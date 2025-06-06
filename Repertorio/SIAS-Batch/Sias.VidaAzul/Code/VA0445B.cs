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
using Sias.VidaAzul.DB2.VA0445B;

namespace Code
{
    public class VA0445B
    {
        public bool IsCall { get; set; }

        public VA0445B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *     GERA ARQUIVO ANALITICO DE PROPOSTAS EM CRITICA SO COM AS   *      */
        /*"      *     CRITICAS CADASTRAIS.                                       *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *     01     *  07/12/15  *   LUIGI C.   *      IMPLANTACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                        ATUALIZACOES                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  * VERSAO 09 - DEMANDA 402.982                                    *      */
        /*"      *           - SUBSTITUIR CONSULTA DA TABELA ERROS_PROP_VIDAZUL   *      */
        /*"      *             PELA NA NOVA TABELA VG_CRITICA_PROPOSTA            *      */
        /*"      *                                                                *      */
        /*"      * EM 14/02/2023 - ELIERMES OLIVEIRA                              *      */
        /*"      *                                        PROCURE POR V.09        *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _AVA0445B { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis AVA0445B
        {
            get
            {
                _.Move(REG_AVA0445B, _AVA0445B); VarBasis.RedefinePassValue(REG_AVA0445B, _AVA0445B, REG_AVA0445B); return _AVA0445B;
            }
        }
        public FileBasis _DVA0445B { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis DVA0445B
        {
            get
            {
                _.Move(REG_DVA0445B, _DVA0445B); VarBasis.RedefinePassValue(REG_DVA0445B, _DVA0445B, REG_DVA0445B); return _DVA0445B;
            }
        }
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
        public SortBasis<VA0445B_REG_SVA0445B> SVA0445B { get; set; } = new SortBasis<VA0445B_REG_SVA0445B>(new VA0445B_REG_SVA0445B());
        /*"01            REG-AVA0445B        PIC X(500).*/
        public StringBasis REG_AVA0445B { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"01            REG-DVA0445B        PIC X(200).*/
        public StringBasis REG_DVA0445B { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01            RECORD-DSAIDA       PIC X(200).*/
        public StringBasis RECORD_DSAIDA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01            RECORD-SSAIDA       PIC X(250).*/
        public StringBasis RECORD_SSAIDA { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01            REG-SVA0445B.*/
        public VA0445B_REG_SVA0445B REG_SVA0445B { get; set; } = new VA0445B_REG_SVA0445B();
        public class VA0445B_REG_SVA0445B : VarBasis
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
            /*"    05        SVA-NOMPRODU        PIC  X(30).*/
            public StringBasis SVA_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05        SVA-CODPRODU        PIC  9(04).*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77            WHOST-SITUACAO      PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
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
        /*"77            WS-DESCR-ERRO       PIC  X(040).*/
        public StringBasis WS_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            WS-COD-ERRO         PIC S9(04) COMP.*/
        public IntBasis WS_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WS-ERRO-FATAL       PIC  X(01) VALUE ' '.*/
        public StringBasis WS_ERRO_FATAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
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
        /*"77            ERROSP-DESCR-ERRO  PIC X(40).*/
        public StringBasis ERROSP_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            CONV-NUM-SICOB     PIC S9(15)    COMP-3.*/
        public IntBasis CONV_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            CONV-NUMTIT        PIC S9(13)    COMP-3.*/
        public IntBasis CONV_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0CLIE-NOME-RAZAO  PIC  X(40).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0CLIE-CGCCPF      PIC S9(15)    COMP-3.*/
        public IntBasis V0CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77             V0ENDE-ENDERECO     PIC  X(040).*/
        public StringBasis V0ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77             V0ENDE-BAIRRO       PIC  X(020).*/
        public StringBasis V0ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77             V0ENDE-CIDADE       PIC  X(020).*/
        public StringBasis V0ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77             V0ENDE-SIGLA-UF     PIC  X(002).*/
        public StringBasis V0ENDE_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77             V0ENDE-CEP          PIC S9(009) COMP.*/
        public IntBasis V0ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77             V0ENDE-DDD          PIC S9(004) COMP.*/
        public IntBasis V0ENDE_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77             V0ENDE-TELEFONE     PIC S9(009) COMP.*/
        public IntBasis V0ENDE_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0MALHA-CDESCNEG     PIC S9(04)    COMP.*/
        public IntBasis V0MALHA_CDESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0MALHA-CDFONTE      PIC S9(04)    COMP.*/
        public IntBasis V0MALHA_CDFONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WORK-AREA.*/
        public VA0445B_WORK_AREA WORK_AREA { get; set; } = new VA0445B_WORK_AREA();
        public class VA0445B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public VA0445B_DATA_SQL DATA_SQL { get; set; } = new VA0445B_DATA_SQL();
            public class VA0445B_DATA_SQL : VarBasis
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
            /*"    05        AC-ERRO-DADOS       PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ERRO_DADOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ERRO-SISTEMA     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ERRO_SISTEMA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        WS-COUNT            PIC S9(004) COMP VALUE +0.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WABEND.*/
            public VA0445B_WABEND WABEND { get; set; } = new VA0445B_WABEND();
            public class VA0445B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE              ' VA0445B'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0445B");
                /*"      10      FILLER              PIC  X(026) VALUE              ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE              ' *** SQLCODE '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        LD00.*/
            }
            public VA0445B_LD00 LD00 { get; set; } = new VA0445B_LD00();
            public class VA0445B_LD00 : VarBasis
            {
                /*"      10      FILLER              PIC X(07)   VALUE 'VA0445B'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"VA0445B");
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
            public VA0445B_LD00_1 LD00_1 { get; set; } = new VA0445B_LD00_1();
            public class VA0445B_LD00_1 : VarBasis
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
            public VA0445B_LD01 LD01 { get; set; } = new VA0445B_LD01();
            public class VA0445B_LD01 : VarBasis
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
            public VA0445B_LD02 LD02 { get; set; } = new VA0445B_LD02();
            public class VA0445B_LD02 : VarBasis
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
                public VA0445B_LD02_DESC_DOC LD02_DESC_DOC { get; set; } = new VA0445B_LD02_DESC_DOC();
                public class VA0445B_LD02_DESC_DOC : VarBasis
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
            public VA0445B_HD_REG_DSAIDA HD_REG_DSAIDA { get; set; } = new VA0445B_HD_REG_DSAIDA();
            public class VA0445B_HD_REG_DSAIDA : VarBasis
            {
                /*"      10    HD-COD-PRO-DSAIDA   PIC  X(008)   VALUE 'VA0445B'.*/
                public StringBasis HD_COD_PRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0445B");
                /*"      10    HD-DES-REL-DSAIDA   PIC  X(050)   VALUE      'RELATORIO DE ERROS DE DADOS'.*/
                public StringBasis HD_DES_REL_DSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE DADOS");
                /*"      10    HD-DTA-SIS-DSAIDA   PIC  X(010)   VALUE SPACES.*/
                public StringBasis HD_DTA_SIS_DSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05      CB-REG-DSAIDA.*/
            }
            public VA0445B_CB_REG_DSAIDA CB_REG_DSAIDA { get; set; } = new VA0445B_CB_REG_DSAIDA();
            public class VA0445B_CB_REG_DSAIDA : VarBasis
            {
                /*"      10    FILLER              PIC  X(045)   VALUE      'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
                /*"      10    FILLER              PIC  X(042)   VALUE      'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
                /*"      10    FILLER              PIC  X(033)   VALUE      'DETALHAMENTO DO PROBLEMA OCORRIDO'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO");
                /*"    05      LD-REG-DSAIDA.*/
            }
            public VA0445B_LD_REG_DSAIDA LD_REG_DSAIDA { get; set; } = new VA0445B_LD_REG_DSAIDA();
            public class VA0445B_LD_REG_DSAIDA : VarBasis
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
            public VA0445B_HD_REG_SSAIDA HD_REG_SSAIDA { get; set; } = new VA0445B_HD_REG_SSAIDA();
            public class VA0445B_HD_REG_SSAIDA : VarBasis
            {
                /*"      10    HD-COD-PRO-SSAIDA   PIC  X(008)   VALUE 'VA0445B'.*/
                public StringBasis HD_COD_PRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0445B");
                /*"      10    HD-DES-REL-SSAIDA   PIC  X(050)   VALUE      'RELATORIO DE ERROS DE SISTEMAS'.*/
                public StringBasis HD_DES_REL_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE SISTEMAS");
                /*"      10    HD-DTA-SIS-SSAIDA   PIC  X(010)   VALUE SPACES.*/
                public StringBasis HD_DTA_SIS_SSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05      CB-REG-SSAIDA.*/
            }
            public VA0445B_CB_REG_SSAIDA CB_REG_SSAIDA { get; set; } = new VA0445B_CB_REG_SSAIDA();
            public class VA0445B_CB_REG_SSAIDA : VarBasis
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
            public VA0445B_LD_REG_SSAIDA LD_REG_SSAIDA { get; set; } = new VA0445B_LD_REG_SSAIDA();
            public class VA0445B_LD_REG_SSAIDA : VarBasis
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
                /*"      10    LD-NOM-PROG-SSAIDA        PIC X(008) VALUE 'VA0445B'*/
                public StringBasis LD_NOM_PROG_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0445B");
                /*"01            TABELA-FONTES1.*/
            }
        }
        public VA0445B_TABELA_FONTES1 TABELA_FONTES1 { get; set; } = new VA0445B_TABELA_FONTES1();
        public class VA0445B_TABELA_FONTES1 : VarBasis
        {
            /*"      10      TAB-FTE1            OCCURS 99 TIMES.*/
            public ListBasis<VA0445B_TAB_FTE1> TAB_FTE1 { get; set; } = new ListBasis<VA0445B_TAB_FTE1>(99);
            public class VA0445B_TAB_FTE1 : VarBasis
            {
                /*"        15    TBFT-NMFONTE        PIC  X(040).*/
                public StringBasis TBFT_NMFONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"01            TABELA-FONTES.*/
            }
        }
        public VA0445B_TABELA_FONTES TABELA_FONTES { get; set; } = new VA0445B_TABELA_FONTES();
        public class VA0445B_TABELA_FONTES : VarBasis
        {
            /*"      10      TAB-FTE             OCCURS 99 TIMES.*/
            public ListBasis<VA0445B_TAB_FTE> TAB_FTE { get; set; } = new ListBasis<VA0445B_TAB_FTE>(99);
            public class VA0445B_TAB_FTE : VarBasis
            {
                /*"        15    TBFT-QT-ESTOQ        PIC  9(006).*/
                public IntBasis TBFT_QT_ESTOQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        15    TBFT-VL-ESTOQ        PIC  9(013)V99.*/
                public DoubleBasis TBFT_VL_ESTOQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TABELA-ESCNEG.*/
            }
        }
        public VA0445B_TABELA_ESCNEG TABELA_ESCNEG { get; set; } = new VA0445B_TABELA_ESCNEG();
        public class VA0445B_TABELA_ESCNEG : VarBasis
        {
            /*"      10      TAB-EN              OCCURS 200 TIMES                                  INDEXED BY I01.*/
            public ListBasis<VA0445B_TAB_EN> TAB_EN { get; set; } = new ListBasis<VA0445B_TAB_EN>(200);
            public class VA0445B_TAB_EN : VarBasis
            {
                /*"        15    TBEN-CDFONTE        PIC  9(002).*/
                public IntBasis TBEN_CDFONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        15    TBEN-CDESCNEG       PIC  9(004).*/
                public IntBasis TBEN_CDESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        15    TBEN-NMESCNEG       PIC  X(030).*/
                public StringBasis TBEN_NMESCNEG { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"        15    TBEN-QT-ESTOQ        PIC  9(006).*/
                public IntBasis TBEN_QT_ESTOQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        15    TBEN-VL-ESTOQ        PIC  9(013)V99.*/
                public DoubleBasis TBEN_VL_ESTOQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            WZEROS              PIC S9(005) VALUE +0 COMP-3.*/
            }
        }
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));


