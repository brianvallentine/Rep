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
using Sias.VidaAzul.DB2.VA0952B;

namespace Code
{
    public class VA0952B
    {
        public bool IsCall { get; set; }

        public VA0952B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *     GERA ARQUIVO COM AS EMISSOES MANUAIS                       *      */
        /*"      *     NOS MOLDES DO VA1466B PARA ACOMPANHAMENTO                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  *   VERSAO 07 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUIR CONSULTA DA VIEW V0ERROSPROPVA        *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.07        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - DEMANDA 243544                                   *      */
        /*"      *             - COLOCAR DISPLAY NA DATA DE INICIO E FIM DO CURSOR*      */
        /*"      *               PORQUE NAO ESTA SAINDO NADA NO RELATORIO.        *      */
        /*"      *             - MUDAR O PROGRAMA PRA  JPVAD07, PORQUE VI QUE OS  *      */
        /*"      *               REGISTROS ESTAVAM SENDO ATUALIZADOS SOMENTE NESSE*      */
        /*"      *               JOB, O QUE PODE ESTAR CAUSANDO O PROBLEMA DE NAO *      */
        /*"      *               APRESENTAR DADOS NO RELATORIO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/05/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 102.274                                      *      */
        /*"      *             - ALTERACAO DA DATA DE QUITACAO, ANTES ERA APRESEN-*      */
        /*"      *               TADO NO RELATORIO A DATA DE QUITACAO DA TABELA   *      */
        /*"      *               PROPOSTAS_VA,AGORA IRA APRESENTAR A DATA DO RCAP.*      */
        /*"      *                                                                *      */
        /*"      *   EM 15/09/2014 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 30.719                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUIR NO RELATORIO OS CERTIFICADO COM        *      */
        /*"      *                 CANAL DE ORIGEM GITEL.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/11/2009 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - ATENDE CAD 16 677  - RETIRA CLIENTES QUE ESTAVAM *      */
        /*"      *               SAINDO INDEVIDAMENTE NO RELATORIO.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/11/2008 - JUSTINO  (FAST COMPUTER) PROCURE   POR V.03  *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 02 - ATENDE SSI 19 912  - ACRESCENTA PARAMETRO PARA   *      */
        /*"      *               INFORMAR PERIODO DO RELATORIO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/01/2008 - EDIVALDO (FAST COMPUTER) PROCURE   POR V.02  *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  16/02/00  *   FAST       *                       *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _AVA0952B { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis AVA0952B
        {
            get
            {
                _.Move(REG_AVA0952B, _AVA0952B); VarBasis.RedefinePassValue(REG_AVA0952B, _AVA0952B, REG_AVA0952B); return _AVA0952B;
            }
        }
        public SortBasis<VA0952B_REG_SVA0952B> SVA0952B { get; set; } = new SortBasis<VA0952B_REG_SVA0952B>(new VA0952B_REG_SVA0952B());
        /*"01            REG-AVA0952B        PIC X(500).*/
        public StringBasis REG_AVA0952B { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"01            REG-SVA0952B.*/
        public VA0952B_REG_SVA0952B REG_SVA0952B { get; set; } = new VA0952B_REG_SVA0952B();
        public class VA0952B_REG_SVA0952B : VarBasis
        {
            /*"    05        SVA-APOLICE         PIC  9(013).*/
            public IntBasis SVA_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-CODSUBES        PIC  9(004).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-NRCERTIF        PIC  9(015).*/
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-DTQITBCO        PIC  X(010).*/
            public StringBasis SVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-DTINCLUSAO      PIC  X(010).*/
            public StringBasis SVA_DTINCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-CODUSU          PIC  X(008).*/
            public StringBasis SVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
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
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
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
        /*"77            WHOST-DT-INICIO     PIC  X(10).*/
        public StringBasis WHOST_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DT-FIM        PIC  X(10).*/
        public StringBasis WHOST_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DT-CORRENTE   PIC  X(10).*/
        public StringBasis WHOST_DT_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTINICIAL     PIC  X(10).*/
        public StringBasis WHOST_DTINICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL       PIC  X(10).*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0FONT-CODFTE       PIC S9(04) COMP.*/
        public IntBasis V0FONT_CODFTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0FONT-NOMEFTE      PIC  X(40).*/
        public StringBasis V0FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PROD-NOMPRODU     PIC  X(40).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        /*"77            V0PROP-CODCLIEN    PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PROP-OCOREND     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-DTQITBCO    PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0ERROSP-DESCR-ERRO PIC X(40).*/
        public StringBasis V0ERROSP_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
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
        /*"77            V0RCAP-COD-FONTE     PIC S9(4) USAGE COMP.*/
        public IntBasis V0RCAP_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77            V0RCAP-NUM-RCAP      PIC S9(9) USAGE COMP.*/
        public IntBasis V0RCAP_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77            V0RCAP-SIT-REGISTRO  PIC X(1).*/
        public StringBasis V0RCAP_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77            V0RCAPCOMP-NRRCAP    PIC S9(9) USAGE COMP.*/
        public IntBasis V0RCAPCOMP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77            V0RCAPCOMP-DATARCAP  PIC X(10).*/
        public StringBasis V0RCAPCOMP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WORK-AREA.*/
        public VA0952B_WORK_AREA WORK_AREA { get; set; } = new VA0952B_WORK_AREA();
        public class VA0952B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public VA0952B_DATA_SQL DATA_SQL { get; set; } = new VA0952B_DATA_SQL();
            public class VA0952B_DATA_SQL : VarBasis
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
                /*"    05       WS-DTH-CRITICA       PIC  9(008).*/
            }
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05       WS-DTH-CRITICA-R     REDEFINES   WS-DTH-CRITICA.*/
            private _REDEF_VA0952B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VA0952B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VA0952B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VA0952B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"      10     WS-CRITICA-ANO       PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-CRITICA-MES       PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CRITICA-DIA       PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        IND                 PIC  9(005) VALUE ZEROS.*/

                public _REDEF_VA0952B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

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
            /*"    05        WS-ERRO-DATA        PIC   X(03)  VALUE  SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05       AUX-RESULTADO       PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-RESTO           PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"   05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA0952B_CANAL _canal { get; set; }
            public _REDEF_VA0952B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA0952B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0952B_CANAL : VarBasis
            {
                /*"       07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                   VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                       VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                        VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                          VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                       VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7")
                }
                };

                /*"       07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05        WFIM-V0COMISICOB    PIC   X(01)  VALUE  ' '.*/

                public _REDEF_VA0952B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
        }
        public StringBasis WFIM_V0COMISICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        WFIM-V0ERROSPROP    PIC   X(03)  VALUE  ' '.*/
        public StringBasis WFIM_V0ERROSPROP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
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
        /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05        AC-DESP-1           PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_DESP_1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05        AC-DESP-2           PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_DESP_2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05        AC-DESP-3           PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_DESP_3 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05        AC-DESP-4           PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_DESP_4 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05        AC-DESP-5           PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_DESP_5 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05        AC-DESP-6           PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_DESP_6 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05        AC-DESP-7           PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_DESP_7 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05       WPAR-PARAMETROS     PIC  X(17).*/
        public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
        /*"    05        FILLER REDEFINES    WPAR-PARAMETROS.*/
        private _REDEF_VA0952B_FILLER_3 _filler_3 { get; set; }
        public _REDEF_VA0952B_FILLER_3 FILLER_3
        {
            get { _filler_3 = new _REDEF_VA0952B_FILLER_3(); _.Move(WPAR_PARAMETROS, _filler_3); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _filler_3, WPAR_PARAMETROS); _filler_3.ValueChanged += () => { _.Move(_filler_3, WPAR_PARAMETROS); }; return _filler_3; }
            set { VarBasis.RedefinePassValue(value, _filler_3, WPAR_PARAMETROS); }
        }  //Redefines
        public class _REDEF_VA0952B_FILLER_3 : VarBasis
        {
            /*"      10     WPAR-ROTINA         PIC  X(01).*/
            public StringBasis WPAR_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"      10     WPAR-INICIO         PIC  X(08).*/
            public StringBasis WPAR_INICIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"      10     WPAR-FIM            PIC  X(08).*/
            public StringBasis WPAR_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"  05        WABEND.*/
            public VA0952B_WABEND WABEND { get; set; } = new VA0952B_WABEND();
            public class VA0952B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' VA0952B'.*/
            }

