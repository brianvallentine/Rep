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
using Sias.VidaEmGrupo.DB2.VG0711S;

namespace Code
{
    public class VG0711S
    {
        public bool IsCall { get; set; }

        public VG0711S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    OBJETIVO DA SUBROTINA                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * - EVOLU��O DA SUBROTINA VG0710S PARA REALIZAR TODOS OS         *      */
        /*"      *   LEVANTAMENTOS DE CAPITAIS PUROS E CAPITAIS DE COBERTURAS     *      */
        /*"      *   BEM COM DIVISAO DO VALOR DE PREMIO EM PERCENTUAIS CONFORME   *      */
        /*"      *   CIRCULAR 491/SUSEP, QUANDO HOUVER. CASO CONTRARIO O PERCENT  *      */
        /*"      *   DE 100% SER� COLOCADO NA COBERTURA BASICA.                   *      */
        /*"      * - CALCULO DO VALOR DE IOF SOBRE O PREMIO, QUANDO HOUVER.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.19  * VERSAO  : 019                                                         */
        /*"      * MOTIVO  : VERIFICACAO VALOR DE CAPITAL SEGURADO DOBRADO PARA IPA      */
        /*"      * JAZZ    : 400349                                                      */
        /*"      * DATA    : 14.07.2022                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.19                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"JV118#*VERSAO 18: JV1 DEMANDA 262179 - KINKAS 28/10/2020               *      */
        /*"JV118#*           TROCA REFERENCIAS PRODUTOS JV1 POR JVPRDXXXX         *      */
        /*"JV118#*           - PROCURAR POR JV118                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV117 *VERSAO 17: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV117 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV117 *           - PROCURAR POR JV117                                 *      */
        /*"JV117 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - DEMANDA 192819                                   *      */
        /*"      *               RETIRAR V.14.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/03/2019 - CLAUDETE RADEL                   V.16        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - HISTORIA 164332                                  *      */
        /*"      *               FOI ACRESCENTADO UM UNION NO PARAGRAFO           *      */
        /*"      *               0210-LER-COBER-ACESSORIO ANALOGO A SPBSC091      *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/12/2018 - DANIEL MEDINA GOMIDE (MILLENIUM) V.15        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - HISTORIA 27351                                   *      */
        /*"      *               CORRIGIR CONFIGURA��O DO IEA AP�LICE 889         *      */
        /*"      *               SUBGRUPO 3603 (ATALHO 04 02 06)                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/11/2018 - MAURICIO CUNHA (MILLENIUM)       V.14        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - HISTORIA 163419                                  *      */
        /*"      *               ELEGIBILIDADE SEGURA PRECO - NOVEMBRO/2018       *      */
        /*"      *               RETIRADA DOS CODIGOS DE PRODUTOS DOS FILTROS DO  *      */
        /*"      *               CURSOR QUE GERA O ARQUIVO. A PARTIR DESTA VERSAO *      */
        /*"      *               O FILTRO SERA APENAS DE APOLICE E SUBGRUPO.      *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/11/2018 - RIBAMAR MARQUES (ALTRAN)         V.13        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - DEMANDA 164332 - ESTA VERSAO FOI DESFEITA        *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/10/2018 - DANIEL MEDINA GOMIDE (MILLENIUM) V.12        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - HISTORIA 163419                                  *      */
        /*"      *               ELEGIBILIDADE SEGURA PRECO - OUTUBRO/2018        *      */
        /*"      *               CORRECAO DE INCONSISTENCIAS ENCONTRADAS DURANTE  *      */
        /*"      *               A HOMOLOGACAO                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2018 - RIBAMAR MARQUES (ALTRAN)         V.11        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - HISTORIA 163419                                  *      */
        /*"      *               ELEGIBILIDADE SEGURA PRECO - OUTUBRO/2018        *      */
        /*"      *               IMPLEMENTACAO DE NOVAS REGRAS DE ELEGIBILIDADE   *      */
        /*"      *               PARA A ASSISTENCIA SEGURA PRECO                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/09/2018 - RIBAMAR MARQUES (ALTRAN)         V.10        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - HISTORIA 6341 - CORRECAO 27922                   *      */
        /*"      *             - CORRIGIR ERROS ENCONTRADOS DURANTE HOMOLOGACAO   *      */
        /*"      *               VIA PRODUCAO ASSISTIDA                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/05/2018 - RIBAMAR MARQUES (ALTRAN)         V.09        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - HISTORIA 6341                                    *      */
        /*"      *             - CORRIGIR ERROS ENCONTRADOS DURANTE HOMOLOGACAO   *      */
        /*"      *               VIA PRODUCAO ASSISTIDA                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2018 - RIBAMAR MARQUES (ALTRAN)         V.08        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - HISTORIA 13151                                   *      */
        /*"      *             - TORNAR O PRODUTO 9310 (VIDA EXCLUSIVO) ELEGIVEL  *      */
        /*"      *               PARA A ASSISTENCIA SEGURA PRE�O SEM LIMITACOES   *      */
        /*"      *               DE DATA OU DE PROFISSAO.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/04/2018 - RIBAMAR MARQUES (ALTRAN)         V.07        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - HISTORIA 13151                                   *      */
        /*"      *             - INCLUIR CBO ELEGIVEL (131 - ADVOGADO)            *      */
        /*"      *             - ESTABELECER NOVA DATA PARA ELEGIBILIDADE DA      *      */
        /*"      *               ASSISTENCIA SEGURA PRE�O                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/03/2018 - RIBAMAR MARQUES (ALTRAN)         V.06        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 157.319                                      *      */
        /*"      *             - ALTERACAO DO ESCOPO DA DEMANDA ANTERIOR (CADMUS  *      */
        /*"      *               154738) COM INCLUSAO DE APOLICES E SUBGRUPOS E   *      */
        /*"      *               INCLUSAO/ALTERACAO DE PROFISSOES (CBO'S)         *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/12/2017 - RIBAMAR MARQUES (ALTRAN)         V.05        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CAD 157.115                                      *      */
        /*"      *             - SELECIONAR MENSAGENS HINT APENAS PELO PRODUTO    *      */
        /*"      *               9301.                                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/12/2017 - ELIERMES OLIVEIRA                V.04        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CAD 154.738                                      *      */
        /*"      *             - ELEGIBILIDADE PARA A ASSISTENCIA SEGURA PRECO    *      */
        /*"      *               A PARTIR DE 01/12/2017, APENAS PRODUTOS E        *      */
        /*"      *               PROFISSOES ELEGIVEIS PARA A ASSISTENCIA SEGURA   *      */
        /*"      *               PRECO DEVERAO TER ESSA ASSISTENCIA LISTADA NAS   *      */
        /*"      *               CONSULTAS E RELATORIOS.                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2017 - RIBAMAR MARQUES (ALTRAN)         V.03        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CAD 153.772                                      *      */
        /*"      *             - ALTERAR CALCULO DE IEA CONFORME SOLICITADO       *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/08/2017 - ELIERMES OLIVEIRA                V.02        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 113.034                                      *      */
        /*"      *             - DIVISAO DE PREMIO POR PERCENTUAIS DE COBERTURA   *      */
        /*"      *               CONFORME CIRCULAR 491 DA SUSEP. CASO NAO HAJA    *      */
        /*"      *               CADASTRAMENTO, O PREMIO DEVE SER COLOCADO 100%   *      */
        /*"      *               NO RAMO PRINCIPAL DA APOLICE.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2015 - ELIERMES OLIVEIRA                V.01        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis WIDX1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WIDX { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77  W-TRACE                      PIC  X(003).*/
        public StringBasis W_TRACE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77  WS-SISTEMA-DTMOVABE          PIC  X(010).*/
        public StringBasis WS_SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  TAXA-VG                      PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"77  TAXA-AP-MORACID              PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"77  TAXA-AP-INVPERM              PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"77  TAXA-AP-AMDS                 PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"77  TAXA-AP-DH                   PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"77  TAXA-AP-DIT                  PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"77  GARAN-ADIC-IEA               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"77  GARAN-ADIC-IPA               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"77  GARAN-ADIC-IPD               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IPD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"77  GARAN-ADIC-HD                PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_HD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"77  WS-NUM-APOLICE-GAR           PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis WS_NUM_APOLICE_GAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77  WS-COD-SUBGRUPO-GAR          PIC S9(04)  USAGE COMP.*/
        public IntBasis WS_COD_SUBGRUPO_GAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WS-NUM-APOLICE               PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis WS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77  WS-COD-SUBGRUPO              PIC S9(04)  USAGE COMP.*/
        public IntBasis WS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WS-NUM-CERTIFICADO           PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis WS_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  PROPOVA-NUM-CERTIFICADO      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPOVA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  SEGVGAP-PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  PRODUVG-ORIG-PRODU           PIC X(10).*/
        public StringBasis PRODUVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WS-IDADE                     PIC S9(004)          COMP.*/
        public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-MAX-IDADE                 PIC S9(004)          COMP.*/
        public IntBasis WS_MAX_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-SALARIO                   PIC S9(013)V99       COMP-3.*/
        public DoubleBasis WS_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  PROPOVA-COD-PRODUTO          PIC S9(4) USAGE COMP.*/
        public IntBasis PROPOVA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  PRODUVG-COD-PRODUTO          PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WS-PRODUTO                   PIC S9(004)          COMP.*/
        public IntBasis WS_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-RAMO                      PIC S9(004)          COMP.*/
        public IntBasis WS_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-RAMO1                     PIC S9(004)          COMP.*/
        public IntBasis WS_RAMO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-RAMO2                     PIC S9(004)          COMP.*/
        public IntBasis WS_RAMO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-RAMO-TAB                  PIC S9(004)          COMP.*/
        public IntBasis WS_RAMO_TAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-COBERTURA                 PIC S9(004)          COMP.*/
        public IntBasis WS_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-MODALIDA                  PIC S9(004)          COMP.*/
        public IntBasis WS_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SEGURVGA-NUM-APOLICE         PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77  SEGURVGA-COD-SUBGRUPO        PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  SEGURVGA-NUM-ITEM            PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURVGA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77  SEGURVGA-OCORR-HISTORICO     PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  V0SUBG-IND-IOF               PIC X(001) VALUE SPACES.*/
        public StringBasis V0SUBG_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  WS-DISPLAY                   PIC X(003) VALUE SPACES.*/
        public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WS-IND                       PIC 9(006) VALUE ZEROS.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-VLR-COB-BASICA            PIC S9(013)V99       COMP-3.*/
        public DoubleBasis WS_VLR_COB_BASICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-VLR-COB-CONSULTA          PIC S9(013)V99       COMP-3.*/
        public DoubleBasis WS_VLR_COB_CONSULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-MAX-VLR-CONSULTA          PIC S9(013)V99       COMP-3.*/
        public DoubleBasis WS_MAX_VLR_CONSULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-TIPO-COB-GAR              PIC X(02) VALUE SPACES.*/
        public StringBasis WS_TIPO_COB_GAR { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"77  VGARANTI-TP-GARANTIA         PIC X(01) VALUE SPACES.*/
        public StringBasis VGARANTI_TP_GARANTIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  W88-PROD-VIDA-MULHER         PIC 9(004) VALUE ZEROS.*/
        public IntBasis W88_PROD_VIDA_MULHER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01 VG091-DES-COB-CARENCIA.*/
        public VG0711S_VG091_DES_COB_CARENCIA VG091_DES_COB_CARENCIA { get; set; } = new VG0711S_VG091_DES_COB_CARENCIA();
        public class VG0711S_VG091_DES_COB_CARENCIA : VarBasis
        {
            /*"   49 VG091-DES-COB-CARENCIA-LEN  PIC S9(4) USAGE COMP.*/
            public IntBasis VG091_DES_COB_CARENCIA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"   49 VG091-DES-COB-CARENCIA-TEXT PIC X(1000).*/
            public StringBasis VG091_DES_COB_CARENCIA_TEXT { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)."), @"");
            /*"01 VG091-DES-MSG-HINT.*/
        }
        public VG0711S_VG091_DES_MSG_HINT VG091_DES_MSG_HINT { get; set; } = new VG0711S_VG091_DES_MSG_HINT();
        public class VG0711S_VG091_DES_MSG_HINT : VarBasis
        {
            /*"   49 VG091-DES-MSG-HINT-LEN      PIC S9(4) USAGE COMP.*/
            public IntBasis VG091_DES_MSG_HINT_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"   49 VG091-DES-MSG-HINT-TEXT     PIC X(1000).*/
            public StringBasis VG091_DES_MSG_HINT_TEXT { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)."), @"");
            /*"01  WS-AREA-SEGURA-PRECO-AUX.*/
        }
        public VG0711S_WS_AREA_SEGURA_PRECO_AUX WS_AREA_SEGURA_PRECO_AUX { get; set; } = new VG0711S_WS_AREA_SEGURA_PRECO_AUX();
        public class VG0711S_WS_AREA_SEGURA_PRECO_AUX : VarBasis
        {
            /*"    05 WS-DATA-SEGURA-PRECO      PIC 9(008) VALUE 20181001.*/
            public IntBasis WS_DATA_SEGURA_PRECO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"), 20181001);
            /*"    05 WS-DATA-QUITACAO-DB2      PIC X(10)  VALUE SPACES.*/
            public StringBasis WS_DATA_QUITACAO_DB2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 FILLER REDEFINES WS-DATA-QUITACAO-DB2.*/
            private _REDEF_VG0711S_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VG0711S_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VG0711S_FILLER_0(); _.Move(WS_DATA_QUITACAO_DB2, _filler_0); VarBasis.RedefinePassValue(WS_DATA_QUITACAO_DB2, _filler_0, WS_DATA_QUITACAO_DB2); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_DATA_QUITACAO_DB2); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_DATA_QUITACAO_DB2); }
            }  //Redefines
            public class _REDEF_VG0711S_FILLER_0 : VarBasis
            {
                /*"       07 WS-ANO-DB2             PIC 9(004).*/
                public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       07 FILLER                 PIC X.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                /*"       07 WS-MES-DB2             PIC 9(002).*/
                public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       07 FILLER                 PIC X.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                /*"       07 WS-DIA-DB2             PIC 9(002).*/
                public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DATA-QUITACAO          PIC 9(008).*/

                public _REDEF_VG0711S_FILLER_0()
                {
                    WS_ANO_DB2.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_MES_DB2.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_DIA_DB2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_QUITACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 FILLER REDEFINES WS-DATA-QUITACAO.*/
            private _REDEF_VG0711S_FILLER_3 _filler_3 { get; set; }
            public _REDEF_VG0711S_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_VG0711S_FILLER_3(); _.Move(WS_DATA_QUITACAO, _filler_3); VarBasis.RedefinePassValue(WS_DATA_QUITACAO, _filler_3, WS_DATA_QUITACAO); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS_DATA_QUITACAO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WS_DATA_QUITACAO); }
            }  //Redefines
            public class _REDEF_VG0711S_FILLER_3 : VarBasis
            {
                /*"       07 WS-ANO-QTC             PIC 9(004).*/
                public IntBasis WS_ANO_QTC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       07 WS-MES-QTC             PIC 9(002).*/
                public IntBasis WS_MES_QTC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       07 WS-DIA-QTC             PIC 9(002).*/
                public IntBasis WS_DIA_QTC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-PROD-SEGURA-PRECO      PIC 9(004) VALUE ZEROS.*/

                public _REDEF_VG0711S_FILLER_3()
                {
                    WS_ANO_QTC.ValueChanged += OnValueChanged;
                    WS_MES_QTC.ValueChanged += OnValueChanged;
                    WS_DIA_QTC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_PROD_SEGURA_PRECO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 WS-CBO-SEGURA-PRECO       PIC 9(006) VALUE ZEROS.*/

            public SelectorBasis WS_CBO_SEGURA_PRECO { get; set; } = new SelectorBasis("006", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 W88-CBO-SEGURA-PRECO   VALUE 131 518729 395 214 212                                       213 922 205 201 982 295                                       921 981 994 203 211 293                                       297 296 298. */
							new SelectorItemBasis("W88_CBO_SEGURA_PRECO", "131 518729 395 214 212 213 922 205 201 982 295 921 981 994 203 211 293 297 296 298")
                }
            };

            /*"    05 WACHOU-CBO                PIC X(03)  VALUE SPACES.*/
            public StringBasis WACHOU_CBO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 WS-NUM-CERTIFICADO-AUX    PIC 9(015).*/
            public IntBasis WS_NUM_CERTIFICADO_AUX { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05 FILLER REDEFINES WS-NUM-CERTIFICADO-AUX.*/
            private _REDEF_VG0711S_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VG0711S_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VG0711S_FILLER_4(); _.Move(WS_NUM_CERTIFICADO_AUX, _filler_4); VarBasis.RedefinePassValue(WS_NUM_CERTIFICADO_AUX, _filler_4, WS_NUM_CERTIFICADO_AUX); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_NUM_CERTIFICADO_AUX); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WS_NUM_CERTIFICADO_AUX); }
            }  //Redefines
            public class _REDEF_VG0711S_FILLER_4 : VarBasis
            {
                /*"       07 WS-NRCERTIF            OCCURS 15 TIMES PIC 9(001).*/
                public ListBasis<IntBasis, Int64> WS_NRCERTIF { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 15);
                /*"    05 WS-NUM-CERTIFICADO-ALFA   PIC X(015).*/

                public _REDEF_VG0711S_FILLER_4()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_NUM_CERTIFICADO_ALFA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05 WS-DATA-INI-SEGPRECO      PIC 9(008) VALUE 20121126.*/
            public IntBasis WS_DATA_INI_SEGPRECO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"), 20121126);
            /*"    05 WS-FLAG-SEGPRECO          PIC 9      VALUE 0.*/

            public SelectorBasis WS_FLAG_SEGPRECO { get; set; } = new SelectorBasis("9", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-SEGURA-PRECO       VALUE 1. */
							new SelectorItemBasis("TEM_SEGURA_PRECO", "1")
                }
            };

            /*"01  WS-COBERTURA-OLD             PIC  9(003).*/
        }
        public IntBasis WS_COBERTURA_OLD { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01  WS-COBERTURA-491             PIC  9(003).*/
        public IntBasis WS_COBERTURA_491 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01  WS-COD-COBER-BAS-491         PIC  9(002).*/
        public IntBasis WS_COD_COBER_BAS_491 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01  WS-TIPO-COBERTURA            PIC  X(001).*/
        public StringBasis WS_TIPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WS-VLR-CAP-COBER             PIC  9(013)V99.*/
        public DoubleBasis WS_VLR_CAP_COBER { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"01  WS-QTD-PERCOBER              PIC 9(003) VALUE ZEROS.*/
        public IntBasis WS_QTD_PERCOBER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-COBER-DESC                PIC X(070) VALUE SPACES.*/
        public StringBasis WS_COBER_DESC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"01  WS-FIM-CURSOR                PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FIM_CURSOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FIM-TAB                   PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FIM_TAB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TAB491               PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TAB491 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WFIM-COBER                   PIC X(001) VALUE 'N'.*/
        public StringBasis WFIM_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WFIM-CAREN                   PIC X(001) VALUE 'N'.*/
        public StringBasis WFIM_CAREN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-NUM-FAIXA-INICIAL         PIC  9(003).*/
        public IntBasis WS_NUM_FAIXA_INICIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01  WS-NUM-FAIXA-FINAL           PIC  9(003).*/
        public IntBasis WS_NUM_FAIXA_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01  WS-VLR-FAIXA-CS-INICIAL      PIC  9(013)V99.*/
        public DoubleBasis WS_VLR_FAIXA_CS_INICIAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"01  WS-VLR-FAIXA-CS-FINAL        PIC  9(013)V99.*/
        public DoubleBasis WS_VLR_FAIXA_CS_FINAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"01  WS-PCT-COB-PREMIO            PIC  9(003)V99999.*/
        public DoubleBasis WS_PCT_COB_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99999."), 5);
        /*"01  WS-VLR-CAP-SEGURADO          PIC  9(010)V99.*/
        public DoubleBasis WS_VLR_CAP_SEGURADO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
        /*"01  WS-VLR-PCT-PREMIO            PIC  9(010)V99.*/
        public DoubleBasis WS_VLR_PCT_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
        /*"01  WS-VLR-PREMIO-TOT            PIC S9(010)V99.*/
        public DoubleBasis WS_VLR_PREMIO_TOT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V99."), 2);
        /*"01  WS-VLR-PREMIO-RESTO          PIC S9(010)V99.*/
        public DoubleBasis WS_VLR_PREMIO_RESTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V99."), 2);
        /*"01  WS-NUM-COB-CARENCIA          PIC  9(002).*/
        public IntBasis WS_NUM_COB_CARENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01  WS-CONTA-COB-CARENCIA        PIC  9(002).*/
        public IntBasis WS_CONTA_COB_CARENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01  WS-CONTA-MSG-HINT            PIC  9(002).*/
        public IntBasis WS_CONTA_MSG_HINT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01  WS-DES-COB-CARENCIA          PIC  X(250).*/
        public StringBasis WS_DES_COB_CARENCIA { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01  WS-DES-MSG-HINT              PIC  X(800).*/
        public StringBasis WS_DES_MSG_HINT { get; set; } = new StringBasis(new PIC("X", "800", "X(800)."), @"");
        /*"01  WS-NOM-GRUPO-COBERTURA       PIC  X(050).*/
        public StringBasis WS_NOM_GRUPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"01  WS-DES-GARANTIA-491          PIC  X(070).*/
        public StringBasis WS_DES_GARANTIA_491 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01  WS-I                         PIC  9(02).*/
        public IntBasis WS_I { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
        /*"01  WS-I-ULT                     PIC  9(02).*/
        public IntBasis WS_I_ULT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
        /*"01  WS-IND-J                     PIC  9(02).*/
        public IntBasis WS_IND_J { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
        /*"01  WS-IND-K                     PIC  9(02).*/
        public IntBasis WS_IND_K { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
        /*"01  WS-IND-L                     PIC  9(02).*/
        public IntBasis WS_IND_L { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
        /*"01  WSORT-COB-PREMIO.*/
        public VG0711S_WSORT_COB_PREMIO WSORT_COB_PREMIO { get; set; } = new VG0711S_WSORT_COB_PREMIO();
        public class VG0711S_WSORT_COB_PREMIO : VarBasis
        {
            /*"    10 WSORT-TIPO-GARANTIA          PIC  X(001).*/
            public StringBasis WSORT_TIPO_GARANTIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WSORT-NOM-GRUPO-COBERTURA    PIC  X(050).*/
            public StringBasis WSORT_NOM_GRUPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"    10 WSORT-NUM-GARANTIA           PIC  9(003).*/
            public IntBasis WSORT_NUM_GARANTIA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10 WSORT-NUM-GARANTIA-491       PIC  9(003).*/
            public IntBasis WSORT_NUM_GARANTIA_491 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10 WSORT-DES-GARANTIA           PIC  X(045).*/
            public StringBasis WSORT_DES_GARANTIA { get; set; } = new StringBasis(new PIC("X", "45", "X(045)."), @"");
            /*"    10 WSORT-NUM-FAIXA-INICIAL      PIC  9(003).*/
            public IntBasis WSORT_NUM_FAIXA_INICIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10 WSORT-NUM-FAIXA-FINAL        PIC  9(003).*/
            public IntBasis WSORT_NUM_FAIXA_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10 WSORT-VLR-FAIXA-CS-INICIAL   PIC  9(013)V99.*/
            public DoubleBasis WSORT_VLR_FAIXA_CS_INICIAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10 WSORT-VLR-FAIXA-CS-FINAL     PIC  9(013)V99.*/
            public DoubleBasis WSORT_VLR_FAIXA_CS_FINAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10 WSORT-PCT-COB-PREMIO         PIC  9(003)V99999.*/
            public DoubleBasis WSORT_PCT_COB_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99999."), 5);
            /*"    10 WSORT-VLR-CAP-SEGURADO       PIC  9(010)V99.*/
            public DoubleBasis WSORT_VLR_CAP_SEGURADO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"    10 WSORT-VLR-CAP-DESC           PIC  X(013).*/
            public StringBasis WSORT_VLR_CAP_DESC { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"    10 WSORT-VLR-PCT-PREMIO         PIC  9(010)V99.*/
            public DoubleBasis WSORT_VLR_PCT_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"    10 WSORT-NUM-COB-CARENCIA       PIC  9(002).*/
            public IntBasis WSORT_NUM_COB_CARENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10 WSORT-DES-COB-CARENCIA       PIC  X(250).*/
            public StringBasis WSORT_DES_COB_CARENCIA { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
            /*"01  FILLER.*/
        }
        public VG0711S_FILLER_5 FILLER_5 { get; set; } = new VG0711S_FILLER_5();
        public class VG0711S_FILLER_5 : VarBasis
        {
            /*"  05 WS-VALORES-AX.*/
            public VG0711S_WS_VALORES_AX WS_VALORES_AX { get; set; } = new VG0711S_WS_VALORES_AX();
            public class VG0711S_WS_VALORES_AX : VarBasis
            {
                /*"     10 WS-VALOR-9                   PIC S9(013)V99   COMP-3.*/
                public DoubleBasis WS_VALOR_9 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"     10 WS-VALOR-INT                 PIC Z9.*/
                public IntBasis WS_VALOR_INT { get; set; } = new IntBasis(new PIC("9", "2", "Z9."));
                /*"     10 WS-VALOR-INT-X               PIC X(13).*/
                public StringBasis WS_VALOR_INT_X { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
                /*"     10 WS-VALOR                     PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"     10 WS-VALOR-1                   PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis WS_VALOR_1 { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    05 TABELA-COBER-BASICA.*/
                public VG0711S_TABELA_COBER_BASICA TABELA_COBER_BASICA { get; set; } = new VG0711S_TABELA_COBER_BASICA();
                public class VG0711S_TABELA_COBER_BASICA : VarBasis
                {
                    /*"       10 FILLER PIC X(075) VALUE       'B931101MORTE POR CAUSAS NATURAIS E ACIDENTAIS         '.*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B931101MORTE POR CAUSAS NATURAIS E ACIDENTAIS         ");
                    /*"       10 FILLER PIC X(075) VALUE       'B930102INDENIZA��O ESPECIAL POR MORTE ACIDENTAL       '.*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B930102INDENIZA��O ESPECIAL POR MORTE ACIDENTAL       ");
                    /*"       10 FILLER PIC X(075) VALUE       'B820116MORTE POR CAUSAS ACIDENTAIS                    '.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B820116MORTE POR CAUSAS ACIDENTAIS                    ");
                    /*"       10 FILLER PIC X(075) VALUE       'B820225INVALIDEZ PERMANENTE ACIDENTE (AT�)            '.*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B820225INVALIDEZ PERMANENTE ACIDENTE (AT�)            ");
                    /*"       10 FILLER PIC X(075) VALUE       'B822525INVALIDEZ PERMANENTE POR DOEN�A                '.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B822525INVALIDEZ PERMANENTE POR DOEN�A                ");
                    /*"       10 FILLER PIC X(075) VALUE       'B820300ASSIST�NCIA M�DICA                             '.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B820300ASSIST�NCIA M�DICA                             ");
                    /*"       10 FILLER PIC X(075) VALUE       'B820400DI�RIA HOSPITALAR                              '.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B820400DI�RIA HOSPITALAR                              ");
                    /*"       10 FILLER PIC X(075) VALUE       'B820535DI�RIA INCAPACIDADE TEMPOR�RIA                 '.*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B820535DI�RIA INCAPACIDADE TEMPOR�RIA                 ");
                    /*"       10 FILLER PIC X(075) VALUE       'A825600ADIANTAMENTO DOEN�A GRAVE                      '.*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A825600ADIANTAMENTO DOEN�A GRAVE                      ");
                    /*"       10 FILLER PIC X(075) VALUE       'A823305MORTE ACIDENTAL DO C�NJUGE/COMPANHEIRO(A)      '.*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A823305MORTE ACIDENTAL DO C�NJUGE/COMPANHEIRO(A)      ");
                    /*"       10 FILLER PIC X(075) VALUE       'A823422MORTE DO FILHO                                 '.*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A823422MORTE DO FILHO                                 ");
                    /*"       10 FILLER PIC X(075) VALUE       'A820206SERVICO DE ASSIST�NCIA FUNERAL                 '.*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A820206SERVICO DE ASSIST�NCIA FUNERAL                 ");
                    /*"       10 FILLER PIC X(075) VALUE       'A820507AUX�LIO ALIMENTA��O                            '.*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A820507AUX�LIO ALIMENTA��O                            ");
                    /*"       10 FILLER PIC X(075) VALUE       'A820115COBERTURA DE DOEN�AS GRAVES - CDG              '.*/
                    public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A820115COBERTURA DE DOEN�AS GRAVES - CDG              ");
                    /*"       10 FILLER PIC X(075) VALUE       'A821420REMISS�O PARA DIAGN�STICO DE C�NCER            '.*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A821420REMISS�O PARA DIAGN�STICO DE C�NCER            ");
                    /*"       10 FILLER PIC X(075) VALUE       'A821021REMISS�O PARA DESEMPREGO INVOLUNT�RIO          '.*/
                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A821021REMISS�O PARA DESEMPREGO INVOLUNT�RIO          ");
                    /*"       10 FILLER PIC X(075) VALUE       'A821523REMISS�O DE PAGAMENTO DE PR�MIOS POR INDENIZA��O D       'E CDGCA'.*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A821523REMISS�O DE PAGAMENTO DE PR�MIOS POR INDENIZA��O D       ");
                    /*"       10 FILLER PIC X(075) VALUE       'A821119DIAGN�STICO DE C�NCER DE MAMA, �TERO E OV�RIO  '.*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A821119DIAGN�STICO DE C�NCER DE MAMA, �TERO E OV�RIO  ");
                    /*"       10 FILLER PIC X(075) VALUE       'B822218COBERTURA DE DOEN�AS CR�NICAS GRAVES EM EST�GIO AV       'AN�ADO'.*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"B822218COBERTURA DE DOEN�AS CR�NICAS GRAVES EM EST�GIO AV       ");
                    /*"       10 FILLER PIC X(075) VALUE       'A820282INVALIDEZ PERMANENTE TOTAL OU PARCIAL POR ACIDENTE       ' (AT�)'.*/
                    public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A820282INVALIDEZ PERMANENTE TOTAL OU PARCIAL POR ACIDENTE       ");
                    /*"       10 FILLER PIC X(075) VALUE       'A828282INVALIDEZ FUNCIONAL PERMANENTE TOTAL POR DOEN�A'.*/
                    public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A828282INVALIDEZ FUNCIONAL PERMANENTE TOTAL POR DOEN�A");
                    /*"       10 FILLER PIC X(075) VALUE       'A828282PAGAMENTO ANTECIPADO ESPECIAL EM CONSEQU�NCIA DE D       'OEN�A PROFISSIONAL'.*/
                    public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A828282PAGAMENTO ANTECIPADO ESPECIAL EM CONSEQU�NCIA DE D       ");
                    /*"       10 FILLER PIC X(075) VALUE       'A828282INCLUSAO AUTOM�TICA C�NJUGE POR ACIDENTE'.*/
                    public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A828282INCLUSAO AUTOM�TICA C�NJUGE POR ACIDENTE");
                    /*"       10 FILLER PIC X(075) VALUE       'A828282INCLUSAO FACULTATIVA C�NJUGE POR ACIDENTE'.*/
                    public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A828282INCLUSAO FACULTATIVA C�NJUGE POR ACIDENTE");
                    /*"       10 FILLER PIC X(075) VALUE       'A828282INCLUSAO C�NJUGE/COMPANHEIRO SOBREVIVENTE POR ACID       'ENTE'.*/
                    public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A828282INCLUSAO C�NJUGE/COMPANHEIRO SOBREVIVENTE POR ACID       ");
                    /*"       10 FILLER PIC X(075) VALUE       'A828282MORTE DO C�NJUGE/COMPANHEIRO(A)'.*/
                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"A828282MORTE DO C�NJUGE/COMPANHEIRO(A)");
                    /*"    05 TAB-AUX REDEFINES TABELA-COBER-BASICA.*/
                }
                private _REDEF_VG0711S_TAB_AUX _tab_aux { get; set; }
                public _REDEF_VG0711S_TAB_AUX TAB_AUX
                {
                    get { _tab_aux = new _REDEF_VG0711S_TAB_AUX(); _.Move(TABELA_COBER_BASICA, _tab_aux); VarBasis.RedefinePassValue(TABELA_COBER_BASICA, _tab_aux, TABELA_COBER_BASICA); _tab_aux.ValueChanged += () => { _.Move(_tab_aux, TABELA_COBER_BASICA); }; return _tab_aux; }
                    set { VarBasis.RedefinePassValue(value, _tab_aux, TABELA_COBER_BASICA); }
                }  //Redefines
                public class _REDEF_VG0711S_TAB_AUX : VarBasis
                {
                    /*"       10 TAB-COBER-BASICA OCCURS 26 INDEXED BY WIDX1.*/
                    public ListBasis<VG0711S_TAB_COBER_BASICA> TAB_COBER_BASICA { get; set; } = new ListBasis<VG0711S_TAB_COBER_BASICA>(26);
                    public class VG0711S_TAB_COBER_BASICA : VarBasis
                    {
                        /*"        15  TAB-TP-COBER             PIC  X(001).*/
                        public StringBasis TAB_TP_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15  TAB-RAMO-COBER           PIC  9(002).*/
                        public IntBasis TAB_RAMO_COBER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        15  TAB-COBER-OLD            PIC  9(002).*/
                        public IntBasis TAB_COBER_OLD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        15  TAB-COBER-491            PIC  9(002).*/
                        public IntBasis TAB_COBER_491 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        15  TAB-DES-COBER            PIC  X(068).*/
                        public StringBasis TAB_DES_COBER { get; set; } = new StringBasis(new PIC("X", "68", "X(068)."), @"");
                        /*"    05 WTAB-COB-PREMIO OCCURS 13 INDEXED BY WIDX.*/

                        public VG0711S_TAB_COBER_BASICA()
                        {
                            TAB_TP_COBER.ValueChanged += OnValueChanged;
                            TAB_RAMO_COBER.ValueChanged += OnValueChanged;
                            TAB_COBER_OLD.ValueChanged += OnValueChanged;
                            TAB_COBER_491.ValueChanged += OnValueChanged;
                            TAB_DES_COBER.ValueChanged += OnValueChanged;
                        }

                    }

                    public _REDEF_VG0711S_TAB_AUX()
                    {
                        TAB_COBER_BASICA.ValueChanged += OnValueChanged;
                    }

                }
                public ListBasis<VG0711S_WTAB_COB_PREMIO> WTAB_COB_PREMIO { get; set; } = new ListBasis<VG0711S_WTAB_COB_PREMIO>(13);
                public class VG0711S_WTAB_COB_PREMIO : VarBasis
                {
                    /*"       10 WTAB-TIPO-GARANTIA           PIC  X(001).*/
                    public StringBasis WTAB_TIPO_GARANTIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"       10 WTAB-NOM-GRUPO-COBERTURA     PIC  X(050).*/
                    public StringBasis WTAB_NOM_GRUPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                    /*"       10 WTAB-NUM-GARANTIA            PIC  9(003).*/
                    public IntBasis WTAB_NUM_GARANTIA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"       10 WTAB-NUM-GARANTIA-491        PIC  9(003).*/
                    public IntBasis WTAB_NUM_GARANTIA_491 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"       10 WTAB-DES-GARANTIA            PIC  X(070).*/
                    public StringBasis WTAB_DES_GARANTIA { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                    /*"       10 WTAB-NUM-FAIXA-INICIAL       PIC  9(003).*/
                    public IntBasis WTAB_NUM_FAIXA_INICIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"       10 WTAB-NUM-FAIXA-FINAL         PIC  9(003).*/
                    public IntBasis WTAB_NUM_FAIXA_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"       10 WTAB-VLR-FAIXA-CS-INICIAL    PIC  9(013)V99.*/
                    public DoubleBasis WTAB_VLR_FAIXA_CS_INICIAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"       10 WTAB-VLR-FAIXA-CS-FINAL      PIC  9(013)V99.*/
                    public DoubleBasis WTAB_VLR_FAIXA_CS_FINAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"       10 WTAB-PCT-COB-PREMIO          PIC  9(003)V99999.*/
                    public DoubleBasis WTAB_PCT_COB_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99999."), 5);
                    /*"       10 WTAB-VLR-CAP-SEGURADO        PIC  9(010)V99.*/
                    public DoubleBasis WTAB_VLR_CAP_SEGURADO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                    /*"       10 WTAB-VLR-CAP-DESC            PIC  X(013).*/
                    public StringBasis WTAB_VLR_CAP_DESC { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                    /*"       10 WTAB-VLR-PCT-PREMIO          PIC  9(010)V99.*/
                    public DoubleBasis WTAB_VLR_PCT_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                    /*"       10 WTAB-NUM-COB-CARENCIA        PIC  9(002).*/
                    public IntBasis WTAB_NUM_COB_CARENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10 WTAB-DES-COB-CARENCIA        PIC  X(200).*/
                    public StringBasis WTAB_DES_COB_CARENCIA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
                    /*"       10 WTAB-DES-MSG-HINT            PIC  X(800).*/
                    public StringBasis WTAB_DES_MSG_HINT { get; set; } = new StringBasis(new PIC("X", "800", "X(800)."), @"");
                    /*"    05 FLAG-CALCULA-PREMIO       PIC  X VALUE 'S'.*/
                }

                public SelectorBasis FLAG_CALCULA_PREMIO { get; set; } = new SelectorBasis("X", "S")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CALCULA-PREMIOS        VALUE 'S'. */
							new SelectorItemBasis("CALCULA_PREMIOS", "S")
                }
                };

                /*"    05 DATA-SQL.*/
                public VG0711S_DATA_SQL DATA_SQL { get; set; } = new VG0711S_DATA_SQL();
                public class VG0711S_DATA_SQL : VarBasis
                {
                    /*"       10 ANO                    PIC  9(004).*/
                    public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       10 FILLER                 PIC  X(001) VALUE '-'.*/
                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"       10 MES                    PIC  9(002).*/
                    public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10 FILLER                 PIC  X(001) VALUE '-'.*/
                    public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"       10 DIA                    PIC  9(002).*/
                    public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05 DATA-SISTEMA.*/
                }
                public VG0711S_DATA_SISTEMA DATA_SISTEMA { get; set; } = new VG0711S_DATA_SISTEMA();
                public class VG0711S_DATA_SISTEMA : VarBasis
                {
                    /*"       10 ANO                    PIC  9(004).*/
                    public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       10 MES                    PIC  9(002).*/
                    public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10 DIA                    PIC  9(002).*/
                    public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05 DATA-NORMAL               PIC  9(008).*/
                }
                public IntBasis DATA_NORMAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 DATA-DDMMAA REDEFINES DATA-NORMAL.*/
                private _REDEF_VG0711S_DATA_DDMMAA _data_ddmmaa { get; set; }
                public _REDEF_VG0711S_DATA_DDMMAA DATA_DDMMAA
                {
                    get { _data_ddmmaa = new _REDEF_VG0711S_DATA_DDMMAA(); _.Move(DATA_NORMAL, _data_ddmmaa); VarBasis.RedefinePassValue(DATA_NORMAL, _data_ddmmaa, DATA_NORMAL); _data_ddmmaa.ValueChanged += () => { _.Move(_data_ddmmaa, DATA_NORMAL); }; return _data_ddmmaa; }
                    set { VarBasis.RedefinePassValue(value, _data_ddmmaa, DATA_NORMAL); }
                }  //Redefines
                public class _REDEF_VG0711S_DATA_DDMMAA : VarBasis
                {
                    /*"       10 DIA                    PIC  9(002).*/
                    public IntBasis DIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10 MES                    PIC  9(002).*/
                    public IntBasis MES_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10 ANO                    PIC  9(004).*/
                    public IntBasis ANO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05 DATA-INVERTIDA            PIC  9(008).*/

                    public _REDEF_VG0711S_DATA_DDMMAA()
                    {
                        DIA_1.ValueChanged += OnValueChanged;
                        MES_1.ValueChanged += OnValueChanged;
                        ANO_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DATA_INVERTIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 DATA-AAMMDD REDEFINES DATA-INVERTIDA.*/
                private _REDEF_VG0711S_DATA_AAMMDD _data_aammdd { get; set; }
                public _REDEF_VG0711S_DATA_AAMMDD DATA_AAMMDD
                {
                    get { _data_aammdd = new _REDEF_VG0711S_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                    set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
                }  //Redefines
                public class _REDEF_VG0711S_DATA_AAMMDD : VarBasis
                {
                    /*"       10 ANO                    PIC  9(004).*/
                    public IntBasis ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       10 MES                    PIC  9(002).*/
                    public IntBasis MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10 DIA                    PIC  9(002).*/
                    public IntBasis DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05 AUX-PREM-MORTE-ACIDENTAL   PIC S9(013)V99 COMP-3 VALUE 0.*/

                    public _REDEF_VG0711S_DATA_AAMMDD()
                    {
                        ANO_2.ValueChanged += OnValueChanged;
                        MES_2.ValueChanged += OnValueChanged;
                        DIA_2.ValueChanged += OnValueChanged;
                    }

                }
                public DoubleBasis AUX_PREM_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    05 AUX-PREM-INV-PERMANENTE    PIC S9(013)V99 COMP-3 VALUE 0.*/
                public DoubleBasis AUX_PREM_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    05 AUX-PREM-ASS-MEDICA        PIC S9(013)V99 COMP-3 VALUE 0.*/
                public DoubleBasis AUX_PREM_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    05 AUX-PREM-DIARIA-HOSPITALAR PIC S9(013)V99 COMP-3 VALUE 0.*/
                public DoubleBasis AUX_PREM_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    05 AUX-PREM-DIARIA-INTERNACAO PIC S9(013)V99 COMP-3 VALUE 0.*/
                public DoubleBasis AUX_PREM_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    05 WS-IMP-ADIANT-CDG          PIC S9(13)V99 COMP-3.*/
                public DoubleBasis WS_IMP_ADIANT_CDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 WS-IMP-SEGURADA-AP         PIC S9(13)V99 COMP-3.*/
                public DoubleBasis WS_IMP_SEGURADA_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 WS-IMP-SEGURADA-DIT        PIC S9(13)V99 COMP-3.*/
                public DoubleBasis WS_IMP_SEGURADA_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-IMP-SEGURADA-VG   PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_IMP_SEGURADA_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-IMP-SEGURADA-AP   PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_IMP_SEGURADA_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-IMP-SEGURADA-IP   PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_IMP_SEGURADA_IP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-IMP-SEGURADA-IPA  PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_IMP_SEGURADA_IPA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-IMP-SEGURADA-AMDS PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_IMP_SEGURADA_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-IMP-SEGURADA-DH   PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_IMP_SEGURADA_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-IMP-SEGURADA-DIT  PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_IMP_SEGURADA_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-PRM-TARIFARIO-VG  PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_PRM_TARIFARIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    05 APOLICOB-PRM-TARIFARIO-AP  PIC S9(13)V99 COMP-3.*/
                public DoubleBasis APOLICOB_PRM_TARIFARIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"01  PARAMETROS.*/
            }
        }
        public VG0711S_PARAMETROS PARAMETROS { get; set; } = new VG0711S_PARAMETROS();
        public class VG0711S_PARAMETROS : VarBasis
        {
            /*"    05 LK-NUM-APOLICE                PIC S9(013)V COMP-3.*/
            public DoubleBasis LK_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 0);
            /*"    05 LK-SUBGRUPO                   PIC S9(004)  COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-CERTIFICADO                PIC S9(015)V COMP-3.*/
            public DoubleBasis LK_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
            /*"    05 LK-IDADE                      PIC S9(004)  COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public VG0711S_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG0711S_LK_NASCIMENTO();
            public class VG0711S_LK_NASCIMENTO : VarBasis
            {
                /*"       10 LK-DATA-NASCIMENTO         PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 LK-SALARIO                    PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-VLR-PREMIO                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-DT-QUITACAO                PIC  X(010).*/
            public StringBasis LK_DT_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 LK-COBT-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-POR-ACIDENTE      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-IMP-CONJUGE           PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_IMP_CONJUGE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-IMP-FILHO             PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_IMP_FILHO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-IMP-CDG               PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_IMP_CDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-ACIDENTES-PESSOAIS    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-TOTAL                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-IOF-PREMIO                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_IOF_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-QTD-OCORR                  PIC  9(002).*/
            public IntBasis LK_QTD_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 LK-TAB-COB-PREMIO OCCURS 13 TIMES.*/
            public ListBasis<VG0711S_LK_TAB_COB_PREMIO> LK_TAB_COB_PREMIO { get; set; } = new ListBasis<VG0711S_LK_TAB_COB_PREMIO>(13);
            public class VG0711S_LK_TAB_COB_PREMIO : VarBasis
            {
                /*"       10 LK-NOM-GRUPO-COBERTURA     PIC  X(050).*/
                public StringBasis LK_NOM_GRUPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"       10 LK-NUM-GARANTIA            PIC  9(003).*/
                public IntBasis LK_NUM_GARANTIA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 LK-NUM-GARANTIA-491        PIC  9(003).*/
                public IntBasis LK_NUM_GARANTIA_491 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 LK-DES-GARANTIA            PIC  X(070).*/
                public StringBasis LK_DES_GARANTIA { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                /*"       10 LK-NUM-FAIXA-INICIAL       PIC  9(003).*/
                public IntBasis LK_NUM_FAIXA_INICIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 LK-NUM-FAIXA-FINAL         PIC  9(003).*/
                public IntBasis LK_NUM_FAIXA_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 LK-VLR-FAIXA-CS-INICIAL    PIC S9(013)V99 COMP-3.*/
                public DoubleBasis LK_VLR_FAIXA_CS_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"       10 LK-VLR-FAIXA-CS-FINAL      PIC S9(013)V99 COMP-3.*/
                public DoubleBasis LK_VLR_FAIXA_CS_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"       10 LK-PCT-COB-PREMIO          PIC S9(003)V99999 COMP-3.*/
                public DoubleBasis LK_PCT_COB_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99999"), 5);
                /*"       10 LK-VLR-CAP-SEGURADO        PIC S9(013)V99 COMP-3.*/
                public DoubleBasis LK_VLR_CAP_SEGURADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"       10 LK-VLR-CAP-DESC            PIC  X(013).*/
                public StringBasis LK_VLR_CAP_DESC { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"       10 LK-VLR-PCT-PREMIO          PIC S9(013)V99 COMP-3.*/
                public DoubleBasis LK_VLR_PCT_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"       10 LK-NUM-COB-CARENCIA        PIC  9(002).*/
                public IntBasis LK_NUM_COB_CARENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 LK-DES-COB-CARENCIA        PIC  X(200).*/
                public StringBasis LK_DES_COB_CARENCIA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
                /*"       10 LK-DES-MSG-HINT            PIC  X(800).*/
                public StringBasis LK_DES_MSG_HINT { get; set; } = new StringBasis(new PIC("X", "800", "X(800)."), @"");
                /*"    05 LK-RETURN-CODE                PIC S9(03) COMP-3.*/
            }
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    05 LK-MENSAGEM                   PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
        }


        public Dclgens.PESSOFIS PESSOFIS { get; set; } = new Dclgens.PESSOFIS();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.FAIXAETA FAIXAETA { get; set; } = new Dclgens.FAIXAETA();
        public Dclgens.FAIXASAL FAIXASAL { get; set; } = new Dclgens.FAIXASAL();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.VG033 VG033 { get; set; } = new Dclgens.VG033();
        public Dclgens.VG091 VG091 { get; set; } = new Dclgens.VG091();
        public Dclgens.VG088 VG088 { get; set; } = new Dclgens.VG088();
        public Dclgens.VG085 VG085 { get; set; } = new Dclgens.VG085();
        public Dclgens.VG086 VG086 { get; set; } = new Dclgens.VG086();
        public Dclgens.VG087 VG087 { get; set; } = new Dclgens.VG087();
        public Dclgens.VG094 VG094 { get; set; } = new Dclgens.VG094();
        public Dclgens.VGARANTI VGARANTI { get; set; } = new Dclgens.VGARANTI();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VG0711S_COBER COBER { get; set; } = new VG0711S_COBER();
        public VG0711S_COBER491 COBER491 { get; set; } = new VG0711S_COBER491();
        public VG0711S_CAREN491 CAREN491 { get; set; } = new VG0711S_CAREN491();
        public VG0711S_CHINT491 CHINT491 { get; set; } = new VG0711S_CHINT491();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VG0711S_PARAMETROS VG0711S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*PARAMETROS*/
        {
            try
            {
                this.PARAMETROS = VG0711S_PARAMETROS_P;

                /*" -569- MOVE LK-MENSAGEM TO W-TRACE */
                _.Move(PARAMETROS.LK_MENSAGEM, W_TRACE);

                /*" -570- IF W-TRACE = 'SIM' */

                if (W_TRACE == "SIM")
                {

                    /*" -571- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -573- DISPLAY '------------------------------------------------' '------------------------------------------------' */
                    _.Display($"------------------------------------------------------------------------------------------------");

                    /*" -581- DISPLAY 'PROGRAMA VG0711S - ' 'VERSAO V.019 - DEMANDA 400349 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

                    $"PROGRAMA VG0711S - VERSAO V.019 - DEMANDA 400349 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
                    .Display();

                    /*" -583- DISPLAY '------------------------------------------------' '------------------------------------------------' */
                    _.Display($"------------------------------------------------------------------------------------------------");

                    /*" -584- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -586- END-IF */
                }


                /*" -588- MOVE 'S' TO FLAG-CALCULA-PREMIO. */
                _.Move("S", FILLER_5.WS_VALORES_AX.FLAG_CALCULA_PREMIO);

                /*" -589- MOVE ZEROS TO WS-I */
                _.Move(0, WS_I);

                /*" -590- SET WIDX TO +1. */
                WIDX.Value = +1;

                /*" -592- SET WIDX1 TO +1. */
                WIDX1.Value = +1;

                /*" -625- INITIALIZE LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-COBT-IMP-CONJUGE LK-COBT-IMP-FILHO LK-COBT-IMP-CDG LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-IOF-PREMIO LK-QTD-OCORR LK-RETURN-CODE LK-MENSAGEM APOLICOB-IMP-SEGURADA-VG APOLICOB-IMP-SEGURADA-AP APOLICOB-IMP-SEGURADA-IP APOLICOB-IMP-SEGURADA-IPA APOLICOB-IMP-SEGURADA-AMDS APOLICOB-IMP-SEGURADA-DH APOLICOB-IMP-SEGURADA-DIT APOLICOB-PRM-TARIFARIO-VG APOLICOB-PRM-TARIFARIO-AP */
                _.Initialize(
                    PARAMETROS.LK_COBT_MORTE_NATURAL
                    , PARAMETROS.LK_COBT_MORTE_ACIDENTAL
                    , PARAMETROS.LK_COBT_INV_PERMANENTE
                    , PARAMETROS.LK_COBT_INV_POR_ACIDENTE
                    , PARAMETROS.LK_COBT_ASS_MEDICA
                    , PARAMETROS.LK_COBT_DIARIA_HOSPITALAR
                    , PARAMETROS.LK_COBT_DIARIA_INTERNACAO
                    , PARAMETROS.LK_COBT_IMP_CONJUGE
                    , PARAMETROS.LK_COBT_IMP_FILHO
                    , PARAMETROS.LK_COBT_IMP_CDG
                    , PARAMETROS.LK_PURO_MORTE_NATURAL
                    , PARAMETROS.LK_PURO_MORTE_ACIDENTAL
                    , PARAMETROS.LK_PURO_INV_PERMANENTE
                    , PARAMETROS.LK_PURO_ASS_MEDICA
                    , PARAMETROS.LK_PURO_DIARIA_HOSPITALAR
                    , PARAMETROS.LK_PURO_DIARIA_INTERNACAO
                    , PARAMETROS.LK_PREM_MORTE_NATURAL
                    , PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS
                    , PARAMETROS.LK_PREM_TOTAL
                    , PARAMETROS.LK_IOF_PREMIO
                    , PARAMETROS.LK_QTD_OCORR
                    , PARAMETROS.LK_RETURN_CODE
                    , PARAMETROS.LK_MENSAGEM
                    , FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_VG
                    , FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_AP
                    , FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_IP
                    , FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_IPA
                    , FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_AMDS
                    , FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_DH
                    , FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_DIT
                    , FILLER_5.WS_VALORES_AX.APOLICOB_PRM_TARIFARIO_VG
                    , FILLER_5.WS_VALORES_AX.APOLICOB_PRM_TARIFARIO_AP
                );

                /*" -631- MOVE ZEROS TO WS-I WS-CONTA-COB-CARENCIA WS-CONTA-MSG-HINT WS-VLR-PREMIO-TOT WS-VLR-PREMIO-RESTO */
                _.Move(0, WS_I, WS_CONTA_COB_CARENCIA, WS_CONTA_MSG_HINT, WS_VLR_PREMIO_TOT, WS_VLR_PREMIO_RESTO);

                /*" -632- DISPLAY ' ' */
                _.Display($" ");

                /*" -633- DISPLAY 'DADOS RECEBIDOS DA VG0711S-----------------------' */
                _.Display($"DADOS RECEBIDOS DA VG0711S-----------------------");

                /*" -634- DISPLAY 'LK-NUM-APOLICE             = ' LK-NUM-APOLICE */
                _.Display($"LK-NUM-APOLICE             = {PARAMETROS.LK_NUM_APOLICE}");

                /*" -635- DISPLAY 'LK-SUBGRUPO                = ' LK-SUBGRUPO */
                _.Display($"LK-SUBGRUPO                = {PARAMETROS.LK_SUBGRUPO}");

                /*" -636- DISPLAY 'LK-CERTIFICADO             = ' LK-CERTIFICADO */
                _.Display($"LK-CERTIFICADO             = {PARAMETROS.LK_CERTIFICADO}");

                /*" -637- DISPLAY 'LK-IDADE                   = ' LK-IDADE */
                _.Display($"LK-IDADE                   = {PARAMETROS.LK_IDADE}");

                /*" -638- DISPLAY 'LK-NASCIMENTO.             = ' LK-NASCIMENTO. */
                _.Display($"LK-NASCIMENTO.             = {PARAMETROS.LK_NASCIMENTO}");

                /*" -639- DISPLAY 'LK-SALARIO                 = ' LK-SALARIO */
                _.Display($"LK-SALARIO                 = {PARAMETROS.LK_SALARIO}");

                /*" -640- DISPLAY 'LK-VLR-PREMIO              = ' LK-VLR-PREMIO */
                _.Display($"LK-VLR-PREMIO              = {PARAMETROS.LK_VLR_PREMIO}");

                /*" -641- DISPLAY 'LK-DT-QUITACAO             = ' LK-DT-QUITACAO */
                _.Display($"LK-DT-QUITACAO             = {PARAMETROS.LK_DT_QUITACAO}");

                /*" -642- DISPLAY '-------------------------------------------------' */
                _.Display($"-------------------------------------------------");

                /*" -644- DISPLAY ' ' */
                _.Display($" ");

                /*" -646- PERFORM 0005-INICIALIZA-TAB-COBERTURA 13 TIMES. */

                for (int i = 0; i < 13; i++)
                {

                    M_0005_INICIALIZA_TAB_COBERTURA(true);

                }

                /*" -651- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -654- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -655- MOVE 'ERRO SELECT NA SISTEMAS' TO LK-MENSAGEM */
                    _.Move("ERRO SELECT NA SISTEMAS", PARAMETROS.LK_MENSAGEM);

                    /*" -656- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return Result;

                    /*" -658- END-IF. */
                }


                /*" -662- IF (LK-NUM-APOLICE NOT NUMERIC) OR (LK-SALARIO NOT NUMERIC) OR (LK-VLR-PREMIO NOT NUMERIC) OR (LK-CERTIFICADO NOT NUMERIC) */

                if ((!PARAMETROS.LK_NUM_APOLICE.IsNumeric()) || (!PARAMETROS.LK_SALARIO.IsNumeric()) || (!PARAMETROS.LK_VLR_PREMIO.IsNumeric()) || (!PARAMETROS.LK_CERTIFICADO.IsNumeric()))
                {

                    /*" -663- MOVE 'DADOS NAO NUMERICOS' TO LK-MENSAGEM */
                    _.Move("DADOS NAO NUMERICOS", PARAMETROS.LK_MENSAGEM);

                    /*" -664- MOVE 10 TO LK-RETURN-CODE */
                    _.Move(10, PARAMETROS.LK_RETURN_CODE);

                    /*" -665- GO TO 9999-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/ //GOTO
                    return Result;

                    /*" -667- END-IF. */
                }


                /*" -668- IF LK-NASCIMENTO EQUAL SPACES */

                if (PARAMETROS.LK_NASCIMENTO.IsEmpty())
                {

                    /*" -669- MOVE ZEROS TO LK-DATA-NASCIMENTO */
                    _.Move(0, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO);

                    /*" -670- ELSE */
                }
                else
                {


                    /*" -671- IF LK-DATA-NASCIMENTO NOT NUMERIC */

                    if (!PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO.IsNumeric())
                    {

                        /*" -672- MOVE 'DATA DE NASCIMENTO INVALIDA' TO LK-MENSAGEM */
                        _.Move("DATA DE NASCIMENTO INVALIDA", PARAMETROS.LK_MENSAGEM);

                        /*" -673- MOVE 10 TO LK-RETURN-CODE */
                        _.Move(10, PARAMETROS.LK_RETURN_CODE);

                        /*" -674- GO TO 9999-FIM */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/ //GOTO
                        return Result;

                        /*" -675- END-IF */
                    }


                    /*" -677- END-IF. */
                }


                /*" -679- IF (LK-NUM-APOLICE EQUAL ZEROS) OR (LK-SUBGRUPO EQUAL ZEROS) */

                if ((PARAMETROS.LK_NUM_APOLICE == 00) || (PARAMETROS.LK_SUBGRUPO == 00))
                {

                    /*" -680- MOVE 'APOLICE/SUBGRUPO ZERADOS' TO LK-MENSAGEM */
                    _.Move("APOLICE/SUBGRUPO ZERADOS", PARAMETROS.LK_MENSAGEM);

                    /*" -681- MOVE 20 TO LK-RETURN-CODE */
                    _.Move(20, PARAMETROS.LK_RETURN_CODE);

                    /*" -682- GO TO 9999-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/ //GOTO
                    return Result;

                    /*" -684- END-IF. */
                }


                /*" -685- IF (LK-CERTIFICADO EQUAL ZEROS) */

                if ((PARAMETROS.LK_CERTIFICADO == 00))
                {

                    /*" -686- MOVE 'NUM CERTIFICADO ZERADO' TO LK-MENSAGEM */
                    _.Move("NUM CERTIFICADO ZERADO", PARAMETROS.LK_MENSAGEM);

                    /*" -687- MOVE 20 TO LK-RETURN-CODE */
                    _.Move(20, PARAMETROS.LK_RETURN_CODE);

                    /*" -688- GO TO 9999-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/ //GOTO
                    return Result;

                    /*" -690- END-IF. */
                }


                /*" -692- IF (LK-DATA-NASCIMENTO EQUAL ZEROS) AND (LK-IDADE EQUAL ZEROS) */

                if ((PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO == 00) && (PARAMETROS.LK_IDADE == 00))
                {

                    /*" -693- MOVE 'DATA DE NASCIMENTO INVALIDA' TO LK-MENSAGEM */
                    _.Move("DATA DE NASCIMENTO INVALIDA", PARAMETROS.LK_MENSAGEM);

                    /*" -694- MOVE 10 TO LK-RETURN-CODE */
                    _.Move(10, PARAMETROS.LK_RETURN_CODE);

                    /*" -695- GO TO 9999-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/ //GOTO
                    return Result;

                    /*" -697- END-IF. */
                }


                /*" -698- IF (LK-DT-QUITACAO EQUAL ZEROS) */

                if ((PARAMETROS.LK_DT_QUITACAO == 00))
                {

                    /*" -699- MOVE 'DATA DE QUITACAO INVALIDA' TO LK-MENSAGEM */
                    _.Move("DATA DE QUITACAO INVALIDA", PARAMETROS.LK_MENSAGEM);

                    /*" -700- MOVE 10 TO LK-RETURN-CODE */
                    _.Move(10, PARAMETROS.LK_RETURN_CODE);

                    /*" -701- GO TO 9999-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/ //GOTO
                    return Result;

                    /*" -703- END-IF. */
                }


                /*" -705- IF (LK-IDADE EQUAL ZEROS) AND (LK-SALARIO EQUAL ZEROS) */

                if ((PARAMETROS.LK_IDADE == 00) && (PARAMETROS.LK_SALARIO == 00))
                {

                    /*" -706- MOVE 'N' TO FLAG-CALCULA-PREMIO */
                    _.Move("N", FILLER_5.WS_VALORES_AX.FLAG_CALCULA_PREMIO);

                    /*" -708- END-IF. */
                }


                /*" -710- MOVE LK-NUM-APOLICE TO WS-NUM-APOLICE WS-NUM-APOLICE-GAR. */
                _.Move(PARAMETROS.LK_NUM_APOLICE, WS_NUM_APOLICE, WS_NUM_APOLICE_GAR);

                /*" -712- MOVE LK-SUBGRUPO TO WS-COD-SUBGRUPO WS-COD-SUBGRUPO-GAR. */
                _.Move(PARAMETROS.LK_SUBGRUPO, WS_COD_SUBGRUPO, WS_COD_SUBGRUPO_GAR);

                /*" -714- MOVE LK-CERTIFICADO TO WS-NUM-CERTIFICADO WS-NUM-CERTIFICADO-AUX. */
                _.Move(PARAMETROS.LK_CERTIFICADO, WS_NUM_CERTIFICADO, WS_AREA_SEGURA_PRECO_AUX.WS_NUM_CERTIFICADO_AUX);

                /*" -716- MOVE WS-NUM-CERTIFICADO-AUX TO WS-NUM-CERTIFICADO-ALFA. */
                _.Move(WS_AREA_SEGURA_PRECO_AUX.WS_NUM_CERTIFICADO_AUX, WS_AREA_SEGURA_PRECO_AUX.WS_NUM_CERTIFICADO_ALFA);

                /*" -717- MOVE LK-DT-QUITACAO TO WS-DATA-QUITACAO-DB2 */
                _.Move(PARAMETROS.LK_DT_QUITACAO, WS_AREA_SEGURA_PRECO_AUX.WS_DATA_QUITACAO_DB2);

                /*" -718- MOVE WS-ANO-DB2 TO WS-ANO-QTC */
                _.Move(WS_AREA_SEGURA_PRECO_AUX.FILLER_0.WS_ANO_DB2, WS_AREA_SEGURA_PRECO_AUX.FILLER_3.WS_ANO_QTC);

                /*" -719- MOVE WS-MES-DB2 TO WS-MES-QTC */
                _.Move(WS_AREA_SEGURA_PRECO_AUX.FILLER_0.WS_MES_DB2, WS_AREA_SEGURA_PRECO_AUX.FILLER_3.WS_MES_QTC);

                /*" -721- MOVE WS-DIA-DB2 TO WS-DIA-QTC. */
                _.Move(WS_AREA_SEGURA_PRECO_AUX.FILLER_0.WS_DIA_DB2, WS_AREA_SEGURA_PRECO_AUX.FILLER_3.WS_DIA_QTC);

                /*" -723- PERFORM 0700-SELECT-APOLICE. */

                M_0700_SELECT_APOLICE(true);

                /*" -725- PERFORM 0800-SELECT-SEGURVGA. */

                M_0800_SELECT_SEGURVGA(true);

                /*" -727- PERFORM 0900-SELECT-SEGURVGA-HIST. */

                M_0900_SELECT_SEGURVGA_HIST(true);

                /*" -729- PERFORM 1000-SELECT-MOEDA-COTACAO. */

                M_1000_SELECT_MOEDA_COTACAO(true);

                /*" -730- MOVE WS-SISTEMA-DTMOVABE TO DATA-SQL. */
                _.Move(WS_SISTEMA_DTMOVABE, FILLER_5.WS_VALORES_AX.DATA_SQL);

                /*" -732- MOVE CORR DATA-SQL TO DATA-SISTEMA. */
                _.MoveCorr(FILLER_5.WS_VALORES_AX.DATA_SQL, FILLER_5.WS_VALORES_AX.DATA_SISTEMA);

                /*" -733- IF (LK-DATA-NASCIMENTO NOT EQUAL ZEROS) */

                if ((PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO != 00))
                {

                    /*" -734- PERFORM 0010-CALCULA-IDADE */

                    M_0010_CALCULA_IDADE(true);

                    /*" -736- END-IF. */
                }


                /*" -737- IF (LK-IDADE NOT EQUAL ZEROS) */

                if ((PARAMETROS.LK_IDADE != 00))
                {

                    /*" -738- MOVE LK-IDADE TO WS-IDADE */
                    _.Move(PARAMETROS.LK_IDADE, WS_IDADE);

                    /*" -739- PERFORM 0020-ACESSA-FAIXA-ETARIA */

                    M_0020_ACESSA_FAIXA_ETARIA(true);

                    /*" -741- END-IF. */
                }


                /*" -742- IF (LK-SALARIO NOT EQUAL ZEROS) */

                if ((PARAMETROS.LK_SALARIO != 00))
                {

                    /*" -743- MOVE LK-SALARIO TO WS-SALARIO */
                    _.Move(PARAMETROS.LK_SALARIO, WS_SALARIO);

                    /*" -744- PERFORM 0030-ACESSA-FAIXA-SALARIAL */

                    M_0030_ACESSA_FAIXA_SALARIAL(true);

                    /*" -746- END-IF. */
                }


                /*" -747- IF CALCULA-PREMIOS */

                if (FILLER_5.WS_VALORES_AX.FLAG_CALCULA_PREMIO["CALCULA_PREMIOS"])
                {

                    /*" -748- PERFORM 0060-PREMIOS-SEGURO */

                    M_0060_PREMIOS_SEGURO(true);

                    /*" -750- END-IF */
                }


                /*" -752- IF (LK-VLR-PREMIO EQUAL ZEROS) AND (LK-PREM-TOTAL > ZEROS) */

                if ((PARAMETROS.LK_VLR_PREMIO == 00) && (PARAMETROS.LK_PREM_TOTAL > 00))
                {

                    /*" -753- MOVE LK-PREM-TOTAL TO LK-VLR-PREMIO */
                    _.Move(PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_VLR_PREMIO);

                    /*" -755- END-IF. */
                }


                /*" -757- PERFORM 0040-ACESSA-COND-TECNICAS */

                M_0040_ACESSA_COND_TECNICAS(true);

                /*" -759- PERFORM 0100-PROCURAR-COBER-BASICAS. */

                M_0100_PROCURAR_COBER_BASICAS(true);

                /*" -761- PERFORM M-0200-PROCURAR-COBER-ACESSORIAS. */

                M_0200_PROCURAR_COBER_ACESSORIAS(true);

                /*" -763- PERFORM 0500-DIVIDIR-PREMIO-CIRC-491. */

                M_0500_DIVIDIR_PREMIO_CIRC_491(true);

                /*" -767- PERFORM 0600-CARREGAR-TAB-SAIDA VARYING WS-I FROM 1 BY 1 UNTIL WS-I > 12. */

                for (WS_I.Value = 1; !(WS_I > 12); WS_I.Value += 1)
                {

                    M_0600_CARREGAR_TAB_SAIDA(true);
                }

                /*" -769- COMPUTE LK-QTD-OCORR = WS-I - 1 */
                PARAMETROS.LK_QTD_OCORR.Value = WS_I - 1;

                /*" -770- IF (V0SUBG-IND-IOF EQUAL 'S' ) */

                if ((V0SUBG_IND_IOF == "S"))
                {

                    /*" -772- COMPUTE LK-IOF-PREMIO = (LK-VLR-PREMIO * RAMOCOMP-PCT-IOCC-RAMO) / 100 */
                    PARAMETROS.LK_IOF_PREMIO.Value = (PARAMETROS.LK_VLR_PREMIO * RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO) / 100f;

                    /*" -773- ELSE */
                }
                else
                {


                    /*" -774- MOVE ZEROS TO LK-IOF-PREMIO */
                    _.Move(0, PARAMETROS.LK_IOF_PREMIO);

                    /*" -775- PERFORM 0722-UPDATE-PAGA-IOF */

                    M_0722_UPDATE_PAGA_IOF(true);

                    /*" -777- COMPUTE LK-IOF-PREMIO = (LK-VLR-PREMIO * RAMOCOMP-PCT-IOCC-RAMO) / 100 */
                    PARAMETROS.LK_IOF_PREMIO.Value = (PARAMETROS.LK_VLR_PREMIO * RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO) / 100f;

                    /*" -779- END-IF */
                }


                /*" -780- MOVE ZEROS TO LK-RETURN-CODE. */
                _.Move(0, PARAMETROS.LK_RETURN_CODE);

                /*" -781- MOVE SPACES TO LK-MENSAGEM. */
                _.Move("", PARAMETROS.LK_MENSAGEM);

                /*" -782- DISPLAY ' ' */
                _.Display($" ");

                /*" -783- DISPLAY 'DADOS RETORNADOS DA VG0711S------------------------' */
                _.Display($"DADOS RETORNADOS DA VG0711S------------------------");

                /*" -784- PERFORM 8888-DISPLAY THRU 8888-99-SAIDA. */

                M_8888_DISPLAY(true);

                M_8888_99_SAIDA(true);

                /*" -786- DISPLAY ' ' . */
                _.Display($" ");

                /*" -786- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -651- EXEC SQL SELECT DATA_MOV_ABERTO INTO :WS-SISTEMA-DTMOVABE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SISTEMA_DTMOVABE, WS_SISTEMA_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0005-INICIALIZA-TAB-COBERTURA */
        private void M_0005_INICIALIZA_TAB_COBERTURA(bool isPerform = false)
        {
            /*" -794- ADD 1 TO WS-I */
            WS_I.Value = WS_I + 1;

            /*" -810- INITIALIZE LK-NOM-GRUPO-COBERTURA (WS-I) LK-NUM-GARANTIA (WS-I) LK-NUM-GARANTIA-491 (WS-I) LK-DES-GARANTIA (WS-I) LK-NUM-FAIXA-INICIAL (WS-I) LK-NUM-FAIXA-FINAL (WS-I) LK-VLR-FAIXA-CS-INICIAL(WS-I) LK-VLR-FAIXA-CS-FINAL (WS-I) LK-PCT-COB-PREMIO (WS-I) LK-VLR-CAP-SEGURADO (WS-I) LK-VLR-CAP-DESC (WS-I) LK-VLR-PCT-PREMIO (WS-I) LK-NUM-COB-CARENCIA (WS-I) LK-DES-COB-CARENCIA (WS-I) LK-DES-MSG-HINT (WS-I). */
            _.Initialize(
                PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NOM_GRUPO_COBERTURA
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_GARANTIA
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_GARANTIA_491
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_DES_GARANTIA
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_FAIXA_INICIAL
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_FAIXA_FINAL
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_FAIXA_CS_INICIAL
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_FAIXA_CS_FINAL
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_PCT_COB_PREMIO
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_CAP_SEGURADO
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_CAP_DESC
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_PCT_PREMIO
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_COB_CARENCIA
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_DES_COB_CARENCIA
                , PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_DES_MSG_HINT
            );

            /*" -825- INITIALIZE WTAB-TIPO-GARANTIA (WS-I) WTAB-NOM-GRUPO-COBERTURA (WS-I) WTAB-NUM-GARANTIA (WS-I) WTAB-NUM-GARANTIA-491 (WS-I) WTAB-DES-GARANTIA (WS-I) WTAB-NUM-FAIXA-INICIAL (WS-I) WTAB-NUM-FAIXA-FINAL (WS-I) WTAB-VLR-FAIXA-CS-INICIAL(WS-I) WTAB-VLR-FAIXA-CS-FINAL (WS-I) WTAB-PCT-COB-PREMIO (WS-I) WTAB-VLR-CAP-SEGURADO (WS-I) WTAB-VLR-CAP-DESC (WS-I) WTAB-VLR-PCT-PREMIO (WS-I) WTAB-NUM-COB-CARENCIA (WS-I) WTAB-DES-COB-CARENCIA (WS-I) WTAB-DES-MSG-HINT (WS-I). */
            _.Initialize(
                FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_TIPO_GARANTIA
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NOM_GRUPO_COBERTURA
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_GARANTIA
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_GARANTIA_491
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_FAIXA_INICIAL
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_FAIXA_FINAL
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_FAIXA_CS_INICIAL
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_FAIXA_CS_FINAL
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_PCT_COB_PREMIO
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_CAP_SEGURADO
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_CAP_DESC
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_PCT_PREMIO
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_COB_CARENCIA
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_COB_CARENCIA
                , FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_MSG_HINT
            );

        }

        [StopWatch]
        /*" M-0010-CALCULA-IDADE */
        private void M_0010_CALCULA_IDADE(bool isPerform = false)
        {
            /*" -834- MOVE LK-DATA-NASCIMENTO TO DATA-INVERTIDA. */
            _.Move(PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, FILLER_5.WS_VALORES_AX.DATA_INVERTIDA);

            /*" -835- COMPUTE LK-IDADE = ANO OF DATA-SISTEMA - ANO OF DATA-AAMMDD. */
            PARAMETROS.LK_IDADE.Value = FILLER_5.WS_VALORES_AX.DATA_SISTEMA.ANO_0 - FILLER_5.WS_VALORES_AX.DATA_AAMMDD.ANO_2;

        }

        [StopWatch]
        /*" M-0020-ACESSA-FAIXA-ETARIA */
        private void M_0020_ACESSA_FAIXA_ETARIA(bool isPerform = false)
        {
            /*" -851- PERFORM M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1 */

            M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1();

            /*" -854- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -855- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -856- MOVE 'N' TO FLAG-CALCULA-PREMIO */
                    _.Move("N", FILLER_5.WS_VALORES_AX.FLAG_CALCULA_PREMIO);

                    /*" -857- ELSE */
                }
                else
                {


                    /*" -858- MOVE 'ERRO NO ACESSO A FAIXA ETARIA' TO LK-MENSAGEM */
                    _.Move("ERRO NO ACESSO A FAIXA ETARIA", PARAMETROS.LK_MENSAGEM);

                    /*" -859- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -860- END-IF */
                }


                /*" -860- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0020-ACESSA-FAIXA-ETARIA-DB-SELECT-1 */
        public void M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1()
        {
            /*" -851- EXEC SQL SELECT TAXA_VG INTO :TAXA-VG FROM SEGUROS.FAIXA_ETARIA WHERE NUM_APOLICE = :WS-NUM-APOLICE AND COD_SUBGRUPO = :WS-COD-SUBGRUPO AND IDADE_INICIAL >= :WS-IDADE AND IDADE_FINAL <= :WS-IDADE AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var m_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 = new M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1()
            {
                WS_COD_SUBGRUPO = WS_COD_SUBGRUPO.ToString(),
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
                WS_IDADE = WS_IDADE.ToString(),
            };

            var executed_1 = M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1.Execute(m_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TAXA_VG, TAXA_VG);
            }


        }

        [StopWatch]
        /*" M-0030-ACESSA-FAIXA-SALARIAL */
        private void M_0030_ACESSA_FAIXA_SALARIAL(bool isPerform = false)
        {
            /*" -875- PERFORM M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1 */

            M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1();

            /*" -878- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -879- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -880- MOVE 'N' TO FLAG-CALCULA-PREMIO */
                    _.Move("N", FILLER_5.WS_VALORES_AX.FLAG_CALCULA_PREMIO);

                    /*" -881- ELSE */
                }
                else
                {


                    /*" -882- MOVE 'ERRO NO ACESSO A FAIXA SALARIAL' TO LK-MENSAGEM */
                    _.Move("ERRO NO ACESSO A FAIXA SALARIAL", PARAMETROS.LK_MENSAGEM);

                    /*" -883- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -884- END-IF */
                }


                /*" -884- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0030-ACESSA-FAIXA-SALARIAL-DB-SELECT-1 */
        public void M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1()
        {
            /*" -875- EXEC SQL SELECT TAXA_VG INTO :TAXA-VG FROM SEGUROS.FAIXA_SALARIAL WHERE NUM_APOLICE = :WS-NUM-APOLICE AND COD_SUBGRUPO = :WS-COD-SUBGRUPO AND SALARIO_INICIAL >= :WS-SALARIO AND SALARIO_FINAL <= :WS-SALARIO END-EXEC. */

            var m_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1 = new M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1()
            {
                WS_COD_SUBGRUPO = WS_COD_SUBGRUPO.ToString(),
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
                WS_SALARIO = WS_SALARIO.ToString(),
            };

            var executed_1 = M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1.Execute(m_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TAXA_VG, TAXA_VG);
            }


        }

        [StopWatch]
        /*" M-0040-ACESSA-COND-TECNICAS */
        private void M_0040_ACESSA_COND_TECNICAS(bool isPerform = false)
        {
            /*" -918- PERFORM M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1 */

            M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1();

            /*" -921- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -922- MOVE 'ERRO NO ACESSO A COND. TECNICA' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A COND. TECNICA", PARAMETROS.LK_MENSAGEM);

                /*" -923- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -923- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0040-ACESSA-COND-TECNICAS-DB-SELECT-1 */
        public void M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1()
        {
            /*" -918- EXEC SQL SELECT VALUE(CARREGA_CONJUGE, 0), VALUE(CARREGA_FILHOS, 0), VALUE(TAXA_AP_MORACID, 0), VALUE(TAXA_AP_INVPERM, 0), VALUE(TAXA_AP_AMDS, 0), VALUE(TAXA_AP_DH, 0), VALUE(TAXA_AP_DIT, 0), VALUE(GARAN_ADIC_IEA, 0), VALUE(GARAN_ADIC_IPA, 0), VALUE(GARAN_ADIC_IPD, 0), VALUE(GARAN_ADIC_HD, 0) INTO :CONDITEC-CARREGA-CONJUGE, :CONDITEC-CARREGA-FILHOS, :TAXA-AP-MORACID, :TAXA-AP-INVPERM, :TAXA-AP-AMDS, :TAXA-AP-DH, :TAXA-AP-DIT, :GARAN-ADIC-IEA, :GARAN-ADIC-IPA, :GARAN-ADIC-IPD, :GARAN-ADIC-HD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :WS-NUM-APOLICE AND COD_SUBGRUPO = :WS-COD-SUBGRUPO WITH UR END-EXEC. */

            var m_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1 = new M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1()
            {
                WS_COD_SUBGRUPO = WS_COD_SUBGRUPO.ToString(),
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1.Execute(m_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
                _.Move(executed_1.CONDITEC_CARREGA_FILHOS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS);
                _.Move(executed_1.TAXA_AP_MORACID, TAXA_AP_MORACID);
                _.Move(executed_1.TAXA_AP_INVPERM, TAXA_AP_INVPERM);
                _.Move(executed_1.TAXA_AP_AMDS, TAXA_AP_AMDS);
                _.Move(executed_1.TAXA_AP_DH, TAXA_AP_DH);
                _.Move(executed_1.TAXA_AP_DIT, TAXA_AP_DIT);
                _.Move(executed_1.GARAN_ADIC_IEA, GARAN_ADIC_IEA);
                _.Move(executed_1.GARAN_ADIC_IPA, GARAN_ADIC_IPA);
                _.Move(executed_1.GARAN_ADIC_IPD, GARAN_ADIC_IPD);
                _.Move(executed_1.GARAN_ADIC_HD, GARAN_ADIC_HD);
            }


        }

        [StopWatch]
        /*" M-0050-MOVE-CAP-COBER-BASICA */
        private void M_0050_MOVE_CAP_COBER_BASICA(bool isPerform = false)
        {
            /*" -930- MOVE LK-PURO-MORTE-NATURAL TO LK-COBT-MORTE-NATURAL */
            _.Move(PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_NATURAL);

            /*" -931- MOVE LK-PURO-ASS-MEDICA TO LK-COBT-ASS-MEDICA */
            _.Move(PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_COBT_ASS_MEDICA);

            /*" -932- MOVE LK-PURO-DIARIA-HOSPITALAR TO LK-COBT-DIARIA-HOSPITALAR */
            _.Move(PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR);

            /*" -945- MOVE LK-PURO-DIARIA-INTERNACAO TO LK-COBT-DIARIA-INTERNACAO */
            _.Move(PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_DIARIA_INTERNACAO);

            /*" -947- IF (WS-RAMO EQUAL 93) AND (WS-MODALIDA EQUAL 2) */

            if ((WS_RAMO == 93) && (WS_MODALIDA == 2))
            {

                /*" -948- MOVE LK-PURO-MORTE-ACIDENTAL TO LK-COBT-MORTE-ACIDENTAL */
                _.Move(PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL);

                /*" -949- MOVE LK-PURO-INV-PERMANENTE TO LK-COBT-INV-PERMANENTE */
                _.Move(PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_PERMANENTE);

                /*" -950- MOVE LK-PURO-INV-PERMANENTE TO LK-COBT-INV-POR-ACIDENTE */
                _.Move(PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE);

                /*" -960- ELSE */
            }
            else
            {


                /*" -963- COMPUTE LK-COBT-MORTE-ACIDENTAL ROUNDED = LK-PURO-MORTE-ACIDENTAL + LK-PURO-MORTE-NATURAL */
                PARAMETROS.LK_COBT_MORTE_ACIDENTAL.Value = PARAMETROS.LK_PURO_MORTE_ACIDENTAL + PARAMETROS.LK_PURO_MORTE_NATURAL;

                /*" -967- COMPUTE LK-COBT-MORTE-ACIDENTAL ROUNDED = LK-COBT-MORTE-ACIDENTAL + (LK-PURO-MORTE-NATURAL * GARAN-ADIC-IEA) / 100 */
                PARAMETROS.LK_COBT_MORTE_ACIDENTAL.Value = PARAMETROS.LK_COBT_MORTE_ACIDENTAL + (PARAMETROS.LK_PURO_MORTE_NATURAL * GARAN_ADIC_IEA) / 100f;

                /*" -971- COMPUTE LK-COBT-INV-PERMANENTE ROUNDED = LK-PURO-INV-PERMANENTE + (LK-PURO-MORTE-NATURAL * GARAN-ADIC-IPA) / 100 */
                PARAMETROS.LK_COBT_INV_PERMANENTE.Value = PARAMETROS.LK_PURO_INV_PERMANENTE + (PARAMETROS.LK_PURO_MORTE_NATURAL * GARAN_ADIC_IPA) / 100f;

                /*" -973- COMPUTE LK-COBT-INV-POR-ACIDENTE ROUNDED = (LK-PURO-MORTE-NATURAL * GARAN-ADIC-IPD) / 100 */
                PARAMETROS.LK_COBT_INV_POR_ACIDENTE.Value = (PARAMETROS.LK_PURO_MORTE_NATURAL * GARAN_ADIC_IPD) / 100f;

                /*" -975- END-IF. */
            }


            /*" -976- IF (WS-RAMO NOT EQUAL 93) */

            if ((WS_RAMO != 93))
            {

                /*" -977- IF (WS-RAMO > 93) */

                if ((WS_RAMO > 93))
                {

                    /*" -978- MOVE 93 TO WS-RAMO */
                    _.Move(93, WS_RAMO);

                    /*" -979- ELSE */
                }
                else
                {


                    /*" -980- MOVE 82 TO WS-RAMO */
                    _.Move(82, WS_RAMO);

                    /*" -981- END-IF */
                }


                /*" -983- END-IF. */
            }


            /*" -985- MOVE WS-RAMO TO WS-RAMO-TAB */
            _.Move(WS_RAMO, WS_RAMO_TAB);

            /*" -986- IF (LK-COBT-MORTE-NATURAL > ZEROS) */

            if ((PARAMETROS.LK_COBT_MORTE_NATURAL > 00))
            {

                /*" -987- MOVE 11 TO WS-COBERTURA-OLD */
                _.Move(11, WS_COBERTURA_OLD);

                /*" -988- MOVE 'B' TO WS-TIPO-COBERTURA */
                _.Move("B", WS_TIPO_COBERTURA);

                /*" -989- MOVE LK-COBT-MORTE-NATURAL TO WS-VLR-CAP-COBER */
                _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, WS_VLR_CAP_COBER);

                /*" -990- DISPLAY 'VG0711S - MOVE 01 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 01 PARA WS-VLR-CAP-COBER ");

                /*" -991- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -992- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -994- END-IF */
            }


            /*" -997- COMPUTE WS-IMP-SEGURADA-AP = (LK-COBT-MORTE-ACIDENTAL - LK-COBT-MORTE-NATURAL) */
            FILLER_5.WS_VALORES_AX.WS_IMP_SEGURADA_AP.Value = (PARAMETROS.LK_COBT_MORTE_ACIDENTAL - PARAMETROS.LK_COBT_MORTE_NATURAL);

            /*" -998- DISPLAY 'WS-IMP-SEGURADA-AP      ' WS-IMP-SEGURADA-AP */
            _.Display($"WS-IMP-SEGURADA-AP      {FILLER_5.WS_VALORES_AX.WS_IMP_SEGURADA_AP}");

            /*" -999- DISPLAY 'LK-COBT-MORTE-ACIDENTAL ' LK-COBT-MORTE-ACIDENTAL */
            _.Display($"LK-COBT-MORTE-ACIDENTAL {PARAMETROS.LK_COBT_MORTE_ACIDENTAL}");

            /*" -1001- DISPLAY 'LK-COBT-MORTE-NATURAL   ' LK-COBT-MORTE-NATURAL */
            _.Display($"LK-COBT-MORTE-NATURAL   {PARAMETROS.LK_COBT_MORTE_NATURAL}");

            /*" -1002- IF (WS-IMP-SEGURADA-AP > ZEROS) */

            if ((FILLER_5.WS_VALORES_AX.WS_IMP_SEGURADA_AP > 00))
            {

                /*" -1003- MOVE 01 TO WS-COBERTURA-OLD */
                _.Move(01, WS_COBERTURA_OLD);

                /*" -1004- MOVE 'B' TO WS-TIPO-COBERTURA */
                _.Move("B", WS_TIPO_COBERTURA);

                /*" -1005- MOVE WS-IMP-SEGURADA-AP TO WS-VLR-CAP-COBER */
                _.Move(FILLER_5.WS_VALORES_AX.WS_IMP_SEGURADA_AP, WS_VLR_CAP_COBER);

                /*" -1006- DISPLAY 'VG0711S - MOVE 02 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 02 PARA WS-VLR-CAP-COBER ");

                /*" -1007- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -1008- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -1012- END-IF */
            }


            /*" -1013- IF (LK-COBT-INV-PERMANENTE > ZEROS) */

            if ((PARAMETROS.LK_COBT_INV_PERMANENTE > 00))
            {

                /*" -1014- MOVE 82 TO WS-RAMO-TAB */
                _.Move(82, WS_RAMO_TAB);

                /*" -1015- MOVE 02 TO WS-COBERTURA-OLD */
                _.Move(02, WS_COBERTURA_OLD);

                /*" -1016- MOVE 'B' TO WS-TIPO-COBERTURA */
                _.Move("B", WS_TIPO_COBERTURA);

                /*" -1017- MOVE LK-COBT-INV-PERMANENTE TO WS-VLR-CAP-COBER */
                _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, WS_VLR_CAP_COBER);

                /*" -1018- DISPLAY 'VG0711S - MOVE 03 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 03 PARA WS-VLR-CAP-COBER ");

                /*" -1019- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -1020- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -1022- END-IF */
            }


            /*" -1023- IF (LK-COBT-ASS-MEDICA > ZEROS) */

            if ((PARAMETROS.LK_COBT_ASS_MEDICA > 00))
            {

                /*" -1024- MOVE 82 TO WS-RAMO-TAB */
                _.Move(82, WS_RAMO_TAB);

                /*" -1025- MOVE 03 TO WS-COBERTURA-OLD */
                _.Move(03, WS_COBERTURA_OLD);

                /*" -1026- MOVE 'B' TO WS-TIPO-COBERTURA */
                _.Move("B", WS_TIPO_COBERTURA);

                /*" -1027- MOVE LK-COBT-ASS-MEDICA TO WS-VLR-CAP-COBER */
                _.Move(PARAMETROS.LK_COBT_ASS_MEDICA, WS_VLR_CAP_COBER);

                /*" -1028- DISPLAY 'VG0711S - MOVE 04 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 04 PARA WS-VLR-CAP-COBER ");

                /*" -1029- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -1030- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -1032- END-IF */
            }


            /*" -1033- IF (LK-COBT-DIARIA-HOSPITALAR > ZEROS) */

            if ((PARAMETROS.LK_COBT_DIARIA_HOSPITALAR > 00))
            {

                /*" -1034- MOVE 82 TO WS-RAMO-TAB */
                _.Move(82, WS_RAMO_TAB);

                /*" -1035- MOVE 04 TO WS-COBERTURA-OLD */
                _.Move(04, WS_COBERTURA_OLD);

                /*" -1036- MOVE 'B' TO WS-TIPO-COBERTURA */
                _.Move("B", WS_TIPO_COBERTURA);

                /*" -1037- MOVE LK-COBT-DIARIA-HOSPITALAR TO WS-VLR-CAP-COBER */
                _.Move(PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, WS_VLR_CAP_COBER);

                /*" -1038- DISPLAY 'VG0711S - MOVE 05 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 05 PARA WS-VLR-CAP-COBER ");

                /*" -1039- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -1040- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -1042- END-IF */
            }


            /*" -1044- PERFORM 1200-SELECT-HIS-COBER-PROP */

            M_1200_SELECT_HIS_COBER_PROP(true);

            /*" -1045- IF (LK-COBT-DIARIA-INTERNACAO > ZEROS) */

            if ((PARAMETROS.LK_COBT_DIARIA_INTERNACAO > 00))
            {

                /*" -1046- IF (HISCOBPR-QTMDIT EQUAL ZEROS) */

                if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT == 00))
                {

                    /*" -1047- MOVE 15 TO HISCOBPR-QTMDIT */
                    _.Move(15, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);

                    /*" -1048- END-IF */
                }


                /*" -1050- COMPUTE LK-COBT-DIARIA-INTERNACAO = (LK-COBT-DIARIA-INTERNACAO / HISCOBPR-QTMDIT) */
                PARAMETROS.LK_COBT_DIARIA_INTERNACAO.Value = (PARAMETROS.LK_COBT_DIARIA_INTERNACAO / HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);

                /*" -1051- MOVE 82 TO WS-RAMO-TAB */
                _.Move(82, WS_RAMO_TAB);

                /*" -1052- MOVE 05 TO WS-COBERTURA-OLD */
                _.Move(05, WS_COBERTURA_OLD);

                /*" -1053- MOVE 'B' TO WS-TIPO-COBERTURA */
                _.Move("B", WS_TIPO_COBERTURA);

                /*" -1054- MOVE LK-COBT-DIARIA-INTERNACAO TO WS-VLR-CAP-COBER */
                _.Move(PARAMETROS.LK_COBT_DIARIA_INTERNACAO, WS_VLR_CAP_COBER);

                /*" -1055- DISPLAY 'VG0711S - MOVE 06 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 06 PARA WS-VLR-CAP-COBER ");

                /*" -1056- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -1057- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -1058- END-IF */
            }


            /*" -1058- . */

        }

        [StopWatch]
        /*" M-0060-PREMIOS-SEGURO */
        private void M_0060_PREMIOS_SEGURO(bool isPerform = false)
        {
            /*" -1068- COMPUTE LK-PREM-MORTE-NATURAL ROUNDED = (LK-PURO-MORTE-NATURAL * TAXA-VG) / 1000. */
            PARAMETROS.LK_PREM_MORTE_NATURAL.Value = (PARAMETROS.LK_PURO_MORTE_NATURAL * TAXA_VG) / 1000f;

            /*" -1071- COMPUTE AUX-PREM-MORTE-ACIDENTAL ROUNDED = (LK-PURO-MORTE-ACIDENTAL * TAXA-AP-MORACID) / 1000. */
            FILLER_5.WS_VALORES_AX.AUX_PREM_MORTE_ACIDENTAL.Value = (PARAMETROS.LK_PURO_MORTE_ACIDENTAL * TAXA_AP_MORACID) / 1000f;

            /*" -1074- COMPUTE AUX-PREM-INV-PERMANENTE ROUNDED = (LK-PURO-INV-PERMANENTE * TAXA-AP-INVPERM) / 1000. */
            FILLER_5.WS_VALORES_AX.AUX_PREM_INV_PERMANENTE.Value = (PARAMETROS.LK_PURO_INV_PERMANENTE * TAXA_AP_INVPERM) / 1000f;

            /*" -1077- COMPUTE AUX-PREM-ASS-MEDICA ROUNDED = (LK-PURO-ASS-MEDICA * TAXA-AP-AMDS) / 1000. */
            FILLER_5.WS_VALORES_AX.AUX_PREM_ASS_MEDICA.Value = (PARAMETROS.LK_PURO_ASS_MEDICA * TAXA_AP_AMDS) / 1000f;

            /*" -1080- COMPUTE AUX-PREM-DIARIA-HOSPITALAR ROUNDED = (LK-PURO-DIARIA-HOSPITALAR * TAXA-AP-DH) / 1000. */
            FILLER_5.WS_VALORES_AX.AUX_PREM_DIARIA_HOSPITALAR.Value = (PARAMETROS.LK_PURO_DIARIA_HOSPITALAR * TAXA_AP_DH) / 1000f;

            /*" -1083- COMPUTE AUX-PREM-DIARIA-INTERNACAO ROUNDED = (LK-PURO-DIARIA-INTERNACAO * TAXA-AP-DIT) / 1000. */
            FILLER_5.WS_VALORES_AX.AUX_PREM_DIARIA_INTERNACAO.Value = (PARAMETROS.LK_PURO_DIARIA_INTERNACAO * TAXA_AP_DIT) / 1000f;

            /*" -1090- COMPUTE LK-PREM-ACIDENTES-PESSOAIS = AUX-PREM-MORTE-ACIDENTAL + AUX-PREM-INV-PERMANENTE + AUX-PREM-ASS-MEDICA + AUX-PREM-DIARIA-HOSPITALAR + AUX-PREM-DIARIA-INTERNACAO. */
            PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS.Value = FILLER_5.WS_VALORES_AX.AUX_PREM_MORTE_ACIDENTAL + FILLER_5.WS_VALORES_AX.AUX_PREM_INV_PERMANENTE + FILLER_5.WS_VALORES_AX.AUX_PREM_ASS_MEDICA + FILLER_5.WS_VALORES_AX.AUX_PREM_DIARIA_HOSPITALAR + FILLER_5.WS_VALORES_AX.AUX_PREM_DIARIA_INTERNACAO;

            /*" -1092- COMPUTE LK-PREM-TOTAL = LK-PREM-ACIDENTES-PESSOAIS + LK-PREM-MORTE-NATURAL. */
            PARAMETROS.LK_PREM_TOTAL.Value = PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS + PARAMETROS.LK_PREM_MORTE_NATURAL;

        }

        [StopWatch]
        /*" M-0070-SEARCH-TAB-DEPARA-COBER */
        private void M_0070_SEARCH_TAB_DEPARA_COBER(bool isPerform = false)
        {
            /*" -1101- SET WIDX1 TO +1. */
            WIDX1.Value = +1;

            /*" -1103- SEARCH TAB-COBER-BASICA AT END */
            void SearchAtEnd0()
            {

                /*" -1104- MOVE 'ERRO SEM TAB COBER BASICA ' TO LK-MENSAGEM */
                _.Move("ERRO SEM TAB COBER BASICA ", PARAMETROS.LK_MENSAGEM);

                /*" -1107- DISPLAY 'SEM COBER BASICA - RAMO ' WS-RAMO-TAB ' TP-COBER ' WS-TIPO-COBERTURA ' COBER-OLD ' WS-COBERTURA-OLD */

                $"SEM COBER BASICA - RAMO {WS_RAMO_TAB} TP-COBER {WS_TIPO_COBERTURA} COBER-OLD {WS_COBERTURA_OLD}"
                .Display();

                /*" -1108- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1111- WHEN (TAB-RAMO-COBER(WIDX1) = WS-RAMO-TAB) AND (TAB-TP-COBER (WIDX1) = WS-TIPO-COBERTURA) AND (TAB-COBER-OLD (WIDX1) = WS-COBERTURA-OLD) */
            };

            var mustSearchAtEnd0 = true;
            for (; WIDX1 < FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA.Items.Count; WIDX1.Value++)
            {

                if ((FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_RAMO_COBER == WS_RAMO_TAB) && (FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_TP_COBER == WS_TIPO_COBERTURA) && (FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_COBER_OLD == WS_COBERTURA_OLD))
                {

                    mustSearchAtEnd0 = false;

                    /*" -1113- MOVE WS-TIPO-COBERTURA TO WTAB-TIPO-GARANTIA (WIDX) */
                    _.Move(WS_TIPO_COBERTURA, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_TIPO_GARANTIA);

                    /*" -1115- MOVE TAB-COBER-OLD(WIDX1) TO WTAB-NUM-GARANTIA (WIDX) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_COBER_OLD, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA);

                    /*" -1117- MOVE TAB-COBER-491(WIDX1) TO WTAB-NUM-GARANTIA-491(WIDX) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_COBER_491, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA_491);

                    /*" -1119- MOVE TAB-DES-COBER(WIDX1) TO WTAB-DES-GARANTIA (WIDX) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_DES_GARANTIA);

                    /*" -1121- MOVE WS-VLR-CAP-COBER TO WTAB-VLR-CAP-SEGURADO(WIDX) */
                    _.Move(WS_VLR_CAP_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_VLR_CAP_SEGURADO);

                    /*" -1124- DISPLAY 'VG0711S - MOVE 01 PARA WTAB-VLR-CAP-SEGURADO(WIDX)' */
                    _.Display($"VG0711S - MOVE 01 PARA WTAB-VLR-CAP-SEGURADO(WIDX)");

                    /*" -1126- DISPLAY 'WS-VLR-CAP-COBER            = ' WS-VLR-CAP-COBER */
                    _.Display($"WS-VLR-CAP-COBER            = {WS_VLR_CAP_COBER}");

                    /*" -1128- DISPLAY 'WTAB-VLR-CAP-SEGURADO(WIDX) = ' WTAB-VLR-CAP-SEGURADO(WIDX) */
                    _.Display($"WTAB-VLR-CAP-SEGURADO(WIDX) = {FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX]}");

                    /*" -1129- SET WIDX UP BY +1 */
                    WIDX.Value += +1;

                    /*" -1129- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }

        [StopWatch]
        /*" M-0080-SEARCH-TAB-DEPARA-ACESS */
        private void M_0080_SEARCH_TAB_DEPARA_ACESS(bool isPerform = false)
        {
            /*" -1138- SET WIDX1 TO +1. */
            WIDX1.Value = +1;

            /*" -1140- SEARCH TAB-COBER-BASICA AT END */
            void SearchAtEnd1()
            {

                /*" -1141- MOVE ZEROS TO WS-COBERTURA-491 */
                _.Move(0, WS_COBERTURA_491);

                /*" -1144- WHEN (TAB-RAMO-COBER(WIDX1) = WS-RAMO-TAB) AND (TAB-TP-COBER (WIDX1) = WS-TIPO-COBERTURA) AND (TAB-COBER-OLD (WIDX1) = WS-COBERTURA-OLD) */
            };

            var mustSearchAtEnd1 = true;
            for (; WIDX1 < FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA.Items.Count; WIDX1.Value++)
            {

                if ((FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_RAMO_COBER == WS_RAMO_TAB) && (FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_TP_COBER == WS_TIPO_COBERTURA) && (FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_COBER_OLD == WS_COBERTURA_OLD))
                {

                    mustSearchAtEnd1 = false;

                    /*" -1145- MOVE TAB-COBER-491(WIDX1) TO WS-COBERTURA-491 */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[WIDX1].TAB_COBER_491, WS_COBERTURA_491);

                    /*" -1145- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd1)
                SearchAtEnd1();

            /*" -1147- MOVE WS-TIPO-COBERTURA TO WTAB-TIPO-GARANTIA (WIDX) */
            _.Move(WS_TIPO_COBERTURA, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_TIPO_GARANTIA);

            /*" -1148- MOVE WS-COBERTURA-OLD TO WTAB-NUM-GARANTIA (WIDX) */
            _.Move(WS_COBERTURA_OLD, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA);

            /*" -1149- MOVE WS-COBERTURA-491 TO WTAB-NUM-GARANTIA-491 (WIDX) */
            _.Move(WS_COBERTURA_491, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA_491);

            /*" -1150- MOVE WS-COBER-DESC TO WTAB-DES-GARANTIA (WIDX) */
            _.Move(WS_COBER_DESC, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_DES_GARANTIA);

            /*" -1151- MOVE WS-VALOR TO WTAB-VLR-CAP-SEGURADO (WIDX) */
            _.Move(FILLER_5.WS_VALORES_AX.WS_VALOR, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_VLR_CAP_SEGURADO);

            /*" -1153- DISPLAY 'VG0711S - MOVE 02 PARA WTAB-VLR-CAP-SEGURADO(WIDX)' */
            _.Display($"VG0711S - MOVE 02 PARA WTAB-VLR-CAP-SEGURADO(WIDX)");

            /*" -1155- DISPLAY 'WTAB-VLR-CAP-SEGURADO(WIDX) = ' WTAB-VLR-CAP-SEGURADO(WIDX) */
            _.Display($"WTAB-VLR-CAP-SEGURADO(WIDX) = {FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX]}");

            /*" -1158- DISPLAY 'WTAB-NUM-GARANTIA-491 (WIDX) = ' WTAB-NUM-GARANTIA-491 (WIDX) */
            _.Display($"WTAB-NUM-GARANTIA-491 (WIDX) = {FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX]}");

            /*" -1158- SET WIDX UP BY +1. */
            WIDX.Value += +1;

        }

        [StopWatch]
        /*" M-0090-SEARCH-TAB-DEPARA-491 */
        private void M_0090_SEARCH_TAB_DEPARA_491(bool isPerform = false)
        {
            /*" -1166- SET WS-I TO WIDX */
            WS_I.Value = WIDX;

            /*" -1168- SET WIDX TO +1. */
            WIDX.Value = +1;

            /*" -1170- SEARCH WTAB-COB-PREMIO AT END */
            void SearchAtEnd2()
            {

                /*" -1171- SET WIDX TO WS-I */
                WIDX.Value = WS_I;

                /*" -1172- MOVE 'N' TO WS-FLAG-TAB491 */
                _.Move("N", WS_FLAG_TAB491);

                /*" -1174- WHEN (WTAB-NUM-GARANTIA-491(WIDX) = WS-COBERTURA-491) OR (WTAB-DES-GARANTIA(WIDX) = WS-DES-GARANTIA-491) */
            };

            var mustSearchAtEnd2 = true;
            for (; WIDX < FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO.Items.Count; WIDX.Value++)
            {

                if ((FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA_491 == WS_COBERTURA_491) || (FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_DES_GARANTIA == WS_DES_GARANTIA_491))
                {

                    mustSearchAtEnd2 = false;

                    /*" -1175- MOVE SPACES TO WS-DES-GARANTIA-491 */
                    _.Move("", WS_DES_GARANTIA_491);

                    /*" -1176- MOVE 'S' TO WS-FLAG-TAB491 */
                    _.Move("S", WS_FLAG_TAB491);

                    /*" -1176- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd2)
                SearchAtEnd2();

            /*" -1180- MOVE WS-COBERTURA-491 TO WTAB-NUM-GARANTIA-491 (WIDX) */
            _.Move(WS_COBERTURA_491, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA_491);

            /*" -1182- MOVE WS-NUM-FAIXA-INICIAL TO WTAB-NUM-FAIXA-INICIAL (WIDX) */
            _.Move(WS_NUM_FAIXA_INICIAL, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_FAIXA_INICIAL);

            /*" -1184- MOVE WS-NUM-FAIXA-FINAL TO WTAB-NUM-FAIXA-FINAL (WIDX) */
            _.Move(WS_NUM_FAIXA_FINAL, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_FAIXA_FINAL);

            /*" -1186- MOVE WS-VLR-FAIXA-CS-INICIAL TO WTAB-VLR-FAIXA-CS-INICIAL(WIDX) */
            _.Move(WS_VLR_FAIXA_CS_INICIAL, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_VLR_FAIXA_CS_INICIAL);

            /*" -1188- MOVE WS-VLR-FAIXA-CS-FINAL TO WTAB-VLR-FAIXA-CS-FINAL (WIDX) */
            _.Move(WS_VLR_FAIXA_CS_FINAL, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_VLR_FAIXA_CS_FINAL);

            /*" -1190- MOVE WS-PCT-COB-PREMIO TO WTAB-PCT-COB-PREMIO (WIDX) */
            _.Move(WS_PCT_COB_PREMIO, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_PCT_COB_PREMIO);

            /*" -1192- MOVE WS-VLR-PCT-PREMIO TO WTAB-VLR-PCT-PREMIO (WIDX) */
            _.Move(WS_VLR_PCT_PREMIO, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_VLR_PCT_PREMIO);

            /*" -1194- MOVE WS-NUM-COB-CARENCIA TO WTAB-NUM-COB-CARENCIA (WIDX) */
            _.Move(WS_NUM_COB_CARENCIA, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_COB_CARENCIA);

            /*" -1196- MOVE WS-DES-COB-CARENCIA TO WTAB-DES-COB-CARENCIA (WIDX) */
            _.Move(WS_DES_COB_CARENCIA, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_DES_COB_CARENCIA);

            /*" -1199- MOVE WS-NOM-GRUPO-COBERTURA TO WTAB-NOM-GRUPO-COBERTURA (WIDX) */
            _.Move(WS_NOM_GRUPO_COBERTURA, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NOM_GRUPO_COBERTURA);

            /*" -1200- IF (WS-DES-GARANTIA-491 NOT EQUAL SPACES) */

            if ((!WS_DES_GARANTIA_491.IsEmpty()))
            {

                /*" -1201- MOVE WS-DES-GARANTIA-491 TO WTAB-DES-GARANTIA (WIDX) */
                _.Move(WS_DES_GARANTIA_491, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_DES_GARANTIA);

                /*" -1202- MOVE 'A' TO WTAB-TIPO-GARANTIA (WIDX) */
                _.Move("A", FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_TIPO_GARANTIA);

                /*" -1204- END-IF */
            }


            /*" -1206- SET WIDX TO WS-I */
            WIDX.Value = WS_I;

            /*" -1207- IF (WS-FLAG-TAB491 EQUAL 'N' ) */

            if ((WS_FLAG_TAB491 == "N"))
            {

                /*" -1208- SET WIDX UP BY +1 */
                WIDX.Value += +1;

                /*" -1210- END-IF */
            }


            /*" -1210- MOVE SPACES TO WS-DES-COB-CARENCIA. */
            _.Move("", WS_DES_COB_CARENCIA);

        }

        [StopWatch]
        /*" M-0100-PROCURAR-COBER-BASICAS */
        private void M_0100_PROCURAR_COBER_BASICAS(bool isPerform = false)
        {
            /*" -1221- MOVE 93 TO WS-RAMO1 */
            _.Move(93, WS_RAMO1);

            /*" -1222- MOVE 77 TO WS-RAMO2 */
            _.Move(77, WS_RAMO2);

            /*" -1224- MOVE 11 TO WS-COBERTURA */
            _.Move(11, WS_COBERTURA);

            /*" -1226- PERFORM 1300-SELECT-APOL-COBERTURA. */

            M_1300_SELECT_APOL_COBERTURA(true);

            /*" -1231- COMPUTE APOLICOB-IMP-SEGURADA-VG = APOLICOB-IMP-SEGURADA-IX * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_VG.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -1239- COMPUTE APOLICOB-PRM-TARIFARIO-VG = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            FILLER_5.WS_VALORES_AX.APOLICOB_PRM_TARIFARIO_VG.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -1240- MOVE 81 TO WS-RAMO1 */
            _.Move(81, WS_RAMO1);

            /*" -1241- MOVE 82 TO WS-RAMO2 */
            _.Move(82, WS_RAMO2);

            /*" -1243- MOVE 01 TO WS-COBERTURA */
            _.Move(01, WS_COBERTURA);

            /*" -1245- PERFORM 1300-SELECT-APOL-COBERTURA. */

            M_1300_SELECT_APOL_COBERTURA(true);

            /*" -1250- COMPUTE APOLICOB-IMP-SEGURADA-AP = APOLICOB-IMP-SEGURADA-IX * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_AP.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -1255- COMPUTE APOLICOB-PRM-TARIFARIO-AP = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            FILLER_5.WS_VALORES_AX.APOLICOB_PRM_TARIFARIO_AP.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -1256- IF (APOLICOB-IMP-SEGURADA-VG > ZEROS) */

            if ((FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_VG > 00))
            {

                /*" -1257- MOVE APOLICOB-IMP-SEGURADA-VG TO WS-VLR-COB-BASICA */
                _.Move(FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_VG, WS_VLR_COB_BASICA);

                /*" -1258- MOVE 01 TO WS-COD-COBER-BAS-491 */
                _.Move(01, WS_COD_COBER_BAS_491);

                /*" -1259- ELSE */
            }
            else
            {


                /*" -1260- MOVE APOLICOB-IMP-SEGURADA-AP TO WS-VLR-COB-BASICA */
                _.Move(FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_AP, WS_VLR_COB_BASICA);

                /*" -1261- MOVE 16 TO WS-COD-COBER-BAS-491 */
                _.Move(16, WS_COD_COBER_BAS_491);

                /*" -1266- END-IF. */
            }


            /*" -1268- MOVE 02 TO WS-COBERTURA */
            _.Move(02, WS_COBERTURA);

            /*" -1270- PERFORM 1300-SELECT-APOL-COBERTURA. */

            M_1300_SELECT_APOL_COBERTURA(true);

            /*" -1278- COMPUTE APOLICOB-IMP-SEGURADA-IP = APOLICOB-IMP-SEGURADA-IX * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_IP.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -1280- MOVE 03 TO WS-COBERTURA */
            _.Move(03, WS_COBERTURA);

            /*" -1282- PERFORM 1300-SELECT-APOL-COBERTURA. */

            M_1300_SELECT_APOL_COBERTURA(true);

            /*" -1290- COMPUTE APOLICOB-IMP-SEGURADA-AMDS = APOLICOB-IMP-SEGURADA-IX * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_AMDS.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -1292- MOVE 04 TO WS-COBERTURA */
            _.Move(04, WS_COBERTURA);

            /*" -1294- PERFORM 1300-SELECT-APOL-COBERTURA. */

            M_1300_SELECT_APOL_COBERTURA(true);

            /*" -1302- COMPUTE APOLICOB-IMP-SEGURADA-DH = APOLICOB-IMP-SEGURADA-IX * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_DH.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -1304- MOVE 05 TO WS-COBERTURA */
            _.Move(05, WS_COBERTURA);

            /*" -1306- PERFORM 1300-SELECT-APOL-COBERTURA. */

            M_1300_SELECT_APOL_COBERTURA(true);

            /*" -1313- COMPUTE APOLICOB-IMP-SEGURADA-DIT = APOLICOB-IMP-SEGURADA-IX * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_DIT.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -1314- MOVE APOLICOB-IMP-SEGURADA-VG TO LK-PURO-MORTE-NATURAL */
            _.Move(FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_VG, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -1315- MOVE APOLICOB-IMP-SEGURADA-AP TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_AP, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -1316- MOVE APOLICOB-IMP-SEGURADA-IP TO LK-PURO-INV-PERMANENTE */
            _.Move(FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_IP, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -1317- MOVE APOLICOB-IMP-SEGURADA-AMDS TO LK-PURO-ASS-MEDICA */
            _.Move(FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_AMDS, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -1318- MOVE APOLICOB-IMP-SEGURADA-DH TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_DH, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -1320- MOVE APOLICOB-IMP-SEGURADA-DIT TO LK-PURO-DIARIA-INTERNACAO */
            _.Move(FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_DIT, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -1322- IF (LK-PURO-MORTE-NATURAL EQUAL ZEROS) AND (LK-PURO-MORTE-ACIDENTAL EQUAL ZEROS) */

            if ((PARAMETROS.LK_PURO_MORTE_NATURAL == 00) && (PARAMETROS.LK_PURO_MORTE_ACIDENTAL == 00))
            {

                /*" -1323- MOVE 'CAPITAIS PUROS ZERADOS' TO LK-MENSAGEM */
                _.Move("CAPITAIS PUROS ZERADOS", PARAMETROS.LK_MENSAGEM);

                /*" -1324- MOVE 20 TO LK-RETURN-CODE */
                _.Move(20, PARAMETROS.LK_RETURN_CODE);

                /*" -1325- GO TO 9999-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/ //GOTO
                return;

                /*" -1327- END-IF. */
            }


            /*" -1328- IF (LK-VLR-PREMIO EQUAL ZEROS) */

            if ((PARAMETROS.LK_VLR_PREMIO == 00))
            {

                /*" -1331- COMPUTE LK-VLR-PREMIO = APOLICOB-PRM-TARIFARIO-VG + APOLICOB-PRM-TARIFARIO-AP */
                PARAMETROS.LK_VLR_PREMIO.Value = FILLER_5.WS_VALORES_AX.APOLICOB_PRM_TARIFARIO_VG + FILLER_5.WS_VALORES_AX.APOLICOB_PRM_TARIFARIO_AP;

                /*" -1333- END-IF. */
            }


            /*" -1334- PERFORM 0050-MOVE-CAP-COBER-BASICA */

            M_0050_MOVE_CAP_COBER_BASICA(true);

            /*" -1334- . */

        }

        [StopWatch]
        /*" M-0200-PROCURAR-COBER-ACESSORIAS */
        private void M_0200_PROCURAR_COBER_ACESSORIAS(bool isPerform = false)
        {
            /*" -1342- IF (CONDITEC-CARREGA-CONJUGE > ZEROS) */

            if ((CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE > 00))
            {

                /*" -1345- COMPUTE LK-COBT-IMP-CONJUGE = (LK-COBT-MORTE-NATURAL * (CONDITEC-CARREGA-CONJUGE / 100)) */
                PARAMETROS.LK_COBT_IMP_CONJUGE.Value = (PARAMETROS.LK_COBT_MORTE_NATURAL * (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f));

                /*" -1346- MOVE 82 TO WS-RAMO-TAB */
                _.Move(82, WS_RAMO_TAB);

                /*" -1347- MOVE 33 TO WS-COBERTURA-OLD */
                _.Move(33, WS_COBERTURA_OLD);

                /*" -1348- MOVE 'A' TO WS-TIPO-COBERTURA */
                _.Move("A", WS_TIPO_COBERTURA);

                /*" -1349- MOVE LK-COBT-IMP-CONJUGE TO WS-VLR-CAP-COBER */
                _.Move(PARAMETROS.LK_COBT_IMP_CONJUGE, WS_VLR_CAP_COBER);

                /*" -1350- DISPLAY 'VG0711S - MOVE 07 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 07 PARA WS-VLR-CAP-COBER ");

                /*" -1351- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -1352- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -1354- END-IF. */
            }


            /*" -1355- IF (CONDITEC-CARREGA-FILHOS > ZEROS) */

            if ((CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS > 00))
            {

                /*" -1358- COMPUTE LK-COBT-IMP-FILHO = (LK-COBT-MORTE-NATURAL * (CONDITEC-CARREGA-FILHOS / 100)) */
                PARAMETROS.LK_COBT_IMP_FILHO.Value = (PARAMETROS.LK_COBT_MORTE_NATURAL * (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS / 100f));

                /*" -1359- MOVE 82 TO WS-RAMO-TAB */
                _.Move(82, WS_RAMO_TAB);

                /*" -1360- MOVE 34 TO WS-COBERTURA-OLD */
                _.Move(34, WS_COBERTURA_OLD);

                /*" -1361- MOVE 'A' TO WS-TIPO-COBERTURA */
                _.Move("A", WS_TIPO_COBERTURA);

                /*" -1362- MOVE LK-COBT-IMP-FILHO TO WS-VLR-CAP-COBER */
                _.Move(PARAMETROS.LK_COBT_IMP_FILHO, WS_VLR_CAP_COBER);

                /*" -1363- DISPLAY 'VG0711S - MOVE 08 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 08 PARA WS-VLR-CAP-COBER ");

                /*" -1364- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -1365- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -1367- END-IF. */
            }


            /*" -1368- IF (LK-NUM-APOLICE EQUAL 109300000567) */

            if ((PARAMETROS.LK_NUM_APOLICE == 109300000567))
            {

                /*" -1370- COMPUTE LK-COBT-IMP-CDG = APOLICOB-IMP-SEGURADA-VG * 0,5 */
                PARAMETROS.LK_COBT_IMP_CDG.Value = FILLER_5.WS_VALORES_AX.APOLICOB_IMP_SEGURADA_VG * 0.5;

                /*" -1371- MOVE 82 TO WS-RAMO-TAB */
                _.Move(82, WS_RAMO_TAB);

                /*" -1372- MOVE 56 TO WS-COBERTURA-OLD */
                _.Move(56, WS_COBERTURA_OLD);

                /*" -1373- MOVE 'A' TO WS-TIPO-COBERTURA */
                _.Move("A", WS_TIPO_COBERTURA);

                /*" -1374- MOVE LK-COBT-IMP-CDG TO WS-VLR-CAP-COBER */
                _.Move(PARAMETROS.LK_COBT_IMP_CDG, WS_VLR_CAP_COBER);

                /*" -1375- DISPLAY 'VG0711S - MOVE 09 PARA WS-VLR-CAP-COBER ' */
                _.Display($"VG0711S - MOVE 09 PARA WS-VLR-CAP-COBER ");

                /*" -1376- DISPLAY 'WS-VLR-CAP-COBER = ' WS-VLR-CAP-COBER */
                _.Display($"WS-VLR-CAP-COBER = {WS_VLR_CAP_COBER}");

                /*" -1377- PERFORM 0070-SEARCH-TAB-DEPARA-COBER */

                M_0070_SEARCH_TAB_DEPARA_COBER(true);

                /*" -1379- END-IF. */
            }


            /*" -1381- MOVE 'N' TO WFIM-COBER */
            _.Move("N", WFIM_COBER);

            /*" -1383- PERFORM 0210-LER-COBER-ACESSORIO. */

            M_0210_LER_COBER_ACESSORIO(true);

            /*" -1385- PERFORM 0220-FETCH-COBER-ACESSORIO. */

            M_0220_FETCH_COBER_ACESSORIO(true);

            /*" -1387- PERFORM 0250-PROCESSA-COBER-ACESSORIO THRU 0250-99-SAIDA UNTIL WFIM-COBER = 'S' */

            while (!(WFIM_COBER == "S"))
            {

                M_0250_PROCESSA_COBER_ACESSORIO(true);

                M_0250_10_LER_PROXIMO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0250_99_SAIDA*/

            }

            /*" -1387- . */

        }

        [StopWatch]
        /*" M-0210-LER-COBER-ACESSORIO */
        private void M_0210_LER_COBER_ACESSORIO(bool isPerform = false)
        {
            /*" -1437- PERFORM M_0210_LER_COBER_ACESSORIO_DB_DECLARE_1 */

            M_0210_LER_COBER_ACESSORIO_DB_DECLARE_1();

            /*" -1439- PERFORM M_0210_LER_COBER_ACESSORIO_DB_OPEN_1 */

            M_0210_LER_COBER_ACESSORIO_DB_OPEN_1();

            /*" -1442- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1443- MOVE 'ERRO NO OPEN CURSOR COBER ACESS ' TO LK-MENSAGEM */
                _.Move("ERRO NO OPEN CURSOR COBER ACESS ", PARAMETROS.LK_MENSAGEM);

                /*" -1446- DISPLAY 'ERRO OPEN CURSOR COBER_ACESSORIO ' 'NUM-APOLICE ' WS-NUM-APOLICE ' COD-SUBGRUPO ' WS-COD-SUBGRUPO */

                $"ERRO OPEN CURSOR COBER_ACESSORIO NUM-APOLICE {WS_NUM_APOLICE} COD-SUBGRUPO {WS_COD_SUBGRUPO}"
                .Display();

                /*" -1447- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1447- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0210-LER-COBER-ACESSORIO-DB-DECLARE-1 */
        public void M_0210_LER_COBER_ACESSORIO_DB_DECLARE_1()
        {
            /*" -1437- EXEC SQL DECLARE COBER CURSOR FOR SELECT A.COD_COBERTURA , A.IMP_SEGURADA_IX , DATE(A.DATA_INIVIGENCIA), B.DES_ACESSORIO FROM SEGUROS.VG_COBERTURAS_SUBG A, SEGUROS.VG_ACESSORIO B WHERE A.NUM_APOLICE = :WS-NUM-APOLICE AND A.COD_SUBGRUPO = :WS-COD-SUBGRUPO AND A.SIT_COBERTURA = '0' AND A.COD_COBERTURA <> 12 AND A.COD_COBERTURA = B.NUM_ACESSORIO UNION SELECT A.COD_COBERTURA , A.IMP_SEGURADA_IX , DATE(A.DATA_INIVIGENCIA), D.DES_ACESSORIO FROM SEGUROS.VG_COBERTURAS_SUBG A , SEGUROS.VG_COBER_SUBG_HIST B , SEGUROS.PROPOSTAS_VA C , SEGUROS.VG_ACESSORIO D WHERE A.NUM_APOLICE = :WS-NUM-APOLICE AND A.COD_SUBGRUPO = :WS-COD-SUBGRUPO AND A.COD_COBERTURA = 18 AND C.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.NUM_APOLICE = C.NUM_APOLICE AND A.COD_SUBGRUPO = C.COD_SUBGRUPO AND A.COD_COBERTURA = D.NUM_ACESSORIO AND (A.SIT_COBERTURA = '1' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.COD_COBERTURA = B.COD_COBERTURA AND B.DATA_TERVIGENCIA > C.DATA_QUITACAO AND B.DATA_TERVIGENCIA = (SELECT MAX(E.DATA_TERVIGENCIA) FROM SEGUROS.VG_COBER_SUBG_HIST E WHERE E.NUM_APOLICE = A.NUM_APOLICE AND E.COD_COBERTURA = A.COD_COBERTURA AND E.COD_SUBGRUPO = A.COD_SUBGRUPO AND E.DATA_TERVIGENCIA <> '9999-12-31' )) ORDER BY 1 WITH UR END-EXEC. */
            COBER = new VG0711S_COBER(true);
            string GetQuery_COBER()
            {
                var query = @$"SELECT A.COD_COBERTURA
							, 
							A.IMP_SEGURADA_IX
							, 
							DATE(A.DATA_INIVIGENCIA)
							, 
							B.DES_ACESSORIO 
							FROM SEGUROS.VG_COBERTURAS_SUBG A
							, 
							SEGUROS.VG_ACESSORIO B 
							WHERE A.NUM_APOLICE = '{WS_NUM_APOLICE}' 
							AND A.COD_SUBGRUPO = '{WS_COD_SUBGRUPO}' 
							AND A.SIT_COBERTURA = '0' 
							AND A.COD_COBERTURA <> 12 
							AND A.COD_COBERTURA = B.NUM_ACESSORIO 
							UNION 
							SELECT A.COD_COBERTURA
							, 
							A.IMP_SEGURADA_IX
							, 
							DATE(A.DATA_INIVIGENCIA)
							, 
							D.DES_ACESSORIO 
							FROM SEGUROS.VG_COBERTURAS_SUBG A 
							, SEGUROS.VG_COBER_SUBG_HIST B 
							, SEGUROS.PROPOSTAS_VA C 
							, SEGUROS.VG_ACESSORIO D 
							WHERE A.NUM_APOLICE = '{WS_NUM_APOLICE}' 
							AND A.COD_SUBGRUPO = '{WS_COD_SUBGRUPO}' 
							AND A.COD_COBERTURA = 18 
							AND C.NUM_CERTIFICADO = '{PROPOVA_NUM_CERTIFICADO}' 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.COD_SUBGRUPO = C.COD_SUBGRUPO 
							AND A.COD_COBERTURA = D.NUM_ACESSORIO 
							AND (A.SIT_COBERTURA = '1' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND A.COD_COBERTURA = B.COD_COBERTURA 
							AND B.DATA_TERVIGENCIA > C.DATA_QUITACAO 
							AND B.DATA_TERVIGENCIA = 
							(SELECT MAX(E.DATA_TERVIGENCIA) 
							FROM SEGUROS.VG_COBER_SUBG_HIST E 
							WHERE E.NUM_APOLICE = A.NUM_APOLICE 
							AND E.COD_COBERTURA = A.COD_COBERTURA 
							AND E.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND E.DATA_TERVIGENCIA <> '9999-12-31' )) 
							ORDER BY 1";

                return query;
            }
            COBER.GetQueryEvent += GetQuery_COBER;

        }

        [StopWatch]
        /*" M-0210-LER-COBER-ACESSORIO-DB-OPEN-1 */
        public void M_0210_LER_COBER_ACESSORIO_DB_OPEN_1()
        {
            /*" -1439- EXEC SQL OPEN COBER END-EXEC. */

            COBER.Open();

        }

        [StopWatch]
        /*" M-0510-LER-COBERTURA-491-DB-DECLARE-1 */
        public void M_0510_LER_COBERTURA_491_DB_DECLARE_1()
        {
            /*" -1775- EXEC SQL DECLARE COBER491 CURSOR FOR SELECT F.NOM_GRUPO_COBERTURA, F.IND_CONJUGE, E.NUM_GARANTIA, E.DES_GARANTIA, C.NUM_FAIXA_INICIAL, C.NUM_FAIXA_FINAL, D.VLR_FAIXA_CS_INICIAL, D.VLR_FAIXA_CS_FINAL, B.PCT_COB_PREMIO, B.DTA_INI_VIGENCIA_GRUPO, B.DTA_FIM_VIGENCIA_GRUPO, VALUE(G.DES_CARENCIA_MSG, ' ' ) FROM SEGUROS.VG_APOLICE_COB_GAR A JOIN SEGUROS.VG_GRUPO_COB_CS_ETARIA B ON A.SEQ_GRUPO_COBERTURA = B.SEQ_GRUPO_COBERTURA AND A.NUM_GARANTIA = B.NUM_GARANTIA AND A.DTA_INI_VIGENCIA = B.DTA_INI_VIGENCIA JOIN SEGUROS.VG_FAIXA_ETARIA C ON B.SEQ_FAIXA_ETARIA = C.SEQ_FAIXA_ETARIA JOIN SEGUROS.VG_FAIXA_CAP_SEGUR D ON B.SEQ_FAIXA_CAP_SEGUR = D.SEQ_FAIXA_CAP_SEGUR JOIN SEGUROS.VG_GARANTIA E ON A.NUM_GARANTIA = E.NUM_GARANTIA JOIN SEGUROS.VG_GRUPO_COBERTURA F ON A.SEQ_GRUPO_COBERTURA = F.SEQ_GRUPO_COBERTURA LEFT JOIN SEGUROS.VG_CARENCIA_MSG G ON A.SEQ_CARENCIA = G.SEQ_CARENCIA_MSG WHERE A.NUM_APOLICE = :WS-NUM-APOLICE-GAR AND A.COD_SUBGRUPO = :WS-COD-SUBGRUPO-GAR AND A.COD_PRODUTO = :WS-PRODUTO AND A.IND_TIPO_COB_GAR = 'PF' AND A.IND_PERIODO_FAT = 0 AND C.NUM_FAIXA_INICIAL <= :WS-IDADE AND C.NUM_FAIXA_FINAL >= :WS-IDADE AND D.VLR_FAIXA_CS_INICIAL <= :WS-VLR-COB-CONSULTA AND D.VLR_FAIXA_CS_FINAL >= :WS-VLR-COB-CONSULTA END-EXEC. */
            COBER491 = new VG0711S_COBER491(true);
            string GetQuery_COBER491()
            {
                var query = @$"SELECT F.NOM_GRUPO_COBERTURA
							, 
							F.IND_CONJUGE
							, 
							E.NUM_GARANTIA
							, 
							E.DES_GARANTIA
							, 
							C.NUM_FAIXA_INICIAL
							, 
							C.NUM_FAIXA_FINAL
							, 
							D.VLR_FAIXA_CS_INICIAL
							, 
							D.VLR_FAIXA_CS_FINAL
							, 
							B.PCT_COB_PREMIO
							, 
							B.DTA_INI_VIGENCIA_GRUPO
							, 
							B.DTA_FIM_VIGENCIA_GRUPO
							, 
							VALUE(G.DES_CARENCIA_MSG
							, ' ' ) 
							FROM SEGUROS.VG_APOLICE_COB_GAR A 
							JOIN SEGUROS.VG_GRUPO_COB_CS_ETARIA B 
							ON A.SEQ_GRUPO_COBERTURA = B.SEQ_GRUPO_COBERTURA 
							AND A.NUM_GARANTIA = B.NUM_GARANTIA 
							AND A.DTA_INI_VIGENCIA = B.DTA_INI_VIGENCIA 
							JOIN SEGUROS.VG_FAIXA_ETARIA C 
							ON B.SEQ_FAIXA_ETARIA = C.SEQ_FAIXA_ETARIA 
							JOIN SEGUROS.VG_FAIXA_CAP_SEGUR D 
							ON B.SEQ_FAIXA_CAP_SEGUR = D.SEQ_FAIXA_CAP_SEGUR 
							JOIN SEGUROS.VG_GARANTIA E 
							ON A.NUM_GARANTIA = E.NUM_GARANTIA 
							JOIN SEGUROS.VG_GRUPO_COBERTURA F 
							ON A.SEQ_GRUPO_COBERTURA = F.SEQ_GRUPO_COBERTURA 
							LEFT
							JOIN SEGUROS.VG_CARENCIA_MSG G 
							ON A.SEQ_CARENCIA = G.SEQ_CARENCIA_MSG 
							WHERE A.NUM_APOLICE = '{WS_NUM_APOLICE_GAR}' 
							AND A.COD_SUBGRUPO = '{WS_COD_SUBGRUPO_GAR}' 
							AND A.COD_PRODUTO = '{WS_PRODUTO}' 
							AND A.IND_TIPO_COB_GAR = 'PF' 
							AND A.IND_PERIODO_FAT = 0 
							AND C.NUM_FAIXA_INICIAL <= '{WS_IDADE}' 
							AND C.NUM_FAIXA_FINAL >= '{WS_IDADE}' 
							AND D.VLR_FAIXA_CS_INICIAL <= '{WS_VLR_COB_CONSULTA}' 
							AND D.VLR_FAIXA_CS_FINAL >= '{WS_VLR_COB_CONSULTA}'";

                return query;
            }
            COBER491.GetQueryEvent += GetQuery_COBER491;

        }

        [StopWatch]
        /*" M-0220-FETCH-COBER-ACESSORIO */
        private void M_0220_FETCH_COBER_ACESSORIO(bool isPerform = false)
        {
            /*" -1459- PERFORM M_0220_FETCH_COBER_ACESSORIO_DB_FETCH_1 */

            M_0220_FETCH_COBER_ACESSORIO_DB_FETCH_1();

            /*" -1462- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1463- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -1464- MOVE 'S' TO WFIM-COBER */
                    _.Move("S", WFIM_COBER);

                    /*" -1464- PERFORM M_0220_FETCH_COBER_ACESSORIO_DB_CLOSE_1 */

                    M_0220_FETCH_COBER_ACESSORIO_DB_CLOSE_1();

                    /*" -1466- ELSE */
                }
                else
                {


                    /*" -1467- MOVE 'ERRO FETCH CURSOR COBER ACESS ' TO LK-MENSAGEM */
                    _.Move("ERRO FETCH CURSOR COBER ACESS ", PARAMETROS.LK_MENSAGEM);

                    /*" -1468- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1469- END-IF */
                }


                /*" -1469- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0220-FETCH-COBER-ACESSORIO-DB-FETCH-1 */
        public void M_0220_FETCH_COBER_ACESSORIO_DB_FETCH_1()
        {
            /*" -1459- EXEC SQL FETCH COBER INTO :VGCOBSUB-COD-COBERTURA, :VGCOBSUB-IMP-SEGURADA-IX, :VGCOBSUB-DATA-INIVIGENCIA, :VG033-DES-ACESSORIO END-EXEC. */

            if (COBER.Fetch())
            {
                _.Move(COBER.VGCOBSUB_COD_COBERTURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);
                _.Move(COBER.VGCOBSUB_IMP_SEGURADA_IX, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);
                _.Move(COBER.VGCOBSUB_DATA_INIVIGENCIA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA);
                _.Move(COBER.VG033_DES_ACESSORIO, VG033.DCLVG_ACESSORIO.VG033_DES_ACESSORIO);
            }

        }

        [StopWatch]
        /*" M-0220-FETCH-COBER-ACESSORIO-DB-CLOSE-1 */
        public void M_0220_FETCH_COBER_ACESSORIO_DB_CLOSE_1()
        {
            /*" -1464- EXEC SQL CLOSE COBER END-EXEC */

            COBER.Close();

        }

        [StopWatch]
        /*" M-0250-PROCESSA-COBER-ACESSORIO */
        private void M_0250_PROCESSA_COBER_ACESSORIO(bool isPerform = false)
        {
            /*" -1479- IF VGCOBSUB-COD-COBERTURA EQUAL 31 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 31)
            {

                /*" -1480- MOVE ZEROS TO WS-FLAG-SEGPRECO */
                _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                /*" -1481- PERFORM 4000-00-VALIDAR-SEGURA-PRECO THRU 4000-99-SAIDA */

                M_4000_00_VALIDAR_SEGURA_PRECO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/


                /*" -1482- IF NOT TEM-SEGURA-PRECO */

                if (!WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO["TEM_SEGURA_PRECO"])
                {

                    /*" -1483- GO TO 0250-10-LER-PROXIMO */

                    M_0250_10_LER_PROXIMO(); //GOTO
                    return;

                    /*" -1484- END-IF */
                }


                /*" -1486- END-IF */
            }


            /*" -1487- MOVE VG033-DES-ACESSORIO TO WS-COBER-DESC. */
            _.Move(VG033.DCLVG_ACESSORIO.VG033_DES_ACESSORIO, WS_COBER_DESC);

            /*" -1501- MOVE SPACES TO WS-VALOR-INT-X */
            _.Move("", FILLER_5.WS_VALORES_AX.WS_VALOR_INT_X);

            /*" -1502- EVALUATE VGCOBSUB-COD-COBERTURA */
            switch (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.Value)
            {

                /*" -1503- WHEN  11 */
                case 11:

                    /*" -1504- MOVE TAB-DES-COBER(18) TO WS-COBER-DESC */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[18].TAB_DES_COBER, WS_COBER_DESC);

                    /*" -1505- WHEN  05 */
                    break;
                case 05:

                    /*" -1506- MOVE TAB-DES-COBER(13) TO WS-COBER-DESC */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[13].TAB_DES_COBER, WS_COBER_DESC);

                    /*" -1528- END-EVALUATE */
                    break;
            }


            /*" -1530- IF (WS-COBER-DESC(1:8) EQUAL 'REMISSAO' ) OR (WS-COBER-DESC(1:8) EQUAL 'REMISS�O' ) */

            if ((WS_COBER_DESC.Substring(1, 8) == "REMISSAO") || (WS_COBER_DESC.Substring(1, 8) == "REMISS�O"))
            {

                /*" -1531- MOVE ZEROS TO WS-VALOR */
                _.Move(0, FILLER_5.WS_VALORES_AX.WS_VALOR);

                /*" -1532- DISPLAY 'VG0711S - MOVE 01 PARA WS-VALOR ' */
                _.Display($"VG0711S - MOVE 01 PARA WS-VALOR ");

                /*" -1533- ELSE */
            }
            else
            {


                /*" -1534- MOVE VGCOBSUB-IMP-SEGURADA-IX TO WS-VALOR */
                _.Move(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, FILLER_5.WS_VALORES_AX.WS_VALOR);

                /*" -1535- DISPLAY 'VG0711S - MOVE 02 PARA WS-VALOR ' */
                _.Display($"VG0711S - MOVE 02 PARA WS-VALOR ");

                /*" -1536- DISPLAY 'WS-VALOR = ' WS-VALOR */
                _.Display($"WS-VALOR = {FILLER_5.WS_VALORES_AX.WS_VALOR}");

                /*" -1538- DISPLAY 'VGCOBSUB-IMP-SEGURADA-IX = ' VGCOBSUB-IMP-SEGURADA-IX */
                _.Display($"VGCOBSUB-IMP-SEGURADA-IX = {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX}");

                /*" -1540- END-IF */
            }


            /*" -1542- IF (VGCOBSUB-COD-COBERTURA EQUAL 01 OR 22) AND (HISCOBPR-IMPSEGCDG > ZEROS) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.In("01", "22")) && (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG > 00))
            {

                /*" -1543- MOVE HISCOBPR-IMPSEGCDG TO WS-VALOR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, FILLER_5.WS_VALORES_AX.WS_VALOR);

                /*" -1544- DISPLAY 'VG0711S - MOVE 03 PARA WS-VALOR ' */
                _.Display($"VG0711S - MOVE 03 PARA WS-VALOR ");

                /*" -1545- DISPLAY 'WS-VALOR = ' WS-VALOR */
                _.Display($"WS-VALOR = {FILLER_5.WS_VALORES_AX.WS_VALOR}");

                /*" -1546- DISPLAY 'HISCOBPR-IMPSEGCDG = ' HISCOBPR-IMPSEGCDG */
                _.Display($"HISCOBPR-IMPSEGCDG = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG}");

                /*" -1548- END-IF */
            }


            /*" -1550- IF (VGCOBSUB-COD-COBERTURA EQUAL 02 OR 16 OR 17 OR 18 OR 19 OR 20 OR 25 OR 31) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.In("02", "16", "17", "18", "19", "20", "25", "31")))
            {

                /*" -1551- MOVE ZEROS TO WS-VALOR */
                _.Move(0, FILLER_5.WS_VALORES_AX.WS_VALOR);

                /*" -1552- DISPLAY 'VG0711S - MOVE 04 PARA WS-VALOR ' */
                _.Display($"VG0711S - MOVE 04 PARA WS-VALOR ");

                /*" -1554- END-IF */
            }


            /*" -1555- IF (VGCOBSUB-IMP-SEGURADA-IX EQUAL 1,00) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX == 1.00))
            {

                /*" -1556- MOVE ZEROS TO WS-VALOR */
                _.Move(0, FILLER_5.WS_VALORES_AX.WS_VALOR);

                /*" -1557- DISPLAY 'VG0711S - MOVE 05 PARA WS-VALOR ' */
                _.Display($"VG0711S - MOVE 05 PARA WS-VALOR ");

                /*" -1559- DISPLAY 'VGCOBSUB-IMP-SEGURADA-IX = ' VGCOBSUB-IMP-SEGURADA-IX */
                _.Display($"VGCOBSUB-IMP-SEGURADA-IX = {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX}");

                /*" -1564- END-IF */
            }


            /*" -1565- IF (VGCOBSUB-COD-COBERTURA EQUAL 11) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 11))
            {

                /*" -1566- COMPUTE WS-VALOR-9 = WS-VLR-COB-BASICA / 2 */
                FILLER_5.WS_VALORES_AX.WS_VALOR_9.Value = WS_VLR_COB_BASICA / 2f;

                /*" -1567- IF (WS-VALOR-9 > 50000) */

                if ((FILLER_5.WS_VALORES_AX.WS_VALOR_9 > 50000))
                {

                    /*" -1568- MOVE 50000 TO WS-VALOR */
                    _.Move(50000, FILLER_5.WS_VALORES_AX.WS_VALOR);

                    /*" -1569- DISPLAY 'VG0711S - MOVE 06 PARA WS-VALOR ' */
                    _.Display($"VG0711S - MOVE 06 PARA WS-VALOR ");

                    /*" -1570- ELSE */
                }
                else
                {


                    /*" -1571- MOVE WS-VALOR-9 TO WS-VALOR */
                    _.Move(FILLER_5.WS_VALORES_AX.WS_VALOR_9, FILLER_5.WS_VALORES_AX.WS_VALOR);

                    /*" -1572- DISPLAY 'VG0711S - MOVE 07 PARA WS-VALOR ' */
                    _.Display($"VG0711S - MOVE 07 PARA WS-VALOR ");

                    /*" -1573- DISPLAY 'WS-VALOR   = ' WS-VALOR */
                    _.Display($"WS-VALOR   = {FILLER_5.WS_VALORES_AX.WS_VALOR}");

                    /*" -1574- DISPLAY 'WS-VALOR-9 = ' WS-VALOR-9 */
                    _.Display($"WS-VALOR-9 = {FILLER_5.WS_VALORES_AX.WS_VALOR_9}");

                    /*" -1575- END-IF */
                }


                /*" -1577- END-IF. */
            }


            /*" -1578- MOVE 82 TO WS-RAMO-TAB */
            _.Move(82, WS_RAMO_TAB);

            /*" -1579- MOVE VGCOBSUB-COD-COBERTURA TO WS-COBERTURA-OLD */
            _.Move(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA, WS_COBERTURA_OLD);

            /*" -1581- MOVE 'A' TO WS-TIPO-COBERTURA */
            _.Move("A", WS_TIPO_COBERTURA);

            /*" -1582- IF (VGCOBSUB-COD-COBERTURA EQUAL 22) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 22))
            {

                /*" -1583- MOVE 'B' TO WS-TIPO-COBERTURA */
                _.Move("B", WS_TIPO_COBERTURA);

                /*" -1585- END-IF */
            }


            /*" -1585- PERFORM 0080-SEARCH-TAB-DEPARA-ACESS. */

            M_0080_SEARCH_TAB_DEPARA_ACESS(true);

        }

        [StopWatch]
        /*" M-0250-10-LER-PROXIMO */
        private void M_0250_10_LER_PROXIMO(bool isPerform = false)
        {
            /*" -1589- PERFORM 0220-FETCH-COBER-ACESSORIO. */

            M_0220_FETCH_COBER_ACESSORIO(true);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0250_99_SAIDA*/

        [StopWatch]
        /*" M-0500-DIVIDIR-PREMIO-CIRC-491 */
        private void M_0500_DIVIDIR_PREMIO_CIRC_491(bool isPerform = false)
        {
            /*" -1601- MOVE 'N' TO WFIM-COBER WFIM-CAREN */
            _.Move("N", WFIM_COBER, WFIM_CAREN);

            /*" -1603- PERFORM 0510-LER-COBERTURA-491. */

            M_0510_LER_COBERTURA_491(true);

            /*" -1605- PERFORM 0520-FETCH-COBERTURA-491. */

            M_0520_FETCH_COBERTURA_491(true);

            /*" -1606- IF (WFIM-COBER EQUAL 'S' ) */

            if ((WFIM_COBER == "S"))
            {

                /*" -1607- PERFORM 0510-LER-COBERTURA-491 */

                M_0510_LER_COBERTURA_491(true);

                /*" -1608- PERFORM 0520-FETCH-COBERTURA-491 */

                M_0520_FETCH_COBERTURA_491(true);

                /*" -1610- END-IF */
            }


            /*" -1611- IF (WFIM-COBER EQUAL 'S' ) */

            if ((WFIM_COBER == "S"))
            {

                /*" -1613- MOVE ZEROS TO WS-NUM-FAIXA-INICIAL WS-NUM-FAIXA-FINAL */
                _.Move(0, WS_NUM_FAIXA_INICIAL, WS_NUM_FAIXA_FINAL);

                /*" -1615- MOVE ZEROS TO WS-VLR-FAIXA-CS-INICIAL WS-VLR-FAIXA-CS-FINAL */
                _.Move(0, WS_VLR_FAIXA_CS_INICIAL, WS_VLR_FAIXA_CS_FINAL);

                /*" -1616- MOVE 100 TO WS-PCT-COB-PREMIO */
                _.Move(100, WS_PCT_COB_PREMIO);

                /*" -1617- MOVE LK-VLR-PREMIO TO WS-VLR-PCT-PREMIO */
                _.Move(PARAMETROS.LK_VLR_PREMIO, WS_VLR_PCT_PREMIO);

                /*" -1618- MOVE ZEROS TO WS-NUM-COB-CARENCIA */
                _.Move(0, WS_NUM_COB_CARENCIA);

                /*" -1620- MOVE SPACES TO WS-DES-COB-CARENCIA WS-NOM-GRUPO-COBERTURA */
                _.Move("", WS_DES_COB_CARENCIA, WS_NOM_GRUPO_COBERTURA);

                /*" -1622- MOVE WS-COD-COBER-BAS-491 TO WS-COBERTURA-491 */
                _.Move(WS_COD_COBER_BAS_491, WS_COBERTURA_491);

                /*" -1624- PERFORM 0090-SEARCH-TAB-DEPARA-491 */

                M_0090_SEARCH_TAB_DEPARA_491(true);

                /*" -1625- PERFORM 1510-LER-CARENCIA-491 */

                M_1510_LER_CARENCIA_491(true);

                /*" -1626- PERFORM 1520-FETCH-CARENCIA-491 */

                M_1520_FETCH_CARENCIA_491(true);

                /*" -1628- PERFORM 1550-PROCESSA-CARENCIA-491 UNTIL WFIM-CAREN = 'S' */

                while (!(WFIM_CAREN == "S"))
                {

                    M_1550_PROCESSA_CARENCIA_491(true);
                }

                /*" -1629- ELSE */
            }
            else
            {


                /*" -1632- PERFORM 0550-PROCESSA-COBERTURA-491 UNTIL WFIM-COBER = 'S' */

                while (!(WFIM_COBER == "S"))
                {

                    M_0550_PROCESSA_COBERTURA_491(true);
                }

                /*" -1633- PERFORM 0650-CLASSIFICA-COBERTURA-491 */

                M_0650_CLASSIFICA_COBERTURA_491(true);

                /*" -1635- END-IF. */
            }


            /*" -1636- PERFORM 2500-LER-MSG-HINT-491 */

            M_2500_LER_MSG_HINT_491(true);

            /*" -1637- PERFORM 2520-FETCH-MSG-HINT-491 */

            M_2520_FETCH_MSG_HINT_491(true);

            /*" -1638- PERFORM 2550-PROCESSA-MSG-HINT-491 UNTIL WFIM-CAREN = 'S' . */

            while (!(WFIM_CAREN == "S"))
            {

                M_2550_PROCESSA_MSG_HINT_491(true);
            }

        }

        [StopWatch]
        /*" M-0505-LER-MAX-IDADE-VLR-CS-491 */
        private void M_0505_LER_MAX_IDADE_VLR_CS_491(bool isPerform = false)
        {
            /*" -1667- PERFORM M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1 */

            M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1();

            /*" -1670- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1671- MOVE 'ERRO MAX IDADE COBER 491 ' TO LK-MENSAGEM */
                _.Move("ERRO MAX IDADE COBER 491 ", PARAMETROS.LK_MENSAGEM);

                /*" -1672- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1674- END-IF. */
            }


            /*" -1675- IF (WS-IDADE > WS-MAX-IDADE) */

            if ((WS_IDADE > WS_MAX_IDADE))
            {

                /*" -1676- MOVE WS-MAX-IDADE TO WS-IDADE */
                _.Move(WS_MAX_IDADE, WS_IDADE);

                /*" -1678- END-IF. */
            }


            /*" -1680- MOVE WS-VLR-COB-BASICA TO WS-VLR-COB-CONSULTA */
            _.Move(WS_VLR_COB_BASICA, WS_VLR_COB_CONSULTA);

            /*" -1703- PERFORM M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2 */

            M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2();

            /*" -1706- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1707- MOVE 'ERRO MAX VLR CS COBER 491 ' TO LK-MENSAGEM */
                _.Move("ERRO MAX VLR CS COBER 491 ", PARAMETROS.LK_MENSAGEM);

                /*" -1708- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1710- END-IF. */
            }


            /*" -1711- IF (WS-VLR-COB-CONSULTA > WS-MAX-VLR-CONSULTA) */

            if ((WS_VLR_COB_CONSULTA > WS_MAX_VLR_CONSULTA))
            {

                /*" -1712- MOVE WS-MAX-VLR-CONSULTA TO WS-VLR-COB-CONSULTA */
                _.Move(WS_MAX_VLR_CONSULTA, WS_VLR_COB_CONSULTA);

                /*" -1712- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0505-LER-MAX-IDADE-VLR-CS-491-DB-SELECT-1 */
        public void M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1()
        {
            /*" -1667- EXEC SQL SELECT VALUE(MAX(C.NUM_FAIXA_FINAL), 18) INTO :WS-MAX-IDADE FROM SEGUROS.VG_APOLICE_COB_GAR A, SEGUROS.VG_GRUPO_COB_CS_ETARIA B, SEGUROS.VG_FAIXA_ETARIA C, SEGUROS.VG_FAIXA_CAP_SEGUR D, SEGUROS.VG_GARANTIA E, SEGUROS.VG_GRUPO_COBERTURA F WHERE A.NUM_APOLICE = :WS-NUM-APOLICE-GAR AND A.COD_SUBGRUPO = :WS-COD-SUBGRUPO-GAR AND A.COD_PRODUTO = :WS-PRODUTO AND A.IND_TIPO_COB_GAR = 'PF' AND A.IND_PERIODO_FAT = 0 AND A.SEQ_GRUPO_COBERTURA = B.SEQ_GRUPO_COBERTURA AND A.SEQ_GRUPO_COBERTURA = F.SEQ_GRUPO_COBERTURA AND A.NUM_GARANTIA = B.NUM_GARANTIA AND A.NUM_GARANTIA = E.NUM_GARANTIA AND A.DTA_INI_VIGENCIA = B.DTA_INI_VIGENCIA AND B.SEQ_FAIXA_CAP_SEGUR = D.SEQ_FAIXA_CAP_SEGUR AND B.SEQ_FAIXA_ETARIA = C.SEQ_FAIXA_ETARIA WITH UR END-EXEC. */

            var m_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1_Query1 = new M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1_Query1()
            {
                WS_COD_SUBGRUPO_GAR = WS_COD_SUBGRUPO_GAR.ToString(),
                WS_NUM_APOLICE_GAR = WS_NUM_APOLICE_GAR.ToString(),
                WS_PRODUTO = WS_PRODUTO.ToString(),
            };

            var executed_1 = M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1_Query1.Execute(m_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_IDADE, WS_MAX_IDADE);
            }


        }

        [StopWatch]
        /*" M-0510-LER-COBERTURA-491 */
        private void M_0510_LER_COBERTURA_491(bool isPerform = false)
        {
            /*" -1720- PERFORM 0505-LER-MAX-IDADE-VLR-CS-491 */

            M_0505_LER_MAX_IDADE_VLR_CS_491(true);

            /*" -1721- MOVE WS-VLR-COB-CONSULTA TO WS-VALOR */
            _.Move(WS_VLR_COB_CONSULTA, FILLER_5.WS_VALORES_AX.WS_VALOR);

            /*" -1722- DISPLAY 'VG0711S - MOVE 08 PARA WS-VALOR ' */
            _.Display($"VG0711S - MOVE 08 PARA WS-VALOR ");

            /*" -1723- DISPLAY 'WS-VALOR = ' WS-VALOR */
            _.Display($"WS-VALOR = {FILLER_5.WS_VALORES_AX.WS_VALOR}");

            /*" -1724- DISPLAY 'WS-VLR-COB-CONSULTA = ' WS-VLR-COB-CONSULTA */
            _.Display($"WS-VLR-COB-CONSULTA = {WS_VLR_COB_CONSULTA}");

            /*" -1727- MOVE LK-VLR-PREMIO TO WS-VALOR-1 */
            _.Move(PARAMETROS.LK_VLR_PREMIO, FILLER_5.WS_VALORES_AX.WS_VALOR_1);

            /*" -1728- DISPLAY 'DADOS DOS CAMPOS ACESSO CURSOR COBER491----' */
            _.Display($"DADOS DOS CAMPOS ACESSO CURSOR COBER491----");

            /*" -1729- DISPLAY 'WS-NUM-APOLICE-GAR  = ' WS-NUM-APOLICE-GAR */
            _.Display($"WS-NUM-APOLICE-GAR  = {WS_NUM_APOLICE_GAR}");

            /*" -1730- DISPLAY 'WS-COD-SUBGRUPO-GAR = ' WS-COD-SUBGRUPO-GAR */
            _.Display($"WS-COD-SUBGRUPO-GAR = {WS_COD_SUBGRUPO_GAR}");

            /*" -1731- DISPLAY 'WS-PRODUTO          = ' WS-PRODUTO */
            _.Display($"WS-PRODUTO          = {WS_PRODUTO}");

            /*" -1732- DISPLAY 'WS-IDADE            = ' WS-IDADE */
            _.Display($"WS-IDADE            = {WS_IDADE}");

            /*" -1733- DISPLAY 'WS-IDADE            = ' WS-IDADE */
            _.Display($"WS-IDADE            = {WS_IDADE}");

            /*" -1734- DISPLAY 'WS-VLR-COB-CONSULTA = ' WS-VLR-COB-CONSULTA */
            _.Display($"WS-VLR-COB-CONSULTA = {WS_VLR_COB_CONSULTA}");

            /*" -1735- DISPLAY 'WS-VLR-COB-CONSULTA = ' WS-VLR-COB-CONSULTA */
            _.Display($"WS-VLR-COB-CONSULTA = {WS_VLR_COB_CONSULTA}");

            /*" -1737- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -1775- PERFORM M_0510_LER_COBERTURA_491_DB_DECLARE_1 */

            M_0510_LER_COBERTURA_491_DB_DECLARE_1();

            /*" -1777- PERFORM M_0510_LER_COBERTURA_491_DB_OPEN_1 */

            M_0510_LER_COBERTURA_491_DB_OPEN_1();

            /*" -1780- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1781- MOVE 'ERRO NO OPEN CURSOR COBER 491 ' TO LK-MENSAGEM */
                _.Move("ERRO NO OPEN CURSOR COBER 491 ", PARAMETROS.LK_MENSAGEM);

                /*" -1782- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1782- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0510-LER-COBERTURA-491-DB-OPEN-1 */
        public void M_0510_LER_COBERTURA_491_DB_OPEN_1()
        {
            /*" -1777- EXEC SQL OPEN COBER491 END-EXEC. */

            COBER491.Open();

        }

        [StopWatch]
        /*" M-1510-LER-CARENCIA-491-DB-DECLARE-1 */
        public void M_1510_LER_CARENCIA_491_DB_DECLARE_1()
        {
            /*" -2254- EXEC SQL DECLARE CAREN491 CURSOR FOR SELECT E.NUM_GARANTIA, G.DES_CARENCIA_MSG FROM SEGUROS.VG_APOLICE_COB_GAR A, SEGUROS.VG_GRUPO_COB_CS_ETARIA B, SEGUROS.VG_FAIXA_ETARIA C, SEGUROS.VG_FAIXA_CAP_SEGUR D, SEGUROS.VG_GARANTIA E, SEGUROS.VG_GRUPO_COBERTURA F, SEGUROS.VG_CARENCIA_MSG G WHERE A.NUM_APOLICE = :WS-NUM-APOLICE AND A.COD_PRODUTO = :WS-PRODUTO AND A.IND_TIPO_COB_GAR = 'CC' AND A.SEQ_GRUPO_COBERTURA = B.SEQ_GRUPO_COBERTURA AND A.SEQ_GRUPO_COBERTURA = F.SEQ_GRUPO_COBERTURA AND A.NUM_GARANTIA = B.NUM_GARANTIA AND A.NUM_GARANTIA = E.NUM_GARANTIA AND A.DTA_INI_VIGENCIA = B.DTA_INI_VIGENCIA AND B.SEQ_FAIXA_CAP_SEGUR = D.SEQ_FAIXA_CAP_SEGUR AND B.SEQ_FAIXA_ETARIA = C.SEQ_FAIXA_ETARIA AND A.SEQ_CARENCIA = G.SEQ_CARENCIA_MSG WITH UR END-EXEC. */
            CAREN491 = new VG0711S_CAREN491(true);
            string GetQuery_CAREN491()
            {
                var query = @$"SELECT E.NUM_GARANTIA
							, 
							G.DES_CARENCIA_MSG 
							FROM SEGUROS.VG_APOLICE_COB_GAR A
							, 
							SEGUROS.VG_GRUPO_COB_CS_ETARIA B
							, 
							SEGUROS.VG_FAIXA_ETARIA C
							, 
							SEGUROS.VG_FAIXA_CAP_SEGUR D
							, 
							SEGUROS.VG_GARANTIA E
							, 
							SEGUROS.VG_GRUPO_COBERTURA F
							, 
							SEGUROS.VG_CARENCIA_MSG G 
							WHERE A.NUM_APOLICE = '{WS_NUM_APOLICE}' 
							AND A.COD_PRODUTO = '{WS_PRODUTO}' 
							AND A.IND_TIPO_COB_GAR = 'CC' 
							AND A.SEQ_GRUPO_COBERTURA = B.SEQ_GRUPO_COBERTURA 
							AND A.SEQ_GRUPO_COBERTURA = F.SEQ_GRUPO_COBERTURA 
							AND A.NUM_GARANTIA = B.NUM_GARANTIA 
							AND A.NUM_GARANTIA = E.NUM_GARANTIA 
							AND A.DTA_INI_VIGENCIA = B.DTA_INI_VIGENCIA 
							AND B.SEQ_FAIXA_CAP_SEGUR = D.SEQ_FAIXA_CAP_SEGUR 
							AND B.SEQ_FAIXA_ETARIA = C.SEQ_FAIXA_ETARIA 
							AND A.SEQ_CARENCIA = G.SEQ_CARENCIA_MSG";

                return query;
            }
            CAREN491.GetQueryEvent += GetQuery_CAREN491;

        }

        [StopWatch]
        /*" M-0505-LER-MAX-IDADE-VLR-CS-491-DB-SELECT-2 */
        public void M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2()
        {
            /*" -1703- EXEC SQL SELECT VALUE(MAX(D.VLR_FAIXA_CS_FINAL), :WS-VLR-COB-BASICA) INTO :WS-MAX-VLR-CONSULTA FROM SEGUROS.VG_APOLICE_COB_GAR A, SEGUROS.VG_GRUPO_COB_CS_ETARIA B, SEGUROS.VG_FAIXA_ETARIA C, SEGUROS.VG_FAIXA_CAP_SEGUR D, SEGUROS.VG_GARANTIA E, SEGUROS.VG_GRUPO_COBERTURA F WHERE A.NUM_APOLICE = :WS-NUM-APOLICE-GAR AND A.COD_SUBGRUPO = :WS-COD-SUBGRUPO-GAR AND A.COD_PRODUTO = :WS-PRODUTO AND A.IND_TIPO_COB_GAR = 'PF' AND A.IND_PERIODO_FAT = 0 AND A.SEQ_GRUPO_COBERTURA = B.SEQ_GRUPO_COBERTURA AND A.SEQ_GRUPO_COBERTURA = F.SEQ_GRUPO_COBERTURA AND A.NUM_GARANTIA = B.NUM_GARANTIA AND A.NUM_GARANTIA = E.NUM_GARANTIA AND A.DTA_INI_VIGENCIA = B.DTA_INI_VIGENCIA AND B.SEQ_FAIXA_CAP_SEGUR = D.SEQ_FAIXA_CAP_SEGUR AND B.SEQ_FAIXA_ETARIA = C.SEQ_FAIXA_ETARIA WITH UR END-EXEC. */

            var m_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1 = new M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1()
            {
                WS_COD_SUBGRUPO_GAR = WS_COD_SUBGRUPO_GAR.ToString(),
                WS_NUM_APOLICE_GAR = WS_NUM_APOLICE_GAR.ToString(),
                WS_VLR_COB_BASICA = WS_VLR_COB_BASICA.ToString(),
                WS_PRODUTO = WS_PRODUTO.ToString(),
            };

            var executed_1 = M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1.Execute(m_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_VLR_CONSULTA, WS_MAX_VLR_CONSULTA);
            }


        }

        [StopWatch]
        /*" M-0520-FETCH-COBERTURA-491 */
        private void M_0520_FETCH_COBERTURA_491(bool isPerform = false)
        {
            /*" -1791- INITIALIZE VG091-DES-COB-CARENCIA */
            _.Initialize(
                VG091_DES_COB_CARENCIA
            );

            /*" -1805- PERFORM M_0520_FETCH_COBERTURA_491_DB_FETCH_1 */

            M_0520_FETCH_COBERTURA_491_DB_FETCH_1();

            /*" -1808- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1809- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1810- MOVE 'S' TO WFIM-COBER */
                    _.Move("S", WFIM_COBER);

                    /*" -1810- PERFORM M_0520_FETCH_COBERTURA_491_DB_CLOSE_1 */

                    M_0520_FETCH_COBERTURA_491_DB_CLOSE_1();

                    /*" -1812- ELSE */
                }
                else
                {


                    /*" -1813- MOVE 'ERRO FETCH CURSOR COBER 491 ' TO LK-MENSAGEM */
                    _.Move("ERRO FETCH CURSOR COBER 491 ", PARAMETROS.LK_MENSAGEM);

                    /*" -1814- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1815- END-IF */
                }


                /*" -1815- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0520-FETCH-COBERTURA-491-DB-FETCH-1 */
        public void M_0520_FETCH_COBERTURA_491_DB_FETCH_1()
        {
            /*" -1805- EXEC SQL FETCH COBER491 INTO :VG087-NOM-GRUPO-COBERTURA , :VG087-IND-CONJUGE , :VGARANTI-NUM-GARANTIA , :VGARANTI-DES-GARANTIA , :VG085-NUM-FAIXA-INICIAL , :VG085-NUM-FAIXA-FINAL , :VG086-VLR-FAIXA-CS-INICIAL , :VG086-VLR-FAIXA-CS-FINAL , :VG088-PCT-COB-PREMIO , :VG088-DTA-INI-VIGENCIA-GRUPO, :VG088-DTA-FIM-VIGENCIA-GRUPO, :VG091-DES-COB-CARENCIA END-EXEC. */

            if (COBER491.Fetch())
            {
                _.Move(COBER491.VG087_NOM_GRUPO_COBERTURA, VG087.DCLVG_GRUPO_COBERTURA.VG087_NOM_GRUPO_COBERTURA);
                _.Move(COBER491.VG087_IND_CONJUGE, VG087.DCLVG_GRUPO_COBERTURA.VG087_IND_CONJUGE);
                _.Move(COBER491.VGARANTI_NUM_GARANTIA, VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA);
                _.Move(COBER491.VGARANTI_DES_GARANTIA, VGARANTI.DCLVG_GARANTIA.VGARANTI_DES_GARANTIA);
                _.Move(COBER491.VG085_NUM_FAIXA_INICIAL, VG085.DCLVG_FAIXA_ETARIA.VG085_NUM_FAIXA_INICIAL);
                _.Move(COBER491.VG085_NUM_FAIXA_FINAL, VG085.DCLVG_FAIXA_ETARIA.VG085_NUM_FAIXA_FINAL);
                _.Move(COBER491.VG086_VLR_FAIXA_CS_INICIAL, VG086.DCLVG_FAIXA_CAP_SEGUR.VG086_VLR_FAIXA_CS_INICIAL);
                _.Move(COBER491.VG086_VLR_FAIXA_CS_FINAL, VG086.DCLVG_FAIXA_CAP_SEGUR.VG086_VLR_FAIXA_CS_FINAL);
                _.Move(COBER491.VG088_PCT_COB_PREMIO, VG088.DCLVG_GRUPO_COB_CS_ETARIA.VG088_PCT_COB_PREMIO);
                _.Move(COBER491.VG088_DTA_INI_VIGENCIA_GRUPO, VG088.DCLVG_GRUPO_COB_CS_ETARIA.VG088_DTA_INI_VIGENCIA_GRUPO);
                _.Move(COBER491.VG088_DTA_FIM_VIGENCIA_GRUPO, VG088.DCLVG_GRUPO_COB_CS_ETARIA.VG088_DTA_FIM_VIGENCIA_GRUPO);
                _.Move(COBER491.VG091_DES_COB_CARENCIA, VG091_DES_COB_CARENCIA);
            }

        }

        [StopWatch]
        /*" M-0520-FETCH-COBERTURA-491-DB-CLOSE-1 */
        public void M_0520_FETCH_COBERTURA_491_DB_CLOSE_1()
        {
            /*" -1810- EXEC SQL CLOSE COBER491 END-EXEC */

            COBER491.Close();

        }

        [StopWatch]
        /*" M-0550-PROCESSA-COBERTURA-491 */
        private void M_0550_PROCESSA_COBERTURA_491(bool isPerform = false)
        {
            /*" -1824- IF (VG091-DES-COB-CARENCIA-LEN > ZEROS) AND (VG091-DES-COB-CARENCIA-TEXT NOT EQUAL ' ' ) */

            if ((VG091_DES_COB_CARENCIA.VG091_DES_COB_CARENCIA_LEN > 00) && (VG091_DES_COB_CARENCIA.VG091_DES_COB_CARENCIA_TEXT != " "))
            {

                /*" -1825- ADD 1 TO WS-CONTA-COB-CARENCIA */
                WS_CONTA_COB_CARENCIA.Value = WS_CONTA_COB_CARENCIA + 1;

                /*" -1827- MOVE VG091-DES-COB-CARENCIA-TEXT TO WS-DES-COB-CARENCIA */
                _.Move(VG091_DES_COB_CARENCIA.VG091_DES_COB_CARENCIA_TEXT, WS_DES_COB_CARENCIA);

                /*" -1828- MOVE WS-CONTA-COB-CARENCIA TO WS-NUM-COB-CARENCIA */
                _.Move(WS_CONTA_COB_CARENCIA, WS_NUM_COB_CARENCIA);

                /*" -1829- ELSE */
            }
            else
            {


                /*" -1830- MOVE ZEROS TO WS-NUM-COB-CARENCIA */
                _.Move(0, WS_NUM_COB_CARENCIA);

                /*" -1832- MOVE SPACES TO WS-DES-COB-CARENCIA */
                _.Move("", WS_DES_COB_CARENCIA);

                /*" -1834- END-IF */
            }


            /*" -1837- COMPUTE WS-VLR-PCT-PREMIO ROUNDED = (LK-VLR-PREMIO * VG088-PCT-COB-PREMIO) / 100 */
            WS_VLR_PCT_PREMIO.Value = (PARAMETROS.LK_VLR_PREMIO * VG088.DCLVG_GRUPO_COB_CS_ETARIA.VG088_PCT_COB_PREMIO) / 100f;

            /*" -1838- MOVE VG085-NUM-FAIXA-INICIAL TO WS-NUM-FAIXA-INICIAL */
            _.Move(VG085.DCLVG_FAIXA_ETARIA.VG085_NUM_FAIXA_INICIAL, WS_NUM_FAIXA_INICIAL);

            /*" -1839- MOVE VG085-NUM-FAIXA-FINAL TO WS-NUM-FAIXA-FINAL */
            _.Move(VG085.DCLVG_FAIXA_ETARIA.VG085_NUM_FAIXA_FINAL, WS_NUM_FAIXA_FINAL);

            /*" -1840- MOVE VG086-VLR-FAIXA-CS-INICIAL TO WS-VLR-FAIXA-CS-INICIAL */
            _.Move(VG086.DCLVG_FAIXA_CAP_SEGUR.VG086_VLR_FAIXA_CS_INICIAL, WS_VLR_FAIXA_CS_INICIAL);

            /*" -1841- MOVE VG086-VLR-FAIXA-CS-FINAL TO WS-VLR-FAIXA-CS-FINAL */
            _.Move(VG086.DCLVG_FAIXA_CAP_SEGUR.VG086_VLR_FAIXA_CS_FINAL, WS_VLR_FAIXA_CS_FINAL);

            /*" -1842- MOVE VG088-PCT-COB-PREMIO TO WS-PCT-COB-PREMIO */
            _.Move(VG088.DCLVG_GRUPO_COB_CS_ETARIA.VG088_PCT_COB_PREMIO, WS_PCT_COB_PREMIO);

            /*" -1843- MOVE VGARANTI-NUM-GARANTIA TO WS-COBERTURA-491 */
            _.Move(VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA, WS_COBERTURA_491);

            /*" -1844- MOVE VGARANTI-DES-GARANTIA TO WS-DES-GARANTIA-491 */
            _.Move(VGARANTI.DCLVG_GARANTIA.VGARANTI_DES_GARANTIA, WS_DES_GARANTIA_491);

            /*" -1846- MOVE VG087-NOM-GRUPO-COBERTURA TO WS-NOM-GRUPO-COBERTURA */
            _.Move(VG087.DCLVG_GRUPO_COBERTURA.VG087_NOM_GRUPO_COBERTURA, WS_NOM_GRUPO_COBERTURA);

            /*" -1848- PERFORM 0090-SEARCH-TAB-DEPARA-491 */

            M_0090_SEARCH_TAB_DEPARA_491(true);

            /*" -1848- PERFORM 0520-FETCH-COBERTURA-491. */

            M_0520_FETCH_COBERTURA_491(true);

        }

        [StopWatch]
        /*" M-0600-CARREGAR-TAB-SAIDA */
        private void M_0600_CARREGAR_TAB_SAIDA(bool isPerform = false)
        {
            /*" -1860- EVALUATE WTAB-NUM-GARANTIA-491(WS-I) */
            switch (FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_GARANTIA_491.Value)
            {

                /*" -1865- WHEN  05 */
                case 05:

                    /*" -1868- MOVE WS-PRODUTO TO W88-PROD-VIDA-MULHER */
                    _.Move(WS_PRODUTO, W88_PROD_VIDA_MULHER);

                    /*" -1874- IF W88-PROD-VIDA-MULHER NOT = 9327 AND JVPRD9327 AND 9328 AND JVPRD9328 AND 9334 AND JVPRD9334 AND 9356 AND JVPRD9356 AND 9357 AND JVPRD9357 AND 9358 AND JVPRD9358 */

                    if (!W88_PROD_VIDA_MULHER.In("9327", JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9356", JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString()))
                    {

                        /*" -1875- MOVE TAB-DES-COBER(26) TO WTAB-DES-GARANTIA(WS-I) */
                        _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[26].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                        /*" -1876- END-IF */
                    }


                    /*" -1880- WHEN  18 */
                    break;
                case 18:

                    /*" -1881- MOVE TAB-DES-COBER(19) TO WTAB-DES-GARANTIA(WS-I) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[19].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                    /*" -1885- WHEN  23 */
                    break;
                case 23:

                    /*" -1886- MOVE TAB-DES-COBER(17) TO WTAB-DES-GARANTIA(WS-I) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[17].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                    /*" -1890- WHEN  25 */
                    break;
                case 25:

                    /*" -1891- MOVE TAB-DES-COBER(20) TO WTAB-DES-GARANTIA(WS-I) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[20].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                    /*" -1895- WHEN  28 */
                    break;
                case 28:

                    /*" -1896- MOVE TAB-DES-COBER(21) TO WTAB-DES-GARANTIA(WS-I) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[21].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                    /*" -1901- WHEN  29 */
                    break;
                case 29:

                    /*" -1902- MOVE TAB-DES-COBER(22) TO WTAB-DES-GARANTIA(WS-I) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[22].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                    /*" -1906- WHEN  30 */
                    break;
                case 30:

                    /*" -1907- MOVE TAB-DES-COBER(23) TO WTAB-DES-GARANTIA(WS-I) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[23].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                    /*" -1911- WHEN  31 */
                    break;
                case 31:

                    /*" -1912- MOVE TAB-DES-COBER(24) TO WTAB-DES-GARANTIA(WS-I) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[24].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                    /*" -1916- WHEN  32 */
                    break;
                case 32:

                    /*" -1917- MOVE TAB-DES-COBER(25) TO WTAB-DES-GARANTIA(WS-I) */
                    _.Move(FILLER_5.WS_VALORES_AX.TAB_AUX.TAB_COBER_BASICA[25].TAB_DES_COBER, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA);

                    /*" -1919- END-EVALUATE */
                    break;
            }


            /*" -1921- MOVE WTAB-TIPO-GARANTIA (WS-I) TO LK-NOM-GRUPO-COBERTURA (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_TIPO_GARANTIA, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NOM_GRUPO_COBERTURA);

            /*" -1923- MOVE WTAB-NUM-GARANTIA (WS-I) TO LK-NUM-GARANTIA (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_GARANTIA, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_GARANTIA);

            /*" -1925- MOVE WTAB-NUM-GARANTIA-491 (WS-I) TO LK-NUM-GARANTIA-491 (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_GARANTIA_491, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_GARANTIA_491);

            /*" -1927- MOVE WTAB-DES-GARANTIA (WS-I) TO LK-DES-GARANTIA (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_GARANTIA, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_DES_GARANTIA);

            /*" -1929- MOVE WTAB-NUM-FAIXA-INICIAL (WS-I) TO LK-NUM-FAIXA-INICIAL (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_FAIXA_INICIAL, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_FAIXA_INICIAL);

            /*" -1931- MOVE WTAB-NUM-FAIXA-FINAL (WS-I) TO LK-NUM-FAIXA-FINAL (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_FAIXA_FINAL, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_FAIXA_FINAL);

            /*" -1933- MOVE WTAB-VLR-FAIXA-CS-INICIAL(WS-I) TO LK-VLR-FAIXA-CS-INICIAL (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_FAIXA_CS_INICIAL, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_FAIXA_CS_INICIAL);

            /*" -1935- MOVE WTAB-VLR-FAIXA-CS-FINAL (WS-I) TO LK-VLR-FAIXA-CS-FINAL (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_FAIXA_CS_FINAL, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_FAIXA_CS_FINAL);

            /*" -1937- MOVE WTAB-PCT-COB-PREMIO (WS-I) TO LK-PCT-COB-PREMIO (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_PCT_COB_PREMIO, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_PCT_COB_PREMIO);

            /*" -1939- MOVE WTAB-VLR-CAP-DESC (WS-I) TO LK-VLR-CAP-DESC (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_CAP_DESC, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_CAP_DESC);

            /*" -1941- MOVE WTAB-VLR-CAP-SEGURADO (WS-I) TO LK-VLR-CAP-SEGURADO (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_CAP_SEGURADO, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_CAP_SEGURADO);

            /*" -1943- MOVE WTAB-VLR-PCT-PREMIO (WS-I) TO LK-VLR-PCT-PREMIO (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_VLR_PCT_PREMIO, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_VLR_PCT_PREMIO);

            /*" -1945- MOVE WTAB-NUM-COB-CARENCIA (WS-I) TO LK-NUM-COB-CARENCIA (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_NUM_COB_CARENCIA, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_NUM_COB_CARENCIA);

            /*" -1947- MOVE WTAB-DES-COB-CARENCIA (WS-I) TO LK-DES-COB-CARENCIA (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_COB_CARENCIA, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_DES_COB_CARENCIA);

            /*" -1949- MOVE WTAB-DES-MSG-HINT (WS-I) TO LK-DES-MSG-HINT (WS-I) */
            _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I].WTAB_DES_MSG_HINT, PARAMETROS.LK_TAB_COB_PREMIO[WS_I].LK_DES_MSG_HINT);

            /*" -1949- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0610_DISPLAY_TAB_SAIDA*/

        [StopWatch]
        /*" M-0650-CLASSIFICA-COBERTURA-491 */
        private void M_0650_CLASSIFICA_COBERTURA_491(bool isPerform = false)
        {
            /*" -1974- PERFORM VARYING WS-IND-J FROM 1 BY 1 UNTIL WS-IND-J > 12 */

            for (WS_IND_J.Value = 1; !(WS_IND_J > 12); WS_IND_J.Value += 1)
            {

                /*" -1976- COMPUTE WS-IND-K = WS-IND-J + 1 */
                WS_IND_K.Value = WS_IND_J + 1;

                /*" -1979- PERFORM VARYING WS-IND-L FROM WS-IND-K BY 1 UNTIL WS-IND-L > 12 */

                for (WS_IND_L.Value = WS_IND_K; !(WS_IND_L > 12); WS_IND_L.Value += 1)
                {

                    /*" -1982- IF ((WTAB-VLR-PCT-PREMIO(WS-IND-J) < WTAB-VLR-PCT-PREMIO(WS-IND-L)) AND (WTAB-VLR-CAP-SEGURADO(WS-IND-J) EQUAL ZEROS)) */

                    if (((FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_J].WTAB_VLR_PCT_PREMIO < FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_L].WTAB_VLR_PCT_PREMIO) && (FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_J].WTAB_VLR_CAP_SEGURADO == 00)))
                    {

                        /*" -1984- MOVE WTAB-COB-PREMIO(WS-IND-J) TO WSORT-COB-PREMIO */
                        _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_J], WSORT_COB_PREMIO);

                        /*" -1986- MOVE WTAB-COB-PREMIO(WS-IND-L) TO WTAB-COB-PREMIO(WS-IND-J) */
                        _.Move(FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_L], FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_J]);

                        /*" -1988- MOVE WSORT-COB-PREMIO TO WTAB-COB-PREMIO(WS-IND-L) */
                        _.Move(WSORT_COB_PREMIO, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_L]);

                        /*" -1989- END-IF */
                    }


                    /*" -1990- END-PERFORM */
                }

                /*" -1992- END-PERFORM . */
            }

            /*" -1995- MOVE ZEROS TO WS-VLR-PREMIO-TOT WS-I-ULT */
            _.Move(0, WS_VLR_PREMIO_TOT, WS_I_ULT);

            /*" -1997- PERFORM VARYING WS-IND-J FROM 1 BY 1 UNTIL WS-IND-J > 12 */

            for (WS_IND_J.Value = 1; !(WS_IND_J > 12); WS_IND_J.Value += 1)
            {

                /*" -1998- IF (WTAB-VLR-PCT-PREMIO(WS-IND-J) > ZEROS) */

                if ((FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_J].WTAB_VLR_PCT_PREMIO > 00))
                {

                    /*" -2001- COMPUTE WS-VLR-PREMIO-TOT = WS-VLR-PREMIO-TOT + WTAB-VLR-PCT-PREMIO(WS-IND-J) */
                    WS_VLR_PREMIO_TOT.Value = WS_VLR_PREMIO_TOT + FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_IND_J].WTAB_VLR_PCT_PREMIO.Value;

                    /*" -2002- IF (WS-I-ULT EQUAL ZEROS) */

                    if ((WS_I_ULT == 00))
                    {

                        /*" -2003- MOVE WS-IND-J TO WS-I-ULT */
                        _.Move(WS_IND_J, WS_I_ULT);

                        /*" -2004- END-IF */
                    }


                    /*" -2005- END-IF */
                }


                /*" -2007- END-PERFORM */
            }

            /*" -2010- COMPUTE WS-VLR-PREMIO-RESTO = (LK-VLR-PREMIO - WS-VLR-PREMIO-TOT) */
            WS_VLR_PREMIO_RESTO.Value = (PARAMETROS.LK_VLR_PREMIO - WS_VLR_PREMIO_TOT);

            /*" -2011- IF (WS-VLR-PREMIO-RESTO NOT EQUAL ZEROS) */

            if ((WS_VLR_PREMIO_RESTO != 00))
            {

                /*" -2014- COMPUTE WTAB-VLR-PCT-PREMIO(WS-I-ULT) = (WTAB-VLR-PCT-PREMIO(WS-I-ULT) + WS-VLR-PREMIO-RESTO) */
                FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I_ULT].WTAB_VLR_PCT_PREMIO.Value = (FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WS_I_ULT].WTAB_VLR_PCT_PREMIO.Value + WS_VLR_PREMIO_RESTO);

                /*" -2014- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0700-SELECT-APOLICE */
        private void M_0700_SELECT_APOLICE(bool isPerform = false)
        {
            /*" -2035- PERFORM M_0700_SELECT_APOLICE_DB_SELECT_1 */

            M_0700_SELECT_APOLICE_DB_SELECT_1();

            /*" -2038- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2039- MOVE 'ERRO NO ACESSO A APOLICE/RAMO ' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A APOLICE/RAMO ", PARAMETROS.LK_MENSAGEM);

                /*" -2040- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2040- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0700-SELECT-APOLICE-DB-SELECT-1 */
        public void M_0700_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -2035- EXEC SQL SELECT A.COD_MODALIDADE, A.RAMO_EMISSOR, B.PCT_IOCC_RAMO INTO :WS-MODALIDA, :WS-RAMO, :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.APOLICES A, SEGUROS.RAMO_COMPLEMENTAR B WHERE A.NUM_APOLICE = :WS-NUM-APOLICE AND A.RAMO_EMISSOR = B.RAMO_EMISSOR AND B.DATA_INIVIGENCIA <= :WS-SISTEMA-DTMOVABE AND B.DATA_TERVIGENCIA >= :WS-SISTEMA-DTMOVABE FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var m_0700_SELECT_APOLICE_DB_SELECT_1_Query1 = new M_0700_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                WS_SISTEMA_DTMOVABE = WS_SISTEMA_DTMOVABE.ToString(),
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0700_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(m_0700_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MODALIDA, WS_MODALIDA);
                _.Move(executed_1.WS_RAMO, WS_RAMO);
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }

        [StopWatch]
        /*" M-0722-UPDATE-PAGA-IOF */
        private void M_0722_UPDATE_PAGA_IOF(bool isPerform = false)
        {
            /*" -2051- PERFORM M_0722_UPDATE_PAGA_IOF_DB_UPDATE_1 */

            M_0722_UPDATE_PAGA_IOF_DB_UPDATE_1();

            /*" -2054- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2055- MOVE 'ERRO NO UPDATE IOF SEGURADOS_VGAP ' TO LK-MENSAGEM */
                _.Move("ERRO NO UPDATE IOF SEGURADOS_VGAP ", PARAMETROS.LK_MENSAGEM);

                /*" -2056- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2056- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0722-UPDATE-PAGA-IOF-DB-UPDATE-1 */
        public void M_0722_UPDATE_PAGA_IOF_DB_UPDATE_1()
        {
            /*" -2051- EXEC SQL UPDATE SEGUROS.SUBGRUPOS_VGAP SET IND_IOF = 'S' WHERE NUM_APOLICE = :WS-NUM-APOLICE AND COD_SUBGRUPO = :WS-COD-SUBGRUPO END-EXEC. */

            var m_0722_UPDATE_PAGA_IOF_DB_UPDATE_1_Update1 = new M_0722_UPDATE_PAGA_IOF_DB_UPDATE_1_Update1()
            {
                WS_COD_SUBGRUPO = WS_COD_SUBGRUPO.ToString(),
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
            };

            M_0722_UPDATE_PAGA_IOF_DB_UPDATE_1_Update1.Execute(m_0722_UPDATE_PAGA_IOF_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0800-SELECT-SEGURVGA */
        private void M_0800_SELECT_SEGURVGA(bool isPerform = false)
        {
            /*" -2100- PERFORM M_0800_SELECT_SEGURVGA_DB_SELECT_1 */

            M_0800_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -2103- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2104- MOVE 'ERRO NO ACESSO A SEGURADOS_VGAP ' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A SEGURADOS_VGAP ", PARAMETROS.LK_MENSAGEM);

                /*" -2105- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2107- END-IF. */
            }


            /*" -2108- MOVE PRODUVG-COD-PRODUTO TO WS-PRODUTO */
            _.Move(PRODUVG_COD_PRODUTO, WS_PRODUTO);

            /*" -2108- MOVE PROPOVA-COD-PRODUTO TO WS-PROD-SEGURA-PRECO. */
            _.Move(PROPOVA_COD_PRODUTO, WS_AREA_SEGURA_PRECO_AUX.WS_PROD_SEGURA_PRECO);

        }

        [StopWatch]
        /*" M-0800-SELECT-SEGURVGA-DB-SELECT-1 */
        public void M_0800_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -2100- EXEC SQL SELECT A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_ITEM, A.OCORR_HISTORICO, B.COD_PRODUTO, D.COD_PRODUTO, VALUE(C.IND_IOF, 'S' ), B.NUM_CERTIFICADO, C.PERI_FATURAMENTO, D.ORIG_PRODU INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO, :PROPOVA-COD-PRODUTO, :PRODUVG-COD-PRODUTO, :V0SUBG-IND-IOF, :PROPOVA-NUM-CERTIFICADO, :SEGVGAP-PERI-PAGAMENTO, :PRODUVG-ORIG-PRODU FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PROPOSTAS_VA B, SEGUROS.SUBGRUPOS_VGAP C, SEGUROS.PRODUTOS_VG D WHERE A.NUM_CERTIFICADO = :WS-NUM-CERTIFICADO AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.TIPO_SEGURADO = '1' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.NUM_APOLICE = C.NUM_APOLICE AND A.COD_SUBGRUPO = C.COD_SUBGRUPO AND A.NUM_APOLICE = D.NUM_APOLICE AND A.COD_SUBGRUPO = D.COD_SUBGRUPO ORDER BY A.COD_SUBGRUPO DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var m_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                WS_NUM_CERTIFICADO = WS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(m_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG_COD_PRODUTO);
                _.Move(executed_1.V0SUBG_IND_IOF, V0SUBG_IND_IOF);
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.SEGVGAP_PERI_PAGAMENTO, SEGVGAP_PERI_PAGAMENTO);
                _.Move(executed_1.PRODUVG_ORIG_PRODU, PRODUVG_ORIG_PRODU);
            }


        }

        [StopWatch]
        /*" M-0900-SELECT-SEGURVGA-HIST */
        private void M_0900_SELECT_SEGURVGA_HIST(bool isPerform = false)
        {
            /*" -2124- PERFORM M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1 */

            M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1();

            /*" -2127- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2128- MOVE 'ERRO NO ACESSO A SEGURADOSVGAP-HIST ' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A SEGURADOSVGAP-HIST ", PARAMETROS.LK_MENSAGEM);

                /*" -2129- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2129- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0900-SELECT-SEGURVGA-HIST-DB-SELECT-1 */
        public void M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1()
        {
            /*" -2124- EXEC SQL SELECT VALUE(DATA_MOVIMENTO, CURRENT_DATE), VALUE(COD_MOEDA_PRM, 17) INTO :SEGVGAPH-DATA-MOVIMENTO, :SEGVGAPH-COD-MOEDA-PRM FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :WS-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO WITH UR END-EXEC. */

            var m_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 = new M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA_NUM_ITEM.ToString(),
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1.Execute(m_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAPH_DATA_MOVIMENTO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO);
                _.Move(executed_1.SEGVGAPH_COD_MOEDA_PRM, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM);
            }


        }

        [StopWatch]
        /*" M-1000-SELECT-MOEDA-COTACAO */
        private void M_1000_SELECT_MOEDA_COTACAO(bool isPerform = false)
        {
            /*" -2143- PERFORM M_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1 */

            M_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1();

            /*" -2146- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2147- MOVE 'ERRO NO ACESSO A MOEDAS-COTACAO ' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A MOEDAS-COTACAO ", PARAMETROS.LK_MENSAGEM);

                /*" -2148- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2151- END-IF. */
            }


            /*" -2151- PERFORM 1100-CALCULAR-IOF-PREMIO. */

            M_1100_CALCULAR_IOF_PREMIO(true);

        }

        [StopWatch]
        /*" M-1000-SELECT-MOEDA-COTACAO-DB-SELECT-1 */
        public void M_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1()
        {
            /*" -2143- EXEC SQL SELECT VAL_COMPRA INTO :MOEDACOT-VAL-COMPRA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = :SEGVGAPH-COD-MOEDA-PRM AND DATA_INIVIGENCIA <= :SEGVGAPH-DATA-MOVIMENTO AND DATA_TERVIGENCIA >= :SEGVGAPH-DATA-MOVIMENTO WITH UR END-EXEC. */

            var m_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1_Query1 = new M_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1_Query1()
            {
                SEGVGAPH_DATA_MOVIMENTO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO.ToString(),
                SEGVGAPH_COD_MOEDA_PRM = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM.ToString(),
            };

            var executed_1 = M_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1_Query1.Execute(m_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDACOT_VAL_COMPRA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA);
            }


        }

        [StopWatch]
        /*" M-1100-CALCULAR-IOF-PREMIO */
        private void M_1100_CALCULAR_IOF_PREMIO(bool isPerform = false)
        {
            /*" -2163- PERFORM M_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1 */

            M_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1();

            /*" -2166- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2167- MOVE 'ERRO NO ACESSO A MOEDAS-COTACAO ' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A MOEDAS-COTACAO ", PARAMETROS.LK_MENSAGEM);

                /*" -2168- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2168- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1100-CALCULAR-IOF-PREMIO-DB-SELECT-1 */
        public void M_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1()
        {
            /*" -2163- EXEC SQL SELECT VAL_COMPRA INTO :MOEDACOT-VAL-COMPRA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = :SEGVGAPH-COD-MOEDA-PRM AND DATA_INIVIGENCIA <= :SEGVGAPH-DATA-MOVIMENTO AND DATA_TERVIGENCIA >= :SEGVGAPH-DATA-MOVIMENTO WITH UR END-EXEC. */

            var m_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1_Query1 = new M_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1_Query1()
            {
                SEGVGAPH_DATA_MOVIMENTO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO.ToString(),
                SEGVGAPH_COD_MOEDA_PRM = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM.ToString(),
            };

            var executed_1 = M_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1_Query1.Execute(m_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDACOT_VAL_COMPRA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA);
            }


        }

        [StopWatch]
        /*" M-1200-SELECT-HIS-COBER-PROP */
        private void M_1200_SELECT_HIS_COBER_PROP(bool isPerform = false)
        {
            /*" -2184- PERFORM M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1 */

            M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1();

            /*" -2187- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2188- MOVE 'ERRO NO ACESSO A HIS-COBER-PROPOST ' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A HIS-COBER-PROPOST ", PARAMETROS.LK_MENSAGEM);

                /*" -2189- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2189- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1200-SELECT-HIS-COBER-PROP-DB-SELECT-1 */
        public void M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1()
        {
            /*" -2184- EXEC SQL SELECT VALUE(QTMDIT, 15), VALUE(IMPSEGCDG, 0) INTO :HISCOBPR-QTMDIT, :HISCOBPR-IMPSEGCDG FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= CURRENT DATE AND DATA_TERVIGENCIA >= CURRENT DATE WITH UR END-EXEC. */

            var m_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1 = new M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1()
            {
                WS_NUM_CERTIFICADO = WS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1.Execute(m_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_QTMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);
            }


        }

        [StopWatch]
        /*" M-1300-SELECT-APOL-COBERTURA */
        private void M_1300_SELECT_APOL_COBERTURA(bool isPerform = false)
        {
            /*" -2199- INITIALIZE APOLICOB-IMP-SEGURADA-IX APOLICOB-PRM-TARIFARIO-IX APOLICOB-FATOR-MULTIPLICA. */
            _.Initialize(
                APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX
                , APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX
                , APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA
            );

            /*" -2214- PERFORM M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1 */

            M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1();

            /*" -2217- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2218- MOVE 'ERRO NO ACESSO A APOLICE_COBERTURA ' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A APOLICE_COBERTURA ", PARAMETROS.LK_MENSAGEM);

                /*" -2219- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2221- END-IF. */
            }


            /*" -2222- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -2225- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IX APOLICOB-PRM-TARIFARIO-IX APOLICOB-FATOR-MULTIPLICA */
                _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                /*" -2225- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1300-SELECT-APOL-COBERTURA-DB-SELECT-1 */
        public void M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1()
        {
            /*" -2214- EXEC SQL SELECT VALUE(IMP_SEGURADA_IX, 0), VALUE(PRM_TARIFARIO_IX, 0), VALUE(FATOR_MULTIPLICA, 0) INTO :APOLICOB-IMP-SEGURADA-IX , :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WS-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (:WS-RAMO1, :WS-RAMO2) AND COD_COBERTURA = :WS-COBERTURA WITH UR END-EXEC. */

            var m_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1 = new M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA_NUM_ITEM.ToString(),
                WS_NUM_APOLICE = WS_NUM_APOLICE.ToString(),
                WS_COBERTURA = WS_COBERTURA.ToString(),
                WS_RAMO1 = WS_RAMO1.ToString(),
                WS_RAMO2 = WS_RAMO2.ToString(),
            };

            var executed_1 = M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1.Execute(m_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-1510-LER-CARENCIA-491 */
        private void M_1510_LER_CARENCIA_491(bool isPerform = false)
        {
            /*" -2254- PERFORM M_1510_LER_CARENCIA_491_DB_DECLARE_1 */

            M_1510_LER_CARENCIA_491_DB_DECLARE_1();

            /*" -2256- PERFORM M_1510_LER_CARENCIA_491_DB_OPEN_1 */

            M_1510_LER_CARENCIA_491_DB_OPEN_1();

            /*" -2259- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2260- MOVE 'ERRO NO OPEN CURSOR CARENCIA 491 ' TO LK-MENSAGEM */
                _.Move("ERRO NO OPEN CURSOR CARENCIA 491 ", PARAMETROS.LK_MENSAGEM);

                /*" -2261- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2261- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1510-LER-CARENCIA-491-DB-OPEN-1 */
        public void M_1510_LER_CARENCIA_491_DB_OPEN_1()
        {
            /*" -2256- EXEC SQL OPEN CAREN491 END-EXEC. */

            CAREN491.Open();

        }

        [StopWatch]
        /*" M-2500-LER-MSG-HINT-491-DB-DECLARE-1 */
        public void M_2500_LER_MSG_HINT_491_DB_DECLARE_1()
        {
            /*" -2346- EXEC SQL DECLARE CHINT491 CURSOR FOR SELECT A.NUM_GARANTIA, A.SEQ_GRUPO_COBERTURA, CASE VALUE(A.SEQ_GRUPO_COBERTURA, 9) WHEN 8 THEN 'A' ELSE 'B' END, G.DES_CARENCIA_MSG FROM SEGUROS.VG_APOLICE_COB_GAR A, SEGUROS.VG_CARENCIA_MSG G WHERE A.NUM_APOLICE = 0 AND A.COD_SUBGRUPO = 0 AND A.COD_PRODUTO = 9301 AND A.SEQ_GRUPO_COBERTURA IN (8,9) AND A.IND_TIPO_COB_GAR = 'CC' AND A.SEQ_MSG_HINT = G.SEQ_CARENCIA_MSG ORDER BY A.SEQ_GRUPO_COBERTURA DESC, A.NUM_GARANTIA WITH UR END-EXEC. */
            CHINT491 = new VG0711S_CHINT491(false);
            string GetQuery_CHINT491()
            {
                var query = @$"SELECT A.NUM_GARANTIA
							, 
							A.SEQ_GRUPO_COBERTURA
							, 
							CASE VALUE(A.SEQ_GRUPO_COBERTURA
							, 9) 
							WHEN 8 THEN 'A' 
							ELSE 'B' 
							END
							, 
							G.DES_CARENCIA_MSG 
							FROM SEGUROS.VG_APOLICE_COB_GAR A
							, 
							SEGUROS.VG_CARENCIA_MSG G 
							WHERE A.NUM_APOLICE = 0 
							AND A.COD_SUBGRUPO = 0 
							AND A.COD_PRODUTO = 9301 
							AND A.SEQ_GRUPO_COBERTURA IN (8
							,9) 
							AND A.IND_TIPO_COB_GAR = 'CC' 
							AND A.SEQ_MSG_HINT = G.SEQ_CARENCIA_MSG 
							ORDER BY A.SEQ_GRUPO_COBERTURA DESC
							, A.NUM_GARANTIA";

                return query;
            }
            CHINT491.GetQueryEvent += GetQuery_CHINT491;

        }

        [StopWatch]
        /*" M-1520-FETCH-CARENCIA-491 */
        private void M_1520_FETCH_CARENCIA_491(bool isPerform = false)
        {
            /*" -2270- INITIALIZE VG091-DES-COB-CARENCIA */
            _.Initialize(
                VG091_DES_COB_CARENCIA
            );

            /*" -2274- PERFORM M_1520_FETCH_CARENCIA_491_DB_FETCH_1 */

            M_1520_FETCH_CARENCIA_491_DB_FETCH_1();

            /*" -2277- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2278- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2279- MOVE 'S' TO WFIM-CAREN */
                    _.Move("S", WFIM_CAREN);

                    /*" -2279- PERFORM M_1520_FETCH_CARENCIA_491_DB_CLOSE_1 */

                    M_1520_FETCH_CARENCIA_491_DB_CLOSE_1();

                    /*" -2281- ELSE */
                }
                else
                {


                    /*" -2282- MOVE 'ERRO FETCH CURSOR CARENCIA 491 ' TO LK-MENSAGEM */
                    _.Move("ERRO FETCH CURSOR CARENCIA 491 ", PARAMETROS.LK_MENSAGEM);

                    /*" -2283- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2284- END-IF */
                }


                /*" -2284- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1520-FETCH-CARENCIA-491-DB-FETCH-1 */
        public void M_1520_FETCH_CARENCIA_491_DB_FETCH_1()
        {
            /*" -2274- EXEC SQL FETCH CAREN491 INTO :VGARANTI-NUM-GARANTIA , :VG091-DES-COB-CARENCIA END-EXEC. */

            if (CAREN491.Fetch())
            {
                _.Move(CAREN491.VGARANTI_NUM_GARANTIA, VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA);
                _.Move(CAREN491.VG091_DES_COB_CARENCIA, VG091_DES_COB_CARENCIA);
            }

        }

        [StopWatch]
        /*" M-1520-FETCH-CARENCIA-491-DB-CLOSE-1 */
        public void M_1520_FETCH_CARENCIA_491_DB_CLOSE_1()
        {
            /*" -2279- EXEC SQL CLOSE CAREN491 END-EXEC */

            CAREN491.Close();

        }

        [StopWatch]
        /*" M-1550-PROCESSA-CARENCIA-491 */
        private void M_1550_PROCESSA_CARENCIA_491(bool isPerform = false)
        {
            /*" -2292- ADD 1 TO WS-CONTA-COB-CARENCIA */
            WS_CONTA_COB_CARENCIA.Value = WS_CONTA_COB_CARENCIA + 1;

            /*" -2294- MOVE VG091-DES-COB-CARENCIA-TEXT(1:300) TO WS-DES-COB-CARENCIA */
            _.Move(VG091_DES_COB_CARENCIA.VG091_DES_COB_CARENCIA_TEXT.Substring(1, 300), WS_DES_COB_CARENCIA);

            /*" -2297- MOVE WS-CONTA-COB-CARENCIA TO WS-NUM-COB-CARENCIA */
            _.Move(WS_CONTA_COB_CARENCIA, WS_NUM_COB_CARENCIA);

            /*" -2299- MOVE VGARANTI-NUM-GARANTIA TO WS-COBERTURA-491 */
            _.Move(VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA, WS_COBERTURA_491);

            /*" -2301- PERFORM 1590-SEARCH-TAB-DEPARA-491 */

            M_1590_SEARCH_TAB_DEPARA_491(true);

            /*" -2301- PERFORM 1520-FETCH-CARENCIA-491. */

            M_1520_FETCH_CARENCIA_491(true);

        }

        [StopWatch]
        /*" M-1590-SEARCH-TAB-DEPARA-491 */
        private void M_1590_SEARCH_TAB_DEPARA_491(bool isPerform = false)
        {
            /*" -2309- SET WS-I TO WIDX */
            WS_I.Value = WIDX;

            /*" -2311- SET WIDX TO +1. */
            WIDX.Value = +1;

            /*" -2313- SEARCH WTAB-COB-PREMIO AT END */
            void SearchAtEnd3()
            {

                /*" -2314- SUBTRACT 1 FROM WS-CONTA-COB-CARENCIA */
                WS_CONTA_COB_CARENCIA.Value = WS_CONTA_COB_CARENCIA - 1;

                /*" -2315- WHEN (WTAB-NUM-GARANTIA-491(WIDX) = WS-COBERTURA-491) */
            };

            var mustSearchAtEnd3 = true;
            for (; WIDX < FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO.Items.Count; WIDX.Value++)
            {

                if ((FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA_491 == WS_COBERTURA_491))
                {

                    mustSearchAtEnd3 = false;

                    /*" -2317- MOVE WS-NUM-COB-CARENCIA TO WTAB-NUM-COB-CARENCIA(WIDX) */
                    _.Move(WS_NUM_COB_CARENCIA, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_COB_CARENCIA);

                    /*" -2319- MOVE WS-DES-COB-CARENCIA TO WTAB-DES-COB-CARENCIA(WIDX) */
                    _.Move(WS_DES_COB_CARENCIA, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_DES_COB_CARENCIA);

                    /*" -2319- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd3)
                SearchAtEnd3();

        }

        [StopWatch]
        /*" M-2500-LER-MSG-HINT-491 */
        private void M_2500_LER_MSG_HINT_491(bool isPerform = false)
        {
            /*" -2327- MOVE 'N' TO WFIM-CAREN */
            _.Move("N", WFIM_CAREN);

            /*" -2346- PERFORM M_2500_LER_MSG_HINT_491_DB_DECLARE_1 */

            M_2500_LER_MSG_HINT_491_DB_DECLARE_1();

            /*" -2348- PERFORM M_2500_LER_MSG_HINT_491_DB_OPEN_1 */

            M_2500_LER_MSG_HINT_491_DB_OPEN_1();

            /*" -2351- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2352- MOVE 'ERRO NO OPEN CURSOR MSG HINT 491 ' TO LK-MENSAGEM */
                _.Move("ERRO NO OPEN CURSOR MSG HINT 491 ", PARAMETROS.LK_MENSAGEM);

                /*" -2353- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2353- END-IF. */
            }


        }

        [StopWatch]
        /*" M-2500-LER-MSG-HINT-491-DB-OPEN-1 */
        public void M_2500_LER_MSG_HINT_491_DB_OPEN_1()
        {
            /*" -2348- EXEC SQL OPEN CHINT491 END-EXEC. */

            CHINT491.Open();

        }

        [StopWatch]
        /*" M-2520-FETCH-MSG-HINT-491 */
        private void M_2520_FETCH_MSG_HINT_491(bool isPerform = false)
        {
            /*" -2362- INITIALIZE VG091-DES-MSG-HINT */
            _.Initialize(
                VG091_DES_MSG_HINT
            );

            /*" -2368- PERFORM M_2520_FETCH_MSG_HINT_491_DB_FETCH_1 */

            M_2520_FETCH_MSG_HINT_491_DB_FETCH_1();

            /*" -2371- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2372- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2373- MOVE 'S' TO WFIM-CAREN */
                    _.Move("S", WFIM_CAREN);

                    /*" -2373- PERFORM M_2520_FETCH_MSG_HINT_491_DB_CLOSE_1 */

                    M_2520_FETCH_MSG_HINT_491_DB_CLOSE_1();

                    /*" -2375- ELSE */
                }
                else
                {


                    /*" -2376- MOVE 'ERRO FETCH CURSOR MSG HINT 491 ' TO LK-MENSAGEM */
                    _.Move("ERRO FETCH CURSOR MSG HINT 491 ", PARAMETROS.LK_MENSAGEM);

                    /*" -2377- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2378- END-IF */
                }


                /*" -2378- END-IF. */
            }


        }

        [StopWatch]
        /*" M-2520-FETCH-MSG-HINT-491-DB-FETCH-1 */
        public void M_2520_FETCH_MSG_HINT_491_DB_FETCH_1()
        {
            /*" -2368- EXEC SQL FETCH CHINT491 INTO :VGARANTI-NUM-GARANTIA , :VG087-SEQ-GRUPO-COBERTURA , :VGARANTI-TP-GARANTIA, :VG091-DES-MSG-HINT END-EXEC. */

            if (CHINT491.Fetch())
            {
                _.Move(CHINT491.VGARANTI_NUM_GARANTIA, VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA);
                _.Move(CHINT491.VG087_SEQ_GRUPO_COBERTURA, VG087.DCLVG_GRUPO_COBERTURA.VG087_SEQ_GRUPO_COBERTURA);
                _.Move(CHINT491.VGARANTI_TP_GARANTIA, VGARANTI_TP_GARANTIA);
                _.Move(CHINT491.VG091_DES_MSG_HINT, VG091_DES_MSG_HINT);
            }

        }

        [StopWatch]
        /*" M-2520-FETCH-MSG-HINT-491-DB-CLOSE-1 */
        public void M_2520_FETCH_MSG_HINT_491_DB_CLOSE_1()
        {
            /*" -2373- EXEC SQL CLOSE CHINT491 END-EXEC */

            CHINT491.Close();

        }

        [StopWatch]
        /*" M-2550-PROCESSA-MSG-HINT-491 */
        private void M_2550_PROCESSA_MSG_HINT_491(bool isPerform = false)
        {
            /*" -2387- MOVE VG091-DES-MSG-HINT-TEXT(1:800) TO WS-DES-MSG-HINT */
            _.Move(VG091_DES_MSG_HINT.VG091_DES_MSG_HINT_TEXT.Substring(1, 800), WS_DES_MSG_HINT);

            /*" -2390- MOVE WS-CONTA-MSG-HINT TO WS-NUM-COB-CARENCIA */
            _.Move(WS_CONTA_MSG_HINT, WS_NUM_COB_CARENCIA);

            /*" -2392- MOVE VGARANTI-NUM-GARANTIA TO WS-COBERTURA-491 */
            _.Move(VGARANTI.DCLVG_GARANTIA.VGARANTI_NUM_GARANTIA, WS_COBERTURA_491);

            /*" -2394- PERFORM 2590-SEARCH-TAB-DEPARA-491 */

            M_2590_SEARCH_TAB_DEPARA_491(true);

            /*" -2394- PERFORM 2520-FETCH-MSG-HINT-491. */

            M_2520_FETCH_MSG_HINT_491(true);

        }

        [StopWatch]
        /*" M-2590-SEARCH-TAB-DEPARA-491 */
        private void M_2590_SEARCH_TAB_DEPARA_491(bool isPerform = false)
        {
            /*" -2403- SET WIDX TO +1. */
            WIDX.Value = +1;

            /*" -2404- SEARCH WTAB-COB-PREMIO */
            for (; WIDX < FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO.Items.Count; WIDX.Value++)
            {

                /*" -2408- WHEN ((WTAB-NUM-GARANTIA-491(WIDX) = WS-COBERTURA-491) OR ((WTAB-NUM-GARANTIA-491(WIDX) = ZEROS) AND (WTAB-NUM-GARANTIA(WIDX) = WS-COBERTURA-491))) AND (WTAB-TIPO-GARANTIA(WIDX) = VGARANTI-TP-GARANTIA) */

                if (((FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA_491 == WS_COBERTURA_491) || ((FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA_491 == 00) && (FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_NUM_GARANTIA == WS_COBERTURA_491))) && (FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_TIPO_GARANTIA == VGARANTI_TP_GARANTIA))
                {


                    /*" -2409- MOVE WS-DES-MSG-HINT TO WTAB-DES-MSG-HINT(WIDX) */
                    _.Move(WS_DES_MSG_HINT, FILLER_5.WS_VALORES_AX.WTAB_COB_PREMIO[WIDX].WTAB_DES_MSG_HINT);

                    /*" -2409- END-SEARCH. */
                    break;
                }
            }


        }

        [StopWatch]
        /*" M-3000-PESQUISA-CBO */
        private void M_3000_PESQUISA_CBO(bool isPerform = false)
        {
            /*" -2415- MOVE SPACES TO WACHOU-CBO. */
            _.Move("", WS_AREA_SEGURA_PRECO_AUX.WACHOU_CBO);

            /*" -2416- MOVE ZEROS TO WS-CBO-SEGURA-PRECO. */
            _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_CBO_SEGURA_PRECO);

            /*" -2417- PERFORM 3100-00-SEL-PESSOA-FISICA THRU 3100-99-SAIDA. */

            M_3100_00_SEL_PESSOA_FISICA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_99_SAIDA*/


            /*" -2418- IF WACHOU-CBO = 'SIM' */

            if (WS_AREA_SEGURA_PRECO_AUX.WACHOU_CBO == "SIM")
            {

                /*" -2419- MOVE PESSOFIS-COD-CBO TO WS-CBO-SEGURA-PRECO */
                _.Move(PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO, WS_AREA_SEGURA_PRECO_AUX.WS_CBO_SEGURA_PRECO);

                /*" -2420- GO TO 3000-10-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_10_SAIDA*/ //GOTO
                return;

                /*" -2421- ELSE */
            }
            else
            {


                /*" -2422- MOVE SPACES TO WACHOU-CBO */
                _.Move("", WS_AREA_SEGURA_PRECO_AUX.WACHOU_CBO);

                /*" -2423- MOVE ZEROS TO WS-CBO-SEGURA-PRECO */
                _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_CBO_SEGURA_PRECO);

                /*" -2424- PERFORM 3200-00-SEL-PF-CBO THRU 3200-99-SAIDA */

                M_3200_00_SEL_PF_CBO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_99_SAIDA*/


                /*" -2425- MOVE PESSOFIS-COD-CBO TO WS-CBO-SEGURA-PRECO */
                _.Move(PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO, WS_AREA_SEGURA_PRECO_AUX.WS_CBO_SEGURA_PRECO);

                /*" -2426- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_10_SAIDA*/

        [StopWatch]
        /*" M-3100-00-SEL-PESSOA-FISICA */
        private void M_3100_00_SEL_PESSOA_FISICA(bool isPerform = false)
        {
            /*" -2440- PERFORM M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1 */

            M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1();

            /*" -2443- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2444- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2445- MOVE ZEROS TO PESSOFIS-COD-CBO */
                    _.Move(0, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO);

                    /*" -2446- MOVE 'NAO' TO WACHOU-CBO */
                    _.Move("NAO", WS_AREA_SEGURA_PRECO_AUX.WACHOU_CBO);

                    /*" -2447- GO TO 3100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_99_SAIDA*/ //GOTO
                    return;

                    /*" -2448- ELSE */
                }
                else
                {


                    /*" -2452- STRING 'PROBLEMAS NA LEITURA DE PESSOA FISICA. ' 'CERTIFICADO: ' WS-NUM-CERTIFICADO-ALFA DELIMITED BY SIZE INTO LK-MENSAGEM */
                    #region STRING
                    var spl1 = "PROBLEMAS NA LEITURA DE PESSOA FISICA. " + "CERTIFICADO: " + WS_AREA_SEGURA_PRECO_AUX.WS_NUM_CERTIFICADO_ALFA.GetMoveValues();
                    _.Move(spl1, PARAMETROS.LK_MENSAGEM);
                    #endregion

                    /*" -2453- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2454- END-IF */
                }


                /*" -2455- END-IF. */
            }


            /*" -2455- MOVE 'SIM' TO WACHOU-CBO. */
            _.Move("SIM", WS_AREA_SEGURA_PRECO_AUX.WACHOU_CBO);

        }

        [StopWatch]
        /*" M-3100-00-SEL-PESSOA-FISICA-DB-SELECT-1 */
        public void M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -2440- EXEC SQL SELECT PESSOFIS.COD_CBO INTO :PESSOFIS-COD-CBO FROM SEGUROS.PROPOSTA_FIDELIZ FIDELIZ , SEGUROS.PESSOA_FISICA PESSOFIS WHERE FIDELIZ.NUM_PROPOSTA_SIVPF = :WS-NUM-CERTIFICADO AND PESSOFIS.COD_PESSOA = FIDELIZ.COD_PESSOA WITH UR END-EXEC. */

            var m_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1 = new M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                WS_NUM_CERTIFICADO = WS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(m_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOFIS_COD_CBO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_99_SAIDA*/

        [StopWatch]
        /*" M-3200-00-SEL-PF-CBO */
        private void M_3200_00_SEL_PF_CBO(bool isPerform = false)
        {
            /*" -2467- PERFORM M_3200_00_SEL_PF_CBO_DB_SELECT_1 */

            M_3200_00_SEL_PF_CBO_DB_SELECT_1();

            /*" -2470- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2471- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2472- MOVE ZEROS TO PESSOFIS-COD-CBO */
                    _.Move(0, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO);

                    /*" -2473- MOVE 'NAO' TO WACHOU-CBO */
                    _.Move("NAO", WS_AREA_SEGURA_PRECO_AUX.WACHOU_CBO);

                    /*" -2474- GO TO 3200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2475- ELSE */
                }
                else
                {


                    /*" -2479- STRING 'PROBLEMAS NA LEITURA DE PF_CBO. ' 'CERTIFICADO: ' WS-NUM-CERTIFICADO-ALFA DELIMITED BY SIZE INTO LK-MENSAGEM */
                    #region STRING
                    var spl2 = "PROBLEMAS NA LEITURA DE PF_CBO. " + "CERTIFICADO: " + WS_AREA_SEGURA_PRECO_AUX.WS_NUM_CERTIFICADO_ALFA.GetMoveValues();
                    _.Move(spl2, PARAMETROS.LK_MENSAGEM);
                    #endregion

                    /*" -2480- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2481- END-IF */
                }


                /*" -2482- ELSE */
            }
            else
            {


                /*" -2483- MOVE PF062-COD-CBO TO PESSOFIS-COD-CBO */
                _.Move(PF062.DCLPF_CBO.PF062_COD_CBO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO);

                /*" -2484- MOVE 'SIM' TO WACHOU-CBO */
                _.Move("SIM", WS_AREA_SEGURA_PRECO_AUX.WACHOU_CBO);

                /*" -2484- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3200-00-SEL-PF-CBO-DB-SELECT-1 */
        public void M_3200_00_SEL_PF_CBO_DB_SELECT_1()
        {
            /*" -2467- EXEC SQL SELECT COD_CBO INTO :PF062-COD-CBO FROM SEGUROS.PF_CBO WHERE NUM_PROPOSTA_SIVPF = :WS-NUM-CERTIFICADO WITH UR END-EXEC. */

            var m_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1 = new M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1()
            {
                WS_NUM_CERTIFICADO = WS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1.Execute(m_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF062_COD_CBO, PF062.DCLPF_CBO.PF062_COD_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_99_SAIDA*/

        [StopWatch]
        /*" M-4000-00-VALIDAR-SEGURA-PRECO */
        private void M_4000_00_VALIDAR_SEGURA_PRECO(bool isPerform = false)
        {
            /*" -2495- IF WS-PROD-SEGURA-PRECO = 9310 OR JVPRD9310 OR 9311 OR JVPRD9311 OR 9337 OR 9338 */

            if (WS_AREA_SEGURA_PRECO_AUX.WS_PROD_SEGURA_PRECO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString(), "9311", JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString(), "9337", "9338"))
            {

                /*" -2496- MOVE 1 TO WS-FLAG-SEGPRECO */
                _.Move(1, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                /*" -2497- GO TO 4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                return;

                /*" -2499- END-IF. */
            }


            /*" -2508- IF (WS-NUM-APOLICE = 109300000680 AND WS-COD-SUBGRUPO = 1) OR (WS-NUM-APOLICE = 109300000680 AND WS-COD-SUBGRUPO = 2) OR (WS-NUM-APOLICE = 109300001553 AND WS-COD-SUBGRUPO = 1) OR (WS-NUM-APOLICE = 109300001553 AND WS-COD-SUBGRUPO = 2) */

            if ((WS_NUM_APOLICE == 109300000680 && WS_COD_SUBGRUPO == 1) || (WS_NUM_APOLICE == 109300000680 && WS_COD_SUBGRUPO == 2) || (WS_NUM_APOLICE == 109300001553 && WS_COD_SUBGRUPO == 1) || (WS_NUM_APOLICE == 109300001553 && WS_COD_SUBGRUPO == 2))
            {

                /*" -2509- MOVE 1 TO WS-FLAG-SEGPRECO */
                _.Move(1, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                /*" -2511- GO TO 4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                return;

                /*" -2513- END-IF. */
            }


            /*" -2514- IF WS-DATA-QUITACAO < WS-DATA-INI-SEGPRECO */

            if (WS_AREA_SEGURA_PRECO_AUX.WS_DATA_QUITACAO < WS_AREA_SEGURA_PRECO_AUX.WS_DATA_INI_SEGPRECO)
            {

                /*" -2515- MOVE 0 TO WS-FLAG-SEGPRECO */
                _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                /*" -2516- GO TO 4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                return;

                /*" -2519- END-IF. */
            }


            /*" -2520- IF WS-PROD-SEGURA-PRECO = 9353 OR JVPRD9353 */

            if (WS_AREA_SEGURA_PRECO_AUX.WS_PROD_SEGURA_PRECO.In("9353", JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString()))
            {

                /*" -2521- IF WS-DATA-QUITACAO >= WS-DATA-SEGURA-PRECO */

                if (WS_AREA_SEGURA_PRECO_AUX.WS_DATA_QUITACAO >= WS_AREA_SEGURA_PRECO_AUX.WS_DATA_SEGURA_PRECO)
                {

                    /*" -2522- MOVE 0 TO WS-FLAG-SEGPRECO */
                    _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                    /*" -2523- GO TO 4000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                    return;

                    /*" -2524- END-IF */
                }


                /*" -2527- END-IF. */
            }


            /*" -2528- IF WS-PROD-SEGURA-PRECO = 9352 OR JVPRD9352 */

            if (WS_AREA_SEGURA_PRECO_AUX.WS_PROD_SEGURA_PRECO.In("9352", JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString()))
            {

                /*" -2529- IF WS-DATA-QUITACAO >= WS-DATA-SEGURA-PRECO */

                if (WS_AREA_SEGURA_PRECO_AUX.WS_DATA_QUITACAO >= WS_AREA_SEGURA_PRECO_AUX.WS_DATA_SEGURA_PRECO)
                {

                    /*" -2530- MOVE 0 TO WS-FLAG-SEGPRECO */
                    _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                    /*" -2531- GO TO 4000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                    return;

                    /*" -2532- END-IF */
                }


                /*" -2534- END-IF. */
            }


            /*" -2554- IF ( WS-NUM-APOLICE = 109300002001 AND (WS-COD-SUBGRUPO = 1 OR 2 ) ) OR ( WS-NUM-APOLICE = 109300001966 AND (WS-COD-SUBGRUPO = 1 OR 2 ) ) OR ( WS-NUM-APOLICE = 109300001970 OR 3009300001970 AND (WS-COD-SUBGRUPO = 1 OR 2 OR 3 OR 4 ) ) OR ( WS-NUM-APOLICE = 109300002004 AND (WS-COD-SUBGRUPO = 1 OR 2 OR 3 ) ) OR ( WS-NUM-APOLICE = 109300002007 AND (WS-COD-SUBGRUPO = 1 OR 2 ) ) OR ( WS-NUM-APOLICE = 109300001976 AND (WS-COD-SUBGRUPO = 1 OR 2 ) ) OR ( WS-NUM-APOLICE = 109300001977 OR 3009300001977 AND (WS-COD-SUBGRUPO = 3 OR 4 OR 7 OR 8 ) ) OR ( WS-NUM-APOLICE = 109300002002 OR 3009300002002 AND (WS-COD-SUBGRUPO = 3 OR 4 ) ) OR ( WS-NUM-APOLICE = 109300002005 OR 3009300002005 AND (WS-COD-SUBGRUPO = 1 OR 2 OR 3 OR 4 ) ) OR ( WS-NUM-APOLICE = 109300002008 OR 3009300002008 AND (WS-COD-SUBGRUPO = 2 OR 3 OR 4 ) ) */

            if ((WS_NUM_APOLICE == 109300002001 && (WS_COD_SUBGRUPO.In("1", "2"))) || (WS_NUM_APOLICE == 109300001966 && (WS_COD_SUBGRUPO.In("1", "2"))) || (WS_NUM_APOLICE.In("109300001970", "3009300001970") && (WS_COD_SUBGRUPO.In("1", "2", "3", "4"))) || (WS_NUM_APOLICE == 109300002004 && (WS_COD_SUBGRUPO.In("1", "2", "3"))) || (WS_NUM_APOLICE == 109300002007 && (WS_COD_SUBGRUPO.In("1", "2"))) || (WS_NUM_APOLICE == 109300001976 && (WS_COD_SUBGRUPO.In("1", "2"))) || (WS_NUM_APOLICE.In("109300001977", "3009300001977") && (WS_COD_SUBGRUPO.In("3", "4", "7", "8"))) || (WS_NUM_APOLICE.In("109300002002", "3009300002002") && (WS_COD_SUBGRUPO.In("3", "4"))) || (WS_NUM_APOLICE.In("109300002005", "3009300002005") && (WS_COD_SUBGRUPO.In("1", "2", "3", "4"))) || (WS_NUM_APOLICE.In("109300002008", "3009300002008") && (WS_COD_SUBGRUPO.In("2", "3", "4"))))
            {

                /*" -2555- IF WS-DATA-QUITACAO NOT LESS WS-DATA-INI-SEGPRECO */

                if (WS_AREA_SEGURA_PRECO_AUX.WS_DATA_QUITACAO >= WS_AREA_SEGURA_PRECO_AUX.WS_DATA_INI_SEGPRECO)
                {

                    /*" -2556- PERFORM 3000-PESQUISA-CBO THRU 3000-10-SAIDA */

                    M_3000_PESQUISA_CBO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_10_SAIDA*/


                    /*" -2557- IF W88-CBO-SEGURA-PRECO */

                    if (WS_AREA_SEGURA_PRECO_AUX.WS_CBO_SEGURA_PRECO["W88_CBO_SEGURA_PRECO"])
                    {

                        /*" -2558- MOVE 1 TO WS-FLAG-SEGPRECO */
                        _.Move(1, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                        /*" -2559- GO TO 4000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                        return;

                        /*" -2560- ELSE */
                    }
                    else
                    {


                        /*" -2561- MOVE 0 TO WS-FLAG-SEGPRECO */
                        _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                        /*" -2562- GO TO 4000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                        return;

                        /*" -2563- END-IF */
                    }


                    /*" -2564- ELSE */
                }
                else
                {


                    /*" -2565- MOVE 0 TO WS-FLAG-SEGPRECO */
                    _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                    /*" -2566- GO TO 4000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                    return;

                    /*" -2567- END-IF */
                }


                /*" -2568- ELSE */
            }
            else
            {


                /*" -2569- MOVE 0 TO WS-FLAG-SEGPRECO */
                _.Move(0, WS_AREA_SEGURA_PRECO_AUX.WS_FLAG_SEGPRECO);

                /*" -2570- GO TO 4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/ //GOTO
                return;

                /*" -2570- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_99_SAIDA*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -2578- MOVE SQLCODE TO LK-RETURN-CODE. */
            _.Move(DB.SQLCODE, PARAMETROS.LK_RETURN_CODE);

            /*" -2579- DISPLAY ' ' */
            _.Display($" ");

            /*" -2580- DISPLAY 'DADOS RETORNADOS DA VG0711S------------------------' */
            _.Display($"DADOS RETORNADOS DA VG0711S------------------------");

            /*" -2581- PERFORM 8888-DISPLAY THRU 8888-99-SAIDA. */

            M_8888_DISPLAY(true);

            M_8888_99_SAIDA(true);

            /*" -2581- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/

        [StopWatch]
        /*" M-8888-DISPLAY */
        private void M_8888_DISPLAY(bool isPerform = false)
        {
            /*" -2589- DISPLAY 'LK-NUM-APOLICE             = ' LK-NUM-APOLICE */
            _.Display($"LK-NUM-APOLICE             = {PARAMETROS.LK_NUM_APOLICE}");

            /*" -2590- DISPLAY 'LK-SUBGRUPO                = ' LK-SUBGRUPO */
            _.Display($"LK-SUBGRUPO                = {PARAMETROS.LK_SUBGRUPO}");

            /*" -2591- DISPLAY 'LK-CERTIFICADO             = ' LK-CERTIFICADO */
            _.Display($"LK-CERTIFICADO             = {PARAMETROS.LK_CERTIFICADO}");

            /*" -2592- DISPLAY 'LK-IDADE                   = ' LK-IDADE */
            _.Display($"LK-IDADE                   = {PARAMETROS.LK_IDADE}");

            /*" -2593- DISPLAY 'LK-NASCIMENTO              = ' LK-NASCIMENTO */
            _.Display($"LK-NASCIMENTO              = {PARAMETROS.LK_NASCIMENTO}");

            /*" -2594- DISPLAY 'LK-SALARIO                 = ' LK-SALARIO */
            _.Display($"LK-SALARIO                 = {PARAMETROS.LK_SALARIO}");

            /*" -2595- DISPLAY 'LK-VLR-PREMIO              = ' LK-VLR-PREMIO */
            _.Display($"LK-VLR-PREMIO              = {PARAMETROS.LK_VLR_PREMIO}");

            /*" -2596- DISPLAY 'LK-DT-QUITACAO             = ' LK-DT-QUITACAO */
            _.Display($"LK-DT-QUITACAO             = {PARAMETROS.LK_DT_QUITACAO}");

            /*" -2597- DISPLAY 'LK-COBT-MORTE-NATURAL      = ' LK-COBT-MORTE-NATURAL */
            _.Display($"LK-COBT-MORTE-NATURAL      = {PARAMETROS.LK_COBT_MORTE_NATURAL}");

            /*" -2599- DISPLAY 'LK-COBT-MORTE-ACIDENTAL    = ' LK-COBT-MORTE-ACIDENTAL */
            _.Display($"LK-COBT-MORTE-ACIDENTAL    = {PARAMETROS.LK_COBT_MORTE_ACIDENTAL}");

            /*" -2601- DISPLAY 'LK-COBT-INV-PERMANENTE     = ' LK-COBT-INV-PERMANENTE */
            _.Display($"LK-COBT-INV-PERMANENTE     = {PARAMETROS.LK_COBT_INV_PERMANENTE}");

            /*" -2603- DISPLAY 'LK-COBT-INV-POR-ACIDENTE   = ' LK-COBT-INV-POR-ACIDENTE */
            _.Display($"LK-COBT-INV-POR-ACIDENTE   = {PARAMETROS.LK_COBT_INV_POR_ACIDENTE}");

            /*" -2604- DISPLAY 'LK-COBT-ASS-MEDICA         = ' LK-COBT-ASS-MEDICA */
            _.Display($"LK-COBT-ASS-MEDICA         = {PARAMETROS.LK_COBT_ASS_MEDICA}");

            /*" -2606- DISPLAY 'LK-COBT-DIARIA-HOSPITALAR  = ' LK-COBT-DIARIA-HOSPITALAR */
            _.Display($"LK-COBT-DIARIA-HOSPITALAR  = {PARAMETROS.LK_COBT_DIARIA_HOSPITALAR}");

            /*" -2608- DISPLAY 'LK-COBT-DIARIA-INTERNACAO  = ' LK-COBT-DIARIA-INTERNACAO */
            _.Display($"LK-COBT-DIARIA-INTERNACAO  = {PARAMETROS.LK_COBT_DIARIA_INTERNACAO}");

            /*" -2610- DISPLAY 'LK-COBT-IMP-CONJUGE        = ' LK-COBT-IMP-CONJUGE */
            _.Display($"LK-COBT-IMP-CONJUGE        = {PARAMETROS.LK_COBT_IMP_CONJUGE}");

            /*" -2611- DISPLAY 'LK-COBT-IMP-FILHO          = ' LK-COBT-IMP-FILHO */
            _.Display($"LK-COBT-IMP-FILHO          = {PARAMETROS.LK_COBT_IMP_FILHO}");

            /*" -2612- DISPLAY 'LK-COBT-IMP-CDG            = ' LK-COBT-IMP-CDG */
            _.Display($"LK-COBT-IMP-CDG            = {PARAMETROS.LK_COBT_IMP_CDG}");

            /*" -2613- DISPLAY 'LK-PURO-MORTE-NATURAL      = ' LK-PURO-MORTE-NATURAL */
            _.Display($"LK-PURO-MORTE-NATURAL      = {PARAMETROS.LK_PURO_MORTE_NATURAL}");

            /*" -2615- DISPLAY 'LK-PURO-MORTE-ACIDENTAL    = ' LK-PURO-MORTE-ACIDENTAL */
            _.Display($"LK-PURO-MORTE-ACIDENTAL    = {PARAMETROS.LK_PURO_MORTE_ACIDENTAL}");

            /*" -2617- DISPLAY 'LK-PURO-INV-PERMANENTE     = ' LK-PURO-INV-PERMANENTE */
            _.Display($"LK-PURO-INV-PERMANENTE     = {PARAMETROS.LK_PURO_INV_PERMANENTE}");

            /*" -2618- DISPLAY 'LK-PURO-ASS-MEDICA         = ' LK-PURO-ASS-MEDICA */
            _.Display($"LK-PURO-ASS-MEDICA         = {PARAMETROS.LK_PURO_ASS_MEDICA}");

            /*" -2620- DISPLAY 'LK-PURO-DIARIA-HOSPITALAR  = ' LK-PURO-DIARIA-HOSPITALAR */
            _.Display($"LK-PURO-DIARIA-HOSPITALAR  = {PARAMETROS.LK_PURO_DIARIA_HOSPITALAR}");

            /*" -2623- DISPLAY 'LK-PURO-DIARIA-INTERNACAO  = ' LK-PURO-DIARIA-INTERNACAO LK-PURO-DIARIA-INTERNACAO */

            $"LK-PURO-DIARIA-INTERNACAO  = {PARAMETROS.LK_PURO_DIARIA_INTERNACAO}{PARAMETROS.LK_PURO_DIARIA_INTERNACAO}"
            .Display();

            /*" -2624- DISPLAY 'LK-PREM-MORTE-NATURAL      = ' LK-PREM-MORTE-NATURAL */
            _.Display($"LK-PREM-MORTE-NATURAL      = {PARAMETROS.LK_PREM_MORTE_NATURAL}");

            /*" -2626- DISPLAY 'LK-PREM-ACIDENTES-PESSOAIS = ' LK-PREM-ACIDENTES-PESSOAIS */
            _.Display($"LK-PREM-ACIDENTES-PESSOAIS = {PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS}");

            /*" -2627- DISPLAY 'LK-PREM-TOTAL              = ' LK-PREM-TOTAL */
            _.Display($"LK-PREM-TOTAL              = {PARAMETROS.LK_PREM_TOTAL}");

            /*" -2628- DISPLAY 'LK-IOF-PREMIO              = ' LK-IOF-PREMIO */
            _.Display($"LK-IOF-PREMIO              = {PARAMETROS.LK_IOF_PREMIO}");

            /*" -2630- DISPLAY 'INICIO DAS CORRENC COBERT COM VALORES E DIVISAO DE PREMIO' */
            _.Display($"INICIO DAS CORRENC COBERT COM VALORES E DIVISAO DE PREMIO");

            /*" -2631- MOVE 1 TO WS-IND */
            _.Move(1, WS_IND);

            /*" -2632- MOVE SPACES TO WS-DISPLAY */
            _.Move("", WS_DISPLAY);

            /*" -2633- PERFORM UNTIL WS-DISPLAY = 'NAO' */

            while (!(WS_DISPLAY == "NAO"))
            {

                /*" -2634- DISPLAY 'WS-IND                 = ' WS-IND */
                _.Display($"WS-IND                 = {WS_IND}");

                /*" -2636- DISPLAY 'LK-NOM-GRUPO-COBERTURA = ' LK-NOM-GRUPO-COBERTURA(WS-IND) */
                _.Display($"LK-NOM-GRUPO-COBERTURA = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2638- DISPLAY 'LK-NUM-GARANTIA        = ' LK-NUM-GARANTIA(WS-IND) */
                _.Display($"LK-NUM-GARANTIA        = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2640- DISPLAY 'LK-NUM-GARANTIA-491    = ' LK-NUM-GARANTIA-491(WS-IND) */
                _.Display($"LK-NUM-GARANTIA-491    = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2642- DISPLAY 'LK-DES-GARANTIA        = ' LK-DES-GARANTIA(WS-IND) */
                _.Display($"LK-DES-GARANTIA        = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2644- DISPLAY 'LK-NUM-FAIXA-INICIAL   = ' LK-NUM-FAIXA-INICIAL(WS-IND) */
                _.Display($"LK-NUM-FAIXA-INICIAL   = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2646- DISPLAY 'LK-NUM-FAIXA-FINAL     = ' LK-NUM-FAIXA-FINAL(WS-IND) */
                _.Display($"LK-NUM-FAIXA-FINAL     = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2648- DISPLAY 'LK-VLR-FAIXA-CS-INICIAL= ' LK-VLR-FAIXA-CS-INICIAL(WS-IND) */
                _.Display($"LK-VLR-FAIXA-CS-INICIAL= {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2650- DISPLAY 'LK-VLR-FAIXA-CS-FINAL  = ' LK-VLR-FAIXA-CS-FINAL(WS-IND) */
                _.Display($"LK-VLR-FAIXA-CS-FINAL  = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2652- DISPLAY 'LK-PCT-COB-PREMIO      = ' LK-PCT-COB-PREMIO(WS-IND) */
                _.Display($"LK-PCT-COB-PREMIO      = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2654- DISPLAY 'LK-VLR-CAP-SEGURADO    = ' LK-VLR-CAP-SEGURADO(WS-IND) */
                _.Display($"LK-VLR-CAP-SEGURADO    = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2656- DISPLAY 'LK-VLR-CAP-DESC        = ' LK-VLR-CAP-DESC(WS-IND) */
                _.Display($"LK-VLR-CAP-DESC        = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2658- DISPLAY 'LK-VLR-PCT-PREMIO      = ' LK-VLR-PCT-PREMIO(WS-IND) */
                _.Display($"LK-VLR-PCT-PREMIO      = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2660- DISPLAY 'LK-NUM-COB-CARENCIA    = ' LK-NUM-COB-CARENCIA(WS-IND) */
                _.Display($"LK-NUM-COB-CARENCIA    = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2662- DISPLAY 'LK-DES-COB-CARENCIA    = ' LK-DES-COB-CARENCIA(WS-IND) */
                _.Display($"LK-DES-COB-CARENCIA    = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2664- DISPLAY 'LK-DES-MSG-HINT        = ' LK-DES-MSG-HINT(WS-IND) */
                _.Display($"LK-DES-MSG-HINT        = {PARAMETROS.LK_TAB_COB_PREMIO[WS_IND]}");

                /*" -2665- ADD 1 TO WS-IND */
                WS_IND.Value = WS_IND + 1;

                /*" -2666- IF WS-IND > 13 */

                if (WS_IND > 13)
                {

                    /*" -2667- MOVE 'NAO' TO WS-DISPLAY */
                    _.Move("NAO", WS_DISPLAY);

                    /*" -2668- END-IF */
                }


                /*" -2669- END-PERFORM */
            }

            /*" -2671- DISPLAY 'FIM DAS CORRENC COBERT COM VALORES E DIVISAO DE PREMIO' */
            _.Display($"FIM DAS CORRENC COBERT COM VALORES E DIVISAO DE PREMIO");

            /*" -2672- DISPLAY 'LK-RETURN-CODE             = ' LK-RETURN-CODE */
            _.Display($"LK-RETURN-CODE             = {PARAMETROS.LK_RETURN_CODE}");

            /*" -2673- DISPLAY 'LK-MENSAGEM                = ' LK-MENSAGEM */
            _.Display($"LK-MENSAGEM                = {PARAMETROS.LK_MENSAGEM}");

            /*" -2673- . */

        }

        [StopWatch]
        /*" M-8888-99-SAIDA */
        private void M_8888_99_SAIDA(bool isPerform = false)
        {
            /*" -2677- GOBACK. */

            throw new GoBack();

        }
    }
}