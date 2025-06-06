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
using Sias.VidaAzul.DB2.VA0812B;

namespace Code
{
    public class VA0812B
    {
        public bool IsCall { get; set; }

        public VA0812B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *      RETORNO DOS LANCAMENTOS DE CREDITO EM CONTA FEBRABAN      *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO SUMARIA                             11.12.92        *      */
        /*"      *                                                                *      */
        /*"      *         O PROGRAMA LE O MOVIMENTO DE RETORNO DOS LANCAMENTOS   *      */
        /*"      *     DE CREDITO NAO EFETUADOS E ATUALIZA A TABELA V0MOVCOMIS,   *      */
        /*"      *     GERANDO NO FINAL UM PEDIDO DE EMISSAO DE RELATORIO.        *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE FONSECA           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.34  *  VERSAO 34  - DEMANDA   RITM0002669                            *      */
        /*"      *             - PASSA A ALTERAR A SITUACAO DA PARCELAS_VIDAZUL,  *      */
        /*"      *               COBER_HIST_VIDAZUL E HIST_LANC_CTA PARA          *      */
        /*"      *               8 - CANCELADO PARA PERMITIR O RECOMANDO EM CASOS *      */
        /*"      *               INSUCESSO NA RESTITUICAO.                        *      */
        /*"      *   *                                                                   */
        /*"      *  EM 26/09/2024 - FELIPE LARA                                   *      */
        /*"      *                                        PROCURE POR V.34        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.33  *  VERSAO 33  - INCIDENTE 577.372                                *      */
        /*"      *             - CORRIGIR A OCORRENCIA NO INSERT DA HISTCONTABILVA*      */
        /*"      *               IGUALANDO O VALOR COM A TABELA V0HISTCONTAVA     *      */
        /*"      *                                                                *      */
        /*"      *  EM 18/03/2024 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.33        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 31/01/2024 *      */
        /*"      *   VERSAO 32               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
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
        /*"      *                           - PROCURAR POR V.32                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.31  *  VERSAO 31  - INCIDENTE 570.509                                *      */
        /*"      *             - RETIRAR O ROLLBACK DEIXADO INDEVIDAMENTE         *      */
        /*"      *                                                                       */
        /*"      *  EM 30/01/2024 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.31        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.30  *  VERSAO 30  - DEMANDA   486.862                                *      */
        /*"      *             - MARCAR COD_USUARIO NA HIST_LANC_CTA QUANDO A PAR-*      */
        /*"      *               CELA FOR BAIXADA                                *       */
        /*"      *                                                                       */
        /*"      *  EM 27/12/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.30        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.29  *  VERSAO 29  - DEMANDA   482.713                                       */
        /*"      *             - PASSA A ALTERAR A SITUACAO DA PARCELAS_VIDAZUL   *      */
        /*"      *               E DA COBER_HIST_VIDAZUL PARA "7 - DEVOLVIDA"     *      */
        /*"      *               EM CASOS DE SUCESSO                              *      */
        /*"      *             - PASSA A ALTERAR A SITUACAO DA PARCELAS_VIDAZUL   *      */
        /*"      *               E DA COBER_HIST_VIDAZUL PARA "1 - PAGO"          *      */
        /*"      *               EM CASOS DE INSUCESSO                            *      */
        /*"      *                                                                       */
        /*"      *  EM 12/05/2023 - FELIPE LARA                                   *      */
        /*"      *                                        PROCURE POR V.29        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.28  *VERSAO V.28-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO 27: JV1 TAREFA: 267762 - HERVAL 29/11/2020               *      */
        /*"      *               ABEND:  270611 - CLAUDETE 17/12/2020             *      */
        /*"      *           ABEND ESTOURO TABELA INTERNA PRODUTO                 *      */
        /*"      *           - PROCURAR POR JV127                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV126 *----------------------------------------------------------------*      */
        /*"JV126 *VERSAO 26: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV126 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV126 *           - PROCURAR POR JV126                                 *      */
        /*"JV126 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - HIST 181.573                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 24 -   FGV-2                                          *      */
        /*"      *               - AJUSTES A FIM DE POSSIBILITAR O PARALELISMO    *      */
        /*"      *                 DOS JOBS JPVAD00 E JPCSD01.                    *      */
        /*"      *   EM 08/02/2017 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.24         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 - CAD 99.943                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CORRECAO SQL -811                                *      */
        /*"      *               PARAGRAFO = 0036-INSERT-HISTCONTABILVA           *      */
        /*"      *               COMANDO   = SELECT V0HISCOBVA                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/07/2014 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.22      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21 - CAD 99.439                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CORRECAO DA QUERY QUE ESTAO PENGANDO RAMO 29 COM        */
        /*"      *               PERIODO DE VIGENCIA VENCIDO                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/06/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.21      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20 - CAD 87.342                                       *      */
        /*"      *                                                                *      */
        /*"      *             - TRATA SQLCODE -811 PARA O CONVENIO 6131 NO SELECT*      */
        /*"      *               DA TABELA V0HISTCOBVA.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/11/2013 -  FRANK CARVALHO (INDRA COMPANY)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.20    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO 07/10/96                                            *      */
        /*"      *                                                                *      */
        /*"      *  PROGRAMA TRATA AGORA, DO RETORNO DOS RESGATES DE TITULOS DE   *      */
        /*"      * CAPITALIZACAO, CONVENIO 6075. ATUALIZA A TABELA V0RESGATE_CAP_ *      */
        /*"      * VG.                                                            *      */
        /*"      *                                                                *      */
        /*"      *                                    MANOEL MESSIAS              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.19    *      */
        /*"      *----------------------------------------------------------------*      */
        /*" MMS  *   ALTERACOES                                                   *      */
        /*"      *                                                                *      */
        /*" MMS  *   EM 25.02.97 POR MESSIAS (SASSE)......... PROCURE POR /MMS    *      */
        /*" MMS  *   . ALTERACAO NA ROTINA DE CONTABILIZACAO PARA AS NOVAS TABE_  *      */
        /*" MMS  *   LAS DE FATURAMENTO POR FILIAL.                               *      */
        /*"      *                                                                *      */
        /*"      *                                    MANOEL MESSIAS              *      */
        /*"      ******************************************************************      */
        /*"AF0498*   ALTERACOES                                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 02.04.98 POR FONSECA (SHINE) ........ PROCURE POR /AF0498 *      */
        /*"      *   . INCLUIDO O TRATAMENTO DO RETORNO DO CONVENIO 6041 PARA     *      */
        /*"      *   O PAGAMENTO DA PREMIACAO DO MULTIPREMIADO REF VENDAS DE      *      */
        /*"      *   OUT A DEZ/97.                                                *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE F FONSECA         *      */
        /*"      ******************************************************************      */
        /*"AF0598*   ALTERACOES                                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 05.05.98 POR FONSECA (SHINE) ........ PROCURE POR /AF0598 *      */
        /*"      *   . INCLUIDO O TRATAMENTO DO RETORNO DO CONVENIO 6090 PARA     *      */
        /*"      *   O PAGAMENTO DA DEVOLUCAO DE PREMIO DO MULTIPREMIADO.         *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE F FONSECA         *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*" MMS  *   ALTERACOES                                                   *      */
        /*" MMS  *   EM 20.05.98 POR MESSIAS (SASSE).........                     *      */
        /*" MMS  *   . NA BUSCA DA FONTE, QUANDO A FONTE FOR IGUAL A 10, ABENDAR  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*" MMS  *   ALTERACOES                                                   *      */
        /*" MMS  *   EM 25.05.98 POR MESSIAS (SASSE).........                     *      */
        /*" MMS  *   . NA BUSCA DA FONTE, QUANDO A FLAG88 FOR IGUAL A 1, SIGNIFI- *      */
        /*" MMS  *   CA QUE O RETURN-CODE SERA 88 NO ABEND (PULAR P/ PROXIMO STEP)*      */
        /*"      ******************************************************************      */
        /*"AF0898*   ALTERACOES                                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 10.08.98 POR FONSECA (SHINE) ........ PROCURE POR /AF0898 *      */
        /*"      *   . INCLUIDO O TRATAMENTO DO RETORNO DO CONVENIO 6129 PARA     *      */
        /*"      *   O PAGAMENTO DA DEVOLUCAO DE PREMIO DO SASSE SAUDE PADV.      *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE F FONSECA         *      */
        /*"      ******************************************************************      */
        /*"AF0799*   ALTERACOES                                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 27.07.99 POR FONSECA (SHINE) ........ PROCURE POR /AF0799 *      */
        /*"      *   . INCLUIDO O TRATAMENTO DO RETORNO DO CONVENIO 6131 PARA     *      */
        /*"      *   O PAGAMENTO DA DEVOLUCAO DE PREMIO DO FEDERAL PLUS.          *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE F FONSECA         *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACOES                                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 22.12.00 POR MANOEL MESSIAS  ........ PROCURE POR /MM1200 *      */
        /*"      *   . VOLTA A SITUACAO DA V0HISTCOBVA PARA '1' (PAGO), POIS, A   *      */
        /*"      *   DEVOLUCAO DO PREMIO NAO FOI EFETIVADA.                       *      */
        /*"      *                                                                *      */
        /*"      *                                    MANOEL MESSIAS              *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACOES                                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 01.10.01 POR TERCIO CARVALHO ........ PROCURE POR /TL0110 *      */
        /*"      *   . PASSA A INSERIR  V0HISTCONTABILVA QUANDO HA SUCESSO NO     *      */
        /*"      *   RESSARCIMENTO. SUBSTITUI ASSIM A INSERCAO QUE ERA FEITA NA   *      */
        /*"      *   VLNRA (RESSARCIMENTO)                                        *      */
        /*"      *                                                                *      */
        /*"      *                                    TERCIO CARVALHO             *      */
        /*"      ******************************************************************      */
        /*"      * IMPLEMENTACAO DA NOVA CODIFICACAO DE ESCRITORIO DE NEGOCIOS    *      */
        /*"      * (PROCURAR POR EB0202) - ENRICO (PRODEXTER)            FEV/2002 *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACOES                                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 05.12.05 POR NORA CORTABERRIA........ PROCURE POR /NC1205 *      */
        /*"      *   . DISPLAYS PARA TRATAR ERROS NA SAIDA                        *      */
        /*"      *                                                                *      */
        /*"      *                                    NORA CORTABERRIA            *      */
        /*"      ******************************************************************      */
        /*"      *   EM  15/01/2007 - TRATA MENSAGEM ERRO -811  NO PARAGRAFO      *      */
        /*"      *                    0036-INSERT-HISTCONTABILVA - V0HISCOBVA     *      */
        /*"      *   PRODURAR POR V.11                LUCIA VIEIRA                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERACOES     - SSI 12209/2007 - AJUSTE CONTABIL            *      */
        /*"      *                                                                *      */
        /*"      *   EM 30.05.08 POR CLOVIS                                       *      */
        /*"      *   . ALTERA A ORIGEM DE AVISO DO CONVENIO 6090 DE               *      */
        /*"      *     12 - COBR. VIDA AZUL      - 21521999111  PARA              *      */
        /*"      *     22 - PGTO RESTIT. PREMIOS - 21211199119.                   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   EM  16/03/2009 - TRATA MENSAGEM ERRO -803  NO COMANDO        *      */
        /*"      *                    INSERT V0HISTCONTABILVA - V0HISTCONTABILVA  *      */
        /*"      *   - FAST COMPUTER                                              *      */
        /*"      *                                             PROCURAR POR V.13  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14  - CAD 51.170                                      *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO TAMANHO DA TABELA DE PRODUTOS         *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/11/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURAR POR V.14  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15  - CAD 48.762                                      *      */
        /*"      *                                                                *      */
        /*"      *              - CIRCULAR SUSEP 395                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/11/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURAR POR V.15  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - CAD 55.832                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CORRECAO DO ABEND SQLCODE = -180                *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/04/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                            PROCURE POR V.16    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - CAD 201.053                                      *      */
        /*"      *                                                                *      */
        /*"      *              - CORRECAO DE VALORES NEGATIVOS NA V0FITASASSE    *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/04/2011 - LEANDRO CORTES ( FAST COMPUTER)              *      */
        /*"      *                                            PROCURE POR V.17    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - CAD 74.014                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO TAMANHO DA TABELA DE PRODUTOS         *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/09/2012 - AUGUSTO ANASTACIO  (FAST COMPUTER)           *      */
        /*"      *                                            PROCURE POR V.18    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RETCRE { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETCRE
        {
            get
            {
                _.Move(RETCRE_RECORD, _RETCRE); VarBasis.RedefinePassValue(RETCRE_RECORD, _RETCRE, RETCRE_RECORD); return _RETCRE;
            }
        }
        public FileBasis _RETINV { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETINV
        {
            get
            {
                _.Move(RETINV_RECORD, _RETINV); VarBasis.RedefinePassValue(RETINV_RECORD, _RETINV, RETINV_RECORD); return _RETINV;
            }
        }
        /*"01  RETCRE-RECORD        PIC X(150).*/
        public StringBasis RETCRE_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  RET-HEADER.*/
        public VA0812B_RET_HEADER RET_HEADER { get; set; } = new VA0812B_RET_HEADER();
        public class VA0812B_RET_HEADER : VarBasis
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
            public VA0812B_RA_DATA_GERACAO RA_DATA_GERACAO { get; set; } = new VA0812B_RA_DATA_GERACAO();
            public class VA0812B_RA_DATA_GERACAO : VarBasis
            {
                /*"       10 RA-AA-GERACAO   PIC 9(004).*/
                public IntBasis RA_AA_GERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 RA-MM-GERACAO   PIC 9(002).*/
                public IntBasis RA_MM_GERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 RA-DD-GERACAO   PIC 9(002).*/
                public IntBasis RA_DD_GERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
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
        public VA0812B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA0812B_RET_CADASTRAMENTO();
        public class VA0812B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05 RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RF-IDENT-CLI-EMPRESA.*/
            public VA0812B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA0812B_RF_IDENT_CLI_EMPRESA();
            public class VA0812B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 RF-NRCERTIF      PIC 9(015).*/
                public IntBasis RF_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 RF-NSAS          PIC 9(005).*/
                public IntBasis RF_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10 FILLER           PIC X(005).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05 RF-AGENCIA          PIC 9(004).*/
            }
            public IntBasis RF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VA0812B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA0812B_RF_IDENT_CLI_BANCO();
            public class VA0812B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 RF-COD-OPERACAO  PIC 9(004).*/
                public IntBasis RF_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 RF-NUM-CONTA     PIC 9(012).*/
                public IntBasis RF_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 RF-DIG-CONTA     PIC 9(001).*/
                public IntBasis RF_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER           PIC X(002).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL.*/
            }
            public VA0812B_RF_DATA_REAL RF_DATA_REAL { get; set; } = new VA0812B_RF_DATA_REAL();
            public class VA0812B_RF_DATA_REAL : VarBasis
            {
                /*"       10 RF-AA-REAL       PIC 9(004).*/
                public IntBasis RF_AA_REAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 RF-MM-REAL       PIC 9(002).*/
                public IntBasis RF_MM_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 RF-DD-REAL       PIC 9(002).*/
                public IntBasis RF_DD_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 RF-VALOR            PIC 9(013)V99.*/
            }
            public DoubleBasis RF_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNO      PIC 9(002).*/
            public IntBasis RF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESA.*/
            public VA0812B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA0812B_RF_USO_EMPRESA();
            public class VA0812B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10 RF-NSA           PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 RF-NSA-R         REDEFINES          RF-NSA.*/
                private _REDEF_VA0812B_RF_NSA_R _rf_nsa_r { get; set; }
                public _REDEF_VA0812B_RF_NSA_R RF_NSA_R
                {
                    get { _rf_nsa_r = new _REDEF_VA0812B_RF_NSA_R(); _.Move(RF_NSA, _rf_nsa_r); VarBasis.RedefinePassValue(RF_NSA, _rf_nsa_r, RF_NSA); _rf_nsa_r.ValueChanged += () => { _.Move(_rf_nsa_r, RF_NSA); }; return _rf_nsa_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_nsa_r, RF_NSA); }
                }  //Redefines
                public class _REDEF_VA0812B_RF_NSA_R : VarBasis
                {
                    /*"          15 FILLER        PIC X(001).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"          15 RF-SERIE      PIC 9(002).*/
                    public IntBasis RF_SERIE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10 RF-NSL           PIC 9(008).*/

                    public _REDEF_VA0812B_RF_NSA_R()
                    {
                        FILLER_3.ValueChanged += OnValueChanged;
                        RF_SERIE.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 RF-NSL-R         REDEFINES          RF-NSL.*/
                private _REDEF_VA0812B_RF_NSL_R _rf_nsl_r { get; set; }
                public _REDEF_VA0812B_RF_NSL_R RF_NSL_R
                {
                    get { _rf_nsl_r = new _REDEF_VA0812B_RF_NSL_R(); _.Move(RF_NSL, _rf_nsl_r); VarBasis.RedefinePassValue(RF_NSL, _rf_nsl_r, RF_NSL); _rf_nsl_r.ValueChanged += () => { _.Move(_rf_nsl_r, RF_NSL); }; return _rf_nsl_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_nsl_r, RF_NSL); }
                }  //Redefines
                public class _REDEF_VA0812B_RF_NSL_R : VarBasis
                {
                    /*"          15 RF-NSL-7      PIC 9(007).*/
                    public IntBasis RF_NSL_7 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                    /*"          15 FILLER        PIC X(001).*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"       10 FILLER           PIC X(047).*/

                    public _REDEF_VA0812B_RF_NSL_R()
                    {
                        RF_NSL_7.ValueChanged += OnValueChanged;
                        FILLER_4.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 RF-RESERVADO        PIC X(017).*/
            }
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RF-COD-MOVIMENTO    PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLER.*/
        }
        public VA0812B_RET_TRAILLER RET_TRAILLER { get; set; } = new VA0812B_RET_TRAILLER();
        public class VA0812B_RET_TRAILLER : VarBasis
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
            /*"01  RETINV-RECORD        PIC X(150).*/
        }
        public StringBasis RETINV_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  V1MCEF-COD-FONTE                 PIC S9(4) COMP.*/
        public IntBasis V1MCEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  V1ACEF-COD-AGENCIA               PIC S9(4) COMP.*/
        public IntBasis V1ACEF_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-AGE-VENDA                  PIC S9(4) COMP.*/
        public IntBasis WHOST_AGE_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-CODCONV                    PIC S9(9) COMP.*/
        public IntBasis WHOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  VIND-NSAC                        PIC S9(4) COMP.*/
        public IntBasis VIND_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTCREDITO                   PIC S9(4) COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  HOST-NUM-CONTA                   PIC S9(017) COMP-3.*/
        public IntBasis HOST_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"01  HOST-DV-CONTA                    PIC  X(001).*/
        public StringBasis HOST_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  HOST-AGENCIA                     PIC S9(4) COMP.*/
        public IntBasis HOST_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  HHORA-OPERACAO                   PIC  X(008).*/
        public StringBasis HHORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  SQL-NOT-NULL                     PIC S9(004) COMP VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"01  SQL-MAYBE-NULL                   PIC S9(004) COMP.*/
        public IntBasis SQL_MAYBE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CAMP-CODRET                      PIC S9(4) COMP.*/
        public IntBasis CAMP_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CAMP-SITUACAO                    PIC  X(1).*/
        public StringBasis CAMP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  DTMOVABE                         PIC  X(10).*/
        public StringBasis DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  FITCEF-DTRET                     PIC  X(10).*/
        public StringBasis FITCEF_DTRET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  FITCEF-VERSAO                    PIC S9(4) COMP.*/
        public IntBasis FITCEF_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  FITCEF-QTREG                     PIC S9(9) COMP.*/
        public IntBasis FITCEF_QTREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITCEF-QTLANCCR                  PIC S9(9) COMP.*/
        public IntBasis FITCEF_QTLANCCR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITCEF-QTCREFET                  PIC S9(9) COMP.*/
        public IntBasis FITCEF_QTCREFET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITCEF-TOTCREFET                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FITCEF_TOTCREFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FITCEF-TOTCRNEFET                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FITCEF_TOTCRNEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FITSAS-CREDEFET                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FITSAS_CREDEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FITSAS-CREDNEFET                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FITSAS_CREDNEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNCEF-AGENCIA                   PIC S9(4) COMP.*/
        public IntBasis FUNCEF_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  FUNCEF-OPERACAO                  PIC S9(4) COMP.*/
        public IntBasis FUNCEF_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  FUNCEF-CONTA                     PIC S9(13) COMP-3.*/
        public IntBasis FUNCEF_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  FUNCEF-DIG                       PIC S9(4) COMP.*/
        public IntBasis FUNCEF_DIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  HISR-NUM-PARCELA                 PIC S9(04) COMP.*/
        public IntBasis HISR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HISR-CODOPER                     PIC S9(04) COMP.*/
        public IntBasis HISR_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  RESA-NRCERTIF                    PIC S9(15) COMP-3.*/
        public IntBasis RESA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  RESA-DESCR                       PIC X(120).*/
        public StringBasis RESA_DESCR { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
        /*"01  HCTA-NRCERTIF                    PIC S9(15) COMP-3.*/
        public IntBasis HCTA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  HCTA-VLPRMTOT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HCTA_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  HCTA-NRPARCEL                    PIC S9(04) COMP.*/
        public IntBasis HCTA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HCTA-CODRET                      PIC S9(4) COMP.*/
        public IntBasis HCTA_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  HCTA-OCORRHISTCTA                PIC S9(4) COMP.*/
        public IntBasis HCTA_OCORRHISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  HCTA-SITUACAO                    PIC  X(1).*/
        public StringBasis HCTA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  HCVA-NRTIT                       PIC S9(13) COMP-3.*/
        public IntBasis HCVA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  HCVA-OCORHIST                    PIC S9(04) COMP.*/
        public IntBasis HCVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  HCVA-DTVENCTO                    PIC  X(10).*/
        public StringBasis HCVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROP-NUM-APOLICE                 PIC S9(15) COMP-3.*/
        public IntBasis PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROP-CODSUBES                    PIC S9(04) COMP.*/
        public IntBasis PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROP-FONTE                       PIC S9(04) COMP.*/
        public IntBasis PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROP-DTVENCTO                    PIC  X(10).*/
        public StringBasis PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROP-RAMO                        PIC S9(004)      COMP.*/
        public IntBasis PROP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PROP-DTQITBCO                    PIC  X(10).*/
        public StringBasis PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROP-CODCLIEN                    PIC S9(09)    COMP.*/
        public IntBasis PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROP-OPCAO-COBER                 PIC  X(01).*/
        public StringBasis PROP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WHOST-GRUPO-SUSEP                PIC S9(004)      COMP.*/
        public IntBasis WHOST_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-COD-RAMO                   PIC S9(004)      COMP.*/
        public IntBasis WHOST_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PREMIO-CONJ                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WHOST_PREMIO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-TAXA-RAMO                  PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_TAXA_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-PERC-CDG                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERC_CDG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-PERC-DIT                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERC_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-OPCAO-COBER                PIC  X(01).*/
        public StringBasis WHOST_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WHOST-DTVENCTO                   PIC  X(10).*/
        public StringBasis WHOST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-DTVENCTO1                  PIC  X(10).*/
        public StringBasis WHOST_DTVENCTO1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-ANO-VENC                   PIC S9(004) COMP.*/
        public IntBasis WHOST_ANO_VENC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-ANO-NASC                   PIC S9(004) COMP.*/
        public IntBasis WHOST_ANO_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-IDADE                      PIC S9(004) COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PROP-OCORHIST                    PIC S9(04) COMP.*/
        public IntBasis PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PCVA-PRMVG                       PIC S9(13) COMP-3.*/
        public IntBasis PCVA_PRMVG { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PCVA-PRMAP                       PIC S9(13) COMP-3.*/
        public IntBasis PCVA_PRMAP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  CBVA-VLPREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CBVA_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CBVA-PRMVG                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CBVA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CBVA-PRMAP                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CBVA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CBVA-IMPMORNATU                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CBVA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CBVA-IMPMORACID                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CBVA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CBVA-IMPDIT                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CBVA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CBVA-IMPSEGCDG                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis CBVA_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  HOST-FATOR                       PIC  9(05)V9(04).*/
        public DoubleBasis HOST_FATOR { get; set; } = new DoubleBasis(new PIC("9", "5", "9(05)V9(04)."), 4);
        /*"01  HOST-PRMVG                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  HOST-PRMAP                       PIC S9(13)V99 COMP-3.*/
        public DoubleBasis HOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SQL-NSAC                         PIC S9(4) COMP.*/
        public IntBasis SQL_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-COD-RETORNO                  PIC S9(4) COMP.*/
        public IntBasis SQL_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-CODPDT                     PIC S9(9) COMP.*/
        public IntBasis MVCOM_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  MVCOM-COD-RETORNO                PIC S9(4) COMP.*/
        public IntBasis MVCOM_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-DATA-MOV                   PIC  X(10).*/
        public StringBasis MVCOM_DATA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  MVCOM-AGENCIA                    PIC S9(4) COMP.*/
        public IntBasis MVCOM_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-OPERACAO                   PIC S9(4) COMP.*/
        public IntBasis MVCOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-CONTA                      PIC S9(13) COMP-3.*/
        public IntBasis MVCOM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  MVCOM-DIG                        PIC S9(4) COMP.*/
        public IntBasis MVCOM_DIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-SITUACAO                   PIC  X(1).*/
        public StringBasis MVCOM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  MVCOM-NSAS                       PIC S9(4) COMP.*/
        public IntBasis MVCOM_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  MVCOM-NSL                        PIC S9(9) COMP.*/
        public IntBasis MVCOM_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  MVCOM-NSL1                       PIC S9(4) COMP.*/
        public IntBasis MVCOM_NSL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PARC-PREMIO-IX                   PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis PARC_PREMIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"01  PROPAZ-NRPROPAZ                  PIC S9(13) COMP-3.*/
        public IntBasis PROPAZ_NRPROPAZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPAZ-AGELOTE                   PIC S9(4) COMP.*/
        public IntBasis PROPAZ_AGELOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPAZ-DTLOTE                    PIC S9(9) COMP.*/
        public IntBasis PROPAZ_DTLOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PROPAZ-NRLOTE                    PIC S9(4) COMP.*/
        public IntBasis PROPAZ_NRLOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPAZ-NRSEQLOTE                 PIC S9(4) COMP.*/
        public IntBasis PROPAZ_NRSEQLOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPAZ-CODPRODAZ                 PIC  X(3).*/
        public StringBasis PROPAZ_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"01  PROPAZ-DTQITBCO                  PIC  X(10).*/
        public StringBasis PROPAZ_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SEGV-DTINIVIG                  PIC  X(10).*/
        public StringBasis V0SEGV_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SEGV-DTRENOVA                  PIC  X(10).*/
        public StringBasis V0SEGV_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SEGV-DTRENOVA-I                PIC S9(04)    COMP.*/
        public IntBasis V0SEGV_DTRENOVA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COMPROPH-VLCOMISVG               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COMPROPH_VLCOMISVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COMPROPH-VLCOMISAP               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COMPROPH_VLCOMISAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COMPROPH-VALBASVG                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COMPROPH_VALBASVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COMPROPH-VALBASAP                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COMPROPH_VALBASAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0CCOR-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0CCOR_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RESG-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0RESG_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RESG-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RESG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  USUARIO                          PIC  X(08).*/
        public StringBasis USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01  V0RESG-DTCREDITO                 PIC  X(10).*/
        public StringBasis V0RESG_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RESG-NSAC                      PIC S9(4) COMP.*/
        public IntBasis V0RESG_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODEMP                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-ORIGAVISO                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VALADT                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTMOVTO                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTNASC                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
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
        /*"01    WSHOST-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01    V0PROP-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    WS-RESTO                  PIC S9(007)     COMP-3.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
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
        /*"01    WAUX-FLAG                 PIC X(01) VALUE 'S'.*/
        public StringBasis WAUX_FLAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"S");
        /*"01    VIND-CODRET               PIC S9(04)    COMP VALUE +0.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WORK-TAB-RAMO-CONJ.*/
        public VA0812B_WORK_TAB_RAMO_CONJ WORK_TAB_RAMO_CONJ { get; set; } = new VA0812B_WORK_TAB_RAMO_CONJ();
        public class VA0812B_WORK_TAB_RAMO_CONJ : VarBasis
        {
            /*"    05  N5WORK-TAB-RAMO-CONJ    OCCURS 30 TIMES.*/
            public ListBasis<VA0812B_N5WORK_TAB_RAMO_CONJ> N5WORK_TAB_RAMO_CONJ { get; set; } = new ListBasis<VA0812B_N5WORK_TAB_RAMO_CONJ>(30);
            public class VA0812B_N5WORK_TAB_RAMO_CONJ : VarBasis
            {
                /*"      10  TB-GRUPO-SUSEP              PIC S9(004) COMP.*/
                public IntBasis TB_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10  TB-RAMO-CONJ                PIC S9(004) COMP.*/
                public IntBasis TB_RAMO_CONJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10  TB-TAXA-RAMO-CONJ           PIC S9(003)V9(4) COMP-3.*/
                public DoubleBasis TB_TAXA_RAMO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
                /*"01  WORK-RAMO-CONJ.*/
            }
        }
        public VA0812B_WORK_RAMO_CONJ WORK_RAMO_CONJ { get; set; } = new VA0812B_WORK_RAMO_CONJ();
        public class VA0812B_WORK_RAMO_CONJ : VarBasis
        {
            /*"    05  WS-GRUPO-SUSEP-ANT            PIC S9(004) COMP.*/
            public IntBasis WS_GRUPO_SUSEP_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-RAMO-CONJ-ANT              PIC S9(004) COMP.*/
            public IntBasis WS_RAMO_CONJ_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-IND                        PIC S9(004) COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-IND1                       PIC S9(004) COMP.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WHOST-VLR-PERC-PREMIO         PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis WHOST_VLR_PERC_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05  WHOST-VLR-PERC-PREMIO-TOT     PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis WHOST_VLR_PERC_PREMIO_TOT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05  WS-SALVA                      PIC  X(020).*/
            public StringBasis WS_SALVA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"01  WORK-AREA.*/
        }
        public VA0812B_WORK_AREA WORK_AREA { get; set; } = new VA0812B_WORK_AREA();
        public class VA0812B_WORK_AREA : VarBasis
        {
            /*"    05      WS-DESCR.*/
            public VA0812B_WS_DESCR WS_DESCR { get; set; } = new VA0812B_WS_DESCR();
            public class VA0812B_WS_DESCR : VarBasis
            {
                /*"      10    WS-PARC                  PIC  X(005).*/
                public StringBasis WS_PARC { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10    WS-NUM-PARCELA           PIC  9(003).*/
                public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10    WS-RESTO-DESCR           PIC  X(112).*/
                public StringBasis WS_RESTO_DESCR { get; set; } = new StringBasis(new PIC("X", "112", "X(112)."), @"");
                /*"    05      TAB-FILIAL.*/
            }
            public VA0812B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA0812B_TAB_FILIAL();
            public class VA0812B_TAB_FILIAL : VarBasis
            {
                /*"      10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<VA0812B_FILLER_6> FILLER_6 { get; set; } = new ListBasis<VA0812B_FILLER_6>(9999);
                public class VA0812B_FILLER_6 : VarBasis
                {
                    /*"        15  TAB-AGENCIA              PIC  9(4).*/
                    public IntBasis TAB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"        15  TAB-FONTE                PIC  9(4).*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"    05 WS-NSA-9                      PIC 9(6).*/
                }
            }
            public IntBasis WS_NSA_9 { get; set; } = new IntBasis(new PIC("9", "6", "9(6)."));
            /*"    05 WS-NSA-R REDEFINES WS-NSA-9.*/
            private _REDEF_VA0812B_WS_NSA_R _ws_nsa_r { get; set; }
            public _REDEF_VA0812B_WS_NSA_R WS_NSA_R
            {
                get { _ws_nsa_r = new _REDEF_VA0812B_WS_NSA_R(); _.Move(WS_NSA_9, _ws_nsa_r); VarBasis.RedefinePassValue(WS_NSA_9, _ws_nsa_r, WS_NSA_9); _ws_nsa_r.ValueChanged += () => { _.Move(_ws_nsa_r, WS_NSA_9); }; return _ws_nsa_r; }
                set { VarBasis.RedefinePassValue(value, _ws_nsa_r, WS_NSA_9); }
            }  //Redefines
            public class _REDEF_VA0812B_WS_NSA_R : VarBasis
            {
                /*"      10 FILLER                      PIC X(3).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
                /*"      10 WS-NSA                      PIC 9(3).*/
                public IntBasis WS_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(3)."));
                /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/

                public _REDEF_VA0812B_WS_NSA_R()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                    WS_NSA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 WS-CONVENIO                   PIC 9(4).*/
            public IntBasis WS_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    05 WS-ACHEI                      PIC 9(1).*/
            public IntBasis WS_ACHEI { get; set; } = new IntBasis(new PIC("9", "1", "9(1)."));
            /*"    05 WNUM-CTA-CORRENTE.*/
            public VA0812B_WNUM_CTA_CORRENTE WNUM_CTA_CORRENTE { get; set; } = new VA0812B_WNUM_CTA_CORRENTE();
            public class VA0812B_WNUM_CTA_CORRENTE : VarBasis
            {
                /*"       10 WCOD-OPER-CONTA           PIC 9(4).*/
                public IntBasis WCOD_OPER_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                /*"       10 WNUM-CONTA                PIC 9(12).*/
                public IntBasis WNUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                /*"    05 WNUM-CTA-CORR-R REDEFINES WNUM-CTA-CORRENTE                                    PIC S9(016).*/
            }
            private _REDEF_IntBasis _wnum_cta_corr_r { get; set; }
            public _REDEF_IntBasis WNUM_CTA_CORR_R
            {
                get { _wnum_cta_corr_r = new _REDEF_IntBasis(new PIC("S9", "016", "S9(016).")); ; _.Move(WNUM_CTA_CORRENTE, _wnum_cta_corr_r); VarBasis.RedefinePassValue(WNUM_CTA_CORRENTE, _wnum_cta_corr_r, WNUM_CTA_CORRENTE); _wnum_cta_corr_r.ValueChanged += () => { _.Move(_wnum_cta_corr_r, WNUM_CTA_CORRENTE); }; return _wnum_cta_corr_r; }
                set { VarBasis.RedefinePassValue(value, _wnum_cta_corr_r, WNUM_CTA_CORRENTE); }
            }  //Redefines
            /*"    05 WS-NSL                        PIC 9(09).*/
            public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 WS-NSL-R                      REDEFINES       WS-NSL.*/
            private _REDEF_VA0812B_WS_NSL_R _ws_nsl_r { get; set; }
            public _REDEF_VA0812B_WS_NSL_R WS_NSL_R
            {
                get { _ws_nsl_r = new _REDEF_VA0812B_WS_NSL_R(); _.Move(WS_NSL, _ws_nsl_r); VarBasis.RedefinePassValue(WS_NSL, _ws_nsl_r, WS_NSL); _ws_nsl_r.ValueChanged += () => { _.Move(_ws_nsl_r, WS_NSL); }; return _ws_nsl_r; }
                set { VarBasis.RedefinePassValue(value, _ws_nsl_r, WS_NSL); }
            }  //Redefines
            public class _REDEF_VA0812B_WS_NSL_R : VarBasis
            {
                /*"       10 WS-SERIE-NSL               PIC 9(02).*/
                public IntBasis WS_SERIE_NSL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       10 WS-PROPOSTA-NSL            PIC 9(07).*/
                public IntBasis WS_PROPOSTA_NSL { get; set; } = new IntBasis(new PIC("9", "7", "9(07)."));
                /*"    05 WHORA-OPERACAO-WORK.*/

                public _REDEF_VA0812B_WS_NSL_R()
                {
                    WS_SERIE_NSL.ValueChanged += OnValueChanged;
                    WS_PROPOSTA_NSL.ValueChanged += OnValueChanged;
                }

            }
            public VA0812B_WHORA_OPERACAO_WORK WHORA_OPERACAO_WORK { get; set; } = new VA0812B_WHORA_OPERACAO_WORK();
            public class VA0812B_WHORA_OPERACAO_WORK : VarBasis
            {
                /*"       10 WHORA-HORA                 PIC  X(002).*/
                public StringBasis WHORA_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10 FILLER                     PIC  X(001)  VALUE '.'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"       10 WHORA-MINU                 PIC  X(002).*/
                public StringBasis WHORA_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10 FILLER                     PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"       10 WHORA-SEGU                 PIC  X(002).*/
                public StringBasis WHORA_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 WHORA-OPERACAO-WORK-R         REDEFINES       WHORA-OPERACAO-WORK           PIC  X(008).*/
            }
            private _REDEF_StringBasis _whora_operacao_work_r { get; set; }
            public _REDEF_StringBasis WHORA_OPERACAO_WORK_R
            {
                get { _whora_operacao_work_r = new _REDEF_StringBasis(new PIC("X", "008", "X(008).")); ; _.Move(WHORA_OPERACAO_WORK, _whora_operacao_work_r); VarBasis.RedefinePassValue(WHORA_OPERACAO_WORK, _whora_operacao_work_r, WHORA_OPERACAO_WORK); _whora_operacao_work_r.ValueChanged += () => { _.Move(_whora_operacao_work_r, WHORA_OPERACAO_WORK); }; return _whora_operacao_work_r; }
                set { VarBasis.RedefinePassValue(value, _whora_operacao_work_r, WHORA_OPERACAO_WORK); }
            }  //Redefines
            /*"    05 WHORA-OPERACAO.*/
            public VA0812B_WHORA_OPERACAO WHORA_OPERACAO { get; set; } = new VA0812B_WHORA_OPERACAO();
            public class VA0812B_WHORA_OPERACAO : VarBasis
            {
                /*"       10 WHORA-HORA-W               PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_HORA_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10 WHORA-MINU-W               PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_MINU_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10 WHORA-SEGU-W               PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_SEGU_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05 WHORA-OPERACAO-R              REDEFINES       WHORA-OPERACAO                PIC  9(006).*/
            }
            private _REDEF_IntBasis _whora_operacao_r { get; set; }
            public _REDEF_IntBasis WHORA_OPERACAO_R
            {
                get { _whora_operacao_r = new _REDEF_IntBasis(new PIC("9", "006", "9(006).")); ; _.Move(WHORA_OPERACAO, _whora_operacao_r); VarBasis.RedefinePassValue(WHORA_OPERACAO, _whora_operacao_r, WHORA_OPERACAO); _whora_operacao_r.ValueChanged += () => { _.Move(_whora_operacao_r, WHORA_OPERACAO); }; return _whora_operacao_r; }
                set { VarBasis.RedefinePassValue(value, _whora_operacao_r, WHORA_OPERACAO); }
            }  //Redefines
            /*"   05  WS-TRABALHO.*/
            public VA0812B_WS_TRABALHO WS_TRABALHO { get; set; } = new VA0812B_WS_TRABALHO();
            public class VA0812B_WS_TRABALHO : VarBasis
            {
                /*"       10  WS-PROPOSTA-E                PIC 9(13).*/
                public IntBasis WS_PROPOSTA_E { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"       10  WS-AGLOTE-E                  PIC 9(4).*/
                public IntBasis WS_AGLOTE_E { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                /*"       10  WS-DTLOTE-E                  PIC 9(9).*/
                public IntBasis WS_DTLOTE_E { get; set; } = new IntBasis(new PIC("9", "9", "9(9)."));
                /*"       10  WS-NRLOTE-E                  PIC 9(4).*/
                public IntBasis WS_NRLOTE_E { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                /*"       10  WS-SEQLOTE-E                 PIC 9(4).*/
                public IntBasis WS_SEQLOTE_E { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                /*"    05      DATA-SQL.*/
            }
        }
        public VA0812B_DATA_SQL DATA_SQL { get; set; } = new VA0812B_DATA_SQL();
        public class VA0812B_DATA_SQL : VarBasis
        {
            /*"      10    ANO-SQL                  PIC  9(004).*/
            public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"      10    MES-SQL                  PIC  9(002).*/
            public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"      10    DIA-SQL                  PIC  9(002).*/
            public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05      FLAG88                   PIC  9(001) VALUE 0.*/
        }
        public IntBasis FLAG88 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/
        public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    05      WFIM-V1AGENCEF           PIC  X(001) VALUE SPACES.*/
        public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    05 LK-CONTABIL.*/
        public VA0812B_LK_CONTABIL LK_CONTABIL { get; set; } = new VA0812B_LK_CONTABIL();
        public class VA0812B_LK_CONTABIL : VarBasis
        {
            /*"       10 LK-APOLICE          PIC S9(13) COMP-3    VALUE +0.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"       10 LK-FONTE            PIC S9(04) COMP      VALUE +0.*/
            public IntBasis LK_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"       10 LK-DTMOVTO          PIC X(10)            VALUE SPACES.*/
            public StringBasis LK_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"       10 LK-DTINIVIG         PIC X(10)            VALUE SPACES.*/
            public StringBasis LK_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"       10 LK-DTRENOVA         PIC X(10)            VALUE SPACES.*/
            public StringBasis LK_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"       10 LK-CODPRODAZ        PIC X(03)            VALUE SPACES.*/
            public StringBasis LK_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"       10 LK-CODOPER          PIC S9(04) COMP      VALUE +0.*/
            public IntBasis LK_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"       10 LK-VLOPER           PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis LK_VLOPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"       10 LK-RETCODE          PIC S9(04) COMP      VALUE +0.*/
            public IntBasis LK_RETCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"       10 LK-MENSAGEM         PIC X(50)            VALUE SPACES.*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"");
            /*"    05 LK-VA0101S.*/
        }
        public VA0812B_LK_VA0101S LK_VA0101S { get; set; } = new VA0812B_LK_VA0101S();
        public class VA0812B_LK_VA0101S : VarBasis
        {
            /*"       10 LK101-CODPRODAZ       PIC X(03)            VALUE ' '.*/
            public StringBasis LK101_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"       10 LK101-QTD-VIDAS       PIC S9(09)    COMP   VALUE +0.*/
            public IntBasis LK101_QTD_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"       10 LK101-PREMIO          PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis LK101_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"       10 LK101-MENSAGEM        PIC X(50)            VALUE ' '.*/
            public StringBasis LK101_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @" ");
            /*"       10 LK101-RETCODE         PIC S9(04)    COMP   VALUE +9.*/
            public IntBasis LK101_RETCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +9);
            /*"    05 LK-MOD11CF.*/
        }
        public VA0812B_LK_MOD11CF LK_MOD11CF { get; set; } = new VA0812B_LK_MOD11CF();
        public class VA0812B_LK_MOD11CF : VarBasis
        {
            /*"       10 LK-NUMERO                 PIC 9(15).*/
            public IntBasis LK_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"       10 FILLER                    PIC S9(04) COMP.*/
            public IntBasis FILLER_12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"       10 LK-DV                     PIC 9(01).*/
            public IntBasis LK_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05 WS-NRPROPAZ                  PIC 9(12).*/
        }
        public IntBasis WS_NRPROPAZ { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
        /*"    05 WS-NRPROPAZ-R                REDEFINES       WS-NRPROPAZ.*/
        private _REDEF_VA0812B_WS_NRPROPAZ_R _ws_nrpropaz_r { get; set; }
        public _REDEF_VA0812B_WS_NRPROPAZ_R WS_NRPROPAZ_R
        {
            get { _ws_nrpropaz_r = new _REDEF_VA0812B_WS_NRPROPAZ_R(); _.Move(WS_NRPROPAZ, _ws_nrpropaz_r); VarBasis.RedefinePassValue(WS_NRPROPAZ, _ws_nrpropaz_r, WS_NRPROPAZ); _ws_nrpropaz_r.ValueChanged += () => { _.Move(_ws_nrpropaz_r, WS_NRPROPAZ); }; return _ws_nrpropaz_r; }
            set { VarBasis.RedefinePassValue(value, _ws_nrpropaz_r, WS_NRPROPAZ); }
        }  //Redefines
        public class _REDEF_VA0812B_WS_NRPROPAZ_R : VarBasis
        {
            /*"       10 WS-NRPROPAZ-1             PIC 9(11).*/
            public IntBasis WS_NRPROPAZ_1 { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
            /*"       10 WS-NRPROPAZ-1-R           REDEFINES          WS-NRPROPAZ-1.*/
            private _REDEF_VA0812B_WS_NRPROPAZ_1_R _ws_nrpropaz_1_r { get; set; }
            public _REDEF_VA0812B_WS_NRPROPAZ_1_R WS_NRPROPAZ_1_R
            {
                get { _ws_nrpropaz_1_r = new _REDEF_VA0812B_WS_NRPROPAZ_1_R(); _.Move(WS_NRPROPAZ_1, _ws_nrpropaz_1_r); VarBasis.RedefinePassValue(WS_NRPROPAZ_1, _ws_nrpropaz_1_r, WS_NRPROPAZ_1); _ws_nrpropaz_1_r.ValueChanged += () => { _.Move(_ws_nrpropaz_1_r, WS_NRPROPAZ_1); }; return _ws_nrpropaz_1_r; }
                set { VarBasis.RedefinePassValue(value, _ws_nrpropaz_1_r, WS_NRPROPAZ_1); }
            }  //Redefines
            public class _REDEF_VA0812B_WS_NRPROPAZ_1_R : VarBasis
            {
                /*"          15 WS-SERIE               PIC 9(02).*/
                public IntBasis WS_SERIE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"          15 WS-DV-SERIE            PIC 9(01).*/
                public IntBasis WS_DV_SERIE { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"          15 WS-PROPOSTA            PIC 9(08).*/
                public IntBasis WS_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"       10 WS-DV-PROP                PIC 9(01).*/

                public _REDEF_VA0812B_WS_NRPROPAZ_1_R()
                {
                    WS_SERIE.ValueChanged += OnValueChanged;
                    WS_DV_SERIE.ValueChanged += OnValueChanged;
                    WS_PROPOSTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DV_PROP { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05 WS-REGISTROS              PIC  9(9)      VALUE  0.*/

            public _REDEF_VA0812B_WS_NRPROPAZ_R()
            {
                WS_NRPROPAZ_1.ValueChanged += OnValueChanged;
                WS_NRPROPAZ_1_R.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"    05 WS-QTCREFET               PIC  9(9)      VALUE  0.*/
        public IntBasis WS_QTCREFET { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"    05 WS-ACG-TOTCREFET          PIC  9(13)V99  VALUE  0.*/
        public DoubleBasis WS_ACG_TOTCREFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
        /*"    05 WD-ACG-TOTCREFET          PIC  ZZZ.ZZZ.ZZ9,99-.*/
        public DoubleBasis WD_ACG_TOTCREFET { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
        /*"    05 WS-ACG-TOTCRNEFET         PIC  9(13)V99  VALUE  0.*/
        public DoubleBasis WS_ACG_TOTCRNEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
        /*"    05 WD-ACG-TOTCRNEFET         PIC  ZZZ.ZZZ.ZZ9,99-.*/
        public DoubleBasis WD_ACG_TOTCRNEFET { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
        /*"    05 WS-PRM-TOT                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_PRM_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"    05 WS-PRM-DIF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_PRM_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"    05 WS-PREMIO-TOTAL           PIC S9(13)V99 COMP-3 VALUE ZERO*/
        public DoubleBasis WS_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"    05 WS-PREMIO-TOTAL-AC        PIC S9(13)V99 COMP-3 VALUE ZERO*/
        public DoubleBasis WS_PREMIO_TOTAL_AC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"    05 AC-L-V1AGENCEF            PIC  9(7) VALUE ZEROS.*/
        public IntBasis AC_L_V1AGENCEF { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
        /*"    05 WS-NRAVISO                PIC  9(009)    VALUE  0.*/
        public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05 FILLER                    REDEFINES      WS-NRAVISO.*/
        private _REDEF_VA0812B_FILLER_13 _filler_13 { get; set; }
        public _REDEF_VA0812B_FILLER_13 FILLER_13
        {
            get { _filler_13 = new _REDEF_VA0812B_FILLER_13(); _.Move(WS_NRAVISO, _filler_13); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_13, WS_NRAVISO); _filler_13.ValueChanged += () => { _.Move(_filler_13, WS_NRAVISO); }; return _filler_13; }
            set { VarBasis.RedefinePassValue(value, _filler_13, WS_NRAVISO); }
        }  //Redefines
        public class _REDEF_VA0812B_FILLER_13 : VarBasis
        {
            /*"      10 WS-AGEAVISO             PIC  9(004).*/
            public IntBasis WS_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      10 WS-NSAC                 PIC  9(005).*/
            public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05 WS-SUBS                   PIC  9(005)    VALUE ZEROS.*/

            public _REDEF_VA0812B_FILLER_13()
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
        /*"    05 WFIM-VGRAMOCOMP           PIC  X(003)    VALUE ' '.*/
        public StringBasis WFIM_VGRAMOCOMP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
        /*"    05 WFIM-TAB-RAMO             PIC  X(003)    VALUE ' '.*/
        public StringBasis WFIM_TAB_RAMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
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
        private _REDEF_VA0812B_FILLER_14 _filler_14 { get; set; }
        public _REDEF_VA0812B_FILLER_14 FILLER_14
        {
            get { _filler_14 = new _REDEF_VA0812B_FILLER_14(); _.Move(WDATA_REL, _filler_14); VarBasis.RedefinePassValue(WDATA_REL, _filler_14, WDATA_REL); _filler_14.ValueChanged += () => { _.Move(_filler_14, WDATA_REL); }; return _filler_14; }
            set { VarBasis.RedefinePassValue(value, _filler_14, WDATA_REL); }
        }  //Redefines
        public class _REDEF_VA0812B_FILLER_14 : VarBasis
        {
            /*"      10     WDAT-REL-ANO      PIC  9(004).*/
            public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      10     FILLER            PIC  X(001).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10     WDAT-REL-MES      PIC  9(002).*/
            public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      10     FILLER            PIC  X(001).*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10     WDAT-REL-DIA      PIC  9(002).*/
            public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  WS-RESULT             PIC  9(006)    VALUE   ZEROS.*/

            public _REDEF_VA0812B_FILLER_14()
            {
                WDAT_REL_ANO.ValueChanged += OnValueChanged;
                FILLER_15.ValueChanged += OnValueChanged;
                WDAT_REL_MES.ValueChanged += OnValueChanged;
                FILLER_16.ValueChanged += OnValueChanged;
                WDAT_REL_DIA.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05  AUX-ANO   PIC  9(004)    VALUE   ZEROS.*/
        public IntBasis AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05  FILLER    REDEFINES      AUX-ANO.*/
        private _REDEF_VA0812B_FILLER_17 _filler_17 { get; set; }
        public _REDEF_VA0812B_FILLER_17 FILLER_17
        {
            get { _filler_17 = new _REDEF_VA0812B_FILLER_17(); _.Move(AUX_ANO, _filler_17); VarBasis.RedefinePassValue(AUX_ANO, _filler_17, AUX_ANO); _filler_17.ValueChanged += () => { _.Move(_filler_17, AUX_ANO); }; return _filler_17; }
            set { VarBasis.RedefinePassValue(value, _filler_17, AUX_ANO); }
        }  //Redefines
        public class _REDEF_VA0812B_FILLER_17 : VarBasis
        {
            /*"          10 AUX-ANO1           PIC  9(002).*/
            public IntBasis AUX_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"          10 AUX-ANO2           PIC  9(002).*/
            public IntBasis AUX_ANO2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/

            public _REDEF_VA0812B_FILLER_17()
            {
                AUX_ANO1.ValueChanged += OnValueChanged;
                AUX_ANO2.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"    05      WABEND.*/
        public VA0812B_WABEND WABEND { get; set; } = new VA0812B_WABEND();
        public class VA0812B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VA0812B  '.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0812B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      LOCALIZA-ABEND-1.*/
        }
        public VA0812B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0812B_LOCALIZA_ABEND_1();
        public class VA0812B_LOCALIZA_ABEND_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    05      LOCALIZA-ABEND-2.*/
        }
        public VA0812B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0812B_LOCALIZA_ABEND_2();
        public class VA0812B_LOCALIZA_ABEND_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"01  WS-TIME.*/
        }
        public VA0812B_WS_TIME WS_TIME { get; set; } = new VA0812B_WS_TIME();
        public class VA0812B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  ON-INTERVAL                      PIC 9(06) VALUE 10000.*/
        }
        public IntBasis ON_INTERVAL { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"), 10000);
        /*"01  ON-COUNTER                       PIC 9(06) VALUE 0.*/
        public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01    WS-HORAS.*/
        public VA0812B_WS_HORAS WS_HORAS { get; set; } = new VA0812B_WS_HORAS();
        public class VA0812B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA0812B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA0812B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA0812B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA0812B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  FILLER                PIC  X(002).*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VA0812B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    FILLER_27.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA0812B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA0812B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA0812B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA0812B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  FILLER                PIC  X(002).*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03  SIT                       PIC S9(015)    COMP.*/

                public _REDEF_VA0812B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    FILLER_28.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis SIT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  03  SFT                       PIC S9(015)    COMP.*/
            public IntBasis SFT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  03  SII                       PIC S9(004)    COMP.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  TOTAIS-ROT.*/
        }
        public VA0812B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA0812B_TOTAIS_ROT();
        public class VA0812B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 30 TIMES.*/
            public ListBasis<VA0812B_FILLER_29> FILLER_29 { get; set; } = new ListBasis<VA0812B_FILLER_29>(30);
            public class VA0812B_FILLER_29 : VarBasis
            {
                /*"        05  STT                       PIC S9(015)    COMP.*/
                public IntBasis STT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"        05  SQT                       PIC S9(015)    COMP.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01  AUX-TABELAS.*/
            }
        }
        public VA0812B_AUX_TABELAS AUX_TABELAS { get; set; } = new VA0812B_AUX_TABELAS();
        public class VA0812B_AUX_TABELAS : VarBasis
        {
            /*"  03          WTABG-VALORES.*/
            public VA0812B_WTABG_VALORES WTABG_VALORES { get; set; } = new VA0812B_WTABG_VALORES();
            public class VA0812B_WTABG_VALORES : VarBasis
            {
                /*"    05        WTABG-OCORREPRD     OCCURS       2000  TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<VA0812B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<VA0812B_WTABG_OCORREPRD>(2000);
                public class VA0812B_WTABG_OCORREPRD : VarBasis
                {
                    /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                    public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WTABG-OCORRETIP     OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<VA0812B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<VA0812B_WTABG_OCORRETIP>(003);
                    public class VA0812B_WTABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WTABG-TIPO          PIC  X(001).*/
                        public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<VA0812B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<VA0812B_WTABG_OCORRESIT>(002);
                        public class VA0812B_WTABG_OCORRESIT : VarBasis
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
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.VG080 VG080 { get; set; } = new Dclgens.VG080();
        public Dclgens.VG081 VG081 { get; set; } = new Dclgens.VG081();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public VA0812B_CVGRAMOCOMP CVGRAMOCOMP { get; set; } = new VA0812B_CVGRAMOCOMP();
        public VA0812B_V1AGENCEF V1AGENCEF { get; set; } = new VA0812B_V1AGENCEF();
        public VA0812B_V0PRODUTO V0PRODUTO { get; set; } = new VA0812B_V0PRODUTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETCRE_FILE_NAME_P, string RETINV_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETCRE.SetFile(RETCRE_FILE_NAME_P);
                RETINV.SetFile(RETINV_FILE_NAME_P);

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
            /*" -904- DISPLAY ' ' */
            _.Display($" ");

            /*" -906- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -918- DISPLAY 'PROGRAMA EM EXECUCAO VA0812B   - ' 'VERSAO V.34 - DEMANDA RITM0002669 ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VA0812B   - VERSAO V.34 - DEMANDA RITM0002669 FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -920- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -922- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -923- OPEN INPUT RETCRE. */
            RETCRE.Open(RETCRE_RECORD);

            /*" -925- OPEN OUTPUT RETINV. */
            RETINV.Open(RETINV_RECORD);

            /*" -927- MOVE ZEROS TO TAB-FILIAL. */
            _.Move(0, WORK_AREA.TAB_FILIAL);

            /*" -929- PERFORM 3000-00-DECLARE-V1AGENCEF THRU 3000-FIM. */

            M_3000_00_DECLARE_V1AGENCEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/


            /*" -931- PERFORM 3100-00-FETCH-V1AGENCEF THRU 3100-FIM. */

            M_3100_00_FETCH_V1AGENCEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_FIM*/


            /*" -932- IF WFIM-V1AGENCEF NOT EQUAL SPACES */

            if (!WFIM_V1AGENCEF.IsEmpty())
            {

                /*" -933- DISPLAY '0000 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"0000 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -935- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -938- PERFORM 3200-00-CARREGA-FILIAL THRU 3200-FIM UNTIL WFIM-V1AGENCEF EQUAL 'S' . */

            while (!(WFIM_V1AGENCEF == "S"))
            {

                M_3200_00_CARREGA_FILIAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_FIM*/

            }

            /*" -939- MOVE '0001-INICIO  ' TO PARAGRAFO. */
            _.Move("0001-INICIO  ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -940- MOVE 'SELECT ... FROM SEGUROS.V1SISTEMA  ' TO COMANDO. */
            _.Move("SELECT ... FROM SEGUROS.V1SISTEMA  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -942- MOVE LOW-VALUES TO TOTAIS-ROT. */
            _.Move("", TOTAIS_ROT);

            /*" -948- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -952- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -953- DISPLAY 'SISTEMA NAO ENCONTRADO' */
                    _.Display($"SISTEMA NAO ENCONTRADO");

                    /*" -954- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -955- ELSE */
                }
                else
                {


                    /*" -956- DISPLAY 'PROBLEMAS NO ACESSO A V0SISTEMA' */
                    _.Display($"PROBLEMAS NO ACESSO A V0SISTEMA");

                    /*" -958- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -959- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -960- MOVE WS-TIME-N TO WHORA-OPERACAO-R. */
            _.Move(WS_TIME.WS_TIME_N, WORK_AREA.WHORA_OPERACAO_R);

            /*" -961- MOVE WHORA-HORA-W TO WHORA-HORA. */
            _.Move(WORK_AREA.WHORA_OPERACAO.WHORA_HORA_W, WORK_AREA.WHORA_OPERACAO_WORK.WHORA_HORA);

            /*" -962- MOVE WHORA-MINU-W TO WHORA-MINU. */
            _.Move(WORK_AREA.WHORA_OPERACAO.WHORA_MINU_W, WORK_AREA.WHORA_OPERACAO_WORK.WHORA_MINU);

            /*" -963- MOVE WHORA-SEGU-W TO WHORA-SEGU. */
            _.Move(WORK_AREA.WHORA_OPERACAO.WHORA_SEGU_W, WORK_AREA.WHORA_OPERACAO_WORK.WHORA_SEGU);

            /*" -965- MOVE WHORA-OPERACAO-WORK-R TO HHORA-OPERACAO. */
            _.Move(WORK_AREA.WHORA_OPERACAO_WORK_R, HHORA_OPERACAO);

            /*" -967- PERFORM R0050-00-INICIO THRU R0050-99-SAIDA. */

            R0050_00_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/


            /*" -967- PERFORM 0001-INICIO-PROCESSO. */

            M_0001_INICIO_PROCESSO(true);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -948- EXEC SQL SELECT DTMOVABE INTO :DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM= 'VA' WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DTMOVABE, DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0001-INICIO-PROCESSO */
        private void M_0001_INICIO_PROCESSO(bool isPerform = false)
        {
            /*" -975- MOVE '0001-INICIO-PROCESSO' TO PARAGRAFO. */
            _.Move("0001-INICIO-PROCESSO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -977- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -978- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -979- DISPLAY '*** VA0812B *** MOVIMENTO RETORNO VAZIO' */
                    _.Display($"*** VA0812B *** MOVIMENTO RETORNO VAZIO");

                    /*" -981- GO TO 0001-FIM-NORMAL. */

                    M_0001_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADER);
                _.Move(RETCRE.Value, RET_CADASTRAMENTO);
                _.Move(RETCRE.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -982- IF RA-COD-REG NOT EQUAL 'A' */

            if (RET_HEADER.RA_COD_REG != "A")
            {

                /*" -983- DISPLAY '*** VA0812B *** FITA SEM HEADER' */
                _.Display($"*** VA0812B *** FITA SEM HEADER");

                /*" -985- GO TO 0001-FIM-ANORMAL. */

                M_0001_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -986- MOVE RA-NSA TO WS-NSA-9. */
            _.Move(RET_HEADER.RA_NSA, WORK_AREA.WS_NSA_9);

            /*" -988- MOVE WS-NSA TO SQL-NSAC. */
            _.Move(WORK_AREA.WS_NSA_R.WS_NSA, SQL_NSAC);

            /*" -991- MOVE RA-COD-CONVENIO TO WS-CONVENIO WHOST-CODCONV. */
            _.Move(RET_HEADER.RA_COD_CONVENIO, WORK_AREA.WS_CONVENIO, WHOST_CODCONV);

            /*" -992- MOVE RA-COD-CONVENIO TO AUX-CONVENIO */
            _.Move(RET_HEADER.RA_COD_CONVENIO, AUX_CONVENIO);

            /*" -994- MOVE RA-NSA TO AUX-NSAC. */
            _.Move(RET_HEADER.RA_NSA, AUX_NSAC);

            /*" -995- IF WS-CONVENIO = 6038 */

            if (WORK_AREA.WS_CONVENIO == 6038)
            {

                /*" -997- ADD 2000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 2000;
            }


            /*" -998- IF WS-CONVENIO = 6065 */

            if (WORK_AREA.WS_CONVENIO == 6065)
            {

                /*" -1000- ADD 10000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 10000;
            }


            /*" -1001- IF WS-CONVENIO = 6039 */

            if (WORK_AREA.WS_CONVENIO == 6039)
            {

                /*" -1003- ADD 3000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 3000;
            }


            /*" -1004- IF WS-CONVENIO = 6068 */

            if (WORK_AREA.WS_CONVENIO == 6068)
            {

                /*" -1006- ADD 12000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 12000;
            }


            /*" -1007- IF WS-CONVENIO = 6040 */

            if (WORK_AREA.WS_CONVENIO == 6040)
            {

                /*" -1009- ADD 4000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 4000;
            }


            /*" -1010- IF WS-CONVENIO = 6069 */

            if (WORK_AREA.WS_CONVENIO == 6069)
            {

                /*" -1012- ADD 13000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 13000;
            }


            /*" -1013- IF WS-CONVENIO = 6041 */

            if (WORK_AREA.WS_CONVENIO == 6041)
            {

                /*" -1015- ADD 5000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 5000;
            }


            /*" -1016- IF WS-CONVENIO = 6070 */

            if (WORK_AREA.WS_CONVENIO == 6070)
            {

                /*" -1018- ADD 14000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 14000;
            }


            /*" -1019- IF WS-CONVENIO = 6042 */

            if (WORK_AREA.WS_CONVENIO == 6042)
            {

                /*" -1021- ADD 6000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 6000;
            }


            /*" -1022- IF WS-CONVENIO = 6071 */

            if (WORK_AREA.WS_CONVENIO == 6071)
            {

                /*" -1024- ADD 15000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 15000;
            }


            /*" -1025- IF WS-CONVENIO = 6036 */

            if (WORK_AREA.WS_CONVENIO == 6036)
            {

                /*" -1027- ADD 9000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 9000;
            }


            /*" -1028- IF WS-CONVENIO = 6075 */

            if (WORK_AREA.WS_CONVENIO == 6075)
            {

                /*" -1030- ADD 18000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 18000;
            }


            /*" -1031- IF WS-CONVENIO = 6090 */

            if (WORK_AREA.WS_CONVENIO == 6090)
            {

                /*" -1033- ADD 25000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 25000;
            }


            /*" -1034- IF WS-CONVENIO = 6129 */

            if (WORK_AREA.WS_CONVENIO == 6129)
            {

                /*" -1036- ADD 27000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 27000;
            }


            /*" -1037- IF WS-CONVENIO = 6132 */

            if (WORK_AREA.WS_CONVENIO == 6132)
            {

                /*" -1039- ADD 28000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 28000;
            }


            /*" -1040- IF WS-CONVENIO = 6131 */

            if (WORK_AREA.WS_CONVENIO == 6131)
            {

                /*" -1042- ADD 29000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 29000;
            }


            /*" -1043- IF WS-CONVENIO = 6153 */

            if (WORK_AREA.WS_CONVENIO == 6153)
            {

                /*" -1045- ADD 30000 TO SQL-NSAC. */
                SQL_NSAC.Value = SQL_NSAC + 30000;
            }


            /*" -1046- MOVE RA-AA-GERACAO TO ANO-SQL. */
            _.Move(RET_HEADER.RA_DATA_GERACAO.RA_AA_GERACAO, DATA_SQL.ANO_SQL);

            /*" -1047- MOVE RA-MM-GERACAO TO MES-SQL. */
            _.Move(RET_HEADER.RA_DATA_GERACAO.RA_MM_GERACAO, DATA_SQL.MES_SQL);

            /*" -1048- MOVE RA-DD-GERACAO TO DIA-SQL. */
            _.Move(RET_HEADER.RA_DATA_GERACAO.RA_DD_GERACAO, DATA_SQL.DIA_SQL);

            /*" -1050- MOVE DATA-SQL TO FITCEF-DTRET. */
            _.Move(DATA_SQL, FITCEF_DTRET);

            /*" -1052- MOVE RA-VERSAO-LAYOUT TO FITCEF-VERSAO. */
            _.Move(RET_HEADER.RA_VERSAO_LAYOUT, FITCEF_VERSAO);

            /*" -1054- PERFORM 0090-MONTA-AVISO THRU 0090-FIM. */

            M_0090_MONTA_AVISO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0090_FIM*/


            /*" -1055- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -1056- DISPLAY '*** VA0812B *** FITA SEM MOVIMENTO ' */
                    _.Display($"*** VA0812B *** FITA SEM MOVIMENTO ");

                    /*" -1058- GO TO 0001-FIM-NORMAL. */

                    M_0001_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADER);
                _.Move(RETCRE.Value, RET_CADASTRAMENTO);
                _.Move(RETCRE.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1059- IF RA-COD-REG NOT EQUAL 'F' AND 'Z' */

            if (!RET_HEADER.RA_COD_REG.In("F", "Z"))
            {

                /*" -1060- DISPLAY '*** VA0812B *** COD REGISTRO NAO ESPERADO' */
                _.Display($"*** VA0812B *** COD REGISTRO NAO ESPERADO");

                /*" -1062- GO TO 0001-FIM-ANORMAL. */

                M_0001_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -1063- IF RA-COD-REG EQUAL 'Z' */

            if (RET_HEADER.RA_COD_REG == "Z")
            {

                /*" -1064- DISPLAY '*** VA0812B *** NAO HA RETORNO DE CREDITO' */
                _.Display($"*** VA0812B *** NAO HA RETORNO DE CREDITO");

                /*" -1066- GO TO 0001-FIM-NORMAL. */

                M_0001_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -1067- DISPLAY '*** VA0812B *** PROCESSANDO ...' . */
            _.Display($"*** VA0812B *** PROCESSANDO ...");

            /*" -1071- PERFORM 0020-PROCESSA THRU 0020-FIM UNTIL WS-EOF = 1 OR RA-COD-REG NOT EQUAL 'F' . */

            while (!(WS_EOF == 1 || RET_HEADER.RA_COD_REG != "F"))
            {

                M_0020_PROCESSA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

            }

            /*" -1072- IF WS-EOF = 1 */

            if (WS_EOF == 1)
            {

                /*" -1073- DISPLAY '*** VA0812B *** FITA SEM TRAILLER' */
                _.Display($"*** VA0812B *** FITA SEM TRAILLER");

                /*" -1074- GO TO 0001-FIM-ANORMAL */

                M_0001_FIM_ANORMAL(); //GOTO
                return;

                /*" -1075- ELSE */
            }
            else
            {


                /*" -1076- IF RA-COD-REG NOT EQUAL 'Z' */

                if (RET_HEADER.RA_COD_REG != "Z")
                {

                    /*" -1077- DISPLAY '*** VA0812B *** COD REGISTRO NAO ESPERADO' */
                    _.Display($"*** VA0812B *** COD REGISTRO NAO ESPERADO");

                    /*" -1079- GO TO 0001-FIM-ANORMAL. */

                    M_0001_FIM_ANORMAL(); //GOTO
                    return;
                }

            }


            /*" -1080- DISPLAY '*** VA0812B *** CREDITOS RETORNADOS ' WS-REGISTROS. */
            _.Display($"*** VA0812B *** CREDITOS RETORNADOS {WS_REGISTROS}");

            /*" -1081- MOVE WS-ACG-TOTCREFET TO WD-ACG-TOTCREFET */
            _.Move(WS_ACG_TOTCREFET, WD_ACG_TOTCREFET);

            /*" -1084- DISPLAY '*** VA0812B *** CREDITOS EFETUADOS  ' WD-ACG-TOTCREFET. */
            _.Display($"*** VA0812B *** CREDITOS EFETUADOS  {WD_ACG_TOTCREFET}");

            /*" -1085- MOVE WS-ACG-TOTCRNEFET TO WD-ACG-TOTCRNEFET */
            _.Move(WS_ACG_TOTCRNEFET, WD_ACG_TOTCRNEFET);

            /*" -1089- DISPLAY '*** VA0812B *** CREDITOS NAO EFET   ' WD-ACG-TOTCRNEFET. */
            _.Display($"*** VA0812B *** CREDITOS NAO EFET   {WD_ACG_TOTCRNEFET}");

            /*" -1091- PERFORM 0050-GERA-FITACEF THRU 0050-FIM. */

            M_0050_GERA_FITACEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0050_FIM*/


            /*" -1093- IF WS-CONVENIO NOT EQUAL 6075 AND 6090 AND 6129 AND 6132 AND 6131 AND 6153 */

            if (!WORK_AREA.WS_CONVENIO.In("6075", "6090", "6129", "6132", "6131", "6153"))
            {

                /*" -1095- PERFORM 0075-SOLICITA-RELAT THRU 0075-FIM. */

                M_0075_SOLICITA_RELAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0075_FIM*/

            }


            /*" -1097- IF WS-CONVENIO EQUAL 6131 OR 6090 */

            if (WORK_AREA.WS_CONVENIO.In("6131", "6090"))
            {

                /*" -1098- IF AUX-VLPRMTOT NOT EQUAL ZEROS */

                if (AUX_VLPRMTOT != 00)
                {

                    /*" -1098- PERFORM 0100-INSERT-AVISOS THRU 0100-FIM. */

                    M_0100_INSERT_AVISOS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

                }

            }


        }

        [StopWatch]
        /*" M-0001-FIM-NORMAL */
        private void M_0001_FIM_NORMAL(bool isPerform = false)
        {
            /*" -1108- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1110- DISPLAY ' PROCESSO EXECUTAR COM COMMIT           ' */
            _.Display($" PROCESSO EXECUTAR COM COMMIT           ");

            /*" -1111- DISPLAY ' PROCESSO EXECUTAR COM COMMIT           ' */
            _.Display($" PROCESSO EXECUTAR COM COMMIT           ");

            /*" -1113- DISPLAY ' PROCESSO EXECUTAR COM COMMIT           ' */
            _.Display($" PROCESSO EXECUTAR COM COMMIT           ");

            /*" -1114- CLOSE RETCRE. */
            RETCRE.Close();

            /*" -1116- CLOSE RETINV. */
            RETINV.Close();

            /*" -1118- DISPLAY '*** VA0812B *** TERMINO NORMAL' . */
            _.Display($"*** VA0812B *** TERMINO NORMAL");

            /*" -1120- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1120- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0001-FIM-ANORMAL */
        private void M_0001_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -1124- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1127- CLOSE RETCRE. */
            RETCRE.Close();

            /*" -1129- CLOSE RETINV. */
            RETINV.Close();

            /*" -1131- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1131- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0020-PROCESSA */
        private void M_0020_PROCESSA(bool isPerform = false)
        {
            /*" -1146- MOVE '0020-PROCESSA ..    ' TO PARAGRAFO. */
            _.Move("0020-PROCESSA ..    ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1148- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1152- ADD 1 TO AC-LIDOS ON-COUNTER. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            ON_COUNTER.Value = ON_COUNTER + 1;

            /*" -1154- MOVE 'S' TO WAUX-FLAG. */
            _.Move("S", WAUX_FLAG);

            /*" -1156- IF AC-LIDOS EQUAL 1 OR ON-COUNTER EQUAL ON-INTERVAL */

            if (WORK_AREA.AC_LIDOS == 1 || ON_COUNTER == ON_INTERVAL)
            {

                /*" -1157- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1158- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WS_TIME}"
                .Display();

                /*" -1160- MOVE 0 TO ON-COUNTER. */
                _.Move(0, ON_COUNTER);
            }


            /*" -1161- IF RF-COD-RETORNO = 0 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 0)
            {

                /*" -1163- ADD 1 TO WS-QTCREFET. */
                WS_QTCREFET.Value = WS_QTCREFET + 1;
            }


            /*" -1164- MOVE RF-NSA TO MVCOM-NSAS */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA, MVCOM_NSAS);

            /*" -1165- MOVE RF-NSL TO MVCOM-NSL */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, MVCOM_NSL);

            /*" -1166- MOVE RF-VALOR TO PARC-PREMIO-IX. */
            _.Move(RET_CADASTRAMENTO.RF_VALOR, PARC_PREMIO_IX);

            /*" -1174- MOVE 0 TO WS-ACHEI. */
            _.Move(0, WORK_AREA.WS_ACHEI);

            /*" -1176- IF RF-COD-RETORNO EQUAL ZEROS AND RF-COD-MOVIMENTO EQUAL 2 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00 && RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 2)
            {

                /*" -1178- IF WS-CONVENIO EQUAL 6131 OR 6090 */

                if (WORK_AREA.WS_CONVENIO.In("6131", "6090"))
                {

                    /*" -1182- PERFORM R8000-00-TRATA-DESPESAS THRU R8000-99-SAIDA. */

                    R8000_00_TRATA_DESPESAS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

                }

            }


            /*" -1183- IF WS-CONVENIO NOT EQUAL 6075 */

            if (WORK_AREA.WS_CONVENIO != 6075)
            {

                /*" -1185- IF WS-CONVENIO EQUAL 6090 OR 6129 OR 6132 OR 6131 OR 6153 */

                if (WORK_AREA.WS_CONVENIO.In("6090", "6129", "6132", "6131", "6153"))
                {

                    /*" -1186- PERFORM 0035-LOCALIZA-DEVMULTI THRU 0035-FIM */

                    M_0035_LOCALIZA_DEVMULTI(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0035_FIM*/


                    /*" -1187- ELSE */
                }
                else
                {


                    /*" -1188- IF WS-CONVENIO NOT EQUAL 6039 AND 6068 */

                    if (!WORK_AREA.WS_CONVENIO.In("6039", "6068"))
                    {

                        /*" -1189- PERFORM 0031-LOCALIZA-OUTROS THRU 0031-FIM */

                        M_0031_LOCALIZA_OUTROS(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0031_FIM*/


                        /*" -1190- ELSE */
                    }
                    else
                    {


                        /*" -1191- PERFORM 0041-LOCALIZA-6039 THRU 0041-FIM */

                        M_0041_LOCALIZA_6039(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0041_FIM*/


                        /*" -1192- ELSE */
                    }

                }

            }
            else
            {


                /*" -1194- PERFORM 0060-LOCALIZA-6075 THRU 0060-FIM. */

                M_0060_LOCALIZA_6075(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0060_FIM*/

            }


            /*" -1195- IF WS-ACHEI = 0 */

            if (WORK_AREA.WS_ACHEI == 0)
            {

                /*" -1196- WRITE RETINV-RECORD FROM RETCRE-RECORD */
                _.Move(RETCRE_RECORD.GetMoveValues(), RETINV_RECORD);

                RETINV.Write(RETINV_RECORD.GetMoveValues().ToString());

                /*" -1197- ELSE */
            }
            else
            {


                /*" -1198- PERFORM 0025-ATUALIZA-FITASASSE THRU 0025-FIM */

                M_0025_ATUALIZA_FITASASSE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0025_FIM*/


                /*" -1199- MOVE RF-NRCERTIF TO VGFOLLOW-NUM-CERTIFICADO */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NRCERTIF, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO);

                /*" -1200- MOVE RF-NSAS TO VGFOLLOW-NUM-NOSSA-FITA */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NSAS, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA);

                /*" -1201- MOVE RF-NSL TO VGFOLLOW-NUM-LANCAMENTO */
                _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO);

                /*" -1202- PERFORM 8800-UPDATE-FOLLOWUP THRU 8800-SAIDA */

                M_8800_UPDATE_FOLLOWUP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8800_SAIDA*/


                /*" -1204- ADD 1 TO WS-REGISTROS. */
                WS_REGISTROS.Value = WS_REGISTROS + 1;
            }


            /*" -1205- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -1206- MOVE 1 TO WS-EOF. */
                    _.Move(1, WS_EOF);
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADER);
                _.Move(RETCRE.Value, RET_CADASTRAMENTO);
                _.Move(RETCRE.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

        [StopWatch]
        /*" M-0025-ATUALIZA-FITASASSE */
        private void M_0025_ATUALIZA_FITASASSE(bool isPerform = false)
        {
            /*" -1216- MOVE '0025-ATUALIZA-FITASASSE' TO PARAGRAFO. */
            _.Move("0025-ATUALIZA-FITASASSE", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1218- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1219- IF WAUX-FLAG EQUAL 'N' */

            if (WAUX_FLAG == "N")
            {

                /*" -1220- GO TO 0025-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0025_FIM*/ //GOTO
                return;

                /*" -1222- END-IF. */
            }


            /*" -1223- IF RF-COD-RETORNO = 0 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 0)
            {

                /*" -1224- ADD PARC-PREMIO-IX TO WS-ACG-TOTCREFET */
                WS_ACG_TOTCREFET.Value = WS_ACG_TOTCREFET + PARC_PREMIO_IX;

                /*" -1225- MOVE PARC-PREMIO-IX TO FITSAS-CREDEFET */
                _.Move(PARC_PREMIO_IX, FITSAS_CREDEFET);

                /*" -1226- MOVE +0 TO FITSAS-CREDNEFET */
                _.Move(+0, FITSAS_CREDNEFET);

                /*" -1227- ELSE */
            }
            else
            {


                /*" -1228- ADD PARC-PREMIO-IX TO WS-ACG-TOTCRNEFET */
                WS_ACG_TOTCRNEFET.Value = WS_ACG_TOTCRNEFET + PARC_PREMIO_IX;

                /*" -1229- MOVE PARC-PREMIO-IX TO FITSAS-CREDNEFET */
                _.Move(PARC_PREMIO_IX, FITSAS_CREDNEFET);

                /*" -1231- MOVE +0 TO FITSAS-CREDEFET. */
                _.Move(+0, FITSAS_CREDEFET);
            }


            /*" -1233- MOVE 'UPDATE V0FITASASSE' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE", LOCALIZA_ABEND_2.COMANDO);

            /*" -1243- PERFORM M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1 */

            M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1();

            /*" -1246- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1246- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0025-ATUALIZA-FITASASSE-DB-UPDATE-1 */
        public void M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1()
        {
            /*" -1243- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET QTDE_LANC_CRED_RET = QTDE_LANC_CRED_RET + 1, TOT_CRED_EFET = TOT_CRED_EFET + :FITSAS-CREDEFET, TOT_CRED_NAO_EFET = TOT_CRED_NAO_EFET + :FITSAS-CREDNEFET WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :MVCOM-NSAS END-EXEC. */

            var m_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1 = new M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1()
            {
                FITSAS_CREDNEFET = FITSAS_CREDNEFET.ToString(),
                FITSAS_CREDEFET = FITSAS_CREDEFET.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
            };

            M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1.Execute(m_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0025_FIM*/

        [StopWatch]
        /*" M-0031-LOCALIZA-OUTROS */
        private void M_0031_LOCALIZA_OUTROS(bool isPerform = false)
        {
            /*" -1261- MOVE '0031-LOCALIZA-OUTROS' TO PARAGRAFO. */
            _.Move("0031-LOCALIZA-OUTROS", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1262- IF RF-NSAS NOT NUMERIC */

            if (!RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NSAS.IsNumeric())
            {

                /*" -1263- IF WS-CONVENIO EQUAL 6065 */

                if (WORK_AREA.WS_CONVENIO == 6065)
                {

                    /*" -1264- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 10000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 10000;

                    /*" -1266- END-IF */
                }


                /*" -1267- IF WS-CONVENIO EQUAL 6038 */

                if (WORK_AREA.WS_CONVENIO == 6038)
                {

                    /*" -1268- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 2000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 2000;

                    /*" -1270- END-IF */
                }


                /*" -1271- IF WS-CONVENIO EQUAL 6040 */

                if (WORK_AREA.WS_CONVENIO == 6040)
                {

                    /*" -1272- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 4000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 4000;

                    /*" -1274- END-IF */
                }


                /*" -1275- IF WS-CONVENIO EQUAL 6069 */

                if (WORK_AREA.WS_CONVENIO == 6069)
                {

                    /*" -1276- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 13000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 13000;

                    /*" -1278- END-IF */
                }


                /*" -1279- IF WS-CONVENIO EQUAL 6041 */

                if (WORK_AREA.WS_CONVENIO == 6041)
                {

                    /*" -1280- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 5000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 5000;

                    /*" -1282- END-IF */
                }


                /*" -1283- IF WS-CONVENIO EQUAL 6070 */

                if (WORK_AREA.WS_CONVENIO == 6070)
                {

                    /*" -1284- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 14000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 14000;

                    /*" -1286- END-IF */
                }


                /*" -1287- IF WS-CONVENIO EQUAL 6042 */

                if (WORK_AREA.WS_CONVENIO == 6042)
                {

                    /*" -1288- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 6000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 6000;

                    /*" -1290- END-IF */
                }


                /*" -1291- IF WS-CONVENIO EQUAL 6071 */

                if (WORK_AREA.WS_CONVENIO == 6071)
                {

                    /*" -1292- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 15000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 15000;

                    /*" -1294- END-IF */
                }


                /*" -1295- IF WS-CONVENIO EQUAL 6036 */

                if (WORK_AREA.WS_CONVENIO == 6036)
                {

                    /*" -1296- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 9000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 9000;

                    /*" -1297- END-IF */
                }


                /*" -1298- ELSE */
            }
            else
            {


                /*" -1300- MOVE RF-NSAS TO MVCOM-NSAS. */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NSAS, MVCOM_NSAS);
            }


            /*" -1302- PERFORM 0032-LOCALIZA-COMISSAO THRU 0032-FIM. */

            M_0032_LOCALIZA_COMISSAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0032_FIM*/


            /*" -1303- IF WS-ACHEI = 0 */

            if (WORK_AREA.WS_ACHEI == 0)
            {

                /*" -1305- PERFORM 0033-LOCALIZA-RESSARC THRU 0033-FIM. */

                M_0033_LOCALIZA_RESSARC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0033_FIM*/

            }


            /*" -1306- IF WS-ACHEI = 0 */

            if (WORK_AREA.WS_ACHEI == 0)
            {

                /*" -1306- PERFORM 0034-LOCALIZA-PREMIACAO THRU 0034-FIM. */

                M_0034_LOCALIZA_PREMIACAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0034_FIM*/

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0031_FIM*/

        [StopWatch]
        /*" M-0032-LOCALIZA-COMISSAO */
        private void M_0032_LOCALIZA_COMISSAO(bool isPerform = false)
        {
            /*" -1315- MOVE '0032-LOCALIZA-COMISSAO' TO PARAGRAFO. */
            _.Move("0032-LOCALIZA-COMISSAO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1317- MOVE 'SELECT V0MOVCOMIS ' TO COMANDO. */
            _.Move("SELECT V0MOVCOMIS ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1320- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1321- ACCEPT WS-HORA-INI FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1323- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI. */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -1342- PERFORM M_0032_LOCALIZA_COMISSAO_DB_SELECT_1 */

            M_0032_LOCALIZA_COMISSAO_DB_SELECT_1();

            /*" -1345- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1346- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -1347- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1348- ADD SFT TO STT(1) */
            TOTAIS_ROT.FILLER_29[1].STT.Value = TOTAIS_ROT.FILLER_29[1].STT + WS_HORAS.SFT;

            /*" -1351- ADD 1 TO SQT(1) */
            TOTAIS_ROT.FILLER_29[1].SQT.Value = TOTAIS_ROT.FILLER_29[1].SQT + 1;

            /*" -1352- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1353- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1354- ELSE */
            }
            else
            {


                /*" -1355- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1356- MOVE 1 TO WS-ACHEI */
                    _.Move(1, WORK_AREA.WS_ACHEI);

                    /*" -1357- IF RF-COD-RETORNO EQUAL 00 */

                    if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00)
                    {

                        /*" -1358- PERFORM 1132-QUITA-COMISSAO THRU 1132-FIM */

                        M_1132_QUITA_COMISSAO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1132_FIM*/


                        /*" -1359- ELSE */
                    }
                    else
                    {


                        /*" -1359- PERFORM 1232-REJEITA-COMISSAO THRU 1232-FIM. */

                        M_1232_REJEITA_COMISSAO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1232_FIM*/

                    }

                }

            }


        }

        [StopWatch]
        /*" M-0032-LOCALIZA-COMISSAO-DB-SELECT-1 */
        public void M_0032_LOCALIZA_COMISSAO_DB_SELECT_1()
        {
            /*" -1342- EXEC SQL SELECT COD_PRODUTOR, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA, DATA_MOVIMENTO, SITUACAO INTO :MVCOM-CODPDT, :MVCOM-AGENCIA, :MVCOM-OPERACAO, :MVCOM-CONTA, :MVCOM-DIG, :MVCOM-DATA-MOV, :MVCOM-SITUACAO FROM SEGUROS.V0MOVCOMIS WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL WITH UR END-EXEC. */

            var m_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1 = new M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            var executed_1 = M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1.Execute(m_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MVCOM_CODPDT, MVCOM_CODPDT);
                _.Move(executed_1.MVCOM_AGENCIA, MVCOM_AGENCIA);
                _.Move(executed_1.MVCOM_OPERACAO, MVCOM_OPERACAO);
                _.Move(executed_1.MVCOM_CONTA, MVCOM_CONTA);
                _.Move(executed_1.MVCOM_DIG, MVCOM_DIG);
                _.Move(executed_1.MVCOM_DATA_MOV, MVCOM_DATA_MOV);
                _.Move(executed_1.MVCOM_SITUACAO, MVCOM_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0032_FIM*/

        [StopWatch]
        /*" M-0033-LOCALIZA-RESSARC */
        private void M_0033_LOCALIZA_RESSARC(bool isPerform = false)
        {
            /*" -1374- MOVE '0033-LOCALIZA-RESSARC' TO PARAGRAFO. */
            _.Move("0033-LOCALIZA-RESSARC", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1376- MOVE 'SELECT V0RESSARCIAZUL' TO COMANDO */
            _.Move("SELECT V0RESSARCIAZUL", LOCALIZA_ABEND_2.COMANDO);

            /*" -1378- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1381- MOVE RF-NSL-7 TO MVCOM-NSL1. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL_R.RF_NSL_7, MVCOM_NSL1);

            /*" -1382- ACCEPT WS-HORA-INI FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1385- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI. */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -1398- PERFORM M_0033_LOCALIZA_RESSARC_DB_SELECT_1 */

            M_0033_LOCALIZA_RESSARC_DB_SELECT_1();

            /*" -1402- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1403- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -1404- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1405- ADD SFT TO STT(2) */
            TOTAIS_ROT.FILLER_29[2].STT.Value = TOTAIS_ROT.FILLER_29[2].STT + WS_HORAS.SFT;

            /*" -1408- ADD 1 TO SQT(2) */
            TOTAIS_ROT.FILLER_29[2].SQT.Value = TOTAIS_ROT.FILLER_29[2].SQT + 1;

            /*" -1409- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1410- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1411- GO TO 0033-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0033_FIM*/ //GOTO
                    return;

                    /*" -1412- ELSE */
                }
                else
                {


                    /*" -1414- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1416- PERFORM 3400-NUM-PARCELA THRU 3400-FIM. */

            M_3400_NUM_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3400_FIM*/


            /*" -1418- MOVE 1 TO WS-ACHEI. */
            _.Move(1, WORK_AREA.WS_ACHEI);

            /*" -1419- IF RF-COD-RETORNO EQUAL ZEROES */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00)
            {

                /*" -1420- MOVE 'UPDATE V0RESSARCIAZUL 1' TO COMANDO */
                _.Move("UPDATE V0RESSARCIAZUL 1", LOCALIZA_ABEND_2.COMANDO);

                /*" -1427- PERFORM M_0033_LOCALIZA_RESSARC_DB_UPDATE_1 */

                M_0033_LOCALIZA_RESSARC_DB_UPDATE_1();

                /*" -1429- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1430- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1431- END-IF */
                }


                /*" -1432- MOVE 'SELECT V0RESSARCIAZUL 1' TO COMANDO */
                _.Move("SELECT V0RESSARCIAZUL 1", LOCALIZA_ABEND_2.COMANDO);

                /*" -1445- PERFORM M_0033_LOCALIZA_RESSARC_DB_SELECT_2 */

                M_0033_LOCALIZA_RESSARC_DB_SELECT_2();

                /*" -1447- IF SQLCODE NOT EQUAL ZEROES AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1448- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1449- END-IF */
                }


                /*" -1450- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1451- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1452- MOVE 'SELECT V0RESS+V0SEG+VPROD' TO COMANDO */
                        _.Move("SELECT V0RESS+V0SEG+VPROD", LOCALIZA_ABEND_2.COMANDO);

                        /*" -1468- PERFORM M_0033_LOCALIZA_RESSARC_DB_SELECT_3 */

                        M_0033_LOCALIZA_RESSARC_DB_SELECT_3();

                        /*" -1470- IF SQLCODE NOT EQUAL ZEROES */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -1471- GO TO 9999-ERRO */

                            M_9999_ERRO(); //GOTO
                            return;

                            /*" -1472- END-IF */
                        }


                        /*" -1473- PERFORM 3300-BUSCA-FONTE THRU 3300-FIM */

                        M_3300_BUSCA_FONTE(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3300_FIM*/


                        /*" -1475- IF PROPAZ-CODPRODAZ EQUAL 'PRM' OR 'SNR' OR 'TRD' OR 'EXC' OR 'MST' OR 'MCE' */

                        if (PROPAZ_CODPRODAZ.In("PRM", "SNR", "TRD", "EXC", "MST", "MCE"))
                        {

                            /*" -1476- MOVE TAB-FONTE (WHOST-AGE-VENDA) TO LK-FONTE */
                            _.Move(WORK_AREA.TAB_FILIAL.FILLER_6[WHOST_AGE_VENDA].TAB_FONTE, LK_CONTABIL.LK_FONTE);

                            /*" -1477- MOVE MVCOM-DATA-MOV TO LK-DTMOVTO */
                            _.Move(MVCOM_DATA_MOV, LK_CONTABIL.LK_DTMOVTO);

                            /*" -1478- MOVE RF-VALOR TO LK-VLOPER */
                            _.Move(RET_CADASTRAMENTO.RF_VALOR, LK_CONTABIL.LK_VLOPER);

                            /*" -1480- MOVE PROPAZ-CODPRODAZ TO LK-CODPRODAZ LK101-CODPRODAZ */
                            _.Move(PROPAZ_CODPRODAZ, LK_CONTABIL.LK_CODPRODAZ, LK_VA0101S.LK101_CODPRODAZ);

                            /*" -1481- MOVE +201 TO LK-CODOPER */
                            _.Move(+201, LK_CONTABIL.LK_CODOPER);

                            /*" -1482- IF V0SEGV-DTRENOVA-I LESS ZEROS */

                            if (V0SEGV_DTRENOVA_I < 00)
                            {

                                /*" -1483- MOVE V0SEGV-DTINIVIG TO LK-DTINIVIG */
                                _.Move(V0SEGV_DTINIVIG, LK_CONTABIL.LK_DTINIVIG);

                                /*" -1484- MOVE SPACES TO LK-DTRENOVA */
                                _.Move("", LK_CONTABIL.LK_DTRENOVA);

                                /*" -1485- ELSE */
                            }
                            else
                            {


                                /*" -1486- MOVE V0SEGV-DTINIVIG TO LK-DTINIVIG */
                                _.Move(V0SEGV_DTINIVIG, LK_CONTABIL.LK_DTINIVIG);

                                /*" -1487- MOVE V0SEGV-DTRENOVA TO LK-DTRENOVA */
                                _.Move(V0SEGV_DTRENOVA, LK_CONTABIL.LK_DTRENOVA);

                                /*" -1488- END-IF */
                            }


                            /*" -1489- CALL 'VA0100S' USING LK-CONTABIL */
                            _.Call("VA0100S", LK_CONTABIL);

                            /*" -1490- IF LK-RETCODE NOT EQUAL +0 */

                            if (LK_CONTABIL.LK_RETCODE != +0)
                            {

                                /*" -1491- DISPLAY 'ERRO VA0100S ' LK-RETCODE */
                                _.Display($"ERRO VA0100S {LK_CONTABIL.LK_RETCODE}");

                                /*" -1492- DISPLAY LK-MENSAGEM */
                                _.Display(LK_CONTABIL.LK_MENSAGEM);

                                /*" -1493- GO TO 9999-ERRO */

                                M_9999_ERRO(); //GOTO
                                return;

                                /*" -1494- END-IF */
                            }


                            /*" -1495- MOVE LK-VLOPER TO LK101-PREMIO */
                            _.Move(LK_CONTABIL.LK_VLOPER, LK_VA0101S.LK101_PREMIO);

                            /*" -1496- CALL 'VA0101S' USING LK-VA0101S */
                            _.Call("VA0101S", LK_VA0101S);

                            /*" -1497- IF LK101-RETCODE NOT EQUAL +0 */

                            if (LK_VA0101S.LK101_RETCODE != +0)
                            {

                                /*" -1498- DISPLAY 'ERRO VA0101S ' LK101-RETCODE */
                                _.Display($"ERRO VA0101S {LK_VA0101S.LK101_RETCODE}");

                                /*" -1499- DISPLAY LK101-MENSAGEM */
                                _.Display(LK_VA0101S.LK101_MENSAGEM);

                                /*" -1500- DISPLAY 'PROPAZ-CODPRODAZ ' PROPAZ-CODPRODAZ */
                                _.Display($"PROPAZ-CODPRODAZ {PROPAZ_CODPRODAZ}");

                                /*" -1501- GO TO 9999-ERRO */

                                M_9999_ERRO(); //GOTO
                                return;

                                /*" -1502- END-IF */
                            }


                            /*" -1503- GO TO 0033-FIM */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0033_FIM*/ //GOTO
                            return;

                            /*" -1504- ELSE */
                        }
                        else
                        {


                            /*" -1505- GO TO 0033-FIM */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0033_FIM*/ //GOTO
                            return;

                            /*" -1506- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1507- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -1508- ELSE */
                    }

                }
                else
                {


                    /*" -1509- PERFORM 3300-BUSCA-FONTE THRU 3300-FIM */

                    M_3300_BUSCA_FONTE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3300_FIM*/


                    /*" -1511- IF PROPAZ-CODPRODAZ EQUAL 'PRM' OR 'SNR' OR 'TRD' OR 'EXC' OR 'MST' OR 'MCE' */

                    if (PROPAZ_CODPRODAZ.In("PRM", "SNR", "TRD", "EXC", "MST", "MCE"))
                    {

                        /*" -1512- MOVE TAB-FONTE (WHOST-AGE-VENDA) TO LK-FONTE */
                        _.Move(WORK_AREA.TAB_FILIAL.FILLER_6[WHOST_AGE_VENDA].TAB_FONTE, LK_CONTABIL.LK_FONTE);

                        /*" -1513- MOVE MVCOM-DATA-MOV TO LK-DTMOVTO */
                        _.Move(MVCOM_DATA_MOV, LK_CONTABIL.LK_DTMOVTO);

                        /*" -1514- MOVE RF-VALOR TO LK-VLOPER */
                        _.Move(RET_CADASTRAMENTO.RF_VALOR, LK_CONTABIL.LK_VLOPER);

                        /*" -1516- MOVE PROPAZ-CODPRODAZ TO LK-CODPRODAZ LK101-CODPRODAZ */
                        _.Move(PROPAZ_CODPRODAZ, LK_CONTABIL.LK_CODPRODAZ, LK_VA0101S.LK101_CODPRODAZ);

                        /*" -1517- MOVE PROPAZ-DTQITBCO TO LK-DTINIVIG */
                        _.Move(PROPAZ_DTQITBCO, LK_CONTABIL.LK_DTINIVIG);

                        /*" -1518- MOVE SPACES TO LK-DTRENOVA */
                        _.Move("", LK_CONTABIL.LK_DTRENOVA);

                        /*" -1519- MOVE +201 TO LK-CODOPER */
                        _.Move(+201, LK_CONTABIL.LK_CODOPER);

                        /*" -1520- CALL 'VA0100S' USING LK-CONTABIL */
                        _.Call("VA0100S", LK_CONTABIL);

                        /*" -1521- IF LK-RETCODE NOT EQUAL +0 */

                        if (LK_CONTABIL.LK_RETCODE != +0)
                        {

                            /*" -1522- DISPLAY 'ERRO VA0100S ' LK-RETCODE */
                            _.Display($"ERRO VA0100S {LK_CONTABIL.LK_RETCODE}");

                            /*" -1523- DISPLAY LK-MENSAGEM */
                            _.Display(LK_CONTABIL.LK_MENSAGEM);

                            /*" -1524- GO TO 9999-ERRO */

                            M_9999_ERRO(); //GOTO
                            return;

                            /*" -1525- END-IF */
                        }


                        /*" -1526- MOVE LK-VLOPER TO LK101-PREMIO */
                        _.Move(LK_CONTABIL.LK_VLOPER, LK_VA0101S.LK101_PREMIO);

                        /*" -1527- CALL 'VA0101S' USING LK-VA0101S */
                        _.Call("VA0101S", LK_VA0101S);

                        /*" -1528- IF LK101-RETCODE NOT EQUAL +0 */

                        if (LK_VA0101S.LK101_RETCODE != +0)
                        {

                            /*" -1529- DISPLAY 'ERRO VA0101S ' LK101-RETCODE */
                            _.Display($"ERRO VA0101S {LK_VA0101S.LK101_RETCODE}");

                            /*" -1530- DISPLAY LK101-MENSAGEM */
                            _.Display(LK_VA0101S.LK101_MENSAGEM);

                            /*" -1531- DISPLAY 'PROPAZ-CODPRODAZ ' PROPAZ-CODPRODAZ */
                            _.Display($"PROPAZ-CODPRODAZ {PROPAZ_CODPRODAZ}");

                            /*" -1532- GO TO 9999-ERRO */

                            M_9999_ERRO(); //GOTO
                            return;

                            /*" -1533- END-IF */
                        }


                        /*" -1534- GO TO 0033-FIM */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0033_FIM*/ //GOTO
                        return;

                        /*" -1535- ELSE */
                    }
                    else
                    {


                        /*" -1537- GO TO 0033-FIM. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0033_FIM*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1539- MOVE 'UPDATE V0RESSARCIAZUL 2' TO COMANDO. */
            _.Move("UPDATE V0RESSARCIAZUL 2", LOCALIZA_ABEND_2.COMANDO);

            /*" -1540- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1542- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -1549- PERFORM M_0033_LOCALIZA_RESSARC_DB_UPDATE_2 */

            M_0033_LOCALIZA_RESSARC_DB_UPDATE_2();

            /*" -1552- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1553- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -1554- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1555- ADD SFT TO STT(4) */
            TOTAIS_ROT.FILLER_29[4].STT.Value = TOTAIS_ROT.FILLER_29[4].STT + WS_HORAS.SFT;

            /*" -1558- ADD 1 TO SQT(4). */
            TOTAIS_ROT.FILLER_29[4].SQT.Value = TOTAIS_ROT.FILLER_29[4].SQT + 1;

            /*" -1559- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1561- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1562- IF HISR-NUM-PARCELA < 1 */

            if (HISR_NUM_PARCELA < 1)
            {

                /*" -1567- GO TO 0033-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0033_FIM*/ //GOTO
                return;
            }


            /*" -1568- MOVE 'INSERT V0HISTREJAZUL   ' TO COMANDO */
            _.Move("INSERT V0HISTREJAZUL   ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1586- PERFORM M_0033_LOCALIZA_RESSARC_DB_INSERT_1 */

            M_0033_LOCALIZA_RESSARC_DB_INSERT_1();

            /*" -1589- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1591- IF SQLCODE = 100 OR -803 NEXT SENTENCE */

                if (DB.SQLCODE.In("100", "-803"))
                {

                    /*" -1592- ELSE */
                }
                else
                {


                    /*" -1592- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0033-LOCALIZA-RESSARC-DB-SELECT-1 */
        public void M_0033_LOCALIZA_RESSARC_DB_SELECT_1()
        {
            /*" -1398- EXEC SQL SELECT NSAS, DATA_DEBITO, NUM_CERTIFICADO, DESCR_RESSARCI INTO :MVCOM-NSAS, :MVCOM-DATA-MOV, :RESA-NRCERTIF, :RESA-DESCR FROM SEGUROS.V0RESSARCIAZUL WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL1 WITH UR END-EXEC. */

            var m_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1 = new M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL1 = MVCOM_NSL1.ToString(),
            };

            var executed_1 = M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1.Execute(m_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MVCOM_NSAS, MVCOM_NSAS);
                _.Move(executed_1.MVCOM_DATA_MOV, MVCOM_DATA_MOV);
                _.Move(executed_1.RESA_NRCERTIF, RESA_NRCERTIF);
                _.Move(executed_1.RESA_DESCR, RESA_DESCR);
            }


        }

        [StopWatch]
        /*" M-0033-LOCALIZA-RESSARC-DB-UPDATE-1 */
        public void M_0033_LOCALIZA_RESSARC_DB_UPDATE_1()
        {
            /*" -1427- EXEC SQL UPDATE SEGUROS.V0RESSARCIAZUL SET DATA_RESSARCIDO = :FITCEF-DTRET, SITUACAO = '1' , NSAC = :SQL-NSAC:SQL-NOT-NULL WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL1 END-EXEC */

            var m_0033_LOCALIZA_RESSARC_DB_UPDATE_1_Update1 = new M_0033_LOCALIZA_RESSARC_DB_UPDATE_1_Update1()
            {
                SQL_NSAC = SQL_NSAC.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
                FITCEF_DTRET = FITCEF_DTRET.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL1 = MVCOM_NSL1.ToString(),
            };

            M_0033_LOCALIZA_RESSARC_DB_UPDATE_1_Update1.Execute(m_0033_LOCALIZA_RESSARC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0033_FIM*/

        [StopWatch]
        /*" M-0033-LOCALIZA-RESSARC-DB-SELECT-2 */
        public void M_0033_LOCALIZA_RESSARC_DB_SELECT_2()
        {
            /*" -1445- EXEC SQL SELECT B.CODPRODAZ, B.DTQITBCO INTO :PROPAZ-CODPRODAZ, :PROPAZ-DTQITBCO FROM SEGUROS.V0RESSARCIAZUL A, SEGUROS.V0PROPAZUL B WHERE A.NSAS = :MVCOM-NSAS AND A.NSL = :MVCOM-NSL1 AND B.NRPROPAZ = A.NRPROPAZ AND B.AGELOTE = A.AGELOTE AND B.DTLOTE = A.DTLOTE AND B.NRLOTE = A.NRLOTE AND B.NRSEQLOTE = A.NRSEQLOTE WITH UR END-EXEC */

            var m_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1 = new M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL1 = MVCOM_NSL1.ToString(),
            };

            var executed_1 = M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1.Execute(m_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPAZ_CODPRODAZ, PROPAZ_CODPRODAZ);
                _.Move(executed_1.PROPAZ_DTQITBCO, PROPAZ_DTQITBCO);
            }


        }

        [StopWatch]
        /*" M-0034-LOCALIZA-PREMIACAO */
        private void M_0034_LOCALIZA_PREMIACAO(bool isPerform = false)
        {
            /*" -1687- MOVE '0034-LOCALIZA-PREMIACAO' TO PARAGRAFO. */
            _.Move("0034-LOCALIZA-PREMIACAO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1689- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1691- MOVE RF-NSL TO MVCOM-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, MVCOM_NSL);

            /*" -1693- MOVE 'SELECT V0CAMPMULTIND' TO COMANDO */
            _.Move("SELECT V0CAMPMULTIND", LOCALIZA_ABEND_2.COMANDO);

            /*" -1700- PERFORM M_0034_LOCALIZA_PREMIACAO_DB_SELECT_1 */

            M_0034_LOCALIZA_PREMIACAO_DB_SELECT_1();

            /*" -1703- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1705- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1706- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1707- MOVE 1 TO WS-ACHEI */
                _.Move(1, WORK_AREA.WS_ACHEI);

                /*" -1708- IF RF-COD-RETORNO EQUAL 0 */

                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 0)
                {

                    /*" -1709- MOVE '5' TO CAMP-SITUACAO */
                    _.Move("5", CAMP_SITUACAO);

                    /*" -1710- ELSE */
                }
                else
                {


                    /*" -1711- MOVE ' ' TO CAMP-SITUACAO */
                    _.Move(" ", CAMP_SITUACAO);

                    /*" -1712- END-IF */
                }


                /*" -1713- MOVE RF-COD-RETORNO TO CAMP-CODRET */
                _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, CAMP_CODRET);

                /*" -1714- MOVE 'UPDATE V0CAMPMULTIND' TO COMANDO */
                _.Move("UPDATE V0CAMPMULTIND", LOCALIZA_ABEND_2.COMANDO);

                /*" -1721- PERFORM M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1 */

                M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1();

                /*" -1723- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1724- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1725- ELSE */
                }
                else
                {


                    /*" -1727- GO TO 0034-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0034_FIM*/ //GOTO
                    return;
                }

            }


            /*" -1729- MOVE 'SELECT V0CAMPMULTGER' TO COMANDO */
            _.Move("SELECT V0CAMPMULTGER", LOCALIZA_ABEND_2.COMANDO);

            /*" -1736- PERFORM M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2 */

            M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2();

            /*" -1739- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1741- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1742- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1743- MOVE 1 TO WS-ACHEI */
                _.Move(1, WORK_AREA.WS_ACHEI);

                /*" -1744- IF RF-COD-RETORNO EQUAL 0 */

                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 0)
                {

                    /*" -1745- MOVE '5' TO CAMP-SITUACAO */
                    _.Move("5", CAMP_SITUACAO);

                    /*" -1746- ELSE */
                }
                else
                {


                    /*" -1747- MOVE ' ' TO CAMP-SITUACAO */
                    _.Move(" ", CAMP_SITUACAO);

                    /*" -1748- END-IF */
                }


                /*" -1749- MOVE RF-COD-RETORNO TO CAMP-CODRET */
                _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, CAMP_CODRET);

                /*" -1750- MOVE 'UPDATE V0CAMPMULTGER' TO COMANDO */
                _.Move("UPDATE V0CAMPMULTGER", LOCALIZA_ABEND_2.COMANDO);

                /*" -1757- PERFORM M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2 */

                M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2();

                /*" -1759- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1760- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1761- ELSE */
                }
                else
                {


                    /*" -1763- GO TO 0034-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0034_FIM*/ //GOTO
                    return;
                }

            }


            /*" -1765- MOVE 'SELECT V0CAMPMULTSUP' TO COMANDO */
            _.Move("SELECT V0CAMPMULTSUP", LOCALIZA_ABEND_2.COMANDO);

            /*" -1772- PERFORM M_0034_LOCALIZA_PREMIACAO_DB_SELECT_3 */

            M_0034_LOCALIZA_PREMIACAO_DB_SELECT_3();

            /*" -1775- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1777- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1778- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1779- MOVE 1 TO WS-ACHEI */
                _.Move(1, WORK_AREA.WS_ACHEI);

                /*" -1780- IF RF-COD-RETORNO EQUAL 0 */

                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 0)
                {

                    /*" -1781- MOVE '5' TO CAMP-SITUACAO */
                    _.Move("5", CAMP_SITUACAO);

                    /*" -1782- ELSE */
                }
                else
                {


                    /*" -1783- MOVE ' ' TO CAMP-SITUACAO */
                    _.Move(" ", CAMP_SITUACAO);

                    /*" -1784- END-IF */
                }


                /*" -1785- MOVE RF-COD-RETORNO TO CAMP-CODRET */
                _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, CAMP_CODRET);

                /*" -1786- MOVE 'UPDATE V0CAMPMULTSUP' TO COMANDO */
                _.Move("UPDATE V0CAMPMULTSUP", LOCALIZA_ABEND_2.COMANDO);

                /*" -1793- PERFORM M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3 */

                M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3();

                /*" -1795- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1795- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0034-LOCALIZA-PREMIACAO-DB-SELECT-1 */
        public void M_0034_LOCALIZA_PREMIACAO_DB_SELECT_1()
        {
            /*" -1700- EXEC SQL SELECT SITUACAO INTO :CAMP-SITUACAO FROM SEGUROS.V0CAMPMULTIND WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL WITH UR END-EXEC. */

            var m_0034_LOCALIZA_PREMIACAO_DB_SELECT_1_Query1 = new M_0034_LOCALIZA_PREMIACAO_DB_SELECT_1_Query1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            var executed_1 = M_0034_LOCALIZA_PREMIACAO_DB_SELECT_1_Query1.Execute(m_0034_LOCALIZA_PREMIACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CAMP_SITUACAO, CAMP_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-0034-LOCALIZA-PREMIACAO-DB-UPDATE-1 */
        public void M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1()
        {
            /*" -1721- EXEC SQL UPDATE SEGUROS.V0CAMPMULTIND SET SITUACAO = :CAMP-SITUACAO, NSAC = :SQL-NSAC, CODRET = :CAMP-CODRET WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL END-EXEC */

            var m_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1_Update1 = new M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1_Update1()
            {
                CAMP_SITUACAO = CAMP_SITUACAO.ToString(),
                CAMP_CODRET = CAMP_CODRET.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1_Update1.Execute(m_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0033-LOCALIZA-RESSARC-DB-INSERT-1 */
        public void M_0033_LOCALIZA_RESSARC_DB_INSERT_1()
        {
            /*" -1586- EXEC SQL INSERT INTO SEGUROS.V0HISTREJAZUL VALUES (:RESA-NRCERTIF, :HISR-NUM-PARCELA, :MVCOM-DATA-MOV, :HISR-CODOPER, :DTMOVABE, CURRENT TIMESTAMP, :MVCOM-NSAS, :MVCOM-NSL1, :SQL-NSAC, NULL, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var m_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1 = new M_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1()
            {
                RESA_NRCERTIF = RESA_NRCERTIF.ToString(),
                HISR_NUM_PARCELA = HISR_NUM_PARCELA.ToString(),
                MVCOM_DATA_MOV = MVCOM_DATA_MOV.ToString(),
                HISR_CODOPER = HISR_CODOPER.ToString(),
                DTMOVABE = DTMOVABE.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL1 = MVCOM_NSL1.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
            };

            M_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1.Execute(m_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0034-LOCALIZA-PREMIACAO-DB-SELECT-2 */
        public void M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2()
        {
            /*" -1736- EXEC SQL SELECT SITUACAO INTO :CAMP-SITUACAO FROM SEGUROS.V0CAMPMULTGER WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL WITH UR END-EXEC. */

            var m_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1 = new M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            var executed_1 = M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1.Execute(m_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CAMP_SITUACAO, CAMP_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-0034-LOCALIZA-PREMIACAO-DB-UPDATE-2 */
        public void M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2()
        {
            /*" -1757- EXEC SQL UPDATE SEGUROS.V0CAMPMULTGER SET SITUACAO = :CAMP-SITUACAO, NSAC = :SQL-NSAC, CODRET = :CAMP-CODRET WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL END-EXEC */

            var m_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2_Update1 = new M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2_Update1()
            {
                CAMP_SITUACAO = CAMP_SITUACAO.ToString(),
                CAMP_CODRET = CAMP_CODRET.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2_Update1.Execute(m_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0033-LOCALIZA-RESSARC-DB-UPDATE-2 */
        public void M_0033_LOCALIZA_RESSARC_DB_UPDATE_2()
        {
            /*" -1549- EXEC SQL UPDATE SEGUROS.V0RESSARCIAZUL SET SITUACAO = '0' , NSAC = :SQL-NSAC:SQL-NOT-NULL, DATA_RESSARCIDO = NULL WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL1 END-EXEC. */

            var m_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1 = new M_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1()
            {
                SQL_NSAC = SQL_NSAC.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL1 = MVCOM_NSL1.ToString(),
            };

            M_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1.Execute(m_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0034-LOCALIZA-PREMIACAO-DB-SELECT-3 */
        public void M_0034_LOCALIZA_PREMIACAO_DB_SELECT_3()
        {
            /*" -1772- EXEC SQL SELECT SITUACAO INTO :CAMP-SITUACAO FROM SEGUROS.V0CAMPMULTSUP WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL WITH UR END-EXEC. */

            var m_0034_LOCALIZA_PREMIACAO_DB_SELECT_3_Query1 = new M_0034_LOCALIZA_PREMIACAO_DB_SELECT_3_Query1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            var executed_1 = M_0034_LOCALIZA_PREMIACAO_DB_SELECT_3_Query1.Execute(m_0034_LOCALIZA_PREMIACAO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CAMP_SITUACAO, CAMP_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-0034-LOCALIZA-PREMIACAO-DB-UPDATE-3 */
        public void M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3()
        {
            /*" -1793- EXEC SQL UPDATE SEGUROS.V0CAMPMULTSUP SET SITUACAO = :CAMP-SITUACAO, NSAC = :SQL-NSAC, CODRET = :CAMP-CODRET WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL END-EXEC */

            var m_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1 = new M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1()
            {
                CAMP_SITUACAO = CAMP_SITUACAO.ToString(),
                CAMP_CODRET = CAMP_CODRET.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1.Execute(m_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-0033-LOCALIZA-RESSARC-DB-SELECT-3 */
        public void M_0033_LOCALIZA_RESSARC_DB_SELECT_3()
        {
            /*" -1468- EXEC SQL SELECT C.CODPRODAZ, B.DATA_INIVIGENCIA, B.DATA_ADMISSAO INTO :PROPAZ-CODPRODAZ, :V0SEGV-DTINIVIG, :V0SEGV-DTRENOVA:V0SEGV-DTRENOVA-I FROM SEGUROS.V0RESSARCIAZUL A, SEGUROS.V0SEGURAVG B, SEGUROS.V0PRODUTOSVG C WHERE A.NSAS = :MVCOM-NSAS AND A.NSL = :MVCOM-NSL1 AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.CODSUBES = B.COD_SUBGRUPO WITH UR END-EXEC */

            var m_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1 = new M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL1 = MVCOM_NSL1.ToString(),
            };

            var executed_1 = M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1.Execute(m_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPAZ_CODPRODAZ, PROPAZ_CODPRODAZ);
                _.Move(executed_1.V0SEGV_DTINIVIG, V0SEGV_DTINIVIG);
                _.Move(executed_1.V0SEGV_DTRENOVA, V0SEGV_DTRENOVA);
                _.Move(executed_1.V0SEGV_DTRENOVA_I, V0SEGV_DTRENOVA_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0034_FIM*/

        [StopWatch]
        /*" M-0035-LOCALIZA-DEVMULTI */
        private void M_0035_LOCALIZA_DEVMULTI(bool isPerform = false)
        {
            /*" -1804- MOVE '0035-LOCALIZA-DEVMULTI' TO PARAGRAFO. */
            _.Move("0035-LOCALIZA-DEVMULTI", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1806- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1807- IF RF-NSAS NOT NUMERIC */

            if (!RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NSAS.IsNumeric())
            {

                /*" -1808- IF WS-CONVENIO EQUAL 6090 */

                if (WORK_AREA.WS_CONVENIO == 6090)
                {

                    /*" -1809- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 25000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 25000;

                    /*" -1811- END-IF */
                }


                /*" -1812- IF WS-CONVENIO EQUAL 6129 */

                if (WORK_AREA.WS_CONVENIO == 6129)
                {

                    /*" -1813- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 27000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 27000;

                    /*" -1815- END-IF */
                }


                /*" -1816- IF WS-CONVENIO EQUAL 6132 */

                if (WORK_AREA.WS_CONVENIO == 6132)
                {

                    /*" -1817- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 28000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 28000;

                    /*" -1819- END-IF */
                }


                /*" -1820- IF WS-CONVENIO EQUAL 6131 */

                if (WORK_AREA.WS_CONVENIO == 6131)
                {

                    /*" -1821- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 29000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 29000;

                    /*" -1823- END-IF */
                }


                /*" -1824- IF WS-CONVENIO EQUAL 6153 */

                if (WORK_AREA.WS_CONVENIO == 6153)
                {

                    /*" -1825- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 30000 */
                    MVCOM_NSAS.Value = MVCOM_NSAS + 30000;

                    /*" -1826- END-IF */
                }


                /*" -1827- ELSE */
            }
            else
            {


                /*" -1832- MOVE RF-NSAS TO MVCOM-NSAS. */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NSAS, MVCOM_NSAS);
            }


            /*" -1834- MOVE RF-NSL TO MVCOM-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, MVCOM_NSL);

            /*" -1836- MOVE 'SELECT V0HISTCONTAVA' TO COMANDO */
            _.Move("SELECT V0HISTCONTAVA", LOCALIZA_ABEND_2.COMANDO);

            /*" -1838- MOVE ZEROS TO HCTA-OCORRHISTCTA */
            _.Move(0, HCTA_OCORRHISTCTA);

            /*" -1856- PERFORM M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1 */

            M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1();

            /*" -1859- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1861- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1863- IF VIND-CODRET NOT LESS +0 AND HCTA-CODRET GREATER ZEROS */

            if (VIND_CODRET >= +0 && HCTA_CODRET > 00)
            {

                /*" -1864- MOVE 'N' TO WAUX-FLAG */
                _.Move("N", WAUX_FLAG);

                /*" -1866- END-IF. */
            }


            /*" -1867- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1869- MOVE 1 TO WS-ACHEI */
                _.Move(1, WORK_AREA.WS_ACHEI);

                /*" -1870- IF RF-COD-RETORNO EQUAL 0 */

                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 0)
                {

                    /*" -1871- MOVE '1' TO HCTA-SITUACAO */
                    _.Move("1", HCTA_SITUACAO);

                    /*" -1872- PERFORM 0036-INSERT-HISTCONTABILVA THRU 0036-FIM */

                    M_0036_INSERT_HISTCONTABILVA(true);

                    M_0036_INSERT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0036_FIM*/


                    /*" -1874- ELSE */
                }
                else
                {


                    /*" -1875- MOVE '8' TO HCTA-SITUACAO */
                    _.Move("8", HCTA_SITUACAO);

                    /*" -1876- MOVE 'UPDATE V0PARCELVA   ' TO COMANDO */
                    _.Move("UPDATE V0PARCELVA   ", LOCALIZA_ABEND_2.COMANDO);

                    /*" -1882- PERFORM M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1 */

                    M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1();

                    /*" -1884- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1885- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -1886- END-IF */
                    }


                    /*" -1891- PERFORM M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2 */

                    M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2();

                    /*" -1893- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1894- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -1895- END-IF */
                    }


                    /*" -1897- END-IF */
                }


                /*" -1898- MOVE RF-COD-RETORNO TO HCTA-CODRET */
                _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, HCTA_CODRET);

                /*" -1900- MOVE 'UPDATE V0HISTCONTAVA' TO COMANDO */
                _.Move("UPDATE V0HISTCONTAVA", LOCALIZA_ABEND_2.COMANDO);

                /*" -1910- PERFORM M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3 */

                M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3();

                /*" -1913- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1914- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1915- END-IF */
                }


                /*" -1915- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0035-LOCALIZA-DEVMULTI-DB-SELECT-1 */
        public void M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1()
        {
            /*" -1856- EXEC SQL SELECT NRCERTIF, NRPARCEL, VLPRMTOT, SITUACAO, CODRET, OCORRHISTCTA INTO :HCTA-NRCERTIF, :HCTA-NRPARCEL, :HCTA-VLPRMTOT, :HCTA-SITUACAO, :HCTA-CODRET :VIND-CODRET, :HCTA-OCORRHISTCTA FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = :WHOST-CODCONV AND NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL WITH UR END-EXEC. */

            var m_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1 = new M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1()
            {
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            var executed_1 = M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1.Execute(m_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HCTA_NRCERTIF, HCTA_NRCERTIF);
                _.Move(executed_1.HCTA_NRPARCEL, HCTA_NRPARCEL);
                _.Move(executed_1.HCTA_VLPRMTOT, HCTA_VLPRMTOT);
                _.Move(executed_1.HCTA_SITUACAO, HCTA_SITUACAO);
                _.Move(executed_1.HCTA_CODRET, HCTA_CODRET);
                _.Move(executed_1.VIND_CODRET, VIND_CODRET);
                _.Move(executed_1.HCTA_OCORRHISTCTA, HCTA_OCORRHISTCTA);
            }


        }

        [StopWatch]
        /*" M-0035-LOCALIZA-DEVMULTI-DB-UPDATE-1 */
        public void M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1()
        {
            /*" -1882- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF =:HCTA-NRCERTIF AND NRPARCEL =:HCTA-NRPARCEL END-EXEC */

            var m_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1_Update1 = new M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1_Update1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                HCTA_NRPARCEL = HCTA_NRPARCEL.ToString(),
            };

            M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1_Update1.Execute(m_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0035_FIM*/

        [StopWatch]
        /*" M-0035-LOCALIZA-DEVMULTI-DB-UPDATE-2 */
        public void M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2()
        {
            /*" -1891- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '1' WHERE NRCERTIF =:HCTA-NRCERTIF AND NRPARCEL =:HCTA-NRPARCEL END-EXEC */

            var m_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2_Update1 = new M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2_Update1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                HCTA_NRPARCEL = HCTA_NRPARCEL.ToString(),
            };

            M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2_Update1.Execute(m_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0036-INSERT-HISTCONTABILVA */
        private void M_0036_INSERT_HISTCONTABILVA(bool isPerform = false)
        {
            /*" -1922- MOVE '0036-INSERT-HISTCONTABILVA' TO PARAGRAFO. */
            _.Move("0036-INSERT-HISTCONTABILVA", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1924- MOVE 'SELECT V0PROPOSTAVA ' TO COMANDO */
            _.Move("SELECT V0PROPOSTAVA ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1926- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1950- PERFORM M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1 */

            M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1();

            /*" -1953- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1955- DISPLAY 'ERRO PESQUISA TABELA V0PROPOSTAVA SQLCODE = ' SQLCODE */
                _.Display($"ERRO PESQUISA TABELA V0PROPOSTAVA SQLCODE = {DB.SQLCODE}");

                /*" -1956- DISPLAY 'CERTIFICADO = ' HCTA-NRCERTIF */
                _.Display($"CERTIFICADO = {HCTA_NRCERTIF}");

                /*" -1958- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1959- MOVE 'SELECT CLIENTES     ' TO COMANDO */
            _.Move("SELECT CLIENTES     ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1967- PERFORM M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2 */

            M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2();

            /*" -1970- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1972- DISPLAY 'VA0812B - PROBLEMAS NO SELECT CLIENTES       ' PROP-CODCLIEN ' ' HCTA-NRCERTIF ' ' */

                $"VA0812B - PROBLEMAS NO SELECT CLIENTES       {PROP_CODCLIEN} {HCTA_NRCERTIF} "
                .Display();

                /*" -1974- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1975- IF VIND-DTNASC LESS +0 */

            if (VIND_DTNASC < +0)
            {

                /*" -1977- MOVE '1900-01-01' TO CLIENTES-DATA-NASCIMENTO */
                _.Move("1900-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -1979- END-IF. */
            }


            /*" -1980- MOVE 'SELECT V0COBERPROPVA ' TO COMANDO */
            _.Move("SELECT V0COBERPROPVA ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1999- PERFORM M_0036_INSERT_HISTCONTABILVA_DB_SELECT_3 */

            M_0036_INSERT_HISTCONTABILVA_DB_SELECT_3();

            /*" -2002- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2003- MOVE 'SELECT V0COBERPROPVA 1 ' TO COMANDO */
                _.Move("SELECT V0COBERPROPVA 1 ", LOCALIZA_ABEND_2.COMANDO);

                /*" -2022- PERFORM M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4 */

                M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4();

                /*" -2025- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2026- MOVE 'SELECT V0COBERPROPVA 2 ' TO COMANDO */
                    _.Move("SELECT V0COBERPROPVA 2 ", LOCALIZA_ABEND_2.COMANDO);

                    /*" -2046- PERFORM M_0036_INSERT_HISTCONTABILVA_DB_SELECT_5 */

                    M_0036_INSERT_HISTCONTABILVA_DB_SELECT_5();

                    /*" -2049- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2051- DISPLAY 'NRCERTIF = ' HCTA-NRCERTIF '  OCORHIST = ' PROP-OCORHIST */

                        $"NRCERTIF = {HCTA_NRCERTIF}  OCORHIST = {PROP_OCORHIST}"
                        .Display();

                        /*" -2053- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -2054- IF CBVA-VLPREMIO EQUAL ZEROS */

            if (CBVA_VLPREMIO == 00)
            {

                /*" -2055- MOVE ZEROS TO HOST-PRMAP */
                _.Move(0, HOST_PRMAP);

                /*" -2056- MOVE HCTA-VLPRMTOT TO HOST-PRMVG */
                _.Move(HCTA_VLPRMTOT, HOST_PRMVG);

                /*" -2057- ELSE */
            }
            else
            {


                /*" -2059- COMPUTE HOST-FATOR = CBVA-PRMAP / CBVA-VLPREMIO. */
                HOST_FATOR.Value = CBVA_PRMAP / CBVA_VLPREMIO;
            }


            /*" -2060- COMPUTE HOST-PRMAP ROUNDED = HCTA-VLPRMTOT * HOST-FATOR. */
            HOST_PRMAP.Value = HCTA_VLPRMTOT * HOST_FATOR;

            /*" -2062- COMPUTE HOST-PRMVG = HCTA-VLPRMTOT - HOST-PRMAP. */
            HOST_PRMVG.Value = HCTA_VLPRMTOT - HOST_PRMAP;

            /*" -2066- MOVE 'SELECT V0HISCOBVA   ' TO COMANDO */
            _.Move("SELECT V0HISCOBVA   ", LOCALIZA_ABEND_2.COMANDO);

            /*" -2081- PERFORM M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6 */

            M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6();

            /*" -2084- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2085- DISPLAY 'ERRO SELECT V0HISTCOBVA(COBER_HIST_VIDAZUL)' */
                _.Display($"ERRO SELECT V0HISTCOBVA(COBER_HIST_VIDAZUL)");

                /*" -2086- DISPLAY 'SQLCODE     = ' SQLCODE */
                _.Display($"SQLCODE     = {DB.SQLCODE}");

                /*" -2087- DISPLAY 'CERTIFICADO = ' HCTA-NRCERTIF */
                _.Display($"CERTIFICADO = {HCTA_NRCERTIF}");

                /*" -2088- DISPLAY 'NRPARCEL    = ' HCTA-NRPARCEL */
                _.Display($"NRPARCEL    = {HCTA_NRPARCEL}");

                /*" -2089- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2127- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0036-INSERT-HISTCONTABILVA-DB-SELECT-1 */
        public void M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1()
        {
            /*" -1950- EXEC SQL SELECT A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.DTVENCTO, A.OCORHIST, A.DTQITBCO, A.CODCLIEN, A.OPCAO_COBER, B.RAMO_EMISSOR INTO :PROP-NUM-APOLICE, :PROP-CODSUBES, :PROP-FONTE, :PROP-DTVENCTO, :PROP-OCORHIST, :PROP-DTQITBCO, :PROP-CODCLIEN, :PROP-OPCAO-COBER, :PROP-RAMO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.APOLICES B WHERE A.NRCERTIF = :HCTA-NRCERTIF AND A.NUM_APOLICE = B.NUM_APOLICE WITH UR END-EXEC. */

            var m_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1.Execute(m_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROP_NUM_APOLICE, PROP_NUM_APOLICE);
                _.Move(executed_1.PROP_CODSUBES, PROP_CODSUBES);
                _.Move(executed_1.PROP_FONTE, PROP_FONTE);
                _.Move(executed_1.PROP_DTVENCTO, PROP_DTVENCTO);
                _.Move(executed_1.PROP_OCORHIST, PROP_OCORHIST);
                _.Move(executed_1.PROP_DTQITBCO, PROP_DTQITBCO);
                _.Move(executed_1.PROP_CODCLIEN, PROP_CODCLIEN);
                _.Move(executed_1.PROP_OPCAO_COBER, PROP_OPCAO_COBER);
                _.Move(executed_1.PROP_RAMO, PROP_RAMO);
            }


        }

        [StopWatch]
        /*" M-0035-LOCALIZA-DEVMULTI-DB-UPDATE-3 */
        public void M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3()
        {
            /*" -1910- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA A SET A.SITUACAO = :HCTA-SITUACAO, A.NSAC = :SQL-NSAC, A.CODRET = :HCTA-CODRET, A.TIMESTAMP = CURRENT_TIMESTAMP, A.CODUSU = 'VA0812B' WHERE A.CODCONV = :WHOST-CODCONV AND A.NSAS = :MVCOM-NSAS AND A.NSL = :MVCOM-NSL END-EXEC */

            var m_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1 = new M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1()
            {
                HCTA_SITUACAO = HCTA_SITUACAO.ToString(),
                HCTA_CODRET = HCTA_CODRET.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1.Execute(m_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-0036-INSERT-HISTCONTABILVA-DB-SELECT-2 */
        public void M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2()
        {
            /*" -1967- EXEC SQL SELECT DATA_NASCIMENTO , CGCCPF INTO :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROP-CODCLIEN WITH UR END-EXEC. */

            var m_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1 = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1()
            {
                PROP_CODCLIEN = PROP_CODCLIEN.ToString(),
            };

            var executed_1 = M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1.Execute(m_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" M-0036-INSERT */
        private void M_0036_INSERT(bool isPerform = false)
        {
            /*" -2132- IF HCTA-OCORRHISTCTA > ZEROS */

            if (HCTA_OCORRHISTCTA > 00)
            {

                /*" -2133- MOVE HCTA-OCORRHISTCTA TO HCVA-OCORHIST */
                _.Move(HCTA_OCORRHISTCTA, HCVA_OCORHIST);

                /*" -2134- ELSE */
            }
            else
            {


                /*" -2135- ADD 1 TO HCVA-OCORHIST */
                HCVA_OCORHIST.Value = HCVA_OCORHIST + 1;

                /*" -2137- END-IF. */
            }


            /*" -2138- MOVE 'INSERT V0HISTCONTABILVA' TO COMANDO */
            _.Move("INSERT V0HISTCONTABILVA", LOCALIZA_ABEND_2.COMANDO);

            /*" -2171- PERFORM M_0036_INSERT_DB_INSERT_1 */

            M_0036_INSERT_DB_INSERT_1();

            /*" -2174- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2175- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2176- MOVE 'N' TO WAUX-FLAG */
                    _.Move("N", WAUX_FLAG);

                    /*" -2178- MOVE ZEROS TO HCTA-OCORRHISTCTA */
                    _.Move(0, HCTA_OCORRHISTCTA);

                    /*" -2179- GO TO 0036-INSERT */
                    new Task(() => M_0036_INSERT()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2180- ELSE */
                }
                else
                {


                    /*" -2182- DISPLAY 'ERRO INSERT V0HISTCONTABILVA SQLCODE = ' SQLCODE */
                    _.Display($"ERRO INSERT V0HISTCONTABILVA SQLCODE = {DB.SQLCODE}");

                    /*" -2183- DISPLAY 'HCTA-NRCERTIF    ' HCTA-NRCERTIF, */
                    _.Display($"HCTA-NRCERTIF    {HCTA_NRCERTIF}");

                    /*" -2184- DISPLAY 'HCTA-NRPARCEL    ' HCTA-NRPARCEL, */
                    _.Display($"HCTA-NRPARCEL    {HCTA_NRPARCEL}");

                    /*" -2185- DISPLAY 'HCVA-NRTIT       ' HCVA-NRTIT, */
                    _.Display($"HCVA-NRTIT       {HCVA_NRTIT}");

                    /*" -2186- DISPLAY 'HCVA-OCORHIST    ' HCVA-OCORHIST, */
                    _.Display($"HCVA-OCORHIST    {HCVA_OCORHIST}");

                    /*" -2187- DISPLAY 'PROP-NUM-APOLICE ' PROP-NUM-APOLICE, */
                    _.Display($"PROP-NUM-APOLICE {PROP_NUM_APOLICE}");

                    /*" -2188- DISPLAY 'PROP-CODSUBES    ' PROP-CODSUBES, */
                    _.Display($"PROP-CODSUBES    {PROP_CODSUBES}");

                    /*" -2189- DISPLAY 'PROP-FONTE       ' PROP-FONTE, */
                    _.Display($"PROP-FONTE       {PROP_FONTE}");

                    /*" -2190- DISPLAY 'HOST-PRMVG       ' HOST-PRMVG, */
                    _.Display($"HOST-PRMVG       {HOST_PRMVG}");

                    /*" -2191- DISPLAY 'HOST-PRMAP       ' HOST-PRMAP, */
                    _.Display($"HOST-PRMAP       {HOST_PRMAP}");

                    /*" -2192- DISPLAY 'DTMOVABE         ' DTMOVABE, */
                    _.Display($"DTMOVABE         {DTMOVABE}");

                    /*" -2193- END-IF */
                }


                /*" -2194- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2196- END-IF. */
            }


            /*" -2197- MOVE PROP-DTQITBCO TO WHOST-DTVENCTO */
            _.Move(PROP_DTQITBCO, WHOST_DTVENCTO);

            /*" -2199- MOVE 2011 TO WHOST-DTVENCTO(1:4) */
            _.MoveAtPosition(2011, WHOST_DTVENCTO, 1, 4);

            /*" -2201- IF (WHOST-DTVENCTO(6:2) EQUAL 02) AND (WHOST-DTVENCTO(9:2) EQUAL 28 OR 29) */

            if ((WHOST_DTVENCTO.Substring(6, 2) == 02) && (WHOST_DTVENCTO.Substring(9, 2).In("28", "29")))
            {

                /*" -2202- PERFORM R0300-00-CALCULA-BISSEXTO */

                R0300_00_CALCULA_BISSEXTO(true);

                /*" -2204- END-IF. */
            }


            /*" -2206- IF PROP-DTQITBCO GREATER '2010-12-31' OR HCVA-DTVENCTO GREATER WHOST-DTVENCTO */

            if (PROP_DTQITBCO > "2010-12-31" || HCVA_DTVENCTO > WHOST_DTVENCTO)
            {

                /*" -2207- IF PROP-DTQITBCO GREATER '2010-12-31' */

                if (PROP_DTQITBCO > "2010-12-31")
                {

                    /*" -2208- MOVE PROP-DTQITBCO TO WHOST-DTVENCTO1 */
                    _.Move(PROP_DTQITBCO, WHOST_DTVENCTO1);

                    /*" -2209- ELSE */
                }
                else
                {


                    /*" -2210- MOVE WHOST-DTVENCTO TO WHOST-DTVENCTO1 */
                    _.Move(WHOST_DTVENCTO, WHOST_DTVENCTO1);

                    /*" -2211- END-IF */
                }


                /*" -2212- MOVE WHOST-DTVENCTO1(1:4) TO WHOST-ANO-VENC */
                _.Move(WHOST_DTVENCTO1.Substring(1, 4), WHOST_ANO_VENC);

                /*" -2213- MOVE CLIENTES-DATA-NASCIMENTO(1:4) TO WHOST-ANO-NASC */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(1, 4), WHOST_ANO_NASC);

                /*" -2214- COMPUTE WHOST-IDADE = WHOST-ANO-VENC - WHOST-ANO-NASC */
                WHOST_IDADE.Value = WHOST_ANO_VENC - WHOST_ANO_NASC;

                /*" -2215- PERFORM 0037-00-DECLARE-VGRAMOCOMP THRU 0037-FIM */

                M_0037_00_DECLARE_VGRAMOCOMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0037_FIM*/


                /*" -2216- PERFORM 0038-00-FETCH-VGRAMOCOMP THRU 0038-FIM */

                M_0038_00_FETCH_VGRAMOCOMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0038_FIM*/


                /*" -2217- INITIALIZE WORK-TAB-RAMO-CONJ */
                _.Initialize(
                    WORK_TAB_RAMO_CONJ
                );

                /*" -2220- MOVE ZEROS TO WS-IND WHOST-VLR-PERC-PREMIO-TOT WS-PREMIO-TOTAL-AC */
                _.Move(0, WORK_RAMO_CONJ.WS_IND, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT, WS_PREMIO_TOTAL_AC);

                /*" -2222- COMPUTE WS-PREMIO-TOTAL = HOST-PRMVG + HOST-PRMAP */
                WS_PREMIO_TOTAL.Value = HOST_PRMVG + HOST_PRMAP;

                /*" -2225- PERFORM M-0039-00-PROCESSA-VGRAMOCOMP THRU 0039-FIM UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' */

                while (!(WFIM_VGRAMOCOMP == "SIM"))
                {

                    M_0039_00_PROCESSA_VGRAMOCOMP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0039_FIM*/

                }

                /*" -2226- IF WS-IND GREATER ZEROS */

                if (WORK_RAMO_CONJ.WS_IND > 00)
                {

                    /*" -2227- IF PROP-RAMO NOT EQUAL TB-RAMO-CONJ (WS-IND) */

                    if (PROP_RAMO != WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ)
                    {

                        /*" -2228- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND) TO WS-SALVA */
                        _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND], WORK_RAMO_CONJ.WS_SALVA);

                        /*" -2231- PERFORM VARYING WS-IND1 FROM 1 BY 1 UNTIL TB-RAMO-CONJ (WS-IND1) EQUAL PROP-RAMO OR WS-IND1 EQUAL WS-IND */

                        for (WORK_RAMO_CONJ.WS_IND1.Value = 1; !(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ == PROP_RAMO || WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND); WORK_RAMO_CONJ.WS_IND1.Value += 1)
                        {

                            /*" -2232- END-PERFORM */
                        }

                        /*" -2234- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND1) TO N5WORK-TAB-RAMO-CONJ(WS-IND) */
                        _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1], WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND]);

                        /*" -2235- MOVE WS-SALVA TO N5WORK-TAB-RAMO-CONJ(WS-IND1) */
                        _.Move(WORK_RAMO_CONJ.WS_SALVA, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1]);

                        /*" -2236- END-IF */
                    }


                    /*" -2238- END-IF */
                }


                /*" -2239- MOVE 'NAO' TO WFIM-TAB-RAMO */
                _.Move("NAO", WFIM_TAB_RAMO);

                /*" -2240- MOVE ZEROS TO WS-IND1 */
                _.Move(0, WORK_RAMO_CONJ.WS_IND1);

                /*" -2242- PERFORM 0042-00-INSERT-VGHISTCONT THRU 0042-FIM UNTIL WFIM-TAB-RAMO EQUAL 'SIM' */

                while (!(WFIM_TAB_RAMO == "SIM"))
                {

                    M_0042_00_INSERT_VGHISTCONT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0042_FIM*/

                }

                /*" -2244- END-IF. */
            }


            /*" -2245- MOVE 'UPDATE V0HISTCOBVA 1   ' TO COMANDO */
            _.Move("UPDATE V0HISTCOBVA 1   ", LOCALIZA_ABEND_2.COMANDO);

            /*" -2251- PERFORM M_0036_INSERT_DB_UPDATE_1 */

            M_0036_INSERT_DB_UPDATE_1();

            /*" -2254- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2256- DISPLAY 'ERRO UPDATE SEGUROS.V0HISTCOBVA SQLCODE = ' SQLCODE */
                _.Display($"ERRO UPDATE SEGUROS.V0HISTCOBVA SQLCODE = {DB.SQLCODE}");

                /*" -2257- DISPLAY 'CERTIFICADO = ' HCTA-NRCERTIF */
                _.Display($"CERTIFICADO = {HCTA_NRCERTIF}");

                /*" -2258- DISPLAY 'NRPARCEL    = ' HCTA-NRPARCEL */
                _.Display($"NRPARCEL    = {HCTA_NRPARCEL}");

                /*" -2260- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -2261- MOVE 'UPDATE V0PARCELVA      ' TO COMANDO */
            _.Move("UPDATE V0PARCELVA      ", LOCALIZA_ABEND_2.COMANDO);

            /*" -2266- PERFORM M_0036_INSERT_DB_UPDATE_2 */

            M_0036_INSERT_DB_UPDATE_2();

            /*" -2269- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2271- DISPLAY 'ERRO UPDATE SEGUROS.V0PARCELVA  SQLCODE = ' SQLCODE */
                _.Display($"ERRO UPDATE SEGUROS.V0PARCELVA  SQLCODE = {DB.SQLCODE}");

                /*" -2272- DISPLAY 'CERTIFICADO = ' HCTA-NRCERTIF */
                _.Display($"CERTIFICADO = {HCTA_NRCERTIF}");

                /*" -2273- DISPLAY 'NRPARCEL    = ' HCTA-NRPARCEL */
                _.Display($"NRPARCEL    = {HCTA_NRPARCEL}");

                /*" -2274- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2274- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0036-INSERT-DB-INSERT-1 */
        public void M_0036_INSERT_DB_INSERT_1()
        {
            /*" -2171- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA (NRCERTIF, NRPARCEL, NRTIT, OCOORHIST, NUM_APOLICE, CODSUBES, FONTE, NRENDOS, PRMVG, PRMAP, DTMOVTO, SITUACAO, CODOPER, TIMESTAMP, DTFATUR) VALUES (:HCTA-NRCERTIF, :HCTA-NRPARCEL, :HCVA-NRTIT, :HCVA-OCORHIST, :PROP-NUM-APOLICE, :PROP-CODSUBES, :PROP-FONTE, 0, :HOST-PRMVG, :HOST-PRMAP, :DTMOVABE, '0' , 501, CURRENT TIMESTAMP, NULL) END-EXEC. */

            var m_0036_INSERT_DB_INSERT_1_Insert1 = new M_0036_INSERT_DB_INSERT_1_Insert1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                HCTA_NRPARCEL = HCTA_NRPARCEL.ToString(),
                HCVA_NRTIT = HCVA_NRTIT.ToString(),
                HCVA_OCORHIST = HCVA_OCORHIST.ToString(),
                PROP_NUM_APOLICE = PROP_NUM_APOLICE.ToString(),
                PROP_CODSUBES = PROP_CODSUBES.ToString(),
                PROP_FONTE = PROP_FONTE.ToString(),
                HOST_PRMVG = HOST_PRMVG.ToString(),
                HOST_PRMAP = HOST_PRMAP.ToString(),
                DTMOVABE = DTMOVABE.ToString(),
            };

            M_0036_INSERT_DB_INSERT_1_Insert1.Execute(m_0036_INSERT_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0036-INSERT-DB-UPDATE-1 */
        public void M_0036_INSERT_DB_UPDATE_1()
        {
            /*" -2251- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET OCORHIST = :HCVA-OCORHIST , SITUACAO = '7' WHERE NRCERTIF =:HCTA-NRCERTIF AND NRPARCEL =:HCTA-NRPARCEL END-EXEC. */

            var m_0036_INSERT_DB_UPDATE_1_Update1 = new M_0036_INSERT_DB_UPDATE_1_Update1()
            {
                HCVA_OCORHIST = HCVA_OCORHIST.ToString(),
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                HCTA_NRPARCEL = HCTA_NRPARCEL.ToString(),
            };

            M_0036_INSERT_DB_UPDATE_1_Update1.Execute(m_0036_INSERT_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0036-INSERT-HISTCONTABILVA-DB-SELECT-3 */
        public void M_0036_INSERT_HISTCONTABILVA_DB_SELECT_3()
        {
            /*" -1999- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, IMPMORNATU, IMPMORACID, IMPDIT, IMPSEGCDC INTO :CBVA-VLPREMIO, :CBVA-PRMVG, :CBVA-PRMAP, :CBVA-IMPMORNATU, :CBVA-IMPMORACID, :CBVA-IMPDIT, :CBVA-IMPSEGCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF =:HCTA-NRCERTIF AND OCORHIST =:PROP-OCORHIST WITH UR END-EXEC. */

            var m_0036_INSERT_HISTCONTABILVA_DB_SELECT_3_Query1 = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_3_Query1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                PROP_OCORHIST = PROP_OCORHIST.ToString(),
            };

            var executed_1 = M_0036_INSERT_HISTCONTABILVA_DB_SELECT_3_Query1.Execute(m_0036_INSERT_HISTCONTABILVA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBVA_VLPREMIO, CBVA_VLPREMIO);
                _.Move(executed_1.CBVA_PRMVG, CBVA_PRMVG);
                _.Move(executed_1.CBVA_PRMAP, CBVA_PRMAP);
                _.Move(executed_1.CBVA_IMPMORNATU, CBVA_IMPMORNATU);
                _.Move(executed_1.CBVA_IMPMORACID, CBVA_IMPMORACID);
                _.Move(executed_1.CBVA_IMPDIT, CBVA_IMPDIT);
                _.Move(executed_1.CBVA_IMPSEGCDG, CBVA_IMPSEGCDG);
            }


        }

        [StopWatch]
        /*" M-0036-INSERT-DB-UPDATE-2 */
        public void M_0036_INSERT_DB_UPDATE_2()
        {
            /*" -2266- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '2' WHERE NRCERTIF =:HCTA-NRCERTIF AND NRPARCEL =:HCTA-NRPARCEL END-EXEC. */

            var m_0036_INSERT_DB_UPDATE_2_Update1 = new M_0036_INSERT_DB_UPDATE_2_Update1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                HCTA_NRPARCEL = HCTA_NRPARCEL.ToString(),
            };

            M_0036_INSERT_DB_UPDATE_2_Update1.Execute(m_0036_INSERT_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0036_FIM*/

        [StopWatch]
        /*" M-0036-INSERT-HISTCONTABILVA-DB-SELECT-4 */
        public void M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4()
        {
            /*" -2022- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, IMPMORNATU, IMPMORACID, IMPDIT, IMPSEGCDC INTO :CBVA-VLPREMIO, :CBVA-PRMVG, :CBVA-PRMAP, :CBVA-IMPMORNATU, :CBVA-IMPMORACID, :CBVA-IMPDIT, :CBVA-IMPSEGCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF =:HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var m_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1 = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1.Execute(m_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBVA_VLPREMIO, CBVA_VLPREMIO);
                _.Move(executed_1.CBVA_PRMVG, CBVA_PRMVG);
                _.Move(executed_1.CBVA_PRMAP, CBVA_PRMAP);
                _.Move(executed_1.CBVA_IMPMORNATU, CBVA_IMPMORNATU);
                _.Move(executed_1.CBVA_IMPMORACID, CBVA_IMPMORACID);
                _.Move(executed_1.CBVA_IMPDIT, CBVA_IMPDIT);
                _.Move(executed_1.CBVA_IMPSEGCDG, CBVA_IMPSEGCDG);
            }


        }

        [StopWatch]
        /*" M-0037-00-DECLARE-VGRAMOCOMP */
        private void M_0037_00_DECLARE_VGRAMOCOMP(bool isPerform = false)
        {
            /*" -2282- MOVE '0037-00-DECLARE-VGRAMOCOMP   ' TO PARAGRAFO. */
            _.Move("0037-00-DECLARE-VGRAMOCOMP   ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2284- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2286- MOVE 'NAO' TO WFIM-VGRAMOCOMP. */
            _.Move("NAO", WFIM_VGRAMOCOMP);

            /*" -2297- IF PROP-NUM-APOLICE = 109300000559 OR 109300000709 OR 109300001311 OR 109300001392 OR 109300001393 OR 3009300000559 OR 3009300001559 OR 109300000709 OR 109300001311 OR 109300001392 OR 109300001393 */

            if (PROP_NUM_APOLICE.In("109300000559", "109300000709", "109300001311", "109300001392", "109300001393", "3009300000559", "3009300001559", "109300000709", "109300001311", "109300001392", "109300001393"))
            {

                /*" -2299- MOVE PROP-OPCAO-COBER TO WHOST-OPCAO-COBER */
                _.Move(PROP_OPCAO_COBER, WHOST_OPCAO_COBER);

                /*" -2300- ELSE */
            }
            else
            {


                /*" -2302- MOVE ' ' TO WHOST-OPCAO-COBER */
                _.Move(" ", WHOST_OPCAO_COBER);

                /*" -2304- END-IF. */
            }


            /*" -2348- PERFORM M_0037_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1 */

            M_0037_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1();

            /*" -2350- PERFORM M_0037_00_DECLARE_VGRAMOCOMP_DB_OPEN_1 */

            M_0037_00_DECLARE_VGRAMOCOMP_DB_OPEN_1();

            /*" -2353- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2354- DISPLAY '0037 - (PROBLEMAS NO DECLARE CVGRAMOCOMP) ..' */
                _.Display($"0037 - (PROBLEMAS NO DECLARE CVGRAMOCOMP) ..");

                /*" -2355- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2356- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0037-00-DECLARE-VGRAMOCOMP-DB-DECLARE-1 */
        public void M_0037_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1()
        {
            /*" -2348- EXEC SQL DECLARE CVGRAMOCOMP CURSOR FOR SELECT DISTINCT B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_GRUPO_SUSEP , B.RAMO_EMISSOR , B.COD_MODALIDADE , B.DTH_INI_VIGENCIA , B.COD_OPCAO_COBERTURA , B.NUM_IDADE_INICIAL , B.NUM_IDADE_FINAL , B.VLR_PERC_PREMIO , B.COD_USUARIO , B.DTH_ATUALIZACAO FROM SEGUROS.VG_PARAM_RAMO_CONJ A, SEGUROS.VG_PARAM_RAMO_COMP B WHERE A.NUM_APOLICE = :PROP-NUM-APOLICE AND A.COD_SUBGRUPO = :PROP-CODSUBES AND A.DTH_INI_VIGENCIA <= :WHOST-DTVENCTO1 AND A.DTH_TER_VIGENCIA >= :WHOST-DTVENCTO1 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.RAMO_EMISSOR = A.RAMO_EMISSOR AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA AND B.NUM_IDADE_INICIAL <= :WHOST-IDADE AND B.NUM_IDADE_FINAL >= :WHOST-IDADE AND B.COD_OPCAO_COBERTURA = :WHOST-OPCAO-COBER ORDER BY B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_GRUPO_SUSEP , B.RAMO_EMISSOR , B.COD_MODALIDADE , B.DTH_INI_VIGENCIA , B.COD_OPCAO_COBERTURA , B.NUM_IDADE_INICIAL , B.NUM_IDADE_FINAL , B.VLR_PERC_PREMIO , B.COD_USUARIO , B.DTH_ATUALIZACAO WITH UR END-EXEC. */
            CVGRAMOCOMP = new VA0812B_CVGRAMOCOMP(true);
            string GetQuery_CVGRAMOCOMP()
            {
                var query = @$"SELECT DISTINCT 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_GRUPO_SUSEP
							, 
							B.RAMO_EMISSOR
							, 
							B.COD_MODALIDADE
							, 
							B.DTH_INI_VIGENCIA
							, 
							B.COD_OPCAO_COBERTURA
							, 
							B.NUM_IDADE_INICIAL
							, 
							B.NUM_IDADE_FINAL
							, 
							B.VLR_PERC_PREMIO
							, 
							B.COD_USUARIO
							, 
							B.DTH_ATUALIZACAO 
							FROM SEGUROS.VG_PARAM_RAMO_CONJ A
							, 
							SEGUROS.VG_PARAM_RAMO_COMP B 
							WHERE A.NUM_APOLICE = '{PROP_NUM_APOLICE}' 
							AND A.COD_SUBGRUPO = '{PROP_CODSUBES}' 
							AND A.DTH_INI_VIGENCIA <= '{WHOST_DTVENCTO1}' 
							AND A.DTH_TER_VIGENCIA >= '{WHOST_DTVENCTO1}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.RAMO_EMISSOR = A.RAMO_EMISSOR 
							AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA 
							AND B.NUM_IDADE_INICIAL <= 
							'{WHOST_IDADE}' 
							AND B.NUM_IDADE_FINAL >= 
							'{WHOST_IDADE}' 
							AND B.COD_OPCAO_COBERTURA = 
							'{WHOST_OPCAO_COBER}' 
							ORDER BY 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_GRUPO_SUSEP
							, 
							B.RAMO_EMISSOR
							, 
							B.COD_MODALIDADE
							, 
							B.DTH_INI_VIGENCIA
							, 
							B.COD_OPCAO_COBERTURA
							, 
							B.NUM_IDADE_INICIAL
							, 
							B.NUM_IDADE_FINAL
							, 
							B.VLR_PERC_PREMIO
							, 
							B.COD_USUARIO
							, 
							B.DTH_ATUALIZACAO";

                return query;
            }
            CVGRAMOCOMP.GetQueryEvent += GetQuery_CVGRAMOCOMP;

        }

        [StopWatch]
        /*" M-0037-00-DECLARE-VGRAMOCOMP-DB-OPEN-1 */
        public void M_0037_00_DECLARE_VGRAMOCOMP_DB_OPEN_1()
        {
            /*" -2350- EXEC SQL OPEN CVGRAMOCOMP END-EXEC. */

            CVGRAMOCOMP.Open();

        }

        [StopWatch]
        /*" M-3000-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -3691- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            V1AGENCEF = new VA0812B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.V1AGENCIACEF A
							, 
							SEGUROS.V1MALHACEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }

        [StopWatch]
        /*" M-0036-INSERT-HISTCONTABILVA-DB-SELECT-5 */
        public void M_0036_INSERT_HISTCONTABILVA_DB_SELECT_5()
        {
            /*" -2046- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, IMPMORNATU, IMPMORACID, IMPDIT, IMPSEGCDC INTO :CBVA-VLPREMIO, :CBVA-PRMVG, :CBVA-PRMAP, :CBVA-IMPMORNATU, :CBVA-IMPMORACID, :CBVA-IMPDIT, :CBVA-IMPSEGCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF =:HCTA-NRCERTIF AND DTINIVIG <= :PROP-DTVENCTO AND DTTERVIG >= :PROP-DTVENCTO WITH UR END-EXEC. */

            var m_0036_INSERT_HISTCONTABILVA_DB_SELECT_5_Query1 = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_5_Query1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                PROP_DTVENCTO = PROP_DTVENCTO.ToString(),
            };

            var executed_1 = M_0036_INSERT_HISTCONTABILVA_DB_SELECT_5_Query1.Execute(m_0036_INSERT_HISTCONTABILVA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBVA_VLPREMIO, CBVA_VLPREMIO);
                _.Move(executed_1.CBVA_PRMVG, CBVA_PRMVG);
                _.Move(executed_1.CBVA_PRMAP, CBVA_PRMAP);
                _.Move(executed_1.CBVA_IMPMORNATU, CBVA_IMPMORNATU);
                _.Move(executed_1.CBVA_IMPMORACID, CBVA_IMPMORACID);
                _.Move(executed_1.CBVA_IMPDIT, CBVA_IMPDIT);
                _.Move(executed_1.CBVA_IMPSEGCDG, CBVA_IMPSEGCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0037_FIM*/

        [StopWatch]
        /*" M-0036-INSERT-HISTCONTABILVA-DB-SELECT-6 */
        public void M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6()
        {
            /*" -2081- EXEC SQL SELECT OCORHIST, NRTIT, DTVENCTO INTO :HCVA-OCORHIST, :HCVA-NRTIT, :HCVA-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :HCTA-NRCERTIF AND NRPARCEL = :HCTA-NRPARCEL AND NRTIT = ( SELECT MAX(NRTIT) FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :HCTA-NRCERTIF AND NRPARCEL = :HCTA-NRPARCEL ) WITH UR END-EXEC. */

            var m_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1 = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                HCTA_NRPARCEL = HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1.Execute(m_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HCVA_OCORHIST, HCVA_OCORHIST);
                _.Move(executed_1.HCVA_NRTIT, HCVA_NRTIT);
                _.Move(executed_1.HCVA_DTVENCTO, HCVA_DTVENCTO);
            }


        }

        [StopWatch]
        /*" M-0038-00-FETCH-VGRAMOCOMP */
        private void M_0038_00_FETCH_VGRAMOCOMP(bool isPerform = false)
        {
            /*" -2364- MOVE '0038-00-FETCH-CURSOR         ' TO PARAGRAFO. */
            _.Move("0038-00-FETCH-CURSOR         ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2366- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2380- PERFORM M_0038_00_FETCH_VGRAMOCOMP_DB_FETCH_1 */

            M_0038_00_FETCH_VGRAMOCOMP_DB_FETCH_1();

            /*" -2383- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2384- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2385- MOVE 'SIM' TO WFIM-VGRAMOCOMP */
                    _.Move("SIM", WFIM_VGRAMOCOMP);

                    /*" -2385- PERFORM M_0038_00_FETCH_VGRAMOCOMP_DB_CLOSE_1 */

                    M_0038_00_FETCH_VGRAMOCOMP_DB_CLOSE_1();

                    /*" -2387- GO TO 0038-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0038_FIM*/ //GOTO
                    return;

                    /*" -2388- ELSE */
                }
                else
                {


                    /*" -2389- DISPLAY '0038 - (PROBLEMAS NO FETCH CVGRAMOCOMP) ..' */
                    _.Display($"0038 - (PROBLEMAS NO FETCH CVGRAMOCOMP) ..");

                    /*" -2390- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -2391- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0038-00-FETCH-VGRAMOCOMP-DB-FETCH-1 */
        public void M_0038_00_FETCH_VGRAMOCOMP_DB_FETCH_1()
        {
            /*" -2380- EXEC SQL FETCH CVGRAMOCOMP INTO :VG081-NUM-APOLICE , :VG081-COD-SUBGRUPO , :VG081-COD-GRUPO-SUSEP , :VG081-RAMO-EMISSOR , :VG081-COD-MODALIDADE , :VG081-DTH-INI-VIGENCIA , :VG081-COD-OPCAO-COBERTURA , :VG081-NUM-IDADE-INICIAL , :VG081-NUM-IDADE-FINAL , :VG081-VLR-PERC-PREMIO , :VG081-COD-USUARIO , :VG081-DTH-ATUALIZACAO END-EXEC. */

            if (CVGRAMOCOMP.Fetch())
            {
                _.Move(CVGRAMOCOMP.VG081_NUM_APOLICE, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_APOLICE);
                _.Move(CVGRAMOCOMP.VG081_COD_SUBGRUPO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_SUBGRUPO);
                _.Move(CVGRAMOCOMP.VG081_COD_GRUPO_SUSEP, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP);
                _.Move(CVGRAMOCOMP.VG081_RAMO_EMISSOR, VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR);
                _.Move(CVGRAMOCOMP.VG081_COD_MODALIDADE, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE);
                _.Move(CVGRAMOCOMP.VG081_DTH_INI_VIGENCIA, VG081.DCLVG_PARAM_RAMO_COMP.VG081_DTH_INI_VIGENCIA);
                _.Move(CVGRAMOCOMP.VG081_COD_OPCAO_COBERTURA, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_OPCAO_COBERTURA);
                _.Move(CVGRAMOCOMP.VG081_NUM_IDADE_INICIAL, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_IDADE_INICIAL);
                _.Move(CVGRAMOCOMP.VG081_NUM_IDADE_FINAL, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_IDADE_FINAL);
                _.Move(CVGRAMOCOMP.VG081_VLR_PERC_PREMIO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO);
                _.Move(CVGRAMOCOMP.VG081_COD_USUARIO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_USUARIO);
                _.Move(CVGRAMOCOMP.VG081_DTH_ATUALIZACAO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_DTH_ATUALIZACAO);
            }

        }

        [StopWatch]
        /*" M-0038-00-FETCH-VGRAMOCOMP-DB-CLOSE-1 */
        public void M_0038_00_FETCH_VGRAMOCOMP_DB_CLOSE_1()
        {
            /*" -2385- EXEC SQL CLOSE CVGRAMOCOMP END-EXEC */

            CVGRAMOCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0038_FIM*/

        [StopWatch]
        /*" M-0039-00-PROCESSA-VGRAMOCOMP */
        private void M_0039_00_PROCESSA_VGRAMOCOMP(bool isPerform = false)
        {
            /*" -2399- MOVE '0039-00-PROCESSA-VGRAMOCOMP  ' TO PARAGRAFO. */
            _.Move("0039-00-PROCESSA-VGRAMOCOMP  ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2401- MOVE VG081-COD-GRUPO-SUSEP TO WS-GRUPO-SUSEP-ANT */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP, WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT);

            /*" -2404- MOVE VG081-RAMO-EMISSOR TO WS-RAMO-CONJ-ANT */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR, WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT);

            /*" -2407- MOVE ZEROS TO WHOST-TAXA-RAMO WHOST-VLR-PERC-PREMIO */
            _.Move(0, WHOST_TAXA_RAMO, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO);

            /*" -2414- PERFORM 0040-00-PROCESSA-REGISTRO THRU 0040-FIM UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT. */

            while (!(WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
            {

                M_0040_00_PROCESSA_REGISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_FIM*/

            }

            /*" -2415- ADD 1 TO WS-IND */
            WORK_RAMO_CONJ.WS_IND.Value = WORK_RAMO_CONJ.WS_IND + 1;

            /*" -2417- MOVE WS-GRUPO-SUSEP-ANT TO TB-GRUPO-SUSEP (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_GRUPO_SUSEP);

            /*" -2419- MOVE WS-RAMO-CONJ-ANT TO TB-RAMO-CONJ (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ);

            /*" -2421- MOVE WHOST-VLR-PERC-PREMIO TO TB-TAXA-RAMO-CONJ (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_TAXA_RAMO_CONJ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0039_FIM*/

        [StopWatch]
        /*" M-0040-00-PROCESSA-REGISTRO */
        private void M_0040_00_PROCESSA_REGISTRO(bool isPerform = false)
        {
            /*" -2429- MOVE '0040-00-PROCESSA-REGISTRO    ' TO PARAGRAFO. */
            _.Move("0040-00-PROCESSA-REGISTRO    ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2431- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2437- IF (PROP-NUM-APOLICE = 0109300000550 OR 0109300000559 OR 0109300000559 OR 3009300000559 OR 3009300001559 ) AND WS-RAMO-CONJ-ANT = 84 */

            if ((PROP_NUM_APOLICE.In("0109300000550", "0109300000559", "0109300000559", "3009300000559", "3009300001559")) && WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 84)
            {

                /*" -2438- IF CBVA-IMPMORNATU > 0 */

                if (CBVA_IMPMORNATU > 0)
                {

                    /*" -2441- DIVIDE CBVA-IMPSEGCDG BY CBVA-IMPMORNATU GIVING WHOST-PERC-CDG */
                    _.Divide(CBVA_IMPSEGCDG, CBVA_IMPMORNATU, WHOST_PERC_CDG);

                    /*" -2442- ELSE */
                }
                else
                {


                    /*" -2443- IF CBVA-IMPMORACID > 0 */

                    if (CBVA_IMPMORACID > 0)
                    {

                        /*" -2446- DIVIDE CBVA-IMPSEGCDG BY CBVA-IMPMORACID GIVING WHOST-PERC-CDG */
                        _.Divide(CBVA_IMPSEGCDG, CBVA_IMPMORACID, WHOST_PERC_CDG);

                        /*" -2447- ELSE */
                    }
                    else
                    {


                        /*" -2448- MOVE ZEROS TO WHOST-PERC-CDG */
                        _.Move(0, WHOST_PERC_CDG);

                        /*" -2449- END-IF */
                    }


                    /*" -2450- END-IF */
                }


                /*" -2452- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-CDG */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_CDG;

                /*" -2454- END-IF. */
            }


            /*" -2455- IF WS-RAMO-CONJ-ANT = 82 */

            if (WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 82)
            {

                /*" -2456- IF CBVA-IMPMORNATU > 0 */

                if (CBVA_IMPMORNATU > 0)
                {

                    /*" -2459- DIVIDE CBVA-IMPDIT BY CBVA-IMPMORNATU GIVING WHOST-PERC-DIT */
                    _.Divide(CBVA_IMPDIT, CBVA_IMPMORNATU, WHOST_PERC_DIT);

                    /*" -2460- ELSE */
                }
                else
                {


                    /*" -2461- IF CBVA-IMPMORACID > 0 */

                    if (CBVA_IMPMORACID > 0)
                    {

                        /*" -2464- DIVIDE CBVA-IMPDIT BY CBVA-IMPMORACID GIVING WHOST-PERC-DIT */
                        _.Divide(CBVA_IMPDIT, CBVA_IMPMORACID, WHOST_PERC_DIT);

                        /*" -2465- ELSE */
                    }
                    else
                    {


                        /*" -2466- MOVE ZEROS TO WHOST-PERC-DIT */
                        _.Move(0, WHOST_PERC_DIT);

                        /*" -2467- END-IF */
                    }


                    /*" -2468- END-IF */
                }


                /*" -2470- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-DIT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_DIT;

                /*" -2472- END-IF */
            }


            /*" -2476- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -2477- PERFORM 0038-00-FETCH-VGRAMOCOMP THRU 0038-FIM. */

            M_0038_00_FETCH_VGRAMOCOMP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0038_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_FIM*/

        [StopWatch]
        /*" M-0041-LOCALIZA-6039 */
        private void M_0041_LOCALIZA_6039(bool isPerform = false)
        {
            /*" -2491- MOVE '0041-LOCALIZA-6039' TO PARAGRAFO. */
            _.Move("0041-LOCALIZA-6039", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2493- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2497- MOVE RF-SERIE TO LK-NUMERO WS-SERIE WS-SERIE-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA_R.RF_SERIE, LK_MOD11CF.LK_NUMERO, WS_NRPROPAZ_R.WS_NRPROPAZ_1_R.WS_SERIE, WORK_AREA.WS_NSL_R.WS_SERIE_NSL);

            /*" -2498- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2500- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -2502- CALL 'PROM11CF' USING LK-MOD11CF. */
            _.Call("PROM11CF", LK_MOD11CF);

            /*" -2503- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2504- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -2505- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2506- ADD SFT TO STT(8) */
            TOTAIS_ROT.FILLER_29[8].STT.Value = TOTAIS_ROT.FILLER_29[8].STT + WS_HORAS.SFT;

            /*" -2508- ADD 1 TO SQT(8) */
            TOTAIS_ROT.FILLER_29[8].SQT.Value = TOTAIS_ROT.FILLER_29[8].SQT + 1;

            /*" -2509- MOVE LK-DV TO WS-DV-SERIE. */
            _.Move(LK_MOD11CF.LK_DV, WS_NRPROPAZ_R.WS_NRPROPAZ_1_R.WS_DV_SERIE);

            /*" -2512- MOVE RF-NSL TO WS-PROPOSTA WS-PROPOSTA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, WS_NRPROPAZ_R.WS_NRPROPAZ_1_R.WS_PROPOSTA);
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, WORK_AREA.WS_NSL_R.WS_PROPOSTA_NSL);


            /*" -2514- MOVE WS-NRPROPAZ-1 TO LK-NUMERO. */
            _.Move(WS_NRPROPAZ_R.WS_NRPROPAZ_1, LK_MOD11CF.LK_NUMERO);

            /*" -2515- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2517- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -2519- CALL 'PROM11CF' USING LK-MOD11CF. */
            _.Call("PROM11CF", LK_MOD11CF);

            /*" -2520- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2521- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -2522- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2523- ADD SFT TO STT(9) */
            TOTAIS_ROT.FILLER_29[9].STT.Value = TOTAIS_ROT.FILLER_29[9].STT + WS_HORAS.SFT;

            /*" -2525- ADD 1 TO SQT(9) */
            TOTAIS_ROT.FILLER_29[9].SQT.Value = TOTAIS_ROT.FILLER_29[9].SQT + 1;

            /*" -2527- MOVE LK-DV TO WS-DV-PROP. */
            _.Move(LK_MOD11CF.LK_DV, WS_NRPROPAZ_R.WS_DV_PROP);

            /*" -2529- MOVE WS-NRPROPAZ TO PROPAZ-NRPROPAZ. */
            _.Move(WS_NRPROPAZ, PROPAZ_NRPROPAZ);

            /*" -2531- MOVE WS-NSL TO MVCOM-NSL. */
            _.Move(WORK_AREA.WS_NSL, MVCOM_NSL);

            /*" -2534- MOVE 'SELECT V0MOVCOMIS ' TO COMANDO. */
            _.Move("SELECT V0MOVCOMIS ", LOCALIZA_ABEND_2.COMANDO);

            /*" -2535- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2537- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -2545- PERFORM M_0041_LOCALIZA_6039_DB_SELECT_1 */

            M_0041_LOCALIZA_6039_DB_SELECT_1();

            /*" -2548- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2549- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -2550- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2551- ADD SFT TO STT(10) */
            TOTAIS_ROT.FILLER_29[10].STT.Value = TOTAIS_ROT.FILLER_29[10].STT + WS_HORAS.SFT;

            /*" -2554- ADD 1 TO SQT(10) */
            TOTAIS_ROT.FILLER_29[10].SQT.Value = TOTAIS_ROT.FILLER_29[10].SQT + 1;

            /*" -2555- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2556- DISPLAY 'ERRO SELECT V0MOVCOMIS SQLCODE = ' SQLCODE */
                _.Display($"ERRO SELECT V0MOVCOMIS SQLCODE = {DB.SQLCODE}");

                /*" -2557- DISPLAY 'NSL = ' MVCOM-NSL */
                _.Display($"NSL = {MVCOM_NSL}");

                /*" -2559- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -2560- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2562- GO TO 0041-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0041_FIM*/ //GOTO
                return;
            }


            /*" -2564- MOVE 1 TO WS-ACHEI. */
            _.Move(1, WORK_AREA.WS_ACHEI);

            /*" -2565- IF RF-COD-RETORNO EQUAL 00 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00)
            {

                /*" -2566- PERFORM 1141-QUITA-COMISSAO THRU 1141-FIM */

                M_1141_QUITA_COMISSAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1141_FIM*/


                /*" -2567- ELSE */
            }
            else
            {


                /*" -2567- PERFORM 1241-REJEITA-COMISSAO THRU 1241-FIM. */

                M_1241_REJEITA_COMISSAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1241_FIM*/

            }


        }

        [StopWatch]
        /*" M-0041-LOCALIZA-6039-DB-SELECT-1 */
        public void M_0041_LOCALIZA_6039_DB_SELECT_1()
        {
            /*" -2545- EXEC SQL SELECT NSAS, DATA_MOVIMENTO INTO :MVCOM-NSAS, :MVCOM-DATA-MOV FROM SEGUROS.V0MOVCOMIS WHERE NSL = :MVCOM-NSL WITH UR END-EXEC. */

            var m_0041_LOCALIZA_6039_DB_SELECT_1_Query1 = new M_0041_LOCALIZA_6039_DB_SELECT_1_Query1()
            {
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            var executed_1 = M_0041_LOCALIZA_6039_DB_SELECT_1_Query1.Execute(m_0041_LOCALIZA_6039_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MVCOM_NSAS, MVCOM_NSAS);
                _.Move(executed_1.MVCOM_DATA_MOV, MVCOM_DATA_MOV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0041_FIM*/

        [StopWatch]
        /*" M-0042-00-INSERT-VGHISTCONT */
        private void M_0042_00_INSERT_VGHISTCONT(bool isPerform = false)
        {
            /*" -2575- MOVE '0042-00-INSERT-VGHISTCONT    ' TO PARAGRAFO. */
            _.Move("0042-00-INSERT-VGHISTCONT    ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2577- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2579- ADD 1 TO WS-IND1. */
            WORK_RAMO_CONJ.WS_IND1.Value = WORK_RAMO_CONJ.WS_IND1 + 1;

            /*" -2581- IF WS-IND1 GREATER 30 OR TB-GRUPO-SUSEP (WS-IND1) EQUAL ZEROS */

            if (WORK_RAMO_CONJ.WS_IND1 > 30 || WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP == 00)
            {

                /*" -2582- MOVE 'SIM' TO WFIM-TAB-RAMO */
                _.Move("SIM", WFIM_TAB_RAMO);

                /*" -2583- ELSE */
            }
            else
            {


                /*" -2584- INITIALIZE DCLVG-HIST-CONT-COBER */
                _.Initialize(
                    VG082.DCLVG_HIST_CONT_COBER
                );

                /*" -2585- MOVE TB-GRUPO-SUSEP (WS-IND1) TO WHOST-GRUPO-SUSEP */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP, WHOST_GRUPO_SUSEP);

                /*" -2586- MOVE TB-RAMO-CONJ (WS-IND1) TO WHOST-COD-RAMO */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ, WHOST_COD_RAMO);

                /*" -2587- MOVE TB-TAXA-RAMO-CONJ (WS-IND1) TO WHOST-TAXA-RAMO */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_TAXA_RAMO_CONJ, WHOST_TAXA_RAMO);

                /*" -2591- COMPUTE WHOST-PREMIO-CONJ ROUNDED = WS-PREMIO-TOTAL * WHOST-TAXA-RAMO / WHOST-VLR-PERC-PREMIO-TOT */
                WHOST_PREMIO_CONJ.Value = WS_PREMIO_TOTAL * WHOST_TAXA_RAMO / WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT;

                /*" -2592- IF WS-IND1 EQUAL WS-IND */

                if (WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND)
                {

                    /*" -2594- COMPUTE WHOST-PREMIO-CONJ = WS-PREMIO-TOTAL - WS-PREMIO-TOTAL-AC */
                    WHOST_PREMIO_CONJ.Value = WS_PREMIO_TOTAL - WS_PREMIO_TOTAL_AC;

                    /*" -2595- ELSE */
                }
                else
                {


                    /*" -2596- ADD WHOST-PREMIO-CONJ TO WS-PREMIO-TOTAL-AC */
                    WS_PREMIO_TOTAL_AC.Value = WS_PREMIO_TOTAL_AC + WHOST_PREMIO_CONJ;

                    /*" -2598- END-IF */
                }


                /*" -2623- PERFORM M_0042_00_INSERT_VGHISTCONT_DB_INSERT_1 */

                M_0042_00_INSERT_VGHISTCONT_DB_INSERT_1();

                /*" -2627- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
                {

                    /*" -2628- DISPLAY 'PROBLEMAS NO INSERT VGHISTCONT     ' */
                    _.Display($"PROBLEMAS NO INSERT VGHISTCONT     ");

                    /*" -2629- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0042-00-INSERT-VGHISTCONT-DB-INSERT-1 */
        public void M_0042_00_INSERT_VGHISTCONT_DB_INSERT_1()
        {
            /*" -2623- EXEC SQL INSERT INTO SEGUROS.VG_HIST_CONT_COBER (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO ) VALUES (:HCTA-NRCERTIF, :HCTA-NRPARCEL, :HCVA-NRTIT, :HCVA-OCORHIST, :WHOST-GRUPO-SUSEP , :WHOST-COD-RAMO , :VG082-COD-MODALIDADE, :VG082-COD-COBERTURA, :WHOST-PREMIO-CONJ, 'VA0812B' , CURRENT TIMESTAMP ) END-EXEC */

            var m_0042_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 = new M_0042_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1()
            {
                HCTA_NRCERTIF = HCTA_NRCERTIF.ToString(),
                HCTA_NRPARCEL = HCTA_NRPARCEL.ToString(),
                HCVA_NRTIT = HCVA_NRTIT.ToString(),
                HCVA_OCORHIST = HCVA_OCORHIST.ToString(),
                WHOST_GRUPO_SUSEP = WHOST_GRUPO_SUSEP.ToString(),
                WHOST_COD_RAMO = WHOST_COD_RAMO.ToString(),
                VG082_COD_MODALIDADE = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_MODALIDADE.ToString(),
                VG082_COD_COBERTURA = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_COBERTURA.ToString(),
                WHOST_PREMIO_CONJ = WHOST_PREMIO_CONJ.ToString(),
            };

            M_0042_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1.Execute(m_0042_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0042_FIM*/

        [StopWatch]
        /*" M-0050-GERA-FITACEF */
        private void M_0050_GERA_FITACEF(bool isPerform = false)
        {
            /*" -2638- MOVE '0050-GERA-FITACEF' TO PARAGRAFO. */
            _.Move("0050-GERA-FITACEF", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2640- MOVE 'SELECT ... FROM SEGUROS.V0FITACEF' TO COMANDO. */
            _.Move("SELECT ... FROM SEGUROS.V0FITACEF", LOCALIZA_ABEND_2.COMANDO);

            /*" -2643- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2644- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2646- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -2652- PERFORM M_0050_GERA_FITACEF_DB_SELECT_1 */

            M_0050_GERA_FITACEF_DB_SELECT_1();

            /*" -2655- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2656- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -2657- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2658- ADD SFT TO STT(11) */
            TOTAIS_ROT.FILLER_29[11].STT.Value = TOTAIS_ROT.FILLER_29[11].STT + WS_HORAS.SFT;

            /*" -2661- ADD 1 TO SQT(11) */
            TOTAIS_ROT.FILLER_29[11].SQT.Value = TOTAIS_ROT.FILLER_29[11].SQT + 1;

            /*" -2662- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2664- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -2665- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -2666- PERFORM 0053-UPDATE-FITACEF THRU 0053-FIM */

                M_0053_UPDATE_FITACEF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0053_FIM*/


                /*" -2667- ELSE */
            }
            else
            {


                /*" -2667- PERFORM 0055-INSERT-FITACEF THRU 0055-FIM. */

                M_0055_INSERT_FITACEF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0055_FIM*/

            }


        }

        [StopWatch]
        /*" M-0050-GERA-FITACEF-DB-SELECT-1 */
        public void M_0050_GERA_FITACEF_DB_SELECT_1()
        {
            /*" -2652- EXEC SQL SELECT DATA_GERACAO INTO :FITCEF-DTRET FROM SEGUROS.V0FITACEF WHERE NSAC = :SQL-NSAC WITH UR END-EXEC. */

            var m_0050_GERA_FITACEF_DB_SELECT_1_Query1 = new M_0050_GERA_FITACEF_DB_SELECT_1_Query1()
            {
                SQL_NSAC = SQL_NSAC.ToString(),
            };

            var executed_1 = M_0050_GERA_FITACEF_DB_SELECT_1_Query1.Execute(m_0050_GERA_FITACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FITCEF_DTRET, FITCEF_DTRET);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0050_FIM*/

        [StopWatch]
        /*" M-0053-UPDATE-FITACEF */
        private void M_0053_UPDATE_FITACEF(bool isPerform = false)
        {
            /*" -2677- MOVE '0053-UPDATE-FITACEF' TO PARAGRAFO. */
            _.Move("0053-UPDATE-FITACEF", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2679- MOVE 'UPDATE ... SEGUROS.V0FITACEF' TO COMANDO. */
            _.Move("UPDATE ... SEGUROS.V0FITACEF", LOCALIZA_ABEND_2.COMANDO);

            /*" -2681- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2682- MOVE WS-REGISTROS TO FITCEF-QTLANCCR. */
            _.Move(WS_REGISTROS, FITCEF_QTLANCCR);

            /*" -2683- MOVE WS-QTCREFET TO FITCEF-QTCREFET. */
            _.Move(WS_QTCREFET, FITCEF_QTCREFET);

            /*" -2684- MOVE WS-ACG-TOTCREFET TO FITCEF-TOTCREFET. */
            _.Move(WS_ACG_TOTCREFET, FITCEF_TOTCREFET);

            /*" -2687- MOVE WS-ACG-TOTCRNEFET TO FITCEF-TOTCRNEFET. */
            _.Move(WS_ACG_TOTCRNEFET, FITCEF_TOTCRNEFET);

            /*" -2688- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2690- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -2697- PERFORM M_0053_UPDATE_FITACEF_DB_UPDATE_1 */

            M_0053_UPDATE_FITACEF_DB_UPDATE_1();

            /*" -2700- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2703- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -2704- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2705- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -2706- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2707- ADD SFT TO STT(12) */
            TOTAIS_ROT.FILLER_29[12].STT.Value = TOTAIS_ROT.FILLER_29[12].STT + WS_HORAS.SFT;

            /*" -2707- ADD 1 TO SQT(12). */
            TOTAIS_ROT.FILLER_29[12].SQT.Value = TOTAIS_ROT.FILLER_29[12].SQT + 1;

        }

        [StopWatch]
        /*" M-0053-UPDATE-FITACEF-DB-UPDATE-1 */
        public void M_0053_UPDATE_FITACEF_DB_UPDATE_1()
        {
            /*" -2697- EXEC SQL UPDATE SEGUROS.V0FITACEF SET QTDE_LANC_CRED_RET = :FITCEF-QTLANCCR, TOT_CRED_EFET = :FITCEF-TOTCREFET, TOT_CRED_NAO_EFET = :FITCEF-TOTCRNEFET, QTDE_CRED_EFET = :FITCEF-QTCREFET WHERE NSAC = :SQL-NSAC END-EXEC. */

            var m_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1 = new M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1()
            {
                FITCEF_TOTCRNEFET = FITCEF_TOTCRNEFET.ToString(),
                FITCEF_TOTCREFET = FITCEF_TOTCREFET.ToString(),
                FITCEF_QTLANCCR = FITCEF_QTLANCCR.ToString(),
                FITCEF_QTCREFET = FITCEF_QTCREFET.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
            };

            M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1.Execute(m_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0053_FIM*/

        [StopWatch]
        /*" M-0055-INSERT-FITACEF */
        private void M_0055_INSERT_FITACEF(bool isPerform = false)
        {
            /*" -2717- MOVE '0055-INSERT-FITACEF' TO PARAGRAFO. */
            _.Move("0055-INSERT-FITACEF", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2719- MOVE 'INSERT ... SEGUROS.V0FITACEF' TO COMANDO. */
            _.Move("INSERT ... SEGUROS.V0FITACEF", LOCALIZA_ABEND_2.COMANDO);

            /*" -2721- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2722- MOVE RZ-QTDE-REGISTROS TO FITCEF-QTREG. */
            _.Move(RET_TRAILLER.RZ_QTDE_REGISTROS, FITCEF_QTREG);

            /*" -2723- MOVE WS-REGISTROS TO FITCEF-QTLANCCR. */
            _.Move(WS_REGISTROS, FITCEF_QTLANCCR);

            /*" -2724- MOVE WS-QTCREFET TO FITCEF-QTCREFET. */
            _.Move(WS_QTCREFET, FITCEF_QTCREFET);

            /*" -2725- MOVE WS-ACG-TOTCREFET TO FITCEF-TOTCREFET. */
            _.Move(WS_ACG_TOTCREFET, FITCEF_TOTCREFET);

            /*" -2728- MOVE WS-ACG-TOTCRNEFET TO FITCEF-TOTCRNEFET. */
            _.Move(WS_ACG_TOTCRNEFET, FITCEF_TOTCRNEFET);

            /*" -2729- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2731- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -2745- PERFORM M_0055_INSERT_FITACEF_DB_INSERT_1 */

            M_0055_INSERT_FITACEF_DB_INSERT_1();

            /*" -2748- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2749- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -2750- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2751- ADD SFT TO STT(13) */
            TOTAIS_ROT.FILLER_29[13].STT.Value = TOTAIS_ROT.FILLER_29[13].STT + WS_HORAS.SFT;

            /*" -2754- ADD 1 TO SQT(13). */
            TOTAIS_ROT.FILLER_29[13].SQT.Value = TOTAIS_ROT.FILLER_29[13].SQT + 1;

            /*" -2755- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2755- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0055-INSERT-FITACEF-DB-INSERT-1 */
        public void M_0055_INSERT_FITACEF_DB_INSERT_1()
        {
            /*" -2745- EXEC SQL INSERT INTO SEGUROS.V0FITACEF VALUES (:SQL-NSAC, :FITCEF-DTRET, :FITCEF-VERSAO, :FITCEF-QTREG, 0, 0, 0, :FITCEF-QTLANCCR, :FITCEF-TOTCREFET, :FITCEF-TOTCRNEFET, 0, :FITCEF-QTCREFET) END-EXEC. */

            var m_0055_INSERT_FITACEF_DB_INSERT_1_Insert1 = new M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1()
            {
                SQL_NSAC = SQL_NSAC.ToString(),
                FITCEF_DTRET = FITCEF_DTRET.ToString(),
                FITCEF_VERSAO = FITCEF_VERSAO.ToString(),
                FITCEF_QTREG = FITCEF_QTREG.ToString(),
                FITCEF_QTLANCCR = FITCEF_QTLANCCR.ToString(),
                FITCEF_TOTCREFET = FITCEF_TOTCREFET.ToString(),
                FITCEF_TOTCRNEFET = FITCEF_TOTCRNEFET.ToString(),
                FITCEF_QTCREFET = FITCEF_QTCREFET.ToString(),
            };

            M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1.Execute(m_0055_INSERT_FITACEF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0055_FIM*/

        [StopWatch]
        /*" M-0060-LOCALIZA-6075 */
        private void M_0060_LOCALIZA_6075(bool isPerform = false)
        {
            /*" -2768- MOVE '0060-LOCALIZA-6075  ' TO PARAGRAFO. */
            _.Move("0060-LOCALIZA-6075  ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2770- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2771- MOVE RF-COD-RETORNO TO MVCOM-COD-RETORNO. */
            _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, MVCOM_COD_RETORNO);

            /*" -2772- MOVE RF-COD-OPERACAO TO WCOD-OPER-CONTA */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPERACAO, WORK_AREA.WNUM_CTA_CORRENTE.WCOD_OPER_CONTA);

            /*" -2773- MOVE RF-NUM-CONTA TO WNUM-CONTA */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_CONTA, WORK_AREA.WNUM_CTA_CORRENTE.WNUM_CONTA);

            /*" -2774- MOVE WNUM-CTA-CORR-R TO HOST-NUM-CONTA */
            _.Move(WORK_AREA.WNUM_CTA_CORR_R, HOST_NUM_CONTA);

            /*" -2775- MOVE RF-DIG-CONTA TO HOST-DV-CONTA */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_DIG_CONTA, HOST_DV_CONTA);

            /*" -2795- MOVE RF-AGENCIA TO HOST-AGENCIA */
            _.Move(RET_CADASTRAMENTO.RF_AGENCIA, HOST_AGENCIA);

            /*" -2797- MOVE RF-NRCERTIF TO V0RESG-NRCERTIF. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NRCERTIF, V0RESG_NRCERTIF);

            /*" -2799- MOVE 'SELECT V0RESGATE_CAP_VG ...      ' TO COMANDO. */
            _.Move("SELECT V0RESGATE_CAP_VG ...      ", LOCALIZA_ABEND_2.COMANDO);

            /*" -2812- PERFORM M_0060_LOCALIZA_6075_DB_SELECT_1 */

            M_0060_LOCALIZA_6075_DB_SELECT_1();

            /*" -2815- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2817- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -2818- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2819- DISPLAY 'VA0812B - PROBLEMAS NO SELECT V0RESGATE_CAP_VG' */
                _.Display($"VA0812B - PROBLEMAS NO SELECT V0RESGATE_CAP_VG");

                /*" -2820- DISPLAY 'NRCERTIF- ' V0RESG-NRCERTIF */
                _.Display($"NRCERTIF- {V0RESG_NRCERTIF}");

                /*" -2821- DISPLAY 'AGENCIA - ' HOST-AGENCIA */
                _.Display($"AGENCIA - {HOST_AGENCIA}");

                /*" -2822- DISPLAY 'CTA CORR- ' HOST-NUM-CONTA */
                _.Display($"CTA CORR- {HOST_NUM_CONTA}");

                /*" -2823- DISPLAY 'DV CONTA- ' HOST-DV-CONTA */
                _.Display($"DV CONTA- {HOST_DV_CONTA}");

                /*" -2825- GO TO 0060-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0060_FIM*/ //GOTO
                return;
            }


            /*" -2826- IF VIND-DTCREDITO LESS ZEROS */

            if (VIND_DTCREDITO < 00)
            {

                /*" -2828- MOVE ZEROS TO V0RESG-DTCREDITO. */
                _.Move(0, V0RESG_DTCREDITO);
            }


            /*" -2829- IF VIND-NSAC LESS ZEROS */

            if (VIND_NSAC < 00)
            {

                /*" -2831- MOVE ZEROS TO V0RESG-NSAC. */
                _.Move(0, V0RESG_NSAC);
            }


            /*" -2832- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -2833- MOVE 1 TO WS-ACHEI */
                _.Move(1, WORK_AREA.WS_ACHEI);

                /*" -2834- IF RF-COD-RETORNO EQUAL 00 */

                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00)
                {

                    /*" -2835- PERFORM 0061-QUITA-RESGATE THRU 0061-FIM */

                    M_0061_QUITA_RESGATE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0061_FIM*/


                    /*" -2837- ELSE */
                }
                else
                {


                    /*" -2840- PERFORM 0062-REJEITA-RESGATE THRU 0062-FIM. */

                    M_0062_REJEITA_RESGATE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0062_FIM*/

                }

            }


            /*" -2841- IF RF-NSAS NOT NUMERIC */

            if (!RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NSAS.IsNumeric())
            {

                /*" -2842- COMPUTE MVCOM-NSAS = MVCOM-NSAS + 18000 */
                MVCOM_NSAS.Value = MVCOM_NSAS + 18000;

                /*" -2843- ELSE */
            }
            else
            {


                /*" -2843- MOVE RF-NSAS TO MVCOM-NSAS. */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NSAS, MVCOM_NSAS);
            }


        }

        [StopWatch]
        /*" M-0060-LOCALIZA-6075-DB-SELECT-1 */
        public void M_0060_LOCALIZA_6075_DB_SELECT_1()
        {
            /*" -2812- EXEC SQL SELECT SITUACAO, DTCREDITO, NSAC INTO :V0RESG-SITUACAO, :V0RESG-DTCREDITO:VIND-DTCREDITO, :V0RESG-NSAC:VIND-NSAC FROM SEGUROS.V0RESGATE_CAP_VG WHERE NRCERTIF = :V0RESG-NRCERTIF AND NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL AND SITUACAO = '3' WITH UR END-EXEC. */

            var m_0060_LOCALIZA_6075_DB_SELECT_1_Query1 = new M_0060_LOCALIZA_6075_DB_SELECT_1_Query1()
            {
                V0RESG_NRCERTIF = V0RESG_NRCERTIF.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            var executed_1 = M_0060_LOCALIZA_6075_DB_SELECT_1_Query1.Execute(m_0060_LOCALIZA_6075_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RESG_SITUACAO, V0RESG_SITUACAO);
                _.Move(executed_1.V0RESG_DTCREDITO, V0RESG_DTCREDITO);
                _.Move(executed_1.VIND_DTCREDITO, VIND_DTCREDITO);
                _.Move(executed_1.V0RESG_NSAC, V0RESG_NSAC);
                _.Move(executed_1.VIND_NSAC, VIND_NSAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0060_FIM*/

        [StopWatch]
        /*" M-0061-QUITA-RESGATE */
        private void M_0061_QUITA_RESGATE(bool isPerform = false)
        {
            /*" -2856- MOVE '0061-QUITA-RESGATE' TO PARAGRAFO. */
            _.Move("0061-QUITA-RESGATE", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2858- MOVE 'UPDATE V0RESGATE_CAP_VG ...      ' TO COMANDO. */
            _.Move("UPDATE V0RESGATE_CAP_VG ...      ", LOCALIZA_ABEND_2.COMANDO);

            /*" -2860- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2861- MOVE RF-AA-REAL TO ANO-SQL. */
            _.Move(RET_CADASTRAMENTO.RF_DATA_REAL.RF_AA_REAL, DATA_SQL.ANO_SQL);

            /*" -2862- MOVE RF-MM-REAL TO MES-SQL. */
            _.Move(RET_CADASTRAMENTO.RF_DATA_REAL.RF_MM_REAL, DATA_SQL.MES_SQL);

            /*" -2863- MOVE RF-DD-REAL TO DIA-SQL. */
            _.Move(RET_CADASTRAMENTO.RF_DATA_REAL.RF_DD_REAL, DATA_SQL.DIA_SQL);

            /*" -2865- MOVE DATA-SQL TO V0RESG-DTCREDITO. */
            _.Move(DATA_SQL, V0RESG_DTCREDITO);

            /*" -2874- PERFORM M_0061_QUITA_RESGATE_DB_UPDATE_1 */

            M_0061_QUITA_RESGATE_DB_UPDATE_1();

            /*" -2877- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2878- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2879- MOVE 0 TO WS-ACHEI */
                    _.Move(0, WORK_AREA.WS_ACHEI);

                    /*" -2880- DISPLAY 'VA0812B - PROBLEMAS QUITACAO V0RESGATE_CAP_VG' */
                    _.Display($"VA0812B - PROBLEMAS QUITACAO V0RESGATE_CAP_VG");

                    /*" -2881- DISPLAY 'NRCERTIF- ' V0RESG-NRCERTIF */
                    _.Display($"NRCERTIF- {V0RESG_NRCERTIF}");

                    /*" -2882- ELSE */
                }
                else
                {


                    /*" -2882- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0061-QUITA-RESGATE-DB-UPDATE-1 */
        public void M_0061_QUITA_RESGATE_DB_UPDATE_1()
        {
            /*" -2874- EXEC SQL UPDATE SEGUROS.V0RESGATE_CAP_VG SET SITUACAO = '1' , DTCREDITO = :V0RESG-DTCREDITO, NSAC = :SQL-NSAC, TIMESTAMP = CURRENT TIMESTAMP, CODRET = :MVCOM-COD-RETORNO WHERE NRCERTIF = :V0RESG-NRCERTIF AND NSAS = :MVCOM-NSAS END-EXEC. */

            var m_0061_QUITA_RESGATE_DB_UPDATE_1_Update1 = new M_0061_QUITA_RESGATE_DB_UPDATE_1_Update1()
            {
                MVCOM_COD_RETORNO = MVCOM_COD_RETORNO.ToString(),
                V0RESG_DTCREDITO = V0RESG_DTCREDITO.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
                V0RESG_NRCERTIF = V0RESG_NRCERTIF.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
            };

            M_0061_QUITA_RESGATE_DB_UPDATE_1_Update1.Execute(m_0061_QUITA_RESGATE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0061_FIM*/

        [StopWatch]
        /*" M-0062-REJEITA-RESGATE */
        private void M_0062_REJEITA_RESGATE(bool isPerform = false)
        {
            /*" -2897- MOVE '0062-REJEITA-RESGATE' TO PARAGRAFO. */
            _.Move("0062-REJEITA-RESGATE", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2899- MOVE 'UPDATE V0RESGATE_CAP_VG ...      ' TO COMANDO. */
            _.Move("UPDATE V0RESGATE_CAP_VG ...      ", LOCALIZA_ABEND_2.COMANDO);

            /*" -2901- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2909- PERFORM M_0062_REJEITA_RESGATE_DB_UPDATE_1 */

            M_0062_REJEITA_RESGATE_DB_UPDATE_1();

            /*" -2912- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2913- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2914- MOVE 0 TO WS-ACHEI */
                    _.Move(0, WORK_AREA.WS_ACHEI);

                    /*" -2915- DISPLAY 'VA0812B - PROBLEMAS REJEICAO V0RESGATE_CAP_VG' */
                    _.Display($"VA0812B - PROBLEMAS REJEICAO V0RESGATE_CAP_VG");

                    /*" -2916- DISPLAY 'NRCERTIF- ' V0RESG-NRCERTIF */
                    _.Display($"NRCERTIF- {V0RESG_NRCERTIF}");

                    /*" -2917- ELSE */
                }
                else
                {


                    /*" -2917- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0062-REJEITA-RESGATE-DB-UPDATE-1 */
        public void M_0062_REJEITA_RESGATE_DB_UPDATE_1()
        {
            /*" -2909- EXEC SQL UPDATE SEGUROS.V0RESGATE_CAP_VG SET SITUACAO = ' ' , NSAC = :SQL-NSAC, TIMESTAMP = CURRENT TIMESTAMP, CODRET = :MVCOM-COD-RETORNO WHERE NRCERTIF = :V0RESG-NRCERTIF AND NSAS = :MVCOM-NSAS END-EXEC. */

            var m_0062_REJEITA_RESGATE_DB_UPDATE_1_Update1 = new M_0062_REJEITA_RESGATE_DB_UPDATE_1_Update1()
            {
                MVCOM_COD_RETORNO = MVCOM_COD_RETORNO.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
                V0RESG_NRCERTIF = V0RESG_NRCERTIF.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
            };

            M_0062_REJEITA_RESGATE_DB_UPDATE_1_Update1.Execute(m_0062_REJEITA_RESGATE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0062_FIM*/

        [StopWatch]
        /*" M-0075-SOLICITA-RELAT */
        private void M_0075_SOLICITA_RELAT(bool isPerform = false)
        {
            /*" -2926- MOVE '0075-SOLICITA-RELAT' TO PARAGRAFO. */
            _.Move("0075-SOLICITA-RELAT", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2928- MOVE 'INSERT VA0835B  SEGUROS.V0RELATORIO' TO COMANDO. */
            _.Move("INSERT VA0835B  SEGUROS.V0RELATORIO", LOCALIZA_ABEND_2.COMANDO);

            /*" -2931- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2932- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2934- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -2977- PERFORM M_0075_SOLICITA_RELAT_DB_INSERT_1 */

            M_0075_SOLICITA_RELAT_DB_INSERT_1();

            /*" -2980- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2981- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -2982- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2983- ADD SFT TO STT(14) */
            TOTAIS_ROT.FILLER_29[14].STT.Value = TOTAIS_ROT.FILLER_29[14].STT + WS_HORAS.SFT;

            /*" -2986- ADD 1 TO SQT(14) */
            TOTAIS_ROT.FILLER_29[14].SQT.Value = TOTAIS_ROT.FILLER_29[14].SQT + 1;

            /*" -2987- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2988- DISPLAY 'VA0812B - PROBLEMAS NA INCLUSAO VA0835B' */
                _.Display($"VA0812B - PROBLEMAS NA INCLUSAO VA0835B");

                /*" -2988- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0075-SOLICITA-RELAT-DB-INSERT-1 */
        public void M_0075_SOLICITA_RELAT_DB_INSERT_1()
        {
            /*" -2977- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0812B' , :DTMOVABE, 'VA' , 'VA0835B' , :SQL-NSAC, 0, :DTMOVABE, :DTMOVABE, :DTMOVABE, 0, 0, 0, 0, 0, 0, 0, 0, 97010000889, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var m_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1 = new M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1()
            {
                DTMOVABE = DTMOVABE.ToString(),
                SQL_NSAC = SQL_NSAC.ToString(),
            };

            M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1.Execute(m_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0075_FIM*/

        [StopWatch]
        /*" M-0090-MONTA-AVISO */
        private void M_0090_MONTA_AVISO(bool isPerform = false)
        {
            /*" -2996- MOVE '0090-MONTA-AVISO   ' TO PARAGRAFO. */
            _.Move("0090-MONTA-AVISO   ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2999- MOVE 'MONTA AVISO       ' TO COMANDO. */
            _.Move("MONTA AVISO       ", LOCALIZA_ABEND_2.COMANDO);

            /*" -3001- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3002- IF AUX-CONVENIO EQUAL 6131 */

            if (AUX_CONVENIO == 6131)
            {

                /*" -3003- MOVE 7383 TO V0AVIS-AGEAVISO */
                _.Move(7383, V0AVIS_AGEAVISO);

                /*" -3004- MOVE 2 TO V0AVIS-ORIGAVISO */
                _.Move(2, V0AVIS_ORIGAVISO);

                /*" -3005- ELSE */
            }
            else
            {


                /*" -3006- IF AUX-CONVENIO EQUAL 6090 */

                if (AUX_CONVENIO == 6090)
                {

                    /*" -3008- MOVE 7004 TO V0AVIS-AGEAVISO */
                    _.Move(7004, V0AVIS_AGEAVISO);

                    /*" -3009- MOVE 22 TO V0AVIS-ORIGAVISO */
                    _.Move(22, V0AVIS_ORIGAVISO);

                    /*" -3010- ELSE */
                }
                else
                {


                    /*" -3013- MOVE ZEROS TO V0AVIS-BCOAVISO V0AVIS-AGEAVISO V0AVIS-NRAVISO */
                    _.Move(0, V0AVIS_BCOAVISO, V0AVIS_AGEAVISO, V0AVIS_NRAVISO);

                    /*" -3016- GO TO 0090-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0090_FIM*/ //GOTO
                    return;
                }

            }


            /*" -3017- MOVE 104 TO V0AVIS-BCOAVISO */
            _.Move(104, V0AVIS_BCOAVISO);

            /*" -3018- MOVE AUX-CONVENIO TO WS-AGEAVISO */
            _.Move(AUX_CONVENIO, FILLER_13.WS_AGEAVISO);

            /*" -3020- MOVE AUX-NSAC TO WS-NSAC. */
            _.Move(AUX_NSAC, FILLER_13.WS_NSAC);

            /*" -3023- COMPUTE WS-NRAVISO EQUAL WS-NRAVISO + 80000. */
            WS_NRAVISO.Value = WS_NRAVISO + 80000;

            /*" -3024- MOVE WS-NRAVISO TO V0AVIS-NRAVISO */
            _.Move(WS_NRAVISO, V0AVIS_NRAVISO);

            /*" -3025- MOVE 1 TO V0AVIS-NRSEQ */
            _.Move(1, V0AVIS_NRSEQ);

            /*" -3026- MOVE DTMOVABE TO V0AVIS-DTMOVTO */
            _.Move(DTMOVABE, V0AVIS_DTMOVTO);

            /*" -3027- MOVE 100 TO V0AVIS-OPERACAO */
            _.Move(100, V0AVIS_OPERACAO);

            /*" -3028- MOVE 'D' TO V0AVIS-TIPAVI */
            _.Move("D", V0AVIS_TIPAVI);

            /*" -3029- MOVE FITCEF-DTRET TO V0AVIS-DTAVISO */
            _.Move(FITCEF_DTRET, V0AVIS_DTAVISO);

            /*" -3030- MOVE ZEROS TO V0AVIS-VLIOCC */
            _.Move(0, V0AVIS_VLIOCC);

            /*" -3031- MOVE ZEROS TO V0AVIS-VLDESPES */
            _.Move(0, V0AVIS_VLDESPES);

            /*" -3032- MOVE ZEROS TO V0AVIS-PRECED */
            _.Move(0, V0AVIS_PRECED);

            /*" -3033- MOVE '0' TO V0AVIS-SITCONTB */
            _.Move("0", V0AVIS_SITCONTB);

            /*" -3034- MOVE ZEROS TO V0AVIS-CODEMP */
            _.Move(0, V0AVIS_CODEMP);

            /*" -3036- MOVE ZEROS TO V0AVIS-VALADT. */
            _.Move(0, V0AVIS_VALADT);

            /*" -3037- MOVE ZEROS TO AUX-VLPRMTOT AUX-VLDESPES. */
            _.Move(0, AUX_VLPRMTOT, AUX_VLDESPES);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0090_FIM*/

        [StopWatch]
        /*" M-0100-INSERT-AVISOS */
        private void M_0100_INSERT_AVISOS(bool isPerform = false)
        {
            /*" -3045- MOVE '0100-INSERT-AVISOS ' TO PARAGRAFO. */
            _.Move("0100-INSERT-AVISOS ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3047- MOVE 'INSERT V0AVISOCRED' TO COMANDO. */
            _.Move("INSERT V0AVISOCRED", LOCALIZA_ABEND_2.COMANDO);

            /*" -3049- DISPLAY PARAGRAFO. */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3050- MOVE AUX-VLPRMTOT TO V0AVIS-VLPRMTOT. */
            _.Move(AUX_VLPRMTOT, V0AVIS_VLPRMTOT);

            /*" -3052- MOVE AUX-VLDESPES TO V0AVIS-VLDESPES. */
            _.Move(AUX_VLDESPES, V0AVIS_VLDESPES);

            /*" -3055- COMPUTE V0AVIS-VLPRMLIQ EQUAL V0AVIS-VLPRMTOT + V0AVIS-VLDESPES. */
            V0AVIS_VLPRMLIQ.Value = V0AVIS_VLPRMTOT + V0AVIS_VLDESPES;

            /*" -3059- MOVE ZEROS TO VIND-CODEMP VIND-ORIGAVISO VIND-VALADT. */
            _.Move(0, VIND_CODEMP, VIND_ORIGAVISO, VIND_VALADT);

            /*" -3061- MOVE 'P' TO V0AVIS-SITDEPTER. */
            _.Move("P", V0AVIS_SITDEPTER);

            /*" -3082- PERFORM M_0100_INSERT_AVISOS_DB_INSERT_1 */

            M_0100_INSERT_AVISOS_DB_INSERT_1();

            /*" -3085- MOVE V0AVIS-CODEMP TO V0SALD-CODEMP */
            _.Move(V0AVIS_CODEMP, V0SALD_CODEMP);

            /*" -3086- MOVE V0AVIS-BCOAVISO TO V0SALD-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0SALD_BCOAVISO);

            /*" -3087- MOVE V0AVIS-AGEAVISO TO V0SALD-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0SALD_AGEAVISO);

            /*" -3088- MOVE '1' TO V0SALD-TIPSGU */
            _.Move("1", V0SALD_TIPSGU);

            /*" -3089- MOVE V0AVIS-NRAVISO TO V0SALD-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0SALD_NRAVISO);

            /*" -3090- MOVE V0AVIS-DTAVISO TO V0SALD-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0SALD_DTAVISO);

            /*" -3091- MOVE V0AVIS-DTMOVTO TO V0SALD-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0SALD_DTMOVTO);

            /*" -3092- MOVE ZEROS TO V0SALD-SDOATU */
            _.Move(0, V0SALD_SDOATU);

            /*" -3094- MOVE '0' TO V0SALD-SITUACAO. */
            _.Move("0", V0SALD_SITUACAO);

            /*" -3106- PERFORM M_0100_INSERT_AVISOS_DB_INSERT_2 */

            M_0100_INSERT_AVISOS_DB_INSERT_2();

            /*" -3110- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -3111- PERFORM R8500-00-GRAVA-DESPESAS THRU R8500-99-SAIDA 2000 TIMES. */

            R8500_00_GRAVA_DESPESAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/


        }

        [StopWatch]
        /*" M-0100-INSERT-AVISOS-DB-INSERT-1 */
        public void M_0100_INSERT_AVISOS_DB_INSERT_1()
        {
            /*" -3082- EXEC SQL INSERT INTO SEGUROS.V0AVISOCRED VALUES (:V0AVIS-BCOAVISO , :V0AVIS-AGEAVISO , :V0AVIS-NRAVISO , :V0AVIS-NRSEQ , :V0AVIS-DTMOVTO , :V0AVIS-OPERACAO , :V0AVIS-TIPAVI , :V0AVIS-DTAVISO , :V0AVIS-VLIOCC , :V0AVIS-VLDESPES , :V0AVIS-PRECED , :V0AVIS-VLPRMLIQ , :V0AVIS-VLPRMTOT , :V0AVIS-SITCONTB , :V0AVIS-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0AVIS-ORIGAVISO:VIND-ORIGAVISO , :V0AVIS-VALADT:VIND-VALADT , :V0AVIS-SITDEPTER) END-EXEC. */

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
            /*" -3106- EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS VALUES (:V0SALD-CODEMP , :V0SALD-BCOAVISO , :V0SALD-AGEAVISO , :V0SALD-TIPSGU , :V0SALD-NRAVISO , :V0SALD-DTAVISO , :V0SALD-DTMOVTO , :V0SALD-SDOATU , :V0SALD-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" M-1132-QUITA-COMISSAO */
        private void M_1132_QUITA_COMISSAO(bool isPerform = false)
        {
            /*" -3123- MOVE '1132-QUITA-COMISSAO' TO PARAGRAFO. */
            _.Move("1132-QUITA-COMISSAO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3125- MOVE 'UPDATE ...      SEGUROS.V0MOVCOMIS' TO COMANDO. */
            _.Move("UPDATE ...      SEGUROS.V0MOVCOMIS", LOCALIZA_ABEND_2.COMANDO);

            /*" -3128- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3129- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3131- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3137- PERFORM M_1132_QUITA_COMISSAO_DB_UPDATE_1 */

            M_1132_QUITA_COMISSAO_DB_UPDATE_1();

            /*" -3140- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3141- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3142- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3143- ADD SFT TO STT(15) */
            TOTAIS_ROT.FILLER_29[15].STT.Value = TOTAIS_ROT.FILLER_29[15].STT + WS_HORAS.SFT;

            /*" -3146- ADD 1 TO SQT(15) */
            TOTAIS_ROT.FILLER_29[15].SQT.Value = TOTAIS_ROT.FILLER_29[15].SQT + 1;

            /*" -3147- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3148- DISPLAY 'VA0812B - PROBLEMAS NA ATUALIZACAO V0MOVCOMIS' */
                _.Display($"VA0812B - PROBLEMAS NA ATUALIZACAO V0MOVCOMIS");

                /*" -3148- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1132-QUITA-COMISSAO-DB-UPDATE-1 */
        public void M_1132_QUITA_COMISSAO_DB_UPDATE_1()
        {
            /*" -3137- EXEC SQL UPDATE SEGUROS.V0MOVCOMIS SET SITUACAO = '2' , DATA_QUITACAO = DATA_SAIDA WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL END-EXEC. */

            var m_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1 = new M_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1.Execute(m_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1132_FIM*/

        [StopWatch]
        /*" M-1232-REJEITA-COMISSAO */
        private void M_1232_REJEITA_COMISSAO(bool isPerform = false)
        {
            /*" -3157- MOVE '1232-REJEITA-COMISSAO' TO PARAGRAFO. */
            _.Move("1232-REJEITA-COMISSAO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3159- MOVE 'SELECT ... V0FUNCIOCEF+V0PRODU' TO COMANDO. */
            _.Move("SELECT ... V0FUNCIOCEF+V0PRODU", LOCALIZA_ABEND_2.COMANDO);

            /*" -3161- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3162- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3164- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3179- PERFORM M_1232_REJEITA_COMISSAO_DB_SELECT_1 */

            M_1232_REJEITA_COMISSAO_DB_SELECT_1();

            /*" -3182- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3183- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3184- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3185- ADD SFT TO STT(16) */
            TOTAIS_ROT.FILLER_29[16].STT.Value = TOTAIS_ROT.FILLER_29[16].STT + WS_HORAS.SFT;

            /*" -3188- ADD 1 TO SQT(16) */
            TOTAIS_ROT.FILLER_29[16].SQT.Value = TOTAIS_ROT.FILLER_29[16].SQT + 1;

            /*" -3189- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3191- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3193- MOVE RF-COD-RETORNO TO MVCOM-COD-RETORNO. */
            _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, MVCOM_COD_RETORNO);

            /*" -3197- IF FUNCEF-AGENCIA NOT EQUAL MVCOM-AGENCIA OR FUNCEF-OPERACAO NOT EQUAL MVCOM-OPERACAO OR FUNCEF-CONTA NOT EQUAL MVCOM-CONTA OR FUNCEF-DIG NOT EQUAL MVCOM-DIG */

            if (FUNCEF_AGENCIA != MVCOM_AGENCIA || FUNCEF_OPERACAO != MVCOM_OPERACAO || FUNCEF_CONTA != MVCOM_CONTA || FUNCEF_DIG != MVCOM_DIG)
            {

                /*" -3198- PERFORM 1332-ATUALIZA-CONTA THRU 1332-FIM */

                M_1332_ATUALIZA_CONTA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1332_FIM*/


                /*" -3199- ELSE */
            }
            else
            {


                /*" -3201- PERFORM 1432-REJEITA-COMISSAO THRU 1432-FIM. */

                M_1432_REJEITA_COMISSAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1432_FIM*/

            }


            /*" -3201- PERFORM 1532-GERA-RETCOMIS THRU 1532-FIM. */

            M_1532_GERA_RETCOMIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1532_FIM*/


        }

        [StopWatch]
        /*" M-1232-REJEITA-COMISSAO-DB-SELECT-1 */
        public void M_1232_REJEITA_COMISSAO_DB_SELECT_1()
        {
            /*" -3179- EXEC SQL SELECT B.COD_AGENCIA, B.OPERACAO_CONTA, B.NUM_CONTA, B.DIG_CONTA INTO :FUNCEF-AGENCIA, :FUNCEF-OPERACAO, :FUNCEF-CONTA, :FUNCEF-DIG FROM SEGUROS.V0PRODUTOR A, SEGUROS.V0FUNCIOCEF B WHERE A.CODPDT = :MVCOM-CODPDT AND B.NUM_MATRICULA = A.CHPFUN AND B.NUM_CPF = A.CGCCPF WITH UR END-EXEC. */

            var m_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1 = new M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1()
            {
                MVCOM_CODPDT = MVCOM_CODPDT.ToString(),
            };

            var executed_1 = M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1.Execute(m_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCEF_AGENCIA, FUNCEF_AGENCIA);
                _.Move(executed_1.FUNCEF_OPERACAO, FUNCEF_OPERACAO);
                _.Move(executed_1.FUNCEF_CONTA, FUNCEF_CONTA);
                _.Move(executed_1.FUNCEF_DIG, FUNCEF_DIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1232_FIM*/

        [StopWatch]
        /*" M-1332-ATUALIZA-CONTA */
        private void M_1332_ATUALIZA_CONTA(bool isPerform = false)
        {
            /*" -3211- MOVE '1332-ATUALIZA-CONTA' TO PARAGRAFO. */
            _.Move("1332-ATUALIZA-CONTA", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3216- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3219- MOVE 'UPDATE ...      SEGUROS.V0MOVCOMIS' TO COMANDO. */
            _.Move("UPDATE ...      SEGUROS.V0MOVCOMIS", LOCALIZA_ABEND_2.COMANDO);

            /*" -3220- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3222- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3232- PERFORM M_1332_ATUALIZA_CONTA_DB_UPDATE_1 */

            M_1332_ATUALIZA_CONTA_DB_UPDATE_1();

            /*" -3235- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3236- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3237- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3238- ADD SFT TO STT(17) */
            TOTAIS_ROT.FILLER_29[17].STT.Value = TOTAIS_ROT.FILLER_29[17].STT + WS_HORAS.SFT;

            /*" -3241- ADD 1 TO SQT(17) */
            TOTAIS_ROT.FILLER_29[17].SQT.Value = TOTAIS_ROT.FILLER_29[17].SQT + 1;

            /*" -3242- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3242- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1332-ATUALIZA-CONTA-DB-UPDATE-1 */
        public void M_1332_ATUALIZA_CONTA_DB_UPDATE_1()
        {
            /*" -3232- EXEC SQL UPDATE SEGUROS.V0MOVCOMIS SET SITUACAO = '0' , COD_AGENCIA = :FUNCEF-AGENCIA, OPERACAO_CONTA = :FUNCEF-OPERACAO, NUM_CONTA = :FUNCEF-CONTA, DIG_CONTA = :FUNCEF-DIG, DATA_SAIDA = NULL WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL END-EXEC. */

            var m_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1 = new M_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1()
            {
                FUNCEF_OPERACAO = FUNCEF_OPERACAO.ToString(),
                FUNCEF_AGENCIA = FUNCEF_AGENCIA.ToString(),
                FUNCEF_CONTA = FUNCEF_CONTA.ToString(),
                FUNCEF_DIG = FUNCEF_DIG.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1.Execute(m_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1332_FIM*/

        [StopWatch]
        /*" M-1432-REJEITA-COMISSAO */
        private void M_1432_REJEITA_COMISSAO(bool isPerform = false)
        {
            /*" -3252- MOVE '1432-REJEITA-COMISSAO' TO PARAGRAFO. */
            _.Move("1432-REJEITA-COMISSAO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3257- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3260- MOVE 'UPDATE ...      SEGUROS.V0MOVCOMIS' TO COMANDO. */
            _.Move("UPDATE ...      SEGUROS.V0MOVCOMIS", LOCALIZA_ABEND_2.COMANDO);

            /*" -3261- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3263- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3269- PERFORM M_1432_REJEITA_COMISSAO_DB_UPDATE_1 */

            M_1432_REJEITA_COMISSAO_DB_UPDATE_1();

            /*" -3272- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3273- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3274- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3275- ADD SFT TO STT(18) */
            TOTAIS_ROT.FILLER_29[18].STT.Value = TOTAIS_ROT.FILLER_29[18].STT + WS_HORAS.SFT;

            /*" -3278- ADD 1 TO SQT(18) */
            TOTAIS_ROT.FILLER_29[18].SQT.Value = TOTAIS_ROT.FILLER_29[18].SQT + 1;

            /*" -3279- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3279- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1432-REJEITA-COMISSAO-DB-UPDATE-1 */
        public void M_1432_REJEITA_COMISSAO_DB_UPDATE_1()
        {
            /*" -3269- EXEC SQL UPDATE SEGUROS.V0MOVCOMIS SET SITUACAO = '0' , DATA_SAIDA = NULL WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL END-EXEC. */

            var m_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1 = new M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1.Execute(m_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1432_FIM*/

        [StopWatch]
        /*" M-1532-GERA-RETCOMIS */
        private void M_1532_GERA_RETCOMIS(bool isPerform = false)
        {
            /*" -3289- MOVE '1532-GERA-RETCOMIS' TO PARAGRAFO. */
            _.Move("1532-GERA-RETCOMIS", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3291- MOVE 'SELECT V0FITASASSE' TO COMANDO. */
            _.Move("SELECT V0FITASASSE", LOCALIZA_ABEND_2.COMANDO);

            /*" -3293- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3300- PERFORM M_1532_GERA_RETCOMIS_DB_SELECT_1 */

            M_1532_GERA_RETCOMIS_DB_SELECT_1();

            /*" -3303- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3308- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3311- MOVE 'INSERT ...      SEGUROS.V0RETORNOCOMIS' TO COMANDO. */
            _.Move("INSERT ...      SEGUROS.V0RETORNOCOMIS", LOCALIZA_ABEND_2.COMANDO);

            /*" -3312- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3314- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3322- PERFORM M_1532_GERA_RETCOMIS_DB_INSERT_1 */

            M_1532_GERA_RETCOMIS_DB_INSERT_1();

            /*" -3325- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3326- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3327- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3328- ADD SFT TO STT(19) */
            TOTAIS_ROT.FILLER_29[19].STT.Value = TOTAIS_ROT.FILLER_29[19].STT + WS_HORAS.SFT;

            /*" -3331- ADD 1 TO SQT(19) */
            TOTAIS_ROT.FILLER_29[19].SQT.Value = TOTAIS_ROT.FILLER_29[19].SQT + 1;

            /*" -3332- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3341- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3342- IF WS-CONVENIO EQUAL 6040 OR 6041 OR 6036 OR 6069 OR 6070 */

            if (WORK_AREA.WS_CONVENIO.In("6040", "6041", "6036", "6069", "6070"))
            {

                /*" -3343- IF WS-CONVENIO EQUAL 6040 */

                if (WORK_AREA.WS_CONVENIO == 6040)
                {

                    /*" -3344- MOVE +302 TO LK-CODOPER */
                    _.Move(+302, LK_CONTABIL.LK_CODOPER);

                    /*" -3345- MOVE '***' TO LK-CODPRODAZ */
                    _.Move("***", LK_CONTABIL.LK_CODPRODAZ);

                    /*" -3346- END-IF */
                }


                /*" -3347- IF WS-CONVENIO EQUAL 6069 */

                if (WORK_AREA.WS_CONVENIO == 6069)
                {

                    /*" -3348- MOVE +302 TO LK-CODOPER */
                    _.Move(+302, LK_CONTABIL.LK_CODOPER);

                    /*" -3349- MOVE 'MCE' TO LK-CODPRODAZ */
                    _.Move("MCE", LK_CONTABIL.LK_CODPRODAZ);

                    /*" -3350- END-IF */
                }


                /*" -3351- IF WS-CONVENIO EQUAL 6041 */

                if (WORK_AREA.WS_CONVENIO == 6041)
                {

                    /*" -3352- MOVE +303 TO LK-CODOPER */
                    _.Move(+303, LK_CONTABIL.LK_CODOPER);

                    /*" -3353- MOVE '***' TO LK-CODPRODAZ */
                    _.Move("***", LK_CONTABIL.LK_CODPRODAZ);

                    /*" -3354- END-IF */
                }


                /*" -3355- IF WS-CONVENIO EQUAL 6070 */

                if (WORK_AREA.WS_CONVENIO == 6070)
                {

                    /*" -3356- MOVE +303 TO LK-CODOPER */
                    _.Move(+303, LK_CONTABIL.LK_CODOPER);

                    /*" -3357- MOVE 'MCE' TO LK-CODPRODAZ */
                    _.Move("MCE", LK_CONTABIL.LK_CODPRODAZ);

                    /*" -3358- END-IF */
                }


                /*" -3359- IF WS-CONVENIO EQUAL 6036 */

                if (WORK_AREA.WS_CONVENIO == 6036)
                {

                    /*" -3360- MOVE 'EMP' TO LK-CODPRODAZ */
                    _.Move("EMP", LK_CONTABIL.LK_CODPRODAZ);

                    /*" -3361- MOVE +304 TO LK-CODOPER */
                    _.Move(+304, LK_CONTABIL.LK_CODOPER);

                    /*" -3362- END-IF */
                }


                /*" -3363- MOVE MVCOM-DATA-MOV TO LK-DTMOVTO */
                _.Move(MVCOM_DATA_MOV, LK_CONTABIL.LK_DTMOVTO);

                /*" -3364- MOVE MVCOM-DATA-MOV TO LK-DTINIVIG */
                _.Move(MVCOM_DATA_MOV, LK_CONTABIL.LK_DTINIVIG);

                /*" -3365- MOVE SPACES TO LK-DTRENOVA */
                _.Move("", LK_CONTABIL.LK_DTRENOVA);

                /*" -3367- COMPUTE LK-VLOPER = RF-VALOR * -1 */
                LK_CONTABIL.LK_VLOPER.Value = RET_CADASTRAMENTO.RF_VALOR * -1;

                /*" -3368- ACCEPT WS-HORA-INI FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

                /*" -3370- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
                WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

                /*" -3372- CALL 'VA0100S' USING LK-CONTABIL */
                _.Call("VA0100S", LK_CONTABIL);

                /*" -3373- ACCEPT WS-HORA-FIM FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

                /*" -3374- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
                WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

                /*" -3375- SUBTRACT SIT FROM SFT */
                WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

                /*" -3376- ADD SFT TO STT(20) */
                TOTAIS_ROT.FILLER_29[20].STT.Value = TOTAIS_ROT.FILLER_29[20].STT + WS_HORAS.SFT;

                /*" -3378- ADD 1 TO SQT(20) */
                TOTAIS_ROT.FILLER_29[20].SQT.Value = TOTAIS_ROT.FILLER_29[20].SQT + 1;

                /*" -3379- IF LK-RETCODE NOT EQUAL +0 */

                if (LK_CONTABIL.LK_RETCODE != +0)
                {

                    /*" -3380- DISPLAY 'ERRO VA0100S ' LK-RETCODE */
                    _.Display($"ERRO VA0100S {LK_CONTABIL.LK_RETCODE}");

                    /*" -3381- DISPLAY LK-MENSAGEM */
                    _.Display(LK_CONTABIL.LK_MENSAGEM);

                    /*" -3381- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-1532-GERA-RETCOMIS-DB-SELECT-1 */
        public void M_1532_GERA_RETCOMIS_DB_SELECT_1()
        {
            /*" -3300- EXEC SQL SELECT DATA_LANCAMENTO INTO :MVCOM-DATA-MOV FROM SEGUROS.V0FITASASSE WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :MVCOM-NSAS WITH UR END-EXEC. */

            var m_1532_GERA_RETCOMIS_DB_SELECT_1_Query1 = new M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1()
            {
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
            };

            var executed_1 = M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1.Execute(m_1532_GERA_RETCOMIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MVCOM_DATA_MOV, MVCOM_DATA_MOV);
            }


        }

        [StopWatch]
        /*" M-1532-GERA-RETCOMIS-DB-INSERT-1 */
        public void M_1532_GERA_RETCOMIS_DB_INSERT_1()
        {
            /*" -3322- EXEC SQL INSERT INTO SEGUROS.V0RETORNOCOMIS VALUES (:SQL-NSAC, :MVCOM-NSAS, :MVCOM-NSL, :MVCOM-COD-RETORNO, :DTMOVABE, :MVCOM-DATA-MOV) END-EXEC. */

            var m_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1 = new M_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1()
            {
                SQL_NSAC = SQL_NSAC.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
                MVCOM_COD_RETORNO = MVCOM_COD_RETORNO.ToString(),
                DTMOVABE = DTMOVABE.ToString(),
                MVCOM_DATA_MOV = MVCOM_DATA_MOV.ToString(),
            };

            M_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1.Execute(m_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1532_FIM*/

        [StopWatch]
        /*" M-1141-QUITA-COMISSAO */
        private void M_1141_QUITA_COMISSAO(bool isPerform = false)
        {
            /*" -3390- MOVE '1141-QUITA-COMISSAO' TO PARAGRAFO. */
            _.Move("1141-QUITA-COMISSAO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3392- MOVE 'UPDATE ...      SEGUROS.V0MOVCOMIS' TO COMANDO. */
            _.Move("UPDATE ...      SEGUROS.V0MOVCOMIS", LOCALIZA_ABEND_2.COMANDO);

            /*" -3395- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3396- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3398- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3404- PERFORM M_1141_QUITA_COMISSAO_DB_UPDATE_1 */

            M_1141_QUITA_COMISSAO_DB_UPDATE_1();

            /*" -3407- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3408- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3409- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3410- ADD SFT TO STT(21) */
            TOTAIS_ROT.FILLER_29[21].STT.Value = TOTAIS_ROT.FILLER_29[21].STT + WS_HORAS.SFT;

            /*" -3413- ADD 1 TO SQT(21) */
            TOTAIS_ROT.FILLER_29[21].SQT.Value = TOTAIS_ROT.FILLER_29[21].SQT + 1;

            /*" -3414- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3415- DISPLAY 'VA0812B - PROBLEMAS NA ATUALIZACAO V0MOVCOMIS' */
                _.Display($"VA0812B - PROBLEMAS NA ATUALIZACAO V0MOVCOMIS");

                /*" -3415- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1141-QUITA-COMISSAO-DB-UPDATE-1 */
        public void M_1141_QUITA_COMISSAO_DB_UPDATE_1()
        {
            /*" -3404- EXEC SQL UPDATE SEGUROS.V0MOVCOMIS SET SITUACAO = '2' , DATA_QUITACAO = DATA_SAIDA WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL END-EXEC. */

            var m_1141_QUITA_COMISSAO_DB_UPDATE_1_Update1 = new M_1141_QUITA_COMISSAO_DB_UPDATE_1_Update1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_1141_QUITA_COMISSAO_DB_UPDATE_1_Update1.Execute(m_1141_QUITA_COMISSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1141_FIM*/

        [StopWatch]
        /*" M-1241-REJEITA-COMISSAO */
        private void M_1241_REJEITA_COMISSAO(bool isPerform = false)
        {
            /*" -3425- MOVE '1241-REJEITA-COMISSAO' TO PARAGRAFO. */
            _.Move("1241-REJEITA-COMISSAO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3427- MOVE 'SELECT ... V0PROPAZUL' TO COMANDO. */
            _.Move("SELECT ... V0PROPAZUL", LOCALIZA_ABEND_2.COMANDO);

            /*" -3429- DISPLAY PARAGRAFO */
            _.Display(LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3430- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3432- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3448- PERFORM M_1241_REJEITA_COMISSAO_DB_SELECT_1 */

            M_1241_REJEITA_COMISSAO_DB_SELECT_1();

            /*" -3451- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3452- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3453- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3454- ADD SFT TO STT(22) */
            TOTAIS_ROT.FILLER_29[22].STT.Value = TOTAIS_ROT.FILLER_29[22].STT + WS_HORAS.SFT;

            /*" -3457- ADD 1 TO SQT(22) */
            TOTAIS_ROT.FILLER_29[22].SQT.Value = TOTAIS_ROT.FILLER_29[22].SQT + 1;

            /*" -3458- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3459- DISPLAY 'PROPOSTA ' PROPAZ-NRPROPAZ */
                _.Display($"PROPOSTA {PROPAZ_NRPROPAZ}");

                /*" -3466- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3467- MOVE MVCOM-DATA-MOV TO LK-DTMOVTO. */
            _.Move(MVCOM_DATA_MOV, LK_CONTABIL.LK_DTMOVTO);

            /*" -3468- COMPUTE LK-VLOPER = RF-VALOR * -1. */
            LK_CONTABIL.LK_VLOPER.Value = RET_CADASTRAMENTO.RF_VALOR * -1;

            /*" -3469- MOVE PROPAZ-DTQITBCO TO LK-DTINIVIG */
            _.Move(PROPAZ_DTQITBCO, LK_CONTABIL.LK_DTINIVIG);

            /*" -3470- MOVE SPACES TO LK-DTRENOVA */
            _.Move("", LK_CONTABIL.LK_DTRENOVA);

            /*" -3471- MOVE PROPAZ-CODPRODAZ TO LK-CODPRODAZ */
            _.Move(PROPAZ_CODPRODAZ, LK_CONTABIL.LK_CODPRODAZ);

            /*" -3473- MOVE +301 TO LK-CODOPER. */
            _.Move(+301, LK_CONTABIL.LK_CODOPER);

            /*" -3474- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3476- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3478- CALL 'VA0100S' USING LK-CONTABIL. */
            _.Call("VA0100S", LK_CONTABIL);

            /*" -3479- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3480- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3481- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3482- ADD SFT TO STT(23) */
            TOTAIS_ROT.FILLER_29[23].STT.Value = TOTAIS_ROT.FILLER_29[23].STT + WS_HORAS.SFT;

            /*" -3484- ADD 1 TO SQT(23) */
            TOTAIS_ROT.FILLER_29[23].SQT.Value = TOTAIS_ROT.FILLER_29[23].SQT + 1;

            /*" -3485- IF LK-RETCODE NOT EQUAL +0 */

            if (LK_CONTABIL.LK_RETCODE != +0)
            {

                /*" -3486- DISPLAY 'ERRO VA0100S ' LK-RETCODE */
                _.Display($"ERRO VA0100S {LK_CONTABIL.LK_RETCODE}");

                /*" -3487- DISPLAY LK-MENSAGEM */
                _.Display(LK_CONTABIL.LK_MENSAGEM);

                /*" -3489- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3491- MOVE RF-COD-RETORNO TO MVCOM-COD-RETORNO. */
            _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, MVCOM_COD_RETORNO);

            /*" -3494- MOVE 'UPDATE ...      SEGUROS.V0MOVCOMIS' TO COMANDO. */
            _.Move("UPDATE ...      SEGUROS.V0MOVCOMIS", LOCALIZA_ABEND_2.COMANDO);

            /*" -3495- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3497- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3503- PERFORM M_1241_REJEITA_COMISSAO_DB_UPDATE_1 */

            M_1241_REJEITA_COMISSAO_DB_UPDATE_1();

            /*" -3506- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3507- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3508- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3509- ADD SFT TO STT(24) */
            TOTAIS_ROT.FILLER_29[24].STT.Value = TOTAIS_ROT.FILLER_29[24].STT + WS_HORAS.SFT;

            /*" -3512- ADD 1 TO SQT(24) */
            TOTAIS_ROT.FILLER_29[24].SQT.Value = TOTAIS_ROT.FILLER_29[24].SQT + 1;

            /*" -3513- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3515- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3518- MOVE 'INSERT ...      SEGUROS.V0RETORNOCOMIS' TO COMANDO. */
            _.Move("INSERT ...      SEGUROS.V0RETORNOCOMIS", LOCALIZA_ABEND_2.COMANDO);

            /*" -3519- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3521- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3529- PERFORM M_1241_REJEITA_COMISSAO_DB_INSERT_1 */

            M_1241_REJEITA_COMISSAO_DB_INSERT_1();

            /*" -3532- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3533- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3534- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3535- ADD SFT TO STT(25) */
            TOTAIS_ROT.FILLER_29[25].STT.Value = TOTAIS_ROT.FILLER_29[25].STT + WS_HORAS.SFT;

            /*" -3538- ADD 1 TO SQT(25) */
            TOTAIS_ROT.FILLER_29[25].SQT.Value = TOTAIS_ROT.FILLER_29[25].SQT + 1;

            /*" -3539- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3548- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3551- MOVE 'SELECT V0HISTCOMPROPAZ' TO COMANDO. */
            _.Move("SELECT V0HISTCOMPROPAZ", LOCALIZA_ABEND_2.COMANDO);

            /*" -3552- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3555- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3572- PERFORM M_1241_REJEITA_COMISSAO_DB_SELECT_2 */

            M_1241_REJEITA_COMISSAO_DB_SELECT_2();

            /*" -3575- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3576- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3577- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3578- ADD SFT TO STT(26) */
            TOTAIS_ROT.FILLER_29[26].STT.Value = TOTAIS_ROT.FILLER_29[26].STT + WS_HORAS.SFT;

            /*" -3581- ADD 1 TO SQT(26) */
            TOTAIS_ROT.FILLER_29[26].SQT.Value = TOTAIS_ROT.FILLER_29[26].SQT + 1;

            /*" -3582- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3583- MOVE PROPAZ-NRPROPAZ TO WS-PROPOSTA-E */
                _.Move(PROPAZ_NRPROPAZ, WORK_AREA.WS_TRABALHO.WS_PROPOSTA_E);

                /*" -3584- MOVE PROPAZ-AGELOTE TO WS-AGLOTE-E */
                _.Move(PROPAZ_AGELOTE, WORK_AREA.WS_TRABALHO.WS_AGLOTE_E);

                /*" -3585- MOVE PROPAZ-DTLOTE TO WS-DTLOTE-E */
                _.Move(PROPAZ_DTLOTE, WORK_AREA.WS_TRABALHO.WS_DTLOTE_E);

                /*" -3586- MOVE PROPAZ-NRLOTE TO WS-NRLOTE-E */
                _.Move(PROPAZ_NRLOTE, WORK_AREA.WS_TRABALHO.WS_NRLOTE_E);

                /*" -3588- MOVE PROPAZ-NRSEQLOTE TO WS-SEQLOTE-E */
                _.Move(PROPAZ_NRSEQLOTE, WORK_AREA.WS_TRABALHO.WS_SEQLOTE_E);

                /*" -3589- DISPLAY 'PROPOSTA' WS-PROPOSTA-E */
                _.Display($"PROPOSTA{WORK_AREA.WS_TRABALHO.WS_PROPOSTA_E}");

                /*" -3590- DISPLAY 'AGENCIA ' WS-AGLOTE-E */
                _.Display($"AGENCIA {WORK_AREA.WS_TRABALHO.WS_AGLOTE_E}");

                /*" -3591- DISPLAY 'DATA    ' WS-DTLOTE-E */
                _.Display($"DATA    {WORK_AREA.WS_TRABALHO.WS_DTLOTE_E}");

                /*" -3592- DISPLAY 'NRLOTE  ' WS-NRLOTE-E */
                _.Display($"NRLOTE  {WORK_AREA.WS_TRABALHO.WS_NRLOTE_E}");

                /*" -3593- DISPLAY 'SEQLOTE ' WS-SEQLOTE-E */
                _.Display($"SEQLOTE {WORK_AREA.WS_TRABALHO.WS_SEQLOTE_E}");

                /*" -3595- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3596- DISPLAY 'PROPOSTA' PROPAZ-NRPROPAZ */
            _.Display($"PROPOSTA{PROPAZ_NRPROPAZ}");

            /*" -3597- DISPLAY 'AGENCIA ' PROPAZ-AGELOTE */
            _.Display($"AGENCIA {PROPAZ_AGELOTE}");

            /*" -3598- DISPLAY 'DATA    ' PROPAZ-DTLOTE */
            _.Display($"DATA    {PROPAZ_DTLOTE}");

            /*" -3599- DISPLAY 'NRLOTE  ' PROPAZ-NRLOTE */
            _.Display($"NRLOTE  {PROPAZ_NRLOTE}");

            /*" -3601- DISPLAY 'SEQLOTE ' PROPAZ-NRSEQLOTE */
            _.Display($"SEQLOTE {PROPAZ_NRSEQLOTE}");

            /*" -3604- MOVE 'UPDATE V0HISTCOMPROPAZ' TO COMANDO. */
            _.Move("UPDATE V0HISTCOMPROPAZ", LOCALIZA_ABEND_2.COMANDO);

            /*" -3605- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3607- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3608- MOVE 'VA0812B' TO USUARIO */
            _.Move("VA0812B", USUARIO);

            /*" -3620- PERFORM M_1241_REJEITA_COMISSAO_DB_UPDATE_2 */

            M_1241_REJEITA_COMISSAO_DB_UPDATE_2();

            /*" -3623- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3624- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3625- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3626- ADD SFT TO STT(27) */
            TOTAIS_ROT.FILLER_29[27].STT.Value = TOTAIS_ROT.FILLER_29[27].STT + WS_HORAS.SFT;

            /*" -3628- ADD 1 TO SQT(27) */
            TOTAIS_ROT.FILLER_29[27].SQT.Value = TOTAIS_ROT.FILLER_29[27].SQT + 1;

            /*" -3629- DISPLAY 'PROPOSTA' PROPAZ-NRPROPAZ */
            _.Display($"PROPOSTA{PROPAZ_NRPROPAZ}");

            /*" -3630- DISPLAY 'AGENCIA ' PROPAZ-AGELOTE */
            _.Display($"AGENCIA {PROPAZ_AGELOTE}");

            /*" -3631- DISPLAY 'DATA    ' PROPAZ-DTLOTE */
            _.Display($"DATA    {PROPAZ_DTLOTE}");

            /*" -3632- DISPLAY 'NRLOTE  ' PROPAZ-NRLOTE */
            _.Display($"NRLOTE  {PROPAZ_NRLOTE}");

            /*" -3634- DISPLAY 'SEQLOTE ' PROPAZ-NRSEQLOTE */
            _.Display($"SEQLOTE {PROPAZ_NRSEQLOTE}");

            /*" -3635- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3637- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3640- MOVE 'INSERT V0HISTCOMPROPAZ' TO COMANDO. */
            _.Move("INSERT V0HISTCOMPROPAZ", LOCALIZA_ABEND_2.COMANDO);

            /*" -3641- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3643- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI;

            /*" -3660- PERFORM M_1241_REJEITA_COMISSAO_DB_INSERT_2 */

            M_1241_REJEITA_COMISSAO_DB_INSERT_2();

            /*" -3663- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3664- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF;

            /*" -3665- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3666- ADD SFT TO STT(28) */
            TOTAIS_ROT.FILLER_29[28].STT.Value = TOTAIS_ROT.FILLER_29[28].STT + WS_HORAS.SFT;

            /*" -3669- ADD 1 TO SQT(28) */
            TOTAIS_ROT.FILLER_29[28].SQT.Value = TOTAIS_ROT.FILLER_29[28].SQT + 1;

            /*" -3670- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3670- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1241-REJEITA-COMISSAO-DB-SELECT-1 */
        public void M_1241_REJEITA_COMISSAO_DB_SELECT_1()
        {
            /*" -3448- EXEC SQL SELECT AGELOTE, DTLOTE, DTQITBCO, NRLOTE, NRSEQLOTE, CODPRODAZ INTO :PROPAZ-AGELOTE, :PROPAZ-DTLOTE, :PROPAZ-DTQITBCO, :PROPAZ-NRLOTE, :PROPAZ-NRSEQLOTE, :PROPAZ-CODPRODAZ FROM SEGUROS.V0PROPAZUL WHERE NRPROPAZ = :PROPAZ-NRPROPAZ WITH UR END-EXEC. */

            var m_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1 = new M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1()
            {
                PROPAZ_NRPROPAZ = PROPAZ_NRPROPAZ.ToString(),
            };

            var executed_1 = M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1.Execute(m_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPAZ_AGELOTE, PROPAZ_AGELOTE);
                _.Move(executed_1.PROPAZ_DTLOTE, PROPAZ_DTLOTE);
                _.Move(executed_1.PROPAZ_DTQITBCO, PROPAZ_DTQITBCO);
                _.Move(executed_1.PROPAZ_NRLOTE, PROPAZ_NRLOTE);
                _.Move(executed_1.PROPAZ_NRSEQLOTE, PROPAZ_NRSEQLOTE);
                _.Move(executed_1.PROPAZ_CODPRODAZ, PROPAZ_CODPRODAZ);
            }


        }

        [StopWatch]
        /*" M-1241-REJEITA-COMISSAO-DB-UPDATE-1 */
        public void M_1241_REJEITA_COMISSAO_DB_UPDATE_1()
        {
            /*" -3503- EXEC SQL UPDATE SEGUROS.V0MOVCOMIS SET SITUACAO = '4' , DATA_SAIDA = NULL WHERE NSAS = :MVCOM-NSAS AND NSL = :MVCOM-NSL END-EXEC. */

            var m_1241_REJEITA_COMISSAO_DB_UPDATE_1_Update1 = new M_1241_REJEITA_COMISSAO_DB_UPDATE_1_Update1()
            {
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
            };

            M_1241_REJEITA_COMISSAO_DB_UPDATE_1_Update1.Execute(m_1241_REJEITA_COMISSAO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1241-REJEITA-COMISSAO-DB-INSERT-1 */
        public void M_1241_REJEITA_COMISSAO_DB_INSERT_1()
        {
            /*" -3529- EXEC SQL INSERT INTO SEGUROS.V0RETORNOCOMIS VALUES (:SQL-NSAC, :MVCOM-NSAS, :MVCOM-NSL, :MVCOM-COD-RETORNO, :DTMOVABE, :MVCOM-DATA-MOV) END-EXEC. */

            var m_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1 = new M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1()
            {
                SQL_NSAC = SQL_NSAC.ToString(),
                MVCOM_NSAS = MVCOM_NSAS.ToString(),
                MVCOM_NSL = MVCOM_NSL.ToString(),
                MVCOM_COD_RETORNO = MVCOM_COD_RETORNO.ToString(),
                DTMOVABE = DTMOVABE.ToString(),
                MVCOM_DATA_MOV = MVCOM_DATA_MOV.ToString(),
            };

            M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1.Execute(m_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1241_FIM*/

        [StopWatch]
        /*" M-1241-REJEITA-COMISSAO-DB-SELECT-2 */
        public void M_1241_REJEITA_COMISSAO_DB_SELECT_2()
        {
            /*" -3572- EXEC SQL SELECT VALUE(SUM(VLCOMISVG),0), VALUE(SUM(VLCOMISAP),0), VALUE(MAX(VALBASVG),0), VALUE(MAX(VALBASAP),0) INTO :COMPROPH-VLCOMISVG, :COMPROPH-VLCOMISAP, :COMPROPH-VALBASVG, :COMPROPH-VALBASAP FROM SEGUROS.V0HISTCOMPROPAZ WHERE NRPROPAZ = :PROPAZ-NRPROPAZ AND AGELOTE = :PROPAZ-AGELOTE AND DTLOTE = :PROPAZ-DTLOTE AND NRLOTE = :PROPAZ-NRLOTE AND NRSEQLOTE = :PROPAZ-NRSEQLOTE AND TIPCOM = 'G' WITH UR END-EXEC. */

            var m_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1 = new M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1()
            {
                PROPAZ_NRSEQLOTE = PROPAZ_NRSEQLOTE.ToString(),
                PROPAZ_NRPROPAZ = PROPAZ_NRPROPAZ.ToString(),
                PROPAZ_AGELOTE = PROPAZ_AGELOTE.ToString(),
                PROPAZ_DTLOTE = PROPAZ_DTLOTE.ToString(),
                PROPAZ_NRLOTE = PROPAZ_NRLOTE.ToString(),
            };

            var executed_1 = M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1.Execute(m_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COMPROPH_VLCOMISVG, COMPROPH_VLCOMISVG);
                _.Move(executed_1.COMPROPH_VLCOMISAP, COMPROPH_VLCOMISAP);
                _.Move(executed_1.COMPROPH_VALBASVG, COMPROPH_VALBASVG);
                _.Move(executed_1.COMPROPH_VALBASAP, COMPROPH_VALBASAP);
            }


        }

        [StopWatch]
        /*" M-1241-REJEITA-COMISSAO-DB-UPDATE-2 */
        public void M_1241_REJEITA_COMISSAO_DB_UPDATE_2()
        {
            /*" -3620- EXEC SQL UPDATE SEGUROS.V0HISTCOMPROPAZ SET SITUACAO = '2' , COD_USUARIO = :USUARIO, TIMESTAMP = CURRENT TIMESTAMP WHERE NRPROPAZ = :PROPAZ-NRPROPAZ AND AGELOTE = :PROPAZ-AGELOTE AND DTLOTE = :PROPAZ-DTLOTE AND NRLOTE = :PROPAZ-NRLOTE AND NRSEQLOTE = :PROPAZ-NRSEQLOTE AND TIPCOM = 'G' END-EXEC. */

            var m_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1 = new M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1()
            {
                USUARIO = USUARIO.ToString(),
                PROPAZ_NRSEQLOTE = PROPAZ_NRSEQLOTE.ToString(),
                PROPAZ_NRPROPAZ = PROPAZ_NRPROPAZ.ToString(),
                PROPAZ_AGELOTE = PROPAZ_AGELOTE.ToString(),
                PROPAZ_DTLOTE = PROPAZ_DTLOTE.ToString(),
                PROPAZ_NRLOTE = PROPAZ_NRLOTE.ToString(),
            };

            M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1.Execute(m_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-1241-REJEITA-COMISSAO-DB-INSERT-2 */
        public void M_1241_REJEITA_COMISSAO_DB_INSERT_2()
        {
            /*" -3660- EXEC SQL INSERT INTO SEGUROS.V0HISTCOMPROPAZ VALUES ( :PROPAZ-NRPROPAZ, :PROPAZ-AGELOTE, :PROPAZ-DTLOTE, :PROPAZ-NRLOTE, :PROPAZ-NRSEQLOTE, 'G' , 102, :COMPROPH-VLCOMISVG, :COMPROPH-VLCOMISAP, :COMPROPH-VALBASVG, :COMPROPH-VALBASAP, CURRENT DATE, '0' , 'VA0812B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1 = new M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1()
            {
                PROPAZ_NRPROPAZ = PROPAZ_NRPROPAZ.ToString(),
                PROPAZ_AGELOTE = PROPAZ_AGELOTE.ToString(),
                PROPAZ_DTLOTE = PROPAZ_DTLOTE.ToString(),
                PROPAZ_NRLOTE = PROPAZ_NRLOTE.ToString(),
                PROPAZ_NRSEQLOTE = PROPAZ_NRSEQLOTE.ToString(),
                COMPROPH_VLCOMISVG = COMPROPH_VLCOMISVG.ToString(),
                COMPROPH_VLCOMISAP = COMPROPH_VLCOMISAP.ToString(),
                COMPROPH_VALBASVG = COMPROPH_VALBASVG.ToString(),
                COMPROPH_VALBASAP = COMPROPH_VALBASAP.ToString(),
            };

            M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1.Execute(m_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-3000-00-DECLARE-V1AGENCEF */
        private void M_3000_00_DECLARE_V1AGENCEF(bool isPerform = false)
        {
            /*" -3679- MOVE '3000-DECLA-V1AGENCEF   ' TO PARAGRAFO. */
            _.Move("3000-DECLA-V1AGENCEF   ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3681- MOVE 'DECLARE V1AGENCEF+V1MALHCEF' TO COMANDO. */
            _.Move("DECLARE V1AGENCEF+V1MALHCEF", LOCALIZA_ABEND_2.COMANDO);

            /*" -3691- PERFORM M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -3693- PERFORM M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -3696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3697- DISPLAY '3000 - PROBLEMAS DECLARE (V1AGENCEF) ..' */
                _.Display($"3000 - PROBLEMAS DECLARE (V1AGENCEF) ..");

                /*" -3698- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -3698- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-3000-00-DECLARE-V1AGENCEF-DB-OPEN-1 */
        public void M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1()
        {
            /*" -3693- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -3881- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA IN ( 00, 10, 11 ) ORDER BY CODPRODU WITH UR END-EXEC. */
            V0PRODUTO = new VA0812B_V0PRODUTO(false);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF */
        private void M_3100_00_FETCH_V1AGENCEF(bool isPerform = false)
        {
            /*" -3707- MOVE '3100-FETCH-V1AGENCEF   ' TO PARAGRAFO. */
            _.Move("3100-FETCH-V1AGENCEF   ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3709- MOVE 'FETCH   V1AGENCIACEF   ' TO COMANDO. */
            _.Move("FETCH   V1AGENCIACEF   ", LOCALIZA_ABEND_2.COMANDO);

            /*" -3712- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -3715- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3716- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3717- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", WFIM_V1AGENCEF);

                    /*" -3717- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -3719- ELSE */
                }
                else
                {


                    /*" -3719- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -3721- DISPLAY '3100 - (PROBLEMAS NO FETCH V1AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH V1AGENCEF) ..");

                    /*" -3722- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -3723- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -3724- ELSE */
                }

            }
            else
            {


                /*" -3724- ADD 1 TO AC-L-V1AGENCEF. */
                AC_L_V1AGENCEF.Value = AC_L_V1AGENCEF + 1;
            }


        }

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -3712- EXEC SQL FETCH V1AGENCEF INTO :V1ACEF-COD-AGENCIA, :V1MCEF-COD-FONTE END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.V1ACEF_COD_AGENCIA, V1ACEF_COD_AGENCIA);
                _.Move(V1AGENCEF.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF-DB-CLOSE-1 */
        public void M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_1()
        {
            /*" -3717- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_FIM*/

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -3719- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" M-3200-00-CARREGA-FILIAL */
        private void M_3200_00_CARREGA_FILIAL(bool isPerform = false)
        {
            /*" -3734- MOVE '3200-CARREGA-FILIAL    ' TO PARAGRAFO. */
            _.Move("3200-CARREGA-FILIAL    ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3736- MOVE 'CARREGA FILIAL         ' TO COMANDO. */
            _.Move("CARREGA FILIAL         ", LOCALIZA_ABEND_2.COMANDO);

            /*" -3738- MOVE V1ACEF-COD-AGENCIA TO TAB-AGENCIA (V1ACEF-COD-AGENCIA) */
            _.Move(V1ACEF_COD_AGENCIA, WORK_AREA.TAB_FILIAL.FILLER_6[V1ACEF_COD_AGENCIA].TAB_AGENCIA);

            /*" -3741- MOVE V1MCEF-COD-FONTE TO TAB-FONTE (V1ACEF-COD-AGENCIA) */
            _.Move(V1MCEF_COD_FONTE, WORK_AREA.TAB_FILIAL.FILLER_6[V1ACEF_COD_AGENCIA].TAB_FONTE);

            /*" -3741- PERFORM 3100-00-FETCH-V1AGENCEF. */

            M_3100_00_FETCH_V1AGENCEF(true);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_FIM*/

        [StopWatch]
        /*" M-3300-BUSCA-FONTE */
        private void M_3300_BUSCA_FONTE(bool isPerform = false)
        {
            /*" -3751- MOVE '3300-BUSCA-FONTE   ' TO PARAGRAFO. */
            _.Move("3300-BUSCA-FONTE   ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3753- MOVE 'BUSCA-FONTE        ' TO COMANDO. */
            _.Move("BUSCA-FONTE        ", LOCALIZA_ABEND_2.COMANDO);

            /*" -3754- MOVE ZEROES TO FLAG88. */
            _.Move(0, FLAG88);

            /*" -3756- MOVE RF-AGENCIA TO WHOST-AGE-VENDA */
            _.Move(RET_CADASTRAMENTO.RF_AGENCIA, WHOST_AGE_VENDA);

            /*" -3757- IF WHOST-AGE-VENDA = TAB-AGENCIA (WHOST-AGE-VENDA) */

            if (WHOST_AGE_VENDA == WORK_AREA.TAB_FILIAL.FILLER_6[WHOST_AGE_VENDA].TAB_AGENCIA)
            {

                /*" -3758- IF TAB-FONTE (WHOST-AGE-VENDA) EQUAL 10 */

                if (WORK_AREA.TAB_FILIAL.FILLER_6[WHOST_AGE_VENDA].TAB_FONTE == 10)
                {

                    /*" -3759- DISPLAY 'A FONTE DA AGENCIA NAO E PERMITIDA ' */
                    _.Display($"A FONTE DA AGENCIA NAO E PERMITIDA ");

                    /*" -3760- DISPLAY 'AGENCIA ... ' TAB-AGENCIA (WHOST-AGE-VENDA) */
                    _.Display($"AGENCIA ... {WORK_AREA.TAB_FILIAL.FILLER_6[WHOST_AGE_VENDA]}");

                    /*" -3761- DISPLAY 'FONTE   ... ' TAB-FONTE (WHOST-AGE-VENDA) */
                    _.Display($"FONTE   ... {WORK_AREA.TAB_FILIAL.FILLER_6[WHOST_AGE_VENDA]}");

                    /*" -3762- MOVE 1 TO FLAG88 */
                    _.Move(1, FLAG88);

                    /*" -3764- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -3765- IF WHOST-AGE-VENDA NOT EQUAL TAB-AGENCIA (WHOST-AGE-VENDA) */

            if (WHOST_AGE_VENDA != WORK_AREA.TAB_FILIAL.FILLER_6[WHOST_AGE_VENDA].TAB_AGENCIA)
            {

                /*" -3766- DISPLAY 'AGENCIA NAO IDENTIFICADA .. ' WHOST-AGE-VENDA */
                _.Display($"AGENCIA NAO IDENTIFICADA .. {WHOST_AGE_VENDA}");

                /*" -3767- MOVE 1 TO FLAG88 */
                _.Move(1, FLAG88);

                /*" -3767- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3300_FIM*/

        [StopWatch]
        /*" M-3400-NUM-PARCELA */
        private void M_3400_NUM_PARCELA(bool isPerform = false)
        {
            /*" -3781- MOVE ZEROS TO HISR-NUM-PARCELA. */
            _.Move(0, HISR_NUM_PARCELA);

            /*" -3782- MOVE RF-COD-RETORNO TO HISR-CODOPER. */
            _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, HISR_CODOPER);

            /*" -3784- MOVE RESA-DESCR TO WS-DESCR. */
            _.Move(RESA_DESCR, WORK_AREA.WS_DESCR);

            /*" -3785- IF WS-PARC EQUAL 'PARC ' */

            if (WORK_AREA.WS_DESCR.WS_PARC == "PARC ")
            {

                /*" -3786- IF WS-NUM-PARCELA NUMERIC */

                if (WORK_AREA.WS_DESCR.WS_NUM_PARCELA.IsNumeric())
                {

                    /*" -3786- MOVE WS-NUM-PARCELA TO HISR-NUM-PARCELA. */
                    _.Move(WORK_AREA.WS_DESCR.WS_NUM_PARCELA, HISR_NUM_PARCELA);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3400_FIM*/

        [StopWatch]
        /*" M-8800-UPDATE-FOLLOWUP */
        private void M_8800_UPDATE_FOLLOWUP(bool isPerform = false)
        {
            /*" -3794- MOVE '8800-UPDATE-FOLLOWUP   ' TO PARAGRAFO. */
            _.Move("8800-UPDATE-FOLLOWUP   ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3806- PERFORM M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1 */

            M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1();

            /*" -3809- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3810- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3811- DISPLAY '8800- PROBLEMAS UPDATE (FOLLOWUP) 100' */
                    _.Display($"8800- PROBLEMAS UPDATE (FOLLOWUP) 100");

                    /*" -3812- DISPLAY 'NUM_CERTIFICADO ' RF-NRCERTIF */
                    _.Display($"NUM_CERTIFICADO {RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NRCERTIF}");

                    /*" -3813- DISPLAY 'NUM_NOSSA_FITA  ' RF-NSAS */
                    _.Display($"NUM_NOSSA_FITA  {RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NSAS}");

                    /*" -3814- DISPLAY 'NUM_LANCAMENTO  ' RF-NSL */
                    _.Display($"NUM_LANCAMENTO  {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL}");

                    /*" -3815- ELSE */
                }
                else
                {


                    /*" -3816- DISPLAY '8800- PROBLEMAS UPDATE (FOLLOWUP)   ' */
                    _.Display($"8800- PROBLEMAS UPDATE (FOLLOWUP)   ");

                    /*" -3816- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-8800-UPDATE-FOLLOWUP-DB-UPDATE-1 */
        public void M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1()
        {
            /*" -3806- EXEC SQL UPDATE SEGUROS.VG_FOLLOW_UP SET NUM_PARCELA_USADA = :HCTA-NRPARCEL, STA_PROCESSAMENTO = 'P' , COD_USUARIO = 'VA0812B' , DTH_ATUALIZACAO = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :VGFOLLOW-NUM-CERTIFICADO AND NUM_NOSSA_FITA = :VGFOLLOW-NUM-NOSSA-FITA AND NUM_LANCAMENTO = :VGFOLLOW-NUM-LANCAMENTO END-EXEC. */

            var m_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1 = new M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1()
            {
                HCTA_NRPARCEL = HCTA_NRPARCEL.ToString(),
                VGFOLLOW_NUM_CERTIFICADO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO.ToString(),
                VGFOLLOW_NUM_NOSSA_FITA = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA.ToString(),
                VGFOLLOW_NUM_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO.ToString(),
            };

            M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1.Execute(m_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8800_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO */
        private void R0050_00_INICIO(bool isPerform = false)
        {
            /*" -3835- MOVE 'R0050-INICIO            ' TO PARAGRAFO. */
            _.Move("R0050-INICIO            ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3836- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -3839- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -3843- PERFORM R0220-00-MOVE-DADOS THRU R0220-99-SAIDA. */

            R0220_00_MOVE_DADOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/


            /*" -3844- MOVE 1 TO LD-PRODUTO */
            _.Move(1, LD_PRODUTO);

            /*" -3845- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WFIM_PRODUTO);

            /*" -3848- PERFORM R0200-00-DECLARE-V0PRODUTO THRU R0200-99-SAIDA. */

            R0200_00_DECLARE_V0PRODUTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/


            /*" -3853- PERFORM R0210-00-FETCH-V0PRODUTO THRU R0210-99-SAIDA UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WFIM_PRODUTO.IsEmpty()))
            {

                R0210_00_FETCH_V0PRODUTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

            }

            /*" -3857- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -3859- PERFORM R0220-00-MOVE-DADOS THRU R0220-99-SAIDA UNTIL WS-SUBS GREATER 2000. */

            while (!(WS_SUBS > 2000))
            {

                R0220_00_MOVE_DADOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO */
        private void R0200_00_DECLARE_V0PRODUTO(bool isPerform = false)
        {
            /*" -3872- MOVE 'R0200-DECLARE-V0PRODUTO ' TO PARAGRAFO. */
            _.Move("R0200-DECLARE-V0PRODUTO ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3881- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -3883- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -3887- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3888- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ");

                /*" -3888- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -3883- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO */
        private void R0210_00_FETCH_V0PRODUTO(bool isPerform = false)
        {
            /*" -3901- MOVE 'R0210-FETCH-V0PRODUTO   ' TO PARAGRAFO. */
            _.Move("R0210-FETCH-V0PRODUTO   ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3903- PERFORM R0210_00_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_00_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -3907- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3907- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -3909- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WFIM_PRODUTO);

                /*" -3911- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3912- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3913- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -3916- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3918- ADD 1 TO LD-PRODUTO. */
            LD_PRODUTO.Value = LD_PRODUTO + 1;

            /*" -3919- IF LD-PRODUTO GREATER 2000 */

            if (LD_PRODUTO > 2000)
            {

                /*" -3919- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -3921- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -3924- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3925- PERFORM R0220-00-MOVE-DADOS THRU R0220-99-SAIDA. */

            R0220_00_MOVE_DADOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/


        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -3903- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -3907- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -3919- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0220-00-MOVE-DADOS */
        private void R0220_00_MOVE_DADOS(bool isPerform = false)
        {
            /*" -3938- MOVE 'R0220-MOVE-DADOS        ' TO PARAGRAFO. */
            _.Move("R0220-MOVE-DADOS        ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3942- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-PRD). */
            _.Move(V0PROD_CODPRODU, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU);

            /*" -3943- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -3947- PERFORM R0250-00-MOVE-TIPO THRU R0250-99-SAIDA 03 TIMES. */

            R0250_00_MOVE_TIPO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/


            /*" -3948- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -3948- SET WS-SUBS TO WS-PRD. */
            WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-MOVE-TIPO */
        private void R0250_00_MOVE_TIPO(bool isPerform = false)
        {
            /*" -3961- MOVE 'R0250-MOVE-TIPO         ' TO PARAGRAFO. */
            _.Move("R0250-MOVE-TIPO         ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3966- SET WS-SUBS1 TO WS-TIP. */
            WS_SUBS1.Value = WS_TIP;

            /*" -3967- IF WS-SUBS1 EQUAL 1 */

            if (WS_SUBS1 == 1)
            {

                /*" -3969- MOVE 'A' TO WTABG-TIPO(WS-PRD WS-TIP) */
                _.Move("A", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                /*" -3973- ELSE */
            }
            else
            {


                /*" -3974- IF WS-SUBS1 EQUAL 2 */

                if (WS_SUBS1 == 2)
                {

                    /*" -3976- MOVE 'M' TO WTABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("M", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -3980- ELSE */
                }
                else
                {


                    /*" -3984- MOVE 'S' TO WTABG-TIPO(WS-PRD WS-TIP). */
                    _.Move("S", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);
                }

            }


            /*" -3985- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -3989- PERFORM R0260-00-MOVE-SITUACAO THRU R0260-99-SAIDA 02 TIMES. */

            R0260_00_MOVE_SITUACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/


            /*" -3989- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-SITUACAO */
        private void R0260_00_MOVE_SITUACAO(bool isPerform = false)
        {
            /*" -4002- MOVE 'R0260-MOVE-SITUACAO     ' TO PARAGRAFO. */
            _.Move("R0260-MOVE-SITUACAO     ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4011- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -4016- SET WS-SUBS2 TO WS-SIT. */
            WS_SUBS2.Value = WS_SIT;

            /*" -4017- IF WS-SUBS2 EQUAL 1 */

            if (WS_SUBS2 == 1)
            {

                /*" -4019- MOVE '0' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                _.Move("0", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -4023- ELSE */
            }
            else
            {


                /*" -4027- MOVE '2' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT). */
                _.Move("2", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);
            }


            /*" -4027- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-CALCULA-BISSEXTO */
        private void R0300_00_CALCULA_BISSEXTO(bool isPerform = false)
        {
            /*" -4039- MOVE 'R0300-00-CALCULA-BISSEXTO' TO PARAGRAFO. */
            _.Move("R0300-00-CALCULA-BISSEXTO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4041- MOVE WHOST-DTVENCTO(1:4) TO AUX-ANO. */
            _.Move(WHOST_DTVENCTO.Substring(1, 4), AUX_ANO);

            /*" -4042- IF AUX-ANO2 EQUAL ZEROS */

            if (FILLER_17.AUX_ANO2 == 00)
            {

                /*" -4044- DIVIDE AUX-ANO BY 400 GIVING WS-RESULT REMAINDER WS-RESTO */
                _.Divide(AUX_ANO, 400, WS_RESULT, WS_RESTO);

                /*" -4045- ELSE */
            }
            else
            {


                /*" -4047- DIVIDE AUX-ANO BY 4 GIVING WS-RESULT REMAINDER WS-RESTO */
                _.Divide(AUX_ANO, 4, WS_RESULT, WS_RESTO);

                /*" -4048- END-IF. */
            }


            /*" -4049- IF WS-RESTO EQUAL ZEROS */

            if (WS_RESTO == 00)
            {

                /*" -4050- MOVE 29 TO WHOST-DTVENCTO(9:2) */
                _.MoveAtPosition(29, WHOST_DTVENCTO, 9, 2);

                /*" -4051- ELSE */
            }
            else
            {


                /*" -4052- MOVE 28 TO WHOST-DTVENCTO(9:2) */
                _.MoveAtPosition(28, WHOST_DTVENCTO, 9, 2);

                /*" -4052- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-TRATA-DESPESAS */
        private void R8000_00_TRATA_DESPESAS(bool isPerform = false)
        {
            /*" -4062- MOVE 'R8000-TRATA-DESPESAS    ' TO PARAGRAFO. */
            _.Move("R8000-TRATA-DESPESAS    ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4066- PERFORM R8010-00-VER-PRODUTO THRU R8010-99-SAIDA. */

            R8010_00_VER_PRODUTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_99_SAIDA*/


            /*" -4067- MOVE RF-VALOR TO WSHOST-VLPRMTOT */
            _.Move(RET_CADASTRAMENTO.RF_VALOR, WSHOST_VLPRMTOT);

            /*" -4068- MOVE V0PROP-CODPRODU TO WSHOST-CODPRODU */
            _.Move(V0PROP_CODPRODU, WSHOST_CODPRODU);

            /*" -4072- MOVE ZEROS TO WSHOST-VLTARIFA WSHOST-VLBALCAO WSHOST-VLIOCC WSHOST-VLDESCON */
            _.Move(0, WSHOST_VLTARIFA, WSHOST_VLBALCAO, WSHOST_VLIOCC, WSHOST_VLDESCON);

            /*" -4074- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -4075- IF WS-CONVENIO EQUAL 6131 */

            if (WORK_AREA.WS_CONVENIO == 6131)
            {

                /*" -4076- MOVE 0,56 TO WSHOST-VLTARIFA */
                _.Move(0.56, WSHOST_VLTARIFA);

                /*" -4077- ELSE */
            }
            else
            {


                /*" -4080- MOVE 0,60 TO WSHOST-VLTARIFA. */
                _.Move(0.60, WSHOST_VLTARIFA);
            }


            /*" -4081- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -4082- SEARCH WTABG-OCORREPRD */
            for (; WS_PRD < AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -4084- WHEN WSHOST-CODPRODU EQUAL WTABG-CODPRODU(WS-PRD) */

                if (WSHOST_CODPRODU == AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU)
                {


                    /*" -4085- PERFORM R8050-00-VERIFICA-TIPO THRU R8050-99-SAIDA  END-SEARCH. */

                    R8050_00_VERIFICA_TIPO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8050_99_SAIDA*/

                    break;
                }
            }


            /*" -4091- ADD WSHOST-VLPRMTOT TO AUX-VLPRMTOT. */
            AUX_VLPRMTOT.Value = AUX_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -4092- ADD WSHOST-VLTARIFA TO AUX-VLDESPES. */
            AUX_VLDESPES.Value = AUX_VLDESPES + WSHOST_VLTARIFA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8010-00-VER-PRODUTO */
        private void R8010_00_VER_PRODUTO(bool isPerform = false)
        {
            /*" -4104- MOVE 'R8010-VER-PRODUTO       ' TO PARAGRAFO. */
            _.Move("R8010-VER-PRODUTO       ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4106- MOVE RF-NRCERTIF TO WSHOST-NRCERTIF. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_NRCERTIF, WSHOST_NRCERTIF);

            /*" -4115- PERFORM R8010_00_VER_PRODUTO_DB_SELECT_1 */

            R8010_00_VER_PRODUTO_DB_SELECT_1();

            /*" -4119- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4119- MOVE ZEROS TO V0PROP-CODPRODU. */
                _.Move(0, V0PROP_CODPRODU);
            }


        }

        [StopWatch]
        /*" R8010-00-VER-PRODUTO-DB-SELECT-1 */
        public void R8010_00_VER_PRODUTO_DB_SELECT_1()
        {
            /*" -4115- EXEC SQL SELECT A.CODPRODU INTO :V0PROP-CODPRODU FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :WSHOST-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES WITH UR END-EXEC. */

            var r8010_00_VER_PRODUTO_DB_SELECT_1_Query1 = new R8010_00_VER_PRODUTO_DB_SELECT_1_Query1()
            {
                WSHOST_NRCERTIF = WSHOST_NRCERTIF.ToString(),
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
            /*" -4132- MOVE 'R8050-VERIFICA-TIPO     ' TO PARAGRAFO. */
            _.Move("R8050-VERIFICA-TIPO     ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4137- SET WS-TIP TO 3. */
            WS_TIP.Value = 3;

            /*" -4138- IF WSHOST-SITUACAO EQUAL '0' */

            if (WSHOST_SITUACAO == "0")
            {

                /*" -4139- SET WS-SIT TO 1 */
                WS_SIT.Value = 1;

                /*" -4143- ELSE */
            }
            else
            {


                /*" -4146- SET WS-SIT TO 2. */
                WS_SIT.Value = 2;
            }


            /*" -4149- ADD 1 TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE + 1;

            /*" -4152- ADD WSHOST-VLPRMTOT TO WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -4155- ADD WSHOST-VLTARIFA TO WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA + WSHOST_VLTARIFA;

            /*" -4158- ADD WSHOST-VLBALCAO TO WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO + WSHOST_VLBALCAO;

            /*" -4161- ADD WSHOST-VLIOCC TO WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC + WSHOST_VLIOCC;

            /*" -4162- ADD WSHOST-VLDESCON TO WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON + WSHOST_VLDESCON;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8050_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-GRAVA-DESPESAS */
        private void R8500_00_GRAVA_DESPESAS(bool isPerform = false)
        {
            /*" -4175- MOVE 'R8500-GRAVA-DESPESAS    ' TO PARAGRAFO. */
            _.Move("R8500-GRAVA-DESPESAS    ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4176- IF WTABG-CODPRODU(WS-PRD) EQUAL 9999 */

            if (AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU == 9999)
            {

                /*" -4177- SET WS-PRD UP BY 1 */
                WS_PRD.Value += 1;

                /*" -4180- GO TO R8500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4183- MOVE WTABG-CODPRODU(WS-PRD) TO V0DPCF-CODPRODU. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU, V0DPCF_CODPRODU);

            /*" -4184- MOVE ZEROS TO V0DPCF-CODEMP */
            _.Move(0, V0DPCF_CODEMP);

            /*" -4185- MOVE V0AVIS-BCOAVISO TO V0DPCF-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0DPCF_BCOAVISO);

            /*" -4186- MOVE V0AVIS-AGEAVISO TO V0DPCF-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0DPCF_AGEAVISO);

            /*" -4187- MOVE V0AVIS-NRAVISO TO V0DPCF-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0DPCF_NRAVISO);

            /*" -4188- MOVE '1' TO V0DPCF-TIPOCOB */
            _.Move("1", V0DPCF_TIPOCOB);

            /*" -4189- MOVE V0AVIS-DTMOVTO TO V0DPCF-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0DPCF_DTMOVTO);

            /*" -4190- MOVE V0AVIS-DTAVISO TO V0DPCF-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0DPCF_DTAVISO);

            /*" -4193- MOVE ZEROS TO V0DPCF-VLJUROS V0DPCF-VLMULTA. */
            _.Move(0, V0DPCF_VLJUROS, V0DPCF_VLMULTA);

            /*" -4194- MOVE V0AVIS-DTAVISO TO WDATA-REL */
            _.Move(V0AVIS_DTAVISO, WDATA_REL);

            /*" -4195- MOVE WDAT-REL-ANO TO V0DPCF-ANOREF */
            _.Move(FILLER_14.WDAT_REL_ANO, V0DPCF_ANOREF);

            /*" -4197- MOVE WDAT-REL-MES TO V0DPCF-MESREF */
            _.Move(FILLER_14.WDAT_REL_MES, V0DPCF_MESREF);

            /*" -4198- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -4202- PERFORM R8550-00-GRAVA-TIPO THRU R8550-99-SAIDA 03 TIMES. */

            R8550_00_GRAVA_TIPO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/


            /*" -4202- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/

        [StopWatch]
        /*" R8550-00-GRAVA-TIPO */
        private void R8550_00_GRAVA_TIPO(bool isPerform = false)
        {
            /*" -4215- MOVE 'R8550-GRAVA-TIPO        ' TO PARAGRAFO. */
            _.Move("R8550-GRAVA-TIPO        ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4219- MOVE WTABG-TIPO(WS-PRD WS-TIP) TO V0DPCF-TIPOREG. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO, V0DPCF_TIPOREG);

            /*" -4220- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -4224- PERFORM R8600-00-GRAVA-REGISTRO THRU R8600-99-SAIDA 02 TIMES. */

            R8600_00_GRAVA_REGISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/


            /*" -4224- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/

        [StopWatch]
        /*" R8600-00-GRAVA-REGISTRO */
        private void R8600_00_GRAVA_REGISTRO(bool isPerform = false)
        {
            /*" -4237- MOVE 'R8600-GRAVA-REGISTRO    ' TO PARAGRAFO. */
            _.Move("R8600-GRAVA-REGISTRO    ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4239- MOVE WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) TO V0DPCF-SITUACAO. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO, V0DPCF_SITUACAO);

            /*" -4241- MOVE WTABG-QTDE(WS-PRD WS-TIP WS-SIT) TO V0DPCF-QTDREG. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, V0DPCF_QTDREG);

            /*" -4243- MOVE WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLPRMTOT. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, V0DPCF_VLPRMTOT);

            /*" -4245- MOVE WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLTARIFA. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, V0DPCF_VLTARIFA);

            /*" -4247- MOVE WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLBALCAO. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, V0DPCF_VLBALCAO);

            /*" -4249- MOVE WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLIOCC. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, V0DPCF_VLIOCC);

            /*" -4253- MOVE WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLDESCON. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON, V0DPCF_VLDESCON);

            /*" -4260- COMPUTE V0DPCF-VLPRMLIQ EQUAL (V0DPCF-VLPRMTOT + V0DPCF-VLTARIFA + V0DPCF-VLBALCAO + V0DPCF-VLIOCC + V0DPCF-VLDESCON + V0DPCF-VLJUROS + V0DPCF-VLMULTA). */
            V0DPCF_VLPRMLIQ.Value = (V0DPCF_VLPRMTOT + V0DPCF_VLTARIFA + V0DPCF_VLBALCAO + V0DPCF_VLIOCC + V0DPCF_VLDESCON + V0DPCF_VLJUROS + V0DPCF_VLMULTA);

            /*" -4265- IF V0DPCF-QTDREG EQUAL ZEROS AND V0DPCF-VLPRMTOT EQUAL ZEROS AND V0DPCF-VLPRMLIQ EQUAL ZEROS AND V0DPCF-VLTARIFA EQUAL ZEROS AND V0DPCF-VLBALCAO EQUAL ZEROS */

            if (V0DPCF_QTDREG == 00 && V0DPCF_VLPRMTOT == 00 && V0DPCF_VLPRMLIQ == 00 && V0DPCF_VLTARIFA == 00 && V0DPCF_VLBALCAO == 00)
            {

                /*" -4266- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -4269- GO TO R8600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4273- PERFORM R8700-00-INSERT-DESPESAS THRU R8700-99-SAIDA. */

            R8700_00_INSERT_DESPESAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8700_99_SAIDA*/


            /*" -4282- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -4282- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS */
        private void R8700_00_INSERT_DESPESAS(bool isPerform = false)
        {
            /*" -4295- MOVE 'R8700-INSERT-DESPESAS   ' TO PARAGRAFO. */
            _.Move("R8700-INSERT-DESPESAS   ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4320- PERFORM R8700_00_INSERT_DESPESAS_DB_INSERT_1 */

            R8700_00_INSERT_DESPESAS_DB_INSERT_1();

            /*" -4324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4325- DISPLAY 'R8700-00 - PROBLEMAS INSERT (DESPESAS)   ' */
                _.Display($"R8700-00 - PROBLEMAS INSERT (DESPESAS)   ");

                /*" -4325- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-DB-INSERT-1 */
        public void R8700_00_INSERT_DESPESAS_DB_INSERT_1()
        {
            /*" -4320- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF VALUES (:V0DPCF-CODEMP , :V0DPCF-ANOREF , :V0DPCF-MESREF , :V0DPCF-BCOAVISO , :V0DPCF-AGEAVISO , :V0DPCF-NRAVISO , :V0DPCF-CODPRODU , :V0DPCF-TIPOREG , :V0DPCF-SITUACAO , :V0DPCF-TIPOCOB , :V0DPCF-DTMOVTO , :V0DPCF-DTAVISO , :V0DPCF-QTDREG , :V0DPCF-VLPRMTOT , :V0DPCF-VLPRMLIQ , :V0DPCF-VLTARIFA , :V0DPCF-VLBALCAO , :V0DPCF-VLIOCC , :V0DPCF-VLDESCON , :V0DPCF-VLJUROS , :V0DPCF-VLMULTA , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -4340- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4341- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -4342- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -4343- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -4344- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(LOCALIZA_ABEND_1);

            /*" -4346- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(LOCALIZA_ABEND_2);

            /*" -4347- CLOSE RETCRE. */
            RETCRE.Close();

            /*" -4349- CLOSE RETINV. */
            RETINV.Close();

            /*" -4351- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4356- IF FLAG88 EQUAL 1 */

            if (FLAG88 == 1)
            {

                /*" -4357- MOVE 88 TO RETURN-CODE */
                _.Move(88, RETURN_CODE);

                /*" -4358- ELSE */
            }
            else
            {


                /*" -4360- MOVE 9 TO RETURN-CODE. */
                _.Move(9, RETURN_CODE);
            }


            /*" -4360- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}