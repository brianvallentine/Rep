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
using Sias.FederalVida.DB2.VF0853B;

namespace Code
{
    public class VF0853B
    {
        public bool IsCall { get; set; }

        public VF0853B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  FEDERAL VIDA                       *      */
        /*"      *   PROGRAMA ...............  VF0853B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  16/09/1998                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA A PROXIMA PARCELA DO SEGURO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PROPOSTAS VA                        V0PROPOSTAVA      INPUT    *      */
        /*"      * COBERTURAS PROPOSTA VA              V0COBERPROPVA     INPUT    *      */
        /*"      * PARCELAS VA                         V0PARCELVA        I-O      *      */
        /*"      * DIFERENCAS DE PARCELAS VA           V0DIFPARCELVA     I-O      *      */
        /*"      * HISTORICO DEBITO CONTA VA           V0HISTCONTAVA     OUTPUT   *      */
        /*"      * HISTORICO COBRANCA VA               V0HISTCOBVA       OUTPUT   *      */
        /*"      * COMPOSICAO DE TITULOS VA            V0COMPTITVA       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06                                                    *      */
        /*"      *             - CAD 87.342                                       *      */
        /*"      *               MODIFICACAO DO NUMERO DO COD_OPERACAO ENVIADO    *      */
        /*"      *               PARA A TABELA SEGUROS.V0HISTCOBVA ONDE O CORRETO *      */
        /*"      *               E ENVIAR 143 POR SE TRATAR DE CORRECAO DE IGP-M. *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2013 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.06             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05                                                    *      */
        /*"      *             - CAD 81.324                                       *      */
        /*"      *               ALTERACAO PARA EVITAR ERRO NA GERACAO DE NUMEROS *      */
        /*"      *               DE TITULOS PARA O COD_CEDENTE = 36 DA TABELA     *      */
        /*"      *               SEGUROS.CEDENTE                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/04/2012 - AUGUSTO ANASTACIO (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.05             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04                                                    *      */
        /*"      *             - CAD  201.122                                     *      */
        /*"      *               INSERIR COLUNAS NA CLAUSULA INSERT DAS TABELAS   *      */
        /*"      *               HIST_LANC_CTA OU V0HISTCONTAVA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2011 - LOPES          (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.04             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03     08/03/2010  MARCO (FAST COMPUTER)              *      */
        /*"      *   CAD-38.578                CORRECAO DE ABEND, TRATAMENTO  DE  *      */
        /*"      *                             CODIGO DE RETORNO SQLCODE -803.    *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURE V.03       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02     22/09/2008  FAST COMPUTER                      *      */
        /*"      *   CAD-14573                 ALTERADO PARA NAO ABENDAR          *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURE V.02       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO 01                                                   *      */
        /*"      * DATA: 07/08/2006 - MARCO ANTONIO                               *      */
        /*"      * CORRECAO DO ABEND OCORRIDO - SQLCODE = -803                    *      */
        /*"      *                   PROCURAR POR V.01                            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WHOST-VLPREMIO      PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1SIST-DTCORMAISQD  PIC  X(010).*/
        public StringBasis V1SIST_DTCORMAISQD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCORMAIS1D  PIC  X(010).*/
        public StringBasis V1SIST_DTCORMAIS1D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCORMAIS1M  PIC  X(010).*/
        public StringBasis V1SIST_DTCORMAIS1M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCORMAIS3M  PIC  X(010).*/
        public StringBasis V1SIST_DTCORMAIS3M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CEDE-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0CEDE_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0BANC-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
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
        /*"77         V0PROP-QTDPARATZ    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PROP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PROP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0SEGU-DTINISAF     PIC  X(10).*/
        public StringBasis V0SEGU_DTINISAF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0SEGU-DTINIRTO     PIC  X(10).*/
        public StringBasis V0SEGU_DTINIRTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0SEGU-DTINIDIT     PIC  X(10).*/
        public StringBasis V0SEGU_DTINIDIT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0SEGU-DTINIDFT     PIC  X(10).*/
        public StringBasis V0SEGU_DTINIDFT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RSAF-DTREFER      PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RSAF-SITUACAO     PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0RSAF-CODOPER      PIC S9(04) COMP.*/
        public IntBasis V0RSAF_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0SAFC-VLCUSTSAF    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0OPCP-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-DIA-DEBITO   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-AGECTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-OPRCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-NUMCTADEB    PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0OPCP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0OPCP-DIGCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDAGE       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDOPR       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDNUM       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDDIG       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-VLPREMIO     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTAUXF   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-IVLCUSTAUXF  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-PRMTOTANT    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-NUM-PARCELA  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V3DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V3DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0DIFP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CONV-CODCONV      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HICB-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HICB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HICB-SITUACAO     PIC  X(001).*/
        public StringBasis V0HICB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HICB-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HICB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COMP-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0COMP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COMP-CODOPER      PIC S9(004) COMP.*/
        public IntBasis V0COMP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COMP-PRMDIFVG     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COMP-PRMDIFAP     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  W-TITULO-CED                PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_TITULO_CED { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  W-TITULO                    PIC S9(013)   VALUE +0 COMP-3.*/
        public IntBasis W_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VF0853B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VF0853B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VF0853B_FILLER_0(); _.Move(W_NUMR_TITULO, _filler_0); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_0, W_NUMR_TITULO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUMR_TITULO); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VF0853B_FILLER_0 : VarBasis
        {
            /*"  05    WTITL-ZEROS             PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA         PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO            PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              DPARM01X.*/

            public _REDEF_VF0853B_FILLER_0()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VF0853B_DPARM01X DPARM01X { get; set; } = new VF0853B_DPARM01X();
        public class VF0853B_DPARM01X : VarBasis
        {
            /*"  05            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_VF0853B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VF0853B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VF0853B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VF0853B_DPARM01_R : VarBasis
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

                public _REDEF_VF0853B_DPARM01_R()
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
        public VF0853B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VF0853B_AREA_DE_WORK();
        public class VF0853B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-GRAVADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-CPROPVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPROPVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CDIFPAR    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDIFPAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CCMPTIT    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CCMPTIT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WREGULARIZOU    PIC X(001)  VALUE SPACES.*/
            public StringBasis WREGULARIZOU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WDATA-SISTEMA.*/
            public VF0853B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VF0853B_WDATA_SISTEMA();
            public class VF0853B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  9(004).*/
                public IntBasis WDATA_SIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  9(002).*/
                public IntBasis WDATA_SIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  9(002).*/
                public IntBasis WDATA_SIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA.*/
            }
            public VF0853B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new VF0853B_WDATA_VIGENCIA();
            public class VF0853B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002).*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VENCTO.*/
            }
            public VF0853B_WDATA_VENCTO WDATA_VENCTO { get; set; } = new VF0853B_WDATA_VENCTO();
            public class VF0853B_WDATA_VENCTO : VarBasis
            {
                /*"    10       WDATA-VEN-ANO     PIC  9(004).*/
                public IntBasis WDATA_VEN_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VEN-MES     PIC  9(002).*/
                public IntBasis WDATA_VEN_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VEN-DIA     PIC  9(002).*/
                public IntBasis WDATA_VEN_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
            }
            public VF0853B_WABEND WABEND { get; set; } = new VF0853B_WABEND();
            public class VF0853B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VF0853B '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VF0853B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public VF0853B_CPROPVA CPROPVA { get; set; } = new VF0853B_CPROPVA();
        public VF0853B_CDIFPAR CDIFPAR { get; set; } = new VF0853B_CDIFPAR();
        public VF0853B_CCMPTIT CCMPTIT { get; set; } = new VF0853B_CCMPTIT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -328- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -331- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -334- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -337- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -338- DISPLAY 'PROGRAMA EM EXECUCAO VF0853B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO VF0853B   ");

            /*" -339- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -344- DISPLAY 'VERSAO V.07 103.659 11/11/2014 ' . */
            _.Display($"VERSAO V.07 103.659 11/11/2014 ");

            /*" -345- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -347- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -349- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -362- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -365- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -366- DISPLAY 'ERRO SELECT V1SISTEMA VA' */
                _.Display($"ERRO SELECT V1SISTEMA VA");

                /*" -368- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -386- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -390- DISPLAY '*** VF0853B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VF0853B *** ABRINDO CURSOR ...");

            /*" -391- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -391- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -394- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -395- DISPLAY 'PROBLEMAS NO OPEN (CPROPVA   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPVA   ) ... ");

                /*" -397- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -399- DISPLAY '*** VF0853B *** PROCESSANDO ... ' . */
            _.Display($"*** VF0853B *** PROCESSANDO ... ");

            /*" -401- PERFORM R0910-00-FETCH-CPROPVA. */

            R0910_00_FETCH_CPROPVA_SECTION();

            /*" -402- IF WFIM-CPROPVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty())
            {

                /*" -403- DISPLAY 'V1SIST-DTCORMAISQD ' V1SIST-DTCORMAISQD */
                _.Display($"V1SIST-DTCORMAISQD {V1SIST_DTCORMAISQD}");

                /*" -404- DISPLAY 'V1SIST-DTCORMAIS1D ' V1SIST-DTCORMAIS1D */
                _.Display($"V1SIST-DTCORMAIS1D {V1SIST_DTCORMAIS1D}");