        public VA0445B_TCOMIS TCOMIS { get; set; } = new VA0445B_TCOMIS();
        public VA0445B_CERROSP CERROSP { get; set; } = new VA0445B_CERROSP();
        public VA0445B_CFONTES CFONTES { get; set; } = new VA0445B_CFONTES();
        public VA0445B_CESCNEG CESCNEG { get; set; } = new VA0445B_CESCNEG();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVA0445B_FILE_NAME_P, string AVA0445B_FILE_NAME_P, string DVA0445B_FILE_NAME_P, string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVA0445B.SetFile(SVA0445B_FILE_NAME_P);
                AVA0445B.SetFile(AVA0445B_FILE_NAME_P);
                DVA0445B.SetFile(DVA0445B_FILE_NAME_P);
                DSAIDA.SetFile(DSAIDA_FILE_NAME_P);
                SSAIDA.SetFile(SSAIDA_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -525- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -528- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -531- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -532- PERFORM R0000-00-PRINCIPAL */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -538- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -539- DISPLAY '          PROGRAMA EM EXECUCAO VA0445B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO VA0445B          ");

            /*" -540- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -542- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -543- DISPLAY 'VERSAO V.02: ' FUNCTION WHEN-COMPILED ' - 402.982' */

            $"VERSAO V.02: FUNCTION{_.WhenCompiled()} - 402.982"
            .Display();

            /*" -544- DISPLAY ' ' */
            _.Display($" ");

            /*" -551- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -552- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -553- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -554- DISPLAY ' ' */
            _.Display($" ");

            /*" -556- DISPLAY ' ' */
            _.Display($" ");

            /*" -558- OPEN OUTPUT DSAIDA SSAIDA. */
            DSAIDA.Open(RECORD_DSAIDA);
            SSAIDA.Open(RECORD_SSAIDA);

            /*" -562- MOVE ZEROS TO V0PROP-APOLICE V0PROP-CODSUBES V0PROP-NRCERTIF V0PROP-CODPRODU. */
            _.Move(0, V0PROP_APOLICE, V0PROP_CODSUBES, V0PROP_NRCERTIF, V0PROP_CODPRODU);

            /*" -565- MOVE SPACES TO V0PROD-NOMPRODU V0PROP-DTPROXVEN. */
            _.Move("", V0PROD_NOMPRODU, V0PROP_DTPROXVEN);

            /*" -567- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -571- INITIALIZE TABELA-FONTES TABELA-ESCNEG LD01. */
            _.Initialize(
                TABELA_FONTES
                , TABELA_ESCNEG
                , WORK_AREA.LD01
            );

            /*" -573- PERFORM R3100-00-DECLARE-FONTES. */

            R3100_00_DECLARE_FONTES_SECTION();

            /*" -575- PERFORM R3110-00-FETCH-FONTES. */

            R3110_00_FETCH_FONTES_SECTION();

            /*" -576- IF WFIM-FONTES NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_FONTES.IsEmpty())
            {

                /*" -577- DISPLAY '0000 - PROBLEMA NO FETCH DA FONTES      ' */
                _.Display($"0000 - PROBLEMA NO FETCH DA FONTES      ");

                /*" -578- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -580- END-IF. */
            }


            /*" -583- PERFORM R3120-00-CARREGA-FONTES UNTIL WFIM-FONTES EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_FONTES == "S"))
            {

                R3120_00_CARREGA_FONTES_SECTION();
            }

            /*" -585- PERFORM R3200-00-DECLARE-ESCNEG. */

            R3200_00_DECLARE_ESCNEG_SECTION();

            /*" -587- PERFORM R3210-00-FETCH-ESCNEG. */

            R3210_00_FETCH_ESCNEG_SECTION();

            /*" -588- IF WFIM-ESCNEG NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_ESCNEG.IsEmpty())
            {

                /*" -589- DISPLAY '0000 - PROBLEMA NO FETCH DA ESCNEG      ' */
                _.Display($"0000 - PROBLEMA NO FETCH DA ESCNEG      ");

