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
using Sias.Cobranca.DB2.CB0124B;

namespace Code
{
    public class CB0124B
    {
        public bool IsCall { get; set; }

        public CB0124B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0124B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  PROJETO CARTAO DE CREDITO CIELO.                              *      */
        /*"      *  FUNCAO: RECEBE O ARQUIVO DEMAIS PARCELAS GERADO PELO PROGRAMA *      */
        /*"      *  EM8024B E EFETUA A BAIXA DO PAGAMENTO DE DEMAIS PARCELAS VIA  *      */
        /*"      *  CARTAO. AO RECEBER O MOVIMENTO 03 (CONFIRMACAO DE CAPTURA) ,  *      */
        /*"      *  BAIXA A PARCELA NA TABELA PARCELAS_VIDAZUL,COBER_HIST_VIDAZUL,*      */
        /*"      *  E DEIXA COM SITUACAO '3' (AGUARDANDO RETORNO) NA HIST_LANC_CTA*      */
        /*"      *  GERANDO TAMBEM O ENDOSSO DE EMISSAO. AO RECEBER O MOVIMENTO 04*      */
        /*"      *  (MOVIMENTO FINANCEIRO) BAIXA PARCELA NA HIST_LANC_CTA, BAIXA O*      */
        /*"      *  ENDOSSO EMITIDO E CRIA OPERACAO DE BAIXA NA TABELA            *      */
        /*"      *  PARCELA_HISTORICO.                                            *      */
        /*"      *                                                                *      */
        /*"      *  PROGRAMADOR ............  FRANK / DANIEL MEDINA               *      */
        /*"      *  DATA CODIFICACAO .......  19/06/2019                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 25/01/2024 *      */
        /*"      *   VERSAO 21               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
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
        /*"      *                           - PROCURAR POR V.21                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.20  *  VERSAO...: V.20                                               *      */
        /*"      *  JAZZ.....: 496862             PROGRAMADOR: ELIERMES OLIVEIRA  *      */
        /*"      *  DATA ....: 27/12/2023                                         *      */
        /*"      *  DESCRICAO: PROCESSA RETORNO DE CANCELAMENTO PARCIAL DE PARCELA*      */
        /*"      *             E CHARGEBACK ENVIADO PELA CIELO/SAP                *      */
        /*"      *  PROCURE  : V.20                                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.18  *  VERSAO...: V.18                                               *      */
        /*"      *  JAZZ.....: 531.762            PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 15/09/2023                                         *      */
        /*"      *  DESCRICAO: DESPREZAR REGISTROS QUE MUDARAM DE OPCAO DE PAGA-  *      */
        /*"      *             MENTO E A OPERACAO REMOVEU O LANCAMENTO DE COBRAN- *      */
        /*"      *             CA NO CARTAO DE CREDITO DO SIAS ATRAVES DAS APLICA-*      */
        /*"      *             COES, DESDE QUE O RETORNO SEJA DE RECUSA DE CAPTURA*      */
        /*"      *  PROCURE  : V.18                                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.17  *  VERSAO...: V.17                                               *      */
        /*"      *  JAZZ.....: 458445             PROGRAMADOR: CANETTA            *      */
        /*"      *  DATA ....: 05/01/2023                                         *      */
        /*"      *  DESCRICAO: FORMATACAO HISCONPA-NUM-CERTIFICADO/NUM-PARCELA    *      */
        /*"      *  PROCURE  : V.17                                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.16                                               *      */
        /*"      *  JAZZ.....: 317.905            PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 23/09/2021                                         *      */
        /*"      *  DESCRICAO: ATUALIZAR A SITUACAO DA PARCELA NA HIST_LANC_CTA   *      */
        /*"      *             PARA SEM RETORNO CASO TENHA ENTRADO EM REGUA DE    *      */
        /*"      *             COBRANCA E POSTERIORMENTE OBTEVE SUCESSO NA CAPTURA*      */
        /*"      *                                          PROCURE POR V.16      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.15                                               *      */
        /*"      *  JAZZ.....: 318.037            PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 16/09/2021                                         *      */
        /*"      *  DESCRICAO: RECUPERAR O FATURAMENTO DO LANCAMENTO CORRETO NA   *      */
        /*"      *             TABELA HIST_CONT_PARCELVA.                         *      */
        /*"      *                                          PROCURE POR V.15      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.14                                               *      */
        /*"      *  JAZZ.....: 316.343            PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 13/09/2021                                         *      */
        /*"      *  DESCRICAO: PERMITIR O CONSUMO DE REGISTROS COM RETORNO DE     *      */
        /*"      *             CHARGEBACK ATE A IMPLEMENTACAO DA DEMANDA 241946.  *      */
        /*"      *                                          PROCURE POR V.14      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.13                                               *      */
        /*"      *  OS/FABRIC: 251270 / 2019230   PROGRAMADORA: TERCIO / FRANK    *      */
        /*"      *  DATA ....: 26/04/2020                                         *      */
        /*"      *  DESCRICAO: NA DEVOLUCAO AUTOMATICA TRATAR O RETORNO DO ARQ-H. *      */
        /*"      *             CANCELAR O FATURAMENTO NA TABELA HIST_CONT_PARCELVA*      */
        /*"      *                                          PROCURE POR V.13      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.12                                               *      */
        /*"      *  OS/FABRIC: 278.146            PROGRAMADORA: FRANK CARVALHO    *      */
        /*"      *  DATA ....: 23/03/2021                                         *      */
        /*"      *  DESCRICAO: UTILIZAR O CAMPO MOTIVO DE COMPENSACAO PARA PERMA- *      */
        /*"      *             NECER COM O REGISTRO EM REGUA DE COBRANCA          *      */
        /*"      *                                          PROCURE POR V.12      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.11                                               *      */
        /*"      *  JAZZ.....: ABEND 278.176      PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 18/02/2021                                         *      */
        /*"      *  DESCRICAO: BUSCAR REGISTROS NA HIST-LANC-CTA PELO IDLG PARA   *      */
        /*"      *             AMENIZAR AINDA MAIS OS IMPACTOS DA REGUA DE COBRAN-*      */
        /*"      *             CA QUE O SAP PUBLICOU.                             *      */
        /*"      *                                          PROCURE POR V.11      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.10                                               *      */
        /*"      *  JAZZ.....: ABEND 274.738      PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 20/01/2021                                         *      */
        /*"      *  DESCRICAO: DEVIDO AOS CASOS COM PROCEDIMENTOS DE ADVERTENCIAS *      */
        /*"      *             INVALIDOS, REALIZAR A CONSULTA SEM TRATAR A SITUA- *      */
        /*"      *             �AO ATUAL DA PARCELA PARA ABSORVER O ENVIO DE MAIS *      */
        /*"      *             DE UM ARQ-H.                                       *      */
        /*"      *                                          PROCURE POR V.10      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.09                                               *      */
        /*"      *  JAZZ.....: DEMANDA 250.426    PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 12/01/2021                                         *      */
        /*"      *  DESCRICAO: CASO NAO SEJA INFORMADO OS PROCEDIMENTOS DE ADVER- *      */
        /*"      *             TENCIAS DA REGUA DE COBRANCA CONSIDERAR A PARCELA  *      */
        /*"      *             COMO INADIMPLENTE.                                 *      */
        /*"      *                                          PROCURE POR V.09      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.08                                               *      */
        /*"      *  JAZZ.....: ABEND 270.587      PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 16/12/2020                                         *      */
        /*"      *  DESCRICAO: ALTERAR A MANEIRA DE RECUPERAR O NUMERO DO CARTAO  *      */
        /*"      *             PARA NAO ABENDAR QUANDO O CLIENTE MUDOU DE OPCAO.  *      */
        /*"      *                                          PROCURE POR V.08      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.07                                               *      */
        /*"      *  JAZZ.....: ABEND 270072       PROGRAMADOR: CLAUDETE RADEL     *      */
        /*"      *  DATA ....: 14/12/2020                                         *      */
        /*"      *  DESCRICAO: INCLUIR O CONVENIO NA BUSCA DA HIST_LANC_CTA PARA  *      */
        /*"      *             NAO DAR -811. CODCONV 9020 -> CARTAO.              *      */
        /*"      *                                          PROCURE POR V.07      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.06                                               *      */
        /*"      *  JAZ......: DEMANDA 250.426    PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 03/12/2020                                         *      */
        /*"      *  DESCRICAO: PERMITIR QUE O REGISTRO PERMANECA EM REGUA DE      *      */
        /*"      *             COBRANCA NO SAP POR ATE 3 REPIQUES NO CARTAO.      *      */
        /*"      *                                          PROCURE POR V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.05                                               *      */
        /*"      *  INCIDENTE: 237.057         PROGRAMADORA: FRANK CARVALHO       *      */
        /*"      *  DATA ....: 16/03/2020                                         *      */
        /*"      *  DESCRICAO: FALHA AO ENCONTRAR A PARCELA PENDENTE DE BAIXA.    *      */
        /*"      *             FOI ADICIONADO A SITUACAO 'CANCELADO' POIS O SEGURO*      */
        /*"      *             ESTA NESTA SITUACAO NO MOMENTO DO RETORNO DO SAP.  *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.04                                               *      */
        /*"      *  JAZ......: 229.994         PROGRAMADORA: FRANK CARVALHO       *      */
        /*"      *  DATA ....: 15/01/2020                                         *      */
        /*"      *  DESCRICAO: NAO REALIZAR UPDATE DO CAMPO TIMESTAMP AO ATUALIZAR*      */
        /*"      *             A SITUACAO, O CAMPO SERA UTILIZADO PARA A DATA DE  *      */
        /*"      *             GERACAO DA PARCELA ATE QUE TENHAMOS UM CAMPO ESPE- *      */
        /*"      *             FICO.                                              *      */
        /*"      *                                          PROCURE POR V.04      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.03                                               *      */
        /*"      *  JAZ......: 226.949         PROGRAMADORA: CLAUDETE RADEL       *      */
        /*"      *  DATA ....: 17/12/2019                                         *      */
        /*"      *  DESCRICAO: ALTERAR A CONSULTA DA R3070 PARA BUSCAR PELA DATA  *      */
        /*"      *             DE GERACAO DA PARCELA E NAO PELA DATA DE VENCIMENTO*      */
        /*"      *                                          PROCURE POR V.03      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.02                                               *      */
        /*"      *  JAZ......: 224.866         PROGRAMADOR: FRANK CARVALHO        *      */
        /*"      *  DATA ....: 11/11/2019                                         *      */
        /*"      *  DESCRICAO: ATUALIZAR NUM-CARTAO-CREDITO MASCARADO NA BASE DO  *      */
        /*"      *             SIAS (OPCAO_PAG_VIDAZUL).                          *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.01                                               *      */
        /*"      *  JAZ......: 176367          PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 11/09/2019                                         *      */
        /*"      *  DESCRICAO:                                                    *      */
        /*"      *  OCORR�NCIA DE FALHA N� 176367                                 *      */
        /*"      *  SISTEMA: CONTABILIDADE GERAL                                  *      */
        /*"      *  PROGRAMA: GL0001B                                             *      */
        /*"      *  ROTINA: JPGLD01                                               *      */
        /*"      *  DESCRI��O: SQLCODE 100                                        *      */
        /*"      *  DATA DA OCORR�NCIA: 11/09/2019 01:40:42                       *      */
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

        public FileBasis _CCDEMAIS { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis CCDEMAIS
        {
            get
            {
                _.Move(REG_CCDEMAIS, _CCDEMAIS); VarBasis.RedefinePassValue(REG_CCDEMAIS, _CCDEMAIS, REG_CCDEMAIS); return _CCDEMAIS;
            }
        }
        /*"01        REG-CCDEMAIS.*/
        public CB0124B_REG_CCDEMAIS REG_CCDEMAIS { get; set; } = new CB0124B_REG_CCDEMAIS();
        public class CB0124B_REG_CCDEMAIS : VarBasis
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
        public CB0124B_ABEN ABEN { get; set; } = new CB0124B_ABEN();
        public class CB0124B_ABEN : VarBasis
        {
            /*"  03     WABEND.*/
            public CB0124B_WABEND WABEND { get; set; } = new CB0124B_WABEND();
            public class CB0124B_WABEND : VarBasis
            {
                /*"    05   FILLER                 PIC  X(010) VALUE        ' CB0124B  '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB0124B  ");
                /*"    05   FILLER                 PIC  X(028) VALUE        ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05   WNR-EXEC-SQL           PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03     WABEND1.*/
            }
            public CB0124B_WABEND1 WABEND1 { get; set; } = new CB0124B_WABEND1();
            public class CB0124B_WABEND1 : VarBasis
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
        public CB0124B_HEAD01_CIELO HEAD01_CIELO { get; set; } = new CB0124B_HEAD01_CIELO();
        public class CB0124B_HEAD01_CIELO : VarBasis
        {
            /*"  05   HEAD01-TIPO-REGISTRO     PIC  9(003).*/
            public IntBasis HEAD01_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   HEAD01-TIPO-ARQUIVO      PIC  9(003).*/
            public IntBasis HEAD01_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   HEAD01-DATA-GERACAO.*/
            public CB0124B_HEAD01_DATA_GERACAO HEAD01_DATA_GERACAO { get; set; } = new CB0124B_HEAD01_DATA_GERACAO();
            public class CB0124B_HEAD01_DATA_GERACAO : VarBasis
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
        public CB0124B_REG_CIELO REG_CIELO { get; set; } = new CB0124B_REG_CIELO();
        public class CB0124B_REG_CIELO : VarBasis
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
            /*"  05   MCIELO-PROC-ADVERT       PIC  X(002).*/
            public StringBasis MCIELO_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05   MCIELO-NIVE-ADVERT       PIC  X(002).*/
            public StringBasis MCIELO_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05   MCIELO-MOTI-COMPEN       PIC  9(002).*/
            public IntBasis MCIELO_MOTI_COMPEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05   FILLER                   PIC  X(008).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"01     TRAI01-CIELO.*/
        }
        public CB0124B_TRAI01_CIELO TRAI01_CIELO { get; set; } = new CB0124B_TRAI01_CIELO();
        public class CB0124B_TRAI01_CIELO : VarBasis
        {
            /*"  05   TRAI01-TIPO-REGISTRO     PIC  9(003).*/
            public IntBasis TRAI01_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   TRAI01-DATA-MOVIMENTO.*/
            public CB0124B_TRAI01_DATA_MOVIMENTO TRAI01_DATA_MOVIMENTO { get; set; } = new CB0124B_TRAI01_DATA_MOVIMENTO();
            public class CB0124B_TRAI01_DATA_MOVIMENTO : VarBasis
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
        public CB0124B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB0124B_AREA_DE_WORK();
        public class CB0124B_AREA_DE_WORK : VarBasis
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
            /*"  03  WS-CONT-IDE3-CC          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDE3_CC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDE3-CI          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDE3_CI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDE3CC           PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDE3CC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDE4-OK          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDE4_OK { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDE4-NOK         PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDE4_NOK { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDE4-17          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDE4_17 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDEPA-17         PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDEPA_17 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDERC            PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDERC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDERC0102        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDERC0102 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-CONT-IDERC03          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_CONT_IDERC03 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-DES-TIPO-SIT          PIC  X(040).*/
            public StringBasis WS_DES_TIPO_SIT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  03  WS-FIM-MOVIMENTO         PIC  X(01)     VALUE SPACES.*/
            public StringBasis WS_FIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  03  WS-FIM-PARC-SRETORNO     PIC  X(01)     VALUE SPACES.*/
            public StringBasis WS_FIM_PARC_SRETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
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
            /*"  03  WS-CONTA-CONTABIL        PIC S9(004)    COMP.*/
            public IntBasis WS_CONTA_CONTABIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-NUM-PARCELA           PIC S9(004)    COMP.*/
            public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-NSAC                  PIC S9(004)    COMP.*/
            public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-DATA-GERACAO-PARCELA  PIC  X(010)    VALUE SPACES.*/
            public StringBasis WS_DATA_GERACAO_PARCELA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03  WS-OCORR-HISTORICO       PIC S9(004)    COMP.*/
            public IntBasis WS_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-DTQITBCO            PIC S9(004)    COMP.*/
            public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-CODEMP              PIC S9(004)    COMP.*/
            public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-ORIGEM              PIC S9(004)    COMP.*/
            public IntBasis VIND_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-VALADT              PIC S9(004)    COMP.*/
            public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-DTFATUR             PIC S9(004)    COMP.*/
            public IntBasis VIND_DTFATUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-CCRE                PIC S9(004)    COMP.*/
            public IntBasis VIND_CCRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-NSAC                PIC S9(004)    COMP.*/
            public IntBasis VIND_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  VIND-COD-RET             PIC S9(004)    COMP.*/
            public IntBasis VIND_COD_RET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-FIM-PROD              PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_FIM_PROD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-LD-PRODUTOS           PIC  9(007) VALUE ZEROS.*/
            public IntBasis WS_LD_PRODUTOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-LD-PARC-SR            PIC  9(007) VALUE ZEROS.*/
            public IntBasis WS_LD_PARC_SR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-NUM-PARC-SR           PIC S9(004)    COMP.*/
            public IntBasis WS_NUM_PARC_SR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-QTD-PARC-SR           PIC S9(004)    COMP.*/
            public IntBasis WS_QTD_PARC_SR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-VLR-PARC-SR           PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLR_PARC_SR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-SUBS                  PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-SUBS1                 PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-SUBS2                 PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  PARAGRAFO                PIC  X(050) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"  03  V0SEGU-TPINCLUS          PIC  X(001).*/
            public StringBasis V0SEGU_TPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  V0SEGU-AGENCIADOR        PIC S9(009) VALUE +0 COMP.*/
            public IntBasis V0SEGU_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  V0SEGU-ITEM              PIC S9(009) VALUE +0 COMP.*/
            public IntBasis V0SEGU_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  V0SEGU-OCORHIST          PIC S9(004) VALUE +0 COMP.*/
            public IntBasis V0SEGU_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0SEGU-LOT-EMP-SEGURADO  PIC X(030).*/
            public StringBasis V0SEGU_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  03  VIND-LOT-EMP-SEG         PIC S9(004) COMP VALUE +0.*/
            public IntBasis VIND_LOT_EMP_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-NRCERTIF          PIC S9(015)      VALUE +0 COMP-3.*/
            public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  03  V0PROP-CODPRODU          PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-NRPARCEL          PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0PROP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-SITUACAO          PIC  X(001).*/
            public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  V0PROP-DTVENCTO          PIC  X(010).*/
            public StringBasis V0PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03  V0PROP-DTPROXVEN         PIC  X(010).*/
            public StringBasis V0PROP_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03  V0PROP-DTQITBCO          PIC  X(010).*/
            public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03  V0PROP-DTADMISSAO        PIC  X(010).*/
            public StringBasis V0PROP_DTADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03  V0PROP-QTDPARATZ         PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-NRPRIPARATZ       PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0PROP_NRPRIPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-FONTE             PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-NUM-APOLICE       PIC S9(013)      VALUE +0 COMP-3.*/
            public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03  V0PROP-CODSUBES          PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-NRMATRFUN         PIC S9(015)      VALUE +0 COMP-3.*/
            public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  03  V0PROP-INRMATRFUN        PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-CODCLIEN          PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  V0PROP-TIMESTAMP         PIC  X(026).*/
            public StringBasis V0PROP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"  03  V0PROP-OPCAOCAP          PIC S9(004)               COMP.*/
            public IntBasis V0PROP_OPCAOCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0PROP-ESTR-COBR         PIC  X(010).*/
            public StringBasis V0PROP_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03  V0PROP-ORIG-PRODU        PIC  X(010).*/
            public StringBasis V0PROP_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03  V0PROP-TEM-SAF           PIC  X(001).*/
            public StringBasis V0PROP_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  V0PROP-TEM-CDG           PIC  X(001).*/
            public StringBasis V0PROP_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  V0PROP-COBERADIC         PIC  X(001).*/
            public StringBasis V0PROP_COBERADIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  V0PROP-CUSTOCAP          PIC  X(001).*/
            public StringBasis V0PROP_CUSTOCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  V0PROP-PERIPGTO          PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0PROP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0OPCP-OPCAOPAG          PIC  X(001).*/
            public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  V0OPCP-PERIPGTO          PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0OPCP-AGECTADEB         PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0OPCP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0OPCP-OPRCTADEB         PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0OPCP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0OPCP-NUMCTADEB         PIC S9(013)      VALUE +0 COMP-3.*/
            public IntBasis V0OPCP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03  V0OPCP-DIGCTADEB         PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis V0OPCP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  V0OPCP-CARTAOCRED        PIC  X(016)      VALUE SPACES.*/
            public StringBasis V0OPCP_CARTAOCRED { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
            /*"  03  V0COBA-IMPMORNATU        PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis V0COBA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  V0COBA-IMPMORACID        PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis V0COBA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  V0COBA-IMPINVPERM        PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis V0COBA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  V0COBA-IMPDIT            PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis V0COBA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  V0COBA-PRMVG             PIC S9(010)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis V0COBA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03  V0COBA-PRMAP             PIC S9(010)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis V0COBA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  03  V0FONT-PROPAUTOM         PIC S9(009)      COMP.*/
            public IntBasis V0FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WS-VLR-RELAT             PIC S9(10)V9(5) USAGE COMP-3.*/
            public DoubleBasis WS_VLR_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
            /*"  03  WS-NUM-ORDEM-RELAT       PIC S9(15)V     USAGE COMP-3.*/
            public DoubleBasis WS_NUM_ORDEM_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"  03  WS-BCO-RELAT             PIC S9(04)      COMP.*/
            public IntBasis WS_BCO_RELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03  WS-VLDESPES              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VLPRMLIQ              PIC S9(013)V99 COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03    WS-DATA-REL           PIC  X(010) VALUE SPACES.*/
            public StringBasis WS_DATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03    FILLER            REDEFINES      WS-DATA-REL.*/
            private _REDEF_CB0124B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_CB0124B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_CB0124B_FILLER_9(); _.Move(WS_DATA_REL, _filler_9); VarBasis.RedefinePassValue(WS_DATA_REL, _filler_9, WS_DATA_REL); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS_DATA_REL); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS_DATA_REL); }
            }  //Redefines
            public class _REDEF_CB0124B_FILLER_9 : VarBasis
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