                /*" -405- DISPLAY 'V1SIST-DTCORMAIS1M ' V1SIST-DTCORMAIS1M */
                _.Display($"V1SIST-DTCORMAIS1M {V1SIST_DTCORMAIS1M}");

                /*" -406- DISPLAY 'V1SIST-DTCORMAIS3M ' V1SIST-DTCORMAIS3M */
                _.Display($"V1SIST-DTCORMAIS3M {V1SIST_DTCORMAIS3M}");

                /*" -407- DISPLAY 'V1SIST-DTMOVABE    ' V1SIST-DTMOVABE */
                _.Display($"V1SIST-DTMOVABE    {V1SIST_DTMOVABE}");

                /*" -409- DISPLAY '*** VF0853B *** NENHUMA PROPOSTA A PROCESSAR' */
                _.Display($"*** VF0853B *** NENHUMA PROPOSTA A PROCESSAR");

                /*" -434- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -449- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -454- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -457- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -458- DISPLAY 'BANCO NAO CADASTRADO (V0BANCO) 104 ' */
                _.Display($"BANCO NAO CADASTRADO (V0BANCO) 104 ");

                /*" -460- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -461- MOVE V0BANC-NRTIT TO W-NUMR-TITULO. */
            _.Move(V0BANC_NRTIT, W_NUMR_TITULO);

            /*" -462- DISPLAY ' ' */
            _.Display($" ");

            /*" -463- DISPLAY 'NUMERO BANCO TITULO <' W-NUMR-TITULO '>' */

            $"NUMERO BANCO TITULO <{W_NUMR_TITULO}>"
            .Display();

            /*" -465- DISPLAY ' ' */
            _.Display($" ");

            /*" -468- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CPROPVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -481- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -486- PERFORM R0000_00_PRINCIPAL_DB_UPDATE_1 */

            R0000_00_PRINCIPAL_DB_UPDATE_1();

            /*" -489- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -490- DISPLAY 'R0000 - ERRO UPDATE V0BANCO 104' */
                _.Display($"R0000 - ERRO UPDATE V0BANCO 104");

                /*" -505- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -506- DISPLAY 'PROPOSTAS LIDAS ............ ' WACC-LIDOS. */
            _.Display($"PROPOSTAS LIDAS ............ {AREA_DE_WORK.WACC_LIDOS}");