            public _REDEF_VA0952B_FILLER_3()
            {
                WPAR_ROTINA.ValueChanged += OnValueChanged;
                WPAR_INICIO.ValueChanged += OnValueChanged;
                WPAR_FIM.ValueChanged += OnValueChanged;
                WABEND.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0952B");
        /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
        public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
        /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
        /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
        public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
        /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
        public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        /*"    05        LD00.*/
        public VA0952B_LD00 LD00 { get; set; } = new VA0952B_LD00();
        public class VA0952B_LD00 : VarBasis
        {
            /*"      10      FILLER              PIC X(07)   VALUE 'VA0952B'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"VA0952B");
            /*"      10      FILLER              PIC X(08)   VALUE  SPACES.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"      10      FILLER              PIC X(50)   VALUE            'PROPOSTAS ACEITAS MANUALMENTE'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"PROPOSTAS ACEITAS MANUALMENTE");
            /*"      10      FILLER              PIC X(08)   VALUE             ' DATA : '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" DATA : ");
            /*"      10      LD00-DATAINI        PIC X(10).*/
            public StringBasis LD00_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"      10      LD00-A              PIC X(05)   VALUE   SPACES.*/
            public StringBasis LD00_A { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"      10      LD00-DATAFIN        PIC X(10)   VALUE   SPACES.*/
            public StringBasis LD00_DATAFIN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"      10      FILLER              PIC X(03)   VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @";");
            /*"    05        LD00-1.*/
        }
        public VA0952B_LD00_1 LD00_1 { get; set; } = new VA0952B_LD00_1();
        public class VA0952B_LD00_1 : VarBasis
        {
            /*"      10      FILLER              PIC X(07)   VALUE 'PRODUTO'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'FILIAL'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FILIAL");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(02)   VALUE 'EN'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"EN");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(11)   VALUE             'CERTIFICADO'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE             'QTDIAS'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"QTDIAS");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(10)   VALUE             'OBSERVACAO'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"OBSERVACAO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(04)   VALUE 'NOME'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"NOME");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(03)   VALUE 'CPF'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(03)   VALUE 'DDD'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DDD");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(08)   VALUE 'TELEFONE'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"TELEFONE");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(08)   VALUE 'ENDERECO'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"ENDERECO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'BAIRRO'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"BAIRRO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'CIDADE'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CIDADE");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(02)   VALUE 'UF'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"UF");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(03)   VALUE 'CEP'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CEP");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(08)   VALUE 'QUITACAO'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"QUITACAO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(07)   VALUE 'EMISSAO'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"EMISSAO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(07)   VALUE 'AGENCIA'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'PREMIO'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PREMIO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'IMP.SG'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"IMP.SG");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(07)   VALUE 'USUARIO'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
            /*"    05        LD01.*/
        }
        public VA0952B_LD01 LD01 { get; set; } = new VA0952B_LD01();
        public class VA0952B_LD01 : VarBasis
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
            /*"      10      LD01-FIL3-IK        PIC X(01)   VALUE ';'.*/
            public StringBasis LD01_FIL3_IK { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-DTINCLUS       PIC X(10).*/
            public StringBasis LD01_DTINCLUS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
            /*"01            TABELA-FONTES1.*/
        }
        public VA0952B_TABELA_FONTES1 TABELA_FONTES1 { get; set; } = new VA0952B_TABELA_FONTES1();
        public class VA0952B_TABELA_FONTES1 : VarBasis
        {
            /*"      10      TAB-FTE1            OCCURS 99 TIMES.*/
            public ListBasis<VA0952B_TAB_FTE1> TAB_FTE1 { get; set; } = new ListBasis<VA0952B_TAB_FTE1>(99);
            public class VA0952B_TAB_FTE1 : VarBasis
            {
                /*"        15    TBFT-NMFONTE        PIC  X(040).*/
                public StringBasis TBFT_NMFONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"01            TABELA-FONTES.*/
            }
        }
        public VA0952B_TABELA_FONTES TABELA_FONTES { get; set; } = new VA0952B_TABELA_FONTES();
        public class VA0952B_TABELA_FONTES : VarBasis
        {
            /*"      10      TAB-FTE             OCCURS 99 TIMES.*/
            public ListBasis<VA0952B_TAB_FTE> TAB_FTE { get; set; } = new ListBasis<VA0952B_TAB_FTE>(99);
            public class VA0952B_TAB_FTE : VarBasis
            {
                /*"        15    TBFT-QT-ESTOQ        PIC  9(006).*/
                public IntBasis TBFT_QT_ESTOQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        15    TBFT-VL-ESTOQ        PIC  9(013)V99.*/
                public DoubleBasis TBFT_VL_ESTOQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TABELA-ESCNEG.*/
            }
        }
        public VA0952B_TABELA_ESCNEG TABELA_ESCNEG { get; set; } = new VA0952B_TABELA_ESCNEG();
        public class VA0952B_TABELA_ESCNEG : VarBasis
        {
            /*"      10      TAB-EN              OCCURS 200 TIMES                                  INDEXED BY I01.*/
            public ListBasis<VA0952B_TAB_EN> TAB_EN { get; set; } = new ListBasis<VA0952B_TAB_EN>(200);
            public class VA0952B_TAB_EN : VarBasis
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


        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public VA0952B_TCOMIS TCOMIS { get; set; } = new VA0952B_TCOMIS();
        public VA0952B_CERROSP CERROSP { get; set; } = new VA0952B_CERROSP();
        public VA0952B_CFONTES CFONTES { get; set; } = new VA0952B_CFONTES();
        public VA0952B_CESCNEG CESCNEG { get; set; } = new VA0952B_CESCNEG();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(StringBasis WPAR_PARAMETROS_P, string SVA0952B_FILE_NAME_P, string AVA0952B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.WPAR_PARAMETROS.Value = WPAR_PARAMETROS_P.Value;
                SVA0952B.SetFile(SVA0952B_FILE_NAME_P);
                AVA0952B.SetFile(AVA0952B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WPAR_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -472- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -475- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -478- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -480- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -489- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WNR_EXEC_SQL);

            /*" -490- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -491- DISPLAY '          PROGRAMA EM EXECUCAO VA0952B           ' */
            _.Display($"          PROGRAMA EM EXECUCAO VA0952B           ");

            /*" -492- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -493- DISPLAY 'VERSAO V.07: ' FUNCTION WHEN-COMPILED ' - 402.982' */

            $"VERSAO V.07: FUNCTION{_.WhenCompiled()} - 402.982"
            .Display();

            /*" -494- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -495- DISPLAY ' ' */
            _.Display($" ");

            /*" -502- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -507- DISPLAY '   ' */
            _.Display($"   ");

            /*" -511- INITIALIZE TABELA-FONTES TABELA-ESCNEG LD01. */
            _.Initialize(
                TABELA_FONTES
                , TABELA_ESCNEG
                , LD01
            );

            /*" -513- ACCEPT WPAR-PARAMETROS FROM SYSIN. */
            /*-Accept convertido para parametro de entrada...*/

            /*" -516- MOVE 'NAO' TO WS-ERRO-DATA. */
            _.Move("NAO", WORK_AREA.WS_ERRO_DATA);

            /*" -517- IF WPAR-ROTINA EQUAL 'E' */

            if (FILLER_3.WPAR_ROTINA == "E")
            {

                /*" -519- IF WPAR-INICIO EQUAL '00000000' AND WPAR-FIM EQUAL '00000000' */

                if (FILLER_3.WPAR_INICIO == "00000000" && FILLER_3.WPAR_FIM == "00000000")
                {

                    /*" -521- DISPLAY '*** NAO HOUVE SOLICITACAO  ' WPAR-PARAMETROS */
                    _.Display($"*** NAO HOUVE SOLICITACAO  {WPAR_PARAMETROS}");

                    /*" -522- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -523- END-IF */
                }


                /*" -526- MOVE WPAR-INICIO TO WS-DTH-CRITICA-R */
                _.Move(FILLER_3.WPAR_INICIO, WORK_AREA.WS_DTH_CRITICA_R);

                /*" -528- PERFORM R0400-00-CONSISTE-DATA */

                R0400_00_CONSISTE_DATA_SECTION();

                /*" -529- IF WS-ERRO-DATA EQUAL 'NAO' */

                if (WORK_AREA.WS_ERRO_DATA == "NAO")
                {

                    /*" -532- MOVE WPAR-FIM TO WS-DTH-CRITICA-R */
                    _.Move(FILLER_3.WPAR_FIM, WORK_AREA.WS_DTH_CRITICA_R);

                    /*" -533- PERFORM R0400-00-CONSISTE-DATA */

                    R0400_00_CONSISTE_DATA_SECTION();

                    /*" -534- END-IF */
                }


                /*" -536- END-IF. */
            }


            /*" -539- IF WPAR-ROTINA EQUAL ( 'E' OR 'D' ) AND WS-ERRO-DATA EQUAL 'NAO' NEXT SENTENCE */

            if (FILLER_3.WPAR_ROTINA.In("E", "D") && WORK_AREA.WS_ERRO_DATA == "NAO")
            {

                /*" -540- ELSE */
            }
            else
            {


                /*" -542- DISPLAY '*** PROBLEMAS NOS PARAMETROS INFORMADOS ' WPAR-PARAMETROS */
                _.Display($"*** PROBLEMAS NOS PARAMETROS INFORMADOS {WPAR_PARAMETROS}");

                /*" -543- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -545- END-IF. */
            }


            /*" -547- PERFORM R3100-00-DECLARE-FONTES. */

            R3100_00_DECLARE_FONTES_SECTION();

            /*" -549- PERFORM R3110-00-FETCH-FONTES. */

            R3110_00_FETCH_FONTES_SECTION();

            /*" -550- IF WFIM-FONTES NOT EQUAL SPACES */

            if (!WFIM_FONTES.IsEmpty())
            {

                /*" -551- DISPLAY '0000 - PROBLEMA NO FETCH DA FONTES      ' */
                _.Display($"0000 - PROBLEMA NO FETCH DA FONTES      ");

                /*" -553- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -556- PERFORM R3120-00-CARREGA-FONTES UNTIL WFIM-FONTES EQUAL 'S' . */

            while (!(WFIM_FONTES == "S"))
            {

                R3120_00_CARREGA_FONTES_SECTION();
            }

            /*" -558- PERFORM R3200-00-DECLARE-ESCNEG. */

            R3200_00_DECLARE_ESCNEG_SECTION();

            /*" -560- PERFORM R3210-00-FETCH-ESCNEG. */

            R3210_00_FETCH_ESCNEG_SECTION();

            /*" -561- IF WFIM-ESCNEG NOT EQUAL SPACES */

            if (!WFIM_ESCNEG.IsEmpty())
            {

                /*" -562- DISPLAY '0000 - PROBLEMA NO FETCH DA ESCNEG      ' */
                _.Display($"0000 - PROBLEMA NO FETCH DA ESCNEG      ");

                /*" -564- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -566- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -567- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -568- DISPLAY '*** PROBLEMAS NA V0SISTEMA' */
                _.Display($"*** PROBLEMAS NA V0SISTEMA");

                /*" -569- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -571- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -572- IF WPAR-ROTINA EQUAL 'E' */

            if (FILLER_3.WPAR_ROTINA == "E")
            {

                /*" -573- PERFORM R0300-00-MONTA-DATA-PARAMETROS */

                R0300_00_MONTA_DATA_PARAMETROS_SECTION();

                /*" -575- END-IF. */
            }


            /*" -577- PERFORM R0900-00-DECLARE-PROPOVA. */

            R0900_00_DECLARE_PROPOVA_SECTION();

            /*" -579- PERFORM R0900-00-FETCH-PROPOVA. */

            R0900_00_FETCH_PROPOVA_SECTION();

            /*" -580- IF WFIM-V0COMISICOB EQUAL 'S' */

            if (WFIM_V0COMISICOB == "S")
            {

                /*" -581- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -582- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -585- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -587- MOVE +400000 TO SORT-FILE-SIZE. */
            _.Move(+400000, SORT_FILE_SIZE);

            /*" -595- SORT SVA0952B ON ASCENDING KEY SVA-APOLICE SVA-CODSUBES SVA-CDFONTE SVA-CDESCNEG SVA-NRCERTIF INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-GERA-ARQ THRU R0020-FIM. */
            SORT_RETURN.Value = SVA0952B.Sort("SVA-APOLICE,SVA-CODSUBES,SVA-CDFONTE,SVA-CDESCNEG,SVA-NRCERTIF", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_GERA_ARQ_SECTION());

            /*" -598- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -599- DISPLAY '*** VA0952B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VA0952B *** PROBLEMAS NO SORT ");

                /*" -600- DISPLAY '*** VA0952B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VA0952B *** SORT-RETURN = {SORT_RETURN}");

                /*" -601- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -601- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -607- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -607- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -610- DISPLAY '*** VA0952B - ' */
            _.Display($"*** VA0952B - ");

            /*" -611- DISPLAY 'LIDOS V0COMISICOBVA      ' AC-LIDOS. */
            _.Display($"LIDOS V0COMISICOBVA      {AC_LIDOS}");

            /*" -612- DISPLAY 'DESPREZADOS 1            ' AC-DESP-1. */
            _.Display($"DESPREZADOS 1            {AC_DESP_1}");

            /*" -613- DISPLAY 'DESPREZADOS 2            ' AC-DESP-2. */
            _.Display($"DESPREZADOS 2            {AC_DESP_2}");

            /*" -614- DISPLAY 'DESPREZADOS 3            ' AC-DESP-3. */
            _.Display($"DESPREZADOS 3            {AC_DESP_3}");

            /*" -615- DISPLAY 'DESPREZADOS 4            ' AC-DESP-4. */
            _.Display($"DESPREZADOS 4            {AC_DESP_4}");

            /*" -616- DISPLAY 'DESPREZADOS 5            ' AC-DESP-5. */
            _.Display($"DESPREZADOS 5            {AC_DESP_5}");

            /*" -617- DISPLAY 'DESPREZADOS 6            ' AC-DESP-6. */
            _.Display($"DESPREZADOS 6            {AC_DESP_6}");

            /*" -619- DISPLAY 'DESPREZADOS 7            ' AC-DESP-7. */
            _.Display($"DESPREZADOS 7            {AC_DESP_7}");

            /*" -621- DISPLAY '*** VA0952B - TERMINO NORMAL ***' */
            _.Display($"*** VA0952B - TERMINO NORMAL ***");

            /*" -621- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -635- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0COMISICOB EQUAL 'S' . */

            while (!(WFIM_V0COMISICOB == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -635- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-GERA-ARQ-SECTION */
        private void R0020_00_GERA_ARQ_SECTION()
        {
            /*" -648- OPEN OUTPUT AVA0952B. */
            AVA0952B.Open(REG_AVA0952B);

            /*" -649- WRITE REG-AVA0952B FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_AVA0952B);

            AVA0952B.Write(REG_AVA0952B.GetMoveValues().ToString());

            /*" -651- WRITE REG-AVA0952B FROM LD00-1. */
            _.Move(LD00_1.GetMoveValues(), REG_AVA0952B);

            AVA0952B.Write(REG_AVA0952B.GetMoveValues().ToString());

            /*" -653- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -656- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -656- CLOSE AVA0952B. */
            AVA0952B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -669- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WNR_EXEC_SQL);

            /*" -676- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -679- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -680- DISPLAY 'VA0952B - SISTEMA VA NAO ESTA CADASTRADO' */
                _.Display($"VA0952B - SISTEMA VA NAO ESTA CADASTRADO");

                /*" -681- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", WFIM_V1SISTEMA);

                /*" -683- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -685- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WNR_EXEC_SQL);

            /*" -690- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -693- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -694- DISPLAY 'VA0952B - PROBLEMAS NO ACESSO A V0CONTROCNAB' */
                _.Display($"VA0952B - PROBLEMAS NO ACESSO A V0CONTROCNAB");

                /*" -697- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -699- MOVE V0CONT-DATCEF TO DATA-SQL. */
            _.Move(V0CONT_DATCEF, WORK_AREA.DATA_SQL);

            /*" -701- MOVE DATA-SQL TO WHOST-DTFINAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTFINAL);

            /*" -702- MOVE 01 TO DIA-SQL */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -703- MOVE DATA-SQL TO WHOST-DTINICIAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTINICIAL);

            /*" -704- MOVE V1SIST-DTMOVABE(1:4) TO LD00-DATAINI(7:4) */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(1, 4), LD00.LD00_DATAINI, 7, 4);

            /*" -705- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAINI, 3, 1);

            /*" -706- MOVE V1SIST-DTMOVABE(6:2) TO LD00-DATAINI(4:2) */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(6, 2), LD00.LD00_DATAINI, 4, 2);

            /*" -707- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAINI, 6, 1);

            /*" -709- MOVE V1SIST-DTMOVABE(9:2) TO LD00-DATAINI(1:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(9, 2), LD00.LD00_DATAINI, 1, 2);

            /*" -711- MOVE V1SIST-DTMOVABE TO WHOST-DT-INICIO WHOST-DT-FIM. */
            _.Move(V1SIST_DTMOVABE, WHOST_DT_INICIO, WHOST_DT_FIM);

            /*" -712- DISPLAY '*** DATA:           ***' */
            _.Display($"*** DATA:           ***");

            /*" -713- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA */
            _.Display($"*** TIPO DE ROTINA   {FILLER_3.WPAR_ROTINA}");

            /*" -714- DISPLAY '*** DATA DE INICIO   ' WHOST-DT-INICIO */
            _.Display($"*** DATA DE INICIO   {WHOST_DT_INICIO}");

            /*" -714- DISPLAY '*** DATA DE FIM      ' WHOST-DT-FIM. */
            _.Display($"*** DATA DE FIM      {WHOST_DT_FIM}");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -676- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :WHOST-DT-CORRENTE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.WHOST_DT_CORRENTE, WHOST_DT_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-2 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_2()
        {
            /*" -690- EXEC SQL SELECT MAX(DATCEF) INTO :V0CONT-DATCEF FROM SEGUROS.V0CONTROCNAB WHERE NRCTACED = 63000300001004 END-EXEC. */

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
        /*" R0300-00-MONTA-DATA-PARAMETROS-SECTION */
        private void R0300_00_MONTA_DATA_PARAMETROS_SECTION()
        {
            /*" -729- MOVE 'R030' TO WNR-EXEC-SQL. */
            _.Move("R030", WNR_EXEC_SQL);

            /*" -733- MOVE WPAR-INICIO (1:4) TO LD00-DATAINI(7:4) */
            _.MoveAtPosition(FILLER_3.WPAR_INICIO.Substring(1, 4), LD00.LD00_DATAINI, 7, 4);

            /*" -733- MOVE WPAR-INICIO (1:4) TO WHOST-DT-INICIO(1:4) */
            _.MoveAtPosition(FILLER_3.WPAR_INICIO.Substring(1, 4), WHOST_DT_INICIO, 1, 4);

            /*" -737- MOVE WPAR-INICIO (5:2) TO LD00-DATAINI(4:2) */
            _.MoveAtPosition(FILLER_3.WPAR_INICIO.Substring(5, 2), LD00.LD00_DATAINI, 4, 2);

            /*" -737- MOVE WPAR-INICIO (5:2) TO WHOST-DT-INICIO(6:2) */
            _.MoveAtPosition(FILLER_3.WPAR_INICIO.Substring(5, 2), WHOST_DT_INICIO, 6, 2);

            /*" -741- MOVE WPAR-INICIO (7:2) TO LD00-DATAINI(1:2) */
            _.MoveAtPosition(FILLER_3.WPAR_INICIO.Substring(7, 2), LD00.LD00_DATAINI, 1, 2);

            /*" -741- MOVE WPAR-INICIO (7:2) TO WHOST-DT-INICIO(9:2) */
            _.MoveAtPosition(FILLER_3.WPAR_INICIO.Substring(7, 2), WHOST_DT_INICIO, 9, 2);

            /*" -745- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAINI, 6, 1);

            /*" -745- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAINI, 3, 1);

            /*" -749- MOVE WPAR-FIM (1:4) TO LD00-DATAFIN(7:4) */
            _.MoveAtPosition(FILLER_3.WPAR_FIM.Substring(1, 4), LD00.LD00_DATAFIN, 7, 4);

            /*" -749- MOVE WPAR-FIM (1:4) TO WHOST-DT-FIM(1:4) */
            _.MoveAtPosition(FILLER_3.WPAR_FIM.Substring(1, 4), WHOST_DT_FIM, 1, 4);

            /*" -751- IF WPAR-FIM (1:4) GREATER WHOST-DT-CORRENTE (1:4) */

            if (FILLER_3.WPAR_FIM.Substring(1, 4) > WHOST_DT_CORRENTE.Substring(1, 4))
            {

                /*" -753- MOVE WHOST-DT-CORRENTE (1:4) TO LD00-DATAFIN (7:4) */
                _.MoveAtPosition(WHOST_DT_CORRENTE.Substring(1, 4), LD00.LD00_DATAFIN, 7, 4);

                /*" -755- END-IF. */
            }


            /*" -759- MOVE WPAR-FIM (5:2) TO LD00-DATAFIN(4:2) */
            _.MoveAtPosition(FILLER_3.WPAR_FIM.Substring(5, 2), LD00.LD00_DATAFIN, 4, 2);

            /*" -759- MOVE WPAR-FIM (5:2) TO WHOST-DT-FIM(6:2) */
            _.MoveAtPosition(FILLER_3.WPAR_FIM.Substring(5, 2), WHOST_DT_FIM, 6, 2);

            /*" -763- MOVE WPAR-FIM (7:2) TO LD00-DATAFIN(1:2) */
            _.MoveAtPosition(FILLER_3.WPAR_FIM.Substring(7, 2), LD00.LD00_DATAFIN, 1, 2);

            /*" -763- MOVE WPAR-FIM (7:2) TO WHOST-DT-FIM(9:2) */
            _.MoveAtPosition(FILLER_3.WPAR_FIM.Substring(7, 2), WHOST_DT_FIM, 9, 2);

            /*" -769- MOVE '/' TO LD00-DATAFIN(6:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAFIN, 6, 1);

            /*" -769- MOVE '/' TO LD00-DATAFIN(3:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAFIN, 3, 1);

            /*" -769- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAINI, 6, 1);

            /*" -769- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAINI, 3, 1);

            /*" -772- MOVE '  A  ' TO LD00-A */
            _.Move("  A  ", LD00.LD00_A);

            /*" -778- MOVE '-' TO WHOST-DT-FIM(8:1). */
            _.MoveAtPosition("-", WHOST_DT_FIM, 8, 1);

            /*" -778- MOVE '-' TO WHOST-DT-FIM(5:1) */
            _.MoveAtPosition("-", WHOST_DT_FIM, 5, 1);

            /*" -778- MOVE '-' TO WHOST-DT-INICIO(8:1) */
            _.MoveAtPosition("-", WHOST_DT_INICIO, 8, 1);

            /*" -778- MOVE '-' TO WHOST-DT-INICIO(5:1) */
            _.MoveAtPosition("-", WHOST_DT_INICIO, 5, 1);

            /*" -779- DISPLAY '***     PARAMETROS  ***' */
            _.Display($"***     PARAMETROS  ***");

            /*" -780- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA */
            _.Display($"*** TIPO DE ROTINA   {FILLER_3.WPAR_ROTINA}");

            /*" -781- DISPLAY '*** DATA DE INICIO   ' LD00-DATAINI */
            _.Display($"*** DATA DE INICIO   {LD00.LD00_DATAINI}");

            /*" -782- DISPLAY '*** DATA DE FIM      ' LD00-DATAFIN. */
            _.Display($"*** DATA DE FIM      {LD00.LD00_DATAFIN}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-CONSISTE-DATA-SECTION */
        private void R0400_00_CONSISTE_DATA_SECTION()
        {
            /*" -796- MOVE 'R400' TO WNR-EXEC-SQL. */
            _.Move("R400", WNR_EXEC_SQL);

            /*" -798- MOVE 'NAO' TO WS-ERRO-DATA */
            _.Move("NAO", WORK_AREA.WS_ERRO_DATA);

            /*" -800- IF WS-CRITICA-ANO LESS 1900 OR WS-CRITICA-ANO IS NOT NUMERIC */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_ANO < 1900 || !WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_ANO.IsNumeric())
            {

                /*" -801- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                /*" -802- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -804- END-IF. */
            }


            /*" -807- IF WS-CRITICA-MES EQUAL ZEROS OR WS-CRITICA-MES GREATER 12 OR WS-CRITICA-MES IS NOT NUMERIC */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES == 00 || WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES > 12 || !WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -808- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                /*" -809- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -811- END-IF */
            }


            /*" -813- IF WS-CRITICA-DIA EQUAL ZEROS OR WS-CRITICA-MES IS NOT NUMERIC */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA == 00 || !WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -814- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                /*" -815- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -817- END-IF. */
            }


            /*" -820- IF WS-CRITICA-MES EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -821- IF WS-CRITICA-DIA GREATER 31 */

                if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 31)
                {

                    /*" -822- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                    /*" -823- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -825- END-IF. */
                }

            }


            /*" -826- IF WS-CRITICA-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("04", "06", "09", "11"))
            {

                /*" -827- IF WS-CRITICA-DIA GREATER 30 */

                if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 30)
                {

                    /*" -828- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                    /*" -829- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -830- END-IF */
                }


                /*" -832- END-IF. */
            }


            /*" -833- IF WS-CRITICA-MES EQUAL 02 */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES == 02)
            {

                /*" -837- DIVIDE WS-CRITICA-ANO BY 4 GIVING AUX-RESULTADO REMAINDER AUX-RESTO */
                _.Divide(WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_ANO, 4, WORK_AREA.AUX_RESULTADO, WORK_AREA.AUX_RESTO);

                /*" -838- IF AUX-RESTO EQUAL ZEROS */

                if (WORK_AREA.AUX_RESTO == 00)
                {

                    /*" -839- IF WS-CRITICA-DIA GREATER 29 */

                    if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 29)
                    {

                        /*" -840- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                        /*" -841- GO TO R0400-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                        return;

                        /*" -842- END-IF */
                    }


                    /*" -843- ELSE */
                }
                else
                {


                    /*" -844- IF WS-CRITICA-DIA GREATER 28 */

                    if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 28)
                    {

                        /*" -845- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                        /*" -846- GO TO R0400-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                        return;

                        /*" -847- END-IF */
                    }


                    /*" -848- END-IF */
                }


                /*" -848- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-SECTION */
        private void R0900_00_DECLARE_PROPOVA_SECTION()
        {
            /*" -861- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WNR_EXEC_SQL);

            /*" -896- PERFORM R0900_00_DECLARE_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -898- PERFORM R0900_00_DECLARE_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -896- EXEC SQL DECLARE TCOMIS CURSOR FOR SELECT B.NUM_APOLICE, B.CODSUBES, B.NRCERTIF, B.AGECOBR, B.DTQITBCO, DAYS (:V1SIST-DTMOVABE) - DAYS (B.DTQITBCO), B.CODUSU, B.CODCLIEN, B.OCOREND, C.IMPSEGUR, C.VLPREMIO, M.DATA_INCLUSAO, B.SITUACAO FROM SEGUROS.V0MOVIMENTO M, SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0COBERPROPVA C WHERE M.DATA_INCLUSAO IS NOT NULL AND M.DATA_INCLUSAO BETWEEN :WHOST-DT-INICIO AND :WHOST-DT-FIM AND M.COD_OPERACAO BETWEEN 100 AND 199 AND M.COD_USUARIO NOT IN ( 'VA0601B' , 'VP0601B' , 'VA3118B' ) AND B.NRCERTIF = M.NUM_CERTIFICADO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND C.NRCERTIF = B.NRCERTIF AND C.OCORHIST = B.OCORHIST END-EXEC. */
            TCOMIS = new VA0952B_TCOMIS(true);
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
							B.CODCLIEN
							, 
							B.OCOREND
							, 
							C.IMPSEGUR
							, 
							C.VLPREMIO
							, 
							M.DATA_INCLUSAO
							, 
							B.SITUACAO 
							FROM SEGUROS.V0MOVIMENTO M
							, 
							SEGUROS.V0PRODUTOSVG A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0COBERPROPVA C 
							WHERE M.DATA_INCLUSAO IS NOT NULL 
							AND M.DATA_INCLUSAO BETWEEN '{WHOST_DT_INICIO}' 
							AND '{WHOST_DT_FIM}' 
							AND M.COD_OPERACAO BETWEEN 100 AND 199 
							AND M.COD_USUARIO NOT IN ( 'VA0601B'
							, 
							'VP0601B'
							, 
							'VA3118B' ) 
							AND B.NRCERTIF = M.NUM_CERTIFICADO 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND C.NRCERTIF = B.NRCERTIF 
							AND C.OCORHIST = B.OCORHIST";

                return query;
            }
            TCOMIS.GetQueryEvent += GetQuery_TCOMIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -898- EXEC SQL OPEN TCOMIS END-EXEC. */

            TCOMIS.Open();

        }

