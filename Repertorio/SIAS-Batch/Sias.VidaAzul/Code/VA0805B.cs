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
using Sias.VidaAzul.DB2.VA0805B;

namespace Code
{
    public class VA0805B
    {
        public bool IsCall { get; set; }

        public VA0805B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *            CONSISTENCIA DA FITA RETORNO FEBRABAN               *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  31/08/92  *   FONSECA    *                       *      */
        /*"      *     02     *    /  /    *              *                       *      */
        /*"      *     03     *    /  /    *              *                       *      */
        /*"      ******************************************************************      */
        /*"      *  DESCRICAO SUMARIA                                             *      */
        /*"      *                                                                *      */
        /*"      *         O PROGRAMA LE A FITA DE RETORNO DA CEF E CONSISTE O    *      */
        /*"      *     MOVIMENTO, EMITINDO RELATORIO DE CONSISTENCIA.             *      */
        /*"      *                                                                *      */
        /*"      *         OS MOVIMENTOS SAO SEPARADOS EM MOVIMENTO RETORNO       *      */
        /*"      *     ORIGINARIO DO DEBITO EM CONTA, MOVIMENTO RETORNO           *      */
        /*"      *     ORIGINARIO DO CREDITO DE COMISSAO, E MOVIMENTO RETORNO     *      */
        /*"      *     ORIGINARIO DO CADASTRAMENTO DE OPTANTES PELAS AGENCIAS.    *      */
        /*"      *                                                                *      */
        /*"      *         CASO TEHA HAVIDO QUALQUER ERRO DE CONSISTENCIA, A      *      */
        /*"      *     APLICACAO ABORTA NO FINAL. AS CONSISTENCIAS DEVEM SER      *      */
        /*"      *     ANALISADAS POSTERIORMENTE.                                 *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE FONSECA           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 27.01.93 - ALEXANDRE F FONSECA                   *      */
        /*"      *                                                                *      */
        /*"      *    A CEF ALTEROU O PADRAO FEBRABAN COM RELACAO AO              *      */
        /*"      *  CADASTRAMENTO DAS AUTORIZACOES DE DEBITO EM CONTA (FAX DE     *      */
        /*"      *  08.01.93 DIDEB/BSB), PASSANDO A UTILIZAR O IDENTIFICADOR      *      */
        /*"      *  DO CLIENTE NA EMPRESA COMO PARTE DA CHAVE.                    *      */
        /*"      *    A SASSE PASSARA A GERAR AS AUTORIZACOES CONTENDO O NUMERO   *      */
        /*"      *  DO CERTIFICADO DO SEGURADO. AS AUTORIZACOES FEITAS PELAS      *      */
        /*"      *  AGENCIAS SERAO IGNORADAS POIS ELAS NAO TERAO COMO IDENTIFICAR *      */
        /*"      *  OS CLIENTES. ESTE PROGRAMA PASSA A DESPREZAR OS RETORNOS DAS  *      */
        /*"      *  AUTORIZACOES DAS AGENCIAS.                                    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 13.08.93 - ALEXANDRE F FONSECA                   *      */
        /*"      *                                                                *      */
        /*"      *    RETIRADA A CRITICA DE 'CONTINUACAO DA AREA RESERVADA        *      */
        /*"      *  DIFERENTE DE BRANCOS' VISTO QUE TEM PROVOCADO O CANCELAMENTO  *      */
        /*"      *  DE PRATICAMENTE TODAS AS CRITICAS E NAO DECORRE DE INCONSIS-  *      */
        /*"      *  TENCIA DE INFORMACOES.                                        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 13.08.95 - ALEXANDRE F FONSECA                   *      */
        /*"      *                                                                *      */
        /*"      *    PASSAM A SER RETORNADOS OS CONVENIOS 6038 A 6044, ALEM      *      */
        /*"      *  DO 6001                                                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 27.10.95 - EDSON GUIMARAES                       *      */
        /*"      *                                                                *      */
        /*"      *    PASSA A SER ACEITO O COD-RETORNO = 99 ( AUTORIZACAO DE DEBI-*      */
        /*"      *  TO CANCELADA)                                                 *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 09.05.97 - FONSECA                               *      */
        /*"      *                                                                *      */
        /*"      *    PASSA A ENXERGAR OS CONVENIOS DO EMPRESA GLOBAL             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4           15/06/1998  *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 27.07.1999 - FONSECA                             *      */
        /*"      *                                                                *      */
        /*"      *    PASSA A ENXERGAR O CONVENIO 6131 - FEDERAL PLUS             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 26.08.1999 - TERCIO                              *      */
        /*"      *                                                                *      */
        /*"      *    PASSA A TRATAR O NSA-CEF COM TRES POSICOES EM FUNCAO DO     *      */
        /*"      *    ESTOURO DAS FAIXAS.       PROCURE TL9908                    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 27.10.1999 - MESSIAS                             *      */
        /*"      *                                                                *      */
        /*"      *    PASSA A GERAR O RELATORIO DE LANCAMENTOS RECEBIDOS DA CEF   *      */
        /*"      *    SOMENTE COM OS TOTAIS.    PROCURE MM2710                    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO EM 13.03.2001 - LIANE                               *      */
        /*"      *                                                                *      */
        /*"      *    ALTERACAO DA COLUNA COD_CONVENIO DE SMALLINT PARA INTEGER   *      */
        /*"      *    PROCURE LP0301                                              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - Incidente 513798                                 *      */
        /*"      *             - ERRO DE SORT RC=16 ESTA MASCARANDO ERRO NO PROCES*      */
        /*"      *               SAMENTO DO ARQUIVO. REVISAR PROGRAMA E COLOCAR   *      */
        /*"      *               DISPLAY                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/07/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 -   ABEND - 152826                                 *      */
        /*"      *               - INCLUIR OS NOVOS CODIGOS DE RETORNO:           *      */
        /*"      *                                                                *      */
        /*"      *               0013       - DATA LANC. INVALIDA                 *      */
        /*"      *               0018       - DATA ANTERIOR PROC                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/07/2017 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 -   FGV-2                                          *      */
        /*"      *               - AJUSTES NO PROGRAMA A FIM DE FAZER UMA EXECUCAO*      */
        /*"      *                 PARALELA ENTRE A JPVAD00 E JPCSD01.            *      */
        /*"      *   EM 08/02/2017 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 35.895                                       *      */
        /*"      *               TRATAMENTO PARA ARQUIVO VAZIO, NAO ENVIAR PARA   *      */
        /*"      *               ROTINA DE ERRO.                                  *      */
        /*"      *               CAPITALIZACAO.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2010 - TERCIO FREITAS           PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RVA0805B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVA0805B
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RVA0805B); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RVA0805B, REG_IMPRESSAO); return _RVA0805B;
            }
        }
        public FileBasis _RVA0805B2 { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVA0805B2
        {
            get
            {
                _.Move(REG_RVA0805B2, _RVA0805B2); VarBasis.RedefinePassValue(REG_RVA0805B2, _RVA0805B2, REG_RVA0805B2); return _RVA0805B2;
            }
        }
        public FileBasis _RETCEF { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETCEF
        {
            get
            {
                _.Move(RETCEF_RECORD, _RETCEF); VarBasis.RedefinePassValue(RETCEF_RECORD, _RETCEF, RETCEF_RECORD); return _RETCEF;
            }
        }
        public FileBasis _RETOPT { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETOPT
        {
            get
            {
                _.Move(RETOPT_RECORD, _RETOPT); VarBasis.RedefinePassValue(RETOPT_RECORD, _RETOPT, RETOPT_RECORD); return _RETOPT;
            }
        }
        public FileBasis _RETDEB { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETDEB
        {
            get
            {
                _.Move(RETDEB_RECORD, _RETDEB); VarBasis.RedefinePassValue(RETDEB_RECORD, _RETDEB, RETDEB_RECORD); return _RETDEB;
            }
        }
        public FileBasis _RETCRE { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETCRE
        {
            get
            {
                _.Move(RETCRE_RECORD, _RETCRE); VarBasis.RedefinePassValue(RETCRE_RECORD, _RETCRE, RETCRE_RECORD); return _RETCRE;
            }
        }
        public SortBasis<VA0805B_REG_SVA0805B> SVA0805B { get; set; } = new SortBasis<VA0805B_REG_SVA0805B>(new VA0805B_REG_SVA0805B());
        /*"01  REG-IMPRESSAO        PIC X(132).*/
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01  REG-RVA0805B2        PIC X(132).*/
        public StringBasis REG_RVA0805B2 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01  RETCEF-RECORD        PIC X(150).*/
        public StringBasis RETCEF_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  RETCEF-PARTES.*/
        public VA0805B_RETCEF_PARTES RETCEF_PARTES { get; set; } = new VA0805B_RETCEF_PARTES();
        public class VA0805B_RETCEF_PARTES : VarBasis
        {
            /*"    05 RETCEF-PARTE-1    PIC X(50).*/
            public StringBasis RETCEF_PARTE_1 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"    05 RETCEF-PARTE-2    PIC X(50).*/
            public StringBasis RETCEF_PARTE_2 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"    05 RETCEF-PARTE-3    PIC X(50).*/
            public StringBasis RETCEF_PARTE_3 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"01  RET-HEADER.*/
        }
        public VA0805B_RET_HEADER RET_HEADER { get; set; } = new VA0805B_RET_HEADER();
        public class VA0805B_RET_HEADER : VarBasis
        {
            /*"    05 RA-COD-REG         PIC X(001).*/
            public StringBasis RA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RA-COD-REMESSA     PIC X(001).*/
            public StringBasis RA_COD_REMESSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RA-COD-CONVENIO    PIC X(004).*/
            public StringBasis RA_COD_CONVENIO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05 FILLER             PIC X(016).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
            /*"    05 RA-NOME-EMPRESA    PIC X(020).*/
            public StringBasis RA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05 RA-COD-BANCO       PIC X(003).*/
            public StringBasis RA_COD_BANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05 RA-NOME-BANCO      PIC X(020).*/
            public StringBasis RA_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05 RA-DATA-GERACAO    PIC X(008).*/
            public StringBasis RA_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 RA-NSA             PIC X(006).*/
            public StringBasis RA_NSA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05 RA-VERSAO-LAYOUT   PIC X(002).*/
            public StringBasis RA_VERSAO_LAYOUT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05 RA-SERVICO         PIC X(017).*/
            public StringBasis RA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RA-RESERVADO       PIC X(052).*/
            public StringBasis RA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01  RET-CADASTRAMENTO.*/
        }
        public VA0805B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA0805B_RET_CADASTRAMENTO();
        public class VA0805B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05 RB-COD-REG          PIC X(001).*/
            public StringBasis RB_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RB-IDENT-CLI-EMPRESA.*/
            public VA0805B_RB_IDENT_CLI_EMPRESA RB_IDENT_CLI_EMPRESA { get; set; } = new VA0805B_RB_IDENT_CLI_EMPRESA();
            public class VA0805B_RB_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 RB-IDENTIF-CLI   PIC X(015).*/
                public StringBasis RB_IDENTIF_CLI { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"       10 RB-IDENTIF-RESTO PIC X(010).*/
                public StringBasis RB_IDENTIF_RESTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05 RB-AGENCIA          PIC X(004).*/
            }
            public StringBasis RB_AGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05 RB-IDENT-CLI-BANCO.*/
            public VA0805B_RB_IDENT_CLI_BANCO RB_IDENT_CLI_BANCO { get; set; } = new VA0805B_RB_IDENT_CLI_BANCO();
            public class VA0805B_RB_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 RB-COD-OPERACAO  PIC X(004).*/
                public StringBasis RB_COD_OPERACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10 RB-NUM-CONTA     PIC X(012).*/
                public StringBasis RB_NUM_CONTA { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"       10 RB-DIG-CONTA     PIC X(001).*/
                public StringBasis RB_DIG_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 RB-IDENT-RESTO   PIC X(002).*/
                public StringBasis RB_IDENT_RESTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RB-DATA-OPCAO       PIC X(008).*/
            }
            public StringBasis RB_DATA_OPCAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 RB-RESERVADO        PIC X(092).*/
            public StringBasis RB_RESERVADO { get; set; } = new StringBasis(new PIC("X", "92", "X(092)."), @"");
            /*"    05 RB-COD-MOVIMENTO    PIC X(001).*/
            public StringBasis RB_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01  RET-LANCAMENTO.*/
        }
        public VA0805B_RET_LANCAMENTO RET_LANCAMENTO { get; set; } = new VA0805B_RET_LANCAMENTO();
        public class VA0805B_RET_LANCAMENTO : VarBasis
        {
            /*"    05 RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RF-IDENT-CLI-EMPRESA.*/
            public VA0805B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA0805B_RF_IDENT_CLI_EMPRESA();
            public class VA0805B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 RF-IDENTIF-CLI   PIC X(015).*/
                public StringBasis RF_IDENTIF_CLI { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"       10 RF-IDENTIF-RESTO PIC X(010).*/
                public StringBasis RF_IDENTIF_RESTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05 RF-AGENCIA          PIC X(004).*/
            }
            public StringBasis RF_AGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VA0805B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA0805B_RF_IDENT_CLI_BANCO();
            public class VA0805B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 RF-COD-OPERACAO  PIC X(004).*/
                public StringBasis RF_COD_OPERACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10 RF-NUM-CONTA     PIC X(012).*/
                public StringBasis RF_NUM_CONTA { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"       10 RF-DIG-CONTA     PIC X(001).*/
                public StringBasis RF_DIG_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 RF-IDENT-RESTO   PIC X(002).*/
                public StringBasis RF_IDENT_RESTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL        PIC X(008).*/
            }
            public StringBasis RF_DATA_REAL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 RF-VALOR            PIC X(15).*/
            public StringBasis RF_VALOR { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 RF-COD-RETORNO      PIC X(002).*/
            public StringBasis RF_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05 RF-USO-EMPRESA.*/
            public VA0805B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA0805B_RF_USO_EMPRESA();
            public class VA0805B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10 RF-NSA           PIC X(003).*/
                public StringBasis RF_NSA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"       10 RF-NSL           PIC X(008).*/
                public StringBasis RF_NSL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"       10 RF-RES-RESTO     PIC X(047).*/
                public StringBasis RF_RES_RESTO { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 RF-RESERVADO        PIC X(017).*/
            }
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RF-COD-MOVIMENTO    PIC X(001).*/
            public StringBasis RF_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01  RET-TRAILLER.*/
        }
        public VA0805B_RET_TRAILLER RET_TRAILLER { get; set; } = new VA0805B_RET_TRAILLER();
        public class VA0805B_RET_TRAILLER : VarBasis
        {
            /*"    05 RZ-COD-REG         PIC X(001).*/
            public StringBasis RZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RZ-QTDE-REGISTROS  PIC X(006).*/
            public StringBasis RZ_QTDE_REGISTROS { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05 RZ-TOT-DEB-CRUZ    PIC X(017).*/
            public StringBasis RZ_TOT_DEB_CRUZ { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RZ-TOT-CRED-CRUZ   PIC X(017).*/
            public StringBasis RZ_TOT_CRED_CRUZ { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RZ-RESERVADO       PIC X(109).*/
            public StringBasis RZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01  RETOPT-RECORD        PIC X(150).*/
        }
        public StringBasis RETOPT_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  RETDEB-RECORD        PIC X(150).*/
        public StringBasis RETDEB_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  RETCRE-RECORD        PIC X(150).*/
        public StringBasis RETCRE_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  REG-SVA0805B.*/
        public VA0805B_REG_SVA0805B REG_SVA0805B { get; set; } = new VA0805B_REG_SVA0805B();
        public class VA0805B_REG_SVA0805B : VarBasis
        {
            /*"    05  SVA-DEB-CRED      PIC  X(001).*/
            public StringBasis SVA_DEB_CRED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  SVA-CODPRODAZ     PIC  X(003).*/
            public StringBasis SVA_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05  SVA-VALOR         PIC  9(013)V99.*/
            public DoubleBasis SVA_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05  SVA-IDX           PIC  9(002).*/
            public IntBasis SVA_IDX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  SVA-COD-RETORNO   PIC  9(002).*/
            public IntBasis SVA_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"01  WHOST-ACESSO                     PIC S9(15) COMP-3.*/
        public IntBasis WHOST_ACESSO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  WHOST-COD-CLIENTE                PIC S9(09) COMP.*/
        public IntBasis WHOST_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  WHOST-NOME                       PIC  X(40).*/
        public StringBasis WHOST_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  WHOST-AGENCIA                    PIC S9(4)  COMP.*/
        public IntBasis WHOST_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-OPERACAO                   PIC S9(4)  COMP.*/
        public IntBasis WHOST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-NRCONTA                    PIC S9(17) COMP-3.*/
        public IntBasis WHOST_NRCONTA { get; set; } = new IntBasis(new PIC("S9", "17", "S9(17)"));
        /*"01  WHOST-NRCONTA-P                  PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NRCONTA_P { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  WHOST-COD-CONVENIO               PIC S9(9)  COMP.*/
        public IntBasis WHOST_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  WHOST-NOME-CONVENIO              PIC  X(30).*/
        public StringBasis WHOST_NOME_CONVENIO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01  SQL-MAYBE-NULL                   PIC S9(4)  COMP.*/
        public IntBasis SQL_MAYBE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SIST-DATA-SAIDA                  PIC  X(10).*/
        public StringBasis SIST_DATA_SAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DATA-SQL                    PIC  X(10).*/
        public StringBasis SIST_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V1SIST-DTMOVABE                  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V1SIST-DTCURRENT                 PIC  X(10).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V1SIST-DTCURRENT-18              PIC  X(10).*/
        public StringBasis V1SIST_DTCURRENT_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PROD-CODPRODAZ                 PIC  X(03).*/
        public StringBasis V0PROD_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  FITCEF-DTRET                     PIC  X(10).*/
        public StringBasis FITCEF_DTRET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  FITCEF-DATA-GERACAO              PIC  X(10).*/
        public StringBasis FITCEF_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  FITCEF-NSAC                      PIC S9(4)  COMP.*/
        public IntBasis FITCEF_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  FITCEF-NSA                       PIC S9(4)  COMP.*/
        public IntBasis FITCEF_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPT-IDENTIF                      PIC S9(15) COMP-3.*/
        public IntBasis OPT_IDENTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  OPT-AGENCIA                      PIC S9(4)  COMP.*/
        public IntBasis OPT_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPT-OPERACAO                     PIC S9(4)  COMP.*/
        public IntBasis OPT_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPT-CONTA                        PIC S9(13) COMP-3.*/
        public IntBasis OPT_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  OPT-DIGITO                       PIC S9(4)  COMP.*/
        public IntBasis OPT_DIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-IDENTIF                      PIC S9(15) COMP-3.*/
        public IntBasis SQL_IDENTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SQL-AGENCIA                      PIC S9(4)  COMP.*/
        public IntBasis SQL_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-OPERACAO                     PIC S9(4)  COMP.*/
        public IntBasis SQL_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-CONTA                        PIC S9(13) COMP-3.*/
        public IntBasis SQL_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  SQL-DIGITO                       PIC S9(4)  COMP.*/
        public IntBasis SQL_DIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DEBTO-AGENCIA                    PIC S9(4)  COMP.*/
        public IntBasis DEBTO_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DEBTO-OPERACAO                   PIC S9(4)  COMP.*/
        public IntBasis DEBTO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DEBTO-CONTA                      PIC S9(13) COMP-3.*/
        public IntBasis DEBTO_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  DEBTO-DIGITO                     PIC S9(4)  COMP.*/
        public IntBasis DEBTO_DIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DEBTO-SITUACAO                   PIC  X(1).*/
        public StringBasis DEBTO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  DEBTO-VALOR                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DEBTO_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DEBTO-NSAS                       PIC S9(4)  COMP.*/
        public IntBasis DEBTO_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DEBTO-NSL                        PIC S9(9)  COMP.*/
        public IntBasis DEBTO_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  MVCOM-IDENTIF                    PIC S9(15) COMP-3.*/
        public IntBasis MVCOM_IDENTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  MVCOM-AGENCIA                    PIC S9(4)  COMP.*/
        public IntBasis MVCOM_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-OPERACAO                   PIC S9(4)  COMP.*/
        public IntBasis MVCOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-CONTA                      PIC S9(13) COMP-3.*/
        public IntBasis MVCOM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  MVCOM-DIGITO                     PIC S9(4)  COMP.*/
        public IntBasis MVCOM_DIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-NSAS                       PIC S9(4)  COMP.*/
        public IntBasis MVCOM_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-NSL                        PIC S9(9)  COMP.*/
        public IntBasis MVCOM_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  MVCOM-SITUACAO                   PIC  X(1).*/
        public StringBasis MVCOM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  MVCOM-VALOR                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis MVCOM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FITSAS-NSAS                      PIC S9(4)  COMP.*/
        public IntBasis FITSAS_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  FITSAS-NSL                       PIC S9(9)  COMP.*/
        public IntBasis FITSAS_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-ULTNSL                    PIC S9(9)  COMP.*/
        public IntBasis FITSAS_ULTNSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-ORIGEM                    PIC  X(1).*/
        public StringBasis FITSAS_ORIGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  WORK-AREA.*/
        public VA0805B_WORK_AREA WORK_AREA { get; set; } = new VA0805B_WORK_AREA();
        public class VA0805B_WORK_AREA : VarBasis
        {
            /*"    05 WORK-AREA-1.*/
            public VA0805B_WORK_AREA_1 WORK_AREA_1 { get; set; } = new VA0805B_WORK_AREA_1();
            public class VA0805B_WORK_AREA_1 : VarBasis
            {
                /*"       10 WRA-NSA-R                     PIC X(006).*/
                public StringBasis WRA_NSA_R { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"       10 WRA-COD-CONVENIO-R            PIC X(020).*/
                public StringBasis WRA_COD_CONVENIO_R { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10 WRB-IDENTIF-CLI-R             PIC X(015).*/
                public StringBasis WRB_IDENTIF_CLI_R { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"       10 WRB-AGENCIA-R                 PIC X(004).*/
                public StringBasis WRB_AGENCIA_R { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10 WRB-COD-OPERACAO-R            PIC X(004).*/
                public StringBasis WRB_COD_OPERACAO_R { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10 WRB-NUM-CONTA-R               PIC X(012).*/
                public StringBasis WRB_NUM_CONTA_R { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"       10 WRB-DIG-CONTA-R               PIC X(001).*/
                public StringBasis WRB_DIG_CONTA_R { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WRF-IDENTIF-CLI-R             PIC X(015).*/
                public StringBasis WRF_IDENTIF_CLI_R { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"       10 WRF-AGENCIA-R                 PIC X(004).*/
                public StringBasis WRF_AGENCIA_R { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10 WRF-COD-OPERACAO-R            PIC X(004).*/
                public StringBasis WRF_COD_OPERACAO_R { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10 WRF-NUM-CONTA-R               PIC X(012).*/
                public StringBasis WRF_NUM_CONTA_R { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"       10 WRF-DIG-CONTA-R               PIC X(001).*/
                public StringBasis WRF_DIG_CONTA_R { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WRF-COD-RETORNO-R             PIC X(002).*/
                public StringBasis WRF_COD_RETORNO_R { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10 WRF-VALOR-R                   PIC X(15).*/
                public StringBasis WRF_VALOR_R { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"       10 WRF-NSA-R                     PIC X(003).*/
                public StringBasis WRF_NSA_R { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"       10 WRF-NSL-R                     PIC X(008).*/
                public StringBasis WRF_NSL_R { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"       10 WRZ-QTDE-REGISTROS-R          PIC X(006).*/
                public StringBasis WRZ_QTDE_REGISTROS_R { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"       10 WRZ-TOT-DEB-CRUZ-R            PIC X(017).*/
                public StringBasis WRZ_TOT_DEB_CRUZ_R { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
                /*"       10 WRZ-TOT-CRED-CRUZ-R           PIC X(017).*/
                public StringBasis WRZ_TOT_CRED_CRUZ_R { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
                /*"    05 WORK-AREA-2 REDEFINES WORK-AREA-1.*/
            }
            private _REDEF_VA0805B_WORK_AREA_2 _work_area_2 { get; set; }
            public _REDEF_VA0805B_WORK_AREA_2 WORK_AREA_2
            {
                get { _work_area_2 = new _REDEF_VA0805B_WORK_AREA_2(); _.Move(WORK_AREA_1, _work_area_2); VarBasis.RedefinePassValue(WORK_AREA_1, _work_area_2, WORK_AREA_1); _work_area_2.ValueChanged += () => { _.Move(_work_area_2, WORK_AREA_1); }; return _work_area_2; }
                set { VarBasis.RedefinePassValue(value, _work_area_2, WORK_AREA_1); }
            }  //Redefines
            public class _REDEF_VA0805B_WORK_AREA_2 : VarBasis
            {
                /*"       10 WRA-NSA                       PIC 9(006).*/
                public IntBasis WRA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"       10 WRA-COD-CONVENIO-I.*/
                public VA0805B_WRA_COD_CONVENIO_I WRA_COD_CONVENIO_I { get; set; } = new VA0805B_WRA_COD_CONVENIO_I();
                public class VA0805B_WRA_COD_CONVENIO_I : VarBasis
                {
                    /*"          15  WRA-COD-CONVENIO          PIC 9(004).*/
                    public IntBasis WRA_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"          15  FILLER                    PIC 9(016).*/
                    public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                    /*"       10 WRB-IDENTIF-CLI               PIC 9(015).*/

                    public VA0805B_WRA_COD_CONVENIO_I()
                    {
                        WRA_COD_CONVENIO.ValueChanged += OnValueChanged;
                        FILLER_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WRB_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 WRB-AGENCIA                   PIC 9(004).*/
                public IntBasis WRB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 WRB-COD-OPERACAO              PIC 9(004).*/
                public IntBasis WRB_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 WRB-NUM-CONTA                 PIC 9(012).*/
                public IntBasis WRB_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 WRB-DIG-CONTA                 PIC 9(001).*/
                public IntBasis WRB_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 WRF-IDENTIF-CLI               PIC 9(015).*/
                public IntBasis WRF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 WRF-AGENCIA                   PIC 9(004).*/
                public IntBasis WRF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 WRF-COD-OPERACAO              PIC 9(004).*/
                public IntBasis WRF_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 WRF-NUM-CONTA                 PIC 9(012).*/
                public IntBasis WRF_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 WRF-DIG-CONTA                 PIC 9(001).*/
                public IntBasis WRF_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 WRF-COD-RETORNO               PIC 9(002).*/
                public IntBasis WRF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 WRF-VALOR                     PIC 9(13)V99.*/
                public DoubleBasis WRF_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
                /*"       10 WRF-NSA                       PIC 9(003).*/
                public IntBasis WRF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 WRF-NSL                       PIC 9(008).*/
                public IntBasis WRF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 WRZ-QTDE-REGISTROS            PIC 9(006).*/
                public IntBasis WRZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"       10 WRZ-TOT-DEB-CRUZ              PIC 9(015)V99.*/
                public DoubleBasis WRZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
                /*"       10 WRZ-TOT-CRED-CRUZ             PIC 9(015)V99.*/
                public DoubleBasis WRZ_TOT_CRED_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
                /*"    05      WANO4                    PIC  9(004).*/

                public _REDEF_VA0805B_WORK_AREA_2()
                {
                    WRA_NSA.ValueChanged += OnValueChanged;
                    WRA_COD_CONVENIO_I.ValueChanged += OnValueChanged;
                    WRB_IDENTIF_CLI.ValueChanged += OnValueChanged;
                    WRB_AGENCIA.ValueChanged += OnValueChanged;
                    WRB_COD_OPERACAO.ValueChanged += OnValueChanged;
                    WRB_NUM_CONTA.ValueChanged += OnValueChanged;
                    WRB_DIG_CONTA.ValueChanged += OnValueChanged;
                    WRF_IDENTIF_CLI.ValueChanged += OnValueChanged;
                    WRF_AGENCIA.ValueChanged += OnValueChanged;
                    WRF_COD_OPERACAO.ValueChanged += OnValueChanged;
                    WRF_NUM_CONTA.ValueChanged += OnValueChanged;
                    WRF_DIG_CONTA.ValueChanged += OnValueChanged;
                    WRF_COD_RETORNO.ValueChanged += OnValueChanged;
                    WRF_VALOR.ValueChanged += OnValueChanged;
                    WRF_NSA.ValueChanged += OnValueChanged;
                    WRF_NSL.ValueChanged += OnValueChanged;
                    WRZ_QTDE_REGISTROS.ValueChanged += OnValueChanged;
                    WRZ_TOT_DEB_CRUZ.ValueChanged += OnValueChanged;
                    WRZ_TOT_CRED_CRUZ.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WANO4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05      DATA-SQL.*/
            public VA0805B_DATA_SQL DATA_SQL { get; set; } = new VA0805B_DATA_SQL();
            public class VA0805B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL                  PIC  X(004).*/
                public StringBasis ANO_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-SQL                  PIC  X(002).*/
                public StringBasis MES_SQL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-SQL                  PIC  X(002).*/
                public StringBasis DIA_SQL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 WS-NSA-X                      PIC  X(006).*/
            }
            public StringBasis WS_NSA_X { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05 WS-NSA-R REDEFINES WS-NSA-X.*/
            private _REDEF_VA0805B_WS_NSA_R _ws_nsa_r { get; set; }
            public _REDEF_VA0805B_WS_NSA_R WS_NSA_R
            {
                get { _ws_nsa_r = new _REDEF_VA0805B_WS_NSA_R(); _.Move(WS_NSA_X, _ws_nsa_r); VarBasis.RedefinePassValue(WS_NSA_X, _ws_nsa_r, WS_NSA_X); _ws_nsa_r.ValueChanged += () => { _.Move(_ws_nsa_r, WS_NSA_X); }; return _ws_nsa_r; }
                set { VarBasis.RedefinePassValue(value, _ws_nsa_r, WS_NSA_X); }
            }  //Redefines
            public class _REDEF_VA0805B_WS_NSA_R : VarBasis
            {
                /*"      10 FILLER                      PIC  X(003).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 WS-NSA                      PIC  9(003).*/
                public IntBasis WS_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05 WS-DATA-INV.*/

                public _REDEF_VA0805B_WS_NSA_R()
                {
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_NSA.ValueChanged += OnValueChanged;
                }

            }
            public VA0805B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA0805B_WS_DATA_INV();
            public class VA0805B_WS_DATA_INV : VarBasis
            {
                /*"      10 WS-ANO-INV                  PIC  X(004).*/
                public StringBasis WS_ANO_INV { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"      10 WS-MES-INV                  PIC  X(002).*/
                public StringBasis WS_MES_INV { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10 WS-DIA-INV                  PIC  X(002).*/
                public StringBasis WS_DIA_INV { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 WS-DATA-NOR.*/
            }
            public VA0805B_WS_DATA_NOR WS_DATA_NOR { get; set; } = new VA0805B_WS_DATA_NOR();
            public class VA0805B_WS_DATA_NOR : VarBasis
            {
                /*"      10 WS-DIA-NOR                  PIC  X(002).*/
                public StringBasis WS_DIA_NOR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10 WS-MES-NOR                  PIC  X(002).*/
                public StringBasis WS_MES_NOR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10 WS-ANO-NOR                  PIC  X(004).*/
                public StringBasis WS_ANO_NOR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/
            }
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-IDX                   PIC  9(002) VALUE 0.*/
            public IntBasis WS_IDX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05      WS-ERRO                  PIC  9(001) VALUE 0.*/
            public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-DEB-CRED-ANT          PIC  X(001) VALUE ' '.*/
            public StringBasis WS_DEB_CRED_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      WS-CODPRODAZ-ANT         PIC  X(003) VALUE SPACES.*/
            public StringBasis WS_CODPRODAZ_ANT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05      WFIM-SORT                PIC X(01) VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05      DATA-AUX.*/
            public VA0805B_DATA_AUX DATA_AUX { get; set; } = new VA0805B_DATA_AUX();
            public class VA0805B_DATA_AUX : VarBasis
            {
                /*"      10    DIA-AUX                  PIC  9(002).*/
                public IntBasis DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    MES-AUX                  PIC  9(002).*/
                public IntBasis MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    ANO-AUX                  PIC  9(004).*/
                public IntBasis ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 AC-LIDOS                      PIC 9(7) VALUE 1.*/
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"), 1);
            /*"    05 AC-LIDOS-R                    REDEFINES       AC-LIDOS.*/
            private _REDEF_VA0805B_AC_LIDOS_R _ac_lidos_r { get; set; }
            public _REDEF_VA0805B_AC_LIDOS_R AC_LIDOS_R
            {
                get { _ac_lidos_r = new _REDEF_VA0805B_AC_LIDOS_R(); _.Move(AC_LIDOS, _ac_lidos_r); VarBasis.RedefinePassValue(AC_LIDOS, _ac_lidos_r, AC_LIDOS); _ac_lidos_r.ValueChanged += () => { _.Move(_ac_lidos_r, AC_LIDOS); }; return _ac_lidos_r; }
                set { VarBasis.RedefinePassValue(value, _ac_lidos_r, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_VA0805B_AC_LIDOS_R : VarBasis
            {
                /*"       10 FILLER                     PIC X(7).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "7", "X(7)."), @"");
                /*"    05 AC-LIDOS-ANT                  PIC 9(7) VALUE 0.*/

                public _REDEF_VA0805B_AC_LIDOS_R()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LIDOS_ANT { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 WS-QUOC                       PIC 9(7).*/
            public IntBasis WS_QUOC { get; set; } = new IntBasis(new PIC("9", "7", "9(7)."));
            /*"    05 WS-RESTO                      PIC 9(7).*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "7", "9(7)."));
            /*"    05 WS-POS-1                      PIC 9(3).*/
            public IntBasis WS_POS_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(3)."));
            /*"    05 WS-POS-2                      PIC 9(3).*/
            public IntBasis WS_POS_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(3)."));
            /*"    05 WS-NOME-CPO                   PIC X(20).*/
            public StringBasis WS_NOME_CPO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05 WS-MENS                       PIC X(38).*/
            public StringBasis WS_MENS { get; set; } = new StringBasis(new PIC("X", "38", "X(38)."), @"");
            /*"    05 WS-RC-DATA                    PIC 9(1).*/
            public IntBasis WS_RC_DATA { get; set; } = new IntBasis(new PIC("9", "1", "9(1)."));
            /*"    05 WS-TOT-DEB-CRUZ               PIC 9(13)V99 VALUE 0.*/
            public DoubleBasis WS_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-TOT-DEB-CRUZ-R             REDEFINES       WS-TOT-DEB-CRUZ.*/
            private _REDEF_VA0805B_WS_TOT_DEB_CRUZ_R _ws_tot_deb_cruz_r { get; set; }
            public _REDEF_VA0805B_WS_TOT_DEB_CRUZ_R WS_TOT_DEB_CRUZ_R
            {
                get { _ws_tot_deb_cruz_r = new _REDEF_VA0805B_WS_TOT_DEB_CRUZ_R(); _.Move(WS_TOT_DEB_CRUZ, _ws_tot_deb_cruz_r); VarBasis.RedefinePassValue(WS_TOT_DEB_CRUZ, _ws_tot_deb_cruz_r, WS_TOT_DEB_CRUZ); _ws_tot_deb_cruz_r.ValueChanged += () => { _.Move(_ws_tot_deb_cruz_r, WS_TOT_DEB_CRUZ); }; return _ws_tot_deb_cruz_r; }
                set { VarBasis.RedefinePassValue(value, _ws_tot_deb_cruz_r, WS_TOT_DEB_CRUZ); }
            }  //Redefines
            public class _REDEF_VA0805B_WS_TOT_DEB_CRUZ_R : VarBasis
            {
                /*"       10 FILLER                     PIC X(15).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"    05 WS-TOT-CRED-CRUZ              PIC 9(13)V99 VALUE 0.*/

                public _REDEF_VA0805B_WS_TOT_DEB_CRUZ_R()
                {
                    FILLER_8.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WS_TOT_CRED_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-TOT-CRED-CRUZ-R            REDEFINES       WS-TOT-CRED-CRUZ.*/
            private _REDEF_VA0805B_WS_TOT_CRED_CRUZ_R _ws_tot_cred_cruz_r { get; set; }
            public _REDEF_VA0805B_WS_TOT_CRED_CRUZ_R WS_TOT_CRED_CRUZ_R
            {
                get { _ws_tot_cred_cruz_r = new _REDEF_VA0805B_WS_TOT_CRED_CRUZ_R(); _.Move(WS_TOT_CRED_CRUZ, _ws_tot_cred_cruz_r); VarBasis.RedefinePassValue(WS_TOT_CRED_CRUZ, _ws_tot_cred_cruz_r, WS_TOT_CRED_CRUZ); _ws_tot_cred_cruz_r.ValueChanged += () => { _.Move(_ws_tot_cred_cruz_r, WS_TOT_CRED_CRUZ); }; return _ws_tot_cred_cruz_r; }
                set { VarBasis.RedefinePassValue(value, _ws_tot_cred_cruz_r, WS_TOT_CRED_CRUZ); }
            }  //Redefines
            public class _REDEF_VA0805B_WS_TOT_CRED_CRUZ_R : VarBasis
            {
                /*"       10 FILLER                     PIC X(15).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"    05 WS-CONTA-INT                  PIC 9(16) VALUE ZEROS.*/

                public _REDEF_VA0805B_WS_TOT_CRED_CRUZ_R()
                {
                    FILLER_9.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CONTA_INT { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"));
            /*"    05 WS-CONTA-INT-R                REDEFINES       WS-CONTA-INT.*/
            private _REDEF_VA0805B_WS_CONTA_INT_R _ws_conta_int_r { get; set; }
            public _REDEF_VA0805B_WS_CONTA_INT_R WS_CONTA_INT_R
            {
                get { _ws_conta_int_r = new _REDEF_VA0805B_WS_CONTA_INT_R(); _.Move(WS_CONTA_INT, _ws_conta_int_r); VarBasis.RedefinePassValue(WS_CONTA_INT, _ws_conta_int_r, WS_CONTA_INT); _ws_conta_int_r.ValueChanged += () => { _.Move(_ws_conta_int_r, WS_CONTA_INT); }; return _ws_conta_int_r; }
                set { VarBasis.RedefinePassValue(value, _ws_conta_int_r, WS_CONTA_INT); }
            }  //Redefines
            public class _REDEF_VA0805B_WS_CONTA_INT_R : VarBasis
            {
                /*"       10 WS-OPERACAO-INT            PIC 9(04).*/
                public IntBasis WS_OPERACAO_INT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 WS-NRCONTA-INT             PIC 9(12).*/
                public IntBasis WS_NRCONTA_INT { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                /*"    05      WS-CTPAG                 PIC  9(007)    VALUE 0.*/

                public _REDEF_VA0805B_WS_CONTA_INT_R()
                {
                    WS_OPERACAO_INT.ValueChanged += OnValueChanged;
                    WS_NRCONTA_INT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CTPAG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05      WS-CTPAG1                PIC  9(007)    VALUE 0.*/
            public IntBasis WS_CTPAG1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05      WS-CTLIN                 PIC  9(007)    VALUE 90.*/
            public IntBasis WS_CTLIN { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"), 90);
            /*"    05      WS-CTLINHA               PIC  9(007)    VALUE 90.*/
            public IntBasis WS_CTLINHA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"), 90);
            /*"    05      WS-VAL-OPERACAO          PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis WS_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05      WS-VAL-OPERACAO-R        REDEFINES            WS-VAL-OPERACAO.*/
            private _REDEF_VA0805B_WS_VAL_OPERACAO_R _ws_val_operacao_r { get; set; }
            public _REDEF_VA0805B_WS_VAL_OPERACAO_R WS_VAL_OPERACAO_R
            {
                get { _ws_val_operacao_r = new _REDEF_VA0805B_WS_VAL_OPERACAO_R(); _.Move(WS_VAL_OPERACAO, _ws_val_operacao_r); VarBasis.RedefinePassValue(WS_VAL_OPERACAO, _ws_val_operacao_r, WS_VAL_OPERACAO); _ws_val_operacao_r.ValueChanged += () => { _.Move(_ws_val_operacao_r, WS_VAL_OPERACAO); }; return _ws_val_operacao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_val_operacao_r, WS_VAL_OPERACAO); }
            }  //Redefines
            public class _REDEF_VA0805B_WS_VAL_OPERACAO_R : VarBasis
            {
                /*"            10 FILLER                PIC X(15).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"    05      AC-LANC-DEB-G            PIC  9(009)    VALUE 0.*/

                public _REDEF_VA0805B_WS_VAL_OPERACAO_R()
                {
                    FILLER_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LANC_DEB_G { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-LANC-CRED-G           PIC  9(009)    VALUE 0.*/
            public IntBasis AC_LANC_CRED_G { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-VAL-DEB-G             PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_VAL_DEB_G { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05      AC-VAL-CRED-G            PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_VAL_CRED_G { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05      AC-LANC-DEB-G-N          PIC  9(009)    VALUE 0.*/
            public IntBasis AC_LANC_DEB_G_N { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-LANC-CRED-G-N         PIC  9(009)    VALUE 0.*/
            public IntBasis AC_LANC_CRED_G_N { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-VAL-DEB-G-N           PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_VAL_DEB_G_N { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05      AC-VAL-CRED-G-N          PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_VAL_CRED_G_N { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05      AC-LANC-DEB              PIC  9(009)    VALUE 0.*/
            public IntBasis AC_LANC_DEB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-LANC-CRED             PIC  9(009)    VALUE 0.*/
            public IntBasis AC_LANC_CRED { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-VAL-DEB               PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_VAL_DEB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05      AC-VAL-CRED              PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_VAL_CRED { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05      AC-LANC-DEB-N            PIC  9(009)    VALUE 0.*/
            public IntBasis AC_LANC_DEB_N { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-LANC-CRED-N           PIC  9(009)    VALUE 0.*/
            public IntBasis AC_LANC_CRED_N { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05      AC-VAL-DEB-N             PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_VAL_DEB_N { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05      AC-VAL-CRED-N            PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_VAL_CRED_N { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05 TABELA-COD-RETORNO.*/
            public VA0805B_TABELA_COD_RETORNO TABELA_COD_RETORNO { get; set; } = new VA0805B_TABELA_COD_RETORNO();
            public class VA0805B_TABELA_COD_RETORNO : VarBasis
            {
                /*"      10 TAB-COD-RETORNO.*/
                public VA0805B_TAB_COD_RETORNO TAB_COD_RETORNO { get; set; } = new VA0805B_TAB_COD_RETORNO();
                public class VA0805B_TAB_COD_RETORNO : VarBasis
                {
                    /*"        15 FILLER PIC X(027) VALUE '00DEBITO EFETUADO          '*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"00DEBITO EFETUADO          ");
                    /*"        15 FILLER PIC X(027) VALUE '01INSUFICIENCIA DE FUNDOS  '*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"01INSUFICIENCIA DE FUNDOS  ");
                    /*"        15 FILLER PIC X(027) VALUE '02CONTA NAO CADASTRADA     '*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"02CONTA NAO CADASTRADA     ");
                    /*"        15 FILLER PIC X(027) VALUE '04OUTRAS RESTRICOES        '*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"04OUTRAS RESTRICOES        ");
                    /*"        15 FILLER PIC X(027) VALUE '10AGENCIA EM REGIME ENCERR '*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"10AGENCIA EM REGIME ENCERR ");
                    /*"        15 FILLER PIC X(027) VALUE '12VALOR INVALIDO           '*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"12VALOR INVALIDO           ");
                    /*"        15 FILLER PIC X(027) VALUE '13DATA LANCAMENTO INVALIDA '*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"13DATA LANCAMENTO INVALIDA ");
                    /*"        15 FILLER PIC X(027) VALUE '14AGENCIA INVALIDA         '*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"14AGENCIA INVALIDA         ");
                    /*"        15 FILLER PIC X(027) VALUE '15DV DA CONTA INVALIDO     '*/
                    public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"15DV DA CONTA INVALIDO     ");
                    /*"        15 FILLER PIC X(027) VALUE '18DATA ANTERIOR PROCESSADA '*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"18DATA ANTERIOR PROCESSADA ");
                    /*"        15 FILLER PIC X(027) VALUE '30SEM CONTRATO             '*/
                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"30SEM CONTRATO             ");
                    /*"        15 FILLER PIC X(027) VALUE '96VALOR ZERADO             '*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"96VALOR ZERADO             ");
                    /*"        15 FILLER PIC X(027) VALUE '97CANCEL. P/LANC NAO ENCONT'*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"97CANCEL. P/LANC NAO ENCONT");
                    /*"        15 FILLER PIC X(027) VALUE '98CANCEL. P/LANC FORA DATA '*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"98CANCEL. P/LANC FORA DATA ");
                    /*"        15 FILLER PIC X(027) VALUE '99AUTORIZ. DEBITO CANCELADA'*/
                    public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"99AUTORIZ. DEBITO CANCELADA");
                    /*"    05 TABELA-COD-RETORNO-R REDEFINES TABELA-COD-RETORNO.*/
                }
            }
            private _REDEF_VA0805B_TABELA_COD_RETORNO_R _tabela_cod_retorno_r { get; set; }
            public _REDEF_VA0805B_TABELA_COD_RETORNO_R TABELA_COD_RETORNO_R
            {
                get { _tabela_cod_retorno_r = new _REDEF_VA0805B_TABELA_COD_RETORNO_R(); _.Move(TABELA_COD_RETORNO, _tabela_cod_retorno_r); VarBasis.RedefinePassValue(TABELA_COD_RETORNO, _tabela_cod_retorno_r, TABELA_COD_RETORNO); _tabela_cod_retorno_r.ValueChanged += () => { _.Move(_tabela_cod_retorno_r, TABELA_COD_RETORNO); }; return _tabela_cod_retorno_r; }
                set { VarBasis.RedefinePassValue(value, _tabela_cod_retorno_r, TABELA_COD_RETORNO); }
            }  //Redefines
            public class _REDEF_VA0805B_TABELA_COD_RETORNO_R : VarBasis
            {
                /*"      10 TAB-COD-RETORNO-R OCCURS 15.*/
                public ListBasis<VA0805B_TAB_COD_RETORNO_R> TAB_COD_RETORNO_R { get; set; } = new ListBasis<VA0805B_TAB_COD_RETORNO_R>(15);
                public class VA0805B_TAB_COD_RETORNO_R : VarBasis
                {
                    /*"        15 TB-COD-RETORNO           PIC  9(002).*/
                    public IntBasis TB_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15 TB-DSC-RETORNO           PIC  X(025).*/
                    public StringBasis TB_DSC_RETORNO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                    /*"    05 LK-DATA.*/

                    public VA0805B_TAB_COD_RETORNO_R()
                    {
                        TB_COD_RETORNO.ValueChanged += OnValueChanged;
                        TB_DSC_RETORNO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA0805B_TABELA_COD_RETORNO_R()
                {
                    TAB_COD_RETORNO_R.ValueChanged += OnValueChanged;
                }

            }
            public VA0805B_LK_DATA LK_DATA { get; set; } = new VA0805B_LK_DATA();
            public class VA0805B_LK_DATA : VarBasis
            {
                /*"       10 LK-DATA-DDMMAA            PIC 9(8).*/
                public IntBasis LK_DATA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "8", "9(8)."));
                /*"       10 LK-DATA-DDMMAA-R          REDEFINES          LK-DATA-DDMMAA.*/
                private _REDEF_VA0805B_LK_DATA_DDMMAA_R _lk_data_ddmmaa_r { get; set; }
                public _REDEF_VA0805B_LK_DATA_DDMMAA_R LK_DATA_DDMMAA_R
                {
                    get { _lk_data_ddmmaa_r = new _REDEF_VA0805B_LK_DATA_DDMMAA_R(); _.Move(LK_DATA_DDMMAA, _lk_data_ddmmaa_r); VarBasis.RedefinePassValue(LK_DATA_DDMMAA, _lk_data_ddmmaa_r, LK_DATA_DDMMAA); _lk_data_ddmmaa_r.ValueChanged += () => { _.Move(_lk_data_ddmmaa_r, LK_DATA_DDMMAA); }; return _lk_data_ddmmaa_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_ddmmaa_r, LK_DATA_DDMMAA); }
                }  //Redefines
                public class _REDEF_VA0805B_LK_DATA_DDMMAA_R : VarBasis
                {
                    /*"          15 LK-DIA                 PIC 9(2).*/
                    public IntBasis LK_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(2)."));
                    /*"          15 LK-MES                 PIC 9(2).*/
                    public IntBasis LK_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(2)."));
                    /*"          15 LK-ANO                 PIC 9(4).*/
                    public IntBasis LK_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"       10 LK-RETURN-CODE            PIC 9(1) VALUE 0.*/

                    public _REDEF_VA0805B_LK_DATA_DDMMAA_R()
                    {
                        LK_DIA.ValueChanged += OnValueChanged;
                        LK_MES.ValueChanged += OnValueChanged;
                        LK_ANO.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("9", "1", "9(1)"));
                /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VA0805B_WABEND WABEND { get; set; } = new VA0805B_WABEND();
            public class VA0805B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0805B  '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0805B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA0805B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0805B_LOCALIZA_ABEND_1();
            public class VA0805B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0805B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0805B_LOCALIZA_ABEND_2();
            public class VA0805B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05      TRACO.*/
            }
            public VA0805B_TRACO TRACO { get; set; } = new VA0805B_TRACO();
            public class VA0805B_TRACO : VarBasis
            {
                /*"      10    FILLER                   PIC  X(001) VALUE     '*'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"      10    FILLER                   PIC  X(130) VALUE ALL '-'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"      10    FILLER                   PIC  X(001) VALUE     '*'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    05      BRANCO.*/
            }
            public VA0805B_BRANCO BRANCO { get; set; } = new VA0805B_BRANCO();
            public class VA0805B_BRANCO : VarBasis
            {
                /*"      10    FILLER                   PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    05      CAB-1.*/
            }
            public VA0805B_CAB_1 CAB_1 { get; set; } = new VA0805B_CAB_1();
            public class VA0805B_CAB_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(002) VALUE '* '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"* ");
                /*"      10    FILLER                   PIC  X(007) VALUE 'VA0805B'*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VA0805B");
                /*"      10    FILLER                   PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"      10    FILLER                   PIC  X(040) VALUE            'SASSE CIA NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SASSE CIA NACIONAL DE SEGUROS GERAIS");
                /*"      10    FILLER                   PIC  X(029) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"      10    FILLER                   PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"      10    CAB1-PAGINA              PIC  ZZZ9.*/
                public IntBasis CAB1_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"      10    FILLER                   PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05      CAB-2.*/
            }
            public VA0805B_CAB_2 CAB_2 { get; set; } = new VA0805B_CAB_2();
            public class VA0805B_CAB_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(002) VALUE '* '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"* ");
                /*"      10    FILLER                   PIC  X(113) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "113", "X(113)"), @"");
                /*"      10    FILLER                   PIC  X(005) VALUE 'DATA '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA ");
                /*"      10    CAB2-DATA                PIC  X(10).*/
                public StringBasis CAB2_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10    FILLER                   PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05      CAB-3.*/
            }
            public VA0805B_CAB_3 CAB_3 { get; set; } = new VA0805B_CAB_3();
            public class VA0805B_CAB_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(002) VALUE '* '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"* ");
                /*"      10    FILLER                   PIC  X(043) VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"      10    FILLER                   PIC  X(042) VALUE            'CONSISTENCIA DA FITA RETORNO CEF - VIDAZUL'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CONSISTENCIA DA FITA RETORNO CEF - VIDAZUL");
                /*"      10    FILLER                   PIC  X(028) VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
                /*"      10    FILLER                   PIC  X(007) VALUE 'HORA '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA ");
                /*"      10    CAB3-HORA                PIC  99.99.99.*/
                public IntBasis CAB3_HORA { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
                /*"      10    FILLER                   PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05 CAB-4.*/
            }
            public VA0805B_CAB_4 CAB_4 { get; set; } = new VA0805B_CAB_4();
            public class VA0805B_CAB_4 : VarBasis
            {
                /*"      10 FILLER            PIC X(9) VALUE 'CONVENIO '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "9", "X(9)"), @"CONVENIO ");
                /*"      10 CAB4-CONVENIO     PIC X(4).*/
                public StringBasis CAB4_CONVENIO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
                /*"      10 FILLER            PIC X(9)  VALUE '   BANCO '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "9", "X(9)"), @"   BANCO ");
                /*"      10 CAB4-BANCO        PIC X(3).*/
                public StringBasis CAB4_BANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
                /*"      10 FILLER            PIC X(1)  VALUE '-'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"-");
                /*"      10 CAB4-NOME-BANCO   PIC X(20).*/
                public StringBasis CAB4_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10 FILLER            PIC X(11) VALUE '   EMPRESA '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"   EMPRESA ");
                /*"      10 CAB4-EMPRESA      PIC X(20).*/
                public StringBasis CAB4_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"    05 CAB-5.*/
            }
            public VA0805B_CAB_5 CAB_5 { get; set; } = new VA0805B_CAB_5();
            public class VA0805B_CAB_5 : VarBasis
            {
                /*"      10 FILLER            PIC X(40) VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10 FILLER            PIC X(05) VALUE 'NSA '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"NSA ");
                /*"      10 CAB5-NSA          PIC X(6).*/
                public StringBasis CAB5_NSA { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
                /*"      10 FILLER            PIC X(11) VALUE '   GERACAO '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"   GERACAO ");
                /*"      10 CAB5-DD-GER       PIC X(02).*/
                public StringBasis CAB5_DD_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"      10 FILLER            PIC X(1)  VALUE '/'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"/");
                /*"      10 CAB5-MM-GER       PIC X(02).*/
                public StringBasis CAB5_MM_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"      10 FILLER            PIC X(1)  VALUE '/'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"/");
                /*"      10 CAB5-AA-GER       PIC X(04).*/
                public StringBasis CAB5_AA_GER { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"      10 FILLER            PIC X(13) VALUE '   V.LAY-OUT '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"   V.LAY-OUT ");
                /*"      10 CAB5-V-LAYOUT     PIC X(02).*/
                public StringBasis CAB5_V_LAYOUT { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"      10 FILLER            PIC X(11) VALUE '   SERVICO '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"   SERVICO ");
                /*"      10 CAB5-SERVICO      PIC X(17).*/
                public StringBasis CAB5_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
                /*"    05 CAB-6.*/
            }
            public VA0805B_CAB_6 CAB_6 { get; set; } = new VA0805B_CAB_6();
            public class VA0805B_CAB_6 : VarBasis
            {
                /*"      10 FILLER PIC X(30) VALUE ' N.REG  1---+---10----+---20--'*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @" N.REG  1---+---10----+---20--");
                /*"      10 FILLER PIC X(30) VALUE '--+---30----+---40----+---50  '*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"--+---30----+---40----+---50  ");
                /*"      10 FILLER PIC X(30) VALUE 'POSICAO/NOME CAMPO    MENSAGEM'*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"POSICAO/NOME CAMPO    MENSAGEM");
                /*"    05 DET-1.*/
            }
            public VA0805B_DET_1 DET_1 { get; set; } = new VA0805B_DET_1();
            public class VA0805B_DET_1 : VarBasis
            {
                /*"      10 DET1-REGISTRO           PIC ZZZZZ9.*/
                public IntBasis DET1_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10 FILLER                  PIC X(2)   VALUE SPACES.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "2", "X(2)"), @"");
                /*"      10 DET1-PARTE-1            PIC X(50).*/
                public StringBasis DET1_PARTE_1 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 DET-2.*/
            }
            public VA0805B_DET_2 DET_2 { get; set; } = new VA0805B_DET_2();
            public class VA0805B_DET_2 : VarBasis
            {
                /*"      10 FILLER                  PIC X(8)   VALUE SPACES.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "8", "X(8)"), @"");
                /*"      10 DET2-PARTE-2            PIC X(50).*/
                public StringBasis DET2_PARTE_2 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 DET-3.*/
            }
            public VA0805B_DET_3 DET_3 { get; set; } = new VA0805B_DET_3();
            public class VA0805B_DET_3 : VarBasis
            {
                /*"      10 FILLER                  PIC X(8)   VALUE SPACES.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "8", "X(8)"), @"");
                /*"      10 DET3-PARTE-3            PIC X(50).*/
                public StringBasis DET3_PARTE_3 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 DET-4.*/
            }
            public VA0805B_DET_4 DET_4 { get; set; } = new VA0805B_DET_4();
            public class VA0805B_DET_4 : VarBasis
            {
                /*"      10 FILLER                  PIC X(60)  VALUE SPACES.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
                /*"      10 DET4-POS-1              PIC 999.*/
                public IntBasis DET4_POS_1 { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"      10 FILLER                  PIC X(1)   VALUE '/'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"/");
                /*"      10 DET4-POS-2              PIC 999.*/
                public IntBasis DET4_POS_2 { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"      10 FILLER                  PIC X(15)  VALUE SPACES.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"      10 DET4-MENS               PIC X(50).*/
                public StringBasis DET4_MENS { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 DET-5.*/
            }
            public VA0805B_DET_5 DET_5 { get; set; } = new VA0805B_DET_5();
            public class VA0805B_DET_5 : VarBasis
            {
                /*"      10 FILLER                  PIC X(60)  VALUE SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
                /*"      10 DET5-NOME-CPO           PIC X(20).*/
                public StringBasis DET5_NOME_CPO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"    05      LC01.*/
            }
            public VA0805B_LC01 LC01 { get; set; } = new VA0805B_LC01();
            public class VA0805B_LC01 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(002) VALUE '*'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"*");
                /*"      10    FILLER                 PIC  X(009) VALUE 'VA0805B.2'*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"VA0805B.2");
                /*"      10    FILLER                   PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"      10    FILLER PIC X(27) VALUE 'SASSE CIA NACIONAL DE SEGUR'*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"SASSE CIA NACIONAL DE SEGUR");
                /*"      10    FILLER PIC X(13) VALUE 'OS GERAIS'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"OS GERAIS");
                /*"      10    FILLER                   PIC  X(027) VALUE SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"      10    FILLER                   PIC  X(011) VALUE            'PAGINA'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"      10    LC01-PAGINA              PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"      10    FILLER                   PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05      LC02.*/
            }
            public VA0805B_LC02 LC02 { get; set; } = new VA0805B_LC02();
            public class VA0805B_LC02 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(2)   VALUE '*'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "2", "X(2)"), @"*");
                /*"      10    FILLER                   PIC  X(005) VALUE 'DATA '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA ");
                /*"      10    LC02-DATA                PIC  X(010).*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      10    FILLER                   PIC  X(014) VALUE SPACES.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10    LC02-RELAT               PIC  X(075).*/
                public StringBasis LC02_RELAT { get; set; } = new StringBasis(new PIC("X", "75", "X(075)."), @"");
                /*"      10    FILLER                   PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10    FILLER                   PIC  X(007) VALUE 'HORA '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA ");
                /*"      10    LC02-HORA                PIC  99.99.99.*/
                public IntBasis LC02_HORA { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
                /*"      10    FILLER                   PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05      LC03.*/
            }
            public VA0805B_LC03 LC03 { get; set; } = new VA0805B_LC03();
            public class VA0805B_LC03 : VarBasis
            {
                /*"      10    FILLER            PIC  X(002) VALUE '*'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"*");
                /*"      10    FILLER            PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10    FILLER            PIC  X(012) VALUE SPACES.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"      10    FILLER            PIC  X(009) VALUE 'CONVENIO '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CONVENIO ");
                /*"      10    LC03-CONVENIO     PIC  X(004).*/
                public StringBasis LC03_CONVENIO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"      10    FILLER            PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10    FILLER            PIC  X(032) VALUE      ' LANCAMENTOS RECEBIDOS DA CEF   '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @" LANCAMENTOS RECEBIDOS DA CEF   ");
                /*"      10    FILLER            PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10    FILLER            PIC  X(010) VALUE 'NSA SUCOV '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"NSA SUCOV ");
                /*"      10    LC03-NSA          PIC  X(006).*/
                public StringBasis LC03_NSA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"      10    FILLER            PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10    FILLER            PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    05      LC04.*/
            }
            public VA0805B_LC04 LC04 { get; set; } = new VA0805B_LC04();
            public class VA0805B_LC04 : VarBasis
            {
                /*"      10    FILLER            PIC X(002) VALUE '*'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"*");
                /*"      10    FILLER            PIC X(016) VALUE 'GERACAO DA FITA'*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"GERACAO DA FITA");
                /*"      10    LC04-DATA-GER     PIC X(010).*/
                public StringBasis LC04_DATA_GER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      10    FILLER            PIC X(033) VALUE SPACES.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"      10    LC04-SERVICO      PIC X(021) VALUE SPACES.*/
                public StringBasis LC04_SERVICO { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"      10    FILLER            PIC X(027) VALUE SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"      10    FILLER            PIC X(021) VALUE            'CR/DB EM   /   /     '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"CR/DB EM   /   /     ");
                /*"      10    FILLER            PIC X(002) VALUE ' *'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05 LC05.*/
            }
            public VA0805B_LC05 LC05 { get; set; } = new VA0805B_LC05();
            public class VA0805B_LC05 : VarBasis
            {
                /*"       10  FILLER            PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"       10  FILLER            PIC  X(043) VALUE 'TITULAR'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"TITULAR");
                /*"       10  FILLER            PIC  X(020) VALUE           'AGEN/OPE/ N.CONTA/DV'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"AGEN/OPE/ N.CONTA/DV");
                /*"       10  FILLER            PIC  X(019) VALUE           '              VALOR'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"              VALOR");
                /*"       10  FILLER            PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"       10  FILLER            PIC  X(015) VALUE 'MENSAGEM'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"MENSAGEM");
                /*"    05 LC5A.*/
            }
            public VA0805B_LC5A LC5A { get; set; } = new VA0805B_LC5A();
            public class VA0805B_LC5A : VarBasis
            {
                /*"      10 FILLER PIC X(08) VALUE 'PRODUTO '.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PRODUTO ");
                /*"      10 FILLER PIC X(30) VALUE '     ----- DEB EFETUADOS -----'*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"     ----- DEB EFETUADOS -----");
                /*"      10 FILLER PIC X(30) VALUE '-  ----- CRED EFETUADOS ------'*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"-  ----- CRED EFETUADOS ------");
                /*"      10 FILLER PIC X(30) VALUE '--  ---- DEB NAO EFETUADOS ---'*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"--  ---- DEB NAO EFETUADOS ---");
                /*"      10 FILLER PIC X(30) VALUE '---  ---- CRED NAO EFETUADOS -'*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"---  ---- CRED NAO EFETUADOS -");
                /*"      10 FILLER PIC X(04) VALUE '----'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"----");
                /*"    05 LC06.*/
            }
            public VA0805B_LC06 LC06 { get; set; } = new VA0805B_LC06();
            public class VA0805B_LC06 : VarBasis
            {
                /*"      10 FILLER PIC X(08) VALUE SPACES.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"      10 FILLER PIC X(30) VALUE '     ----- DEB EFETUADOS -----'*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"     ----- DEB EFETUADOS -----");
                /*"      10 FILLER PIC X(30) VALUE '-  ----- CRED EFETUADOS ------'*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"-  ----- CRED EFETUADOS ------");
                /*"      10 FILLER PIC X(30) VALUE '--  ---- DEB NAO EFETUADOS ---'*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"--  ---- DEB NAO EFETUADOS ---");
                /*"      10 FILLER PIC X(30) VALUE '---  ---- CRED NAO EFETUADOS -'*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"---  ---- CRED NAO EFETUADOS -");
                /*"      10 FILLER PIC X(04) VALUE '----'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"----");
                /*"    05 LD01.*/
            }
            public VA0805B_LD01 LD01 { get; set; } = new VA0805B_LD01();
            public class VA0805B_LD01 : VarBasis
            {
                /*"      10 LD01-FILLER            PIC X(002) VALUE SPACES.*/
                public StringBasis LD01_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10 LD01-CODPRODAZ         PIC X(003).*/
                public StringBasis LD01_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LD01-FILLER            PIC X(003) VALUE SPACES.*/
                public StringBasis LD01_FILLER_0 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10 LD01-LANC-DEB          PIC ZZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_LANC_DEB { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"      10 LD01-FILLER            PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10 LD01-VAL-DEB           PIC Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VAL_DEB { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10 LD01-LANC-CRED         PIC ZZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_LANC_CRED { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"      10 LD01-FILLER            PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10 LD01-VAL-CRED          PIC Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VAL_CRED { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10 LD01-LANC-DEB-N        PIC ZZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_LANC_DEB_N { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"      10 LD01-FILLER            PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_FILLER_3 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10 LD01-VAL-DEB-N         PIC Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VAL_DEB_N { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10 LD01-LANC-CRED-N       PIC ZZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_LANC_CRED_N { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"      10 LD01-FILLER            PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_FILLER_4 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10 LD01-VAL-CRED-N        PIC Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VAL_CRED_N { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05 LT01.*/
            }
            public VA0805B_LT01 LT01 { get; set; } = new VA0805B_LT01();
            public class VA0805B_LT01 : VarBasis
            {
                /*"      10 LT01-FILLER            PIC X(008) VALUE SPACES.*/
                public StringBasis LT01_FILLER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"      10 LT01-LANC-DEB          PIC ZZZ.ZZZ.ZZ9.*/
                public IntBasis LT01_LANC_DEB { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"      10 LT01-VAL-DEB           PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VAL_DEB { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10 LT01-LANC-CRED         PIC ZZZ.ZZZ.ZZ9.*/
                public IntBasis LT01_LANC_CRED { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"      10 LT01-VAL-CRED          PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VAL_CRED { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10 LT01-LANC-DEB-N        PIC ZZZ.ZZZ.ZZ9.*/
                public IntBasis LT01_LANC_DEB_N { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"      10 LT01-VAL-DEB-N         PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VAL_DEB_N { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10 LT01-LANC-CRED-N       PIC ZZZ.ZZZ.ZZ9.*/
                public IntBasis LT01_LANC_CRED_N { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"      10 LT01-VAL-CRED-N        PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VAL_CRED_N { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05      ASTERISCO.*/
            }
            public VA0805B_ASTERISCO ASTERISCO { get; set; } = new VA0805B_ASTERISCO();
            public class VA0805B_ASTERISCO : VarBasis
            {
                /*"      10    FILLER                   PIC  X(132) VALUE ALL '*'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"01  WS-DATE.*/
            }
        }
        public VA0805B_WS_DATE WS_DATE { get; set; } = new VA0805B_WS_DATE();
        public class VA0805B_WS_DATE : VarBasis
        {
            /*"    05 WS-AA-DATE                    PIC 9(04).*/
            public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                        PIC X(01).*/
            public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 WS-MM-DATE                    PIC 9(02).*/
            public IntBasis WS_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 FILLER                        PIC X(01).*/
            public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 WS-DD-DATE                    PIC 9(02).*/
            public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-TIME.*/
        }
        public VA0805B_WS_TIME WS_TIME { get; set; } = new VA0805B_WS_TIME();
        public class VA0805B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  ON-INTERVAL                      PIC 9(06) VALUE 5000.*/
        }
        public IntBasis ON_INTERVAL { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"), 5000);
        /*"01  ON-COUNTER                       PIC 9(06) VALUE 1.*/
        public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"), 1);

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVA0805B_FILE_NAME_P, string RETCEF_FILE_NAME_P, string RETOPT_FILE_NAME_P, string RETDEB_FILE_NAME_P, string RETCRE_FILE_NAME_P, string SVA0805B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVA0805B.SetFile(RVA0805B_FILE_NAME_P);
                RETCEF.SetFile(RETCEF_FILE_NAME_P);
                RETOPT.SetFile(RETOPT_FILE_NAME_P);
                RETDEB.SetFile(RETDEB_FILE_NAME_P);
                RETCRE.SetFile(RETCRE_FILE_NAME_P);
                SVA0805B.SetFile(SVA0805B_FILE_NAME_P);

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
            /*" -904- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -907- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -910- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -912- PERFORM 0001-INICIO-PROCESSO. */

            M_0001_INICIO_PROCESSO(true);

        }

        [StopWatch]
        /*" M-0001-INICIO-PROCESSO */
        private void M_0001_INICIO_PROCESSO(bool isPerform = false)
        {
            /*" -918- MOVE '0001-INICIO-PROCESSO' TO PARAGRAFO. */
            _.Move("0001-INICIO-PROCESSO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -920- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -921- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -922- DISPLAY 'VA0805B - V.05 - INCIDENTE 513.798 - 13/07/2023' */
            _.Display($"VA0805B - V.05 - INCIDENTE 513.798 - 13/07/2023");

            /*" -923- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -924- DISPLAY '  ' */
            _.Display($"  ");

            /*" -930- DISPLAY '  ' */
            _.Display($"  ");

            /*" -938- PERFORM M_0001_INICIO_PROCESSO_DB_SELECT_1 */

            M_0001_INICIO_PROCESSO_DB_SELECT_1();

            /*" -941- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -942- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -943- DISPLAY 'SISTEMA VIDAZUL NAO CADASTRADO' */
                    _.Display($"SISTEMA VIDAZUL NAO CADASTRADO");

                    /*" -944- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -945- ELSE */
                }
                else
                {


                    /*" -946- DISPLAY 'PROBLEMAS ACESSO V1SISTEMA' */
                    _.Display($"PROBLEMAS ACESSO V1SISTEMA");

                    /*" -948- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -949- MOVE V1SIST-DTCURRENT TO WS-DATE */
            _.Move(V1SIST_DTCURRENT, WS_DATE);

            /*" -950- MOVE WS-DD-DATE TO DIA-AUX. */
            _.Move(WS_DATE.WS_DD_DATE, WORK_AREA.DATA_AUX.DIA_AUX);

            /*" -951- MOVE WS-MM-DATE TO MES-AUX. */
            _.Move(WS_DATE.WS_MM_DATE, WORK_AREA.DATA_AUX.MES_AUX);

            /*" -952- MOVE WS-AA-DATE TO ANO-AUX. */
            _.Move(WS_DATE.WS_AA_DATE, WORK_AREA.DATA_AUX.ANO_AUX);

            /*" -953- MOVE DATA-AUX TO CAB2-DATA. */
            _.Move(WORK_AREA.DATA_AUX, WORK_AREA.CAB_2.CAB2_DATA);

            /*" -955- MOVE DATA-AUX TO LC02-DATA. */
            _.Move(WORK_AREA.DATA_AUX, WORK_AREA.LC02.LC02_DATA);

            /*" -956- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -957- MOVE WS-TIME-N TO CAB3-HORA. */
            _.Move(WS_TIME.WS_TIME_N, WORK_AREA.CAB_3.CAB3_HORA);

            /*" -959- MOVE WS-TIME-N TO LC02-HORA. */
            _.Move(WS_TIME.WS_TIME_N, WORK_AREA.LC02.LC02_HORA);

            /*" -961- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -966- SORT SVA0805B ON ASCENDING KEY SVA-DEB-CRED SVA-CODPRODAZ INPUT PROCEDURE 0002-00-PROC-FITACEF THRU 0002-FIM OUTPUT PROCEDURE 7000-GERA-ESPELHO THRU 7000-FIM . */
            SORT_RETURN.Value = SVA0805B.Sort("SVA-DEB-CRED,SVA-CODPRODAZ", () => M_0002_00_PROC_FITACEF(true), () => M_7000_GERA_ESPELHO(true));

            /*" -969- IF SORT-RETURN NOT = ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -970- DISPLAY '*** VA0805B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VA0805B *** PROBLEMAS NO SORT ");

                /*" -971- DISPLAY '*** VA0805B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VA0805B *** SORT-RETURN = {SORT_RETURN}");

                /*" -973- GO TO 0001-FIM-ANORMAL */

                M_0001_FIM_ANORMAL(); //GOTO
                return;

                /*" -975- END-IF. */
            }


            /*" -976- IF RETURN-CODE = 888 */

            if (RETURN_CODE == 888)
            {

                /*" -977- DISPLAY '*** VA0805B *** MOVIMENTO REJEITADO ' */
                _.Display($"*** VA0805B *** MOVIMENTO REJEITADO ");

                /*" -978- DISPLAY '*** VA0805B *** FITA JAH PROCESSADA ' */
                _.Display($"*** VA0805B *** FITA JAH PROCESSADA ");

                /*" -979- GO TO 0001-INT */

                M_0001_INT(); //GOTO
                return;

                /*" -981- END-IF. */
            }


            /*" -982- IF WS-ERRO = 1 */

            if (WORK_AREA.WS_ERRO == 1)
            {

                /*" -983- DISPLAY ' ' */
                _.Display($" ");

                /*" -984- DISPLAY '*** VA0805B *** MOVIMENTO REJEITADO' */
                _.Display($"*** VA0805B *** MOVIMENTO REJEITADO");

                /*" -985- DISPLAY '*** VA0805B *** FITA COM ERROS DE CONSISTENCIA' */
                _.Display($"*** VA0805B *** FITA COM ERROS DE CONSISTENCIA");

                /*" -986- GO TO 0001-FIM-ANORMAL */

                M_0001_FIM_ANORMAL(); //GOTO
                return;

                /*" -988- END-IF. */
            }


            /*" -988- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -991- CLOSE RETCEF. */
            RETCEF.Close();

            /*" -992- CLOSE RETOPT. */
            RETOPT.Close();

            /*" -993- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -994- CLOSE RETCRE. */
            RETCRE.Close();

            /*" -996- CLOSE RVA0805B. */
            RVA0805B.Close();

            /*" -997- DISPLAY ' ' */
            _.Display($" ");

            /*" -998- DISPLAY '*** VA0805B *** MOVIMENTO ACEITO' */
            _.Display($"*** VA0805B *** MOVIMENTO ACEITO");

            /*" -1000- DISPLAY '*** VA0805B *** TERMINO NORMAL.' */
            _.Display($"*** VA0805B *** TERMINO NORMAL.");

            /*" -1002- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1002- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0001-INICIO-PROCESSO-DB-SELECT-1 */
        public void M_0001_INICIO_PROCESSO_DB_SELECT_1()
        {
            /*" -938- EXEC SQL SELECT DTMOVABE, CURRENT DATE, CURRENT DATE - 18 MONTHS INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT, :V1SIST-DTCURRENT-18 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var m_0001_INICIO_PROCESSO_DB_SELECT_1_Query1 = new M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1.Execute(m_0001_INICIO_PROCESSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
                _.Move(executed_1.V1SIST_DTCURRENT_18, V1SIST_DTCURRENT_18);
            }


        }

        [StopWatch]
        /*" M-0001-FIM-ANORMAL */
        private void M_0001_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -1006- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1009- CLOSE RETCEF. */
            RETCEF.Close();

            /*" -1010- CLOSE RETOPT. */
            RETOPT.Close();

            /*" -1011- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -1012- CLOSE RETCRE. */
            RETCRE.Close();

            /*" -1014- CLOSE RVA0805B. */
            RVA0805B.Close();

            /*" -1014- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

        }

        [StopWatch]
        /*" M-0001-INT */
        private void M_0001_INT(bool isPerform = false)
        {
            /*" -1017- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0002-00-PROC-FITACEF */
        private void M_0002_00_PROC_FITACEF(bool isPerform = false)
        {
            /*" -1023- MOVE '0002-00-PROC-FITACEF' TO PARAGRAFO. */
            _.Move("0002-00-PROC-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1025- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1026- OPEN INPUT RETCEF. */
            RETCEF.Open(RETCEF_RECORD);

            /*" -1027- OPEN OUTPUT RETOPT. */
            RETOPT.Open(RETOPT_RECORD);

            /*" -1028- OPEN OUTPUT RETDEB. */
            RETDEB.Open(RETDEB_RECORD);

            /*" -1029- OPEN OUTPUT RETCRE. */
            RETCRE.Open(RETCRE_RECORD);

            /*" -1031- OPEN OUTPUT RVA0805B. */
            RVA0805B.Open(REG_IMPRESSAO);

            /*" -1032- READ RETCEF AT END */
            try
            {
                RETCEF.Read(() =>
                {

                    /*" -1033- DISPLAY '*** VA0805B *** MOVIMENTO RETORNO VAZIO' */
                    _.Display($"*** VA0805B *** MOVIMENTO RETORNO VAZIO");

                    /*" -1034- MOVE SPACES TO RETCEF-RECORD */
                    _.Move("", RETCEF_RECORD);

                    /*" -1036- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETCEF.Value, RETCEF_RECORD);
                _.Move(RETCEF.Value, RETCEF_PARTES);
                _.Move(RETCEF.Value, RET_HEADER);
                _.Move(RETCEF.Value, RET_CADASTRAMENTO);
                _.Move(RETCEF.Value, RET_LANCAMENTO);
                _.Move(RETCEF.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1037- IF RA-COD-REG NOT EQUAL 'A' */

            if (RET_HEADER.RA_COD_REG != "A")
            {

                /*" -1039- DISPLAY '*** VA0805B *** FITA SEM HEADER' . */
                _.Display($"*** VA0805B *** FITA SEM HEADER");
            }


            /*" -1041- MOVE RA-NSA TO WS-NSA-X. */
            _.Move(RET_HEADER.RA_NSA, WORK_AREA.WS_NSA_X);

            /*" -1043- PERFORM 0010-CONSISTE-HEADER THRU 0010-FIM. */

            M_0010_CONSISTE_HEADER(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -1044- IF WS-ERRO = 1 */

            if (WORK_AREA.WS_ERRO == 1)
            {

                /*" -1045- DISPLAY '*** VA0805B *** HEADER INCONSISTENTE' */
                _.Display($"*** VA0805B *** HEADER INCONSISTENTE");

                /*" -1046- IF RETURN-CODE = 888 */

                if (RETURN_CODE == 888)
                {

                    /*" -1047- MOVE 9 TO RETURN-CODE */
                    _.Move(9, RETURN_CODE);

                    /*" -1049- GO TO 0002-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0002_FIM*/ //GOTO
                    return;
                }

            }


            /*" -1051- MOVE RA-DATA-GERACAO TO WS-DATA-INV */
            _.Move(RET_HEADER.RA_DATA_GERACAO, WORK_AREA.WS_DATA_INV);

            /*" -1052- MOVE WS-ANO-INV TO ANO-SQL */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -1053- MOVE WS-MES-INV TO MES-SQL */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -1054- MOVE WS-DIA-INV TO DIA-SQL */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1056- MOVE DATA-SQL TO FITCEF-DTRET. */
            _.Move(WORK_AREA.DATA_SQL, FITCEF_DTRET);

            /*" -1057- WRITE RETOPT-RECORD FROM RETCEF-RECORD. */
            _.Move(RETCEF_RECORD.GetMoveValues(), RETOPT_RECORD);

            RETOPT.Write(RETOPT_RECORD.GetMoveValues().ToString());

            /*" -1058- WRITE RETDEB-RECORD FROM RETCEF-RECORD. */
            _.Move(RETCEF_RECORD.GetMoveValues(), RETDEB_RECORD);

            RETDEB.Write(RETDEB_RECORD.GetMoveValues().ToString());

            /*" -1061- WRITE RETCRE-RECORD FROM RETCEF-RECORD. */
            _.Move(RETCEF_RECORD.GetMoveValues(), RETCRE_RECORD);

            RETCRE.Write(RETCRE_RECORD.GetMoveValues().ToString());

            /*" -1062- IF RA-NSA NOT NUMERIC */

            if (!RET_HEADER.RA_NSA.IsNumeric())
            {

                /*" -1064- MOVE ZEROES TO WRA-NSA-R. */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRA_NSA_R);
            }


            /*" -1065- IF WRA-COD-CONVENIO = 6001 */

            if (WORK_AREA.WORK_AREA_2.WRA_COD_CONVENIO_I.WRA_COD_CONVENIO == 6001)
            {

                /*" -1067- MOVE 'DESCONTO MENSAL SEGURO - ANTIGO VIDAZUL P.F.' TO LC02-RELAT */
                _.Move("DESCONTO MENSAL SEGURO - ANTIGO VIDAZUL P.F.", WORK_AREA.LC02.LC02_RELAT);

                /*" -1069- GO TO 0002-10-INT. */

                M_0002_10_INT(); //GOTO
                return;
            }


            /*" -1075- MOVE WRA-COD-CONVENIO TO WHOST-COD-CONVENIO. */
            _.Move(WORK_AREA.WORK_AREA_2.WRA_COD_CONVENIO_I.WRA_COD_CONVENIO, WHOST_COD_CONVENIO);

            /*" -1081- PERFORM M_0002_00_PROC_FITACEF_DB_SELECT_1 */

            M_0002_00_PROC_FITACEF_DB_SELECT_1();

            /*" -1084- IF SQLCODE = ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1085- MOVE WHOST-NOME-CONVENIO TO LC02-RELAT */
                _.Move(WHOST_NOME_CONVENIO, WORK_AREA.LC02.LC02_RELAT);

                /*" -1086- ELSE */
            }
            else
            {


                /*" -1087- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1088- MOVE 'CONVENIO NAO CADASTRADO' TO LC02-RELAT */
                    _.Move("CONVENIO NAO CADASTRADO", WORK_AREA.LC02.LC02_RELAT);

                    /*" -1089- ELSE */
                }
                else
                {


                    /*" -1089- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0002-00-PROC-FITACEF-DB-SELECT-1 */
        public void M_0002_00_PROC_FITACEF_DB_SELECT_1()
        {
            /*" -1081- EXEC SQL SELECT NOME_CONVENIO INTO :WHOST-NOME-CONVENIO FROM SEGUROS.V0CONVSUCOV WHERE COD_CONVENIO = :WHOST-COD-CONVENIO WITH UR END-EXEC. */

            var m_0002_00_PROC_FITACEF_DB_SELECT_1_Query1 = new M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1()
            {
                WHOST_COD_CONVENIO = WHOST_COD_CONVENIO.ToString(),
            };

            var executed_1 = M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1.Execute(m_0002_00_PROC_FITACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NOME_CONVENIO, WHOST_NOME_CONVENIO);
            }


        }

        [StopWatch]
        /*" M-0002-10-INT */
        private void M_0002_10_INT(bool isPerform = false)
        {
            /*" -1094- READ RETCEF AT END */
            try
            {
                RETCEF.Read(() =>
                {

                    /*" -1095- DISPLAY '*** VA0805B *** FITA SEM MOVIMENTO ' */
                    _.Display($"*** VA0805B *** FITA SEM MOVIMENTO ");

                    /*" -1097- MOVE SPACES TO RETCEF-RECORD. */
                    _.Move("", RETCEF_RECORD);
                });

                _.Move(RETCEF.Value, RETCEF_RECORD);
                _.Move(RETCEF.Value, RETCEF_PARTES);
                _.Move(RETCEF.Value, RET_HEADER);
                _.Move(RETCEF.Value, RET_CADASTRAMENTO);
                _.Move(RETCEF.Value, RET_LANCAMENTO);
                _.Move(RETCEF.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1101- PERFORM 0020-PROCESSA THRU 0020-FIM UNTIL WS-EOF = 1 OR RA-COD-REG = 'Z' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADER.RA_COD_REG == "Z"))
            {

                M_0020_PROCESSA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

            }

            /*" -1102- IF RZ-QTDE-REGISTROS = '000002' */

            if (RET_TRAILLER.RZ_QTDE_REGISTROS == "000002")
            {

                /*" -1104- DISPLAY '*** VA0805B *** ARQUIVO COM MOVIMENTO VAZIO.' */
                _.Display($"*** VA0805B *** ARQUIVO COM MOVIMENTO VAZIO.");

                /*" -1105- DISPLAY RZ-QTDE-REGISTROS */
                _.Display(RET_TRAILLER.RZ_QTDE_REGISTROS);

                /*" -1106- PERFORM 5600-MOVIMENTO-VAZIO THRU 5600-EXIT */

                M_5600_MOVIMENTO_VAZIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5600_EXIT*/


                /*" -1106- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1110- GO TO 0002-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0002_FIM*/ //GOTO
                return;
            }


            /*" -1112- PERFORM 0900-CONSISTE-TRAILLER THRU 0900-FIM. */

            M_0900_CONSISTE_TRAILLER(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_FIM*/


            /*" -1113- IF RZ-QTDE-REGISTROS = 0 */

            if (RET_TRAILLER.RZ_QTDE_REGISTROS == 0)
            {

                /*" -1114- DISPLAY 'MOVIMENTO VAZIO ' . */
                _.Display($"MOVIMENTO VAZIO ");
            }


            /*" -1116- PERFORM 5600-MOVIMENTO-VAZIO THRU 5600-EXIT. */

            M_5600_MOVIMENTO_VAZIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5600_EXIT*/


            /*" -1117- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1118- DISPLAY '*** VA0805B *** REGISTROS PROCESSADOS ' AC-LIDOS. */
            _.Display($"*** VA0805B *** REGISTROS PROCESSADOS {WORK_AREA.AC_LIDOS}");

            /*" -1119- DISPLAY '*** VA0805B *** VALOR TOTAL ACUMULADO ' WS-VAL-OPERACAO. */
            _.Display($"*** VA0805B *** VALOR TOTAL ACUMULADO {WORK_AREA.WS_VAL_OPERACAO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0002_FIM*/

        [StopWatch]
        /*" M-0010-CONSISTE-HEADER */
        private void M_0010_CONSISTE_HEADER(bool isPerform = false)
        {
            /*" -1126- MOVE '0010-CONSISTE-HEADER' TO PARAGRAFO. */
            _.Move("0010-CONSISTE-HEADER", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1128- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1129- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1130- DISPLAY 'CONVENIO     ' RA-COD-CONVENIO. */
            _.Display($"CONVENIO     {RET_HEADER.RA_COD_CONVENIO}");

            /*" -1131- DISPLAY 'EMPRESA      ' RA-NOME-EMPRESA. */
            _.Display($"EMPRESA      {RET_HEADER.RA_NOME_EMPRESA}");

            /*" -1132- DISPLAY 'NSA CEF      ' RA-NSA. */
            _.Display($"NSA CEF      {RET_HEADER.RA_NSA}");

            /*" -1133- DISPLAY 'DATA GERACAO ' RA-DATA-GERACAO. */
            _.Display($"DATA GERACAO {RET_HEADER.RA_DATA_GERACAO}");

            /*" -1135- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1138- MOVE RA-COD-CONVENIO TO CAB4-CONVENIO LC03-CONVENIO WRA-COD-CONVENIO-R. */
            _.Move(RET_HEADER.RA_COD_CONVENIO, WORK_AREA.CAB_4.CAB4_CONVENIO, WORK_AREA.LC03.LC03_CONVENIO, WORK_AREA.WORK_AREA_1.WRA_COD_CONVENIO_R);

            /*" -1139- MOVE RA-SERVICO TO LC04-SERVICO */
            _.Move(RET_HEADER.RA_SERVICO, WORK_AREA.LC04.LC04_SERVICO);

            /*" -1140- MOVE RA-COD-BANCO TO CAB4-BANCO. */
            _.Move(RET_HEADER.RA_COD_BANCO, WORK_AREA.CAB_4.CAB4_BANCO);

            /*" -1141- MOVE RA-NOME-BANCO TO CAB4-NOME-BANCO. */
            _.Move(RET_HEADER.RA_NOME_BANCO, WORK_AREA.CAB_4.CAB4_NOME_BANCO);

            /*" -1142- MOVE RA-NOME-EMPRESA TO CAB4-EMPRESA. */
            _.Move(RET_HEADER.RA_NOME_EMPRESA, WORK_AREA.CAB_4.CAB4_EMPRESA);

            /*" -1144- MOVE RA-NSA TO CAB5-NSA LC03-NSA. */
            _.Move(RET_HEADER.RA_NSA, WORK_AREA.CAB_5.CAB5_NSA, WORK_AREA.LC03.LC03_NSA);

            /*" -1145- MOVE RA-DATA-GERACAO TO WS-DATA-INV. */
            _.Move(RET_HEADER.RA_DATA_GERACAO, WORK_AREA.WS_DATA_INV);

            /*" -1147- MOVE WS-DIA-INV TO CAB5-DD-GER DIA-AUX */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.CAB_5.CAB5_DD_GER, WORK_AREA.DATA_AUX.DIA_AUX);

            /*" -1150- MOVE WS-MES-INV TO CAB5-MM-GER MES-AUX */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.CAB_5.CAB5_MM_GER, WORK_AREA.DATA_AUX.MES_AUX);

            /*" -1153- MOVE WS-ANO-INV TO CAB5-AA-GER ANO-AUX */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.CAB_5.CAB5_AA_GER, WORK_AREA.DATA_AUX.ANO_AUX);

            /*" -1154- MOVE DATA-AUX TO LC04-DATA-GER */
            _.Move(WORK_AREA.DATA_AUX, WORK_AREA.LC04.LC04_DATA_GER);

            /*" -1155- MOVE RA-VERSAO-LAYOUT TO CAB5-V-LAYOUT. */
            _.Move(RET_HEADER.RA_VERSAO_LAYOUT, WORK_AREA.CAB_5.CAB5_V_LAYOUT);

            /*" -1157- MOVE RA-SERVICO TO CAB5-SERVICO. */
            _.Move(RET_HEADER.RA_SERVICO, WORK_AREA.CAB_5.CAB5_SERVICO);

            /*" -1158- IF RA-COD-REMESSA NOT EQUAL '2' */

            if (RET_HEADER.RA_COD_REMESSA != "2")
            {

                /*" -1159- MOVE 'COD REMESSA DEVE SER 2                ' TO WS-MENS */
                _.Move("COD REMESSA DEVE SER 2                ", WORK_AREA.WS_MENS);

                /*" -1161- MOVE 002 TO WS-POS-1 WS-POS-2 */
                _.Move(002, WORK_AREA.WS_POS_1, WORK_AREA.WS_POS_2);

                /*" -1162- MOVE 'CODIGO DE REMESSA   ' TO WS-NOME-CPO */
                _.Move("CODIGO DE REMESSA   ", WORK_AREA.WS_NOME_CPO);

                /*" -1164- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1171- IF RA-COD-CONVENIO NOT EQUAL '6001' AND '6038' AND '6039' AND '6040' AND '6041' AND '6042' AND '6043' AND '6044' AND '6036' AND '6065' AND '6067' AND '6068' AND '6069' AND '6070' AND '6071' AND '6072' AND '6073' AND '6075' AND '6081' AND '6082' AND '6083' AND '6084' AND '6088' AND '6089' AND '6090' AND '6091' AND '6132' AND '6131' AND '6153' */

            if (!RET_HEADER.RA_COD_CONVENIO.In("6001", "6038", "6039", "6040", "6041", "6042", "6043", "6044", "6036", "6065", "6067", "6068", "6069", "6070", "6071", "6072", "6073", "6075", "6081", "6082", "6083", "6084", "6088", "6089", "6090", "6091", "6132", "6131", "6153"))
            {

                /*" -1172- MOVE 'CONVENIO NAO ESPERADO                 ' TO WS-MENS */
                _.Move("CONVENIO NAO ESPERADO                 ", WORK_AREA.WS_MENS);

                /*" -1173- MOVE 003 TO WS-POS-1 */
                _.Move(003, WORK_AREA.WS_POS_1);

                /*" -1174- MOVE 022 TO WS-POS-2 */
                _.Move(022, WORK_AREA.WS_POS_2);

                /*" -1175- MOVE 'CODIGO DO CONVENIO  ' TO WS-NOME-CPO */
                _.Move("CODIGO DO CONVENIO  ", WORK_AREA.WS_NOME_CPO);

                /*" -1177- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1178- IF RA-NOME-EMPRESA EQUAL SPACES */

            if (RET_HEADER.RA_NOME_EMPRESA.IsEmpty())
            {

                /*" -1179- MOVE 'NOME DA EMPRESA EM BRANCO             ' TO WS-MENS */
                _.Move("NOME DA EMPRESA EM BRANCO             ", WORK_AREA.WS_MENS);

                /*" -1180- MOVE 023 TO WS-POS-1 */
                _.Move(023, WORK_AREA.WS_POS_1);

                /*" -1181- MOVE 042 TO WS-POS-2 */
                _.Move(042, WORK_AREA.WS_POS_2);

                /*" -1182- MOVE 'NOME DA EMPRESA     ' TO WS-NOME-CPO */
                _.Move("NOME DA EMPRESA     ", WORK_AREA.WS_NOME_CPO);

                /*" -1184- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1185- IF RA-COD-BANCO NOT EQUAL '104' */

            if (RET_HEADER.RA_COD_BANCO != "104")
            {

                /*" -1186- MOVE 'COD BANCO DEVE SER 104 - CEF          ' TO WS-MENS */
                _.Move("COD BANCO DEVE SER 104 - CEF          ", WORK_AREA.WS_MENS);

                /*" -1187- MOVE 043 TO WS-POS-1 */
                _.Move(043, WORK_AREA.WS_POS_1);

                /*" -1188- MOVE 045 TO WS-POS-2 */
                _.Move(045, WORK_AREA.WS_POS_2);

                /*" -1189- MOVE 'CODIGO DO BANCO     ' TO WS-NOME-CPO */
                _.Move("CODIGO DO BANCO     ", WORK_AREA.WS_NOME_CPO);

                /*" -1191- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1192- IF RA-NOME-BANCO EQUAL SPACES */

            if (RET_HEADER.RA_NOME_BANCO.IsEmpty())
            {

                /*" -1193- MOVE 'NOME DO BANCO EM BRANCO               ' TO WS-MENS */
                _.Move("NOME DO BANCO EM BRANCO               ", WORK_AREA.WS_MENS);

                /*" -1194- MOVE 046 TO WS-POS-1 */
                _.Move(046, WORK_AREA.WS_POS_1);

                /*" -1195- MOVE 065 TO WS-POS-2 */
                _.Move(065, WORK_AREA.WS_POS_2);

                /*" -1196- MOVE 'NOME DO BANCO       ' TO WS-NOME-CPO */
                _.Move("NOME DO BANCO       ", WORK_AREA.WS_NOME_CPO);

                /*" -1198- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1199- MOVE RA-DATA-GERACAO TO WS-DATA-INV. */
            _.Move(RET_HEADER.RA_DATA_GERACAO, WORK_AREA.WS_DATA_INV);

            /*" -1200- PERFORM 5700-CONSISTE-DATA THRU 5700-FIM. */

            M_5700_CONSISTE_DATA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5700_FIM*/


            /*" -1201- IF LK-RETURN-CODE NOT EQUAL 0 */

            if (WORK_AREA.LK_DATA.LK_RETURN_CODE != 0)
            {

                /*" -1202- MOVE 'DATA DE GERACAO DA FITA INVALIDA      ' TO WS-MENS */
                _.Move("DATA DE GERACAO DA FITA INVALIDA      ", WORK_AREA.WS_MENS);

                /*" -1203- MOVE 066 TO WS-POS-1 */
                _.Move(066, WORK_AREA.WS_POS_1);

                /*" -1204- MOVE 071 TO WS-POS-2 */
                _.Move(071, WORK_AREA.WS_POS_2);

                /*" -1205- MOVE 'DATA GERACAO AAMMDD ' TO WS-NOME-CPO */
                _.Move("DATA GERACAO AAMMDD ", WORK_AREA.WS_NOME_CPO);

                /*" -1207- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1209- IF RA-NSA NOT NUMERIC OR RA-NSA EQUAL ZEROES */

            if (!RET_HEADER.RA_NSA.IsNumeric() || RET_HEADER.RA_NSA == 00)
            {

                /*" -1210- MOVE 'NUM SEQ ARQUIVO INVALIDO              ' TO WS-MENS */
                _.Move("NUM SEQ ARQUIVO INVALIDO              ", WORK_AREA.WS_MENS);

                /*" -1211- MOVE 072 TO WS-POS-1 */
                _.Move(072, WORK_AREA.WS_POS_1);

                /*" -1212- MOVE 077 TO WS-POS-2 */
                _.Move(077, WORK_AREA.WS_POS_2);

                /*" -1213- MOVE 'NSA                 ' TO WS-NOME-CPO */
                _.Move("NSA                 ", WORK_AREA.WS_NOME_CPO);

                /*" -1214- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1215- ELSE */
            }
            else
            {


                /*" -1244- IF RA-COD-CONVENIO EQUAL '6001' OR RA-COD-CONVENIO = '6038' OR RA-COD-CONVENIO = '6039' OR RA-COD-CONVENIO = '6044' OR RA-COD-CONVENIO = '6043' OR RA-COD-CONVENIO = '6042' OR RA-COD-CONVENIO = '6041' OR RA-COD-CONVENIO = '6040' OR RA-COD-CONVENIO = '6036' OR RA-COD-CONVENIO = '6065' OR RA-COD-CONVENIO = '6067' OR RA-COD-CONVENIO = '6068' OR RA-COD-CONVENIO = '6069' OR RA-COD-CONVENIO = '6070' OR RA-COD-CONVENIO = '6071' OR RA-COD-CONVENIO = '6072' OR RA-COD-CONVENIO = '6073' OR RA-COD-CONVENIO = '6075' OR RA-COD-CONVENIO = '6081' OR RA-COD-CONVENIO = '6082' OR RA-COD-CONVENIO = '6083' OR RA-COD-CONVENIO = '6084' OR RA-COD-CONVENIO = '6088' OR RA-COD-CONVENIO = '6089' OR RA-COD-CONVENIO = '6090' OR RA-COD-CONVENIO = '6091' OR RA-COD-CONVENIO = '6131' OR RA-COD-CONVENIO = '6132' OR RA-COD-CONVENIO = '6153' */

                if (RET_HEADER.RA_COD_CONVENIO == "6001" || RET_HEADER.RA_COD_CONVENIO == "6038" || RET_HEADER.RA_COD_CONVENIO == "6039" || RET_HEADER.RA_COD_CONVENIO == "6044" || RET_HEADER.RA_COD_CONVENIO == "6043" || RET_HEADER.RA_COD_CONVENIO == "6042" || RET_HEADER.RA_COD_CONVENIO == "6041" || RET_HEADER.RA_COD_CONVENIO == "6040" || RET_HEADER.RA_COD_CONVENIO == "6036" || RET_HEADER.RA_COD_CONVENIO == "6065" || RET_HEADER.RA_COD_CONVENIO == "6067" || RET_HEADER.RA_COD_CONVENIO == "6068" || RET_HEADER.RA_COD_CONVENIO == "6069" || RET_HEADER.RA_COD_CONVENIO == "6070" || RET_HEADER.RA_COD_CONVENIO == "6071" || RET_HEADER.RA_COD_CONVENIO == "6072" || RET_HEADER.RA_COD_CONVENIO == "6073" || RET_HEADER.RA_COD_CONVENIO == "6075" || RET_HEADER.RA_COD_CONVENIO == "6081" || RET_HEADER.RA_COD_CONVENIO == "6082" || RET_HEADER.RA_COD_CONVENIO == "6083" || RET_HEADER.RA_COD_CONVENIO == "6084" || RET_HEADER.RA_COD_CONVENIO == "6088" || RET_HEADER.RA_COD_CONVENIO == "6089" || RET_HEADER.RA_COD_CONVENIO == "6090" || RET_HEADER.RA_COD_CONVENIO == "6091" || RET_HEADER.RA_COD_CONVENIO == "6131" || RET_HEADER.RA_COD_CONVENIO == "6132" || RET_HEADER.RA_COD_CONVENIO == "6153")
                {

                    /*" -1246- PERFORM 0011-CONSISTE-NSA THRU 0011-FIM. */

                    M_0011_CONSISTE_NSA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0011_FIM*/

                }

            }


            /*" -1248- IF RA-VERSAO-LAYOUT NOT NUMERIC OR RA-VERSAO-LAYOUT NOT EQUAL '04' */

            if (!RET_HEADER.RA_VERSAO_LAYOUT.IsNumeric() || RET_HEADER.RA_VERSAO_LAYOUT != "04")
            {

                /*" -1249- MOVE 'VERSAO DO LAYOUT DEVE SER 04          ' TO WS-MENS */
                _.Move("VERSAO DO LAYOUT DEVE SER 04          ", WORK_AREA.WS_MENS);

                /*" -1250- MOVE 078 TO WS-POS-1 */
                _.Move(078, WORK_AREA.WS_POS_1);

                /*" -1251- MOVE 079 TO WS-POS-2 */
                _.Move(079, WORK_AREA.WS_POS_2);

                /*" -1252- MOVE 'VERSAO DO LAYOUT    ' TO WS-NOME-CPO */
                _.Move("VERSAO DO LAYOUT    ", WORK_AREA.WS_NOME_CPO);

                /*" -1252- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0011-CONSISTE-NSA */
        private void M_0011_CONSISTE_NSA(bool isPerform = false)
        {
            /*" -1273- MOVE '0011-CONSISTE-NSA' TO PARAGRAFO. */
            _.Move("0011-CONSISTE-NSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1275- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1277- MOVE 'SELECT ... FROM SEGUROS.V0FITACEF  ' TO COMANDO. */
            _.Move("SELECT ... FROM SEGUROS.V0FITACEF  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1278- MOVE RA-NSA TO WRA-NSA-R. */
            _.Move(RET_HEADER.RA_NSA, WORK_AREA.WORK_AREA_1.WRA_NSA_R);

            /*" -1280- MOVE WS-NSA TO FITCEF-NSA FITCEF-NSAC. */
            _.Move(WORK_AREA.WS_NSA_R.WS_NSA, FITCEF_NSA, FITCEF_NSAC);

            /*" -1281- DISPLAY 'NSA-CEF        ' RA-NSA */
            _.Display($"NSA-CEF        {RET_HEADER.RA_NSA}");

            /*" -1282- IF RA-COD-CONVENIO = '6036' */

            if (RET_HEADER.RA_COD_CONVENIO == "6036")
            {

                /*" -1283- COMPUTE FITCEF-NSA = FITCEF-NSA + 9000 */
                FITCEF_NSA.Value = FITCEF_NSA + 9000;

                /*" -1284- ELSE */
            }
            else
            {


                /*" -1285- IF RA-COD-CONVENIO = '6038' */

                if (RET_HEADER.RA_COD_CONVENIO == "6038")
                {

                    /*" -1286- COMPUTE FITCEF-NSA = FITCEF-NSA + 2000 */
                    FITCEF_NSA.Value = FITCEF_NSA + 2000;

                    /*" -1287- ELSE */
                }
                else
                {


                    /*" -1288- IF RA-COD-CONVENIO = '6039' */

                    if (RET_HEADER.RA_COD_CONVENIO == "6039")
                    {

                        /*" -1289- COMPUTE FITCEF-NSA = FITCEF-NSA + 3000 */
                        FITCEF_NSA.Value = FITCEF_NSA + 3000;

                        /*" -1290- ELSE */
                    }
                    else
                    {


                        /*" -1291- IF RA-COD-CONVENIO = '6040' */

                        if (RET_HEADER.RA_COD_CONVENIO == "6040")
                        {

                            /*" -1292- COMPUTE FITCEF-NSA = FITCEF-NSA + 4000 */
                            FITCEF_NSA.Value = FITCEF_NSA + 4000;

                            /*" -1293- ELSE */
                        }
                        else
                        {


                            /*" -1294- IF RA-COD-CONVENIO = '6041' */

                            if (RET_HEADER.RA_COD_CONVENIO == "6041")
                            {

                                /*" -1295- COMPUTE FITCEF-NSA = FITCEF-NSA + 5000 */
                                FITCEF_NSA.Value = FITCEF_NSA + 5000;

                                /*" -1296- ELSE */
                            }
                            else
                            {


                                /*" -1297- IF RA-COD-CONVENIO = '6042' */

                                if (RET_HEADER.RA_COD_CONVENIO == "6042")
                                {

                                    /*" -1298- COMPUTE FITCEF-NSA = FITCEF-NSA + 6000 */
                                    FITCEF_NSA.Value = FITCEF_NSA + 6000;

                                    /*" -1299- ELSE */
                                }
                                else
                                {


                                    /*" -1300- IF RA-COD-CONVENIO = '6043' */

                                    if (RET_HEADER.RA_COD_CONVENIO == "6043")
                                    {

                                        /*" -1301- COMPUTE FITCEF-NSA = FITCEF-NSA + 7000 */
                                        FITCEF_NSA.Value = FITCEF_NSA + 7000;

                                        /*" -1302- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1303- IF RA-COD-CONVENIO = '6044' */

                                        if (RET_HEADER.RA_COD_CONVENIO == "6044")
                                        {

                                            /*" -1304- COMPUTE FITCEF-NSA = FITCEF-NSA + 8000 */
                                            FITCEF_NSA.Value = FITCEF_NSA + 8000;

                                            /*" -1310- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1311- IF RA-COD-CONVENIO = '6065' */

                                            if (RET_HEADER.RA_COD_CONVENIO == "6065")
                                            {

                                                /*" -1312- COMPUTE FITCEF-NSA = FITCEF-NSA + 10000 */
                                                FITCEF_NSA.Value = FITCEF_NSA + 10000;

                                                /*" -1313- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1314- IF RA-COD-CONVENIO = '6067' */

                                                if (RET_HEADER.RA_COD_CONVENIO == "6067")
                                                {

                                                    /*" -1315- COMPUTE FITCEF-NSA = FITCEF-NSA + 11000 */
                                                    FITCEF_NSA.Value = FITCEF_NSA + 11000;

                                                    /*" -1316- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1317- IF RA-COD-CONVENIO = '6068' */

                                                    if (RET_HEADER.RA_COD_CONVENIO == "6068")
                                                    {

                                                        /*" -1318- COMPUTE FITCEF-NSA = FITCEF-NSA + 12000 */
                                                        FITCEF_NSA.Value = FITCEF_NSA + 12000;

                                                        /*" -1319- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1320- IF RA-COD-CONVENIO = '6069' */

                                                        if (RET_HEADER.RA_COD_CONVENIO == "6069")
                                                        {

                                                            /*" -1321- COMPUTE FITCEF-NSA = FITCEF-NSA + 13000 */
                                                            FITCEF_NSA.Value = FITCEF_NSA + 13000;

                                                            /*" -1322- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1323- IF RA-COD-CONVENIO = '6070' */

                                                            if (RET_HEADER.RA_COD_CONVENIO == "6070")
                                                            {

                                                                /*" -1324- COMPUTE FITCEF-NSA = FITCEF-NSA + 14000 */
                                                                FITCEF_NSA.Value = FITCEF_NSA + 14000;

                                                                /*" -1325- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1326- IF RA-COD-CONVENIO = '6071' */

                                                                if (RET_HEADER.RA_COD_CONVENIO == "6071")
                                                                {

                                                                    /*" -1327- COMPUTE FITCEF-NSA = FITCEF-NSA + 15000 */
                                                                    FITCEF_NSA.Value = FITCEF_NSA + 15000;

                                                                    /*" -1328- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -1329- IF RA-COD-CONVENIO = '6072' */

                                                                    if (RET_HEADER.RA_COD_CONVENIO == "6072")
                                                                    {

                                                                        /*" -1330- COMPUTE FITCEF-NSA = FITCEF-NSA + 16000 */
                                                                        FITCEF_NSA.Value = FITCEF_NSA + 16000;

                                                                        /*" -1331- ELSE */
                                                                    }
                                                                    else
                                                                    {


                                                                        /*" -1332- IF RA-COD-CONVENIO = '6073' */

                                                                        if (RET_HEADER.RA_COD_CONVENIO == "6073")
                                                                        {

                                                                            /*" -1333- COMPUTE FITCEF-NSA = FITCEF-NSA + 17000 */
                                                                            FITCEF_NSA.Value = FITCEF_NSA + 17000;

                                                                            /*" -1334- ELSE */
                                                                        }
                                                                        else
                                                                        {


                                                                            /*" -1335- IF RA-COD-CONVENIO = '6075' */

                                                                            if (RET_HEADER.RA_COD_CONVENIO == "6075")
                                                                            {

                                                                                /*" -1336- COMPUTE FITCEF-NSA = FITCEF-NSA + 18000 */
                                                                                FITCEF_NSA.Value = FITCEF_NSA + 18000;

                                                                                /*" -1342- ELSE */
                                                                            }
                                                                            else
                                                                            {


                                                                                /*" -1343- IF RA-COD-CONVENIO = '6081' */

                                                                                if (RET_HEADER.RA_COD_CONVENIO == "6081")
                                                                                {

                                                                                    /*" -1344- COMPUTE FITCEF-NSA = FITCEF-NSA + 19000 */
                                                                                    FITCEF_NSA.Value = FITCEF_NSA + 19000;

                                                                                    /*" -1345- ELSE */
                                                                                }
                                                                                else
                                                                                {


                                                                                    /*" -1346- IF RA-COD-CONVENIO = '6082' */

                                                                                    if (RET_HEADER.RA_COD_CONVENIO == "6082")
                                                                                    {

                                                                                        /*" -1347- COMPUTE FITCEF-NSA = FITCEF-NSA + 20000 */
                                                                                        FITCEF_NSA.Value = FITCEF_NSA + 20000;

                                                                                        /*" -1348- ELSE */
                                                                                    }
                                                                                    else
                                                                                    {


                                                                                        /*" -1349- IF RA-COD-CONVENIO = '6083' */

                                                                                        if (RET_HEADER.RA_COD_CONVENIO == "6083")
                                                                                        {

                                                                                            /*" -1350- COMPUTE FITCEF-NSA = FITCEF-NSA + 21000 */
                                                                                            FITCEF_NSA.Value = FITCEF_NSA + 21000;

                                                                                            /*" -1351- ELSE */
                                                                                        }
                                                                                        else
                                                                                        {


                                                                                            /*" -1352- IF RA-COD-CONVENIO = '6084' */

                                                                                            if (RET_HEADER.RA_COD_CONVENIO == "6084")
                                                                                            {

                                                                                                /*" -1353- COMPUTE FITCEF-NSA = FITCEF-NSA + 22000 */
                                                                                                FITCEF_NSA.Value = FITCEF_NSA + 22000;

                                                                                                /*" -1354- ELSE */
                                                                                            }
                                                                                            else
                                                                                            {


                                                                                                /*" -1355- IF RA-COD-CONVENIO = '6088' */

                                                                                                if (RET_HEADER.RA_COD_CONVENIO == "6088")
                                                                                                {

                                                                                                    /*" -1356- COMPUTE FITCEF-NSA = FITCEF-NSA + 23000 */
                                                                                                    FITCEF_NSA.Value = FITCEF_NSA + 23000;

                                                                                                    /*" -1357- ELSE */
                                                                                                }
                                                                                                else
                                                                                                {


                                                                                                    /*" -1358- IF RA-COD-CONVENIO = '6089' */

                                                                                                    if (RET_HEADER.RA_COD_CONVENIO == "6089")
                                                                                                    {

                                                                                                        /*" -1359- COMPUTE FITCEF-NSA = FITCEF-NSA + 24000 */
                                                                                                        FITCEF_NSA.Value = FITCEF_NSA + 24000;

                                                                                                        /*" -1360- ELSE */
                                                                                                    }
                                                                                                    else
                                                                                                    {


                                                                                                        /*" -1361- IF RA-COD-CONVENIO = '6090' */

                                                                                                        if (RET_HEADER.RA_COD_CONVENIO == "6090")
                                                                                                        {

                                                                                                            /*" -1362- COMPUTE FITCEF-NSA = FITCEF-NSA + 21000 */
                                                                                                            FITCEF_NSA.Value = FITCEF_NSA + 21000;

                                                                                                            /*" -1363- ELSE */
                                                                                                        }
                                                                                                        else
                                                                                                        {


                                                                                                            /*" -1364- IF RA-COD-CONVENIO = '6091' */

                                                                                                            if (RET_HEADER.RA_COD_CONVENIO == "6091")
                                                                                                            {

                                                                                                                /*" -1365- COMPUTE FITCEF-NSA = FITCEF-NSA + 26000 */
                                                                                                                FITCEF_NSA.Value = FITCEF_NSA + 26000;

                                                                                                                /*" -1366- ELSE */
                                                                                                            }
                                                                                                            else
                                                                                                            {


                                                                                                                /*" -1367- IF RA-COD-CONVENIO = '6132' */

                                                                                                                if (RET_HEADER.RA_COD_CONVENIO == "6132")
                                                                                                                {

                                                                                                                    /*" -1368- COMPUTE FITCEF-NSA = FITCEF-NSA + 28000 */
                                                                                                                    FITCEF_NSA.Value = FITCEF_NSA + 28000;

                                                                                                                    /*" -1369- ELSE */
                                                                                                                }
                                                                                                                else
                                                                                                                {


                                                                                                                    /*" -1370- IF RA-COD-CONVENIO = '6131' */

                                                                                                                    if (RET_HEADER.RA_COD_CONVENIO == "6131")
                                                                                                                    {

                                                                                                                        /*" -1371- COMPUTE FITCEF-NSA = FITCEF-NSA + 29000 */
                                                                                                                        FITCEF_NSA.Value = FITCEF_NSA + 29000;

                                                                                                                        /*" -1372- ELSE */
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {


                                                                                                                        /*" -1373- IF RA-COD-CONVENIO = '6153' */

                                                                                                                        if (RET_HEADER.RA_COD_CONVENIO == "6153")
                                                                                                                        {

                                                                                                                            /*" -1374- COMPUTE FITCEF-NSA = FITCEF-NSA + 30000 */
                                                                                                                            FITCEF_NSA.Value = FITCEF_NSA + 30000;

                                                                                                                            /*" -1375- ELSE */
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {


                                                                                                                            /*" -1377- DISPLAY 'NSA-CONVERTIDO ' FITCEF-NSA. */
                                                                                                                            _.Display($"NSA-CONVERTIDO {FITCEF_NSA}");
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

                }

            }


            /*" -1379- DISPLAY 'NSA-CONVERTIDO ' FITCEF-NSA. */
            _.Display($"NSA-CONVERTIDO {FITCEF_NSA}");

            /*" -1387- PERFORM M_0011_CONSISTE_NSA_DB_SELECT_1 */

            M_0011_CONSISTE_NSA_DB_SELECT_1();

            /*" -1391- DISPLAY 'SQLCODE V0FITACEF >>> ' SQLCODE */
            _.Display($"SQLCODE V0FITACEF >>> {DB.SQLCODE}");

            /*" -1392- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1393- DISPLAY 'FITCEF-DATA-GERACAO = ' FITCEF-DATA-GERACAO */
                _.Display($"FITCEF-DATA-GERACAO = {FITCEF_DATA_GERACAO}");

                /*" -1394- DISPLAY 'V1SIST-DTCURRENT-18 = ' V1SIST-DTCURRENT-18 */
                _.Display($"V1SIST-DTCURRENT-18 = {V1SIST_DTCURRENT_18}");

                /*" -1395- DISPLAY 'FITCEF-NSA          = ' FITCEF-NSA */
                _.Display($"FITCEF-NSA          = {FITCEF_NSA}");

                /*" -1397- DISPLAY 'FITCEF-DATA-GERACAO = ' FITCEF-DATA-GERACAO */
                _.Display($"FITCEF-DATA-GERACAO = {FITCEF_DATA_GERACAO}");

                /*" -1398- IF FITCEF-DATA-GERACAO < V1SIST-DTCURRENT-18 */

                if (FITCEF_DATA_GERACAO < V1SIST_DTCURRENT_18)
                {

                    /*" -1401- PERFORM M_0011_CONSISTE_NSA_DB_DELETE_1 */

                    M_0011_CONSISTE_NSA_DB_DELETE_1();

                    /*" -1403- IF SQLCODE NOT = 0 */

                    if (DB.SQLCODE != 0)
                    {

                        /*" -1404- DISPLAY 'PROBLEMA NO DELETE DA V0FITACEF' */
                        _.Display($"PROBLEMA NO DELETE DA V0FITACEF");

                        /*" -1405- DISPLAY SQLCODE */
                        _.Display(DB.SQLCODE);

                        /*" -1406- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -1407- END-IF */
                    }


                    /*" -1408- ELSE */
                }
                else
                {


                    /*" -1409- MOVE 'FITA JA PROCESSADA             ' TO WS-MENS */
                    _.Move("FITA JA PROCESSADA             ", WORK_AREA.WS_MENS);

                    /*" -1410- MOVE 072 TO WS-POS-1 */
                    _.Move(072, WORK_AREA.WS_POS_1);

                    /*" -1411- MOVE 077 TO WS-POS-2 */
                    _.Move(077, WORK_AREA.WS_POS_2);

                    /*" -1412- MOVE 'NSA                 ' TO WS-NOME-CPO */
                    _.Move("NSA                 ", WORK_AREA.WS_NOME_CPO);

                    /*" -1413- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                    M_5000_IMPRIME_MENS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                    /*" -1414- MOVE 888 TO RETURN-CODE */
                    _.Move(888, RETURN_CODE);

                    /*" -1415- END-IF */
                }


                /*" -1416- ELSE */
            }
            else
            {


                /*" -1417- IF SQLCODE NOT = 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1418- DISPLAY 'PROBLEMA ACESSO A V0FITACEF' */
                    _.Display($"PROBLEMA ACESSO A V0FITACEF");

                    /*" -1419- DISPLAY 'SQLCODE = ' SQLCODE */
                    _.Display($"SQLCODE = {DB.SQLCODE}");

                    /*" -1420- DISPLAY 'NSA = ' FITCEF-NSA */
                    _.Display($"NSA = {FITCEF_NSA}");

                    /*" -1421- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1422- END-IF */
                }


                /*" -1422- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0011-CONSISTE-NSA-DB-SELECT-1 */
        public void M_0011_CONSISTE_NSA_DB_SELECT_1()
        {
            /*" -1387- EXEC SQL SELECT NSAC, DATA_GERACAO INTO :FITCEF-NSAC, :FITCEF-DATA-GERACAO FROM SEGUROS.V0FITACEF WHERE NSAC = :FITCEF-NSA WITH UR END-EXEC. */

            var m_0011_CONSISTE_NSA_DB_SELECT_1_Query1 = new M_0011_CONSISTE_NSA_DB_SELECT_1_Query1()
            {
                FITCEF_NSA = FITCEF_NSA.ToString(),
            };

            var executed_1 = M_0011_CONSISTE_NSA_DB_SELECT_1_Query1.Execute(m_0011_CONSISTE_NSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FITCEF_NSAC, FITCEF_NSAC);
                _.Move(executed_1.FITCEF_DATA_GERACAO, FITCEF_DATA_GERACAO);
            }


        }

        [StopWatch]
        /*" M-0011-CONSISTE-NSA-DB-DELETE-1 */
        public void M_0011_CONSISTE_NSA_DB_DELETE_1()
        {
            /*" -1401- EXEC SQL DELETE FROM SEGUROS.V0FITACEF WHERE NSAC = :FITCEF-NSA END-EXEC */

            var m_0011_CONSISTE_NSA_DB_DELETE_1_Delete1 = new M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1()
            {
                FITCEF_NSA = FITCEF_NSA.ToString(),
            };

            M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1.Execute(m_0011_CONSISTE_NSA_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0011_FIM*/

        [StopWatch]
        /*" M-0020-PROCESSA */
        private void M_0020_PROCESSA(bool isPerform = false)
        {
            /*" -1432- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1434- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1437- ADD 1 TO AC-LIDOS ON-COUNTER. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            ON_COUNTER.Value = ON_COUNTER + 1;

            /*" -1439- IF AC-LIDOS EQUAL 2 OR ON-COUNTER EQUAL ON-INTERVAL */

            if (WORK_AREA.AC_LIDOS == 2 || ON_COUNTER == ON_INTERVAL)
            {

                /*" -1440- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1441- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WS_TIME}"
                .Display();

                /*" -1443- MOVE 0 TO ON-COUNTER. */
                _.Move(0, ON_COUNTER);
            }


            /*" -1444- IF RA-COD-REG NOT EQUAL 'B' AND 'F' */

            if (!RET_HEADER.RA_COD_REG.In("B", "F"))
            {

                /*" -1445- MOVE 'COD REGISTRO NAO ESPERADO             ' TO WS-MENS */
                _.Move("COD REGISTRO NAO ESPERADO             ", WORK_AREA.WS_MENS);

                /*" -1446- MOVE 001 TO WS-POS-1 */
                _.Move(001, WORK_AREA.WS_POS_1);

                /*" -1447- MOVE 001 TO WS-POS-2 */
                _.Move(001, WORK_AREA.WS_POS_2);

                /*" -1448- MOVE 'COD REGISTRO        ' TO WS-NOME-CPO */
                _.Move("COD REGISTRO        ", WORK_AREA.WS_NOME_CPO);

                /*" -1450- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1451- IF RA-COD-REG EQUAL 'B' */

            if (RET_HEADER.RA_COD_REG == "B")
            {

                /*" -1453- PERFORM 1000-CONSISTE-RET-OPTANTE THRU 1000-FIM. */

                M_1000_CONSISTE_RET_OPTANTE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }


            /*" -1454- IF RA-COD-REG EQUAL 'F' */

            if (RET_HEADER.RA_COD_REG == "F")
            {

                /*" -1456- PERFORM M-2000-CONSISTE-RET-LANCAMENTO THRU 2000-FIM. */

                M_2000_CONSISTE_RET_LANCAMENTO(true);

                M_2000_10_PESQ_TB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -1458- DIVIDE AC-LIDOS BY 1000 GIVING WS-QUOC REMAINDER WS-RESTO. */
            _.Divide(WORK_AREA.AC_LIDOS, 1000, WORK_AREA.WS_QUOC, WORK_AREA.WS_RESTO);

            /*" -1459- IF WS-RESTO = 0 */

            if (WORK_AREA.WS_RESTO == 0)
            {

                /*" -1459- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();
            }


            /*" -1462- READ RETCEF AT END */
            try
            {
                RETCEF.Read(() =>
                {

                    /*" -1462- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETCEF.Value, RETCEF_RECORD);
                _.Move(RETCEF.Value, RETCEF_PARTES);
                _.Move(RETCEF.Value, RET_HEADER);
                _.Move(RETCEF.Value, RET_CADASTRAMENTO);
                _.Move(RETCEF.Value, RET_LANCAMENTO);
                _.Move(RETCEF.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

        [StopWatch]
        /*" M-0900-CONSISTE-TRAILLER */
        private void M_0900_CONSISTE_TRAILLER(bool isPerform = false)
        {
            /*" -1470- MOVE '0900-CONSISTE-TRAILLER' TO PARAGRAFO. */
            _.Move("0900-CONSISTE-TRAILLER", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1472- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1473- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -1474- MOVE SPACES TO RETCEF-RECORD */
                _.Move("", RETCEF_RECORD);

                /*" -1475- PERFORM 5100-IMPRIME-CAB THRU 5100-FIM */

                M_5100_IMPRIME_CAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5100_FIM*/


                /*" -1476- PERFORM 5500-IMPRIME-RECORD THRU 5500-FIM */

                M_5500_IMPRIME_RECORD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5500_FIM*/


                /*" -1477- MOVE 'FALTA REGISTRO TRAILLER               ' TO WS-MENS */
                _.Move("FALTA REGISTRO TRAILLER               ", WORK_AREA.WS_MENS);

                /*" -1478- MOVE 000 TO WS-POS-1 */
                _.Move(000, WORK_AREA.WS_POS_1);

                /*" -1479- MOVE 000 TO WS-POS-2 */
                _.Move(000, WORK_AREA.WS_POS_2);

                /*" -1480- MOVE 'REGISTRO TRAILLER   ' TO WS-NOME-CPO */
                _.Move("REGISTRO TRAILLER   ", WORK_AREA.WS_NOME_CPO);

                /*" -1481- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1483- GO TO 0900-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_FIM*/ //GOTO
                return;
            }


            /*" -1485- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

            /*" -1487- IF RZ-QTDE-REGISTROS NOT NUMERIC OR RZ-QTDE-REGISTROS EQUAL ZEROES */

            if (!RET_TRAILLER.RZ_QTDE_REGISTROS.IsNumeric() || RET_TRAILLER.RZ_QTDE_REGISTROS == 00)
            {

                /*" -1488- MOVE 'QUANTIDADE REGISTROS INVALIDA         ' TO WS-MENS */
                _.Move("QUANTIDADE REGISTROS INVALIDA         ", WORK_AREA.WS_MENS);

                /*" -1489- MOVE 002 TO WS-POS-1 */
                _.Move(002, WORK_AREA.WS_POS_1);

                /*" -1490- MOVE 007 TO WS-POS-2 */
                _.Move(007, WORK_AREA.WS_POS_2);

                /*" -1491- MOVE 'QUANTIDADE REGISTROS' TO WS-NOME-CPO */
                _.Move("QUANTIDADE REGISTROS", WORK_AREA.WS_NOME_CPO);

                /*" -1492- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1493- MOVE ZEROES TO WRZ-QTDE-REGISTROS-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRZ_QTDE_REGISTROS_R);

                /*" -1494- ELSE */
            }
            else
            {


                /*" -1505- MOVE RZ-QTDE-REGISTROS TO WRZ-QTDE-REGISTROS-R. */
                _.Move(RET_TRAILLER.RZ_QTDE_REGISTROS, WORK_AREA.WORK_AREA_1.WRZ_QTDE_REGISTROS_R);
            }


            /*" -1506- IF RZ-TOT-DEB-CRUZ NOT NUMERIC */

            if (!RET_TRAILLER.RZ_TOT_DEB_CRUZ.IsNumeric())
            {

                /*" -1507- MOVE 'VALOR TOTAL DEBITO TRAILLER INVALIDO  ' TO WS-MENS */
                _.Move("VALOR TOTAL DEBITO TRAILLER INVALIDO  ", WORK_AREA.WS_MENS);

                /*" -1508- MOVE 008 TO WS-POS-1 */
                _.Move(008, WORK_AREA.WS_POS_1);

                /*" -1509- MOVE 024 TO WS-POS-2 */
                _.Move(024, WORK_AREA.WS_POS_2);

                /*" -1510- MOVE 'VALOR TOTAL DEBITO  ' TO WS-NOME-CPO */
                _.Move("VALOR TOTAL DEBITO  ", WORK_AREA.WS_NOME_CPO);

                /*" -1511- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1512- MOVE ZEROES TO WRZ-TOT-DEB-CRUZ-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRZ_TOT_DEB_CRUZ_R);

                /*" -1513- ELSE */
            }
            else
            {


                /*" -1524- MOVE RZ-TOT-DEB-CRUZ TO WRZ-TOT-DEB-CRUZ-R. */
                _.Move(RET_TRAILLER.RZ_TOT_DEB_CRUZ, WORK_AREA.WORK_AREA_1.WRZ_TOT_DEB_CRUZ_R);
            }


            /*" -1530- IF RZ-TOT-CRED-CRUZ NOT NUMERIC */

            if (!RET_TRAILLER.RZ_TOT_CRED_CRUZ.IsNumeric())
            {

                /*" -1531- MOVE ZEROES TO WRZ-TOT-CRED-CRUZ-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRZ_TOT_CRED_CRUZ_R);

                /*" -1532- ELSE */
            }
            else
            {


                /*" -1543- MOVE RZ-TOT-CRED-CRUZ TO WRZ-TOT-CRED-CRUZ-R. */
                _.Move(RET_TRAILLER.RZ_TOT_CRED_CRUZ, WORK_AREA.WORK_AREA_1.WRZ_TOT_CRED_CRUZ_R);
            }


            /*" -1544- IF RZ-RESERVADO NOT EQUAL SPACES */

            if (!RET_TRAILLER.RZ_RESERVADO.IsEmpty())
            {

                /*" -1545- MOVE 'AREA RESERVADA P/ FUTURO DIF BRANCOS  ' TO WS-MENS */
                _.Move("AREA RESERVADA P/ FUTURO DIF BRANCOS  ", WORK_AREA.WS_MENS);

                /*" -1546- MOVE 042 TO WS-POS-1 */
                _.Move(042, WORK_AREA.WS_POS_1);

                /*" -1547- MOVE 150 TO WS-POS-2 */
                _.Move(150, WORK_AREA.WS_POS_2);

                /*" -1548- MOVE 'RESERVADO P/ FUTURO ' TO WS-NOME-CPO */
                _.Move("RESERVADO P/ FUTURO ", WORK_AREA.WS_NOME_CPO);

                /*" -1550- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1551- WRITE RETOPT-RECORD FROM RETCEF-RECORD. */
            _.Move(RETCEF_RECORD.GetMoveValues(), RETOPT_RECORD);

            RETOPT.Write(RETOPT_RECORD.GetMoveValues().ToString());

            /*" -1552- WRITE RETDEB-RECORD FROM RETCEF-RECORD. */
            _.Move(RETCEF_RECORD.GetMoveValues(), RETDEB_RECORD);

            RETDEB.Write(RETDEB_RECORD.GetMoveValues().ToString());

            /*" -1554- WRITE RETCRE-RECORD FROM RETCEF-RECORD. */
            _.Move(RETCEF_RECORD.GetMoveValues(), RETCRE_RECORD);

            RETCRE.Write(RETCRE_RECORD.GetMoveValues().ToString());

            /*" -1555- READ RETCEF AT END */
            try
            {
                RETCEF.Read(() =>
                {

                    /*" -1557- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETCEF.Value, RETCEF_RECORD);
                _.Move(RETCEF.Value, RETCEF_PARTES);
                _.Move(RETCEF.Value, RET_HEADER);
                _.Move(RETCEF.Value, RET_CADASTRAMENTO);
                _.Move(RETCEF.Value, RET_LANCAMENTO);
                _.Move(RETCEF.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1558- IF WS-EOF = 0 */

            if (WORK_AREA.WS_EOF == 0)
            {

                /*" -1559- ADD 1 TO AC-LIDOS */
                WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

                /*" -1560- MOVE 'MOVIM APOS TRAILLER. PGM INTERROMPIDO ' TO WS-MENS */
                _.Move("MOVIM APOS TRAILLER. PGM INTERROMPIDO ", WORK_AREA.WS_MENS);

                /*" -1561- MOVE 001 TO WS-POS-1 */
                _.Move(001, WORK_AREA.WS_POS_1);

                /*" -1562- MOVE 001 TO WS-POS-2 */
                _.Move(001, WORK_AREA.WS_POS_2);

                /*" -1563- MOVE 'COD REGISTRO        ' TO WS-NOME-CPO */
                _.Move("COD REGISTRO        ", WORK_AREA.WS_NOME_CPO);

                /*" -1563- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_FIM*/

        [StopWatch]
        /*" M-1000-CONSISTE-RET-OPTANTE */
        private void M_1000_CONSISTE_RET_OPTANTE(bool isPerform = false)
        {
            /*" -1571- MOVE '1000-CONSISTE-RET-OPTANTE' TO PARAGRAFO. */
            _.Move("1000-CONSISTE-RET-OPTANTE", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1573- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1574- IF RB-IDENTIF-CLI NOT NUMERIC */

            if (!RET_CADASTRAMENTO.RB_IDENT_CLI_EMPRESA.RB_IDENTIF_CLI.IsNumeric())
            {

                /*" -1575- MOVE ZEROES TO WRB-IDENTIF-CLI-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRB_IDENTIF_CLI_R);

                /*" -1576- ELSE */
            }
            else
            {


                /*" -1585- MOVE RB-IDENTIF-CLI TO WRB-IDENTIF-CLI-R. */
                _.Move(RET_CADASTRAMENTO.RB_IDENT_CLI_EMPRESA.RB_IDENTIF_CLI, WORK_AREA.WORK_AREA_1.WRB_IDENTIF_CLI_R);
            }


            /*" -1587- IF RB-AGENCIA NOT NUMERIC OR RB-AGENCIA EQUAL ZEROES */

            if (!RET_CADASTRAMENTO.RB_AGENCIA.IsNumeric() || RET_CADASTRAMENTO.RB_AGENCIA == 00)
            {

                /*" -1588- MOVE 'AGENCIA INVALIDA                      ' TO WS-MENS */
                _.Move("AGENCIA INVALIDA                      ", WORK_AREA.WS_MENS);

                /*" -1589- MOVE 027 TO WS-POS-1 */
                _.Move(027, WORK_AREA.WS_POS_1);

                /*" -1590- MOVE 030 TO WS-POS-2 */
                _.Move(030, WORK_AREA.WS_POS_2);

                /*" -1591- MOVE 'AGENCIA             ' TO WS-NOME-CPO */
                _.Move("AGENCIA             ", WORK_AREA.WS_NOME_CPO);

                /*" -1592- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1593- MOVE ZEROES TO WRB-AGENCIA-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRB_AGENCIA_R);

                /*" -1594- ELSE */
            }
            else
            {


                /*" -1596- MOVE RB-AGENCIA TO WRB-AGENCIA-R. */
                _.Move(RET_CADASTRAMENTO.RB_AGENCIA, WORK_AREA.WORK_AREA_1.WRB_AGENCIA_R);
            }


            /*" -1598- IF RB-COD-OPERACAO NOT NUMERIC OR RB-COD-OPERACAO EQUAL ZEROES */

            if (!RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_COD_OPERACAO.IsNumeric() || RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_COD_OPERACAO == 00)
            {

                /*" -1599- MOVE 'OPERACAO INVALIDA                     ' TO WS-MENS */
                _.Move("OPERACAO INVALIDA                     ", WORK_AREA.WS_MENS);

                /*" -1600- MOVE 031 TO WS-POS-1 */
                _.Move(031, WORK_AREA.WS_POS_1);

                /*" -1601- MOVE 033 TO WS-POS-2 */
                _.Move(033, WORK_AREA.WS_POS_2);

                /*" -1602- MOVE 'COD OPERACAO        ' TO WS-NOME-CPO */
                _.Move("COD OPERACAO        ", WORK_AREA.WS_NOME_CPO);

                /*" -1603- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1604- MOVE ZEROES TO WRB-COD-OPERACAO-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRB_COD_OPERACAO_R);

                /*" -1605- ELSE */
            }
            else
            {


                /*" -1607- MOVE RB-COD-OPERACAO TO WRB-COD-OPERACAO-R. */
                _.Move(RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_COD_OPERACAO, WORK_AREA.WORK_AREA_1.WRB_COD_OPERACAO_R);
            }


            /*" -1609- IF RB-NUM-CONTA NOT NUMERIC OR RB-NUM-CONTA EQUAL ZEROES */

            if (!RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_NUM_CONTA.IsNumeric() || RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_NUM_CONTA == 00)
            {

                /*" -1610- MOVE 'CONTA INVALIDA                        ' TO WS-MENS */
                _.Move("CONTA INVALIDA                        ", WORK_AREA.WS_MENS);

                /*" -1611- MOVE 034 TO WS-POS-1 */
                _.Move(034, WORK_AREA.WS_POS_1);

                /*" -1612- MOVE 041 TO WS-POS-2 */
                _.Move(041, WORK_AREA.WS_POS_2);

                /*" -1613- MOVE 'NUMERO DA CONTA     ' TO WS-NOME-CPO */
                _.Move("NUMERO DA CONTA     ", WORK_AREA.WS_NOME_CPO);

                /*" -1614- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1615- MOVE ZEROES TO WRB-NUM-CONTA-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRB_NUM_CONTA_R);

                /*" -1616- ELSE */
            }
            else
            {


                /*" -1618- MOVE RB-NUM-CONTA TO WRB-NUM-CONTA-R */
                _.Move(RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_NUM_CONTA, WORK_AREA.WORK_AREA_1.WRB_NUM_CONTA_R);

                /*" -1619- IF RB-DIG-CONTA NOT NUMERIC */

                if (!RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_DIG_CONTA.IsNumeric())
                {

                    /*" -1620- MOVE 'DIGITO DA CONTA INVALIDO              ' TO WS-MENS */
                    _.Move("DIGITO DA CONTA INVALIDO              ", WORK_AREA.WS_MENS);

                    /*" -1621- MOVE 042 TO WS-POS-1 */
                    _.Move(042, WORK_AREA.WS_POS_1);

                    /*" -1622- MOVE 042 TO WS-POS-2 */
                    _.Move(042, WORK_AREA.WS_POS_2);

                    /*" -1623- MOVE 'DIGITO DA CONTA     ' TO WS-NOME-CPO */
                    _.Move("DIGITO DA CONTA     ", WORK_AREA.WS_NOME_CPO);

                    /*" -1624- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                    M_5000_IMPRIME_MENS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                    /*" -1625- MOVE ZEROES TO WRB-DIG-CONTA-R */
                    _.Move(0, WORK_AREA.WORK_AREA_1.WRB_DIG_CONTA_R);

                    /*" -1626- ELSE */
                }
                else
                {


                    /*" -1628- MOVE RB-DIG-CONTA TO WRB-DIG-CONTA-R. */
                    _.Move(RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_DIG_CONTA, WORK_AREA.WORK_AREA_1.WRB_DIG_CONTA_R);
                }

            }


            /*" -1629- IF RB-IDENT-RESTO NOT EQUAL SPACES */

            if (!RET_CADASTRAMENTO.RB_IDENT_CLI_BANCO.RB_IDENT_RESTO.IsEmpty())
            {

                /*" -1630- MOVE 'IDENTIFIC CLIENTE BANCO INVALIDO      ' TO WS-MENS */
                _.Move("IDENTIFIC CLIENTE BANCO INVALIDO      ", WORK_AREA.WS_MENS);

                /*" -1631- MOVE 043 TO WS-POS-1 */
                _.Move(043, WORK_AREA.WS_POS_1);

                /*" -1632- MOVE 044 TO WS-POS-2 */
                _.Move(044, WORK_AREA.WS_POS_2);

                /*" -1633- MOVE 'IDENTIF CLI BANCO   ' TO WS-NOME-CPO */
                _.Move("IDENTIF CLI BANCO   ", WORK_AREA.WS_NOME_CPO);

                /*" -1635- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1636- MOVE RB-DATA-OPCAO TO WS-DATA-INV. */
            _.Move(RET_CADASTRAMENTO.RB_DATA_OPCAO, WORK_AREA.WS_DATA_INV);

            /*" -1637- PERFORM 5700-CONSISTE-DATA THRU 5700-FIM. */

            M_5700_CONSISTE_DATA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5700_FIM*/


            /*" -1638- IF LK-RETURN-CODE NOT EQUAL 0 */

            if (WORK_AREA.LK_DATA.LK_RETURN_CODE != 0)
            {

                /*" -1639- MOVE 'DATA DE OPCAO INVALIDA                ' TO WS-MENS */
                _.Move("DATA DE OPCAO INVALIDA                ", WORK_AREA.WS_MENS);

                /*" -1640- MOVE 045 TO WS-POS-1 */
                _.Move(045, WORK_AREA.WS_POS_1);

                /*" -1641- MOVE 050 TO WS-POS-2 */
                _.Move(050, WORK_AREA.WS_POS_2);

                /*" -1642- MOVE 'DATA DE OPCAO       ' TO WS-NOME-CPO */
                _.Move("DATA DE OPCAO       ", WORK_AREA.WS_NOME_CPO);

                /*" -1644- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1645- IF RB-RESERVADO NOT EQUAL SPACES */

            if (!RET_CADASTRAMENTO.RB_RESERVADO.IsEmpty())
            {

                /*" -1646- MOVE 'AREA RESERVADA P/ FUTURO DIF BRANCOS ' TO WS-MENS */
                _.Move("AREA RESERVADA P/ FUTURO DIF BRANCOS ", WORK_AREA.WS_MENS);

                /*" -1647- MOVE 125 TO WS-POS-1 */
                _.Move(125, WORK_AREA.WS_POS_1);

                /*" -1648- MOVE 149 TO WS-POS-2 */
                _.Move(149, WORK_AREA.WS_POS_2);

                /*" -1649- MOVE 'RESERVADO P/ FUTURO ' TO WS-NOME-CPO */
                _.Move("RESERVADO P/ FUTURO ", WORK_AREA.WS_NOME_CPO);

                /*" -1651- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1652- IF RB-COD-MOVIMENTO NOT EQUAL '1' AND '2' */

            if (!RET_CADASTRAMENTO.RB_COD_MOVIMENTO.In("1", "2"))
            {

                /*" -1653- MOVE 'COD MOVIMENTO DEVE SER 1 OU 2         ' TO WS-MENS */
                _.Move("COD MOVIMENTO DEVE SER 1 OU 2         ", WORK_AREA.WS_MENS);

                /*" -1654- MOVE 150 TO WS-POS-1 */
                _.Move(150, WORK_AREA.WS_POS_1);

                /*" -1655- MOVE 150 TO WS-POS-2 */
                _.Move(150, WORK_AREA.WS_POS_2);

                /*" -1656- MOVE 'COD MOVIMENTO       ' TO WS-NOME-CPO */
                _.Move("COD MOVIMENTO       ", WORK_AREA.WS_NOME_CPO);

                /*" -1658- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1660- IF RB-IDENTIF-CLI NUMERIC AND RB-IDENTIF-RESTO EQUAL SPACES */

            if (RET_CADASTRAMENTO.RB_IDENT_CLI_EMPRESA.RB_IDENTIF_CLI.IsNumeric() && RET_CADASTRAMENTO.RB_IDENT_CLI_EMPRESA.RB_IDENTIF_RESTO.IsEmpty())
            {

                /*" -1660- WRITE RETOPT-RECORD FROM RETCEF-RECORD. */
                _.Move(RETCEF_RECORD.GetMoveValues(), RETOPT_RECORD);

                RETOPT.Write(RETOPT_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-2000-CONSISTE-RET-LANCAMENTO */
        private void M_2000_CONSISTE_RET_LANCAMENTO(bool isPerform = false)
        {
            /*" -1668- MOVE '2000-CONSISTE-RET-LANCAMENTO' TO PARAGRAFO. */
            _.Move("2000-CONSISTE-RET-LANCAMENTO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1670- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1671- IF RF-IDENTIF-CLI NOT NUMERIC */

            if (!RET_LANCAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI.IsNumeric())
            {

                /*" -1672- MOVE ZEROES TO WRF-IDENTIF-CLI-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_IDENTIF_CLI_R);

                /*" -1673- MOVE SPACES TO SVA-CODPRODAZ */
                _.Move("", REG_SVA0805B.SVA_CODPRODAZ);

                /*" -1674- ELSE */
            }
            else
            {


                /*" -1675- MOVE RF-IDENTIF-CLI TO WRF-IDENTIF-CLI-R */
                _.Move(RET_LANCAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, WORK_AREA.WORK_AREA_1.WRF_IDENTIF_CLI_R);

                /*" -1676- MOVE WRF-IDENTIF-CLI-R TO WHOST-ACESSO */
                _.Move(WORK_AREA.WORK_AREA_1.WRF_IDENTIF_CLI_R, WHOST_ACESSO);

                /*" -1685- PERFORM M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1 */

                M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1();

                /*" -1687- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -1688- MOVE V0PROD-CODPRODAZ TO SVA-CODPRODAZ */
                    _.Move(V0PROD_CODPRODAZ, REG_SVA0805B.SVA_CODPRODAZ);

                    /*" -1689- ELSE */
                }
                else
                {


                    /*" -1698- MOVE SPACES TO SVA-CODPRODAZ. */
                    _.Move("", REG_SVA0805B.SVA_CODPRODAZ);
                }

            }


            /*" -1700- IF RF-AGENCIA NOT NUMERIC OR RF-AGENCIA EQUAL ZEROES */

            if (!RET_LANCAMENTO.RF_AGENCIA.IsNumeric() || RET_LANCAMENTO.RF_AGENCIA == 00)
            {

                /*" -1701- MOVE 'AGENCIA INVALIDA                      ' TO WS-MENS */
                _.Move("AGENCIA INVALIDA                      ", WORK_AREA.WS_MENS);

                /*" -1702- MOVE 027 TO WS-POS-1 */
                _.Move(027, WORK_AREA.WS_POS_1);

                /*" -1703- MOVE 030 TO WS-POS-2 */
                _.Move(030, WORK_AREA.WS_POS_2);

                /*" -1704- MOVE 'AGENCIA             ' TO WS-NOME-CPO */
                _.Move("AGENCIA             ", WORK_AREA.WS_NOME_CPO);

                /*" -1705- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1706- MOVE ZEROES TO WRF-AGENCIA-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_AGENCIA_R);

                /*" -1707- ELSE */
            }
            else
            {


                /*" -1710- MOVE RF-AGENCIA TO WRF-AGENCIA-R. */
                _.Move(RET_LANCAMENTO.RF_AGENCIA, WORK_AREA.WORK_AREA_1.WRF_AGENCIA_R);
            }


            /*" -1711- IF RF-COD-OPERACAO NOT NUMERIC */

            if (!RET_LANCAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPERACAO.IsNumeric())
            {

                /*" -1712- MOVE 'OPERACAO INVALIDA                     ' TO WS-MENS */
                _.Move("OPERACAO INVALIDA                     ", WORK_AREA.WS_MENS);

                /*" -1713- MOVE 031 TO WS-POS-1 */
                _.Move(031, WORK_AREA.WS_POS_1);

                /*" -1714- MOVE 033 TO WS-POS-2 */
                _.Move(033, WORK_AREA.WS_POS_2);

                /*" -1715- MOVE 'COD OPERACAO        ' TO WS-NOME-CPO */
                _.Move("COD OPERACAO        ", WORK_AREA.WS_NOME_CPO);

                /*" -1716- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1717- MOVE ZEROES TO WRF-COD-OPERACAO-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_COD_OPERACAO_R);

                /*" -1718- ELSE */
            }
            else
            {


                /*" -1721- MOVE RF-COD-OPERACAO TO WRF-COD-OPERACAO-R. */
                _.Move(RET_LANCAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPERACAO, WORK_AREA.WORK_AREA_1.WRF_COD_OPERACAO_R);
            }


            /*" -1722- IF RF-NUM-CONTA NOT NUMERIC */

            if (!RET_LANCAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_CONTA.IsNumeric())
            {

                /*" -1723- MOVE 'CONTA INVALIDA                        ' TO WS-MENS */
                _.Move("CONTA INVALIDA                        ", WORK_AREA.WS_MENS);

                /*" -1724- MOVE 034 TO WS-POS-1 */
                _.Move(034, WORK_AREA.WS_POS_1);

                /*" -1725- MOVE 041 TO WS-POS-2 */
                _.Move(041, WORK_AREA.WS_POS_2);

                /*" -1726- MOVE 'NUMERO DA CONTA     ' TO WS-NOME-CPO */
                _.Move("NUMERO DA CONTA     ", WORK_AREA.WS_NOME_CPO);

                /*" -1727- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1728- MOVE ZEROES TO WRF-NUM-CONTA-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_NUM_CONTA_R);

                /*" -1729- ELSE */
            }
            else
            {


                /*" -1732- MOVE RF-NUM-CONTA TO WRF-NUM-CONTA-R. */
                _.Move(RET_LANCAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_CONTA, WORK_AREA.WORK_AREA_1.WRF_NUM_CONTA_R);
            }


            /*" -1733- IF RF-DIG-CONTA NOT NUMERIC */

            if (!RET_LANCAMENTO.RF_IDENT_CLI_BANCO.RF_DIG_CONTA.IsNumeric())
            {

                /*" -1734- MOVE 'DIGITO DA CONTA INVALIDO              ' TO WS-MENS */
                _.Move("DIGITO DA CONTA INVALIDO              ", WORK_AREA.WS_MENS);

                /*" -1735- MOVE 042 TO WS-POS-1 */
                _.Move(042, WORK_AREA.WS_POS_1);

                /*" -1736- MOVE 042 TO WS-POS-2 */
                _.Move(042, WORK_AREA.WS_POS_2);

                /*" -1737- MOVE 'DIGITO DA CONTA     ' TO WS-NOME-CPO */
                _.Move("DIGITO DA CONTA     ", WORK_AREA.WS_NOME_CPO);

                /*" -1738- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1739- MOVE ZEROES TO WRF-DIG-CONTA-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_DIG_CONTA_R);

                /*" -1740- ELSE */
            }
            else
            {


                /*" -1743- MOVE RF-DIG-CONTA TO WRF-DIG-CONTA-R. */
                _.Move(RET_LANCAMENTO.RF_IDENT_CLI_BANCO.RF_DIG_CONTA, WORK_AREA.WORK_AREA_1.WRF_DIG_CONTA_R);
            }


            /*" -1744- IF RF-IDENT-RESTO NOT EQUAL SPACES */

            if (!RET_LANCAMENTO.RF_IDENT_CLI_BANCO.RF_IDENT_RESTO.IsEmpty())
            {

                /*" -1745- MOVE 'IDENTIFIC CLIENTE BANCO INVALIDO      ' TO WS-MENS */
                _.Move("IDENTIFIC CLIENTE BANCO INVALIDO      ", WORK_AREA.WS_MENS);

                /*" -1746- MOVE 043 TO WS-POS-1 */
                _.Move(043, WORK_AREA.WS_POS_1);

                /*" -1747- MOVE 044 TO WS-POS-2 */
                _.Move(044, WORK_AREA.WS_POS_2);

                /*" -1748- MOVE 'IDENTIF CLI BANCO   ' TO WS-NOME-CPO */
                _.Move("IDENTIF CLI BANCO   ", WORK_AREA.WS_NOME_CPO);

                /*" -1759- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1761- IF RF-VALOR NOT NUMERIC */

            if (!RET_LANCAMENTO.RF_VALOR.IsNumeric())
            {

                /*" -1762- MOVE 'VALOR INVALIDO                        ' TO WS-MENS */
                _.Move("VALOR INVALIDO                        ", WORK_AREA.WS_MENS);

                /*" -1763- MOVE 051 TO WS-POS-1 */
                _.Move(051, WORK_AREA.WS_POS_1);

                /*" -1764- MOVE 065 TO WS-POS-2 */
                _.Move(065, WORK_AREA.WS_POS_2);

                /*" -1765- MOVE 'VALOR               ' TO WS-NOME-CPO */
                _.Move("VALOR               ", WORK_AREA.WS_NOME_CPO);

                /*" -1766- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1767- MOVE ZEROES TO WRF-VALOR-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_VALOR_R);

                /*" -1768- ELSE */
            }
            else
            {


                /*" -1769- MOVE RF-VALOR TO WRF-VALOR-R */
                _.Move(RET_LANCAMENTO.RF_VALOR, WORK_AREA.WORK_AREA_1.WRF_VALOR_R);

                /*" -1771- MOVE WRF-VALOR TO SVA-VALOR. */
                _.Move(WORK_AREA.WORK_AREA_2.WRF_VALOR, REG_SVA0805B.SVA_VALOR);
            }


            /*" -1772- IF RF-COD-RETORNO NOT NUMERIC */

            if (!RET_LANCAMENTO.RF_COD_RETORNO.IsNumeric())
            {

                /*" -1773- MOVE 'COD RETORNO INVALIDO                  ' TO WS-MENS */
                _.Move("COD RETORNO INVALIDO                  ", WORK_AREA.WS_MENS);

                /*" -1774- MOVE 066 TO WS-POS-1 */
                _.Move(066, WORK_AREA.WS_POS_1);

                /*" -1775- MOVE 067 TO WS-POS-2 */
                _.Move(067, WORK_AREA.WS_POS_2);

                /*" -1776- MOVE 'COD RETORNO         ' TO WS-NOME-CPO */
                _.Move("COD RETORNO         ", WORK_AREA.WS_NOME_CPO);

                /*" -1777- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1778- MOVE ZEROES TO WRF-COD-RETORNO-R */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_COD_RETORNO_R);

                /*" -1779- ELSE */
            }
            else
            {


                /*" -1781- MOVE RF-COD-RETORNO TO WRF-COD-RETORNO-R. */
                _.Move(RET_LANCAMENTO.RF_COD_RETORNO, WORK_AREA.WORK_AREA_1.WRF_COD_RETORNO_R);
            }


            /*" -1781- MOVE ZEROS TO WS-IDX. */
            _.Move(0, WORK_AREA.WS_IDX);

        }

        [StopWatch]
        /*" M-2000-CONSISTE-RET-LANCAMENTO-DB-SELECT-1 */
        public void M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1()
        {
            /*" -1685- EXEC SQL SELECT B.CODPRODAZ INTO :V0PROD-CODPRODAZ FROM SEGUROS.V0SEGURAVG A, SEGUROS.V0PRODUTOSVG B WHERE A.NUM_CERTIFICADO = :WHOST-ACESSO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.COD_SUBGRUPO WITH UR END-EXEC */

            var m_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1 = new M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1()
            {
                WHOST_ACESSO = WHOST_ACESSO.ToString(),
            };

            var executed_1 = M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1.Execute(m_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_CODPRODAZ, V0PROD_CODPRODAZ);
            }


        }

        [StopWatch]
        /*" M-2000-10-PESQ-TB */
        private void M_2000_10_PESQ_TB(bool isPerform = false)
        {
            /*" -1788- ADD 1 TO WS-IDX. */
            WORK_AREA.WS_IDX.Value = WORK_AREA.WS_IDX + 1;

            /*" -1789- IF WS-IDX > 15 */

            if (WORK_AREA.WS_IDX > 15)
            {

                /*" -1790- MOVE 'COD RETORNO NAO PREVISTO              ' TO WS-MENS */
                _.Move("COD RETORNO NAO PREVISTO              ", WORK_AREA.WS_MENS);

                /*" -1791- MOVE 066 TO WS-POS-1 */
                _.Move(066, WORK_AREA.WS_POS_1);

                /*" -1792- MOVE 067 TO WS-POS-2 */
                _.Move(067, WORK_AREA.WS_POS_2);

                /*" -1793- MOVE 'COD RETORNO         ' TO WS-NOME-CPO */
                _.Move("COD RETORNO         ", WORK_AREA.WS_NOME_CPO);

                /*" -1794- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -1795- MOVE ZEROS TO SVA-IDX */
                _.Move(0, REG_SVA0805B.SVA_IDX);

                /*" -1796- MOVE ZEROS TO SVA-COD-RETORNO */
                _.Move(0, REG_SVA0805B.SVA_COD_RETORNO);

                /*" -1797- ELSE */
            }
            else
            {


                /*" -1798- IF TB-COD-RETORNO(WS-IDX) = WRF-COD-RETORNO */

                if (WORK_AREA.TABELA_COD_RETORNO_R.TAB_COD_RETORNO_R[WORK_AREA.WS_IDX].TB_COD_RETORNO == WORK_AREA.WORK_AREA_2.WRF_COD_RETORNO)
                {

                    /*" -1799- MOVE WS-IDX TO SVA-IDX */
                    _.Move(WORK_AREA.WS_IDX, REG_SVA0805B.SVA_IDX);

                    /*" -1800- MOVE WRF-COD-RETORNO TO SVA-COD-RETORNO */
                    _.Move(WORK_AREA.WORK_AREA_2.WRF_COD_RETORNO, REG_SVA0805B.SVA_COD_RETORNO);

                    /*" -1801- ELSE */
                }
                else
                {


                    /*" -1819- GO TO 2000-10-PESQ-TB. */
                    new Task(() => M_2000_10_PESQ_TB()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -1826- IF RF-NSA NOT NUMERIC OR RF-NSA EQUAL ZEROES */

            if (!RET_LANCAMENTO.RF_USO_EMPRESA.RF_NSA.IsNumeric() || RET_LANCAMENTO.RF_USO_EMPRESA.RF_NSA == 00)
            {

                /*" -1828- MOVE ZEROES TO WRF-NSA-R RF-NSA */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_NSA_R, RET_LANCAMENTO.RF_USO_EMPRESA.RF_NSA);

                /*" -1829- ELSE */
            }
            else
            {


                /*" -1859- MOVE RF-NSA TO WRF-NSA-R. */
                _.Move(RET_LANCAMENTO.RF_USO_EMPRESA.RF_NSA, WORK_AREA.WORK_AREA_1.WRF_NSA_R);
            }


            /*" -1866- IF RF-NSL NOT NUMERIC OR RF-NSL EQUAL ZEROES */

            if (!RET_LANCAMENTO.RF_USO_EMPRESA.RF_NSL.IsNumeric() || RET_LANCAMENTO.RF_USO_EMPRESA.RF_NSL == 00)
            {

                /*" -1868- MOVE ZEROES TO WRF-NSL-R RF-NSL */
                _.Move(0, WORK_AREA.WORK_AREA_1.WRF_NSL_R, RET_LANCAMENTO.RF_USO_EMPRESA.RF_NSL);

                /*" -1869- ELSE */
            }
            else
            {


                /*" -1878- MOVE RF-NSL TO WRF-NSL-R. */
                _.Move(RET_LANCAMENTO.RF_USO_EMPRESA.RF_NSL, WORK_AREA.WORK_AREA_1.WRF_NSL_R);
            }


            /*" -1879- IF RF-COD-MOVIMENTO NOT EQUAL '0' AND '2' AND '1' */

            if (!RET_LANCAMENTO.RF_COD_MOVIMENTO.In("0", "2", "1"))
            {

                /*" -1880- MOVE 'COD MOVIMENTO DEVE SER 0 OU 1 OU 2    ' TO WS-MENS */
                _.Move("COD MOVIMENTO DEVE SER 0 OU 1 OU 2    ", WORK_AREA.WS_MENS);

                /*" -1881- MOVE 150 TO WS-POS-1 */
                _.Move(150, WORK_AREA.WS_POS_1);

                /*" -1882- MOVE 150 TO WS-POS-2 */
                _.Move(150, WORK_AREA.WS_POS_2);

                /*" -1883- MOVE 'COD MOVIMENTO       ' TO WS-NOME-CPO */
                _.Move("COD MOVIMENTO       ", WORK_AREA.WS_NOME_CPO);

                /*" -1904- PERFORM 5000-IMPRIME-MENS THRU 5000-FIM. */

                M_5000_IMPRIME_MENS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

            }


            /*" -1905- IF RF-COD-RETORNO = '96' */

            if (RET_LANCAMENTO.RF_COD_RETORNO == "96")
            {

                /*" -1907- GO TO 2000-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/ //GOTO
                return;
            }


            /*" -1909- IF RF-COD-MOVIMENTO = '0' OR ( RF-COD-RETORNO = '99' AND RF-COD-MOVIMENTO = '1' ) */

            if (RET_LANCAMENTO.RF_COD_MOVIMENTO == "0" || (RET_LANCAMENTO.RF_COD_RETORNO == "99" && RET_LANCAMENTO.RF_COD_MOVIMENTO == "1"))
            {

                /*" -1910- PERFORM 2100-CONSISTE-SEGURO THRU 2100-FIM */

                M_2100_CONSISTE_SEGURO(true);

                M_2100_FINALIZA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/


                /*" -1911- ELSE */
            }
            else
            {


                /*" -1913- PERFORM 2200-CONSISTE-COMISS THRU 2200-FIM. */

                M_2200_CONSISTE_COMISS(true);

                M_2200_FINALIZA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2200_FIM*/

            }


            /*" -1914- IF WS-ERRO NOT = 1 */

            if (WORK_AREA.WS_ERRO != 1)
            {

                /*" -1916- PERFORM 2300-PESQUISA-NOME THRU 2300-FIM. */

                M_2300_PESQUISA_NOME(true);

                M_2300_10_PESQUISA_CONTA(true);

                M_2300_20_PESQUISA_NOME(true);

                M_2300_30_INT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2300_FIM*/

            }


            /*" -1916- ADD WRF-VALOR TO WS-VAL-OPERACAO. */
            WORK_AREA.WS_VAL_OPERACAO.Value = WORK_AREA.WS_VAL_OPERACAO + WORK_AREA.WORK_AREA_2.WRF_VALOR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-2100-CONSISTE-SEGURO */
        private void M_2100_CONSISTE_SEGURO(bool isPerform = false)
        {
            /*" -1925- MOVE '2100-CONSISTE-SEGURO' TO PARAGRAFO. */
            _.Move("2100-CONSISTE-SEGURO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1988- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1988- WRITE RETDEB-RECORD FROM RETCEF-RECORD. */
            _.Move(RETCEF_RECORD.GetMoveValues(), RETDEB_RECORD);

            RETDEB.Write(RETDEB_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-2100-FINALIZA */
        private void M_2100_FINALIZA(bool isPerform = false)
        {
            /*" -1994- ADD WRF-VALOR TO WS-TOT-DEB-CRUZ */
            WORK_AREA.WS_TOT_DEB_CRUZ.Value = WORK_AREA.WS_TOT_DEB_CRUZ + WORK_AREA.WORK_AREA_2.WRF_VALOR;

            /*" -1994- MOVE 'D' TO SVA-DEB-CRED. */
            _.Move("D", REG_SVA0805B.SVA_DEB_CRED);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/

        [StopWatch]
        /*" M-2200-CONSISTE-COMISS */
        private void M_2200_CONSISTE_COMISS(bool isPerform = false)
        {
            /*" -2003- MOVE '2200-CONSISTE-COMISS' TO PARAGRAFO. */
            _.Move("2200-CONSISTE-COMISS", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2066- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2066- WRITE RETCRE-RECORD FROM RETCEF-RECORD. */
            _.Move(RETCEF_RECORD.GetMoveValues(), RETCRE_RECORD);

            RETCRE.Write(RETCRE_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-2200-FINALIZA */
        private void M_2200_FINALIZA(bool isPerform = false)
        {
            /*" -2072- ADD WRF-VALOR TO WS-TOT-CRED-CRUZ. */
            WORK_AREA.WS_TOT_CRED_CRUZ.Value = WORK_AREA.WS_TOT_CRED_CRUZ + WORK_AREA.WORK_AREA_2.WRF_VALOR;

            /*" -2072- MOVE 'C' TO SVA-DEB-CRED. */
            _.Move("C", REG_SVA0805B.SVA_DEB_CRED);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2200_FIM*/

        [StopWatch]
        /*" M-2300-PESQUISA-NOME */
        private void M_2300_PESQUISA_NOME(bool isPerform = false)
        {
            /*" -2080- MOVE '2300-PESQUISA-NOME' TO PARAGRAFO. */
            _.Move("2300-PESQUISA-NOME", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2082- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2084- MOVE 'SELECT ... FROM SEGUROS.V0CONTACOR ' TO COMANDO. */
            _.Move("SELECT ... FROM SEGUROS.V0CONTACOR ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2085- IF WRF-IDENTIF-CLI-R = SPACES */

            if (WORK_AREA.WORK_AREA_1.WRF_IDENTIF_CLI_R.IsEmpty())
            {

                /*" -2087- GO TO 2300-10-PESQUISA-CONTA. */

                M_2300_10_PESQUISA_CONTA(); //GOTO
                return;
            }


            /*" -2089- MOVE WRF-IDENTIF-CLI TO WHOST-ACESSO. */
            _.Move(WORK_AREA.WORK_AREA_2.WRF_IDENTIF_CLI, WHOST_ACESSO);

            /*" -2095- PERFORM M_2300_PESQUISA_NOME_DB_SELECT_1 */

            M_2300_PESQUISA_NOME_DB_SELECT_1();

            /*" -2098- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2098- GO TO 2300-20-PESQUISA-NOME. */

                M_2300_20_PESQUISA_NOME(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2300-PESQUISA-NOME-DB-SELECT-1 */
        public void M_2300_PESQUISA_NOME_DB_SELECT_1()
        {
            /*" -2095- EXEC SQL SELECT COD_CLIENTE INTO :WHOST-COD-CLIENTE FROM SEGUROS.V0CONTACOR WHERE NUM_CERTIFICADO = :WHOST-ACESSO WITH UR END-EXEC. */

            var m_2300_PESQUISA_NOME_DB_SELECT_1_Query1 = new M_2300_PESQUISA_NOME_DB_SELECT_1_Query1()
            {
                WHOST_ACESSO = WHOST_ACESSO.ToString(),
            };

            var executed_1 = M_2300_PESQUISA_NOME_DB_SELECT_1_Query1.Execute(m_2300_PESQUISA_NOME_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_CLIENTE, WHOST_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" M-2300-10-PESQUISA-CONTA */
        private void M_2300_10_PESQUISA_CONTA(bool isPerform = false)
        {
            /*" -2102- MOVE '2300-10-PESQUISA-CONTA' TO PARAGRAFO. */
            _.Move("2300-10-PESQUISA-CONTA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2104- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2106- MOVE 'SELECT ... FROM SEGUROS.V0CONTACOR ' TO COMANDO. */
            _.Move("SELECT ... FROM SEGUROS.V0CONTACOR ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2107- MOVE WRF-AGENCIA TO WHOST-AGENCIA. */
            _.Move(WORK_AREA.WORK_AREA_2.WRF_AGENCIA, WHOST_AGENCIA);

            /*" -2109- MOVE WRF-COD-OPERACAO TO WS-OPERACAO-INT WHOST-OPERACAO. */
            _.Move(WORK_AREA.WORK_AREA_2.WRF_COD_OPERACAO, WORK_AREA.WS_CONTA_INT_R.WS_OPERACAO_INT);
            _.Move(WORK_AREA.WORK_AREA_2.WRF_COD_OPERACAO, WHOST_OPERACAO);


            /*" -2111- MOVE WRF-NUM-CONTA TO WS-NRCONTA-INT WHOST-NRCONTA-P. */
            _.Move(WORK_AREA.WORK_AREA_2.WRF_NUM_CONTA, WORK_AREA.WS_CONTA_INT_R.WS_NRCONTA_INT);
            _.Move(WORK_AREA.WORK_AREA_2.WRF_NUM_CONTA, WHOST_NRCONTA_P);


            /*" -2113- MOVE WS-CONTA-INT TO WHOST-NRCONTA. */
            _.Move(WORK_AREA.WS_CONTA_INT, WHOST_NRCONTA);

            /*" -2120- PERFORM M_2300_10_PESQUISA_CONTA_DB_SELECT_1 */

            M_2300_10_PESQUISA_CONTA_DB_SELECT_1();

            /*" -2123- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2125- GO TO 2300-20-PESQUISA-NOME. */

                M_2300_20_PESQUISA_NOME(); //GOTO
                return;
            }


            /*" -2127- MOVE 'SELECT ... FROM SEGUROS.V0FUNCIOCEF' TO COMANDO. */
            _.Move("SELECT ... FROM SEGUROS.V0FUNCIOCEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2135- PERFORM M_2300_10_PESQUISA_CONTA_DB_SELECT_2 */

            M_2300_10_PESQUISA_CONTA_DB_SELECT_2();

            /*" -2140- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2141- GO TO 2300-30-INT */

                M_2300_30_INT(); //GOTO
                return;

                /*" -2142- ELSE */
            }
            else
            {


                /*" -2144- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2144- GO TO 2300-30-INT. */

                    M_2300_30_INT(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-2300-10-PESQUISA-CONTA-DB-SELECT-1 */
        public void M_2300_10_PESQUISA_CONTA_DB_SELECT_1()
        {
            /*" -2120- EXEC SQL SELECT COD_CLIENTE INTO :WHOST-COD-CLIENTE FROM SEGUROS.V0CONTACOR WHERE COD_AGENCIA = :WHOST-AGENCIA AND NUM_CTA_CORRENTE = :WHOST-NRCONTA WITH UR END-EXEC. */

            var m_2300_10_PESQUISA_CONTA_DB_SELECT_1_Query1 = new M_2300_10_PESQUISA_CONTA_DB_SELECT_1_Query1()
            {
                WHOST_AGENCIA = WHOST_AGENCIA.ToString(),
                WHOST_NRCONTA = WHOST_NRCONTA.ToString(),
            };

            var executed_1 = M_2300_10_PESQUISA_CONTA_DB_SELECT_1_Query1.Execute(m_2300_10_PESQUISA_CONTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_CLIENTE, WHOST_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" M-2300-20-PESQUISA-NOME */
        private void M_2300_20_PESQUISA_NOME(bool isPerform = false)
        {
            /*" -2149- MOVE '2300-20-PESQUISA-NOME' TO PARAGRAFO. */
            _.Move("2300-20-PESQUISA-NOME", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2151- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2153- MOVE 'SELECT ... FROM SEGUROS.V0CLIENTE  ' TO COMANDO. */
            _.Move("SELECT ... FROM SEGUROS.V0CLIENTE  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2159- PERFORM M_2300_20_PESQUISA_NOME_DB_SELECT_1 */

            M_2300_20_PESQUISA_NOME_DB_SELECT_1();

            /*" -2163- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2163- GO TO 2300-30-INT. */

                M_2300_30_INT(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2300-20-PESQUISA-NOME-DB-SELECT-1 */
        public void M_2300_20_PESQUISA_NOME_DB_SELECT_1()
        {
            /*" -2159- EXEC SQL SELECT NOME_RAZAO INTO :WHOST-NOME FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :WHOST-COD-CLIENTE WITH UR END-EXEC. */

            var m_2300_20_PESQUISA_NOME_DB_SELECT_1_Query1 = new M_2300_20_PESQUISA_NOME_DB_SELECT_1_Query1()
            {
                WHOST_COD_CLIENTE = WHOST_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_2300_20_PESQUISA_NOME_DB_SELECT_1_Query1.Execute(m_2300_20_PESQUISA_NOME_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NOME, WHOST_NOME);
            }


        }

        [StopWatch]
        /*" M-2300-10-PESQUISA-CONTA-DB-SELECT-2 */
        public void M_2300_10_PESQUISA_CONTA_DB_SELECT_2()
        {
            /*" -2135- EXEC SQL SELECT NOME_FUNCIONARIO INTO :WHOST-NOME FROM SEGUROS.V0FUNCIOCEF WHERE COD_AGENCIA = :WHOST-AGENCIA AND OPERACAO_CONTA = :WHOST-OPERACAO AND NUM_CONTA = :WHOST-NRCONTA-P WITH UR END-EXEC. */

            var m_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1 = new M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1()
            {
                WHOST_NRCONTA_P = WHOST_NRCONTA_P.ToString(),
                WHOST_OPERACAO = WHOST_OPERACAO.ToString(),
                WHOST_AGENCIA = WHOST_AGENCIA.ToString(),
            };

            var executed_1 = M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1.Execute(m_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NOME, WHOST_NOME);
            }


        }

        [StopWatch]
        /*" M-2300-30-INT */
        private void M_2300_30_INT(bool isPerform = false)
        {
            /*" -2169- RELEASE REG-SVA0805B. */
            SVA0805B.Release(REG_SVA0805B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2300_FIM*/

        [StopWatch]
        /*" M-5000-IMPRIME-MENS */
        private void M_5000_IMPRIME_MENS(bool isPerform = false)
        {
            /*" -2178- MOVE '5000-IMPRIME-MENS' TO PARAGRAFO. */
            _.Move("5000-IMPRIME-MENS", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2180- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2181- IF WS-CTLIN > 60 */

            if (WORK_AREA.WS_CTLIN > 60)
            {

                /*" -2182- PERFORM 5100-IMPRIME-CAB THRU 5100-FIM */

                M_5100_IMPRIME_CAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5100_FIM*/


                /*" -2184- PERFORM 5500-IMPRIME-RECORD THRU 5500-FIM. */

                M_5500_IMPRIME_RECORD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5500_FIM*/

            }


            /*" -2185- IF AC-LIDOS NOT = AC-LIDOS-ANT */

            if (WORK_AREA.AC_LIDOS != WORK_AREA.AC_LIDOS_ANT)
            {

                /*" -2187- PERFORM 5500-IMPRIME-RECORD THRU 5500-FIM. */

                M_5500_IMPRIME_RECORD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5500_FIM*/

            }


            /*" -2188- MOVE WS-POS-1 TO DET4-POS-1. */
            _.Move(WORK_AREA.WS_POS_1, WORK_AREA.DET_4.DET4_POS_1);

            /*" -2189- MOVE WS-POS-2 TO DET4-POS-2. */
            _.Move(WORK_AREA.WS_POS_2, WORK_AREA.DET_4.DET4_POS_2);

            /*" -2190- MOVE WS-MENS TO DET4-MENS. */
            _.Move(WORK_AREA.WS_MENS, WORK_AREA.DET_4.DET4_MENS);

            /*" -2192- MOVE WS-NOME-CPO TO DET5-NOME-CPO. */
            _.Move(WORK_AREA.WS_NOME_CPO, WORK_AREA.DET_5.DET5_NOME_CPO);

            /*" -2193- WRITE REG-IMPRESSAO FROM DET-4. */
            _.Move(WORK_AREA.DET_4.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2194- WRITE REG-IMPRESSAO FROM DET-5. */
            _.Move(WORK_AREA.DET_5.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2195- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2197- ADD 3 TO WS-CTLIN. */
            WORK_AREA.WS_CTLIN.Value = WORK_AREA.WS_CTLIN + 3;

            /*" -2199- DISPLAY 'WS-NOME-CPO =  ' WS-NOME-CPO */
            _.Display($"WS-NOME-CPO =  {WORK_AREA.WS_NOME_CPO}");

            /*" -2199- MOVE 1 TO WS-ERRO. */
            _.Move(1, WORK_AREA.WS_ERRO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

        [StopWatch]
        /*" M-5010-IMPRIME-MENS */
        private void M_5010_IMPRIME_MENS(bool isPerform = false)
        {
            /*" -2208- MOVE '5010-IMPRIME-MENS' TO PARAGRAFO. */
            _.Move("5010-IMPRIME-MENS", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2210- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2211- IF WS-CTLIN > 60 */

            if (WORK_AREA.WS_CTLIN > 60)
            {

                /*" -2212- PERFORM 5100-IMPRIME-CAB THRU 5100-FIM */

                M_5100_IMPRIME_CAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5100_FIM*/


                /*" -2214- PERFORM 5500-IMPRIME-RECORD THRU 5500-FIM. */

                M_5500_IMPRIME_RECORD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5500_FIM*/

            }


            /*" -2215- IF AC-LIDOS NOT = AC-LIDOS-ANT */

            if (WORK_AREA.AC_LIDOS != WORK_AREA.AC_LIDOS_ANT)
            {

                /*" -2217- PERFORM 5500-IMPRIME-RECORD THRU 5500-FIM. */

                M_5500_IMPRIME_RECORD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5500_FIM*/

            }


            /*" -2218- MOVE WS-POS-1 TO DET4-POS-1. */
            _.Move(WORK_AREA.WS_POS_1, WORK_AREA.DET_4.DET4_POS_1);

            /*" -2219- MOVE WS-POS-2 TO DET4-POS-2. */
            _.Move(WORK_AREA.WS_POS_2, WORK_AREA.DET_4.DET4_POS_2);

            /*" -2220- MOVE WS-MENS TO DET4-MENS. */
            _.Move(WORK_AREA.WS_MENS, WORK_AREA.DET_4.DET4_MENS);

            /*" -2222- MOVE WS-NOME-CPO TO DET5-NOME-CPO. */
            _.Move(WORK_AREA.WS_NOME_CPO, WORK_AREA.DET_5.DET5_NOME_CPO);

            /*" -2223- WRITE REG-IMPRESSAO FROM DET-4. */
            _.Move(WORK_AREA.DET_4.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2224- WRITE REG-IMPRESSAO FROM DET-5. */
            _.Move(WORK_AREA.DET_5.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2225- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2225- ADD 3 TO WS-CTLIN. */
            WORK_AREA.WS_CTLIN.Value = WORK_AREA.WS_CTLIN + 3;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5010_FIM*/

        [StopWatch]
        /*" M-5100-IMPRIME-CAB */
        private void M_5100_IMPRIME_CAB(bool isPerform = false)
        {
            /*" -2233- MOVE '5100-IMPRIME-CAB' TO PARAGRAFO. */
            _.Move("5100-IMPRIME-CAB", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2235- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2236- ADD 1 TO WS-CTPAG. */
            WORK_AREA.WS_CTPAG.Value = WORK_AREA.WS_CTPAG + 1;

            /*" -2237- MOVE WS-CTPAG TO CAB1-PAGINA. */
            _.Move(WORK_AREA.WS_CTPAG, WORK_AREA.CAB_1.CAB1_PAGINA);

            /*" -2238- WRITE REG-IMPRESSAO FROM TRACO AFTER SALTA-PAGINA. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2239- WRITE REG-IMPRESSAO FROM CAB-1. */
            _.Move(WORK_AREA.CAB_1.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2240- WRITE REG-IMPRESSAO FROM CAB-2. */
            _.Move(WORK_AREA.CAB_2.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2241- WRITE REG-IMPRESSAO FROM CAB-3. */
            _.Move(WORK_AREA.CAB_3.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2243- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2244- WRITE REG-IMPRESSAO FROM CAB-4 AFTER 2. */
            _.Move(WORK_AREA.CAB_4.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2245- WRITE REG-IMPRESSAO FROM CAB-5. */
            _.Move(WORK_AREA.CAB_5.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2246- WRITE REG-IMPRESSAO FROM CAB-6 AFTER 2. */
            _.Move(WORK_AREA.CAB_6.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2247- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2247- MOVE 11 TO WS-CTLIN. */
            _.Move(11, WORK_AREA.WS_CTLIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5100_FIM*/

        [StopWatch]
        /*" M-5500-IMPRIME-RECORD */
        private void M_5500_IMPRIME_RECORD(bool isPerform = false)
        {
            /*" -2256- MOVE '5500-IMPRIME-RECORD' TO PARAGRAFO. */
            _.Move("5500-IMPRIME-RECORD", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2258- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2260- MOVE AC-LIDOS TO DET1-REGISTRO AC-LIDOS-ANT. */
            _.Move(WORK_AREA.AC_LIDOS, WORK_AREA.DET_1.DET1_REGISTRO, WORK_AREA.AC_LIDOS_ANT);

            /*" -2261- MOVE RETCEF-PARTE-1 TO DET1-PARTE-1. */
            _.Move(RETCEF_PARTES.RETCEF_PARTE_1, WORK_AREA.DET_1.DET1_PARTE_1);

            /*" -2262- MOVE RETCEF-PARTE-2 TO DET2-PARTE-2. */
            _.Move(RETCEF_PARTES.RETCEF_PARTE_2, WORK_AREA.DET_2.DET2_PARTE_2);

            /*" -2264- MOVE RETCEF-PARTE-3 TO DET3-PARTE-3. */
            _.Move(RETCEF_PARTES.RETCEF_PARTE_3, WORK_AREA.DET_3.DET3_PARTE_3);

            /*" -2265- WRITE REG-IMPRESSAO FROM DET-1. */
            _.Move(WORK_AREA.DET_1.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2266- WRITE REG-IMPRESSAO FROM DET-2. */
            _.Move(WORK_AREA.DET_2.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2267- WRITE REG-IMPRESSAO FROM DET-3. */
            _.Move(WORK_AREA.DET_3.GetMoveValues(), REG_IMPRESSAO);

            RVA0805B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -2267- ADD 3 TO WS-CTLIN. */
            WORK_AREA.WS_CTLIN.Value = WORK_AREA.WS_CTLIN + 3;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5500_FIM*/

        [StopWatch]
        /*" M-5600-MOVIMENTO-VAZIO */
        private void M_5600_MOVIMENTO_VAZIO(bool isPerform = false)
        {
            /*" -2273- MOVE '5600-MOVIMENTO-VAZIO' TO PARAGRAFO. */
            _.Move("5600-MOVIMENTO-VAZIO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2276- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2290- PERFORM M_5600_MOVIMENTO_VAZIO_DB_INSERT_1 */

            M_5600_MOVIMENTO_VAZIO_DB_INSERT_1();

            /*" -2293- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2293- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-5600-MOVIMENTO-VAZIO-DB-INSERT-1 */
        public void M_5600_MOVIMENTO_VAZIO_DB_INSERT_1()
        {
            /*" -2290- EXEC SQL INSERT INTO SEGUROS.V0FITACEF VALUES (:FITCEF-NSA, :FITCEF-DTRET, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var m_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1 = new M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1()
            {
                FITCEF_NSA = FITCEF_NSA.ToString(),
                FITCEF_DTRET = FITCEF_DTRET.ToString(),
            };

            M_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1.Execute(m_5600_MOVIMENTO_VAZIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5600_EXIT*/

        [StopWatch]
        /*" M-5700-CONSISTE-DATA */
        private void M_5700_CONSISTE_DATA(bool isPerform = false)
        {
            /*" -2302- MOVE '5700-CONSISTE-DATA' TO PARAGRAFO. */
            _.Move("5700-CONSISTE-DATA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2304- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2305- MOVE WS-DIA-INV TO LK-DIA. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.LK_DATA.LK_DATA_DDMMAA_R.LK_DIA);

            /*" -2306- MOVE WS-MES-INV TO LK-MES. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.LK_DATA.LK_DATA_DDMMAA_R.LK_MES);

            /*" -2308- MOVE WS-ANO-INV TO LK-ANO. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.LK_DATA.LK_DATA_DDMMAA_R.LK_ANO);

            /*" -2310- MOVE 0 TO LK-RETURN-CODE. */
            _.Move(0, WORK_AREA.LK_DATA.LK_RETURN_CODE);

            /*" -2310- CALL 'PROCONC1' USING LK-DATA. */
            _.Call("PROCONC1", WORK_AREA.LK_DATA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5700_FIM*/

        [StopWatch]
        /*" M-7000-GERA-ESPELHO */
        private void M_7000_GERA_ESPELHO(bool isPerform = false)
        {
            /*" -2319- MOVE '7000-GERA-ESPELHO' TO PARAGRAFO. */
            _.Move("7000-GERA-ESPELHO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2325- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2327- RETURN SVA0805B AT END */
            try
            {
                SVA0805B.Return(REG_SVA0805B, () =>
                {

                    /*" -2329- GO TO 7000-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7000_FIM*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2330- OPEN OUTPUT RVA0805B2. */
            RVA0805B2.Open(REG_RVA0805B2);

            /*" -2331- MOVE SVA-DEB-CRED TO WS-DEB-CRED-ANT */
            _.Move(REG_SVA0805B.SVA_DEB_CRED, WORK_AREA.WS_DEB_CRED_ANT);

            /*" -2333- MOVE SVA-CODPRODAZ TO WS-CODPRODAZ-ANT */
            _.Move(REG_SVA0805B.SVA_CODPRODAZ, WORK_AREA.WS_CODPRODAZ_ANT);

            /*" -2336- PERFORM 7100-PROCESSA-REGISTRO THRU 7100-FIM UNTIL WFIM-SORT = 'S' */

            while (!(WORK_AREA.WFIM_SORT == "S"))
            {

                M_7100_PROCESSA_REGISTRO(true);

                M_7100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7100_FIM*/

            }

            /*" -2336- CLOSE RVA0805B2. */
            RVA0805B2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7000_FIM*/

        [StopWatch]
        /*" M-7100-PROCESSA-REGISTRO */
        private void M_7100_PROCESSA_REGISTRO(bool isPerform = false)
        {
            /*" -2345- MOVE '7100-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("7100-PROCESSA-REGISTRO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2356- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2357- IF WS-ERRO = 1 OR RETURN-CODE = 888 */

            if (WORK_AREA.WS_ERRO == 1 || RETURN_CODE == 888)
            {

                /*" -2358- GO TO 7100-NEXT */

                M_7100_NEXT(); //GOTO
                return;

                /*" -2360- END-IF */
            }


            /*" -2361- IF SVA-CODPRODAZ EQUAL SPACES */

            if (REG_SVA0805B.SVA_CODPRODAZ.IsEmpty())
            {

                /*" -2363- GO TO 7100-NEXT. */

                M_7100_NEXT(); //GOTO
                return;
            }


            /*" -2364- IF SVA-CODPRODAZ EQUAL WS-CODPRODAZ-ANT */

            if (REG_SVA0805B.SVA_CODPRODAZ == WORK_AREA.WS_CODPRODAZ_ANT)
            {

                /*" -2365- MOVE WS-CODPRODAZ-ANT TO LD01-CODPRODAZ */
                _.Move(WORK_AREA.WS_CODPRODAZ_ANT, WORK_AREA.LD01.LD01_CODPRODAZ);

                /*" -2366- ELSE */
            }
            else
            {


                /*" -2367- IF WS-CODPRODAZ-ANT EQUAL SPACES */

                if (WORK_AREA.WS_CODPRODAZ_ANT.IsEmpty())
                {

                    /*" -2368- MOVE SVA-DEB-CRED TO WS-DEB-CRED-ANT */
                    _.Move(REG_SVA0805B.SVA_DEB_CRED, WORK_AREA.WS_DEB_CRED_ANT);

                    /*" -2369- ELSE */
                }
                else
                {


                    /*" -2370- MOVE WS-CODPRODAZ-ANT TO LD01-CODPRODAZ */
                    _.Move(WORK_AREA.WS_CODPRODAZ_ANT, WORK_AREA.LD01.LD01_CODPRODAZ);

                    /*" -2371- MOVE SVA-CODPRODAZ TO WS-CODPRODAZ-ANT */
                    _.Move(REG_SVA0805B.SVA_CODPRODAZ, WORK_AREA.WS_CODPRODAZ_ANT);

                    /*" -2372- MOVE AC-LANC-DEB TO LD01-LANC-DEB */
                    _.Move(WORK_AREA.AC_LANC_DEB, WORK_AREA.LD01.LD01_LANC_DEB);

                    /*" -2373- MOVE AC-VAL-DEB TO LD01-VAL-DEB */
                    _.Move(WORK_AREA.AC_VAL_DEB, WORK_AREA.LD01.LD01_VAL_DEB);

                    /*" -2374- MOVE AC-LANC-DEB-N TO LD01-LANC-DEB-N */
                    _.Move(WORK_AREA.AC_LANC_DEB_N, WORK_AREA.LD01.LD01_LANC_DEB_N);

                    /*" -2375- MOVE AC-VAL-DEB-N TO LD01-VAL-DEB-N */
                    _.Move(WORK_AREA.AC_VAL_DEB_N, WORK_AREA.LD01.LD01_VAL_DEB_N);

                    /*" -2376- MOVE AC-LANC-CRED TO LD01-LANC-CRED */
                    _.Move(WORK_AREA.AC_LANC_CRED, WORK_AREA.LD01.LD01_LANC_CRED);

                    /*" -2377- MOVE AC-VAL-CRED TO LD01-VAL-CRED */
                    _.Move(WORK_AREA.AC_VAL_CRED, WORK_AREA.LD01.LD01_VAL_CRED);

                    /*" -2378- MOVE AC-LANC-CRED-N TO LD01-LANC-CRED-N */
                    _.Move(WORK_AREA.AC_LANC_CRED_N, WORK_AREA.LD01.LD01_LANC_CRED_N);

                    /*" -2379- MOVE AC-VAL-CRED-N TO LD01-VAL-CRED-N */
                    _.Move(WORK_AREA.AC_VAL_CRED_N, WORK_AREA.LD01.LD01_VAL_CRED_N);

                    /*" -2380- WRITE REG-RVA0805B2 FROM LD01 */
                    _.Move(WORK_AREA.LD01.GetMoveValues(), REG_RVA0805B2);

                    RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

                    /*" -2381- WRITE REG-RVA0805B2 FROM BRANCO */
                    _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_RVA0805B2);

                    RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

                    /*" -2382- ADD 2 TO WS-CTLINHA */
                    WORK_AREA.WS_CTLINHA.Value = WORK_AREA.WS_CTLINHA + 2;

                    /*" -2388- MOVE ZEROS TO AC-LANC-CRED AC-VAL-CRED AC-LANC-CRED-N AC-VAL-CRED-N AC-LANC-DEB AC-VAL-DEB AC-LANC-DEB-N AC-VAL-DEB-N. */
                    _.Move(0, WORK_AREA.AC_LANC_CRED, WORK_AREA.AC_VAL_CRED, WORK_AREA.AC_LANC_CRED_N, WORK_AREA.AC_VAL_CRED_N, WORK_AREA.AC_LANC_DEB, WORK_AREA.AC_VAL_DEB, WORK_AREA.AC_LANC_DEB_N, WORK_AREA.AC_VAL_DEB_N);
                }

            }


            /*" -2389- IF SVA-DEB-CRED NOT = WS-DEB-CRED-ANT */

            if (REG_SVA0805B.SVA_DEB_CRED != WORK_AREA.WS_DEB_CRED_ANT)
            {

                /*" -2390- MOVE SVA-DEB-CRED TO WS-DEB-CRED-ANT */
                _.Move(REG_SVA0805B.SVA_DEB_CRED, WORK_AREA.WS_DEB_CRED_ANT);

                /*" -2391- PERFORM 7800-IMP-TOT-GERAL THRU 7800-FIM */

                M_7800_IMP_TOT_GERAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7800_FIM*/


                /*" -2392- MOVE ZEROS TO WS-CTPAG1 */
                _.Move(0, WORK_AREA.WS_CTPAG1);

                /*" -2394- PERFORM 7700-IMPRIME-CAB THRU 7700-FIM. */

                M_7700_IMPRIME_CAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7700_FIM*/

            }


            /*" -2395- IF WS-CTLINHA > 55 */

            if (WORK_AREA.WS_CTLINHA > 55)
            {

                /*" -2405- PERFORM 7700-IMPRIME-CAB THRU 7700-FIM. */

                M_7700_IMPRIME_CAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7700_FIM*/

            }


            /*" -2406- IF SVA-DEB-CRED = 'D' */

            if (REG_SVA0805B.SVA_DEB_CRED == "D")
            {

                /*" -2407- IF SVA-IDX = 01 */

                if (REG_SVA0805B.SVA_IDX == 01)
                {

                    /*" -2409- ADD 1 TO AC-LANC-DEB-G AC-LANC-DEB */
                    WORK_AREA.AC_LANC_DEB_G.Value = WORK_AREA.AC_LANC_DEB_G + 1;
                    WORK_AREA.AC_LANC_DEB.Value = WORK_AREA.AC_LANC_DEB + 1;

                    /*" -2411- ADD SVA-VALOR TO AC-VAL-DEB-G AC-VAL-DEB */
                    WORK_AREA.AC_VAL_DEB_G.Value = WORK_AREA.AC_VAL_DEB_G + REG_SVA0805B.SVA_VALOR;
                    WORK_AREA.AC_VAL_DEB.Value = WORK_AREA.AC_VAL_DEB + REG_SVA0805B.SVA_VALOR;

                    /*" -2412- ELSE */
                }
                else
                {


                    /*" -2414- ADD 1 TO AC-LANC-DEB-G-N AC-LANC-DEB-N */
                    WORK_AREA.AC_LANC_DEB_G_N.Value = WORK_AREA.AC_LANC_DEB_G_N + 1;
                    WORK_AREA.AC_LANC_DEB_N.Value = WORK_AREA.AC_LANC_DEB_N + 1;

                    /*" -2416- ADD SVA-VALOR TO AC-VAL-DEB-G-N AC-VAL-DEB-N */
                    WORK_AREA.AC_VAL_DEB_G_N.Value = WORK_AREA.AC_VAL_DEB_G_N + REG_SVA0805B.SVA_VALOR;
                    WORK_AREA.AC_VAL_DEB_N.Value = WORK_AREA.AC_VAL_DEB_N + REG_SVA0805B.SVA_VALOR;

                    /*" -2417- ELSE */
                }

            }
            else
            {


                /*" -2418- IF SVA-IDX = 01 */

                if (REG_SVA0805B.SVA_IDX == 01)
                {

                    /*" -2420- ADD 1 TO AC-LANC-CRED-G AC-LANC-CRED */
                    WORK_AREA.AC_LANC_CRED_G.Value = WORK_AREA.AC_LANC_CRED_G + 1;
                    WORK_AREA.AC_LANC_CRED.Value = WORK_AREA.AC_LANC_CRED + 1;

                    /*" -2422- ADD SVA-VALOR TO AC-VAL-CRED-G AC-VAL-CRED */
                    WORK_AREA.AC_VAL_CRED_G.Value = WORK_AREA.AC_VAL_CRED_G + REG_SVA0805B.SVA_VALOR;
                    WORK_AREA.AC_VAL_CRED.Value = WORK_AREA.AC_VAL_CRED + REG_SVA0805B.SVA_VALOR;

                    /*" -2423- ELSE */
                }
                else
                {


                    /*" -2425- ADD 1 TO AC-LANC-CRED-G-N AC-LANC-CRED-N */
                    WORK_AREA.AC_LANC_CRED_G_N.Value = WORK_AREA.AC_LANC_CRED_G_N + 1;
                    WORK_AREA.AC_LANC_CRED_N.Value = WORK_AREA.AC_LANC_CRED_N + 1;

                    /*" -2426- ADD SVA-VALOR TO AC-VAL-CRED-G-N AC-VAL-CRED-N. */
                    WORK_AREA.AC_VAL_CRED_G_N.Value = WORK_AREA.AC_VAL_CRED_G_N + REG_SVA0805B.SVA_VALOR;
                    WORK_AREA.AC_VAL_CRED_N.Value = WORK_AREA.AC_VAL_CRED_N + REG_SVA0805B.SVA_VALOR;
                }

            }


        }

        [StopWatch]
        /*" M-7100-NEXT */
        private void M_7100_NEXT(bool isPerform = false)
        {
            /*" -2435- RETURN SVA0805B AT END */
            try
            {
                SVA0805B.Return(REG_SVA0805B, () =>
                {

                    /*" -2437- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2440- IF WS-ERRO NOT EQUAL 1 AND RETURN-CODE NOT EQUAL 888 AND WFIM-SORT EQUAL 'S' */

            if (WORK_AREA.WS_ERRO != 1 && RETURN_CODE != 888 && WORK_AREA.WFIM_SORT == "S")
            {

                /*" -2441- MOVE WS-CODPRODAZ-ANT TO LD01-CODPRODAZ */
                _.Move(WORK_AREA.WS_CODPRODAZ_ANT, WORK_AREA.LD01.LD01_CODPRODAZ);

                /*" -2442- MOVE AC-LANC-DEB TO LD01-LANC-DEB */
                _.Move(WORK_AREA.AC_LANC_DEB, WORK_AREA.LD01.LD01_LANC_DEB);

                /*" -2443- MOVE AC-VAL-DEB TO LD01-VAL-DEB */
                _.Move(WORK_AREA.AC_VAL_DEB, WORK_AREA.LD01.LD01_VAL_DEB);

                /*" -2444- MOVE AC-LANC-DEB-N TO LD01-LANC-DEB-N */
                _.Move(WORK_AREA.AC_LANC_DEB_N, WORK_AREA.LD01.LD01_LANC_DEB_N);

                /*" -2445- MOVE AC-VAL-DEB-N TO LD01-VAL-DEB-N */
                _.Move(WORK_AREA.AC_VAL_DEB_N, WORK_AREA.LD01.LD01_VAL_DEB_N);

                /*" -2446- MOVE AC-LANC-CRED TO LD01-LANC-CRED */
                _.Move(WORK_AREA.AC_LANC_CRED, WORK_AREA.LD01.LD01_LANC_CRED);

                /*" -2447- MOVE AC-VAL-CRED TO LD01-VAL-CRED */
                _.Move(WORK_AREA.AC_VAL_CRED, WORK_AREA.LD01.LD01_VAL_CRED);

                /*" -2448- MOVE AC-LANC-CRED-N TO LD01-LANC-CRED-N */
                _.Move(WORK_AREA.AC_LANC_CRED_N, WORK_AREA.LD01.LD01_LANC_CRED_N);

                /*" -2449- MOVE AC-VAL-CRED-N TO LD01-VAL-CRED-N */
                _.Move(WORK_AREA.AC_VAL_CRED_N, WORK_AREA.LD01.LD01_VAL_CRED_N);

                /*" -2450- WRITE REG-RVA0805B2 FROM LD01 */
                _.Move(WORK_AREA.LD01.GetMoveValues(), REG_RVA0805B2);

                RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

                /*" -2451- WRITE REG-RVA0805B2 FROM BRANCO */
                _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_RVA0805B2);

                RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

                /*" -2452- ADD 2 TO WS-CTLINHA */
                WORK_AREA.WS_CTLINHA.Value = WORK_AREA.WS_CTLINHA + 2;

                /*" -2458- MOVE ZEROS TO AC-LANC-CRED AC-VAL-CRED AC-LANC-CRED-N AC-VAL-CRED-N AC-LANC-DEB AC-VAL-DEB AC-LANC-DEB-N AC-VAL-DEB-N */
                _.Move(0, WORK_AREA.AC_LANC_CRED, WORK_AREA.AC_VAL_CRED, WORK_AREA.AC_LANC_CRED_N, WORK_AREA.AC_VAL_CRED_N, WORK_AREA.AC_LANC_DEB, WORK_AREA.AC_VAL_DEB, WORK_AREA.AC_LANC_DEB_N, WORK_AREA.AC_VAL_DEB_N);

                /*" -2459- PERFORM 7800-IMP-TOT-GERAL THRU 7800-FIM */

                M_7800_IMP_TOT_GERAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7800_FIM*/


                /*" -2459- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7100_FIM*/

        [StopWatch]
        /*" M-7700-IMPRIME-CAB */
        private void M_7700_IMPRIME_CAB(bool isPerform = false)
        {
            /*" -2467- MOVE '7700-IMPRIME-CAB' TO PARAGRAFO. */
            _.Move("7700-IMPRIME-CAB", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2469- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2470- ADD 1 TO WS-CTPAG1. */
            WORK_AREA.WS_CTPAG1.Value = WORK_AREA.WS_CTPAG1 + 1;

            /*" -2471- MOVE WS-CTPAG1 TO LC01-PAGINA. */
            _.Move(WORK_AREA.WS_CTPAG1, WORK_AREA.LC01.LC01_PAGINA);

            /*" -2472- WRITE REG-RVA0805B2 FROM TRACO AFTER SALTA-PAGINA. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2473- WRITE REG-RVA0805B2 FROM LC01. */
            _.Move(WORK_AREA.LC01.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2474- WRITE REG-RVA0805B2 FROM LC02. */
            _.Move(WORK_AREA.LC02.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2475- WRITE REG-RVA0805B2 FROM LC03. */
            _.Move(WORK_AREA.LC03.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2476- WRITE REG-RVA0805B2 FROM LC04. */
            _.Move(WORK_AREA.LC04.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2477- WRITE REG-RVA0805B2 FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2479- WRITE REG-RVA0805B2 FROM BRANCO AFTER 2. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2481- WRITE REG-RVA0805B2 FROM LC5A. */
            _.Move(WORK_AREA.LC5A.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2482- WRITE REG-RVA0805B2 FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2482- MOVE ZEROS TO WS-CTLINHA. */
            _.Move(0, WORK_AREA.WS_CTLINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7700_FIM*/

        [StopWatch]
        /*" M-7800-IMP-TOT-GERAL */
        private void M_7800_IMP_TOT_GERAL(bool isPerform = false)
        {
            /*" -2490- MOVE '7800-IMP-TOT-GERAL' TO PARAGRAFO. */
            _.Move("7800-IMP-TOT-GERAL", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2492- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2493- MOVE AC-LANC-DEB-G TO LT01-LANC-DEB. */
            _.Move(WORK_AREA.AC_LANC_DEB_G, WORK_AREA.LT01.LT01_LANC_DEB);

            /*" -2494- MOVE AC-LANC-CRED-G TO LT01-LANC-CRED. */
            _.Move(WORK_AREA.AC_LANC_CRED_G, WORK_AREA.LT01.LT01_LANC_CRED);

            /*" -2495- MOVE AC-VAL-DEB-G TO LT01-VAL-DEB. */
            _.Move(WORK_AREA.AC_VAL_DEB_G, WORK_AREA.LT01.LT01_VAL_DEB);

            /*" -2496- MOVE AC-VAL-CRED-G TO LT01-VAL-CRED. */
            _.Move(WORK_AREA.AC_VAL_CRED_G, WORK_AREA.LT01.LT01_VAL_CRED);

            /*" -2497- MOVE AC-LANC-DEB-G-N TO LT01-LANC-DEB-N. */
            _.Move(WORK_AREA.AC_LANC_DEB_G_N, WORK_AREA.LT01.LT01_LANC_DEB_N);

            /*" -2498- MOVE AC-LANC-CRED-G-N TO LT01-LANC-CRED-N. */
            _.Move(WORK_AREA.AC_LANC_CRED_G_N, WORK_AREA.LT01.LT01_LANC_CRED_N);

            /*" -2499- MOVE AC-VAL-DEB-G-N TO LT01-VAL-DEB-N. */
            _.Move(WORK_AREA.AC_VAL_DEB_G_N, WORK_AREA.LT01.LT01_VAL_DEB_N);

            /*" -2501- MOVE AC-VAL-CRED-G-N TO LT01-VAL-CRED-N. */
            _.Move(WORK_AREA.AC_VAL_CRED_G_N, WORK_AREA.LT01.LT01_VAL_CRED_N);

            /*" -2502- IF WS-CTLINHA > 53 */

            if (WORK_AREA.WS_CTLINHA > 53)
            {

                /*" -2504- PERFORM 7700-IMPRIME-CAB THRU 7700-FIM. */

                M_7700_IMPRIME_CAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7700_FIM*/

            }


            /*" -2505- WRITE REG-RVA0805B2 FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2506- WRITE REG-RVA0805B2 FROM LC06. */
            _.Move(WORK_AREA.LC06.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2508- WRITE REG-RVA0805B2 FROM LT01. */
            _.Move(WORK_AREA.LT01.GetMoveValues(), REG_RVA0805B2);

            RVA0805B2.Write(REG_RVA0805B2.GetMoveValues().ToString());

            /*" -2515- MOVE ZEROS TO AC-LANC-CRED-G AC-VAL-CRED-G AC-LANC-CRED-G-N AC-VAL-CRED-G-N AC-LANC-DEB-G AC-VAL-DEB-G AC-LANC-DEB-G-N AC-VAL-DEB-G-N. */
            _.Move(0, WORK_AREA.AC_LANC_CRED_G, WORK_AREA.AC_VAL_CRED_G, WORK_AREA.AC_LANC_CRED_G_N, WORK_AREA.AC_VAL_CRED_G_N, WORK_AREA.AC_LANC_DEB_G, WORK_AREA.AC_VAL_DEB_G, WORK_AREA.AC_LANC_DEB_G_N, WORK_AREA.AC_VAL_DEB_G_N);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7800_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -2525- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -2526- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -2527- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -2528- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -2529- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -2531- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -2532- CLOSE RVA0805B. */
            RVA0805B.Close();

            /*" -2533- CLOSE RETCEF. */
            RETCEF.Close();

            /*" -2534- CLOSE RETOPT. */
            RETOPT.Close();

            /*" -2535- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -2537- CLOSE RETCRE. */
            RETCRE.Close();

            /*" -2539- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2543- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2543- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}