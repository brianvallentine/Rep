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
using Sias.VidaAzul.DB2.VA1466B;

namespace Code
{
    public class VA1466B
    {
        public bool IsCall { get; set; }

        public VA1466B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      *     GERA ARQUIVO ANALITICO DE PROPOSTAS EM CRITICA.            *      */
        /*"      ******************************************************************      */
        /*"V.15  *   VERSAO 15 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUIR CONSULTA DA TABELA ERROS_PROP_VIDAZUL *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/03/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.15        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.14  *   VERSAO 14 - DEMANDA 358068                                   *      */
        /*"      *         - CASO O CPF/CNPJ SEJA CLIENTE PEPS, COLOCAR A INFORMA-*      */
        /*"      *           CAO NO CAMPO SITUACAO                                *      */
        /*"      *   EM 27/05/2022 - ELIERMES OLIVEIRA   PROCURE POR V.14         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  *VERSAO V.13: 05/07/2021- 295489 - KINKAS -CORRIGIR -502         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - DEMANDA 201470                                   *      */
        /*"      *         - AJUSTES EMISSAO RELATORIO VA1466B.                   *      */
        /*"      *           NAO TRATAR PROPOSTAS DO RAMO 77.                     *      */
        /*"      *           DESABILITAR GRAVACAO ARQUIVOS DSAIDA E SSAIDA.       *      */
        /*"      *   EM 29/07/2019 - BRICE HO            PROCURE POR V.12         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - DEMANDA 169167                                   *      */
        /*"      *         - PROPOSTAS ASSINADAS FISICAMENTE E QUE POSSUEM CRITICA*      */
        /*"      *           CADASTRAL ESTAO DISPONIVEIS NO VA1466B, POREM AS PRO-*      */
        /*"      *           POSTAS ASSINADAS ELETRONICAMENTE E QUE POSSUEM CRITI-*      */
        /*"      *           CA CADASTRAL NAO ESTA NO VA1466B.                    *      */
        /*"      *         - NO MOMENTO DE REALIZAR O TESTE NA TABELA             *      */
        /*"      *           PROPOSTA_VIDAZUL COM INDICADOR IGUAL A CAD  O PROGRA-*      */
        /*"      *           NAO ESTAVA GRAVANDO O REGISTRO.                      *      */
        /*"      *   EM 30/10/2018 - MAURICIO CUNHA (MILLENIUM)  PROCURE POR V.11 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - CAD 126.138                                      *      */
        /*"      *         - RETIRADA DAS CRITICAS CADASTRAIS DO RELATORIO.       *      */
        /*"      *           SER�O TRATADAS NO VA0445B.                           *      */
        /*"      *   EM 08/12/2015 - LUIGI CONTE (INDRA COMPANY) PROCURE POR V.10 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - CAD 88.560                                       *      */
        /*"      *         - CONTADOR DE REGISTROS PROCESSADOS NO SORT NAO ESTAVA *      */
        /*"      *           SENDO ATUALIZADO NO PROCESSAMENTO.                   *      */
        /*"      *   EM 15/04/2014 - RIBAMAR MARQUES     PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 28.665                                       *      */
        /*"      *               - CRIACAO DOS RELATORIOS DE ERRO NA ROTINA.      *      */
        /*"      *   18/09/2009-FAST COMPUTER - TERCIO FREITAS - PROCURE POR V.08 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - CAD 26.166  - SQLCODE -811                       *      */
        /*"      *   26/06/2009-FAST COMPUTER - LEANDRO CORTES - PROCURE POR V.07 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     05     *  14/01/2009*FAST COMPUTER * MOSTRA MENSAGEM DE    *      */
        /*"      *            *            *              * CPF RECORRENTE QUANDO *      */
        /*"      *            *            *              * FOR ERRO.             *      */
        /*"      *            *            *              *   -  PROCURAR V.05 -  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      * 03/10/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     04     *  08/08/2008*FAST COMPUTER * MOSTRA MENSAGEM DE    *      */
        /*"      * CAD-12834  *            *              * CPF QUANDO FOR ERRO.  *      */
        /*"      *            *            *              *   -  PROCURAR V.04 -  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     03     *  04/03/2008*  MARCO PAIVA * INCLUIR COLUNA DE DES-*      */
        /*"      *            *            *              * CRICAO DA SITUACAO    *      */
        /*"      *            *            *              *   -  PROCURAR V.03 -  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     01     *  16/02/00  *   MESSIAS    *                       *      */
        /*"      *     02     *  18/08/06  *   FAST       * RETIRA REDUNDANCIA    *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _AVA1466B { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis AVA1466B
        {
            get
            {
                _.Move(REG_AVA1466B, _AVA1466B); VarBasis.RedefinePassValue(REG_AVA1466B, _AVA1466B, REG_AVA1466B); return _AVA1466B;
            }
        }
        public FileBasis _DVA1466B { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis DVA1466B
        {
            get
            {
                _.Move(REG_DVA1466B, _DVA1466B); VarBasis.RedefinePassValue(REG_DVA1466B, _DVA1466B, REG_DVA1466B); return _DVA1466B;
            }
        }
        public SortBasis<VA1466B_REG_SVA1466B> SVA1466B { get; set; } = new SortBasis<VA1466B_REG_SVA1466B>(new VA1466B_REG_SVA1466B());
        /*"01            REG-AVA1466B        PIC X(500).*/
        public StringBasis REG_AVA1466B { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"01            REG-DVA1466B        PIC X(200).*/
        public StringBasis REG_DVA1466B { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01            REG-SVA1466B.*/
        public VA1466B_REG_SVA1466B REG_SVA1466B { get; set; } = new VA1466B_REG_SVA1466B();
        public class VA1466B_REG_SVA1466B : VarBasis
        {
            /*"    05        SVA-APOLICE         PIC  9(013).*/
            public IntBasis SVA_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-CODSUBES        PIC  9(004).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-NRCERTIF        PIC  9(015).*/
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-DTQITBCO        PIC  X(010).*/
            public StringBasis SVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-CODUSU          PIC  X(008).*/
            public StringBasis SVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        SVA-NRMATRVEN       PIC  9(008).*/
            public IntBasis SVA_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        SVA-AGECOBR         PIC  9(004).*/
            public IntBasis SVA_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-CDFONTE         PIC  9(004).*/
            public IntBasis SVA_CDFONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-CDESCNEG        PIC  9(004).*/
            public IntBasis SVA_CDESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-VLPREMIO        PIC  9(13)V99.*/
            public DoubleBasis SVA_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05        SVA-IMPSEGUR        PIC  9(13)V99.*/
            public DoubleBasis SVA_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05        SVA-SITUACAO        PIC  X(01).*/
            public StringBasis SVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05        SVA-NOME-RAZAO      PIC  X(40).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05        SVA-CGCCPF          PIC  9(14).*/
            public IntBasis SVA_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05        SVA-ENDERECO        PIC  X(40).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05        SVA-BAIRRO          PIC  X(20).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05        SVA-CIDADE          PIC  X(20).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05        SVA-SIGLA-UF        PIC  X(02).*/
            public StringBasis SVA_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05        SVA-CEP             PIC  9(08).*/
            public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05        SVA-DDD             PIC  9(04).*/
            public IntBasis SVA_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05        SVA-TELEFONE        PIC  9(09).*/
            public IntBasis SVA_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05        SVA-QTDIAS          PIC  9(06).*/
            public IntBasis SVA_QTDIAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05        SVA-DTPROXVEN       PIC  X(10).*/
            public StringBasis SVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05        SVA-DESC-ERRO       PIC  X(40).*/
            public StringBasis SVA_DESC_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77            WHOST-NRCERTIF      PIC S9(15) COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            WHOST-QTDIAS        PIC S9(09) COMP.*/
        public IntBasis WHOST_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WHOST-NUMTIT        PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-APOLICE       PIC S9(13) COMP-3.*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-CODSUBES      PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-COD-ESCNEG    PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-DTINICIAL     PIC  X(10).*/
        public StringBasis WHOST_DTINICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL       PIC  X(10).*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WS-CLIENTE-PEP      PIC  X(01) VALUE 'N'.*/
        public StringBasis WS_CLIENTE_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77            WS-DESCR-ERRO       PIC  X(040).*/
        public StringBasis WS_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0FONT-CODFTE       PIC S9(04) COMP.*/
        public IntBasis V0FONT_CODFTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0FONT-NOMEFTE      PIC  X(40).*/
        public StringBasis V0FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PROD-NOMPRODU     PIC  X(40).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTHOJE       PIC  X(10).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0CONT-DATCEF       PIC  X(10).*/
        public StringBasis V0CONT_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0ESCN-CODESC       PIC S9(04) COMP.*/
        public IntBasis V0ESCN_CODESC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0ESCN-NOMEESC      PIC  X(40).*/
        public StringBasis V0ESCN_NOMEESC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0ESCN-FONTE        PIC S9(04) COMP.*/
        public IntBasis V0ESCN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-AGECOBR     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-VLPREMIO    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PROP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PROP-IMPSEGUR    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PROP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PROP-SITUACAO    PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V0PROP-APOLICE     PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0PROP-CODSUBES    PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-NRCERTIF    PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0PROP-CODUSU      PIC  X(08).*/
        public StringBasis V0PROP_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77            V0PROP-NRMATRVEN   PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0PROP-CODCLIEN    PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PROP-OCOREND     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-DTQITBCO    PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-DTPROXVEN   PIC  X(10).*/
        public StringBasis V0PROP_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-CODPRODU    PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-NOMPRODU    PIC  X(30).*/
        public StringBasis V0PROP_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77            V0CLIE-NOME-RAZAO  PIC  X(40).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0CLIE-CGCCPF      PIC S9(15)    COMP-3.*/
        public IntBasis V0CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0ENDE-ENDERECO     PIC  X(040).*/
        public StringBasis V0ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0ENDE-BAIRRO       PIC  X(020).*/
        public StringBasis V0ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-CIDADE       PIC  X(020).*/
        public StringBasis V0ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-SIGLA-UF     PIC  X(002).*/
        public StringBasis V0ENDE_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V0ENDE-CEP          PIC S9(009) COMP.*/
        public IntBasis V0ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0ENDE-DDD          PIC S9(004) COMP.*/
        public IntBasis V0ENDE_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0ENDE-TELEFONE     PIC S9(009) COMP.*/
        public IntBasis V0ENDE_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0MALHA-CDESCNEG     PIC S9(04)    COMP.*/
        public IntBasis V0MALHA_CDESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0MALHA-CDFONTE      PIC S9(04)    COMP.*/
        public IntBasis V0MALHA_CDFONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WORK-AREA.*/
        public VA1466B_WORK_AREA WORK_AREA { get; set; } = new VA1466B_WORK_AREA();
        public class VA1466B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public VA1466B_DATA_SQL DATA_SQL { get; set; } = new VA1466B_DATA_SQL();
            public class VA1466B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        IND                 PIC  9(005) VALUE ZEROS.*/
            }
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WS-ESCNEG           PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-FONTE-ANT        PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-COD-ESCNEG-ANT   PIC  9(004) VALUE 9999.*/
            public IntBasis WS_COD_ESCNEG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 9999);
            /*"    05        WS-APOLICE-ANT      PIC  9(013) VALUE ZEROS.*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05        WS-CODSUBES-ANT     PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-ESCNEG-ANT       PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_ESCNEG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WFIM-V0COMISICOB    PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V0COMISICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-ERROSPROP      PIC   X(03)  VALUE  ' '.*/
            public StringBasis WFIM_ERROSPROP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT1          PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-FONTES         PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-ESCNEG         PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_ESCNEG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-LIDOS-SORT       PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_SORT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-GRAVA-SORT       PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_SORT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-GRAVA-AVA1466B   PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_AVA1466B { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-GRAVA-DVA1466B   PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_DVA1466B { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        WABEND.*/
            public VA1466B_WABEND WABEND { get; set; } = new VA1466B_WABEND();
            public class VA1466B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA1466B'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA1466B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        LD00.*/
            }
            public VA1466B_LD00 LD00 { get; set; } = new VA1466B_LD00();
            public class VA1466B_LD00 : VarBasis
            {
                /*"      10      FILLER              PIC X(07)   VALUE 'VA1466B'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"VA1466B");
                /*"      10      FILLER              PIC X(08)   VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"      10      FILLER              PIC X(50)   VALUE            'ESTOQUE DE PROPOSTAS PENDENTES DE DOCUMENTO FISICO'*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"ESTOQUE DE PROPOSTAS PENDENTES DE DOCUMENTO FISICO");
                /*"      10      FILLER              PIC X(08)   VALUE             ' DATA : '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" DATA : ");
                /*"      10      LD00-DATAINI        PIC X(10).*/
                public StringBasis LD00_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10      FILLER              PIC X(03)   VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @";");
                /*"    05        LD00-1.*/
            }
            public VA1466B_LD00_1 LD00_1 { get; set; } = new VA1466B_LD00_1();
            public class VA1466B_LD00_1 : VarBasis
            {
                /*"      10      FILLER              PIC X(07)   VALUE 'PRODUTO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'FILIAL'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FILIAL");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(02)   VALUE 'EN'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"EN");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(11)   VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE             'QTDIAS'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"QTDIAS");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE             'CRITICAS'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"CRITICAS");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(04)   VALUE 'NOME'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"NOME");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(03)   VALUE 'CPF'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(03)   VALUE 'DDD'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DDD");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE 'TELEFONE'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"TELEFONE");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE 'ENDERECO'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"ENDERECO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'BAIRRO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"BAIRRO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'CIDADE'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CIDADE");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(02)   VALUE 'UF'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"UF");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(03)   VALUE 'CEP'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CEP");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE 'QUITACAO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"QUITACAO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(07)   VALUE 'AGENCIA'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'PREMIO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PREMIO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'IMP.SG'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"IMP.SG");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(07)   VALUE 'USUARIO'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(09)   VALUE 'MATRICULA'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"MATRICULA");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(07)   VALUE 'APOLICE'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE 'SUBGRUPO'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SUBGRUPO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE 'SITUACAO'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SITUACAO");
                /*"    05        LD01.*/
            }
            public VA1466B_LD01 LD01 { get; set; } = new VA1466B_LD01();
            public class VA1466B_LD01 : VarBasis
            {
                /*"      10      LD01-NOMPRODU       PIC X(40)   VALUE SPACES.*/
                public StringBasis LD01_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10      LD01-FIL1           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CODFILIAL      PIC 9(04)   VALUE ZEROES.*/
                public IntBasis LD01_CODFILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      10      LD01-TRA1           PIC X(01)   VALUE '-'.*/
                public StringBasis LD01_TRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      10      LD01-NOMFILIAL      PIC X(31)   VALUE SPACES.*/
                public StringBasis LD01_NOMFILIAL { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"");
                /*"      10      LD01-FIL2           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-COD-ESCNEG     PIC 9(04)   VALUE ZEROES.*/
                public IntBasis LD01_COD_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      10      LD01-TRA1A          PIC X(01)   VALUE '-'.*/
                public StringBasis LD01_TRA1A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      10      LD01-REGIAO-ESCNEG  PIC X(31)   VALUE SPACES.*/
                public StringBasis LD01_REGIAO_ESCNEG { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"");
                /*"      10      LD01-FIL2A          PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL2A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-NRCERTIF       PIC 9(15).*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD01-FIL3           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-QTDIAS         PIC 9(06).*/
                public IntBasis LD01_QTDIAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"      10      LD01-FIL3-A1        PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_A1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-DESCR-ERRO     PIC X(40).*/
                public StringBasis LD01_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      LD01-FIL3-A2        PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_A2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-NOME-RAZAO     PIC X(40).*/
                public StringBasis LD01_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      LD01-FIL3-A         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CGCCPF         PIC 9(15).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD01-FIL3-B         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_B { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-DDD            PIC 9(04).*/
                public IntBasis LD01_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      LD01-FIL3-C         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_C { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-TELEFONE       PIC 9(09).*/
                public IntBasis LD01_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"      10      LD01-FIL3-D         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_D { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-ENDERECO       PIC X(40).*/
                public StringBasis LD01_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      LD01-FIL3-E         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_E { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-BAIRRO         PIC X(20).*/
                public StringBasis LD01_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      LD01-FIL3-F         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_F { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CIDADE         PIC X(20).*/
                public StringBasis LD01_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      LD01-FIL3-G         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_G { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-SIGLA-UF       PIC X(02).*/
                public StringBasis LD01_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"      10      LD01-FIL3-H         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_H { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CEP            PIC 9(08).*/
                public IntBasis LD01_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"      10      LD01-FIL3-I         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_I { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-DTQITBCO       PIC X(10).*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10      LD01-FIL4           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-AGECOBR        PIC 9(04).*/
                public IntBasis LD01_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      LD01-FIL5           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-VLPREMIO       PIC 9999999999999,99.*/
                public DoubleBasis LD01_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
                /*"      10      LD01-FIL6           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-IMPSEGUR       PIC 9999999999999,99.*/
                public DoubleBasis LD01_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
                /*"      10      LD01-FIL7           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CODUSU         PIC X(08).*/
                public StringBasis LD01_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"      10      LD01-FIL8           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-NRMATRVEN      PIC 9(08).*/
                public IntBasis LD01_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"      10      LD01-FIL9           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-APOLICE        PIC 9(13).*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"      10      LD01-FIL10          PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-SUBGRUPO       PIC 9(05).*/
                public IntBasis LD01_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"      10      LD01-FIL11          PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-SITUACAO       PIC X(30)   VALUE SPACES.*/
                public StringBasis LD01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    05        LD02.*/
            }
            public VA1466B_LD02 LD02 { get; set; } = new VA1466B_LD02();
            public class VA1466B_LD02 : VarBasis
            {
                /*"      10      LD02-COD-DOC        PIC 9(04)   VALUE 103.*/
                public IntBasis LD02_COD_DOC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 103);
                /*"      10      LD02-FIL1           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-AGECOBR        PIC 9(04).*/
                public IntBasis LD02_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      LD02-FIL2           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-CODFILIAL      PIC 9(04)   VALUE ZEROES.*/
                public IntBasis LD02_CODFILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      10      LD02-FIL3           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-COD-SOLIC      PIC 9(03)   VALUE 140.*/
                public IntBasis LD02_COD_SOLIC { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 140);
                /*"      10      LD02-FIL4           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-COD-AREA-RESP  PIC 9(04)   VALUE 11.*/
                public IntBasis LD02_COD_AREA_RESP { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 11);
                /*"      10      LD02-FIL5           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-COD-AREA-SOLIC PIC 9(04)   VALUE 11.*/
                public IntBasis LD02_COD_AREA_SOLIC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 11);
                /*"      10      LD02-FIL6           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-NRCERTIF       PIC 9(15).*/
                public IntBasis LD02_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD02-FIL7           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-NOME-RAZAO     PIC X(40).*/
                public StringBasis LD02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      LD02-FIL8           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-CGCCPF         PIC 9(15).*/
                public IntBasis LD02_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD02-FIL9           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-DESC-DOC.*/
                public VA1466B_LD02_DESC_DOC LD02_DESC_DOC { get; set; } = new VA1466B_LD02_DESC_DOC();
                public class VA1466B_LD02_DESC_DOC : VarBasis
                {
                    /*"        15    LD02-DESC-P1        PIC X(22)   VALUE             'PROPOSTA EM CRITICA - '.*/
                    public StringBasis LD02_DESC_P1 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"PROPOSTA EM CRITICA - ");
                    /*"        15    LD02-NOMPRODU       PIC X(40)   VALUE SPACES.*/
                    public StringBasis LD02_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"      10      LD02-FIL10          PIC X(01)   VALUE ';'.*/
                }
                public StringBasis LD02_FIL10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05      HD-REG-DSAIDA.*/
            }
            public VA1466B_HD_REG_DSAIDA HD_REG_DSAIDA { get; set; } = new VA1466B_HD_REG_DSAIDA();
            public class VA1466B_HD_REG_DSAIDA : VarBasis
            {
                /*"      10    HD-COD-PRO-DSAIDA   PIC  X(008)   VALUE 'VA1466B'.*/
                public StringBasis HD_COD_PRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA1466B");
                /*"      10    HD-DES-REL-DSAIDA   PIC  X(050)   VALUE      'RELATORIO DE ERROS DE DADOS'.*/
                public StringBasis HD_DES_REL_DSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE DADOS");
                /*"      10    HD-DTA-SIS-DSAIDA   PIC  X(010)   VALUE SPACES.*/
                public StringBasis HD_DTA_SIS_DSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05      CB-REG-DSAIDA.*/
            }
            public VA1466B_CB_REG_DSAIDA CB_REG_DSAIDA { get; set; } = new VA1466B_CB_REG_DSAIDA();
            public class VA1466B_CB_REG_DSAIDA : VarBasis
            {
                /*"      10    FILLER              PIC  X(045)   VALUE      'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
                /*"      10    FILLER              PIC  X(042)   VALUE      'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
                /*"      10    FILLER              PIC  X(033)   VALUE      'DETALHAMENTO DO PROBLEMA OCORRIDO'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO");
                /*"    05      LD-REG-DSAIDA.*/
            }
            public VA1466B_LD_REG_DSAIDA LD_REG_DSAIDA { get; set; } = new VA1466B_LD_REG_DSAIDA();
            public class VA1466B_LD_REG_DSAIDA : VarBasis
            {
                /*"      10    LD-NUM-APOL-DSAIDA         PIC 9(013).*/
                public IntBasis LD_NUM_APOL_DSAIDA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-COD-SUBG-DSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_SUBG_DSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-COD-PROD-DSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_PROD_DSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-NOM-PROD-DSAIDA         PIC X(030).*/
                public StringBasis LD_NOM_PROD_DSAIDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-NUM-CERT-SUB-DSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SUB_DSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-NUM-CERT-SEG-DSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SEG_DSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-DES-ERRO-DSAIDA         PIC X(080).*/
                public StringBasis LD_DES_ERRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"    05      HD-REG-SSAIDA.*/
            }
            public VA1466B_HD_REG_SSAIDA HD_REG_SSAIDA { get; set; } = new VA1466B_HD_REG_SSAIDA();
            public class VA1466B_HD_REG_SSAIDA : VarBasis
            {
                /*"      10    HD-COD-PRO-SSAIDA   PIC  X(008)   VALUE 'VA1466B'.*/
                public StringBasis HD_COD_PRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA1466B");
                /*"      10    HD-DES-REL-SSAIDA   PIC  X(050)   VALUE      'RELATORIO DE ERROS DE SISTEMAS'.*/
                public StringBasis HD_DES_REL_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE SISTEMAS");
                /*"      10    HD-DTA-SIS-SSAIDA   PIC  X(010)   VALUE SPACES.*/
                public StringBasis HD_DTA_SIS_SSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05      CB-REG-SSAIDA.*/
            }
            public VA1466B_CB_REG_SSAIDA CB_REG_SSAIDA { get; set; } = new VA1466B_CB_REG_SSAIDA();
            public class VA1466B_CB_REG_SSAIDA : VarBasis
            {
                /*"      10    FILLER              PIC  X(045)   VALUE      'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
                /*"      10    FILLER              PIC  X(042)   VALUE      'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
                /*"      10    FILLER              PIC  X(035)   VALUE      'CODIGO ERRO DB2;DESCRICAO ERRO DB2;'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"CODIGO ERRO DB2;DESCRICAO ERRO DB2;");
                /*"      10    FILLER              PIC  X(034)   VALUE      'DETALHAMENTO DO PROBLEMA OCORRIDO;'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO;");
                /*"      10    FILLER              PIC  X(016)   VALUE      'PROGRAMA'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PROGRAMA");
                /*"    05      LD-REG-SSAIDA.*/
            }
            public VA1466B_LD_REG_SSAIDA LD_REG_SSAIDA { get; set; } = new VA1466B_LD_REG_SSAIDA();
            public class VA1466B_LD_REG_SSAIDA : VarBasis
            {
                /*"      10    LD-NUM-APOL-SSAIDA         PIC 9(013).*/
                public IntBasis LD_NUM_APOL_SSAIDA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-COD-SUBG-SSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_SUBG_SSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-COD-PROD-SSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_PROD_SSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-NOM-PROD-SSAIDA         PIC X(030).*/
                public StringBasis LD_NOM_PROD_SSAIDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-NUM-CERT-SUB-SSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SUB_SSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-NUM-CERT-SEG-SSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SEG_SSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-COD-ERRO-DB2-SSAIDA     PIC -9(004).*/
                public IntBasis LD_COD_ERRO_DB2_SSAIDA { get; set; } = new IntBasis(new PIC("-9", "4", "-9(004)."));
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-DES-ERRO-DB2-SSAIDA     PIC X(050).*/
                public StringBasis LD_DES_ERRO_DB2_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-DES-ERRO-SSAIDA         PIC X(050).*/
                public StringBasis LD_DES_ERRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"      10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"      10    LD-NOM-PROG-SSAIDA        PIC X(008) VALUE 'VA1466B'*/
                public StringBasis LD_NOM_PROG_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA1466B");
                /*"01            TABELA-FONTES1.*/
            }
        }
        public VA1466B_TABELA_FONTES1 TABELA_FONTES1 { get; set; } = new VA1466B_TABELA_FONTES1();
        public class VA1466B_TABELA_FONTES1 : VarBasis
        {
            /*"      10      TAB-FTE1            OCCURS 99 TIMES.*/
            public ListBasis<VA1466B_TAB_FTE1> TAB_FTE1 { get; set; } = new ListBasis<VA1466B_TAB_FTE1>(99);
            public class VA1466B_TAB_FTE1 : VarBasis
            {
                /*"        15    TBFT-NMFONTE        PIC  X(040).*/
                public StringBasis TBFT_NMFONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"01            TABELA-FONTES.*/
            }
        }
        public VA1466B_TABELA_FONTES TABELA_FONTES { get; set; } = new VA1466B_TABELA_FONTES();
        public class VA1466B_TABELA_FONTES : VarBasis
        {
            /*"      10      TAB-FTE             OCCURS 99 TIMES.*/
            public ListBasis<VA1466B_TAB_FTE> TAB_FTE { get; set; } = new ListBasis<VA1466B_TAB_FTE>(99);
            public class VA1466B_TAB_FTE : VarBasis
            {
                /*"        15    TBFT-QT-ESTOQ        PIC  9(006).*/
                public IntBasis TBFT_QT_ESTOQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        15    TBFT-VL-ESTOQ        PIC  9(013)V99.*/
                public DoubleBasis TBFT_VL_ESTOQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TABELA-ESCNEG.*/
            }
        }
        public VA1466B_TABELA_ESCNEG TABELA_ESCNEG { get; set; } = new VA1466B_TABELA_ESCNEG();
        public class VA1466B_TABELA_ESCNEG : VarBasis
        {
            /*"      10      TAB-EN              OCCURS 200 TIMES                                  INDEXED BY I01.*/
            public ListBasis<VA1466B_TAB_EN> TAB_EN { get; set; } = new ListBasis<VA1466B_TAB_EN>(200);
            public class VA1466B_TAB_EN : VarBasis
            {
                /*"        15    TBEN-CDFONTE        PIC  9(002).*/
                public IntBasis TBEN_CDFONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        15    TBEN-CDESCNEG       PIC  9(004).*/
                public IntBasis TBEN_CDESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        15    TBEN-NMESCNEG       PIC  X(030).*/
                public StringBasis TBEN_NMESCNEG { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"        15    TBEN-QT-ESTOQ       PIC  9(006).*/
                public IntBasis TBEN_QT_ESTOQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        15    TBEN-VL-ESTOQ       PIC  9(013)V99.*/
                public DoubleBasis TBEN_VL_ESTOQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            }
        }


        public Dclgens.GE637 GE637 { get; set; } = new Dclgens.GE637();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public VA1466B_TCOMIS TCOMIS { get; set; } = new VA1466B_TCOMIS();
        public VA1466B_CFONTES CFONTES { get; set; } = new VA1466B_CFONTES();
        public VA1466B_CESCNEG CESCNEG { get; set; } = new VA1466B_CESCNEG();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVA1466B_FILE_NAME_P, string AVA1466B_FILE_NAME_P, string DVA1466B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVA1466B.SetFile(SVA1466B_FILE_NAME_P);
                AVA1466B.SetFile(AVA1466B_FILE_NAME_P);
                DVA1466B.SetFile(DVA1466B_FILE_NAME_P);

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
            /*" -552- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -553- DISPLAY ' ' */
            _.Display($" ");

            /*" -554- DISPLAY '===============================================' */
            _.Display($"===============================================");

            /*" -555- DISPLAY '                  - VA1466B -                  ' */
            _.Display($"                  - VA1466B -                  ");

            /*" -558- DISPLAY '   VERSAO V.15 - DEMANDA 402.982 - 14/02/2023  ' */
            _.Display($"   VERSAO V.15 - DEMANDA 402.982 - 14/02/2023  ");

            /*" -559- DISPLAY '   COMPILACAO: ' FUNCTION WHEN-COMPILED '      ' */

            $"   COMPILACAO: FUNCTION{_.WhenCompiled()}      "
            .Display();

            /*" -560- DISPLAY '===============================================' */
            _.Display($"===============================================");

            /*" -562- DISPLAY ' ' */
            _.Display($" ");

            /*" -569- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -571- DISPLAY ' ' */
            _.Display($" ");

            /*" -576- MOVE ZEROS TO V0PROP-APOLICE V0PROP-CODSUBES V0PROP-NRCERTIF V0PROP-CODPRODU. */
            _.Move(0, V0PROP_APOLICE, V0PROP_CODSUBES, V0PROP_NRCERTIF, V0PROP_CODPRODU);

            /*" -579- MOVE SPACES TO V0PROD-NOMPRODU V0PROP-DTPROXVEN. */
            _.Move("", V0PROD_NOMPRODU, V0PROP_DTPROXVEN);

            /*" -583- INITIALIZE TABELA-FONTES TABELA-ESCNEG LD01. */
            _.Initialize(
                TABELA_FONTES
                , TABELA_ESCNEG
                , WORK_AREA.LD01
            );

            /*" -585- PERFORM R3100-00-DECLARE-FONTES. */

            R3100_00_DECLARE_FONTES_SECTION();

            /*" -587- PERFORM R3110-00-FETCH-FONTES. */

            R3110_00_FETCH_FONTES_SECTION();

            /*" -588- IF WFIM-FONTES NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_FONTES.IsEmpty())
            {

                /*" -589- DISPLAY '0000 - PROBLEMA NO FETCH DA FONTES      ' */
                _.Display($"0000 - PROBLEMA NO FETCH DA FONTES      ");

                /*" -591- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -594- PERFORM R3120-00-CARREGA-FONTES UNTIL WFIM-FONTES EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_FONTES == "S"))
            {

                R3120_00_CARREGA_FONTES_SECTION();
            }

            /*" -596- PERFORM R3200-00-DECLARE-ESCNEG. */

            R3200_00_DECLARE_ESCNEG_SECTION();

            /*" -598- PERFORM R3210-00-FETCH-ESCNEG. */

            R3210_00_FETCH_ESCNEG_SECTION();

            /*" -599- IF WFIM-ESCNEG NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_ESCNEG.IsEmpty())
            {

                /*" -600- DISPLAY 'R0000 - PROBLEMA NO FETCH DA ESCNEG ' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA ESCNEG ");

                /*" -602- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -604- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -606- PERFORM R0900-00-DECLARE-V0COMISICOB. */

            R0900_00_DECLARE_V0COMISICOB_SECTION();

            /*" -608- PERFORM R0910-00-FETCH-V0COMISICOB. */

            R0910_00_FETCH_V0COMISICOB_SECTION();

            /*" -609- IF WFIM-V0COMISICOB EQUAL 'S' */

            if (WORK_AREA.WFIM_V0COMISICOB == "S")
            {

                /*" -610- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -611- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -615- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -623- SORT SVA1466B ON ASCENDING KEY SVA-APOLICE SVA-CODSUBES SVA-CDFONTE SVA-CDESCNEG SVA-NRCERTIF INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-GERA-ARQ THRU R0020-FIM. */
            SORT_RETURN.Value = SVA1466B.Sort("SVA-APOLICE,SVA-CODSUBES,SVA-CDFONTE,SVA-CDESCNEG,SVA-NRCERTIF", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_GERA_ARQ_SECTION());

            /*" -626- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -627- DISPLAY '*** VA1466B - PROBLEMAS NO SORT ' */
                _.Display($"*** VA1466B - PROBLEMAS NO SORT ");

                /*" -628- DISPLAY '              SORT-RETURN = ' SORT-RETURN */
                _.Display($"              SORT-RETURN = {SORT_RETURN}");

                /*" -629- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -629- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -635- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -636- DISPLAY ' ' */
            _.Display($" ");

            /*" -644- DISPLAY 'TERMINO PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"TERMINO PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -645- DISPLAY ' ' */
            _.Display($" ");

            /*" -646- DISPLAY 'LIDOS V0PROPOSTAVA   =  ' AC-LIDOS. */
            _.Display($"LIDOS V0PROPOSTAVA   =  {WORK_AREA.AC_LIDOS}");

            /*" -647- DISPLAY 'GRAVADOS    SORT     =  ' AC-GRAVA-SORT. */
            _.Display($"GRAVADOS    SORT     =  {WORK_AREA.AC_GRAVA_SORT}");

            /*" -648- DISPLAY 'PROCESSADOS SORT     =  ' AC-LIDOS-SORT. */
            _.Display($"PROCESSADOS SORT     =  {WORK_AREA.AC_LIDOS_SORT}");

            /*" -649- DISPLAY ' ' */
            _.Display($" ");

            /*" -650- DISPLAY 'QTDE AVA1466B        =  ' AC-GRAVA-AVA1466B */
            _.Display($"QTDE AVA1466B        =  {WORK_AREA.AC_GRAVA_AVA1466B}");

            /*" -651- DISPLAY 'QTDE DVA1466B        =  ' AC-GRAVA-DVA1466B */
            _.Display($"QTDE DVA1466B        =  {WORK_AREA.AC_GRAVA_DVA1466B}");

            /*" -652- DISPLAY ' ' */
            _.Display($" ");

            /*" -653- DISPLAY '*** VA1466B - TERMINO NORMAL ***' */
            _.Display($"*** VA1466B - TERMINO NORMAL ***");

            /*" -653- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -663- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0COMISICOB EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V0COMISICOB == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-GERA-ARQ-SECTION */
        private void R0020_00_GERA_ARQ_SECTION()
        {
            /*" -675- OPEN OUTPUT AVA1466B DVA1466B. */
            AVA1466B.Open(REG_AVA1466B);
            DVA1466B.Open(REG_DVA1466B);

            /*" -676- WRITE REG-AVA1466B FROM LD00. */
            _.Move(WORK_AREA.LD00.GetMoveValues(), REG_AVA1466B);

            AVA1466B.Write(REG_AVA1466B.GetMoveValues().ToString());

            /*" -678- WRITE REG-AVA1466B FROM LD00-1. */
            _.Move(WORK_AREA.LD00_1.GetMoveValues(), REG_AVA1466B);

            AVA1466B.Write(REG_AVA1466B.GetMoveValues().ToString());

            /*" -680- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -683- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -684- CLOSE AVA1466B DVA1466B. */
            AVA1466B.Close();
            DVA1466B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -695- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -703- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -706- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -707- DISPLAY 'R0100 - PROBLEMAS SELECT  V1SISTEMA' */
                _.Display($"R0100 - PROBLEMAS SELECT  V1SISTEMA");

                /*" -708- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -710- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -712- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -718- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -721- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -722- DISPLAY 'R0100 - PROBLEMAS SELECT V0CONTROCNAB' */
                _.Display($"R0100 - PROBLEMAS SELECT V0CONTROCNAB");

                /*" -723- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -725- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -726- MOVE V0CONT-DATCEF TO DATA-SQL. */
            _.Move(V0CONT_DATCEF, WORK_AREA.DATA_SQL);

            /*" -727- MOVE DATA-SQL TO WHOST-DTFINAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTFINAL);

            /*" -728- MOVE 01 TO DIA-SQL */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -729- MOVE DATA-SQL TO WHOST-DTINICIAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTINICIAL);

            /*" -730- MOVE V1SIST-DTHOJE(1:4) TO LD00-DATAINI(7:4) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(1, 4), WORK_AREA.LD00.LD00_DATAINI, 7, 4);

            /*" -731- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", WORK_AREA.LD00.LD00_DATAINI, 3, 1);

            /*" -732- MOVE V1SIST-DTHOJE(6:2) TO LD00-DATAINI(4:2) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(6, 2), WORK_AREA.LD00.LD00_DATAINI, 4, 2);

            /*" -733- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", WORK_AREA.LD00.LD00_DATAINI, 6, 1);

            /*" -735- MOVE V1SIST-DTHOJE(9:2) TO LD00-DATAINI(1:2). */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(9, 2), WORK_AREA.LD00.LD00_DATAINI, 1, 2);

            /*" -736- MOVE V1SIST-DTMOVABE(1:4) TO HD-DTA-SIS-DSAIDA(7:4). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(1, 4), WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 7, 4);

            /*" -737- MOVE V1SIST-DTMOVABE(6:2) TO HD-DTA-SIS-DSAIDA(4:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(6, 2), WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 4, 2);

            /*" -738- MOVE V1SIST-DTMOVABE(9:2) TO HD-DTA-SIS-DSAIDA(1:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(9, 2), WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 1, 2);

            /*" -740- MOVE '/' TO HD-DTA-SIS-DSAIDA(6:1). */
            _.MoveAtPosition("/", WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 6, 1);

            /*" -740- MOVE '/' TO HD-DTA-SIS-DSAIDA(3:1) */
            _.MoveAtPosition("/", WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 3, 1);

            /*" -740- MOVE HD-DTA-SIS-DSAIDA TO HD-DTA-SIS-SSAIDA. */
            _.Move(WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, WORK_AREA.HD_REG_SSAIDA.HD_DTA_SIS_SSAIDA);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -703- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTHOJE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-2 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_2()
        {
            /*" -718- EXEC SQL SELECT MAX(DATCEF) INTO :V0CONT-DATCEF FROM SEGUROS.V0CONTROCNAB WHERE NRCTACED = 63000300001004 WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONT_DATCEF, V0CONT_DATCEF);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0COMISICOB-SECTION */
        private void R0900_00_DECLARE_V0COMISICOB_SECTION()
        {
            /*" -751- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -780- PERFORM R0900_00_DECLARE_V0COMISICOB_DB_DECLARE_1 */

            R0900_00_DECLARE_V0COMISICOB_DB_DECLARE_1();

            /*" -787- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -788- DISPLAY 'R0900 - PROBLEMAS DECLARE V0COMISICOB' */
                _.Display($"R0900 - PROBLEMAS DECLARE V0COMISICOB");

                /*" -789- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -791- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -791- PERFORM R0900_00_DECLARE_V0COMISICOB_DB_OPEN_1 */

            R0900_00_DECLARE_V0COMISICOB_DB_OPEN_1();

            /*" -794- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -795- DISPLAY 'R0900 - PROBLEMAS OPEN V0COMISICOB' */
                _.Display($"R0900 - PROBLEMAS OPEN V0COMISICOB");

                /*" -796- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -796- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0COMISICOB-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0COMISICOB_DB_DECLARE_1()
        {
            /*" -780- EXEC SQL DECLARE TCOMIS CURSOR FOR SELECT B.NUM_APOLICE, B.CODSUBES, B.NRCERTIF, B.AGECOBR, B.DTQITBCO, DAYS (:V1SIST-DTMOVABE) - DAYS (B.DTQITBCO), B.CODUSU, B.NRMATRVEN, B.CODCLIEN, B.OCOREND, C.IMPSEGUR, C.VLPREMIO, B.SITUACAO, B.DTPROXVEN, A.CODPRODU, A.NOMPRODU FROM SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0COBERPROPVA C WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.SITUACAO IN ( '1' , '9' , 'E' ) AND C.OCORHIST = B.OCORHIST AND C.NRCERTIF = B.NRCERTIF AND A.RAMO <> 77 WITH UR END-EXEC. */
            TCOMIS = new VA1466B_TCOMIS(true);
            string GetQuery_TCOMIS()
            {
                var query = @$"SELECT 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.NRCERTIF
							, 
							B.AGECOBR
							, 
							B.DTQITBCO
							, 
							DAYS ('{V1SIST_DTMOVABE}') - DAYS (B.DTQITBCO)
							, 
							B.CODUSU
							, 
							B.NRMATRVEN
							, 
							B.CODCLIEN
							, 
							B.OCOREND
							, 
							C.IMPSEGUR
							, 
							C.VLPREMIO
							, 
							B.SITUACAO
							, 
							B.DTPROXVEN
							, 
							A.CODPRODU
							, 
							A.NOMPRODU 
							FROM SEGUROS.V0PRODUTOSVG A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0COBERPROPVA C 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.SITUACAO IN ( '1'
							, '9'
							, 'E' ) 
							AND C.OCORHIST = B.OCORHIST 
							AND C.NRCERTIF = B.NRCERTIF 
							AND A.RAMO <> 77";

                return query;
            }
            TCOMIS.GetQueryEvent += GetQuery_TCOMIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0COMISICOB-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0COMISICOB_DB_OPEN_1()
        {
            /*" -791- EXEC SQL OPEN TCOMIS END-EXEC. */

            TCOMIS.Open();

        }

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R3100_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -1336- EXEC SQL DECLARE CFONTES CURSOR FOR SELECT FONTE, NOMEFTE FROM SEGUROS.V0FONTE ORDER BY FONTE WITH UR END-EXEC. */
            CFONTES = new VA1466B_CFONTES(false);
            string GetQuery_CFONTES()
            {
                var query = @$"SELECT FONTE
							, 
							NOMEFTE 
							FROM SEGUROS.V0FONTE 
							ORDER BY FONTE";

                return query;
            }
            CFONTES.GetQueryEvent += GetQuery_CFONTES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0COMISICOB-SECTION */
        private void R0910_00_FETCH_V0COMISICOB_SECTION()
        {
            /*" -807- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -825- PERFORM R0910_00_FETCH_V0COMISICOB_DB_FETCH_1 */

            R0910_00_FETCH_V0COMISICOB_DB_FETCH_1();

            /*" -828- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -829- MOVE 'S' TO WFIM-V0COMISICOB */
                _.Move("S", WORK_AREA.WFIM_V0COMISICOB);

                /*" -829- PERFORM R0910_00_FETCH_V0COMISICOB_DB_CLOSE_1 */

                R0910_00_FETCH_V0COMISICOB_DB_CLOSE_1();

                /*" -831- ELSE */
            }
            else
            {


                /*" -831- ADD 1 TO AC-LIDOS. */
                WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-V0COMISICOB-DB-FETCH-1 */
        public void R0910_00_FETCH_V0COMISICOB_DB_FETCH_1()
        {
            /*" -825- EXEC SQL FETCH TCOMIS INTO :V0PROP-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-AGECOBR, :V0PROP-DTQITBCO, :WHOST-QTDIAS, :V0PROP-CODUSU, :V0PROP-NRMATRVEN, :V0PROP-CODCLIEN, :V0PROP-OCOREND, :V0PROP-IMPSEGUR, :V0PROP-VLPREMIO, :V0PROP-SITUACAO, :V0PROP-DTPROXVEN, :V0PROP-CODPRODU, :V0PROP-NOMPRODU END-EXEC. */

            if (TCOMIS.Fetch())
            {
                _.Move(TCOMIS.V0PROP_APOLICE, V0PROP_APOLICE);
                _.Move(TCOMIS.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(TCOMIS.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(TCOMIS.V0PROP_AGECOBR, V0PROP_AGECOBR);
                _.Move(TCOMIS.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(TCOMIS.WHOST_QTDIAS, WHOST_QTDIAS);
                _.Move(TCOMIS.V0PROP_CODUSU, V0PROP_CODUSU);
                _.Move(TCOMIS.V0PROP_NRMATRVEN, V0PROP_NRMATRVEN);
                _.Move(TCOMIS.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(TCOMIS.V0PROP_OCOREND, V0PROP_OCOREND);
                _.Move(TCOMIS.V0PROP_IMPSEGUR, V0PROP_IMPSEGUR);
                _.Move(TCOMIS.V0PROP_VLPREMIO, V0PROP_VLPREMIO);
                _.Move(TCOMIS.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(TCOMIS.V0PROP_DTPROXVEN, V0PROP_DTPROXVEN);
                _.Move(TCOMIS.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(TCOMIS.V0PROP_NOMPRODU, V0PROP_NOMPRODU);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0COMISICOB-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0COMISICOB_DB_CLOSE_1()
        {
            /*" -829- EXEC SQL CLOSE TCOMIS END-EXEC */

            TCOMIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -842- PERFORM R1010-00-SELECT-CONVERSAO. */

            R1010_00_SELECT_CONVERSAO_SECTION();

            /*" -843- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -844- MOVE CONVERSI-NUM-SICOB TO WHOST-NUMTIT */
                _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB, WHOST_NUMTIT);

                /*" -845- ELSE */
            }
            else
            {


                /*" -846- MOVE V0PROP-NRCERTIF TO WHOST-NUMTIT */
                _.Move(V0PROP_NRCERTIF, WHOST_NUMTIT);

                /*" -852- END-IF */
            }


            /*" -856- PERFORM R1600-PROCESSA-RCAPS */

            R1600_PROCESSA_RCAPS_SECTION();

            /*" -858- PERFORM R1100-00-SELECT-V0CLIENTE. */

            R1100_00_SELECT_V0CLIENTE_SECTION();

            /*" -859- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -861- MOVE 'CLIENTE NAO CADASTRADO' TO V0CLIE-NOME-RAZAO */
                _.Move("CLIENTE NAO CADASTRADO", V0CLIE_NOME_RAZAO);

                /*" -863- MOVE ZEROS TO V0CLIE-CGCCPF. */
                _.Move(0, V0CLIE_CGCCPF);
            }


            /*" -865- PERFORM R1200-00-SELECT-V0ENDERECO. */

            R1200_00_SELECT_V0ENDERECO_SECTION();

            /*" -866- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -868- MOVE 'ENDERECO NAO CADASTRADO' TO V0ENDE-ENDERECO */
                _.Move("ENDERECO NAO CADASTRADO", V0ENDE_ENDERECO);

                /*" -871- MOVE SPACES TO V0ENDE-BAIRRO V0ENDE-CIDADE V0ENDE-SIGLA-UF */
                _.Move("", V0ENDE_BAIRRO, V0ENDE_CIDADE, V0ENDE_SIGLA_UF);

                /*" -875- MOVE ZEROS TO V0ENDE-CEP V0ENDE-DDD V0ENDE-TELEFONE. */
                _.Move(0, V0ENDE_CEP, V0ENDE_DDD, V0ENDE_TELEFONE);
            }


            /*" -877- PERFORM R1300-00-SELECT-V0AGENCIACEF. */

            R1300_00_SELECT_V0AGENCIACEF_SECTION();

            /*" -878- MOVE V0CLIE-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVA1466B.SVA_NOME_RAZAO);

            /*" -879- MOVE V0CLIE-CGCCPF TO SVA-CGCCPF. */
            _.Move(V0CLIE_CGCCPF, REG_SVA1466B.SVA_CGCCPF);

            /*" -880- MOVE V0ENDE-ENDERECO TO SVA-ENDERECO. */
            _.Move(V0ENDE_ENDERECO, REG_SVA1466B.SVA_ENDERECO);

            /*" -881- MOVE V0ENDE-BAIRRO TO SVA-BAIRRO. */
            _.Move(V0ENDE_BAIRRO, REG_SVA1466B.SVA_BAIRRO);

            /*" -882- MOVE V0ENDE-CIDADE TO SVA-CIDADE. */
            _.Move(V0ENDE_CIDADE, REG_SVA1466B.SVA_CIDADE);

            /*" -883- MOVE V0ENDE-SIGLA-UF TO SVA-SIGLA-UF. */
            _.Move(V0ENDE_SIGLA_UF, REG_SVA1466B.SVA_SIGLA_UF);

            /*" -884- MOVE V0ENDE-CEP TO SVA-CEP. */
            _.Move(V0ENDE_CEP, REG_SVA1466B.SVA_CEP);

            /*" -885- MOVE V0ENDE-DDD TO SVA-DDD. */
            _.Move(V0ENDE_DDD, REG_SVA1466B.SVA_DDD);

            /*" -886- MOVE V0ENDE-TELEFONE TO SVA-TELEFONE. */
            _.Move(V0ENDE_TELEFONE, REG_SVA1466B.SVA_TELEFONE);

            /*" -887- MOVE V0PROP-APOLICE TO SVA-APOLICE. */
            _.Move(V0PROP_APOLICE, REG_SVA1466B.SVA_APOLICE);

            /*" -888- MOVE V0PROP-CODSUBES TO SVA-CODSUBES. */
            _.Move(V0PROP_CODSUBES, REG_SVA1466B.SVA_CODSUBES);

            /*" -889- MOVE V0PROP-NRCERTIF TO SVA-NRCERTIF. */
            _.Move(V0PROP_NRCERTIF, REG_SVA1466B.SVA_NRCERTIF);

            /*" -890- MOVE V0PROP-CODUSU TO SVA-CODUSU. */
            _.Move(V0PROP_CODUSU, REG_SVA1466B.SVA_CODUSU);

            /*" -893- MOVE V0PROP-NRMATRVEN TO SVA-NRMATRVEN. */
            _.Move(V0PROP_NRMATRVEN, REG_SVA1466B.SVA_NRMATRVEN);

            /*" -894- IF RCAPCOMP-DATA-RCAP = '0001-01-01' */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP == "0001-01-01")
            {

                /*" -895- MOVE V0PROP-DTQITBCO TO SVA-DTQITBCO */
                _.Move(V0PROP_DTQITBCO, REG_SVA1466B.SVA_DTQITBCO);

                /*" -896- ELSE */
            }
            else
            {


                /*" -897- MOVE RCAPCOMP-DATA-RCAP TO SVA-DTQITBCO */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, REG_SVA1466B.SVA_DTQITBCO);

                /*" -899- END-IF */
            }


            /*" -900- MOVE V0PROP-AGECOBR TO SVA-AGECOBR. */
            _.Move(V0PROP_AGECOBR, REG_SVA1466B.SVA_AGECOBR);

            /*" -901- MOVE V0MALHA-CDFONTE TO SVA-CDFONTE. */
            _.Move(V0MALHA_CDFONTE, REG_SVA1466B.SVA_CDFONTE);

            /*" -902- MOVE V0MALHA-CDESCNEG TO SVA-CDESCNEG. */
            _.Move(V0MALHA_CDESCNEG, REG_SVA1466B.SVA_CDESCNEG);

            /*" -903- MOVE V0PROP-IMPSEGUR TO SVA-IMPSEGUR. */
            _.Move(V0PROP_IMPSEGUR, REG_SVA1466B.SVA_IMPSEGUR);

            /*" -904- MOVE V0PROP-VLPREMIO TO SVA-VLPREMIO. */
            _.Move(V0PROP_VLPREMIO, REG_SVA1466B.SVA_VLPREMIO);

            /*" -905- MOVE V0PROP-SITUACAO TO SVA-SITUACAO. */
            _.Move(V0PROP_SITUACAO, REG_SVA1466B.SVA_SITUACAO);

            /*" -906- MOVE WHOST-QTDIAS TO SVA-QTDIAS. */
            _.Move(WHOST_QTDIAS, REG_SVA1466B.SVA_QTDIAS);

            /*" -910- MOVE V0PROP-DTPROXVEN TO SVA-DTPROXVEN. */
            _.Move(V0PROP_DTPROXVEN, REG_SVA1466B.SVA_DTPROXVEN);

            /*" -911- PERFORM R1500-00-SELECT-PROP-ERRO. */

            R1500_00_SELECT_PROP_ERRO_SECTION();

            /*" -913- MOVE WS-DESCR-ERRO TO SVA-DESC-ERRO. */
            _.Move(WS_DESCR_ERRO, REG_SVA1466B.SVA_DESC_ERRO);

            /*" -914- RELEASE REG-SVA1466B. */
            SVA1466B.Release(REG_SVA1466B);

            /*" -914- ADD 1 TO AC-GRAVA-SORT. */
            WORK_AREA.AC_GRAVA_SORT.Value = WORK_AREA.AC_GRAVA_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -918- PERFORM R0910-00-FETCH-V0COMISICOB. */

            R0910_00_FETCH_V0COMISICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-SECTION */
        private void R1100_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -929- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -937- PERFORM R1100_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1100_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -940- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -941- DISPLAY 'PROBLEMAS SELECT V0CLIENTE' */
                _.Display($"PROBLEMAS SELECT V0CLIENTE");

                /*" -942- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -942- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1100_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -937- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CGCCPF FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0PROP-CODCLIEN WITH UR END-EXEC. */

            var r1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO, V0CLIE_NOME_RAZAO);
                _.Move(executed_1.V0CLIE_CGCCPF, V0CLIE_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-SECTION */
        private void R1010_00_SELECT_CONVERSAO_SECTION()
        {
            /*" -953- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -959- PERFORM R1010_00_SELECT_CONVERSAO_DB_SELECT_1 */

            R1010_00_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -962- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -963- DISPLAY 'R1010 - PROBLEMAS SELECT CONVERSAO_SICOB' */
                _.Display($"R1010 - PROBLEMAS SELECT CONVERSAO_SICOB");

                /*" -965- DISPLAY 'SQLCODE=' SQLCODE ' NUM_PROPOSTA_SIVPF=' V0PROP-NRCERTIF */

                $"SQLCODE={DB.SQLCODE} NUM_PROPOSTA_SIVPF={V0PROP_NRCERTIF}"
                .Display();

                /*" -966- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -967- END-IF */
            }


            /*" -967- . */

        }

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R1010_00_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -959- EXEC SQL SELECT NUM_SICOB INTO :CONVERSI-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NRCERTIF WITH UR END-EXEC. */

            var r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 = new R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_SICOB, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECO-SECTION */
        private void R1200_00_SELECT_V0ENDERECO_SECTION()
        {
            /*" -1000- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1019- PERFORM R1200_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1200_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -1022- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1023- DISPLAY 'R1200 - PROBLEMAS SELECT V0ENDERECOS' */
                _.Display($"R1200 - PROBLEMAS SELECT V0ENDERECOS");

                /*" -1024- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1024- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1200_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -1019- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-SIGLA-UF, :V0ENDE-CEP, :V0ENDE-DDD, :V0ENDE-TELEFONE FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0PROP-CODCLIEN AND OCORR_ENDERECO = :V0PROP-OCOREND WITH UR END-EXEC. */

            var r1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0PROP_OCOREND = V0PROP_OCOREND.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDERECO, V0ENDE_ENDERECO);
                _.Move(executed_1.V0ENDE_BAIRRO, V0ENDE_BAIRRO);
                _.Move(executed_1.V0ENDE_CIDADE, V0ENDE_CIDADE);
                _.Move(executed_1.V0ENDE_SIGLA_UF, V0ENDE_SIGLA_UF);
                _.Move(executed_1.V0ENDE_CEP, V0ENDE_CEP);
                _.Move(executed_1.V0ENDE_DDD, V0ENDE_DDD);
                _.Move(executed_1.V0ENDE_TELEFONE, V0ENDE_TELEFONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0AGENCIACEF-SECTION */
        private void R1300_00_SELECT_V0AGENCIACEF_SECTION()
        {
            /*" -1035- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1045- PERFORM R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1 */

            R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1();

            /*" -1048- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1049- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1050- MOVE 99 TO V0MALHA-CDFONTE */
                    _.Move(99, V0MALHA_CDFONTE);

                    /*" -1051- MOVE 4172 TO V0MALHA-CDESCNEG */
                    _.Move(4172, V0MALHA_CDESCNEG);

                    /*" -1052- ELSE */
                }
                else
                {


                    /*" -1053- DISPLAY 'R1300 - PROBLEMAS SELECT V0AGENCIACEF' */
                    _.Display($"R1300 - PROBLEMAS SELECT V0AGENCIACEF");

                    /*" -1054- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1054- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0AGENCIACEF-DB-SELECT-1 */
        public void R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1()
        {
            /*" -1045- EXEC SQL SELECT B.COD_FONTE, A.COD_ESCNEG INTO :V0MALHA-CDFONTE, :V0MALHA-CDESCNEG FROM SEGUROS.V0AGENCIACEF A, SEGUROS.V0MALHACEF B WHERE A.COD_AGENCIA = :V0PROP-AGECOBR AND B.COD_SUREG = A.COD_ESCNEG WITH UR END-EXEC. */

            var r1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1()
            {
                V0PROP_AGECOBR = V0PROP_AGECOBR.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MALHA_CDFONTE, V0MALHA_CDFONTE);
                _.Move(executed_1.V0MALHA_CDESCNEG, V0MALHA_CDESCNEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-PROP-ERRO-SECTION */
        private void R1500_00_SELECT_PROP_ERRO_SECTION()
        {
            /*" -1078- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1089- PERFORM R1500_00_SELECT_PROP_ERRO_DB_SELECT_1 */

            R1500_00_SELECT_PROP_ERRO_DB_SELECT_1();

            /*" -1093- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1094- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1095- MOVE 'PROPOSTA SEM ERRO' TO WS-DESCR-ERRO */
                    _.Move("PROPOSTA SEM ERRO", WS_DESCR_ERRO);

                    /*" -1096- ELSE */
                }
                else
                {


                    /*" -1097- DISPLAY 'R1500 - PROBLEMAS SELECT VG_CRITICA_PROPOSTA' */
                    _.Display($"R1500 - PROBLEMAS SELECT VG_CRITICA_PROPOSTA");

                    /*" -1098- DISPLAY 'SLQCODE - ' SQLCODE */
                    _.Display($"SLQCODE - {DB.SQLCODE}");

                    /*" -1099- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1100- END-IF */
                }


                /*" -1100- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-PROP-ERRO-DB-SELECT-1 */
        public void R1500_00_SELECT_PROP_ERRO_DB_SELECT_1()
        {
            /*" -1089- EXEC SQL SELECT SUBSTR(VALUE(T2.DES_ABREV_MSG_CRITICA, ' ' ),1,40) INTO :WS-DESCR-ERRO FROM SEGUROS.VG_CRITICA_PROPOSTA T1, SEGUROS.VG_DM_MSG_CRITICA T2 WHERE T1.NUM_CERTIFICADO = :V0PROP-NRCERTIF AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA AND T2.COD_TP_MSG_CRITICA <> '3' FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1 = new R1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_PROP_ERRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DESCR_ERRO, WS_DESCR_ERRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-PROCESSA-RCAPS-SECTION */
        private void R1600_PROCESSA_RCAPS_SECTION()
        {
            /*" -1112- MOVE '1600' TO WNR-EXEC-SQL */
            _.Move("1600", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1114- INITIALIZE RCAPS-COD-FONTE RCAPS-NUM-RCAP */
            _.Initialize(
                RCAPS.DCLRCAPS.RCAPS_COD_FONTE
                , RCAPS.DCLRCAPS.RCAPS_NUM_RCAP
            );

            /*" -1117- MOVE '0001-01-01' TO RCAPCOMP-DATA-RCAP */
            _.Move("0001-01-01", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);

            /*" -1119- PERFORM DB100-ACESSA-RCAPS-TITULO */

            DB100_ACESSA_RCAPS_TITULO_SECTION();

            /*" -1121- IF SQLCODE = +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -1122- PERFORM DB200-ACESSA-RCAPS-CERTIFICADO */

                DB200_ACESSA_RCAPS_CERTIFICADO_SECTION();

                /*" -1124- END-IF */
            }


            /*" -1125- IF RCAPS-COD-FONTE NOT = 000 */

            if (RCAPS.DCLRCAPS.RCAPS_COD_FONTE != 000)
            {

                /*" -1126- PERFORM DB300-ACESSA-RCAP-COMPLEMENTAR */

                DB300_ACESSA_RCAP_COMPLEMENTAR_SECTION();

                /*" -1127- END-IF */
            }


            /*" -1127- . */

        }

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -1136- MOVE SVA-APOLICE TO WS-APOLICE-ANT WHOST-APOLICE */
            _.Move(REG_SVA1466B.SVA_APOLICE, WORK_AREA.WS_APOLICE_ANT, WHOST_APOLICE);

            /*" -1139- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT WHOST-CODSUBES. */
            _.Move(REG_SVA1466B.SVA_CODSUBES, WORK_AREA.WS_CODSUBES_ANT, WHOST_CODSUBES);

            /*" -1141- PERFORM R2500-00-SELECT-PRODUTO. */

            R2500_00_SELECT_PRODUTO_SECTION();

            /*" -1144- PERFORM R2100-00-PROCESSA-PRODUTO UNTIL SVA-APOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA1466B.SVA_APOLICE != WORK_AREA.WS_APOLICE_ANT || REG_SVA1466B.SVA_CODSUBES != WORK_AREA.WS_CODSUBES_ANT || WORK_AREA.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_PRODUTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-PRODUTO-SECTION */
        private void R2100_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -1156- MOVE SVA-CDFONTE TO WS-FONTE-ANT. */
            _.Move(REG_SVA1466B.SVA_CDFONTE, WORK_AREA.WS_FONTE_ANT);

            /*" -1160- PERFORM R2200-00-PROCESSA-FONTE UNTIL SVA-APOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CDFONTE NOT EQUAL WS-FONTE-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA1466B.SVA_APOLICE != WORK_AREA.WS_APOLICE_ANT || REG_SVA1466B.SVA_CODSUBES != WORK_AREA.WS_CODSUBES_ANT || REG_SVA1466B.SVA_CDFONTE != WORK_AREA.WS_FONTE_ANT || WORK_AREA.WFIM_SORT == "S"))
            {

                R2200_00_PROCESSA_FONTE_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FONTE-SECTION */
        private void R2200_00_PROCESSA_FONTE_SECTION()
        {
            /*" -1172- MOVE '-' TO LD01-TRA1 LD01-TRA1A */
            _.Move("-", WORK_AREA.LD01.LD01_TRA1, WORK_AREA.LD01.LD01_TRA1A);

            /*" -1206- MOVE ';' TO LD01-FIL1 LD01-FIL2 LD01-FIL2A LD01-FIL3 LD01-FIL3-A LD01-FIL3-A1 LD01-FIL3-A2 LD01-FIL3-B LD01-FIL3-C LD01-FIL3-D LD01-FIL3-E LD01-FIL3-F LD01-FIL3-G LD01-FIL3-H LD01-FIL3-I LD01-FIL4 LD01-FIL5 LD01-FIL6 LD01-FIL7 LD01-FIL8 LD01-FIL9 LD01-FIL10 LD01-FIL11 LD02-FIL1 LD02-FIL2 LD02-FIL3 LD02-FIL4 LD02-FIL5 LD02-FIL6 LD02-FIL7 LD02-FIL8 LD02-FIL9 LD02-FIL10 */
            _.Move(";", WORK_AREA.LD01.LD01_FIL1, WORK_AREA.LD01.LD01_FIL2, WORK_AREA.LD01.LD01_FIL2A, WORK_AREA.LD01.LD01_FIL3, WORK_AREA.LD01.LD01_FIL3_A, WORK_AREA.LD01.LD01_FIL3_A1, WORK_AREA.LD01.LD01_FIL3_A2, WORK_AREA.LD01.LD01_FIL3_B, WORK_AREA.LD01.LD01_FIL3_C, WORK_AREA.LD01.LD01_FIL3_D, WORK_AREA.LD01.LD01_FIL3_E, WORK_AREA.LD01.LD01_FIL3_F, WORK_AREA.LD01.LD01_FIL3_G, WORK_AREA.LD01.LD01_FIL3_H, WORK_AREA.LD01.LD01_FIL3_I, WORK_AREA.LD01.LD01_FIL4, WORK_AREA.LD01.LD01_FIL5, WORK_AREA.LD01.LD01_FIL6, WORK_AREA.LD01.LD01_FIL7, WORK_AREA.LD01.LD01_FIL8, WORK_AREA.LD01.LD01_FIL9, WORK_AREA.LD01.LD01_FIL10, WORK_AREA.LD01.LD01_FIL11, WORK_AREA.LD02.LD02_FIL1, WORK_AREA.LD02.LD02_FIL2, WORK_AREA.LD02.LD02_FIL3, WORK_AREA.LD02.LD02_FIL4, WORK_AREA.LD02.LD02_FIL5, WORK_AREA.LD02.LD02_FIL6, WORK_AREA.LD02.LD02_FIL7, WORK_AREA.LD02.LD02_FIL8, WORK_AREA.LD02.LD02_FIL9, WORK_AREA.LD02.LD02_FIL10);

            /*" -1207- IF SVA-CDESCNEG NOT EQUAL WS-COD-ESCNEG-ANT */

            if (REG_SVA1466B.SVA_CDESCNEG != WORK_AREA.WS_COD_ESCNEG_ANT)
            {

                /*" -1209- MOVE SVA-CDESCNEG TO WS-COD-ESCNEG-ANT WHOST-COD-ESCNEG */
                _.Move(REG_SVA1466B.SVA_CDESCNEG, WORK_AREA.WS_COD_ESCNEG_ANT, WHOST_COD_ESCNEG);

                /*" -1210- PERFORM R3190-00-SELECT-ESCNEG */

                R3190_00_SELECT_ESCNEG_SECTION();

                /*" -1211- MOVE V0ESCN-NOMEESC TO LD01-REGIAO-ESCNEG */
                _.Move(V0ESCN_NOMEESC, WORK_AREA.LD01.LD01_REGIAO_ESCNEG);

                /*" -1213- END-IF. */
            }


            /*" -1215- MOVE SVA-NOME-RAZAO TO LD01-NOME-RAZAO LD02-NOME-RAZAO. */
            _.Move(REG_SVA1466B.SVA_NOME_RAZAO, WORK_AREA.LD01.LD01_NOME_RAZAO, WORK_AREA.LD02.LD02_NOME_RAZAO);

            /*" -1217- MOVE SVA-CGCCPF TO LD01-CGCCPF LD02-CGCCPF. */
            _.Move(REG_SVA1466B.SVA_CGCCPF, WORK_AREA.LD01.LD01_CGCCPF, WORK_AREA.LD02.LD02_CGCCPF);

            /*" -1218- MOVE SVA-ENDERECO TO LD01-ENDERECO. */
            _.Move(REG_SVA1466B.SVA_ENDERECO, WORK_AREA.LD01.LD01_ENDERECO);

            /*" -1219- MOVE SVA-BAIRRO TO LD01-BAIRRO. */
            _.Move(REG_SVA1466B.SVA_BAIRRO, WORK_AREA.LD01.LD01_BAIRRO);

            /*" -1220- MOVE SVA-CIDADE TO LD01-CIDADE. */
            _.Move(REG_SVA1466B.SVA_CIDADE, WORK_AREA.LD01.LD01_CIDADE);

            /*" -1221- MOVE SVA-SIGLA-UF TO LD01-SIGLA-UF. */
            _.Move(REG_SVA1466B.SVA_SIGLA_UF, WORK_AREA.LD01.LD01_SIGLA_UF);

            /*" -1222- MOVE SVA-CEP TO LD01-CEP. */
            _.Move(REG_SVA1466B.SVA_CEP, WORK_AREA.LD01.LD01_CEP);

            /*" -1223- MOVE SVA-DDD TO LD01-DDD. */
            _.Move(REG_SVA1466B.SVA_DDD, WORK_AREA.LD01.LD01_DDD);

            /*" -1224- MOVE SVA-TELEFONE TO LD01-TELEFONE. */
            _.Move(REG_SVA1466B.SVA_TELEFONE, WORK_AREA.LD01.LD01_TELEFONE);

            /*" -1225- MOVE SVA-CDESCNEG TO LD01-COD-ESCNEG */
            _.Move(REG_SVA1466B.SVA_CDESCNEG, WORK_AREA.LD01.LD01_COD_ESCNEG);

            /*" -1227- MOVE V0PROD-NOMPRODU TO LD01-NOMPRODU LD02-NOMPRODU */
            _.Move(V0PROD_NOMPRODU, WORK_AREA.LD01.LD01_NOMPRODU, WORK_AREA.LD02.LD02_DESC_DOC.LD02_NOMPRODU);

            /*" -1229- MOVE SVA-CDFONTE TO LD01-CODFILIAL LD02-CODFILIAL */
            _.Move(REG_SVA1466B.SVA_CDFONTE, WORK_AREA.LD01.LD01_CODFILIAL, WORK_AREA.LD02.LD02_CODFILIAL);

            /*" -1230- MOVE TBFT-NMFONTE(SVA-CDFONTE) TO LD01-NOMFILIAL */
            _.Move(TABELA_FONTES1.TAB_FTE1[REG_SVA1466B.SVA_CDFONTE].TBFT_NMFONTE, WORK_AREA.LD01.LD01_NOMFILIAL);

            /*" -1232- MOVE SVA-NRCERTIF TO LD01-NRCERTIF LD02-NRCERTIF */
            _.Move(REG_SVA1466B.SVA_NRCERTIF, WORK_AREA.LD01.LD01_NRCERTIF, WORK_AREA.LD02.LD02_NRCERTIF);

            /*" -1233- MOVE SVA-CODUSU TO LD01-CODUSU */
            _.Move(REG_SVA1466B.SVA_CODUSU, WORK_AREA.LD01.LD01_CODUSU);

            /*" -1234- MOVE SVA-NRMATRVEN TO LD01-NRMATRVEN */
            _.Move(REG_SVA1466B.SVA_NRMATRVEN, WORK_AREA.LD01.LD01_NRMATRVEN);

            /*" -1235- MOVE SVA-DTQITBCO (1:4) TO LD01-DTQITBCO(7:4) */
            _.MoveAtPosition(REG_SVA1466B.SVA_DTQITBCO.Substring(1, 4), WORK_AREA.LD01.LD01_DTQITBCO, 7, 4);

            /*" -1236- MOVE '/' TO LD01-DTQITBCO(3:1) */
            _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DTQITBCO, 3, 1);

            /*" -1237- MOVE SVA-DTQITBCO (6:2) TO LD01-DTQITBCO(4:2) */
            _.MoveAtPosition(REG_SVA1466B.SVA_DTQITBCO.Substring(6, 2), WORK_AREA.LD01.LD01_DTQITBCO, 4, 2);

            /*" -1238- MOVE '/' TO LD01-DTQITBCO(6:1) */
            _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DTQITBCO, 6, 1);

            /*" -1239- MOVE SVA-DTQITBCO (9:2) TO LD01-DTQITBCO(1:2) */
            _.MoveAtPosition(REG_SVA1466B.SVA_DTQITBCO.Substring(9, 2), WORK_AREA.LD01.LD01_DTQITBCO, 1, 2);

            /*" -1241- MOVE SVA-AGECOBR TO LD01-AGECOBR LD02-AGECOBR */
            _.Move(REG_SVA1466B.SVA_AGECOBR, WORK_AREA.LD01.LD01_AGECOBR, WORK_AREA.LD02.LD02_AGECOBR);

            /*" -1242- MOVE SVA-VLPREMIO TO LD01-VLPREMIO */
            _.Move(REG_SVA1466B.SVA_VLPREMIO, WORK_AREA.LD01.LD01_VLPREMIO);

            /*" -1243- MOVE SVA-IMPSEGUR TO LD01-IMPSEGUR */
            _.Move(REG_SVA1466B.SVA_IMPSEGUR, WORK_AREA.LD01.LD01_IMPSEGUR);

            /*" -1245- MOVE SVA-QTDIAS TO LD01-QTDIAS */
            _.Move(REG_SVA1466B.SVA_QTDIAS, WORK_AREA.LD01.LD01_QTDIAS);

            /*" -1246- MOVE SVA-APOLICE TO LD01-APOLICE. */
            _.Move(REG_SVA1466B.SVA_APOLICE, WORK_AREA.LD01.LD01_APOLICE);

            /*" -1248- MOVE SVA-CODSUBES TO LD01-SUBGRUPO. */
            _.Move(REG_SVA1466B.SVA_CODSUBES, WORK_AREA.LD01.LD01_SUBGRUPO);

            /*" -1249- IF SVA-SITUACAO EQUAL '1' */

            if (REG_SVA1466B.SVA_SITUACAO == "1")
            {

                /*" -1251- MOVE 'EM CRITICA' TO LD01-SITUACAO */
                _.Move("EM CRITICA", WORK_AREA.LD01.LD01_SITUACAO);

                /*" -1253- PERFORM R3250-00-VERIFICA-PEP */

                R3250_00_VERIFICA_PEP_SECTION();

                /*" -1254- IF WS-CLIENTE-PEP EQUAL 'S' */

                if (WS_CLIENTE_PEP == "S")
                {

                    /*" -1256- MOVE 'CLIENTE PEP' TO LD01-SITUACAO */
                    _.Move("CLIENTE PEP", WORK_AREA.LD01.LD01_SITUACAO);

                    /*" -1257- END-IF */
                }


                /*" -1259- END-IF. */
            }


            /*" -1260- IF SVA-SITUACAO EQUAL 'E' */

            if (REG_SVA1466B.SVA_SITUACAO == "E")
            {

                /*" -1261- MOVE 'AGUARDANDO CRIVO' TO LD01-SITUACAO */
                _.Move("AGUARDANDO CRIVO", WORK_AREA.LD01.LD01_SITUACAO);

                /*" -1263- END-IF. */
            }


            /*" -1264- IF SVA-SITUACAO EQUAL '9' */

            if (REG_SVA1466B.SVA_SITUACAO == "9")
            {

                /*" -1266- MOVE 'AGUARDANDO PROPOSTA FISICA' TO LD01-SITUACAO */
                _.Move("AGUARDANDO PROPOSTA FISICA", WORK_AREA.LD01.LD01_SITUACAO);

                /*" -1268- END-IF. */
            }


            /*" -1270- MOVE SVA-DESC-ERRO TO LD01-DESCR-ERRO. */
            _.Move(REG_SVA1466B.SVA_DESC_ERRO, WORK_AREA.LD01.LD01_DESCR_ERRO);

            /*" -1271- WRITE REG-AVA1466B FROM LD01. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_AVA1466B);

            AVA1466B.Write(REG_AVA1466B.GetMoveValues().ToString());

            /*" -1273- ADD 1 TO AC-GRAVA-AVA1466B. */
            WORK_AREA.AC_GRAVA_AVA1466B.Value = WORK_AREA.AC_GRAVA_AVA1466B + 1;

            /*" -1274- WRITE REG-DVA1466B FROM LD02. */
            _.Move(WORK_AREA.LD02.GetMoveValues(), REG_DVA1466B);

            DVA1466B.Write(REG_DVA1466B.GetMoveValues().ToString());

            /*" -1274- ADD 1 TO AC-GRAVA-DVA1466B. */
            WORK_AREA.AC_GRAVA_DVA1466B.Value = WORK_AREA.AC_GRAVA_DVA1466B + 1;

            /*" -0- FLUXCONTROL_PERFORM R2200_90_LER */

            R2200_90_LER();

        }

        [StopWatch]
        /*" R2200-90-LER */
        private void R2200_90_LER(bool isPerform = false)
        {
            /*" -1278- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -1289- RETURN SVA1466B AT END */
            try
            {
                SVA1466B.Return(REG_SVA1466B, () =>
                {

                    /*" -1291- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                    /*" -1292- NOT AT END */
                }, () =>
                {

                    /*" -1293- ADD 1 TO AC-LIDOS-SORT END-RETURN. */
                    WORK_AREA.AC_LIDOS_SORT.Value = WORK_AREA.AC_LIDOS_SORT + 1;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-PRODUTO-SECTION */
        private void R2500_00_SELECT_PRODUTO_SECTION()
        {
            /*" -1304- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1311- PERFORM R2500_00_SELECT_PRODUTO_DB_SELECT_1 */

            R2500_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -1314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1315- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1316- MOVE 'PRODUTO INEXISTENTE' TO V0PROD-NOMPRODU */
                    _.Move("PRODUTO INEXISTENTE", V0PROD_NOMPRODU);

                    /*" -1317- ELSE */
                }
                else
                {


                    /*" -1318- DISPLAY 'R2500 - PROBLEMAS SELECT V0PRODUTOSVG' */
                    _.Display($"R2500 - PROBLEMAS SELECT V0PRODUTOSVG");

                    /*" -1319- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1319- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R2500_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -1311- EXEC SQL SELECT NOMPRODU INTO :V0PROD-NOMPRODU FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :WHOST-APOLICE AND CODSUBES = :WHOST-CODSUBES WITH UR END-EXEC. */

            var r2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
                WHOST_APOLICE = WHOST_APOLICE.ToString(),
            };

            var executed_1 = R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_NOMPRODU, V0PROD_NOMPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-SECTION */
        private void R3100_00_DECLARE_FONTES_SECTION()
        {
            /*" -1330- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1336- PERFORM R3100_00_DECLARE_FONTES_DB_DECLARE_1 */

            R3100_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -1339- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1340- DISPLAY 'R3100 - PROBLEMAS DECLARE CFONTES' */
                _.Display($"R3100 - PROBLEMAS DECLARE CFONTES");

                /*" -1341- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1343- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1343- PERFORM R3100_00_DECLARE_FONTES_DB_OPEN_1 */

            R3100_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -1346- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1347- DISPLAY 'R3100 - PROBLEMAS OPEN CFONTES' */
                _.Display($"R3100 - PROBLEMAS OPEN CFONTES");

                /*" -1348- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1348- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R3100_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -1343- EXEC SQL OPEN CFONTES END-EXEC. */

            CFONTES.Open();

        }

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-DB-DECLARE-1 */
        public void R3200_00_DECLARE_ESCNEG_DB_DECLARE_1()
        {
            /*" -1434- EXEC SQL DECLARE CESCNEG CURSOR FOR SELECT COD_ESCNEG, REGIAO_ESCNEG, COD_FONTE FROM SEGUROS.V0ESCNEG ORDER BY COD_ESCNEG WITH UR END-EXEC. */
            CESCNEG = new VA1466B_CESCNEG(false);
            string GetQuery_CESCNEG()
            {
                var query = @$"SELECT COD_ESCNEG
							, 
							REGIAO_ESCNEG
							, 
							COD_FONTE 
							FROM SEGUROS.V0ESCNEG 
							ORDER BY COD_ESCNEG";

                return query;
            }
            CESCNEG.GetQueryEvent += GetQuery_CESCNEG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-SECTION */
        private void R3110_00_FETCH_FONTES_SECTION()
        {
            /*" -1359- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1362- PERFORM R3110_00_FETCH_FONTES_DB_FETCH_1 */

            R3110_00_FETCH_FONTES_DB_FETCH_1();

            /*" -1365- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1366- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1367- MOVE 'S' TO WFIM-FONTES */
                    _.Move("S", WORK_AREA.WFIM_FONTES);

                    /*" -1367- PERFORM R3110_00_FETCH_FONTES_DB_CLOSE_1 */

                    R3110_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -1369- ELSE */
                }
                else
                {


                    /*" -1370- DISPLAY 'R3110 - PROBLEMAS FETCH CFONTES' */
                    _.Display($"R3110 - PROBLEMAS FETCH CFONTES");

                    /*" -1371- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1371- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-FETCH-1 */
        public void R3110_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -1362- EXEC SQL FETCH CFONTES INTO :V0FONT-CODFTE, :V0FONT-NOMEFTE END-EXEC. */

            if (CFONTES.Fetch())
            {
                _.Move(CFONTES.V0FONT_CODFTE, V0FONT_CODFTE);
                _.Move(CFONTES.V0FONT_NOMEFTE, V0FONT_NOMEFTE);
            }

        }

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-CLOSE-1 */
        public void R3110_00_FETCH_FONTES_DB_CLOSE_1()
        {
            /*" -1367- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3120-00-CARREGA-FONTES-SECTION */
        private void R3120_00_CARREGA_FONTES_SECTION()
        {
            /*" -1382- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1383- IF V0FONT-CODFTE LESS 100 */

            if (V0FONT_CODFTE < 100)
            {

                /*" -1386- MOVE V0FONT-NOMEFTE TO TBFT-NMFONTE (V0FONT-CODFTE). */
                _.Move(V0FONT_NOMEFTE, TABELA_FONTES1.TAB_FTE1[V0FONT_CODFTE].TBFT_NMFONTE);
            }


            /*" -1386- PERFORM R3110-00-FETCH-FONTES. */

            R3110_00_FETCH_FONTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3190-00-SELECT-ESCNEG-SECTION */
        private void R3190_00_SELECT_ESCNEG_SECTION()
        {
            /*" -1397- MOVE '319' TO WNR-EXEC-SQL. */
            _.Move("319", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1407- PERFORM R3190_00_SELECT_ESCNEG_DB_SELECT_1 */

            R3190_00_SELECT_ESCNEG_DB_SELECT_1();

            /*" -1410- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1411- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1413- MOVE 'E.N. NAO CADASTRADO' TO V0ESCN-NOMEESC */
                    _.Move("E.N. NAO CADASTRADO", V0ESCN_NOMEESC);

                    /*" -1414- ELSE */
                }
                else
                {


                    /*" -1415- DISPLAY 'R3190 - PROBLEMAS SELECT V0ESCNEG' */
                    _.Display($"R3190 - PROBLEMAS SELECT V0ESCNEG");

                    /*" -1416- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1416- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3190-00-SELECT-ESCNEG-DB-SELECT-1 */
        public void R3190_00_SELECT_ESCNEG_DB_SELECT_1()
        {
            /*" -1407- EXEC SQL SELECT COD_ESCNEG, REGIAO_ESCNEG, COD_FONTE INTO :V0ESCN-CODESC, :V0ESCN-NOMEESC, :V0ESCN-FONTE FROM SEGUROS.V0ESCNEG WHERE COD_ESCNEG = :WHOST-COD-ESCNEG WITH UR END-EXEC. */

            var r3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1 = new R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1()
            {
                WHOST_COD_ESCNEG = WHOST_COD_ESCNEG.ToString(),
            };

            var executed_1 = R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1.Execute(r3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ESCN_CODESC, V0ESCN_CODESC);
                _.Move(executed_1.V0ESCN_NOMEESC, V0ESCN_NOMEESC);
                _.Move(executed_1.V0ESCN_FONTE, V0ESCN_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3190_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-SECTION */
        private void R3200_00_DECLARE_ESCNEG_SECTION()
        {
            /*" -1427- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1434- PERFORM R3200_00_DECLARE_ESCNEG_DB_DECLARE_1 */

            R3200_00_DECLARE_ESCNEG_DB_DECLARE_1();

            /*" -1437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1438- DISPLAY 'R3200 - PROBLEMAS DECLARE CESCNEG' */
                _.Display($"R3200 - PROBLEMAS DECLARE CESCNEG");

                /*" -1439- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1441- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1441- PERFORM R3200_00_DECLARE_ESCNEG_DB_OPEN_1 */

            R3200_00_DECLARE_ESCNEG_DB_OPEN_1();

            /*" -1444- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1445- DISPLAY 'R3200 - PROBLEMAS OPEN CESCNEG' */
                _.Display($"R3200 - PROBLEMAS OPEN CESCNEG");

                /*" -1446- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1446- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-DB-OPEN-1 */
        public void R3200_00_DECLARE_ESCNEG_DB_OPEN_1()
        {
            /*" -1441- EXEC SQL OPEN CESCNEG END-EXEC. */

            CESCNEG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-SECTION */
        private void R3210_00_FETCH_ESCNEG_SECTION()
        {
            /*" -1457- MOVE '321' TO WNR-EXEC-SQL. */
            _.Move("321", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1461- PERFORM R3210_00_FETCH_ESCNEG_DB_FETCH_1 */

            R3210_00_FETCH_ESCNEG_DB_FETCH_1();

            /*" -1464- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1465- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1466- MOVE 'S' TO WFIM-ESCNEG */
                    _.Move("S", WORK_AREA.WFIM_ESCNEG);

                    /*" -1466- PERFORM R3210_00_FETCH_ESCNEG_DB_CLOSE_1 */

                    R3210_00_FETCH_ESCNEG_DB_CLOSE_1();

                    /*" -1468- ELSE */
                }
                else
                {


                    /*" -1469- DISPLAY 'R3210 - PROBLEMAS FETCH CFONTES' */
                    _.Display($"R3210 - PROBLEMAS FETCH CFONTES");

                    /*" -1470- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1470- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-FETCH-1 */
        public void R3210_00_FETCH_ESCNEG_DB_FETCH_1()
        {
            /*" -1461- EXEC SQL FETCH CESCNEG INTO :V0ESCN-CODESC, :V0ESCN-NOMEESC, :V0ESCN-FONTE END-EXEC. */

            if (CESCNEG.Fetch())
            {
                _.Move(CESCNEG.V0ESCN_CODESC, V0ESCN_CODESC);
                _.Move(CESCNEG.V0ESCN_NOMEESC, V0ESCN_NOMEESC);
                _.Move(CESCNEG.V0ESCN_FONTE, V0ESCN_FONTE);
            }

        }

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-CLOSE-1 */
        public void R3210_00_FETCH_ESCNEG_DB_CLOSE_1()
        {
            /*" -1466- EXEC SQL CLOSE CESCNEG END-EXEC */

            CESCNEG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-VERIFICA-PEP-SECTION */
        private void R3250_00_VERIFICA_PEP_SECTION()
        {
            /*" -1481- MOVE '325' TO WNR-EXEC-SQL. */
            _.Move("325", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1482- MOVE 'N' TO WS-CLIENTE-PEP */
            _.Move("N", WS_CLIENTE_PEP);

            /*" -1484- MOVE SVA-CGCCPF TO GE637-NUM-CPF-CNPJ */
            _.Move(REG_SVA1466B.SVA_CGCCPF, GE637.DCLGE_PESSOA_PEPS.GE637_NUM_CPF_CNPJ);

            /*" -1492- PERFORM R3250_00_VERIFICA_PEP_DB_SELECT_1 */

            R3250_00_VERIFICA_PEP_DB_SELECT_1();

            /*" -1495- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -1496- DISPLAY 'R3250 - PROBLEMAS SELECT GE_PESSOA_PEPS' */
                _.Display($"R3250 - PROBLEMAS SELECT GE_PESSOA_PEPS");

                /*" -1497- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1498- DISPLAY 'NUM-CPF-CNPJ - ' SVA-CGCCPF */
                _.Display($"NUM-CPF-CNPJ - {REG_SVA1466B.SVA_CGCCPF}");

                /*" -1499- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1500- END-IF */
            }


            /*" -1500- . */

        }

        [StopWatch]
        /*" R3250-00-VERIFICA-PEP-DB-SELECT-1 */
        public void R3250_00_VERIFICA_PEP_DB_SELECT_1()
        {
            /*" -1492- EXEC SQL SELECT 'S' INTO :WS-CLIENTE-PEP FROM SEGUROS.GE_PESSOA_PEPS GE637 WHERE GE637.NUM_CPF_CNPJ = :GE637-NUM-CPF-CNPJ AND GE637.DTA_FIM_VIG IS NULL FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r3250_00_VERIFICA_PEP_DB_SELECT_1_Query1 = new R3250_00_VERIFICA_PEP_DB_SELECT_1_Query1()
            {
                GE637_NUM_CPF_CNPJ = GE637.DCLGE_PESSOA_PEPS.GE637_NUM_CPF_CNPJ.ToString(),
            };

            var executed_1 = R3250_00_VERIFICA_PEP_DB_SELECT_1_Query1.Execute(r3250_00_VERIFICA_PEP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CLIENTE_PEP, WS_CLIENTE_PEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" DB100-ACESSA-RCAPS-TITULO-SECTION */
        private void DB100_ACESSA_RCAPS_TITULO_SECTION()
        {
            /*" -1509- MOVE 'B100' TO WNR-EXEC-SQL */
            _.Move("B100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1511- MOVE WHOST-NUMTIT TO RCAPS-NUM-TITULO */
            _.Move(WHOST_NUMTIT, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -1519- PERFORM DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1 */

            DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1();

            /*" -1521- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -1522- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -1523- DISPLAY 'DB100 - ERRO NO SELECT SEGUROS.RCAPS.' */
                _.Display($"DB100 - ERRO NO SELECT SEGUROS.RCAPS.");

                /*" -1525- DISPLAY ' SQLCODE=' WSQLCODE ' NUM_TITULO=' WHOST-NUMTIT */

                $" SQLCODE={WORK_AREA.WABEND.WSQLCODE} NUM_TITULO={WHOST_NUMTIT}"
                .Display();

                /*" -1526- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1527- END-IF */
            }


            /*" -1529- . */

        }

        [StopWatch]
        /*" DB100-ACESSA-RCAPS-TITULO-DB-SELECT-1 */
        public void DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1()
        {
            /*" -1519- EXEC SQL SELECT COD_FONTE , NUM_RCAP INTO :RCAPS-COD-FONTE , :RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO = :RCAPS-NUM-TITULO WITH UR END-EXEC */

            var dB100_ACESSA_RCAPS_TITULO_DB_SELECT_1_Query1 = new DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1_Query1.Execute(dB100_ACESSA_RCAPS_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }

        [StopWatch]
        /*" DB200-ACESSA-RCAPS-CERTIFICADO-SECTION */
        private void DB200_ACESSA_RCAPS_CERTIFICADO_SECTION()
        {
            /*" -1535- MOVE 'B200' TO WNR-EXEC-SQL */
            _.Move("B200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1537- MOVE WHOST-NUMTIT TO RCAPS-NUM-CERTIFICADO */
            _.Move(WHOST_NUMTIT, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -1545- PERFORM DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1 */

            DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1();

            /*" -1548- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -1549- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -1550- DISPLAY 'DB200 - ERRO NO SELECT SEGUROS.RCAPS.' */
                _.Display($"DB200 - ERRO NO SELECT SEGUROS.RCAPS.");

                /*" -1552- DISPLAY ' SQLCODE=' WSQLCODE ' NUM-CERTIFICADO=' WHOST-NUMTIT */

                $" SQLCODE={WORK_AREA.WABEND.WSQLCODE} NUM-CERTIFICADO={WHOST_NUMTIT}"
                .Display();

                /*" -1553- DISPLAY 'SQLCODE - ' WSQLCODE */
                _.Display($"SQLCODE - {WORK_AREA.WABEND.WSQLCODE}");

                /*" -1554- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1555- END-IF */
            }


            /*" -1555- . */

        }

        [StopWatch]
        /*" DB200-ACESSA-RCAPS-CERTIFICADO-DB-SELECT-1 */
        public void DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1()
        {
            /*" -1545- EXEC SQL SELECT COD_FONTE , NUM_RCAP INTO :RCAPS-COD-FONTE , :RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO WITH UR END-EXEC */

            var dB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1 = new DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1.Execute(dB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }

        [StopWatch]
        /*" DB300-ACESSA-RCAP-COMPLEMENTAR-SECTION */
        private void DB300_ACESSA_RCAP_COMPLEMENTAR_SECTION()
        {
            /*" -1563- MOVE 'B300' TO WNR-EXEC-SQL */
            _.Move("B300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1564- MOVE RCAPS-COD-FONTE TO RCAPCOMP-COD-FONTE */
            _.Move(RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);

            /*" -1566- MOVE RCAPS-NUM-RCAP TO RCAPCOMP-NUM-RCAP */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);

            /*" -1575- PERFORM DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1 */

            DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1();

            /*" -1578- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -1579- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -1580- DISPLAY 'DB300-ERRO NO SELECT SEGUROS.RCAP_COMPLEMENTAR.' */
                _.Display($"DB300-ERRO NO SELECT SEGUROS.RCAP_COMPLEMENTAR.");

                /*" -1584- DISPLAY ' SQLCODE=' WSQLCODE ' CERTIFICADO=' WHOST-NUMTIT ' COD_FONTE=' RCAPCOMP-COD-FONTE ' NUM_RCAP=' RCAPCOMP-NUM-RCAP */

                $" SQLCODE={WORK_AREA.WABEND.WSQLCODE} CERTIFICADO={WHOST_NUMTIT} COD_FONTE={RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE} NUM_RCAP={RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}"
                .Display();

                /*" -1585- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1586- END-IF */
            }


            /*" -1586- . */

        }

        [StopWatch]
        /*" DB300-ACESSA-RCAP-COMPLEMENTAR-DB-SELECT-1 */
        public void DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1()
        {
            /*" -1575- EXEC SQL SELECT DATA_RCAP INTO :RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :RCAPCOMP-COD-FONTE AND NUM_RCAP = :RCAPCOMP-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND SIT_REGISTRO = '0' WITH UR END-EXEC */

            var dB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1 = new DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            var executed_1 = DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1.Execute(dB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1597- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1598- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1599- DISPLAY '*   VA1466B - GERA RELATORIO MULTPREMIADO  *' */
            _.Display($"*   VA1466B - GERA RELATORIO MULTPREMIADO  *");

            /*" -1600- DISPLAY '*   -------   -------------- ------------  *' */
            _.Display($"*   -------   -------------- ------------  *");

            /*" -1601- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1602- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -1603- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -1604- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1604- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1617- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1619- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1620- IF SQLERRMC NOT = SPACES */

            if (!DB.SQLERRMC.IsEmpty())
            {

                /*" -1621- DISPLAY 'SQLERRMC=' SQLERRMC */
                _.Display($"SQLERRMC={DB.SQLERRMC}");

                /*" -1623- END-IF */
            }


            /*" -1623- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1625- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1629- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1629- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}