        [StopWatch]
        /*" R2280-00-DECLARE-ERROSPROP-DB-DECLARE-1 */
        public void R2280_00_DECLARE_ERROSPROP_DB_DECLARE_1()
        {
            /*" -1366- EXEC SQL DECLARE CERROSP CURSOR FOR SELECT SUBSTR(VALUE(T2.DES_ABREV_MSG_CRITICA, ' ' ),1,40) FROM SEGUROS.VG_CRITICA_PROPOSTA T1, SEGUROS.VG_DM_MSG_CRITICA T2 WHERE T1.NUM_CERTIFICADO = :WHOST-NRCERTIF AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA AND T2.COD_TP_MSG_CRITICA <> '3' ORDER BY T2.DES_ABREV_MSG_CRITICA WITH UR END-EXEC. */
            CERROSP = new VA0952B_CERROSP(true);
            string GetQuery_CERROSP()
            {
                var query = @$"SELECT SUBSTR(VALUE(T2.DES_ABREV_MSG_CRITICA
							, ' ' )
							,1
							,40) 
							FROM SEGUROS.VG_CRITICA_PROPOSTA T1
							, 
							SEGUROS.VG_DM_MSG_CRITICA T2 
							WHERE T1.NUM_CERTIFICADO = '{WHOST_NRCERTIF}' 
							AND T1.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA 
							AND T2.COD_TP_MSG_CRITICA <> '3' 
							ORDER BY T2.DES_ABREV_MSG_CRITICA";

