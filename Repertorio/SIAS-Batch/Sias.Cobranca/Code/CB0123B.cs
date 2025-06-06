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
using Sias.Cobranca.DB2.CB0123B;

namespace Code
{
    public class CB0123B
    {
        public bool IsCall { get; set; }

        public CB0123B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0123B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  PROJETO CARTAO DE CREDITO CIELO.                              *      */
        /*"      *  FUNCAO: RECEBE O ARQUIVO DE ADESAO GERADO PELO PROGRAMA       *      */
        /*"      *  EM8024B E EFETUA A BAIXA DO PAGAMENTO DE ADESAO VIA CARTAO,   *      */
        /*"      *  BAIXA A PRIMEIRA PARCELA NA TABELA PARCELAS_VIDAZUL,          *      */
        /*"      *  COBER_HIST_VIDAZUL, HIST_LANC_CTA E GERA OPERACAO DE BAIXA NA *      */
        /*"      *  TABELA PARCELA_HISTORICO PARA ENDOSSO QUE ESTA PENDENTE.      *      */
        /*"      *                                                                *      */
        /*"V.05  *  ESTE PROGRAMA SOMENTE TRATA O PAGAMENTO DA ADESAO. DEVOLUCAO  *      */
        /*"V.05  *  DA PRIMEIRA PARCELA NO CENARIO DE DECLINIO, SERA REDIRECIONADA*      */
        /*"V.05  *  PARA O PROGRAMA CB0124B QUE CONCENTRARA TODOS OS DEMAIS MOVI- *      */
        /*"V.05  *  MENTOS, PAGAMENTO DE DEMAIS, DEVOLUCAO E RESTITUICAO.         *      */
        /*"      *                                                                *      */
        /*"      *  PROGRAMADOR ............  FRANK / DANIEL MEDINA               *      */
        /*"      *  DATA CODIFICACAO .......  20/05/2019                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 25/01/2024 *      */
        /*"      *   VERSAO 07               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
        /*"      *                             NA TABELA AVISO_CREDITO PARA FAZER *      */
        /*"      *                             A CONCILIACAO DOS AVISOS DE CREDITO*      */
        /*"      *                             MANUAL COM O DEPOSITO DE TERCEIRO  *      */
        /*"      *                             (DT) NO MCP-ZE.                    *      */
        /*"      *                           - ESTA COLUNA ASSUME COMO DEFAULT O  *      */
        /*"      *                             DOMINIO 'P' (CREDITO NAO CONSUMIDO)*      */
        /*"      *                             E SOMENTE OS PROGRAMAS DO SISTEMA  *      */
        /*"      *                             "ZE" EH QUE ATUALIZARAO A MESMA.   *      */
        /*"      *                           - JAZZ - DEMANDA - 569880            *      */
        /*"      *                                    TAREFA  - 569478            *      */
        /*"      *                           - PROCURAR POR V.07                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.06                                               *      */
        /*"      *  JAZ......: 300816 (ABEND)      PROGRAMADOR: FRANK CARVALHO    *      */
        /*"      *  DATA ....: 03/08/2021                                         *      */
        /*"      *  DESCRICAO: CORRIGIR A VARIAVEL DA TABELA HIST_LANC_CTA.       *      */
        /*"      *             OCORR_HISTORICO PARA OCORR_HISTORICOCTA            *      */
        /*"      *                                          PROCURE POR V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.05                                               *      */
        /*"      *  JAZ......: 251270 / 2019230    PROGRAMADOR: TERCIO / FRANK    *      */
        /*"      *  DATA ....: 24/04/2020                                         *      */
        /*"      *  DESCRICAO: REMOVER AS ALTERACOES REFERENTES A ESTORNO MANUAL. *      */
        /*"      *             NAO EFETUAR BAIXA FINANCEIRA QUANDO PROPOSTA FOR   *      */
        /*"      *             DECLINADA.                                         *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.04                                               *      */
        /*"      *  JAZ......: 255.984         PROGRAMADOR: FRANK CARVALHO        *      */
        /*"      *  DATA ....: 09/09/2020                                         *      */
        /*"      *  DESCRICAO: RECUPERAR A PARCELA COM SITUACAO DE CANCELADA, UMA *      */
        /*"      *             VEZ QUE A MESMA TEVE A SITUACAO ALTERADA PELO PRO- *      */
        /*"      *             GRAMA VA0972B.                                     *      */
        /*"      *                                          PROCURE POR V.04      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.03                                               *      */
        /*"      *  JAZ......: 229.994         PROGRAMADOR: FRANK CARVALHO        *      */
        /*"      *  DATA ....: 15/01/2020                                         *      */
        /*"      *  DESCRICAO: NAO REALIZAR UPDATE DO CAMPO TIMESTAMP AO ATUALIZAR*      */
        /*"      *             A SITUACAO, O CAMPO SERA UTILIZADO PARA A DATA DE  *      */
        /*"      *             GERACAO DA PARCELA ATE QUE TENHAMOS UM CAMPO ESPE- *      */
        /*"      *             FICO.                                              *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.02                                               *      */
        /*"      *  JAZ......: 224.866         PROGRAMADOR: FRANK CARVALHO        *      */
        /*"      *  DATA ....: 30/10/2019                                         *      */
        /*"      *  DESCRICAO: ATUALIZAR NUM-CARTAO-CREDITO MASCARADO NA BASE DO  *      */
        /*"      *             SIAS (OPCAO_PAG_VIDAZUL).                          *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  VERSAO...: V.01                                               *      */
        /*"      *  JAZ......: 177439          PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 16/09/2019                                         *      */
        /*"      *  DESCRICAO:                                                    *      */
        /*"      *  OCORR�NCIA DE FALHA N� 177439                                 *      */
        /*"      *  SISTEMA: CONTABILIDADE GERAL                                  *      */
        /*"      *  PROGRAMA: GL0001B                                             *      */
        /*"      *  ROTINA: JPGLD01                                               *      */
        /*"      *  DESCRI��O: SQLCODE 100                                        *      */
        /*"      *  DATA DA OCORR�NCIA: 17/09/2019 02:49:04                       *      */
        /*"      *                                          PROCURE POR V.01      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.XX                                               *      */
        /*"      *  JAZ......: XXXXX           PROGRAMADOR:                       *      */
        /*"      *  DATA ....: 99/99/9999                                         *      */
        /*"      *  DESCRICAO:                                                    *      */
        /*"      *                                          PROCURE POR V.XX      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _CCADESAO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis CCADESAO
        {
            get
            {
                _.Move(REG_CCADESAO, _CCADESAO); VarBasis.RedefinePassValue(REG_CCADESAO, _CCADESAO, REG_CCADESAO); return _CCADESAO;
            }
        }
        /*"01        REG-CCADESAO.*/
        public CB0123B_REG_CCADESAO REG_CCADESAO { get; set; } = new CB0123B_REG_CCADESAO();
        public class CB0123B_REG_CCADESAO : VarBasis
        {
            /*"  03      REG-TIPO-REGISTRO        PIC  9(003).*/
            public IntBasis REG_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  03      FILLER                   PIC  X(147).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "147", "X(147)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  ABEN.*/
        public CB0123B_ABEN ABEN { get; set; } = new CB0123B_ABEN();
        public class CB0123B_ABEN : VarBasis
        {
            /*"  03     WABEND.*/
            public CB0123B_WABEND WABEND { get; set; } = new CB0123B_WABEND();
            public class CB0123B_WABEND : VarBasis
            {
                /*"    05   FILLER                 PIC  X(010) VALUE        ' CB0123B  '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB0123B  ");
                /*"    05   FILLER                 PIC  X(028) VALUE        ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05   WNR-EXEC-SQL           PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03     WABEND1.*/
            }
            public CB0123B_WABEND1 WABEND1 { get; set; } = new CB0123B_WABEND1();
            public class CB0123B_WABEND1 : VarBasis
            {
                /*"    05   FILLER                 PIC  X(011) VALUE        ' SQLCODE = '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    05   WS-SQLCODE             PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05   FILLER                 PIC  X(012) VALUE        ' SQLERRD1 = '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"    05   WSQLERRD1              PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05   FILLER                 PIC  X(012) VALUE        ' SQLERRD2 = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"    05   WSQLERRD2              PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01     HEAD01-CIELO.*/
            }
        }
        public CB0123B_HEAD01_CIELO HEAD01_CIELO { get; set; } = new CB0123B_HEAD01_CIELO();
        public class CB0123B_HEAD01_CIELO : VarBasis
        {
            /*"  05   HEAD01-TIPO-REGISTRO     PIC  9(003).*/
            public IntBasis HEAD01_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   HEAD01-TIPO-ARQUIVO      PIC  9(003).*/
            public IntBasis HEAD01_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   HEAD01-DATA-GERACAO.*/
            public CB0123B_HEAD01_DATA_GERACAO HEAD01_DATA_GERACAO { get; set; } = new CB0123B_HEAD01_DATA_GERACAO();
            public class CB0123B_HEAD01_DATA_GERACAO : VarBasis
            {
                /*"    10 HEAD01-ANO               PIC  9(004).*/
                public IntBasis HEAD01_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10 HEAD01-MES               PIC  9(002).*/
                public IntBasis HEAD01_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 HEAD01-DIA               PIC  9(002).*/
                public IntBasis HEAD01_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05   HEAD01-COD-CONVENIO      PIC  9(004).*/
            }
            public IntBasis HEAD01_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05   HEAD01-NSAS              PIC  9(006).*/
            public IntBasis HEAD01_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05   FILLER                   PIC  X(126).*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01     REG-CIELO.*/
        }
        public CB0123B_REG_CIELO REG_CIELO { get; set; } = new CB0123B_REG_CIELO();
        public class CB0123B_REG_CIELO : VarBasis
        {
            /*"  05   MCIELO-TIPO-REGISTRO     PIC  9(003).*/
            public IntBasis MCIELO_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   MCIELO-NUM-PROPOSTA      PIC  9(016).*/
            public IntBasis MCIELO_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05   MCIELO-NUM-PARCELA       PIC  9(003).*/
            public IntBasis MCIELO_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   MCIELO-NUM-IDLG          PIC  X(040).*/
            public StringBasis MCIELO_NUM_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05   MCIELO-DATA-VENCIMENTO   PIC  X(010).*/
            public StringBasis MCIELO_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05   MCIELO-DATA-CAPTURA      PIC  X(010).*/
            public StringBasis MCIELO_DATA_CAPTURA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05   MCIELO-DATA-CREDITO      PIC  X(010).*/
            public StringBasis MCIELO_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05   MCIELO-VLR-COBRANCA      PIC  9(013)V99.*/
            public DoubleBasis MCIELO_VLR_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05   MCIELO-VLR-LIQUIDO       PIC  9(013)V99.*/
            public DoubleBasis MCIELO_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05   MCIELO-VLR-TAX-ADM       PIC  9(013)V99.*/
            public DoubleBasis MCIELO_VLR_TAX_ADM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05   MCIELO-COD-MOVIMENTO     PIC  X(002).*/
            public StringBasis MCIELO_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05   MCIELO-COD-RETORNO       PIC  X(003).*/
            public StringBasis MCIELO_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05   FILLER                   PIC  X(014).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"01     TRAI01-CIELO.*/
        }
        public CB0123B_TRAI01_CIELO TRAI01_CIELO { get; set; } = new CB0123B_TRAI01_CIELO();
        public class CB0123B_TRAI01_CIELO : VarBasis
        {
            /*"  05   TRAI01-TIPO-REGISTRO     PIC  9(003).*/
            public IntBasis TRAI01_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   TRAI01-DATA-MOVIMENTO.*/
            public CB0123B_TRAI01_DATA_MOVIMENTO TRAI01_DATA_MOVIMENTO { get; set; } = new CB0123B_TRAI01_DATA_MOVIMENTO();
            public class CB0123B_TRAI01_DATA_MOVIMENTO : VarBasis
            {
                /*"    10 TRAI01-ANO               PIC  9(004).*/
                public IntBasis TRAI01_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10 TRAI01-MES               PIC  9(002).*/
                public IntBasis TRAI01_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 TRAI01-DIA               PIC  9(002).*/
                public IntBasis TRAI01_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05   TRAI01-COD-CONVENIO      PIC  9(004).*/
            }
            public IntBasis TRAI01_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05   TRAI01-NSAS              PIC  9(005).*/
            public IntBasis TRAI01_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05   TRAI01-QTD-TOTAL         PIC  9(009).*/
            public IntBasis TRAI01_QTD_TOTAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05   TRAI01-VLR-TOTAL         PIC  9(015)V99.*/
            public DoubleBasis TRAI01_VLR_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05   FILLER                   PIC  X(074).*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)."), @"");
            /*"01  AREA-DE-WORK.*/
        }
        public CB0123B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB0123B_AREA_DE_WORK();
        public class CB0123B_AREA_DE_WORK : VarBasis
        {
            /*"  03  WS-CONT-LIDOS            PIC  9(006).*/
            public IntBasis WS_CONT_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  03  WS-IN-MOVIMCOB           PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_IN_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-IN-AVISOCRE           PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_IN_AVISOCRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-IN-AVISOSAL           PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_IN_AVISOSAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-IN-CONDESCE           PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_IN_CONDESCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-IN-PARCEHIS           PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_IN_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-UP-PARC-VIDAZUL       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_UP_PARC_VIDAZUL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-UP-COBER-HIS-VA       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_UP_COBER_HIS_VA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-UP-HIS-LANC-CTA       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_UP_HIS_LANC_CTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-UP-PARCELAS           PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_UP_PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-UP-ENDOSSOS           PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_UP_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-DES-TIPO-SIT          PIC  X(040).*/
            public StringBasis WS_DES_TIPO_SIT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  03  WS-FIM-MOVIMENTO         PIC  X(01)     VALUE SPACES.*/
            public StringBasis WS_FIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  03  WS-COD-CODPRODU          PIC S9(004)    COMP.*/
            public IntBasis WS_COD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-VLPRMTOT              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLTARIFA              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLBALCAO              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLIOCC                PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLDESCON              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-SDOATUAL              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_SDOATUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-DATA-GERACAO-PARCELA  PIC  X(010)    VALUE SPACES.*/
            public StringBasis WS_DATA_GERACAO_PARCELA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03  VIND-DTQITBCO            PIC S9(004)    COMP.*/
            public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-CODEMP              PIC S9(004)    COMP.*/
            public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-ORIGEM              PIC S9(004)    COMP.*/
            public IntBasis VIND_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-VALADT              PIC S9(004)    COMP.*/
            public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-CCRE                PIC S9(004)    COMP.*/
            public IntBasis VIND_CCRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-FIM-PROD              PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_FIM_PROD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-LD-PRODUTOS           PIC  9(007) VALUE ZEROS.*/
            public IntBasis WS_LD_PRODUTOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-SUBS                  PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-SUBS1                 PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-SUBS2                 PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-VLDESPES              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLPRMLIQ              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-NSAC                  PIC S9(004)    COMP.*/
            public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03    WS-DATA-REL           PIC  X(010) VALUE SPACES.*/
            public StringBasis WS_DATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03    FILLER            REDEFINES      WS-DATA-REL.*/
            private _REDEF_CB0123B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_CB0123B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_CB0123B_FILLER_9(); _.Move(WS_DATA_REL, _filler_9); VarBasis.RedefinePassValue(WS_DATA_REL, _filler_9, WS_DATA_REL); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS_DATA_REL); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS_DATA_REL); }
            }  //Redefines
            public class _REDEF_CB0123B_FILLER_9 : VarBasis
            {
                /*"    10  WS-DAT-REL-ANO        PIC  9(004).*/
                public IntBasis WS_DAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  FILLER                PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10  WS-DAT-REL-MES        PIC  9(002).*/
                public IntBasis WS_DAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  FILLER                PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10  WS-DAT-REL-DIA        PIC  9(002).*/
                public IntBasis WS_DAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03    WS-TIME.*/

                public _REDEF_CB0123B_FILLER_9()
                {
                    WS_DAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WS_DAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WS_DAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0123B_WS_TIME WS_TIME { get; set; } = new CB0123B_WS_TIME();
            public class CB0123B_WS_TIME : VarBasis
            {
                /*"    10  WS-HH-TIME             PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  WS-MM-TIME             PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  WS-SS-TIME             PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  WS-CC-TIME             PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03    WS-HORA-EDIT.*/
            }
            public CB0123B_WS_HORA_EDIT WS_HORA_EDIT { get; set; } = new CB0123B_WS_HORA_EDIT();
            public class CB0123B_WS_HORA_EDIT : VarBasis
            {
                /*"    10  WS-HORA-HH-EDIT        PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_HORA_HH_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                 PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10  WS-HORA-MM-EDIT        PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_HORA_MM_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                 PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10  WS-HORA-SS-EDIT        PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_HORA_SS_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03    WS-NUM-CARTAO-CRED-SAP.*/
            }
            public CB0123B_WS_NUM_CARTAO_CRED_SAP WS_NUM_CARTAO_CRED_SAP { get; set; } = new CB0123B_WS_NUM_CARTAO_CRED_SAP();
            public class CB0123B_WS_NUM_CARTAO_CRED_SAP : VarBasis
            {
                /*"    10  FILLER                 PIC  X(002).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10  WS-NUM-CART-CRED16     PIC  X(016).*/
                public StringBasis WS_NUM_CART_CRED16 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"    10  FILLER                 PIC  X(007).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"01  AUX-TABELAS.*/
            }
        }
        public CB0123B_AUX_TABELAS AUX_TABELAS { get; set; } = new CB0123B_AUX_TABELAS();
        public class CB0123B_AUX_TABELAS : VarBasis
        {
            /*"  03          WS-TABG-VALORES.*/
            public CB0123B_WS_TABG_VALORES WS_TABG_VALORES { get; set; } = new CB0123B_WS_TABG_VALORES();
            public class CB0123B_WS_TABG_VALORES : VarBasis
            {
                /*"    05        WS-TABG-OCORREPRD   OCCURS      80000  TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<CB0123B_WS_TABG_OCORREPRD> WS_TABG_OCORREPRD { get; set; } = new ListBasis<CB0123B_WS_TABG_OCORREPRD>(80000);
                public class CB0123B_WS_TABG_OCORREPRD : VarBasis
                {
                    /*"      10      WS-TABG-CODPRODU    PIC S9(004)        COMP.*/
                    public IntBasis WS_TABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WS-TABG-OCORRETIP   OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<CB0123B_WS_TABG_OCORRETIP> WS_TABG_OCORRETIP { get; set; } = new ListBasis<CB0123B_WS_TABG_OCORRETIP>(003);
                    public class CB0123B_WS_TABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WS-TABG-TIPO        PIC  X(001).*/
                        public StringBasis WS_TABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WS-TABG-OCORRESIT   OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<CB0123B_WS_TABG_OCORRESIT> WS_TABG_OCORRESIT { get; set; } = new ListBasis<CB0123B_WS_TABG_OCORRESIT>(002);
                        public class CB0123B_WS_TABG_OCORRESIT : VarBasis
                        {
                            /*"          20  WS-TABG-SITUACAO    PIC  X(001).*/
                            public StringBasis WS_TABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          20  WS-TABG-QTDE        PIC S9(009)        COMP.*/
                            public IntBasis WS_TABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          20  WS-TABG-VLPRMTOT    PIC S9(013)V99 COMP-3 VALUE 0.*/
                            public DoubleBasis WS_TABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WS-TABG-VLTARIFA    PIC S9(013)V99 COMP-3 VALUE 0.*/
                            public DoubleBasis WS_TABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WS-TABG-VLBALCAO    PIC S9(013)V99 COMP-3 VALUE 0.*/
                            public DoubleBasis WS_TABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WS-TABG-VLIOCC      PIC S9(013)V99 COMP-3 VALUE 0.*/
                            public DoubleBasis WS_TABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WS-TABG-VLDESCON    PIC S9(013)V99 COMP-3 VALUE 0.*/
                            public DoubleBasis WS_TABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                        }
                    }
                }
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.CB042 CB042 { get; set; } = new Dclgens.CB042();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.CONDESCE CONDESCE { get; set; } = new Dclgens.CONDESCE();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.GE407 GE407 { get; set; } = new Dclgens.GE407();
        public Dclgens.GE408 GE408 { get; set; } = new Dclgens.GE408();

        public CB0123B_C0_PRODUTOS C0_PRODUTOS { get; set; } = new CB0123B_C0_PRODUTOS(false);
        string GetQuery_C0_PRODUTOS()
        {
            var query = @$"SELECT COD_PRODUTO
							FROM SEGUROS.PRODUTO WHERE COD_EMPRESA IN (0
							,10
							,11) ORDER BY COD_PRODUTO";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CCADESAO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CCADESAO.SetFile(CCADESAO_FILE_NAME_P);
                InitializeGetQuery();

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

        public void InitializeGetQuery()
        {
            C0_PRODUTOS.GetQueryEvent += GetQuery_C0_PRODUTOS;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -348- MOVE '0000' TO WNR-EXEC-SQL */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -349- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -350- DISPLAY ' CB0123B - PROCESSA <CCADESAO> ' */
            _.Display($" CB0123B - PROCESSA <CCADESAO> ");

            /*" -351- DISPLAY ' ' */
            _.Display($" ");

            /*" -352- DISPLAY 'VERSAO V.06 : ' FUNCTION WHEN-COMPILED ' - 300.816' */

            $"VERSAO V.06 : FUNCTION{_.WhenCompiled()} - 300.816"
            .Display();

            /*" -353- DISPLAY ' ' */
            _.Display($" ");

            /*" -360- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -361- DISPLAY '   ' */
            _.Display($"   ");

            /*" -363- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -366- PERFORM R0100-00-INICIO */

            R0100_00_INICIO_SECTION();

            /*" -371- PERFORM R0300-00-PROCESSA-MOVIMENTO UNTIL WS-FIM-MOVIMENTO = 'S' */

            while (!(AREA_DE_WORK.WS_FIM_MOVIMENTO == "S"))
            {

                R0300_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -372- IF WS-IN-MOVIMCOB GREATER ZEROS */

            if (AREA_DE_WORK.WS_IN_MOVIMCOB > 00)
            {

                /*" -373- PERFORM R3000-00-PROCESSA-FINAL */

                R3000_00_PROCESSA_FINAL_SECTION();

                /*" -375- END-IF */
            }


            /*" -375- PERFORM R0051-00-FINALIZA. */

            R0051_00_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0051-00-FINALIZA-SECTION */
        private void R0051_00_FINALIZA_SECTION()
        {
            /*" -383- MOVE '0051' TO WNR-EXEC-SQL */
            _.Move("0051", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -385- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -386- DISPLAY ' ' . */
            _.Display($" ");

            /*" -387- DISPLAY 'LIDOS MOVIMENTO .............. ' WS-CONT-LIDOS */
            _.Display($"LIDOS MOVIMENTO .............. {AREA_DE_WORK.WS_CONT_LIDOS}");

            /*" -388- DISPLAY ' ' . */
            _.Display($" ");

            /*" -389- DISPLAY 'QTDE PRODUTOS................. ' WS-LD-PRODUTOS */
            _.Display($"QTDE PRODUTOS................. {AREA_DE_WORK.WS_LD_PRODUTOS}");

            /*" -390- DISPLAY ' ' . */
            _.Display($" ");

            /*" -391- DISPLAY 'INSERIDOS MOVIMCOB............ ' WS-IN-MOVIMCOB */
            _.Display($"INSERIDOS MOVIMCOB............ {AREA_DE_WORK.WS_IN_MOVIMCOB}");

            /*" -392- DISPLAY 'INSERIDOS AVISOSCRE........... ' WS-IN-AVISOCRE */
            _.Display($"INSERIDOS AVISOSCRE........... {AREA_DE_WORK.WS_IN_AVISOCRE}");

            /*" -393- DISPLAY 'INSERIDOS AVISOSAL............ ' WS-IN-AVISOSAL */
            _.Display($"INSERIDOS AVISOSAL............ {AREA_DE_WORK.WS_IN_AVISOSAL}");

            /*" -394- DISPLAY ' ' . */
            _.Display($" ");

            /*" -396- DISPLAY 'ATUALIZADOS PARC_VIDAZUL...... ' WS-UP-PARC-VIDAZUL */
            _.Display($"ATUALIZADOS PARC_VIDAZUL...... {AREA_DE_WORK.WS_UP_PARC_VIDAZUL}");

            /*" -398- DISPLAY 'ATUALIZADOS COBER_HIST_VIDAZUL ' WS-UP-COBER-HIS-VA */
            _.Display($"ATUALIZADOS COBER_HIST_VIDAZUL {AREA_DE_WORK.WS_UP_COBER_HIS_VA}");

            /*" -400- DISPLAY 'ATUALIZADOS HIST_LANC_VA...... ' WS-UP-HIS-LANC-CTA */
            _.Display($"ATUALIZADOS HIST_LANC_VA...... {AREA_DE_WORK.WS_UP_HIS_LANC_CTA}");

            /*" -401- DISPLAY ' ' */
            _.Display($" ");

            /*" -403- CLOSE CCADESAO */
            CCADESAO.Close();

            /*" -403- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -406- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -407- DISPLAY ' ' */
            _.Display($" ");

            /*" -408- DISPLAY 'CB0123B - FIM NORMAL' */
            _.Display($"CB0123B - FIM NORMAL");

            /*" -410- DISPLAY ' ' */
            _.Display($" ");

            /*" -410- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIO-SECTION */
        private void R0100_00_INICIO_SECTION()
        {
            /*" -415- MOVE '0100' TO WNR-EXEC-SQL */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -417- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -419- OPEN INPUT CCADESAO */
            CCADESAO.Open(REG_CCADESAO);

            /*" -420- INITIALIZE DCLAVISO-CREDITO */
            _.Initialize(
                AVISOCRE.DCLAVISO_CREDITO
            );

            /*" -422- MOVE ZEROS TO WS-SDOATUAL */
            _.Move(0, AREA_DE_WORK.WS_SDOATUAL);

            /*" -425- PERFORM R0110-00-SELECT-V0SISTEMA */

            R0110_00_SELECT_V0SISTEMA_SECTION();

            /*" -428- PERFORM R0120-00-SELECT-AVISOCRE */

            R0120_00_SELECT_AVISOCRE_SECTION();

            /*" -430- PERFORM R0130-00-BUSCAR-PRODUTOS */

            R0130_00_BUSCAR_PRODUTOS_SECTION();

            /*" -432- MOVE SPACES TO WS-FIM-MOVIMENTO */
            _.Move("", AREA_DE_WORK.WS_FIM_MOVIMENTO);

            /*" -434- PERFORM R0150-00-LER-MOVIMENTO */

            R0150_00_LER_MOVIMENTO_SECTION();

            /*" -434- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-SELECT-V0SISTEMA-SECTION */
        private void R0110_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -443- MOVE '0110' TO WNR-EXEC-SQL */
            _.Move("0110", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -449- PERFORM R0110_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0110_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -452- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -453- WHEN 0 */
                case 0:

                    /*" -454- DISPLAY 'DATA DO MOVIMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
                    _.Display($"DATA DO MOVIMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                    /*" -455- WHEN +100 */
                    break;
                case +100:

                    /*" -456- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -457- DISPLAY 'R0110-00-SISTEMA NAO ENCONTRADO ' */
                    _.Display($"R0110-00-SISTEMA NAO ENCONTRADO ");

                    /*" -458- DISPLAY 'IDE_SISTEMA  = ' SISTEMAS-IDE-SISTEMA */
                    _.Display($"IDE_SISTEMA  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                    /*" -459- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -460- WHEN OTHER */
                    break;
                default:

                    /*" -461- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -462- DISPLAY 'R0110-00-ERRO SELECT SISTEMAS ' */
                    _.Display($"R0110-00-ERRO SELECT SISTEMAS ");

                    /*" -463- DISPLAY 'IDE_SISTEMA  = ' SISTEMAS-IDE-SISTEMA */
                    _.Display($"IDE_SISTEMA  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                    /*" -464- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -464- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R0110-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0110_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -449- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC */

            var r0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-SELECT-AVISOCRE-SECTION */
        private void R0120_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -472- MOVE '0120' TO WNR-EXEC-SQL */
            _.Move("0120", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -474- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -483- PERFORM R0120_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R0120_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -486- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -487- WHEN 0 */
                case 0:

                    /*" -488- IF (AVISOCRE-NUM-AVISO-CREDITO NOT LESS 902099999) */

                    if ((AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO >= 902099999))
                    {

                        /*" -489- DISPLAY 'R0120-00 - NRAVISO ULTRAPASSA FAIXA   ' */
                        _.Display($"R0120-00 - NRAVISO ULTRAPASSA FAIXA   ");

                        /*" -490- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -491- ELSE */
                    }
                    else
                    {


                        /*" -492- IF AVISOCRE-NUM-AVISO-CREDITO EQUAL ZEROS */

                        if (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO == 00)
                        {

                            /*" -493- MOVE 902000001 TO AVISOCRE-NUM-AVISO-CREDITO */
                            _.Move(902000001, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

                            /*" -494- ELSE */
                        }
                        else
                        {


                            /*" -495- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO */
                            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;

                            /*" -496- END-IF */
                        }


                        /*" -497- END-IF */
                    }


                    /*" -498- WHEN OTHER */
                    break;
                default:

                    /*" -499- DISPLAY 'R0120-00 - PROBLEMAS NO SELECT(AVISOCRE)' */
                    _.Display($"R0120-00 - PROBLEMAS NO SELECT(AVISOCRE)");

                    /*" -500- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -500- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R0120-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R0120_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -483- EXEC SQL SELECT VALUE(MAX(NUM_AVISO_CREDITO),0) INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = 104 AND AGE_AVISO = 7011 AND NUM_AVISO_CREDITO BETWEEN 902000000 AND 902099999 WITH UR END-EXEC */

            var r0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 = new R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1.Execute(r0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-BUSCAR-PRODUTOS-SECTION */
        private void R0130_00_BUSCAR_PRODUTOS_SECTION()
        {
            /*" -508- MOVE '0130' TO WNR-EXEC-SQL */
            _.Move("0130", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -510- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -511- MOVE 1 TO WS-LD-PRODUTOS */
            _.Move(1, AREA_DE_WORK.WS_LD_PRODUTOS);

            /*" -513- MOVE SPACES TO WS-FIM-PROD */
            _.Move("", AREA_DE_WORK.WS_FIM_PROD);

            /*" -515- PERFORM R0130_00_BUSCAR_PRODUTOS_DB_OPEN_1 */

            R0130_00_BUSCAR_PRODUTOS_DB_OPEN_1();

            /*" -518- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -519- DISPLAY 'R0130-PROBLEMAS AO ABRIR (C0-PRODUTOS) ' */
                _.Display($"R0130-PROBLEMAS AO ABRIR (C0-PRODUTOS) ");

                /*" -520- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -522- END-IF */
            }


            /*" -524- PERFORM R0670-00-FETCH-C0-PRODUTO */

            R0670_00_FETCH_C0_PRODUTO_SECTION();

            /*" -525- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -527- MOVE ZEROS TO PRODUTO-COD-PRODUTO */
            _.Move(0, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -531- PERFORM R0620-00-MOVE-DADOS UNTIL WS-FIM-PROD EQUAL 'S' */

            while (!(AREA_DE_WORK.WS_FIM_PROD == "S"))
            {

                R0620_00_MOVE_DADOS_SECTION();
            }

            /*" -533- MOVE 9999 TO PRODUTO-COD-PRODUTO */
            _.Move(9999, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -534- PERFORM R0620-00-MOVE-DADOS UNTIL WS-SUBS GREATER 8000. */

            while (!(AREA_DE_WORK.WS_SUBS > 8000))
            {

                R0620_00_MOVE_DADOS_SECTION();
            }

        }

        [StopWatch]
        /*" R0130-00-BUSCAR-PRODUTOS-DB-OPEN-1 */
        public void R0130_00_BUSCAR_PRODUTOS_DB_OPEN_1()
        {
            /*" -515- EXEC SQL OPEN C0-PRODUTOS END-EXEC */

            C0_PRODUTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-LER-MOVIMENTO-SECTION */
        private void R0150_00_LER_MOVIMENTO_SECTION()
        {
            /*" -543- MOVE '0150' TO WNR-EXEC-SQL */
            _.Move("0150", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -544- READ CCADESAO AT END */
            try
            {
                CCADESAO.Read(() =>
                {

                    /*" -546- MOVE 'S' TO WS-FIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WS_FIM_MOVIMENTO);

                    /*" -547- GO TO R0150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/ //GOTO
                    return;

                    /*" -548- END-READ */
                });

                _.Move(CCADESAO.Value, REG_CCADESAO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -550- ADD 1 TO WS-CONT-LIDOS */
            AREA_DE_WORK.WS_CONT_LIDOS.Value = AREA_DE_WORK.WS_CONT_LIDOS + 1;

            /*" -552- IF WS-CONT-LIDOS EQUAL 1 AND REG-TIPO-REGISTRO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONT_LIDOS == 1 && REG_CCADESAO.REG_TIPO_REGISTRO != 00)
            {

                /*" -553- DISPLAY '*** CB0123B *** FITA SEM HEADER' */
                _.Display($"*** CB0123B *** FITA SEM HEADER");

                /*" -554- MOVE ZEROS TO SQLCODE */
                _.Move(0, DB.SQLCODE);

                /*" -555- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -557- END-IF */
            }


            /*" -558-  EVALUATE REG-TIPO-REGISTRO  */

            /*" -559-  WHEN ZEROS  */

            /*" -559- IF   REG-TIPO-REGISTRO EQUALS  ZEROS */

            if (REG_CCADESAO.REG_TIPO_REGISTRO == 00)
            {

                /*" -560- MOVE REG-CCADESAO TO HEAD01-CIELO */
                _.Move(CCADESAO?.Value, HEAD01_CIELO);

                /*" -561- PERFORM R0155-00-VALIDA-HEADER */

                R0155_00_VALIDA_HEADER_SECTION();

                /*" -562- GO TO R0150-00-LER-MOVIMENTO */
                new Task(() => R0150_00_LER_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -563-  WHEN 001  */

                /*" -563- ELSE IF   REG-TIPO-REGISTRO EQUALS  001 */
            }
            else

            if (REG_CCADESAO.REG_TIPO_REGISTRO == 001)
            {

                /*" -564- MOVE REG-CCADESAO TO REG-CIELO */
                _.Move(CCADESAO?.Value, REG_CIELO);

                /*" -565-  WHEN 999  */

                /*" -565- ELSE IF   REG-TIPO-REGISTRO EQUALS  999 */
            }
            else

            if (REG_CCADESAO.REG_TIPO_REGISTRO == 999)
            {

                /*" -566- MOVE REG-CCADESAO TO TRAI01-CIELO */
                _.Move(CCADESAO?.Value, TRAI01_CIELO);

                /*" -567- IF TRAI01-TIPO-REGISTRO EQUAL 999 */

                if (TRAI01_CIELO.TRAI01_TIPO_REGISTRO == 999)
                {

                    /*" -568- DISPLAY '*** CB0123B *** TRAILLER PROCESSADO' */
                    _.Display($"*** CB0123B *** TRAILLER PROCESSADO");

                    /*" -569- GO TO R0150-00-LER-MOVIMENTO */
                    new Task(() => R0150_00_LER_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -570- END-IF */
                }


                /*" -571-  WHEN OTHER  */

                /*" -571- ELSE */
            }
            else
            {


                /*" -572- DISPLAY 'ERRO - TIPO DE REGISTRO NAO ESPERADO' */
                _.Display($"ERRO - TIPO DE REGISTRO NAO ESPERADO");

                /*" -573- DISPLAY 'REG-TIPO-REGISTRO = ' REG-TIPO-REGISTRO */
                _.Display($"REG-TIPO-REGISTRO = {REG_CCADESAO.REG_TIPO_REGISTRO}");

                /*" -574- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -574-  END-EVALUATE.  */

                /*" -574- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0155-00-VALIDA-HEADER-SECTION */
        private void R0155_00_VALIDA_HEADER_SECTION()
        {
            /*" -582- MOVE '0155' TO WNR-EXEC-SQL */
            _.Move("0155", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -584- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -585- IF HEAD01-TIPO-ARQUIVO NOT EQUAL 001 */

            if (HEAD01_CIELO.HEAD01_TIPO_ARQUIVO != 001)
            {

                /*" -586- DISPLAY '*** CB0123B *** MOVIMENTO NAO E DE ADESAO' */
                _.Display($"*** CB0123B *** MOVIMENTO NAO E DE ADESAO");

                /*" -587- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -591- END-IF */
            }


            /*" -592- IF HEAD01-NSAS >= 32767 */

            if (HEAD01_CIELO.HEAD01_NSAS >= 32767)
            {

                /*" -593- DISPLAY '*** CB0123B *** ESTOURO DE CAMPO SMALLINT' */
                _.Display($"*** CB0123B *** ESTOURO DE CAMPO SMALLINT");

                /*" -594- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -596- END-IF */
            }


            /*" -598- MOVE HEAD01-NSAS TO WS-NSAC */
            _.Move(HEAD01_CIELO.HEAD01_NSAS, AREA_DE_WORK.WS_NSAC);

            /*" -598- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0155_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0300_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -606- MOVE '0300' TO WNR-EXEC-SQL */
            _.Move("0300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -609- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -612- PERFORM R0305-00-VERIFICAR-PARCELA */

            R0305_00_VERIFICAR_PARCELA_SECTION();

            /*" -615- PERFORM R0310-00-SELECT-PARCELAS */

            R0310_00_SELECT_PARCELAS_SECTION();

            /*" -617- PERFORM R0320-00-TRATA-NUM-CARTAO */

            R0320_00_TRATA_NUM_CARTAO_SECTION();

            /*" -618- EVALUATE MCIELO-COD-MOVIMENTO */
            switch (REG_CIELO.MCIELO_COD_MOVIMENTO.Value.Trim())
            {

                /*" -619- WHEN '03' */
                case "03":

                    /*" -622- IF MCIELO-COD-RETORNO EQUAL ' CC' */

                    if (REG_CIELO.MCIELO_COD_RETORNO == " CC")
                    {

                        /*" -625- PERFORM R3212-UPDATE-PARCELAS-VIDAZUL */

                        R3212_UPDATE_PARCELAS_VIDAZUL_SECTION();

                        /*" -627- PERFORM R3213-UPD-COBER-HIST-VIDAZUL */

                        R3213_UPD_COBER_HIST_VIDAZUL_SECTION();

                        /*" -628- ELSE */
                    }
                    else
                    {


                        /*" -629- DISPLAY 'ERRO - CODIGO DE RETORNO NAO ESPERADO PARA CC' */
                        _.Display($"ERRO - CODIGO DE RETORNO NAO ESPERADO PARA CC");

                        /*" -630- DISPLAY 'MCIELO-COD-RETORNO = ' MCIELO-COD-RETORNO */
                        _.Display($"MCIELO-COD-RETORNO = {REG_CIELO.MCIELO_COD_RETORNO}");

                        /*" -631- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -632- END-IF */
                    }


                    /*" -633- WHEN '04' */
                    break;
                case "04":

                    /*" -636- IF MCIELO-COD-RETORNO EQUAL ' 00' */

                    if (REG_CIELO.MCIELO_COD_RETORNO == " 00")
                    {

                        /*" -639- PERFORM R0350-00-PROCESSA-REGISTRO */

                        R0350_00_PROCESSA_REGISTRO_SECTION();

                        /*" -642- PERFORM R3210-UPD-COBER-HIST-VIDAZUL */

                        R3210_UPD_COBER_HIST_VIDAZUL_SECTION();

                        /*" -645- PERFORM R3214-UPDATE-HIST-LANC-CTA */

                        R3214_UPDATE_HIST_LANC_CTA_SECTION();

                        /*" -646- PERFORM R0700-00-PROCESSA-COBRANCA */

                        R0700_00_PROCESSA_COBRANCA_SECTION();

                        /*" -647- ELSE */
                    }
                    else
                    {


                        /*" -648- DISPLAY 'ERRO - CODIGO DE RETORNO NAO ESPERADO PARA 04' */
                        _.Display($"ERRO - CODIGO DE RETORNO NAO ESPERADO PARA 04");

                        /*" -649- DISPLAY 'MCIELO-COD-RETORNO = ' MCIELO-COD-RETORNO */
                        _.Display($"MCIELO-COD-RETORNO = {REG_CIELO.MCIELO_COD_RETORNO}");

                        /*" -650- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -651- END-IF */
                    }


                    /*" -654- END-EVALUATE */
                    break;
            }


            /*" -654- PERFORM R0150-00-LER-MOVIMENTO. */

            R0150_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0305-00-VERIFICAR-PARCELA-SECTION */
        private void R0305_00_VERIFICAR_PARCELA_SECTION()
        {
            /*" -662- MOVE '0305' TO WNR-EXEC-SQL */
            _.Move("0305", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -664- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -665- MOVE MCIELO-NUM-PROPOSTA TO HISLANCT-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -667- MOVE MCIELO-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -693- PERFORM R0305_00_VERIFICAR_PARCELA_DB_SELECT_1 */

            R0305_00_VERIFICAR_PARCELA_DB_SELECT_1();

            /*" -696- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -697- WHEN 0 */
                case 0:

                    /*" -698- CONTINUE */

                    /*" -699- WHEN 100 */
                    break;
                case 100:

                    /*" -700- DISPLAY '0305-00-ERRO-PARCELA DE COBRANCA NAO ENCONTRADA.' */
                    _.Display($"0305-00-ERRO-PARCELA DE COBRANCA NAO ENCONTRADA.");

                    /*" -701- DISPLAY 'NUM_CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -702- DISPLAY 'NUM_PARCELA     = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -703- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -704- WHEN OTHER */
                    break;
                default:

                    /*" -705- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -706- DISPLAY 'R0305-00-ERRO-SELECT PARCELA HIST_LANC_CTA.' */
                    _.Display($"R0305-00-ERRO-SELECT PARCELA HIST_LANC_CTA.");

                    /*" -707- DISPLAY 'NUM_CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -708- DISPLAY 'NUM_PARCELA     = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -709- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -709- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R0305-00-VERIFICAR-PARCELA-DB-SELECT-1 */
        public void R0305_00_VERIFICAR_PARCELA_DB_SELECT_1()
        {
            /*" -693- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.OCORR_HISTORICOCTA , A.SIT_REGISTRO , DATE(C.TIMESTAMP) , B.SIT_REGISTRO INTO :HISLANCT-NUM-CERTIFICADO , :HISLANCT-NUM-PARCELA , :HISLANCT-OCORR-HISTORICOCTA , :HISLANCT-SIT-REGISTRO , :WS-DATA-GERACAO-PARCELA , :PROPOVA-SIT-REGISTRO FROM SEGUROS.HIST_LANC_CTA A , SEGUROS.PROPOSTAS_VA B , SEGUROS.PARCELAS_VIDAZUL C WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA AND A.SIT_REGISTRO IN ( '2' , '3' ) AND A.TIPLANC = '1' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND A.NUM_PARCELA = C.NUM_PARCELA WITH UR END-EXEC */

            var r0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 = new R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1.Execute(r0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
                _.Move(executed_1.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(executed_1.HISLANCT_OCORR_HISTORICOCTA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA);
                _.Move(executed_1.HISLANCT_SIT_REGISTRO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);
                _.Move(executed_1.WS_DATA_GERACAO_PARCELA, AREA_DE_WORK.WS_DATA_GERACAO_PARCELA);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0305_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-SELECT-PARCELAS-SECTION */
        private void R0310_00_SELECT_PARCELAS_SECTION()
        {
            /*" -717- MOVE '0310' TO WNR-EXEC-SQL */
            _.Move("0310", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -719- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -720- MOVE MCIELO-NUM-PROPOSTA TO HISCONPA-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -722- MOVE MCIELO-NUM-PARCELA TO HISCONPA-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -778- PERFORM R0310_00_SELECT_PARCELAS_DB_SELECT_1 */

            R0310_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -781- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -782- WHEN 0 */
                case 0:

                    /*" -783- CONTINUE */

                    /*" -784- WHEN 100 */
                    break;
                case 100:

                    /*" -785- DISPLAY '0310-00-ERRO-REGISTRO NAO ENCONTRAO JOIN PARCELA' */
                    _.Display($"0310-00-ERRO-REGISTRO NAO ENCONTRAO JOIN PARCELA");

                    /*" -786- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -787- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -788- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -789- WHEN -811 */
                    break;
                case -811:

                    /*" -790- DISPLAY '0310-00-ERRO-DUPLIICIDADE JOIN PARCELAS' */
                    _.Display($"0310-00-ERRO-DUPLIICIDADE JOIN PARCELAS");

                    /*" -791- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -792- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -793- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -794- WHEN OTHER */
                    break;
                default:

                    /*" -795- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -796- DISPLAY '0310-00-ERRO-SELECT JOIN PARCELAS      ' */
                    _.Display($"0310-00-ERRO-SELECT JOIN PARCELAS      ");

                    /*" -797- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -798- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -799- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -799- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R0310-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R0310_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -778- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.NUM_ENDOSSO , A.NUM_APOLICE , A.SIT_REGISTRO , C.DAC_PARCELA , C.PRM_TARIFARIO_IX , C.VAL_DESCONTO_IX , C.PRM_LIQUIDO_IX , C.ADICIONAL_FRAC_IX , C.VAL_CUSTO_EMIS_IX , C.VAL_IOCC_IX , C.PRM_TOTAL_IX , C.QTD_DOCUMENTOS , B.COD_PRODUTO , D.TIPO_CORRECAO , D.COD_MOEDA_PRM , D.COD_USUARIO , E.NUM_TITULO INTO :HISCONPA-NUM-CERTIFICADO , :HISCONPA-NUM-PARCELA , :HISCONPA-NUM-ENDOSSO , :HISCONPA-NUM-APOLICE , :HISCONPA-SIT-REGISTRO , :PARCELAS-DAC-PARCELA , :PARCELAS-PRM-TARIFARIO-IX , :PARCELAS-VAL-DESCONTO-IX , :PARCELAS-PRM-LIQUIDO-IX , :PARCELAS-ADICIONAL-FRAC-IX , :PARCELAS-VAL-CUSTO-EMIS-IX , :PARCELAS-VAL-IOCC-IX , :PARCELAS-PRM-TOTAL-IX , :PARCELAS-QTD-DOCUMENTOS , :PROPOVA-COD-PRODUTO , :ENDOSSOS-TIPO-CORRECAO , :ENDOSSOS-COD-MOEDA-PRM , :ENDOSSOS-COD-USUARIO , :COBHISVI-NUM-TITULO FROM SEGUROS.HIST_CONT_PARCELVA A , SEGUROS.PROPOSTAS_VA B , SEGUROS.PARCELAS C , SEGUROS.ENDOSSOS D , SEGUROS.COBER_HIST_VIDAZUL E WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_TITULO > 0 AND A.NUM_PARCELA = :HISCONPA-NUM-PARCELA AND A.COD_OPERACAO BETWEEN 200 AND 299 AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_APOLICE = C.NUM_APOLICE AND A.NUM_ENDOSSO = C.NUM_ENDOSSO AND A.NUM_APOLICE = D.NUM_APOLICE AND A.NUM_ENDOSSO = D.NUM_ENDOSSO AND A.NUM_CERTIFICADO = E.NUM_CERTIFICADO AND A.NUM_PARCELA = E.NUM_PARCELA WITH UR END-EXEC */

            var r0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(executed_1.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(executed_1.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
                _.Move(executed_1.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(executed_1.HISCONPA_SIT_REGISTRO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);
                _.Move(executed_1.PARCELAS_DAC_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);
                _.Move(executed_1.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);
                _.Move(executed_1.PARCELAS_VAL_DESCONTO_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);
                _.Move(executed_1.PARCELAS_PRM_LIQUIDO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);
                _.Move(executed_1.PARCELAS_ADICIONAL_FRAC_IX, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);
                _.Move(executed_1.PARCELAS_VAL_CUSTO_EMIS_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);
                _.Move(executed_1.PARCELAS_VAL_IOCC_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);
                _.Move(executed_1.PARCELAS_PRM_TOTAL_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);
                _.Move(executed_1.PARCELAS_QTD_DOCUMENTOS, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_TIPO_CORRECAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);
                _.Move(executed_1.ENDOSSOS_COD_USUARIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-TRATA-NUM-CARTAO-SECTION */
        private void R0320_00_TRATA_NUM_CARTAO_SECTION()
        {
            /*" -807- MOVE '0320' TO WNR-EXEC-SQL */
            _.Move("0320", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -809- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -811- INITIALIZE DCLOPCAO-PAG-VIDAZUL */
            _.Initialize(
                OPCPAGVI.DCLOPCAO_PAG_VIDAZUL
            );

            /*" -813- PERFORM R0322-00-CONSULTA-NUM-CARTAO */

            R0322_00_CONSULTA_NUM_CARTAO_SECTION();

            /*" -815- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' AND OPCPAGVI-NUM-CARTAO-CREDITO EQUAL SPACES */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5" && OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.IsEmpty())
            {

                /*" -816- PERFORM R0324-00-RECUPERA-NUM-CARTAO */

                R0324_00_RECUPERA_NUM_CARTAO_SECTION();

                /*" -817- PERFORM R0326-00-ATUALIZA-NUM-CARTAO */

                R0326_00_ATUALIZA_NUM_CARTAO_SECTION();

                /*" -819- END-IF */
            }


            /*" -819- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0322-00-CONSULTA-NUM-CARTAO-SECTION */
        private void R0322_00_CONSULTA_NUM_CARTAO_SECTION()
        {
            /*" -827- MOVE '0322' TO WNR-EXEC-SQL */
            _.Move("0322", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -829- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -831- MOVE MCIELO-NUM-PROPOSTA TO OPCPAGVI-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -844- PERFORM R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1 */

            R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1();

            /*" -847- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -848- WHEN 0 */
                case 0:

                    /*" -849- CONTINUE */

                    /*" -850- WHEN 100 */
                    break;
                case 100:

                    /*" -851- DISPLAY 'R0322-00-ERRO-REGISTRO NAO ENCONTRAO OPCAO_PAG_V' */
                    _.Display($"R0322-00-ERRO-REGISTRO NAO ENCONTRAO OPCAO_PAG_V");

                    /*" -852- DISPLAY 'NUM_CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -853- DISPLAY 'DATA_VENCIMENTO = ' MCIELO-DATA-VENCIMENTO */
                    _.Display($"DATA_VENCIMENTO = {REG_CIELO.MCIELO_DATA_VENCIMENTO}");

                    /*" -854- DISPLAY 'DATA_GERACAO    = ' WS-DATA-GERACAO-PARCELA */
                    _.Display($"DATA_GERACAO    = {AREA_DE_WORK.WS_DATA_GERACAO_PARCELA}");

                    /*" -855- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -856- WHEN OTHER */
                    break;
                default:

                    /*" -857- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -858- DISPLAY 'R0322-00-ERRO-SELECT JOIN PARCELAS' */
                    _.Display($"R0322-00-ERRO-SELECT JOIN PARCELAS");

                    /*" -859- DISPLAY 'NUM_CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -860- DISPLAY 'DATA_VENCIMENTO = ' MCIELO-DATA-VENCIMENTO */
                    _.Display($"DATA_VENCIMENTO = {REG_CIELO.MCIELO_DATA_VENCIMENTO}");

                    /*" -861- DISPLAY 'DATA_GERACAO    = ' WS-DATA-GERACAO-PARCELA */
                    _.Display($"DATA_GERACAO    = {AREA_DE_WORK.WS_DATA_GERACAO_PARCELA}");

                    /*" -862- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -864- END-EVALUATE */
                    break;
            }


            /*" -865- IF VIND-CCRE LESS ZEROS */

            if (AREA_DE_WORK.VIND_CCRE < 00)
            {

                /*" -867- MOVE SPACES TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move("", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -869- END-IF */
            }


            /*" -869- . */

        }

        [StopWatch]
        /*" R0322-00-CONSULTA-NUM-CARTAO-DB-SELECT-1 */
        public void R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1()
        {
            /*" -844- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_CARTAO_CREDITO , A.OPCAO_PAGAMENTO INTO :OPCPAGVI-NUM-CERTIFICADO , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CCRE , :OPCPAGVI-OPCAO-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL A WHERE A.NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND A.DATA_INIVIGENCIA <= :WS-DATA-GERACAO-PARCELA AND A.DATA_TERVIGENCIA >= :WS-DATA-GERACAO-PARCELA WITH UR END-EXEC */

            var r0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1 = new R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
                WS_DATA_GERACAO_PARCELA = AREA_DE_WORK.WS_DATA_GERACAO_PARCELA.ToString(),
            };

            var executed_1 = R0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1.Execute(r0322_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_CCRE, AREA_DE_WORK.VIND_CCRE);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0322_99_SAIDA*/

        [StopWatch]
        /*" R0324-00-RECUPERA-NUM-CARTAO-SECTION */
        private void R0324_00_RECUPERA_NUM_CARTAO_SECTION()
        {
            /*" -877- MOVE '0324' TO WNR-EXEC-SQL */
            _.Move("0324", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -879- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -880- MOVE MCIELO-NUM-PROPOSTA TO GE407-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO);

            /*" -881- MOVE MCIELO-NUM-PARCELA TO GE407-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA);

            /*" -883- MOVE MCIELO-NUM-IDLG TO GE407-COD-IDLG */
            _.Move(REG_CIELO.MCIELO_NUM_IDLG, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG);

            /*" -897- PERFORM R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1 */

            R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1();

            /*" -900- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -901- WHEN 0 */
                case 0:

                    /*" -902- CONTINUE */

                    /*" -903- WHEN 100 */
                    break;
                case 100:

                    /*" -905- DISPLAY 'R0324-00-ERRO-REGISTRO NAO ENCONTRADO NA TABELA' 'GE_RETORNO_CA_CIELO' */
                    _.Display($"R0324-00-ERRO-REGISTRO NAO ENCONTRADO NA TABELAGE_RETORNO_CA_CIELO");

                    /*" -906- DISPLAY 'NUM_CERTIFICADO = ' GE407-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                    /*" -907- DISPLAY 'NUM_PARCELA     = ' GE407-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                    /*" -908- DISPLAY 'COD_IDLG        = ' GE407-COD-IDLG */
                    _.Display($"COD_IDLG        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG}");

                    /*" -909- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -910- WHEN OTHER */
                    break;
                default:

                    /*" -911- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -912- DISPLAY 'R0324-00-ERRO-SELECT JOIN GE_CONTROLE_CA_CIELO' */
                    _.Display($"R0324-00-ERRO-SELECT JOIN GE_CONTROLE_CA_CIELO");

                    /*" -913- DISPLAY 'NUM_CERTIFICADO = ' GE407-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                    /*" -914- DISPLAY 'NUM_PARCELA     = ' GE407-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                    /*" -915- DISPLAY 'COD_IDLG        = ' GE407-COD-IDLG */
                    _.Display($"COD_IDLG        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG}");

                    /*" -916- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -918- END-EVALUATE */
                    break;
            }


            /*" -918- . */

        }

        [StopWatch]
        /*" R0324-00-RECUPERA-NUM-CARTAO-DB-SELECT-1 */
        public void R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1()
        {
            /*" -897- EXEC SQL SELECT T2.NUM_CARTAO INTO :GE408-NUM-CARTAO FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1 JOIN SEGUROS.GE_RETORNO_CA_CIELO T2 ON T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO AND T1.NUM_PARCELA = T2.NUM_PARCELA AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO WHERE T1.NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO AND T1.NUM_PARCELA = :GE407-NUM-PARCELA AND T1.COD_IDLG = :GE407-COD-IDLG ORDER BY T2.SEQ_RET_CONTROL_HIST DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1 = new R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1()
            {
                GE407_NUM_CERTIFICADO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.ToString(),
                GE407_NUM_PARCELA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA.ToString(),
                GE407_COD_IDLG = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG.ToString(),
            };

            var executed_1 = R0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1.Execute(r0324_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE408_NUM_CARTAO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0324_99_SAIDA*/

        [StopWatch]
        /*" R0326-00-ATUALIZA-NUM-CARTAO-SECTION */
        private void R0326_00_ATUALIZA_NUM_CARTAO_SECTION()
        {
            /*" -926- MOVE '0326' TO WNR-EXEC-SQL */
            _.Move("0326", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -928- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -929- MOVE GE408-NUM-CARTAO TO WS-NUM-CARTAO-CRED-SAP */
            _.Move(GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CARTAO, AREA_DE_WORK.WS_NUM_CARTAO_CRED_SAP);

            /*" -932- MOVE WS-NUM-CART-CRED16 TO OPCPAGVI-NUM-CARTAO-CREDITO */
            _.Move(AREA_DE_WORK.WS_NUM_CARTAO_CRED_SAP.WS_NUM_CART_CRED16, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

            /*" -939- PERFORM R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1 */

            R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1();

            /*" -942- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -943- WHEN 0 */
                case 0:

                    /*" -944- CONTINUE */

                    /*" -945- WHEN OTHER */
                    break;
                default:

                    /*" -946- DISPLAY 'R0326-00-ATUALIZA-NUM-CARTAO' */
                    _.Display($"R0326-00-ATUALIZA-NUM-CARTAO");

                    /*" -947- DISPLAY 'NUM-CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"NUM-CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -948- DISPLAY 'DATA-VENCIMENTO = ' MCIELO-DATA-VENCIMENTO */
                    _.Display($"DATA-VENCIMENTO = {REG_CIELO.MCIELO_DATA_VENCIMENTO}");

                    /*" -949- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -949- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R0326-00-ATUALIZA-NUM-CARTAO-DB-UPDATE-1 */
        public void R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1()
        {
            /*" -939- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET NUM_CARTAO_CREDITO = :OPCPAGVI-NUM-CARTAO-CREDITO WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND OPCAO_PAGAMENTO = '5' AND DATA_INIVIGENCIA <= :MCIELO-DATA-VENCIMENTO AND DATA_TERVIGENCIA >= :MCIELO-DATA-VENCIMENTO END-EXEC. */

            var r0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1 = new R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1()
            {
                OPCPAGVI_NUM_CARTAO_CREDITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.ToString(),
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
                MCIELO_DATA_VENCIMENTO = REG_CIELO.MCIELO_DATA_VENCIMENTO.ToString(),
            };

            R0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1.Execute(r0326_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0326_99_SAIDA*/

        [StopWatch]
        /*" R0620-00-MOVE-DADOS-SECTION */
        private void R0620_00_MOVE_DADOS_SECTION()
        {
            /*" -958- MOVE '0620' TO WNR-EXEC-SQL */
            _.Move("0620", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -960- MOVE PRODUTO-COD-PRODUTO TO WS-TABG-CODPRODU(WS-PRD) */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_CODPRODU);

            /*" -961- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -962- PERFORM R0650-00-MOVE-TIPO 03 TIMES */

            for (int i = 0; i < 3; i++)
            {

                R0650_00_MOVE_TIPO_SECTION();

            }

            /*" -963- SET WS-PRD UP BY 1 */
            WS_PRD.Value += 1;

            /*" -965- SET WS-SUBS TO WS-PRD */
            AREA_DE_WORK.WS_SUBS.Value = WS_PRD;

            /*" -967- IF PRODUTO-COD-PRODUTO NOT = 9999 */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO != 9999)
            {

                /*" -968- PERFORM R0670-00-FETCH-C0-PRODUTO */

                R0670_00_FETCH_C0_PRODUTO_SECTION();

                /*" -968- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-MOVE-TIPO-SECTION */
        private void R0650_00_MOVE_TIPO_SECTION()
        {
            /*" -977- MOVE '0650' TO WNR-EXEC-SQL */
            _.Move("0650", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -979- SET WS-SUBS1 TO WS-TIP */
            AREA_DE_WORK.WS_SUBS1.Value = WS_TIP;

            /*" -980- EVALUATE WS-SUBS1 */
            switch (AREA_DE_WORK.WS_SUBS1.Value)
            {

                /*" -982- WHEN 1 */
                case 1:

                    /*" -984- MOVE 'A' TO WS-TABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("A", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_TIPO);

                    /*" -986- WHEN 2 */
                    break;
                case 2:

                    /*" -989- MOVE 'S' TO WS-TABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("S", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_TIPO);

                    /*" -991- WHEN OTHER */
                    break;
                default:

                    /*" -993- MOVE 'D' TO WS-TABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("D", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_TIPO);

                    /*" -995- END-EVALUATE */
                    break;
            }


            /*" -996- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -998- PERFORM R0660-00-MOVE-SITUACAO 02 TIMES */

            for (int i = 0; i < 2; i++)
            {

                R0660_00_MOVE_SITUACAO_SECTION();

            }

            /*" -998- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R0660-00-MOVE-SITUACAO-SECTION */
        private void R0660_00_MOVE_SITUACAO_SECTION()
        {
            /*" -1009- MOVE '0660' TO WNR-EXEC-SQL */
            _.Move("0660", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1017- MOVE ZEROS TO WS-TABG-QTDE (WS-PRD WS-TIP WS-SIT) WS-TABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WS-TABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WS-TABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WS-TABG-VLIOCC (WS-PRD WS-TIP WS-SIT) WS-TABG-VLDESCON(WS-PRD WS-TIP WS-SIT) */
            _.Move(0, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON);

            /*" -1019- SET WS-SUBS2 TO WS-SIT */
            AREA_DE_WORK.WS_SUBS2.Value = WS_SIT;

            /*" -1020- EVALUATE WS-SUBS2 */
            switch (AREA_DE_WORK.WS_SUBS2.Value)
            {

                /*" -1022- WHEN 1 */
                case 1:

                    /*" -1025- MOVE '0' TO WS-TABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                    _.Move("0", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_SITUACAO);

                    /*" -1027- WHEN OTHER */
                    break;
                default:

                    /*" -1029- MOVE '2' TO WS-TABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                    _.Move("2", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_SITUACAO);

                    /*" -1031- END-EVALUATE */
                    break;
            }


            /*" -1031- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0660_99_SAIDA*/

        [StopWatch]
        /*" R0670-00-FETCH-C0-PRODUTO-SECTION */
        private void R0670_00_FETCH_C0_PRODUTO_SECTION()
        {
            /*" -1040- MOVE '0670' TO WNR-EXEC-SQL */
            _.Move("0670", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1043- PERFORM R0670_00_FETCH_C0_PRODUTO_DB_FETCH_1 */

            R0670_00_FETCH_C0_PRODUTO_DB_FETCH_1();

            /*" -1046-  EVALUATE SQLCODE  */

            /*" -1047-  WHEN ZEROS  */

            /*" -1047- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1048- CONTINUE */

                /*" -1049-  WHEN +100  */

                /*" -1049- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1051- PERFORM R0670_00_FETCH_C0_PRODUTO_DB_CLOSE_1 */

                R0670_00_FETCH_C0_PRODUTO_DB_CLOSE_1();

                /*" -1055- MOVE 'S' TO WS-FIM-PROD */
                _.Move("S", AREA_DE_WORK.WS_FIM_PROD);

                /*" -1056- IF WS-LD-PRODUTOS EQUAL ZEROS */

                if (AREA_DE_WORK.WS_LD_PRODUTOS == 00)
                {

                    /*" -1057- DISPLAY '0670-TABELA DE PRODUTOS VAZIA, VERIFICAR' */
                    _.Display($"0670-TABELA DE PRODUTOS VAZIA, VERIFICAR");

                    /*" -1058- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1059- END-IF */
                }


                /*" -1060-  WHEN OTHER  */

                /*" -1060- ELSE */
            }
            else
            {


                /*" -1061- DISPLAY '0670-00 - PROBLEMAS FETCH (C0-PRODUTO)   ' */
                _.Display($"0670-00 - PROBLEMAS FETCH (C0-PRODUTO)   ");

                /*" -1062- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1064-  END-EVALUATE  */

                /*" -1064- END-IF */
            }


            /*" -1066- ADD 1 TO WS-LD-PRODUTOS */
            AREA_DE_WORK.WS_LD_PRODUTOS.Value = AREA_DE_WORK.WS_LD_PRODUTOS + 1;

            /*" -1067- IF WS-LD-PRODUTOS GREATER 8000 */

            if (AREA_DE_WORK.WS_LD_PRODUTOS > 8000)
            {

                /*" -1069- PERFORM R0670_00_FETCH_C0_PRODUTO_DB_CLOSE_2 */

                R0670_00_FETCH_C0_PRODUTO_DB_CLOSE_2();

                /*" -1071- DISPLAY '0670-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"0670-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -1072- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1072- END-IF. */
            }


        }

        [StopWatch]
        /*" R0670-00-FETCH-C0-PRODUTO-DB-FETCH-1 */
        public void R0670_00_FETCH_C0_PRODUTO_DB_FETCH_1()
        {
            /*" -1043- EXEC SQL FETCH C0-PRODUTOS INTO :PRODUTO-COD-PRODUTO END-EXEC */

            if (C0_PRODUTOS.Fetch())
            {
                _.Move(C0_PRODUTOS.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0670-00-FETCH-C0-PRODUTO-DB-CLOSE-1 */
        public void R0670_00_FETCH_C0_PRODUTO_DB_CLOSE_1()
        {
            /*" -1051- EXEC SQL CLOSE C0-PRODUTOS END-EXEC */

            C0_PRODUTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0670_99_SAIDA*/

        [StopWatch]
        /*" R0670-00-FETCH-C0-PRODUTO-DB-CLOSE-2 */
        public void R0670_00_FETCH_C0_PRODUTO_DB_CLOSE_2()
        {
            /*" -1069- EXEC SQL CLOSE C0-PRODUTOS END-EXEC */

            C0_PRODUTOS.Close();

        }

        [StopWatch]
        /*" R0350-00-PROCESSA-REGISTRO-SECTION */
        private void R0350_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1080- MOVE '0350' TO WNR-EXEC-SQL */
            _.Move("0350", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1083- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1089- MOVE ZEROS TO WS-VLPRMTOT WS-VLBALCAO WS-VLIOCC WS-VLDESCON WS-VLTARIFA */
            _.Move(0, AREA_DE_WORK.WS_VLPRMTOT, AREA_DE_WORK.WS_VLBALCAO, AREA_DE_WORK.WS_VLIOCC, AREA_DE_WORK.WS_VLDESCON, AREA_DE_WORK.WS_VLTARIFA);

            /*" -1090- MOVE MCIELO-VLR-COBRANCA TO WS-VLPRMTOT */
            _.Move(REG_CIELO.MCIELO_VLR_COBRANCA, AREA_DE_WORK.WS_VLPRMTOT);

            /*" -1093- MOVE PARCELAS-VAL-IOCC-IX TO WS-VLIOCC */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, AREA_DE_WORK.WS_VLIOCC);

            /*" -1094- COMPUTE WS-VLPRMLIQ = WS-VLPRMTOT - WS-VLIOCC */
            AREA_DE_WORK.WS_VLPRMLIQ.Value = AREA_DE_WORK.WS_VLPRMTOT - AREA_DE_WORK.WS_VLIOCC;

            /*" -1095- ADD WS-VLPRMLIQ TO AVISOCRE-PRM-LIQUIDO */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO + AREA_DE_WORK.WS_VLPRMLIQ;

            /*" -1097- ADD MCIELO-VLR-COBRANCA TO AVISOCRE-PRM-TOTAL WS-SDOATUAL */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL + REG_CIELO.MCIELO_VLR_COBRANCA;
            AREA_DE_WORK.WS_SDOATUAL.Value = AREA_DE_WORK.WS_SDOATUAL + REG_CIELO.MCIELO_VLR_COBRANCA;

            /*" -1098- ADD WS-VLIOCC TO AVISOCRE-VAL-IOCC */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC + AREA_DE_WORK.WS_VLIOCC;

            /*" -1100- ADD MCIELO-VLR-TAX-ADM TO WS-VLDESPES */
            AREA_DE_WORK.WS_VLDESPES.Value = AREA_DE_WORK.WS_VLDESPES + REG_CIELO.MCIELO_VLR_TAX_ADM;

            /*" -1102- PERFORM R0353-00-INSERT-MOV-COBR */

            R0353_00_INSERT_MOV_COBR_SECTION();

            /*" -1102- PERFORM R0355-00-TRATA-DESPESAS. */

            R0355_00_TRATA_DESPESAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0353-00-INSERT-MOV-COBR-SECTION */
        private void R0353_00_INSERT_MOV_COBR_SECTION()
        {
            /*" -1110- MOVE 0353 TO WNR-EXEC-SQL */
            _.Move(0353, ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1112- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1115- MOVE 'PAGAMENTO DE PARCELA DE ADESAO' TO WS-DES-TIPO-SIT */
            _.Move("PAGAMENTO DE PARCELA DE ADESAO", AREA_DE_WORK.WS_DES_TIPO_SIT);

            /*" -1116- MOVE AVISOCRE-COD-EMPRESA TO MOVIMCOB-COD-EMPRESA */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);

            /*" -1117- MOVE ZEROS TO MOVIMCOB-COD-MOVIMENTO */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -1118- MOVE 104 TO MOVIMCOB-COD-BANCO */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -1119- MOVE 7011 TO MOVIMCOB-COD-AGENCIA */
            _.Move(7011, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -1120- MOVE AVISOCRE-NUM-AVISO-CREDITO TO MOVIMCOB-NUM-AVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -1121- MOVE HEAD01-NSAS TO MOVIMCOB-NUM-FITA */
            _.Move(HEAD01_CIELO.HEAD01_NSAS, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);

            /*" -1122- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMCOB-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);

            /*" -1123- MOVE MCIELO-DATA-CREDITO TO MOVIMCOB-DATA-QUITACAO */
            _.Move(REG_CIELO.MCIELO_DATA_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);

            /*" -1124- MOVE COBHISVI-NUM-TITULO TO MOVIMCOB-NUM-TITULO */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -1125- MOVE HISCONPA-NUM-APOLICE TO MOVIMCOB-NUM-APOLICE */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -1126- MOVE HISCONPA-NUM-ENDOSSO TO MOVIMCOB-NUM-ENDOSSO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);

            /*" -1127- MOVE HISCONPA-NUM-PARCELA TO MOVIMCOB-NUM-PARCELA */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);

            /*" -1129- MOVE MCIELO-VLR-COBRANCA TO MOVIMCOB-VAL-TITULO */
            _.Move(REG_CIELO.MCIELO_VLR_COBRANCA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);

            /*" -1131- MOVE WS-VLIOCC TO MOVIMCOB-VAL-IOCC */
            _.Move(AREA_DE_WORK.WS_VLIOCC, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);

            /*" -1132- MOVE WS-VLPRMLIQ TO MOVIMCOB-VAL-CREDITO */
            _.Move(AREA_DE_WORK.WS_VLPRMLIQ, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -1133- MOVE HISCONPA-SIT-REGISTRO TO MOVIMCOB-SIT-REGISTRO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -1134- MOVE WS-DES-TIPO-SIT TO MOVIMCOB-NOME-SEGURADO */
            _.Move(AREA_DE_WORK.WS_DES_TIPO_SIT, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

            /*" -1135- MOVE '1' TO MOVIMCOB-TIPO-MOVIMENTO */
            _.Move("1", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

            /*" -1137- MOVE MCIELO-NUM-PROPOSTA TO MOVIMCOB-NUM-NOSSO-TITULO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -1183- PERFORM R0353_00_INSERT_MOV_COBR_DB_INSERT_1 */

            R0353_00_INSERT_MOV_COBR_DB_INSERT_1();

            /*" -1186- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1187- CONTINUE */

                /*" -1188- ELSE */
            }
            else
            {


                /*" -1189- DISPLAY '1000-PROBLEMAS NO INSERT MOVIMENTO_COBRANCA' */
                _.Display($"1000-PROBLEMAS NO INSERT MOVIMENTO_COBRANCA");

                /*" -1190- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1191- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1193- END-IF */
            }


            /*" -1193- ADD 1 TO WS-IN-MOVIMCOB. */
            AREA_DE_WORK.WS_IN_MOVIMCOB.Value = AREA_DE_WORK.WS_IN_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R0353-00-INSERT-MOV-COBR-DB-INSERT-1 */
        public void R0353_00_INSERT_MOV_COBR_DB_INSERT_1()
        {
            /*" -1183- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_COBRANCA ( COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_IOCC , VAL_CREDITO , SIT_REGISTRO , TIMESTAMP , NOME_SEGURADO , TIPO_MOVIMENTO , NUM_NOSSO_TITULO ) VALUES ( :MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-IOCC , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , CURRENT TIMESTAMP , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-TIPO-MOVIMENTO , :MOVIMCOB-NUM-NOSSO-TITULO ) END-EXEC */

            var r0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1 = new R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1()
            {
                MOVIMCOB_COD_EMPRESA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA.ToString(),
                MOVIMCOB_COD_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_NUM_FITA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA.ToString(),
                MOVIMCOB_DATA_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.ToString(),
                MOVIMCOB_DATA_QUITACAO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_VAL_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO.ToString(),
                MOVIMCOB_VAL_IOCC = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC.ToString(),
                MOVIMCOB_VAL_CREDITO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO.ToString(),
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
                MOVIMCOB_NOME_SEGURADO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO.ToString(),
                MOVIMCOB_TIPO_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO.ToString(),
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1.Execute(r0353_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0353_99_SAIDA*/

        [StopWatch]
        /*" R0355-00-TRATA-DESPESAS-SECTION */
        private void R0355_00_TRATA_DESPESAS_SECTION()
        {
            /*" -1201- MOVE '0355' TO WNR-EXEC-SQL */
            _.Move("0355", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1203- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1205- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -1206- SEARCH WS-TABG-OCORREPRD */
            for (; WS_PRD < AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -1207- WHEN PROPOVA-COD-PRODUTO EQUAL WS-TABG-CODPRODU(WS-PRD) */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_CODPRODU)
                {


                    /*" -1208- PERFORM R0357-00-VERIFICA-TIPO */

                    R0357_00_VERIFICA_TIPO_SECTION();

                    /*" -1208- END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0355_99_SAIDA*/

        [StopWatch]
        /*" R0357-00-VERIFICA-TIPO-SECTION */
        private void R0357_00_VERIFICA_TIPO_SECTION()
        {
            /*" -1216- MOVE '0357' TO WNR-EXEC-SQL */
            _.Move("0357", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1222- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1223- SET WS-TIP TO 3 */
            WS_TIP.Value = 3;

            /*" -1226- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -1227- ADD 1 TO WS-TABG-QTDE(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE + 1;

            /*" -1228- ADD WS-VLPRMTOT TO WS-TABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT + AREA_DE_WORK.WS_VLPRMTOT;

            /*" -1229- ADD WS-VLTARIFA TO WS-TABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA + AREA_DE_WORK.WS_VLTARIFA;

            /*" -1230- ADD WS-VLBALCAO TO WS-TABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO + AREA_DE_WORK.WS_VLBALCAO;

            /*" -1231- ADD WS-VLIOCC TO WS-TABG-VLIOCC (WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC + AREA_DE_WORK.WS_VLIOCC;

            /*" -1233- ADD WS-VLDESCON TO WS-TABG-VLDESCON(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON + AREA_DE_WORK.WS_VLDESCON;

            /*" -1233- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0357_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-FINAL-SECTION */
        private void R3000_00_PROCESSA_FINAL_SECTION()
        {
            /*" -1241- MOVE '3000' TO WNR-EXEC-SQL */
            _.Move("3000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1243- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1245- PERFORM R3100-00-INSERT-AVISO-CREDITO */

            R3100_00_INSERT_AVISO_CREDITO_SECTION();

            /*" -1247- PERFORM R3200-00-INSERT-AVISOS-SALDOS */

            R3200_00_INSERT_AVISOS_SALDOS_SECTION();

            /*" -1248- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -1248- PERFORM R3600-00-GRAVA-DESPESAS 9999 TIMES. */

            for (int i = 0; i < 9999; i++)
            {

                R3600_00_GRAVA_DESPESAS_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-AVISO-CREDITO-SECTION */
        private void R3100_00_INSERT_AVISO_CREDITO_SECTION()
        {
            /*" -1256- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1258- DISPLAY WNR-EXEC-SQL. */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1259- MOVE 2 TO AVISOCRE-ORIGEM-AVISO */
            _.Move(2, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);

            /*" -1260- MOVE 104 TO AVISOCRE-BCO-AVISO */
            _.Move(104, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);

            /*" -1261- MOVE 7011 TO AVISOCRE-AGE-AVISO */
            _.Move(7011, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);

            /*" -1262- MOVE 1 TO AVISOCRE-NUM-SEQUENCIA */
            _.Move(1, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA);

            /*" -1264- MOVE SISTEMAS-DATA-MOV-ABERTO TO AVISOCRE-DATA-MOVIMENTO AVISOCRE-DATA-AVISO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);

            /*" -1265- MOVE 100 TO AVISOCRE-COD-OPERACAO */
            _.Move(100, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO);

            /*" -1266- MOVE '0' TO AVISOCRE-SIT-CONTABIL */
            _.Move("0", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_SIT_CONTABIL);

            /*" -1267- MOVE 'D' TO AVISOCRE-TIPO-AVISO */
            _.Move("D", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO);

            /*" -1274- MOVE ZEROS TO AVISOCRE-PRM-COSSEGURO-CED AVISOCRE-COD-EMPRESA AVISOCRE-VAL-ADIANTAMENTO VIND-CODEMP VIND-ORIGEM VIND-VALADT. */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_COSSEGURO_CED, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_ADIANTAMENTO, AREA_DE_WORK.VIND_CODEMP, AREA_DE_WORK.VIND_ORIGEM, AREA_DE_WORK.VIND_VALADT);

            /*" -1276- MOVE 'P' TO AVISOCRE-STA-DEPOSITO-TER. */
            _.Move("P", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_STA_DEPOSITO_TER);

            /*" -1320- PERFORM R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1 */

            R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1();

            /*" -1323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1324- DISPLAY '3100-00 - PROBLEMAS NO INSERT(AVISOCRE) ' */
                _.Display($"3100-00 - PROBLEMAS NO INSERT(AVISOCRE) ");

                /*" -1325- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1327- END-IF. */
            }


            /*" -1327- ADD 1 TO WS-IN-AVISOCRE. */
            AREA_DE_WORK.WS_IN_AVISOCRE.Value = AREA_DE_WORK.WS_IN_AVISOCRE + 1;

        }

        [StopWatch]
        /*" R3100-00-INSERT-AVISO-CREDITO-DB-INSERT-1 */
        public void R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1()
        {
            /*" -1320- EXEC SQL INSERT INTO SEGUROS.AVISO_CREDITO ( BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_SEQUENCIA , DATA_MOVIMENTO , COD_OPERACAO , TIPO_AVISO , DATA_AVISO , VAL_IOCC , VAL_DESPESA , PRM_COSSEGURO_CED , PRM_LIQUIDO , PRM_TOTAL , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP , ORIGEM_AVISO , VAL_ADIANTAMENTO , STA_DEPOSITO_TER ) VALUES ( :AVISOCRE-BCO-AVISO , :AVISOCRE-AGE-AVISO , :AVISOCRE-NUM-AVISO-CREDITO , :AVISOCRE-NUM-SEQUENCIA , :AVISOCRE-DATA-MOVIMENTO , :AVISOCRE-COD-OPERACAO , :AVISOCRE-TIPO-AVISO , :AVISOCRE-DATA-AVISO , :AVISOCRE-VAL-IOCC , :AVISOCRE-VAL-DESPESA , :AVISOCRE-PRM-COSSEGURO-CED , :AVISOCRE-PRM-LIQUIDO , :AVISOCRE-PRM-TOTAL , :AVISOCRE-SIT-CONTABIL , :AVISOCRE-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP , :AVISOCRE-ORIGEM-AVISO:VIND-ORIGEM , :AVISOCRE-VAL-ADIANTAMENTO:VIND-VALADT , :AVISOCRE-STA-DEPOSITO-TER ) END-EXEC. */

            var r3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1 = new R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1()
            {
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_NUM_SEQUENCIA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA.ToString(),
                AVISOCRE_DATA_MOVIMENTO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.ToString(),
                AVISOCRE_COD_OPERACAO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO.ToString(),
                AVISOCRE_TIPO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO.ToString(),
                AVISOCRE_DATA_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO.ToString(),
                AVISOCRE_VAL_IOCC = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC.ToString(),
                AVISOCRE_VAL_DESPESA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA.ToString(),
                AVISOCRE_PRM_COSSEGURO_CED = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_COSSEGURO_CED.ToString(),
                AVISOCRE_PRM_LIQUIDO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.ToString(),
                AVISOCRE_PRM_TOTAL = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.ToString(),
                AVISOCRE_SIT_CONTABIL = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_SIT_CONTABIL.ToString(),
                AVISOCRE_COD_EMPRESA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA.ToString(),
                VIND_CODEMP = AREA_DE_WORK.VIND_CODEMP.ToString(),
                AVISOCRE_ORIGEM_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO.ToString(),
                VIND_ORIGEM = AREA_DE_WORK.VIND_ORIGEM.ToString(),
                AVISOCRE_VAL_ADIANTAMENTO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_ADIANTAMENTO.ToString(),
                VIND_VALADT = AREA_DE_WORK.VIND_VALADT.ToString(),
                AVISOCRE_STA_DEPOSITO_TER = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_STA_DEPOSITO_TER.ToString(),
            };

            R3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-INSERT-AVISOS-SALDOS-SECTION */
        private void R3200_00_INSERT_AVISOS_SALDOS_SECTION()
        {
            /*" -1336- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1338- DISPLAY WNR-EXEC-SQL. */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1339- MOVE AVISOCRE-COD-EMPRESA TO AVISOSAL-COD-EMPRESA */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_COD_EMPRESA);

            /*" -1340- MOVE AVISOCRE-BCO-AVISO TO AVISOSAL-BCO-AVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO);

            /*" -1341- MOVE AVISOCRE-AGE-AVISO TO AVISOSAL-AGE-AVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO);

            /*" -1342- MOVE '1' TO AVISOSAL-TIPO-SEGURO */
            _.Move("1", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO);

            /*" -1343- MOVE AVISOCRE-NUM-AVISO-CREDITO TO AVISOSAL-NUM-AVISO-CREDITO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO);

            /*" -1344- MOVE AVISOCRE-DATA-AVISO TO AVISOSAL-DATA-AVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO);

            /*" -1345- MOVE AVISOCRE-DATA-MOVIMENTO TO AVISOSAL-DATA-MOVIMENTO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO);

            /*" -1346- MOVE ZEROS TO AVISOSAL-SALDO-ATUAL */
            _.Move(0, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);

            /*" -1348- MOVE '0' TO AVISOSAL-SIT-REGISTRO. */
            _.Move("0", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO);

            /*" -1374- PERFORM R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1 */

            R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1();

            /*" -1377- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1378- DISPLAY 'R3200-00 - PROBLEMAS NO INSERT(AVISOSAL)   ' */
                _.Display($"R3200-00 - PROBLEMAS NO INSERT(AVISOSAL)   ");

                /*" -1379- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1381- END-IF. */
            }


            /*" -1381- ADD 1 TO WS-IN-AVISOSAL. */
            AREA_DE_WORK.WS_IN_AVISOSAL.Value = AREA_DE_WORK.WS_IN_AVISOSAL + 1;

        }

        [StopWatch]
        /*" R3200-00-INSERT-AVISOS-SALDOS-DB-INSERT-1 */
        public void R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1()
        {
            /*" -1374- EXEC SQL INSERT INTO SEGUROS.AVISOS_SALDOS ( COD_EMPRESA , BCO_AVISO , AGE_AVISO , TIPO_SEGURO , NUM_AVISO_CREDITO , DATA_AVISO , DATA_MOVIMENTO , SALDO_ATUAL , SIT_REGISTRO , TIMESTAMP ) VALUES ( :AVISOSAL-COD-EMPRESA , :AVISOSAL-BCO-AVISO , :AVISOSAL-AGE-AVISO , :AVISOSAL-TIPO-SEGURO , :AVISOSAL-NUM-AVISO-CREDITO , :AVISOSAL-DATA-AVISO , :AVISOSAL-DATA-MOVIMENTO , :AVISOSAL-SALDO-ATUAL , :AVISOSAL-SIT-REGISTRO , CURRENT TIMESTAMP ) END-EXEC. */

            var r3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1 = new R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1()
            {
                AVISOSAL_COD_EMPRESA = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_COD_EMPRESA.ToString(),
                AVISOSAL_BCO_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
                AVISOSAL_TIPO_SEGURO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO.ToString(),
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_DATA_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO.ToString(),
                AVISOSAL_DATA_MOVIMENTO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.ToString(),
                AVISOSAL_SALDO_ATUAL = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.ToString(),
                AVISOSAL_SIT_REGISTRO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO.ToString(),
            };

            R3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1.Execute(r3200_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-UPD-COBER-HIST-VIDAZUL-SECTION */
        private void R3210_UPD_COBER_HIST_VIDAZUL_SECTION()
        {
            /*" -1389- MOVE '3210' TO WNR-EXEC-SQL */
            _.Move("3210", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1391- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1399- PERFORM R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1 */

            R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1();

            /*" -1402- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1403- DISPLAY '3210 - PROBLEMAS  UPDATE COBER_HIST_VIDAZUL' */
                _.Display($"3210 - PROBLEMAS  UPDATE COBER_HIST_VIDAZUL");

                /*" -1404- DISPLAY 'NUM-CERTIFICADO => ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1405- DISPLAY 'NUM-PARCELA     => ' HISCONPA-NUM-PARCELA */
                _.Display($"NUM-PARCELA     => {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -1406- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1408- END-IF */
            }


            /*" -1408- ADD 1 TO WS-UP-COBER-HIS-VA. */
            AREA_DE_WORK.WS_UP_COBER_HIS_VA.Value = AREA_DE_WORK.WS_UP_COBER_HIS_VA + 1;

        }

        [StopWatch]
        /*" R3210-UPD-COBER-HIST-VIDAZUL-DB-UPDATE-1 */
        public void R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1()
        {
            /*" -1399- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET NUM_AVISO_CREDITO = :MOVIMCOB-NUM-AVISO , BCO_AVISO = :MOVIMCOB-COD-BANCO , AGE_AVISO = :MOVIMCOB-COD-AGENCIA WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND SIT_REGISTRO = '1' END-EXEC */

            var r3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1 = new R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            R3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1.Execute(r3210_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3212-UPDATE-PARCELAS-VIDAZUL-SECTION */
        private void R3212_UPDATE_PARCELAS_VIDAZUL_SECTION()
        {
            /*" -1416- MOVE '3212' TO WNR-EXEC-SQL */
            _.Move("3212", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1418- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1419- MOVE HISCONPA-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

            /*" -1421- MOVE HISCONPA-NUM-PARCELA TO PARCEVID-NUM-PARCELA */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

            /*" -1427- PERFORM R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1 */

            R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1();

            /*" -1430- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1431- DISPLAY '3212 - PROBLEMAS  UPDATE PARCELAS_VIDAZUL' */
                _.Display($"3212 - PROBLEMAS  UPDATE PARCELAS_VIDAZUL");

                /*" -1432- DISPLAY 'NUM-CERTIFICADO => ' PARCEVID-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO}");

                /*" -1433- DISPLAY 'NUM-PARCELA     => ' PARCEVID-NUM-PARCELA */
                _.Display($"NUM-PARCELA     => {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}");

                /*" -1434- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1436- END-IF */
            }


            /*" -1436- ADD 1 TO WS-UP-PARC-VIDAZUL. */
            AREA_DE_WORK.WS_UP_PARC_VIDAZUL.Value = AREA_DE_WORK.WS_UP_PARC_VIDAZUL + 1;

        }

        [StopWatch]
        /*" R3212-UPDATE-PARCELAS-VIDAZUL-DB-UPDATE-1 */
        public void R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1()
        {
            /*" -1427- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :PARCEVID-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA END-EXEC */

            var r3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1 = new R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1()
            {
                PARCEVID_NUM_CERTIFICADO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
            };

            R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1.Execute(r3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3212_99_SAIDA*/

        [StopWatch]
        /*" R3213-UPD-COBER-HIST-VIDAZUL-SECTION */
        private void R3213_UPD_COBER_HIST_VIDAZUL_SECTION()
        {
            /*" -1444- MOVE '3213' TO WNR-EXEC-SQL */
            _.Move("3213", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1446- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1452- PERFORM R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1 */

            R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1();

            /*" -1455- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1456- DISPLAY '3213 - PROBLEMAS  UPDATE COBER_HIST_VIDAZUL' */
                _.Display($"3213 - PROBLEMAS  UPDATE COBER_HIST_VIDAZUL");

                /*" -1457- DISPLAY 'NUM-CERTIFICADO => ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1458- DISPLAY 'NUM-PARCELA     => ' HISCONPA-NUM-PARCELA */
                _.Display($"NUM-PARCELA     => {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -1459- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1461- END-IF */
            }


            /*" -1461- ADD 1 TO WS-UP-COBER-HIS-VA. */
            AREA_DE_WORK.WS_UP_COBER_HIS_VA.Value = AREA_DE_WORK.WS_UP_COBER_HIS_VA + 1;

        }

        [StopWatch]
        /*" R3213-UPD-COBER-HIST-VIDAZUL-DB-UPDATE-1 */
        public void R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1()
        {
            /*" -1452- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND SIT_REGISTRO = '0' END-EXEC */

            var r3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1 = new R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            R3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1.Execute(r3213_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3213_99_SAIDA*/

        [StopWatch]
        /*" R3214-UPDATE-HIST-LANC-CTA-SECTION */
        private void R3214_UPDATE_HIST_LANC_CTA_SECTION()
        {
            /*" -1469- MOVE '3214' TO WNR-EXEC-SQL */
            _.Move("3214", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1471- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1472- MOVE HISCONPA-NUM-CERTIFICADO TO HISLANCT-NUM-CERTIFICADO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -1473- MOVE HISCONPA-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -1474- MOVE WS-NSAC TO HISLANCT-NSAC */
            _.Move(AREA_DE_WORK.WS_NSAC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC);

            /*" -1475- MOVE ZEROS TO HISLANCT-CODRET */
            _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

            /*" -1477- MOVE '1' TO HISLANCT-SIT-REGISTRO */
            _.Move("1", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -1489- PERFORM R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1 */

            R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1();

            /*" -1492- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1493- DISPLAY '3214 - PROBLEMAS  UPDATE HIST_LANC_CTA ' */
                _.Display($"3214 - PROBLEMAS  UPDATE HIST_LANC_CTA ");

                /*" -1494- DISPLAY 'NUM-CERTIFICADO => ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -1495- DISPLAY 'NUM-PARCELA     => ' HISLANCT-NUM-PARCELA */
                _.Display($"NUM-PARCELA     => {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                /*" -1496- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1498- END-IF */
            }


            /*" -1498- ADD 1 TO WS-UP-HIS-LANC-CTA. */
            AREA_DE_WORK.WS_UP_HIS_LANC_CTA.Value = AREA_DE_WORK.WS_UP_HIS_LANC_CTA + 1;

        }

        [StopWatch]
        /*" R3214-UPDATE-HIST-LANC-CTA-DB-UPDATE-1 */
        public void R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1()
        {
            /*" -1489- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = :HISLANCT-SIT-REGISTRO , NSAC = :HISLANCT-NSAC , OCORR_HISTORICO = OCORR_HISTORICO + 1 , CODRET = :HISLANCT-CODRET , TIMESTAMP = CURRENT TIMESTAMP , COD_USUARIO = 'CB0123B' WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND NUM_PARCELA = :HISLANCT-NUM-PARCELA AND OCORR_HISTORICOCTA = :HISLANCT-OCORR-HISTORICOCTA AND SIT_REGISTRO = '3' END-EXEC */

            var r3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 = new R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1()
            {
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_CODRET = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET.ToString(),
                HISLANCT_NSAC = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC.ToString(),
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            R3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1.Execute(r3214_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3214_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-GRAVA-DESPESAS-SECTION */
        private void R3600_00_GRAVA_DESPESAS_SECTION()
        {
            /*" -1507- MOVE '3600' TO WNR-EXEC-SQL */
            _.Move("3600", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1508- IF WS-TABG-CODPRODU(WS-PRD) EQUAL 9999 */

            if (AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_CODPRODU == 9999)
            {

                /*" -1509- SET WS-PRD UP BY 1 */
                WS_PRD.Value += 1;

                /*" -1510- ELSE */
            }
            else
            {


                /*" -1511- MOVE AVISOCRE-COD-EMPRESA TO CONDESCE-COD-EMPRESA */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA);

                /*" -1512- MOVE AVISOCRE-DATA-AVISO TO WS-DATA-REL */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, AREA_DE_WORK.WS_DATA_REL);

                /*" -1513- MOVE WS-DAT-REL-ANO TO CONDESCE-ANO-REFERENCIA */
                _.Move(AREA_DE_WORK.FILLER_9.WS_DAT_REL_ANO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA);

                /*" -1514- MOVE WS-DAT-REL-MES TO CONDESCE-MES-REFERENCIA */
                _.Move(AREA_DE_WORK.FILLER_9.WS_DAT_REL_MES, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA);

                /*" -1515- MOVE AVISOCRE-BCO-AVISO TO CONDESCE-BCO-AVISO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO);

                /*" -1516- MOVE AVISOCRE-AGE-AVISO TO CONDESCE-AGE-AVISO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO);

                /*" -1518- MOVE AVISOCRE-NUM-AVISO-CREDITO TO CONDESCE-NUM-AVISO-CREDITO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO);

                /*" -1520- MOVE WS-TABG-CODPRODU(WS-PRD) TO CONDESCE-COD-PRODUTO */
                _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_CODPRODU, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO);

                /*" -1521- MOVE '2' TO CONDESCE-TIPO-COBRANCA */
                _.Move("2", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_COBRANCA);

                /*" -1523- MOVE AVISOCRE-DATA-MOVIMENTO TO CONDESCE-DATA-MOVIMENTO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO);

                /*" -1524- MOVE AVISOCRE-DATA-AVISO TO CONDESCE-DATA-AVISO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO);

                /*" -1527- MOVE ZEROS TO CONDESCE-VAL-JUROS CONDESCE-VAL-MULTA */
                _.Move(0, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA);

                /*" -1528- SET WS-TIP TO 1 */
                WS_TIP.Value = 1;

                /*" -1529- PERFORM R3650-00-GRAVA-TIPO 03 TIMES */

                for (int i = 0; i < 3; i++)
                {

                    R3650_00_GRAVA_TIPO_SECTION();

                }

                /*" -1530- SET WS-PRD UP BY 1 */
                WS_PRD.Value += 1;

                /*" -1530- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3650-00-GRAVA-TIPO-SECTION */
        private void R3650_00_GRAVA_TIPO_SECTION()
        {
            /*" -1540- MOVE '3650' TO WNR-EXEC-SQL */
            _.Move("3650", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1543- MOVE WS-TABG-TIPO(WS-PRD WS-TIP) TO CONDESCE-TIPO-REGISTRO */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_TIPO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_REGISTRO);

            /*" -1544- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -1545- PERFORM R3700-00-GRAVA-REGISTRO 02 TIMES */

            for (int i = 0; i < 2; i++)
            {

                R3700_00_GRAVA_REGISTRO_SECTION();

            }

            /*" -1545- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3650_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-GRAVA-REGISTRO-SECTION */
        private void R3700_00_GRAVA_REGISTRO_SECTION()
        {
            /*" -1554- MOVE '3700' TO WNR-EXEC-SQL */
            _.Move("3700", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1556- MOVE WS-TABG-SITUACAO(WS-PRD WS-TIP WS-SIT) TO CONDESCE-SITUACAO */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_SITUACAO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_SITUACAO);

            /*" -1558- MOVE WS-TABG-QTDE (WS-PRD WS-TIP WS-SIT) TO CONDESCE-QTD-REGISTROS */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS);

            /*" -1560- MOVE WS-TABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) TO CONDESCE-PRM-TOTAL */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL);

            /*" -1562- MOVE WS-TABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) TO CONDESCE-VAL-TARIFA */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA);

            /*" -1564- MOVE WS-TABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) TO CONDESCE-VAL-BALCAO */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO);

            /*" -1566- MOVE WS-TABG-VLIOCC (WS-PRD WS-TIP WS-SIT) TO CONDESCE-VAL-IOCC */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC);

            /*" -1569- MOVE WS-TABG-VLDESCON(WS-PRD WS-TIP WS-SIT) TO CONDESCE-VAL-DESCONTO */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO);

            /*" -1579- COMPUTE CONDESCE-PRM-LIQUIDO EQUAL (CONDESCE-PRM-TOTAL - CONDESCE-VAL-TARIFA - CONDESCE-VAL-BALCAO - CONDESCE-VAL-IOCC - CONDESCE-VAL-DESCONTO - CONDESCE-VAL-JUROS - CONDESCE-VAL-MULTA) */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO.Value = (CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA);

            /*" -1584- IF (CONDESCE-QTD-REGISTROS EQUAL ZEROS AND CONDESCE-PRM-TOTAL EQUAL ZEROS AND CONDESCE-PRM-LIQUIDO EQUAL ZEROS AND CONDESCE-VAL-TARIFA EQUAL ZEROS AND CONDESCE-VAL-BALCAO EQUAL ZEROS ) */

            if ((CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS == 00 && CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL == 00 && CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO == 00 && CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA == 00 && CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO == 00))
            {

                /*" -1585- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -1586- ELSE */
            }
            else
            {


                /*" -1588- PERFORM R3800-00-INSERT-DESPESAS */

                R3800_00_INSERT_DESPESAS_SECTION();

                /*" -1595- MOVE ZEROS TO WS-TABG-QTDE (WS-PRD WS-TIP WS-SIT) WS-TABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WS-TABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WS-TABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WS-TABG-VLIOCC (WS-PRD WS-TIP WS-SIT) WS-TABG-VLDESCON(WS-PRD WS-TIP WS-SIT) */
                _.Move(0, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON);

                /*" -1596- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -1596- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R3800-00-INSERT-DESPESAS-SECTION */
        private void R3800_00_INSERT_DESPESAS_SECTION()
        {
            /*" -1605- MOVE '3800' TO WNR-EXEC-SQL */
            _.Move("3800", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1655- PERFORM R3800_00_INSERT_DESPESAS_DB_INSERT_1 */

            R3800_00_INSERT_DESPESAS_DB_INSERT_1();

            /*" -1658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1659- DISPLAY '3800-00 - PROBLEMAS INSERT (DESPESAS)   ' */
                _.Display($"3800-00 - PROBLEMAS INSERT (DESPESAS)   ");

                /*" -1660- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1662- END-IF */
            }


            /*" -1662- ADD 1 TO WS-IN-CONDESCE. */
            AREA_DE_WORK.WS_IN_CONDESCE.Value = AREA_DE_WORK.WS_IN_CONDESCE + 1;

        }

        [StopWatch]
        /*" R3800-00-INSERT-DESPESAS-DB-INSERT-1 */
        public void R3800_00_INSERT_DESPESAS_DB_INSERT_1()
        {
            /*" -1655- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF ( COD_EMPRESA , ANO_REFERENCIA , MES_REFERENCIA , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_PRODUTO , TIPO_REGISTRO , SITUACAO , TIPO_COBRANCA , DATA_MOVIMENTO , DATA_AVISO , QTD_REGISTROS , PRM_TOTAL , PRM_LIQUIDO , VAL_TARIFA , VAL_BALCAO , VAL_IOCC , VAL_DESCONTO , VAL_JUROS , VAL_MULTA , TIMESTAMP ) VALUES ( :CONDESCE-COD-EMPRESA , :CONDESCE-ANO-REFERENCIA , :CONDESCE-MES-REFERENCIA , :CONDESCE-BCO-AVISO , :CONDESCE-AGE-AVISO , :CONDESCE-NUM-AVISO-CREDITO , :CONDESCE-COD-PRODUTO , :CONDESCE-TIPO-REGISTRO , :CONDESCE-SITUACAO , :CONDESCE-TIPO-COBRANCA , :CONDESCE-DATA-MOVIMENTO , :CONDESCE-DATA-AVISO , :CONDESCE-QTD-REGISTROS , :CONDESCE-PRM-TOTAL , :CONDESCE-PRM-LIQUIDO , :CONDESCE-VAL-TARIFA , :CONDESCE-VAL-BALCAO , :CONDESCE-VAL-IOCC , :CONDESCE-VAL-DESCONTO , :CONDESCE-VAL-JUROS , :CONDESCE-VAL-MULTA , CURRENT TIMESTAMP ) END-EXEC */

            var r3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 = new R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1()
            {
                CONDESCE_COD_EMPRESA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA.ToString(),
                CONDESCE_ANO_REFERENCIA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA.ToString(),
                CONDESCE_MES_REFERENCIA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA.ToString(),
                CONDESCE_BCO_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO.ToString(),
                CONDESCE_AGE_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO.ToString(),
                CONDESCE_NUM_AVISO_CREDITO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO.ToString(),
                CONDESCE_COD_PRODUTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO.ToString(),
                CONDESCE_TIPO_REGISTRO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_REGISTRO.ToString(),
                CONDESCE_SITUACAO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_SITUACAO.ToString(),
                CONDESCE_TIPO_COBRANCA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_COBRANCA.ToString(),
                CONDESCE_DATA_MOVIMENTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO.ToString(),
                CONDESCE_DATA_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO.ToString(),
                CONDESCE_QTD_REGISTROS = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS.ToString(),
                CONDESCE_PRM_TOTAL = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL.ToString(),
                CONDESCE_PRM_LIQUIDO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO.ToString(),
                CONDESCE_VAL_TARIFA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA.ToString(),
                CONDESCE_VAL_BALCAO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO.ToString(),
                CONDESCE_VAL_IOCC = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC.ToString(),
                CONDESCE_VAL_DESCONTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO.ToString(),
                CONDESCE_VAL_JUROS = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS.ToString(),
                CONDESCE_VAL_MULTA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA.ToString(),
            };

            R3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1.Execute(r3800_00_INSERT_DESPESAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-COBRANCA-SECTION */
        private void R0700_00_PROCESSA_COBRANCA_SECTION()
        {
            /*" -1671- MOVE '0570' TO WNR-EXEC-SQL */
            _.Move("0570", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1675- IF HISLANCT-NUM-PARCELA EQUAL 1 AND PROPOVA-SIT-REGISTRO EQUAL '2' */

            if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA == 1 && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
            {

                /*" -1676- CONTINUE */

                /*" -1677- ELSE */
            }
            else
            {


                /*" -1678- PERFORM R0712-00-MONTA-COBRANCA */

                R0712_00_MONTA_COBRANCA_SECTION();

                /*" -1679- PERFORM R0718-00-INSERT-PARCELA-HIS */

                R0718_00_INSERT_PARCELA_HIS_SECTION();

                /*" -1680- PERFORM R0725-00-ATUALIZA-PARCELAS */

                R0725_00_ATUALIZA_PARCELAS_SECTION();

                /*" -1681- PERFORM R0730-00-ATUALIZA-ENDOSSOS */

                R0730_00_ATUALIZA_ENDOSSOS_SECTION();

                /*" -1683- END-IF */
            }


            /*" -1683- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0712-00-MONTA-COBRANCA-SECTION */
        private void R0712_00_MONTA_COBRANCA_SECTION()
        {
            /*" -1691- MOVE '0712' TO WNR-EXEC-SQL */
            _.Move("0712", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1694- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1695- IF HISCONPA-NUM-ENDOSSO EQUAL ZEROS */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO == 00)
            {

                /*" -1696- DISPLAY 'MOVIMENTO FINANCEIRO SEM ENDOSSO EMITIDO.' */
                _.Display($"MOVIMENTO FINANCEIRO SEM ENDOSSO EMITIDO.");

                /*" -1697- DISPLAY 'VERIFICAR O FATURAMENTO DO CERTIFICAO.' */
                _.Display($"VERIFICAR O FATURAMENTO DO CERTIFICAO.");

                /*" -1698- DISPLAY 'CERTIFICADO ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1699- DISPLAY 'PARCELA     ' HISCONPA-NUM-PARCELA */
                _.Display($"PARCELA     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -1700- DISPLAY 'APOLICE     ' HISCONPA-NUM-APOLICE */
                _.Display($"APOLICE     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                /*" -1701- DISPLAY 'ENDOSSO     ' HISCONPA-NUM-ENDOSSO */
                _.Display($"ENDOSSO     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                /*" -1702- MOVE +9999 TO SQLCODE */
                _.Move(+9999, DB.SQLCODE);

                /*" -1703- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1705- END-IF */
            }


            /*" -1706- MOVE HISCONPA-NUM-APOLICE TO PARCEHIS-NUM-APOLICE */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -1708- MOVE HISCONPA-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -1709- MOVE PARCELAS-DAC-PARCELA TO PARCEHIS-DAC-PARCELA */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -1710- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -1712- MOVE 221 TO PARCEHIS-COD-OPERACAO */
            _.Move(221, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -1713- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -1714- MOVE WS-HH-TIME TO WS-HORA-HH-EDIT */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WS_HORA_EDIT.WS_HORA_HH_EDIT);

            /*" -1715- MOVE WS-MM-TIME TO WS-HORA-MM-EDIT */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WS_HORA_EDIT.WS_HORA_MM_EDIT);

            /*" -1716- MOVE WS-SS-TIME TO WS-HORA-SS-EDIT */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WS_HORA_EDIT.WS_HORA_SS_EDIT);

            /*" -1718- MOVE WS-HORA-EDIT TO PARCEHIS-HORA-OPERACAO */
            _.Move(AREA_DE_WORK.WS_HORA_EDIT, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO);

            /*" -1719- PERFORM R0715-00-RECUP-DADOS-HISTORICO */

            R0715_00_RECUP_DADOS_HISTORICO_SECTION();

            /*" -1720- ADD 1 TO PARCEHIS-OCORR-HISTORICO */
            PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO + 1;

            /*" -1721- MOVE MOVIMCOB-COD-BANCO TO PARCEHIS-BCO-COBRANCA */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -1722- MOVE MOVIMCOB-COD-AGENCIA TO PARCEHIS-AGE-COBRANCA */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -1723- MOVE MOVIMCOB-NUM-AVISO TO PARCEHIS-NUM-AVISO-CREDITO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -1724- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -1726- MOVE '0' TO PARCEHIS-SIT-CONTABIL */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -1727- MOVE 'CB0123B' TO PARCEHIS-COD-USUARIO */
            _.Move("CB0123B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -1728- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -1729- MOVE MOVIMCOB-DATA-QUITACAO TO PARCEHIS-DATA-QUITACAO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -1737- MOVE ZEROS TO PARCEHIS-COD-EMPRESA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -1738- IF PARCEHIS-PRM-TOTAL NOT EQUAL MCIELO-VLR-COBRANCA */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL != REG_CIELO.MCIELO_VLR_COBRANCA)
            {

                /*" -1739- DISPLAY 'ERRO - VALORES DIFERENTES' */
                _.Display($"ERRO - VALORES DIFERENTES");

                /*" -1740- DISPLAY 'CERTIFICADO ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1741- DISPLAY 'APOLICE     ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE     {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1743- DISPLAY 'ENDOSSO     ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO     {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1745- DISPLAY 'PREMIO TOTAL COBRADO NO CARTAO = ' PARCEHIS-PRM-TOTAL */
                _.Display($"PREMIO TOTAL COBRADO NO CARTAO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL}");

                /*" -1747- DISPLAY 'PREMIO TOTAL RETORNADO DO SAP  = ' MCIELO-VLR-COBRANCA */
                _.Display($"PREMIO TOTAL RETORNADO DO SAP  = {REG_CIELO.MCIELO_VLR_COBRANCA}");

                /*" -1749- END-IF */
            }


            /*" -1750- MOVE MCIELO-VLR-COBRANCA TO PARCEHIS-VAL-OPERACAO */
            _.Move(REG_CIELO.MCIELO_VLR_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -1750- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0712_99_SAIDA*/

        [StopWatch]
        /*" R0715-00-RECUP-DADOS-HISTORICO-SECTION */
        private void R0715_00_RECUP_DADOS_HISTORICO_SECTION()
        {
            /*" -1758- MOVE '0715' TO WNR-EXEC-SQL */
            _.Move("0715", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1760- DISPLAY WNR-EXEC-SQL */
            _.Display(ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1761- MOVE HISCONPA-NUM-APOLICE TO PARCEHIS-NUM-APOLICE */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -1763- MOVE HISCONPA-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -1765- MOVE ZEROS TO PARCEHIS-NUM-PARCELA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -1797- PERFORM R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1 */

            R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1();

            /*" -1800-  EVALUATE SQLCODE  */

            /*" -1801-  WHEN ZEROS  */

            /*" -1801- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1802- CONTINUE */

                /*" -1803-  WHEN -811  */

                /*" -1803- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -1804- DISPLAY '0715-00-TITULO DUPLICADO PARCELA_HISTORICO' */
                _.Display($"0715-00-TITULO DUPLICADO PARCELA_HISTORICO");

                /*" -1805- DISPLAY 'APOLICE  ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1806- DISPLAY 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1807- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1808-  WHEN +100  */

                /*" -1808- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1809- DISPLAY '0715-NAO ACHOU REGISTRO PARCELA_HISTORICO' */
                _.Display($"0715-NAO ACHOU REGISTRO PARCELA_HISTORICO");

                /*" -1810- DISPLAY 'APOLICE  ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1811- DISPLAY 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1812- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1813-  WHEN OTHER  */

                /*" -1813- ELSE */
            }
            else
            {


                /*" -1814- DISPLAY '0715-ERRO NO ACESSO PARCELA_HISTORICO' */
                _.Display($"0715-ERRO NO ACESSO PARCELA_HISTORICO");

                /*" -1815- DISPLAY 'APOLICE  ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1816- DISPLAY 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1817- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1817-  END-EVALUATE.  */

                /*" -1817- END-IF. */
            }


        }

        [StopWatch]
        /*" R0715-00-RECUP-DADOS-HISTORICO-DB-SELECT-1 */
        public void R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1()
        {
            /*" -1797- EXEC SQL SELECT A.DATA_VENCIMENTO , A.OCORR_HISTORICO , A.PRM_TARIFARIO , A.VAL_DESCONTO , A.PRM_LIQUIDO , A.ADICIONAL_FRACIO , A.VAL_CUSTO_EMISSAO , A.VAL_IOCC , A.PRM_TOTAL , A.NUM_PARCELA INTO :PARCEHIS-DATA-VENCIMENTO , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-PRM-LIQUIDO , :PARCEHIS-ADICIONAL-FRACIO , :PARCEHIS-VAL-CUSTO-EMISSAO , :PARCEHIS-VAL-IOCC , :PARCEHIS-PRM-TOTAL , :PARCEHIS-NUM-PARCELA FROM SEGUROS.PARCELA_HISTORICO A ,SEGUROS.PARCELAS B WHERE A.NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND A.NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND A.NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA AND A.OCORR_HISTORICO = B.OCORR_HISTORICO WITH UR END-EXEC */

            var r0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1 = new R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1.Execute(r0715_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
                _.Move(executed_1.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(executed_1.PARCEHIS_PRM_TARIFARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);
                _.Move(executed_1.PARCEHIS_VAL_DESCONTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);
                _.Move(executed_1.PARCEHIS_PRM_LIQUIDO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);
                _.Move(executed_1.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);
                _.Move(executed_1.PARCEHIS_VAL_CUSTO_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);
                _.Move(executed_1.PARCEHIS_VAL_IOCC, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);
                _.Move(executed_1.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(executed_1.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0715_99_SAIDA*/

        [StopWatch]
        /*" R0718-00-INSERT-PARCELA-HIS-SECTION */
        private void R0718_00_INSERT_PARCELA_HIS_SECTION()
        {
            /*" -1826- MOVE '0718' TO WNR-EXEC-SQL */
            _.Move("0718", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1884- PERFORM R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1 */

            R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1();

            /*" -1887-  EVALUATE SQLCODE  */

            /*" -1888-  WHEN ZEROS  */

            /*" -1888- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1889- SUBTRACT PARCEHIS-PRM-TOTAL FROM WS-SDOATUAL */
                AREA_DE_WORK.WS_SDOATUAL.Value = AREA_DE_WORK.WS_SDOATUAL - PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                /*" -1890-  WHEN -803  */

                /*" -1890- ELSE IF   SQLCODE EQUALS  -803 */
            }
            else

            if (DB.SQLCODE == -803)
            {

                /*" -1891- DISPLAY '0718- (REG DUPLICADO) PARCELA_HISTORICO ' */
                _.Display($"0718- (REG DUPLICADO) PARCELA_HISTORICO ");

                /*" -1892- DISPLAY 'APOLICE  ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1893- DISPLAY 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1894- DISPLAY 'NRO PARC ' PARCEHIS-NUM-PARCELA */
                _.Display($"NRO PARC {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1895- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1896-  WHEN OTHER  */

                /*" -1896- ELSE */
            }
            else
            {


                /*" -1897- DISPLAY '0718-ERRO-PROBLEMAS NO INSERT PARCELA_HISTORICO' */
                _.Display($"0718-ERRO-PROBLEMAS NO INSERT PARCELA_HISTORICO");

                /*" -1898- DISPLAY 'APOLICE  ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1899- DISPLAY 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1900- DISPLAY 'NRO PARC ' PARCEHIS-NUM-PARCELA */
                _.Display($"NRO PARC {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1901- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1903-  END-EVALUATE  */

                /*" -1903- END-IF */
            }


            /*" -1903- ADD 1 TO WS-IN-PARCEHIS. */
            AREA_DE_WORK.WS_IN_PARCEHIS.Value = AREA_DE_WORK.WS_IN_PARCEHIS + 1;

        }

        [StopWatch]
        /*" R0718-00-INSERT-PARCELA-HIS-DB-INSERT-1 */
        public void R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1()
        {
            /*" -1884- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO ( NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , COD_OPERACAO , HORA_OPERACAO , OCORR_HISTORICO , PRM_TARIFARIO , VAL_DESCONTO , PRM_LIQUIDO , ADICIONAL_FRACIO , VAL_CUSTO_EMISSAO , VAL_IOCC , PRM_TOTAL , VAL_OPERACAO , DATA_VENCIMENTO , BCO_COBRANCA , AGE_COBRANCA , NUM_AVISO_CREDITO , ENDOS_CANCELA , SIT_CONTABIL , COD_USUARIO , RENUM_DOCUMENTO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP ) VALUES ( :PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-DAC-PARCELA , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-COD-OPERACAO , :PARCEHIS-HORA-OPERACAO , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-PRM-LIQUIDO , :PARCEHIS-ADICIONAL-FRACIO , :PARCEHIS-VAL-CUSTO-EMISSAO , :PARCEHIS-VAL-IOCC , :PARCEHIS-PRM-TOTAL , :PARCEHIS-VAL-OPERACAO , :PARCEHIS-DATA-VENCIMENTO , :PARCEHIS-BCO-COBRANCA , :PARCEHIS-AGE-COBRANCA , :PARCEHIS-NUM-AVISO-CREDITO , :PARCEHIS-ENDOS-CANCELA , :PARCEHIS-SIT-CONTABIL , :PARCEHIS-COD-USUARIO , :PARCEHIS-RENUM-DOCUMENTO , :PARCEHIS-DATA-QUITACAO:VIND-DTQITBCO , :PARCEHIS-COD-EMPRESA , CURRENT TIMESTAMP ) END-EXEC */

            var r0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1 = new R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_HORA_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_DTQITBCO = AREA_DE_WORK.VIND_DTQITBCO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
            };

            R0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1.Execute(r0718_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0718_99_SAIDA*/

        [StopWatch]
        /*" R0725-00-ATUALIZA-PARCELAS-SECTION */
        private void R0725_00_ATUALIZA_PARCELAS_SECTION()
        {
            /*" -1912- MOVE '0725' TO WNR-EXEC-SQL */
            _.Move("0725", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1918- PERFORM R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1 */

            R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1();

            /*" -1921- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1922- DISPLAY '0725 - PROBLEMAS UPDATE PARCELAS' */
                _.Display($"0725 - PROBLEMAS UPDATE PARCELAS");

                /*" -1923- DISPLAY 'NUM-APOLICE = ' HISCONPA-NUM-APOLICE */
                _.Display($"NUM-APOLICE = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                /*" -1924- DISPLAY 'NUM-ENDOSSO = ' HISCONPA-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                /*" -1925- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1927- END-IF */
            }


            /*" -1927- ADD 1 TO WS-UP-PARCELAS. */
            AREA_DE_WORK.WS_UP_PARCELAS.Value = AREA_DE_WORK.WS_UP_PARCELAS + 1;

        }

        [StopWatch]
        /*" R0725-00-ATUALIZA-PARCELAS-DB-UPDATE-1 */
        public void R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1()
        {
            /*" -1918- EXEC SQL UPDATE SEGUROS.PARCELAS SET SIT_REGISTRO = '1' , OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO END-EXEC */

            var r0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1 = new R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1()
            {
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            R0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1.Execute(r0725_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0725_99_SAIDA*/

        [StopWatch]
        /*" R0730-00-ATUALIZA-ENDOSSOS-SECTION */
        private void R0730_00_ATUALIZA_ENDOSSOS_SECTION()
        {
            /*" -1937- MOVE '0730' TO WNR-EXEC-SQL */
            _.Move("0730", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1942- PERFORM R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1 */

            R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1();

            /*" -1945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1946- DISPLAY '0730 - PROBLEMAS UPDATE ENDOSSOS' */
                _.Display($"0730 - PROBLEMAS UPDATE ENDOSSOS");

                /*" -1947- DISPLAY 'NUM-APOLICE = ' HISCONPA-NUM-APOLICE */
                _.Display($"NUM-APOLICE = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                /*" -1948- DISPLAY 'NUM-ENDOSSO = ' HISCONPA-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                /*" -1949- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1951- END-IF */
            }


            /*" -1951- ADD 1 TO WS-UP-ENDOSSOS. */
            AREA_DE_WORK.WS_UP_ENDOSSOS.Value = AREA_DE_WORK.WS_UP_ENDOSSOS + 1;

        }

        [StopWatch]
        /*" R0730-00-ATUALIZA-ENDOSSOS-DB-UPDATE-1 */
        public void R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -1942- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET SIT_REGISTRO = '1' WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO END-EXEC */

            var r0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1 = new R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            R0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r0730_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0730_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1960- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

            /*" -1961- DISPLAY WABEND */
            _.Display(ABEN.WABEND);

            /*" -1962- DISPLAY WABEND1 */
            _.Display(ABEN.WABEND1);

            /*" -1962- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1964- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1965- DISPLAY ' ' */
            _.Display($" ");

            /*" -1966- DISPLAY 'CB00123B - FIM COM ERRO     ' . */
            _.Display($"CB00123B - FIM COM ERRO     ");

            /*" -1968- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1968- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}