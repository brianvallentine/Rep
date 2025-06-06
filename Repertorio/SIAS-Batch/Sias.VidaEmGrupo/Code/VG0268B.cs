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
using Sias.VidaEmGrupo.DB2.VG0268B;

namespace Code
{
    public class VG0268B
    {
        public bool IsCall { get; set; }

        public VG0268B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      * EMITE FATURA DE PREMIOS DAS APOLICES ESPECIFICA E EMPRESARIAL  *      */
        /*"      * NA NOVA ESTRUTURA DE FATURAMENTO PARA DEBITO EM CONTA.         *      */
        /*"      * V0HISTCOBVA COM SITUACAO = '5'  => IMPRIMIR CORRESPONDENCIA    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   OPCAOPAG 1 E 2 =>  DEBITO    EM CONTA    CORRENTE            *      */
        /*"      *   OPCAOPAG     3 =>  DOCUMENTO DE COBRANCA BANCARIA            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.18  *  VERSAO 18  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/08/2024 - SERGIO LORETO                                *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV117 *VERSAO 17: JV1 DEMANDA 259756 - KINKAS 10/10/2020               *      */
        /*"JV117 *           ALTERA FORMULARIOS FASE 2 PARA EMPRESA 11 - JV1      *      */
        /*"JV117 *           - PROCURAR POR JV117                                 *      */
        /*"JV116 *-----------------------------------------------------------------      */
        /*"JV116 *VERSAO 16: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV116 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV116 *           - PROCURAR POR JV116                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - CORRIGIR ERRO DE CAMPOS COM NULOS.               *      */
        /*"      *   DEMANDA 233438 - TAREFA 248029                                      */
        /*"      *   EM 15/06/2020 - RAUL BASILI ROTTA   FIND BY V.15             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - CORRIGIR FORMULARIO CVP.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/01/2020 - HERVAL SOUZA        FIND BY V.14             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - CORRIGIR IDENTIFICA��O DO CODIGO DA EMPRESA      *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/09/2019 - HERVAL SOUZA        FIND BY V.13             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 -                                                  *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA FOLHETA -*      */
        /*"      *             -  RIA                                             *      */
        /*"      *   EM 17/02/2019 - JOAO ARAUJO         FIND BY JV1              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    VERSAO 11 -   NSGD - CADMUS 103659.                         *      */
        /*"      *                                                                *      */
        /*"      *       - NOVA SOLUCAO DE GESTAO DE DEPOSITOS                    *      */
        /*"      *                                                                *      */
        /*"      *    EM 26/06/2015 - COREON                                      *      */
        /*"      *                                      PROCURE POR V.11          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - CAD 106.701                                      *      */
        /*"      *                                                                *      */
        /*"      *       - RETIRAR OS PRODUTOS EMPRESARIAIS DO VD03.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/05/2015 - CLAUDETE RADEL*                                     */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - CAD 110.125                                      *      */
        /*"      *                                                                *      */
        /*"      *       - INSERCAO DE COD-PRODUTO NO FORMULARIO DE IMPRESSAO     *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/03/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.08      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 78188 - CORRECAO DO ACESSO NA TABELA                  *      */
        /*"      *   SEGUROS.V0COBERPROPVA. ACESSO POR VENCIMENTO ORIGINAL DA     *      */
        /*"      *   PARCELA.                                                     *      */
        /*"      *   LUIZ MARQUES(FAST COMPUTER)                                  *      */
        /*"      *   DATA: 15/01/2013                     PROCURE V.07            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 74489 - CORRECAO DO ABEND OCORRIDO SQLCODE = 100 NA   *      */
        /*"      *   TABELA SEGUROS.V0COBERPROPVA.                                *      */
        /*"      *   MARCO PAIVA (FAST COMPUTER)                                  *      */
        /*"      *   DATA: 21/09/2012                     PROCURE V.06            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 61873 - INCLUIR O COD PRODUTO NO REGISTRO DE IMPRESSAO*      */
        /*"      *   O PRODUTO SERA UTILIZADO NO PORTAL DE IMPRESSAO PARA SEPARAR *      */
        /*"      *   A COBRANCA DE GERACAO DE PDF, POR PRODUTO.                   *      */
        /*"      *   JEFFERSON - OUTUBRO/2011 - PROCURAR: V.05                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     04     *  04/09/06  *   F COMPUTER * PASSA A NAO IMPRIMIR  *      */
        /*"      *  BOLETOS DO EMPRESA GLOBAL.                                    *      */
        /*"      *                                         PROCURE V.04           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     03     *  04/09/06  *   F COMPUTER * PASSA A IMPRIMIR      *      */
        /*"      *  BOLETOS DO EMPRESA GLOBAL.                                    *      */
        /*"      *                                         PROCURE V.03           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     02     *  07/03/02  *   MESSIAS    * VERSAO DO PROGRAMA    *      */
        /*"      *  VG0267B, PARA O NOVO FATURAMENTO DAS APOLICES ESPECIFICA E EM-*      */
        /*"      *  PRESARIAL, NA ESTRUTURA DO MULTIPREMIADO.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     01     *  25/08/97  *   TERCIO     *                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ADEQUACAO PARA CALCULAR DATA DE POSTAGEM COM 2 DIAS UTEIS      *      */
        /*"      * VERSAO                          PRODEXTER          09/07/2003  *      */
        /*"      * (PROCURAR POR CH0703)                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM JULHO/2004 - PRODEXTER (VANDO)                    *      */
        /*"      * CONVERSAO A5 PARA A4 - TRATAMENTO CIF/POSTNET                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 29257 - EVITAR A REJEICAO DE CORRESPONDENCIAS, RECU-  *      */
        /*"      *   PERANDO O CEP NAS BASES DNE DOS CORREIOS PELO ENDERECO.      *      */
        /*"      *   BRSEG - SETEMBRO/2009 - VER: BR.V01                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RVG0268B { get; set; } = new FileBasis(new PIC("X", "3500", "X(3500)"));

        public FileBasis RVG0268B
        {
            get
            {
                _.Move(RVG0268B_RECORD, _RVG0268B); VarBasis.RedefinePassValue(RVG0268B_RECORD, _RVG0268B, RVG0268B_RECORD); return _RVG0268B;
            }
        }
        public FileBasis _FVG0268B { get; set; } = new FileBasis(new PIC("X", "3500", "X(3500)"));

        public FileBasis FVG0268B
        {
            get
            {
                _.Move(FVG0268B_RECORD, _FVG0268B); VarBasis.RedefinePassValue(FVG0268B_RECORD, _FVG0268B, FVG0268B_RECORD); return _FVG0268B;
            }
        }
        public SortBasis<VG0268B_REG_SVG0268B> SVG0268B { get; set; } = new SortBasis<VG0268B_REG_SVG0268B>(new VG0268B_REG_SVG0268B());
        /*"01            RVG0268B-RECORD     PIC X(3500).*/
        public StringBasis RVG0268B_RECORD { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");
        /*"01            FVG0268B-RECORD     PIC X(3500).*/
        public StringBasis FVG0268B_RECORD { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");
        /*"01            REG-SVG0268B.*/
        public VG0268B_REG_SVG0268B REG_SVG0268B { get; set; } = new VG0268B_REG_SVG0268B();
        public class VG0268B_REG_SVG0268B : VarBasis
        {
            /*"    05        SVA-NRAPOLICE       PIC  9(013).*/
            public IntBasis SVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-CODSUBES        PIC  9(005).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        SVA-CODPRODU        PIC  9(004).*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-CEP-G           PIC  9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        SVA-NUM-CEP.*/
            public VG0268B_SVA_NUM_CEP SVA_NUM_CEP { get; set; } = new VG0268B_SVA_NUM_CEP();
            public class VG0268B_SVA_NUM_CEP : VarBasis
            {
                /*"      15      SVA-CEP             PIC  9(005).*/
                public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15      SVA-CEP-COMPL       PIC  9(003).*/
                public IntBasis SVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        SVA-NUM-CEP-9       REDEFINES  SVA-NUM-CEP                                  PIC  9(008).*/
            }
            private _REDEF_IntBasis _sva_num_cep_9 { get; set; }
            public _REDEF_IntBasis SVA_NUM_CEP_9
            {
                get { _sva_num_cep_9 = new _REDEF_IntBasis(new PIC("9", "008", "9(008).")); ; _.Move(SVA_NUM_CEP, _sva_num_cep_9); VarBasis.RedefinePassValue(SVA_NUM_CEP, _sva_num_cep_9, SVA_NUM_CEP); _sva_num_cep_9.ValueChanged += () => { _.Move(_sva_num_cep_9, SVA_NUM_CEP); }; return _sva_num_cep_9; }
                set { VarBasis.RedefinePassValue(value, _sva_num_cep_9, SVA_NUM_CEP); }
            }  //Redefines
            /*"    05        SVA-NRCERTIF        PIC  9(015).*/
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
        /*"77            VIND-NRCOPIAS       PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-NRTITCOMP      PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-TEMCDG         PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_TEMCDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            SQL-PCIOF           PIC S9(003)V99 COMP-3.*/
        public DoubleBasis SQL_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77            VIND-PRODUTO        PIC S9(004)    COMP VALUE +0.*/
        public IntBasis VIND_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRCERTIF      PIC S9(015)    COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            WHOST-NRPARCEL      PIC S9(004)    COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRTIT         PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-NRTITCOMP     PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-OCORHIST      PIC S9(004)    COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRAPOLICE     PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-CODSUBES      PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODPRODU      PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODOPER       PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0COBP-OCORHIST      PIC S9(004)    COMP.*/
        public IntBasis V0COBP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0COBP-QUANT-VIDAS   PIC S9(009)    COMP.*/
        public IntBasis V0COBP_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0COBP-IMPSEGUR      PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBP-DTINIVIG-PARC PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WHOST-DATA1          PIC  X(010).*/
        public StringBasis WHOST_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WHOST-DATA2          PIC  X(010).*/
        public StringBasis WHOST_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WHOST-DTMOVABE      PIC  X(010)    VALUE SPACES.*/
        public StringBasis WHOST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77            V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-MESREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1SIST-ANOREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77            V0CEDE-CONTA        PIC S9(013)    COMP-3.*/
        public IntBasis V0CEDE_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
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
        /*"77            V0COBE-OCORHIST     PIC S9(004)    COMP.*/
        public IntBasis V0COBE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77            V0HIST-DAY          PIC S9(004)    COMP.*/
        public IntBasis V0HIST_DAY { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77            V0CLIE-NOME-SE      PIC  X(040).*/
        public StringBasis V0CLIE_NOME_SE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0CLIE-CNPJ-SE      PIC S9(015)    COMP-3.*/
        public IntBasis V0CLIE_CNPJ_SE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
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
        /*"77            V0ENDE-ENDER-SE     PIC  X(040).*/
        public StringBasis V0ENDE_ENDER_SE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0ENDE-BAIRRO-SE    PIC  X(020).*/
        public StringBasis V0ENDE_BAIRRO_SE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-CIDADE-SE    PIC  X(020).*/
        public StringBasis V0ENDE_CIDADE_SE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-UF-SE        PIC  X(002).*/
        public StringBasis V0ENDE_UF_SE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V0ENDE-CEP-SE       PIC S9(009)    COMP.*/
        public IntBasis V0ENDE_CEP_SE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77            WS-COD-PRODUTO      PIC S9(004) COMP-5 VALUE 0.*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  TAB-MESES-REF.*/
        public VG0268B_TAB_MESES_REF TAB_MESES_REF { get; set; } = new VG0268B_TAB_MESES_REF();
        public class VG0268B_TAB_MESES_REF : VarBasis
        {
            /*"    05 FILLER PIC X(24) VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"312831303130313130313031");
            /*"01  TAB-MESES-R-REF REDEFINES TAB-MESES-REF.*/
        }
        private _REDEF_VG0268B_TAB_MESES_R_REF _tab_meses_r_ref { get; set; }
        public _REDEF_VG0268B_TAB_MESES_R_REF TAB_MESES_R_REF
        {
            get { _tab_meses_r_ref = new _REDEF_VG0268B_TAB_MESES_R_REF(); _.Move(TAB_MESES_REF, _tab_meses_r_ref); VarBasis.RedefinePassValue(TAB_MESES_REF, _tab_meses_r_ref, TAB_MESES_REF); _tab_meses_r_ref.ValueChanged += () => { _.Move(_tab_meses_r_ref, TAB_MESES_REF); }; return _tab_meses_r_ref; }
            set { VarBasis.RedefinePassValue(value, _tab_meses_r_ref, TAB_MESES_REF); }
        }  //Redefines
        public class _REDEF_VG0268B_TAB_MESES_R_REF : VarBasis
        {
            /*"    05 TAB-ULT-DIAS OCCURS 12.*/
            public ListBasis<VG0268B_TAB_ULT_DIAS> TAB_ULT_DIAS { get; set; } = new ListBasis<VG0268B_TAB_ULT_DIAS>(12);
            public class VG0268B_TAB_ULT_DIAS : VarBasis
            {
                /*"       10 TAB-ULT-DIA-MES PIC 9(2).*/
                public IntBasis TAB_ULT_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(2)."));
                /*"01  WS-FORM-LINHA                    PIC  X(023) VALUE SPACES.*/

                public VG0268B_TAB_ULT_DIAS()
                {
                    TAB_ULT_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0268B_TAB_MESES_R_REF()
            {
                TAB_ULT_DIAS.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_FORM_LINHA { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
        /*"01  AREA-DE-WORK.*/
        public VG0268B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0268B_AREA_DE_WORK();
        public class VG0268B_AREA_DE_WORK : VarBasis
        {
            /*"    05          WS-SIT-PRODUTO       PIC  9(001)  VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88        WS-PROD-RUNON                     VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88        WS-PROD-RUNOFF                    VALUE 2. */
							new SelectorItemBasis("WS_PROD_RUNOFF", "2")
                }
            };

            /*"    05            LC01-LINHA01.*/
            public VG0268B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new VG0268B_LC01_LINHA01();
            public class VG0268B_LC01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(002) VALUE '%!'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
                /*"    05            LC02-LINHA02.*/
            }
            public VG0268B_LC02_LINHA02 LC02_LINHA02 { get; set; } = new VG0268B_LC02_LINHA02();
            public class VG0268B_LC02_LINHA02 : VarBasis
            {
                /*"      10          LC02-FILLER          PIC X(070) VALUE    '%%DocumentMedia: papel1 595 842 75 white normal'.*/
                public StringBasis LC02_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%DocumentMedia: papel1 595 842 75 white normal");
                /*"    05            LC03-LINHA03.*/
            }
            public VG0268B_LC03_LINHA03 LC03_LINHA03 { get; set; } = new VG0268B_LC03_LINHA03();
            public class VG0268B_LC03_LINHA03 : VarBasis
            {
                /*"      10          LC03-FILLER          PIC X(070) VALUE    '%%+papel2 595 842 75 blue azul'.*/
                public StringBasis LC03_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%+papel2 595 842 75 blue azul");
                /*"    05            LC04-LINHA04.*/
            }
            public VG0268B_LC04_LINHA04 LC04_LINHA04 { get; set; } = new VG0268B_LC04_LINHA04();
            public class VG0268B_LC04_LINHA04 : VarBasis
            {
                /*"      10          LC04-FILLER          PIC X(070) VALUE    '%%XRXrequeriments: duplex'.*/
                public StringBasis LC04_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%XRXrequeriments: duplex");
                /*"    05            LC05-LINHA05.*/
            }
            public VG0268B_LC05_LINHA05 LC05_LINHA05 { get; set; } = new VG0268B_LC05_LINHA05();
            public class VG0268B_LC05_LINHA05 : VarBasis
            {
                /*"      10          LC05-FILLER          PIC X(070) VALUE    '%%BeginFeature: *Duplex True'.*/
                public StringBasis LC05_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%BeginFeature: *Duplex True");
                /*"    05            LC06-LINHA06.*/
            }
            public VG0268B_LC06_LINHA06 LC06_LINHA06 { get; set; } = new VG0268B_LC06_LINHA06();
            public class VG0268B_LC06_LINHA06 : VarBasis
            {
                /*"      10          LC06-FILLER          PIC X(070) VALUE    '<</Duplex true>> setpagedevice'.*/
                public StringBasis LC06_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"<</Duplex true>> setpagedevice");
                /*"    05            LC07-LINHA07.*/
            }
            public VG0268B_LC07_LINHA07 LC07_LINHA07 { get; set; } = new VG0268B_LC07_LINHA07();
            public class VG0268B_LC07_LINHA07 : VarBasis
            {
                /*"      10          LC07-FILLER          PIC X(070) VALUE    '%%EndFeature'.*/
                public StringBasis LC07_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EndFeature");
                /*"    05            LC08-LINHA08.*/
            }
            public VG0268B_LC08_LINHA08 LC08_LINHA08 { get; set; } = new VG0268B_LC08_LINHA08();
            public class VG0268B_LC08_LINHA08 : VarBasis
            {
                /*"      10          LC08-FILLER          PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05            LC09-LINHA09.*/
            }
            public VG0268B_LC09_LINHA09 LC09_LINHA09 { get; set; } = new VG0268B_LC09_LINHA09();
            public class VG0268B_LC09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LC09-FORM.*/
                public VG0268B_LC09_FORM LC09_FORM { get; set; } = new VG0268B_LC09_FORM();
                public class VG0268B_LC09_FORM : VarBasis
                {
                    /*"        15        LC09-JDE             PIC X(008).*/
                    public StringBasis LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'dbm'.*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"dbm");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            FILLER     REDEFINES LC09-LINHA09.*/
            }
            private _REDEF_VG0268B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VG0268B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VG0268B_FILLER_7(); _.Move(LC09_LINHA09, _filler_7); VarBasis.RedefinePassValue(LC09_LINHA09, _filler_7, LC09_LINHA09); _filler_7.ValueChanged += () => { _.Move(_filler_7, LC09_LINHA09); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, LC09_LINHA09); }
            }  //Redefines
            public class _REDEF_VG0268B_FILLER_7 : VarBasis
            {
                /*"      10          LC09-LIN09           PIC X(023).*/
                public StringBasis LC09_LIN09 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LC10-LINHA10.*/

                public _REDEF_VG0268B_FILLER_7()
                {
                    LC09_LIN09.ValueChanged += OnValueChanged;
                }

            }
            public VG0268B_LC10_LINHA10 LC10_LINHA10 { get; set; } = new VG0268B_LC10_LINHA10();
            public class VG0268B_LC10_LINHA10 : VarBasis
            {
                /*"       10         FILLER              PIC X(008) VALUE       'PRODUTO|'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PRODUTO|");
                /*"       10         FILLER              PIC X(051) VALUE       'AGENCIA|APOLICE|ENDOSSO|FATURA|PERIODO|EMISSAO|VENC'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"AGENCIA|APOLICE|ENDOSSO|FATURA|PERIODO|EMISSAO|VENC");
                /*"       10         FILLER              PIC X(051) VALUE       'IMENT|ESTIPULANTE|CNPJ1|ENDERE1|CEP1|CIDADE1|EST1|S'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"IMENT|ESTIPULANTE|CNPJ1|ENDERE1|CEP1|CIDADE1|EST1|S");
                /*"       10         FILLER              PIC X(051) VALUE       'UBESTIPULANTE|CNPJ2|ENDERE2|CEP2|CIDADE2|EST2|NVIDA'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"UBESTIPULANTE|CNPJ2|ENDERE2|CEP2|CIDADE2|EST2|NVIDA");
                /*"       10         FILLER              PIC X(051) VALUE       'S|CAPITAL|IOF|PREMIO|TEXTO|DTPOSTAGEM|NUMOBJETO|DES'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"S|CAPITAL|IOF|PREMIO|TEXTO|DTPOSTAGEM|NUMOBJETO|DES");
                /*"       10         FILLER              PIC X(051) VALUE       'TINATARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|R'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"TINATARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|R");
                /*"       10         FILLER              PIC X(051) VALUE       'EMET-ENDERECO|REMET-BAIRRO|REMET-CIDADE|REMET-UF|RE'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"EMET_ENDERECO|REMET_BAIRRO|REMET_CIDADE|REMET_UF|RE");
                /*"       10         FILLER              PIC X(051) VALUE       'MET-CEP|CODIGO-CIF|POSTNET|COD-PRODUTO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"MET_CEP|CODIGO_CIF|POSTNET|COD_PRODUTO");
                /*"    05            LC11-LINHA11.*/
            }
            public VG0268B_LC11_LINHA11 LC11_LINHA11 { get; set; } = new VG0268B_LC11_LINHA11();
            public class VG0268B_LC11_LINHA11 : VarBasis
            {
                /*"       10         LC11-PRODUTO-E      PIC 9999.*/
                public IntBasis LC11_PRODUTO_E { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-AGENCIA-E      PIC 9999.*/
                public IntBasis LC11_AGENCIA_E { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-APOLICE-E      PIC ZZZZZZZZZZZZZ.*/
                public StringBasis LC11_APOLICE_E { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDOSSO-E      PIC X(009) VALUE '*-*-*-*'*/
                public StringBasis LC11_ENDOSSO_E { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"*-*-*-*");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-FATURA-SEC-E   PIC 9(004).*/
                public IntBasis LC11_FATURA_SEC_E { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         LC11-FATURA-MES-E   PIC 9(002).*/
                public IntBasis LC11_FATURA_MES_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTINI-DIA-E    PIC 9(002).*/
                public IntBasis LC11_DTINI_DIA_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-DTINI-MES-E    PIC 9(002).*/
                public IntBasis LC11_DTINI_MES_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-DTINI-ANO-E    PIC 9(004).*/
                public IntBasis LC11_DTINI_ANO_E { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(003) VALUE ' A '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"       10         LC11-DTTER-DIA-E    PIC 9(002).*/
                public IntBasis LC11_DTTER_DIA_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-DTTER-MES-E    PIC 9(002).*/
                public IntBasis LC11_DTTER_MES_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-DTTER-ANO-E    PIC 9(004).*/
                public IntBasis LC11_DTTER_ANO_E { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTEMISSAO-E    PIC X(010).*/
                public StringBasis LC11_DTEMISSAO_E { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVENCTO-E     PIC X(010).*/
                public StringBasis LC11_DTVENCTO_E { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-EST-E     PIC X(040).*/
                public StringBasis LC11_NOME_EST_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRCNPJ1-EST-E  PIC 999.999.999.*/
                public IntBasis LC11_NRCNPJ1_EST_E { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-NRCNPJ2-EST-E  PIC 9(004).*/
                public IntBasis LC11_NRCNPJ2_EST_E { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-DVCNPJ3-EST-E  PIC 9(002).*/
                public IntBasis LC11_DVCNPJ3_EST_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDER-EST-E    PIC X(040).*/
                public StringBasis LC11_ENDER_EST_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP1-EST-E     PIC 9(005).*/
                public IntBasis LC11_CEP1_EST_E { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP2-EST-E     PIC 9(003).*/
                public IntBasis LC11_CEP2_EST_E { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-EST-E   PIC X(020).*/
                public StringBasis LC11_CIDADE_EST_E { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-EST-E       PIC X(002).*/
                public StringBasis LC11_UF_EST_E { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CODSUBES-SUB-E PIC Z9999.*/
                public IntBasis LC11_CODSUBES_SUB_E { get; set; } = new IntBasis(new PIC("9", "5", "Z9999."));
                /*"       10         FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"       10         LC11-NOME-SUB-E     PIC X(032).*/
                public StringBasis LC11_NOME_SUB_E { get; set; } = new StringBasis(new PIC("X", "32", "X(032)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRCNPJ1-SUB-E  PIC 999.999.999.*/
                public IntBasis LC11_NRCNPJ1_SUB_E { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-NRCNPJ2-SUB-E  PIC 9(004).*/
                public IntBasis LC11_NRCNPJ2_SUB_E { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-DVCNPJ-SUB-E   PIC 9(002).*/
                public IntBasis LC11_DVCNPJ_SUB_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDER-SUB-E    PIC X(040).*/
                public StringBasis LC11_ENDER_SUB_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP1-SUB-E     PIC 9(005).*/
                public IntBasis LC11_CEP1_SUB_E { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP2-SUB-E     PIC 9(003).*/
                public IntBasis LC11_CEP2_SUB_E { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-SUB-E   PIC X(020).*/
                public StringBasis LC11_CIDADE_SUB_E { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-SUB-E       PIC X(002).*/
                public StringBasis LC11_UF_SUB_E { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NVIDAS-E       PIC ZZZZZZ.*/
                public StringBasis LC11_NVIDAS_E { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CAPITAL-E      PIC ZZZ.ZZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis LC11_CAPITAL_E { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ.ZZZ.ZZZ.ZZZVZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-IOF-E          PIC ZZZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis LC11_IOF_E { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZ.ZZZ.ZZZVZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-VLPRMTOT-E     PIC ZZZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis LC11_VLPRMTOT_E { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZ.ZZZ.ZZZVZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-TEXTO-E        PIC X(002) VALUE '  '.*/
                public StringBasis LC11_TEXTO_E { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"  ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE01-DTPOSTAGEM-E   PIC X(010).*/
                public StringBasis LE01_DTPOSTAGEM_E { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE01-NUMOBJETO-E    PIC X(007).*/
                public StringBasis LE01_NUMOBJETO_E { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE02-NOME-DEST-E    PIC X(040).*/
                public StringBasis LE02_NOME_DEST_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE03-ENDER-DEST-E   PIC X(072).*/
                public StringBasis LE03_ENDER_DEST_E { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-BAIRRO-DEST-E  PIC X(072).*/
                public StringBasis LE04_BAIRRO_DEST_E { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-CIDADE-DEST-E  PIC X(072).*/
                public StringBasis LE04_CIDADE_DEST_E { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-UF-DEST-E      PIC X(002).*/
                public StringBasis LE04_UF_DEST_E { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE05-CEP-DEST-E     PIC 99999.*/
                public IntBasis LE05_CEP_DEST_E { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LE05-CEPC-DEST-E    PIC 999.*/
                public IntBasis LE05_CEPC_DEST_E { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         FILLER              PIC X(014) VALUE                 'CAIXA SEGUROS '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CAIXA SEGUROS ");
                /*"       10         LE06-REMETENTE-G.*/
                public VG0268B_LE06_REMETENTE_G LE06_REMETENTE_G { get; set; } = new VG0268B_LE06_REMETENTE_G();
                public class VG0268B_LE06_REMETENTE_G : VarBasis
                {
                    /*"         15       LE06-FILIAL-REM-E   PIC X(007).*/
                    public StringBasis LE06_FILIAL_REM_E { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"         15       LE06-REMETENTE-E    PIC X(024).*/
                    public StringBasis LE06_REMETENTE_E { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                }
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE07-ENDER-REM-E    PIC X(040).*/
                public StringBasis LE07_ENDER_REM_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-BAIRRO-REM-E   PIC X(020).*/
                public StringBasis LE08_BAIRRO_REM_E { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-CIDADE-REM-E   PIC X(020).*/
                public StringBasis LE08_CIDADE_REM_E { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-UF-REM-E       PIC X(002).*/
                public StringBasis LE08_UF_REM_E { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-CEP-REM-E      PIC 99999.*/
                public IntBasis LE09_CEP_REM_E { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LE09-CEPC-REM-E     PIC 999.*/
                public IntBasis LE09_CEPC_REM_E { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-CODIGO-CIF-E   PIC X(034) VALUE '@'.*/
                public StringBasis LE09_CODIGO_CIF_E { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"@");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-POSTNET-E      PIC X(011) VALUE '#'.*/
                public StringBasis LE09_POSTNET_E { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"#");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-COD-PRODUTO    PIC 9(004).*/
                public IntBasis LE09_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05            LC12-LINHA12.*/
            }
            public VG0268B_LC12_LINHA12 LC12_LINHA12 { get; set; } = new VG0268B_LC12_LINHA12();
            public class VG0268B_LC12_LINHA12 : VarBasis
            {
                /*"      10          LC12-FILLER          PIC X(070) VALUE    '%%EOF'.*/
                public StringBasis LC12_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EOF");
                /*"    05            LF01-LINHA01.*/
            }
            public VG0268B_LF01_LINHA01 LF01_LINHA01 { get; set; } = new VG0268B_LF01_LINHA01();
            public class VG0268B_LF01_LINHA01 : VarBasis
            {
                /*"      10          FILLER              PIC X(055) VALUE     '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>");
                /*"      10          FILLER              PIC X(080) VALUE     'setpagedevice'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"setpagedevice");
                /*"    05            LF02-LINHA02.*/
            }
            public VG0268B_LF02_LINHA02 LF02_LINHA02 { get; set; } = new VG0268B_LF02_LINHA02();
            public class VG0268B_LF02_LINHA02 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LF02-FORM.*/
                public VG0268B_LF02_FORM LF02_FORM { get; set; } = new VG0268B_LF02_FORM();
                public class VG0268B_LF02_FORM : VarBasis
                {
                    /*"        15        LF02-JDE             PIC X(004).*/
                    public StringBasis LF02_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            LF03-LINHA03.*/
            }
            public VG0268B_LF03_LINHA03 LF03_LINHA03 { get; set; } = new VG0268B_LF03_LINHA03();
            public class VG0268B_LF03_LINHA03 : VarBasis
            {
                /*"      10          FILLER               PIC X(070) VALUE     'LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA");
                /*"    05            LF04-LINHA04.*/
            }
            public VG0268B_LF04_LINHA04 LF04_LINHA04 { get; set; } = new VG0268B_LF04_LINHA04();
            public class VG0268B_LF04_LINHA04 : VarBasis
            {
                /*"      10          LF02-NOME-FAIXA     PIC X(072).*/
                public StringBasis LF02_NOME_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF03-FAIXA1         PIC X(005).*/
                public StringBasis LF03_FAIXA1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LF03-FAIXA1C        PIC X(003).*/
                public StringBasis LF03_FAIXA1C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC X(005) VALUE '  A '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A ");
                /*"      10          LF03-FAIXA2         PIC X(005).*/
                public StringBasis LF03_FAIXA2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LF03-FAIXA2C        PIC X(003).*/
                public StringBasis LF03_FAIXA2C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF04-QTD-OBJ        PIC 9(003).*/
                public IntBasis LF04_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF05-AMARRADO       PIC ZZZ.999.*/
                public IntBasis LF05_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF05-SEQ-INICIAL    PIC ZZZ.999.*/
                public IntBasis LF05_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LF05-SEQ-FINAL      PIC ZZZ.999.*/
                public IntBasis LF05_SEQ_FINAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    05            LR01-LINHA01.*/
            }
            public VG0268B_LR01_LINHA01 LR01_LINHA01 { get; set; } = new VG0268B_LR01_LINHA01();
            public class VG0268B_LR01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '1'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05            LR02-LINHA02.*/
            }
            public VG0268B_LR02_LINHA02 LR02_LINHA02 { get; set; } = new VG0268B_LR02_LINHA02();
            public class VG0268B_LR02_LINHA02 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LR02-FORM.*/
                public VG0268B_LR02_FORM LR02_FORM { get; set; } = new VG0268B_LR02_FORM();
                public class VG0268B_LR02_FORM : VarBasis
                {
                    /*"        15        LR02-JDE             PIC X(004) VALUE 'CO05'.*/
                    public StringBasis LR02_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"CO05");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'JDT'.*/
                    public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"JDT");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE     'STARTLM'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTLM");
                /*"    05            LR03-LINHA03.*/
            }
            public VG0268B_LR03_LINHA03 LR03_LINHA03 { get; set; } = new VG0268B_LR03_LINHA03();
            public class VG0268B_LR03_LINHA03 : VarBasis
            {
                /*"      10          LR03-CONTRATO-ECT    PIC X(030) VALUE     '     100134700-5'.*/
                public StringBasis LR03_CONTRATO_ECT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     100134700-5");
                /*"    05            LR04-LINHA04.*/
            }
            public VG0268B_LR04_LINHA04 LR04_LINHA04 { get; set; } = new VG0268B_LR04_LINHA04();
            public class VG0268B_LR04_LINHA04 : VarBasis
            {
                /*"      10          LR04-USUARIO         PIC X(030) VALUE     '     CAIXA SEGUROS'.*/
                public StringBasis LR04_USUARIO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     CAIXA SEGUROS");
                /*"    05            LR05-LINHA05.*/
            }
            public VG0268B_LR05_LINHA05 LR05_LINHA05 { get; set; } = new VG0268B_LR05_LINHA05();
            public class VG0268B_LR05_LINHA05 : VarBasis
            {
                /*"      10          LR05-ENDERECO        PIC X(070) VALUE     '     SCN Q1 BLOCO A - ED. NUMBER ONE - 13 ANDAR'.*/
                public StringBasis LR05_ENDERECO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"     SCN Q1 BLOCO A - ED. NUMBER ONE - 13 ANDAR");
                /*"    05            LR06-LINHA06.*/
            }
            public VG0268B_LR06_LINHA06 LR06_LINHA06 { get; set; } = new VG0268B_LR06_LINHA06();
            public class VG0268B_LR06_LINHA06 : VarBasis
            {
                /*"      10          LR06-UNID-POSTAGEM   PIC X(030) VALUE     '     DR/BSB/BSA'.*/
                public StringBasis LR06_UNID_POSTAGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     DR/BSB/BSA");
                /*"    05            LR07-LINHA07.*/
            }
            public VG0268B_LR07_LINHA07 LR07_LINHA07 { get; set; } = new VG0268B_LR07_LINHA07();
            public class VG0268B_LR07_LINHA07 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR02-SEQ             PIC ZZ.ZZ9.*/
                public IntBasis LR02_SEQ { get; set; } = new IntBasis(new PIC("9", "5", "ZZ.ZZ9."));
                /*"      10          FILLER               PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LR02-MES             PIC X(012).*/
                public StringBasis LR02_MES { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"    05            LR08-LINHA08.*/
            }
            public VG0268B_LR08_LINHA08 LR08_LINHA08 { get; set; } = new VG0268B_LR08_LINHA08();
            public class VG0268B_LR08_LINHA08 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR08-TIPO.*/
                public VG0268B_LR08_TIPO LR08_TIPO { get; set; } = new VG0268B_LR08_TIPO();
                public class VG0268B_LR08_TIPO : VarBasis
                {
                    /*"        15        LR08-COD-PRODUTO     PIC 9(004).*/
                    public IntBasis LR08_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15        FILLER               PIC X(001) VALUE '-'.*/
                    public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"        15        LR08-NOME-PRODUTO    PIC X(030).*/
                    public StringBasis LR08_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"    05            LR09-LINHA09.*/
                }
            }
            public VG0268B_LR09_LINHA09 LR09_LINHA09 { get; set; } = new VG0268B_LR09_LINHA09();
            public class VG0268B_LR09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR04-DATA            PIC X(010).*/
                public StringBasis LR04_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05            LR10-LINHA10-A.*/
            }
            public VG0268B_LR10_LINHA10_A LR10_LINHA10_A { get; set; } = new VG0268B_LR10_LINHA10_A();
            public class VG0268B_LR10_LINHA10_A : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR10-NUCLEO          PIC X(030) VALUE                 'BRASILIA(DF)'.*/
                public StringBasis LR10_NUCLEO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"BRASILIA(DF)");
                /*"    05            LR10-LINHA10.*/
            }
            public VG0268B_LR10_LINHA10 LR10_LINHA10 { get; set; } = new VG0268B_LR10_LINHA10();
            public class VG0268B_LR10_LINHA10 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR02-PAGINA          PIC 9(003).*/
                public IntBasis LR02_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER               PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LR02-PAG-FINAL       PIC 9(003).*/
                public IntBasis LR02_PAG_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            LR11-LINHA11.*/
            }
            public VG0268B_LR11_LINHA11 LR11_LINHA11 { get; set; } = new VG0268B_LR11_LINHA11();
            public class VG0268B_LR11_LINHA11 : VarBasis
            {
                /*"      10          FILLER              PIC X(101) VALUE SPACES.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "101", "X(101)"), @"");
                /*"      10          LR11-GEPES          PIC X(008) VALUE                                                'GEPES - '.*/
                public StringBasis LR11_GEPES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
                /*"      10          LR03-TP-PGTO        PIC X(022) VALUE SPACES.*/
                public StringBasis LR03_TP_PGTO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05            LR12-LINHA12.*/
            }
            public VG0268B_LR12_LINHA12 LR12_LINHA12 { get; set; } = new VG0268B_LR12_LINHA12();
            public class VG0268B_LR12_LINHA12 : VarBasis
            {
                /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          LR05-CEPI           PIC 9(005).*/
                public IntBasis LR05_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LR05-COMPL-CEPI     PIC 9(003).*/
                public IntBasis LR05_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LR05-CEPF           PIC 9(005).*/
                public IntBasis LR05_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LR05-COMPL-CEPF     PIC 9(003).*/
                public IntBasis LR05_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LR05-OBJI           PIC ZZZ.999.*/
                public IntBasis LR05_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-OBJF           PIC ZZZ.999.*/
                public IntBasis LR05_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR05-AMARI          PIC ZZZ.999.*/
                public IntBasis LR05_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-AMARF          PIC ZZZ.999.*/
                public IntBasis LR05_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR05-QTD-OBJ        PIC ZZZ.999.*/
                public IntBasis LR05_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-QTD-AMAR       PIC ZZZ.999.*/
                public IntBasis LR05_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          LR05-OBS            PIC X(023).*/
                public StringBasis LR05_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LR13-LINHA13.*/
            }
            public VG0268B_LR13_LINHA13 LR13_LINHA13 { get; set; } = new VG0268B_LR13_LINHA13();
            public class VG0268B_LR13_LINHA13 : VarBasis
            {
                /*"      10          FILLER              PIC X(001) VALUE '1'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        AC-LINHAS           PIC  9(002)    VALUE 80.*/
            }
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"    05        WWORK-QTDE01.*/
            public VG0268B_WWORK_QTDE01 WWORK_QTDE01 { get; set; } = new VG0268B_WWORK_QTDE01();
            public class VG0268B_WWORK_QTDE01 : VarBasis
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
            /*"    05        WS-COUNT            PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05        WHOST-PROXIMA-DATA  PIC  X(010)    VALUE SPACES.*/
            public StringBasis WHOST_PROXIMA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05        AC-PAGINA           PIC  9(003)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05        AC-CONTA1           PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-I-RELATORIOS     PIC S9(005)    COMP-3 VALUE +0*/
            public IntBasis AC_I_RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
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
            /*"    05        WS-IND-LADO         PIC  9(001)    VALUE ZEROS.*/
            public IntBasis WS_IND_LADO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05        WS-NUM-APOLICE-ANT  PIC  9(013).*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-CODSUBES-ANT     PIC  9(005).*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-JDE-GER          PIC  X(008).*/
            public StringBasis WS_JDE_GER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-CEP-G-ANT        PIC  9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        WS-NOME-COR-ANT.*/
            public VG0268B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VG0268B_WS_NOME_COR_ANT();
            public class VG0268B_WS_NOME_COR_ANT : VarBasis
            {
                /*"      10      WS-FAIXA1-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-FAIXA2-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-NOME-ANT         PIC  X(030).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05        WS-INF              PIC  9(009).*/
            }
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-SUP              PIC  9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WIND                PIC S9(008)    VALUE +0 COMP.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"    05        WIND1               PIC S9(008)    VALUE +0 COMP.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"    05        WINDM               PIC S9(008)    VALUE +0 COMP.*/
            public IntBasis WINDM { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"    05        IDX-IND1            PIC S9(008)    VALUE +0 COMP.*/
            public IntBasis IDX_IND1 { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"    05        INF                 PIC S9(009)    COMP.*/
            public IntBasis INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        SUP                 PIC S9(009)    COMP.*/
            public IntBasis SUP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        DEST-NUM-CEP.*/
            public VG0268B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VG0268B_DEST_NUM_CEP();
            public class VG0268B_DEST_NUM_CEP : VarBasis
            {
                /*"      15      DEST-CEP            PIC  9(005)    VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      15      DEST-CEP-COMPL      PIC  9(003)    VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05        WS-CNPJ             PIC  9(015).*/
            }
            public IntBasis WS_CNPJ { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CNPJ-R           REDEFINES              WS-CNPJ.*/
            private _REDEF_VG0268B_WS_CNPJ_R _ws_cnpj_r { get; set; }
            public _REDEF_VG0268B_WS_CNPJ_R WS_CNPJ_R
            {
                get { _ws_cnpj_r = new _REDEF_VG0268B_WS_CNPJ_R(); _.Move(WS_CNPJ, _ws_cnpj_r); VarBasis.RedefinePassValue(WS_CNPJ, _ws_cnpj_r, WS_CNPJ); _ws_cnpj_r.ValueChanged += () => { _.Move(_ws_cnpj_r, WS_CNPJ); }; return _ws_cnpj_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cnpj_r, WS_CNPJ); }
            }  //Redefines
            public class _REDEF_VG0268B_WS_CNPJ_R : VarBasis
            {
                /*"      10      WS-NRCNPJ1          PIC  9(009).*/
                public IntBasis WS_NRCNPJ1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10      WS-NRCNPJ2          PIC  9(004).*/
                public IntBasis WS_NRCNPJ2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WS-DVCNPJ           PIC  9(002).*/
                public IntBasis WS_DVCNPJ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA-SQL.*/

                public _REDEF_VG0268B_WS_CNPJ_R()
                {
                    WS_NRCNPJ1.ValueChanged += OnValueChanged;
                    WS_NRCNPJ2.ValueChanged += OnValueChanged;
                    WS_DVCNPJ.ValueChanged += OnValueChanged;
                }

            }
            public VG0268B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG0268B_WS_DATA_SQL();
            public class VG0268B_WS_DATA_SQL : VarBasis
            {
                /*"      10      WS-ANO-SQL          PIC  9(004).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-DATA.*/
            }
            public VG0268B_WS_DATA WS_DATA { get; set; } = new VG0268B_WS_DATA();
            public class VG0268B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-DATA1.*/
            }
            public VG0268B_WS_DATA1 WS_DATA1 { get; set; } = new VG0268B_WS_DATA1();
            public class VG0268B_WS_DATA1 : VarBasis
            {
                /*"      10      WS-ANO1             PIC  9(004).*/
                public IntBasis WS_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES1             PIC  9(002).*/
                public IntBasis WS_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA1             PIC  9(002).*/
                public IntBasis WS_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA2.*/
            }
            public VG0268B_WS_DATA2 WS_DATA2 { get; set; } = new VG0268B_WS_DATA2();
            public class VG0268B_WS_DATA2 : VarBasis
            {
                /*"      10      WS-ANO2             PIC  9(004).*/
                public IntBasis WS_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES2             PIC  9(002).*/
                public IntBasis WS_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA2             PIC  9(002).*/
                public IntBasis WS_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DTVENCTO-SQL.*/
            }
            public VG0268B_WS_DTVENCTO_SQL WS_DTVENCTO_SQL { get; set; } = new VG0268B_WS_DTVENCTO_SQL();
            public class VG0268B_WS_DTVENCTO_SQL : VarBasis
            {
                /*"      10      WS-ANO-VCT          PIC  9(004).*/
                public IntBasis WS_ANO_VCT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-VCT          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_VCT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-VCT          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_VCT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-CERTIF           PIC  9(015).*/
            }
            public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CERTIF-R         REDEFINES WS-CERTIF.*/
            private _REDEF_VG0268B_WS_CERTIF_R _ws_certif_r { get; set; }
            public _REDEF_VG0268B_WS_CERTIF_R WS_CERTIF_R
            {
                get { _ws_certif_r = new _REDEF_VG0268B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
            }  //Redefines
            public class _REDEF_VG0268B_WS_CERTIF_R : VarBasis
            {
                /*"      10      WS-NRCERTIF         PIC  9(014).*/
                public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10      WS-DVCERTIF         PIC  9(001).*/
                public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-DATA-I.*/

                public _REDEF_VG0268B_WS_CERTIF_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                    WS_DVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public VG0268B_WS_DATA_I WS_DATA_I { get; set; } = new VG0268B_WS_DATA_I();
            public class VG0268B_WS_DATA_I : VarBasis
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
            /*"    05        WS-NUM-CEP-AUX      PIC  9(008).*/
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-NUM-CEP-AUX-R    REDEFINES              WS-NUM-CEP-AUX.*/
            private _REDEF_VG0268B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_VG0268B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_VG0268B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VG0268B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10      WS-CEP-AUX          PIC  9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CEP-COMPL-AUX    PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        WS-NUM-CEP-AUX-R1   REDEFINES              WS-NUM-CEP-AUX.*/

                public _REDEF_VG0268B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG0268B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_VG0268B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_VG0268B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VG0268B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10      WS-CEP-COMPL-AUX1   PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WS-CEP-AUX1         PIC  9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05        WS-CHAVE            PIC  X(021).*/

                public _REDEF_VG0268B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
            /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
            private _REDEF_VG0268B_WS_CHAVE_R _ws_chave_r { get; set; }
            public _REDEF_VG0268B_WS_CHAVE_R WS_CHAVE_R
            {
                get { _ws_chave_r = new _REDEF_VG0268B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
                set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
            }  //Redefines
            public class _REDEF_VG0268B_WS_CHAVE_R : VarBasis
            {
                /*"      10      WS-NUM-APOLICE      PIC  9(013).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-CODSUBES         PIC  9(005).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CODOPER          PIC  9(003).*/
                public IntBasis WS_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        AC-LIDOS            PIC  9(009)    VALUE ZEROES.*/

                public _REDEF_VG0268B_WS_CHAVE_R()
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
            /*"    05        WFIM-V1SISTEMA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V1AGENCEF      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0FAIXACEP     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0HISTCOBVA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0PARCELVA     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0PARCELVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-SORT           PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        LK-PROSOMU1.*/
            public VG0268B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VG0268B_LK_PROSOMU1();
            public class VG0268B_LK_PROSOMU1 : VarBasis
            {
                /*"      10      LK-DATA-SOM         PIC  9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-SOM-R       REDEFINES              LK-DATA-SOM.*/
                private _REDEF_VG0268B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_VG0268B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_VG0268B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_VG0268B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15    LK-DIA-SOM          PIC  9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-SOM          PIC  9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-SOM          PIC  9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      LK-QTDIAS           PIC S9(005)    COMP-3 VALUE +2*/

                    public _REDEF_VG0268B_LK_DATA_SOM_R()
                    {
                        LK_DIA_SOM.ValueChanged += OnValueChanged;
                        LK_MES_SOM.ValueChanged += OnValueChanged;
                        LK_ANO_SOM.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +2);
                /*"      10      LK-DATA-CALC        PIC  9(008).*/
                public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-CALC-R      REDEFINES              LK-DATA-CALC.*/
                private _REDEF_VG0268B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_VG0268B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_VG0268B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_VG0268B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15    LK-DIA-CALC         PIC  9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-CALC         PIC  9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-CALC         PIC  9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"01            TAB-FILIAL.*/

                    public _REDEF_VG0268B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public VG0268B_TAB_FILIAL TAB_FILIAL { get; set; } = new VG0268B_TAB_FILIAL();
        public class VG0268B_TAB_FILIAL : VarBasis
        {
            /*"    05        FILLER              OCCURS 19 TIMES.*/
            public ListBasis<VG0268B_FILLER_125> FILLER_125 { get; set; } = new ListBasis<VG0268B_FILLER_125>(19);
            public class VG0268B_FILLER_125 : VarBasis
            {
                /*"      10      TAB-FONTE           PIC  9(04).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      TAB-NOMEFTE         PIC  X(40).*/
                public StringBasis TAB_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      TAB-ENDERFTE        PIC  X(40).*/
                public StringBasis TAB_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      TAB-BAIRRO          PIC  X(20).*/
                public StringBasis TAB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      TAB-CIDADE          PIC  X(20).*/
                public StringBasis TAB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      TAB-CEP             PIC  9(08).*/
                public IntBasis TAB_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"      10      TAB-UF              PIC  X(02).*/
                public StringBasis TAB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"01            TABELA-CEP.*/
            }
        }
        public VG0268B_TABELA_CEP TABELA_CEP { get; set; } = new VG0268B_TABELA_CEP();
        public class VG0268B_TABELA_CEP : VarBasis
        {
            /*"    05        CEP                 OCCURS 2000 TIMES.*/
            public ListBasis<VG0268B_CEP> CEP { get; set; } = new ListBasis<VG0268B_CEP>(2000);
            public class VG0268B_CEP : VarBasis
            {
                /*"      10      TAB-FX-CEP-G        PIC  9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TAB-FAIXAS.*/
                public VG0268B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new VG0268B_TAB_FAIXAS();
                public class VG0268B_TAB_FAIXAS : VarBasis
                {
                    /*"        15    TAB-FX-INI          PIC  9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-FIM          PIC  9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-NOME         PIC  X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"        15    TAB-FX-CENTR        PIC  X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01            TABELA-VALORES.*/
                }
            }
        }
        public VG0268B_TABELA_VALORES TABELA_VALORES { get; set; } = new VG0268B_TABELA_VALORES();
        public class VG0268B_TABELA_VALORES : VarBasis
        {
            /*"    05        TAB-VALORES         OCCURS    3 TIMES.*/
            public ListBasis<VG0268B_TAB_VALORES> TAB_VALORES { get; set; } = new ListBasis<VG0268B_TAB_VALORES>(3);
            public class VG0268B_TAB_VALORES : VarBasis
            {
                /*"      10      TAB-VLPRMTOT        PIC  9(013)V99.*/
                public DoubleBasis TAB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10      TAB-VLPREMIO        PIC  9(013)V99.*/
                public DoubleBasis TAB_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10      TAB-VLMULTA         PIC  9(013)V99.*/
                public DoubleBasis TAB_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TABELA-TOTAIS.*/
            }
        }
        public VG0268B_TABELA_TOTAIS TABELA_TOTAIS { get; set; } = new VG0268B_TABELA_TOTAIS();
        public class VG0268B_TABELA_TOTAIS : VarBasis
        {
            /*"    05        TAB-TOTAIS          OCCURS  2000 TIMES.*/
            public ListBasis<VG0268B_TAB_TOTAIS> TAB_TOTAIS { get; set; } = new ListBasis<VG0268B_TAB_TOTAIS>(2000);
            public class VG0268B_TAB_TOTAIS : VarBasis
            {
                /*"      10      TAB1-OBJI           PIC  9(006).*/
                public IntBasis TAB1_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-OBJF           PIC  9(006).*/
                public IntBasis TAB1_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-AMARI          PIC  9(006).*/
                public IntBasis TAB1_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-AMARF          PIC  9(006).*/
                public IntBasis TAB1_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-QTD-OBJ        PIC  9(006).*/
                public IntBasis TAB1_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-QTD-AMAR       PIC  9(006).*/
                public IntBasis TAB1_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01            TABELA-MSG.*/
            }
        }
        public VG0268B_TABELA_MSG TABELA_MSG { get; set; } = new VG0268B_TABELA_MSG();
        public class VG0268B_TABELA_MSG : VarBasis
        {
            /*"    05        TAB-MSG             OCCURS 3000  TIMES.*/
            public ListBasis<VG0268B_TAB_MSG> TAB_MSG { get; set; } = new ListBasis<VG0268B_TAB_MSG>(3000);
            public class VG0268B_TAB_MSG : VarBasis
            {
                /*"      10      TABJ-CHAVE          PIC  X(021).*/
                public StringBasis TABJ_CHAVE { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
                /*"      10      TABJ-CHAVE-R        REDEFINES              TABJ-CHAVE.*/
                private _REDEF_VG0268B_TABJ_CHAVE_R _tabj_chave_r { get; set; }
                public _REDEF_VG0268B_TABJ_CHAVE_R TABJ_CHAVE_R
                {
                    get { _tabj_chave_r = new _REDEF_VG0268B_TABJ_CHAVE_R(); _.Move(TABJ_CHAVE, _tabj_chave_r); VarBasis.RedefinePassValue(TABJ_CHAVE, _tabj_chave_r, TABJ_CHAVE); _tabj_chave_r.ValueChanged += () => { _.Move(_tabj_chave_r, TABJ_CHAVE); }; return _tabj_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tabj_chave_r, TABJ_CHAVE); }
                }  //Redefines
                public class _REDEF_VG0268B_TABJ_CHAVE_R : VarBasis
                {
                    /*"        15    TABJ-NUM-APOLICE    PIC  9(013).*/
                    public IntBasis TABJ_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"        15    TABJ-CODSUBES       PIC  9(005).*/
                    public IntBasis TABJ_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"        15    TABJ-CODOPER        PIC  9(003).*/
                    public IntBasis TABJ_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"      10      TABJ-JDE            PIC  X(008).*/

                    public _REDEF_VG0268B_TABJ_CHAVE_R()
                    {
                        TABJ_NUM_APOLICE.ValueChanged += OnValueChanged;
                        TABJ_CODSUBES.ValueChanged += OnValueChanged;
                        TABJ_CODOPER.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis TABJ_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10      TABJ-JDL            PIC  X(008).*/
                public StringBasis TABJ_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01            TABELA-MESES.*/
            }
        }
        public VG0268B_TABELA_MESES TABELA_MESES { get; set; } = new VG0268B_TABELA_MESES();
        public class VG0268B_TABELA_MESES : VarBasis
        {
            /*"    05        TAB-MESES.*/
            public VG0268B_TAB_MESES TAB_MESES { get; set; } = new VG0268B_TAB_MESES();
            public class VG0268B_TAB_MESES : VarBasis
            {
                /*"      10      FILLER              PIC  X(009)  VALUE '  JANEIRO'*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE 'FEVEREIRO'*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    MARCO'*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    ABRIL'*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"      10      FILLER              PIC  X(009)  VALUE '     MAIO'*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JUNHO'*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JULHO'*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '   AGOSTO'*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' SETEMBRO'*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '  OUTUBRO'*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' NOVEMBRO'*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' DEZEMBRO'*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"    05        TAB-MESES-R         REDEFINES              TAB-MESES.*/
            }
            private _REDEF_VG0268B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_VG0268B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_VG0268B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_VG0268B_TAB_MESES_R : VarBasis
            {
                /*"      10      TAB-MES             OCCURS 12 TIMES                                  PIC  X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01          WABEND.*/

                public _REDEF_VG0268B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public VG0268B_WABEND WABEND { get; set; } = new VG0268B_WABEND();
        public class VG0268B_WABEND : VarBasis
        {
            /*"      05    FILLER              PIC  X(010) VALUE           ' VG0268B'.*/
            public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0268B");
            /*"      05    FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05    WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05    FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.GEOBJECT GEOBJECT { get; set; } = new Dclgens.GEOBJECT();
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VG0268B_CFAIXACEP CFAIXACEP { get; set; } = new VG0268B_CFAIXACEP();
        public VG0268B_V1AGENCEF V1AGENCEF { get; set; } = new VG0268B_V1AGENCEF();
        public VG0268B_CHISTCOB CHISTCOB { get; set; } = new VG0268B_CHISTCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVG0268B_FILE_NAME_P, string SVG0268B_FILE_NAME_P, string FVG0268B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVG0268B.SetFile(RVG0268B_FILE_NAME_P);
                SVG0268B.SetFile(SVG0268B_FILE_NAME_P);
                FVG0268B.SetFile(FVG0268B_FILE_NAME_P);

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
            /*" -1027- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", WABEND.WNR_EXEC_SQL);

            /*" -1028- DISPLAY ' ' */
            _.Display($" ");

            /*" -1030- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1040- DISPLAY 'PROGRAMA VG0268B - VERSAO V.18 ' '- DEMANDA 582106 - 22/08/2024 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VG0268B - VERSAO V.18 - DEMANDA 582106 - 22/08/2024 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1042- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1051- DISPLAY ' ' */
            _.Display($" ");

            /*" -1053- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1054- DISPLAY ' ' */
            _.Display($" ");

            /*" -1061- DISPLAY 'INICIOU PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1063- DISPLAY ' ' */
            _.Display($" ");

            /*" -1065- MOVE ZEROS TO TABELA-TOTAIS */
            _.Move(0, TABELA_TOTAIS);

            /*" -1067- INITIALIZE TAB-FILIAL. */
            _.Initialize(
                TAB_FILIAL
            );

            /*" -1069- PERFORM R0500-00-DECLARE-V1AGENCEF. */

            R0500_00_DECLARE_V1AGENCEF_SECTION();

            /*" -1071- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

            /*" -1072- IF WFIM-V1AGENCEF NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1AGENCEF.IsEmpty())
            {

                /*" -1073- DISPLAY 'R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -1075- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1080- PERFORM R0520-00-CARREGA-FILIAL VARYING IDX-IND1 FROM 1 BY 1 UNTIL IDX-IND1 > 19 OR WFIM-V1AGENCEF EQUAL 'S' . */

            for (AREA_DE_WORK.IDX_IND1.Value = 1; !(AREA_DE_WORK.IDX_IND1 > 19 || AREA_DE_WORK.WFIM_V1AGENCEF == "S"); AREA_DE_WORK.IDX_IND1.Value += 1)
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1082- PERFORM R0900-00-DECLARE-V0HISTCOBVA. */

            R0900_00_DECLARE_V0HISTCOBVA_SECTION();

            /*" -1084- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

            /*" -1085- IF WFIM-V0HISTCOBVA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V0HISTCOBVA == "S")
            {

                /*" -1086- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1087- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1089- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1091- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1092- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -1094- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1096- PERFORM R0200-00-CARREGA-V0FAIXACEP. */

            R0200_00_CARREGA_V0FAIXACEP_SECTION();

            /*" -1098- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1105- SORT SVG0268B ON ASCENDING KEY SVA-NRAPOLICE SVA-CODSUBES SVA-CEP-G SVA-NUM-CEP SVA-CODOPER INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SVG0268B.Sort("SVA-NRAPOLICE,SVA-CODSUBES,SVA-CEP-G,SVA-NUM-CEP,SVA-CODOPER", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1108- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1109- DISPLAY '*** VG0268B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VG0268B *** PROBLEMAS NO SORT ");

                /*" -1110- DISPLAY '*** VG0268B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VG0268B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1111- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -1111- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1117- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1117- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1120- DISPLAY '*** VG0268B - ' */
            _.Display($"*** VG0268B - ");

            /*" -1121- DISPLAY 'LIDOS V0HISTCOBVA        ' AC-LIDOS. */
            _.Display($"LIDOS V0HISTCOBVA        {AREA_DE_WORK.AC_LIDOS}");

            /*" -1123- DISPLAY 'COBRANCAS IMPRESSAS      ' AC-IMPRESSOS. */
            _.Display($"COBRANCAS IMPRESSAS      {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -1124- DISPLAY '*** VG0268B - TERMINO NORMAL ***' */
            _.Display($"*** VG0268B - TERMINO NORMAL ***");

            /*" -1124- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1135- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0HISTCOBVA EQUAL 'S' . */

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
            /*" -1149- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1150- MOVE 'CO03.DBM' TO WS-JDE-GER. */
            _.Move("CO03.DBM", AREA_DE_WORK.WS_JDE_GER);

            /*" -1154- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LF02-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LF02_LINHA02.LF02_FORM);

            /*" -1155- MOVE 'CO05.JDT' TO WS-JDE-GER. */
            _.Move("CO05.JDT", AREA_DE_WORK.WS_JDE_GER);

            /*" -1157- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LR02-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LR02_LINHA02.LR02_FORM);

            /*" -1161- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

            /*" -1162- IF WFIM-SORT NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SORT != "S")
            {

                /*" -1163- WRITE RVG0268B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1164- WRITE RVG0268B-RECORD FROM LC02-LINHA02 */
                _.Move(AREA_DE_WORK.LC02_LINHA02.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1165- WRITE RVG0268B-RECORD FROM LC03-LINHA03 */
                _.Move(AREA_DE_WORK.LC03_LINHA03.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1166- WRITE RVG0268B-RECORD FROM LC04-LINHA04 */
                _.Move(AREA_DE_WORK.LC04_LINHA04.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1167- WRITE RVG0268B-RECORD FROM LC05-LINHA05 */
                _.Move(AREA_DE_WORK.LC05_LINHA05.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1168- WRITE RVG0268B-RECORD FROM LC06-LINHA06 */
                _.Move(AREA_DE_WORK.LC06_LINHA06.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1169- WRITE RVG0268B-RECORD FROM LC07-LINHA07 */
                _.Move(AREA_DE_WORK.LC07_LINHA07.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1170- WRITE FVG0268B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1171- WRITE FVG0268B-RECORD FROM LC02-LINHA02 */
                _.Move(AREA_DE_WORK.LC02_LINHA02.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1172- WRITE FVG0268B-RECORD FROM LC03-LINHA03 */
                _.Move(AREA_DE_WORK.LC03_LINHA03.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1173- WRITE FVG0268B-RECORD FROM LC07-LINHA07 */
                _.Move(AREA_DE_WORK.LC07_LINHA07.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -1175- WRITE FVG0268B-RECORD FROM LC08-LINHA08. */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());
            }


            /*" -1180- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -1181- WRITE RVG0268B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1183- WRITE FVG0268B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1183- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1195- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -1206- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1209- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1210- DISPLAY 'VG0268B - SISTEMA FI NAO ESTA CADASTRADO' */
                _.Display($"VG0268B - SISTEMA FI NAO ESTA CADASTRADO");

                /*" -1211- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -1211- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1206- EXEC SQL SELECT DTMOVABE, MONTH(DTMOVABE), YEAR(DTMOVABE), (DTMOVABE + 1 DAY) INTO :V1SIST-DTMOVABE, :V1SIST-MESREFER, :V1SIST-ANOREFER, :WHOST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
                _.Move(executed_1.WHOST_DTMOVABE, WHOST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-SECTION */
        private void R0200_00_CARREGA_V0FAIXACEP_SECTION()
        {
            /*" -1223- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -1233- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1();

            /*" -1235- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1();

            /*" -1238- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1239- DISPLAY 'VG0268B - PROBLEMAS NA V0FAIXA_CEP' */
                _.Display($"VG0268B - PROBLEMAS NA V0FAIXA_CEP");

                /*" -1241- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1242- PERFORM R0210-00-FETCH-V0FAIXACEP UNTIL WFIM-V0FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0FAIXACEP == "S"))
            {

                R0210_00_FETCH_V0FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1()
        {
            /*" -1233- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :V1SIST-DTMOVABE AND DATA_TERVIGENCIA >= :V1SIST-DTMOVABE ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new VG0268B_CFAIXACEP(true);
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
            /*" -1235- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -1305- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT DISTINCT B.COD_FONTE, C.NOMEFTE, C.ENDERFTE, C.BAIRRO, C.CIDADE, C.CEP, C.ESTADO FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B, SEGUROS.V1FONTE C WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND B.COD_FONTE = C.FONTE ORDER BY B.COD_FONTE END-EXEC. */
            V1AGENCEF = new VG0268B_V1AGENCEF(false);
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
            /*" -1254- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", WABEND.WNR_EXEC_SQL);

            /*" -1261- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1();

            /*" -1264- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1265- MOVE 'S' TO WFIM-V0FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_V0FAIXACEP);

                /*" -1267- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1267- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1 */

                R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1();

                /*" -1271- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1272- MOVE V0FAIC-FAIXA TO TAB-FX-CEP-G (V0FAIC-FAIXA). */
            _.Move(V0FAIC_FAIXA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FX_CEP_G);

            /*" -1273- MOVE V0FAIC-CEPINI TO TAB-FX-INI (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CEPINI, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -1274- MOVE V0FAIC-CEPFIM TO TAB-FX-FIM (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CEPFIM, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -1275- MOVE V0FAIC-DESC-FAIXA TO TAB-FX-NOME (V0FAIC-FAIXA). */
            _.Move(V0FAIC_DESC_FAIXA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1277- MOVE V0FAIC-CENTRALIZA TO TAB-FX-CENTR (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CENTRALIZA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -1277- GO TO R0210-00-FETCH-V0FAIXACEP. */
            new Task(() => R0210_00_FETCH_V0FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1()
        {
            /*" -1261- EXEC SQL FETCH CFAIXACEP INTO :V0FAIC-FAIXA, :V0FAIC-CEPINI, :V0FAIC-CEPFIM, :V0FAIC-DESC-FAIXA, :V0FAIC-CENTRALIZA END-EXEC. */

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
            /*" -1267- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-SECTION */
        private void R0500_00_DECLARE_V1AGENCEF_SECTION()
        {
            /*" -1289- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1305- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -1307- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -1310- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1311- DISPLAY 'R0500 - PROBLEMAS DECLARE (V1AGENCEF) ..' */
                _.Display($"R0500 - PROBLEMAS DECLARE (V1AGENCEF) ..");

                /*" -1312- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1312- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1()
        {
            /*" -1307- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1()
        {
            /*" -1410- EXEC SQL DECLARE CHISTCOB CURSOR FOR SELECT A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.DTVENCTO, A.VLPRMTOT, A.CODOPER, A.OPCAOPAG, A.NRTITCOMP, B.CODPRODU, B.OCORHIST, B.CODCLIEN, B.IDE_SEXO, B.OPCAO_COBER, B.NUM_APOLICE, B.CODSUBES, B.OCOREND, B.AGECOBR, B.FONTE, B.DTQITBCO, C.DTVENCTO ,D.COD_EMPRESA FROM SEGUROS.V0HISTCOBVA A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PARCELVA C ,SEGUROS.PRODUTO D WHERE A.SITUACAO = '5' AND A.NRCERTIF = B.NRCERTIF AND A.NRCERTIF = C.NRCERTIF AND A.NRPARCEL = C.NRPARCEL AND D.COD_PRODUTO = B.CODPRODU ORDER BY A.NRCERTIF, A.NRPARCEL END-EXEC. */
            CHISTCOB = new VG0268B_CHISTCOB(false);
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
							,D.COD_EMPRESA 
							FROM SEGUROS.V0HISTCOBVA A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0PARCELVA C 
							,SEGUROS.PRODUTO D 
							WHERE A.SITUACAO = '5' 
							AND A.NRCERTIF = B.NRCERTIF 
							AND A.NRCERTIF = C.NRCERTIF 
							AND A.NRPARCEL = C.NRPARCEL 
							AND D.COD_PRODUTO = B.CODPRODU 
							ORDER BY A.NRCERTIF
							, 
							A.NRPARCEL";

                return query;
            }
            CHISTCOB.GetQueryEvent += GetQuery_CHISTCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-SECTION */
        private void R0510_00_FETCH_V1AGENCEF_SECTION()
        {
            /*" -1324- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -1333- PERFORM R0510_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            R0510_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -1336- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1337- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1338- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_V1AGENCEF);

                    /*" -1338- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -1340- ELSE */
                }
                else
                {


                    /*" -1340- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -1342- DISPLAY 'R0510 - (PROBLEMAS NO FETCH V1AGENCEF) ..' */
                    _.Display($"R0510 - (PROBLEMAS NO FETCH V1AGENCEF) ..");

                    /*" -1343- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1343- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -1333- EXEC SQL FETCH V1AGENCEF INTO :V1MCEF-COD-FONTE, :V1FONT-NOMEFTE, :V1FONT-ENDERFTE, :V1FONT-BAIRRO, :V1FONT-CIDADE, :V1FONT-CEP, :V1FONT-UF END-EXEC. */

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
            /*" -1338- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -1340- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -1355- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -1356- MOVE V1MCEF-COD-FONTE TO TAB-FONTE (IDX-IND1) */
            _.Move(V1MCEF_COD_FONTE, TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_FONTE);

            /*" -1357- MOVE V1FONT-NOMEFTE TO TAB-NOMEFTE (IDX-IND1) */
            _.Move(V1FONT_NOMEFTE, TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE);

            /*" -1358- MOVE V1FONT-ENDERFTE TO TAB-ENDERFTE (IDX-IND1) */
            _.Move(V1FONT_ENDERFTE, TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE);

            /*" -1359- MOVE V1FONT-BAIRRO TO TAB-BAIRRO (IDX-IND1) */
            _.Move(V1FONT_BAIRRO, TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO);

            /*" -1360- MOVE V1FONT-CIDADE TO TAB-CIDADE (IDX-IND1) */
            _.Move(V1FONT_CIDADE, TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_CIDADE);

            /*" -1361- MOVE V1FONT-CEP TO TAB-CEP (IDX-IND1) */
            _.Move(V1FONT_CEP, TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_CEP);

            /*" -1363- MOVE V1FONT-UF TO TAB-UF (IDX-IND1) */
            _.Move(V1FONT_UF, TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_UF);

            /*" -1363- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-SECTION */
        private void R0900_00_DECLARE_V0HISTCOBVA_SECTION()
        {
            /*" -1375- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -1410- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1();

            /*" -1412- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1()
        {
            /*" -1412- EXEC SQL OPEN CHISTCOB END-EXEC. */

            CHISTCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-SECTION */
        private void R0910_00_FETCH_V0HISTCOBVA_SECTION()
        {
            /*" -1424- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -1447- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1 */

            R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1();

            /*" -1451- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1452- MOVE 'S' TO WFIM-V0HISTCOBVA */
                _.Move("S", AREA_DE_WORK.WFIM_V0HISTCOBVA);

                /*" -1454- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1454- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1 */

                R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1();

                /*" -1457- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1459- PERFORM R2710-00-SELECT-V0PRODUTOSVG. */

            R2710_00_SELECT_V0PRODUTOSVG_SECTION();

            /*" -1460- IF V0PROD-ESTR-COBR-I < ZEROS */

            if (V0PROD_ESTR_COBR_I < 00)
            {

                /*" -1462- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1463- IF V0PROD-ORIG-PRODU-I < ZEROS */

            if (V0PROD_ORIG_PRODU_I < 00)
            {

                /*" -1465- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1466- IF V0PROD-ESTR-COBR NOT = 'MULT' */

            if (V0PROD_ESTR_COBR != "MULT")
            {

                /*" -1468- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1472- IF V0PROD-ORIG-PRODU NOT = 'ESPEC' */

            if (V0PROD_ORIG_PRODU != "ESPEC")
            {

                /*" -1474- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1475- IF VIND-NRTITCOMP < ZEROS */

            if (VIND_NRTITCOMP < 00)
            {

                /*" -1480- MOVE ZEROS TO V0HIST-NRTITCOMP. */
                _.Move(0, V0HIST_NRTITCOMP);
            }


            /*" -1482- IF V0HIST-OPCAOPAG EQUAL '1' OR '2' NEXT SENTENCE */

            if (V0HIST_OPCAOPAG.In("1", "2"))
            {

                /*" -1483- ELSE */
            }
            else
            {


                /*" -1485- GO TO R0910-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0910_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1488- ADD 1 TO AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -1489- IF AC-CONTA > 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -1490- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1491- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -1491- DISPLAY '**** LIDOS V0HISTCOBVA ' AC-LIDOS ' ' WHORA-CURR. */

                $"**** LIDOS V0HISTCOBVA {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1()
        {
            /*" -1447- EXEC SQL FETCH CHISTCOB INTO :V0HIST-NRCERTIF, :V0HIST-NRPARCEL, :V0HIST-NRTIT, :V0HIST-DTVENCTO, :V0HIST-VLPRMTOT, :V0HIST-CODOPER, :V0HIST-OPCAOPAG, :V0HIST-NRTITCOMP, :V0HIST-CODPRODU, :V0HIST-OCORHIST, :V0HIST-CDCLIENTE, :V0HIST-IDSEXO, :V0HIST-OPCOBERT, :V0HIST-NRAPOLICE, :V0HIST-CODSUBES, :V0HIST-OCOREND, :V0HIST-AGECOBR, :V0HIST-FONTE, :V0HIST-DTQITBCO, :V0PARC-DTVENCTO ,:PRODUTO-COD-EMPRESA END-EXEC. */

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
            /*" -1454- EXEC SQL CLOSE CHISTCOB END-EXEC */

            CHISTCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1503- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -1506- MOVE V0HIST-NRAPOLICE TO V0MENS-NUM-APOLICE WS-NUM-APOLICE. */
            _.Move(V0HIST_NRAPOLICE, V0MENS_NUM_APOLICE);
            _.Move(V0HIST_NRAPOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);


            /*" -1509- MOVE V0HIST-CODSUBES TO V0MENS-CODSUBES WS-CODSUBES. */
            _.Move(V0HIST_CODSUBES, V0MENS_CODSUBES);
            _.Move(V0HIST_CODSUBES, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);


            /*" -1512- MOVE V0HIST-CODOPER TO WHOST-CODOPER WS-CODOPER. */
            _.Move(V0HIST_CODOPER, WHOST_CODOPER);
            _.Move(V0HIST_CODOPER, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);


            /*" -1514- PERFORM R1200-00-SELECT-V0CLIENTE. */

            R1200_00_SELECT_V0CLIENTE_SECTION();

            /*" -1516- PERFORM R1300-00-SELECT-V0ENDERECO. */

            R1300_00_SELECT_V0ENDERECO_SECTION();

            /*" -1518- PERFORM R1500-00-SELECT-V1AGENCEF. */

            R1500_00_SELECT_V1AGENCEF_SECTION();

            /*" -1520- PERFORM R1510-00-SELECT-V0OPCAOPAGVA. */

            R1510_00_SELECT_V0OPCAOPAGVA_SECTION();

            /*" -1521- MOVE V1MCEF-COD-FONTE TO SVA-FONTE. */
            _.Move(V1MCEF_COD_FONTE, REG_SVG0268B.SVA_FONTE);

            /*" -1522- MOVE V0CLIE-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVG0268B.SVA_NOME_RAZAO);

            /*" -1523- MOVE V0CLIE-CNPJ TO SVA-NRCNPJ. */
            _.Move(V0CLIE_CNPJ, REG_SVG0268B.SVA_NRCNPJ);

            /*" -1524- MOVE V0ENDE-ENDERECO TO SVA-ENDERECO. */
            _.Move(V0ENDE_ENDERECO, REG_SVG0268B.SVA_ENDERECO);

            /*" -1525- MOVE V0ENDE-BAIRRO TO SVA-BAIRRO. */
            _.Move(V0ENDE_BAIRRO, REG_SVG0268B.SVA_BAIRRO);

            /*" -1526- MOVE V0ENDE-CIDADE TO SVA-CIDADE. */
            _.Move(V0ENDE_CIDADE, REG_SVG0268B.SVA_CIDADE);

            /*" -1527- MOVE V0ENDE-UF TO SVA-UF. */
            _.Move(V0ENDE_UF, REG_SVG0268B.SVA_UF);

            /*" -1528- MOVE V0ENDE-CEP TO WS-NUM-CEP-AUX. */
            _.Move(V0ENDE_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1529- MOVE V0HIST-NRCERTIF TO SVA-NRCERTIF. */
            _.Move(V0HIST_NRCERTIF, REG_SVG0268B.SVA_NRCERTIF);

            /*" -1530- MOVE V0HIST-NRTIT TO SVA-NRTIT. */
            _.Move(V0HIST_NRTIT, REG_SVG0268B.SVA_NRTIT);

            /*" -1531- MOVE V0HIST-NRTITCOMP TO SVA-NRTITCOMP. */
            _.Move(V0HIST_NRTITCOMP, REG_SVG0268B.SVA_NRTITCOMP);

            /*" -1532- MOVE V0HIST-NRPARCEL TO SVA-NRPARCEL. */
            _.Move(V0HIST_NRPARCEL, REG_SVG0268B.SVA_NRPARCEL);

            /*" -1533- MOVE V0HIST-DTVENCTO TO SVA-DTVENCTO. */
            _.Move(V0HIST_DTVENCTO, REG_SVG0268B.SVA_DTVENCTO);

            /*" -1534- MOVE V0PARC-DTVENCTO TO SVA-DTVENCTO-ORIG. */
            _.Move(V0PARC_DTVENCTO, REG_SVG0268B.SVA_DTVENCTO_ORIG);

            /*" -1535- MOVE V0HIST-VLPRMTOT TO SVA-VLPRMTOT. */
            _.Move(V0HIST_VLPRMTOT, REG_SVG0268B.SVA_VLPRMTOT);

            /*" -1536- MOVE V0HIST-CODOPER TO SVA-CODOPER. */
            _.Move(V0HIST_CODOPER, REG_SVG0268B.SVA_CODOPER);

            /*" -1537- MOVE V0HIST-OCORHIST TO SVA-OCORHIST. */
            _.Move(V0HIST_OCORHIST, REG_SVG0268B.SVA_OCORHIST);

            /*" -1538- MOVE V0HIST-CODPRODU TO SVA-CODPRODU. */
            _.Move(V0HIST_CODPRODU, REG_SVG0268B.SVA_CODPRODU);

            /*" -1539- MOVE V0HIST-NRAPOLICE TO SVA-NRAPOLICE. */
            _.Move(V0HIST_NRAPOLICE, REG_SVG0268B.SVA_NRAPOLICE);

            /*" -1540- MOVE V0HIST-CODSUBES TO SVA-CODSUBES. */
            _.Move(V0HIST_CODSUBES, REG_SVG0268B.SVA_CODSUBES);

            /*" -1541- MOVE V0HIST-AGECOBR TO SVA-AGECOBR. */
            _.Move(V0HIST_AGECOBR, REG_SVG0268B.SVA_AGECOBR);

            /*" -1542- MOVE V0HIST-DTQITBCO TO SVA-DTQITBCO. */
            _.Move(V0HIST_DTQITBCO, REG_SVG0268B.SVA_DTQITBCO);

            /*" -1544- MOVE V0OPCP-PERIPGTO TO SVA-PERIPGTO. */
            _.Move(V0OPCP_PERIPGTO, REG_SVG0268B.SVA_PERIPGTO);

            /*" -1546- MOVE PRODUTO-COD-EMPRESA TO SVA-COD-EMPRESA. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, REG_SVG0268B.SVA_COD_EMPRESA);

            /*" -1547- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -1548- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVG0268B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -1549- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVG0268B.SVA_NUM_CEP.SVA_CEP);

                /*" -1550- ELSE */
            }
            else
            {


                /*" -1551- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVG0268B.SVA_NUM_CEP.SVA_CEP);

                /*" -1553- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL. */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVG0268B.SVA_NUM_CEP.SVA_CEP_COMPL);
            }


            /*" -1554- IF V0ENDE-CEP EQUAL ZEROS */

            if (V0ENDE_CEP == 00)
            {

                /*" -1555- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVG0268B.SVA_CEP_G);

                /*" -1556- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVG0268B.SVA_NOME_CORREIO);

                /*" -1557- ELSE */
            }
            else
            {


                /*" -1559- PERFORM R1900-00-LOCALIZA-CEP. */

                R1900_00_LOCALIZA_CEP_SECTION();
            }


            /*" -1559- RELEASE REG-SVG0268B. */
            SVG0268B.Release(REG_SVG0268B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1563- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-SECTION */
        private void R1200_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -1575- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1582- PERFORM R1200_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1200_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -1585- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1586- DISPLAY 'R1200 - PROBLEMAS NO ACESSO A V0CLIENTE' */
                _.Display($"R1200 - PROBLEMAS NO ACESSO A V0CLIENTE");

                /*" -1587- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -1587- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1200_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -1582- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CNPJ FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0HIST-CDCLIENTE END-EXEC. */

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
            /*" -1599- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1613- PERFORM R1300_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -1616- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1617- DISPLAY 'R1300 - PROBLEMAS NO ACESSO A V0ENDERECOS' */
                _.Display($"R1300 - PROBLEMAS NO ACESSO A V0ENDERECOS");

                /*" -1618- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -1618- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -1613- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-UF, :V0ENDE-CEP FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0HIST-CDCLIENTE AND OCORR_ENDERECO = :V0HIST-OCOREND END-EXEC. */

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
            /*" -1630- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1639- PERFORM R1500_00_SELECT_V1AGENCEF_DB_SELECT_1 */

            R1500_00_SELECT_V1AGENCEF_DB_SELECT_1();

            /*" -1642- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1643- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1644- MOVE V0HIST-FONTE TO V1MCEF-COD-FONTE */
                    _.Move(V0HIST_FONTE, V1MCEF_COD_FONTE);

                    /*" -1645- ELSE */
                }
                else
                {


                    /*" -1646- DISPLAY 'R1500 - PROBLEMAS SELECT V1AGENCEF ..' */
                    _.Display($"R1500 - PROBLEMAS SELECT V1AGENCEF ..");

                    /*" -1647- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1647- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_V1AGENCEF_DB_SELECT_1()
        {
            /*" -1639- EXEC SQL SELECT B.COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG < 1000 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :V0HIST-AGECOBR END-EXEC. */

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
            /*" -1659- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", WABEND.WNR_EXEC_SQL);

            /*" -1665- PERFORM R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1 */

            R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1();

            /*" -1668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1669- DISPLAY 'R1510 - PROBLEMAS SELECT V0OPCAOPAGVA ..' */
                _.Display($"R1510 - PROBLEMAS SELECT V0OPCAOPAGVA ..");

                /*" -1670- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1670- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-V0OPCAOPAGVA-DB-SELECT-1 */
        public void R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -1665- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HIST-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

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
            /*" -1680- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -1685- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -1687- DISPLAY '*** R1900 - CEP NAO ENCONTRADO ' V0ENDE-CEP ' ' V0HIST-NRCERTIF */

                $"*** R1900 - CEP NAO ENCONTRADO {V0ENDE_CEP} {V0HIST_NRCERTIF}"
                .Display();

                /*" -1688- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVG0268B.SVA_CEP_G);

                /*" -1689- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVG0268B.SVA_NOME_CORREIO);

                /*" -1691- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1692- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -1694- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -1695- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -1697- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -1699- IF V0ENDE-CEP GREATER WS-INF AND V0ENDE-CEP LESS WS-SUP */

            if (V0ENDE_CEP > AREA_DE_WORK.WS_INF && V0ENDE_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -1700- MOVE TAB-FX-CEP-G (WIND) TO SVA-CEP-G */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FX_CEP_G, REG_SVG0268B.SVA_CEP_G);

                /*" -1701- MOVE TAB-FAIXAS (WIND) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS, REG_SVG0268B.SVA_NOME_CORREIO);

                /*" -1702- ELSE */
            }
            else
            {


                /*" -1703- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -1703- GO TO R1900-10-LOOP. */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -1718- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE-ANT V0MENS-NUM-APOLICE WHOST-NRAPOLICE. */
            _.Move(REG_SVG0268B.SVA_NRAPOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0MENS_NUM_APOLICE, WHOST_NRAPOLICE);

            /*" -1722- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT V0MENS-CODSUBES WHOST-CODSUBES. */
            _.Move(REG_SVG0268B.SVA_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0MENS_CODSUBES, WHOST_CODSUBES);

            /*" -1724- PERFORM R2900-00-TRATA-V0RELATORIOS. */

            R2900_00_TRATA_V0RELATORIOS_SECTION();

            /*" -1726- PERFORM R2700-00-SELECT-V0PRODUTOSVG. */

            R2700_00_SELECT_V0PRODUTOSVG_SECTION();

            /*" -1727- MOVE V0PROD-CODPRODU TO LR08-COD-PRODUTO. */
            _.Move(V0PROD_CODPRODU, AREA_DE_WORK.LR08_LINHA08.LR08_TIPO.LR08_COD_PRODUTO);

            /*" -1729- MOVE V0PROD-NOMPRODU TO LR08-NOME-PRODUTO. */
            _.Move(V0PROD_NOMPRODU, AREA_DE_WORK.LR08_LINHA08.LR08_TIPO.LR08_NOME_PRODUTO);

            /*" -1731- PERFORM R2800-00-SELECT-V0CEDENTE. */

            R2800_00_SELECT_V0CEDENTE_SECTION();

            /*" -1733- MOVE V0PROD-NOMPRODU TO LR03-TP-PGTO. */
            _.Move(V0PROD_NOMPRODU, AREA_DE_WORK.LR11_LINHA11.LR03_TP_PGTO);

            /*" -1738- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVG0268B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVG0268B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -1740- MOVE 'C' TO WS-CONTR-PRODU. */
            _.Move("C", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -1742- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -1746- PERFORM R3000-00-IMPRIME-LST. */

            R3000_00_IMPRIME_LST_SECTION();

            /*" -1747- WRITE FVG0268B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1749- WRITE FVG0268B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1751- MOVE 'R' TO WS-CONTR-PRODU. */
            _.Move("R", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -1753- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -1763- MOVE ZEROS TO TABELA-TOTAIS WS-AMARRADO WS-CONTR-AMAR WS-CONTR-OBJ WS-CONTR-200 WS-SEQ AC-QTD-OBJ AC-CONTA1 AC-PAGINA WS-OCORR WIND. */
            _.Move(0, TABELA_TOTAIS, AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ, AREA_DE_WORK.WS_CONTR_200, AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.WS_OCORR, AREA_DE_WORK.WIND);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -1774- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SVG0268B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -1775- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SVG0268B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -1778- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -1779- MOVE TAB-FX-INI (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVG0268B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1780- MOVE WS-CEP-AUX TO LF03-FAIXA1. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1);

            /*" -1781- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA1C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1C);

            /*" -1782- MOVE TAB-FX-FIM (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVG0268B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1783- MOVE WS-CEP-AUX TO LF03-FAIXA2. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2);

            /*" -1786- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA2C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2C);

            /*" -1792- PERFORM R2100-00-PROCESSA-CEP UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVG0268B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVG0268B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || REG_SVG0268B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

            /*" -1793- MOVE WS-AMARRADO TO TAB1-AMARF(WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARF);

            /*" -1793- MOVE WS-SEQ TO TAB1-OBJF (WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -1807- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -1811- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -1812- WRITE RVG0268B-RECORD FROM LC08-LINHA08. */
            _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1813- WRITE RVG0268B-RECORD FROM LC09-LINHA09. */
            _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1815- WRITE RVG0268B-RECORD FROM LC10-LINHA10. */
            _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1822- PERFORM R2200-00-PROCESSA-FAC UNTIL SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199. */

            while (!(REG_SVG0268B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVG0268B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || REG_SVG0268B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -1825- ADD 1 TO WS-AMARRADO TAB1-QTD-AMAR (WS-CEP-G-ANT). */
            AREA_DE_WORK.WS_AMARRADO.Value = AREA_DE_WORK.WS_AMARRADO + 1;
            TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR + 1;

            /*" -1826- IF WS-CONTR-AMAR EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_AMAR == 00)
            {

                /*" -1827- MOVE 1 TO WS-CONTR-AMAR */
                _.Move(1, AREA_DE_WORK.WS_CONTR_AMAR);

                /*" -1830- MOVE WS-AMARRADO TO TAB1-AMARI (WS-CEP-G-ANT). */
                _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARI);
            }


            /*" -1831- MOVE WS-AMARRADO TO LF05-AMARRADO. */
            _.Move(AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.LF04_LINHA04.LF05_AMARRADO);

            /*" -1832- MOVE AC-QTD-OBJ TO LF04-QTD-OBJ. */
            _.Move(AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ);

            /*" -1833- MOVE WS-SEQ-INICIAL TO LF05-SEQ-INICIAL. */
            _.Move(AREA_DE_WORK.WS_SEQ_INICIAL, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_INICIAL);

            /*" -1837- MOVE WS-SEQ TO LF05-SEQ-FINAL. */
            _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_FINAL);

            /*" -1838- WRITE RVG0268B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1839- WRITE RVG0268B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1840- WRITE RVG0268B-RECORD FROM LF01-LINHA01. */
            _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1842- WRITE RVG0268B-RECORD FROM LC08-LINHA08. */
            _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1844- MOVE SPACES TO LF02-NOME-FAIXA. */
            _.Move("", AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

            /*" -1845- IF AC-CONTA1 GREATER 199 */

            if (AREA_DE_WORK.AC_CONTA1 > 199)
            {

                /*" -1847- MOVE TAB-FX-NOME (WS-CEP-G-ANT) TO LF02-NOME-FAIXA */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_NOME, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

                /*" -1848- ELSE */
            }
            else
            {


                /*" -1851- MOVE TAB-FX-CENTR(WS-CEP-G-ANT) TO LF02-NOME-FAIXA. */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_CENTR, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);
            }


            /*" -1852- WRITE RVG0268B-RECORD FROM LF02-LINHA02. */
            _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1853- WRITE RVG0268B-RECORD FROM LF03-LINHA03. */
            _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1855- WRITE RVG0268B-RECORD FROM LF04-LINHA04. */
            _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1856- WRITE RVG0268B-RECORD FROM LC12-LINHA12 */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1858- WRITE RVG0268B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1859- MOVE ZEROS TO AC-QTD-OBJ. */
            _.Move(0, AREA_DE_WORK.AC_QTD_OBJ);

            /*" -1859- MOVE 1 TO WS-CONTROLE. */
            _.Move(1, AREA_DE_WORK.WS_CONTROLE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -1871- MOVE SVA-NRCERTIF TO WS-CERTIF WHOST-NRCERTIF. */
            _.Move(REG_SVG0268B.SVA_NRCERTIF, AREA_DE_WORK.WS_CERTIF, WHOST_NRCERTIF);

            /*" -1872- MOVE SVA-NRTIT TO WHOST-NRTIT. */
            _.Move(REG_SVG0268B.SVA_NRTIT, WHOST_NRTIT);

            /*" -1873- MOVE SVA-NRPARCEL TO WHOST-NRPARCEL. */
            _.Move(REG_SVG0268B.SVA_NRPARCEL, WHOST_NRPARCEL);

            /*" -1874- MOVE SVA-OCORHIST TO WHOST-OCORHIST. */
            _.Move(REG_SVG0268B.SVA_OCORHIST, WHOST_OCORHIST);

            /*" -1876- MOVE SVA-NRTITCOMP TO WHOST-NRTITCOMP. */
            _.Move(REG_SVG0268B.SVA_NRTITCOMP, WHOST_NRTITCOMP);

            /*" -1878- PERFORM R2210-00-MONTA-DETALHE */

            R2210_00_MONTA_DETALHE_SECTION();

            /*" -1880- WRITE RVG0268B-RECORD FROM LC11-LINHA11 */
            _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVG0268B_RECORD);

            RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

            /*" -1882- ADD 1 TO AC-IMPRESSOS */
            AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

            /*" -1884- PERFORM R4000-00-GRAVA-OBJETO */

            R4000_00_GRAVA_OBJETO_SECTION();

            /*" -1886- PERFORM R2600-00-UPDATE-V0HISTCOBVA. */

            R2600_00_UPDATE_V0HISTCOBVA_SECTION();

            /*" -1886- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-MONTA-DETALHE-SECTION */
        private void R2210_00_MONTA_DETALHE_SECTION()
        {
            /*" -1900- MOVE SVA-CODPRODU TO LC11-PRODUTO-E. */
            _.Move(REG_SVG0268B.SVA_CODPRODU, AREA_DE_WORK.LC11_LINHA11.LC11_PRODUTO_E);

            /*" -1904- MOVE SVA-AGECOBR TO LC11-AGENCIA-E. */
            _.Move(REG_SVG0268B.SVA_AGECOBR, AREA_DE_WORK.LC11_LINHA11.LC11_AGENCIA_E);

            /*" -1908- MOVE SVA-NRAPOLICE TO LC11-APOLICE-E. */
            _.Move(REG_SVG0268B.SVA_NRAPOLICE, AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE_E);

            /*" -1912- PERFORM R2651-00-BUSCA-ESTIPULANTE. */

            R2651_00_BUSCA_ESTIPULANTE_SECTION();

            /*" -1916- PERFORM R2652-00-BUSCA-PARCELA. */

            R2652_00_BUSCA_PARCELA_SECTION();

            /*" -1917- MOVE V0PARC-DTVENCTO-ORIG TO WS-DTVENCTO-SQL. */
            _.Move(V0PARC_DTVENCTO_ORIG, AREA_DE_WORK.WS_DTVENCTO_SQL);

            /*" -1918- MOVE WS-ANO-VCT TO LC11-FATURA-SEC-E. */
            _.Move(AREA_DE_WORK.WS_DTVENCTO_SQL.WS_ANO_VCT, AREA_DE_WORK.LC11_LINHA11.LC11_FATURA_SEC_E);

            /*" -1922- MOVE WS-MES-VCT TO LC11-FATURA-MES-E. */
            _.Move(AREA_DE_WORK.WS_DTVENCTO_SQL.WS_MES_VCT, AREA_DE_WORK.LC11_LINHA11.LC11_FATURA_MES_E);

            /*" -1923- MOVE V0COBP-DTINIVIG-PARC TO WS-DATA1. */
            _.Move(V0COBP_DTINIVIG_PARC, AREA_DE_WORK.WS_DATA1);

            /*" -1924- MOVE WS-DIA1 TO LC11-DTINI-DIA-E. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_DIA1, AREA_DE_WORK.LC11_LINHA11.LC11_DTINI_DIA_E);

            /*" -1925- MOVE WS-MES1 TO LC11-DTINI-MES-E. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_MES1, AREA_DE_WORK.LC11_LINHA11.LC11_DTINI_MES_E);

            /*" -1927- MOVE WS-ANO1 TO LC11-DTINI-ANO-E. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_ANO1, AREA_DE_WORK.LC11_LINHA11.LC11_DTINI_ANO_E);

            /*" -1929- MOVE WS-DATA1 TO WHOST-DATA1. */
            _.Move(AREA_DE_WORK.WS_DATA1, WHOST_DATA1);

            /*" -1931- MOVE SVA-PERIPGTO TO V0OPCP-PERIPGTO. */
            _.Move(REG_SVG0268B.SVA_PERIPGTO, V0OPCP_PERIPGTO);

            /*" -1937- PERFORM R2210_00_MONTA_DETALHE_DB_SELECT_1 */

            R2210_00_MONTA_DETALHE_DB_SELECT_1();

            /*" -1940- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1941- DISPLAY 'R2210 - ERRO TERMINO DE VIGENCIA ' SQLCODE */
                _.Display($"R2210 - ERRO TERMINO DE VIGENCIA {DB.SQLCODE}");

                /*" -1943- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1944- MOVE WHOST-DATA2 TO WS-DATA2. */
            _.Move(WHOST_DATA2, AREA_DE_WORK.WS_DATA2);

            /*" -1945- MOVE WS-DIA2 TO LC11-DTTER-DIA-E. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_DIA2, AREA_DE_WORK.LC11_LINHA11.LC11_DTTER_DIA_E);

            /*" -1946- MOVE WS-MES2 TO LC11-DTTER-MES-E. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_MES2, AREA_DE_WORK.LC11_LINHA11.LC11_DTTER_MES_E);

            /*" -1950- MOVE WS-ANO2 TO LC11-DTTER-ANO-E. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_ANO2, AREA_DE_WORK.LC11_LINHA11.LC11_DTTER_ANO_E);

            /*" -1951- MOVE V1SIST-DTMOVABE TO WS-DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WS_DATA_SQL);

            /*" -1952- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -1953- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -1954- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -1958- MOVE WS-DATA TO LC11-DTEMISSAO-E. */
            _.Move(AREA_DE_WORK.WS_DATA, AREA_DE_WORK.LC11_LINHA11.LC11_DTEMISSAO_E);

            /*" -1959- MOVE SVA-DTVENCTO TO WS-DATA-SQL. */
            _.Move(REG_SVG0268B.SVA_DTVENCTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -1960- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -1961- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -1962- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -1966- MOVE WS-DATA TO LC11-DTVENCTO-E. */
            _.Move(AREA_DE_WORK.WS_DATA, AREA_DE_WORK.LC11_LINHA11.LC11_DTVENCTO_E);

            /*" -1968- MOVE SVA-NOME-RAZAO TO LC11-NOME-EST-E. */
            _.Move(REG_SVG0268B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_EST_E);

            /*" -1969- MOVE SVA-NRCNPJ TO WS-CNPJ. */
            _.Move(REG_SVG0268B.SVA_NRCNPJ, AREA_DE_WORK.WS_CNPJ);

            /*" -1970- MOVE WS-NRCNPJ1 TO LC11-NRCNPJ1-EST-E */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ1, AREA_DE_WORK.LC11_LINHA11.LC11_NRCNPJ1_EST_E);

            /*" -1971- MOVE WS-NRCNPJ2 TO LC11-NRCNPJ2-EST-E */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ2, AREA_DE_WORK.LC11_LINHA11.LC11_NRCNPJ2_EST_E);

            /*" -1975- MOVE WS-DVCNPJ TO LC11-DVCNPJ3-EST-E. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_DVCNPJ, AREA_DE_WORK.LC11_LINHA11.LC11_DVCNPJ3_EST_E);

            /*" -1979- MOVE SVA-ENDERECO TO LC11-ENDER-EST-E. */
            _.Move(REG_SVG0268B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDER_EST_E);

            /*" -1980- MOVE SVA-NUM-CEP TO LC11-CEP1-EST-E. */
            _.Move(REG_SVG0268B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP1_EST_E);

            /*" -1981- MOVE SVA-CEP-COMPL TO LC11-CEP2-EST-E. */
            _.Move(REG_SVG0268B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP2_EST_E);

            /*" -1982- MOVE SVA-CIDADE TO LC11-CIDADE-EST-E. */
            _.Move(REG_SVG0268B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_EST_E);

            /*" -1986- MOVE SVA-UF TO LC11-UF-EST-E. */
            _.Move(REG_SVG0268B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF_EST_E);

            /*" -1987- MOVE SVA-CODSUBES TO LC11-CODSUBES-SUB-E */
            _.Move(REG_SVG0268B.SVA_CODSUBES, AREA_DE_WORK.LC11_LINHA11.LC11_CODSUBES_SUB_E);

            /*" -1988- MOVE V0CLIE-NOME-SE TO LC11-NOME-SUB-E. */
            _.Move(V0CLIE_NOME_SE, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_SUB_E);

            /*" -1989- MOVE V0CLIE-CNPJ-SE TO WS-CNPJ. */
            _.Move(V0CLIE_CNPJ_SE, AREA_DE_WORK.WS_CNPJ);

            /*" -1990- MOVE WS-NRCNPJ1 TO LC11-NRCNPJ1-SUB-E. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ1, AREA_DE_WORK.LC11_LINHA11.LC11_NRCNPJ1_SUB_E);

            /*" -1991- MOVE WS-NRCNPJ2 TO LC11-NRCNPJ2-SUB-E. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ2, AREA_DE_WORK.LC11_LINHA11.LC11_NRCNPJ2_SUB_E);

            /*" -1995- MOVE WS-DVCNPJ TO LC11-DVCNPJ-SUB-E. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_DVCNPJ, AREA_DE_WORK.LC11_LINHA11.LC11_DVCNPJ_SUB_E);

            /*" -1999- MOVE V0ENDE-ENDER-SE TO LC11-ENDER-SUB-E. */
            _.Move(V0ENDE_ENDER_SE, AREA_DE_WORK.LC11_LINHA11.LC11_ENDER_SUB_E);

            /*" -2000- MOVE V0ENDE-CEP-SE TO WS-NUM-CEP-AUX. */
            _.Move(V0ENDE_CEP_SE, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2001- MOVE WS-CEP-AUX TO LC11-CEP1-SUB-E. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LC11_LINHA11.LC11_CEP1_SUB_E);

            /*" -2002- MOVE WS-CEP-COMPL-AUX TO LC11-CEP2-SUB-E. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LC11_LINHA11.LC11_CEP2_SUB_E);

            /*" -2003- MOVE V0ENDE-CIDADE-SE TO LC11-CIDADE-SUB-E. */
            _.Move(V0ENDE_CIDADE_SE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_SUB_E);

            /*" -2007- MOVE V0ENDE-UF-SE TO LC11-UF-SUB-E. */
            _.Move(V0ENDE_UF_SE, AREA_DE_WORK.LC11_LINHA11.LC11_UF_SUB_E);

            /*" -2008- MOVE V0COBP-QUANT-VIDAS TO LC11-NVIDAS-E. */
            _.Move(V0COBP_QUANT_VIDAS, AREA_DE_WORK.LC11_LINHA11.LC11_NVIDAS_E);

            /*" -2010- MOVE V0COBP-IMPSEGUR TO LC11-CAPITAL-E. */
            _.Move(V0COBP_IMPSEGUR, AREA_DE_WORK.LC11_LINHA11.LC11_CAPITAL_E);

            /*" -2012- MOVE '222A' TO WNR-EXEC-SQL. */
            _.Move("222A", WABEND.WNR_EXEC_SQL);

            /*" -2018- PERFORM R2210_00_MONTA_DETALHE_DB_SELECT_2 */

            R2210_00_MONTA_DETALHE_DB_SELECT_2();

            /*" -2021- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2023- DISPLAY 'R2210 - NAO ENCONTRADO NA V0SUBGRUPO - IOF ' WHOST-NRAPOLICE ' ' WHOST-CODSUBES */

                $"R2210 - NAO ENCONTRADO NA V0SUBGRUPO - IOF {WHOST_NRAPOLICE} {WHOST_CODSUBES}"
                .Display();

                /*" -2025- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2026- IF V0SUBG-IND-IOF EQUAL 'S' */

            if (V0SUBG_IND_IOF == "S")
            {

                /*" -2028- COMPUTE LC11-IOF-E = SVA-VLPRMTOT - (SVA-VLPRMTOT / SQL-PCIOF) */
                AREA_DE_WORK.LC11_LINHA11.LC11_IOF_E.Value = (REG_SVG0268B.SVA_VLPRMTOT - (REG_SVG0268B.SVA_VLPRMTOT / SQL_PCIOF)).ToString();

                /*" -2029- ELSE */
            }
            else
            {


                /*" -2031- MOVE ZEROES TO LC11-IOF-E. */
                _.Move(0, AREA_DE_WORK.LC11_LINHA11.LC11_IOF_E);
            }


            /*" -2035- MOVE SVA-VLPRMTOT TO LC11-VLPRMTOT-E. */
            _.Move(REG_SVG0268B.SVA_VLPRMTOT, AREA_DE_WORK.LC11_LINHA11.LC11_VLPRMTOT_E);

            /*" -2039- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -2044- PERFORM R2650-00-BUSCA-FONTE. */

            R2650_00_BUSCA_FONTE_SECTION();

            /*" -2046- MOVE 'XX/XX/XXXX' TO LE01-DTPOSTAGEM-E. */
            _.Move("XX/XX/XXXX", AREA_DE_WORK.LC11_LINHA11.LE01_DTPOSTAGEM_E);

            /*" -2052- ADD 1 TO WS-SEQ TAB1-QTD-OBJ (SVA-CEP-G) AC-QTD-OBJ AC-CONTA1. */
            AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
            TABELA_TOTAIS.TAB_TOTAIS[REG_SVG0268B.SVA_CEP_G].TAB1_QTD_OBJ.Value = TABELA_TOTAIS.TAB_TOTAIS[REG_SVG0268B.SVA_CEP_G].TAB1_QTD_OBJ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
            AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

            /*" -2054- MOVE 'XXX.XXX' TO LE01-NUMOBJETO-E. */
            _.Move("XXX.XXX", AREA_DE_WORK.LC11_LINHA11.LE01_NUMOBJETO_E);

            /*" -2055- MOVE ALL '@' TO LE09-CODIGO-CIF-E */
            _.MoveAll("@", AREA_DE_WORK.LC11_LINHA11.LE09_CODIGO_CIF_E);

            /*" -2057- MOVE ALL '#' TO LE09-POSTNET-E */
            _.MoveAll("#", AREA_DE_WORK.LC11_LINHA11.LE09_POSTNET_E);

            /*" -2058- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -2059- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -2062- MOVE WS-SEQ TO TAB1-OBJI (SVA-CEP-G). */
                _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[REG_SVG0268B.SVA_CEP_G].TAB1_OBJI);
            }


            /*" -2063- IF WS-CONTR-200 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_200 == 00)
            {

                /*" -2064- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                /*" -2068- MOVE WS-SEQ TO WS-SEQ-INICIAL. */
                _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);
            }


            /*" -2069- MOVE SVA-NOME-RAZAO TO LE02-NOME-DEST-E */
            _.Move(REG_SVG0268B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LE02_NOME_DEST_E);

            /*" -2070- MOVE SVA-ENDERECO TO LE03-ENDER-DEST-E. */
            _.Move(REG_SVG0268B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LE03_ENDER_DEST_E);

            /*" -2071- MOVE SVA-BAIRRO TO LE04-BAIRRO-DEST-E. */
            _.Move(REG_SVG0268B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LE04_BAIRRO_DEST_E);

            /*" -2072- MOVE SVA-CIDADE TO LE04-CIDADE-DEST-E */
            _.Move(REG_SVG0268B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LE04_CIDADE_DEST_E);

            /*" -2073- MOVE SVA-UF TO LE04-UF-DEST-E. */
            _.Move(REG_SVG0268B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LE04_UF_DEST_E);

            /*" -2074- MOVE SVA-NUM-CEP TO LE05-CEP-DEST-E. */
            _.Move(REG_SVG0268B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LE05_CEP_DEST_E);

            /*" -2074- MOVE SVA-CEP-COMPL TO LE05-CEPC-DEST-E. */
            _.Move(REG_SVG0268B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LE05_CEPC_DEST_E);

        }

        [StopWatch]
        /*" R2210-00-MONTA-DETALHE-DB-SELECT-1 */
        public void R2210_00_MONTA_DETALHE_DB_SELECT_1()
        {
            /*" -1937- EXEC SQL SELECT DATE(:WHOST-DATA1) + :V0OPCP-PERIPGTO MONTHS - 1 DAY INTO :WHOST-DATA2 FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r2210_00_MONTA_DETALHE_DB_SELECT_1_Query1 = new R2210_00_MONTA_DETALHE_DB_SELECT_1_Query1()
            {
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                WHOST_DATA1 = WHOST_DATA1.ToString(),
            };

            var executed_1 = R2210_00_MONTA_DETALHE_DB_SELECT_1_Query1.Execute(r2210_00_MONTA_DETALHE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA2, WHOST_DATA2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-MONTA-DETALHE-DB-SELECT-2 */
        public void R2210_00_MONTA_DETALHE_DB_SELECT_2()
        {
            /*" -2018- EXEC SQL SELECT VALUE(IND_IOF, 'S' ) INTO :V0SUBG-IND-IOF FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES END-EXEC. */

            var r2210_00_MONTA_DETALHE_DB_SELECT_2_Query1 = new R2210_00_MONTA_DETALHE_DB_SELECT_2_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2210_00_MONTA_DETALHE_DB_SELECT_2_Query1.Execute(r2210_00_MONTA_DETALHE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_IND_IOF, V0SUBG_IND_IOF);
            }


        }

        [StopWatch]
        /*" R2300-00-LE-SORT-SECTION */
        private void R2300_00_LE_SORT_SECTION()
        {
            /*" -2086- RETURN SVG0268B AT END */
            try
            {
                SVG0268B.Return(REG_SVG0268B, () =>
                {

                    /*" -2087- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -2089- GO TO R2300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2093- ADD 1 TO AC-LIDOS AC-CONTA WS-IND-LADO. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.WS_IND_LADO.Value = AREA_DE_WORK.WS_IND_LADO + 1;

            /*" -2095- MOVE SVA-COD-EMPRESA TO PRODUTO-COD-EMPRESA. */
            _.Move(REG_SVG0268B.SVA_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);

            /*" -2096- IF AC-CONTA GREATER 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -2097- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -2098- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -2098- DISPLAY '*** LIDOS SORT       ' AC-LIDOS ' ' WHORA-CURR. */

                $"*** LIDOS SORT       {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-IDENTIFICA-MSG-SECTION */
        private void R2310_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -2121- MOVE SVA-CODPRODU TO WS-COD-PRODUTO */
            _.Move(REG_SVG0268B.SVA_CODPRODU, WS_COD_PRODUTO);

            /*" -2123- INITIALIZE WS-SIT-PRODUTO */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -2128- PERFORM R2315-PRODUTO-RUNOFF */

            R2315_PRODUTO_RUNOFF_SECTION();

            /*" -2129- EVALUATE PRODUTO-COD-EMPRESA */
            switch (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.Value)
            {

                /*" -2130- WHEN 10 */
                case 10:

                    /*" -2132- WHEN 11 */
                    break;
                case 11:

                    /*" -2134- MOVE 'VD03' TO WS-JDE-GER */
                    _.Move("VD03", AREA_DE_WORK.WS_JDE_GER);

                    /*" -2135- IF WS-PROD-RUNON */

                    if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                    {

                        /*" -2136- MOVE 'VIDA27' TO WS-JDE-GER */
                        _.Move("VIDA27", AREA_DE_WORK.WS_JDE_GER);

                        /*" -2137- END-IF */
                    }


                    /*" -2138- WHEN OTHER */
                    break;
                default:

                    /*" -2139- MOVE 'VD03' TO WS-JDE-GER */
                    _.Move("VD03", AREA_DE_WORK.WS_JDE_GER);

                    /*" -2141- END-EVALUATE. */
                    break;
            }


            /*" -2142- MOVE SPACES TO LC09-LIN09 */
            _.Move("", AREA_DE_WORK.FILLER_7.LC09_LIN09);

            /*" -2145- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO WS-FORM-LINHA */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), WS_FORM_LINHA);

            /*" -2149- STRING '(' WS-FORM-LINHA DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LC09-LIN09. */
            #region STRING
            var spl1 = "(" + WS_FORM_LINHA.GetMoveValues().Split(" ").FirstOrDefault();
            spl1 += ".DBM".ToString().ToLower();
            spl1 += ") STARTDBM";
            spl1 += "(";
            var spl2 = WS_FORM_LINHA.GetMoveValues();
            spl2 += ".DBM".ToString().ToLower();
            spl2 += ") STARTDBM";
            var results3 = spl1 + spl2;
            _.Move(results3, AREA_DE_WORK.FILLER_7.LC09_LIN09);
            #endregion

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-PRODUTO-RUNOFF-SECTION */
        private void R2315_PRODUTO_RUNOFF_SECTION()
        {
            /*" -2175- MOVE '2315' TO WNR-EXEC-SQL. */
            _.Move("2315", WABEND.WNR_EXEC_SQL);

            /*" -2176- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -2178- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -2179- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -2180- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -2181- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -2183- END-SEARCH */

                    /*" -2183- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2335_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-TRATA-MENSAGEM-SECTION */
        private void R2320_00_TRATA_MENSAGEM_SECTION()
        {
            /*" -2195- PERFORM R2340-00-SELECT-V0PARCELVA. */

            R2340_00_SELECT_V0PARCELVA_SECTION();

            /*" -2195- PERFORM R2450-00-SELECT-V0COBERPROPVA. */

            R2450_00_SELECT_V0COBERPROPVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2340-00-SELECT-V0PARCELVA-SECTION */
        private void R2340_00_SELECT_V0PARCELVA_SECTION()
        {
            /*" -2207- MOVE '234' TO WNR-EXEC-SQL. */
            _.Move("234", WABEND.WNR_EXEC_SQL);

            /*" -2221- PERFORM R2340_00_SELECT_V0PARCELVA_DB_SELECT_1 */

            R2340_00_SELECT_V0PARCELVA_DB_SELECT_1();

            /*" -2224- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2225- DISPLAY 'R2340 - NAO ENCONTRADO NA V0PARCELVA' */
                _.Display($"R2340 - NAO ENCONTRADO NA V0PARCELVA");

                /*" -2226- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -2227- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -2229- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2232- COMPUTE WS-VLPRMTOT = V0PARC-PRMVG + V0PARC-PRMAP. */
            AREA_DE_WORK.WS_VLPRMTOT.Value = V0PARC_PRMVG + V0PARC_PRMAP;

            /*" -2235- COMPUTE WS-VLPREMIO = WS-VLPRMTOT - V0PARC-VLMULTA. */
            AREA_DE_WORK.WS_VLPREMIO.Value = AREA_DE_WORK.WS_VLPRMTOT - V0PARC_VLMULTA;

            /*" -2236- COMPUTE WS-VLMULTA = V0PARC-VLMULTA - 1,50. */
            AREA_DE_WORK.WS_VLMULTA.Value = V0PARC_VLMULTA - 1.50;

        }

        [StopWatch]
        /*" R2340-00-SELECT-V0PARCELVA-DB-SELECT-1 */
        public void R2340_00_SELECT_V0PARCELVA_DB_SELECT_1()
        {
            /*" -2221- EXEC SQL SELECT PRMVG + PRMAP - VLMULTA, DTVENCTO, PRMVG, PRMAP, VLMULTA INTO :V0PARC-VLPRMTOT, :V0PARC-DTVENCTO, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-VLMULTA FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :WHOST-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL END-EXEC. */

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
            /*" -2248- MOVE '245' TO WNR-EXEC-SQL. */
            _.Move("245", WABEND.WNR_EXEC_SQL);

            /*" -2250- MOVE SVA-DTVENCTO-ORIG TO V0PARC-DTVENCTO-ORIG. */
            _.Move(REG_SVG0268B.SVA_DTVENCTO_ORIG, V0PARC_DTVENCTO_ORIG);

            /*" -2264- PERFORM R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -2267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2268- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2269- PERFORM R2460-00-SELECT-V0COBERPROPVA */

                    R2460_00_SELECT_V0COBERPROPVA_SECTION();

                    /*" -2270- ELSE */
                }
                else
                {


                    /*" -2271- DISPLAY 'R2450 - NAO ENCONTRADO NA V0COBERPROPVA' */
                    _.Display($"R2450 - NAO ENCONTRADO NA V0COBERPROPVA");

                    /*" -2272- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                    _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                    /*" -2273- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                    _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                    /*" -2274- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2275- END-IF */
                }


                /*" -2275- END-IF. */
            }


        }

        [StopWatch]
        /*" R2450-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -2264- EXEC SQL SELECT IMPMORNATU, VLPREMIO, DTINIVIG, IMPSEGCDC INTO :V0COBE-IMPMORNATU, :V0COBE-VLPREMIO, :V0COBE-DTINIVIG, :V0COBE-IMPSEGCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :WHOST-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

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
        /*" R2460-00-SELECT-V0COBERPROPVA-SECTION */
        private void R2460_00_SELECT_V0COBERPROPVA_SECTION()
        {
            /*" -2287- MOVE '246' TO WNR-EXEC-SQL. */
            _.Move("246", WABEND.WNR_EXEC_SQL);

            /*" -2299- PERFORM R2460_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            R2460_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -2302- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2303- DISPLAY 'R2460 - NAO ENCONTRADO NA V0COBERPROPVA' */
                _.Display($"R2460 - NAO ENCONTRADO NA V0COBERPROPVA");

                /*" -2304- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -2305- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -2306- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2306- END-IF. */
            }


        }

        [StopWatch]
        /*" R2460-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void R2460_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -2299- EXEC SQL SELECT IMPMORNATU, VLPREMIO, DTINIVIG, IMPSEGCDC INTO :V0COBE-IMPMORNATU, :V0COBE-VLPREMIO, :V0COBE-DTINIVIG, :V0COBE-IMPSEGCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :WHOST-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r2460_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new R2460_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2460_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(r2460_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBE_IMPMORNATU, V0COBE_IMPMORNATU);
                _.Move(executed_1.V0COBE_VLPREMIO, V0COBE_VLPREMIO);
                _.Move(executed_1.V0COBE_DTINIVIG, V0COBE_DTINIVIG);
                _.Move(executed_1.V0COBE_IMPSEGCDG, V0COBE_IMPSEGCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2460_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-UPDATE-V0HISTCOBVA-SECTION */
        private void R2600_00_UPDATE_V0HISTCOBVA_SECTION()
        {
            /*" -2318- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -2324- PERFORM R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1 */

            R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1();

            /*" -2327- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2328- DISPLAY 'R2600 - NAO ENCONTRADO NA V0HISTCOBVA' */
                _.Display($"R2600 - NAO ENCONTRADO NA V0HISTCOBVA");

                /*" -2329- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -2330- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -2331- DISPLAY 'TITULO      => ' WHOST-NRTIT */
                _.Display($"TITULO      => {WHOST_NRTIT}");

                /*" -2331- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2600-00-UPDATE-V0HISTCOBVA-DB-UPDATE-1 */
        public void R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1()
        {
            /*" -2324- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '0' WHERE NRCERTIF = :WHOST-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL AND NRTIT = :WHOST-NRTIT END-EXEC. */

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
            /*" -2343- MOVE '2650' TO WNR-EXEC-SQL */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -2345- MOVE ZEROS TO IDX-IND1. */
            _.Move(0, AREA_DE_WORK.IDX_IND1);

            /*" -2346- MOVE SPACES TO LE06-FILIAL-REM-E. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_FILIAL_REM_E);

            /*" -2347- MOVE SPACES TO LE06-REMETENTE-E. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE_E);

            /*" -2348- MOVE SPACES TO LE07-ENDER-REM-E. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LE07_ENDER_REM_E);

            /*" -2349- MOVE SPACES TO LE08-BAIRRO-REM-E. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LE08_BAIRRO_REM_E);

            /*" -2350- MOVE SPACES TO LE08-CIDADE-REM-E. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LE08_CIDADE_REM_E);

            /*" -2351- MOVE SPACES TO LE08-UF-REM-E. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LE08_UF_REM_E);

            /*" -2352- MOVE ZEROS TO LE09-CEP-REM-E. */
            _.Move(0, AREA_DE_WORK.LC11_LINHA11.LE09_CEP_REM_E);

            /*" -2352- MOVE ZEROS TO LE09-CEPC-REM-E. */
            _.Move(0, AREA_DE_WORK.LC11_LINHA11.LE09_CEPC_REM_E);

            /*" -0- FLUXCONTROL_PERFORM R2650_LOOP */

            R2650_LOOP();

        }

        [StopWatch]
        /*" R2650-LOOP */
        private void R2650_LOOP(bool isPerform = false)
        {
            /*" -2359- ADD 1 TO IDX-IND1. */
            AREA_DE_WORK.IDX_IND1.Value = AREA_DE_WORK.IDX_IND1 + 1;

            /*" -2360- IF IDX-IND1 > 19 */

            if (AREA_DE_WORK.IDX_IND1 > 19)
            {

                /*" -2362- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2363- IF SVA-FONTE = TAB-FONTE (IDX-IND1) */

            if (REG_SVG0268B.SVA_FONTE == TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_FONTE)
            {

                /*" -2364- IF SVA-FONTE = 10 */

                if (REG_SVG0268B.SVA_FONTE == 10)
                {

                    /*" -2366- MOVE SPACES TO LE06-REMETENTE-E */
                    _.Move("", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE_E);

                    /*" -2368- MOVE 'MATRIZ ' TO LE06-FILIAL-REM-E */
                    _.Move("MATRIZ ", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_FILIAL_REM_E);

                    /*" -2369- ELSE */
                }
                else
                {


                    /*" -2371- MOVE TAB-NOMEFTE (IDX-IND1) TO LE06-REMETENTE-E */
                    _.Move(TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE, AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE_E);

                    /*" -2373- MOVE 'FILIAL ' TO LE06-FILIAL-REM-E */
                    _.Move("FILIAL ", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_FILIAL_REM_E);

                    /*" -2374- END-IF */
                }


                /*" -2376- MOVE TAB-ENDERFTE(IDX-IND1) TO LE07-ENDER-REM-E */
                _.Move(TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE, AREA_DE_WORK.LC11_LINHA11.LE07_ENDER_REM_E);

                /*" -2378- MOVE TAB-BAIRRO (IDX-IND1) TO LE08-BAIRRO-REM-E */
                _.Move(TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LE08_BAIRRO_REM_E);

                /*" -2380- MOVE TAB-CIDADE (IDX-IND1) TO LE08-CIDADE-REM-E */
                _.Move(TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_CIDADE, AREA_DE_WORK.LC11_LINHA11.LE08_CIDADE_REM_E);

                /*" -2382- MOVE TAB-UF (IDX-IND1) TO LE08-UF-REM-E */
                _.Move(TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_UF, AREA_DE_WORK.LC11_LINHA11.LE08_UF_REM_E);

                /*" -2384- MOVE TAB-CEP (IDX-IND1) TO DEST-NUM-CEP */
                _.Move(TAB_FILIAL.FILLER_125[AREA_DE_WORK.IDX_IND1].TAB_CEP, AREA_DE_WORK.DEST_NUM_CEP);

                /*" -2385- MOVE DEST-CEP TO LE09-CEP-REM-E */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, AREA_DE_WORK.LC11_LINHA11.LE09_CEP_REM_E);

                /*" -2386- MOVE DEST-CEP-COMPL TO LE09-CEPC-REM-E */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LE09_CEPC_REM_E);

                /*" -2388- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2388- GO TO R2650-LOOP. */
            new Task(() => R2650_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-SECTION */
        private void R2651_00_BUSCA_ESTIPULANTE_SECTION()
        {
            /*" -2399- MOVE '2651' TO WNR-EXEC-SQL */
            _.Move("2651", WABEND.WNR_EXEC_SQL);

            /*" -2410- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1();

            /*" -2413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2414- DISPLAY 'R2651 - NAO ENCONTRADO NA V0SUBGRUPO ' */
                _.Display($"R2651 - NAO ENCONTRADO NA V0SUBGRUPO ");

                /*" -2415- DISPLAY 'APOLICE     => ' WHOST-NRAPOLICE */
                _.Display($"APOLICE     => {WHOST_NRAPOLICE}");

                /*" -2418- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2420- MOVE '265A' TO WNR-EXEC-SQL. */
            _.Move("265A", WABEND.WNR_EXEC_SQL);

            /*" -2427- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2();

            /*" -2430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2431- DISPLAY 'R2651 - PROBLEMAS NO ACESSO A V0CLIENTE  ' */
                _.Display($"R2651 - PROBLEMAS NO ACESSO A V0CLIENTE  ");

                /*" -2432- DISPLAY 'CLIENTE           => ' V0SUBG-COD-CLIENTE */
                _.Display($"CLIENTE           => {V0SUBG_COD_CLIENTE}");

                /*" -2434- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2436- MOVE '265B' TO WNR-EXEC-SQL. */
            _.Move("265B", WABEND.WNR_EXEC_SQL);

            /*" -2450- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3();

            /*" -2453- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2454- DISPLAY 'R2651 - PROBLEMAS NO ACESSO A V0ENDERECOS' */
                _.Display($"R2651 - PROBLEMAS NO ACESSO A V0ENDERECOS");

                /*" -2455- DISPLAY 'CLIENTE           => ' V0SUBG-COD-CLIENTE */
                _.Display($"CLIENTE           => {V0SUBG_COD_CLIENTE}");

                /*" -2455- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-DB-SELECT-1 */
        public void R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -2410- EXEC SQL SELECT COD_CLIENTE, OCORR_ENDERECO INTO :V0SUBG-COD-CLIENTE, :V0SUBG-OCOREND FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = 0 END-EXEC. */

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
            /*" -2427- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-SE, :V0CLIE-CNPJ-SE FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0SUBG-COD-CLIENTE END-EXEC. */

            var r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1 = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1()
            {
                V0SUBG_COD_CLIENTE = V0SUBG_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1.Execute(r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_SE, V0CLIE_NOME_SE);
                _.Move(executed_1.V0CLIE_CNPJ_SE, V0CLIE_CNPJ_SE);
            }


        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-SECTION */
        private void R2652_00_BUSCA_PARCELA_SECTION()
        {
            /*" -2466- MOVE '2652' TO WNR-EXEC-SQL */
            _.Move("2652", WABEND.WNR_EXEC_SQL);

            /*" -2467- MOVE SVA-NRCERTIF TO V0PARC-NRCERTIF. */
            _.Move(REG_SVG0268B.SVA_NRCERTIF, V0PARC_NRCERTIF);

            /*" -2469- MOVE SVA-NRPARCEL TO V0PARC-NRPARCEL. */
            _.Move(REG_SVG0268B.SVA_NRPARCEL, V0PARC_NRPARCEL);

            /*" -2478- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_1 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_1();

            /*" -2481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2482- DISPLAY 'R2652 - NAO ENCONTRADO NA V0PARCELVA ' */
                _.Display($"R2652 - NAO ENCONTRADO NA V0PARCELVA ");

                /*" -2483- DISPLAY 'CERTIFICADO => ' V0PARC-NRCERTIF */
                _.Display($"CERTIFICADO => {V0PARC_NRCERTIF}");

                /*" -2484- DISPLAY 'PARCELA     => ' V0PARC-NRPARCEL */
                _.Display($"PARCELA     => {V0PARC_NRPARCEL}");

                /*" -2487- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2489- MOVE '265F' TO WNR-EXEC-SQL. */
            _.Move("265F", WABEND.WNR_EXEC_SQL);

            /*" -2503- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_2 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_2();

            /*" -2506- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2507- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2508- MOVE '265G' TO WNR-EXEC-SQL */
                    _.Move("265G", WABEND.WNR_EXEC_SQL);

                    /*" -2520- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_3 */

                    R2652_00_BUSCA_PARCELA_DB_SELECT_3();

                    /*" -2522- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2523- DISPLAY 'R2652 - PROBLEMAS NA V0COBERPROPVA ' */
                        _.Display($"R2652 - PROBLEMAS NA V0COBERPROPVA ");

                        /*" -2524- DISPLAY 'CERTIFICADO       => ' V0PARC-NRCERTIF */
                        _.Display($"CERTIFICADO       => {V0PARC_NRCERTIF}");

                        /*" -2525- DISPLAY 'PARCELA           => ' V0PARC-NRPARCEL */
                        _.Display($"PARCELA           => {V0PARC_NRPARCEL}");

                        /*" -2526- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2527- END-IF */
                    }


                    /*" -2528- ELSE */
                }
                else
                {


                    /*" -2529- DISPLAY 'R2652 - PROBLEMAS NO ACESSO A V0COBERPROPVA ' */
                    _.Display($"R2652 - PROBLEMAS NO ACESSO A V0COBERPROPVA ");

                    /*" -2530- DISPLAY 'CERTIFICADO       => ' V0PARC-NRCERTIF */
                    _.Display($"CERTIFICADO       => {V0PARC_NRCERTIF}");

                    /*" -2531- DISPLAY 'PARCELA           => ' V0PARC-NRPARCEL */
                    _.Display($"PARCELA           => {V0PARC_NRPARCEL}");

                    /*" -2532- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2533- END-IF */
                }


                /*" -2535- END-IF. */
            }


            /*" -2537- MOVE '265K' TO WNR-EXEC-SQL. */
            _.Move("265K", WABEND.WNR_EXEC_SQL);

            /*" -2538- IF V0PARC-NRPARCEL GREATER V0COBP-OCORHIST */

            if (V0PARC_NRPARCEL > V0COBP_OCORHIST)
            {

                /*" -2539- COMPUTE V0COBP-OCORHIST = V0PARC-NRPARCEL - V0COBP-OCORHIST */
                V0COBP_OCORHIST.Value = V0PARC_NRPARCEL - V0COBP_OCORHIST;

                /*" -2548- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_4 */

                R2652_00_BUSCA_PARCELA_DB_SELECT_4();

                /*" -2551- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2552- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2553- END-IF */
                }


                /*" -2555- END-IF. */
            }


            /*" -2557- MOVE '265H' TO WNR-EXEC-SQL. */
            _.Move("265H", WABEND.WNR_EXEC_SQL);

            /*" -2564- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_5 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_5();

            /*" -2567- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2568- DISPLAY 'R2652 - PROBLEMAS NO ACESSO A V1RAMOIND     ' */
                _.Display($"R2652 - PROBLEMAS NO ACESSO A V1RAMOIND     ");

                /*" -2569- DISPLAY 'RAMO              =>   93' */
                _.Display($"RAMO              =>   93");

                /*" -2570- DISPLAY 'DTVENCTO          => ' V0PARC-DTVENCTO-ORIG */
                _.Display($"DTVENCTO          => {V0PARC_DTVENCTO_ORIG}");

                /*" -2572- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2572- COMPUTE SQL-PCIOF = 1 + (SQL-PCIOF / 100). */
            SQL_PCIOF.Value = 1 + (SQL_PCIOF / 100f);

        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-1 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_1()
        {
            /*" -2478- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO-ORIG FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PARC-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

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
            /*" -2450- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :V0ENDE-ENDER-SE, :V0ENDE-BAIRRO-SE, :V0ENDE-CIDADE-SE, :V0ENDE-UF-SE, :V0ENDE-CEP-SE FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0SUBG-COD-CLIENTE AND OCORR_ENDERECO = :V0SUBG-OCOREND END-EXEC. */

            var r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1 = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1()
            {
                V0SUBG_COD_CLIENTE = V0SUBG_COD_CLIENTE.ToString(),
                V0SUBG_OCOREND = V0SUBG_OCOREND.ToString(),
            };

            var executed_1 = R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1.Execute(r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDER_SE, V0ENDE_ENDER_SE);
                _.Move(executed_1.V0ENDE_BAIRRO_SE, V0ENDE_BAIRRO_SE);
                _.Move(executed_1.V0ENDE_CIDADE_SE, V0ENDE_CIDADE_SE);
                _.Move(executed_1.V0ENDE_UF_SE, V0ENDE_UF_SE);
                _.Move(executed_1.V0ENDE_CEP_SE, V0ENDE_CEP_SE);
            }


        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-2 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_2()
        {
            /*" -2503- EXEC SQL SELECT DTINIVIG, QUANT_VIDAS, IMPSEGUR, OCORHIST INTO :V0COBP-DTINIVIG-PARC, :V0COBP-QUANT-VIDAS, :V0COBP-IMPSEGUR, :V0COBP-OCORHIST FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PARC-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

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
            /*" -2520- EXEC SQL SELECT DTINIVIG, QUANT_VIDAS, IMPSEGUR, OCORHIST INTO :V0COBP-DTINIVIG-PARC, :V0COBP-QUANT-VIDAS, :V0COBP-IMPSEGUR, :V0COBP-OCORHIST FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PARC-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1()
            {
                V0PARC_NRCERTIF = V0PARC_NRCERTIF.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);
                _.Move(executed_1.V0COBP_QUANT_VIDAS, V0COBP_QUANT_VIDAS);
                _.Move(executed_1.V0COBP_IMPSEGUR, V0COBP_IMPSEGUR);
                _.Move(executed_1.V0COBP_OCORHIST, V0COBP_OCORHIST);
            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-V0PRODUTOSVG-SECTION */
        private void R2700_00_SELECT_V0PRODUTOSVG_SECTION()
        {
            /*" -2584- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", WABEND.WNR_EXEC_SQL);

            /*" -2596- PERFORM R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1 */

            R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1();

            /*" -2599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2600- DISPLAY 'R2700 - PROBLEMAS NO ACESSO A V0PRODUTOSVG' */
                _.Display($"R2700 - PROBLEMAS NO ACESSO A V0PRODUTOSVG");

                /*" -2602- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'CODSUBES    - ' WHOST-CODSUBES */

                $"NUM_APOLICE - {WHOST_NRAPOLICE} CODSUBES    - {WHOST_CODSUBES}"
                .Display();

                /*" -2604- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2605- IF VIND-TEMCDG LESS ZEROES */

            if (VIND_TEMCDG < 00)
            {

                /*" -2605- MOVE SPACES TO V0PROD-TEM-CDG. */
                _.Move("", V0PROD_TEM_CDG);
            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-V0PRODUTOSVG-DB-SELECT-1 */
        public void R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1()
        {
            /*" -2596- EXEC SQL SELECT NOMPRODU, CODCDT, CODPRODU, TEM_CDG INTO :V0PROD-NOMPRODU, :V0PROD-CODCDT, :V0PROD-CODPRODU, :V0PROD-TEM-CDG:VIND-TEMCDG FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND CODSUBES = :WHOST-CODSUBES END-EXEC. */

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

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-4 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_4()
        {
            /*" -2548- EXEC SQL SELECT DATE(:V0COBP-DTINIVIG-PARC) + (:V0OPCP-PERIPGTO * :V0COBP-OCORHIST) MONTHS INTO :V0COBP-DTINIVIG-PARC FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1()
            {
                V0COBP_DTINIVIG_PARC = V0COBP_DTINIVIG_PARC.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                V0COBP_OCORHIST = V0COBP_OCORHIST.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-5 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_5()
        {
            /*" -2564- EXEC SQL SELECT PCIOF INTO :SQL-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = 93 AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_5_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_5_Query1()
            {
                V0PARC_DTVENCTO_ORIG = V0PARC_DTVENCTO_ORIG.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_5_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_PCIOF, SQL_PCIOF);
            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-V0PRODUTOSVG-SECTION */
        private void R2710_00_SELECT_V0PRODUTOSVG_SECTION()
        {
            /*" -2617- MOVE '271' TO WNR-EXEC-SQL. */
            _.Move("271", WABEND.WNR_EXEC_SQL);

            /*" -2628- PERFORM R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1 */

            R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1();

            /*" -2631- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2632- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2633- MOVE SPACES TO V0PROD-ESTR-COBR */
                    _.Move("", V0PROD_ESTR_COBR);

                    /*" -2634- MOVE -1 TO V0PROD-ESTR-COBR-I */
                    _.Move(-1, V0PROD_ESTR_COBR_I);

                    /*" -2635- MOVE SPACES TO V0PROD-ORIG-PRODU */
                    _.Move("", V0PROD_ORIG_PRODU);

                    /*" -2636- MOVE -1 TO V0PROD-ORIG-PRODU-I */
                    _.Move(-1, V0PROD_ORIG_PRODU_I);

                    /*" -2637- ELSE */
                }
                else
                {


                    /*" -2638- DISPLAY 'R2710 - PROBLEMAS NO ACESSO A V0PRODUTOSVG' */
                    _.Display($"R2710 - PROBLEMAS NO ACESSO A V0PRODUTOSVG");

                    /*" -2640- DISPLAY 'NUM_APOLICE - ' V0HIST-NRAPOLICE ' ' 'CODSUBES    - ' V0HIST-CODSUBES */

                    $"NUM_APOLICE - {V0HIST_NRAPOLICE} CODSUBES    - {V0HIST_CODSUBES}"
                    .Display();

                    /*" -2640- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-V0PRODUTOSVG-DB-SELECT-1 */
        public void R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1()
        {
            /*" -2628- EXEC SQL SELECT ESTR_COBR, ORIG_PRODU INTO :V0PROD-ESTR-COBR:V0PROD-ESTR-COBR-I, :V0PROD-ORIG-PRODU:V0PROD-ORIG-PRODU-I FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V0HIST-NRAPOLICE AND CODSUBES = :V0HIST-CODSUBES END-EXEC. */

            var r2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 = new R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1()
            {
                V0HIST_NRAPOLICE = V0HIST_NRAPOLICE.ToString(),
                V0HIST_CODSUBES = V0HIST_CODSUBES.ToString(),
            };

            var executed_1 = R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1.Execute(r2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_ESTR_COBR, V0PROD_ESTR_COBR);
                _.Move(executed_1.V0PROD_ESTR_COBR_I, V0PROD_ESTR_COBR_I);
                _.Move(executed_1.V0PROD_ORIG_PRODU, V0PROD_ORIG_PRODU);
                _.Move(executed_1.V0PROD_ORIG_PRODU_I, V0PROD_ORIG_PRODU_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-SELECT-V0CEDENTE-SECTION */
        private void R2800_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -2652- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", WABEND.WNR_EXEC_SQL);

            /*" -2665- PERFORM R2800_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R2800_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -2669- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2670- DISPLAY 'R2800 - PROBLEMAS NO ACESSO A V0CEDENTE' */
                _.Display($"R2800 - PROBLEMAS NO ACESSO A V0CEDENTE");

                /*" -2673- DISPLAY 'CODCDT      ' V0PROD-CODCDT 'NUM_APOLICE ' WHOST-NRAPOLICE 'CODSUBES    ' WHOST-CODSUBES */

                $"CODCDT      {V0PROD_CODCDT}NUM_APOLICE {WHOST_NRAPOLICE}CODSUBES    {WHOST_CODSUBES}"
                .Display();

                /*" -2673- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R2800_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -2665- EXEC SQL SELECT NOMCDT, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA INTO :V0CEDE-NOMECED, :V0CEDE-AGENCIA, :V0CEDE-OPERACAO, :V0CEDE-CONTA, :V0CEDE-DIGCC FROM SEGUROS.V0CEDENTE WHERE CODCDT = :V0PROD-CODCDT END-EXEC. */

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
            /*" -2685- PERFORM R2910-00-OBTEM-NUMERACAO. */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -2687- MOVE V0RELA-NRCOPIAS TO LR02-SEQ. */
            _.Move(V0RELA_NRCOPIAS, AREA_DE_WORK.LR07_LINHA07.LR02_SEQ);

            /*" -2688- MOVE V1SIST-DTMOVABE TO WS-DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WS_DATA_SQL);

            /*" -2689- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -2690- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -2692- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -2694- MOVE TAB-MES(WS-MES-SQL) TO LR02-MES. */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL], AREA_DE_WORK.LR07_LINHA07.LR02_MES);

            /*" -2695- MOVE ZEROS TO WS-COUNT. */
            _.Move(0, AREA_DE_WORK.WS_COUNT);

            /*" -2697- MOVE WHOST-DTMOVABE TO WHOST-PROXIMA-DATA. */
            _.Move(WHOST_DTMOVABE, AREA_DE_WORK.WHOST_PROXIMA_DATA);

            /*" -2700- PERFORM R2920-00-CALC-DIAS-UTEIS UNTIL WS-COUNT EQUAL 2. */

            while (!(AREA_DE_WORK.WS_COUNT == 2))
            {

                R2920_00_CALC_DIAS_UTEIS_SECTION();
            }

            /*" -2701- MOVE CALENDAR-DATA-CALENDARIO TO WS-DATA-SQL. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -2702- MOVE WS-DIA-SQL TO WS-DIA-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -2703- MOVE WS-MES-SQL TO WS-MES-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -2704- MOVE WS-ANO-SQL TO WS-ANO-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_ANO_I);

            /*" -2706- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", AREA_DE_WORK.WS_DATA_I.FILLERB1, AREA_DE_WORK.WS_DATA_I.FILLERB2);

            /*" -2706- MOVE WS-DATA-I TO LR04-DATA. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LR09_LINHA09.LR04_DATA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-SECTION */
        private void R2910_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -2718- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -2725- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -2728- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2729- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2730- MOVE ZEROS TO V0RELA-NRCOPIAS */
                    _.Move(0, V0RELA_NRCOPIAS);

                    /*" -2731- ELSE */
                }
                else
                {


                    /*" -2732- DISPLAY 'R2910 - PROBLEMAS SELECT V0RELATORIOS' */
                    _.Display($"R2910 - PROBLEMAS SELECT V0RELATORIOS");

                    /*" -2734- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2735- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -2735- MOVE ZEROS TO V0RELA-NRCOPIAS. */
                _.Move(0, V0RELA_NRCOPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -2725- EXEC SQL SELECT MAX(NRCOPIAS) INTO :V0RELA-NRCOPIAS:VIND-NRCOPIAS FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER END-EXEC. */

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
            /*" -2741- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -2743- ADD 1 TO V0RELA-NRCOPIAS. */
            V0RELA_NRCOPIAS.Value = V0RELA_NRCOPIAS + 1;

            /*" -2786- PERFORM R2910_10_INCLUI_RELATORIO_DB_INSERT_1 */

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -2789- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -2790- DISPLAY 'R2910 - (REGISTRO DUPLICADO) ... ' */
                _.Display($"R2910 - (REGISTRO DUPLICADO) ... ");

                /*" -2792- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2793- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2794- DISPLAY 'R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -2796- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2796- ADD 1 TO AC-I-RELATORIOS. */
            AREA_DE_WORK.AC_I_RELATORIOS.Value = AREA_DE_WORK.AC_I_RELATORIOS + 1;

        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void R2910_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -2786- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'EM0600B' , :V1SIST-DTMOVABE, 'EM' , 'CARTAECT' , :V0RELA-NRCOPIAS, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-MESREFER, :V1SIST-ANOREFER, 0, 0, 0, 0, 0, 0, :WHOST-NRAPOLICE, 0, 0, 0, 0, :WHOST-CODSUBES, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2808- PERFORM R2930-00-CALCULA-DIA-UTIL. */

            R2930_00_CALCULA_DIA_UTIL_SECTION();

            /*" -2812- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO EQUAL 'N' NEXT SENTENCE */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D" || CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
            {

                /*" -2813- ELSE */
            }
            else
            {


                /*" -2813- ADD 1 TO WS-COUNT. */
                AREA_DE_WORK.WS_COUNT.Value = AREA_DE_WORK.WS_COUNT + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R2930-00-CALCULA-DIA-UTIL-SECTION */
        private void R2930_00_CALCULA_DIA_UTIL_SECTION()
        {
            /*" -2824- MOVE '293' TO WNR-EXEC-SQL. */
            _.Move("293", WABEND.WNR_EXEC_SQL);

            /*" -2838- PERFORM R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1 */

            R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1();

            /*" -2841- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2842- DISPLAY 'VG0268B - PROBLEMAS NO ACESSO A TABELA CALENDARIO' */
                _.Display($"VG0268B - PROBLEMAS NO ACESSO A TABELA CALENDARIO");

                /*" -2842- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2930-00-CALCULA-DIA-UTIL-DB-SELECT-1 */
        public void R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1()
        {
            /*" -2838- EXEC SQL SELECT DATA_CALENDARIO, (DATA_CALENDARIO + 1 DAY), DIA_SEMANA, FERIADO INTO :CALENDAR-DATA-CALENDARIO, :WHOST-PROXIMA-DATA, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-PROXIMA-DATA END-EXEC. */

            var r2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 = new R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1()
            {
                WHOST_PROXIMA_DATA = AREA_DE_WORK.WHOST_PROXIMA_DATA.ToString(),
            };

            var executed_1 = R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1.Execute(r2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.WHOST_PROXIMA_DATA, AREA_DE_WORK.WHOST_PROXIMA_DATA);
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2930_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRIME-LST-SECTION */
        private void R3000_00_IMPRIME_LST_SECTION()
        {
            /*" -2853- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -2853- WRITE FVG0268B-RECORD FROM LR02-LINHA02. */
            _.Move(AREA_DE_WORK.LR02_LINHA02.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP_OCORR */

            R3000_10_LOOP_OCORR();

        }

        [StopWatch]
        /*" R3000-10-LOOP-OCORR */
        private void R3000_10_LOOP_OCORR(bool isPerform = false)
        {
            /*" -2858- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2859- MOVE 1 TO WIND */
                _.Move(1, AREA_DE_WORK.WIND);

                /*" -2861- GO TO R3000-20-INT. */

                R3000_20_INT(); //GOTO
                return;
            }


            /*" -2862- IF TAB1-QTD-OBJ (WIND) NOT EQUAL ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ != 00)
            {

                /*" -2864- ADD 1 TO WS-OCORR. */
                AREA_DE_WORK.WS_OCORR.Value = AREA_DE_WORK.WS_OCORR + 1;
            }


            /*" -2865- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -2865- GO TO R3000-10-LOOP-OCORR. */
            new Task(() => R3000_10_LOOP_OCORR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3000-20-INT */
        private void R3000_20_INT(bool isPerform = false)
        {
            /*" -2870- COMPUTE WWORK-QTDE = (WS-OCORR / 18) */
            AREA_DE_WORK.WWORK_QTDE.Value = (AREA_DE_WORK.WS_OCORR / 18f);

            /*" -2871- IF WWORK-QTDE12 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE12 != 00)
            {

                /*" -2873- COMPUTE WWORK-QTDE11 = WWORK-QTDE11 + 1. */
                AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11.Value = AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11 + 1;
            }


            /*" -2873- MOVE WWORK-QTDE11 TO LR02-PAG-FINAL. */
            _.Move(AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11, AREA_DE_WORK.LR10_LINHA10.LR02_PAG_FINAL);

        }

        [StopWatch]
        /*" R3000-30-LOOP-CABEC */
        private void R3000_30_LOOP_CABEC(bool isPerform = false)
        {
            /*" -2898- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2899- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -2901- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2902- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -2903- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -2905- GO TO R3000-30-LOOP-CABEC. */
                new Task(() => R3000_30_LOOP_CABEC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2907- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -2909- MOVE AC-PAGINA TO LR02-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LR10_LINHA10.LR02_PAGINA);

            /*" -2910- IF AC-PAGINA GREATER 1 */

            if (AREA_DE_WORK.AC_PAGINA > 1)
            {

                /*" -2912- WRITE FVG0268B-RECORD FROM LR13-LINHA13. */
                _.Move(AREA_DE_WORK.LR13_LINHA13.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());
            }


            /*" -2914- PERFORM R3010-00-CABECALHOS. */

            R3010_00_CABECALHOS_SECTION();

            /*" -2915- WRITE FVG0268B-RECORD FROM LR10-LINHA10. */
            _.Move(AREA_DE_WORK.LR10_LINHA10.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2917- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AREA_DE_WORK.AC_LINHAS);

            /*" -2918- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2919- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPI);

            /*" -2920- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPI);

            /*" -2921- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2922- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPF);

            /*" -2923- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPF);

            /*" -2924- MOVE TAB1-OBJI (WIND) TO LR05-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR12_LINHA12.LR05_OBJI);

            /*" -2925- MOVE TAB1-OBJF (WIND) TO LR05-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR12_LINHA12.LR05_OBJF);

            /*" -2926- MOVE TAB1-AMARI (WIND) TO LR05-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR12_LINHA12.LR05_AMARI);

            /*" -2927- MOVE TAB1-AMARF (WIND) TO LR05-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR12_LINHA12.LR05_AMARF);

            /*" -2928- MOVE TAB1-QTD-OBJ (WIND) TO LR05-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_OBJ);

            /*" -2929- MOVE TAB1-QTD-AMAR(WIND) TO LR05-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_AMAR);

            /*" -2931- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR12_LINHA12.LR05_OBS);

            /*" -2931- WRITE FVG0268B-RECORD FROM LR12-LINHA12. */
            _.Move(AREA_DE_WORK.LR12_LINHA12.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R3000-40-LOOP-DET */
        private void R3000_40_LOOP_DET(bool isPerform = false)
        {
            /*" -2937- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -2938- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2939- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -2941- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2942- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -2944- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2945- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2946- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPI);

            /*" -2947- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPI);

            /*" -2948- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2949- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPF);

            /*" -2950- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPF);

            /*" -2951- MOVE TAB1-OBJI (WIND) TO LR05-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR12_LINHA12.LR05_OBJI);

            /*" -2952- MOVE TAB1-OBJF (WIND) TO LR05-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR12_LINHA12.LR05_OBJF);

            /*" -2953- MOVE TAB1-AMARI (WIND) TO LR05-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR12_LINHA12.LR05_AMARI);

            /*" -2954- MOVE TAB1-AMARF (WIND) TO LR05-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR12_LINHA12.LR05_AMARF);

            /*" -2955- MOVE TAB1-QTD-OBJ (WIND) TO LR05-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_OBJ);

            /*" -2956- MOVE TAB1-QTD-AMAR(WIND) TO LR05-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_AMAR);

            /*" -2958- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR12_LINHA12.LR05_OBS);

            /*" -2959- WRITE FVG0268B-RECORD FROM LR12-LINHA12. */
            _.Move(AREA_DE_WORK.LR12_LINHA12.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2961- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -2962- IF AC-LINHAS > 17 */

            if (AREA_DE_WORK.AC_LINHAS > 17)
            {

                /*" -2963- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -2964- GO TO R3000-30-LOOP-CABEC */

                R3000_30_LOOP_CABEC(); //GOTO
                return;

                /*" -2965- ELSE */
            }
            else
            {


                /*" -2965- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-CABECALHOS-SECTION */
        private void R3010_00_CABECALHOS_SECTION()
        {
            /*" -2975- WRITE FVG0268B-RECORD FROM LR03-LINHA03 */
            _.Move(AREA_DE_WORK.LR03_LINHA03.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2976- WRITE FVG0268B-RECORD FROM LR04-LINHA04 */
            _.Move(AREA_DE_WORK.LR04_LINHA04.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2977- WRITE FVG0268B-RECORD FROM LR05-LINHA05 */
            _.Move(AREA_DE_WORK.LR05_LINHA05.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2978- WRITE FVG0268B-RECORD FROM LR06-LINHA06 */
            _.Move(AREA_DE_WORK.LR06_LINHA06.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2979- WRITE FVG0268B-RECORD FROM LR07-LINHA07 */
            _.Move(AREA_DE_WORK.LR07_LINHA07.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2980- WRITE FVG0268B-RECORD FROM LR08-LINHA08 */
            _.Move(AREA_DE_WORK.LR08_LINHA08.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2981- WRITE FVG0268B-RECORD FROM LR09-LINHA09 */
            _.Move(AREA_DE_WORK.LR09_LINHA09.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

            /*" -2981- WRITE FVG0268B-RECORD FROM LR10-LINHA10-A. */
            _.Move(AREA_DE_WORK.LR10_LINHA10_A.GetMoveValues(), FVG0268B_RECORD);

            FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SEPARA-PRODUTO-SECTION */
        private void R3100_00_SEPARA_PRODUTO_SECTION()
        {
            /*" -2999- MOVE 999999 TO LF03-FAIXA1 LF03-FAIXA2 LF03-FAIXA1C LF03-FAIXA2C LF05-AMARRADO LF04-QTD-OBJ LF05-SEQ-INICIAL LF05-SEQ-FINAL. */
            _.Move(999999, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1C, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2C, AREA_DE_WORK.LF04_LINHA04.LF05_AMARRADO, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_INICIAL, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_FINAL);

            /*" -3001- MOVE LR03-TP-PGTO TO LF02-NOME-FAIXA. */
            _.Move(AREA_DE_WORK.LR11_LINHA11.LR03_TP_PGTO, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

            /*" -3001- PERFORM R3200-00-FAC-PRODUTO 3 TIMES. */

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
            /*" -3014- IF WS-CONTR-PRODU EQUAL 'C' */

            if (AREA_DE_WORK.WS_CONTR_PRODU == "C")
            {

                /*" -3015- WRITE RVG0268B-RECORD FROM LF01-LINHA01 */
                _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3016- WRITE RVG0268B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3017- WRITE RVG0268B-RECORD FROM LF02-LINHA02 */
                _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3018- WRITE RVG0268B-RECORD FROM LF03-LINHA03 */
                _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3019- WRITE RVG0268B-RECORD FROM LF04-LINHA04 */
                _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3020- WRITE RVG0268B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3021- WRITE RVG0268B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG0268B_RECORD);

                RVG0268B.Write(RVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3022- ELSE */
            }
            else
            {


                /*" -3023- WRITE FVG0268B-RECORD FROM LF01-LINHA01 */
                _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3024- WRITE FVG0268B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3025- WRITE FVG0268B-RECORD FROM LF02-LINHA02 */
                _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3026- WRITE FVG0268B-RECORD FROM LF03-LINHA03 */
                _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3027- WRITE FVG0268B-RECORD FROM LF04-LINHA04 */
                _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3028- WRITE FVG0268B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());

                /*" -3028- WRITE FVG0268B-RECORD FROM LC01-LINHA01. */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVG0268B_RECORD);

                FVG0268B.Write(FVG0268B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-GRAVA-OBJETO-SECTION */
        private void R4000_00_GRAVA_OBJETO_SECTION()
        {
            /*" -3041- MOVE WS-JDE-GER TO GEOBJECT-COD-FORMULARIO. */
            _.Move(AREA_DE_WORK.WS_JDE_GER, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

            /*" -3051- PERFORM R4000_00_GRAVA_OBJETO_DB_SELECT_1 */

            R4000_00_GRAVA_OBJETO_DB_SELECT_1();

            /*" -3054- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3055- PERFORM R4000-03-VALUES-DETALHE */

                R4000_03_VALUES_DETALHE_SECTION();

                /*" -3056- PERFORM R4000-02-INSERT-OBJETO */

                R4000_02_INSERT_OBJETO_SECTION();

                /*" -3058- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3059- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -3060- DISPLAY 'ERRO DE ACESSO A TABELA GE_OBJETO_ECT.' */
                _.Display($"ERRO DE ACESSO A TABELA GE_OBJETO_ECT.");

                /*" -3061- DISPLAY 'SQLCODE............... ' SQLCODE */
                _.Display($"SQLCODE............... {DB.SQLCODE}");

                /*" -3062- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3063- ELSE */
            }
            else
            {


                /*" -3064- PERFORM R4000-01-VALUES-HEADER */

                R4000_01_VALUES_HEADER_SECTION();

                /*" -3065- PERFORM R4000-02-INSERT-OBJETO */

                R4000_02_INSERT_OBJETO_SECTION();

                /*" -3066- PERFORM R4000-03-VALUES-DETALHE */

                R4000_03_VALUES_DETALHE_SECTION();

                /*" -3066- PERFORM R4000-02-INSERT-OBJETO. */

                R4000_02_INSERT_OBJETO_SECTION();
            }


        }

        [StopWatch]
        /*" R4000-00-GRAVA-OBJETO-DB-SELECT-1 */
        public void R4000_00_GRAVA_OBJETO_DB_SELECT_1()
        {
            /*" -3051- EXEC SQL SELECT DISTINCT STA_REGISTRO INTO :GEOBJECT-STA-REGISTRO FROM SEGUROS.GE_OBJETO_ECT WHERE NUM_CEP = 0 AND NOM_PROGRAMA = 'VG0268B' AND COD_FORMULARIO = :GEOBJECT-COD-FORMULARIO AND STA_REGISTRO = 'H' AND DATE(DTH_TIMESTAMP) <> '9999-12-31' ORDER BY STA_REGISTRO END-EXEC. */

            var r4000_00_GRAVA_OBJETO_DB_SELECT_1_Query1 = new R4000_00_GRAVA_OBJETO_DB_SELECT_1_Query1()
            {
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
            };

            var executed_1 = R4000_00_GRAVA_OBJETO_DB_SELECT_1_Query1.Execute(r4000_00_GRAVA_OBJETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOBJECT_STA_REGISTRO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4000-02-INSERT-OBJETO-SECTION */
        private void R4000_02_INSERT_OBJETO_SECTION()
        {
            /*" -3088- PERFORM R4000_02_INSERT_OBJETO_DB_INSERT_1 */

            R4000_02_INSERT_OBJETO_DB_INSERT_1();

            /*" -3091- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3092- DISPLAY 'ERRO NO INSERT DA GE-OBJETO-ECT ' */
                _.Display($"ERRO NO INSERT DA GE-OBJETO-ECT ");

                /*" -3094- DISPLAY 'H = HEADER D = DETALHE.' GEOBJECT-STA-REGISTRO */
                _.Display($"H = HEADER D = DETALHE.{GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO}");

                /*" -3095- DISPLAY 'PROGRAMA VG0268B.......' */
                _.Display($"PROGRAMA VG0268B.......");

                /*" -3097- DISPLAY 'FORMULARIO............ ' GEOBJECT-COD-FORMULARIO */
                _.Display($"FORMULARIO............ {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO}");

                /*" -3098- DISPLAY 'SQLCODE............... ' SQLCODE */
                _.Display($"SQLCODE............... {DB.SQLCODE}");

                /*" -3098- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-02-INSERT-OBJETO-DB-INSERT-1 */
        public void R4000_02_INSERT_OBJETO_DB_INSERT_1()
        {
            /*" -3088- EXEC SQL INSERT INTO SEGUROS.GE_OBJETO_ECT VALUES (:GEOBJECT-NUM-CEP, 'VG0268B' , :GEOBJECT-COD-FORMULARIO, :GEOBJECT-STA-REGISTRO, CURRENT TIMESTAMP, :GEOBJECT-COD-PRODUTO:VIND-PRODUTO, :GEOBJECT-NUM-INI-POS-VERSO, :GEOBJECT-QTD-PESO-GRAMAS, :GEOBJECT-VLR-DECLARADO, :GEOBJECT-COD-IDENT-OBJETO, :GEOBJECT-DES-OBJETO) END-EXEC. */

            var r4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1 = new R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1()
            {
                GEOBJECT_NUM_CEP = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP.ToString(),
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
                GEOBJECT_STA_REGISTRO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO.ToString(),
                GEOBJECT_COD_PRODUTO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO.ToString(),
                VIND_PRODUTO = VIND_PRODUTO.ToString(),
                GEOBJECT_NUM_INI_POS_VERSO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO.ToString(),
                GEOBJECT_QTD_PESO_GRAMAS = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS.ToString(),
                GEOBJECT_VLR_DECLARADO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO.ToString(),
                GEOBJECT_COD_IDENT_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO.ToString(),
                GEOBJECT_DES_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.ToString(),
            };

            R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1.Execute(r4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_02_SAIDA*/

        [StopWatch]
        /*" R4000-01-VALUES-HEADER-SECTION */
        private void R4000_01_VALUES_HEADER_SECTION()
        {
            /*" -3106- MOVE 0 TO GEOBJECT-NUM-CEP */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -3107- MOVE 'H' TO GEOBJECT-STA-REGISTRO */
            _.Move("H", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -3108- MOVE -1 TO VIND-PRODUTO */
            _.Move(-1, VIND_PRODUTO);

            /*" -3109- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -3110- MOVE 0 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -3111- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -3112- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -3113- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -3113- MOVE LC10-LINHA10 TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(AREA_DE_WORK.LC10_LINHA10, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_01_SAIDA*/

        [StopWatch]
        /*" R4000-03-VALUES-DETALHE-SECTION */
        private void R4000_03_VALUES_DETALHE_SECTION()
        {
            /*" -3123- MOVE SVA-NUM-CEP-9 TO GEOBJECT-NUM-CEP */
            _.Move(REG_SVG0268B.SVA_NUM_CEP_9, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -3124- MOVE 'D' TO GEOBJECT-STA-REGISTRO */
            _.Move("D", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -3125- MOVE 0 TO VIND-PRODUTO */
            _.Move(0, VIND_PRODUTO);

            /*" -3127- MOVE SVA-CODPRODU TO GEOBJECT-COD-PRODUTO LE09-COD-PRODUTO */
            _.Move(REG_SVG0268B.SVA_CODPRODU, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO, AREA_DE_WORK.LC11_LINHA11.LE09_COD_PRODUTO);

            /*" -3128- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -3129- MOVE 4,6 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(4.6, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -3130- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -3131- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -3132- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -3132- MOVE LC11-LINHA11 TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(AREA_DE_WORK.LC11_LINHA11, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_03_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -3145- OPEN OUTPUT RVG0268B. */
            RVG0268B.Open(RVG0268B_RECORD);

            /*" -3145- OPEN OUTPUT FVG0268B. */
            FVG0268B.Open(FVG0268B_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -3156- CLOSE RVG0268B. */
            RVG0268B.Close();

            /*" -3156- CLOSE FVG0268B. */
            FVG0268B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -3169- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3170- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3171- DISPLAY '*   VG0268B - IMPRIME COBRANCA             *' */
            _.Display($"*   VG0268B - IMPRIME COBRANCA             *");

            /*" -3172- DISPLAY '*   -------   ----------------             *' */
            _.Display($"*   -------   ----------------             *");

            /*" -3173- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3174- DISPLAY '*             NAO EXISTE COBRANCA DO       *' */
            _.Display($"*             NAO EXISTE COBRANCA DO       *");

            /*" -3175- DISPLAY '*             MULTIPREMIADO PARA ESTA DATA *' */
            _.Display($"*             MULTIPREMIADO PARA ESTA DATA *");

            /*" -3176- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3176- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3190- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -3192- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -3192- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3194- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3198- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3198- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}