                public _REDEF_CB0124B_FILLER_9()
                {
                    WS_DAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WS_DAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WS_DAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0124B_WS_TIME WS_TIME { get; set; } = new CB0124B_WS_TIME();
            public class CB0124B_WS_TIME : VarBasis
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
            public CB0124B_WS_HORA_EDIT WS_HORA_EDIT { get; set; } = new CB0124B_WS_HORA_EDIT();
            public class CB0124B_WS_HORA_EDIT : VarBasis
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
            public CB0124B_WS_NUM_CARTAO_CRED_SAP WS_NUM_CARTAO_CRED_SAP { get; set; } = new CB0124B_WS_NUM_CARTAO_CRED_SAP();
            public class CB0124B_WS_NUM_CARTAO_CRED_SAP : VarBasis
            {
                /*"    10  FILLER                 PIC  X(002).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10  WS-NUM-CART-CRED16     PIC  X(016).*/
                public StringBasis WS_NUM_CART_CRED16 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"    10  FILLER                 PIC  X(007).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"  03  WS-COD-IDLG                 PIC  X(040).*/
            }
            public StringBasis WS_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  03  WS-COD-IDLG-DEMAIS REDEFINES WS-COD-IDLG.*/
            private _REDEF_CB0124B_WS_COD_IDLG_DEMAIS _ws_cod_idlg_demais { get; set; }
            public _REDEF_CB0124B_WS_COD_IDLG_DEMAIS WS_COD_IDLG_DEMAIS
            {
                get { _ws_cod_idlg_demais = new _REDEF_CB0124B_WS_COD_IDLG_DEMAIS(); _.Move(WS_COD_IDLG, _ws_cod_idlg_demais); VarBasis.RedefinePassValue(WS_COD_IDLG, _ws_cod_idlg_demais, WS_COD_IDLG); _ws_cod_idlg_demais.ValueChanged += () => { _.Move(_ws_cod_idlg_demais, WS_COD_IDLG); }; return _ws_cod_idlg_demais; }
                set { VarBasis.RedefinePassValue(value, _ws_cod_idlg_demais, WS_COD_IDLG); }
            }  //Redefines
            public class _REDEF_CB0124B_WS_COD_IDLG_DEMAIS : VarBasis
            {
                /*"    10 WS-IDLG-CONVENIO           PIC  9(006).*/
                public IntBasis WS_IDLG_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10 WS-IDLG-NSA                PIC  9(006).*/
                public IntBasis WS_IDLG_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10 WS-IDLG-NRSEQ              PIC  9(009).*/
                public IntBasis WS_IDLG_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10 FILLER                     PIC  X(019).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"  03  WS-COD-IDLG-ADESAO REDEFINES WS-COD-IDLG.*/

                public _REDEF_CB0124B_WS_COD_IDLG_DEMAIS()
                {
                    WS_IDLG_CONVENIO.ValueChanged += OnValueChanged;
                    WS_IDLG_NSA.ValueChanged += OnValueChanged;
                    WS_IDLG_NRSEQ.ValueChanged += OnValueChanged;
                    FILLER_16.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_CB0124B_WS_COD_IDLG_ADESAO _ws_cod_idlg_adesao { get; set; }
            public _REDEF_CB0124B_WS_COD_IDLG_ADESAO WS_COD_IDLG_ADESAO
            {
                get { _ws_cod_idlg_adesao = new _REDEF_CB0124B_WS_COD_IDLG_ADESAO(); _.Move(WS_COD_IDLG, _ws_cod_idlg_adesao); VarBasis.RedefinePassValue(WS_COD_IDLG, _ws_cod_idlg_adesao, WS_COD_IDLG); _ws_cod_idlg_adesao.ValueChanged += () => { _.Move(_ws_cod_idlg_adesao, WS_COD_IDLG); }; return _ws_cod_idlg_adesao; }
                set { VarBasis.RedefinePassValue(value, _ws_cod_idlg_adesao, WS_COD_IDLG); }
            }  //Redefines
            public class _REDEF_CB0124B_WS_COD_IDLG_ADESAO : VarBasis
            {
                /*"    10 WS-COD-EMPRESA             PIC  X(004).*/
                public StringBasis WS_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10 WS-IDENTIFICACAO           PIC  X(011).*/
                public StringBasis WS_IDENTIFICACAO { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"    10 WS-NUM-PROPOSTA            PIC  X(014).*/
                public StringBasis WS_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                /*"    10 FILLER                     PIC  X(011).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"01  WS-DESPREZA-REGISTRO       PIC  X(001) VALUE 'N'.*/

                public _REDEF_CB0124B_WS_COD_IDLG_ADESAO()
                {
                    WS_COD_EMPRESA.ValueChanged += OnValueChanged;
                    WS_IDENTIFICACAO.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_17.ValueChanged += OnValueChanged;
                }

            }
        }

        public SelectorBasis WS_DESPREZA_REGISTRO { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-DESPREZA                      VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_DESPREZA", "S"),
							/*" 88 WS-NAO-DESPREZA                      VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_DESPREZA", "N")
                }
        };

        /*"01  WS-COD-RETORNO             PIC  X(003) VALUE '   '.*/

        public SelectorBasis WS_COD_RETORNO { get; set; } = new SelectorBasis("003", " ")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-COD-CHARGE-BACK                   VALUE      ' 28' ' 29' ' 30' ' 31' ' 32' ' 33' ' 34' ' 35' ' 36'      ' 37' ' 38' ' 39' ' 40' ' 52' ' 53' ' 54' ' 55' ' 56' ' 57'      ' 58' ' 59' ' 60' ' 61' ' 62' ' 63' ' 64' ' 65' ' 66' ' 67'      ' 68' ' 69' ' 70' ' 71' ' 72' ' 73' ' 74' ' 75' ' 76'. */
							new SelectorItemBasis("WS_COD_CHARGE_BACK", " 28")
                }
        };

        /*"01  AUX-TABELAS.*/
        public CB0124B_AUX_TABELAS AUX_TABELAS { get; set; } = new CB0124B_AUX_TABELAS();
        public class CB0124B_AUX_TABELAS : VarBasis
        {
            /*"  03          WS-TABG-VALORES.*/
            public CB0124B_WS_TABG_VALORES WS_TABG_VALORES { get; set; } = new CB0124B_WS_TABG_VALORES();
            public class CB0124B_WS_TABG_VALORES : VarBasis
            {
                /*"    05        WS-TABG-OCORREPRD   OCCURS      8000   TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<CB0124B_WS_TABG_OCORREPRD> WS_TABG_OCORREPRD { get; set; } = new ListBasis<CB0124B_WS_TABG_OCORREPRD>(8000);
                public class CB0124B_WS_TABG_OCORREPRD : VarBasis
                {
                    /*"      10      WS-TABG-CODPRODU    PIC S9(004)        COMP.*/
                    public IntBasis WS_TABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WS-TABG-OCORRETIP   OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<CB0124B_WS_TABG_OCORRETIP> WS_TABG_OCORRETIP { get; set; } = new ListBasis<CB0124B_WS_TABG_OCORRETIP>(003);
                    public class CB0124B_WS_TABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WS-TABG-TIPO        PIC  X(001).*/
                        public StringBasis WS_TABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WS-TABG-OCORRESIT   OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<CB0124B_WS_TABG_OCORRESIT> WS_TABG_OCORRESIT { get; set; } = new ListBasis<CB0124B_WS_TABG_OCORRESIT>(002);
                        public class CB0124B_WS_TABG_OCORRESIT : VarBasis
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


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
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

        public CB0124B_C0_PRODUTOS C0_PRODUTOS { get; set; } = new CB0124B_C0_PRODUTOS(false);
        string GetQuery_C0_PRODUTOS()
        {
            var query = @$"SELECT COD_PRODUTO
							FROM SEGUROS.PRODUTO WHERE COD_EMPRESA IN (0
							,10
							,11) ORDER BY COD_PRODUTO";

            return query;
        }


        public CB0124B_C1_PARC_SRETORNO C1_PARC_SRETORNO { get; set; } = new CB0124B_C1_PARC_SRETORNO(true);
        string GetQuery_C1_PARC_SRETORNO()
        {
            var query = @$"SELECT A.NUM_PARCELA
							, (A.PREMIO_VG + A.PREMIO_AP)
							FROM SEGUROS.PARCELAS_VIDAZUL A
							, SEGUROS.GE_CONTROLE_CARTAO_CIELO B WHERE A.NUM_CERTIFICADO = '{AREA_DE_WORK.V0PROP_NRCERTIF}' AND A.SIT_REGISTRO = '1' AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.NUM_PARCELA = A.NUM_PARCELA AND NOT EXISTS
							(SELECT  C.NUM_CERTIFICADO
							FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO C WHERE C.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND C.NUM_PARCELA = A.NUM_PARCELA AND C.COD_TP_PAGAMENTO IN ('01'
							, '02') AND C.STA_REGISTRO = 'P') AND NOT EXISTS
							(SELECT  D.NUM_CERTIFICADO
							FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO D WHERE D.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND D.NUM_PARCELA = A.NUM_PARCELA AND D.COD_TP_PAGAMENTO IN ('03'
							, '04')) ORDER BY A.NUM_PARCELA";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CCDEMAIS_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CCDEMAIS.SetFile(CCDEMAIS_FILE_NAME_P);
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
            C1_PARC_SRETORNO.GetQueryEvent += GetQuery_C1_PARC_SRETORNO;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -587- MOVE 'R0000-00-PRINCIPAL' TO PARAGRAFO */
            _.Move("R0000-00-PRINCIPAL", AREA_DE_WORK.PARAGRAFO);

            /*" -588- MOVE '0000' TO WNR-EXEC-SQL */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -590- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -591- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -592- DISPLAY '          CB0124B - PROCESSA <CCDEMAIS>           ' */
            _.Display($"          CB0124B - PROCESSA <CCDEMAIS>           ");

            /*" -593- DISPLAY ' ' */
            _.Display($" ");

            /*" -596- DISPLAY 'VERSAO V.20 : ' FUNCTION WHEN-COMPILED ' - 496.862' */

            $"VERSAO V.20 : FUNCTION{_.WhenCompiled()} - 496.862"
            .Display();

            /*" -597- DISPLAY ' ' */
            _.Display($" ");

            /*" -604- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -605- DISPLAY '   ' */
            _.Display($"   ");

            /*" -607- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -610- PERFORM R0100-00-INICIO */

            R0100_00_INICIO_SECTION();

            /*" -615- PERFORM R3000-00-PROCESSA-MOVIMENTO UNTIL WS-FIM-MOVIMENTO = 'S' */

            while (!(AREA_DE_WORK.WS_FIM_MOVIMENTO == "S"))
            {

                R3000_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -616- IF WS-IN-MOVIMCOB GREATER ZEROS */

            if (AREA_DE_WORK.WS_IN_MOVIMCOB > 00)
            {

                /*" -617- PERFORM R5000-00-PROCESSA-FINAL */

                R5000_00_PROCESSA_FINAL_SECTION();

                /*" -619- END-IF */
            }


            /*" -619- PERFORM R0200-00-FINALIZA. */

            R0200_00_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INICIO-SECTION */
        private void R0100_00_INICIO_SECTION()
        {
            /*" -627- MOVE '0100' TO WNR-EXEC-SQL */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -628- MOVE 'R0100-00-INICIO' TO PARAGRAFO */
            _.Move("R0100-00-INICIO", AREA_DE_WORK.PARAGRAFO);

            /*" -630- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -632- OPEN INPUT CCDEMAIS */
            CCDEMAIS.Open(REG_CCDEMAIS);

            /*" -633- INITIALIZE DCLAVISO-CREDITO */
            _.Initialize(
                AVISOCRE.DCLAVISO_CREDITO
            );

            /*" -635- MOVE ZEROS TO WS-SDOATUAL */
            _.Move(0, AREA_DE_WORK.WS_SDOATUAL);

            /*" -638- PERFORM R0110-00-SELECT-V0SISTEMA */

            R0110_00_SELECT_V0SISTEMA_SECTION();

            /*" -641- PERFORM R0120-00-SELECT-AVISOCRE */

            R0120_00_SELECT_AVISOCRE_SECTION();

            /*" -643- PERFORM R0130-00-BUSCAR-PRODUTOS */

            R0130_00_BUSCAR_PRODUTOS_SECTION();

            /*" -645- MOVE SPACES TO WS-FIM-MOVIMENTO */
            _.Move("", AREA_DE_WORK.WS_FIM_MOVIMENTO);

            /*" -647- PERFORM R0150-00-LER-MOVIMENTO */

            R0150_00_LER_MOVIMENTO_SECTION();

            /*" -647- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-SELECT-V0SISTEMA-SECTION */
        private void R0110_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -655- MOVE '0110' TO WNR-EXEC-SQL */
            _.Move("0110", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -656- MOVE 'R0110-00-SELECT-V0SISTEMA' TO PARAGRAFO */
            _.Move("R0110-00-SELECT-V0SISTEMA", AREA_DE_WORK.PARAGRAFO);

            /*" -658- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -664- PERFORM R0110_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0110_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -667- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -668- WHEN 0 */
                case 0:

                    /*" -669- DISPLAY 'DATA DO MOVIMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
                    _.Display($"DATA DO MOVIMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                    /*" -670- WHEN +100 */
                    break;
                case +100:

                    /*" -671- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -672- DISPLAY 'R0110-00-SISTEMA NAO ENCONTRADO ' */
                    _.Display($"R0110-00-SISTEMA NAO ENCONTRADO ");

                    /*" -673- DISPLAY 'IDE_SISTEMA  = ' SISTEMAS-IDE-SISTEMA */
                    _.Display($"IDE_SISTEMA  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                    /*" -674- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -675- WHEN OTHER */
                    break;
                default:

                    /*" -676- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -677- DISPLAY 'R0110-00-ERRO SELECT SISTEMAS ' */
                    _.Display($"R0110-00-ERRO SELECT SISTEMAS ");

                    /*" -678- DISPLAY 'IDE_SISTEMA  = ' SISTEMAS-IDE-SISTEMA */
                    _.Display($"IDE_SISTEMA  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                    /*" -679- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -679- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R0110-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0110_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -664- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC */

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
            /*" -687- MOVE '0120' TO WNR-EXEC-SQL */
            _.Move("0120", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -688- MOVE 'R0120-00-SELECT-AVISOCRE' TO PARAGRAFO */
            _.Move("R0120-00-SELECT-AVISOCRE", AREA_DE_WORK.PARAGRAFO);

            /*" -690- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -699- PERFORM R0120_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R0120_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -702- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -703- WHEN 0 */
                case 0:

                    /*" -704- IF (AVISOCRE-NUM-AVISO-CREDITO NOT LESS 902099999) */

                    if ((AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO >= 902099999))
                    {

                        /*" -705- DISPLAY 'R0120-00 - NRAVISO ULTRAPASSA FAIXA   ' */
                        _.Display($"R0120-00 - NRAVISO ULTRAPASSA FAIXA   ");

                        /*" -706- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -707- ELSE */
                    }
                    else
                    {


                        /*" -708- IF AVISOCRE-NUM-AVISO-CREDITO EQUAL ZEROS */

                        if (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO == 00)
                        {

                            /*" -709- MOVE 902000001 TO AVISOCRE-NUM-AVISO-CREDITO */
                            _.Move(902000001, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

                            /*" -710- ELSE */
                        }
                        else
                        {


                            /*" -711- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO */
                            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;

                            /*" -712- END-IF */
                        }


                        /*" -713- END-IF */
                    }


                    /*" -714- WHEN OTHER */
                    break;
                default:

                    /*" -715- DISPLAY 'R0120-00 - PROBLEMAS NO SELECT(AVISOCRE)' */
                    _.Display($"R0120-00 - PROBLEMAS NO SELECT(AVISOCRE)");

                    /*" -716- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -716- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R0120-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R0120_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -699- EXEC SQL SELECT VALUE(MAX(NUM_AVISO_CREDITO),0) INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = 104 AND AGE_AVISO = 7011 AND NUM_AVISO_CREDITO BETWEEN 902000000 AND 902099999 WITH UR END-EXEC */

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
            /*" -724- MOVE '0130' TO WNR-EXEC-SQL */
            _.Move("0130", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -725- MOVE 'R0130-00-BUSCAR-PRODUTOS' TO PARAGRAFO */
            _.Move("R0130-00-BUSCAR-PRODUTOS", AREA_DE_WORK.PARAGRAFO);

            /*" -727- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -728- MOVE 1 TO WS-LD-PRODUTOS */
            _.Move(1, AREA_DE_WORK.WS_LD_PRODUTOS);

            /*" -730- MOVE SPACES TO WS-FIM-PROD */
            _.Move("", AREA_DE_WORK.WS_FIM_PROD);

            /*" -732- PERFORM R0130_00_BUSCAR_PRODUTOS_DB_OPEN_1 */

            R0130_00_BUSCAR_PRODUTOS_DB_OPEN_1();

            /*" -735- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -736- DISPLAY 'R0130-PROBLEMAS AO ABRIR (C0-PRODUTOS) ' */
                _.Display($"R0130-PROBLEMAS AO ABRIR (C0-PRODUTOS) ");

                /*" -737- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -739- END-IF */
            }


            /*" -741- PERFORM R0131-00-FETCH-C0-PRODUTO */

            R0131_00_FETCH_C0_PRODUTO_SECTION();

            /*" -742- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -744- MOVE ZEROS TO PRODUTO-COD-PRODUTO */
            _.Move(0, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -749- PERFORM R0132-00-MOVE-DADOS UNTIL WS-FIM-PROD EQUAL 'S' */

            while (!(AREA_DE_WORK.WS_FIM_PROD == "S"))
            {

                R0132_00_MOVE_DADOS_SECTION();
            }

            /*" -751- MOVE 9999 TO PRODUTO-COD-PRODUTO */
            _.Move(9999, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -752- PERFORM R0132-00-MOVE-DADOS UNTIL WS-SUBS GREATER 8000. */

            while (!(AREA_DE_WORK.WS_SUBS > 8000))
            {

                R0132_00_MOVE_DADOS_SECTION();
            }

        }

        [StopWatch]
        /*" R0130-00-BUSCAR-PRODUTOS-DB-OPEN-1 */
        public void R0130_00_BUSCAR_PRODUTOS_DB_OPEN_1()
        {
            /*" -732- EXEC SQL OPEN C0-PRODUTOS END-EXEC */

            C0_PRODUTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0131-00-FETCH-C0-PRODUTO-SECTION */
        private void R0131_00_FETCH_C0_PRODUTO_SECTION()
        {
            /*" -760- MOVE '0131' TO WNR-EXEC-SQL */
            _.Move("0131", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -763- MOVE 'R0131-00-FETCH-C0-PRODUTO' TO PARAGRAFO */
            _.Move("R0131-00-FETCH-C0-PRODUTO", AREA_DE_WORK.PARAGRAFO);

            /*" -766- PERFORM R0131_00_FETCH_C0_PRODUTO_DB_FETCH_1 */

            R0131_00_FETCH_C0_PRODUTO_DB_FETCH_1();

            /*" -769-  EVALUATE SQLCODE  */

            /*" -770-  WHEN ZEROS  */

            /*" -770- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -771- CONTINUE */

                /*" -772-  WHEN +100  */

                /*" -772- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -772- PERFORM R0131_00_FETCH_C0_PRODUTO_DB_CLOSE_1 */

                R0131_00_FETCH_C0_PRODUTO_DB_CLOSE_1();

                /*" -776- MOVE 'S' TO WS-FIM-PROD */
                _.Move("S", AREA_DE_WORK.WS_FIM_PROD);

                /*" -777- IF WS-LD-PRODUTOS EQUAL ZEROS */

                if (AREA_DE_WORK.WS_LD_PRODUTOS == 00)
                {

                    /*" -778- DISPLAY '0131-TABELA DE PRODUTOS VAZIA, VERIFICAR' */
                    _.Display($"0131-TABELA DE PRODUTOS VAZIA, VERIFICAR");

                    /*" -779- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -780- END-IF */
                }


                /*" -781-  WHEN OTHER  */

                /*" -781- ELSE */
            }
            else
            {


                /*" -782- DISPLAY '0131-00 - PROBLEMAS FETCH (C0-PRODUTO)   ' */
                _.Display($"0131-00 - PROBLEMAS FETCH (C0-PRODUTO)   ");

                /*" -783- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -785-  END-EVALUATE  */

                /*" -785- END-IF */
            }


            /*" -787- ADD 1 TO WS-LD-PRODUTOS */
            AREA_DE_WORK.WS_LD_PRODUTOS.Value = AREA_DE_WORK.WS_LD_PRODUTOS + 1;

            /*" -788- IF WS-LD-PRODUTOS GREATER 8000 */

            if (AREA_DE_WORK.WS_LD_PRODUTOS > 8000)
            {

                /*" -788- PERFORM R0131_00_FETCH_C0_PRODUTO_DB_CLOSE_2 */

                R0131_00_FETCH_C0_PRODUTO_DB_CLOSE_2();

                /*" -790- DISPLAY '0131-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"0131-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -791- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -791- END-IF. */
            }


        }

        [StopWatch]
        /*" R0131-00-FETCH-C0-PRODUTO-DB-FETCH-1 */
        public void R0131_00_FETCH_C0_PRODUTO_DB_FETCH_1()
        {
            /*" -766- EXEC SQL FETCH C0-PRODUTOS INTO :PRODUTO-COD-PRODUTO END-EXEC */

            if (C0_PRODUTOS.Fetch())
            {
                _.Move(C0_PRODUTOS.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0131-00-FETCH-C0-PRODUTO-DB-CLOSE-1 */
        public void R0131_00_FETCH_C0_PRODUTO_DB_CLOSE_1()
        {
            /*" -772- EXEC SQL CLOSE C0-PRODUTOS END-EXEC */

            C0_PRODUTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0131_99_SAIDA*/

        [StopWatch]
        /*" R0131-00-FETCH-C0-PRODUTO-DB-CLOSE-2 */
        public void R0131_00_FETCH_C0_PRODUTO_DB_CLOSE_2()
        {
            /*" -788- EXEC SQL CLOSE C0-PRODUTOS END-EXEC */

            C0_PRODUTOS.Close();

        }

        [StopWatch]
        /*" R0132-00-MOVE-DADOS-SECTION */
        private void R0132_00_MOVE_DADOS_SECTION()
        {
            /*" -799- MOVE '0132' TO WNR-EXEC-SQL */
            _.Move("0132", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -802- MOVE 'R0132-00-MOVE-DADOS' TO PARAGRAFO */
            _.Move("R0132-00-MOVE-DADOS", AREA_DE_WORK.PARAGRAFO);

            /*" -804- MOVE PRODUTO-COD-PRODUTO TO WS-TABG-CODPRODU(WS-PRD) */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_CODPRODU);

            /*" -805- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -806- PERFORM R0135-00-MOVE-TIPO 03 TIMES */

            for (int i = 0; i < 3; i++)
            {

                R0135_00_MOVE_TIPO_SECTION();

            }

            /*" -807- SET WS-PRD UP BY 1 */
            WS_PRD.Value += 1;

            /*" -809- SET WS-SUBS TO WS-PRD */
            AREA_DE_WORK.WS_SUBS.Value = WS_PRD;

            /*" -811- IF PRODUTO-COD-PRODUTO NOT = 9999 */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO != 9999)
            {

                /*" -812- PERFORM R0131-00-FETCH-C0-PRODUTO */

                R0131_00_FETCH_C0_PRODUTO_SECTION();

                /*" -812- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/

        [StopWatch]
        /*" R0135-00-MOVE-TIPO-SECTION */
        private void R0135_00_MOVE_TIPO_SECTION()
        {
            /*" -820- MOVE '0135' TO WNR-EXEC-SQL */
            _.Move("0135", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -823- MOVE 'R0135-00-MOVE-TIPO' TO PARAGRAFO */
            _.Move("R0135-00-MOVE-TIPO", AREA_DE_WORK.PARAGRAFO);

            /*" -825- SET WS-SUBS1 TO WS-TIP */
            AREA_DE_WORK.WS_SUBS1.Value = WS_TIP;

            /*" -826- EVALUATE WS-SUBS1 */
            switch (AREA_DE_WORK.WS_SUBS1.Value)
            {

                /*" -828- WHEN 1 */
                case 1:

                    /*" -830- MOVE 'A' TO WS-TABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("A", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_TIPO);

                    /*" -832- WHEN 2 */
                    break;
                case 2:

                    /*" -835- MOVE 'S' TO WS-TABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("S", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_TIPO);

                    /*" -837- WHEN OTHER */
                    break;
                default:

                    /*" -839- MOVE 'D' TO WS-TABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("D", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_TIPO);

                    /*" -841- END-EVALUATE */
                    break;
            }


            /*" -842- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -844- PERFORM R0136-00-MOVE-SITUACAO 02 TIMES */

            for (int i = 0; i < 2; i++)
            {

                R0136_00_MOVE_SITUACAO_SECTION();

            }

            /*" -844- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0135_99_SAIDA*/

        [StopWatch]
        /*" R0136-00-MOVE-SITUACAO-SECTION */
        private void R0136_00_MOVE_SITUACAO_SECTION()
        {
            /*" -853- MOVE '0136' TO WNR-EXEC-SQL */
            _.Move("0136", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -856- MOVE 'R0136-00-MOVE-SITUACAO' TO PARAGRAFO */
            _.Move("R0136-00-MOVE-SITUACAO", AREA_DE_WORK.PARAGRAFO);

            /*" -864- MOVE ZEROS TO WS-TABG-QTDE (WS-PRD WS-TIP WS-SIT) WS-TABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WS-TABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WS-TABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WS-TABG-VLIOCC (WS-PRD WS-TIP WS-SIT) WS-TABG-VLDESCON(WS-PRD WS-TIP WS-SIT) */
            _.Move(0, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON);

            /*" -866- SET WS-SUBS2 TO WS-SIT */
            AREA_DE_WORK.WS_SUBS2.Value = WS_SIT;

            /*" -867- EVALUATE WS-SUBS2 */
            switch (AREA_DE_WORK.WS_SUBS2.Value)
            {

                /*" -869- WHEN 1 */
                case 1:

                    /*" -872- MOVE '0' TO WS-TABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                    _.Move("0", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_SITUACAO);

                    /*" -874- WHEN OTHER */
                    break;
                default:

                    /*" -876- MOVE '2' TO WS-TABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                    _.Move("2", AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_SITUACAO);

                    /*" -878- END-EVALUATE */
                    break;
            }


            /*" -878- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0136_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-LER-MOVIMENTO-SECTION */
        private void R0150_00_LER_MOVIMENTO_SECTION()
        {
            /*" -886- MOVE '0150' TO WNR-EXEC-SQL */
            _.Move("0150", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -887- MOVE 'R0150-00-LER-MOVIMENTO' TO PARAGRAFO */
            _.Move("R0150-00-LER-MOVIMENTO", AREA_DE_WORK.PARAGRAFO);

            /*" -889- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -890- READ CCDEMAIS AT END */
            try
            {
                CCDEMAIS.Read(() =>
                {

                    /*" -892- MOVE 'S' TO WS-FIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WS_FIM_MOVIMENTO);

                    /*" -893- GO TO R0150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/ //GOTO
                    return;

                    /*" -894- END-READ */
                });

                _.Move(CCDEMAIS.Value, REG_CCDEMAIS);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -896- ADD 1 TO WS-CONT-LIDOS */
            AREA_DE_WORK.WS_CONT_LIDOS.Value = AREA_DE_WORK.WS_CONT_LIDOS + 1;

            /*" -898- IF WS-CONT-LIDOS EQUAL 1 AND REG-TIPO-REGISTRO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONT_LIDOS == 1 && REG_CCDEMAIS.REG_TIPO_REGISTRO != 00)
            {

                /*" -899- DISPLAY '*** CB0124B *** FITA SEM HEADER' */
                _.Display($"*** CB0124B *** FITA SEM HEADER");

                /*" -900- MOVE ZEROS TO SQLCODE */
                _.Move(0, DB.SQLCODE);

                /*" -901- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -903- END-IF */
            }


            /*" -904-  EVALUATE REG-TIPO-REGISTRO  */

            /*" -905-  WHEN ZEROS  */

            /*" -905- IF   REG-TIPO-REGISTRO EQUALS  ZEROS */

            if (REG_CCDEMAIS.REG_TIPO_REGISTRO == 00)
            {

                /*" -906- MOVE REG-CCDEMAIS TO HEAD01-CIELO */
                _.Move(CCDEMAIS?.Value, HEAD01_CIELO);

                /*" -907- PERFORM R0155-00-VALIDA-HEADER */

                R0155_00_VALIDA_HEADER_SECTION();

                /*" -908- GO TO R0150-00-LER-MOVIMENTO */
                new Task(() => R0150_00_LER_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -909-  WHEN 001  */

                /*" -909- ELSE IF   REG-TIPO-REGISTRO EQUALS  001 */
            }
            else

            if (REG_CCDEMAIS.REG_TIPO_REGISTRO == 001)
            {

                /*" -910- MOVE REG-CCDEMAIS TO REG-CIELO */
                _.Move(CCDEMAIS?.Value, REG_CIELO);

                /*" -911-  WHEN 999  */

                /*" -911- ELSE IF   REG-TIPO-REGISTRO EQUALS  999 */
            }
            else

            if (REG_CCDEMAIS.REG_TIPO_REGISTRO == 999)
            {

                /*" -912- MOVE REG-CCDEMAIS TO TRAI01-CIELO */
                _.Move(CCDEMAIS?.Value, TRAI01_CIELO);

                /*" -913- IF TRAI01-TIPO-REGISTRO EQUAL 999 */

                if (TRAI01_CIELO.TRAI01_TIPO_REGISTRO == 999)
                {

                    /*" -914- DISPLAY '*** CB0124B *** TRAILLER PROCESSADO' */
                    _.Display($"*** CB0124B *** TRAILLER PROCESSADO");

                    /*" -915- GO TO R0150-00-LER-MOVIMENTO */
                    new Task(() => R0150_00_LER_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -916- END-IF */
                }


                /*" -917-  WHEN OTHER  */

                /*" -917- ELSE */
            }
            else
            {


                /*" -918- DISPLAY 'ERRO - TIPO DE REGISTRO NAO ESPERADO' */
                _.Display($"ERRO - TIPO DE REGISTRO NAO ESPERADO");

                /*" -919- DISPLAY 'REG-TIPO-REGISTRO = ' REG-TIPO-REGISTRO */
                _.Display($"REG-TIPO-REGISTRO = {REG_CCDEMAIS.REG_TIPO_REGISTRO}");

                /*" -920- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -920-  END-EVALUATE.  */

                /*" -920- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0155-00-VALIDA-HEADER-SECTION */
        private void R0155_00_VALIDA_HEADER_SECTION()
        {
            /*" -929- MOVE '0155' TO WNR-EXEC-SQL */
            _.Move("0155", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -930- MOVE 'R0155-00-VALIDA-HEADER' TO PARAGRAFO */
            _.Move("R0155-00-VALIDA-HEADER", AREA_DE_WORK.PARAGRAFO);

            /*" -932- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -933- IF HEAD01-TIPO-ARQUIVO NOT EQUAL 002 */

            if (HEAD01_CIELO.HEAD01_TIPO_ARQUIVO != 002)
            {

                /*" -934- DISPLAY '*** CB0124B *** MOVIMENTO NAO E DEMAIS PARCELAS' */
                _.Display($"*** CB0124B *** MOVIMENTO NAO E DEMAIS PARCELAS");

                /*" -935- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -939- END-IF */
            }


            /*" -940- IF HEAD01-NSAS >= 32767 */

            if (HEAD01_CIELO.HEAD01_NSAS >= 32767)
            {

                /*" -941- DISPLAY '*** CB0124B *** ESTOURO DE CAMPO SMALLINT' */
                _.Display($"*** CB0124B *** ESTOURO DE CAMPO SMALLINT");

                /*" -942- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -944- END-IF */
            }


            /*" -946- MOVE HEAD01-NSAS TO WS-NSAC */
            _.Move(HEAD01_CIELO.HEAD01_NSAS, AREA_DE_WORK.WS_NSAC);

            /*" -946- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0155_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-FINALIZA-SECTION */
        private void R0200_00_FINALIZA_SECTION()
        {
            /*" -954- MOVE '0200' TO WNR-EXEC-SQL */
            _.Move("0200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -955- MOVE 'R0200-00-FINALIZA' TO PARAGRAFO */
            _.Move("R0200-00-FINALIZA", AREA_DE_WORK.PARAGRAFO);

            /*" -957- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -958- DISPLAY ' ' */
            _.Display($" ");

            /*" -960- DISPLAY 'LIDOS MOVIMENTO ......................... ' WS-CONT-LIDOS */
            _.Display($"LIDOS MOVIMENTO ......................... {AREA_DE_WORK.WS_CONT_LIDOS}");

            /*" -961- DISPLAY ' ' */
            _.Display($" ");

            /*" -963- DISPLAY 'QTDE PRODUTOS............................ ' WS-LD-PRODUTOS */
            _.Display($"QTDE PRODUTOS............................ {AREA_DE_WORK.WS_LD_PRODUTOS}");

            /*" -964- DISPLAY ' ' */
            _.Display($" ");

            /*" -966- DISPLAY 'INSERIDOS MOVIMCOB....................... ' WS-IN-MOVIMCOB */
            _.Display($"INSERIDOS MOVIMCOB....................... {AREA_DE_WORK.WS_IN_MOVIMCOB}");

            /*" -968- DISPLAY 'INSERIDOS AVISOSCRE...................... ' WS-IN-AVISOCRE */
            _.Display($"INSERIDOS AVISOSCRE...................... {AREA_DE_WORK.WS_IN_AVISOCRE}");

            /*" -970- DISPLAY 'INSERIDOS AVISOSAL....................... ' WS-IN-AVISOSAL */
            _.Display($"INSERIDOS AVISOSAL....................... {AREA_DE_WORK.WS_IN_AVISOSAL}");

            /*" -971- DISPLAY ' ' */
            _.Display($" ");

            /*" -973- DISPLAY 'ATUALIZADOS PARC_VIDAZUL................. ' WS-UP-PARC-VIDAZUL */
            _.Display($"ATUALIZADOS PARC_VIDAZUL................. {AREA_DE_WORK.WS_UP_PARC_VIDAZUL}");

            /*" -975- DISPLAY 'ATUALIZADOS COBER_HIST_VIDAZUL........... ' WS-UP-COBER-HIS-VA */
            _.Display($"ATUALIZADOS COBER_HIST_VIDAZUL........... {AREA_DE_WORK.WS_UP_COBER_HIS_VA}");

            /*" -977- DISPLAY 'ATUALIZADOS HIST_LANC_VA................. ' WS-UP-HIS-LANC-CTA */
            _.Display($"ATUALIZADOS HIST_LANC_VA................. {AREA_DE_WORK.WS_UP_HIS_LANC_CTA}");

            /*" -978- DISPLAY ' ' */
            _.Display($" ");

            /*" -980- DISPLAY 'CAPTURA REALIZADA CORRETAMENTE........... ' WS-CONT-IDE3-CC */
            _.Display($"CAPTURA REALIZADA CORRETAMENTE........... {AREA_DE_WORK.WS_CONT_IDE3_CC}");

            /*" -982- DISPLAY 'CANCELAMENTO COM INSUCESSO............... ' WS-CONT-IDE3-CI */
            _.Display($"CANCELAMENTO COM INSUCESSO............... {AREA_DE_WORK.WS_CONT_IDE3_CI}");

            /*" -984- DISPLAY 'MOVIMENTO FINANCEIRO RECEBIDO............ ' WS-CONT-IDE4-OK */
            _.Display($"MOVIMENTO FINANCEIRO RECEBIDO............ {AREA_DE_WORK.WS_CONT_IDE4_OK}");

            /*" -986- DISPLAY 'FALHA NA CAPTURA......................... ' WS-CONT-IDERC */
            _.Display($"FALHA NA CAPTURA......................... {AREA_DE_WORK.WS_CONT_IDERC}");

            /*" -988- DISPLAY 'EM REGUA DE COBRANCA..................... ' WS-CONT-IDERC0102 */
            _.Display($"EM REGUA DE COBRANCA..................... {AREA_DE_WORK.WS_CONT_IDERC0102}");

            /*" -990- DISPLAY 'DEIXANDO A REGUA POR INADIMPLENCIA....... ' WS-CONT-IDERC03 */
            _.Display($"DEIXANDO A REGUA POR INADIMPLENCIA....... {AREA_DE_WORK.WS_CONT_IDERC03}");

            /*" -994- DISPLAY 'DEIXANDO A REGUA POR SUCESSO NA CAPTURA.. ' WS-CONT-IDE3CC */
            _.Display($"DEIXANDO A REGUA POR SUCESSO NA CAPTURA.. {AREA_DE_WORK.WS_CONT_IDE3CC}");

            /*" -996- DISPLAY 'SUCESSO NA PROVISAO DE AJUSTE............ ' WS-CONT-IDEPA-17 */
            _.Display($"SUCESSO NA PROVISAO DE AJUSTE............ {AREA_DE_WORK.WS_CONT_IDEPA_17}");

            /*" -998- DISPLAY 'SUCESSO AO REALIZAR DEVOLUCAO............ ' WS-CONT-IDE4-17 */
            _.Display($"SUCESSO AO REALIZAR DEVOLUCAO............ {AREA_DE_WORK.WS_CONT_IDE4_17}");

            /*" -1000- DISPLAY 'FALHA NO MOVIMENTO FINANCEIRO............ ' WS-CONT-IDE4-NOK */
            _.Display($"FALHA NO MOVIMENTO FINANCEIRO............ {AREA_DE_WORK.WS_CONT_IDE4_NOK}");

            /*" -1002- DISPLAY 'PARC. CANCELADAS S/ RETORNO - CHARGEBACK. ' WS-LD-PARC-SR */
            _.Display($"PARC. CANCELADAS S/ RETORNO - CHARGEBACK. {AREA_DE_WORK.WS_LD_PARC_SR}");

            /*" -1004- DISPLAY ' ' */
            _.Display($" ");

            /*" -1010- CLOSE CCDEMAIS */
            CCDEMAIS.Close();

            /*" -1010- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1012- DISPLAY 'CB0124B - PROCESSADO COM COMMIT' */
            _.Display($"CB0124B - PROCESSADO COM COMMIT");

            /*" -1014- DISPLAY 'CB0124B - PROCESSADO COM COMMIT' */
            _.Display($"CB0124B - PROCESSADO COM COMMIT");

            /*" -1015- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1016- DISPLAY ' ' */
            _.Display($" ");

            /*" -1017- DISPLAY 'CB0124B - FIM NORMAL' */
            _.Display($"CB0124B - FIM NORMAL");

            /*" -1019- DISPLAY ' ' */
            _.Display($" ");

            /*" -1019- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R3000-00-PROCESSA-MOVIMENTO-SECTION */
        private void R3000_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -1024- MOVE '3000' TO WNR-EXEC-SQL */
            _.Move("3000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1025- MOVE 'R3000-00-PROCESSA-MOVIMENTO' TO PARAGRAFO */
            _.Move("R3000-00-PROCESSA-MOVIMENTO", AREA_DE_WORK.PARAGRAFO);

            /*" -1026- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1028- DISPLAY 'MCIELO-NUM-PROPOSTA = ' MCIELO-NUM-PROPOSTA */
            _.Display($"MCIELO-NUM-PROPOSTA = {REG_CIELO.MCIELO_NUM_PROPOSTA}");

            /*" -1031- SET WS-NAO-DESPREZA TO TRUE */
            WS_DESPREZA_REGISTRO["WS_NAO_DESPREZA"] = true;

            /*" -1032- MOVE MCIELO-NUM-IDLG TO WS-COD-IDLG */
            _.Move(REG_CIELO.MCIELO_NUM_IDLG, AREA_DE_WORK.WS_COD_IDLG);

            /*" -1034- MOVE MCIELO-COD-RETORNO TO WS-COD-RETORNO */
            _.Move(REG_CIELO.MCIELO_COD_RETORNO, WS_COD_RETORNO);

            /*" -1036- PERFORM R3002-00-IDENTIFICA-MOVIMENTO */

            R3002_00_IDENTIFICA_MOVIMENTO_SECTION();

            /*" -1037- IF WS-NAO-DESPREZA */

            if (WS_DESPREZA_REGISTRO["WS_NAO_DESPREZA"])
            {

                /*" -1039- IF MCIELO-NUM-PROPOSTA EQUAL HISLANCT-NUM-CERTIFICADO AND MCIELO-NUM-PARCELA EQUAL HISLANCT-NUM-PARCELA */

                if (REG_CIELO.MCIELO_NUM_PROPOSTA == HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO && REG_CIELO.MCIELO_NUM_PARCELA == HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA)
                {

                    /*" -1040- CONTINUE */

                    /*" -1041- ELSE */
                }
                else
                {


                    /*" -1042- DISPLAY 'ERRO-PARC. DO ARQUIVO NAO CORRESPONDE AO IDLG' */
                    _.Display($"ERRO-PARC. DO ARQUIVO NAO CORRESPONDE AO IDLG");

                    /*" -1044- DISPLAY 'MCIELO-NUM-IDLG          = ' MCIELO-NUM-IDLG */
                    _.Display($"MCIELO-NUM-IDLG          = {REG_CIELO.MCIELO_NUM_IDLG}");

                    /*" -1046- DISPLAY 'MCIELO-NUM-PROPOSTA      = ' MCIELO-NUM-PROPOSTA */
                    _.Display($"MCIELO-NUM-PROPOSTA      = {REG_CIELO.MCIELO_NUM_PROPOSTA}");

                    /*" -1048- DISPLAY 'MCIELO-NUM-PARCELA       = ' MCIELO-NUM-PARCELA */
                    _.Display($"MCIELO-NUM-PARCELA       = {REG_CIELO.MCIELO_NUM_PARCELA}");

                    /*" -1050- DISPLAY 'HISLANCT-NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"HISLANCT-NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1052- DISPLAY 'HISLANCT-NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                    _.Display($"HISLANCT-NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1053- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1055- END-IF */
                }


                /*" -1056- IF WS-COD-CHARGE-BACK */

                if (WS_COD_RETORNO["WS_COD_CHARGE_BACK"])
                {

                    /*" -1057- PERFORM R3008-00-VERIF-PARC-CHARGE */

                    R3008_00_VERIF_PARC_CHARGE_SECTION();

                    /*" -1058- ELSE */
                }
                else
                {


                    /*" -1059- EVALUATE HISLANCT-TIPLANC */
                    switch (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC.Value.Trim())
                    {

                        /*" -1061- WHEN '1' */
                        case "1":

                            /*" -1062- PERFORM R3005-00-VERIFICAR-PARCELA */

                            R3005_00_VERIFICAR_PARCELA_SECTION();

                            /*" -1064- WHEN '2' */
                            break;
                        case "2":

                            /*" -1065- PERFORM R3007-00-VERIFICAR-CREDITO */

                            R3007_00_VERIFICAR_CREDITO_SECTION();

                            /*" -1066- WHEN OTHER */
                            break;
                        default:

                            /*" -1067- DISPLAY 'ERRO-TIPO LANC. NAO ESPERADO PARA IDLG' */
                            _.Display($"ERRO-TIPO LANC. NAO ESPERADO PARA IDLG");

                            /*" -1069- DISPLAY 'MCIELO-NUM-IDLG          = ' MCIELO-NUM-IDLG */
                            _.Display($"MCIELO-NUM-IDLG          = {REG_CIELO.MCIELO_NUM_IDLG}");

                            /*" -1071- DISPLAY 'MCIELO-NUM-PROPOSTA      = ' MCIELO-NUM-PROPOSTA */
                            _.Display($"MCIELO-NUM-PROPOSTA      = {REG_CIELO.MCIELO_NUM_PROPOSTA}");

                            /*" -1073- DISPLAY 'MCIELO-NUM-PARCELA       = ' MCIELO-NUM-PARCELA */
                            _.Display($"MCIELO-NUM-PARCELA       = {REG_CIELO.MCIELO_NUM_PARCELA}");

                            /*" -1075- DISPLAY 'HISLANCT-NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                            _.Display($"HISLANCT-NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                            /*" -1077- DISPLAY 'HISLANCT-NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                            _.Display($"HISLANCT-NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                            /*" -1078- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1079- END-EVALUATE */
                            break;
                    }


                    /*" -1081- END-IF */
                }


                /*" -1083- PERFORM R3050-00-TRATA-NUM-CARTAO */

                R3050_00_TRATA_NUM_CARTAO_SECTION();

                /*" -1085- EVALUATE MCIELO-COD-MOVIMENTO */
                switch (REG_CIELO.MCIELO_COD_MOVIMENTO.Value.Trim())
                {

                    /*" -1086- WHEN 'CI' */
                    case "CI":

                        /*" -1087- IF HISLANCT-TIPLANC EQUAL '2' */

                        if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC == "2")
                        {

                            /*" -1089- MOVE HISCONPA-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO */
                            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

                            /*" -1091- MOVE HISCONPA-NUM-PARCELA TO PARCEVID-NUM-PARCELA */
                            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

                            /*" -1094- MOVE '1' TO PARCEVID-SIT-REGISTRO */
                            _.Move("1", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

                            /*" -1096- PERFORM R3020-00-UPDATE-PARCEVID */

                            R3020_00_UPDATE_PARCEVID_SECTION();

                            /*" -1098- MOVE HISCONPA-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO */
                            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

                            /*" -1100- MOVE HISCONPA-NUM-PARCELA TO COBHISVI-NUM-PARCELA */
                            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

                            /*" -1103- MOVE '1' TO COBHISVI-SIT-REGISTRO */
                            _.Move("1", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                            /*" -1105- PERFORM R3040-00-UPDATE-COBHISVI */

                            R3040_00_UPDATE_COBHISVI_SECTION();

                            /*" -1106- MOVE '2' TO HISLANCT-SIT-REGISTRO */
                            _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                            /*" -1107- MOVE WS-NSAC TO HISLANCT-NSAC */
                            _.Move(AREA_DE_WORK.WS_NSAC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC);

                            /*" -1110- MOVE ZEROS TO HISLANCT-CODRET */
                            _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

                            /*" -1112- PERFORM R6010-00-UPDATE-HIST-LANC-CTA */

                            R6010_00_UPDATE_HIST_LANC_CTA_SECTION();

                            /*" -1113- ADD 1 TO WS-CONT-IDE3-CI */
                            AREA_DE_WORK.WS_CONT_IDE3_CI.Value = AREA_DE_WORK.WS_CONT_IDE3_CI + 1;

                            /*" -1114- ELSE */
                        }
                        else
                        {


                            /*" -1115- DISPLAY 'ERRO-CANCELAMENTO COM INSUCESSO' */
                            _.Display($"ERRO-CANCELAMENTO COM INSUCESSO");

                            /*" -1116- DISPLAY 'TIPLANC         = ' HISLANCT-TIPLANC */
                            _.Display($"TIPLANC         = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC}");

                            /*" -1118- DISPLAY 'NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                            _.Display($"NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                            /*" -1119- DISPLAY 'NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                            _.Display($"NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                            /*" -1120- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1122- END-IF */
                        }


                        /*" -1123- WHEN 'RC' */
                        break;
                    case "RC":

                        /*" -1124- IF HISLANCT-TIPLANC EQUAL '1' */

                        if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC == "1")
                        {

                            /*" -1125- IF MCIELO-MOTI-COMPEN EQUAL 05 */

                            if (REG_CIELO.MCIELO_MOTI_COMPEN == 05)
                            {

                                /*" -1126- PERFORM R3500-00-ATUALIZA-INADIMPLENTE */

                                R3500_00_ATUALIZA_INADIMPLENTE_SECTION();

                                /*" -1127- ADD 1 TO WS-CONT-IDERC03 */
                                AREA_DE_WORK.WS_CONT_IDERC03.Value = AREA_DE_WORK.WS_CONT_IDERC03 + 1;

                                /*" -1128- ELSE */
                            }
                            else
                            {


                                /*" -1129- PERFORM R3600-00-ATUAL-REGUA-COBRANCA */

                                R3600_00_ATUAL_REGUA_COBRANCA_SECTION();

                                /*" -1130- ADD 1 TO WS-CONT-IDERC0102 */
                                AREA_DE_WORK.WS_CONT_IDERC0102.Value = AREA_DE_WORK.WS_CONT_IDERC0102 + 1;

                                /*" -1131- END-IF */
                            }


                            /*" -1133- ELSE */
                        }
                        else
                        {


                            /*" -1134- IF HISLANCT-TIPLANC EQUAL '2' */

                            if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC == "2")
                            {

                                /*" -1135- MOVE '2' TO HISLANCT-SIT-REGISTRO */
                                _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                                /*" -1136- MOVE WS-NSAC TO HISLANCT-NSAC */
                                _.Move(AREA_DE_WORK.WS_NSAC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC);

                                /*" -1139- MOVE ZEROS TO HISLANCT-CODRET */
                                _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

                                /*" -1141- PERFORM R6010-00-UPDATE-HIST-LANC-CTA */

                                R6010_00_UPDATE_HIST_LANC_CTA_SECTION();

                                /*" -1142- DISPLAY 'ERRO-RECUSA CAPTURA DE DEVOLUCAO' */
                                _.Display($"ERRO-RECUSA CAPTURA DE DEVOLUCAO");

                                /*" -1143- DISPLAY 'NUM-IDLG     = ' MCIELO-NUM-IDLG */
                                _.Display($"NUM-IDLG     = {REG_CIELO.MCIELO_NUM_IDLG}");

                                /*" -1144- DISPLAY 'NUM-PROPOSTA = ' MCIELO-NUM-PROPOSTA */
                                _.Display($"NUM-PROPOSTA = {REG_CIELO.MCIELO_NUM_PROPOSTA}");

                                /*" -1145- DISPLAY 'NUM-PARCELA  = ' MCIELO-NUM-PARCELA */
                                _.Display($"NUM-PARCELA  = {REG_CIELO.MCIELO_NUM_PARCELA}");

                                /*" -1147- DISPLAY 'HISLANCT-NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                                _.Display($"HISLANCT-NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                                /*" -1149- DISPLAY 'HISLANCT-NUM-PARCELA = ' HISLANCT-NUM-PARCELA */
                                _.Display($"HISLANCT-NUM-PARCELA = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                                /*" -1150- ELSE */
                            }
                            else
                            {


                                /*" -1151- DISPLAY 'ERRO-RECUSA DE CAPTURA DE DEVOLUCAO ' */
                                _.Display($"ERRO-RECUSA DE CAPTURA DE DEVOLUCAO ");

                                /*" -1152- DISPLAY 'TIPLANC     = ' HISLANCT-TIPLANC */
                                _.Display($"TIPLANC     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC}");

                                /*" -1153- DISPLAY 'CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                                _.Display($"CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                                /*" -1154- DISPLAY 'NUM-PARCELA = ' HISLANCT-NUM-PARCELA */
                                _.Display($"NUM-PARCELA = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                                /*" -1155- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -1156- END-IF */
                            }


                            /*" -1157- END-IF */
                        }


                        /*" -1176- ADD 1 TO WS-CONT-IDERC */
                        AREA_DE_WORK.WS_CONT_IDERC.Value = AREA_DE_WORK.WS_CONT_IDERC + 1;

                        /*" -1178- WHEN '03' */
                        break;
                    case "03":

                        /*" -1179- IF MCIELO-COD-RETORNO EQUAL ' CC' */

                        if (REG_CIELO.MCIELO_COD_RETORNO == " CC")
                        {

                            /*" -1182- IF HISLANCT-TIPLANC EQUAL '1' */

                            if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC == "1")
                            {

                                /*" -1183- PERFORM R3100-00-VERIFICA-FATURAMENTO */

                                R3100_00_VERIFICA_FATURAMENTO_SECTION();

                                /*" -1184- IF WS-CONTA-CONTABIL > ZEROS */

                                if (AREA_DE_WORK.WS_CONTA_CONTABIL > 00)
                                {

                                    /*" -1185- DISPLAY 'ERRO-PARCELA JAH FATURADA' */
                                    _.Display($"ERRO-PARCELA JAH FATURADA");

                                    /*" -1187- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                                    /*" -1189- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                                    /*" -1191- DISPLAY 'OCORR_HISTORICO = ' HISCONPA-OCORR-HISTORICO */
                                    _.Display($"OCORR_HISTORICO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO}");

                                    /*" -1192- GO TO R9999-00-ROT-ERRO */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;

                                    /*" -1195- END-IF */
                                }


                                /*" -1196- PERFORM R3120-00-MONTA-HISCOMPA */

                                R3120_00_MONTA_HISCOMPA_SECTION();

                                /*" -1198- MOVE 201 TO HISCONPA-COD-OPERACAO */
                                _.Move(201, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                                /*" -1200- PERFORM R3150-00-INSERT-HISCONPA */

                                R3150_00_INSERT_HISCONPA_SECTION();

                                /*" -1202- MOVE HISCONPA-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO */
                                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

                                /*" -1203- MOVE HISCONPA-NUM-PARCELA TO PARCEVID-NUM-PARCELA */
                                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

                                /*" -1206- MOVE '1' TO PARCEVID-SIT-REGISTRO */
                                _.Move("1", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

                                /*" -1208- PERFORM R3020-00-UPDATE-PARCEVID */

                                R3020_00_UPDATE_PARCEVID_SECTION();

                                /*" -1210- MOVE HISCONPA-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO */
                                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

                                /*" -1211- MOVE HISCONPA-NUM-PARCELA TO COBHISVI-NUM-PARCELA */
                                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

                                /*" -1214- MOVE '1' TO COBHISVI-SIT-REGISTRO */
                                _.Move("1", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                                /*" -1216- PERFORM R3030-00-UPDATE-COBHISVI */

                                R3030_00_UPDATE_COBHISVI_SECTION();

                                /*" -1217- IF HISLANCT-SIT-REGISTRO EQUAL 'A' */

                                if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO == "A")
                                {

                                    /*" -1219- MOVE COBHISVI-NUM-CERTIFICADO TO HISLANCT-NUM-CERTIFICADO */
                                    _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

                                    /*" -1221- MOVE COBHISVI-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
                                    _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

                                    /*" -1223- MOVE '3' TO HISLANCT-SIT-REGISTRO */
                                    _.Move("3", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                                    /*" -1225- MOVE ZEROS TO HISLANCT-NSAC HISLANCT-CODRET */
                                    _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

                                    /*" -1229- MOVE -1 TO VIND-NSAC VIND-COD-RET */
                                    _.Move(-1, AREA_DE_WORK.VIND_NSAC, AREA_DE_WORK.VIND_COD_RET);

                                    /*" -1230- PERFORM R4040-UPDATE-HIST-LANC-CTA */

                                    R4040_UPDATE_HIST_LANC_CTA_SECTION();

                                    /*" -1231- ADD 1 TO WS-CONT-IDE3CC */
                                    AREA_DE_WORK.WS_CONT_IDE3CC.Value = AREA_DE_WORK.WS_CONT_IDE3CC + 1;

                                    /*" -1233- END-IF */
                                }


                                /*" -1235- ADD 1 TO WS-CONT-IDE3-CC */
                                AREA_DE_WORK.WS_CONT_IDE3_CC.Value = AREA_DE_WORK.WS_CONT_IDE3_CC + 1;

                                /*" -1236- ELSE */
                            }
                            else
                            {


                                /*" -1237- IF HISLANCT-TIPLANC EQUAL '2' */

                                if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC == "2")
                                {

                                    /*" -1239- MOVE HISCONPA-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

                                    /*" -1241- MOVE HISCONPA-NUM-PARCELA TO PARCEVID-NUM-PARCELA */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

                                    /*" -1244- MOVE '2' TO PARCEVID-SIT-REGISTRO */
                                    _.Move("2", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

                                    /*" -1246- PERFORM R3020-00-UPDATE-PARCEVID */

                                    R3020_00_UPDATE_PARCEVID_SECTION();

                                    /*" -1248- MOVE HISCONPA-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

                                    /*" -1250- MOVE HISCONPA-NUM-PARCELA TO COBHISVI-NUM-PARCELA */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

                                    /*" -1253- MOVE '2' TO COBHISVI-SIT-REGISTRO */
                                    _.Move("2", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                                    /*" -1255- PERFORM R3030-00-UPDATE-COBHISVI */

                                    R3030_00_UPDATE_COBHISVI_SECTION();

                                    /*" -1256- ADD 1 TO WS-CONT-IDE3-CC */
                                    AREA_DE_WORK.WS_CONT_IDE3_CC.Value = AREA_DE_WORK.WS_CONT_IDE3_CC + 1;

                                    /*" -1257- ELSE */
                                }
                                else
                                {


                                    /*" -1258- DISPLAY 'ERRO-CAPTURA DE LANC. NAO ESPERADO' */
                                    _.Display($"ERRO-CAPTURA DE LANC. NAO ESPERADO");

                                    /*" -1259- DISPLAY 'TIPLANC         = ' HISLANCT-TIPLANC */
                                    _.Display($"TIPLANC         = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC}");

                                    /*" -1261- DISPLAY 'NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                                    _.Display($"NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                                    /*" -1263- DISPLAY 'NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                                    _.Display($"NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                                    /*" -1264- GO TO R9999-00-ROT-ERRO */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;

                                    /*" -1265- END-IF */
                                }


                                /*" -1266- END-IF */
                            }


                            /*" -1267- ELSE */
                        }
                        else
                        {


                            /*" -1268- DISPLAY 'ERRO - COD. RETORNO NAO ESPERADO PARA 03' */
                            _.Display($"ERRO - COD. RETORNO NAO ESPERADO PARA 03");

                            /*" -1270- DISPLAY 'NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                            _.Display($"NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                            /*" -1272- DISPLAY 'NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                            _.Display($"NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                            /*" -1273- DISPLAY 'MCIELO-COD-RETORNO = ' MCIELO-COD-RETORNO */
                            _.Display($"MCIELO-COD-RETORNO = {REG_CIELO.MCIELO_COD_RETORNO}");

                            /*" -1274- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1276- END-IF */
                        }


                        /*" -1277- WHEN '04' */
                        break;
                    case "04":

                        /*" -1279- EVALUATE MCIELO-COD-RETORNO */
                        switch (REG_CIELO.MCIELO_COD_RETORNO.Value.Trim())
                        {

                            /*" -1280- WHEN '00' */
                            case "00":

                                /*" -1283- IF HISLANCT-TIPLANC EQUAL '1' */

                                if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC == "1")
                                {

                                    /*" -1286- PERFORM R4010-00-SELECT-PARCELAS */

                                    R4010_00_SELECT_PARCELAS_SECTION();

                                    /*" -1289- PERFORM R4020-00-PROCESSA-REGISTRO */

                                    R4020_00_PROCESSA_REGISTRO_SECTION();

                                    /*" -1291- PERFORM R4030-UPD-COBER-HIST-VIDAZUL */

                                    R4030_UPD_COBER_HIST_VIDAZUL_SECTION();

                                    /*" -1293- MOVE HISCONPA-NUM-CERTIFICADO TO HISLANCT-NUM-CERTIFICADO */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

                                    /*" -1295- MOVE HISCONPA-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

                                    /*" -1296- MOVE '1' TO HISLANCT-SIT-REGISTRO */
                                    _.Move("1", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                                    /*" -1297- MOVE WS-NSAC TO HISLANCT-NSAC */
                                    _.Move(AREA_DE_WORK.WS_NSAC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC);

                                    /*" -1302- MOVE ZEROS TO HISLANCT-CODRET VIND-NSAC VIND-COD-RET */
                                    _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET, AREA_DE_WORK.VIND_NSAC, AREA_DE_WORK.VIND_COD_RET);

                                    /*" -1305- PERFORM R4040-UPDATE-HIST-LANC-CTA */

                                    R4040_UPDATE_HIST_LANC_CTA_SECTION();

                                    /*" -1307- PERFORM R4200-00-PROCESSA-COBRANCA */

                                    R4200_00_PROCESSA_COBRANCA_SECTION();

                                    /*" -1309- ADD 1 TO WS-CONT-IDE4-OK */
                                    AREA_DE_WORK.WS_CONT_IDE4_OK.Value = AREA_DE_WORK.WS_CONT_IDE4_OK + 1;

                                    /*" -1310- ELSE */
                                }
                                else
                                {


                                    /*" -1313- IF (HISLANCT-TIPLANC EQUAL '2' AND (HISLANCT-CODCONV EQUAL 9020 OR 9022)) */

                                    if ((HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC == "2" && (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.In("9020", "9022"))))
                                    {

                                        /*" -1314- PERFORM R7200-00-TRATA-DEVOL-PARC */

                                        R7200_00_TRATA_DEVOL_PARC_SECTION();

                                        /*" -1315- ADD 1 TO WS-CONT-IDE4-OK */
                                        AREA_DE_WORK.WS_CONT_IDE4_OK.Value = AREA_DE_WORK.WS_CONT_IDE4_OK + 1;

                                        /*" -1316- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1317- DISPLAY 'ERRO - CANCEL. DE VENDA INESPERADO ' */
                                        _.Display($"ERRO - CANCEL. DE VENDA INESPERADO ");

                                        /*" -1318- DISPLAY 'TIPLANC         = ' HISLANCT-TIPLANC */
                                        _.Display($"TIPLANC         = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC}");

                                        /*" -1319- DISPLAY 'CODCONV         = ' HISLANCT-CODCONV */
                                        _.Display($"CODCONV         = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV}");

                                        /*" -1321- DISPLAY 'NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                                        _.Display($"NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                                        /*" -1323- DISPLAY 'NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                                        _.Display($"NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                                        /*" -1324- GO TO R9999-00-ROT-ERRO */

                                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                                        return;

                                        /*" -1325- END-IF */
                                    }


                                    /*" -1328- END-IF */
                                }


                                /*" -1329- WHEN '17' */
                                break;
                            case "17":

                                /*" -1332- IF (HISLANCT-TIPLANC EQUAL '2' AND (HISLANCT-CODCONV EQUAL 9020 OR 9022)) */

                                if ((HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC == "2" && (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.In("9020", "9022"))))
                                {

                                    /*" -1333- PERFORM R7200-00-TRATA-DEVOL-PARC */

                                    R7200_00_TRATA_DEVOL_PARC_SECTION();

                                    /*" -1334- ADD 1 TO WS-CONT-IDE4-17 */
                                    AREA_DE_WORK.WS_CONT_IDE4_17.Value = AREA_DE_WORK.WS_CONT_IDE4_17 + 1;

                                    /*" -1335- ELSE */
                                }
                                else
                                {


                                    /*" -1336- DISPLAY 'ERRO-CANCELAMENTO DE VENDA INESPERADO ' */
                                    _.Display($"ERRO-CANCELAMENTO DE VENDA INESPERADO ");

                                    /*" -1337- DISPLAY 'TIPLANC         = ' HISLANCT-TIPLANC */
                                    _.Display($"TIPLANC         = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC}");

                                    /*" -1338- DISPLAY 'CODCONV         = ' HISLANCT-CODCONV */
                                    _.Display($"CODCONV         = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV}");

                                    /*" -1340- DISPLAY 'NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                                    _.Display($"NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                                    /*" -1342- DISPLAY 'NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                                    _.Display($"NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                                    /*" -1343- GO TO R9999-00-ROT-ERRO */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;

                                    /*" -1346- END-IF */
                                }


                                /*" -1347- WHEN '28' */
                                break;
                            case "28":

                            /*" -1348- WHEN '29' */
                            case "29":

                                /*" -1349- WHEN '30' */
                                break;
                            case "30":

                            /*" -1350- WHEN '31' */
                            case "31":

                                /*" -1351- WHEN '32' */
                                break;
                            case "32":

                            /*" -1352- WHEN '33' */
                            case "33":

                                /*" -1353- WHEN '34' */
                                break;
                            case "34":

                            /*" -1354- WHEN '35' */
                            case "35":

                                /*" -1355- WHEN '36' */
                                break;
                            case "36":

                            /*" -1356- WHEN '37' */
                            case "37":

                                /*" -1357- WHEN '38' */
                                break;
                            case "38":

                            /*" -1358- WHEN '39' */
                            case "39":

                                /*" -1359- WHEN '40' */
                                break;
                            case "40":

                            /*" -1360- WHEN '52' */
                            case "52":

                                /*" -1361- WHEN '53' */
                                break;
                            case "53":

                            /*" -1362- WHEN '54' */
                            case "54":

                                /*" -1363- WHEN '55' */
                                break;
                            case "55":

                            /*" -1364- WHEN '56' */
                            case "56":

                                /*" -1365- WHEN '57' */
                                break;
                            case "57":

                            /*" -1366- WHEN '58' */
                            case "58":

                                /*" -1367- WHEN '59' */
                                break;
                            case "59":

                            /*" -1368- WHEN '60' */
                            case "60":

                                /*" -1369- WHEN '61' */
                                break;
                            case "61":

                            /*" -1370- WHEN '62' */
                            case "62":

                                /*" -1371- WHEN '63' */
                                break;
                            case "63":

                            /*" -1372- WHEN '64' */
                            case "64":

                                /*" -1373- WHEN '65' */
                                break;
                            case "65":

                            /*" -1374- WHEN '66' */
                            case "66":

                                /*" -1375- WHEN '67' */
                                break;
                            case "67":

                            /*" -1376- WHEN '68' */
                            case "68":

                                /*" -1377- WHEN '69' */
                                break;
                            case "69":

                            /*" -1378- WHEN '70' */
                            case "70":

                                /*" -1379- WHEN '71' */
                                break;
                            case "71":

                            /*" -1380- WHEN '72' */
                            case "72":

                                /*" -1381- WHEN '73' */
                                break;
                            case "73":

                            /*" -1382- WHEN '74' */
                            case "74":

                                /*" -1383- WHEN '75' */
                                break;
                            case "75":

                            /*" -1386- WHEN '76' */
                            case "76":

                                /*" -1388- PERFORM R7000-00-TRATA-RETORNO-CHARGE */

                                R7000_00_TRATA_RETORNO_CHARGE_SECTION();

                                /*" -1389- WHEN OTHER */
                                break;
                            default:

                                /*" -1390- DISPLAY 'ERRO - COD. RETORNO NAO ESPERADO PARA 04' */
                                _.Display($"ERRO - COD. RETORNO NAO ESPERADO PARA 04");

                                /*" -1392- DISPLAY 'NUM-CERTIFICADO       = ' HISLANCT-NUM-CERTIFICADO */
                                _.Display($"NUM-CERTIFICADO       = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                                /*" -1394- DISPLAY 'NUM-PARCELA           = ' HISLANCT-NUM-PARCELA */
                                _.Display($"NUM-PARCELA           = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                                /*" -1396- DISPLAY 'MCIELO-COD-MOVIMENTO  = ' MCIELO-COD-MOVIMENTO */
                                _.Display($"MCIELO-COD-MOVIMENTO  = {REG_CIELO.MCIELO_COD_MOVIMENTO}");

                                /*" -1398- DISPLAY 'MCIELO-COD-RETORNO    = ' MCIELO-COD-RETORNO */
                                _.Display($"MCIELO-COD-RETORNO    = {REG_CIELO.MCIELO_COD_RETORNO}");

                                /*" -1399- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -1401- END-EVALUATE */
                                break;
                        }


                        /*" -1402- WHEN 'PA' */
                        break;
                    case "PA":

                        /*" -1404- EVALUATE MCIELO-COD-RETORNO */
                        switch (REG_CIELO.MCIELO_COD_RETORNO.Value.Trim())
                        {

                            /*" -1406- WHEN ' 17' */
                            case " 17":

                                /*" -1407- IF HISLANCT-CODCONV EQUAL 9020 */

                                if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV == 9020)
                                {

                                    /*" -1412- IF HISLANCT-NUM-PARCELA EQUAL 1 AND PROPOVA-SIT-REGISTRO EQUAL '2' */

                                    if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA == 1 && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
                                    {

                                        /*" -1413- PERFORM R3120-00-MONTA-HISCOMPA */

                                        R3120_00_MONTA_HISCOMPA_SECTION();

                                        /*" -1414- MOVE 501 TO HISCONPA-COD-OPERACAO */
                                        _.Move(501, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                                        /*" -1416- PERFORM R3150-00-INSERT-HISCONPA */

                                        R3150_00_INSERT_HISCONPA_SECTION();

                                        /*" -1417- ADD 1 TO WS-CONT-IDEPA-17 */
                                        AREA_DE_WORK.WS_CONT_IDEPA_17.Value = AREA_DE_WORK.WS_CONT_IDEPA_17 + 1;

                                        /*" -1418- END-IF */
                                    }


                                    /*" -1420- END-IF */
                                }


                                /*" -1421- IF HISLANCT-CODCONV EQUAL 9022 */

                                if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV == 9022)
                                {

                                    /*" -1422- PERFORM R3100-00-VERIFICA-FATURAMENTO */

                                    R3100_00_VERIFICA_FATURAMENTO_SECTION();

                                    /*" -1424- MOVE HISCONPA-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

                                    /*" -1426- MOVE HISCONPA-NUM-PARCELA TO PARCEVID-NUM-PARCELA */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

                                    /*" -1429- MOVE '2' TO PARCEVID-SIT-REGISTRO */
                                    _.Move("2", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

                                    /*" -1431- PERFORM R3020-00-UPDATE-PARCEVID */

                                    R3020_00_UPDATE_PARCEVID_SECTION();

                                    /*" -1433- MOVE HISCONPA-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

                                    /*" -1435- MOVE HISCONPA-NUM-PARCELA TO COBHISVI-NUM-PARCELA */
                                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

                                    /*" -1438- MOVE '2' TO COBHISVI-SIT-REGISTRO */
                                    _.Move("2", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                                    /*" -1440- PERFORM R3030-00-UPDATE-COBHISVI */

                                    R3030_00_UPDATE_COBHISVI_SECTION();

                                    /*" -1441- ADD 1 TO WS-CONT-IDEPA-17 */
                                    AREA_DE_WORK.WS_CONT_IDEPA_17.Value = AREA_DE_WORK.WS_CONT_IDEPA_17 + 1;

                                    /*" -1442- END-IF */
                                }


                                /*" -1443- WHEN OTHER */
                                break;
                            default:

                                /*" -1444- DISPLAY 'ERRO - COD. RETORNO NAO ESPERADO PARA PA' */
                                _.Display($"ERRO - COD. RETORNO NAO ESPERADO PARA PA");

                                /*" -1446- DISPLAY 'NUM-CERTIFICADO       = ' HISLANCT-NUM-CERTIFICADO */
                                _.Display($"NUM-CERTIFICADO       = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                                /*" -1448- DISPLAY 'NUM-PARCELA           = ' HISLANCT-NUM-PARCELA */
                                _.Display($"NUM-PARCELA           = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                                /*" -1450- DISPLAY 'MCIELO-COD-MOVIMENTO  = ' MCIELO-COD-MOVIMENTO */
                                _.Display($"MCIELO-COD-MOVIMENTO  = {REG_CIELO.MCIELO_COD_MOVIMENTO}");

                                /*" -1452- DISPLAY 'MCIELO-COD-RETORNO    = ' MCIELO-COD-RETORNO */
                                _.Display($"MCIELO-COD-RETORNO    = {REG_CIELO.MCIELO_COD_RETORNO}");

                                /*" -1453- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -1454- END-EVALUATE */
                                break;
                        }


                        /*" -1455- WHEN OTHER */
                        break;
                    default:

                        /*" -1456- DISPLAY 'ERRO - CODIGO DE MOVIMENTO NAO ESPERADO' */
                        _.Display($"ERRO - CODIGO DE MOVIMENTO NAO ESPERADO");

                        /*" -1457- DISPLAY 'MCIELO-COD-MOVIMENTO = ' MCIELO-COD-MOVIMENTO */
                        _.Display($"MCIELO-COD-MOVIMENTO = {REG_CIELO.MCIELO_COD_MOVIMENTO}");

                        /*" -1458- DISPLAY 'MCIELO-NUM-PROPOSTA  = ' MCIELO-NUM-PROPOSTA */
                        _.Display($"MCIELO-NUM-PROPOSTA  = {REG_CIELO.MCIELO_NUM_PROPOSTA}");

                        /*" -1459- DISPLAY 'MCIELO-NUM-PARCELA   = ' MCIELO-NUM-PARCELA */
                        _.Display($"MCIELO-NUM-PARCELA   = {REG_CIELO.MCIELO_NUM_PARCELA}");

                        /*" -1460- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1461- END-EVALUATE */
                        break;
                }


                /*" -1464- END-IF */
            }


            /*" -1464- PERFORM R0150-00-LER-MOVIMENTO. */

            R0150_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3002-00-IDENTIFICA-MOVIMENTO-SECTION */
        private void R3002_00_IDENTIFICA_MOVIMENTO_SECTION()
        {
            /*" -1472- MOVE '3002' TO WNR-EXEC-SQL */
            _.Move("3002", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1473- MOVE 'R3002-00-IDENTIFICA-MOVIMENTO' TO PARAGRAFO */
            _.Move("R3002-00-IDENTIFICA-MOVIMENTO", AREA_DE_WORK.PARAGRAFO);

            /*" -1475- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1477- INITIALIZE DCLHIST-LANC-CTA */
            _.Initialize(
                HISLANCT.DCLHIST_LANC_CTA
            );

            /*" -1478- MOVE WS-IDLG-CONVENIO TO HISLANCT-CODCONV */
            _.Move(AREA_DE_WORK.WS_COD_IDLG_DEMAIS.WS_IDLG_CONVENIO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);

            /*" -1479- MOVE WS-IDLG-NSA TO HISLANCT-NSAS */
            _.Move(AREA_DE_WORK.WS_COD_IDLG_DEMAIS.WS_IDLG_NSA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);

            /*" -1481- MOVE WS-IDLG-NRSEQ TO HISLANCT-NSL */
            _.Move(AREA_DE_WORK.WS_COD_IDLG_DEMAIS.WS_IDLG_NRSEQ, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL);

            /*" -1497- PERFORM R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1 */

            R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1();

            /*" -1500- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1501- WHEN 0 */
                case 0:

                    /*" -1502- CONTINUE */

                    /*" -1503- WHEN 100 */
                    break;
                case 100:

                    /*" -1504- IF MCIELO-COD-MOVIMENTO EQUAL 'RC' */

                    if (REG_CIELO.MCIELO_COD_MOVIMENTO == "RC")
                    {

                        /*" -1505- SET WS-SIM-DESPREZA TO TRUE */
                        WS_DESPREZA_REGISTRO["WS_SIM_DESPREZA"] = true;

                        /*" -1506- ELSE */
                    }
                    else
                    {


                        /*" -1507- IF WS-COD-CHARGE-BACK */

                        if (WS_COD_RETORNO["WS_COD_CHARGE_BACK"])
                        {

                            /*" -1508- PERFORM R3003-00-IDENTIFICA-MOVIMENTO */

                            R3003_00_IDENTIFICA_MOVIMENTO_SECTION();

                            /*" -1509- ELSE */
                        }
                        else
                        {


                            /*" -1510- DISPLAY '3002-00-ERRO-PARC. COBRANCA NAO ENCONTRADA' */
                            _.Display($"3002-00-ERRO-PARC. COBRANCA NAO ENCONTRADA");

                            /*" -1511- DISPLAY 'CODCONV = ' HISLANCT-CODCONV */
                            _.Display($"CODCONV = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV}");

                            /*" -1512- DISPLAY 'NSAS    = ' HISLANCT-NSAS */
                            _.Display($"NSAS    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS}");

                            /*" -1513- DISPLAY 'NSL     = ' HISLANCT-NSL */
                            _.Display($"NSL     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL}");

                            /*" -1514- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1515- END-IF */
                        }


                        /*" -1516- END-IF */
                    }


                    /*" -1517- WHEN OTHER */
                    break;
                default:

                    /*" -1518- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -1519- DISPLAY 'R3002-00-ERRO-SELECT PARCELA HIST_LANC_CTA.' */
                    _.Display($"R3002-00-ERRO-SELECT PARCELA HIST_LANC_CTA.");

                    /*" -1520- DISPLAY 'CODCONV = ' HISLANCT-CODCONV */
                    _.Display($"CODCONV = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV}");

                    /*" -1521- DISPLAY 'NSAS    = ' HISLANCT-NSAS */
                    _.Display($"NSAS    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS}");

                    /*" -1522- DISPLAY 'NSL     = ' HISLANCT-NSL */
                    _.Display($"NSL     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL}");

                    /*" -1523- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1523- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R3002-00-IDENTIFICA-MOVIMENTO-DB-SELECT-1 */
        public void R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1()
        {
            /*" -1497- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.OCORR_HISTORICOCTA , A.SIT_REGISTRO , A.TIPLANC INTO :HISLANCT-NUM-CERTIFICADO , :HISLANCT-NUM-PARCELA , :HISLANCT-OCORR-HISTORICOCTA , :HISLANCT-SIT-REGISTRO , :HISLANCT-TIPLANC FROM SEGUROS.HIST_LANC_CTA A WHERE A.CODCONV = :HISLANCT-CODCONV AND A.NSAS = :HISLANCT-NSAS AND A.NSL = :HISLANCT-NSL WITH UR END-EXEC */

            var r3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1 = new R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1()
            {
                HISLANCT_CODCONV = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.ToString(),
                HISLANCT_NSAS = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS.ToString(),
                HISLANCT_NSL = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL.ToString(),
            };

            var executed_1 = R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1.Execute(r3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
                _.Move(executed_1.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(executed_1.HISLANCT_OCORR_HISTORICOCTA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA);
                _.Move(executed_1.HISLANCT_SIT_REGISTRO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);
                _.Move(executed_1.HISLANCT_TIPLANC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3002_99_SAIDA*/

        [StopWatch]
        /*" R3003-00-IDENTIFICA-MOVIMENTO-SECTION */
        private void R3003_00_IDENTIFICA_MOVIMENTO_SECTION()
        {
            /*" -1533- MOVE '3003' TO WNR-EXEC-SQL */
            _.Move("3003", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1534- MOVE 'R3003-00-IDENTIFICA-MOVIMENTO' TO PARAGRAFO */
            _.Move("R3003-00-IDENTIFICA-MOVIMENTO", AREA_DE_WORK.PARAGRAFO);

            /*" -1536- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1538- INITIALIZE DCLHIST-LANC-CTA */
            _.Initialize(
                HISLANCT.DCLHIST_LANC_CTA
            );

            /*" -1539- MOVE WS-NUM-PROPOSTA TO HISLANCT-NUM-CERTIFICADO */
            _.Move(AREA_DE_WORK.WS_COD_IDLG_ADESAO.WS_NUM_PROPOSTA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -1541- MOVE MCIELO-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -1561- PERFORM R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1 */

            R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1();

            /*" -1564- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1565- WHEN 0 */
                case 0:

                    /*" -1566- CONTINUE */

                    /*" -1567- WHEN 100 */
                    break;
                case 100:

                    /*" -1568- DISPLAY '3003-00-ERRO-PARCELA DE COBRANCA NAO ENCONTRADA.' */
                    _.Display($"3003-00-ERRO-PARCELA DE COBRANCA NAO ENCONTRADA.");

                    /*" -1569- DISPLAY 'NUM_CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1570- DISPLAY 'NUM_PARCELA     = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1571- DISPLAY 'WS-COD-IDLG     = ' WS-COD-IDLG */
                    _.Display($"WS-COD-IDLG     = {AREA_DE_WORK.WS_COD_IDLG}");

                    /*" -1572- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1573- WHEN OTHER */
                    break;
                default:

                    /*" -1574- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -1575- DISPLAY 'R3003-00-ERRO-SELECT PARCELA HIST_LANC_CTA.' */
                    _.Display($"R3003-00-ERRO-SELECT PARCELA HIST_LANC_CTA.");

                    /*" -1576- DISPLAY 'NUM_CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1577- DISPLAY 'NUM_PARCELA     = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1578- DISPLAY 'WS-COD-IDLG     = ' WS-COD-IDLG */
                    _.Display($"WS-COD-IDLG     = {AREA_DE_WORK.WS_COD_IDLG}");

                    /*" -1579- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1579- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R3003-00-IDENTIFICA-MOVIMENTO-DB-SELECT-1 */
        public void R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1()
        {
            /*" -1561- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.OCORR_HISTORICOCTA , A.SIT_REGISTRO , A.TIPLANC INTO :HISLANCT-NUM-CERTIFICADO , :HISLANCT-NUM-PARCELA , :HISLANCT-OCORR-HISTORICOCTA , :HISLANCT-SIT-REGISTRO , :HISLANCT-TIPLANC FROM SEGUROS.HIST_LANC_CTA A WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA AND A.OCORR_HISTORICOCTA = (SELECT MAX(B.OCORR_HISTORICOCTA) FROM SEGUROS.HIST_LANC_CTA B WHERE B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.NUM_PARCELA = A.NUM_PARCELA) WITH UR END-EXEC */

            var r3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1 = new R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1.Execute(r3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
                _.Move(executed_1.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(executed_1.HISLANCT_OCORR_HISTORICOCTA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA);
                _.Move(executed_1.HISLANCT_SIT_REGISTRO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);
                _.Move(executed_1.HISLANCT_TIPLANC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3003_99_SAIDA*/

        [StopWatch]
        /*" R3005-00-VERIFICAR-PARCELA-SECTION */
        private void R3005_00_VERIFICAR_PARCELA_SECTION()
        {
            /*" -1587- MOVE '3005' TO WNR-EXEC-SQL */
            _.Move("3005", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1588- MOVE 'R3005-00-VERIFICAR-PARCELA' TO PARAGRAFO */
            _.Move("R3005-00-VERIFICAR-PARCELA", AREA_DE_WORK.PARAGRAFO);

            /*" -1593- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1627- PERFORM R3005_00_VERIFICAR_PARCELA_DB_SELECT_1 */

            R3005_00_VERIFICAR_PARCELA_DB_SELECT_1();

            /*" -1630- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1631- WHEN 0 */
                case 0:

                    /*" -1632- CONTINUE */

                    /*" -1633- WHEN 100 */
                    break;
                case 100:

                    /*" -1634- IF MCIELO-COD-MOVIMENTO EQUAL 'RC' OR '03' OR '04' */

                    if (REG_CIELO.MCIELO_COD_MOVIMENTO.In("RC", "03", "04"))
                    {

                        /*" -1635- PERFORM R3006-00-VERIFICAR-PARCELA */

                        R3006_00_VERIFICAR_PARCELA_SECTION();

                        /*" -1636- ELSE */
                    }
                    else
                    {


                        /*" -1637- DISPLAY '3005-00-ERRO-PARCELA NAO ENCONTRADA.' */
                        _.Display($"3005-00-ERRO-PARCELA NAO ENCONTRADA.");

                        /*" -1638- DISPLAY 'NUM_CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                        _.Display($"NUM_CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                        /*" -1639- DISPLAY 'NUM_PARCELA     = ' HISLANCT-NUM-PARCELA */
                        _.Display($"NUM_PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                        /*" -1640- DISPLAY 'COD-MOVIMENTO   = ' MCIELO-COD-MOVIMENTO */
                        _.Display($"COD-MOVIMENTO   = {REG_CIELO.MCIELO_COD_MOVIMENTO}");

                        /*" -1641- DISPLAY 'COD-RETORNO     = ' MCIELO-COD-RETORNO */
                        _.Display($"COD-RETORNO     = {REG_CIELO.MCIELO_COD_RETORNO}");

                        /*" -1642- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1643- END-IF */
                    }


                    /*" -1644- WHEN OTHER */
                    break;
                default:

                    /*" -1645- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -1646- DISPLAY 'R3005-00-ERRO-SELECT PARCELA HIST_LANC_CTA.' */
                    _.Display($"R3005-00-ERRO-SELECT PARCELA HIST_LANC_CTA.");

                    /*" -1647- DISPLAY 'NUM_CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1648- DISPLAY 'NUM_PARCELA     = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1649- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1649- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R3005-00-VERIFICAR-PARCELA-DB-SELECT-1 */
        public void R3005_00_VERIFICAR_PARCELA_DB_SELECT_1()
        {
            /*" -1627- EXEC SQL SELECT B.COD_FONTE , B.NUM_APOLICE , B.COD_SUBGRUPO , C.PREMIO_VG , C.PREMIO_AP , DATE(C.TIMESTAMP) , D.NUM_TITULO , D.OCORR_HISTORICO INTO :PROPOVA-COD-FONTE , :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PARCEVID-PREMIO-VG , :PARCEVID-PREMIO-AP , :WS-DATA-GERACAO-PARCELA , :COBHISVI-NUM-TITULO , :COBHISVI-OCORR-HISTORICO FROM SEGUROS.HIST_LANC_CTA A , SEGUROS.PROPOSTAS_VA B , SEGUROS.PARCELAS_VIDAZUL C , SEGUROS.COBER_HIST_VIDAZUL D WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA AND A.OCORR_HISTORICOCTA = :HISLANCT-OCORR-HISTORICOCTA AND A.SIT_REGISTRO IN ( '3' , 'A' ) AND A.TIPLANC = '1' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND B.SIT_REGISTRO IN ( '3' , '6' , '4' ) AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND A.NUM_PARCELA = C.NUM_PARCELA AND A.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND A.NUM_PARCELA = D.NUM_PARCELA AND A.CODCONV = 9020 WITH UR END-EXEC */

            var r3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 = new R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1()
            {
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1.Execute(r3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_PREMIO_AP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);
                _.Move(executed_1.WS_DATA_GERACAO_PARCELA, AREA_DE_WORK.WS_DATA_GERACAO_PARCELA);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.COBHISVI_OCORR_HISTORICO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3005_99_SAIDA*/

        [StopWatch]
        /*" R3006-00-VERIFICAR-PARCELA-SECTION */
        private void R3006_00_VERIFICAR_PARCELA_SECTION()
        {
            /*" -1657- MOVE '3006' TO WNR-EXEC-SQL */
            _.Move("3006", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1658- MOVE 'R3006-00-VERIFICAR-PARCELA' TO PARAGRAFO */
            _.Move("R3006-00-VERIFICAR-PARCELA", AREA_DE_WORK.PARAGRAFO);

            /*" -1660- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1694- PERFORM R3006_00_VERIFICAR_PARCELA_DB_SELECT_1 */

            R3006_00_VERIFICAR_PARCELA_DB_SELECT_1();

            /*" -1697- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1698- WHEN 0 */
                case 0:

                    /*" -1699- CONTINUE */

                    /*" -1700- WHEN 100 */
                    break;
                case 100:

                    /*" -1701- DISPLAY '3006-00-ERRO-PARCELA DE COBRANCA NAO ENCONTRADA.' */
                    _.Display($"3006-00-ERRO-PARCELA DE COBRANCA NAO ENCONTRADA.");

                    /*" -1702- DISPLAY 'NUM_CERTIFICADO    = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1703- DISPLAY 'NUM_PARCELA        = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA        = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1704- DISPLAY 'OCORR_HISTORICOCTA = ' HISLANCT-OCORR-HISTORICOCTA */
                    _.Display($"OCORR_HISTORICOCTA = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}");

                    /*" -1705- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1706- WHEN OTHER */
                    break;
                default:

                    /*" -1707- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -1708- DISPLAY 'R3006-00-ERRO-SELECT PARCELA HIST_LANC_CTA.' */
                    _.Display($"R3006-00-ERRO-SELECT PARCELA HIST_LANC_CTA.");

                    /*" -1709- DISPLAY 'NUM_CERTIFICADO    = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1710- DISPLAY 'NUM_PARCELA        = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA        = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1711- DISPLAY 'OCORR_HISTORICOCTA = ' HISLANCT-OCORR-HISTORICOCTA */
                    _.Display($"OCORR_HISTORICOCTA = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}");

                    /*" -1712- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1714- END-EVALUATE */
                    break;
            }


            /*" -1716- IF MCIELO-COD-MOVIMENTO EQUAL '03' */

            if (REG_CIELO.MCIELO_COD_MOVIMENTO == "03")
            {

                /*" -1724- PERFORM R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1 */

                R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1();

                /*" -1727-  EVALUATE SQLCODE  */

                /*" -1728-  WHEN ZEROS  */

                /*" -1729-  WHEN +100  */

                /*" -1729- IF   SQLCODE EQUALS ZEROS OR  +100 */

                if (DB.SQLCODE.In("00", "+100"))
                {

                    /*" -1730- CONTINUE */

                    /*" -1731-  WHEN OTHER  */

                    /*" -1731- ELSE */
                }
                else
                {


                    /*" -1732- DISPLAY '3006 - PROBLEMAS  UPDATE HIST_LANC_CTA ' */
                    _.Display($"3006 - PROBLEMAS  UPDATE HIST_LANC_CTA ");

                    /*" -1734- DISPLAY 'NUM-CERTIFICADO    => ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM-CERTIFICADO    => {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1735- DISPLAY 'NUM-PARCELA        => ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM-PARCELA        => {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1737- DISPLAY 'OCORR-HISTORICOCTA => ' HISLANCT-OCORR-HISTORICOCTA */
                    _.Display($"OCORR-HISTORICOCTA => {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}");

                    /*" -1738- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1739-  END-EVALUATE  */

                    /*" -1739- END-IF */
                }


                /*" -1741- END-IF */
            }


            /*" -1741- . */

        }

        [StopWatch]
        /*" R3006-00-VERIFICAR-PARCELA-DB-SELECT-1 */
        public void R3006_00_VERIFICAR_PARCELA_DB_SELECT_1()
        {
            /*" -1694- EXEC SQL SELECT B.COD_FONTE , B.NUM_APOLICE , B.COD_SUBGRUPO , C.PREMIO_VG , C.PREMIO_AP , DATE(C.TIMESTAMP) , D.NUM_TITULO , D.OCORR_HISTORICO INTO :PROPOVA-COD-FONTE , :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PARCEVID-PREMIO-VG , :PARCEVID-PREMIO-AP , :WS-DATA-GERACAO-PARCELA , :COBHISVI-NUM-TITULO , :COBHISVI-OCORR-HISTORICO FROM SEGUROS.HIST_LANC_CTA A , SEGUROS.PROPOSTAS_VA B , SEGUROS.PARCELAS_VIDAZUL C , SEGUROS.COBER_HIST_VIDAZUL D WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA AND A.OCORR_HISTORICOCTA = :HISLANCT-OCORR-HISTORICOCTA AND A.SIT_REGISTRO IN ( '3' , 'A' , ' ' , '2' ) AND A.TIPLANC = '1' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND B.SIT_REGISTRO IN ( '3' , '6' , '4' ) AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND A.NUM_PARCELA = C.NUM_PARCELA AND A.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND A.NUM_PARCELA = D.NUM_PARCELA AND A.CODCONV = 9020 WITH UR END-EXEC */

            var r3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 = new R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1()
            {
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1.Execute(r3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_PREMIO_AP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);
                _.Move(executed_1.WS_DATA_GERACAO_PARCELA, AREA_DE_WORK.WS_DATA_GERACAO_PARCELA);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.COBHISVI_OCORR_HISTORICO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" R3006-00-VERIFICAR-PARCELA-DB-UPDATE-1 */
        public void R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1()
        {
            /*" -1724- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = '3' , COD_USUARIO = 'CB0124B' WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND NUM_PARCELA = :HISLANCT-NUM-PARCELA AND OCORR_HISTORICOCTA = :HISLANCT-OCORR-HISTORICOCTA AND SIT_REGISTRO = ' ' END-EXEC */

            var r3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1 = new R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1()
            {
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1.Execute(r3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3006_99_SAIDA*/

        [StopWatch]
        /*" R3007-00-VERIFICAR-CREDITO-SECTION */
        private void R3007_00_VERIFICAR_CREDITO_SECTION()
        {
            /*" -1749- MOVE '3007' TO WNR-EXEC-SQL */
            _.Move("3007", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1750- MOVE 'R3007-00-VERIFICAR-CREDITO' TO PARAGRAFO */
            _.Move("R3007-00-VERIFICAR-CREDITO", AREA_DE_WORK.PARAGRAFO);

            /*" -1752- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1787- PERFORM R3007_00_VERIFICAR_CREDITO_DB_SELECT_1 */

            R3007_00_VERIFICAR_CREDITO_DB_SELECT_1();

            /*" -1790- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1791- WHEN 0 */
                case 0:

                    /*" -1792- CONTINUE */

                    /*" -1793- WHEN 100 */
                    break;
                case 100:

                    /*" -1794- DISPLAY 'R3007-00-ERRO-PARCELA DE CREDITO NAO ENCONTRADA.' */
                    _.Display($"R3007-00-ERRO-PARCELA DE CREDITO NAO ENCONTRADA.");

                    /*" -1795- DISPLAY 'NUM_CERTIFICADO    = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1796- DISPLAY 'NUM_PARCELA        = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA        = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1797- DISPLAY 'OCORR_HISTORICOCTA = ' HISLANCT-OCORR-HISTORICOCTA */
                    _.Display($"OCORR_HISTORICOCTA = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}");

                    /*" -1798- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1799- WHEN OTHER */
                    break;
                default:

                    /*" -1800- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -1801- DISPLAY 'R3007-00-ERRO-SELECT PARCELA HIST_LANC_CTA.' */
                    _.Display($"R3007-00-ERRO-SELECT PARCELA HIST_LANC_CTA.");

                    /*" -1802- DISPLAY 'NUM_CERTIFICADO    = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1803- DISPLAY 'NUM_PARCELA        = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA        = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1804- DISPLAY 'OCORR_HISTORICOCTA = ' HISLANCT-OCORR-HISTORICOCTA */
                    _.Display($"OCORR_HISTORICOCTA = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}");

                    /*" -1805- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1805- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R3007-00-VERIFICAR-CREDITO-DB-SELECT-1 */
        public void R3007_00_VERIFICAR_CREDITO_DB_SELECT_1()
        {
            /*" -1787- EXEC SQL SELECT B.COD_FONTE , B.NUM_APOLICE , B.COD_SUBGRUPO , B.SIT_REGISTRO , C.PREMIO_VG , C.PREMIO_AP , DATE(C.TIMESTAMP) , D.NUM_TITULO , D.OCORR_HISTORICO INTO :PROPOVA-COD-FONTE , :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-SIT-REGISTRO , :PARCEVID-PREMIO-VG , :PARCEVID-PREMIO-AP , :WS-DATA-GERACAO-PARCELA , :COBHISVI-NUM-TITULO , :COBHISVI-OCORR-HISTORICO FROM SEGUROS.HIST_LANC_CTA A , SEGUROS.PROPOSTAS_VA B , SEGUROS.PARCELAS_VIDAZUL C , SEGUROS.COBER_HIST_VIDAZUL D WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA AND A.OCORR_HISTORICOCTA = :HISLANCT-OCORR-HISTORICOCTA AND A.SIT_REGISTRO = '3' AND A.TIPLANC = '2' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND B.SIT_REGISTRO IN ( '3' , '6' , '2' , '4' ) AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND A.NUM_PARCELA = C.NUM_PARCELA AND A.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND A.NUM_PARCELA = D.NUM_PARCELA WITH UR END-EXEC */

            var r3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1 = new R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1()
            {
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1.Execute(r3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_PREMIO_AP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);
                _.Move(executed_1.WS_DATA_GERACAO_PARCELA, AREA_DE_WORK.WS_DATA_GERACAO_PARCELA);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.COBHISVI_OCORR_HISTORICO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3007_99_SAIDA*/

        [StopWatch]
        /*" R3008-00-VERIF-PARC-CHARGE-SECTION */
        private void R3008_00_VERIF_PARC_CHARGE_SECTION()
        {
            /*" -1813- MOVE '3008' TO WNR-EXEC-SQL */
            _.Move("3008", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1814- MOVE 'R3008-00-VERIF-PARC-CHARGE' TO PARAGRAFO */
            _.Move("R3008-00-VERIF-PARC-CHARGE", AREA_DE_WORK.PARAGRAFO);

            /*" -1816- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1849- PERFORM R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1 */

            R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1();

            /*" -1852- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1853- WHEN 0 */
                case 0:

                    /*" -1854- CONTINUE */

                    /*" -1855- WHEN 100 */
                    break;
                case 100:

                    /*" -1856- DISPLAY 'R3008-00-ERRO-PARCELA DE CREDITO NAO ENCONTRADA.' */
                    _.Display($"R3008-00-ERRO-PARCELA DE CREDITO NAO ENCONTRADA.");

                    /*" -1857- DISPLAY 'NUM_CERTIFICADO    = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1858- DISPLAY 'NUM_PARCELA        = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA        = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1860- DISPLAY 'OCORR_HISTORICOCTA = ' HISLANCT-OCORR-HISTORICOCTA */
                    _.Display($"OCORR_HISTORICOCTA = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}");

                    /*" -1861- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1862- WHEN OTHER */
                    break;
                default:

                    /*" -1863- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -1864- DISPLAY 'R3008-00-ERRO-SELECT PARCELA HIST_LANC_CTA.' */
                    _.Display($"R3008-00-ERRO-SELECT PARCELA HIST_LANC_CTA.");

                    /*" -1865- DISPLAY 'NUM_CERTIFICADO    = ' HISLANCT-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                    /*" -1866- DISPLAY 'NUM_PARCELA        = ' HISLANCT-NUM-PARCELA */
                    _.Display($"NUM_PARCELA        = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                    /*" -1868- DISPLAY 'OCORR_HISTORICOCTA = ' HISLANCT-OCORR-HISTORICOCTA */
                    _.Display($"OCORR_HISTORICOCTA = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}");

                    /*" -1869- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1869- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R3008-00-VERIF-PARC-CHARGE-DB-SELECT-1 */
        public void R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1()
        {
            /*" -1849- EXEC SQL SELECT B.COD_FONTE , B.NUM_APOLICE , B.COD_SUBGRUPO , B.SIT_REGISTRO , C.PREMIO_VG , C.PREMIO_AP , DATE(C.TIMESTAMP) , D.NUM_TITULO , D.OCORR_HISTORICO INTO :PROPOVA-COD-FONTE , :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-SIT-REGISTRO , :PARCEVID-PREMIO-VG , :PARCEVID-PREMIO-AP , :WS-DATA-GERACAO-PARCELA , :COBHISVI-NUM-TITULO , :COBHISVI-OCORR-HISTORICO FROM SEGUROS.HIST_LANC_CTA A , SEGUROS.PROPOSTAS_VA B , SEGUROS.PARCELAS_VIDAZUL C , SEGUROS.COBER_HIST_VIDAZUL D WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA AND A.OCORR_HISTORICOCTA = :HISLANCT-OCORR-HISTORICOCTA AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND B.SIT_REGISTRO IN ( '3' , '6' , '2' , '4' ) AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND A.NUM_PARCELA = C.NUM_PARCELA AND A.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND A.NUM_PARCELA = D.NUM_PARCELA WITH UR END-EXEC */

            var r3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1 = new R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1()
            {
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1.Execute(r3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_PREMIO_AP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);
                _.Move(executed_1.WS_DATA_GERACAO_PARCELA, AREA_DE_WORK.WS_DATA_GERACAO_PARCELA);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.COBHISVI_OCORR_HISTORICO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3008_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-UPDATE-PARCEVID-SECTION */
        private void R3020_00_UPDATE_PARCEVID_SECTION()
        {
            /*" -1878- MOVE '3020' TO WNR-EXEC-SQL */
            _.Move("3020", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1879- MOVE 'R3020-00-UPDATE-PARCEVID' TO PARAGRAFO */
            _.Move("R3020-00-UPDATE-PARCEVID", AREA_DE_WORK.PARAGRAFO);

            /*" -1881- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1887- PERFORM R3020_00_UPDATE_PARCEVID_DB_UPDATE_1 */

            R3020_00_UPDATE_PARCEVID_DB_UPDATE_1();

            /*" -1890- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1891- DISPLAY '3020 - PROBLEMAS  UPDATE PARCELAS_VIDAZUL' */
                _.Display($"3020 - PROBLEMAS  UPDATE PARCELAS_VIDAZUL");

                /*" -1892- DISPLAY 'NUM-CERTIFICADO => ' PARCEVID-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO}");

                /*" -1893- DISPLAY 'NUM-PARCELA     => ' PARCEVID-NUM-PARCELA */
                _.Display($"NUM-PARCELA     => {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}");

                /*" -1894- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1896- END-IF */
            }


            /*" -1896- ADD 1 TO WS-UP-PARC-VIDAZUL. */
            AREA_DE_WORK.WS_UP_PARC_VIDAZUL.Value = AREA_DE_WORK.WS_UP_PARC_VIDAZUL + 1;

        }

        [StopWatch]
        /*" R3020-00-UPDATE-PARCEVID-DB-UPDATE-1 */
        public void R3020_00_UPDATE_PARCEVID_DB_UPDATE_1()
        {
            /*" -1887- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET SIT_REGISTRO = :PARCEVID-SIT-REGISTRO WHERE NUM_CERTIFICADO = :PARCEVID-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA END-EXEC */

            var r3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1 = new R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1()
            {
                PARCEVID_SIT_REGISTRO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO.ToString(),
                PARCEVID_NUM_CERTIFICADO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
            };

            R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1.Execute(r3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3030-00-UPDATE-COBHISVI-SECTION */
        private void R3030_00_UPDATE_COBHISVI_SECTION()
        {
            /*" -1904- MOVE '3030' TO WNR-EXEC-SQL */
            _.Move("3030", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1905- MOVE 'R3030-00-UPDATE-COBHISVI' TO PARAGRAFO */
            _.Move("R3030-00-UPDATE-COBHISVI", AREA_DE_WORK.PARAGRAFO);

            /*" -1907- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1914- PERFORM R3030_00_UPDATE_COBHISVI_DB_UPDATE_1 */

            R3030_00_UPDATE_COBHISVI_DB_UPDATE_1();

            /*" -1917-  EVALUATE SQLCODE  */

            /*" -1918-  WHEN ZEROS  */

            /*" -1918- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1919- ADD 1 TO WS-UP-COBER-HIS-VA */
                AREA_DE_WORK.WS_UP_COBER_HIS_VA.Value = AREA_DE_WORK.WS_UP_COBER_HIS_VA + 1;

                /*" -1920-  WHEN +100  */

                /*" -1920- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1921- CONTINUE */

                /*" -1922-  WHEN OTHER  */

                /*" -1922- ELSE */
            }
            else
            {


                /*" -1923- DISPLAY '3030 - PROBLEMAS UPDATE COBER_HIST_VIDAZUL' */
                _.Display($"3030 - PROBLEMAS UPDATE COBER_HIST_VIDAZUL");

                /*" -1924- DISPLAY 'NUM-CERTIFICADO => ' COBHISVI-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO}");

                /*" -1925- DISPLAY 'NUM-PARCELA     => ' COBHISVI-NUM-PARCELA */
                _.Display($"NUM-PARCELA     => {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA}");

                /*" -1926- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1928-  END-EVALUATE  */

                /*" -1928- END-IF */
            }


            /*" -1928- . */

        }

        [StopWatch]
        /*" R3030-00-UPDATE-COBHISVI-DB-UPDATE-1 */
        public void R3030_00_UPDATE_COBHISVI_DB_UPDATE_1()
        {
            /*" -1914- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = :COBHISVI-SIT-REGISTRO , OCORR_HISTORICO = OCORR_HISTORICO + 1 WHERE NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND NUM_PARCELA = :COBHISVI-NUM-PARCELA AND SIT_REGISTRO IN ( '0' , 'A' ) END-EXEC */

            var r3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 = new R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1()
            {
                COBHISVI_SIT_REGISTRO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.ToString(),
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
            };

            R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1.Execute(r3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3030_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-UPDATE-COBHISVI-SECTION */
        private void R3040_00_UPDATE_COBHISVI_SECTION()
        {
            /*" -1936- MOVE '3040' TO WNR-EXEC-SQL */
            _.Move("3040", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1937- MOVE 'R3040-00-UPDATE-COBHISVI' TO PARAGRAFO */
            _.Move("R3040-00-UPDATE-COBHISVI", AREA_DE_WORK.PARAGRAFO);

            /*" -1939- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1945- PERFORM R3040_00_UPDATE_COBHISVI_DB_UPDATE_1 */

            R3040_00_UPDATE_COBHISVI_DB_UPDATE_1();

            /*" -1948-  EVALUATE SQLCODE  */

            /*" -1949-  WHEN ZEROS  */

            /*" -1949- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1950- ADD 1 TO WS-UP-COBER-HIS-VA */
                AREA_DE_WORK.WS_UP_COBER_HIS_VA.Value = AREA_DE_WORK.WS_UP_COBER_HIS_VA + 1;

                /*" -1951-  WHEN +100  */

                /*" -1951- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1952- CONTINUE */

                /*" -1953-  WHEN OTHER  */

                /*" -1953- ELSE */
            }
            else
            {


                /*" -1954- DISPLAY '3040 - PROBLEMAS UPDATE COBER_HIST_VIDAZUL' */
                _.Display($"3040 - PROBLEMAS UPDATE COBER_HIST_VIDAZUL");

                /*" -1955- DISPLAY 'NUM-CERTIFICADO => ' COBHISVI-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO}");

                /*" -1956- DISPLAY 'NUM-PARCELA     => ' COBHISVI-NUM-PARCELA */
                _.Display($"NUM-PARCELA     => {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA}");

                /*" -1957- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1959-  END-EVALUATE  */

                /*" -1959- END-IF */
            }


            /*" -1959- . */

        }

        [StopWatch]
        /*" R3040-00-UPDATE-COBHISVI-DB-UPDATE-1 */
        public void R3040_00_UPDATE_COBHISVI_DB_UPDATE_1()
        {
            /*" -1945- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = :COBHISVI-SIT-REGISTRO WHERE NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND NUM_PARCELA = :COBHISVI-NUM-PARCELA AND SIT_REGISTRO = '2' END-EXEC */

            var r3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 = new R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1()
            {
                COBHISVI_SIT_REGISTRO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.ToString(),
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
            };

            R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1.Execute(r3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-TRATA-NUM-CARTAO-SECTION */
        private void R3050_00_TRATA_NUM_CARTAO_SECTION()
        {
            /*" -1967- MOVE '3050' TO WNR-EXEC-SQL */
            _.Move("3050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1968- MOVE 'R3050-00-TRATA-NUM-CARTAO' TO PARAGRAFO */
            _.Move("R3050-00-TRATA-NUM-CARTAO", AREA_DE_WORK.PARAGRAFO);

            /*" -1970- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1972- INITIALIZE DCLOPCAO-PAG-VIDAZUL */
            _.Initialize(
                OPCPAGVI.DCLOPCAO_PAG_VIDAZUL
            );

            /*" -1974- PERFORM R3055-00-CONSULTA-NUM-CARTAO */

            R3055_00_CONSULTA_NUM_CARTAO_SECTION();

            /*" -1976- IF OPCPAGVI-NUM-CARTAO-CREDITO EQUAL SPACES AND OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.IsEmpty() && OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
            {

                /*" -1977- PERFORM R3060-00-RECUPERA-NUM-CARTAO */

                R3060_00_RECUPERA_NUM_CARTAO_SECTION();

                /*" -1978- PERFORM R3070-00-ATUALIZA-NUM-CARTAO */

                R3070_00_ATUALIZA_NUM_CARTAO_SECTION();

                /*" -1980- END-IF */
            }


            /*" -1980- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3055-00-CONSULTA-NUM-CARTAO-SECTION */
        private void R3055_00_CONSULTA_NUM_CARTAO_SECTION()
        {
            /*" -1988- MOVE '3055' TO WNR-EXEC-SQL */
            _.Move("3055", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1989- MOVE 'R3055-00-CONSULTA-NUM-CARTAO' TO PARAGRAFO */
            _.Move("R3055-00-CONSULTA-NUM-CARTAO", AREA_DE_WORK.PARAGRAFO);

            /*" -1991- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -1993- MOVE MCIELO-NUM-PROPOSTA TO OPCPAGVI-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -2006- PERFORM R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1 */

            R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1();

            /*" -2009- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -2010- WHEN 0 */
                case 0:

                    /*" -2011- CONTINUE */

                    /*" -2012- WHEN 100 */
                    break;
                case 100:

                    /*" -2013- DISPLAY 'R3055-00-ERRO-REGISTRO NAO ENCONTRAO OPCAO_PAG_V' */
                    _.Display($"R3055-00-ERRO-REGISTRO NAO ENCONTRAO OPCAO_PAG_V");

                    /*" -2014- DISPLAY 'NUM_CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -2015- DISPLAY 'DATA_VENCIMENTO = ' MCIELO-DATA-VENCIMENTO */
                    _.Display($"DATA_VENCIMENTO = {REG_CIELO.MCIELO_DATA_VENCIMENTO}");

                    /*" -2016- DISPLAY 'DATA_GERACAO    = ' WS-DATA-GERACAO-PARCELA */
                    _.Display($"DATA_GERACAO    = {AREA_DE_WORK.WS_DATA_GERACAO_PARCELA}");

                    /*" -2017- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2018- WHEN OTHER */
                    break;
                default:

                    /*" -2019- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -2020- DISPLAY 'R3055-00-ERRO-SELECT JOIN PARCELAS' */
                    _.Display($"R3055-00-ERRO-SELECT JOIN PARCELAS");

                    /*" -2021- DISPLAY 'NUM_CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -2022- DISPLAY 'DATA_VENCIMENTO = ' MCIELO-DATA-VENCIMENTO */
                    _.Display($"DATA_VENCIMENTO = {REG_CIELO.MCIELO_DATA_VENCIMENTO}");

                    /*" -2023- DISPLAY 'DATA_GERACAO    = ' WS-DATA-GERACAO-PARCELA */
                    _.Display($"DATA_GERACAO    = {AREA_DE_WORK.WS_DATA_GERACAO_PARCELA}");

                    /*" -2024- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2026- END-EVALUATE */
                    break;
            }


            /*" -2027- IF VIND-CCRE LESS ZEROS */

            if (AREA_DE_WORK.VIND_CCRE < 00)
            {

                /*" -2029- MOVE SPACES TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move("", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -2031- END-IF */
            }


            /*" -2031- . */

        }

        [StopWatch]
        /*" R3055-00-CONSULTA-NUM-CARTAO-DB-SELECT-1 */
        public void R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1()
        {
            /*" -2006- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_CARTAO_CREDITO , A.OPCAO_PAGAMENTO INTO :OPCPAGVI-NUM-CERTIFICADO , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CCRE , :OPCPAGVI-OPCAO-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL A WHERE A.NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND A.DATA_INIVIGENCIA <= :WS-DATA-GERACAO-PARCELA AND A.DATA_TERVIGENCIA >= :WS-DATA-GERACAO-PARCELA WITH UR END-EXEC */

            var r3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1 = new R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
                WS_DATA_GERACAO_PARCELA = AREA_DE_WORK.WS_DATA_GERACAO_PARCELA.ToString(),
            };

            var executed_1 = R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1.Execute(r3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_CCRE, AREA_DE_WORK.VIND_CCRE);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3055_99_SAIDA*/

        [StopWatch]
        /*" R3060-00-RECUPERA-NUM-CARTAO-SECTION */
        private void R3060_00_RECUPERA_NUM_CARTAO_SECTION()
        {
            /*" -2039- MOVE '3060' TO WNR-EXEC-SQL */
            _.Move("3060", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2040- MOVE 'R3060-00-RECUPERA-NUM-CARTAO' TO PARAGRAFO */
            _.Move("R3060-00-RECUPERA-NUM-CARTAO", AREA_DE_WORK.PARAGRAFO);

            /*" -2042- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2043- MOVE MCIELO-NUM-PROPOSTA TO GE407-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO);

            /*" -2044- MOVE MCIELO-NUM-PARCELA TO GE407-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA);

            /*" -2046- MOVE MCIELO-NUM-IDLG TO GE407-COD-IDLG */
            _.Move(REG_CIELO.MCIELO_NUM_IDLG, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG);

            /*" -2060- PERFORM R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1 */

            R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1();

            /*" -2063- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -2064- WHEN 0 */
                case 0:

                    /*" -2065- CONTINUE */

                    /*" -2066- WHEN 100 */
                    break;
                case 100:

                    /*" -2068- DISPLAY 'R3060-00-ERRO-REGISTRO NAO ENCONTRADO NA TABELA' 'GE_RETORNO_CA_CIELO' */
                    _.Display($"R3060-00-ERRO-REGISTRO NAO ENCONTRADO NA TABELAGE_RETORNO_CA_CIELO");

                    /*" -2069- DISPLAY 'NUM_CERTIFICADO = ' GE407-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                    /*" -2070- DISPLAY 'NUM_PARCELA     = ' GE407-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                    /*" -2071- DISPLAY 'COD_IDLG        = ' GE407-COD-IDLG */
                    _.Display($"COD_IDLG        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG}");

                    /*" -2072- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2073- WHEN OTHER */
                    break;
                default:

                    /*" -2074- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -2075- DISPLAY 'R3060-00-ERRO-SELECT JOIN GE_CONTROLE_CA_CIELO' */
                    _.Display($"R3060-00-ERRO-SELECT JOIN GE_CONTROLE_CA_CIELO");

                    /*" -2076- DISPLAY 'NUM_CERTIFICADO = ' GE407-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                    /*" -2077- DISPLAY 'NUM_PARCELA     = ' GE407-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                    /*" -2078- DISPLAY 'COD_IDLG        = ' GE407-COD-IDLG */
                    _.Display($"COD_IDLG        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG}");

                    /*" -2079- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2081- END-EVALUATE */
                    break;
            }


            /*" -2081- . */

        }

        [StopWatch]
        /*" R3060-00-RECUPERA-NUM-CARTAO-DB-SELECT-1 */
        public void R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1()
        {
            /*" -2060- EXEC SQL SELECT T2.NUM_CARTAO INTO :GE408-NUM-CARTAO FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1 JOIN SEGUROS.GE_RETORNO_CA_CIELO T2 ON T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO AND T1.NUM_PARCELA = T2.NUM_PARCELA AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO WHERE T1.NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO AND T1.NUM_PARCELA = :GE407-NUM-PARCELA AND T1.COD_IDLG = :GE407-COD-IDLG ORDER BY T2.SEQ_RET_CONTROL_HIST DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1 = new R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1()
            {
                GE407_NUM_CERTIFICADO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.ToString(),
                GE407_NUM_PARCELA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA.ToString(),
                GE407_COD_IDLG = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG.ToString(),
            };

            var executed_1 = R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1.Execute(r3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE408_NUM_CARTAO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3060_99_SAIDA*/

        [StopWatch]
        /*" R3070-00-ATUALIZA-NUM-CARTAO-SECTION */
        private void R3070_00_ATUALIZA_NUM_CARTAO_SECTION()
        {
            /*" -2089- MOVE '3070' TO WNR-EXEC-SQL */
            _.Move("3070", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2090- MOVE 'R3070-00-ATUALIZA-NUM-CARTAO' TO PARAGRAFO */
            _.Move("R3070-00-ATUALIZA-NUM-CARTAO", AREA_DE_WORK.PARAGRAFO);

            /*" -2092- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2093- MOVE GE408-NUM-CARTAO TO WS-NUM-CARTAO-CRED-SAP */
            _.Move(GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CARTAO, AREA_DE_WORK.WS_NUM_CARTAO_CRED_SAP);

            /*" -2096- MOVE WS-NUM-CART-CRED16 TO OPCPAGVI-NUM-CARTAO-CREDITO */
            _.Move(AREA_DE_WORK.WS_NUM_CARTAO_CRED_SAP.WS_NUM_CART_CRED16, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

            /*" -2105- PERFORM R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1 */

            R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1();

            /*" -2108- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -2109- WHEN 0 */
                case 0:

                    /*" -2110- CONTINUE */

                    /*" -2111- WHEN OTHER */
                    break;
                default:

                    /*" -2112- DISPLAY 'R3070-00-ATUALIZA-NUM-CARTAO' */
                    _.Display($"R3070-00-ATUALIZA-NUM-CARTAO");

                    /*" -2113- DISPLAY 'NUM-CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"NUM-CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -2114- DISPLAY 'DATA-VENCIMENTO = ' MCIELO-DATA-VENCIMENTO */
                    _.Display($"DATA-VENCIMENTO = {REG_CIELO.MCIELO_DATA_VENCIMENTO}");

                    /*" -2115- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2115- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R3070-00-ATUALIZA-NUM-CARTAO-DB-UPDATE-1 */
        public void R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1()
        {
            /*" -2105- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET NUM_CARTAO_CREDITO = :OPCPAGVI-NUM-CARTAO-CREDITO WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND OPCAO_PAGAMENTO = '5' AND DATA_INIVIGENCIA <= :WS-DATA-GERACAO-PARCELA AND DATA_TERVIGENCIA >= :WS-DATA-GERACAO-PARCELA END-EXEC. */

            var r3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1 = new R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1()
            {
                OPCPAGVI_NUM_CARTAO_CREDITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.ToString(),
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
                WS_DATA_GERACAO_PARCELA = AREA_DE_WORK.WS_DATA_GERACAO_PARCELA.ToString(),
            };

            R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1.Execute(r3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3070_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-VERIFICA-FATURAMENTO-SECTION */
        private void R3100_00_VERIFICA_FATURAMENTO_SECTION()
        {
            /*" -2123- MOVE '3100' TO WNR-EXEC-SQL */
            _.Move("3100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2124- MOVE 'R3100-00-VERIFICA-FATURAMENTO' TO PARAGRAFO */
            _.Move("R3100-00-VERIFICA-FATURAMENTO", AREA_DE_WORK.PARAGRAFO);

            /*" -2126- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2128- INITIALIZE DCLHIST-CONT-PARCELVA */
            _.Initialize(
                HISCONPA.DCLHIST_CONT_PARCELVA
            );

            /*" -2129- MOVE MCIELO-NUM-PROPOSTA TO HISCONPA-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -2130- MOVE MCIELO-NUM-PARCELA TO HISCONPA-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -2131- MOVE HISLANCT-OCORR-HISTORICOCTA TO HISCONPA-OCORR-HISTORICO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);

            /*" -2133- MOVE ZEROS TO WS-CONTA-CONTABIL */
            _.Move(0, AREA_DE_WORK.WS_CONTA_CONTABIL);

            /*" -2143- PERFORM R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1 */

            R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1();

            /*" -2147- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -2148- DISPLAY 'R3100-00 (PARCELA FATURADA)' */
                _.Display($"R3100-00 (PARCELA FATURADA)");

                /*" -2149- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -2150- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -2151- DISPLAY 'OCORR_HISTORICO = ' HISCONPA-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO}");

                /*" -2152- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -2153- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2155- END-IF */
            }


            /*" -2155- . */

        }

        [StopWatch]
        /*" R3100-00-VERIFICA-FATURAMENTO-DB-SELECT-1 */
        public void R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1()
        {
            /*" -2143- EXEC SQL SELECT COUNT(*) INTO :WS-CONTA-CONTABIL FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND OCORR_HISTORICO = :HISCONPA-OCORR-HISTORICO END-EXEC */

            var r3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1 = new R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_OCORR_HISTORICO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1.Execute(r3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONTA_CONTABIL, AREA_DE_WORK.WS_CONTA_CONTABIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3120-00-MONTA-HISCOMPA-SECTION */
        private void R3120_00_MONTA_HISCOMPA_SECTION()
        {
            /*" -2196- MOVE '3120' TO WNR-EXEC-SQL */
            _.Move("3120", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2197- MOVE 'R3120-00-MONTA-HISCOMPA' TO PARAGRAFO */
            _.Move("R3120-00-MONTA-HISCOMPA", AREA_DE_WORK.PARAGRAFO);

            /*" -2199- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2200- MOVE MCIELO-NUM-PROPOSTA TO HISCONPA-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -2202- MOVE MCIELO-NUM-PARCELA TO HISCONPA-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -2204- MOVE HISLANCT-OCORR-HISTORICOCTA TO HISCONPA-OCORR-HISTORICO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);

            /*" -2205- MOVE COBHISVI-NUM-TITULO TO HISCONPA-NUM-TITULO */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);

            /*" -2206- MOVE PROPOVA-NUM-APOLICE TO HISCONPA-NUM-APOLICE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);

            /*" -2207- MOVE PROPOVA-COD-SUBGRUPO TO HISCONPA-COD-SUBGRUPO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);

            /*" -2208- MOVE PROPOVA-COD-FONTE TO HISCONPA-COD-FONTE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE);

            /*" -2209- MOVE PARCEVID-PREMIO-VG TO HISCONPA-PREMIO-VG */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);

            /*" -2210- MOVE PARCEVID-PREMIO-AP TO HISCONPA-PREMIO-AP */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

            /*" -2211- MOVE SISTEMAS-DATA-MOV-ABERTO TO HISCONPA-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO);

            /*" -2212- MOVE ZEROS TO HISCONPA-NUM-ENDOSSO */
            _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);

            /*" -2214- MOVE '0' TO HISCONPA-SIT-REGISTRO */
            _.Move("0", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);

            /*" -2216- MOVE -1 TO VIND-DTFATUR */
            _.Move(-1, AREA_DE_WORK.VIND_DTFATUR);

            /*" -2216- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3150-00-INSERT-HISCONPA-SECTION */
        private void R3150_00_INSERT_HISCONPA_SECTION()
        {
            /*" -2224- MOVE '3150' TO WNR-EXEC-SQL */
            _.Move("3150", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2225- MOVE 'R3150-00-INSERT-HISCONPA' TO PARAGRAFO */
            _.Move("R3150-00-INSERT-HISCONPA", AREA_DE_WORK.PARAGRAFO);

            /*" -2227- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2263- PERFORM R3150_00_INSERT_HISCONPA_DB_INSERT_1 */

            R3150_00_INSERT_HISCONPA_DB_INSERT_1();

            /*" -2266- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2267- DISPLAY 'R3150-00 - PROBLEMAS NO INSERT HISTCONTABILVA' */
                _.Display($"R3150-00 - PROBLEMAS NO INSERT HISTCONTABILVA");

                /*" -2268- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -2269- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -2270- DISPLAY 'COD_OPERACAO    = ' HISCONPA-COD-OPERACAO */
                _.Display($"COD_OPERACAO    = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO}");

                /*" -2271- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -2272- DISPLAY 'REG. NUMERO     = ' WS-CONT-LIDOS */
                _.Display($"REG. NUMERO     = {AREA_DE_WORK.WS_CONT_LIDOS}");

                /*" -2273- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2273- END-IF. */
            }


        }

        [StopWatch]
        /*" R3150-00-INSERT-HISCONPA-DB-INSERT-1 */
        public void R3150_00_INSERT_HISCONPA_DB_INSERT_1()
        {
            /*" -2263- EXEC SQL INSERT INTO SEGUROS.HIST_CONT_PARCELVA ( NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_ENDOSSO , PREMIO_VG , PREMIO_AP , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , TIMESTAMP , DTFATUR ) VALUES ( :HISCONPA-NUM-CERTIFICADO , :HISCONPA-NUM-PARCELA , :HISCONPA-NUM-TITULO , :HISCONPA-OCORR-HISTORICO , :HISCONPA-NUM-APOLICE , :HISCONPA-COD-SUBGRUPO , :HISCONPA-COD-FONTE , :HISCONPA-NUM-ENDOSSO , :HISCONPA-PREMIO-VG , :HISCONPA-PREMIO-AP , :HISCONPA-DATA-MOVIMENTO , :HISCONPA-SIT-REGISTRO , :HISCONPA-COD-OPERACAO , CURRENT TIMESTAMP , :HISCONPA-DTFATUR:VIND-DTFATUR ) END-EXEC */

            var r3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1 = new R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
                HISCONPA_OCORR_HISTORICO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_COD_SUBGRUPO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO.ToString(),
                HISCONPA_COD_FONTE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
                HISCONPA_PREMIO_VG = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG.ToString(),
                HISCONPA_PREMIO_AP = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP.ToString(),
                HISCONPA_DATA_MOVIMENTO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO.ToString(),
                HISCONPA_SIT_REGISTRO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO.ToString(),
                HISCONPA_COD_OPERACAO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO.ToString(),
                HISCONPA_DTFATUR = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR.ToString(),
                VIND_DTFATUR = AREA_DE_WORK.VIND_DTFATUR.ToString(),
            };

            R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1.Execute(r3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-ATUALIZA-INADIMPLENTE-SECTION */
        private void R3500_00_ATUALIZA_INADIMPLENTE_SECTION()
        {
            /*" -2282- MOVE '3500' TO WNR-EXEC-SQL */
            _.Move("3500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2283- MOVE 'R3500-00-ATUALIZA-INADIMPLENTE' TO PARAGRAFO */
            _.Move("R3500-00-ATUALIZA-INADIMPLENTE", AREA_DE_WORK.PARAGRAFO);

            /*" -2285- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2286- MOVE MCIELO-NUM-PROPOSTA TO COBHISVI-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

            /*" -2287- MOVE MCIELO-NUM-PARCELA TO COBHISVI-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -2290- MOVE ' ' TO COBHISVI-SIT-REGISTRO */
            _.Move(" ", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

            /*" -2292- PERFORM R3030-00-UPDATE-COBHISVI */

            R3030_00_UPDATE_COBHISVI_SECTION();

            /*" -2293- MOVE COBHISVI-NUM-CERTIFICADO TO HISLANCT-NUM-CERTIFICADO */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -2294- MOVE COBHISVI-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -2295- MOVE ' ' TO HISLANCT-SIT-REGISTRO */
            _.Move(" ", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -2296- MOVE WS-NSAC TO HISLANCT-NSAC */
            _.Move(AREA_DE_WORK.WS_NSAC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC);

            /*" -2297- MOVE 9999 TO HISLANCT-CODRET */
            _.Move(9999, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

            /*" -2301- MOVE ZEROS TO VIND-NSAC VIND-COD-RET */
            _.Move(0, AREA_DE_WORK.VIND_NSAC, AREA_DE_WORK.VIND_COD_RET);

            /*" -2303- PERFORM R4040-UPDATE-HIST-LANC-CTA */

            R4040_UPDATE_HIST_LANC_CTA_SECTION();

            /*" -2303- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-ATUAL-REGUA-COBRANCA-SECTION */
        private void R3600_00_ATUAL_REGUA_COBRANCA_SECTION()
        {
            /*" -2312- MOVE '3600' TO WNR-EXEC-SQL */
            _.Move("3600", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2313- MOVE 'R3600-00-ATUAL-REGUA-COBRANCA' TO PARAGRAFO */
            _.Move("R3600-00-ATUAL-REGUA-COBRANCA", AREA_DE_WORK.PARAGRAFO);

            /*" -2315- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2316- MOVE MCIELO-NUM-PROPOSTA TO COBHISVI-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

            /*" -2317- MOVE MCIELO-NUM-PARCELA TO COBHISVI-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -2320- MOVE 'A' TO COBHISVI-SIT-REGISTRO */
            _.Move("A", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

            /*" -2322- PERFORM R3030-00-UPDATE-COBHISVI */

            R3030_00_UPDATE_COBHISVI_SECTION();

            /*" -2323- MOVE COBHISVI-NUM-CERTIFICADO TO HISLANCT-NUM-CERTIFICADO */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -2324- MOVE COBHISVI-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -2325- MOVE 'A' TO HISLANCT-SIT-REGISTRO */
            _.Move("A", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -2327- MOVE ZEROS TO HISLANCT-NSAC HISLANCT-CODRET */
            _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

            /*" -2331- MOVE -1 TO VIND-NSAC VIND-COD-RET */
            _.Move(-1, AREA_DE_WORK.VIND_NSAC, AREA_DE_WORK.VIND_COD_RET);

            /*" -2333- PERFORM R4040-UPDATE-HIST-LANC-CTA */

            R4040_UPDATE_HIST_LANC_CTA_SECTION();

            /*" -2333- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R4010-00-SELECT-PARCELAS-SECTION */
        private void R4010_00_SELECT_PARCELAS_SECTION()
        {
            /*" -2341- MOVE '4010' TO WNR-EXEC-SQL */
            _.Move("4010", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2342- MOVE 'R4010-00-SELECT-PARCELAS' TO PARAGRAFO */
            _.Move("R4010-00-SELECT-PARCELAS", AREA_DE_WORK.PARAGRAFO);

            /*" -2344- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2345- MOVE MCIELO-NUM-PROPOSTA TO HISCONPA-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -2346- MOVE MCIELO-NUM-PARCELA TO HISCONPA-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -2349- MOVE HISLANCT-OCORR-HISTORICOCTA TO HISCONPA-OCORR-HISTORICO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);

            /*" -2408- PERFORM R4010_00_SELECT_PARCELAS_DB_SELECT_1 */

            R4010_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -2411- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -2412- WHEN 0 */
                case 0:

                    /*" -2413- CONTINUE */

                    /*" -2414- WHEN 100 */
                    break;
                case 100:

                    /*" -2415- DISPLAY '4010-00-ERRO-REGISTRO NAO ENCONTRAO JOIN PARCELA' */
                    _.Display($"4010-00-ERRO-REGISTRO NAO ENCONTRAO JOIN PARCELA");

                    /*" -2416- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -2417- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -2418- DISPLAY 'OCORR_HISTORICO = ' HISCONPA-OCORR-HISTORICO */
                    _.Display($"OCORR_HISTORICO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO}");

                    /*" -2419- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2420- WHEN -811 */
                    break;
                case -811:

                    /*" -2421- DISPLAY '4010-00-ERRO-DUPLIICIDADE JOIN PARCELAS' */
                    _.Display($"4010-00-ERRO-DUPLIICIDADE JOIN PARCELAS");

                    /*" -2422- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -2423- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -2424- DISPLAY 'OCORR_HISTORICO = ' HISCONPA-OCORR-HISTORICO */
                    _.Display($"OCORR_HISTORICO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO}");

                    /*" -2425- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2426- WHEN OTHER */
                    break;
                default:

                    /*" -2427- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -2428- DISPLAY '4010-00-ERRO-SELECT JOIN PARCELAS      ' */
                    _.Display($"4010-00-ERRO-SELECT JOIN PARCELAS      ");

                    /*" -2429- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -2430- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -2431- DISPLAY 'OCORR_HISTORICO = ' HISCONPA-OCORR-HISTORICO */
                    _.Display($"OCORR_HISTORICO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO}");

                    /*" -2432- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2432- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R4010-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R4010_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -2408- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.NUM_ENDOSSO , A.NUM_APOLICE , A.SIT_REGISTRO , C.DAC_PARCELA , C.PRM_TARIFARIO_IX , C.VAL_DESCONTO_IX , C.PRM_LIQUIDO_IX , C.ADICIONAL_FRAC_IX , C.VAL_CUSTO_EMIS_IX , C.VAL_IOCC_IX , C.PRM_TOTAL_IX , C.QTD_DOCUMENTOS , C.SIT_REGISTRO , B.COD_PRODUTO , D.TIPO_CORRECAO , D.COD_MOEDA_PRM , D.COD_USUARIO , E.NUM_TITULO INTO :HISCONPA-NUM-CERTIFICADO , :HISCONPA-NUM-PARCELA , :HISCONPA-NUM-ENDOSSO , :HISCONPA-NUM-APOLICE , :HISCONPA-SIT-REGISTRO , :PARCELAS-DAC-PARCELA , :PARCELAS-PRM-TARIFARIO-IX , :PARCELAS-VAL-DESCONTO-IX , :PARCELAS-PRM-LIQUIDO-IX , :PARCELAS-ADICIONAL-FRAC-IX , :PARCELAS-VAL-CUSTO-EMIS-IX , :PARCELAS-VAL-IOCC-IX , :PARCELAS-PRM-TOTAL-IX , :PARCELAS-QTD-DOCUMENTOS , :PARCELAS-SIT-REGISTRO , :PROPOVA-COD-PRODUTO , :ENDOSSOS-TIPO-CORRECAO , :ENDOSSOS-COD-MOEDA-PRM , :ENDOSSOS-COD-USUARIO , :COBHISVI-NUM-TITULO FROM SEGUROS.HIST_CONT_PARCELVA A , SEGUROS.PROPOSTAS_VA B , SEGUROS.PARCELAS C , SEGUROS.ENDOSSOS D , SEGUROS.COBER_HIST_VIDAZUL E WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_TITULO > 0 AND A.NUM_PARCELA = :HISCONPA-NUM-PARCELA AND A.COD_OPERACAO BETWEEN 200 AND 299 AND A.OCORR_HISTORICO = :HISCONPA-OCORR-HISTORICO AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_APOLICE = C.NUM_APOLICE AND A.NUM_ENDOSSO = C.NUM_ENDOSSO AND A.NUM_APOLICE = D.NUM_APOLICE AND A.NUM_ENDOSSO = D.NUM_ENDOSSO AND A.NUM_CERTIFICADO = E.NUM_CERTIFICADO AND A.NUM_PARCELA = E.NUM_PARCELA WITH UR END-EXEC */

            var r4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_OCORR_HISTORICO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
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
                _.Move(executed_1.PARCELAS_SIT_REGISTRO, PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_TIPO_CORRECAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);
                _.Move(executed_1.ENDOSSOS_COD_USUARIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4010_99_SAIDA*/

        [StopWatch]
        /*" R4015-00-SELECT-PARCELAS-SECTION */
        private void R4015_00_SELECT_PARCELAS_SECTION()
        {
            /*" -2440- MOVE '4015' TO WNR-EXEC-SQL */
            _.Move("4015", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2441- MOVE 'R4015-00-SELECT-PARCELAS' TO PARAGRAFO */
            _.Move("R4015-00-SELECT-PARCELAS", AREA_DE_WORK.PARAGRAFO);

            /*" -2443- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2444- MOVE MCIELO-NUM-PROPOSTA TO HISCONPA-NUM-CERTIFICADO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -2446- MOVE MCIELO-NUM-PARCELA TO HISCONPA-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -2508- PERFORM R4015_00_SELECT_PARCELAS_DB_SELECT_1 */

            R4015_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -2511- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -2512- WHEN 0 */
                case 0:

                    /*" -2513- CONTINUE */

                    /*" -2514- WHEN 100 */
                    break;
                case 100:

                    /*" -2515- DISPLAY '4015-00-ERRO-REGISTRO NAO ENCONTRAO JOIN PARCELA' */
                    _.Display($"4015-00-ERRO-REGISTRO NAO ENCONTRAO JOIN PARCELA");

                    /*" -2516- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -2517- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -2518- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2519- WHEN -811 */
                    break;
                case -811:

                    /*" -2520- DISPLAY '4015-00-ERRO-DUPLIICIDADE JOIN PARCELAS' */
                    _.Display($"4015-00-ERRO-DUPLIICIDADE JOIN PARCELAS");

                    /*" -2521- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -2522- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -2523- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2524- WHEN OTHER */
                    break;
                default:

                    /*" -2525- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                    /*" -2526- DISPLAY '4015-00-ERRO-SELECT JOIN PARCELAS      ' */
                    _.Display($"4015-00-ERRO-SELECT JOIN PARCELAS      ");

                    /*" -2527- DISPLAY 'NUM_CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -2528- DISPLAY 'NUM_PARCELA     = ' HISCONPA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -2529- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2529- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R4015-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R4015_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -2508- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.NUM_ENDOSSO , A.NUM_APOLICE , A.SIT_REGISTRO , C.DAC_PARCELA , C.PRM_TARIFARIO_IX , C.VAL_DESCONTO_IX , C.PRM_LIQUIDO_IX , C.ADICIONAL_FRAC_IX , C.VAL_CUSTO_EMIS_IX , C.VAL_IOCC_IX , C.PRM_TOTAL_IX , C.QTD_DOCUMENTOS , C.SIT_REGISTRO , B.COD_PRODUTO , D.TIPO_CORRECAO , D.COD_MOEDA_PRM , D.COD_USUARIO , E.NUM_TITULO , A.OCORR_HISTORICO INTO :HISCONPA-NUM-CERTIFICADO , :HISCONPA-NUM-PARCELA , :HISCONPA-NUM-ENDOSSO , :HISCONPA-NUM-APOLICE , :HISCONPA-SIT-REGISTRO , :PARCELAS-DAC-PARCELA , :PARCELAS-PRM-TARIFARIO-IX , :PARCELAS-VAL-DESCONTO-IX , :PARCELAS-PRM-LIQUIDO-IX , :PARCELAS-ADICIONAL-FRAC-IX , :PARCELAS-VAL-CUSTO-EMIS-IX , :PARCELAS-VAL-IOCC-IX , :PARCELAS-PRM-TOTAL-IX , :PARCELAS-QTD-DOCUMENTOS , :PARCELAS-SIT-REGISTRO , :PROPOVA-COD-PRODUTO , :ENDOSSOS-TIPO-CORRECAO , :ENDOSSOS-COD-MOEDA-PRM , :ENDOSSOS-COD-USUARIO , :COBHISVI-NUM-TITULO , :HISCONPA-OCORR-HISTORICO FROM SEGUROS.HIST_CONT_PARCELVA A , SEGUROS.PROPOSTAS_VA B , SEGUROS.PARCELAS C , SEGUROS.ENDOSSOS D , SEGUROS.COBER_HIST_VIDAZUL E WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_TITULO > 0 AND A.NUM_PARCELA = :HISCONPA-NUM-PARCELA AND A.COD_OPERACAO BETWEEN 200 AND 299 AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_APOLICE = C.NUM_APOLICE AND A.NUM_ENDOSSO = C.NUM_ENDOSSO AND A.NUM_APOLICE = D.NUM_APOLICE AND A.NUM_ENDOSSO = D.NUM_ENDOSSO AND A.NUM_CERTIFICADO = E.NUM_CERTIFICADO AND A.NUM_PARCELA = E.NUM_PARCELA ORDER BY A.OCORR_HISTORICO DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
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
                _.Move(executed_1.PARCELAS_SIT_REGISTRO, PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_TIPO_CORRECAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);
                _.Move(executed_1.ENDOSSOS_COD_USUARIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4015_99_SAIDA*/

        [StopWatch]
        /*" R4020-00-PROCESSA-REGISTRO-SECTION */
        private void R4020_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -2538- MOVE '4020' TO WNR-EXEC-SQL */
            _.Move("4020", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2539- MOVE 'R4020-00-PROCESSA-REGISTRO' TO PARAGRAFO */
            _.Move("R4020-00-PROCESSA-REGISTRO", AREA_DE_WORK.PARAGRAFO);

            /*" -2542- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2548- MOVE ZEROS TO WS-VLPRMTOT WS-VLBALCAO WS-VLIOCC WS-VLDESCON WS-VLTARIFA */
            _.Move(0, AREA_DE_WORK.WS_VLPRMTOT, AREA_DE_WORK.WS_VLBALCAO, AREA_DE_WORK.WS_VLIOCC, AREA_DE_WORK.WS_VLDESCON, AREA_DE_WORK.WS_VLTARIFA);

            /*" -2549- MOVE MCIELO-VLR-COBRANCA TO WS-VLPRMTOT */
            _.Move(REG_CIELO.MCIELO_VLR_COBRANCA, AREA_DE_WORK.WS_VLPRMTOT);

            /*" -2553- MOVE PARCELAS-VAL-IOCC-IX TO WS-VLIOCC */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, AREA_DE_WORK.WS_VLIOCC);

            /*" -2555- COMPUTE WS-VLPRMLIQ = WS-VLPRMTOT - WS-VLIOCC */
            AREA_DE_WORK.WS_VLPRMLIQ.Value = AREA_DE_WORK.WS_VLPRMTOT - AREA_DE_WORK.WS_VLIOCC;

            /*" -2557- ADD WS-VLPRMLIQ TO AVISOCRE-PRM-LIQUIDO */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO + AREA_DE_WORK.WS_VLPRMLIQ;

            /*" -2560- ADD MCIELO-VLR-COBRANCA TO AVISOCRE-PRM-TOTAL WS-SDOATUAL */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL + REG_CIELO.MCIELO_VLR_COBRANCA;
            AREA_DE_WORK.WS_SDOATUAL.Value = AREA_DE_WORK.WS_SDOATUAL + REG_CIELO.MCIELO_VLR_COBRANCA;

            /*" -2562- ADD WS-VLIOCC TO AVISOCRE-VAL-IOCC */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC + AREA_DE_WORK.WS_VLIOCC;

            /*" -2565- ADD MCIELO-VLR-TAX-ADM TO WS-VLDESPES */
            AREA_DE_WORK.WS_VLDESPES.Value = AREA_DE_WORK.WS_VLDESPES + REG_CIELO.MCIELO_VLR_TAX_ADM;

            /*" -2568- PERFORM R4025-00-INSERT-MOV-COBR */

            R4025_00_INSERT_MOV_COBR_SECTION();

            /*" -2568- PERFORM R4100-00-TRATA-DESPESAS. */

            R4100_00_TRATA_DESPESAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4020_99_SAIDA*/

        [StopWatch]
        /*" R4025-00-INSERT-MOV-COBR-SECTION */
        private void R4025_00_INSERT_MOV_COBR_SECTION()
        {
            /*" -2576- MOVE '4025' TO WNR-EXEC-SQL */
            _.Move("4025", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2577- MOVE 'R4025-00-INSERT-MOV-COBR' TO PARAGRAFO */
            _.Move("R4025-00-INSERT-MOV-COBR", AREA_DE_WORK.PARAGRAFO);

            /*" -2579- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2582- MOVE 'PAGAMENTO DE PARCELA DE ADESAO' TO WS-DES-TIPO-SIT */
            _.Move("PAGAMENTO DE PARCELA DE ADESAO", AREA_DE_WORK.WS_DES_TIPO_SIT);

            /*" -2583- MOVE AVISOCRE-COD-EMPRESA TO MOVIMCOB-COD-EMPRESA */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);

            /*" -2584- MOVE ZEROS TO MOVIMCOB-COD-MOVIMENTO */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -2585- MOVE 104 TO MOVIMCOB-COD-BANCO */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -2586- MOVE 7011 TO MOVIMCOB-COD-AGENCIA */
            _.Move(7011, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -2587- MOVE AVISOCRE-NUM-AVISO-CREDITO TO MOVIMCOB-NUM-AVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -2588- MOVE HEAD01-NSAS TO MOVIMCOB-NUM-FITA */
            _.Move(HEAD01_CIELO.HEAD01_NSAS, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);

            /*" -2589- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMCOB-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);

            /*" -2590- MOVE MCIELO-DATA-CREDITO TO MOVIMCOB-DATA-QUITACAO */
            _.Move(REG_CIELO.MCIELO_DATA_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);

            /*" -2591- MOVE COBHISVI-NUM-TITULO TO MOVIMCOB-NUM-TITULO */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -2592- MOVE HISCONPA-NUM-APOLICE TO MOVIMCOB-NUM-APOLICE */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -2593- MOVE HISCONPA-NUM-ENDOSSO TO MOVIMCOB-NUM-ENDOSSO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);

            /*" -2594- MOVE HISCONPA-NUM-PARCELA TO MOVIMCOB-NUM-PARCELA */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);

            /*" -2596- MOVE MCIELO-VLR-COBRANCA TO MOVIMCOB-VAL-TITULO */
            _.Move(REG_CIELO.MCIELO_VLR_COBRANCA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);

            /*" -2598- MOVE WS-VLIOCC TO MOVIMCOB-VAL-IOCC */
            _.Move(AREA_DE_WORK.WS_VLIOCC, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);

            /*" -2599- MOVE WS-VLPRMLIQ TO MOVIMCOB-VAL-CREDITO */
            _.Move(AREA_DE_WORK.WS_VLPRMLIQ, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -2600- MOVE HISCONPA-SIT-REGISTRO TO MOVIMCOB-SIT-REGISTRO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -2601- MOVE WS-DES-TIPO-SIT TO MOVIMCOB-NOME-SEGURADO */
            _.Move(AREA_DE_WORK.WS_DES_TIPO_SIT, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

            /*" -2602- MOVE '1' TO MOVIMCOB-TIPO-MOVIMENTO */
            _.Move("1", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

            /*" -2604- MOVE MCIELO-NUM-PROPOSTA TO MOVIMCOB-NUM-NOSSO-TITULO */
            _.Move(REG_CIELO.MCIELO_NUM_PROPOSTA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -2650- PERFORM R4025_00_INSERT_MOV_COBR_DB_INSERT_1 */

            R4025_00_INSERT_MOV_COBR_DB_INSERT_1();

            /*" -2653- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2654- CONTINUE */

                /*" -2655- ELSE */
            }
            else
            {


                /*" -2656- DISPLAY '1000-PROBLEMAS NO INSERT MOVIMENTO_COBRANCA' */
                _.Display($"1000-PROBLEMAS NO INSERT MOVIMENTO_COBRANCA");

                /*" -2657- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2658- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2660- END-IF */
            }


            /*" -2660- ADD 1 TO WS-IN-MOVIMCOB. */
            AREA_DE_WORK.WS_IN_MOVIMCOB.Value = AREA_DE_WORK.WS_IN_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R4025-00-INSERT-MOV-COBR-DB-INSERT-1 */
        public void R4025_00_INSERT_MOV_COBR_DB_INSERT_1()
        {
            /*" -2650- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_COBRANCA ( COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_IOCC , VAL_CREDITO , SIT_REGISTRO , TIMESTAMP , NOME_SEGURADO , TIPO_MOVIMENTO , NUM_NOSSO_TITULO ) VALUES ( :MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-IOCC , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , CURRENT TIMESTAMP , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-TIPO-MOVIMENTO , :MOVIMCOB-NUM-NOSSO-TITULO ) END-EXEC */

            var r4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1 = new R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1()
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

            R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1.Execute(r4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4025_99_SAIDA*/

        [StopWatch]
        /*" R4030-UPD-COBER-HIST-VIDAZUL-SECTION */
        private void R4030_UPD_COBER_HIST_VIDAZUL_SECTION()
        {
            /*" -2668- MOVE '4030' TO WNR-EXEC-SQL */
            _.Move("4030", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2669- MOVE 'R4030-UPD-COBER-HIST-VIDAZUL' TO PARAGRAFO */
            _.Move("R4030-UPD-COBER-HIST-VIDAZUL", AREA_DE_WORK.PARAGRAFO);

            /*" -2671- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2679- PERFORM R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1 */

            R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1();

            /*" -2682-  EVALUATE SQLCODE  */

            /*" -2683-  WHEN ZEROS  */

            /*" -2683- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2684- ADD 1 TO WS-UP-COBER-HIS-VA */
                AREA_DE_WORK.WS_UP_COBER_HIS_VA.Value = AREA_DE_WORK.WS_UP_COBER_HIS_VA + 1;

                /*" -2685-  WHEN +100  */

                /*" -2685- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2686- CONTINUE */

                /*" -2687-  WHEN OTHER  */

                /*" -2687- ELSE */
            }
            else
            {


                /*" -2688- DISPLAY '3210 - PROBLEMAS  UPDATE COBER_HIST_VIDAZUL' */
                _.Display($"3210 - PROBLEMAS  UPDATE COBER_HIST_VIDAZUL");

                /*" -2689- DISPLAY 'NUM-CERTIFICADO => ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -2690- DISPLAY 'NUM-PARCELA     => ' HISCONPA-NUM-PARCELA */
                _.Display($"NUM-PARCELA     => {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -2691- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2693-  END-EVALUATE  */

                /*" -2693- END-IF */
            }


            /*" -2693- . */

        }

        [StopWatch]
        /*" R4030-UPD-COBER-HIST-VIDAZUL-DB-UPDATE-1 */
        public void R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1()
        {
            /*" -2679- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET NUM_AVISO_CREDITO = :MOVIMCOB-NUM-AVISO , BCO_AVISO = :MOVIMCOB-COD-BANCO , AGE_AVISO = :MOVIMCOB-COD-AGENCIA WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND SIT_REGISTRO = '1' END-EXEC */

            var r4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1 = new R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1.Execute(r4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4030_99_SAIDA*/

        [StopWatch]
        /*" R4040-UPDATE-HIST-LANC-CTA-SECTION */
        private void R4040_UPDATE_HIST_LANC_CTA_SECTION()
        {
            /*" -2701- MOVE '4040' TO WNR-EXEC-SQL */
            _.Move("4040", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2702- MOVE 'R4040-UPDATE-HIST-LANC-CTA' TO PARAGRAFO */
            _.Move("R4040-UPDATE-HIST-LANC-CTA", AREA_DE_WORK.PARAGRAFO);

            /*" -2704- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2716- PERFORM R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1 */

            R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1();

            /*" -2719-  EVALUATE SQLCODE  */

            /*" -2720-  WHEN ZEROS  */

            /*" -2720- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2721- ADD 1 TO WS-UP-HIS-LANC-CTA */
                AREA_DE_WORK.WS_UP_HIS_LANC_CTA.Value = AREA_DE_WORK.WS_UP_HIS_LANC_CTA + 1;

                /*" -2722-  WHEN +100  */

                /*" -2722- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2723- CONTINUE */

                /*" -2724-  WHEN OTHER  */

                /*" -2724- ELSE */
            }
            else
            {


                /*" -2725- DISPLAY '3214 - PROBLEMAS  UPDATE HIST_LANC_CTA ' */
                _.Display($"3214 - PROBLEMAS  UPDATE HIST_LANC_CTA ");

                /*" -2726- DISPLAY 'NUM-CERTIFICADO   = ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO   = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -2727- DISPLAY 'NUM-PARCELA       = ' HISLANCT-NUM-PARCELA */
                _.Display($"NUM-PARCELA       = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                /*" -2728- DISPLAY 'OCORR-HISTORICOCTA= ' HISLANCT-OCORR-HISTORICOCTA */
                _.Display($"OCORR-HISTORICOCTA= {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}");

                /*" -2729- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2731-  END-EVALUATE  */

                /*" -2731- END-IF */
            }


            /*" -2731- . */

        }

        [StopWatch]
        /*" R4040-UPDATE-HIST-LANC-CTA-DB-UPDATE-1 */
        public void R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1()
        {
            /*" -2716- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = :HISLANCT-SIT-REGISTRO , NSAC = :HISLANCT-NSAC:VIND-NSAC , OCORR_HISTORICO = OCORR_HISTORICO + 1 , CODRET = :HISLANCT-CODRET:VIND-COD-RET , TIMESTAMP = CURRENT TIMESTAMP , COD_USUARIO = 'CB0124B' WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND NUM_PARCELA = :HISLANCT-NUM-PARCELA AND OCORR_HISTORICOCTA = :HISLANCT-OCORR-HISTORICOCTA AND SIT_REGISTRO IN ( '3' , 'A' ) END-EXEC */

            var r4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 = new R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1()
            {
                HISLANCT_CODRET = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET.ToString(),
                VIND_COD_RET = AREA_DE_WORK.VIND_COD_RET.ToString(),
                HISLANCT_NSAC = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC.ToString(),
                VIND_NSAC = AREA_DE_WORK.VIND_NSAC.ToString(),
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1.Execute(r4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4040_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-TRATA-DESPESAS-SECTION */
        private void R4100_00_TRATA_DESPESAS_SECTION()
        {
            /*" -2739- MOVE '4100' TO WNR-EXEC-SQL */
            _.Move("4100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2740- MOVE 'R4100-00-TRATA-DESPESAS' TO PARAGRAFO */
            _.Move("R4100-00-TRATA-DESPESAS", AREA_DE_WORK.PARAGRAFO);

            /*" -2742- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2744- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -2745- SEARCH WS-TABG-OCORREPRD */
            for (; WS_PRD < AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -2746- WHEN PROPOVA-COD-PRODUTO EQUAL WS-TABG-CODPRODU(WS-PRD) */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_CODPRODU)
                {


                    /*" -2747- PERFORM R4150-00-VERIFICA-TIPO */

                    R4150_00_VERIFICA_TIPO_SECTION();

                    /*" -2747- END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4150-00-VERIFICA-TIPO-SECTION */
        private void R4150_00_VERIFICA_TIPO_SECTION()
        {
            /*" -2755- MOVE '4150' TO WNR-EXEC-SQL */
            _.Move("4150", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2756- MOVE 'R4150-00-VERIFICA-TIPO' TO PARAGRAFO */
            _.Move("R4150-00-VERIFICA-TIPO", AREA_DE_WORK.PARAGRAFO);

            /*" -2762- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2763- SET WS-TIP TO 3 */
            WS_TIP.Value = 3;

            /*" -2766- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -2767- ADD 1 TO WS-TABG-QTDE(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE + 1;

            /*" -2768- ADD WS-VLPRMTOT TO WS-TABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT + AREA_DE_WORK.WS_VLPRMTOT;

            /*" -2769- ADD WS-VLTARIFA TO WS-TABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA + AREA_DE_WORK.WS_VLTARIFA;

            /*" -2770- ADD WS-VLBALCAO TO WS-TABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO + AREA_DE_WORK.WS_VLBALCAO;

            /*" -2771- ADD WS-VLIOCC TO WS-TABG-VLIOCC (WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC + AREA_DE_WORK.WS_VLIOCC;

            /*" -2773- ADD WS-VLDESCON TO WS-TABG-VLDESCON(WS-PRD WS-TIP WS-SIT) */
            AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON.Value = AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON + AREA_DE_WORK.WS_VLDESCON;

            /*" -2773- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-PROCESSA-COBRANCA-SECTION */
        private void R4200_00_PROCESSA_COBRANCA_SECTION()
        {
            /*" -2781- MOVE '4200' TO WNR-EXEC-SQL */
            _.Move("4200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2782- MOVE 'R4200-00-PROCESSA-COBRANCA' TO PARAGRAFO */
            _.Move("R4200-00-PROCESSA-COBRANCA", AREA_DE_WORK.PARAGRAFO);

            /*" -2784- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2785- PERFORM R4210-00-MONTA-COBRANCA */

            R4210_00_MONTA_COBRANCA_SECTION();

            /*" -2786- PERFORM R4220-00-INSERT-PARCELA-HIS */

            R4220_00_INSERT_PARCELA_HIS_SECTION();

            /*" -2787- PERFORM R4230-00-ATUALIZA-PARCELAS */

            R4230_00_ATUALIZA_PARCELAS_SECTION();

            /*" -2789- PERFORM R4240-00-ATUALIZA-ENDOSSOS */

            R4240_00_ATUALIZA_ENDOSSOS_SECTION();

            /*" -2789- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4210-00-MONTA-COBRANCA-SECTION */
        private void R4210_00_MONTA_COBRANCA_SECTION()
        {
            /*" -2797- MOVE '4210' TO WNR-EXEC-SQL */
            _.Move("4210", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2798- MOVE 'R4210-00-MONTA-COBRANCA' TO PARAGRAFO */
            _.Move("R4210-00-MONTA-COBRANCA", AREA_DE_WORK.PARAGRAFO);

            /*" -2801- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2802- IF HISCONPA-NUM-ENDOSSO EQUAL ZEROS */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO == 00)
            {

                /*" -2803- DISPLAY 'MOVIMENTO FINANCEIRO SEM ENDOSSO EMITIDO.' */
                _.Display($"MOVIMENTO FINANCEIRO SEM ENDOSSO EMITIDO.");

                /*" -2804- DISPLAY 'VERIFICAR O FATURAMENTO DO CERTIFICAO.' */
                _.Display($"VERIFICAR O FATURAMENTO DO CERTIFICAO.");

                /*" -2805- DISPLAY 'CERTIFICADO ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -2806- DISPLAY 'PARCELA     ' HISCONPA-NUM-PARCELA */
                _.Display($"PARCELA     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -2807- DISPLAY 'APOLICE     ' HISCONPA-NUM-APOLICE */
                _.Display($"APOLICE     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                /*" -2808- DISPLAY 'ENDOSSO     ' HISCONPA-NUM-ENDOSSO */
                _.Display($"ENDOSSO     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                /*" -2809- MOVE +9999 TO SQLCODE */
                _.Move(+9999, DB.SQLCODE);

                /*" -2810- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2815- END-IF */
            }


            /*" -2816- IF PARCELAS-SIT-REGISTRO NOT EQUAL '0' */

            if (PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO != "0")
            {

                /*" -2817- DISPLAY 'ENDOSSO JA BAIXADO. ANALISAR O MOTIVO.' */
                _.Display($"ENDOSSO JA BAIXADO. ANALISAR O MOTIVO.");

                /*" -2818- DISPLAY 'NAO PODE OCORRER 2 BAIXAS PARA O MESMO ENDOSSO.' */
                _.Display($"NAO PODE OCORRER 2 BAIXAS PARA O MESMO ENDOSSO.");

                /*" -2819- DISPLAY 'CERTIFICADO ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -2820- DISPLAY 'PARCELA     ' HISCONPA-NUM-PARCELA */
                _.Display($"PARCELA     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -2821- DISPLAY 'APOLICE     ' HISCONPA-NUM-APOLICE */
                _.Display($"APOLICE     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                /*" -2822- DISPLAY 'ENDOSSO     ' HISCONPA-NUM-ENDOSSO */
                _.Display($"ENDOSSO     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                /*" -2823- MOVE +9999 TO SQLCODE */
                _.Move(+9999, DB.SQLCODE);

                /*" -2824- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2826- END-IF */
            }


            /*" -2827- MOVE HISCONPA-NUM-APOLICE TO PARCEHIS-NUM-APOLICE */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -2829- MOVE HISCONPA-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -2830- MOVE PARCELAS-DAC-PARCELA TO PARCEHIS-DAC-PARCELA */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -2831- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -2833- MOVE 221 TO PARCEHIS-COD-OPERACAO */
            _.Move(221, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -2834- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -2835- MOVE WS-HH-TIME TO WS-HORA-HH-EDIT */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WS_HORA_EDIT.WS_HORA_HH_EDIT);

            /*" -2836- MOVE WS-MM-TIME TO WS-HORA-MM-EDIT */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WS_HORA_EDIT.WS_HORA_MM_EDIT);

            /*" -2837- MOVE WS-SS-TIME TO WS-HORA-SS-EDIT */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WS_HORA_EDIT.WS_HORA_SS_EDIT);

            /*" -2839- MOVE WS-HORA-EDIT TO PARCEHIS-HORA-OPERACAO */
            _.Move(AREA_DE_WORK.WS_HORA_EDIT, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_HORA_OPERACAO);

            /*" -2840- PERFORM R4215-00-RECUP-DADOS-HISTORICO */

            R4215_00_RECUP_DADOS_HISTORICO_SECTION();

            /*" -2841- ADD 1 TO PARCEHIS-OCORR-HISTORICO */
            PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO + 1;

            /*" -2842- MOVE MOVIMCOB-COD-BANCO TO PARCEHIS-BCO-COBRANCA */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -2843- MOVE MOVIMCOB-COD-AGENCIA TO PARCEHIS-AGE-COBRANCA */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -2844- MOVE MOVIMCOB-NUM-AVISO TO PARCEHIS-NUM-AVISO-CREDITO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -2845- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -2847- MOVE '0' TO PARCEHIS-SIT-CONTABIL */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -2848- MOVE 'CB0124B' TO PARCEHIS-COD-USUARIO */
            _.Move("CB0124B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -2849- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -2850- MOVE MOVIMCOB-DATA-QUITACAO TO PARCEHIS-DATA-QUITACAO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -2858- MOVE ZEROS TO PARCEHIS-COD-EMPRESA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -2859- IF PARCEHIS-PRM-TOTAL NOT EQUAL MCIELO-VLR-COBRANCA */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL != REG_CIELO.MCIELO_VLR_COBRANCA)
            {

                /*" -2860- DISPLAY 'ERRO - VALORES DIFERENTES' */
                _.Display($"ERRO - VALORES DIFERENTES");

                /*" -2862- DISPLAY 'PREMIO TOTAL COBRADO NO CARTAO = ' PARCEHIS-PRM-TOTAL */
                _.Display($"PREMIO TOTAL COBRADO NO CARTAO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL}");

                /*" -2864- DISPLAY 'PREMIO TOTAL RETORNADO DO SAP  = ' MCIELO-VLR-COBRANCA */
                _.Display($"PREMIO TOTAL RETORNADO DO SAP  = {REG_CIELO.MCIELO_VLR_COBRANCA}");

                /*" -2866- END-IF */
            }


            /*" -2867- MOVE MCIELO-VLR-COBRANCA TO PARCEHIS-VAL-OPERACAO */
            _.Move(REG_CIELO.MCIELO_VLR_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -2867- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4210_99_SAIDA*/

        [StopWatch]
        /*" R4215-00-RECUP-DADOS-HISTORICO-SECTION */
        private void R4215_00_RECUP_DADOS_HISTORICO_SECTION()
        {
            /*" -2875- MOVE '4215' TO WNR-EXEC-SQL */
            _.Move("4215", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2876- MOVE 'R4215-00-RECUP-DADOS-HISTORICO' TO PARAGRAFO */
            _.Move("R4215-00-RECUP-DADOS-HISTORICO", AREA_DE_WORK.PARAGRAFO);

            /*" -2878- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -2879- MOVE HISCONPA-NUM-APOLICE TO PARCEHIS-NUM-APOLICE */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -2881- MOVE HISCONPA-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -2883- MOVE ZEROS TO PARCEHIS-NUM-PARCELA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -2915- PERFORM R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1 */

            R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1();

            /*" -2918-  EVALUATE SQLCODE  */

            /*" -2919-  WHEN ZEROS  */

            /*" -2919- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2920- CONTINUE */

                /*" -2921-  WHEN -811  */

                /*" -2921- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -2922- DISPLAY '4215-00-TITULO DUPLICADO PARCELA_HISTORICO' */
                _.Display($"4215-00-TITULO DUPLICADO PARCELA_HISTORICO");

                /*" -2923- DISPLAY 'APOLICE  ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -2924- DISPLAY 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -2925- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2926-  WHEN +100  */

                /*" -2926- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2927- DISPLAY '4215-NAO ACHOU REGISTRO PARCELA_HISTORICO' */
                _.Display($"4215-NAO ACHOU REGISTRO PARCELA_HISTORICO");

                /*" -2928- DISPLAY 'APOLICE  ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -2929- DISPLAY 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -2930- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2931-  WHEN OTHER  */

                /*" -2931- ELSE */
            }
            else
            {


                /*" -2932- DISPLAY '4215-ERRO NO ACESSO PARCELA_HISTORICO' */
                _.Display($"4215-ERRO NO ACESSO PARCELA_HISTORICO");

                /*" -2933- DISPLAY 'APOLICE  ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -2934- DISPLAY 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -2935- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2935-  END-EVALUATE.  */

                /*" -2935- END-IF. */
            }


        }

        [StopWatch]
        /*" R4215-00-RECUP-DADOS-HISTORICO-DB-SELECT-1 */
        public void R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1()
        {
            /*" -2915- EXEC SQL SELECT A.DATA_VENCIMENTO , A.OCORR_HISTORICO , A.PRM_TARIFARIO , A.VAL_DESCONTO , A.PRM_LIQUIDO , A.ADICIONAL_FRACIO , A.VAL_CUSTO_EMISSAO , A.VAL_IOCC , A.PRM_TOTAL , A.NUM_PARCELA INTO :PARCEHIS-DATA-VENCIMENTO , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-PRM-LIQUIDO , :PARCEHIS-ADICIONAL-FRACIO , :PARCEHIS-VAL-CUSTO-EMISSAO , :PARCEHIS-VAL-IOCC , :PARCEHIS-PRM-TOTAL , :PARCEHIS-NUM-PARCELA FROM SEGUROS.PARCELA_HISTORICO A ,SEGUROS.PARCELAS B WHERE A.NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND A.NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND A.NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA AND A.OCORR_HISTORICO = B.OCORR_HISTORICO WITH UR END-EXEC */

            var r4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1 = new R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1.Execute(r4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4215_99_SAIDA*/

        [StopWatch]
        /*" R4220-00-INSERT-PARCELA-HIS-SECTION */
        private void R4220_00_INSERT_PARCELA_HIS_SECTION()
        {
            /*" -2943- MOVE '4220' TO WNR-EXEC-SQL */
            _.Move("4220", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2944- MOVE 'R4220-00-INSERT-PARCELA-HIS' TO PARAGRAFO */
            _.Move("R4220-00-INSERT-PARCELA-HIS", AREA_DE_WORK.PARAGRAFO);

            /*" -2946- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3004- PERFORM R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1 */

            R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1();

            /*" -3007-  EVALUATE SQLCODE  */

            /*" -3008-  WHEN ZEROS  */

            /*" -3008- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3009- SUBTRACT PARCEHIS-PRM-TOTAL FROM WS-SDOATUAL */
                AREA_DE_WORK.WS_SDOATUAL.Value = AREA_DE_WORK.WS_SDOATUAL - PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                /*" -3010-  WHEN -803  */

                /*" -3010- ELSE IF   SQLCODE EQUALS  -803 */
            }
            else

            if (DB.SQLCODE == -803)
            {

                /*" -3015- DISPLAY '4220- (REG DUPLICADO) PARCELA_HISTORICO ' 'APOLICE  ' PARCEHIS-NUM-APOLICE 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO 'NRO PARC ' PARCEHIS-NUM-PARCELA */

                $"4220- (REG DUPLICADO) PARCELA_HISTORICO APOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}NRO PARC {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -3016- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3017-  WHEN OTHER  */

                /*" -3017- ELSE */
            }
            else
            {


                /*" -3022- DISPLAY '4220-ERRO-PROBLEMAS NA INSERCAO PARCELA_HISTORICO' 'APOLICE  ' PARCEHIS-NUM-APOLICE 'ENDOSSO  ' PARCEHIS-NUM-ENDOSSO 'NRO PARC ' PARCEHIS-NUM-PARCELA */

                $"4220-ERRO-PROBLEMAS NA INSERCAO PARCELA_HISTORICOAPOLICE  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}ENDOSSO  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}NRO PARC {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -3023- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3025-  END-EVALUATE  */

                /*" -3025- END-IF */
            }


            /*" -3025- ADD 1 TO WS-IN-PARCEHIS. */
            AREA_DE_WORK.WS_IN_PARCEHIS.Value = AREA_DE_WORK.WS_IN_PARCEHIS + 1;

        }

        [StopWatch]
        /*" R4220-00-INSERT-PARCELA-HIS-DB-INSERT-1 */
        public void R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1()
        {
            /*" -3004- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO ( NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , COD_OPERACAO , HORA_OPERACAO , OCORR_HISTORICO , PRM_TARIFARIO , VAL_DESCONTO , PRM_LIQUIDO , ADICIONAL_FRACIO , VAL_CUSTO_EMISSAO , VAL_IOCC , PRM_TOTAL , VAL_OPERACAO , DATA_VENCIMENTO , BCO_COBRANCA , AGE_COBRANCA , NUM_AVISO_CREDITO , ENDOS_CANCELA , SIT_CONTABIL , COD_USUARIO , RENUM_DOCUMENTO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP ) VALUES ( :PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-DAC-PARCELA , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-COD-OPERACAO , :PARCEHIS-HORA-OPERACAO , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-PRM-LIQUIDO , :PARCEHIS-ADICIONAL-FRACIO , :PARCEHIS-VAL-CUSTO-EMISSAO , :PARCEHIS-VAL-IOCC , :PARCEHIS-PRM-TOTAL , :PARCEHIS-VAL-OPERACAO , :PARCEHIS-DATA-VENCIMENTO , :PARCEHIS-BCO-COBRANCA , :PARCEHIS-AGE-COBRANCA , :PARCEHIS-NUM-AVISO-CREDITO , :PARCEHIS-ENDOS-CANCELA , :PARCEHIS-SIT-CONTABIL , :PARCEHIS-COD-USUARIO , :PARCEHIS-RENUM-DOCUMENTO , :PARCEHIS-DATA-QUITACAO:VIND-DTQITBCO , :PARCEHIS-COD-EMPRESA , CURRENT TIMESTAMP ) END-EXEC */

            var r4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1 = new R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1()
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

            R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1.Execute(r4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4220_99_SAIDA*/

        [StopWatch]
        /*" R4230-00-ATUALIZA-PARCELAS-SECTION */
        private void R4230_00_ATUALIZA_PARCELAS_SECTION()
        {
            /*" -3033- MOVE '4230' TO WNR-EXEC-SQL */
            _.Move("4230", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3034- MOVE 'R4230-00-ATUALIZA-PARCELAS' TO PARAGRAFO */
            _.Move("R4230-00-ATUALIZA-PARCELAS", AREA_DE_WORK.PARAGRAFO);

            /*" -3036- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3042- PERFORM R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1 */

            R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1();

            /*" -3045- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3046- DISPLAY '4230 - PROBLEMAS UPDATE PARCELAS' */
                _.Display($"4230 - PROBLEMAS UPDATE PARCELAS");

                /*" -3047- DISPLAY 'NUM-APOLICE = ' HISCONPA-NUM-APOLICE */
                _.Display($"NUM-APOLICE = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                /*" -3048- DISPLAY 'NUM-ENDOSSO = ' HISCONPA-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                /*" -3049- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3051- END-IF */
            }


            /*" -3051- ADD 1 TO WS-UP-PARCELAS. */
            AREA_DE_WORK.WS_UP_PARCELAS.Value = AREA_DE_WORK.WS_UP_PARCELAS + 1;

        }

        [StopWatch]
        /*" R4230-00-ATUALIZA-PARCELAS-DB-UPDATE-1 */
        public void R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1()
        {
            /*" -3042- EXEC SQL UPDATE SEGUROS.PARCELAS SET SIT_REGISTRO = '1' , OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO END-EXEC */

            var r4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1 = new R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1()
            {
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1.Execute(r4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4230_99_SAIDA*/

        [StopWatch]
        /*" R4240-00-ATUALIZA-ENDOSSOS-SECTION */
        private void R4240_00_ATUALIZA_ENDOSSOS_SECTION()
        {
            /*" -3060- MOVE '4240' TO WNR-EXEC-SQL */
            _.Move("4240", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3061- MOVE 'R4240-00-ATUALIZA-ENDOSSOS' TO PARAGRAFO */
            _.Move("R4240-00-ATUALIZA-ENDOSSOS", AREA_DE_WORK.PARAGRAFO);

            /*" -3063- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3068- PERFORM R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1 */

            R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1();

            /*" -3071- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3072- DISPLAY '4240 - PROBLEMAS UPDATE ENDOSSOS' */
                _.Display($"4240 - PROBLEMAS UPDATE ENDOSSOS");

                /*" -3073- DISPLAY 'NUM-APOLICE = ' HISCONPA-NUM-APOLICE */
                _.Display($"NUM-APOLICE = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                /*" -3074- DISPLAY 'NUM-ENDOSSO = ' HISCONPA-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                /*" -3075- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3077- END-IF */
            }


            /*" -3077- ADD 1 TO WS-UP-ENDOSSOS. */
            AREA_DE_WORK.WS_UP_ENDOSSOS.Value = AREA_DE_WORK.WS_UP_ENDOSSOS + 1;

        }

        [StopWatch]
        /*" R4240-00-ATUALIZA-ENDOSSOS-DB-UPDATE-1 */
        public void R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -3068- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET SIT_REGISTRO = '1' WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO END-EXEC */

            var r4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1 = new R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4240_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-PROCESSA-FINAL-SECTION */
        private void R5000_00_PROCESSA_FINAL_SECTION()
        {
            /*" -3085- MOVE '5000' TO WNR-EXEC-SQL */
            _.Move("5000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3086- MOVE 'R5000-00-PROCESSA-FINAL' TO PARAGRAFO */
            _.Move("R5000-00-PROCESSA-FINAL", AREA_DE_WORK.PARAGRAFO);

            /*" -3088- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3090- PERFORM R5010-00-INSERT-AVISO-CREDITO */

            R5010_00_INSERT_AVISO_CREDITO_SECTION();

            /*" -3092- PERFORM R5020-00-INSERT-AVISOS-SALDOS */

            R5020_00_INSERT_AVISOS_SALDOS_SECTION();

            /*" -3093- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -3093- PERFORM R5100-00-GRAVA-DESPESAS 8000 TIMES. */

            for (int i = 0; i < 8000; i++)
            {

                R5100_00_GRAVA_DESPESAS_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5010-00-INSERT-AVISO-CREDITO-SECTION */
        private void R5010_00_INSERT_AVISO_CREDITO_SECTION()
        {
            /*" -3101- MOVE '5010' TO WNR-EXEC-SQL. */
            _.Move("5010", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3102- MOVE 'R5010-00-INSERT-AVISO-CREDITO' TO PARAGRAFO. */
            _.Move("R5010-00-INSERT-AVISO-CREDITO", AREA_DE_WORK.PARAGRAFO);

            /*" -3104- DISPLAY PARAGRAFO. */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3105- MOVE 2 TO AVISOCRE-ORIGEM-AVISO */
            _.Move(2, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);

            /*" -3106- MOVE 104 TO AVISOCRE-BCO-AVISO */
            _.Move(104, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);

            /*" -3107- MOVE 7011 TO AVISOCRE-AGE-AVISO */
            _.Move(7011, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);

            /*" -3108- MOVE 1 TO AVISOCRE-NUM-SEQUENCIA */
            _.Move(1, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA);

            /*" -3110- MOVE SISTEMAS-DATA-MOV-ABERTO TO AVISOCRE-DATA-MOVIMENTO AVISOCRE-DATA-AVISO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);

            /*" -3111- MOVE 100 TO AVISOCRE-COD-OPERACAO */
            _.Move(100, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO);

            /*" -3112- MOVE '0' TO AVISOCRE-SIT-CONTABIL */
            _.Move("0", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_SIT_CONTABIL);

            /*" -3113- MOVE 'D' TO AVISOCRE-TIPO-AVISO */
            _.Move("D", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO);

            /*" -3120- MOVE ZEROS TO AVISOCRE-PRM-COSSEGURO-CED AVISOCRE-COD-EMPRESA AVISOCRE-VAL-ADIANTAMENTO VIND-CODEMP VIND-ORIGEM VIND-VALADT. */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_COSSEGURO_CED, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_ADIANTAMENTO, AREA_DE_WORK.VIND_CODEMP, AREA_DE_WORK.VIND_ORIGEM, AREA_DE_WORK.VIND_VALADT);

            /*" -3122- MOVE 'P' TO AVISOCRE-STA-DEPOSITO-TER. */
            _.Move("P", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_STA_DEPOSITO_TER);

            /*" -3166- PERFORM R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1 */

            R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1();

            /*" -3169- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3170- DISPLAY '5010-00 - PROBLEMAS NO INSERT(AVISOCRE) ' */
                _.Display($"5010-00 - PROBLEMAS NO INSERT(AVISOCRE) ");

                /*" -3171- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3173- END-IF. */
            }


            /*" -3173- ADD 1 TO WS-IN-AVISOCRE. */
            AREA_DE_WORK.WS_IN_AVISOCRE.Value = AREA_DE_WORK.WS_IN_AVISOCRE + 1;

        }

        [StopWatch]
        /*" R5010-00-INSERT-AVISO-CREDITO-DB-INSERT-1 */
        public void R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1()
        {
            /*" -3166- EXEC SQL INSERT INTO SEGUROS.AVISO_CREDITO ( BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_SEQUENCIA , DATA_MOVIMENTO , COD_OPERACAO , TIPO_AVISO , DATA_AVISO , VAL_IOCC , VAL_DESPESA , PRM_COSSEGURO_CED , PRM_LIQUIDO , PRM_TOTAL , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP , ORIGEM_AVISO , VAL_ADIANTAMENTO , STA_DEPOSITO_TER ) VALUES ( :AVISOCRE-BCO-AVISO , :AVISOCRE-AGE-AVISO , :AVISOCRE-NUM-AVISO-CREDITO , :AVISOCRE-NUM-SEQUENCIA , :AVISOCRE-DATA-MOVIMENTO , :AVISOCRE-COD-OPERACAO , :AVISOCRE-TIPO-AVISO , :AVISOCRE-DATA-AVISO , :AVISOCRE-VAL-IOCC , :AVISOCRE-VAL-DESPESA , :AVISOCRE-PRM-COSSEGURO-CED , :AVISOCRE-PRM-LIQUIDO , :AVISOCRE-PRM-TOTAL , :AVISOCRE-SIT-CONTABIL , :AVISOCRE-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP , :AVISOCRE-ORIGEM-AVISO:VIND-ORIGEM , :AVISOCRE-VAL-ADIANTAMENTO:VIND-VALADT , :AVISOCRE-STA-DEPOSITO-TER ) END-EXEC. */

            var r5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1 = new R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1()
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

            R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1.Execute(r5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5010_99_SAIDA*/

        [StopWatch]
        /*" R5020-00-INSERT-AVISOS-SALDOS-SECTION */
        private void R5020_00_INSERT_AVISOS_SALDOS_SECTION()
        {
            /*" -3181- MOVE '5020' TO WNR-EXEC-SQL. */
            _.Move("5020", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3182- MOVE 'R5020-00-INSERT-AVISOS-SALDOS' TO PARAGRAFO. */
            _.Move("R5020-00-INSERT-AVISOS-SALDOS", AREA_DE_WORK.PARAGRAFO);

            /*" -3184- DISPLAY PARAGRAFO. */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3185- MOVE AVISOCRE-COD-EMPRESA TO AVISOSAL-COD-EMPRESA */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_COD_EMPRESA);

            /*" -3186- MOVE AVISOCRE-BCO-AVISO TO AVISOSAL-BCO-AVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO);

            /*" -3187- MOVE AVISOCRE-AGE-AVISO TO AVISOSAL-AGE-AVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO);

            /*" -3188- MOVE '1' TO AVISOSAL-TIPO-SEGURO */
            _.Move("1", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO);

            /*" -3189- MOVE AVISOCRE-NUM-AVISO-CREDITO TO AVISOSAL-NUM-AVISO-CREDITO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO);

            /*" -3190- MOVE AVISOCRE-DATA-AVISO TO AVISOSAL-DATA-AVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO);

            /*" -3191- MOVE AVISOCRE-DATA-MOVIMENTO TO AVISOSAL-DATA-MOVIMENTO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO);

            /*" -3192- MOVE ZEROS TO AVISOSAL-SALDO-ATUAL */
            _.Move(0, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);

            /*" -3194- MOVE '0' TO AVISOSAL-SIT-REGISTRO. */
            _.Move("0", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO);

            /*" -3220- PERFORM R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1 */

            R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1();

            /*" -3223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3224- DISPLAY 'R5020-00 - PROBLEMAS NO INSERT(AVISOSAL)   ' */
                _.Display($"R5020-00 - PROBLEMAS NO INSERT(AVISOSAL)   ");

                /*" -3225- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3227- END-IF. */
            }


            /*" -3227- ADD 1 TO WS-IN-AVISOSAL. */
            AREA_DE_WORK.WS_IN_AVISOSAL.Value = AREA_DE_WORK.WS_IN_AVISOSAL + 1;

        }

        [StopWatch]
        /*" R5020-00-INSERT-AVISOS-SALDOS-DB-INSERT-1 */
        public void R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1()
        {
            /*" -3220- EXEC SQL INSERT INTO SEGUROS.AVISOS_SALDOS ( COD_EMPRESA , BCO_AVISO , AGE_AVISO , TIPO_SEGURO , NUM_AVISO_CREDITO , DATA_AVISO , DATA_MOVIMENTO , SALDO_ATUAL , SIT_REGISTRO , TIMESTAMP ) VALUES ( :AVISOSAL-COD-EMPRESA , :AVISOSAL-BCO-AVISO , :AVISOSAL-AGE-AVISO , :AVISOSAL-TIPO-SEGURO , :AVISOSAL-NUM-AVISO-CREDITO , :AVISOSAL-DATA-AVISO , :AVISOSAL-DATA-MOVIMENTO , :AVISOSAL-SALDO-ATUAL , :AVISOSAL-SIT-REGISTRO , CURRENT TIMESTAMP ) END-EXEC. */

            var r5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1 = new R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1()
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

            R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1.Execute(r5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5020_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-GRAVA-DESPESAS-SECTION */
        private void R5100_00_GRAVA_DESPESAS_SECTION()
        {
            /*" -3235- MOVE '5100' TO WNR-EXEC-SQL */
            _.Move("5100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3236- MOVE 'R5100-00-GRAVA-DESPESAS' TO PARAGRAFO */
            _.Move("R5100-00-GRAVA-DESPESAS", AREA_DE_WORK.PARAGRAFO);

            /*" -3238- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3239- IF WS-TABG-CODPRODU(WS-PRD) EQUAL 9999 */

            if (AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_CODPRODU == 9999)
            {

                /*" -3240- SET WS-PRD UP BY 1 */
                WS_PRD.Value += 1;

                /*" -3241- ELSE */
            }
            else
            {


                /*" -3242- MOVE AVISOCRE-COD-EMPRESA TO CONDESCE-COD-EMPRESA */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA);

                /*" -3243- MOVE AVISOCRE-DATA-AVISO TO WS-DATA-REL */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, AREA_DE_WORK.WS_DATA_REL);

                /*" -3244- MOVE WS-DAT-REL-ANO TO CONDESCE-ANO-REFERENCIA */
                _.Move(AREA_DE_WORK.FILLER_9.WS_DAT_REL_ANO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA);

                /*" -3245- MOVE WS-DAT-REL-MES TO CONDESCE-MES-REFERENCIA */
                _.Move(AREA_DE_WORK.FILLER_9.WS_DAT_REL_MES, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA);

                /*" -3246- MOVE AVISOCRE-BCO-AVISO TO CONDESCE-BCO-AVISO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO);

                /*" -3247- MOVE AVISOCRE-AGE-AVISO TO CONDESCE-AGE-AVISO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO);

                /*" -3249- MOVE AVISOCRE-NUM-AVISO-CREDITO TO CONDESCE-NUM-AVISO-CREDITO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO);

                /*" -3251- MOVE WS-TABG-CODPRODU(WS-PRD) TO CONDESCE-COD-PRODUTO */
                _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_CODPRODU, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO);

                /*" -3252- MOVE '2' TO CONDESCE-TIPO-COBRANCA */
                _.Move("2", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_COBRANCA);

                /*" -3254- MOVE AVISOCRE-DATA-MOVIMENTO TO CONDESCE-DATA-MOVIMENTO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO);

                /*" -3255- MOVE AVISOCRE-DATA-AVISO TO CONDESCE-DATA-AVISO */
                _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO);

                /*" -3258- MOVE ZEROS TO CONDESCE-VAL-JUROS CONDESCE-VAL-MULTA */
                _.Move(0, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA);

                /*" -3259- SET WS-TIP TO 1 */
                WS_TIP.Value = 1;

                /*" -3260- PERFORM R5110-00-GRAVA-TIPO 03 TIMES */

                for (int i = 0; i < 3; i++)
                {

                    R5110_00_GRAVA_TIPO_SECTION();

                }

                /*" -3261- SET WS-PRD UP BY 1 */
                WS_PRD.Value += 1;

                /*" -3261- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5110-00-GRAVA-TIPO-SECTION */
        private void R5110_00_GRAVA_TIPO_SECTION()
        {
            /*" -3270- MOVE '5110' TO WNR-EXEC-SQL */
            _.Move("5110", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3271- MOVE 'R5110-00-GRAVA-TIPO' TO PARAGRAFO */
            _.Move("R5110-00-GRAVA-TIPO", AREA_DE_WORK.PARAGRAFO);

            /*" -3273- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3276- MOVE WS-TABG-TIPO(WS-PRD WS-TIP) TO CONDESCE-TIPO-REGISTRO */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_TIPO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_REGISTRO);

            /*" -3277- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -3278- PERFORM R5120-00-GRAVA-REGISTRO 02 TIMES */

            for (int i = 0; i < 2; i++)
            {

                R5120_00_GRAVA_REGISTRO_SECTION();

            }

            /*" -3278- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5110_99_SAIDA*/

        [StopWatch]
        /*" R5120-00-GRAVA-REGISTRO-SECTION */
        private void R5120_00_GRAVA_REGISTRO_SECTION()
        {
            /*" -3286- MOVE '5120' TO WNR-EXEC-SQL */
            _.Move("5120", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3287- MOVE 'R5120-00-GRAVA-REGISTRO' TO PARAGRAFO */
            _.Move("R5120-00-GRAVA-REGISTRO", AREA_DE_WORK.PARAGRAFO);

            /*" -3289- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3291- MOVE WS-TABG-SITUACAO(WS-PRD WS-TIP WS-SIT) TO CONDESCE-SITUACAO */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_SITUACAO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_SITUACAO);

            /*" -3293- MOVE WS-TABG-QTDE (WS-PRD WS-TIP WS-SIT) TO CONDESCE-QTD-REGISTROS */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS);

            /*" -3295- MOVE WS-TABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) TO CONDESCE-PRM-TOTAL */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL);

            /*" -3297- MOVE WS-TABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) TO CONDESCE-VAL-TARIFA */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA);

            /*" -3299- MOVE WS-TABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) TO CONDESCE-VAL-BALCAO */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO);

            /*" -3301- MOVE WS-TABG-VLIOCC (WS-PRD WS-TIP WS-SIT) TO CONDESCE-VAL-IOCC */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC);

            /*" -3304- MOVE WS-TABG-VLDESCON(WS-PRD WS-TIP WS-SIT) TO CONDESCE-VAL-DESCONTO */
            _.Move(AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO);

            /*" -3314- COMPUTE CONDESCE-PRM-LIQUIDO EQUAL (CONDESCE-PRM-TOTAL - CONDESCE-VAL-TARIFA - CONDESCE-VAL-BALCAO - CONDESCE-VAL-IOCC - CONDESCE-VAL-DESCONTO - CONDESCE-VAL-JUROS - CONDESCE-VAL-MULTA) */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO.Value = (CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA);

            /*" -3319- IF (CONDESCE-QTD-REGISTROS EQUAL ZEROS AND CONDESCE-PRM-TOTAL EQUAL ZEROS AND CONDESCE-PRM-LIQUIDO EQUAL ZEROS AND CONDESCE-VAL-TARIFA EQUAL ZEROS AND CONDESCE-VAL-BALCAO EQUAL ZEROS ) */

            if ((CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS == 00 && CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL == 00 && CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO == 00 && CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA == 00 && CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO == 00))
            {

                /*" -3320- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -3321- ELSE */
            }
            else
            {


                /*" -3323- PERFORM R5500-00-INSERT-DESPESAS */

                R5500_00_INSERT_DESPESAS_SECTION();

                /*" -3330- MOVE ZEROS TO WS-TABG-QTDE (WS-PRD WS-TIP WS-SIT) WS-TABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WS-TABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WS-TABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WS-TABG-VLIOCC (WS-PRD WS-TIP WS-SIT) WS-TABG-VLDESCON(WS-PRD WS-TIP WS-SIT) */
                _.Move(0, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_QTDE, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLPRMTOT, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLTARIFA, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLBALCAO, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLIOCC, AUX_TABELAS.WS_TABG_VALORES.WS_TABG_OCORREPRD[WS_PRD].WS_TABG_OCORRETIP[WS_TIP].WS_TABG_OCORRESIT[WS_SIT].WS_TABG_VLDESCON);

                /*" -3331- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -3331- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5120_99_SAIDA*/

        [StopWatch]
        /*" R5500-00-INSERT-DESPESAS-SECTION */
        private void R5500_00_INSERT_DESPESAS_SECTION()
        {
            /*" -3339- MOVE '5500' TO WNR-EXEC-SQL */
            _.Move("5500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3340- MOVE 'R5500-00-INSERT-DESPESAS' TO PARAGRAFO */
            _.Move("R5500-00-INSERT-DESPESAS", AREA_DE_WORK.PARAGRAFO);

            /*" -3342- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3392- PERFORM R5500_00_INSERT_DESPESAS_DB_INSERT_1 */

            R5500_00_INSERT_DESPESAS_DB_INSERT_1();

            /*" -3395- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3396- DISPLAY '5500-00 - PROBLEMAS INSERT (DESPESAS)   ' */
                _.Display($"5500-00 - PROBLEMAS INSERT (DESPESAS)   ");

                /*" -3397- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3399- END-IF */
            }


            /*" -3399- ADD 1 TO WS-IN-CONDESCE. */
            AREA_DE_WORK.WS_IN_CONDESCE.Value = AREA_DE_WORK.WS_IN_CONDESCE + 1;

        }

        [StopWatch]
        /*" R5500-00-INSERT-DESPESAS-DB-INSERT-1 */
        public void R5500_00_INSERT_DESPESAS_DB_INSERT_1()
        {
            /*" -3392- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF ( COD_EMPRESA , ANO_REFERENCIA , MES_REFERENCIA , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_PRODUTO , TIPO_REGISTRO , SITUACAO , TIPO_COBRANCA , DATA_MOVIMENTO , DATA_AVISO , QTD_REGISTROS , PRM_TOTAL , PRM_LIQUIDO , VAL_TARIFA , VAL_BALCAO , VAL_IOCC , VAL_DESCONTO , VAL_JUROS , VAL_MULTA , TIMESTAMP ) VALUES ( :CONDESCE-COD-EMPRESA , :CONDESCE-ANO-REFERENCIA , :CONDESCE-MES-REFERENCIA , :CONDESCE-BCO-AVISO , :CONDESCE-AGE-AVISO , :CONDESCE-NUM-AVISO-CREDITO , :CONDESCE-COD-PRODUTO , :CONDESCE-TIPO-REGISTRO , :CONDESCE-SITUACAO , :CONDESCE-TIPO-COBRANCA , :CONDESCE-DATA-MOVIMENTO , :CONDESCE-DATA-AVISO , :CONDESCE-QTD-REGISTROS , :CONDESCE-PRM-TOTAL , :CONDESCE-PRM-LIQUIDO , :CONDESCE-VAL-TARIFA , :CONDESCE-VAL-BALCAO , :CONDESCE-VAL-IOCC , :CONDESCE-VAL-DESCONTO , :CONDESCE-VAL-JUROS , :CONDESCE-VAL-MULTA , CURRENT TIMESTAMP ) END-EXEC */

            var r5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 = new R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1()
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

            R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1.Execute(r5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-UPDATE-HIST-LANC-CTA-SECTION */
        private void R6010_00_UPDATE_HIST_LANC_CTA_SECTION()
        {
            /*" -3408- MOVE '6010' TO WNR-EXEC-SQL */
            _.Move("6010", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3409- MOVE 'R6010-00-UPDATE-HIST-LANC-CTA' TO PARAGRAFO */
            _.Move("R6010-00-UPDATE-HIST-LANC-CTA", AREA_DE_WORK.PARAGRAFO);

            /*" -3411- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3423- PERFORM R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1 */

            R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1();

            /*" -3426- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3427- DISPLAY '6010 - PROBLEMAS  UPDATE HIST_LANC_CTA ' */
                _.Display($"6010 - PROBLEMAS  UPDATE HIST_LANC_CTA ");

                /*" -3428- DISPLAY 'CODCONV = ' HISLANCT-CODCONV */
                _.Display($"CODCONV = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV}");

                /*" -3429- DISPLAY 'NSAS    = ' HISLANCT-NSAS */
                _.Display($"NSAS    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS}");

                /*" -3430- DISPLAY 'NSL     = ' HISLANCT-NSL */
                _.Display($"NSL     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL}");

                /*" -3431- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3433- END-IF */
            }


            /*" -3433- ADD 1 TO WS-UP-HIS-LANC-CTA. */
            AREA_DE_WORK.WS_UP_HIS_LANC_CTA.Value = AREA_DE_WORK.WS_UP_HIS_LANC_CTA + 1;

        }

        [StopWatch]
        /*" R6010-00-UPDATE-HIST-LANC-CTA-DB-UPDATE-1 */
        public void R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1()
        {
            /*" -3423- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = :HISLANCT-SIT-REGISTRO , NSAC = :HISLANCT-NSAC , OCORR_HISTORICO = OCORR_HISTORICO + 1 , CODRET = :HISLANCT-CODRET , TIMESTAMP = CURRENT TIMESTAMP , COD_USUARIO = 'CB0124B' WHERE CODCONV = :HISLANCT-CODCONV AND NSAS = :HISLANCT-NSAS AND NSL = :HISLANCT-NSL AND SIT_REGISTRO = '3' END-EXEC */

            var r6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 = new R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1()
            {
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_CODRET = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET.ToString(),
                HISLANCT_NSAC = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC.ToString(),
                HISLANCT_CODCONV = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.ToString(),
                HISLANCT_NSAS = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS.ToString(),
                HISLANCT_NSL = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL.ToString(),
            };

            R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1.Execute(r6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-TRATA-RETORNO-CHARGE-SECTION */
        private void R7000_00_TRATA_RETORNO_CHARGE_SECTION()
        {
            /*" -3443- MOVE '7000' TO WNR-EXEC-SQL */
            _.Move("7000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3444- MOVE 'R7000-00-TRATA-RETORNO-CHARGE' TO PARAGRAFO */
            _.Move("R7000-00-TRATA-RETORNO-CHARGE", AREA_DE_WORK.PARAGRAFO);

            /*" -3446- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3448- PERFORM R7030-00-SELECT-PROPOSTAS-VA */

            R7030_00_SELECT_PROPOSTAS_VA_SECTION();

            /*" -3449- IF V0PROP-SITUACAO NOT EQUAL '2' AND '4' */

            if (!AREA_DE_WORK.V0PROP_SITUACAO.In("2", "4"))
            {

                /*" -3451- PERFORM R7060-00-INSERT-MOVIMENTO-CANC */

                R7060_00_INSERT_MOVIMENTO_CANC_SECTION();

                /*" -3452- PERFORM R7010-00-UPDATE-PROPOSTA-VA */

                R7010_00_UPDATE_PROPOSTA_VA_SECTION();

                /*" -3454- END-IF */
            }


            /*" -3456- PERFORM R7100-00-TRATA-DEVOL-PARC */

            R7100_00_TRATA_DEVOL_PARC_SECTION();

            /*" -3457- PERFORM R7250-00-INSERE-INFO-CHRGBACK */

            R7250_00_INSERE_INFO_CHRGBACK_SECTION();

            /*" -3457- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7010-00-UPDATE-PROPOSTA-VA-SECTION */
        private void R7010_00_UPDATE_PROPOSTA_VA_SECTION()
        {
            /*" -3466- MOVE '7010' TO WNR-EXEC-SQL */
            _.Move("7010", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3467- MOVE 'R7010-00-UPDATE-PROPOSTA-VA' TO PARAGRAFO */
            _.Move("R7010-00-UPDATE-PROPOSTA-VA", AREA_DE_WORK.PARAGRAFO);

            /*" -3469- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3476- PERFORM R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1 */

            R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1();

            /*" -3479- IF SQLCODE NOT EQUAL +0 */

            if (DB.SQLCODE != +0)
            {

                /*" -3480- DISPLAY '7000 - PROBLEMAS UPDATE PROPOSTAS_VA ' */
                _.Display($"7000 - PROBLEMAS UPDATE PROPOSTAS_VA ");

                /*" -3481- DISPLAY 'NUM-CERTIFICADO    => ' V0PROP-NRCERTIF */
                _.Display($"NUM-CERTIFICADO    => {AREA_DE_WORK.V0PROP_NRCERTIF}");

                /*" -3482- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3483- END-IF */
            }


            /*" -3483- . */

        }

        [StopWatch]
        /*" R7010-00-UPDATE-PROPOSTA-VA-DB-UPDATE-1 */
        public void R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1()
        {
            /*" -3476- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '4' , COD_USUARIO = 'CB0124B' , TIMESTAMP = CURRENT_TIMESTAMP , DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF END-EXEC */

            var r7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1 = new R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                V0PROP_NRCERTIF = AREA_DE_WORK.V0PROP_NRCERTIF.ToString(),
            };

            R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1.Execute(r7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7010_99_SAIDA*/

        [StopWatch]
        /*" R7020-00-SELECT-SEGURADO-VG-SECTION */
        private void R7020_00_SELECT_SEGURADO_VG_SECTION()
        {
            /*" -3492- MOVE '7020' TO WNR-EXEC-SQL */
            _.Move("7020", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3493- MOVE 'R7020-00-SELECT-SEGURADO-VG' TO PARAGRAFO */
            _.Move("R7020-00-SELECT-SEGURADO-VG", AREA_DE_WORK.PARAGRAFO);

            /*" -3496- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3511- PERFORM R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1 */

            R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1();

            /*" -3514- IF SQLCODE NOT EQUAL +0 */

            if (DB.SQLCODE != +0)
            {

                /*" -3515- DISPLAY '7020 - PROBLEMAS SELECT V0SEGURAVG ' */
                _.Display($"7020 - PROBLEMAS SELECT V0SEGURAVG ");

                /*" -3517- DISPLAY 'NUM-CERTIFICADO    => ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO    => {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -3518- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3519- END-IF */
            }


            /*" -3519- . */

        }

        [StopWatch]
        /*" R7020-00-SELECT-SEGURADO-VG-DB-SELECT-1 */
        public void R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1()
        {
            /*" -3511- EXEC SQL SELECT TIPO_INCLUSAO, COD_AGENCIADOR, NUM_ITEM, OCORR_HISTORICO, LOT_EMP_SEGURADO INTO :V0SEGU-TPINCLUS, :V0SEGU-AGENCIADOR, :V0SEGU-ITEM, :V0SEGU-OCORHIST, :V0SEGU-LOT-EMP-SEGURADO :VIND-LOT-EMP-SEG FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1 = new R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1.Execute(r7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGU_TPINCLUS, AREA_DE_WORK.V0SEGU_TPINCLUS);
                _.Move(executed_1.V0SEGU_AGENCIADOR, AREA_DE_WORK.V0SEGU_AGENCIADOR);
                _.Move(executed_1.V0SEGU_ITEM, AREA_DE_WORK.V0SEGU_ITEM);
                _.Move(executed_1.V0SEGU_OCORHIST, AREA_DE_WORK.V0SEGU_OCORHIST);
                _.Move(executed_1.V0SEGU_LOT_EMP_SEGURADO, AREA_DE_WORK.V0SEGU_LOT_EMP_SEGURADO);
                _.Move(executed_1.VIND_LOT_EMP_SEG, AREA_DE_WORK.VIND_LOT_EMP_SEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7020_99_SAIDA*/

        [StopWatch]
        /*" R7030-00-SELECT-PROPOSTAS-VA-SECTION */
        private void R7030_00_SELECT_PROPOSTAS_VA_SECTION()
        {
            /*" -3528- MOVE '7030' TO WNR-EXEC-SQL */
            _.Move("7030", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3529- MOVE 'R7030-00-SELECT-PROPOSTAS-VA' TO PARAGRAFO */
            _.Move("R7030-00-SELECT-PROPOSTAS-VA", AREA_DE_WORK.PARAGRAFO);

            /*" -3532- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3586- PERFORM R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1 */

            R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1();

            /*" -3589- IF SQLCODE NOT EQUAL +0 */

            if (DB.SQLCODE != +0)
            {

                /*" -3590- DISPLAY '7030 - PROBLEMAS SELECT V0PROPOSTAVA ' */
                _.Display($"7030 - PROBLEMAS SELECT V0PROPOSTAVA ");

                /*" -3592- DISPLAY 'NUM-CERTIFICADO    => ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO    => {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -3593- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3594- END-IF */
            }


            /*" -3594- . */

        }

        [StopWatch]
        /*" R7030-00-SELECT-PROPOSTAS-VA-DB-SELECT-1 */
        public void R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1()
        {
            /*" -3586- EXEC SQL SELECT B.NRCERTIF, B.FONTE, B.NUM_APOLICE, B.CODSUBES, B.CODPRODU, B.CODCLIEN, B.NRPARCE, B.SITUACAO, B.DTQITBCO, B.DTVENCTO, B.DTPROXVEN, B.NRPRIPARATZ, B.QTDPARATZ, VALUE(B.NUM_MATRICULA, 0), VALUE(B.DATA_ADMISSAO, '2001-01-01' ), B.TIMESTAMP, D.PERIPGTO, D.OPCAOPAG, VALUE(D.AGECTADEB, 0), VALUE(D.OPRCTADEB, 0), VALUE(D.NUMCTADEB, 0), VALUE(D.DIGCTADEB, 0), VALUE(D.NUM_CARTAO_CREDITO, '' ) INTO :V0PROP-NRCERTIF, :V0PROP-FONTE, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-CODPRODU, :V0PROP-CODCLIEN, :V0PROP-NRPARCEL, :V0PROP-SITUACAO, :V0PROP-DTQITBCO, :V0PROP-DTVENCTO, :V0PROP-DTPROXVEN, :V0PROP-NRPRIPARATZ, :V0PROP-QTDPARATZ, :V0PROP-NRMATRFUN, :V0PROP-DTADMISSAO, :V0PROP-TIMESTAMP, :V0OPCP-PERIPGTO, :V0OPCP-OPCAOPAG, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0OPCP-CARTAOCRED FROM SEGUROS.V0PROPOSTAVA B, SEGUROS.V0OPCAOPAGVA D WHERE B.NRCERTIF = :HISLANCT-NUM-CERTIFICADO AND D.NRCERTIF = B.NRCERTIF AND D.DTTERVIG = '9999-12-31' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1 = new R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1.Execute(r7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_NRCERTIF, AREA_DE_WORK.V0PROP_NRCERTIF);
                _.Move(executed_1.V0PROP_FONTE, AREA_DE_WORK.V0PROP_FONTE);
                _.Move(executed_1.V0PROP_NUM_APOLICE, AREA_DE_WORK.V0PROP_NUM_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, AREA_DE_WORK.V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_CODPRODU, AREA_DE_WORK.V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_CODCLIEN, AREA_DE_WORK.V0PROP_CODCLIEN);
                _.Move(executed_1.V0PROP_NRPARCEL, AREA_DE_WORK.V0PROP_NRPARCEL);
                _.Move(executed_1.V0PROP_SITUACAO, AREA_DE_WORK.V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_DTQITBCO, AREA_DE_WORK.V0PROP_DTQITBCO);
                _.Move(executed_1.V0PROP_DTVENCTO, AREA_DE_WORK.V0PROP_DTVENCTO);
                _.Move(executed_1.V0PROP_DTPROXVEN, AREA_DE_WORK.V0PROP_DTPROXVEN);
                _.Move(executed_1.V0PROP_NRPRIPARATZ, AREA_DE_WORK.V0PROP_NRPRIPARATZ);
                _.Move(executed_1.V0PROP_QTDPARATZ, AREA_DE_WORK.V0PROP_QTDPARATZ);
                _.Move(executed_1.V0PROP_NRMATRFUN, AREA_DE_WORK.V0PROP_NRMATRFUN);
                _.Move(executed_1.V0PROP_DTADMISSAO, AREA_DE_WORK.V0PROP_DTADMISSAO);
                _.Move(executed_1.V0PROP_TIMESTAMP, AREA_DE_WORK.V0PROP_TIMESTAMP);
                _.Move(executed_1.V0OPCP_PERIPGTO, AREA_DE_WORK.V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_OPCAOPAG, AREA_DE_WORK.V0OPCP_OPCAOPAG);
                _.Move(executed_1.V0OPCP_AGECTADEB, AREA_DE_WORK.V0OPCP_AGECTADEB);
                _.Move(executed_1.V0OPCP_OPRCTADEB, AREA_DE_WORK.V0OPCP_OPRCTADEB);
                _.Move(executed_1.V0OPCP_NUMCTADEB, AREA_DE_WORK.V0OPCP_NUMCTADEB);
                _.Move(executed_1.V0OPCP_DIGCTADEB, AREA_DE_WORK.V0OPCP_DIGCTADEB);
                _.Move(executed_1.V0OPCP_CARTAOCRED, AREA_DE_WORK.V0OPCP_CARTAOCRED);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7030_99_SAIDA*/

        [StopWatch]
        /*" R7040-00-RECUPERA-IS-PREMIO-SECTION */
        private void R7040_00_RECUPERA_IS_PREMIO_SECTION()
        {
            /*" -3604- MOVE '7040' TO WNR-EXEC-SQL */
            _.Move("7040", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3605- MOVE 'R7040-00-RECUPERA-IS-PREMIO' TO PARAGRAFO */
            _.Move("R7040-00-RECUPERA-IS-PREMIO", AREA_DE_WORK.PARAGRAFO);

            /*" -3610- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3624- PERFORM R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1 */

            R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1();

            /*" -3627- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3629- MOVE ZEROS TO V0COBA-IMPMORNATU V0COBA-PRMVG */
                _.Move(0, AREA_DE_WORK.V0COBA_IMPMORNATU, AREA_DE_WORK.V0COBA_PRMVG);

                /*" -3631- END-IF. */
            }


            /*" -3645- PERFORM R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2 */

            R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2();

            /*" -3648- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3650- MOVE ZEROS TO V0COBA-IMPMORACID V0COBA-PRMAP */
                _.Move(0, AREA_DE_WORK.V0COBA_IMPMORACID, AREA_DE_WORK.V0COBA_PRMAP);

                /*" -3652- END-IF */
            }


            /*" -3664- PERFORM R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3 */

            R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3();

            /*" -3667- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3668- MOVE 0 TO V0COBA-IMPINVPERM */
                _.Move(0, AREA_DE_WORK.V0COBA_IMPINVPERM);

                /*" -3670- END-IF */
            }


            /*" -3682- PERFORM R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4 */

            R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4();

            /*" -3685- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3686- MOVE 0 TO V0COBA-IMPDIT */
                _.Move(0, AREA_DE_WORK.V0COBA_IMPDIT);

                /*" -3686- END-IF. */
            }


        }

        [StopWatch]
        /*" R7040-00-RECUPERA-IS-PREMIO-DB-SELECT-1 */
        public void R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1()
        {
            /*" -3624- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORNATU, :V0COBA-PRMVG FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR = 93 AND MODALIFR >= 0 AND COD_COBERTURA = 11 WITH UR END-EXEC. */

            var r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1 = new R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1()
            {
                V0PROP_NUM_APOLICE = AREA_DE_WORK.V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = AREA_DE_WORK.V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = AREA_DE_WORK.V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1.Execute(r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORNATU, AREA_DE_WORK.V0COBA_IMPMORNATU);
                _.Move(executed_1.V0COBA_PRMVG, AREA_DE_WORK.V0COBA_PRMVG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7040_99_SAIDA*/

        [StopWatch]
        /*" R7040-00-RECUPERA-IS-PREMIO-DB-SELECT-2 */
        public void R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2()
        {
            /*" -3645- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORACID, :V0COBA-PRMAP FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81,82) AND MODALIFR >= 0 AND COD_COBERTURA = 1 WITH UR END-EXEC. */

            var r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1 = new R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1()
            {
                V0PROP_NUM_APOLICE = AREA_DE_WORK.V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = AREA_DE_WORK.V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = AREA_DE_WORK.V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1.Execute(r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORACID, AREA_DE_WORK.V0COBA_IMPMORACID);
                _.Move(executed_1.V0COBA_PRMAP, AREA_DE_WORK.V0COBA_PRMAP);
            }


        }

        [StopWatch]
        /*" R7050-00-RECUPERA-PROPOSTA-AUT-SECTION */
        private void R7050_00_RECUPERA_PROPOSTA_AUT_SECTION()
        {
            /*" -3696- MOVE '7050' TO WNR-EXEC-SQL */
            _.Move("7050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3697- MOVE 'R7050-00-RECUPERA-PROPOSTA-AUT' TO PARAGRAFO */
            _.Move("R7050-00-RECUPERA-PROPOSTA-AUT", AREA_DE_WORK.PARAGRAFO);

            /*" -3703- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3709- PERFORM R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1 */

            R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1();

            /*" -3712- IF SQLCODE NOT EQUAL +0 */

            if (DB.SQLCODE != +0)
            {

                /*" -3713- DISPLAY '7050 - PROBLEMAS SELECT V0FONTE ' */
                _.Display($"7050 - PROBLEMAS SELECT V0FONTE ");

                /*" -3714- DISPLAY 'V0PROP-FONTE    => ' V0PROP-FONTE */
                _.Display($"V0PROP-FONTE    => {AREA_DE_WORK.V0PROP_FONTE}");

                /*" -3715- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3716- END-IF */
            }


            /*" -3716- . */

        }

        [StopWatch]
        /*" R7050-00-RECUPERA-PROPOSTA-AUT-DB-SELECT-1 */
        public void R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1()
        {
            /*" -3709- EXEC SQL SELECT PROPAUTOM INTO :V0FONT-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :V0PROP-FONTE WITH UR END-EXEC. */

            var r7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1 = new R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1()
            {
                V0PROP_FONTE = AREA_DE_WORK.V0PROP_FONTE.ToString(),
            };

            var executed_1 = R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1.Execute(r7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FONT_PROPAUTOM, AREA_DE_WORK.V0FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R7040-00-RECUPERA-IS-PREMIO-DB-SELECT-3 */
        public void R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3()
        {
            /*" -3664- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPINVPERM FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81, 82) AND MODALIFR >= 0 AND COD_COBERTURA = 2 WITH UR END-EXEC. */

            var r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1 = new R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1()
            {
                V0PROP_NUM_APOLICE = AREA_DE_WORK.V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = AREA_DE_WORK.V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = AREA_DE_WORK.V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1.Execute(r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPINVPERM, AREA_DE_WORK.V0COBA_IMPINVPERM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7050_99_SAIDA*/

        [StopWatch]
        /*" R7040-00-RECUPERA-IS-PREMIO-DB-SELECT-4 */
        public void R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4()
        {
            /*" -3682- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPDIT FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81, 82) AND MODALIFR >= 0 AND COD_COBERTURA = 5 WITH UR END-EXEC. */

            var r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1 = new R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1()
            {
                V0PROP_NUM_APOLICE = AREA_DE_WORK.V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = AREA_DE_WORK.V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = AREA_DE_WORK.V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1.Execute(r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPDIT, AREA_DE_WORK.V0COBA_IMPDIT);
            }


        }

        [StopWatch]
        /*" R7060-00-INSERT-MOVIMENTO-CANC-SECTION */
        private void R7060_00_INSERT_MOVIMENTO_CANC_SECTION()
        {
            /*" -3726- MOVE '7060' TO WNR-EXEC-SQL */
            _.Move("7060", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3727- MOVE 'R7060-00-INSERT-MOVIMENTO-CANC' TO PARAGRAFO */
            _.Move("R7060-00-INSERT-MOVIMENTO-CANC", AREA_DE_WORK.PARAGRAFO);

            /*" -3729- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3730- PERFORM R7020-00-SELECT-SEGURADO-VG */

            R7020_00_SELECT_SEGURADO_VG_SECTION();

            /*" -3731- PERFORM R7040-00-RECUPERA-IS-PREMIO */

            R7040_00_RECUPERA_IS_PREMIO_SECTION();

            /*" -3732- PERFORM R7050-00-RECUPERA-PROPOSTA-AUT */

            R7050_00_RECUPERA_PROPOSTA_AUT_SECTION();

            /*" -3732- . */

            /*" -0- FLUXCONTROL_PERFORM R7060_10_INSERT_MOVIMENTO */

            R7060_10_INSERT_MOVIMENTO();

        }

        [StopWatch]
        /*" R7060-10-INSERT-MOVIMENTO */
        private void R7060_10_INSERT_MOVIMENTO(bool isPerform = false)
        {
            /*" -3738- COMPUTE V0FONT-PROPAUTOM = V0FONT-PROPAUTOM + 1 */
            AREA_DE_WORK.V0FONT_PROPAUTOM.Value = AREA_DE_WORK.V0FONT_PROPAUTOM + 1;

            /*" -3815- PERFORM R7060_10_INSERT_MOVIMENTO_DB_INSERT_1 */

            R7060_10_INSERT_MOVIMENTO_DB_INSERT_1();

            /*" -3818- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3819- IF (SQLCODE EQUAL -803) */

                if ((DB.SQLCODE == -803))
                {

                    /*" -3820- GO TO R7060-10-INSERT-MOVIMENTO */
                    new Task(() => R7060_10_INSERT_MOVIMENTO()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3821- ELSE */
                }
                else
                {


                    /*" -3822- DISPLAY '7060 - PROBLEMAS SELECT V0PROPOSTAVA ' */
                    _.Display($"7060 - PROBLEMAS SELECT V0PROPOSTAVA ");

                    /*" -3823- DISPLAY 'NUM-CERTIFICADO    => ' V0PROP-NRCERTIF */
                    _.Display($"NUM-CERTIFICADO    => {AREA_DE_WORK.V0PROP_NRCERTIF}");

                    /*" -3824- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3825- END-IF */
                }


                /*" -3827- END-IF */
            }


            /*" -3832- PERFORM R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1 */

            R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1();

            /*" -3835- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3836- DISPLAY '7060 - PROBLEMAS UPDATE V0FONTE ' */
                _.Display($"7060 - PROBLEMAS UPDATE V0FONTE ");

                /*" -3837- DISPLAY 'V0FONT-PROPAUTOM  => ' V0FONT-PROPAUTOM */
                _.Display($"V0FONT-PROPAUTOM  => {AREA_DE_WORK.V0FONT_PROPAUTOM}");

                /*" -3838- DISPLAY 'V0PROP-FONTE      => ' V0PROP-FONTE */
                _.Display($"V0PROP-FONTE      => {AREA_DE_WORK.V0PROP_FONTE}");

                /*" -3839- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3840- END-IF */
            }


            /*" -3840- . */

        }

        [StopWatch]
        /*" R7060-10-INSERT-MOVIMENTO-DB-INSERT-1 */
        public void R7060_10_INSERT_MOVIMENTO_DB_INSERT_1()
        {
            /*" -3815- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0FONT-PROPAUTOM, '1' , :V0PROP-NRCERTIF, ' ' , :V0SEGU-TPINCLUS, :V0PROP-CODCLIEN, :V0SEGU-AGENCIADOR, 0, 0, 0, 0, 'S' , 'N' , :V0OPCP-PERIPGTO, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, 0, ' ' , :V0PROP-NRMATRFUN, 0, ' ' , 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0COBA-IMPMORNATU, :V0COBA-IMPMORNATU, :V0COBA-IMPMORACID, :V0COBA-IMPMORACID, :V0COBA-IMPINVPERM, :V0COBA-IMPINVPERM, 0, 0, 0, 0, :V0COBA-IMPDIT, :V0COBA-IMPDIT, :V0COBA-PRMVG, :V0COBA-PRMVG, :V0COBA-PRMAP, :V0COBA-PRMAP, 420, :SISTEMAS-DATA-MOV-ABERTO, 0, '1' , 'CB0124B' , :SISTEMAS-DATA-MOV-ABERTO, NULL, NULL, NULL, NULL, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, NULL, :V0SEGU-LOT-EMP-SEGURADO :VIND-LOT-EMP-SEG ) END-EXEC */

            var r7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 = new R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1()
            {
                V0PROP_NUM_APOLICE = AREA_DE_WORK.V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = AREA_DE_WORK.V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = AREA_DE_WORK.V0PROP_FONTE.ToString(),
                V0FONT_PROPAUTOM = AREA_DE_WORK.V0FONT_PROPAUTOM.ToString(),
                V0PROP_NRCERTIF = AREA_DE_WORK.V0PROP_NRCERTIF.ToString(),
                V0SEGU_TPINCLUS = AREA_DE_WORK.V0SEGU_TPINCLUS.ToString(),
                V0PROP_CODCLIEN = AREA_DE_WORK.V0PROP_CODCLIEN.ToString(),
                V0SEGU_AGENCIADOR = AREA_DE_WORK.V0SEGU_AGENCIADOR.ToString(),
                V0OPCP_PERIPGTO = AREA_DE_WORK.V0OPCP_PERIPGTO.ToString(),
                V0PROP_NRMATRFUN = AREA_DE_WORK.V0PROP_NRMATRFUN.ToString(),
                V0COBA_IMPMORNATU = AREA_DE_WORK.V0COBA_IMPMORNATU.ToString(),
                V0COBA_IMPMORACID = AREA_DE_WORK.V0COBA_IMPMORACID.ToString(),
                V0COBA_IMPINVPERM = AREA_DE_WORK.V0COBA_IMPINVPERM.ToString(),
                V0COBA_IMPDIT = AREA_DE_WORK.V0COBA_IMPDIT.ToString(),
                V0COBA_PRMVG = AREA_DE_WORK.V0COBA_PRMVG.ToString(),
                V0COBA_PRMAP = AREA_DE_WORK.V0COBA_PRMAP.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                V0SEGU_LOT_EMP_SEGURADO = AREA_DE_WORK.V0SEGU_LOT_EMP_SEGURADO.ToString(),
                VIND_LOT_EMP_SEG = AREA_DE_WORK.VIND_LOT_EMP_SEG.ToString(),
            };

            R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1.Execute(r7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R7060-10-INSERT-MOVIMENTO-DB-UPDATE-1 */
        public void R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1()
        {
            /*" -3832- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V0FONT-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0PROP-FONTE END-EXEC */

            var r7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1 = new R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1()
            {
                V0FONT_PROPAUTOM = AREA_DE_WORK.V0FONT_PROPAUTOM.ToString(),
                V0PROP_FONTE = AREA_DE_WORK.V0PROP_FONTE.ToString(),
            };

            R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1.Execute(r7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7060_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-TRATA-DEVOL-PARC-SECTION */
        private void R7100_00_TRATA_DEVOL_PARC_SECTION()
        {
            /*" -3848- MOVE '7100' TO WNR-EXEC-SQL */
            _.Move("7100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3849- MOVE 'R7100-00-TRATA-DEVOL-PARC' TO PARAGRAFO */
            _.Move("R7100-00-TRATA-DEVOL-PARC", AREA_DE_WORK.PARAGRAFO);

            /*" -3851- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3852- MOVE MCIELO-VLR-COBRANCA TO WS-VLR-RELAT */
            _.Move(REG_CIELO.MCIELO_VLR_COBRANCA, AREA_DE_WORK.WS_VLR_RELAT);

            /*" -3853- COMPUTE WS-VLR-RELAT = WS-VLR-RELAT * 100 */
            AREA_DE_WORK.WS_VLR_RELAT.Value = AREA_DE_WORK.WS_VLR_RELAT * 100;

            /*" -3854- MOVE WS-VLR-RELAT TO WS-NUM-ORDEM-RELAT */
            _.Move(AREA_DE_WORK.WS_VLR_RELAT, AREA_DE_WORK.WS_NUM_ORDEM_RELAT);

            /*" -3855- MOVE MCIELO-NUM-PARCELA TO WS-NUM-PARCELA */
            _.Move(REG_CIELO.MCIELO_NUM_PARCELA, AREA_DE_WORK.WS_NUM_PARCELA);

            /*" -3857- MOVE 'N' TO WS-FIM-PARC-SRETORNO */
            _.Move("N", AREA_DE_WORK.WS_FIM_PARC_SRETORNO);

            /*" -3858- IF V0OPCP-NUMCTADEB > ZEROS */

            if (AREA_DE_WORK.V0OPCP_NUMCTADEB > 00)
            {

                /*" -3859- MOVE 104 TO WS-BCO-RELAT */
                _.Move(104, AREA_DE_WORK.WS_BCO_RELAT);

                /*" -3860- ELSE */
            }
            else
            {


                /*" -3861- MOVE 0 TO WS-BCO-RELAT */
                _.Move(0, AREA_DE_WORK.WS_BCO_RELAT);

                /*" -3863- END-IF */
            }


            /*" -3865- PERFORM R7110-00-INSERE-DEVOL-PARC */

            R7110_00_INSERE_DEVOL_PARC_SECTION();

            /*" -3867- PERFORM R7100_00_TRATA_DEVOL_PARC_DB_OPEN_1 */

            R7100_00_TRATA_DEVOL_PARC_DB_OPEN_1();

            /*" -3870- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3871- DISPLAY 'R7100-PROBLEMAS AO ABRIR (C1-PARC-SRETORNO) ' */
                _.Display($"R7100-PROBLEMAS AO ABRIR (C1-PARC-SRETORNO) ");

                /*" -3872- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3874- END-IF */
            }


            /*" -3876- PERFORM R7120-00-FETCH-C1-PARC */

            R7120_00_FETCH_C1_PARC_SECTION();

            /*" -3879- PERFORM R7130-00-PROCESSA-PARC-SR UNTIL WS-FIM-PARC-SRETORNO EQUAL 'S' */

            while (!(AREA_DE_WORK.WS_FIM_PARC_SRETORNO == "S"))
            {

                R7130_00_PROCESSA_PARC_SR_SECTION();
            }

            /*" -3879- . */

        }

        [StopWatch]
        /*" R7100-00-TRATA-DEVOL-PARC-DB-OPEN-1 */
        public void R7100_00_TRATA_DEVOL_PARC_DB_OPEN_1()
        {
            /*" -3867- EXEC SQL OPEN C1-PARC-SRETORNO END-EXEC */

            C1_PARC_SRETORNO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R7110-00-INSERE-DEVOL-PARC-SECTION */
        private void R7110_00_INSERE_DEVOL_PARC_SECTION()
        {
            /*" -3886- MOVE '7110' TO WNR-EXEC-SQL */
            _.Move("7110", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3887- MOVE 'R7110-00-INSERE-DEVOL-PARC' TO PARAGRAFO */
            _.Move("R7110-00-INSERE-DEVOL-PARC", AREA_DE_WORK.PARAGRAFO);

            /*" -3889- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -3891- PERFORM R7111-00-CONSULTA-DEVOL-PARC */

            R7111_00_CONSULTA_DEVOL_PARC_SECTION();

            /*" -3892- IF WS-QTD-PARC-SR EQUAL ZEROS */

            if (AREA_DE_WORK.WS_QTD_PARC_SR == 00)
            {

                /*" -3979- PERFORM R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1 */

                R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1();

                /*" -3982- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -3983- DISPLAY '7110 - PROBLEMAS NO INSERT TABELA RELATORIOS ' */
                    _.Display($"7110 - PROBLEMAS NO INSERT TABELA RELATORIOS ");

                    /*" -3984- DISPLAY ' NUM-CERTIFICADO.......   ' V0PROP-NRCERTIF */
                    _.Display($" NUM-CERTIFICADO.......   {AREA_DE_WORK.V0PROP_NRCERTIF}");

                    /*" -3985- DISPLAY ' SQLCODE...............   ' SQLCODE */
                    _.Display($" SQLCODE...............   {DB.SQLCODE}");

                    /*" -3986- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3988- END-IF */
                }


                /*" -3989- ADD 1 TO WS-LD-PARC-SR */
                AREA_DE_WORK.WS_LD_PARC_SR.Value = AREA_DE_WORK.WS_LD_PARC_SR + 1;

                /*" -3991- END-IF */
            }


            /*" -3991- . */

        }

        [StopWatch]
        /*" R7110-00-INSERE-DEVOL-PARC-DB-INSERT-1 */
        public void R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1()
        {
            /*" -3979- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES ( 'CB0124B' , :SISTEMAS-DATA-MOV-ABERTO , 'VA' , 'VA0469B' , '8' , :WS-BCO-RELAT , :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO , :V0OPCP-AGECTADEB , :V0OPCP-OPRCTADEB , :V0OPCP-DIGCTADEB , 0 , 0 , 0 , 0 , 0 , :V0PROP-NUM-APOLICE , 0 , :WS-NUM-PARCELA , :V0PROP-NRCERTIF , 0 , :V0PROP-CODSUBES , 16 , 0 , 0 , ' ' , ' ' , 0 , :V0OPCP-NUMCTADEB , ' ' , :WS-NUM-ORDEM-RELAT , 0 , ' ' , '0' , ' ' , ' ' , NULL , 0 , 0 , CURRENT TIMESTAMP ) END-EXEC */

            var r7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1 = new R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WS_BCO_RELAT = AREA_DE_WORK.WS_BCO_RELAT.ToString(),
                V0OPCP_AGECTADEB = AREA_DE_WORK.V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = AREA_DE_WORK.V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_DIGCTADEB = AREA_DE_WORK.V0OPCP_DIGCTADEB.ToString(),
                V0PROP_NUM_APOLICE = AREA_DE_WORK.V0PROP_NUM_APOLICE.ToString(),
                WS_NUM_PARCELA = AREA_DE_WORK.WS_NUM_PARCELA.ToString(),
                V0PROP_NRCERTIF = AREA_DE_WORK.V0PROP_NRCERTIF.ToString(),
                V0PROP_CODSUBES = AREA_DE_WORK.V0PROP_CODSUBES.ToString(),
                V0OPCP_NUMCTADEB = AREA_DE_WORK.V0OPCP_NUMCTADEB.ToString(),
                WS_NUM_ORDEM_RELAT = AREA_DE_WORK.WS_NUM_ORDEM_RELAT.ToString(),
            };

            R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1.Execute(r7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7110_99_SAIDA*/

        [StopWatch]
        /*" R7111-00-CONSULTA-DEVOL-PARC-SECTION */
        private void R7111_00_CONSULTA_DEVOL_PARC_SECTION()
        {
            /*" -3998- MOVE '7111' TO WNR-EXEC-SQL */
            _.Move("7111", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3999- MOVE 'R7111-00-CONSULTA-DEVOL-PARC' TO PARAGRAFO */
            _.Move("R7111-00-CONSULTA-DEVOL-PARC", AREA_DE_WORK.PARAGRAFO);

            /*" -4001- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -4003- MOVE ZEROS TO WS-QTD-PARC-SR */
            _.Move(0, AREA_DE_WORK.WS_QTD_PARC_SR);

            /*" -4012- PERFORM R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1 */

            R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1();

            /*" -4015- IF (SQLCODE NOT EQUAL 0 AND +100) */

            if ((!DB.SQLCODE.In("0", "+100")))
            {

                /*" -4016- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

                /*" -4017- DISPLAY 'R7111-00-CONSULTA-DEVOL-PARC ' */
                _.Display($"R7111-00-CONSULTA-DEVOL-PARC ");

                /*" -4018- DISPLAY 'NUM_CERTIFICADO = ' V0PROP-NRCERTIF */
                _.Display($"NUM_CERTIFICADO = {AREA_DE_WORK.V0PROP_NRCERTIF}");

                /*" -4019- DISPLAY 'NUM_PARCELA     = ' WS-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {AREA_DE_WORK.WS_NUM_PARCELA}");

                /*" -4020- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4021- END-IF */
            }


            /*" -4021- . */

        }

        [StopWatch]
        /*" R7111-00-CONSULTA-DEVOL-PARC-DB-SELECT-1 */
        public void R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1()
        {
            /*" -4012- EXEC SQL SELECT COUNT(*) INTO :WS-QTD-PARC-SR FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND NUM_PARCELA = :WS-NUM-PARCELA AND NUM_COPIAS = '8' AND SIT_REGISTRO = '0' WITH UR END-EXEC */

            var r7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1 = new R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = AREA_DE_WORK.V0PROP_NRCERTIF.ToString(),
                WS_NUM_PARCELA = AREA_DE_WORK.WS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1.Execute(r7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTD_PARC_SR, AREA_DE_WORK.WS_QTD_PARC_SR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7111_99_SAIDA*/

        [StopWatch]
        /*" R7120-00-FETCH-C1-PARC-SECTION */
        private void R7120_00_FETCH_C1_PARC_SECTION()
        {
            /*" -4028- MOVE '7120' TO WNR-EXEC-SQL */
            _.Move("7120", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4029- MOVE 'R7120-00-FETCH-C1-PARC' TO PARAGRAFO */
            _.Move("R7120-00-FETCH-C1-PARC", AREA_DE_WORK.PARAGRAFO);

            /*" -4031- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -4035- PERFORM R7120_00_FETCH_C1_PARC_DB_FETCH_1 */

            R7120_00_FETCH_C1_PARC_DB_FETCH_1();

            /*" -4038-  EVALUATE SQLCODE  */

            /*" -4039-  WHEN ZEROS  */

            /*" -4039- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4040- CONTINUE */

                /*" -4041-  WHEN +100  */

                /*" -4041- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -4043- PERFORM R7120_00_FETCH_C1_PARC_DB_CLOSE_1 */

                R7120_00_FETCH_C1_PARC_DB_CLOSE_1();

                /*" -4046- MOVE 'S' TO WS-FIM-PARC-SRETORNO */
                _.Move("S", AREA_DE_WORK.WS_FIM_PARC_SRETORNO);

                /*" -4047-  WHEN OTHER  */

                /*" -4047- ELSE */
            }
            else
            {


                /*" -4048- DISPLAY '7120-00 - PROBLEMAS FETCH (C1-PARC-SRETORNO) ' */
                _.Display($"7120-00 - PROBLEMAS FETCH (C1-PARC-SRETORNO) ");

                /*" -4049- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4051-  END-EVALUATE  */

                /*" -4051- END-IF */
            }


            /*" -4051- . */

        }

        [StopWatch]
        /*" R7120-00-FETCH-C1-PARC-DB-FETCH-1 */
        public void R7120_00_FETCH_C1_PARC_DB_FETCH_1()
        {
            /*" -4035- EXEC SQL FETCH C1-PARC-SRETORNO INTO :WS-NUM-PARC-SR, :WS-VLR-PARC-SR END-EXEC */

            if (C1_PARC_SRETORNO.Fetch())
            {
                _.Move(C1_PARC_SRETORNO.WS_NUM_PARC_SR, AREA_DE_WORK.WS_NUM_PARC_SR);
                _.Move(C1_PARC_SRETORNO.WS_VLR_PARC_SR, AREA_DE_WORK.WS_VLR_PARC_SR);
            }

        }

        [StopWatch]
        /*" R7120-00-FETCH-C1-PARC-DB-CLOSE-1 */
        public void R7120_00_FETCH_C1_PARC_DB_CLOSE_1()
        {
            /*" -4043- EXEC SQL CLOSE C1-PARC-SRETORNO END-EXEC */

            C1_PARC_SRETORNO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7120_99_SAIDA*/

        [StopWatch]
        /*" R7130-00-PROCESSA-PARC-SR-SECTION */
        private void R7130_00_PROCESSA_PARC_SR_SECTION()
        {
            /*" -4058- MOVE '7130' TO WNR-EXEC-SQL */
            _.Move("7130", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4059- MOVE 'R7130-00-PROCESSA-PARC-SR' TO PARAGRAFO */
            _.Move("R7130-00-PROCESSA-PARC-SR", AREA_DE_WORK.PARAGRAFO);

            /*" -4061- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -4062- MOVE WS-VLR-PARC-SR TO WS-VLR-RELAT */
            _.Move(AREA_DE_WORK.WS_VLR_PARC_SR, AREA_DE_WORK.WS_VLR_RELAT);

            /*" -4063- COMPUTE WS-VLR-RELAT = WS-VLR-RELAT * 100 */
            AREA_DE_WORK.WS_VLR_RELAT.Value = AREA_DE_WORK.WS_VLR_RELAT * 100;

            /*" -4064- MOVE WS-VLR-RELAT TO WS-NUM-ORDEM-RELAT */
            _.Move(AREA_DE_WORK.WS_VLR_RELAT, AREA_DE_WORK.WS_NUM_ORDEM_RELAT);

            /*" -4065- MOVE WS-NUM-PARC-SR TO WS-NUM-PARCELA */
            _.Move(AREA_DE_WORK.WS_NUM_PARC_SR, AREA_DE_WORK.WS_NUM_PARCELA);

            /*" -4067- MOVE 'N' TO WS-FIM-PARC-SRETORNO */
            _.Move("N", AREA_DE_WORK.WS_FIM_PARC_SRETORNO);

            /*" -4068- IF V0OPCP-NUMCTADEB > ZEROS */

            if (AREA_DE_WORK.V0OPCP_NUMCTADEB > 00)
            {

                /*" -4069- MOVE 104 TO WS-BCO-RELAT */
                _.Move(104, AREA_DE_WORK.WS_BCO_RELAT);

                /*" -4070- ELSE */
            }
            else
            {


                /*" -4071- MOVE 0 TO WS-BCO-RELAT */
                _.Move(0, AREA_DE_WORK.WS_BCO_RELAT);

                /*" -4073- END-IF */
            }


            /*" -4075- PERFORM R7110-00-INSERE-DEVOL-PARC */

            R7110_00_INSERE_DEVOL_PARC_SECTION();

            /*" -4077- PERFORM R7120-00-FETCH-C1-PARC */

            R7120_00_FETCH_C1_PARC_SECTION();

            /*" -4077- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7130_99_SAIDA*/

        [StopWatch]
        /*" R7200-00-TRATA-DEVOL-PARC-SECTION */
        private void R7200_00_TRATA_DEVOL_PARC_SECTION()
        {
            /*" -4084- MOVE '7200' TO WNR-EXEC-SQL */
            _.Move("7200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4085- MOVE 'R7200-00-TRATA-DEVOL-PARC' TO PARAGRAFO */
            _.Move("R7200-00-TRATA-DEVOL-PARC", AREA_DE_WORK.PARAGRAFO);

            /*" -4088- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -4090- PERFORM R4015-00-SELECT-PARCELAS */

            R4015_00_SELECT_PARCELAS_SECTION();

            /*" -4091- MOVE HISCONPA-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

            /*" -4092- MOVE HISCONPA-NUM-PARCELA TO PARCEVID-NUM-PARCELA */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

            /*" -4095- MOVE '2' TO PARCEVID-SIT-REGISTRO */
            _.Move("2", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

            /*" -4097- PERFORM R3020-00-UPDATE-PARCEVID */

            R3020_00_UPDATE_PARCEVID_SECTION();

            /*" -4098- MOVE HISCONPA-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

            /*" -4099- MOVE HISCONPA-NUM-PARCELA TO COBHISVI-NUM-PARCELA */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -4102- MOVE '2' TO COBHISVI-SIT-REGISTRO */
            _.Move("2", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

            /*" -4104- PERFORM R3030-00-UPDATE-COBHISVI */

            R3030_00_UPDATE_COBHISVI_SECTION();

            /*" -4105- MOVE '7' TO HISLANCT-SIT-REGISTRO */
            _.Move("7", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -4106- MOVE WS-NSAC TO HISLANCT-NSAC */
            _.Move(AREA_DE_WORK.WS_NSAC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAC);

            /*" -4109- MOVE ZEROS TO HISLANCT-CODRET */
            _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

            /*" -4111- PERFORM R6010-00-UPDATE-HIST-LANC-CTA */

            R6010_00_UPDATE_HIST_LANC_CTA_SECTION();

            /*" -4112- PERFORM R3120-00-MONTA-HISCOMPA */

            R3120_00_MONTA_HISCOMPA_SECTION();

            /*" -4113- MOVE 501 TO HISCONPA-COD-OPERACAO */
            _.Move(501, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

            /*" -4114- PERFORM R3150-00-INSERT-HISCONPA */

            R3150_00_INSERT_HISCONPA_SECTION();

            /*" -4114- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R7250-00-INSERE-INFO-CHRGBACK-SECTION */
        private void R7250_00_INSERE_INFO_CHRGBACK_SECTION()
        {
            /*" -4123- MOVE '7250' TO WNR-EXEC-SQL */
            _.Move("7250", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4124- MOVE 'R7250-00-INSERE-INFO-CHRGBACK' TO PARAGRAFO */
            _.Move("R7250-00-INSERE-INFO-CHRGBACK", AREA_DE_WORK.PARAGRAFO);

            /*" -4126- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -4128- PERFORM P7251-00-CONS-COD-CRITICA */

            P7251_00_CONS_COD_CRITICA_SECTION();

            /*" -4129- IF VG001-IND-EXISTE EQUAL 'S' */

            if (SPVG001V.VG001_IND_EXISTE == "S")
            {

                /*" -4130- GO TO R7250-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7250_99_EXIT*/ //GOTO
                return;

                /*" -4134- END-IF */
            }


            /*" -4136- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -4137- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4138- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4139- MOVE V0PROP-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(AREA_DE_WORK.V0PROP_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4140- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4141- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4142- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4143- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4144- MOVE 'CB0124B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB0124B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4145- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4146- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4147- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4148- MOVE 5000 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(5000, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -4151- MOVE 'CERTIFICADO CANCELADO APOS RETORNO DE CHARGEBACK' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CERTIFICADO CANCELADO APOS RETORNO DE CHARGEBACK", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4153- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4154- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -4155- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -4159- DISPLAY 'ERRO JAH GRAVADO R7250 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO R7250 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -4160- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4161- ELSE */
                }
                else
                {


                    /*" -4162- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4163- DISPLAY '* P7250 -  PROBLEMAS CALL SUBROTINA SPBVG001*' */
                    _.Display($"* P7250 -  PROBLEMAS CALL SUBROTINA SPBVG001*");

                    /*" -4164- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4165- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -4166- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -4167- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -4168- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -4169- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -4170- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -4172- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4173- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -4174- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4175- END-IF */
                }


                /*" -4176- END-IF */
            }


            /*" -4176- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7250_99_EXIT*/

        [StopWatch]
        /*" P7251-00-CONS-COD-CRITICA-SECTION */
        private void P7251_00_CONS_COD_CRITICA_SECTION()
        {
            /*" -4184- MOVE '7250' TO WNR-EXEC-SQL */
            _.Move("7250", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4185- MOVE 'P7251-00-CONS-COD-CRITICA' TO PARAGRAFO */
            _.Move("P7251-00-CONS-COD-CRITICA", AREA_DE_WORK.PARAGRAFO);

            /*" -4189- DISPLAY PARAGRAFO */
            _.Display(AREA_DE_WORK.PARAGRAFO);

            /*" -4191- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -4192- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -4193- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4194- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4195- MOVE V0PROP-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(AREA_DE_WORK.V0PROP_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4196- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4197- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4198- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4199- MOVE 5000 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(5000, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -4200- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4201- MOVE 'CB0124B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("CB0124B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4202- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4203- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4204- MOVE 00 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(00, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4206- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4208- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4209- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -4210- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -4211- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -4212- ELSE */
                }
                else
                {


                    /*" -4213- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -4214- END-IF */
                }


                /*" -4215- ELSE */
            }
            else
            {


                /*" -4216- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4217- DISPLAY '* 8580 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 8580 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -4218- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4219- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -4220- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -4221- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -4222- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -4223- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -4224- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -4226- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4227- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -4228- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4229- END-IF */
            }


            /*" -4229- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7251_99_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -4238- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WS_SQLCODE);

            /*" -4239- DISPLAY WABEND */
            _.Display(ABEN.WABEND);

            /*" -4240- DISPLAY WABEND1 */
            _.Display(ABEN.WABEND1);

            /*" -4240- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4242- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -4243- DISPLAY ' ' */
            _.Display($" ");

            /*" -4244- DISPLAY 'CB0124B - FIM COM ERRO     ' . */
            _.Display($"CB0124B - FIM COM ERRO     ");

            /*" -4246- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4246- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}