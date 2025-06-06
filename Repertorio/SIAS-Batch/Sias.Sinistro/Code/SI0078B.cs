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
using Sias.Sinistro.DB2.SI0078B;

namespace Code
{
    public class SI0078B
    {
        public bool IsCall { get; set; }

        public SI0078B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0078B                             *      */
        /*"      *   ANALISTA ............... HEIDER COELHO                       *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... OUT. / 97                           *      */
        /*"      *   FUNCAO ................. EMITE RELATORIO DE SINISTROS MOVI-  *      */
        /*"      *       MENTADOS NO MES SOLIC. VIA V0RELATORIOS. (FUNCEF)        *      */
        /*"      *   USUARIO SOLICITANTE .... PELA AREA TECNICA                   *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *ALTERADO POR JEFFERSON PARA UTILIZAR AS NOVAS TABELAS DO HABITA-*      */
        /*"      *CIONAL - 05/2000                                                *      */
        /*"      *                                                                *      */
        /*"      * MELHORIA DE PERFORMANCE         PRODEXTER            AGO/2000  *      */
        /*"      * (PROCURAR POR CH0800)                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 08/04/2005 - PRODEXTER                                         *      */
        /*"      *   SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16/10/2010 - CAD 47494/2010 - CIRCULAR 395:           *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/10/2010 - MARCELO NEVES (TE41729)   PROCURAR: C395     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SI0078BR { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0078BR
        {
            get
            {
                _.Move(REG_SI0078BR, _SI0078BR); VarBasis.RedefinePassValue(REG_SI0078BR, _SI0078BR, REG_SI0078BR); return _SI0078BR;
            }
        }
        /*"01                  REG-SI0078BR.*/
        public SI0078B_REG_SI0078BR REG_SI0078BR { get; set; } = new SI0078B_REG_SI0078BR();
        public class SI0078B_REG_SI0078BR : VarBasis
        {
            /*"      05            LINHA              PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0CONT-DATA-CONTRATO        PIC X(10).*/
        public StringBasis V0CONT_DATA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CONT-PRZ-VIGENCIA         PIC S9(04)       VALUE +0 COMP.*/
        public IntBasis V0CONT_PRZ_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SEGU-NOME-SEGURADO        PIC X(40).*/
        public StringBasis V0SEGU_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  SINI-OCORHIST                PIC S9(04)   VALUE +0 COMP.*/
        public IntBasis SINI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SINI-OPERACAO                PIC S9(04)   VALUE +0 COMP.*/
        public IntBasis SINI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SINI-DTMOVTO                 PIC X(10).*/
        public StringBasis SINI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  SINI-NOMFAV                  PIC X(40).*/
        public StringBasis SINI_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  SINI-VAL-OPERACAO            PIC S9(15)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis SINI_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"77  SINI-CODUSU                  PIC X(08).*/
        public StringBasis SINI_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  SINI-NUM-APOL-SINISTRO    PIC S9(13)       VALUE +0 COMP-3.*/
        public IntBasis SINI_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  SINI-NUM-APOLICE          PIC S9(13)       VALUE +0 COMP-3.*/
        public IntBasis SINI_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  SINI-NUMIRB               PIC S9(11)       VALUE +0 COMP-3.*/
        public IntBasis SINI_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "11", "S9(11)"));
        /*"77  SINI-CODCAU               PIC S9(04)       VALUE +0 COMP.*/
        public IntBasis SINI_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SINI-RAMO                 PIC S9(04)       VALUE +0 COMP.*/
        public IntBasis SINI_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SINI-DATCMD               PIC  X(10).*/
        public StringBasis SINI_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  SINI-DATORR               PIC  X(10).*/
        public StringBasis SINI_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  SINI-SITUACAO             PIC  X(10).*/
        public StringBasis SINI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HAB01-NUM-CONTRATO          PIC S9(09)     VALUE +0 COMP.*/
        public IntBasis V0HAB01_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HAB01-NUM-APOL-SINISTRO     PIC S9(13)     VALUE +0 COMP-3*/
        public IntBasis V0HAB01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0HAB01-COD-COBERTURA         PIC S9(04)     VALUE +0 COMP.*/
        public IntBasis V0HAB01_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HAB01-NOME-SEGURADO         PIC X(40).*/
        public StringBasis V0HAB01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V1SISTEMA-DTCURRENT          PIC  X(010).*/
        public StringBasis V1SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1SISTEMA-DTMOVABE           PIC  X(010).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1SISTEMA-DTMOVABE-SI        PIC  X(010).*/
        public StringBasis V1SISTEMA_DTMOVABE_SI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1SISTEMA-DTMOVABE-MES       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V1SISTEMA_DTMOVABE_MES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1SISTEMA-DTMOVABE-ANO       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V1SISTEMA_DTMOVABE_ANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1SISTEMA-HORA               PIC  X(008).*/
        public StringBasis V1SISTEMA_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0HISTSINI-COD-EMPRESA       PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0HISTSINI-TIPREG            PIC  X(001).*/
        public StringBasis V0HISTSINI_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0HISTSINI-NUM-APOL-SINISTRO PIC S9(013)    VALUE +0 COMP-3.*/
        public IntBasis V0HISTSINI_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0HISTSINI-OCORHIST          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HISTSINI-OPERACAO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HISTSINI-DTMOVTO           PIC  X(010).*/
        public StringBasis V0HISTSINI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0HISTSINI-HORAOPER          PIC  X(008).*/
        public StringBasis V0HISTSINI_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0HISTSINI-NOMFAV            PIC  X(040).*/
        public StringBasis V0HISTSINI_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0HISTSINI-VAL-OPERACAO     PIC S9(015)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis V0HISTSINI_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V9(2)"), 2);
        /*"77  V0HISTSINI-LIMCRR            PIC  X(010).*/
        public StringBasis V0HISTSINI_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0HISTSINI-TIPFAV            PIC  X(001).*/
        public StringBasis V0HISTSINI_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0HISTSINI-DATNEG            PIC  X(010).*/
        public StringBasis V0HISTSINI_DATNEG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0HISTSINI-FONPAG            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_FONPAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HISTSINI-CODPSVI           PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_CODPSVI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0HISTSINI-CODSVI            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HISTSINI-NUMOPG            PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0HISTSINI-NUMREC            PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0HISTSINI-MOVPCS            PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V0HISTSINI_MOVPCS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0HISTSINI-CODUSU            PIC  X(008).*/
        public StringBasis V0HISTSINI_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0HISTSINI-SITCONTB          PIC  X(001).*/
        public StringBasis V0HISTSINI_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0HISTSINI-SITUACAO          PIC  X(001).*/
        public StringBasis V0HISTSINI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0HISTSINI-TIMESTAMP         PIC  X(026).*/
        public StringBasis V0HISTSINI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77  V0CAUSA-DESCAU                PIC X(40).*/
        public StringBasis V0CAUSA_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0SERVICOS-TIPREG            PIC  X(001).*/
        public StringBasis V0SERVICOS_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0SERVICOS-OPERACAO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V0SERVICOS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0SERVICOS-CODSVI            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V0SERVICOS_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0SERVICOS-DESSVI            PIC  X(040).*/
        public StringBasis V0SERVICOS_DESSVI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77   V0RELATORIOS-ANO-REFERENCIA  PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis V0RELATORIOS_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0RELATORIOS-MES-REFERENCIA  PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis V0RELATORIOS_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WRESTO                       PIC  9(001)  VALUE ZEROS.*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"77   J                            PIC  9(002)  VALUE ZEROS.*/
        public IntBasis J { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01           AREA-DE-WORK.*/
        public SI0078B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0078B_AREA_DE_WORK();
        public class SI0078B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE               PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  W-CHAVES-FIM-ARQUIVO.*/
            public SI0078B_W_CHAVES_FIM_ARQUIVO W_CHAVES_FIM_ARQUIVO { get; set; } = new SI0078B_W_CHAVES_FIM_ARQUIVO();
            public class SI0078B_W_CHAVES_FIM_ARQUIVO : VarBasis
            {
                /*"      10  WFIM-V0HISTSINI        PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_V0HISTSINI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  WFIM-SINISTROS         PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_SINISTROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  WFIM-V0RELATORIOS      PIC  X(003)      VALUE SPACES.*/
                public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10  W-EDICAO               PIC  ZZZ.ZZZ.ZZ9,99999999.*/
                public DoubleBasis W_EDICAO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99999999."), 8);
                /*"  05  W-NUM-APOL-SINISTRO-ANT   PIC S9(013)    VALUE +0 COMP-3.*/
            }
            public IntBasis W_NUM_APOL_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05  W-AC-LINHAS               PIC  9(002)     VALUE  80.*/
            public IntBasis W_AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05  W-AC-PAGINA               PIC  9(004)     VALUE  ZEROS.*/
            public IntBasis W_AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  W-TOT-VALOR               PIC  9(15)V99   VALUE  ZEROS.*/
            public DoubleBasis W_TOT_VALOR { get; set; } = new DoubleBasis(new PIC("9", "15", "9(15)V99"), 2);
            /*"  05  W-LANCAMENTOS-PROCESSADOS PIC  9(005)     VALUE  ZEROS.*/
            public IntBasis W_LANCAMENTOS_PROCESSADOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WDATA-CURR.*/
            public SI0078B_WDATA_CURR WDATA_CURR { get; set; } = new SI0078B_WDATA_CURR();
            public class SI0078B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05   W-DATA-1.*/
            }
            public SI0078B_W_DATA_1 W_DATA_1 { get; set; } = new SI0078B_W_DATA_1();
            public class SI0078B_W_DATA_1 : VarBasis
            {
                /*"    10  W-AA-DATA-1             PIC  9(004)    VALUE ZEROS.*/
                public IntBasis W_AA_DATA_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10  FILLER                  PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  W-MM-DATA-1             PIC  9(002)    VALUE ZEROS.*/
                public IntBasis W_MM_DATA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                  PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  W-DD-DATA-1             PIC  9(002)    VALUE ZEROS.*/
                public IntBasis W_DD_DATA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05   W-DATA-2.*/
            }
            public SI0078B_W_DATA_2 W_DATA_2 { get; set; } = new SI0078B_W_DATA_2();
            public class SI0078B_W_DATA_2 : VarBasis
            {
                /*"    10  W-DD-DATA-2             PIC  9(002)    VALUE ZEROS.*/
                public IntBasis W_DD_DATA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                  PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10  W-MM-DATA-2             PIC  9(002)    VALUE ZEROS.*/
                public IntBasis W_MM_DATA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                  PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10  W-AA-DATA-2             PIC  9(004)    VALUE ZEROS.*/
                public IntBasis W_AA_DATA_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CURR.*/
            }
            public SI0078B_WHORA_CURR WHORA_CURR { get; set; } = new SI0078B_WHORA_CURR();
            public class SI0078B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05       WK-HORA-2.*/
            }
            public SI0078B_WK_HORA_2 WK_HORA_2 { get; set; } = new SI0078B_WK_HORA_2();
            public class SI0078B_WK_HORA_2 : VarBasis
            {
                /*"     07    WK-HH-2             PIC 9(002)       VALUE ZEROS.*/
                public IntBasis WK_HH_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     07    FILLE               PIC X(001)       VALUE '.'.*/
                public StringBasis FILLE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"     07    WK-MM-2             PIC 9(002)       VALUE ZEROS.*/
                public IntBasis WK_MM_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     07    FILLE               PIC X(001)       VALUE '.'.*/
                public StringBasis FILLE_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"     07    WK-SS-2             PIC 9(002)       VALUE ZEROS.*/
                public IntBasis WK_SS_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05 CA-EF0101S.*/
                public SI0078B_CA_EF0101S CA_EF0101S { get; set; } = new SI0078B_CA_EF0101S();
                public class SI0078B_CA_EF0101S : VarBasis
                {
                    /*"       07 CA-NUM-CONTRATO-EF0101S  PIC S9(09)  COMP.*/
                    public IntBasis CA_NUM_CONTRATO_EF0101S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"       07 CA-SINI-DATORR-EF0101S   PIC  X(10).*/
                    public StringBasis CA_SINI_DATORR_EF0101S { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"       07 CA-DATA-CONTRATO-EF0101S PIC  X(10).*/
                    public StringBasis CA_DATA_CONTRATO_EF0101S { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"       07 CA-PRZ-VIGENCIA-EF0101S  PIC S9(04)  COMP.*/
                    public IntBasis CA_PRZ_VIGENCIA_EF0101S { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"       07 CA-SQLCODE-EF0101S       PIC S9(09)  COMP-4.*/
                    public IntBasis CA_SQLCODE_EF0101S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"    05 CA-EF0102S.*/
                }
                public SI0078B_CA_EF0102S CA_EF0102S { get; set; } = new SI0078B_CA_EF0102S();
                public class SI0078B_CA_EF0102S : VarBasis
                {
                    /*"       07 CA-NUM-CONTRATO-EF0102S  PIC S9(09) COMP.*/
                    public IntBasis CA_NUM_CONTRATO_EF0102S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"       07 CA-SINI-DATORR-EF0102S   PIC  X(10).*/
                    public StringBasis CA_SINI_DATORR_EF0102S { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"       07 CA-SQLCODE-EF0102S       PIC S9(09) COMP-4.*/
                    public IntBasis CA_SQLCODE_EF0102S { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"       07 CA-NOME-SEGURADO-EF0102S PIC  X(40).*/
                    public StringBasis CA_NOME_SEGURADO_EF0102S { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                    /*"  05   LC00.*/
                }
            }
        }
        public SI0078B_LC00 LC00 { get; set; } = new SI0078B_LC00();
        public class SI0078B_LC00 : VarBasis
        {
            /*"    10 LC00-RELATOR             PIC X(007) VALUE 'SI0078B'.*/
            public StringBasis LC00_RELATOR { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI0078B");
            /*"    10 FILLER                   PIC X(038) VALUE  SPACES.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
            /*"    10 LC00-EMPRESA             PIC X(040) VALUE       'SASSE - CIA NACIONAL DE SEGUROS GERAIS'.*/
            public StringBasis LC00_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SASSE - CIA NACIONAL DE SEGUROS GERAIS");
            /*"    10 FILLER                   PIC X(032) VALUE  SPACES.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
            /*"    10 FILLER                   PIC X(011) VALUE 'PAGINA '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA ");
            /*"    10 LC00-PAGINA              PIC ZZZ9.*/
            public IntBasis LC00_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
            /*"  03 LC01.*/
        }
        public SI0078B_LC01 LC01 { get; set; } = new SI0078B_LC01();
        public class SI0078B_LC01 : VarBasis
        {
            /*"    05 FILLER                        PIC  X(35)     VALUE SPACES*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"");
            /*"    05 FILLER                        PIC  X(42)     VALUE       'ACOMPANHAMENTO DA CARTEIRA HABITACIONAL - '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "42", "X(42)"), @"ACOMPANHAMENTO DA CARTEIRA HABITACIONAL - ");
            /*"    05 LC01-CARTEIRA                 PIC  X(06)     VALUE SPACES*/
            public StringBasis LC01_CARTEIRA { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"    05 FILLER                        PIC  X(34)     VALUE SPACES*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
            /*"    05 FILLER                        PIC  X(05)     VALUE       'DATA '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA ");
            /*"    05 LC01-DD-PROCESSAMENTO         PIC  9(02)     VALUE ZEROS.*/
            public IntBasis LC01_DD_PROCESSAMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 FILLER                        PIC  X(01)     VALUE '/'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
            /*"    05 LC01-MM-PROCESSAMENTO         PIC  9(02)     VALUE ZEROS.*/
            public IntBasis LC01_MM_PROCESSAMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 FILLER                        PIC  X(01)     VALUE '/'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
            /*"    05 LC01-AA-PROCESSAMENTO         PIC  9(04)     VALUE ZEROS.*/
            public IntBasis LC01_AA_PROCESSAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  03 LC02.*/
        }
        public SI0078B_LC02 LC02 { get; set; } = new SI0078B_LC02();
        public class SI0078B_LC02 : VarBasis
        {
            /*"    05 FILLER                        PIC  X(43)     VALUE SPACES*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "43", "X(43)"), @"");
            /*"    05 FILLER                        PIC  X(24)     VALUE       'PERIODO DE REFERENCIA - '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"PERIODO DE REFERENCIA - ");
            /*"    05 LC02-MES-REFERENCIA           PIC  X(03)     VALUE SPACES*/
            public StringBasis LC02_MES_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 FILLER                        PIC  X(03)     VALUE ' / '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" / ");
            /*"    05 LC02-ANO-REFERENCIA           PIC  9(04)     VALUE ZEROS.*/
            public IntBasis LC02_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05 FILLER                        PIC  X(40)     VALUE SPACES*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 FILLER                        PIC  X(07)     VALUE       'HORA: '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"HORA: ");
            /*"    05 LC02-HH-HORA                  PIC  9(02)     VALUE ZEROS.*/
            public IntBasis LC02_HH_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 FILLER                        PIC  X(01)     VALUE ':'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
            /*"    05 LC02-MM-HORA                  PIC  9(02)     VALUE ZEROS.*/
            public IntBasis LC02_MM_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 FILLER                        PIC  X(01)     VALUE ':'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
            /*"    05 LC02-SS-HORA                  PIC  9(02)     VALUE ZEROS.*/
            public IntBasis LC02_SS_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"  03 LC03.*/
        }
        public SI0078B_LC03 LC03 { get; set; } = new SI0078B_LC03();
        public class SI0078B_LC03 : VarBasis
        {
            /*"    05 FILLER                        PIC  X(132)   VALUE ALL '-'*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
            /*"  03    LC04.*/
        }
        public SI0078B_LC04 LC04 { get; set; } = new SI0078B_LC04();
        public class SI0078B_LC04 : VarBasis
        {
            /*"    05  FILLER                   PIC  X(010) VALUE        'SIN. SASSE'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SIN. SASSE");
            /*"    05  FILLER                   PIC  X(004) VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    05  FILLER                   PIC  X(018) VALUE        'SEGURADO PRINCIPAL'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"SEGURADO PRINCIPAL");
            /*"    05  FILLER                   PIC  X(023) VALUE SPACES.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
            /*"    05  FILLER                   PIC  X(013) VALUE        'DATA CONTRATO'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DATA CONTRATO");
            /*"    05  FILLER                   PIC  X(003) VALUE SPACES.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  FILLER                   PIC  X(005) VALUE        'AVISO'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"AVISO");
            /*"    05  FILLER                   PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"    05  FILLER                   PIC  X(013) VALUE        'TIPO SINISTRO'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"TIPO SINISTRO");
            /*"    05  FILLER                   PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"    05  FILLER                   PIC  X(017) VALUE        'CAUSA DO SINISTRO'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"CAUSA DO SINISTRO");
            /*"    05  FILLER                   PIC  X(012) VALUE SPACES.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  03    LC05.*/
        }
        public SI0078B_LC05 LC05 { get; set; } = new SI0078B_LC05();
        public class SI0078B_LC05 : VarBasis
        {
            /*"    05  FILLER                   PIC  X(008) VALUE        'SIN. IRB'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SIN. IRB");
            /*"    05  FILLER                   PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"    05  FILLER                   PIC  X(021) VALUE        'SEGURADO PARTICIPANTE'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"SEGURADO PARTICIPANTE");
            /*"    05  FILLER                   PIC  X(020) VALUE SPACES.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"    05  FILLER                   PIC  X(014) VALUE        'PRAZO CONTRATO'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"PRAZO CONTRATO");
            /*"    05  FILLER                   PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05  FILLER                   PIC  X(010) VALUE        'OCORRENCIA'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"OCORRENCIA");
            /*"    05  FILLER                   PIC  X(051) VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"");
            /*"  03    LC06.*/
        }
        public SI0078B_LC06 LC06 { get; set; } = new SI0078B_LC06();
        public class SI0078B_LC06 : VarBasis
        {
            /*"    05  FILLER                   PIC  X(004) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    05  FILLER                   PIC  X(013) VALUE        'NUM. FIAP'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NUM. FIAP");
            /*"    05  FILLER                   PIC  X(020) VALUE SPACES.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"    05  FILLER                   PIC  X(004) VALUE        'DATA'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"DATA");
            /*"    05  FILLER                   PIC  X(003) VALUE SPACES.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  FILLER                   PIC  X(008) VALUE        'OPERACAO'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"OPERACAO");
            /*"    05  FILLER                   PIC  X(023) VALUE SPACES.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
            /*"    05  FILLER                   PIC  X(010) VALUE        'FAVORECIDO'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"FAVORECIDO");
            /*"    05  FILLER                   PIC  X(021) VALUE SPACES.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
            /*"    05  FILLER                   PIC  X(008) VALUE        'ANALISTA'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"ANALISTA");
            /*"    05  FILLER                   PIC  X(013) VALUE SPACES.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
            /*"    05  FILLER                   PIC  X(014) VALUE        'VALOR'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"VALOR");
            /*"  03    LD01.*/
        }
        public SI0078B_LD01 LD01 { get; set; } = new SI0078B_LD01();
        public class SI0078B_LD01 : VarBasis
        {
            /*"    05  LD01-NUM-APOL-SINISTRO            PIC 9(13) VALUE ZEROS.*/
            public IntBasis LD01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05  FILLER                            PIC X(01) VALUE SPACES*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  LD01-NM-SEGUR1                    PIC X(40) VALUE SPACES*/
            public StringBasis LD01_NM_SEGUR1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05  FILLER                            PIC X(01) VALUE SPACES*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  LD01-DATA-CONTRATO                PIC X(10) VALUE SPACES*/
            public StringBasis LD01_DATA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05  FILLER                            PIC X(05) VALUE SPACES*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"    05  LD01-DATA-AVISO                   PIC X(10) VALUE SPACES*/
            public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05  FILLER                            PIC X(06) VALUE SPACES*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"    05  LD01-TIPO-SINISTRO                PIC X(06) VALUE SPACES*/
            public StringBasis LD01_TIPO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"    05  FILLER                            PIC X(10) VALUE SPACES*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05  LD01-CAUSA-SINISTRO               PIC X(30) VALUE SPACES*/
            public StringBasis LD01_CAUSA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  03    LD02.*/
        }
        public SI0078B_LD02 LD02 { get; set; } = new SI0078B_LD02();
        public class SI0078B_LD02 : VarBasis
        {
            /*"    05  LD02-NUMIRB                       PIC ZZZ.ZZZ.*/
            public StringBasis LD02_NUMIRB { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ.ZZZ."), @"");
            /*"    05  FILLER                            PIC X(07) VALUE SPACES*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
            /*"    05  LD02-NM-SEGUR2                    PIC X(40) VALUE SPACES*/
            public StringBasis LD02_NM_SEGUR2 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05  FILLER                            PIC X(03) VALUE SPACES*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05  LD02-PRAZO-CONTRATO               PIC ZZ.ZZZ.*/
            public StringBasis LD02_PRAZO_CONTRATO { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ."), @"");
            /*"    05  FILLER                            PIC X(07) VALUE SPACES*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
            /*"    05  LD02-DATA-OCORRENCIA              PIC X(10) VALUE SPACES*/
            public StringBasis LD02_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05  FILLER                            PIC X(22) VALUE SPACES*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"");
            /*"    05  FILLER                            PIC X(10) VALUE        'SITUACAO: '.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SITUACAO: ");
            /*"    05  LD02-SITUACAO                     PIC X(20) VALUE SPACES*/
            public StringBasis LD02_SITUACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"  03    LD03.*/
        }
        public SI0078B_LD03 LD03 { get; set; } = new SI0078B_LD03();
        public class SI0078B_LD03 : VarBasis
        {
            /*"    05  LD03-NUM-FIAP                     PIC ZZZZZZZZZZZZZ.*/
            public StringBasis LD03_NUM_FIAP { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
            /*"    05  FILLER                            PIC X(20) VALUE SPACES*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    05  LD03-DTMOVTO                      PIC X(10) VALUE SPACES*/
            public StringBasis LD03_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05  FILLER                            PIC X(01) VALUE SPACES*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  LD03-OPERACAO                     PIC X(30) VALUE SPACES*/
            public StringBasis LD03_OPERACAO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05  FILLER                            PIC X(01) VALUE SPACES*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  LD03-FAVORECIDO                   PIC X(30) VALUE SPACES*/
            public StringBasis LD03_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05  FILLER                            PIC X(01) VALUE SPACES*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  LD03-ANALISTA                     PIC X(08) VALUE SPACES*/
            public StringBasis LD03_ANALISTA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05  FILLER                            PIC X(01) VALUE SPACES*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  LD03-VALOR                        PIC ZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis LD03_VALOR { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  03 LT01.*/
        }
        public SI0078B_LT01 LT01 { get; set; } = new SI0078B_LT01();
        public class SI0078B_LT01 : VarBasis
        {
            /*"    05  FILLER                           PIC X(112) VALUE SPACES*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
            /*"    05  LT01-VALOR                       PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis LT01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
        }
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03        WABEND.*/
        public SI0078B_WABEND WABEND { get; set; } = new SI0078B_WABEND();
        public class SI0078B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(007) VALUE           'SI0078B'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI0078B");
            /*"    05      FILLER              PIC  X(030) VALUE           ' *** ERRO  EXEC SQL  NUMERO = '.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" *** ERRO  EXEC SQL  NUMERO = ");
            /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    05      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           ' SQLCODE1= '.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           ' SQLCODE2= '.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01 WDATA1-DB2  PIC X(010).*/
        }
        public StringBasis WDATA1_DB2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01 WDATA1-DB2R REDEFINES WDATA1-DB2.*/
        private _REDEF_SI0078B_WDATA1_DB2R _wdata1_db2r { get; set; }
        public _REDEF_SI0078B_WDATA1_DB2R WDATA1_DB2R
        {
            get { _wdata1_db2r = new _REDEF_SI0078B_WDATA1_DB2R(); _.Move(WDATA1_DB2, _wdata1_db2r); VarBasis.RedefinePassValue(WDATA1_DB2, _wdata1_db2r, WDATA1_DB2); _wdata1_db2r.ValueChanged += () => { _.Move(_wdata1_db2r, WDATA1_DB2); }; return _wdata1_db2r; }
            set { VarBasis.RedefinePassValue(value, _wdata1_db2r, WDATA1_DB2); }
        }  //Redefines
        public class _REDEF_SI0078B_WDATA1_DB2R : VarBasis
        {
            /*"  05        WDATA1-ANO           PIC  9(004)      VALUE ZEROS.*/
            public IntBasis WDATA1_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        FILLER               PIC  X(001)      VALUE '-'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        WDATA1-MES           PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WDATA1_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05        FILLER               PIC  X(001)      VALUE '-'.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        WDATA1-DIA           PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WDATA1_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01 WDATA2-DB2  PIC X(010).*/

            public _REDEF_SI0078B_WDATA1_DB2R()
            {
                WDATA1_ANO.ValueChanged += OnValueChanged;
                FILLER_77.ValueChanged += OnValueChanged;
                WDATA1_MES.ValueChanged += OnValueChanged;
                FILLER_78.ValueChanged += OnValueChanged;
                WDATA1_DIA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WDATA2_DB2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01 WDATA2-DB2R REDEFINES WDATA2-DB2.*/
        private _REDEF_SI0078B_WDATA2_DB2R _wdata2_db2r { get; set; }
        public _REDEF_SI0078B_WDATA2_DB2R WDATA2_DB2R
        {
            get { _wdata2_db2r = new _REDEF_SI0078B_WDATA2_DB2R(); _.Move(WDATA2_DB2, _wdata2_db2r); VarBasis.RedefinePassValue(WDATA2_DB2, _wdata2_db2r, WDATA2_DB2); _wdata2_db2r.ValueChanged += () => { _.Move(_wdata2_db2r, WDATA2_DB2); }; return _wdata2_db2r; }
            set { VarBasis.RedefinePassValue(value, _wdata2_db2r, WDATA2_DB2); }
        }  //Redefines
        public class _REDEF_SI0078B_WDATA2_DB2R : VarBasis
        {
            /*"  05        WDATA2-ANO           PIC  9(004)      VALUE ZEROS.*/
            public IntBasis WDATA2_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        FILLER               PIC  X(001)      VALUE '-'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        WDATA2-MES           PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WDATA2_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05        FILLER               PIC  X(001)      VALUE '-'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        WDATA2-DIA           PIC  9(002)      VALUE ZEROS .*/
            public IntBasis WDATA2_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));

            public _REDEF_SI0078B_WDATA2_DB2R()
            {
                WDATA2_ANO.ValueChanged += OnValueChanged;
                FILLER_79.ValueChanged += OnValueChanged;
                WDATA2_MES.ValueChanged += OnValueChanged;
                FILLER_80.ValueChanged += OnValueChanged;
                WDATA2_DIA.ValueChanged += OnValueChanged;
            }

        }


        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public SI0078B_V0RELATORIOS V0RELATORIOS { get; set; } = new SI0078B_V0RELATORIOS();
        public SI0078B_V0HISTSINI V0HISTSINI { get; set; } = new SI0078B_V0HISTSINI();
        public SI0078B_SINISTROS SINISTROS { get; set; } = new SI0078B_SINISTROS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0078BR_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0078BR.SetFile(SI0078BR_FILE_NAME_P);

                /*" -467- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -469- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -471- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -476- MOVE '000' TO WNR-EXEC-SQL. */
                _.Move("000", WABEND.WNR_EXEC_SQL);

                /*" -481- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -484- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -485- DISPLAY 'PROBLEMA NO SELECT DA V1SISTEMA .........' */
                    _.Display($"PROBLEMA NO SELECT DA V1SISTEMA .........");

                    /*" -487- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return Result;
                }


                /*" -488- PERFORM 000-DECLARE-V0RELATORIOS THRU 000-EXIT. */

                M_000_DECLARE_V0RELATORIOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_EXIT*/


                /*" -489- MOVE 'NAO' TO WFIM-V0RELATORIOS. */
                _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS);

                /*" -491- PERFORM 010-FETCH-V0RELATORIOS THRU 010-EXIT. */

                M_010_FETCH_V0RELATORIOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/


                /*" -492- IF WFIM-V0RELATORIOS EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS == "SIM")
                {

                    /*" -493- DISPLAY '/////////////////////////////////////////' */
                    _.Display($"/////////////////////////////////////////");

                    /*" -494- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -495- DISPLAY '//     ==>     SI0078B      <==        //' */
                    _.Display($"//     ==>     SI0078B      <==        //");

                    /*" -496- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -497- DISPLAY '// ==>  NAO HOUVE SOLICITACAO PARA <== //' */
                    _.Display($"// ==>  NAO HOUVE SOLICITACAO PARA <== //");

                    /*" -498- DISPLAY '// ==>  EXECUCAO DO PROGRAMA NA    <== //' */
                    _.Display($"// ==>  EXECUCAO DO PROGRAMA NA    <== //");

                    /*" -499- DISPLAY '// ==>  V0RELATORIOS               <== //' */
                    _.Display($"// ==>  V0RELATORIOS               <== //");

                    /*" -500- DISPLAY '//                                     //' */
                    _.Display($"//                                     //");

                    /*" -501- DISPLAY '/////////////////////////////////////////' */
                    _.Display($"/////////////////////////////////////////");

                    /*" -503- GO TO 0000-99-ENCERRA. */

                    M_0000_99_ENCERRA(); //GOTO
                    return Result;
                }


                /*" -505- OPEN OUTPUT SI0078BR. */
                SI0078BR.Open(REG_SI0078BR);

                /*" -508- PERFORM M-020-PROCESSA-V0RELATORIOS THRU 020-EXIT UNTIL (WFIM-V0RELATORIOS EQUAL 'SIM' ). */

                while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS == "SIM")))
                {

                    M_020_PROCESSA_V0RELATORIOS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/

                }

                /*" -510- CLOSE SI0078BR. */
                SI0078BR.Close();

                /*" -512- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND.WNR_EXEC_SQL);

                /*" -515- PERFORM Execute_DB_DELETE_1 */

                Execute_DB_DELETE_1();

                /*" -519- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
                {

                    /*" -520- DISPLAY 'PROBLEMA NO DELETE DA V0RELATORIOS ........' */
                    _.Display($"PROBLEMA NO DELETE DA V0RELATORIOS ........");

                    /*" -522- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return Result;
                }


                /*" -524- MOVE '002' TO WNR-EXEC-SQL. */
                _.Move("002", WABEND.WNR_EXEC_SQL);

                /*" -524- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -526- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -527- DISPLAY 'ERRO ACESSO COMMIT' */
                    _.Display($"ERRO ACESSO COMMIT");

                    /*" -527- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return Result;
                }


                /*" -527- FLUXCONTROL_PERFORM Execute-DB-SELECT-1 */

                Execute_DB_SELECT_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -481- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SISTEMA-DTMOVABE, :V1SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEMA_DTMOVABE, V1SISTEMA_DTMOVABE);
                _.Move(executed_1.V1SISTEMA_DTCURRENT, V1SISTEMA_DTCURRENT);
            }


        }

        [StopWatch]
        /*" Execute-DB-DELETE-1 */
        public void Execute_DB_DELETE_1()
        {
            /*" -515- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0078B' END-EXEC. */

            var execute_DB_DELETE_1_Delete1 = new Execute_DB_DELETE_1_Delete1()
            {
            };

            Execute_DB_DELETE_1_Delete1.Execute(execute_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" M-0000-99-ENCERRA */
        private void M_0000_99_ENCERRA(bool isPerform = false)
        {
            /*" -531- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -532- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -533- DISPLAY '//     ==>     SI0078B      <==        //' */
            _.Display($"//     ==>     SI0078B      <==        //");

            /*" -534- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
            _.Display($"//     ==>  TERMINO NORMAL  <==        //");

            /*" -535- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -536- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -537- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -537- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-000-DECLARE-V0RELATORIOS */
        private void M_000_DECLARE_V0RELATORIOS(bool isPerform = false)
        {
            /*" -544- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WABEND.WNR_EXEC_SQL);

            /*" -549- PERFORM M_000_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            M_000_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -552- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -553- DISPLAY 'PROBLEMA NO DECLARE DA V0RELATORIOS ........' */
                _.Display($"PROBLEMA NO DECLARE DA V0RELATORIOS ........");

                /*" -555- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -555- PERFORM M_000_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            M_000_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -558- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -559- DISPLAY 'PROBLEMAS OPEN V0RELATORIOS ............' */
                _.Display($"PROBLEMAS OPEN V0RELATORIOS ............");

                /*" -559- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void M_000_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -549- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT ANO_REFERENCIA , MES_REFERENCIA FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0078B' END-EXEC. */
            V0RELATORIOS = new SI0078B_V0RELATORIOS(false);
            string GetQuery_V0RELATORIOS()
            {
                var query = @$"SELECT ANO_REFERENCIA
							, 
							MES_REFERENCIA 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = 'SI0078B'";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }

        [StopWatch]
        /*" M-000-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void M_000_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -555- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-100-DECLARE-V0HISTSINI-DB-DECLARE-1 */
        public void M_100_DECLARE_V0HISTSINI_DB_DECLARE_1()
        {
            /*" -643- EXEC SQL DECLARE V0HISTSINI CURSOR FOR SELECT DISTINCT NUM_APOL_SINISTRO FROM SEGUROS.V0HISTSINI WHERE DTMOVTO BETWEEN :WDATA1-DB2 AND :WDATA2-DB2 AND NUM_APOL_SINISTRO BETWEEN 0106100000001 AND 0106199999999 AND NUM_APOL_SINISTRO BETWEEN 0106500000001 AND 0106599999999 AND NUM_APOL_SINISTRO BETWEEN 0106800000001 AND 0106899999999 ORDER BY NUM_APOL_SINISTRO END-EXEC. */
            V0HISTSINI = new SI0078B_V0HISTSINI(true);
            string GetQuery_V0HISTSINI()
            {
                var query = @$"SELECT DISTINCT NUM_APOL_SINISTRO 
							FROM SEGUROS.V0HISTSINI 
							WHERE DTMOVTO BETWEEN '{WDATA1_DB2}' 
							AND '{WDATA2_DB2}' 
							AND NUM_APOL_SINISTRO BETWEEN 0106100000001 
							AND 0106199999999 
							AND NUM_APOL_SINISTRO BETWEEN 0106500000001 
							AND 0106599999999 
							AND NUM_APOL_SINISTRO BETWEEN 0106800000001 
							AND 0106899999999 
							ORDER BY NUM_APOL_SINISTRO";

                return query;
            }
            V0HISTSINI.GetQueryEvent += GetQuery_V0HISTSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_EXIT*/

        [StopWatch]
        /*" M-010-FETCH-V0RELATORIOS */
        private void M_010_FETCH_V0RELATORIOS(bool isPerform = false)
        {
            /*" -567- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND.WNR_EXEC_SQL);

            /*" -570- PERFORM M_010_FETCH_V0RELATORIOS_DB_FETCH_1 */

            M_010_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -573- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -574- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -575- DISPLAY '*      SOLICITACAO LIDA DA V0RELATORIOS       *' */
                _.Display($"*      SOLICITACAO LIDA DA V0RELATORIOS       *");

                /*" -576- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -578- DISPLAY '* ANO DE REFERENCIA = ' V0RELATORIOS-ANO-REFERENCIA */
                _.Display($"* ANO DE REFERENCIA = {V0RELATORIOS_ANO_REFERENCIA}");

                /*" -580- DISPLAY '* MES DE REFERENCIA = ' V0RELATORIOS-MES-REFERENCIA */
                _.Display($"* MES DE REFERENCIA = {V0RELATORIOS_MES_REFERENCIA}");

                /*" -582- MOVE ZEROS TO W-AC-PAGINA. */
                _.Move(0, AREA_DE_WORK.W_AC_PAGINA);
            }


            /*" -583- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -584- MOVE 'SIM' TO WFIM-V0RELATORIOS */
                _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0RELATORIOS);

                /*" -584- PERFORM M_010_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                M_010_FETCH_V0RELATORIOS_DB_CLOSE_1();

                /*" -586- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -587- DISPLAY 'PROBLEMAS CLOSE DA V0RELATORIOS ........' */
                    _.Display($"PROBLEMAS CLOSE DA V0RELATORIOS ........");

                    /*" -589- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -591- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -592- DISPLAY 'PROBLEMAS FETCH V0RELATORIOS ........' */
                _.Display($"PROBLEMAS FETCH V0RELATORIOS ........");

                /*" -592- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-010-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void M_010_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -570- EXEC SQL FETCH V0RELATORIOS INTO :V0RELATORIOS-ANO-REFERENCIA , :V0RELATORIOS-MES-REFERENCIA END-EXEC. */

            if (V0RELATORIOS.Fetch())
            {
                _.Move(V0RELATORIOS.V0RELATORIOS_ANO_REFERENCIA, V0RELATORIOS_ANO_REFERENCIA);
                _.Move(V0RELATORIOS.V0RELATORIOS_MES_REFERENCIA, V0RELATORIOS_MES_REFERENCIA);
            }

        }

        [StopWatch]
        /*" M-010-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void M_010_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -584- EXEC SQL CLOSE V0RELATORIOS END-EXEC */

            V0RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/

        [StopWatch]
        /*" M-020-PROCESSA-V0RELATORIOS */
        private void M_020_PROCESSA_V0RELATORIOS(bool isPerform = false)
        {
            /*" -599- PERFORM 100-DECLARE-V0HISTSINI THRU 100-EXIT. */

            M_100_DECLARE_V0HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/


            /*" -600- MOVE 'NAO' TO WFIM-V0HISTSINI. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0HISTSINI);

            /*" -602- PERFORM 110-FETCH-V0HISTSINI THRU 110-EXIT. */

            M_110_FETCH_V0HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_EXIT*/


            /*" -603- IF WFIM-V0HISTSINI EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0HISTSINI == "SIM")
            {

                /*" -604- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -605- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -606- DISPLAY '//     ==>     SI0078B      <==        //' */
                _.Display($"//     ==>     SI0078B      <==        //");

                /*" -607- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -608- DISPLAY '// ==>  NENHUMA MOVIMENTACAO EXIS- <== //' */
                _.Display($"// ==>  NENHUMA MOVIMENTACAO EXIS- <== //");

                /*" -609- DISPLAY '// ==>  TENTE NA V0HISTSINI PARA O <== //' */
                _.Display($"// ==>  TENTE NA V0HISTSINI PARA O <== //");

                /*" -610- DISPLAY '// ==>  MES E ANO SOLICITADO.      <== //' */
                _.Display($"// ==>  MES E ANO SOLICITADO.      <== //");

                /*" -611- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -612- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -614- GO TO 0000-99-ENCERRA. */

                M_0000_99_ENCERRA(); //GOTO
                return;
            }


            /*" -616- PERFORM 910-MONTA-CABECALHO THRU 910-EXIT. */

            M_910_MONTA_CABECALHO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_910_EXIT*/


            /*" -619- PERFORM 150-PROCESSA-V0HISTSINI THRU 150-EXIT UNTIL (WFIM-V0HISTSINI EQUAL 'SIM' ). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0HISTSINI == "SIM")))
            {

                M_150_PROCESSA_V0HISTSINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_EXIT*/

            }

            /*" -619- PERFORM 010-FETCH-V0RELATORIOS THRU 010-EXIT. */

            M_010_FETCH_V0RELATORIOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/

        [StopWatch]
        /*" M-100-DECLARE-V0HISTSINI */
        private void M_100_DECLARE_V0HISTSINI(bool isPerform = false)
        {
            /*" -627- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND.WNR_EXEC_SQL);

            /*" -629- PERFORM 101-MONTA-DATA THRU 101-EXIT. */

            M_101_MONTA_DATA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_101_EXIT*/


            /*" -643- PERFORM M_100_DECLARE_V0HISTSINI_DB_DECLARE_1 */

            M_100_DECLARE_V0HISTSINI_DB_DECLARE_1();

            /*" -646- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -647- DISPLAY 'PROBLEMA NO DECLARE DA V0HISTSINI ..........' */
                _.Display($"PROBLEMA NO DECLARE DA V0HISTSINI ..........");

                /*" -649- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -649- PERFORM M_100_DECLARE_V0HISTSINI_DB_OPEN_1 */

            M_100_DECLARE_V0HISTSINI_DB_OPEN_1();

            /*" -652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -653- DISPLAY 'PROBLEMAS OPEN V0HISTSINI  .............' */
                _.Display($"PROBLEMAS OPEN V0HISTSINI  .............");

                /*" -653- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-100-DECLARE-V0HISTSINI-DB-OPEN-1 */
        public void M_100_DECLARE_V0HISTSINI_DB_OPEN_1()
        {
            /*" -649- EXEC SQL OPEN V0HISTSINI END-EXEC. */

            V0HISTSINI.Open();

        }

        [StopWatch]
        /*" M-300-DECLARE-SINISTRO-DB-DECLARE-1 */
        public void M_300_DECLARE_SINISTRO_DB_DECLARE_1()
        {
            /*" -743- EXEC SQL DECLARE SINISTROS CURSOR FOR SELECT M.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.NUMIRB, M.CODCAU, M.DATCMD, M.DATORR, M.SITUACAO, M.RAMO, H.OCORHIST, H.OPERACAO, H.DTMOVTO, H.VAL_OPERACAO, H.NOMFAV, H.CODUSU FROM SEGUROS.V0HISTSINI H, SEGUROS.V0MESTSINI M WHERE M.NUM_APOL_SINISTRO = :V0HISTSINI-NUM-APOL-SINISTRO AND H.NUM_APOL_SINISTRO = :V0HISTSINI-NUM-APOL-SINISTRO AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND M.NUM_APOLICE = 0106500000001 ORDER BY M.NUM_APOL_SINISTRO, H.OCORHIST END-EXEC. */
            SINISTROS = new SI0078B_SINISTROS(true);
            string GetQuery_SINISTROS()
            {
                var query = @$"SELECT M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.NUMIRB
							, 
							M.CODCAU
							, 
							M.DATCMD
							, 
							M.DATORR
							, 
							M.SITUACAO
							, 
							M.RAMO
							, 
							H.OCORHIST
							, 
							H.OPERACAO
							, 
							H.DTMOVTO
							, 
							H.VAL_OPERACAO
							, 
							H.NOMFAV
							, 
							H.CODUSU 
							FROM SEGUROS.V0HISTSINI H
							, 
							SEGUROS.V0MESTSINI M 
							WHERE M.NUM_APOL_SINISTRO = 
							'{V0HISTSINI_NUM_APOL_SINISTRO}' 
							AND H.NUM_APOL_SINISTRO = 
							'{V0HISTSINI_NUM_APOL_SINISTRO}' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND M.NUM_APOLICE = 0106500000001 
							ORDER BY M.NUM_APOL_SINISTRO
							, H.OCORHIST";

                return query;
            }
            SINISTROS.GetQueryEvent += GetQuery_SINISTROS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/

        [StopWatch]
        /*" M-101-MONTA-DATA */
        private void M_101_MONTA_DATA(bool isPerform = false)
        {
            /*" -660- MOVE V0RELATORIOS-ANO-REFERENCIA TO WDATA1-ANO WDATA2-ANO. */
            _.Move(V0RELATORIOS_ANO_REFERENCIA, WDATA1_DB2R.WDATA1_ANO);
            _.Move(V0RELATORIOS_ANO_REFERENCIA, WDATA2_DB2R.WDATA2_ANO);


            /*" -662- MOVE V0RELATORIOS-MES-REFERENCIA TO WDATA1-MES WDATA2-MES. */
            _.Move(V0RELATORIOS_MES_REFERENCIA, WDATA1_DB2R.WDATA1_MES);
            _.Move(V0RELATORIOS_MES_REFERENCIA, WDATA2_DB2R.WDATA2_MES);


            /*" -664- MOVE 1 TO WDATA1-DIA. */
            _.Move(1, WDATA1_DB2R.WDATA1_DIA);

            /*" -666- IF WDATA1-MES EQUAL 1 OR 3 OR 5 OR 7 OR 8 OR 10 OR 12 */

            if (WDATA1_DB2R.WDATA1_MES.In("1", "3", "5", "7", "8", "10", "12"))
            {

                /*" -667- MOVE 31 TO WDATA2-DIA */
                _.Move(31, WDATA2_DB2R.WDATA2_DIA);

                /*" -668- ELSE */
            }
            else
            {


                /*" -669- IF WDATA1-MES EQUAL 4 OR 6 OR 9 OR 11 */

                if (WDATA1_DB2R.WDATA1_MES.In("4", "6", "9", "11"))
                {

                    /*" -670- MOVE 30 TO WDATA2-DIA */
                    _.Move(30, WDATA2_DB2R.WDATA2_DIA);

                    /*" -671- ELSE */
                }
                else
                {


                    /*" -672- DIVIDE WDATA1-ANO BY 4 GIVING J REMAINDER WRESTO */
                    _.Divide(WDATA1_DB2R.WDATA1_ANO, 4, J, WRESTO);

                    /*" -673- IF WRESTO EQUAL ZEROS */

                    if (WRESTO == 00)
                    {

                        /*" -674- MOVE 29 TO WDATA2-DIA */
                        _.Move(29, WDATA2_DB2R.WDATA2_DIA);

                        /*" -675- ELSE */
                    }
                    else
                    {


                        /*" -676- MOVE 28 TO WDATA2-DIA. */
                        _.Move(28, WDATA2_DB2R.WDATA2_DIA);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_101_EXIT*/

        [StopWatch]
        /*" M-110-FETCH-V0HISTSINI */
        private void M_110_FETCH_V0HISTSINI(bool isPerform = false)
        {
            /*" -683- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WABEND.WNR_EXEC_SQL);

            /*" -685- PERFORM M_110_FETCH_V0HISTSINI_DB_FETCH_1 */

            M_110_FETCH_V0HISTSINI_DB_FETCH_1();

            /*" -688- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -689- MOVE 'SIM' TO WFIM-V0HISTSINI */
                _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_V0HISTSINI);

                /*" -689- PERFORM M_110_FETCH_V0HISTSINI_DB_CLOSE_1 */

                M_110_FETCH_V0HISTSINI_DB_CLOSE_1();

                /*" -691- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -692- DISPLAY 'PROBLEMAS CLOSE DA V0HISTSINI ..........' */
                    _.Display($"PROBLEMAS CLOSE DA V0HISTSINI ..........");

                    /*" -694- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -696- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -697- DISPLAY 'PROBLEMAS FETCH V0HISTSINI  .........' */
                _.Display($"PROBLEMAS FETCH V0HISTSINI  .........");

                /*" -697- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-110-FETCH-V0HISTSINI-DB-FETCH-1 */
        public void M_110_FETCH_V0HISTSINI_DB_FETCH_1()
        {
            /*" -685- EXEC SQL FETCH V0HISTSINI INTO :V0HISTSINI-NUM-APOL-SINISTRO END-EXEC. */

            if (V0HISTSINI.Fetch())
            {
                _.Move(V0HISTSINI.V0HISTSINI_NUM_APOL_SINISTRO, V0HISTSINI_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" M-110-FETCH-V0HISTSINI-DB-CLOSE-1 */
        public void M_110_FETCH_V0HISTSINI_DB_CLOSE_1()
        {
            /*" -689- EXEC SQL CLOSE V0HISTSINI END-EXEC */

            V0HISTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_EXIT*/

        [StopWatch]
        /*" M-150-PROCESSA-V0HISTSINI */
        private void M_150_PROCESSA_V0HISTSINI(bool isPerform = false)
        {
            /*" -704- PERFORM 300-DECLARE-SINISTRO THRU 300-EXIT. */

            M_300_DECLARE_SINISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_EXIT*/


            /*" -705- MOVE 'NAO' TO WFIM-SINISTROS. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_SINISTROS);

            /*" -707- PERFORM 310-FETCH-SINISTRO THRU 310-EXIT. */

            M_310_FETCH_SINISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_EXIT*/


            /*" -710- PERFORM 320-PROCESSA-SINISTRO THRU 320-EXIT UNTIL (WFIM-SINISTROS EQUAL 'SIM' ). */

            while (!((AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_SINISTROS == "SIM")))
            {

                M_320_PROCESSA_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_320_EXIT*/

            }

            /*" -710- PERFORM 110-FETCH-V0HISTSINI THRU 110-EXIT. */

            M_110_FETCH_V0HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_EXIT*/

        [StopWatch]
        /*" M-300-DECLARE-SINISTRO */
        private void M_300_DECLARE_SINISTRO(bool isPerform = false)
        {
            /*" -718- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WABEND.WNR_EXEC_SQL);

            /*" -743- PERFORM M_300_DECLARE_SINISTRO_DB_DECLARE_1 */

            M_300_DECLARE_SINISTRO_DB_DECLARE_1();

            /*" -746- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -747- DISPLAY 'PROBLEMA NO DECLARE DA V0HISTSINI ..........' */
                _.Display($"PROBLEMA NO DECLARE DA V0HISTSINI ..........");

                /*" -748- DISPLAY 'NO PARAGRAFO => DECLARE SINISTROS ..........' */
                _.Display($"NO PARAGRAFO => DECLARE SINISTROS ..........");

                /*" -750- DISPLAY 'SINISTRO PROCESSADO = ' V0HISTSINI-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO PROCESSADO = {V0HISTSINI_NUM_APOL_SINISTRO}");

                /*" -752- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -752- PERFORM M_300_DECLARE_SINISTRO_DB_OPEN_1 */

            M_300_DECLARE_SINISTRO_DB_OPEN_1();

            /*" -755- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -756- DISPLAY 'PROBLEMAS OPEN V0HISTSINI  .............' */
                _.Display($"PROBLEMAS OPEN V0HISTSINI  .............");

                /*" -757- DISPLAY 'NO PARAGRAFO => DECLARE SINISTROS ..........' */
                _.Display($"NO PARAGRAFO => DECLARE SINISTROS ..........");

                /*" -757- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-300-DECLARE-SINISTRO-DB-OPEN-1 */
        public void M_300_DECLARE_SINISTRO_DB_OPEN_1()
        {
            /*" -752- EXEC SQL OPEN SINISTROS END-EXEC. */

            SINISTROS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_EXIT*/

        [StopWatch]
        /*" M-310-FETCH-SINISTRO */
        private void M_310_FETCH_SINISTRO(bool isPerform = false)
        {
            /*" -765- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WABEND.WNR_EXEC_SQL);

            /*" -780- PERFORM M_310_FETCH_SINISTRO_DB_FETCH_1 */

            M_310_FETCH_SINISTRO_DB_FETCH_1();

            /*" -783- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -784- MOVE 'SIM' TO WFIM-SINISTROS */
                _.Move("SIM", AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_SINISTROS);

                /*" -784- PERFORM M_310_FETCH_SINISTRO_DB_CLOSE_1 */

                M_310_FETCH_SINISTRO_DB_CLOSE_1();

                /*" -786- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -787- DISPLAY 'PROBLEMAS CLOSE DO CURSOR SINISTROS ....' */
                    _.Display($"PROBLEMAS CLOSE DO CURSOR SINISTROS ....");

                    /*" -789- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -791- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -792- DISPLAY 'PROBLEMAS FETCH DO CURSOR SINISTROS .....' */
                _.Display($"PROBLEMAS FETCH DO CURSOR SINISTROS .....");

                /*" -792- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-310-FETCH-SINISTRO-DB-FETCH-1 */
        public void M_310_FETCH_SINISTRO_DB_FETCH_1()
        {
            /*" -780- EXEC SQL FETCH SINISTROS INTO :SINI-NUM-APOL-SINISTRO, :SINI-NUM-APOLICE, :SINI-NUMIRB, :SINI-CODCAU, :SINI-DATCMD, :SINI-DATORR, :SINI-SITUACAO, :SINI-RAMO, :SINI-OCORHIST, :SINI-OPERACAO, :SINI-DTMOVTO, :SINI-VAL-OPERACAO, :SINI-NOMFAV, :SINI-CODUSU END-EXEC. */

            if (SINISTROS.Fetch())
            {
                _.Move(SINISTROS.SINI_NUM_APOL_SINISTRO, SINI_NUM_APOL_SINISTRO);
                _.Move(SINISTROS.SINI_NUM_APOLICE, SINI_NUM_APOLICE);
                _.Move(SINISTROS.SINI_NUMIRB, SINI_NUMIRB);
                _.Move(SINISTROS.SINI_CODCAU, SINI_CODCAU);
                _.Move(SINISTROS.SINI_DATCMD, SINI_DATCMD);
                _.Move(SINISTROS.SINI_DATORR, SINI_DATORR);
                _.Move(SINISTROS.SINI_SITUACAO, SINI_SITUACAO);
                _.Move(SINISTROS.SINI_RAMO, SINI_RAMO);
                _.Move(SINISTROS.SINI_OCORHIST, SINI_OCORHIST);
                _.Move(SINISTROS.SINI_OPERACAO, SINI_OPERACAO);
                _.Move(SINISTROS.SINI_DTMOVTO, SINI_DTMOVTO);
                _.Move(SINISTROS.SINI_VAL_OPERACAO, SINI_VAL_OPERACAO);
                _.Move(SINISTROS.SINI_NOMFAV, SINI_NOMFAV);
                _.Move(SINISTROS.SINI_CODUSU, SINI_CODUSU);
            }

        }

        [StopWatch]
        /*" M-310-FETCH-SINISTRO-DB-CLOSE-1 */
        public void M_310_FETCH_SINISTRO_DB_CLOSE_1()
        {
            /*" -784- EXEC SQL CLOSE SINISTROS END-EXEC */

            SINISTROS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_EXIT*/

        [StopWatch]
        /*" M-320-PROCESSA-SINISTRO */
        private void M_320_PROCESSA_SINISTRO(bool isPerform = false)
        {
            /*" -800- PERFORM 400-SELECT-SINISTRO-HAB THRU 400-EXIT. */

            M_400_SELECT_SINISTRO_HAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_EXIT*/


            /*" -801- IF W-AC-LINHAS GREATER 60 */

            if (AREA_DE_WORK.W_AC_LINHAS > 60)
            {

                /*" -803- PERFORM 900-IMPRIME-CABECALHO THRU 900-EXIT. */

                M_900_IMPRIME_CABECALHO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_EXIT*/

            }


            /*" -805- PERFORM 500-IMPRIME-DADOS-GERAIS THRU 500-EXIT. */

            M_500_IMPRIME_DADOS_GERAIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_EXIT*/


            /*" -807- MOVE SINI-NUM-APOL-SINISTRO TO W-NUM-APOL-SINISTRO-ANT. */
            _.Move(SINI_NUM_APOL_SINISTRO, AREA_DE_WORK.W_NUM_APOL_SINISTRO_ANT);

            /*" -810- PERFORM 510-IMPRIME-OPERACOES THRU 510-EXIT UNTIL (SINI-NUM-APOL-SINISTRO NOT EQUAL W-NUM-APOL-SINISTRO-ANT) OR (WFIM-SINISTROS EQUAL 'SIM' ). */

            while (!((SINI_NUM_APOL_SINISTRO != AREA_DE_WORK.W_NUM_APOL_SINISTRO_ANT) || (AREA_DE_WORK.W_CHAVES_FIM_ARQUIVO.WFIM_SINISTROS == "SIM")))
            {

                M_510_IMPRIME_OPERACOES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_510_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_320_EXIT*/

        [StopWatch]
        /*" M-400-SELECT-SINISTRO-HAB */
        private void M_400_SELECT_SINISTRO_HAB(bool isPerform = false)
        {
            /*" -818- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", WABEND.WNR_EXEC_SQL);

            /*" -828- PERFORM M_400_SELECT_SINISTRO_HAB_DB_SELECT_1 */

            M_400_SELECT_SINISTRO_HAB_DB_SELECT_1();

            /*" -831- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -832- DISPLAY 'PROBLEMA NO SELECT DA V0SINISTRO-HABIT01 ...' */
                _.Display($"PROBLEMA NO SELECT DA V0SINISTRO-HABIT01 ...");

                /*" -834- DISPLAY 'SINISTRO COM ERRO = ' V0HISTSINI-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO COM ERRO = {V0HISTSINI_NUM_APOL_SINISTRO}");

                /*" -836- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -838- INITIALIZE CA-EF0101S. */
            _.Initialize(
                AREA_DE_WORK.WK_HORA_2.CA_EF0101S
            );

            /*" -839- MOVE V0HAB01-NUM-CONTRATO TO CA-NUM-CONTRATO-EF0101S. */
            _.Move(V0HAB01_NUM_CONTRATO, AREA_DE_WORK.WK_HORA_2.CA_EF0101S.CA_NUM_CONTRATO_EF0101S);

            /*" -841- MOVE SINI-DATORR TO CA-SINI-DATORR-EF0101S. */
            _.Move(SINI_DATORR, AREA_DE_WORK.WK_HORA_2.CA_EF0101S.CA_SINI_DATORR_EF0101S);

            /*" -848- CALL 'EF0101S' USING CA-NUM-CONTRATO-EF0101S CA-SINI-DATORR-EF0101S CA-DATA-CONTRATO-EF0101S CA-PRZ-VIGENCIA-EF0101S CA-SQLCODE-EF0101S. */
            _.Call("EF0101S", AREA_DE_WORK.WK_HORA_2.CA_EF0101S);

            /*" -849- IF CA-SQLCODE-EF0101S NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WK_HORA_2.CA_EF0101S.CA_SQLCODE_EF0101S != 00)
            {

                /*" -850- MOVE CA-SQLCODE-EF0101S TO SQLCODE */
                _.Move(AREA_DE_WORK.WK_HORA_2.CA_EF0101S.CA_SQLCODE_EF0101S, DB.SQLCODE);

                /*" -851- DISPLAY 'SI0078B - ERRO ACESSO SUBROTINA EF0101S' */
                _.Display($"SI0078B - ERRO ACESSO SUBROTINA EF0101S");

                /*" -852- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -854- END-IF. */
            }


            /*" -855- MOVE CA-DATA-CONTRATO-EF0101S TO V0CONT-DATA-CONTRATO. */
            _.Move(AREA_DE_WORK.WK_HORA_2.CA_EF0101S.CA_DATA_CONTRATO_EF0101S, V0CONT_DATA_CONTRATO);

            /*" -857- MOVE CA-PRZ-VIGENCIA-EF0101S TO V0CONT-PRZ-VIGENCIA. */
            _.Move(AREA_DE_WORK.WK_HORA_2.CA_EF0101S.CA_PRZ_VIGENCIA_EF0101S, V0CONT_PRZ_VIGENCIA);

            /*" -859- INITIALIZE CA-EF0102S. */
            _.Initialize(
                AREA_DE_WORK.WK_HORA_2.CA_EF0102S
            );

            /*" -860- MOVE V0HAB01-NUM-CONTRATO TO CA-NUM-CONTRATO-EF0102S. */
            _.Move(V0HAB01_NUM_CONTRATO, AREA_DE_WORK.WK_HORA_2.CA_EF0102S.CA_NUM_CONTRATO_EF0102S);

            /*" -862- MOVE SINI-DATORR TO CA-SINI-DATORR-EF0102S. */
            _.Move(SINI_DATORR, AREA_DE_WORK.WK_HORA_2.CA_EF0102S.CA_SINI_DATORR_EF0102S);

            /*" -868- CALL 'EF0102S' USING CA-NUM-CONTRATO-EF0102S CA-SINI-DATORR-EF0102S CA-SQLCODE-EF0102S CA-NOME-SEGURADO-EF0102S. */
            _.Call("EF0102S", AREA_DE_WORK.WK_HORA_2.CA_EF0102S);

            /*" -869- IF CA-SQLCODE-EF0102S NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WK_HORA_2.CA_EF0102S.CA_SQLCODE_EF0102S != 00)
            {

                /*" -870- IF CA-SQLCODE-EF0102S EQUAL +100 */

                if (AREA_DE_WORK.WK_HORA_2.CA_EF0102S.CA_SQLCODE_EF0102S == +100)
                {

                    /*" -871- MOVE SPACES TO CA-NOME-SEGURADO-EF0102S */
                    _.Move("", AREA_DE_WORK.WK_HORA_2.CA_EF0102S.CA_NOME_SEGURADO_EF0102S);

                    /*" -872- DISPLAY 'NAO HA SEGURADO SECUNDARIO' */
                    _.Display($"NAO HA SEGURADO SECUNDARIO");

                    /*" -873- ELSE */
                }
                else
                {


                    /*" -874- MOVE CA-SQLCODE-EF0102S TO SQLCODE */
                    _.Move(AREA_DE_WORK.WK_HORA_2.CA_EF0102S.CA_SQLCODE_EF0102S, DB.SQLCODE);

                    /*" -875- DISPLAY 'SI0078B - ERRO ACESSO SUBROTINA EF0102S' */
                    _.Display($"SI0078B - ERRO ACESSO SUBROTINA EF0102S");

                    /*" -876- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -877- END-IF */
                }


                /*" -879- END-IF. */
            }


            /*" -879- MOVE CA-NOME-SEGURADO-EF0102S TO V0SEGU-NOME-SEGURADO. */
            _.Move(AREA_DE_WORK.WK_HORA_2.CA_EF0102S.CA_NOME_SEGURADO_EF0102S, V0SEGU_NOME_SEGURADO);

        }

        [StopWatch]
        /*" M-400-SELECT-SINISTRO-HAB-DB-SELECT-1 */
        public void M_400_SELECT_SINISTRO_HAB_DB_SELECT_1()
        {
            /*" -828- EXEC SQL SELECT NUM_CONTRATO, COD_COBERTURA, NOME_SEGURADO INTO :V0HAB01-NUM-CONTRATO, :V0HAB01-COD-COBERTURA, :V0HAB01-NOME-SEGURADO FROM SEGUROS.V0SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :V0HISTSINI-NUM-APOL-SINISTRO END-EXEC. */

            var m_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1 = new M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1()
            {
                V0HISTSINI_NUM_APOL_SINISTRO = V0HISTSINI_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1.Execute(m_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HAB01_NUM_CONTRATO, V0HAB01_NUM_CONTRATO);
                _.Move(executed_1.V0HAB01_COD_COBERTURA, V0HAB01_COD_COBERTURA);
                _.Move(executed_1.V0HAB01_NOME_SEGURADO, V0HAB01_NOME_SEGURADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_EXIT*/

        [StopWatch]
        /*" M-500-IMPRIME-DADOS-GERAIS */
        private void M_500_IMPRIME_DADOS_GERAIS(bool isPerform = false)
        {
            /*" -885- MOVE SINI-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO. */
            _.Move(SINI_NUM_APOL_SINISTRO, LD01.LD01_NUM_APOL_SINISTRO);

            /*" -886- MOVE V0HAB01-NOME-SEGURADO TO LD01-NM-SEGUR1. */
            _.Move(V0HAB01_NOME_SEGURADO, LD01.LD01_NM_SEGUR1);

            /*" -887- MOVE V0CONT-DATA-CONTRATO TO W-DATA-1. */
            _.Move(V0CONT_DATA_CONTRATO, AREA_DE_WORK.W_DATA_1);

            /*" -888- MOVE W-AA-DATA-1 TO W-AA-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_DATA_2.W_AA_DATA_2);

            /*" -889- MOVE W-MM-DATA-1 TO W-MM-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_DATA_2.W_MM_DATA_2);

            /*" -890- MOVE W-DD-DATA-1 TO W-DD-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_DATA_2.W_DD_DATA_2);

            /*" -891- MOVE W-DATA-2 TO LD01-DATA-CONTRATO. */
            _.Move(AREA_DE_WORK.W_DATA_2, LD01.LD01_DATA_CONTRATO);

            /*" -892- MOVE SINI-DATCMD TO W-DATA-1. */
            _.Move(SINI_DATCMD, AREA_DE_WORK.W_DATA_1);

            /*" -893- MOVE W-AA-DATA-1 TO W-AA-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_DATA_2.W_AA_DATA_2);

            /*" -894- MOVE W-MM-DATA-1 TO W-MM-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_DATA_2.W_MM_DATA_2);

            /*" -895- MOVE W-DD-DATA-1 TO W-DD-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_DATA_2.W_DD_DATA_2);

            /*" -897- MOVE W-DATA-2 TO LD01-DATA-AVISO. */
            _.Move(AREA_DE_WORK.W_DATA_2, LD01.LD01_DATA_AVISO);

            /*" -898- IF V0HAB01-COD-COBERTURA = 1 */

            if (V0HAB01_COD_COBERTURA == 1)
            {

                /*" -899- MOVE 'M.I.P.' TO LD01-TIPO-SINISTRO */
                _.Move("M.I.P.", LD01.LD01_TIPO_SINISTRO);

                /*" -900- ELSE */
            }
            else
            {


                /*" -902- MOVE 'D.F.I.' TO LD01-TIPO-SINISTRO. */
                _.Move("D.F.I.", LD01.LD01_TIPO_SINISTRO);
            }


            /*" -904- MOVE V0SEGU-NOME-SEGURADO TO LD02-NM-SEGUR2. */
            _.Move(V0SEGU_NOME_SEGURADO, LD02.LD02_NM_SEGUR2);

            /*" -906- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -912- PERFORM M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1 */

            M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1();

            /*" -915- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -916- DISPLAY 'PROBLEMAS NO SELECT V0SINICAUSA.............' */
                _.Display($"PROBLEMAS NO SELECT V0SINICAUSA.............");

                /*" -917- DISPLAY 'RAMO DA CAUSA         = ' SINI-RAMO */
                _.Display($"RAMO DA CAUSA         = {SINI_RAMO}");

                /*" -918- DISPLAY 'CODIGO DA CAUSA       = ' SINI-CODCAU */
                _.Display($"CODIGO DA CAUSA       = {SINI_CODCAU}");

                /*" -920- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -922- MOVE V0CAUSA-DESCAU TO LD01-CAUSA-SINISTRO. */
            _.Move(V0CAUSA_DESCAU, LD01.LD01_CAUSA_SINISTRO);

            /*" -923- MOVE SINI-NUMIRB TO LD02-NUMIRB. */
            _.Move(SINI_NUMIRB, LD02.LD02_NUMIRB);

            /*" -924- MOVE V0CONT-PRZ-VIGENCIA TO LD02-PRAZO-CONTRATO. */
            _.Move(V0CONT_PRZ_VIGENCIA, LD02.LD02_PRAZO_CONTRATO);

            /*" -925- MOVE SINI-DATORR TO W-DATA-1. */
            _.Move(SINI_DATORR, AREA_DE_WORK.W_DATA_1);

            /*" -926- MOVE W-AA-DATA-1 TO W-AA-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_DATA_2.W_AA_DATA_2);

            /*" -927- MOVE W-MM-DATA-1 TO W-MM-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_DATA_2.W_MM_DATA_2);

            /*" -928- MOVE W-DD-DATA-1 TO W-DD-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_DATA_2.W_DD_DATA_2);

            /*" -930- MOVE W-DATA-2 TO LD02-DATA-OCORRENCIA. */
            _.Move(AREA_DE_WORK.W_DATA_2, LD02.LD02_DATA_OCORRENCIA);

            /*" -931- IF SINI-SITUACAO EQUAL '2' */

            if (SINI_SITUACAO == "2")
            {

                /*" -932- MOVE 'CANCELADO' TO LD02-SITUACAO */
                _.Move("CANCELADO", LD02.LD02_SITUACAO);

                /*" -933- ELSE */
            }
            else
            {


                /*" -935- MOVE 'NAO CANCELADO' TO LD02-SITUACAO. */
                _.Move("NAO CANCELADO", LD02.LD02_SITUACAO);
            }


            /*" -936- WRITE REG-SI0078BR FROM LD01 AFTER 3. */
            _.Move(LD01.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -938- WRITE REG-SI0078BR FROM LD02 AFTER 1. */
            _.Move(LD02.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -940- ADD 2 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 2;

            /*" -940- MOVE V0HAB01-NUM-CONTRATO TO LD03-NUM-FIAP. */
            _.Move(V0HAB01_NUM_CONTRATO, LD03.LD03_NUM_FIAP);

        }

        [StopWatch]
        /*" M-500-IMPRIME-DADOS-GERAIS-DB-SELECT-1 */
        public void M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1()
        {
            /*" -912- EXEC SQL SELECT DESCAU INTO :V0CAUSA-DESCAU FROM SEGUROS.V0SINICAUSA WHERE RAMO = :SINI-RAMO AND CODCAU = :SINI-CODCAU END-EXEC. */

            var m_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1 = new M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1()
            {
                SINI_CODCAU = SINI_CODCAU.ToString(),
                SINI_RAMO = SINI_RAMO.ToString(),
            };

            var executed_1 = M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1.Execute(m_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CAUSA_DESCAU, V0CAUSA_DESCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_EXIT*/

        [StopWatch]
        /*" M-510-IMPRIME-OPERACOES */
        private void M_510_IMPRIME_OPERACOES(bool isPerform = false)
        {
            /*" -948- MOVE ALL '*' TO LD03-OPERACAO. */
            _.MoveAll("*", LD03.LD03_OPERACAO);

            /*" -950- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WABEND.WNR_EXEC_SQL);

            /*" -956- PERFORM M_510_IMPRIME_OPERACOES_DB_SELECT_1 */

            M_510_IMPRIME_OPERACOES_DB_SELECT_1();

            /*" -959- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -960- DISPLAY 'PROBLEMAS NO SELECT GE_OPERACAO......' */
                _.Display($"PROBLEMAS NO SELECT GE_OPERACAO......");

                /*" -961- DISPLAY 'SINISTRO              = ' SINI-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO              = {SINI_NUM_APOL_SINISTRO}");

                /*" -962- DISPLAY 'CODIGO OPERACAO       = ' SINI-OPERACAO */
                _.Display($"CODIGO OPERACAO       = {SINI_OPERACAO}");

                /*" -964- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -966- MOVE GEOPERAC-DES-OPERACAO TO LD03-OPERACAO. */
            _.Move(GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO, LD03.LD03_OPERACAO);

            /*" -967- MOVE SINI-DTMOVTO TO W-DATA-1. */
            _.Move(SINI_DTMOVTO, AREA_DE_WORK.W_DATA_1);

            /*" -968- MOVE W-AA-DATA-1 TO W-AA-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_AA_DATA_1, AREA_DE_WORK.W_DATA_2.W_AA_DATA_2);

            /*" -969- MOVE W-MM-DATA-1 TO W-MM-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_MM_DATA_1, AREA_DE_WORK.W_DATA_2.W_MM_DATA_2);

            /*" -970- MOVE W-DD-DATA-1 TO W-DD-DATA-2 */
            _.Move(AREA_DE_WORK.W_DATA_1.W_DD_DATA_1, AREA_DE_WORK.W_DATA_2.W_DD_DATA_2);

            /*" -971- MOVE W-DATA-2 TO LD03-DTMOVTO. */
            _.Move(AREA_DE_WORK.W_DATA_2, LD03.LD03_DTMOVTO);

            /*" -972- MOVE SINI-NOMFAV TO LD03-FAVORECIDO. */
            _.Move(SINI_NOMFAV, LD03.LD03_FAVORECIDO);

            /*" -973- MOVE SINI-VAL-OPERACAO TO LD03-VALOR. */
            _.Move(SINI_VAL_OPERACAO, LD03.LD03_VALOR);

            /*" -974- MOVE SINI-CODUSU TO LD03-ANALISTA. */
            _.Move(SINI_CODUSU, LD03.LD03_ANALISTA);

            /*" -976- WRITE REG-SI0078BR FROM LD03 AFTER 1. */
            _.Move(LD03.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -978- MOVE 0 TO LD03-NUM-FIAP. */
            _.Move(0, LD03.LD03_NUM_FIAP);

            /*" -980- ADD 1 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 1;

            /*" -980- PERFORM 310-FETCH-SINISTRO THRU 310-EXIT. */

            M_310_FETCH_SINISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_EXIT*/


        }

        [StopWatch]
        /*" M-510-IMPRIME-OPERACOES-DB-SELECT-1 */
        public void M_510_IMPRIME_OPERACOES_DB_SELECT_1()
        {
            /*" -956- EXEC SQL SELECT DES_OPERACAO INTO :GEOPERAC-DES-OPERACAO FROM SEGUROS.GE_OPERACAO WHERE COD_OPERACAO = :SINI-OPERACAO AND IDE_SISTEMA = 'SI' END-EXEC. */

            var m_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1 = new M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1()
            {
                SINI_OPERACAO = SINI_OPERACAO.ToString(),
            };

            var executed_1 = M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1.Execute(m_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_510_EXIT*/

        [StopWatch]
        /*" M-900-IMPRIME-CABECALHO */
        private void M_900_IMPRIME_CABECALHO(bool isPerform = false)
        {
            /*" -987- ADD 1 TO W-AC-PAGINA. */
            AREA_DE_WORK.W_AC_PAGINA.Value = AREA_DE_WORK.W_AC_PAGINA + 1;

            /*" -989- MOVE W-AC-PAGINA TO LC00-PAGINA. */
            _.Move(AREA_DE_WORK.W_AC_PAGINA, LC00.LC00_PAGINA);

            /*" -990- WRITE REG-SI0078BR FROM LC00 AFTER NEW-PAGE. */
            _.Move(LC00.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -991- WRITE REG-SI0078BR FROM LC01 AFTER 1. */
            _.Move(LC01.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -992- WRITE REG-SI0078BR FROM LC02 AFTER 1. */
            _.Move(LC02.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -993- WRITE REG-SI0078BR FROM LC03 AFTER 1. */
            _.Move(LC03.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -994- WRITE REG-SI0078BR FROM LC04 AFTER 1. */
            _.Move(LC04.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -995- WRITE REG-SI0078BR FROM LC05 AFTER 1. */
            _.Move(LC05.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -996- WRITE REG-SI0078BR FROM LC06 AFTER 1. */
            _.Move(LC06.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -998- WRITE REG-SI0078BR FROM LC03 AFTER 1. */
            _.Move(LC03.GetMoveValues(), REG_SI0078BR);

            SI0078BR.Write(REG_SI0078BR.GetMoveValues().ToString());

            /*" -998- MOVE 8 TO W-AC-LINHAS. */
            _.Move(8, AREA_DE_WORK.W_AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_EXIT*/

        [StopWatch]
        /*" M-910-MONTA-CABECALHO */
        private void M_910_MONTA_CABECALHO(bool isPerform = false)
        {
            /*" -1005- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -1006- MOVE WHORA-HH-CURR TO LC02-HH-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, LC02.LC02_HH_HORA);

            /*" -1007- MOVE WHORA-MM-CURR TO LC02-MM-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, LC02.LC02_MM_HORA);

            /*" -1009- MOVE WHORA-SS-CURR TO LC02-SS-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, LC02.LC02_SS_HORA);

            /*" -1010- MOVE V1SISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTEMA_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -1011- MOVE WDATA-DD-CURR TO LC01-DD-PROCESSAMENTO. */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_DD_CURR, LC01.LC01_DD_PROCESSAMENTO);

            /*" -1012- MOVE WDATA-MM-CURR TO LC01-MM-PROCESSAMENTO. */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_MM_CURR, LC01.LC01_MM_PROCESSAMENTO);

            /*" -1014- MOVE WDATA-AA-CURR TO LC01-AA-PROCESSAMENTO. */
            _.Move(AREA_DE_WORK.WDATA_CURR.WDATA_AA_CURR, LC01.LC01_AA_PROCESSAMENTO);

            /*" -1015- MOVE 'FUNCEF' TO LC01-CARTEIRA. */
            _.Move("FUNCEF", LC01.LC01_CARTEIRA);

            /*" -1017- MOVE V0RELATORIOS-ANO-REFERENCIA TO LC02-ANO-REFERENCIA. */
            _.Move(V0RELATORIOS_ANO_REFERENCIA, LC02.LC02_ANO_REFERENCIA);

            /*" -1018- IF V0RELATORIOS-MES-REFERENCIA EQUAL 01 */

            if (V0RELATORIOS_MES_REFERENCIA == 01)
            {

                /*" -1019- MOVE 'JAN' TO LC02-MES-REFERENCIA */
                _.Move("JAN", LC02.LC02_MES_REFERENCIA);

                /*" -1020- ELSE */
            }
            else
            {


                /*" -1021- IF V0RELATORIOS-MES-REFERENCIA EQUAL 02 */

                if (V0RELATORIOS_MES_REFERENCIA == 02)
                {

                    /*" -1022- MOVE 'FEV' TO LC02-MES-REFERENCIA */
                    _.Move("FEV", LC02.LC02_MES_REFERENCIA);

                    /*" -1023- ELSE */
                }
                else
                {


                    /*" -1024- IF V0RELATORIOS-MES-REFERENCIA EQUAL 03 */

                    if (V0RELATORIOS_MES_REFERENCIA == 03)
                    {

                        /*" -1025- MOVE 'MAR' TO LC02-MES-REFERENCIA */
                        _.Move("MAR", LC02.LC02_MES_REFERENCIA);

                        /*" -1026- ELSE */
                    }
                    else
                    {


                        /*" -1027- IF V0RELATORIOS-MES-REFERENCIA EQUAL 04 */

                        if (V0RELATORIOS_MES_REFERENCIA == 04)
                        {

                            /*" -1028- MOVE 'ABR' TO LC02-MES-REFERENCIA */
                            _.Move("ABR", LC02.LC02_MES_REFERENCIA);

                            /*" -1029- ELSE */
                        }
                        else
                        {


                            /*" -1030- IF V0RELATORIOS-MES-REFERENCIA EQUAL 05 */

                            if (V0RELATORIOS_MES_REFERENCIA == 05)
                            {

                                /*" -1031- MOVE 'MAI' TO LC02-MES-REFERENCIA */
                                _.Move("MAI", LC02.LC02_MES_REFERENCIA);

                                /*" -1032- ELSE */
                            }
                            else
                            {


                                /*" -1033- IF V0RELATORIOS-MES-REFERENCIA EQUAL 06 */

                                if (V0RELATORIOS_MES_REFERENCIA == 06)
                                {

                                    /*" -1034- MOVE 'JUN' TO LC02-MES-REFERENCIA */
                                    _.Move("JUN", LC02.LC02_MES_REFERENCIA);

                                    /*" -1035- ELSE */
                                }
                                else
                                {


                                    /*" -1036- IF V0RELATORIOS-MES-REFERENCIA EQUAL 07 */

                                    if (V0RELATORIOS_MES_REFERENCIA == 07)
                                    {

                                        /*" -1037- MOVE 'JUL' TO LC02-MES-REFERENCIA */
                                        _.Move("JUL", LC02.LC02_MES_REFERENCIA);

                                        /*" -1038- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1039- IF V0RELATORIOS-MES-REFERENCIA EQUAL 08 */

                                        if (V0RELATORIOS_MES_REFERENCIA == 08)
                                        {

                                            /*" -1040- MOVE 'AGO' TO LC02-MES-REFERENCIA */
                                            _.Move("AGO", LC02.LC02_MES_REFERENCIA);

                                            /*" -1041- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1042- IF V0RELATORIOS-MES-REFERENCIA EQUAL 09 */

                                            if (V0RELATORIOS_MES_REFERENCIA == 09)
                                            {

                                                /*" -1043- MOVE 'SET' TO LC02-MES-REFERENCIA */
                                                _.Move("SET", LC02.LC02_MES_REFERENCIA);

                                                /*" -1044- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1045- IF V0RELATORIOS-MES-REFERENCIA EQUAL 10 */

                                                if (V0RELATORIOS_MES_REFERENCIA == 10)
                                                {

                                                    /*" -1046- MOVE 'OUT' TO LC02-MES-REFERENCIA */
                                                    _.Move("OUT", LC02.LC02_MES_REFERENCIA);

                                                    /*" -1047- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1048- IF V0RELATORIOS-MES-REFERENCIA EQUAL 11 */

                                                    if (V0RELATORIOS_MES_REFERENCIA == 11)
                                                    {

                                                        /*" -1049- MOVE 'NOV' TO LC02-MES-REFERENCIA */
                                                        _.Move("NOV", LC02.LC02_MES_REFERENCIA);

                                                        /*" -1050- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1051- IF V0RELATORIOS-MES-REFERENCIA EQUAL 01 */

                                                        if (V0RELATORIOS_MES_REFERENCIA == 01)
                                                        {

                                                            /*" -1051- MOVE 'DEZ' TO LC02-MES-REFERENCIA. */
                                                            _.Move("DEZ", LC02.LC02_MES_REFERENCIA);
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


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_910_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1060- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1061- DISPLAY ' ' */
                _.Display($" ");

                /*" -1062- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1063- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0078B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0078B  *");

                /*" -1064- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1065- DISPLAY ' ' */
                _.Display($" ");

                /*" -1066- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {WABEND.WNR_EXEC_SQL}");

                /*" -1067- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1068- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLCODE1);

                /*" -1069- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLCODE2);

                /*" -1070- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WSQLCODE3);

                /*" -1072- DISPLAY WABEND. */
                _.Display(WABEND);
            }


            /*" -1072- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1073- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1077- CLOSE SI0078BR. */
            SI0078BR.Close();

            /*" -1078- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1078- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}