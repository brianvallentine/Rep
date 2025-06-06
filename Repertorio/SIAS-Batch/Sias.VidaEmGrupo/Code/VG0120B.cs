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
using Sias.VidaEmGrupo.DB2.VG0120B;

namespace Code
{
    public class VG0120B
    {
        public bool IsCall { get; set; }

        public VG0120B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *      EMISSAO DE RELACAO DE SEGURADOS ATIVOS POR APOLICE        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  09/10/91  *   PROCAS     *                       *      */
        /*"      *     02     *  26/03/03  *   FREDERICO  * ALTERACAO NO RAMO-AP  *      */
        /*"      *            *            *              * PROCURAR POR FF0303   *      */
        /*"      *     03     *  04/05/04  *   MESSIAS    * TRATAR RAMO 77(PRESTA-*      */
        /*"      *            *            *              * MISTA) PROCURE MM0504 *      */
        /*"      *     04     *  03/04/07  * FAST COMPUTER* TRATAR SUBESTIPULANTE *      */
        /*"      *            *            *              *        PROCURE V.04   *      */
        /*"      *     05     *  23/10/07  * FAST COMPUTER* CORRECAO DO ABEND     *      */
        /*"      *            *            *              *        PROCURE  V.05  *      */
        /*"      *     06     *  29/11/07  * FAST COMPUTER* CORRECAO DO RELATORIO *      */
        /*"      *            *            *              *        PROCURE  V.06  *      */
        /*"      *     07     *  19/12/13  * MARINHO      * ACRESCENTAR AS INFOR- *      */
        /*"      *            *            *              * MACOES DE CNPJ ESTIPU-*      */
        /*"      *            *            *              * LANTE E SUBESTIPULANTE*      */
        /*"      *            *            *              * E VIGENCIA.                  */
        /*"      *     08     *  26/02/14  * RIBAMAR      * CADMUS 96035: ALTERAR *      */
        /*"      *            *            *              * A ROTINA              *      */
        /*"      *            *            *              * 0040-030-BUSCA-VIGENCIA      */
        /*"      *            *            *              * PARA SOLUCIONAR ABEND *      */
        /*"      *            *            *              * COM SQLCODE +100      *      */
        /*"      *     09     *  01/04/14  * RIBAMAR      * CADMUS 96100: ALTERAR *      */
        /*"      *            *            *              * PROGRAMA PARA SOLUCIO-*      */
        /*"      *            *            *              * NAR ABEND COM SQLCODE *      */
        /*"      *            *            *              * -310                  *      */
        /*"      *     10     *  04/04/14  * RIBAMAR      * CADMUS 96326: ALTERAR *      */
        /*"      *            *            *              * PROGRAMA PARA SOLUCIO-*      */
        /*"      *            *            *              * NAR ABEND COM SQLCODE *      */
        /*"      *            *            *              * +100 NO UPDATE DA     *      */
        /*"      *            *            *              * TABELA DE RELATORIOS  *      */
        /*"      *     11     *  13/05/14  * RIBAMAR      * CADMUS 97877: SOLUCIO-*      */
        /*"      *            *            *              * NAR ABEND COM SQLCODE *      */
        /*"      *            *            *              * -183 NA ROTINA        *      */
        /*"      *            *            *              *0040-030-BUSCA-VIGENCIA*      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 28/05/1998.   *      */
        /*"      ******************************************************************      */
        /*"      *                                                          *            */
        /*"      *   VERSAO 12 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RVG0120B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVG0120B
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RVG0120B); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RVG0120B, REG_IMPRESSAO); return _RVG0120B;
            }
        }
        /*"01              REG-IMPRESSAO        PIC X(132).*/
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          COBERPR-QTTITCAP            PIC S9(004)  COMP.*/
        public IntBasis COBERPR_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          COBERPR-VLCUSTCAP           PIC S9(013)V99    COMP-3*/
        public DoubleBasis COBERPR_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PRODUVG-CUSTOCAP-TOTAL   PIC  X(001).*/
        public StringBasis PRODUVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          APOLICE-RAMO             PIC S9(004) COMP.*/
        public IntBasis APOLICE_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          APOLICE-MODALIDA         PIC S9(004) COMP.*/
        public IntBasis APOLICE_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          RELAT-IDSISTEM           PIC  X(002).*/
        public StringBasis RELAT_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"01          RELAT-CODRELAT           PIC  X(008).*/
        public StringBasis RELAT_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01          RELAT-NUM-APOLICE        PIC S9(013) COMP-3.*/
        public IntBasis RELAT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          RELAT-NUM-CERTIFIC       PIC S9(015) COMP-3.*/
        public IntBasis RELAT_NUM_CERTIFIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          RELAT-COD-SUBES          PIC S9(004) COMP.*/
        public IntBasis RELAT_COD_SUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          RELAT-OPERACAO           PIC S9(004) COMP.*/
        public IntBasis RELAT_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          RELAT-SITUACAO           PIC  X(001).*/
        public StringBasis RELAT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          CLIENTE-COD-CLI          PIC S9(009) COMP.*/
        public IntBasis CLIENTE_COD_CLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          CLIENTE-NOME-RAZAO       PIC  X(040).*/
        public StringBasis CLIENTE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01          CLIENTE-CGC-CPF          PIC S9(015) COMP-3.*/
        public IntBasis CLIENTE_CGC_CPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          WHOST-COD-CLI            PIC S9(009) COMP.*/
        public IntBasis WHOST_COD_CLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          WHOST-NOME-RAZAO         PIC  X(040).*/
        public StringBasis WHOST_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01          WHOST-CGC-CPF            PIC S9(015) COMP-3.*/
        public IntBasis WHOST_CGC_CPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          HISTSEGVG-NUM-APOL       PIC S9(013)  COMP-3.*/
        public IntBasis HISTSEGVG_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          HISTSEGVG-NUM-ITEM       PIC S9(009)  COMP.*/
        public IntBasis HISTSEGVG_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          HISTSEGVG-COD-OPER       PIC S9(004)  COMP.*/
        public IntBasis HISTSEGVG_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          HISTSEGVG-DATA-MOV       PIC  X(010).*/
        public StringBasis HISTSEGVG_DATA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          HISTSEGVG-OCORR-HI       PIC S9(004)  COMP.*/
        public IntBasis HISTSEGVG_OCORR_HI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          HISTSEGVG-COD-MOEDA-IMP     PIC S9(004)  COMP.*/
        public IntBasis HISTSEGVG_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          HISTSEGVG-COD-MOEDA-PRM     PIC S9(004)  COMP.*/
        public IntBasis HISTSEGVG_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SEGURAVG-NUM-APOL           PIC S9(013)    COMP-3.*/
        public IntBasis SEGURAVG_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          SEGURAVG-COD-SUBG           PIC S9(004)    COMP.*/
        public IntBasis SEGURAVG_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SEGURAVG-COD-CLI            PIC S9(009)    COMP.*/
        public IntBasis SEGURAVG_COD_CLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          SEGURAVG-NUM-CERT           PIC S9(015)    COMP-3.*/
        public IntBasis SEGURAVG_NUM_CERT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          SEGURAVG-DAC-CERT           PIC  X(001).*/
        public StringBasis SEGURAVG_DAC_CERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-TIPO-SEG           PIC  X(001).*/
        public StringBasis SEGURAVG_TIPO_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-NUM-ITEM           PIC S9(009)    COMP.*/
        public IntBasis SEGURAVG_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          SEGURAVG-OCORR-HI           PIC S9(004)    COMP.*/
        public IntBasis SEGURAVG_OCORR_HI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SEGURAVG-EST-CIVIL          PIC  X(001).*/
        public StringBasis SEGURAVG_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-IDE-SEXO           PIC  X(001).*/
        public StringBasis SEGURAVG_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-MATRICULA          PIC S9(015)    COMP-3.*/
        public IntBasis SEGURAVG_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          SEGURAVG-DT-INIVI           PIC  X(010).*/
        public StringBasis SEGURAVG_DT_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          SEGURAVG-SIT-REG            PIC  X(001).*/
        public StringBasis SEGURAVG_SIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-DT-NASCI           PIC  X(010).*/
        public StringBasis SEGURAVG_DT_NASCI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          SISTEMA-DTMOVABE         PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          SISTEMA-DTCURRENT        PIC  X(010).*/
        public StringBasis SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          NOME-EMPRESA             PIC  X(040).*/
        public StringBasis NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01          SUBGRUPO-NUM-APOL        PIC S9(013)  COMP-3.*/
        public IntBasis SUBGRUPO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          SUBGRUPO-COD-SUBG        PIC S9(004)  COMP.*/
        public IntBasis SUBGRUPO_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBGRUPO-COD-CLI         PIC S9(009)  COMP.*/
        public IntBasis SUBGRUPO_COD_CLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          COBERAPOL-RAMO              PIC S9(004)  COMP.*/
        public IntBasis COBERAPOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          COBERAPOL-COBERT            PIC S9(004)  COMP.*/
        public IntBasis COBERAPOL_COBERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          COBERAPOL-SEGUR-IX          PIC S9(013)V99    COMP-3*/
        public DoubleBasis COBERAPOL_SEGUR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          COBERAPOL-PREM-IX           PIC S9(010)V99999 COMP-3*/
        public DoubleBasis COBERAPOL_PREM_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V99999"), 5);
        /*"01          COBERAPOL-FATOR-MULTIPLICA  PIC S9(004)  COMP.*/
        public IntBasis COBERAPOL_FATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONDTEC-NUM-APOL         PIC S9(013)  COMP-3.*/
        public IntBasis CONDTEC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          CONDTEC-COD-SUBG         PIC S9(004)  COMP.*/
        public IntBasis CONDTEC_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONDTEC-GAR-IEA          PIC S9(005)V99  COMP-3.*/
        public DoubleBasis CONDTEC_GAR_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          CONDTEC-GAR-IPA          PIC S9(005)V99  COMP-3.*/
        public DoubleBasis CONDTEC_GAR_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          CONDTEC-GAR-IPD          PIC S9(005)V99  COMP-3.*/
        public DoubleBasis CONDTEC_GAR_IPD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          CONDTEC-GAR-HD           PIC S9(005)V99  COMP-3.*/
        public DoubleBasis CONDTEC_GAR_HD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          MOEDA-VLCRUZADO     PIC S9(006)V999999999  COMP-3.*/
        public DoubleBasis MOEDA_VLCRUZADO { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V999999999"), 9);
        /*"01          PARAM-RAMO-VGAP          PIC S9(004)  COMP.*/
        public IntBasis PARAM_RAMO_VGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          PARAM-RAMO-VG            PIC S9(004)  COMP.*/
        public IntBasis PARAM_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          PARAM-RAMO-AP            PIC S9(004)  COMP.*/
        public IntBasis PARAM_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          PARAM-RAMO-PRSTMISTA     PIC S9(004)  COMP.*/
        public IntBasis PARAM_RAMO_PRSTMISTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONTACOR-BANCO           PIC S9(004)  COMP.*/
        public IntBasis CONTACOR_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONTACOR-AGENCIA         PIC S9(004)  COMP.*/
        public IntBasis CONTACOR_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONTACOR-CTA-COR         PIC S9(017)  COMP-3.*/
        public IntBasis CONTACOR_CTA_COR { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"01          CONTACOR-DAC             PIC  X(001).*/
        public StringBasis CONTACOR_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          WS-V1HISTSEGVG           PIC  X(001) VALUE SPACES.*/
        public StringBasis WS_V1HISTSEGVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          AUX-TIPO-SEGURADO        PIC  X(001).*/
        public StringBasis AUX_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          AUX-APOLICE              PIC S9(013)  COMP-3.*/
        public IntBasis AUX_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          AUX-SUBGRUPO-I           PIC S9(004)  COMP.*/
        public IntBasis AUX_SUBGRUPO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AUX-SUBGRUPO-F           PIC S9(004)  COMP.*/
        public IntBasis AUX_SUBGRUPO_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AUX-SUBGRUPO             PIC S9(004)  COMP.*/
        public IntBasis AUX_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AUX-CERTIFICADO          PIC S9(015)  COMP-3.*/
        public IntBasis AUX_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          AUX-MOEDA-IMP       PIC S9(006)V999999999 COMP-3.*/
        public DoubleBasis AUX_MOEDA_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V999999999"), 9);
        /*"01          AUX-MOEDA-PRM       PIC S9(006)V999999999 COMP-3.*/
        public DoubleBasis AUX_MOEDA_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V999999999"), 9);
        /*"01              WORK.*/
        public VG0120B_WORK WORK { get; set; } = new VG0120B_WORK();
        public class VG0120B_WORK : VarBasis
        {
            /*"    05      FILLER                   PIC  X(035) VALUE                'III INICIO DA WORKING-STORAGE III'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"III INICIO DA WORKING-STORAGE III");
            /*"    05      DATA-SQL.*/
            public VG0120B_DATA_SQL DATA_SQL { get; set; } = new VG0120B_DATA_SQL();
            public class VG0120B_DATA_SQL : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         DATA-MAQ.*/
                public VG0120B_DATA_MAQ DATA_MAQ { get; set; } = new VG0120B_DATA_MAQ();
                public class VG0120B_DATA_MAQ : VarBasis
                {
                    /*"    10       ANO               PIC  9(004).*/
                }
            }
            public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       MES               PIC  9(002).*/
            public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       DIA               PIC  9(002).*/
            public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05      DATA-NORMAL              PIC  9(008).*/
            public IntBasis DATA_NORMAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05      DATA-DDMMAA REDEFINES DATA-NORMAL.*/
            private _REDEF_VG0120B_DATA_DDMMAA _data_ddmmaa { get; set; }
            public _REDEF_VG0120B_DATA_DDMMAA DATA_DDMMAA
            {
                get { _data_ddmmaa = new _REDEF_VG0120B_DATA_DDMMAA(); _.Move(DATA_NORMAL, _data_ddmmaa); VarBasis.RedefinePassValue(DATA_NORMAL, _data_ddmmaa, DATA_NORMAL); _data_ddmmaa.ValueChanged += () => { _.Move(_data_ddmmaa, DATA_NORMAL); }; return _data_ddmmaa; }
                set { VarBasis.RedefinePassValue(value, _data_ddmmaa, DATA_NORMAL); }
            }  //Redefines
            public class _REDEF_VG0120B_DATA_DDMMAA : VarBasis
            {
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05      DATA-INVERTIDA           PIC  9(008).*/

                public _REDEF_VG0120B_DATA_DDMMAA()
                {
                    DIA_1.ValueChanged += OnValueChanged;
                    MES_1.ValueChanged += OnValueChanged;
                    ANO_1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DATA_INVERTIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05      DATA-AAMMDD REDEFINES DATA-INVERTIDA.*/
            private _REDEF_VG0120B_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_VG0120B_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_VG0120B_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_VG0120B_DATA_AAMMDD : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WHORA-OPERACAO-1    PIC 99999999.*/

                public _REDEF_VG0120B_DATA_AAMMDD()
                {
                    ANO_2.ValueChanged += OnValueChanged;
                    MES_2.ValueChanged += OnValueChanged;
                    DIA_2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WHORA_OPERACAO_1 { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
            /*"    05          WHORA-PER-X REDEFINES WHORA-OPERACAO-1.*/
            private _REDEF_VG0120B_WHORA_PER_X _whora_per_x { get; set; }
            public _REDEF_VG0120B_WHORA_PER_X WHORA_PER_X
            {
                get { _whora_per_x = new _REDEF_VG0120B_WHORA_PER_X(); _.Move(WHORA_OPERACAO_1, _whora_per_x); VarBasis.RedefinePassValue(WHORA_OPERACAO_1, _whora_per_x, WHORA_OPERACAO_1); _whora_per_x.ValueChanged += () => { _.Move(_whora_per_x, WHORA_OPERACAO_1); }; return _whora_per_x; }
                set { VarBasis.RedefinePassValue(value, _whora_per_x, WHORA_OPERACAO_1); }
            }  //Redefines
            public class _REDEF_VG0120B_WHORA_PER_X : VarBasis
            {
                /*"       10       WHORA-OPERACAO-2    PIC 999999.*/
                public IntBasis WHORA_OPERACAO_2 { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
                /*"       10       FILLER              PIC 99.*/
                public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"    05      FLAG-FIM-RELATORIO       PIC  9(001) VALUE 0.*/

                public _REDEF_VG0120B_WHORA_PER_X()
                {
                    WHORA_OPERACAO_2.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis FLAG_FIM_RELATORIO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-RELATORIO            VALUE 1. */
							new SelectorItemBasis("FIM_RELATORIO", "1")
                }
            };

            /*"    05      FLAG-EXISTE-REL          PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_EXISTE_REL { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-RELATORIO          VALUE 1. */
							new SelectorItemBasis("HOUVE_RELATORIO", "1")
                }
            };

            /*"    05      FLAG-EXISTE-ERROVIG      PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_EXISTE_ERROVIG { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-ERRO-VIGENCIA      VALUE 1. */
							new SelectorItemBasis("HOUVE_ERRO_VIGENCIA", "1")
                }
            };

            /*"    05      FLAG-EXISTE-SEGUR        PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_EXISTE_SEGUR { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-SEGURADO           VALUE 1. */
							new SelectorItemBasis("HOUVE_SEGURADO", "1")
                }
            };

            /*"    05      FLAG-CONJUGE             PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_CONJUGE { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    POSSUI-CONJUGE           VALUE 1. */
							new SelectorItemBasis("POSSUI_CONJUGE", "1")
                }
            };

            /*"    05      FLAG-FIM-SEGURADO        PIC  9(001) VALUE 0.*/

