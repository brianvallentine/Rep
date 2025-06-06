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
using Sias.VidaAzul.DB2.VA1815B;

namespace Code
{
    public class VA1815B
    {
        public bool IsCall { get; set; }

        public VA1815B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *      RETORNO DOS LANCAMENTOS DE DEBITO EM CONTA FEBRABAN       *      */
        /*"      *           CONVENIOS 6081 GLOBAL , 6088 MULTIPREMIADO,          *      */
        /*"      *                                                                       */
        /*"      *                     6153 PREFERENCIAL VIDA                     *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO SUMARIA                             21.10.97        *      */
        /*"      *                                                                *      */
        /*"      *         O PROGRAMA LE O MOVIMENTO DE RETORNO DOS LANCAMENTOS   *      */
        /*"      *     DE DEBITO DE SEGURO E EFETUA A QUITACAO OU A GERACAO DO    *      */
        /*"      *     RETORNO DO DEBITO NAO EFETUADO.                            *      */
        /*"      *                                                                *      */
        /*"      *         AS PARCELAS NAO DEBITADAS POR CONTA NAO CADASTRADA OU  *      */
        /*"      *     POR QUALQUER MOTIVO QUE GERE O CANCELAMENTO DO DEBITO      *      */
        /*"      *     IRAO FORCAR A MUDANCA DA OPCAO DE PAGAMENTO DO SEGURO DE   *      */
        /*"      *     DEBITO EM CONTA PARA CARNE, NAO GERANDO O CANCELAMENTO DO  *      */
        /*"      *     SEGURO.                                                    *      */
        /*"      *                                                                *      */
        /*"      *         CASO A PARCELA TENHA SIDO PAGA, EH GERADA A TABELA     *      */
        /*"      *     V0REPASSECDG INDICANDO QUE DEVE SER FEITO O REPASSE.       *      */
        /*"      *                                                                *      */
        /*"      *         E GERADO O ARQUIVO RETREL COM O RETORNO QUE APRESENTE  *      */
        /*"      *     INCONSISTENCIA NA ATUALIZACAO, PARA EMISSAO DE RELATORIO,  *      */
        /*"      *     CONTENDO A MENSAGEM DE ERRO.                               *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE FONSECA           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - ABEND 163.669                                    *      */
        /*"      *             - FOI COPIADO O PROGRAMA ATUAL VA1813T2 E GERADO O *      */
        /*"      *   PROGRAMA VA1815B PARA SUBSTITUI-LO E RETIRAR DA DIARIA COMPO-*      */
        /*"      *   NENTES COM NOMENCLATURA TEMPORARIA.                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/05/2018 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 00 - CADMUS 201.024 - CANCELA MOVIMENTOS BAIXADOS     *      */
        /*"      *   NA TABELA SEGUROS.MOVTO_DEBITOCC_CEF E PENDENTES NA TABELA   *      */
        /*"      *   SEGUROS.HIST_LANC_CTA.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2011 - EDIVALDO GOMES                               *      */
        /*"      *                                            PROCURE POR V.00    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RETREL { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RETREL
        {
            get
            {
                _.Move(RETREL_RECORD, _RETREL); VarBasis.RedefinePassValue(RETREL_RECORD, _RETREL, RETREL_RECORD); return _RETREL;
            }
        }
        /*"01  RETREL-RECORD.*/
        public VA1815B_RETREL_RECORD RETREL_RECORD { get; set; } = new VA1815B_RETREL_RECORD();
        public class VA1815B_RETREL_RECORD : VarBasis
        {
            /*"    05 RETREL-REGISTRO   PIC X(150).*/
            public StringBasis RETREL_REGISTRO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  VIND-RISCO                       PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-SAF                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-CDG                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTMOVTO                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-NSAS                        PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-COD-RETORNO                 PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-SITUACAO                   PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WHOST-TIPLANC                    PIC  X(01).*/
        public StringBasis WHOST_TIPLANC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WHOST-CODCONV                    PIC S9(09)    COMP.*/
        public IntBasis WHOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  WHOST-NSAC                       PIC S9(09)  COMP.*/
        public IntBasis WHOST_NSAC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SIST-DTMOVABE                  PIC X(10).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-DTRET                     PIC X(10).*/
        public StringBasis V0FTCF_DTRET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-DTRET2                    PIC X(10).*/
        public StringBasis V0FTCF_DTRET2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-NSAC                      PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0FTCF-NSAC1                     PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_NSAC1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0FTCF-QTLANCDB                  PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTLANCDB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-QTREG                     PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-QTDBEFET                  PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTDBEFET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-TOTDBEFET                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FTCF_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FTCF-TOTDBNEFET                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FTCF_TOTDBNEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FTCF-VERSAO                    PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTVA-PRMVG                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-PRMAP                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-VLCOBADIC                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_VLCOBADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0CAPI-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0CAPI_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PRVG-RISCO                     PIC  X(01).*/
        public StringBasis V0PRVG_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0PRVG_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-SAF                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-CDG                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-ORIG-PRODU                PIC  X(10).*/
        public StringBasis V0PRVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PRVG-CUSTOCAP-TOTAL            PIC  X(01).*/
        public StringBasis V0PRVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-PERIPGTO                  PIC S9(04)    COMP.*/
        public IntBasis V0PRVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-AGECTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-CODRET                    PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-DIGCTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NUMCTADEB                 PIC S9(09)    COMP.*/
        public IntBasis V0HCTA_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0HCTA-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0HCTA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0HCTA-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NSAS                      PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NSL                       PIC S9(09)    COMP.*/
        public IntBasis V0HCTA_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0HCTA-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0HCTA_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTA-OPRCTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-OCORHISTCTA               PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OCORHISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HCTA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTA-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTA_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTA-OCORHISTCOB               PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OCORHISTCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-TIPLANC                   PIC  X(01).*/
        public StringBasis V0HCTA_TIPLANC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTB-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0HCTB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PARC-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PARC-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0PARC_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PARC-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMTOT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMTOTVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RCDG-DTREFER                   PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RCDG-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0RSAF-DTREFER                   PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RSAF-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0PROP-CODSUBES                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-CODPRODU                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-FONTE                     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-NRPARCE                   PIC S9(04)    COMP.*/
        public IntBasis V0PROP_NRPARCE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0PROP-NRMATRFUN                 PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0PROP-INRMATRFUN                PIC S9(04)    COMP.*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-QTDPARATZ                 PIC S9(04)    COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0COBP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-IMPSEGAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-VLCUSTCAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-QTTITCAP                  PIC S9(04)    COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0CDGC-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SAFC-VLCUSTSAF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-DTALTOPC                  PIC  X(10).*/
        public StringBasis V0HCOB_DTALTOPC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0HCOB-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0HCOB-NRTIT                     PIC S9(13)    COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0HCOB-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCOB-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCOB-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0HCOB_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0OPCP-DIADEB                    PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_DIADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0OPCP-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0OPCP-PERIPGTO                  PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-PRMDEVVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEVVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDEVAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEVAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMPAGVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAGVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMPAGAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAGAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDIFVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDIFAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01    V0PROD-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01        RET-HEADER.*/
        public VA1815B_RET_HEADER RET_HEADER { get; set; } = new VA1815B_RET_HEADER();
        public class VA1815B_RET_HEADER : VarBasis
        {
            /*"      05   RA-COD-REG          PIC X(001).*/
            public StringBasis RA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      05   RA-COD-REMESSA      PIC 9(001).*/
            public IntBasis RA_COD_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"      05   RA-COD-CONVENIO     PIC 9(004).*/
            public IntBasis RA_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      05   FILLER              PIC X(016).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
            /*"      05   RA-NOME-EMPRESA     PIC X(020).*/
            public StringBasis RA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      05   RA-COD-BANCO        PIC 9(003).*/
            public IntBasis RA_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      05   RA-NOME-BANCO       PIC X(020).*/
            public StringBasis RA_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      05   RA-DATA-GERACAO.*/
            public VA1815B_RA_DATA_GERACAO RA_DATA_GERACAO { get; set; } = new VA1815B_RA_DATA_GERACAO();
            public class VA1815B_RA_DATA_GERACAO : VarBasis
            {
                /*"       10  RA-AA-GER           PIC X(004).*/
                public StringBasis RA_AA_GER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10  RA-MM-GER           PIC X(002).*/
                public StringBasis RA_MM_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10  RA-DD-GER           PIC X(002).*/
                public StringBasis RA_DD_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      05   RA-NSA              PIC 9(006).*/
            }
            public IntBasis RA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"      05   RA-VERSAO-LAYOUT    PIC 9(002).*/
            public IntBasis RA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      05   RA-SERVICO          PIC X(017).*/
            public StringBasis RA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"      05   RA-RESERVADO        PIC X(052).*/
            public StringBasis RA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01         RET-CADASTRAMENTO.*/
        }
        public VA1815B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA1815B_RET_CADASTRAMENTO();
        public class VA1815B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05   RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05   RF-IDENT-CLI-EMPRESA.*/
            public VA1815B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA1815B_RF_IDENT_CLI_EMPRESA();
            public class VA1815B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10  RF-IDENTIF-CLI      PIC 9(015).*/
                public IntBasis RF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10  RF-IDENTIF-CLI-R REDEFINES           RF-IDENTIF-CLI.*/
                private _REDEF_VA1815B_RF_IDENTIF_CLI_R _rf_identif_cli_r { get; set; }
                public _REDEF_VA1815B_RF_IDENTIF_CLI_R RF_IDENTIF_CLI_R
                {
                    get { _rf_identif_cli_r = new _REDEF_VA1815B_RF_IDENTIF_CLI_R(); _.Move(RF_IDENTIF_CLI, _rf_identif_cli_r); VarBasis.RedefinePassValue(RF_IDENTIF_CLI, _rf_identif_cli_r, RF_IDENTIF_CLI); _rf_identif_cli_r.ValueChanged += () => { _.Move(_rf_identif_cli_r, RF_IDENTIF_CLI); }; return _rf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_identif_cli_r, RF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VA1815B_RF_IDENTIF_CLI_R : VarBasis
                {
                    /*"           15 FILLER           PIC X(015).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10  RF-IDENTIF-NSA      PIC 9(005).*/

                    public _REDEF_VA1815B_RF_IDENTIF_CLI_R()
                    {
                        FILLER_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis RF_IDENTIF_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10  FILLER              PIC X(005).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05 RF-AGECTADEB            PIC 9(004).*/
            }
            public IntBasis RF_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VA1815B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA1815B_RF_IDENT_CLI_BANCO();
            public class VA1815B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10  RF-COD-OPRCTADEB    PIC 9(003).*/
                public IntBasis RF_COD_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  RF-NUM-NUMCTADEB    PIC 9(008).*/
                public IntBasis RF_NUM_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10  RF-DIG-NUMCTADEB    PIC 9(001).*/
                public IntBasis RF_DIG_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10  FILLER              PIC X(002).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL.*/
            }
            public VA1815B_RF_DATA_REAL RF_DATA_REAL { get; set; } = new VA1815B_RF_DATA_REAL();
            public class VA1815B_RF_DATA_REAL : VarBasis
            {
                /*"       10  RF-ANO-REAL         PIC 9(004).*/
                public IntBasis RF_ANO_REAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-MES-REAL         PIC 9(002).*/
                public IntBasis RF_MES_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  RF-DIA-REAL         PIC 9(002).*/
                public IntBasis RF_DIA_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 RF-VLPRMTOT             PIC 9(013)V99.*/
            }
            public DoubleBasis RF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNO          PIC 9(002).*/
            public IntBasis RF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESA.*/
            public VA1815B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA1815B_RF_USO_EMPRESA();
            public class VA1815B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10  RF-NSA              PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  RF-NSL              PIC 9(008).*/
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10  FILLER              PIC X(047).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 RF-RESERVADO            PIC X(022).*/
            }
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
            /*"    05 RF-COD-MOVIMENTO        PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLER.*/
        }
        public VA1815B_RET_TRAILLER RET_TRAILLER { get; set; } = new VA1815B_RET_TRAILLER();
        public class VA1815B_RET_TRAILLER : VarBasis
        {
            /*"    05 RZ-COD-REG              PIC X(001).*/
            public StringBasis RZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RZ-QTDE-REGISTROS       PIC 9(006).*/
            public IntBasis RZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RZ-TOT-DEB-CRUZ         PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-TOT-CRED-CRUZ        PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_CRED_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-RESERVADO            PIC X(109).*/
            public StringBasis RZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01        RET-CABEC0.*/
        }
        public VA1815B_RET_CABEC0 RET_CABEC0 { get; set; } = new VA1815B_RET_CABEC0();
        public class VA1815B_RET_CABEC0 : VarBasis
        {
            /*"      05   FILLER              PIC X(018) VALUE          'PROGRAMA: VA1815B'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"PROGRAMA: VA1815B");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(020) VALUE          'DATA PROCESSAMENTO:'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DATA PROCESSAMENTO:");
            /*"      05   RET-CABEC0-DATA     PIC X(010).*/
            public StringBasis RET_CABEC0_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(048) VALUE          'MOVTO-DEBITOCC-CEF X HIST-LANC-CTA - ATUALIZADOR'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"MOVTO_DEBITOCC_CEF X HIST_LANC_CTA - ATUALIZADOR");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01         RET-CABEC.*/
        }
        public VA1815B_RET_CABEC RET_CABEC { get; set; } = new VA1815B_RET_CABEC();
        public class VA1815B_RET_CABEC : VarBasis
        {
            /*"      05   FILLER              PIC X(004) VALUE          'NSAS'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"NSAS");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(003) VALUE          'NSL'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NSL");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(011) VALUE          'CERTIFICADO'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CERTIFICADO");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(010) VALUE          'VENCIMENTO'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VENCIMENTO");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(007) VALUE          'PARCELA'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(014) VALUE          'PREMIO ARQUIVO'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"PREMIO ARQUIVO");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(011) VALUE          'PREMIO BASE'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PREMIO BASE");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05   FILLER              PIC X(007) VALUE          'RETORNO'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"RETORNO");
            /*"      05   FILLER              PIC X(001) VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01         REGISTRO-SAIDA.*/
        }
        public VA1815B_REGISTRO_SAIDA REGISTRO_SAIDA { get; set; } = new VA1815B_REGISTRO_SAIDA();
        public class VA1815B_REGISTRO_SAIDA : VarBasis
        {
            /*"   10       SAIDA-NSAS                PIC  9(005).*/
            public IntBasis SAIDA_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"   10       FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10       SAIDA-NSL                 PIC  9(008).*/
            public IntBasis SAIDA_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   10       FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10       SAIDA-NRCERTIF            PIC  9(015).*/
            public IntBasis SAIDA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"   10       FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10       SAIDA-DTVENCTO            PIC  X(010).*/
            public StringBasis SAIDA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   10       FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10       SAIDA-NRPARCEL            PIC  9(004).*/
            public IntBasis SAIDA_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   10       FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10       SAIDA-VLR-PREMIO          PIC  99999999999,99.*/
            public DoubleBasis SAIDA_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "11", "99999999999V99."), 2);
            /*"   10       FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10       SAIDA-VLR-PREMIO1         PIC  99999999999,99.*/
            public DoubleBasis SAIDA_VLR_PREMIO1 { get; set; } = new DoubleBasis(new PIC("9", "11", "99999999999V99."), 2);
            /*"   10       FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10       SAIDA-COD-RETORNO         PIC  X(030).*/
            public StringBasis SAIDA_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"   10       FILLER                    PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REGISTRO-WORK.*/
        }
        public VA1815B_REGISTRO_WORK REGISTRO_WORK { get; set; } = new VA1815B_REGISTRO_WORK();
        public class VA1815B_REGISTRO_WORK : VarBasis
        {
            /*"   10      WORK-NSAS                PIC  9(005).*/
            public IntBasis WORK_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"   10       WORK-NSL                  PIC  9(008).*/
            public IntBasis WORK_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   10       WORK-VLR-PREMIO           PIC  9(011)V99.*/
            public DoubleBasis WORK_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"   10       WORK-COD-RETORNO          PIC  9(002).*/
            public IntBasis WORK_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  WORK-AREA.*/
        }
        public VA1815B_WORK_AREA WORK_AREA { get; set; } = new VA1815B_WORK_AREA();
        public class VA1815B_WORK_AREA : VarBasis
        {
            /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 AC-CONTA                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05      DATA-SQL.*/
            public VA1815B_DATA_SQL DATA_SQL { get; set; } = new VA1815B_DATA_SQL();
            public class VA1815B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL                  PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-SQL                  PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-SQL                  PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-TIME                       PIC  X(008).*/
            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 WS-DATA-INV.*/
            public VA1815B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA1815B_WS_DATA_INV();
            public class VA1815B_WS_DATA_INV : VarBasis
            {
                /*"      10 WS-ANO-INV                  PIC  9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-MES-INV                  PIC  9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 WS-DIA-INV                  PIC  9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/
            }
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-NAO-ACHEI             PIC  9(001) VALUE 0.*/
            public IntBasis WS_NAO_ACHEI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-CODCONV               PIC  9(004).*/
            public IntBasis WS_CODCONV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 WS-REGISTROS              PIC  9(9)      VALUE  0.*/
            public IntBasis WS_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-QTDBEFET               PIC  9(9)      VALUE  0.*/
            public IntBasis WS_QTDBEFET { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-ACG-TOTDBEFET          PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_ACG_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-ACG-TOTDBNEFET         PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_ACG_TOTDBNEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-DIFERENCA              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_DIFERENCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-PC-VG                  PIC  9(03)V9(7) VALUE  0.*/
            public DoubleBasis WS_PC_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"    05 WS-PCT-COB-VG             PIC  9(03)V9(7) VALUE  0.*/
            public DoubleBasis WS_PCT_COB_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"    05 WS-PCT-COB-AP             PIC  9(03)V9(7) VALUE  0.*/
            public DoubleBasis WS_PCT_COB_AP { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"    05 AUX-NSAC                  PIC  9(005).*/
            public IntBasis AUX_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05 AUX-CONVENIO              PIC  9(004).*/
            public IntBasis AUX_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 LD-PRODUTO                PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis LD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05 WS-NRAVISO                PIC  9(009)    VALUE  0.*/
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 FILLER                    REDEFINES      WS-NRAVISO.*/
            private _REDEF_VA1815B_FILLER_37 _filler_37 { get; set; }
            public _REDEF_VA1815B_FILLER_37 FILLER_37
            {
                get { _filler_37 = new _REDEF_VA1815B_FILLER_37(); _.Move(WS_NRAVISO, _filler_37); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_37, WS_NRAVISO); _filler_37.ValueChanged += () => { _.Move(_filler_37, WS_NRAVISO); }; return _filler_37; }
                set { VarBasis.RedefinePassValue(value, _filler_37, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_VA1815B_FILLER_37 : VarBasis
            {
                /*"      10 WS-AGEAVISO             PIC  9(004).*/
                public IntBasis WS_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-NSAC                 PIC  9(005).*/
                public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05       WS-SUBS           PIC  9(005)    VALUE ZEROS.*/

                public _REDEF_VA1815B_FILLER_37()
                {
                    WS_AGEAVISO.ValueChanged += OnValueChanged;
                    WS_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WS-SUBS1          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WS-SUBS2          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WFIM-PRODUTO      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA1815B_FILLER_38 _filler_38 { get; set; }
            public _REDEF_VA1815B_FILLER_38 FILLER_38
            {
                get { _filler_38 = new _REDEF_VA1815B_FILLER_38(); _.Move(WDATA_REL, _filler_38); VarBasis.RedefinePassValue(WDATA_REL, _filler_38, WDATA_REL); _filler_38.ValueChanged += () => { _.Move(_filler_38, WDATA_REL); }; return _filler_38; }
                set { VarBasis.RedefinePassValue(value, _filler_38, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA1815B_FILLER_38 : VarBasis
            {
                /*"      10     WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/

                public _REDEF_VA1815B_FILLER_38()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_39.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_40.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VA1815B_WABEND WABEND { get; set; } = new VA1815B_WABEND();
            public class VA1815B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA1815B  '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA1815B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA1815B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA1815B_LOCALIZA_ABEND_1();
            public class VA1815B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA1815B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA1815B_LOCALIZA_ABEND_2();
            public class VA1815B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public VA1815B_WS_HORAS WS_HORAS { get; set; } = new VA1815B_WS_HORAS();
        public class VA1815B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA1815B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA1815B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA1815B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA1815B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VA1815B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA1815B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA1815B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA1815B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA1815B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VA1815B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VA1815B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA1815B_TOTAIS_ROT();
        public class VA1815B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VA1815B_FILLER_49> FILLER_49 { get; set; } = new ListBasis<VA1815B_FILLER_49>(50);
            public class VA1815B_FILLER_49 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Dclgens.VGFOLLOW VGFOLLOW { get; set; } = new Dclgens.VGFOLLOW();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public VA1815B_CMOVDEB CMOVDEB { get; set; } = new VA1815B_CMOVDEB();
        public VA1815B_CHCONTA2 CHCONTA2 { get; set; } = new VA1815B_CHCONTA2();
        public VA1815B_CHCONTA3 CHCONTA3 { get; set; } = new VA1815B_CHCONTA3();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETREL_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETREL.SetFile(RETREL_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -469- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -472- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -475- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -478- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -479- DISPLAY 'PROGRAMA EM EXECUCAO VA1815B ' */
            _.Display($"PROGRAMA EM EXECUCAO VA1815B ");

            /*" -480- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -481- DISPLAY 'VERSAO V.00 201.024 17/02/2011 ' */
            _.Display($"VERSAO V.00 201.024 17/02/2011 ");

            /*" -482- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -484- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -486- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -488- OPEN OUTPUT RETREL. */
            RETREL.Open(RETREL_RECORD);

            /*" -489- MOVE '0001-INICIO  ' TO PARAGRAFO. */
            _.Move("0001-INICIO  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -491- MOVE 'SELECT V1SISTEMA' TO COMANDO. */
            _.Move("SELECT V1SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -492- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -494- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -499- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -503- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -504- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -505- DISPLAY 'SISTEMA NAO ENCONTRADO' */
                _.Display($"SISTEMA NAO ENCONTRADO");

                /*" -507- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -510- MOVE V0SIST-DTMOVABE (9:2) TO RA-DATA-GERACAO(7:2) */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(9, 2), RET_HEADER.RA_DATA_GERACAO, 7, 2);

            /*" -510- MOVE V0SIST-DTMOVABE (9:2) TO RET-CABEC0-DATA(1:2) */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(9, 2), RET_CABEC0.RET_CABEC0_DATA, 1, 2);

            /*" -513- MOVE V0SIST-DTMOVABE (6:2) TO RA-DATA-GERACAO(5:2) */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(6, 2), RET_HEADER.RA_DATA_GERACAO, 5, 2);

            /*" -513- MOVE V0SIST-DTMOVABE (6:2) TO RET-CABEC0-DATA(4:2) */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(6, 2), RET_CABEC0.RET_CABEC0_DATA, 4, 2);

            /*" -516- MOVE V0SIST-DTMOVABE (1:4) TO RA-DATA-GERACAO(1:4) */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(1, 4), RET_HEADER.RA_DATA_GERACAO, 1, 4);

            /*" -516- MOVE V0SIST-DTMOVABE (1:4) TO RET-CABEC0-DATA(7:4) */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(1, 4), RET_CABEC0.RET_CABEC0_DATA, 7, 4);

            /*" -520- MOVE '/' TO RET-CABEC0-DATA(6:1). */
            _.MoveAtPosition("/", RET_CABEC0.RET_CABEC0_DATA, 6, 1);

            /*" -520- MOVE '/' TO RET-CABEC0-DATA(3:1) */
            _.MoveAtPosition("/", RET_CABEC0.RET_CABEC0_DATA, 3, 1);

            /*" -521- WRITE RETREL-RECORD FROM RET-CABEC0. */
            _.Move(RET_CABEC0.GetMoveValues(), RETREL_RECORD);

            RETREL.Write(RETREL_RECORD.GetMoveValues().ToString());

            /*" -523- WRITE RETREL-RECORD FROM RET-CABEC. */
            _.Move(RET_CABEC.GetMoveValues(), RETREL_RECORD);

            RETREL.Write(RETREL_RECORD.GetMoveValues().ToString());

            /*" -524- PERFORM R0001-00-DECLARE-CURSOR. */

            R0001_00_DECLARE_CURSOR_SECTION();

            /*" -526- PERFORM R0002-00-FETCH-CURSOR. */

            R0002_00_FETCH_CURSOR_SECTION();

            /*" -527- MOVE 6088 TO RA-COD-CONVENIO */
            _.Move(6088, RET_HEADER.RA_COD_CONVENIO);

            /*" -532- MOVE RA-COD-CONVENIO TO WS-CODCONV WHOST-CODCONV. */
            _.Move(RET_HEADER.RA_COD_CONVENIO, WORK_AREA.WS_CODCONV, WHOST_CODCONV);

            /*" -533- IF WS-CODCONV NOT EQUAL 6081 AND 6088 AND 6132 AND 6153 */

            if (!WORK_AREA.WS_CODCONV.In("6081", "6088", "6132", "6153"))
            {

                /*" -535- GO TO R0001-00-FIM-NORMAL. */

                R0001_00_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -541- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -544- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -545- DISPLAY 'PROBLEMAS NO ACESSO A V0FITACEF' */
                _.Display($"PROBLEMAS NO ACESSO A V0FITACEF");

                /*" -546- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -548- END-IF. */
            }


            /*" -550- IF WHOST-NSAC = ZEROS */

            if (WHOST_NSAC == 00)
            {

                /*" -551- MOVE 4000 TO WHOST-NSAC */
                _.Move(4000, WHOST_NSAC);

                /*" -552- ELSE */
            }
            else
            {


                /*" -553- ADD 1 TO WHOST-NSAC */
                WHOST_NSAC.Value = WHOST_NSAC + 1;

                /*" -555- END-IF. */
            }


            /*" -556- MOVE WHOST-NSAC TO RA-NSA */
            _.Move(WHOST_NSAC, RET_HEADER.RA_NSA);

            /*" -558- MOVE RA-NSA TO V0FTCF-NSAC. */
            _.Move(RET_HEADER.RA_NSA, V0FTCF_NSAC);

            /*" -559- MOVE WS-CODCONV TO AUX-CONVENIO */
            _.Move(WORK_AREA.WS_CODCONV, WORK_AREA.AUX_CONVENIO);

            /*" -573- MOVE RA-NSA TO AUX-NSAC. */
            _.Move(RET_HEADER.RA_NSA, WORK_AREA.AUX_NSAC);

            /*" -574- MOVE RA-DATA-GERACAO TO WS-DATA-INV. */
            _.Move(RET_HEADER.RA_DATA_GERACAO, WORK_AREA.WS_DATA_INV);

            /*" -575- MOVE WS-ANO-INV TO ANO-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -576- MOVE WS-MES-INV TO MES-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -578- MOVE WS-DIA-INV TO DIA-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -579- MOVE DATA-SQL TO V0FTCF-DTRET. */
            _.Move(WORK_AREA.DATA_SQL, V0FTCF_DTRET);

            /*" -580- MOVE DATA-SQL TO V0FTCF-DTRET2. */
            _.Move(WORK_AREA.DATA_SQL, V0FTCF_DTRET2);

            /*" -582- MOVE RA-VERSAO-LAYOUT TO V0FTCF-VERSAO. */
            _.Move(RET_HEADER.RA_VERSAO_LAYOUT, V0FTCF_VERSAO);

            /*" -585- PERFORM R0020-00-PROCESSA UNTIL WS-EOF = 1. */

            while (!(WORK_AREA.WS_EOF == 1))
            {

                R0020_00_PROCESSA_SECTION();
            }

            /*" -587- DISPLAY '*** VA1815B *** LANCAMENTOS RETORNADOS ' WS-REGISTROS. */
            _.Display($"*** VA1815B *** LANCAMENTOS RETORNADOS {WORK_AREA.WS_REGISTROS}");

            /*" -590- DISPLAY '*** VA1815B *** DEBITOS NAO EFET       ' WS-ACG-TOTDBNEFET. */
            _.Display($"*** VA1815B *** DEBITOS NAO EFET       {WORK_AREA.WS_ACG_TOTDBNEFET}");

            /*" -591- IF WS-REGISTROS GREATER ZEROES */

            if (WORK_AREA.WS_REGISTROS > 00)
            {

                /*" -591- PERFORM R0050-00-GERA-FITACEF. */

                R0050_00_GERA_FITACEF_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0001_00_FIM_NORMAL */

            R0001_00_FIM_NORMAL();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -499- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R0001-00-FIM-NORMAL */
        private void R0001_00_FIM_NORMAL(bool isPerform = false)
        {
            /*" -595- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -599- CLOSE RETREL. */
            RETREL.Close();

            /*" -600- DISPLAY '*** VA1815B *** TERMINO NORMAL' . */
            _.Display($"*** VA1815B *** TERMINO NORMAL");

            /*" -602- DISPLAY ' ' . */
            _.Display($" ");

            /*" -604- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -606- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -606- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -541- EXEC SQL SELECT VALUE(MAX(NSAC),0) INTO :WHOST-NSAC FROM SEGUROS.V0FITACEF WHERE NSAC BETWEEN 4000 AND 4999 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NSAC, WHOST_NSAC);
            }


        }

        [StopWatch]
        /*" R0001-00-FIM-ANORMAL */
        private void R0001_00_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -611- DISPLAY '*** VA1815B *** PROCESSAMENTO TERMINOU COM ERRO' . */
            _.Display($"*** VA1815B *** PROCESSAMENTO TERMINOU COM ERRO");

            /*" -613- DISPLAY '*** VA1815B *** VIDE ARQUIVO RETREL COM MSG' . */
            _.Display($"*** VA1815B *** VIDE ARQUIVO RETREL COM MSG");

            /*" -613- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -617- CLOSE RETREL. */
            RETREL.Close();

            /*" -619- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -619- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0001-00-DECLARE-CURSOR-SECTION */
        private void R0001_00_DECLARE_CURSOR_SECTION()
        {
            /*" -626- MOVE 'DECLARE CURSOR' TO COMANDO. */
            _.Move("DECLARE CURSOR", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -640- PERFORM R0001_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0001_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -642- PERFORM R0001_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0001_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -645- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -646- DISPLAY 'VA0813T2 - PROBLEMAS NO OPEN CMOVDEB ' */
                _.Display($"VA0813T2 - PROBLEMAS NO OPEN CMOVDEB ");

                /*" -646- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0001-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0001_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -640- EXEC SQL DECLARE CMOVDEB CURSOR FOR SELECT A.NSAS, A.NUM_ENDOSSO, A.COD_RETORNO_CEF, A.VALOR_DEBITO FROM SEGUROS.MOVTO_DEBITOCC_CEF A, SEGUROS.HIST_LANC_CTA B WHERE A.COD_CONVENIO = 608800 AND A.SITUACAO_COBRANCA IN ( '2' , '3' ) AND A.COD_RETORNO_CEF IN (97, 98, 99) AND A.NUM_CARTAO = B.NUM_CERTIFICADO AND A.NSAS = B.NSAS AND A.NUM_ENDOSSO = B.NSL AND B.SIT_REGISTRO = '3' END-EXEC. */
            CMOVDEB = new VA1815B_CMOVDEB(false);
            string GetQuery_CMOVDEB()
            {
                var query = @$"SELECT A.NSAS
							, 
							A.NUM_ENDOSSO
							, 
							A.COD_RETORNO_CEF
							, 
							A.VALOR_DEBITO 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF A
							, 
							SEGUROS.HIST_LANC_CTA B 
							WHERE A.COD_CONVENIO = 608800 
							AND A.SITUACAO_COBRANCA IN ( '2'
							, '3' ) 
							AND A.COD_RETORNO_CEF IN (97
							, 98
							, 99) 
							AND A.NUM_CARTAO = B.NUM_CERTIFICADO 
							AND A.NSAS = B.NSAS 
							AND A.NUM_ENDOSSO = B.NSL 
							AND B.SIT_REGISTRO = '3'";

                return query;
            }
            CMOVDEB.GetQueryEvent += GetQuery_CMOVDEB;

        }

        [StopWatch]
        /*" R0001-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R0001_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -642- EXEC SQL OPEN CMOVDEB END-EXEC. */

            CMOVDEB.Open();

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-DECLARE-1 */
        public void R0030_00_ACESSO_CERTIF_DB_DECLARE_1()
        {
            /*" -1074- EXEC SQL DECLARE CHCONTA2 CURSOR FOR SELECT NRPARCEL, OCORRHISTCTA, NSAS, NSL, TIPLANC FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND TIPLANC = '1' AND SITUACAO = '3' ORDER BY NRPARCEL, TIPLANC DESC END-EXEC. */
            CHCONTA2 = new VA1815B_CHCONTA2(true);
            string GetQuery_CHCONTA2()
            {
                var query = @$"SELECT NRPARCEL
							, 
							OCORRHISTCTA
							, 
							NSAS
							, 
							NSL
							, 
							TIPLANC 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE NRCERTIF = '{V0HCTA_NRCERTIF}' 
							AND TIPLANC = '1' 
							AND SITUACAO = '3' 
							ORDER BY NRPARCEL
							, TIPLANC DESC";

                return query;
            }
            CHCONTA2.GetQueryEvent += GetQuery_CHCONTA2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_SAIDA*/

        [StopWatch]
        /*" R0002-00-FETCH-CURSOR-SECTION */
        private void R0002_00_FETCH_CURSOR_SECTION()
        {
            /*" -656- MOVE 'FETCH   CURSOR' TO COMANDO. */
            _.Move("FETCH   CURSOR", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -661- PERFORM R0002_00_FETCH_CURSOR_DB_FETCH_1 */

            R0002_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -665- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -666- MOVE 1 TO WS-EOF */
                    _.Move(1, WORK_AREA.WS_EOF);

                    /*" -666- PERFORM R0002_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R0002_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -668- ELSE */
                }
                else
                {


                    /*" -669- DISPLAY 'VA0813T2 - PROBLEMAS NO FETCH CMOVDEB ' */
                    _.Display($"VA0813T2 - PROBLEMAS NO FETCH CMOVDEB ");

                    /*" -671- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -672- IF VIND-NSAS LESS ZEROS */

            if (VIND_NSAS < 00)
            {

                /*" -673- MOVE ZEROS TO MOVDEBCE-NSAS */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

                /*" -675- END-IF. */
            }


            /*" -676- IF VIND-COD-RETORNO LESS ZEROS */

            if (VIND_COD_RETORNO < 00)
            {

                /*" -677- MOVE ZEROS TO VIND-COD-RETORNO */
                _.Move(0, VIND_COD_RETORNO);

                /*" -677- END-IF. */
            }


        }

        [StopWatch]
        /*" R0002-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R0002_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -661- EXEC SQL FETCH CMOVDEB INTO :MOVDEBCE-NSAS:VIND-NSAS, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-COD-RETORNO-CEF:VIND-COD-RETORNO, :MOVDEBCE-VALOR-DEBITO END-EXEC. */

            if (CMOVDEB.Fetch())
            {
                _.Move(CMOVDEB.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(CMOVDEB.VIND_NSAS, VIND_NSAS);
                _.Move(CMOVDEB.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(CMOVDEB.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);
                _.Move(CMOVDEB.VIND_COD_RETORNO, VIND_COD_RETORNO);
                _.Move(CMOVDEB.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
            }

        }

        [StopWatch]
        /*" R0002-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R0002_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -666- EXEC SQL CLOSE CMOVDEB END-EXEC */

            CMOVDEB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0002_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-PROCESSA-SECTION */
        private void R0020_00_PROCESSA_SECTION()
        {
            /*" -687- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -690- MOVE MOVDEBCE-NSAS TO WORK-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REGISTRO_WORK.WORK_NSAS);

            /*" -693- MOVE MOVDEBCE-NUM-ENDOSSO TO WORK-NSL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REGISTRO_WORK.WORK_NSL);

            /*" -696- MOVE MOVDEBCE-COD-RETORNO-CEF TO WORK-COD-RETORNO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF, REGISTRO_WORK.WORK_COD_RETORNO);

            /*" -699- MOVE MOVDEBCE-VALOR-DEBITO TO WORK-VLR-PREMIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, REGISTRO_WORK.WORK_VLR_PREMIO);

            /*" -700- ADD 1 TO AC-LIDOS AC-CONTA. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            WORK_AREA.AC_CONTA.Value = WORK_AREA.AC_CONTA + 1;

            /*" -701- IF AC-CONTA > 999 */

            if (WORK_AREA.AC_CONTA > 999)
            {

                /*" -702- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WORK_AREA.AC_CONTA);

                /*" -703- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -705- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME. */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WORK_AREA.WS_TIME}"
                .Display();
            }


            /*" -708- MOVE WORK-VLR-PREMIO TO RF-VLPRMTOT */
            _.Move(REGISTRO_WORK.WORK_VLR_PREMIO, RET_CADASTRAMENTO.RF_VLPRMTOT);

            /*" -711- MOVE WORK-COD-RETORNO TO RF-COD-RETORNO */
            _.Move(REGISTRO_WORK.WORK_COD_RETORNO, RET_CADASTRAMENTO.RF_COD_RETORNO);

            /*" -714- MOVE WORK-NSAS TO RF-IDENTIF-NSA */
            _.Move(REGISTRO_WORK.WORK_NSAS, RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA);

            /*" -718- MOVE WORK-NSL TO RF-NSL */
            _.Move(REGISTRO_WORK.WORK_NSL, RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL);

            /*" -720- IF RF-VLPRMTOT EQUAL ZEROS OR RF-COD-RETORNO EQUAL 96 */

            if (RET_CADASTRAMENTO.RF_VLPRMTOT == 00 || RET_CADASTRAMENTO.RF_COD_RETORNO == 96)
            {

                /*" -721- DISPLAY '************************' */
                _.Display($"************************");

                /*" -722- DISPLAY 'DEBITO COM VALOR ZERADO ' */
                _.Display($"DEBITO COM VALOR ZERADO ");

                /*" -723- DISPLAY 'RF-NSA - ' RF-NSA */
                _.Display($"RF-NSA - {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA}");

                /*" -724- DISPLAY 'RF-NSL - ' RF-NSL */
                _.Display($"RF-NSL - {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL}");

                /*" -726- DISPLAY '************************' */
                _.Display($"************************");

                /*" -728- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -732- MOVE 0 TO WS-NAO-ACHEI. */
            _.Move(0, WORK_AREA.WS_NAO_ACHEI);

            /*" -733- IF RF-COD-RETORNO NOT EQUAL 97 AND 98 AND 99 */

            if (!RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99"))
            {

                /*" -735- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -736- IF RF-VLPRMTOT GREATER ZEROES */

            if (RET_CADASTRAMENTO.RF_VLPRMTOT > 00)
            {

                /*" -737- PERFORM R0036-00-ACESSO-NSAS */

                R0036_00_ACESSO_NSAS_SECTION();

                /*" -739- END-IF. */
            }


            /*" -740- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -742- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -743- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -745- MOVE RF-COD-RETORNO TO V0HCTA-CODRET. */
            _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, V0HCTA_CODRET);

            /*" -746- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -748- MOVE 'SELECT V0PARCELVA' TO COMANDO. */
            _.Move("SELECT V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -749- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -751- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -765- PERFORM R0020_00_PROCESSA_DB_SELECT_1 */

            R0020_00_PROCESSA_DB_SELECT_1();

            /*" -769- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -770- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -772- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -774- MOVE 'SELECT V0HISTCOBVA' TO COMANDO. */
            _.Move("SELECT V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -775- MOVE 03 TO SII. */
            _.Move(03, WS_HORAS.SII);

            /*" -777- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -795- PERFORM R0020_00_PROCESSA_DB_SELECT_2 */

            R0020_00_PROCESSA_DB_SELECT_2();

            /*" -799- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -800- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -802- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -804- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -805- MOVE 04 TO SII. */
            _.Move(04, WS_HORAS.SII);

            /*" -807- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -817- PERFORM R0020_00_PROCESSA_DB_SELECT_3 */

            R0020_00_PROCESSA_DB_SELECT_3();

            /*" -821- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -822- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -824- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -826- MOVE 0 TO V0HCTA-OCORHISTCOB. */
            _.Move(0, V0HCTA_OCORHISTCOB);

            /*" -828- MOVE 'SELECT V0PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -829- MOVE 22 TO SII */
            _.Move(22, WS_HORAS.SII);

            /*" -831- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -869- PERFORM R0020_00_PROCESSA_DB_SELECT_4 */

            R0020_00_PROCESSA_DB_SELECT_4();

            /*" -873- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -874- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -876- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -877- IF V0PROP-INRMATRFUN LESS 0 */

            if (V0PROP_INRMATRFUN < 0)
            {

                /*" -879- MOVE 0 TO V0PROP-NRMATRFUN. */
                _.Move(0, V0PROP_NRMATRFUN);
            }


            /*" -880- IF VIND-TEM-SAF LESS 0 */

            if (VIND_TEM_SAF < 0)
            {

                /*" -882- MOVE 'N' TO V0PRVG-TEM-SAF. */
                _.Move("N", V0PRVG_TEM_SAF);
            }


            /*" -883- IF VIND-TEM-CDG LESS 0 */

            if (VIND_TEM_CDG < 0)
            {

                /*" -885- MOVE 'N' TO V0PRVG-TEM-CDG. */
                _.Move("N", V0PRVG_TEM_CDG);
            }


            /*" -886- IF VIND-RISCO LESS 0 */

            if (VIND_RISCO < 0)
            {

                /*" -891- MOVE '1' TO V0PRVG-RISCO. */
                _.Move("1", V0PRVG_RISCO);
            }


            /*" -893- PERFORM R2000-00-REJEITA-PARCELA. */

            R2000_00_REJEITA_PARCELA_SECTION();

            /*" -894- IF RF-COD-RETORNO EQUAL 97 OR 98 OR 99 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99"))
            {

                /*" -896- PERFORM R0023-00-ATUALIZA-ESTORNO. */

                R0023_00_ATUALIZA_ESTORNO_SECTION();
            }


            /*" -898- MOVE RF-IDENTIF-NSA TO SAIDA-NSAS */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, REGISTRO_SAIDA.SAIDA_NSAS);

            /*" -900- MOVE RF-NSL TO SAIDA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, REGISTRO_SAIDA.SAIDA_NSL);

            /*" -902- MOVE V0HCTA-NRCERTIF TO SAIDA-NRCERTIF */
            _.Move(V0HCTA_NRCERTIF, REGISTRO_SAIDA.SAIDA_NRCERTIF);

            /*" -904- MOVE V0HCOB-DTVENCTO TO SAIDA-DTVENCTO */
            _.Move(V0HCOB_DTVENCTO, REGISTRO_SAIDA.SAIDA_DTVENCTO);

            /*" -906- MOVE V0HCTA-NRPARCEL TO SAIDA-NRPARCEL */
            _.Move(V0HCTA_NRPARCEL, REGISTRO_SAIDA.SAIDA_NRPARCEL);

            /*" -908- MOVE RF-VLPRMTOT TO SAIDA-VLR-PREMIO */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, REGISTRO_SAIDA.SAIDA_VLR_PREMIO);

            /*" -911- MOVE V0HCOB-VLPRMTOT TO SAIDA-VLR-PREMIO1 */
            _.Move(V0HCOB_VLPRMTOT, REGISTRO_SAIDA.SAIDA_VLR_PREMIO1);

            /*" -912- IF RF-COD-RETORNO EQUAL 00 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00)
            {

                /*" -914- MOVE 'DEBITO EFETUADO' TO SAIDA-COD-RETORNO */
                _.Move("DEBITO EFETUADO", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                /*" -915- ELSE */
            }
            else
            {


                /*" -916- IF RF-COD-RETORNO EQUAL 01 */

                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 01)
                {

                    /*" -918- MOVE 'INSUFICIENCIA DE FUNDOS' TO SAIDA-COD-RETORNO */
                    _.Move("INSUFICIENCIA DE FUNDOS", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                    /*" -919- ELSE */
                }
                else
                {


                    /*" -920- IF RF-COD-RETORNO EQUAL 02 */

                    if (RET_CADASTRAMENTO.RF_COD_RETORNO == 02)
                    {

                        /*" -922- MOVE 'CONTA NAO CADASTRADA' TO SAIDA-COD-RETORNO */
                        _.Move("CONTA NAO CADASTRADA", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                        /*" -923- ELSE */
                    }
                    else
                    {


                        /*" -924- IF RF-COD-RETORNO EQUAL 04 */

                        if (RET_CADASTRAMENTO.RF_COD_RETORNO == 04)
                        {

                            /*" -926- MOVE 'OUTRAS RESTRICOES' TO SAIDA-COD-RETORNO */
                            _.Move("OUTRAS RESTRICOES", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                            /*" -927- ELSE */
                        }
                        else
                        {


                            /*" -928- IF RF-COD-RETORNO EQUAL 10 */

                            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 10)
                            {

                                /*" -930- MOVE 'AGENCIA EM REGIME ENCERR' TO SAIDA-COD-RETORNO */
                                _.Move("AGENCIA EM REGIME ENCERR", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                                /*" -931- ELSE */
                            }
                            else
                            {


                                /*" -932- IF RF-COD-RETORNO EQUAL 12 */

                                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 12)
                                {

                                    /*" -934- MOVE 'VALOR INVALIDO' TO SAIDA-COD-RETORNO */
                                    _.Move("VALOR INVALIDO", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                                    /*" -935- ELSE */
                                }
                                else
                                {


                                    /*" -936- IF RF-COD-RETORNO EQUAL 14 */

                                    if (RET_CADASTRAMENTO.RF_COD_RETORNO == 14)
                                    {

                                        /*" -938- MOVE 'AGENCIA INVALIDA' TO SAIDA-COD-RETORNO */
                                        _.Move("AGENCIA INVALIDA", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                                        /*" -939- ELSE */
                                    }
                                    else
                                    {


                                        /*" -940- IF RF-COD-RETORNO EQUAL 15 */

                                        if (RET_CADASTRAMENTO.RF_COD_RETORNO == 15)
                                        {

                                            /*" -942- MOVE 'DV DA CONTA INVALIDO' TO SAIDA-COD-RETORNO */
                                            _.Move("DV DA CONTA INVALIDO", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                                            /*" -943- ELSE */
                                        }
                                        else
                                        {


                                            /*" -944- IF RF-COD-RETORNO EQUAL 96 */

                                            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 96)
                                            {

                                                /*" -946- MOVE 'VALOR ZERADO' TO SAIDA-COD-RETORNO */
                                                _.Move("VALOR ZERADO", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                                                /*" -947- ELSE */
                                            }
                                            else
                                            {


                                                /*" -948- IF RF-COD-RETORNO EQUAL 97 */

                                                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 97)
                                                {

                                                    /*" -950- MOVE 'CANCEL. P/LANC NAO ENCONT' TO SAIDA-COD-RETORNO */
                                                    _.Move("CANCEL. P/LANC NAO ENCONT", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                                                    /*" -951- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -952- IF RF-COD-RETORNO EQUAL 98 */

                                                    if (RET_CADASTRAMENTO.RF_COD_RETORNO == 98)
                                                    {

                                                        /*" -954- MOVE 'CANCEL. P/LANC FORA DATA' TO SAIDA-COD-RETORNO */
                                                        _.Move("CANCEL. P/LANC FORA DATA", REGISTRO_SAIDA.SAIDA_COD_RETORNO);

                                                        /*" -955- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -956- IF RF-COD-RETORNO EQUAL 99 */

                                                        if (RET_CADASTRAMENTO.RF_COD_RETORNO == 99)
                                                        {

                                                            /*" -959- MOVE 'AUTORIZ. DEBITO CANCELADA' TO SAIDA-COD-RETORNO. */
                                                            _.Move("AUTORIZ. DEBITO CANCELADA", REGISTRO_SAIDA.SAIDA_COD_RETORNO);
                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -962- WRITE RETREL-RECORD FROM REGISTRO-SAIDA */
            _.Move(REGISTRO_SAIDA.GetMoveValues(), RETREL_RECORD);

            RETREL.Write(RETREL_RECORD.GetMoveValues().ToString());

            /*" -964- ADD 1 TO WS-REGISTROS. */
            WORK_AREA.WS_REGISTROS.Value = WORK_AREA.WS_REGISTROS + 1;

            /*" -965- MOVE RF-IDENTIF-CLI TO VGFOLLOW-NUM-CERTIFICADO. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO);

            /*" -966- MOVE RF-IDENTIF-NSA TO VGFOLLOW-NUM-NOSSA-FITA. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA);

            /*" -968- MOVE RF-NSL TO VGFOLLOW-NUM-LANCAMENTO. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO);

            /*" -968- PERFORM R8800-00-UPDATE-FOLLOWUP. */

            R8800_00_UPDATE_FOLLOWUP_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0020_00_NEXT */

            R0020_00_NEXT();

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-1 */
        public void R0020_00_PROCESSA_DB_SELECT_1()
        {
            /*" -765- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, OPCAOOPAG, DTVENCTO INTO :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-PRMTOT, :V0PARC-OPCAOPAG, :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_1_Query1 = new R0020_00_PROCESSA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_1_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(executed_1.V0PARC_PRMTOT, V0PARC_PRMTOT);
                _.Move(executed_1.V0PARC_OPCAOPAG, V0PARC_OPCAOPAG);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R0020-00-NEXT */
        private void R0020_00_NEXT(bool isPerform = false)
        {
            /*" -972- PERFORM R0002-00-FETCH-CURSOR. */

            R0002_00_FETCH_CURSOR_SECTION();

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-2 */
        public void R0020_00_PROCESSA_DB_SELECT_2()
        {
            /*" -795- EXEC SQL SELECT NRTIT, OCORHIST, DTVENCTO, SITUACAO, VLPRMTOT, OPCAOPAG, DTVENCTO - 1 DAY INTO :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0HCOB-DTVENCTO, :V0HCOB-SITUACAO, :V0HCOB-VLPRMTOT, :V0HCOB-OPCAOPAG, :V0HCOB-DTALTOPC FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_2_Query1 = new R0020_00_PROCESSA_DB_SELECT_2_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_2_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
                _.Move(executed_1.V0HCOB_DTALTOPC, V0HCOB_DTALTOPC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-3 */
        public void R0020_00_PROCESSA_DB_SELECT_3()
        {
            /*" -817- EXEC SQL SELECT PERIPGTO, DIA_DEBITO, OPCAOPAG INTO :V0OPCP-PERIPGTO, :V0OPCP-DIADEB, :V0OPCP-OPCAOPAG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_3_Query1 = new R0020_00_PROCESSA_DB_SELECT_3_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_3_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_DIADEB, V0OPCP_DIADEB);
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
            }


        }

        [StopWatch]
        /*" R0023-00-ATUALIZA-ESTORNO-SECTION */
        private void R0023_00_ATUALIZA_ESTORNO_SECTION()
        {
            /*" -981- IF RF-COD-MOVIMENTO EQUAL 0 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 0)
            {

                /*" -982- MOVE '1' TO WHOST-TIPLANC. */
                _.Move("1", WHOST_TIPLANC);
            }


            /*" -983- IF RF-COD-MOVIMENTO EQUAL 1 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 1)
            {

                /*" -984- MOVE '4' TO WHOST-TIPLANC. */
                _.Move("4", WHOST_TIPLANC);
            }


            /*" -985- IF RF-COD-MOVIMENTO EQUAL 2 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 2)
            {

                /*" -986- MOVE '2' TO WHOST-TIPLANC. */
                _.Move("2", WHOST_TIPLANC);
            }


            /*" -987- IF RF-COD-MOVIMENTO EQUAL 3 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 3)
            {

                /*" -989- MOVE '5' TO WHOST-TIPLANC. */
                _.Move("5", WHOST_TIPLANC);
            }


            /*" -990- IF RF-COD-RETORNO EQUAL 97 OR 98 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98"))
            {

                /*" -991- MOVE '8' TO WHOST-SITUACAO */
                _.Move("8", WHOST_SITUACAO);

                /*" -992- ELSE */
            }
            else
            {


                /*" -994- MOVE '7' TO WHOST-SITUACAO. */
                _.Move("7", WHOST_SITUACAO);
            }


            /*" -996- MOVE 'UPDATE V0HISTCONTAVA 03' TO COMANDO */
            _.Move("UPDATE V0HISTCONTAVA 03", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -997- MOVE 08 TO SII */
            _.Move(08, WS_HORAS.SII);

            /*" -999- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1012- PERFORM R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1 */

            R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1();

            /*" -1016- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1017- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1018- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1030- PERFORM R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2 */

                    R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2();

                    /*" -1032- ELSE */
                }
                else
                {


                    /*" -1032- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0023-00-ATUALIZA-ESTORNO-DB-UPDATE-1 */
        public void R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1()
        {
            /*" -1012- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = :WHOST-SITUACAO, NSAC = :V0FTCF-NSAC, CODRET = :V0HCTA-CODRET, OCORHIST = :V0HCTA-OCORHISTCOB, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND OCORRHISTCTA >= 0 AND NSAC IS NULL AND TIPLANC IN ( '4' , '5' ) END-EXEC. */

            var r0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1 = new R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1()
            {
                V0HCTA_OCORHISTCOB = V0HCTA_OCORHISTCOB.ToString(),
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                V0HCTA_CODRET = V0HCTA_CODRET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1.Execute(r0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-4 */
        public void R0020_00_PROCESSA_DB_SELECT_4()
        {
            /*" -869- EXEC SQL SELECT A.CODCLIEN, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.QTDPARATZ, A.SITUACAO, A.NUM_MATRICULA, A.CODPRODU, A.NRPARCE, B.PERIPGTO, B.TEM_SAF, B.TEM_CDG, B.RISCO, B.OPCAOPAG, B.CUSTOCAP_TOTAL, VALUE(B.ORIG_PRODU, ' ' ) INTO :V0PROP-CODCLIEN, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0PROP-QTDPARATZ, :V0PROP-SITUACAO, :V0PROP-NRMATRFUN:V0PROP-INRMATRFUN, :V0PROP-CODPRODU, :V0PROP-NRPARCE, :V0PRVG-PERIPGTO, :V0PRVG-TEM-SAF:VIND-TEM-SAF, :V0PRVG-TEM-CDG:VIND-TEM-CDG, :V0PRVG-RISCO:VIND-RISCO, :V0PRVG-OPCAOPAG, :V0PRVG-CUSTOCAP-TOTAL, :V0PRVG-ORIG-PRODU FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCTA-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_4_Query1 = new R0020_00_PROCESSA_DB_SELECT_4_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_4_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(executed_1.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_FONTE, V0PROP_FONTE);
                _.Move(executed_1.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(executed_1.V0PROP_INRMATRFUN, V0PROP_INRMATRFUN);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_NRPARCE, V0PROP_NRPARCE);
                _.Move(executed_1.V0PRVG_PERIPGTO, V0PRVG_PERIPGTO);
                _.Move(executed_1.V0PRVG_TEM_SAF, V0PRVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.V0PRVG_TEM_CDG, V0PRVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.V0PRVG_RISCO, V0PRVG_RISCO);
                _.Move(executed_1.VIND_RISCO, VIND_RISCO);
                _.Move(executed_1.V0PRVG_OPCAOPAG, V0PRVG_OPCAOPAG);
                _.Move(executed_1.V0PRVG_CUSTOCAP_TOTAL, V0PRVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.V0PRVG_ORIG_PRODU, V0PRVG_ORIG_PRODU);
            }


        }

        [StopWatch]
        /*" R0023-00-ATUALIZA-ESTORNO-DB-UPDATE-2 */
        public void R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2()
        {
            /*" -1030- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = :WHOST-SITUACAO, NSAC = :V0FTCF-NSAC, CODRET = :V0HCTA-CODRET, OCORHIST = :V0HCTA-OCORHISTCOB, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND OCORRHISTCTA >= 0 AND NSAC IS NULL END-EXEC */

            var r0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1 = new R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1()
            {
                V0HCTA_OCORHISTCOB = V0HCTA_OCORHISTCOB.ToString(),
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                V0HCTA_CODRET = V0HCTA_CODRET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1.Execute(r0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0023_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-SECTION */
        private void R0030_00_ACESSO_CERTIF_SECTION()
        {
            /*" -1042- MOVE 'R0030-00-ACESSO-CERTIF' TO PARAGRAFO. */
            _.Move("R0030-00-ACESSO-CERTIF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1044- MOVE 'SELECT MIN V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT MIN V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1045- MOVE RF-IDENTIF-CLI TO V0HCTA-NRCERTIF. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, V0HCTA_NRCERTIF);

            /*" -1046- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -1047- MOVE RF-AGECTADEB TO V0HCTA-AGECTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_AGECTADEB, V0HCTA_AGECTADEB);

            /*" -1048- MOVE RF-COD-OPRCTADEB TO V0HCTA-OPRCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPRCTADEB, V0HCTA_OPRCTADEB);

            /*" -1050- MOVE RF-NUM-NUMCTADEB TO V0HCTA-NUMCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_NUMCTADEB, V0HCTA_NUMCTADEB);

            /*" -1051- IF RF-COD-MOVIMENTO EQUAL 0 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 0)
            {

                /*" -1052- MOVE '1' TO WHOST-TIPLANC. */
                _.Move("1", WHOST_TIPLANC);
            }


            /*" -1053- IF RF-COD-MOVIMENTO EQUAL 1 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 1)
            {

                /*" -1054- MOVE '4' TO WHOST-TIPLANC. */
                _.Move("4", WHOST_TIPLANC);
            }


            /*" -1055- IF RF-COD-MOVIMENTO EQUAL 2 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 2)
            {

                /*" -1056- MOVE '2' TO WHOST-TIPLANC. */
                _.Move("2", WHOST_TIPLANC);
            }


            /*" -1057- IF RF-COD-MOVIMENTO EQUAL 3 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 3)
            {

                /*" -1059- MOVE '5' TO WHOST-TIPLANC. */
                _.Move("5", WHOST_TIPLANC);
            }


            /*" -1060- MOVE 12 TO SII */
            _.Move(12, WS_HORAS.SII);

            /*" -1062- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1074- PERFORM R0030_00_ACESSO_CERTIF_DB_DECLARE_1 */

            R0030_00_ACESSO_CERTIF_DB_DECLARE_1();

            /*" -1076- PERFORM R0030_00_ACESSO_CERTIF_DB_OPEN_1 */

            R0030_00_ACESSO_CERTIF_DB_OPEN_1();

            /*" -1080- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1081- MOVE 13 TO SII */
            _.Move(13, WS_HORAS.SII);

            /*" -1083- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1089- PERFORM R0030_00_ACESSO_CERTIF_DB_FETCH_1 */

            R0030_00_ACESSO_CERTIF_DB_FETCH_1();

            /*" -1093- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1095- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1095- PERFORM R0030_00_ACESSO_CERTIF_DB_CLOSE_1 */

                R0030_00_ACESSO_CERTIF_DB_CLOSE_1();

                /*" -1097- MOVE 1 TO WS-NAO-ACHEI */
                _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                /*" -1099- GO TO R0030-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1099- PERFORM R0030_00_ACESSO_CERTIF_DB_CLOSE_2 */

            R0030_00_ACESSO_CERTIF_DB_CLOSE_2();

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-OPEN-1 */
        public void R0030_00_ACESSO_CERTIF_DB_OPEN_1()
        {
            /*" -1076- EXEC SQL OPEN CHCONTA2 END-EXEC. */

            CHCONTA2.Open();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-DECLARE-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1()
        {
            /*" -1171- EXEC SQL DECLARE CHCONTA3 CURSOR FOR SELECT NRCERTIF, NRPARCEL, OCORRHISTCTA, TIPLANC FROM SEGUROS.V0HISTCONTAVA WHERE AGECTADEB = :V0HCTA-AGECTADEB AND OPRCTADEB = :V0HCTA-OPRCTADEB AND NUMCTADEB = :V0HCTA-NUMCTADEB AND CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND VLPRMTOT = :V0HCTA-VLPRMTOT AND SITUACAO = '3' ORDER BY NRCERTIF, NRPARCEL, TIPLANC DESC END-EXEC. */
            CHCONTA3 = new VA1815B_CHCONTA3(true);
            string GetQuery_CHCONTA3()
            {
                var query = @$"SELECT NRCERTIF
							, 
							NRPARCEL
							, 
							OCORRHISTCTA
							, 
							TIPLANC 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE AGECTADEB = '{V0HCTA_AGECTADEB}' 
							AND OPRCTADEB = '{V0HCTA_OPRCTADEB}' 
							AND NUMCTADEB = '{V0HCTA_NUMCTADEB}' 
							AND CODCONV = '{WHOST_CODCONV}' 
							AND NSAS = '{V0HCTA_NSAS}' 
							AND VLPRMTOT = '{V0HCTA_VLPRMTOT}' 
							AND SITUACAO = '3' 
							ORDER BY NRCERTIF
							, NRPARCEL
							, TIPLANC DESC";

                return query;
            }
            CHCONTA3.GetQueryEvent += GetQuery_CHCONTA3;

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-FETCH-1 */
        public void R0030_00_ACESSO_CERTIF_DB_FETCH_1()
        {
            /*" -1089- EXEC SQL FETCH CHCONTA2 INTO :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA, :V0HCTA-NSAS, :V0HCTA-NSL, :V0HCTA-TIPLANC END-EXEC. */

            if (CHCONTA2.Fetch())
            {
                _.Move(CHCONTA2.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
                _.Move(CHCONTA2.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
                _.Move(CHCONTA2.V0HCTA_NSAS, V0HCTA_NSAS);
                _.Move(CHCONTA2.V0HCTA_NSL, V0HCTA_NSL);
                _.Move(CHCONTA2.V0HCTA_TIPLANC, V0HCTA_TIPLANC);
            }

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-CLOSE-1 */
        public void R0030_00_ACESSO_CERTIF_DB_CLOSE_1()
        {
            /*" -1095- EXEC SQL CLOSE CHCONTA2 END-EXEC */

            CHCONTA2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-CLOSE-2 */
        public void R0030_00_ACESSO_CERTIF_DB_CLOSE_2()
        {
            /*" -1099- EXEC SQL CLOSE CHCONTA2 END-EXEC. */

            CHCONTA2.Close();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-SECTION */
        private void R0035_00_ACESSO_NUMCTADEB_SECTION()
        {
            /*" -1108- MOVE 'R0035-00-ACESSO-NUMCTADEB' TO PARAGRAFO. */
            _.Move("R0035-00-ACESSO-NUMCTADEB", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1110- MOVE 'SELECT MIN V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT MIN V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1111- MOVE RF-AGECTADEB TO V0HCTA-AGECTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_AGECTADEB, V0HCTA_AGECTADEB);

            /*" -1112- MOVE RF-COD-OPRCTADEB TO V0HCTA-OPRCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPRCTADEB, V0HCTA_OPRCTADEB);

            /*" -1113- MOVE RF-NUM-NUMCTADEB TO V0HCTA-NUMCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_NUMCTADEB, V0HCTA_NUMCTADEB);

            /*" -1115- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -1120- MOVE RF-NSA TO V0HCTA-NSAS. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA, V0HCTA_NSAS);

            /*" -1121- IF RF-IDENTIF-NSA NOT NUMERIC */

            if (!RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA.IsNumeric())
            {

                /*" -1122- IF WS-CODCONV EQUAL 6081 */

                if (WORK_AREA.WS_CODCONV == 6081)
                {

                    /*" -1123- ADD 19000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 19000;

                    /*" -1125- END-IF */
                }


                /*" -1126- IF WS-CODCONV EQUAL 6088 */

                if (WORK_AREA.WS_CODCONV == 6088)
                {

                    /*" -1127- ADD 23000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 23000;

                    /*" -1129- END-IF */
                }


                /*" -1130- IF WS-CODCONV EQUAL 6132 */

                if (WORK_AREA.WS_CODCONV == 6132)
                {

                    /*" -1131- ADD 28000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 28000;

                    /*" -1133- END-IF */
                }


                /*" -1134- IF WS-CODCONV EQUAL 6153 */

                if (WORK_AREA.WS_CODCONV == 6153)
                {

                    /*" -1135- ADD 30000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 30000;

                    /*" -1136- END-IF */
                }


                /*" -1137- ELSE */
            }
            else
            {


                /*" -1139- MOVE RF-IDENTIF-NSA TO V0HCTA-NSAS. */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, V0HCTA_NSAS);
            }


            /*" -1141- MOVE RF-NSL TO V0HCTA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, V0HCTA_NSL);

            /*" -1142- IF RF-COD-MOVIMENTO EQUAL 0 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 0)
            {

                /*" -1143- MOVE '1' TO WHOST-TIPLANC. */
                _.Move("1", WHOST_TIPLANC);
            }


            /*" -1144- IF RF-COD-MOVIMENTO EQUAL 1 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 1)
            {

                /*" -1145- MOVE '4' TO WHOST-TIPLANC. */
                _.Move("4", WHOST_TIPLANC);
            }


            /*" -1146- IF RF-COD-MOVIMENTO EQUAL 2 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 2)
            {

                /*" -1147- MOVE '2' TO WHOST-TIPLANC. */
                _.Move("2", WHOST_TIPLANC);
            }


            /*" -1148- IF RF-COD-MOVIMENTO EQUAL 3 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 3)
            {

                /*" -1151- MOVE '5' TO WHOST-TIPLANC. */
                _.Move("5", WHOST_TIPLANC);
            }


            /*" -1152- MOVE 14 TO SII */
            _.Move(14, WS_HORAS.SII);

            /*" -1154- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1171- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1();

            /*" -1173- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1();

            /*" -1177- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1178- MOVE 15 TO SII */
            _.Move(15, WS_HORAS.SII);

            /*" -1180- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1185- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1();

            /*" -1189- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1191- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1191- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1 */

                R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1();

                /*" -1193- MOVE 1 TO WS-NAO-ACHEI */
                _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                /*" -1195- GO TO R0035-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1195- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2 */

            R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-OPEN-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1()
        {
            /*" -1173- EXEC SQL OPEN CHCONTA3 END-EXEC. */

            CHCONTA3.Open();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-FETCH-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1()
        {
            /*" -1185- EXEC SQL FETCH CHCONTA3 INTO :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA, :V0HCTA-TIPLANC END-EXEC. */

            if (CHCONTA3.Fetch())
            {
                _.Move(CHCONTA3.V0HCTA_NRCERTIF, V0HCTA_NRCERTIF);
                _.Move(CHCONTA3.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
                _.Move(CHCONTA3.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
                _.Move(CHCONTA3.V0HCTA_TIPLANC, V0HCTA_TIPLANC);
            }

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-CLOSE-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1()
        {
            /*" -1191- EXEC SQL CLOSE CHCONTA3 END-EXEC */

            CHCONTA3.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_99_SAIDA*/

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-CLOSE-2 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2()
        {
            /*" -1195- EXEC SQL CLOSE CHCONTA3 END-EXEC. */

            CHCONTA3.Close();

        }

        [StopWatch]
        /*" R0036-00-ACESSO-NSAS-SECTION */
        private void R0036_00_ACESSO_NSAS_SECTION()
        {
            /*" -1245- MOVE 'R0036-00-ACESSO-NSAS     ' TO PARAGRAFO. */
            _.Move("R0036-00-ACESSO-NSAS     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1247- MOVE 'SELECT V0HISTCONTAVA NSAS' TO COMANDO. */
            _.Move("SELECT V0HISTCONTAVA NSAS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1248- MOVE RF-IDENTIF-NSA TO V0HCTA-NSAS. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, V0HCTA_NSAS);

            /*" -1250- MOVE RF-NSL TO V0HCTA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, V0HCTA_NSL);

            /*" -1251- MOVE 14 TO SII */
            _.Move(14, WS_HORAS.SII);

            /*" -1253- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1266- PERFORM R0036_00_ACESSO_NSAS_DB_SELECT_1 */

            R0036_00_ACESSO_NSAS_DB_SELECT_1();

            /*" -1270- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1271- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1272- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1273- MOVE 1 TO WS-NAO-ACHEI */
                    _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                    /*" -1274- GO TO R0036-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0036_99_SAIDA*/ //GOTO
                    return;

                    /*" -1275- ELSE */
                }
                else
                {


                    /*" -1276- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -1277- MOVE 1 TO WS-NAO-ACHEI */
                        _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                        /*" -1278- GO TO R0036-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0036_99_SAIDA*/ //GOTO
                        return;

                        /*" -1279- ELSE */
                    }
                    else
                    {


                        /*" -1281- DISPLAY 'VA0813T - PROBLEMAS NO SELECT NSAS V0HISTCONT' V0HCTA-NSAS ' ' V0HCTA-NSL */

                        $"VA0813T - PROBLEMAS NO SELECT NSAS V0HISTCONT{V0HCTA_NSAS} {V0HCTA_NSL}"
                        .Display();

                        /*" -1282- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0036-00-ACESSO-NSAS-DB-SELECT-1 */
        public void R0036_00_ACESSO_NSAS_DB_SELECT_1()
        {
            /*" -1266- EXEC SQL SELECT NRCERTIF, NRPARCEL, OCORRHISTCTA, TIPLANC INTO :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA, :V0HCTA-TIPLANC FROM SEGUROS.V0HISTCONTAVA WHERE NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL AND TIPLANC = '1' END-EXEC. */

            var r0036_00_ACESSO_NSAS_DB_SELECT_1_Query1 = new R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1()
            {
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            var executed_1 = R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1.Execute(r0036_00_ACESSO_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NRCERTIF, V0HCTA_NRCERTIF);
                _.Move(executed_1.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
                _.Move(executed_1.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
                _.Move(executed_1.V0HCTA_TIPLANC, V0HCTA_TIPLANC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0036_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-GERA-FITACEF-SECTION */
        private void R0050_00_GERA_FITACEF_SECTION()
        {
            /*" -1291- MOVE '0050-GERA-FITACEF' TO PARAGRAFO. */
            _.Move("0050-GERA-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1293- MOVE 'SELECT V0FITACEF' TO COMANDO. */
            _.Move("SELECT V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1294- MOVE 16 TO SII */
            _.Move(16, WS_HORAS.SII);

            /*" -1296- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1301- PERFORM R0050_00_GERA_FITACEF_DB_SELECT_1 */

            R0050_00_GERA_FITACEF_DB_SELECT_1();

            /*" -1305- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1306- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1307- PERFORM R0053-00-UPDATE-FITACEF */

                R0053_00_UPDATE_FITACEF_SECTION();

                /*" -1308- ELSE */
            }
            else
            {


                /*" -1308- PERFORM R0055-00-INSERT-FITACEF. */

                R0055_00_INSERT_FITACEF_SECTION();
            }


        }

        [StopWatch]
        /*" R0050-00-GERA-FITACEF-DB-SELECT-1 */
        public void R0050_00_GERA_FITACEF_DB_SELECT_1()
        {
            /*" -1301- EXEC SQL SELECT DATA_GERACAO INTO :V0FTCF-DTRET FROM SEGUROS.V0FITACEF WHERE NSAC = :V0FTCF-NSAC END-EXEC. */

            var r0050_00_GERA_FITACEF_DB_SELECT_1_Query1 = new R0050_00_GERA_FITACEF_DB_SELECT_1_Query1()
            {
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
            };

            var executed_1 = R0050_00_GERA_FITACEF_DB_SELECT_1_Query1.Execute(r0050_00_GERA_FITACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FTCF_DTRET, V0FTCF_DTRET);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0053-00-UPDATE-FITACEF-SECTION */
        private void R0053_00_UPDATE_FITACEF_SECTION()
        {
            /*" -1318- MOVE 'R0053-00-UPDATE-FITACEF' TO PARAGRAFO. */
            _.Move("R0053-00-UPDATE-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1320- MOVE 'UPDATE V0FITACEF' TO COMANDO. */
            _.Move("UPDATE V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1321- MOVE WS-REGISTROS TO V0FTCF-QTLANCDB. */
            _.Move(WORK_AREA.WS_REGISTROS, V0FTCF_QTLANCDB);

            /*" -1322- MOVE WS-QTDBEFET TO V0FTCF-QTDBEFET. */
            _.Move(WORK_AREA.WS_QTDBEFET, V0FTCF_QTDBEFET);

            /*" -1323- MOVE WS-ACG-TOTDBEFET TO V0FTCF-TOTDBEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBEFET, V0FTCF_TOTDBEFET);

            /*" -1325- MOVE WS-ACG-TOTDBNEFET TO V0FTCF-TOTDBNEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBNEFET, V0FTCF_TOTDBNEFET);

            /*" -1326- MOVE 17 TO SII */
            _.Move(17, WS_HORAS.SII);

            /*" -1328- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1336- PERFORM R0053_00_UPDATE_FITACEF_DB_UPDATE_1 */

            R0053_00_UPDATE_FITACEF_DB_UPDATE_1();

            /*" -1338- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R0053-00-UPDATE-FITACEF-DB-UPDATE-1 */
        public void R0053_00_UPDATE_FITACEF_DB_UPDATE_1()
        {
            /*" -1336- EXEC SQL UPDATE SEGUROS.V0FITACEF SET DATA_GERACAO = :V0FTCF-DTRET2, QTDE_LANC_DEB_RET = :V0FTCF-QTLANCDB, TOT_DEB_EFET = :V0FTCF-TOTDBEFET, TOT_DEB_NAO_EFET = :V0FTCF-TOTDBNEFET, QTDE_DEB_EFET = :V0FTCF-QTDBEFET WHERE NSAC = :V0FTCF-NSAC END-EXEC. */

            var r0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1 = new R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1()
            {
                V0FTCF_TOTDBNEFET = V0FTCF_TOTDBNEFET.ToString(),
                V0FTCF_TOTDBEFET = V0FTCF_TOTDBEFET.ToString(),
                V0FTCF_QTLANCDB = V0FTCF_QTLANCDB.ToString(),
                V0FTCF_QTDBEFET = V0FTCF_QTDBEFET.ToString(),
                V0FTCF_DTRET2 = V0FTCF_DTRET2.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
            };

            R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1.Execute(r0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0053_99_SAIDA*/

        [StopWatch]
        /*" R0055-00-INSERT-FITACEF-SECTION */
        private void R0055_00_INSERT_FITACEF_SECTION()
        {
            /*" -1348- MOVE 'R0055-00-INSERT-FITACEF' TO PARAGRAFO. */
            _.Move("R0055-00-INSERT-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1350- MOVE 'INSERT V0FITACEF' TO COMANDO. */
            _.Move("INSERT V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1351- MOVE RZ-QTDE-REGISTROS TO V0FTCF-QTREG. */
            _.Move(RET_TRAILLER.RZ_QTDE_REGISTROS, V0FTCF_QTREG);

            /*" -1352- MOVE WS-REGISTROS TO V0FTCF-QTLANCDB. */
            _.Move(WORK_AREA.WS_REGISTROS, V0FTCF_QTLANCDB);

            /*" -1353- MOVE WS-QTDBEFET TO V0FTCF-QTDBEFET. */
            _.Move(WORK_AREA.WS_QTDBEFET, V0FTCF_QTDBEFET);

            /*" -1354- MOVE WS-ACG-TOTDBEFET TO V0FTCF-TOTDBEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBEFET, V0FTCF_TOTDBEFET);

            /*" -1356- MOVE WS-ACG-TOTDBNEFET TO V0FTCF-TOTDBNEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBNEFET, V0FTCF_TOTDBNEFET);

            /*" -1357- MOVE 18 TO SII */
            _.Move(18, WS_HORAS.SII);

            /*" -1359- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1373- PERFORM R0055_00_INSERT_FITACEF_DB_INSERT_1 */

            R0055_00_INSERT_FITACEF_DB_INSERT_1();

            /*" -1375- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R0055-00-INSERT-FITACEF-DB-INSERT-1 */
        public void R0055_00_INSERT_FITACEF_DB_INSERT_1()
        {
            /*" -1373- EXEC SQL INSERT INTO SEGUROS.V0FITACEF VALUES (:V0FTCF-NSAC, :V0FTCF-DTRET, :V0FTCF-VERSAO, :V0FTCF-QTREG, :V0FTCF-QTLANCDB, :V0FTCF-TOTDBEFET, :V0FTCF-TOTDBNEFET, 0, 0, 0, :V0FTCF-QTDBEFET, 0) END-EXEC. */

            var r0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1 = new R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1()
            {
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0FTCF_DTRET = V0FTCF_DTRET.ToString(),
                V0FTCF_VERSAO = V0FTCF_VERSAO.ToString(),
                V0FTCF_QTREG = V0FTCF_QTREG.ToString(),
                V0FTCF_QTLANCDB = V0FTCF_QTLANCDB.ToString(),
                V0FTCF_TOTDBEFET = V0FTCF_TOTDBEFET.ToString(),
                V0FTCF_TOTDBNEFET = V0FTCF_TOTDBNEFET.ToString(),
                V0FTCF_QTDBEFET = V0FTCF_QTDBEFET.ToString(),
            };

            R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1.Execute(r0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0055_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-SECTION */
        private void R1000_00_QUITA_PARCELA_SECTION()
        {
            /*" -1386- MOVE 'R1000-00-QUITA-PARCELA' TO PARAGRAFO. */
            _.Move("R1000-00-QUITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1387- ADD 1 TO WS-QTDBEFET. */
            WORK_AREA.WS_QTDBEFET.Value = WORK_AREA.WS_QTDBEFET + 1;

            /*" -1389- MOVE '1' TO V0HCTA-SITUACAO. */
            _.Move("1", V0HCTA_SITUACAO);

            /*" -1390- COMPUTE V0HCOB-OCORHIST = V0HCOB-OCORHIST + 1. */
            V0HCOB_OCORHIST.Value = V0HCOB_OCORHIST + 1;

            /*" -1392- MOVE V0HCOB-OCORHIST TO V0HCTA-OCORHISTCOB. */
            _.Move(V0HCOB_OCORHIST, V0HCTA_OCORHISTCOB);

            /*" -1396- MOVE V0OPCP-OPCAOPAG TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move(V0OPCP_OPCAOPAG, V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -1398- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1399- MOVE 21 TO SII */
            _.Move(21, WS_HORAS.SII);

            /*" -1401- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1424- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_1 */

            R1000_00_QUITA_PARCELA_DB_SELECT_1();

            /*" -1428- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1429- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1431- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1432- IF V0COBP-VLCUSTAUXF-I < ZEROS */

            if (V0COBP_VLCUSTAUXF_I < 00)
            {

                /*" -1433- MOVE ZEROS TO V0COBP-IMPSEGAUXF */
                _.Move(0, V0COBP_IMPSEGAUXF);

                /*" -1435- MOVE ZEROS TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -1437- MOVE 0 TO WS-DIFERENCA. */
            _.Move(0, WORK_AREA.WS_DIFERENCA);

            /*" -1438- IF V0HCOB-SITUACAO EQUAL '1' */

            if (V0HCOB_SITUACAO == "1")
            {

                /*" -1439- MOVE 204 TO V0HCTB-CODOPER */
                _.Move(204, V0HCTB_CODOPER);

                /*" -1440- MOVE 601 TO V0DIFP-CODOPER */
                _.Move(601, V0DIFP_CODOPER);

                /*" -1441- MOVE V0HCTA-VLPRMTOT TO WS-DIFERENCA */
                _.Move(V0HCTA_VLPRMTOT, WORK_AREA.WS_DIFERENCA);

                /*" -1443- MOVE 0 TO V0DIFP-PRMDEVVG V0DIFP-PRMDEVAP */
                _.Move(0, V0DIFP_PRMDEVVG, V0DIFP_PRMDEVAP);

                /*" -1451- ELSE */
            }
            else
            {


                /*" -1452- IF V0HCTA-VLPRMTOT EQUAL V0HCOB-VLPRMTOT */

                if (V0HCTA_VLPRMTOT == V0HCOB_VLPRMTOT)
                {

                    /*" -1453- MOVE 202 TO V0HCTB-CODOPER */
                    _.Move(202, V0HCTB_CODOPER);

                    /*" -1454- ELSE */
                }
                else
                {


                    /*" -1455- MOVE V0PARC-PRMVG TO V0DIFP-PRMDEVVG */
                    _.Move(V0PARC_PRMVG, V0DIFP_PRMDEVVG);

                    /*" -1456- MOVE V0PARC-PRMAP TO V0DIFP-PRMDEVAP */
                    _.Move(V0PARC_PRMAP, V0DIFP_PRMDEVAP);

                    /*" -1457- IF V0HCTA-VLPRMTOT LESS V0HCOB-VLPRMTOT */

                    if (V0HCTA_VLPRMTOT < V0HCOB_VLPRMTOT)
                    {

                        /*" -1458- MOVE 206 TO V0HCTB-CODOPER */
                        _.Move(206, V0HCTB_CODOPER);

                        /*" -1459- MOVE 401 TO V0DIFP-CODOPER */
                        _.Move(401, V0DIFP_CODOPER);

                        /*" -1461- COMPUTE WS-DIFERENCA = V0HCOB-VLPRMTOT - V0HCTA-VLPRMTOT */
                        WORK_AREA.WS_DIFERENCA.Value = V0HCOB_VLPRMTOT - V0HCTA_VLPRMTOT;

                        /*" -1462- ELSE */
                    }
                    else
                    {


                        /*" -1463- MOVE 207 TO V0HCTB-CODOPER */
                        _.Move(207, V0HCTB_CODOPER);

                        /*" -1464- MOVE 602 TO V0DIFP-CODOPER */
                        _.Move(602, V0DIFP_CODOPER);

                        /*" -1467- COMPUTE WS-DIFERENCA = V0HCTA-VLPRMTOT - V0HCOB-VLPRMTOT. */
                        WORK_AREA.WS_DIFERENCA.Value = V0HCTA_VLPRMTOT - V0HCOB_VLPRMTOT;
                    }

                }

            }


            /*" -1468- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1469- IF V0HCOB-VLPRMTOT GREATER 0 */

                if (V0HCOB_VLPRMTOT > 0)
                {

                    /*" -1470- COMPUTE WS-PC-VG = V0PARC-PRMVG / V0HCOB-VLPRMTOT */
                    WORK_AREA.WS_PC_VG.Value = V0PARC_PRMVG / V0HCOB_VLPRMTOT;

                    /*" -1471- COMPUTE V0DIFP-PRMPAGVG = V0HCTA-VLPRMTOT * WS-PC-VG */
                    V0DIFP_PRMPAGVG.Value = V0HCTA_VLPRMTOT * WORK_AREA.WS_PC_VG;

                    /*" -1473- COMPUTE V0DIFP-PRMPAGAP = V0HCTA-VLPRMTOT - V0DIFP-PRMPAGVG */
                    V0DIFP_PRMPAGAP.Value = V0HCTA_VLPRMTOT - V0DIFP_PRMPAGVG;

                    /*" -1474- MOVE V0DIFP-PRMPAGVG TO V0PARC-PRMVG */
                    _.Move(V0DIFP_PRMPAGVG, V0PARC_PRMVG);

                    /*" -1475- MOVE V0DIFP-PRMPAGAP TO V0PARC-PRMAP */
                    _.Move(V0DIFP_PRMPAGAP, V0PARC_PRMAP);

                    /*" -1476- COMPUTE V0DIFP-PRMDIFVG = WS-DIFERENCA * WS-PC-VG */
                    V0DIFP_PRMDIFVG.Value = WORK_AREA.WS_DIFERENCA * WORK_AREA.WS_PC_VG;

                    /*" -1478- COMPUTE V0DIFP-PRMDIFAP = WS-DIFERENCA - V0DIFP-PRMDIFVG */
                    V0DIFP_PRMDIFAP.Value = WORK_AREA.WS_DIFERENCA - V0DIFP_PRMDIFVG;

                    /*" -1479- ELSE */
                }
                else
                {


                    /*" -1482- MOVE V0HCTA-VLPRMTOT TO V0DIFP-PRMPAGVG V0DIFP-PRMDIFVG V0PARC-PRMVG */
                    _.Move(V0HCTA_VLPRMTOT, V0DIFP_PRMPAGVG, V0DIFP_PRMDIFVG, V0PARC_PRMVG);

                    /*" -1486- MOVE 0 TO V0DIFP-PRMPAGAP V0DIFP-PRMDIFAP V0PARC-PRMAP. */
                    _.Move(0, V0DIFP_PRMPAGAP, V0DIFP_PRMDIFAP, V0PARC_PRMAP);
                }

            }


            /*" -1487- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1488- IF V0PARC-PRMAP LESS ZEROS */

                if (V0PARC_PRMAP < 00)
                {

                    /*" -1489- COMPUTE V0PARC-PRMTOTVG = V0PARC-PRMVG + V0PARC-PRMAP */
                    V0PARC_PRMTOTVG.Value = V0PARC_PRMVG + V0PARC_PRMAP;

                    /*" -1491- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -1492- ELSE */
                    }
                    else
                    {


                        /*" -1493- MOVE V0PARC-PRMTOTVG TO V0PARC-PRMVG */
                        _.Move(V0PARC_PRMTOTVG, V0PARC_PRMVG);

                        /*" -1495- MOVE ZEROS TO V0PARC-PRMAP. */
                        _.Move(0, V0PARC_PRMAP);
                    }

                }

            }


            /*" -1496- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1497- IF V0DIFP-PRMPAGAP LESS ZEROS */

                if (V0DIFP_PRMPAGAP < 00)
                {

                    /*" -1499- COMPUTE V0PARC-PRMTOTVG = V0DIFP-PRMPAGVG + V0DIFP-PRMPAGAP */
                    V0PARC_PRMTOTVG.Value = V0DIFP_PRMPAGVG + V0DIFP_PRMPAGAP;

                    /*" -1501- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -1502- ELSE */
                    }
                    else
                    {


                        /*" -1503- MOVE V0PARC-PRMTOTVG TO V0DIFP-PRMPAGVG */
                        _.Move(V0PARC_PRMTOTVG, V0DIFP_PRMPAGVG);

                        /*" -1505- MOVE ZEROS TO V0DIFP-PRMPAGAP. */
                        _.Move(0, V0DIFP_PRMPAGAP);
                    }

                }

            }


            /*" -1506- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1507- IF V0DIFP-PRMDIFAP LESS ZEROS */

                if (V0DIFP_PRMDIFAP < 00)
                {

                    /*" -1509- COMPUTE V0PARC-PRMTOTVG = V0DIFP-PRMDIFVG + V0DIFP-PRMDIFAP */
                    V0PARC_PRMTOTVG.Value = V0DIFP_PRMDIFVG + V0DIFP_PRMDIFAP;

                    /*" -1511- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -1512- ELSE */
                    }
                    else
                    {


                        /*" -1513- MOVE V0PARC-PRMTOTVG TO V0DIFP-PRMDIFVG */
                        _.Move(V0PARC_PRMTOTVG, V0DIFP_PRMDIFVG);

                        /*" -1520- MOVE ZEROS TO V0DIFP-PRMDIFAP. */
                        _.Move(0, V0DIFP_PRMDIFAP);
                    }

                }

            }


            /*" -1521- IF V0PRVG-TEM-SAF = 'N' */

            if (V0PRVG_TEM_SAF == "N")
            {

                /*" -1523- MOVE ZEROS TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -1524- IF V0PRVG-TEM-CDG = 'N' */

            if (V0PRVG_TEM_CDG == "N")
            {

                /*" -1526- MOVE ZEROS TO V0COBP-VLCUSTCDG. */
                _.Move(0, V0COBP_VLCUSTCDG);
            }


            /*" -1527- IF V0PRVG-CUSTOCAP-TOTAL = 'N' */

            if (V0PRVG_CUSTOCAP_TOTAL == "N")
            {

                /*" -1530- COMPUTE V0COBP-VLCUSTCAP = V0COBP-VLCUSTCAP * V0COBP-QTTITCAP. */
                V0COBP_VLCUSTCAP.Value = V0COBP_VLCUSTCAP * V0COBP_QTTITCAP;
            }


            /*" -1540- COMPUTE V0HCTVA-VLCOBADIC = V0COBP-VLCUSTCDG + V0COBP-VLCUSTAUXF + V0COBP-VLCUSTCAP. */
            V0HCTVA_VLCOBADIC.Value = V0COBP_VLCUSTCDG + V0COBP_VLCUSTAUXF + V0COBP_VLCUSTCAP;

            /*" -1541- IF V0SIST-DTMOVABE NOT GREATER '2001-09-30' */

            if (V0SIST_DTMOVABE <= "2001-09-30")
            {

                /*" -1543- COMPUTE V0HCTVA-PRMVG = V0PARC-PRMVG - V0HCTVA-VLCOBADIC */
                V0HCTVA_PRMVG.Value = V0PARC_PRMVG - V0HCTVA_VLCOBADIC;

                /*" -1544- ELSE */
            }
            else
            {


                /*" -1546- MOVE V0PARC-PRMVG TO V0HCTVA-PRMVG. */
                _.Move(V0PARC_PRMVG, V0HCTVA_PRMVG);
            }


            /*" -1547- IF V0COBP-PRMVG > ZEROS */

            if (V0COBP_PRMVG > 00)
            {

                /*" -1548- COMPUTE WS-PCT-COB-VG = V0COBP-PRMVG / V0COBP-VLPREMIO */
                WORK_AREA.WS_PCT_COB_VG.Value = V0COBP_PRMVG / V0COBP_VLPREMIO;

                /*" -1550- COMPUTE V0HCTVA-PRMVG ROUNDED = V0HCTA-VLPRMTOT * WS-PCT-COB-VG */
                V0HCTVA_PRMVG.Value = V0HCTA_VLPRMTOT * WORK_AREA.WS_PCT_COB_VG;

                /*" -1551- COMPUTE V0HCTVA-PRMAP = V0HCTA-VLPRMTOT - V0HCTVA-PRMVG */
                V0HCTVA_PRMAP.Value = V0HCTA_VLPRMTOT - V0HCTVA_PRMVG;

                /*" -1552- ELSE */
            }
            else
            {


                /*" -1553- MOVE ZEROS TO V0HCTVA-PRMVG */
                _.Move(0, V0HCTVA_PRMVG);

                /*" -1560- MOVE V0HCTA-VLPRMTOT TO V0HCTVA-PRMAP. */
                _.Move(V0HCTA_VLPRMTOT, V0HCTVA_PRMAP);
            }


            /*" -1562- MOVE 'INSERT V0HISTCONTABILVA' TO COMANDO. */
            _.Move("INSERT V0HISTCONTABILVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1563- MOVE 23 TO SII */
            _.Move(23, WS_HORAS.SII);

            /*" -1565- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1582- PERFORM R1000_00_QUITA_PARCELA_DB_INSERT_1 */

            R1000_00_QUITA_PARCELA_DB_INSERT_1();

            /*" -1586- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1587- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1589- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1590- IF (V0HCOB-SITUACAO NOT EQUAL ' ' AND '0' AND '5' ) */

            if ((!V0HCOB_SITUACAO.In(" ", "0", "5")))
            {

                /*" -1591- MOVE 'UPDATE V0HISTCOBVA 1' TO COMANDO */
                _.Move("UPDATE V0HISTCOBVA 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1592- MOVE 24 TO SII */
                _.Move(24, WS_HORAS.SII);

                /*" -1593- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1600- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_1 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_1();

                /*" -1602- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1603- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1604- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1605- END-IF */
                }


                /*" -1606- ELSE */
            }
            else
            {


                /*" -1607- MOVE 'UPDATE V0HISTCOBVA 2' TO COMANDO */
                _.Move("UPDATE V0HISTCOBVA 2", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1608- MOVE 25 TO SII */
                _.Move(25, WS_HORAS.SII);

                /*" -1609- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1618- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_2 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_2();

                /*" -1620- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1621- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1622- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1623- END-IF */
                }


                /*" -1624- MOVE 'UPDATE V0DIFPARCELVA' TO COMANDO */
                _.Move("UPDATE V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1625- MOVE 26 TO SII */
                _.Move(26, WS_HORAS.SII);

                /*" -1626- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1631- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_3 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_3();

                /*" -1633- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1634- IF SQLCODE NOT EQUAL ZEROES AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1635- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1636- END-IF */
                }


                /*" -1637- IF V0PROP-QTDPARATZ GREATER 0 */

                if (V0PROP_QTDPARATZ > 0)
                {

                    /*" -1638- SUBTRACT 1 FROM V0PROP-QTDPARATZ */
                    V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ - 1;

                    /*" -1639- MOVE 'UPDATE V0PROPOSTAVA 1' TO COMANDO */
                    _.Move("UPDATE V0PROPOSTAVA 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1640- MOVE 27 TO SII */
                    _.Move(27, WS_HORAS.SII);

                    /*" -1641- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -1645- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_4 */

                    R1000_00_QUITA_PARCELA_DB_UPDATE_4();

                    /*" -1647- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -1648- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1650- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -1651- IF V0PROP-SITUACAO EQUAL '8' */

            if (V0PROP_SITUACAO == "8")
            {

                /*" -1652- MOVE 'UPDATE V0PROPOSTAVA 2' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA 2", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1653- MOVE 28 TO SII */
                _.Move(28, WS_HORAS.SII);

                /*" -1654- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1659- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_5 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_5();

                /*" -1661- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1662- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1664- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1666- IF V0PROP-SITUACAO EQUAL '6' AND V0PROP-NRPARCE EQUAL V0HCTA-NRPARCEL */

            if (V0PROP_SITUACAO == "6" && V0PROP_NRPARCE == V0HCTA_NRPARCEL)
            {

                /*" -1667- MOVE 'UPDATE V0PROPOSTAVA 3' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1668- MOVE 29 TO SII */
                _.Move(29, WS_HORAS.SII);

                /*" -1669- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1675- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_6 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_6();

                /*" -1677- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1678- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1680- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1681- MOVE 'SELECT V0CDGCOBER' TO COMANDO. */
            _.Move("SELECT V0CDGCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1682- MOVE 'UPDATE V0PROPOSTAVA 3' TO COMANDO */
            _.Move("UPDATE V0PROPOSTAVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1683- MOVE 30 TO SII */
            _.Move(30, WS_HORAS.SII);

            /*" -1685- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1691- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_2 */

            R1000_00_QUITA_PARCELA_DB_SELECT_2();

            /*" -1694- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1695- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1696- IF V0PRVG-TEM-CDG = 'S' */

                if (V0PRVG_TEM_CDG == "S")
                {

                    /*" -1697- PERFORM R1100-00-REPASSA-CDG */

                    R1100_00_REPASSA_CDG_SECTION();

                    /*" -1699- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1700- ELSE */
                }

            }
            else
            {


                /*" -1704- IF SQLCODE EQUAL 100 AND V0PRVG-TEM-CDG = 'S' AND V0COBP-VLCUSTCDG > ZEROS AND V0PROP-SITUACAO = '3' OR '6' */

                if (DB.SQLCODE == 100 && V0PRVG_TEM_CDG == "S" && V0COBP_VLCUSTCDG > 00 && V0PROP_SITUACAO.In("3", "6"))
                {

                    /*" -1706- PERFORM R1099-00-INCLUI-CDG. */

                    R1099_00_INCLUI_CDG_SECTION();
                }

            }


            /*" -1707- MOVE 'SELECT V0SAFCOBER' TO COMANDO. */
            _.Move("SELECT V0SAFCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1708- MOVE 31 TO SII */
            _.Move(31, WS_HORAS.SII);

            /*" -1710- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1716- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_3 */

            R1000_00_QUITA_PARCELA_DB_SELECT_3();

            /*" -1719- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1720- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1721- IF V0PRVG-TEM-SAF = 'S' */

                if (V0PRVG_TEM_SAF == "S")
                {

                    /*" -1722- PERFORM R1200-00-REPASSA-SAF */

                    R1200_00_REPASSA_SAF_SECTION();

                    /*" -1724- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1725- ELSE */
                }

            }
            else
            {


                /*" -1729- IF SQLCODE EQUAL 100 AND V0PRVG-TEM-SAF = 'S' AND V0COBP-VLCUSTAUXF > ZEROS AND V0PROP-SITUACAO = '3' OR '6' */

                if (DB.SQLCODE == 100 && V0PRVG_TEM_SAF == "S" && V0COBP_VLCUSTAUXF > 00 && V0PROP_SITUACAO.In("3", "6"))
                {

                    /*" -1731- PERFORM R1199-00-INCLUI-SAF. */

                    R1199_00_INCLUI_SAF_SECTION();
                }

            }


            /*" -1732- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1734- PERFORM R1050-00-GRAVA-DIFERENCA. */

                R1050_00_GRAVA_DIFERENCA_SECTION();
            }


            /*" -1736- MOVE 'R1000-00-QUITA-PARCELA' TO PARAGRAFO. */
            _.Move("R1000-00-QUITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1737- MOVE 'UPDATE V0FITASASSE 1' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1738- MOVE 32 TO SII */
            _.Move(32, WS_HORAS.SII);

            /*" -1740- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1747- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_7 */

            R1000_00_QUITA_PARCELA_DB_UPDATE_7();

            /*" -1750- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1751- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1752- DISPLAY V0HCTA-NRCERTIF ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"{V0HCTA_NRCERTIF} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -1754- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1757- ADD V0HCTA-VLPRMTOT TO WS-ACG-TOTDBEFET. */
            WORK_AREA.WS_ACG_TOTDBEFET.Value = WORK_AREA.WS_ACG_TOTDBEFET + V0HCTA_VLPRMTOT;

            /*" -1759- COMPUTE V0CAPI-NRPARCEL = V0HCTA-NRPARCEL - 1. */
            V0CAPI_NRPARCEL.Value = V0HCTA_NRPARCEL - 1;

            /*" -1760- MOVE 'UPDATE V0PARCELCAPVG' TO COMANDO. */
            _.Move("UPDATE V0PARCELCAPVG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1761- MOVE 33 TO SII */
            _.Move(33, WS_HORAS.SII);

            /*" -1763- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1770- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_8 */

            R1000_00_QUITA_PARCELA_DB_UPDATE_8();

            /*" -1773- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1774- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1776- IF SQLCODE = 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1777- ELSE */
                }
                else
                {


                    /*" -1779- DISPLAY '*** VA1815B - ERRO UPDATE V0PARCELCAPVG ' V0HCTA-NRCERTIF ' ' V0CAPI-NRPARCEL ' ' SQLCODE */

                    $"*** VA1815B - ERRO UPDATE V0PARCELCAPVG {V0HCTA_NRCERTIF} {V0CAPI_NRPARCEL} {DB.SQLCODE}"
                    .Display();

                    /*" -1779- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-1 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_1()
        {
            /*" -1424- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, VLCUSTCDG, VLCUSTAUXF, IMPSEGCDC, IMPSEGAUXF, VLCUSTCAP, QTTITCAP INTO :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-VLPREMIO, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I, :V0COBP-IMPSEGCDG, :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I, :V0COBP-VLCUSTCAP, :V0COBP-QTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO AND DTTERVIG >= :V0PARC-DTVENCTO END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_1_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-INSERT-1 */
        public void R1000_00_QUITA_PARCELA_DB_INSERT_1()
        {
            /*" -1582- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES (:V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, 0, :V0HCTVA-PRMVG, :V0HCTVA-PRMAP, :V0HCOB-DTVENCTO, '0' , :V0HCTB-CODOPER, CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1 = new R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0HCTVA_PRMVG = V0HCTVA_PRMVG.ToString(),
                V0HCTVA_PRMAP = V0HCTVA_PRMAP.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0HCTB_CODOPER = V0HCTB_CODOPER.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1.Execute(r1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-1 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_1()
        {
            /*" -1600- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET OCORHIST = :V0HCOB-OCORHIST, OPCAOPAG = :V0HCOB-OPCAOPAG WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCOB_OPCAOPAG = V0HCOB_OPCAOPAG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-2 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_2()
        {
            /*" -1618- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = :V0HCTA-SITUACAO, VLPRMTOT = :V0HCTA-VLPRMTOT, OCORHIST = :V0HCOB-OCORHIST, OPCAOPAG = :V0HCOB-OPCAOPAG WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCOB_OPCAOPAG = V0HCOB_OPCAOPAG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1050-00-GRAVA-DIFERENCA-SECTION */
        private void R1050_00_GRAVA_DIFERENCA_SECTION()
        {
            /*" -1795- MOVE 'R1050-00-GRAVA-DIFERENCA' TO PARAGRAFO. */
            _.Move("R1050-00-GRAVA-DIFERENCA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1795- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1797- MOVE V0HCTA-NRPARCEL TO V0DIFP-NRPARCEL. */
            _.Move(V0HCTA_NRPARCEL, V0DIFP_NRPARCEL);

            /*" -0- FLUXCONTROL_PERFORM R1050_00_LOOP */

            R1050_00_LOOP();

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-3 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_3()
        {
            /*" -1631- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R1050-00-LOOP */
        private void R1050_00_LOOP(bool isPerform = false)
        {
            /*" -1803- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1804- MOVE 34 TO SII */
            _.Move(34, WS_HORAS.SII);

            /*" -1805- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1820- PERFORM R1050_00_LOOP_DB_INSERT_1 */

            R1050_00_LOOP_DB_INSERT_1();

            /*" -1823- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1824- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1825- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1826- ADD 1 TO V0DIFP-NRPARCEL */
                    V0DIFP_NRPARCEL.Value = V0DIFP_NRPARCEL + 1;

                    /*" -1827- MOVE 'SELECT V0PARCELVA' TO COMANDO */
                    _.Move("SELECT V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1828- MOVE 35 TO SII */
                    _.Move(35, WS_HORAS.SII);

                    /*" -1829- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -1835- PERFORM R1050_00_LOOP_DB_SELECT_1 */

                    R1050_00_LOOP_DB_SELECT_1();

                    /*" -1837- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -1838- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1839- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1840- END-IF */
                    }


                    /*" -1841- GO TO R1050-00-LOOP */
                    new Task(() => R1050_00_LOOP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1842- ELSE */
                }
                else
                {


                    /*" -1844- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1844- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

        }

        [StopWatch]
        /*" R1050-00-LOOP-DB-INSERT-1 */
        public void R1050_00_LOOP_DB_INSERT_1()
        {
            /*" -1820- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HCTA-NRCERTIF, 9999, :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0PARC-DTVENCTO, :V0DIFP-PRMDEVVG, :V0DIFP-PRMDEVAP, :V0DIFP-PRMPAGVG, :V0DIFP-PRMPAGAP, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, 0, ' ' ) END-EXEC. */

            var r1050_00_LOOP_DB_INSERT_1_Insert1 = new R1050_00_LOOP_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0DIFP_PRMDEVVG = V0DIFP_PRMDEVVG.ToString(),
                V0DIFP_PRMDEVAP = V0DIFP_PRMDEVAP.ToString(),
                V0DIFP_PRMPAGVG = V0DIFP_PRMPAGVG.ToString(),
                V0DIFP_PRMPAGAP = V0DIFP_PRMPAGAP.ToString(),
                V0DIFP_PRMDIFVG = V0DIFP_PRMDIFVG.ToString(),
                V0DIFP_PRMDIFAP = V0DIFP_PRMDIFAP.ToString(),
            };

            R1050_00_LOOP_DB_INSERT_1_Insert1.Execute(r1050_00_LOOP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1050-00-LOOP-DB-SELECT-1 */
        public void R1050_00_LOOP_DB_SELECT_1()
        {
            /*" -1835- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0DIFP-NRPARCEL END-EXEC */

            var r1050_00_LOOP_DB_SELECT_1_Query1 = new R1050_00_LOOP_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
            };

            var executed_1 = R1050_00_LOOP_DB_SELECT_1_Query1.Execute(r1050_00_LOOP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-4 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_4()
        {
            /*" -1645- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET QTDPARATZ = :V0PROP-QTDPARATZ WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1()
            {
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-2 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_2()
        {
            /*" -1691- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_2_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-3 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_3()
        {
            /*" -1716- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_3_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_3_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_3_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-5 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_5()
        {
            /*" -1659- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '0' , DTQITBCO = :V0PARC-DTVENCTO WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1()
            {
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1);

        }

        [StopWatch]
        /*" R1099-00-INCLUI-CDG-SECTION */
        private void R1099_00_INCLUI_CDG_SECTION()
        {
            /*" -1855- MOVE 'R1099-00-INCLUI-CDG' TO PARAGRAFO. */
            _.Move("R1099-00-INCLUI-CDG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1857- IF V0COBP-VLCUSTCDG > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTCDG > 00)
            {

                /*" -1858- ELSE */
            }
            else
            {


                /*" -1862- GO TO R1099-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1099_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1863- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -1865- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1866- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -1867- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -1868- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -1869- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -1871- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -1873- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RCDG_DTREFER);

            /*" -1875- MOVE 'INSERT V0CDGCOBER  ' TO COMANDO. */
            _.Move("INSERT V0CDGCOBER  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1876- MOVE 36 TO SII */
            _.Move(36, WS_HORAS.SII);

            /*" -1878- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1890- PERFORM R1099_00_INCLUI_CDG_DB_INSERT_1 */

            R1099_00_INCLUI_CDG_DB_INSERT_1();

            /*" -1893- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1894- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1896- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1898- MOVE V0COBP-VLCUSTCDG TO V0CDGC-VLCUSTCDG. */
            _.Move(V0COBP_VLCUSTCDG, V0CDGC_VLCUSTCDG);

            /*" -1898- PERFORM R1100-00-REPASSA-CDG. */

            R1100_00_REPASSA_CDG_SECTION();

        }

        [StopWatch]
        /*" R1099-00-INCLUI-CDG-DB-INSERT-1 */
        public void R1099_00_INCLUI_CDG_DB_INSERT_1()
        {
            /*" -1890- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, '9999-12-31' , :V0COBP-IMPSEGCDG, :V0COBP-VLCUSTCDG, :V0HCTA-NRCERTIF, 0, '0' , 'VA1815B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1099_00_INCLUI_CDG_DB_INSERT_1_Insert1 = new R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0COBP_IMPSEGCDG = V0COBP_IMPSEGCDG.ToString(),
                V0COBP_VLCUSTCDG = V0COBP_VLCUSTCDG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1.Execute(r1099_00_INCLUI_CDG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-6 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_6()
        {
            /*" -1675- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '3' , NRPRIPARATZ = 0 , QTDPARATZ = 0 WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1099_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-7 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_7()
        {
            /*" -1747- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET TOT_DEB_EFET = TOT_DEB_EFET + :V0HCTA-VLPRMTOT, QTDE_LANC_DEB_RET = QTDE_LANC_DEB_RET + 1 WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1()
            {
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1);

        }

        [StopWatch]
        /*" R1100-00-REPASSA-CDG-SECTION */
        private void R1100_00_REPASSA_CDG_SECTION()
        {
            /*" -1909- MOVE 'R1100-00-REPASSA-CDG' TO PARAGRAFO. */
            _.Move("R1100-00-REPASSA-CDG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1911- IF V0COBP-VLCUSTCDG > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTCDG > 00)
            {

                /*" -1912- ELSE */
            }
            else
            {


                /*" -1916- GO TO R1100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1917- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -1919- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1920- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -1921- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -1922- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -1923- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -1925- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -1927- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RCDG_DTREFER);

            /*" -1929- MOVE 'SELECT V0REPASSECDG' TO COMANDO. */
            _.Move("SELECT V0REPASSECDG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1930- MOVE 37 TO SII */
            _.Move(37, WS_HORAS.SII);

            /*" -1932- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1938- PERFORM R1100_00_REPASSA_CDG_DB_SELECT_1 */

            R1100_00_REPASSA_CDG_DB_SELECT_1();

            /*" -1941- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1942- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1944- GO TO R1100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1946- MOVE 'INSERT V0REPASSECDG' TO COMANDO. */
            _.Move("INSERT V0REPASSECDG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1947- MOVE 38 TO SII */
            _.Move(38, WS_HORAS.SII);

            /*" -1949- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1959- PERFORM R1100_00_REPASSA_CDG_DB_INSERT_1 */

            R1100_00_REPASSA_CDG_DB_INSERT_1();

            /*" -1962- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1963- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1963- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-REPASSA-CDG-DB-SELECT-1 */
        public void R1100_00_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -1938- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER END-EXEC. */

            var r1100_00_REPASSA_CDG_DB_SELECT_1_Query1 = new R1100_00_REPASSA_CDG_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = R1100_00_REPASSA_CDG_DB_SELECT_1_Query1.Execute(r1100_00_REPASSA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1100-00-REPASSA-CDG-DB-INSERT-1 */
        public void R1100_00_REPASSA_CDG_DB_INSERT_1()
        {
            /*" -1959- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, '0' , :V0SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r1100_00_REPASSA_CDG_DB_INSERT_1_Insert1 = new R1100_00_REPASSA_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            R1100_00_REPASSA_CDG_DB_INSERT_1_Insert1.Execute(r1100_00_REPASSA_CDG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-8 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_8()
        {
            /*" -1770- EXEC SQL UPDATE SEGUROS.V0PARCELCAPVG SET SITPARCEL = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0CAPI-NRPARCEL AND SITPARCEL = '3' END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0CAPI_NRPARCEL = V0CAPI_NRPARCEL.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-SECTION */
        private void R1199_00_INCLUI_SAF_SECTION()
        {
            /*" -1974- MOVE 'R1199-00-INCLUI-SAF' TO PARAGRAFO. */
            _.Move("R1199-00-INCLUI-SAF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1976- IF V0COBP-VLCUSTAUXF > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTAUXF > 00)
            {

                /*" -1977- ELSE */
            }
            else
            {


                /*" -1981- GO TO R1199-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1199_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1982- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -1984- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1985- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -1986- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -1987- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -1988- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -1990- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -1992- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RSAF_DTREFER);

            /*" -1994- MOVE 'INSERT V0SAFCOBER' TO COMANDO. */
            _.Move("INSERT V0SAFCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1995- MOVE 39 TO SII */
            _.Move(39, WS_HORAS.SII);

            /*" -1997- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2009- PERFORM R1199_00_INCLUI_SAF_DB_INSERT_1 */

            R1199_00_INCLUI_SAF_DB_INSERT_1();

            /*" -2012- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2013- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2015- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2017- MOVE V0COBP-VLCUSTAUXF TO V0SAFC-VLCUSTSAF. */
            _.Move(V0COBP_VLCUSTAUXF, V0SAFC_VLCUSTSAF);

            /*" -2019- MOVE 'SELECT V0HISTREPSAF - 102' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF - 102", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2020- MOVE 40 TO SII */
            _.Move(40, WS_HORAS.SII);

            /*" -2022- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2029- PERFORM R1199_00_INCLUI_SAF_DB_SELECT_1 */

            R1199_00_INCLUI_SAF_DB_SELECT_1();

            /*" -2032- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2033- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -2035- GO TO R1199-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1199_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2037- MOVE 'INSERT V0HISTREPSAF - 102' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF - 102", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2038- MOVE 41 TO SII */
            _.Move(41, WS_HORAS.SII);

            /*" -2040- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2056- PERFORM R1199_00_INCLUI_SAF_DB_INSERT_2 */

            R1199_00_INCLUI_SAF_DB_INSERT_2();

            /*" -2059- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2060- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2062- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2062- PERFORM R1200-00-REPASSA-SAF. */

            R1200_00_REPASSA_SAF_SECTION();

        }

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-DB-INSERT-1 */
        public void R1199_00_INCLUI_SAF_DB_INSERT_1()
        {
            /*" -2009- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, '9999-12-31' , :V0COBP-IMPSEGAUXF, :V0COBP-VLCUSTAUXF, :V0HCTA-NRCERTIF, 0, '0' , 'VA1815B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1199_00_INCLUI_SAF_DB_INSERT_1_Insert1 = new R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0COBP_IMPSEGAUXF = V0COBP_IMPSEGAUXF.ToString(),
                V0COBP_VLCUSTAUXF = V0COBP_VLCUSTAUXF.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1.Execute(r1199_00_INCLUI_SAF_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-DB-SELECT-1 */
        public void R1199_00_INCLUI_SAF_DB_SELECT_1()
        {
            /*" -2029- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 102 END-EXEC. */

            var r1199_00_INCLUI_SAF_DB_SELECT_1_Query1 = new R1199_00_INCLUI_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1199_00_INCLUI_SAF_DB_SELECT_1_Query1.Execute(r1199_00_INCLUI_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1199_99_SAIDA*/

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-DB-INSERT-2 */
        public void R1199_00_INCLUI_SAF_DB_INSERT_2()
        {
            /*" -2056- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, 102, '0' , '0' , 0, 0, 'VA1815B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1199_00_INCLUI_SAF_DB_INSERT_2_Insert1 = new R1199_00_INCLUI_SAF_DB_INSERT_2_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1199_00_INCLUI_SAF_DB_INSERT_2_Insert1.Execute(r1199_00_INCLUI_SAF_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1200-00-REPASSA-SAF-SECTION */
        private void R1200_00_REPASSA_SAF_SECTION()
        {
            /*" -2073- MOVE 'R1200-00-REPASSA-SAF' TO PARAGRAFO. */
            _.Move("R1200-00-REPASSA-SAF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2075- IF V0COBP-VLCUSTAUXF > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTAUXF > 00)
            {

                /*" -2076- ELSE */
            }
            else
            {


                /*" -2080- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2081- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -2083- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -2084- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -2085- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -2086- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -2087- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -2089- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -2091- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RSAF_DTREFER);

            /*" -2093- MOVE 'SELECT V0HISTREPSAF' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2094- MOVE 42 TO SII */
            _.Move(42, WS_HORAS.SII);

            /*" -2096- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2103- PERFORM R1200_00_REPASSA_SAF_DB_SELECT_1 */

            R1200_00_REPASSA_SAF_DB_SELECT_1();

            /*" -2106- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2107- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -2109- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2111- MOVE 'INSERT V0HISTREPSAF' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2112- MOVE 43 TO SII */
            _.Move(43, WS_HORAS.SII);

            /*" -2114- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2130- PERFORM R1200_00_REPASSA_SAF_DB_INSERT_1 */

            R1200_00_REPASSA_SAF_DB_INSERT_1();

            /*" -2133- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2134- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2134- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1200_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -2103- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 1100 END-EXEC. */

            var r1200_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R1200_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1200_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r1200_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1200-00-REPASSA-SAF-DB-INSERT-1 */
        public void R1200_00_REPASSA_SAF_DB_INSERT_1()
        {
            /*" -2130- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, 1100, '0' , '0' , 0, 0, 'VA1815B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1200_00_REPASSA_SAF_DB_INSERT_1_Insert1 = new R1200_00_REPASSA_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1200_00_REPASSA_SAF_DB_INSERT_1_Insert1.Execute(r1200_00_REPASSA_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-SECTION */
        private void R2000_00_REJEITA_PARCELA_SECTION()
        {
            /*" -2145- MOVE 'R2000-00-REJEITA-PARCELA' TO PARAGRAFO. */
            _.Move("R2000-00-REJEITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2148- IF RF-COD-RETORNO EQUAL 99 AND V0HCTA-TIPLANC EQUAL '1' NEXT SENTENCE */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 99 && V0HCTA_TIPLANC == "1")
            {

                /*" -2149- ELSE */
            }
            else
            {


                /*" -2150- IF V0HCOB-SITUACAO NOT EQUAL '1' */

                if (V0HCOB_SITUACAO != "1")
                {

                    /*" -2151- MOVE ' ' TO V0HCTA-SITUACAO */
                    _.Move(" ", V0HCTA_SITUACAO);

                    /*" -2152- ELSE */
                }
                else
                {


                    /*" -2153- MOVE '1' TO V0HCTA-SITUACAO */
                    _.Move("1", V0HCTA_SITUACAO);

                    /*" -2158- END-IF. */
                }

            }


            /*" -2162- MOVE V0OPCP-OPCAOPAG TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move(V0OPCP_OPCAOPAG, V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -2163- MOVE '2000-REJEITA-PARCELA' TO PARAGRAFO. */
            _.Move("2000-REJEITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2165- MOVE 'UPDATE V0FITASASSE' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2166- MOVE 44 TO SII */
            _.Move(44, WS_HORAS.SII);

            /*" -2168- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2176- PERFORM R2000_00_REJEITA_PARCELA_DB_UPDATE_1 */

            R2000_00_REJEITA_PARCELA_DB_UPDATE_1();

            /*" -2178- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2179- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2181- DISPLAY V0HCTA-NRCERTIF ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"{V0HCTA_NRCERTIF} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -2183- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2186- ADD V0HCTA-VLPRMTOT TO WS-ACG-TOTDBNEFET. */
            WORK_AREA.WS_ACG_TOTDBNEFET.Value = WORK_AREA.WS_ACG_TOTDBNEFET + V0HCTA_VLPRMTOT;

            /*" -2188- IF (RF-COD-RETORNO EQUAL 97 OR 98 OR 99) AND (V0HCTA-TIPLANC EQUAL '1' ) */

            if ((RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99")) && (V0HCTA_TIPLANC == "1"))
            {

                /*" -2189- IF V0PRVG-PERIPGTO GREATER 1 */

                if (V0PRVG_PERIPGTO > 1)
                {

                    /*" -2190- MOVE '0' TO V0HCTA-SITUACAO */
                    _.Move("0", V0HCTA_SITUACAO);

                    /*" -2192- END-IF */
                }


                /*" -2193- ELSE */
            }
            else
            {


                /*" -2194- IF V0HCOB-SITUACAO NOT EQUAL '1' */

                if (V0HCOB_SITUACAO != "1")
                {

                    /*" -2196- IF V0HCOB-SITUACAO EQUAL '2' OR RF-COD-RETORNO EQUAL 97 OR 98 OR 99 */

                    if (V0HCOB_SITUACAO == "2" || RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99"))
                    {

                        /*" -2198- MOVE '2' TO V0HCTA-SITUACAO. */
                        _.Move("2", V0HCTA_SITUACAO);
                    }

                }

            }


            /*" -2200- MOVE 'UPDATE V0HISTCOBVA 3' TO COMANDO. */
            _.Move("UPDATE V0HISTCOBVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2201- MOVE 45 TO SII */
            _.Move(45, WS_HORAS.SII);

            /*" -2203- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2212- PERFORM R2000_00_REJEITA_PARCELA_DB_UPDATE_2 */

            R2000_00_REJEITA_PARCELA_DB_UPDATE_2();

            /*" -2215- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2216- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2218- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2220- MOVE 'UPDATE V0PARCELVA' TO COMANDO. */
            _.Move("UPDATE V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2221- MOVE 07 TO SII */
            _.Move(07, WS_HORAS.SII);

            /*" -2223- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2232- PERFORM R2000_00_REJEITA_PARCELA_DB_UPDATE_3 */

            R2000_00_REJEITA_PARCELA_DB_UPDATE_3();

            /*" -2236- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2237- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2239- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2240- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' OR 'ESPEC' */

            if (V0PRVG_ORIG_PRODU.In("EMPRE", "ESPEC"))
            {

                /*" -2240- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-1 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_1()
        {
            /*" -2176- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET TOT_DEB_NAO_EFET = TOT_DEB_NAO_EFET + :V0HCTA-VLPRMTOT, QTDE_LANC_DEB_RET = QTDE_LANC_DEB_RET + 1 WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS END-EXEC */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-2 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_2()
        {
            /*" -2212- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = :V0HCTA-SITUACAO, OPCAOPAG = :V0HCOB-OPCAOPAG, OCORHIST = :V0HCOB-OCORHIST WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCOB_OPCAOPAG = V0HCOB_OPCAOPAG.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-SECTION */
        private void R2100_00_MUDA_OPCAOPAG_SECTION()
        {
            /*" -2266- MOVE 'R2100-00-MUDA-OPCAOPAG' TO PARAGRAFO. */
            _.Move("R2100-00-MUDA-OPCAOPAG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2267- IF V0PRVG-OPCAOPAG = '3' */

            if (V0PRVG_OPCAOPAG == "3")
            {

                /*" -2269- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2273- MOVE '3' TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move("3", V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -2274- IF V0OPCP-OPCAOPAG = '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -2276- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2278- MOVE 'UPDATE V0OPCAOPAGVA' TO COMANDO. */
            _.Move("UPDATE V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2279- MOVE 47 TO SII */
            _.Move(47, WS_HORAS.SII);

            /*" -2281- PERFORM R9000-00-INICIO. */

            R9000_00_INICIO_SECTION();

            /*" -2287- PERFORM R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1 */

            R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1();

            /*" -2290- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2291- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2293- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2294- MOVE 'INSERT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("INSERT V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2296- MOVE '3' TO V0OPCP-OPCAOPAG. */
            _.Move("3", V0OPCP_OPCAOPAG);

            /*" -2297- MOVE 48 TO SII */
            _.Move(48, WS_HORAS.SII);

            /*" -2299- PERFORM R9000-00-INICIO. */

            R9000_00_INICIO_SECTION();

            /*" -2327- PERFORM R2100_00_MUDA_OPCAOPAG_DB_INSERT_1 */

            R2100_00_MUDA_OPCAOPAG_DB_INSERT_1();

            /*" -2330- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2331- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2331- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-DB-UPDATE-1 */
        public void R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1()
        {
            /*" -2287- EXEC SQL UPDATE SEGUROS.V0OPCAOPAGVA SET DTTERVIG = :V0HCOB-DTALTOPC, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1 = new R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1()
            {
                V0HCOB_DTALTOPC = V0HCOB_DTALTOPC.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1.Execute(r2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-DB-INSERT-1 */
        public void R2100_00_MUDA_OPCAOPAG_DB_INSERT_1()
        {
            /*" -2327- EXEC SQL INSERT INTO SEGUROS.V0OPCAOPAGVA (NRCERTIF, DTINIVIG, DTTERVIG, OPCAOPAG, PERIPGTO, DIA_DEBITO, CODUSU, TIMESTAMP, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, NUM_CARTAO_CREDITO) VALUES (:V0HCTA-NRCERTIF, :V0HCOB-DTVENCTO, '9999-12-31' , :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIADEB, 'VA1815B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 = new R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                V0OPCP_DIADEB = V0OPCP_DIADEB.ToString(),
            };

            R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1.Execute(r2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-3 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_3()
        {
            /*" -2232- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = :V0HCTA-SITUACAO, OPCAOOPAG = :V0PARC-OPCAOPAG, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC. */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0PARC_OPCAOPAG = V0PARC_OPCAOPAG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R8800-00-UPDATE-FOLLOWUP-SECTION */
        private void R8800_00_UPDATE_FOLLOWUP_SECTION()
        {
            /*" -2342- MOVE 'R8800-UPDATE-FOLLOWUP   ' TO PARAGRAFO. */
            _.Move("R8800-UPDATE-FOLLOWUP   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2354- PERFORM R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1 */

            R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1();

            /*" -2357- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2363- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -2364- ELSE */
                }
                else
                {


                    /*" -2365- DISPLAY 'R8800-00 - PROBLEMAS UPDATE (FOLLOWUP)   ' */
                    _.Display($"R8800-00 - PROBLEMAS UPDATE (FOLLOWUP)   ");

                    /*" -2365- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8800-00-UPDATE-FOLLOWUP-DB-UPDATE-1 */
        public void R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1()
        {
            /*" -2354- EXEC SQL UPDATE SEGUROS.VG_FOLLOW_UP SET NUM_PARCELA_USADA = :V0HCTA-NRPARCEL, STA_PROCESSAMENTO = 'P' , COD_USUARIO = 'VA1815B' , DTH_ATUALIZACAO = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :VGFOLLOW-NUM-CERTIFICADO AND NUM_NOSSA_FITA = :VGFOLLOW-NUM-NOSSA-FITA AND NUM_LANCAMENTO = :VGFOLLOW-NUM-LANCAMENTO END-EXEC. */

            var r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1 = new R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1()
            {
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                VGFOLLOW_NUM_CERTIFICADO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO.ToString(),
                VGFOLLOW_NUM_NOSSA_FITA = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA.ToString(),
                VGFOLLOW_NUM_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO.ToString(),
            };

            R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1.Execute(r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8800_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -2374- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2375- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -2384- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2385- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2386- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2387- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_49[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_49[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -2388- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_49[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_49[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -2397- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2398- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -2403- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -2404- IF SII < 51 */

            if (WS_HORAS.SII < 51)
            {

                /*" -2405- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_49[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -2407- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_49[WS_HORAS.SII]}"
                .Display();

                /*" -2409- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2410- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2422- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -2423- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -2424- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -2425- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -2426- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -2428- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -2430- CLOSE RETREL. */
            RETREL.Close();

            /*" -2430- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2433- DISPLAY 'CERTIFICADO ' V0HCTA-NRCERTIF. */
            _.Display($"CERTIFICADO {V0HCTA_NRCERTIF}");

            /*" -2434- DISPLAY 'PARCELA     ' V0HCTA-NRPARCEL. */
            _.Display($"PARCELA     {V0HCTA_NRPARCEL}");

            /*" -2436- DISPLAY 'LIDOS       ' AC-LIDOS. */
            _.Display($"LIDOS       {WORK_AREA.AC_LIDOS}");

            /*" -2438- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -2440- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2440- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}