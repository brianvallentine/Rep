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
using Sias.VidaEmGrupo.DB2.VG4267B;

namespace Code
{
    public class VG4267B
    {
        public bool IsCall { get; set; }

        public VG4267B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      * EMITE FATURA MENSAL DE PREMIOS PARA A APOLICE  ESPECIFICA DO  *       */
        /*"      * PRODUTO 7701 -                                                        */
        /*"      * EMPRESARIAL NA NOVA ESTRUTURA DE FATURAMENTO.                  *      */
        /*"      * V0HISTCOBVA COM SITUACAO = '5'  => IMPRIMIR CORRESPONDENCIA    *      */
        /*"      * ESTE PROGRAMA EH COPIA DO VG0267B                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   OPCAOPAG 1 E 2 =>  DEBITO    EM CONTA    CORRENTE            *      */
        /*"      *   OPCAOPAG     3 =>  DOCUMENTO DE COBRANCA BANCARIA            *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      ******************************************************************      */
        /*"JV127 *VERSAO 27: JV1 DEMANDA 259756 - KINKAS 19/11/2020               *      */
        /*"JV127 *           - RETIRADA DO ABEND 0C7                              *      */
        /*"JV127 *           - PROCURAR POR JV127                                 *      */
        /*"JV126 *----------------------------------------------------------------*      */
        /*"JV126 *VERSAO 26: JV1 DEMANDA 259756 - KINKAS 19/11/2020               *      */
        /*"JV126 *           AJUSTE DA MONTAGEM DO CODIGO DO FORMULARIO           *      */
        /*"JV126 *           - PROCURAR POR JV126                                 *      */
        /*"JV126 *----------------------------------------------------------------*      */
        /*"JV125 *VERSAO 25: JV1 DEMANDA 259756 - KINKAS 10/10/2020               *      */
        /*"JV125 *           ALTERA FORMULARIOS FASE 2 PARA EMPRESA 11 - JV1      *      */
        /*"JV125 *           - PROCURAR POR JV125                                 *      */
        /*"JV125 *----------------------------------------------------------------*      */
        /*"JV124 *VERSAO 24: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV124 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV124 *           - PROCURAR POR JV124                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     01     *  13/05/2015*   ALEXANDRE ANDRE                    *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RVG4267B { get; set; } = new FileBasis(new PIC("X", "1500", "X(1500)"));

        public FileBasis RVG4267B
        {
            get
            {
                _.Move(RVG4267B_RECORD, _RVG4267B); VarBasis.RedefinePassValue(RVG4267B_RECORD, _RVG4267B, RVG4267B_RECORD); return _RVG4267B;
            }
        }
        public FileBasis _FVG4267B { get; set; } = new FileBasis(new PIC("X", "1500", "X(1500)"));

        public FileBasis FVG4267B
        {
            get
            {
                _.Move(FVG4267B_RECORD, _FVG4267B); VarBasis.RedefinePassValue(FVG4267B_RECORD, _FVG4267B, FVG4267B_RECORD); return _FVG4267B;
            }
        }
        public SortBasis<VG4267B_REG_SVG4267B> SVG4267B { get; set; } = new SortBasis<VG4267B_REG_SVG4267B>(new VG4267B_REG_SVG4267B());
        /*"01            RVG4267B-RECORD     PIC X(1500).*/
        public StringBasis RVG4267B_RECORD { get; set; } = new StringBasis(new PIC("X", "1500", "X(1500)."), @"");
        /*"01            FVG4267B-RECORD     PIC X(1500).*/
        public StringBasis FVG4267B_RECORD { get; set; } = new StringBasis(new PIC("X", "1500", "X(1500)."), @"");
        /*"01            REG-SVG4267B.*/
        public VG4267B_REG_SVG4267B REG_SVG4267B { get; set; } = new VG4267B_REG_SVG4267B();
        public class VG4267B_REG_SVG4267B : VarBasis
        {
            /*"    05        SVA-NRAPOLICE       PIC  9(013).*/
            public IntBasis SVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-CODSUBES        PIC  9(005).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        SVA-CODPRODU        PIC  9(004).*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-CEP-G           PIC  9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        SVA-CEP-G-IX        PIC  9(006).*/
            public IntBasis SVA_CEP_G_IX { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05        SVA-NUM-CEP-9       PIC  9(008).*/
            public IntBasis SVA_NUM_CEP_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        SVA-NUM-CEP         REDEFINES              SVA-NUM-CEP-9.*/
            private _REDEF_VG4267B_SVA_NUM_CEP _sva_num_cep { get; set; }
            public _REDEF_VG4267B_SVA_NUM_CEP SVA_NUM_CEP
            {
                get { _sva_num_cep = new _REDEF_VG4267B_SVA_NUM_CEP(); _.Move(SVA_NUM_CEP_9, _sva_num_cep); VarBasis.RedefinePassValue(SVA_NUM_CEP_9, _sva_num_cep, SVA_NUM_CEP_9); _sva_num_cep.ValueChanged += () => { _.Move(_sva_num_cep, SVA_NUM_CEP_9); }; return _sva_num_cep; }
                set { VarBasis.RedefinePassValue(value, _sva_num_cep, SVA_NUM_CEP_9); }
            }  //Redefines
            public class _REDEF_VG4267B_SVA_NUM_CEP : VarBasis
            {
                /*"      15      SVA-CEP             PIC  9(005).*/
                public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15      SVA-CEP-COMPL       PIC  9(003).*/
                public IntBasis SVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        SVA-NRCERTIF        PIC  9(015).*/

                public _REDEF_VG4267B_SVA_NUM_CEP()
                {
                    SVA_CEP.ValueChanged += OnValueChanged;
                    SVA_CEP_COMPL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-OCORHIST        PIC  9(004).*/
            public IntBasis SVA_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-NRTIT           PIC  9(013).*/
            public IntBasis SVA_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-NRTITCOMP       PIC  9(013).*/
            public IntBasis SVA_NRTITCOMP { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-NRCNPJ          PIC  9(015).*/
            public IntBasis SVA_NRCNPJ { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-NRPARCEL        PIC  9(004).*/
            public IntBasis SVA_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-DTVENCTO        PIC  X(010).*/
            public StringBasis SVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-DTVENCTO-ORIG   PIC  X(010).*/
            public StringBasis SVA_DTVENCTO_ORIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-VLPRMTOT        PIC  9(013)V99.*/
            public DoubleBasis SVA_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05        SVA-CODOPER         PIC  9(004).*/
            public IntBasis SVA_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-ENDERECO        PIC  X(072).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-BAIRRO          PIC  X(072).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-CIDADE          PIC  X(072).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-UF              PIC  X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05        SVA-NOME-RAZAO      PIC  X(040).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        SVA-NOME-CORREIO    PIC  X(046).*/
            public StringBasis SVA_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05        SVA-FONTE           PIC  9(004).*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-AGECOBR         PIC  9(004).*/
            public IntBasis SVA_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-DTQITBCO        PIC  X(010).*/
            public StringBasis SVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-PERIPGTO        PIC  9(004).*/
            public IntBasis SVA_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-COD-EMPRESA     PIC  9(004).*/
            public IntBasis SVA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77            W-RETURN-CODE       PIC 9(006) VALUE 0.*/
        public IntBasis W_RETURN_CODE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77            W-OPEN-ARQ          PIC X(003) VALUE 'NAO'.*/
        public StringBasis W_OPEN_ARQ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77            VIND-NRCOPIAS       PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-NRTITCOMP      PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-TEMCDG         PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_TEMCDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            SQL-PCIOF           PIC S9(003)V99 COMP-3.*/
        public DoubleBasis SQL_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77            WHOST-NRCERTIF       PIC S9(015)    COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            WHOST-NRPARCEL       PIC S9(004)    COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRTIT          PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-NRTITCOMP      PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-OCORHIST       PIC S9(004)    COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRAPOLICE      PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-CODSUBES       PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODPRODU       PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODOPER        PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0COBP-QUANT-VIDAS   PIC S9(009)    COMP.*/
        public IntBasis V0COBP_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0COBP-IMPSEGUR      PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBP-DTINIVIG-PARC PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WS-FLAG-CALC-PARC    PIC  X(003) VALUE 'NAO'.*/
        public StringBasis WS_FLAG_CALC_PARC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77            WS-DTCALC-PARC       PIC  X(010).*/
        public StringBasis WS_DTCALC_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WS-DTINIVIG-PARC     PIC  X(010).*/
        public StringBasis WS_DTINIVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WS-DTTERVIG-PARC     PIC  X(010).*/
        public StringBasis WS_DTTERVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WS-QTD-DIAS-PARC     PIC S9(004)    COMP.*/
        public IntBasis WS_QTD_DIAS_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0COBP-OCORHIST      PIC S9(004)    COMP.*/
        public IntBasis V0COBP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-DATA1          PIC  X(010).*/
        public StringBasis WHOST_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WHOST-DATA2          PIC  X(010).*/
        public StringBasis WHOST_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-DATA-LIMITE  PIC  X(010).*/
        public StringBasis V1SIST_DATA_LIMITE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-MESREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1SIST-ANOREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-NUM-APOLICE  PIC S9(013)    COMP-3.*/
        public IntBasis V0PROD_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0PROD-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-ORIG-PRODU   PIC  X(010).*/
        public StringBasis V0PROD_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0PROD-ORIG-PRODU-I PIC S9(004)    COMP.*/
        public IntBasis V0PROD_ORIG_PRODU_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-ESTR-COBR    PIC  X(010).*/
        public StringBasis V0PROD_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0PROD-ESTR-COBR-I  PIC S9(004)    COMP.*/
        public IntBasis V0PROD_ESTR_COBR_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-NOMPRODU     PIC  X(030).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77            V0PROD-CODPRODU     PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-CODCDT       PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODCDT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-TEM-CDG      PIC  X(001).*/
        public StringBasis V0PROD_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0CEDE-NOMECED      PIC  X(040).*/
        public StringBasis V0CEDE_NOMECED { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0CEDE-AGENCIA      PIC S9(004)    COMP.*/
        public IntBasis V0CEDE_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CEDE-OPERACAO     PIC S9(004)    COMP.*/
        public IntBasis V0CEDE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CEDE-CONTA        PIC S9(009)    COMP.*/
        public IntBasis V0CEDE_CONTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0CEDE-DIGCC        PIC S9(004)    COMP.*/
        public IntBasis V0CEDE_DIGCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0DIFP-NRPARCELDIF  PIC S9(004)    COMP.*/
        public IntBasis V0DIFP_NRPARCELDIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0DIFP-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0DIFP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0DIFP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0DIFP-PRMDEV       PIC S9(015)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77            V0DIFP-PRMPAG       PIC S9(015)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77            V0DIFP-PRMDIF       PIC S9(015)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77            V0DIFP-VLMULTA      PIC S9(015)V99 COMP-3.*/
        public DoubleBasis V0DIFP_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77            V0MENS-NUM-APOLICE  PIC S9(013)    COMP-3.*/
        public IntBasis V0MENS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0MENS-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0MENS_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0MENS_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-JDE          PIC  X(008).*/
        public StringBasis V0MENS_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0MENS-JDL          PIC  X(008).*/
        public StringBasis V0MENS_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0FAIC-FAIXA        PIC S9(004)    COMP.*/
        public IntBasis V0FAIC_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0FAIC-CEPINI       PIC S9(009)    COMP.*/
        public IntBasis V0FAIC_CEPINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0FAIC-CEPFIM       PIC S9(009)    COMP.*/
        public IntBasis V0FAIC_CEPFIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0FAIC-DESC-FAIXA   PIC  X(072).*/
        public StringBasis V0FAIC_DESC_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0FAIC-CENTRALIZA   PIC  X(072).*/
        public StringBasis V0FAIC_CENTRALIZA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0COBE-IMPMORNATU   PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-VLPREMIO     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBE_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0COBE-IMPSEGCDG    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0PARC-NRCERTIF      PIC S9(015)    COMP-3.*/
        public IntBasis V0PARC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0PARC-NRPARCEL      PIC S9(004)    COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PARC-VLPRMTOT      PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0PARC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0PARC-DTVENCTO      PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0PARC-DTVENCTO-ORIG PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO_ORIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0PARC-PRMVG         PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0PARC-PRMAP         PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0PARC-VLMULTA       PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0PARC_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0HIST-NRCERTIF     PIC S9(015)    COMP-3.*/
        public IntBasis V0HIST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0HIST-OCORHIST     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-NRPARCEL     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-NRTIT        PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-NRTITCOMP    PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HIST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0HIST-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HIST_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0HIST-VLPRMTOT     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0HIST-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-CODPRODU     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-CDCLIENTE    PIC S9(009)    COMP.*/
        public IntBasis V0HIST_CDCLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0HIST-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0HIST_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-IDSEXO       PIC  X(001).*/
        public StringBasis V0HIST_IDSEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-OPCOBERT     PIC  X(001).*/
        public StringBasis V0HIST_OPCOBERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-NRAPOLICE    PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-OCOREND      PIC S9(004)    COMP.*/
        public IntBasis V0HIST_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-AGECOBR      PIC S9(004)    COMP.*/
        public IntBasis V0HIST_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-FONTE        PIC S9(004)    COMP.*/
        public IntBasis V0HIST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0SUBG-COD-CLIENTE  PIC S9(009)    COMP.*/
        public IntBasis V0SUBG_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0SUBG-OCOREND      PIC S9(004)    COMP.*/
        public IntBasis V0SUBG_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0SUBG-IND-IOF      PIC  X(001).*/
        public StringBasis V0SUBG_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0RELA-NRCOPIAS     PIC S9(004)    COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0OPCP-PERIPGTO     PIC S9(004)    COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CLIE-NOME-RAZAO   PIC  X(040).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0CLIE-CNPJ         PIC S9(015)    COMP-3.*/
        public IntBasis V0CLIE_CNPJ { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0CLIE-NOME-RAZAO-E PIC  X(040).*/
        public StringBasis V0CLIE_NOME_RAZAO_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0CLIE-CNPJ-E       PIC S9(015)    COMP-3.*/
        public IntBasis V0CLIE_CNPJ_E { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0ENDE-ENDERECO     PIC  X(072).*/
        public StringBasis V0ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0ENDE-BAIRRO       PIC  X(072).*/
        public StringBasis V0ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0ENDE-CIDADE       PIC  X(072).*/
        public StringBasis V0ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0ENDE-UF           PIC  X(002).*/
        public StringBasis V0ENDE_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V0ENDE-CEP          PIC S9(009)    COMP.*/
        public IntBasis V0ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0ENDE-ENDERECO-E   PIC  X(040).*/
        public StringBasis V0ENDE_ENDERECO_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0ENDE-BAIRRO-E     PIC  X(020).*/
        public StringBasis V0ENDE_BAIRRO_E { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-CIDADE-E     PIC  X(020).*/
        public StringBasis V0ENDE_CIDADE_E { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-UF-E         PIC  X(002).*/
        public StringBasis V0ENDE_UF_E { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V0ENDE-CEP-E        PIC S9(009)    COMP.*/
        public IntBasis V0ENDE_CEP_E { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V1MCEF-COD-FONTE    PIC S9(004)    COMP.*/
        public IntBasis V1MCEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1ACEF-COD-AGENCIA  PIC S9(004)    COMP.*/
        public IntBasis V1ACEF_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1FONT-NOMEFTE      PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V1FONT-ENDERFTE     PIC  X(040).*/
        public StringBasis V1FONT_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V1FONT-BAIRRO       PIC  X(020).*/
        public StringBasis V1FONT_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V1FONT-CIDADE       PIC  X(020).*/
        public StringBasis V1FONT_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V1FONT-UF           PIC  X(002).*/
        public StringBasis V1FONT_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V1FONT-CEP          PIC S9(009)    COMP.*/
        public IntBasis V1FONT_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            VIND-COD-PRODUTO    PIC S9(004)    COMP.*/
        public IntBasis VIND_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  AREA-DE-WORK.*/
        public VG4267B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG4267B_AREA_DE_WORK();
        public class VG4267B_AREA_DE_WORK : VarBasis
        {
            /*"    05            LC01-LINHA01.*/
            public VG4267B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new VG4267B_LC01_LINHA01();
            public class VG4267B_LC01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(002) VALUE '%!'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
                /*"    05            LC02-LINHA02.*/
            }
            public VG4267B_LC02_LINHA02 LC02_LINHA02 { get; set; } = new VG4267B_LC02_LINHA02();
            public class VG4267B_LC02_LINHA02 : VarBasis
            {
                /*"      10          LC02-FILLER          PIC X(070) VALUE    '%%DocumentMedia: papel1 595 842 75 white normal'.*/
                public StringBasis LC02_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%DocumentMedia: papel1 595 842 75 white normal");
                /*"    05            LC03-LINHA03.*/
            }
            public VG4267B_LC03_LINHA03 LC03_LINHA03 { get; set; } = new VG4267B_LC03_LINHA03();
            public class VG4267B_LC03_LINHA03 : VarBasis
            {
                /*"      10          LC03-FILLER          PIC X(070) VALUE    '%%+papel2 595 842 75 blue azul'.*/
                public StringBasis LC03_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%+papel2 595 842 75 blue azul");
                /*"    05            LC04-LINHA04.*/
            }
            public VG4267B_LC04_LINHA04 LC04_LINHA04 { get; set; } = new VG4267B_LC04_LINHA04();
            public class VG4267B_LC04_LINHA04 : VarBasis
            {
                /*"      10          LC04-FILLER          PIC X(070) VALUE    '%%XRXrequeriments: duplex'.*/
                public StringBasis LC04_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%XRXrequeriments: duplex");
                /*"    05            LC04-LINHA04-01.*/
            }
            public VG4267B_LC04_LINHA04_01 LC04_LINHA04_01 { get; set; } = new VG4267B_LC04_LINHA04_01();
            public class VG4267B_LC04_LINHA04_01 : VarBasis
            {
                /*"      10          LC04-FILLER-01       PIC X(070) VALUE    '%%XRXrequeriments: simplex'.*/
                public StringBasis LC04_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%XRXrequeriments: simplex");
                /*"    05            LC05-LINHA05.*/
            }
            public VG4267B_LC05_LINHA05 LC05_LINHA05 { get; set; } = new VG4267B_LC05_LINHA05();
            public class VG4267B_LC05_LINHA05 : VarBasis
            {
                /*"      10          LC05-FILLER          PIC X(070) VALUE    '%%BeginFeature: *Duplex True'.*/
                public StringBasis LC05_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%BeginFeature: *Duplex True");
                /*"    05            LC05-LINHA05-01.*/
            }
            public VG4267B_LC05_LINHA05_01 LC05_LINHA05_01 { get; set; } = new VG4267B_LC05_LINHA05_01();
            public class VG4267B_LC05_LINHA05_01 : VarBasis
            {
                /*"      10          LC05-FILLER-01       PIC X(070) VALUE    '%%BeginFeature: *Simplex True'.*/
                public StringBasis LC05_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%BeginFeature: *Simplex True");
                /*"    05            LC06-LINHA06.*/
            }
            public VG4267B_LC06_LINHA06 LC06_LINHA06 { get; set; } = new VG4267B_LC06_LINHA06();
            public class VG4267B_LC06_LINHA06 : VarBasis
            {
                /*"      10          LC06-FILLER          PIC X(070) VALUE    '<</Duplex true>> setpagedevice'.*/
                public StringBasis LC06_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"<</Duplex true>> setpagedevice");
                /*"    05            LC06-LINHA06-01.*/
            }
            public VG4267B_LC06_LINHA06_01 LC06_LINHA06_01 { get; set; } = new VG4267B_LC06_LINHA06_01();
            public class VG4267B_LC06_LINHA06_01 : VarBasis
            {
                /*"      10          LC06-FILLER-01       PIC X(070) VALUE    '<</Simplex true>> setpagedevice'.*/
                public StringBasis LC06_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"<</Simplex true>> setpagedevice");
                /*"    05            LC07-LINHA07.*/
            }
            public VG4267B_LC07_LINHA07 LC07_LINHA07 { get; set; } = new VG4267B_LC07_LINHA07();
            public class VG4267B_LC07_LINHA07 : VarBasis
            {
                /*"      10          LC07-FILLER          PIC X(070) VALUE    '%%EndFeature'.*/
                public StringBasis LC07_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EndFeature");
                /*"    05            LC08-LINHA08.*/
            }
            public VG4267B_LC08_LINHA08 LC08_LINHA08 { get; set; } = new VG4267B_LC08_LINHA08();
            public class VG4267B_LC08_LINHA08 : VarBasis
            {
                /*"      10          LC08-FILLER          PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05            LC09-LINHA09.*/
            }
            public VG4267B_LC09_LINHA09 LC09_LINHA09 { get; set; } = new VG4267B_LC09_LINHA09();
            public class VG4267B_LC09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LC09-FORM.*/
                public VG4267B_LC09_FORM LC09_FORM { get; set; } = new VG4267B_LC09_FORM();
                public class VG4267B_LC09_FORM : VarBasis
                {
                    /*"        15        LC09-JDE             PIC X(008).*/
                    public StringBasis LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            LC10-LINHA10.*/
            }
            public VG4267B_LC10_LINHA10 LC10_LINHA10 { get; set; } = new VG4267B_LC10_LINHA10();
            public class VG4267B_LC10_LINHA10 : VarBasis
            {
                /*"       10         FILLER              PIC X(008) VALUE      'PRODUTO|'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PRODUTO|");
                /*"       10         FILLER              PIC X(051) VALUE      'AGENCIA|APOLICE|ENDOSSO|FATURA|PERIODO|EMISSAO|VENC'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"AGENCIA|APOLICE|ENDOSSO|FATURA|PERIODO|EMISSAO|VENC");
                /*"       10         FILLER              PIC X(051) VALUE      'IMENT|ESTIPULANTE|ENDERE1|CEP1|CIDADE1|EST1|CNPJ1|S'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"IMENT|ESTIPULANTE|ENDERE1|CEP1|CIDADE1|EST1|CNPJ1|S");
                /*"       10         FILLER              PIC X(036) VALUE      'UBESTIPULANTE|ENDERE2|CEP2|CIDADE2|E'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"UBESTIPULANTE|ENDERE2|CEP2|CIDADE2|E");
                /*"       10         FILLER              PIC X(051) VALUE      'ST2|CNPJ2|NVIDAS|CAPITAL|IOF|PREMIO|TEXTO|CODDOC|CO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ST2|CNPJ2|NVIDAS|CAPITAL|IOF|PREMIO|TEXTO|CODDOC|CO");
                /*"       10         FILLER              PIC X(051) VALUE      'DCEDENTE|DATAVENC|PARCELA|VALOR|NUMCDBARRA|DTVENCTO'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"DCEDENTE|DATAVENC|PARCELA|VALOR|NUMCDBARRA|DTVENCTO");
                /*"       10         FILLER              PIC X(051) VALUE      '|NCEDENTE|CEDENTE|DTDOCTO|NUMDOCTO|DTPROCESS|NSNUME'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"|NCEDENTE|CEDENTE|DTDOCTO|NUMDOCTO|DTPROCESS|NSNUME");
                /*"       10         FILLER              PIC X(051) VALUE      'RO|VALDOCTO|MENSA1|MENSA2|MENSA3|MENSA4|MENSA5|MENS'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"RO|VALDOCTO|MENSA1|MENSA2|MENSA3|MENSA4|MENSA5|MENS");
                /*"       10         FILLER              PIC X(051) VALUE      'A6|MENSA7|VALCOBRADO|CODBARRA|SUBSCRITOR|CGCCPFSUB|'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"A6|MENSA7|VALCOBRADO|CODBARRA|SUBSCRITOR|CGCCPFSUB|");
                /*"       10         FILLER              PIC X(019) VALUE      'DTPOSTAGEM|NUMOBJET'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DTPOSTAGEM|NUMOBJET");
                /*"       10         FILLER              PIC X(051) VALUE      'O|DESTINATARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETE'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"O|DESTINATARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETE");
                /*"       10         FILLER              PIC X(051) VALUE      'NTE|REMET-ENDERECO|REMET-BAIRRO|REMET-CIDADE|REMET-'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NTE|REMET_ENDERECO|REMET_BAIRRO|REMET_CIDADE|REMET_");
                /*"       10         FILLER              PIC X(051) VALUE      'UF|REMET-CEP|CODIGO-CIF|POSTNET                    '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"UF|REMET_CEP|CODIGO_CIF|POSTNET                    ");
                /*"    05            LC11-LINHA11.*/
            }
            public VG4267B_LC11_LINHA11 LC11_LINHA11 { get; set; } = new VG4267B_LC11_LINHA11();
            public class VG4267B_LC11_LINHA11 : VarBasis
            {
                /*"       10         LC11-PRODUTO        PIC 9999.*/
                public IntBasis LC11_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-AGENCIA        PIC 9999.*/
                public IntBasis LC11_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-APOLICE        PIC ZZZZZZZZZZZZZ.*/
                public StringBasis LC11_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDOSSO        PIC X(009) VALUE '*-*-*-*'*/
                public StringBasis LC11_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"*-*-*-*");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-FATURA-SEC     PIC 9(004).*/
                public IntBasis LC11_FATURA_SEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         LC11-FATURA-MES     PIC 9(002).*/
                public IntBasis LC11_FATURA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-PERIODO-1-DD   PIC 9(002).*/
                public IntBasis LC11_PERIODO_1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-PERIODO-1-MM   PIC 9(002).*/
                public IntBasis LC11_PERIODO_1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-PERIODO-1-AA   PIC 9(004).*/
                public IntBasis LC11_PERIODO_1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(003) VALUE ' A '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"       10         LC11-PERIODO-2-DD   PIC 9(002).*/
                public IntBasis LC11_PERIODO_2_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-PERIODO-2-MM   PIC 9(002).*/
                public IntBasis LC11_PERIODO_2_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-PERIODO-2-AA   PIC 9(004).*/
                public IntBasis LC11_PERIODO_2_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTEMISSAO      PIC X(010).*/
                public StringBasis LC11_DTEMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVENCTO       PIC X(010).*/
                public StringBasis LC11_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-EST PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO_EST { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO-EST   PIC X(040).*/
                public StringBasis LC11_ENDERECO_EST { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP1-EST       PIC 9(005).*/
                public IntBasis LC11_CEP1_EST { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP2-EST       PIC 9(003).*/
                public IntBasis LC11_CEP2_EST { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-EST     PIC X(020).*/
                public StringBasis LC11_CIDADE_EST { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-EST         PIC X(002).*/
                public StringBasis LC11_UF_EST { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CNPJ1-EST      PIC 999.999.999.*/
                public IntBasis LC11_CNPJ1_EST { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-CNPJ2-EST      PIC 9(004).*/
                public IntBasis LC11_CNPJ2_EST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CNPJ3-EST      PIC 9(002).*/
                public IntBasis LC11_CNPJ3_EST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CODSUBES       PIC Z9999.*/
                public IntBasis LC11_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "Z9999."));
                /*"       10         FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"       10         LC02-NOME-RAZAO     PIC X(032).*/
                public StringBasis LC02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "32", "X(032)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO-SUB   PIC X(040).*/
                public StringBasis LC11_ENDERECO_SUB { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP1-SUB       PIC 9(005).*/
                public IntBasis LC11_CEP1_SUB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP2-SUB       PIC 9(003).*/
                public IntBasis LC11_CEP2_SUB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-SUB     PIC X(020).*/
                public StringBasis LC11_CIDADE_SUB { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-SUB         PIC X(002).*/
                public StringBasis LC11_UF_SUB { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC02-NRCNPJ1        PIC 999.999.999.*/
                public IntBasis LC02_NRCNPJ1 { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC02-NRCNPJ2        PIC 9(004).*/
                public IntBasis LC02_NRCNPJ2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC02-DVCNPJ         PIC 9(002).*/
                public IntBasis LC02_DVCNPJ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NVIDAS         PIC ZZZ.ZZZ.*/
                public StringBasis LC11_NVIDAS { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ.ZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CAPITAL        PIC ZZZ.ZZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis LC11_CAPITAL { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ.ZZZ.ZZZ.ZZZVZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-IOF            PIC Z.ZZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis LC11_IOF { get; set; } = new StringBasis(new PIC("X", "0", "Z.ZZZ.ZZZ.ZZZVZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-VLPRMTOT       PIC Z.ZZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis LC11_VLPRMTOT { get; set; } = new StringBasis(new PIC("X", "0", "Z.ZZZ.ZZZ.ZZZVZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-TEXTO          PIC X(002) VALUE '  '.*/
                public StringBasis LC11_TEXTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"  ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-NRTIT          PIC ZZZZZZZZZZZ99.*/
                public IntBasis LC03_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZ99."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC03-DVTITULO       PIC 9(001).*/
                public IntBasis LC03_DVTITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-AGECTACED      PIC 9(004).*/
                public IntBasis LC03_AGECTACED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         LC03-PONTO1         PIC X(001) VALUE '.'.*/
                public StringBasis LC03_PONTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"       10         LC03-OPRCTACED      PIC 9(003).*/
                public IntBasis LC03_OPRCTACED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10         LC03-PONTO2         PIC X(001) VALUE '.'.*/
                public StringBasis LC03_PONTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"       10         LC03-NUMCTACED      PIC 9(008).*/
                public IntBasis LC03_NUMCTACED { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10         LC03-TRACO          PIC X(001) VALUE '-'.*/
                public StringBasis LC03_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC03-DIGCTACED      PIC 9(001).*/
                public IntBasis LC03_DIGCTACED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-DTVENCTO       PIC X(010).*/
                public StringBasis LC03_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-NRPARCEL       PIC ZZ99.*/
                public IntBasis LC03_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-VLPRMTOT       PIC Z.ZZZ.ZZ9,99.*/
                public DoubleBasis LC03_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC06-CAMPO1.*/
                public VG4267B_LC06_CAMPO1 LC06_CAMPO1 { get; set; } = new VG4267B_LC06_CAMPO1();
                public class VG4267B_LC06_CAMPO1 : VarBasis
                {
                    /*"         15       LC06-BANCO          PIC 9(003) VALUE ZEROS.*/
                    public IntBasis LC06_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                    /*"         15       LC06-MOEDA          PIC 9(001) VALUE ZEROS.*/
                    public IntBasis LC06_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"         15       LC06-NSNRO-1        PIC 9(001) VALUE ZEROS.*/
                    public IntBasis LC06_NSNRO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"         15       FILLER              PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"         15       LC06-NSNRO-2        PIC 9(004) VALUE ZEROS.*/
                    public IntBasis LC06_NSNRO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"         15       LC06-DAC-1          PIC 9(001) VALUE ZEROS.*/
                    public IntBasis LC06_DAC_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"         15       FILLER              PIC X(001) VALUE SPACE.*/
                    public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"       10         LC06-CAMPO2.*/
                }
                public VG4267B_LC06_CAMPO2 LC06_CAMPO2 { get; set; } = new VG4267B_LC06_CAMPO2();
                public class VG4267B_LC06_CAMPO2 : VarBasis
                {
                    /*"         15       LC06-NSNRO-3        PIC 9(005) VALUE ZEROS.*/
                    public IntBasis LC06_NSNRO_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                    /*"         15       FILLER              PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"         15       LC06-CDCED-1        PIC 9(005) VALUE ZEROS.*/
                    public IntBasis LC06_CDCED_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                    /*"         15       LC06-DAC-2          PIC 9(001) VALUE ZEROS.*/
                    public IntBasis LC06_DAC_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"         15       FILLER              PIC X(001) VALUE SPACE.*/
                    public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"       10         LC06-CAMPO3.*/
                }
                public VG4267B_LC06_CAMPO3 LC06_CAMPO3 { get; set; } = new VG4267B_LC06_CAMPO3();
                public class VG4267B_LC06_CAMPO3 : VarBasis
                {
                    /*"         15       LC06-CDCED-2        PIC 9(005) VALUE ZEROS.*/
                    public IntBasis LC06_CDCED_2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                    /*"         15       FILLER              PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"         15       LC06-CDCED-3        PIC 9(005) VALUE ZEROS.*/
                    public IntBasis LC06_CDCED_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                    /*"         15       LC06-DAC-3          PIC 9(001) VALUE ZEROS.*/
                    public IntBasis LC06_DAC_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"         15       FILLER              PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"       10         LC06-CAMPO4.*/
                }
                public VG4267B_LC06_CAMPO4 LC06_CAMPO4 { get; set; } = new VG4267B_LC06_CAMPO4();
                public class VG4267B_LC06_CAMPO4 : VarBasis
                {
                    /*"         15       LC06-DIGITO         PIC 9(001) VALUE ZEROS.*/
                    public IntBasis LC06_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"         15       FILLER              PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"       10         LC06-CAMPO5.*/
                }
                public VG4267B_LC06_CAMPO5 LC06_CAMPO5 { get; set; } = new VG4267B_LC06_CAMPO5();
                public class VG4267B_LC06_CAMPO5 : VarBasis
                {
                    /*"         15       LC06-FATOR-DT-VENC  PIC 9(004) VALUE ZEROS.*/
                    public IntBasis LC06_FATOR_DT_VENC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"         15       LC06-VALOR          PIC X(010) VALUE SPACES.*/
                    public StringBasis LC06_VALOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"         15       LC06-VALORR1 REDEFINES  LC06-VALOR.*/
                    private _REDEF_VG4267B_LC06_VALORR1 _lc06_valorr1 { get; set; }
                    public _REDEF_VG4267B_LC06_VALORR1 LC06_VALORR1
                    {
                        get { _lc06_valorr1 = new _REDEF_VG4267B_LC06_VALORR1(); _.Move(LC06_VALOR, _lc06_valorr1); VarBasis.RedefinePassValue(LC06_VALOR, _lc06_valorr1, LC06_VALOR); _lc06_valorr1.ValueChanged += () => { _.Move(_lc06_valorr1, LC06_VALOR); }; return _lc06_valorr1; }
                        set { VarBasis.RedefinePassValue(value, _lc06_valorr1, LC06_VALOR); }
                    }  //Redefines
                    public class _REDEF_VG4267B_LC06_VALORR1 : VarBasis
                    {
                        /*"           20     LC06-VALOR-Z        PIC ZZZZZZZZZZ.*/
                        public StringBasis LC06_VALOR_Z { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZ."), @"");
                        /*"         15       LC06-VALORR2 REDEFINES  LC06-VALOR.*/

                        public _REDEF_VG4267B_LC06_VALORR1()
                        {
                            LC06_VALOR_Z.ValueChanged += OnValueChanged;
                        }

                    }
                    private _REDEF_VG4267B_LC06_VALORR2 _lc06_valorr2 { get; set; }
                    public _REDEF_VG4267B_LC06_VALORR2 LC06_VALORR2
                    {
                        get { _lc06_valorr2 = new _REDEF_VG4267B_LC06_VALORR2(); _.Move(LC06_VALOR, _lc06_valorr2); VarBasis.RedefinePassValue(LC06_VALOR, _lc06_valorr2, LC06_VALOR); _lc06_valorr2.ValueChanged += () => { _.Move(_lc06_valorr2, LC06_VALOR); }; return _lc06_valorr2; }
                        set { VarBasis.RedefinePassValue(value, _lc06_valorr2, LC06_VALOR); }
                    }  //Redefines
                    public class _REDEF_VG4267B_LC06_VALORR2 : VarBasis
                    {
                        /*"           20     LC06-VALOR-9        PIC 9(010).*/
                        public IntBasis LC06_VALOR_9 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                        /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                        public _REDEF_VG4267B_LC06_VALORR2()
                        {
                            LC06_VALOR_9.ValueChanged += OnValueChanged;
                        }

                    }
                }
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC07-DTVENCTO       PIC X(010).*/
                public StringBasis LC07_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC08-NOMECED        PIC X(040).*/
                public StringBasis LC08_NOMECED { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC08-AGECTACED      PIC 9(004).*/
                public IntBasis LC08_AGECTACED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         LC08-PONTO1         PIC X(001) VALUE '.'.*/
                public StringBasis LC08_PONTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"       10         LC08-OPRCTACED      PIC 9(003).*/
                public IntBasis LC08_OPRCTACED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10         LC08-PONTO2         PIC X(001) VALUE '.'.*/
                public StringBasis LC08_PONTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"       10         LC08-NUMCTACED      PIC 9(008).*/
                public IntBasis LC08_NUMCTACED { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10         LC08-TRACO          PIC X(001) VALUE '-'.*/
                public StringBasis LC08_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC08-DIGCTACED      PIC 9(001).*/
                public IntBasis LC08_DIGCTACED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC09-DTEMISSAO      PIC X(010).*/
                public StringBasis LC09_DTEMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC09-NRTIT          PIC ZZZZZZZZZZZ99.*/
                public IntBasis LC09_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZ99."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC09-DVTITULO       PIC 9(001).*/
                public IntBasis LC09_DVTITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC09-DTPROCES       PIC X(010).*/
                public StringBasis LC09_DTPROCES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC09-NRTIT1         PIC ZZZZZZZZZZZ99.*/
                public IntBasis LC09_NRTIT1 { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZ99."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC09-DVTITULO1      PIC 9(001).*/
                public IntBasis LC09_DVTITULO1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC10-VLPRMTOT       PIC Z.ZZZ.ZZ9,99.*/
                public DoubleBasis LC10_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA1              PIC X(009) VALUE                                      'APOLICE: '.*/
                public StringBasis MENSA1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"APOLICE: ");
                /*"       10         LC11-NUM-APOLICE    PIC 9(013).*/
                public IntBasis LC11_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10         FILLER              PIC X(011) VALUE                                      ' SUBGRUPO: '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SUBGRUPO: ");
                /*"       10         LC11-COD-SUBGRUPO   PIC Z9999.*/
                public IntBasis LC11_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "Z9999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA2              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA3              PIC X(013) VALUE                                      'CERTIFICADO: '.*/
                public StringBasis MENSA3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"CERTIFICADO: ");
                /*"       10         LC13-NRCERTIF       PIC ZZZZZZZZZZZZ99.*/
                public IntBasis LC13_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "ZZZZZZZZZZZZ99."));
                /*"       10         LC13-DVCERTIF       PIC 9(001).*/
                public IntBasis LC13_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(010) VALUE                                      ' PARCELA: '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PARCELA: ");
                /*"       10         LC13-NRPARCEL       PIC ZZ99.*/
                public IntBasis LC13_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA4              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA5              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA6              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA7              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-VALCOBRADO     PIC X(001) VALUE ' '.*/
                public StringBasis LC11_VALCOBRADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC16-CDBARRA        PIC X(112).*/
                public StringBasis LC16_CDBARRA { get; set; } = new StringBasis(new PIC("X", "112", "X(112)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC14-NOME-RAZAO     PIC X(040).*/
                public StringBasis LC14_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC14-NRCNPJ1        PIC 999.999.999.*/
                public IntBasis LC14_NRCNPJ1 { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC14-NRCNPJ2        PIC 9999.*/
                public IntBasis LC14_NRCNPJ2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC14-DVCNPJ         PIC 99.*/
                public IntBasis LC14_DVCNPJ { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE01-DTPOSTAGEM     PIC X(010).*/
                public StringBasis LE01_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE01-SEQUENCIA      PIC X(007).*/
                public StringBasis LE01_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE02-NOME-RAZAO     PIC X(040).*/
                public StringBasis LE02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE03-ENDERECO       PIC X(072).*/
                public StringBasis LE03_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-BAIRRO         PIC X(072).*/
                public StringBasis LE04_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-CIDADE         PIC X(072).*/
                public StringBasis LE04_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-UF             PIC X(002).*/
                public StringBasis LE04_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE05-CEP            PIC 99999.*/
                public IntBasis LE05_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LE05-CEP-COMPL      PIC 999.*/
                public IntBasis LE05_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         FILLER              PIC X(014) VALUE                 'CAIXA SEGUROS '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CAIXA SEGUROS ");
                /*"       10         LE06-REMETENTE-G.*/
                public VG4267B_LE06_REMETENTE_G LE06_REMETENTE_G { get; set; } = new VG4267B_LE06_REMETENTE_G();
                public class VG4267B_LE06_REMETENTE_G : VarBasis
                {
                    /*"         15       LE06-REMETENTE-S    PIC X(007).*/
                    public StringBasis LE06_REMETENTE_S { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"         15       LE06-REMETENTE      PIC X(024).*/
                    public StringBasis LE06_REMETENTE { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                }
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE07-ENDERECO       PIC X(040).*/
                public StringBasis LE07_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-BAIRRO         PIC X(020).*/
                public StringBasis LE08_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-CIDADE         PIC X(020).*/
                public StringBasis LE08_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-UF             PIC X(002).*/
                public StringBasis LE08_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-CEP            PIC 99999.*/
                public IntBasis LE09_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LE09-CEP-COMPL      PIC 999.*/
                public IntBasis LE09_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-CIF            PIC X(034) VALUE ALL '@'.*/
                public StringBasis LE09_CIF { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"ALL");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-POSTNET        PIC X(011) VALUE ALL '#'.*/
                public StringBasis LE09_POSTNET { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"ALL");
                /*"    05            LC12-LINHA12.*/
            }
            public VG4267B_LC12_LINHA12 LC12_LINHA12 { get; set; } = new VG4267B_LC12_LINHA12();
            public class VG4267B_LC12_LINHA12 : VarBasis
            {
                /*"      10          LC12-FILLER          PIC X(070) VALUE    '%%EOF'.*/
                public StringBasis LC12_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EOF");
                /*"    05            LF01-LINHA01.*/
            }
            public VG4267B_LF01_LINHA01 LF01_LINHA01 { get; set; } = new VG4267B_LF01_LINHA01();
            public class VG4267B_LF01_LINHA01 : VarBasis
            {
                /*"      10          FILLER              PIC X(055) VALUE     '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>");
                /*"      10          FILLER              PIC X(080) VALUE     'setpagedevice'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"setpagedevice");
                /*"    05            LF02-LINHA02.*/
            }
            public VG4267B_LF02_LINHA02 LF02_LINHA02 { get; set; } = new VG4267B_LF02_LINHA02();
            public class VG4267B_LF02_LINHA02 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LF02-FORM.*/
                public VG4267B_LF02_FORM LF02_FORM { get; set; } = new VG4267B_LF02_FORM();
                public class VG4267B_LF02_FORM : VarBasis
                {
                    /*"        15        LF02-JDE             PIC X(004).*/
                    public StringBasis LF02_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            LF03-LINHA03.*/
            }
            public VG4267B_LF03_LINHA03 LF03_LINHA03 { get; set; } = new VG4267B_LF03_LINHA03();
            public class VG4267B_LF03_LINHA03 : VarBasis
            {
                /*"      10          FILLER               PIC X(070) VALUE     'LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA");
                /*"    05            LF04-LINHA04.*/
            }
            public VG4267B_LF04_LINHA04 LF04_LINHA04 { get; set; } = new VG4267B_LF04_LINHA04();
            public class VG4267B_LF04_LINHA04 : VarBasis
            {
                /*"      10          LF02-NOME-FAIXA     PIC X(072).*/
                public StringBasis LF02_NOME_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF03-FAIXA1         PIC X(005).*/
                public StringBasis LF03_FAIXA1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LF03-FAIXA1C        PIC X(003).*/
                public StringBasis LF03_FAIXA1C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC X(005) VALUE '  A '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A ");
                /*"      10          LF03-FAIXA2         PIC X(005).*/
                public StringBasis LF03_FAIXA2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LF03-FAIXA2C        PIC X(003).*/
                public StringBasis LF03_FAIXA2C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF04-QTD-OBJ        PIC 9(003).*/
                public IntBasis LF04_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF05-AMARRADO       PIC ZZZ.999.*/
                public IntBasis LF05_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF05-SEQ-INICIAL    PIC ZZZ.999.*/
                public IntBasis LF05_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LF05-SEQ-FINAL      PIC ZZZ.999.*/
                public IntBasis LF05_SEQ_FINAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    05            LR01-LINHA01.*/
            }
            public VG4267B_LR01_LINHA01 LR01_LINHA01 { get; set; } = new VG4267B_LR01_LINHA01();
            public class VG4267B_LR01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '1'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05            LR02-LINHA02.*/
            }
            public VG4267B_LR02_LINHA02 LR02_LINHA02 { get; set; } = new VG4267B_LR02_LINHA02();
            public class VG4267B_LR02_LINHA02 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LR02-FORM.*/
                public VG4267B_LR02_FORM LR02_FORM { get; set; } = new VG4267B_LR02_FORM();
                public class VG4267B_LR02_FORM : VarBasis
                {
                    /*"        15        LR02-JDE             PIC X(004) VALUE 'CO05'.*/
                    public StringBasis LR02_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"CO05");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'JDT'.*/
                    public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"JDT");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE     'STARTLM'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTLM");
                /*"    05            LR03-LINHA03.*/
            }
            public VG4267B_LR03_LINHA03 LR03_LINHA03 { get; set; } = new VG4267B_LR03_LINHA03();
            public class VG4267B_LR03_LINHA03 : VarBasis
            {
                /*"      10          LR03-CONTRATO-ECT    PIC X(030) VALUE     '     100134700-5'.*/
                public StringBasis LR03_CONTRATO_ECT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     100134700-5");
                /*"    05            LR04-LINHA04.*/
            }
            public VG4267B_LR04_LINHA04 LR04_LINHA04 { get; set; } = new VG4267B_LR04_LINHA04();
            public class VG4267B_LR04_LINHA04 : VarBasis
            {
                /*"      10          LR04-USUARIO         PIC X(030) VALUE     '     CAIXA SEGUROS'.*/
                public StringBasis LR04_USUARIO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     CAIXA SEGUROS");
                /*"    05            LR05-LINHA05.*/
            }
            public VG4267B_LR05_LINHA05 LR05_LINHA05 { get; set; } = new VG4267B_LR05_LINHA05();
            public class VG4267B_LR05_LINHA05 : VarBasis
            {
                /*"      10          LR05-ENDERECO        PIC X(070) VALUE     '     SCN Q1 BLOCO A - ED. NUMBER ONE - 13 ANDAR'.*/
                public StringBasis LR05_ENDERECO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"     SCN Q1 BLOCO A - ED. NUMBER ONE - 13 ANDAR");
                /*"    05            LR06-LINHA06.*/
            }
            public VG4267B_LR06_LINHA06 LR06_LINHA06 { get; set; } = new VG4267B_LR06_LINHA06();
            public class VG4267B_LR06_LINHA06 : VarBasis
            {
                /*"      10          LR06-UNID-POSTAGEM   PIC X(030) VALUE     '     DR/BSB/BSA'.*/
                public StringBasis LR06_UNID_POSTAGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     DR/BSB/BSA");
                /*"    05            LR07-LINHA07.*/
            }
            public VG4267B_LR07_LINHA07 LR07_LINHA07 { get; set; } = new VG4267B_LR07_LINHA07();
            public class VG4267B_LR07_LINHA07 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR02-SEQ             PIC ZZ.ZZ9.*/
                public IntBasis LR02_SEQ { get; set; } = new IntBasis(new PIC("9", "5", "ZZ.ZZ9."));
                /*"      10          FILLER               PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LR02-MES             PIC X(012).*/
                public StringBasis LR02_MES { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"    05            LR08-LINHA08.*/
            }
            public VG4267B_LR08_LINHA08 LR08_LINHA08 { get; set; } = new VG4267B_LR08_LINHA08();
            public class VG4267B_LR08_LINHA08 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR08-TIPO.*/
                public VG4267B_LR08_TIPO LR08_TIPO { get; set; } = new VG4267B_LR08_TIPO();
                public class VG4267B_LR08_TIPO : VarBasis
                {
                    /*"        15        LR08-COD-PRODUTO     PIC 9(004).*/
                    public IntBasis LR08_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15        FILLER               PIC X(001) VALUE '-'.*/
                    public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"        15        LR08-NOME-PRODUTO    PIC X(030).*/
                    public StringBasis LR08_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"    05            LR09-LINHA09.*/
                }
            }
            public VG4267B_LR09_LINHA09 LR09_LINHA09 { get; set; } = new VG4267B_LR09_LINHA09();
            public class VG4267B_LR09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR04-DATA            PIC X(010).*/
                public StringBasis LR04_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05            LR10-LINHA10-A.*/
            }
            public VG4267B_LR10_LINHA10_A LR10_LINHA10_A { get; set; } = new VG4267B_LR10_LINHA10_A();
            public class VG4267B_LR10_LINHA10_A : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR10-NUCLEO          PIC X(030) VALUE                 'BRASILIA(DF)'.*/
                public StringBasis LR10_NUCLEO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"BRASILIA(DF)");
                /*"    05            LR10-LINHA10.*/
            }
            public VG4267B_LR10_LINHA10 LR10_LINHA10 { get; set; } = new VG4267B_LR10_LINHA10();
            public class VG4267B_LR10_LINHA10 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR02-PAGINA          PIC 9(003).*/
                public IntBasis LR02_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER               PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LR02-PAG-FINAL       PIC 9(003).*/
                public IntBasis LR02_PAG_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            LR11-LINHA11.*/
            }
            public VG4267B_LR11_LINHA11 LR11_LINHA11 { get; set; } = new VG4267B_LR11_LINHA11();
            public class VG4267B_LR11_LINHA11 : VarBasis
            {
                /*"      10          FILLER              PIC X(101) VALUE SPACES.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "101", "X(101)"), @"");
                /*"      10          LR11-GEPES          PIC X(008) VALUE                                                'GEPES - '.*/
                public StringBasis LR11_GEPES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
                /*"      10          LR03-TP-PGTO        PIC X(022) VALUE SPACES.*/
                public StringBasis LR03_TP_PGTO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05            LR12-LINHA12.*/
            }
            public VG4267B_LR12_LINHA12 LR12_LINHA12 { get; set; } = new VG4267B_LR12_LINHA12();
            public class VG4267B_LR12_LINHA12 : VarBasis
            {
                /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          LR05-CEPI           PIC 9(005).*/
                public IntBasis LR05_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LR05-COMPL-CEPI     PIC 9(003).*/
                public IntBasis LR05_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LR05-CEPF           PIC 9(005).*/
                public IntBasis LR05_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LR05-COMPL-CEPF     PIC 9(003).*/
                public IntBasis LR05_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LR05-OBJI           PIC ZZZ.999.*/
                public IntBasis LR05_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-OBJF           PIC ZZZ.999.*/
                public IntBasis LR05_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR05-AMARI          PIC ZZZ.999.*/
                public IntBasis LR05_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-AMARF          PIC ZZZ.999.*/
                public IntBasis LR05_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR05-QTD-OBJ        PIC ZZZ.999.*/
                public IntBasis LR05_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-QTD-AMAR       PIC ZZZ.999.*/
                public IntBasis LR05_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          LR05-OBS            PIC X(023).*/
                public StringBasis LR05_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LR13-LINHA13.*/
            }
            public VG4267B_LR13_LINHA13 LR13_LINHA13 { get; set; } = new VG4267B_LR13_LINHA13();
            public class VG4267B_LR13_LINHA13 : VarBasis
            {
                /*"      10          FILLER              PIC X(001) VALUE '1'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        WWRK-NSNUMERO       PIC  9(011)    VALUE ZEROS.*/
            }
            public IntBasis WWRK_NSNUMERO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"    05        FILLER              REDEFINES              WWRK-NSNUMERO.*/
            private _REDEF_VG4267B_FILLER_156 _filler_156 { get; set; }
            public _REDEF_VG4267B_FILLER_156 FILLER_156
            {
                get { _filler_156 = new _REDEF_VG4267B_FILLER_156(); _.Move(WWRK_NSNUMERO, _filler_156); VarBasis.RedefinePassValue(WWRK_NSNUMERO, _filler_156, WWRK_NSNUMERO); _filler_156.ValueChanged += () => { _.Move(_filler_156, WWRK_NSNUMERO); }; return _filler_156; }
                set { VarBasis.RedefinePassValue(value, _filler_156, WWRK_NSNUMERO); }
            }  //Redefines
            public class _REDEF_VG4267B_FILLER_156 : VarBasis
            {
                /*"      10      WWRK-NSNRO          PIC  9(010).*/
                public IntBasis WWRK_NSNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10      FILLER              REDEFINES              WWRK-NSNRO.*/
                private _REDEF_VG4267B_FILLER_157 _filler_157 { get; set; }
                public _REDEF_VG4267B_FILLER_157 FILLER_157
                {
                    get { _filler_157 = new _REDEF_VG4267B_FILLER_157(); _.Move(WWRK_NSNRO, _filler_157); VarBasis.RedefinePassValue(WWRK_NSNRO, _filler_157, WWRK_NSNRO); _filler_157.ValueChanged += () => { _.Move(_filler_157, WWRK_NSNRO); }; return _filler_157; }
                    set { VarBasis.RedefinePassValue(value, _filler_157, WWRK_NSNRO); }
                }  //Redefines
                public class _REDEF_VG4267B_FILLER_157 : VarBasis
                {
                    /*"        15    WWRK-NSNRO-1        PIC  9(001).*/
                    public IntBasis WWRK_NSNRO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    WWRK-NSNRO-2        PIC  9(004).*/
                    public IntBasis WWRK_NSNRO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15    WWRK-NSNRO-3        PIC  9(005).*/
                    public IntBasis WWRK_NSNRO_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      10      WWRK-NSNRO-4        PIC  9(001).*/

                    public _REDEF_VG4267B_FILLER_157()
                    {
                        WWRK_NSNRO_1.ValueChanged += OnValueChanged;
                        WWRK_NSNRO_2.ValueChanged += OnValueChanged;
                        WWRK_NSNRO_3.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WWRK_NSNRO_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WK-NUMERO           PIC  9(015)    VALUE  ZEROS.*/

                public _REDEF_VG4267B_FILLER_156()
                {
                    WWRK_NSNRO.ValueChanged += OnValueChanged;
                    FILLER_157.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WK_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05        WK-DIGITO           PIC  9(001)    VALUE  ZEROS.*/
            public IntBasis WK_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05        QUOCIENTE           PIC  9(006)    VALUE  ZEROS.*/
            public IntBasis QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        RESTO               PIC  9(006)    VALUE  ZEROS.*/
            public IntBasis RESTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WPARM01-AUX         PIC S9(009)    VALUE +0 COMP-3*/
            public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        WPARM91-AUX         PIC S9(015)    VALUE +0 COMP-3*/
            public IntBasis WPARM91_AUX { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05        WQUOCIENTE          PIC S9(004)    VALUE +0 COMP-3*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WRESTO              PIC S9(004)    VALUE +0 COMP-3*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        AC-L-PBR0002B       PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_PBR0002B { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WCALCULO            PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WCALCULO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05        FILLER              REDEFINES              WCALCULO.*/
            private _REDEF_VG4267B_FILLER_158 _filler_158 { get; set; }
            public _REDEF_VG4267B_FILLER_158 FILLER_158
            {
                get { _filler_158 = new _REDEF_VG4267B_FILLER_158(); _.Move(WCALCULO, _filler_158); VarBasis.RedefinePassValue(WCALCULO, _filler_158, WCALCULO); _filler_158.ValueChanged += () => { _.Move(_filler_158, WCALCULO); }; return _filler_158; }
                set { VarBasis.RedefinePassValue(value, _filler_158, WCALCULO); }
            }  //Redefines
            public class _REDEF_VG4267B_FILLER_158 : VarBasis
            {
                /*"      10      WCALCUL1            PIC  9(001).*/
                public IntBasis WCALCUL1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      WCALCUL2            PIC  9(001).*/
                public IntBasis WCALCUL2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        W91-NUMERO          PIC  X(043) VALUE ZEROS.*/

                public _REDEF_VG4267B_FILLER_158()
                {
                    WCALCUL1.ValueChanged += OnValueChanged;
                    WCALCUL2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W91_NUMERO { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
            /*"    05        FILLER              REDEFINES              W91-NUMERO.*/
            private _REDEF_VG4267B_FILLER_159 _filler_159 { get; set; }
            public _REDEF_VG4267B_FILLER_159 FILLER_159
            {
                get { _filler_159 = new _REDEF_VG4267B_FILLER_159(); _.Move(W91_NUMERO, _filler_159); VarBasis.RedefinePassValue(W91_NUMERO, _filler_159, W91_NUMERO); _filler_159.ValueChanged += () => { _.Move(_filler_159, W91_NUMERO); }; return _filler_159; }
                set { VarBasis.RedefinePassValue(value, _filler_159, W91_NUMERO); }
            }  //Redefines
            public class _REDEF_VG4267B_FILLER_159 : VarBasis
            {
                /*"      10      W91-BANCO           PIC  9(003).*/
                public IntBasis W91_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      W91-MOEDA           PIC  9(001).*/
                public IntBasis W91_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      W91-VALOR           PIC  9(014).*/
                public IntBasis W91_VALOR { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10      W91-NSNUM           PIC  9(010).*/
                public IntBasis W91_NSNUM { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10      W91-CDCED           PIC  9(015).*/
                public IntBasis W91_CDCED { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    05        W91-DIGITO          PIC  9(001)    VALUE ZEROS.*/

                public _REDEF_VG4267B_FILLER_159()
                {
                    W91_BANCO.ValueChanged += OnValueChanged;
                    W91_MOEDA.ValueChanged += OnValueChanged;
                    W91_VALOR.ValueChanged += OnValueChanged;
                    W91_NSNUM.ValueChanged += OnValueChanged;
                    W91_CDCED.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W91_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05        LPARM01X.*/
            public VG4267B_LPARM01X LPARM01X { get; set; } = new VG4267B_LPARM01X();
            public class VG4267B_LPARM01X : VarBasis
            {
                /*"      10      LPARM01             PIC  9(015).*/
                public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10      LPARM01-R           REDEFINES              LPARM01.*/
                private _REDEF_VG4267B_LPARM01_R _lparm01_r { get; set; }
                public _REDEF_VG4267B_LPARM01_R LPARM01_R
                {
                    get { _lparm01_r = new _REDEF_VG4267B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
                }  //Redefines
                public class _REDEF_VG4267B_LPARM01_R : VarBasis
                {
                    /*"        15    LPARM01-1           PIC  9(001).*/
                    public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-2           PIC  9(001).*/
                    public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-3           PIC  9(001).*/
                    public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-4           PIC  9(001).*/
                    public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-5           PIC  9(001).*/
                    public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-6           PIC  9(001).*/
                    public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-7           PIC  9(001).*/
                    public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-8           PIC  9(001).*/
                    public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-9           PIC  9(001).*/
                    public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-10          PIC  9(001).*/
                    public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-11          PIC  9(001).*/
                    public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-12          PIC  9(001).*/
                    public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-13          PIC  9(001).*/
                    public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-14          PIC  9(001).*/
                    public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-15          PIC  9(001).*/
                    public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05        LPARM02             PIC S9(004) COMP.*/

                    public _REDEF_VG4267B_LPARM01_R()
                    {
                        LPARM01_1.ValueChanged += OnValueChanged;
                        LPARM01_2.ValueChanged += OnValueChanged;
                        LPARM01_3.ValueChanged += OnValueChanged;
                        LPARM01_4.ValueChanged += OnValueChanged;
                        LPARM01_5.ValueChanged += OnValueChanged;
                        LPARM01_6.ValueChanged += OnValueChanged;
                        LPARM01_7.ValueChanged += OnValueChanged;
                        LPARM01_8.ValueChanged += OnValueChanged;
                        LPARM01_9.ValueChanged += OnValueChanged;
                        LPARM01_10.ValueChanged += OnValueChanged;
                        LPARM01_11.ValueChanged += OnValueChanged;
                        LPARM01_12.ValueChanged += OnValueChanged;
                        LPARM01_13.ValueChanged += OnValueChanged;
                        LPARM01_14.ValueChanged += OnValueChanged;
                        LPARM01_15.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        LPARM03             PIC  9(001).*/
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05        LPARM03-R           REDEFINES   LPARM03                                  PIC  X(001).*/
            private _REDEF_StringBasis _lparm03_r { get; set; }
            public _REDEF_StringBasis LPARM03_R
            {
                get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
                set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
            }  //Redefines
            /*"    05        LPARM91X.*/
            public VG4267B_LPARM91X LPARM91X { get; set; } = new VG4267B_LPARM91X();
            public class VG4267B_LPARM91X : VarBasis
            {
                /*"      10      LPARM91             PIC  X(043).*/
                public StringBasis LPARM91 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)."), @"");
                /*"      10      LPARM91-R           REDEFINES              LPARM91.*/
                private _REDEF_VG4267B_LPARM91_R _lparm91_r { get; set; }
                public _REDEF_VG4267B_LPARM91_R LPARM91_R
                {
                    get { _lparm91_r = new _REDEF_VG4267B_LPARM91_R(); _.Move(LPARM91, _lparm91_r); VarBasis.RedefinePassValue(LPARM91, _lparm91_r, LPARM91); _lparm91_r.ValueChanged += () => { _.Move(_lparm91_r, LPARM91); }; return _lparm91_r; }
                    set { VarBasis.RedefinePassValue(value, _lparm91_r, LPARM91); }
                }  //Redefines
                public class _REDEF_VG4267B_LPARM91_R : VarBasis
                {
                    /*"        15    LPARM91-1           PIC  9(001).*/
                    public IntBasis LPARM91_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-2           PIC  9(001).*/
                    public IntBasis LPARM91_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-3           PIC  9(001).*/
                    public IntBasis LPARM91_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-4           PIC  9(001).*/
                    public IntBasis LPARM91_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-5           PIC  9(001).*/
                    public IntBasis LPARM91_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-6           PIC  9(001).*/
                    public IntBasis LPARM91_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-7           PIC  9(001).*/
                    public IntBasis LPARM91_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-8           PIC  9(001).*/
                    public IntBasis LPARM91_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-9           PIC  9(001).*/
                    public IntBasis LPARM91_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-10          PIC  9(001).*/
                    public IntBasis LPARM91_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-11          PIC  9(001).*/
                    public IntBasis LPARM91_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-12          PIC  9(001).*/
                    public IntBasis LPARM91_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-13          PIC  9(001).*/
                    public IntBasis LPARM91_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-14          PIC  9(001).*/
                    public IntBasis LPARM91_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-15          PIC  9(001).*/
                    public IntBasis LPARM91_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-16          PIC  9(001).*/
                    public IntBasis LPARM91_16 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-17          PIC  9(001).*/
                    public IntBasis LPARM91_17 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-18          PIC  9(001).*/
                    public IntBasis LPARM91_18 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-19          PIC  9(001).*/
                    public IntBasis LPARM91_19 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-20          PIC  9(001).*/
                    public IntBasis LPARM91_20 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-21          PIC  9(001).*/
                    public IntBasis LPARM91_21 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-22          PIC  9(001).*/
                    public IntBasis LPARM91_22 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-23          PIC  9(001).*/
                    public IntBasis LPARM91_23 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-24          PIC  9(001).*/
                    public IntBasis LPARM91_24 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-25          PIC  9(001).*/
                    public IntBasis LPARM91_25 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-26          PIC  9(001).*/
                    public IntBasis LPARM91_26 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-27          PIC  9(001).*/
                    public IntBasis LPARM91_27 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-28          PIC  9(001).*/
                    public IntBasis LPARM91_28 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-29          PIC  9(001).*/
                    public IntBasis LPARM91_29 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-30          PIC  9(001).*/
                    public IntBasis LPARM91_30 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-31          PIC  9(001).*/
                    public IntBasis LPARM91_31 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-32          PIC  9(001).*/
                    public IntBasis LPARM91_32 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-33          PIC  9(001).*/
                    public IntBasis LPARM91_33 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-34          PIC  9(001).*/
                    public IntBasis LPARM91_34 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-35          PIC  9(001).*/
                    public IntBasis LPARM91_35 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-36          PIC  9(001).*/
                    public IntBasis LPARM91_36 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-37          PIC  9(001).*/
                    public IntBasis LPARM91_37 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-38          PIC  9(001).*/
                    public IntBasis LPARM91_38 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-39          PIC  9(001).*/
                    public IntBasis LPARM91_39 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-40          PIC  9(001).*/
                    public IntBasis LPARM91_40 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-41          PIC  9(001).*/
                    public IntBasis LPARM91_41 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-42          PIC  9(001).*/
                    public IntBasis LPARM91_42 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-43          PIC  9(001).*/
                    public IntBasis LPARM91_43 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      10      LPARM92             PIC S9(004) COMP.*/

                    public _REDEF_VG4267B_LPARM91_R()
                    {
                        LPARM91_1.ValueChanged += OnValueChanged;
                        LPARM91_2.ValueChanged += OnValueChanged;
                        LPARM91_3.ValueChanged += OnValueChanged;
                        LPARM91_4.ValueChanged += OnValueChanged;
                        LPARM91_5.ValueChanged += OnValueChanged;
                        LPARM91_6.ValueChanged += OnValueChanged;
                        LPARM91_7.ValueChanged += OnValueChanged;
                        LPARM91_8.ValueChanged += OnValueChanged;
                        LPARM91_9.ValueChanged += OnValueChanged;
                        LPARM91_10.ValueChanged += OnValueChanged;
                        LPARM91_11.ValueChanged += OnValueChanged;
                        LPARM91_12.ValueChanged += OnValueChanged;
                        LPARM91_13.ValueChanged += OnValueChanged;
                        LPARM91_14.ValueChanged += OnValueChanged;
                        LPARM91_15.ValueChanged += OnValueChanged;
                        LPARM91_16.ValueChanged += OnValueChanged;
                        LPARM91_17.ValueChanged += OnValueChanged;
                        LPARM91_18.ValueChanged += OnValueChanged;
                        LPARM91_19.ValueChanged += OnValueChanged;
                        LPARM91_20.ValueChanged += OnValueChanged;
                        LPARM91_21.ValueChanged += OnValueChanged;
                        LPARM91_22.ValueChanged += OnValueChanged;
                        LPARM91_23.ValueChanged += OnValueChanged;
                        LPARM91_24.ValueChanged += OnValueChanged;
                        LPARM91_25.ValueChanged += OnValueChanged;
                        LPARM91_26.ValueChanged += OnValueChanged;
                        LPARM91_27.ValueChanged += OnValueChanged;
                        LPARM91_28.ValueChanged += OnValueChanged;
                        LPARM91_29.ValueChanged += OnValueChanged;
                        LPARM91_30.ValueChanged += OnValueChanged;
                        LPARM91_31.ValueChanged += OnValueChanged;
                        LPARM91_32.ValueChanged += OnValueChanged;
                        LPARM91_33.ValueChanged += OnValueChanged;
                        LPARM91_34.ValueChanged += OnValueChanged;
                        LPARM91_35.ValueChanged += OnValueChanged;
                        LPARM91_36.ValueChanged += OnValueChanged;
                        LPARM91_37.ValueChanged += OnValueChanged;
                        LPARM91_38.ValueChanged += OnValueChanged;
                        LPARM91_39.ValueChanged += OnValueChanged;
                        LPARM91_40.ValueChanged += OnValueChanged;
                        LPARM91_41.ValueChanged += OnValueChanged;
                        LPARM91_42.ValueChanged += OnValueChanged;
                        LPARM91_43.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LPARM92 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10      LPARM93             PIC  9(001).*/
                public IntBasis LPARM93 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      LPARM93-R           REDEFINES   LPARM93                                  PIC  X(001).*/
                private _REDEF_StringBasis _lparm93_r { get; set; }
                public _REDEF_StringBasis LPARM93_R
                {
                    get { _lparm93_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM93, _lparm93_r); VarBasis.RedefinePassValue(LPARM93, _lparm93_r, LPARM93); _lparm93_r.ValueChanged += () => { _.Move(_lparm93_r, LPARM93); }; return _lparm93_r; }
                    set { VarBasis.RedefinePassValue(value, _lparm93_r, LPARM93); }
                }  //Redefines
                /*"    05        WWRK-NRTIT          PIC  9(011)    VALUE ZEROS.*/
            }
            public IntBasis WWRK_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"    05        FILLER              REDEFINES              WWRK-NRTIT.*/
            private _REDEF_VG4267B_FILLER_160 _filler_160 { get; set; }
            public _REDEF_VG4267B_FILLER_160 FILLER_160
            {
                get { _filler_160 = new _REDEF_VG4267B_FILLER_160(); _.Move(WWRK_NRTIT, _filler_160); VarBasis.RedefinePassValue(WWRK_NRTIT, _filler_160, WWRK_NRTIT); _filler_160.ValueChanged += () => { _.Move(_filler_160, WWRK_NRTIT); }; return _filler_160; }
                set { VarBasis.RedefinePassValue(value, _filler_160, WWRK_NRTIT); }
            }  //Redefines
            public class _REDEF_VG4267B_FILLER_160 : VarBasis
            {
                /*"      10      WWRK-NRTIT-NRO      PIC  9(009).*/
                public IntBasis WWRK_NRTIT_NRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10      WWRK-NRTIT-DG1      PIC  9(001).*/
                public IntBasis WWRK_NRTIT_DG1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      WWRK-NRTIT-DG2      PIC  9(001).*/
                public IntBasis WWRK_NRTIT_DG2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WWRK-AGEOPE-CED     PIC  9(005)    VALUE ZEROS.*/

                public _REDEF_VG4267B_FILLER_160()
                {
                    WWRK_NRTIT_NRO.ValueChanged += OnValueChanged;
                    WWRK_NRTIT_DG1.ValueChanged += OnValueChanged;
                    WWRK_NRTIT_DG2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWRK_AGEOPE_CED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        FILLER              REDEFINES              WWRK-AGEOPE-CED.*/
            private _REDEF_VG4267B_FILLER_161 _filler_161 { get; set; }
            public _REDEF_VG4267B_FILLER_161 FILLER_161
            {
                get { _filler_161 = new _REDEF_VG4267B_FILLER_161(); _.Move(WWRK_AGEOPE_CED, _filler_161); VarBasis.RedefinePassValue(WWRK_AGEOPE_CED, _filler_161, WWRK_AGEOPE_CED); _filler_161.ValueChanged += () => { _.Move(_filler_161, WWRK_AGEOPE_CED); }; return _filler_161; }
                set { VarBasis.RedefinePassValue(value, _filler_161, WWRK_AGEOPE_CED); }
            }  //Redefines
            public class _REDEF_VG4267B_FILLER_161 : VarBasis
            {
                /*"      10      WWRK-CDAGE          PIC  9(004).*/
                public IntBasis WWRK_CDAGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WWRK-OPE            PIC  9(001).*/
                public IntBasis WWRK_OPE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WWRK-OPE-CED        PIC  9(003)    VALUE ZEROS.*/

                public _REDEF_VG4267B_FILLER_161()
                {
                    WWRK_CDAGE.ValueChanged += OnValueChanged;
                    WWRK_OPE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWRK_OPE_CED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05        FILLER              REDEFINES              WWRK-OPE-CED.*/
            private _REDEF_VG4267B_FILLER_162 _filler_162 { get; set; }
            public _REDEF_VG4267B_FILLER_162 FILLER_162
            {
                get { _filler_162 = new _REDEF_VG4267B_FILLER_162(); _.Move(WWRK_OPE_CED, _filler_162); VarBasis.RedefinePassValue(WWRK_OPE_CED, _filler_162, WWRK_OPE_CED); _filler_162.ValueChanged += () => { _.Move(_filler_162, WWRK_OPE_CED); }; return _filler_162; }
                set { VarBasis.RedefinePassValue(value, _filler_162, WWRK_OPE_CED); }
            }  //Redefines
            public class _REDEF_VG4267B_FILLER_162 : VarBasis
            {
                /*"      10      WWRK-OPE1           PIC  9(001).*/
                public IntBasis WWRK_OPE1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      WWRK-OPE2           PIC  9(002).*/
                public IntBasis WWRK_OPE2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WWRK-CAMPO3         PIC  9(010)    VALUE ZEROS.*/

                public _REDEF_VG4267B_FILLER_162()
                {
                    WWRK_OPE1.ValueChanged += OnValueChanged;
                    WWRK_OPE2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWRK_CAMPO3 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05        FILLER              REDEFINES              WWRK-CAMPO3.*/
            private _REDEF_VG4267B_FILLER_163 _filler_163 { get; set; }
            public _REDEF_VG4267B_FILLER_163 FILLER_163
            {
                get { _filler_163 = new _REDEF_VG4267B_FILLER_163(); _.Move(WWRK_CAMPO3, _filler_163); VarBasis.RedefinePassValue(WWRK_CAMPO3, _filler_163, WWRK_CAMPO3); _filler_163.ValueChanged += () => { _.Move(_filler_163, WWRK_CAMPO3); }; return _filler_163; }
                set { VarBasis.RedefinePassValue(value, _filler_163, WWRK_CAMPO3); }
            }  //Redefines
            public class _REDEF_VG4267B_FILLER_163 : VarBasis
            {
                /*"      10      WWRK-2UOPE          PIC  9(002).*/
                public IntBasis WWRK_2UOPE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WWRK-NCTCD          PIC  9(008).*/
                public IntBasis WWRK_NCTCD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05        WWRK-VALOR-FMT      PIC  9(012)V9(002) VALUE ZEROS*/

                public _REDEF_VG4267B_FILLER_163()
                {
                    WWRK_2UOPE.ValueChanged += OnValueChanged;
                    WWRK_NCTCD.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WWRK_VALOR_FMT { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V9(002)"), 2);
            /*"    05        WWRK-VALOR          REDEFINES              WWRK-VALOR-FMT      PIC  9(014).*/
            private _REDEF_IntBasis _wwrk_valor { get; set; }
            public _REDEF_IntBasis WWRK_VALOR
            {
                get { _wwrk_valor = new _REDEF_IntBasis(new PIC("9", "014", "9(014).")); ; _.Move(WWRK_VALOR_FMT, _wwrk_valor); VarBasis.RedefinePassValue(WWRK_VALOR_FMT, _wwrk_valor, WWRK_VALOR_FMT); _wwrk_valor.ValueChanged += () => { _.Move(_wwrk_valor, WWRK_VALOR_FMT); }; return _wwrk_valor; }
                set { VarBasis.RedefinePassValue(value, _wwrk_valor, WWRK_VALOR_FMT); }
            }  //Redefines
            /*"    05        WBAR-AREA.*/
            public VG4267B_WBAR_AREA WBAR_AREA { get; set; } = new VG4267B_WBAR_AREA();
            public class VG4267B_WBAR_AREA : VarBasis
            {
                /*"      10      WBAR-CAMPO-1        PIC  9(009)    VALUE ZEROS.*/
                public IntBasis WBAR_CAMPO_1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-1.*/
                private _REDEF_VG4267B_FILLER_164 _filler_164 { get; set; }
                public _REDEF_VG4267B_FILLER_164 FILLER_164
                {
                    get { _filler_164 = new _REDEF_VG4267B_FILLER_164(); _.Move(WBAR_CAMPO_1, _filler_164); VarBasis.RedefinePassValue(WBAR_CAMPO_1, _filler_164, WBAR_CAMPO_1); _filler_164.ValueChanged += () => { _.Move(_filler_164, WBAR_CAMPO_1); }; return _filler_164; }
                    set { VarBasis.RedefinePassValue(value, _filler_164, WBAR_CAMPO_1); }
                }  //Redefines
                public class _REDEF_VG4267B_FILLER_164 : VarBasis
                {
                    /*"        15    WBAR-BANCO          PIC  9(003).*/
                    public IntBasis WBAR_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"        15    WBAR-MOEDA          PIC  9(001).*/
                    public IntBasis WBAR_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    WBAR-NSNRO-1        PIC  9(001).*/
                    public IntBasis WBAR_NSNRO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    WBAR-NSNRO-2        PIC  9(004).*/
                    public IntBasis WBAR_NSNRO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      WBAR-DAC-1          PIC  9(001)    VALUE ZEROS.*/

                    public _REDEF_VG4267B_FILLER_164()
                    {
                        WBAR_BANCO.ValueChanged += OnValueChanged;
                        WBAR_MOEDA.ValueChanged += OnValueChanged;
                        WBAR_NSNRO_1.ValueChanged += OnValueChanged;
                        WBAR_NSNRO_2.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WBAR_DAC_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"      10      WBAR-CAMPO-2        PIC  9(010)    VALUE ZEROS.*/
                public IntBasis WBAR_CAMPO_2 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-2.*/
                private _REDEF_VG4267B_FILLER_165 _filler_165 { get; set; }
                public _REDEF_VG4267B_FILLER_165 FILLER_165
                {
                    get { _filler_165 = new _REDEF_VG4267B_FILLER_165(); _.Move(WBAR_CAMPO_2, _filler_165); VarBasis.RedefinePassValue(WBAR_CAMPO_2, _filler_165, WBAR_CAMPO_2); _filler_165.ValueChanged += () => { _.Move(_filler_165, WBAR_CAMPO_2); }; return _filler_165; }
                    set { VarBasis.RedefinePassValue(value, _filler_165, WBAR_CAMPO_2); }
                }  //Redefines
                public class _REDEF_VG4267B_FILLER_165 : VarBasis
                {
                    /*"        15    WBAR-NSNRO-3        PIC  9(005).*/
                    public IntBasis WBAR_NSNRO_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"        15    WBAR-CDCED-1        PIC  9(005).*/
                    public IntBasis WBAR_CDCED_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      10      WBAR-DAC-2          PIC  9(001).*/

                    public _REDEF_VG4267B_FILLER_165()
                    {
                        WBAR_NSNRO_3.ValueChanged += OnValueChanged;
                        WBAR_CDCED_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WBAR_DAC_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      WBAR-CAMPO-3        PIC  9(010)    VALUE ZEROS.*/
                public IntBasis WBAR_CAMPO_3 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-3.*/
                private _REDEF_VG4267B_FILLER_166 _filler_166 { get; set; }
                public _REDEF_VG4267B_FILLER_166 FILLER_166
                {
                    get { _filler_166 = new _REDEF_VG4267B_FILLER_166(); _.Move(WBAR_CAMPO_3, _filler_166); VarBasis.RedefinePassValue(WBAR_CAMPO_3, _filler_166, WBAR_CAMPO_3); _filler_166.ValueChanged += () => { _.Move(_filler_166, WBAR_CAMPO_3); }; return _filler_166; }
                    set { VarBasis.RedefinePassValue(value, _filler_166, WBAR_CAMPO_3); }
                }  //Redefines
                public class _REDEF_VG4267B_FILLER_166 : VarBasis
                {
                    /*"        15    WBAR-CDCED-2        PIC  9(005).*/
                    public IntBasis WBAR_CDCED_2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"        15    WBAR-CDCED-3        PIC  9(005).*/
                    public IntBasis WBAR_CDCED_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      10      WBAR-DAC-3          PIC  9(001)    VALUE ZEROS.*/

                    public _REDEF_VG4267B_FILLER_166()
                    {
                        WBAR_CDCED_2.ValueChanged += OnValueChanged;
                        WBAR_CDCED_3.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WBAR_DAC_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"      10      WBAR-CAMPO-4        PIC  9(001)    VALUE ZEROS.*/
                public IntBasis WBAR_CAMPO_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-4.*/
                private _REDEF_VG4267B_FILLER_167 _filler_167 { get; set; }
                public _REDEF_VG4267B_FILLER_167 FILLER_167
                {
                    get { _filler_167 = new _REDEF_VG4267B_FILLER_167(); _.Move(WBAR_CAMPO_4, _filler_167); VarBasis.RedefinePassValue(WBAR_CAMPO_4, _filler_167, WBAR_CAMPO_4); _filler_167.ValueChanged += () => { _.Move(_filler_167, WBAR_CAMPO_4); }; return _filler_167; }
                    set { VarBasis.RedefinePassValue(value, _filler_167, WBAR_CAMPO_4); }
                }  //Redefines
                public class _REDEF_VG4267B_FILLER_167 : VarBasis
                {
                    /*"        15    WBAR-DIGITO         PIC  9(001).*/
                    public IntBasis WBAR_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      10      WBAR-CAMPO-5        PIC  9(012)V99 VALUE ZEROS.*/

                    public _REDEF_VG4267B_FILLER_167()
                    {
                        WBAR_DIGITO.ValueChanged += OnValueChanged;
                    }

                }
                public DoubleBasis WBAR_CAMPO_5 { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-5.*/
                private _REDEF_VG4267B_FILLER_168 _filler_168 { get; set; }
                public _REDEF_VG4267B_FILLER_168 FILLER_168
                {
                    get { _filler_168 = new _REDEF_VG4267B_FILLER_168(); _.Move(WBAR_CAMPO_5, _filler_168); VarBasis.RedefinePassValue(WBAR_CAMPO_5, _filler_168, WBAR_CAMPO_5); _filler_168.ValueChanged += () => { _.Move(_filler_168, WBAR_CAMPO_5); }; return _filler_168; }
                    set { VarBasis.RedefinePassValue(value, _filler_168, WBAR_CAMPO_5); }
                }  //Redefines
                public class _REDEF_VG4267B_FILLER_168 : VarBasis
                {
                    /*"        15    WBAR-VALOR          PIC  9(014).*/
                    public IntBasis WBAR_VALOR { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"    05        WWRK-CEDENTE        PIC  9(015)    VALUE ZEROS.*/

                    public _REDEF_VG4267B_FILLER_168()
                    {
                        WBAR_VALOR.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis WWRK_CEDENTE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05        FILLER              REDEFINES      WWRK-CEDENTE.*/
            private _REDEF_VG4267B_FILLER_169 _filler_169 { get; set; }
            public _REDEF_VG4267B_FILLER_169 FILLER_169
            {
                get { _filler_169 = new _REDEF_VG4267B_FILLER_169(); _.Move(WWRK_CEDENTE, _filler_169); VarBasis.RedefinePassValue(WWRK_CEDENTE, _filler_169, WWRK_CEDENTE); _filler_169.ValueChanged += () => { _.Move(_filler_169, WWRK_CEDENTE); }; return _filler_169; }
                set { VarBasis.RedefinePassValue(value, _filler_169, WWRK_CEDENTE); }
            }  //Redefines
            public class _REDEF_VG4267B_FILLER_169 : VarBasis
            {
                /*"      10      WWRK-CDCED-1        PIC  9(004).*/
                public IntBasis WWRK_CDCED_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WWRK-CDCED-2        PIC  9(003).*/
                public IntBasis WWRK_CDCED_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WWRK-CDCED-3        PIC  9(008).*/
                public IntBasis WWRK_CDCED_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05        WSL-SQLCODE         PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_VG4267B_FILLER_169()
                {
                    WWRK_CDCED_1.ValueChanged += OnValueChanged;
                    WWRK_CDCED_2.ValueChanged += OnValueChanged;
                    WWRK_CDCED_3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-LINHAS           PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"    05        WWORK-QTDE01.*/
            public VG4267B_WWORK_QTDE01 WWORK_QTDE01 { get; set; } = new VG4267B_WWORK_QTDE01();
            public class VG4267B_WWORK_QTDE01 : VarBasis
            {
                /*"       10     WWORK-QTDE11        PIC  9(004).*/
                public IntBasis WWORK_QTDE11 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10     WWORK-QTDE12        PIC  9(002).*/
                public IntBasis WWORK_QTDE12 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WWORK-QTDE  REDEFINES  WWORK-QTDE01                                  PIC S9(004)V99.*/
            }
            private _REDEF_DoubleBasis _wwork_qtde { get; set; }
            public _REDEF_DoubleBasis WWORK_QTDE
            {
                get { _wwork_qtde = new _REDEF_DoubleBasis(new PIC("S9", "004", "S9(004)V99."), 2); ; _.Move(WWORK_QTDE01, _wwork_qtde); VarBasis.RedefinePassValue(WWORK_QTDE01, _wwork_qtde, WWORK_QTDE01); _wwork_qtde.ValueChanged += () => { _.Move(_wwork_qtde, WWORK_QTDE01); }; return _wwork_qtde; }
                set { VarBasis.RedefinePassValue(value, _wwork_qtde, WWORK_QTDE01); }
            }  //Redefines
            /*"    05        AC-PAGINA           PIC  9(003)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05        AC-CONTA1           PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-CONTA-910        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA_910 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-I-RELATORIOS     PIC S9(005)    COMP-3 VALUE +0*/
            public IntBasis AC_I_RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05        WS-IMPMORACID       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-IMPMORESPO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORESPO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPRMTOT         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPREMIO         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLMULTA          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-OCORR            PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_OCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-AMARRADO         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ-INICIAL      PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTD-OBJ          PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTROLE         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-AMAR       PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-OBJ        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-200        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_200 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-PRODU      PIC  X(001).*/
            public StringBasis WS_CONTR_PRODU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-NUM-APOLICE-ANT  PIC  9(013).*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-CODSUBES-ANT     PIC  9(005).*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-JDE-GER          PIC  X(008).*/
            public StringBasis WS_JDE_GER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-JDE-ANT          PIC  X(006).*/
            public StringBasis WS_JDE_ANT { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05        WS-PRODU-ANT        PIC  9(004).*/
            public IntBasis WS_PRODU_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        WS-CEP-G-ANT        PIC  9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        WS-CEP-G-IX-ANT     PIC  9(006).*/
            public IntBasis WS_CEP_G_IX_ANT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05        WS-NOME-COR-ANT.*/
            public VG4267B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VG4267B_WS_NOME_COR_ANT();
            public class VG4267B_WS_NOME_COR_ANT : VarBasis
            {
                /*"      10      WS-FAIXA1-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-FAIXA2-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-NOME-ANT         PIC  X(030).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05        WS-CEP-ANT          PIC  9(005).*/
            }
            public IntBasis WS_CEP_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-COMPL-ANT        PIC  9(003).*/
            public IntBasis WS_COMPL_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05        WS-INF              PIC  9(009).*/
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-SUP              PIC  9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-IND              PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WIND                PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WIND1               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDM               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDH               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        IDX-IND2            PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis IDX_IND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        INF                 PIC S9(009)    COMP.*/
            public IntBasis INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        SUP                 PIC S9(009)    COMP.*/
            public IntBasis SUP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        DEST-NUM-CEP.*/
            public VG4267B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VG4267B_DEST_NUM_CEP();
            public class VG4267B_DEST_NUM_CEP : VarBasis
            {
                /*"      15      DEST-CEP            PIC  9(005)    VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      15      DEST-CEP-COMPL      PIC  9(003)    VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05        WS-CNPJ             PIC  9(015).*/
            }
            public IntBasis WS_CNPJ { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CNPJ-R           REDEFINES              WS-CNPJ.*/
            private _REDEF_VG4267B_WS_CNPJ_R _ws_cnpj_r { get; set; }
            public _REDEF_VG4267B_WS_CNPJ_R WS_CNPJ_R
            {
                get { _ws_cnpj_r = new _REDEF_VG4267B_WS_CNPJ_R(); _.Move(WS_CNPJ, _ws_cnpj_r); VarBasis.RedefinePassValue(WS_CNPJ, _ws_cnpj_r, WS_CNPJ); _ws_cnpj_r.ValueChanged += () => { _.Move(_ws_cnpj_r, WS_CNPJ); }; return _ws_cnpj_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cnpj_r, WS_CNPJ); }
            }  //Redefines
            public class _REDEF_VG4267B_WS_CNPJ_R : VarBasis
            {
                /*"      10      WS-NRCNPJ1          PIC  9(009).*/
                public IntBasis WS_NRCNPJ1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10      WS-NRCNPJ2          PIC  9(004).*/
                public IntBasis WS_NRCNPJ2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WS-DVCNPJ           PIC  9(002).*/
                public IntBasis WS_DVCNPJ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA-SQL.*/

                public _REDEF_VG4267B_WS_CNPJ_R()
                {
                    WS_NRCNPJ1.ValueChanged += OnValueChanged;
                    WS_NRCNPJ2.ValueChanged += OnValueChanged;
                    WS_DVCNPJ.ValueChanged += OnValueChanged;
                }

            }
            public VG4267B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG4267B_WS_DATA_SQL();
            public class VG4267B_WS_DATA_SQL : VarBasis
            {
                /*"      10      WS-ANO-SQL          PIC  9(004).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-DATA1.*/
            }
            public VG4267B_WS_DATA1 WS_DATA1 { get; set; } = new VG4267B_WS_DATA1();
            public class VG4267B_WS_DATA1 : VarBasis
            {
                /*"      10      WS-ANO1             PIC  9(004).*/
                public IntBasis WS_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES1             PIC  9(002).*/
                public IntBasis WS_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA1             PIC  9(002).*/
                public IntBasis WS_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA2.*/
            }
            public VG4267B_WS_DATA2 WS_DATA2 { get; set; } = new VG4267B_WS_DATA2();
            public class VG4267B_WS_DATA2 : VarBasis
            {
                /*"      10      WS-ANO2             PIC  9(004).*/
                public IntBasis WS_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES2             PIC  9(002).*/
                public IntBasis WS_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA2             PIC  9(002).*/
                public IntBasis WS_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA.*/
            }
            public VG4267B_WS_DATA WS_DATA { get; set; } = new VG4267B_WS_DATA();
            public class VG4267B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-DTVENCTO-SQL.*/
            }
            public VG4267B_WS_DTVENCTO_SQL WS_DTVENCTO_SQL { get; set; } = new VG4267B_WS_DTVENCTO_SQL();
            public class VG4267B_WS_DTVENCTO_SQL : VarBasis
            {
                /*"      10      WS-ANO-VCT          PIC  9(004).*/
                public IntBasis WS_ANO_VCT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-VCT          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_VCT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-VCT          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_VCT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-CERTIF           PIC  9(015).*/
            }
            public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CERTIF-R         REDEFINES WS-CERTIF.*/
            private _REDEF_VG4267B_WS_CERTIF_R _ws_certif_r { get; set; }
            public _REDEF_VG4267B_WS_CERTIF_R WS_CERTIF_R
            {
                get { _ws_certif_r = new _REDEF_VG4267B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
            }  //Redefines
            public class _REDEF_VG4267B_WS_CERTIF_R : VarBasis
            {
                /*"      10      WS-NRCERTIF         PIC  9(014).*/
                public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10      WS-DVCERTIF         PIC  9(001).*/
                public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-TITULO           PIC  9(013).*/

                public _REDEF_VG4267B_WS_CERTIF_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                    WS_DVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-TITULO-R         REDEFINES WS-TITULO.*/
            private _REDEF_VG4267B_WS_TITULO_R _ws_titulo_r { get; set; }
            public _REDEF_VG4267B_WS_TITULO_R WS_TITULO_R
            {
                get { _ws_titulo_r = new _REDEF_VG4267B_WS_TITULO_R(); _.Move(WS_TITULO, _ws_titulo_r); VarBasis.RedefinePassValue(WS_TITULO, _ws_titulo_r, WS_TITULO); _ws_titulo_r.ValueChanged += () => { _.Move(_ws_titulo_r, WS_TITULO); }; return _ws_titulo_r; }
                set { VarBasis.RedefinePassValue(value, _ws_titulo_r, WS_TITULO); }
            }  //Redefines
            public class _REDEF_VG4267B_WS_TITULO_R : VarBasis
            {
                /*"      10      WS-NRTIT            PIC  9(012).*/
                public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"      10      WS-DVTITULO         PIC  9(001).*/
                public IntBasis WS_DVTITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-DATA-I.*/

                public _REDEF_VG4267B_WS_TITULO_R()
                {
                    WS_NRTIT.ValueChanged += OnValueChanged;
                    WS_DVTITULO.ValueChanged += OnValueChanged;
                }

            }
            public VG4267B_WS_DATA_I WS_DATA_I { get; set; } = new VG4267B_WS_DATA_I();
            public class VG4267B_WS_DATA_I : VarBasis
            {
                /*"      10      WS-DIA-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB1            PIC  X(001).*/
                public StringBasis FILLERB1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB2            PIC  X(001).*/
                public StringBasis FILLERB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-ANO-I            PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05        WHORA-CURR          PIC  X(008)    VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05        WS-NOME-RAZAO.*/
            public VG4267B_WS_NOME_RAZAO WS_NOME_RAZAO { get; set; } = new VG4267B_WS_NOME_RAZAO();
            public class VG4267B_WS_NOME_RAZAO : VarBasis
            {
                /*"      10      WS-LETRA-NOME       OCCURS 41 TIMES                                  PIC  X(001).*/
                public ListBasis<StringBasis, string> WS_LETRA_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 41);
                /*"    05        WS-NUM-CEP-AUX      PIC  9(008).*/
            }
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-NUM-CEP-AUX-R    REDEFINES              WS-NUM-CEP-AUX.*/
            private _REDEF_VG4267B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_VG4267B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_VG4267B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VG4267B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10      WS-CEP-AUX          PIC  9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CEP-COMPL-AUX    PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        WS-NUM-CEP-AUX-R1   REDEFINES              WS-NUM-CEP-AUX.*/

                public _REDEF_VG4267B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG4267B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_VG4267B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_VG4267B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VG4267B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10      WS-CEP-COMPL-AUX1   PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WS-CEP-AUX1         PIC  9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05        WS-CHAVE            PIC  X(021).*/

                public _REDEF_VG4267B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
            /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
            private _REDEF_VG4267B_WS_CHAVE_R _ws_chave_r { get; set; }
            public _REDEF_VG4267B_WS_CHAVE_R WS_CHAVE_R
            {
                get { _ws_chave_r = new _REDEF_VG4267B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
                set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
            }  //Redefines
            public class _REDEF_VG4267B_WS_CHAVE_R : VarBasis
            {
                /*"      10      WS-NUM-APOLICE      PIC  9(013).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-CODSUBES         PIC  9(005).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CODOPER          PIC  9(003).*/
                public IntBasis WS_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        AC-LIDOS            PIC  9(009)    VALUE ZEROES.*/

                public _REDEF_VG4267B_WS_CHAVE_R()
                {
                    WS_NUM_APOLICE.ValueChanged += OnValueChanged;
                    WS_CODSUBES.ValueChanged += OnValueChanged;
                    WS_CODOPER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-CONTA            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-IMPRESSOS        PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        WINSERE-HEA         PIC  X(003)    VALUE 'SIM'.*/
            public StringBasis WINSERE_HEA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
            /*"    05        WFIM-V1SISTEMA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V1AGENCEF      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0FAIXACEP     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0HISTCOBVA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0MSGCOBR      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0MSGCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0PARCELVA     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0PARCELVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0DIFPARCEL    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0DIFPARCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-SORT           PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-TABELA         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-MULTIMSG       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_MULTIMSG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-PRODUTO        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        LK-PROSOMU1.*/
            public VG4267B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VG4267B_LK_PROSOMU1();
            public class VG4267B_LK_PROSOMU1 : VarBasis
            {
                /*"      10      LK-DATA-SOM         PIC  9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-SOM-R       REDEFINES              LK-DATA-SOM.*/
                private _REDEF_VG4267B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_VG4267B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_VG4267B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_VG4267B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15    LK-DIA-SOM          PIC  9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-SOM          PIC  9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-SOM          PIC  9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      LK-QTDIAS           PIC S9(005)    COMP-3 VALUE +1*/

                    public _REDEF_VG4267B_LK_DATA_SOM_R()
                    {
                        LK_DIA_SOM.ValueChanged += OnValueChanged;
                        LK_MES_SOM.ValueChanged += OnValueChanged;
                        LK_ANO_SOM.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
                /*"      10      LK-DATA-CALC        PIC  9(008).*/
                public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-CALC-R      REDEFINES              LK-DATA-CALC.*/
                private _REDEF_VG4267B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_VG4267B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_VG4267B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_VG4267B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15    LK-DIA-CALC         PIC  9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-CALC         PIC  9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-CALC         PIC  9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"  05          LINK-AREA.*/
                    public VG4267B_LINK_AREA LINK_AREA { get; set; } = new VG4267B_LINK_AREA();
                    public class VG4267B_LINK_AREA : VarBasis
                    {
                        /*"    10        LK-BANCO            PIC  9(003).*/
                    }

                    public _REDEF_VG4267B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                        LINK_AREA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis LK_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10        LK-MOEDA            PIC  9(001).*/
            public IntBasis LK_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    10        LK-DIGITO           PIC  9(001).*/
            public IntBasis LK_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    10        LK-VALOR            PIC  9(012)V99.*/
            public DoubleBasis LK_VALOR { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"    10        LK-NNURO            PIC  9(010).*/
            public IntBasis LK_NNURO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    10        LK-CDCED            PIC  9(015).*/
            public IntBasis LK_CDCED { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10        LK-CODIGO           PIC  X(112).*/
            public StringBasis LK_CODIGO { get; set; } = new StringBasis(new PIC("X", "112", "X(112)."), @"");
            /*"    10        LK-RCCODE           PIC  X(001).*/
            public StringBasis LK_RCCODE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01            TB1-TABELA-FILIAL.*/
        }
        public VG4267B_TB1_TABELA_FILIAL TB1_TABELA_FILIAL { get; set; } = new VG4267B_TB1_TABELA_FILIAL();
        public class VG4267B_TB1_TABELA_FILIAL : VarBasis
        {
            /*"    05        TB1-LIM-OCOR        PIC  9(006) VALUE 19.*/
            public IntBasis TB1_LIM_OCOR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 19);
            /*"    05        TB1-ULT-OCOR        PIC  9(006) VALUE 0.*/
            public IntBasis TB1_ULT_OCOR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        TB1-IX              PIC  9(006) VALUE 0.*/
            public IntBasis TB1_IX { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        TB1-TAB-FILIAL.*/
            public VG4267B_TB1_TAB_FILIAL TB1_TAB_FILIAL { get; set; } = new VG4267B_TB1_TAB_FILIAL();
            public class VG4267B_TB1_TAB_FILIAL : VarBasis
            {
                /*"      10      TB1-FILIAL          OCCURS 19 TIMES.*/
                public ListBasis<VG4267B_TB1_FILIAL> TB1_FILIAL { get; set; } = new ListBasis<VG4267B_TB1_FILIAL>(19);
                public class VG4267B_TB1_FILIAL : VarBasis
                {
                    /*"        15    TB1-FONTE           PIC  9(04).*/
                    public IntBasis TB1_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"        15    TB1-NOMEFTE         PIC  X(40).*/
                    public StringBasis TB1_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                    /*"        15    TB1-ENDERFTE        PIC  X(40).*/
                    public StringBasis TB1_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                    /*"        15    TB1-BAIRRO          PIC  X(20).*/
                    public StringBasis TB1_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"        15    TB1-CIDADE          PIC  X(20).*/
                    public StringBasis TB1_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"        15    TB1-CEP             PIC  9(08).*/
                    public IntBasis TB1_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"        15    TB1-UF              PIC  X(02).*/
                    public StringBasis TB1_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"01            TB2-TABELA-FAIXA-CEP.*/
                }
            }
        }
        public VG4267B_TB2_TABELA_FAIXA_CEP TB2_TABELA_FAIXA_CEP { get; set; } = new VG4267B_TB2_TABELA_FAIXA_CEP();
        public class VG4267B_TB2_TABELA_FAIXA_CEP : VarBasis
        {
            /*"    03        TB2-LIM-OCOR        PIC  9(006) VALUE 2000.*/
            public IntBasis TB2_LIM_OCOR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 2000);
            /*"    03        TB2-ULT-OCOR        PIC  9(006) VALUE 0.*/
            public IntBasis TB2_ULT_OCOR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03        TB2-IX-01           PIC  9(006) VALUE 0.*/
            public IntBasis TB2_IX_01 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03        TB2-IX              PIC  9(006) VALUE 0.*/
            public IntBasis TB2_IX { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03        TB2-TAB-FAIXA-CEP.*/
            public VG4267B_TB2_TAB_FAIXA_CEP TB2_TAB_FAIXA_CEP { get; set; } = new VG4267B_TB2_TAB_FAIXA_CEP();
            public class VG4267B_TB2_TAB_FAIXA_CEP : VarBasis
            {
                /*"      05      TB2-FAIXA-CEP   OCCURS 2000 TIMES.*/
                public ListBasis<VG4267B_TB2_FAIXA_CEP> TB2_FAIXA_CEP { get; set; } = new ListBasis<VG4267B_TB2_FAIXA_CEP>(2000);
                public class VG4267B_TB2_FAIXA_CEP : VarBasis
                {
                    /*"        10    TB2-FX-CEP-G        PIC  9(004).*/
                    public IntBasis TB2_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        10    TB2-FAIXAS.*/
                    public VG4267B_TB2_FAIXAS TB2_FAIXAS { get; set; } = new VG4267B_TB2_FAIXAS();
                    public class VG4267B_TB2_FAIXAS : VarBasis
                    {
                        /*"          15  TB2-FX-INI          PIC  9(008).*/
                        public IntBasis TB2_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                        /*"          15  TB2-FX-FIM          PIC  9(008).*/
                        public IntBasis TB2_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                        /*"          15  TB2-FX-NOME         PIC  X(072).*/
                        public StringBasis TB2_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                        /*"          15  TB2-FX-CENTR        PIC  X(072).*/
                        public StringBasis TB2_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                        /*"01            TB3-TABELA-TOTAIS.*/
                    }
                }
            }
        }
        public VG4267B_TB3_TABELA_TOTAIS TB3_TABELA_TOTAIS { get; set; } = new VG4267B_TB3_TABELA_TOTAIS();
        public class VG4267B_TB3_TABELA_TOTAIS : VarBasis
        {
            /*"    05        TB3-TAB-TOTAIS       OCCURS  2000 TIMES.*/
            public ListBasis<VG4267B_TB3_TAB_TOTAIS> TB3_TAB_TOTAIS { get; set; } = new ListBasis<VG4267B_TB3_TAB_TOTAIS>(2000);
            public class VG4267B_TB3_TAB_TOTAIS : VarBasis
            {
                /*"      10      TB3-OBJI            PIC  9(006).*/
                public IntBasis TB3_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TB3-OBJF            PIC  9(006).*/
                public IntBasis TB3_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TB3-AMARI           PIC  9(006).*/
                public IntBasis TB3_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TB3-AMARF           PIC  9(006).*/
                public IntBasis TB3_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TB3-QTD-OBJ         PIC  9(006).*/
                public IntBasis TB3_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TB3-QTD-AMAR        PIC  9(006).*/
                public IntBasis TB3_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01            TBM-TABELA-MESES.*/
            }
        }
        public VG4267B_TBM_TABELA_MESES TBM_TABELA_MESES { get; set; } = new VG4267B_TBM_TABELA_MESES();
        public class VG4267B_TBM_TABELA_MESES : VarBasis
        {
            /*"    05        TBM-TBM-MESES.*/
            public VG4267B_TBM_TBM_MESES TBM_TBM_MESES { get; set; } = new VG4267B_TBM_TBM_MESES();
            public class VG4267B_TBM_TBM_MESES : VarBasis
            {
                /*"      10      FILLER              PIC  X(009)  VALUE '  JANEIRO'*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE 'FEVEREIRO'*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    MARCO'*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    ABRIL'*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"      10      FILLER              PIC  X(009)  VALUE '     MAIO'*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JUNHO'*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JULHO'*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '   AGOSTO'*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' SETEMBRO'*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '  OUTUBRO'*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' NOVEMBRO'*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' DEZEMBRO'*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"    05        TBM-TBM-MESES-R     REDEFINES              TBM-TBM-MESES.*/
            }
            private _REDEF_VG4267B_TBM_TBM_MESES_R _tbm_tbm_meses_r { get; set; }
            public _REDEF_VG4267B_TBM_TBM_MESES_R TBM_TBM_MESES_R
            {
                get { _tbm_tbm_meses_r = new _REDEF_VG4267B_TBM_TBM_MESES_R(); _.Move(TBM_TBM_MESES, _tbm_tbm_meses_r); VarBasis.RedefinePassValue(TBM_TBM_MESES, _tbm_tbm_meses_r, TBM_TBM_MESES); _tbm_tbm_meses_r.ValueChanged += () => { _.Move(_tbm_tbm_meses_r, TBM_TBM_MESES); }; return _tbm_tbm_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tbm_tbm_meses_r, TBM_TBM_MESES); }
            }  //Redefines
            public class _REDEF_VG4267B_TBM_TBM_MESES_R : VarBasis
            {
                /*"      10      TBM-MES             OCCURS 12 TIMES                                  PIC  X(009).*/
                public ListBasis<StringBasis, string> TBM_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01          PARAGRAFO           PIC  X(050).*/

                public _REDEF_VG4267B_TBM_TBM_MESES_R()
                {
                    TBM_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"01          WABEND.*/
        public VG4267B_WABEND WABEND { get; set; } = new VG4267B_WABEND();
        public class VG4267B_WABEND : VarBasis
        {
            /*"      05    FILLER              PIC  X(010) VALUE           ' VG4267B'.*/
            public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG4267B");
            /*"      05    FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05    WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05    FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.GEOBJECT GEOBJECT { get; set; } = new Dclgens.GEOBJECT();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public VG4267B_CFAIXACEP CFAIXACEP { get; set; } = new VG4267B_CFAIXACEP();
        public VG4267B_V1AGENCEF V1AGENCEF { get; set; } = new VG4267B_V1AGENCEF();
        public VG4267B_CHISTCOB CHISTCOB { get; set; } = new VG4267B_CHISTCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVG4267B_FILE_NAME_P, string SVG4267B_FILE_NAME_P, string FVG4267B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVG4267B.SetFile(RVG4267B_FILE_NAME_P);
                SVG4267B.SetFile(SVG4267B_FILE_NAME_P);
                FVG4267B.SetFile(FVG4267B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1270- MOVE 'R0000-00-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R0000-00-PRINCIPAL", PARAGRAFO);

            /*" -1271- DISPLAY ' ' */
            _.Display($" ");

            /*" -1273- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1281- DISPLAY 'PROGRAMA EM EXECUCAO VG4267B-' 'VERSAO V.27 - DEMANDA 259756 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VG4267B-VERSAO V.27 - DEMANDA 259756 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1283- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1284- DISPLAY ' ' */
            _.Display($" ");

            /*" -1291- DISPLAY 'INICIOU PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1293- DISPLAY ' ' */
            _.Display($" ");

            /*" -1294- MOVE 00 TO W-RETURN-CODE */
            _.Move(00, W_RETURN_CODE);

            /*" -1296- INITIALIZE TB3-TABELA-TOTAIS */
            _.Initialize(
                TB3_TABELA_TOTAIS
            );

            /*" -1298- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1300- INITIALIZE TB1-TAB-FILIAL. */
            _.Initialize(
                TB1_TABELA_FILIAL.TB1_TAB_FILIAL
            );

            /*" -1302- PERFORM R0500-00-DECLARE-V1AGENCEF. */

            R0500_00_DECLARE_V1AGENCEF_SECTION();

            /*" -1304- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

            /*" -1305- IF WFIM-V1AGENCEF NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1AGENCEF.IsEmpty())
            {

                /*" -1306- DISPLAY 'R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -1307- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1309- END-IF */
            }


            /*" -1314- PERFORM R0520-00-CARREGA-FILIAL VARYING TB1-IX FROM 1 BY 1 UNTIL TB1-IX > TB1-LIM-OCOR OR WFIM-V1AGENCEF EQUAL 'S' . */

            for (TB1_TABELA_FILIAL.TB1_IX.Value = 1; !(TB1_TABELA_FILIAL.TB1_IX > TB1_TABELA_FILIAL.TB1_LIM_OCOR || AREA_DE_WORK.WFIM_V1AGENCEF == "S"); TB1_TABELA_FILIAL.TB1_IX.Value += 1)
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1316- PERFORM R0900-00-DECLARE-V0HISTCOBVA. */

            R0900_00_DECLARE_V0HISTCOBVA_SECTION();

            /*" -1318- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

            /*" -1319- IF WFIM-V0HISTCOBVA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V0HISTCOBVA == "S")
            {

                /*" -1320- GO TO R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION(); //GOTO
                return;

                /*" -1322- END-IF */
            }


            /*" -1324- PERFORM R0200-00-CARREGA-V0FAIXACEP. */

            R0200_00_CARREGA_V0FAIXACEP_SECTION();

            /*" -1326- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1334- SORT SVG4267B ON ASCENDING KEY SVA-CODPRODU SVA-CEP-G SVA-NUM-CEP SVA-CODOPER INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SVG4267B.Sort("SVA-CODPRODU,SVA-CEP-G,SVA-NUM-CEP,SVA-CODOPER", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1337- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1338- DISPLAY '*** VG4267B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VG4267B *** PROBLEMAS NO SORT ");

                /*" -1339- DISPLAY '*** VG4267B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VG4267B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1340- MOVE 99 TO W-RETURN-CODE */
                _.Move(99, W_RETURN_CODE);

                /*" -1341- GO TO R9999-00-FINALIZA */

                R9999_00_FINALIZA_SECTION(); //GOTO
                return;

                /*" -1344- END-IF */
            }


            /*" -1344- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1347- DISPLAY ' ' */
            _.Display($" ");

            /*" -1349- DISPLAY '###################################################' '###################################################' */
            _.Display($"######################################################################################################");

            /*" -1350- DISPLAY '*** COMMIT EXECUTADO ***' */
            _.Display($"*** COMMIT EXECUTADO ***");

            /*" -1352- DISPLAY '###################################################' '###################################################' */
            _.Display($"######################################################################################################");

            /*" -1353- MOVE 00 TO W-RETURN-CODE */
            _.Move(00, W_RETURN_CODE);

            /*" -1354- GO TO R9999-00-FINALIZA */

            R9999_00_FINALIZA_SECTION(); //GOTO
            return;

            /*" -1354- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1365- MOVE 'R0010-00-SELECIONA' TO PARAGRAFO. */
            _.Move("R0010-00-SELECIONA", PARAGRAFO);

            /*" -1366- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0HISTCOBVA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0HISTCOBVA == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1378- MOVE 'R0020-00-IMPRIME  ' TO PARAGRAFO. */
            _.Move("R0020-00-IMPRIME  ", PARAGRAFO);

            /*" -1380- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1381- MOVE 'CO03.DBM' TO WS-JDE-GER. */
            _.Move("CO03.DBM", AREA_DE_WORK.WS_JDE_GER);

            /*" -1383- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LF02-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LF02_LINHA02.LF02_FORM);

            /*" -1384- MOVE 'CO05.JDT' TO WS-JDE-GER. */
            _.Move("CO05.JDT", AREA_DE_WORK.WS_JDE_GER);

            /*" -1386- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LR02-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LR02_LINHA02.LR02_FORM);

            /*" -1388- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

            /*" -1389- IF WFIM-SORT NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SORT != "S")
            {

                /*" -1390- WRITE RVG4267B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1391- WRITE RVG4267B-RECORD FROM LC02-LINHA02 */
                _.Move(AREA_DE_WORK.LC02_LINHA02.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1392- WRITE RVG4267B-RECORD FROM LC03-LINHA03 */
                _.Move(AREA_DE_WORK.LC03_LINHA03.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1393- WRITE RVG4267B-RECORD FROM LC04-LINHA04 */
                _.Move(AREA_DE_WORK.LC04_LINHA04.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1394- WRITE RVG4267B-RECORD FROM LC05-LINHA05 */
                _.Move(AREA_DE_WORK.LC05_LINHA05.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1395- WRITE RVG4267B-RECORD FROM LC06-LINHA06 */
                _.Move(AREA_DE_WORK.LC06_LINHA06.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1396- WRITE RVG4267B-RECORD FROM LC07-LINHA07 */
                _.Move(AREA_DE_WORK.LC07_LINHA07.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1397- WRITE FVG4267B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1398- WRITE FVG4267B-RECORD FROM LC02-LINHA02 */
                _.Move(AREA_DE_WORK.LC02_LINHA02.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1399- WRITE FVG4267B-RECORD FROM LC03-LINHA03 */
                _.Move(AREA_DE_WORK.LC03_LINHA03.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1400- WRITE FVG4267B-RECORD FROM LC04-LINHA04-01 */
                _.Move(AREA_DE_WORK.LC04_LINHA04_01.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1401- WRITE FVG4267B-RECORD FROM LC05-LINHA05-01 */
                _.Move(AREA_DE_WORK.LC05_LINHA05_01.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1402- WRITE FVG4267B-RECORD FROM LC06-LINHA06-01 */
                _.Move(AREA_DE_WORK.LC06_LINHA06_01.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1403- WRITE FVG4267B-RECORD FROM LC07-LINHA07 */
                _.Move(AREA_DE_WORK.LC07_LINHA07.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

                /*" -1405- WRITE FVG4267B-RECORD FROM LC08-LINHA08. */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());
            }


            /*" -1408- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -1409- WRITE RVG4267B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -1411- WRITE FVG4267B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -1411- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1423- MOVE 'R0100-00-SELECT-V1' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-V1", PARAGRAFO);

            /*" -1425- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -1437- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1440- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1441- DISPLAY ' ' */
                _.Display($" ");

                /*" -1443- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -1444- DISPLAY 'SISTEMA "FI" NAO CADASTRADO' */

                $"SISTEMA FI NAO CADASTRADO"
                .Display();

                /*" -1446- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -1447- MOVE 99 TO W-RETURN-CODE */
                _.Move(99, W_RETURN_CODE);

                /*" -1448- GO TO R9999-00-FINALIZA */

                R9999_00_FINALIZA_SECTION(); //GOTO
                return;

                /*" -1449- END-IF */
            }


            /*" -1449- . */

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1437- EXEC SQL SELECT DTMOVABE, MONTH(DTMOVABE), YEAR(DTMOVABE), DATE(DTMOVABE) + 15 DAYS INTO :V1SIST-DTMOVABE, :V1SIST-MESREFER, :V1SIST-ANOREFER, :V1SIST-DATA-LIMITE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
                _.Move(executed_1.V1SIST_DATA_LIMITE, V1SIST_DATA_LIMITE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-SECTION */
        private void R0200_00_CARREGA_V0FAIXACEP_SECTION()
        {
            /*" -1460- MOVE 'R0200-00-CARREGA  ' TO PARAGRAFO. */
            _.Move("R0200-00-CARREGA  ", PARAGRAFO);

            /*" -1462- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -1472- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1();

            /*" -1474- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1();

            /*" -1477- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1478- DISPLAY 'VG4267B - PROBLEMAS NA V0FAIXA_CEP' */
                _.Display($"VG4267B - PROBLEMAS NA V0FAIXA_CEP");

                /*" -1479- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1481- END-IF */
            }


            /*" -1487- INITIALIZE WFIM-V0FAIXACEP TB2-ULT-OCOR TB2-IX TB2-IX-01 TB2-TAB-FAIXA-CEP */
            _.Initialize(
                AREA_DE_WORK.WFIM_V0FAIXACEP
                , TB2_TABELA_FAIXA_CEP.TB2_ULT_OCOR
                , TB2_TABELA_FAIXA_CEP.TB2_IX
                , TB2_TABELA_FAIXA_CEP.TB2_IX_01
                , TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP
            );

            /*" -1490- PERFORM R0210-00-FETCH-V0FAIXACEP UNTIL WFIM-V0FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0FAIXACEP == "S"))
            {

                R0210_00_FETCH_V0FAIXACEP_SECTION();
            }

            /*" -1491- IF TB2-ULT-OCOR = 0 */

            if (TB2_TABELA_FAIXA_CEP.TB2_ULT_OCOR == 0)
            {

                /*" -1492- DISPLAY ' ' */
                _.Display($" ");

                /*" -1494- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -1495- DISPLAY 'NENHUMA FAIXA DE CEP CARREGADO NA TABELA INTERNA' */
                _.Display($"NENHUMA FAIXA DE CEP CARREGADO NA TABELA INTERNA");

                /*" -1497- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -1498- MOVE 99 TO W-RETURN-CODE */
                _.Move(99, W_RETURN_CODE);

                /*" -1499- GO TO R9999-00-FINALIZA */

                R9999_00_FINALIZA_SECTION(); //GOTO
                return;

                /*" -1500- END-IF */
            }


            /*" -1500- . */

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1()
        {
            /*" -1472- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :V1SIST-DTMOVABE AND DATA_TERVIGENCIA >= :V1SIST-DTMOVABE ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new VG4267B_CFAIXACEP(true);
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
							WHERE DATA_INIVIGENCIA <= '{V1SIST_DTMOVABE}' 
							AND DATA_TERVIGENCIA >= '{V1SIST_DTMOVABE}' 
							ORDER BY FAIXA";

                return query;
            }
            CFAIXACEP.GetQueryEvent += GetQuery_CFAIXACEP;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-OPEN-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1()
        {
            /*" -1474- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -1584- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT DISTINCT B.COD_FONTE, C.NOMEFTE, C.ENDERFTE, C.BAIRRO, C.CIDADE, C.CEP, C.ESTADO FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B, SEGUROS.V1FONTE C WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND B.COD_FONTE = C.FONTE ORDER BY B.COD_FONTE END-EXEC. */
            V1AGENCEF = new VG4267B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT DISTINCT B.COD_FONTE
							, 
							C.NOMEFTE
							, 
							C.ENDERFTE
							, 
							C.BAIRRO
							, 
							C.CIDADE
							, 
							C.CEP
							, 
							C.ESTADO 
							FROM SEGUROS.V1AGENCIACEF A
							, 
							SEGUROS.V1MALHACEF B
							, 
							SEGUROS.V1FONTE C 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							AND B.COD_FONTE = C.FONTE 
							ORDER BY B.COD_FONTE";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-SECTION */
        private void R0210_00_FETCH_V0FAIXACEP_SECTION()
        {
            /*" -1508- MOVE 'R0210-00-FETCH-V0F' TO PARAGRAFO. */
            _.Move("R0210-00-FETCH-V0F", PARAGRAFO);

            /*" -1510- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", WABEND.WNR_EXEC_SQL);

            /*" -1517- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1();

            /*" -1520- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1521- MOVE 'S' TO WFIM-V0FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_V0FAIXACEP);

                /*" -1523- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1523- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1 */

                R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1();

                /*" -1525- GO TO R0210-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;

                /*" -1527- END-IF */
            }


            /*" -1528- ADD 1 TO TB2-IX */
            TB2_TABELA_FAIXA_CEP.TB2_IX.Value = TB2_TABELA_FAIXA_CEP.TB2_IX + 1;

            /*" -1529- IF TB2-IX > TB2-LIM-OCOR */

            if (TB2_TABELA_FAIXA_CEP.TB2_IX > TB2_TABELA_FAIXA_CEP.TB2_LIM_OCOR)
            {

                /*" -1530- MOVE 'S' TO WFIM-V0FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_V0FAIXACEP);

                /*" -1532- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1533- DISPLAY ' ' */
                _.Display($" ");

                /*" -1535- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -1537- DISPLAY 'TABELA INTERNA <TB2-TABELA-FAIXA-CEP> ESTOUROU ' 'O LIMITE DE <' TB2-LIM-OCOR '> OCORRENCIAS.' */

                $"TABELA INTERNA <TB2-TABELA-FAIXA-CEP> ESTOUROU O LIMITE DE <{TB2_TABELA_FAIXA_CEP.TB2_LIM_OCOR}> OCORRENCIAS."
                .Display();

                /*" -1539- DISPLAY 'INFORMAR AO ANALISTA RESPONSAVEL PARA AUMENTAR ' 'O LIMITE DE OCORRENCIAS DA <TABELA_CEP>' */
                _.Display($"INFORMAR AO ANALISTA RESPONSAVEL PARA AUMENTAR O LIMITE DE OCORRENCIAS DA <TABELA_CEP>");

                /*" -1541- DISPLAY '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@' */
                _.Display($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                /*" -1542- MOVE 99 TO W-RETURN-CODE */
                _.Move(99, W_RETURN_CODE);

                /*" -1543- GO TO R9999-00-FINALIZA */

                R9999_00_FINALIZA_SECTION(); //GOTO
                return;

                /*" -1546- END-IF */
            }


            /*" -1547- IF V0FAIC-FAIXA = 01 */

            if (V0FAIC_FAIXA == 01)
            {

                /*" -1548- MOVE V0FAIC-FAIXA TO TB2-IX-01 */
                _.Move(V0FAIC_FAIXA, TB2_TABELA_FAIXA_CEP.TB2_IX_01);

                /*" -1549- END-IF */
            }


            /*" -1550- MOVE V0FAIC-FAIXA TO TB2-FX-CEP-G(TB2-IX) */
            _.Move(V0FAIC_FAIXA, TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FX_CEP_G);

            /*" -1551- MOVE V0FAIC-CEPINI TO TB2-FX-INI(TB2-IX) */
            _.Move(V0FAIC_CEPINI, TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_INI);

            /*" -1552- MOVE V0FAIC-CEPFIM TO TB2-FX-FIM(TB2-IX) */
            _.Move(V0FAIC_CEPFIM, TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_FIM);

            /*" -1553- MOVE V0FAIC-DESC-FAIXA TO TB2-FX-NOME(TB2-IX) */
            _.Move(V0FAIC_DESC_FAIXA, TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_NOME);

            /*" -1554- MOVE V0FAIC-CENTRALIZA TO TB2-FX-CENTR(TB2-IX) */
            _.Move(V0FAIC_CENTRALIZA, TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_CENTR);

            /*" -1555- MOVE TB2-IX TO TB2-ULT-OCOR */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_IX, TB2_TABELA_FAIXA_CEP.TB2_ULT_OCOR);

            /*" -1555- . */

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1()
        {
            /*" -1517- EXEC SQL FETCH CFAIXACEP INTO :V0FAIC-FAIXA, :V0FAIC-CEPINI, :V0FAIC-CEPFIM, :V0FAIC-DESC-FAIXA, :V0FAIC-CENTRALIZA END-EXEC. */

            if (CFAIXACEP.Fetch())
            {
                _.Move(CFAIXACEP.V0FAIC_FAIXA, V0FAIC_FAIXA);
                _.Move(CFAIXACEP.V0FAIC_CEPINI, V0FAIC_CEPINI);
                _.Move(CFAIXACEP.V0FAIC_CEPFIM, V0FAIC_CEPFIM);
                _.Move(CFAIXACEP.V0FAIC_DESC_FAIXA, V0FAIC_DESC_FAIXA);
                _.Move(CFAIXACEP.V0FAIC_CENTRALIZA, V0FAIC_CENTRALIZA);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1()
        {
            /*" -1523- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-SECTION */
        private void R0500_00_DECLARE_V1AGENCEF_SECTION()
        {
            /*" -1566- MOVE 'R0500-00-DECLARE-V' TO PARAGRAFO. */
            _.Move("R0500-00-DECLARE-V", PARAGRAFO);

            /*" -1568- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1584- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -1586- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -1589- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1590- DISPLAY 'R0500 - PROBLEMAS DECLARE (V1AGENCEF) ..' */
                _.Display($"R0500 - PROBLEMAS DECLARE (V1AGENCEF) ..");

                /*" -1591- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1591- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1()
        {
            /*" -1586- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1()
        {
            /*" -1696- EXEC SQL DECLARE CHISTCOB CURSOR FOR SELECT A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.DTVENCTO, A.VLPRMTOT, A.CODOPER, A.OPCAOPAG, A.NRTITCOMP, B.CODPRODU, B.OCORHIST, B.CODCLIEN, B.IDE_SEXO, B.OPCAO_COBER, B.NUM_APOLICE, B.CODSUBES, B.OCOREND, B.AGECOBR, B.FONTE, B.DTQITBCO, C.DTVENCTO , D.COD_EMPRESA FROM SEGUROS.V0HISTCOBVA A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PARCELVA C , SEGUROS.PRODUTO D WHERE A.SITUACAO = '5' AND A.NRCERTIF = B.NRCERTIF AND A.NRCERTIF = C.NRCERTIF AND A.NRPARCEL = C.NRPARCEL AND B.CODPRODU = 7701 AND B.NUM_APOLICE = 107700000007 AND D.COD_PRODUTO = B.CODPRODU END-EXEC. */
            CHISTCOB = new VG4267B_CHISTCOB(false);
            string GetQuery_CHISTCOB()
            {
                var query = @$"SELECT 
							A.NRCERTIF
							, 
							A.NRPARCEL
							, 
							A.NRTIT
							, 
							A.DTVENCTO
							, 
							A.VLPRMTOT
							, 
							A.CODOPER
							, 
							A.OPCAOPAG
							, 
							A.NRTITCOMP
							, 
							B.CODPRODU
							, 
							B.OCORHIST
							, 
							B.CODCLIEN
							, 
							B.IDE_SEXO
							, 
							B.OPCAO_COBER
							, 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.OCOREND
							, 
							B.AGECOBR
							, 
							B.FONTE
							, 
							B.DTQITBCO
							, 
							C.DTVENCTO 
							, D.COD_EMPRESA 
							FROM SEGUROS.V0HISTCOBVA A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0PARCELVA C 
							, SEGUROS.PRODUTO D 
							WHERE A.SITUACAO = '5' 
							AND A.NRCERTIF = B.NRCERTIF 
							AND A.NRCERTIF = C.NRCERTIF 
							AND A.NRPARCEL = C.NRPARCEL 
							AND B.CODPRODU = 7701 
							AND B.NUM_APOLICE = 107700000007 
							AND D.COD_PRODUTO = B.CODPRODU";

                return query;
            }
            CHISTCOB.GetQueryEvent += GetQuery_CHISTCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-SECTION */
        private void R0510_00_FETCH_V1AGENCEF_SECTION()
        {
            /*" -1603- MOVE 'R0510-00-FETCH-V1A' TO PARAGRAFO. */
            _.Move("R0510-00-FETCH-V1A", PARAGRAFO);

            /*" -1605- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -1614- PERFORM R0510_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            R0510_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -1617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1618- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1619- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_V1AGENCEF);

                    /*" -1619- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -1621- ELSE */
                }
                else
                {


                    /*" -1621- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -1623- DISPLAY 'R0510 - (PROBLEMAS NO FETCH V1AGENCEF) ..' */
                    _.Display($"R0510 - (PROBLEMAS NO FETCH V1AGENCEF) ..");

                    /*" -1624- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1624- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -1614- EXEC SQL FETCH V1AGENCEF INTO :V1MCEF-COD-FONTE, :V1FONT-NOMEFTE, :V1FONT-ENDERFTE, :V1FONT-BAIRRO, :V1FONT-CIDADE, :V1FONT-CEP, :V1FONT-UF END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
                _.Move(V1AGENCEF.V1FONT_NOMEFTE, V1FONT_NOMEFTE);
                _.Move(V1AGENCEF.V1FONT_ENDERFTE, V1FONT_ENDERFTE);
                _.Move(V1AGENCEF.V1FONT_BAIRRO, V1FONT_BAIRRO);
                _.Move(V1AGENCEF.V1FONT_CIDADE, V1FONT_CIDADE);
                _.Move(V1AGENCEF.V1FONT_CEP, V1FONT_CEP);
                _.Move(V1AGENCEF.V1FONT_UF, V1FONT_UF);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1()
        {
            /*" -1619- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -1621- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -1636- MOVE 'R0520-00-CARREGA-F' TO PARAGRAFO. */
            _.Move("R0520-00-CARREGA-F", PARAGRAFO);

            /*" -1638- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -1639- MOVE V1MCEF-COD-FONTE TO TB1-FONTE(TB1-IX) */
            _.Move(V1MCEF_COD_FONTE, TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_FONTE);

            /*" -1640- MOVE V1FONT-NOMEFTE TO TB1-NOMEFTE(TB1-IX) */
            _.Move(V1FONT_NOMEFTE, TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_NOMEFTE);

            /*" -1641- MOVE V1FONT-ENDERFTE TO TB1-ENDERFTE(TB1-IX) */
            _.Move(V1FONT_ENDERFTE, TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_ENDERFTE);

            /*" -1642- MOVE V1FONT-BAIRRO TO TB1-BAIRRO(TB1-IX) */
            _.Move(V1FONT_BAIRRO, TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_BAIRRO);

            /*" -1643- MOVE V1FONT-CIDADE TO TB1-CIDADE(TB1-IX) */
            _.Move(V1FONT_CIDADE, TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_CIDADE);

            /*" -1644- MOVE V1FONT-CEP TO TB1-CEP(TB1-IX) */
            _.Move(V1FONT_CEP, TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_CEP);

            /*" -1645- MOVE V1FONT-UF TO TB1-UF(TB1-IX) */
            _.Move(V1FONT_UF, TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_UF);

            /*" -1647- MOVE TB1-IX TO TB1-ULT-OCOR */
            _.Move(TB1_TABELA_FILIAL.TB1_IX, TB1_TABELA_FILIAL.TB1_ULT_OCOR);

            /*" -1647- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-SECTION */
        private void R0900_00_DECLARE_V0HISTCOBVA_SECTION()
        {
            /*" -1659- MOVE 'R0900-00-DECLARE-V' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-V", PARAGRAFO);

            /*" -1661- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -1696- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1();

            /*" -1698- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1()
        {
            /*" -1698- EXEC SQL OPEN CHISTCOB END-EXEC. */

            CHISTCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-SECTION */
        private void R0910_00_FETCH_V0HISTCOBVA_SECTION()
        {
            /*" -1710- MOVE 'R0910-00-FETCH-V0H' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-V0H", PARAGRAFO);

            /*" -1712- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -1735- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1 */

            R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1();

            /*" -1738- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1739- MOVE 'S' TO WFIM-V0HISTCOBVA */
                _.Move("S", AREA_DE_WORK.WFIM_V0HISTCOBVA);

                /*" -1741- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1741- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1 */

                R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1();

                /*" -1744- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1750- IF V0HIST-NRAPOLICE NOT EQUAL 107700000003 AND 107700000006 AND 109300000799 AND 108208503665 AND 108209646968 AND 109300002554 */

            if (!V0HIST_NRAPOLICE.In("107700000003", "107700000006", "109300000799", "108208503665", "108209646968", "109300002554"))
            {

                /*" -1752- IF V0HIST-DTVENCTO GREATER V1SIST-DATA-LIMITE */

                if (V0HIST_DTVENCTO > V1SIST_DATA_LIMITE)
                {

                    /*" -1754- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                    new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -1756- PERFORM R2710-00-SELECT-V0PRODUTOSVG. */

            R2710_00_SELECT_V0PRODUTOSVG_SECTION();

            /*" -1757- IF V0PROD-ESTR-COBR-I < ZEROS */

            if (V0PROD_ESTR_COBR_I < 00)
            {

                /*" -1759- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1760- IF V0PROD-ORIG-PRODU-I < ZEROS */

            if (V0PROD_ORIG_PRODU_I < 00)
            {

                /*" -1762- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1763- IF V0PROD-ESTR-COBR NOT = 'MULT' */

            if (V0PROD_ESTR_COBR != "MULT")
            {

                /*" -1765- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1769- IF V0PROD-ORIG-PRODU NOT = 'EMPRE' AND 'ESPEC' AND 'ESPE1' AND 'GLOBAL' */

            if (!V0PROD_ORIG_PRODU.In("EMPRE", "ESPEC", "ESPE1", "GLOBAL"))
            {

                /*" -1772- IF V0PROD-NUM-APOLICE EQUAL 109300000635 AND V0PROD-CODSUBES EQUAL 1 NEXT SENTENCE */

                if (V0PROD_NUM_APOLICE == 109300000635 && V0PROD_CODSUBES == 1)
                {

                    /*" -1773- ELSE */
                }
                else
                {


                    /*" -1776- IF V0PROD-NUM-APOLICE EQUAL 107700000007 AND V0PROD-CODSUBES EQUAL 2 NEXT SENTENCE */

                    if (V0PROD_NUM_APOLICE == 107700000007 && V0PROD_CODSUBES == 2)
                    {

                        /*" -1777- ELSE */
                    }
                    else
                    {


                        /*" -1779- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                        new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...
                    }

                }

            }


            /*" -1780- IF VIND-NRTITCOMP < ZEROS */

            if (VIND_NRTITCOMP < 00)
            {

                /*" -1784- MOVE ZEROS TO V0HIST-NRTITCOMP. */
                _.Move(0, V0HIST_NRTITCOMP);
            }


            /*" -1785- IF V0HIST-OPCAOPAG EQUAL '3' */

            if (V0HIST_OPCAOPAG == "3")
            {

                /*" -1794- IF V0HIST-CODOPER EQUAL ZEROS OR 111 OR 112 OR 113 OR 114 OR 115 OR 301 OR 501 NEXT SENTENCE */

                if (V0HIST_CODOPER.In("00", "111", "112", "113", "114", "115", "301", "501"))
                {

                    /*" -1795- ELSE */
                }
                else
                {


                    /*" -1796- GO TO R0910-00-FETCH-V0HISTCOBVA */
                    new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1797- ELSE */
                }

            }
            else
            {


                /*" -1801- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1802- IF V0HIST-OPCAOPAG EQUAL '1' OR '2' */

            if (V0HIST_OPCAOPAG.In("1", "2"))
            {

                /*" -1804- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1807- ADD 1 TO AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -1808- IF AC-CONTA > 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -1809- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1810- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -1810- DISPLAY '**** LIDOS V0HISTCOBVA ' AC-LIDOS ' ' WHORA-CURR. */

                $"**** LIDOS V0HISTCOBVA {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1()
        {
            /*" -1735- EXEC SQL FETCH CHISTCOB INTO :V0HIST-NRCERTIF, :V0HIST-NRPARCEL, :V0HIST-NRTIT, :V0HIST-DTVENCTO, :V0HIST-VLPRMTOT, :V0HIST-CODOPER, :V0HIST-OPCAOPAG, :V0HIST-NRTITCOMP, :V0HIST-CODPRODU, :V0HIST-OCORHIST, :V0HIST-CDCLIENTE, :V0HIST-IDSEXO, :V0HIST-OPCOBERT, :V0HIST-NRAPOLICE, :V0HIST-CODSUBES, :V0HIST-OCOREND, :V0HIST-AGECOBR, :V0HIST-FONTE, :V0HIST-DTQITBCO, :V0PARC-DTVENCTO , :PRODUTO-COD-EMPRESA END-EXEC. */

            if (CHISTCOB.Fetch())
            {
                _.Move(CHISTCOB.V0HIST_NRCERTIF, V0HIST_NRCERTIF);
                _.Move(CHISTCOB.V0HIST_NRPARCEL, V0HIST_NRPARCEL);
                _.Move(CHISTCOB.V0HIST_NRTIT, V0HIST_NRTIT);
                _.Move(CHISTCOB.V0HIST_DTVENCTO, V0HIST_DTVENCTO);
                _.Move(CHISTCOB.V0HIST_VLPRMTOT, V0HIST_VLPRMTOT);
                _.Move(CHISTCOB.V0HIST_CODOPER, V0HIST_CODOPER);
                _.Move(CHISTCOB.V0HIST_OPCAOPAG, V0HIST_OPCAOPAG);
                _.Move(CHISTCOB.V0HIST_NRTITCOMP, V0HIST_NRTITCOMP);
                _.Move(CHISTCOB.V0HIST_CODPRODU, V0HIST_CODPRODU);
                _.Move(CHISTCOB.V0HIST_OCORHIST, V0HIST_OCORHIST);
                _.Move(CHISTCOB.V0HIST_CDCLIENTE, V0HIST_CDCLIENTE);
                _.Move(CHISTCOB.V0HIST_IDSEXO, V0HIST_IDSEXO);
                _.Move(CHISTCOB.V0HIST_OPCOBERT, V0HIST_OPCOBERT);
                _.Move(CHISTCOB.V0HIST_NRAPOLICE, V0HIST_NRAPOLICE);
                _.Move(CHISTCOB.V0HIST_CODSUBES, V0HIST_CODSUBES);
                _.Move(CHISTCOB.V0HIST_OCOREND, V0HIST_OCOREND);
                _.Move(CHISTCOB.V0HIST_AGECOBR, V0HIST_AGECOBR);
                _.Move(CHISTCOB.V0HIST_FONTE, V0HIST_FONTE);
                _.Move(CHISTCOB.V0HIST_DTQITBCO, V0HIST_DTQITBCO);
                _.Move(CHISTCOB.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
                _.Move(CHISTCOB.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1()
        {
            /*" -1741- EXEC SQL CLOSE CHISTCOB END-EXEC */

            CHISTCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1822- MOVE 'R1000-00-PROCESSA-' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-", PARAGRAFO);

            /*" -1824- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -1827- MOVE V0HIST-NRAPOLICE TO V0MENS-NUM-APOLICE WS-NUM-APOLICE. */
            _.Move(V0HIST_NRAPOLICE, V0MENS_NUM_APOLICE);
            _.Move(V0HIST_NRAPOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);


            /*" -1830- MOVE V0HIST-CODSUBES TO V0MENS-CODSUBES WS-CODSUBES. */
            _.Move(V0HIST_CODSUBES, V0MENS_CODSUBES);
            _.Move(V0HIST_CODSUBES, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);


            /*" -1833- MOVE V0HIST-CODOPER TO WHOST-CODOPER WS-CODOPER. */
            _.Move(V0HIST_CODOPER, WHOST_CODOPER);
            _.Move(V0HIST_CODOPER, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);


            /*" -1835- PERFORM R1200-00-SELECT-V0CLIENTE. */

            R1200_00_SELECT_V0CLIENTE_SECTION();

            /*" -1837- PERFORM R1300-00-SELECT-V0ENDERECO. */

            R1300_00_SELECT_V0ENDERECO_SECTION();

            /*" -1839- PERFORM R1500-00-SELECT-V1AGENCEF. */

            R1500_00_SELECT_V1AGENCEF_SECTION();

            /*" -1841- PERFORM R1510-00-SELECT-V0OPCAOPAGVA. */

            R1510_00_SELECT_V0OPCAOPAGVA_SECTION();

            /*" -1842- MOVE V1MCEF-COD-FONTE TO SVA-FONTE. */
            _.Move(V1MCEF_COD_FONTE, REG_SVG4267B.SVA_FONTE);

            /*" -1843- MOVE V0CLIE-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVG4267B.SVA_NOME_RAZAO);

            /*" -1844- MOVE V0CLIE-CNPJ TO SVA-NRCNPJ. */
            _.Move(V0CLIE_CNPJ, REG_SVG4267B.SVA_NRCNPJ);

            /*" -1845- MOVE V0ENDE-ENDERECO TO SVA-ENDERECO. */
            _.Move(V0ENDE_ENDERECO, REG_SVG4267B.SVA_ENDERECO);

            /*" -1846- MOVE V0ENDE-BAIRRO TO SVA-BAIRRO. */
            _.Move(V0ENDE_BAIRRO, REG_SVG4267B.SVA_BAIRRO);

            /*" -1847- MOVE V0ENDE-CIDADE TO SVA-CIDADE. */
            _.Move(V0ENDE_CIDADE, REG_SVG4267B.SVA_CIDADE);

            /*" -1848- MOVE V0ENDE-UF TO SVA-UF. */
            _.Move(V0ENDE_UF, REG_SVG4267B.SVA_UF);

            /*" -1849- MOVE V0ENDE-CEP TO WS-NUM-CEP-AUX. */
            _.Move(V0ENDE_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1850- MOVE V0HIST-NRCERTIF TO SVA-NRCERTIF. */
            _.Move(V0HIST_NRCERTIF, REG_SVG4267B.SVA_NRCERTIF);

            /*" -1851- MOVE V0HIST-NRTIT TO SVA-NRTIT. */
            _.Move(V0HIST_NRTIT, REG_SVG4267B.SVA_NRTIT);

            /*" -1852- MOVE V0HIST-NRTITCOMP TO SVA-NRTITCOMP. */
            _.Move(V0HIST_NRTITCOMP, REG_SVG4267B.SVA_NRTITCOMP);

            /*" -1853- MOVE V0HIST-NRPARCEL TO SVA-NRPARCEL. */
            _.Move(V0HIST_NRPARCEL, REG_SVG4267B.SVA_NRPARCEL);

            /*" -1854- MOVE V0HIST-DTVENCTO TO SVA-DTVENCTO. */
            _.Move(V0HIST_DTVENCTO, REG_SVG4267B.SVA_DTVENCTO);

            /*" -1855- MOVE V0PARC-DTVENCTO TO SVA-DTVENCTO-ORIG. */
            _.Move(V0PARC_DTVENCTO, REG_SVG4267B.SVA_DTVENCTO_ORIG);

            /*" -1856- MOVE V0HIST-VLPRMTOT TO SVA-VLPRMTOT. */
            _.Move(V0HIST_VLPRMTOT, REG_SVG4267B.SVA_VLPRMTOT);

            /*" -1857- MOVE V0HIST-CODOPER TO SVA-CODOPER. */
            _.Move(V0HIST_CODOPER, REG_SVG4267B.SVA_CODOPER);

            /*" -1858- MOVE V0HIST-OCORHIST TO SVA-OCORHIST. */
            _.Move(V0HIST_OCORHIST, REG_SVG4267B.SVA_OCORHIST);

            /*" -1859- MOVE V0HIST-CODPRODU TO SVA-CODPRODU. */
            _.Move(V0HIST_CODPRODU, REG_SVG4267B.SVA_CODPRODU);

            /*" -1860- MOVE V0HIST-NRAPOLICE TO SVA-NRAPOLICE. */
            _.Move(V0HIST_NRAPOLICE, REG_SVG4267B.SVA_NRAPOLICE);

            /*" -1861- MOVE V0HIST-CODSUBES TO SVA-CODSUBES. */
            _.Move(V0HIST_CODSUBES, REG_SVG4267B.SVA_CODSUBES);

            /*" -1862- MOVE V0HIST-AGECOBR TO SVA-AGECOBR. */
            _.Move(V0HIST_AGECOBR, REG_SVG4267B.SVA_AGECOBR);

            /*" -1863- MOVE V0HIST-DTQITBCO TO SVA-DTQITBCO. */
            _.Move(V0HIST_DTQITBCO, REG_SVG4267B.SVA_DTQITBCO);

            /*" -1865- MOVE V0OPCP-PERIPGTO TO SVA-PERIPGTO. */
            _.Move(V0OPCP_PERIPGTO, REG_SVG4267B.SVA_PERIPGTO);

            /*" -1866- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -1867- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVG4267B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -1868- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVG4267B.SVA_NUM_CEP.SVA_CEP);

                /*" -1869- ELSE */
            }
            else
            {


                /*" -1870- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVG4267B.SVA_NUM_CEP.SVA_CEP);

                /*" -1872- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL. */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVG4267B.SVA_NUM_CEP.SVA_CEP_COMPL);
            }


            /*" -1873- IF V0ENDE-CEP EQUAL ZEROS */

            if (V0ENDE_CEP == 00)
            {

                /*" -1874- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVG4267B.SVA_CEP_G);

                /*" -1875- MOVE TB2-FAIXAS(TB2-IX-01) TO SVA-NOME-CORREIO */
                _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX_01].TB2_FAIXAS, REG_SVG4267B.SVA_NOME_CORREIO);

                /*" -1876- ELSE */
            }
            else
            {


                /*" -1877- PERFORM R1900-00-LOCALIZA-CEP */

                R1900_00_LOCALIZA_CEP_SECTION();

                /*" -1879- END-IF */
            }


            /*" -1881- MOVE PRODUTO-COD-EMPRESA TO SVA-COD-EMPRESA. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, REG_SVG4267B.SVA_COD_EMPRESA);

            /*" -1881- RELEASE REG-SVG4267B. */
            SVG4267B.Release(REG_SVG4267B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1885- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-SECTION */
        private void R1200_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -1897- MOVE 'R1200-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R1200-00-SELECT-V0", PARAGRAFO);

            /*" -1899- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1906- PERFORM R1200_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1200_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -1909- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1910- DISPLAY 'R1200 - PROBLEMAS NO ACESSO A V0CLIENTE' */
                _.Display($"R1200 - PROBLEMAS NO ACESSO A V0CLIENTE");

                /*" -1911- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -1911- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1200_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -1906- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CNPJ FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0HIST-CDCLIENTE END-EXEC. */

            var r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0HIST_CDCLIENTE = V0HIST_CDCLIENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO, V0CLIE_NOME_RAZAO);
                _.Move(executed_1.V0CLIE_CNPJ, V0CLIE_CNPJ);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-SECTION */
        private void R1300_00_SELECT_V0ENDERECO_SECTION()
        {
            /*" -1923- MOVE 'R1300-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R1300-00-SELECT-V0", PARAGRAFO);

            /*" -1925- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1939- PERFORM R1300_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -1942- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1943- DISPLAY 'R1300 - PROBLEMAS NO ACESSO A V0ENDERECOS' */
                _.Display($"R1300 - PROBLEMAS NO ACESSO A V0ENDERECOS");

                /*" -1944- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -1944- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -1939- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-UF, :V0ENDE-CEP FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0HIST-CDCLIENTE AND OCORR_ENDERECO = :V0HIST-OCOREND END-EXEC. */

            var r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1()
            {
                V0HIST_CDCLIENTE = V0HIST_CDCLIENTE.ToString(),
                V0HIST_OCOREND = V0HIST_OCOREND.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDERECO, V0ENDE_ENDERECO);
                _.Move(executed_1.V0ENDE_BAIRRO, V0ENDE_BAIRRO);
                _.Move(executed_1.V0ENDE_CIDADE, V0ENDE_CIDADE);
                _.Move(executed_1.V0ENDE_UF, V0ENDE_UF);
                _.Move(executed_1.V0ENDE_CEP, V0ENDE_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-SECTION */
        private void R1500_00_SELECT_V1AGENCEF_SECTION()
        {
            /*" -1956- MOVE 'R1500-00-SELECT-V1' TO PARAGRAFO. */
            _.Move("R1500-00-SELECT-V1", PARAGRAFO);

            /*" -1958- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1967- PERFORM R1500_00_SELECT_V1AGENCEF_DB_SELECT_1 */

            R1500_00_SELECT_V1AGENCEF_DB_SELECT_1();

            /*" -1970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1971- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1972- MOVE V0HIST-FONTE TO V1MCEF-COD-FONTE */
                    _.Move(V0HIST_FONTE, V1MCEF_COD_FONTE);

                    /*" -1973- ELSE */
                }
                else
                {


                    /*" -1974- DISPLAY 'R1500 - PROBLEMAS SELECT V1AGENCEF ..' */
                    _.Display($"R1500 - PROBLEMAS SELECT V1AGENCEF ..");

                    /*" -1975- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1975- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_V1AGENCEF_DB_SELECT_1()
        {
            /*" -1967- EXEC SQL SELECT B.COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG < 1000 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :V0HIST-AGECOBR END-EXEC. */

            var r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 = new R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1()
            {
                V0HIST_AGECOBR = V0HIST_AGECOBR.ToString(),
            };

            var executed_1 = R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-SELECT-V0OPCAOPAGVA-SECTION */
        private void R1510_00_SELECT_V0OPCAOPAGVA_SECTION()
        {
            /*" -1986- MOVE 'R1510-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R1510-00-SELECT-V0", PARAGRAFO);

            /*" -1988- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", WABEND.WNR_EXEC_SQL);

            /*" -1994- PERFORM R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1 */

            R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1();

            /*" -1997- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1998- DISPLAY 'R1500 - PROBLEMAS SELECT V1AGENCEF ..' */
                _.Display($"R1500 - PROBLEMAS SELECT V1AGENCEF ..");

                /*" -1999- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1999- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-V0OPCAOPAGVA-DB-SELECT-1 */
        public void R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -1994- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HIST-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1 = new R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                V0HIST_NRCERTIF = V0HIST_NRCERTIF.ToString(),
            };

            var executed_1 = R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-LOCALIZA-CEP-SECTION */
        private void R1900_00_LOCALIZA_CEP_SECTION()
        {
            /*" -2011- MOVE 'R1900-00-LOCALIZA-' TO PARAGRAFO. */
            _.Move("R1900-00-LOCALIZA-", PARAGRAFO);

            /*" -2011- MOVE 1 TO TB2-IX. */
            _.Move(1, TB2_TABELA_FAIXA_CEP.TB2_IX);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -2015- IF TB2-IX GREATER TB2-ULT-OCOR */

            if (TB2_TABELA_FAIXA_CEP.TB2_IX > TB2_TABELA_FAIXA_CEP.TB2_ULT_OCOR)
            {

                /*" -2017- DISPLAY '*** R1900 - CEP NAO ENCONTRADO ' V0ENDE-CEP ' ' V0HIST-NRCERTIF */

                $"*** R1900 - CEP NAO ENCONTRADO {V0ENDE_CEP} {V0HIST_NRCERTIF}"
                .Display();

                /*" -2018- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVG4267B.SVA_CEP_G);

                /*" -2019- MOVE TB2-FAIXAS(TB2-IX-01) TO SVA-NOME-CORREIO */
                _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX_01].TB2_FAIXAS, REG_SVG4267B.SVA_NOME_CORREIO);

                /*" -2020- GO TO R1900-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;

                /*" -2022- END-IF */
            }


            /*" -2023- MOVE TB2-FX-FIM(TB2-IX) TO WS-SUP. */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -2025- MOVE TB2-FX-INI(TB2-IX) TO WS-INF. */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -2026- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -2028- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -2030- IF V0ENDE-CEP GREATER WS-INF AND V0ENDE-CEP LESS WS-SUP */

            if (V0ENDE_CEP > AREA_DE_WORK.WS_INF && V0ENDE_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -2031- MOVE TB2-IX TO SVA-CEP-G-IX */
                _.Move(TB2_TABELA_FAIXA_CEP.TB2_IX, REG_SVG4267B.SVA_CEP_G_IX);

                /*" -2032- MOVE TB2-FX-CEP-G(TB2-IX) TO SVA-CEP-G */
                _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FX_CEP_G, REG_SVG4267B.SVA_CEP_G);

                /*" -2033- MOVE TB2-FAIXAS(TB2-IX) TO SVA-NOME-CORREIO */
                _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS, REG_SVG4267B.SVA_NOME_CORREIO);

                /*" -2034- ELSE */
            }
            else
            {


                /*" -2035- ADD 1 TO TB2-IX */
                TB2_TABELA_FAIXA_CEP.TB2_IX.Value = TB2_TABELA_FAIXA_CEP.TB2_IX + 1;

                /*" -2036- GO TO R1900-10-LOOP */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2037- END-IF */
            }


            /*" -2037- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -2047- MOVE 'R2000-00-PROCESSA-' TO PARAGRAFO. */
            _.Move("R2000-00-PROCESSA-", PARAGRAFO);

            /*" -2048- MOVE SVA-CODPRODU TO WS-PRODU-ANT. */
            _.Move(REG_SVG4267B.SVA_CODPRODU, AREA_DE_WORK.WS_PRODU_ANT);

            /*" -2050- MOVE SVA-CODPRODU TO WHOST-CODPRODU. */
            _.Move(REG_SVG4267B.SVA_CODPRODU, WHOST_CODPRODU);

            /*" -2054- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE-ANT V0MENS-NUM-APOLICE WHOST-NRAPOLICE. */
            _.Move(REG_SVG4267B.SVA_NRAPOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0MENS_NUM_APOLICE, WHOST_NRAPOLICE);

            /*" -2058- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT V0MENS-CODSUBES WHOST-CODSUBES. */
            _.Move(REG_SVG4267B.SVA_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0MENS_CODSUBES, WHOST_CODSUBES);

            /*" -2060- PERFORM R2900-00-TRATA-V0RELATORIOS. */

            R2900_00_TRATA_V0RELATORIOS_SECTION();

            /*" -2062- PERFORM R2700-00-SELECT-V0PRODUTOSVG. */

            R2700_00_SELECT_V0PRODUTOSVG_SECTION();

            /*" -2063- MOVE V0PROD-CODPRODU TO LR08-COD-PRODUTO. */
            _.Move(V0PROD_CODPRODU, AREA_DE_WORK.LR08_LINHA08.LR08_TIPO.LR08_COD_PRODUTO);

            /*" -2065- MOVE V0PROD-NOMPRODU TO LR08-NOME-PRODUTO. */
            _.Move(V0PROD_NOMPRODU, AREA_DE_WORK.LR08_LINHA08.LR08_TIPO.LR08_NOME_PRODUTO);

            /*" -2067- PERFORM R2800-00-SELECT-V0CEDENTE. */

            R2800_00_SELECT_V0CEDENTE_SECTION();

            /*" -2069- MOVE V0PROD-NOMPRODU TO LR03-TP-PGTO. */
            _.Move(V0PROD_NOMPRODU, AREA_DE_WORK.LR11_LINHA11.LR03_TP_PGTO);

            /*" -2075- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL SVA-CODPRODU NOT EQUAL WS-PRODU-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVG4267B.SVA_CODPRODU != AREA_DE_WORK.WS_PRODU_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -2077- MOVE 'C' TO WS-CONTR-PRODU. */
            _.Move("C", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -2079- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -2081- PERFORM R3000-00-IMPRIME-LST. */

            R3000_00_IMPRIME_LST_SECTION();

            /*" -2082- WRITE FVG4267B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2084- WRITE FVG4267B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2086- MOVE 'R' TO WS-CONTR-PRODU. */
            _.Move("R", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -2088- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -2098- MOVE ZEROS TO TB3-TABELA-TOTAIS WS-AMARRADO WS-CONTR-AMAR WS-CONTR-OBJ WS-CONTR-200 WS-SEQ AC-QTD-OBJ AC-CONTA1 AC-PAGINA WS-OCORR WIND. */
            _.Move(0, TB3_TABELA_TOTAIS, AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ, AREA_DE_WORK.WS_CONTR_200, AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.WS_OCORR, AREA_DE_WORK.WIND);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -2108- MOVE 'R2010-00-PROCESSA-' TO PARAGRAFO. */
            _.Move("R2010-00-PROCESSA-", PARAGRAFO);

            /*" -2109- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SVG4267B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -2110- MOVE SVA-CEP-G-IX TO WS-CEP-G-IX-ANT */
            _.Move(REG_SVG4267B.SVA_CEP_G_IX, AREA_DE_WORK.WS_CEP_G_IX_ANT);

            /*" -2111- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SVG4267B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -2113- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -2114- MOVE TB2-FX-INI(SVA-CEP-G-IX) TO WS-NUM-CEP-AUX. */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[REG_SVG4267B.SVA_CEP_G_IX].TB2_FAIXAS.TB2_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2115- MOVE WS-CEP-AUX TO LF03-FAIXA1. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1);

            /*" -2116- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA1C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1C);

            /*" -2117- MOVE TB2-FX-FIM(SVA-CEP-G-IX) TO WS-NUM-CEP-AUX. */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[REG_SVG4267B.SVA_CEP_G_IX].TB2_FAIXAS.TB2_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2118- MOVE WS-CEP-AUX TO LF03-FAIXA2. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2);

            /*" -2121- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA2C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2C);

            /*" -2128- PERFORM R2100-00-PROCESSA-CEP UNTIL SVA-CODPRODU NOT EQUAL WS-PRODU-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVG4267B.SVA_CODPRODU != AREA_DE_WORK.WS_PRODU_ANT || REG_SVG4267B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

            /*" -2129- MOVE WS-AMARRADO TO TB3-AMARF(WS-CEP-G-IX-ANT) */
            _.Move(AREA_DE_WORK.WS_AMARRADO, TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_IX_ANT].TB3_AMARF);

            /*" -2130- MOVE WS-SEQ TO TB3-OBJF (WS-CEP-G-IX-ANT) */
            _.Move(AREA_DE_WORK.WS_SEQ, TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_IX_ANT].TB3_OBJF);

            /*" -2130- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -2141- MOVE 'R2100-00-PROCESSA-CEP' TO PARAGRAFO. */
            _.Move("R2100-00-PROCESSA-CEP", PARAGRAFO);

            /*" -2145- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -2147- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -2148- WRITE RVG4267B-RECORD FROM LC08-LINHA08. */
            _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2149- WRITE RVG4267B-RECORD FROM LC09-LINHA09. */
            _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2151- WRITE RVG4267B-RECORD FROM LC10-LINHA10. */
            _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2152- IF WINSERE-HEA EQUAL 'SIM' */

            if (AREA_DE_WORK.WINSERE_HEA == "SIM")
            {

                /*" -2153- MOVE 'NAO' TO WINSERE-HEA */
                _.Move("NAO", AREA_DE_WORK.WINSERE_HEA);

                /*" -2154- MOVE ZEROS TO GEOBJECT-NUM-CEP */
                _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

                /*" -2155- MOVE 'VG0267B' TO GEOBJECT-NOM-PROGRAMA */
                _.Move("VG0267B", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NOM_PROGRAMA);

                /*" -2156- MOVE 'VD02' TO GEOBJECT-COD-FORMULARIO */
                _.Move("VD02", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                /*" -2157- IF PRODUTO-COD-EMPRESA = 11 */

                if (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA == 11)
                {

                    /*" -2158- MOVE 'VIDA25' TO GEOBJECT-COD-FORMULARIO */
                    _.Move("VIDA25", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                    /*" -2159- END-IF */
                }


                /*" -2160- MOVE 'H' TO GEOBJECT-STA-REGISTRO */
                _.Move("H", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

                /*" -2161- MOVE -1 TO VIND-COD-PRODUTO */
                _.Move(-1, VIND_COD_PRODUTO);

                /*" -2165- MOVE ZEROS TO GEOBJECT-COD-PRODUTO GEOBJECT-NUM-INI-POS-VERSO GEOBJECT-VLR-DECLARADO GEOBJECT-QTD-PESO-GRAMAS */
                _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

                /*" -2166- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
                _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

                /*" -2167- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
                _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

                /*" -2169- MOVE LC10-LINHA10 TO GEOBJECT-DES-OBJETO-TEXT */
                _.Move(AREA_DE_WORK.LC10_LINHA10, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

                /*" -2170- PERFORM R9100-00-INSERT-GEOBJECT */

                R9100_00_INSERT_GEOBJECT_SECTION();

                /*" -2172- END-IF */
            }


            /*" -2180- PERFORM R2200-00-PROCESSA-FAC UNTIL SVA-CODPRODU NOT EQUAL WS-PRODU-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199. */

            while (!(REG_SVG4267B.SVA_CODPRODU != AREA_DE_WORK.WS_PRODU_ANT || REG_SVG4267B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -2183- ADD 1 TO WS-AMARRADO TB3-QTD-AMAR(WS-CEP-G-IX-ANT) */
            AREA_DE_WORK.WS_AMARRADO.Value = AREA_DE_WORK.WS_AMARRADO + 1;
            TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_IX_ANT].TB3_QTD_AMAR.Value = TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_IX_ANT].TB3_QTD_AMAR + 1;

            /*" -2184- IF WS-CONTR-AMAR EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_AMAR == 00)
            {

                /*" -2185- MOVE 1 TO WS-CONTR-AMAR */
                _.Move(1, AREA_DE_WORK.WS_CONTR_AMAR);

                /*" -2186- MOVE WS-AMARRADO TO TB3-AMARI(WS-CEP-G-IX-ANT) */
                _.Move(AREA_DE_WORK.WS_AMARRADO, TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_IX_ANT].TB3_AMARI);

                /*" -2188- END-IF */
            }


            /*" -2189- MOVE WS-AMARRADO TO LF05-AMARRADO. */
            _.Move(AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.LF04_LINHA04.LF05_AMARRADO);

            /*" -2190- MOVE AC-QTD-OBJ TO LF04-QTD-OBJ. */
            _.Move(AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ);

            /*" -2191- MOVE WS-SEQ-INICIAL TO LF05-SEQ-INICIAL. */
            _.Move(AREA_DE_WORK.WS_SEQ_INICIAL, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_INICIAL);

            /*" -2195- MOVE WS-SEQ TO LF05-SEQ-FINAL. */
            _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_FINAL);

            /*" -2196- WRITE RVG4267B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2197- WRITE RVG4267B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2198- WRITE RVG4267B-RECORD FROM LF01-LINHA01. */
            _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2200- WRITE RVG4267B-RECORD FROM LC08-LINHA08. */
            _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2202- MOVE SPACES TO LF02-NOME-FAIXA. */
            _.Move("", AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

            /*" -2203- IF AC-CONTA1 GREATER 199 */

            if (AREA_DE_WORK.AC_CONTA1 > 199)
            {

                /*" -2204- MOVE TB2-FX-NOME(WS-CEP-G-IX-ANT) TO LF02-NOME-FAIXA */
                _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[AREA_DE_WORK.WS_CEP_G_IX_ANT].TB2_FAIXAS.TB2_FX_NOME, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

                /*" -2205- ELSE */
            }
            else
            {


                /*" -2206- MOVE TB2-FX-CENTR(WS-CEP-G-IX-ANT) TO LF02-NOME-FAIXA */
                _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[AREA_DE_WORK.WS_CEP_G_IX_ANT].TB2_FAIXAS.TB2_FX_CENTR, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

                /*" -2208- END-IF */
            }


            /*" -2209- WRITE RVG4267B-RECORD FROM LF02-LINHA02. */
            _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2210- WRITE RVG4267B-RECORD FROM LF03-LINHA03. */
            _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2213- WRITE RVG4267B-RECORD FROM LF04-LINHA04. */
            _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2214- WRITE RVG4267B-RECORD FROM LC12-LINHA12 */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2216- WRITE RVG4267B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2217- MOVE ZEROS TO AC-QTD-OBJ. */
            _.Move(0, AREA_DE_WORK.AC_QTD_OBJ);

            /*" -2217- MOVE 1 TO WS-CONTROLE. */
            _.Move(1, AREA_DE_WORK.WS_CONTROLE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -2229- MOVE 'R2200-00-PROCESSA-FAC' TO PARAGRAFO. */
            _.Move("R2200-00-PROCESSA-FAC", PARAGRAFO);

            /*" -2231- MOVE SVA-NRAPOLICE TO WHOST-NRAPOLICE. */
            _.Move(REG_SVG4267B.SVA_NRAPOLICE, WHOST_NRAPOLICE);

            /*" -2233- MOVE SVA-CODSUBES TO WHOST-CODSUBES. */
            _.Move(REG_SVG4267B.SVA_CODSUBES, WHOST_CODSUBES);

            /*" -2235- PERFORM R2711-00-SELECT-V0PRODUTOSVG. */

            R2711_00_SELECT_V0PRODUTOSVG_SECTION();

            /*" -2237- PERFORM R2800-00-SELECT-V0CEDENTE. */

            R2800_00_SELECT_V0CEDENTE_SECTION();

            /*" -2239- MOVE SVA-NRCERTIF TO WS-CERTIF WHOST-NRCERTIF. */
            _.Move(REG_SVG4267B.SVA_NRCERTIF, AREA_DE_WORK.WS_CERTIF, WHOST_NRCERTIF);

            /*" -2240- MOVE SVA-DTVENCTO TO V0HIST-DTVENCTO */
            _.Move(REG_SVG4267B.SVA_DTVENCTO, V0HIST_DTVENCTO);

            /*" -2241- MOVE SVA-PERIPGTO TO V0OPCP-PERIPGTO. */
            _.Move(REG_SVG4267B.SVA_PERIPGTO, V0OPCP_PERIPGTO);

            /*" -2242- MOVE SVA-NRTIT TO WHOST-NRTIT. */
            _.Move(REG_SVG4267B.SVA_NRTIT, WHOST_NRTIT);

            /*" -2243- MOVE SVA-NRPARCEL TO WHOST-NRPARCEL. */
            _.Move(REG_SVG4267B.SVA_NRPARCEL, WHOST_NRPARCEL);

            /*" -2244- MOVE SVA-OCORHIST TO WHOST-OCORHIST. */
            _.Move(REG_SVG4267B.SVA_OCORHIST, WHOST_OCORHIST);

            /*" -2246- MOVE SVA-NRTITCOMP TO WHOST-NRTITCOMP. */
            _.Move(REG_SVG4267B.SVA_NRTITCOMP, WHOST_NRTITCOMP);

            /*" -2250- MOVE SVA-NOME-RAZAO TO LC02-NOME-RAZAO LC14-NOME-RAZAO LE02-NOME-RAZAO. */
            _.Move(REG_SVG4267B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC02_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC14_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LE02_NOME_RAZAO);

            /*" -2251- MOVE SVA-NRCNPJ TO WS-CNPJ. */
            _.Move(REG_SVG4267B.SVA_NRCNPJ, AREA_DE_WORK.WS_CNPJ);

            /*" -2253- MOVE WS-NRCNPJ1 TO LC02-NRCNPJ1 LC14-NRCNPJ1 */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ1, AREA_DE_WORK.LC11_LINHA11.LC02_NRCNPJ1, AREA_DE_WORK.LC11_LINHA11.LC14_NRCNPJ1);

            /*" -2255- MOVE WS-NRCNPJ2 TO LC02-NRCNPJ2 LC14-NRCNPJ2 */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ2, AREA_DE_WORK.LC11_LINHA11.LC02_NRCNPJ2, AREA_DE_WORK.LC11_LINHA11.LC14_NRCNPJ2);

            /*" -2258- MOVE WS-DVCNPJ TO LC02-DVCNPJ LC14-DVCNPJ. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_DVCNPJ, AREA_DE_WORK.LC11_LINHA11.LC02_DVCNPJ, AREA_DE_WORK.LC11_LINHA11.LC14_DVCNPJ);

            /*" -2260- MOVE SVA-CODPRODU TO LC11-PRODUTO. */
            _.Move(REG_SVG4267B.SVA_CODPRODU, AREA_DE_WORK.LC11_LINHA11.LC11_PRODUTO);

            /*" -2262- MOVE SVA-AGECOBR TO LC11-AGENCIA. */
            _.Move(REG_SVG4267B.SVA_AGECOBR, AREA_DE_WORK.LC11_LINHA11.LC11_AGENCIA);

            /*" -2265- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE V0MENS-NUM-APOLICE. */
            _.Move(REG_SVG4267B.SVA_NRAPOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);
            _.Move(REG_SVG4267B.SVA_NRAPOLICE, V0MENS_NUM_APOLICE);


            /*" -2270- MOVE SVA-CODSUBES TO WS-CODSUBES LC11-CODSUBES LC11-COD-SUBGRUPO V0MENS-CODSUBES. */
            _.Move(REG_SVG4267B.SVA_CODSUBES, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);
            _.Move(REG_SVG4267B.SVA_CODSUBES, AREA_DE_WORK.LC11_LINHA11.LC11_CODSUBES);
            _.Move(REG_SVG4267B.SVA_CODSUBES, AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUBGRUPO);
            _.Move(REG_SVG4267B.SVA_CODSUBES, V0MENS_CODSUBES);


            /*" -2273- MOVE SVA-CODOPER TO WS-CODOPER WHOST-CODOPER. */
            _.Move(REG_SVG4267B.SVA_CODOPER, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);
            _.Move(REG_SVG4267B.SVA_CODOPER, WHOST_CODOPER);


            /*" -2274- MOVE 1 TO INF. */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -2276- MOVE WINDM TO SUP. */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -2281- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -2283- IF SVA-CODOPER NOT = 111 AND 112 AND 115 */

            if (!REG_SVG4267B.SVA_CODOPER.In("111", "112", "115"))
            {

                /*" -2284- PERFORM R2320-00-TRATA-MENSAGEM */

                R2320_00_TRATA_MENSAGEM_SECTION();

                /*" -2285- ELSE */
            }
            else
            {


                /*" -2287- IF SVA-CODOPER = 112 AND V0PROD-TEM-CDG = 'S' */

                if (REG_SVG4267B.SVA_CODOPER == 112 && V0PROD_TEM_CDG == "S")
                {

                    /*" -2289- PERFORM R2320-00-TRATA-MENSAGEM. */

                    R2320_00_TRATA_MENSAGEM_SECTION();
                }

            }


            /*" -2290- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2291- GO TO R2200-40-NEXT */

                R2200_40_NEXT(); //GOTO
                return;

                /*" -2293- END-IF. */
            }


            /*" -2294- MOVE SVA-NUM-CEP TO LE05-CEP. */
            _.Move(REG_SVG4267B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LE05_CEP);

            /*" -2295- MOVE SVA-NUM-CEP TO LC11-CEP1-SUB. */
            _.Move(REG_SVG4267B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP1_SUB);

            /*" -2296- MOVE SVA-CEP-COMPL TO LE05-CEP-COMPL. */
            _.Move(REG_SVG4267B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LE05_CEP_COMPL);

            /*" -2297- MOVE SVA-CEP-COMPL TO LC11-CEP2-SUB. */
            _.Move(REG_SVG4267B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP2_SUB);

            /*" -2299- MOVE SVA-CIDADE TO LE04-CIDADE LC11-CIDADE-SUB. */
            _.Move(REG_SVG4267B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LE04_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_SUB);

            /*" -2300- MOVE SVA-BAIRRO TO LE04-BAIRRO. */
            _.Move(REG_SVG4267B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LE04_BAIRRO);

            /*" -2302- MOVE SVA-UF TO LE04-UF LC11-UF-SUB. */
            _.Move(REG_SVG4267B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LE04_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF_SUB);

            /*" -2304- MOVE SVA-ENDERECO TO LE03-ENDERECO LC11-ENDERECO-SUB. */
            _.Move(REG_SVG4267B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LE03_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO_SUB);

            /*" -2305- MOVE SVA-DTVENCTO TO WS-DATA-SQL. */
            _.Move(REG_SVG4267B.SVA_DTVENCTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -2306- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -2307- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -2308- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -2311- MOVE WS-DATA TO LC03-DTVENCTO LC07-DTVENCTO LC11-DTVENCTO. */
            _.Move(AREA_DE_WORK.WS_DATA, AREA_DE_WORK.LC11_LINHA11.LC03_DTVENCTO, AREA_DE_WORK.LC11_LINHA11.LC07_DTVENCTO, AREA_DE_WORK.LC11_LINHA11.LC11_DTVENCTO);

            /*" -2312- MOVE WS-NRCERTIF TO LC13-NRCERTIF. */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_NRCERTIF, AREA_DE_WORK.LC11_LINHA11.LC13_NRCERTIF);

            /*" -2313- MOVE WS-DVCERTIF TO LC13-DVCERTIF. */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_DVCERTIF, AREA_DE_WORK.LC11_LINHA11.LC13_DVCERTIF);

            /*" -2316- MOVE SVA-NRPARCEL TO LC03-NRPARCEL LC13-NRPARCEL. */
            _.Move(REG_SVG4267B.SVA_NRPARCEL, AREA_DE_WORK.LC11_LINHA11.LC03_NRPARCEL, AREA_DE_WORK.LC11_LINHA11.LC13_NRPARCEL);

            /*" -2317- MOVE 104 TO WBAR-BANCO */
            _.Move(104, AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_BANCO);

            /*" -2318- MOVE 9 TO WBAR-MOEDA */
            _.Move(9, AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_MOEDA);

            /*" -2320- MOVE SVA-NRTIT TO WWRK-NSNUMERO WS-TITULO. */
            _.Move(REG_SVG4267B.SVA_NRTIT, AREA_DE_WORK.WWRK_NSNUMERO, AREA_DE_WORK.WS_TITULO);

            /*" -2323- MOVE WS-NRTIT TO LC03-NRTIT LC09-NRTIT LC09-NRTIT1. */
            _.Move(AREA_DE_WORK.WS_TITULO_R.WS_NRTIT, AREA_DE_WORK.LC11_LINHA11.LC03_NRTIT, AREA_DE_WORK.LC11_LINHA11.LC09_NRTIT, AREA_DE_WORK.LC11_LINHA11.LC09_NRTIT1);

            /*" -2326- MOVE WS-DVTITULO TO LC03-DVTITULO LC09-DVTITULO LC09-DVTITULO1. */
            _.Move(AREA_DE_WORK.WS_TITULO_R.WS_DVTITULO, AREA_DE_WORK.LC11_LINHA11.LC03_DVTITULO, AREA_DE_WORK.LC11_LINHA11.LC09_DVTITULO, AREA_DE_WORK.LC11_LINHA11.LC09_DVTITULO1);

            /*" -2327- MOVE WWRK-NSNRO-1 TO WBAR-NSNRO-1. */
            _.Move(AREA_DE_WORK.FILLER_156.FILLER_157.WWRK_NSNRO_1, AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_NSNRO_1);

            /*" -2328- MOVE WWRK-NSNRO-2 TO WBAR-NSNRO-2. */
            _.Move(AREA_DE_WORK.FILLER_156.FILLER_157.WWRK_NSNRO_2, AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_NSNRO_2);

            /*" -2330- MOVE WBAR-CAMPO-1 TO WK-NUMERO. */
            _.Move(AREA_DE_WORK.WBAR_AREA.WBAR_CAMPO_1, AREA_DE_WORK.WK_NUMERO);

            /*" -2332- PERFORM R2400-00-CALCULA-DIGITO. */

            R2400_00_CALCULA_DIGITO_SECTION();

            /*" -2334- MOVE WK-DIGITO TO WBAR-DAC-1 */
            _.Move(AREA_DE_WORK.WK_DIGITO, AREA_DE_WORK.WBAR_AREA.WBAR_DAC_1);

            /*" -2336- MOVE WWRK-NSNRO-3 TO WBAR-NSNRO-3 */
            _.Move(AREA_DE_WORK.FILLER_156.FILLER_157.WWRK_NSNRO_3, AREA_DE_WORK.WBAR_AREA.FILLER_165.WBAR_NSNRO_3);

            /*" -2338- MOVE V0CEDE-NOMECED TO LC08-NOMECED. */
            _.Move(V0CEDE_NOMECED, AREA_DE_WORK.LC11_LINHA11.LC08_NOMECED);

            /*" -2342- MOVE V0CEDE-AGENCIA TO WWRK-CDAGE LC03-AGECTACED LC08-AGECTACED WWRK-CDCED-1. */
            _.Move(V0CEDE_AGENCIA, AREA_DE_WORK.FILLER_161.WWRK_CDAGE);
            _.Move(V0CEDE_AGENCIA, AREA_DE_WORK.LC11_LINHA11.LC03_AGECTACED);
            _.Move(V0CEDE_AGENCIA, AREA_DE_WORK.LC11_LINHA11.LC08_AGECTACED);
            _.Move(V0CEDE_AGENCIA, AREA_DE_WORK.FILLER_169.WWRK_CDCED_1);


            /*" -2344- MOVE '-' TO LC03-TRACO LC08-TRACO. */
            _.Move("-", AREA_DE_WORK.LC11_LINHA11.LC03_TRACO, AREA_DE_WORK.LC11_LINHA11.LC08_TRACO);

            /*" -2348- MOVE '.' TO LC03-PONTO1 LC03-PONTO2 LC08-PONTO1 LC08-PONTO2. */
            _.Move(".", AREA_DE_WORK.LC11_LINHA11.LC03_PONTO1, AREA_DE_WORK.LC11_LINHA11.LC03_PONTO2, AREA_DE_WORK.LC11_LINHA11.LC08_PONTO1, AREA_DE_WORK.LC11_LINHA11.LC08_PONTO2);

            /*" -2352- MOVE V0CEDE-OPERACAO TO WWRK-OPE-CED LC03-OPRCTACED LC08-OPRCTACED WWRK-CDCED-2. */
            _.Move(V0CEDE_OPERACAO, AREA_DE_WORK.WWRK_OPE_CED, AREA_DE_WORK.LC11_LINHA11.LC03_OPRCTACED, AREA_DE_WORK.LC11_LINHA11.LC08_OPRCTACED, AREA_DE_WORK.FILLER_169.WWRK_CDCED_2);

            /*" -2353- MOVE WWRK-OPE1 TO WWRK-OPE. */
            _.Move(AREA_DE_WORK.FILLER_162.WWRK_OPE1, AREA_DE_WORK.FILLER_161.WWRK_OPE);

            /*" -2354- MOVE WWRK-AGEOPE-CED TO WBAR-CDCED-1 */
            _.Move(AREA_DE_WORK.WWRK_AGEOPE_CED, AREA_DE_WORK.WBAR_AREA.FILLER_165.WBAR_CDCED_1);

            /*" -2356- MOVE WBAR-CAMPO-2 TO WK-NUMERO */
            _.Move(AREA_DE_WORK.WBAR_AREA.WBAR_CAMPO_2, AREA_DE_WORK.WK_NUMERO);

            /*" -2358- PERFORM R2400-00-CALCULA-DIGITO */

            R2400_00_CALCULA_DIGITO_SECTION();

            /*" -2360- MOVE WK-DIGITO TO WBAR-DAC-2 */
            _.Move(AREA_DE_WORK.WK_DIGITO, AREA_DE_WORK.WBAR_AREA.WBAR_DAC_2);

            /*" -2361- MOVE WWRK-OPE2 TO WWRK-2UOPE. */
            _.Move(AREA_DE_WORK.FILLER_162.WWRK_OPE2, AREA_DE_WORK.FILLER_163.WWRK_2UOPE);

            /*" -2366- MOVE V0CEDE-CONTA TO WWRK-NCTCD LC03-NUMCTACED LC08-NUMCTACED WWRK-CDCED-3. */
            _.Move(V0CEDE_CONTA, AREA_DE_WORK.FILLER_163.WWRK_NCTCD);
            _.Move(V0CEDE_CONTA, AREA_DE_WORK.LC11_LINHA11.LC03_NUMCTACED);
            _.Move(V0CEDE_CONTA, AREA_DE_WORK.LC11_LINHA11.LC08_NUMCTACED);
            _.Move(V0CEDE_CONTA, AREA_DE_WORK.FILLER_169.WWRK_CDCED_3);


            /*" -2369- MOVE V0CEDE-DIGCC TO LC03-DIGCTACED LC08-DIGCTACED. */
            _.Move(V0CEDE_DIGCC, AREA_DE_WORK.LC11_LINHA11.LC03_DIGCTACED, AREA_DE_WORK.LC11_LINHA11.LC08_DIGCTACED);

            /*" -2370- MOVE WWRK-CAMPO3 TO WBAR-CAMPO-3 */
            _.Move(AREA_DE_WORK.WWRK_CAMPO3, AREA_DE_WORK.WBAR_AREA.WBAR_CAMPO_3);

            /*" -2372- MOVE WBAR-CAMPO-3 TO WK-NUMERO */
            _.Move(AREA_DE_WORK.WBAR_AREA.WBAR_CAMPO_3, AREA_DE_WORK.WK_NUMERO);

            /*" -2374- PERFORM R2400-00-CALCULA-DIGITO */

            R2400_00_CALCULA_DIGITO_SECTION();

            /*" -2376- MOVE WK-DIGITO TO WBAR-DAC-3 */
            _.Move(AREA_DE_WORK.WK_DIGITO, AREA_DE_WORK.WBAR_AREA.WBAR_DAC_3);

            /*" -2380- MOVE SVA-VLPRMTOT TO WWRK-VALOR-FMT LC03-VLPRMTOT LC10-VLPRMTOT LC11-VLPRMTOT. */
            _.Move(REG_SVG4267B.SVA_VLPRMTOT, AREA_DE_WORK.WWRK_VALOR_FMT, AREA_DE_WORK.LC11_LINHA11.LC03_VLPRMTOT, AREA_DE_WORK.LC11_LINHA11.LC10_VLPRMTOT, AREA_DE_WORK.LC11_LINHA11.LC11_VLPRMTOT);

            /*" -2382- MOVE WWRK-VALOR TO WBAR-VALOR */
            _.Move(AREA_DE_WORK.WWRK_VALOR, AREA_DE_WORK.WBAR_AREA.FILLER_168.WBAR_VALOR);

            /*" -2383- MOVE ZEROS TO W91-NUMERO */
            _.Move(0, AREA_DE_WORK.W91_NUMERO);

            /*" -2384- MOVE WBAR-BANCO TO W91-BANCO */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_BANCO, AREA_DE_WORK.FILLER_159.W91_BANCO);

            /*" -2385- MOVE WBAR-MOEDA TO W91-MOEDA */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_MOEDA, AREA_DE_WORK.FILLER_159.W91_MOEDA);

            /*" -2386- MOVE WBAR-VALOR TO W91-VALOR */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_168.WBAR_VALOR, AREA_DE_WORK.FILLER_159.W91_VALOR);

            /*" -2387- MOVE WWRK-NSNRO TO W91-NSNUM */
            _.Move(AREA_DE_WORK.FILLER_156.WWRK_NSNRO, AREA_DE_WORK.FILLER_159.W91_NSNUM);

            /*" -2388- MOVE WWRK-CEDENTE TO W91-CDCED */
            _.Move(AREA_DE_WORK.WWRK_CEDENTE, AREA_DE_WORK.FILLER_159.W91_CDCED);

            /*" -2390- PERFORM R2500-00-CALCULA-DIGITO-11 */

            R2500_00_CALCULA_DIGITO_11_SECTION();

            /*" -2392- MOVE W91-DIGITO TO WBAR-DIGITO */
            _.Move(AREA_DE_WORK.W91_DIGITO, AREA_DE_WORK.WBAR_AREA.FILLER_167.WBAR_DIGITO);

            /*" -2393- MOVE WBAR-BANCO TO LC06-BANCO. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_BANCO, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO1.LC06_BANCO);

            /*" -2394- MOVE WBAR-MOEDA TO LC06-MOEDA. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_MOEDA, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO1.LC06_MOEDA);

            /*" -2395- MOVE WBAR-NSNRO-1 TO LC06-NSNRO-1. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_NSNRO_1, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO1.LC06_NSNRO_1);

            /*" -2396- MOVE WBAR-NSNRO-2 TO LC06-NSNRO-2. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_NSNRO_2, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO1.LC06_NSNRO_2);

            /*" -2398- MOVE WBAR-DAC-1 TO LC06-DAC-1. */
            _.Move(AREA_DE_WORK.WBAR_AREA.WBAR_DAC_1, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO1.LC06_DAC_1);

            /*" -2399- MOVE WBAR-NSNRO-3 TO LC06-NSNRO-3. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_165.WBAR_NSNRO_3, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO2.LC06_NSNRO_3);

            /*" -2400- MOVE WBAR-CDCED-1 TO LC06-CDCED-1. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_165.WBAR_CDCED_1, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO2.LC06_CDCED_1);

            /*" -2402- MOVE WBAR-DAC-2 TO LC06-DAC-2. */
            _.Move(AREA_DE_WORK.WBAR_AREA.WBAR_DAC_2, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO2.LC06_DAC_2);

            /*" -2403- MOVE WBAR-CDCED-2 TO LC06-CDCED-2. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_166.WBAR_CDCED_2, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO3.LC06_CDCED_2);

            /*" -2404- MOVE WBAR-CDCED-3 TO LC06-CDCED-3. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_166.WBAR_CDCED_3, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO3.LC06_CDCED_3);

            /*" -2406- MOVE WBAR-DAC-3 TO LC06-DAC-3. */
            _.Move(AREA_DE_WORK.WBAR_AREA.WBAR_DAC_3, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO3.LC06_DAC_3);

            /*" -2408- MOVE WBAR-DIGITO TO LC06-DIGITO. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_167.WBAR_DIGITO, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO4.LC06_DIGITO);

            /*" -2411- MOVE SPACES TO LC06-VALOR. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO5.LC06_VALOR);

            /*" -2412- MOVE ZEROS TO LC06-FATOR-DT-VENC */
            _.Move(0, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO5.LC06_FATOR_DT_VENC);

            /*" -2414- MOVE WBAR-VALOR TO LC06-VALOR-9 */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_168.WBAR_VALOR, AREA_DE_WORK.LC11_LINHA11.LC06_CAMPO5.LC06_VALORR2.LC06_VALOR_9);

            /*" -2415- MOVE WBAR-BANCO TO LK-BANCO. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_BANCO, AREA_DE_WORK.LK_BANCO);

            /*" -2416- MOVE WBAR-MOEDA TO LK-MOEDA. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_164.WBAR_MOEDA, AREA_DE_WORK.LK_MOEDA);

            /*" -2417- MOVE WBAR-DIGITO TO LK-DIGITO. */
            _.Move(AREA_DE_WORK.WBAR_AREA.FILLER_167.WBAR_DIGITO, AREA_DE_WORK.LK_DIGITO);

            /*" -2418- MOVE WBAR-CAMPO-5 TO LK-VALOR. */
            _.Move(AREA_DE_WORK.WBAR_AREA.WBAR_CAMPO_5, AREA_DE_WORK.LK_VALOR);

            /*" -2419- MOVE WWRK-NSNRO TO LK-NNURO. */
            _.Move(AREA_DE_WORK.FILLER_156.WWRK_NSNRO, AREA_DE_WORK.LK_NNURO);

            /*" -2421- MOVE WWRK-CEDENTE TO LK-CDCED. */
            _.Move(AREA_DE_WORK.WWRK_CEDENTE, AREA_DE_WORK.LK_CDCED);

            /*" -2423- CALL 'PROCBR01' USING LINK-AREA. */
            _.Call("PROCBR01", AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LINK_AREA);

            /*" -2424- IF LK-RCCODE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.LK_RCCODE.IsEmpty())
            {

                /*" -2426- DISPLAY 'PROBLEMAS NO CALL DA SUBROTINA (PROCBR01) ... ' ' ' LINK-AREA */

                $"PROBLEMAS NO CALL DA SUBROTINA (PROCBR01) ...  {AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LINK_AREA}"
                .Display();

                /*" -2428- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2430- MOVE LK-CODIGO TO LC16-CDBARRA. */
            _.Move(AREA_DE_WORK.LK_CODIGO, AREA_DE_WORK.LC11_LINHA11.LC16_CDBARRA);

            /*" -2435- ADD 1 TO WS-SEQ TB3-QTD-OBJ (SVA-CEP-G-IX) AC-QTD-OBJ AC-CONTA1. */
            AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
            TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[REG_SVG4267B.SVA_CEP_G_IX].TB3_QTD_OBJ.Value = TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[REG_SVG4267B.SVA_CEP_G_IX].TB3_QTD_OBJ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
            AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

            /*" -2437- MOVE 'XXX.XXX' TO LE01-SEQUENCIA. */
            _.Move("XXX.XXX", AREA_DE_WORK.LC11_LINHA11.LE01_SEQUENCIA);

            /*" -2438- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -2439- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -2441- MOVE WS-SEQ TO TB3-OBJI (SVA-CEP-G-IX) */
                _.Move(AREA_DE_WORK.WS_SEQ, TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[REG_SVG4267B.SVA_CEP_G_IX].TB3_OBJI);

                /*" -2443- END-IF */
            }


            /*" -2444- IF WS-CONTR-200 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_200 == 00)
            {

                /*" -2445- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                /*" -2447- MOVE WS-SEQ TO WS-SEQ-INICIAL. */
                _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);
            }


            /*" -2449- PERFORM R2650-00-BUSCA-FONTE. */

            R2650_00_BUSCA_FONTE_SECTION();

            /*" -2452- PERFORM R2651-00-BUSCA-ESTIPULANTE. */

            R2651_00_BUSCA_ESTIPULANTE_SECTION();

            /*" -2456- PERFORM R2652-00-BUSCA-PARCELA. */

            R2652_00_BUSCA_PARCELA_SECTION();

            /*" -2457- MOVE SVA-NRAPOLICE TO LC11-APOLICE. */
            _.Move(REG_SVG4267B.SVA_NRAPOLICE, AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE);

            /*" -2458- MOVE SVA-NRAPOLICE TO LC11-NUM-APOLICE. */
            _.Move(REG_SVG4267B.SVA_NRAPOLICE, AREA_DE_WORK.LC11_LINHA11.LC11_NUM_APOLICE);

            /*" -2459- MOVE V0CLIE-NOME-RAZAO-E TO LC11-NOME-RAZAO-EST. */
            _.Move(V0CLIE_NOME_RAZAO_E, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_EST);

            /*" -2460- MOVE V0CLIE-CNPJ-E TO WS-CNPJ. */
            _.Move(V0CLIE_CNPJ_E, AREA_DE_WORK.WS_CNPJ);

            /*" -2461- MOVE WS-NRCNPJ1 TO LC11-CNPJ1-EST. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ1, AREA_DE_WORK.LC11_LINHA11.LC11_CNPJ1_EST);

            /*" -2462- MOVE WS-NRCNPJ2 TO LC11-CNPJ2-EST. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ2, AREA_DE_WORK.LC11_LINHA11.LC11_CNPJ2_EST);

            /*" -2463- MOVE WS-DVCNPJ TO LC11-CNPJ3-EST. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_DVCNPJ, AREA_DE_WORK.LC11_LINHA11.LC11_CNPJ3_EST);

            /*" -2464- MOVE V0ENDE-ENDERECO-E TO LC11-ENDERECO-EST. */
            _.Move(V0ENDE_ENDERECO_E, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO_EST);

            /*" -2465- MOVE V0ENDE-CIDADE-E TO LC11-CIDADE-EST. */
            _.Move(V0ENDE_CIDADE_E, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_EST);

            /*" -2466- MOVE V0ENDE-UF-E TO LC11-UF-EST. */
            _.Move(V0ENDE_UF_E, AREA_DE_WORK.LC11_LINHA11.LC11_UF_EST);

            /*" -2467- MOVE V0ENDE-CEP-E TO WS-NUM-CEP-AUX. */
            _.Move(V0ENDE_CEP_E, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2468- MOVE WS-CEP-AUX TO LC11-CEP1-EST. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LC11_LINHA11.LC11_CEP1_EST);

            /*" -2469- MOVE WS-CEP-COMPL-AUX TO LC11-CEP2-EST. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LC11_LINHA11.LC11_CEP2_EST);

            /*" -2470- MOVE V0PARC-DTVENCTO-ORIG TO WS-DTVENCTO-SQL. */
            _.Move(V0PARC_DTVENCTO_ORIG, AREA_DE_WORK.WS_DTVENCTO_SQL);

            /*" -2471- MOVE WS-ANO-VCT TO LC11-FATURA-SEC. */
            _.Move(AREA_DE_WORK.WS_DTVENCTO_SQL.WS_ANO_VCT, AREA_DE_WORK.LC11_LINHA11.LC11_FATURA_SEC);

            /*" -2472- MOVE WS-MES-VCT TO LC11-FATURA-MES. */
            _.Move(AREA_DE_WORK.WS_DTVENCTO_SQL.WS_MES_VCT, AREA_DE_WORK.LC11_LINHA11.LC11_FATURA_MES);

            /*" -2473- MOVE V0COBP-DTINIVIG-PARC TO WS-DATA1. */
            _.Move(V0COBP_DTINIVIG_PARC, AREA_DE_WORK.WS_DATA1);

            /*" -2474- MOVE WS-DIA1 TO LC11-PERIODO-1-DD. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_DIA1, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_1_DD);

            /*" -2475- MOVE WS-MES1 TO LC11-PERIODO-1-MM. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_MES1, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_1_MM);

            /*" -2476- MOVE WS-ANO1 TO LC11-PERIODO-1-AA. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_ANO1, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_1_AA);

            /*" -2478- MOVE WS-DATA1 TO WHOST-DATA1. */
            _.Move(AREA_DE_WORK.WS_DATA1, WHOST_DATA1);

            /*" -2480- MOVE SVA-PERIPGTO TO V0OPCP-PERIPGTO. */
            _.Move(REG_SVG4267B.SVA_PERIPGTO, V0OPCP_PERIPGTO);

            /*" -2488- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_1 */

            R2200_00_PROCESSA_FAC_DB_SELECT_1();

            /*" -2490- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2491- DISPLAY 'ERRO DATA DE TERMINO DE VIGENCIA ' SQLCODE */
                _.Display($"ERRO DATA DE TERMINO DE VIGENCIA {DB.SQLCODE}");

                /*" -2493- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2494- MOVE WHOST-DATA2 TO WS-DATA2. */
            _.Move(WHOST_DATA2, AREA_DE_WORK.WS_DATA2);

            /*" -2495- MOVE WS-DIA2 TO LC11-PERIODO-2-DD. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_DIA2, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_2_DD);

            /*" -2496- MOVE WS-MES2 TO LC11-PERIODO-2-MM. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_MES2, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_2_MM);

            /*" -2498- MOVE WS-ANO2 TO LC11-PERIODO-2-AA. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_ANO2, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_2_AA);

            /*" -2499- MOVE V0COBP-QUANT-VIDAS TO LC11-NVIDAS. */
            _.Move(V0COBP_QUANT_VIDAS, AREA_DE_WORK.LC11_LINHA11.LC11_NVIDAS);

            /*" -2501- MOVE V0COBP-IMPSEGUR TO LC11-CAPITAL. */
            _.Move(V0COBP_IMPSEGUR, AREA_DE_WORK.LC11_LINHA11.LC11_CAPITAL);

            /*" -2503- MOVE '22AA' TO WNR-EXEC-SQL */
            _.Move("22AA", WABEND.WNR_EXEC_SQL);

            /*" -2512- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_2 */

            R2200_00_PROCESSA_FAC_DB_SELECT_2();

            /*" -2515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2516- DISPLAY 'R2200 - NAO ENCONTRADO NA V0SUBGRUPO - IOF ' */
                _.Display($"R2200 - NAO ENCONTRADO NA V0SUBGRUPO - IOF ");

                /*" -2517- DISPLAY 'APOLICE     => ' WHOST-NRAPOLICE */
                _.Display($"APOLICE     => {WHOST_NRAPOLICE}");

                /*" -2520- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2521- IF V0SUBG-IND-IOF EQUAL 'S' */

            if (V0SUBG_IND_IOF == "S")
            {

                /*" -2523- COMPUTE LC11-IOF = SVA-VLPRMTOT - (SVA-VLPRMTOT / SQL-PCIOF) */
                AREA_DE_WORK.LC11_LINHA11.LC11_IOF.Value = (REG_SVG4267B.SVA_VLPRMTOT - (REG_SVG4267B.SVA_VLPRMTOT / SQL_PCIOF)).ToString();

                /*" -2524- ELSE */
            }
            else
            {


                /*" -2526- MOVE ZEROS TO LC11-IOF. */
                _.Move(0, AREA_DE_WORK.LC11_LINHA11.LC11_IOF);
            }


            /*" -2530- WRITE RVG4267B-RECORD FROM LC11-LINHA11. */
            _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVG4267B_RECORD);

            RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

            /*" -2531- MOVE SVA-NUM-CEP-9 TO GEOBJECT-NUM-CEP */
            _.Move(REG_SVG4267B.SVA_NUM_CEP_9, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -2532- MOVE 'VG0267B' TO GEOBJECT-NOM-PROGRAMA */
            _.Move("VG0267B", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NOM_PROGRAMA);

            /*" -2533- MOVE 'VD02' TO GEOBJECT-COD-FORMULARIO */
            _.Move("VD02", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

            /*" -2534- IF PRODUTO-COD-EMPRESA = 11 */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA == 11)
            {

                /*" -2535- MOVE 'VIDA25' TO GEOBJECT-COD-FORMULARIO */
                _.Move("VIDA25", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                /*" -2536- END-IF */
            }


            /*" -2537- MOVE 'D' TO GEOBJECT-STA-REGISTRO */
            _.Move("D", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -2538- MOVE SVA-CODPRODU TO GEOBJECT-COD-PRODUTO */
            _.Move(REG_SVG4267B.SVA_CODPRODU, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO);

            /*" -2540- MOVE ZEROS TO GEOBJECT-NUM-INI-POS-VERSO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -2541- MOVE 0 TO VIND-COD-PRODUTO */
            _.Move(0, VIND_COD_PRODUTO);

            /*" -2542- MOVE 4,6 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(4.6, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -2543- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -2544- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -2546- MOVE LC11-LINHA11 TO GEOBJECT-DES-OBJETO-TEXT */
            _.Move(AREA_DE_WORK.LC11_LINHA11, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

            /*" -2549- PERFORM R9100-00-INSERT-GEOBJECT. */

            R9100_00_INSERT_GEOBJECT_SECTION();

            /*" -2551- ADD 1 TO AC-IMPRESSOS. */
            AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

            /*" -2551- PERFORM R2600-00-UPDATE-V0HISTCOBVA. */

            R2600_00_UPDATE_V0HISTCOBVA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2200_40_NEXT */

            R2200_40_NEXT();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-1 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_1()
        {
            /*" -2488- EXEC SQL SELECT DATE(:WHOST-DATA1) + :V0OPCP-PERIPGTO MONTHS - 1 DAY INTO :WHOST-DATA2 FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1()
            {
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                WHOST_DATA1 = WHOST_DATA1.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA2, WHOST_DATA2);
            }


        }

        [StopWatch]
        /*" R2200-40-NEXT */
        private void R2200_40_NEXT(bool isPerform = false)
        {
            /*" -2555- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-2 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_2()
        {
            /*" -2512- EXEC SQL SELECT VALUE(IND_IOF, 'S' ) INTO :V0SUBG-IND-IOF FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_2_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_IND_IOF, V0SUBG_IND_IOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-LE-SORT-SECTION */
        private void R2300_00_LE_SORT_SECTION()
        {
            /*" -2567- MOVE 'R2300-00-LE-SORT  ' TO PARAGRAFO. */
            _.Move("R2300-00-LE-SORT  ", PARAGRAFO);

            /*" -2569- RETURN SVG4267B AT END */
            try
            {
                SVG4267B.Return(REG_SVG4267B, () =>
                {

                    /*" -2570- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -2572- GO TO R2300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2574- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -2576- MOVE SVA-COD-EMPRESA TO PRODUTO-COD-EMPRESA. */
            _.Move(REG_SVG4267B.SVA_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);

            /*" -2577- IF AC-CONTA GREATER 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -2578- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -2579- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -2579- DISPLAY '*** LIDOS SORT       ' AC-LIDOS ' ' WHORA-CURR. */

                $"*** LIDOS SORT       {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-IDENTIFICA-MSG-SECTION */
        private void R2310_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -2592- MOVE 'R2310-00-IDENTIFICA-MSG' TO PARAGRAFO. */
            _.Move("R2310-00-IDENTIFICA-MSG", PARAGRAFO);

            /*" -2593- MOVE 'VD02.DBM' TO WS-JDE-GER. */
            _.Move("VD02.DBM", AREA_DE_WORK.WS_JDE_GER);

            /*" -2594- IF PRODUTO-COD-EMPRESA = 11 */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA == 11)
            {

                /*" -2595- MOVE 'VIDA25.DBM' TO WS-JDE-GER */
                _.Move("VIDA25.DBM", AREA_DE_WORK.WS_JDE_GER);

                /*" -2596- END-IF */
            }


            /*" -2596- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LC09-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LC09_LINHA09.LC09_FORM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-SECTION */
        private void R2315_00_SELECT_V0MULTIMENS_SECTION()
        {
            /*" -2608- MOVE 'R2315-00-SELECT-V0MULT' TO PARAGRAFO. */
            _.Move("R2315-00-SELECT-V0MULT", PARAGRAFO);

            /*" -2610- MOVE '231' TO WNR-EXEC-SQL */
            _.Move("231", WABEND.WNR_EXEC_SQL);

            /*" -2620- PERFORM R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1 */

            R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1();

            /*" -2623- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2624- DISPLAY 'R2315 - NAO ENCONTRADO NA V0MSGCOBR   ' */
                _.Display($"R2315 - NAO ENCONTRADO NA V0MSGCOBR   ");

                /*" -2625- DISPLAY 'APOLICE     => ' V0MENS-NUM-APOLICE */
                _.Display($"APOLICE     => {V0MENS_NUM_APOLICE}");

                /*" -2626- DISPLAY 'SUBGRUPO    => ' V0MENS-CODSUBES */
                _.Display($"SUBGRUPO    => {V0MENS_CODSUBES}");

                /*" -2627- DISPLAY 'OPERACAO    => ' WHOST-CODOPER */
                _.Display($"OPERACAO    => {WHOST_CODOPER}");

                /*" -2627- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-DB-SELECT-1 */
        public void R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1()
        {
            /*" -2620- EXEC SQL SELECT JDE, JDL INTO :V0MENS-JDE, :V0MENS-JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :V0MENS-NUM-APOLICE AND CODSUBES = :V0MENS-CODSUBES AND COD_OPERACAO = :WHOST-CODOPER END-EXEC. */

            var r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 = new R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1()
            {
                V0MENS_NUM_APOLICE = V0MENS_NUM_APOLICE.ToString(),
                V0MENS_CODSUBES = V0MENS_CODSUBES.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
            };

            var executed_1 = R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1.Execute(r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MENS_JDE, V0MENS_JDE);
                _.Move(executed_1.V0MENS_JDL, V0MENS_JDL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-TRATA-MENSAGEM-SECTION */
        private void R2320_00_TRATA_MENSAGEM_SECTION()
        {
            /*" -2639- MOVE 'R2320-00-TRATA-MEN' TO PARAGRAFO. */
            _.Move("R2320-00-TRATA-MEN", PARAGRAFO);

            /*" -2650- PERFORM R2340-00-SELECT-V0PARCELVA. */

            R2340_00_SELECT_V0PARCELVA_SECTION();

            /*" -2650- PERFORM R2450-00-SELECT-V0COBERPROPVA. */

            R2450_00_SELECT_V0COBERPROPVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2340-00-SELECT-V0PARCELVA-SECTION */
        private void R2340_00_SELECT_V0PARCELVA_SECTION()
        {
            /*" -2663- MOVE 'R2340-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R2340-00-SELECT-V0", PARAGRAFO);

            /*" -2665- MOVE '234' TO WNR-EXEC-SQL. */
            _.Move("234", WABEND.WNR_EXEC_SQL);

            /*" -2679- PERFORM R2340_00_SELECT_V0PARCELVA_DB_SELECT_1 */

            R2340_00_SELECT_V0PARCELVA_DB_SELECT_1();

            /*" -2682- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2683- DISPLAY 'R2340 - NAO ENCONTRADO NA V0PARCELVA' */
                _.Display($"R2340 - NAO ENCONTRADO NA V0PARCELVA");

                /*" -2684- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -2685- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -2687- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2690- COMPUTE WS-VLPRMTOT = V0PARC-PRMVG + V0PARC-PRMAP. */
            AREA_DE_WORK.WS_VLPRMTOT.Value = V0PARC_PRMVG + V0PARC_PRMAP;

            /*" -2693- COMPUTE WS-VLPREMIO = WS-VLPRMTOT - V0PARC-VLMULTA. */
            AREA_DE_WORK.WS_VLPREMIO.Value = AREA_DE_WORK.WS_VLPRMTOT - V0PARC_VLMULTA;

            /*" -2694- COMPUTE WS-VLMULTA = V0PARC-VLMULTA - 1,50. */
            AREA_DE_WORK.WS_VLMULTA.Value = V0PARC_VLMULTA - 1.50;

        }

        [StopWatch]
        /*" R2340-00-SELECT-V0PARCELVA-DB-SELECT-1 */
        public void R2340_00_SELECT_V0PARCELVA_DB_SELECT_1()
        {
            /*" -2679- EXEC SQL SELECT PRMVG + PRMAP - VLMULTA, DTVENCTO, PRMVG, PRMAP, VLMULTA INTO :V0PARC-VLPRMTOT, :V0PARC-DTVENCTO, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-VLMULTA FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :WHOST-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL END-EXEC. */

            var r2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 = new R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
            };

            var executed_1 = R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1.Execute(r2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_VLPRMTOT, V0PARC_VLPRMTOT);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(executed_1.V0PARC_VLMULTA, V0PARC_VLMULTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2340_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-SELECT-V0COBERPROPVA-SECTION */
        private void R2450_00_SELECT_V0COBERPROPVA_SECTION()
        {
            /*" -2706- MOVE 'R2450-00-SELECT-V0COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2450-00-SELECT-V0COBERPROPVA", PARAGRAFO);

            /*" -2712- MOVE '245' TO WNR-EXEC-SQL. */
            _.Move("245", WABEND.WNR_EXEC_SQL);

            /*" -2714- MOVE SVA-DTVENCTO-ORIG TO V0PARC-DTVENCTO-ORIG. */
            _.Move(REG_SVG4267B.SVA_DTVENCTO_ORIG, V0PARC_DTVENCTO_ORIG);

            /*" -2730- PERFORM R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -2733- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2734- DISPLAY 'R2450 - NAO ENCONTRADO NA V0COBERPROPVA' */
                _.Display($"R2450 - NAO ENCONTRADO NA V0COBERPROPVA");

                /*" -2735- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -2736- DISPLAY 'VENCIMENTO  => ' V0PARC-DTVENCTO */
                _.Display($"VENCIMENTO  => {V0PARC_DTVENCTO}");

                /*" -2737- DISPLAY 'PROX VENCIM => ' V0HIST-DTVENCTO */
                _.Display($"PROX VENCIM => {V0HIST_DTVENCTO}");

                /*" -2738- DISPLAY 'VENC ORIGIN => ' V0PARC-DTVENCTO-ORIG */
                _.Display($"VENC ORIGIN => {V0PARC_DTVENCTO_ORIG}");

                /*" -2739- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -2741- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -2742- ELSE */
                }
                else
                {


                    /*" -2743- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2744- END-IF */
                }


                /*" -2744- END-IF. */
            }


        }

        [StopWatch]
        /*" R2450-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -2730- EXEC SQL SELECT IMPMORNATU, VLPREMIO, DTINIVIG, IMPSEGCDC INTO :V0COBE-IMPMORNATU, :V0COBE-VLPREMIO, :V0COBE-DTINIVIG, :V0COBE-IMPSEGCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :WHOST-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

            var r2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                V0PARC_DTVENCTO_ORIG = V0PARC_DTVENCTO_ORIG.ToString(),
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(r2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBE_IMPMORNATU, V0COBE_IMPMORNATU);
                _.Move(executed_1.V0COBE_VLPREMIO, V0COBE_VLPREMIO);
                _.Move(executed_1.V0COBE_DTINIVIG, V0COBE_DTINIVIG);
                _.Move(executed_1.V0COBE_IMPSEGCDG, V0COBE_IMPSEGCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-CALCULA-DIGITO-SECTION */
        private void R2400_00_CALCULA_DIGITO_SECTION()
        {
            /*" -2924- MOVE 'R2400-00-CALCULA-DIGITO' TO PARAGRAFO. */
            _.Move("R2400-00-CALCULA-DIGITO", PARAGRAFO);

            /*" -2925- MOVE WK-NUMERO TO LPARM01 */
            _.Move(AREA_DE_WORK.WK_NUMERO, AREA_DE_WORK.LPARM01X.LPARM01);

            /*" -2927- MOVE ZEROS TO WPARM01-AUX */
            _.Move(0, AREA_DE_WORK.WPARM01_AUX);

            /*" -2928- COMPUTE WCALCULO = LPARM01-15 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_15 * 2;

            /*" -2929- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2931- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2933- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2934- COMPUTE WCALCULO = LPARM01-14 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_14 * 1;

            /*" -2935- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2937- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2939- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2940- COMPUTE WCALCULO = LPARM01-13 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_13 * 2;

            /*" -2941- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2943- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2945- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2946- COMPUTE WCALCULO = LPARM01-12 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_12 * 1;

            /*" -2947- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2949- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2951- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2952- COMPUTE WCALCULO = LPARM01-11 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_11 * 2;

            /*" -2953- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2955- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2957- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2958- COMPUTE WCALCULO = LPARM01-10 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_10 * 1;

            /*" -2959- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2961- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2963- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2964- COMPUTE WCALCULO = LPARM01-9 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_9 * 2;

            /*" -2965- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2967- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2969- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2970- COMPUTE WCALCULO = LPARM01-8 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_8 * 1;

            /*" -2971- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2973- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2975- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2976- COMPUTE WCALCULO = LPARM01-7 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_7 * 2;

            /*" -2977- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2979- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2981- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2982- COMPUTE WCALCULO = LPARM01-6 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_6 * 1;

            /*" -2983- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2985- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2987- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2988- COMPUTE WCALCULO = LPARM01-5 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_5 * 2;

            /*" -2989- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2991- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2993- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -2994- COMPUTE WCALCULO = LPARM01-4 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_4 * 1;

            /*" -2995- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -2997- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -2999- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3000- COMPUTE WCALCULO = LPARM01-3 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_3 * 2;

            /*" -3001- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3003- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -3005- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3006- COMPUTE WCALCULO = LPARM01-2 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_2 * 1;

            /*" -3007- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3009- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -3011- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3012- COMPUTE WCALCULO = LPARM01-1 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_1 * 2;

            /*" -3013- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3015- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_158.WCALCUL1 + AREA_DE_WORK.FILLER_158.WCALCUL2;
            }


            /*" -3017- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3020- DIVIDE WPARM01-AUX BY 10 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(AREA_DE_WORK.WPARM01_AUX, 10, AREA_DE_WORK.WQUOCIENTE, AREA_DE_WORK.WRESTO);

            /*" -3021- IF WRESTO EQUAL ZEROS */

            if (AREA_DE_WORK.WRESTO == 00)
            {

                /*" -3022- MOVE 0 TO LPARM03 */
                _.Move(0, AREA_DE_WORK.LPARM03);

                /*" -3023- ELSE */
            }
            else
            {


                /*" -3026- SUBTRACT WRESTO FROM 10 GIVING LPARM03. */
                AREA_DE_WORK.LPARM03.Value = 10 - AREA_DE_WORK.WRESTO;
            }


            /*" -3026- MOVE LPARM03 TO WK-DIGITO. */
            _.Move(AREA_DE_WORK.LPARM03, AREA_DE_WORK.WK_DIGITO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-CALCULA-DIGITO-11-SECTION */
        private void R2500_00_CALCULA_DIGITO_11_SECTION()
        {
            /*" -3038- MOVE 'R2500-00-CALCULA-DIGITO-11' TO PARAGRAFO. */
            _.Move("R2500-00-CALCULA-DIGITO-11", PARAGRAFO);

            /*" -3039- MOVE W91-NUMERO TO LPARM91 */
            _.Move(AREA_DE_WORK.W91_NUMERO, AREA_DE_WORK.LPARM91X.LPARM91);

            /*" -3041- MOVE ZEROS TO WPARM91-AUX */
            _.Move(0, AREA_DE_WORK.WPARM91_AUX);

            /*" -3085- COMPUTE WPARM91-AUX = LPARM91-1 * 4 + LPARM91-2 * 3 + LPARM91-3 * 2 + LPARM91-4 * 9 + LPARM91-5 * 8 + LPARM91-6 * 7 + LPARM91-7 * 6 + LPARM91-8 * 5 + LPARM91-9 * 4 + LPARM91-10 * 3 + LPARM91-11 * 2 + LPARM91-12 * 9 + LPARM91-13 * 8 + LPARM91-14 * 7 + LPARM91-15 * 6 + LPARM91-16 * 5 + LPARM91-17 * 4 + LPARM91-18 * 3 + LPARM91-19 * 2 + LPARM91-20 * 9 + LPARM91-21 * 8 + LPARM91-22 * 7 + LPARM91-23 * 6 + LPARM91-24 * 5 + LPARM91-25 * 4 + LPARM91-26 * 3 + LPARM91-27 * 2 + LPARM91-28 * 9 + LPARM91-29 * 8 + LPARM91-30 * 7 + LPARM91-31 * 6 + LPARM91-32 * 5 + LPARM91-33 * 4 + LPARM91-34 * 3 + LPARM91-35 * 2 + LPARM91-36 * 9 + LPARM91-37 * 8 + LPARM91-38 * 7 + LPARM91-39 * 6 + LPARM91-40 * 5 + LPARM91-41 * 4 + LPARM91-42 * 3 + LPARM91-43 * 2 */
            AREA_DE_WORK.WPARM91_AUX.Value = AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_1 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_2 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_3 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_4 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_5 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_6 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_7 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_8 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_9 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_10 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_11 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_12 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_13 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_14 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_15 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_16 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_17 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_18 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_19 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_20 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_21 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_22 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_23 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_24 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_25 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_26 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_27 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_28 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_29 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_30 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_31 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_32 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_33 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_34 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_35 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_36 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_37 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_38 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_39 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_40 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_41 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_42 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_43 * 2;

            /*" -3088- DIVIDE WPARM91-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(AREA_DE_WORK.WPARM91_AUX, 11, AREA_DE_WORK.WQUOCIENTE, AREA_DE_WORK.WRESTO);

            /*" -3090- IF WRESTO EQUAL ZEROS OR WRESTO EQUAL 1 */

            if (AREA_DE_WORK.WRESTO == 00 || AREA_DE_WORK.WRESTO == 1)
            {

                /*" -3091- MOVE 1 TO LK-DIGITO */
                _.Move(1, AREA_DE_WORK.LK_DIGITO);

                /*" -3092- ELSE */
            }
            else
            {


                /*" -3095- SUBTRACT WRESTO FROM 11 GIVING LK-DIGITO. */
                AREA_DE_WORK.LK_DIGITO.Value = 11 - AREA_DE_WORK.WRESTO;
            }


            /*" -3095- MOVE LK-DIGITO TO W91-DIGITO. */
            _.Move(AREA_DE_WORK.LK_DIGITO, AREA_DE_WORK.W91_DIGITO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-UPDATE-V0HISTCOBVA-SECTION */
        private void R2600_00_UPDATE_V0HISTCOBVA_SECTION()
        {
            /*" -3107- MOVE 'R2600-00-UPDATE-V0HISTCOBVA' TO PARAGRAFO. */
            _.Move("R2600-00-UPDATE-V0HISTCOBVA", PARAGRAFO);

            /*" -3109- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -3115- PERFORM R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1 */

            R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1();

            /*" -3118- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3119- DISPLAY 'R2600 - NAO ENCONTRADO NA V0HISTCOBVA' */
                _.Display($"R2600 - NAO ENCONTRADO NA V0HISTCOBVA");

                /*" -3120- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -3121- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -3122- DISPLAY 'TITULO      => ' WHOST-NRTIT */
                _.Display($"TITULO      => {WHOST_NRTIT}");

                /*" -3122- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2600-00-UPDATE-V0HISTCOBVA-DB-UPDATE-1 */
        public void R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1()
        {
            /*" -3115- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '0' WHERE NRCERTIF = :WHOST-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL AND NRTIT = :WHOST-NRTIT END-EXEC. */

            var r2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 = new R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
            };

            R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1.Execute(r2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-BUSCA-FONTE-SECTION */
        private void R2650_00_BUSCA_FONTE_SECTION()
        {
            /*" -3133- MOVE '2650' TO WNR-EXEC-SQL */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -3133- MOVE ZEROS TO TB1-IX. */
            _.Move(0, TB1_TABELA_FILIAL.TB1_IX);

            /*" -0- FLUXCONTROL_PERFORM R2650_LOOP */

            R2650_LOOP();

        }

        [StopWatch]
        /*" R2650-LOOP */
        private void R2650_LOOP(bool isPerform = false)
        {
            /*" -3139- ADD 1 TO TB1-IX. */
            TB1_TABELA_FILIAL.TB1_IX.Value = TB1_TABELA_FILIAL.TB1_IX + 1;

            /*" -3140- IF TB1-IX > TB1-ULT-OCOR */

            if (TB1_TABELA_FILIAL.TB1_IX > TB1_TABELA_FILIAL.TB1_ULT_OCOR)
            {

                /*" -3141- GO TO R2650-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;

                /*" -3143- END-IF */
            }


            /*" -3144- IF SVA-FONTE = TB1-FONTE(TB1-IX) */

            if (REG_SVG4267B.SVA_FONTE == TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_FONTE)
            {

                /*" -3145- IF SVA-FONTE = 10 */

                if (REG_SVG4267B.SVA_FONTE == 10)
                {

                    /*" -3147- MOVE SPACES TO LE06-REMETENTE */
                    _.Move("", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE);

                    /*" -3149- MOVE 'MATRIZ ' TO LE06-REMETENTE-S */
                    _.Move("MATRIZ ", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE_S);

                    /*" -3150- ELSE */
                }
                else
                {


                    /*" -3152- MOVE TB1-NOMEFTE(TB1-IX) TO LE06-REMETENTE */
                    _.Move(TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_NOMEFTE, AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE);

                    /*" -3154- MOVE 'FILIAL ' TO LE06-REMETENTE-S */
                    _.Move("FILIAL ", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE_S);

                    /*" -3155- END-IF */
                }


                /*" -3157- MOVE TB1-ENDERFTE(TB1-IX) TO LE07-ENDERECO */
                _.Move(TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_ENDERFTE, AREA_DE_WORK.LC11_LINHA11.LE07_ENDERECO);

                /*" -3159- MOVE TB1-BAIRRO(TB1-IX) TO LE08-BAIRRO */
                _.Move(TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LE08_BAIRRO);

                /*" -3161- MOVE TB1-CIDADE(TB1-IX) TO LE08-CIDADE */
                _.Move(TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_CIDADE, AREA_DE_WORK.LC11_LINHA11.LE08_CIDADE);

                /*" -3163- MOVE TB1-UF(TB1-IX) TO LE08-UF */
                _.Move(TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_UF, AREA_DE_WORK.LC11_LINHA11.LE08_UF);

                /*" -3165- MOVE TB1-CEP(TB1-IX) TO DEST-NUM-CEP */
                _.Move(TB1_TABELA_FILIAL.TB1_TAB_FILIAL.TB1_FILIAL[TB1_TABELA_FILIAL.TB1_IX].TB1_CEP, AREA_DE_WORK.DEST_NUM_CEP);

                /*" -3166- MOVE DEST-CEP TO LE09-CEP */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, AREA_DE_WORK.LC11_LINHA11.LE09_CEP);

                /*" -3167- MOVE DEST-CEP-COMPL TO LE09-CEP-COMPL */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LE09_CEP_COMPL);

                /*" -3168- MOVE ALL '@' TO LE09-CIF */
                _.MoveAll("@", AREA_DE_WORK.LC11_LINHA11.LE09_CIF);

                /*" -3169- MOVE ALL '#' TO LE09-POSTNET */
                _.MoveAll("#", AREA_DE_WORK.LC11_LINHA11.LE09_POSTNET);

                /*" -3170- GO TO R2650-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;

                /*" -3172- END-IF */
            }


            /*" -3173- GO TO R2650-LOOP */
            new Task(() => R2650_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

            /*" -3173- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-SECTION */
        private void R2651_00_BUSCA_ESTIPULANTE_SECTION()
        {
            /*" -3184- MOVE 'R2651-00-BUSCA-EST' TO PARAGRAFO. */
            _.Move("R2651-00-BUSCA-EST", PARAGRAFO);

            /*" -3186- MOVE '2651' TO WNR-EXEC-SQL */
            _.Move("2651", WABEND.WNR_EXEC_SQL);

            /*" -3197- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1();

            /*" -3200- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3201- DISPLAY 'R2651 - NAO ENCONTRADO NA V0SUBGRUPO ' */
                _.Display($"R2651 - NAO ENCONTRADO NA V0SUBGRUPO ");

                /*" -3202- DISPLAY 'APOLICE     => ' WHOST-NRAPOLICE */
                _.Display($"APOLICE     => {WHOST_NRAPOLICE}");

                /*" -3205- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3207- MOVE '265A' TO WNR-EXEC-SQL. */
            _.Move("265A", WABEND.WNR_EXEC_SQL);

            /*" -3214- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2();

            /*" -3217- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3218- DISPLAY 'R2651 - PROBLEMAS NO ACESSO A V0CLIENTE  ' */
                _.Display($"R2651 - PROBLEMAS NO ACESSO A V0CLIENTE  ");

                /*" -3219- DISPLAY 'CLIENTE           => ' V0SUBG-COD-CLIENTE */
                _.Display($"CLIENTE           => {V0SUBG_COD_CLIENTE}");

                /*" -3221- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3223- MOVE '265B' TO WNR-EXEC-SQL. */
            _.Move("265B", WABEND.WNR_EXEC_SQL);

            /*" -3237- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3();

            /*" -3240- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3241- DISPLAY 'R2651 - PROBLEMAS NO ACESSO A V0ENDERECOS' */
                _.Display($"R2651 - PROBLEMAS NO ACESSO A V0ENDERECOS");

                /*" -3242- DISPLAY 'CLIENTE           => ' V0SUBG-COD-CLIENTE */
                _.Display($"CLIENTE           => {V0SUBG_COD_CLIENTE}");

                /*" -3242- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-DB-SELECT-1 */
        public void R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -3197- EXEC SQL SELECT COD_CLIENTE, OCORR_ENDERECO INTO :V0SUBG-COD-CLIENTE, :V0SUBG-OCOREND FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = 0 END-EXEC. */

            var r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1 = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1.Execute(r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_COD_CLIENTE, V0SUBG_COD_CLIENTE);
                _.Move(executed_1.V0SUBG_OCOREND, V0SUBG_OCOREND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2651_99_SAIDA*/

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-DB-SELECT-2 */
        public void R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2()
        {
            /*" -3214- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-RAZAO-E, :V0CLIE-CNPJ-E FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0SUBG-COD-CLIENTE END-EXEC. */

            var r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1 = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1()
            {
                V0SUBG_COD_CLIENTE = V0SUBG_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1.Execute(r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO_E, V0CLIE_NOME_RAZAO_E);
                _.Move(executed_1.V0CLIE_CNPJ_E, V0CLIE_CNPJ_E);
            }


        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-SECTION */
        private void R2652_00_BUSCA_PARCELA_SECTION()
        {
            /*" -3254- MOVE 'R2652-00-BUSCA-PAR' TO PARAGRAFO. */
            _.Move("R2652-00-BUSCA-PAR", PARAGRAFO);

            /*" -3256- MOVE '2652' TO WNR-EXEC-SQL */
            _.Move("2652", WABEND.WNR_EXEC_SQL);

            /*" -3257- MOVE SVA-NRCERTIF TO V0PARC-NRCERTIF. */
            _.Move(REG_SVG4267B.SVA_NRCERTIF, V0PARC_NRCERTIF);

            /*" -3259- MOVE SVA-NRPARCEL TO V0PARC-NRPARCEL. */
            _.Move(REG_SVG4267B.SVA_NRPARCEL, V0PARC_NRPARCEL);

            /*" -3265- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_1 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_1();

            /*" -3268- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3269- DISPLAY 'R2652 - NAO ENCONTRADO NA V0PARCELVA ' */
                _.Display($"R2652 - NAO ENCONTRADO NA V0PARCELVA ");

                /*" -3270- DISPLAY 'CERTIFICADO => ' V0PARC-NRCERTIF */
                _.Display($"CERTIFICADO => {V0PARC_NRCERTIF}");

                /*" -3271- DISPLAY 'PARCELA     => ' V0PARC-NRPARCEL */
                _.Display($"PARCELA     => {V0PARC_NRPARCEL}");

                /*" -3274- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3297- MOVE '265F' TO WNR-EXEC-SQL. */
            _.Move("265F", WABEND.WNR_EXEC_SQL);

            /*" -3310- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_2 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_2();

            /*" -3313- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3314- DISPLAY 'R2652 - PROBLEMAS NO ACESSO A V0COBERPROPVA ' */
                _.Display($"R2652 - PROBLEMAS NO ACESSO A V0COBERPROPVA ");

                /*" -3315- DISPLAY 'CERTIFICADO       => ' V0PARC-NRCERTIF */
                _.Display($"CERTIFICADO       => {V0PARC_NRCERTIF}");

                /*" -3316- DISPLAY 'PARCELA           => ' V0PARC-NRPARCEL */
                _.Display($"PARCELA           => {V0PARC_NRPARCEL}");

                /*" -3317- DISPLAY 'DTVENCTO          => ' V0HIST-DTVENCTO */
                _.Display($"DTVENCTO          => {V0HIST_DTVENCTO}");

                /*" -3318- DISPLAY 'VENCT ORIGINAL    => ' V0PARC-DTVENCTO-ORIG */
                _.Display($"VENCT ORIGINAL    => {V0PARC_DTVENCTO_ORIG}");

                /*" -3320- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3324- MOVE '265G' TO WNR-EXEC-SQL. */
            _.Move("265G", WABEND.WNR_EXEC_SQL);

            /*" -3325- IF SVA-CODPRODU = 9313 OR 7701 */

            if (REG_SVG4267B.SVA_CODPRODU.In("9313", "7701"))
            {

                /*" -3330- STRING SVA-DTVENCTO-ORIG(1:8) SVA-DTQITBCO(9:2) DELIMITED BY SIZE INTO V0COBP-DTINIVIG-PARC END-STRING */
                #region STRING
                var spl1 = REG_SVG4267B.SVA_DTVENCTO_ORIG.Substring(1, 8).GetMoveValues();
                var spl2 = REG_SVG4267B.SVA_DTQITBCO.Substring(9, 2).GetMoveValues();
                var results3 = spl1 + spl2;
                _.Move(results3, V0COBP_DTINIVIG_PARC);
                #endregion

                /*" -3331- IF V0COBP-DTINIVIG-PARC >= SVA-DTVENCTO-ORIG */

                if (V0COBP_DTINIVIG_PARC >= REG_SVG4267B.SVA_DTVENCTO_ORIG)
                {

                    /*" -3333- PERFORM R2655-00-CALCULA-INIVIGENCIA UNTIL V0COBP-DTINIVIG-PARC < SVA-DTVENCTO-ORIG */

                    while (!(V0COBP_DTINIVIG_PARC < REG_SVG4267B.SVA_DTVENCTO_ORIG))
                    {

                        R2655_00_CALCULA_INIVIGENCIA_SECTION();
                    }

                    /*" -3334- END-IF */
                }


                /*" -3335- ELSE */
            }
            else
            {


                /*" -3336- IF (WHOST-NRAPOLICE EQUAL 109300002554) */

                if ((WHOST_NRAPOLICE == 109300002554))
                {

                    /*" -3348- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_3 */

                    R2652_00_BUSCA_PARCELA_DB_SELECT_3();

                    /*" -3351- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3352- DISPLAY 'R2652-ERRO-CYRELA SEM VG-VIGENCIA-FATURA' */
                        _.Display($"R2652-ERRO-CYRELA SEM VG-VIGENCIA-FATURA");

                        /*" -3353- DISPLAY 'CERTIFICADO = ' V0PARC-NRCERTIF */
                        _.Display($"CERTIFICADO = {V0PARC_NRCERTIF}");

                        /*" -3354- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3355- END-IF */
                    }


                    /*" -3356- ELSE */
                }
                else
                {


                    /*" -3357- MOVE V0PARC-DTVENCTO-ORIG TO WS-DTCALC-PARC */
                    _.Move(V0PARC_DTVENCTO_ORIG, WS_DTCALC_PARC);

                    /*" -3359- MOVE V0COBP-DTINIVIG-PARC TO WS-DTINIVIG-PARC */
                    _.Move(V0COBP_DTINIVIG_PARC, WS_DTINIVIG_PARC);

                    /*" -3361- MOVE 'NAO' TO WS-FLAG-CALC-PARC */
                    _.Move("NAO", WS_FLAG_CALC_PARC);

                    /*" -3364- PERFORM R2657-00-CALCULA-TERVIGENCIA UNTIL WS-FLAG-CALC-PARC EQUAL 'SIM' */

                    while (!(WS_FLAG_CALC_PARC == "SIM"))
                    {

                        R2657_00_CALCULA_TERVIGENCIA_SECTION();
                    }

                    /*" -3365- MOVE WS-DTINIVIG-PARC TO V0COBP-DTINIVIG-PARC */
                    _.Move(WS_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);

                    /*" -3366- END-IF */
                }


                /*" -3389- END-IF. */
            }


            /*" -3391- MOVE '265H' TO WNR-EXEC-SQL. */
            _.Move("265H", WABEND.WNR_EXEC_SQL);

            /*" -3398- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_4 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_4();

            /*" -3401- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3402- DISPLAY 'R2652 - PROBLEMAS NO ACESSO A V1RAMOIND     ' */
                _.Display($"R2652 - PROBLEMAS NO ACESSO A V1RAMOIND     ");

                /*" -3403- DISPLAY 'RAMO              =>   93' */
                _.Display($"RAMO              =>   93");

                /*" -3404- DISPLAY 'DTVENCTO          => ' V0PARC-DTVENCTO-ORIG */
                _.Display($"DTVENCTO          => {V0PARC_DTVENCTO_ORIG}");

                /*" -3406- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3406- COMPUTE SQL-PCIOF = 1 + (SQL-PCIOF / 100). */
            SQL_PCIOF.Value = 1 + (SQL_PCIOF / 100f);

        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-1 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_1()
        {
            /*" -3265- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO-ORIG FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PARC-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1()
            {
                V0PARC_NRCERTIF = V0PARC_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO_ORIG, V0PARC_DTVENCTO_ORIG);
            }


        }

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-DB-SELECT-3 */
        public void R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3()
        {
            /*" -3237- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :V0ENDE-ENDERECO-E, :V0ENDE-BAIRRO-E, :V0ENDE-CIDADE-E, :V0ENDE-UF-E, :V0ENDE-CEP-E FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0SUBG-COD-CLIENTE AND OCORR_ENDERECO = :V0SUBG-OCOREND END-EXEC. */

            var r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1 = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1()
            {
                V0SUBG_COD_CLIENTE = V0SUBG_COD_CLIENTE.ToString(),
                V0SUBG_OCOREND = V0SUBG_OCOREND.ToString(),
            };

            var executed_1 = R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1.Execute(r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDERECO_E, V0ENDE_ENDERECO_E);
                _.Move(executed_1.V0ENDE_BAIRRO_E, V0ENDE_BAIRRO_E);
                _.Move(executed_1.V0ENDE_CIDADE_E, V0ENDE_CIDADE_E);
                _.Move(executed_1.V0ENDE_UF_E, V0ENDE_UF_E);
                _.Move(executed_1.V0ENDE_CEP_E, V0ENDE_CEP_E);
            }


        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-2 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_2()
        {
            /*" -3310- EXEC SQL SELECT DTINIVIG, QUANT_VIDAS, IMPSEGUR, OCORHIST INTO :V0COBP-DTINIVIG-PARC, :V0COBP-QUANT-VIDAS, :V0COBP-IMPSEGUR, :V0COBP-OCORHIST FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PARC-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1()
            {
                V0PARC_DTVENCTO_ORIG = V0PARC_DTVENCTO_ORIG.ToString(),
                V0PARC_NRCERTIF = V0PARC_NRCERTIF.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);
                _.Move(executed_1.V0COBP_QUANT_VIDAS, V0COBP_QUANT_VIDAS);
                _.Move(executed_1.V0COBP_IMPSEGUR, V0COBP_IMPSEGUR);
                _.Move(executed_1.V0COBP_OCORHIST, V0COBP_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2652_99_SAIDA*/

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-3 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_3()
        {
            /*" -3348- EXEC SQL SELECT DTA_INI_FATURA INTO :V0COBP-DTINIVIG-PARC FROM SEGUROS.VG_VIGENCIA_FATURA WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = 0 AND SEQ_FATURAMENTO = (SELECT MAX(T1.SEQ_FATURAMENTO) FROM SEGUROS.VG_VIGENCIA_FATURA T1 WHERE T1.NUM_APOLICE = :WHOST-NRAPOLICE AND T1.COD_SUBGRUPO = 0 AND T1.IND_PROCESSAMENTO <> 'NP' ) END-EXEC */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);
            }


        }

        [StopWatch]
        /*" R2655-00-CALCULA-INIVIGENCIA-SECTION */
        private void R2655_00_CALCULA_INIVIGENCIA_SECTION()
        {
            /*" -3415- MOVE 'R2700-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R2700-00-SELECT-V0", PARAGRAFO);

            /*" -3417- MOVE '265I' TO WNR-EXEC-SQL. */
            _.Move("265I", WABEND.WNR_EXEC_SQL);

            /*" -3418- IF (V0OPCP-PERIPGTO <= ZEROS) */

            if ((V0OPCP_PERIPGTO <= 00))
            {

                /*" -3419- MOVE 1 TO V0OPCP-PERIPGTO */
                _.Move(1, V0OPCP_PERIPGTO);

                /*" -3421- END-IF */
            }


            /*" -3428- PERFORM R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1 */

            R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1();

            /*" -3431- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3432- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3433- END-IF. */
            }


        }

        [StopWatch]
        /*" R2655-00-CALCULA-INIVIGENCIA-DB-SELECT-1 */
        public void R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1()
        {
            /*" -3428- EXEC SQL SELECT DATE(:V0COBP-DTINIVIG-PARC) - (:V0OPCP-PERIPGTO) MONTHS INTO :V0COBP-DTINIVIG-PARC FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC */

            var r2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1_Query1 = new R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1_Query1()
            {
                V0COBP_DTINIVIG_PARC = V0COBP_DTINIVIG_PARC.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
            };

            var executed_1 = R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1_Query1.Execute(r2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);
            }


        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-4 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_4()
        {
            /*" -3398- EXEC SQL SELECT PCIOF INTO :SQL-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = 93 AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1()
            {
                V0PARC_DTVENCTO_ORIG = V0PARC_DTVENCTO_ORIG.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_PCIOF, SQL_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2655_99_SAIDA*/

        [StopWatch]
        /*" R2657-00-CALCULA-TERVIGENCIA-SECTION */
        private void R2657_00_CALCULA_TERVIGENCIA_SECTION()
        {
            /*" -3441- MOVE 'R2657-00-CALCULA-T' TO PARAGRAFO. */
            _.Move("R2657-00-CALCULA-T", PARAGRAFO);

            /*" -3443- MOVE '267I' TO WNR-EXEC-SQL. */
            _.Move("267I", WABEND.WNR_EXEC_SQL);

            /*" -3444- IF (V0OPCP-PERIPGTO <= ZEROS) */

            if ((V0OPCP_PERIPGTO <= 00))
            {

                /*" -3445- MOVE 1 TO V0OPCP-PERIPGTO */
                _.Move(1, V0OPCP_PERIPGTO);

                /*" -3447- END-IF */
            }


            /*" -3459- PERFORM R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1 */

            R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1();

            /*" -3462- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3463- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3465- END-IF. */
            }


            /*" -3466- IF (WS-QTD-DIAS-PARC IS NEGATIVE) */

            if ((WS_QTD_DIAS_PARC < 0))
            {

                /*" -3467- MOVE 'NAO' TO WS-FLAG-CALC-PARC */
                _.Move("NAO", WS_FLAG_CALC_PARC);

                /*" -3468- MOVE WS-DTTERVIG-PARC TO WS-DTINIVIG-PARC */
                _.Move(WS_DTTERVIG_PARC, WS_DTINIVIG_PARC);

                /*" -3469- ELSE */
            }
            else
            {


                /*" -3470- MOVE 'SIM' TO WS-FLAG-CALC-PARC */
                _.Move("SIM", WS_FLAG_CALC_PARC);

                /*" -3471- END-IF. */
            }


        }

        [StopWatch]
        /*" R2657-00-CALCULA-TERVIGENCIA-DB-SELECT-1 */
        public void R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1()
        {
            /*" -3459- EXEC SQL SELECT DATE(:WS-DTINIVIG-PARC) + (:V0OPCP-PERIPGTO) MONTHS, DATE(:WS-DTINIVIG-PARC) + (:V0OPCP-PERIPGTO) MONTHS - 1 DAYS - DATE(:WS-DTCALC-PARC) INTO :WS-DTTERVIG-PARC, :WS-QTD-DIAS-PARC FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC */

            var r2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1 = new R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1()
            {
                WS_DTINIVIG_PARC = WS_DTINIVIG_PARC.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                WS_DTCALC_PARC = WS_DTCALC_PARC.ToString(),
            };

            var executed_1 = R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1.Execute(r2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DTTERVIG_PARC, WS_DTTERVIG_PARC);
                _.Move(executed_1.WS_QTD_DIAS_PARC, WS_QTD_DIAS_PARC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2657_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-V0PRODUTOSVG-SECTION */
        private void R2700_00_SELECT_V0PRODUTOSVG_SECTION()
        {
            /*" -3482- MOVE 'R2700-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R2700-00-SELECT-V0", PARAGRAFO);

            /*" -3484- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", WABEND.WNR_EXEC_SQL);

            /*" -3496- PERFORM R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1 */

            R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1();

            /*" -3499- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3500- DISPLAY 'R2700 - PROBLEMAS NO ACESSO A V0PRODUTOSVG' */
                _.Display($"R2700 - PROBLEMAS NO ACESSO A V0PRODUTOSVG");

                /*" -3502- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'CODSUBES    - ' WHOST-CODSUBES */

                $"NUM_APOLICE - {WHOST_NRAPOLICE} CODSUBES    - {WHOST_CODSUBES}"
                .Display();

                /*" -3504- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3505- IF VIND-TEMCDG LESS ZEROES */

            if (VIND_TEMCDG < 00)
            {

                /*" -3505- MOVE SPACES TO V0PROD-TEM-CDG. */
                _.Move("", V0PROD_TEM_CDG);
            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-V0PRODUTOSVG-DB-SELECT-1 */
        public void R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1()
        {
            /*" -3496- EXEC SQL SELECT NOMPRODU, CODCDT, CODPRODU, TEM_CDG INTO :V0PROD-NOMPRODU, :V0PROD-CODCDT, :V0PROD-CODPRODU, :V0PROD-TEM-CDG:VIND-TEMCDG FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND CODSUBES = :WHOST-CODSUBES END-EXEC. */

            var r2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 = new R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1.Execute(r2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_NOMPRODU, V0PROD_NOMPRODU);
                _.Move(executed_1.V0PROD_CODCDT, V0PROD_CODCDT);
                _.Move(executed_1.V0PROD_CODPRODU, V0PROD_CODPRODU);
                _.Move(executed_1.V0PROD_TEM_CDG, V0PROD_TEM_CDG);
                _.Move(executed_1.VIND_TEMCDG, VIND_TEMCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-SELECT-V0PRODUTOSVG-SECTION */
        private void R2710_00_SELECT_V0PRODUTOSVG_SECTION()
        {
            /*" -3517- MOVE 'R2710-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R2710-00-SELECT-V0", PARAGRAFO);

            /*" -3519- MOVE '271' TO WNR-EXEC-SQL. */
            _.Move("271", WABEND.WNR_EXEC_SQL);

            /*" -3534- PERFORM R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1 */

            R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1();

            /*" -3537- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3538- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3539- MOVE SPACES TO V0PROD-ESTR-COBR */
                    _.Move("", V0PROD_ESTR_COBR);

                    /*" -3540- MOVE -1 TO V0PROD-ESTR-COBR-I */
                    _.Move(-1, V0PROD_ESTR_COBR_I);

                    /*" -3541- MOVE SPACES TO V0PROD-ORIG-PRODU */
                    _.Move("", V0PROD_ORIG_PRODU);

                    /*" -3542- MOVE -1 TO V0PROD-ORIG-PRODU-I */
                    _.Move(-1, V0PROD_ORIG_PRODU_I);

                    /*" -3543- ELSE */
                }
                else
                {


                    /*" -3544- DISPLAY 'R2710 - PROBLEMAS NO ACESSO A V0PRODUTOSVG' */
                    _.Display($"R2710 - PROBLEMAS NO ACESSO A V0PRODUTOSVG");

                    /*" -3546- DISPLAY 'NUM_APOLICE - ' V0HIST-NRAPOLICE ' ' 'CODSUBES    - ' V0HIST-CODSUBES */

                    $"NUM_APOLICE - {V0HIST_NRAPOLICE} CODSUBES    - {V0HIST_CODSUBES}"
                    .Display();

                    /*" -3546- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-V0PRODUTOSVG-DB-SELECT-1 */
        public void R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1()
        {
            /*" -3534- EXEC SQL SELECT NUM_APOLICE, CODSUBES , ESTR_COBR , ORIG_PRODU INTO :V0PROD-NUM-APOLICE, :V0PROD-CODSUBES , :V0PROD-ESTR-COBR:V0PROD-ESTR-COBR-I, :V0PROD-ORIG-PRODU:V0PROD-ORIG-PRODU-I FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V0HIST-NRAPOLICE AND CODSUBES = :V0HIST-CODSUBES END-EXEC. */

            var r2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 = new R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1()
            {
                V0HIST_NRAPOLICE = V0HIST_NRAPOLICE.ToString(),
                V0HIST_CODSUBES = V0HIST_CODSUBES.ToString(),
            };

            var executed_1 = R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1.Execute(r2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_NUM_APOLICE, V0PROD_NUM_APOLICE);
                _.Move(executed_1.V0PROD_CODSUBES, V0PROD_CODSUBES);
                _.Move(executed_1.V0PROD_ESTR_COBR, V0PROD_ESTR_COBR);
                _.Move(executed_1.V0PROD_ESTR_COBR_I, V0PROD_ESTR_COBR_I);
                _.Move(executed_1.V0PROD_ORIG_PRODU, V0PROD_ORIG_PRODU);
                _.Move(executed_1.V0PROD_ORIG_PRODU_I, V0PROD_ORIG_PRODU_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2711-00-SELECT-V0PRODUTOSVG-SECTION */
        private void R2711_00_SELECT_V0PRODUTOSVG_SECTION()
        {
            /*" -3558- MOVE 'R2711-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R2711-00-SELECT-V0", PARAGRAFO);

            /*" -3560- MOVE '27X' TO WNR-EXEC-SQL. */
            _.Move("27X", WABEND.WNR_EXEC_SQL);

            /*" -3568- PERFORM R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1 */

            R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1();

            /*" -3571- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3572- DISPLAY 'R2711 - PROBLEMAS NO ACESSO A V0PRODUTOSVG' */
                _.Display($"R2711 - PROBLEMAS NO ACESSO A V0PRODUTOSVG");

                /*" -3574- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'CODSUBES    - ' WHOST-CODSUBES */

                $"NUM_APOLICE - {WHOST_NRAPOLICE} CODSUBES    - {WHOST_CODSUBES}"
                .Display();

                /*" -3574- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2711-00-SELECT-V0PRODUTOSVG-DB-SELECT-1 */
        public void R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1()
        {
            /*" -3568- EXEC SQL SELECT CODCDT INTO :V0PROD-CODCDT FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND CODSUBES = :WHOST-CODSUBES END-EXEC. */

            var r2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 = new R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1.Execute(r2711_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_CODCDT, V0PROD_CODCDT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2711_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-SELECT-V0CEDENTE-SECTION */
        private void R2800_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -3586- MOVE 'R2800-00-SELECT-V0CEDENTE' TO PARAGRAFO. */
            _.Move("R2800-00-SELECT-V0CEDENTE", PARAGRAFO);

            /*" -3588- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", WABEND.WNR_EXEC_SQL);

            /*" -3601- PERFORM R2800_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R2800_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -3604- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3605- DISPLAY 'R2800 - PROBLEMAS NO ACESSO A V0CEDENTE' */
                _.Display($"R2800 - PROBLEMAS NO ACESSO A V0CEDENTE");

                /*" -3608- DISPLAY 'CODCDT      ' V0PROD-CODCDT 'NUM_APOLICE ' WHOST-NRAPOLICE 'CODSUBES    ' WHOST-CODSUBES */

                $"CODCDT      {V0PROD_CODCDT}NUM_APOLICE {WHOST_NRAPOLICE}CODSUBES    {WHOST_CODSUBES}"
                .Display();

                /*" -3608- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R2800_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -3601- EXEC SQL SELECT NOMCDT, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA INTO :V0CEDE-NOMECED, :V0CEDE-AGENCIA, :V0CEDE-OPERACAO, :V0CEDE-CONTA, :V0CEDE-DIGCC FROM SEGUROS.V0CEDENTE WHERE CODCDT = :V0PROD-CODCDT END-EXEC. */

            var r2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 = new R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1()
            {
                V0PROD_CODCDT = V0PROD_CODCDT.ToString(),
            };

            var executed_1 = R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1.Execute(r2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CEDE_NOMECED, V0CEDE_NOMECED);
                _.Move(executed_1.V0CEDE_AGENCIA, V0CEDE_AGENCIA);
                _.Move(executed_1.V0CEDE_OPERACAO, V0CEDE_OPERACAO);
                _.Move(executed_1.V0CEDE_CONTA, V0CEDE_CONTA);
                _.Move(executed_1.V0CEDE_DIGCC, V0CEDE_DIGCC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-TRATA-V0RELATORIOS-SECTION */
        private void R2900_00_TRATA_V0RELATORIOS_SECTION()
        {
            /*" -3620- MOVE 'R2900-00-TRATA-V0RELATORIOS' TO PARAGRAFO. */
            _.Move("R2900-00-TRATA-V0RELATORIOS", PARAGRAFO);

            /*" -3622- PERFORM R2910-00-OBTEM-NUMERACAO. */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -3624- MOVE V0RELA-NRCOPIAS TO LR02-SEQ. */
            _.Move(V0RELA_NRCOPIAS, AREA_DE_WORK.LR07_LINHA07.LR02_SEQ);

            /*" -3625- MOVE V1SIST-DTMOVABE TO WS-DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3626- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -3627- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -3628- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -3632- MOVE WS-DATA TO LC09-DTEMISSAO LC11-DTEMISSAO LC09-DTPROCES. */
            _.Move(AREA_DE_WORK.WS_DATA, AREA_DE_WORK.LC11_LINHA11.LC09_DTEMISSAO, AREA_DE_WORK.LC11_LINHA11.LC11_DTEMISSAO, AREA_DE_WORK.LC11_LINHA11.LC09_DTPROCES);

            /*" -3634- MOVE TBM-MES(WS-MES-SQL) TO LR02-MES. */
            _.Move(TBM_TABELA_MESES.TBM_TBM_MESES_R.TBM_MES[AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL], AREA_DE_WORK.LR07_LINHA07.LR02_MES);

            /*" -3637- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", AREA_DE_WORK.WS_DATA_I.FILLERB1, AREA_DE_WORK.WS_DATA_I.FILLERB2);

            /*" -3638- MOVE WS-ANO-SQL TO LK-ANO-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC);

            /*" -3639- MOVE WS-MES-SQL TO LK-MES-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC);

            /*" -3641- MOVE WS-DIA-SQL TO LK-DIA-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC);

            /*" -3643- PERFORM R2920-00-CALC-DIAS-UTEIS. */

            R2920_00_CALC_DIAS_UTEIS_SECTION();

            /*" -3644- MOVE LK-DIA-CALC TO WS-DIA-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -3645- MOVE LK-MES-CALC TO WS-MES-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -3646- MOVE LK-ANO-CALC TO WS-ANO-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC, AREA_DE_WORK.WS_DATA_I.WS_ANO_I);

            /*" -3647- MOVE WS-DATA-I TO LR04-DATA. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LR09_LINHA09.LR04_DATA);

            /*" -3647- MOVE 'XX/XX/XXXX' TO LE01-DTPOSTAGEM. */
            _.Move("XX/XX/XXXX", AREA_DE_WORK.LC11_LINHA11.LE01_DTPOSTAGEM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-SECTION */
        private void R2910_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -3659- MOVE 'R2910-00-OBTEM-NUMERACAO' TO PARAGRAFO. */
            _.Move("R2910-00-OBTEM-NUMERACAO", PARAGRAFO);

            /*" -3661- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -3668- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -3671- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3672- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3673- MOVE ZEROS TO V0RELA-NRCOPIAS */
                    _.Move(0, V0RELA_NRCOPIAS);

                    /*" -3674- ELSE */
                }
                else
                {


                    /*" -3675- DISPLAY 'R2910 - PROBLEMAS SELECT V0RELATORIOS' */
                    _.Display($"R2910 - PROBLEMAS SELECT V0RELATORIOS");

                    /*" -3677- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3678- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -3678- MOVE ZEROS TO V0RELA-NRCOPIAS. */
                _.Move(0, V0RELA_NRCOPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -3668- EXEC SQL SELECT MAX(NRCOPIAS) INTO :V0RELA-NRCOPIAS:VIND-NRCOPIAS FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER END-EXEC. */

            var r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
            };

            var executed_1 = R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_NRCOPIAS, V0RELA_NRCOPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO */
        private void R2910_10_INCLUI_RELATORIO(bool isPerform = false)
        {
            /*" -3685- MOVE 'R0000-00-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R0000-00-PRINCIPAL", PARAGRAFO);

            /*" -3687- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -3689- ADD 1 TO V0RELA-NRCOPIAS. */
            V0RELA_NRCOPIAS.Value = V0RELA_NRCOPIAS + 1;

            /*" -3732- PERFORM R2910_10_INCLUI_RELATORIO_DB_INSERT_1 */

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -3735- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -3736- DISPLAY 'R2910 - (REGISTRO DUPLICADO) ... ' */
                _.Display($"R2910 - (REGISTRO DUPLICADO) ... ");

                /*" -3738- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3740- DISPLAY 'R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -3742- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3742- ADD 1 TO AC-I-RELATORIOS. */
            AREA_DE_WORK.AC_I_RELATORIOS.Value = AREA_DE_WORK.AC_I_RELATORIOS + 1;

        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void R2910_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -3732- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'EM0600B' , :V1SIST-DTMOVABE, 'EM' , 'CARTAECT' , :V0RELA-NRCOPIAS, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-MESREFER, :V1SIST-ANOREFER, 0, 0, 0, 0, 0, 0, :WHOST-NRAPOLICE, 0, 0, 0, 0, :WHOST-CODSUBES, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 = new R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
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
            /*" -3754- MOVE 'R2920-00-CALC-DIAS-UTEIS' TO PARAGRAFO. */
            _.Move("R2920-00-CALC-DIAS-UTEIS", PARAGRAFO);

            /*" -3755- MOVE LK-DATA-CALC TO LK-DATA-SOM. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_SOM);

            /*" -3755- CALL 'PROSOCU1' USING LK-PROSOMU1. */
            _.Call("PROSOCU1", AREA_DE_WORK.LK_PROSOMU1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRIME-LST-SECTION */
        private void R3000_00_IMPRIME_LST_SECTION()
        {
            /*" -3767- MOVE 'R3000-00-IMPRIME-LST' TO PARAGRAFO. */
            _.Move("R3000-00-IMPRIME-LST", PARAGRAFO);

            /*" -3769- MOVE 1 TO TB2-IX. */
            _.Move(1, TB2_TABELA_FAIXA_CEP.TB2_IX);

            /*" -3769- WRITE FVG4267B-RECORD FROM LR02-LINHA02. */
            _.Move(AREA_DE_WORK.LR02_LINHA02.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP_OCORR */

            R3000_10_LOOP_OCORR();

        }

        [StopWatch]
        /*" R3000-10-LOOP-OCORR */
        private void R3000_10_LOOP_OCORR(bool isPerform = false)
        {
            /*" -3776- MOVE 'R3000-10-LOOP-OCOR' TO PARAGRAFO. */
            _.Move("R3000-10-LOOP-OCOR", PARAGRAFO);

            /*" -3777- IF TB2-IX GREATER TB2-ULT-OCOR */

            if (TB2_TABELA_FAIXA_CEP.TB2_IX > TB2_TABELA_FAIXA_CEP.TB2_ULT_OCOR)
            {

                /*" -3778- MOVE 1 TO TB2-IX */
                _.Move(1, TB2_TABELA_FAIXA_CEP.TB2_IX);

                /*" -3779- GO TO R3000-20-INT */

                R3000_20_INT(); //GOTO
                return;

                /*" -3781- END-IF */
            }


            /*" -3782- IF TB3-QTD-OBJ(TB2-IX) NOT EQUAL ZEROS */

            if (TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_QTD_OBJ != 00)
            {

                /*" -3783- ADD 1 TO WS-OCORR */
                AREA_DE_WORK.WS_OCORR.Value = AREA_DE_WORK.WS_OCORR + 1;

                /*" -3785- END-IF */
            }


            /*" -3786- ADD 1 TO TB2-IX. */
            TB2_TABELA_FAIXA_CEP.TB2_IX.Value = TB2_TABELA_FAIXA_CEP.TB2_IX + 1;

            /*" -3786- GO TO R3000-10-LOOP-OCORR. */
            new Task(() => R3000_10_LOOP_OCORR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3000-20-INT */
        private void R3000_20_INT(bool isPerform = false)
        {
            /*" -3793- MOVE 'R3000-20-INT      ' TO PARAGRAFO. */
            _.Move("R3000-20-INT      ", PARAGRAFO);

            /*" -3794- COMPUTE WWORK-QTDE = (WS-OCORR / 18) */
            AREA_DE_WORK.WWORK_QTDE.Value = (AREA_DE_WORK.WS_OCORR / 18f);

            /*" -3795- IF WWORK-QTDE12 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE12 != 00)
            {

                /*" -3797- COMPUTE WWORK-QTDE11 = WWORK-QTDE11 + 1. */
                AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11.Value = AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11 + 1;
            }


            /*" -3797- MOVE WWORK-QTDE11 TO LR02-PAG-FINAL. */
            _.Move(AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11, AREA_DE_WORK.LR10_LINHA10.LR02_PAG_FINAL);

        }

        [StopWatch]
        /*" R3000-30-LOOP-CABEC */
        private void R3000_30_LOOP_CABEC(bool isPerform = false)
        {
            /*" -3824- MOVE 'R3000-30-LOOP     ' TO PARAGRAFO. */
            _.Move("R3000-30-LOOP     ", PARAGRAFO);

            /*" -3825- IF TB2-IX GREATER TB2-ULT-OCOR */

            if (TB2_TABELA_FAIXA_CEP.TB2_IX > TB2_TABELA_FAIXA_CEP.TB2_ULT_OCOR)
            {

                /*" -3826- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -3827- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -3829- END-IF */
            }


            /*" -3830- IF TB3-QTD-OBJ(TB2-IX) = ZEROS */

            if (TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_QTD_OBJ == 00)
            {

                /*" -3831- ADD 1 TO TB2-IX */
                TB2_TABELA_FAIXA_CEP.TB2_IX.Value = TB2_TABELA_FAIXA_CEP.TB2_IX + 1;

                /*" -3832- GO TO R3000-30-LOOP-CABEC */
                new Task(() => R3000_30_LOOP_CABEC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3834- END-IF */
            }


            /*" -3836- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -3838- MOVE AC-PAGINA TO LR02-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LR10_LINHA10.LR02_PAGINA);

            /*" -3839- IF AC-PAGINA GREATER 1 */

            if (AREA_DE_WORK.AC_PAGINA > 1)
            {

                /*" -3840- WRITE FVG4267B-RECORD FROM LR13-LINHA13 */
                _.Move(AREA_DE_WORK.LR13_LINHA13.GetMoveValues(), FVG4267B_RECORD);

                FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

                /*" -3842- END-IF */
            }


            /*" -3844- PERFORM R3010-00-CABECALHOS. */

            R3010_00_CABECALHOS_SECTION();

            /*" -3845- WRITE FVG4267B-RECORD FROM LR10-LINHA10. */
            _.Move(AREA_DE_WORK.LR10_LINHA10.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3847- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AREA_DE_WORK.AC_LINHAS);

            /*" -3848- MOVE TB2-FX-INI(TB2-IX) TO WS-NUM-CEP-AUX. */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3849- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPI);

            /*" -3850- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPI);

            /*" -3851- MOVE TB2-FX-FIM(TB2-IX) TO WS-NUM-CEP-AUX. */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3852- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPF);

            /*" -3853- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPF);

            /*" -3854- MOVE TB3-OBJI(TB2-IX) TO LR05-OBJI. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_OBJI, AREA_DE_WORK.LR12_LINHA12.LR05_OBJI);

            /*" -3855- MOVE TB3-OBJF(TB2-IX) TO LR05-OBJF. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_OBJF, AREA_DE_WORK.LR12_LINHA12.LR05_OBJF);

            /*" -3856- MOVE TB3-AMARI(TB2-IX) TO LR05-AMARI. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_AMARI, AREA_DE_WORK.LR12_LINHA12.LR05_AMARI);

            /*" -3857- MOVE TB3-AMARF(TB2-IX) TO LR05-AMARF. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_AMARF, AREA_DE_WORK.LR12_LINHA12.LR05_AMARF);

            /*" -3858- MOVE TB3-QTD-OBJ(TB2-IX) TO LR05-QTD-OBJ. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_QTD_OBJ, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_OBJ);

            /*" -3859- MOVE TB3-QTD-AMAR(TB2-IX) TO LR05-QTD-AMAR. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_QTD_AMAR, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_AMAR);

            /*" -3861- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR12_LINHA12.LR05_OBS);

            /*" -3861- WRITE FVG4267B-RECORD FROM LR12-LINHA12. */
            _.Move(AREA_DE_WORK.LR12_LINHA12.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R3000-40-LOOP-DET */
        private void R3000_40_LOOP_DET(bool isPerform = false)
        {
            /*" -3868- MOVE 'R3000-40-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R3000-40-PRINCIPAL", PARAGRAFO);

            /*" -3870- ADD 1 TO TB2-IX. */
            TB2_TABELA_FAIXA_CEP.TB2_IX.Value = TB2_TABELA_FAIXA_CEP.TB2_IX + 1;

            /*" -3871- IF TB2-IX GREATER TB2-ULT-OCOR */

            if (TB2_TABELA_FAIXA_CEP.TB2_IX > TB2_TABELA_FAIXA_CEP.TB2_ULT_OCOR)
            {

                /*" -3872- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -3873- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -3875- END-IF */
            }


            /*" -3876- IF TB3-QTD-OBJ(TB2-IX) = ZEROS */

            if (TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_QTD_OBJ == 00)
            {

                /*" -3877- GO TO R3000-40-LOOP-DET */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3879- END-IF */
            }


            /*" -3880- MOVE TB2-FX-INI(TB2-IX) TO WS-NUM-CEP-AUX. */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3881- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPI);

            /*" -3882- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPI);

            /*" -3883- MOVE TB2-FX-FIM(TB2-IX) TO WS-NUM-CEP-AUX. */
            _.Move(TB2_TABELA_FAIXA_CEP.TB2_TAB_FAIXA_CEP.TB2_FAIXA_CEP[TB2_TABELA_FAIXA_CEP.TB2_IX].TB2_FAIXAS.TB2_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3884- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPF);

            /*" -3885- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPF);

            /*" -3886- MOVE TB3-OBJI(TB2-IX) TO LR05-OBJI. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_OBJI, AREA_DE_WORK.LR12_LINHA12.LR05_OBJI);

            /*" -3887- MOVE TB3-OBJF(TB2-IX) TO LR05-OBJF. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_OBJF, AREA_DE_WORK.LR12_LINHA12.LR05_OBJF);

            /*" -3888- MOVE TB3-AMARI(TB2-IX) TO LR05-AMARI. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_AMARI, AREA_DE_WORK.LR12_LINHA12.LR05_AMARI);

            /*" -3889- MOVE TB3-AMARF(TB2-IX) TO LR05-AMARF. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_AMARF, AREA_DE_WORK.LR12_LINHA12.LR05_AMARF);

            /*" -3890- MOVE TB3-QTD-OBJ(TB2-IX) TO LR05-QTD-OBJ. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_QTD_OBJ, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_OBJ);

            /*" -3891- MOVE TB3-QTD-AMAR(TB2-IX) TO LR05-QTD-AMAR. */
            _.Move(TB3_TABELA_TOTAIS.TB3_TAB_TOTAIS[TB2_TABELA_FAIXA_CEP.TB2_IX].TB3_QTD_AMAR, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_AMAR);

            /*" -3893- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR12_LINHA12.LR05_OBS);

            /*" -3894- WRITE FVG4267B-RECORD FROM LR12-LINHA12. */
            _.Move(AREA_DE_WORK.LR12_LINHA12.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3896- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -3897- IF AC-LINHAS > 17 */

            if (AREA_DE_WORK.AC_LINHAS > 17)
            {

                /*" -3898- ADD 1 TO TB2-IX */
                TB2_TABELA_FAIXA_CEP.TB2_IX.Value = TB2_TABELA_FAIXA_CEP.TB2_IX + 1;

                /*" -3899- GO TO R3000-30-LOOP-CABEC */

                R3000_30_LOOP_CABEC(); //GOTO
                return;

                /*" -3900- ELSE */
            }
            else
            {


                /*" -3901- GO TO R3000-40-LOOP-DET */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3902- END-IF */
            }


            /*" -3902- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-CABECALHOS-SECTION */
        private void R3010_00_CABECALHOS_SECTION()
        {
            /*" -3912- MOVE 'R3010-00-CABECALHOS' TO PARAGRAFO. */
            _.Move("R3010-00-CABECALHOS", PARAGRAFO);

            /*" -3913- WRITE FVG4267B-RECORD FROM LR03-LINHA03 */
            _.Move(AREA_DE_WORK.LR03_LINHA03.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3914- WRITE FVG4267B-RECORD FROM LR04-LINHA04 */
            _.Move(AREA_DE_WORK.LR04_LINHA04.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3915- WRITE FVG4267B-RECORD FROM LR05-LINHA05 */
            _.Move(AREA_DE_WORK.LR05_LINHA05.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3916- WRITE FVG4267B-RECORD FROM LR06-LINHA06 */
            _.Move(AREA_DE_WORK.LR06_LINHA06.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3917- WRITE FVG4267B-RECORD FROM LR07-LINHA07 */
            _.Move(AREA_DE_WORK.LR07_LINHA07.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3918- WRITE FVG4267B-RECORD FROM LR08-LINHA08 */
            _.Move(AREA_DE_WORK.LR08_LINHA08.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3919- WRITE FVG4267B-RECORD FROM LR09-LINHA09 */
            _.Move(AREA_DE_WORK.LR09_LINHA09.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

            /*" -3919- WRITE FVG4267B-RECORD FROM LR10-LINHA10-A. */
            _.Move(AREA_DE_WORK.LR10_LINHA10_A.GetMoveValues(), FVG4267B_RECORD);

            FVG4267B.Write(FVG4267B_RECORD.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SEPARA-PRODUTO-SECTION */
        private void R3100_00_SEPARA_PRODUTO_SECTION()
        {
            /*" -3931- MOVE 'R3100-00-SEPARA-PRODUTO' TO PARAGRAFO. */
            _.Move("R3100-00-SEPARA-PRODUTO", PARAGRAFO);

            /*" -3939- MOVE 999999 TO LF03-FAIXA1 LF03-FAIXA2 LF03-FAIXA1C LF03-FAIXA2C LF05-AMARRADO LF04-QTD-OBJ LF05-SEQ-INICIAL LF05-SEQ-FINAL. */
            _.Move(999999, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1C, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2C, AREA_DE_WORK.LF04_LINHA04.LF05_AMARRADO, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_INICIAL, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_FINAL);

            /*" -3941- MOVE LR03-TP-PGTO TO LF02-NOME-FAIXA. */
            _.Move(AREA_DE_WORK.LR11_LINHA11.LR03_TP_PGTO, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

            /*" -3941- PERFORM R3200-00-FAC-PRODUTO 3 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R3200_00_FAC_PRODUTO_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-FAC-PRODUTO-SECTION */
        private void R3200_00_FAC_PRODUTO_SECTION()
        {
            /*" -3955- MOVE 'R3200-00-FAC-PRODUTO' TO PARAGRAFO. */
            _.Move("R3200-00-FAC-PRODUTO", PARAGRAFO);

            /*" -3956- IF WS-CONTR-PRODU EQUAL 'C' */

            if (AREA_DE_WORK.WS_CONTR_PRODU == "C")
            {

                /*" -3957- WRITE RVG4267B-RECORD FROM LF01-LINHA01 */
                _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -3958- WRITE RVG4267B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -3959- WRITE RVG4267B-RECORD FROM LF02-LINHA02 */
                _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -3960- WRITE RVG4267B-RECORD FROM LF03-LINHA03 */
                _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -3961- WRITE RVG4267B-RECORD FROM LF04-LINHA04 */
                _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -3962- WRITE RVG4267B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -3965- WRITE RVG4267B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG4267B_RECORD);

                RVG4267B.Write(RVG4267B_RECORD.GetMoveValues().ToString());

                /*" -3965- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -3984- MOVE 'R8000-00-OPEN-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R8000-00-OPEN-ARQUIVOS", PARAGRAFO);

            /*" -3985- MOVE 'SIM' TO W-OPEN-ARQ */
            _.Move("SIM", W_OPEN_ARQ);

            /*" -3986- OPEN OUTPUT RVG4267B. */
            RVG4267B.Open(RVG4267B_RECORD);

            /*" -3986- OPEN OUTPUT FVG4267B. */
            FVG4267B.Open(FVG4267B_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -3996- MOVE 'R9000-00-CLOSE-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R9000-00-CLOSE-ARQUIVOS", PARAGRAFO);

            /*" -3997- IF W-OPEN-ARQ = 'SIM' */

            if (W_OPEN_ARQ == "SIM")
            {

                /*" -3998- CLOSE RVG4267B */
                RVG4267B.Close();

                /*" -3999- CLOSE FVG4267B */
                FVG4267B.Close();

                /*" -4000- END-IF */
            }


            /*" -4000- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-INSERT-GEOBJECT-SECTION */
        private void R9100_00_INSERT_GEOBJECT_SECTION()
        {
            /*" -4014- MOVE 'R9100-00-INSERT-GEOBJECT' TO PARAGRAFO. */
            _.Move("R9100-00-INSERT-GEOBJECT", PARAGRAFO);

            /*" -4039- PERFORM R9100_00_INSERT_GEOBJECT_DB_INSERT_1 */

            R9100_00_INSERT_GEOBJECT_DB_INSERT_1();

            /*" -4042- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4043- DISPLAY 'R9100-00 (PROBLEMAS NA INSERCAO GEOBJECT)' */
                _.Display($"R9100-00 (PROBLEMAS NA INSERCAO GEOBJECT)");

                /*" -4047- DISPLAY 'CHAVE = ' GEOBJECT-NUM-CEP ' ' GEOBJECT-NOM-PROGRAMA ' ' GEOBJECT-COD-FORMULARIO ' ' GEOBJECT-STA-REGISTRO */

                $"CHAVE = {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP} {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NOM_PROGRAMA} {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO} {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO}"
                .Display();

                /*" -4047- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9100-00-INSERT-GEOBJECT-DB-INSERT-1 */
        public void R9100_00_INSERT_GEOBJECT_DB_INSERT_1()
        {
            /*" -4039- EXEC SQL INSERT INTO SEGUROS.GE_OBJETO_ECT ( NUM_CEP , NOM_PROGRAMA , COD_FORMULARIO , STA_REGISTRO , DTH_TIMESTAMP , COD_PRODUTO , NUM_INI_POS_VERSO , QTD_PESO_GRAMAS , VLR_DECLARADO , COD_IDENT_OBJETO , DES_OBJETO) VALUES (:GEOBJECT-NUM-CEP , :GEOBJECT-NOM-PROGRAMA , :GEOBJECT-COD-FORMULARIO , :GEOBJECT-STA-REGISTRO , CURRENT TIMESTAMP , :GEOBJECT-COD-PRODUTO :VIND-COD-PRODUTO , :GEOBJECT-NUM-INI-POS-VERSO , :GEOBJECT-QTD-PESO-GRAMAS , :GEOBJECT-VLR-DECLARADO , :GEOBJECT-COD-IDENT-OBJETO , :GEOBJECT-DES-OBJETO) END-EXEC. */

            var r9100_00_INSERT_GEOBJECT_DB_INSERT_1_Insert1 = new R9100_00_INSERT_GEOBJECT_DB_INSERT_1_Insert1()
            {
                GEOBJECT_NUM_CEP = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP.ToString(),
                GEOBJECT_NOM_PROGRAMA = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NOM_PROGRAMA.ToString(),
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
                GEOBJECT_STA_REGISTRO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO.ToString(),
                GEOBJECT_COD_PRODUTO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO.ToString(),
                VIND_COD_PRODUTO = VIND_COD_PRODUTO.ToString(),
                GEOBJECT_NUM_INI_POS_VERSO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO.ToString(),
                GEOBJECT_QTD_PESO_GRAMAS = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS.ToString(),
                GEOBJECT_VLR_DECLARADO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO.ToString(),
                GEOBJECT_COD_IDENT_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO.ToString(),
                GEOBJECT_DES_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.ToString(),
            };

            R9100_00_INSERT_GEOBJECT_DB_INSERT_1_Insert1.Execute(r9100_00_INSERT_GEOBJECT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -4060- MOVE 'R9800-00-ENCERRA- ' TO PARAGRAFO. */
            _.Move("R9800-00-ENCERRA- ", PARAGRAFO);

            /*" -4061- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -4062- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4063- DISPLAY '*   VG4267B - IMPRIME COBRANCA             *' */
            _.Display($"*   VG4267B - IMPRIME COBRANCA             *");

            /*" -4064- DISPLAY '*   -------   ----------------             *' */
            _.Display($"*   -------   ----------------             *");

            /*" -4065- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4066- DISPLAY '*             NAO EXISTE BOLETO DE         *' */
            _.Display($"*             NAO EXISTE BOLETO DE         *");

            /*" -4067- DISPLAY '*             COBRANCA PARA ESTA DATA      *' */
            _.Display($"*             COBRANCA PARA ESTA DATA      *");

            /*" -4068- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4069- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -4070- MOVE 00 TO W-RETURN-CODE */
            _.Move(00, W_RETURN_CODE);

            /*" -4071- GO TO R9999-00-FINALIZA */

            R9999_00_FINALIZA_SECTION(); //GOTO
            return;

            /*" -4071- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -4082- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4083- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -4083- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4085- MOVE 99 TO W-RETURN-CODE */
            _.Move(99, W_RETURN_CODE);

            /*" -4086- GO TO R9999-00-FINALIZA */

            R9999_00_FINALIZA_SECTION(); //GOTO
            return;

            /*" -4086- . */

        }

        [StopWatch]
        /*" R9999-00-FINALIZA-SECTION */
        private void R9999_00_FINALIZA_SECTION()
        {
            /*" -4093- DISPLAY ' ' */
            _.Display($" ");

            /*" -4095- DISPLAY '***************************************************' '***************************************************' */
            _.Display($"******************************************************************************************************");

            /*" -4096- IF W-RETURN-CODE = 0 */

            if (W_RETURN_CODE == 0)
            {

                /*" -4103- DISPLAY 'INICIOU PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"INICIOU PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -4104- ELSE */
            }
            else
            {


                /*" -4111- DISPLAY 'FINALIZOU O PROCESSAMENTO COM ERRO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"FINALIZOU O PROCESSAMENTO COM ERRO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -4112- END-IF */
            }


            /*" -4114- DISPLAY '***************************************************' '***************************************************' */
            _.Display($"******************************************************************************************************");

            /*" -4115- DISPLAY ' ' */
            _.Display($" ");

            /*" -4117- DISPLAY '===================================================' '===================================================' */
            _.Display($"======================================================================================================");

            /*" -4119- DISPLAY 'TOTALIZACAO' '===================================================' */
            _.Display($"TOTALIZACAO===================================================");

            /*" -4120- DISPLAY 'LIDOS V0HISTCOBVA       = ' AC-LIDOS. */
            _.Display($"LIDOS V0HISTCOBVA       = {AREA_DE_WORK.AC_LIDOS}");

            /*" -4121- DISPLAY 'COBRANCAS IMPRESSAS     = ' AC-IMPRESSOS */
            _.Display($"COBRANCAS IMPRESSAS     = {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -4124- DISPLAY '===================================================' '===================================================' */
            _.Display($"======================================================================================================");

            /*" -4125- MOVE W-RETURN-CODE TO RETURN-CODE */
            _.Move(W_RETURN_CODE, RETURN_CODE);

            /*" -4126- STOP RUN */

            throw new GoBack();   // => STOP RUN.

            /*" -4126- . */

        }
    }
}