            public SelectorBasis FLAG_FIM_SEGURADO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-SEGURADO             VALUE 1. */
							new SelectorItemBasis("FIM_SEGURADO", "1")
                }
            };

            /*"    05      AUX-APOLICE-ERRO         PIC S9(13) COMP-3 VALUE +0.*/
            public IntBasis AUX_APOLICE_ERRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05      AUX-CONT-ERRO            PIC 9(3) VALUE 0.*/
            public IntBasis AUX_CONT_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(3)"));
            /*"    05      IND-APOL-ERRO            PIC 9(3) VALUE 0.*/
            public IntBasis IND_APOL_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(3)"));
            /*"    05      TAB-APOL-ERRO.*/
            public VG0120B_TAB_APOL_ERRO TAB_APOL_ERRO { get; set; } = new VG0120B_TAB_APOL_ERRO();
            public class VG0120B_TAB_APOL_ERRO : VarBasis
            {
                /*"      10    OC-TAB-APOL-ERRO         OCCURS 500.*/
                public ListBasis<VG0120B_OC_TAB_APOL_ERRO> OC_TAB_APOL_ERRO { get; set; } = new ListBasis<VG0120B_OC_TAB_APOL_ERRO>(500);
                public class VG0120B_OC_TAB_APOL_ERRO : VarBasis
                {
                    /*"        15  APOL-ERRO-TAB            PIC S9(13) COMP-3.*/
                    public IntBasis APOL_ERRO_TAB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                    /*"    05      DATA-AUX.*/
                }
            }
            public VG0120B_DATA_AUX DATA_AUX { get; set; } = new VG0120B_DATA_AUX();
            public class VG0120B_DATA_AUX : VarBasis
            {
                /*"      10    DIA-AUX                  PIC  X(002).*/
                public StringBasis DIA_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    MES-AUX                  PIC  X(002).*/
                public StringBasis MES_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    ANO-AUX                  PIC  X(004).*/
                public StringBasis ANO_AUX { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    05      CONTA-CORRENTE           PIC  9(016).*/
            }
            public IntBasis CONTA_CORRENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"    05      CTA-CORR                 REDEFINES CONTA-CORRENTE.*/
            private _REDEF_VG0120B_CTA_CORR _cta_corr { get; set; }
            public _REDEF_VG0120B_CTA_CORR CTA_CORR
            {
                get { _cta_corr = new _REDEF_VG0120B_CTA_CORR(); _.Move(CONTA_CORRENTE, _cta_corr); VarBasis.RedefinePassValue(CONTA_CORRENTE, _cta_corr, CONTA_CORRENTE); _cta_corr.ValueChanged += () => { _.Move(_cta_corr, CONTA_CORRENTE); }; return _cta_corr; }
                set { VarBasis.RedefinePassValue(value, _cta_corr, CONTA_CORRENTE); }
            }  //Redefines
            public class _REDEF_VG0120B_CTA_CORR : VarBasis
            {
                /*"      10    CTA-OPERACAO             PIC  9(004).*/
                public IntBasis CTA_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    CTA-NUM-CONTA            PIC  9(012).*/
                public IntBasis CTA_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    05      CERTIFICADO-ANT          PIC  9(015).*/

                public _REDEF_VG0120B_CTA_CORR()
                {
                    CTA_OPERACAO.ValueChanged += OnValueChanged;
                    CTA_NUM_CONTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis CERTIFICADO_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05      AUX-CPF                  PIC  9(011).*/
            public IntBasis AUX_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"    05      FILLER                   REDEFINES  AUX-CPF.*/
            private _REDEF_VG0120B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VG0120B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VG0120B_FILLER_8(); _.Move(AUX_CPF, _filler_8); VarBasis.RedefinePassValue(AUX_CPF, _filler_8, AUX_CPF); _filler_8.ValueChanged += () => { _.Move(_filler_8, AUX_CPF); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, AUX_CPF); }
            }  //Redefines
            public class _REDEF_VG0120B_FILLER_8 : VarBasis
            {
                /*"      10    AUX-CPF-1                PIC  9(009).*/
                public IntBasis AUX_CPF_1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10    AUX-CPF-2                PIC  9(002).*/
                public IntBasis AUX_CPF_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      AUX-VALORES.*/

                public _REDEF_VG0120B_FILLER_8()
                {
                    AUX_CPF_1.ValueChanged += OnValueChanged;
                    AUX_CPF_2.ValueChanged += OnValueChanged;
                }

            }
            public VG0120B_AUX_VALORES AUX_VALORES { get; set; } = new VG0120B_AUX_VALORES();
            public class VG0120B_AUX_VALORES : VarBasis
            {
                /*"      10    AUX-MORTE-NATURAL        PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-MORTE-ACIDENTAL      PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-PREM-MA              PIC  9(013)V99.*/
                public DoubleBasis AUX_PREM_MA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-INV-PERMANENTE       PIC  9(013)V99.*/
                public DoubleBasis AUX_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-PREM-IP              PIC  9(013)V99.*/
                public DoubleBasis AUX_PREM_IP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-AMDS                 PIC  9(013)V99.*/
                public DoubleBasis AUX_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-PREM-AMDS            PIC  9(013)V99.*/
                public DoubleBasis AUX_PREM_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-DIARIA-HOSP          PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_HOSP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-PREM-DH              PIC  9(013)V99.*/
                public DoubleBasis AUX_PREM_DH { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-DIARIA-INT           PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_INT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10    AUX-PREM-DI              PIC  9(013)V99.*/
                public DoubleBasis AUX_PREM_DI { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-TIPO-CLIENTE         PIC  X(030).*/
            }
            public StringBasis AUX_TIPO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05      AUX-TIPO-IMPORT          PIC  X(030).*/
            public StringBasis AUX_TIPO_IMPORT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05      AUX-OUTROS               PIC  X(001) VALUE SPACES.*/
            public StringBasis AUX_OUTROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05      I                        PIC  9(002) VALUE ZEROS.*/
            public IntBasis I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05      JK                       PIC  9(002) VALUE ZEROS.*/
            public IntBasis JK { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05      TABELA-DES-OPERACAO.*/
            public VG0120B_TABELA_DES_OPERACAO TABELA_DES_OPERACAO { get; set; } = new VG0120B_TABELA_DES_OPERACAO();
            public class VG0120B_TABELA_DES_OPERACAO : VarBasis
            {
                /*"      10    DESC-TAB-OPERACAO.*/
                public VG0120B_DESC_TAB_OPERACAO DESC_TAB_OPERACAO { get; set; } = new VG0120B_DESC_TAB_OPERACAO();
                public class VG0120B_DESC_TAB_OPERACAO : VarBasis
                {
                    /*"        15  FILLER  PIC X(025) VALUE '0101 INCLUSAO DE SEGURADO'*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0101 INCLUSAO DE SEGURADO");
                    /*"        15  FILLER  PIC X(025) VALUE '0102 INCL. SEG. AUTOMATIC'*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0102 INCL. SEG. AUTOMATIC");
                    /*"        15  FILLER  PIC X(025) VALUE '0111 INCL. SEG. FOLLOW UP'*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0111 INCL. SEG. FOLLOW UP");
                    /*"        15  FILLER  PIC X(025) VALUE '0112 INCL. SEG. FOL. AUT.'*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0112 INCL. SEG. FOL. AUT.");
                    /*"        15  FILLER  PIC X(025) VALUE '0201 TRANSF. DEBITO      '*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0201 TRANSF. DEBITO      ");
                    /*"        15  FILLER  PIC X(025) VALUE '0301 TRANSF. CREDITO     '*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0301 TRANSF. CREDITO     ");
                    /*"        15  FILLER  PIC X(025) VALUE '0401 CANC. SOLICITADO    '*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0401 CANC. SOLICITADO    ");
                    /*"        15  FILLER  PIC X(025) VALUE '0402 CANC. SINISTRO      '*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0402 CANC. SINISTRO      ");
                    /*"        15  FILLER  PIC X(025) VALUE '0403 CANC. FALTA PAGTO   '*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0403 CANC. FALTA PAGTO   ");
                    /*"        15  FILLER  PIC X(025) VALUE '0501 REAB. DE CANC. SOLI.'*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0501 REAB. DE CANC. SOLI.");
                    /*"        15  FILLER  PIC X(025) VALUE '0502 REAB. DE CANC. SINI.'*/
                    public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0502 REAB. DE CANC. SINI.");
                    /*"        15  FILLER  PIC X(025) VALUE '0503 REAB. DE CANC. S/PG '*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0503 REAB. DE CANC. S/PG ");
                    /*"        15  FILLER  PIC X(025) VALUE '0701 REDUCAO DE CAPITAL  '*/
                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0701 REDUCAO DE CAPITAL  ");
                    /*"        15  FILLER  PIC X(025) VALUE '0801 AUMENTO DE CAPITAL  '*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0801 AUMENTO DE CAPITAL  ");
                    /*"        15  FILLER  PIC X(025) VALUE '0802 AUMENTO DE CAP. COL.'*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0802 AUMENTO DE CAP. COL.");
                    /*"    05      TAB-AUX             REDEFINES TABELA-DES-OPERACAO.*/
                }
            }
            private _REDEF_VG0120B_TAB_AUX _tab_aux { get; set; }
            public _REDEF_VG0120B_TAB_AUX TAB_AUX
            {
                get { _tab_aux = new _REDEF_VG0120B_TAB_AUX(); _.Move(TABELA_DES_OPERACAO, _tab_aux); VarBasis.RedefinePassValue(TABELA_DES_OPERACAO, _tab_aux, TABELA_DES_OPERACAO); _tab_aux.ValueChanged += () => { _.Move(_tab_aux, TABELA_DES_OPERACAO); }; return _tab_aux; }
                set { VarBasis.RedefinePassValue(value, _tab_aux, TABELA_DES_OPERACAO); }
            }  //Redefines
            public class _REDEF_VG0120B_TAB_AUX : VarBasis
            {
                /*"      10    TAB-OPERACAO             OCCURS 15.*/
                public ListBasis<VG0120B_TAB_OPERACAO> TAB_OPERACAO { get; set; } = new ListBasis<VG0120B_TAB_OPERACAO>(15);
                public class VG0120B_TAB_OPERACAO : VarBasis
                {
                    /*"        15  TAB-COD-OPER             PIC  9(004).*/
                    public IntBasis TAB_COD_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15  FILLER                   PIC  X(001).*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"        15  TAB-DES-OPER             PIC  X(020).*/
                    public StringBasis TAB_DES_OPER { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                    /*"    05      AC-SOLICITADO            PIC  9(009) COMP-3 VALUE 0.*/

                    public VG0120B_TAB_OPERACAO()
                    {
                        TAB_COD_OPER.ValueChanged += OnValueChanged;
                        FILLER_24.ValueChanged += OnValueChanged;
                        TAB_DES_OPER.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VG0120B_TAB_AUX()
                {
                    TAB_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_SOLICITADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-EMITIDOS              PIC  9(009) COMP-3 VALUE 0.*/
            public IntBasis AC_EMITIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-LINHAS                PIC  9(002) VALUE 99.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 99);
            /*"    05      AC-PAGINAS               PIC  9(004) VALUE ZEROS.*/
            public IntBasis AC_PAGINAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05      AC-CAPITAIS.*/
            public VG0120B_AC_CAPITAIS AC_CAPITAIS { get; set; } = new VG0120B_AC_CAPITAIS();
            public class VG0120B_AC_CAPITAIS : VarBasis
            {
                /*"      10    AC-VIDAS                 PIC  S9(010)     VALUE +0.*/
                public IntBasis AC_VIDAS { get; set; } = new IntBasis(new PIC("S9", "10", "S9(010)"));
                /*"      10    AC-TIT                   PIC  S9(010)     VALUE +0.*/
                public IntBasis AC_TIT { get; set; } = new IntBasis(new PIC("S9", "10", "S9(010)"));
                /*"      10    AC-CUSTOCAP              PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_CUSTOCAP { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"      10    AC-MORTE-NATURAL         PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"      10    AC-MORTE-ACIDENTAL       PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"      10    AC-INV-PERMANENTE        PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"      10    AC-ASS-MEDICA            PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"      10    AC-DIARIA-HOSPITALAR     PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"      10    AC-DIARIA-INTERNACAO     PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"      10    AC-PREM-MORTE-NATURAL    PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"      10    AC-PREM-ACID-PESSOAIS    PIC  S9(015)V99  VALUE +0.*/
                public DoubleBasis AC_PREM_ACID_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
                /*"    05      WABEND.*/
            }
            public VG0120B_WABEND WABEND { get; set; } = new VG0120B_WABEND();
            public class VG0120B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VG0120B  '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG0120B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO EXEC SQL  ****'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO EXEC SQL  ****");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VG0120B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG0120B_LOCALIZA_ABEND_1();
            public class VG0120B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VG0120B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG0120B_LOCALIZA_ABEND_2();
            public class VG0120B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05      TRACO.*/
            }
            public VG0120B_TRACO TRACO { get; set; } = new VG0120B_TRACO();
            public class VG0120B_TRACO : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(130) VALUE ALL '-'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    05      BRANCO.*/
            }
            public VG0120B_BRANCO BRANCO { get; set; } = new VG0120B_BRANCO();
            public class VG0120B_BRANCO : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(130) VALUE ALL ' '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    05      CAB-1.*/
            }
            public VG0120B_CAB_1 CAB_1 { get; set; } = new VG0120B_CAB_1();
            public class VG0120B_CAB_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(007) VALUE 'VG0120B'*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VG0120B");
                /*"      10    FILLER                   PIC  X(035) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"      10    CAB1-EMPRESA             PIC  X(040) VALUE SPACES.*/
                public StringBasis CAB1_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10    FILLER                   PIC  X(033) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"      10    FILLER                   PIC  X(011) VALUE            'PAGINA'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"      10    CAB1-PAGINA              PIC  ZZZ9.*/
                public IntBasis CAB1_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    05      CAB-2.*/
            }
            public VG0120B_CAB_2 CAB_2 { get; set; } = new VG0120B_CAB_2();
            public class VG0120B_CAB_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(115) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "115", "X(115)"), @"");
                /*"      10    FILLER                   PIC  X(005) VALUE 'DATA '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA ");
                /*"      10    CAB2-DATA                PIC  99/99/9999.*/
                public IntBasis CAB2_DATA { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    05      CAB-3.*/
            }
            public VG0120B_CAB_3 CAB_3 { get; set; } = new VG0120B_CAB_3();
            public class VG0120B_CAB_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"      10    FILLER                   PIC  X(048) VALUE            'SISTEMA DE VIDA EM GRUPO E/OU ACIDENTES PESSOAIS'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"SISTEMA DE VIDA EM GRUPO E/OU ACIDENTES PESSOAIS");
                /*"      10    FILLER                   PIC  X(009) VALUE            ' COLETIVO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" COLETIVO");
                /*"      10    FILLER                   PIC  X(028) VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
                /*"      10    FILLER                   PIC  X(007) VALUE 'HORA '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA ");
                /*"      10    CAB3-HORA                PIC  99.99.99.*/
                public IntBasis CAB3_HORA { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    05      CAB-4.*/
            }
            public VG0120B_CAB_4 CAB_4 { get; set; } = new VG0120B_CAB_4();
            public class VG0120B_CAB_4 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    CAB4-TITULO              PIC  X(035) VALUE ' '.*/
                public StringBasis CAB4_TITULO { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" ");
                /*"      10    FILLER                   PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10    FILLER                   PIC  X(016) VALUE            'SEGURADOS ATIVOS'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SEGURADOS ATIVOS");
                /*"      10    FILLER                   PIC  X(060) VALUE ' '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @" ");
                /*"    05      CAB-VIGENCIA.*/
            }
            public VG0120B_CAB_VIGENCIA CAB_VIGENCIA { get; set; } = new VG0120B_CAB_VIGENCIA();
            public class VG0120B_CAB_VIGENCIA : VarBasis
            {
                /*"      10    FILLER                   PIC  X(097) VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "97", "X(097)"), @"");
                /*"      10    FILLER                   PIC  X(010) VALUE                                                 'VIGENCIA: '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VIGENCIA: ");
                /*"      10    DIA-INI-VIGENCIA         PIC  9(002).*/
                public IntBasis DIA_INI_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    MES-INI-VIGENCIA         PIC  9(002).*/
                public IntBasis MES_INI_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    ANO-INI-VIGENCIA         PIC  9(004).*/
                public IntBasis ANO_INI_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(003) VALUE ' A '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"      10    DIA-TER-VIGENCIA         PIC  9(002).*/
                public IntBasis DIA_TER_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    MES-TER-VIGENCIA         PIC  9(002).*/
                public IntBasis MES_TER_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    ANO-TER-VIGENCIA         PIC  9(004).*/
                public IntBasis ANO_TER_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05      CAB-5.*/
            }
            public VG0120B_CAB_5 CAB_5 { get; set; } = new VG0120B_CAB_5();
            public class VG0120B_CAB_5 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(010) VALUE            'APOLICE = '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"APOLICE = ");
                /*"      10    CAB5-APOLICE             PIC  ZZZZZZZZZZZZZ.*/
                public StringBasis CAB5_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
                /*"      10    FILLER                   PIC  X(005) VALUE '  -  '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  -  ");
                /*"      10    CAB5-ESTIP               PIC  X(038) VALUE ' '.*/
                public StringBasis CAB5_ESTIP { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @" ");
                /*"      10    FILLER                   PIC  X(003) VALUE ' '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
                /*"      10    FILLER                   PIC  X(006) VALUE 'CNPJ: '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"CNPJ: ");
                /*"      10    CAB5-CNPJ-ESTIP          PIC  999.999.999.9999.99.*/
                public IntBasis CAB5_CNPJ_ESTIP { get; set; } = new IntBasis(new PIC("9", "15", "999.999.999.9999.99."));
                /*"    05      CAB5-SUBESTIP.*/
            }
            public VG0120B_CAB5_SUBESTIP CAB5_SUBESTIP { get; set; } = new VG0120B_CAB5_SUBESTIP();
            public class VG0120B_CAB5_SUBESTIP : VarBasis
            {
                /*"      10    FILLER                   PIC  X(020) VALUE            ' SUB-ESTIPULANTE = '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @" SUB-ESTIPULANTE = ");
                /*"      10    CAB5-SUBG                PIC  ZZZZZ.*/
                public StringBasis CAB5_SUBG { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
                /*"      10    FILLER                   PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10    CAB5-SUB-ESTIP           PIC  X(038) VALUE ' '.*/
                public StringBasis CAB5_SUB_ESTIP { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @" ");
                /*"      10    FILLER                   PIC  X(004) VALUE ' '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ");
                /*"      10    FILLER                   PIC  X(006) VALUE 'CNPJ: '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"CNPJ: ");
                /*"      10    CAB5-CNPJ-SUBEST         PIC  999.999.999.9999.99.*/
                public IntBasis CAB5_CNPJ_SUBEST { get; set; } = new IntBasis(new PIC("9", "15", "999.999.999.9999.99."));
                /*"    05      CAB-6.*/
            }
            public VG0120B_CAB_6 CAB_6 { get; set; } = new VG0120B_CAB_6();
            public class VG0120B_CAB_6 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE           'NOME DO SEGURADO              '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"NOME DO SEGURADO              ");
                /*"      10    FILLER                   PIC  X(032) VALUE           '  SUBG        MORTE NAT      MOR'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"  SUBG        MORTE NAT      MOR");
                /*"      10    FILLER                   PIC  X(045) VALUE           'TE ACID      INV. PERM.        A.M.D.S       '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"TE ACID      INV. PERM.        A.M.D.S       ");
                /*"      10    FILLER                   PIC  X(023) VALUE           '     D.H          D.I.T'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"     D.H          D.I.T");
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    05      CAB-7.*/
            }
            public VG0120B_CAB_7 CAB_7 { get; set; } = new VG0120B_CAB_7();
            public class VG0120B_CAB_7 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(041) VALUE           '                                         '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"                                         ");
                /*"      10    FILLER                   PIC  X(048) VALUE           'CPF        MATRICULA  SEXO  EST.CIVIL  DATA NASC'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"CPF        MATRICULA  SEXO  EST.CIVIL  DATA NASC");
                /*"      10    FILLER                   PIC  X(042) VALUE           '  DATA INIC      PREMIO VG      PREMIO AP '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"  DATA INIC      PREMIO VG      PREMIO AP ");
                /*"    05      CAB-8.*/
            }
            public VG0120B_CAB_8 CAB_8 { get; set; } = new VG0120B_CAB_8();
            public class VG0120B_CAB_8 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE       ' QTD TIT      CUSTO CAP. TOTAL'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" QTD TIT      CUSTO CAP. TOTAL");
                /*"      10    FILLER                   PIC  X(052) VALUE       '     CERTIFICADO   DT.ULT.MOV   ULT. MOVIMENTACAO   '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"     CERTIFICADO   DT.ULT.MOV   ULT. MOVIMENTACAO   ");
                /*"      10    FILLER                   PIC  X(050) VALUE       '          AGENCIA   OPERACAO   CTA. CORRENTE  DV'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"          AGENCIA   OPERACAO   CTA. CORRENTE  DV");
                /*"    05      DET-1.*/
            }
            public VG0120B_DET_1 DET_1 { get; set; } = new VG0120B_DET_1();
            public class VG0120B_DET_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET1-NOME                PIC  X(030) VALUE ' '.*/
                public StringBasis DET1_NOME { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
                /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
                /*"      10    DET1-SUBG                PIC  9999.*/
                public IntBasis DET1_SUBG { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
                /*"      10    DET1-CAP-VG              PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET1_CAP_VG { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET1-CAP-MA              PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET1_CAP_MA { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET1-CAP-IP              PIC  ZZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET1_CAP_IP { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET1-CAP-AMDS            PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET1_CAP_AMDS { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET1-CAP-DH              PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET1_CAP_DH { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET1-CAP-DIT             PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET1_CAP_DIT { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05      DET-2.*/
            }
            public VG0120B_DET_2 DET_2 { get; set; } = new VG0120B_DET_2();
            public class VG0120B_DET_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
                /*"      10    DET2-CPF                 PIC  999.999.999.*/
                public IntBasis DET2_CPF { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DET2-CPF-CONT            PIC  99.*/
                public IntBasis DET2_CPF_CONT { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
                /*"      10    DET2-MATR                PIC  ZZZZZZZZZZZZ999.*/
                public IntBasis DET2_MATR { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZ999."));
                /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
                /*"      10    DET2-SEXO                PIC  X(004) VALUE ' '.*/
                public StringBasis DET2_SEXO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ");
                /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
                /*"      10    DET2-EST-CVL             PIC  X(010) VALUE ' '.*/
                public StringBasis DET2_EST_CVL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
                /*"      10    FI1LER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FI1LER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET2-NASC                PIC  99/99/9999.*/
                public IntBasis DET2_NASC { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET2-INIVIG              PIC  99/99/9999.*/
                public IntBasis DET2_INIVIG { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    DET2-PREM-VG             PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET2_PREM_VG { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
                /*"      10    DET2-PREM-AP             PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET2_PREM_AP { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    05      DET-3.*/
            }
            public VG0120B_DET_3 DET_3 { get; set; } = new VG0120B_DET_3();
            public class VG0120B_DET_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(003) VALUE ' '.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
                /*"      10    DET3-QTTITCAP            PIC  99.*/
                public IntBasis DET3_QTTITCAP { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"      10    FILLER                   PIC  X(005) VALUE ' '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ");
                /*"      10    DET3-VLCUSTCAP           PIC  ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis DET3_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10    FILLER                   PIC  X(003) VALUE ' '.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
                /*"      10    DET3-CERT                PIC  ZZZZZZZZZZZZ999.*/
                public IntBasis DET3_CERT { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZ999."));
                /*"      10    FILLER                   PIC  X(003) VALUE ' '.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
                /*"      10    DET3-ULTI-ALT            PIC  99/99/9999.*/
                public IntBasis DET3_ULTI_ALT { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
                /*"      10    FILLER                   PIC  X(003) VALUE ' '.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
                /*"      10    DET3-DESC-ULT-ALT        PIC  X(025) VALUE ' '.*/
                public StringBasis DET3_DESC_ULT_ALT { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @" ");
                /*"      10    FILLER                   PIC  X(008) VALUE ' '.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" ");
                /*"      10    DET3-CONTA-CORRENTE.*/
                public VG0120B_DET3_CONTA_CORRENTE DET3_CONTA_CORRENTE { get; set; } = new VG0120B_DET3_CONTA_CORRENTE();
                public class VG0120B_DET3_CONTA_CORRENTE : VarBasis
                {
                    /*"        15  DET3-AGENCIA             PIC  ZZZ9.*/
                    public IntBasis DET3_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                    /*"        15  FILLER                   PIC  X(006) VALUE ' '.*/
                    public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ");
                    /*"        15  DET3-OPERACAO            PIC  Z999.*/
                    public IntBasis DET3_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                    /*"        15  FILLER                   PIC  X(002) VALUE ' '.*/
                    public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
                    /*"        15  DET3-CTA-CORR            PIC  ZZZ.ZZZ.ZZZ.ZZ9.*/
                    public IntBasis DET3_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9."));
                    /*"        15  DET3-TRACO               PIC  X(003).*/
                    public StringBasis DET3_TRACO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"        15  DET3-DAC-CONTA           PIC  X(001).*/
                    public StringBasis DET3_DAC_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                }
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    05      TOT-CAB-1.*/
            }
            public VG0120B_TOT_CAB_1 TOT_CAB_1 { get; set; } = new VG0120B_TOT_CAB_1();
            public class VG0120B_TOT_CAB_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
                /*"      10    FILLER                   PIC  X(050) VALUE           '                       MORTE NATU.            INV.'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"                       MORTE NATU.            INV.");
                /*"      10    FILLER                   PIC  X(050) VALUE           ' PERM.                    DH            PREMIO  VG'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" PERM.                    DH            PREMIO  VG");
                /*"    05      TOT-CAB-2.*/
            }
            public VG0120B_TOT_CAB_2 TOT_CAB_2 { get; set; } = new VG0120B_TOT_CAB_2();
            public class VG0120B_TOT_CAB_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
                /*"      10    FILLER                   PIC  X(050) VALUE           'NUM. VIDAS             MORTE ACID.                '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NUM. VIDAS             MORTE ACID.                ");
                /*"      10    FILLER                   PIC  X(050) VALUE           '  AMDS                   DIT            PREMIO APC'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"  AMDS                   DIT            PREMIO APC");
                /*"    05      TOT-CAB-3.*/
            }
            public VG0120B_TOT_CAB_3 TOT_CAB_3 { get; set; } = new VG0120B_TOT_CAB_3();
            public class VG0120B_TOT_CAB_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
                /*"      10    FILLER                   PIC  X(100) VALUE ALL '-'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"ALL");
                /*"    05      TOT-CAB-4.*/
            }
            public VG0120B_TOT_CAB_4 TOT_CAB_4 { get; set; } = new VG0120B_TOT_CAB_4();
            public class VG0120B_TOT_CAB_4 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
                /*"      10    FILLER                   PIC  X(050) VALUE           'TOT. TITULOS        TOT. CAPITALIZACAO            '.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"TOT. TITULOS        TOT. CAPITALIZACAO            ");
                /*"      10    FILLER                   PIC  X(050) VALUE           '                                                  '.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"                                                  ");
                /*"    05      TOT-DET-1.*/
            }
            public VG0120B_TOT_DET_1 TOT_DET_1 { get; set; } = new VG0120B_TOT_DET_1();
            public class VG0120B_TOT_DET_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(041) VALUE ' '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @" ");
                /*"      10    TOT1-CAP-VG              PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_CAP_VG { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"      10    TOT1-CAP-IP              PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_CAP_IP { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"      10    TOT1-CAP-DH              PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_CAP_DH { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"      10    TOT1-PREM-VG             PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_PREM_VG { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"    05      TOT-DET-2.*/
            }
            public VG0120B_TOT_DET_2 TOT_DET_2 { get; set; } = new VG0120B_TOT_DET_2();
            public class VG0120B_TOT_DET_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE            '                              '.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                              ");
                /*"      10    TOT1-VIDAS               PIC  ZZZZZZZZZZ.*/
                public StringBasis TOT1_VIDAS { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZ."), @"");
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    TOT1-CAP-MA              PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_CAP_MA { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"      10    TOT1-CAP-AMDS            PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_CAP_AMDS { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"      10    TOT1-CAP-DIT             PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_CAP_DIT { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"      10    TOT1-PREM-APC            PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_PREM_APC { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"    05      TOT-DET-3.*/
            }
            public VG0120B_TOT_DET_3 TOT_DET_3 { get; set; } = new VG0120B_TOT_DET_3();
            public class VG0120B_TOT_DET_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(030) VALUE            '       TOTAIS DA APOLICE....  '.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"       TOTAIS DA APOLICE....  ");
                /*"      10    TOT1-TIT                 PIC  ZZZZZZZZZ9.*/
                public IntBasis TOT1_TIT { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZZZZ9."));
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    TOT1-CUSTOCAP            PIC ---.---.---.---.--9,99.*/
                public DoubleBasis TOT1_CUSTOCAP { get; set; } = new DoubleBasis(new PIC("9", "15", "---.---.---.---.--9V99."), 2);
                /*"      10    FILLER                   PIC  X(086) VALUE ' '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @" ");
                /*"    05      MEN-1.*/
            }
            public VG0120B_MEN_1 MEN_1 { get; set; } = new VG0120B_MEN_1();
            public class VG0120B_MEN_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(051) VALUE         'NAO HOUVE SOLICITACAO PARA ESTE RELATORIO          '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NAO HOUVE SOLICITACAO PARA ESTE RELATORIO          ");
                /*"      10    FILLER                   PIC  X(080) VALUE ' '.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @" ");
                /*"    05      MEN-2.*/
            }
            public VG0120B_MEN_2 MEN_2 { get; set; } = new VG0120B_MEN_2();
            public class VG0120B_MEN_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(051) VALUE         'NAO HOUVE SELECAO DE SEGURADOS CONFORME SOLICITACAO'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NAO HOUVE SELECAO DE SEGURADOS CONFORME SOLICITACAO");
                /*"      10    FILLER                   PIC  X(080) VALUE ' '.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @" ");
                /*"    05      MENSAGEM.*/
            }
            public VG0120B_MENSAGEM MENSAGEM { get; set; } = new VG0120B_MENSAGEM();
            public class VG0120B_MENSAGEM : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10    FILLER                   PIC  X(131) VALUE ' '.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "131", "X(131)"), @" ");
                /*"    05        LK-LINK.*/
            }
            public VG0120B_LK_LINK LK_LINK { get; set; } = new VG0120B_LK_LINK();
            public class VG0120B_LK_LINK : VarBasis
            {
                /*"      10      LK-RETURN-CODE           PIC S9(004) COMP VALUE +0*/
                public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10      LK-TAMANHO              PIC S9(004) COMP VALUE +40*/
                public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                /*"      10      LK-TITULO                PIC  X(132) VALUE SPACES.*/
                public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    05        PARAMETROS.*/
            }
            public VG0120B_PARAMETROS PARAMETROS { get; set; } = new VG0120B_PARAMETROS();
            public class VG0120B_PARAMETROS : VarBasis
            {
                /*"      10      LK-APOLICE               PIC S9(013) COMP-3.*/
                public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"      10      LK-SUBGRUPO              PIC S9(004) COMP.*/
                public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10      LK-IDADE                 PIC S9(004) COMP.*/
                public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10      LK-NASCIMENTO.*/
                public VG0120B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG0120B_LK_NASCIMENTO();
                public class VG0120B_LK_NASCIMENTO : VarBasis
                {
                    /*"        15 LK-DATA-NASCIMENTO          PIC  9(008).*/
                    public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      10      LK-SALARIO               PIC S9(013)V99 COMP-3.*/
                }
                public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    10      LK-COBT-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-COBT-MORTE-ACIDENTAL  PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-COBT-INV-PERMANENTE   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-COBT-INV-POR-DOENCA   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_DOENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-COBT-ASS-MEDICA       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-COBT-DIARIA-HOSPITALAR PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-COBT-DIARIA-INTERNACAO PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PURO-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PURO-MORTE-ACIDENTAL  PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PURO-INV-PERMANENTE   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PURO-ASS-MEDICA       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PURO-DIARIA-HOSPITALAR PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PURO-DIARIA-INTERNACAO PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-RETURN-CODE           PIC S9(03) COMP-3.*/
            public IntBasis LK_RETURN_CODE_0 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    10      LK-MENSAGEM              PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01  WS-CHAVE-ATU.*/
        }
        public VG0120B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VG0120B_WS_CHAVE_ATU();
        public class VG0120B_WS_CHAVE_ATU : VarBasis
        {
            /*"    10      WS-APOLICE-ATU           PIC 9(13).*/
            public IntBasis WS_APOLICE_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    10      WS-SUBGRUPO-ATU          PIC 9(05).*/
            public IntBasis WS_SUBGRUPO_ATU { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"01  WS-CHAVE-ANT.*/
        }
        public VG0120B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VG0120B_WS_CHAVE_ANT();
        public class VG0120B_WS_CHAVE_ANT : VarBasis
        {
            /*"    10      WS-APOLICE-ANT           PIC 9(13).*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    10      WS-SUBGRUPO-ANT          PIC 9(05).*/
            public IntBasis WS_SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"01  WS-TIME.*/
        }
        public VG0120B_WS_TIME WS_TIME { get; set; } = new VG0120B_WS_TIME();
        public class VG0120B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  AC-LIDOS                         PIC 9(07) VALUE 0.*/
        }
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"01  ON-INTERVAL                      PIC 9(05) VALUE 10000.*/
        public IntBasis ON_INTERVAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"), 10000);
        /*"01  ON-COUNTER                       PIC 9(05) VALUE 0.*/
        public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
        /*"01        WS-DATA1.*/
        public VG0120B_WS_DATA1 WS_DATA1 { get; set; } = new VG0120B_WS_DATA1();
        public class VG0120B_WS_DATA1 : VarBasis
        {
            /*"  05      WS-ANO1                    PIC  9(004).*/
            public IntBasis WS_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER                     PIC  X(001).*/
            public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      WS-MES1                    PIC  9(002).*/
            public IntBasis WS_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER                     PIC  X(001).*/
            public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      WS-DIA1                    PIC  9(002).*/
            public IntBasis WS_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01        WS-DATA2.*/
        }
        public VG0120B_WS_DATA2 WS_DATA2 { get; set; } = new VG0120B_WS_DATA2();
        public class VG0120B_WS_DATA2 : VarBasis
        {
            /*"  05      WS-ANO2                    PIC  9(004).*/
            public IntBasis WS_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER                     PIC  X(001).*/
            public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      WS-MES2                    PIC  9(002).*/
            public IntBasis WS_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER                     PIC  X(001).*/
            public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      WS-DIA2                    PIC  9(002).*/
            public IntBasis WS_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01        WS-DTINIVIG-PARC           PIC  X(010) VALUE SPACES.*/
        }
        public StringBasis WS_DTINIVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01        WS-PERIPGTO                PIC S9(004) COMP.*/
        public IntBasis WS_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01        WHOST-DATA1                PIC  X(010) VALUE SPACES.*/
        public StringBasis WHOST_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01        WHOST-DATA2                PIC  X(010) VALUE SPACES.*/
        public StringBasis WHOST_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01        WS-NUM-CERT-PROPVA         PIC S9(015)    COMP-3.*/
        public IntBasis WS_NUM_CERT_PROPVA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01        WS-COD-SUBG-ZERO           PIC S9(004)    COMP.*/
        public IntBasis WS_COD_SUBG_ZERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));


        public Dclgens.VG083 VG083 { get; set; } = new Dclgens.VG083();
        public VG0120B_RELATORIO RELATORIO { get; set; } = new VG0120B_RELATORIO();
        public VG0120B_SEGURADO1 SEGURADO1 { get; set; } = new VG0120B_SEGURADO1();
        public VG0120B_SEGURADO2 SEGURADO2 { get; set; } = new VG0120B_SEGURADO2();
        public VG0120B_SEGURADO3 SEGURADO3 { get; set; } = new VG0120B_SEGURADO3();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVG0120B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVG0120B.SetFile(RVG0120B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-000-PRINCIPAL */

                M_0000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-000-PRINCIPAL */
        private void M_0000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -801- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -804- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -807- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -810- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -811- DISPLAY 'PROGRAMA EM EXECUCAO VG0120B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO VG0120B   ");

            /*" -812- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -813- DISPLAY 'VERSAO V.12 NSGD    13/10/2014 ' . */
            _.Display($"VERSAO V.12 NSGD    13/10/2014 ");

            /*" -815- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -816- MOVE '0000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-000-PRINCIPAL", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -818- MOVE 'SELECT... FROM SEGUROS.V1SISTEMA' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SISTEMA", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -823- PERFORM M_0000_000_PRINCIPAL_DB_SELECT_1 */

            M_0000_000_PRINCIPAL_DB_SELECT_1();

            /*" -826- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -828- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -830- MOVE SISTEMA-DTMOVABE TO DATA-SQL. */
            _.Move(SISTEMA_DTMOVABE, WORK.DATA_SQL);

            /*" -832- MOVE SISTEMA-DTCURRENT TO DATA-MAQ. */
            _.Move(SISTEMA_DTCURRENT, WORK.DATA_SQL.DATA_MAQ);

            /*" -835- MOVE ZEROS TO WS-CHAVE-ATU WS-CHAVE-ANT */
            _.Move(0, WS_CHAVE_ATU, WS_CHAVE_ANT);

            /*" -836- MOVE CORR DATA-MAQ TO DATA-DDMMAA. */
            _.MoveCorr(WORK.DATA_SQL.DATA_MAQ, WORK.DATA_DDMMAA);

            /*" -837- MOVE DATA-NORMAL TO CAB2-DATA. */
            _.Move(WORK.DATA_NORMAL, WORK.CAB_2.CAB2_DATA);

            /*" -838- ACCEPT WHORA-OPERACAO-1 FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WORK.WHORA_OPERACAO_1);

            /*" -840- MOVE WHORA-OPERACAO-2 TO CAB3-HORA. */
            _.Move(WORK.WHORA_PER_X.WHORA_OPERACAO_2, WORK.CAB_3.CAB3_HORA);

            /*" -842- MOVE 'SELECT... FROM SEGUROS.V1EMPRESA' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1EMPRESA", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -846- PERFORM M_0000_000_PRINCIPAL_DB_SELECT_2 */

            M_0000_000_PRINCIPAL_DB_SELECT_2();

            /*" -849- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -851- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -853- MOVE NOME-EMPRESA TO LK-TITULO. */
            _.Move(NOME_EMPRESA, WORK.LK_LINK.LK_TITULO);

            /*" -854- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", WORK.LK_LINK);

            /*" -855- IF LK-RETURN-CODE OF LK-LINK EQUAL ZEROS */

            if (WORK.LK_LINK.LK_RETURN_CODE == 00)
            {

                /*" -856- MOVE LK-TITULO TO CAB1-EMPRESA */
                _.Move(WORK.LK_LINK.LK_TITULO, WORK.CAB_1.CAB1_EMPRESA);

                /*" -857- ELSE */
            }
            else
            {


                /*" -858- DISPLAY 'PROBLEMA NO CALL AS0010S - ALINHA/ TITULO' */
                _.Display($"PROBLEMA NO CALL AS0010S - ALINHA/ TITULO");

                /*" -860- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -862- MOVE 'SELECT... FROM SEGUROS.V1PARAMRAMO' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1PARAMRAMO", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -871- PERFORM M_0000_000_PRINCIPAL_DB_SELECT_3 */

            M_0000_000_PRINCIPAL_DB_SELECT_3();

            /*" -874- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -875- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -876- DISPLAY '    VG0120B - ERRO NO ACESSO A V1PARAMRAMO' */
                _.Display($"    VG0120B - ERRO NO ACESSO A V1PARAMRAMO");

                /*" -877- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -879- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -879- PERFORM 0010-000-INICI-PROCESSO. */

            M_0010_000_INICI_PROCESSO_SECTION();

        }

        [StopWatch]
        /*" M-0000-000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -823- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SISTEMA-DTMOVABE, :SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_0000_000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_DTCURRENT, SISTEMA_DTCURRENT);
            }


        }

        [StopWatch]
        /*" M-0010-000-INICI-PROCESSO-SECTION */
        private void M_0010_000_INICI_PROCESSO_SECTION()
        {
            /*" -884- MOVE ZEROS TO AC-CAPITAIS. */
            _.Move(0, WORK.AC_CAPITAIS);

            /*" -895- MOVE ZEROS TO AC-VIDAS AC-TIT AC-CUSTOCAP AC-MORTE-NATURAL AC-MORTE-ACIDENTAL AC-INV-PERMANENTE AC-ASS-MEDICA AC-DIARIA-HOSPITALAR AC-DIARIA-INTERNACAO AC-PREM-MORTE-NATURAL AC-PREM-ACID-PESSOAIS. */
            _.Move(0, WORK.AC_CAPITAIS.AC_VIDAS, WORK.AC_CAPITAIS.AC_TIT, WORK.AC_CAPITAIS.AC_CUSTOCAP, WORK.AC_CAPITAIS.AC_MORTE_NATURAL, WORK.AC_CAPITAIS.AC_MORTE_ACIDENTAL, WORK.AC_CAPITAIS.AC_INV_PERMANENTE, WORK.AC_CAPITAIS.AC_ASS_MEDICA, WORK.AC_CAPITAIS.AC_DIARIA_HOSPITALAR, WORK.AC_CAPITAIS.AC_DIARIA_INTERNACAO, WORK.AC_CAPITAIS.AC_PREM_MORTE_NATURAL, WORK.AC_CAPITAIS.AC_PREM_ACID_PESSOAIS);

            /*" -896- PERFORM 0100-000-DECLARA-RELATORIO. */

            M_0100_000_DECLARA_RELATORIO_SECTION();

            /*" -898- PERFORM 0110-020-FETCH-RELATORIO. */

            M_0110_020_FETCH_RELATORIO_SECTION();

            /*" -899- IF HOUVE-RELATORIO */

            if (WORK.FLAG_EXISTE_REL["HOUVE_RELATORIO"])
            {

                /*" -900- OPEN OUTPUT RVG0120B */
                RVG0120B.Open(REG_IMPRESSAO);

                /*" -902- PERFORM 0020-000-PROCESSA UNTIL FIM-RELATORIO */

                while (!(WORK.FLAG_FIM_RELATORIO["FIM_RELATORIO"]))
                {

                    M_0020_000_PROCESSA_SECTION();
                }

                /*" -903- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -904- DISPLAY ' PROGRAMA VG0120B ' */
                _.Display($" PROGRAMA VG0120B ");

                /*" -905- DISPLAY ' TOTAL DE SOLICITACAO          = ' AC-SOLICITADO */
                _.Display($" TOTAL DE SOLICITACAO          = {WORK.AC_SOLICITADO}");

                /*" -906- DISPLAY ' TOTAL DE SEGURADOS PROCESADOS = ' AC-EMITIDOS */
                _.Display($" TOTAL DE SEGURADOS PROCESADOS = {WORK.AC_EMITIDOS}");

                /*" -907- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -909- DISPLAY ' ' */
                _.Display($" ");

                /*" -910- CLOSE RVG0120B */
                RVG0120B.Close();

                /*" -911- ELSE */
            }
            else
            {


                /*" -913- DISPLAY '------------------------------------------------- '--------------------------' */
                _.Display($"------------------------------------------------- --------------------------");

                /*" -915- DISPLAY ' VG0120B - NAO HOUVE SELECAO DE SOLICITACAO NEST 'A DATA - ' SISTEMA-DTMOVABE */

                $" VG0120B - NAO HOUVE SELECAO DE SOLICITACAO NEST ADATA-{SISTEMA_DTMOVABE}"
                .Display();

                /*" -917- DISPLAY '------------------------------------------------- '--------------------------' */
                _.Display($"------------------------------------------------- --------------------------");

                /*" -919- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -921- PERFORM 9000-000-CLOSE-CURSOR. */

            M_9000_000_CLOSE_CURSOR_SECTION();

            /*" -921- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -925- DISPLAY 'FIM NORMAL      **** VG0120B ****' . */
            _.Display($"FIM NORMAL      **** VG0120B ****");

            /*" -927- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -929- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -846- EXEC SQL SELECT NOME_EMPRESA INTO :NOME-EMPRESA FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_0000_000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NOME_EMPRESA, NOME_EMPRESA);
            }


        }

        [StopWatch]
        /*" M-0020-000-PROCESSA-SECTION */
        private void M_0020_000_PROCESSA_SECTION()
        {
            /*" -935- PERFORM 0400-020-MONTA-ESTIPULANTE. */

            M_0400_020_MONTA_ESTIPULANTE_SECTION();

            /*" -936- PERFORM 0120-020-DECLARA-SEGURADOS. */

            M_0120_020_DECLARA_SEGURADOS_SECTION();

            /*" -937- PERFORM 0130-040-FETCH-SEGURADO. */

            M_0130_040_FETCH_SEGURADO_SECTION();

            /*" -938- DISPLAY '*** VG0120B *** PROCESSANDO ...' . */
            _.Display($"*** VG0120B *** PROCESSANDO ...");

            /*" -940- MOVE 0 TO AC-LIDOS ON-COUNTER. */
            _.Move(0, AC_LIDOS, ON_COUNTER);

            /*" -941- PERFORM 0040-020-PROCESSA-RELATO UNTIL FIM-SEGURADO. */

            while (!(WORK.FLAG_FIM_SEGURADO["FIM_SEGURADO"]))
            {

                M_0040_020_PROCESSA_RELATO_SECTION();
            }

            /*" -943- IF HOUVE-SEGURADO NEXT SENTENCE */

            if (WORK.FLAG_EXISTE_SEGUR["HOUVE_SEGURADO"])
            {

                /*" -944- ELSE */
            }
            else
            {


                /*" -946- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -948- DISPLAY ' VG0120B - NAO HOUVE SELECAO DE SEGURADOS CONFORM 'E SOLICITACAO ' */

                $" VG0120B - NAO HOUVE SELECAO DE SEGURADOS CONFORM ESOLICITACAO"
                .Display();

                /*" -949- DISPLAY '           APOLICE  = ' RELAT-NUM-APOLICE */
                _.Display($"           APOLICE  = {RELAT_NUM_APOLICE}");

                /*" -950- DISPLAY '         SUB GRUPO  = ' RELAT-COD-SUBES */
                _.Display($"         SUB GRUPO  = {RELAT_COD_SUBES}");

                /*" -952- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -954- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -955- PERFORM 9000-020-CLOSE-CURSOR-SEGURADO */

            M_9000_020_CLOSE_CURSOR_SEGURADO_SECTION();

            /*" -956- PERFORM 0520-020-IMPRIME-TOTAIS */

            M_0520_020_IMPRIME_TOTAIS_SECTION();

            /*" -957- MOVE ZEROS TO FLAG-EXISTE-SEGUR */
            _.Move(0, WORK.FLAG_EXISTE_SEGUR);

            /*" -958- MOVE ZEROS TO FLAG-FIM-SEGURADO */
            _.Move(0, WORK.FLAG_FIM_SEGURADO);

            /*" -959- MOVE ZEROS TO AC-PAGINAS */
            _.Move(0, WORK.AC_PAGINAS);

            /*" -960- PERFORM 0700-000-UPDATE */

            M_0700_000_UPDATE_SECTION();

            /*" -962- MOVE ZEROS TO AUX-CONT-ERRO FLAG-EXISTE-ERROVIG */
            _.Move(0, WORK.AUX_CONT_ERRO, WORK.FLAG_EXISTE_ERROVIG);

            /*" -962- PERFORM 0110-020-FETCH-RELATORIO. */

            M_0110_020_FETCH_RELATORIO_SECTION();

        }

        [StopWatch]
        /*" M-0000-000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -871- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG , RAMO_AP , NUM_RAMO_PRSTMISTA INTO :PARAM-RAMO-VGAP, :PARAM-RAMO-VG , :PARAM-RAMO-AP , :PARAM-RAMO-PRSTMISTA FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var m_0000_000_PRINCIPAL_DB_SELECT_3_Query1 = new M_0000_000_PRINCIPAL_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = M_0000_000_PRINCIPAL_DB_SELECT_3_Query1.Execute(m_0000_000_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAM_RAMO_VGAP, PARAM_RAMO_VGAP);
                _.Move(executed_1.PARAM_RAMO_VG, PARAM_RAMO_VG);
                _.Move(executed_1.PARAM_RAMO_AP, PARAM_RAMO_AP);
                _.Move(executed_1.PARAM_RAMO_PRSTMISTA, PARAM_RAMO_PRSTMISTA);
            }


        }

        [StopWatch]
        /*" M-0040-020-PROCESSA-RELATO-SECTION */
        private void M_0040_020_PROCESSA_RELATO_SECTION()
        {
            /*" -969- PERFORM 0140-040-060-ACESSA-HISTSEGVG. */

            M_0140_040_060_ACESSA_HISTSEGVG_SECTION();

            /*" -970- IF WS-V1HISTSEGVG EQUAL 'S' */

            if (WS_V1HISTSEGVG == "S")
            {

                /*" -971- MOVE SPACES TO WS-V1HISTSEGVG */
                _.Move("", WS_V1HISTSEGVG);

                /*" -972- GO TO R1000-10-LEITURA */

                R1000_10_LEITURA(); //GOTO
                return;

                /*" -973- END-IF. */
            }


            /*" -974- PERFORM 0145-020-060-ACESSA-MOEDA-IMP */

            M_0145_020_060_ACESSA_MOEDA_IMP_SECTION();

            /*" -978- PERFORM 0145-020-060-ACESSA-MOEDA-PRM */

            M_0145_020_060_ACESSA_MOEDA_PRM_SECTION();

            /*" -979- IF WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT */

            if (WS_CHAVE_ATU != WS_CHAVE_ANT)
            {

                /*" -980- MOVE ZEROS TO FLAG-EXISTE-ERROVIG */
                _.Move(0, WORK.FLAG_EXISTE_ERROVIG);

                /*" -981- PERFORM 0400-020-MONTA-SUB-ESTIPULA */

                M_0400_020_MONTA_SUB_ESTIPULA_SECTION();

                /*" -982- PERFORM 0040-030-BUSCA-VIGENCIA */

                M_0040_030_BUSCA_VIGENCIA_SECTION();

                /*" -983- PERFORM 0600-500-000-IMPRIME-CABECALHO */

                M_0600_500_000_IMPRIME_CABECALHO_SECTION();

                /*" -984- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT */
                _.Move(WS_CHAVE_ATU, WS_CHAVE_ANT);

                /*" -986- END-IF */
            }


            /*" -987- IF HOUVE-ERRO-VIGENCIA */

            if (WORK.FLAG_EXISTE_ERROVIG["HOUVE_ERRO_VIGENCIA"])
            {

                /*" -988- GO TO R1000-10-LEITURA */

                R1000_10_LEITURA(); //GOTO
                return;

                /*" -990- END-IF */
            }


            /*" -991- PERFORM 0060-040-MONTA-DETALHES. */

            M_0060_040_MONTA_DETALHES_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LEITURA */

            R1000_10_LEITURA();

        }

        [StopWatch]
        /*" R1000-10-LEITURA */
        private void R1000_10_LEITURA(bool isPerform = false)
        {
            /*" -994- PERFORM 0130-040-FETCH-SEGURADO. */

            M_0130_040_FETCH_SEGURADO_SECTION();

        }

        [StopWatch]
        /*" M-0040-030-BUSCA-VIGENCIA-SECTION */
        private void M_0040_030_BUSCA_VIGENCIA_SECTION()
        {
            /*" -1001- MOVE '0040-030-BUSCA-VIGENCIA           ' TO PARAGRAFO. */
            _.Move("0040-030-BUSCA-VIGENCIA           ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1003- MOVE 'SELECT VG_VIGENCIA_FATURA         ' TO COMANDO. */
            _.Move("SELECT VG_VIGENCIA_FATURA         ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1016- PERFORM M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1 */

            M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1();

            /*" -1020- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -1022- MOVE 'SELECT PROPOSTAS_VA APOL+SUBGRUPO ' TO COMANDO */
                _.Move("SELECT PROPOSTAS_VA APOL+SUBGRUPO ", WORK.LOCALIZA_ABEND_2.COMANDO);

                /*" -1030- PERFORM M_0040_030_BUSCA_VIGENCIA_DB_SELECT_2 */

                M_0040_030_BUSCA_VIGENCIA_DB_SELECT_2();

                /*" -1034- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1035- MOVE 'PROPVA: APOLICE+SUBG-ZERO   ' TO COMANDO */
                    _.Move("PROPVA: APOLICE+SUBG-ZERO   ", WORK.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1037- MOVE ZEROS TO WS-COD-SUBG-ZERO */
                    _.Move(0, WS_COD_SUBG_ZERO);

                    /*" -1043- PERFORM M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3 */

                    M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3();

                    /*" -1046- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1047- IF SEGURAVG-NUM-APOL NOT EQUAL AUX-APOLICE-ERRO */

                        if (SEGURAVG_NUM_APOL != WORK.AUX_APOLICE_ERRO)
                        {

                            /*" -1048- DISPLAY '*** NAO ACHOU APOLICE - PROPOSTAS_VA' */
                            _.Display($"*** NAO ACHOU APOLICE - PROPOSTAS_VA");

                            /*" -1051- DISPLAY 'APOLICE: ' SEGURAVG-NUM-APOL ' SUBGRP-0: ' WS-COD-SUBG-ZERO ' SUBGRP-VG: ' SEGURAVG-COD-SUBG */

                            $"APOLICE: {SEGURAVG_NUM_APOL} SUBGRP-0: {WS_COD_SUBG_ZERO} SUBGRP-VG: {SEGURAVG_COD_SUBG}"
                            .Display();

                            /*" -1052- ADD 1 TO AUX-CONT-ERRO */
                            WORK.AUX_CONT_ERRO.Value = WORK.AUX_CONT_ERRO + 1;

                            /*" -1054- MOVE SEGURAVG-NUM-APOL TO APOL-ERRO-TAB(AUX-CONT-ERRO) */
                            _.Move(SEGURAVG_NUM_APOL, WORK.TAB_APOL_ERRO.OC_TAB_APOL_ERRO[WORK.AUX_CONT_ERRO].APOL_ERRO_TAB);

                            /*" -1055- MOVE 1 TO FLAG-EXISTE-ERROVIG */
                            _.Move(1, WORK.FLAG_EXISTE_ERROVIG);

                            /*" -1056- GO TO 0040-999-BUSCA-VIGENCIA-FIM */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_999_BUSCA_VIGENCIA_FIM*/ //GOTO
                            return;

                            /*" -1058- END-IF */
                        }


                        /*" -1059- END-IF */
                    }


                    /*" -1060- ELSE */
                }
                else
                {


                    /*" -1061- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1063- DISPLAY 'APOLICE  = ' SEGURAVG-NUM-APOL ' SUBGRUPO = ' SEGURAVG-COD-SUBG */

                        $"APOLICE  = {SEGURAVG_NUM_APOL} SUBGRUPO = {SEGURAVG_COD_SUBG}"
                        .Display();

                        /*" -1064- GO TO 9999-999-ERRO */

                        M_9999_999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1065- END-IF */
                    }


                    /*" -1074- END-IF */
                }


                /*" -1075- MOVE 'PARCELAS-VIDAZUL            ' TO COMANDO */
                _.Move("PARCELAS-VIDAZUL            ", WORK.LOCALIZA_ABEND_2.COMANDO);

                /*" -1080- PERFORM M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4 */

                M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4();

                /*" -1083- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1084- DISPLAY '*** ERRO AO ACESSAR PARCELAS-VIDAZUL' */
                    _.Display($"*** ERRO AO ACESSAR PARCELAS-VIDAZUL");

                    /*" -1088- DISPLAY '*** APOLICE: ' SEGURAVG-NUM-APOL ' SUBGRUPO: ' SEGURAVG-COD-SUBG ' CERTIFICADO: ' WS-NUM-CERT-PROPVA ' WHOST1: ' WHOST-DATA1 */

                    $"*** APOLICE: {SEGURAVG_NUM_APOL} SUBGRUPO: {SEGURAVG_COD_SUBG} CERTIFICADO: {WS_NUM_CERT_PROPVA} WHOST1: {WHOST_DATA1}"
                    .Display();

                    /*" -1089- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1091- END-IF */
                }


                /*" -1092- IF WS-DTINIVIG-PARC EQUAL '9999-12-31' */

                if (WS_DTINIVIG_PARC == "9999-12-31")
                {

                    /*" -1093- MOVE SISTEMA-DTMOVABE TO WS-DTINIVIG-PARC */
                    _.Move(SISTEMA_DTMOVABE, WS_DTINIVIG_PARC);

                    /*" -1094- END-IF */
                }


                /*" -1095- MOVE WS-DTINIVIG-PARC TO WS-DATA1 */
                _.Move(WS_DTINIVIG_PARC, WS_DATA1);

                /*" -1096- MOVE 01 TO WS-DIA1 */
                _.Move(01, WS_DATA1.WS_DIA1);

                /*" -1097- MOVE WS-DIA1 TO DIA-INI-VIGENCIA */
                _.Move(WS_DATA1.WS_DIA1, WORK.CAB_VIGENCIA.DIA_INI_VIGENCIA);

                /*" -1098- MOVE WS-MES1 TO MES-INI-VIGENCIA */
                _.Move(WS_DATA1.WS_MES1, WORK.CAB_VIGENCIA.MES_INI_VIGENCIA);

                /*" -1099- MOVE WS-ANO1 TO ANO-INI-VIGENCIA */
                _.Move(WS_DATA1.WS_ANO1, WORK.CAB_VIGENCIA.ANO_INI_VIGENCIA);

                /*" -1101- MOVE WS-DATA1 TO WHOST-DATA1 */
                _.Move(WS_DATA1, WHOST_DATA1);

                /*" -1102- MOVE 'SEGUROS-V0OPCAOPAGVA        ' TO COMANDO */
                _.Move("SEGUROS-V0OPCAOPAGVA        ", WORK.LOCALIZA_ABEND_2.COMANDO);

                /*" -1108- PERFORM M_0040_030_BUSCA_VIGENCIA_DB_SELECT_5 */

                M_0040_030_BUSCA_VIGENCIA_DB_SELECT_5();

                /*" -1111- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1112- DISPLAY 'SEGUROS.V0OPCAOPAGVA = ' WS-NUM-CERT-PROPVA */
                    _.Display($"SEGUROS.V0OPCAOPAGVA = {WS_NUM_CERT_PROPVA}");

                    /*" -1113- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1115- END-IF */
                }


                /*" -1116- MOVE 'V0SISTEMA: CALCULO DATA HOST2' TO COMANDO */
                _.Move("V0SISTEMA: CALCULO DATA HOST2", WORK.LOCALIZA_ABEND_2.COMANDO);

                /*" -1124- PERFORM M_0040_030_BUSCA_VIGENCIA_DB_SELECT_6 */

                M_0040_030_BUSCA_VIGENCIA_DB_SELECT_6();

                /*" -1127- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1128- DISPLAY '*** SEGUROS.V0SISTEMA - CALCULO HOST2 ***' */
                    _.Display($"*** SEGUROS.V0SISTEMA - CALCULO HOST2 ***");

                    /*" -1132- DISPLAY '*** APOLICE: ' SEGURAVG-NUM-APOL ' SUBGRUPO: ' SEGURAVG-COD-SUBG ' CERTIFICADO: ' WS-NUM-CERT-PROPVA ' WHOST1: ' WHOST-DATA1 */

                    $"*** APOLICE: {SEGURAVG_NUM_APOL} SUBGRUPO: {SEGURAVG_COD_SUBG} CERTIFICADO: {WS_NUM_CERT_PROPVA} WHOST1: {WHOST_DATA1}"
                    .Display();

                    /*" -1133- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1135- END-IF */
                }


                /*" -1136- MOVE WHOST-DATA2 TO WS-DATA2 */
                _.Move(WHOST_DATA2, WS_DATA2);

                /*" -1137- MOVE WS-DIA2 TO DIA-TER-VIGENCIA */
                _.Move(WS_DATA2.WS_DIA2, WORK.CAB_VIGENCIA.DIA_TER_VIGENCIA);

                /*" -1138- MOVE WS-MES2 TO MES-TER-VIGENCIA */
                _.Move(WS_DATA2.WS_MES2, WORK.CAB_VIGENCIA.MES_TER_VIGENCIA);

                /*" -1140- MOVE WS-ANO2 TO ANO-TER-VIGENCIA */
                _.Move(WS_DATA2.WS_ANO2, WORK.CAB_VIGENCIA.ANO_TER_VIGENCIA);

                /*" -1141- ELSE */
            }
            else
            {


                /*" -1143- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1145- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1146- ELSE */
                }
                else
                {


                    /*" -1147- MOVE VG083-DTA-INI-FATURA TO WS-DATA1 */
                    _.Move(VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_INI_FATURA, WS_DATA1);

                    /*" -1148- MOVE WS-DIA1 TO DIA-INI-VIGENCIA */
                    _.Move(WS_DATA1.WS_DIA1, WORK.CAB_VIGENCIA.DIA_INI_VIGENCIA);

                    /*" -1149- MOVE WS-MES1 TO MES-INI-VIGENCIA */
                    _.Move(WS_DATA1.WS_MES1, WORK.CAB_VIGENCIA.MES_INI_VIGENCIA);

                    /*" -1150- MOVE WS-ANO1 TO ANO-INI-VIGENCIA */
                    _.Move(WS_DATA1.WS_ANO1, WORK.CAB_VIGENCIA.ANO_INI_VIGENCIA);

                    /*" -1152- MOVE WS-DATA1 TO WHOST-DATA1 */
                    _.Move(WS_DATA1, WHOST_DATA1);

                    /*" -1153- MOVE VG083-DTA-FIM-FATURA TO WS-DATA2 */
                    _.Move(VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_FIM_FATURA, WS_DATA2);

                    /*" -1154- MOVE WS-DIA2 TO DIA-TER-VIGENCIA */
                    _.Move(WS_DATA2.WS_DIA2, WORK.CAB_VIGENCIA.DIA_TER_VIGENCIA);

                    /*" -1155- MOVE WS-MES2 TO MES-TER-VIGENCIA */
                    _.Move(WS_DATA2.WS_MES2, WORK.CAB_VIGENCIA.MES_TER_VIGENCIA);

                    /*" -1156- MOVE WS-ANO2 TO ANO-TER-VIGENCIA */
                    _.Move(WS_DATA2.WS_ANO2, WORK.CAB_VIGENCIA.ANO_TER_VIGENCIA);

                    /*" -1157- END-IF */
                }


                /*" -1158- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0040-030-BUSCA-VIGENCIA-DB-SELECT-1 */
        public void M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1()
        {
            /*" -1016- EXEC SQL SELECT DTA_INI_FATURA, DTA_FIM_FATURA INTO :VG083-DTA-INI-FATURA, :VG083-DTA-FIM-FATURA FROM SEGUROS.VG_VIGENCIA_FATURA WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND COD_SUBGRUPO = 0 AND SEQ_FATURAMENTO = (SELECT MAX(T1.SEQ_FATURAMENTO) FROM SEGUROS.VG_VIGENCIA_FATURA T1 WHERE T1.NUM_APOLICE = :SEGURAVG-NUM-APOL AND T1.COD_SUBGRUPO = 0) END-EXEC. */

            var m_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1 = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
            };

            var executed_1 = M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1.Execute(m_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG083_DTA_INI_FATURA, VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_INI_FATURA);
                _.Move(executed_1.VG083_DTA_FIM_FATURA, VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_FIM_FATURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_999_BUSCA_VIGENCIA_FIM*/

        [StopWatch]
        /*" M-0040-030-BUSCA-VIGENCIA-DB-SELECT-2 */
        public void M_0040_030_BUSCA_VIGENCIA_DB_SELECT_2()
        {
            /*" -1030- EXEC SQL SELECT NUM_CERTIFICADO INTO :WS-NUM-CERT-PROPVA FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND COD_SUBGRUPO = :SEGURAVG-COD-SUBG AND SIT_REGISTRO IN ( '0' , '1' , '3' , '6' , '7' , '9' ) FETCH FIRST 1 ROW ONLY END-EXEC */

            var m_0040_030_BUSCA_VIGENCIA_DB_SELECT_2_Query1 = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_2_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_COD_SUBG = SEGURAVG_COD_SUBG.ToString(),
            };

            var executed_1 = M_0040_030_BUSCA_VIGENCIA_DB_SELECT_2_Query1.Execute(m_0040_030_BUSCA_VIGENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_CERT_PROPVA, WS_NUM_CERT_PROPVA);
            }


        }

        [StopWatch]
        /*" M-0060-040-MONTA-DETALHES-SECTION */
        private void M_0060_040_MONTA_DETALHES_SECTION()
        {
            /*" -1167- PERFORM 0070-060-PROCESSA-PRINCIPAL. */

            M_0070_060_PROCESSA_PRINCIPAL_SECTION();

            /*" -1167- PERFORM 0080-060-PROCESSA-CONJUGE. */

            M_0080_060_PROCESSA_CONJUGE_SECTION();

        }

        [StopWatch]
        /*" M-0040-030-BUSCA-VIGENCIA-DB-SELECT-3 */
        public void M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3()
        {
            /*" -1043- EXEC SQL SELECT NUM_CERTIFICADO INTO :WS-NUM-CERT-PROPVA FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND COD_SUBGRUPO = :WS-COD-SUBG-ZERO END-EXEC */

            var m_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1 = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                WS_COD_SUBG_ZERO = WS_COD_SUBG_ZERO.ToString(),
            };

            var executed_1 = M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1.Execute(m_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_CERT_PROPVA, WS_NUM_CERT_PROPVA);
            }


        }

        [StopWatch]
        /*" M-0070-060-PROCESSA-PRINCIPAL-SECTION */
        private void M_0070_060_PROCESSA_PRINCIPAL_SECTION()
        {
            /*" -1175- PERFORM 300-150-240-COBERTURAS. */

            M_300_150_240_COBERTURAS_SECTION();

            /*" -1176- MOVE CLIENTE-NOME-RAZAO TO DET1-NOME */
            _.Move(CLIENTE_NOME_RAZAO, WORK.DET_1.DET1_NOME);

            /*" -1177- MOVE SEGURAVG-COD-SUBG TO DET1-SUBG */
            _.Move(SEGURAVG_COD_SUBG, WORK.DET_1.DET1_SUBG);

            /*" -1178- MOVE LK-COBT-MORTE-NATURAL TO DET1-CAP-VG */
            _.Move(WORK.LK_COBT_MORTE_NATURAL, WORK.DET_1.DET1_CAP_VG);

            /*" -1179- MOVE LK-COBT-MORTE-ACIDENTAL TO DET1-CAP-MA */
            _.Move(WORK.LK_COBT_MORTE_ACIDENTAL, WORK.DET_1.DET1_CAP_MA);

            /*" -1180- MOVE LK-COBT-INV-PERMANENTE TO DET1-CAP-IP */
            _.Move(WORK.LK_COBT_INV_PERMANENTE, WORK.DET_1.DET1_CAP_IP);

            /*" -1181- MOVE LK-COBT-ASS-MEDICA TO DET1-CAP-AMDS */
            _.Move(WORK.LK_COBT_ASS_MEDICA, WORK.DET_1.DET1_CAP_AMDS);

            /*" -1182- MOVE LK-COBT-DIARIA-HOSPITALAR TO DET1-CAP-DH */
            _.Move(WORK.LK_COBT_DIARIA_HOSPITALAR, WORK.DET_1.DET1_CAP_DH);

            /*" -1183- MOVE LK-COBT-DIARIA-INTERNACAO TO DET1-CAP-DIT */
            _.Move(WORK.LK_COBT_DIARIA_INTERNACAO, WORK.DET_1.DET1_CAP_DIT);

            /*" -1184- MOVE CLIENTE-CGC-CPF TO AUX-CPF */
            _.Move(CLIENTE_CGC_CPF, WORK.AUX_CPF);

            /*" -1185- MOVE AUX-CPF-1 TO DET2-CPF */
            _.Move(WORK.FILLER_8.AUX_CPF_1, WORK.DET_2.DET2_CPF);

            /*" -1186- MOVE AUX-CPF-2 TO DET2-CPF-CONT */
            _.Move(WORK.FILLER_8.AUX_CPF_2, WORK.DET_2.DET2_CPF_CONT);

            /*" -1188- MOVE SEGURAVG-MATRICULA TO DET2-MATR */
            _.Move(SEGURAVG_MATRICULA, WORK.DET_2.DET2_MATR);

            /*" -1189- IF SEGURAVG-IDE-SEXO EQUAL 'M' */

            if (SEGURAVG_IDE_SEXO == "M")
            {

                /*" -1190- MOVE 'MASC' TO DET2-SEXO */
                _.Move("MASC", WORK.DET_2.DET2_SEXO);

                /*" -1191- ELSE */
            }
            else
            {


                /*" -1193- MOVE 'FEM ' TO DET2-SEXO. */
                _.Move("FEM ", WORK.DET_2.DET2_SEXO);
            }


            /*" -1194- IF SEGURAVG-EST-CIVIL EQUAL 'S' */

            if (SEGURAVG_EST_CIVIL == "S")
            {

                /*" -1195- MOVE 'SOLTEIRO  ' TO DET2-EST-CVL */
                _.Move("SOLTEIRO  ", WORK.DET_2.DET2_EST_CVL);

                /*" -1196- ELSE */
            }
            else
            {


                /*" -1197- IF SEGURAVG-EST-CIVIL EQUAL 'C' */

                if (SEGURAVG_EST_CIVIL == "C")
                {

                    /*" -1198- MOVE 'CASADO    ' TO DET2-EST-CVL */
                    _.Move("CASADO    ", WORK.DET_2.DET2_EST_CVL);

                    /*" -1199- ELSE */
                }
                else
                {


                    /*" -1200- IF SEGURAVG-EST-CIVIL EQUAL 'D' */

                    if (SEGURAVG_EST_CIVIL == "D")
                    {

                        /*" -1201- MOVE 'DESQUITADO' TO DET2-EST-CVL */
                        _.Move("DESQUITADO", WORK.DET_2.DET2_EST_CVL);

                        /*" -1202- ELSE */
                    }
                    else
                    {


                        /*" -1204- MOVE SEGURAVG-EST-CIVIL TO DET2-EST-CVL. */
                        _.Move(SEGURAVG_EST_CIVIL, WORK.DET_2.DET2_EST_CVL);
                    }

                }

            }


            /*" -1205- MOVE SEGURAVG-DT-NASCI TO DATA-SQL */
            _.Move(SEGURAVG_DT_NASCI, WORK.DATA_SQL);

            /*" -1206- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -1207- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -1208- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -1209- MOVE DATA-NORMAL TO DET2-NASC. */
            _.Move(WORK.DATA_NORMAL, WORK.DET_2.DET2_NASC);

            /*" -1210- MOVE SEGURAVG-DT-INIVI TO DATA-SQL. */
            _.Move(SEGURAVG_DT_INIVI, WORK.DATA_SQL);

            /*" -1211- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -1212- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -1213- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -1214- MOVE DATA-NORMAL TO DET2-INIVIG. */
            _.Move(WORK.DATA_NORMAL, WORK.DET_2.DET2_INIVIG);

            /*" -1215- MOVE LK-PREM-MORTE-NATURAL TO DET2-PREM-VG. */
            _.Move(WORK.LK_PREM_MORTE_NATURAL, WORK.DET_2.DET2_PREM_VG);

            /*" -1216- MOVE LK-PREM-ACIDENTES-PESSOAIS TO DET2-PREM-AP. */
            _.Move(WORK.LK_PREM_ACIDENTES_PESSOAIS, WORK.DET_2.DET2_PREM_AP);

            /*" -1217- MOVE COBERPR-VLCUSTCAP TO DET3-VLCUSTCAP. */
            _.Move(COBERPR_VLCUSTCAP, WORK.DET_3.DET3_VLCUSTCAP);

            /*" -1218- MOVE COBERPR-QTTITCAP TO DET3-QTTITCAP. */
            _.Move(COBERPR_QTTITCAP, WORK.DET_3.DET3_QTTITCAP);

            /*" -1219- MOVE SEGURAVG-NUM-CERT TO DET3-CERT. */
            _.Move(SEGURAVG_NUM_CERT, WORK.DET_3.DET3_CERT);

            /*" -1220- MOVE HISTSEGVG-DATA-MOV TO DATA-SQL. */
            _.Move(HISTSEGVG_DATA_MOV, WORK.DATA_SQL);

            /*" -1221- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -1222- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -1223- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -1224- MOVE DATA-NORMAL TO DET3-ULTI-ALT. */
            _.Move(WORK.DATA_NORMAL, WORK.DET_3.DET3_ULTI_ALT);

            /*" -1229- PERFORM 0330-070-090-PESQUISA VARYING I FROM 1 BY 1 UNTIL I GREATER 15 OR TAB-COD-OPER(I) EQUAL HISTSEGVG-COD-OPER. */

            for (WORK.I.Value = 1; !(WORK.I > 15 || WORK.TAB_AUX.TAB_OPERACAO[WORK.I].TAB_COD_OPER == HISTSEGVG_COD_OPER); WORK.I.Value += 1)
            {

                M_0330_070_090_PESQUISA_SECTION();
            }

            /*" -1230- IF I GREATER 15 */

            if (WORK.I > 15)
            {

                /*" -1231- MOVE 'NAO CADASTRADO' TO DET3-DESC-ULT-ALT */
                _.Move("NAO CADASTRADO", WORK.DET_3.DET3_DESC_ULT_ALT);

                /*" -1232- ELSE */
            }
            else
            {


                /*" -1234- MOVE TAB-DES-OPER(I) TO DET3-DESC-ULT-ALT. */
                _.Move(WORK.TAB_AUX.TAB_OPERACAO[WORK.I].TAB_DES_OPER, WORK.DET_3.DET3_DESC_ULT_ALT);
            }


            /*" -1236- PERFORM 0450-020-ACESSA-CTA-CORRENTE. */

            M_0450_020_ACESSA_CTA_CORRENTE_SECTION();

            /*" -1237- PERFORM 0340-070-090-TOTALIZA. */

            M_0340_070_090_TOTALIZA_SECTION();

            /*" -1237- PERFORM 0500-070-090-IMPRIME-DETALHES. */

            M_0500_070_090_IMPRIME_DETALHES_SECTION();

        }

        [StopWatch]
        /*" M-0040-030-BUSCA-VIGENCIA-DB-SELECT-4 */
        public void M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4()
        {
            /*" -1080- EXEC SQL SELECT VALUE(MAX(DATA_VENCIMENTO), '9999-12-31' ) INTO :WS-DTINIVIG-PARC FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :WS-NUM-CERT-PROPVA END-EXEC */

            var m_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1 = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1()
            {
                WS_NUM_CERT_PROPVA = WS_NUM_CERT_PROPVA.ToString(),
            };

            var executed_1 = M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1.Execute(m_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DTINIVIG_PARC, WS_DTINIVIG_PARC);
            }


        }

        [StopWatch]
        /*" M-0080-060-PROCESSA-CONJUGE-SECTION */
        private void M_0080_060_PROCESSA_CONJUGE_SECTION()
        {
            /*" -1243- PERFORM 0210-200-ACESSA-SEGURAVG */

            M_0210_200_ACESSA_SEGURAVG_SECTION();

            /*" -1244- IF POSSUI-CONJUGE */

            if (WORK.FLAG_CONJUGE["POSSUI_CONJUGE"])
            {

                /*" -1245- PERFORM 0220-200-ACESSA-CLIENTES */

                M_0220_200_ACESSA_CLIENTES_SECTION();

                /*" -1246- PERFORM 0140-040-060-ACESSA-HISTSEGVG */

                M_0140_040_060_ACESSA_HISTSEGVG_SECTION();

                /*" -1247- PERFORM 0145-020-060-ACESSA-MOEDA-IMP */

                M_0145_020_060_ACESSA_MOEDA_IMP_SECTION();

                /*" -1248- PERFORM 0145-020-060-ACESSA-MOEDA-PRM */

                M_0145_020_060_ACESSA_MOEDA_PRM_SECTION();

                /*" -1249- PERFORM 0090-080-MONTA-CONJUGE */

                M_0090_080_MONTA_CONJUGE_SECTION();

                /*" -1249- MOVE ZEROS TO FLAG-CONJUGE. */
                _.Move(0, WORK.FLAG_CONJUGE);
            }


        }

        [StopWatch]
        /*" M-0040-030-BUSCA-VIGENCIA-DB-SELECT-5 */
        public void M_0040_030_BUSCA_VIGENCIA_DB_SELECT_5()
        {
            /*" -1108- EXEC SQL SELECT PERIPGTO INTO :WS-PERIPGTO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :WS-NUM-CERT-PROPVA AND DTTERVIG = '9999-12-31' END-EXEC */

            var m_0040_030_BUSCA_VIGENCIA_DB_SELECT_5_Query1 = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_5_Query1()
            {
                WS_NUM_CERT_PROPVA = WS_NUM_CERT_PROPVA.ToString(),
            };

            var executed_1 = M_0040_030_BUSCA_VIGENCIA_DB_SELECT_5_Query1.Execute(m_0040_030_BUSCA_VIGENCIA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_PERIPGTO, WS_PERIPGTO);
            }


        }

        [StopWatch]
        /*" M-0090-080-MONTA-CONJUGE-SECTION */
        private void M_0090_080_MONTA_CONJUGE_SECTION()
        {
            /*" -1256- PERFORM 300-150-240-COBERTURAS. */

            M_300_150_240_COBERTURAS_SECTION();

            /*" -1257- MOVE WHOST-NOME-RAZAO TO DET1-NOME */
            _.Move(WHOST_NOME_RAZAO, WORK.DET_1.DET1_NOME);

            /*" -1258- MOVE SEGURAVG-COD-SUBG TO DET1-SUBG */
            _.Move(SEGURAVG_COD_SUBG, WORK.DET_1.DET1_SUBG);

            /*" -1259- MOVE LK-COBT-MORTE-NATURAL TO DET1-CAP-VG */
            _.Move(WORK.LK_COBT_MORTE_NATURAL, WORK.DET_1.DET1_CAP_VG);

            /*" -1260- MOVE LK-COBT-MORTE-ACIDENTAL TO DET1-CAP-MA */
            _.Move(WORK.LK_COBT_MORTE_ACIDENTAL, WORK.DET_1.DET1_CAP_MA);

            /*" -1261- MOVE LK-COBT-INV-PERMANENTE TO DET1-CAP-IP */
            _.Move(WORK.LK_COBT_INV_PERMANENTE, WORK.DET_1.DET1_CAP_IP);

            /*" -1262- MOVE LK-COBT-ASS-MEDICA TO DET1-CAP-AMDS */
            _.Move(WORK.LK_COBT_ASS_MEDICA, WORK.DET_1.DET1_CAP_AMDS);

            /*" -1263- MOVE LK-COBT-DIARIA-HOSPITALAR TO DET1-CAP-DH */
            _.Move(WORK.LK_COBT_DIARIA_HOSPITALAR, WORK.DET_1.DET1_CAP_DH);

            /*" -1264- MOVE LK-COBT-DIARIA-INTERNACAO TO DET1-CAP-DIT */
            _.Move(WORK.LK_COBT_DIARIA_INTERNACAO, WORK.DET_1.DET1_CAP_DIT);

            /*" -1265- MOVE WHOST-CGC-CPF TO AUX-CPF */
            _.Move(WHOST_CGC_CPF, WORK.AUX_CPF);

            /*" -1266- MOVE AUX-CPF-1 TO DET2-CPF */
            _.Move(WORK.FILLER_8.AUX_CPF_1, WORK.DET_2.DET2_CPF);

            /*" -1267- MOVE AUX-CPF-2 TO DET2-CPF-CONT */
            _.Move(WORK.FILLER_8.AUX_CPF_2, WORK.DET_2.DET2_CPF_CONT);

            /*" -1269- MOVE SEGURAVG-MATRICULA TO DET2-MATR */
            _.Move(SEGURAVG_MATRICULA, WORK.DET_2.DET2_MATR);

            /*" -1270- IF SEGURAVG-IDE-SEXO EQUAL 'F' */

            if (SEGURAVG_IDE_SEXO == "F")
            {

                /*" -1271- MOVE 'FEM ' TO DET2-SEXO */
                _.Move("FEM ", WORK.DET_2.DET2_SEXO);

                /*" -1272- ELSE */
            }
            else
            {


                /*" -1274- MOVE 'MASC' TO DET2-SEXO. */
                _.Move("MASC", WORK.DET_2.DET2_SEXO);
            }


            /*" -1275- IF SEGURAVG-EST-CIVIL EQUAL 'S' */

            if (SEGURAVG_EST_CIVIL == "S")
            {

                /*" -1276- MOVE 'SOLTEIRO  ' TO DET2-EST-CVL */
                _.Move("SOLTEIRO  ", WORK.DET_2.DET2_EST_CVL);

                /*" -1277- ELSE */
            }
            else
            {


                /*" -1278- IF SEGURAVG-EST-CIVIL EQUAL 'C' */

                if (SEGURAVG_EST_CIVIL == "C")
                {

                    /*" -1279- MOVE 'CASADO    ' TO DET2-EST-CVL */
                    _.Move("CASADO    ", WORK.DET_2.DET2_EST_CVL);

                    /*" -1280- ELSE */
                }
                else
                {


                    /*" -1281- IF SEGURAVG-EST-CIVIL EQUAL 'D' */

                    if (SEGURAVG_EST_CIVIL == "D")
                    {

                        /*" -1282- MOVE 'DESQUITADO' TO DET2-EST-CVL */
                        _.Move("DESQUITADO", WORK.DET_2.DET2_EST_CVL);

                        /*" -1283- ELSE */
                    }
                    else
                    {


                        /*" -1285- MOVE SEGURAVG-EST-CIVIL TO DET2-EST-CVL. */
                        _.Move(SEGURAVG_EST_CIVIL, WORK.DET_2.DET2_EST_CVL);
                    }

                }

            }


            /*" -1286- MOVE SEGURAVG-DT-NASCI TO DATA-SQL */
            _.Move(SEGURAVG_DT_NASCI, WORK.DATA_SQL);

            /*" -1287- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -1288- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -1289- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -1290- MOVE DATA-NORMAL TO DET2-NASC. */
            _.Move(WORK.DATA_NORMAL, WORK.DET_2.DET2_NASC);

            /*" -1291- MOVE SEGURAVG-DT-INIVI TO DATA-SQL. */
            _.Move(SEGURAVG_DT_INIVI, WORK.DATA_SQL);

            /*" -1292- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -1293- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -1294- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -1295- MOVE DATA-NORMAL TO DET2-INIVIG. */
            _.Move(WORK.DATA_NORMAL, WORK.DET_2.DET2_INIVIG);

            /*" -1296- MOVE LK-PREM-MORTE-NATURAL TO DET2-PREM-VG. */
            _.Move(WORK.LK_PREM_MORTE_NATURAL, WORK.DET_2.DET2_PREM_VG);

            /*" -1297- MOVE LK-PREM-ACIDENTES-PESSOAIS TO DET2-PREM-AP. */
            _.Move(WORK.LK_PREM_ACIDENTES_PESSOAIS, WORK.DET_2.DET2_PREM_AP);

            /*" -1298- MOVE SEGURAVG-NUM-CERT TO DET3-CERT */
            _.Move(SEGURAVG_NUM_CERT, WORK.DET_3.DET3_CERT);

            /*" -1299- MOVE HISTSEGVG-DATA-MOV TO DATA-SQL. */
            _.Move(HISTSEGVG_DATA_MOV, WORK.DATA_SQL);

            /*" -1300- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -1301- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -1302- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -1303- MOVE DATA-NORMAL TO DET3-ULTI-ALT. */
            _.Move(WORK.DATA_NORMAL, WORK.DET_3.DET3_ULTI_ALT);

            /*" -1308- PERFORM 0330-070-090-PESQUISA VARYING I FROM 1 BY 1 UNTIL I GREATER 15 OR TAB-COD-OPER(I) EQUAL HISTSEGVG-COD-OPER. */

            for (WORK.I.Value = 1; !(WORK.I > 15 || WORK.TAB_AUX.TAB_OPERACAO[WORK.I].TAB_COD_OPER == HISTSEGVG_COD_OPER); WORK.I.Value += 1)
            {

                M_0330_070_090_PESQUISA_SECTION();
            }

            /*" -1309- IF I GREATER 15 */

            if (WORK.I > 15)
            {

                /*" -1310- MOVE 'NAO CADASTRADO' TO DET3-DESC-ULT-ALT */
                _.Move("NAO CADASTRADO", WORK.DET_3.DET3_DESC_ULT_ALT);

                /*" -1311- ELSE */
            }
            else
            {


                /*" -1313- MOVE TAB-DES-OPER(I) TO DET3-DESC-ULT-ALT. */
                _.Move(WORK.TAB_AUX.TAB_OPERACAO[WORK.I].TAB_DES_OPER, WORK.DET_3.DET3_DESC_ULT_ALT);
            }


            /*" -1315- PERFORM 0450-020-ACESSA-CTA-CORRENTE. */

            M_0450_020_ACESSA_CTA_CORRENTE_SECTION();

            /*" -1316- PERFORM 0340-070-090-TOTALIZA. */

            M_0340_070_090_TOTALIZA_SECTION();

            /*" -1316- PERFORM 0500-070-090-IMPRIME-DETALHES. */

            M_0500_070_090_IMPRIME_DETALHES_SECTION();

        }

        [StopWatch]
        /*" M-0040-030-BUSCA-VIGENCIA-DB-SELECT-6 */
        public void M_0040_030_BUSCA_VIGENCIA_DB_SELECT_6()
        {
            /*" -1124- EXEC SQL SELECT DATE(:WHOST-DATA1) + :WS-PERIPGTO MONTHS - 1 DAY INTO :WHOST-DATA2 FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VG' END-EXEC */

            var m_0040_030_BUSCA_VIGENCIA_DB_SELECT_6_Query1 = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_6_Query1()
            {
                WHOST_DATA1 = WHOST_DATA1.ToString(),
                WS_PERIPGTO = WS_PERIPGTO.ToString(),
            };

            var executed_1 = M_0040_030_BUSCA_VIGENCIA_DB_SELECT_6_Query1.Execute(m_0040_030_BUSCA_VIGENCIA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA2, WHOST_DATA2);
            }


        }

        [StopWatch]
        /*" M-0100-000-DECLARA-RELATORIO-SECTION */
        private void M_0100_000_DECLARA_RELATORIO_SECTION()
        {
            /*" -1323- MOVE '0100-000-DECLARA-RELATORIO ' TO PARAGRAFO. */
            _.Move("0100-000-DECLARA-RELATORIO ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1325- MOVE 'DECLARE.. FROM SEGUROS.V0RELATORIOS' TO COMANDO. */
            _.Move("DECLARE.. FROM SEGUROS.V0RELATORIOS", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1341- PERFORM M_0100_000_DECLARA_RELATORIO_DB_DECLARE_1 */

            M_0100_000_DECLARA_RELATORIO_DB_DECLARE_1();

            /*" -1344- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1346- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1347- MOVE 'OPEN ...  CURSOR  RELATORIO      ' TO COMANDO. */
            _.Move("OPEN ...  CURSOR  RELATORIO      ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1349- DISPLAY 'OPEN ...  CURSOR  RELATORIO      ' . */
            _.Display($"OPEN ...  CURSOR  RELATORIO      ");

            /*" -1350- PERFORM M_0100_000_DECLARA_RELATORIO_DB_OPEN_1 */

            M_0100_000_DECLARA_RELATORIO_DB_OPEN_1();

            /*" -1353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1353- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0100-000-DECLARA-RELATORIO-DB-DECLARE-1 */
        public void M_0100_000_DECLARA_RELATORIO_DB_DECLARE_1()
        {
            /*" -1341- EXEC SQL DECLARE RELATORIO CURSOR FOR SELECT IDSISTEM , CODRELAT , NUM_APOLICE , NRCERTIF , CODSUBES , OPERACAO , SITUACAO FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'VG' AND SITUACAO = '0' AND CODRELAT = 'VG0120B' AND OPERACAO >= 1 AND OPERACAO <= 3 ORDER BY OPERACAO END-EXEC. */
            RELATORIO = new VG0120B_RELATORIO(false);
            string GetQuery_RELATORIO()
            {
                var query = @$"SELECT IDSISTEM
							, 
							CODRELAT
							, 
							NUM_APOLICE
							, 
							NRCERTIF
							, 
							CODSUBES
							, 
							OPERACAO
							, 
							SITUACAO 
							FROM SEGUROS.V0RELATORIOS 
							WHERE IDSISTEM = 'VG' 
							AND SITUACAO = '0' 
							AND CODRELAT = 'VG0120B' 
							AND OPERACAO >= 1 
							AND OPERACAO <= 3 
							ORDER BY OPERACAO";

                return query;
            }
            RELATORIO.GetQueryEvent += GetQuery_RELATORIO;

        }

        [StopWatch]
        /*" M-0100-000-DECLARA-RELATORIO-DB-OPEN-1 */
        public void M_0100_000_DECLARA_RELATORIO_DB_OPEN_1()
        {
            /*" -1350- EXEC SQL OPEN RELATORIO END-EXEC. */

            RELATORIO.Open();

        }

        [StopWatch]
        /*" M-0121-120-DECLARA-SEGURADOS-DB-DECLARE-1 */
        public void M_0121_120_DECLARA_SEGURADOS_DB_DECLARE_1()
        {
            /*" -1473- EXEC SQL DECLARE SEGURADO1 CURSOR FOR SELECT T1.NUM_APOLICE , T1.COD_SUBGRUPO , T1.COD_CLIENTE , T1.NUM_CERTIFICADO , T1.DAC_CERTIFICADO , T1.TIPO_SEGURADO , T1.NUM_ITEM , T1.OCORR_HISTORICO , T1.ESTADO_CIVIL , T1.IDE_SEXO , T1.NUM_MATRICULA , T1.DATA_INIVIGENCIA , T1.SIT_REGISTRO , VALUE(T1.DATA_NASCIMENTO, DATE( '1900-01-01' )), T2.COD_CLIENTE , T2.NOME_RAZAO , T2.CGCCPF FROM SEGUROS.V1SEGURAVG T1, SEGUROS.V1CLIENTE T2 WHERE T1.COD_CLIENTE = T2.COD_CLIENTE AND T1.NUM_APOLICE = :RELAT-NUM-APOLICE AND T1.COD_SUBGRUPO >= :AUX-SUBGRUPO-I AND T1.COD_SUBGRUPO <= :AUX-SUBGRUPO-F AND T1.TIPO_SEGURADO = '1' AND T1.SIT_REGISTRO = '0' ORDER BY T1.NUM_APOLICE, T1.COD_SUBGRUPO, T2.NOME_RAZAO END-EXEC. */
            SEGURADO1 = new VG0120B_SEGURADO1(true);
            string GetQuery_SEGURADO1()
            {
                var query = @$"SELECT T1.NUM_APOLICE
							, 
							T1.COD_SUBGRUPO
							, 
							T1.COD_CLIENTE
							, 
							T1.NUM_CERTIFICADO
							, 
							T1.DAC_CERTIFICADO
							, 
							T1.TIPO_SEGURADO
							, 
							T1.NUM_ITEM
							, 
							T1.OCORR_HISTORICO
							, 
							T1.ESTADO_CIVIL
							, 
							T1.IDE_SEXO
							, 
							T1.NUM_MATRICULA
							, 
							T1.DATA_INIVIGENCIA
							, 
							T1.SIT_REGISTRO
							, 
							VALUE(T1.DATA_NASCIMENTO
							, DATE( '1900-01-01' ))
							, 
							T2.COD_CLIENTE
							, 
							T2.NOME_RAZAO
							, 
							T2.CGCCPF 
							FROM SEGUROS.V1SEGURAVG T1
							, 
							SEGUROS.V1CLIENTE T2 
							WHERE T1.COD_CLIENTE = T2.COD_CLIENTE 
							AND T1.NUM_APOLICE = '{RELAT_NUM_APOLICE}' 
							AND T1.COD_SUBGRUPO >= '{AUX_SUBGRUPO_I}' 
							AND T1.COD_SUBGRUPO <= '{AUX_SUBGRUPO_F}' 
							AND T1.TIPO_SEGURADO = '1' 
							AND T1.SIT_REGISTRO = '0' 
							ORDER BY T1.NUM_APOLICE
							, T1.COD_SUBGRUPO
							, 
							T2.NOME_RAZAO";

                return query;
            }
            SEGURADO1.GetQueryEvent += GetQuery_SEGURADO1;

        }

        [StopWatch]
        /*" M-0110-020-FETCH-RELATORIO-SECTION */
        private void M_0110_020_FETCH_RELATORIO_SECTION()
        {
            /*" -1359- MOVE '0110-020-FETCH-RELATORIO ' TO PARAGRAFO. */
            _.Move("0110-020-FETCH-RELATORIO ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1361- MOVE 'FETCH.... FROM SEGUROS.V0RELATORIOS' TO COMANDO. */
            _.Move("FETCH.... FROM SEGUROS.V0RELATORIOS", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1369- PERFORM M_0110_020_FETCH_RELATORIO_DB_FETCH_1 */

            M_0110_020_FETCH_RELATORIO_DB_FETCH_1();

            /*" -1372- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1373- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1374- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -1375- DISPLAY '    VG0120B - ERRO NO FETCH DO RELATORIOS ' */
                    _.Display($"    VG0120B - ERRO NO FETCH DO RELATORIOS ");

                    /*" -1376- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -1377- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1378- ELSE */
                }
                else
                {


                    /*" -1379- MOVE 1 TO FLAG-FIM-RELATORIO */
                    _.Move(1, WORK.FLAG_FIM_RELATORIO);

                    /*" -1380- END-IF */
                }


                /*" -1381- ELSE */
            }
            else
            {


                /*" -1382- MOVE 1 TO FLAG-EXISTE-REL */
                _.Move(1, WORK.FLAG_EXISTE_REL);

                /*" -1383- ADD 1 TO AC-SOLICITADO */
                WORK.AC_SOLICITADO.Value = WORK.AC_SOLICITADO + 1;

                /*" -1384- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0110-020-FETCH-RELATORIO-DB-FETCH-1 */
        public void M_0110_020_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -1369- EXEC SQL FETCH RELATORIO INTO :RELAT-IDSISTEM , :RELAT-CODRELAT , :RELAT-NUM-APOLICE , :RELAT-NUM-CERTIFIC , :RELAT-COD-SUBES , :RELAT-OPERACAO , :RELAT-SITUACAO END-EXEC. */

            if (RELATORIO.Fetch())
            {
                _.Move(RELATORIO.RELAT_IDSISTEM, RELAT_IDSISTEM);
                _.Move(RELATORIO.RELAT_CODRELAT, RELAT_CODRELAT);
                _.Move(RELATORIO.RELAT_NUM_APOLICE, RELAT_NUM_APOLICE);
                _.Move(RELATORIO.RELAT_NUM_CERTIFIC, RELAT_NUM_CERTIFIC);
                _.Move(RELATORIO.RELAT_COD_SUBES, RELAT_COD_SUBES);
                _.Move(RELATORIO.RELAT_OPERACAO, RELAT_OPERACAO);
                _.Move(RELATORIO.RELAT_SITUACAO, RELAT_SITUACAO);
            }

        }

        [StopWatch]
        /*" M-0120-020-DECLARA-SEGURADOS-SECTION */
        private void M_0120_020_DECLARA_SEGURADOS_SECTION()
        {
            /*" -1410- MOVE '0120-020-DECLARA-SEGURADO  ' TO PARAGRAFO. */
            _.Move("0120-020-DECLARA-SEGURADO  ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1413- MOVE 'DECLARE.. FROM SEGUROS.V1SEGURAVG  ' TO COMANDO. */
            _.Move("DECLARE.. FROM SEGUROS.V1SEGURAVG  ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1414- IF RELAT-COD-SUBES NOT GREATER ZEROS */

            if (RELAT_COD_SUBES <= 00)
            {

                /*" -1415- MOVE ZEROS TO AUX-SUBGRUPO-I */
                _.Move(0, AUX_SUBGRUPO_I);

                /*" -1416- MOVE 9999 TO AUX-SUBGRUPO-F */
                _.Move(9999, AUX_SUBGRUPO_F);

                /*" -1417- ELSE */
            }
            else
            {


                /*" -1418- MOVE RELAT-COD-SUBES TO AUX-SUBGRUPO-I */
                _.Move(RELAT_COD_SUBES, AUX_SUBGRUPO_I);

                /*" -1422- MOVE RELAT-COD-SUBES TO AUX-SUBGRUPO-F. */
                _.Move(RELAT_COD_SUBES, AUX_SUBGRUPO_F);
            }


            /*" -1423- DISPLAY '*** VG0120B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VG0120B *** ABRINDO CURSOR ...");

            /*" -1424- IF RELAT-OPERACAO EQUAL 0001 */

            if (RELAT_OPERACAO == 0001)
            {

                /*" -1425- PERFORM 0121-120-DECLARA-SEGURADOS */

                M_0121_120_DECLARA_SEGURADOS_SECTION();

                /*" -1428- MOVE 'SEGURADO POR APOLICE/NOME    ' TO CAB4-TITULO */
                _.Move("SEGURADO POR APOLICE/NOME    ", WORK.CAB_4.CAB4_TITULO);

                /*" -1429- ELSE */
            }
            else
            {


                /*" -1430- IF RELAT-OPERACAO EQUAL 0002 */

                if (RELAT_OPERACAO == 0002)
                {

                    /*" -1431- PERFORM 0122-120-DECLARA-SEGURADOS */

                    M_0122_120_DECLARA_SEGURADOS_SECTION();

                    /*" -1434- MOVE 'SEGURADO POR APOLICE/MATRICULA ' TO CAB4-TITULO */
                    _.Move("SEGURADO POR APOLICE/MATRICULA ", WORK.CAB_4.CAB4_TITULO);

                    /*" -1435- ELSE */
                }
                else
                {


                    /*" -1436- IF RELAT-OPERACAO EQUAL 0003 */

                    if (RELAT_OPERACAO == 0003)
                    {

                        /*" -1437- PERFORM 0123-120-DECLARA-SEGURADOS */

                        M_0123_120_DECLARA_SEGURADOS_SECTION();

                        /*" -1438- MOVE 'SEGURADO POR APOLICE/CERTIFICADO' TO CAB4-TITULO. */
                        _.Move("SEGURADO POR APOLICE/CERTIFICADO", WORK.CAB_4.CAB4_TITULO);
                    }

                }

            }


        }

        [StopWatch]
        /*" M-0121-120-DECLARA-SEGURADOS-SECTION */
        private void M_0121_120_DECLARA_SEGURADOS_SECTION()
        {
            /*" -1473- PERFORM M_0121_120_DECLARA_SEGURADOS_DB_DECLARE_1 */

            M_0121_120_DECLARA_SEGURADOS_DB_DECLARE_1();

            /*" -1476- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1477- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1478- DISPLAY '  VG0120B - ERRO NO JOIN SEGURAVG/CLIENTE' */
                _.Display($"  VG0120B - ERRO NO JOIN SEGURAVG/CLIENTE");

                /*" -1479- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1481- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1483- MOVE 'OPEN ...  CURSOR   SEGURADO1     ' TO COMANDO. */
            _.Move("OPEN ...  CURSOR   SEGURADO1     ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1484- PERFORM M_0121_120_DECLARA_SEGURADOS_DB_OPEN_1 */

            M_0121_120_DECLARA_SEGURADOS_DB_OPEN_1();

            /*" -1487- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1487- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0121-120-DECLARA-SEGURADOS-DB-OPEN-1 */
        public void M_0121_120_DECLARA_SEGURADOS_DB_OPEN_1()
        {
            /*" -1484- EXEC SQL OPEN SEGURADO1 END-EXEC. */

            SEGURADO1.Open();

        }

        [StopWatch]
        /*" M-0122-120-DECLARA-SEGURADOS-DB-DECLARE-1 */
        public void M_0122_120_DECLARA_SEGURADOS_DB_DECLARE_1()
        {
            /*" -1521- EXEC SQL DECLARE SEGURADO2 CURSOR FOR SELECT T1.NUM_APOLICE , T1.COD_SUBGRUPO , T1.COD_CLIENTE , T1.NUM_CERTIFICADO , T1.DAC_CERTIFICADO , T1.TIPO_SEGURADO , T1.NUM_ITEM , T1.OCORR_HISTORICO , T1.ESTADO_CIVIL , T1.IDE_SEXO , T1.NUM_MATRICULA , T1.DATA_INIVIGENCIA , T1.SIT_REGISTRO , T1.DATA_NASCIMENTO , T2.COD_CLIENTE , T2.NOME_RAZAO , T2.CGCCPF FROM SEGUROS.V1SEGURAVG T1, SEGUROS.V1CLIENTE T2 WHERE T1.COD_CLIENTE = T2.COD_CLIENTE AND T1.NUM_APOLICE = :RELAT-NUM-APOLICE AND T1.COD_SUBGRUPO >= :AUX-SUBGRUPO-I AND T1.COD_SUBGRUPO <= :AUX-SUBGRUPO-F AND T1.TIPO_SEGURADO = '1' AND T1.SIT_REGISTRO = '0' ORDER BY T1.NUM_APOLICE, T1.COD_SUBGRUPO, T1.NUM_MATRICULA END-EXEC. */
            SEGURADO2 = new VG0120B_SEGURADO2(true);
            string GetQuery_SEGURADO2()
            {
                var query = @$"SELECT T1.NUM_APOLICE
							, 
							T1.COD_SUBGRUPO
							, 
							T1.COD_CLIENTE
							, 
							T1.NUM_CERTIFICADO
							, 
							T1.DAC_CERTIFICADO
							, 
							T1.TIPO_SEGURADO
							, 
							T1.NUM_ITEM
							, 
							T1.OCORR_HISTORICO
							, 
							T1.ESTADO_CIVIL
							, 
							T1.IDE_SEXO
							, 
							T1.NUM_MATRICULA
							, 
							T1.DATA_INIVIGENCIA
							, 
							T1.SIT_REGISTRO
							, 
							T1.DATA_NASCIMENTO
							, 
							T2.COD_CLIENTE
							, 
							T2.NOME_RAZAO
							, 
							T2.CGCCPF 
							FROM SEGUROS.V1SEGURAVG T1
							, 
							SEGUROS.V1CLIENTE T2 
							WHERE T1.COD_CLIENTE = T2.COD_CLIENTE 
							AND T1.NUM_APOLICE = '{RELAT_NUM_APOLICE}' 
							AND T1.COD_SUBGRUPO >= '{AUX_SUBGRUPO_I}' 
							AND T1.COD_SUBGRUPO <= '{AUX_SUBGRUPO_F}' 
							AND T1.TIPO_SEGURADO = '1' 
							AND T1.SIT_REGISTRO = '0' 
							ORDER BY T1.NUM_APOLICE
							, T1.COD_SUBGRUPO
							, 
							T1.NUM_MATRICULA";

                return query;
            }
            SEGURADO2.GetQueryEvent += GetQuery_SEGURADO2;

        }

        [StopWatch]
        /*" M-0122-120-DECLARA-SEGURADOS-SECTION */
        private void M_0122_120_DECLARA_SEGURADOS_SECTION()
        {
            /*" -1521- PERFORM M_0122_120_DECLARA_SEGURADOS_DB_DECLARE_1 */

            M_0122_120_DECLARA_SEGURADOS_DB_DECLARE_1();

            /*" -1524- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1525- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1526- DISPLAY '  VG0120B - ERRO NO JOIN SEGURAVG/CLIENTE' */
                _.Display($"  VG0120B - ERRO NO JOIN SEGURAVG/CLIENTE");

                /*" -1527- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1529- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1531- MOVE 'OPEN ...  CURSOR   SEGURADO2     ' TO COMANDO. */
            _.Move("OPEN ...  CURSOR   SEGURADO2     ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1532- PERFORM M_0122_120_DECLARA_SEGURADOS_DB_OPEN_1 */

            M_0122_120_DECLARA_SEGURADOS_DB_OPEN_1();

            /*" -1535- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1535- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0122-120-DECLARA-SEGURADOS-DB-OPEN-1 */
        public void M_0122_120_DECLARA_SEGURADOS_DB_OPEN_1()
        {
            /*" -1532- EXEC SQL OPEN SEGURADO2 END-EXEC. */

            SEGURADO2.Open();

        }

        [StopWatch]
        /*" M-0123-120-DECLARA-SEGURADOS-DB-DECLARE-1 */
        public void M_0123_120_DECLARA_SEGURADOS_DB_DECLARE_1()
        {
            /*" -1570- EXEC SQL DECLARE SEGURADO3 CURSOR FOR SELECT T1.NUM_APOLICE , T1.COD_SUBGRUPO , T1.COD_CLIENTE , T1.NUM_CERTIFICADO , T1.DAC_CERTIFICADO , T1.TIPO_SEGURADO , T1.NUM_ITEM , T1.OCORR_HISTORICO , T1.ESTADO_CIVIL , T1.IDE_SEXO , T1.NUM_MATRICULA , T1.DATA_INIVIGENCIA , T1.SIT_REGISTRO , T1.DATA_NASCIMENTO , T2.COD_CLIENTE , T2.NOME_RAZAO , T2.CGCCPF FROM SEGUROS.V1SEGURAVG T1, SEGUROS.V1CLIENTE T2 WHERE T1.COD_CLIENTE = T2.COD_CLIENTE AND T1.NUM_APOLICE = :RELAT-NUM-APOLICE AND T1.COD_SUBGRUPO >= :AUX-SUBGRUPO-I AND T1.COD_SUBGRUPO <= :AUX-SUBGRUPO-F AND T1.TIPO_SEGURADO = '1' AND T1.SIT_REGISTRO = '0' ORDER BY T1.NUM_APOLICE, T1.COD_SUBGRUPO, T1.NUM_CERTIFICADO END-EXEC. */
            SEGURADO3 = new VG0120B_SEGURADO3(true);
            string GetQuery_SEGURADO3()
            {
                var query = @$"SELECT T1.NUM_APOLICE
							, 
							T1.COD_SUBGRUPO
							, 
							T1.COD_CLIENTE
							, 
							T1.NUM_CERTIFICADO
							, 
							T1.DAC_CERTIFICADO
							, 
							T1.TIPO_SEGURADO
							, 
							T1.NUM_ITEM
							, 
							T1.OCORR_HISTORICO
							, 
							T1.ESTADO_CIVIL
							, 
							T1.IDE_SEXO
							, 
							T1.NUM_MATRICULA
							, 
							T1.DATA_INIVIGENCIA
							, 
							T1.SIT_REGISTRO
							, 
							T1.DATA_NASCIMENTO
							, 
							T2.COD_CLIENTE
							, 
							T2.NOME_RAZAO
							, 
							T2.CGCCPF 
							FROM SEGUROS.V1SEGURAVG T1
							, 
							SEGUROS.V1CLIENTE T2 
							WHERE T1.COD_CLIENTE = T2.COD_CLIENTE 
							AND T1.NUM_APOLICE = '{RELAT_NUM_APOLICE}' 
							AND T1.COD_SUBGRUPO >= '{AUX_SUBGRUPO_I}' 
							AND T1.COD_SUBGRUPO <= '{AUX_SUBGRUPO_F}' 
							AND T1.TIPO_SEGURADO = '1' 
							AND T1.SIT_REGISTRO = '0' 
							ORDER BY T1.NUM_APOLICE
							, T1.COD_SUBGRUPO
							, 
							T1.NUM_CERTIFICADO";

                return query;
            }
            SEGURADO3.GetQueryEvent += GetQuery_SEGURADO3;

        }

        [StopWatch]
        /*" M-0123-120-DECLARA-SEGURADOS-SECTION */
        private void M_0123_120_DECLARA_SEGURADOS_SECTION()
        {
            /*" -1570- PERFORM M_0123_120_DECLARA_SEGURADOS_DB_DECLARE_1 */

            M_0123_120_DECLARA_SEGURADOS_DB_DECLARE_1();

            /*" -1573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1574- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1575- DISPLAY '  VG0120B - ERRO NO JOIN SEGURAVG/CLIENTE' */
                _.Display($"  VG0120B - ERRO NO JOIN SEGURAVG/CLIENTE");

                /*" -1576- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1578- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1580- MOVE 'OPEN ...  CURSOR   SEGURADO3     ' TO COMANDO. */
            _.Move("OPEN ...  CURSOR   SEGURADO3     ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1581- PERFORM M_0123_120_DECLARA_SEGURADOS_DB_OPEN_1 */

            M_0123_120_DECLARA_SEGURADOS_DB_OPEN_1();

            /*" -1584- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1586- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0123-120-DECLARA-SEGURADOS-DB-OPEN-1 */
        public void M_0123_120_DECLARA_SEGURADOS_DB_OPEN_1()
        {
            /*" -1581- EXEC SQL OPEN SEGURADO3 END-EXEC. */

            SEGURADO3.Open();

        }

        [StopWatch]
        /*" M-0130-040-FETCH-SEGURADO-SECTION */
        private void M_0130_040_FETCH_SEGURADO_SECTION()
        {
            /*" -1593- ADD 1 TO AC-LIDOS ON-COUNTER. */
            AC_LIDOS.Value = AC_LIDOS + 1;
            ON_COUNTER.Value = ON_COUNTER + 1;

            /*" -1595- IF AC-LIDOS EQUAL 1 OR ON-COUNTER EQUAL ON-INTERVAL */

            if (AC_LIDOS == 1 || ON_COUNTER == ON_INTERVAL)
            {

                /*" -1596- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1597- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME */

                $"LIDOS {AC_LIDOS} {WS_TIME}"
                .Display();

                /*" -1599- MOVE 0 TO ON-COUNTER. */
                _.Move(0, ON_COUNTER);
            }


            /*" -1600- MOVE '0130-040-FETCH-SEGURADO            ' TO PARAGRAFO. */
            _.Move("0130-040-FETCH-SEGURADO            ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1604- MOVE 'FETCH.... FROM SEGUROS.V1SEGURAVG  ' TO COMANDO. */
            _.Move("FETCH.... FROM SEGUROS.V1SEGURAVG  ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1605- IF RELAT-OPERACAO EQUAL 0001 */

            if (RELAT_OPERACAO == 0001)
            {

                /*" -1606- PERFORM 0131-130-FETCH-SEGURADO */

                M_0131_130_FETCH_SEGURADO_SECTION();

                /*" -1607- ELSE */
            }
            else
            {


                /*" -1608- IF RELAT-OPERACAO EQUAL 0002 */

                if (RELAT_OPERACAO == 0002)
                {

                    /*" -1609- PERFORM 0132-130-FETCH-SEGURADO */

                    M_0132_130_FETCH_SEGURADO_SECTION();

                    /*" -1610- ELSE */
                }
                else
                {


                    /*" -1611- IF RELAT-OPERACAO EQUAL 0003 */

                    if (RELAT_OPERACAO == 0003)
                    {

                        /*" -1613- PERFORM 0133-130-FETCH-SEGURADO. */

                        M_0133_130_FETCH_SEGURADO_SECTION();
                    }

                }

            }


            /*" -1614- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1615- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1616- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -1617- DISPLAY '    VG0120B - ERRO NO FETCH NO SEGURADO   ' */
                    _.Display($"    VG0120B - ERRO NO FETCH NO SEGURADO   ");

                    /*" -1618- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -1619- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1620- ELSE */
                }
                else
                {


                    /*" -1621- MOVE 1 TO FLAG-FIM-SEGURADO */
                    _.Move(1, WORK.FLAG_FIM_SEGURADO);

                    /*" -1622- ELSE */
                }

            }
            else
            {


                /*" -1622- MOVE 1 TO FLAG-EXISTE-SEGUR. */
                _.Move(1, WORK.FLAG_EXISTE_SEGUR);
            }


        }

        [StopWatch]
        /*" M-0131-130-FETCH-SEGURADO-SECTION */
        private void M_0131_130_FETCH_SEGURADO_SECTION()
        {
            /*" -1645- PERFORM M_0131_130_FETCH_SEGURADO_DB_FETCH_1 */

            M_0131_130_FETCH_SEGURADO_DB_FETCH_1();

            /*" -1650- MOVE SEGURAVG-NUM-APOL TO WS-APOLICE-ATU. */
            _.Move(SEGURAVG_NUM_APOL, WS_CHAVE_ATU.WS_APOLICE_ATU);

            /*" -1651- MOVE SEGURAVG-COD-SUBG TO WS-SUBGRUPO-ATU. */
            _.Move(SEGURAVG_COD_SUBG, WS_CHAVE_ATU.WS_SUBGRUPO_ATU);

        }

        [StopWatch]
        /*" M-0131-130-FETCH-SEGURADO-DB-FETCH-1 */
        public void M_0131_130_FETCH_SEGURADO_DB_FETCH_1()
        {
            /*" -1645- EXEC SQL FETCH SEGURADO1 INTO :SEGURAVG-NUM-APOL , :SEGURAVG-COD-SUBG , :SEGURAVG-COD-CLI , :SEGURAVG-NUM-CERT , :SEGURAVG-DAC-CERT , :SEGURAVG-TIPO-SEG , :SEGURAVG-NUM-ITEM , :SEGURAVG-OCORR-HI , :SEGURAVG-EST-CIVIL , :SEGURAVG-IDE-SEXO , :SEGURAVG-MATRICULA , :SEGURAVG-DT-INIVI , :SEGURAVG-SIT-REG , :SEGURAVG-DT-NASCI , :CLIENTE-COD-CLI , :CLIENTE-NOME-RAZAO , :CLIENTE-CGC-CPF END-EXEC. */

            if (SEGURADO1.Fetch())
            {
                _.Move(SEGURADO1.SEGURAVG_NUM_APOL, SEGURAVG_NUM_APOL);
                _.Move(SEGURADO1.SEGURAVG_COD_SUBG, SEGURAVG_COD_SUBG);
                _.Move(SEGURADO1.SEGURAVG_COD_CLI, SEGURAVG_COD_CLI);
                _.Move(SEGURADO1.SEGURAVG_NUM_CERT, SEGURAVG_NUM_CERT);
                _.Move(SEGURADO1.SEGURAVG_DAC_CERT, SEGURAVG_DAC_CERT);
                _.Move(SEGURADO1.SEGURAVG_TIPO_SEG, SEGURAVG_TIPO_SEG);
                _.Move(SEGURADO1.SEGURAVG_NUM_ITEM, SEGURAVG_NUM_ITEM);
                _.Move(SEGURADO1.SEGURAVG_OCORR_HI, SEGURAVG_OCORR_HI);
                _.Move(SEGURADO1.SEGURAVG_EST_CIVIL, SEGURAVG_EST_CIVIL);
                _.Move(SEGURADO1.SEGURAVG_IDE_SEXO, SEGURAVG_IDE_SEXO);
                _.Move(SEGURADO1.SEGURAVG_MATRICULA, SEGURAVG_MATRICULA);
                _.Move(SEGURADO1.SEGURAVG_DT_INIVI, SEGURAVG_DT_INIVI);
                _.Move(SEGURADO1.SEGURAVG_SIT_REG, SEGURAVG_SIT_REG);
                _.Move(SEGURADO1.SEGURAVG_DT_NASCI, SEGURAVG_DT_NASCI);
                _.Move(SEGURADO1.CLIENTE_COD_CLI, CLIENTE_COD_CLI);
                _.Move(SEGURADO1.CLIENTE_NOME_RAZAO, CLIENTE_NOME_RAZAO);
                _.Move(SEGURADO1.CLIENTE_CGC_CPF, CLIENTE_CGC_CPF);
            }

        }

        [StopWatch]
        /*" M-0132-130-FETCH-SEGURADO-SECTION */
        private void M_0132_130_FETCH_SEGURADO_SECTION()
        {
            /*" -1675- PERFORM M_0132_130_FETCH_SEGURADO_DB_FETCH_1 */

            M_0132_130_FETCH_SEGURADO_DB_FETCH_1();

            /*" -1680- MOVE SEGURAVG-NUM-APOL TO WS-APOLICE-ATU. */
            _.Move(SEGURAVG_NUM_APOL, WS_CHAVE_ATU.WS_APOLICE_ATU);

            /*" -1681- MOVE SEGURAVG-COD-SUBG TO WS-SUBGRUPO-ATU. */
            _.Move(SEGURAVG_COD_SUBG, WS_CHAVE_ATU.WS_SUBGRUPO_ATU);

        }

        [StopWatch]
        /*" M-0132-130-FETCH-SEGURADO-DB-FETCH-1 */
        public void M_0132_130_FETCH_SEGURADO_DB_FETCH_1()
        {
            /*" -1675- EXEC SQL FETCH SEGURADO2 INTO :SEGURAVG-NUM-APOL , :SEGURAVG-COD-SUBG , :SEGURAVG-COD-CLI , :SEGURAVG-NUM-CERT , :SEGURAVG-DAC-CERT , :SEGURAVG-TIPO-SEG , :SEGURAVG-NUM-ITEM , :SEGURAVG-OCORR-HI , :SEGURAVG-EST-CIVIL , :SEGURAVG-IDE-SEXO , :SEGURAVG-MATRICULA , :SEGURAVG-DT-INIVI , :SEGURAVG-SIT-REG , :SEGURAVG-DT-NASCI , :CLIENTE-COD-CLI , :CLIENTE-NOME-RAZAO , :CLIENTE-CGC-CPF END-EXEC. */

            if (SEGURADO2.Fetch())
            {
                _.Move(SEGURADO2.SEGURAVG_NUM_APOL, SEGURAVG_NUM_APOL);
                _.Move(SEGURADO2.SEGURAVG_COD_SUBG, SEGURAVG_COD_SUBG);
                _.Move(SEGURADO2.SEGURAVG_COD_CLI, SEGURAVG_COD_CLI);
                _.Move(SEGURADO2.SEGURAVG_NUM_CERT, SEGURAVG_NUM_CERT);
                _.Move(SEGURADO2.SEGURAVG_DAC_CERT, SEGURAVG_DAC_CERT);
                _.Move(SEGURADO2.SEGURAVG_TIPO_SEG, SEGURAVG_TIPO_SEG);
                _.Move(SEGURADO2.SEGURAVG_NUM_ITEM, SEGURAVG_NUM_ITEM);
                _.Move(SEGURADO2.SEGURAVG_OCORR_HI, SEGURAVG_OCORR_HI);
                _.Move(SEGURADO2.SEGURAVG_EST_CIVIL, SEGURAVG_EST_CIVIL);
                _.Move(SEGURADO2.SEGURAVG_IDE_SEXO, SEGURAVG_IDE_SEXO);
                _.Move(SEGURADO2.SEGURAVG_MATRICULA, SEGURAVG_MATRICULA);
                _.Move(SEGURADO2.SEGURAVG_DT_INIVI, SEGURAVG_DT_INIVI);
                _.Move(SEGURADO2.SEGURAVG_SIT_REG, SEGURAVG_SIT_REG);
                _.Move(SEGURADO2.SEGURAVG_DT_NASCI, SEGURAVG_DT_NASCI);
                _.Move(SEGURADO2.CLIENTE_COD_CLI, CLIENTE_COD_CLI);
                _.Move(SEGURADO2.CLIENTE_NOME_RAZAO, CLIENTE_NOME_RAZAO);
                _.Move(SEGURADO2.CLIENTE_CGC_CPF, CLIENTE_CGC_CPF);
            }

        }

        [StopWatch]
        /*" M-0133-130-FETCH-SEGURADO-SECTION */
        private void M_0133_130_FETCH_SEGURADO_SECTION()
        {
            /*" -1704- PERFORM M_0133_130_FETCH_SEGURADO_DB_FETCH_1 */

            M_0133_130_FETCH_SEGURADO_DB_FETCH_1();

            /*" -1709- MOVE SEGURAVG-NUM-APOL TO WS-APOLICE-ATU. */
            _.Move(SEGURAVG_NUM_APOL, WS_CHAVE_ATU.WS_APOLICE_ATU);

            /*" -1710- MOVE SEGURAVG-COD-SUBG TO WS-SUBGRUPO-ATU. */
            _.Move(SEGURAVG_COD_SUBG, WS_CHAVE_ATU.WS_SUBGRUPO_ATU);

        }

        [StopWatch]
        /*" M-0133-130-FETCH-SEGURADO-DB-FETCH-1 */
        public void M_0133_130_FETCH_SEGURADO_DB_FETCH_1()
        {
            /*" -1704- EXEC SQL FETCH SEGURADO3 INTO :SEGURAVG-NUM-APOL , :SEGURAVG-COD-SUBG , :SEGURAVG-COD-CLI , :SEGURAVG-NUM-CERT , :SEGURAVG-DAC-CERT , :SEGURAVG-TIPO-SEG , :SEGURAVG-NUM-ITEM , :SEGURAVG-OCORR-HI , :SEGURAVG-EST-CIVIL , :SEGURAVG-IDE-SEXO , :SEGURAVG-MATRICULA , :SEGURAVG-DT-INIVI , :SEGURAVG-SIT-REG , :SEGURAVG-DT-NASCI , :CLIENTE-COD-CLI , :CLIENTE-NOME-RAZAO , :CLIENTE-CGC-CPF END-EXEC. */

            if (SEGURADO3.Fetch())
            {
                _.Move(SEGURADO3.SEGURAVG_NUM_APOL, SEGURAVG_NUM_APOL);
                _.Move(SEGURADO3.SEGURAVG_COD_SUBG, SEGURAVG_COD_SUBG);
                _.Move(SEGURADO3.SEGURAVG_COD_CLI, SEGURAVG_COD_CLI);
                _.Move(SEGURADO3.SEGURAVG_NUM_CERT, SEGURAVG_NUM_CERT);
                _.Move(SEGURADO3.SEGURAVG_DAC_CERT, SEGURAVG_DAC_CERT);
                _.Move(SEGURADO3.SEGURAVG_TIPO_SEG, SEGURAVG_TIPO_SEG);
                _.Move(SEGURADO3.SEGURAVG_NUM_ITEM, SEGURAVG_NUM_ITEM);
                _.Move(SEGURADO3.SEGURAVG_OCORR_HI, SEGURAVG_OCORR_HI);
                _.Move(SEGURADO3.SEGURAVG_EST_CIVIL, SEGURAVG_EST_CIVIL);
                _.Move(SEGURADO3.SEGURAVG_IDE_SEXO, SEGURAVG_IDE_SEXO);
                _.Move(SEGURADO3.SEGURAVG_MATRICULA, SEGURAVG_MATRICULA);
                _.Move(SEGURADO3.SEGURAVG_DT_INIVI, SEGURAVG_DT_INIVI);
                _.Move(SEGURADO3.SEGURAVG_SIT_REG, SEGURAVG_SIT_REG);
                _.Move(SEGURADO3.SEGURAVG_DT_NASCI, SEGURAVG_DT_NASCI);
                _.Move(SEGURADO3.CLIENTE_COD_CLI, CLIENTE_COD_CLI);
                _.Move(SEGURADO3.CLIENTE_NOME_RAZAO, CLIENTE_NOME_RAZAO);
                _.Move(SEGURADO3.CLIENTE_CGC_CPF, CLIENTE_CGC_CPF);
            }

        }

        [StopWatch]
        /*" M-0140-040-060-ACESSA-HISTSEGVG-SECTION */
        private void M_0140_040_060_ACESSA_HISTSEGVG_SECTION()
        {
            /*" -1716- MOVE '0140-040-ACESSA-HISTSEGVG          ' TO PARAGRAFO. */
            _.Move("0140-040-ACESSA-HISTSEGVG          ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1717- MOVE 'SELECT... FROM SEGUROS.V1HISTSEGVG ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1HISTSEGVG ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1719- MOVE SPACES TO WS-V1HISTSEGVG. */
            _.Move("", WS_V1HISTSEGVG);

            /*" -1739- PERFORM M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1 */

            M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1();

            /*" -1742- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1743- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1744- DISPLAY 'CERTIFICADO NAO ENCONTRADO' */
                    _.Display($"CERTIFICADO NAO ENCONTRADO");

                    /*" -1745- DISPLAY 'APOLICE  ' SEGURAVG-NUM-APOL */
                    _.Display($"APOLICE  {SEGURAVG_NUM_APOL}");

                    /*" -1746- DISPLAY 'ITEM     ' SEGURAVG-NUM-ITEM */
                    _.Display($"ITEM     {SEGURAVG_NUM_ITEM}");

                    /*" -1747- DISPLAY 'HISTORICO' SEGURAVG-OCORR-HI */
                    _.Display($"HISTORICO{SEGURAVG_OCORR_HI}");

                    /*" -1748- MOVE 'S' TO WS-V1HISTSEGVG */
                    _.Move("S", WS_V1HISTSEGVG);

                    /*" -1749- ELSE */
                }
                else
                {


                    /*" -1750- DISPLAY 'ATENCAO ----------------------------------' */
                    _.Display($"ATENCAO ----------------------------------");

                    /*" -1751- DISPLAY '    VG0120B - ERRO NO ACESSO A V1HISTSEGVG' */
                    _.Display($"    VG0120B - ERRO NO ACESSO A V1HISTSEGVG");

                    /*" -1752- DISPLAY '------------------------------------------' */
                    _.Display($"------------------------------------------");

                    /*" -1752- GO TO 9999-999-ERRO. */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0140-040-060-ACESSA-HISTSEGVG-DB-SELECT-1 */
        public void M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1()
        {
            /*" -1739- EXEC SQL SELECT NUM_APOLICE , NUM_ITEM , COD_OPERACAO , DATA_MOVIMENTO , OCORR_HISTORICO , COD_MOEDA_IMP , COD_MOEDA_PRM INTO :HISTSEGVG-NUM-APOL , :HISTSEGVG-NUM-ITEM , :HISTSEGVG-COD-OPER , :HISTSEGVG-DATA-MOV , :HISTSEGVG-OCORR-HI , :HISTSEGVG-COD-MOEDA-IMP , :HISTSEGVG-COD-MOEDA-PRM FROM SEGUROS.V1HISTSEGVG WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND NUM_ITEM = :SEGURAVG-NUM-ITEM AND OCORR_HISTORICO = :SEGURAVG-OCORR-HI END-EXEC. */

            var m_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 = new M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_NUM_ITEM = SEGURAVG_NUM_ITEM.ToString(),
                SEGURAVG_OCORR_HI = SEGURAVG_OCORR_HI.ToString(),
            };

            var executed_1 = M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1.Execute(m_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSEGVG_NUM_APOL, HISTSEGVG_NUM_APOL);
                _.Move(executed_1.HISTSEGVG_NUM_ITEM, HISTSEGVG_NUM_ITEM);
                _.Move(executed_1.HISTSEGVG_COD_OPER, HISTSEGVG_COD_OPER);
                _.Move(executed_1.HISTSEGVG_DATA_MOV, HISTSEGVG_DATA_MOV);
                _.Move(executed_1.HISTSEGVG_OCORR_HI, HISTSEGVG_OCORR_HI);
                _.Move(executed_1.HISTSEGVG_COD_MOEDA_IMP, HISTSEGVG_COD_MOEDA_IMP);
                _.Move(executed_1.HISTSEGVG_COD_MOEDA_PRM, HISTSEGVG_COD_MOEDA_PRM);
            }


        }

        [StopWatch]
        /*" M-0145-020-060-ACESSA-MOEDA-IMP-SECTION */
        private void M_0145_020_060_ACESSA_MOEDA_IMP_SECTION()
        {
            /*" -1758- MOVE '0145-020-ACESSA-MOEDA-IMP          ' TO PARAGRAFO. */
            _.Move("0145-020-ACESSA-MOEDA-IMP          ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1760- MOVE 'SELECT... FROM SEGUROS.V1MOEDA     ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1MOEDA     ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1766- PERFORM M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1 */

            M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1();

            /*" -1769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1770- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1771- DISPLAY '    VG0120B - ERRO NO ACESSO A V1MOEDA    ' */
                _.Display($"    VG0120B - ERRO NO ACESSO A V1MOEDA    ");

                /*" -1772- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1773- GO TO 9999-999-ERRO */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;

                /*" -1774- ELSE */
            }
            else
            {


                /*" -1774- MOVE MOEDA-VLCRUZADO TO AUX-MOEDA-IMP. */
                _.Move(MOEDA_VLCRUZADO, AUX_MOEDA_IMP);
            }


        }

        [StopWatch]
        /*" M-0145-020-060-ACESSA-MOEDA-IMP-DB-SELECT-1 */
        public void M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1()
        {
            /*" -1766- EXEC SQL SELECT VLCRUZAD INTO :MOEDA-VLCRUZADO FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :HISTSEGVG-COD-MOEDA-IMP AND DTINIVIG <= :HISTSEGVG-DATA-MOV AND DTTERVIG >= :HISTSEGVG-DATA-MOV END-EXEC. */

            var m_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1 = new M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1()
            {
                HISTSEGVG_COD_MOEDA_IMP = HISTSEGVG_COD_MOEDA_IMP.ToString(),
                HISTSEGVG_DATA_MOV = HISTSEGVG_DATA_MOV.ToString(),
            };

            var executed_1 = M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1.Execute(m_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDA_VLCRUZADO, MOEDA_VLCRUZADO);
            }


        }

        [StopWatch]
        /*" M-0145-020-060-ACESSA-MOEDA-PRM-SECTION */
        private void M_0145_020_060_ACESSA_MOEDA_PRM_SECTION()
        {
            /*" -1781- MOVE '0145-020-ACESSA-MOEDA-PRM          ' TO PARAGRAFO. */
            _.Move("0145-020-ACESSA-MOEDA-PRM          ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1783- MOVE 'SELECT... FROM SEGUROS.V1MOEDA     ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1MOEDA     ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1789- PERFORM M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1 */

            M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1();

            /*" -1792- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1793- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1794- DISPLAY '    VG0120B - ERRO NO ACESSO A V1MOEDA    ' */
                _.Display($"    VG0120B - ERRO NO ACESSO A V1MOEDA    ");

                /*" -1795- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1796- GO TO 9999-999-ERRO */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;

                /*" -1797- ELSE */
            }
            else
            {


                /*" -1797- MOVE MOEDA-VLCRUZADO TO AUX-MOEDA-PRM. */
                _.Move(MOEDA_VLCRUZADO, AUX_MOEDA_PRM);
            }


        }

        [StopWatch]
        /*" M-0145-020-060-ACESSA-MOEDA-PRM-DB-SELECT-1 */
        public void M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1()
        {
            /*" -1789- EXEC SQL SELECT VLCRUZAD INTO :MOEDA-VLCRUZADO FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :HISTSEGVG-COD-MOEDA-PRM AND DTINIVIG <= :HISTSEGVG-DATA-MOV AND DTTERVIG >= :HISTSEGVG-DATA-MOV END-EXEC. */

            var m_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1 = new M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1()
            {
                HISTSEGVG_COD_MOEDA_PRM = HISTSEGVG_COD_MOEDA_PRM.ToString(),
                HISTSEGVG_DATA_MOV = HISTSEGVG_DATA_MOV.ToString(),
            };

            var executed_1 = M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1.Execute(m_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDA_VLCRUZADO, MOEDA_VLCRUZADO);
            }


        }

        [StopWatch]
        /*" M-0210-200-ACESSA-SEGURAVG-SECTION */
        private void M_0210_200_ACESSA_SEGURAVG_SECTION()
        {
            /*" -1805- MOVE '0210-200-ACESSA-SEGURAVG           ' TO PARAGRAFO. */
            _.Move("0210-200-ACESSA-SEGURAVG           ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1807- MOVE 'SELECT... FROM SEGUROS.V1SEGURAVG  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SEGURAVG  ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1809- MOVE SEGURAVG-NUM-CERT TO AUX-CERTIFICADO */
            _.Move(SEGURAVG_NUM_CERT, AUX_CERTIFICADO);

            /*" -1840- PERFORM M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1 */

            M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1();

            /*" -1843- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1844- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1845- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -1846- DISPLAY '    VG0120B - ERRO NO ACESSO A V1SEGURAVG ' */
                    _.Display($"    VG0120B - ERRO NO ACESSO A V1SEGURAVG ");

                    /*" -1847- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -1848- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1849- ELSE */
                }
                else
                {


                    /*" -1850- MOVE ZEROS TO FLAG-CONJUGE */
                    _.Move(0, WORK.FLAG_CONJUGE);

                    /*" -1851- ELSE */
                }

            }
            else
            {


                /*" -1853- MOVE 1 TO FLAG-CONJUGE. */
                _.Move(1, WORK.FLAG_CONJUGE);
            }


        }

        [StopWatch]
        /*" M-0210-200-ACESSA-SEGURAVG-DB-SELECT-1 */
        public void M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1()
        {
            /*" -1840- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_CLIENTE , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_SEGURADO , NUM_ITEM , OCORR_HISTORICO , ESTADO_CIVIL , IDE_SEXO , NUM_MATRICULA , DATA_INIVIGENCIA , SIT_REGISTRO , DATA_NASCIMENTO INTO :SEGURAVG-NUM-APOL , :SEGURAVG-COD-SUBG , :SEGURAVG-COD-CLI , :SEGURAVG-NUM-CERT , :SEGURAVG-DAC-CERT , :SEGURAVG-TIPO-SEG , :SEGURAVG-NUM-ITEM , :SEGURAVG-OCORR-HI , :SEGURAVG-EST-CIVIL , :SEGURAVG-IDE-SEXO , :SEGURAVG-MATRICULA , :SEGURAVG-DT-INIVI , :SEGURAVG-SIT-REG , :SEGURAVG-DT-NASCI FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :AUX-CERTIFICADO AND TIPO_SEGURADO = '2' END-EXEC. */

            var m_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1 = new M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1()
            {
                AUX_CERTIFICADO = AUX_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1.Execute(m_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURAVG_NUM_APOL, SEGURAVG_NUM_APOL);
                _.Move(executed_1.SEGURAVG_COD_SUBG, SEGURAVG_COD_SUBG);
                _.Move(executed_1.SEGURAVG_COD_CLI, SEGURAVG_COD_CLI);
                _.Move(executed_1.SEGURAVG_NUM_CERT, SEGURAVG_NUM_CERT);
                _.Move(executed_1.SEGURAVG_DAC_CERT, SEGURAVG_DAC_CERT);
                _.Move(executed_1.SEGURAVG_TIPO_SEG, SEGURAVG_TIPO_SEG);
                _.Move(executed_1.SEGURAVG_NUM_ITEM, SEGURAVG_NUM_ITEM);
                _.Move(executed_1.SEGURAVG_OCORR_HI, SEGURAVG_OCORR_HI);
                _.Move(executed_1.SEGURAVG_EST_CIVIL, SEGURAVG_EST_CIVIL);
                _.Move(executed_1.SEGURAVG_IDE_SEXO, SEGURAVG_IDE_SEXO);
                _.Move(executed_1.SEGURAVG_MATRICULA, SEGURAVG_MATRICULA);
                _.Move(executed_1.SEGURAVG_DT_INIVI, SEGURAVG_DT_INIVI);
                _.Move(executed_1.SEGURAVG_SIT_REG, SEGURAVG_SIT_REG);
                _.Move(executed_1.SEGURAVG_DT_NASCI, SEGURAVG_DT_NASCI);
            }


        }

        [StopWatch]
        /*" M-0220-200-ACESSA-CLIENTES-SECTION */
        private void M_0220_200_ACESSA_CLIENTES_SECTION()
        {
            /*" -1858- MOVE '0220-200-ACESSA-CLIENTES           ' TO PARAGRAFO. */
            _.Move("0220-200-ACESSA-CLIENTES           ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1860- MOVE 'SELECT... FROM SEGUROS.V1SEGURAVG  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SEGURAVG  ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -1868- PERFORM M_0220_200_ACESSA_CLIENTES_DB_SELECT_1 */

            M_0220_200_ACESSA_CLIENTES_DB_SELECT_1();

            /*" -1871- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1872- DISPLAY ' ATENCAO----------------------------------' */
                _.Display($" ATENCAO----------------------------------");

                /*" -1873- DISPLAY '    VG0120B - ERRO NO ACESSO A V1CLIENTES ' */
                _.Display($"    VG0120B - ERRO NO ACESSO A V1CLIENTES ");

                /*" -1874- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1874- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0220-200-ACESSA-CLIENTES-DB-SELECT-1 */
        public void M_0220_200_ACESSA_CLIENTES_DB_SELECT_1()
        {
            /*" -1868- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , VALUE(CGCCPF, 0) INTO :WHOST-COD-CLI , :WHOST-NOME-RAZAO, :WHOST-CGC-CPF FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :SEGURAVG-COD-CLI END-EXEC. */

            var m_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1 = new M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1()
            {
                SEGURAVG_COD_CLI = SEGURAVG_COD_CLI.ToString(),
            };

            var executed_1 = M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1.Execute(m_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_CLI, WHOST_COD_CLI);
                _.Move(executed_1.WHOST_NOME_RAZAO, WHOST_NOME_RAZAO);
                _.Move(executed_1.WHOST_CGC_CPF, WHOST_CGC_CPF);
            }


        }

        [StopWatch]
        /*" M-300-150-240-COBERTURAS-SECTION */
        private void M_300_150_240_COBERTURAS_SECTION()
        {
            /*" -1882- MOVE ZEROS TO AUX-VALORES. */
            _.Move(0, WORK.AUX_VALORES);

            /*" -1889- PERFORM M_300_150_240_COBERTURAS_DB_SELECT_1 */

            M_300_150_240_COBERTURAS_DB_SELECT_1();

            /*" -1892- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1895- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1897- IF APOLICE-RAMO = PARAM-RAMO-VG OR PARAM-RAMO-VGAP */

            if (APOLICE_RAMO.In(PARAM_RAMO_VG.ToString(), PARAM_RAMO_VGAP.ToString()))
            {

                /*" -1898- MOVE 'MORTE NATURAL ' TO AUX-TIPO-IMPORT */
                _.Move("MORTE NATURAL ", WORK.AUX_TIPO_IMPORT);

                /*" -1899- MOVE PARAM-RAMO-VG TO COBERAPOL-RAMO */
                _.Move(PARAM_RAMO_VG, COBERAPOL_RAMO);

                /*" -1900- MOVE 11 TO COBERAPOL-COBERT */
                _.Move(11, COBERAPOL_COBERT);

                /*" -1901- PERFORM 0310-300-ACESSA-V1COBERAPOL */

                M_0310_300_ACESSA_V1COBERAPOL_SECTION();

                /*" -1905- COMPUTE AUX-MORTE-NATURAL = COBERAPOL-SEGUR-IX * AUX-MOEDA-IMP * COBERAPOL-FATOR-MULTIPLICA */
                WORK.AUX_VALORES.AUX_MORTE_NATURAL.Value = COBERAPOL_SEGUR_IX * AUX_MOEDA_IMP * COBERAPOL_FATOR_MULTIPLICA;

                /*" -1910- COMPUTE LK-PREM-MORTE-NATURAL = COBERAPOL-PREM-IX * AUX-MOEDA-PRM * COBERAPOL-FATOR-MULTIPLICA */
                WORK.LK_PREM_MORTE_NATURAL.Value = COBERAPOL_PREM_IX * AUX_MOEDA_PRM * COBERAPOL_FATOR_MULTIPLICA;

                /*" -1911- ELSE */
            }
            else
            {


                /*" -1912- IF APOLICE-RAMO = PARAM-RAMO-PRSTMISTA */

                if (APOLICE_RAMO == PARAM_RAMO_PRSTMISTA)
                {

                    /*" -1913- MOVE 'MORTE NATURAL ' TO AUX-TIPO-IMPORT */
                    _.Move("MORTE NATURAL ", WORK.AUX_TIPO_IMPORT);

                    /*" -1914- MOVE PARAM-RAMO-PRSTMISTA TO COBERAPOL-RAMO */
                    _.Move(PARAM_RAMO_PRSTMISTA, COBERAPOL_RAMO);

                    /*" -1915- MOVE 11 TO COBERAPOL-COBERT */
                    _.Move(11, COBERAPOL_COBERT);

                    /*" -1916- PERFORM 0310-300-ACESSA-V1COBERAPOL */

                    M_0310_300_ACESSA_V1COBERAPOL_SECTION();

                    /*" -1920- COMPUTE AUX-MORTE-NATURAL = COBERAPOL-SEGUR-IX * AUX-MOEDA-IMP * COBERAPOL-FATOR-MULTIPLICA */
                    WORK.AUX_VALORES.AUX_MORTE_NATURAL.Value = COBERAPOL_SEGUR_IX * AUX_MOEDA_IMP * COBERAPOL_FATOR_MULTIPLICA;

                    /*" -1923- COMPUTE LK-PREM-MORTE-NATURAL = COBERAPOL-PREM-IX * AUX-MOEDA-PRM * COBERAPOL-FATOR-MULTIPLICA */
                    WORK.LK_PREM_MORTE_NATURAL.Value = COBERAPOL_PREM_IX * AUX_MOEDA_PRM * COBERAPOL_FATOR_MULTIPLICA;

                    /*" -1924- ELSE */
                }
                else
                {


                    /*" -1928- MOVE ZEROES TO AUX-MORTE-NATURAL LK-PREM-MORTE-NATURAL. */
                    _.Move(0, WORK.AUX_VALORES.AUX_MORTE_NATURAL, WORK.LK_PREM_MORTE_NATURAL);
                }

            }


            /*" -1929- MOVE 'MORTE ACIDENTAL' TO AUX-TIPO-IMPORT */
            _.Move("MORTE ACIDENTAL", WORK.AUX_TIPO_IMPORT);

            /*" -1930- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1931- MOVE 1 TO COBERAPOL-COBERT. */
            _.Move(1, COBERAPOL_COBERT);

            /*" -1932- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1936- COMPUTE AUX-MORTE-ACIDENTAL = COBERAPOL-SEGUR-IX * AUX-MOEDA-IMP * COBERAPOL-FATOR-MULTIPLICA */
            WORK.AUX_VALORES.AUX_MORTE_ACIDENTAL.Value = COBERAPOL_SEGUR_IX * AUX_MOEDA_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1941- COMPUTE AUX-PREM-MA = COBERAPOL-PREM-IX * AUX-MOEDA-PRM * COBERAPOL-FATOR-MULTIPLICA. */
            WORK.AUX_VALORES.AUX_PREM_MA.Value = COBERAPOL_PREM_IX * AUX_MOEDA_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1942- MOVE 'INV PERMANENTE' TO AUX-TIPO-IMPORT */
            _.Move("INV PERMANENTE", WORK.AUX_TIPO_IMPORT);

            /*" -1943- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1944- MOVE 2 TO COBERAPOL-COBERT. */
            _.Move(2, COBERAPOL_COBERT);

            /*" -1945- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1949- COMPUTE AUX-INV-PERMANENTE = COBERAPOL-SEGUR-IX * AUX-MOEDA-IMP * COBERAPOL-FATOR-MULTIPLICA */
            WORK.AUX_VALORES.AUX_INV_PERMANENTE.Value = COBERAPOL_SEGUR_IX * AUX_MOEDA_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1954- COMPUTE AUX-PREM-IP = COBERAPOL-PREM-IX * AUX-MOEDA-PRM * COBERAPOL-FATOR-MULTIPLICA. */
            WORK.AUX_VALORES.AUX_PREM_IP.Value = COBERAPOL_PREM_IX * AUX_MOEDA_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1955- MOVE 'AMDS          ' TO AUX-TIPO-IMPORT */
            _.Move("AMDS          ", WORK.AUX_TIPO_IMPORT);

            /*" -1956- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1957- MOVE 3 TO COBERAPOL-COBERT. */
            _.Move(3, COBERAPOL_COBERT);

            /*" -1958- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1962- COMPUTE AUX-AMDS = COBERAPOL-SEGUR-IX * AUX-MOEDA-IMP * COBERAPOL-FATOR-MULTIPLICA */
            WORK.AUX_VALORES.AUX_AMDS.Value = COBERAPOL_SEGUR_IX * AUX_MOEDA_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1968- COMPUTE AUX-PREM-AMDS = COBERAPOL-PREM-IX * AUX-MOEDA-PRM * COBERAPOL-FATOR-MULTIPLICA. */
            WORK.AUX_VALORES.AUX_PREM_AMDS.Value = COBERAPOL_PREM_IX * AUX_MOEDA_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1969- MOVE 'DIARIA HOSPITAL' TO AUX-TIPO-IMPORT */
            _.Move("DIARIA HOSPITAL", WORK.AUX_TIPO_IMPORT);

            /*" -1970- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1971- MOVE 4 TO COBERAPOL-COBERT. */
            _.Move(4, COBERAPOL_COBERT);

            /*" -1972- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1977- COMPUTE AUX-DIARIA-HOSP = COBERAPOL-SEGUR-IX * AUX-MOEDA-IMP * COBERAPOL-FATOR-MULTIPLICA */
            WORK.AUX_VALORES.AUX_DIARIA_HOSP.Value = COBERAPOL_SEGUR_IX * AUX_MOEDA_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1983- COMPUTE AUX-PREM-DH = COBERAPOL-PREM-IX * AUX-MOEDA-PRM * COBERAPOL-FATOR-MULTIPLICA. */
            WORK.AUX_VALORES.AUX_PREM_DH.Value = COBERAPOL_PREM_IX * AUX_MOEDA_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1984- MOVE 'DIARIA INTERNACAO' TO AUX-TIPO-IMPORT */
            _.Move("DIARIA INTERNACAO", WORK.AUX_TIPO_IMPORT);

            /*" -1985- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1986- MOVE 5 TO COBERAPOL-COBERT. */
            _.Move(5, COBERAPOL_COBERT);

            /*" -1987- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1991- COMPUTE AUX-DIARIA-INT = COBERAPOL-SEGUR-IX * AUX-MOEDA-IMP * COBERAPOL-FATOR-MULTIPLICA */
            WORK.AUX_VALORES.AUX_DIARIA_INT.Value = COBERAPOL_SEGUR_IX * AUX_MOEDA_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1995- COMPUTE AUX-PREM-DI = COBERAPOL-PREM-IX * AUX-MOEDA-PRM * COBERAPOL-FATOR-MULTIPLICA. */
            WORK.AUX_VALORES.AUX_PREM_DI.Value = COBERAPOL_PREM_IX * AUX_MOEDA_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -2001- COMPUTE LK-PREM-ACIDENTES-PESSOAIS = AUX-PREM-MA + AUX-PREM-IP + AUX-PREM-AMDS + AUX-PREM-DH + AUX-PREM-DI. */
            WORK.LK_PREM_ACIDENTES_PESSOAIS.Value = WORK.AUX_VALORES.AUX_PREM_MA + WORK.AUX_VALORES.AUX_PREM_IP + WORK.AUX_VALORES.AUX_PREM_AMDS + WORK.AUX_VALORES.AUX_PREM_DH + WORK.AUX_VALORES.AUX_PREM_DI;

            /*" -2008- COMPUTE LK-PREM-TOTAL = LK-PREM-ACIDENTES-PESSOAIS + LK-PREM-MORTE-NATURAL. */
            WORK.LK_PREM_TOTAL.Value = WORK.LK_PREM_ACIDENTES_PESSOAIS + WORK.LK_PREM_MORTE_NATURAL;

            /*" -2009- MOVE '300-150-240-COBERTURAS             ' TO PARAGRAFO. */
            _.Move("300-150-240-COBERTURAS             ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2011- MOVE 'SELECT... FROM SEGUROS.V0APOLICE   ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V0APOLICE   ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2020- PERFORM M_300_150_240_COBERTURAS_DB_SELECT_2 */

            M_300_150_240_COBERTURAS_DB_SELECT_2();

            /*" -2023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2025- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2026- MOVE '300-150-240-COBERTURAS             ' TO PARAGRAFO. */
            _.Move("300-150-240-COBERTURAS             ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2028- MOVE 'SELECT... FROM SEGUROS.V1CONDTEC   ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1CONDTEC   ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2039- PERFORM M_300_150_240_COBERTURAS_DB_SELECT_3 */

            M_300_150_240_COBERTURAS_DB_SELECT_3();

            /*" -2042- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2044- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2045- MOVE '300-150-240-COBERTURAS             ' TO PARAGRAFO. */
            _.Move("300-150-240-COBERTURAS             ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2047- MOVE 'SELECT... FROM SEGUROS.V0PRODUTOSVG' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V0PRODUTOSVG", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2053- PERFORM M_300_150_240_COBERTURAS_DB_SELECT_4 */

            M_300_150_240_COBERTURAS_DB_SELECT_4();

            /*" -2056- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2057- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2058- MOVE SPACES TO PRODUVG-CUSTOCAP-TOTAL */
                    _.Move("", PRODUVG_CUSTOCAP_TOTAL);

                    /*" -2059- ELSE */
                }
                else
                {


                    /*" -2061- GO TO 9999-999-ERRO. */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2062- MOVE ZEROS TO COBERPR-VLCUSTCAP. */
            _.Move(0, COBERPR_VLCUSTCAP);

            /*" -2064- MOVE ZEROS TO COBERPR-QTTITCAP. */
            _.Move(0, COBERPR_QTTITCAP);

            /*" -2065- IF PRODUVG-CUSTOCAP-TOTAL = 'S' OR 'N' */

            if (PRODUVG_CUSTOCAP_TOTAL.In("S", "N"))
            {

                /*" -2066- MOVE '300-150-240-COBERTURAS             ' TO PARAGRAFO */
                _.Move("300-150-240-COBERTURAS             ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

                /*" -2068- MOVE 'SELECT... FROM SEGUROS.V0COBERPROPV' TO COMANDO */
                _.Move("SELECT... FROM SEGUROS.V0COBERPROPV", WORK.LOCALIZA_ABEND_2.COMANDO);

                /*" -2077- PERFORM M_300_150_240_COBERTURAS_DB_SELECT_5 */

                M_300_150_240_COBERTURAS_DB_SELECT_5();

                /*" -2080- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2081- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2082- MOVE ZEROS TO COBERPR-VLCUSTCAP */
                        _.Move(0, COBERPR_VLCUSTCAP);

                        /*" -2083- MOVE ZEROS TO COBERPR-QTTITCAP */
                        _.Move(0, COBERPR_QTTITCAP);

                        /*" -2084- ELSE */
                    }
                    else
                    {


                        /*" -2086- GO TO 9999-999-ERRO. */

                        M_9999_999_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2087- IF PRODUVG-CUSTOCAP-TOTAL = 'N' */

            if (PRODUVG_CUSTOCAP_TOTAL == "N")
            {

                /*" -2090- COMPUTE COBERPR-VLCUSTCAP = COBERPR-VLCUSTCAP * COBERPR-QTTITCAP. */
                COBERPR_VLCUSTCAP.Value = COBERPR_VLCUSTCAP * COBERPR_QTTITCAP;
            }


            /*" -2092- IF APOLICE-RAMO EQUAL 93 AND APOLICE-MODALIDA EQUAL 2 */

            if (APOLICE_RAMO == 93 && APOLICE_MODALIDA == 2)
            {

                /*" -2093- COMPUTE LK-COBT-MORTE-NATURAL = AUX-MORTE-NATURAL */
                WORK.LK_COBT_MORTE_NATURAL.Value = WORK.AUX_VALORES.AUX_MORTE_NATURAL;

                /*" -2094- COMPUTE LK-COBT-MORTE-ACIDENTAL = AUX-MORTE-ACIDENTAL */
                WORK.LK_COBT_MORTE_ACIDENTAL.Value = WORK.AUX_VALORES.AUX_MORTE_ACIDENTAL;

                /*" -2095- COMPUTE LK-COBT-INV-PERMANENTE = AUX-INV-PERMANENTE */
                WORK.LK_COBT_INV_PERMANENTE.Value = WORK.AUX_VALORES.AUX_INV_PERMANENTE;

                /*" -2096- COMPUTE LK-COBT-INV-POR-DOENCA = AUX-INV-PERMANENTE */
                WORK.LK_COBT_INV_POR_DOENCA.Value = WORK.AUX_VALORES.AUX_INV_PERMANENTE;

                /*" -2097- COMPUTE LK-COBT-ASS-MEDICA = AUX-AMDS */
                WORK.LK_COBT_ASS_MEDICA.Value = WORK.AUX_VALORES.AUX_AMDS;

                /*" -2098- COMPUTE LK-COBT-DIARIA-HOSPITALAR = AUX-DIARIA-HOSP */
                WORK.LK_COBT_DIARIA_HOSPITALAR.Value = WORK.AUX_VALORES.AUX_DIARIA_HOSP;

                /*" -2099- COMPUTE LK-COBT-DIARIA-INTERNACAO = AUX-DIARIA-INT */
                WORK.LK_COBT_DIARIA_INTERNACAO.Value = WORK.AUX_VALORES.AUX_DIARIA_INT;

                /*" -2100- ELSE */
            }
            else
            {


                /*" -2101- COMPUTE LK-COBT-MORTE-NATURAL = AUX-MORTE-NATURAL */
                WORK.LK_COBT_MORTE_NATURAL.Value = WORK.AUX_VALORES.AUX_MORTE_NATURAL;

                /*" -2103- COMPUTE LK-COBT-MORTE-ACIDENTAL ROUNDED = AUX-MORTE-ACIDENTAL + AUX-MORTE-NATURAL */
                WORK.LK_COBT_MORTE_ACIDENTAL.Value = WORK.AUX_VALORES.AUX_MORTE_ACIDENTAL + WORK.AUX_VALORES.AUX_MORTE_NATURAL;

                /*" -2106- COMPUTE LK-COBT-MORTE-ACIDENTAL ROUNDED = LK-COBT-MORTE-ACIDENTAL + (AUX-MORTE-NATURAL * CONDTEC-GAR-IEA) / 100 */
                WORK.LK_COBT_MORTE_ACIDENTAL.Value = WORK.LK_COBT_MORTE_ACIDENTAL + (WORK.AUX_VALORES.AUX_MORTE_NATURAL * CONDTEC_GAR_IEA) / 100f;

                /*" -2109- COMPUTE LK-COBT-INV-PERMANENTE ROUNDED = AUX-INV-PERMANENTE + (AUX-MORTE-NATURAL * CONDTEC-GAR-IPA) / 100 */
                WORK.LK_COBT_INV_PERMANENTE.Value = WORK.AUX_VALORES.AUX_INV_PERMANENTE + (WORK.AUX_VALORES.AUX_MORTE_NATURAL * CONDTEC_GAR_IPA) / 100f;

                /*" -2111- COMPUTE LK-COBT-INV-POR-DOENCA ROUNDED = (AUX-MORTE-NATURAL * CONDTEC-GAR-IPD) / 100 */
                WORK.LK_COBT_INV_POR_DOENCA.Value = (WORK.AUX_VALORES.AUX_MORTE_NATURAL * CONDTEC_GAR_IPD) / 100f;

                /*" -2112- COMPUTE LK-COBT-ASS-MEDICA = AUX-AMDS */
                WORK.LK_COBT_ASS_MEDICA.Value = WORK.AUX_VALORES.AUX_AMDS;

                /*" -2113- COMPUTE LK-COBT-DIARIA-HOSPITALAR = AUX-DIARIA-HOSP */
                WORK.LK_COBT_DIARIA_HOSPITALAR.Value = WORK.AUX_VALORES.AUX_DIARIA_HOSP;

                /*" -2113- COMPUTE LK-COBT-DIARIA-INTERNACAO = AUX-DIARIA-INT. */
                WORK.LK_COBT_DIARIA_INTERNACAO.Value = WORK.AUX_VALORES.AUX_DIARIA_INT;
            }


        }

        [StopWatch]
        /*" M-300-150-240-COBERTURAS-DB-SELECT-1 */
        public void M_300_150_240_COBERTURAS_DB_SELECT_1()
        {
            /*" -1889- EXEC SQL SELECT RAMO INTO :APOLICE-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :RELAT-NUM-APOLICE END-EXEC. */

            var m_300_150_240_COBERTURAS_DB_SELECT_1_Query1 = new M_300_150_240_COBERTURAS_DB_SELECT_1_Query1()
            {
                RELAT_NUM_APOLICE = RELAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_300_150_240_COBERTURAS_DB_SELECT_1_Query1.Execute(m_300_150_240_COBERTURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICE_RAMO, APOLICE_RAMO);
            }


        }

        [StopWatch]
        /*" M-0310-300-ACESSA-V1COBERAPOL-SECTION */
        private void M_0310_300_ACESSA_V1COBERAPOL_SECTION()
        {
            /*" -2132- PERFORM M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1 */

            M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1();

            /*" -2135- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -2136- IF PARAM-RAMO-AP EQUAL COBERAPOL-RAMO */

                if (PARAM_RAMO_AP == COBERAPOL_RAMO)
                {

                    /*" -2137- MOVE 81 TO COBERAPOL-RAMO */
                    _.Move(81, COBERAPOL_RAMO);

                    /*" -2138- GO TO 0310-300-ACESSA-V1COBERAPOL */
                    new Task(() => M_0310_300_ACESSA_V1COBERAPOL_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2139- ELSE */
                }
                else
                {


                    /*" -2142- MOVE ZEROS TO COBERAPOL-SEGUR-IX COBERAPOL-PREM-IX COBERAPOL-FATOR-MULTIPLICA */
                    _.Move(0, COBERAPOL_SEGUR_IX, COBERAPOL_PREM_IX, COBERAPOL_FATOR_MULTIPLICA);

                    /*" -2143- ELSE */
                }

            }
            else
            {


                /*" -2144- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2145- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -2146- DISPLAY '    VG0120B - ERRO NO ACESSO A V1COBERAPOL ' */
                    _.Display($"    VG0120B - ERRO NO ACESSO A V1COBERAPOL ");

                    /*" -2147- DISPLAY '    PARA SE OBTER O VALOR ' AUX-TIPO-IMPORT */
                    _.Display($"    PARA SE OBTER O VALOR {WORK.AUX_TIPO_IMPORT}");

                    /*" -2148- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -2148- GO TO 9999-999-ERRO. */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0310-300-ACESSA-V1COBERAPOL-DB-SELECT-1 */
        public void M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1()
        {
            /*" -2132- EXEC SQL SELECT IMP_SEGURADA_IX , PRM_TARIFARIO_IX , FATOR_MULTIPLICA INTO :COBERAPOL-SEGUR-IX, :COBERAPOL-PREM-IX, :COBERAPOL-FATOR-MULTIPLICA FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND NRENDOS = 0 AND NUM_ITEM = :SEGURAVG-NUM-ITEM AND OCORHIST = :SEGURAVG-OCORR-HI AND RAMOFR = :COBERAPOL-RAMO AND MODALIFR = 0 AND COD_COBERTURA = :COBERAPOL-COBERT END-EXEC. */

            var m_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1 = new M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_NUM_ITEM = SEGURAVG_NUM_ITEM.ToString(),
                SEGURAVG_OCORR_HI = SEGURAVG_OCORR_HI.ToString(),
                COBERAPOL_COBERT = COBERAPOL_COBERT.ToString(),
                COBERAPOL_RAMO = COBERAPOL_RAMO.ToString(),
            };

            var executed_1 = M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1.Execute(m_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERAPOL_SEGUR_IX, COBERAPOL_SEGUR_IX);
                _.Move(executed_1.COBERAPOL_PREM_IX, COBERAPOL_PREM_IX);
                _.Move(executed_1.COBERAPOL_FATOR_MULTIPLICA, COBERAPOL_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-300-150-240-COBERTURAS-DB-SELECT-2 */
        public void M_300_150_240_COBERTURAS_DB_SELECT_2()
        {
            /*" -2020- EXEC SQL SELECT RAMO, MODALIDA INTO :APOLICE-RAMO, :APOLICE-MODALIDA FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL END-EXEC. */

            var m_300_150_240_COBERTURAS_DB_SELECT_2_Query1 = new M_300_150_240_COBERTURAS_DB_SELECT_2_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
            };

            var executed_1 = M_300_150_240_COBERTURAS_DB_SELECT_2_Query1.Execute(m_300_150_240_COBERTURAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICE_RAMO, APOLICE_RAMO);
                _.Move(executed_1.APOLICE_MODALIDA, APOLICE_MODALIDA);
            }


        }

        [StopWatch]
        /*" M-0330-070-090-PESQUISA-SECTION */
        private void M_0330_070_090_PESQUISA_SECTION()
        {
            /*" -2153- MOVE ZEROS TO JK. */
            _.Move(0, WORK.JK);

        }

        [StopWatch]
        /*" M-300-150-240-COBERTURAS-DB-SELECT-3 */
        public void M_300_150_240_COBERTURAS_DB_SELECT_3()
        {
            /*" -2039- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :CONDTEC-GAR-IEA, :CONDTEC-GAR-IPA, :CONDTEC-GAR-IPD, :CONDTEC-GAR-HD FROM SEGUROS.V1CONDTEC WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND COD_SUBGRUPO = :SEGURAVG-COD-SUBG END-EXEC. */

            var m_300_150_240_COBERTURAS_DB_SELECT_3_Query1 = new M_300_150_240_COBERTURAS_DB_SELECT_3_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_COD_SUBG = SEGURAVG_COD_SUBG.ToString(),
            };

            var executed_1 = M_300_150_240_COBERTURAS_DB_SELECT_3_Query1.Execute(m_300_150_240_COBERTURAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDTEC_GAR_IEA, CONDTEC_GAR_IEA);
                _.Move(executed_1.CONDTEC_GAR_IPA, CONDTEC_GAR_IPA);
                _.Move(executed_1.CONDTEC_GAR_IPD, CONDTEC_GAR_IPD);
                _.Move(executed_1.CONDTEC_GAR_HD, CONDTEC_GAR_HD);
            }


        }

        [StopWatch]
        /*" M-0340-070-090-TOTALIZA-SECTION */
        private void M_0340_070_090_TOTALIZA_SECTION()
        {
            /*" -2160- ADD 1 TO AC-VIDAS */
            WORK.AC_CAPITAIS.AC_VIDAS.Value = WORK.AC_CAPITAIS.AC_VIDAS + 1;

            /*" -2161- ADD 1 TO AC-EMITIDOS */
            WORK.AC_EMITIDOS.Value = WORK.AC_EMITIDOS + 1;

            /*" -2162- ADD LK-COBT-MORTE-NATURAL TO AC-MORTE-NATURAL. */
            WORK.AC_CAPITAIS.AC_MORTE_NATURAL.Value = WORK.AC_CAPITAIS.AC_MORTE_NATURAL + WORK.LK_COBT_MORTE_NATURAL;

            /*" -2163- ADD LK-COBT-MORTE-ACIDENTAL TO AC-MORTE-ACIDENTAL. */
            WORK.AC_CAPITAIS.AC_MORTE_ACIDENTAL.Value = WORK.AC_CAPITAIS.AC_MORTE_ACIDENTAL + WORK.LK_COBT_MORTE_ACIDENTAL;

            /*" -2164- ADD LK-COBT-INV-PERMANENTE TO AC-INV-PERMANENTE. */
            WORK.AC_CAPITAIS.AC_INV_PERMANENTE.Value = WORK.AC_CAPITAIS.AC_INV_PERMANENTE + WORK.LK_COBT_INV_PERMANENTE;

            /*" -2165- ADD LK-COBT-ASS-MEDICA TO AC-ASS-MEDICA. */
            WORK.AC_CAPITAIS.AC_ASS_MEDICA.Value = WORK.AC_CAPITAIS.AC_ASS_MEDICA + WORK.LK_COBT_ASS_MEDICA;

            /*" -2166- ADD LK-COBT-DIARIA-HOSPITALAR TO AC-DIARIA-HOSPITALAR. */
            WORK.AC_CAPITAIS.AC_DIARIA_HOSPITALAR.Value = WORK.AC_CAPITAIS.AC_DIARIA_HOSPITALAR + WORK.LK_COBT_DIARIA_HOSPITALAR;

            /*" -2167- ADD LK-COBT-DIARIA-INTERNACAO TO AC-DIARIA-INTERNACAO. */
            WORK.AC_CAPITAIS.AC_DIARIA_INTERNACAO.Value = WORK.AC_CAPITAIS.AC_DIARIA_INTERNACAO + WORK.LK_COBT_DIARIA_INTERNACAO;

            /*" -2168- ADD LK-PREM-MORTE-NATURAL TO AC-PREM-MORTE-NATURAL. */
            WORK.AC_CAPITAIS.AC_PREM_MORTE_NATURAL.Value = WORK.AC_CAPITAIS.AC_PREM_MORTE_NATURAL + WORK.LK_PREM_MORTE_NATURAL;

            /*" -2169- ADD LK-PREM-ACIDENTES-PESSOAIS TO AC-PREM-ACID-PESSOAIS. */
            WORK.AC_CAPITAIS.AC_PREM_ACID_PESSOAIS.Value = WORK.AC_CAPITAIS.AC_PREM_ACID_PESSOAIS + WORK.LK_PREM_ACIDENTES_PESSOAIS;

            /*" -2170- ADD COBERPR-QTTITCAP TO AC-TIT. */
            WORK.AC_CAPITAIS.AC_TIT.Value = WORK.AC_CAPITAIS.AC_TIT + COBERPR_QTTITCAP;

            /*" -2170- ADD COBERPR-VLCUSTCAP TO AC-CUSTOCAP. */
            WORK.AC_CAPITAIS.AC_CUSTOCAP.Value = WORK.AC_CAPITAIS.AC_CUSTOCAP + COBERPR_VLCUSTCAP;

        }

        [StopWatch]
        /*" M-300-150-240-COBERTURAS-DB-SELECT-4 */
        public void M_300_150_240_COBERTURAS_DB_SELECT_4()
        {
            /*" -2053- EXEC SQL SELECT VALUE(CUSTOCAP_TOTAL, ' ' ) INTO :PRODUVG-CUSTOCAP-TOTAL FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND CODSUBES = :SEGURAVG-COD-SUBG END-EXEC. */

            var m_300_150_240_COBERTURAS_DB_SELECT_4_Query1 = new M_300_150_240_COBERTURAS_DB_SELECT_4_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_COD_SUBG = SEGURAVG_COD_SUBG.ToString(),
            };

            var executed_1 = M_300_150_240_COBERTURAS_DB_SELECT_4_Query1.Execute(m_300_150_240_COBERTURAS_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_CUSTOCAP_TOTAL, PRODUVG_CUSTOCAP_TOTAL);
            }


        }

        [StopWatch]
        /*" M-0400-020-MONTA-ESTIPULANTE-SECTION */
        private void M_0400_020_MONTA_ESTIPULANTE_SECTION()
        {
            /*" -2176- MOVE '0400-020-MONTA-ESTIPULANTE        ' TO PARAGRAFO. */
            _.Move("0400-020-MONTA-ESTIPULANTE        ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2178- MOVE 'RAZAO SOCIAL                      ' TO COMANDO. */
            _.Move("RAZAO SOCIAL                      ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2179- MOVE RELAT-NUM-APOLICE TO AUX-APOLICE */
            _.Move(RELAT_NUM_APOLICE, AUX_APOLICE);

            /*" -2180- MOVE ZEROS TO AUX-SUBGRUPO */
            _.Move(0, AUX_SUBGRUPO);

            /*" -2181- PERFORM 0410-400-ACESSA-ESTIPULANTE. */

            M_0410_400_ACESSA_ESTIPULANTE_SECTION();

            /*" -2182- MOVE RELAT-NUM-APOLICE TO CAB5-APOLICE */
            _.Move(RELAT_NUM_APOLICE, WORK.CAB_5.CAB5_APOLICE);

            /*" -2183- MOVE WHOST-NOME-RAZAO TO CAB5-ESTIP. */
            _.Move(WHOST_NOME_RAZAO, WORK.CAB_5.CAB5_ESTIP);

            /*" -2183- MOVE WHOST-CGC-CPF TO CAB5-CNPJ-ESTIP. */
            _.Move(WHOST_CGC_CPF, WORK.CAB_5.CAB5_CNPJ_ESTIP);

        }

        [StopWatch]
        /*" M-300-150-240-COBERTURAS-DB-SELECT-5 */
        public void M_300_150_240_COBERTURAS_DB_SELECT_5()
        {
            /*" -2077- EXEC SQL SELECT VLCUSTCAP, QTTITCAP INTO :COBERPR-VLCUSTCAP, :COBERPR-QTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :SEGURAVG-NUM-CERT AND DTTERVIG = '9999-12-31' END-EXEC */

            var m_300_150_240_COBERTURAS_DB_SELECT_5_Query1 = new M_300_150_240_COBERTURAS_DB_SELECT_5_Query1()
            {
                SEGURAVG_NUM_CERT = SEGURAVG_NUM_CERT.ToString(),
            };

            var executed_1 = M_300_150_240_COBERTURAS_DB_SELECT_5_Query1.Execute(m_300_150_240_COBERTURAS_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERPR_VLCUSTCAP, COBERPR_VLCUSTCAP);
                _.Move(executed_1.COBERPR_QTTITCAP, COBERPR_QTTITCAP);
            }


        }

        [StopWatch]
        /*" M-0400-020-MONTA-SUB-ESTIPULA-SECTION */
        private void M_0400_020_MONTA_SUB_ESTIPULA_SECTION()
        {
            /*" -2188- MOVE '0400-020-MONTA-SUB-ESTIPULA       ' TO PARAGRAFO. */
            _.Move("0400-020-MONTA-SUB-ESTIPULA       ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2192- MOVE 'RAZAO SOCIAL SUB-ESTIPULANTE      ' TO COMANDO. */
            _.Move("RAZAO SOCIAL SUB-ESTIPULANTE      ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2193- MOVE SEGURAVG-NUM-APOL TO AUX-APOLICE */
            _.Move(SEGURAVG_NUM_APOL, AUX_APOLICE);

            /*" -2194- MOVE SEGURAVG-COD-SUBG TO AUX-SUBGRUPO */
            _.Move(SEGURAVG_COD_SUBG, AUX_SUBGRUPO);

            /*" -2195- PERFORM 0410-400-ACESSA-ESTIPULANTE. */

            M_0410_400_ACESSA_ESTIPULANTE_SECTION();

            /*" -2196- MOVE SEGURAVG-COD-SUBG TO CAB5-SUBG */
            _.Move(SEGURAVG_COD_SUBG, WORK.CAB5_SUBESTIP.CAB5_SUBG);

            /*" -2198- MOVE WHOST-NOME-RAZAO TO CAB5-SUB-ESTIP. */
            _.Move(WHOST_NOME_RAZAO, WORK.CAB5_SUBESTIP.CAB5_SUB_ESTIP);

            /*" -2198- MOVE WHOST-CGC-CPF TO CAB5-CNPJ-SUBEST. */
            _.Move(WHOST_CGC_CPF, WORK.CAB5_SUBESTIP.CAB5_CNPJ_SUBEST);

        }

        [StopWatch]
        /*" M-0410-400-ACESSA-ESTIPULANTE-SECTION */
        private void M_0410_400_ACESSA_ESTIPULANTE_SECTION()
        {
            /*" -2203- MOVE '0410-400-ACESSA-ESTIPULANTE        ' TO PARAGRAFO. */
            _.Move("0410-400-ACESSA-ESTIPULANTE        ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2205- MOVE 'SELECT... FROM SEGUROS.V1SUBGRUPO  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SUBGRUPO  ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2215- PERFORM M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1 */

            M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1();

            /*" -2219- MOVE 'SELECT... FROM SEGUROS.V1CLIENTES  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1CLIENTES  ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2227- PERFORM M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2 */

            M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2();

        }

        [StopWatch]
        /*" M-0410-400-ACESSA-ESTIPULANTE-DB-SELECT-1 */
        public void M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -2215- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, COD_CLIENTE INTO :SUBGRUPO-NUM-APOL, :SUBGRUPO-COD-SUBG, :SUBGRUPO-COD-CLI FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :AUX-APOLICE AND COD_SUBGRUPO = :AUX-SUBGRUPO END-EXEC. */

            var m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1 = new M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                AUX_SUBGRUPO = AUX_SUBGRUPO.ToString(),
                AUX_APOLICE = AUX_APOLICE.ToString(),
            };

            var executed_1 = M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1.Execute(m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGRUPO_NUM_APOL, SUBGRUPO_NUM_APOL);
                _.Move(executed_1.SUBGRUPO_COD_SUBG, SUBGRUPO_COD_SUBG);
                _.Move(executed_1.SUBGRUPO_COD_CLI, SUBGRUPO_COD_CLI);
            }


        }

        [StopWatch]
        /*" M-0450-020-ACESSA-CTA-CORRENTE-SECTION */
        private void M_0450_020_ACESSA_CTA_CORRENTE_SECTION()
        {
            /*" -2233- MOVE '0450-020-ACESA-CTA-CORRENTE' TO PARAGRAFO. */
            _.Move("0450-020-ACESA-CTA-CORRENTE", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2235- MOVE 'SELECT... FROM SEGUROS.V0CONTACOR  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V0CONTACOR  ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2246- PERFORM M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1 */

            M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1();

            /*" -2249- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2250- IF SQLCODE = +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -2251- MOVE SPACES TO DET3-CONTA-CORRENTE */
                    _.Move("", WORK.DET_3.DET3_CONTA_CORRENTE);

                    /*" -2252- ELSE */
                }
                else
                {


                    /*" -2253- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -2254- DISPLAY '    VG0120B - ERRO NO ACESSO A V0CONTACOR ' */
                    _.Display($"    VG0120B - ERRO NO ACESSO A V0CONTACOR ");

                    /*" -2255- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -2256- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2257- ELSE */
                }

            }
            else
            {


                /*" -2258- MOVE CONTACOR-AGENCIA TO DET3-AGENCIA */
                _.Move(CONTACOR_AGENCIA, WORK.DET_3.DET3_CONTA_CORRENTE.DET3_AGENCIA);

                /*" -2259- MOVE CONTACOR-CTA-COR TO CONTA-CORRENTE */
                _.Move(CONTACOR_CTA_COR, WORK.CONTA_CORRENTE);

                /*" -2260- MOVE CTA-OPERACAO TO DET3-OPERACAO */
                _.Move(WORK.CTA_CORR.CTA_OPERACAO, WORK.DET_3.DET3_CONTA_CORRENTE.DET3_OPERACAO);

                /*" -2261- MOVE CTA-NUM-CONTA TO DET3-CTA-CORR */
                _.Move(WORK.CTA_CORR.CTA_NUM_CONTA, WORK.DET_3.DET3_CONTA_CORRENTE.DET3_CTA_CORR);

                /*" -2262- MOVE ' - ' TO DET3-TRACO */
                _.Move(" - ", WORK.DET_3.DET3_CONTA_CORRENTE.DET3_TRACO);

                /*" -2262- MOVE CONTACOR-DAC TO DET3-DAC-CONTA. */
                _.Move(CONTACOR_DAC, WORK.DET_3.DET3_CONTA_CORRENTE.DET3_DAC_CONTA);
            }


        }

        [StopWatch]
        /*" M-0450-020-ACESSA-CTA-CORRENTE-DB-SELECT-1 */
        public void M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1()
        {
            /*" -2246- EXEC SQL SELECT COD_BANCO , COD_AGENCIA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE INTO :CONTACOR-BANCO , :CONTACOR-AGENCIA , :CONTACOR-CTA-COR , :CONTACOR-DAC FROM SEGUROS.V0CONTACOR WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND NUM_CERTIFICADO = :SEGURAVG-NUM-CERT END-EXEC. */

            var m_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1 = new M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_NUM_CERT = SEGURAVG_NUM_CERT.ToString(),
            };

            var executed_1 = M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1.Execute(m_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONTACOR_BANCO, CONTACOR_BANCO);
                _.Move(executed_1.CONTACOR_AGENCIA, CONTACOR_AGENCIA);
                _.Move(executed_1.CONTACOR_CTA_COR, CONTACOR_CTA_COR);
                _.Move(executed_1.CONTACOR_DAC, CONTACOR_DAC);
            }


        }

        [StopWatch]
        /*" M-0410-400-ACESSA-ESTIPULANTE-DB-SELECT-2 */
        public void M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2()
        {
            /*" -2227- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , CGCCPF INTO :WHOST-COD-CLI , :WHOST-NOME-RAZAO, :WHOST-CGC-CPF FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :SUBGRUPO-COD-CLI END-EXEC. */

            var m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1 = new M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1()
            {
                SUBGRUPO_COD_CLI = SUBGRUPO_COD_CLI.ToString(),
            };

            var executed_1 = M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1.Execute(m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_CLI, WHOST_COD_CLI);
                _.Move(executed_1.WHOST_NOME_RAZAO, WHOST_NOME_RAZAO);
                _.Move(executed_1.WHOST_CGC_CPF, WHOST_CGC_CPF);
            }


        }

        [StopWatch]
        /*" M-0500-070-090-IMPRIME-DETALHES-SECTION */
        private void M_0500_070_090_IMPRIME_DETALHES_SECTION()
        {
            /*" -2267- IF AC-LINHAS GREATER 52 */

            if (WORK.AC_LINHAS > 52)
            {

                /*" -2268- PERFORM 0600-500-000-IMPRIME-CABECALHO. */

                M_0600_500_000_IMPRIME_CABECALHO_SECTION();
            }


            /*" -2269- ADD 3 TO AC-LINHAS. */
            WORK.AC_LINHAS.Value = WORK.AC_LINHAS + 3;

            /*" -2270- WRITE REG-IMPRESSAO FROM DET-1. */
            _.Move(WORK.DET_1.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2271- WRITE REG-IMPRESSAO FROM DET-2. */
            _.Move(WORK.DET_2.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2271- WRITE REG-IMPRESSAO FROM DET-3. */
            _.Move(WORK.DET_3.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0520-020-IMPRIME-TOTAIS-SECTION */
        private void M_0520_020_IMPRIME_TOTAIS_SECTION()
        {
            /*" -2283- MOVE AC-VIDAS TO TOT1-VIDAS. */
            _.Move(WORK.AC_CAPITAIS.AC_VIDAS, WORK.TOT_DET_2.TOT1_VIDAS);

            /*" -2284- MOVE AC-TIT TO TOT1-TIT. */
            _.Move(WORK.AC_CAPITAIS.AC_TIT, WORK.TOT_DET_3.TOT1_TIT);

            /*" -2285- MOVE AC-CUSTOCAP TO TOT1-CUSTOCAP. */
            _.Move(WORK.AC_CAPITAIS.AC_CUSTOCAP, WORK.TOT_DET_3.TOT1_CUSTOCAP);

            /*" -2286- MOVE AC-MORTE-NATURAL TO TOT1-CAP-VG. */
            _.Move(WORK.AC_CAPITAIS.AC_MORTE_NATURAL, WORK.TOT_DET_1.TOT1_CAP_VG);

            /*" -2287- MOVE AC-MORTE-ACIDENTAL TO TOT1-CAP-MA. */
            _.Move(WORK.AC_CAPITAIS.AC_MORTE_ACIDENTAL, WORK.TOT_DET_2.TOT1_CAP_MA);

            /*" -2288- MOVE AC-INV-PERMANENTE TO TOT1-CAP-IP. */
            _.Move(WORK.AC_CAPITAIS.AC_INV_PERMANENTE, WORK.TOT_DET_1.TOT1_CAP_IP);

            /*" -2289- MOVE AC-ASS-MEDICA TO TOT1-CAP-AMDS. */
            _.Move(WORK.AC_CAPITAIS.AC_ASS_MEDICA, WORK.TOT_DET_2.TOT1_CAP_AMDS);

            /*" -2290- MOVE AC-DIARIA-HOSPITALAR TO TOT1-CAP-DH. */
            _.Move(WORK.AC_CAPITAIS.AC_DIARIA_HOSPITALAR, WORK.TOT_DET_1.TOT1_CAP_DH);

            /*" -2291- MOVE AC-DIARIA-INTERNACAO TO TOT1-CAP-DIT. */
            _.Move(WORK.AC_CAPITAIS.AC_DIARIA_INTERNACAO, WORK.TOT_DET_2.TOT1_CAP_DIT);

            /*" -2292- MOVE AC-PREM-MORTE-NATURAL TO TOT1-PREM-VG. */
            _.Move(WORK.AC_CAPITAIS.AC_PREM_MORTE_NATURAL, WORK.TOT_DET_1.TOT1_PREM_VG);

            /*" -2294- MOVE AC-PREM-ACID-PESSOAIS TO TOT1-PREM-APC. */
            _.Move(WORK.AC_CAPITAIS.AC_PREM_ACID_PESSOAIS, WORK.TOT_DET_2.TOT1_PREM_APC);

            /*" -2295- WRITE REG-IMPRESSAO FROM TOT-CAB-1 AFTER 3. */
            _.Move(WORK.TOT_CAB_1.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2296- WRITE REG-IMPRESSAO FROM TOT-CAB-2. */
            _.Move(WORK.TOT_CAB_2.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2297- WRITE REG-IMPRESSAO FROM TOT-CAB-4. */
            _.Move(WORK.TOT_CAB_4.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2298- WRITE REG-IMPRESSAO FROM TOT-CAB-3. */
            _.Move(WORK.TOT_CAB_3.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2299- WRITE REG-IMPRESSAO FROM TOT-DET-1 AFTER 2. */
            _.Move(WORK.TOT_DET_1.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2300- WRITE REG-IMPRESSAO FROM TOT-DET-2. */
            _.Move(WORK.TOT_DET_2.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2301- WRITE REG-IMPRESSAO FROM TOT-DET-3. */
            _.Move(WORK.TOT_DET_3.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2302- MOVE ZEROS TO AC-CAPITAIS. */
            _.Move(0, WORK.AC_CAPITAIS);

            /*" -2312- MOVE ZEROS TO AC-VIDAS AC-TIT AC-CUSTOCAP AC-MORTE-NATURAL AC-MORTE-ACIDENTAL AC-INV-PERMANENTE AC-ASS-MEDICA AC-DIARIA-HOSPITALAR AC-DIARIA-INTERNACAO AC-PREM-MORTE-NATURAL AC-PREM-ACID-PESSOAIS. */
            _.Move(0, WORK.AC_CAPITAIS.AC_VIDAS, WORK.AC_CAPITAIS.AC_TIT, WORK.AC_CAPITAIS.AC_CUSTOCAP, WORK.AC_CAPITAIS.AC_MORTE_NATURAL, WORK.AC_CAPITAIS.AC_MORTE_ACIDENTAL, WORK.AC_CAPITAIS.AC_INV_PERMANENTE, WORK.AC_CAPITAIS.AC_ASS_MEDICA, WORK.AC_CAPITAIS.AC_DIARIA_HOSPITALAR, WORK.AC_CAPITAIS.AC_DIARIA_INTERNACAO, WORK.AC_CAPITAIS.AC_PREM_MORTE_NATURAL, WORK.AC_CAPITAIS.AC_PREM_ACID_PESSOAIS);

        }

        [StopWatch]
        /*" M-0600-500-000-IMPRIME-CABECALHO-SECTION */
        private void M_0600_500_000_IMPRIME_CABECALHO_SECTION()
        {
            /*" -2317- ADD 1 TO AC-PAGINAS. */
            WORK.AC_PAGINAS.Value = WORK.AC_PAGINAS + 1;

            /*" -2318- MOVE AC-PAGINAS TO CAB1-PAGINA. */
            _.Move(WORK.AC_PAGINAS, WORK.CAB_1.CAB1_PAGINA);

            /*" -2319- WRITE REG-IMPRESSAO FROM CAB-1 AFTER PAGE. */
            _.Move(WORK.CAB_1.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2320- WRITE REG-IMPRESSAO FROM CAB-2. */
            _.Move(WORK.CAB_2.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2321- WRITE REG-IMPRESSAO FROM CAB-3. */
            _.Move(WORK.CAB_3.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2323- WRITE REG-IMPRESSAO FROM CAB-4. */
            _.Move(WORK.CAB_4.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2324- WRITE REG-IMPRESSAO FROM CAB-VIGENCIA. */
            _.Move(WORK.CAB_VIGENCIA.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2325- WRITE REG-IMPRESSAO FROM CAB-5. */
            _.Move(WORK.CAB_5.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2326- WRITE REG-IMPRESSAO FROM CAB5-SUBESTIP. */
            _.Move(WORK.CAB5_SUBESTIP.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2327- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2328- WRITE REG-IMPRESSAO FROM CAB-6. */
            _.Move(WORK.CAB_6.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2329- WRITE REG-IMPRESSAO FROM CAB-7. */
            _.Move(WORK.CAB_7.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2330- WRITE REG-IMPRESSAO FROM CAB-8. */
            _.Move(WORK.CAB_8.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2332- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVG0120B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2332- MOVE 12 TO AC-LINHAS. */
            _.Move(12, WORK.AC_LINHAS);

        }

        [StopWatch]
        /*" M-0700-000-UPDATE-SECTION */
        private void M_0700_000_UPDATE_SECTION()
        {
            /*" -2338- MOVE '0700-000-UPDATE               ' TO PARAGRAFO. */
            _.Move("0700-000-UPDATE               ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2340- MOVE 'UPDATE...  SEGUROS.V1RELATORIOS  ' TO COMANDO */
            _.Move("UPDATE...  SEGUROS.V1RELATORIOS  ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2341- IF AUX-CONT-ERRO GREATER ZEROS */

            if (WORK.AUX_CONT_ERRO > 00)
            {

                /*" -2351- PERFORM M_0700_000_UPDATE_DB_UPDATE_1 */

                M_0700_000_UPDATE_DB_UPDATE_1();

                /*" -2353- ELSE */
            }
            else
            {


                /*" -2363- PERFORM M_0700_000_UPDATE_DB_UPDATE_2 */

                M_0700_000_UPDATE_DB_UPDATE_2();

                /*" -2366- END-IF */
            }


            /*" -2367- IF SQLCODE NOT = +0 AND +100 */

            if (!DB.SQLCODE.In("+0", "+100"))
            {

                /*" -2368- DISPLAY 'VG0120B - ERRO NA ATUALIZACAO DA V0RELATORIOS' */
                _.Display($"VG0120B - ERRO NA ATUALIZACAO DA V0RELATORIOS");

                /*" -2369- DISPLAY 'APOLICE   = ' RELAT-NUM-APOLICE */
                _.Display($"APOLICE   = {RELAT_NUM_APOLICE}");

                /*" -2370- DISPLAY 'SUB GRUPO = ' RELAT-COD-SUBES */
                _.Display($"SUB GRUPO = {RELAT_COD_SUBES}");

                /*" -2370- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0700-000-UPDATE-DB-UPDATE-1 */
        public void M_0700_000_UPDATE_DB_UPDATE_1()
        {
            /*" -2351- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '0' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'VG0120B' AND IDSISTEM = 'VG' AND SITUACAO = '0' AND NUM_APOLICE = :RELAT-NUM-APOLICE AND OPERACAO >= 1 AND OPERACAO <= 3 END-EXEC */

            var m_0700_000_UPDATE_DB_UPDATE_1_Update1 = new M_0700_000_UPDATE_DB_UPDATE_1_Update1()
            {
                RELAT_NUM_APOLICE = RELAT_NUM_APOLICE.ToString(),
            };

            M_0700_000_UPDATE_DB_UPDATE_1_Update1.Execute(m_0700_000_UPDATE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-9000-000-CLOSE-CURSOR-SECTION */
        private void M_9000_000_CLOSE_CURSOR_SECTION()
        {
            /*" -2376- MOVE '9000-000-CLOSE-CURSOR      ' TO PARAGRAFO. */
            _.Move("9000-000-CLOSE-CURSOR      ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2378- MOVE 'CLOSE.... CURSOR  RELATORIO        ' TO COMANDO. */
            _.Move("CLOSE.... CURSOR  RELATORIO        ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2379- PERFORM M_9000_000_CLOSE_CURSOR_DB_CLOSE_1 */

            M_9000_000_CLOSE_CURSOR_DB_CLOSE_1();

            /*" -2382- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2382- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-9000-000-CLOSE-CURSOR-DB-CLOSE-1 */
        public void M_9000_000_CLOSE_CURSOR_DB_CLOSE_1()
        {
            /*" -2379- EXEC SQL CLOSE RELATORIO END-EXEC. */

            RELATORIO.Close();

        }

        [StopWatch]
        /*" M-0700-000-UPDATE-DB-UPDATE-2 */
        public void M_0700_000_UPDATE_DB_UPDATE_2()
        {
            /*" -2363- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'VG0120B' AND IDSISTEM = 'VG' AND SITUACAO = '0' AND NUM_APOLICE = :RELAT-NUM-APOLICE AND OPERACAO >= 1 AND OPERACAO <= 3 END-EXEC */

            var m_0700_000_UPDATE_DB_UPDATE_2_Update1 = new M_0700_000_UPDATE_DB_UPDATE_2_Update1()
            {
                RELAT_NUM_APOLICE = RELAT_NUM_APOLICE.ToString(),
            };

            M_0700_000_UPDATE_DB_UPDATE_2_Update1.Execute(m_0700_000_UPDATE_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-9000-020-CLOSE-CURSOR-SEGURADO-SECTION */
        private void M_9000_020_CLOSE_CURSOR_SEGURADO_SECTION()
        {
            /*" -2388- MOVE '9000-000-CLOSE-CURSOR      ' TO PARAGRAFO. */
            _.Move("9000-000-CLOSE-CURSOR      ", WORK.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2390- MOVE 'CLOSE.... CURSOR  SEGURADO         ' TO COMANDO. */
            _.Move("CLOSE.... CURSOR  SEGURADO         ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2391- IF RELAT-OPERACAO NOT EQUAL 0001 */

            if (RELAT_OPERACAO != 0001)
            {

                /*" -2392- GO TO 9000-020-SALTA1. */

                M_9000_020_SALTA1(); //GOTO
                return;
            }


            /*" -2392- PERFORM M_9000_020_CLOSE_CURSOR_SEGURADO_DB_CLOSE_1 */

            M_9000_020_CLOSE_CURSOR_SEGURADO_DB_CLOSE_1();

            /*" -2394- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2394- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM M_9000_020_SALTA1 */

            M_9000_020_SALTA1();

        }

        [StopWatch]
        /*" M-9000-020-CLOSE-CURSOR-SEGURADO-DB-CLOSE-1 */
        public void M_9000_020_CLOSE_CURSOR_SEGURADO_DB_CLOSE_1()
        {
            /*" -2392- EXEC SQL CLOSE SEGURADO1 END-EXEC. */

            SEGURADO1.Close();

        }

        [StopWatch]
        /*" M-9000-020-SALTA1 */
        private void M_9000_020_SALTA1(bool isPerform = false)
        {
            /*" -2399- MOVE 'CLOSE.... CURSOR  SEGURADO2        ' TO COMANDO. */
            _.Move("CLOSE.... CURSOR  SEGURADO2        ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2400- IF RELAT-OPERACAO NOT EQUAL 0002 */

            if (RELAT_OPERACAO != 0002)
            {

                /*" -2401- GO TO 9000-020-SALTA2. */

                M_9000_020_SALTA2(); //GOTO
                return;
            }


            /*" -2401- PERFORM M_9000_020_SALTA1_DB_CLOSE_1 */

            M_9000_020_SALTA1_DB_CLOSE_1();

            /*" -2403- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2403- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-9000-020-SALTA1-DB-CLOSE-1 */
        public void M_9000_020_SALTA1_DB_CLOSE_1()
        {
            /*" -2401- EXEC SQL CLOSE SEGURADO2 END-EXEC. */

            SEGURADO2.Close();

        }

        [StopWatch]
        /*" M-9000-020-SALTA2 */
        private void M_9000_020_SALTA2(bool isPerform = false)
        {
            /*" -2408- MOVE 'CLOSE.... CURSOR  SEGURADO3        ' TO COMANDO. */
            _.Move("CLOSE.... CURSOR  SEGURADO3        ", WORK.LOCALIZA_ABEND_2.COMANDO);

            /*" -2409- IF RELAT-OPERACAO NOT EQUAL 0003 */

            if (RELAT_OPERACAO != 0003)
            {

                /*" -2410- GO TO 9000-020-SALTA3. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_020_SALTA3*/ //GOTO
                return;
            }


            /*" -2410- PERFORM M_9000_020_SALTA2_DB_CLOSE_1 */

            M_9000_020_SALTA2_DB_CLOSE_1();

            /*" -2412- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2412- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-9000-020-SALTA2-DB-CLOSE-1 */
        public void M_9000_020_SALTA2_DB_CLOSE_1()
        {
            /*" -2410- EXEC SQL CLOSE SEGURADO3 END-EXEC. */

            SEGURADO3.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_020_SALTA3*/

        [StopWatch]
        /*" M-9999-999-ERRO-SECTION */
        private void M_9999_999_ERRO_SECTION()
        {
            /*" -2421- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK.WABEND.WSQLCODE);

            /*" -2422- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK.WABEND.WSQLERRD1);

            /*" -2423- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK.WABEND.WSQLERRD2);

            /*" -2424- DISPLAY WABEND. */
            _.Display(WORK.WABEND);

            /*" -2425- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK.LOCALIZA_ABEND_1);

            /*" -2427- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK.LOCALIZA_ABEND_2);

            /*" -2427- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2429- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2432- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2432- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}