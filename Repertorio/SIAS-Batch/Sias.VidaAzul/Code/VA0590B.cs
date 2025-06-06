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
using Sias.VidaAzul.DB2.VA0590B;

namespace Code
{
    public class VA0590B
    {
        public bool IsCall { get; set; }

        public VA0590B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *VERSAO: 03/11/2008 AS 17H02                                            */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SISTEMA HABITACIONAL               *      */
        /*"      *   PROGRAMA ...............  VA0590B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CELIA                              *      */
        /*"      *   PROGRAMADOR ............  CELIA                              *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/2008                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERAR ARQUIVO COM DADOS DE VENDAS  *      */
        /*"      *                             DO SEGURO DE PRESTAMISTA           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD - 159.822 / JIRA - 4727                      *      */
        /*"      *             - RETIRAR DO CURSOR OS PRODUTOS 7732 E 7733        *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/02/2018 - JEFFERSON                                    *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - CAD 86.802                                       *      */
        /*"      *               - ABEND SQLCODE -305                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/08/2013 - DIOGO MATHEUS                                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - CAD 81.938                                       *      */
        /*"      *               - INCLUIR CAMPOS DATA DE VENDA, INICIO E FIM DE  *      */
        /*"      *                 VIGENCIA, NUMERO DO ENDOSSO E NUM SICOB.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2013 - ANDRE ANDRIOLE COSTA                         *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 43.895                                       *      */
        /*"      *               - GERAR ARQUIVO COM CERTIFICADOS QUE TENHAM MOVI-*      */
        /*"      *                 MENTACAO OU ALTERACAO.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/06/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04                                                    *      */
        /*"      *   CAD 37444  EM 27/02/2010 - EDIVALDO GOMES - FAST COMPUTER    *      */
        /*"      *   MANUTENCAO EVOLUTIVA - INCLUSAO DA COLUNA DESCRICAO OPERACAO *      */
        /*"      *                          PROCURAR POR 'V04'                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03                                                    *      */
        /*"      *   CAD 29848  EM 16/09/2009 - ALCIONE ARAUJO                    *      */
        /*"      *   MANUTENCAO CORRETIVA - TRATAMENTO DE NULIDADE                *      */
        /*"      *                          PROCURAR POR 'V03'                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *   CAD 27560  EM 24/08/2009 - ALCIONE ARAUJO                    *      */
        /*"      *   MANUTENCAO EVOLUTIVA                                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *   CAD 18.251                                                   *      */
        /*"      *   correcao do abend sqlcode = 180 no cursor principal          *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/12/2008 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ARQVA590 { get; set; } = new FileBasis(new PIC("X", "650", "X(650)"));

        public FileBasis ARQVA590
        {
            get
            {
                _.Move(REG_ARQVA590, _ARQVA590); VarBasis.RedefinePassValue(REG_ARQVA590, _ARQVA590, REG_ARQVA590); return _ARQVA590;
            }
        }
        /*"01              REG-ARQVA590         PIC  X(650).*/
        public StringBasis REG_ARQVA590 { get; set; } = new StringBasis(new PIC("X", "650", "X(650)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0PERI-INICIAL         PIC   X(010).*/
        public StringBasis V0PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0PERI-FINAL           PIC   X(010).*/
        public StringBasis V0PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  AC-DISPLAY             PIC   9(007) VALUE ZEROS.*/
        public IntBasis AC_DISPLAY { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77  V0ANO-REFER            PIC   9(004) VALUE 0.*/
        public IntBasis V0ANO_REFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77  V0MES-REFER            PIC   9(002) VALUE 0.*/
        public IntBasis V0MES_REFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"77  WS-NULL                PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL1               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL2               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL3               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL4               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL4 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL5               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL5 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL6               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL6 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL7               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL7 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL8               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL8 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NULL9               PIC  S9(004) USAGE COMP VALUE +0.*/
        public IntBasis WS_NULL9 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-FIM-DE-VIGENCIA     PIC   X(010).*/
        public StringBasis WS_FIM_DE_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-REG-PARAMETROS.*/
        public VA0590B_WS_REG_PARAMETROS WS_REG_PARAMETROS { get; set; } = new VA0590B_WS_REG_PARAMETROS();
        public class VA0590B_WS_REG_PARAMETROS : VarBasis
        {
            /*"    03  WS-DTH-ULT-MOV.*/
            public VA0590B_WS_DTH_ULT_MOV WS_DTH_ULT_MOV { get; set; } = new VA0590B_WS_DTH_ULT_MOV();
            public class VA0590B_WS_DTH_ULT_MOV : VarBasis
            {
                /*"        05  WS-DTH-ANO-ULT-MOV    PIC  9(004).*/
                public IntBasis WS_DTH_ANO_ULT_MOV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        05  WS-DTH-MES-ULT-MOV    PIC  9(002).*/
                public IntBasis WS_DTH_MES_ULT_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  WS-DTH-DIA-ULT-MOV    PIC  9(002).*/
                public IntBasis WS_DTH_DIA_ULT_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WS-SEPARADOR              PIC  X(001).*/
            }
            public StringBasis WS_SEPARADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  WS-QTD-MES                PIC  9(002).*/
            public IntBasis WS_QTD_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*" 01     WDATA-ATUAL.*/
            public VA0590B_WDATA_ATUAL WDATA_ATUAL { get; set; } = new VA0590B_WDATA_ATUAL();
            public class VA0590B_WDATA_ATUAL : VarBasis
            {
                /*"   05   W-ANO-ATL              PIC  9(004)         VALUE ZEROS.*/
                public IntBasis W_ANO_ATL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05   FILLER                 PIC  X(001)         VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   05   W-MES-ATL              PIC  9(002)         VALUE ZEROS.*/
                public IntBasis W_MES_ATL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05   FILLER                 PIC  X(001)         VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   05   W-DIA-ATL              PIC  9(002)         VALUE ZEROS.*/
                public IntBasis W_DIA_ATL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01      AREA-DE-WORK.*/
            }
        }
        public VA0590B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0590B_AREA_DE_WORK();
        public class VA0590B_AREA_DE_WORK : VarBasis
        {
            /*"   05    REG00.*/
            public VA0590B_REG00 REG00 { get; set; } = new VA0590B_REG00();
            public class VA0590B_REG00 : VarBasis
            {
                /*"     10  FILLER              PIC X(07) VALUE 'APOLICE'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"     10  FIL16               PIC X(01) VALUE ';'.*/
                public StringBasis FIL16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(11) VALUE 'CERTIFICADO'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"     10  FIL17               PIC X(01) VALUE ';'.*/
                public StringBasis FIL17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(14) VALUE 'CODIGO-PRODUTO'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"CODIGO-PRODUTO");
                /*"     10  FIL18               PIC X(01) VALUE ';'.*/
                public StringBasis FIL18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(13) VALUE 'NOME-SEGURADO'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NOME-SEGURADO");
                /*"     10  FIL19               PIC X(01) VALUE ';'.*/
                public StringBasis FIL19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(08) VALUE 'CPF-CNPJ'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"CPF-CNPJ");
                /*"     10  FIL20               PIC X(01) VALUE ';'.*/
                public StringBasis FIL20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(04) VALUE 'SEXO'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"SEXO");
                /*"     10  FIL21               PIC X(01) VALUE ';'.*/
                public StringBasis FIL21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(15) VALUE 'DATA-NASCIMENTO'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA-NASCIMENTO");
                /*"     10  FIL22               PIC X(01) VALUE ';'.*/
                public StringBasis FIL22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(02) VALUE 'UF'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"UF");
                /*"     10  FIL23               PIC X(01) VALUE ';'.*/
                public StringBasis FIL23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(17) VALUE 'CPTL-SEGURADO-IS'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"CPTL-SEGURADO-IS");
                /*"     10  FIL24               PIC X(01) VALUE ';'.*/
                public StringBasis FIL24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(12) VALUE 'VALOR-PREMIO'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"VALOR-PREMIO");
                /*"     10  FIL25               PIC X(01) VALUE ';'.*/
                public StringBasis FIL25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(09) VALUE 'PROFISSAO'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PROFISSAO");
                /*"     10  FIL26               PIC X(01) VALUE ';'.*/
                public StringBasis FIL26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(05) VALUE 'PRAZO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"PRAZO");
                /*"     10  FIL27               PIC X(01) VALUE ';'.*/
                public StringBasis FIL27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(11) VALUE 'NOME-ESPOSA'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"NOME-ESPOSA");
                /*"     10  FIL28               PIC X(01) VALUE ';'.*/
                public StringBasis FIL28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(15) VALUE 'DT-NSCMO-ESPOSA'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DT-NSCMO-ESPOSA");
                /*"     10  FIL29               PIC X(01) VALUE ';'.*/
                public StringBasis FIL29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(16) VALUE 'AGENCIA-COBRANCA'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"AGENCIA-COBRANCA");
                /*"     10  FIL30               PIC X(01) VALUE ';'.*/
                public StringBasis FIL30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(13) VALUE 'DATA-QUITACAO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DATA-QUITACAO");
                /*"     10  FIL31               PIC X(01) VALUE ';'.*/
                public StringBasis FIL31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(09) VALUE 'SITUACAO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SITUACAO");
                /*"     10  FIL32               PIC X(01) VALUE ';'.*/
                public StringBasis FIL32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(12) VALUE 'OPER-CREDITO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"OPER-CREDITO");
                /*"     10  FIL33               PIC X(01) VALUE ';'.*/
                public StringBasis FIL33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(09) VALUE 'DESCRICAO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DESCRICAO");
                /*"     10  FILLER              PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(14) VALUE 'NUM-CONTR-VINC'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"NUM-CONTR-VINC");
                /*"     10  FIL34               PIC X(01) VALUE ';'.*/
                public StringBasis FIL34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(12) VALUE 'ORIGEM-VENDA'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"ORIGEM-VENDA");
                /*"     10  FIL35               PIC X(01) VALUE ';'.*/
                public StringBasis FIL35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(09) VALUE 'DESCRICAO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DESCRICAO");
                /*"     10  FIL36               PIC X(01) VALUE ';'.*/
                public StringBasis FIL36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(09) VALUE 'AGE-VENDA'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"AGE-VENDA");
                /*"     10  FIL37               PIC X(01) VALUE ';'.*/
                public StringBasis FIL37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(13) VALUE 'NOME-VENDEDOR'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NOME-VENDEDOR");
                /*"     10  FIL38               PIC X(01) VALUE ';'.*/
                public StringBasis FIL38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(12) VALUE 'MAT-VENDEDOR'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"MAT-VENDEDOR");
                /*"     10  FIL39               PIC X(01) VALUE ';'.*/
                public StringBasis FIL39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(13) VALUE 'CORRESP.CAIXA'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"CORRESP.CAIXA");
                /*"     10  FIL40               PIC X(01) VALUE ';'.*/
                public StringBasis FIL40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(09) VALUE 'NUMERO-RG'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NUMERO-RG");
                /*"     10  FIL41               PIC X(01) VALUE ';'.*/
                public StringBasis FIL41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(14) VALUE 'DATA-EXPEDICAO'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DATA-EXPEDICAO");
                /*"     10  FIL42               PIC X(01) VALUE ';'.*/
                public StringBasis FIL42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(13) VALUE 'ORGAO-EMISSOR'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"ORGAO-EMISSOR");
                /*"     10  FIL43               PIC X(01) VALUE ';'.*/
                public StringBasis FIL43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER              PIC X(05) VALUE 'UF-RG'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"UF-RG");
                /*"     10  FIL44               PIC X(01) VALUE ';'.*/
                public StringBasis FIL44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(18) VALUE 'RENDA MENS IND.INI'*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"RENDA MENS IND.INI");
                /*"     10  FIL45               PIC X(01) VALUE ';'.*/
                public StringBasis FIL45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(18) VALUE 'RENDA MENS IND.FIM'*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"RENDA MENS IND.FIM");
                /*"     10  FIL46              PIC X(01) VALUE ';'.*/
                public StringBasis FIL46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(18) VALUE 'RENDA MENS FAM.INI'*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"RENDA MENS FAM.INI");
                /*"     10  FIL47              PIC X(01) VALUE ';'.*/
                public StringBasis FIL47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(18) VALUE 'RENDA MENS FAM.FIM'*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"RENDA MENS FAM.FIM");
                /*"     10  FIL48              PIC X(01) VALUE ';'.*/
                public StringBasis FIL48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(13) VALUE 'DATA DE VENDA'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DATA DE VENDA");
                /*"     10  FIL49              PIC X(01) VALUE ';'.*/
                public StringBasis FIL49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(17) VALUE 'DTH INICIO VIGENC'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"DTH INICIO VIGENC");
                /*"     10  FIL50              PIC X(01) VALUE ';'.*/
                public StringBasis FIL50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(14) VALUE 'DTH FIM VIGENC'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DTH FIM VIGENC");
                /*"     10  FIL51              PIC X(01) VALUE ';'.*/
                public StringBasis FIL51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(11) VALUE 'NUM ENDOSSO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"NUM ENDOSSO");
                /*"     10  FIL52              PIC X(01) VALUE ';'.*/
                public StringBasis FIL52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER             PIC X(09) VALUE 'NUM-SICOB'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NUM-SICOB");
                /*"     10  FILLER             PIC X(151) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "151", "X(151)"), @"");
                /*"   05    REG01.*/
            }
            public VA0590B_REG01 REG01 { get; set; } = new VA0590B_REG01();
            public class VA0590B_REG01 : VarBasis
            {
                /*"     10  R1-NUM-APOLICE      PIC 9(13) VALUE ZEROS.*/
                public IntBasis R1_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"     10  FILL                PIC X(01) VALUE ';'.*/
                public StringBasis FILL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NUM-CERTIFICADO  PIC 9(15) VALUE ZEROS.*/
                public IntBasis R1_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
                /*"     10  FILL1               PIC X(01) VALUE ';'.*/
                public StringBasis FILL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-COD-PRODUTO      PIC 9(04) VALUE ZEROS.*/
                public IntBasis R1_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10  FILL2               PIC X(01) VALUE ';'.*/
                public StringBasis FILL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NOME-RAZAO       PIC X(40) VALUE SPACES.*/
                public StringBasis R1_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"     10  FILL3               PIC X(01) VALUE ';'.*/
                public StringBasis FILL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-CGCCPF           PIC 9(15) VALUE ZEROS.*/
                public IntBasis R1_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
                /*"     10  FILL4               PIC X(01) VALUE ';'.*/
                public StringBasis FILL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-IDE-SEXO         PIC X(01) VALUE  SPACES.*/
                public StringBasis R1_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"     10  FILL5               PIC X(01) VALUE ';'.*/
                public StringBasis FILL5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-DATA-NASCIMENTO  PIC X(10) VALUE  SPACES.*/
                public StringBasis R1_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"     10  FIL6                PIC X(01) VALUE ';'.*/
                public StringBasis FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-SIGLA-UF         PIC X(02) VALUE SPACES.*/
                public StringBasis R1_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"     10  FILL7               PIC X(01) VALUE ';'.*/
                public StringBasis FILL7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-IMP-MORNATU      PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis R1_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"     10  FIL8                PIC X(01) VALUE ';'.*/
                public StringBasis FIL8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-VLPREMIO         PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis R1_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"     10  FILL9               PIC X(01) VALUE ';'.*/
                public StringBasis FILL9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-PROFISSAO        PIC X(20) VALUE SPACES.*/
                public StringBasis R1_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"     10  FILL10              PIC X(01) VALUE ';'.*/
                public StringBasis FILL10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-COD-PLANO        PIC 9(04) VALUE ZEROS.*/
                public IntBasis R1_COD_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10  FILL11              PIC X(01) VALUE ';'.*/
                public StringBasis FILL11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NOME-ESPOSA      PIC X(40) VALUE SPACES.*/
                public StringBasis R1_NOME_ESPOSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"     10  FILL12              PIC X(01) VALUE ';'.*/
                public StringBasis FILL12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-DTNASC-ESPOSA    PIC X(10) VALUE SPACES.*/
                public StringBasis R1_DTNASC_ESPOSA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"     10  FILL13              PIC X(01) VALUE ';'.*/
                public StringBasis FILL13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-AGE-COBRANCA     PIC X(04) VALUE SPACES.*/
                public StringBasis R1_AGE_COBRANCA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"     10  FILL14              PIC X(01) VALUE ';'.*/
                public StringBasis FILL14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-DATA-QUITACAO    PIC X(10) VALUE SPACES.*/
                public StringBasis R1_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"     10  FILL15              PIC X(01) VALUE ';'.*/
                public StringBasis FILL15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-SIT-REGISTRO     PIC X(18) VALUE SPACES.*/
                public StringBasis R1_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"");
                /*"     10  FILL16              PIC X(01) VALUE ';'.*/
                public StringBasis FILL16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-OPER-CREDITO     PIC X(04) VALUE SPACES.*/
                public StringBasis R1_OPER_CREDITO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"     10  FILL17              PIC X(01) VALUE ';'.*/
                public StringBasis FILL17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-DES-OPER-CREDITO PIC X(30) VALUE SPACES.*/
                public StringBasis R1_DES_OPER_CREDITO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"     10  FILLER              PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NUM-CONTRATO     PIC X(13) VALUE SPACES.*/
                public StringBasis R1_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"     10  FILL18              PIC X(01) VALUE ';'.*/
                public StringBasis FILL18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-ORI-VENDA        PIC X(04) VALUE SPACES.*/
                public StringBasis R1_ORI_VENDA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"     10  FILL19              PIC X(01) VALUE ';'.*/
                public StringBasis FILL19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-DESCRICAO        PIC X(22) VALUE SPACES.*/
                public StringBasis R1_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"");
                /*"     10  FILL20              PIC X(01) VALUE ';'.*/
                public StringBasis FILL20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-AGE-VENDA        PIC X(04) VALUE SPACES.*/
                public StringBasis R1_AGE_VENDA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"     10  FILL21              PIC X(01) VALUE ';'.*/
                public StringBasis FILL21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NOME-VENDEDOR    PIC X(40) VALUE SPACES.*/
                public StringBasis R1_NOME_VENDEDOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"     10  FILL22              PIC X(01) VALUE ';'.*/
                public StringBasis FILL22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-MAT-VENDEDOR     PIC X(15) VALUE SPACES.*/
                public StringBasis R1_MAT_VENDEDOR { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"     10  FILL23              PIC X(01) VALUE ';'.*/
                public StringBasis FILL23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NUM-CORRESPOND   PIC X(04) VALUE SPACES.*/
                public StringBasis R1_NUM_CORRESPOND { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"     10  FILL24              PIC X(01) VALUE ';'.*/
                public StringBasis FILL24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NUM-RG           PIC X(15) VALUE SPACES.*/
                public StringBasis R1_NUM_RG { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"     10  FILL25              PIC X(01) VALUE ';'.*/
                public StringBasis FILL25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-DTA-EXPEDICAO    PIC X(10) VALUE SPACES.*/
                public StringBasis R1_DTA_EXPEDICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"     10  FILL26              PIC X(01) VALUE ';'.*/
                public StringBasis FILL26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-ORGAO-EMIS-RG    PIC X(30) VALUE SPACES.*/
                public StringBasis R1_ORGAO_EMIS_RG { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"     10  FILL27              PIC X(01) VALUE ';'.*/
                public StringBasis FILL27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-UF               PIC X(02) VALUE SPACES.*/
                public StringBasis R1_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"     10  FILL28              PIC X(01) VALUE ';'.*/
                public StringBasis FILL28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-REN-INDIV-INI    PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis R1_REN_INDIV_INI { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"     10  FILL29              PIC X(01) VALUE ';'.*/
                public StringBasis FILL29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-REN-INDIV-FIM    PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis R1_REN_INDIV_FIM { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"     10  FILL30              PIC X(01) VALUE ';'.*/
                public StringBasis FILL30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-REN-FAMIL-INI    PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis R1_REN_FAMIL_INI { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"     10  FILL31              PIC X(01) VALUE ';'.*/
                public StringBasis FILL31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-REN-FAMIL-FIM    PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis R1_REN_FAMIL_FIM { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"     10  FILL32              PIC X(01) VALUE ';'.*/
                public StringBasis FILL32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-DATA-DE-VENDA    PIC X(10).*/
                public StringBasis R1_DATA_DE_VENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10  FILL33              PIC X(01) VALUE ';'.*/
                public StringBasis FILL33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-INICIO-VIG       PIC X(10).*/
                public StringBasis R1_INICIO_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10  FILL34              PIC X(01) VALUE ';'.*/
                public StringBasis FILL34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-DTH-FIM-VIG      PIC X(10).*/
                public StringBasis R1_DTH_FIM_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10  FILL35              PIC X(01) VALUE ';'.*/
                public StringBasis FILL35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NUM-ENDOSSO      PIC 9(10).*/
                public IntBasis R1_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                /*"     10  FILL36              PIC X(01) VALUE ';'.*/
                public StringBasis FILL36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  R1-NUM-SICOB        PIC 9(16).*/
                public IntBasis R1_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
                /*"     10  FILLER              PIC X(37) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "37", "X(37)"), @"");
                /*"   05    WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"   05    WFORMATA-CEP      PIC  X(010)   VALUE  ZEROS.*/
            public StringBasis WFORMATA_CEP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"   05    WFORMATA-CEP-N   REDEFINES WFORMATA-CEP PIC 9(10).*/
            private _REDEF_IntBasis _wformata_cep_n { get; set; }
            public _REDEF_IntBasis WFORMATA_CEP_N
            {
                get { _wformata_cep_n = new _REDEF_IntBasis(new PIC("9", "10", "9(10).")); ; _.Move(WFORMATA_CEP, _wformata_cep_n); VarBasis.RedefinePassValue(WFORMATA_CEP, _wformata_cep_n, WFORMATA_CEP); _wformata_cep_n.ValueChanged += () => { _.Move(_wformata_cep_n, WFORMATA_CEP); }; return _wformata_cep_n; }
                set { VarBasis.RedefinePassValue(value, _wformata_cep_n, WFORMATA_CEP); }
            }  //Redefines
            /*"   05    WFORMATA-CEP-Z   REDEFINES WFORMATA-CEP.*/
            private _REDEF_VA0590B_WFORMATA_CEP_Z _wformata_cep_z { get; set; }
            public _REDEF_VA0590B_WFORMATA_CEP_Z WFORMATA_CEP_Z
            {
                get { _wformata_cep_z = new _REDEF_VA0590B_WFORMATA_CEP_Z(); _.Move(WFORMATA_CEP, _wformata_cep_z); VarBasis.RedefinePassValue(WFORMATA_CEP, _wformata_cep_z, WFORMATA_CEP); _wformata_cep_z.ValueChanged += () => { _.Move(_wformata_cep_z, WFORMATA_CEP); }; return _wformata_cep_z; }
                set { VarBasis.RedefinePassValue(value, _wformata_cep_z, WFORMATA_CEP); }
            }  //Redefines
            public class _REDEF_VA0590B_WFORMATA_CEP_Z : VarBasis
            {
                /*"     10  WCEP-PARTEZ1      PIC  X(001).*/
                public StringBasis WCEP_PARTEZ1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10  WCEP-PARTEZ2      PIC  X(001).*/
                public StringBasis WCEP_PARTEZ2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10  WCEP-PARTERES     PIC  X(008).*/
                public StringBasis WCEP_PARTERES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   05    WFORMATA-CONTA-R REDEFINES WFORMATA-CEP.*/

                public _REDEF_VA0590B_WFORMATA_CEP_Z()
                {
                    WCEP_PARTEZ1.ValueChanged += OnValueChanged;
                    WCEP_PARTEZ2.ValueChanged += OnValueChanged;
                    WCEP_PARTERES.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA0590B_WFORMATA_CONTA_R _wformata_conta_r { get; set; }
            public _REDEF_VA0590B_WFORMATA_CONTA_R WFORMATA_CONTA_R
            {
                get { _wformata_conta_r = new _REDEF_VA0590B_WFORMATA_CONTA_R(); _.Move(WFORMATA_CEP, _wformata_conta_r); VarBasis.RedefinePassValue(WFORMATA_CEP, _wformata_conta_r, WFORMATA_CEP); _wformata_conta_r.ValueChanged += () => { _.Move(_wformata_conta_r, WFORMATA_CEP); }; return _wformata_conta_r; }
                set { VarBasis.RedefinePassValue(value, _wformata_conta_r, WFORMATA_CEP); }
            }  //Redefines
            public class _REDEF_VA0590B_WFORMATA_CONTA_R : VarBasis
            {
                /*"     10  WCEP-PARTE1       PIC  X(002).*/
                public StringBasis WCEP_PARTE1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"     10  WCEP-PARTE2       PIC  X(003).*/
                public StringBasis WCEP_PARTE2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"     10  WCEP-PARTE3       PIC  X(003).*/
                public StringBasis WCEP_PARTE3 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"     10  FILLER            PIC  X(002).*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   05    WFORMATA-DATA.*/

                public _REDEF_VA0590B_WFORMATA_CONTA_R()
                {
                    WCEP_PARTE1.ValueChanged += OnValueChanged;
                    WCEP_PARTE2.ValueChanged += OnValueChanged;
                    WCEP_PARTE3.ValueChanged += OnValueChanged;
                    FILLER_45.ValueChanged += OnValueChanged;
                }

            }
            public VA0590B_WFORMATA_DATA WFORMATA_DATA { get; set; } = new VA0590B_WFORMATA_DATA();
            public class VA0590B_WFORMATA_DATA : VarBasis
            {
                /*"     10  W-AA-FORMA        PIC  9(004)   VALUE ZEROS.*/
                public IntBasis W_AA_FORMA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10  FILLER            PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10  W-MM-FORMA        PIC  9(002)   VALUE ZEROS.*/
                public IntBasis W_MM_FORMA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  FILLER            PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10  W-DD-FORMA        PIC  9(002)   VALUE ZEROS.*/
                public IntBasis W_DD_FORMA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05    WFORMATA-DATAS.*/
            }
            public VA0590B_WFORMATA_DATAS WFORMATA_DATAS { get; set; } = new VA0590B_WFORMATA_DATAS();
            public class VA0590B_WFORMATA_DATAS : VarBasis
            {
                /*"     10  W-AA-FORMAS       PIC  9(004)   VALUE ZEROS.*/
                public IntBasis W_AA_FORMAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10  FILLER            PIC  X(001)   VALUE '/'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10  W-MM-FORMAS       PIC  9(002)   VALUE ZEROS.*/
                public IntBasis W_MM_FORMAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  FILLER            PIC  X(001)   VALUE '/'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10  W-DD-FORMAS       PIC  9(002)   VALUE ZEROS.*/
                public IntBasis W_DD_FORMAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05    W-DATA-TERVIG.*/
            }
            public VA0590B_W_DATA_TERVIG W_DATA_TERVIG { get; set; } = new VA0590B_W_DATA_TERVIG();
            public class VA0590B_W_DATA_TERVIG : VarBasis
            {
                /*"     10  W-DD-TERVIG       PIC  9(002)   VALUE ZEROS.*/
                public IntBasis W_DD_TERVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  FILLER            PIC  X(001)   VALUE '/'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10  W-MM-TERVIG       PIC  9(002)   VALUE ZEROS.*/
                public IntBasis W_MM_TERVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  FILLER            PIC  X(001)   VALUE '/'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10  W-AA-TERVIG       PIC  9(004)   VALUE ZEROS.*/
                public IntBasis W_AA_TERVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05    WNUM-IMOVEL            PIC  ZZZ99  BLANK WHEN ZERO.*/
            }
            public IntBasis WNUM_IMOVEL { get; set; } = new IntBasis(new PIC("9", "5", "ZZZ99"));
            /*"   05    WNUM-IMOVEL-RD REDEFINES WNUM-IMOVEL PIC X(005).*/
            private _REDEF_StringBasis _wnum_imovel_rd { get; set; }
            public _REDEF_StringBasis WNUM_IMOVEL_RD
            {
                get { _wnum_imovel_rd = new _REDEF_StringBasis(new PIC("X", "005", "X(005).")); ; _.Move(WNUM_IMOVEL, _wnum_imovel_rd); VarBasis.RedefinePassValue(WNUM_IMOVEL, _wnum_imovel_rd, WNUM_IMOVEL); _wnum_imovel_rd.ValueChanged += () => { _.Move(_wnum_imovel_rd, WNUM_IMOVEL); }; return _wnum_imovel_rd; }
                set { VarBasis.RedefinePassValue(value, _wnum_imovel_rd, WNUM_IMOVEL); }
            }  //Redefines
            /*"   05    WCONT-DETALHE     PIC  9(006)   VALUE  ZEROS.*/
            public IntBasis WCONT_DETALHE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05    WCONT-DETALHE01   PIC  9(006)   VALUE  ZEROS.*/
            public IntBasis WCONT_DETALHE01 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05    WCONT-DETALHE02   PIC  9(006)   VALUE  ZEROS.*/
            public IntBasis WCONT_DETALHE02 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05    WCONT-DETALHE03   PIC  9(006)   VALUE  ZEROS.*/
            public IntBasis WCONT_DETALHE03 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05    WCONT-DETALHE04   PIC  9(006)   VALUE  ZEROS.*/
            public IntBasis WCONT_DETALHE04 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05    WCONT-REGISTRO    PIC  9(006)   VALUE  ZEROS.*/
            public IntBasis WCONT_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05    WCONT-SORT        PIC  9(006)   VALUE  ZEROS.*/
            public IntBasis WCONT_SORT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05    WCONT-ARQUIVO     PIC  9(006)   VALUE  ZEROS.*/
            public IntBasis WCONT_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05    WCONT-PRESTAMISTA PIC  9(007)   VALUE  ZEROS.*/
            public IntBasis WCONT_PRESTAMISTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"   05    WCONT-ENDERECO    PIC  9(007)   VALUE  ZEROS.*/
            public IntBasis WCONT_ENDERECO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"   05    WFIM-ARQVA590     PIC  X(003)   VALUE SPACES.*/
            public StringBasis WFIM_ARQVA590 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05 WTIPO-REGISTRO       PIC  9(02)    VALUE ZEROS.*/
            public IntBasis WTIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"   05 WRESTO               PIC  9(03)    VALUE ZEROS.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"   05 WSTRING-ENDER        PIC  X(80)    VALUE SPACES.*/
            public StringBasis WSTRING_ENDER { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
            /*"   05    WS-TIME.*/
            public VA0590B_WS_TIME WS_TIME { get; set; } = new VA0590B_WS_TIME();
            public class VA0590B_WS_TIME : VarBasis
            {
                /*"     10  WS-HH-TIME        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  WS-MM-TIME        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  WS-SS-TIME        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  WS-CC-TIME        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05    WSAIDA-AREA.*/
            }
            public VA0590B_WSAIDA_AREA WSAIDA_AREA { get; set; } = new VA0590B_WSAIDA_AREA();
            public class VA0590B_WSAIDA_AREA : VarBasis
            {
                /*"     10  WFIM-PRESTAMISTA        PIC X(001)     VALUE SPACES.*/
                public StringBasis WFIM_PRESTAMISTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10  WSAI-TIPO-REGISTRO      PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WSAI_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  WSAI-DATA-INI-VIG       PIC X(010)     VALUE SPACES.*/
                public StringBasis WSAI_DATA_INI_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"     10  WSAI-DATA-TER-VIG       PIC X(010)     VALUE SPACES.*/
                public StringBasis WSAI_DATA_TER_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"     10  WSAI-NUM-APOLICE        PIC 9(013)     VALUE ZEROS.*/
                public IntBasis WSAI_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"     10  WSAI-COD-COBERTURA      PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WSAI_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10  WSAI-NOME-COBERTURA     PIC X(025)     VALUE SPACES.*/
                public StringBasis WSAI_NOME_COBERTURA { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"     10  WSAI-VAL-IMP-SEG        PIC 9(11)V9(2) VALUE ZEROS.*/
                public DoubleBasis WSAI_VAL_IMP_SEG { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V9(2)"), 2);
                /*"     10  WSAI-VAL-PREMIO         PIC 9(11)V9(2) VALUE ZEROS.*/
                public DoubleBasis WSAI_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V9(2)"), 2);
                /*"     10  WSAI-TX-BASE-PREMIO     PIC 9(3)V9(9)  VALUE ZEROS.*/
                public DoubleBasis WSAI_TX_BASE_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(3)V9(9)"), 9);
                /*"     10  WSAI-PERC-BONUS         PIC 9(3)V9(9)  VALUE ZEROS.*/
                public DoubleBasis WSAI_PERC_BONUS { get; set; } = new DoubleBasis(new PIC("9", "3", "9(3)V9(9)"), 9);
                /*"     10  WSAI-PERC-AGRAV-SIN     PIC 9(3)V9(9)  VALUE ZEROS.*/
                public DoubleBasis WSAI_PERC_AGRAV_SIN { get; set; } = new DoubleBasis(new PIC("9", "3", "9(3)V9(9)"), 9);
                /*"     10  WSAI-PERC-IOF           PIC 9(3)V9(9)  VALUE ZEROS.*/
                public DoubleBasis WSAI_PERC_IOF { get; set; } = new DoubleBasis(new PIC("9", "3", "9(3)V9(9)"), 9);
                /*"     10  WSAI-TX-FINAL-PREMIO    PIC 9(3)V9(9)  VALUE ZEROS.*/
                public DoubleBasis WSAI_TX_FINAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(3)V9(9)"), 9);
                /*"     10  FILLER                  PIC X(070)     VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"     10  WSAI-NSR                PIC 9(006)     VALUE ZEROS.*/
                public IntBasis WSAI_NSR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"   05     WABEND.*/
            }
            public VA0590B_WABEND WABEND { get; set; } = new VA0590B_WABEND();
            public class VA0590B_WABEND : VarBasis
            {
                /*"     10   FILLER              PIC  X(008) VALUE         'va0590b'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"va0590b");
                /*"     10   FILLER              PIC  X(025) VALUE         '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"     10   WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"     10   FILLER              PIC  X(013) VALUE         ' *** SQLCODE '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"     10   WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01    FORMATACAO.*/
            }
        }
        public VA0590B_FORMATACAO FORMATACAO { get; set; } = new VA0590B_FORMATACAO();
        public class VA0590B_FORMATACAO : VarBasis
        {
            /*"   05     WDATA-REF-ANT.*/
            public VA0590B_WDATA_REF_ANT WDATA_REF_ANT { get; set; } = new VA0590B_WDATA_REF_ANT();
            public class VA0590B_WDATA_REF_ANT : VarBasis
            {
                /*"      10  W-AA-ANT             PIC  9(004)      VALUE ZEROS.*/
                public IntBasis W_AA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10  FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10  W-MM-ANT             PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_MM_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10  FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10  W-DD-ANT             PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_DD_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05     WDTMOVABE-INI.*/
            }
            public VA0590B_WDTMOVABE_INI WDTMOVABE_INI { get; set; } = new VA0590B_WDTMOVABE_INI();
            public class VA0590B_WDTMOVABE_INI : VarBasis
            {
                /*"      10  W-AA-MOVAINI         PIC  9(004)      VALUE ZEROS.*/
                public IntBasis W_AA_MOVAINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10  FILLER               PIC  X(001)      VALUE '-'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10  W-MM-MOVAINI         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_MM_MOVAINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10  FILLER               PIC  X(001)      VALUE '-'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10  W-DD-MOVAINI         PIC  9(002)      VALUE 01.*/
                public IntBasis W_DD_MOVAINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 01);
                /*"   05     WDATA-REF-N.*/
            }
            public VA0590B_WDATA_REF_N WDATA_REF_N { get; set; } = new VA0590B_WDATA_REF_N();
            public class VA0590B_WDATA_REF_N : VarBasis
            {
                /*"      10  W-DD-DTREF-N         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_DD_DTREF_N { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10  FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10  W-MM-DTREF-N         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_MM_DTREF_N { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10  FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10  W-AA-DTREF-N         PIC  9(004)      VALUE ZEROS.*/
                public IntBasis W_AA_DTREF_N { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05     WDATA-REF-F.*/
            }
            public VA0590B_WDATA_REF_F WDATA_REF_F { get; set; } = new VA0590B_WDATA_REF_F();
            public class VA0590B_WDATA_REF_F : VarBasis
            {
                /*"      10  W-DD-DTREF-F         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_DD_DTREF_F { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10  FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10  W-MM-DTREF-F         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_MM_DTREF_F { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10  FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10  W-AA-DTREF-F         PIC  9(004)      VALUE ZEROS.*/
                public IntBasis W_AA_DTREF_F { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05     WDATA-REF.*/
            }
            public VA0590B_WDATA_REF WDATA_REF { get; set; } = new VA0590B_WDATA_REF();
            public class VA0590B_WDATA_REF : VarBasis
            {
                /*"      10  W-AA-DTREF           PIC  9(004)      VALUE ZEROS.*/
                public IntBasis W_AA_DTREF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10  FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10  W-MM-DTREF           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_MM_DTREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10  FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10  W-DD-DTREF           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_DD_DTREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01       LK-LINK-MES.*/
            }
        }
        public VA0590B_LK_LINK_MES LK_LINK_MES { get; set; } = new VA0590B_LK_LINK_MES();
        public class VA0590B_LK_LINK_MES : VarBasis
        {
            /*"   05    LK-LMES                  PIC 9(002)      VALUE ZEROS.*/
            public IntBasis LK_LMES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"   05    LK-LANO                  PIC 9(004)      VALUE ZEROS.*/
            public IntBasis LK_LANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"   05    LK-LEXTENSO              PIC X(014)      VALUE SPACES.*/
            public StringBasis LK_LEXTENSO { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
            /*"   05    LK-LDIAS-MES             PIC 9(002)      VALUE ZEROS.*/
            public IntBasis LK_LDIAS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        }


        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.GE243 GE243 { get; set; } = new Dclgens.GE243();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GE372 GE372 { get; set; } = new Dclgens.GE372();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public VA0590B_PRESTAMISTA PRESTAMISTA { get; set; } = new VA0590B_PRESTAMISTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQVA590_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQVA590.SetFile(ARQVA590_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-ROTINA-INICIAL-SECTION */

                R0000_00_ROTINA_INICIAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-ROTINA-INICIAL-SECTION */
        private void R0000_00_ROTINA_INICIAL_SECTION()
        {
            /*" -504- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -505- DISPLAY 'PROGRAMA EM EXECUCAO VA0590B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0590B  ");

            /*" -506- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -507- DISPLAY 'VERSAO V.08        20/02/2018 ' */
            _.Display($"VERSAO V.08        20/02/2018 ");

            /*" -516- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -517- DISPLAY ' ' */
            _.Display($" ");

            /*" -524- DISPLAY '--> INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:4) */

            $"--> INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDate(12, 4)}"
            .Display();

            /*" -526- DISPLAY ' ' */
            _.Display($" ");

            /*" -532- PERFORM R0000_00_ROTINA_INICIAL_DB_SELECT_1 */

            R0000_00_ROTINA_INICIAL_DB_SELECT_1();

            /*" -535- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -536- DISPLAY ' ' */
                _.Display($" ");

                /*" -537- DISPLAY 'DATA DE MOVIMENTO DA TABELA SEGUROS.SISTEMAS' */
                _.Display($"DATA DE MOVIMENTO DA TABELA SEGUROS.SISTEMAS");

                /*" -538- DISPLAY 'DATA DE MOVIMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA DE MOVIMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -539- PERFORM R9999-ROT-ERRO THRU R9999-SAIDA */

                R9999_ROT_ERRO();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/


                /*" -540- DISPLAY ' ' */
                _.Display($" ");

                /*" -542- END-IF. */
            }


            /*" -543- DISPLAY '--> DATA DO MOVIMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"--> DATA DO MOVIMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -545- DISPLAY ' ' */
            _.Display($" ");

            /*" -547- OPEN OUTPUT ARQVA590. */
            ARQVA590.Open(REG_ARQVA590);

            /*" -549- WRITE REG-ARQVA590 FROM REG00. */
            _.Move(AREA_DE_WORK.REG00.GetMoveValues(), REG_ARQVA590);

            ARQVA590.Write(REG_ARQVA590.GetMoveValues().ToString());

            /*" -551- PERFORM R0150-00-INICIO THRU R0150-99-SAIDA. */

            R0150_00_INICIO();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/


            /*" -553- ADD 1 TO WCONT-DETALHE. */
            AREA_DE_WORK.WCONT_DETALHE.Value = AREA_DE_WORK.WCONT_DETALHE + 1;

            /*" -555- CLOSE ARQVA590. */
            ARQVA590.Close();

            /*" -556- IF WCONT-DETALHE > 0 */

            if (AREA_DE_WORK.WCONT_DETALHE > 0)
            {

                /*" -557- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -558- ELSE */
            }
            else
            {


                /*" -560- MOVE 1 TO RETURN-CODE. */
                _.Move(1, RETURN_CODE);
            }


            /*" -561- DISPLAY ' ' */
            _.Display($" ");

            /*" -562- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -564- DISPLAY '--> TOTAL DE LINHAS LIDAS NO CURSOR: ' WCONT-PRESTAMISTA */
            _.Display($"--> TOTAL DE LINHAS LIDAS NO CURSOR: {AREA_DE_WORK.WCONT_PRESTAMISTA}");

            /*" -565- DISPLAY ' ' */
            _.Display($" ");

            /*" -566- DISPLAY '*********** VA0590B - FIM NORMAL ***********' . */
            _.Display($"*********** VA0590B - FIM NORMAL ***********");

            /*" -572- DISPLAY ' EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:4) */

            $" EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDate(12, 4)}"
            .Display();

            /*" -573- DISPLAY ' ' . */
            _.Display($" ");

            /*" -575- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -575- EXEC SQL COMMIT END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -577- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-ROTINA-INICIAL-DB-SELECT-1 */
        public void R0000_00_ROTINA_INICIAL_DB_SELECT_1()
        {
            /*" -532- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' WITH UR END-EXEC. */

            var r0000_00_ROTINA_INICIAL_DB_SELECT_1_Query1 = new R0000_00_ROTINA_INICIAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_ROTINA_INICIAL_DB_SELECT_1_Query1.Execute(r0000_00_ROTINA_INICIAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-INICIO */
        private void R0150_00_INICIO(bool isPerform = false)
        {
            /*" -587- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -589- MOVE SPACES TO WFIM-PRESTAMISTA. */
            _.Move("", AREA_DE_WORK.WSAIDA_AREA.WFIM_PRESTAMISTA);

            /*" -591- PERFORM R0300-00-DECLARE-PRESTAMISTA THRU R0300-99-SAIDA */

            R0300_00_DECLARE_PRESTAMISTA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/


            /*" -592- PERFORM R0400-00-FETCH-PRESTAMISTA UNTIL WFIM-PRESTAMISTA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WSAIDA_AREA.WFIM_PRESTAMISTA.IsEmpty()))
            {

                R0400_00_FETCH_PRESTAMISTA(true);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-PRESTAMISTA */
        private void R0300_00_DECLARE_PRESTAMISTA(bool isPerform = false)
        {
            /*" -603- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -651- PERFORM R0300_00_DECLARE_PRESTAMISTA_DB_DECLARE_1 */

            R0300_00_DECLARE_PRESTAMISTA_DB_DECLARE_1();

            /*" -653- PERFORM R0300_00_DECLARE_PRESTAMISTA_DB_OPEN_1 */

            R0300_00_DECLARE_PRESTAMISTA_DB_OPEN_1();

            /*" -656- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -657- DISPLAY 'ERRO NO DECLARE DA PRESTAMISTA-HABIT' */
                _.Display($"ERRO NO DECLARE DA PRESTAMISTA-HABIT");

                /*" -658- PERFORM R9999-ROT-ERRO THRU R9999-SAIDA */

                R9999_ROT_ERRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/


                /*" -658- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-PRESTAMISTA-DB-DECLARE-1 */
        public void R0300_00_DECLARE_PRESTAMISTA_DB_DECLARE_1()
        {
            /*" -651- EXEC SQL DECLARE PRESTAMISTA CURSOR FOR SELECT P.NUM_CERTIFICADO , P.COD_PRODUTO , P.COD_CLIENTE , P.AGE_COBRANCA , P.DATA_QUITACAO , P.NUM_MATRI_VENDEDOR , P.PROFISSAO , P.SIT_REGISTRO , P.NUM_APOLICE , P.IDE_SEXO , P.NOME_ESPOSA , P.DTNASC_ESPOSA , P.FAIXA_RENDA_IND , P.FAIXA_RENDA_FAM , P.NUM_CONTR_VINCULO , P.COD_CORRESP_BANC , P.COD_ORIGEM_PROPOSTA, P.COD_OPER_CREDITO , C.NOME_RAZAO , C.CGCCPF , C.DATA_NASCIMENTO , E.SIGLA_UF , H.IMP_MORNATU , H.VLPREMIO , PF.COD_PLANO , PF.NUM_SICOB , ( P.DATA_QUITACAO + PF.COD_PLANO MONTH) FROM SEGUROS.PROPOSTAS_VA P, SEGUROS.CLIENTES C, SEGUROS.HIS_COBER_PROPOST H, SEGUROS.ENDERECOS E, SEGUROS.PROPOSTA_FIDELIZ PF WHERE DATE(P.TIMESTAMP) >= :SISTEMAS-DATA-MOV-ABERTO AND P.NUM_APOLICE BETWEEN 0107700000000 AND 0107799999999 AND P.COD_PRODUTO NOT IN (7732, 7733) AND P.COD_CLIENTE = C.COD_CLIENTE AND P.NUM_CERTIFICADO = H.NUM_CERTIFICADO AND P.OCORR_HISTORICO = H.OCORR_HISTORICO AND P.COD_CLIENTE = E.COD_CLIENTE AND P.OCOREND = E.OCORR_ENDERECO AND P.NUM_CERTIFICADO = PF.NUM_PROPOSTA_SIVPF ORDER BY P.NUM_APOLICE , P.NUM_CERTIFICADO WITH UR END-EXEC. */
            PRESTAMISTA = new VA0590B_PRESTAMISTA(true);
            string GetQuery_PRESTAMISTA()
            {
                var query = @$"SELECT P.NUM_CERTIFICADO
							, 
							P.COD_PRODUTO
							, 
							P.COD_CLIENTE
							, 
							P.AGE_COBRANCA
							, 
							P.DATA_QUITACAO
							, 
							P.NUM_MATRI_VENDEDOR
							, 
							P.PROFISSAO
							, 
							P.SIT_REGISTRO
							, 
							P.NUM_APOLICE
							, 
							P.IDE_SEXO
							, 
							P.NOME_ESPOSA
							, 
							P.DTNASC_ESPOSA
							, 
							P.FAIXA_RENDA_IND
							, 
							P.FAIXA_RENDA_FAM
							, 
							P.NUM_CONTR_VINCULO
							, 
							P.COD_CORRESP_BANC
							, 
							P.COD_ORIGEM_PROPOSTA
							, 
							P.COD_OPER_CREDITO
							, 
							C.NOME_RAZAO
							, 
							C.CGCCPF
							, 
							C.DATA_NASCIMENTO
							, 
							E.SIGLA_UF
							, 
							H.IMP_MORNATU
							, 
							H.VLPREMIO
							, 
							PF.COD_PLANO
							, 
							PF.NUM_SICOB
							, 
							( P.DATA_QUITACAO + PF.COD_PLANO MONTH) 
							FROM SEGUROS.PROPOSTAS_VA P
							, 
							SEGUROS.CLIENTES C
							, 
							SEGUROS.HIS_COBER_PROPOST H
							, 
							SEGUROS.ENDERECOS E
							, 
							SEGUROS.PROPOSTA_FIDELIZ PF 
							WHERE DATE(P.TIMESTAMP) >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND P.NUM_APOLICE BETWEEN 0107700000000 AND 
							0107799999999 
							AND P.COD_PRODUTO NOT IN (7732
							, 7733) 
							AND P.COD_CLIENTE = C.COD_CLIENTE 
							AND P.NUM_CERTIFICADO = H.NUM_CERTIFICADO 
							AND P.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND P.COD_CLIENTE = E.COD_CLIENTE 
							AND P.OCOREND = E.OCORR_ENDERECO 
							AND P.NUM_CERTIFICADO = PF.NUM_PROPOSTA_SIVPF 
							ORDER BY P.NUM_APOLICE
							, 
							P.NUM_CERTIFICADO";

                return query;
            }
            PRESTAMISTA.GetQueryEvent += GetQuery_PRESTAMISTA;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-PRESTAMISTA-DB-OPEN-1 */
        public void R0300_00_DECLARE_PRESTAMISTA_DB_OPEN_1()
        {
            /*" -653- EXEC SQL OPEN PRESTAMISTA END-EXEC. */

            PRESTAMISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-FETCH-PRESTAMISTA */
        private void R0400_00_FETCH_PRESTAMISTA(bool isPerform = false)
        {
            /*" -669- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -680- INITIALIZE WS-NULL WS-NULL1 WS-NULL2 WS-NULL3 WS-NULL4 WS-NULL5 WS-NULL6 WS-NULL7 WS-NULL8 WS-NULL9. */
            _.Initialize(
                WS_NULL
                , WS_NULL1
                , WS_NULL2
                , WS_NULL3
                , WS_NULL4
                , WS_NULL5
                , WS_NULL6
                , WS_NULL7
                , WS_NULL8
                , WS_NULL9
            );

            /*" -708- PERFORM R0400_00_FETCH_PRESTAMISTA_DB_FETCH_1 */

            R0400_00_FETCH_PRESTAMISTA_DB_FETCH_1();

            /*" -711- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -712- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -713- MOVE 'S' TO WFIM-PRESTAMISTA */
                    _.Move("S", AREA_DE_WORK.WSAIDA_AREA.WFIM_PRESTAMISTA);

                    /*" -713- PERFORM R0400_00_FETCH_PRESTAMISTA_DB_CLOSE_1 */

                    R0400_00_FETCH_PRESTAMISTA_DB_CLOSE_1();

                    /*" -715- ELSE */
                }
                else
                {


                    /*" -716- DISPLAY 'ERRO NO FETCH   DO CURSOR PRESTAMISTA ' */
                    _.Display($"ERRO NO FETCH   DO CURSOR PRESTAMISTA ");

                    /*" -717- DISPLAY 'SQLERRMC: ' SQLERRMC */
                    _.Display($"SQLERRMC: {DB.SQLERRMC}");

                    /*" -718- DISPLAY 'LIDOS ATE O MOMENTO: ' WCONT-PRESTAMISTA */
                    _.Display($"LIDOS ATE O MOMENTO: {AREA_DE_WORK.WCONT_PRESTAMISTA}");

                    /*" -719- PERFORM R9999-ROT-ERRO THRU R9999-SAIDA */

                    R9999_ROT_ERRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/


                    /*" -720- END-IF */
                }


                /*" -721- ELSE */
            }
            else
            {


                /*" -722- ADD 1 TO WCONT-PRESTAMISTA */
                AREA_DE_WORK.WCONT_PRESTAMISTA.Value = AREA_DE_WORK.WCONT_PRESTAMISTA + 1;

                /*" -723- IF WS-NULL < 0 */

                if (WS_NULL < 0)
                {

                    /*" -724- MOVE SPACES TO PROPOVA-NOME-ESPOSA */
                    _.Move("", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NOME_ESPOSA);

                    /*" -725- END-IF */
                }


                /*" -726- IF WS-NULL1 < 0 */

                if (WS_NULL1 < 0)
                {

                    /*" -727- MOVE '0001-01-01' TO PROPOVA-DTNASC-ESPOSA */
                    _.Move("0001-01-01", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA);

                    /*" -728- END-IF */
                }


                /*" -729- IF WS-NULL2 < 0 */

                if (WS_NULL2 < 0)
                {

                    /*" -730- MOVE SPACES TO PROPOVA-FAIXA-RENDA-IND */
                    _.Move("", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND);

                    /*" -731- END-IF */
                }


                /*" -732- IF WS-NULL3 < 0 */

                if (WS_NULL3 < 0)
                {

                    /*" -733- MOVE SPACES TO PROPOVA-FAIXA-RENDA-FAM */
                    _.Move("", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);

                    /*" -735- END-IF */
                }


                /*" -736- IF WS-NULL4 < 0 */

                if (WS_NULL4 < 0)
                {

                    /*" -737- MOVE ZEROS TO PROPOVA-NUM-CONTR-VINCULO */
                    _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTR_VINCULO);

                    /*" -738- MOVE SPACES TO R1-NUM-CONTRATO */
                    _.Move("", AREA_DE_WORK.REG01.R1_NUM_CONTRATO);

                    /*" -739- ELSE */
                }
                else
                {


                    /*" -741- MOVE PROPOVA-NUM-CONTR-VINCULO TO R1-NUM-CONTRATO */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTR_VINCULO, AREA_DE_WORK.REG01.R1_NUM_CONTRATO);

                    /*" -743- END-IF */
                }


                /*" -744- IF WS-NULL5 < 0 */

                if (WS_NULL5 < 0)
                {

                    /*" -745- MOVE ZEROS TO PROPOVA-COD-CORRESP-BANC */
                    _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CORRESP_BANC);

                    /*" -746- MOVE SPACES TO R1-NUM-CORRESPOND */
                    _.Move("", AREA_DE_WORK.REG01.R1_NUM_CORRESPOND);

                    /*" -747- ELSE */
                }
                else
                {


                    /*" -749- MOVE PROPOVA-COD-CORRESP-BANC TO R1-NUM-CORRESPOND */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CORRESP_BANC, AREA_DE_WORK.REG01.R1_NUM_CORRESPOND);

                    /*" -751- END-IF */
                }


                /*" -752- IF WS-NULL6 < 0 */

                if (WS_NULL6 < 0)
                {

                    /*" -753- MOVE ZEROS TO PROPOVA-COD-ORIGEM-PROPOSTA */
                    _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_ORIGEM_PROPOSTA);

                    /*" -754- MOVE SPACES TO R1-ORI-VENDA */
                    _.Move("", AREA_DE_WORK.REG01.R1_ORI_VENDA);

                    /*" -755- ELSE */
                }
                else
                {


                    /*" -756- MOVE PROPOVA-COD-ORIGEM-PROPOSTA TO R1-ORI-VENDA */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_ORIGEM_PROPOSTA, AREA_DE_WORK.REG01.R1_ORI_VENDA);

                    /*" -758- END-IF */
                }


                /*" -759- IF WS-NULL7 < 0 */

                if (WS_NULL7 < 0)
                {

                    /*" -760- MOVE ZEROS TO PROPOVA-COD-OPER-CREDITO */
                    _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPER_CREDITO);

                    /*" -762- MOVE SPACES TO R1-OPER-CREDITO R1-DES-OPER-CREDITO */
                    _.Move("", AREA_DE_WORK.REG01.R1_OPER_CREDITO, AREA_DE_WORK.REG01.R1_DES_OPER_CREDITO);

                    /*" -763- ELSE */
                }
                else
                {


                    /*" -766- MOVE PROPOVA-COD-OPER-CREDITO TO R1-OPER-CREDITO GE372-COD-OPER-CREDITO */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPER_CREDITO, AREA_DE_WORK.REG01.R1_OPER_CREDITO, GE372.DCLGE_OPER_CREDITO.GE372_COD_OPER_CREDITO);

                    /*" -767- PERFORM R0800-00-LE-GE-OPE-CRE THRU R0800-99-SAIDA */

                    R0800_00_LE_GE_OPE_CRE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/


                    /*" -768- MOVE GE372-DES-OPER-CREDITO TO R1-DES-OPER-CREDITO */
                    _.Move(GE372.DCLGE_OPER_CREDITO.GE372_DES_OPER_CREDITO, AREA_DE_WORK.REG01.R1_DES_OPER_CREDITO);

                    /*" -770- END-IF */
                }


                /*" -771- IF WS-NULL8 < 0 */

                if (WS_NULL8 < 0)
                {

                    /*" -772- MOVE SPACES TO R1-DATA-NASCIMENTO */
                    _.Move("", AREA_DE_WORK.REG01.R1_DATA_NASCIMENTO);

                    /*" -773- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                    _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                    /*" -774- ELSE */
                }
                else
                {


                    /*" -775- MOVE CLIENTES-DATA-NASCIMENTO TO R1-DATA-NASCIMENTO */
                    _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, AREA_DE_WORK.REG01.R1_DATA_NASCIMENTO);

                    /*" -777- END-IF */
                }


                /*" -778- IF PROPOVA-AGE-COBRANCA EQUAL ZEROS */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA == 00)
                {

                    /*" -779- MOVE SPACES TO R1-AGE-VENDA */
                    _.Move("", AREA_DE_WORK.REG01.R1_AGE_VENDA);

                    /*" -780- ELSE */
                }
                else
                {


                    /*" -781- MOVE PROPOVA-AGE-COBRANCA TO R1-AGE-VENDA */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, AREA_DE_WORK.REG01.R1_AGE_VENDA);

                    /*" -783- END-IF */
                }


                /*" -784- EVALUATE PROPOVA-COD-ORIGEM-PROPOSTA */
                switch (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_ORIGEM_PROPOSTA.Value)
                {

                    /*" -785- WHEN 01 */
                    case 01:

                        /*" -786- MOVE 'SIGPF' TO R1-DESCRICAO */
                        _.Move("SIGPF", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -787- WHEN 02 */
                        break;
                    case 02:

                        /*" -788- MOVE 'CAIXA-PREV' TO R1-DESCRICAO */
                        _.Move("CAIXA-PREV", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -789- WHEN 03 */
                        break;
                    case 03:

                        /*" -790- MOVE 'VENDA ELETRONICA/SIGAT' TO R1-DESCRICAO */
                        _.Move("VENDA ELETRONICA/SIGAT", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -791- WHEN 04 */
                        break;
                    case 04:

                        /*" -792- MOVE 'SASSE' TO R1-DESCRICAO */
                        _.Move("SASSE", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -793- WHEN 05 */
                        break;
                    case 05:

                        /*" -794- MOVE 'GITEL' TO R1-DESCRICAO */
                        _.Move("GITEL", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -795- WHEN 06 */
                        break;
                    case 06:

                        /*" -796- MOVE 'MANUAL' TO R1-DESCRICAO */
                        _.Move("MANUAL", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -797- WHEN 07 */
                        break;
                    case 07:

                        /*" -798- MOVE 'VENDAS REMOTAS' TO R1-DESCRICAO */
                        _.Move("VENDAS REMOTAS", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -799- WHEN 08 */
                        break;
                    case 08:

                        /*" -800- MOVE 'INTRANET' TO R1-DESCRICAO */
                        _.Move("INTRANET", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -801- WHEN 09 */
                        break;
                    case 09:

                        /*" -802- MOVE 'INTERNET' TO R1-DESCRICAO */
                        _.Move("INTERNET", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -803- WHEN 10 */
                        break;
                    case 10:

                        /*" -804- MOVE 'CORRET VIT' TO R1-DESCRICAO */
                        _.Move("CORRET VIT", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -805- WHEN 11 */
                        break;
                    case 11:

                        /*" -806- MOVE 'FILIAL' TO R1-DESCRICAO */
                        _.Move("FILIAL", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -807- WHEN 12 */
                        break;
                    case 12:

                        /*" -808- MOVE 'MARSH' TO R1-DESCRICAO */
                        _.Move("MARSH", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -809- WHEN 13 */
                        break;
                    case 13:

                        /*" -810- MOVE 'LOTERICO' TO R1-DESCRICAO */
                        _.Move("LOTERICO", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -811- WHEN 14 */
                        break;
                    case 14:

                        /*" -812- MOVE 'CORRESPONDENTE' TO R1-DESCRICAO */
                        _.Move("CORRESPONDENTE", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -813- WHEN OTHER */
                        break;
                    default:

                        /*" -814- MOVE SPACES TO R1-DESCRICAO */
                        _.Move("", AREA_DE_WORK.REG01.R1_DESCRICAO);

                        /*" -816- END-EVALUATE */
                        break;
                }


                /*" -817- EVALUATE PROPOVA-SIT-REGISTRO */
                switch (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.Value.Trim())
                {

                    /*" -818- WHEN                '0' */
                    case "0":

                        /*" -819- MOVE 'ACEITO.AGUARDANDO EMISSAO' TO R1-SIT-REGISTRO */
                        _.Move("ACEITO.AGUARDANDO EMISSAO", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -820- WHEN                '1' */
                        break;
                    case "1":

                        /*" -821- MOVE 'EM CRITICA ' TO R1-SIT-REGISTRO */
                        _.Move("EM CRITICA ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -822- WHEN                '2' */
                        break;
                    case "2":

                        /*" -823- MOVE 'NAO ACEITO ' TO R1-SIT-REGISTRO */
                        _.Move("NAO ACEITO ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -824- WHEN                '3' */
                        break;
                    case "3":

                        /*" -825- MOVE 'INTEGRADO  ' TO R1-SIT-REGISTRO */
                        _.Move("INTEGRADO  ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -826- WHEN                '4' */
                        break;
                    case "4":

                        /*" -827- MOVE 'CANCELADO  ' TO R1-SIT-REGISTRO */
                        _.Move("CANCELADO  ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -828- WHEN                '5' */
                        break;
                    case "5":

                        /*" -829- MOVE 'RCAP NAO ENCONTRADO ' TO R1-SIT-REGISTRO */
                        _.Move("RCAP NAO ENCONTRADO ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -830- WHEN                '6' */
                        break;
                    case "6":

                        /*" -831- MOVE 'COBERTURA SUSPENSA' TO R1-SIT-REGISTRO */
                        _.Move("COBERTURA SUSPENSA", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -832- WHEN                '7' */
                        break;
                    case "7":

                        /*" -833- MOVE 'AGUARDA EMISSAO 1A. PARCELA' TO R1-SIT-REGISTRO */
                        _.Move("AGUARDA EMISSAO 1A. PARCELA", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -834- WHEN                '9' */
                        break;
                    case "9":

                        /*" -835- MOVE 'AGUARDANDO PROPOSTA FISICA' TO R1-SIT-REGISTRO */
                        _.Move("AGUARDANDO PROPOSTA FISICA", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -836- WHEN                'A' */
                        break;
                    case "A":

                        /*" -837- MOVE 'INTEGRAR            ' TO R1-SIT-REGISTRO */
                        _.Move("INTEGRAR            ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -838- WHEN                'B' */
                        break;
                    case "B":

                        /*" -839- MOVE 'INTEGRADA PROPOSTA NOVA' TO R1-SIT-REGISTRO */
                        _.Move("INTEGRADA PROPOSTA NOVA", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -840- WHEN                'C' */
                        break;
                    case "C":

                        /*" -841- MOVE 'INTEGRADA MIGRADA ' TO R1-SIT-REGISTRO */
                        _.Move("INTEGRADA MIGRADA ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -842- WHEN                'D' */
                        break;
                    case "D":

                        /*" -843- MOVE 'UTILIZADO PELO SAUDE ' TO R1-SIT-REGISTRO */
                        _.Move("UTILIZADO PELO SAUDE ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -844- WHEN                'E' */
                        break;
                    case "E":

                        /*" -845- MOVE 'AGUARDANDO CRIVO ' TO R1-SIT-REGISTRO */
                        _.Move("AGUARDANDO CRIVO ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -846- WHEN                OTHER */
                        break;
                    default:

                        /*" -847- MOVE 'DESCONHECIDO ' TO R1-SIT-REGISTRO */
                        _.Move("DESCONHECIDO ", AREA_DE_WORK.REG01.R1_SIT_REGISTRO);

                        /*" -849- END-EVALUATE */
                        break;
                }


                /*" -850- MOVE PROPOVA-PROFISSAO TO R1-PROFISSAO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO, AREA_DE_WORK.REG01.R1_PROFISSAO);

                /*" -851- MOVE PROPOVA-NUM-APOLICE TO R1-NUM-APOLICE */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, AREA_DE_WORK.REG01.R1_NUM_APOLICE);

                /*" -852- MOVE PROPOVA-NUM-CERTIFICADO TO R1-NUM-CERTIFICADO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, AREA_DE_WORK.REG01.R1_NUM_CERTIFICADO);

                /*" -853- MOVE PROPOVA-COD-PRODUTO TO R1-COD-PRODUTO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, AREA_DE_WORK.REG01.R1_COD_PRODUTO);

                /*" -854- MOVE CLIENTES-NOME-RAZAO TO R1-NOME-RAZAO */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.REG01.R1_NOME_RAZAO);

                /*" -855- MOVE CLIENTES-CGCCPF TO R1-CGCCPF */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.REG01.R1_CGCCPF);

                /*" -856- MOVE PROPOVA-IDE-SEXO TO R1-IDE-SEXO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO, AREA_DE_WORK.REG01.R1_IDE_SEXO);

                /*" -857- MOVE ENDERECO-SIGLA-UF TO R1-SIGLA-UF */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, AREA_DE_WORK.REG01.R1_SIGLA_UF);

                /*" -858- IF PROPOVA-COD-PRODUTO = 7701 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 7701)
                {

                    /*" -859- PERFORM M-0900-BUSCA-NUM-PARCELA THRU R0900-99-SAIDA */

                    M_0900_BUSCA_NUM_PARCELA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/


                    /*" -860- PERFORM 1000-BUSCA-VALORES2 THRU R1000-99-SAIDA */

                    M_1000_BUSCA_VALORES2(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/


                    /*" -861- MOVE HISCOBPR-IMP-MORNATU TO R1-IMP-MORNATU */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, AREA_DE_WORK.REG01.R1_IMP_MORNATU);

                    /*" -862- MOVE HISCOBPR-VLPREMIO TO R1-VLPREMIO */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, AREA_DE_WORK.REG01.R1_VLPREMIO);

                    /*" -863- ELSE */
                }
                else
                {


                    /*" -864- MOVE HISCOBPR-IMP-MORNATU TO R1-IMP-MORNATU */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, AREA_DE_WORK.REG01.R1_IMP_MORNATU);

                    /*" -865- MOVE HISCOBPR-VLPREMIO TO R1-VLPREMIO */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, AREA_DE_WORK.REG01.R1_VLPREMIO);

                    /*" -866- END-IF */
                }


                /*" -867- MOVE PROPOFID-COD-PLANO TO R1-COD-PLANO */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, AREA_DE_WORK.REG01.R1_COD_PLANO);

                /*" -869- MOVE PROPOVA-NOME-ESPOSA TO R1-NOME-ESPOSA */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NOME_ESPOSA, AREA_DE_WORK.REG01.R1_NOME_ESPOSA);

                /*" -870- IF PROPOVA-DTNASC-ESPOSA = '0001-01-01' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA == "0001-01-01")
                {

                    /*" -871- MOVE SPACES TO R1-DTNASC-ESPOSA */
                    _.Move("", AREA_DE_WORK.REG01.R1_DTNASC_ESPOSA);

                    /*" -872- ELSE */
                }
                else
                {


                    /*" -873- MOVE PROPOVA-DTNASC-ESPOSA TO R1-DTNASC-ESPOSA */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA, AREA_DE_WORK.REG01.R1_DTNASC_ESPOSA);

                    /*" -875- END-IF */
                }


                /*" -876- MOVE PROPOVA-AGE-COBRANCA TO R1-AGE-COBRANCA */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, AREA_DE_WORK.REG01.R1_AGE_COBRANCA);

                /*" -878- MOVE PROPOVA-DATA-QUITACAO TO R1-DATA-QUITACAO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, AREA_DE_WORK.REG01.R1_DATA_QUITACAO);

                /*" -879- IF PROPOVA-NUM-MATRI-VENDEDOR EQUAL ZEROS */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR == 00)
                {

                    /*" -881- MOVE SPACES TO R1-MAT-VENDEDOR R1-NOME-VENDEDOR */
                    _.Move("", AREA_DE_WORK.REG01.R1_MAT_VENDEDOR, AREA_DE_WORK.REG01.R1_NOME_VENDEDOR);

                    /*" -882- ELSE */
                }
                else
                {


                    /*" -883- PERFORM R0500-00-LE-MAT-FUNC THRU R0500-99-SAIDA */

                    R0500_00_LE_MAT_FUNC(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/


                    /*" -885- END-IF */
                }


                /*" -886- IF PROPOVA-COD-CLIENTE EQUAL ZEROS */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE == 00)
                {

                    /*" -887- MOVE SPACES TO R1-NUM-RG */
                    _.Move("", AREA_DE_WORK.REG01.R1_NUM_RG);

                    /*" -888- ELSE */
                }
                else
                {


                    /*" -889- PERFORM R0600-00-LE-GEDOC-CLI THRU R0600-99-SAIDA */

                    R0600_00_LE_GEDOC_CLI(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/


                    /*" -891- END-IF */
                }


                /*" -892- IF PROPOVA-FAIXA-RENDA-IND EQUAL SPACES */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND.IsEmpty())
                {

                    /*" -894- MOVE ZEROS TO R1-REN-INDIV-INI R1-REN-INDIV-FIM */
                    _.Move(0, AREA_DE_WORK.REG01.R1_REN_INDIV_INI, AREA_DE_WORK.REG01.R1_REN_INDIV_FIM);

                    /*" -895- ELSE */
                }
                else
                {


                    /*" -896- MOVE PROPOVA-FAIXA-RENDA-IND TO GE243-NUM-FAIXA-RENDA */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, GE243.DCLGE_FAIXA_RENDA.GE243_NUM_FAIXA_RENDA);

                    /*" -897- PERFORM R0700-00-LE-GE-FAI-REN THRU R0700-99-SAIDA */

                    R0700_00_LE_GE_FAI_REN(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/


                    /*" -898- MOVE GE243-VLR-MIN-FAIXA TO R1-REN-INDIV-INI */
                    _.Move(GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MIN_FAIXA, AREA_DE_WORK.REG01.R1_REN_INDIV_INI);

                    /*" -899- MOVE GE243-VLR-MAX-FAIXA TO R1-REN-INDIV-FIM */
                    _.Move(GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MAX_FAIXA, AREA_DE_WORK.REG01.R1_REN_INDIV_FIM);

                    /*" -901- END-IF */
                }


                /*" -902- IF PROPOVA-FAIXA-RENDA-FAM EQUAL SPACES */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM.IsEmpty())
                {

                    /*" -904- MOVE ZEROS TO R1-REN-FAMIL-INI R1-REN-FAMIL-FIM */
                    _.Move(0, AREA_DE_WORK.REG01.R1_REN_FAMIL_INI, AREA_DE_WORK.REG01.R1_REN_FAMIL_FIM);

                    /*" -905- ELSE */
                }
                else
                {


                    /*" -906- MOVE PROPOVA-FAIXA-RENDA-FAM TO GE243-NUM-FAIXA-RENDA */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, GE243.DCLGE_FAIXA_RENDA.GE243_NUM_FAIXA_RENDA);

                    /*" -907- PERFORM R0700-00-LE-GE-FAI-REN THRU R0700-99-SAIDA */

                    R0700_00_LE_GE_FAI_REN(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/


                    /*" -908- MOVE GE243-VLR-MIN-FAIXA TO R1-REN-FAMIL-INI */
                    _.Move(GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MIN_FAIXA, AREA_DE_WORK.REG01.R1_REN_FAMIL_INI);

                    /*" -909- MOVE GE243-VLR-MAX-FAIXA TO R1-REN-FAMIL-FIM */
                    _.Move(GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MAX_FAIXA, AREA_DE_WORK.REG01.R1_REN_FAMIL_FIM);

                    /*" -911- END-IF */
                }


                /*" -912- MOVE PROPOVA-DATA-QUITACAO TO R1-DATA-DE-VENDA */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, AREA_DE_WORK.REG01.R1_DATA_DE_VENDA);

                /*" -913- MOVE PROPOVA-DATA-QUITACAO TO R1-INICIO-VIG */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, AREA_DE_WORK.REG01.R1_INICIO_VIG);

                /*" -915- MOVE WS-FIM-DE-VIGENCIA TO R1-DTH-FIM-VIG */
                _.Move(WS_FIM_DE_VIGENCIA, AREA_DE_WORK.REG01.R1_DTH_FIM_VIG);

                /*" -916- PERFORM 1100-00-BUSCA-ENDOSSO THRU R1100-99-SAIDA */

                M_1100_00_BUSCA_ENDOSSO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/


                /*" -917- MOVE HISCONPA-NUM-ENDOSSO TO R1-NUM-ENDOSSO */
                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, AREA_DE_WORK.REG01.R1_NUM_ENDOSSO);

                /*" -919- MOVE PROPOFID-NUM-SICOB TO R1-NUM-SICOB */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, AREA_DE_WORK.REG01.R1_NUM_SICOB);

                /*" -920- WRITE REG-ARQVA590 FROM REG01 */
                _.Move(AREA_DE_WORK.REG01.GetMoveValues(), REG_ARQVA590);

                ARQVA590.Write(REG_ARQVA590.GetMoveValues().ToString());

                /*" -920- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-FETCH-PRESTAMISTA-DB-FETCH-1 */
        public void R0400_00_FETCH_PRESTAMISTA_DB_FETCH_1()
        {
            /*" -708- EXEC SQL FETCH PRESTAMISTA INTO :PROPOVA-NUM-CERTIFICADO ,:PROPOVA-COD-PRODUTO ,:PROPOVA-COD-CLIENTE ,:PROPOVA-AGE-COBRANCA ,:PROPOVA-DATA-QUITACAO ,:PROPOVA-NUM-MATRI-VENDEDOR ,:PROPOVA-PROFISSAO ,:PROPOVA-SIT-REGISTRO ,:PROPOVA-NUM-APOLICE ,:PROPOVA-IDE-SEXO ,:PROPOVA-NOME-ESPOSA :WS-NULL ,:PROPOVA-DTNASC-ESPOSA :WS-NULL1 ,:PROPOVA-FAIXA-RENDA-IND :WS-NULL2 ,:PROPOVA-FAIXA-RENDA-FAM :WS-NULL3 ,:PROPOVA-NUM-CONTR-VINCULO :WS-NULL4 ,:PROPOVA-COD-CORRESP-BANC :WS-NULL5 ,:PROPOVA-COD-ORIGEM-PROPOSTA :WS-NULL6 ,:PROPOVA-COD-OPER-CREDITO :WS-NULL7 ,:CLIENTES-NOME-RAZAO ,:CLIENTES-CGCCPF ,:CLIENTES-DATA-NASCIMENTO :WS-NULL8 ,:ENDERECO-SIGLA-UF ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-VLPREMIO ,:PROPOFID-COD-PLANO ,:PROPOFID-NUM-SICOB ,:WS-FIM-DE-VIGENCIA END-EXEC. */

            if (PRESTAMISTA.Fetch())
            {
                _.Move(PRESTAMISTA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(PRESTAMISTA.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(PRESTAMISTA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(PRESTAMISTA.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(PRESTAMISTA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(PRESTAMISTA.PROPOVA_NUM_MATRI_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);
                _.Move(PRESTAMISTA.PROPOVA_PROFISSAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO);
                _.Move(PRESTAMISTA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(PRESTAMISTA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(PRESTAMISTA.PROPOVA_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);
                _.Move(PRESTAMISTA.PROPOVA_NOME_ESPOSA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NOME_ESPOSA);
                _.Move(PRESTAMISTA.WS_NULL, WS_NULL);
                _.Move(PRESTAMISTA.PROPOVA_DTNASC_ESPOSA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA);
                _.Move(PRESTAMISTA.WS_NULL1, WS_NULL1);
                _.Move(PRESTAMISTA.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND);
                _.Move(PRESTAMISTA.WS_NULL2, WS_NULL2);
                _.Move(PRESTAMISTA.PROPOVA_FAIXA_RENDA_FAM, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);
                _.Move(PRESTAMISTA.WS_NULL3, WS_NULL3);
                _.Move(PRESTAMISTA.PROPOVA_NUM_CONTR_VINCULO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTR_VINCULO);
                _.Move(PRESTAMISTA.WS_NULL4, WS_NULL4);
                _.Move(PRESTAMISTA.PROPOVA_COD_CORRESP_BANC, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CORRESP_BANC);
                _.Move(PRESTAMISTA.WS_NULL5, WS_NULL5);
                _.Move(PRESTAMISTA.PROPOVA_COD_ORIGEM_PROPOSTA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_ORIGEM_PROPOSTA);
                _.Move(PRESTAMISTA.WS_NULL6, WS_NULL6);
                _.Move(PRESTAMISTA.PROPOVA_COD_OPER_CREDITO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPER_CREDITO);
                _.Move(PRESTAMISTA.WS_NULL7, WS_NULL7);
                _.Move(PRESTAMISTA.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(PRESTAMISTA.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(PRESTAMISTA.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(PRESTAMISTA.WS_NULL8, WS_NULL8);
                _.Move(PRESTAMISTA.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(PRESTAMISTA.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(PRESTAMISTA.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(PRESTAMISTA.PROPOFID_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);
                _.Move(PRESTAMISTA.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(PRESTAMISTA.WS_FIM_DE_VIGENCIA, WS_FIM_DE_VIGENCIA);
            }

        }

        [StopWatch]
        /*" R0400-00-FETCH-PRESTAMISTA-DB-CLOSE-1 */
        public void R0400_00_FETCH_PRESTAMISTA_DB_CLOSE_1()
        {
            /*" -713- EXEC SQL CLOSE PRESTAMISTA END-EXEC */

            PRESTAMISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-LE-MAT-FUNC */
        private void R0500_00_LE_MAT_FUNC(bool isPerform = false)
        {
            /*" -931- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -934- MOVE PROPOVA-NUM-MATRI-VENDEDOR TO FUNCICEF-NUM-MATRICULA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA);

            /*" -942- PERFORM R0500_00_LE_MAT_FUNC_DB_SELECT_1 */

            R0500_00_LE_MAT_FUNC_DB_SELECT_1();

            /*" -945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -946- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -948- MOVE SPACES TO R1-MAT-VENDEDOR R1-NOME-VENDEDOR */
                    _.Move("", AREA_DE_WORK.REG01.R1_MAT_VENDEDOR, AREA_DE_WORK.REG01.R1_NOME_VENDEDOR);

                    /*" -949- ELSE */
                }
                else
                {


                    /*" -950- DISPLAY 'ERRO NO SELECT - SEGUROS.FUNCIONARIOS_CEF' */
                    _.Display($"ERRO NO SELECT - SEGUROS.FUNCIONARIOS_CEF");

                    /*" -951- DISPLAY 'NUM_CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -952- PERFORM R9999-ROT-ERRO THRU R9999-SAIDA */

                    R9999_ROT_ERRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/


                    /*" -953- END-IF */
                }


                /*" -954- ELSE */
            }
            else
            {


                /*" -955- IF FUNCICEF-NUM-MATRICULA EQUAL ZEROS */

                if (FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA == 00)
                {

                    /*" -956- MOVE PROPOVA-NUM-MATRI-VENDEDOR TO R1-MAT-VENDEDOR */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR, AREA_DE_WORK.REG01.R1_MAT_VENDEDOR);

                    /*" -957- ELSE */
                }
                else
                {


                    /*" -958- MOVE FUNCICEF-NUM-MATRICULA TO R1-MAT-VENDEDOR */
                    _.Move(FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA, AREA_DE_WORK.REG01.R1_MAT_VENDEDOR);

                    /*" -960- END-IF */
                }


                /*" -961- IF FUNCICEF-NOME-FUNCIONARIO EQUAL SPACES */

                if (FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO.IsEmpty())
                {

                    /*" -962- MOVE SPACES TO R1-NOME-VENDEDOR */
                    _.Move("", AREA_DE_WORK.REG01.R1_NOME_VENDEDOR);

                    /*" -963- ELSE */
                }
                else
                {


                    /*" -964- MOVE FUNCICEF-NOME-FUNCIONARIO TO R1-NOME-VENDEDOR */
                    _.Move(FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO, AREA_DE_WORK.REG01.R1_NOME_VENDEDOR);

                    /*" -965- END-IF */
                }


                /*" -965- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-LE-MAT-FUNC-DB-SELECT-1 */
        public void R0500_00_LE_MAT_FUNC_DB_SELECT_1()
        {
            /*" -942- EXEC SQL SELECT NUM_MATRICULA , NOME_FUNCIONARIO INTO :FUNCICEF-NUM-MATRICULA ,:FUNCICEF-NOME-FUNCIONARIO FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA WITH UR END-EXEC. */

            var r0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1 = new R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1()
            {
                FUNCICEF_NUM_MATRICULA = FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA.ToString(),
            };

            var executed_1 = R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1.Execute(r0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_NUM_MATRICULA, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA);
                _.Move(executed_1.FUNCICEF_NOME_FUNCIONARIO, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-LE-GEDOC-CLI */
        private void R0600_00_LE_GEDOC_CLI(bool isPerform = false)
        {
            /*" -975- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -976- MOVE PROPOVA-COD-CLIENTE TO GEDOCCLI-COD-CLIENTE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -988- PERFORM R0600_00_LE_GEDOC_CLI_DB_SELECT_1 */

            R0600_00_LE_GEDOC_CLI_DB_SELECT_1();

            /*" -991- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -992- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -996- MOVE SPACES TO R1-NUM-RG R1-DTA-EXPEDICAO R1-ORGAO-EMIS-RG R1-UF */
                    _.Move("", AREA_DE_WORK.REG01.R1_NUM_RG, AREA_DE_WORK.REG01.R1_DTA_EXPEDICAO, AREA_DE_WORK.REG01.R1_ORGAO_EMIS_RG, AREA_DE_WORK.REG01.R1_UF);

                    /*" -997- ELSE */
                }
                else
                {


                    /*" -998- DISPLAY 'ERRO NO SELECT - SEGUROS.GE_DOC_CLIENTE' */
                    _.Display($"ERRO NO SELECT - SEGUROS.GE_DOC_CLIENTE");

                    /*" -999- DISPLAY 'NUM_CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1000- PERFORM R9999-ROT-ERRO THRU R9999-SAIDA */

                    R9999_ROT_ERRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/


                    /*" -1001- END-IF */
                }


                /*" -1002- ELSE */
            }
            else
            {


                /*" -1003- MOVE GEDOCCLI-COD-IDENTIFICACAO TO R1-NUM-RG */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO, AREA_DE_WORK.REG01.R1_NUM_RG);

                /*" -1004- MOVE GEDOCCLI-NOM-ORGAO-EXP TO R1-ORGAO-EMIS-RG */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP, AREA_DE_WORK.REG01.R1_ORGAO_EMIS_RG);

                /*" -1005- MOVE GEDOCCLI-DTH-EXPEDICAO TO R1-DTA-EXPEDICAO */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO, AREA_DE_WORK.REG01.R1_DTA_EXPEDICAO);

                /*" -1006- IF WS-NULL9 < 0 */

                if (WS_NULL9 < 0)
                {

                    /*" -1007- MOVE SPACES TO R1-UF */
                    _.Move("", AREA_DE_WORK.REG01.R1_UF);

                    /*" -1008- ELSE */
                }
                else
                {


                    /*" -1009- MOVE GEDOCCLI-COD-UF TO R1-UF */
                    _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF, AREA_DE_WORK.REG01.R1_UF);

                    /*" -1010- END-IF */
                }


                /*" -1011- END-IF */
            }


            /*" -1011- . */

        }

        [StopWatch]
        /*" R0600-00-LE-GEDOC-CLI-DB-SELECT-1 */
        public void R0600_00_LE_GEDOC_CLI_DB_SELECT_1()
        {
            /*" -988- EXEC SQL SELECT COD_IDENTIFICACAO ,NOM_ORGAO_EXP ,DTH_EXPEDICAO ,COD_UF INTO :GEDOCCLI-COD-IDENTIFICACAO ,:GEDOCCLI-NOM-ORGAO-EXP ,:GEDOCCLI-DTH-EXPEDICAO ,:GEDOCCLI-COD-UF :WS-NULL9 FROM SEGUROS.GE_DOC_CLIENTE WHERE COD_CLIENTE = :GEDOCCLI-COD-CLIENTE WITH UR END-EXEC. */

            var r0600_00_LE_GEDOC_CLI_DB_SELECT_1_Query1 = new R0600_00_LE_GEDOC_CLI_DB_SELECT_1_Query1()
            {
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0600_00_LE_GEDOC_CLI_DB_SELECT_1_Query1.Execute(r0600_00_LE_GEDOC_CLI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEDOCCLI_COD_IDENTIFICACAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);
                _.Move(executed_1.GEDOCCLI_NOM_ORGAO_EXP, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);
                _.Move(executed_1.GEDOCCLI_DTH_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);
                _.Move(executed_1.GEDOCCLI_COD_UF, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
                _.Move(executed_1.WS_NULL9, WS_NULL9);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-LE-GE-FAI-REN */
        private void R0700_00_LE_GE_FAI_REN(bool isPerform = false)
        {
            /*" -1020- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1028- PERFORM R0700_00_LE_GE_FAI_REN_DB_SELECT_1 */

            R0700_00_LE_GE_FAI_REN_DB_SELECT_1();

            /*" -1031- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1032- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1034- MOVE ZEROS TO GE243-VLR-MIN-FAIXA GE243-VLR-MAX-FAIXA */
                    _.Move(0, GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MIN_FAIXA, GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MAX_FAIXA);

                    /*" -1035- ELSE */
                }
                else
                {


                    /*" -1036- DISPLAY 'ERRO NO SELECT - SEGUROS.GE_FAIXA_RENDA' */
                    _.Display($"ERRO NO SELECT - SEGUROS.GE_FAIXA_RENDA");

                    /*" -1037- DISPLAY 'NUM_CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1038- PERFORM R9999-ROT-ERRO THRU R9999-SAIDA */

                    R9999_ROT_ERRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/


                    /*" -1039- END-IF */
                }


                /*" -1039- END-IF. */
            }


        }

        [StopWatch]
        /*" R0700-00-LE-GE-FAI-REN-DB-SELECT-1 */
        public void R0700_00_LE_GE_FAI_REN_DB_SELECT_1()
        {
            /*" -1028- EXEC SQL SELECT VLR_MIN_FAIXA , VLR_MAX_FAIXA INTO :GE243-VLR-MIN-FAIXA ,:GE243-VLR-MAX-FAIXA FROM SEGUROS.GE_FAIXA_RENDA WHERE NUM_FAIXA_RENDA = :GE243-NUM-FAIXA-RENDA WITH UR END-EXEC. */

            var r0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1 = new R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1()
            {
                GE243_NUM_FAIXA_RENDA = GE243.DCLGE_FAIXA_RENDA.GE243_NUM_FAIXA_RENDA.ToString(),
            };

            var executed_1 = R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1.Execute(r0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE243_VLR_MIN_FAIXA, GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MIN_FAIXA);
                _.Move(executed_1.GE243_VLR_MAX_FAIXA, GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MAX_FAIXA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-LE-GE-OPE-CRE */
        private void R0800_00_LE_GE_OPE_CRE(bool isPerform = false)
        {
            /*" -1049- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1055- PERFORM R0800_00_LE_GE_OPE_CRE_DB_SELECT_1 */

            R0800_00_LE_GE_OPE_CRE_DB_SELECT_1();

            /*" -1058- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1059- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1060- MOVE SPACES TO GE372-DES-OPER-CREDITO */
                    _.Move("", GE372.DCLGE_OPER_CREDITO.GE372_DES_OPER_CREDITO);

                    /*" -1061- ELSE */
                }
                else
                {


                    /*" -1062- DISPLAY 'ERRO NO SELECT - SEGUROS.GE_OPER_CREDITO' */
                    _.Display($"ERRO NO SELECT - SEGUROS.GE_OPER_CREDITO");

                    /*" -1063- DISPLAY 'NUM_CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1064- PERFORM R9999-ROT-ERRO THRU R9999-SAIDA */

                    R9999_ROT_ERRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/


                    /*" -1065- END-IF */
                }


                /*" -1066- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-LE-GE-OPE-CRE-DB-SELECT-1 */
        public void R0800_00_LE_GE_OPE_CRE_DB_SELECT_1()
        {
            /*" -1055- EXEC SQL SELECT DES_OPER_CREDITO INTO :GE372-DES-OPER-CREDITO FROM SEGUROS.GE_OPER_CREDITO WHERE COD_OPER_CREDITO = :GE372-COD-OPER-CREDITO WITH UR END-EXEC. */

            var r0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1 = new R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1()
            {
                GE372_COD_OPER_CREDITO = GE372.DCLGE_OPER_CREDITO.GE372_COD_OPER_CREDITO.ToString(),
            };

            var executed_1 = R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1.Execute(r0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE372_DES_OPER_CREDITO, GE372.DCLGE_OPER_CREDITO.GE372_DES_OPER_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" M-0900-BUSCA-NUM-PARCELA */
        private void M_0900_BUSCA_NUM_PARCELA(bool isPerform = false)
        {
            /*" -1076- MOVE '0900' TO WNR-EXEC-SQL */
            _.Move("0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1082- PERFORM M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1 */

            M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1();

            /*" -1085- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1088- DISPLAY '* VA0590B ' WNR-EXEC-SQL ' SELECT PARCELA SEGUROS.HIST_CONT_PARCELVA' ' NUM_CERTIFICADO ' PROPOVA-NUM-CERTIFICADO */

                $"* VA0590B {AREA_DE_WORK.WABEND.WNR_EXEC_SQL} SELECT PARCELA SEGUROS.HIST_CONT_PARCELVA NUM_CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -1089- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -1089- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0900-BUSCA-NUM-PARCELA-DB-SELECT-1 */
        public void M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1()
        {
            /*" -1082- EXEC SQL SELECT MAX ( NUM_PARCELA ) INTO :HISCONPA-NUM-PARCELA FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC */

            var m_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1 = new M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1.Execute(m_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" M-1000-BUSCA-VALORES2 */
        private void M_1000_BUSCA_VALORES2(bool isPerform = false)
        {
            /*" -1099- MOVE '1000' TO WNR-EXEC-SQL */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1108- PERFORM M_1000_BUSCA_VALORES2_DB_SELECT_1 */

            M_1000_BUSCA_VALORES2_DB_SELECT_1();

            /*" -1111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1112- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1113- MOVE ZEROS TO HISCOBPR-IMP-MORNATU */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

                    /*" -1114- MOVE ZEROS TO HISCOBPR-VLPREMIO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);

                    /*" -1115- ELSE */
                }
                else
                {


                    /*" -1119- DISPLAY '* VA0590B ' WNR-EXEC-SQL ' SELECT HIS_COBER_PROPOS2 PARA ' ' NUM_CERTIFICADO ' PROPOVA-NUM-CERTIFICADO ' OCORR_HISTORICO ' PROPOVA-OCORR-HISTORICO */

                    $"* VA0590B {AREA_DE_WORK.WABEND.WNR_EXEC_SQL} SELECT HIS_COBER_PROPOS2 PARA  NUM_CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} OCORR_HISTORICO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -1120- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1121- END-IF */
                }


                /*" -1121- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1000-BUSCA-VALORES2-DB-SELECT-1 */
        public void M_1000_BUSCA_VALORES2_DB_SELECT_1()
        {
            /*" -1108- EXEC SQL SELECT IMP_MORNATU, VLPREMIO INTO :HISCOBPR-IMP-MORNATU , :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :HISCONPA-NUM-PARCELA WITH UR END-EXEC */

            var m_1000_BUSCA_VALORES2_DB_SELECT_1_Query1 = new M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1.Execute(m_1000_BUSCA_VALORES2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" M-1100-00-BUSCA-ENDOSSO */
        private void M_1100_00_BUSCA_ENDOSSO(bool isPerform = false)
        {
            /*" -1131- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1132- IF PROPOVA-COD-PRODUTO NOT EQUAL 7701 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO != 7701)
            {

                /*" -1133- MOVE 1 TO HISCONPA-NUM-PARCELA */
                _.Move(1, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

                /*" -1135- END-IF */
            }


            /*" -1143- PERFORM M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1 */

            M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1();

            /*" -1146- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1147- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1148- MOVE ZEROS TO HISCONPA-NUM-ENDOSSO */
                    _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);

                    /*" -1149- ELSE */
                }
                else
                {


                    /*" -1152- DISPLAY '* VA0590B ' WNR-EXEC-SQL ' SEGUROS.HIST_CONT_PARCELVA ' ' NUM_CERTIFICADO  ' PROPOVA-NUM-CERTIFICADO */

                    $"* VA0590B {AREA_DE_WORK.WABEND.WNR_EXEC_SQL} SEGUROS.HIST_CONT_PARCELVA  NUM_CERTIFICADO  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -1154- DISPLAY '* VA0590B - NUM-PARCELA = ' HISCONPA-NUM-PARCELA */
                    _.Display($"* VA0590B - NUM-PARCELA = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -1155- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1156- END-IF */
                }


                /*" -1157- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1100-00-BUSCA-ENDOSSO-DB-SELECT-1 */
        public void M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1()
        {
            /*" -1143- EXEC SQL SELECT VALUE (MAX ( NUM_ENDOSSO ), 0) INTO :HISCONPA-NUM-ENDOSSO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_PARCELA = :HISCONPA-NUM-PARCELA AND NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC */

            var m_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 = new M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1.Execute(m_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R9999-ROT-ERRO */
        private void R9999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1169- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1171- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1173- CLOSE ARQVA590. */
            ARQVA590.Close();

            /*" -1173- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1177- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1177- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}