            /*" -508- DISPLAY 'PARCELAS GERADAS ........... ' WACC-GRAVADOS. */
            _.Display($"PARCELAS GERADAS ........... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -512- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -512- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -362- EXEC SQL SELECT CURRENT DATE + 15 DAYS, CURRENT DATE + 1 DAY, CURRENT DATE + 15 DAYS, CURRENT DATE + 15 DAYS + 2 MONTHS, DTMOVABE INTO :V1SIST-DTCORMAISQD, :V1SIST-DTCORMAIS1D, :V1SIST-DTCORMAIS1M, :V1SIST-DTCORMAIS3M, :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VF' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTCORMAISQD, V1SIST_DTCORMAISQD);
                _.Move(executed_1.V1SIST_DTCORMAIS1D, V1SIST_DTCORMAIS1D);
                _.Move(executed_1.V1SIST_DTCORMAIS1M, V1SIST_DTCORMAIS1M);
                _.Move(executed_1.V1SIST_DTCORMAIS3M, V1SIST_DTCORMAIS3M);
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -386- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT B.NRCERTIF, B.CODPRODU, B.CODCLIEN, B.NRPARCE, B.SITUACAO, B.DTVENCTO, B.DTPROXVEN, B.QTDPARATZ, B.TIMESTAMP FROM SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PROPOSTAVA B WHERE A.ESTR_COBR = 'FEDERAL' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.DTPROXVEN <= :V1SIST-DTCORMAISQD AND B.SITUACAO IN ( '3' , '6' ) END-EXEC. */
            CPROPVA = new VF0853B_CPROPVA(true);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT B.NRCERTIF
							, 
							B.CODPRODU
							, 
							B.CODCLIEN
							, 
							B.NRPARCE
							, 
							B.SITUACAO
							, 
							B.DTVENCTO
							, 
							B.DTPROXVEN
							, 
							B.QTDPARATZ
							, 
							B.TIMESTAMP 
							FROM SEGUROS.V0PRODUTOSVG A
							, 
							SEGUROS.V0PROPOSTAVA B 
							WHERE A.ESTR_COBR = 'FEDERAL' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.DTPROXVEN <= '{V1SIST_DTCORMAISQD}' 
							AND B.SITUACAO IN ( '3'
							, '6' )";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -391- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" R1500-00-COMPOE-DIFERENCAS-DB-DECLARE-1 */
        public void R1500_00_COMPOE_DIFERENCAS_DB_DECLARE_1()
        {
            /*" -1102- EXEC SQL DECLARE CDIFPAR CURSOR FOR SELECT NRPARCELDIF, DTVENCTO, CODOPER, PRMDIFVG+PRMDIFAP, PRMDIFVG, PRMDIFAP, NRPARCEL FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = 9999 AND SITUACAO = ' ' FOR UPDATE OF NRPARCEL, PRMDIFVG, PRMDIFAP END-EXEC. */
            CDIFPAR = new VF0853B_CDIFPAR(true);
            string GetQuery_CDIFPAR()
            {
                var query = @$"SELECT NRPARCELDIF
							, 
							DTVENCTO
							, 
							CODOPER
							, 
							PRMDIFVG+PRMDIFAP
							, 
							PRMDIFVG
							, 
							PRMDIFAP
							, 
							NRPARCEL 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND NRPARCEL = 9999 
							AND SITUACAO = ' '";

                return query;
            }
            CDIFPAR.GetQueryEvent += GetQuery_CDIFPAR;

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -518- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -519- DISPLAY ' ' */
            _.Display($" ");

            /*" -521- DISPLAY '*--------  VF0853B - FIM NORMAL  --------*' */
            _.Display($"*--------  VF0853B - FIM NORMAL  --------*");

            /*" -521- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-UPDATE-1 */
        public void R0000_00_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -486- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_UPDATE_1_Update1 = new R0000_00_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R0000_00_PRINCIPAL_DB_UPDATE_1_Update1.Execute(r0000_00_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -454- EXEC SQL SELECT NRTIT INTO :V0BANC-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BANC_NRTIT, V0BANC_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-SECTION */
        private void R0910_00_FETCH_CPROPVA_SECTION()
        {
            /*" -532- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -542- PERFORM R0910_00_FETCH_CPROPVA_DB_FETCH_1 */

            R0910_00_FETCH_CPROPVA_DB_FETCH_1();

            /*" -545- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -546- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -546- PERFORM R0910_00_FETCH_CPROPVA_DB_CLOSE_1 */

                    R0910_00_FETCH_CPROPVA_DB_CLOSE_1();

                    /*" -548- MOVE 'S' TO WFIM-CPROPVA */
                    _.Move("S", AREA_DE_WORK.WFIM_CPROPVA);

                    /*" -549- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -550- ELSE */
                }
                else
                {


                    /*" -551- DISPLAY 'R0910-00 ( FETCH CPROPVA   )...' */
                    _.Display($"R0910-00 ( FETCH CPROPVA   )...");

                    /*" -553- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -553- ADD 1 TO WACC-LIDOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-DB-FETCH-1 */
        public void R0910_00_FETCH_CPROPVA_DB_FETCH_1()
        {
            /*" -542- EXEC SQL FETCH CPROPVA INTO :V0PROP-NRCERTIF, :V0PROP-CODPRODU, :V0PROP-CODCLIEN, :V0PROP-NRPARCEL, :V0PROP-SITUACAO, :V0PROP-DTVENCTO, :V0PROP-DTPROXVEN, :V0PROP-QTDPARATZ, :V0PROP-TIMESTAMP END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVA.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CPROPVA.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CPROPVA.V0PROP_NRPARCEL, V0PROP_NRPARCEL);
                _.Move(CPROPVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPVA.V0PROP_DTVENCTO, V0PROP_DTVENCTO);
                _.Move(CPROPVA.V0PROP_DTPROXVEN, V0PROP_DTPROXVEN);
                _.Move(CPROPVA.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(CPROPVA.V0PROP_TIMESTAMP, V0PROP_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_CPROPVA_DB_CLOSE_1()
        {
            /*" -546- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -565- MOVE '1003' TO WNR-EXEC-SQL. */
            _.Move("1003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -577- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -580- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -581- DISPLAY 'R1000-00 (SELECT V0SEGURAVG)' */
                _.Display($"R1000-00 (SELECT V0SEGURAVG)");

                /*" -582- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -584- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -586- MOVE '1011' TO WNR-EXEC-SQL. */
            _.Move("1011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -605- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -608- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -609- DISPLAY 'R1000-00 (SELECT V0OPCAOPAGVA)' */
                _.Display($"R1000-00 (SELECT V0OPCAOPAGVA)");

                /*" -611- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-DTPROXVEN */

                $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_DTPROXVEN}"
                .Display();

                /*" -613- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -614- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -618- IF V0OPCP-INDAGE LESS ZEROES OR V0OPCP-INDOPR LESS ZEROES OR V0OPCP-INDNUM LESS ZEROES OR V0OPCP-INDDIG LESS ZEROES */

                if (V0OPCP_INDAGE < 00 || V0OPCP_INDOPR < 00 || V0OPCP_INDNUM < 00 || V0OPCP_INDDIG < 00)
                {

                    /*" -620- DISPLAY 'SEGURADO NAO TEM CONTA PARA DEBITAR ' V0PROP-NRCERTIF */
                    _.Display($"SEGURADO NAO TEM CONTA PARA DEBITAR {V0PROP_NRCERTIF}");

                    /*" -622- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -623- MOVE V0PROP-DTPROXVEN TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTPROXVEN, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -624- MOVE V0OPCP-DIA-DEBITO TO WDATA-SIS-DIA. */
            _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -626- MOVE WDATA-SISTEMA TO V0PROP-DTPROXVEN. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0PROP_DTPROXVEN);

            /*" -627- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -628- MOVE '1012' TO WNR-EXEC-SQL */
                _.Move("1012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -633- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

                R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

                /*" -635- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -636- DISPLAY 'R0000-00 (SELECT V0CONSICOV)' */
                    _.Display($"R0000-00 (SELECT V0CONSICOV)");

                    /*" -637- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -638- END-IF */
                }


                /*" -640- PERFORM R1200-00-GERA-PARCELAS UNTIL V0PROP-DTPROXVEN GREATER V1SIST-DTCORMAIS1M */

                while (!(V0PROP_DTPROXVEN > V1SIST_DTCORMAIS1M))
                {

                    R1200_00_GERA_PARCELAS_SECTION();
                }

                /*" -641- ELSE */
            }
            else
            {


                /*" -644- PERFORM R1200-00-GERA-PARCELAS UNTIL V0PROP-DTPROXVEN GREATER V1SIST-DTCORMAIS3M. */

                while (!(V0PROP_DTPROXVEN > V1SIST_DTCORMAIS3M))
                {

                    R1200_00_GERA_PARCELAS_SECTION();
                }
            }


            /*" -646- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -655- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -659- DISPLAY 'R1000-00 (UPDATE CPROPVA   )' */
                _.Display($"R1000-00 (UPDATE CPROPVA   )");

                /*" -660- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -660- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -577- EXEC SQL SELECT DATA_INIVIGENCIA + 7 MONTHS, DATA_INIVIGENCIA + 11 MONTHS, DATA_INIVIGENCIA + 3 MONTHS, DATA_INIVIGENCIA + 7 MONTHS INTO :V0SEGU-DTINISAF, :V0SEGU-DTINIRTO, :V0SEGU-DTINIDIT, :V0SEGU-DTINIDFT FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGU_DTINISAF, V0SEGU_DTINISAF);
                _.Move(executed_1.V0SEGU_DTINIRTO, V0SEGU_DTINIRTO);
                _.Move(executed_1.V0SEGU_DTINIDIT, V0SEGU_DTINIDIT);
                _.Move(executed_1.V0SEGU_DTINIDFT, V0SEGU_DTINIDFT);
            }


        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -664- PERFORM R0910-00-FETCH-CPROPVA. */

            R0910_00_FETCH_CPROPVA_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -605- EXEC SQL SELECT OPCAOPAG, PERIPGTO, DIA_DEBITO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB INTO :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIA-DEBITO, :V0OPCP-AGECTADEB:V0OPCP-INDAGE, :V0OPCP-OPRCTADEB:V0OPCP-INDOPR, :V0OPCP-NUMCTADEB:V0OPCP-INDNUM, :V0OPCP-DIGCTADEB:V0OPCP-INDDIG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTPROXVEN AND DTTERVIG >= :V0PROP-DTPROXVEN END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_DIA_DEBITO, V0OPCP_DIA_DEBITO);
                _.Move(executed_1.V0OPCP_AGECTADEB, V0OPCP_AGECTADEB);
                _.Move(executed_1.V0OPCP_INDAGE, V0OPCP_INDAGE);
                _.Move(executed_1.V0OPCP_OPRCTADEB, V0OPCP_OPRCTADEB);
                _.Move(executed_1.V0OPCP_INDOPR, V0OPCP_INDOPR);
                _.Move(executed_1.V0OPCP_NUMCTADEB, V0OPCP_NUMCTADEB);
                _.Move(executed_1.V0OPCP_INDNUM, V0OPCP_INDNUM);
                _.Move(executed_1.V0OPCP_DIGCTADEB, V0OPCP_DIGCTADEB);
                _.Move(executed_1.V0OPCP_INDDIG, V0OPCP_INDDIG);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -655- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET NRPARCE = :V0PROP-NRPARCEL, SITUACAO = :V0PROP-SITUACAO, DTVENCTO = :V0PROP-DTVENCTO, DTPROXVEN = :V0PROP-DTPROXVEN, QTDPARATZ = :V0PROP-QTDPARATZ, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0PROP-NRCERTIF END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_SITUACAO = V0PROP_SITUACAO.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -633- EXEC SQL SELECT COD_SEGURO INTO :V0CONV-CODCONV FROM SEGUROS.V0CONVSICOV WHERE CODPRODU = :V0PROP-CODPRODU END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0PROP_CODPRODU = V0PROP_CODPRODU.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODCONV, V0CONV_CODCONV);
            }


        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-SECTION */
        private void R1200_00_GERA_PARCELAS_SECTION()
        {
            /*" -677- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -683- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_1 */

            R1200_00_GERA_PARCELAS_DB_SELECT_1();

            /*" -686- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -687- DISPLAY 'R1200-00 (SELECT V0PARCELVA)' */
                _.Display($"R1200-00 (SELECT V0PARCELVA)");

                /*" -689- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF 'PARCEL: ' V0PROP-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF}PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -691- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -693- COMPUTE V0PROP-NRPARCEL = V0PROP-NRPARCEL + 1. */
            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL + 1;

            /*" -695- MOVE V0PROP-DTPROXVEN TO V0PROP-DTVENCTO. */
            _.Move(V0PROP_DTPROXVEN, V0PROP_DTVENCTO);

            /*" -696- IF V0OPCP-OPCAOPAG = '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -697- MOVE 0 TO V0PARC-OCORHIST */
                _.Move(0, V0PARC_OCORHIST);

                /*" -698- ELSE */
            }
            else
            {


                /*" -700- MOVE 1 TO V0PARC-OCORHIST. */
                _.Move(1, V0PARC_OCORHIST);
            }


            /*" -704- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' OR '5' */

            if (V0OPCP_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -706- PERFORM R1220-00-GERA-NUM-TITULO */

                R1220_00_GERA_NUM_TITULO_SECTION();

                /*" -708- MOVE W-TITULO-CED TO W-TITULO */
                _.Move(W_TITULO_CED, W_TITULO);

                /*" -710- MOVE W-TITULO-CED TO CEDENTE-NUM-TITULO */
                _.Move(W_TITULO_CED, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

                /*" -712- ELSE */
            }
            else
            {


                /*" -714- ADD 1 TO WTITL-SEQUENCIA */
                FILLER_0.WTITL_SEQUENCIA.Value = FILLER_0.WTITL_SEQUENCIA + 1;

                /*" -716- MOVE WTITL-SEQUENCIA TO DPARM01 */
                _.Move(FILLER_0.WTITL_SEQUENCIA, DPARM01X.DPARM01);

                /*" -718- CALL 'PROTIT01' USING DPARM01X */
                _.Call("PROTIT01", DPARM01X);

                /*" -719- IF DPARM01-RC NOT EQUAL +0 */

                if (DPARM01X.DPARM01_RC != +0)
                {

                    /*" -720- DISPLAY 'ERRO CHAMADA PROTIT01' */
                    _.Display($"ERRO CHAMADA PROTIT01");

                    /*" -721- DISPLAY 'CERTIFICADO     ' V0PROP-NRCERTIF */
                    _.Display($"CERTIFICADO     {V0PROP_NRCERTIF}");

                    /*" -722- DISPLAY 'AREA            ' DPARM01X */
                    _.Display($"AREA            {DPARM01X}");

                    /*" -723- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -725- END-IF */
                }


                /*" -728- MOVE DPARM01-D1 TO WTITL-DIGITO */
                _.Move(DPARM01X.DPARM01_D1, FILLER_0.WTITL_DIGITO);

                /*" -730- MOVE W-NUMR-TITULO TO V0BANC-NRTIT */
                _.Move(W_NUMR_TITULO, V0BANC_NRTIT);

                /*" -732- MOVE W-NUMR-TITULO TO W-TITULO */
                _.Move(W_NUMR_TITULO, W_TITULO);

                /*" -734- END-IF. */
            }


            /*" -736- MOVE '1201' TO WNR-EXEC-SQL. */
            _.Move("1201", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -751- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_2 */

            R1200_00_GERA_PARCELAS_DB_SELECT_2();

            /*" -754- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -755- DISPLAY 'R1200-00 (SELECT V0COBERPROPVA)' */
                _.Display($"R1200-00 (SELECT V0COBERPROPVA)");

                /*" -757- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-DTVENCTO */

                $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_DTVENCTO}"
                .Display();

                /*" -759- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -760- IF V0COBP-IVLCUSTAUXF LESS 0 */

            if (V0COBP_IVLCUSTAUXF < 0)
            {

                /*" -762- MOVE 0 TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -763- MOVE V0PROP-NRPARCEL TO V0COMP-NRPARCEL. */
            _.Move(V0PROP_NRPARCEL, V0COMP_NRPARCEL);

            /*" -764- MOVE V0COBP-PRMVG TO V0COMP-PRMDIFVG. */
            _.Move(V0COBP_PRMVG, V0COMP_PRMDIFVG);

            /*" -765- MOVE V0COBP-PRMAP TO V0COMP-PRMDIFAP. */
            _.Move(V0COBP_PRMAP, V0COMP_PRMDIFAP);

            /*" -767- MOVE 0 TO V0COMP-CODOPER. */
            _.Move(0, V0COMP_CODOPER);

            /*" -769- PERFORM R1250-00-GERA-V0COMPTITVA. */

            R1250_00_GERA_V0COMPTITVA_SECTION();

            /*" -770- MOVE V0COBP-VLPREMIO TO WHOST-VLPREMIO. */
            _.Move(V0COBP_VLPREMIO, WHOST_VLPREMIO);

            /*" -771- MOVE V0COBP-PRMVG TO WHOST-PRMVG. */
            _.Move(V0COBP_PRMVG, WHOST_PRMVG);

            /*" -773- MOVE V0COBP-PRMAP TO WHOST-PRMAP. */
            _.Move(V0COBP_PRMAP, WHOST_PRMAP);

            /*" -775- PERFORM R1500-00-COMPOE-DIFERENCAS. */

            R1500_00_COMPOE_DIFERENCAS_SECTION();

            /*" -776- IF WHOST-VLPREMIO EQUAL ZEROS */

            if (WHOST_VLPREMIO == 00)
            {

                /*" -780- MOVE '1' TO V0PARC-SITUACAO */
                _.Move("1", V0PARC_SITUACAO);

                /*" -781- PERFORM R1750-00-APROPRIA-DIFERENCAS */

                R1750_00_APROPRIA_DIFERENCAS_SECTION();

                /*" -782- ELSE */
            }
            else
            {


                /*" -784- MOVE ' ' TO V0PARC-SITUACAO. */
                _.Move(" ", V0PARC_SITUACAO);
            }


            /*" -786- MOVE '1202' TO WNR-EXEC-SQL. */
            _.Move("1202", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -798- PERFORM R1200_00_GERA_PARCELAS_DB_INSERT_1 */

            R1200_00_GERA_PARCELAS_DB_INSERT_1();

            /*" -802- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -805- DISPLAY 'R1200-00 (INSERT V0PARCELVA)' 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                $"R1200-00 (INSERT V0PARCELVA)CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -807- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -809- MOVE V0PROP-DTVENCTO TO V0HICB-DTVENCTO. */
            _.Move(V0PROP_DTVENCTO, V0HICB_DTVENCTO);

            /*" -810- IF V0PARC-SITUACAO EQUAL ' ' */

            if (V0PARC_SITUACAO == " ")
            {

                /*" -811- IF V0OPCP-OPCAOPAG NOT EQUAL '3' */

                if (V0OPCP_OPCAOPAG != "3")
                {

                    /*" -812- IF V0PROP-DTVENCTO < V1SIST-DTCORMAIS1D */

                    if (V0PROP_DTVENCTO < V1SIST_DTCORMAIS1D)
                    {

                        /*" -813- MOVE V1SIST-DTCORMAIS1D TO V0HICB-DTVENCTO */
                        _.Move(V1SIST_DTCORMAIS1D, V0HICB_DTVENCTO);

                        /*" -814- END-IF */
                    }


                    /*" -815- PERFORM R1300-00-GERA-DEBITO */

                    R1300_00_GERA_DEBITO_SECTION();

                    /*" -816- ELSE */
                }
                else
                {


                    /*" -817- IF V0PROP-DTVENCTO < V1SIST-DTCORMAISQD */

                    if (V0PROP_DTVENCTO < V1SIST_DTCORMAISQD)
                    {

                        /*" -819- MOVE V1SIST-DTCORMAISQD TO V0HICB-DTVENCTO. */
                        _.Move(V1SIST_DTCORMAISQD, V0HICB_DTVENCTO);
                    }

                }

            }


            /*" -820- IF V0PROP-QTDPARATZ GREATER 0 */

            if (V0PROP_QTDPARATZ > 0)
            {

                /*" -822- COMPUTE V0PROP-QTDPARATZ = V0PROP-QTDPARATZ - 1. */
                V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ - 1;
            }


            /*" -824- PERFORM R1400-00-GERA-HIST-COBRANCA. */

            R1400_00_GERA_HIST_COBRANCA_SECTION();

            /*" -825- IF V0PARC-SITUACAO EQUAL '1' */

            if (V0PARC_SITUACAO == "1")
            {

                /*" -827- PERFORM R1600-00-VERIFICA-REPASSE. */

                R1600_00_VERIFICA_REPASSE_SECTION();
            }


            /*" -827- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R1200_00_PROXIMA */

            R1200_00_PROXIMA();

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-1 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_1()
        {
            /*" -683- EXEC SQL SELECT PRMVG + PRMAP - VLMULTA INTO :V0PARC-PRMTOTANT FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC. */

            var r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMTOTANT, V0PARC_PRMTOTANT);
            }


        }

        [StopWatch]
        /*" R1200-00-PROXIMA */
        private void R1200_00_PROXIMA(bool isPerform = false)
        {
            /*" -833- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -835- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -836- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -837- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -839- COMPUTE WDATA-SIS-ANO = WDATA-SIS-ANO + 1. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -839- MOVE WDATA-SISTEMA TO V0PROP-DTPROXVEN. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0PROP_DTPROXVEN);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-INSERT-1 */
        public void R1200_00_GERA_PARCELAS_DB_INSERT_1()
        {
            /*" -798- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-DTVENCTO, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, :V0OPCP-OPCAOPAG, :V0PARC-SITUACAO, :V0PARC-OCORHIST, CURRENT TIMESTAMP) END-EXEC. */

            var r1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1 = new R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0COBP_PRMVG = V0COBP_PRMVG.ToString(),
                V0COBP_PRMAP = V0COBP_PRMAP.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
            };

            R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1.Execute(r1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-2 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_2()
        {
            /*" -751- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, VLCUSTAUXF, CODOPER INTO :V0COBP-VLPREMIO, :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF, :V0COBP-CODOPER FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTVENCTO AND DTTERVIG >= :V0PROP-DTVENCTO END-EXEC. */

            var r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_IVLCUSTAUXF, V0COBP_IVLCUSTAUXF);
                _.Move(executed_1.V0COBP_CODOPER, V0COBP_CODOPER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-GERA-NUM-TITULO-SECTION */
        private void R1220_00_GERA_NUM_TITULO_SECTION()
        {
            /*" -850- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -855- PERFORM R1220_00_GERA_NUM_TITULO_DB_UPDATE_1 */

            R1220_00_GERA_NUM_TITULO_DB_UPDATE_1();

            /*" -858- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -859- DISPLAY 'R0000 - ERRO UPDATE CEDENTE 36' */
                _.Display($"R0000 - ERRO UPDATE CEDENTE 36");

                /*" -861- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -866- PERFORM R1220_00_GERA_NUM_TITULO_DB_SELECT_1 */

            R1220_00_GERA_NUM_TITULO_DB_SELECT_1();

            /*" -870- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -871- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -872- DISPLAY 'CEDENTE NAO CADASTRADO (CEDENTE) 36' */
                    _.Display($"CEDENTE NAO CADASTRADO (CEDENTE) 36");

                    /*" -873- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -874- ELSE */
                }
                else
                {


                    /*" -875- DISPLAY 'PROBLEMAS NA CEDENTE' */
                    _.Display($"PROBLEMAS NA CEDENTE");

                    /*" -877- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -878- MOVE CEDENTE-NUM-TITULO TO W-TITULO-CED. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, W_TITULO_CED);

        }

        [StopWatch]
        /*" R1220-00-GERA-NUM-TITULO-DB-UPDATE-1 */
        public void R1220_00_GERA_NUM_TITULO_DB_UPDATE_1()
        {
            /*" -855- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = NUM_TITULO + 1, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CEDENTE = 36 END-EXEC. */

            var r1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1 = new R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1()
            {
            };

            R1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1.Execute(r1220_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1220-00-GERA-NUM-TITULO-DB-SELECT-1 */
        public void R1220_00_GERA_NUM_TITULO_DB_SELECT_1()
        {
            /*" -866- EXEC SQL SELECT NUM_TITULO INTO :CEDENTE-NUM-TITULO FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 36 END-EXEC. */

            var r1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1 = new R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1.Execute(r1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-GERA-V0COMPTITVA-SECTION */
        private void R1250_00_GERA_V0COMPTITVA_SECTION()
        {
            /*" -889- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -901- PERFORM R1250_00_GERA_V0COMPTITVA_DB_INSERT_1 */

            R1250_00_GERA_V0COMPTITVA_DB_INSERT_1();

            /*" -904- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -905- DISPLAY 'R1250-00 (INSERT V0COMPTITVA)' */
                _.Display($"R1250-00 (INSERT V0COMPTITVA)");

                /*" -908- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL '  ' 'TITULO: ' V0CEDE-NRTIT */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}  TITULO: {V0CEDE_NRTIT}"
                .Display();

                /*" -908- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1250-00-GERA-V0COMPTITVA-DB-INSERT-1 */
        public void R1250_00_GERA_V0COMPTITVA_DB_INSERT_1()
        {
            /*" -901- EXEC SQL INSERT INTO SEGUROS.V0COMPTITVA VALUES (:W-TITULO, :V0COMP-NRPARCEL, :V0COMP-CODOPER, :V0COMP-PRMDIFVG, :V0COMP-PRMDIFAP, :V1SIST-DTMOVABE, 'VF0853B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1 = new R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1()
            {
                W_TITULO = W_TITULO.ToString(),
                V0COMP_NRPARCEL = V0COMP_NRPARCEL.ToString(),
                V0COMP_CODOPER = V0COMP_CODOPER.ToString(),
                V0COMP_PRMDIFVG = V0COMP_PRMDIFVG.ToString(),
                V0COMP_PRMDIFAP = V0COMP_PRMDIFAP.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1.Execute(r1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GERA-DEBITO-SECTION */
        private void R1300_00_GERA_DEBITO_SECTION()
        {
            /*" -920- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -962- PERFORM R1300_00_GERA_DEBITO_DB_INSERT_1 */

            R1300_00_GERA_DEBITO_DB_INSERT_1();

            /*" -965- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -966- DISPLAY 'R1300-00 (INSERT V0HISTCONTAVA)' */
                _.Display($"R1300-00 (INSERT V0HISTCONTAVA)");

                /*" -968- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -968- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-GERA-DEBITO-DB-INSERT-1 */
        public void R1300_00_GERA_DEBITO_DB_INSERT_1()
        {
            /*" -962- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, 1, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0HICB-DTVENCTO, :WHOST-VLPREMIO, '0' , '1' , CURRENT TIMESTAMP, 0, :V0CONV-CODCONV, NULL, NULL, NULL, NULL, NULL, 0) END-EXEC. */

            var r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1 = new R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                V0HICB_DTVENCTO = V0HICB_DTVENCTO.ToString(),
                WHOST_VLPREMIO = WHOST_VLPREMIO.ToString(),
                V0CONV_CODCONV = V0CONV_CODCONV.ToString(),
            };

            R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1.Execute(r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GERA-HIST-COBRANCA-SECTION */
        private void R1400_00_GERA_HIST_COBRANCA_SECTION()
        {
            /*" -980- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -981- IF V0PARC-SITUACAO EQUAL '1' */

            if (V0PARC_SITUACAO == "1")
            {

                /*" -982- MOVE '1' TO V0HICB-SITUACAO */
                _.Move("1", V0HICB_SITUACAO);

                /*" -983- ELSE */
            }
            else
            {


                /*" -985- MOVE '5' TO V0HICB-SITUACAO. */
                _.Move("5", V0HICB_SITUACAO);
            }


            /*" -986- IF V0OPCP-OPCAOPAG EQUAL '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -987- MOVE 141 TO V0HICB-CODOPER */
                _.Move(141, V0HICB_CODOPER);

                /*" -988- ELSE */
            }
            else
            {


                /*" -990- MOVE 131 TO V0HICB-CODOPER. */
                _.Move(131, V0HICB_CODOPER);
            }


            /*" -992- MOVE 'N' TO WREGULARIZOU. */
            _.Move("N", AREA_DE_WORK.WREGULARIZOU);

            /*" -994- IF V0PROP-SITUACAO = '6' AND V0PROP-QTDPARATZ EQUAL 0 */

            if (V0PROP_SITUACAO == "6" && V0PROP_QTDPARATZ == 0)
            {

                /*" -995- MOVE 'S' TO WREGULARIZOU */
                _.Move("S", AREA_DE_WORK.WREGULARIZOU);

                /*" -996- MOVE '3' TO V0PROP-SITUACAO */
                _.Move("3", V0PROP_SITUACAO);

                /*" -997- MOVE 0 TO V0PROP-QTDPARATZ */
                _.Move(0, V0PROP_QTDPARATZ);

                /*" -998- MOVE '5' TO V0HICB-SITUACAO */
                _.Move("5", V0HICB_SITUACAO);

                /*" -999- IF V0OPCP-OPCAOPAG EQUAL '3' */

                if (V0OPCP_OPCAOPAG == "3")
                {

                    /*" -1000- MOVE 147 TO V0HICB-CODOPER */
                    _.Move(147, V0HICB_CODOPER);

                    /*" -1001- ELSE */
                }
                else
                {


                    /*" -1003- MOVE 135 TO V0HICB-CODOPER. */
                    _.Move(135, V0HICB_CODOPER);
                }

            }


            /*" -1005- MOVE V0HICB-DTVENCTO TO WDATA-VENCTO. */
            _.Move(V0HICB_DTVENCTO, AREA_DE_WORK.WDATA_VENCTO);

            /*" -1006- MOVE V0SEGU-DTINISAF TO WDATA-VIGENCIA. */
            _.Move(V0SEGU_DTINISAF, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -1008- IF WDATA-VIG-ANO = WDATA-VEN-ANO AND WDATA-VIG-MES = WDATA-VEN-MES */

            if (AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO == AREA_DE_WORK.WDATA_VENCTO.WDATA_VEN_ANO && AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES == AREA_DE_WORK.WDATA_VENCTO.WDATA_VEN_MES)
            {

                /*" -1009- MOVE '5' TO V0HICB-SITUACAO */
                _.Move("5", V0HICB_SITUACAO);

                /*" -1010- IF V0OPCP-OPCAOPAG EQUAL '3' */

                if (V0OPCP_OPCAOPAG == "3")
                {

                    /*" -1011- MOVE 142 TO V0HICB-CODOPER */
                    _.Move(142, V0HICB_CODOPER);

                    /*" -1012- ELSE */
                }
                else
                {


                    /*" -1014- MOVE 132 TO V0HICB-CODOPER. */
                    _.Move(132, V0HICB_CODOPER);
                }

            }


            /*" -1015- MOVE V0SEGU-DTINIRTO TO WDATA-VIGENCIA. */
            _.Move(V0SEGU_DTINIRTO, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -1017- IF WDATA-VIG-ANO = WDATA-VEN-ANO AND WDATA-VIG-MES = WDATA-VEN-MES */

            if (AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO == AREA_DE_WORK.WDATA_VENCTO.WDATA_VEN_ANO && AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES == AREA_DE_WORK.WDATA_VENCTO.WDATA_VEN_MES)
            {

                /*" -1018- MOVE '5' TO V0HICB-SITUACAO */
                _.Move("5", V0HICB_SITUACAO);

                /*" -1019- IF V0OPCP-OPCAOPAG EQUAL '3' */

                if (V0OPCP_OPCAOPAG == "3")
                {

                    /*" -1020- MOVE 145 TO V0HICB-CODOPER */
                    _.Move(145, V0HICB_CODOPER);

                    /*" -1021- ELSE */
                }
                else
                {


                    /*" -1023- MOVE 139 TO V0HICB-CODOPER. */
                    _.Move(139, V0HICB_CODOPER);
                }

            }


            /*" -1024- MOVE V0SEGU-DTINIDIT TO WDATA-VIGENCIA. */
            _.Move(V0SEGU_DTINIDIT, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -1026- IF WDATA-VIG-ANO = WDATA-VEN-ANO AND WDATA-VIG-MES = WDATA-VEN-MES */

            if (AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO == AREA_DE_WORK.WDATA_VENCTO.WDATA_VEN_ANO && AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES == AREA_DE_WORK.WDATA_VENCTO.WDATA_VEN_MES)
            {

                /*" -1027- MOVE '5' TO V0HICB-SITUACAO */
                _.Move("5", V0HICB_SITUACAO);

                /*" -1028- IF V0OPCP-OPCAOPAG EQUAL '3' */

                if (V0OPCP_OPCAOPAG == "3")
                {

                    /*" -1029- MOVE 146 TO V0HICB-CODOPER */
                    _.Move(146, V0HICB_CODOPER);

                    /*" -1030- ELSE */
                }
                else
                {


                    /*" -1032- MOVE 140 TO V0HICB-CODOPER. */
                    _.Move(140, V0HICB_CODOPER);
                }

            }


            /*" -1034- IF V0PARC-PRMTOTANT NOT EQUAL V0COBP-VLPREMIO AND V0PARC-PRMTOTANT NOT EQUAL 0 */

            if (V0PARC_PRMTOTANT != V0COBP_VLPREMIO && V0PARC_PRMTOTANT != 0)
            {

                /*" -1035- MOVE '5' TO V0HICB-SITUACAO */
                _.Move("5", V0HICB_SITUACAO);

                /*" -1036- IF V0COBP-CODOPER = 820 */

                if (V0COBP_CODOPER == 820)
                {

                    /*" -1037- IF V0OPCP-OPCAOPAG EQUAL '3' */

                    if (V0OPCP_OPCAOPAG == "3")
                    {

                        /*" -1038- MOVE 144 TO V0HICB-CODOPER */
                        _.Move(144, V0HICB_CODOPER);

                        /*" -1039- ELSE */
                    }
                    else
                    {


                        /*" -1040- MOVE 134 TO V0HICB-CODOPER */
                        _.Move(134, V0HICB_CODOPER);

                        /*" -1041- END-IF */
                    }


                    /*" -1042- ELSE */
                }
                else
                {


                    /*" -1043- IF V0COBP-CODOPER = 895 */

                    if (V0COBP_CODOPER == 895)
                    {

                        /*" -1045- IF V0OPCP-OPCAOPAG EQUAL '3' */

                        if (V0OPCP_OPCAOPAG == "3")
                        {

                            /*" -1046- MOVE 143 TO V0HICB-CODOPER */
                            _.Move(143, V0HICB_CODOPER);

                            /*" -1047- ELSE */
                        }
                        else
                        {


                            /*" -1049- MOVE 133 TO V0HICB-CODOPER. */
                            _.Move(133, V0HICB_CODOPER);
                        }

                    }

                }

            }


            /*" -1067- PERFORM R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1 */

            R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1();

            /*" -1070- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1071- DISPLAY 'R1400-00 (INSERT V0HISTCOBVA)' */
                _.Display($"R1400-00 (INSERT V0HISTCOBVA)");

                /*" -1075- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL 'TITULO: ' W-TITULO */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}TITULO: {W_TITULO}"
                .Display();

                /*" -1075- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-GERA-HIST-COBRANCA-DB-INSERT-1 */
        public void R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1()
        {
            /*" -1067- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :W-TITULO, :V0HICB-DTVENCTO, :WHOST-VLPREMIO, :V0OPCP-OPCAOPAG, :V0HICB-SITUACAO, :V0HICB-CODOPER, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 = new R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                W_TITULO = W_TITULO.ToString(),
                V0HICB_DTVENCTO = V0HICB_DTVENCTO.ToString(),
                WHOST_VLPREMIO = WHOST_VLPREMIO.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0HICB_SITUACAO = V0HICB_SITUACAO.ToString(),
                V0HICB_CODOPER = V0HICB_CODOPER.ToString(),
            };

            R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1.Execute(r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-COMPOE-DIFERENCAS-SECTION */
        private void R1500_00_COMPOE_DIFERENCAS_SECTION()
        {
            /*" -1102- PERFORM R1500_00_COMPOE_DIFERENCAS_DB_DECLARE_1 */

            R1500_00_COMPOE_DIFERENCAS_DB_DECLARE_1();

            /*" -1106- MOVE '1501' TO WNR-EXEC-SQL. */
            _.Move("1501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1106- PERFORM R1500_00_COMPOE_DIFERENCAS_DB_OPEN_1 */

            R1500_00_COMPOE_DIFERENCAS_DB_OPEN_1();

            /*" -1109- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1110- DISPLAY 'R1500-00 (OPEN CDIFPAR)' */
                _.Display($"R1500-00 (OPEN CDIFPAR)");

                /*" -1112- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1114- MOVE SPACES TO WFIM-CDIFPAR. */
            _.Move("", AREA_DE_WORK.WFIM_CDIFPAR);

            /*" -1116- PERFORM R1520-00-FETCH-CDIFPAR. */

            R1520_00_FETCH_CDIFPAR_SECTION();

            /*" -1117- PERFORM R1510-00-MONTA-DIFERENCA UNTIL WFIM-CDIFPAR NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty()))
            {

                R1510_00_MONTA_DIFERENCA_SECTION();
            }

        }

        [StopWatch]
        /*" R1500-00-COMPOE-DIFERENCAS-DB-OPEN-1 */
        public void R1500_00_COMPOE_DIFERENCAS_DB_OPEN_1()
        {
            /*" -1106- EXEC SQL OPEN CDIFPAR END-EXEC. */

            CDIFPAR.Open();

        }

        [StopWatch]
        /*" R1750-00-APROPRIA-DIFERENCAS-DB-DECLARE-1 */
        public void R1750_00_APROPRIA_DIFERENCAS_DB_DECLARE_1()
        {
            /*" -1272- EXEC SQL DECLARE CCMPTIT CURSOR FOR SELECT NRPARCEL, CODOPER, PRMDIFVG, PRMDIFAP FROM SEGUROS.V0COMPTITVA WHERE NRTIT = :W-TITULO AND CODOPER <> 0 END-EXEC. */
            CCMPTIT = new VF0853B_CCMPTIT(true);
            string GetQuery_CCMPTIT()
            {
                var query = @$"SELECT NRPARCEL
							, 
							CODOPER
							, 
							PRMDIFVG
							, 
							PRMDIFAP 
							FROM SEGUROS.V0COMPTITVA 
							WHERE NRTIT = '{W_TITULO}' 
							AND CODOPER <> 0";

                return query;
            }
            CCMPTIT.GetQueryEvent += GetQuery_CCMPTIT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-MONTA-DIFERENCA-SECTION */
        private void R1510_00_MONTA_DIFERENCA_SECTION()
        {
            /*" -1127- IF V0DIFP-CODOPER NOT LESS 600 AND V0DIFP-CODOPER NOT GREATER 699 */

            if (V0DIFP_CODOPER >= 600 && V0DIFP_CODOPER <= 699)
            {

                /*" -1128- IF WHOST-VLPREMIO < V0DIFP-VLPRMTOT */

                if (WHOST_VLPREMIO < V0DIFP_VLPRMTOT)
                {

                    /*" -1129- PERFORM R1530-00-DESMEMBRA-DIFERENCA */

                    R1530_00_DESMEMBRA_DIFERENCA_SECTION();

                    /*" -1130- ELSE */
                }
                else
                {


                    /*" -1131- COMPUTE WHOST-PRMVG = WHOST-PRMVG - V0DIFP-PRMDIFVG */
                    WHOST_PRMVG.Value = WHOST_PRMVG - V0DIFP_PRMDIFVG;

                    /*" -1132- COMPUTE WHOST-PRMAP = WHOST-PRMAP - V0DIFP-PRMDIFAP */
                    WHOST_PRMAP.Value = WHOST_PRMAP - V0DIFP_PRMDIFAP;

                    /*" -1133- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP */
                    WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;

                    /*" -1134- MOVE V0DIFP-NRPARCEL TO V0COMP-NRPARCEL */
                    _.Move(V0DIFP_NRPARCEL, V0COMP_NRPARCEL);

                    /*" -1135- MOVE V0DIFP-CODOPER TO V0COMP-CODOPER */
                    _.Move(V0DIFP_CODOPER, V0COMP_CODOPER);

                    /*" -1136- MOVE V0DIFP-PRMDIFVG TO V0COMP-PRMDIFVG */
                    _.Move(V0DIFP_PRMDIFVG, V0COMP_PRMDIFVG);

                    /*" -1137- MOVE V0DIFP-PRMDIFAP TO V0COMP-PRMDIFAP */
                    _.Move(V0DIFP_PRMDIFAP, V0COMP_PRMDIFAP);

                    /*" -1139- PERFORM R1250-00-GERA-V0COMPTITVA. */

                    R1250_00_GERA_V0COMPTITVA_SECTION();
                }

            }


            /*" -1141- IF V0DIFP-CODOPER NOT LESS 400 AND V0DIFP-CODOPER NOT GREATER 499 */

            if (V0DIFP_CODOPER >= 400 && V0DIFP_CODOPER <= 499)
            {

                /*" -1142- COMPUTE WHOST-PRMVG = WHOST-PRMVG + V0DIFP-PRMDIFVG */
                WHOST_PRMVG.Value = WHOST_PRMVG + V0DIFP_PRMDIFVG;

                /*" -1143- COMPUTE WHOST-PRMAP = WHOST-PRMAP + V0DIFP-PRMDIFAP */
                WHOST_PRMAP.Value = WHOST_PRMAP + V0DIFP_PRMDIFAP;

                /*" -1144- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;

                /*" -1145- MOVE V0DIFP-NRPARCEL TO V0COMP-NRPARCEL */
                _.Move(V0DIFP_NRPARCEL, V0COMP_NRPARCEL);

                /*" -1146- MOVE V0DIFP-CODOPER TO V0COMP-CODOPER */
                _.Move(V0DIFP_CODOPER, V0COMP_CODOPER);

                /*" -1147- MOVE V0DIFP-PRMDIFVG TO V0COMP-PRMDIFVG */
                _.Move(V0DIFP_PRMDIFVG, V0COMP_PRMDIFVG);

                /*" -1148- MOVE V0DIFP-PRMDIFAP TO V0COMP-PRMDIFAP */
                _.Move(V0DIFP_PRMDIFAP, V0COMP_PRMDIFAP);

                /*" -1150- PERFORM R1250-00-GERA-V0COMPTITVA. */

                R1250_00_GERA_V0COMPTITVA_SECTION();
            }


            /*" -1154- PERFORM R1510_00_MONTA_DIFERENCA_DB_UPDATE_1 */

            R1510_00_MONTA_DIFERENCA_DB_UPDATE_1();

            /*" -1156- PERFORM R1520-00-FETCH-CDIFPAR. */

            R1520_00_FETCH_CDIFPAR_SECTION();

        }

        [StopWatch]
        /*" R1510-00-MONTA-DIFERENCA-DB-UPDATE-1 */
        public void R1510_00_MONTA_DIFERENCA_DB_UPDATE_1()
        {
            /*" -1154- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V0PROP-NRPARCEL WHERE CURRENT OF CDIFPAR END-EXEC. */

            var r1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1 = new R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1(CDIFPAR)
            {
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1.Execute(r1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1520-00-FETCH-CDIFPAR-SECTION */
        private void R1520_00_FETCH_CDIFPAR_SECTION()
        {
            /*" -1167- MOVE '1520' TO WNR-EXEC-SQL. */
            _.Move("1520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1175- PERFORM R1520_00_FETCH_CDIFPAR_DB_FETCH_1 */

            R1520_00_FETCH_CDIFPAR_DB_FETCH_1();

            /*" -1178- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1179- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1179- PERFORM R1520_00_FETCH_CDIFPAR_DB_CLOSE_1 */

                    R1520_00_FETCH_CDIFPAR_DB_CLOSE_1();

                    /*" -1181- MOVE 'S' TO WFIM-CDIFPAR */
                    _.Move("S", AREA_DE_WORK.WFIM_CDIFPAR);

                    /*" -1182- ELSE */
                }
                else
                {


                    /*" -1183- DISPLAY 'R1520-00 (FETCH CDIFPAR)' */
                    _.Display($"R1520-00 (FETCH CDIFPAR)");

                    /*" -1184- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                    _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                    /*" -1184- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1520-00-FETCH-CDIFPAR-DB-FETCH-1 */
        public void R1520_00_FETCH_CDIFPAR_DB_FETCH_1()
        {
            /*" -1175- EXEC SQL FETCH CDIFPAR INTO :V0DIFP-NRPARCEL, :V0DIFP-DTVENCTO, :V0DIFP-CODOPER, :V0DIFP-VLPRMTOT, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, :V0DIFP-NUM-PARCELA END-EXEC. */

            if (CDIFPAR.Fetch())
            {
                _.Move(CDIFPAR.V0DIFP_NRPARCEL, V0DIFP_NRPARCEL);
                _.Move(CDIFPAR.V0DIFP_DTVENCTO, V0DIFP_DTVENCTO);
                _.Move(CDIFPAR.V0DIFP_CODOPER, V0DIFP_CODOPER);
                _.Move(CDIFPAR.V0DIFP_VLPRMTOT, V0DIFP_VLPRMTOT);
                _.Move(CDIFPAR.V0DIFP_PRMDIFVG, V0DIFP_PRMDIFVG);
                _.Move(CDIFPAR.V0DIFP_PRMDIFAP, V0DIFP_PRMDIFAP);
                _.Move(CDIFPAR.V0DIFP_NUM_PARCELA, V0DIFP_NUM_PARCELA);
            }

        }

        [StopWatch]
        /*" R1520-00-FETCH-CDIFPAR-DB-CLOSE-1 */
        public void R1520_00_FETCH_CDIFPAR_DB_CLOSE_1()
        {
            /*" -1179- EXEC SQL CLOSE CDIFPAR END-EXEC */

            CDIFPAR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_99_SAIDA*/

        [StopWatch]
        /*" R1530-00-DESMEMBRA-DIFERENCA-SECTION */
        private void R1530_00_DESMEMBRA_DIFERENCA_SECTION()
        {
            /*" -1195- MOVE '1531' TO WNR-EXEC-SQL. */
            _.Move("1531", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1200- PERFORM R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1 */

            R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1();

            /*" -1203- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1204- DISPLAY 'R1530-00 (UPDATE V0DIFPARCELVA)' */
                _.Display($"R1530-00 (UPDATE V0DIFPARCELVA)");

                /*" -1205- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                /*" -1207- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1208- MOVE V0DIFP-NRPARCEL TO V0COMP-NRPARCEL. */
            _.Move(V0DIFP_NRPARCEL, V0COMP_NRPARCEL);

            /*" -1209- MOVE V0DIFP-CODOPER TO V0COMP-CODOPER. */
            _.Move(V0DIFP_CODOPER, V0COMP_CODOPER);

            /*" -1210- MOVE WHOST-PRMVG TO V0COMP-PRMDIFVG. */
            _.Move(WHOST_PRMVG, V0COMP_PRMDIFVG);

            /*" -1212- MOVE WHOST-PRMAP TO V0COMP-PRMDIFAP. */
            _.Move(WHOST_PRMAP, V0COMP_PRMDIFAP);

            /*" -1214- PERFORM R1250-00-GERA-V0COMPTITVA. */

            R1250_00_GERA_V0COMPTITVA_SECTION();

            /*" -1216- MOVE 651 TO V3DIFP-CODOPER. */
            _.Move(651, V3DIFP_CODOPER);

            /*" -1217- COMPUTE V0DIFP-VLPRMTOT = V0DIFP-VLPRMTOT - WHOST-VLPREMIO. */
            V0DIFP_VLPRMTOT.Value = V0DIFP_VLPRMTOT - WHOST_VLPREMIO;

            /*" -1218- COMPUTE V0DIFP-PRMDIFVG = V0DIFP-PRMDIFVG - WHOST-PRMVG. */
            V0DIFP_PRMDIFVG.Value = V0DIFP_PRMDIFVG - WHOST_PRMVG;

            /*" -1218- COMPUTE V0DIFP-PRMDIFAP = V0DIFP-PRMDIFAP - WHOST-PRMAP. */
            V0DIFP_PRMDIFAP.Value = V0DIFP_PRMDIFAP - WHOST_PRMAP;

            /*" -0- FLUXCONTROL_PERFORM R1530_00_LOOP */

            R1530_00_LOOP();

        }

        [StopWatch]
        /*" R1530-00-DESMEMBRA-DIFERENCA-DB-UPDATE-1 */
        public void R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1()
        {
            /*" -1200- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET PRMDIFVG = :WHOST-PRMVG, PRMDIFAP = :WHOST-PRMAP WHERE CURRENT OF CDIFPAR END-EXEC. */

            var r1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1 = new R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1(CDIFPAR)
            {
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                WHOST_PRMAP = WHOST_PRMAP.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1.Execute(r1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1530-00-LOOP */
        private void R1530_00_LOOP(bool isPerform = false)
        {
            /*" -1224- MOVE '1532' TO WNR-EXEC-SQL. */
            _.Move("1532", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1239- PERFORM R1530_00_LOOP_DB_INSERT_1 */

            R1530_00_LOOP_DB_INSERT_1();

            /*" -1242- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1243- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1244- ADD 1 TO V3DIFP-CODOPER */
                    V3DIFP_CODOPER.Value = V3DIFP_CODOPER + 1;

                    /*" -1245- GO TO R1530-00-LOOP */
                    new Task(() => R1530_00_LOOP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1246- ELSE */
                }
                else
                {


                    /*" -1247- DISPLAY 'R1530-00 (INSERT V0DIFPARCELVA)' */
                    _.Display($"R1530-00 (INSERT V0DIFPARCELVA)");

                    /*" -1248- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                    _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                    /*" -1250- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1252- MOVE 0 TO WHOST-VLPREMIO WHOST-PRMVG WHOST-PRMAP. */
            _.Move(0, WHOST_VLPREMIO, WHOST_PRMVG, WHOST_PRMAP);

        }

        [StopWatch]
        /*" R1530-00-LOOP-DB-INSERT-1 */
        public void R1530_00_LOOP_DB_INSERT_1()
        {
            /*" -1239- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0PROP-NRCERTIF, 9999, :V0DIFP-NRPARCEL, :V3DIFP-CODOPER, :V0DIFP-DTVENCTO, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, 0, 0, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, 0, ' ' ) END-EXEC. */

            var r1530_00_LOOP_DB_INSERT_1_Insert1 = new R1530_00_LOOP_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
                V3DIFP_CODOPER = V3DIFP_CODOPER.ToString(),
                V0DIFP_DTVENCTO = V0DIFP_DTVENCTO.ToString(),
                V0DIFP_PRMDIFVG = V0DIFP_PRMDIFVG.ToString(),
                V0DIFP_PRMDIFAP = V0DIFP_PRMDIFAP.ToString(),
            };

            R1530_00_LOOP_DB_INSERT_1_Insert1.Execute(r1530_00_LOOP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1530_99_SAIDA*/

        [StopWatch]
        /*" R1750-00-APROPRIA-DIFERENCAS-SECTION */
        private void R1750_00_APROPRIA_DIFERENCAS_SECTION()
        {
            /*" -1272- PERFORM R1750_00_APROPRIA_DIFERENCAS_DB_DECLARE_1 */

            R1750_00_APROPRIA_DIFERENCAS_DB_DECLARE_1();

            /*" -1276- MOVE '1751' TO WNR-EXEC-SQL. */
            _.Move("1751", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1276- PERFORM R1750_00_APROPRIA_DIFERENCAS_DB_OPEN_1 */

            R1750_00_APROPRIA_DIFERENCAS_DB_OPEN_1();

            /*" -1279- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1280- DISPLAY 'R1750-00 (OPEN CURSOR CCMPTIT)' */
                _.Display($"R1750-00 (OPEN CURSOR CCMPTIT)");

                /*" -1281- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -1283- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1284- MOVE SPACES TO WFIM-CCMPTIT. */
            _.Move("", AREA_DE_WORK.WFIM_CCMPTIT);

            /*" -1286- PERFORM R1770-00-FETCH-V0COMPTITVA. */

            R1770_00_FETCH_V0COMPTITVA_SECTION();

            /*" -1287- IF WFIM-CCMPTIT NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CCMPTIT.IsEmpty())
            {

                /*" -1288- DISPLAY 'R1750-00 (DIFERENCAS NAO ENCONTRADAS) ' */
                _.Display($"R1750-00 (DIFERENCAS NAO ENCONTRADAS) ");

                /*" -1289- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -1291- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1294- PERFORM R1760-00-APROPRIA-DIFERENCA UNTIL WFIM-CCMPTIT NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CCMPTIT.IsEmpty()))
            {

                R1760_00_APROPRIA_DIFERENCA_SECTION();
            }

            /*" -1296- MOVE '1752' TO WNR-EXEC-SQL. */
            _.Move("1752", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1296- PERFORM R1750_00_APROPRIA_DIFERENCAS_DB_CLOSE_1 */

            R1750_00_APROPRIA_DIFERENCAS_DB_CLOSE_1();

            /*" -1299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1300- DISPLAY 'R1750-00 (CLOSE CURSOR CCMPTIT)' */
                _.Display($"R1750-00 (CLOSE CURSOR CCMPTIT)");

                /*" -1301- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -1301- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1750-00-APROPRIA-DIFERENCAS-DB-OPEN-1 */
        public void R1750_00_APROPRIA_DIFERENCAS_DB_OPEN_1()
        {
            /*" -1276- EXEC SQL OPEN CCMPTIT END-EXEC. */

            CCMPTIT.Open();

        }

        [StopWatch]
        /*" R1750-00-APROPRIA-DIFERENCAS-DB-CLOSE-1 */
        public void R1750_00_APROPRIA_DIFERENCAS_DB_CLOSE_1()
        {
            /*" -1296- EXEC SQL CLOSE CCMPTIT END-EXEC. */

            CCMPTIT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R1760-00-APROPRIA-DIFERENCA-SECTION */
        private void R1760_00_APROPRIA_DIFERENCA_SECTION()
        {
            /*" -1311- MOVE '1761' TO WNR-EXEC-SQL */
            _.Move("1761", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1322- PERFORM R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1 */

            R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1();

            /*" -1325- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1326- DISPLAY 'R1760-00 (UPDATE V0COMPTITVA) ' */
                _.Display($"R1760-00 (UPDATE V0COMPTITVA) ");

                /*" -1328- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' PARCEL: ' V0PROP-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF} PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -1330- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1330- PERFORM R1770-00-FETCH-V0COMPTITVA. */

            R1770_00_FETCH_V0COMPTITVA_SECTION();

        }

        [StopWatch]
        /*" R1760-00-APROPRIA-DIFERENCA-DB-UPDATE-1 */
        public void R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1()
        {
            /*" -1322- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' , NRPARCEL = :V0PROP-NRPARCEL WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL AND NRPARCELDIF = :V0COMP-NRPARCEL AND CODOPER = :V0COMP-CODOPER AND PRMDIFVG = :V0COMP-PRMDIFVG AND PRMDIFAP = :V0COMP-PRMDIFAP END-EXEC. */

            var r1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1 = new R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1()
            {
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0COMP_NRPARCEL = V0COMP_NRPARCEL.ToString(),
                V0COMP_PRMDIFVG = V0COMP_PRMDIFVG.ToString(),
                V0COMP_PRMDIFAP = V0COMP_PRMDIFAP.ToString(),
                V0COMP_CODOPER = V0COMP_CODOPER.ToString(),
            };

            R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1.Execute(r1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1760_99_SAIDA*/

        [StopWatch]
        /*" R1770-00-FETCH-V0COMPTITVA-SECTION */
        private void R1770_00_FETCH_V0COMPTITVA_SECTION()
        {
            /*" -1340- MOVE '1770' TO WNR-EXEC-SQL. */
            _.Move("1770", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1345- PERFORM R1770_00_FETCH_V0COMPTITVA_DB_FETCH_1 */

            R1770_00_FETCH_V0COMPTITVA_DB_FETCH_1();

            /*" -1348- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1349- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1350- MOVE 'S' TO WFIM-CCMPTIT */
                    _.Move("S", AREA_DE_WORK.WFIM_CCMPTIT);

                    /*" -1351- ELSE */
                }
                else
                {


                    /*" -1352- DISPLAY 'R1770-00 (FETCH CCMPTIT)' */
                    _.Display($"R1770-00 (FETCH CCMPTIT)");

                    /*" -1352- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1770-00-FETCH-V0COMPTITVA-DB-FETCH-1 */
        public void R1770_00_FETCH_V0COMPTITVA_DB_FETCH_1()
        {
            /*" -1345- EXEC SQL FETCH CCMPTIT INTO :V0COMP-NRPARCEL, :V0COMP-CODOPER, :V0COMP-PRMDIFVG, :V0COMP-PRMDIFAP END-EXEC. */

            if (CCMPTIT.Fetch())
            {
                _.Move(CCMPTIT.V0COMP_NRPARCEL, V0COMP_NRPARCEL);
                _.Move(CCMPTIT.V0COMP_CODOPER, V0COMP_CODOPER);
                _.Move(CCMPTIT.V0COMP_PRMDIFVG, V0COMP_PRMDIFVG);
                _.Move(CCMPTIT.V0COMP_PRMDIFAP, V0COMP_PRMDIFAP);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1770_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-SECTION */
        private void R1600_00_VERIFICA_REPASSE_SECTION()
        {
            /*" -1365- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1371- PERFORM R1600_00_VERIFICA_REPASSE_DB_SELECT_1 */

            R1600_00_VERIFICA_REPASSE_DB_SELECT_1();

            /*" -1374- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1374- PERFORM R1670-00-REPASSA-SAF. */

                R1670_00_REPASSA_SAF_SECTION();
            }


        }

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-SELECT-1 */
        public void R1600_00_VERIFICA_REPASSE_DB_SELECT_1()
        {
            /*" -1371- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1 = new R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1.Execute(r1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1670-00-REPASSA-SAF-SECTION */
        private void R1670_00_REPASSA_SAF_SECTION()
        {
            /*" -1384- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -1386- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -1387- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -1388- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -1389- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -1391- ADD 1 TO WDATA-SIS-ANO. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -1393- MOVE WDATA-SISTEMA TO V0RSAF-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RSAF_DTREFER);

            /*" -1395- MOVE '1670' TO WNR-EXEC-SQL. */
            _.Move("1670", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1401- PERFORM R1670_00_REPASSA_SAF_DB_SELECT_1 */

            R1670_00_REPASSA_SAF_DB_SELECT_1();

            /*" -1404- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1406- GO TO R1670-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1670_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1407- IF WREGULARIZOU EQUAL 'S' */

            if (AREA_DE_WORK.WREGULARIZOU == "S")
            {

                /*" -1408- MOVE 501 TO V0RSAF-CODOPER */
                _.Move(501, V0RSAF_CODOPER);

                /*" -1410- PERFORM R1675-00-INSERT-V0HISTREPSAF. */

                R1675_00_INSERT_V0HISTREPSAF_SECTION();
            }


            /*" -1411- MOVE 1100 TO V0RSAF-CODOPER. */
            _.Move(1100, V0RSAF_CODOPER);

            /*" -1411- PERFORM R1675-00-INSERT-V0HISTREPSAF. */

            R1675_00_INSERT_V0HISTREPSAF_SECTION();

        }

        [StopWatch]
        /*" R1670-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1670_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -1401- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER END-EXEC. */

            var r1670_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R1670_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1670_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r1670_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1670_99_SAIDA*/

        [StopWatch]
        /*" R1675-00-INSERT-V0HISTREPSAF-SECTION */
        private void R1675_00_INSERT_V0HISTREPSAF_SECTION()
        {
            /*" -1421- MOVE '1675' TO WNR-EXEC-SQL. */
            _.Move("1675", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1437- PERFORM R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1 */

            R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1();

            /*" -1440- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1440- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1675-00-INSERT-V0HISTREPSAF-DB-INSERT-1 */
        public void R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1()
        {
            /*" -1437- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0PROP-NRCERTIF, :V0PROP-NRPARCEL, 0, :V0SAFC-VLCUSTSAF, :V0RSAF-CODOPER, '0' , '0' , 0, 0, 'VF0853B' , CURRENT TIMESTAMP, :V0PROP-DTVENCTO) END-EXEC. */

            var r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1 = new R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0RSAF_CODOPER = V0RSAF_CODOPER.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
            };

            R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1.Execute(r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1675_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1452- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1454- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1454- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1456- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1460- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1460- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}