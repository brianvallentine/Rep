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
using Sias.FederalVida.DB2.VF0813B;

namespace Code
{
    public class VF0813B
    {
        public bool IsCall { get; set; }

        public VF0813B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *      RETORNO DOS LANCAMENTOS DE DEBITO EM CONTA FEBRABAN       *      */
        /*"      *           CONVENIO 6131 FEDERAL PLUS    VERSAO NAO CONVERTIDA  *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO SUMARIA                             30.07.99        *      */
        /*"      *                                                                *      */
        /*"      *         O PROGRAMA LE O MOVIMENTO DE RETORNO DOS LANCAMENTOS   *      */
        /*"      *     DE DEBITO DE SEGURO E EFETUA A QUITACAO OU A GERACAO DO    *      */
        /*"      *     RETORNO DO DEBITO NAO EFETUADO.                            *      */
        /*"      *                                                                *      */
        /*"      *         AS PARCELAS NAO DEBITADAS POR CONTA NAO CADASTRADA OU  *      */
        /*"      *     POR QUALQUER MOTIVO QUE GERE O CANCELAMENTO DO DEBITO      *      */
        /*"      *     IRAO FORCAR A MUDANCA DA OPCAO DE PAGAMENTO DO SEGURO DE   *      */
        /*"      *     DEBITO EM CONTA PARA CARNE, NAO GERANDO O CANCELAMENTO DO  *      */
        /*"      *     SEGURO.                                                    *      */
        /*"      *                                                                *      */
        /*"      *         CASO A PARCELA TENHA SIDO PAGA, EH GERADA A TABELA     *      */
        /*"      *     V0REPASSECDG INDICANDO QUE DEVE SER FEITO O REPASSE.       *      */
        /*"      *                                                                *      */
        /*"      *         E GERADO O ARQUIVO RETERR COM O RETORNO QUE APRESENTE  *      */
        /*"      *     INCONSISTENCIA NA ATUALIZACAO, PARA EMISSAO DE RELATORIO,  *      */
        /*"      *     CONTENDO A MENSAGEM DE ERRO.                               *      */
        /*"      *                                                                *      */
        /*"      *     ESTE PROGRAMA EH UMA VERSAO DO PROGRAMA VA0813B DO DIA     *      */
        /*"      *     30/07/1999, ONDE CONSTAVAM AS ALTERACOES ABAIXO DESCRITAS. *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE FONSECA           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 31/01/2024 *      */
        /*"      *   VERSAO 20               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
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
        /*"      *                           - PROCURAR POR V.20                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - HIST 181.573                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 -   CORRECAO DE ABEND - CADMUS 155172              *      */
        /*"      *               - COBRANCA NAO ENCONTRADA                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/10/2017 - MARCUS (ALTRAN)                              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 -   CORRECAO DE ABEND - CADMUS 146109              *      */
        /*"      *               - COBRANCA NAO ENCONTRADA                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/01/2017 - MARCUS (ALTRAN)                              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - CAD 87.342                                       *      */
        /*"      *                                                                *      */
        /*"      *              - ATUALIZACAO DA SITUACAO DA PARCELA NA TABELA    *      */
        /*"      *                V0HISTCOBVA QUANDO A PARCELA FOR REJEITADA E    *      */
        /*"      *                ATUALIZA REGISTRO DA TABELA VG_FOLLOW_UP.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/11/2013 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.15    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.14    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 - CAD 74.016                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE NA TABELA INTERNA DO PRODUTO            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/09/2012 - AUGUSTO ANASTACIO (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 64.594                                       *      */
        /*"      *               - AJUSTE NA CRITICA DO RF-NSA ZERADO             *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/01/2012 - CLAUDIO FREITAS (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 51.170                                       *      */
        /*"      *               - AJUSTE NA TABELA INTERNA DO PRODUTO            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/12/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     ALTERADO EM 31/03/98 - FREDERICO FONSECA (FF0398)          *      */
        /*"      *         ESTAVA GERANDO O REPASSE DA COBERTURA AUXILIO FUNERAL  *      */
        /*"      *     PARA QUALQUER PRODUTO. OS UNICOS PRODUTOS HOJE QUE POSSUEM *      */
        /*"      *     TAL COBERTURA SAO O PREFERENCIAL VIDA (801) E O PREFEREN-  *      */
        /*"      *     CIAL VIDA PLUS (802).                                      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERADO EM 08/04/98 - TERCIO CARVALHO   (TL0498)          *      */
        /*"      *         ESTAVA FAZENDO ACESSO NA V0OPCAOPAGVA COM DTTERVIG     *      */
        /*"      *     = 1999-12-31. FOI ALTERADO PARA IN 1999-12-31 E 9999-12-31.*      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERADO EM 14/09/98 - CLOVIS            (CL0998)          *      */
        /*"      *         INCLUSAO DO AVISO DE CREDITO                           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERADO EM 30/12/98 - TERCIO CARVALHO   (TL9812)          *      */
        /*"      *         ESTAVA FAZENDO ACESSO NA V0HISTCONTAVA COM NSAC IS NULL*      */
        /*"      *         OCORRE QUE A CEF ESTA RECOMANDANDO LANCAMENTOS QUE EM  *      */
        /*"      *         EM PRINCIPIO ESTAVAM COM CODIGO DE RETORNO 02 - CONTA  *      */
        /*"      *         NAO CADASTRADA OU 04 - OUTRAS RESTRICOES COM CODIGO    *      */
        /*"      *         DE RETORNO 00 - DEBITO EFETUADO.                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           16/09/1998  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"MM0399*     ALTERADO EM 03/03/99 - MANOEL MESSIAS    (MM0399)          *      */
        /*"MM0399*         CRIADO SORT INTERNO PARA PRIORIZAR DEBITOS EFETUADOS   *      */
        /*"MM0399*      (CODIGO DE RETORNO 00).                                   *      */
        /*"MM0399*         O ACESSO PRINCIPAL PARA A TABELA V0HISTCONTAVA SERA POR*      */
        /*"MM0399*      CERTIFICADO.                                              *      */
        /*"MM0399*         QUITAR SEMPRE A MENOR PARCELA EM COBRANCA.             *      */
        /*"MM0399*                                                                *      */
        /*"      ******************************************************************      */
        /*"MM0599*     ALTERADO EM 13/05/99 - MANOEL MESSIAS    (MM0599)          *      */
        /*"MM0599*         QUANDO DA MUDANCA DE OPCAO DE PAGAMENTO (V0OPCAOPAGVA),*      */
        /*"MM0599*      ATUALIZAR TAMBEM, A OPCAO DE PAGAMENTO (OPCAOPAG) DAS TA- *      */
        /*"MM0599*      BELAS V0PARCELVA E V0HISTCOBVA.                           *      */
        /*"MM0599*                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERADO EM 15/07/99 - TERCIO CARVALHO   (TL9907)          *      */
        /*"      *         PASSA A NAO MAIS TRATAR POR PRODUTO E SIM POR          *      */
        /*"      *      APOLICE E SUBGRUPO.                                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERADO EM 23/11/99 - FONSECA (AF9911)                    *      */
        /*"      *        ATUALIZA A SITUACAO DA V0HISTCONTAVA NO RETORNO DE      *      */
        /*"      *     DEBITO NAO EFETUADO.                                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERADO EM 12/09/02 - MESSIAS / FREDERICO (MM1209)        *      */
        /*"      *        COLOCA UM LOOP NA ATUALIZACAO DA EVENTOSVF PORQUE O     *      */
        /*"      *     OCORHIST DA EVENTOSVF E PRODUTORVF NAO SE EQUIPARAVAM.     *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RETDEB { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETDEB
        {
            get
            {
                _.Move(RETDEB_RECORD, _RETDEB); VarBasis.RedefinePassValue(RETDEB_RECORD, _RETDEB, RETDEB_RECORD); return _RETDEB;
            }
        }
        public FileBasis _RETERR { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RETERR
        {
            get
            {
                _.Move(RETERR_RECORD, _RETERR); VarBasis.RedefinePassValue(RETERR_RECORD, _RETERR, RETERR_RECORD); return _RETERR;
            }
        }
        /*"01  RETDEB-RECORD        PIC X(150).*/
        public StringBasis RETDEB_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  RET-HEADER.*/
        public VF0813B_RET_HEADER RET_HEADER { get; set; } = new VF0813B_RET_HEADER();
        public class VF0813B_RET_HEADER : VarBasis
        {
            /*"    05 RA-COD-REG         PIC X(001).*/
            public StringBasis RA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RA-COD-REMESSA     PIC 9(001).*/
            public IntBasis RA_COD_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05 RA-COD-CONVENIO    PIC 9(004).*/
            public IntBasis RA_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 FILLER             PIC X(016).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
            /*"    05 RA-NOME-EMPRESA    PIC X(020).*/
            public StringBasis RA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05 RA-COD-BANCO       PIC 9(003).*/
            public IntBasis RA_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05 RA-NOME-BANCO      PIC X(020).*/
            public StringBasis RA_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05 RA-DATA-GERACAO.*/
            public VF0813B_RA_DATA_GERACAO RA_DATA_GERACAO { get; set; } = new VF0813B_RA_DATA_GERACAO();
            public class VF0813B_RA_DATA_GERACAO : VarBasis
            {
                /*"       10 RA-AA-GER       PIC X(004).*/
                public StringBasis RA_AA_GER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10 RA-MM-GER       PIC X(002).*/
                public StringBasis RA_MM_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10 RA-DD-GER       PIC X(002).*/
                public StringBasis RA_DD_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RA-NSA             PIC 9(006).*/
            }
            public IntBasis RA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RA-VERSAO-LAYOUT   PIC 9(002).*/
            public IntBasis RA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RA-SERVICO         PIC X(017).*/
            public StringBasis RA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RA-RESERVADO       PIC X(052).*/
            public StringBasis RA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01  RET-CADASTRAMENTO.*/
        }
        public VF0813B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VF0813B_RET_CADASTRAMENTO();
        public class VF0813B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05 RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RF-IDENT-CLI-EMPRESA.*/
            public VF0813B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VF0813B_RF_IDENT_CLI_EMPRESA();
            public class VF0813B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 RF-IDENTIF-CLI   PIC 9(015).*/
                public IntBasis RF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 RF-IDENTIF-CLI-R REDEFINES          RF-IDENTIF-CLI.*/
                private _REDEF_VF0813B_RF_IDENTIF_CLI_R _rf_identif_cli_r { get; set; }
                public _REDEF_VF0813B_RF_IDENTIF_CLI_R RF_IDENTIF_CLI_R
                {
                    get { _rf_identif_cli_r = new _REDEF_VF0813B_RF_IDENTIF_CLI_R(); _.Move(RF_IDENTIF_CLI, _rf_identif_cli_r); VarBasis.RedefinePassValue(RF_IDENTIF_CLI, _rf_identif_cli_r, RF_IDENTIF_CLI); _rf_identif_cli_r.ValueChanged += () => { _.Move(_rf_identif_cli_r, RF_IDENTIF_CLI); }; return _rf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_identif_cli_r, RF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VF0813B_RF_IDENTIF_CLI_R : VarBasis
                {
                    /*"          15 FILLER        PIC X(015).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10 RF-IDENTIF-NSAS  PIC 9(005).*/

                    public _REDEF_VF0813B_RF_IDENTIF_CLI_R()
                    {
                        FILLER_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis RF_IDENTIF_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10 FILLER           PIC X(005).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05 RF-AGECTADEB        PIC 9(004).*/
            }
            public IntBasis RF_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VF0813B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VF0813B_RF_IDENT_CLI_BANCO();
            public class VF0813B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 RF-COD-OPRCTADEB PIC 9(004).*/
                public IntBasis RF_COD_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 RF-NUM-NUMCTADEB PIC 9(012).*/
                public IntBasis RF_NUM_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 RF-DIG-NUMCTADEB PIC 9(001).*/
                public IntBasis RF_DIG_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER           PIC X(002).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL.*/
            }
            public VF0813B_RF_DATA_REAL RF_DATA_REAL { get; set; } = new VF0813B_RF_DATA_REAL();
            public class VF0813B_RF_DATA_REAL : VarBasis
            {
                /*"       10 RF-ANO-REAL      PIC 9(004).*/
                public IntBasis RF_ANO_REAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 RF-MES-REAL      PIC 9(002).*/
                public IntBasis RF_MES_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 RF-DIA-REAL      PIC 9(002).*/
                public IntBasis RF_DIA_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 RF-VLPRMTOT         PIC 9(013)V99.*/
            }
            public DoubleBasis RF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNO      PIC 9(002).*/
            public IntBasis RF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESA.*/
            public VF0813B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VF0813B_RF_USO_EMPRESA();
            public class VF0813B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10 RF-NSA           PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 RF-NSL           PIC 9(008).*/
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 FILLER           PIC X(047).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 RF-RESERVADO        PIC X(017).*/
            }
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RF-COD-MOVIMENTO    PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLER.*/
        }
        public VF0813B_RET_TRAILLER RET_TRAILLER { get; set; } = new VF0813B_RET_TRAILLER();
        public class VF0813B_RET_TRAILLER : VarBasis
        {
            /*"    05 RZ-COD-REG         PIC X(001).*/
            public StringBasis RZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RZ-QTDE-REGISTROS  PIC 9(006).*/
            public IntBasis RZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RZ-TOT-DEB-CRUZ    PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-TOT-CRED-CRUZ   PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_CRED_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-RESERVADO       PIC X(109).*/
            public StringBasis RZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01  RETERR-RECORD.*/
        }
        public VF0813B_RETERR_RECORD RETERR_RECORD { get; set; } = new VF0813B_RETERR_RECORD();
        public class VF0813B_RETERR_RECORD : VarBasis
        {
            /*"    05 RETERR-REGISTRO   PIC X(150).*/
            public StringBasis RETERR_REGISTRO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
            /*"    05 RETERR-MENSAGEM   PIC X(070).*/
            public StringBasis RETERR_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  V0SIST-DTMOVABE                  PIC X(10).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-DTRET                     PIC X(10).*/
        public StringBasis V0FTCF_DTRET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-NSAC                      PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0FTCF-QTLANCDB                  PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTLANCDB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-QTREG                     PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-QTDBEFET                  PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTDBEFET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-TOTDBEFET                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FTCF_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FTCF-TOTDBNEFET                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FTCF_TOTDBNEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FTCF-VERSAO                    PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PRVG-TEM-SAF                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-CDG                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTA-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-CODRET                    PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NUMCTADEB                 PIC S9(13)    COMP-3.*/
        public IntBasis V0HCTA_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0HCTA-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0HCTA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0HCTA-NSAS                      PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NSL                       PIC S9(09)    COMP.*/
        public IntBasis V0HCTA_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0HCTA-OCORHISTCTA               PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OCORHISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-OCORHISTCOB               PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OCORHISTCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-CODCONV                    PIC S9(09)    COMP.*/
        public IntBasis WHOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0HCTB-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTB-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTB_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PARC-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PARC-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RCDG-DTREFER                   PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RCDG-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0RSAF-DTREFER                   PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RSAF-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0PROP-CODSUBES                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-CODPRODU                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-FONTE                     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0PROP-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0COBP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-IMPSEGAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0CMPT-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0CMPT_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0CMPT-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0CMPT_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0CMPT-VLPRMDIF                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CMPT_VLPRMDIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0CDGC-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SAFC-VLCUSTSAF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-DTALTOPC                  PIC  X(10).*/
        public StringBasis V0HCOB_DTALTOPC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0HCOB-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0HCOB-NRTIT                     PIC S9(13)    COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0HCOB-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCOB-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0HCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCOB-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCOB-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0OPCP-DIADEB                    PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_DIADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0OPCP-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0OPCP-PERIPGTO                  PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-BCOAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-AGEAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-NRAVISO                   PIC S9(09)    COMP.*/
        public IntBasis V0AVIS_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0AVIS-NRSEQ                     PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-DTMOVTO                   PIC X(10).*/
        public StringBasis V0AVIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0AVIS-OPERACAO                  PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-TIPAVI                    PIC X(01).*/
        public StringBasis V0AVIS_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-DTAVISO                   PIC X(10).*/
        public StringBasis V0AVIS_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0AVIS-VLIOCC                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLDESPES                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-PRECED                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_PRECED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLPRMLIQ                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-SITCONTB                  PIC X(01).*/
        public StringBasis V0AVIS_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-CODEMP                    PIC S9(09)    COMP.*/
        public IntBasis V0AVIS_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0AVIS-ORIGAVISO                 PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-VALADT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-SITDEPTER                 PIC  X(01).*/
        public StringBasis V0AVIS_SITDEPTER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  VIND-CODEMP                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-ORIGAVISO                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VALADT                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-SAF                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-CDG                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTMOVTO                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-CODEMP                    PIC S9(09)    COMP.*/
        public IntBasis V0SALD_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SALD-BCOAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0SALD_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-AGEAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0SALD_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-TIPSGU                    PIC X(01).*/
        public StringBasis V0SALD_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0SALD-NRAVISO                   PIC S9(09)    COMP.*/
        public IntBasis V0SALD_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SALD-DTAVISO                   PIC X(10).*/
        public StringBasis V0SALD_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SALD-DTMOVTO                   PIC X(10).*/
        public StringBasis V0SALD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SALD-SDOATU                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SALD_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SALD-SITUACAO                  PIC X(01).*/
        public StringBasis V0SALD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PLCO-CODPDT                    PIC S9(09)    COMP.*/
        public IntBasis V0PLCO_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0PDTV-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0PDTV_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01    WSHOST-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis WSHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    WSHOST-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-SITUACAO           PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0PROD-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-ANOREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_ANOREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-MESREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_MESREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-TIPOREG            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-SITUACAO           PIC  X(001).*/
        public StringBasis V0DPCF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-TIPOCOB            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-DTMOVTO            PIC  X(010).*/
        public StringBasis V0DPCF_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0DPCF-DTAVISO            PIC  X(010).*/
        public StringBasis V0DPCF_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0DPCF-QTDREG             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_QTDREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLPRMLIQ           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLJUROS            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLMULTA            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WORK-AREA.*/
        public VF0813B_WORK_AREA WORK_AREA { get; set; } = new VF0813B_WORK_AREA();
        public class VF0813B_WORK_AREA : VarBasis
        {
            /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05      DATA-SQL.*/
            public VF0813B_DATA_SQL DATA_SQL { get; set; } = new VF0813B_DATA_SQL();
            public class VF0813B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL                  PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-SQL                  PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-SQL                  PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DATA-INV.*/
            }
            public VF0813B_WS_DATA_INV WS_DATA_INV { get; set; } = new VF0813B_WS_DATA_INV();
            public class VF0813B_WS_DATA_INV : VarBasis
            {
                /*"      10 WS-ANO-INV                  PIC  9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-MES-INV                  PIC  9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 WS-DIA-INV                  PIC  9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/
            }
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-EOC                   PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-EOP                   PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOP { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-EOP2                  PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOP2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-NAO-ACHEI             PIC  9(001) VALUE 0.*/
            public IntBasis WS_NAO_ACHEI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-CODCONV               PIC  9(004).*/
            public IntBasis WS_CODCONV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05      WS-VLPRMTOT              PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-REGISTROS              PIC  9(9)      VALUE  0.*/
            public IntBasis WS_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-QTDBEFET               PIC  9(9)      VALUE  0.*/
            public IntBasis WS_QTDBEFET { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-ACG-TOTDBEFET          PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_ACG_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-ACG-TOTDBNEFET         PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_ACG_TOTDBNEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-DIFERENCA              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_DIFERENCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-PC-VG                  PIC  9(03)V9(7) VALUE  0.*/
            public DoubleBasis WS_PC_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"    05 WS-ACHOU                  PIC  9          VALUE  0.*/
            public IntBasis WS_ACHOU { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    05 WS-NRAVISO                PIC  9(009)    VALUE  0.*/
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 FILLER                    REDEFINES      WS-NRAVISO.*/
            private _REDEF_VF0813B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VF0813B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VF0813B_FILLER_7(); _.Move(WS_NRAVISO, _filler_7); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_7, WS_NRAVISO); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_NRAVISO); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_VF0813B_FILLER_7 : VarBasis
            {
                /*"      10 WS-AGEAVISO             PIC  9(004).*/
                public IntBasis WS_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-NSAC                 PIC  9(005).*/
                public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05 WS-SUBS                   PIC  9(005)    VALUE ZEROS.*/

                public _REDEF_VF0813B_FILLER_7()
                {
                    WS_AGEAVISO.ValueChanged += OnValueChanged;
                    WS_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 WS-SUBS1                  PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 WS-SUBS2                  PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 WFIM-PRODUTO              PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 AUX-NSAC                  PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AUX_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 AUX-CONVENIO              PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AUX_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 LD-PRODUTO                PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis LD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05 AUX-VLPRMTOT              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis AUX_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 AUX-VLDESPES              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis AUX_VLDESPES { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VF0813B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VF0813B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VF0813B_FILLER_8(); _.Move(WDATA_REL, _filler_8); VarBasis.RedefinePassValue(WDATA_REL, _filler_8, WDATA_REL); _filler_8.ValueChanged += () => { _.Move(_filler_8, WDATA_REL); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VF0813B_FILLER_8 : VarBasis
            {
                /*"      10     WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/

                public _REDEF_VF0813B_FILLER_8()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VF0813B_WABEND WABEND { get; set; } = new VF0813B_WABEND();
            public class VF0813B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VF0813B  '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VF0813B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VF0813B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VF0813B_LOCALIZA_ABEND_1();
            public class VF0813B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VF0813B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VF0813B_LOCALIZA_ABEND_2();
            public class VF0813B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  AUX-TABELAS.*/
            }
        }
        public VF0813B_AUX_TABELAS AUX_TABELAS { get; set; } = new VF0813B_AUX_TABELAS();
        public class VF0813B_AUX_TABELAS : VarBasis
        {
            /*"  03          WTABG-VALORES.*/
            public VF0813B_WTABG_VALORES WTABG_VALORES { get; set; } = new VF0813B_WTABG_VALORES();
            public class VF0813B_WTABG_VALORES : VarBasis
            {
                /*"    05        WTABG-OCORREPRD     OCCURS       2000  TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<VF0813B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<VF0813B_WTABG_OCORREPRD>(2000);
                public class VF0813B_WTABG_OCORREPRD : VarBasis
                {
                    /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                    public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WTABG-OCORRETIP     OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<VF0813B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<VF0813B_WTABG_OCORRETIP>(003);
                    public class VF0813B_WTABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WTABG-TIPO          PIC  X(001).*/
                        public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<VF0813B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<VF0813B_WTABG_OCORRESIT>(002);
                        public class VF0813B_WTABG_OCORRESIT : VarBasis
                        {
                            /*"          20  WTABG-SITUACAO      PIC  X(001).*/
                            public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          20  WTABG-QTDE          PIC S9(009)        COMP.*/
                            public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          20  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLIOCC        PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLDESCON      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                        }
                    }
                }
            }
        }


        public Dclgens.VGFOLLOW VGFOLLOW { get; set; } = new Dclgens.VGFOLLOW();
        public VF0813B_CCMPTIT CCMPTIT { get; set; } = new VF0813B_CCMPTIT();
        public VF0813B_CPLCOM CPLCOM { get; set; } = new VF0813B_CPLCOM();
        public VF0813B_CPARC1 CPARC1 { get; set; } = new VF0813B_CPARC1();
        public VF0813B_V0PRODUTO V0PRODUTO { get; set; } = new VF0813B_V0PRODUTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETDEB_FILE_NAME_P, string RETERR_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETDEB.SetFile(RETDEB_FILE_NAME_P);
                RETERR.SetFile(RETERR_FILE_NAME_P);

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
            /*" -589- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -592- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -595- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -600- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -601- DISPLAY 'PROGRAMA EM EXECUCAO VF0813B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VF0813B  ");

            /*" -602- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -609- DISPLAY 'VERSAO V.18 155172 22/10/2017 ' */
            _.Display($"VERSAO V.18 155172 22/10/2017 ");

            /*" -610- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -614- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -615- OPEN INPUT RETDEB. */
            RETDEB.Open(RETDEB_RECORD);

            /*" -617- OPEN OUTPUT RETERR. */
            RETERR.Open(RETERR_RECORD);

            /*" -618- MOVE '0001-INICIO  ' TO PARAGRAFO. */
            _.Move("0001-INICIO  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -620- MOVE 'SELECT V1SISTEMA' TO COMANDO. */
            _.Move("SELECT V1SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -625- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -628- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -629- DISPLAY 'SISTEMA NAO ENCONTRADO' */
                _.Display($"SISTEMA NAO ENCONTRADO");

                /*" -632- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -635- PERFORM R0050-00-INICIO THRU R0050-99-SAIDA. */

            R0050_00_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/


            /*" -636- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -637- DISPLAY '*** VF0813B *** MOVIMENTO RETORNO VAZIO' */
                    _.Display($"*** VF0813B *** MOVIMENTO RETORNO VAZIO");

                    /*" -639- GO TO 0001-FIM-NORMAL. */

                    M_0001_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -640- IF RA-COD-REG NOT EQUAL 'A' */

            if (RET_HEADER.RA_COD_REG != "A")
            {

                /*" -641- DISPLAY '*** VF0813B *** FITA SEM HEADER' */
                _.Display($"*** VF0813B *** FITA SEM HEADER");

                /*" -644- GO TO 0001-FIM-ANORMAL. */

                M_0001_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -649- MOVE RA-COD-CONVENIO TO WS-CODCONV WHOST-CODCONV. */
            _.Move(RET_HEADER.RA_COD_CONVENIO, WORK_AREA.WS_CODCONV, WHOST_CODCONV);

            /*" -650- IF WS-CODCONV NOT EQUAL 6131 */

            if (WORK_AREA.WS_CODCONV != 6131)
            {

                /*" -652- GO TO 0001-FIM-NORMAL. */

                M_0001_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -654- MOVE RA-NSA TO V0FTCF-NSAC. */
            _.Move(RET_HEADER.RA_NSA, V0FTCF_NSAC);

            /*" -655- MOVE WS-CODCONV TO AUX-CONVENIO */
            _.Move(WORK_AREA.WS_CODCONV, WORK_AREA.AUX_CONVENIO);

            /*" -657- MOVE RA-NSA TO AUX-NSAC. */
            _.Move(RET_HEADER.RA_NSA, WORK_AREA.AUX_NSAC);

            /*" -658- IF WS-CODCONV = 6131 */

            if (WORK_AREA.WS_CODCONV == 6131)
            {

                /*" -660- ADD 29000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 29000;
            }


            /*" -661- MOVE RA-DATA-GERACAO TO WS-DATA-INV. */
            _.Move(RET_HEADER.RA_DATA_GERACAO, WORK_AREA.WS_DATA_INV);

            /*" -662- MOVE WS-ANO-INV TO ANO-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -663- MOVE WS-MES-INV TO MES-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -665- MOVE WS-DIA-INV TO DIA-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -666- MOVE DATA-SQL TO V0FTCF-DTRET. */
            _.Move(WORK_AREA.DATA_SQL, V0FTCF_DTRET);

            /*" -668- MOVE RA-VERSAO-LAYOUT TO V0FTCF-VERSAO. */
            _.Move(RET_HEADER.RA_VERSAO_LAYOUT, V0FTCF_VERSAO);

            /*" -670- WRITE RETERR-RECORD FROM RETDEB-RECORD. */
            _.Move(RETDEB_RECORD.GetMoveValues(), RETERR_RECORD);

            RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

            /*" -672- PERFORM 0090-MONTA-AVISO THRU 0090-FIM. */

            M_0090_MONTA_AVISO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0090_FIM*/


            /*" -673- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -674- DISPLAY '*** VF0813B *** FITA SEM MOVIMENTO ' */
                    _.Display($"*** VF0813B *** FITA SEM MOVIMENTO ");

                    /*" -676- GO TO 0001-FIM-NORMAL. */

                    M_0001_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -677- IF RA-COD-REG NOT EQUAL 'F' AND 'Z' */

            if (!RET_HEADER.RA_COD_REG.In("F", "Z"))
            {

                /*" -678- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                /*" -679- MOVE 'COD REGISTRO NAO ESPERADO' TO RETERR-MENSAGEM */
                _.Move("COD REGISTRO NAO ESPERADO", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -680- WRITE RETERR-RECORD */
                RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                /*" -682- GO TO 0001-FIM-ANORMAL. */

                M_0001_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -683- IF RA-COD-REG EQUAL 'Z' */

            if (RET_HEADER.RA_COD_REG == "Z")
            {

                /*" -684- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                /*" -685- MOVE 'NAO HA RETORNO DE DEBITO' TO RETERR-MENSAGEM */
                _.Move("NAO HA RETORNO DE DEBITO", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -686- WRITE RETERR-RECORD */
                RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                /*" -688- GO TO 0001-FIM-NORMAL. */

                M_0001_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -690- DISPLAY '*** VF0813B *** PROCESSANDO ...' . */
            _.Display($"*** VF0813B *** PROCESSANDO ...");

            /*" -694- PERFORM 0020-PROCESSA THRU 0020-FIM UNTIL WS-EOF = 1 OR RA-COD-REG NOT EQUAL 'F' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADER.RA_COD_REG != "F"))
            {

                M_0020_PROCESSA(true);

                M_0020_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

            }

            /*" -695- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -696- DISPLAY '*** VF0813B *** FITA SEM TRAILLER' */
                _.Display($"*** VF0813B *** FITA SEM TRAILLER");

                /*" -697- GO TO 0001-FIM-ANORMAL */

                M_0001_FIM_ANORMAL(); //GOTO
                return;

                /*" -698- ELSE */
            }
            else
            {


                /*" -699- IF RA-COD-REG NOT EQUAL 'Z' */

                if (RET_HEADER.RA_COD_REG != "Z")
                {

                    /*" -700- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                    _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                    /*" -701- MOVE 'COD REGISTRO NAO ESPERADO' TO RETERR-MENSAGEM */
                    _.Move("COD REGISTRO NAO ESPERADO", RETERR_RECORD.RETERR_MENSAGEM);

                    /*" -702- WRITE RETERR-RECORD */
                    RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                    /*" -704- GO TO 0001-FIM-ANORMAL. */

                    M_0001_FIM_ANORMAL(); //GOTO
                    return;
                }

            }


            /*" -706- WRITE RETERR-RECORD FROM RETDEB-RECORD. */
            _.Move(RETDEB_RECORD.GetMoveValues(), RETERR_RECORD);

            RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

            /*" -708- DISPLAY '*** VF0813B *** LANCAMENTOS RETORNADOS ' WS-REGISTROS. */
            _.Display($"*** VF0813B *** LANCAMENTOS RETORNADOS {WORK_AREA.WS_REGISTROS}");

            /*" -710- DISPLAY '*** VF0813B *** DEBITOS RETORNADOS     ' RZ-TOT-DEB-CRUZ. */
            _.Display($"*** VF0813B *** DEBITOS RETORNADOS     {RET_TRAILLER.RZ_TOT_DEB_CRUZ}");

            /*" -712- DISPLAY '*** VF0813B *** DEBITOS EFETUADOS      ' WS-ACG-TOTDBEFET. */
            _.Display($"*** VF0813B *** DEBITOS EFETUADOS      {WORK_AREA.WS_ACG_TOTDBEFET}");

            /*" -715- DISPLAY '*** VF0813B *** DEBITOS NAO EFET       ' WS-ACG-TOTDBNEFET. */
            _.Display($"*** VF0813B *** DEBITOS NAO EFET       {WORK_AREA.WS_ACG_TOTDBNEFET}");

            /*" -716- IF WS-REGISTROS GREATER ZEROES */

            if (WORK_AREA.WS_REGISTROS > 00)
            {

                /*" -718- PERFORM 0050-GERA-FITACEF THRU 0050-FIM. */

                M_0050_GERA_FITACEF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0050_FIM*/

            }


            /*" -720- IF WS-CODCONV EQUAL 6131 AND AUX-VLPRMTOT NOT EQUAL ZEROS */

            if (WORK_AREA.WS_CODCONV == 6131 && WORK_AREA.AUX_VLPRMTOT != 00)
            {

                /*" -720- PERFORM 0100-INSERT-AVISOS THRU 0100-FIM. */

                M_0100_INSERT_AVISOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -625- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0001-FIM-NORMAL */
        private void M_0001_FIM_NORMAL(bool isPerform = false)
        {
            /*" -725- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -728- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -730- CLOSE RETERR. */
            RETERR.Close();

            /*" -731- DISPLAY '*** VF0813B *** TERMINO NORMAL' . */
            _.Display($"*** VF0813B *** TERMINO NORMAL");

            /*" -733- DISPLAY ' ' . */
            _.Display($" ");

            /*" -735- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -735- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0001-FIM-ANORMAL */
        private void M_0001_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -740- DISPLAY '*** VF0813B *** PROCESSAMENTO TERMINOU COM ERRO' . */
            _.Display($"*** VF0813B *** PROCESSAMENTO TERMINOU COM ERRO");

            /*" -742- DISPLAY '*** VF0813B *** VIDE ARQUIVO RETERR COM MSG' . */
            _.Display($"*** VF0813B *** VIDE ARQUIVO RETERR COM MSG");

            /*" -742- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -745- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -747- CLOSE RETERR. */
            RETERR.Close();

            /*" -749- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -749- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0020-PROCESSA */
        private void M_0020_PROCESSA(bool isPerform = false)
        {
            /*" -758- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

            /*" -760- IF RF-VLPRMTOT EQUAL ZEROS OR RF-COD-RETORNO EQUAL 96 */

            if (RET_CADASTRAMENTO.RF_VLPRMTOT == 00 || RET_CADASTRAMENTO.RF_COD_RETORNO == 96)
            {

                /*" -761- DISPLAY '************************' */
                _.Display($"************************");

                /*" -762- DISPLAY 'DEBITO COM VALOR ZERADO ' */
                _.Display($"DEBITO COM VALOR ZERADO ");

                /*" -763- DISPLAY 'RF-NSA - ' RF-NSA */
                _.Display($"RF-NSA - {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA}");

                /*" -764- DISPLAY 'RF-NSL - ' RF-NSL */
                _.Display($"RF-NSL - {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL}");

                /*" -765- DISPLAY '************************' */
                _.Display($"************************");

                /*" -775- GO TO 0020-NEXT. */

                M_0020_NEXT(); //GOTO
                return;
            }


            /*" -776- MOVE RF-VLPRMTOT TO V0HCOB-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCOB_VLPRMTOT);

            /*" -778- MOVE RF-COD-RETORNO TO V0HCTA-CODRET. */
            _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, V0HCTA_CODRET);

            /*" -781- MOVE 0 TO WS-NAO-ACHEI. */
            _.Move(0, WORK_AREA.WS_NAO_ACHEI);

            /*" -783- IF RF-IDENTIF-NSAS IS NUMERIC AND RF-IDENTIF-NSAS EQUAL ZEROES */

            if (RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSAS.IsNumeric() && RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSAS == 00)
            {

                /*" -784- DISPLAY 'LANCAMENTO SEM NSA/NSL' */
                _.Display($"LANCAMENTO SEM NSA/NSL");

                /*" -785- DISPLAY RETDEB-RECORD */
                _.Display(RETDEB_RECORD);

                /*" -793- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -796- IF RF-COD-RETORNO EQUAL ZEROS AND RF-COD-MOVIMENTO EQUAL ZEROS AND WS-CODCONV EQUAL 6131 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00 && RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 00 && WORK_AREA.WS_CODCONV == 6131)
            {

                /*" -800- PERFORM R8000-00-TRATA-DESPESAS THRU R8000-99-SAIDA. */

                R8000_00_TRATA_DESPESAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

            }


            /*" -802- PERFORM 0025-ACESSO-NSA THRU 0025-FIM. */

            M_0025_ACESSO_NSA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0025_FIM*/


            /*" -803- IF WS-NAO-ACHEI NOT EQUAL 0 */

            if (WORK_AREA.WS_NAO_ACHEI != 0)
            {

                /*" -804- DISPLAY 'LANCAMENTO NAO ENCONTRADO OU JA PROCESSADO' */
                _.Display($"LANCAMENTO NAO ENCONTRADO OU JA PROCESSADO");

                /*" -805- DISPLAY RETDEB-RECORD */
                _.Display(RETDEB_RECORD);

                /*" -807- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -808- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -810- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -820- PERFORM M_0020_PROCESSA_DB_SELECT_1 */

            M_0020_PROCESSA_DB_SELECT_1();

            /*" -823- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -825- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -826- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -827- PERFORM 0021-LOCALIZA-TIT-DEB THRU 0021-FIM */

                M_0021_LOCALIZA_TIT_DEB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0021_FIM*/


                /*" -828- ELSE */
            }
            else
            {


                /*" -830- PERFORM 0022-LOCALIZA-TIT-CRN THRU 0022-FIM. */

                M_0022_LOCALIZA_TIT_CRN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0022_FIM*/

            }


            /*" -832- MOVE 'SELECT V0HISTCOBVA' TO COMANDO. */
            _.Move("SELECT V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -845- PERFORM M_0020_PROCESSA_DB_SELECT_2 */

            M_0020_PROCESSA_DB_SELECT_2();

            /*" -848- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -850- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -851- COMPUTE V0HCOB-OCORHIST = V0HCOB-OCORHIST + 1. */
            V0HCOB_OCORHIST.Value = V0HCOB_OCORHIST + 1;

            /*" -853- MOVE V0HCOB-OCORHIST TO V0HCTA-OCORHISTCOB. */
            _.Move(V0HCOB_OCORHIST, V0HCTA_OCORHISTCOB);

            /*" -854- IF RF-COD-RETORNO NOT EQUAL 00 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO != 00)
            {

                /*" -855- PERFORM 1037-REJEITA-PARCELA THRU 1037-FIM */

                M_1037_REJEITA_PARCELA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1037_FIM*/


                /*" -856- ADD 1 TO WS-REGISTROS */
                WORK_AREA.WS_REGISTROS.Value = WORK_AREA.WS_REGISTROS + 1;

                /*" -858- GO TO 0020-NEXT. */

                M_0020_NEXT(); //GOTO
                return;
            }


            /*" -860- MOVE 'SELECT V0PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -882- PERFORM M_0020_PROCESSA_DB_SELECT_3 */

            M_0020_PROCESSA_DB_SELECT_3();

            /*" -885- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -887- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -888- IF VIND-TEM-SAF LESS 0 */

            if (VIND_TEM_SAF < 0)
            {

                /*" -890- MOVE 'N' TO V0PRVG-TEM-SAF. */
                _.Move("N", V0PRVG_TEM_SAF);
            }


            /*" -891- IF VIND-TEM-CDG LESS 0 */

            if (VIND_TEM_CDG < 0)
            {

                /*" -893- MOVE 'N' TO V0PRVG-TEM-CDG. */
                _.Move("N", V0PRVG_TEM_CDG);
            }


            /*" -901- PERFORM M_0020_PROCESSA_DB_DECLARE_1 */

            M_0020_PROCESSA_DB_DECLARE_1();

            /*" -904- MOVE 'OPEN CCMPTIT' TO COMANDO. */
            _.Move("OPEN CCMPTIT", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -904- PERFORM M_0020_PROCESSA_DB_OPEN_1 */

            M_0020_PROCESSA_DB_OPEN_1();

            /*" -907- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -909- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -910- MOVE 0 TO WS-EOC. */
            _.Move(0, WORK_AREA.WS_EOC);

            /*" -912- PERFORM 1032-FETCH THRU 1032-FIM. */

            M_1032_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1032_FIM*/


            /*" -915- PERFORM 1031-PROC-COMPOSICAO THRU 1031-FIM UNTIL WS-EOC = 1. */

            while (!(WORK_AREA.WS_EOC == 1))
            {

                M_1031_PROC_COMPOSICAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1031_FIM*/

            }

            /*" -916- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -917- MOVE 'CLOSE CCMPTIT' TO COMANDO. */
            _.Move("CLOSE CCMPTIT", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -917- PERFORM M_0020_PROCESSA_DB_CLOSE_1 */

            M_0020_PROCESSA_DB_CLOSE_1();

            /*" -920- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -922- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -924- MOVE 'SELECT V0PARCELVA' TO COMANDO. */
            _.Move("SELECT V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -934- PERFORM M_0020_PROCESSA_DB_SELECT_4 */

            M_0020_PROCESSA_DB_SELECT_4();

            /*" -937- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -939- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -941- COMPUTE WS-VLPRMTOT = V0PARC-PRMVG + V0PARC-PRMAP. */
            WORK_AREA.WS_VLPRMTOT.Value = V0PARC_PRMVG + V0PARC_PRMAP;

            /*" -942- IF V0HCOB-VLPRMTOT EQUAL WS-VLPRMTOT */

            if (V0HCOB_VLPRMTOT == WORK_AREA.WS_VLPRMTOT)
            {

                /*" -943- MOVE V0PARC-PRMVG TO V0HCTB-PRMVG */
                _.Move(V0PARC_PRMVG, V0HCTB_PRMVG);

                /*" -944- MOVE V0PARC-PRMAP TO V0HCTB-PRMAP */
                _.Move(V0PARC_PRMAP, V0HCTB_PRMAP);

                /*" -945- ELSE */
            }
            else
            {


                /*" -946- COMPUTE WS-PC-VG = V0PARC-PRMVG / WS-VLPRMTOT */
                WORK_AREA.WS_PC_VG.Value = V0PARC_PRMVG / WORK_AREA.WS_VLPRMTOT;

                /*" -947- COMPUTE V0HCTB-PRMVG = V0HCOB-VLPRMTOT * WS-PC-VG */
                V0HCTB_PRMVG.Value = V0HCOB_VLPRMTOT * WORK_AREA.WS_PC_VG;

                /*" -950- COMPUTE V0HCTB-PRMAP = V0HCOB-VLPRMTOT - V0HCTB-PRMVG. */
                V0HCTB_PRMAP.Value = V0HCOB_VLPRMTOT - V0HCTB_PRMVG;
            }


            /*" -952- MOVE 'INSERT V0HISTCONTABILVA' TO COMANDO. */
            _.Move("INSERT V0HISTCONTABILVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -969- PERFORM M_0020_PROCESSA_DB_INSERT_1 */

            M_0020_PROCESSA_DB_INSERT_1();

            /*" -972- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -974- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -975- IF V0HCOB-SITUACAO EQUAL '1' */

            if (V0HCOB_SITUACAO == "1")
            {

                /*" -977- PERFORM 1050-GERA-DIFERENCA THRU 1050-FIM. */

                M_1050_GERA_DIFERENCA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1050_FIM*/

            }


            /*" -979- MOVE 'UPDATE V0HISTCOBVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -987- PERFORM M_0020_PROCESSA_DB_UPDATE_1 */

            M_0020_PROCESSA_DB_UPDATE_1();

            /*" -990- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -992- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -994- MOVE 'UPDATE V0FITASASSE' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1001- PERFORM M_0020_PROCESSA_DB_UPDATE_2 */

            M_0020_PROCESSA_DB_UPDATE_2();

            /*" -1004- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1006- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1008- ADD V0HCOB-VLPRMTOT TO WS-ACG-TOTDBEFET. */
            WORK_AREA.WS_ACG_TOTDBEFET.Value = WORK_AREA.WS_ACG_TOTDBEFET + V0HCOB_VLPRMTOT;

            /*" -1010- ADD 1 TO WS-REGISTROS. */
            WORK_AREA.WS_REGISTROS.Value = WORK_AREA.WS_REGISTROS + 1;

            /*" -1011- MOVE RF-IDENTIF-CLI TO VGFOLLOW-NUM-CERTIFICADO. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO);

            /*" -1012- MOVE RF-IDENTIF-NSAS TO VGFOLLOW-NUM-NOSSA-FITA. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSAS, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA);

            /*" -1014- MOVE RF-NSL TO VGFOLLOW-NUM-LANCAMENTO. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO);

            /*" -1014- PERFORM R8800-00-UPDATE-FOLLOWUP. */

            R8800_00_UPDATE_FOLLOWUP_SECTION();

        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-SELECT-1 */
        public void M_0020_PROCESSA_DB_SELECT_1()
        {
            /*" -820- EXEC SQL SELECT PERIPGTO, DIA_DEBITO, OPCAOPAG INTO :V0OPCP-PERIPGTO, :V0OPCP-DIADEB, :V0OPCP-OPCAOPAG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_0020_PROCESSA_DB_SELECT_1_Query1 = new M_0020_PROCESSA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0020_PROCESSA_DB_SELECT_1_Query1.Execute(m_0020_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_DIADEB, V0OPCP_DIADEB);
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
            }


        }

        [StopWatch]
        /*" M-0020-NEXT */
        private void M_0020_NEXT(bool isPerform = false)
        {
            /*" -1018- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -1018- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-SELECT-2 */
        public void M_0020_PROCESSA_DB_SELECT_2()
        {
            /*" -845- EXEC SQL SELECT OCORHIST, NRPARCEL, DTVENCTO, SITUACAO, DTVENCTO - 1 DAY INTO :V0HCOB-OCORHIST, :V0HCOB-NRPARCEL, :V0HCOB-DTVENCTO, :V0HCOB-SITUACAO, :V0HCOB-DTALTOPC FROM SEGUROS.V0HISTCOBVA WHERE NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var m_0020_PROCESSA_DB_SELECT_2_Query1 = new M_0020_PROCESSA_DB_SELECT_2_Query1()
            {
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            var executed_1 = M_0020_PROCESSA_DB_SELECT_2_Query1.Execute(m_0020_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_NRPARCEL, V0HCOB_NRPARCEL);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_DTALTOPC, V0HCOB_DTALTOPC);
            }


        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-DECLARE-1 */
        public void M_0020_PROCESSA_DB_DECLARE_1()
        {
            /*" -901- EXEC SQL DECLARE CCMPTIT CURSOR FOR SELECT NRPARCEL, CODOPER, PRMDIFVG + PRMDIFAP FROM SEGUROS.V0COMPTITVA WHERE NRTIT = :V0HCOB-NRTIT ORDER BY 1 END-EXEC. */
            CCMPTIT = new VF0813B_CCMPTIT(true);
            string GetQuery_CCMPTIT()
            {
                var query = @$"SELECT NRPARCEL
							, 
							CODOPER
							, 
							PRMDIFVG + PRMDIFAP 
							FROM SEGUROS.V0COMPTITVA 
							WHERE NRTIT = '{V0HCOB_NRTIT}' 
							ORDER BY 1";

                return query;
            }
            CCMPTIT.GetQueryEvent += GetQuery_CCMPTIT;

        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-OPEN-1 */
        public void M_0020_PROCESSA_DB_OPEN_1()
        {
            /*" -904- EXEC SQL OPEN CCMPTIT END-EXEC. */

            CCMPTIT.Open();

        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-DECLARE-1 */
        public void M_1035_QUITA_PARCELA_DB_DECLARE_1()
        {
            /*" -1611- EXEC SQL DECLARE CPLCOM CURSOR FOR SELECT DISTINCT CODPDT FROM SEGUROS.V0PLANCOMISVF WHERE NRCERTIF = :V0HCTA-NRCERTIF ORDER BY CODPDT END-EXEC. */
            CPLCOM = new VF0813B_CPLCOM(true);
            string GetQuery_CPLCOM()
            {
                var query = @$"SELECT DISTINCT CODPDT 
							FROM SEGUROS.V0PLANCOMISVF 
							WHERE NRCERTIF = '{V0HCTA_NRCERTIF}' 
							ORDER BY CODPDT";

                return query;
            }
            CPLCOM.GetQueryEvent += GetQuery_CPLCOM;

        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-CLOSE-1 */
        public void M_0020_PROCESSA_DB_CLOSE_1()
        {
            /*" -917- EXEC SQL CLOSE CCMPTIT END-EXEC. */

            CCMPTIT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

        [StopWatch]
        /*" M-0020-PROCESSA-DB-INSERT-1 */
        public void M_0020_PROCESSA_DB_INSERT_1()
        {
            /*" -969- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES (:V0HCTA-NRCERTIF, :V0HCOB-NRPARCEL, :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, 0, :V0HCTB-PRMVG, :V0HCTB-PRMAP, :V0HCOB-DTVENCTO, '0' , 202, CURRENT TIMESTAMP, NULL) END-EXEC. */

            var m_0020_PROCESSA_DB_INSERT_1_Insert1 = new M_0020_PROCESSA_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0HCTB_PRMVG = V0HCTB_PRMVG.ToString(),
                V0HCTB_PRMAP = V0HCTB_PRMAP.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
            };

            M_0020_PROCESSA_DB_INSERT_1_Insert1.Execute(m_0020_PROCESSA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-UPDATE-1 */
        public void M_0020_PROCESSA_DB_UPDATE_1()
        {
            /*" -987- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '1' , OCORHIST = :V0HCOB-OCORHIST, BCOAVISO = :V0AVIS-BCOAVISO, AGEAVISO = :V0AVIS-AGEAVISO, NRAVISO = :V0AVIS-NRAVISO WHERE NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var m_0020_PROCESSA_DB_UPDATE_1_Update1 = new M_0020_PROCESSA_DB_UPDATE_1_Update1()
            {
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            M_0020_PROCESSA_DB_UPDATE_1_Update1.Execute(m_0020_PROCESSA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-SELECT-3 */
        public void M_0020_PROCESSA_DB_SELECT_3()
        {
            /*" -882- EXEC SQL SELECT A.CODCLIEN, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.SITUACAO, A.CODPRODU, B.TEM_SAF, B.TEM_CDG INTO :V0PROP-CODCLIEN, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0PROP-SITUACAO, :V0PROP-CODPRODU, :V0PRVG-TEM-SAF:VIND-TEM-SAF, :V0PRVG-TEM-CDG:VIND-TEM-CDG FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCTA-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES END-EXEC. */

            var m_0020_PROCESSA_DB_SELECT_3_Query1 = new M_0020_PROCESSA_DB_SELECT_3_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0020_PROCESSA_DB_SELECT_3_Query1.Execute(m_0020_PROCESSA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(executed_1.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_FONTE, V0PROP_FONTE);
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PRVG_TEM_SAF, V0PRVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.V0PRVG_TEM_CDG, V0PRVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
            }


        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-UPDATE-2 */
        public void M_0020_PROCESSA_DB_UPDATE_2()
        {
            /*" -1001- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET TOT_DEB_EFET = TOT_DEB_EFET + :V0HCOB-VLPRMTOT, QTDE_LANC_DEB_RET = QTDE_LANC_DEB_RET + 1 WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS END-EXEC. */

            var m_0020_PROCESSA_DB_UPDATE_2_Update1 = new M_0020_PROCESSA_DB_UPDATE_2_Update1()
            {
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
            };

            M_0020_PROCESSA_DB_UPDATE_2_Update1.Execute(m_0020_PROCESSA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0021-LOCALIZA-TIT-DEB */
        private void M_0021_LOCALIZA_TIT_DEB(bool isPerform = false)
        {
            /*" -1027- MOVE '0021-LOCALIZA-TIT-DEB' TO PARAGRAFO. */
            _.Move("0021-LOCALIZA-TIT-DEB", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1029- MOVE 'SELECT V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1036- PERFORM M_0021_LOCALIZA_TIT_DEB_DB_SELECT_1 */

            M_0021_LOCALIZA_TIT_DEB_DB_SELECT_1();

            /*" -1039- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1040- DISPLAY 'ERRO NO ACESSO A PARCELA DA HIST_LANC_CTA' */
                _.Display($"ERRO NO ACESSO A PARCELA DA HIST_LANC_CTA");

                /*" -1041- DISPLAY RETDEB-RECORD */
                _.Display(RETDEB_RECORD);

                /*" -1043- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1045- MOVE 'SELECT MIN V0HISTCOBVA 0' TO COMANDO. */
            _.Move("SELECT MIN V0HISTCOBVA 0", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1053- PERFORM M_0021_LOCALIZA_TIT_DEB_DB_SELECT_2 */

            M_0021_LOCALIZA_TIT_DEB_DB_SELECT_2();

            /*" -1056- IF V0HCOB-NRTIT EQUAL ZEROS */

            if (V0HCOB_NRTIT == 00)
            {

                /*" -1057- MOVE 'SELECT MIN V0HISTCOBVA 1' TO COMANDO */
                _.Move("SELECT MIN V0HISTCOBVA 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1065- PERFORM M_0021_LOCALIZA_TIT_DEB_DB_SELECT_3 */

                M_0021_LOCALIZA_TIT_DEB_DB_SELECT_3();

                /*" -1067- IF V0HCOB-NRTIT EQUAL ZEROS */

                if (V0HCOB_NRTIT == 00)
                {

                    /*" -1068- MOVE 'SELECT MIN V0HISTCOBVA 2' TO COMANDO */
                    _.Move("SELECT MIN V0HISTCOBVA 2", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1077- PERFORM M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4 */

                    M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4();

                    /*" -1079- IF V0HCOB-NRTIT EQUAL ZEROS */

                    if (V0HCOB_NRTIT == 00)
                    {

                        /*" -1080- DISPLAY 'COBRANCA NAO ENCONTRADA' */
                        _.Display($"COBRANCA NAO ENCONTRADA");

                        /*" -1081- DISPLAY V0HCTA-NRCERTIF ' ' V0HCOB-VLPRMTOT */

                        $"{V0HCTA_NRCERTIF} {V0HCOB_VLPRMTOT}"
                        .Display();

                        /*" -1082- DISPLAY RETDEB-RECORD */
                        _.Display(RETDEB_RECORD);

                        /*" -1082- GO TO 9999-ERRO. */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" M-0021-LOCALIZA-TIT-DEB-DB-SELECT-1 */
        public void M_0021_LOCALIZA_TIT_DEB_DB_SELECT_1()
        {
            /*" -1036- EXEC SQL SELECT NRPARCEL INTO :V0HCTA-NRPARCEL FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL END-EXEC. */

            var m_0021_LOCALIZA_TIT_DEB_DB_SELECT_1_Query1 = new M_0021_LOCALIZA_TIT_DEB_DB_SELECT_1_Query1()
            {
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            var executed_1 = M_0021_LOCALIZA_TIT_DEB_DB_SELECT_1_Query1.Execute(m_0021_LOCALIZA_TIT_DEB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
            }


        }

        [StopWatch]
        /*" M-0020-PROCESSA-DB-SELECT-4 */
        public void M_0020_PROCESSA_DB_SELECT_4()
        {
            /*" -934- EXEC SQL SELECT PRMVG, PRMAP, DTVENCTO INTO :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL END-EXEC. */

            var m_0020_PROCESSA_DB_SELECT_4_Query1 = new M_0020_PROCESSA_DB_SELECT_4_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            var executed_1 = M_0020_PROCESSA_DB_SELECT_4_Query1.Execute(m_0020_PROCESSA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" M-0021-LOCALIZA-TIT-DEB-DB-SELECT-2 */
        public void M_0021_LOCALIZA_TIT_DEB_DB_SELECT_2()
        {
            /*" -1053- EXEC SQL SELECT VALUE(MIN(NRTIT),0) INTO :V0HCOB-NRTIT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND SITUACAO = '0' AND VLPRMTOT = :V0HCOB-VLPRMTOT AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC. */

            var m_0021_LOCALIZA_TIT_DEB_DB_SELECT_2_Query1 = new M_0021_LOCALIZA_TIT_DEB_DB_SELECT_2_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = M_0021_LOCALIZA_TIT_DEB_DB_SELECT_2_Query1.Execute(m_0021_LOCALIZA_TIT_DEB_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0021_FIM*/

        [StopWatch]
        /*" M-0021-LOCALIZA-TIT-DEB-DB-SELECT-3 */
        public void M_0021_LOCALIZA_TIT_DEB_DB_SELECT_3()
        {
            /*" -1065- EXEC SQL SELECT VALUE(MIN(NRTIT),0) INTO :V0HCOB-NRTIT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND SITUACAO = '1' AND VLPRMTOT = :V0HCOB-VLPRMTOT END-EXEC */

            var m_0021_LOCALIZA_TIT_DEB_DB_SELECT_3_Query1 = new M_0021_LOCALIZA_TIT_DEB_DB_SELECT_3_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
            };

            var executed_1 = M_0021_LOCALIZA_TIT_DEB_DB_SELECT_3_Query1.Execute(m_0021_LOCALIZA_TIT_DEB_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
            }


        }

        [StopWatch]
        /*" M-0022-LOCALIZA-TIT-CRN */
        private void M_0022_LOCALIZA_TIT_CRN(bool isPerform = false)
        {
            /*" -1091- MOVE '0022-LOCALIZA-TIT-CRN' TO PARAGRAFO. */
            _.Move("0022-LOCALIZA-TIT-CRN", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1093- MOVE 'SELECT V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1100- PERFORM M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1 */

            M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1();

            /*" -1103- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1104- DISPLAY 'ERRO ACESSO PARCELA ' */
                _.Display($"ERRO ACESSO PARCELA ");

                /*" -1105- DISPLAY RETDEB-RECORD */
                _.Display(RETDEB_RECORD);

                /*" -1107- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1109- MOVE 'SELECT V0HISTCOBVA 0' TO COMANDO. */
            _.Move("SELECT V0HISTCOBVA 0", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1116- PERFORM M_0022_LOCALIZA_TIT_CRN_DB_SELECT_2 */

            M_0022_LOCALIZA_TIT_CRN_DB_SELECT_2();

            /*" -1119- IF V0HCOB-NRTIT EQUAL ZEROES */

            if (V0HCOB_NRTIT == 00)
            {

                /*" -1120- MOVE 'SELECT V0HISTCOBVA 1' TO COMANDO */
                _.Move("SELECT V0HISTCOBVA 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1127- PERFORM M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3 */

                M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3();

                /*" -1129- IF V0HCOB-NRTIT EQUAL ZEROES */

                if (V0HCOB_NRTIT == 00)
                {

                    /*" -1130- DISPLAY 'ERRO ACESSO COBRANCA ' */
                    _.Display($"ERRO ACESSO COBRANCA ");

                    /*" -1131- DISPLAY RETDEB-RECORD */
                    _.Display(RETDEB_RECORD);

                    /*" -1131- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0022-LOCALIZA-TIT-CRN-DB-SELECT-1 */
        public void M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1()
        {
            /*" -1100- EXEC SQL SELECT NRPARCEL INTO :V0HCTA-NRPARCEL FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL END-EXEC. */

            var m_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1 = new M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1()
            {
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            var executed_1 = M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1.Execute(m_0022_LOCALIZA_TIT_CRN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
            }


        }

        [StopWatch]
        /*" M-0021-LOCALIZA-TIT-DEB-DB-SELECT-4 */
        public void M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4()
        {
            /*" -1077- EXEC SQL SELECT VALUE(MIN(NRTIT),0) INTO :V0HCOB-NRTIT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND SITUACAO IN ( '2' , '5' ) AND VLPRMTOT = :V0HCOB-VLPRMTOT END-EXEC */

            var m_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1 = new M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
            };

            var executed_1 = M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1.Execute(m_0021_LOCALIZA_TIT_DEB_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
            }


        }

        [StopWatch]
        /*" M-0022-LOCALIZA-TIT-CRN-DB-SELECT-2 */
        public void M_0022_LOCALIZA_TIT_CRN_DB_SELECT_2()
        {
            /*" -1116- EXEC SQL SELECT VALUE(MIN(NRTIT),0) INTO :V0HCOB-NRTIT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND SITUACAO = '0' END-EXEC. */

            var m_0022_LOCALIZA_TIT_CRN_DB_SELECT_2_Query1 = new M_0022_LOCALIZA_TIT_CRN_DB_SELECT_2_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = M_0022_LOCALIZA_TIT_CRN_DB_SELECT_2_Query1.Execute(m_0022_LOCALIZA_TIT_CRN_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0022_FIM*/

        [StopWatch]
        /*" M-0022-LOCALIZA-TIT-CRN-DB-SELECT-3 */
        public void M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3()
        {
            /*" -1127- EXEC SQL SELECT VALUE(MIN(NRTIT),0) INTO :V0HCOB-NRTIT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND SITUACAO = '1' END-EXEC */

            var m_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1 = new M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1.Execute(m_0022_LOCALIZA_TIT_CRN_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
            }


        }

        [StopWatch]
        /*" M-0025-ACESSO-NSA */
        private void M_0025_ACESSO_NSA(bool isPerform = false)
        {
            /*" -1140- MOVE '0025-ACESSO-NSA' TO PARAGRAFO. */
            _.Move("0025-ACESSO-NSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1142- MOVE 'SELECT V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1145- MOVE RF-NSA TO V0HCTA-NSAS. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA, V0HCTA_NSAS);

            /*" -1146- IF RF-IDENTIF-NSAS NOT NUMERIC */

            if (!RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSAS.IsNumeric())
            {

                /*" -1147- ADD 29000 TO V0HCTA-NSAS */
                V0HCTA_NSAS.Value = V0HCTA_NSAS + 29000;

                /*" -1148- ELSE */
            }
            else
            {


                /*" -1150- MOVE RF-IDENTIF-NSAS TO V0HCTA-NSAS. */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSAS, V0HCTA_NSAS);
            }


            /*" -1152- MOVE RF-NSL TO V0HCTA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, V0HCTA_NSL);

            /*" -1159- PERFORM M_0025_ACESSO_NSA_DB_SELECT_1 */

            M_0025_ACESSO_NSA_DB_SELECT_1();

            /*" -1162- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1163- MOVE 'LANCAMENTO NAO ENCONTRADO' TO RETERR-MENSAGEM */
                _.Move("LANCAMENTO NAO ENCONTRADO", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -1163- MOVE 1 TO WS-NAO-ACHEI. */
                _.Move(1, WORK_AREA.WS_NAO_ACHEI);
            }


        }

        [StopWatch]
        /*" M-0025-ACESSO-NSA-DB-SELECT-1 */
        public void M_0025_ACESSO_NSA_DB_SELECT_1()
        {
            /*" -1159- EXEC SQL SELECT NRCERTIF INTO :V0HCTA-NRCERTIF FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL END-EXEC. */

            var m_0025_ACESSO_NSA_DB_SELECT_1_Query1 = new M_0025_ACESSO_NSA_DB_SELECT_1_Query1()
            {
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            var executed_1 = M_0025_ACESSO_NSA_DB_SELECT_1_Query1.Execute(m_0025_ACESSO_NSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NRCERTIF, V0HCTA_NRCERTIF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0025_FIM*/

        [StopWatch]
        /*" M-0050-GERA-FITACEF */
        private void M_0050_GERA_FITACEF(bool isPerform = false)
        {
            /*" -1200- MOVE '0050-GERA-FITACEF' TO PARAGRAFO. */
            _.Move("0050-GERA-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1202- MOVE 'SELECT V0FITACEF' TO COMANDO. */
            _.Move("SELECT V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1207- PERFORM M_0050_GERA_FITACEF_DB_SELECT_1 */

            M_0050_GERA_FITACEF_DB_SELECT_1();

            /*" -1210- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1211- PERFORM 0053-UPDATE-FITACEF THRU 0053-FIM */

                M_0053_UPDATE_FITACEF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0053_FIM*/


                /*" -1212- ELSE */
            }
            else
            {


                /*" -1212- PERFORM 0055-INSERT-FITACEF THRU 0055-FIM. */

                M_0055_INSERT_FITACEF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0055_FIM*/

            }


        }

        [StopWatch]
        /*" M-0050-GERA-FITACEF-DB-SELECT-1 */
        public void M_0050_GERA_FITACEF_DB_SELECT_1()
        {
            /*" -1207- EXEC SQL SELECT DATA_GERACAO INTO :V0FTCF-DTRET FROM SEGUROS.V0FITACEF WHERE NSAC = :V0FTCF-NSAC END-EXEC. */

            var m_0050_GERA_FITACEF_DB_SELECT_1_Query1 = new M_0050_GERA_FITACEF_DB_SELECT_1_Query1()
            {
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
            };

            var executed_1 = M_0050_GERA_FITACEF_DB_SELECT_1_Query1.Execute(m_0050_GERA_FITACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FTCF_DTRET, V0FTCF_DTRET);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0050_FIM*/

        [StopWatch]
        /*" M-0053-UPDATE-FITACEF */
        private void M_0053_UPDATE_FITACEF(bool isPerform = false)
        {
            /*" -1221- MOVE '0053-UPDATE-FITACEF' TO PARAGRAFO. */
            _.Move("0053-UPDATE-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1223- MOVE 'UPDATE V0FITACEF' TO COMANDO. */
            _.Move("UPDATE V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1224- MOVE WS-REGISTROS TO V0FTCF-QTLANCDB. */
            _.Move(WORK_AREA.WS_REGISTROS, V0FTCF_QTLANCDB);

            /*" -1225- MOVE WS-QTDBEFET TO V0FTCF-QTDBEFET. */
            _.Move(WORK_AREA.WS_QTDBEFET, V0FTCF_QTDBEFET);

            /*" -1226- MOVE WS-ACG-TOTDBEFET TO V0FTCF-TOTDBEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBEFET, V0FTCF_TOTDBEFET);

            /*" -1228- MOVE WS-ACG-TOTDBNEFET TO V0FTCF-TOTDBNEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBNEFET, V0FTCF_TOTDBNEFET);

            /*" -1235- PERFORM M_0053_UPDATE_FITACEF_DB_UPDATE_1 */

            M_0053_UPDATE_FITACEF_DB_UPDATE_1();

        }

        [StopWatch]
        /*" M-0053-UPDATE-FITACEF-DB-UPDATE-1 */
        public void M_0053_UPDATE_FITACEF_DB_UPDATE_1()
        {
            /*" -1235- EXEC SQL UPDATE SEGUROS.V0FITACEF SET QTDE_LANC_DEB_RET = :V0FTCF-QTLANCDB, TOT_DEB_EFET = :V0FTCF-TOTDBEFET, TOT_DEB_NAO_EFET = :V0FTCF-TOTDBNEFET, QTDE_DEB_EFET = :V0FTCF-QTDBEFET WHERE NSAC = :V0FTCF-NSAC END-EXEC. */

            var m_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1 = new M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1()
            {
                V0FTCF_TOTDBNEFET = V0FTCF_TOTDBNEFET.ToString(),
                V0FTCF_TOTDBEFET = V0FTCF_TOTDBEFET.ToString(),
                V0FTCF_QTLANCDB = V0FTCF_QTLANCDB.ToString(),
                V0FTCF_QTDBEFET = V0FTCF_QTDBEFET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
            };

            M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1.Execute(m_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0053_FIM*/

        [StopWatch]
        /*" M-0055-INSERT-FITACEF */
        private void M_0055_INSERT_FITACEF(bool isPerform = false)
        {
            /*" -1244- MOVE '0055-INSERT-FITACEF' TO PARAGRAFO. */
            _.Move("0055-INSERT-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1246- MOVE 'INSERT V0FITACEF' TO COMANDO. */
            _.Move("INSERT V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1247- MOVE RZ-QTDE-REGISTROS TO V0FTCF-QTREG. */
            _.Move(RET_TRAILLER.RZ_QTDE_REGISTROS, V0FTCF_QTREG);

            /*" -1248- MOVE WS-REGISTROS TO V0FTCF-QTLANCDB. */
            _.Move(WORK_AREA.WS_REGISTROS, V0FTCF_QTLANCDB);

            /*" -1249- MOVE WS-QTDBEFET TO V0FTCF-QTDBEFET. */
            _.Move(WORK_AREA.WS_QTDBEFET, V0FTCF_QTDBEFET);

            /*" -1250- MOVE WS-ACG-TOTDBEFET TO V0FTCF-TOTDBEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBEFET, V0FTCF_TOTDBEFET);

            /*" -1252- MOVE WS-ACG-TOTDBNEFET TO V0FTCF-TOTDBNEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBNEFET, V0FTCF_TOTDBNEFET);

            /*" -1266- PERFORM M_0055_INSERT_FITACEF_DB_INSERT_1 */

            M_0055_INSERT_FITACEF_DB_INSERT_1();

        }

        [StopWatch]
        /*" M-0055-INSERT-FITACEF-DB-INSERT-1 */
        public void M_0055_INSERT_FITACEF_DB_INSERT_1()
        {
            /*" -1266- EXEC SQL INSERT INTO SEGUROS.V0FITACEF VALUES (:V0FTCF-NSAC, :V0FTCF-DTRET, :V0FTCF-VERSAO, :V0FTCF-QTREG, :V0FTCF-QTLANCDB, :V0FTCF-TOTDBEFET, :V0FTCF-TOTDBNEFET, 0, 0, 0, :V0FTCF-QTDBEFET, 0) END-EXEC. */

            var m_0055_INSERT_FITACEF_DB_INSERT_1_Insert1 = new M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1()
            {
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0FTCF_DTRET = V0FTCF_DTRET.ToString(),
                V0FTCF_VERSAO = V0FTCF_VERSAO.ToString(),
                V0FTCF_QTREG = V0FTCF_QTREG.ToString(),
                V0FTCF_QTLANCDB = V0FTCF_QTLANCDB.ToString(),
                V0FTCF_TOTDBEFET = V0FTCF_TOTDBEFET.ToString(),
                V0FTCF_TOTDBNEFET = V0FTCF_TOTDBNEFET.ToString(),
                V0FTCF_QTDBEFET = V0FTCF_QTDBEFET.ToString(),
            };

            M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1.Execute(m_0055_INSERT_FITACEF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0055_FIM*/

        [StopWatch]
        /*" M-0090-MONTA-AVISO */
        private void M_0090_MONTA_AVISO(bool isPerform = false)
        {
            /*" -1275- MOVE '0090-MONTA-AVISO   ' TO PARAGRAFO. */
            _.Move("0090-MONTA-AVISO   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1277- MOVE 'MONTA AVISO       ' TO COMANDO. */
            _.Move("MONTA AVISO       ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1278- MOVE 104 TO V0AVIS-BCOAVISO */
            _.Move(104, V0AVIS_BCOAVISO);

            /*" -1279- MOVE 7383 TO V0AVIS-AGEAVISO */
            _.Move(7383, V0AVIS_AGEAVISO);

            /*" -1280- MOVE 2 TO V0AVIS-ORIGAVISO */
            _.Move(2, V0AVIS_ORIGAVISO);

            /*" -1281- MOVE AUX-CONVENIO TO WS-AGEAVISO */
            _.Move(WORK_AREA.AUX_CONVENIO, WORK_AREA.FILLER_7.WS_AGEAVISO);

            /*" -1283- MOVE AUX-NSAC TO WS-NSAC. */
            _.Move(WORK_AREA.AUX_NSAC, WORK_AREA.FILLER_7.WS_NSAC);

            /*" -1284- MOVE WS-NRAVISO TO V0AVIS-NRAVISO */
            _.Move(WORK_AREA.WS_NRAVISO, V0AVIS_NRAVISO);

            /*" -1285- MOVE 1 TO V0AVIS-NRSEQ */
            _.Move(1, V0AVIS_NRSEQ);

            /*" -1286- MOVE V0SIST-DTMOVABE TO V0AVIS-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0AVIS_DTMOVTO);

            /*" -1287- MOVE 100 TO V0AVIS-OPERACAO */
            _.Move(100, V0AVIS_OPERACAO);

            /*" -1288- MOVE 'C' TO V0AVIS-TIPAVI */
            _.Move("C", V0AVIS_TIPAVI);

            /*" -1289- MOVE V0FTCF-DTRET TO V0AVIS-DTAVISO */
            _.Move(V0FTCF_DTRET, V0AVIS_DTAVISO);

            /*" -1290- MOVE ZEROS TO V0AVIS-VLIOCC */
            _.Move(0, V0AVIS_VLIOCC);

            /*" -1291- MOVE ZEROS TO V0AVIS-VLDESPES */
            _.Move(0, V0AVIS_VLDESPES);

            /*" -1292- MOVE ZEROS TO V0AVIS-PRECED */
            _.Move(0, V0AVIS_PRECED);

            /*" -1293- MOVE '0' TO V0AVIS-SITCONTB */
            _.Move("0", V0AVIS_SITCONTB);

            /*" -1294- MOVE ZEROS TO V0AVIS-CODEMP */
            _.Move(0, V0AVIS_CODEMP);

            /*" -1296- MOVE ZEROS TO V0AVIS-VALADT. */
            _.Move(0, V0AVIS_VALADT);

            /*" -1297- MOVE ZEROS TO AUX-VLPRMTOT AUX-VLDESPES. */
            _.Move(0, WORK_AREA.AUX_VLPRMTOT, WORK_AREA.AUX_VLDESPES);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0090_FIM*/

        [StopWatch]
        /*" M-0100-INSERT-AVISOS */
        private void M_0100_INSERT_AVISOS(bool isPerform = false)
        {
            /*" -1305- MOVE '0100-INSERT-AVISOS ' TO PARAGRAFO. */
            _.Move("0100-INSERT-AVISOS ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1307- MOVE 'INSERT V0AVISOCRED' TO COMANDO. */
            _.Move("INSERT V0AVISOCRED", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1308- MOVE AUX-VLPRMTOT TO V0AVIS-VLPRMTOT. */
            _.Move(WORK_AREA.AUX_VLPRMTOT, V0AVIS_VLPRMTOT);

            /*" -1310- MOVE AUX-VLDESPES TO V0AVIS-VLDESPES. */
            _.Move(WORK_AREA.AUX_VLDESPES, V0AVIS_VLDESPES);

            /*" -1313- COMPUTE V0AVIS-VLPRMLIQ EQUAL V0AVIS-VLPRMTOT - V0AVIS-VLDESPES. */
            V0AVIS_VLPRMLIQ.Value = V0AVIS_VLPRMTOT - V0AVIS_VLDESPES;

            /*" -1317- MOVE ZEROS TO VIND-CODEMP VIND-ORIGAVISO VIND-VALADT. */
            _.Move(0, VIND_CODEMP, VIND_ORIGAVISO, VIND_VALADT);

            /*" -1319- MOVE 'P' TO V0AVIS-SITDEPTER. */
            _.Move("P", V0AVIS_SITDEPTER);

            /*" -1340- PERFORM M_0100_INSERT_AVISOS_DB_INSERT_1 */

            M_0100_INSERT_AVISOS_DB_INSERT_1();

            /*" -1343- MOVE V0AVIS-CODEMP TO V0SALD-CODEMP */
            _.Move(V0AVIS_CODEMP, V0SALD_CODEMP);

            /*" -1344- MOVE V0AVIS-BCOAVISO TO V0SALD-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0SALD_BCOAVISO);

            /*" -1345- MOVE V0AVIS-AGEAVISO TO V0SALD-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0SALD_AGEAVISO);

            /*" -1346- MOVE '1' TO V0SALD-TIPSGU */
            _.Move("1", V0SALD_TIPSGU);

            /*" -1347- MOVE V0AVIS-NRAVISO TO V0SALD-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0SALD_NRAVISO);

            /*" -1348- MOVE V0AVIS-DTAVISO TO V0SALD-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0SALD_DTAVISO);

            /*" -1349- MOVE V0AVIS-DTMOVTO TO V0SALD-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0SALD_DTMOVTO);

            /*" -1350- MOVE ZEROS TO V0SALD-SDOATU */
            _.Move(0, V0SALD_SDOATU);

            /*" -1352- MOVE '0' TO V0SALD-SITUACAO. */
            _.Move("0", V0SALD_SITUACAO);

            /*" -1364- PERFORM M_0100_INSERT_AVISOS_DB_INSERT_2 */

            M_0100_INSERT_AVISOS_DB_INSERT_2();

            /*" -1368- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -1369- PERFORM R8500-00-GRAVA-DESPESAS THRU R8500-99-SAIDA 800 TIMES. */

            R8500_00_GRAVA_DESPESAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/


        }

        [StopWatch]
        /*" M-0100-INSERT-AVISOS-DB-INSERT-1 */
        public void M_0100_INSERT_AVISOS_DB_INSERT_1()
        {
            /*" -1340- EXEC SQL INSERT INTO SEGUROS.V0AVISOCRED VALUES (:V0AVIS-BCOAVISO , :V0AVIS-AGEAVISO , :V0AVIS-NRAVISO , :V0AVIS-NRSEQ , :V0AVIS-DTMOVTO , :V0AVIS-OPERACAO , :V0AVIS-TIPAVI , :V0AVIS-DTAVISO , :V0AVIS-VLIOCC , :V0AVIS-VLDESPES , :V0AVIS-PRECED , :V0AVIS-VLPRMLIQ , :V0AVIS-VLPRMTOT , :V0AVIS-SITCONTB , :V0AVIS-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0AVIS-ORIGAVISO:VIND-ORIGAVISO , :V0AVIS-VALADT:VIND-VALADT , :V0AVIS-SITDEPTER) END-EXEC. */

            var m_0100_INSERT_AVISOS_DB_INSERT_1_Insert1 = new M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1()
            {
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
                V0AVIS_DTMOVTO = V0AVIS_DTMOVTO.ToString(),
                V0AVIS_OPERACAO = V0AVIS_OPERACAO.ToString(),
                V0AVIS_TIPAVI = V0AVIS_TIPAVI.ToString(),
                V0AVIS_DTAVISO = V0AVIS_DTAVISO.ToString(),
                V0AVIS_VLIOCC = V0AVIS_VLIOCC.ToString(),
                V0AVIS_VLDESPES = V0AVIS_VLDESPES.ToString(),
                V0AVIS_PRECED = V0AVIS_PRECED.ToString(),
                V0AVIS_VLPRMLIQ = V0AVIS_VLPRMLIQ.ToString(),
                V0AVIS_VLPRMTOT = V0AVIS_VLPRMTOT.ToString(),
                V0AVIS_SITCONTB = V0AVIS_SITCONTB.ToString(),
                V0AVIS_CODEMP = V0AVIS_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0AVIS_ORIGAVISO = V0AVIS_ORIGAVISO.ToString(),
                VIND_ORIGAVISO = VIND_ORIGAVISO.ToString(),
                V0AVIS_VALADT = V0AVIS_VALADT.ToString(),
                VIND_VALADT = VIND_VALADT.ToString(),
                V0AVIS_SITDEPTER = V0AVIS_SITDEPTER.ToString(),
            };

            M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1.Execute(m_0100_INSERT_AVISOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-INSERT-AVISOS-DB-INSERT-2 */
        public void M_0100_INSERT_AVISOS_DB_INSERT_2()
        {
            /*" -1364- EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS VALUES (:V0SALD-CODEMP , :V0SALD-BCOAVISO , :V0SALD-AGEAVISO , :V0SALD-TIPSGU , :V0SALD-NRAVISO , :V0SALD-DTAVISO , :V0SALD-DTMOVTO , :V0SALD-SDOATU , :V0SALD-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var m_0100_INSERT_AVISOS_DB_INSERT_2_Insert1 = new M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1()
            {
                V0SALD_CODEMP = V0SALD_CODEMP.ToString(),
                V0SALD_BCOAVISO = V0SALD_BCOAVISO.ToString(),
                V0SALD_AGEAVISO = V0SALD_AGEAVISO.ToString(),
                V0SALD_TIPSGU = V0SALD_TIPSGU.ToString(),
                V0SALD_NRAVISO = V0SALD_NRAVISO.ToString(),
                V0SALD_DTAVISO = V0SALD_DTAVISO.ToString(),
                V0SALD_DTMOVTO = V0SALD_DTMOVTO.ToString(),
                V0SALD_SDOATU = V0SALD_SDOATU.ToString(),
                V0SALD_SITUACAO = V0SALD_SITUACAO.ToString(),
            };

            M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1.Execute(m_0100_INSERT_AVISOS_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-1031-PROC-COMPOSICAO */
        private void M_1031_PROC_COMPOSICAO(bool isPerform = false)
        {
            /*" -1381- IF V0CMPT-CODOPER NOT EQUAL 0 AND 121 AND 122 AND 123 */

            if (!V0CMPT_CODOPER.In("0", "121", "122", "123"))
            {

                /*" -1382- PERFORM M-1033-APROPRIA-DIFERENCA THRU 1033-FIM */

                M_1033_APROPRIA_DIFERENCA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1033_FIM*/


                /*" -1383- ELSE */
            }
            else
            {


                /*" -1385- PERFORM 1035-QUITA-PARCELA THRU 1035-FIM. */

                M_1035_QUITA_PARCELA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1035_FIM*/

            }


            /*" -1385- PERFORM 1032-FETCH THRU 1032-FIM. */

            M_1032_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1032_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1031_FIM*/

        [StopWatch]
        /*" M-1032-FETCH */
        private void M_1032_FETCH(bool isPerform = false)
        {
            /*" -1394- MOVE '1032-FETCH' TO PARAGRAFO. */
            _.Move("1032-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1396- MOVE 'FETCH CCMPTIT' TO COMANDO. */
            _.Move("FETCH CCMPTIT", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1401- PERFORM M_1032_FETCH_DB_FETCH_1 */

            M_1032_FETCH_DB_FETCH_1();

            /*" -1404- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1404- MOVE 1 TO WS-EOC. */
                _.Move(1, WORK_AREA.WS_EOC);
            }


        }

        [StopWatch]
        /*" M-1032-FETCH-DB-FETCH-1 */
        public void M_1032_FETCH_DB_FETCH_1()
        {
            /*" -1401- EXEC SQL FETCH CCMPTIT INTO :V0CMPT-NRPARCEL, :V0CMPT-CODOPER, :V0CMPT-VLPRMDIF END-EXEC. */

            if (CCMPTIT.Fetch())
            {
                _.Move(CCMPTIT.V0CMPT_NRPARCEL, V0CMPT_NRPARCEL);
                _.Move(CCMPTIT.V0CMPT_CODOPER, V0CMPT_CODOPER);
                _.Move(CCMPTIT.V0CMPT_VLPRMDIF, V0CMPT_VLPRMDIF);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1032_FIM*/

        [StopWatch]
        /*" M-1033-APROPRIA-DIFERENCA */
        private void M_1033_APROPRIA_DIFERENCA(bool isPerform = false)
        {
            /*" -1413- MOVE '1033-APROPRIA-DIFERENCA' TO PARAGRAFO. */
            _.Move("1033-APROPRIA-DIFERENCA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1415- MOVE 'UPDATE V0DIFPARCELVA' TO COMANDO. */
            _.Move("UPDATE V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1423- PERFORM M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1 */

            M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1();

            /*" -1426- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1426- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1033-APROPRIA-DIFERENCA-DB-UPDATE-1 */
        public void M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1()
        {
            /*" -1423- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCELDIF = :V0CMPT-NRPARCEL AND CODOPER = :V0CMPT-CODOPER AND SITUACAO = ' ' END-EXEC. */

            var m_1033_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1 = new M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0CMPT_NRPARCEL = V0CMPT_NRPARCEL.ToString(),
                V0CMPT_CODOPER = V0CMPT_CODOPER.ToString(),
            };

            M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1.Execute(m_1033_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1033_FIM*/

        [StopWatch]
        /*" M-1035-QUITA-PARCELA */
        private void M_1035_QUITA_PARCELA(bool isPerform = false)
        {
            /*" -1438- ADD 1 TO WS-QTDBEFET. */
            WORK_AREA.WS_QTDBEFET.Value = WORK_AREA.WS_QTDBEFET + 1;

            /*" -1440- IF V0HCOB-SITUACAO EQUAL '0' AND V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0HCOB_SITUACAO == "0" && V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -1441- PERFORM 1101-ACHA-PARCELA THRU 1101-FIM */

                M_1101_ACHA_PARCELA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1101_FIM*/


                /*" -1442- IF WS-ACHOU EQUAL 0 */

                if (WORK_AREA.WS_ACHOU == 0)
                {

                    /*" -1443- PERFORM 1036-BAIXA-HISTCTA THRU 1036-FIM */

                    M_1036_BAIXA_HISTCTA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1036_FIM*/


                    /*" -1444- GO TO 1035-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1035_FIM*/ //GOTO
                    return;

                    /*" -1445- END-IF */
                }


                /*" -1446- ELSE */
            }
            else
            {


                /*" -1448- MOVE V0HCOB-NRPARCEL TO V0PARC-NRPARCEL. */
                _.Move(V0HCOB_NRPARCEL, V0PARC_NRPARCEL);
            }


            /*" -1449- MOVE '1035-QUITA-PARCELA' TO PARAGRAFO. */
            _.Move("1035-QUITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1451- MOVE 'SELECT MAX V0HISTCONTAVA 1' TO COMANDO. */
            _.Move("SELECT MAX V0HISTCONTAVA 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1459- PERFORM M_1035_QUITA_PARCELA_DB_SELECT_1 */

            M_1035_QUITA_PARCELA_DB_SELECT_1();

            /*" -1462- IF V0HCTA-OCORHISTCTA EQUAL 0 */

            if (V0HCTA_OCORHISTCTA == 0)
            {

                /*" -1463- MOVE 'SELECT MAX V0HISTCONTAVA 2' TO COMANDO */
                _.Move("SELECT MAX V0HISTCONTAVA 2", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1471- PERFORM M_1035_QUITA_PARCELA_DB_SELECT_2 */

                M_1035_QUITA_PARCELA_DB_SELECT_2();

                /*" -1473- IF V0HCTA-OCORHISTCTA EQUAL 0 */

                if (V0HCTA_OCORHISTCTA == 0)
                {

                    /*" -1474- MOVE 'SELECT V0HISTCONTAVA' TO COMANDO */
                    _.Move("SELECT V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1483- PERFORM M_1035_QUITA_PARCELA_DB_SELECT_3 */

                    M_1035_QUITA_PARCELA_DB_SELECT_3();

                    /*" -1485- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1486- DISPLAY 'ERRO ACESSO PARCELA ' */
                        _.Display($"ERRO ACESSO PARCELA ");

                        /*" -1487- DISPLAY RETDEB-RECORD */
                        _.Display(RETDEB_RECORD);

                        /*" -1488- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1489- ELSE */
                    }
                    else
                    {


                        /*" -1491- MOVE V0PARC-NRPARCEL TO V0HCOB-NRPARCEL. */
                        _.Move(V0PARC_NRPARCEL, V0HCOB_NRPARCEL);
                    }

                }

            }


            /*" -1493- MOVE 'SELECT V0PARCELVA' TO COMANDO. */
            _.Move("SELECT V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1499- PERFORM M_1035_QUITA_PARCELA_DB_SELECT_4 */

            M_1035_QUITA_PARCELA_DB_SELECT_4();

            /*" -1502- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1503- DISPLAY 'PARCELA NAO ENCONTRADA' */
                _.Display($"PARCELA NAO ENCONTRADA");

                /*" -1504- DISPLAY RETDEB-RECORD */
                _.Display(RETDEB_RECORD);

                /*" -1506- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1508- MOVE 'UPDATE V0PARCELVA' TO COMANDO. */
            _.Move("UPDATE V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1514- PERFORM M_1035_QUITA_PARCELA_DB_UPDATE_1 */

            M_1035_QUITA_PARCELA_DB_UPDATE_1();

            /*" -1517- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1519- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1521- MOVE 'UPDATE V0HISTCONTAVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1531- PERFORM M_1035_QUITA_PARCELA_DB_UPDATE_2 */

            M_1035_QUITA_PARCELA_DB_UPDATE_2();

            /*" -1534- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1536- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1538- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1551- PERFORM M_1035_QUITA_PARCELA_DB_SELECT_5 */

            M_1035_QUITA_PARCELA_DB_SELECT_5();

            /*" -1554- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1556- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1557- IF V0COBP-VLCUSTAUXF-I < ZEROS */

            if (V0COBP_VLCUSTAUXF_I < 00)
            {

                /*" -1558- MOVE ZEROS TO V0COBP-IMPSEGAUXF */
                _.Move(0, V0COBP_IMPSEGAUXF);

                /*" -1560- MOVE ZEROS TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -1562- MOVE 'SELECT V0CDGCOBER' TO COMANDO. */
            _.Move("SELECT V0CDGCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1568- PERFORM M_1035_QUITA_PARCELA_DB_SELECT_6 */

            M_1035_QUITA_PARCELA_DB_SELECT_6();

            /*" -1571- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1572- PERFORM 1100-REPASSA-CDG THRU 1100-FIM */

                M_1100_REPASSA_CDG(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


                /*" -1573- ELSE */
            }
            else
            {


                /*" -1578- IF SQLCODE EQUAL 100 AND V0PARC-NRPARCEL = 1 AND V0PRVG-TEM-SAF = 'S' AND V0COBP-VLCUSTCDG > ZEROS AND V0PROP-SITUACAO = '3' OR '6' */

                if (DB.SQLCODE == 100 && V0PARC_NRPARCEL == 1 && V0PRVG_TEM_SAF == "S" && V0COBP_VLCUSTCDG > 00 && V0PROP_SITUACAO.In("3", "6"))
                {

                    /*" -1580- PERFORM 1099-INCLUI-CDG THRU 1099-FIM. */

                    M_1099_INCLUI_CDG(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1099_FIM*/

                }

            }


            /*" -1582- MOVE 'SELECT V0SAFCOBER' TO COMANDO. */
            _.Move("SELECT V0SAFCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1588- PERFORM M_1035_QUITA_PARCELA_DB_SELECT_7 */

            M_1035_QUITA_PARCELA_DB_SELECT_7();

            /*" -1591- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1592- IF V0PRVG-TEM-SAF = 'S' */

                if (V0PRVG_TEM_SAF == "S")
                {

                    /*" -1593- PERFORM 1200-REPASSA-SAF THRU 1200-FIM */

                    M_1200_REPASSA_SAF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


                    /*" -1595- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1596- ELSE */
                }

            }
            else
            {


                /*" -1601- IF SQLCODE EQUAL 100 AND V0PARC-NRPARCEL = 1 AND V0PRVG-TEM-SAF = 'S' AND V0COBP-VLCUSTAUXF > ZEROS AND V0PROP-SITUACAO = '3' OR '6' */

                if (DB.SQLCODE == 100 && V0PARC_NRPARCEL == 1 && V0PRVG_TEM_SAF == "S" && V0COBP_VLCUSTAUXF > 00 && V0PROP_SITUACAO.In("3", "6"))
                {

                    /*" -1603- PERFORM 1199-INCLUI-SAF THRU 1199-FIM. */

                    M_1199_INCLUI_SAF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1199_FIM*/

                }

            }


            /*" -1605- MOVE '1000-QUITA-PARCELA' TO PARAGRAFO. */
            _.Move("1000-QUITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1611- PERFORM M_1035_QUITA_PARCELA_DB_DECLARE_1 */

            M_1035_QUITA_PARCELA_DB_DECLARE_1();

            /*" -1614- MOVE 'OPEN CPLCOM' TO COMANDO. */
            _.Move("OPEN CPLCOM", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1614- PERFORM M_1035_QUITA_PARCELA_DB_OPEN_1 */

            M_1035_QUITA_PARCELA_DB_OPEN_1();

            /*" -1617- MOVE 0 TO WS-EOP. */
            _.Move(0, WORK_AREA.WS_EOP);

            /*" -1619- PERFORM 1041-FETCH THRU 1041-FIM. */

            M_1041_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1041_FIM*/


            /*" -1622- PERFORM 1040-GERA-EVENTO THRU 1040-FIM UNTIL WS-EOP = 1. */

            while (!(WORK_AREA.WS_EOP == 1))
            {

                M_1040_GERA_EVENTO(true);

                M_1040_LOOP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1040_FIM*/

            }

            /*" -1623- MOVE 'CLOSE CPLCOM' TO COMANDO. */
            _.Move("CLOSE CPLCOM", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1623- PERFORM M_1035_QUITA_PARCELA_DB_CLOSE_1 */

            M_1035_QUITA_PARCELA_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-SELECT-1 */
        public void M_1035_QUITA_PARCELA_DB_SELECT_1()
        {
            /*" -1459- EXEC SQL SELECT VALUE(MAX(OCORRHISTCTA),0) INTO :V0HCTA-OCORHISTCTA FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL AND VLPRMTOT = :V0CMPT-VLPRMDIF AND SITUACAO = '3' END-EXEC. */

            var m_1035_QUITA_PARCELA_DB_SELECT_1_Query1 = new M_1035_QUITA_PARCELA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0CMPT_VLPRMDIF = V0CMPT_VLPRMDIF.ToString(),
            };

            var executed_1 = M_1035_QUITA_PARCELA_DB_SELECT_1_Query1.Execute(m_1035_QUITA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1035_FIM*/

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-SELECT-2 */
        public void M_1035_QUITA_PARCELA_DB_SELECT_2()
        {
            /*" -1471- EXEC SQL SELECT VALUE(MAX(OCORRHISTCTA),0) INTO :V0HCTA-OCORHISTCTA FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL AND VLPRMTOT = :V0HCOB-VLPRMTOT AND SITUACAO = '3' END-EXEC */

            var m_1035_QUITA_PARCELA_DB_SELECT_2_Query1 = new M_1035_QUITA_PARCELA_DB_SELECT_2_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
            };

            var executed_1 = M_1035_QUITA_PARCELA_DB_SELECT_2_Query1.Execute(m_1035_QUITA_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
            }


        }

        [StopWatch]
        /*" M-1036-BAIXA-HISTCTA */
        private void M_1036_BAIXA_HISTCTA(bool isPerform = false)
        {
            /*" -1630- MOVE '1036-BAIXA-HISTCTA' TO PARAGRAFO. */
            _.Move("1036-BAIXA-HISTCTA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1632- MOVE 'UPDATE V0HISTCONTAVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1641- PERFORM M_1036_BAIXA_HISTCTA_DB_UPDATE_1 */

            M_1036_BAIXA_HISTCTA_DB_UPDATE_1();

            /*" -1644- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1644- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1036-BAIXA-HISTCTA-DB-UPDATE-1 */
        public void M_1036_BAIXA_HISTCTA_DB_UPDATE_1()
        {
            /*" -1641- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '1' , NSAC = :V0FTCF-NSAC, CODRET = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL END-EXEC. */

            var m_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1 = new M_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1()
            {
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            M_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1.Execute(m_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-UPDATE-1 */
        public void M_1035_QUITA_PARCELA_DB_UPDATE_1()
        {
            /*" -1514- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var m_1035_QUITA_PARCELA_DB_UPDATE_1_Update1 = new M_1035_QUITA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            M_1035_QUITA_PARCELA_DB_UPDATE_1_Update1.Execute(m_1035_QUITA_PARCELA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-SELECT-3 */
        public void M_1035_QUITA_PARCELA_DB_SELECT_3()
        {
            /*" -1483- EXEC SQL SELECT NRPARCEL, OCORRHISTCTA INTO :V0PARC-NRPARCEL, :V0HCTA-OCORHISTCTA FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL END-EXEC */

            var m_1035_QUITA_PARCELA_DB_SELECT_3_Query1 = new M_1035_QUITA_PARCELA_DB_SELECT_3_Query1()
            {
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            var executed_1 = M_1035_QUITA_PARCELA_DB_SELECT_3_Query1.Execute(m_1035_QUITA_PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(executed_1.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
            }


        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-UPDATE-2 */
        public void M_1035_QUITA_PARCELA_DB_UPDATE_2()
        {
            /*" -1531- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '1' , NSAC = :V0FTCF-NSAC, CODRET = :V0HCTA-CODRET, OCORHIST = :V0HCTA-OCORHISTCOB, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL AND OCORRHISTCTA = :V0HCTA-OCORHISTCTA END-EXEC. */

            var m_1035_QUITA_PARCELA_DB_UPDATE_2_Update1 = new M_1035_QUITA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HCTA_OCORHISTCOB = V0HCTA_OCORHISTCOB.ToString(),
                V0HCTA_CODRET = V0HCTA_CODRET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0HCTA_OCORHISTCTA = V0HCTA_OCORHISTCTA.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            M_1035_QUITA_PARCELA_DB_UPDATE_2_Update1.Execute(m_1035_QUITA_PARCELA_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1036_FIM*/

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-SELECT-4 */
        public void M_1035_QUITA_PARCELA_DB_SELECT_4()
        {
            /*" -1499- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var m_1035_QUITA_PARCELA_DB_SELECT_4_Query1 = new M_1035_QUITA_PARCELA_DB_SELECT_4_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = M_1035_QUITA_PARCELA_DB_SELECT_4_Query1.Execute(m_1035_QUITA_PARCELA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-OPEN-1 */
        public void M_1035_QUITA_PARCELA_DB_OPEN_1()
        {
            /*" -1614- EXEC SQL OPEN CPLCOM END-EXEC. */

            CPLCOM.Open();

        }

        [StopWatch]
        /*" M-1101-ACHA-PARCELA-DB-DECLARE-1 */
        public void M_1101_ACHA_PARCELA_DB_DECLARE_1()
        {
            /*" -2148- EXEC SQL DECLARE CPARC1 CURSOR FOR SELECT NRPARCEL, PRMVG + PRMAP FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND SITUACAO = ' ' ORDER BY NRPARCEL END-EXEC. */
            CPARC1 = new VF0813B_CPARC1(true);
            string GetQuery_CPARC1()
            {
                var query = @$"SELECT NRPARCEL
							, 
							PRMVG + PRMAP 
							FROM SEGUROS.V0PARCELVA 
							WHERE NRCERTIF = '{V0HCTA_NRCERTIF}' 
							AND SITUACAO = ' ' 
							ORDER BY NRPARCEL";

                return query;
            }
            CPARC1.GetQueryEvent += GetQuery_CPARC1;

        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-CLOSE-1 */
        public void M_1035_QUITA_PARCELA_DB_CLOSE_1()
        {
            /*" -1623- EXEC SQL CLOSE CPLCOM END-EXEC. */

            CPLCOM.Close();

        }

        [StopWatch]
        /*" M-1040-GERA-EVENTO */
        private void M_1040_GERA_EVENTO(bool isPerform = false)
        {
            /*" -1655- MOVE '1040-GERA-EVENTO' TO PARAGRAFO. */
            _.Move("1040-GERA-EVENTO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1657- MOVE 'SELECT V0PRODUTORVF' TO COMANDO. */
            _.Move("SELECT V0PRODUTORVF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1662- PERFORM M_1040_GERA_EVENTO_DB_SELECT_1 */

            M_1040_GERA_EVENTO_DB_SELECT_1();

            /*" -1665- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1665- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1040-GERA-EVENTO-DB-SELECT-1 */
        public void M_1040_GERA_EVENTO_DB_SELECT_1()
        {
            /*" -1662- EXEC SQL SELECT OCORHIST INTO :V0PDTV-OCORHIST FROM SEGUROS.V0PRODUTORVF WHERE CODPDT = :V0PLCO-CODPDT END-EXEC. */

            var m_1040_GERA_EVENTO_DB_SELECT_1_Query1 = new M_1040_GERA_EVENTO_DB_SELECT_1_Query1()
            {
                V0PLCO_CODPDT = V0PLCO_CODPDT.ToString(),
            };

            var executed_1 = M_1040_GERA_EVENTO_DB_SELECT_1_Query1.Execute(m_1040_GERA_EVENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PDTV_OCORHIST, V0PDTV_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-SELECT-5 */
        public void M_1035_QUITA_PARCELA_DB_SELECT_5()
        {
            /*" -1551- EXEC SQL SELECT VLCUSTCDG, VLCUSTAUXF, IMPSEGCDC, IMPSEGAUXF INTO :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I, :V0COBP-IMPSEGCDG, :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO AND DTTERVIG >= :V0PARC-DTVENCTO END-EXEC. */

            var m_1035_QUITA_PARCELA_DB_SELECT_5_Query1 = new M_1035_QUITA_PARCELA_DB_SELECT_5_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = M_1035_QUITA_PARCELA_DB_SELECT_5_Query1.Execute(m_1035_QUITA_PARCELA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
            }


        }

        [StopWatch]
        /*" M-1040-LOOP */
        private void M_1040_LOOP(bool isPerform = false)
        {
            /*" -1671- ADD 1 TO V0PDTV-OCORHIST. */
            V0PDTV_OCORHIST.Value = V0PDTV_OCORHIST + 1;

            /*" -1673- MOVE 'UPDATE V0PRODUTORVF' TO COMANDO. */
            _.Move("UPDATE V0PRODUTORVF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1677- PERFORM M_1040_LOOP_DB_UPDATE_1 */

            M_1040_LOOP_DB_UPDATE_1();

            /*" -1680- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1682- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1683- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1687- MOVE 'INSERT V0EVENTOSVF' TO COMANDO. */
            _.Move("INSERT V0EVENTOSVF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1703- PERFORM M_1040_LOOP_DB_INSERT_1 */

            M_1040_LOOP_DB_INSERT_1();

            /*" -1706- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1707- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1708- GO TO 1040-LOOP */
                    new Task(() => M_1040_LOOP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1709- ELSE */
                }
                else
                {


                    /*" -1711- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1712- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -1714- PERFORM 1041-FETCH THRU 1041-FIM. */

            M_1041_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1041_FIM*/


        }

        [StopWatch]
        /*" M-1040-LOOP-DB-UPDATE-1 */
        public void M_1040_LOOP_DB_UPDATE_1()
        {
            /*" -1677- EXEC SQL UPDATE SEGUROS.V0PRODUTORVF SET OCORHIST = :V0PDTV-OCORHIST WHERE CODPDT = :V0PLCO-CODPDT END-EXEC. */

            var m_1040_LOOP_DB_UPDATE_1_Update1 = new M_1040_LOOP_DB_UPDATE_1_Update1()
            {
                V0PDTV_OCORHIST = V0PDTV_OCORHIST.ToString(),
                V0PLCO_CODPDT = V0PLCO_CODPDT.ToString(),
            };

            M_1040_LOOP_DB_UPDATE_1_Update1.Execute(m_1040_LOOP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1040-LOOP-DB-INSERT-1 */
        public void M_1040_LOOP_DB_INSERT_1()
        {
            /*" -1703- EXEC SQL INSERT INTO SEGUROS.V0EVENTOSVF VALUES (:V0PLCO-CODPDT, :V0PDTV-OCORHIST, 0, :V0HCTA-NRCERTIF, :V0PARC-NRPARCEL, 8, 202, :V0SIST-DTMOVABE, :V0HCOB-DTVENCTO, '0' , :V0CMPT-VLPRMDIF, 0, 'VF0813B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_1040_LOOP_DB_INSERT_1_Insert1 = new M_1040_LOOP_DB_INSERT_1_Insert1()
            {
                V0PLCO_CODPDT = V0PLCO_CODPDT.ToString(),
                V0PDTV_OCORHIST = V0PDTV_OCORHIST.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0CMPT_VLPRMDIF = V0CMPT_VLPRMDIF.ToString(),
            };

            M_1040_LOOP_DB_INSERT_1_Insert1.Execute(m_1040_LOOP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-SELECT-6 */
        public void M_1035_QUITA_PARCELA_DB_SELECT_6()
        {
            /*" -1568- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_1035_QUITA_PARCELA_DB_SELECT_6_Query1 = new M_1035_QUITA_PARCELA_DB_SELECT_6_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = M_1035_QUITA_PARCELA_DB_SELECT_6_Query1.Execute(m_1035_QUITA_PARCELA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1040_FIM*/

        [StopWatch]
        /*" M-1035-QUITA-PARCELA-DB-SELECT-7 */
        public void M_1035_QUITA_PARCELA_DB_SELECT_7()
        {
            /*" -1588- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_1035_QUITA_PARCELA_DB_SELECT_7_Query1 = new M_1035_QUITA_PARCELA_DB_SELECT_7_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = M_1035_QUITA_PARCELA_DB_SELECT_7_Query1.Execute(m_1035_QUITA_PARCELA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }

        [StopWatch]
        /*" M-1041-FETCH */
        private void M_1041_FETCH(bool isPerform = false)
        {
            /*" -1725- MOVE '1041-FETCH' TO PARAGRAFO. */
            _.Move("1041-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1727- MOVE 'FETCH CLPCOM' TO COMANDO. */
            _.Move("FETCH CLPCOM", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1730- PERFORM M_1041_FETCH_DB_FETCH_1 */

            M_1041_FETCH_DB_FETCH_1();

            /*" -1733- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1733- MOVE 1 TO WS-EOP. */
                _.Move(1, WORK_AREA.WS_EOP);
            }


        }

        [StopWatch]
        /*" M-1041-FETCH-DB-FETCH-1 */
        public void M_1041_FETCH_DB_FETCH_1()
        {
            /*" -1730- EXEC SQL FETCH CPLCOM INTO :V0PLCO-CODPDT END-EXEC. */

            if (CPLCOM.Fetch())
            {
                _.Move(CPLCOM.V0PLCO_CODPDT, V0PLCO_CODPDT);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1041_FIM*/

        [StopWatch]
        /*" M-1050-GERA-DIFERENCA */
        private void M_1050_GERA_DIFERENCA(bool isPerform = false)
        {
            /*" -1744- MOVE '1050-GERA-DIFERENCA' TO PARAGRAFO. */
            _.Move("1050-GERA-DIFERENCA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1746- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1761- PERFORM M_1050_GERA_DIFERENCA_DB_INSERT_1 */

            M_1050_GERA_DIFERENCA_DB_INSERT_1();

            /*" -1764- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1766- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1768- MOVE 'UPDATE V0DIFPARCELVA' TO COMANDO. */
            _.Move("UPDATE V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1775- PERFORM M_1050_GERA_DIFERENCA_DB_UPDATE_1 */

            M_1050_GERA_DIFERENCA_DB_UPDATE_1();

            /*" -1778- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1778- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1050-GERA-DIFERENCA-DB-INSERT-1 */
        public void M_1050_GERA_DIFERENCA_DB_INSERT_1()
        {
            /*" -1761- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HCTA-NRCERTIF, 9999, :V0HCOB-NRPARCEL, 601, :V0PARC-DTVENCTO, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-PRMVG, :V0PARC-PRMAP, 0, ' ' ) END-EXEC. */

            var m_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1 = new M_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
            };

            M_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1.Execute(m_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1050-GERA-DIFERENCA-DB-UPDATE-1 */
        public void M_1050_GERA_DIFERENCA_DB_UPDATE_1()
        {
            /*" -1775- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = ' ' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCELDIF = :V0CMPT-NRPARCEL AND CODOPER = :V0CMPT-CODOPER END-EXEC. */

            var m_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1 = new M_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0CMPT_NRPARCEL = V0CMPT_NRPARCEL.ToString(),
                V0CMPT_CODOPER = V0CMPT_CODOPER.ToString(),
            };

            M_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1.Execute(m_1050_GERA_DIFERENCA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1050_FIM*/

        [StopWatch]
        /*" M-1099-INCLUI-CDG */
        private void M_1099_INCLUI_CDG(bool isPerform = false)
        {
            /*" -1790- MOVE '1099-INCLUI-CDG' TO PARAGRAFO. */
            _.Move("1099-INCLUI-CDG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1791- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -1792- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1793- ADD V0OPCP-PERIPGTO TO MES-SQL. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

            /*" -1794- IF MES-SQL > 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -1795- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -1796- ADD 1 TO ANO-SQL. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -1798- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RCDG_DTREFER);

            /*" -1800- MOVE 'INSERT V0CDGCOBER  ' TO COMANDO. */
            _.Move("INSERT V0CDGCOBER  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1812- PERFORM M_1099_INCLUI_CDG_DB_INSERT_1 */

            M_1099_INCLUI_CDG_DB_INSERT_1();

            /*" -1815- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1817- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1819- MOVE V0COBP-VLCUSTCDG TO V0CDGC-VLCUSTCDG. */
            _.Move(V0COBP_VLCUSTCDG, V0CDGC_VLCUSTCDG);

            /*" -1819- PERFORM 1100-REPASSA-CDG THRU 1100-FIM. */

            M_1100_REPASSA_CDG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


        }

        [StopWatch]
        /*" M-1099-INCLUI-CDG-DB-INSERT-1 */
        public void M_1099_INCLUI_CDG_DB_INSERT_1()
        {
            /*" -1812- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, '9999-12-31' , :V0COBP-IMPSEGCDG, :V0COBP-VLCUSTCDG, :V0HCTA-NRCERTIF, 0, '0' , 'VF0813B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_1099_INCLUI_CDG_DB_INSERT_1_Insert1 = new M_1099_INCLUI_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0COBP_IMPSEGCDG = V0COBP_IMPSEGCDG.ToString(),
                V0COBP_VLCUSTCDG = V0COBP_VLCUSTCDG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            M_1099_INCLUI_CDG_DB_INSERT_1_Insert1.Execute(m_1099_INCLUI_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1099_FIM*/

        [StopWatch]
        /*" M-1100-REPASSA-CDG */
        private void M_1100_REPASSA_CDG(bool isPerform = false)
        {
            /*" -1831- MOVE '1100-REPASSA-CDG' TO PARAGRAFO. */
            _.Move("1100-REPASSA-CDG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1832- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -1833- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1834- ADD V0OPCP-PERIPGTO TO MES-SQL. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

            /*" -1835- IF MES-SQL > 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -1836- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -1837- ADD 1 TO ANO-SQL. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -1839- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RCDG_DTREFER);

            /*" -1841- MOVE 'SELECT V0REPASSECDG' TO COMANDO. */
            _.Move("SELECT V0REPASSECDG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1847- PERFORM M_1100_REPASSA_CDG_DB_SELECT_1 */

            M_1100_REPASSA_CDG_DB_SELECT_1();

            /*" -1850- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1852- GO TO 1100-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/ //GOTO
                return;
            }


            /*" -1854- MOVE 'INSERT V0REPASSECDG' TO COMANDO. */
            _.Move("INSERT V0REPASSECDG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1864- PERFORM M_1100_REPASSA_CDG_DB_INSERT_1 */

            M_1100_REPASSA_CDG_DB_INSERT_1();

            /*" -1867- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1867- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1100-REPASSA-CDG-DB-SELECT-1 */
        public void M_1100_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -1847- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER END-EXEC. */

            var m_1100_REPASSA_CDG_DB_SELECT_1_Query1 = new M_1100_REPASSA_CDG_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = M_1100_REPASSA_CDG_DB_SELECT_1_Query1.Execute(m_1100_REPASSA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-1100-REPASSA-CDG-DB-INSERT-1 */
        public void M_1100_REPASSA_CDG_DB_INSERT_1()
        {
            /*" -1864- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0HCTA-NRCERTIF, :V0PARC-NRPARCEL, '0' , :V0SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var m_1100_REPASSA_CDG_DB_INSERT_1_Insert1 = new M_1100_REPASSA_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            M_1100_REPASSA_CDG_DB_INSERT_1_Insert1.Execute(m_1100_REPASSA_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1199-INCLUI-SAF */
        private void M_1199_INCLUI_SAF(bool isPerform = false)
        {
            /*" -1879- MOVE '1199-INCLUI-SAF' TO PARAGRAFO. */
            _.Move("1199-INCLUI-SAF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1880- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -1881- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1882- ADD V0OPCP-PERIPGTO TO MES-SQL. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

            /*" -1883- IF MES-SQL > 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -1884- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -1885- ADD 1 TO ANO-SQL. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -1887- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RSAF_DTREFER);

            /*" -1889- MOVE 'INSERT V0SAFCOBER' TO COMANDO. */
            _.Move("INSERT V0SAFCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1901- PERFORM M_1199_INCLUI_SAF_DB_INSERT_1 */

            M_1199_INCLUI_SAF_DB_INSERT_1();

            /*" -1904- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1906- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1908- MOVE V0COBP-VLCUSTAUXF TO V0SAFC-VLCUSTSAF. */
            _.Move(V0COBP_VLCUSTAUXF, V0SAFC_VLCUSTSAF);

            /*" -1910- MOVE 'SELECT V0HISTREPSAF - 102' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF - 102", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1917- PERFORM M_1199_INCLUI_SAF_DB_SELECT_1 */

            M_1199_INCLUI_SAF_DB_SELECT_1();

            /*" -1920- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1922- GO TO 1199-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1199_FIM*/ //GOTO
                return;
            }


            /*" -1924- MOVE 'INSERT V0HISTREPSAF - 102' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF - 102", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1940- PERFORM M_1199_INCLUI_SAF_DB_INSERT_2 */

            M_1199_INCLUI_SAF_DB_INSERT_2();

            /*" -1943- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1945- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1945- PERFORM 1200-REPASSA-SAF THRU 1200-FIM. */

            M_1200_REPASSA_SAF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


        }

        [StopWatch]
        /*" M-1199-INCLUI-SAF-DB-INSERT-1 */
        public void M_1199_INCLUI_SAF_DB_INSERT_1()
        {
            /*" -1901- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, '9999-12-31' , :V0COBP-IMPSEGAUXF, :V0COBP-VLCUSTAUXF, :V0HCTA-NRCERTIF, 0, '0' , 'VF0813B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_1199_INCLUI_SAF_DB_INSERT_1_Insert1 = new M_1199_INCLUI_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0COBP_IMPSEGAUXF = V0COBP_IMPSEGAUXF.ToString(),
                V0COBP_VLCUSTAUXF = V0COBP_VLCUSTAUXF.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            M_1199_INCLUI_SAF_DB_INSERT_1_Insert1.Execute(m_1199_INCLUI_SAF_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1199-INCLUI-SAF-DB-SELECT-1 */
        public void M_1199_INCLUI_SAF_DB_SELECT_1()
        {
            /*" -1917- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 102 END-EXEC. */

            var m_1199_INCLUI_SAF_DB_SELECT_1_Query1 = new M_1199_INCLUI_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = M_1199_INCLUI_SAF_DB_SELECT_1_Query1.Execute(m_1199_INCLUI_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1199_FIM*/

        [StopWatch]
        /*" M-1199-INCLUI-SAF-DB-INSERT-2 */
        public void M_1199_INCLUI_SAF_DB_INSERT_2()
        {
            /*" -1940- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCTA-NRCERTIF, :V0PARC-NRPARCEL, 0, :V0SAFC-VLCUSTSAF, 102, '0' , '0' , 0, 0, 'VF0813B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var m_1199_INCLUI_SAF_DB_INSERT_2_Insert1 = new M_1199_INCLUI_SAF_DB_INSERT_2_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            M_1199_INCLUI_SAF_DB_INSERT_2_Insert1.Execute(m_1199_INCLUI_SAF_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-1200-REPASSA-SAF */
        private void M_1200_REPASSA_SAF(bool isPerform = false)
        {
            /*" -1957- MOVE '1200-REPASSA-SAF' TO PARAGRAFO. */
            _.Move("1200-REPASSA-SAF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1958- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -1959- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1960- ADD V0OPCP-PERIPGTO TO MES-SQL. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

            /*" -1961- IF MES-SQL > 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -1962- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -1963- ADD 1 TO ANO-SQL. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -1965- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RSAF_DTREFER);

            /*" -1967- MOVE 'SELECT V0HISTREPSAF' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1974- PERFORM M_1200_REPASSA_SAF_DB_SELECT_1 */

            M_1200_REPASSA_SAF_DB_SELECT_1();

            /*" -1977- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1979- GO TO 1200-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/ //GOTO
                return;
            }


            /*" -1981- MOVE 'INSERT V0HISTREPSAF' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1997- PERFORM M_1200_REPASSA_SAF_DB_INSERT_1 */

            M_1200_REPASSA_SAF_DB_INSERT_1();

            /*" -2000- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2000- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1200-REPASSA-SAF-DB-SELECT-1 */
        public void M_1200_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -1974- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 1100 END-EXEC. */

            var m_1200_REPASSA_SAF_DB_SELECT_1_Query1 = new M_1200_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = M_1200_REPASSA_SAF_DB_SELECT_1_Query1.Execute(m_1200_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-1200-REPASSA-SAF-DB-INSERT-1 */
        public void M_1200_REPASSA_SAF_DB_INSERT_1()
        {
            /*" -1997- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCTA-NRCERTIF, :V0PARC-NRPARCEL, 0, :V0SAFC-VLCUSTSAF, 1100, '0' , '0' , 0, 0, 'VF0813B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var m_1200_REPASSA_SAF_DB_INSERT_1_Insert1 = new M_1200_REPASSA_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            M_1200_REPASSA_SAF_DB_INSERT_1_Insert1.Execute(m_1200_REPASSA_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/

        [StopWatch]
        /*" M-1037-REJEITA-PARCELA */
        private void M_1037_REJEITA_PARCELA(bool isPerform = false)
        {
            /*" -2009- IF V0HCTA-CODRET NOT EQUAL 01 AND 99 */

            if (!V0HCTA_CODRET.In("01", "99"))
            {

                /*" -2010- IF V0OPCP-OPCAOPAG NOT EQUAL '3' */

                if (V0OPCP_OPCAOPAG != "3")
                {

                    /*" -2012- PERFORM 1038-MUDA-OPCAOPAG THRU 1038-FIM. */

                    M_1038_MUDA_OPCAOPAG(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1038_FIM*/

                }

            }


            /*" -2013- MOVE '1037-REJEITA-PARCELA' TO PARAGRAFO. */
            _.Move("1037-REJEITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2015- MOVE 'UPDATE V0FITASASSE' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2023- PERFORM M_1037_REJEITA_PARCELA_DB_UPDATE_1 */

            M_1037_REJEITA_PARCELA_DB_UPDATE_1();

            /*" -2026- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2028- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2030- MOVE 'UPDATE V0HISTCONTAVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2039- PERFORM M_1037_REJEITA_PARCELA_DB_UPDATE_2 */

            M_1037_REJEITA_PARCELA_DB_UPDATE_2();

            /*" -2042- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2044- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2046- MOVE 'UPDATE V0HISTCOBVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2054- PERFORM M_1037_REJEITA_PARCELA_DB_UPDATE_3 */

            M_1037_REJEITA_PARCELA_DB_UPDATE_3();

            /*" -2057- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2063- DISPLAY 'VF0813B - PROBLEMAS NO UPDATE V0HISTCOBVA DD ' V0HCTA-NRCERTIF ' ' V0HCOB-NRPARCEL ' ' V0HCOB-NRTIT ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VF0813B - PROBLEMAS NO UPDATE V0HISTCOBVA DD {V0HCTA_NRCERTIF} {V0HCOB_NRPARCEL} {V0HCOB_NRTIT} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -2065- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2071- ADD V0HCOB-VLPRMTOT TO WS-ACG-TOTDBNEFET. */
            WORK_AREA.WS_ACG_TOTDBNEFET.Value = WORK_AREA.WS_ACG_TOTDBNEFET + V0HCOB_VLPRMTOT;

            /*" -2072- MOVE RF-IDENTIF-CLI TO VGFOLLOW-NUM-CERTIFICADO. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO);

            /*" -2073- MOVE RF-IDENTIF-NSAS TO VGFOLLOW-NUM-NOSSA-FITA. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSAS, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA);

            /*" -2075- MOVE RF-NSL TO VGFOLLOW-NUM-LANCAMENTO. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO);

            /*" -2075- PERFORM R8800-00-UPDATE-FOLLOWUP. */

            R8800_00_UPDATE_FOLLOWUP_SECTION();

        }

        [StopWatch]
        /*" M-1037-REJEITA-PARCELA-DB-UPDATE-1 */
        public void M_1037_REJEITA_PARCELA_DB_UPDATE_1()
        {
            /*" -2023- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET TOT_DEB_NAO_EFET = TOT_DEB_NAO_EFET + :V0HCOB-VLPRMTOT, QTDE_LANC_DEB_RET = QTDE_LANC_DEB_RET + 1 WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS END-EXEC. */

            var m_1037_REJEITA_PARCELA_DB_UPDATE_1_Update1 = new M_1037_REJEITA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
            };

            M_1037_REJEITA_PARCELA_DB_UPDATE_1_Update1.Execute(m_1037_REJEITA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1037_FIM*/

        [StopWatch]
        /*" M-1037-REJEITA-PARCELA-DB-UPDATE-2 */
        public void M_1037_REJEITA_PARCELA_DB_UPDATE_2()
        {
            /*" -2039- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET NSAC = :V0FTCF-NSAC, SITUACAO = ' ' , CODRET = :V0HCTA-CODRET, TIMESTAMP = CURRENT TIMESTAMP WHERE CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL END-EXEC. */

            var m_1037_REJEITA_PARCELA_DB_UPDATE_2_Update1 = new M_1037_REJEITA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HCTA_CODRET = V0HCTA_CODRET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            M_1037_REJEITA_PARCELA_DB_UPDATE_2_Update1.Execute(m_1037_REJEITA_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-1038-MUDA-OPCAOPAG */
        private void M_1038_MUDA_OPCAOPAG(bool isPerform = false)
        {
            /*" -2085- MOVE '1038-MUDA-OPCAOPAG' TO PARAGRAFO. */
            _.Move("1038-MUDA-OPCAOPAG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2087- MOVE 'UPDATE V0OPCAOPAGVA' TO COMANDO. */
            _.Move("UPDATE V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2094- PERFORM M_1038_MUDA_OPCAOPAG_DB_UPDATE_1 */

            M_1038_MUDA_OPCAOPAG_DB_UPDATE_1();

            /*" -2097- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2099- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2101- MOVE 'INSERT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("INSERT V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2127- PERFORM M_1038_MUDA_OPCAOPAG_DB_INSERT_1 */

            M_1038_MUDA_OPCAOPAG_DB_INSERT_1();

            /*" -2130- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2130- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1038-MUDA-OPCAOPAG-DB-UPDATE-1 */
        public void M_1038_MUDA_OPCAOPAG_DB_UPDATE_1()
        {
            /*" -2094- EXEC SQL UPDATE SEGUROS.V0OPCAOPAGVA SET DTTERVIG = :V0HCOB-DTALTOPC, TIMESTAMP = CURRENT TIMESTAMP, CODUSU = 'VF0813B' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1 = new M_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1()
            {
                V0HCOB_DTALTOPC = V0HCOB_DTALTOPC.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            M_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1.Execute(m_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1038-MUDA-OPCAOPAG-DB-INSERT-1 */
        public void M_1038_MUDA_OPCAOPAG_DB_INSERT_1()
        {
            /*" -2127- EXEC SQL INSERT INTO SEGUROS.V0OPCAOPAGVA (NRCERTIF, DTINIVIG, DTTERVIG, OPCAOPAG, PERIPGTO, DIA_DEBITO, CODUSU, TIMESTAMP, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB) VALUES (:V0HCTA-NRCERTIF, :V0HCOB-DTVENCTO, '9999-12-31' , '3' , :V0OPCP-PERIPGTO, :V0OPCP-DIADEB, 'VF0813B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

            var m_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 = new M_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                V0OPCP_DIADEB = V0OPCP_DIADEB.ToString(),
            };

            M_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1.Execute(m_1038_MUDA_OPCAOPAG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1037-REJEITA-PARCELA-DB-UPDATE-3 */
        public void M_1037_REJEITA_PARCELA_DB_UPDATE_3()
        {
            /*" -2054- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = ' ' , VLPRMTOT = :V0HCOB-VLPRMTOT, OPCAOPAG = :V0OPCP-OPCAOPAG WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var m_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1 = new M_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1()
            {
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            M_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1.Execute(m_1037_REJEITA_PARCELA_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1038_FIM*/

        [StopWatch]
        /*" M-1101-ACHA-PARCELA */
        private void M_1101_ACHA_PARCELA(bool isPerform = false)
        {
            /*" -2140- MOVE '1101-ACHA-PARCELA' TO PARAGRAFO. */
            _.Move("1101-ACHA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2148- PERFORM M_1101_ACHA_PARCELA_DB_DECLARE_1 */

            M_1101_ACHA_PARCELA_DB_DECLARE_1();

            /*" -2151- MOVE 'OPEN CPARC1' TO COMANDO. */
            _.Move("OPEN CPARC1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2151- PERFORM M_1101_ACHA_PARCELA_DB_OPEN_1 */

            M_1101_ACHA_PARCELA_DB_OPEN_1();

            /*" -2156- MOVE 0 TO WS-EOP2 V0PARC-VLPRMTOT. */
            _.Move(0, WORK_AREA.WS_EOP2, V0PARC_VLPRMTOT);

            /*" -2160- PERFORM 1120-FETCH THRU 1120-FIM UNTIL WS-EOP2 EQUAL 1 OR V0PARC-VLPRMTOT EQUAL V0CMPT-VLPRMDIF. */

            while (!(WORK_AREA.WS_EOP2 == 1 || V0PARC_VLPRMTOT == V0CMPT_VLPRMDIF))
            {

                M_1120_FETCH(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/

            }

            /*" -2161- IF WS-EOP2 EQUAL 1 */

            if (WORK_AREA.WS_EOP2 == 1)
            {

                /*" -2162- MOVE 0 TO WS-ACHOU */
                _.Move(0, WORK_AREA.WS_ACHOU);

                /*" -2163- ELSE */
            }
            else
            {


                /*" -2165- MOVE 1 TO WS-ACHOU. */
                _.Move(1, WORK_AREA.WS_ACHOU);
            }


            /*" -2166- MOVE '1101-ACHA-PARCELA' TO PARAGRAFO. */
            _.Move("1101-ACHA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2167- MOVE 'CLOSE CPARC1' TO COMANDO. */
            _.Move("CLOSE CPARC1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2167- PERFORM M_1101_ACHA_PARCELA_DB_CLOSE_1 */

            M_1101_ACHA_PARCELA_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-1101-ACHA-PARCELA-DB-OPEN-1 */
        public void M_1101_ACHA_PARCELA_DB_OPEN_1()
        {
            /*" -2151- EXEC SQL OPEN CPARC1 END-EXEC. */

            CPARC1.Open();

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -2249- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA IN ( 00, 10, 11 ) ORDER BY CODPRODU END-EXEC. */
            V0PRODUTO = new VF0813B_V0PRODUTO(false);
            string GetQuery_V0PRODUTO()
            {
                var query = @$"SELECT CODPRODU 
							FROM SEGUROS.V0PRODUTO 
							WHERE COD_EMPRESA IN ( 00
							, 10
							, 11 ) 
							ORDER BY CODPRODU";

                return query;
            }
            V0PRODUTO.GetQueryEvent += GetQuery_V0PRODUTO;

        }

        [StopWatch]
        /*" M-1101-ACHA-PARCELA-DB-CLOSE-1 */
        public void M_1101_ACHA_PARCELA_DB_CLOSE_1()
        {
            /*" -2167- EXEC SQL CLOSE CPARC1 END-EXEC. */

            CPARC1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1101_FIM*/

        [StopWatch]
        /*" M-1120-FETCH */
        private void M_1120_FETCH(bool isPerform = false)
        {
            /*" -2174- MOVE '1120-FETCH' TO PARAGRAFO. */
            _.Move("1120-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2176- MOVE 'FETCH CPARC1' TO COMANDO. */
            _.Move("FETCH CPARC1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2180- PERFORM M_1120_FETCH_DB_FETCH_1 */

            M_1120_FETCH_DB_FETCH_1();

            /*" -2183- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2183- MOVE 1 TO WS-EOP2. */
                _.Move(1, WORK_AREA.WS_EOP2);
            }


        }

        [StopWatch]
        /*" M-1120-FETCH-DB-FETCH-1 */
        public void M_1120_FETCH_DB_FETCH_1()
        {
            /*" -2180- EXEC SQL FETCH CPARC1 INTO :V0PARC-NRPARCEL, :V0PARC-VLPRMTOT END-EXEC. */

            if (CPARC1.Fetch())
            {
                _.Move(CPARC1.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(CPARC1.V0PARC_VLPRMTOT, V0PARC_VLPRMTOT);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/

        [StopWatch]
        /*" R0050-00-INICIO */
        private void R0050_00_INICIO(bool isPerform = false)
        {
            /*" -2201- MOVE 'R0050-INICIO            ' TO PARAGRAFO. */
            _.Move("R0050-INICIO            ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2202- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -2205- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -2209- PERFORM R0220-00-MOVE-DADOS THRU R0220-99-SAIDA. */

            R0220_00_MOVE_DADOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/


            /*" -2210- MOVE 1 TO LD-PRODUTO */
            _.Move(1, WORK_AREA.LD_PRODUTO);

            /*" -2211- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WORK_AREA.WFIM_PRODUTO);

            /*" -2214- PERFORM R0200-00-DECLARE-V0PRODUTO THRU R0200-99-SAIDA. */

            R0200_00_DECLARE_V0PRODUTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/


            /*" -2219- PERFORM R0210-00-FETCH-V0PRODUTO THRU R0210-99-SAIDA UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WORK_AREA.WFIM_PRODUTO.IsEmpty()))
            {

                R0210_00_FETCH_V0PRODUTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

            }

            /*" -2223- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -2228- PERFORM R0220-00-MOVE-DADOS THRU R0220-99-SAIDA UNTIL WS-SUBS GREATER 2000. */

            while (!(WORK_AREA.WS_SUBS > 2000))
            {

                R0220_00_MOVE_DADOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

            }

            /*" -2228- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO */
        private void R0200_00_DECLARE_V0PRODUTO(bool isPerform = false)
        {
            /*" -2241- MOVE 'R0200-DECLARE-V0PRODUTO ' TO PARAGRAFO. */
            _.Move("R0200-DECLARE-V0PRODUTO ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2249- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -2251- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -2255- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2256- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ");

                /*" -2256- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -2251- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO */
        private void R0210_00_FETCH_V0PRODUTO(bool isPerform = false)
        {
            /*" -2269- MOVE 'R0210-FETCH-V0PRODUTO   ' TO PARAGRAFO. */
            _.Move("R0210-FETCH-V0PRODUTO   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2271- PERFORM R0210_00_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_00_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -2275- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2275- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -2277- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WORK_AREA.WFIM_PRODUTO);

                /*" -2279- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2280- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2281- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -2284- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2286- ADD 1 TO LD-PRODUTO. */
            WORK_AREA.LD_PRODUTO.Value = WORK_AREA.LD_PRODUTO + 1;

            /*" -2287- IF LD-PRODUTO GREATER 2000 */

            if (WORK_AREA.LD_PRODUTO > 2000)
            {

                /*" -2287- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -2289- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -2292- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2293- PERFORM R0220-00-MOVE-DADOS THRU R0220-99-SAIDA. */

            R0220_00_MOVE_DADOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/


        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -2271- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -2275- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -2287- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0220-00-MOVE-DADOS */
        private void R0220_00_MOVE_DADOS(bool isPerform = false)
        {
            /*" -2306- MOVE 'R0220-MOVE-DADOS        ' TO PARAGRAFO. */
            _.Move("R0220-MOVE-DADOS        ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2310- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-PRD). */
            _.Move(V0PROD_CODPRODU, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU);

            /*" -2311- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -2315- PERFORM R0250-00-MOVE-TIPO THRU R0250-99-SAIDA 03 TIMES. */

            R0250_00_MOVE_TIPO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/


            /*" -2316- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -2316- SET WS-SUBS TO WS-PRD. */
            WORK_AREA.WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-MOVE-TIPO */
        private void R0250_00_MOVE_TIPO(bool isPerform = false)
        {
            /*" -2329- MOVE 'R0250-MOVE-TIPO         ' TO PARAGRAFO. */
            _.Move("R0250-MOVE-TIPO         ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2334- SET WS-SUBS1 TO WS-TIP. */
            WORK_AREA.WS_SUBS1.Value = WS_TIP;

            /*" -2335- IF WS-SUBS1 EQUAL 1 */

            if (WORK_AREA.WS_SUBS1 == 1)
            {

                /*" -2337- MOVE 'A' TO WTABG-TIPO(WS-PRD WS-TIP) */
                _.Move("A", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                /*" -2341- ELSE */
            }
            else
            {


                /*" -2342- IF WS-SUBS1 EQUAL 2 */

                if (WORK_AREA.WS_SUBS1 == 2)
                {

                    /*" -2344- MOVE 'M' TO WTABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("M", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -2348- ELSE */
                }
                else
                {


                    /*" -2352- MOVE 'D' TO WTABG-TIPO(WS-PRD WS-TIP). */
                    _.Move("D", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);
                }

            }


            /*" -2353- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -2357- PERFORM R0260-00-MOVE-SITUACAO THRU R0260-99-SAIDA 02 TIMES. */

            R0260_00_MOVE_SITUACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/


            /*" -2357- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-SITUACAO */
        private void R0260_00_MOVE_SITUACAO(bool isPerform = false)
        {
            /*" -2370- MOVE 'R0260-MOVE-SITUACAO     ' TO PARAGRAFO. */
            _.Move("R0260-MOVE-SITUACAO     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2379- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -2384- SET WS-SUBS2 TO WS-SIT. */
            WORK_AREA.WS_SUBS2.Value = WS_SIT;

            /*" -2385- IF WS-SUBS2 EQUAL 1 */

            if (WORK_AREA.WS_SUBS2 == 1)
            {

                /*" -2387- MOVE '0' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                _.Move("0", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -2391- ELSE */
            }
            else
            {


                /*" -2395- MOVE '2' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT). */
                _.Move("2", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);
            }


            /*" -2395- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-TRATA-DESPESAS */
        private void R8000_00_TRATA_DESPESAS(bool isPerform = false)
        {
            /*" -2408- MOVE 'R8000-TRATA-DESPESAS    ' TO PARAGRAFO. */
            _.Move("R8000-TRATA-DESPESAS    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2412- PERFORM R8010-00-VER-PRODUTO THRU R8010-99-SAIDA. */

            R8010_00_VER_PRODUTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_99_SAIDA*/


            /*" -2413- MOVE RF-VLPRMTOT TO WSHOST-VLPRMTOT */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, WSHOST_VLPRMTOT);

            /*" -2414- MOVE V0PROP-CODPRODU TO WSHOST-CODPRODU */
            _.Move(V0PROP_CODPRODU, WSHOST_CODPRODU);

            /*" -2418- MOVE ZEROS TO WSHOST-VLTARIFA WSHOST-VLBALCAO WSHOST-VLIOCC WSHOST-VLDESCON */
            _.Move(0, WSHOST_VLTARIFA, WSHOST_VLBALCAO, WSHOST_VLIOCC, WSHOST_VLDESCON);

            /*" -2420- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -2423- MOVE 0,56 TO WSHOST-VLTARIFA. */
            _.Move(0.56, WSHOST_VLTARIFA);

            /*" -2424- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -2425- SEARCH WTABG-OCORREPRD */
            for (; WS_PRD < AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -2427- WHEN WSHOST-CODPRODU EQUAL WTABG-CODPRODU(WS-PRD) */

                if (WSHOST_CODPRODU == AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU)
                {


                    /*" -2428- PERFORM R8050-00-VERIFICA-TIPO THRU R8050-99-SAIDA  END-SEARCH. */

                    R8050_00_VERIFICA_TIPO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8050_99_SAIDA*/

                    break;
                }
            }


            /*" -2434- ADD WSHOST-VLPRMTOT TO AUX-VLPRMTOT. */
            WORK_AREA.AUX_VLPRMTOT.Value = WORK_AREA.AUX_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -2435- ADD WSHOST-VLTARIFA TO AUX-VLDESPES. */
            WORK_AREA.AUX_VLDESPES.Value = WORK_AREA.AUX_VLDESPES + WSHOST_VLTARIFA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8010-00-VER-PRODUTO */
        private void R8010_00_VER_PRODUTO(bool isPerform = false)
        {
            /*" -2447- MOVE 'R8010-VER-PRODUTO       ' TO PARAGRAFO. */
            _.Move("R8010-VER-PRODUTO       ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2449- MOVE RF-IDENTIF-CLI TO V0HCTA-NRCERTIF. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, V0HCTA_NRCERTIF);

            /*" -2457- PERFORM R8010_00_VER_PRODUTO_DB_SELECT_1 */

            R8010_00_VER_PRODUTO_DB_SELECT_1();

            /*" -2461- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2461- MOVE ZEROS TO V0PROP-CODPRODU. */
                _.Move(0, V0PROP_CODPRODU);
            }


        }

        [StopWatch]
        /*" R8010-00-VER-PRODUTO-DB-SELECT-1 */
        public void R8010_00_VER_PRODUTO_DB_SELECT_1()
        {
            /*" -2457- EXEC SQL SELECT A.CODPRODU INTO :V0PROP-CODPRODU FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCTA-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES END-EXEC. */

            var r8010_00_VER_PRODUTO_DB_SELECT_1_Query1 = new R8010_00_VER_PRODUTO_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R8010_00_VER_PRODUTO_DB_SELECT_1_Query1.Execute(r8010_00_VER_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_99_SAIDA*/

        [StopWatch]
        /*" R8050-00-VERIFICA-TIPO */
        private void R8050_00_VERIFICA_TIPO(bool isPerform = false)
        {
            /*" -2474- MOVE 'R8050-VERIFICA-TIPO     ' TO PARAGRAFO. */
            _.Move("R8050-VERIFICA-TIPO     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2479- SET WS-TIP TO 3. */
            WS_TIP.Value = 3;

            /*" -2480- IF WSHOST-SITUACAO EQUAL '0' */

            if (WSHOST_SITUACAO == "0")
            {

                /*" -2481- SET WS-SIT TO 1 */
                WS_SIT.Value = 1;

                /*" -2485- ELSE */
            }
            else
            {


                /*" -2488- SET WS-SIT TO 2. */
                WS_SIT.Value = 2;
            }


            /*" -2491- ADD 1 TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE + 1;

            /*" -2494- ADD WSHOST-VLPRMTOT TO WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -2497- ADD WSHOST-VLTARIFA TO WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA + WSHOST_VLTARIFA;

            /*" -2500- ADD WSHOST-VLBALCAO TO WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO + WSHOST_VLBALCAO;

            /*" -2503- ADD WSHOST-VLIOCC TO WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC + WSHOST_VLIOCC;

            /*" -2504- ADD WSHOST-VLDESCON TO WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON + WSHOST_VLDESCON;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8050_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-GRAVA-DESPESAS */
        private void R8500_00_GRAVA_DESPESAS(bool isPerform = false)
        {
            /*" -2517- MOVE 'R8500-GRAVA-DESPESAS    ' TO PARAGRAFO. */
            _.Move("R8500-GRAVA-DESPESAS    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2518- IF WTABG-CODPRODU(WS-PRD) EQUAL 9999 */

            if (AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU == 9999)
            {

                /*" -2519- SET WS-PRD UP BY 1 */
                WS_PRD.Value += 1;

                /*" -2522- GO TO R8500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2525- MOVE WTABG-CODPRODU(WS-PRD) TO V0DPCF-CODPRODU. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU, V0DPCF_CODPRODU);

            /*" -2526- MOVE ZEROS TO V0DPCF-CODEMP */
            _.Move(0, V0DPCF_CODEMP);

            /*" -2527- MOVE V0AVIS-BCOAVISO TO V0DPCF-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0DPCF_BCOAVISO);

            /*" -2528- MOVE V0AVIS-AGEAVISO TO V0DPCF-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0DPCF_AGEAVISO);

            /*" -2529- MOVE V0AVIS-NRAVISO TO V0DPCF-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0DPCF_NRAVISO);

            /*" -2530- MOVE '1' TO V0DPCF-TIPOCOB */
            _.Move("1", V0DPCF_TIPOCOB);

            /*" -2531- MOVE V0AVIS-DTMOVTO TO V0DPCF-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0DPCF_DTMOVTO);

            /*" -2532- MOVE V0AVIS-DTAVISO TO V0DPCF-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0DPCF_DTAVISO);

            /*" -2535- MOVE ZEROS TO V0DPCF-VLJUROS V0DPCF-VLMULTA. */
            _.Move(0, V0DPCF_VLJUROS, V0DPCF_VLMULTA);

            /*" -2536- MOVE V0AVIS-DTAVISO TO WDATA-REL */
            _.Move(V0AVIS_DTAVISO, WORK_AREA.WDATA_REL);

            /*" -2537- MOVE WDAT-REL-ANO TO V0DPCF-ANOREF */
            _.Move(WORK_AREA.FILLER_8.WDAT_REL_ANO, V0DPCF_ANOREF);

            /*" -2540- MOVE WDAT-REL-MES TO V0DPCF-MESREF. */
            _.Move(WORK_AREA.FILLER_8.WDAT_REL_MES, V0DPCF_MESREF);

            /*" -2541- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -2545- PERFORM R8550-00-GRAVA-TIPO THRU R8550-99-SAIDA 03 TIMES. */

            R8550_00_GRAVA_TIPO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/


            /*" -2545- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/

        [StopWatch]
        /*" R8550-00-GRAVA-TIPO */
        private void R8550_00_GRAVA_TIPO(bool isPerform = false)
        {
            /*" -2558- MOVE 'R8550-GRAVA-TIPO        ' TO PARAGRAFO. */
            _.Move("R8550-GRAVA-TIPO        ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2562- MOVE WTABG-TIPO(WS-PRD WS-TIP) TO V0DPCF-TIPOREG. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO, V0DPCF_TIPOREG);

            /*" -2563- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -2567- PERFORM R8600-00-GRAVA-REGISTRO THRU R8600-99-SAIDA 02 TIMES. */

            R8600_00_GRAVA_REGISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/


            /*" -2567- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/

        [StopWatch]
        /*" R8600-00-GRAVA-REGISTRO */
        private void R8600_00_GRAVA_REGISTRO(bool isPerform = false)
        {
            /*" -2580- MOVE 'R8600-GRAVA-REGISTRO    ' TO PARAGRAFO. */
            _.Move("R8600-GRAVA-REGISTRO    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2582- MOVE WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) TO V0DPCF-SITUACAO. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO, V0DPCF_SITUACAO);

            /*" -2584- MOVE WTABG-QTDE(WS-PRD WS-TIP WS-SIT) TO V0DPCF-QTDREG. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, V0DPCF_QTDREG);

            /*" -2586- MOVE WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLPRMTOT. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, V0DPCF_VLPRMTOT);

            /*" -2588- MOVE WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLTARIFA. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, V0DPCF_VLTARIFA);

            /*" -2590- MOVE WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLBALCAO. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, V0DPCF_VLBALCAO);

            /*" -2592- MOVE WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLIOCC. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, V0DPCF_VLIOCC);

            /*" -2596- MOVE WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLDESCON. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON, V0DPCF_VLDESCON);

            /*" -2603- COMPUTE V0DPCF-VLPRMLIQ EQUAL (V0DPCF-VLPRMTOT - V0DPCF-VLTARIFA - V0DPCF-VLBALCAO - V0DPCF-VLIOCC - V0DPCF-VLDESCON - V0DPCF-VLJUROS - V0DPCF-VLMULTA). */
            V0DPCF_VLPRMLIQ.Value = (V0DPCF_VLPRMTOT - V0DPCF_VLTARIFA - V0DPCF_VLBALCAO - V0DPCF_VLIOCC - V0DPCF_VLDESCON - V0DPCF_VLJUROS - V0DPCF_VLMULTA);

            /*" -2608- IF V0DPCF-QTDREG EQUAL ZEROS AND V0DPCF-VLPRMTOT EQUAL ZEROS AND V0DPCF-VLPRMLIQ EQUAL ZEROS AND V0DPCF-VLTARIFA EQUAL ZEROS AND V0DPCF-VLBALCAO EQUAL ZEROS */

            if (V0DPCF_QTDREG == 00 && V0DPCF_VLPRMTOT == 00 && V0DPCF_VLPRMLIQ == 00 && V0DPCF_VLTARIFA == 00 && V0DPCF_VLBALCAO == 00)
            {

                /*" -2609- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -2612- GO TO R8600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2616- PERFORM R8700-00-INSERT-DESPESAS THRU R8700-99-SAIDA. */

            R8700_00_INSERT_DESPESAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8700_99_SAIDA*/


            /*" -2625- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -2625- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS */
        private void R8700_00_INSERT_DESPESAS(bool isPerform = false)
        {
            /*" -2638- MOVE 'R8700-INSERT-DESPESAS   ' TO PARAGRAFO. */
            _.Move("R8700-INSERT-DESPESAS   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2663- PERFORM R8700_00_INSERT_DESPESAS_DB_INSERT_1 */

            R8700_00_INSERT_DESPESAS_DB_INSERT_1();

            /*" -2667- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2668- DISPLAY 'R8700-00 - PROBLEMAS INSERT (DESPESAS)   ' */
                _.Display($"R8700-00 - PROBLEMAS INSERT (DESPESAS)   ");

                /*" -2668- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-DB-INSERT-1 */
        public void R8700_00_INSERT_DESPESAS_DB_INSERT_1()
        {
            /*" -2663- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF VALUES (:V0DPCF-CODEMP , :V0DPCF-ANOREF , :V0DPCF-MESREF , :V0DPCF-BCOAVISO , :V0DPCF-AGEAVISO , :V0DPCF-NRAVISO , :V0DPCF-CODPRODU , :V0DPCF-TIPOREG , :V0DPCF-SITUACAO , :V0DPCF-TIPOCOB , :V0DPCF-DTMOVTO , :V0DPCF-DTAVISO , :V0DPCF-QTDREG , :V0DPCF-VLPRMTOT , :V0DPCF-VLPRMLIQ , :V0DPCF-VLTARIFA , :V0DPCF-VLBALCAO , :V0DPCF-VLIOCC , :V0DPCF-VLDESCON , :V0DPCF-VLJUROS , :V0DPCF-VLMULTA , CURRENT TIMESTAMP) END-EXEC. */

            var r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 = new R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1()
            {
                V0DPCF_CODEMP = V0DPCF_CODEMP.ToString(),
                V0DPCF_ANOREF = V0DPCF_ANOREF.ToString(),
                V0DPCF_MESREF = V0DPCF_MESREF.ToString(),
                V0DPCF_BCOAVISO = V0DPCF_BCOAVISO.ToString(),
                V0DPCF_AGEAVISO = V0DPCF_AGEAVISO.ToString(),
                V0DPCF_NRAVISO = V0DPCF_NRAVISO.ToString(),
                V0DPCF_CODPRODU = V0DPCF_CODPRODU.ToString(),
                V0DPCF_TIPOREG = V0DPCF_TIPOREG.ToString(),
                V0DPCF_SITUACAO = V0DPCF_SITUACAO.ToString(),
                V0DPCF_TIPOCOB = V0DPCF_TIPOCOB.ToString(),
                V0DPCF_DTMOVTO = V0DPCF_DTMOVTO.ToString(),
                V0DPCF_DTAVISO = V0DPCF_DTAVISO.ToString(),
                V0DPCF_QTDREG = V0DPCF_QTDREG.ToString(),
                V0DPCF_VLPRMTOT = V0DPCF_VLPRMTOT.ToString(),
                V0DPCF_VLPRMLIQ = V0DPCF_VLPRMLIQ.ToString(),
                V0DPCF_VLTARIFA = V0DPCF_VLTARIFA.ToString(),
                V0DPCF_VLBALCAO = V0DPCF_VLBALCAO.ToString(),
                V0DPCF_VLIOCC = V0DPCF_VLIOCC.ToString(),
                V0DPCF_VLDESCON = V0DPCF_VLDESCON.ToString(),
                V0DPCF_VLJUROS = V0DPCF_VLJUROS.ToString(),
                V0DPCF_VLMULTA = V0DPCF_VLMULTA.ToString(),
            };

            R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1.Execute(r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8700_99_SAIDA*/

        [StopWatch]
        /*" R8800-00-UPDATE-FOLLOWUP-SECTION */
        private void R8800_00_UPDATE_FOLLOWUP_SECTION()
        {
            /*" -2681- MOVE 'R8800-UPDATE-FOLLOWUP   ' TO PARAGRAFO. */
            _.Move("R8800-UPDATE-FOLLOWUP   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2683- MOVE 'UPDATE FOLLOWUP         ' TO COMANDO. */
            _.Move("UPDATE FOLLOWUP         ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2695- PERFORM R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1 */

            R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1();

            /*" -2698- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2699- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2700- DISPLAY 'R8800-00 - PROBLEMAS UPDATE (FOLLOWUP) 100' */
                    _.Display($"R8800-00 - PROBLEMAS UPDATE (FOLLOWUP) 100");

                    /*" -2701- DISPLAY 'NUM_CERTIFICADO ' RF-IDENTIF-CLI */
                    _.Display($"NUM_CERTIFICADO {RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI}");

                    /*" -2702- DISPLAY 'NUM_NOSSA_FITA  ' RF-IDENTIF-NSAS */
                    _.Display($"NUM_NOSSA_FITA  {RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSAS}");

                    /*" -2703- DISPLAY 'NUM_LANCAMENTO  ' RF-NSL */
                    _.Display($"NUM_LANCAMENTO  {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL}");

                    /*" -2704- ELSE */
                }
                else
                {


                    /*" -2705- DISPLAY 'R8800-00 - PROBLEMAS UPDATE (FOLLOWUP)   ' */
                    _.Display($"R8800-00 - PROBLEMAS UPDATE (FOLLOWUP)   ");

                    /*" -2705- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8800-00-UPDATE-FOLLOWUP-DB-UPDATE-1 */
        public void R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1()
        {
            /*" -2695- EXEC SQL UPDATE SEGUROS.VG_FOLLOW_UP SET NUM_PARCELA_USADA = :V0HCOB-NRPARCEL, STA_PROCESSAMENTO = 'P' , COD_USUARIO = 'VF0813B' , DTH_ATUALIZACAO = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :VGFOLLOW-NUM-CERTIFICADO AND NUM_NOSSA_FITA = :VGFOLLOW-NUM-NOSSA-FITA AND NUM_LANCAMENTO = :VGFOLLOW-NUM-LANCAMENTO END-EXEC. */

            var r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1 = new R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1()
            {
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                VGFOLLOW_NUM_CERTIFICADO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO.ToString(),
                VGFOLLOW_NUM_NOSSA_FITA = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA.ToString(),
                VGFOLLOW_NUM_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO.ToString(),
            };

            R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1.Execute(r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8800_99_SAIDA*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -2718- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -2719- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -2720- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -2721- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -2722- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -2724- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -2725- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -2727- CLOSE RETERR. */
            RETERR.Close();

            /*" -2727- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2730- DISPLAY 'CERTIFICADO ' V0HCTA-NRCERTIF. */
            _.Display($"CERTIFICADO {V0HCTA_NRCERTIF}");

            /*" -2732- DISPLAY 'PARCELA     ' V0PARC-NRPARCEL. */
            _.Display($"PARCELA     {V0PARC_NRPARCEL}");

            /*" -2734- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2734- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_99_SAIDA*/
    }
}