                /*" -590- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -592- END-IF. */
            }


            /*" -594- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -595- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -596- DISPLAY '*** PROBLEMAS NA V0SISTEMA' */
                _.Display($"*** PROBLEMAS NA V0SISTEMA");

                /*" -597- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -598- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -600- END-IF. */
            }


            /*" -602- PERFORM R0900-00-DECLARE-V0COMISICOB. */

            R0900_00_DECLARE_V0COMISICOB_SECTION();

            /*" -603- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -604- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -606- END-IF. */
            }


            /*" -608- PERFORM R0910-00-FETCH-V0COMISICOB. */

            R0910_00_FETCH_V0COMISICOB_SECTION();

            /*" -609- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -610- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -612- END-IF. */
            }


            /*" -613- IF WFIM-V0COMISICOB EQUAL 'S' */

            if (WORK_AREA.WFIM_V0COMISICOB == "S")
            {

                /*" -614- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -615- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -616- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -618- END-IF. */
            }


            /*" -620- MOVE +400000 TO SORT-FILE-SIZE. */
            _.Move(+400000, SORT_FILE_SIZE);

            /*" -626- SORT SVA0445B ON ASCENDING KEY SVA-APOLICE SVA-CODSUBES SVA-CDFONTE SVA-CDESCNEG SVA-NRCERTIF INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-GERA-ARQ THRU R0020-FIM. */
            SORT_RETURN.Value = SVA0445B.Sort("SVA-APOLICE,SVA-CODSUBES,SVA-CDFONTE,SVA-CDESCNEG,SVA-NRCERTIF", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_GERA_ARQ_SECTION());

            /*" -629- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -630- DISPLAY '*** VA0445B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VA0445B *** PROBLEMAS NO SORT ");

                /*" -631- DISPLAY '*** VA0445B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VA0445B *** SORT-RETURN = {SORT_RETURN}");

                /*" -632- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -633- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -635- END-IF. */
            }


            /*" -636- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -637- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -637- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -644- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -646- IF AC-ERRO-DADOS GREATER ZEROS AND AC-ERRO-SISTEMA GREATER ZEROS */

            if (WORK_AREA.AC_ERRO_DADOS > 00 && WORK_AREA.AC_ERRO_SISTEMA > 00)
            {

                /*" -647- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -648- ELSE */
            }
            else
            {


                /*" -649- IF AC-ERRO-SISTEMA GREATER ZEROS */

                if (WORK_AREA.AC_ERRO_SISTEMA > 00)
                {

                    /*" -650- MOVE 2 TO RETURN-CODE */
                    _.Move(2, RETURN_CODE);

                    /*" -651- ELSE */
                }
                else
                {


                    /*" -652- IF AC-ERRO-DADOS GREATER ZEROS */

                    if (WORK_AREA.AC_ERRO_DADOS > 00)
                    {

                        /*" -653- MOVE 1 TO RETURN-CODE */
                        _.Move(1, RETURN_CODE);

                        /*" -654- END-IF */
                    }


                    /*" -655- END-IF */
                }


                /*" -657- END-IF. */
            }


            /*" -660- CLOSE DSAIDA SSAIDA. */
            DSAIDA.Close();
            SSAIDA.Close();

            /*" -660- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -663- DISPLAY '  ' . */
            _.Display($"  ");

            /*" -664- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -665- DISPLAY '******** VA0445B - FIM DE PROCESSAMENTO ********' */
            _.Display($"******** VA0445B - FIM DE PROCESSAMENTO ********");

            /*" -666- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -667- DISPLAY 'LIDOS V0COMISICOBVA  =  ' AC-LIDOS. */
            _.Display($"LIDOS V0COMISICOBVA  =  {WORK_AREA.AC_LIDOS}");

            /*" -668- DISPLAY 'PROCESSADOS SORT     =  ' AC-LIDOS-SORT. */
            _.Display($"PROCESSADOS SORT     =  {WORK_AREA.AC_LIDOS_SORT}");

            /*" -669- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -670- DISPLAY '********** VA0445B - TERMINO NORMAL ************' */
            _.Display($"********** VA0445B - TERMINO NORMAL ************");

            /*" -672- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -672- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -685- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0COMISICOB EQUAL 'S' OR WS-ERRO-FATAL EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V0COMISICOB == "S" || WS_ERRO_FATAL == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -686- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -687- GO TO R0010-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/ //GOTO
                return;

                /*" -689- END-IF. */
            }


            /*" -689- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-GERA-ARQ-SECTION */
        private void R0020_00_GERA_ARQ_SECTION()
        {
            /*" -701- OPEN OUTPUT AVA0445B DVA0445B. */
            AVA0445B.Open(REG_AVA0445B);
            DVA0445B.Open(REG_DVA0445B);

            /*" -702- WRITE REG-AVA0445B FROM LD00. */
            _.Move(WORK_AREA.LD00.GetMoveValues(), REG_AVA0445B);

            AVA0445B.Write(REG_AVA0445B.GetMoveValues().ToString());

            /*" -704- WRITE REG-AVA0445B FROM LD00-1. */
            _.Move(WORK_AREA.LD00_1.GetMoveValues(), REG_AVA0445B);

            AVA0445B.Write(REG_AVA0445B.GetMoveValues().ToString());

            /*" -706- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -711- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' OR WS-ERRO-FATAL EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_SORT == "S" || WS_ERRO_FATAL == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -712- CLOSE AVA0445B DVA0445B. */
            AVA0445B.Close();
            DVA0445B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -723- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -731- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -734- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -735- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                /*" -736- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -738- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -740- MOVE 'ERRO NO ACESSO A TABELA DE SISTEMAS - VA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A TABELA DE SISTEMAS - VA", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -741- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA */
                _.Move(WORK_AREA.HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -742- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA */
                _.Move(WORK_AREA.CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -743- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA */
                _.Move(WORK_AREA.HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -744- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA */
                _.Move(WORK_AREA.CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -745- PERFORM R1400-00-GRAVA-REGISTROS */

                R1400_00_GRAVA_REGISTROS_SECTION();

                /*" -746- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -747- DISPLAY 'VA0445B - SISTEMA VA NAO ESTA CADASTRADO' */
                    _.Display($"VA0445B - SISTEMA VA NAO ESTA CADASTRADO");

                    /*" -748- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                    /*" -749- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -750- ELSE */
                }
                else
                {


                    /*" -751- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -752- END-IF */
                }


                /*" -754- END-IF. */
            }


            /*" -756- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -762- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -765- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -766- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                /*" -767- DISPLAY 'VA0445B - PROBLEMAS NO ACESSO A V0CONTROCNAB' */
                _.Display($"VA0445B - PROBLEMAS NO ACESSO A V0CONTROCNAB");

                /*" -768- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -770- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -772- MOVE 'ERRO NO ACESSO A TABELA DE SISTEMAS - VA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A TABELA DE SISTEMAS - VA", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -773- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA */
                _.Move(WORK_AREA.HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -774- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA */
                _.Move(WORK_AREA.CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -775- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA */
                _.Move(WORK_AREA.HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -776- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA */
                _.Move(WORK_AREA.CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -777- PERFORM R1400-00-GRAVA-REGISTROS */

                R1400_00_GRAVA_REGISTROS_SECTION();

                /*" -778- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -780- END-IF. */
            }


            /*" -782- MOVE V0CONT-DATCEF TO DATA-SQL. */
            _.Move(V0CONT_DATCEF, WORK_AREA.DATA_SQL);

            /*" -784- MOVE DATA-SQL TO WHOST-DTFINAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTFINAL);

            /*" -785- MOVE 01 TO DIA-SQL */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -786- MOVE DATA-SQL TO WHOST-DTINICIAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTINICIAL);

            /*" -787- MOVE V1SIST-DTHOJE(1:4) TO LD00-DATAINI(7:4) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(1, 4), WORK_AREA.LD00.LD00_DATAINI, 7, 4);

            /*" -788- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", WORK_AREA.LD00.LD00_DATAINI, 3, 1);

            /*" -789- MOVE V1SIST-DTHOJE(6:2) TO LD00-DATAINI(4:2) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(6, 2), WORK_AREA.LD00.LD00_DATAINI, 4, 2);

            /*" -790- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", WORK_AREA.LD00.LD00_DATAINI, 6, 1);

            /*" -792- MOVE V1SIST-DTHOJE(9:2) TO LD00-DATAINI(1:2). */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(9, 2), WORK_AREA.LD00.LD00_DATAINI, 1, 2);

            /*" -793- MOVE V1SIST-DTMOVABE(1:4) TO HD-DTA-SIS-DSAIDA(7:4). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(1, 4), WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 7, 4);

            /*" -794- MOVE V1SIST-DTMOVABE(6:2) TO HD-DTA-SIS-DSAIDA(4:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(6, 2), WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 4, 2);

            /*" -795- MOVE V1SIST-DTMOVABE(9:2) TO HD-DTA-SIS-DSAIDA(1:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(9, 2), WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 1, 2);

            /*" -797- MOVE '/' TO HD-DTA-SIS-DSAIDA(6:1). */
            _.MoveAtPosition("/", WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 6, 1);

            /*" -797- MOVE '/' TO HD-DTA-SIS-DSAIDA(3:1) */
            _.MoveAtPosition("/", WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 3, 1);

            /*" -799- MOVE HD-DTA-SIS-DSAIDA TO HD-DTA-SIS-SSAIDA. */
            _.Move(WORK_AREA.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, WORK_AREA.HD_REG_SSAIDA.HD_DTA_SIS_SSAIDA);

            /*" -800- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA. */
            _.Move(WORK_AREA.HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

            DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

            /*" -801- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA. */
            _.Move(WORK_AREA.CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

            DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

            /*" -802- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA. */
            _.Move(WORK_AREA.HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

            SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

            /*" -802- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA. */
            _.Move(WORK_AREA.CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

            SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -731- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTHOJE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

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
            /*" -762- EXEC SQL SELECT MAX(DATCEF) INTO :V0CONT-DATCEF FROM SEGUROS.V0CONTROCNAB WHERE NRCTACED = 63000300001004 WITH UR END-EXEC. */

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
            /*" -813- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -840- PERFORM R0900_00_DECLARE_V0COMISICOB_DB_DECLARE_1 */

            R0900_00_DECLARE_V0COMISICOB_DB_DECLARE_1();

            /*" -842- PERFORM R0900_00_DECLARE_V0COMISICOB_DB_OPEN_1 */

            R0900_00_DECLARE_V0COMISICOB_DB_OPEN_1();

            /*" -845- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -846- DISPLAY 'R0900 - PROBLEMAS DECLARE V0COMISICOB ..' */
                _.Display($"R0900 - PROBLEMAS DECLARE V0COMISICOB ..");

                /*" -847- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -848- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -850- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -852- MOVE 'R0900 - PROBLEMAS DECLARE V0COMISICOB.' TO LD-DES-ERRO-SSAIDA */
                _.Move("R0900 - PROBLEMAS DECLARE V0COMISICOB.", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -853- PERFORM R1400-00-GRAVA-REGISTROS */

                R1400_00_GRAVA_REGISTROS_SECTION();

                /*" -853- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0COMISICOB-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0COMISICOB_DB_DECLARE_1()
        {
            /*" -840- EXEC SQL DECLARE TCOMIS CURSOR FOR SELECT B.NUM_APOLICE, B.CODSUBES, B.NRCERTIF, B.AGECOBR, B.DTQITBCO, DAYS (:V1SIST-DTMOVABE) - DAYS (B.DTQITBCO), B.CODUSU, B.NRMATRVEN, B.CODCLIEN, B.OCOREND, C.IMPSEGUR, C.VLPREMIO, B.SITUACAO, B.DTPROXVEN, A.CODPRODU, A.NOMPRODU FROM SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0COBERPROPVA C WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.SITUACAO IN ( '1' , '9' , 'E' ) AND C.OCORHIST = B.OCORHIST AND C.NRCERTIF = B.NRCERTIF WITH UR END-EXEC. */
            TCOMIS = new VA0445B_TCOMIS(true);
            string GetQuery_TCOMIS()
            {
                var query = @$"SELECT B.NUM_APOLICE
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
							AND C.NRCERTIF = B.NRCERTIF";

                return query;
            }
            TCOMIS.GetQueryEvent += GetQuery_TCOMIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0COMISICOB-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0COMISICOB_DB_OPEN_1()
        {
            /*" -842- EXEC SQL OPEN TCOMIS END-EXEC. */

            TCOMIS.Open();

        }

        [StopWatch]
        /*" R2280-00-DECLARE-ERROSPROP-DB-DECLARE-1 */
        public void R2280_00_DECLARE_ERROSPROP_DB_DECLARE_1()
        {
            /*" -1497- EXEC SQL DECLARE CERROSP CURSOR FOR SELECT SUBSTR(VALUE(B.DES_ABREV_MSG_CRITICA, ' ' ),1,40) FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :WHOST-NRCERTIF AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' AND B.COD_AGRUPA_ERRO = 'CAD' WITH UR END-EXEC. */
            CERROSP = new VA0445B_CERROSP(true);
            string GetQuery_CERROSP()
            {
                var query = @$"SELECT SUBSTR(VALUE(B.DES_ABREV_MSG_CRITICA
							, ' ' )
							,1
							,40) 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, 
							SEGUROS.VG_DM_MSG_CRITICA B 
							WHERE A.NUM_CERTIFICADO = '{WHOST_NRCERTIF}' 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA 
							AND B.COD_TP_MSG_CRITICA <> '3' 
							AND B.COD_AGRUPA_ERRO = 'CAD'";

                return query;
            }
            CERROSP.GetQueryEvent += GetQuery_CERROSP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0COMISICOB-SECTION */
        private void R0910_00_FETCH_V0COMISICOB_SECTION()
        {
            /*" -864- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -882- PERFORM R0910_00_FETCH_V0COMISICOB_DB_FETCH_1 */

            R0910_00_FETCH_V0COMISICOB_DB_FETCH_1();

            /*" -885- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -886- MOVE 'S' TO WFIM-V0COMISICOB */
                _.Move("S", WORK_AREA.WFIM_V0COMISICOB);

                /*" -886- PERFORM R0910_00_FETCH_V0COMISICOB_DB_CLOSE_1 */

                R0910_00_FETCH_V0COMISICOB_DB_CLOSE_1();

                /*" -888- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -890- END-IF. */
            }


            /*" -890- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0COMISICOB-DB-FETCH-1 */
        public void R0910_00_FETCH_V0COMISICOB_DB_FETCH_1()
        {
            /*" -882- EXEC SQL FETCH TCOMIS INTO :V0PROP-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-AGECOBR, :V0PROP-DTQITBCO, :WHOST-QTDIAS, :V0PROP-CODUSU, :V0PROP-NRMATRVEN, :V0PROP-CODCLIEN, :V0PROP-OCOREND, :V0PROP-IMPSEGUR, :V0PROP-VLPREMIO, :V0PROP-SITUACAO, :V0PROP-DTPROXVEN, :V0PROP-CODPRODU, :V0PROP-NOMPRODU END-EXEC. */

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
            /*" -886- EXEC SQL CLOSE TCOMIS END-EXEC */

            TCOMIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -901- PERFORM R1010-00-SELECT-CONVERSAO. */

            R1010_00_SELECT_CONVERSAO_SECTION();

            /*" -902- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -903- MOVE CONV-NUM-SICOB TO WHOST-NUMTIT */
                _.Move(CONV_NUM_SICOB, WHOST_NUMTIT);

                /*" -904- ELSE */
            }
            else
            {


                /*" -905- MOVE V0PROP-NRCERTIF TO WHOST-NUMTIT */
                _.Move(V0PROP_NRCERTIF, WHOST_NUMTIT);

                /*" -907- END-IF. */
            }


            /*" -908- IF (WS-ERRO-FATAL EQUAL 'S' ) */

            if ((WS_ERRO_FATAL == "S"))
            {

                /*" -909- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -911- END-IF. */
            }


            /*" -913- PERFORM R1020-00-SELECT-V0RCAP. */

            R1020_00_SELECT_V0RCAP_SECTION();

            /*" -914- IF (WS-ERRO-FATAL EQUAL 'S' ) */

            if ((WS_ERRO_FATAL == "S"))
            {

                /*" -915- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -917- END-IF. */
            }


            /*" -918- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -919- IF V0PROP-APOLICE NOT EQUAL 107700000013 */

                if (V0PROP_APOLICE != 107700000013)
                {

                    /*" -920- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -921- END-IF */
                }


                /*" -923- END-IF. */
            }


            /*" -925- PERFORM R1100-00-SELECT-V0CLIENTE. */

            R1100_00_SELECT_V0CLIENTE_SECTION();

            /*" -926- IF (WS-ERRO-FATAL EQUAL 'S' ) */

            if ((WS_ERRO_FATAL == "S"))
            {

                /*" -927- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -929- END-IF. */
            }


            /*" -930- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -931- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -933- END-IF. */
            }


            /*" -935- PERFORM R1200-00-SELECT-V0ENDERECO. */

            R1200_00_SELECT_V0ENDERECO_SECTION();

            /*" -936- IF (WS-ERRO-FATAL EQUAL 'S' ) */

            if ((WS_ERRO_FATAL == "S"))
            {

                /*" -937- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -939- END-IF. */
            }


            /*" -940- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -941- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -943- END-IF. */
            }


            /*" -945- PERFORM R1300-00-SELECT-V0AGENCIACEF. */

            R1300_00_SELECT_V0AGENCIACEF_SECTION();

            /*" -946- IF (WS-ERRO-FATAL EQUAL 'S' ) */

            if ((WS_ERRO_FATAL == "S"))
            {

                /*" -947- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -949- END-IF. */
            }


            /*" -950- MOVE V0CLIE-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVA0445B.SVA_NOME_RAZAO);

            /*" -951- MOVE V0CLIE-CGCCPF TO SVA-CGCCPF. */
            _.Move(V0CLIE_CGCCPF, REG_SVA0445B.SVA_CGCCPF);

            /*" -952- MOVE V0ENDE-ENDERECO TO SVA-ENDERECO. */
            _.Move(V0ENDE_ENDERECO, REG_SVA0445B.SVA_ENDERECO);

            /*" -953- MOVE V0ENDE-BAIRRO TO SVA-BAIRRO. */
            _.Move(V0ENDE_BAIRRO, REG_SVA0445B.SVA_BAIRRO);

            /*" -954- MOVE V0ENDE-CIDADE TO SVA-CIDADE. */
            _.Move(V0ENDE_CIDADE, REG_SVA0445B.SVA_CIDADE);

            /*" -955- MOVE V0ENDE-SIGLA-UF TO SVA-SIGLA-UF. */
            _.Move(V0ENDE_SIGLA_UF, REG_SVA0445B.SVA_SIGLA_UF);

            /*" -956- MOVE V0ENDE-CEP TO SVA-CEP. */
            _.Move(V0ENDE_CEP, REG_SVA0445B.SVA_CEP);

            /*" -957- MOVE V0ENDE-DDD TO SVA-DDD. */
            _.Move(V0ENDE_DDD, REG_SVA0445B.SVA_DDD);

            /*" -958- MOVE V0ENDE-TELEFONE TO SVA-TELEFONE. */
            _.Move(V0ENDE_TELEFONE, REG_SVA0445B.SVA_TELEFONE);

            /*" -959- MOVE V0PROP-APOLICE TO SVA-APOLICE. */
            _.Move(V0PROP_APOLICE, REG_SVA0445B.SVA_APOLICE);

            /*" -960- MOVE V0PROP-CODSUBES TO SVA-CODSUBES. */
            _.Move(V0PROP_CODSUBES, REG_SVA0445B.SVA_CODSUBES);

            /*" -961- MOVE V0PROP-NRCERTIF TO SVA-NRCERTIF. */
            _.Move(V0PROP_NRCERTIF, REG_SVA0445B.SVA_NRCERTIF);

            /*" -962- MOVE V0PROP-CODUSU TO SVA-CODUSU. */
            _.Move(V0PROP_CODUSU, REG_SVA0445B.SVA_CODUSU);

            /*" -963- MOVE V0PROP-NRMATRVEN TO SVA-NRMATRVEN. */
            _.Move(V0PROP_NRMATRVEN, REG_SVA0445B.SVA_NRMATRVEN);

            /*" -964- MOVE V0PROP-DTQITBCO TO SVA-DTQITBCO. */
            _.Move(V0PROP_DTQITBCO, REG_SVA0445B.SVA_DTQITBCO);

            /*" -965- MOVE V0PROP-AGECOBR TO SVA-AGECOBR. */
            _.Move(V0PROP_AGECOBR, REG_SVA0445B.SVA_AGECOBR);

            /*" -966- MOVE V0MALHA-CDFONTE TO SVA-CDFONTE. */
            _.Move(V0MALHA_CDFONTE, REG_SVA0445B.SVA_CDFONTE);

            /*" -967- MOVE V0MALHA-CDESCNEG TO SVA-CDESCNEG. */
            _.Move(V0MALHA_CDESCNEG, REG_SVA0445B.SVA_CDESCNEG);

            /*" -968- MOVE V0PROP-IMPSEGUR TO SVA-IMPSEGUR. */
            _.Move(V0PROP_IMPSEGUR, REG_SVA0445B.SVA_IMPSEGUR);

            /*" -969- MOVE V0PROP-VLPREMIO TO SVA-VLPREMIO. */
            _.Move(V0PROP_VLPREMIO, REG_SVA0445B.SVA_VLPREMIO);

            /*" -970- MOVE V0PROP-SITUACAO TO SVA-SITUACAO. */
            _.Move(V0PROP_SITUACAO, REG_SVA0445B.SVA_SITUACAO);

            /*" -971- MOVE WHOST-QTDIAS TO SVA-QTDIAS. */
            _.Move(WHOST_QTDIAS, REG_SVA0445B.SVA_QTDIAS);

            /*" -972- MOVE V0PROP-DTPROXVEN TO SVA-DTPROXVEN. */
            _.Move(V0PROP_DTPROXVEN, REG_SVA0445B.SVA_DTPROXVEN);

            /*" -973- MOVE V0PROP-CODPRODU TO SVA-NOMPRODU. */
            _.Move(V0PROP_CODPRODU, REG_SVA0445B.SVA_NOMPRODU);

            /*" -975- MOVE V0PROP-NOMPRODU TO SVA-CODPRODU. */
            _.Move(V0PROP_NOMPRODU, REG_SVA0445B.SVA_CODPRODU);

            /*" -975- RELEASE REG-SVA0445B. */
            SVA0445B.Release(REG_SVA0445B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -979- PERFORM R0910-00-FETCH-V0COMISICOB. */

            R0910_00_FETCH_V0COMISICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-SECTION */
        private void R1100_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -990- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -998- PERFORM R1100_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1100_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -1001- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -1002- MOVE 'S' TO WS-ERRO-FATAL */
                _.Move("S", WS_ERRO_FATAL);

                /*" -1003- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -1005- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1007- MOVE 'ERRO NO SELECT V0CLIENTE' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO SELECT V0CLIENTE", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1008- PERFORM R1400-00-GRAVA-REGISTROS */

                R1400_00_GRAVA_REGISTROS_SECTION();

                /*" -1008- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1100_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -998- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CGCCPF FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0PROP-CODCLIEN WITH UR END-EXEC. */

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
            /*" -1019- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1025- PERFORM R1010_00_SELECT_CONVERSAO_DB_SELECT_1 */

            R1010_00_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -1028- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -1029- MOVE 'S' TO WS-ERRO-FATAL */
                _.Move("S", WS_ERRO_FATAL);

                /*" -1030- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -1032- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1034- MOVE 'ERRO NO SELECT SEGUROS.CONVERSAO_SICOB' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO SELECT SEGUROS.CONVERSAO_SICOB", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1035- PERFORM R1400-00-GRAVA-REGISTROS */

                R1400_00_GRAVA_REGISTROS_SECTION();

                /*" -1037- END-IF. */
            }


            /*" -1038- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -1039- MOVE CONV-NUM-SICOB TO CONV-NUMTIT */
                _.Move(CONV_NUM_SICOB, CONV_NUMTIT);

                /*" -1039- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R1010_00_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -1025- EXEC SQL SELECT NUM_SICOB INTO :CONV-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NRCERTIF WITH UR END-EXEC. */

            var r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 = new R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONV_NUM_SICOB, CONV_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-SECTION */
        private void R1020_00_SELECT_V0RCAP_SECTION()
        {
            /*" -1050- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1056- PERFORM R1020_00_SELECT_V0RCAP_DB_SELECT_1 */

            R1020_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -1059- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -1060- MOVE 'S' TO WS-ERRO-FATAL */
                _.Move("S", WS_ERRO_FATAL);

                /*" -1061- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -1063- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1065- MOVE 'ERRO NO SELECT V0AGENCIACEF' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO SELECT V0AGENCIACEF", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1066- PERFORM R1400-00-GRAVA-REGISTROS */

                R1400_00_GRAVA_REGISTROS_SECTION();

                /*" -1066- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R1020_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -1056- EXEC SQL SELECT SITUACAO INTO :WHOST-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :WHOST-NUMTIT WITH UR END-EXEC. */

            var r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                WHOST_NUMTIT = WHOST_NUMTIT.ToString(),
            };

            var executed_1 = R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_SITUACAO, WHOST_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECO-SECTION */
        private void R1200_00_SELECT_V0ENDERECO_SECTION()
        {
            /*" -1077- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1096- PERFORM R1200_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1200_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -1099- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -1100- MOVE 'S' TO WS-ERRO-FATAL */
                _.Move("S", WS_ERRO_FATAL);

                /*" -1101- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -1103- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1105- MOVE 'ERRO NO SELECT V0ENDERECOS' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO SELECT V0ENDERECOS", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1106- PERFORM R1400-00-GRAVA-REGISTROS */

                R1400_00_GRAVA_REGISTROS_SECTION();

                /*" -1106- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1200_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -1096- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-SIGLA-UF, :V0ENDE-CEP, :V0ENDE-DDD, :V0ENDE-TELEFONE FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0PROP-CODCLIEN AND OCORR_ENDERECO = :V0PROP-OCOREND WITH UR END-EXEC. */

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
            /*" -1117- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1127- PERFORM R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1 */

            R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1();

            /*" -1130- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1131- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1132- MOVE 99 TO V0MALHA-CDFONTE */
                    _.Move(99, V0MALHA_CDFONTE);

                    /*" -1133- MOVE 4172 TO V0MALHA-CDESCNEG */
                    _.Move(4172, V0MALHA_CDESCNEG);

                    /*" -1134- ELSE */
                }
                else
                {


                    /*" -1135- MOVE 'S' TO WS-ERRO-FATAL */
                    _.Move("S", WS_ERRO_FATAL);

                    /*" -1136- PERFORM R1350-00-LIMPA-REGISTROS */

                    R1350_00_LIMPA_REGISTROS_SECTION();

                    /*" -1138- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1140- MOVE 'ERRO NO SELECT V0AGENCIACEF' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO SELECT V0AGENCIACEF", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1140- PERFORM R1400-00-GRAVA-REGISTROS. */

                    R1400_00_GRAVA_REGISTROS_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0AGENCIACEF-DB-SELECT-1 */
        public void R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1()
        {
            /*" -1127- EXEC SQL SELECT B.COD_FONTE, A.COD_ESCNEG INTO :V0MALHA-CDFONTE, :V0MALHA-CDESCNEG FROM SEGUROS.V0AGENCIACEF A, SEGUROS.V0MALHACEF B WHERE A.COD_AGENCIA = :V0PROP-AGECOBR AND B.COD_SUREG = A.COD_ESCNEG WITH UR END-EXEC. */

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
        /*" R1350-00-LIMPA-REGISTROS-SECTION */
        private void R1350_00_LIMPA_REGISTROS_SECTION()
        {
            /*" -1156- MOVE ZEROS TO LD-NUM-APOL-SSAIDA LD-COD-SUBG-SSAIDA LD-COD-PROD-SSAIDA LD-NUM-CERT-SUB-SSAIDA LD-NUM-CERT-SEG-SSAIDA LD-COD-ERRO-DB2-SSAIDA. */
            _.Move(0, WORK_AREA.LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA, WORK_AREA.LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA, WORK_AREA.LD_REG_SSAIDA.LD_COD_PROD_SSAIDA, WORK_AREA.LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA, WORK_AREA.LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

            /*" -1160- MOVE SPACES TO LD-NOM-PROD-SSAIDA LD-DES-ERRO-DB2-SSAIDA LD-DES-ERRO-SSAIDA. */
            _.Move("", WORK_AREA.LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA, WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_DB2_SSAIDA, WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

            /*" -1165- MOVE ZEROS TO LD-NUM-APOL-DSAIDA LD-COD-SUBG-DSAIDA LD-COD-PROD-DSAIDA LD-NUM-CERT-SUB-DSAIDA LD-NUM-CERT-SEG-DSAIDA. */
            _.Move(0, WORK_AREA.LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA, WORK_AREA.LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA, WORK_AREA.LD_REG_DSAIDA.LD_COD_PROD_DSAIDA, WORK_AREA.LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA, WORK_AREA.LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

            /*" -1166- MOVE SPACES TO LD-NOM-PROD-DSAIDA LD-DES-ERRO-DSAIDA. */
            _.Move("", WORK_AREA.LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA, WORK_AREA.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-REGISTROS-SECTION */
        private void R1400_00_GRAVA_REGISTROS_SECTION()
        {
            /*" -1178- IF LD-DES-ERRO-SSAIDA NOT EQUAL SPACES */

            if (!WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA.IsEmpty())
            {

                /*" -1180- MOVE V0PROP-APOLICE TO LD-NUM-APOL-SSAIDA */
                _.Move(V0PROP_APOLICE, WORK_AREA.LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA);

                /*" -1182- MOVE V0PROP-CODSUBES TO LD-COD-SUBG-SSAIDA */
                _.Move(V0PROP_CODSUBES, WORK_AREA.LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA);

                /*" -1185- MOVE V0PROP-CODPRODU TO LD-COD-PROD-SSAIDA */
                _.Move(V0PROP_CODPRODU, WORK_AREA.LD_REG_SSAIDA.LD_COD_PROD_SSAIDA);

                /*" -1187- IF V0PROP-DTPROXVEN NOT EQUAL '9999-12-31' AND V0PROP-CODSUBES EQUAL ZEROS */

                if (V0PROP_DTPROXVEN != "9999-12-31" && V0PROP_CODSUBES == 00)
                {

                    /*" -1189- MOVE V0PROP-NRCERTIF TO LD-NUM-CERT-SUB-SSAIDA */
                    _.Move(V0PROP_NRCERTIF, WORK_AREA.LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA);

                    /*" -1190- ELSE */
                }
                else
                {


                    /*" -1192- MOVE V0PROP-NRCERTIF TO LD-NUM-CERT-SEG-SSAIDA */
                    _.Move(V0PROP_NRCERTIF, WORK_AREA.LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA);

                    /*" -1194- END-IF */
                }


                /*" -1196- MOVE V0PROD-NOMPRODU TO LD-NOM-PROD-SSAIDA */
                _.Move(V0PROD_NOMPRODU, WORK_AREA.LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA);

                /*" -1197- WRITE RECORD-SSAIDA FROM LD-REG-SSAIDA */
                _.Move(WORK_AREA.LD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -1198- ADD 1 TO AC-ERRO-SISTEMA */
                WORK_AREA.AC_ERRO_SISTEMA.Value = WORK_AREA.AC_ERRO_SISTEMA + 1;

                /*" -1199- ELSE */
            }
            else
            {


                /*" -1201- MOVE V0PROP-APOLICE TO LD-NUM-APOL-DSAIDA */
                _.Move(V0PROP_APOLICE, WORK_AREA.LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA);

                /*" -1203- MOVE V0PROP-CODSUBES TO LD-COD-SUBG-DSAIDA */
                _.Move(V0PROP_CODSUBES, WORK_AREA.LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA);

                /*" -1206- MOVE V0PROP-CODPRODU TO LD-COD-PROD-DSAIDA */
                _.Move(V0PROP_CODPRODU, WORK_AREA.LD_REG_DSAIDA.LD_COD_PROD_DSAIDA);

                /*" -1208- IF V0PROP-DTPROXVEN NOT EQUAL '9999-12-31' AND V0PROP-CODSUBES EQUAL ZEROS */

                if (V0PROP_DTPROXVEN != "9999-12-31" && V0PROP_CODSUBES == 00)
                {

                    /*" -1210- MOVE V0PROP-NRCERTIF TO LD-NUM-CERT-SUB-DSAIDA */
                    _.Move(V0PROP_NRCERTIF, WORK_AREA.LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA);

                    /*" -1211- ELSE */
                }
                else
                {


                    /*" -1213- MOVE V0PROP-NRCERTIF TO LD-NUM-CERT-SEG-DSAIDA */
                    _.Move(V0PROP_NRCERTIF, WORK_AREA.LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

                    /*" -1215- END-IF */
                }


                /*" -1217- MOVE V0PROD-NOMPRODU TO LD-NOM-PROD-DSAIDA */
                _.Move(V0PROD_NOMPRODU, WORK_AREA.LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA);

                /*" -1218- WRITE RECORD-DSAIDA FROM LD-REG-DSAIDA */
                _.Move(WORK_AREA.LD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -1219- ADD 1 TO AC-ERRO-DADOS */
                WORK_AREA.AC_ERRO_DADOS.Value = WORK_AREA.AC_ERRO_DADOS + 1;

                /*" -1219- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -1232- MOVE SVA-APOLICE TO WS-APOLICE-ANT WHOST-APOLICE */
            _.Move(REG_SVA0445B.SVA_APOLICE, WORK_AREA.WS_APOLICE_ANT, WHOST_APOLICE);

            /*" -1235- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT WHOST-CODSUBES. */
            _.Move(REG_SVA0445B.SVA_CODSUBES, WORK_AREA.WS_CODSUBES_ANT, WHOST_CODSUBES);

            /*" -1237- PERFORM R2500-00-SELECT-PRODUTO. */

            R2500_00_SELECT_PRODUTO_SECTION();

            /*" -1238- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1239- GO TO R2000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;

                /*" -1241- END-IF. */
            }


            /*" -1247- PERFORM R2100-00-PROCESSA-PRODUTO UNTIL SVA-APOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR WFIM-SORT EQUAL 'S' OR WS-ERRO-FATAL EQUAL 'S' . */

            while (!(REG_SVA0445B.SVA_APOLICE != WORK_AREA.WS_APOLICE_ANT || REG_SVA0445B.SVA_CODSUBES != WORK_AREA.WS_CODSUBES_ANT || WORK_AREA.WFIM_SORT == "S" || WS_ERRO_FATAL == "S"))
            {

                R2100_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -1248- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1249- GO TO R2000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;

                /*" -1249- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-PRODUTO-SECTION */
        private void R2100_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -1260- MOVE SVA-CDFONTE TO WS-FONTE-ANT. */
            _.Move(REG_SVA0445B.SVA_CDFONTE, WORK_AREA.WS_FONTE_ANT);

            /*" -1267- PERFORM R2200-00-PROCESSA-FONTE UNTIL SVA-APOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CDFONTE NOT EQUAL WS-FONTE-ANT OR WFIM-SORT EQUAL 'S' OR WS-ERRO-FATAL EQUAL 'S' . */

            while (!(REG_SVA0445B.SVA_APOLICE != WORK_AREA.WS_APOLICE_ANT || REG_SVA0445B.SVA_CODSUBES != WORK_AREA.WS_CODSUBES_ANT || REG_SVA0445B.SVA_CDFONTE != WORK_AREA.WS_FONTE_ANT || WORK_AREA.WFIM_SORT == "S" || WS_ERRO_FATAL == "S"))
            {

                R2200_00_PROCESSA_FONTE_SECTION();
            }

            /*" -1268- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1269- GO TO R2100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;

                /*" -1269- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FONTE-SECTION */
        private void R2200_00_PROCESSA_FONTE_SECTION()
        {
            /*" -1281- MOVE '-' TO LD01-TRA1 LD01-TRA1A */
            _.Move("-", WORK_AREA.LD01.LD01_TRA1, WORK_AREA.LD01.LD01_TRA1A);

            /*" -1315- MOVE ';' TO LD01-FIL1 LD01-FIL2 LD01-FIL2A LD01-FIL3 LD01-FIL3-A LD01-FIL3-A1 LD01-FIL3-A2 LD01-FIL3-B LD01-FIL3-C LD01-FIL3-D LD01-FIL3-E LD01-FIL3-F LD01-FIL3-G LD01-FIL3-H LD01-FIL3-I LD01-FIL4 LD01-FIL5 LD01-FIL6 LD01-FIL7 LD01-FIL8 LD01-FIL9 LD01-FIL10 LD01-FIL11 LD02-FIL1 LD02-FIL2 LD02-FIL3 LD02-FIL4 LD02-FIL5 LD02-FIL6 LD02-FIL7 LD02-FIL8 LD02-FIL9 LD02-FIL10 */
            _.Move(";", WORK_AREA.LD01.LD01_FIL1, WORK_AREA.LD01.LD01_FIL2, WORK_AREA.LD01.LD01_FIL2A, WORK_AREA.LD01.LD01_FIL3, WORK_AREA.LD01.LD01_FIL3_A, WORK_AREA.LD01.LD01_FIL3_A1, WORK_AREA.LD01.LD01_FIL3_A2, WORK_AREA.LD01.LD01_FIL3_B, WORK_AREA.LD01.LD01_FIL3_C, WORK_AREA.LD01.LD01_FIL3_D, WORK_AREA.LD01.LD01_FIL3_E, WORK_AREA.LD01.LD01_FIL3_F, WORK_AREA.LD01.LD01_FIL3_G, WORK_AREA.LD01.LD01_FIL3_H, WORK_AREA.LD01.LD01_FIL3_I, WORK_AREA.LD01.LD01_FIL4, WORK_AREA.LD01.LD01_FIL5, WORK_AREA.LD01.LD01_FIL6, WORK_AREA.LD01.LD01_FIL7, WORK_AREA.LD01.LD01_FIL8, WORK_AREA.LD01.LD01_FIL9, WORK_AREA.LD01.LD01_FIL10, WORK_AREA.LD01.LD01_FIL11, WORK_AREA.LD02.LD02_FIL1, WORK_AREA.LD02.LD02_FIL2, WORK_AREA.LD02.LD02_FIL3, WORK_AREA.LD02.LD02_FIL4, WORK_AREA.LD02.LD02_FIL5, WORK_AREA.LD02.LD02_FIL6, WORK_AREA.LD02.LD02_FIL7, WORK_AREA.LD02.LD02_FIL8, WORK_AREA.LD02.LD02_FIL9, WORK_AREA.LD02.LD02_FIL10);

            /*" -1316- IF SVA-CDESCNEG NOT EQUAL WS-COD-ESCNEG-ANT */

            if (REG_SVA0445B.SVA_CDESCNEG != WORK_AREA.WS_COD_ESCNEG_ANT)
            {

                /*" -1318- MOVE SVA-CDESCNEG TO WS-COD-ESCNEG-ANT WHOST-COD-ESCNEG */
                _.Move(REG_SVA0445B.SVA_CDESCNEG, WORK_AREA.WS_COD_ESCNEG_ANT, WHOST_COD_ESCNEG);

                /*" -1319- PERFORM R3190-00-SELECT-ESCNEG */

                R3190_00_SELECT_ESCNEG_SECTION();

                /*" -1320- IF WS-ERRO-FATAL EQUAL 'S' */

                if (WS_ERRO_FATAL == "S")
                {

                    /*" -1321- GO TO R2200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/ //GOTO
                    return;

                    /*" -1322- END-IF */
                }


                /*" -1324- MOVE V0ESCN-NOMEESC TO LD01-REGIAO-ESCNEG. */
                _.Move(V0ESCN_NOMEESC, WORK_AREA.LD01.LD01_REGIAO_ESCNEG);
            }


            /*" -1326- MOVE SVA-NOME-RAZAO TO LD01-NOME-RAZAO LD02-NOME-RAZAO. */
            _.Move(REG_SVA0445B.SVA_NOME_RAZAO, WORK_AREA.LD01.LD01_NOME_RAZAO, WORK_AREA.LD02.LD02_NOME_RAZAO);

            /*" -1328- MOVE SVA-CGCCPF TO LD01-CGCCPF LD02-CGCCPF. */
            _.Move(REG_SVA0445B.SVA_CGCCPF, WORK_AREA.LD01.LD01_CGCCPF, WORK_AREA.LD02.LD02_CGCCPF);

            /*" -1329- MOVE SVA-ENDERECO TO LD01-ENDERECO. */
            _.Move(REG_SVA0445B.SVA_ENDERECO, WORK_AREA.LD01.LD01_ENDERECO);

            /*" -1330- MOVE SVA-BAIRRO TO LD01-BAIRRO. */
            _.Move(REG_SVA0445B.SVA_BAIRRO, WORK_AREA.LD01.LD01_BAIRRO);

            /*" -1331- MOVE SVA-CIDADE TO LD01-CIDADE. */
            _.Move(REG_SVA0445B.SVA_CIDADE, WORK_AREA.LD01.LD01_CIDADE);

            /*" -1332- MOVE SVA-SIGLA-UF TO LD01-SIGLA-UF. */
            _.Move(REG_SVA0445B.SVA_SIGLA_UF, WORK_AREA.LD01.LD01_SIGLA_UF);

            /*" -1333- MOVE SVA-CEP TO LD01-CEP. */
            _.Move(REG_SVA0445B.SVA_CEP, WORK_AREA.LD01.LD01_CEP);

            /*" -1334- MOVE SVA-DDD TO LD01-DDD. */
            _.Move(REG_SVA0445B.SVA_DDD, WORK_AREA.LD01.LD01_DDD);

            /*" -1335- MOVE SVA-TELEFONE TO LD01-TELEFONE. */
            _.Move(REG_SVA0445B.SVA_TELEFONE, WORK_AREA.LD01.LD01_TELEFONE);

            /*" -1336- MOVE SVA-CDESCNEG TO LD01-COD-ESCNEG */
            _.Move(REG_SVA0445B.SVA_CDESCNEG, WORK_AREA.LD01.LD01_COD_ESCNEG);

            /*" -1338- MOVE V0PROD-NOMPRODU TO LD01-NOMPRODU LD02-NOMPRODU */
            _.Move(V0PROD_NOMPRODU, WORK_AREA.LD01.LD01_NOMPRODU, WORK_AREA.LD02.LD02_DESC_DOC.LD02_NOMPRODU);

            /*" -1340- MOVE SVA-CDFONTE TO LD01-CODFILIAL LD02-CODFILIAL */
            _.Move(REG_SVA0445B.SVA_CDFONTE, WORK_AREA.LD01.LD01_CODFILIAL, WORK_AREA.LD02.LD02_CODFILIAL);

            /*" -1341- MOVE TBFT-NMFONTE(SVA-CDFONTE) TO LD01-NOMFILIAL */
            _.Move(TABELA_FONTES1.TAB_FTE1[REG_SVA0445B.SVA_CDFONTE].TBFT_NMFONTE, WORK_AREA.LD01.LD01_NOMFILIAL);

            /*" -1343- MOVE SVA-NRCERTIF TO LD01-NRCERTIF LD02-NRCERTIF */
            _.Move(REG_SVA0445B.SVA_NRCERTIF, WORK_AREA.LD01.LD01_NRCERTIF, WORK_AREA.LD02.LD02_NRCERTIF);

            /*" -1344- MOVE SVA-CODUSU TO LD01-CODUSU */
            _.Move(REG_SVA0445B.SVA_CODUSU, WORK_AREA.LD01.LD01_CODUSU);

            /*" -1345- MOVE SVA-NRMATRVEN TO LD01-NRMATRVEN */
            _.Move(REG_SVA0445B.SVA_NRMATRVEN, WORK_AREA.LD01.LD01_NRMATRVEN);

            /*" -1346- MOVE SVA-DTQITBCO (1:4) TO LD01-DTQITBCO(7:4) */
            _.MoveAtPosition(REG_SVA0445B.SVA_DTQITBCO.Substring(1, 4), WORK_AREA.LD01.LD01_DTQITBCO, 7, 4);

            /*" -1347- MOVE '/' TO LD01-DTQITBCO(3:1) */
            _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DTQITBCO, 3, 1);

            /*" -1348- MOVE SVA-DTQITBCO (6:2) TO LD01-DTQITBCO(4:2) */
            _.MoveAtPosition(REG_SVA0445B.SVA_DTQITBCO.Substring(6, 2), WORK_AREA.LD01.LD01_DTQITBCO, 4, 2);

            /*" -1349- MOVE '/' TO LD01-DTQITBCO(6:1) */
            _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DTQITBCO, 6, 1);

            /*" -1350- MOVE SVA-DTQITBCO (9:2) TO LD01-DTQITBCO(1:2) */
            _.MoveAtPosition(REG_SVA0445B.SVA_DTQITBCO.Substring(9, 2), WORK_AREA.LD01.LD01_DTQITBCO, 1, 2);

            /*" -1352- MOVE SVA-AGECOBR TO LD01-AGECOBR LD02-AGECOBR */
            _.Move(REG_SVA0445B.SVA_AGECOBR, WORK_AREA.LD01.LD01_AGECOBR, WORK_AREA.LD02.LD02_AGECOBR);

            /*" -1353- MOVE SVA-VLPREMIO TO LD01-VLPREMIO */
            _.Move(REG_SVA0445B.SVA_VLPREMIO, WORK_AREA.LD01.LD01_VLPREMIO);

            /*" -1354- MOVE SVA-IMPSEGUR TO LD01-IMPSEGUR */
            _.Move(REG_SVA0445B.SVA_IMPSEGUR, WORK_AREA.LD01.LD01_IMPSEGUR);

            /*" -1356- MOVE SVA-QTDIAS TO LD01-QTDIAS */
            _.Move(REG_SVA0445B.SVA_QTDIAS, WORK_AREA.LD01.LD01_QTDIAS);

            /*" -1357- MOVE SVA-APOLICE TO LD01-APOLICE. */
            _.Move(REG_SVA0445B.SVA_APOLICE, WORK_AREA.LD01.LD01_APOLICE);

            /*" -1359- MOVE SVA-CODSUBES TO LD01-SUBGRUPO. */
            _.Move(REG_SVA0445B.SVA_CODSUBES, WORK_AREA.LD01.LD01_SUBGRUPO);

            /*" -1360- IF SVA-SITUACAO EQUAL '1' */

            if (REG_SVA0445B.SVA_SITUACAO == "1")
            {

                /*" -1361- MOVE 'EM CRITICA' TO LD01-SITUACAO */
                _.Move("EM CRITICA", WORK_AREA.LD01.LD01_SITUACAO);

                /*" -1363- END-IF. */
            }


            /*" -1364- IF SVA-SITUACAO EQUAL 'E' */

            if (REG_SVA0445B.SVA_SITUACAO == "E")
            {

                /*" -1365- MOVE 'AGUARDANDO CRIVO' TO LD01-SITUACAO */
                _.Move("AGUARDANDO CRIVO", WORK_AREA.LD01.LD01_SITUACAO);

                /*" -1367- END-IF. */
            }


            /*" -1368- IF SVA-SITUACAO EQUAL '9' */

            if (REG_SVA0445B.SVA_SITUACAO == "9")
            {

                /*" -1369- MOVE 'AGUARDANDO PROPOSTA FISICA' TO LD01-SITUACAO */
                _.Move("AGUARDANDO PROPOSTA FISICA", WORK_AREA.LD01.LD01_SITUACAO);

                /*" -1371- END-IF. */
            }


            /*" -1372- PERFORM R2210-00-GRAVA-SAIDA. */

            R2210_00_GRAVA_SAIDA_SECTION();

            /*" -1372- WRITE REG-DVA0445B FROM LD02. */
            _.Move(WORK_AREA.LD02.GetMoveValues(), REG_DVA0445B);

            DVA0445B.Write(REG_DVA0445B.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R2200_90_LER */

            R2200_90_LER();

        }

        [StopWatch]
        /*" R2200-90-LER */
        private void R2200_90_LER(bool isPerform = false)
        {
            /*" -1376- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-GRAVA-SAIDA-SECTION */
        private void R2210_00_GRAVA_SAIDA_SECTION()
        {
            /*" -1387- PERFORM R2280-00-DECLARE-ERROSPROP. */

            R2280_00_DECLARE_ERROSPROP_SECTION();

            /*" -1388- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1390- GO TO R2210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1391- MOVE SPACES TO WFIM-ERROSPROP. */
            _.Move("", WORK_AREA.WFIM_ERROSPROP);

            /*" -1393- PERFORM R2290-00-FETCH-ERROSPROP. */

            R2290_00_FETCH_ERROSPROP_SECTION();

            /*" -1394- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1396- GO TO R2210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1397- IF WFIM-ERROSPROP EQUAL 'SIM' */

            if (WORK_AREA.WFIM_ERROSPROP == "SIM")
            {

                /*" -1398- PERFORM R2215-00-VERIFICA-ERRO */

                R2215_00_VERIFICA_ERRO_SECTION();

                /*" -1399- IF WS-COUNT GREATER 0 */

                if (WORK_AREA.WS_COUNT > 0)
                {

                    /*" -1400- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1401- ELSE */
                }
                else
                {


                    /*" -1402- MOVE 'PROPOSTA SEM ERRO' TO LD01-DESCR-ERRO */
                    _.Move("PROPOSTA SEM ERRO", WORK_AREA.LD01.LD01_DESCR_ERRO);

                    /*" -1403- WRITE REG-AVA0445B FROM LD01 */
                    _.Move(WORK_AREA.LD01.GetMoveValues(), REG_AVA0445B);

                    AVA0445B.Write(REG_AVA0445B.GetMoveValues().ToString());

                    /*" -1404- GO TO R2210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1405- END-IF */
                }


                /*" -1407- END-IF */
            }


            /*" -1407- PERFORM R2220-00-PROCESSA-ERROSPROP. */

            R2220_00_PROCESSA_ERROSPROP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2215-00-VERIFICA-ERRO-SECTION */
        private void R2215_00_VERIFICA_ERRO_SECTION()
        {
            /*" -1417- MOVE '215' TO WNR-EXEC-SQL. */
            _.Move("215", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1431- MOVE ZEROS TO WS-COUNT. */
            _.Move(0, WORK_AREA.WS_COUNT);

            /*" -1442- PERFORM R2215_00_VERIFICA_ERRO_DB_SELECT_1 */

            R2215_00_VERIFICA_ERRO_DB_SELECT_1();

            /*" -1445- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1446- DISPLAY 'R2215 - PROBLEMAS DECLARE (ERROSPROP) ..' */
                _.Display($"R2215 - PROBLEMAS DECLARE (ERROSPROP) ..");

                /*" -1447- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1448- MOVE 'S' TO WS-ERRO-FATAL */
                _.Move("S", WS_ERRO_FATAL);

                /*" -1449- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -1451- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1453- MOVE 'R2215 - PROBLEMAS DECLARE (ERROSPROP).' TO LD-DES-ERRO-SSAIDA */
                _.Move("R2215 - PROBLEMAS DECLARE (ERROSPROP).", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1453- PERFORM R2600-00-GRAVA-REGISTROS. */

                R2600_00_GRAVA_REGISTROS_SECTION();
            }


        }

        [StopWatch]
        /*" R2215-00-VERIFICA-ERRO-DB-SELECT-1 */
        public void R2215_00_VERIFICA_ERRO_DB_SELECT_1()
        {
            /*" -1442- EXEC SQL SELECT COUNT(A.COD_MSG_CRITICA) INTO :WS-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :WHOST-NRCERTIF AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' AND VALUE(B.COD_AGRUPA_ERRO, ' ' ) <> 'CAD' WITH UR END-EXEC. */

            var r2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1 = new R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1.Execute(r2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WORK_AREA.WS_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-PROCESSA-ERROSPROP-SECTION */
        private void R2220_00_PROCESSA_ERROSPROP_SECTION()
        {
            /*" -1463- MOVE ERROSP-DESCR-ERRO TO LD01-DESCR-ERRO. */
            _.Move(ERROSP_DESCR_ERRO, WORK_AREA.LD01.LD01_DESCR_ERRO);

            /*" -1463- WRITE REG-AVA0445B FROM LD01. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_AVA0445B);

            AVA0445B.Write(REG_AVA0445B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2280-00-DECLARE-ERROSPROP-SECTION */
        private void R2280_00_DECLARE_ERROSPROP_SECTION()
        {
            /*" -1474- MOVE '228' TO WNR-EXEC-SQL. */
            _.Move("228", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1487- MOVE SVA-NRCERTIF TO WHOST-NRCERTIF. */
            _.Move(REG_SVA0445B.SVA_NRCERTIF, WHOST_NRCERTIF);

            /*" -1497- PERFORM R2280_00_DECLARE_ERROSPROP_DB_DECLARE_1 */

            R2280_00_DECLARE_ERROSPROP_DB_DECLARE_1();

            /*" -1499- PERFORM R2280_00_DECLARE_ERROSPROP_DB_OPEN_1 */

            R2280_00_DECLARE_ERROSPROP_DB_OPEN_1();

            /*" -1502- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1503- DISPLAY 'R2280 - PROBLEMAS DECLARE (ERROSPROP) ..' */
                _.Display($"R2280 - PROBLEMAS DECLARE (ERROSPROP) ..");

                /*" -1504- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1505- MOVE 'S' TO WS-ERRO-FATAL */
                _.Move("S", WS_ERRO_FATAL);

                /*" -1506- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -1508- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1510- MOVE 'R2280 - PROBLEMAS DECLARE (ERROSPROP).' TO LD-DES-ERRO-SSAIDA */
                _.Move("R2280 - PROBLEMAS DECLARE (ERROSPROP).", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1510- PERFORM R2600-00-GRAVA-REGISTROS. */

                R2600_00_GRAVA_REGISTROS_SECTION();
            }


        }

        [StopWatch]
        /*" R2280-00-DECLARE-ERROSPROP-DB-OPEN-1 */
        public void R2280_00_DECLARE_ERROSPROP_DB_OPEN_1()
        {
            /*" -1499- EXEC SQL OPEN CERROSP END-EXEC. */

            CERROSP.Open();

        }

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R3100_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -1652- EXEC SQL DECLARE CFONTES CURSOR FOR SELECT FONTE, NOMEFTE FROM SEGUROS.V0FONTE ORDER BY FONTE WITH UR END-EXEC. */
            CFONTES = new VA0445B_CFONTES(false);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2280_99_SAIDA*/

        [StopWatch]
        /*" R2290-00-FETCH-ERROSPROP-SECTION */
        private void R2290_00_FETCH_ERROSPROP_SECTION()
        {
            /*" -1521- MOVE '229' TO WNR-EXEC-SQL. */
            _.Move("229", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1523- PERFORM R2290_00_FETCH_ERROSPROP_DB_FETCH_1 */

            R2290_00_FETCH_ERROSPROP_DB_FETCH_1();

            /*" -1526- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1527- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1528- MOVE 'SIM' TO WFIM-ERROSPROP */
                    _.Move("SIM", WORK_AREA.WFIM_ERROSPROP);

                    /*" -1529- ELSE */
                }
                else
                {


                    /*" -1530- DISPLAY 'R2290 - PROBLEMAS DECLARE (ERROSPROP) ..' */
                    _.Display($"R2290 - PROBLEMAS DECLARE (ERROSPROP) ..");

                    /*" -1531- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1532- MOVE 'S' TO WS-ERRO-FATAL */
                    _.Move("S", WS_ERRO_FATAL);

                    /*" -1533- PERFORM R1350-00-LIMPA-REGISTROS */

                    R1350_00_LIMPA_REGISTROS_SECTION();

                    /*" -1535- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1537- MOVE 'R2290 - PROBLEMAS DECLARE (ERROSPROP).' TO LD-DES-ERRO-SSAIDA */
                    _.Move("R2290 - PROBLEMAS DECLARE (ERROSPROP).", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1539- PERFORM R2600-00-GRAVA-REGISTROS. */

                    R2600_00_GRAVA_REGISTROS_SECTION();
                }

            }


            /*" -1539- PERFORM R2290_00_FETCH_ERROSPROP_DB_CLOSE_1 */

            R2290_00_FETCH_ERROSPROP_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R2290-00-FETCH-ERROSPROP-DB-FETCH-1 */
        public void R2290_00_FETCH_ERROSPROP_DB_FETCH_1()
        {
            /*" -1523- EXEC SQL FETCH CERROSP INTO :ERROSP-DESCR-ERRO END-EXEC. */

            if (CERROSP.Fetch())
            {
                _.Move(CERROSP.ERROSP_DESCR_ERRO, ERROSP_DESCR_ERRO);
            }

        }

        [StopWatch]
        /*" R2290-00-FETCH-ERROSPROP-DB-CLOSE-1 */
        public void R2290_00_FETCH_ERROSPROP_DB_CLOSE_1()
        {
            /*" -1539- EXEC SQL CLOSE CERROSP END-EXEC. */

            CERROSP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2290_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -1550- RETURN SVA0445B AT END */
            try
            {
                SVA0445B.Return(REG_SVA0445B, () =>
                {

                    /*" -1552- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1553- IF WFIM-SORT NOT EQUAL 'S' */

            if (WORK_AREA.WFIM_SORT != "S")
            {

                /*" -1554- ADD 1 TO AC-LIDOS-SORT */
                WORK_AREA.AC_LIDOS_SORT.Value = WORK_AREA.AC_LIDOS_SORT + 1;

                /*" -1554- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-PRODUTO-SECTION */
        private void R2500_00_SELECT_PRODUTO_SECTION()
        {
            /*" -1565- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1572- PERFORM R2500_00_SELECT_PRODUTO_DB_SELECT_1 */

            R2500_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -1575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1576- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1577- MOVE 'PRODUTO INEXISTENTE' TO V0PROD-NOMPRODU */
                    _.Move("PRODUTO INEXISTENTE", V0PROD_NOMPRODU);

                    /*" -1578- ELSE */
                }
                else
                {


                    /*" -1579- MOVE 'S' TO WS-ERRO-FATAL */
                    _.Move("S", WS_ERRO_FATAL);

                    /*" -1580- PERFORM R1350-00-LIMPA-REGISTROS */

                    R1350_00_LIMPA_REGISTROS_SECTION();

                    /*" -1582- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1584- MOVE 'ERRO NO SELECT V0PRODUTOSVG' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO SELECT V0PRODUTOSVG", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1584- PERFORM R2600-00-GRAVA-REGISTROS. */

                    R2600_00_GRAVA_REGISTROS_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R2500_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -1572- EXEC SQL SELECT NOMPRODU INTO :V0PROD-NOMPRODU FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :WHOST-APOLICE AND CODSUBES = :WHOST-CODSUBES WITH UR END-EXEC. */

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
        /*" R2600-00-GRAVA-REGISTROS-SECTION */
        private void R2600_00_GRAVA_REGISTROS_SECTION()
        {
            /*" -1594- IF LD-DES-ERRO-SSAIDA NOT EQUAL SPACES */

            if (!WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA.IsEmpty())
            {

                /*" -1596- MOVE SVA-APOLICE TO LD-NUM-APOL-SSAIDA */
                _.Move(REG_SVA0445B.SVA_APOLICE, WORK_AREA.LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA);

                /*" -1598- MOVE SVA-CODSUBES TO LD-COD-SUBG-SSAIDA */
                _.Move(REG_SVA0445B.SVA_CODSUBES, WORK_AREA.LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA);

                /*" -1601- MOVE SVA-CODPRODU TO LD-COD-PROD-SSAIDA */
                _.Move(REG_SVA0445B.SVA_CODPRODU, WORK_AREA.LD_REG_SSAIDA.LD_COD_PROD_SSAIDA);

                /*" -1603- IF SVA-DTPROXVEN NOT EQUAL '9999-12-31' AND SVA-CODSUBES EQUAL ZEROS */

                if (REG_SVA0445B.SVA_DTPROXVEN != "9999-12-31" && REG_SVA0445B.SVA_CODSUBES == 00)
                {

                    /*" -1605- MOVE SVA-NRCERTIF TO LD-NUM-CERT-SUB-SSAIDA */
                    _.Move(REG_SVA0445B.SVA_NRCERTIF, WORK_AREA.LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA);

                    /*" -1606- ELSE */
                }
                else
                {


                    /*" -1608- MOVE SVA-NRCERTIF TO LD-NUM-CERT-SEG-SSAIDA */
                    _.Move(REG_SVA0445B.SVA_NRCERTIF, WORK_AREA.LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA);

                    /*" -1610- END-IF */
                }


                /*" -1612- MOVE SVA-NOMPRODU TO LD-NOM-PROD-SSAIDA */
                _.Move(REG_SVA0445B.SVA_NOMPRODU, WORK_AREA.LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA);

                /*" -1613- WRITE RECORD-SSAIDA FROM LD-REG-SSAIDA */
                _.Move(WORK_AREA.LD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -1614- ADD 1 TO AC-ERRO-SISTEMA */
                WORK_AREA.AC_ERRO_SISTEMA.Value = WORK_AREA.AC_ERRO_SISTEMA + 1;

                /*" -1615- ELSE */
            }
            else
            {


                /*" -1617- MOVE SVA-APOLICE TO LD-NUM-APOL-DSAIDA */
                _.Move(REG_SVA0445B.SVA_APOLICE, WORK_AREA.LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA);

                /*" -1619- MOVE SVA-CODSUBES TO LD-COD-SUBG-DSAIDA */
                _.Move(REG_SVA0445B.SVA_CODSUBES, WORK_AREA.LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA);

                /*" -1622- MOVE SVA-CODPRODU TO LD-COD-PROD-DSAIDA */
                _.Move(REG_SVA0445B.SVA_CODPRODU, WORK_AREA.LD_REG_DSAIDA.LD_COD_PROD_DSAIDA);

                /*" -1624- IF SVA-DTPROXVEN NOT EQUAL '9999-12-31' AND SVA-CODSUBES EQUAL ZEROS */

                if (REG_SVA0445B.SVA_DTPROXVEN != "9999-12-31" && REG_SVA0445B.SVA_CODSUBES == 00)
                {

                    /*" -1626- MOVE SVA-NRCERTIF TO LD-NUM-CERT-SUB-DSAIDA */
                    _.Move(REG_SVA0445B.SVA_NRCERTIF, WORK_AREA.LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA);

                    /*" -1627- ELSE */
                }
                else
                {


                    /*" -1629- MOVE SVA-NRCERTIF TO LD-NUM-CERT-SEG-DSAIDA */
                    _.Move(REG_SVA0445B.SVA_NRCERTIF, WORK_AREA.LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

                    /*" -1631- END-IF */
                }


                /*" -1633- MOVE SVA-NOMPRODU TO LD-NOM-PROD-DSAIDA */
                _.Move(REG_SVA0445B.SVA_NOMPRODU, WORK_AREA.LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA);

                /*" -1634- WRITE RECORD-DSAIDA FROM LD-REG-DSAIDA */
                _.Move(WORK_AREA.LD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -1635- ADD 1 TO AC-ERRO-DADOS */
                WORK_AREA.AC_ERRO_DADOS.Value = WORK_AREA.AC_ERRO_DADOS + 1;

                /*" -1635- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-SECTION */
        private void R3100_00_DECLARE_FONTES_SECTION()
        {
            /*" -1646- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1652- PERFORM R3100_00_DECLARE_FONTES_DB_DECLARE_1 */

            R3100_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -1654- PERFORM R3100_00_DECLARE_FONTES_DB_OPEN_1 */

            R3100_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -1657- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1658- DISPLAY 'R3100 - PROBLEMAS DECLARE (V0FONTE  ) ..' */
                _.Display($"R3100 - PROBLEMAS DECLARE (V0FONTE  ) ..");

                /*" -1659- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1660- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -1662- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1664- MOVE 'R3100 - PROBLEMAS DECLARE (V0FONTE  ).' TO LD-DES-ERRO-SSAIDA */
                _.Move("R3100 - PROBLEMAS DECLARE (V0FONTE).", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1664- PERFORM R2600-00-GRAVA-REGISTROS. */

                R2600_00_GRAVA_REGISTROS_SECTION();
            }


        }

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R3100_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -1654- EXEC SQL OPEN CFONTES END-EXEC. */

            CFONTES.Open();

        }

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-DB-DECLARE-1 */
        public void R3200_00_DECLARE_ESCNEG_DB_DECLARE_1()
        {
            /*" -1760- EXEC SQL DECLARE CESCNEG CURSOR FOR SELECT COD_ESCNEG, REGIAO_ESCNEG, COD_FONTE FROM SEGUROS.V0ESCNEG ORDER BY COD_ESCNEG WITH UR END-EXEC. */
            CESCNEG = new VA0445B_CESCNEG(false);
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
            /*" -1675- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1678- PERFORM R3110_00_FETCH_FONTES_DB_FETCH_1 */

            R3110_00_FETCH_FONTES_DB_FETCH_1();

            /*" -1681- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1682- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1683- MOVE 'S' TO WFIM-FONTES */
                    _.Move("S", WORK_AREA.WFIM_FONTES);

                    /*" -1683- PERFORM R3110_00_FETCH_FONTES_DB_CLOSE_1 */

                    R3110_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -1685- ELSE */
                }
                else
                {


                    /*" -1685- PERFORM R3110_00_FETCH_FONTES_DB_CLOSE_2 */

                    R3110_00_FETCH_FONTES_DB_CLOSE_2();

                    /*" -1687- DISPLAY '3110 - (PROBLEMAS NO FETCH CFONTES  ) ..' */
                    _.Display($"3110 - (PROBLEMAS NO FETCH CFONTES  ) ..");

                    /*" -1688- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1689- PERFORM R1350-00-LIMPA-REGISTROS */

                    R1350_00_LIMPA_REGISTROS_SECTION();

                    /*" -1691- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1693- MOVE '3110 - (PROBLEMAS NO FETCH CFONTES  ).' TO LD-DES-ERRO-SSAIDA */
                    _.Move("3110 - (PROBLEMAS NO FETCH CFONTES).", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1693- PERFORM R2600-00-GRAVA-REGISTROS. */

                    R2600_00_GRAVA_REGISTROS_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-FETCH-1 */
        public void R3110_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -1678- EXEC SQL FETCH CFONTES INTO :V0FONT-CODFTE, :V0FONT-NOMEFTE END-EXEC. */

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
            /*" -1683- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-CLOSE-2 */
        public void R3110_00_FETCH_FONTES_DB_CLOSE_2()
        {
            /*" -1685- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }

        [StopWatch]
        /*" R3120-00-CARREGA-FONTES-SECTION */
        private void R3120_00_CARREGA_FONTES_SECTION()
        {
            /*" -1704- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1705- IF V0FONT-CODFTE LESS 100 */

            if (V0FONT_CODFTE < 100)
            {

                /*" -1708- MOVE V0FONT-NOMEFTE TO TBFT-NMFONTE (V0FONT-CODFTE). */
                _.Move(V0FONT_NOMEFTE, TABELA_FONTES1.TAB_FTE1[V0FONT_CODFTE].TBFT_NMFONTE);
            }


            /*" -1708- PERFORM R3110-00-FETCH-FONTES. */

            R3110_00_FETCH_FONTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3190-00-SELECT-ESCNEG-SECTION */
        private void R3190_00_SELECT_ESCNEG_SECTION()
        {
            /*" -1719- MOVE '319' TO WNR-EXEC-SQL. */
            _.Move("319", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1729- PERFORM R3190_00_SELECT_ESCNEG_DB_SELECT_1 */

            R3190_00_SELECT_ESCNEG_DB_SELECT_1();

            /*" -1732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1733- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1734- MOVE 'NAO CADASTRADO' TO V0ESCN-NOMEESC */
                    _.Move("NAO CADASTRADO", V0ESCN_NOMEESC);

                    /*" -1735- ELSE */
                }
                else
                {


                    /*" -1736- DISPLAY 'R3190 - PROBLEMAS SELECT  (V0ESCNEG ) ..' */
                    _.Display($"R3190 - PROBLEMAS SELECT  (V0ESCNEG ) ..");

                    /*" -1737- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1738- PERFORM R1350-00-LIMPA-REGISTROS */

                    R1350_00_LIMPA_REGISTROS_SECTION();

                    /*" -1740- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1742- MOVE 'R3190 - PROBLEMAS SELECT  (V0ESCNEG ).' TO LD-DES-ERRO-SSAIDA */
                    _.Move("R3190 - PROBLEMAS SELECT  (V0ESCNEG).", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1742- PERFORM R1400-00-GRAVA-REGISTROS. */

                    R1400_00_GRAVA_REGISTROS_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3190-00-SELECT-ESCNEG-DB-SELECT-1 */
        public void R3190_00_SELECT_ESCNEG_DB_SELECT_1()
        {
            /*" -1729- EXEC SQL SELECT COD_ESCNEG, REGIAO_ESCNEG, COD_FONTE INTO :V0ESCN-CODESC, :V0ESCN-NOMEESC, :V0ESCN-FONTE FROM SEGUROS.V0ESCNEG WHERE COD_ESCNEG = :WHOST-COD-ESCNEG WITH UR END-EXEC. */

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
            /*" -1753- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1760- PERFORM R3200_00_DECLARE_ESCNEG_DB_DECLARE_1 */

            R3200_00_DECLARE_ESCNEG_DB_DECLARE_1();

            /*" -1762- PERFORM R3200_00_DECLARE_ESCNEG_DB_OPEN_1 */

            R3200_00_DECLARE_ESCNEG_DB_OPEN_1();

            /*" -1765- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1766- DISPLAY 'R3200 - PROBLEMAS DECLARE (V0ESCNEG ) ..' */
                _.Display($"R3200 - PROBLEMAS DECLARE (V0ESCNEG ) ..");

                /*" -1767- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1768- PERFORM R1350-00-LIMPA-REGISTROS */

                R1350_00_LIMPA_REGISTROS_SECTION();

                /*" -1770- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1772- MOVE 'R3200 - PROBLEMAS DECLARE (V0ESCNEG ).' TO LD-DES-ERRO-SSAIDA */
                _.Move("R3200 - PROBLEMAS DECLARE (V0ESCNEG).", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1772- PERFORM R1400-00-GRAVA-REGISTROS. */

                R1400_00_GRAVA_REGISTROS_SECTION();
            }


        }

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-DB-OPEN-1 */
        public void R3200_00_DECLARE_ESCNEG_DB_OPEN_1()
        {
            /*" -1762- EXEC SQL OPEN CESCNEG END-EXEC. */

            CESCNEG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-SECTION */
        private void R3210_00_FETCH_ESCNEG_SECTION()
        {
            /*" -1783- MOVE '321' TO WNR-EXEC-SQL. */
            _.Move("321", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1787- PERFORM R3210_00_FETCH_ESCNEG_DB_FETCH_1 */

            R3210_00_FETCH_ESCNEG_DB_FETCH_1();

            /*" -1790- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1791- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1792- MOVE 'S' TO WFIM-ESCNEG */
                    _.Move("S", WORK_AREA.WFIM_ESCNEG);

                    /*" -1792- PERFORM R3210_00_FETCH_ESCNEG_DB_CLOSE_1 */

                    R3210_00_FETCH_ESCNEG_DB_CLOSE_1();

                    /*" -1794- ELSE */
                }
                else
                {


                    /*" -1794- PERFORM R3210_00_FETCH_ESCNEG_DB_CLOSE_2 */

                    R3210_00_FETCH_ESCNEG_DB_CLOSE_2();

                    /*" -1796- DISPLAY '3210 - (PROBLEMAS NO FETCH CESCNEG  ) ..' */
                    _.Display($"3210 - (PROBLEMAS NO FETCH CESCNEG  ) ..");

                    /*" -1797- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1798- PERFORM R1350-00-LIMPA-REGISTROS */

                    R1350_00_LIMPA_REGISTROS_SECTION();

                    /*" -1800- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, WORK_AREA.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1802- MOVE '3210 - (PROBLEMAS NO FETCH CESCNEG  ).' TO LD-DES-ERRO-SSAIDA */
                    _.Move("3210 - (PROBLEMAS NO FETCH CESCNEG).", WORK_AREA.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1802- PERFORM R1400-00-GRAVA-REGISTROS. */

                    R1400_00_GRAVA_REGISTROS_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-FETCH-1 */
        public void R3210_00_FETCH_ESCNEG_DB_FETCH_1()
        {
            /*" -1787- EXEC SQL FETCH CESCNEG INTO :V0ESCN-CODESC, :V0ESCN-NOMEESC, :V0ESCN-FONTE END-EXEC. */

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
            /*" -1792- EXEC SQL CLOSE CESCNEG END-EXEC */

            CESCNEG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-CLOSE-2 */
        public void R3210_00_FETCH_ESCNEG_DB_CLOSE_2()
        {
            /*" -1794- EXEC SQL CLOSE CESCNEG END-EXEC */

            CESCNEG.Close();

        }

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1815- CLOSE DSAIDA. */
            DSAIDA.Close();

            /*" -1817- CLOSE SSAIDA. */
            SSAIDA.Close();

            /*" -1818- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1819- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1820- DISPLAY '*   VA0445B - GERA RELATORIO MULTPREMIADO  *' */
            _.Display($"*   VA0445B - GERA RELATORIO MULTPREMIADO  *");

            /*" -1821- DISPLAY '*   -------   -------------- ------------  *' */
            _.Display($"*   -------   -------------- ------------  *");

            /*" -1822- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1823- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -1824- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -1825- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1825- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1839- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1841- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1841- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1843- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1847- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1849- IF AC-ERRO-DADOS GREATER ZEROS AND AC-ERRO-SISTEMA GREATER ZEROS */

            if (WORK_AREA.AC_ERRO_DADOS > 00 && WORK_AREA.AC_ERRO_SISTEMA > 00)
            {

                /*" -1850- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -1851- ELSE */
            }
            else
            {


                /*" -1852- IF AC-ERRO-SISTEMA GREATER ZEROS */

                if (WORK_AREA.AC_ERRO_SISTEMA > 00)
                {

                    /*" -1853- MOVE 2 TO RETURN-CODE */
                    _.Move(2, RETURN_CODE);

                    /*" -1854- ELSE */
                }
                else
                {


                    /*" -1855- IF AC-ERRO-DADOS GREATER ZEROS */

                    if (WORK_AREA.AC_ERRO_DADOS > 00)
                    {

                        /*" -1856- MOVE 1 TO RETURN-CODE */
                        _.Move(1, RETURN_CODE);

                        /*" -1857- END-IF */
                    }


                    /*" -1858- END-IF */
                }


                /*" -1860- END-IF. */
            }


            /*" -1863- CLOSE DSAIDA SSAIDA. */
            DSAIDA.Close();
            SSAIDA.Close();

            /*" -1863- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}