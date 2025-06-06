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
using Sias.Bilhetes.DB2.BI0071B;

namespace Code
{
    public class BI0071B
    {
        public bool IsCall { get; set; }

        public BI0071B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI0071B   (VERSAO DO BI0031B)      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/2010                        *      */
        /*"      *   CADMUS .................  45.765                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - GERAR FITA DE MOVTO P/ COBRANCA  *      */
        /*"      *                               DE BILHETE AP PARA A NOVA        *      */
        /*"      *                               PARCERIA SYSTEM CRED             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      *                                     V0MOVDEBCC_CEF    I-O      *      */
        /*"      *                                     V0PARAM_CONTACEF  I-O      *      */
        /*"      *                                     V0BILHETE         I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                          ALTERACAO                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"V.29  *  VERSAO 29  - DEMANDA 564.320                                  *      */
        /*"      *             - SUBSTITUIR A CHAMADA DA ROTINA FC0105S DA CAP    *      */
        /*"      *               PELA VG0105S                                     *      */
        /*"      *               E DA SPBFC012 PELA SPBVG012                             */
        /*"      *             - PORQUE A CAP ESTA DEIXANDO O MAINFRAME.          *      */
        /*"      *                                                                *      */
        /*"      *  EM 18/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.29        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 28 - DEMANDA 231933                                   *      */
        /*"      *             - PASSA A USAR A SPBFC012 AO INVES DE ACESSAR AS   *      */
        /*"      *               TABELAS DA CAP DIRETAMENTE.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/02/2020 - CLAUDETE RADEL                               *      */
        /*"      *      13/04/2020 - HUSNI ALI HUSNI (MERGE CVP x CAP)            *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 27 - DEMANDA 226662 - TAREFA 238923                   *      */
        /*"      *             - VOLTAR VERS�O DE PROGRAMA E IMPLEMENTAR PESQUISA *      */
        /*"      *               DO C�DIGO DA EMPRESA DE PARCEIRO PARA CAP NA     *      */
        /*"      *               PARAMENTROS GERAIS                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/03/2020  -  HUSNI ALI HUSNI                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - HISTORIA 181375                                  *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2019 - RAUL BASILI ROTTA                            *      */
        /*"      *   MERGE DE VERSOES APOS ATENDIMENTO DA DEMANDA DE ACOPLADOS.   *      */
        /*"      *   HISTORIA 196716 - LUIZ FERNANDO GONCALVES                    *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - ABEND 173854                                     *      */
        /*"      *             - CORRECAO ABEND ACESSO TABELA CAP.                *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/03/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.25         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24 - HISTORIA 178780                                  *      */
        /*"      *             - MUDANCAS DE PRODUTOS ACOPLADOS - CAP             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - RIBAMAR MARQUES/CLAUDETE                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.24         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 - HISTORIA 39.487                                  *      */
        /*"      *             - RETIRADA DA V.22 E COLOCAR DISPLAYS PRA          *      */
        /*"      *               ACOMPANHAR A EXECU��O DO PROGRAMA.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/05/2018 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 - CADMUS 140843                                    *      */
        /*"      *             - AJUSTE NO PROGRAMA PARA OS PRODUTOS 8124 E 8132  *      */
        /*"      *               COMPRA NUMERO DE SORTEIO                         *      */
        /*"      *               UNIC                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/08/2016 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CADMUS 123799(ABEND)                             *      */
        /*"      *             - AJUSTE NO PROGRAMA PARA NAO ABENDAR COM          *      */
        /*"      *   LK-OUT-COD-RETORNO = 99 (PROPOSTA JA CADASTRADA - FC0105S)   *      */
        /*"      *   DESPREZANDO A PROPOSTA.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/10/2015 - RIBAMAR MARQUES (STEFANINI)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - CADMUS 123279                                    *      */
        /*"      *             - INTERRUPCAO DE REMESSA DE ARQUIVO PARA COBRANCA  *      */
        /*"      *               DE PARCELAS EM CONTA DE OUTROS BANCOS SAP/BACKSEG*      */
        /*"      *               ALTERANDO A SIT_COBRANCA DA MOVTO-DEBITOCC-CEF   *      */
        /*"      *               PARA "4 - PARCELA A CANCELAR".                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/10/2015 - ELIERMES OLIVEIRA (MILLENIUM)                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/01/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - CAD 117.785 - CORRECAO DE ABEND -310             *      */
        /*"      *               CORRECAO DE ABEND -310 EM UPDATE NA R1400        *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/07/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - CAD 107.004 - INTEGRACAO SAP/BACKSEG             *      */
        /*"      *             - CONFORME DEFINICAO SAP/DIRVI O SISTEMA SAP       *      */
        /*"      *               ATENDE A RECEPCAO DO ARQ-A PARA DEBITO EM        *      */
        /*"      *               CONTA OUTROS BANCOS.                             *      */
        /*"      *               ARQ-A GERADO PELO PGM EM8002B A PARTIR DA        *      */
        /*"      *               LEITURA DO ARQUIVO BI0071B1 GERADO NESTE PGM.    *      */
        /*"      *               OS DEBITOS REFERENTE A COBRANCA CARTAO DE        *      */
        /*"      *               CREDITO SERAO ENVIADOS PELO SIAS PARA BACKSEG.   *      */
        /*"      *               PARA EVITAR DUPLICIDADE DE COBRANCA ESTAMOS      *      */
        /*"      *               RETIRANDO A COBRANCA OUTROS BANCOS DO ARQUIVO    *      */
        /*"      *               MVDBSCRE.(MOVDEBITO-CC).                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/02/2015 - CLOVIS                                       *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 -   INTEGRACAO SAP                                 *      */
        /*"      *               - GERA ARQUIVO DAS COBRANCAS DO CONVENIO 102837  *      */
        /*"      *                 BACKSEG/CIELO (OUTROS BANCOS E CARTAO) PARA    *      */
        /*"      *                 GERACAO DO ARQ-A.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/08/2014 - CLOVIS                                       *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - CAD 85.727                                       *      */
        /*"      *               - AJUSTE PARA ENVIAR RETORNO DE COBRANCA         *      */
        /*"      *                 DE PARCELAS COBRADAS PELO CONVENIO 6114 (CEF)  *      */
        /*"      *                 DE BILHETES CANCELADOS.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/08/2013 - EDIVALDO GOMES   (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - CAD 81.113                                       *      */
        /*"      *               - AJUSTE PARA NAO ALTERAR A SITUACAO_COBRANCA    *      */
        /*"      *                 DE PARCELAS COBRADAS PELO CONVENIO 6114 (CEF). *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/04/2013 - EDIVALDO GOMES   (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 - CAD 75.124                                       *      */
        /*"      *               - AJUSTE NO PROGRAMA PARA NAO ABENDAR COM        *      */
        /*"      *   LK-OUT-COD-RETORNO = 98 (PROPOSTA JA CADASTRADA - FC0105S)  *       */
        /*"      *   DESPREZANDO A PROPOSTA.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/10/2012 - CLAUDIO FREITAS  (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 73.286                                       *      */
        /*"      *               - AJUSTE NO PROGRAMA PARA SOLICITAR A RENOVACAO  *      */
        /*"      *                 DO TITULO.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/08/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 71.926                                       *      */
        /*"      *               - AJUSTE NO PROGRAMA PARA CORRECAO DO ABEND      *      */
        /*"      *                 SQLCODE = -803 NA TABELA SEGUROS.V0MOVDEBCC_CEF*      */
        /*"      *                                                                *      */
        /*"      *   EM 13/07/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 70.663                                       *      */
        /*"      *           CORRECAO DO ABEND OCORRIDO DANDO SQLCODE = -803 NA   *      */
        /*"      *           TABELA DRCAP.FC_PROPOSTA.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/06/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 64.999                                       *      */
        /*"      *           ADAPTAR OS PROGRAMAS DE VIDA PARA UTILIZAREM A NOVA  *      */
        /*"      *           ROTINA DE COMPRA DA CAP QUE SOFREU ALTERACAO,        *      */
        /*"      *           MODIFICANDO A CHAMADA DA ROTINA FC0105B PARA FC0105S.*      */
        /*"      *                                                                *      */
        /*"      *   EM 22/12/2011 - ROGERIO PEREIRA (FASTCOMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 201.137 / 51.476 / 201.037                          */
        /*"      *               - KIT POS-VENDA (INSERE A LINHA NA RELATORIO)    *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/08/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 64.051                                       *      */
        /*"      *               - AJUSTE NO PROGRAMA PARA TRATAR CORRETAMENTE    *      */
        /*"      *                 PARCELAS DE OUTROS BANCOS.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/11/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 54.910                                       *      */
        /*"      *               - ALTERACAO DO PLANO DE CAPITALIZACAO DE 810     *      */
        /*"      *                 PARA 818                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/07/2011 - BRUNO RIBEIRO (FAST COMPUTER)                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 54.362                                       *      */
        /*"      *               - PREENCHER DATA DE CREDITO PARA MOVIMENTO CAIXA *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/03/2011 - TERCIO CARVALHO(FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 201.012                                      *      */
        /*"      *               - AJUSTE NO PROGRAMA                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/01/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 52.124                                       *      */
        /*"      *               - REVISAO DA OPERACAO.                           *      */
        /*"      *               - AJUSTE NO CODIGO DE CONVENIO MUDANDO DAS       *      */
        /*"      *                 SEIS ULTIMAS PARA AS SEIS PRIMEIRA POSICOES    *      */
        /*"      *                 EM FUNCAO DO SAP.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/01/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 51.015                                       *      */
        /*"      *                                                                *      */
        /*"      *             - PROJETO RETENCAO DE CLIENTES - SYSTEM CRED       *      */
        /*"      *               IMPLEMENTACAO DE UM NOVO PRODUTO.                *      */
        /*"      *               - 8124 (FACIL PLANO 1 ODONTO).                   *      */
        /*"      *               - 8132 (FACIL PLANO 2 ODONTO).                   *      */
        /*"      *               - 8125 (VIDA AP + RD).                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/12/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 50.292                                       *      */
        /*"      *               - GERA O MOVIMENTO DE COBRANCA COM AS PARCELAS   *      */
        /*"      *                 PAGAS PELO CONVENIO CAIXA.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/11/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVDEBITO_CC { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVDEBITO_CC
        {
            get
            {
                _.Move(HEADER_REGISTRO, _MOVDEBITO_CC); VarBasis.RedefinePassValue(HEADER_REGISTRO, _MOVDEBITO_CC, HEADER_REGISTRO); return _MOVDEBITO_CC;
            }
        }
        public FileBasis _RBI0071B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RBI0071B
        {
            get
            {
                _.Move(REG_BI0071B, _RBI0071B); VarBasis.RedefinePassValue(REG_BI0071B, _RBI0071B, REG_BI0071B); return _RBI0071B;
            }
        }
        public FileBasis _BI0071B1 { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis BI0071B1
        {
            get
            {
                _.Move(REG_BI0071B1, _BI0071B1); VarBasis.RedefinePassValue(REG_BI0071B1, _BI0071B1, REG_BI0071B1); return _BI0071B1;
            }
        }
        /*"01        HEADER-REGISTRO.*/
        public BI0071B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new BI0071B_HEADER_REGISTRO();
        public class BI0071B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  X(020).*/
            public StringBasis HEADER_CODCONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO   PIC  9(008).*/
            public IntBasis HEADER_DATGERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      HEADER-NSA          PIC  9(006).*/
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      HEADER-IDENTIFICA   PIC  X(017).*/
            public StringBasis HEADER_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      HEADER-FILLER       PIC  X(052).*/
            public StringBasis HEADER_FILLER { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01        MOVCC-REGISTRO.*/
        }
        public BI0071B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new BI0071B_MOVCC_REGISTRO();
        public class BI0071B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIBAN    PIC  X(020).*/
            public StringBasis MOVCC_IDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      MOVCC-DTPAGTO      PIC  X(008).*/
            public StringBasis MOVCC_DTPAGTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      MOVCC-DTCREDITO    PIC  X(008).*/
            public StringBasis MOVCC_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      MOVCC-IDTCLIEMP.*/
            public BI0071B_MOVCC_IDTCLIEMP MOVCC_IDTCLIEMP { get; set; } = new BI0071B_MOVCC_IDTCLIEMP();
            public class BI0071B_MOVCC_IDTCLIEMP : VarBasis
            {
                /*"    10    MOVCC-COD-BANCO    PIC  9(003).*/
                public IntBasis MOVCC_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    MOVCC-AGENCIA-DEB  PIC  9(004).*/
                public IntBasis MOVCC_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPERACAO-DEB PIC  9(004).*/
                public IntBasis MOVCC_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCTA-DEB   PIC  9(012).*/
                public IntBasis MOVCC_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCTA-DEB   PIC  X(001).*/
                public StringBasis MOVCC_DIGCTA_DEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    MOVCC-DIGCTA-DEB-R REDEFINES          MOVCC-DIGCTA-DEB   PIC  9(001).*/
                private _REDEF_IntBasis _movcc_digcta_deb_r { get; set; }
                public _REDEF_IntBasis MOVCC_DIGCTA_DEB_R
                {
                    get { _movcc_digcta_deb_r = new _REDEF_IntBasis(new PIC("9", "001", "9(001).")); ; _.Move(MOVCC_DIGCTA_DEB, _movcc_digcta_deb_r); VarBasis.RedefinePassValue(MOVCC_DIGCTA_DEB, _movcc_digcta_deb_r, MOVCC_DIGCTA_DEB); _movcc_digcta_deb_r.ValueChanged += () => { _.Move(_movcc_digcta_deb_r, MOVCC_DIGCTA_DEB); }; return _movcc_digcta_deb_r; }
                    set { VarBasis.RedefinePassValue(value, _movcc_digcta_deb_r, MOVCC_DIGCTA_DEB); }
                }  //Redefines
                /*"    10    FILLER             PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    MOVCC-NUM-PROPOSTA PIC  9(013).*/
                public IntBasis MOVCC_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    MOVCC-NUM-PARCELA  PIC  9(004).*/
                public IntBasis MOVCC_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-BARRA3       PIC  X(004).*/
                public StringBasis MOVCC_BARRA3 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      MOVCC-VLRDEBITO    PIC  9(010)V99.*/
            }
            public DoubleBasis MOVCC_VLRDEBITO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  05      MOVCC-VLRTARIFA    PIC  9(005)V99.*/
            public DoubleBasis MOVCC_VLRTARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  05      MOVCC-NSR          PIC  9(008).*/
            public IntBasis MOVCC_NSR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-AGEDEBITO    PIC  X(008).*/
            public StringBasis MOVCC_AGEDEBITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      MOVCC-TPCAPTURA    PIC  X(001).*/
            public StringBasis MOVCC_TPCAPTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-CODAUTENT    PIC  X(023).*/
            public StringBasis MOVCC_CODAUTENT { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"  05      MOVCC-CODAUTENT-R  REDEFINES          MOVCC-CODAUTENT.*/
            private _REDEF_BI0071B_MOVCC_CODAUTENT_R _movcc_codautent_r { get; set; }
            public _REDEF_BI0071B_MOVCC_CODAUTENT_R MOVCC_CODAUTENT_R
            {
                get { _movcc_codautent_r = new _REDEF_BI0071B_MOVCC_CODAUTENT_R(); _.Move(MOVCC_CODAUTENT, _movcc_codautent_r); VarBasis.RedefinePassValue(MOVCC_CODAUTENT, _movcc_codautent_r, MOVCC_CODAUTENT); _movcc_codautent_r.ValueChanged += () => { _.Move(_movcc_codautent_r, MOVCC_CODAUTENT); }; return _movcc_codautent_r; }
                set { VarBasis.RedefinePassValue(value, _movcc_codautent_r, MOVCC_CODAUTENT); }
            }  //Redefines
            public class _REDEF_BI0071B_MOVCC_CODAUTENT_R : VarBasis
            {
                /*"    10    MOVCC-NRCARTAO     PIC  9(016).*/
                public IntBasis MOVCC_NRCARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10    MOVCC-CDRETORNO    PIC  X(002).*/
                public StringBasis MOVCC_CDRETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10    MOVCC-CDRETORNO-R  REDEFINES          MOVCC-CDRETORNO    PIC  9(002).*/
                private _REDEF_IntBasis _movcc_cdretorno_r { get; set; }
                public _REDEF_IntBasis MOVCC_CDRETORNO_R
                {
                    get { _movcc_cdretorno_r = new _REDEF_IntBasis(new PIC("9", "002", "9(002).")); ; _.Move(MOVCC_CDRETORNO, _movcc_cdretorno_r); VarBasis.RedefinePassValue(MOVCC_CDRETORNO, _movcc_cdretorno_r, MOVCC_CDRETORNO); _movcc_cdretorno_r.ValueChanged += () => { _.Move(_movcc_cdretorno_r, MOVCC_CDRETORNO); }; return _movcc_cdretorno_r; }
                    set { VarBasis.RedefinePassValue(value, _movcc_cdretorno_r, MOVCC_CDRETORNO); }
                }  //Redefines
                /*"    10    FILLER             PIC  X(005).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"  05      MOVCC-TPPAGTO      PIC  9(001).*/

                public _REDEF_BI0071B_MOVCC_CODAUTENT_R()
                {
                    MOVCC_NRCARTAO.ValueChanged += OnValueChanged;
                    MOVCC_CDRETORNO.ValueChanged += OnValueChanged;
                    MOVCC_CDRETORNO_R.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis MOVCC_TPPAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      MOVCC-FILLER       PIC  X(007).*/
            public StringBasis MOVCC_FILLER { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public BI0071B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new BI0071B_TRAILL_REGISTRO();
        public class BI0071B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTDEB    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-FILLER       PIC  X(126).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01        REG-BI0071B        PIC  X(132).*/
        }
        public StringBasis REG_BI0071B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01        REG-BI0071B1       PIC  X(200).*/
        public StringBasis REG_BI0071B1 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WDATA-BASE-05                PIC X(10).*/
        public StringBasis WDATA_BASE_05 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE-30          PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE             PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE-10          PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTCURRENT            PIC X(10).*/
        public StringBasis V1SISTE_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-TSCURRENT            PIC X(26).*/
        public StringBasis V1SISTE_TSCURRENT { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  V1SISTE-DTMOVABE-FI          PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  VIND-COD-RETORNO             PIC S9(004)   VALUE +0     COMP*/
        public IntBasis VIND_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTH-FIM-VIGENCIA        PIC S9(04)    COMP VALUE +0.*/
        public IntBasis VIND_DTH_FIM_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-NULL01                  PIC S9(004)   VALUE +0     COMP*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NULL02                  PIC S9(004)   VALUE +0     COMP*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NULL03                  PIC S9(004)   VALUE +0     COMP*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NULL04                  PIC S9(004)   VALUE +0     COMP*/
        public IntBasis VIND_NULL04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NULL05                  PIC S9(004)   VALUE +0     COMP*/
        public IntBasis VIND_NULL05 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1EMPR-COD-EMP               PIC S9(004)     COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1EMPR-NOM-EMP               PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0MOVDE-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MOVDE-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-SIT-COBRANCA         PIC X(1).*/
        public StringBasis V0MOVDE_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0MOVDE-DTVENCTO             PIC X(10).*/
        public StringBasis V0MOVDE_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTVENCTO-5           PIC X(10).*/
        public StringBasis V0MOVDE_DTVENCTO_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-VLR-DEBITO           PIC S9(13)V9(2) COMP-3                                     VALUE 0.*/
        public DoubleBasis V0MOVDE_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0MOVDE-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-OPER-CONTA-DEB       PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NUM-CONTA-DEB        PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-DIG-CONTA-DEB        PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MOVDE-DTMOVTO              PIC X(10).*/
        public StringBasis V0MOVDE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTENVIO              PIC X(10).*/
        public StringBasis V0MOVDE_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTRETORNO            PIC X(10).*/
        public StringBasis V0MOVDE_DTRETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-COD-RETORNO-CEF      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-COD-USUARIO          PIC X(08).*/
        public StringBasis V0MOVDE_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0MOVDE-SEQUENCIA            PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-REQUISICAO           PIC S9(13) COMP-3                                     VALUE 0.*/
        public IntBasis V0MOVDE_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-DAYS                 PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_DAYS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PARAMC-TIPO-MOVTOCC         PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_TIPO_MOVTOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-CODPRODU             PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0PARAMC_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PARAMC-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-COD-AGENCIA-SASS     PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_COD_AGENCIA_SASS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-DTPROX-DEB           PIC X(10).*/
        public StringBasis V0PARAMC_DTPROX_DEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PARAMC-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-SITUACAO             PIC X(1).*/
        public StringBasis V0PARAMC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V1BILH-NUMBIL                 PIC S9(15) COMP-3.*/
        public IntBasis V1BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1BILH-NUMAPOL                PIC S9(13) COMP-3.*/
        public IntBasis V1BILH_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1BILH-OPCAO-COB              PIC S9(004) COMP.*/
        public IntBasis V1BILH_OPCAO_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1BILH-RAMO                   PIC S9(004) COMP.*/
        public IntBasis V1BILH_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1BILH-SITUACAO               PIC  X(01).*/
        public StringBasis V1BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1BILH-COD-CLIENTE            PIC S9(09) COMP.*/
        public IntBasis V1BILH_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1BILH-FONTE                  PIC S9(004) COMP.*/
        public IntBasis V1BILH_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1BILH-OCOREND                PIC S9(004) COMP.*/
        public IntBasis V1BILH_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1CLIEN-COD-CLIENTE          PIC S9(09) COMP.*/
        public IntBasis V1CLIEN_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1CLIEN-NOME-RAZAO           PIC  X(40).*/
        public StringBasis V1CLIEN_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0CONV-NUMPROPOSTA           PIC S9(15)V COMP-3.*/
        public DoubleBasis V0CONV_NUMPROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  V0CONV-NUMSICOB              PIC S9(15)V COMP-3.*/
        public DoubleBasis V0CONV_NUMSICOB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  V0CONV-CODPRODU              PIC S9(04)  COMP.*/
        public IntBasis V0CONV_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         PROD-COD-EMPRESA     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PROD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         PARM-COD-EMPR-CAP    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PARM_COD_EMPR_CAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-PLANO                PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-SERIE                PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-TITULO               PIC S9(9)      USAGE COMP.*/
        public IntBasis LK_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01     LK-NUM-PROPOSTA         PIC S9(15)V    USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01     LK-QTD-TITULOS          PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-VLR-TITULO           PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"01     LK-PARCEIRO             PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-RAMO                 PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-COD-USUARIO          PIC  X(8).*/
        public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01     LK-NUM-NSA              PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-TRACE                PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88   LK-TRACE-ON             VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88   LK-TRACE-OFF            VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*"01     LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01     LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01     LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01           AREA-DE-WORK.*/
        public BI0071B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0071B_AREA_DE_WORK();
        public class BI0071B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-RENOVACAO         PIC X(003)     VALUE SPACES.*/
            public StringBasis WS_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WHOST-SIT-REGISTRO   PIC X(001)     VALUE SPACES.*/
            public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-FDRCAP          PIC X(001)     VALUE SPACES.*/
            public StringBasis WFIM_FDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-FDRCAP          PIC X(001)     VALUE SPACES.*/
            public StringBasis WTEM_FDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV1SISTEMA        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV1BILHETE        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV1BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV1APOLCOBR       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV1APOLCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0PARAM-CONTACEF PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0PARAM_CONTACEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0MOVDEBCC-CEF   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0MOVDEBCC_CEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-MARSH             PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_MARSH { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-GRAVA             PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WS_GRAVA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-TIT-CAP           PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WS_TIT_CAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-ERR-TIT-CAP       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WS_ERR_TIT_CAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WPAG                 PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WPAG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WLIN                 PIC  9(009)    VALUE 90.*/
            public IntBasis WLIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 90);
            /*"  05         WTOTPARAMC           PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTPARAMC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTMOVDE            PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTMOVDE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTREG              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WTOTREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WTOTGER              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WTOTGER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WTOTDEB              PIC  9(016)V99 VALUE ZEROS.*/
            public DoubleBasis WTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "16", "9(016)V99"), 2);
            /*"  05         WCOD-CONVENIO        PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis WCOD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WDATSIS              PIC  9(008)    VALUE ZEROS.*/
            public IntBasis WDATSIS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WNSAS                PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WNSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-RESTO             PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-RESULT            PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-SQLCODE           PIC  ----9.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
            /*"  05         WS-TIMESTAMP-CANCEL  PIC  X(26).*/
            public StringBasis WS_TIMESTAMP_CANCEL { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
            /*"  05         FILLER        REDEFINES    WS-TIMESTAMP-CANCEL.*/
            private _REDEF_BI0071B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_BI0071B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_BI0071B_FILLER_2(); _.Move(WS_TIMESTAMP_CANCEL, _filler_2); VarBasis.RedefinePassValue(WS_TIMESTAMP_CANCEL, _filler_2, WS_TIMESTAMP_CANCEL); _filler_2.ValueChanged += () => { _.Move(_filler_2, WS_TIMESTAMP_CANCEL); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WS_TIMESTAMP_CANCEL); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_2 : VarBasis
            {
                /*"     10      WS-DATA-CANCEL       PIC  X(10).*/
                public StringBasis WS_DATA_CANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10      WS-SPACE-CANCEL      PIC  X(01).*/
                public StringBasis WS_SPACE_CANCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10      WS-TIME-CANCEL       PIC  X(15).*/
                public StringBasis WS_TIME_CANCEL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"  05         WIDTCLIBAN           PIC   X(020).*/

                public _REDEF_BI0071B_FILLER_2()
                {
                    WS_DATA_CANCEL.ValueChanged += OnValueChanged;
                    WS_SPACE_CANCEL.ValueChanged += OnValueChanged;
                    WS_TIME_CANCEL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WIDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05         FILLER        REDEFINES    WIDTCLIBAN.*/
            private _REDEF_BI0071B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_BI0071B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_BI0071B_FILLER_3(); _.Move(WIDTCLIBAN, _filler_3); VarBasis.RedefinePassValue(WIDTCLIBAN, _filler_3, WIDTCLIBAN); _filler_3.ValueChanged += () => { _.Move(_filler_3, WIDTCLIBAN); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WIDTCLIBAN); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_3 : VarBasis
            {
                /*"     10      WCOD-AGENCIA         PIC   9(004).*/
                public IntBasis WCOD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      WNUM-CONTA           PIC   9(011).*/
                public IntBasis WNUM_CONTA { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"     10      WDIG-CONTA           PIC   9(001).*/
                public IntBasis WDIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"     10      WIDT-SPACES          PIC   X(004).*/
                public StringBasis WIDT_SPACES { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05         WS-PROPOSTA       PIC  9(014)    VALUE ZEROS.*/

                public _REDEF_BI0071B_FILLER_3()
                {
                    WCOD_AGENCIA.ValueChanged += OnValueChanged;
                    WNUM_CONTA.ValueChanged += OnValueChanged;
                    WDIG_CONTA.ValueChanged += OnValueChanged;
                    WIDT_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WS-PROPOSTA.*/
            private _REDEF_BI0071B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI0071B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI0071B_FILLER_4(); _.Move(WS_PROPOSTA, _filler_4); VarBasis.RedefinePassValue(WS_PROPOSTA, _filler_4, WS_PROPOSTA); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_PROPOSTA); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WS_PROPOSTA); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_4 : VarBasis
            {
                /*"    10       WNUMPROP          PIC  9(013).*/
                public IntBasis WNUMPROP { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       FILLER            PIC  9(001).*/
                public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05         WS-IDTCLIEMP      PIC  X(044)    VALUE SPACES.*/

                public _REDEF_BI0071B_FILLER_4()
                {
                    WNUMPROP.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"");
            /*"  05         FILLER            REDEFINES      WS-IDTCLIEMP.*/
            private _REDEF_BI0071B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_BI0071B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_BI0071B_FILLER_6(); _.Move(WS_IDTCLIEMP, _filler_6); VarBasis.RedefinePassValue(WS_IDTCLIEMP, _filler_6, WS_IDTCLIEMP); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_IDTCLIEMP); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WS_IDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_6 : VarBasis
            {
                /*"    10       FILLER            PIC  X(023).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    10       WNUMPROPOS        PIC  9(013).*/
                public IntBasis WNUMPROPOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WNRENDOS          PIC  9(004).*/
                public IntBasis WNRENDOS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(004).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05         WS-IDTAUTENT      PIC  X(023)    VALUE SPACES.*/

                public _REDEF_BI0071B_FILLER_6()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                    WNUMPROPOS.ValueChanged += OnValueChanged;
                    WNRENDOS.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_IDTAUTENT { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
            /*"  05         FILLER            REDEFINES      WS-IDTAUTENT.*/
            private _REDEF_BI0071B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_BI0071B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_BI0071B_FILLER_9(); _.Move(WS_IDTAUTENT, _filler_9); VarBasis.RedefinePassValue(WS_IDTAUTENT, _filler_9, WS_IDTAUTENT); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS_IDTAUTENT); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS_IDTAUTENT); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_9 : VarBasis
            {
                /*"    10       WNUMCARTAO        PIC  9(016).*/
                public IntBasis WNUMCARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10       WCODRETORNO       PIC  X(002).*/
                public StringBasis WCODRETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       FILLER            PIC  X(005).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI0071B_FILLER_9()
                {
                    WNUMCARTAO.ValueChanged += OnValueChanged;
                    WCODRETORNO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_BI0071B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_BI0071B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_BI0071B_FILLER_11(); _.Move(WDATA_CURR, _filler_11); VarBasis.RedefinePassValue(WDATA_CURR, _filler_11, WDATA_CURR); _filler_11.ValueChanged += () => { _.Move(_filler_11, WDATA_CURR); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_11 : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WHORA-CURR.*/

                public _REDEF_BI0071B_FILLER_11()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_12.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public BI0071B_WHORA_CURR WHORA_CURR { get; set; } = new BI0071B_WHORA_CURR();
            public class BI0071B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public BI0071B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI0071B_WDATA_CABEC();
            public class BI0071B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public BI0071B_WHORA_CABEC WHORA_CABEC { get; set; } = new BI0071B_WHORA_CABEC();
            public class BI0071B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WUSOEMPRESA          PIC  X(060).*/
            }
            public StringBasis WUSOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"  05         FILLER        REDEFINES   WUSOEMPRESA.*/
            private _REDEF_BI0071B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_BI0071B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_BI0071B_FILLER_18(); _.Move(WUSOEMPRESA, _filler_18); VarBasis.RedefinePassValue(WUSOEMPRESA, _filler_18, WUSOEMPRESA); _filler_18.ValueChanged += () => { _.Move(_filler_18, WUSOEMPRESA); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, WUSOEMPRESA); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_18 : VarBasis
            {
                /*"     10      WUSO-CONVENIO        PIC   9(006).*/
                public IntBasis WUSO_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-NSAS            PIC   9(006).*/
                public IntBasis WUSO_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-SEQFITA         PIC   9(006).*/
                public IntBasis WUSO_SEQFITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-SPACES          PIC   X(042).*/
                public StringBasis WUSO_SPACES { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
                /*"  05         WDATA-DEBITO         PIC   X(010).*/

                public _REDEF_BI0071B_FILLER_18()
                {
                    WUSO_CONVENIO.ValueChanged += OnValueChanged;
                    WUSO_NSAS.ValueChanged += OnValueChanged;
                    WUSO_SEQFITA.ValueChanged += OnValueChanged;
                    WUSO_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_DEBITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         WDATA-SQL            PIC   X(010).*/
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FILLER        REDEFINES   WDATA-SQL.*/
            private _REDEF_BI0071B_FILLER_19 _filler_19 { get; set; }
            public _REDEF_BI0071B_FILLER_19 FILLER_19
            {
                get { _filler_19 = new _REDEF_BI0071B_FILLER_19(); _.Move(WDATA_SQL, _filler_19); VarBasis.RedefinePassValue(WDATA_SQL, _filler_19, WDATA_SQL); _filler_19.ValueChanged += () => { _.Move(_filler_19, WDATA_SQL); }; return _filler_19; }
                set { VarBasis.RedefinePassValue(value, _filler_19, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_19 : VarBasis
            {
                /*"     10      WANO-SQL             PIC   9(004).*/
                public IntBasis WANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      FILLER               PIC   X(001).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10      WMES-SQL             PIC   9(002).*/
                public IntBasis WMES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      FILLER               PIC   X(001).*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10      WDIA-SQL             PIC   9(002).*/
                public IntBasis WDIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATATRA             PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_BI0071B_FILLER_19()
                {
                    WANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_20.ValueChanged += OnValueChanged;
                    WMES_SQL.ValueChanged += OnValueChanged;
                    FILLER_21.ValueChanged += OnValueChanged;
                    WDIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATATRA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER        REDEFINES   WDATATRA.*/
            private _REDEF_BI0071B_FILLER_22 _filler_22 { get; set; }
            public _REDEF_BI0071B_FILLER_22 FILLER_22
            {
                get { _filler_22 = new _REDEF_BI0071B_FILLER_22(); _.Move(WDATATRA, _filler_22); VarBasis.RedefinePassValue(WDATATRA, _filler_22, WDATATRA); _filler_22.ValueChanged += () => { _.Move(_filler_22, WDATATRA); }; return _filler_22; }
                set { VarBasis.RedefinePassValue(value, _filler_22, WDATATRA); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_22 : VarBasis
            {
                /*"     10      WANO-TRA            PIC   9(004).*/
                public IntBasis WANO_TRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      WMES-TRA            PIC   9(002).*/
                public IntBasis WMES_TRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      WDIA-TRA            PIC   9(002).*/
                public IntBasis WDIA_TRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-DISPLAY        PIC   X(010).*/

                public _REDEF_BI0071B_FILLER_22()
                {
                    WANO_TRA.ValueChanged += OnValueChanged;
                    WMES_TRA.ValueChanged += OnValueChanged;
                    WDIA_TRA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_DISPLAY { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         LPARM.*/
            public BI0071B_LPARM LPARM { get; set; } = new BI0071B_LPARM();
            public class BI0071B_LPARM : VarBasis
            {
                /*"    10       DATA1.*/
                public BI0071B_DATA1 DATA1 { get; set; } = new BI0071B_DATA1();
                public class BI0071B_DATA1 : VarBasis
                {
                    /*"      15     DATA1-DD          PIC  9(002).*/
                    public IntBasis DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA1-MM          PIC  9(002).*/
                    public IntBasis DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA1-AA          PIC  9(004).*/
                    public IntBasis DATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       RESPOSTA          PIC  X(001).*/
                }
                public StringBasis RESPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         LPARM2.*/
            }
            public BI0071B_LPARM2 LPARM2 { get; set; } = new BI0071B_LPARM2();
            public class BI0071B_LPARM2 : VarBasis
            {
                /*"    10       DATA2             PIC  9(008).*/
                public IntBasis DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       DATA2-R           REDEFINES             DATA2.*/
                private _REDEF_BI0071B_DATA2_R _data2_r { get; set; }
                public _REDEF_BI0071B_DATA2_R DATA2_R
                {
                    get { _data2_r = new _REDEF_BI0071B_DATA2_R(); _.Move(DATA2, _data2_r); VarBasis.RedefinePassValue(DATA2, _data2_r, DATA2); _data2_r.ValueChanged += () => { _.Move(_data2_r, DATA2); }; return _data2_r; }
                    set { VarBasis.RedefinePassValue(value, _data2_r, DATA2); }
                }  //Redefines
                public class _REDEF_BI0071B_DATA2_R : VarBasis
                {
                    /*"      15     DATA2-DD          PIC  X(002).*/
                    public StringBasis DATA2_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA2-MM          PIC  X(002).*/
                    public StringBasis DATA2_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA2-AA          PIC  X(004).*/
                    public StringBasis DATA2_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"    10       QUANTIDA          PIC S9(005)  COMP-3  VALUE +1.*/

                    public _REDEF_BI0071B_DATA2_R()
                    {
                        DATA2_DD.ValueChanged += OnValueChanged;
                        DATA2_MM.ValueChanged += OnValueChanged;
                        DATA2_AA.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis QUANTIDA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
                /*"    10       DATA3             PIC  9(008).*/
                public IntBasis DATA3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       DATA3-R           REDEFINES             DATA3.*/
                private _REDEF_BI0071B_DATA3_R _data3_r { get; set; }
                public _REDEF_BI0071B_DATA3_R DATA3_R
                {
                    get { _data3_r = new _REDEF_BI0071B_DATA3_R(); _.Move(DATA3, _data3_r); VarBasis.RedefinePassValue(DATA3, _data3_r, DATA3); _data3_r.ValueChanged += () => { _.Move(_data3_r, DATA3); }; return _data3_r; }
                    set { VarBasis.RedefinePassValue(value, _data3_r, DATA3); }
                }  //Redefines
                public class _REDEF_BI0071B_DATA3_R : VarBasis
                {
                    /*"      15     DATA3-DD          PIC  X(002).*/
                    public StringBasis DATA3_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA3-MM          PIC  X(002).*/
                    public StringBasis DATA3_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA3-AA          PIC  X(004).*/
                    public StringBasis DATA3_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"  05            LC01.*/

                    public _REDEF_BI0071B_DATA3_R()
                    {
                        DATA3_DD.ValueChanged += OnValueChanged;
                        DATA3_MM.ValueChanged += OnValueChanged;
                        DATA3_AA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public BI0071B_LC01 LC01 { get; set; } = new BI0071B_LC01();
            public class BI0071B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(007) VALUE 'BI0071B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"BI0071B");
                /*"    10          FILLER          PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public BI0071B_LC02 LC02 { get; set; } = new BI0071B_LC02();
            public class BI0071B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public BI0071B_LC03 LC03 { get; set; } = new BI0071B_LC03();
            public class BI0071B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(025) VALUE  SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10          FILLER          PIC  X(053) VALUE               'RELACAO DE DOCUMENTOS ENVIADOS PELA FITA DE DEBIT               'O - '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"RELACAO DE DOCUMENTOS ENVIADOS PELA FITA DE DEBIT               ");
                /*"    10          FILLER          PIC  X(018) VALUE 'SYSTEM-CRED'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"SYSTEM-CRED");
                /*"    10          FILLER          PIC  X(003) VALUE 'EM'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"EM");
                /*"    10          LC03-DATA       PIC  X(010).*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public BI0071B_LC04 LC04 { get; set; } = new BI0071B_LC04();
            public class BI0071B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC05.*/
            }
            public BI0071B_LC05 LC05 { get; set; } = new BI0071B_LC05();
            public class BI0071B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048)  VALUE      '          APOLICE    ENDOSSO PARC DT.VENC. DIA'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"          APOLICE    ENDOSSO PARC DT.VENC. DIA");
                /*"    10          FILLER          PIC  X(026)  VALUE      '-- C/C DEBITADA --'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"-- C/C DEBITADA --");
                /*"    10          FILLER          PIC  X(050)  VALUE      'NOME DO SEGURADO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NOME DO SEGURADO");
                /*"    10          FILLER          PIC  X(005)  VALUE      'VALOR'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"  05            LC06.*/
            }
            public BI0071B_LC06 LC06 { get; set; } = new BI0071B_LC06();
            public class BI0071B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE    'FITA  NR.: '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"FITA  NR.: ");
                /*"    10          LC06-NRFITA     PIC  ZZZZZZZZZ9.*/
                public IntBasis LC06_NRFITA { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZZZZ9."));
                /*"  05            LC07.*/
            }
            public BI0071B_LC07 LC07 { get; set; } = new BI0071B_LC07();
            public class BI0071B_LC07 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL ' '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LD01.*/
            }
            public BI0071B_LD01 LD01 { get; set; } = new BI0071B_LD01();
            public class BI0071B_LD01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10          LD01-NUMBIL     PIC  9(013).*/
                public IntBasis LD01_NUMBIL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NRENDOS    PIC  9(009).*/
                public IntBasis LD01_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NRPARCEL   PIC  9(002).*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DTVENCTO   PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DIA-DEBITO PIC  9(002).*/
                public IntBasis LD01_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-DEBITO.*/
                public BI0071B_LD01_DEBITO LD01_DEBITO { get; set; } = new BI0071B_LD01_DEBITO();
                public class BI0071B_LD01_DEBITO : VarBasis
                {
                    /*"      15        LD01-AGENCIA    PIC  9(004).*/
                    public IntBasis LD01_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15        FILLER          PIC  X(001) VALUE SPACES.*/
                    public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15        LD01-OPERACAO   PIC  9(004).*/
                    public IntBasis LD01_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15        LD01-BARRA      PIC  X(001).*/
                    public StringBasis LD01_BARRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15        LD01-CONTA      PIC  9(012).*/
                    public IntBasis LD01_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"      15        LD01-HIFEN1     PIC  X(001).*/
                    public StringBasis LD01_HIFEN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15        LD01-DIGITO     PIC  9(001).*/
                    public IntBasis LD01_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                }
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NOME       PIC  X(040).*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-VLDEBITO   PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLDEBITO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"  05            LD02.*/
            }
            public BI0071B_LD02 LD02 { get; set; } = new BI0071B_LD02();
            public class BI0071B_LD02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE ALL '*'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"ALL");
                /*"  05            LD03.*/
            }
            public BI0071B_LD03 LD03 { get; set; } = new BI0071B_LD03();
            public class BI0071B_LD03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*  NAO HOUVE MOVIMENTO NESTA DATA  *'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*  NAO HOUVE MOVIMENTO NESTA DATA  *");
                /*"  05            LD04.*/
            }
            public BI0071B_LD04 LD04 { get; set; } = new BI0071B_LD04();
            public class BI0071B_LD04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*                                  *'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*                                  *");
                /*"  05            LT01.*/
            }
            public BI0071B_LT01 LT01 { get; set; } = new BI0071B_LT01();
            public class BI0071B_LT01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(074) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"");
                /*"    10          FILLER          PIC  X(026) VALUE 'TOTAIS'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"TOTAIS");
                /*"    10          LT01-QT-TOTAL   PIC  ZZZZ.ZZ9.*/
                public IntBasis LT01_QT_TOTAL { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LT01-VL-TOTAL   PIC  ZZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05        WABEND.*/
            }
            public BI0071B_WABEND WABEND { get; set; } = new BI0071B_WABEND();
            public class BI0071B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' BI0071B'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0071B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  05        WPARAGRAFO          PIC  X(040)    VALUE SPACES.*/
            }
            public StringBasis WPARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"01          LK-CONSISTE-CONTA.*/
        }
        public BI0071B_LK_CONSISTE_CONTA LK_CONSISTE_CONTA { get; set; } = new BI0071B_LK_CONSISTE_CONTA();
        public class BI0071B_LK_CONSISTE_CONTA : VarBasis
        {
            /*"  03  WS-CTA-ERRO               PIC  X(001)  VALUE SPACES.*/
            public StringBasis WS_CTA_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WPARM15-AUX               PIC S9(009)  VALUE ZEROS COMP.*/
            public IntBasis WPARM15_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WQUOCIENTE                PIC S9(004)  VALUE ZEROS COMP.*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WRESTO                    PIC S9(004)  VALUE ZEROS COMP.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-DIGCONTA               PIC  9(001)  VALUE ZEROS.*/
            public IntBasis WS_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        WS-NUMERO           PIC  9(015)  VALUE   ZEROS.*/
            public IntBasis WS_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  03        FILLER              REDEFINES    WS-NUMERO.*/
            private _REDEF_BI0071B_FILLER_63 _filler_63 { get; set; }
            public _REDEF_BI0071B_FILLER_63 FILLER_63
            {
                get { _filler_63 = new _REDEF_BI0071B_FILLER_63(); _.Move(WS_NUMERO, _filler_63); VarBasis.RedefinePassValue(WS_NUMERO, _filler_63, WS_NUMERO); _filler_63.ValueChanged += () => { _.Move(_filler_63, WS_NUMERO); }; return _filler_63; }
                set { VarBasis.RedefinePassValue(value, _filler_63, WS_NUMERO); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_63 : VarBasis
            {
                /*"    10      WS-AGENCIA          PIC  9(004).*/
                public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-OPERACAO         PIC  9(003).*/
                public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      WS-NUMCONTA         PIC  9(008).*/
                public IntBasis WS_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03        LPARM15X.*/

                public _REDEF_BI0071B_FILLER_63()
                {
                    WS_AGENCIA.ValueChanged += OnValueChanged;
                    WS_OPERACAO.ValueChanged += OnValueChanged;
                    WS_NUMCONTA.ValueChanged += OnValueChanged;
                }

            }
            public BI0071B_LPARM15X LPARM15X { get; set; } = new BI0071B_LPARM15X();
            public class BI0071B_LPARM15X : VarBasis
            {
                /*"    10      LPARM15             PIC  9(015).*/
                public IntBasis LPARM15 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10      FILLER              REDEFINES   LPARM15.*/
                private _REDEF_BI0071B_FILLER_64 _filler_64 { get; set; }
                public _REDEF_BI0071B_FILLER_64 FILLER_64
                {
                    get { _filler_64 = new _REDEF_BI0071B_FILLER_64(); _.Move(LPARM15, _filler_64); VarBasis.RedefinePassValue(LPARM15, _filler_64, LPARM15); _filler_64.ValueChanged += () => { _.Move(_filler_64, LPARM15); }; return _filler_64; }
                    set { VarBasis.RedefinePassValue(value, _filler_64, LPARM15); }
                }  //Redefines
                public class _REDEF_BI0071B_FILLER_64 : VarBasis
                {
                    /*"      15    LPARM15-1           PIC  9(001).*/
                    public IntBasis LPARM15_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-2           PIC  9(001).*/
                    public IntBasis LPARM15_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-3           PIC  9(001).*/
                    public IntBasis LPARM15_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-4           PIC  9(001).*/
                    public IntBasis LPARM15_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-5           PIC  9(001).*/
                    public IntBasis LPARM15_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-6           PIC  9(001).*/
                    public IntBasis LPARM15_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-7           PIC  9(001).*/
                    public IntBasis LPARM15_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-8           PIC  9(001).*/
                    public IntBasis LPARM15_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-9           PIC  9(001).*/
                    public IntBasis LPARM15_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-10          PIC  9(001).*/
                    public IntBasis LPARM15_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-11          PIC  9(001).*/
                    public IntBasis LPARM15_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-12          PIC  9(001).*/
                    public IntBasis LPARM15_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-13          PIC  9(001).*/
                    public IntBasis LPARM15_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-14          PIC  9(001).*/
                    public IntBasis LPARM15_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-15          PIC  9(001).*/
                    public IntBasis LPARM15_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    10      LPARM15-D1          PIC  9(001).*/

                    public _REDEF_BI0071B_FILLER_64()
                    {
                        LPARM15_1.ValueChanged += OnValueChanged;
                        LPARM15_2.ValueChanged += OnValueChanged;
                        LPARM15_3.ValueChanged += OnValueChanged;
                        LPARM15_4.ValueChanged += OnValueChanged;
                        LPARM15_5.ValueChanged += OnValueChanged;
                        LPARM15_6.ValueChanged += OnValueChanged;
                        LPARM15_7.ValueChanged += OnValueChanged;
                        LPARM15_8.ValueChanged += OnValueChanged;
                        LPARM15_9.ValueChanged += OnValueChanged;
                        LPARM15_10.ValueChanged += OnValueChanged;
                        LPARM15_11.ValueChanged += OnValueChanged;
                        LPARM15_12.ValueChanged += OnValueChanged;
                        LPARM15_13.ValueChanged += OnValueChanged;
                        LPARM15_14.ValueChanged += OnValueChanged;
                        LPARM15_15.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LPARM15_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05            WDATA-SQL1           PIC   X(010).*/
            }
            public StringBasis WDATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05            FILLER               REDEFINES        WDATA-SQL1*/
            private _REDEF_BI0071B_FILLER_65 _filler_65 { get; set; }
            public _REDEF_BI0071B_FILLER_65 FILLER_65
            {
                get { _filler_65 = new _REDEF_BI0071B_FILLER_65(); _.Move(WDATA_SQL1, _filler_65); VarBasis.RedefinePassValue(WDATA_SQL1, _filler_65, WDATA_SQL1); _filler_65.ValueChanged += () => { _.Move(_filler_65, WDATA_SQL1); }; return _filler_65; }
                set { VarBasis.RedefinePassValue(value, _filler_65, WDATA_SQL1); }
            }  //Redefines
            public class _REDEF_BI0071B_FILLER_65 : VarBasis
            {
                /*"     10         WANO-SQL1            PIC   9(004).*/
                public IntBasis WANO_SQL1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10         FILLER               PIC   X(001).*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10         WMES-SQL1            PIC   9(002).*/
                public IntBasis WMES_SQL1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10         FILLER               PIC   X(001).*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10         WDIA-SQL1            PIC   9(002).*/
                public IntBasis WDIA_SQL1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01            AUX-DETALHE.*/

                public _REDEF_BI0071B_FILLER_65()
                {
                    WANO_SQL1.ValueChanged += OnValueChanged;
                    FILLER_66.ValueChanged += OnValueChanged;
                    WMES_SQL1.ValueChanged += OnValueChanged;
                    FILLER_67.ValueChanged += OnValueChanged;
                    WDIA_SQL1.ValueChanged += OnValueChanged;
                }

            }
        }
        public BI0071B_AUX_DETALHE AUX_DETALHE { get; set; } = new BI0071B_AUX_DETALHE();
        public class BI0071B_AUX_DETALHE : VarBasis
        {
            /*"  03          LD99.*/
            public BI0071B_LD99 LD99 { get; set; } = new BI0071B_LD99();
            public class BI0071B_LD99 : VarBasis
            {
                /*"    10        LD99-CONVENIO       PIC  9(008).*/
                public IntBasis LD99_CONVENIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-NSAS           PIC  9(007).*/
                public IntBasis LD99_NSAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-FONTE          PIC  9(004).*/
                public IntBasis LD99_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-RAMO           PIC  9(004).*/
                public IntBasis LD99_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-PRODUTO        PIC  9(004).*/
                public IntBasis LD99_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-PROPOSTA       PIC  9(014).*/
                public IntBasis LD99_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-BILHETE        PIC  9(013).*/
                public IntBasis LD99_BILHETE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-APOLICE        PIC  9(013).*/
                public IntBasis LD99_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-ENDOSSO        PIC  9(009).*/
                public IntBasis LD99_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-PARCELA        PIC  9(004).*/
                public IntBasis LD99_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-BANCO          PIC  9(004).*/
                public IntBasis LD99_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-AGENCIA        PIC  9(005).*/
                public IntBasis LD99_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-OPECONTA       PIC  9(004).*/
                public IntBasis LD99_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-CONTA          PIC  9(012).*/
                public IntBasis LD99_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-DIGCONTA       PIC  9(001).*/
                public IntBasis LD99_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-CARTAO         PIC  9(016).*/
                public IntBasis LD99_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-DTVENCTO       PIC  X(010).*/
                public StringBasis LD99_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-VALOR          PIC  9(010)V99.*/
                public DoubleBasis LD99_VALOR { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-NRSEQ          PIC  9(009).*/
                public IntBasis LD99_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-CLIENTE        PIC  9(009).*/
                public IntBasis LD99_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-OCOREND        PIC  9(004).*/
                public IntBasis LD99_OCOREND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        LD99-SITUACAO       PIC  X(001).*/
                public StringBasis LD99_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(001).*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"01  LK-NUM-PLANO                   PIC S9(004)  USAGE COMP.*/
            }
        }
        public IntBasis LK_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-COD-RAMO                    PIC S9(004)  USAGE COMP.*/
        public IntBasis LK_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-PLANO                   PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-SERIE                   PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-TITULO                  PIC S9(009)            COMP.*/
        public IntBasis WF_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WF-COD-STA-TITULO              PIC  X(003).*/
        public StringBasis WF_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WF-COD-SUB-STATUS              PIC  X(003).*/
        public StringBasis WF_COD_SUB_STATUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WF-DTH-ATIVACAO                PIC  X(026).*/
        public StringBasis WF_DTH_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WF-DTH-CADUCACAO               PIC  X(010).*/
        public StringBasis WF_DTH_CADUCACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-CRIACAO                 PIC  X(026).*/
        public StringBasis WF_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WF-DTH-FIM-VIGENCIA            PIC  X(010).*/
        public StringBasis WF_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-INI-SORTEIO             PIC  X(010).*/
        public StringBasis WF_DTH_INI_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-INI-VIGENCIA            PIC  X(010).*/
        public StringBasis WF_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-SUSPENSAO               PIC  X(010).*/
        public StringBasis WF_DTH_SUSPENSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-IND-DV                      PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-VLR-MENSALIDADE             PIC S9(008)V9(2) USAGE COMP-3*/
        public DoubleBasis WF_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
        /*"01  WF-NUM-PROPOSTA                PIC S9(015)V     USAGE COMP-3*/
        public DoubleBasis WF_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"01  WF-NUM-MOD-PLANO               PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-DES-COMBINACAO              PIC  X(020).*/
        public StringBasis WF_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WL-LOCATOR     USAGE SQL TYPE IS RESULT-SET-LOCATOR VARYING.*/
        public IntBasis WL_LOCATOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-EOF-RESULT                  PIC  9(001) VALUE ZEROS.*/
        public IntBasis WS_EOF_RESULT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01          LK-LINK.*/
        public BI0071B_LK_LINK LK_LINK { get; set; } = new BI0071B_LK_LINK();
        public class BI0071B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO1          PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO1 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01           GE0006S-LINKAGE.*/
        }
        public BI0071B_GE0006S_LINKAGE GE0006S_LINKAGE { get; set; } = new BI0071B_GE0006S_LINKAGE();
        public class BI0071B_GE0006S_LINKAGE : VarBasis
        {
            /*"  05         GE0006S-DATA-DESTINO    PIC  X(010).*/
            public StringBasis GE0006S_DATA_DESTINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         GE0006S-QTDDIAS         PIC  9(004).*/
            public IntBasis GE0006S_QTDDIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0006S-MENSAGEM        PIC  X(070).*/
            public StringBasis GE0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }


        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public Dclgens.APOLCOBR APOLCOBR { get; set; } = new Dclgens.APOLCOBR();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public BI0071B_V0PARAMC V0PARAMC { get; set; } = new BI0071B_V0PARAMC();
        public BI0071B_V0MOVDE V0MOVDE { get; set; } = new BI0071B_V0MOVDE();
        public BI0071B_C01_RESULT C01_RESULT { get; set; } = new BI0071B_C01_RESULT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVDEBITO_CC_FILE_NAME_P, string RBI0071B_FILE_NAME_P, string BI0071B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVDEBITO_CC.SetFile(MOVDEBITO_CC_FILE_NAME_P);
                RBI0071B.SetFile(RBI0071B_FILE_NAME_P);
                BI0071B1.SetFile(BI0071B1_FILE_NAME_P);

                /*" -961- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -964- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -967- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -970- DISPLAY '-------------------------------' . */
                _.Display($"-------------------------------");

                /*" -971- DISPLAY 'PROGRAMA EM EXECUCAO BI0071B   ' . */
                _.Display($"PROGRAMA EM EXECUCAO BI0071B   ");

                /*" -972- DISPLAY '                               ' . */
                _.Display($"                               ");

                /*" -980- DISPLAY '--------------------INICIO --> ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"--------------------INICIO --> {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -983- DISPLAY 'VERSAO V.29: ' FUNCTION WHEN-COMPILED ' - 564320 ' */

                $"VERSAO V.29: FUNCTION{_.WhenCompiled()} - 564320 "
                .Display();

                /*" -984- ACCEPT WHORA-CURR FROM TIME. */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -985- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

                /*" -986- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

                /*" -987- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

                /*" -987- MOVE WHORA-CABEC TO LC03-HORA. */
                _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

                /*" -987- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -996- ACCEPT WDATSIS FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WDATSIS);

            /*" -998- OPEN OUTPUT MOVDEBITO-CC RBI0071B */
            MOVDEBITO_CC.Open(HEADER_REGISTRO);
            RBI0071B.Open(REG_BI0071B);

            /*" -1000- OPEN OUTPUT BI0071B1. */
            BI0071B1.Open(REG_BI0071B1);

            /*" -1001- PERFORM R0010-00-SELECT-V1SISTEMA */

            R0010_00_SELECT_V1SISTEMA_SECTION();

            /*" -1002- IF WFIMV1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIMV1SISTEMA.IsEmpty())
            {

                /*" -1004- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1006- PERFORM R0015-00-MONTA-V1EMPRESA */

            R0015_00_MONTA_V1EMPRESA_SECTION();

            /*" -1008- PERFORM R0020-00-DECLARE-V0PARAM-CONTA */

            R0020_00_DECLARE_V0PARAM_CONTA_SECTION();

            /*" -1009- PERFORM R0060-00-LE-V0PARAM-CONTACEF */

            R0060_00_LE_V0PARAM_CONTACEF_SECTION();

            /*" -1010- IF WFIMV0PARAM-CONTACEF EQUAL 'S' */

            if (AREA_DE_WORK.WFIMV0PARAM_CONTACEF == "S")
            {

                /*" -1012- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1015- PERFORM R0050-00-PROCE-V0PARAM-CONTA UNTIL WFIMV0PARAM-CONTACEF EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIMV0PARAM_CONTACEF == "S"))
            {

                R0050_00_PROCE_V0PARAM_CONTA_SECTION();
            }

            /*" -1016- IF WTOTMOVDE GREATER ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE > 00)
            {

                /*" -1017- PERFORM R0080-00-REGISTRO-TRAILLER */

                R0080_00_REGISTRO_TRAILLER_SECTION();

                /*" -1017- PERFORM R0170-00-TOTALIZADOR. */

                R0170_00_TOTALIZADOR_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1022- IF WTOTMOVDE GREATER ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE > 00)
            {

                /*" -1024- DISPLAY '*** BI0071B *** DATA GERACAO DA FITA   ' WDATSIS */
                _.Display($"*** BI0071B *** DATA GERACAO DA FITA   {AREA_DE_WORK.WDATSIS}");

                /*" -1026- DISPLAY '*** BI0071B *** QUANTIDADE             ' WTOTREG */
                _.Display($"*** BI0071B *** QUANTIDADE             {AREA_DE_WORK.WTOTREG}");

                /*" -1028- DISPLAY '*** BI0071B *** VALOR TOTAL            ' WTOTDEB */
                _.Display($"*** BI0071B *** VALOR TOTAL            {AREA_DE_WORK.WTOTDEB}");

                /*" -1030- DISPLAY '*** BI0071B *** NSA                    ' WNSAS */
                _.Display($"*** BI0071B *** NSA                    {AREA_DE_WORK.WNSAS}");

                /*" -1032- DISPLAY '*** BI0071B *** INTEGRACAO SAP/BACKSEG ' WS-GRAVA */
                _.Display($"*** BI0071B *** INTEGRACAO SAP/BACKSEG {AREA_DE_WORK.WS_GRAVA}");

                /*" -1034- DISPLAY '*** BI0071B *** QTD TITULOS COMPRADOS  ' WS-TIT-CAP */
                _.Display($"*** BI0071B *** QTD TITULOS COMPRADOS  {AREA_DE_WORK.WS_TIT_CAP}");

                /*" -1036- DISPLAY '*** BI0071B *** ERRO TITULOS COMPRADOS ' WS-ERR-TIT-CAP */
                _.Display($"*** BI0071B *** ERRO TITULOS COMPRADOS {AREA_DE_WORK.WS_ERR_TIT_CAP}");

                /*" -1037- DISPLAY ' ' */
                _.Display($" ");

                /*" -1038- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1039- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -1040- DISPLAY '* BI0071B - TERMINO NORMAL DE       *' */
                _.Display($"* BI0071B - TERMINO NORMAL DE       *");

                /*" -1041- DISPLAY '*             PROCESSAMENTO         *' */
                _.Display($"*             PROCESSAMENTO         *");

                /*" -1042- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -1043- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1044- ELSE */
            }
            else
            {


                /*" -1045- PERFORM R0160-00-CABECALHOS */

                R0160_00_CABECALHOS_SECTION();

                /*" -1046- PERFORM R0180-00-RELAT-SEM-MOVTO */

                R0180_00_RELAT_SEM_MOVTO_SECTION();

                /*" -1047- DISPLAY '******************************' */
                _.Display($"******************************");

                /*" -1048- DISPLAY '* BI0071B - SEM MOVIMENTACAO *' */
                _.Display($"* BI0071B - SEM MOVIMENTACAO *");

                /*" -1050- DISPLAY '******************************' . */
                _.Display($"******************************");
            }


            /*" -1052- CLOSE MOVDEBITO-CC */
            MOVDEBITO_CC.Close();

            /*" -1054- CLOSE RBI0071B BI0071B1. */
            RBI0071B.Close();
            BI0071B1.Close();

            /*" -1054- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1057- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1057- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-SECTION */
        private void R0010_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1067- MOVE 'R0010-00-SELECT-V1SISTEMA' TO WPARAGRAFO */
            _.Move("R0010-00-SELECT-V1SISTEMA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1070- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1081- PERFORM R0010_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0010_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1085- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1086- DISPLAY 'BI0071B - SISTEMA (EM) NAO CADASTRADO' */
                    _.Display($"BI0071B - SISTEMA (EM) NAO CADASTRADO");

                    /*" -1087- MOVE 'S' TO WFIMV1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIMV1SISTEMA);

                    /*" -1088- ELSE */
                }
                else
                {


                    /*" -1089- DISPLAY 'BI0071B - ' WPARAGRAFO */
                    _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1091- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1092- MOVE V1SISTE-DTMOVABE TO WDATA-SQL1. */
            _.Move(V1SISTE_DTMOVABE, LK_CONSISTE_CONTA.WDATA_SQL1);

            /*" -1093- MOVE 05 TO GE0006S-QTDDIAS. */
            _.Move(05, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -1094- PERFORM R0030-00-VALIDA-DATA. */

            R0030_00_VALIDA_DATA_SECTION();

            /*" -1096- MOVE WDATA-SQL1 TO WDATA-BASE-05. */
            _.Move(LK_CONSISTE_CONTA.WDATA_SQL1, WDATA_BASE_05);

            /*" -1097- MOVE V1SISTE-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -1098- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1099- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1100- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1102- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -1103- MOVE SPACES TO WS-TIMESTAMP-CANCEL */
            _.Move("", AREA_DE_WORK.WS_TIMESTAMP_CANCEL);

            /*" -1104- MOVE V1SISTE-DTCURRENT TO WS-DATA-CANCEL. */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.FILLER_2.WS_DATA_CANCEL);

            /*" -1105- MOVE SPACES TO WS-SPACE-CANCEL. */
            _.Move("", AREA_DE_WORK.FILLER_2.WS_SPACE_CANCEL);

            /*" -1107- MOVE '01:02:03.456789' TO WS-TIME-CANCEL. */
            _.Move("01:02:03.456789", AREA_DE_WORK.FILLER_2.WS_TIME_CANCEL);

            /*" -1108- DISPLAY 'TIMESTAMP CANCELAMENTO BACKSEG/SAP ' WS-TIMESTAMP-CANCEL. */
            _.Display($"TIMESTAMP CANCELAMENTO BACKSEG/SAP {AREA_DE_WORK.WS_TIMESTAMP_CANCEL}");

        }

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0010_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1081- EXEC SQL SELECT DTMOVABE, CURRENT DATE, DTMOVABE + 10 DAYS, DTMOVABE - 30 DAYS INTO :V1SISTE-DTMOVABE, :V1SISTE-DTCURRENT, :V1SISTE-DTMOVABE-10, :V1SISTE-DTMOVABE-30 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTE_DTMOVABE, V1SISTE_DTMOVABE);
                _.Move(executed_1.V1SISTE_DTCURRENT, V1SISTE_DTCURRENT);
                _.Move(executed_1.V1SISTE_DTMOVABE_10, V1SISTE_DTMOVABE_10);
                _.Move(executed_1.V1SISTE_DTMOVABE_30, V1SISTE_DTMOVABE_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0013-00-SELECT-TIMESTAMP-SECTION */
        private void R0013_00_SELECT_TIMESTAMP_SECTION()
        {
            /*" -1118- MOVE 'R0013-00-SELECT-TIMESTAMP' TO WPARAGRAFO */
            _.Move("R0013-00-SELECT-TIMESTAMP", AREA_DE_WORK.WPARAGRAFO);

            /*" -1120- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1126- PERFORM R0013_00_SELECT_TIMESTAMP_DB_SELECT_1 */

            R0013_00_SELECT_TIMESTAMP_DB_SELECT_1();

            /*" -1129- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1130- DISPLAY 'BI0071B - ' WPARAGRAFO */
                _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1131- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1131- END-IF. */
            }


        }

        [StopWatch]
        /*" R0013-00-SELECT-TIMESTAMP-DB-SELECT-1 */
        public void R0013_00_SELECT_TIMESTAMP_DB_SELECT_1()
        {
            /*" -1126- EXEC SQL SELECT CURRENT_TIMESTAMP INTO :V1SISTE-TSCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' WITH UR END-EXEC. */

            var r0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1 = new R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1.Execute(r0013_00_SELECT_TIMESTAMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTE_TSCURRENT, V1SISTE_TSCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0013_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-MONTA-V1EMPRESA-SECTION */
        private void R0015_00_MONTA_V1EMPRESA_SECTION()
        {
            /*" -1140- MOVE 'R0015-00-MONTA-V1EMPRESA' TO WPARAGRAFO */
            _.Move("R0015-00-MONTA-V1EMPRESA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1143- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1147- PERFORM R0015_00_MONTA_V1EMPRESA_DB_SELECT_1 */

            R0015_00_MONTA_V1EMPRESA_DB_SELECT_1();

            /*" -1150- MOVE V1EMPR-NOM-EMP TO LK-TITULO1 */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO1);

            /*" -1152- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -1153- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -1154- MOVE LK-TITULO1 TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO1, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -1155- ELSE */
            }
            else
            {


                /*" -1156- DISPLAY 'PROBLEMA CALL V0EMPRESA' */
                _.Display($"PROBLEMA CALL V0EMPRESA");

                /*" -1156- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0015-00-MONTA-V1EMPRESA-DB-SELECT-1 */
        public void R0015_00_MONTA_V1EMPRESA_DB_SELECT_1()
        {
            /*" -1147- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V0EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1 = new R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1.Execute(r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-VALIDA-DATA-SECTION */
        private void R0030_00_VALIDA_DATA_SECTION()
        {
            /*" -1166- MOVE 'R0030-00-VALIDA-DATA    ' TO WPARAGRAFO */
            _.Move("R0030-00-VALIDA-DATA    ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1169- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1170- MOVE WDATA-SQL1 TO GE0006S-DATA-DESTINO. */
            _.Move(LK_CONSISTE_CONTA.WDATA_SQL1, GE0006S_LINKAGE.GE0006S_DATA_DESTINO);

            /*" -1172- MOVE SPACES TO GE0006S-MENSAGEM. */
            _.Move("", GE0006S_LINKAGE.GE0006S_MENSAGEM);

            /*" -1174- CALL 'GE0006S' USING GE0006S-LINKAGE. */
            _.Call("GE0006S", GE0006S_LINKAGE);

            /*" -1175- IF GE0006S-MENSAGEM EQUAL SPACES */

            if (GE0006S_LINKAGE.GE0006S_MENSAGEM.IsEmpty())
            {

                /*" -1176- MOVE GE0006S-DATA-DESTINO TO WDATA-SQL1 */
                _.Move(GE0006S_LINKAGE.GE0006S_DATA_DESTINO, LK_CONSISTE_CONTA.WDATA_SQL1);

                /*" -1177- ELSE */
            }
            else
            {


                /*" -1178- DISPLAY 'PROBLEMA NA ROTINA GE0006S' */
                _.Display($"PROBLEMA NA ROTINA GE0006S");

                /*" -1179- DISPLAY 'MENSAGEM -->' GE0006S-MENSAGEM */
                _.Display($"MENSAGEM -->{GE0006S_LINKAGE.GE0006S_MENSAGEM}");

                /*" -1180- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1180- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-SECTION */
        private void R0020_00_DECLARE_V0PARAM_CONTA_SECTION()
        {
            /*" -1190- MOVE 'R0020-00-DECLARE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0020-00-DECLARE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1193- MOVE '020' TO WNR-EXEC-SQL */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1194- MOVE 01 TO V0PARAMC-TIPO-MOVTOCC */
            _.Move(01, V0PARAMC_TIPO_MOVTOCC);

            /*" -1196- MOVE 'A' TO V0PARAMC-SITUACAO */
            _.Move("A", V0PARAMC_SITUACAO);

            /*" -1212- PERFORM R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1 */

            R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1();

            /*" -1214- PERFORM R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1 */

            R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1();

            /*" -1217- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1218- DISPLAY 'BI0071B - ' WPARAGRAFO */
                _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1219- DISPLAY 'PROBLEMAS DECLARE V0PARAM_CONTACEF' */
                _.Display($"PROBLEMAS DECLARE V0PARAM_CONTACEF");

                /*" -1219- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-DB-DECLARE-1 */
        public void R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1()
        {
            /*" -1212- EXEC SQL DECLARE V0PARAMC CURSOR FOR SELECT TIPO_MOVTOCC, CODPRODU, COD_CONVENIO, NSAS, COD_AGENCIA_SASS, DTPROX_DEB, DIA_DEBITO FROM SEGUROS.V0PARAM_CONTACEF WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC AND SITUACAO = :V0PARAMC-SITUACAO AND COD_CONVENIO = 102837 AND CODPRODU IN (8114 , :JVPRD8114) ORDER BY COD_CONVENIO END-EXEC. */
            V0PARAMC = new BI0071B_V0PARAMC(true);
            string GetQuery_V0PARAMC()
            {
                var query = @$"SELECT TIPO_MOVTOCC
							, 
							CODPRODU
							, 
							COD_CONVENIO
							, 
							NSAS
							, 
							COD_AGENCIA_SASS
							, 
							DTPROX_DEB
							, 
							DIA_DEBITO 
							FROM SEGUROS.V0PARAM_CONTACEF 
							WHERE TIPO_MOVTOCC = '{V0PARAMC_TIPO_MOVTOCC}' 
							AND SITUACAO = '{V0PARAMC_SITUACAO}' 
							AND COD_CONVENIO = 102837 
							AND CODPRODU IN (8114
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8114}') 
							ORDER BY COD_CONVENIO";

                return query;
            }
            V0PARAMC.GetQueryEvent += GetQuery_V0PARAMC;

        }

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-DB-OPEN-1 */
        public void R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1()
        {
            /*" -1214- EXEC SQL OPEN V0PARAMC END-EXEC. */

            V0PARAMC.Open();

        }

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-DB-DECLARE-1 */
        public void R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1()
        {
            /*" -1354- EXEC SQL DECLARE V0MOVDE CURSOR FOR SELECT COD_CONVENIO, COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, DTVENCTO, DTVENCTO + 5 DAYS, VLR_DEBITO, NUM_APOLICE, NRENDOS, NRPARCEL, DIA_DEBITO, SIT_COBRANCA, COD_RETORNO_CEF, DAYS(DTVENCTO) - DAYS(CURRENT DATE), NSAS, COD_USUARIO FROM SEGUROS.V0MOVDEBCC_CEF WHERE SIT_COBRANCA IN ( '0' , ' ' ) AND COD_CONVENIO = :V0PARAMC-COD-CONVENIO UNION SELECT COD_CONVENIO, COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, DTVENCTO, DTVENCTO + 5 DAYS, VLR_DEBITO, NUM_APOLICE, NRENDOS, NRPARCEL, DIA_DEBITO, SIT_COBRANCA, COD_RETORNO_CEF, DAYS(DTVENCTO) - DAYS(CURRENT DATE), NSAS, COD_USUARIO FROM SEGUROS.V0MOVDEBCC_CEF WHERE SIT_COBRANCA = 'A' AND COD_CONVENIO IN (6114,102837) ORDER BY COD_CONVENIO, DTVENCTO , NUM_APOLICE END-EXEC. */
            V0MOVDE = new BI0071B_V0MOVDE(true);
            string GetQuery_V0MOVDE()
            {
                var query = @$"SELECT 
							COD_CONVENIO
							, 
							COD_AGENCIA_DEB
							, 
							OPER_CONTA_DEB
							, 
							NUM_CONTA_DEB
							, 
							DIG_CONTA_DEB
							, 
							DTVENCTO
							, 
							DTVENCTO + 5 DAYS
							, 
							VLR_DEBITO
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							DIA_DEBITO
							, 
							SIT_COBRANCA
							, 
							COD_RETORNO_CEF
							, 
							DAYS(DTVENCTO) - DAYS(CURRENT DATE)
							, 
							NSAS
							, 
							COD_USUARIO 
							FROM SEGUROS.V0MOVDEBCC_CEF 
							WHERE SIT_COBRANCA IN ( '0'
							, ' ' ) 
							AND COD_CONVENIO = '{V0PARAMC_COD_CONVENIO}' 
							UNION 
							SELECT 
							COD_CONVENIO
							, 
							COD_AGENCIA_DEB
							, 
							OPER_CONTA_DEB
							, 
							NUM_CONTA_DEB
							, 
							DIG_CONTA_DEB
							, 
							DTVENCTO
							, 
							DTVENCTO + 5 DAYS
							, 
							VLR_DEBITO
							, 
							NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							DIA_DEBITO
							, 
							SIT_COBRANCA
							, 
							COD_RETORNO_CEF
							, 
							DAYS(DTVENCTO) - DAYS(CURRENT DATE)
							, 
							NSAS
							, 
							COD_USUARIO 
							FROM SEGUROS.V0MOVDEBCC_CEF 
							WHERE SIT_COBRANCA = 'A' 
							AND COD_CONVENIO IN (6114
							,102837) 
							ORDER BY COD_CONVENIO
							, 
							DTVENCTO
							, 
							NUM_APOLICE";

                return query;
            }
            V0MOVDE.GetQueryEvent += GetQuery_V0MOVDE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-PROCE-V0PARAM-CONTA-SECTION */
        private void R0050_00_PROCE_V0PARAM_CONTA_SECTION()
        {
            /*" -1229- DISPLAY 'GERACAO DO MOVTO DE DEBITO EM CONTA *****' */
            _.Display($"GERACAO DO MOVTO DE DEBITO EM CONTA *****");

            /*" -1231- DISPLAY 'DATA DO VENCIMENTO  = ' WDATA-BASE-05 */
            _.Display($"DATA DO VENCIMENTO  = {WDATA_BASE_05}");

            /*" -1233- MOVE V0PARAMC-DTPROX-DEB TO WDATA-DEBITO. */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_DEBITO);

            /*" -1234- PERFORM R0065-00-DECLARE-V0MOVDEBCC. */

            R0065_00_DECLARE_V0MOVDEBCC_SECTION();

            /*" -1235- PERFORM R0110-00-LE-V0MOVDEBCC-CEF. */

            R0110_00_LE_V0MOVDEBCC_CEF_SECTION();

            /*" -1238- PERFORM R0122-00-UPDATE-V0MOVDEBCC-CEF UNTIL WFIMV0MOVDEBCC-CEF EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIMV0MOVDEBCC_CEF == "S"))
            {

                R0122_00_UPDATE_V0MOVDEBCC_CEF_SECTION();
            }

            /*" -1239- PERFORM R0065-00-DECLARE-V0MOVDEBCC. */

            R0065_00_DECLARE_V0MOVDEBCC_SECTION();

            /*" -1240- PERFORM R0110-00-LE-V0MOVDEBCC-CEF. */

            R0110_00_LE_V0MOVDEBCC_CEF_SECTION();

            /*" -1243- PERFORM R0100-00-PROCESSA-V0MOVDEBCC UNTIL WFIMV0MOVDEBCC-CEF EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIMV0MOVDEBCC_CEF == "S"))
            {

                R0100_00_PROCESSA_V0MOVDEBCC_SECTION();
            }

            /*" -1245- PERFORM R0130-00-UPDATE-V0PARAM-CONTA. */

            R0130_00_UPDATE_V0PARAM_CONTA_SECTION();

            /*" -1245- PERFORM R0060-00-LE-V0PARAM-CONTACEF. */

            R0060_00_LE_V0PARAM_CONTACEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-SECTION */
        private void R0060_00_LE_V0PARAM_CONTACEF_SECTION()
        {
            /*" -1255- MOVE 'R0060-00-LE-V0PARAM-CONTA-CEF' TO WPARAGRAFO */
            _.Move("R0060-00-LE-V0PARAM-CONTA-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1258- MOVE '060' TO WNR-EXEC-SQL */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1266- PERFORM R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1 */

            R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1();

            /*" -1269- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1270- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1271- MOVE 'S' TO WFIMV0PARAM-CONTACEF */
                    _.Move("S", AREA_DE_WORK.WFIMV0PARAM_CONTACEF);

                    /*" -1271- PERFORM R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1 */

                    R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1();

                    /*" -1273- GO TO R0060-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/ //GOTO
                    return;

                    /*" -1274- ELSE */
                }
                else
                {


                    /*" -1275- DISPLAY 'BI0071B - ' WPARAGRAFO */
                    _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1277- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1278- IF WCOD-CONVENIO EQUAL ZEROS */

            if (AREA_DE_WORK.WCOD_CONVENIO == 00)
            {

                /*" -1279- MOVE V0PARAMC-DTPROX-DEB TO WDATA-DISPLAY */
                _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_DISPLAY);

                /*" -1281- MOVE V0PARAMC-COD-CONVENIO TO WCOD-CONVENIO. */
                _.Move(V0PARAMC_COD_CONVENIO, AREA_DE_WORK.WCOD_CONVENIO);
            }


            /*" -1282- MOVE V0PARAMC-DTPROX-DEB TO WDATA-SQL */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_SQL);

            /*" -1283- MOVE WDIA-SQL TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_19.WDIA_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1284- MOVE WMES-SQL TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_19.WMES_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1285- MOVE WANO-SQL TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_19.WANO_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1287- MOVE WDATA-CABEC TO LC03-DATA */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC03.LC03_DATA);

            /*" -1287- COMPUTE WTOTPARAMC = WTOTPARAMC + 1. */
            AREA_DE_WORK.WTOTPARAMC.Value = AREA_DE_WORK.WTOTPARAMC + 1;

        }

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-DB-FETCH-1 */
        public void R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1()
        {
            /*" -1266- EXEC SQL FETCH V0PARAMC INTO :V0PARAMC-TIPO-MOVTOCC, :V0PARAMC-CODPRODU, :V0PARAMC-COD-CONVENIO, :V0PARAMC-NSAS, :V0PARAMC-COD-AGENCIA-SASS, :V0PARAMC-DTPROX-DEB, :V0PARAMC-DIA-DEBITO END-EXEC. */

            if (V0PARAMC.Fetch())
            {
                _.Move(V0PARAMC.V0PARAMC_TIPO_MOVTOCC, V0PARAMC_TIPO_MOVTOCC);
                _.Move(V0PARAMC.V0PARAMC_CODPRODU, V0PARAMC_CODPRODU);
                _.Move(V0PARAMC.V0PARAMC_COD_CONVENIO, V0PARAMC_COD_CONVENIO);
                _.Move(V0PARAMC.V0PARAMC_NSAS, V0PARAMC_NSAS);
                _.Move(V0PARAMC.V0PARAMC_COD_AGENCIA_SASS, V0PARAMC_COD_AGENCIA_SASS);
                _.Move(V0PARAMC.V0PARAMC_DTPROX_DEB, V0PARAMC_DTPROX_DEB);
                _.Move(V0PARAMC.V0PARAMC_DIA_DEBITO, V0PARAMC_DIA_DEBITO);
            }

        }

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-DB-CLOSE-1 */
        public void R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1()
        {
            /*" -1271- EXEC SQL CLOSE V0PARAMC END-EXEC */

            V0PARAMC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-SECTION */
        private void R0065_00_DECLARE_V0MOVDEBCC_SECTION()
        {
            /*" -1297- MOVE 'R0065-00-DECLARE-V0MOVDEBCC' TO WPARAGRAFO */
            _.Move("R0065-00-DECLARE-V0MOVDEBCC", AREA_DE_WORK.WPARAGRAFO);

            /*" -1301- MOVE '065' TO WNR-EXEC-SQL */
            _.Move("065", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1303- MOVE 'N' TO WFIMV0MOVDEBCC-CEF */
            _.Move("N", AREA_DE_WORK.WFIMV0MOVDEBCC_CEF);

            /*" -1354- PERFORM R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1 */

            R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1();

            /*" -1356- PERFORM R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1 */

            R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1();

            /*" -1359- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1360- DISPLAY 'BI0071B - ' WPARAGRAFO */
                _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1361- DISPLAY 'PROBLEMAS OPEN V0MOVDEBCC_CEF ' */
                _.Display($"PROBLEMAS OPEN V0MOVDEBCC_CEF ");

                /*" -1361- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-DB-OPEN-1 */
        public void R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1()
        {
            /*" -1356- EXEC SQL OPEN V0MOVDE END-EXEC. */

            V0MOVDE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_99_SAIDA*/

        [StopWatch]
        /*" R0070-00-REGISTRO-HEADER-SECTION */
        private void R0070_00_REGISTRO_HEADER_SECTION()
        {
            /*" -1371- MOVE ALL SPACES TO HEADER-REGISTRO */
            _.MoveAll("", HEADER_REGISTRO);

            /*" -1372- MOVE 'A' TO HEADER-CODREGISTRO */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -1373- MOVE 1 TO HEADER-CODREMESSA */
            _.Move(1, HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -1374- MOVE 1028370056 TO HEADER-CODCONVENIO */
            _.Move(1028370056, HEADER_REGISTRO.HEADER_CODCONVENIO);

            /*" -1375- MOVE 'CIELO' TO HEADER-NOMEMPRESA */
            _.Move("CIELO", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -1376- MOVE 104 TO HEADER-CODBANCO */
            _.Move(104, HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -1377- MOVE 'CAIXA ECON. FEDERAL' TO HEADER-NOMBANCO */
            _.Move("CAIXA ECON. FEDERAL", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -1378- MOVE V1SISTE-DTCURRENT TO WDATA-SQL */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.WDATA_SQL);

            /*" -1379- MOVE WANO-SQL TO WANO-TRA */
            _.Move(AREA_DE_WORK.FILLER_19.WANO_SQL, AREA_DE_WORK.FILLER_22.WANO_TRA);

            /*" -1380- MOVE WMES-SQL TO WMES-TRA */
            _.Move(AREA_DE_WORK.FILLER_19.WMES_SQL, AREA_DE_WORK.FILLER_22.WMES_TRA);

            /*" -1381- MOVE WDIA-SQL TO WDIA-TRA */
            _.Move(AREA_DE_WORK.FILLER_19.WDIA_SQL, AREA_DE_WORK.FILLER_22.WDIA_TRA);

            /*" -1384- MOVE WDATATRA TO HEADER-DATGERACAO WDATSIS. */
            _.Move(AREA_DE_WORK.WDATATRA, HEADER_REGISTRO.HEADER_DATGERACAO, AREA_DE_WORK.WDATSIS);

            /*" -1385- IF WTOTMOVDE NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE != 00)
            {

                /*" -1387- ADD 1 TO V0PARAMC-NSAS. */
                V0PARAMC_NSAS.Value = V0PARAMC_NSAS + 1;
            }


            /*" -1389- MOVE V0PARAMC-NSAS TO HEADER-NSA WNSAS */
            _.Move(V0PARAMC_NSAS, HEADER_REGISTRO.HEADER_NSA, AREA_DE_WORK.WNSAS);

            /*" -1390- MOVE 04 TO HEADER-VERSAO */
            _.Move(04, HEADER_REGISTRO.HEADER_VERSAO);

            /*" -1391- MOVE 'C�DIGO DE BARRAS' TO HEADER-IDENTIFICA */
            _.Move("C�DIGO DE BARRAS", HEADER_REGISTRO.HEADER_IDENTIFICA);

            /*" -1393- MOVE ALL SPACES TO HEADER-FILLER */
            _.MoveAll("", HEADER_REGISTRO.HEADER_FILLER);

            /*" -1393- WRITE HEADER-REGISTRO. */
            MOVDEBITO_CC.Write(HEADER_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-REGISTRO-TRAILLER-SECTION */
        private void R0080_00_REGISTRO_TRAILLER_SECTION()
        {
            /*" -1403- MOVE 'R0080-00-REGISTRO-TRAILLER' TO WPARAGRAFO */
            _.Move("R0080-00-REGISTRO-TRAILLER", AREA_DE_WORK.WPARAGRAFO);

            /*" -1406- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1407- MOVE ALL SPACES TO TRAILL-REGISTRO */
            _.MoveAll("", TRAILL_REGISTRO);

            /*" -1408- MOVE 'Z' TO TRAILL-CODREGISTRO */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -1409- COMPUTE WTOTREG = WTOTREG + 2 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG + 2;

            /*" -1410- MOVE WTOTREG TO TRAILL-TOTREGISTRO */
            _.Move(AREA_DE_WORK.WTOTREG, TRAILL_REGISTRO.TRAILL_TOTREGISTRO);

            /*" -1411- MOVE WTOTDEB TO TRAILL-VLRTOTDEB */
            _.Move(AREA_DE_WORK.WTOTDEB, TRAILL_REGISTRO.TRAILL_VLRTOTDEB);

            /*" -1412- MOVE ALL SPACES TO TRAILL-FILLER */
            _.MoveAll("", TRAILL_REGISTRO.TRAILL_FILLER);

            /*" -1412- WRITE TRAILL-REGISTRO. */
            MOVDEBITO_CC.Write(TRAILL_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-PROCESSA-V0MOVDEBCC-SECTION */
        private void R0100_00_PROCESSA_V0MOVDEBCC_SECTION()
        {
            /*" -1423- IF V0MOVDE-SIT-COBRANCA NOT EQUAL 'A' */

            if (V0MOVDE_SIT_COBRANCA != "A")
            {

                /*" -1424- IF V0MOVDE-DTVENCTO LESS WDATA-BASE-05 */

                if (V0MOVDE_DTVENCTO < WDATA_BASE_05)
                {

                    /*" -1425- MOVE WDATA-BASE-05 TO V0MOVDE-DTVENCTO */
                    _.Move(WDATA_BASE_05, V0MOVDE_DTVENCTO);

                    /*" -1426- PERFORM R0118-00-UPDATE-V0MOVDEBCC-CEF */

                    R0118_00_UPDATE_V0MOVDEBCC_CEF_SECTION();

                    /*" -1428- END-IF. */
                }

            }


            /*" -1434- COMPUTE WTOTMOVDE = WTOTMOVDE + 1. */
            AREA_DE_WORK.WTOTMOVDE.Value = AREA_DE_WORK.WTOTMOVDE + 1;

            /*" -1435- IF WTOTMOVDE EQUAL 1 */

            if (AREA_DE_WORK.WTOTMOVDE == 1)
            {

                /*" -1438- PERFORM R0070-00-REGISTRO-HEADER. */

                R0070_00_REGISTRO_HEADER_SECTION();
            }


            /*" -1439- PERFORM R0120-00-REGISTRO-E. */

            R0120_00_REGISTRO_E_SECTION();

            /*" -1440- PERFORM R0125-00-RELATORIO. */

            R0125_00_RELATORIO_SECTION();

            /*" -1443- PERFORM R4150-00-SELECT-BILCOBER. */

            R4150_00_SELECT_BILCOBER_SECTION();

            /*" -1446- IF V0MOVDE-SIT-COBRANCA EQUAL 'A' AND V0MOVDE-COD-RETORNO-CEF EQUAL ZEROS AND VIND-COD-RETORNO NOT LESS ZEROS */

            if (V0MOVDE_SIT_COBRANCA == "A" && V0MOVDE_COD_RETORNO_CEF == 00 && VIND_COD_RETORNO >= 00)
            {

                /*" -1449- IF V0CONV-CODPRODU EQUAL 8124 OR 8132 NEXT SENTENCE */

                if (V0CONV_CODPRODU.In("8124", "8132"))
                {

                    /*" -1454- ELSE */
                }
                else
                {


                    /*" -1456- IF (V0MOVDE-NRENDOS EQUAL 13 OR 25 OR 37 OR 49) AND BILCOBER-VAL-MAX-COBER-BAS GREATER ZEROES */

                    if ((V0MOVDE_NRENDOS.In("13", "25", "37", "49")) && BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS > 00)
                    {

                        /*" -1457- DISPLAY 'BILHETE: ' V1BILH-NUMBIL */
                        _.Display($"BILHETE: {V1BILH_NUMBIL}");

                        /*" -1458- DISPLAY 'APOLICE: ' V0MOVDE-NUM-APOLICE */
                        _.Display($"APOLICE: {V0MOVDE_NUM_APOLICE}");

                        /*" -1459- DISPLAY 'ENDOSSO: ' V0MOVDE-NRENDOS */
                        _.Display($"ENDOSSO: {V0MOVDE_NRENDOS}");

                        /*" -1460- DISPLAY 'SITUACAO:' V0MOVDE-SIT-COBRANCA */
                        _.Display($"SITUACAO:{V0MOVDE_SIT_COBRANCA}");

                        /*" -1461- DISPLAY 'COD RETORNO: ' V0MOVDE-COD-RETORNO-CEF */
                        _.Display($"COD RETORNO: {V0MOVDE_COD_RETORNO_CEF}");

                        /*" -1462- DISPLAY 'IND COD_RET: ' VIND-COD-RETORNO */
                        _.Display($"IND COD_RET: {VIND_COD_RETORNO}");

                        /*" -1463- DISPLAY 'USUARIO:     ' V0MOVDE-COD-USUARIO */
                        _.Display($"USUARIO:     {V0MOVDE_COD_USUARIO}");

                        /*" -1464- DISPLAY 'APOLICE:     ' V0MOVDE-NUM-APOLICE */
                        _.Display($"APOLICE:     {V0MOVDE_NUM_APOLICE}");

                        /*" -1466- DISPLAY 'ENDOSSO:     ' V0MOVDE-NRENDOS */
                        _.Display($"ENDOSSO:     {V0MOVDE_NRENDOS}");

                        /*" -1469- PERFORM R4100-00-TRATA-FC0105S. */

                        R4100_00_TRATA_FC0105S_SECTION();
                    }

                }

            }


            /*" -1471- PERFORM R0140-00-UPDATE-V0MOVDEBCC-CEF. */

            R0140_00_UPDATE_V0MOVDEBCC_CEF_SECTION();

            /*" -1471- PERFORM R0110-00-LE-V0MOVDEBCC-CEF. */

            R0110_00_LE_V0MOVDEBCC_CEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-LE-V0MOVDEBCC-CEF-SECTION */
        private void R0110_00_LE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1481- MOVE 'R0110-00-LE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0110-00-LE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1481- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0110_10_LE_MOVDEBCC */

            R0110_10_LE_MOVDEBCC();

        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC */
        private void R0110_10_LE_MOVDEBCC(bool isPerform = false)
        {
            /*" -1505- PERFORM R0110_10_LE_MOVDEBCC_DB_FETCH_1 */

            R0110_10_LE_MOVDEBCC_DB_FETCH_1();

            /*" -1508- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1509- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1510- MOVE 'S' TO WFIMV0MOVDEBCC-CEF */
                    _.Move("S", AREA_DE_WORK.WFIMV0MOVDEBCC_CEF);

                    /*" -1510- PERFORM R0110_10_LE_MOVDEBCC_DB_CLOSE_1 */

                    R0110_10_LE_MOVDEBCC_DB_CLOSE_1();

                    /*" -1512- GO TO R0110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/ //GOTO
                    return;

                    /*" -1513- ELSE */
                }
                else
                {


                    /*" -1514- DISPLAY 'BI0071B - ' WPARAGRAFO */
                    _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1517- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1518- IF V0MOVDE-VLR-DEBITO IS NEGATIVE */

            if (V0MOVDE_VLR_DEBITO < 0)
            {

                /*" -1519- GO TO R0110-10-LE-MOVDEBCC */
                new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1521- END-IF. */
            }


            /*" -1522- IF V0MOVDE-SIT-COBRANCA NOT EQUAL 'A' */

            if (V0MOVDE_SIT_COBRANCA != "A")
            {

                /*" -1523- IF V0MOVDE-DTVENCTO GREATER WDATA-BASE-05 */

                if (V0MOVDE_DTVENCTO > WDATA_BASE_05)
                {

                    /*" -1524- GO TO R0110-10-LE-MOVDEBCC */
                    new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1525- ELSE */
                }
                else
                {


                    /*" -1526- IF V0MOVDE-DTVENCTO LESS V1SISTE-DTMOVABE-30 */

                    if (V0MOVDE_DTVENCTO < V1SISTE_DTMOVABE_30)
                    {

                        /*" -1527- GO TO R0110-10-LE-MOVDEBCC */
                        new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1528- END-IF */
                    }


                    /*" -1530- END-IF. */
                }

            }


            /*" -1531- MOVE V0MOVDE-NUM-APOLICE TO V1BILH-NUMAPOL. */
            _.Move(V0MOVDE_NUM_APOLICE, V1BILH_NUMAPOL);

            /*" -1532- MOVE '9' TO V1BILH-SITUACAO. */
            _.Move("9", V1BILH_SITUACAO);

            /*" -1534- MOVE 'N' TO WFIMV1BILHETE. */
            _.Move("N", AREA_DE_WORK.WFIMV1BILHETE);

            /*" -1536- IF V0MOVDE-SIT-COBRANCA EQUAL 'A' */

            if (V0MOVDE_SIT_COBRANCA == "A")
            {

                /*" -1537- PERFORM R0114-00-LE-V1BILHETE */

                R0114_00_LE_V1BILHETE_SECTION();

                /*" -1538- IF WFIMV1BILHETE EQUAL 'N' */

                if (AREA_DE_WORK.WFIMV1BILHETE == "N")
                {

                    /*" -1539- GO TO R0110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/ //GOTO
                    return;

                    /*" -1540- END-IF */
                }


                /*" -1542- END-IF. */
            }


            /*" -1543- PERFORM R0115-00-LE-V1BILHETE */

            R0115_00_LE_V1BILHETE_SECTION();

            /*" -1544- IF WFIMV1BILHETE EQUAL 'S' */

            if (AREA_DE_WORK.WFIMV1BILHETE == "S")
            {

                /*" -1545- GO TO R0110-10-LE-MOVDEBCC */
                new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1545- END-IF. */
            }


        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC-DB-FETCH-1 */
        public void R0110_10_LE_MOVDEBCC_DB_FETCH_1()
        {
            /*" -1505- EXEC SQL FETCH V0MOVDE INTO :V0MOVDE-COD-CONVENIO, :V0MOVDE-COD-AGENCIA-DEB, :V0MOVDE-OPER-CONTA-DEB, :V0MOVDE-NUM-CONTA-DEB, :V0MOVDE-DIG-CONTA-DEB, :V0MOVDE-DTVENCTO, :V0MOVDE-DTVENCTO-5, :V0MOVDE-VLR-DEBITO, :V0MOVDE-NUM-APOLICE, :V0MOVDE-NRENDOS, :V0MOVDE-NRPARCEL, :V0MOVDE-DIA-DEBITO, :V0MOVDE-SIT-COBRANCA, :V0MOVDE-COD-RETORNO-CEF :VIND-COD-RETORNO, :V0MOVDE-DAYS, :V0MOVDE-NSAS, :V0MOVDE-COD-USUARIO END-EXEC. */

            if (V0MOVDE.Fetch())
            {
                _.Move(V0MOVDE.V0MOVDE_COD_CONVENIO, V0MOVDE_COD_CONVENIO);
                _.Move(V0MOVDE.V0MOVDE_COD_AGENCIA_DEB, V0MOVDE_COD_AGENCIA_DEB);
                _.Move(V0MOVDE.V0MOVDE_OPER_CONTA_DEB, V0MOVDE_OPER_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_NUM_CONTA_DEB, V0MOVDE_NUM_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_DIG_CONTA_DEB, V0MOVDE_DIG_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_DTVENCTO, V0MOVDE_DTVENCTO);
                _.Move(V0MOVDE.V0MOVDE_DTVENCTO_5, V0MOVDE_DTVENCTO_5);
                _.Move(V0MOVDE.V0MOVDE_VLR_DEBITO, V0MOVDE_VLR_DEBITO);
                _.Move(V0MOVDE.V0MOVDE_NUM_APOLICE, V0MOVDE_NUM_APOLICE);
                _.Move(V0MOVDE.V0MOVDE_NRENDOS, V0MOVDE_NRENDOS);
                _.Move(V0MOVDE.V0MOVDE_NRPARCEL, V0MOVDE_NRPARCEL);
                _.Move(V0MOVDE.V0MOVDE_DIA_DEBITO, V0MOVDE_DIA_DEBITO);
                _.Move(V0MOVDE.V0MOVDE_SIT_COBRANCA, V0MOVDE_SIT_COBRANCA);
                _.Move(V0MOVDE.V0MOVDE_COD_RETORNO_CEF, V0MOVDE_COD_RETORNO_CEF);
                _.Move(V0MOVDE.VIND_COD_RETORNO, VIND_COD_RETORNO);
                _.Move(V0MOVDE.V0MOVDE_DAYS, V0MOVDE_DAYS);
                _.Move(V0MOVDE.V0MOVDE_NSAS, V0MOVDE_NSAS);
                _.Move(V0MOVDE.V0MOVDE_COD_USUARIO, V0MOVDE_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC-DB-CLOSE-1 */
        public void R0110_10_LE_MOVDEBCC_DB_CLOSE_1()
        {
            /*" -1510- EXEC SQL CLOSE V0MOVDE END-EXEC */

            V0MOVDE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0114-00-LE-V1BILHETE-SECTION */
        private void R0114_00_LE_V1BILHETE_SECTION()
        {
            /*" -1555- MOVE 'R0114-00-LE-V1BILHETE ' TO WPARAGRAFO */
            _.Move("R0114-00-LE-V1BILHETE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1558- MOVE '114' TO WNR-EXEC-SQL. */
            _.Move("114", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1560- MOVE V0MOVDE-NUM-APOLICE TO V1BILH-NUMBIL. */
            _.Move(V0MOVDE_NUM_APOLICE, V1BILH_NUMBIL);

            /*" -1575- PERFORM R0114_00_LE_V1BILHETE_DB_SELECT_1 */

            R0114_00_LE_V1BILHETE_DB_SELECT_1();

            /*" -1578- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1579- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1580- MOVE 'S' TO WFIMV1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIMV1BILHETE);

                    /*" -1581- ELSE */
                }
                else
                {


                    /*" -1582- DISPLAY 'BI0071B - ' WPARAGRAFO */
                    _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1583- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                    /*" -1583- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0114-00-LE-V1BILHETE-DB-SELECT-1 */
        public void R0114_00_LE_V1BILHETE_DB_SELECT_1()
        {
            /*" -1575- EXEC SQL SELECT NUMBIL, CODCLIEN, NUM_APOLICE, RAMO, OPC_COBERTURA INTO :V1BILH-NUMBIL, :V1BILH-COD-CLIENTE, :V1BILH-NUMAPOL, :V1BILH-RAMO, :V1BILH-OPCAO-COB FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V1BILH-NUMBIL OR NUM_APOLICE = :V1BILH-NUMBIL END-EXEC. */

            var r0114_00_LE_V1BILHETE_DB_SELECT_1_Query1 = new R0114_00_LE_V1BILHETE_DB_SELECT_1_Query1()
            {
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0114_00_LE_V1BILHETE_DB_SELECT_1_Query1.Execute(r0114_00_LE_V1BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILH_NUMBIL, V1BILH_NUMBIL);
                _.Move(executed_1.V1BILH_COD_CLIENTE, V1BILH_COD_CLIENTE);
                _.Move(executed_1.V1BILH_NUMAPOL, V1BILH_NUMAPOL);
                _.Move(executed_1.V1BILH_RAMO, V1BILH_RAMO);
                _.Move(executed_1.V1BILH_OPCAO_COB, V1BILH_OPCAO_COB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0114_99_SAIDA*/

        [StopWatch]
        /*" R0115-00-LE-V1BILHETE-SECTION */
        private void R0115_00_LE_V1BILHETE_SECTION()
        {
            /*" -1593- MOVE 'R0115-00-LE-V1BILHETE ' TO WPARAGRAFO */
            _.Move("R0115-00-LE-V1BILHETE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1596- MOVE '115' TO WNR-EXEC-SQL. */
            _.Move("115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1614- PERFORM R0115_00_LE_V1BILHETE_DB_SELECT_1 */

            R0115_00_LE_V1BILHETE_DB_SELECT_1();

            /*" -1617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1618- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1619- MOVE 'S' TO WFIMV1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIMV1BILHETE);

                    /*" -1620- ELSE */
                }
                else
                {


                    /*" -1621- DISPLAY 'BI0071B - ' WPARAGRAFO */
                    _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1622- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                    /*" -1622- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0115-00-LE-V1BILHETE-DB-SELECT-1 */
        public void R0115_00_LE_V1BILHETE_DB_SELECT_1()
        {
            /*" -1614- EXEC SQL SELECT NUMBIL, FONTE, CODCLIEN, OCORR_ENDERECO, SITUACAO, RAMO, OPC_COBERTURA INTO :V1BILH-NUMBIL, :V1BILH-FONTE, :V1BILH-COD-CLIENTE, :V1BILH-OCOREND, :V1BILH-SITUACAO, :V1BILH-RAMO, :V1BILH-OPCAO-COB FROM SEGUROS.V0BILHETE WHERE NUM_APOLICE = :V1BILH-NUMAPOL AND SITUACAO = :V1BILH-SITUACAO END-EXEC. */

            var r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 = new R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1()
            {
                V1BILH_SITUACAO = V1BILH_SITUACAO.ToString(),
                V1BILH_NUMAPOL = V1BILH_NUMAPOL.ToString(),
            };

            var executed_1 = R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1.Execute(r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILH_NUMBIL, V1BILH_NUMBIL);
                _.Move(executed_1.V1BILH_FONTE, V1BILH_FONTE);
                _.Move(executed_1.V1BILH_COD_CLIENTE, V1BILH_COD_CLIENTE);
                _.Move(executed_1.V1BILH_OCOREND, V1BILH_OCOREND);
                _.Move(executed_1.V1BILH_SITUACAO, V1BILH_SITUACAO);
                _.Move(executed_1.V1BILH_RAMO, V1BILH_RAMO);
                _.Move(executed_1.V1BILH_OPCAO_COB, V1BILH_OPCAO_COB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0115_99_SAIDA*/

        [StopWatch]
        /*" R0118-00-UPDATE-V0MOVDEBCC-CEF-SECTION */
        private void R0118_00_UPDATE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1632- MOVE 'R0118-00-UPDATE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0118-00-UPDATE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1635- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1644- PERFORM R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1 */

            R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1();

            /*" -1647- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1648- DISPLAY 'BI0071B - ' WPARAGRAFO */
                _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1649- DISPLAY 'V0MOVDE-NUM-APOLICE  ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE  {V0MOVDE_NUM_APOLICE}");

                /*" -1650- DISPLAY 'V0MOVDE-NRENDOS      ' V0MOVDE-NRENDOS */
                _.Display($"V0MOVDE-NRENDOS      {V0MOVDE_NRENDOS}");

                /*" -1651- DISPLAY 'V0MOVDE-NRPARCEL     ' V0MOVDE-NRPARCEL */
                _.Display($"V0MOVDE-NRPARCEL     {V0MOVDE_NRPARCEL}");

                /*" -1652- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                /*" -1653- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                /*" -1654- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1654- END-IF. */
            }


        }

        [StopWatch]
        /*" R0118-00-UPDATE-V0MOVDEBCC-CEF-DB-UPDATE-1 */
        public void R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1()
        {
            /*" -1644- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET DTVENCTO = :V0MOVDE-DTVENCTO WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND NRENDOS = :V0MOVDE-NRENDOS AND NRPARCEL = :V0MOVDE-NRPARCEL AND SIT_COBRANCA IN ( '0' , ' ' , 'A' ) AND COD_CONVENIO = :V0MOVDE-COD-CONVENIO END-EXEC. */

            var r0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 = new R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1()
            {
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V0MOVDE_COD_CONVENIO = V0MOVDE_COD_CONVENIO.ToString(),
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_NRPARCEL = V0MOVDE_NRPARCEL.ToString(),
                V0MOVDE_NRENDOS = V0MOVDE_NRENDOS.ToString(),
            };

            R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1.Execute(r0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0118_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-REGISTRO-E-SECTION */
        private void R0120_00_REGISTRO_E_SECTION()
        {
            /*" -1664- MOVE 'R0120-00-REGISTRO-E ' TO WPARAGRAFO */
            _.Move("R0120-00-REGISTRO-E ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1667- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1668- MOVE ALL SPACES TO MOVCC-REGISTRO. */
            _.MoveAll("", MOVCC_REGISTRO);

            /*" -1670- MOVE 'G' TO MOVCC-CODREGISTRO. */
            _.Move("G", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -1676- PERFORM R0121-00-LE-CONVERSI. */

            R0121_00_LE_CONVERSI_SECTION();

            /*" -1677- MOVE WNUMPROP TO MOVCC-NUM-PROPOSTA. */
            _.Move(AREA_DE_WORK.FILLER_4.WNUMPROP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NUM_PROPOSTA);

            /*" -1679- MOVE V0MOVDE-NRENDOS TO MOVCC-NUM-PARCELA. */
            _.Move(V0MOVDE_NRENDOS, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NUM_PARCELA);

            /*" -1680- IF MOVCC-NUM-PARCELA EQUAL ZEROS */

            if (MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NUM_PARCELA == 00)
            {

                /*" -1682- MOVE 1 TO MOVCC-NUM-PARCELA */
                _.Move(1, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NUM_PARCELA);

                /*" -1684- END-IF. */
            }


            /*" -1686- MOVE 0630 TO MOVCC-AGEDEBITO WCOD-AGENCIA. */
            _.Move(0630, MOVCC_REGISTRO.MOVCC_AGEDEBITO, AREA_DE_WORK.FILLER_3.WCOD_AGENCIA);

            /*" -1687- MOVE 00300001581 TO WNUM-CONTA. */
            _.Move(00300001581, AREA_DE_WORK.FILLER_3.WNUM_CONTA);

            /*" -1688- MOVE 4 TO WDIG-CONTA. */
            _.Move(4, AREA_DE_WORK.FILLER_3.WDIG_CONTA);

            /*" -1689- MOVE ALL SPACES TO WIDT-SPACES. */
            _.MoveAll("", AREA_DE_WORK.FILLER_3.WIDT_SPACES);

            /*" -1691- MOVE WIDTCLIBAN TO MOVCC-IDTCLIBAN. */
            _.Move(AREA_DE_WORK.WIDTCLIBAN, MOVCC_REGISTRO.MOVCC_IDTCLIBAN);

            /*" -1693- MOVE V0MOVDE-DTVENCTO TO WDATA-SQL. */
            _.Move(V0MOVDE_DTVENCTO, AREA_DE_WORK.WDATA_SQL);

            /*" -1694- MOVE WANO-SQL TO WANO-TRA. */
            _.Move(AREA_DE_WORK.FILLER_19.WANO_SQL, AREA_DE_WORK.FILLER_22.WANO_TRA);

            /*" -1695- MOVE WMES-SQL TO WMES-TRA. */
            _.Move(AREA_DE_WORK.FILLER_19.WMES_SQL, AREA_DE_WORK.FILLER_22.WMES_TRA);

            /*" -1696- MOVE WDIA-SQL TO WDIA-TRA. */
            _.Move(AREA_DE_WORK.FILLER_19.WDIA_SQL, AREA_DE_WORK.FILLER_22.WDIA_TRA);

            /*" -1698- MOVE WDATATRA TO MOVCC-DTPAGTO. */
            _.Move(AREA_DE_WORK.WDATATRA, MOVCC_REGISTRO.MOVCC_DTPAGTO);

            /*" -1700- IF V0MOVDE-OPER-CONTA-DEB EQUAL ZEROS OR V0MOVDE-COD-RETORNO-CEF GREATER ZEROS */

            if (V0MOVDE_OPER_CONTA_DEB == 00 || V0MOVDE_COD_RETORNO_CEF > 00)
            {

                /*" -1701- MOVE SPACES TO MOVCC-DTCREDITO */
                _.Move("", MOVCC_REGISTRO.MOVCC_DTCREDITO);

                /*" -1702- ELSE */
            }
            else
            {


                /*" -1703- MOVE V0MOVDE-DTVENCTO-5 TO WDATA-SQL */
                _.Move(V0MOVDE_DTVENCTO_5, AREA_DE_WORK.WDATA_SQL);

                /*" -1704- MOVE WANO-SQL TO WANO-TRA */
                _.Move(AREA_DE_WORK.FILLER_19.WANO_SQL, AREA_DE_WORK.FILLER_22.WANO_TRA);

                /*" -1705- MOVE WMES-SQL TO WMES-TRA */
                _.Move(AREA_DE_WORK.FILLER_19.WMES_SQL, AREA_DE_WORK.FILLER_22.WMES_TRA);

                /*" -1706- MOVE WDIA-SQL TO WDIA-TRA */
                _.Move(AREA_DE_WORK.FILLER_19.WDIA_SQL, AREA_DE_WORK.FILLER_22.WDIA_TRA);

                /*" -1707- MOVE WDATATRA TO MOVCC-DTCREDITO */
                _.Move(AREA_DE_WORK.WDATATRA, MOVCC_REGISTRO.MOVCC_DTCREDITO);

                /*" -1709- END-IF. */
            }


            /*" -1710- MOVE V0MOVDE-VLR-DEBITO TO MOVCC-VLRDEBITO. */
            _.Move(V0MOVDE_VLR_DEBITO, MOVCC_REGISTRO.MOVCC_VLRDEBITO);

            /*" -1712- MOVE ZEROS TO MOVCC-VLRTARIFA. */
            _.Move(0, MOVCC_REGISTRO.MOVCC_VLRTARIFA);

            /*" -1714- MOVE '1' TO MOVCC-TPCAPTURA. */
            _.Move("1", MOVCC_REGISTRO.MOVCC_TPCAPTURA);

            /*" -1715- MOVE SPACES TO MOVCC-CODAUTENT. */
            _.Move("", MOVCC_REGISTRO.MOVCC_CODAUTENT);

            /*" -1717- MOVE ALL SPACES TO WS-IDTAUTENT. */
            _.MoveAll("", AREA_DE_WORK.WS_IDTAUTENT);

            /*" -1721- MOVE 1 TO MOVCC-TPPAGTO. */
            _.Move(1, MOVCC_REGISTRO.MOVCC_TPPAGTO);

            /*" -1723- MOVE ALL SPACES TO MOVCC-FILLER. */
            _.MoveAll("", MOVCC_REGISTRO.MOVCC_FILLER);

            /*" -1728- MOVE ZEROS TO MOVCC-COD-BANCO MOVCC-AGENCIA-DEB MOVCC-OPERACAO-DEB MOVCC-NUMCTA-DEB MOVCC-DIGCTA-DEB-R. */
            _.Move(0, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_COD_BANCO, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_AGENCIA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_OPERACAO_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NUMCTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_DIGCTA_DEB_R);

            /*" -1730- PERFORM R0123-00-LE-APOLCOBR. */

            R0123_00_LE_APOLCOBR_SECTION();

            /*" -1731- IF WFIMV1APOLCOBR EQUAL 'N' */

            if (AREA_DE_WORK.WFIMV1APOLCOBR == "N")
            {

                /*" -1732- MOVE APOLCOBR-COD-AGENCIA TO MOVCC-COD-BANCO */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_COD_BANCO);

                /*" -1733- MOVE APOLCOBR-COD-AGENCIA-DEB TO MOVCC-AGENCIA-DEB */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_AGENCIA_DEB);

                /*" -1734- MOVE APOLCOBR-OPER-CONTA-DEB TO MOVCC-OPERACAO-DEB */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_OPERACAO_DEB);

                /*" -1735- MOVE APOLCOBR-NUM-CONTA-DEB TO MOVCC-NUMCTA-DEB */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NUMCTA_DEB);

                /*" -1736- MOVE APOLCOBR-DIG-CONTA-DEB TO MOVCC-DIGCTA-DEB-R */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_DIGCTA_DEB_R);

                /*" -1737- IF APOLCOBR-COD-AGENCIA EQUAL 1 */

                if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA == 1)
                {

                    /*" -1738- IF APOLCOBR-DIG-CONTA-DEB EQUAL 0 */

                    if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB == 0)
                    {

                        /*" -1739- MOVE 'X' TO MOVCC-DIGCTA-DEB */
                        _.Move("X", MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_DIGCTA_DEB);

                        /*" -1740- END-IF */
                    }


                    /*" -1741- END-IF */
                }


                /*" -1743- END-IF. */
            }


            /*" -1744- IF V0MOVDE-SIT-COBRANCA EQUAL 'A' */

            if (V0MOVDE_SIT_COBRANCA == "A")
            {

                /*" -1745- IF VIND-COD-RETORNO LESS ZEROS */

                if (VIND_COD_RETORNO < 00)
                {

                    /*" -1746- MOVE 95 TO MOVCC-CDRETORNO-R */
                    _.Move(95, MOVCC_REGISTRO.MOVCC_CODAUTENT_R.MOVCC_CDRETORNO_R);

                    /*" -1747- ELSE */
                }
                else
                {


                    /*" -1748- MOVE V0MOVDE-COD-RETORNO-CEF TO MOVCC-CDRETORNO-R */
                    _.Move(V0MOVDE_COD_RETORNO_CEF, MOVCC_REGISTRO.MOVCC_CODAUTENT_R.MOVCC_CDRETORNO_R);

                    /*" -1749- END-IF */
                }


                /*" -1750- ELSE */
            }
            else
            {


                /*" -1751- MOVE SPACES TO MOVCC-CDRETORNO */
                _.Move("", MOVCC_REGISTRO.MOVCC_CODAUTENT_R.MOVCC_CDRETORNO);

                /*" -1760- END-IF. */
            }


            /*" -1762- IF MOVCC-DTCREDITO EQUAL SPACES AND MOVCC-CDRETORNO EQUAL SPACES */

            if (MOVCC_REGISTRO.MOVCC_DTCREDITO.IsEmpty() && MOVCC_REGISTRO.MOVCC_CODAUTENT_R.MOVCC_CDRETORNO.IsEmpty())
            {

                /*" -1767- IF MOVCC-COD-BANCO EQUAL 001 OR 033 OR 237 OR 341 OR 399 */

                if (MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_COD_BANCO.In("001", "033", "237", "341", "399"))
                {

                    /*" -1770- GO TO R0120-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1771- COMPUTE WTOTREG = WTOTREG + 1. */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG + 1;

            /*" -1772- COMPUTE WTOTGER = WTOTGER + 1. */
            AREA_DE_WORK.WTOTGER.Value = AREA_DE_WORK.WTOTGER + 1;

            /*" -1774- COMPUTE WTOTDEB = WTOTDEB + V0MOVDE-VLR-DEBITO. */
            AREA_DE_WORK.WTOTDEB.Value = AREA_DE_WORK.WTOTDEB + V0MOVDE_VLR_DEBITO;

            /*" -1775- MOVE WTOTREG TO MOVCC-NSR. */
            _.Move(AREA_DE_WORK.WTOTREG, MOVCC_REGISTRO.MOVCC_NSR);

            /*" -1778- MOVE WTOTREG TO V0MOVDE-REQUISICAO. */
            _.Move(AREA_DE_WORK.WTOTREG, V0MOVDE_REQUISICAO);

            /*" -1778- WRITE MOVCC-REGISTRO. */
            MOVDEBITO_CC.Write(MOVCC_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0121-00-LE-CONVERSI-SECTION */
        private void R0121_00_LE_CONVERSI_SECTION()
        {
            /*" -1789- MOVE 'R0121-00-LE-CONVERSI  ' TO WPARAGRAFO */
            _.Move("R0121-00-LE-CONVERSI  ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1792- MOVE '121' TO WNR-EXEC-SQL. */
            _.Move("121", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1793- MOVE V1BILH-NUMBIL TO V0CONV-NUMSICOB. */
            _.Move(V1BILH_NUMBIL, V0CONV_NUMSICOB);

            /*" -1797- MOVE ZEROS TO V0CONV-NUMPROPOSTA V0CONV-CODPRODU WS-PROPOSTA. */
            _.Move(0, V0CONV_NUMPROPOSTA, V0CONV_CODPRODU, AREA_DE_WORK.WS_PROPOSTA);

            /*" -1805- PERFORM R0121_00_LE_CONVERSI_DB_SELECT_1 */

            R0121_00_LE_CONVERSI_DB_SELECT_1();

            /*" -1808- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1814- PERFORM R0121_00_LE_CONVERSI_DB_SELECT_2 */

                R0121_00_LE_CONVERSI_DB_SELECT_2();

                /*" -1816- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1822- PERFORM R0121_00_LE_CONVERSI_DB_SELECT_3 */

                    R0121_00_LE_CONVERSI_DB_SELECT_3();

                    /*" -1825- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1826- DISPLAY 'BI0071B - ' WPARAGRAFO */
                        _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                        /*" -1827- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                        _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                        /*" -1828- DISPLAY 'V0CONV-NUMSICOB     ' V0CONV-NUMSICOB */
                        _.Display($"V0CONV-NUMSICOB     {V0CONV_NUMSICOB}");

                        /*" -1830- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -1830- MOVE V0CONV-NUMPROPOSTA TO WS-PROPOSTA. */
            _.Move(V0CONV_NUMPROPOSTA, AREA_DE_WORK.WS_PROPOSTA);

        }

        [StopWatch]
        /*" R0121-00-LE-CONVERSI-DB-SELECT-1 */
        public void R0121_00_LE_CONVERSI_DB_SELECT_1()
        {
            /*" -1805- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, COD_PRODUTO_SIVPF INTO :V0CONV-NUMPROPOSTA, :V0CONV-CODPRODU FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V0CONV-NUMSICOB WITH UR END-EXEC. */

            var r0121_00_LE_CONVERSI_DB_SELECT_1_Query1 = new R0121_00_LE_CONVERSI_DB_SELECT_1_Query1()
            {
                V0CONV_NUMSICOB = V0CONV_NUMSICOB.ToString(),
            };

            var executed_1 = R0121_00_LE_CONVERSI_DB_SELECT_1_Query1.Execute(r0121_00_LE_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUMPROPOSTA, V0CONV_NUMPROPOSTA);
                _.Move(executed_1.V0CONV_CODPRODU, V0CONV_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0121_99_SAIDA*/

        [StopWatch]
        /*" R0121-00-LE-CONVERSI-DB-SELECT-2 */
        public void R0121_00_LE_CONVERSI_DB_SELECT_2()
        {
            /*" -1814- EXEC SQL SELECT COD_PRODUTO INTO :V0CONV-CODPRODU FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE WITH UR END-EXEC */

            var r0121_00_LE_CONVERSI_DB_SELECT_2_Query1 = new R0121_00_LE_CONVERSI_DB_SELECT_2_Query1()
            {
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0121_00_LE_CONVERSI_DB_SELECT_2_Query1.Execute(r0121_00_LE_CONVERSI_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODPRODU, V0CONV_CODPRODU);
            }


        }

        [StopWatch]
        /*" R0122-00-UPDATE-V0MOVDEBCC-CEF-SECTION */
        private void R0122_00_UPDATE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1840- MOVE 'R0122-00-UPDATE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0122-00-UPDATE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1845- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1847- IF V0MOVDE-COD-CONVENIO NOT EQUAL 6114 */

            if (V0MOVDE_COD_CONVENIO != 6114)
            {

                /*" -1856- PERFORM R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1 */

                R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1();

                /*" -1859- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1860- DISPLAY 'BI0071B - ' WPARAGRAFO */
                    _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1861- DISPLAY 'V0MOVDE-NUM-APOLICE  ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE  {V0MOVDE_NUM_APOLICE}");

                    /*" -1862- DISPLAY 'V0MOVDE-NRENDOS      ' V0MOVDE-NRENDOS */
                    _.Display($"V0MOVDE-NRENDOS      {V0MOVDE_NRENDOS}");

                    /*" -1863- DISPLAY 'V0MOVDE-NRPARCEL     ' V0MOVDE-NRPARCEL */
                    _.Display($"V0MOVDE-NRPARCEL     {V0MOVDE_NRPARCEL}");

                    /*" -1864- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                    _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                    /*" -1865- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                    _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                    /*" -1866- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1867- END-IF */
                }


                /*" -1869- END-IF. */
            }


            /*" -1869- PERFORM R0110-00-LE-V0MOVDEBCC-CEF. */

            R0110_00_LE_V0MOVDEBCC_CEF_SECTION();

        }

        [StopWatch]
        /*" R0122-00-UPDATE-V0MOVDEBCC-CEF-DB-UPDATE-1 */
        public void R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1()
        {
            /*" -1856- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET DTVENCTO = :V0MOVDE-DTVENCTO, SIT_COBRANCA = '0' WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND NRENDOS < :V0MOVDE-NRENDOS AND NRPARCEL = :V0MOVDE-NRPARCEL AND SIT_COBRANCA = '3' AND COD_CONVENIO = :V0MOVDE-COD-CONVENIO END-EXEC */

            var r0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 = new R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1()
            {
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V0MOVDE_COD_CONVENIO = V0MOVDE_COD_CONVENIO.ToString(),
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_NRPARCEL = V0MOVDE_NRPARCEL.ToString(),
                V0MOVDE_NRENDOS = V0MOVDE_NRENDOS.ToString(),
            };

            R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1.Execute(r0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0121-00-LE-CONVERSI-DB-SELECT-3 */
        public void R0121_00_LE_CONVERSI_DB_SELECT_3()
        {
            /*" -1822- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :V0CONV-NUMPROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V0CONV-NUMSICOB WITH UR END-EXEC. */

            var r0121_00_LE_CONVERSI_DB_SELECT_3_Query1 = new R0121_00_LE_CONVERSI_DB_SELECT_3_Query1()
            {
                V0CONV_NUMSICOB = V0CONV_NUMSICOB.ToString(),
            };

            var executed_1 = R0121_00_LE_CONVERSI_DB_SELECT_3_Query1.Execute(r0121_00_LE_CONVERSI_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_NUMPROPOSTA, V0CONV_NUMPROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0122_99_SAIDA*/

        [StopWatch]
        /*" R0123-00-LE-APOLCOBR-SECTION */
        private void R0123_00_LE_APOLCOBR_SECTION()
        {
            /*" -1879- MOVE 'R0123-00-LE-APOLCOBR  ' TO WPARAGRAFO */
            _.Move("R0123-00-LE-APOLCOBR  ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1882- MOVE '123' TO WNR-EXEC-SQL. */
            _.Move("123", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1884- MOVE 'N' TO WFIMV1APOLCOBR. */
            _.Move("N", AREA_DE_WORK.WFIMV1APOLCOBR);

            /*" -1902- PERFORM R0123_00_LE_APOLCOBR_DB_SELECT_1 */

            R0123_00_LE_APOLCOBR_DB_SELECT_1();

            /*" -1906- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1907- MOVE 'S' TO WFIMV1APOLCOBR */
                _.Move("S", AREA_DE_WORK.WFIMV1APOLCOBR);

                /*" -1915- MOVE ZEROS TO APOLCOBR-COD-AGENCIA APOLCOBR-COD-PRODUTO APOLCOBR-COD-AGENCIA-DEB APOLCOBR-OPER-CONTA-DEB APOLCOBR-NUM-CONTA-DEB APOLCOBR-DIG-CONTA-DEB APOLCOBR-NUM-CARTAO */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_PRODUTO, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO);

                /*" -1917- GO TO R0123-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0123_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1918- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1919- DISPLAY 'BI0071B - ' WPARAGRAFO */
                _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1920- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                /*" -1923- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1924- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1927- MOVE ZEROS TO APOLCOBR-COD-AGENCIA-DEB. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);
            }


            /*" -1928- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -1931- MOVE ZEROS TO APOLCOBR-OPER-CONTA-DEB. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);
            }


            /*" -1932- IF VIND-NULL03 LESS ZEROS */

            if (VIND_NULL03 < 00)
            {

                /*" -1935- MOVE ZEROS TO APOLCOBR-NUM-CONTA-DEB. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);
            }


            /*" -1936- IF VIND-NULL04 LESS ZEROS */

            if (VIND_NULL04 < 00)
            {

                /*" -1939- MOVE ZEROS TO APOLCOBR-DIG-CONTA-DEB. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);
            }


            /*" -1940- IF VIND-NULL05 LESS ZEROS */

            if (VIND_NULL05 < 00)
            {

                /*" -1941- MOVE ZEROS TO APOLCOBR-NUM-CARTAO. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO);
            }


        }

        [StopWatch]
        /*" R0123-00-LE-APOLCOBR-DB-SELECT-1 */
        public void R0123_00_LE_APOLCOBR_DB_SELECT_1()
        {
            /*" -1902- EXEC SQL SELECT COD_AGENCIA, COD_PRODUTO, COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, NUM_CARTAO INTO :APOLCOBR-COD-AGENCIA, :APOLCOBR-COD-PRODUTO, :APOLCOBR-COD-AGENCIA-DEB:VIND-NULL01, :APOLCOBR-OPER-CONTA-DEB:VIND-NULL02, :APOLCOBR-NUM-CONTA-DEB:VIND-NULL03, :APOLCOBR-DIG-CONTA-DEB:VIND-NULL04, :APOLCOBR-NUM-CARTAO:VIND-NULL05 FROM SEGUROS.APOLICE_COBRANCA WHERE NUM_APOLICE = :V1BILH-NUMAPOL FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r0123_00_LE_APOLCOBR_DB_SELECT_1_Query1 = new R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1()
            {
                V1BILH_NUMAPOL = V1BILH_NUMAPOL.ToString(),
            };

            var executed_1 = R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1.Execute(r0123_00_LE_APOLCOBR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOBR_COD_AGENCIA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA);
                _.Move(executed_1.APOLCOBR_COD_PRODUTO, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_PRODUTO);
                _.Move(executed_1.APOLCOBR_COD_AGENCIA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.APOLCOBR_OPER_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.APOLCOBR_NUM_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);
                _.Move(executed_1.VIND_NULL03, VIND_NULL03);
                _.Move(executed_1.APOLCOBR_DIG_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);
                _.Move(executed_1.VIND_NULL04, VIND_NULL04);
                _.Move(executed_1.APOLCOBR_NUM_CARTAO, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO);
                _.Move(executed_1.VIND_NULL05, VIND_NULL05);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0123_99_SAIDA*/

        [StopWatch]
        /*" R0125-00-RELATORIO-SECTION */
        private void R0125_00_RELATORIO_SECTION()
        {
            /*" -1952- MOVE 'R0125-00-RELATORIO ' TO WPARAGRAFO */
            _.Move("R0125-00-RELATORIO ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1955- MOVE '125' TO WNR-EXEC-SQL. */
            _.Move("125", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1957- PERFORM R0126-00-LE-V1CLIENTE */

            R0126_00_LE_V1CLIENTE_SECTION();

            /*" -1958- MOVE V0MOVDE-NUM-APOLICE TO LD01-NUMBIL */
            _.Move(V0MOVDE_NUM_APOLICE, AREA_DE_WORK.LD01.LD01_NUMBIL);

            /*" -1959- MOVE V0MOVDE-NRENDOS TO LD01-NRENDOS */
            _.Move(V0MOVDE_NRENDOS, AREA_DE_WORK.LD01.LD01_NRENDOS);

            /*" -1960- MOVE V0MOVDE-NRPARCEL TO LD01-NRPARCEL */
            _.Move(V0MOVDE_NRPARCEL, AREA_DE_WORK.LD01.LD01_NRPARCEL);

            /*" -1961- MOVE V0MOVDE-DTVENCTO TO WDATA-SQL */
            _.Move(V0MOVDE_DTVENCTO, AREA_DE_WORK.WDATA_SQL);

            /*" -1962- MOVE WDIA-SQL TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_19.WDIA_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1963- MOVE WMES-SQL TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_19.WMES_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1964- MOVE WANO-SQL TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_19.WANO_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1965- MOVE WDATA-CABEC TO LD01-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LD01.LD01_DTVENCTO);

            /*" -1966- MOVE V0MOVDE-DIA-DEBITO TO LD01-DIA-DEBITO */
            _.Move(V0MOVDE_DIA_DEBITO, AREA_DE_WORK.LD01.LD01_DIA_DEBITO);

            /*" -1967- MOVE V0MOVDE-COD-AGENCIA-DEB TO LD01-AGENCIA */
            _.Move(V0MOVDE_COD_AGENCIA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_AGENCIA);

            /*" -1968- MOVE V0MOVDE-OPER-CONTA-DEB TO LD01-OPERACAO */
            _.Move(V0MOVDE_OPER_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_OPERACAO);

            /*" -1969- MOVE '/' TO LD01-BARRA */
            _.Move("/", AREA_DE_WORK.LD01.LD01_DEBITO.LD01_BARRA);

            /*" -1970- MOVE V0MOVDE-NUM-CONTA-DEB TO LD01-CONTA */
            _.Move(V0MOVDE_NUM_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_CONTA);

            /*" -1971- MOVE '-' TO LD01-HIFEN1 */
            _.Move("-", AREA_DE_WORK.LD01.LD01_DEBITO.LD01_HIFEN1);

            /*" -1972- MOVE V0MOVDE-DIG-CONTA-DEB TO LD01-DIGITO */
            _.Move(V0MOVDE_DIG_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_DIGITO);

            /*" -1974- MOVE V0MOVDE-VLR-DEBITO TO LD01-VLDEBITO */
            _.Move(V0MOVDE_VLR_DEBITO, AREA_DE_WORK.LD01.LD01_VLDEBITO);

            /*" -1976- MOVE V1CLIEN-NOME-RAZAO TO LD01-NOME */
            _.Move(V1CLIEN_NOME_RAZAO, AREA_DE_WORK.LD01.LD01_NOME);

            /*" -1977- IF WLIN GREATER 50 */

            if (AREA_DE_WORK.WLIN > 50)
            {

                /*" -1979- PERFORM R0160-00-CABECALHOS. */

                R0160_00_CABECALHOS_SECTION();
            }


            /*" -1981- WRITE REG-BI0071B FROM LD01 AFTER 1 */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -1981- COMPUTE WLIN = WLIN + 1. */
            AREA_DE_WORK.WLIN.Value = AREA_DE_WORK.WLIN + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0125_99_SAIDA*/

        [StopWatch]
        /*" R0126-00-LE-V1CLIENTE-SECTION */
        private void R0126_00_LE_V1CLIENTE_SECTION()
        {
            /*" -1991- MOVE 'R0126-00-LE-V1CLIENTE ' TO WPARAGRAFO */
            _.Move("R0126-00-LE-V1CLIENTE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1994- MOVE '126' TO WNR-EXEC-SQL. */
            _.Move("126", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1995- MOVE V1BILH-COD-CLIENTE TO V1CLIEN-COD-CLIENTE */
            _.Move(V1BILH_COD_CLIENTE, V1CLIEN_COD_CLIENTE);

            /*" -1997- MOVE SPACES TO V1CLIEN-NOME-RAZAO. */
            _.Move("", V1CLIEN_NOME_RAZAO);

            /*" -2002- PERFORM R0126_00_LE_V1CLIENTE_DB_SELECT_1 */

            R0126_00_LE_V1CLIENTE_DB_SELECT_1();

            /*" -2005- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2006- DISPLAY 'BI0071B - ' WPARAGRAFO */
                _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -2007- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                /*" -2008- DISPLAY 'V1CLIEN-COD-CLIENTE ' V1CLIEN-COD-CLIENTE */
                _.Display($"V1CLIEN-COD-CLIENTE {V1CLIEN_COD_CLIENTE}");

                /*" -2008- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0126-00-LE-V1CLIENTE-DB-SELECT-1 */
        public void R0126_00_LE_V1CLIENTE_DB_SELECT_1()
        {
            /*" -2002- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIEN-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :V1CLIEN-COD-CLIENTE END-EXEC. */

            var r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1 = new R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1()
            {
                V1CLIEN_COD_CLIENTE = V1CLIEN_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1.Execute(r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIEN_NOME_RAZAO, V1CLIEN_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0126_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-UPDATE-V0PARAM-CONTA-SECTION */
        private void R0130_00_UPDATE_V0PARAM_CONTA_SECTION()
        {
            /*" -2019- PERFORM R0135-00-PROXIMO-DEBITO */

            R0135_00_PROXIMO_DEBITO_SECTION();

            /*" -2020- MOVE 'R0130-00-UPDATE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0130-00-UPDATE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -2023- MOVE '130' TO WNR-EXEC-SQL */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2032- PERFORM R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1 */

            R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1();

            /*" -2035- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2036- DISPLAY 'BI0071B - ' WPARAGRAFO */
                _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -2037- DISPLAY 'V0PARAMC-TIPO-MOVTOCC ' V0PARAMC-TIPO-MOVTOCC */
                _.Display($"V0PARAMC-TIPO-MOVTOCC {V0PARAMC_TIPO_MOVTOCC}");

                /*" -2038- DISPLAY 'V0PARAMC-CODPRODU     ' V0PARAMC-CODPRODU */
                _.Display($"V0PARAMC-CODPRODU     {V0PARAMC_CODPRODU}");

                /*" -2039- DISPLAY 'V0PARAMC-COD-CONVENIO ' V0PARAMC-COD-CONVENIO */
                _.Display($"V0PARAMC-COD-CONVENIO {V0PARAMC_COD_CONVENIO}");

                /*" -2040- DISPLAY 'V0PARAMC-SITUACAO     ' V0PARAMC-SITUACAO */
                _.Display($"V0PARAMC-SITUACAO     {V0PARAMC_SITUACAO}");

                /*" -2040- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0130-00-UPDATE-V0PARAM-CONTA-DB-UPDATE-1 */
        public void R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1()
        {
            /*" -2032- EXEC SQL UPDATE SEGUROS.V0PARAM_CONTACEF SET NSAS = :V0PARAMC-NSAS, DTMOVTO = :V1SISTE-DTCURRENT, DTPROX_DEB = :V0PARAMC-DTPROX-DEB, TIMESTAMP = CURRENT TIMESTAMP WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC AND COD_CONVENIO = :V0PARAMC-COD-CONVENIO AND SITUACAO = :V0PARAMC-SITUACAO END-EXEC. */

            var r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1 = new R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1()
            {
                V0PARAMC_DTPROX_DEB = V0PARAMC_DTPROX_DEB.ToString(),
                V1SISTE_DTCURRENT = V1SISTE_DTCURRENT.ToString(),
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
                V0PARAMC_TIPO_MOVTOCC = V0PARAMC_TIPO_MOVTOCC.ToString(),
                V0PARAMC_COD_CONVENIO = V0PARAMC_COD_CONVENIO.ToString(),
                V0PARAMC_SITUACAO = V0PARAMC_SITUACAO.ToString(),
            };

            R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1.Execute(r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0135-00-PROXIMO-DEBITO-SECTION */
        private void R0135_00_PROXIMO_DEBITO_SECTION()
        {
            /*" -2050- MOVE 'R0135-00-PROXIMO-DEBITO' TO WPARAGRAFO */
            _.Move("R0135-00-PROXIMO-DEBITO", AREA_DE_WORK.WPARAGRAFO);

            /*" -2053- MOVE '135' TO WNR-EXEC-SQL. */
            _.Move("135", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2054- MOVE V0PARAMC-DTPROX-DEB TO WDATA-SQL. */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_SQL);

            /*" -2055- MOVE WDIA-SQL TO DATA3-DD */
            _.Move(AREA_DE_WORK.FILLER_19.WDIA_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD);

            /*" -2056- MOVE WMES-SQL TO DATA3-MM */
            _.Move(AREA_DE_WORK.FILLER_19.WMES_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM);

            /*" -2057- MOVE WANO-SQL TO DATA3-AA */
            _.Move(AREA_DE_WORK.FILLER_19.WANO_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA);

            /*" -2058- MOVE ZEROS TO DATA2-DD */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_DD);

            /*" -2059- MOVE ZEROS TO DATA2-MM */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_MM);

            /*" -2061- MOVE ZEROS TO DATA2-AA */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_AA);

            /*" -2063- PERFORM R0136-00-ACHA-DATA 1 TIMES. */

            for (int i = 0; i < 1; i++)
            {

                R0136_00_ACHA_DATA_SECTION();

            }

            /*" -2064- IF QUANTIDA EQUAL +99999 */

            if (AREA_DE_WORK.LPARM2.QUANTIDA == +99999)
            {

                /*" -2065- MOVE 31 TO DATA3-DD */
                _.Move(31, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD);

                /*" -2066- MOVE 12 TO DATA3-MM */
                _.Move(12, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM);

                /*" -2067- MOVE 9999 TO DATA3-AA */
                _.Move(9999, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA);

                /*" -2068- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -2069- DISPLAY '* BI0071B - ERRO NA ROTINA PROSOMC1 *' */
                _.Display($"* BI0071B - ERRO NA ROTINA PROSOMC1 *");

                /*" -2070- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -2072- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2073- MOVE DATA3-DD TO WDIA-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD, AREA_DE_WORK.FILLER_19.WDIA_SQL);

            /*" -2074- MOVE DATA3-MM TO WMES-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM, AREA_DE_WORK.FILLER_19.WMES_SQL);

            /*" -2076- MOVE DATA3-AA TO WANO-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA, AREA_DE_WORK.FILLER_19.WANO_SQL);

            /*" -2076- MOVE WDATA-SQL TO V0PARAMC-DTPROX-DEB. */
            _.Move(AREA_DE_WORK.WDATA_SQL, V0PARAMC_DTPROX_DEB);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0135_99_SAIDA*/

        [StopWatch]
        /*" R0136-00-ACHA-DATA-SECTION */
        private void R0136_00_ACHA_DATA_SECTION()
        {
            /*" -2086- MOVE 'R0136-00-ACHA-DATA' TO WPARAGRAFO */
            _.Move("R0136-00-ACHA-DATA", AREA_DE_WORK.WPARAGRAFO);

            /*" -2089- MOVE '136' TO WNR-EXEC-SQL. */
            _.Move("136", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2091- MOVE DATA3 TO DATA2 */
            _.Move(AREA_DE_WORK.LPARM2.DATA3, AREA_DE_WORK.LPARM2.DATA2);

            /*" -2091- CALL 'PROSOMC1' USING LPARM2. */
            _.Call("PROSOMC1", AREA_DE_WORK.LPARM2);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0136_99_SAIDA*/

        [StopWatch]
        /*" R0140-00-UPDATE-V0MOVDEBCC-CEF-SECTION */
        private void R0140_00_UPDATE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -2101- MOVE 'R0140-00-UPDATE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0140-00-UPDATE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -2103- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2104- IF V0MOVDE-SIT-COBRANCA EQUAL 'A' */

            if (V0MOVDE_SIT_COBRANCA == "A")
            {

                /*" -2106- PERFORM R0013-00-SELECT-TIMESTAMP */

                R0013_00_SELECT_TIMESTAMP_SECTION();

                /*" -2107- IF VIND-COD-RETORNO LESS ZEROS */

                if (VIND_COD_RETORNO < 00)
                {

                    /*" -2108- MOVE '4' TO V0MOVDE-SIT-COBRANCA */
                    _.Move("4", V0MOVDE_SIT_COBRANCA);

                    /*" -2109- ELSE */
                }
                else
                {


                    /*" -2110- IF V0MOVDE-COD-RETORNO-CEF EQUAL ZEROS */

                    if (V0MOVDE_COD_RETORNO_CEF == 00)
                    {

                        /*" -2111- MOVE '2' TO V0MOVDE-SIT-COBRANCA */
                        _.Move("2", V0MOVDE_SIT_COBRANCA);

                        /*" -2112- ELSE */
                    }
                    else
                    {


                        /*" -2113- MOVE '3' TO V0MOVDE-SIT-COBRANCA */
                        _.Move("3", V0MOVDE_SIT_COBRANCA);

                        /*" -2114- END-IF */
                    }


                    /*" -2115- END-IF */
                }


                /*" -2118- ELSE */
            }
            else
            {


                /*" -2119- MOVE '4' TO V0MOVDE-SIT-COBRANCA */
                _.Move("4", V0MOVDE_SIT_COBRANCA);

                /*" -2120- MOVE WS-TIMESTAMP-CANCEL TO V1SISTE-TSCURRENT */
                _.Move(AREA_DE_WORK.WS_TIMESTAMP_CANCEL, V1SISTE_TSCURRENT);

                /*" -2122- END-IF. */
            }


            /*" -2123- MOVE 'R0140-00-UPDATE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0140-00-UPDATE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -2125- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2144- PERFORM R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1 */

            R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1();

            /*" -2147- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2148- DISPLAY 'BI0071B - ' WPARAGRAFO */
                _.Display($"BI0071B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -2149- DISPLAY 'V0MOVDE-NUM-APOLICE  ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE  {V0MOVDE_NUM_APOLICE}");

                /*" -2150- DISPLAY 'V0MOVDE-NRENDOS      ' V0MOVDE-NRENDOS */
                _.Display($"V0MOVDE-NRENDOS      {V0MOVDE_NRENDOS}");

                /*" -2151- DISPLAY 'V0MOVDE-NRPARCEL     ' V0MOVDE-NRPARCEL */
                _.Display($"V0MOVDE-NRPARCEL     {V0MOVDE_NRPARCEL}");

                /*" -2152- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                /*" -2153- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                /*" -2154- DISPLAY 'V1SISTE-DTCURRENT    ' V1SISTE-DTCURRENT */
                _.Display($"V1SISTE-DTCURRENT    {V1SISTE_DTCURRENT}");

                /*" -2155- DISPLAY 'V0PARAMC-NSAS        ' V0PARAMC-NSAS */
                _.Display($"V0PARAMC-NSAS        {V0PARAMC_NSAS}");

                /*" -2156- DISPLAY 'V0MOVDE-REQUISICAO   ' V0MOVDE-REQUISICAO */
                _.Display($"V0MOVDE-REQUISICAO   {V0MOVDE_REQUISICAO}");

                /*" -2157- DISPLAY 'V0MOVDE-COD-CONVENIO ' V0MOVDE-COD-CONVENIO */
                _.Display($"V0MOVDE-COD-CONVENIO {V0MOVDE_COD_CONVENIO}");

                /*" -2158- DISPLAY 'V0MOVDE-NSAS         ' V0MOVDE-NSAS */
                _.Display($"V0MOVDE-NSAS         {V0MOVDE_NSAS}");

                /*" -2159- DISPLAY 'SQLCODE              ' SQLCODE */
                _.Display($"SQLCODE              {DB.SQLCODE}");

                /*" -2159- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0140-00-UPDATE-V0MOVDEBCC-CEF-DB-UPDATE-1 */
        public void R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1()
        {
            /*" -2144- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET SIT_COBRANCA = :V0MOVDE-SIT-COBRANCA, DTMOVTO = :V1SISTE-DTCURRENT, DTENVIO = CURRENT DATE, NSAS = :V0PARAMC-NSAS, COD_USUARIO = 'BI0071B' , NUM_REQUISICAO = :V0MOVDE-REQUISICAO, TIMESTAMP = :V1SISTE-TSCURRENT WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND NRENDOS = :V0MOVDE-NRENDOS AND NRPARCEL = :V0MOVDE-NRPARCEL AND SIT_COBRANCA IN ( '0' , ' ' , 'A' ) AND DTVENCTO <= :V0MOVDE-DTVENCTO AND COD_CONVENIO = :V0MOVDE-COD-CONVENIO AND NSAS = :V0MOVDE-NSAS END-EXEC. */

            var r0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 = new R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1()
            {
                V0MOVDE_SIT_COBRANCA = V0MOVDE_SIT_COBRANCA.ToString(),
                V0MOVDE_REQUISICAO = V0MOVDE_REQUISICAO.ToString(),
                V1SISTE_DTCURRENT = V1SISTE_DTCURRENT.ToString(),
                V1SISTE_TSCURRENT = V1SISTE_TSCURRENT.ToString(),
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
                V0MOVDE_COD_CONVENIO = V0MOVDE_COD_CONVENIO.ToString(),
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_NRPARCEL = V0MOVDE_NRPARCEL.ToString(),
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V0MOVDE_NRENDOS = V0MOVDE_NRENDOS.ToString(),
                V0MOVDE_NSAS = V0MOVDE_NSAS.ToString(),
            };

            R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1.Execute(r0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-CABECALHOS-SECTION */
        private void R0160_00_CABECALHOS_SECTION()
        {
            /*" -2171- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2172- MOVE V0PARAMC-NSAS TO LC06-NRFITA */
            _.Move(V0PARAMC_NSAS, AREA_DE_WORK.LC06.LC06_NRFITA);

            /*" -2173- COMPUTE WPAG = WPAG + 1 */
            AREA_DE_WORK.WPAG.Value = AREA_DE_WORK.WPAG + 1;

            /*" -2175- MOVE WPAG TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.WPAG, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -2176- WRITE REG-BI0071B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2177- WRITE REG-BI0071B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2178- WRITE REG-BI0071B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2179- WRITE REG-BI0071B FROM LC07 AFTER 1 */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2180- WRITE REG-BI0071B FROM LC06 AFTER 1 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2181- WRITE REG-BI0071B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2182- WRITE REG-BI0071B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2184- WRITE REG-BI0071B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2184- MOVE 08 TO WLIN. */
            _.Move(08, AREA_DE_WORK.WLIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-TOTALIZADOR-SECTION */
        private void R0170_00_TOTALIZADOR_SECTION()
        {
            /*" -2194- COMPUTE WTOTREG = WTOTREG - 2 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG - 2;

            /*" -2195- MOVE WTOTREG TO LT01-QT-TOTAL */
            _.Move(AREA_DE_WORK.WTOTREG, AREA_DE_WORK.LT01.LT01_QT_TOTAL);

            /*" -2197- MOVE WTOTDEB TO LT01-VL-TOTAL */
            _.Move(AREA_DE_WORK.WTOTDEB, AREA_DE_WORK.LT01.LT01_VL_TOTAL);

            /*" -2197- WRITE REG-BI0071B FROM LT01 AFTER 2. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-RELAT-SEM-MOVTO-SECTION */
        private void R0180_00_RELAT_SEM_MOVTO_SECTION()
        {
            /*" -2209- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2210- WRITE REG-BI0071B FROM LD02 AFTER 2 */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2211- WRITE REG-BI0071B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2212- WRITE REG-BI0071B FROM LD03 AFTER 1 */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2213- WRITE REG-BI0071B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

            /*" -2213- WRITE REG-BI0071B FROM LD02 AFTER 1. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI0071B);

            RBI0071B.Write(REG_BI0071B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INTEGRA-SAP-SECTION */
        private void R0200_00_INTEGRA_SAP_SECTION()
        {
            /*" -2223- MOVE 'R0200-00-INTEGRA-SAP' TO WPARAGRAFO */
            _.Move("R0200-00-INTEGRA-SAP", AREA_DE_WORK.WPARAGRAFO);

            /*" -2225- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2227- MOVE ALL SPACES TO LD99. */
            _.MoveAll("", AUX_DETALHE.LD99);

            /*" -2228- MOVE V0PARAMC-COD-CONVENIO TO LD99-CONVENIO. */
            _.Move(V0PARAMC_COD_CONVENIO, AUX_DETALHE.LD99.LD99_CONVENIO);

            /*" -2230- MOVE V0PARAMC-NSAS TO LD99-NSAS. */
            _.Move(V0PARAMC_NSAS, AUX_DETALHE.LD99.LD99_NSAS);

            /*" -2231- MOVE V1BILH-FONTE TO LD99-FONTE. */
            _.Move(V1BILH_FONTE, AUX_DETALHE.LD99.LD99_FONTE);

            /*" -2232- MOVE V1BILH-RAMO TO LD99-RAMO. */
            _.Move(V1BILH_RAMO, AUX_DETALHE.LD99.LD99_RAMO);

            /*" -2233- MOVE V1BILH-NUMBIL TO LD99-BILHETE. */
            _.Move(V1BILH_NUMBIL, AUX_DETALHE.LD99.LD99_BILHETE);

            /*" -2234- MOVE V1BILH-COD-CLIENTE TO LD99-CLIENTE. */
            _.Move(V1BILH_COD_CLIENTE, AUX_DETALHE.LD99.LD99_CLIENTE);

            /*" -2235- MOVE V1BILH-OCOREND TO LD99-OCOREND. */
            _.Move(V1BILH_OCOREND, AUX_DETALHE.LD99.LD99_OCOREND);

            /*" -2237- MOVE V1BILH-SITUACAO TO LD99-SITUACAO. */
            _.Move(V1BILH_SITUACAO, AUX_DETALHE.LD99.LD99_SITUACAO);

            /*" -2238- MOVE V0CONV-NUMPROPOSTA TO LD99-PROPOSTA. */
            _.Move(V0CONV_NUMPROPOSTA, AUX_DETALHE.LD99.LD99_PROPOSTA);

            /*" -2239- MOVE V0MOVDE-NUM-APOLICE TO LD99-APOLICE. */
            _.Move(V0MOVDE_NUM_APOLICE, AUX_DETALHE.LD99.LD99_APOLICE);

            /*" -2240- MOVE V0MOVDE-NRENDOS TO LD99-ENDOSSO. */
            _.Move(V0MOVDE_NRENDOS, AUX_DETALHE.LD99.LD99_ENDOSSO);

            /*" -2242- MOVE V0MOVDE-NRPARCEL TO LD99-PARCELA. */
            _.Move(V0MOVDE_NRPARCEL, AUX_DETALHE.LD99.LD99_PARCELA);

            /*" -2243- MOVE V0MOVDE-DTVENCTO TO LD99-DTVENCTO. */
            _.Move(V0MOVDE_DTVENCTO, AUX_DETALHE.LD99.LD99_DTVENCTO);

            /*" -2244- MOVE V0MOVDE-VLR-DEBITO TO LD99-VALOR. */
            _.Move(V0MOVDE_VLR_DEBITO, AUX_DETALHE.LD99.LD99_VALOR);

            /*" -2245- MOVE V0MOVDE-REQUISICAO TO LD99-NRSEQ. */
            _.Move(V0MOVDE_REQUISICAO, AUX_DETALHE.LD99.LD99_NRSEQ);

            /*" -2246- MOVE APOLCOBR-COD-AGENCIA TO LD99-BANCO. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA, AUX_DETALHE.LD99.LD99_BANCO);

            /*" -2247- MOVE APOLCOBR-COD-AGENCIA-DEB TO LD99-AGENCIA. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB, AUX_DETALHE.LD99.LD99_AGENCIA);

            /*" -2248- MOVE APOLCOBR-OPER-CONTA-DEB TO LD99-OPECONTA. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB, AUX_DETALHE.LD99.LD99_OPECONTA);

            /*" -2249- MOVE APOLCOBR-NUM-CONTA-DEB TO LD99-CONTA. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB, AUX_DETALHE.LD99.LD99_CONTA);

            /*" -2250- MOVE APOLCOBR-DIG-CONTA-DEB TO LD99-DIGCONTA. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB, AUX_DETALHE.LD99.LD99_DIGCONTA);

            /*" -2251- MOVE APOLCOBR-NUM-CARTAO TO LD99-CARTAO. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO, AUX_DETALHE.LD99.LD99_CARTAO);

            /*" -2253- MOVE APOLCOBR-COD-PRODUTO TO LD99-PRODUTO. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_PRODUTO, AUX_DETALHE.LD99.LD99_PRODUTO);

            /*" -2254- WRITE REG-BI0071B1 FROM LD99. */
            _.Move(AUX_DETALHE.LD99.GetMoveValues(), REG_BI0071B1);

            BI0071B1.Write(REG_BI0071B1.GetMoveValues().ToString());

            /*" -2254- ADD 1 TO WS-GRAVA. */
            AREA_DE_WORK.WS_GRAVA.Value = AREA_DE_WORK.WS_GRAVA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-TRATA-FC0105S-SECTION */
        private void R4100_00_TRATA_FC0105S_SECTION()
        {
            /*" -2265- MOVE '1000' TO WNR-EXEC-SQL */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2273- MOVE SPACES TO WS-RENOVACAO. */
            _.Move("", AREA_DE_WORK.WS_RENOVACAO);

            /*" -2275- PERFORM R4370-00-SELECIONA-TITULO-CAP. */

            R4370_00_SELECIONA_TITULO_CAP_SECTION();

            /*" -2277- PERFORM R4200-00-INSERT-MOVFEDCA. */

            R4200_00_INSERT_MOVFEDCA_SECTION();

            /*" -2278- IF LK-OUT-COD-RETORNO EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO == 00)
            {

                /*" -2279- PERFORM R4300-00-INSERT-COMFEDCA */

                R4300_00_INSERT_COMFEDCA_SECTION();

                /*" -2281- END-IF. */
            }


            /*" -2282- IF WS-RENOVACAO EQUAL SPACES */

            if (AREA_DE_WORK.WS_RENOVACAO.IsEmpty())
            {

                /*" -2283- PERFORM R4350-00-INSERT-RELATORIO */

                R4350_00_INSERT_RELATORIO_SECTION();

                /*" -2283- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4150-00-SELECT-BILCOBER-SECTION */
        private void R4150_00_SELECT_BILCOBER_SECTION()
        {
            /*" -2294- MOVE 'R4150-00-SELECT-BILCOBER' TO WPARAGRAFO. */
            _.Move("R4150-00-SELECT-BILCOBER", AREA_DE_WORK.WPARAGRAFO);

            /*" -2296- MOVE '4150' TO WNR-EXEC-SQL. */
            _.Move("4150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2298- INITIALIZE DCLBILHETE-COBERTURA. */
            _.Initialize(
                BILCOBER.DCLBILHETE_COBERTURA
            );

            /*" -2309- PERFORM R4150_00_SELECT_BILCOBER_DB_SELECT_1 */

            R4150_00_SELECT_BILCOBER_DB_SELECT_1();

            /*" -2312- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2313- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2314- MOVE 'S' TO WFIMV1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIMV1BILHETE);

                    /*" -2315- ELSE */
                }
                else
                {


                    /*" -2316- DISPLAY 'BI0071B -' WPARAGRAFO */
                    _.Display($"BI0071B -{AREA_DE_WORK.WPARAGRAFO}");

                    /*" -2317- DISPLAY 'V0MOVDE-NUM-APOLICE' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE{V0MOVDE_NUM_APOLICE}");

                    /*" -2318- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2319- END-IF */
                }


                /*" -2319- END-IF. */
            }


        }

        [StopWatch]
        /*" R4150-00-SELECT-BILCOBER-DB-SELECT-1 */
        public void R4150_00_SELECT_BILCOBER_DB_SELECT_1()
        {
            /*" -2309- EXEC SQL SELECT VAL_MAX_COBER_BAS INTO :BILCOBER-VAL-MAX-COBER-BAS FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA IN (0,9999,11) AND COD_PRODUTO = :V0CONV-CODPRODU AND RAMO_COBERTURA = :V1BILH-RAMO AND MODALI_COBERTURA = 0 AND COD_OPCAO_PLANO = :V1BILH-OPCAO-COB AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC */

            var r4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1 = new R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1()
            {
                V1BILH_OPCAO_COB = V1BILH_OPCAO_COB.ToString(),
                V0CONV_CODPRODU = V0CONV_CODPRODU.ToString(),
                V1BILH_RAMO = V1BILH_RAMO.ToString(),
            };

            var executed_1 = R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1.Execute(r4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILCOBER_VAL_MAX_COBER_BAS, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-INSERT-MOVFEDCA-SECTION */
        private void R4200_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -2331- MOVE '4200' TO WNR-EXEC-SQL */
            _.Move("4200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2348- INITIALIZE LK-PLANO LK-SERIE LK-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-PARCEIRO LK-RAMO LK-COD-USUARIO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE. */
            _.Initialize(
                LK_PLANO
                , LK_SERIE
                , LK_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_PARCEIRO
                , LK_RAMO
                , LK_COD_USUARIO
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -2351- PERFORM R5000-00-SELECT-EMP-CAP */

            R5000_00_SELECT_EMP_CAP_SECTION();

            /*" -2353- MOVE PARM-COD-EMPR-CAP TO LK-PARCEIRO. */
            _.Move(PARM_COD_EMPR_CAP, LK_PARCEIRO);

            /*" -2355- MOVE 'TRACE OFF' TO LK-TRACE. */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -2357- MOVE ZEROS TO LK-NUM-NSA. */
            _.Move(0, LK_NUM_NSA);

            /*" -2358- IF WS-RENOVACAO EQUAL 'SIM' */

            if (AREA_DE_WORK.WS_RENOVACAO == "SIM")
            {

                /*" -2366- DISPLAY 'RENOVACAO: ' ' PLANO:   ' WF-NUM-PLANO ' SERIE:   ' WF-NUM-SERIE ' TITULO:  ' WF-NUM-TITULO ' BILHETE: ' V1BILH-NUMBIL */

                $"RENOVACAO:  PLANO:   {WF_NUM_PLANO} SERIE:   {WF_NUM_SERIE} TITULO:  {WF_NUM_TITULO} BILHETE: {V1BILH_NUMBIL}"
                .Display();

                /*" -2367- MOVE WF-NUM-PLANO TO LK-PLANO */
                _.Move(WF_NUM_PLANO, LK_PLANO);

                /*" -2368- MOVE WF-NUM-SERIE TO LK-SERIE */
                _.Move(WF_NUM_SERIE, LK_SERIE);

                /*" -2369- MOVE WF-NUM-TITULO TO LK-TITULO */
                _.Move(WF_NUM_TITULO, LK_TITULO);

                /*" -2370- MOVE BILCOBER-VAL-MAX-COBER-BAS TO LK-VLR-TITULO */
                _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS, LK_VLR_TITULO);

                /*" -2371- ELSE */
            }
            else
            {


                /*" -2372- DISPLAY 'COMPRA: ' */
                _.Display($"COMPRA: ");

                /*" -2373- DISPLAY 'BILHETE: ' V1BILH-NUMBIL */
                _.Display($"BILHETE: {V1BILH_NUMBIL}");

                /*" -2374- MOVE 858 TO LK-PLANO */
                _.Move(858, LK_PLANO);

                /*" -2375- MOVE V0CONV-CODPRODU TO LK-RAMO */
                _.Move(V0CONV_CODPRODU, LK_RAMO);

                /*" -2376- MOVE 'BI0071B' TO LK-COD-USUARIO */
                _.Move("BI0071B", LK_COD_USUARIO);

                /*" -2377- MOVE 1 TO LK-QTD-TITULOS */
                _.Move(1, LK_QTD_TITULOS);

                /*" -2378- MOVE BILCOBER-VAL-MAX-COBER-BAS TO LK-VLR-TITULO */
                _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS, LK_VLR_TITULO);

                /*" -2379- MOVE V1BILH-NUMBIL TO LK-NUM-PROPOSTA */
                _.Move(V1BILH_NUMBIL, LK_NUM_PROPOSTA);

                /*" -2383- END-IF. */
            }


            /*" -2402- CALL 'VG0105S' USING LK-PLANO , LK-SERIE , LK-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-PARCEIRO , LK-RAMO , LK-COD-USUARIO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE. */
            _.Call("VG0105S", LK_PLANO, LK_SERIE, LK_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_PARCEIRO, LK_RAMO, LK_COD_USUARIO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -2403- EVALUATE LK-OUT-COD-RETORNO */
            switch (LK_OUT_COD_RETORNO.Value)
            {

                /*" -2404- WHEN 00 */
                case 00:

                    /*" -2405- ADD 1 TO WS-TIT-CAP */
                    AREA_DE_WORK.WS_TIT_CAP.Value = AREA_DE_WORK.WS_TIT_CAP + 1;

                    /*" -2406- WHEN 98 */
                    break;
                case 98:

                    /*" -2407- ADD 1 TO WS-ERR-TIT-CAP */
                    AREA_DE_WORK.WS_ERR_TIT_CAP.Value = AREA_DE_WORK.WS_ERR_TIT_CAP + 1;

                    /*" -2411- DISPLAY 'RETORNO CAP: ' ' ' LK-NUM-PROPOSTA ' ' LK-OUT-COD-RETORNO ' ' LK-OUT-MENSAGEM */

                    $"RETORNO CAP:  {LK_NUM_PROPOSTA} {LK_OUT_COD_RETORNO} {LK_OUT_MENSAGEM}"
                    .Display();

                    /*" -2412- WHEN 99 */
                    break;
                case 99:

                    /*" -2413- ADD 1 TO WS-ERR-TIT-CAP */
                    AREA_DE_WORK.WS_ERR_TIT_CAP.Value = AREA_DE_WORK.WS_ERR_TIT_CAP + 1;

                    /*" -2417- DISPLAY 'RETORNO CAP: ' ' ' LK-NUM-PROPOSTA ' ' LK-OUT-COD-RETORNO ' ' LK-OUT-MENSAGEM */

                    $"RETORNO CAP:  {LK_NUM_PROPOSTA} {LK_OUT_COD_RETORNO} {LK_OUT_MENSAGEM}"
                    .Display();

                    /*" -2418- WHEN OTHER */
                    break;
                default:

                    /*" -2419- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                    _.Move(LK_OUT_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                    /*" -2426- DISPLAY 'PROBLEMAS NO ACESSO A VG0105S ' ' ' LK-NUM-PROPOSTA ' ' LK-OUT-COD-RETORNO ' ' WS-SQLCODE ' ' LK-OUT-MENSAGEM ' ' LK-OUT-SQLERRMC ' ' LK-OUT-SQLSTATE */

                    $"PROBLEMAS NO ACESSO A VG0105S  {LK_NUM_PROPOSTA} {LK_OUT_COD_RETORNO} {AREA_DE_WORK.WS_SQLCODE} {LK_OUT_MENSAGEM} {LK_OUT_SQLERRMC} {LK_OUT_SQLSTATE}"
                    .Display();

                    /*" -2427- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2427- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-INSERT-COMFEDCA-SECTION */
        private void R4300_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -2439- MOVE '4300' TO WNR-EXEC-SQL. */
            _.Move("4300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2440- IF WS-RENOVACAO EQUAL 'SIM' */

            if (AREA_DE_WORK.WS_RENOVACAO == "SIM")
            {

                /*" -2441- MOVE 'R' TO WHOST-SIT-REGISTRO */
                _.Move("R", AREA_DE_WORK.WHOST_SIT_REGISTRO);

                /*" -2442- ELSE */
            }
            else
            {


                /*" -2443- MOVE '0' TO WHOST-SIT-REGISTRO */
                _.Move("0", AREA_DE_WORK.WHOST_SIT_REGISTRO);

                /*" -2445- END-IF. */
            }


            /*" -2457- PERFORM R4300_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R4300_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -2460- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2461- DISPLAY 'R4300 - ERRO NO INSERT DA COMFEDCA' */
                _.Display($"R4300 - ERRO NO INSERT DA COMFEDCA");

                /*" -2462- DISPLAY 'BILHETE ' V1BILH-NUMBIL */
                _.Display($"BILHETE {V1BILH_NUMBIL}");

                /*" -2463- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2463- END-IF. */
            }


        }

        [StopWatch]
        /*" R4300-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R4300_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -2457- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V1BILH-NUMBIL , :WHOST-SIT-REGISTRO, :V1SISTE-DTMOVABE, CURRENT TIMESTAMP ) END-EXEC. */

            var r4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
                WHOST_SIT_REGISTRO = AREA_DE_WORK.WHOST_SIT_REGISTRO.ToString(),
                V1SISTE_DTMOVABE = V1SISTE_DTMOVABE.ToString(),
            };

            R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4350-00-INSERT-RELATORIO-SECTION */
        private void R4350_00_INSERT_RELATORIO_SECTION()
        {
            /*" -2474- MOVE '4350' TO WNR-EXEC-SQL. */
            _.Move("4350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2475- MOVE 'BI0071B1' TO RELATORI-COD-RELATORIO. */
            _.Move("BI0071B1", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -2476- MOVE V1BILH-NUMAPOL TO RELATORI-NUM-APOLICE. */
            _.Move(V1BILH_NUMAPOL, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -2477- MOVE V0MOVDE-NRENDOS TO RELATORI-NUM-ENDOSSO. */
            _.Move(V0MOVDE_NRENDOS, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);

            /*" -2478- MOVE ZEROS TO RELATORI-NUM-CERTIFICADO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

            /*" -2479- MOVE V1BILH-NUMBIL TO RELATORI-NUM-TITULO. */
            _.Move(V1BILH_NUMBIL, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);

            /*" -2481- MOVE 3 TO RELATORI-COD-OPERACAO. */
            _.Move(3, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

            /*" -2524- PERFORM R4350_00_INSERT_RELATORIO_DB_INSERT_1 */

            R4350_00_INSERT_RELATORIO_DB_INSERT_1();

            /*" -2527- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2528- DISPLAY 'R4350 - ERRO INSERT RELATORIOS..' */
                _.Display($"R4350 - ERRO INSERT RELATORIOS..");

                /*" -2529- DISPLAY 'NUMBIL:' V1BILH-NUMBIL */
                _.Display($"NUMBIL:{V1BILH_NUMBIL}");

                /*" -2529- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4350-00-INSERT-RELATORIO-DB-INSERT-1 */
        public void R4350_00_INSERT_RELATORIO_DB_INSERT_1()
        {
            /*" -2524- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'BI0071B' , CURRENT DATE , 'BI' , :RELATORI-COD-RELATORIO , 0 , 0 , CURRENT DATE , CURRENT DATE , CURRENT DATE , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , :RELATORI-NUM-APOLICE , :RELATORI-NUM-ENDOSSO , 0 , :RELATORI-NUM-CERTIFICADO , :RELATORI-NUM-TITULO , 0 , :RELATORI-COD-OPERACAO , 0 , 0 , ' ' , ' ' , 0 , 0 , ' ' , 0 , 0 , ' ' , '0' , ' ' , ' ' , NULL , 0 , 0 , CURRENT TIMESTAMP) END-EXEC. */

            var r4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1 = new R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
            };

            R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1.Execute(r4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4350_99_SAIDA*/

        [StopWatch]
        /*" R4370-00-SELECIONA-TITULO-CAP-SECTION */
        private void R4370_00_SELECIONA_TITULO_CAP_SECTION()
        {
            /*" -2566- MOVE '4370' TO WNR-EXEC-SQL. */
            _.Move("4370", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2567- MOVE V1BILH-NUMBIL TO LK-NUM-PROPOSTA */
            _.Move(V1BILH_NUMBIL, LK_NUM_PROPOSTA);

            /*" -2568- MOVE V0CONV-CODPRODU TO LK-COD-RAMO */
            _.Move(V0CONV_CODPRODU, LK_COD_RAMO);

            /*" -2570- MOVE 'TRACE ON ' TO LK-TRACE */
            _.Move("TRACE ON ", LK_TRACE);

            /*" -2593- INITIALIZE WF-NUM-PLANO , WF-NUM-SERIE , WF-NUM-TITULO , LK-NUM-PLANO , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE */
            _.Initialize(
                WF_NUM_PLANO
                , WF_NUM_SERIE
                , WF_NUM_TITULO
                , LK_NUM_PLANO
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -2605- PERFORM R4370_00_SELECIONA_TITULO_CAP_DB_CALL_1 */

            R4370_00_SELECIONA_TITULO_CAP_DB_CALL_1();

            /*" -2608- IF SQLCODE NOT EQUAL ZEROS AND +466 */

            if (!DB.SQLCODE.In("00", "+466"))
            {

                /*" -2609- DISPLAY 'BI0071B - ERRO NA CHAMADA SPBVG012' */
                _.Display($"BI0071B - ERRO NA CHAMADA SPBVG012");

                /*" -2610- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2612- END-IF. */
            }


            /*" -2613- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -2614- IF LK-OUT-SQLCODE NOT EQUAL ZEROS */

                if (LK_OUT_SQLCODE != 00)
                {

                    /*" -2615- DISPLAY 'ERRO NA CHAMADA SPBVG012 - LK-OUT-COD' */
                    _.Display($"ERRO NA CHAMADA SPBVG012 - LK-OUT-COD");

                    /*" -2616- DISPLAY 'LK-OUT-COD-RETORNO: ' LK-OUT-COD-RETORNO */
                    _.Display($"LK-OUT-COD-RETORNO: {LK_OUT_COD_RETORNO}");

                    /*" -2617- DISPLAY 'LK-OUT-MENSAGEM: ' LK-OUT-MENSAGEM */
                    _.Display($"LK-OUT-MENSAGEM: {LK_OUT_MENSAGEM}");

                    /*" -2618- DISPLAY 'LK-OUT-SQLCODE: ' LK-OUT-SQLCODE */
                    _.Display($"LK-OUT-SQLCODE: {LK_OUT_SQLCODE}");

                    /*" -2619- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2620- ELSE */
                }
                else
                {


                    /*" -2621- GO TO R4370-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4370_99_SAIDA*/ //GOTO
                    return;

                    /*" -2622- END-IF */
                }


                /*" -2624- END-IF. */
            }


            /*" -2625- IF LK-OUT-COD-RETORNO EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO == 00)
            {

                /*" -2626- MOVE ZEROS TO WS-EOF-RESULT */
                _.Move(0, WS_EOF_RESULT);

                /*" -2627- IF SQLCODE EQUAL ZEROS OR +466 */

                if (DB.SQLCODE.In("00", "+466"))
                {

                    /*" -2628- IF SQLCODE EQUAL +466 */

                    if (DB.SQLCODE == +466)
                    {

                        /*" -2629- PERFORM R4380-00-TRATAR-RESULT */

                        R4380_00_TRATAR_RESULT_SECTION();

                        /*" -2631- PERFORM R4390-00-LER-RESULT UNTIL WS-EOF-RESULT NOT EQUAL ZEROES */

                        while (!(WS_EOF_RESULT != 00))
                        {

                            R4390_00_LER_RESULT_SECTION();
                        }

                        /*" -2632- PERFORM P4400-00-FECHAR-CURSOR */

                        P4400_00_FECHAR_CURSOR_SECTION();

                        /*" -2633- END-IF */
                    }


                    /*" -2634- ELSE */
                }
                else
                {


                    /*" -2635- DISPLAY 'BI0071B - ERRO NA CHAMADA SPBVG012 - COD-RET' */
                    _.Display($"BI0071B - ERRO NA CHAMADA SPBVG012 - COD-RET");

                    /*" -2636- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2637- END-IF */
                }


                /*" -2637- END-IF. */
            }


        }

        [StopWatch]
        /*" R4370-00-SELECIONA-TITULO-CAP-DB-CALL-1 */
        public void R4370_00_SELECIONA_TITULO_CAP_DB_CALL_1()
        {
            /*" -2605- EXEC SQL CALL SEGUROS.SPBVG012 ( :LK-NUM-PLANO , :LK-NUM-PROPOSTA , :LK-COD-RAMO , :LK-TRACE , :LK-OUT-COD-RETORNO , :LK-OUT-SQLCODE , :LK-OUT-MENSAGEM , :LK-OUT-SQLERRMC , :LK-OUT-SQLSTATE ) END-EXEC. */

            var sEGUROS_SPBVG012_Call1 = new SEGUROS_SPBVG012_Call1()
            {
                LK_NUM_PLANO = LK_NUM_PLANO.ToString(),
                LK_NUM_PROPOSTA = LK_NUM_PROPOSTA.ToString(),
                LK_COD_RAMO = LK_COD_RAMO.ToString(),
                LK_TRACE = LK_TRACE.ToString(),
                LK_OUT_COD_RETORNO = LK_OUT_COD_RETORNO.ToString(),
                LK_OUT_SQLCODE = LK_OUT_SQLCODE.ToString(),
                LK_OUT_MENSAGEM = LK_OUT_MENSAGEM.ToString(),
                LK_OUT_SQLERRMC = LK_OUT_SQLERRMC.ToString(),
                LK_OUT_SQLSTATE = LK_OUT_SQLSTATE.ToString(),
            };

            var executed_1 = SEGUROS_SPBVG012_Call1.Execute(sEGUROS_SPBVG012_Call1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_NUM_PLANO, LK_NUM_PLANO);
                _.Move(executed_1.LK_NUM_PROPOSTA, LK_NUM_PROPOSTA);
                _.Move(executed_1.LK_COD_RAMO, LK_COD_RAMO);
                _.Move(executed_1.LK_TRACE, LK_TRACE);
                _.Move(executed_1.LK_OUT_COD_RETORNO, LK_OUT_COD_RETORNO);
                _.Move(executed_1.LK_OUT_SQLCODE, LK_OUT_SQLCODE);
                _.Move(executed_1.LK_OUT_MENSAGEM, LK_OUT_MENSAGEM);
                _.Move(executed_1.LK_OUT_SQLERRMC, LK_OUT_SQLERRMC);
                _.Move(executed_1.LK_OUT_SQLSTATE, LK_OUT_SQLSTATE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4370_99_SAIDA*/

        [StopWatch]
        /*" R4380-00-TRATAR-RESULT-SECTION */
        private void R4380_00_TRATAR_RESULT_SECTION()
        {
            /*" -2646- MOVE '4380' TO WNR-EXEC-SQL. */
            _.Move("4380", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2648- DISPLAY WNR-EXEC-SQL. */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2652- EXEC SQL ASSOCIATE LOCATORS (:WL-LOCATOR) WITH PROCEDURE SEGUROS.SPBVG012 END-EXEC. */
            /*-Linha desconsiderada por ser -inútil- no .NET por segurança adicionado SQLCODE = 0*/
            DB.SQLCODE.Value = 0;

            /*" -2655- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2656- DISPLAY 'BI0071B - ERROR ASSOCIATE LOCATORS - SPBVG012' */
                _.Display($"BI0071B - ERROR ASSOCIATE LOCATORS - SPBVG012");

                /*" -2657- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2659- END-IF. */
            }


            /*" -2662- EXEC SQL ALLOCATE C01-RESULT CURSOR FOR RESULT SET :WL-LOCATOR END-EXEC. */
            C01_RESULT.Allocate($"SEGUROS.SPBVG012");

            /*" -2665- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2666- DISPLAY 'BI0071B - ERROR ALLOCATE CURSOR - SPBVG012' */
                _.Display($"BI0071B - ERROR ALLOCATE CURSOR - SPBVG012");

                /*" -2667- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2667- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4380_99_SAIDA*/

        [StopWatch]
        /*" R4390-00-LER-RESULT-SECTION */
        private void R4390_00_LER_RESULT_SECTION()
        {
            /*" -2676- MOVE '4390' TO WNR-EXEC-SQL. */
            _.Move("4390", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2678- DISPLAY WNR-EXEC-SQL. */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2697- PERFORM R4390_00_LER_RESULT_DB_FETCH_1 */

            R4390_00_LER_RESULT_DB_FETCH_1();

            /*" -2700- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -2701- DISPLAY 'ERRO NO FETCH DO RESULT SET - SPBVG012' */
                _.Display($"ERRO NO FETCH DO RESULT SET - SPBVG012");

                /*" -2702- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2704- END-IF */
            }


            /*" -2705- MOVE 1 TO WS-EOF-RESULT */
            _.Move(1, WS_EOF_RESULT);

            /*" -2705- MOVE 'SIM' TO WS-RENOVACAO. */
            _.Move("SIM", AREA_DE_WORK.WS_RENOVACAO);

        }

        [StopWatch]
        /*" R4390-00-LER-RESULT-DB-FETCH-1 */
        public void R4390_00_LER_RESULT_DB_FETCH_1()
        {
            /*" -2697- EXEC SQL FETCH C01-RESULT INTO :WF-NUM-PLANO , :WF-NUM-SERIE , :WF-NUM-TITULO , :WF-COD-STA-TITULO , :WF-COD-SUB-STATUS , :WF-DTH-ATIVACAO , :WF-DTH-CADUCACAO , :WF-DTH-CRIACAO , :WF-DTH-FIM-VIGENCIA , :WF-DTH-INI-SORTEIO , :WF-DTH-INI-VIGENCIA , :WF-DTH-SUSPENSAO , :WF-IND-DV , :WF-VLR-MENSALIDADE , :WF-NUM-PROPOSTA , :WF-NUM-MOD-PLANO , :WF-DES-COMBINACAO END-EXEC */

            if (C01_RESULT.Fetch())
            {
                _.Move(C01_RESULT.WF_NUM_PLANO, WF_NUM_PLANO);
                _.Move(C01_RESULT.WF_NUM_SERIE, WF_NUM_SERIE);
                _.Move(C01_RESULT.WF_NUM_TITULO, WF_NUM_TITULO);
                _.Move(C01_RESULT.WF_COD_STA_TITULO, WF_COD_STA_TITULO);
                _.Move(C01_RESULT.WF_COD_SUB_STATUS, WF_COD_SUB_STATUS);
                _.Move(C01_RESULT.WF_DTH_ATIVACAO, WF_DTH_ATIVACAO);
                _.Move(C01_RESULT.WF_DTH_CADUCACAO, WF_DTH_CADUCACAO);
                _.Move(C01_RESULT.WF_DTH_CRIACAO, WF_DTH_CRIACAO);
                _.Move(C01_RESULT.WF_DTH_FIM_VIGENCIA, WF_DTH_FIM_VIGENCIA);
                _.Move(C01_RESULT.WF_DTH_INI_SORTEIO, WF_DTH_INI_SORTEIO);
                _.Move(C01_RESULT.WF_DTH_INI_VIGENCIA, WF_DTH_INI_VIGENCIA);
                _.Move(C01_RESULT.WF_DTH_SUSPENSAO, WF_DTH_SUSPENSAO);
                _.Move(C01_RESULT.WF_IND_DV, WF_IND_DV);
                _.Move(C01_RESULT.WF_VLR_MENSALIDADE, WF_VLR_MENSALIDADE);
                _.Move(C01_RESULT.WF_NUM_PROPOSTA, WF_NUM_PROPOSTA);
                _.Move(C01_RESULT.WF_NUM_MOD_PLANO, WF_NUM_MOD_PLANO);
                _.Move(C01_RESULT.WF_DES_COMBINACAO, WF_DES_COMBINACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4390_99_SAIDA*/

        [StopWatch]
        /*" P4400-00-FECHAR-CURSOR-SECTION */
        private void P4400_00_FECHAR_CURSOR_SECTION()
        {
            /*" -2713- MOVE '4400' TO WNR-EXEC-SQL. */
            _.Move("4400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2715- DISPLAY WNR-EXEC-SQL. */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2717- PERFORM P4400_00_FECHAR_CURSOR_DB_CLOSE_1 */

            P4400_00_FECHAR_CURSOR_DB_CLOSE_1();

            /*" -2720- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2721- DISPLAY 'ERRO NO CLOSE C01-RESULT. ' */
                _.Display($"ERRO NO CLOSE C01-RESULT. ");

                /*" -2722- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2723- DISPLAY 'SQLERRMC= ' SQLERRMC */
                _.Display($"SQLERRMC= {DB.SQLERRMC}");

                /*" -2724- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2724- END-IF. */
            }


        }

        [StopWatch]
        /*" P4400-00-FECHAR-CURSOR-DB-CLOSE-1 */
        public void P4400_00_FECHAR_CURSOR_DB_CLOSE_1()
        {
            /*" -2717- EXEC SQL CLOSE C01-RESULT END-EXEC */

            C01_RESULT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-SELECT-EMP-CAP-SECTION */
        private void R5000_00_SELECT_EMP_CAP_SECTION()
        {
            /*" -2805- PERFORM R5000_00_SELECT_EMP_CAP_DB_SELECT_1 */

            R5000_00_SELECT_EMP_CAP_DB_SELECT_1();

            /*" -2808- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2809- DISPLAY 'R1000-00 (ERRO - SELECT PRODUTO )...' */
                _.Display($"R1000-00 (ERRO - SELECT PRODUTO )...");

                /*" -2810- DISPLAY 'PRODUTO: ' V0CONV-CODPRODU */
                _.Display($"PRODUTO: {V0CONV_CODPRODU}");

                /*" -2811- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-SELECT-EMP-CAP-DB-SELECT-1 */
        public void R5000_00_SELECT_EMP_CAP_DB_SELECT_1()
        {
            /*" -2805- EXEC SQL SELECT PR.COD_EMPRESA , PG.COD_EMPRESA_CAP INTO :PROD-COD-EMPRESA, :PARM-COD-EMPR-CAP FROM SEGUROS.PRODUTO PR, SEGUROS.PARAMETROS_GERAIS PG WHERE PR.COD_PRODUTO = :V0CONV-CODPRODU AND PR.COD_EMPRESA = PG.COD_EMPRESA END-EXEC. */

            var r5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 = new R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1()
            {
                V0CONV_CODPRODU = V0CONV_CODPRODU.ToString(),
            };

            var executed_1 = R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1.Execute(r5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROD_COD_EMPRESA, PROD_COD_EMPRESA);
                _.Move(executed_1.PARM_COD_EMPR_CAP, PARM_COD_EMPR_CAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2821- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2822- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2824- DISPLAY 'MSG ERRO -> ' SQLERRMC */
            _.Display($"MSG ERRO -> {DB.SQLERRMC}");

            /*" -2824- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2826- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2830- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2832- CLOSE MOVDEBITO-CC. */
            MOVDEBITO_CC.Close();

            /*" -2834- CLOSE RBI0071B BI0071B1. */
            RBI0071B.Close();
            BI0071B1.Close();

            /*" -2834- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}