                return query;
            }
            CERROSP.GetQueryEvent += GetQuery_CERROSP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-FETCH-PROPOVA-SECTION */
        private void R0900_00_FETCH_PROPOVA_SECTION()
        {
            /*" -911- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WNR_EXEC_SQL);

            /*" -926- PERFORM R0900_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0900_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -929- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -930- MOVE 'S' TO WFIM-V0COMISICOB */
                _.Move("S", WFIM_V0COMISICOB);

                /*" -930- PERFORM R0900_00_FETCH_PROPOVA_DB_CLOSE_1 */

                R0900_00_FETCH_PROPOVA_DB_CLOSE_1();

                /*" -933- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -933- ADD 1 TO AC-LIDOS. */
            AC_LIDOS.Value = AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0900-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0900_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -926- EXEC SQL FETCH TCOMIS INTO :V0PROP-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-AGECOBR, :V0PROP-DTQITBCO, :WHOST-QTDIAS, :V0PROP-CODUSU, :V0PROP-CODCLIEN, :V0PROP-OCOREND, :V0PROP-IMPSEGUR, :V0PROP-VLPREMIO, :MOVIMVGA-DATA-INCLUSAO, :V0PROP-SITUACAO END-EXEC. */

            if (TCOMIS.Fetch())
            {
                _.Move(TCOMIS.V0PROP_APOLICE, V0PROP_APOLICE);
                _.Move(TCOMIS.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(TCOMIS.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(TCOMIS.V0PROP_AGECOBR, V0PROP_AGECOBR);
                _.Move(TCOMIS.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(TCOMIS.WHOST_QTDIAS, WHOST_QTDIAS);
                _.Move(TCOMIS.V0PROP_CODUSU, V0PROP_CODUSU);
                _.Move(TCOMIS.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(TCOMIS.V0PROP_OCOREND, V0PROP_OCOREND);
                _.Move(TCOMIS.V0PROP_IMPSEGUR, V0PROP_IMPSEGUR);
                _.Move(TCOMIS.V0PROP_VLPREMIO, V0PROP_VLPREMIO);
                _.Move(TCOMIS.MOVIMVGA_DATA_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO);
                _.Move(TCOMIS.V0PROP_SITUACAO, V0PROP_SITUACAO);
            }

        }

        [StopWatch]
        /*" R0900-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0900_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -930- EXEC SQL CLOSE TCOMIS END-EXEC */

            TCOMIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -946- PERFORM R1010-00-SELECT-CONVERSAO. */

            R1010_00_SELECT_CONVERSAO_SECTION();

            /*" -947- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -948- MOVE CONV-NUM-SICOB TO WHOST-NUMTIT */
                _.Move(CONV_NUM_SICOB, WHOST_NUMTIT);

                /*" -949- ELSE */
            }
            else
            {


                /*" -951- MOVE V0PROP-NRCERTIF TO WHOST-NUMTIT. */
                _.Move(V0PROP_NRCERTIF, WHOST_NUMTIT);
            }


            /*" -954- INITIALIZE V0RCAPCOMP-NRRCAP V0RCAPCOMP-DATARCAP */
            _.Initialize(
                V0RCAPCOMP_NRRCAP
                , V0RCAPCOMP_DATARCAP
            );

            /*" -956- PERFORM R1020-00-SELECT-V0RCAP. */

            R1020_00_SELECT_V0RCAP_SECTION();

            /*" -957- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -958- MOVE V0PROP-NRCERTIF TO W-NUM-PROPOSTA */
                _.Move(V0PROP_NRCERTIF, WORK_AREA.W_NUM_PROPOSTA);

                /*" -959- IF NOT CANAL-GITEL */

                if (!WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
                {

                    /*" -960- ADD 1 TO AC-DESP-1 */
                    AC_DESP_1.Value = AC_DESP_1 + 1;

                    /*" -961- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -963- END-IF */
                }


                /*" -964- ELSE */
            }
            else
            {


                /*" -965- PERFORM R1030-00-SELECT-V0RCAPCOMP */

                R1030_00_SELECT_V0RCAPCOMP_SECTION();

                /*" -967- END-IF */
            }


            /*" -969- PERFORM R1100-00-SELECT-V0CLIENTE. */

            R1100_00_SELECT_V0CLIENTE_SECTION();

            /*" -970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -971- ADD 1 TO AC-DESP-2 */
                AC_DESP_2.Value = AC_DESP_2 + 1;

                /*" -973- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -975- PERFORM R1200-00-SELECT-V0ENDERECO. */

            R1200_00_SELECT_V0ENDERECO_SECTION();

            /*" -976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -977- ADD 1 TO AC-DESP-3 */
                AC_DESP_3.Value = AC_DESP_3 + 1;

                /*" -979- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -981- PERFORM R1300-00-SELECT-V0AGENCIACEF. */

            R1300_00_SELECT_V0AGENCIACEF_SECTION();

            /*" -982- MOVE V0CLIE-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVA0952B.SVA_NOME_RAZAO);

            /*" -983- MOVE V0CLIE-CGCCPF TO SVA-CGCCPF. */
            _.Move(V0CLIE_CGCCPF, REG_SVA0952B.SVA_CGCCPF);

            /*" -984- MOVE V0ENDE-ENDERECO TO SVA-ENDERECO. */
            _.Move(V0ENDE_ENDERECO, REG_SVA0952B.SVA_ENDERECO);

            /*" -985- MOVE V0ENDE-BAIRRO TO SVA-BAIRRO. */
            _.Move(V0ENDE_BAIRRO, REG_SVA0952B.SVA_BAIRRO);

            /*" -986- MOVE V0ENDE-CIDADE TO SVA-CIDADE. */
            _.Move(V0ENDE_CIDADE, REG_SVA0952B.SVA_CIDADE);

            /*" -987- MOVE V0ENDE-SIGLA-UF TO SVA-SIGLA-UF. */
            _.Move(V0ENDE_SIGLA_UF, REG_SVA0952B.SVA_SIGLA_UF);

            /*" -988- MOVE V0ENDE-CEP TO SVA-CEP. */
            _.Move(V0ENDE_CEP, REG_SVA0952B.SVA_CEP);

            /*" -989- MOVE V0ENDE-DDD TO SVA-DDD. */
            _.Move(V0ENDE_DDD, REG_SVA0952B.SVA_DDD);

            /*" -990- MOVE V0ENDE-TELEFONE TO SVA-TELEFONE. */
            _.Move(V0ENDE_TELEFONE, REG_SVA0952B.SVA_TELEFONE);

            /*" -991- MOVE V0PROP-APOLICE TO SVA-APOLICE. */
            _.Move(V0PROP_APOLICE, REG_SVA0952B.SVA_APOLICE);

            /*" -992- MOVE V0PROP-CODSUBES TO SVA-CODSUBES. */
            _.Move(V0PROP_CODSUBES, REG_SVA0952B.SVA_CODSUBES);

            /*" -993- MOVE V0PROP-NRCERTIF TO SVA-NRCERTIF. */
            _.Move(V0PROP_NRCERTIF, REG_SVA0952B.SVA_NRCERTIF);

            /*" -995- MOVE V0PROP-CODUSU TO SVA-CODUSU. */
            _.Move(V0PROP_CODUSU, REG_SVA0952B.SVA_CODUSU);

            /*" -996- MOVE V0PROP-AGECOBR TO SVA-AGECOBR. */
            _.Move(V0PROP_AGECOBR, REG_SVA0952B.SVA_AGECOBR);

            /*" -997- MOVE V0MALHA-CDFONTE TO SVA-CDFONTE. */
            _.Move(V0MALHA_CDFONTE, REG_SVA0952B.SVA_CDFONTE);

            /*" -998- MOVE V0MALHA-CDESCNEG TO SVA-CDESCNEG. */
            _.Move(V0MALHA_CDESCNEG, REG_SVA0952B.SVA_CDESCNEG);

            /*" -999- MOVE V0PROP-IMPSEGUR TO SVA-IMPSEGUR. */
            _.Move(V0PROP_IMPSEGUR, REG_SVA0952B.SVA_IMPSEGUR);

            /*" -1000- MOVE V0PROP-VLPREMIO TO SVA-VLPREMIO. */
            _.Move(V0PROP_VLPREMIO, REG_SVA0952B.SVA_VLPREMIO);

            /*" -1002- MOVE V0PROP-SITUACAO TO SVA-SITUACAO. */
            _.Move(V0PROP_SITUACAO, REG_SVA0952B.SVA_SITUACAO);

            /*" -1005- MOVE MOVIMVGA-DATA-INCLUSAO TO SVA-DTINCLUSAO */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO, REG_SVA0952B.SVA_DTINCLUSAO);

            /*" -1007- MOVE WHOST-QTDIAS TO SVA-QTDIAS. */
            _.Move(WHOST_QTDIAS, REG_SVA0952B.SVA_QTDIAS);

            /*" -1008- IF V0RCAPCOMP-DATARCAP EQUAL SPACES */

            if (V0RCAPCOMP_DATARCAP.IsEmpty())
            {

                /*" -1009- MOVE V0PROP-DTQITBCO TO SVA-DTQITBCO */
                _.Move(V0PROP_DTQITBCO, REG_SVA0952B.SVA_DTQITBCO);

                /*" -1010- ELSE */
            }
            else
            {


                /*" -1011- MOVE V0RCAPCOMP-DATARCAP TO SVA-DTQITBCO */
                _.Move(V0RCAPCOMP_DATARCAP, REG_SVA0952B.SVA_DTQITBCO);

                /*" -1013- END-IF */
            }


            /*" -1013- RELEASE REG-SVA0952B. */
            SVA0952B.Release(REG_SVA0952B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1017- PERFORM R0900-00-FETCH-PROPOVA. */

            R0900_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-SECTION */
        private void R1100_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -1030- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WNR_EXEC_SQL);

            /*" -1037- PERFORM R1100_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1100_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -1040- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1040- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1100_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -1037- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CGCCPF FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0PROP-CODCLIEN END-EXEC. */

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
            /*" -1053- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", WNR_EXEC_SQL);

            /*" -1058- PERFORM R1010_00_SELECT_CONVERSAO_DB_SELECT_1 */

            R1010_00_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -1061- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1063- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1064- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1064- MOVE CONV-NUM-SICOB TO CONV-NUMTIT. */
                _.Move(CONV_NUM_SICOB, CONV_NUMTIT);
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R1010_00_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -1058- EXEC SQL SELECT NUM_SICOB INTO :CONV-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NRCERTIF END-EXEC. */

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
            /*" -1077- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", WNR_EXEC_SQL);

            /*" -1087- PERFORM R1020_00_SELECT_V0RCAP_DB_SELECT_1 */

            R1020_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -1090- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1090- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R1020_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -1087- EXEC SQL SELECT FONTE , NRRCAP , SITUACAO INTO :V0RCAP-COD-FONTE , :V0RCAP-NUM-RCAP , :V0RCAP-SIT-REGISTRO FROM SEGUROS.V0RCAP WHERE NRTIT = :WHOST-NUMTIT END-EXEC. */

            var r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                WHOST_NUMTIT = WHOST_NUMTIT.ToString(),
            };

            var executed_1 = R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_COD_FONTE, V0RCAP_COD_FONTE);
                _.Move(executed_1.V0RCAP_NUM_RCAP, V0RCAP_NUM_RCAP);
                _.Move(executed_1.V0RCAP_SIT_REGISTRO, V0RCAP_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1030_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -1103- MOVE '103' TO WNR-EXEC-SQL. */
            _.Move("103", WNR_EXEC_SQL);

            /*" -1113- PERFORM R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -1116- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1116- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1030-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -1113- EXEC SQL SELECT NRRCAP , DATARCAP INTO :V0RCAPCOMP-NRRCAP , :V0RCAPCOMP-DATARCAP FROM SEGUROS.V0RCAPCOMP WHERE FONTE = :V0RCAP-COD-FONTE AND NRRCAP = :V0RCAP-NUM-RCAP AND NRRCAPCO = 0 AND SITUACAO = '0' END-EXEC. */

            var r1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                V0RCAP_COD_FONTE = V0RCAP_COD_FONTE.ToString(),
                V0RCAP_NUM_RCAP = V0RCAP_NUM_RCAP.ToString(),
            };

            var executed_1 = R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAPCOMP_NRRCAP, V0RCAPCOMP_NRRCAP);
                _.Move(executed_1.V0RCAPCOMP_DATARCAP, V0RCAPCOMP_DATARCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECO-SECTION */
        private void R1200_00_SELECT_V0ENDERECO_SECTION()
        {
            /*" -1129- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WNR_EXEC_SQL);

            /*" -1147- PERFORM R1200_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1200_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -1150- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1150- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1200_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -1147- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-SIGLA-UF, :V0ENDE-CEP, :V0ENDE-DDD, :V0ENDE-TELEFONE FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0PROP-CODCLIEN AND OCORR_ENDERECO = :V0PROP-OCOREND END-EXEC. */

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
            /*" -1163- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WNR_EXEC_SQL);

            /*" -1172- PERFORM R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1 */

            R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1();

            /*" -1175- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1176- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1178- MOVE 99 TO V0MALHA-CDFONTE */
                    _.Move(99, V0MALHA_CDFONTE);

                    /*" -1179- MOVE 4172 TO V0MALHA-CDESCNEG */
                    _.Move(4172, V0MALHA_CDESCNEG);

                    /*" -1180- ELSE */
                }
                else
                {


                    /*" -1180- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0AGENCIACEF-DB-SELECT-1 */
        public void R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1()
        {
            /*" -1172- EXEC SQL SELECT B.COD_FONTE, A.COD_ESCNEG INTO :V0MALHA-CDFONTE, :V0MALHA-CDESCNEG FROM SEGUROS.V0AGENCIACEF A, SEGUROS.V0MALHACEF B WHERE A.COD_AGENCIA = :V0PROP-AGECOBR AND B.COD_SUREG = A.COD_ESCNEG END-EXEC. */

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
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -1193- MOVE SVA-APOLICE TO WS-APOLICE-ANT WHOST-APOLICE */
            _.Move(REG_SVA0952B.SVA_APOLICE, WORK_AREA.WS_APOLICE_ANT, WHOST_APOLICE);

            /*" -1196- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT WHOST-CODSUBES. */
            _.Move(REG_SVA0952B.SVA_CODSUBES, WORK_AREA.WS_CODSUBES_ANT, WHOST_CODSUBES);

            /*" -1198- PERFORM R2500-00-SELECT-PRODUTO. */

            R2500_00_SELECT_PRODUTO_SECTION();

            /*" -1201- PERFORM R2100-00-PROCESSA-PRODUTO UNTIL SVA-APOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA0952B.SVA_APOLICE != WORK_AREA.WS_APOLICE_ANT || REG_SVA0952B.SVA_CODSUBES != WORK_AREA.WS_CODSUBES_ANT || WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_PRODUTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-PRODUTO-SECTION */
        private void R2100_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -1214- MOVE SVA-CDFONTE TO WS-FONTE-ANT. */
            _.Move(REG_SVA0952B.SVA_CDFONTE, WORK_AREA.WS_FONTE_ANT);

            /*" -1218- PERFORM R2200-00-PROCESSA-FONTE UNTIL SVA-APOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CDFONTE NOT EQUAL WS-FONTE-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA0952B.SVA_APOLICE != WORK_AREA.WS_APOLICE_ANT || REG_SVA0952B.SVA_CODSUBES != WORK_AREA.WS_CODSUBES_ANT || REG_SVA0952B.SVA_CDFONTE != WORK_AREA.WS_FONTE_ANT || WFIM_SORT == "S"))
            {

                R2200_00_PROCESSA_FONTE_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FONTE-SECTION */
        private void R2200_00_PROCESSA_FONTE_SECTION()
        {
            /*" -1232- MOVE '-' TO LD01-TRA1 LD01-TRA1A */
            _.Move("-", LD01.LD01_TRA1, LD01.LD01_TRA1A);

            /*" -1254- MOVE ';' TO LD01-FIL1 LD01-FIL2 LD01-FIL2A LD01-FIL3 LD01-FIL3-A LD01-FIL3-A1 LD01-FIL3-A2 LD01-FIL3-B LD01-FIL3-C LD01-FIL3-D LD01-FIL3-E LD01-FIL3-F LD01-FIL3-G LD01-FIL3-H LD01-FIL3-I LD01-FIL3-IK LD01-FIL4 LD01-FIL5 LD01-FIL6 LD01-FIL7 LD01-FIL8 */
            _.Move(";", LD01.LD01_FIL1, LD01.LD01_FIL2, LD01.LD01_FIL2A, LD01.LD01_FIL3, LD01.LD01_FIL3_A, LD01.LD01_FIL3_A1, LD01.LD01_FIL3_A2, LD01.LD01_FIL3_B, LD01.LD01_FIL3_C, LD01.LD01_FIL3_D, LD01.LD01_FIL3_E, LD01.LD01_FIL3_F, LD01.LD01_FIL3_G, LD01.LD01_FIL3_H, LD01.LD01_FIL3_I, LD01.LD01_FIL3_IK, LD01.LD01_FIL4, LD01.LD01_FIL5, LD01.LD01_FIL6, LD01.LD01_FIL7, LD01.LD01_FIL8);

            /*" -1255- IF SVA-CDESCNEG NOT EQUAL WS-COD-ESCNEG-ANT */

            if (REG_SVA0952B.SVA_CDESCNEG != WORK_AREA.WS_COD_ESCNEG_ANT)
            {

                /*" -1257- MOVE SVA-CDESCNEG TO WS-COD-ESCNEG-ANT WHOST-COD-ESCNEG */
                _.Move(REG_SVA0952B.SVA_CDESCNEG, WORK_AREA.WS_COD_ESCNEG_ANT, WHOST_COD_ESCNEG);

                /*" -1258- PERFORM R3190-00-SELECT-ESCNEG */

                R3190_00_SELECT_ESCNEG_SECTION();

                /*" -1260- MOVE V0ESCN-NOMEESC TO LD01-REGIAO-ESCNEG. */
                _.Move(V0ESCN_NOMEESC, LD01.LD01_REGIAO_ESCNEG);
            }


            /*" -1261- MOVE SVA-NOME-RAZAO TO LD01-NOME-RAZAO */
            _.Move(REG_SVA0952B.SVA_NOME_RAZAO, LD01.LD01_NOME_RAZAO);

            /*" -1262- MOVE SVA-CGCCPF TO LD01-CGCCPF */
            _.Move(REG_SVA0952B.SVA_CGCCPF, LD01.LD01_CGCCPF);

            /*" -1263- MOVE SVA-ENDERECO TO LD01-ENDERECO. */
            _.Move(REG_SVA0952B.SVA_ENDERECO, LD01.LD01_ENDERECO);

            /*" -1264- MOVE SVA-BAIRRO TO LD01-BAIRRO. */
            _.Move(REG_SVA0952B.SVA_BAIRRO, LD01.LD01_BAIRRO);

            /*" -1265- MOVE SVA-CIDADE TO LD01-CIDADE. */
            _.Move(REG_SVA0952B.SVA_CIDADE, LD01.LD01_CIDADE);

            /*" -1266- MOVE SVA-SIGLA-UF TO LD01-SIGLA-UF. */
            _.Move(REG_SVA0952B.SVA_SIGLA_UF, LD01.LD01_SIGLA_UF);

            /*" -1267- MOVE SVA-CEP TO LD01-CEP. */
            _.Move(REG_SVA0952B.SVA_CEP, LD01.LD01_CEP);

            /*" -1268- MOVE SVA-DDD TO LD01-DDD. */
            _.Move(REG_SVA0952B.SVA_DDD, LD01.LD01_DDD);

            /*" -1269- MOVE SVA-TELEFONE TO LD01-TELEFONE. */
            _.Move(REG_SVA0952B.SVA_TELEFONE, LD01.LD01_TELEFONE);

            /*" -1270- MOVE SVA-CDESCNEG TO LD01-COD-ESCNEG */
            _.Move(REG_SVA0952B.SVA_CDESCNEG, LD01.LD01_COD_ESCNEG);

            /*" -1271- MOVE V0PROD-NOMPRODU TO LD01-NOMPRODU */
            _.Move(V0PROD_NOMPRODU, LD01.LD01_NOMPRODU);

            /*" -1272- MOVE SVA-CDFONTE TO LD01-CODFILIAL */
            _.Move(REG_SVA0952B.SVA_CDFONTE, LD01.LD01_CODFILIAL);

            /*" -1273- MOVE TBFT-NMFONTE(SVA-CDFONTE) TO LD01-NOMFILIAL */
            _.Move(TABELA_FONTES1.TAB_FTE1[REG_SVA0952B.SVA_CDFONTE].TBFT_NMFONTE, LD01.LD01_NOMFILIAL);

            /*" -1274- MOVE SVA-NRCERTIF TO LD01-NRCERTIF */
            _.Move(REG_SVA0952B.SVA_NRCERTIF, LD01.LD01_NRCERTIF);

            /*" -1275- MOVE SVA-CODUSU TO LD01-CODUSU */
            _.Move(REG_SVA0952B.SVA_CODUSU, LD01.LD01_CODUSU);

            /*" -1276- MOVE SVA-DTQITBCO (1:4) TO LD01-DTQITBCO(7:4) */
            _.MoveAtPosition(REG_SVA0952B.SVA_DTQITBCO.Substring(1, 4), LD01.LD01_DTQITBCO, 7, 4);

            /*" -1277- MOVE '/' TO LD01-DTQITBCO(3:1) */
            _.MoveAtPosition("/", LD01.LD01_DTQITBCO, 3, 1);

            /*" -1278- MOVE SVA-DTQITBCO (6:2) TO LD01-DTQITBCO(4:2) */
            _.MoveAtPosition(REG_SVA0952B.SVA_DTQITBCO.Substring(6, 2), LD01.LD01_DTQITBCO, 4, 2);

            /*" -1279- MOVE '/' TO LD01-DTQITBCO(6:1) */
            _.MoveAtPosition("/", LD01.LD01_DTQITBCO, 6, 1);

            /*" -1280- MOVE SVA-DTQITBCO (9:2) TO LD01-DTQITBCO(1:2) */
            _.MoveAtPosition(REG_SVA0952B.SVA_DTQITBCO.Substring(9, 2), LD01.LD01_DTQITBCO, 1, 2);

            /*" -1281- MOVE SVA-DTINCLUSAO(1:4) TO LD01-DTINCLUS(7:4) */
            _.MoveAtPosition(REG_SVA0952B.SVA_DTINCLUSAO.Substring(1, 4), LD01.LD01_DTINCLUS, 7, 4);

            /*" -1282- MOVE '/' TO LD01-DTINCLUS(3:1) */
            _.MoveAtPosition("/", LD01.LD01_DTINCLUS, 3, 1);

            /*" -1283- MOVE SVA-DTINCLUSAO(6:2) TO LD01-DTINCLUS(4:2) */
            _.MoveAtPosition(REG_SVA0952B.SVA_DTINCLUSAO.Substring(6, 2), LD01.LD01_DTINCLUS, 4, 2);

            /*" -1284- MOVE '/' TO LD01-DTINCLUS(6:1) */
            _.MoveAtPosition("/", LD01.LD01_DTINCLUS, 6, 1);

            /*" -1285- MOVE SVA-DTINCLUSAO(9:2) TO LD01-DTINCLUS(1:2) */
            _.MoveAtPosition(REG_SVA0952B.SVA_DTINCLUSAO.Substring(9, 2), LD01.LD01_DTINCLUS, 1, 2);

            /*" -1286- MOVE SVA-AGECOBR TO LD01-AGECOBR */
            _.Move(REG_SVA0952B.SVA_AGECOBR, LD01.LD01_AGECOBR);

            /*" -1287- MOVE SVA-VLPREMIO TO LD01-VLPREMIO */
            _.Move(REG_SVA0952B.SVA_VLPREMIO, LD01.LD01_VLPREMIO);

            /*" -1288- MOVE SVA-IMPSEGUR TO LD01-IMPSEGUR */
            _.Move(REG_SVA0952B.SVA_IMPSEGUR, LD01.LD01_IMPSEGUR);

            /*" -1289- MOVE SVA-QTDIAS TO LD01-QTDIAS */
            _.Move(REG_SVA0952B.SVA_QTDIAS, LD01.LD01_QTDIAS);

            /*" -1291- MOVE 'EMISSAO MANUAL' TO LD01-DESCR-ERRO. */
            _.Move("EMISSAO MANUAL", LD01.LD01_DESCR_ERRO);

            /*" -1291- WRITE REG-AVA0952B FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_AVA0952B);

            AVA0952B.Write(REG_AVA0952B.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R2200_90_LER */

            R2200_90_LER();

        }

        [StopWatch]
        /*" R2200-90-LER */
        private void R2200_90_LER(bool isPerform = false)
        {
            /*" -1296- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-GRAVA-SAIDA-SECTION */
        private void R2210_00_GRAVA_SAIDA_SECTION()
        {
            /*" -1309- PERFORM R2280-00-DECLARE-ERROSPROP. */

            R2280_00_DECLARE_ERROSPROP_SECTION();

            /*" -1310- MOVE SPACES TO WFIM-V0ERROSPROP. */
            _.Move("", WFIM_V0ERROSPROP);

            /*" -1312- PERFORM R2290-00-FETCH-ERROSPROP. */

            R2290_00_FETCH_ERROSPROP_SECTION();

            /*" -1313- IF WFIM-V0ERROSPROP EQUAL 'SIM' */

            if (WFIM_V0ERROSPROP == "SIM")
            {

                /*" -1314- MOVE 'PROPOSTA SEM ERRO' TO LD01-DESCR-ERRO */
                _.Move("PROPOSTA SEM ERRO", LD01.LD01_DESCR_ERRO);

                /*" -1315- WRITE REG-AVA0952B FROM LD01 */
                _.Move(LD01.GetMoveValues(), REG_AVA0952B);

                AVA0952B.Write(REG_AVA0952B.GetMoveValues().ToString());

                /*" -1317- GO TO R2210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1317- PERFORM R2220-00-PROCESSA-ERROSPROP. */

            R2220_00_PROCESSA_ERROSPROP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-PROCESSA-ERROSPROP-SECTION */
        private void R2220_00_PROCESSA_ERROSPROP_SECTION()
        {
            /*" -1330- MOVE V0ERROSP-DESCR-ERRO TO LD01-DESCR-ERRO. */
            _.Move(V0ERROSP_DESCR_ERRO, LD01.LD01_DESCR_ERRO);

            /*" -1330- WRITE REG-AVA0952B FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_AVA0952B);

            AVA0952B.Write(REG_AVA0952B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2280-00-DECLARE-ERROSPROP-SECTION */
        private void R2280_00_DECLARE_ERROSPROP_SECTION()
        {
            /*" -1345- MOVE '228' TO WNR-EXEC-SQL. */
            _.Move("228", WNR_EXEC_SQL);

            /*" -1356- MOVE SVA-NRCERTIF TO WHOST-NRCERTIF. */
            _.Move(REG_SVA0952B.SVA_NRCERTIF, WHOST_NRCERTIF);

            /*" -1366- PERFORM R2280_00_DECLARE_ERROSPROP_DB_DECLARE_1 */

            R2280_00_DECLARE_ERROSPROP_DB_DECLARE_1();

            /*" -1368- PERFORM R2280_00_DECLARE_ERROSPROP_DB_OPEN_1 */

            R2280_00_DECLARE_ERROSPROP_DB_OPEN_1();

            /*" -1371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1372- DISPLAY 'R2280 - PROBLEMAS DECLARE (ERROSPROP) ..' */
                _.Display($"R2280 - PROBLEMAS DECLARE (ERROSPROP) ..");

                /*" -1373- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1373- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2280-00-DECLARE-ERROSPROP-DB-OPEN-1 */
        public void R2280_00_DECLARE_ERROSPROP_DB_OPEN_1()
        {
            /*" -1368- EXEC SQL OPEN CERROSP END-EXEC. */

            CERROSP.Open();

        }

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R3100_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -1455- EXEC SQL DECLARE CFONTES CURSOR FOR SELECT FONTE, NOMEFTE FROM SEGUROS.V0FONTE ORDER BY FONTE END-EXEC. */
            CFONTES = new VA0952B_CFONTES(false);
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
            /*" -1386- MOVE '229' TO WNR-EXEC-SQL. */
            _.Move("229", WNR_EXEC_SQL);

            /*" -1388- PERFORM R2290_00_FETCH_ERROSPROP_DB_FETCH_1 */

            R2290_00_FETCH_ERROSPROP_DB_FETCH_1();

            /*" -1391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1392- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1394- MOVE 'SIM' TO WFIM-V0ERROSPROP */
                    _.Move("SIM", WFIM_V0ERROSPROP);

                    /*" -1395- ELSE */
                }
                else
                {


                    /*" -1396- DISPLAY 'R2290 - PROBLEMAS DECLARE (ERROSPROP) ..' */
                    _.Display($"R2290 - PROBLEMAS DECLARE (ERROSPROP) ..");

                    /*" -1397- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1399- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1399- PERFORM R2290_00_FETCH_ERROSPROP_DB_CLOSE_1 */

            R2290_00_FETCH_ERROSPROP_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R2290-00-FETCH-ERROSPROP-DB-FETCH-1 */
        public void R2290_00_FETCH_ERROSPROP_DB_FETCH_1()
        {
            /*" -1388- EXEC SQL FETCH CERROSP INTO :V0ERROSP-DESCR-ERRO END-EXEC. */

            if (CERROSP.Fetch())
            {
                _.Move(CERROSP.V0ERROSP_DESCR_ERRO, V0ERROSP_DESCR_ERRO);
            }

        }

        [StopWatch]
        /*" R2290-00-FETCH-ERROSPROP-DB-CLOSE-1 */
        public void R2290_00_FETCH_ERROSPROP_DB_CLOSE_1()
        {
            /*" -1399- EXEC SQL CLOSE CERROSP END-EXEC. */

            CERROSP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2290_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -1412- RETURN SVA0952B AT END */
            try
            {
                SVA0952B.Return(REG_SVA0952B, () =>
                {

                    /*" -1412- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WFIM_SORT);

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
            /*" -1425- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WNR_EXEC_SQL);

            /*" -1431- PERFORM R2500_00_SELECT_PRODUTO_DB_SELECT_1 */

            R2500_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -1434- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1435- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1436- MOVE 'PRODUTO INEXISTENTE' TO V0PROD-NOMPRODU */
                    _.Move("PRODUTO INEXISTENTE", V0PROD_NOMPRODU);

                    /*" -1437- ELSE */
                }
                else
                {


                    /*" -1437- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R2500_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -1431- EXEC SQL SELECT NOMPRODU INTO :V0PROD-NOMPRODU FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :WHOST-APOLICE AND CODSUBES = :WHOST-CODSUBES END-EXEC. */

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
            /*" -1450- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WNR_EXEC_SQL);

            /*" -1455- PERFORM R3100_00_DECLARE_FONTES_DB_DECLARE_1 */

            R3100_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -1457- PERFORM R3100_00_DECLARE_FONTES_DB_OPEN_1 */

            R3100_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -1460- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1461- DISPLAY 'R3100 - PROBLEMAS DECLARE (V0FONTE  ) ..' */
                _.Display($"R3100 - PROBLEMAS DECLARE (V0FONTE  ) ..");

                /*" -1462- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1462- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R3100_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -1457- EXEC SQL OPEN CFONTES END-EXEC. */

            CFONTES.Open();

        }

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-DB-DECLARE-1 */
        public void R3200_00_DECLARE_ESCNEG_DB_DECLARE_1()
        {
            /*" -1554- EXEC SQL DECLARE CESCNEG CURSOR FOR SELECT COD_ESCNEG, REGIAO_ESCNEG, COD_FONTE FROM SEGUROS.V0ESCNEG ORDER BY COD_ESCNEG END-EXEC. */
            CESCNEG = new VA0952B_CESCNEG(false);
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
            /*" -1475- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", WNR_EXEC_SQL);

            /*" -1478- PERFORM R3110_00_FETCH_FONTES_DB_FETCH_1 */

            R3110_00_FETCH_FONTES_DB_FETCH_1();

            /*" -1481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1482- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1483- MOVE 'S' TO WFIM-FONTES */
                    _.Move("S", WFIM_FONTES);

                    /*" -1483- PERFORM R3110_00_FETCH_FONTES_DB_CLOSE_1 */

                    R3110_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -1485- ELSE */
                }
                else
                {


                    /*" -1485- PERFORM R3110_00_FETCH_FONTES_DB_CLOSE_2 */

                    R3110_00_FETCH_FONTES_DB_CLOSE_2();

                    /*" -1487- DISPLAY '3110 - (PROBLEMAS NO FETCH CFONTES  ) ..' */
                    _.Display($"3110 - (PROBLEMAS NO FETCH CFONTES  ) ..");

                    /*" -1488- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1488- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-FETCH-1 */
        public void R3110_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -1478- EXEC SQL FETCH CFONTES INTO :V0FONT-CODFTE, :V0FONT-NOMEFTE END-EXEC. */

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
            /*" -1483- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-CLOSE-2 */
        public void R3110_00_FETCH_FONTES_DB_CLOSE_2()
        {
            /*" -1485- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }

        [StopWatch]
        /*" R3120-00-CARREGA-FONTES-SECTION */
        private void R3120_00_CARREGA_FONTES_SECTION()
        {
            /*" -1501- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", WNR_EXEC_SQL);

            /*" -1502- IF V0FONT-CODFTE LESS 100 */

            if (V0FONT_CODFTE < 100)
            {

                /*" -1505- MOVE V0FONT-NOMEFTE TO TBFT-NMFONTE (V0FONT-CODFTE). */
                _.Move(V0FONT_NOMEFTE, TABELA_FONTES1.TAB_FTE1[V0FONT_CODFTE].TBFT_NMFONTE);
            }


            /*" -1505- PERFORM R3110-00-FETCH-FONTES. */

            R3110_00_FETCH_FONTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3190-00-SELECT-ESCNEG-SECTION */
        private void R3190_00_SELECT_ESCNEG_SECTION()
        {
            /*" -1518- MOVE '319' TO WNR-EXEC-SQL. */
            _.Move("319", WNR_EXEC_SQL);

            /*" -1527- PERFORM R3190_00_SELECT_ESCNEG_DB_SELECT_1 */

            R3190_00_SELECT_ESCNEG_DB_SELECT_1();

            /*" -1530- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1531- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1532- MOVE 'NAO CADASTRADO' TO V0ESCN-NOMEESC */
                    _.Move("NAO CADASTRADO", V0ESCN_NOMEESC);

                    /*" -1533- ELSE */
                }
                else
                {


                    /*" -1534- DISPLAY 'R3190 - PROBLEMAS SELECT  (V0ESCNEG ) ..' */
                    _.Display($"R3190 - PROBLEMAS SELECT  (V0ESCNEG ) ..");

                    /*" -1535- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1535- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3190-00-SELECT-ESCNEG-DB-SELECT-1 */
        public void R3190_00_SELECT_ESCNEG_DB_SELECT_1()
        {
            /*" -1527- EXEC SQL SELECT COD_ESCNEG, REGIAO_ESCNEG, COD_FONTE INTO :V0ESCN-CODESC, :V0ESCN-NOMEESC, :V0ESCN-FONTE FROM SEGUROS.V0ESCNEG WHERE COD_ESCNEG = :WHOST-COD-ESCNEG END-EXEC. */

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
            /*" -1548- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WNR_EXEC_SQL);

            /*" -1554- PERFORM R3200_00_DECLARE_ESCNEG_DB_DECLARE_1 */

            R3200_00_DECLARE_ESCNEG_DB_DECLARE_1();

            /*" -1556- PERFORM R3200_00_DECLARE_ESCNEG_DB_OPEN_1 */

            R3200_00_DECLARE_ESCNEG_DB_OPEN_1();

            /*" -1559- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1560- DISPLAY 'R3200 - PROBLEMAS DECLARE (V0ESCNEG ) ..' */
                _.Display($"R3200 - PROBLEMAS DECLARE (V0ESCNEG ) ..");

                /*" -1561- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1561- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-DB-OPEN-1 */
        public void R3200_00_DECLARE_ESCNEG_DB_OPEN_1()
        {
            /*" -1556- EXEC SQL OPEN CESCNEG END-EXEC. */

            CESCNEG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-SECTION */
        private void R3210_00_FETCH_ESCNEG_SECTION()
        {
            /*" -1574- MOVE '321' TO WNR-EXEC-SQL. */
            _.Move("321", WNR_EXEC_SQL);

            /*" -1578- PERFORM R3210_00_FETCH_ESCNEG_DB_FETCH_1 */

            R3210_00_FETCH_ESCNEG_DB_FETCH_1();

            /*" -1581- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1582- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1583- MOVE 'S' TO WFIM-ESCNEG */
                    _.Move("S", WFIM_ESCNEG);

                    /*" -1583- PERFORM R3210_00_FETCH_ESCNEG_DB_CLOSE_1 */

                    R3210_00_FETCH_ESCNEG_DB_CLOSE_1();

                    /*" -1585- ELSE */
                }
                else
                {


                    /*" -1585- PERFORM R3210_00_FETCH_ESCNEG_DB_CLOSE_2 */

                    R3210_00_FETCH_ESCNEG_DB_CLOSE_2();

                    /*" -1587- DISPLAY '3210 - (PROBLEMAS NO FETCH CESCNEG  ) ..' */
                    _.Display($"3210 - (PROBLEMAS NO FETCH CESCNEG  ) ..");

                    /*" -1588- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1588- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-FETCH-1 */
        public void R3210_00_FETCH_ESCNEG_DB_FETCH_1()
        {
            /*" -1578- EXEC SQL FETCH CESCNEG INTO :V0ESCN-CODESC, :V0ESCN-NOMEESC, :V0ESCN-FONTE END-EXEC. */

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
            /*" -1583- EXEC SQL CLOSE CESCNEG END-EXEC */

            CESCNEG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-CLOSE-2 */
        public void R3210_00_FETCH_ESCNEG_DB_CLOSE_2()
        {
            /*" -1585- EXEC SQL CLOSE CESCNEG END-EXEC */

            CESCNEG.Close();

        }

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1602- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1603- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1604- DISPLAY '*   VA0952B - GERA RELATORIO MULTPREMIADO  *' */
            _.Display($"*   VA0952B - GERA RELATORIO MULTPREMIADO  *");

            /*" -1605- DISPLAY '*   -------   -------------- ------------  *' */
            _.Display($"*   -------   -------------- ------------  *");

            /*" -1606- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1607- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -1608- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -1609- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1609- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1623- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WSQLCODE);

            /*" -1625- DISPLAY WABEND */
            _.Display(FILLER_3.WABEND);

            /*" -1625- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1627- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1631- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1631- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}