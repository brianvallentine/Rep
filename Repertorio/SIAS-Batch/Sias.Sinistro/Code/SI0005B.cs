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
using Sias.Sinistro.DB2.SI0005B;

namespace Code
{
    public class SI0005B
    {
        public bool IsCall { get; set; }

        public SI0005B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / LOTERICO                *      */
        /*"      *   PROGRAMA ...............  SI0005B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER                             *      */
        /*"      *   PROGRAMADOR ............  HEIDER                             *      */
        /*"      *   DATA CODIFICACAO .......  MAIO / 2001                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... PROCESSAMENTO DO ARQUIVO ENVIADO PELA         *      */
        /*"      *                  PRESTADORA DE SERVICO, REFERENTE AO AVISO DO  *      */
        /*"      *                  SINISTRO DO LOTERICO                          *      */
        /*"      *  ATENCAO - ESTE PROGRAMA PROCESSA OS LOTERICOS TANTO DA APOLICE*      */
        /*"      *            ADMINISTRADA, QUANTO DAS APOLICES POR LOTERICO, QUE *      */
        /*"      *            TEM INICIO DE VIGENCIA 01/01/2004 A 31/12/9999      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.17  * EM 12/01/2023 - JAZZ   460479 - HERVAL SOUZA                   *      */
        /*"      *               - CORRIGIR TESTE DE DATA. TEM DE ESTAR NA        *      */
        /*"      *                 CALENDARIO.                                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.16  * EM 01/06/2020 - JAZZ   197432 - FLAVIO DE LIMA SILVA           *      */
        /*"      *               - INSERIR SUB-ROTINA "GE0530S" PARA CONSULTAR OS *      */
        /*"      *                 DADOS DA TABELA "SIUS.GE_PEPS_PESSOA_EXPOSTA" C*      */
        /*"      *                 A FUN��O DE GRAVAR O LOG NA TABELA DE HISTORICO*      */
        /*"      *                 DE PEPS "SIUS.GE_PESSOA_VALIDA_PEPS".          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.15  *   VERSAO 15 -  CADMUS 170482                                   *      */
        /*"      *                                                                *      */
        /*"      *             -  VALIDAR CAUSA DE SINISTRO COM COB. CONTRATADA   *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/10/2018 - LISIANE BRAGANCA SOARES                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.14  *   VERSAO 14 -  CADMUS 151750                                   *      */
        /*"      *                                                                *      */
        /*"      *             -  VINCULAR CAUSA 8 COM A COBERTURA 10             *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/06/2017 - LISIANE BRAGANCA SOARES                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  *   VERSAO 13 -  CADMUS 142855 (COMPLEMENTO DA DEMANDA 142230)   *      */
        /*"      *                                                                *      */
        /*"      *             -  CORRIGIR A VALIDA��O DE PARCELA PAGA,           *      */
        /*"      *                VERIFICANDO, TAMBEM, SE ESTA EM COBRANCA        *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/10/2016 - LISIANE BRAGANCA SOARES                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  *   VERSAO 12 -  CADMUS 142230                                   *      */
        /*"      *                                                                *      */
        /*"      *             -  CORRIGIR A VALIDA��O DE PARCELA PAGA            *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/09/2016 - LISIANE BRAGANCA SOARES                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  *   VERSAO 11 -  CADMUS 133004                                   *      */
        /*"      *                                                                *      */
        /*"      *             -  PERMITIR CADASTRAR AVISO PARA APOLICE CANCELADA *      */
        /*"      *                QUANDO O SINISTRO OCORRER DENTRO DA VIGENCIA    *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/03/2016 - LISIANE BRAGANCA SOARES                      *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  *   VERSAO 10 -  CADMUS 128241                                   *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTAR LMI PARA ROUBO DE VALORES EM TRANSITO  *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/01/2015 - GUILHERME CORREIA                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *   VERSAO 09 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  * ALTERACAO:  31/03/14   09:55 CADMUS 96024  DAIRO LOPES         *      */
        /*"      *             CORRECAO NA DATA DE VENCIMENTO PARA O CCA  V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  *   VERSAO 07 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  12/08/2013  - GUILHERME CORREIA                    *      */
        /*"      *                                                                *      */
        /*"      *      SEGURADO FEZ ALTERACAO DE IS APOS OCORRENCIA DE SINISTRO  *      */
        /*"      *      HOUVE RESSARCIMENTO DO PAGAMENTO E CANCELAMENTO DO AUMENTO*      */
        /*"      *      POREM NAO HOUVE REDUCAO DA IS, DESSA FORMA O SINISTRO     *      */
        /*"      *      CONTINUA ENTENDENDO QUE O VALOR DA IS EH DO ULTIMO ENDOSSO*      */
        /*"      *      OU SEJA DE RESSARCIMENTO, ONDE A IS AINDA EH DE 30 MIL    *      */
        /*"      *                                                                *      */
        /*"      *      TAMBEM FOI FEITA UMA VERIFICACAO PARA NAO RECUPERAR       *      */
        /*"      *      ENDOSSOS CANCELADOS NO SELECT                             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURAR POR: 10479          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  A PARTIR DE 01/01/2011 O CONTROLE DE VERSAO EH     *      */
        /*"      *             FEITO PELA VARIAVEL WS-VERSAO USADA NO DISPLAY.    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  11/11/10   14:41 CADMUS 49843  ALCIONE ARAUJO      *      */
        /*"      *    ATENDIMENTO A CIRCULAR 395.                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  05/08/10   16:17 CADMUS 45985  CELIA SILVA         *      */
        /*"      *    TRATA SQLCODE 100 NA TABELA DE CAUSAS.                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  13/05/10   12:38 CADMUS 42397  CELIA SILVA         *      */
        /*"      *    AUMENTO VALOR IS DE 200.000,00 PARA 1.000.000,00            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  27/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 27/08/2008  INCLUSAO DA CLAUS. WITH UR NO COMANDO SELECT-WV0808*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - WELLINGTON VERAS (POLITEC)                         *      */
        /*"      *             PROJETO FGV                                        *      */
        /*"      * 16/07/2008  INIBIR O COMANDO DISPLAY                     WV0708*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 31/03/2005 - PRODEXTER                                         *      */
        /*"      *   SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 16/12/2004 - MAURICIO LINKE - CONTRASTE                        *      */
        /*"      *   INCLUSAO/ALTERACAO DE ROTINAS PARA PROCESSAMENTO DO ANO 2005.*      */
        /*"      *   PROCURAR POR '2005'.                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 24/08/2004 - SANDRA ROSENIA                                           */
        /*"      *   INCLUS O DO VALOR DE FRANQUIA PARA DESCONTO NO VALOR DE SALDO       */
        /*"      *   DA IS                                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 19/09/2002 - EDUARDO (PRODEXTER)                               *      */
        /*"      *   ATUALIZA A COLUNA "NOM_PROGRAMA" NA SINISTRO_HISTORICO       *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _AVISO { get; set; } = new FileBasis(new PIC("X", "316", "X(316)"));

        public FileBasis AVISO
        {
            get
            {
                _.Move(REGISTRO_AVISO, _AVISO); VarBasis.RedefinePassValue(REGISTRO_AVISO, _AVISO, REGISTRO_AVISO); return _AVISO;
            }
        }
        public FileBasis _RETORNO { get; set; } = new FileBasis(new PIC("X", "325", "X(325)"));

        public FileBasis RETORNO
        {
            get
            {
                _.Move(REGISTRO_RETORNO, _RETORNO); VarBasis.RedefinePassValue(REGISTRO_RETORNO, _RETORNO, REGISTRO_RETORNO); return _RETORNO;
            }
        }
        public FileBasis _RCRITICA { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RCRITICA
        {
            get
            {
                _.Move(REGISTRO_CRITICA, _RCRITICA); VarBasis.RedefinePassValue(REGISTRO_CRITICA, _RCRITICA, REGISTRO_CRITICA); return _RCRITICA;
            }
        }
        public FileBasis _RAVISOOK { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RAVISOOK
        {
            get
            {
                _.Move(REGISTRO_AVISOOK, _RAVISOOK); VarBasis.RedefinePassValue(REGISTRO_AVISOOK, _RAVISOOK, REGISTRO_AVISOOK); return _RAVISOOK;
            }
        }
        /*"01  REGISTRO-AVISO.*/
        public SI0005B_REGISTRO_AVISO REGISTRO_AVISO { get; set; } = new SI0005B_REGISTRO_AVISO();
        public class SI0005B_REGISTRO_AVISO : VarBasis
        {
            /*"    05 AV-TIPO-REGISTRO               PIC  X(01).*/
            public StringBasis AV_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 AV-COD-LOT-CEF                 PIC  X(13).*/
            public StringBasis AV_COD_LOT_CEF { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"    05 AV-NOME-LOTERICO               PIC  X(40).*/
            public StringBasis AV_NOME_LOTERICO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 AV-DATA-OCORRENCIA             PIC  X(08).*/
            public StringBasis AV_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 AV-HORA-OCORRENCIA             PIC  X(04).*/
            public StringBasis AV_HORA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05 AV-DATA-GERACAO                PIC  X(08).*/
            public StringBasis AV_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 AV-DATA-AVISO                  PIC  X(08).*/
            public StringBasis AV_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 AV-HORA-AVISO                  PIC  X(04).*/
            public StringBasis AV_HORA_AVISO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05 AV-VALOR-INFORMADO             PIC  9(13)V99.*/
            public DoubleBasis AV_VALOR_INFORMADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 AV-COD-NATUREZA                PIC  X(02).*/
            public StringBasis AV_COD_NATUREZA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 AV-COD-NATUREZA-N REDEFINES AV-COD-NATUREZA                                      PIC  9(02).*/
            private _REDEF_IntBasis _av_cod_natureza_n { get; set; }
            public _REDEF_IntBasis AV_COD_NATUREZA_N
            {
                get { _av_cod_natureza_n = new _REDEF_IntBasis(new PIC("9", "02", "9(02).")); ; _.Move(AV_COD_NATUREZA, _av_cod_natureza_n); VarBasis.RedefinePassValue(AV_COD_NATUREZA, _av_cod_natureza_n, AV_COD_NATUREZA); _av_cod_natureza_n.ValueChanged += () => { _.Move(_av_cod_natureza_n, AV_COD_NATUREZA); }; return _av_cod_natureza_n; }
                set { VarBasis.RedefinePassValue(value, _av_cod_natureza_n, AV_COD_NATUREZA); }
            }  //Redefines
            /*"    05 AV-COD-CAUSA                   PIC  X(02).*/
            public StringBasis AV_COD_CAUSA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 AV-DATA-ULTIMO-DOC             PIC  X(08).*/
            public StringBasis AV_DATA_ULTIMO_DOC { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 AV-NUM-SINISTRO-PREST          PIC  9(12).*/
            public IntBasis AV_NUM_SINISTRO_PREST { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 AV-INDICADOR-ADIANTAMENTO      PIC  X(01).*/
            public StringBasis AV_INDICADOR_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 AV-QTD-PORTADORES              PIC  9(02).*/
            public IntBasis AV_QTD_PORTADORES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 AV-NUM-APOLICE                 PIC  9(13).*/
            public IntBasis AV_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05 AV-INDICADOR-CRITICA           PIC  9(02).*/
            public IntBasis AV_INDICADOR_CRITICA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 AV-MENSAGEM-CRITICA            PIC  X(80).*/
            public StringBasis AV_MENSAGEM_CRITICA { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"    05 AV-COD-ENDERECO-EXTENSAO       PIC  9(09).*/
            public IntBasis AV_COD_ENDERECO_EXTENSAO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 AV-FILLER-1                    PIC  X(84).*/
            public StringBasis AV_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "84", "X(84)."), @"");
            /*"01  REGISTRO-HEADER.*/
        }
        public SI0005B_REGISTRO_HEADER REGISTRO_HEADER { get; set; } = new SI0005B_REGISTRO_HEADER();
        public class SI0005B_REGISTRO_HEADER : VarBasis
        {
            /*"    05 HE-TIPO-REGISTRO               PIC  X(01).*/
            public StringBasis HE_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 HE-DATA-GERACAO                PIC  X(08).*/
            public StringBasis HE_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 HE-INDICADOR-ORIGEM            PIC  X(01).*/
            public StringBasis HE_INDICADOR_ORIGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 HE-FILLER                      PIC  X(306).*/
            public StringBasis HE_FILLER { get; set; } = new StringBasis(new PIC("X", "306", "X(306)."), @"");
            /*"01  REGISTRO-TRAILLER.*/
        }
        public SI0005B_REGISTRO_TRAILLER REGISTRO_TRAILLER { get; set; } = new SI0005B_REGISTRO_TRAILLER();
        public class SI0005B_REGISTRO_TRAILLER : VarBasis
        {
            /*"    05 TR-TIPO-REGISTRO               PIC  X(01).*/
            public StringBasis TR_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-DATA-GERACAO                PIC  X(08).*/
            public StringBasis TR_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 TR-INDICADOR-ORIGEM            PIC  X(01).*/
            public StringBasis TR_INDICADOR_ORIGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-QTD-REGISTROS               PIC  9(06).*/
            public IntBasis TR_QTD_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 TR-FILLER                      PIC  X(300).*/
            public StringBasis TR_FILLER { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
            /*"01  REGISTRO-RETORNO.*/
        }
        public SI0005B_REGISTRO_RETORNO REGISTRO_RETORNO { get; set; } = new SI0005B_REGISTRO_RETORNO();
        public class SI0005B_REGISTRO_RETORNO : VarBasis
        {
            /*"    05 RE-TIPO-REGISTRO               PIC  X(01).*/
            public StringBasis RE_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RE-COD-LOT-CEF                 PIC  X(13).*/
            public StringBasis RE_COD_LOT_CEF { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"    05 RE-NOME-LOTERICO               PIC  X(40).*/
            public StringBasis RE_NOME_LOTERICO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 RE-DATA-OCORRENCIA             PIC  X(08).*/
            public StringBasis RE_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 RE-HORA-OCORRENCIA             PIC  X(04).*/
            public StringBasis RE_HORA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05 RE-DATA-GERACAO                PIC  X(08).*/
            public StringBasis RE_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 RE-DATA-AVISO                  PIC  X(08).*/
            public StringBasis RE_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 RE-HORA-AVISO                  PIC  X(04).*/
            public StringBasis RE_HORA_AVISO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05 RE-VALOR-INFORMADO             PIC  9(13)V99.*/
            public DoubleBasis RE_VALOR_INFORMADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 RE-COD-NATUREZA                PIC  X(02).*/
            public StringBasis RE_COD_NATUREZA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 RE-COD-CAUSA                   PIC  X(02).*/
            public StringBasis RE_COD_CAUSA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 RE-DATA-ULTIMO-DOC             PIC  X(08).*/
            public StringBasis RE_DATA_ULTIMO_DOC { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 RE-NUM-SINISTRO-PREST          PIC  9(12).*/
            public IntBasis RE_NUM_SINISTRO_PREST { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 RE-INDICADOR-ADIANTAMENTO      PIC  X(01).*/
            public StringBasis RE_INDICADOR_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RE-QTD-PORTADORES              PIC  9(02).*/
            public IntBasis RE_QTD_PORTADORES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 RE-NUM-APOLICE                 PIC  9(13).*/
            public IntBasis RE_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05 RE-FILLER-1.*/
            public SI0005B_RE_FILLER_1 RE_FILLER_1 { get; set; } = new SI0005B_RE_FILLER_1();
            public class SI0005B_RE_FILLER_1 : VarBasis
            {
                /*"       10 RE-INDICADOR-CRITICA           PIC  9(02).*/
                public IntBasis RE_INDICADOR_CRITICA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       10 RE-MENSAGEM                    PIC  X(79).*/
                public StringBasis RE_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "79", "X(79)."), @"");
                /*"       10 RE-VALOR-REGISTRADO            PIC  9(13)V99.*/
                public DoubleBasis RE_VALOR_REGISTRADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
                /*"       10 RE-VALOR-IS                    PIC  9(13)V99.*/
                public DoubleBasis RE_VALOR_IS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
                /*"       10 RE-VALOR-ADIANTAMENTO          PIC  9(13)V99.*/
                public DoubleBasis RE_VALOR_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
                /*"       10 RE-PERC-ADIANTAMENTO           PIC  9(03)V99.*/
                public DoubleBasis RE_PERC_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99."), 2);
                /*"       10 RE-NUM-APOL-SINISTRO           PIC  9(13).*/
                public IntBasis RE_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"       10 RE-DATA-MOVIMENTO              PIC  9(08).*/
                public IntBasis RE_DATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"       10 RE-QTD-SINI-AVISADO            PIC  9(02).*/
                public IntBasis RE_QTD_SINI_AVISADO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       10 RE-QTD-SINI-PAGO               PIC  9(02).*/
                public IntBasis RE_QTD_SINI_PAGO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       10 RE-BANCO                       PIC  9(03).*/
                public IntBasis RE_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"       10 RE-AGENCIA                     PIC  9(04).*/
                public IntBasis RE_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 RE-OPERACAO                    PIC  9(04).*/
                public IntBasis RE_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 RE-CONTA                       PIC  9(12).*/
                public IntBasis RE_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                /*"       10 RE-DV                          PIC  X(01).*/
                public StringBasis RE_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 RE-PRODUTO                     PIC  9(04).*/
                public IntBasis RE_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"01  REGISTRO-CRITICA        PIC  X(132).*/
            }
        }
        public StringBasis REGISTRO_CRITICA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01  REGISTRO-AVISOOK        PIC  X(132).*/
        public StringBasis REGISTRO_AVISOOK { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-DT-CANCELAMENTO               PIC X(10)  VALUE SPACES.*/
        public StringBasis WS_DT_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  WS-QT-REG                        PIC S9(03) COMP VALUE +0.*/
        public IntBasis WS_QT_REG { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
        /*"77  HOST-VALOR-AVISADO               PIC S9(13)V99 COMP-3                                                        VALUE +0*/
        public DoubleBasis HOST_VALOR_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-AVISADO-OPER-101    PIC S9(13)V99 COMP-3                                                        VALUE +0*/
        public DoubleBasis W_HOST_VALOR_AVISADO_OPER_101 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-CALCULADO-99        PIC S9(13)V99 COMP-3                                                        VALUE +0*/
        public DoubleBasis W_HOST_VALOR_CALCULADO_99 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-INDENIZ-SINISTRO          PIC S9(13)V99 COMP-3                                                        VALUE +0*/
        public DoubleBasis W_HOST_INDENIZ_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-FRANQUIA            PIC S9(13)V99 COMP-3                                                        VALUE +0*/
        public DoubleBasis W_HOST_VALOR_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-VALOR-BASE-ADIANTA             PIC S9(13)V99 COMP-3                                                        VALUE +0*/
        public DoubleBasis W_VALOR_BASE_ADIANTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-ADIANTA2            PIC S9(13)V99 COMP-3                                                        VALUE +0*/
        public DoubleBasis W_HOST_VALOR_ADIANTA2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-COUNT                       PIC S9(09) COMP VALUE +0.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HOST-PAGTO                        PIC S9(04) COMP VALUE +0.*/
        public IntBasis HOST_PAGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-ANO-OCORRENCIA               PIC S9(04) COMP VALUE +0.*/
        public IntBasis HOST_ANO_OCORRENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-ACHA-LOTERICO               PIC S9(09) COMP VALUE +0.*/
        public IntBasis HOST_ACHA_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HOST-HORA-CORRENTE               PIC  X(08).*/
        public StringBasis HOST_HORA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  HOST-HORA-AVISO                  PIC  X(08).*/
        public StringBasis HOST_HORA_AVISO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  HOST-HORA-OCORRENCIA             PIC  X(08).*/
        public StringBasis HOST_HORA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  HOST-DATA-CORRENTE               PIC  X(10).*/
        public StringBasis HOST_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-OCORRENCIA             PIC  X(10).*/
        public StringBasis HOST_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-GERACAO                PIC  X(10).*/
        public StringBasis HOST_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-AVISO                  PIC  X(10).*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-ULTIMO-DOC             PIC  X(10).*/
        public StringBasis HOST_DATA_ULTIMO_DOC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-SIT-REGISTRO                PIC  X(01).*/
        public StringBasis HOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  W-HOST-VALOR-SALDO-IS          PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_SALDO_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-ADIANT-EM-ANDAMENTO     PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_ADIANT_EM_ANDAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-AVISOS                  PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_AVISOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-INDENIZ-EFETIVADAS      PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_INDENIZ_EFETIVADAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-INDENIZ-EM-ANDAMENTO    PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_INDENIZ_EM_ANDAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-PERCENTUAL-FRANQUIA          PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_PERCENTUAL_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-PERCENTUAL-PAGO              PIC S9(03)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_PERCENTUAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"77  W-HOST-VAL-AVISOS              PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VAL_AVISOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VAL-INDENIZACOES        PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VAL_INDENIZACOES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-ACUMULA-INDENIZACOES         PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_ACUMULA_INDENIZACOES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-ACUMULA-AVISOS               PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_ACUMULA_AVISOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-CALCULADO-1       PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_CALCULADO_1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-CALCULADO-2       PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_CALCULADO_2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-CALCULADO-3       PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_CALCULADO_3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-CALCULADO-4       PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_CALCULADO_4 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-TOT-PREMIO-TAR          PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_TOT_PREMIO_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-TOT-PREMIO-PAGO         PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_TOT_PREMIO_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-FIM-PRAZO               PIC S9(04)    COMP   VALUE +0*/
        public IntBasis W_HOST_FIM_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SI0006S                        PIC X(07)     VALUE 'SI0006S'*/
        public StringBasis SI0006S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI0006S");
        /*"77  WS-TIPO-ENDOSSO                PIC X(01)     VALUE SPACES.*/
        public StringBasis WS_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77 WS-VERSAO                       PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 17 - 12012023               'JAZZ   460479 -  V.17          '.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 17 - 12012023               ");
        /*"77 WS-VERSAO-10                    PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 10 - 13012016 15:52HS               'CADMUS 128241 -  V.10          '.*/
        public StringBasis WS_VERSAO_10 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 10 - 13012016 15:52HS               ");
        /*"77 WS-VERSAO-9                     PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 9 - 19122012 15:00HS               'CADMUS 103659 - NSGD - V.09          '.*/
        public StringBasis WS_VERSAO_9 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 9 - 19122012 15:00HS               ");
        /*"77 WS-VERSAO-7                     PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 7 - 19122012 15:00HS               'CADMUS 75816 - CHEQUE ZERO - V7.0    '.*/
        public StringBasis WS_VERSAO_7 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 7 - 19122012 15:00HS               ");
        /*"77 WS-VERSAO-6                     PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 6 - 31072012 10:53HS               'CADMUS 72521 - INCLUIR HORA OCORRENCIA'.*/
        public StringBasis WS_VERSAO_6 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 6 - 31072012 10:53HS               ");
        /*"77 WS-VERSAO-5                     PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 5 - 27012011   16:54HS'.*/
        public StringBasis WS_VERSAO_5 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 5 - 27012011   16:54HS");
        /*"77 WS-VERSAO-4                     PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 4 - 06012011   11:29HS'.*/
        public StringBasis WS_VERSAO_4 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 4 - 06012011   11:29HS");
        /*"77 WS-VERSAO-3                     PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 3 - 28122010   11:38HS'.*/
        public StringBasis WS_VERSAO_3 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 3 - 28122010   11:38HS");
        /*"77 WS-VERSAO-2                     PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 2 - 15122010   17:00HS'.*/
        public StringBasis WS_VERSAO_2 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 2 - 15122010   17:00HS");
        /*"77 WS-VERSAO-1                     PIC X(120)     VALUE               'PROG.SI0005B - VERSAO 1 - 11112010   14:43HS'.*/
        public StringBasis WS_VERSAO_1 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.SI0005B - VERSAO 1 - 11112010   14:43HS");
        /*"01  AREA-DE-WORK.*/
        public SI0005B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0005B_AREA_DE_WORK();
        public class SI0005B_AREA_DE_WORK : VarBasis
        {
            /*"    05 W-EDICAO                      PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"    05 W-EDICAO1                     PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO1 { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"    05 W-EDICAO2                     PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO2 { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"    05 W-EDICAO3                     PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO3 { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"    05 W-EDICAO4                     PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO4 { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"    05 W-ANO-PROCESSAMENTO           PIC X(04)    VALUE SPACES.*/
            public StringBasis W_ANO_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 W-CHAVE-NAO-ADIANTA           PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_NAO_ADIANTA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WFIM-ARQ                      PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WFIM_ARQ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WFIM-ARQAVISO                 PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WFIM_ARQAVISO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WFIM-SINISTROS-APOLICE        PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WFIM_SINISTROS_APOLICE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WFIM-ADIANT-PENDENTES         PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WFIM_ADIANT_PENDENTES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-CRITICA               PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_CRITICA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-CRITICA-NUMERIC       PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_CRITICA_NUMERIC { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-TEM-ADIANT-PENDENTE   PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_TEM_ADIANT_PENDENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-TEM-SINI-AVISADO      PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_TEM_SINI_AVISADO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-TEM-SINI-CRITICA      PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_TEM_SINI_CRITICA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-ADIANTA-SALDO-IS      PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ADIANTA_SALDO_IS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-DATA-ANTERIOR               PIC X(10)    VALUE ' '.*/
            public StringBasis W_DATA_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 W-LIDOS                       PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-REG-GRAV-RETORNO            PIC 9(06)    VALUE ZEROS.*/
            public IntBasis W_REG_GRAV_RETORNO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 W-REJEITADOS                  PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_REJEITADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-AVISADOS-SEM-ALTERACAO      PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_AVISADOS_SEM_ALTERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-AVISADOS-COM-ALTERACAO      PIC 9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_AVISADOS_COM_ALTERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-NUMERO-SINISTRO-NUM         PIC 9(13)    VALUE ZEROS.*/
            public IntBasis W_NUMERO_SINISTRO_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05 W-NUMERO-SINISTRO.*/
            public SI0005B_W_NUMERO_SINISTRO W_NUMERO_SINISTRO { get; set; } = new SI0005B_W_NUMERO_SINISTRO();
            public class SI0005B_W_NUMERO_SINISTRO : VarBasis
            {
                /*"       10 W-ORGAO-SINISTRO           PIC 9(03)    VALUE ZEROS.*/
                public IntBasis W_ORGAO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 W-RAMO-SINISTRO            PIC 9(02)    VALUE ZEROS.*/
                public IntBasis W_RAMO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-NUM-SINISTRO             PIC 9(08)    VALUE ZEROS.*/
                public IntBasis W_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
                /*"    05 W-VALOR-ADIANTAMENTO          PIC S9(13)V99 VALUE ZEROS.*/
            }
            public DoubleBasis W_VALOR_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-ADIANTA-OPERACAO-101  PIC S9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_VALOR_ADIANTA_OPERACAO_101 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-LIM-ADIANTAMENTO            PIC S9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_LIM_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-PARA-AVISO            PIC S9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_VALOR_PARA_AVISO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-HOST-VALOR-BASE-AVISO       PIC S9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_HOST_VALOR_BASE_AVISO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-HOST-VALOR-BASE-ADIANTAMENTO                                     PIC S9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_HOST_VALOR_BASE_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-HOST-VALOR-AUX              PIC S9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_HOST_VALOR_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-CONTA-PAGINA                PIC 9(07)    VALUE ZEROS.*/
            public IntBasis W_CONTA_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 W-CONTA-LINHA                 PIC 9(02)    VALUE 90.*/
            public IntBasis W_CONTA_LINHA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 90);
            /*"    05 W-CONTA-PAGINA-AVISOOK        PIC 9(07)    VALUE ZEROS.*/
            public IntBasis W_CONTA_PAGINA_AVISOOK { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 W-CONTA-LINHA-AVISOOK         PIC 9(02)    VALUE 90.*/
            public IntBasis W_CONTA_LINHA_AVISOOK { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 90);
            /*"    05 HOST-DATA-INIVIGENCIA         PIC  X(10).*/
            public StringBasis HOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 HOST-DATA-INIVIGENCIA-R REDEFINES HOST-DATA-INIVIGENCIA.*/
            private _REDEF_SI0005B_HOST_DATA_INIVIGENCIA_R _host_data_inivigencia_r { get; set; }
            public _REDEF_SI0005B_HOST_DATA_INIVIGENCIA_R HOST_DATA_INIVIGENCIA_R
            {
                get { _host_data_inivigencia_r = new _REDEF_SI0005B_HOST_DATA_INIVIGENCIA_R(); _.Move(HOST_DATA_INIVIGENCIA, _host_data_inivigencia_r); VarBasis.RedefinePassValue(HOST_DATA_INIVIGENCIA, _host_data_inivigencia_r, HOST_DATA_INIVIGENCIA); _host_data_inivigencia_r.ValueChanged += () => { _.Move(_host_data_inivigencia_r, HOST_DATA_INIVIGENCIA); }; return _host_data_inivigencia_r; }
                set { VarBasis.RedefinePassValue(value, _host_data_inivigencia_r, HOST_DATA_INIVIGENCIA); }
            }  //Redefines
            public class _REDEF_SI0005B_HOST_DATA_INIVIGENCIA_R : VarBasis
            {
                /*"       10 HOST-ANO-INIVIG            PIC X(04).*/
                public StringBasis HOST_ANO_INIVIG { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"       10 FILLER                     PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 HOST-MES-INIVIG            PIC X(02).*/
                public StringBasis HOST_MES_INIVIG { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10 FILLER                     PIC X(01).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 HOST-DIA-INIVIG            PIC X(02).*/
                public StringBasis HOST_DIA_INIVIG { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    05 HOST-DATA-TERVIGENCIA            PIC  X(10).*/

                public _REDEF_SI0005B_HOST_DATA_INIVIGENCIA_R()
                {
                    HOST_ANO_INIVIG.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    HOST_MES_INIVIG.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    HOST_DIA_INIVIG.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis HOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 W-DATA-CORRENTE.*/
            public SI0005B_W_DATA_CORRENTE W_DATA_CORRENTE { get; set; } = new SI0005B_W_DATA_CORRENTE();
            public class SI0005B_W_DATA_CORRENTE : VarBasis
            {
                /*"       15 W-DATA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-DATA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-DATA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-CORRENTE.*/
            }
            public SI0005B_W_HORA_CORRENTE W_HORA_CORRENTE { get; set; } = new SI0005B_W_HORA_CORRENTE();
            public class SI0005B_W_HORA_CORRENTE : VarBasis
            {
                /*"       15 W-HORA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-HORA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HH-MM-SS.*/
            }
            public SI0005B_W_HORA_HH_MM_SS W_HORA_HH_MM_SS { get; set; } = new SI0005B_W_HORA_HH_MM_SS();
            public class SI0005B_W_HORA_HH_MM_SS : VarBasis
            {
                /*"       15 W-HORA-HH-MM-SS-HH         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-SS         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HHMM.*/
            }
            public SI0005B_W_HORA_HHMM W_HORA_HHMM { get; set; } = new SI0005B_W_HORA_HHMM();
            public class SI0005B_W_HORA_HHMM : VarBasis
            {
                /*"       15 W-HORA-HHMM-HH             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-HHMM-MM             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-AAAAMMDD.*/
            }
            public SI0005B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SI0005B_W_DATA_AAAAMMDD();
            public class SI0005B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"       10 W-DATA-AAAAMMDD-AAAA       PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 W-DATA-AAAAMMDD-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-AAAAMMDD-DD         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-DD-MM-AAAA.*/
            }
            public SI0005B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0005B_W_DATA_DD_MM_AAAA();
            public class SI0005B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       10 W-DATA-DD-MM-AAAA-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-DD-MM-AAAA-DD-F1    PIC X(01)       VALUE '/'.*/
                public StringBasis W_DATA_DD_MM_AAAA_DD_F1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-DD-MM-AAAA-DD-F2    PIC X(01)       VALUE '/'.*/
                public StringBasis W_DATA_DD_MM_AAAA_DD_F2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-DATA-AAAA-MM-DD.*/
            }
            public SI0005B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0005B_W_DATA_AAAA_MM_DD();
            public class SI0005B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       10 W-DATA-AAAA-MM-DD-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 LC01.*/
            }
            public SI0005B_LC01 LC01 { get; set; } = new SI0005B_LC01();
            public class SI0005B_LC01 : VarBasis
            {
                /*"       10 LC01-RELATORIO             PIC X(07) VALUE 'SI0005B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI0005B");
                /*"       10 FILLER                     PIC X(36) VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"");
                /*"       10 LC01-EMPRESA               PIC X(40) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(34) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"       10 FILLER                     PIC X(11) VALUE 'PAGINA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PAGINA");
                /*"       10 LC01-PAGINA                PIC ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    05 LC01-X.*/
            }
            public SI0005B_LC01_X LC01_X { get; set; } = new SI0005B_LC01_X();
            public class SI0005B_LC01_X : VarBasis
            {
                /*"       10 FILELR                     PIC X(07) VALUE 'SI0005B'.*/
                public StringBasis FILELR { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI0005B");
                /*"       10 FILLER                     PIC X(36) VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"");
                /*"       10 LC01-X-EMPRESA             PIC X(40) VALUE  SPACES.*/
                public StringBasis LC01_X_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(34) VALUE  SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"       10 FILLER                     PIC X(11) VALUE 'PAGINA'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PAGINA");
                /*"       10 LC01-X-PAGINA              PIC ZZZ9.*/
                public IntBasis LC01_X_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    05 LC02.*/
            }
            public SI0005B_LC02 LC02 { get; set; } = new SI0005B_LC02();
            public class SI0005B_LC02 : VarBasis
            {
                /*"       10 FILLER                     PIC X(103) VALUE  SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "103", "X(103)"), @"");
                /*"       10 FILLER                     PIC X(19)  VALUE          'DATA SISTEMA (SI): '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA SISTEMA (SI): ");
                /*"       10 LC02-DATA-SISTEMA          PIC X(10)   VALUE SPACES.*/
                public StringBasis LC02_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC02-A.*/
            }
            public SI0005B_LC02_A LC02_A { get; set; } = new SI0005B_LC02_A();
            public class SI0005B_LC02_A : VarBasis
            {
                /*"       10 FILLER                     PIC X(103) VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "103", "X(103)"), @"");
                /*"       10 FILLER                     PIC X(19)  VALUE          'DATA CORRENTE    : '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA CORRENTE    : ");
                /*"       10 LC02-DATA-CORRENTE         PIC X(10)   VALUE SPACES.*/
                public StringBasis LC02_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC03.*/
            }
            public SI0005B_LC03 LC03 { get; set; } = new SI0005B_LC03();
            public class SI0005B_LC03 : VarBasis
            {
                /*"       10 FILLER                     PIC X(25) VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
                /*"       10 FILLER                     PIC X(51) VALUE         'RELATORIO DE CRITICA - AVISO DE SINISTRO - LOTERICO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"RELATORIO DE CRITICA - AVISO DE SINISTRO - LOTERICO");
                /*"       10 FILLER                     PIC X(27) VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"");
                /*"       10 FILLER                     PIC X(18) VALUE          'HORA             :'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"HORA             :");
                /*"       10 FILLER                     PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"       10 LC03-HORA                  PIC X(08) VALUE ' '.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" ");
                /*"    05 LC03-X.*/
            }
            public SI0005B_LC03_X LC03_X { get; set; } = new SI0005B_LC03_X();
            public class SI0005B_LC03_X : VarBasis
            {
                /*"       10 FILLER                     PIC X(23) VALUE  SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
                /*"       10 FILLER                     PIC X(53) VALUE       'SINISTROS AVISADOS NO DIA E ADIANTAMENTOS PENDENTES  '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "53", "X(53)"), @"SINISTROS AVISADOS NO DIA E ADIANTAMENTOS PENDENTES  ");
                /*"       10 FILLER                     PIC X(27) VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"");
                /*"       10 FILLER                     PIC X(18) VALUE          'HORA             :'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"HORA             :");
                /*"       10 FILLER                     PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"       10 LC03-X-HORA                PIC X(08) VALUE ' '.*/
                public StringBasis LC03_X_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" ");
                /*"    05 LC03-A.*/
            }
            public SI0005B_LC03_A LC03_A { get; set; } = new SI0005B_LC03_A();
            public class SI0005B_LC03_A : VarBasis
            {
                /*"       10 FILLER                     PIC X(25) VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
                /*"       10 FILLER                     PIC X(50) VALUE         'PROCESSAMENTO DO ARQUIVO GERADO PELO PRESTADOR EM '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"PROCESSAMENTO DO ARQUIVO GERADO PELO PRESTADOR EM ");
                /*"       10 LC03-DATA-GERACAO          PIC X(10) VALUE  SPACES.*/
                public StringBasis LC03_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC04.*/
            }
            public SI0005B_LC04 LC04 { get; set; } = new SI0005B_LC04();
            public class SI0005B_LC04 : VarBasis
            {
                /*"       10 FILLER                     PIC X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    05 LC05.*/
            }
            public SI0005B_LC05 LC05 { get; set; } = new SI0005B_LC05();
            public class SI0005B_LC05 : VarBasis
            {
                /*"       10 FILLER                     PIC X(13) VALUE          'NUM. SINSTRO '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NUM. SINSTRO ");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(13) VALUE          '     LOTERICO'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"     LOTERICO");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(40) VALUE          'NOME'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"NOME");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(10) VALUE          'DT. OCORR.'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT. OCORR.");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(10) VALUE          ' INFORMADO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" INFORMADO");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(10) VALUE          'VL AVISADO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VL AVISADO");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(10) VALUE          'VL. ADIANT'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VL. ADIANT");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(08) VALUE          'MENSAGEM'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"MENSAGEM");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    05 LC-BRANCO.*/
            }
            public SI0005B_LC_BRANCO LC_BRANCO { get; set; } = new SI0005B_LC_BRANCO();
            public class SI0005B_LC_BRANCO : VarBasis
            {
                /*"       10 FILLER                     PIC X(132) VALUE ' '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @" ");
                /*"    05 LD01.*/
            }
            public SI0005B_LD01 LD01 { get; set; } = new SI0005B_LD01();
            public class SI0005B_LD01 : VarBasis
            {
                /*"       10 FILLER                     PIC X(09)  VALUE          'COD CEF: '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"COD CEF: ");
                /*"       10 LD01-COD-LOT-CEF           PIC X(13).*/
                public StringBasis LD01_COD_LOT_CEF { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-NOME                  PIC X(40)  VALUE ' '.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(09)  VALUE          'DT OCOR. '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DT OCOR. ");
                /*"       10 LD01-DATA-OCORRENCIA       PIC X(08).*/
                public StringBasis LD01_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(09)  VALUE          'HS OCOR. '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"HS OCOR. ");
                /*"       10 LD01-HORA-OCORRENCIA       PIC X(06).*/
                public StringBasis LD01_HORA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(09)  VALUE          'DT GERA. '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DT GERA. ");
                /*"       10 LD01-DATA-GERACAO          PIC X(08).*/
                public StringBasis LD01_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    05 LD01-A.*/
            }
            public SI0005B_LD01_A LD01_A { get; set; } = new SI0005B_LD01_A();
            public class SI0005B_LD01_A : VarBasis
            {
                /*"       10 FILLER                     PIC X(05)  VALUE ' '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @" ");
                /*"       10 FILLER                     PIC X(09)  VALUE          'DT AVISO '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DT AVISO ");
                /*"       10 LD01-DATA-AVISO            PIC X(08).*/
                public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(09)  VALUE          'HS AVISO '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"HS AVISO ");
                /*"       10 LD01-HORA-AVISO            PIC X(06).*/
                public StringBasis LD01_HORA_AVISO { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(09)  VALUE          'VL INFO. '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"VL INFO. ");
                /*"       10 LD01-VALOR-INFORMADO       PIC 9(13)V99.*/
                public DoubleBasis LD01_VALOR_INFORMADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(09)  VALUE          'NATUREZA '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NATUREZA ");
                /*"       10 LD01-COD-NATUREZA          PIC X(02).*/
                public StringBasis LD01_COD_NATUREZA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10 FILLER                     PIC X(01)  VALUE ' '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(06)  VALUE          'CAUSA '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CAUSA ");
                /*"       10 LD01-COD-CAUSA             PIC X(02).*/
                public StringBasis LD01_COD_CAUSA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10 FILLER                     PIC X(05)  VALUE '*****'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"*****");
                /*"       10 LD01-MENSAGEM              PIC X(50).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 LD02.*/
            }
            public SI0005B_LD02 LD02 { get; set; } = new SI0005B_LD02();
            public class SI0005B_LD02 : VarBasis
            {
                /*"       10 LD02-NUM-APOL-SINISTRO     PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD02_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD02-COD-LOT-CEF           PIC ZZZZZZZZZZZZ9.*/
                public IntBasis LD02_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD02-NOME                  PIC X(40) VALUE ' '.*/
                public StringBasis LD02_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD02-DATA-OCORRENCIA       PIC X(10) VALUE ' '.*/
                public StringBasis LD02_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD02-VALOR-INFORMADO       PIC ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VALOR_INFORMADO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD02-VALOR-REGISTRADO      PIC ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VALOR_REGISTRADO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD02-VALOR-ADIANTAMENTO    PIC ZZZ.ZZ9,99.*/
                public DoubleBasis LD02_VALOR_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD02-MENSAGEM              PIC X(32) VALUE ' '.*/
                public StringBasis LD02_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @" ");
                /*"    05 LD03.*/
            }
            public SI0005B_LD03 LD03 { get; set; } = new SI0005B_LD03();
            public class SI0005B_LD03 : VarBasis
            {
                /*"       10 FILLER                     PIC X(04) VALUE '*** '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"*** ");
                /*"       10 LD03-AAAA.*/
                public SI0005B_LD03_AAAA LD03_AAAA { get; set; } = new SI0005B_LD03_AAAA();
                public class SI0005B_LD03_AAAA : VarBasis
                {
                    /*"          15 LD03-TITULO-1           PIC X(45).*/
                    public StringBasis LD03_TITULO_1 { get; set; } = new StringBasis(new PIC("X", "45", "X(45)."), @"");
                    /*"          15 LD03-DATA-TITULO-1      PIC X(10).*/
                    public StringBasis LD03_DATA_TITULO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"          15 FILLER                  PIC X(73).*/
                    public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "73", "X(73)."), @"");
                    /*"       10 LD03-BBBB       REDEFINES  LD03-AAAA.*/
                }
                private _REDEF_SI0005B_LD03_BBBB _ld03_bbbb { get; set; }
                public _REDEF_SI0005B_LD03_BBBB LD03_BBBB
                {
                    get { _ld03_bbbb = new _REDEF_SI0005B_LD03_BBBB(); _.Move(LD03_AAAA, _ld03_bbbb); VarBasis.RedefinePassValue(LD03_AAAA, _ld03_bbbb, LD03_AAAA); _ld03_bbbb.ValueChanged += () => { _.Move(_ld03_bbbb, LD03_AAAA); }; return _ld03_bbbb; }
                    set { VarBasis.RedefinePassValue(value, _ld03_bbbb, LD03_AAAA); }
                }  //Redefines
                public class _REDEF_SI0005B_LD03_BBBB : VarBasis
                {
                    /*"          15 LD03-TITULO-2           PIC X(22).*/
                    public StringBasis LD03_TITULO_2 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
                    /*"          15 LD03-DATA-TITULO-2      PIC X(10).*/
                    public StringBasis LD03_DATA_TITULO_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"          15 FILLER                  PIC X(96).*/
                    public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "96", "X(96)."), @"");
                    /*"    05 LD04.*/

                    public _REDEF_SI0005B_LD03_BBBB()
                    {
                        LD03_TITULO_2.ValueChanged += OnValueChanged;
                        LD03_DATA_TITULO_2.ValueChanged += OnValueChanged;
                        FILLER_75.ValueChanged += OnValueChanged;
                    }

                }
            }
            public SI0005B_LD04 LD04 { get; set; } = new SI0005B_LD04();
            public class SI0005B_LD04 : VarBasis
            {
                /*"       10 FILLER                     PIC X(05) VALUE ' '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @" ");
                /*"       10 FILLER                     PIC X(10) VALUE          'C/C HOJE: '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"C/C HOJE: ");
                /*"       10 LD04-BANCO                 PIC 9(03) VALUE ZEROS.*/
                public IntBasis LD04_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 LD04-AGENCIA               PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD04_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 LD04-OPERACAO              PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD04_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 LD04-CONTA                 PIC 999.999.999.999.*/
                public IntBasis LD04_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "999.999.999.999."));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 LD04-DV                    PIC X(01) VALUE ' '.*/
                public StringBasis LD04_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(16) VALUE          'QTD. SIN. AV. : '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"QTD. SIN. AV. : ");
                /*"       10 LD04-QTD-SIN-AVISADO       PIC 9(03) VALUE ZEROS.*/
                public IntBasis LD04_QTD_SIN_AVISADO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(16) VALUE          'QTD. SIN. PG. : '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"QTD. SIN. PG. : ");
                /*"       10 LD04-QTD-SIN-PAGOS         PIC 9(03) VALUE ZEROS.*/
                public IntBasis LD04_QTD_SIN_PAGOS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD04-MENSAGEM              PIC X(65) VALUE ZEROS.*/
                public StringBasis LD04_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "65", "X(65)"), @"");
                /*"    05 LD05.*/
            }
            public SI0005B_LD05 LD05 { get; set; } = new SI0005B_LD05();
            public class SI0005B_LD05 : VarBasis
            {
                /*"       10 FILLER                     PIC X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    05 LT00.*/
            }
            public SI0005B_LT00 LT00 { get; set; } = new SI0005B_LT00();
            public class SI0005B_LT00 : VarBasis
            {
                /*"       10 FILLER                     PIC X(25) VALUE          '** TOTAIS DE CONTROLE  **'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"** TOTAIS DE CONTROLE  **");
                /*"    05 LT01.*/
            }
            public SI0005B_LT01 LT01 { get; set; } = new SI0005B_LT01();
            public class SI0005B_LT01 : VarBasis
            {
                /*"       10 FILLER                     PIC X(30) VALUE          '  LIDOS              ........ '.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"  LIDOS              ........ ");
                /*"       10 LT01-LIDOS               PIC  ZZZZ.ZZ9.*/
                public IntBasis LT01_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                /*"    05 LT02.*/
            }
            public SI0005B_LT02 LT02 { get; set; } = new SI0005B_LT02();
            public class SI0005B_LT02 : VarBasis
            {
                /*"       10 FILLER                     PIC X(30) VALUE          '  REJEITADOS         ........ '.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"  REJEITADOS         ........ ");
                /*"       10 LT02-REJEITADOS          PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_REJEITADOS { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05 LT03.*/
            }
            public SI0005B_LT03 LT03 { get; set; } = new SI0005B_LT03();
            public class SI0005B_LT03 : VarBasis
            {
                /*"       10 FILLER                     PIC X(30) VALUE          '  AVISADOS SEM ALTERACAO .... '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"  AVISADOS SEM ALTERACAO .... ");
                /*"       10 LT03-AVISADOS-SEM-ALETRACAO PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_AVISADOS_SEM_ALETRACAO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05 LT04.*/
            }
            public SI0005B_LT04 LT04 { get; set; } = new SI0005B_LT04();
            public class SI0005B_LT04 : VarBasis
            {
                /*"       10 FILLER                     PIC X(30) VALUE          '  AVISADOS COM ALTERACAO .... '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"  AVISADOS COM ALTERACAO .... ");
                /*"       10 LT03-AVISADOS-COM-ALETRACAO PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_AVISADOS_COM_ALETRACAO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05 WABEND.*/
            }
            public SI0005B_WABEND WABEND { get; set; } = new SI0005B_WABEND();
            public class SI0005B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI0005B_WABEND1 WABEND1 { get; set; } = new SI0005B_WABEND1();
                public class SI0005B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SI0005B '.*/
                    public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI0005B ");
                    /*"       07 WABEND2.*/
                    public SI0005B_WABEND2 WABEND2 { get; set; } = new SI0005B_WABEND2();
                    public class SI0005B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI0005B_WABEND3 WABEND3 { get; set; } = new SI0005B_WABEND3();
                        public class SI0005B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                            /*"       10 WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                            /*"01          LK1-LINK.*/
                        }
                    }
                    public SI0005B_LK1_LINK LK1_LINK { get; set; } = new SI0005B_LK1_LINK();
                    public class SI0005B_LK1_LINK : VarBasis
                    {
                        /*"  03        LK1-RTCODE          PIC  S9(004)   VALUE +0   COMP.*/
                        public IntBasis LK1_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"  03        LK1-TAMANHO         PIC  S9(004)   VALUE +40  COMP.*/
                        public IntBasis LK1_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                        /*"  03        LK1-TITULO          PIC   X(132)   VALUE  SPACES.*/
                        public StringBasis LK1_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                        /*"01 LK2-LINK.*/
                    }
                    public SI0005B_LK2_LINK LK2_LINK { get; set; } = new SI0005B_LK2_LINK();
                    public class SI0005B_LK2_LINK : VarBasis
                    {
                        /*"   05 LK2-RTCODE                   PIC S9(04) COMP VALUE +0.*/
                        public IntBasis LK2_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                        /*"   05 LK2-LOTERI01-NUM-APOLICE     PIC  9(13).*/
                        public IntBasis LK2_LOTERI01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                        /*"   05 LK2-AV-COD-NATUREZA          PIC  X(02).*/
                        public StringBasis LK2_AV_COD_NATUREZA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                        /*"   05 LK2-LOTERI01-COD-LOT-CEF     PIC  9(13).*/
                        public IntBasis LK2_LOTERI01_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                        /*"   05 LK2-LOTERI01-COD-LOT-FENAL   PIC  9(13).*/
                        public IntBasis LK2_LOTERI01_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                        /*"   05 LK2-IMP-SEGURADA-IX          PIC S9(13)V99 COMP-3 VALUE +0*/
                        public DoubleBasis LK2_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                        /*"   05 LK2-DATA-INIVIGENCIA         PIC  X(10).*/
                        public StringBasis LK2_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                        /*"   05 LK2-DATA-TERVIGENCIA         PIC  X(10).*/
                        public StringBasis LK2_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                        /*"   05 LK2-W-HOST-VALOR-SALDO-IS    PIC S9(13)V99 COMP-3 VALUE +0*/
                        public DoubleBasis LK2_W_HOST_VALOR_SALDO_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                        /*"   05 LK2-W-HOST-VAL-AVISOS        PIC S9(13)V99 COMP-3 VALUE +0*/
                        public DoubleBasis LK2_W_HOST_VAL_AVISOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                        /*"   05 LK2-W-HOST-INDENIZ-EFETIV    PIC S9(13)V99 COMP-3 VALUE +0*/
                        public DoubleBasis LK2_W_HOST_INDENIZ_EFETIV { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                        /*"01 CA1-DATA.*/
                    }
                    public SI0005B_CA1_DATA CA1_DATA { get; set; } = new SI0005B_CA1_DATA();
                    public class SI0005B_CA1_DATA : VarBasis
                    {
                        /*"   05 CA-PARM-PROSOMC1.*/
                        public SI0005B_CA_PARM_PROSOMC1 CA_PARM_PROSOMC1 { get; set; } = new SI0005B_CA_PARM_PROSOMC1();
                        public class SI0005B_CA_PARM_PROSOMC1 : VarBasis
                        {
                            /*"      10 CA-DATA-INF-PROSOMC1.*/
                            public SI0005B_CA_DATA_INF_PROSOMC1 CA_DATA_INF_PROSOMC1 { get; set; } = new SI0005B_CA_DATA_INF_PROSOMC1();
                            public class SI0005B_CA_DATA_INF_PROSOMC1 : VarBasis
                            {
                                /*"         15 CA-DIA-MOV         PIC 9(02)     VALUE ZEROS.*/
                                public IntBasis CA_DIA_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                                /*"         15 CA-MES-MOV         PIC 9(02)     VALUE ZEROS.*/
                                public IntBasis CA_MES_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                                /*"         15 CA-ANO-MOV         PIC 9(04)     VALUE ZEROS.*/
                                public IntBasis CA_ANO_MOV { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                                /*"      10 CA-DIAS-PROSOMC1      PIC S9(05)    VALUE ZEROS COMP-3.*/
                            }
                            public IntBasis CA_DIAS_PROSOMC1 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
                            /*"      10 CA-DATA-RET-PROSOMC1.*/
                            public SI0005B_CA_DATA_RET_PROSOMC1 CA_DATA_RET_PROSOMC1 { get; set; } = new SI0005B_CA_DATA_RET_PROSOMC1();
                            public class SI0005B_CA_DATA_RET_PROSOMC1 : VarBasis
                            {
                                /*"         15 CA-DIA-MOV         PIC 9(02)     VALUE ZEROS.*/
                                public IntBasis CA_DIA_MOV_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                                /*"         15 CA-MES-MOV         PIC 9(02)     VALUE ZEROS.*/
                                public IntBasis CA_MES_MOV_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                                /*"         15 CA-ANO-MOV         PIC 9(04)     VALUE ZEROS.*/
                                public IntBasis CA_ANO_MOV_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                                /*"   05 CA-DATA-INTER.*/
                            }
                        }
                        public SI0005B_CA_DATA_INTER CA_DATA_INTER { get; set; } = new SI0005B_CA_DATA_INTER();
                        public class SI0005B_CA_DATA_INTER : VarBasis
                        {
                            /*"      10 CA-ANO-MOV            PIC 9(04)     VALUE ZEROS.*/
                            public IntBasis CA_ANO_MOV_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                            /*"      10 HIFEN-1               PIC X(01)     VALUE '-'.*/
                            public StringBasis HIFEN_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                            /*"      10 CA-MES-MOV            PIC 9(02)     VALUE ZEROS.*/
                            public IntBasis CA_MES_MOV_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                            /*"      10 HIFEN-2               PIC X(01)     VALUE '-'.*/
                            public StringBasis HIFEN_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                            /*"      10 CA-DIA-MOV            PIC 9(02)     VALUE ZEROS.*/
                            public IntBasis CA_DIA_MOV_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                            /*"01  WS-COD-LOT-CEF             PIC  X(13) VALUE SPACES.*/
                        }
                    }
                    public StringBasis WS_COD_LOT_CEF { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                    /*"01  WS-COD-LOT-CEF-REDF   REDEFINES  WS-COD-LOT-CEF.*/
                    private _REDEF_SI0005B_WS_COD_LOT_CEF_REDF _ws_cod_lot_cef_redf { get; set; }
                    public _REDEF_SI0005B_WS_COD_LOT_CEF_REDF WS_COD_LOT_CEF_REDF
                    {
                        get { _ws_cod_lot_cef_redf = new _REDEF_SI0005B_WS_COD_LOT_CEF_REDF(); _.Move(WS_COD_LOT_CEF, _ws_cod_lot_cef_redf); VarBasis.RedefinePassValue(WS_COD_LOT_CEF, _ws_cod_lot_cef_redf, WS_COD_LOT_CEF); _ws_cod_lot_cef_redf.ValueChanged += () => { _.Move(_ws_cod_lot_cef_redf, WS_COD_LOT_CEF); }; return _ws_cod_lot_cef_redf; }
                        set { VarBasis.RedefinePassValue(value, _ws_cod_lot_cef_redf, WS_COD_LOT_CEF); }
                    }  //Redefines
                    public class _REDEF_SI0005B_WS_COD_LOT_CEF_REDF : VarBasis
                    {
                        /*"    03  WS-COD-LOT-CEF-NUMERIC PIC  9(13).*/
                        public IntBasis WS_COD_LOT_CEF_NUMERIC { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                        /*"01  WS-ERRO                    PIC  9(01) VALUE ZEROS.*/

                        public _REDEF_SI0005B_WS_COD_LOT_CEF_REDF()
                        {
                            WS_COD_LOT_CEF_NUMERIC.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                    /*"01  WS-CONT-PEPS               PIC S9(04) VALUE ZEROS COMP.*/
                    public IntBasis WS_CONT_PEPS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"01  WS-GE0530S                 PIC  X(07) VALUE 'GE0530S'.*/
                    public StringBasis WS_GE0530S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"GE0530S");
                }
            }
        }


        public Copies.LBSI0005 LBSI0005 { get; set; } = new Copies.LBSI0005();
        public Copies.LBGE0530 LBGE0530 { get; set; } = new Copies.LBGE0530();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.OUTROCOB OUTROCOB { get; set; } = new Dclgens.OUTROCOB();
        public Dclgens.SILOTDC2 SILOTDC2 { get; set; } = new Dclgens.SILOTDC2();
        public Dclgens.SINLOTDO SINLOTDO { get; set; } = new Dclgens.SINLOTDO();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.SINISACO SINISACO { get; set; } = new Dclgens.SINISACO();
        public Dclgens.SINISCON SINISCON { get; set; } = new Dclgens.SINISCON();
        public Dclgens.LOTISG01 LOTISG01 { get; set; } = new Dclgens.LOTISG01();
        public Dclgens.SIPARADI SIPARADI { get; set; } = new Dclgens.SIPARADI();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.SIMOLOT1 SIMOLOT1 { get; set; } = new Dclgens.SIMOLOT1();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.LOTCOB01 LOTCOB01 { get; set; } = new Dclgens.LOTCOB01();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.PRAZOSEG PRAZOSEG { get; set; } = new Dclgens.PRAZOSEG();
        public Dclgens.GEPESSOA GEPESSOA { get; set; } = new Dclgens.GEPESSOA();
        public Dclgens.GEPESJUR GEPESJUR { get; set; } = new Dclgens.GEPESJUR();
        public SI0005B_SINISTRO_APOL SINISTRO_APOL { get; set; } = new SI0005B_SINISTRO_APOL();
        public SI0005B_DOCUMENTOS DOCUMENTOS { get; set; } = new SI0005B_DOCUMENTOS();
        public SI0005B_ADIANT_PEND ADIANT_PEND { get; set; } = new SI0005B_ADIANT_PEND();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string AVISO_FILE_NAME_P, string RETORNO_FILE_NAME_P, string RCRITICA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                AVISO.SetFile(AVISO_FILE_NAME_P);
                RETORNO.SetFile(RETORNO_FILE_NAME_P);
                RCRITICA.SetFile(RCRITICA_FILE_NAME_P);

                /*" -880- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -881- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -882- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -886- OPEN INPUT AVISO. */
                AVISO.Open(REGISTRO_AVISO);

                /*" -890- OPEN OUTPUT RCRITICA RETORNO RAVISOOK. */
                RCRITICA.Open(REGISTRO_CRITICA);
                RETORNO.Open(REGISTRO_RETORNO);
                RAVISOOK.Open(REGISTRO_AVISOOK);

                /*" -892- PERFORM R010-LE-SISTEMAS THRU R010-EXIT. */

                R010_LE_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -894- PERFORM R020-LE-MONTA-NOME-EMPRESA THRU R020-EXIT. */

                R020_LE_MONTA_NOME_EMPRESA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -898- PERFORM R030-SELECT-FONTES THRU R030-EXIT. */

                R030_SELECT_FONTES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/


                /*" -900- MOVE 'NAO' TO W-CHAVE-TEM-ADIANT-PENDENTE. */
                _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_ADIANT_PENDENTE);

                /*" -902- PERFORM R2000-ADIANT-PENDENTES THRU R2000-EXIT. */

                R2000_ADIANT_PENDENTES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/


                /*" -903- IF W-CHAVE-TEM-ADIANT-PENDENTE EQUAL 'NAO' */

                if (AREA_DE_WORK.W_CHAVE_TEM_ADIANT_PENDENTE == "NAO")
                {

                    /*" -904- IF W-CONTA-LINHA-AVISOOK GREATER 60 */

                    if (AREA_DE_WORK.W_CONTA_LINHA_AVISOOK > 60)
                    {

                        /*" -905- PERFORM R9005-IMPRIME-CABEC-AVISOOK THRU R9005-EXIT */

                        R9005_IMPRIME_CABEC_AVISOOK(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9005_EXIT*/


                        /*" -907- END-IF */
                    }


                    /*" -910- MOVE 'SEM ADIANTAMENTOS PENDENTES NA DATA DE HOJE' TO LD02 */
                    _.Move("SEM ADIANTAMENTOS PENDENTES NA DATA DE HOJE", AREA_DE_WORK.LD02);

                    /*" -912- WRITE REGISTRO-AVISOOK FROM LD02 AFTER 2 */
                    _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REGISTRO_AVISOOK);

                    RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

                    /*" -914- MOVE SPACES TO LD02 */
                    _.Move("", AREA_DE_WORK.LD02);

                    /*" -916- WRITE REGISTRO-AVISOOK FROM LC-BRANCO AFTER 2 */
                    _.Move(AREA_DE_WORK.LC_BRANCO.GetMoveValues(), REGISTRO_AVISOOK);

                    RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

                    /*" -917- ADD 4 TO W-CONTA-LINHA-AVISOOK */
                    AREA_DE_WORK.W_CONTA_LINHA_AVISOOK.Value = AREA_DE_WORK.W_CONTA_LINHA_AVISOOK + 4;

                    /*" -919- END-IF. */
                }


                /*" -920- MOVE 'SINISTROS AVISADOS EM ' TO LD03-TITULO-2 */
                _.Move("SINISTROS AVISADOS EM ", AREA_DE_WORK.LD03.LD03_BBBB.LD03_TITULO_2);

                /*" -921- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

                /*" -922- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

                /*" -923- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

                /*" -924- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

                /*" -926- MOVE W-DATA-DD-MM-AAAA TO LD03-DATA-TITULO-2. */
                _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD03.LD03_BBBB.LD03_DATA_TITULO_2);

                /*" -927- IF W-CONTA-LINHA-AVISOOK GREATER 60 */

                if (AREA_DE_WORK.W_CONTA_LINHA_AVISOOK > 60)
                {

                    /*" -928- PERFORM R9005-IMPRIME-CABEC-AVISOOK THRU R9005-EXIT */

                    R9005_IMPRIME_CABEC_AVISOOK(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9005_EXIT*/


                    /*" -930- END-IF. */
                }


                /*" -932- WRITE REGISTRO-AVISOOK FROM LD03 AFTER 2. */
                _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REGISTRO_AVISOOK);

                RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

                /*" -934- ADD 1 TO W-CONTA-LINHA-AVISOOK. */
                AREA_DE_WORK.W_CONTA_LINHA_AVISOOK.Value = AREA_DE_WORK.W_CONTA_LINHA_AVISOOK + 1;

                /*" -938- MOVE 'NAO' TO WFIM-ARQAVISO W-CHAVE-TEM-SINI-AVISADO W-CHAVE-TEM-SINI-CRITICA. */
                _.Move("NAO", AREA_DE_WORK.WFIM_ARQAVISO, AREA_DE_WORK.W_CHAVE_TEM_SINI_AVISADO, AREA_DE_WORK.W_CHAVE_TEM_SINI_CRITICA);

                /*" -940- PERFORM R040-LE-ARQAVISO THRU R040-EXIT. */

                R040_LE_ARQAVISO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/


                /*" -943- PERFORM R100-PROCESSA-ARQAVISO THRU R100-EXIT UNTIL WFIM-ARQAVISO EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_ARQAVISO == "SIM"))
                {

                    R100_PROCESSA_ARQAVISO(true);

                    R100_LE_NOVO_REGISTRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -947- PERFORM R050-ALTERA-FONTES THRU R050-EXIT. */

                R050_ALTERA_FONTES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/


                /*" -948- IF W-CHAVE-TEM-SINI-AVISADO EQUAL 'NAO' */

                if (AREA_DE_WORK.W_CHAVE_TEM_SINI_AVISADO == "NAO")
                {

                    /*" -949- IF W-CONTA-LINHA-AVISOOK GREATER 60 */

                    if (AREA_DE_WORK.W_CONTA_LINHA_AVISOOK > 60)
                    {

                        /*" -950- PERFORM R9005-IMPRIME-CABEC-AVISOOK THRU R9005-EXIT */

                        R9005_IMPRIME_CABEC_AVISOOK(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9005_EXIT*/


                        /*" -952- END-IF */
                    }


                    /*" -955- MOVE 'SEM SINISTROS AVISADOS NO PROCESSAMENTO DE HOJE' TO LD02 */
                    _.Move("SEM SINISTROS AVISADOS NO PROCESSAMENTO DE HOJE", AREA_DE_WORK.LD02);

                    /*" -956- WRITE REGISTRO-AVISOOK FROM LD02 AFTER 2 */
                    _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REGISTRO_AVISOOK);

                    RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

                    /*" -958- END-IF. */
                }


                /*" -959- IF W-CHAVE-TEM-SINI-CRITICA EQUAL 'NAO' */

                if (AREA_DE_WORK.W_CHAVE_TEM_SINI_CRITICA == "NAO")
                {

                    /*" -960- IF W-CONTA-LINHA GREATER 60 */

                    if (AREA_DE_WORK.W_CONTA_LINHA > 60)
                    {

                        /*" -961- PERFORM R9000-CABECALHO-CRITICA THRU R9000-EXIT */

                        R9000_CABECALHO_CRITICA(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_EXIT*/


                        /*" -963- END-IF */
                    }


                    /*" -966- MOVE 'MOV. DE AVISO SIN. LOTERICO - SEM CRITICA' TO LD01-A */
                    _.Move("MOV. DE AVISO SIN. LOTERICO - SEM CRITICA", AREA_DE_WORK.LD01_A);

                    /*" -967- WRITE REGISTRO-CRITICA FROM LD01-A AFTER 3 */
                    _.Move(AREA_DE_WORK.LD01_A.GetMoveValues(), REGISTRO_CRITICA);

                    RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

                    /*" -969- END-IF. */
                }


                /*" -970- DISPLAY ' ' . */
                _.Display($" ");

                /*" -971- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -972- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -973- DISPLAY '*           SI0005B                 *' . */
                _.Display($"*           SI0005B                 *");

                /*" -974- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -975- DISPLAY '*  TERMINO NORMAL DE PROCESSAMENTO  *' . */
                _.Display($"*  TERMINO NORMAL DE PROCESSAMENTO  *");

                /*" -976- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -977- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -978- DISPLAY '*QTD. DE SINISTRO CONSULTADO "PEPS" *'. */

                $"*QTD. DE SINISTRO CONSULTADO PEPS *"
                .Display();

                /*" -979- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -980- DISPLAY '* QTD. DE CONSULTAS :' WS-CONT-PEPS */
                _.Display($"* QTD. DE CONSULTAS :{AREA_DE_WORK.WABEND.WABEND1.WS_CONT_PEPS}");

                /*" -982- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -987- CLOSE AVISO RETORNO RAVISOOK RCRITICA. */
                AVISO.Close();
                RETORNO.Close();
                RAVISOOK.Close();
                RCRITICA.Close();

                /*" -987- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1002- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -1002- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R010-LE-SISTEMAS */
        private void R010_LE_SISTEMAS(bool isPerform = false)
        {
            /*" -1010- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1012- DISPLAY WS-VERSAO. */
            _.Display(WS_VERSAO);

            /*" -1022- PERFORM R010_LE_SISTEMAS_DB_SELECT_1 */

            R010_LE_SISTEMAS_DB_SELECT_1();

            /*" -1025- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1026- DISPLAY 'SI0005B - ERRO ACESSO A SISTEMAS' */
                _.Display($"SI0005B - ERRO ACESSO A SISTEMAS");

                /*" -1027- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1031- END-IF. */
            }


            /*" -1032- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1038- DISPLAY 'DATA DO SISTEMA SI : ' SISTEMAS-DATA-MOV-ABERTO(9:2) SISTEMAS-DATA-MOV-ABERTO(8:1) SISTEMAS-DATA-MOV-ABERTO(6:2) SISTEMAS-DATA-MOV-ABERTO(5:1) SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"DATA DO SISTEMA SI : {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -1040- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1041- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -1042- MOVE SISTEMAS-DATA-MOV-ABERTO(8:1) TO W-DATA-DD-MM-AAAA-DD-F1 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F1);

            /*" -1043- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -1044- MOVE SISTEMAS-DATA-MOV-ABERTO(5:1) TO W-DATA-DD-MM-AAAA-DD-F2 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F2);

            /*" -1046- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -1048- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA-SISTEMA. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC02.LC02_DATA_SISTEMA);

            /*" -1049- MOVE HOST-DATA-CORRENTE(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(HOST_DATA_CORRENTE.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -1050- MOVE HOST-DATA-CORRENTE(8:1) TO W-DATA-DD-MM-AAAA-DD-F1 */
            _.Move(HOST_DATA_CORRENTE.Substring(8, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F1);

            /*" -1051- MOVE HOST-DATA-CORRENTE(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(HOST_DATA_CORRENTE.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -1052- MOVE HOST-DATA-CORRENTE(5:1) TO W-DATA-DD-MM-AAAA-DD-F2 */
            _.Move(HOST_DATA_CORRENTE.Substring(5, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F2);

            /*" -1054- MOVE HOST-DATA-CORRENTE(1:4) TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(HOST_DATA_CORRENTE.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -1057- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA-CORRENTE LC03-DATA-GERACAO. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC02_A.LC02_DATA_CORRENTE, AREA_DE_WORK.LC03_A.LC03_DATA_GERACAO);

            /*" -1057- MOVE HOST-HORA-CORRENTE TO LC03-HORA LC03-X-HORA. */
            _.Move(HOST_HORA_CORRENTE, AREA_DE_WORK.LC03.LC03_HORA, AREA_DE_WORK.LC03_X.LC03_X_HORA);

        }

        [StopWatch]
        /*" R010-LE-SISTEMAS-DB-SELECT-1 */
        public void R010_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -1022- EXEC SQL SELECT DATA_MOV_ABERTO ,CURRENT DATE ,CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO ,:HOST-DATA-CORRENTE ,:HOST-HORA-CORRENTE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r010_LE_SISTEMAS_DB_SELECT_1_Query1 = new R010_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r010_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_DATA_CORRENTE, HOST_DATA_CORRENTE);
                _.Move(executed_1.HOST_HORA_CORRENTE, HOST_HORA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-LE-MONTA-NOME-EMPRESA */
        private void R020_LE_MONTA_NOME_EMPRESA(bool isPerform = false)
        {
            /*" -1068- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1074- PERFORM R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1 */

            R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1();

            /*" -1077- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1078- DISPLAY 'SI0005B - ERRO ACESSO A EMPRESAS' */
                _.Display($"SI0005B - ERRO ACESSO A EMPRESAS");

                /*" -1079- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1081- END-IF. */
            }


            /*" -1083- MOVE EMPRESAS-NOME-EMPRESA TO LK1-TITULO */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, AREA_DE_WORK.WABEND.WABEND1.LK1_LINK.LK1_TITULO);

            /*" -1085- CALL 'PROALN01' USING LK1-LINK */
            _.Call("PROALN01", AREA_DE_WORK.WABEND.WABEND1.LK1_LINK);

            /*" -1086- IF LK1-RTCODE NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WABEND.WABEND1.LK1_LINK.LK1_RTCODE != 00)
            {

                /*" -1087- DISPLAY 'PROBLEMA CHAMADA SUBROTINA V0EMPRESA' */
                _.Display($"PROBLEMA CHAMADA SUBROTINA V0EMPRESA");

                /*" -1088- DISPLAY 'RTCODE = ' LK1-RTCODE */
                _.Display($"RTCODE = {AREA_DE_WORK.WABEND.WABEND1.LK1_LINK.LK1_RTCODE}");

                /*" -1089- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1091- END-IF. */
            }


            /*" -1092- MOVE LK1-TITULO TO LC01-EMPRESA LC01-X-EMPRESA. */
            _.Move(AREA_DE_WORK.WABEND.WABEND1.LK1_LINK.LK1_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA, AREA_DE_WORK.LC01_X.LC01_X_EMPRESA);

        }

        [StopWatch]
        /*" R020-LE-MONTA-NOME-EMPRESA-DB-SELECT-1 */
        public void R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1()
        {
            /*" -1074- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 WITH UR END-EXEC. */

            var r020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1 = new R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1.Execute(r020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R030-SELECT-FONTES */
        private void R030_SELECT_FONTES(bool isPerform = false)
        {
            /*" -1102- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1107- PERFORM R030_SELECT_FONTES_DB_SELECT_1 */

            R030_SELECT_FONTES_DB_SELECT_1();

            /*" -1110- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1111- DISPLAY 'ERRO DE ACESSO NA FONTE - ACESSO NUM. PROTOCOLO' */
                _.Display($"ERRO DE ACESSO NA FONTE - ACESSO NUM. PROTOCOLO");

                /*" -1111- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R030-SELECT-FONTES-DB-SELECT-1 */
        public void R030_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -1107- EXEC SQL SELECT NUM_PROTOCOLO_SINI INTO :FONTES-NUM-PROTOCOLO-SINI FROM SEGUROS.FONTES WHERE COD_FONTE = 10 END-EXEC. */

            var r030_SELECT_FONTES_DB_SELECT_1_Query1 = new R030_SELECT_FONTES_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R030_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r030_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NUM_PROTOCOLO_SINI, FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R035-SELECT-NUMERO-AES */
        private void R035_SELECT_NUMERO_AES(bool isPerform = false)
        {
            /*" -1121- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1127- PERFORM R035_SELECT_NUMERO_AES_DB_SELECT_1 */

            R035_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -1130- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1131- DISPLAY 'ERRO SELECT NUMERO_AES ...................' */
                _.Display($"ERRO SELECT NUMERO_AES ...................");

                /*" -1131- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R035-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R035_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -1127- EXEC SQL SELECT SEQ_SINISTRO INTO :NUMERAES-SEQ-SINISTRO FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = 10 AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR END-EXEC. */

            var r035_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r035_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_SEQ_SINISTRO, NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R035_EXIT*/

        [StopWatch]
        /*" R040-LE-ARQAVISO */
        private void R040_LE_ARQAVISO(bool isPerform = false)
        {
            /*" -1141- MOVE 'R040' TO WNR-EXEC-SQL. */
            _.Move("R040", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1141- READ AVISO AT END */
            try
            {
                AVISO.Read(() =>
                {

                    /*" -1143- MOVE 'SIM' TO WFIM-ARQAVISO */
                    _.Move("SIM", AREA_DE_WORK.WFIM_ARQAVISO);

                    /*" -1145- GO TO R040-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/ //GOTO
                    return;
                });

                _.Move(AVISO.Value, REGISTRO_AVISO);
                _.Move(AVISO.Value, REGISTRO_HEADER);
                _.Move(AVISO.Value, REGISTRO_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1146- IF AV-TIPO-REGISTRO EQUAL 'D' */

            if (REGISTRO_AVISO.AV_TIPO_REGISTRO == "D")
            {

                /*" -1147- ADD 1 TO W-LIDOS */
                AREA_DE_WORK.W_LIDOS.Value = AREA_DE_WORK.W_LIDOS + 1;

                /*" -1149- END-IF */
            }


            /*" -1152- IF (AV-TIPO-REGISTRO NOT EQUAL 'A' ) AND (AV-TIPO-REGISTRO NOT EQUAL 'D' ) AND (AV-TIPO-REGISTRO NOT EQUAL 'T' ) */

            if ((REGISTRO_AVISO.AV_TIPO_REGISTRO != "A") && (REGISTRO_AVISO.AV_TIPO_REGISTRO != "D") && (REGISTRO_AVISO.AV_TIPO_REGISTRO != "T"))
            {

                /*" -1153- GO TO R040-LE-ARQAVISO */
                new Task(() => R040_LE_ARQAVISO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1155- END-IF */
            }


            /*" -1156- IF AV-TIPO-REGISTRO EQUAL 'T' */

            if (REGISTRO_AVISO.AV_TIPO_REGISTRO == "T")
            {

                /*" -1157- IF TR-QTD-REGISTROS NOT EQUAL W-LIDOS */

                if (REGISTRO_TRAILLER.TR_QTD_REGISTROS != AREA_DE_WORK.W_LIDOS)
                {

                    /*" -1158- DISPLAY 'QTD. DE REGISTROS DO MOVIMENTO DIFERE DA ' */
                    _.Display($"QTD. DE REGISTROS DO MOVIMENTO DIFERE DA ");

                    /*" -1159- DISPLAY 'QTD. DE REGISTROS PROCESSADOS            ' */
                    _.Display($"QTD. DE REGISTROS PROCESSADOS            ");

                    /*" -1160- DISPLAY 'QTD. DO TRAILLER = ' TR-QTD-REGISTROS */
                    _.Display($"QTD. DO TRAILLER = {REGISTRO_TRAILLER.TR_QTD_REGISTROS}");

                    /*" -1161- DISPLAY 'QTD. PROCESSADA  = ' W-LIDOS */
                    _.Display($"QTD. PROCESSADA  = {AREA_DE_WORK.W_LIDOS}");

                    /*" -1162- MOVE '040' TO WNR-EXEC-SQL */
                    _.Move("040", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                    /*" -1163- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -1164- ELSE */
                }
                else
                {


                    /*" -1165- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

                    /*" -1166- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-AAAAMMDD-AAAA */
                    _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

                    /*" -1167- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-AAAAMMDD-MM */
                    _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

                    /*" -1168- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-AAAAMMDD-DD */
                    _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

                    /*" -1169- MOVE W-DATA-AAAAMMDD TO TR-DATA-GERACAO */
                    _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, REGISTRO_TRAILLER.TR_DATA_GERACAO);

                    /*" -1170- MOVE '1' TO TR-INDICADOR-ORIGEM */
                    _.Move("1", REGISTRO_TRAILLER.TR_INDICADOR_ORIGEM);

                    /*" -1171- MOVE W-REG-GRAV-RETORNO TO TR-QTD-REGISTROS */
                    _.Move(AREA_DE_WORK.W_REG_GRAV_RETORNO, REGISTRO_TRAILLER.TR_QTD_REGISTROS);

                    /*" -1172- MOVE ALL '0' TO TR-FILLER */
                    _.MoveAll("0", REGISTRO_TRAILLER.TR_FILLER);

                    /*" -1173- MOVE REGISTRO-TRAILLER TO REGISTRO-RETORNO */
                    _.Move(AVISO?.Value, REGISTRO_RETORNO);

                    /*" -1174- WRITE REGISTRO-RETORNO */
                    RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                    /*" -1175- MOVE 'SIM' TO WFIM-ARQAVISO */
                    _.Move("SIM", AREA_DE_WORK.WFIM_ARQAVISO);

                    /*" -1176- END-IF */
                }


                /*" -1208- END-IF */
            }


            /*" -1208- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R050-ALTERA-FONTES */
        private void R050_ALTERA_FONTES(bool isPerform = false)
        {
            /*" -1218- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1222- PERFORM R050_ALTERA_FONTES_DB_UPDATE_1 */

            R050_ALTERA_FONTES_DB_UPDATE_1();

            /*" -1225- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1226- DISPLAY 'ERRO UPDATE FONTES' */
                _.Display($"ERRO UPDATE FONTES");

                /*" -1227- DISPLAY 'NUM-PROTOCOLO-SINI ' FONTES-NUM-PROTOCOLO-SINI */
                _.Display($"NUM-PROTOCOLO-SINI {FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI}");

                /*" -1228- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1228- END-IF. */
            }


        }

        [StopWatch]
        /*" R050-ALTERA-FONTES-DB-UPDATE-1 */
        public void R050_ALTERA_FONTES_DB_UPDATE_1()
        {
            /*" -1222- EXEC SQL UPDATE SEGUROS.FONTES SET NUM_PROTOCOLO_SINI = :FONTES-NUM-PROTOCOLO-SINI WHERE COD_FONTE = 10 END-EXEC. */

            var r050_ALTERA_FONTES_DB_UPDATE_1_Update1 = new R050_ALTERA_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_NUM_PROTOCOLO_SINI = FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI.ToString(),
            };

            R050_ALTERA_FONTES_DB_UPDATE_1_Update1.Execute(r050_ALTERA_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/

        [StopWatch]
        /*" R055-ALTERA-NUMERO-AES */
        private void R055_ALTERA_NUMERO_AES(bool isPerform = false)
        {
            /*" -1239- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1244- PERFORM R055_ALTERA_NUMERO_AES_DB_UPDATE_1 */

            R055_ALTERA_NUMERO_AES_DB_UPDATE_1();

            /*" -1247- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1248- DISPLAY 'ERRO UPDATE NUMERO_AES' */
                _.Display($"ERRO UPDATE NUMERO_AES");

                /*" -1249- DISPLAY 'RAMO-EMISSOR ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO-EMISSOR {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -1250- DISPLAY 'SEQ-SINISTRO ' NUMERAES-SEQ-SINISTRO */
                _.Display($"SEQ-SINISTRO {NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO}");

                /*" -1251- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1251- END-IF. */
            }


        }

        [StopWatch]
        /*" R055-ALTERA-NUMERO-AES-DB-UPDATE-1 */
        public void R055_ALTERA_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -1244- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET SEQ_SINISTRO = :NUMERAES-SEQ-SINISTRO WHERE ORGAO_EMISSOR = 10 AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR END-EXEC. */

            var r055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1 = new R055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                NUMERAES_SEQ_SINISTRO = NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            R055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R055_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-ARQAVISO */
        private void R100_PROCESSA_ARQAVISO(bool isPerform = false)
        {
            /*" -1261- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO. */
            _.Move(AVISO?.Value, REGISTRO_RETORNO);

            /*" -1263- MOVE ZEROS TO RE-FILLER-1. */
            _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

            /*" -1264- IF AV-TIPO-REGISTRO EQUAL 'A' */

            if (REGISTRO_AVISO.AV_TIPO_REGISTRO == "A")
            {

                /*" -1265- PERFORM R105-ROTINA-CRITICA-HEADER THRU R105-EXIT */

                R105_ROTINA_CRITICA_HEADER(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/


                /*" -1266- GO TO R100-LE-NOVO-REGISTRO */

                R100_LE_NOVO_REGISTRO(); //GOTO
                return;

                /*" -1268- END-IF */
            }


            /*" -1271- MOVE 'NAO' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

            /*" -1273- PERFORM R110-ROTINA-CRITICA-DADOS THRU R110-EXIT. */

            R110_ROTINA_CRITICA_DADOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -1274- IF W-CHAVE-CRITICA EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_CRITICA == "SIM")
            {

                /*" -1275- MOVE 'SIM' TO W-CHAVE-TEM-SINI-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_SINI_CRITICA);

                /*" -1277- END-IF */
            }


            /*" -1278- IF W-CHAVE-CRITICA EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_CRITICA == "NAO")
            {

                /*" -1280- PERFORM R1000-GRAVA-SINISTRO THRU R1000-EXIT */

                R1000_GRAVA_SINISTRO(true);

                R1000_NAO_GERA_ADIANTAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


                /*" -1282- MOVE 'SIM' TO W-CHAVE-TEM-SINI-AVISADO */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_SINI_AVISADO);

                /*" -1285- PERFORM R130-IMPRIME-GERA-AVISO-OK THRU R130-EXIT */

                R130_IMPRIME_GERA_AVISO_OK(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/


                /*" -1286- PERFORM R7000-00-TRATAR-PEP THRU R7000-99-SAIDA */

                R7000_00_TRATAR_PEP_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/


                /*" -1288- END-IF */
            }


            /*" -1288- . */

        }

        [StopWatch]
        /*" R100-LE-NOVO-REGISTRO */
        private void R100_LE_NOVO_REGISTRO(bool isPerform = false)
        {
            /*" -1291- PERFORM R040-LE-ARQAVISO THRU R040-EXIT. */

            R040_LE_ARQAVISO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R105-ROTINA-CRITICA-HEADER */
        private void R105_ROTINA_CRITICA_HEADER(bool isPerform = false)
        {
            /*" -1302- MOVE '105' TO WNR-EXEC-SQL. */
            _.Move("105", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1303- IF HE-INDICADOR-ORIGEM NOT EQUAL '2' */

            if (REGISTRO_HEADER.HE_INDICADOR_ORIGEM != "2")
            {

                /*" -1305- DISPLAY 'INDICADOR DE ORIGEM DO HEADER INVALIDO = ' HE-INDICADOR-ORIGEM */
                _.Display($"INDICADOR DE ORIGEM DO HEADER INVALIDO = {REGISTRO_HEADER.HE_INDICADOR_ORIGEM}");

                /*" -1306- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1308- END-IF */
            }


            /*" -1309- IF HE-DATA-GERACAO NOT NUMERIC */

            if (!REGISTRO_HEADER.HE_DATA_GERACAO.IsNumeric())
            {

                /*" -1311- DISPLAY 'DATA DA GERACAO DO HEADER NAO NUMERICA = ' HE-DATA-GERACAO */
                _.Display($"DATA DA GERACAO DO HEADER NAO NUMERICA = {REGISTRO_HEADER.HE_DATA_GERACAO}");

                /*" -1312- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1314- END-IF */
            }


            /*" -1315- MOVE HE-DATA-GERACAO TO W-DATA-AAAAMMDD. */
            _.Move(REGISTRO_HEADER.HE_DATA_GERACAO, AREA_DE_WORK.W_DATA_AAAAMMDD);

            /*" -1316- MOVE W-DATA-AAAAMMDD-AAAA TO W-DATA-AAAA-MM-DD-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA);

            /*" -1317- MOVE W-DATA-AAAAMMDD-MM TO W-DATA-AAAA-MM-DD-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM);

            /*" -1318- MOVE W-DATA-AAAAMMDD-DD TO W-DATA-AAAA-MM-DD-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD);

            /*" -1320- MOVE W-DATA-AAAA-MM-DD TO HOST-DATA-GERACAO. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD, HOST_DATA_GERACAO);

            /*" -1326- PERFORM R105_ROTINA_CRITICA_HEADER_DB_SELECT_1 */

            R105_ROTINA_CRITICA_HEADER_DB_SELECT_1();

            /*" -1329- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1330- IF SQLCODE EQUAL -180 */

                if (DB.SQLCODE == -180)
                {

                    /*" -1332- DISPLAY 'DATA DE GERACAO DO HEADER INVALIDA = ' HE-DATA-GERACAO */
                    _.Display($"DATA DE GERACAO DO HEADER INVALIDA = {REGISTRO_HEADER.HE_DATA_GERACAO}");

                    /*" -1334- END-IF */
                }


                /*" -1335- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1337- END-IF. */
            }


            /*" -1338- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -1339- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -1340- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-AAAAMMDD-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -1341- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-AAAAMMDD-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -1342- MOVE W-DATA-AAAAMMDD TO HE-DATA-GERACAO. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, REGISTRO_HEADER.HE_DATA_GERACAO);

            /*" -1346- MOVE '1' TO HE-INDICADOR-ORIGEM. */
            _.Move("1", REGISTRO_HEADER.HE_INDICADOR_ORIGEM);

            /*" -1347- MOVE ALL '0' TO HE-FILLER */
            _.MoveAll("0", REGISTRO_HEADER.HE_FILLER);

            /*" -1349- MOVE REGISTRO-HEADER TO REGISTRO-RETORNO. */
            _.Move(AVISO?.Value, REGISTRO_RETORNO);

            /*" -1349- WRITE REGISTRO-RETORNO. */
            RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R105-ROTINA-CRITICA-HEADER-DB-SELECT-1 */
        public void R105_ROTINA_CRITICA_HEADER_DB_SELECT_1()
        {
            /*" -1326- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-GERACAO WITH UR END-EXEC. */

            var r105_ROTINA_CRITICA_HEADER_DB_SELECT_1_Query1 = new R105_ROTINA_CRITICA_HEADER_DB_SELECT_1_Query1()
            {
                HOST_DATA_GERACAO = HOST_DATA_GERACAO.ToString(),
            };

            var executed_1 = R105_ROTINA_CRITICA_HEADER_DB_SELECT_1_Query1.Execute(r105_ROTINA_CRITICA_HEADER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS */
        private void R110_ROTINA_CRITICA_DADOS(bool isPerform = false)
        {
            /*" -1360- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1370- DISPLAY 'LENDO ARQUIVO: ' AV-COD-LOT-CEF ' APOLICE ' AV-NUM-APOLICE ' NAT ' AV-COD-NATUREZA ' CAUSA ' AV-COD-CAUSA ' VL ' AV-VALOR-INFORMADO ' DT OCO ' AV-DATA-OCORRENCIA ' DT GER ' AV-DATA-GERACAO ' DT AVI ' AV-DATA-AVISO ' DT DOC ' AV-DATA-ULTIMO-DOC */

            $"LENDO ARQUIVO: {REGISTRO_AVISO.AV_COD_LOT_CEF} APOLICE {REGISTRO_AVISO.AV_NUM_APOLICE} NAT {REGISTRO_AVISO.AV_COD_NATUREZA} CAUSA {REGISTRO_AVISO.AV_COD_CAUSA} VL {REGISTRO_AVISO.AV_VALOR_INFORMADO} DT OCO {REGISTRO_AVISO.AV_DATA_OCORRENCIA} DT GER {REGISTRO_AVISO.AV_DATA_GERACAO} DT AVI {REGISTRO_AVISO.AV_DATA_AVISO} DT DOC {REGISTRO_AVISO.AV_DATA_ULTIMO_DOC}"
            .Display();

            /*" -1371- MOVE AV-DATA-OCORRENCIA TO RE-DATA-OCORRENCIA */
            _.Move(REGISTRO_AVISO.AV_DATA_OCORRENCIA, REGISTRO_RETORNO.RE_DATA_OCORRENCIA);

            /*" -1373- MOVE AV-NOME-LOTERICO TO RE-NOME-LOTERICO */
            _.Move(REGISTRO_AVISO.AV_NOME_LOTERICO, REGISTRO_RETORNO.RE_NOME_LOTERICO);

            /*" -1374- IF AV-COD-LOT-CEF NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_COD_LOT_CEF.IsNumeric())
            {

                /*" -1375- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1376- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1379- MOVE TB-MENSAGEM(01) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[01].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1381- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1383- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1385- END-IF */
            }


            /*" -1386- IF AV-DATA-OCORRENCIA NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_DATA_OCORRENCIA.IsNumeric())
            {

                /*" -1387- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1388- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1391- MOVE TB-MENSAGEM(02) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[02].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1393- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1395- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1397- END-IF */
            }


            /*" -1398- IF AV-HORA-OCORRENCIA NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_HORA_OCORRENCIA.IsNumeric())
            {

                /*" -1399- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1400- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1403- MOVE TB-MENSAGEM(03) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[03].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1405- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1407- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1409- END-IF */
            }


            /*" -1410- IF AV-DATA-GERACAO NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_DATA_GERACAO.IsNumeric())
            {

                /*" -1411- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1412- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1414- MOVE TB-MENSAGEM(04) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[04].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1415- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1416- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1418- END-IF */
            }


            /*" -1419- IF AV-DATA-AVISO NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_DATA_AVISO.IsNumeric())
            {

                /*" -1420- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1421- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1423- MOVE TB-MENSAGEM(05) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[05].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1424- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1425- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1427- END-IF */
            }


            /*" -1428- IF AV-HORA-AVISO NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_HORA_AVISO.IsNumeric())
            {

                /*" -1429- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1430- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1432- MOVE TB-MENSAGEM(06) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[06].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1433- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1434- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1436- END-IF */
            }


            /*" -1437- IF AV-DATA-ULTIMO-DOC NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_DATA_ULTIMO_DOC.IsNumeric())
            {

                /*" -1438- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1439- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1441- MOVE TB-MENSAGEM(07) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[07].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1442- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1443- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1445- END-IF */
            }


            /*" -1446- IF AV-VALOR-INFORMADO NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_VALOR_INFORMADO.IsNumeric())
            {

                /*" -1447- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1448- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1450- MOVE TB-MENSAGEM(08) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[08].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1451- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1452- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1454- END-IF */
            }


            /*" -1455- IF AV-COD-NATUREZA NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_COD_NATUREZA.IsNumeric())
            {

                /*" -1456- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1457- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1459- MOVE TB-MENSAGEM(09) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[09].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1460- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1461- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1463- END-IF */
            }


            /*" -1464- IF AV-COD-CAUSA NOT NUMERIC */

            if (!REGISTRO_AVISO.AV_COD_CAUSA.IsNumeric())
            {

                /*" -1465- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1466- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1468- MOVE TB-MENSAGEM(10) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[10].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1469- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1470- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1474- END-IF */
            }


            /*" -1475- IF AV-COD-CAUSA EQUAL '00' */

            if (REGISTRO_AVISO.AV_COD_CAUSA == "00")
            {

                /*" -1476- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1477- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1479- MOVE TB-MENSAGEM(25) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[25].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1480- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1481- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1483- END-IF */
            }


            /*" -1484- IF W-CHAVE-CRITICA-NUMERIC EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC == "SIM")
            {

                /*" -1485- GO TO R110-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;

                /*" -1487- END-IF */
            }


            /*" -1488- IF AV-VALOR-INFORMADO EQUAL ZEROS */

            if (REGISTRO_AVISO.AV_VALOR_INFORMADO == 00)
            {

                /*" -1489- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1490- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1492- MOVE TB-MENSAGEM(11) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[11].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1493- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1494- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1496- END-IF */
            }


            /*" -1498- MOVE AV-VALOR-INFORMADO TO W-HOST-VALOR-AUX */
            _.Move(REGISTRO_AVISO.AV_VALOR_INFORMADO, AREA_DE_WORK.W_HOST_VALOR_AUX);

            /*" -1499- IF W-HOST-VALOR-AUX > 1000000 */

            if (AREA_DE_WORK.W_HOST_VALOR_AUX > 1000000)
            {

                /*" -1500- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1501- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1503- MOVE TB-MENSAGEM(34) TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[34].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1504- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1505- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1507- END-IF */
            }


            /*" -1509- MOVE AV-COD-LOT-CEF TO LOTERI01-COD-LOT-CEF LOTERI01-COD-LOT-FENAL. */
            _.Move(REGISTRO_AVISO.AV_COD_LOT_CEF, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL);

            /*" -1510- MOVE AV-DATA-OCORRENCIA TO W-DATA-AAAAMMDD. */
            _.Move(REGISTRO_AVISO.AV_DATA_OCORRENCIA, AREA_DE_WORK.W_DATA_AAAAMMDD);

            /*" -1511- MOVE W-DATA-AAAAMMDD-AAAA TO W-DATA-AAAA-MM-DD-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA);

            /*" -1512- MOVE W-DATA-AAAAMMDD-MM TO W-DATA-AAAA-MM-DD-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM);

            /*" -1513- MOVE W-DATA-AAAAMMDD-DD TO W-DATA-AAAA-MM-DD-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD);

            /*" -1515- MOVE W-DATA-AAAA-MM-DD TO HOST-DATA-OCORRENCIA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD, HOST_DATA_OCORRENCIA);

            /*" -1521- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_1 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_1();

            /*" -1525- IF SQLCODE EQUAL -180 OR 100 */

            if (DB.SQLCODE.In("-180", "100"))
            {

                /*" -1526- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1527- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1529- MOVE 'DATA DE OCORRENCIA INVALIDA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA DE OCORRENCIA INVALIDA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1530- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1531- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1533- END-IF */
            }


            /*" -1535- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL -180) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != -180) && (DB.SQLCODE != 100))
            {

                /*" -1536- DISPLAY 'ERRO SELECT CALENDARIO (01).....................' */
                _.Display($"ERRO SELECT CALENDARIO (01).....................");

                /*" -1537- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1538- DISPLAY 'DATA OCORR ........... ' HOST-DATA-OCORRENCIA */
                _.Display($"DATA OCORR ........... {HOST_DATA_OCORRENCIA}");

                /*" -1539- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1541- END-IF */
            }


            /*" -1542- IF HOST-DATA-OCORRENCIA >= '2009-01-01' */

            if (HOST_DATA_OCORRENCIA >= "2009-01-01")
            {

                /*" -1543- IF AV-COD-NATUREZA-N EQUAL 2 OR 4 OR 5 */

                if (REGISTRO_AVISO.AV_COD_NATUREZA_N.In("2", "4", "5"))
                {

                    /*" -1544- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                    _.Move(AVISO?.Value, REGISTRO_RETORNO);

                    /*" -1545- MOVE ZEROS TO RE-FILLER-1 */
                    _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                    /*" -1547- MOVE TB-MENSAGEM(24) TO RE-MENSAGEM LD01-MENSAGEM */
                    _.Move(LBSI0005.TABELA_MENSAGENS.TAB_MENSAGENS_R.TB_OCORREMSG[24].TB_OCORRENCIA.TB_MENSAGEM, REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                    /*" -1548- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                    R120_IMPRIME_GERA_CRITICA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                    /*" -1549- MOVE 'SIM' TO W-CHAVE-CRITICA */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                    /*" -1553- DISPLAY ' R0110-LOT=' AV-COD-LOT-CEF ' APO=' AV-NUM-APOLICE ' DT-OCOR=' HOST-DATA-OCORRENCIA ' COD NAT=' AV-COD-NATUREZA-N */

                    $" R0110-LOT={REGISTRO_AVISO.AV_COD_LOT_CEF} APO={REGISTRO_AVISO.AV_NUM_APOLICE} DT-OCOR={HOST_DATA_OCORRENCIA} COD NAT={REGISTRO_AVISO.AV_COD_NATUREZA_N}"
                    .Display();

                    /*" -1554- DISPLAY ' MSG =' LD01-MENSAGEM */
                    _.Display($" MSG ={AREA_DE_WORK.LD01_A.LD01_MENSAGEM}");

                    /*" -1555- END-IF */
                }


                /*" -1557- END-IF. */
            }


            /*" -1558- MOVE AV-DATA-GERACAO TO W-DATA-AAAAMMDD. */
            _.Move(REGISTRO_AVISO.AV_DATA_GERACAO, AREA_DE_WORK.W_DATA_AAAAMMDD);

            /*" -1559- MOVE W-DATA-AAAAMMDD-AAAA TO W-DATA-AAAA-MM-DD-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA);

            /*" -1560- MOVE W-DATA-AAAAMMDD-MM TO W-DATA-AAAA-MM-DD-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM);

            /*" -1561- MOVE W-DATA-AAAAMMDD-DD TO W-DATA-AAAA-MM-DD-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD);

            /*" -1565- MOVE W-DATA-AAAA-MM-DD TO HOST-DATA-GERACAO. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD, HOST_DATA_GERACAO);

            /*" -1571- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_2 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_2();

            /*" -1575- IF SQLCODE EQUAL -180 OR 100 */

            if (DB.SQLCODE.In("-180", "100"))
            {

                /*" -1576- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1577- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1579- MOVE 'DATA DA GERACAO INVALIDA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA DA GERACAO INVALIDA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1580- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1581- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1583- END-IF */
            }


            /*" -1585- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL -180) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != -180) && (DB.SQLCODE != 100))
            {

                /*" -1586- DISPLAY 'ERRO SELECT CALENDARIO (02).....................' */
                _.Display($"ERRO SELECT CALENDARIO (02).....................");

                /*" -1587- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1588- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1590- END-IF */
            }


            /*" -1591- MOVE AV-DATA-AVISO TO W-DATA-AAAAMMDD. */
            _.Move(REGISTRO_AVISO.AV_DATA_AVISO, AREA_DE_WORK.W_DATA_AAAAMMDD);

            /*" -1592- MOVE W-DATA-AAAAMMDD-AAAA TO W-DATA-AAAA-MM-DD-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA);

            /*" -1593- MOVE W-DATA-AAAAMMDD-MM TO W-DATA-AAAA-MM-DD-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM);

            /*" -1594- MOVE W-DATA-AAAAMMDD-DD TO W-DATA-AAAA-MM-DD-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD);

            /*" -1598- MOVE W-DATA-AAAA-MM-DD TO HOST-DATA-AVISO. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD, HOST_DATA_AVISO);

            /*" -1604- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_3 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_3();

            /*" -1608- IF SQLCODE EQUAL -180 OR 100 */

            if (DB.SQLCODE.In("-180", "100"))
            {

                /*" -1609- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1610- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1612- MOVE 'DATA DO AVISO INVALIDA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA DO AVISO INVALIDA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1613- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1614- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1616- END-IF */
            }


            /*" -1618- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL -180) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != -180) && (DB.SQLCODE != 100))
            {

                /*" -1619- DISPLAY 'ERRO SELECT CALENDARIO (03).....................' */
                _.Display($"ERRO SELECT CALENDARIO (03).....................");

                /*" -1620- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1621- DISPLAY 'DATA DO AVISO......... ' HOST-DATA-AVISO */
                _.Display($"DATA DO AVISO......... {HOST_DATA_AVISO}");

                /*" -1622- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1624- END-IF */
            }


            /*" -1625- MOVE AV-DATA-ULTIMO-DOC TO W-DATA-AAAAMMDD. */
            _.Move(REGISTRO_AVISO.AV_DATA_ULTIMO_DOC, AREA_DE_WORK.W_DATA_AAAAMMDD);

            /*" -1626- MOVE W-DATA-AAAAMMDD-AAAA TO W-DATA-AAAA-MM-DD-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA);

            /*" -1627- MOVE W-DATA-AAAAMMDD-MM TO W-DATA-AAAA-MM-DD-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM);

            /*" -1628- MOVE W-DATA-AAAAMMDD-DD TO W-DATA-AAAA-MM-DD-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD);

            /*" -1632- MOVE W-DATA-AAAA-MM-DD TO HOST-DATA-ULTIMO-DOC. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD, HOST_DATA_ULTIMO_DOC);

            /*" -1638- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_4 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_4();

            /*" -1642- IF SQLCODE EQUAL -180 OR 100 */

            if (DB.SQLCODE.In("-180", "100"))
            {

                /*" -1643- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1644- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1646- MOVE 'DATA DO ULTIMO DOCUMENTO INVALIDA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA DO ULTIMO DOCUMENTO INVALIDA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1647- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1648- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1650- END-IF */
            }


            /*" -1652- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL -180) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != -180) && (DB.SQLCODE != 100))
            {

                /*" -1653- DISPLAY 'ERRO SELECT CALENDARIO (04).....................' */
                _.Display($"ERRO SELECT CALENDARIO (04).....................");

                /*" -1654- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1655- DISPLAY 'DATA ULTIMO AVISO..... ' HOST-DATA-ULTIMO-DOC */
                _.Display($"DATA ULTIMO AVISO..... {HOST_DATA_ULTIMO_DOC}");

                /*" -1656- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1658- END-IF */
            }


            /*" -1659- IF HOST-DATA-AVISO < HOST-DATA-OCORRENCIA */

            if (HOST_DATA_AVISO < HOST_DATA_OCORRENCIA)
            {

                /*" -1660- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1661- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1663- MOVE 'DATA DO AVISO ANTERIOR A OCORRENCIA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA DO AVISO ANTERIOR A OCORRENCIA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1664- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1665- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1667- END-IF */
            }


            /*" -1668- IF HOST-DATA-GERACAO < HOST-DATA-OCORRENCIA */

            if (HOST_DATA_GERACAO < HOST_DATA_OCORRENCIA)
            {

                /*" -1669- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1670- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1672- MOVE 'DATA DA GERACAO ANTERIOR A OCORRENCIA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA DA GERACAO ANTERIOR A OCORRENCIA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1673- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1674- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1676- END-IF */
            }


            /*" -1677- IF HOST-DATA-ULTIMO-DOC < HOST-DATA-AVISO */

            if (HOST_DATA_ULTIMO_DOC < HOST_DATA_AVISO)
            {

                /*" -1678- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1679- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1681- MOVE 'DATA DO ULTIMO DOCUMENTO ANTERIOR A DATA AVISO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA DO ULTIMO DOCUMENTO ANTERIOR A DATA AVISO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1682- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1683- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1685- END-IF */
            }


            /*" -1686- IF HOST-DATA-ULTIMO-DOC > HOST-DATA-GERACAO */

            if (HOST_DATA_ULTIMO_DOC > HOST_DATA_GERACAO)
            {

                /*" -1687- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1688- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1690- MOVE 'DATA DO ULTIMO DOCUMENTO POSTERIOR A DATA GERACAO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA DO ULTIMO DOCUMENTO POSTERIOR A DATA GERACAO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1691- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1692- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1694- END-IF. */
            }


            /*" -1695- MOVE AV-HORA-OCORRENCIA TO W-HORA-HHMM. */
            _.Move(REGISTRO_AVISO.AV_HORA_OCORRENCIA, AREA_DE_WORK.W_HORA_HHMM);

            /*" -1696- MOVE W-HORA-HHMM-HH TO W-HORA-HH-MM-SS-HH. */
            _.Move(AREA_DE_WORK.W_HORA_HHMM.W_HORA_HHMM_HH, AREA_DE_WORK.W_HORA_HH_MM_SS.W_HORA_HH_MM_SS_HH);

            /*" -1697- MOVE W-HORA-HHMM-MM TO W-HORA-HH-MM-SS-MM. */
            _.Move(AREA_DE_WORK.W_HORA_HHMM.W_HORA_HHMM_MM, AREA_DE_WORK.W_HORA_HH_MM_SS.W_HORA_HH_MM_SS_MM);

            /*" -1698- MOVE '00' TO W-HORA-HH-MM-SS-SS. */
            _.Move("00", AREA_DE_WORK.W_HORA_HH_MM_SS.W_HORA_HH_MM_SS_SS);

            /*" -1700- MOVE W-HORA-HH-MM-SS TO HOST-HORA-OCORRENCIA. */
            _.Move(AREA_DE_WORK.W_HORA_HH_MM_SS, HOST_HORA_OCORRENCIA);

            /*" -1702- IF (HOST-HORA-OCORRENCIA < '00.00.01' ) OR (HOST-HORA-OCORRENCIA > '23.59.59' ) */

            if ((HOST_HORA_OCORRENCIA < "00.00.01") || (HOST_HORA_OCORRENCIA > "23.59.59"))
            {

                /*" -1703- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1704- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1706- MOVE 'HORA DA OCORRENCIA INVALIDA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("HORA DA OCORRENCIA INVALIDA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1707- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1708- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1710- END-IF. */
            }


            /*" -1711- MOVE AV-HORA-AVISO TO W-HORA-HHMM. */
            _.Move(REGISTRO_AVISO.AV_HORA_AVISO, AREA_DE_WORK.W_HORA_HHMM);

            /*" -1712- MOVE W-HORA-HHMM-HH TO W-HORA-HH-MM-SS-HH. */
            _.Move(AREA_DE_WORK.W_HORA_HHMM.W_HORA_HHMM_HH, AREA_DE_WORK.W_HORA_HH_MM_SS.W_HORA_HH_MM_SS_HH);

            /*" -1713- MOVE W-HORA-HHMM-MM TO W-HORA-HH-MM-SS-MM. */
            _.Move(AREA_DE_WORK.W_HORA_HHMM.W_HORA_HHMM_MM, AREA_DE_WORK.W_HORA_HH_MM_SS.W_HORA_HH_MM_SS_MM);

            /*" -1714- MOVE '00' TO W-HORA-HH-MM-SS-SS. */
            _.Move("00", AREA_DE_WORK.W_HORA_HH_MM_SS.W_HORA_HH_MM_SS_SS);

            /*" -1716- MOVE W-HORA-HH-MM-SS TO HOST-HORA-AVISO. */
            _.Move(AREA_DE_WORK.W_HORA_HH_MM_SS, HOST_HORA_AVISO);

            /*" -1718- IF (HOST-HORA-AVISO < '00.00.01' ) OR (HOST-HORA-AVISO > '23.59.59' ) */

            if ((HOST_HORA_AVISO < "00.00.01") || (HOST_HORA_AVISO > "23.59.59"))
            {

                /*" -1719- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1720- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1722- MOVE 'HORA DO AVISO INVALIDA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("HORA DO AVISO INVALIDA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1723- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1724- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1758- END-IF. */
            }


            /*" -1765- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_5 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_5();

            /*" -1768- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1769- DISPLAY 'ERRO SELECT LOTERICO01 (01).....................' */
                _.Display($"ERRO SELECT LOTERICO01 (01).....................");

                /*" -1770- DISPLAY 'LOTERICO      ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO      {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1771- DISPLAY 'COD-LOT-FENAL ' LOTERI01-COD-LOT-FENAL */
                _.Display($"COD-LOT-FENAL {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL}");

                /*" -1772- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1774- END-IF */
            }


            /*" -1775- IF HOST-ACHA-LOTERICO EQUAL ZERO */

            if (HOST_ACHA_LOTERICO == 00)
            {

                /*" -1776- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1777- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1779- MOVE 'CODIGO DO LOTERICO NAO CADASTRADO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DO LOTERICO NAO CADASTRADO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1780- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1781- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1782- GO TO R110-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;

                /*" -1786- END-IF */
            }


            /*" -1795- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_6 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_6();

            /*" -1798- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1799- DISPLAY 'R110-ERRO SELECT LOTERICO01 (02)' */
                _.Display($"R110-ERRO SELECT LOTERICO01 (02)");

                /*" -1800- DISPLAY 'COD_LOT_CEF   ' LOTERI01-COD-LOT-CEF */
                _.Display($"COD_LOT_CEF   {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1801- DISPLAY 'COD_LOT_FENAL ' LOTERI01-COD-LOT-FENAL */
                _.Display($"COD_LOT_FENAL {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL}");

                /*" -1802- DISPLAY 'DTINIVIG      ' HOST-DATA-OCORRENCIA */
                _.Display($"DTINIVIG      {HOST_DATA_OCORRENCIA}");

                /*" -1803- DISPLAY 'DTTERVIG      ' HOST-DATA-OCORRENCIA */
                _.Display($"DTTERVIG      {HOST_DATA_OCORRENCIA}");

                /*" -1804- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1806- END-IF */
            }


            /*" -1807- IF HOST-ACHA-LOTERICO EQUAL ZERO */

            if (HOST_ACHA_LOTERICO == 00)
            {

                /*" -1808- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1809- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1811- MOVE 'LOTERICO NAO ESTA VIGENTE NA DATA DA OCORRENCIA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("LOTERICO NAO ESTA VIGENTE NA DATA DA OCORRENCIA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1812- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1813- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1814- GO TO R110-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;

                /*" -1816- END-IF */
            }


            /*" -1817- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1819- MOVE AV-NUM-APOLICE TO LOTERI01-NUM-APOLICE. */
            _.Move(REGISTRO_AVISO.AV_NUM_APOLICE, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE);

            /*" -1851- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_7 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_7();

            /*" -1854- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1855- DISPLAY 'ERRO SELECT LOTERICO01 (03).....................' */
                _.Display($"ERRO SELECT LOTERICO01 (03).....................");

                /*" -1856- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1857- DISPLAY 'APOLICE  ............. ' LOTERI01-NUM-APOLICE */
                _.Display($"APOLICE  ............. {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -1858- DISPLAY 'DATA VIGENCIA......... ' HOST-DATA-OCORRENCIA */
                _.Display($"DATA VIGENCIA......... {HOST_DATA_OCORRENCIA}");

                /*" -1859- DISPLAY 'SQLCODE .............. ' SQLCODE */
                _.Display($"SQLCODE .............. {DB.SQLCODE}");

                /*" -1860- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1862- MOVE 'LOT NAO ENCONTRADO COM ESTA APOL. NESTA DATA OCOR' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("LOT NAO ENCONTRADO COM ESTA APOL. NESTA DATA OCOR", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1863- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1864- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1865- GO TO R110-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;

                /*" -1867- END-IF */
            }


            /*" -1869- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1879- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_8 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_8();

            /*" -1882- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1883- DISPLAY 'ERRO SELECT APOLICE ............................' */
                _.Display($"ERRO SELECT APOLICE ............................");

                /*" -1884- DISPLAY 'LOTERICO ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1885- DISPLAY 'APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -1886- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1889- END-IF */
            }


            /*" -1891- PERFORM R111-VERIFICA-PGTO-PREMIO THRU R111-EXIT. */

            R111_VERIFICA_PGTO_PREMIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R111_EXIT*/


            /*" -1892- IF HOST-PAGTO = 0 */

            if (HOST_PAGTO == 0)
            {

                /*" -1893- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1894- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1896- MOVE 'APOLICE CANCELADA OU PEND. PAGTO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("APOLICE CANCELADA OU PEND. PAGTO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1897- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1898- MOVE 'SIM' TO W-CHAVE-CRITICA W-CHAVE-CRITICA-NUMERIC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_CRITICA_NUMERIC);

                /*" -1900- END-IF. */
            }


            /*" -1902- MOVE AV-COD-CAUSA TO SINISCAU-COD-CAUSA. */
            _.Move(REGISTRO_AVISO.AV_COD_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA);

            /*" -1904- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1911- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_9 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_9();

            /*" -1914- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1915- DISPLAY 'ERRO SELECT SINISTRO_CAUSA .....................' */
                _.Display($"ERRO SELECT SINISTRO_CAUSA .....................");

                /*" -1916- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -1917- DISPLAY 'COD_CAUSA ............ ' SINISCAU-COD-CAUSA */
                _.Display($"COD_CAUSA ............ {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA}");

                /*" -1918- DISPLAY 'RAMO_EMISSOR ......... ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO_EMISSOR ......... {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -1925- END-IF. */
            }


            /*" -1928- MOVE AV-COD-NATUREZA-N TO LOTISG01-COD-COBERTURA LOTCOB01-COD-COBERTURA. */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA_N, LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA, LOTCOB01.DCLLOTCOBER01.LOTCOB01_COD_COBERTURA);

            /*" -1929- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1935- MOVE 0 TO HOST-ACHA-LOTERICO */
            _.Move(0, HOST_ACHA_LOTERICO);

            /*" -1957- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_10 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_10();

            /*" -1960- IF (SQLCODE NOT EQUAL 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -1962- DISPLAY 'R110-ERRO SELECT DUPLICIDADE AVISO ' ' LOT=' LOTERI01-COD-LOT-CEF */

                $"R110-ERRO SELECT DUPLICIDADE AVISO  LOT={LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}"
                .Display();

                /*" -1963- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1969- END-IF */
            }


            /*" -1972- IF LOTERI01-NUM-APOLICE EQUAL 0107100057625 AND LOTERI01-COD-LOT-CEF EQUAL 210012137 AND HOST-DATA-OCORRENCIA EQUAL '2002-02-25' */

            if (LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE == 0107100057625 && LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF == 210012137 && HOST_DATA_OCORRENCIA == "2002-02-25")
            {

                /*" -1973- GO TO R110-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;

                /*" -1979- END-IF. */
            }


            /*" -1980- IF HOST-ACHA-LOTERICO NOT EQUAL ZERO */

            if (HOST_ACHA_LOTERICO != 00)
            {

                /*" -1981- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -1982- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -1984- MOVE 'HA SINISTRO ATIVO NA MESMA DT/HORA OCOR E DT.AVISO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("HA SINISTRO ATIVO NA MESMA DT/HORA OCOR E DT.AVISO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -1985- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1986- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1988- END-IF */
            }


            /*" -1991- MOVE ZEROS TO W-HOST-VALOR-BASE-AVISO W-HOST-VALOR-BASE-ADIANTAMENTO. */
            _.Move(0, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);

            /*" -1994- MOVE AV-VALOR-INFORMADO TO W-HOST-VALOR-BASE-AVISO W-HOST-VALOR-BASE-ADIANTAMENTO. */
            _.Move(REGISTRO_AVISO.AV_VALOR_INFORMADO, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);

            /*" -1995- MOVE '047' TO WNR-EXEC-SQL. */
            _.Move("047", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1997- MOVE SPACES TO WS-DT-CANCELAMENTO */
            _.Move("", WS_DT_CANCELAMENTO);

            /*" -2008- PERFORM R110_ROTINA_CRITICA_DADOS_DB_SELECT_11 */

            R110_ROTINA_CRITICA_DADOS_DB_SELECT_11();

            /*" -2011- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2012- DISPLAY 'ERRO SELECT BUSCA VIGENCIA DA APOLICE...........' */
                _.Display($"ERRO SELECT BUSCA VIGENCIA DA APOLICE...........");

                /*" -2013- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2014- DISPLAY 'APOLICE .............. ' LOTERI01-NUM-APOLICE */
                _.Display($"APOLICE .............. {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2015- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2017- END-IF */
            }


            /*" -2018- IF HOST-SIT-REGISTRO EQUAL '2' */

            if (HOST_SIT_REGISTRO == "2")
            {

                /*" -2020- PERFORM R112-BUSCA-DATA-CANCELAMENTO THRU R112-EXIT */

                R112_BUSCA_DATA_CANCELAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R112_EXIT*/


                /*" -2021- IF HOST-DATA-OCORRENCIA > WS-DT-CANCELAMENTO */

                if (HOST_DATA_OCORRENCIA > WS_DT_CANCELAMENTO)
                {

                    /*" -2022- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                    _.Move(AVISO?.Value, REGISTRO_RETORNO);

                    /*" -2023- MOVE ZEROS TO RE-FILLER-1 */
                    _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                    /*" -2026- MOVE 'SINISTRO PARA APOLICE CANCELADA' TO RE-MENSAGEM LD01-MENSAGEM */
                    _.Move("SINISTRO PARA APOLICE CANCELADA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                    /*" -2027- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                    R120_IMPRIME_GERA_CRITICA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                    /*" -2028- MOVE 'SIM' TO W-CHAVE-CRITICA */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                    /*" -2029- END-IF */
                }


                /*" -2031- END-IF */
            }


            /*" -2033- MOVE HOST-ANO-INIVIG TO W-ANO-PROCESSAMENTO */
            _.Move(AREA_DE_WORK.HOST_DATA_INIVIGENCIA_R.HOST_ANO_INIVIG, AREA_DE_WORK.W_ANO_PROCESSAMENTO);

            /*" -2035- IF HOST-DATA-INIVIGENCIA(1:4) GREATER THAN HOST-DATA-CORRENTE(1:4) */

            if (AREA_DE_WORK.HOST_DATA_INIVIGENCIA.Substring(1, 4) > HOST_DATA_CORRENTE.Substring(1, 4))
            {

                /*" -2036- DISPLAY 'DTINIVIG APOLICE INVALIDA PARA PROC.' */
                _.Display($"DTINIVIG APOLICE INVALIDA PARA PROC.");

                /*" -2037- DISPLAY 'LOTERICO ........... ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ........... {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2038- DISPLAY 'APOLICE ............ ' LOTERI01-NUM-APOLICE */
                _.Display($"APOLICE ............ {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2039- DISPLAY 'DTINVIG............. ' HOST-DATA-INIVIGENCIA */
                _.Display($"DTINVIG............. {AREA_DE_WORK.HOST_DATA_INIVIGENCIA}");

                /*" -2040- DISPLAY 'HOST-DATA-CORRENTE.. ' HOST-DATA-CORRENTE */
                _.Display($"HOST-DATA-CORRENTE.. {HOST_DATA_CORRENTE}");

                /*" -2041- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2043- END-IF */
            }


            /*" -2045- MOVE AV-VALOR-INFORMADO TO W-EDICAO. */
            _.Move(REGISTRO_AVISO.AV_VALOR_INFORMADO, AREA_DE_WORK.W_EDICAO);

            /*" -2046- IF APOLICES-RAMO-EMISSOR EQUAL 71 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 71)
            {

                /*" -2047- PERFORM R500-CRITICA-APOL-ADMINIST THRU R500-EXIT */

                R500_CRITICA_APOL_ADMINIST(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/


                /*" -2048- ELSE */
            }
            else
            {


                /*" -2049- PERFORM R700-CRITICA-APOL-POR-LOT THRU R700-EXIT */

                R700_CRITICA_APOL_POR_LOT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/


                /*" -2049- END-IF. */
            }


        }

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-1 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_1()
        {
            /*" -1521- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-OCORRENCIA WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1()
            {
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-2 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_2()
        {
            /*" -1571- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-GERACAO WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_2_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_2_Query1()
            {
                HOST_DATA_GERACAO = HOST_DATA_GERACAO.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_2_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }

        [StopWatch]
        /*" R111-VERIFICA-PGTO-PREMIO */
        private void R111_VERIFICA_PGTO_PREMIO(bool isPerform = false)
        {
            /*" -2059- MOVE '111' TO WNR-EXEC-SQL. */
            _.Move("111", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2060- MOVE AV-NUM-APOLICE TO LOTERI01-NUM-APOLICE. */
            _.Move(REGISTRO_AVISO.AV_NUM_APOLICE, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE);

            /*" -2061- MOVE AV-DATA-OCORRENCIA TO W-DATA-AAAAMMDD. */
            _.Move(REGISTRO_AVISO.AV_DATA_OCORRENCIA, AREA_DE_WORK.W_DATA_AAAAMMDD);

            /*" -2062- MOVE W-DATA-AAAAMMDD-AAAA TO W-DATA-AAAA-MM-DD-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA);

            /*" -2063- MOVE W-DATA-AAAAMMDD-MM TO W-DATA-AAAA-MM-DD-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM);

            /*" -2064- MOVE W-DATA-AAAAMMDD-DD TO W-DATA-AAAA-MM-DD-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD);

            /*" -2065- MOVE W-DATA-AAAA-MM-DD TO HOST-DATA-OCORRENCIA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD, HOST_DATA_OCORRENCIA);

            /*" -2067- MOVE W-DATA-AAAAMMDD-AAAA TO HOST-ANO-OCORRENCIA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, HOST_ANO_OCORRENCIA);

            /*" -2070- MOVE 0 TO WS-QT-REG HOST-PAGTO */
            _.Move(0, WS_QT_REG, HOST_PAGTO);

            /*" -2091- PERFORM R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1 */

            R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1();

            /*" -2094- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2095- DISPLAY 'ERRO SELECT R111-VERIFICA-PGTO-PREMIO' */
                _.Display($"ERRO SELECT R111-VERIFICA-PGTO-PREMIO");

                /*" -2096- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2097- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2099- END-IF */
            }


            /*" -2100- IF WS-QT-REG = 0 */

            if (WS_QT_REG == 0)
            {

                /*" -2101- MOVE 1 TO HOST-PAGTO */
                _.Move(1, HOST_PAGTO);

                /*" -2103- END-IF */
            }


            /*" -2105- GO TO R111-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R111_EXIT*/ //GOTO
            return;


        }

        [StopWatch]
        /*" R111-VERIFICA-PGTO-PREMIO-DB-SELECT-1 */
        public void R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1()
        {
            /*" -2091- EXEC SQL SELECT COUNT(*) INTO :WS-QT-REG FROM SEGUROS.PARCELAS A ,SEGUROS.PARCELA_HISTORICO B WHERE A.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND A.SIT_REGISTRO = '0' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA AND B.OCORR_HISTORICO = 1 AND B.DATA_VENCIMENTO < :SISTEMAS-DATA-MOV-ABERTO AND NOT EXISTS ( SELECT C.NUM_APOLICE FROM SEGUROS.MOVTO_DEBITOCC_CEF C WHERE C.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_ENDOSSO = A.NUM_ENDOSSO AND C.NUM_PARCELA = A.NUM_PARCELA AND C.SITUACAO_COBRANCA IN ( ' ' , '1' , '2' ) ) WITH UR END-EXEC */

            var r111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1 = new R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1.Execute(r111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_REG, WS_QT_REG);
            }


        }

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-3 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_3()
        {
            /*" -1604- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-AVISO WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_3_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_3_Query1()
            {
                HOST_DATA_AVISO = HOST_DATA_AVISO.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_3_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }

        [StopWatch]
        /*" R111-VERIFICA-PGTO-PREMIO-DB-SELECT-2 */
        public void R111_VERIFICA_PGTO_PREMIO_DB_SELECT_2()
        {
            /*" -2127- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-PAGTO FROM SEGUROS.ENDOSSOS E, SEGUROS.MOVTO_DEBITOCC_CEF C WHERE E.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND C.NUM_APOLICE = E.NUM_APOLICE AND E.NUM_ENDOSSO = 0 AND C.NUM_ENDOSSO = 0 AND C.SITUACAO_COBRANCA IN ( '1' , '2' ) AND YEAR(C.DATA_VENCIMENTO) = :HOST-ANO-OCORRENCIA AND ((E.QTD_PARCELAS = C.NUM_PARCELA) OR (C.DATA_VENCIMENTO >= (SELECT DATA_CALENDARIO - 1 MONTH FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-OCORRENCIA))) WITH UR END-EXEC */

            var r111_VERIFICA_PGTO_PREMIO_DB_SELECT_2_Query1 = new R111_VERIFICA_PGTO_PREMIO_DB_SELECT_2_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
                HOST_ANO_OCORRENCIA = HOST_ANO_OCORRENCIA.ToString(),
            };

            var executed_1 = R111_VERIFICA_PGTO_PREMIO_DB_SELECT_2_Query1.Execute(r111_VERIFICA_PGTO_PREMIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_PAGTO, HOST_PAGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R111_EXIT*/

        [StopWatch]
        /*" R111-VERIFICA-PGTO-PREMIO-DB-SELECT-3 */
        public void R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3()
        {
            /*" -2151- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-PAGTO FROM SEGUROS.ENDOSSOS E, SEGUROS.MOVTO_DEBITOCC_CEF C WHERE E.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND C.NUM_APOLICE = E.NUM_APOLICE AND E.NUM_ENDOSSO = 0 AND C.NUM_ENDOSSO = 0 AND C.SITUACAO_COBRANCA IN ( '1' , '2' , ' ' ) AND YEAR(C.DATA_VENCIMENTO) = :HOST-ANO-OCORRENCIA AND ((E.QTD_PARCELAS = C.NUM_PARCELA) OR (C.DATA_VENCIMENTO >= (SELECT DATA_CALENDARIO - 1 MONTH FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-OCORRENCIA))) WITH UR END-EXEC */

            var r111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1 = new R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
                HOST_ANO_OCORRENCIA = HOST_ANO_OCORRENCIA.ToString(),
            };

            var executed_1 = R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1.Execute(r111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_PAGTO, HOST_PAGTO);
            }


        }

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-4 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_4()
        {
            /*" -1638- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-ULTIMO-DOC WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_4_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_4_Query1()
            {
                HOST_DATA_ULTIMO_DOC = HOST_DATA_ULTIMO_DOC.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_4_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }

        [StopWatch]
        /*" R111-VERIFICA-PGTO-PREMIO-DB-SELECT-4 */
        public void R111_VERIFICA_PGTO_PREMIO_DB_SELECT_4()
        {
            /*" -2171- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-PAGTO FROM SEGUROS.ENDOSSOS E ,SEGUROS.MOVTO_DEBITOCC_CEF C WHERE C.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND C.NUM_APOLICE = E.NUM_APOLICE AND E.NUM_ENDOSSO = 0 AND C.NUM_ENDOSSO = 0 AND C.SITUACAO_COBRANCA IN ( '1' , '2' , ' ' ) AND (( E.QTD_PARCELAS = C.NUM_PARCELA ) OR (C.DATA_VENCIMENTO >= (SELECT DATA_CALENDARIO - 1 MONTH FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-OCORRENCIA))) WITH UR END-EXEC */

            var r111_VERIFICA_PGTO_PREMIO_DB_SELECT_4_Query1 = new R111_VERIFICA_PGTO_PREMIO_DB_SELECT_4_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
            };

            var executed_1 = R111_VERIFICA_PGTO_PREMIO_DB_SELECT_4_Query1.Execute(r111_VERIFICA_PGTO_PREMIO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_PAGTO, HOST_PAGTO);
            }


        }

        [StopWatch]
        /*" R112-BUSCA-DATA-CANCELAMENTO */
        private void R112_BUSCA_DATA_CANCELAMENTO(bool isPerform = false)
        {
            /*" -2195- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -2201- PERFORM R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1 */

            R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1();

            /*" -2204- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2205- DISPLAY 'ERRO SELECT ENDOSSOS............................' */
                _.Display($"ERRO SELECT ENDOSSOS............................");

                /*" -2206- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2207- DISPLAY 'APOLICE .............. ' LOTERI01-NUM-APOLICE */
                _.Display($"APOLICE .............. {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2208- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2210- END-IF */
            }


            /*" -2217- PERFORM R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2 */

            R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2();

            /*" -2220- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2221- DISPLAY 'ERRO SELECT ENDOSSOS PARA BUSCAR DT CANCELAMENTO' */
                _.Display($"ERRO SELECT ENDOSSOS PARA BUSCAR DT CANCELAMENTO");

                /*" -2222- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2223- DISPLAY 'APOLICE .............. ' LOTERI01-NUM-APOLICE */
                _.Display($"APOLICE .............. {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2224- DISPLAY 'ENDOSSO .............. ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO .............. {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -2225- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2225- END-IF. */
            }


        }

        [StopWatch]
        /*" R112-BUSCA-DATA-CANCELAMENTO-DB-SELECT-1 */
        public void R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1()
        {
            /*" -2201- EXEC SQL SELECT MAX(NUM_ENDOSSO) INTO :ENDOSSOS-NUM-ENDOSSO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE WITH UR END-EXEC */

            var r112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1 = new R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1.Execute(r112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
            }


        }

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-5 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_5()
        {
            /*" -1765- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-ACHA-LOTERICO FROM SEGUROS.LOTERICO01 WHERE COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1()
            {
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                LOTERI01_COD_LOT_CEF = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_ACHA_LOTERICO, HOST_ACHA_LOTERICO);
            }


        }

        [StopWatch]
        /*" R112-BUSCA-DATA-CANCELAMENTO-DB-SELECT-2 */
        public void R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2()
        {
            /*" -2217- EXEC SQL SELECT DATA_INIVIGENCIA INTO :WS-DT-CANCELAMENTO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO WITH UR END-EXEC */

            var r112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1 = new R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1.Execute(r112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DT_CANCELAMENTO, WS_DT_CANCELAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R112_EXIT*/

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-6 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_6()
        {
            /*" -1795- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-ACHA-LOTERICO FROM SEGUROS.LOTERICO01 WHERE COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND DTINIVIG <= :HOST-DATA-OCORRENCIA AND DTTERVIG >= :HOST-DATA-OCORRENCIA WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1()
            {
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                LOTERI01_COD_LOT_CEF = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_ACHA_LOTERICO, HOST_ACHA_LOTERICO);
            }


        }

        [StopWatch]
        /*" R500-CRITICA-APOL-ADMINIST */
        private void R500_CRITICA_APOL_ADMINIST(bool isPerform = false)
        {
            /*" -2240- IF AV-COD-NATUREZA NOT EQUAL 1 AND 2 AND 3 AND 4 */

            if (!REGISTRO_AVISO.AV_COD_NATUREZA.In("1", "2", "3", "4"))
            {

                /*" -2241- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2242- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2244- MOVE 'CODIGO DA NATUREZA INVALIDO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA NATUREZA INVALIDO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2245- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2247- MOVE 'SIM' TO W-CHAVE-CRITICA. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);
            }


            /*" -2256- IF (AV-COD-NATUREZA EQUAL 1) AND (AV-COD-CAUSA NOT EQUAL '01' ) AND (AV-COD-CAUSA NOT EQUAL '02' ) AND (AV-COD-CAUSA NOT EQUAL '03' ) AND (AV-COD-CAUSA NOT EQUAL '10' ) AND (AV-COD-CAUSA NOT EQUAL '11' ) AND (AV-COD-CAUSA NOT EQUAL '15' ) AND (AV-COD-CAUSA NOT EQUAL '20' ) AND (AV-COD-CAUSA NOT EQUAL '23' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA == 1) && (REGISTRO_AVISO.AV_COD_CAUSA != "01") && (REGISTRO_AVISO.AV_COD_CAUSA != "02") && (REGISTRO_AVISO.AV_COD_CAUSA != "03") && (REGISTRO_AVISO.AV_COD_CAUSA != "10") && (REGISTRO_AVISO.AV_COD_CAUSA != "11") && (REGISTRO_AVISO.AV_COD_CAUSA != "15") && (REGISTRO_AVISO.AV_COD_CAUSA != "20") && (REGISTRO_AVISO.AV_COD_CAUSA != "23"))
            {

                /*" -2257- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2258- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2260- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2261- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2263- MOVE 'SIM' TO W-CHAVE-CRITICA. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);
            }


            /*" -2268- IF (AV-COD-NATUREZA EQUAL 2) AND (AV-COD-CAUSA NOT EQUAL '03' ) AND (AV-COD-CAUSA NOT EQUAL '16' ) AND (AV-COD-CAUSA NOT EQUAL '30' ) AND (AV-COD-CAUSA NOT EQUAL '39' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA == 2) && (REGISTRO_AVISO.AV_COD_CAUSA != "03") && (REGISTRO_AVISO.AV_COD_CAUSA != "16") && (REGISTRO_AVISO.AV_COD_CAUSA != "30") && (REGISTRO_AVISO.AV_COD_CAUSA != "39"))
            {

                /*" -2269- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2270- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2272- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2273- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2275- MOVE 'SIM' TO W-CHAVE-CRITICA. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);
            }


            /*" -2277- IF (AV-COD-NATUREZA EQUAL 3) AND (AV-COD-CAUSA NOT EQUAL '29' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA == 3) && (REGISTRO_AVISO.AV_COD_CAUSA != "29"))
            {

                /*" -2278- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2279- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2281- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2282- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2284- MOVE 'SIM' TO W-CHAVE-CRITICA. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);
            }


            /*" -2293- IF (AV-COD-NATUREZA EQUAL 4) AND (AV-COD-CAUSA NOT EQUAL '31' ) AND (AV-COD-CAUSA NOT EQUAL '32' ) AND (AV-COD-CAUSA NOT EQUAL '41' ) AND (AV-COD-CAUSA NOT EQUAL '43' ) AND (AV-COD-CAUSA NOT EQUAL '44' ) AND (AV-COD-CAUSA NOT EQUAL '46' ) AND (AV-COD-CAUSA NOT EQUAL '47' ) AND (AV-COD-CAUSA NOT EQUAL '48' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA == 4) && (REGISTRO_AVISO.AV_COD_CAUSA != "31") && (REGISTRO_AVISO.AV_COD_CAUSA != "32") && (REGISTRO_AVISO.AV_COD_CAUSA != "41") && (REGISTRO_AVISO.AV_COD_CAUSA != "43") && (REGISTRO_AVISO.AV_COD_CAUSA != "44") && (REGISTRO_AVISO.AV_COD_CAUSA != "46") && (REGISTRO_AVISO.AV_COD_CAUSA != "47") && (REGISTRO_AVISO.AV_COD_CAUSA != "48"))
            {

                /*" -2294- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2295- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2297- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2298- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2300- MOVE 'SIM' TO W-CHAVE-CRITICA. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);
            }


            /*" -2303- MOVE AV-COD-NATUREZA TO LOTISG01-COD-COBERTURA LOTCOB01-COD-COBERTURA. */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA, LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA, LOTCOB01.DCLLOTCOBER01.LOTCOB01_COD_COBERTURA);

            /*" -2305- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2317- PERFORM R500_CRITICA_APOL_ADMINIST_DB_SELECT_1 */

            R500_CRITICA_APOL_ADMINIST_DB_SELECT_1();

            /*" -2320- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -2321- DISPLAY 'ERRO SELECT LOTIMPSEG01 ........................' */
                _.Display($"ERRO SELECT LOTIMPSEG01 ........................");

                /*" -2322- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2323- DISPLAY 'APOLICE .............. ' LOTERI01-NUM-APOLICE */
                _.Display($"APOLICE .............. {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2324- DISPLAY 'RAMO-COBERTURA ....... ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO-COBERTURA ....... {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -2325- DISPLAY 'COD-MODALIDADE ....... ' APOLICES-COD-MODALIDADE */
                _.Display($"COD-MODALIDADE ....... {APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE}");

                /*" -2326- DISPLAY 'COD-COBERTURA ........ ' LOTISG01-COD-COBERTURA */
                _.Display($"COD-COBERTURA ........ {LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA}");

                /*" -2327- DISPLAY 'COD-LOT-FENAL ........ ' LOTERI01-COD-LOT-FENAL */
                _.Display($"COD-LOT-FENAL ........ {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL}");

                /*" -2328- DISPLAY 'DATA-OCORRENCIA ...... ' HOST-DATA-OCORRENCIA */
                _.Display($"DATA-OCORRENCIA ...... {HOST_DATA_OCORRENCIA}");

                /*" -2330- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2331- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -2332- DISPLAY 'LOTERI01-NUM-APOLICE    ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE    {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2333- DISPLAY 'APOLICES-RAMO-EMISSOR   ' APOLICES-RAMO-EMISSOR */
                _.Display($"APOLICES-RAMO-EMISSOR   {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -2334- DISPLAY 'APOLICES-COD-MODALIDADE ' APOLICES-COD-MODALIDADE */
                _.Display($"APOLICES-COD-MODALIDADE {APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE}");

                /*" -2335- DISPLAY 'LOTISG01-COD-COBERTURA  ' LOTISG01-COD-COBERTURA */
                _.Display($"LOTISG01-COD-COBERTURA  {LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA}");

                /*" -2336- DISPLAY 'LOTERI01-COD-LOT-FENAL  ' LOTERI01-COD-LOT-FENAL */
                _.Display($"LOTERI01-COD-LOT-FENAL  {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL}");

                /*" -2338- DISPLAY 'HOST-DATA-OCORRENCIA    ' HOST-DATA-OCORRENCIA */
                _.Display($"HOST-DATA-OCORRENCIA    {HOST_DATA_OCORRENCIA}");

                /*" -2339- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2340- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2342- MOVE 'LOTERICO NAO POSSUI COBERTURA P/ NATUREZA DO SIN.' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("LOTERICO NAO POSSUI COBERTURA P/ NATUREZA DO SIN.", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2343- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2343- MOVE 'SIM' TO W-CHAVE-CRITICA. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);
            }


        }

        [StopWatch]
        /*" R500-CRITICA-APOL-ADMINIST-DB-SELECT-1 */
        public void R500_CRITICA_APOL_ADMINIST_DB_SELECT_1()
        {
            /*" -2317- EXEC SQL SELECT IMP_SEG INTO :LOTISG01-IMP-SEG FROM SEGUROS.LOTIMPSEG01 WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND MODALIDA_COBERTURA = :APOLICES-COD-MODALIDADE AND COD_COBERTURA = :LOTISG01-COD-COBERTURA AND COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND DTINIVIG <= :HOST-DATA-OCORRENCIA AND DTTERVIG >= :HOST-DATA-OCORRENCIA WITH UR END-EXEC. */

            var r500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1 = new R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1()
            {
                APOLICES_COD_MODALIDADE = APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE.ToString(),
                LOTISG01_COD_COBERTURA = LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA.ToString(),
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
            };

            var executed_1 = R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1.Execute(r500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTISG01_IMP_SEG, LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG);
            }


        }

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-7 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_7()
        {
            /*" -1851- EXEC SQL SELECT L.COD_LOT_CEF ,L.COD_LOT_FENAL ,L.COD_CLIENTE ,L.NUM_APOLICE ,L.DTINIVIG ,L.DTTERVIG ,C.NOME_RAZAO INTO :LOTERI01-COD-LOT-CEF ,:LOTERI01-COD-LOT-FENAL ,:LOTERI01-COD-CLIENTE ,:LOTERI01-NUM-APOLICE ,:LOTERI01-DTINIVIG ,:LOTERI01-DTTERVIG ,:CLIENTES-NOME-RAZAO FROM SEGUROS.LOTERICO01 L ,SEGUROS.CLIENTES C WHERE L.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND L.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND L.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND C.COD_CLIENTE = L.COD_CLIENTE AND L.DTINIVIG = ( SELECT MAX(A.DTINIVIG) FROM SEGUROS.LOTERICO01 A WHERE A.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND A.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND A.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND A.DTINIVIG <= :HOST-DATA-OCORRENCIA AND A.DTTERVIG >= :HOST-DATA-OCORRENCIA ) AND L.DTINIVIG <= :HOST-DATA-OCORRENCIA AND L.DTTERVIG >= :HOST-DATA-OCORRENCIA END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1()
            {
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                LOTERI01_COD_LOT_CEF = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTERI01_COD_LOT_CEF, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF);
                _.Move(executed_1.LOTERI01_COD_LOT_FENAL, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL);
                _.Move(executed_1.LOTERI01_COD_CLIENTE, LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLIENTE);
                _.Move(executed_1.LOTERI01_NUM_APOLICE, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE);
                _.Move(executed_1.LOTERI01_DTINIVIG, LOTERI01.DCLLOTERICO01.LOTERI01_DTINIVIG);
                _.Move(executed_1.LOTERI01_DTTERVIG, LOTERI01.DCLLOTERICO01.LOTERI01_DTTERVIG);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-8 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_8()
        {
            /*" -1879- EXEC SQL SELECT COD_MODALIDADE ,RAMO_EMISSOR ,COD_PRODUTO INTO :APOLICES-COD-MODALIDADE ,:APOLICES-RAMO-EMISSOR ,:APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R700-CRITICA-APOL-POR-LOT */
        private void R700_CRITICA_APOL_POR_LOT(bool isPerform = false)
        {
            /*" -2372- IF ( AV-COD-NATUREZA-N < 1 OR > 19 ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N < 1 || REGISTRO_AVISO.AV_COD_NATUREZA_N > 19))
            {

                /*" -2373- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2374- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2376- MOVE 'CODIGO DA NATUREZA INVALIDO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA NATUREZA INVALIDO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2377- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2378- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2380- END-IF */
            }


            /*" -2386- IF ( AV-COD-NATUREZA-N EQUAL 1 AND ( AV-COD-CAUSA NOT EQUAL '01' AND AV-COD-CAUSA NOT EQUAL '02' AND AV-COD-CAUSA NOT EQUAL '03' AND AV-COD-CAUSA NOT EQUAL '20' AND AV-COD-CAUSA NOT EQUAL '21' ) ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 1 && (REGISTRO_AVISO.AV_COD_CAUSA != "01" && REGISTRO_AVISO.AV_COD_CAUSA != "02" && REGISTRO_AVISO.AV_COD_CAUSA != "03" && REGISTRO_AVISO.AV_COD_CAUSA != "20" && REGISTRO_AVISO.AV_COD_CAUSA != "21")))
            {

                /*" -2387- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2388- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2390- MOVE '(1) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(1) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2391- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2392- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2394- END-IF */
            }


            /*" -2406- IF ( AV-COD-NATUREZA-N EQUAL 2 AND ( AV-COD-CAUSA NOT EQUAL '10' AND AV-COD-CAUSA NOT EQUAL '11' AND AV-COD-CAUSA NOT EQUAL '14' AND AV-COD-CAUSA NOT EQUAL '31' AND AV-COD-CAUSA NOT EQUAL '32' AND AV-COD-CAUSA NOT EQUAL '41' AND AV-COD-CAUSA NOT EQUAL '43' AND AV-COD-CAUSA NOT EQUAL '44' AND AV-COD-CAUSA NOT EQUAL '46' AND AV-COD-CAUSA NOT EQUAL '47' AND AV-COD-CAUSA NOT EQUAL '48' ) ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 2 && (REGISTRO_AVISO.AV_COD_CAUSA != "10" && REGISTRO_AVISO.AV_COD_CAUSA != "11" && REGISTRO_AVISO.AV_COD_CAUSA != "14" && REGISTRO_AVISO.AV_COD_CAUSA != "31" && REGISTRO_AVISO.AV_COD_CAUSA != "32" && REGISTRO_AVISO.AV_COD_CAUSA != "41" && REGISTRO_AVISO.AV_COD_CAUSA != "43" && REGISTRO_AVISO.AV_COD_CAUSA != "44" && REGISTRO_AVISO.AV_COD_CAUSA != "46" && REGISTRO_AVISO.AV_COD_CAUSA != "47" && REGISTRO_AVISO.AV_COD_CAUSA != "48")))
            {

                /*" -2407- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2408- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2410- MOVE '(2) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(2) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2411- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2412- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2414- END-IF */
            }


            /*" -2417- IF ( AV-COD-NATUREZA-N EQUAL 3 AND ( AV-COD-CAUSA NOT EQUAL '13' AND AV-COD-CAUSA NOT EQUAL '16' ) ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 3 && (REGISTRO_AVISO.AV_COD_CAUSA != "13" && REGISTRO_AVISO.AV_COD_CAUSA != "16")))
            {

                /*" -2418- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2419- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2421- MOVE '(3) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(3) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2422- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2423- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2425- END-IF */
            }


            /*" -2427- IF ( AV-COD-NATUREZA-N EQUAL 4 AND AV-COD-CAUSA NOT EQUAL '49' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 4 && REGISTRO_AVISO.AV_COD_CAUSA != "49"))
            {

                /*" -2428- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2429- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2431- MOVE '(4) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(4) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2432- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2433- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2435- END-IF */
            }


            /*" -2437- IF (AV-COD-NATUREZA-N EQUAL 5 AND AV-COD-CAUSA NOT EQUAL '50' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 5 && REGISTRO_AVISO.AV_COD_CAUSA != "50"))
            {

                /*" -2438- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2439- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2441- MOVE '(5) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(5) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2442- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2443- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2445- END-IF */
            }


            /*" -2447- IF (AV-COD-NATUREZA-N EQUAL 6 AND AV-COD-CAUSA NOT EQUAL '45' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 6 && REGISTRO_AVISO.AV_COD_CAUSA != "45"))
            {

                /*" -2448- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2449- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2451- MOVE '(6) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(6) - CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2452- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2453- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2455- END-IF */
            }


            /*" -2458- IF ( AV-COD-NATUREZA-N EQUAL 2 AND AV-VALOR-INFORMADO < 500 AND W-ANO-PROCESSAMENTO EQUAL '2004' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 2 && REGISTRO_AVISO.AV_VALOR_INFORMADO < 500 && AREA_DE_WORK.W_ANO_PROCESSAMENTO == "2004"))
            {

                /*" -2459- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2460- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2462- MOVE '(1) $ SIN. INFERIOR A FRANQUIA VALORES (500,00)' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(1) $ SIN. INFERIOR A FRANQUIA VALORES (500,00)", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2463- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2464- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2466- END-IF */
            }


            /*" -2469- IF ( AV-COD-NATUREZA-N EQUAL 2 AND AV-VALOR-INFORMADO <= 600 AND W-ANO-PROCESSAMENTO GREATER '2004' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 2 && REGISTRO_AVISO.AV_VALOR_INFORMADO <= 600 && AREA_DE_WORK.W_ANO_PROCESSAMENTO > "2004"))
            {

                /*" -2470- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2471- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2473- MOVE '(1) $ SIN. INFERIOR A FRANQUIA VALORES (600,00)' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(1) $ SIN. INFERIOR A FRANQUIA VALORES (600,00)", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2474- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2475- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2477- END-IF */
            }


            /*" -2489- IF (AV-COD-NATUREZA-N EQUAL 7 AND ( AV-COD-CAUSA NOT EQUAL '11' AND AV-COD-CAUSA NOT EQUAL '31' AND AV-COD-CAUSA NOT EQUAL '48' ) ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 7 && (REGISTRO_AVISO.AV_COD_CAUSA != "11" && REGISTRO_AVISO.AV_COD_CAUSA != "31" && REGISTRO_AVISO.AV_COD_CAUSA != "48")))
            {

                /*" -2490- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2491- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2493- MOVE ' CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move(" CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2494- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2495- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2497- END-IF */
            }


            /*" -2509- IF (AV-COD-NATUREZA-N EQUAL 8 AND (AV-COD-CAUSA NOT EQUAL '14' AND AV-COD-CAUSA NOT EQUAL '48' ) ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 8 && (REGISTRO_AVISO.AV_COD_CAUSA != "14" && REGISTRO_AVISO.AV_COD_CAUSA != "48")))
            {

                /*" -2510- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2511- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2513- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2514- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2515- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2517- END-IF */
            }


            /*" -2520- IF ( AV-COD-NATUREZA-N EQUAL 9 ) AND ( AV-COD-CAUSA NOT EQUAL '54' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 9) && (REGISTRO_AVISO.AV_COD_CAUSA != "54"))
            {

                /*" -2521- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2522- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2524- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2525- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2526- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2528- END-IF */
            }


            /*" -2532- IF ( AV-COD-NATUREZA-N = 10 ) AND ( AV-COD-CAUSA NOT = '06' AND '08' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 10) && (!REGISTRO_AVISO.AV_COD_CAUSA.In("06", "08")))
            {

                /*" -2533- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2534- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2536- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2537- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2538- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2540- END-IF */
            }


            /*" -2543- IF ( AV-COD-NATUREZA-N EQUAL 11 ) AND ( AV-COD-CAUSA NOT EQUAL '53' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 11) && (REGISTRO_AVISO.AV_COD_CAUSA != "53"))
            {

                /*" -2544- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2545- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2547- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2548- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2549- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2551- END-IF */
            }


            /*" -2554- IF ( AV-COD-NATUREZA-N EQUAL 12 ) AND ( AV-COD-CAUSA NOT EQUAL '09' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 12) && (REGISTRO_AVISO.AV_COD_CAUSA != "09"))
            {

                /*" -2555- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2556- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2558- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2559- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2560- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2562- END-IF */
            }


            /*" -2565- IF ( AV-COD-NATUREZA-N EQUAL 13 ) AND ( AV-COD-CAUSA NOT EQUAL '28' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 13) && (REGISTRO_AVISO.AV_COD_CAUSA != "28"))
            {

                /*" -2566- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2567- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2569- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2570- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2571- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2573- END-IF */
            }


            /*" -2576- IF ( AV-COD-NATUREZA-N EQUAL 14 ) AND ( AV-COD-CAUSA NOT EQUAL '40' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 14) && (REGISTRO_AVISO.AV_COD_CAUSA != "40"))
            {

                /*" -2577- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2578- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2580- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2581- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2582- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2584- END-IF */
            }


            /*" -2587- IF ( AV-COD-NATUREZA-N EQUAL 15 ) AND ( AV-COD-CAUSA NOT EQUAL '51' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 15) && (REGISTRO_AVISO.AV_COD_CAUSA != "51"))
            {

                /*" -2588- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2589- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2591- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2592- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2593- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2596- END-IF */
            }


            /*" -2599- IF ( AV-COD-NATUREZA-N EQUAL 16 ) AND ( AV-COD-CAUSA NOT EQUAL '52' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 16) && (REGISTRO_AVISO.AV_COD_CAUSA != "52"))
            {

                /*" -2600- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2601- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2603- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2604- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2605- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2607- END-IF */
            }


            /*" -2613- IF ( AV-COD-NATUREZA-N EQUAL 17 AND ( AV-COD-CAUSA NOT EQUAL '12' AND AV-COD-CAUSA NOT EQUAL '18' AND AV-COD-CAUSA NOT EQUAL '23' AND AV-COD-CAUSA NOT EQUAL '37' )) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 17 && (REGISTRO_AVISO.AV_COD_CAUSA != "12" && REGISTRO_AVISO.AV_COD_CAUSA != "18" && REGISTRO_AVISO.AV_COD_CAUSA != "23" && REGISTRO_AVISO.AV_COD_CAUSA != "37")))
            {

                /*" -2614- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2615- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2617- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2618- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2619- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2621- END-IF */
            }


            /*" -2627- IF ( AV-COD-NATUREZA-N EQUAL 18 AND ( AV-COD-CAUSA NOT EQUAL '12' AND AV-COD-CAUSA NOT EQUAL '18' AND AV-COD-CAUSA NOT EQUAL '23' AND AV-COD-CAUSA NOT EQUAL '37' )) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 18 && (REGISTRO_AVISO.AV_COD_CAUSA != "12" && REGISTRO_AVISO.AV_COD_CAUSA != "18" && REGISTRO_AVISO.AV_COD_CAUSA != "23" && REGISTRO_AVISO.AV_COD_CAUSA != "37")))
            {

                /*" -2628- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2629- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2631- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2632- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2633- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2635- END-IF */
            }


            /*" -2641- IF ( AV-COD-NATUREZA-N EQUAL 19 AND ( AV-COD-CAUSA NOT EQUAL '12' AND AV-COD-CAUSA NOT EQUAL '18' AND AV-COD-CAUSA NOT EQUAL '23' AND AV-COD-CAUSA NOT EQUAL '37' )) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 19 && (REGISTRO_AVISO.AV_COD_CAUSA != "12" && REGISTRO_AVISO.AV_COD_CAUSA != "18" && REGISTRO_AVISO.AV_COD_CAUSA != "23" && REGISTRO_AVISO.AV_COD_CAUSA != "37")))
            {

                /*" -2642- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2643- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2645- MOVE 'CODIGO DA CAUSA INVALIDO PARA A NATUREZA' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("CODIGO DA CAUSA INVALIDO PARA A NATUREZA", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2646- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2647- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2650- END-IF */
            }


            /*" -2653- IF ( AV-COD-NATUREZA-N EQUAL 3 AND AV-VALOR-INFORMADO < 600 AND W-ANO-PROCESSAMENTO LESS '2009' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 3 && REGISTRO_AVISO.AV_VALOR_INFORMADO < 600 && AREA_DE_WORK.W_ANO_PROCESSAMENTO < "2009"))
            {

                /*" -2654- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2655- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2657- MOVE '(2) $ SIN. INFERIOR A FRANQUIA DANOS ELET.(1000,00)' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(2) $ SIN. INFERIOR A FRANQUIA DANOS ELET.(1000,00)", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2658- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2659- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2661- END-IF */
            }


            /*" -2664- IF (AV-COD-NATUREZA-N EQUAL 6 AND AV-VALOR-INFORMADO < 300 AND W-ANO-PROCESSAMENTO GREATER '2008' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 6 && REGISTRO_AVISO.AV_VALOR_INFORMADO < 300 && AREA_DE_WORK.W_ANO_PROCESSAMENTO > "2008"))
            {

                /*" -2665- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2666- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2668- MOVE '(3) $ SIN. INFERIOR A FRANQUIA RC ( 300,00)' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(3) $ SIN. INFERIOR A FRANQUIA RC ( 300,00)", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2669- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2670- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2672- END-IF */
            }


            /*" -2677- IF ( AV-COD-NATUREZA-N EQUAL 2 AND AV-COD-CAUSA EQUAL '14' AND W-ANO-PROCESSAMENTO GREATER '2004' AND (AV-INDICADOR-ADIANTAMENTO NOT EQUAL 'S' AND AV-INDICADOR-ADIANTAMENTO NOT EQUAL 'N' ) ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 2 && REGISTRO_AVISO.AV_COD_CAUSA == "14" && AREA_DE_WORK.W_ANO_PROCESSAMENTO > "2004" && (REGISTRO_AVISO.AV_INDICADOR_ADIANTAMENTO != "S" && REGISTRO_AVISO.AV_INDICADOR_ADIANTAMENTO != "N")))
            {

                /*" -2678- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2679- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2681- MOVE 'INDICADOR DE ADIANT. OBRIG. P/ ROUBO VAL. TRANSITO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("INDICADOR DE ADIANT. OBRIG. P/ ROUBO VAL. TRANSITO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2682- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2683- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2685- END-IF */
            }


            /*" -2687- IF ( APOLICES-COD-PRODUTO EQUAL 1805 AND AV-INDICADOR-ADIANTAMENTO EQUAL 'S' ) */

            if ((APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO == 1805 && REGISTRO_AVISO.AV_INDICADOR_ADIANTAMENTO == "S"))
            {

                /*" -2688- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2689- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2691- MOVE 'INDICADOR DE ADIANT. OBRIG. INVALIDO PARA CCA ' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("INDICADOR DE ADIANT. OBRIG. INVALIDO PARA CCA ", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2692- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2693- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2695- END-IF */
            }


            /*" -2698- IF (AV-COD-NATUREZA-N EQUAL 8 AND AV-COD-CAUSA EQUAL '14' AND AV-QTD-PORTADORES EQUAL 0 ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N == 8 && REGISTRO_AVISO.AV_COD_CAUSA == "14" && REGISTRO_AVISO.AV_QTD_PORTADORES == 0))
            {

                /*" -2699- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2700- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2702- MOVE 'QTD. PORTADORES OBRIG. P/ ROUBO VAL. TRANSITO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("QTD. PORTADORES OBRIG. P/ ROUBO VAL. TRANSITO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2703- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2704- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2706- END-IF */
            }


            /*" -2708- MOVE AV-COD-NATUREZA-N TO OUTROCOB-COD-COBERTURA. */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA_N, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA);

            /*" -2709- IF LOTERI01-NUM-APOLICE EQUAL 101800171271 */

            if (LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE == 101800171271)
            {

                /*" -2710- MOVE '3' TO WS-TIPO-ENDOSSO */
                _.Move("3", WS_TIPO_ENDOSSO);

                /*" -2711- ELSE */
            }
            else
            {


                /*" -2712- MOVE '9' TO WS-TIPO-ENDOSSO */
                _.Move("9", WS_TIPO_ENDOSSO);

                /*" -2714- END-IF */
            }


            /*" -2716- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2717- IF WS-DT-CANCELAMENTO = SPACES */

            if (WS_DT_CANCELAMENTO.IsEmpty())
            {

                /*" -2764- PERFORM R700_CRITICA_APOL_POR_LOT_DB_SELECT_1 */

                R700_CRITICA_APOL_POR_LOT_DB_SELECT_1();

                /*" -2766- ELSE */
            }
            else
            {


                /*" -2811- PERFORM R700_CRITICA_APOL_POR_LOT_DB_SELECT_2 */

                R700_CRITICA_APOL_POR_LOT_DB_SELECT_2();

                /*" -2814- END-IF */
            }


            /*" -2815- IF (SQLCODE NOT EQUAL ZEROS AND 100 ) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -2816- DISPLAY 'R700-ERRO SELECT OUTROS_COBERTURAS......' */
                _.Display($"R700-ERRO SELECT OUTROS_COBERTURAS......");

                /*" -2817- DISPLAY 'LOTERICO .......... ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO .......... {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2818- DISPLAY 'NUM-APOLICE.........' LOTERI01-NUM-APOLICE */
                _.Display($"NUM-APOLICE.........{LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2819- DISPLAY 'RAMO-EMISSOR........' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO-EMISSOR........{APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -2820- DISPLAY 'COD-MODALIDADE......' APOLICES-COD-MODALIDADE */
                _.Display($"COD-MODALIDADE......{APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE}");

                /*" -2821- DISPLAY 'COD-COBERTURA.......' OUTROCOB-COD-COBERTURA */
                _.Display($"COD-COBERTURA.......{OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                /*" -2822- DISPLAY 'DATA-OCORRENCIA.....' HOST-DATA-OCORRENCIA */
                _.Display($"DATA-OCORRENCIA.....{HOST_DATA_OCORRENCIA}");

                /*" -2823- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2826- END-IF */
            }


            /*" -2828- IF (SQLCODE EQUAL 100) OR (OUTROCOB-IMP-SEGURADA-IX = 0) */

            if ((DB.SQLCODE == 100) || (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX == 0))
            {

                /*" -2830- DISPLAY 'R700-SELECT OUTROS_COBERTURAS......' */
                _.Display($"R700-SELECT OUTROS_COBERTURAS......");

                /*" -2831- IF W-ANO-PROCESSAMENTO EQUAL '2004' */

                if (AREA_DE_WORK.W_ANO_PROCESSAMENTO == "2004")
                {

                    /*" -2832- DISPLAY 'LOTERI01-NUM-APOLICE ' LOTERI01-NUM-APOLICE */
                    _.Display($"LOTERI01-NUM-APOLICE {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                    /*" -2833- DISPLAY 'APOLICES-RAMO-EMISSOR ' APOLICES-RAMO-EMISSOR */
                    _.Display($"APOLICES-RAMO-EMISSOR {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                    /*" -2835- DISPLAY 'APOLICES-COD-MODALIDADE ' APOLICES-COD-MODALIDADE */
                    _.Display($"APOLICES-COD-MODALIDADE {APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE}");

                    /*" -2837- DISPLAY 'OUTROCOB-COD-COBERTURA ' OUTROCOB-COD-COBERTURA */
                    _.Display($"OUTROCOB-COD-COBERTURA {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                    /*" -2838- DISPLAY 'HOST-DATA-OCORRENCIA ' HOST-DATA-OCORRENCIA */
                    _.Display($"HOST-DATA-OCORRENCIA {HOST_DATA_OCORRENCIA}");

                    /*" -2839- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                    _.Move(AVISO?.Value, REGISTRO_RETORNO);

                    /*" -2840- MOVE ZEROS TO RE-FILLER-1 */
                    _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                    /*" -2842- MOVE 'LOTERICO NAO POSSUI COBERTURA P/ NATUREZA SIN.' TO RE-MENSAGEM LD01-MENSAGEM */
                    _.Move("LOTERICO NAO POSSUI COBERTURA P/ NATUREZA SIN.", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                    /*" -2843- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                    R120_IMPRIME_GERA_CRITICA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                    /*" -2844- MOVE 'SIM' TO W-CHAVE-CRITICA */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                    /*" -2845- ELSE */
                }
                else
                {


                    /*" -2847- IF HOST-DATA-INIVIGENCIA = '2005-01-01' AND HOST-DATA-TERVIGENCIA = '2005-12-31' */

                    if (AREA_DE_WORK.HOST_DATA_INIVIGENCIA == "2005-01-01" && AREA_DE_WORK.HOST_DATA_TERVIGENCIA == "2005-12-31")
                    {

                        /*" -2848- PERFORM R710-CONSULTA-PRAZO-CURTO THRU R710-EXIT */

                        R710_CONSULTA_PRAZO_CURTO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R710_EXIT*/


                        /*" -2849- ELSE */
                    }
                    else
                    {


                        /*" -2851- IF HOST-DATA-INIVIGENCIA = '2006-01-01' AND HOST-DATA-TERVIGENCIA = '2006-12-31' */

                        if (AREA_DE_WORK.HOST_DATA_INIVIGENCIA == "2006-01-01" && AREA_DE_WORK.HOST_DATA_TERVIGENCIA == "2006-12-31")
                        {

                            /*" -2852- PERFORM R710-CONSULTA-PRAZO-CURTO THRU R710-EXIT */

                            R710_CONSULTA_PRAZO_CURTO(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R710_EXIT*/


                            /*" -2853- ELSE */
                        }
                        else
                        {


                            /*" -2855- DISPLAY 'LOTERI01-NUM-APOLICE    ' LOTERI01-NUM-APOLICE */
                            _.Display($"LOTERI01-NUM-APOLICE    {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                            /*" -2857- DISPLAY 'APOLICES-RAMO-EMISSOR   ' APOLICES-RAMO-EMISSOR */
                            _.Display($"APOLICES-RAMO-EMISSOR   {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                            /*" -2859- DISPLAY 'APOLICES-COD-MODALIDADE ' APOLICES-COD-MODALIDADE */
                            _.Display($"APOLICES-COD-MODALIDADE {APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE}");

                            /*" -2861- DISPLAY 'OUTROCOB-COD-COBERTURA  ' OUTROCOB-COD-COBERTURA */
                            _.Display($"OUTROCOB-COD-COBERTURA  {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                            /*" -2863- DISPLAY 'HOST-DATA-OCORRENCIA    ' HOST-DATA-OCORRENCIA */
                            _.Display($"HOST-DATA-OCORRENCIA    {HOST_DATA_OCORRENCIA}");

                            /*" -2864- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                            _.Move(AVISO?.Value, REGISTRO_RETORNO);

                            /*" -2865- MOVE ZEROS TO RE-FILLER-1 */
                            _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                            /*" -2868- MOVE 'LOTERICO NAO POSSUI COBERTURA P/ NATUREZA SIN.' TO RE-MENSAGEM LD01-MENSAGEM */
                            _.Move("LOTERICO NAO POSSUI COBERTURA P/ NATUREZA SIN.", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                            /*" -2869- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                            R120_IMPRIME_GERA_CRITICA(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                            /*" -2870- MOVE 'SIM' TO W-CHAVE-CRITICA */
                            _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                            /*" -2871- END-IF */
                        }


                        /*" -2872- END-IF */
                    }


                    /*" -2873- END-IF */
                }


                /*" -2875- END-IF. */
            }


            /*" -2876- IF W-CHAVE-CRITICA EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_CRITICA == "NAO")
            {

                /*" -2877- PERFORM R750-ACHA-VALOR-BASE THRU R750-EXIT */

                R750_ACHA_VALOR_BASE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R750_EXIT*/


                /*" -2878- MOVE OUTROCOB-IMP-SEGURADA-IX TO LOTISG01-IMP-SEG */
                _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG);

                /*" -2880- END-IF */
            }


            /*" -2882- IF (AV-COD-NATUREZA-N EQUAL 2 OR 7 OR 8 ) AND (W-HOST-VALOR-SALDO-IS < 0 ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N.In("2", "7", "8")) && (W_HOST_VALOR_SALDO_IS < 0))
            {

                /*" -2883- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2884- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2886- MOVE '(7) $ VALOR DE SALDO DA IS NEGATIVO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(7) $ VALOR DE SALDO DA IS NEGATIVO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2887- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2888- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2889- GO TO R700-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/ //GOTO
                return;

                /*" -2891- END-IF */
            }


            /*" -2893- IF (AV-COD-NATUREZA-N EQUAL 2 OR 7 OR 8 ) AND (W-HOST-VALOR-SALDO-IS = 0 ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N.In("2", "7", "8")) && (W_HOST_VALOR_SALDO_IS == 0))
            {

                /*" -2894- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2895- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2897- MOVE '(9) $ VALOR DE SALDO DA IS ZERADO' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(9) $ VALOR DE SALDO DA IS ZERADO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2898- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2899- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2900- GO TO R700-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/ //GOTO
                return;

                /*" -2902- END-IF */
            }


            /*" -2905- IF AV-COD-NATUREZA-N EQUAL 2 AND W-HOST-VALOR-BASE-ADIANTAMENTO < 500 AND W-ANO-PROCESSAMENTO EQUAL '2004' */

            if (REGISTRO_AVISO.AV_COD_NATUREZA_N == 2 && AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO < 500 && AREA_DE_WORK.W_ANO_PROCESSAMENTO == "2004")
            {

                /*" -2906- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -2907- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -2909- MOVE '(8) $ VAL. BASE ADIANTAM. MENOR QUE (500,00)' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("(8) $ VAL. BASE ADIANTAM. MENOR QUE (500,00)", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -2910- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -2911- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -2913- END-IF */
            }


            /*" -2915- MOVE 'NAO' TO W-CHAVE-NAO-ADIANTA. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_NAO_ADIANTA);

            /*" -2918- IF (AV-COD-NATUREZA-N EQUAL 2 OR 7 OR 8 ) AND (W-HOST-VALOR-BASE-ADIANTAMENTO < 600 ) AND (W-ANO-PROCESSAMENTO GREATER '2004' ) */

            if ((REGISTRO_AVISO.AV_COD_NATUREZA_N.In("2", "7", "8")) && (AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO < 600) && (AREA_DE_WORK.W_ANO_PROCESSAMENTO > "2004"))
            {

                /*" -2919- MOVE 'SIM' TO W-CHAVE-NAO-ADIANTA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_NAO_ADIANTA);

                /*" -2919- END-IF. */
            }


        }

        [StopWatch]
        /*" R700-CRITICA-APOL-POR-LOT-DB-SELECT-1 */
        public void R700_CRITICA_APOL_POR_LOT_DB_SELECT_1()
        {
            /*" -2764- EXEC SQL SELECT VALUE(IMP_SEGURADA_IX,0) ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA INTO :OUTROCOB-IMP-SEGURADA-IX ,:OUTROCOB-DATA-INIVIGENCIA ,:OUTROCOB-DATA-TERVIGENCIA FROM SEGUROS.OUTROS_COBERTURAS WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND DATA_INIVIGENCIA = ( SELECT MAX(T1.DATA_INIVIGENCIA) FROM SEGUROS.OUTROS_COBERTURAS T1 ,SEGUROS.ENDOSSOS T2 WHERE T1.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND T1.RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND T1.MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND T1.COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND T1.DATA_INIVIGENCIA <= :HOST-DATA-OCORRENCIA AND T1.DATA_TERVIGENCIA >= :HOST-DATA-OCORRENCIA AND T1.NUM_APOLICE = T2.NUM_APOLICE AND T1.NUM_ENDOSSO = T2.NUM_ENDOSSO AND T2.SIT_REGISTRO <> '2' AND T2.TIPO_ENDOSSO <> :WS-TIPO-ENDOSSO ) AND TIMESTAMP = ( SELECT MAX(T3.TIMESTAMP) FROM SEGUROS.OUTROS_COBERTURAS T3, SEGUROS.ENDOSSOS T4 WHERE T3.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND T3.RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND T3.MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND T3.COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND T3.DATA_INIVIGENCIA <= :HOST-DATA-OCORRENCIA AND T3.DATA_TERVIGENCIA >= :HOST-DATA-OCORRENCIA AND T3.NUM_APOLICE = T4.NUM_APOLICE AND T3.NUM_ENDOSSO = T4.NUM_ENDOSSO AND T4.SIT_REGISTRO <> '2' AND T4.TIPO_ENDOSSO <> :WS-TIPO-ENDOSSO ) WITH UR END-EXEC */

            var r700_CRITICA_APOL_POR_LOT_DB_SELECT_1_Query1 = new R700_CRITICA_APOL_POR_LOT_DB_SELECT_1_Query1()
            {
                APOLICES_COD_MODALIDADE = APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE.ToString(),
                OUTROCOB_COD_COBERTURA = OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
                WS_TIPO_ENDOSSO = WS_TIPO_ENDOSSO.ToString(),
            };

            var executed_1 = R700_CRITICA_APOL_POR_LOT_DB_SELECT_1_Query1.Execute(r700_CRITICA_APOL_POR_LOT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OUTROCOB_IMP_SEGURADA_IX, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX);
                _.Move(executed_1.OUTROCOB_DATA_INIVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA);
                _.Move(executed_1.OUTROCOB_DATA_TERVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-9 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_9()
        {
            /*" -1911- EXEC SQL SELECT GRUPO_CAUSAS INTO :SINISCAU-GRUPO-CAUSAS FROM SEGUROS.SINISTRO_CAUSA WHERE COD_CAUSA = :SINISCAU-COD-CAUSA AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_9_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_9_Query1()
            {
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                SINISCAU_COD_CAUSA = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_9_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_GRUPO_CAUSAS, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);
            }


        }

        [StopWatch]
        /*" R700-CRITICA-APOL-POR-LOT-DB-SELECT-2 */
        public void R700_CRITICA_APOL_POR_LOT_DB_SELECT_2()
        {
            /*" -2811- EXEC SQL SELECT VALUE(IMP_SEGURADA_IX,0) ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA INTO :OUTROCOB-IMP-SEGURADA-IX ,:OUTROCOB-DATA-INIVIGENCIA ,:OUTROCOB-DATA-TERVIGENCIA FROM SEGUROS.OUTROS_COBERTURAS WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND DATA_INIVIGENCIA = ( SELECT MAX(T1.DATA_INIVIGENCIA) FROM SEGUROS.OUTROS_COBERTURAS T1 ,SEGUROS.ENDOSSOS T2 WHERE T1.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND T1.RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND T1.MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND T1.COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND T1.DATA_INIVIGENCIA <= :HOST-DATA-OCORRENCIA AND T1.DATA_TERVIGENCIA >= :HOST-DATA-OCORRENCIA AND T1.NUM_APOLICE = T2.NUM_APOLICE AND T1.NUM_ENDOSSO = T2.NUM_ENDOSSO AND T2.TIPO_ENDOSSO <> :WS-TIPO-ENDOSSO ) AND TIMESTAMP = ( SELECT MAX(T3.TIMESTAMP) FROM SEGUROS.OUTROS_COBERTURAS T3, SEGUROS.ENDOSSOS T4 WHERE T3.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND T3.RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND T3.MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND T3.COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND T3.DATA_INIVIGENCIA <= :HOST-DATA-OCORRENCIA AND T3.DATA_TERVIGENCIA >= :HOST-DATA-OCORRENCIA AND T3.NUM_APOLICE = T4.NUM_APOLICE AND T3.NUM_ENDOSSO = T4.NUM_ENDOSSO AND T4.TIPO_ENDOSSO <> :WS-TIPO-ENDOSSO ) WITH UR END-EXEC */

            var r700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1 = new R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1()
            {
                APOLICES_COD_MODALIDADE = APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE.ToString(),
                OUTROCOB_COD_COBERTURA = OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
                WS_TIPO_ENDOSSO = WS_TIPO_ENDOSSO.ToString(),
            };

            var executed_1 = R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1.Execute(r700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OUTROCOB_IMP_SEGURADA_IX, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX);
                _.Move(executed_1.OUTROCOB_DATA_INIVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA);
                _.Move(executed_1.OUTROCOB_DATA_TERVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-10 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_10()
        {
            /*" -1957- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-ACHA-LOTERICO FROM SEGUROS.SINI_LOTERICO01 S ,SEGUROS.SINISTRO_MESTRE M ,SEGUROS.SINISTRO_CAUSA C ,SEGUROS.SI_MOV_LOTERICO1 D WHERE S.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND S.COD_COBERTURA = :LOTCOB01-COD-COBERTURA AND S.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND S.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND M.NUM_APOL_SINISTRO = S.NUM_APOL_SINISTRO AND S.COD_LOT_CEF = D.COD_LOT_CEF AND M.NUM_APOL_SINISTRO = D.NUM_APOL_SINISTRO AND M.DATA_OCORRENCIA = D.DATA_OCORRENCIA AND D.HORA_OCORRENCIA = :HOST-HORA-OCORRENCIA AND M.DATA_OCORRENCIA = :HOST-DATA-OCORRENCIA AND M.DATA_COMUNICADO = :HOST-DATA-AVISO AND M.SIT_REGISTRO <> '2' AND C.RAMO_EMISSOR = M.RAMO AND C.COD_CAUSA = M.COD_CAUSA AND C.GRUPO_CAUSAS = :SINISCAU-GRUPO-CAUSAS END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1()
            {
                LOTCOB01_COD_COBERTURA = LOTCOB01.DCLLOTCOBER01.LOTCOB01_COD_COBERTURA.ToString(),
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                SINISCAU_GRUPO_CAUSAS = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
                LOTERI01_COD_LOT_CEF = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF.ToString(),
                HOST_HORA_OCORRENCIA = HOST_HORA_OCORRENCIA.ToString(),
                HOST_DATA_OCORRENCIA = HOST_DATA_OCORRENCIA.ToString(),
                HOST_DATA_AVISO = HOST_DATA_AVISO.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_ACHA_LOTERICO, HOST_ACHA_LOTERICO);
            }


        }

        [StopWatch]
        /*" R710-CONSULTA-PRAZO-CURTO */
        private void R710_CONSULTA_PRAZO_CURTO(bool isPerform = false)
        {
            /*" -2932- MOVE ZEROS TO W-HOST-TOT-PREMIO-TAR. */
            _.Move(0, W_HOST_TOT_PREMIO_TAR);

            /*" -2934- MOVE '048' TO WNR-EXEC-SQL. */
            _.Move("048", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2942- PERFORM R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1 */

            R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1();

            /*" -2945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2946- DISPLAY 'ERRO ROTINA TABELA PRAZO CURTO' */
                _.Display($"ERRO ROTINA TABELA PRAZO CURTO");

                /*" -2947- DISPLAY 'CALCULO DO PREMIO TOTAL' */
                _.Display($"CALCULO DO PREMIO TOTAL");

                /*" -2948- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2949- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2950- DISPLAY 'APOLICE NAO ENCONTRADA NA TAB PARCELA_HISTORICO' */
                _.Display($"APOLICE NAO ENCONTRADA NA TAB PARCELA_HISTORICO");

                /*" -2951- DISPLAY 'OU ERRO NO ACESSO A TABELA' */
                _.Display($"OU ERRO NO ACESSO A TABELA");

                /*" -2955- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2957- MOVE ZEROS TO W-HOST-TOT-PREMIO-PAGO. */
            _.Move(0, W_HOST_TOT_PREMIO_PAGO);

            /*" -2959- MOVE '049' TO WNR-EXEC-SQL. */
            _.Move("049", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2967- PERFORM R710_CONSULTA_PRAZO_CURTO_DB_SELECT_2 */

            R710_CONSULTA_PRAZO_CURTO_DB_SELECT_2();

            /*" -2970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2971- DISPLAY 'ERRO ROTINA TABELA PRAZO CURTO' */
                _.Display($"ERRO ROTINA TABELA PRAZO CURTO");

                /*" -2972- DISPLAY 'CALCULO DO PREMIO PAGO' */
                _.Display($"CALCULO DO PREMIO PAGO");

                /*" -2973- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -2974- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -2975- DISPLAY 'APOLICE NAO ENCONTRADA NA TAB PARCELA_HISTORICO' */
                _.Display($"APOLICE NAO ENCONTRADA NA TAB PARCELA_HISTORICO");

                /*" -2976- DISPLAY 'OU ERRO NO ACESSO A TABELA' */
                _.Display($"OU ERRO NO ACESSO A TABELA");

                /*" -2980- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2987- COMPUTE W-PERCENTUAL-PAGO ROUNDED = W-HOST-TOT-PREMIO-PAGO / W-HOST-TOT-PREMIO-TAR * 100 */
            W_PERCENTUAL_PAGO.Value = W_HOST_TOT_PREMIO_PAGO / W_HOST_TOT_PREMIO_TAR * 100;

            /*" -2994- PERFORM R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3 */

            R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3();

            /*" -2997- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2998- DISPLAY 'ERRO ROTINA TABELA PRAZO CURTO' */
                _.Display($"ERRO ROTINA TABELA PRAZO CURTO");

                /*" -2999- DISPLAY 'SELECT PRAZO_SEGURO' */
                _.Display($"SELECT PRAZO_SEGURO");

                /*" -3000- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3001- DISPLAY 'LOTERI01-NUM-APOLICE ..' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE ..{LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3002- DISPLAY 'PERCENTUAL ............' W-PERCENTUAL-PAGO */
                _.Display($"PERCENTUAL ............{W_PERCENTUAL_PAGO}");

                /*" -3003- DISPLAY 'PERCENTUAL INVALIDO PARA PESQUISA' */
                _.Display($"PERCENTUAL INVALIDO PARA PESQUISA");

                /*" -3004- DISPLAY 'OU ERRO NO ACESSO A TABELA' */
                _.Display($"OU ERRO NO ACESSO A TABELA");

                /*" -3010- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3011- MOVE HOST-DATA-INIVIGENCIA TO CA-DATA-INTER. */
            _.Move(AREA_DE_WORK.HOST_DATA_INIVIGENCIA, AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_DATA_INTER);

            /*" -3012- MOVE CORR CA-DATA-INTER TO CA-DATA-INF-PROSOMC1. */
            _.MoveCorr(AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_DATA_INTER, AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_PARM_PROSOMC1.CA_DATA_INF_PROSOMC1);

            /*" -3014- MOVE W-HOST-FIM-PRAZO TO CA-DIAS-PROSOMC1. */
            _.Move(W_HOST_FIM_PRAZO, AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_PARM_PROSOMC1.CA_DIAS_PROSOMC1);

            /*" -3016- CALL 'PROSOMC1' USING CA-PARM-PROSOMC1. */
            _.Call("PROSOMC1", AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_PARM_PROSOMC1);

            /*" -3017- IF CA-DATA-RET-PROSOMC1 EQUAL 99999999 */

            if (AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_PARM_PROSOMC1.CA_DATA_RET_PROSOMC1 == 99999999)
            {

                /*" -3018- DISPLAY 'ERRO ROTINA TABELA PRAZO CURTO' */
                _.Display($"ERRO ROTINA TABELA PRAZO CURTO");

                /*" -3019- DISPLAY 'CHAMADA A SUBROTINA ADICIONA DIAS NA DATA' */
                _.Display($"CHAMADA A SUBROTINA ADICIONA DIAS NA DATA");

                /*" -3020- DISPLAY 'LOTERICO .............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO .............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3021- DISPLAY 'LOTERI01-NUM-APOLICE .. ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE .. {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3022- DISPLAY 'DATA A SER ADICIONADA . ' HOST-DATA-INIVIGENCIA */
                _.Display($"DATA A SER ADICIONADA . {AREA_DE_WORK.HOST_DATA_INIVIGENCIA}");

                /*" -3023- DISPLAY 'DIAS A SEREM SOMADOS .. ' W-HOST-FIM-PRAZO */
                _.Display($"DIAS A SEREM SOMADOS .. {W_HOST_FIM_PRAZO}");

                /*" -3025- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3029- MOVE CORR CA-DATA-RET-PROSOMC1 TO CA-DATA-INTER. */
            _.MoveCorr(AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_PARM_PROSOMC1.CA_DATA_RET_PROSOMC1, AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_DATA_INTER);

            /*" -3030- IF HOST-DATA-OCORRENCIA > CA-DATA-INTER */

            if (HOST_DATA_OCORRENCIA > AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_DATA_INTER)
            {

                /*" -3031- DISPLAY 'LOTERI01-NUM-APOLICE    ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE    {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3032- DISPLAY 'APOLICES-RAMO-EMISSOR   ' APOLICES-RAMO-EMISSOR */
                _.Display($"APOLICES-RAMO-EMISSOR   {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -3033- DISPLAY 'APOLICES-COD-MODALIDADE ' APOLICES-COD-MODALIDADE */
                _.Display($"APOLICES-COD-MODALIDADE {APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE}");

                /*" -3034- DISPLAY 'OUTROCOB-COD-COBERTURA  ' OUTROCOB-COD-COBERTURA */
                _.Display($"OUTROCOB-COD-COBERTURA  {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                /*" -3035- DISPLAY 'HOST-DATA-OCORRENCIA    ' HOST-DATA-OCORRENCIA */
                _.Display($"HOST-DATA-OCORRENCIA    {HOST_DATA_OCORRENCIA}");

                /*" -3036- DISPLAY 'DATA PRAZO CURTO        ' CA-DATA-INTER */
                _.Display($"DATA PRAZO CURTO        {AREA_DE_WORK.WABEND.WABEND1.CA1_DATA.CA_DATA_INTER}");

                /*" -3037- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -3038- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -3040- MOVE 'DATA OCORRENCIA MAIOR QUE A DATA TAB PRAZO CURTO.' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("DATA OCORRENCIA MAIOR QUE A DATA TAB PRAZO CURTO.", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -3041- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -3043- MOVE 'SIM' TO W-CHAVE-CRITICA. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);
            }


            /*" -3072- PERFORM R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4 */

            R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4();

            /*" -3075- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -3076- DISPLAY 'ERRO SELECT SEGUROS.OUTROS_COBERTURAS...........' */
                _.Display($"ERRO SELECT SEGUROS.OUTROS_COBERTURAS...........");

                /*" -3077- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3078- DISPLAY 'NUM-APOLICE.........' LOTERI01-NUM-APOLICE */
                _.Display($"NUM-APOLICE.........{LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3079- DISPLAY 'RAMO-EMISSOR........' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO-EMISSOR........{APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -3080- DISPLAY 'COD-MODALIDADE......' APOLICES-COD-MODALIDADE */
                _.Display($"COD-MODALIDADE......{APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE}");

                /*" -3081- DISPLAY 'COD-COBERTURA.......' OUTROCOB-COD-COBERTURA */
                _.Display($"COD-COBERTURA.......{OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                /*" -3082- DISPLAY 'DATA-OCORRENCIA.....' HOST-DATA-OCORRENCIA */
                _.Display($"DATA-OCORRENCIA.....{HOST_DATA_OCORRENCIA}");

                /*" -3083- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -3085- END-IF */
            }


            /*" -3086- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3087- DISPLAY 'LOTERI01-NUM-APOLICE    ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE    {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3088- DISPLAY 'APOLICES-RAMO-EMISSOR   ' APOLICES-RAMO-EMISSOR */
                _.Display($"APOLICES-RAMO-EMISSOR   {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -3089- DISPLAY 'APOLICES-COD-MODALIDADE ' APOLICES-COD-MODALIDADE */
                _.Display($"APOLICES-COD-MODALIDADE {APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE}");

                /*" -3090- DISPLAY 'OUTROCOB-COD-COBERTURA  ' OUTROCOB-COD-COBERTURA */
                _.Display($"OUTROCOB-COD-COBERTURA  {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                /*" -3091- DISPLAY 'HOST-DATA-OCORRENCIA    ' HOST-DATA-OCORRENCIA */
                _.Display($"HOST-DATA-OCORRENCIA    {HOST_DATA_OCORRENCIA}");

                /*" -3092- MOVE REGISTRO-AVISO TO REGISTRO-RETORNO */
                _.Move(AVISO?.Value, REGISTRO_RETORNO);

                /*" -3093- MOVE ZEROS TO RE-FILLER-1 */
                _.Move(0, REGISTRO_RETORNO.RE_FILLER_1);

                /*" -3095- MOVE 'LOTERICO NAO POSSUI COBERTURA P/ NATUREZA DO SIN.' TO RE-MENSAGEM LD01-MENSAGEM */
                _.Move("LOTERICO NAO POSSUI COBERTURA P/ NATUREZA DO SIN.", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD01_A.LD01_MENSAGEM);

                /*" -3096- PERFORM R120-IMPRIME-GERA-CRITICA THRU R120-EXIT */

                R120_IMPRIME_GERA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -3097- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -3098- END-IF */
            }


            /*" -3098- . */

        }

        [StopWatch]
        /*" R710-CONSULTA-PRAZO-CURTO-DB-SELECT-1 */
        public void R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1()
        {
            /*" -2942- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),0) INTO :W-HOST-TOT-PREMIO-TAR FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND COD_OPERACAO = 101 AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1 = new R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1.Execute(r710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_TOT_PREMIO_TAR, W_HOST_TOT_PREMIO_TAR);
            }


        }

        [StopWatch]
        /*" R110-ROTINA-CRITICA-DADOS-DB-SELECT-11 */
        public void R110_ROTINA_CRITICA_DADOS_DB_SELECT_11()
        {
            /*" -2008- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,SIT_REGISTRO INTO :HOST-DATA-INIVIGENCIA ,:HOST-DATA-TERVIGENCIA ,:HOST-SIT-REGISTRO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1 = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1.Execute(r110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DATA_INIVIGENCIA, AREA_DE_WORK.HOST_DATA_INIVIGENCIA);
                _.Move(executed_1.HOST_DATA_TERVIGENCIA, AREA_DE_WORK.HOST_DATA_TERVIGENCIA);
                _.Move(executed_1.HOST_SIT_REGISTRO, HOST_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R710-CONSULTA-PRAZO-CURTO-DB-SELECT-2 */
        public void R710_CONSULTA_PRAZO_CURTO_DB_SELECT_2()
        {
            /*" -2967- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO),0) INTO :W-HOST-TOT-PREMIO-PAGO FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND COD_OPERACAO = 231 AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r710_CONSULTA_PRAZO_CURTO_DB_SELECT_2_Query1 = new R710_CONSULTA_PRAZO_CURTO_DB_SELECT_2_Query1()
            {
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R710_CONSULTA_PRAZO_CURTO_DB_SELECT_2_Query1.Execute(r710_CONSULTA_PRAZO_CURTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_TOT_PREMIO_PAGO, W_HOST_TOT_PREMIO_PAGO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R710_EXIT*/

        [StopWatch]
        /*" R710-CONSULTA-PRAZO-CURTO-DB-SELECT-3 */
        public void R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3()
        {
            /*" -2994- EXEC SQL SELECT MAX(FIM_PRAZO) INTO :W-HOST-FIM-PRAZO FROM SEGUROS.PRAZO_SEGURO WHERE COD_TABELA = 5 AND PCT_PRM_ANUAL <= :W-PERCENTUAL-PAGO WITH UR END-EXEC. */

            var r710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1 = new R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1()
            {
                W_PERCENTUAL_PAGO = W_PERCENTUAL_PAGO.ToString(),
            };

            var executed_1 = R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1.Execute(r710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_FIM_PRAZO, W_HOST_FIM_PRAZO);
            }


        }

        [StopWatch]
        /*" R750-ACHA-VALOR-BASE */
        private void R750_ACHA_VALOR_BASE(bool isPerform = false)
        {
            /*" -3108- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3116- PERFORM R750_ACHA_VALOR_BASE_DB_SELECT_1 */

            R750_ACHA_VALOR_BASE_DB_SELECT_1();

            /*" -3119- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3120- DISPLAY 'ERRO SELECT NA BUSCA DA CLASSE DO LOTERICO......' */
                _.Display($"ERRO SELECT NA BUSCA DA CLASSE DO LOTERICO......");

                /*" -3121- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3123- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3124- IF W-HOST-VALOR-BASE-AVISO > OUTROCOB-IMP-SEGURADA-IX */

            if (AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO > OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX)
            {

                /*" -3127- MOVE OUTROCOB-IMP-SEGURADA-IX TO W-HOST-VALOR-BASE-AVISO W-HOST-VALOR-BASE-ADIANTAMENTO. */
                _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);
            }


            /*" -3128- IF SINISCAU-GRUPO-CAUSAS EQUAL 'VALORES' */

            if (SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "VALORES")
            {

                /*" -3131- MOVE W-HOST-VALOR-BASE-AVISO TO W-HOST-VALOR-BASE-ADIANTAMENTO. */
                _.Move(AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);
            }


            /*" -3133- IF SINISCAU-GRUPO-CAUSAS EQUAL 'VALORES' AND AV-COD-CAUSA EQUAL '14' */

            if (SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "VALORES" && REGISTRO_AVISO.AV_COD_CAUSA == "14")
            {

                /*" -3134- IF APOLICES-COD-PRODUTO EQUAL 1805 */

                if (APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO == 1805)
                {

                    /*" -3135- IF HOST-DATA-INIVIGENCIA < '2015-11-01' */

                    if (AREA_DE_WORK.HOST_DATA_INIVIGENCIA < "2015-11-01")
                    {

                        /*" -3137- IF AV-QTD-PORTADORES = 1 AND W-HOST-VALOR-BASE-AVISO > 3500 */

                        if (REGISTRO_AVISO.AV_QTD_PORTADORES == 1 && AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO > 3500)
                        {

                            /*" -3139- MOVE 3500 TO W-HOST-VALOR-BASE-AVISO W-HOST-VALOR-BASE-ADIANTAMENTO */
                            _.Move(3500, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);

                            /*" -3140- END-IF */
                        }


                        /*" -3141- ELSE */
                    }
                    else
                    {


                        /*" -3143- IF AV-QTD-PORTADORES = 1 AND W-HOST-VALOR-BASE-AVISO > 4000 */

                        if (REGISTRO_AVISO.AV_QTD_PORTADORES == 1 && AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO > 4000)
                        {

                            /*" -3145- MOVE 4000 TO W-HOST-VALOR-BASE-AVISO W-HOST-VALOR-BASE-ADIANTAMENTO */
                            _.Move(4000, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);

                            /*" -3146- END-IF */
                        }


                        /*" -3147- END-IF */
                    }


                    /*" -3148- ELSE */
                }
                else
                {


                    /*" -3149- IF HOST-DATA-INIVIGENCIA < '2016-01-01' */

                    if (AREA_DE_WORK.HOST_DATA_INIVIGENCIA < "2016-01-01")
                    {

                        /*" -3151- IF AV-QTD-PORTADORES = 1 AND W-HOST-VALOR-BASE-AVISO > 3500 */

                        if (REGISTRO_AVISO.AV_QTD_PORTADORES == 1 && AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO > 3500)
                        {

                            /*" -3153- MOVE 3500 TO W-HOST-VALOR-BASE-AVISO W-HOST-VALOR-BASE-ADIANTAMENTO */
                            _.Move(3500, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);

                            /*" -3154- END-IF */
                        }


                        /*" -3155- ELSE */
                    }
                    else
                    {


                        /*" -3157- IF AV-QTD-PORTADORES = 1 AND W-HOST-VALOR-BASE-AVISO > 4000 */

                        if (REGISTRO_AVISO.AV_QTD_PORTADORES == 1 && AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO > 4000)
                        {

                            /*" -3159- MOVE 4000 TO W-HOST-VALOR-BASE-AVISO W-HOST-VALOR-BASE-ADIANTAMENTO */
                            _.Move(4000, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);

                            /*" -3160- END-IF */
                        }


                        /*" -3161- END-IF */
                    }


                    /*" -3162- END-IF */
                }


                /*" -3164- IF AV-QTD-PORTADORES > 1 AND W-HOST-VALOR-BASE-AVISO > 17500 */

                if (REGISTRO_AVISO.AV_QTD_PORTADORES > 1 && AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO > 17500)
                {

                    /*" -3166- MOVE 17500 TO W-HOST-VALOR-BASE-AVISO W-HOST-VALOR-BASE-ADIANTAMENTO */
                    _.Move(17500, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);

                    /*" -3167- END-IF */
                }


                /*" -3171- END-IF */
            }


            /*" -3172- IF SINISCAU-GRUPO-CAUSAS EQUAL 'VALORES' */

            if (SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "VALORES")
            {

                /*" -3173- IF LOTERI01-COD-CLASSE-ADESAO EQUAL 'A' OR 'E' */

                if (LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLASSE_ADESAO.In("A", "E"))
                {

                    /*" -3174- MOVE 7,5 TO W-PERCENTUAL-FRANQUIA */
                    _.Move(7.5, W_PERCENTUAL_FRANQUIA);

                    /*" -3175- ELSE */
                }
                else
                {


                    /*" -3176- IF LOTERI01-COD-CLASSE-ADESAO EQUAL 'B' */

                    if (LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLASSE_ADESAO == "B")
                    {

                        /*" -3177- MOVE 15 TO W-PERCENTUAL-FRANQUIA */
                        _.Move(15, W_PERCENTUAL_FRANQUIA);

                        /*" -3178- ELSE */
                    }
                    else
                    {


                        /*" -3179- IF LOTERI01-COD-CLASSE-ADESAO EQUAL 'C' OR 'D' OR 'F' */

                        if (LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLASSE_ADESAO.In("C", "D", "F"))
                        {

                            /*" -3180- MOVE 30 TO W-PERCENTUAL-FRANQUIA */
                            _.Move(30, W_PERCENTUAL_FRANQUIA);

                            /*" -3181- ELSE */
                        }
                        else
                        {


                            /*" -3191- MOVE 0 TO W-PERCENTUAL-FRANQUIA. */
                            _.Move(0, W_PERCENTUAL_FRANQUIA);
                        }

                    }

                }

            }


            /*" -3192- IF SINISCAU-GRUPO-CAUSAS EQUAL 'VALORES' */

            if (SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "VALORES")
            {

                /*" -3193- IF W-ANO-PROCESSAMENTO EQUAL '2004' */

                if (AREA_DE_WORK.W_ANO_PROCESSAMENTO == "2004")
                {

                    /*" -3194- PERFORM R5010-CALCULA-SALDO-IS THRU R5010-EXIT */

                    R5010_CALCULA_SALDO_IS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R5010_EXIT*/


                    /*" -3195- ELSE */
                }
                else
                {


                    /*" -3196- IF W-ANO-PROCESSAMENTO GREATER '2004' */

                    if (AREA_DE_WORK.W_ANO_PROCESSAMENTO > "2004")
                    {

                        /*" -3198- PERFORM R5020-SUBROTINA-CALC-SALDO THRU R5020-EXIT. */

                        R5020_SUBROTINA_CALC_SALDO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5020_EXIT*/

                    }

                }

            }


            /*" -3200- MOVE 'NAO' TO W-CHAVE-ADIANTA-SALDO-IS. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ADIANTA_SALDO_IS);

            /*" -3201- IF SINISCAU-GRUPO-CAUSAS EQUAL 'VALORES' */

            if (SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "VALORES")
            {

                /*" -3202- IF W-HOST-VALOR-BASE-AVISO > W-HOST-VALOR-SALDO-IS */

                if (AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO > W_HOST_VALOR_SALDO_IS)
                {

                    /*" -3204- MOVE W-HOST-VALOR-SALDO-IS TO W-HOST-VALOR-BASE-ADIANTAMENTO */
                    _.Move(W_HOST_VALOR_SALDO_IS, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);

                    /*" -3206- MOVE W-HOST-VALOR-SALDO-IS TO W-HOST-VALOR-BASE-AVISO */
                    _.Move(W_HOST_VALOR_SALDO_IS, AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO);

                    /*" -3207- MOVE 'SIM' TO W-CHAVE-ADIANTA-SALDO-IS */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ADIANTA_SALDO_IS);

                    /*" -3208- ELSE */
                }
                else
                {


                    /*" -3211- MOVE W-HOST-VALOR-BASE-AVISO TO W-HOST-VALOR-BASE-ADIANTAMENTO. */
                    _.Move(AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);
                }

            }


            /*" -3212- IF W-HOST-VALOR-BASE-ADIANTAMENTO < 0 */

            if (AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO < 0)
            {

                /*" -3214- MOVE ZEROS TO W-HOST-VALOR-BASE-ADIANTAMENTO. */
                _.Move(0, AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO);
            }


            /*" -3215- MOVE W-HOST-VALOR-BASE-AVISO TO W-VALOR-PARA-AVISO. */
            _.Move(AREA_DE_WORK.W_HOST_VALOR_BASE_AVISO, AREA_DE_WORK.W_VALOR_PARA_AVISO);

            /*" -3217- MOVE W-HOST-VALOR-BASE-ADIANTAMENTO TO W-VALOR-ADIANTAMENTO. */
            _.Move(AREA_DE_WORK.W_HOST_VALOR_BASE_ADIANTAMENTO, AREA_DE_WORK.W_VALOR_ADIANTAMENTO);

            /*" -3218- MOVE W-HOST-VALOR-SALDO-IS TO W-EDICAO */
            _.Move(W_HOST_VALOR_SALDO_IS, AREA_DE_WORK.W_EDICAO);

            /*" -3219- MOVE W-VALOR-PARA-AVISO TO W-EDICAO1 */
            _.Move(AREA_DE_WORK.W_VALOR_PARA_AVISO, AREA_DE_WORK.W_EDICAO1);

            /*" -3220- MOVE W-VALOR-ADIANTAMENTO TO W-EDICAO2 */
            _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, AREA_DE_WORK.W_EDICAO2);

            /*" -3221- MOVE AV-VALOR-INFORMADO TO W-EDICAO3 */
            _.Move(REGISTRO_AVISO.AV_VALOR_INFORMADO, AREA_DE_WORK.W_EDICAO3);

            /*" -3223- MOVE OUTROCOB-IMP-SEGURADA-IX TO W-EDICAO4 */
            _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, AREA_DE_WORK.W_EDICAO4);

            /*" -3231- DISPLAY 'R750-LOT=' LOTERI01-COD-LOT-CEF ' AP=' LOTERI01-NUM-APOLICE ' AV=' W-EDICAO3 ' IS=' W-EDICAO4 ' SDIS=' W-EDICAO ' V.BASE=' W-EDICAO1 ' V.BASE ADIANTA' W-EDICAO2 ' CHAVE ADIANTA ' W-CHAVE-ADIANTA-SALDO-IS. */

            $"R750-LOT={LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF} AP={LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE} AV={AREA_DE_WORK.W_EDICAO3} IS={AREA_DE_WORK.W_EDICAO4} SDIS={AREA_DE_WORK.W_EDICAO} V.BASE={AREA_DE_WORK.W_EDICAO1} V.BASE ADIANTA{AREA_DE_WORK.W_EDICAO2} CHAVE ADIANTA {AREA_DE_WORK.W_CHAVE_ADIANTA_SALDO_IS}"
            .Display();

            /*" -3231- . */

        }

        [StopWatch]
        /*" R750-ACHA-VALOR-BASE-DB-SELECT-1 */
        public void R750_ACHA_VALOR_BASE_DB_SELECT_1()
        {
            /*" -3116- EXEC SQL SELECT DISTINCT (COD_CLASSE_ADESAO) INTO :LOTERI01-COD-CLASSE-ADESAO FROM SEGUROS.LOTERICO01 WHERE COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND NUM_APOLICE = :LOTERI01-NUM-APOLICE ORDER BY COD_CLASSE_ADESAO END-EXEC. */

            var r750_ACHA_VALOR_BASE_DB_SELECT_1_Query1 = new R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1()
            {
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                LOTERI01_COD_LOT_CEF = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1.Execute(r750_ACHA_VALOR_BASE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTERI01_COD_CLASSE_ADESAO, LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLASSE_ADESAO);
            }


        }

        [StopWatch]
        /*" R710-CONSULTA-PRAZO-CURTO-DB-SELECT-4 */
        public void R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4()
        {
            /*" -3072- EXEC SQL SELECT VALUE(IMP_SEGURADA_IX,0), DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :OUTROCOB-IMP-SEGURADA-IX, :OUTROCOB-DATA-INIVIGENCIA, :OUTROCOB-DATA-TERVIGENCIA FROM SEGUROS.OUTROS_COBERTURAS WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND DATA_INIVIGENCIA = ( SELECT MAX(DATA_INIVIGENCIA) FROM SEGUROS.OUTROS_COBERTURAS WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA ) AND TIMESTAMP = ( SELECT MAX(TIMESTAMP) FROM SEGUROS.OUTROS_COBERTURAS WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA ) WITH UR END-EXEC. */

            var r710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1 = new R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1()
            {
                APOLICES_COD_MODALIDADE = APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE.ToString(),
                OUTROCOB_COD_COBERTURA = OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1.Execute(r710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OUTROCOB_IMP_SEGURADA_IX, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX);
                _.Move(executed_1.OUTROCOB_DATA_INIVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA);
                _.Move(executed_1.OUTROCOB_DATA_TERVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R750_EXIT*/

        [StopWatch]
        /*" R5010-CALCULA-SALDO-IS */
        private void R5010_CALCULA_SALDO_IS(bool isPerform = false)
        {
            /*" -3240- MOVE ZEROS TO W-HOST-AVISOS W-HOST-VAL-AVISOS W-HOST-INDENIZ-EFETIVADAS W-HOST-VALOR-SALDO-IS. */
            _.Move(0, W_HOST_AVISOS, W_HOST_VAL_AVISOS, W_HOST_INDENIZ_EFETIVADAS, W_HOST_VALOR_SALDO_IS);

            /*" -3244- PERFORM R9001-LE-PERCETUAL-ADIANTA THRU R9001-EXIT. */

            R9001_LE_PERCETUAL_ADIANTA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9001_EXIT*/


            /*" -3245- PERFORM R8000-DECLARE-SINISTROS-APOL THRU R8000-EXIT. */

            R8000_DECLARE_SINISTROS_APOL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_EXIT*/


            /*" -3246- MOVE 'NAO' TO WFIM-SINISTROS-APOLICE. */
            _.Move("NAO", AREA_DE_WORK.WFIM_SINISTROS_APOLICE);

            /*" -3248- PERFORM R8001-FETCH-SINISTROS-APOL THRU R8001-EXIT. */

            R8001_FETCH_SINISTROS_APOL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8001_EXIT*/


            /*" -3253- PERFORM R8010-PROCESSA-SINISTROS-APOL THRU R8010-EXIT UNTIL WFIM-SINISTROS-APOLICE EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_SINISTROS_APOLICE == "SIM"))
            {

                R8010_PROCESSA_SINISTROS_APOL(true);

                R8010_LE_NOVO_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_EXIT*/

            }

            /*" -3257- COMPUTE W-HOST-VALOR-SALDO-IS = (OUTROCOB-IMP-SEGURADA-IX * 3) - ( W-HOST-VAL-AVISOS + W-HOST-INDENIZ-EFETIVADAS ). */
            W_HOST_VALOR_SALDO_IS.Value = (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX * 3) - (W_HOST_VAL_AVISOS + W_HOST_INDENIZ_EFETIVADAS);

            /*" -3258- MOVE W-HOST-VALOR-SALDO-IS TO W-EDICAO. */
            _.Move(W_HOST_VALOR_SALDO_IS, AREA_DE_WORK.W_EDICAO);

            /*" -3259- DISPLAY 'VAL-AVISOS         ' W-HOST-VAL-AVISOS. */
            _.Display($"VAL-AVISOS         {W_HOST_VAL_AVISOS}");

            /*" -3260- DISPLAY 'INDENIZ-EFETIVADAS ' W-HOST-INDENIZ-EFETIVADAS. */
            _.Display($"INDENIZ-EFETIVADAS {W_HOST_INDENIZ_EFETIVADAS}");

            /*" -3260- DISPLAY 'SALDO IS           ......' W-EDICAO. */
            _.Display($"SALDO IS           ......{AREA_DE_WORK.W_EDICAO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5010_EXIT*/

        [StopWatch]
        /*" R5020-SUBROTINA-CALC-SALDO */
        private void R5020_SUBROTINA_CALC_SALDO(bool isPerform = false)
        {
            /*" -3270- MOVE ZEROS TO LK2-RTCODE. */
            _.Move(0, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_RTCODE);

            /*" -3271- MOVE LOTERI01-NUM-APOLICE TO LK2-LOTERI01-NUM-APOLICE. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_LOTERI01_NUM_APOLICE);

            /*" -3272- MOVE AV-COD-NATUREZA TO LK2-AV-COD-NATUREZA. */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_AV_COD_NATUREZA);

            /*" -3273- MOVE LOTERI01-COD-LOT-CEF TO LK2-LOTERI01-COD-LOT-CEF. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_LOTERI01_COD_LOT_CEF);

            /*" -3274- MOVE LOTERI01-COD-LOT-FENAL TO LK2-LOTERI01-COD-LOT-FENAL. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_LOTERI01_COD_LOT_FENAL);

            /*" -3275- MOVE OUTROCOB-IMP-SEGURADA-IX TO LK2-IMP-SEGURADA-IX. */
            _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_IMP_SEGURADA_IX);

            /*" -3276- MOVE OUTROCOB-DATA-INIVIGENCIA TO LK2-DATA-INIVIGENCIA. */
            _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_DATA_INIVIGENCIA);

            /*" -3278- MOVE OUTROCOB-DATA-TERVIGENCIA TO LK2-DATA-TERVIGENCIA. */
            _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_DATA_TERVIGENCIA);

            /*" -3280- CALL SI0006S USING LK2-LINK. */
            _.Call(SI0006S, AREA_DE_WORK.WABEND.WABEND1.LK2_LINK);

            /*" -3281- IF LK2-RTCODE NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_RTCODE != 00)
            {

                /*" -3282- DISPLAY 'PROBLEMA ROTINA CALCULA SALDO SI0006S' */
                _.Display($"PROBLEMA ROTINA CALCULA SALDO SI0006S");

                /*" -3283- DISPLAY 'LK2-RTCODE = ' LK2-RTCODE */
                _.Display($"LK2-RTCODE = {AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_RTCODE}");

                /*" -3284- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -3286- END-IF. */
            }


            /*" -3287- MOVE LK2-W-HOST-VALOR-SALDO-IS TO W-HOST-VALOR-SALDO-IS. */
            _.Move(AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_W_HOST_VALOR_SALDO_IS, W_HOST_VALOR_SALDO_IS);

            /*" -3288- MOVE LK2-W-HOST-VAL-AVISOS TO W-HOST-VAL-AVISOS. */
            _.Move(AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_W_HOST_VAL_AVISOS, W_HOST_VAL_AVISOS);

            /*" -3290- MOVE LK2-W-HOST-INDENIZ-EFETIV TO W-HOST-INDENIZ-EFETIVADAS. */
            _.Move(AREA_DE_WORK.WABEND.WABEND1.LK2_LINK.LK2_W_HOST_INDENIZ_EFETIV, W_HOST_INDENIZ_EFETIVADAS);

            /*" -3292- DISPLAY 'SALDO IS = ' W-HOST-VALOR-SALDO-IS ' AVISO = ' W-HOST-VAL-AVISOS ' INDENIZ = ' W-HOST-INDENIZ-EFETIVADAS. */

            $"SALDO IS = {W_HOST_VALOR_SALDO_IS} AVISO = {W_HOST_VAL_AVISOS} INDENIZ = {W_HOST_INDENIZ_EFETIVADAS}"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5020_EXIT*/

        [StopWatch]
        /*" R8000-DECLARE-SINISTROS-APOL */
        private void R8000_DECLARE_SINISTROS_APOL(bool isPerform = false)
        {
            /*" -3302- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3321- PERFORM R8000_DECLARE_SINISTROS_APOL_DB_DECLARE_1 */

            R8000_DECLARE_SINISTROS_APOL_DB_DECLARE_1();

            /*" -3325- PERFORM R8000_DECLARE_SINISTROS_APOL_DB_OPEN_1 */

            R8000_DECLARE_SINISTROS_APOL_DB_OPEN_1();

            /*" -3328- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3330- DISPLAY 'LOTERICO ...................... ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ...................... {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3332- DISPLAY 'LOTERI01-NUM-APOLICE .......... ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE .......... {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3334- DISPLAY 'OUTROCOB-COD-COBERTURA ........ ' OUTROCOB-COD-COBERTURA */
                _.Display($"OUTROCOB-COD-COBERTURA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                /*" -3336- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ..... ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -3338- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ..... ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -3338- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8000-DECLARE-SINISTROS-APOL-DB-DECLARE-1 */
        public void R8000_DECLARE_SINISTROS_APOL_DB_DECLARE_1()
        {
            /*" -3321- EXEC SQL DECLARE SINISTRO_APOL CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.VAL_OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL WHERE SL.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND SL.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND SL.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND SL.COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND H.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND H.COD_OPERACAO = 101 AND M.SIT_REGISTRO <> '2' ORDER BY H.NUM_APOL_SINISTRO WITH UR END-EXEC. */
            SINISTRO_APOL = new SI0005B_SINISTRO_APOL(true);
            string GetQuery_SINISTRO_APOL()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINI_LOTERICO01 SL 
							WHERE SL.NUM_APOLICE = '{LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}' 
							AND SL.COD_LOT_CEF = '{LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}' 
							AND SL.COD_LOT_FENAL = '{LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL}' 
							AND SL.COD_COBERTURA = '{OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}' 
							AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO 
							AND H.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO 
							AND H.COD_OPERACAO = 101 
							AND M.SIT_REGISTRO <> '2' 
							ORDER BY H.NUM_APOL_SINISTRO";

                return query;
            }
            SINISTRO_APOL.GetQueryEvent += GetQuery_SINISTRO_APOL;

        }

        [StopWatch]
        /*" R8000-DECLARE-SINISTROS-APOL-DB-OPEN-1 */
        public void R8000_DECLARE_SINISTROS_APOL_DB_OPEN_1()
        {
            /*" -3325- EXEC SQL OPEN SINISTRO_APOL END-EXEC. */

            SINISTRO_APOL.Open();

        }

        [StopWatch]
        /*" R1090-INCLUI-DOC01-DB-DECLARE-1 */
        public void R1090_INCLUI_DOC01_DB_DECLARE_1()
        {
            /*" -4803- EXEC SQL DECLARE DOCUMENTOS CURSOR FOR SELECT COD_DOCUMENTO FROM SEGUROS.SINI_LOT_DOC02 WHERE COD_COBERTURA = :SILOTDC2-COD-COBERTURA ORDER BY COD_DOCUMENTO WITH UR END-EXEC. */
            DOCUMENTOS = new SI0005B_DOCUMENTOS(true);
            string GetQuery_DOCUMENTOS()
            {
                var query = @$"SELECT COD_DOCUMENTO 
							FROM SEGUROS.SINI_LOT_DOC02 
							WHERE COD_COBERTURA = '{SILOTDC2.DCLSINI_LOT_DOC02.SILOTDC2_COD_COBERTURA}' 
							ORDER BY COD_DOCUMENTO";

                return query;
            }
            DOCUMENTOS.GetQueryEvent += GetQuery_DOCUMENTOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_EXIT*/

        [StopWatch]
        /*" R8001-FETCH-SINISTROS-APOL */
        private void R8001_FETCH_SINISTROS_APOL(bool isPerform = false)
        {
            /*" -3346- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3349- PERFORM R8001_FETCH_SINISTROS_APOL_DB_FETCH_1 */

            R8001_FETCH_SINISTROS_APOL_DB_FETCH_1();

            /*" -3352- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3353- MOVE W-HOST-VALOR-AVISADO-OPER-101 TO W-EDICAO */
                _.Move(W_HOST_VALOR_AVISADO_OPER_101, AREA_DE_WORK.W_EDICAO);

                /*" -3357- DISPLAY 'SIN. SELECIONADO ........ ' SINISHIS-NUM-APOL-SINISTRO ' VAL. OP 101 .... ' W-EDICAO. */

                $"SIN. SELECIONADO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} VAL. OP 101 .... {AREA_DE_WORK.W_EDICAO}"
                .Display();
            }


            /*" -3358- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -3360- DISPLAY 'LOTERICO ...................... ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ...................... {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3362- DISPLAY 'LOTERI01-NUM-APOLICE .......... ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE .......... {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3364- DISPLAY 'OUTROCOB-COD-COBERTURA ........ ' OUTROCOB-COD-COBERTURA */
                _.Display($"OUTROCOB-COD-COBERTURA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                /*" -3366- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ..... ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -3368- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ..... ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -3370- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3372- MOVE '023' TO WNR-EXEC-SQL. */
            _.Move("023", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3373- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3374- MOVE 'SIM' TO WFIM-SINISTROS-APOLICE */
                _.Move("SIM", AREA_DE_WORK.WFIM_SINISTROS_APOLICE);

                /*" -3374- PERFORM R8001_FETCH_SINISTROS_APOL_DB_CLOSE_1 */

                R8001_FETCH_SINISTROS_APOL_DB_CLOSE_1();

                /*" -3376- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3378- DISPLAY 'LOTERICO ...................... ' LOTERI01-COD-LOT-CEF */
                    _.Display($"LOTERICO ...................... {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                    /*" -3380- DISPLAY 'LOTERI01-NUM-APOLICE .......... ' LOTERI01-NUM-APOLICE */
                    _.Display($"LOTERI01-NUM-APOLICE .......... {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                    /*" -3382- DISPLAY 'OUTROCOB-COD-COBERTURA ........ ' OUTROCOB-COD-COBERTURA */
                    _.Display($"OUTROCOB-COD-COBERTURA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                    /*" -3384- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ..... ' OUTROCOB-DATA-INIVIGENCIA */
                    _.Display($"OUTROCOB-DATA-INIVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                    /*" -3386- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ..... ' OUTROCOB-DATA-TERVIGENCIA */
                    _.Display($"OUTROCOB-DATA-TERVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                    /*" -3386- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8001-FETCH-SINISTROS-APOL-DB-FETCH-1 */
        public void R8001_FETCH_SINISTROS_APOL_DB_FETCH_1()
        {
            /*" -3349- EXEC SQL FETCH SINISTRO_APOL INTO :SINISHIS-NUM-APOL-SINISTRO, :W-HOST-VALOR-AVISADO-OPER-101 END-EXEC. */

            if (SINISTRO_APOL.Fetch())
            {
                _.Move(SINISTRO_APOL.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(SINISTRO_APOL.W_HOST_VALOR_AVISADO_OPER_101, W_HOST_VALOR_AVISADO_OPER_101);
            }

        }

        [StopWatch]
        /*" R8001-FETCH-SINISTROS-APOL-DB-CLOSE-1 */
        public void R8001_FETCH_SINISTROS_APOL_DB_CLOSE_1()
        {
            /*" -3374- EXEC SQL CLOSE SINISTRO_APOL END-EXEC */

            SINISTRO_APOL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8001_EXIT*/

        [StopWatch]
        /*" R8010-PROCESSA-SINISTROS-APOL */
        private void R8010_PROCESSA_SINISTROS_APOL(bool isPerform = false)
        {
            /*" -3397- MOVE ZEROS TO W-HOST-VALOR-CALCULADO-1 W-HOST-VALOR-CALCULADO-99 W-HOST-VALOR-FRANQUIA. */
            _.Move(0, W_HOST_VALOR_CALCULADO_1, W_HOST_VALOR_CALCULADO_99, W_HOST_VALOR_FRANQUIA);

            /*" -3399- PERFORM R8100-INDENIZ-EFETIVADAS THRU R8100-EXIT. */

            R8100_INDENIZ_EFETIVADAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_EXIT*/


            /*" -3400- IF W-HOST-VALOR-CALCULADO-1 > 0 */

            if (W_HOST_VALOR_CALCULADO_1 > 0)
            {

                /*" -3404- PERFORM R8101-BUSCA-FRANQUIA THRU R8101-EXIT. */

                R8101_BUSCA_FRANQUIA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8101_EXIT*/

            }


            /*" -3406- PERFORM R8150-EST-INDENIZ-EFETIVADAS THRU R8150-EXIT. */

            R8150_EST_INDENIZ_EFETIVADAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8150_EXIT*/


            /*" -3411- COMPUTE W-HOST-INDENIZ-SINISTRO = W-HOST-VALOR-CALCULADO-1 + W-HOST-VALOR-FRANQUIA - W-HOST-VALOR-CALCULADO-99. */
            W_HOST_INDENIZ_SINISTRO.Value = W_HOST_VALOR_CALCULADO_1 + W_HOST_VALOR_FRANQUIA - W_HOST_VALOR_CALCULADO_99;

            /*" -3415- COMPUTE W-HOST-INDENIZ-EFETIVADAS = W-HOST-INDENIZ-EFETIVADAS + W-HOST-INDENIZ-SINISTRO. */
            W_HOST_INDENIZ_EFETIVADAS.Value = W_HOST_INDENIZ_EFETIVADAS + W_HOST_INDENIZ_SINISTRO;

            /*" -3416- MOVE W-HOST-INDENIZ-SINISTRO TO W-EDICAO */
            _.Move(W_HOST_INDENIZ_SINISTRO, AREA_DE_WORK.W_EDICAO);

            /*" -3417- DISPLAY 'VALOR INDENIZADO   ......' W-EDICAO. */
            _.Display($"VALOR INDENIZADO   ......{AREA_DE_WORK.W_EDICAO}");

            /*" -3418- IF W-HOST-INDENIZ-SINISTRO > 0 */

            if (W_HOST_INDENIZ_SINISTRO > 0)
            {

                /*" -3422- GO TO R8010-LE-NOVO-SINISTRO. */

                R8010_LE_NOVO_SINISTRO(); //GOTO
                return;
            }


            /*" -3423- PERFORM R8002-BUSCA-ADIANTAMENTOS THRU R8002-EXIT. */

            R8002_BUSCA_ADIANTAMENTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8002_EXIT*/


            /*" -3424- DISPLAY 'W-HOST-VALOR-ADIANTA2 ' W-HOST-VALOR-ADIANTA2. */
            _.Display($"W-HOST-VALOR-ADIANTA2 {W_HOST_VALOR_ADIANTA2}");

            /*" -3428- COMPUTE W-VALOR-BASE-ADIANTA ROUNDED = W-HOST-VALOR-ADIANTA2 * 100 / SIPARADI-PERC-ADIANTAMENTO. */
            W_VALOR_BASE_ADIANTA.Value = W_HOST_VALOR_ADIANTA2 * 100 / SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO;

            /*" -3429- IF W-HOST-VALOR-AVISADO-OPER-101 > W-VALOR-BASE-ADIANTA */

            if (W_HOST_VALOR_AVISADO_OPER_101 > W_VALOR_BASE_ADIANTA)
            {

                /*" -3430- MOVE W-HOST-VALOR-ADIANTA2 TO W-VALOR-BASE-ADIANTA */
                _.Move(W_HOST_VALOR_ADIANTA2, W_VALOR_BASE_ADIANTA);

                /*" -3431- END-IF */
            }


            /*" -3433- COMPUTE W-HOST-VAL-AVISOS = W-HOST-VAL-AVISOS + W-VALOR-BASE-ADIANTA. */
            W_HOST_VAL_AVISOS.Value = W_HOST_VAL_AVISOS + W_VALOR_BASE_ADIANTA;

        }

        [StopWatch]
        /*" R8010-LE-NOVO-SINISTRO */
        private void R8010_LE_NOVO_SINISTRO(bool isPerform = false)
        {
            /*" -3437- PERFORM R8001-FETCH-SINISTROS-APOL THRU R8001-EXIT. */

            R8001_FETCH_SINISTROS_APOL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8001_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_EXIT*/

        [StopWatch]
        /*" R8100-INDENIZ-EFETIVADAS */
        private void R8100_INDENIZ_EFETIVADAS(bool isPerform = false)
        {
            /*" -3445- MOVE ZEROS TO W-HOST-VALOR-CALCULADO-1. */
            _.Move(0, W_HOST_VALOR_CALCULADO_1);

            /*" -3447- MOVE '024' TO WNR-EXEC-SQL. */
            _.Move("024", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3453- PERFORM R8100_INDENIZ_EFETIVADAS_DB_SELECT_1 */

            R8100_INDENIZ_EFETIVADAS_DB_SELECT_1();

            /*" -3456- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -3457- DISPLAY 'R8100-INDENIZ-EFETIVADAS' */
                _.Display($"R8100-INDENIZ-EFETIVADAS");

                /*" -3458- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3459- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3461- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ........ ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -3463- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ........ ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -3464- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -3464- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8100-INDENIZ-EFETIVADAS-DB-SELECT-1 */
        public void R8100_INDENIZ_EFETIVADAS_DB_SELECT_1()
        {
            /*" -3453- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :W-HOST-VALOR-CALCULADO-1 FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO IN (1003 , 1004) END-EXEC. */

            var r8100_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1 = new R8100_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R8100_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1.Execute(r8100_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_VALOR_CALCULADO_1, W_HOST_VALOR_CALCULADO_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_EXIT*/

        [StopWatch]
        /*" R8101-BUSCA-FRANQUIA */
        private void R8101_BUSCA_FRANQUIA(bool isPerform = false)
        {
            /*" -3474- PERFORM R8101_BUSCA_FRANQUIA_DB_SELECT_1 */

            R8101_BUSCA_FRANQUIA_DB_SELECT_1();

            /*" -3477- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -3478- DISPLAY 'R8100-INDENIZ-EFETIVADAS' */
                _.Display($"R8100-INDENIZ-EFETIVADAS");

                /*" -3479- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3480- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3482- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ........ ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -3484- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ........ ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -3485- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -3485- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8101-BUSCA-FRANQUIA-DB-SELECT-1 */
        public void R8101_BUSCA_FRANQUIA_DB_SELECT_1()
        {
            /*" -3474- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :W-HOST-VALOR-FRANQUIA FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO IN (21) END-EXEC. */

            var r8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1 = new R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1.Execute(r8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_VALOR_FRANQUIA, W_HOST_VALOR_FRANQUIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8101_EXIT*/

        [StopWatch]
        /*" R8150-EST-INDENIZ-EFETIVADAS */
        private void R8150_EST_INDENIZ_EFETIVADAS(bool isPerform = false)
        {
            /*" -3493- MOVE ZEROS TO W-HOST-VALOR-CALCULADO-99. */
            _.Move(0, W_HOST_VALOR_CALCULADO_99);

            /*" -3495- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3508- PERFORM R8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1 */

            R8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1();

            /*" -3511- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -3512- DISPLAY 'R8150-EST-INDENIZ-EFETIVADAS' */
                _.Display($"R8150-EST-INDENIZ-EFETIVADAS");

                /*" -3513- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3514- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3516- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ........ ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -3518- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ........ ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -3519- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -3519- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8150-EST-INDENIZ-EFETIVADAS-DB-SELECT-1 */
        public void R8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1()
        {
            /*" -3508- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :W-HOST-VALOR-CALCULADO-99 FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO = 1050 AND H.OCORR_HISTORICO IN ( SELECT DISTINCT H1.OCORR_HISTORICO FROM SEGUROS.SINISTRO_HISTORICO H1 WHERE H1.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H1.COD_OPERACAO IN (1003 , 1004) ) END-EXEC. */

            var r8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1 = new R8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1.Execute(r8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_VALOR_CALCULADO_99, W_HOST_VALOR_CALCULADO_99);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8150_EXIT*/

        [StopWatch]
        /*" R8002-BUSCA-ADIANTAMENTOS */
        private void R8002_BUSCA_ADIANTAMENTOS(bool isPerform = false)
        {
            /*" -3527- MOVE ZEROS TO W-HOST-VALOR-ADIANTA2. */
            _.Move(0, W_HOST_VALOR_ADIANTA2);

            /*" -3529- MOVE '045' TO WNR-EXEC-SQL. */
            _.Move("045", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3535- PERFORM R8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1 */

            R8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1();

            /*" -3538- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -3539- DISPLAY 'BUSCA-ADIANTAMENTOS         ' */
                _.Display($"BUSCA-ADIANTAMENTOS         ");

                /*" -3540- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3541- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -3543- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ........ ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -3545- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ........ ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -3546- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -3546- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8002-BUSCA-ADIANTAMENTOS-DB-SELECT-1 */
        public void R8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1()
        {
            /*" -3535- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :W-HOST-VALOR-ADIANTA2 FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO = 1070 END-EXEC. */

            var r8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1 = new R8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1.Execute(r8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_VALOR_ADIANTA2, W_HOST_VALOR_ADIANTA2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8002_EXIT*/

        [StopWatch]
        /*" R9001-LE-PERCETUAL-ADIANTA */
        private void R9001_LE_PERCETUAL_ADIANTA(bool isPerform = false)
        {
            /*" -3554- MOVE AV-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(REGISTRO_AVISO.AV_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -3555- MOVE AV-COD-NATUREZA-N TO SIPARADI-COD-COBERTURA. */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA_N, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA);

            /*" -3557- MOVE '027' TO WNR-EXEC-SQL. */
            _.Move("027", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3572- PERFORM R9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1 */

            R9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1();

            /*" -3575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3576- DISPLAY 'ERRO SELECT SI_PARAM_ADIANT ....................' */
                _.Display($"ERRO SELECT SI_PARAM_ADIANT ....................");

                /*" -3577- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3578- DISPLAY 'COBERTURA ............ ' LOTISG01-COD-COBERTURA */
                _.Display($"COBERTURA ............ {LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA}");

                /*" -3578- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9001-LE-PERCETUAL-ADIANTA-DB-SELECT-1 */
        public void R9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1()
        {
            /*" -3572- EXEC SQL SELECT P.COD_PRODUTO, P.COD_COBERTURA, P.PERC_ADIANTAMENTO INTO :SIPARADI-COD-PRODUTO, :SIPARADI-COD-COBERTURA, :SIPARADI-PERC-ADIANTAMENTO FROM SEGUROS.SI_PARAM_ADIANT P, SEGUROS.APOLICES A WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE AND P.COD_PRODUTO = A.COD_PRODUTO AND P.COD_COBERTURA = :SIPARADI-COD-COBERTURA AND P.DATA_INIVIGENCIA <= CURRENT DATE AND P.DATA_TERVIGENCIA >= CURRENT DATE WITH UR END-EXEC. */

            var r9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1 = new R9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1()
            {
                SIPARADI_COD_COBERTURA = SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA.ToString(),
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1.Execute(r9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIPARADI_COD_PRODUTO, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_PRODUTO);
                _.Move(executed_1.SIPARADI_COD_COBERTURA, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA);
                _.Move(executed_1.SIPARADI_PERC_ADIANTAMENTO, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9001_EXIT*/

        [StopWatch]
        /*" R120-IMPRIME-GERA-CRITICA */
        private void R120_IMPRIME_GERA_CRITICA(bool isPerform = false)
        {
            /*" -3585- MOVE AV-NOME-LOTERICO TO RE-NOME-LOTERICO */
            _.Move(REGISTRO_AVISO.AV_NOME_LOTERICO, REGISTRO_RETORNO.RE_NOME_LOTERICO);

            /*" -3586- MOVE AV-DATA-OCORRENCIA TO RE-DATA-OCORRENCIA */
            _.Move(REGISTRO_AVISO.AV_DATA_OCORRENCIA, REGISTRO_RETORNO.RE_DATA_OCORRENCIA);

            /*" -3587- MOVE AV-HORA-OCORRENCIA TO RE-HORA-OCORRENCIA */
            _.Move(REGISTRO_AVISO.AV_HORA_OCORRENCIA, REGISTRO_RETORNO.RE_HORA_OCORRENCIA);

            /*" -3588- MOVE AV-DATA-GERACAO TO RE-DATA-GERACAO */
            _.Move(REGISTRO_AVISO.AV_DATA_GERACAO, REGISTRO_RETORNO.RE_DATA_GERACAO);

            /*" -3589- MOVE AV-DATA-AVISO TO RE-DATA-AVISO */
            _.Move(REGISTRO_AVISO.AV_DATA_AVISO, REGISTRO_RETORNO.RE_DATA_AVISO);

            /*" -3590- MOVE AV-HORA-AVISO TO RE-HORA-AVISO */
            _.Move(REGISTRO_AVISO.AV_HORA_AVISO, REGISTRO_RETORNO.RE_HORA_AVISO);

            /*" -3591- MOVE AV-VALOR-INFORMADO TO RE-VALOR-INFORMADO */
            _.Move(REGISTRO_AVISO.AV_VALOR_INFORMADO, REGISTRO_RETORNO.RE_VALOR_INFORMADO);

            /*" -3592- MOVE AV-COD-NATUREZA TO RE-COD-NATUREZA */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA, REGISTRO_RETORNO.RE_COD_NATUREZA);

            /*" -3594- MOVE AV-COD-CAUSA TO RE-COD-CAUSA */
            _.Move(REGISTRO_AVISO.AV_COD_CAUSA, REGISTRO_RETORNO.RE_COD_CAUSA);

            /*" -3595- MOVE AV-COD-LOT-CEF TO LD01-COD-LOT-CEF. */
            _.Move(REGISTRO_AVISO.AV_COD_LOT_CEF, AREA_DE_WORK.LD01.LD01_COD_LOT_CEF);

            /*" -3596- MOVE AV-NOME-LOTERICO TO LD01-NOME. */
            _.Move(REGISTRO_AVISO.AV_NOME_LOTERICO, AREA_DE_WORK.LD01.LD01_NOME);

            /*" -3597- MOVE AV-DATA-OCORRENCIA TO LD01-DATA-OCORRENCIA. */
            _.Move(REGISTRO_AVISO.AV_DATA_OCORRENCIA, AREA_DE_WORK.LD01.LD01_DATA_OCORRENCIA);

            /*" -3598- MOVE AV-HORA-OCORRENCIA TO LD01-HORA-OCORRENCIA. */
            _.Move(REGISTRO_AVISO.AV_HORA_OCORRENCIA, AREA_DE_WORK.LD01.LD01_HORA_OCORRENCIA);

            /*" -3599- MOVE AV-DATA-GERACAO TO LD01-DATA-GERACAO. */
            _.Move(REGISTRO_AVISO.AV_DATA_GERACAO, AREA_DE_WORK.LD01.LD01_DATA_GERACAO);

            /*" -3600- MOVE AV-DATA-AVISO TO LD01-DATA-AVISO. */
            _.Move(REGISTRO_AVISO.AV_DATA_AVISO, AREA_DE_WORK.LD01_A.LD01_DATA_AVISO);

            /*" -3601- MOVE AV-HORA-AVISO TO LD01-HORA-AVISO. */
            _.Move(REGISTRO_AVISO.AV_HORA_AVISO, AREA_DE_WORK.LD01_A.LD01_HORA_AVISO);

            /*" -3602- MOVE AV-VALOR-INFORMADO TO LD01-VALOR-INFORMADO. */
            _.Move(REGISTRO_AVISO.AV_VALOR_INFORMADO, AREA_DE_WORK.LD01_A.LD01_VALOR_INFORMADO);

            /*" -3603- MOVE AV-COD-NATUREZA TO LD01-COD-NATUREZA. */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA, AREA_DE_WORK.LD01_A.LD01_COD_NATUREZA);

            /*" -3604- MOVE AV-COD-CAUSA TO LD01-COD-CAUSA. */
            _.Move(REGISTRO_AVISO.AV_COD_CAUSA, AREA_DE_WORK.LD01_A.LD01_COD_CAUSA);

            /*" -3606- MOVE 1 TO RE-INDICADOR-CRITICA. */
            _.Move(1, REGISTRO_RETORNO.RE_FILLER_1.RE_INDICADOR_CRITICA);

            /*" -3608- ADD 1 TO W-REG-GRAV-RETORNO. */
            AREA_DE_WORK.W_REG_GRAV_RETORNO.Value = AREA_DE_WORK.W_REG_GRAV_RETORNO + 1;

            /*" -3609- IF W-CONTA-LINHA GREATER 60 */

            if (AREA_DE_WORK.W_CONTA_LINHA > 60)
            {

                /*" -3611- PERFORM R9000-CABECALHO-CRITICA THRU R9000-EXIT. */

                R9000_CABECALHO_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_EXIT*/

            }


            /*" -3612- WRITE REGISTRO-CRITICA FROM LD01 AFTER 1. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REGISTRO_CRITICA);

            RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

            /*" -3613- WRITE REGISTRO-CRITICA FROM LD01-A AFTER 1. */
            _.Move(AREA_DE_WORK.LD01_A.GetMoveValues(), REGISTRO_CRITICA);

            RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

            /*" -3614- WRITE REGISTRO-CRITICA FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REGISTRO_CRITICA);

            RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

            /*" -3616- ADD 3 TO W-CONTA-LINHA. */
            AREA_DE_WORK.W_CONTA_LINHA.Value = AREA_DE_WORK.W_CONTA_LINHA + 3;

            /*" -3618- WRITE REGISTRO-RETORNO. */
            RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

            /*" -3618- INITIALIZE LD01. */
            _.Initialize(
                AREA_DE_WORK.LD01
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-IMPRIME-GERA-AVISO-OK */
        private void R130_IMPRIME_GERA_AVISO_OK(bool isPerform = false)
        {
            /*" -3625- MOVE AV-COD-LOT-CEF TO LD02-COD-LOT-CEF */
            _.Move(REGISTRO_AVISO.AV_COD_LOT_CEF, AREA_DE_WORK.LD02.LD02_COD_LOT_CEF);

            /*" -3626- MOVE AV-NOME-LOTERICO TO LD02-NOME */
            _.Move(REGISTRO_AVISO.AV_NOME_LOTERICO, AREA_DE_WORK.LD02.LD02_NOME);

            /*" -3627- MOVE AV-DATA-OCORRENCIA TO W-DATA-AAAAMMDD */
            _.Move(REGISTRO_AVISO.AV_DATA_OCORRENCIA, AREA_DE_WORK.W_DATA_AAAAMMDD);

            /*" -3628- MOVE W-DATA-AAAAMMDD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -3629- MOVE W-DATA-AAAAMMDD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -3630- MOVE W-DATA-AAAAMMDD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -3631- MOVE W-DATA-DD-MM-AAAA TO LD02-DATA-OCORRENCIA */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD02.LD02_DATA_OCORRENCIA);

            /*" -3632- MOVE AV-VALOR-INFORMADO TO LD02-VALOR-INFORMADO */
            _.Move(REGISTRO_AVISO.AV_VALOR_INFORMADO, AREA_DE_WORK.LD02.LD02_VALOR_INFORMADO);

            /*" -3634- MOVE W-VALOR-PARA-AVISO TO LD02-VALOR-REGISTRADO RE-VALOR-REGISTRADO */
            _.Move(AREA_DE_WORK.W_VALOR_PARA_AVISO, AREA_DE_WORK.LD02.LD02_VALOR_REGISTRADO, REGISTRO_RETORNO.RE_FILLER_1.RE_VALOR_REGISTRADO);

            /*" -3635- MOVE LOTISG01-IMP-SEG TO RE-VALOR-IS */
            _.Move(LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG, REGISTRO_RETORNO.RE_FILLER_1.RE_VALOR_IS);

            /*" -3638- MOVE W-VALOR-ADIANTAMENTO TO LD02-VALOR-ADIANTAMENTO RE-VALOR-ADIANTAMENTO */
            _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, AREA_DE_WORK.LD02.LD02_VALOR_ADIANTAMENTO, REGISTRO_RETORNO.RE_FILLER_1.RE_VALOR_ADIANTAMENTO);

            /*" -3641- MOVE W-VALOR-ADIANTAMENTO TO W-EDICAO */
            _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, AREA_DE_WORK.W_EDICAO);

            /*" -3643- MOVE SIPARADI-PERC-ADIANTAMENTO TO RE-PERC-ADIANTAMENTO */
            _.Move(SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO, REGISTRO_RETORNO.RE_FILLER_1.RE_PERC_ADIANTAMENTO);

            /*" -3644- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -3645- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-AAAAMMDD-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -3646- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-AAAAMMDD-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -3647- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-AAAAMMDD-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -3648- MOVE W-DATA-AAAAMMDD TO RE-DATA-MOVIMENTO */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, REGISTRO_RETORNO.RE_FILLER_1.RE_DATA_MOVIMENTO);

            /*" -3650- MOVE SINISMES-NUM-APOL-SINISTRO TO RE-NUM-APOL-SINISTRO LD02-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, REGISTRO_RETORNO.RE_FILLER_1.RE_NUM_APOL_SINISTRO, AREA_DE_WORK.LD02.LD02_NUM_APOL_SINISTRO);

            /*" -3656- MOVE SINISMES-NUM-APOL-SINISTRO TO RE-NUM-APOL-SINISTRO LD02-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, REGISTRO_RETORNO.RE_FILLER_1.RE_NUM_APOL_SINISTRO, AREA_DE_WORK.LD02.LD02_NUM_APOL_SINISTRO);

            /*" -3658- DISPLAY 'PRODUTO DA APOLICE = ' APOLICES-COD-PRODUTO */
            _.Display($"PRODUTO DA APOLICE = {APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO}");

            /*" -3660- MOVE APOLICES-COD-PRODUTO TO RE-PRODUTO */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, REGISTRO_RETORNO.RE_FILLER_1.RE_PRODUTO);

            /*" -3661- IF AV-VALOR-INFORMADO NOT EQUAL W-VALOR-PARA-AVISO */

            if (REGISTRO_AVISO.AV_VALOR_INFORMADO != AREA_DE_WORK.W_VALOR_PARA_AVISO)
            {

                /*" -3662- MOVE 3 TO RE-INDICADOR-CRITICA */
                _.Move(3, REGISTRO_RETORNO.RE_FILLER_1.RE_INDICADOR_CRITICA);

                /*" -3664- MOVE 'AVISO COM ALTERACAO' TO RE-MENSAGEM LD02-MENSAGEM */
                _.Move("AVISO COM ALTERACAO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD02.LD02_MENSAGEM);

                /*" -3665- ELSE */
            }
            else
            {


                /*" -3666- MOVE 2 TO RE-INDICADOR-CRITICA */
                _.Move(2, REGISTRO_RETORNO.RE_FILLER_1.RE_INDICADOR_CRITICA);

                /*" -3668- MOVE 'AVISO EFETUADO' TO RE-MENSAGEM LD02-MENSAGEM */
                _.Move("AVISO EFETUADO", REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM, AREA_DE_WORK.LD02.LD02_MENSAGEM);

                /*" -3670- END-IF */
            }


            /*" -3671- DISPLAY '  VL INFORMADO: ' AV-VALOR-INFORMADO */
            _.Display($"  VL INFORMADO: {REGISTRO_AVISO.AV_VALOR_INFORMADO}");

            /*" -3672- DISPLAY '  VL AVISO    : ' W-VALOR-PARA-AVISO */
            _.Display($"  VL AVISO    : {AREA_DE_WORK.W_VALOR_PARA_AVISO}");

            /*" -3674- DISPLAY '  MSG         : ' RE-MENSAGEM */
            _.Display($"  MSG         : {REGISTRO_RETORNO.RE_FILLER_1.RE_MENSAGEM}");

            /*" -3676- MOVE '028' TO WNR-EXEC-SQL. */
            _.Move("028", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3699- PERFORM R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1 */

            R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1();

            /*" -3702- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3703- MOVE LOTERI01-BANCO TO RE-BANCO */
                _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_BANCO, REGISTRO_RETORNO.RE_FILLER_1.RE_BANCO);

                /*" -3704- MOVE LOTERI01-AGENCIA TO RE-AGENCIA */
                _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA, REGISTRO_RETORNO.RE_FILLER_1.RE_AGENCIA);

                /*" -3705- MOVE LOTERI01-OPERACAO-CONTA TO RE-OPERACAO */
                _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_OPERACAO_CONTA, REGISTRO_RETORNO.RE_FILLER_1.RE_OPERACAO);

                /*" -3706- MOVE LOTERI01-NUMERO-CONTA TO RE-CONTA */
                _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUMERO_CONTA, REGISTRO_RETORNO.RE_FILLER_1.RE_CONTA);

                /*" -3707- MOVE LOTERI01-DV-CONTA TO RE-DV */
                _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DV_CONTA, REGISTRO_RETORNO.RE_FILLER_1.RE_DV);

                /*" -3708- ELSE */
            }
            else
            {


                /*" -3709- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3713- MOVE ZEROS TO LOTERI01-BANCO LOTERI01-AGENCIA LOTERI01-OPERACAO-CONTA LOTERI01-NUMERO-CONTA */
                    _.Move(0, LOTERI01.DCLLOTERICO01.LOTERI01_BANCO, LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA, LOTERI01.DCLLOTERICO01.LOTERI01_OPERACAO_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_NUMERO_CONTA);

                    /*" -3714- MOVE SPACES TO LOTERI01-DV-CONTA */
                    _.Move("", LOTERI01.DCLLOTERICO01.LOTERI01_DV_CONTA);

                    /*" -3715- ELSE */
                }
                else
                {


                    /*" -3716- DISPLAY 'R0130-ERRO SELECT CONTA CORR - LOTERICO01' */
                    _.Display($"R0130-ERRO SELECT CONTA CORR - LOTERICO01");

                    /*" -3717- DISPLAY 'LOT=' LOTERI01-COD-LOT-CEF */
                    _.Display($"LOT={LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                    /*" -3718- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -3719- END-IF */
                }


                /*" -3722- END-IF. */
            }


            /*" -3724- MOVE '029' TO WNR-EXEC-SQL. */
            _.Move("029", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3734- PERFORM R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2 */

            R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2();

            /*" -3737- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3738- DISPLAY 'ERRO SELECT QUANTIDADE DE AVISADOS .............' */
                _.Display($"ERRO SELECT QUANTIDADE DE AVISADOS .............");

                /*" -3739- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3741- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3743- MOVE HOST-COUNT TO RE-QTD-SINI-AVISADO. */
            _.Move(HOST_COUNT, REGISTRO_RETORNO.RE_FILLER_1.RE_QTD_SINI_AVISADO);

            /*" -3745- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3764- PERFORM R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3 */

            R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3();

            /*" -3767- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3768- DISPLAY 'ERRO SELECT QUANTIDADE DE PAGOS ................' */
                _.Display($"ERRO SELECT QUANTIDADE DE PAGOS ................");

                /*" -3769- DISPLAY 'LOTERICO ............. ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3771- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3773- MOVE HOST-COUNT TO RE-QTD-SINI-PAGO. */
            _.Move(HOST_COUNT, REGISTRO_RETORNO.RE_FILLER_1.RE_QTD_SINI_PAGO);

            /*" -3774- MOVE RE-BANCO TO LD04-BANCO. */
            _.Move(REGISTRO_RETORNO.RE_FILLER_1.RE_BANCO, AREA_DE_WORK.LD04.LD04_BANCO);

            /*" -3775- MOVE RE-AGENCIA TO LD04-AGENCIA. */
            _.Move(REGISTRO_RETORNO.RE_FILLER_1.RE_AGENCIA, AREA_DE_WORK.LD04.LD04_AGENCIA);

            /*" -3776- MOVE RE-OPERACAO TO LD04-OPERACAO. */
            _.Move(REGISTRO_RETORNO.RE_FILLER_1.RE_OPERACAO, AREA_DE_WORK.LD04.LD04_OPERACAO);

            /*" -3777- MOVE RE-CONTA TO LD04-CONTA. */
            _.Move(REGISTRO_RETORNO.RE_FILLER_1.RE_CONTA, AREA_DE_WORK.LD04.LD04_CONTA);

            /*" -3778- MOVE RE-DV TO LD04-DV. */
            _.Move(REGISTRO_RETORNO.RE_FILLER_1.RE_DV, AREA_DE_WORK.LD04.LD04_DV);

            /*" -3779- MOVE RE-QTD-SINI-AVISADO TO LD04-QTD-SIN-AVISADO. */
            _.Move(REGISTRO_RETORNO.RE_FILLER_1.RE_QTD_SINI_AVISADO, AREA_DE_WORK.LD04.LD04_QTD_SIN_AVISADO);

            /*" -3781- MOVE RE-QTD-SINI-PAGO TO LD04-QTD-SIN-PAGOS. */
            _.Move(REGISTRO_RETORNO.RE_FILLER_1.RE_QTD_SINI_PAGO, AREA_DE_WORK.LD04.LD04_QTD_SIN_PAGOS);

            /*" -3782- IF W-VALOR-ADIANTAMENTO NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_VALOR_ADIANTAMENTO != 00)
            {

                /*" -3783- IF APOLICES-RAMO-EMISSOR EQUAL 18 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 18)
                {

                    /*" -3784- IF W-VALOR-ADIANTAMENTO <= 30000 */

                    if (AREA_DE_WORK.W_VALOR_ADIANTAMENTO <= 30000)
                    {

                        /*" -3787- MOVE '***  GERADO AUTOMAT. A PRE-LIB. E LIB. DE ADIANT.  ***' TO LD04-MENSAGEM */
                        _.Move("***  GERADO AUTOMAT. A PRE-LIB. E LIB. DE ADIANT.  ***", AREA_DE_WORK.LD04.LD04_MENSAGEM);

                        /*" -3788- ELSE */
                    }
                    else
                    {


                        /*" -3791- MOVE 'PRE-LIB. DE ADIANT. PENDENTE DE LIBERACAO' TO LD04-MENSAGEM */
                        _.Move("PRE-LIB. DE ADIANT. PENDENTE DE LIBERACAO", AREA_DE_WORK.LD04.LD04_MENSAGEM);

                        /*" -3792- ELSE */
                    }

                }
                else
                {


                    /*" -3793- IF W-VALOR-ADIANTAMENTO <= 20000 */

                    if (AREA_DE_WORK.W_VALOR_ADIANTAMENTO <= 20000)
                    {

                        /*" -3796- MOVE '***  GERADO AUTOMAT. A PRE-LIB. E LIB. DE ADIANT.  ***' TO LD04-MENSAGEM */
                        _.Move("***  GERADO AUTOMAT. A PRE-LIB. E LIB. DE ADIANT.  ***", AREA_DE_WORK.LD04.LD04_MENSAGEM);

                        /*" -3797- ELSE */
                    }
                    else
                    {


                        /*" -3799- MOVE 'PRE-LIB. DE ADIANT. PENDENTE DE LIBERACAO' TO LD04-MENSAGEM */
                        _.Move("PRE-LIB. DE ADIANT. PENDENTE DE LIBERACAO", AREA_DE_WORK.LD04.LD04_MENSAGEM);

                        /*" -3800- ELSE */
                    }

                }

            }
            else
            {


                /*" -3802- MOVE 'SINISTRO SEM ADIANTAMENTO' TO LD04-MENSAGEM. */
                _.Move("SINISTRO SEM ADIANTAMENTO", AREA_DE_WORK.LD04.LD04_MENSAGEM);
            }


            /*" -3803- IF W-CONTA-LINHA-AVISOOK GREATER 60 */

            if (AREA_DE_WORK.W_CONTA_LINHA_AVISOOK > 60)
            {

                /*" -3805- PERFORM R9005-IMPRIME-CABEC-AVISOOK THRU R9005-EXIT. */

                R9005_IMPRIME_CABEC_AVISOOK(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9005_EXIT*/

            }


            /*" -3806- WRITE REGISTRO-AVISOOK FROM LD02 AFTER 2. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -3807- WRITE REGISTRO-AVISOOK FROM LD04 AFTER 1. */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -3808- WRITE REGISTRO-AVISOOK FROM LD05 AFTER 1. */
            _.Move(AREA_DE_WORK.LD05.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -3810- ADD 4 TO W-CONTA-LINHA-AVISOOK. */
            AREA_DE_WORK.W_CONTA_LINHA_AVISOOK.Value = AREA_DE_WORK.W_CONTA_LINHA_AVISOOK + 4;

            /*" -3812- ADD 1 TO W-REG-GRAV-RETORNO. */
            AREA_DE_WORK.W_REG_GRAV_RETORNO.Value = AREA_DE_WORK.W_REG_GRAV_RETORNO + 1;

            /*" -3814- WRITE REGISTRO-RETORNO. */
            RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

            /*" -3814- INITIALIZE LD02. */
            _.Initialize(
                AREA_DE_WORK.LD02
            );

        }

        [StopWatch]
        /*" R130-IMPRIME-GERA-AVISO-OK-DB-SELECT-1 */
        public void R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1()
        {
            /*" -3699- EXEC SQL SELECT VALUE(L.BANCO,999), VALUE(L.AGENCIA,999), VALUE(L.OPERACAO_CONTA,9999), VALUE(L.NUMERO_CONTA,999999999999), VALUE(L.DV_CONTA, '9' ) INTO :LOTERI01-BANCO, :LOTERI01-AGENCIA, :LOTERI01-OPERACAO-CONTA, :LOTERI01-NUMERO-CONTA, :LOTERI01-DV-CONTA FROM SEGUROS.LOTERICO01 L WHERE L.COD_LOT_CEF = :SINILT01-COD-LOT-CEF AND L.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND L.DTTERVIG = ( SELECT MAX(A.DTTERVIG) FROM SEGUROS.LOTERICO01 A WHERE A.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND A.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL ) WITH UR END-EXEC. */

            var r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1 = new R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1()
            {
                SINILT01_COD_LOT_FENAL = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL.ToString(),
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                SINILT01_COD_LOT_CEF = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF.ToString(),
                LOTERI01_COD_LOT_CEF = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF.ToString(),
            };

            var executed_1 = R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1.Execute(r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTERI01_BANCO, LOTERI01.DCLLOTERICO01.LOTERI01_BANCO);
                _.Move(executed_1.LOTERI01_AGENCIA, LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA);
                _.Move(executed_1.LOTERI01_OPERACAO_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_OPERACAO_CONTA);
                _.Move(executed_1.LOTERI01_NUMERO_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_NUMERO_CONTA);
                _.Move(executed_1.LOTERI01_DV_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_DV_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R130-IMPRIME-GERA-AVISO-OK-DB-SELECT-2 */
        public void R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2()
        {
            /*" -3734- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.SINI_LOTERICO01 SL, SEGUROS.SINISTRO_MESTRE M WHERE SL.COD_LOT_CEF = :SINILT01-COD-LOT-CEF AND SL.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND SL.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND M.SIT_REGISTRO <> '2' END-EXEC. */

            var r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2_Query1 = new R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2_Query1()
            {
                SINILT01_COD_LOT_FENAL = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL.ToString(),
                SINILT01_COD_LOT_CEF = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2_Query1.Execute(r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1000-GRAVA-SINISTRO */
        private void R1000_GRAVA_SINISTRO(bool isPerform = false)
        {
            /*" -3824- INITIALIZE DCLSINISTRO-MESTRE DCLSINISTRO-HISTORICO. */
            _.Initialize(
                SINISMES.DCLSINISTRO_MESTRE
                , SINISHIS.DCLSINISTRO_HISTORICO
            );

            /*" -3825- IF APOLICES-RAMO-EMISSOR = 71 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 71)
            {

                /*" -3826- IF AV-VALOR-INFORMADO GREATER LOTISG01-IMP-SEG */

                if (REGISTRO_AVISO.AV_VALOR_INFORMADO > LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG)
                {

                    /*" -3830- MOVE LOTISG01-IMP-SEG TO W-VALOR-PARA-AVISO. */
                    _.Move(LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG, AREA_DE_WORK.W_VALOR_PARA_AVISO);
                }

            }


            /*" -3832- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3833- MOVE AV-COD-NATUREZA-N TO LOTISG01-COD-COBERTURA. */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA_N, LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA);

            /*" -3846- PERFORM R1000_GRAVA_SINISTRO_DB_SELECT_1 */

            R1000_GRAVA_SINISTRO_DB_SELECT_1();

            /*" -3849- IF SQLCODE < ZEROS */

            if (DB.SQLCODE < 00)
            {

                /*" -3850- DISPLAY 'R1000-ERRO SELECT SI_PARAM_ADIANT .....' */
                _.Display($"R1000-ERRO SELECT SI_PARAM_ADIANT .....");

                /*" -3851- DISPLAY 'LOTERICO ..... ' LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ..... {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -3852- DISPLAY 'COBERTURA .... ' LOTISG01-COD-COBERTURA */
                _.Display($"COBERTURA .... {LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA}");

                /*" -3853- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -3854- ELSE */
            }
            else
            {


                /*" -3855- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3856- IF LOTISG01-COD-COBERTURA = 2 OR 7 OR 8 */

                    if (LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA.In("2", "7", "8"))
                    {

                        /*" -3857- DISPLAY 'ERRO SELECT SI_PARAM_ADIANT ' */
                        _.Display($"ERRO SELECT SI_PARAM_ADIANT ");

                        /*" -3858- DISPLAY 'LOTERICO ... ' LOTERI01-COD-LOT-CEF */
                        _.Display($"LOTERICO ... {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                        /*" -3859- DISPLAY 'COBERTURA ... ' LOTISG01-COD-COBERTURA */
                        _.Display($"COBERTURA ... {LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA}");

                        /*" -3860- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO(); //GOTO
                        return;

                        /*" -3861- ELSE */
                    }
                    else
                    {


                        /*" -3867- MOVE ZEROS TO SIPARADI-COD-PRODUTO SIPARADI-COD-COBERTURA SIPARADI-PERC-ADIANTAMENTO. */
                        _.Move(0, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_PRODUTO, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO);
                    }

                }

            }


            /*" -3868- IF APOLICES-RAMO-EMISSOR = 71 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 71)
            {

                /*" -3870- COMPUTE W-VALOR-ADIANTAMENTO ROUNDED = (W-VALOR-PARA-AVISO / 100) * SIPARADI-PERC-ADIANTAMENTO */
                AREA_DE_WORK.W_VALOR_ADIANTAMENTO.Value = (AREA_DE_WORK.W_VALOR_PARA_AVISO / 100f) * SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO;

                /*" -3871- ELSE */
            }
            else
            {


                /*" -3872- IF APOLICES-RAMO-EMISSOR = 18 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 18)
                {

                    /*" -3873- IF W-CHAVE-ADIANTA-SALDO-IS EQUAL 'NAO' */

                    if (AREA_DE_WORK.W_CHAVE_ADIANTA_SALDO_IS == "NAO")
                    {

                        /*" -3876- COMPUTE W-VALOR-ADIANTAMENTO ROUNDED = (W-VALOR-ADIANTAMENTO / 100) * SIPARADI-PERC-ADIANTAMENTO */
                        AREA_DE_WORK.W_VALOR_ADIANTAMENTO.Value = (AREA_DE_WORK.W_VALOR_ADIANTAMENTO / 100f) * SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO;

                        /*" -3877- ELSE */
                    }
                    else
                    {


                        /*" -3881- MOVE W-VALOR-ADIANTAMENTO TO W-VALOR-ADIANTAMENTO. */
                        _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, AREA_DE_WORK.W_VALOR_ADIANTAMENTO);
                    }

                }

            }


            /*" -3882- ADD 1 TO FONTES-NUM-PROTOCOLO-SINI */
            FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI.Value = FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI + 1;

            /*" -3885- MOVE FONTES-NUM-PROTOCOLO-SINI TO SINISCON-NUM-PROTOCOLO-SINI */
            _.Move(FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI);

            /*" -3887- PERFORM R1010-INCLUI-SINISCON THRU R1010-EXIT */

            R1010_INCLUI_SINISCON(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/


            /*" -3889- PERFORM R1020-INCLUI-SINISACO THRU R1020-EXIT */

            R1020_INCLUI_SINISACO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/


            /*" -3891- PERFORM R1030-INCLUI-SINISMES THRU R1030-EXIT */

            R1030_INCLUI_SINISMES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_EXIT*/


            /*" -3893- PERFORM R1040-INCLUI-SILOTER1 THRU R1040-EXIT */

            R1040_INCLUI_SILOTER1(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_EXIT*/


            /*" -3895- PERFORM R1050-INCLUI-SINIITEM THRU R1050-EXIT */

            R1050_INCLUI_SINIITEM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_EXIT*/


            /*" -3897- PERFORM R1060-MONTA-SINISHIS-BASICO THRU R1060-EXIT. */

            R1060_MONTA_SINISHIS_BASICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_EXIT*/


            /*" -3898- MOVE 101 TO SINISHIS-COD-OPERACAO */
            _.Move(101, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -3899- MOVE 1 TO SINISHIS-OCORR-HISTORICO */
            _.Move(1, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

            /*" -3900- MOVE W-VALOR-PARA-AVISO TO SINISHIS-VAL-OPERACAO */
            _.Move(AREA_DE_WORK.W_VALOR_PARA_AVISO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -3901- PERFORM R1070-INCLUI-SINISHIS THRU R1070-EXIT */

            R1070_INCLUI_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_EXIT*/


            /*" -3908- ADD 1 TO SINISHIS-OCORR-HISTORICO. */
            SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO + 1;

            /*" -3921- MOVE '1' TO SINISHIS-TIPO-FAVORECIDO. */
            _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);

            /*" -3922- IF APOLICES-RAMO-EMISSOR = 71 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 71)
            {

                /*" -3923- IF LOTCOB01-COD-COBERTURA EQUAL 4 */

                if (LOTCOB01.DCLLOTCOBER01.LOTCOB01_COD_COBERTURA == 4)
                {

                    /*" -3924- MOVE '2' TO SINISHIS-SIT-CONTABIL */
                    _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

                    /*" -3926- ELSE */
                }
                else
                {


                    /*" -3927- MOVE '2' TO SINISHIS-SIT-CONTABIL */
                    _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

                    /*" -3928- ELSE */
                }

            }
            else
            {


                /*" -3929- IF APOLICES-RAMO-EMISSOR = 18 OR 51 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.In("18", "51"))
                {

                    /*" -3930- IF LOTCOB01-COD-COBERTURA EQUAL 2 OR 7 OR 8 */

                    if (LOTCOB01.DCLLOTCOBER01.LOTCOB01_COD_COBERTURA.In("2", "7", "8"))
                    {

                        /*" -3931- MOVE '2' TO SINISHIS-SIT-CONTABIL */
                        _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

                        /*" -3932- ELSE */
                    }
                    else
                    {


                        /*" -3935- MOVE '2' TO SINISHIS-SIT-CONTABIL. */
                        _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                    }

                }

            }


            /*" -3936- MOVE ZEROS TO W-LIM-ADIANTAMENTO */
            _.Move(0, AREA_DE_WORK.W_LIM_ADIANTAMENTO);

            /*" -3937- IF SINISCAU-GRUPO-CAUSAS EQUAL 'VALORES' */

            if (SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "VALORES")
            {

                /*" -3938- IF APOLICES-RAMO-EMISSOR = 71 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 71)
                {

                    /*" -3939- MOVE 20000 TO W-LIM-ADIANTAMENTO */
                    _.Move(20000, AREA_DE_WORK.W_LIM_ADIANTAMENTO);

                    /*" -3940- ELSE */
                }
                else
                {


                    /*" -3941- IF APOLICES-RAMO-EMISSOR = 18 OR 51 */

                    if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.In("18", "51"))
                    {

                        /*" -3943- MOVE 30000 TO W-LIM-ADIANTAMENTO. */
                        _.Move(30000, AREA_DE_WORK.W_LIM_ADIANTAMENTO);
                    }

                }

            }


            /*" -3945- IF (SINISCAU-GRUPO-CAUSAS EQUAL 'VALORES' ) AND (W-VALOR-ADIANTAMENTO NOT EQUAL 0) */

            if ((SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "VALORES") && (AREA_DE_WORK.W_VALOR_ADIANTAMENTO != 0))
            {

                /*" -3946- IF APOLICES-RAMO-EMISSOR = 18 OR 51 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.In("18", "51"))
                {

                    /*" -3947- IF AV-INDICADOR-ADIANTAMENTO = 'N' */

                    if (REGISTRO_AVISO.AV_INDICADOR_ADIANTAMENTO == "N")
                    {

                        /*" -3948- GO TO R1000-NAO-GERA-ADIANTAMENTO */

                        R1000_NAO_GERA_ADIANTAMENTO(); //GOTO
                        return;

                        /*" -3950- END-IF */
                    }


                    /*" -3951- IF W-CHAVE-NAO-ADIANTA EQUAL 'SIM' */

                    if (AREA_DE_WORK.W_CHAVE_NAO_ADIANTA == "SIM")
                    {

                        /*" -3952- GO TO R1000-NAO-GERA-ADIANTAMENTO */

                        R1000_NAO_GERA_ADIANTAMENTO(); //GOTO
                        return;

                        /*" -3955- END-IF */
                    }


                    /*" -3956- MOVE 2 TO SINISHIS-OCORR-HISTORICO */
                    _.Move(2, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

                    /*" -3957- IF W-VALOR-ADIANTAMENTO < W-LIM-ADIANTAMENTO */

                    if (AREA_DE_WORK.W_VALOR_ADIANTAMENTO < AREA_DE_WORK.W_LIM_ADIANTAMENTO)
                    {

                        /*" -3958- MOVE '1' TO SINISHIS-SIT-REGISTRO */
                        _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                        /*" -3959- ELSE */
                    }
                    else
                    {


                        /*" -3960- MOVE '0' TO SINISHIS-SIT-REGISTRO */
                        _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                        /*" -3961- END-IF */
                    }


                    /*" -3962- MOVE 1170 TO SINISHIS-COD-OPERACAO */
                    _.Move(1170, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                    /*" -3963- MOVE W-VALOR-ADIANTAMENTO TO SINISHIS-VAL-OPERACAO */
                    _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                    /*" -3964- PERFORM R1070-INCLUI-SINISHIS THRU R1070-EXIT */

                    R1070_INCLUI_SINISHIS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_EXIT*/


                    /*" -3966- DISPLAY 'VALOR ADIANTAMENTO = ' W-VALOR-ADIANTAMENTO */
                    _.Display($"VALOR ADIANTAMENTO = {AREA_DE_WORK.W_VALOR_ADIANTAMENTO}");

                    /*" -3967- IF W-VALOR-ADIANTAMENTO < W-LIM-ADIANTAMENTO */

                    if (AREA_DE_WORK.W_VALOR_ADIANTAMENTO < AREA_DE_WORK.W_LIM_ADIANTAMENTO)
                    {

                        /*" -3968- MOVE '9' TO SINISHIS-SIT-REGISTRO */
                        _.Move("9", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                        /*" -3969- MOVE 1070 TO SINISHIS-COD-OPERACAO */
                        _.Move(1070, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                        /*" -3970- MOVE W-VALOR-ADIANTAMENTO TO SINISHIS-VAL-OPERACAO */
                        _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                        /*" -3972- PERFORM R1070-INCLUI-SINISHIS THRU R1070-EXIT. */

                        R1070_INCLUI_SINISHIS(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_EXIT*/

                    }

                }

            }


            /*" -3974- IF (SINISCAU-GRUPO-CAUSAS EQUAL 'VALORES' ) AND (W-VALOR-ADIANTAMENTO NOT EQUAL 0) */

            if ((SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "VALORES") && (AREA_DE_WORK.W_VALOR_ADIANTAMENTO != 0))
            {

                /*" -3975- IF APOLICES-RAMO-EMISSOR = 71 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 71)
                {

                    /*" -3976- MOVE 2 TO SINISHIS-OCORR-HISTORICO */
                    _.Move(2, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

                    /*" -3977- MOVE '1' TO SINISHIS-SIT-REGISTRO */
                    _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                    /*" -3978- MOVE 1170 TO SINISHIS-COD-OPERACAO */
                    _.Move(1170, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                    /*" -3979- MOVE W-VALOR-ADIANTAMENTO TO SINISHIS-VAL-OPERACAO */
                    _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                    /*" -3980- PERFORM R1070-INCLUI-SINISHIS THRU R1070-EXIT */

                    R1070_INCLUI_SINISHIS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_EXIT*/


                    /*" -3981- IF W-VALOR-ADIANTAMENTO < W-LIM-ADIANTAMENTO */

                    if (AREA_DE_WORK.W_VALOR_ADIANTAMENTO < AREA_DE_WORK.W_LIM_ADIANTAMENTO)
                    {

                        /*" -3982- MOVE '9' TO SINISHIS-SIT-REGISTRO */
                        _.Move("9", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                        /*" -3983- MOVE 1070 TO SINISHIS-COD-OPERACAO */
                        _.Move(1070, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                        /*" -3984- MOVE W-VALOR-ADIANTAMENTO TO SINISHIS-VAL-OPERACAO */
                        _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                        /*" -3986- PERFORM R1070-INCLUI-SINISHIS THRU R1070-EXIT. */

                        R1070_INCLUI_SINISHIS(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_EXIT*/

                    }

                }

            }


            /*" -3988- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3989- IF SINISMES-OCORR-HISTORICO NOT = SINISHIS-OCORR-HISTORICO */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO != SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO)
            {

                /*" -3992- PERFORM R1000_GRAVA_SINISTRO_DB_UPDATE_1 */

                R1000_GRAVA_SINISTRO_DB_UPDATE_1();

                /*" -3995- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -3996- DISPLAY 'ERRO UPDATE SINISTRO_MESTRE..............' */
                    _.Display($"ERRO UPDATE SINISTRO_MESTRE..............");

                    /*" -3997- DISPLAY 'NUM-APOL-SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUM-APOL-SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -3998- DISPLAY 'OCORR-HISTORICO   ' SINISHIS-OCORR-HISTORICO */
                    _.Display($"OCORR-HISTORICO   {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                    /*" -3998- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1000-GRAVA-SINISTRO-DB-SELECT-1 */
        public void R1000_GRAVA_SINISTRO_DB_SELECT_1()
        {
            /*" -3846- EXEC SQL SELECT COD_PRODUTO, COD_COBERTURA, PERC_ADIANTAMENTO INTO :SIPARADI-COD-PRODUTO, :SIPARADI-COD-COBERTURA, :SIPARADI-PERC-ADIANTAMENTO FROM SEGUROS.SI_PARAM_ADIANT WHERE COD_PRODUTO = :APOLICES-COD-PRODUTO AND COD_COBERTURA = :LOTISG01-COD-COBERTURA AND DATA_INIVIGENCIA <= CURRENT DATE AND DATA_TERVIGENCIA >= CURRENT DATE WITH UR END-EXEC. */

            var r1000_GRAVA_SINISTRO_DB_SELECT_1_Query1 = new R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1()
            {
                LOTISG01_COD_COBERTURA = LOTISG01.DCLLOTIMPSEG01.LOTISG01_COD_COBERTURA.ToString(),
                APOLICES_COD_PRODUTO = APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1.Execute(r1000_GRAVA_SINISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIPARADI_COD_PRODUTO, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_PRODUTO);
                _.Move(executed_1.SIPARADI_COD_COBERTURA, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA);
                _.Move(executed_1.SIPARADI_PERC_ADIANTAMENTO, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO);
            }


        }

        [StopWatch]
        /*" R1000-GRAVA-SINISTRO-DB-UPDATE-1 */
        public void R1000_GRAVA_SINISTRO_DB_UPDATE_1()
        {
            /*" -3992- EXEC SQL UPDATE SEGUROS.SINISTRO_MESTRE SET OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC */

            var r1000_GRAVA_SINISTRO_DB_UPDATE_1_Update1 = new R1000_GRAVA_SINISTRO_DB_UPDATE_1_Update1()
            {
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            R1000_GRAVA_SINISTRO_DB_UPDATE_1_Update1.Execute(r1000_GRAVA_SINISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R130-IMPRIME-GERA-AVISO-OK-DB-SELECT-3 */
        public void R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3()
        {
            /*" -3764- EXEC SQL SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO),0) INTO :HOST-COUNT FROM SEGUROS.SINI_LOTERICO01 SL, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE SL.COD_LOT_CEF = :SINILT01-COD-LOT-CEF AND SL.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND M.SIT_REGISTRO <> '2' AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.SIT_REGISTRO <> '2' AND H.COD_OPERACAO BETWEEN 1181 AND 1184 AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO = 'IN' AND O.FUNCAO_OPERACAO = 'IND' AND O.IDE_SISTEMA = 'SI' AND SL.NUM_APOLICE = :LOTERI01-NUM-APOLICE END-EXEC. */

            var r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1 = new R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1()
            {
                SINILT01_COD_LOT_FENAL = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL.ToString(),
                SINILT01_COD_LOT_CEF = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1.Execute(r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1000-NAO-GERA-ADIANTAMENTO */
        private void R1000_NAO_GERA_ADIANTAMENTO(bool isPerform = false)
        {
            /*" -4004- PERFORM R1080-INCLUI-SIMOLOT1 THRU R1080-EXIT. */

            R1080_INCLUI_SIMOLOT1(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_EXIT*/


            /*" -4004- PERFORM R1090-INCLUI-DOC01 THRU R1090-EXIT. */

            R1090_INCLUI_DOC01(true);

            R1090_LE_NOVAMENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1090_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1010-INCLUI-SINISCON */
        private void R1010_INCLUI_SINISCON(bool isPerform = false)
        {
            /*" -4014- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4015- MOVE 10 TO SINISCON-COD-FONTE */
            _.Move(10, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_FONTE);

            /*" -4016- MOVE FONTES-NUM-PROTOCOLO-SINI TO SINISCON-NUM-PROTOCOLO-SINI */
            _.Move(FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI);

            /*" -4017- MOVE '0' TO SINISCON-DAC-PROTOCOLO-SINI */
            _.Move("0", SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI);

            /*" -4018- MOVE LOTERI01-NUM-APOLICE TO SINISCON-NUM-APOLICE */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_APOLICE);

            /*" -4019- MOVE 0 TO SINISCON-COD-SUBGRUPO */
            _.Move(0, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_SUBGRUPO);

            /*" -4020- MOVE 1 TO SINISCON-OCORR-HISTORICO */
            _.Move(1, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_OCORR_HISTORICO);

            /*" -4021- MOVE 'N' TO SINISCON-PEND-VISTORIA */
            _.Move("N", SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_VISTORIA);

            /*" -4022- MOVE 'N' TO SINISCON-PEND-RESSEGURO */
            _.Move("N", SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_RESSEGURO);

            /*" -4023- MOVE '0' TO SINISCON-SIT-REGISTRO */
            _.Move("0", SINISCON.DCLSINISTRO_CONTROLE.SINISCON_SIT_REGISTRO);

            /*" -4024- MOVE 'N' TO SINISCON-PEND-VIST-COMPL */
            _.Move("N", SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_VIST_COMPL);

            /*" -4025- MOVE 0 TO SINISCON-COD-EMPRESA */
            _.Move(0, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_EMPRESA);

            /*" -4029- MOVE 0 TO SINISCON-NUM-CERTIFICADO. */
            _.Move(0, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_CERTIFICADO);

            /*" -4060- PERFORM R1010_INCLUI_SINISCON_DB_INSERT_1 */

            R1010_INCLUI_SINISCON_DB_INSERT_1();

            /*" -4063- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4066- COMPUTE FONTES-NUM-PROTOCOLO-SINI = FONTES-NUM-PROTOCOLO-SINI + 1 */
                FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI.Value = FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI + 1;

                /*" -4068- GO TO R1010-INCLUI-SINISCON. */
                new Task(() => R1010_INCLUI_SINISCON()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4069- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4070- DISPLAY 'ERRO NA INCLUSAO DA TABELA .SINISTRO_CONTROLE' */
                _.Display($"ERRO NA INCLUSAO DA TABELA .SINISTRO_CONTROLE");

                /*" -4071- DISPLAY 'COD-FONTE          ' SINISCON-COD-FONTE */
                _.Display($"COD-FONTE          {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_FONTE}");

                /*" -4072- DISPLAY 'NUM-PROTOCOLO-SINI ' SINISCON-NUM-PROTOCOLO-SINI */
                _.Display($"NUM-PROTOCOLO-SINI {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI}");

                /*" -4073- DISPLAY 'DAC-PROTOCOLO-SINI ' SINISCON-DAC-PROTOCOLO-SINI */
                _.Display($"DAC-PROTOCOLO-SINI {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI}");

                /*" -4074- DISPLAY 'NUM-APOLICE        ' SINISCON-NUM-APOLICE */
                _.Display($"NUM-APOLICE        {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_APOLICE}");

                /*" -4075- DISPLAY 'COD-SUBGRUPO       ' SINISCON-COD-SUBGRUPO */
                _.Display($"COD-SUBGRUPO       {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_SUBGRUPO}");

                /*" -4076- DISPLAY 'OCORR-HISTORICO    ' SINISCON-OCORR-HISTORICO */
                _.Display($"OCORR-HISTORICO    {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_OCORR_HISTORICO}");

                /*" -4077- DISPLAY 'PEND-VISTORIA      ' SINISCON-PEND-VISTORIA */
                _.Display($"PEND-VISTORIA      {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_VISTORIA}");

                /*" -4078- DISPLAY 'PEND-RESSEGURO     ' SINISCON-PEND-RESSEGURO */
                _.Display($"PEND-RESSEGURO     {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_RESSEGURO}");

                /*" -4079- DISPLAY 'SIT-REGISTRO       ' SINISCON-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO       {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_SIT_REGISTRO}");

                /*" -4080- DISPLAY 'PEND-VIST-COMPL    ' SINISCON-PEND-VIST-COMPL */
                _.Display($"PEND-VIST-COMPL    {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_VIST_COMPL}");

                /*" -4081- DISPLAY 'COD-EMPRESA        ' SINISCON-COD-EMPRESA */
                _.Display($"COD-EMPRESA        {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_EMPRESA}");

                /*" -4082- DISPLAY 'NUM-CERTIFICADO    ' SINISCON-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO    {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_CERTIFICADO}");

                /*" -4082- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1010-INCLUI-SINISCON-DB-INSERT-1 */
        public void R1010_INCLUI_SINISCON_DB_INSERT_1()
        {
            /*" -4060- EXEC SQL INSERT INTO SEGUROS.SINISTRO_CONTROLE ( COD_FONTE ,NUM_PROTOCOLO_SINI ,DAC_PROTOCOLO_SINI ,NUM_APOLICE ,COD_SUBGRUPO ,OCORR_HISTORICO ,PEND_VISTORIA ,PEND_RESSEGURO ,SIT_REGISTRO ,PEND_VIST_COMPL ,COD_EMPRESA ,TIMESTAMP ,NUM_CERTIFICADO ) VALUES (:SINISCON-COD-FONTE ,:SINISCON-NUM-PROTOCOLO-SINI ,:SINISCON-DAC-PROTOCOLO-SINI ,:SINISCON-NUM-APOLICE ,:SINISCON-COD-SUBGRUPO ,:SINISCON-OCORR-HISTORICO ,:SINISCON-PEND-VISTORIA ,:SINISCON-PEND-RESSEGURO ,:SINISCON-SIT-REGISTRO ,:SINISCON-PEND-VIST-COMPL ,:SINISCON-COD-EMPRESA , CURRENT TIMESTAMP ,:SINISCON-NUM-CERTIFICADO ) END-EXEC. */

            var r1010_INCLUI_SINISCON_DB_INSERT_1_Insert1 = new R1010_INCLUI_SINISCON_DB_INSERT_1_Insert1()
            {
                SINISCON_COD_FONTE = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_FONTE.ToString(),
                SINISCON_NUM_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.ToString(),
                SINISCON_DAC_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI.ToString(),
                SINISCON_NUM_APOLICE = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_APOLICE.ToString(),
                SINISCON_COD_SUBGRUPO = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_SUBGRUPO.ToString(),
                SINISCON_OCORR_HISTORICO = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_OCORR_HISTORICO.ToString(),
                SINISCON_PEND_VISTORIA = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_VISTORIA.ToString(),
                SINISCON_PEND_RESSEGURO = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_RESSEGURO.ToString(),
                SINISCON_SIT_REGISTRO = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_SIT_REGISTRO.ToString(),
                SINISCON_PEND_VIST_COMPL = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_VIST_COMPL.ToString(),
                SINISCON_COD_EMPRESA = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_EMPRESA.ToString(),
                SINISCON_NUM_CERTIFICADO = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_CERTIFICADO.ToString(),
            };

            R1010_INCLUI_SINISCON_DB_INSERT_1_Insert1.Execute(r1010_INCLUI_SINISCON_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

        [StopWatch]
        /*" R1020-INCLUI-SINISACO */
        private void R1020_INCLUI_SINISACO(bool isPerform = false)
        {
            /*" -4092- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4093- MOVE 10 TO SINISACO-COD-FONTE */
            _.Move(10, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_FONTE);

            /*" -4094- MOVE FONTES-NUM-PROTOCOLO-SINI TO SINISACO-NUM-PROTOCOLO-SINI */
            _.Move(FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_NUM_PROTOCOLO_SINI);

            /*" -4095- MOVE '0' TO SINISACO-DAC-PROTOCOLO-SINI */
            _.Move("0", SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DAC_PROTOCOLO_SINI);

            /*" -4096- MOVE 9020 TO SINISACO-COD-OPERACAO */
            _.Move(9020, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_OPERACAO);

            /*" -4097- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISACO-DATA-OPERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DATA_OPERACAO);

            /*" -4098- MOVE '12.00.00' TO SINISACO-HORA-OPERACAO */
            _.Move("12.00.00", SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_HORA_OPERACAO);

            /*" -4099- MOVE 1 TO SINISACO-OCORR-HISTORICO */
            _.Move(1, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_OCORR_HISTORICO);

            /*" -4100- MOVE 'SI0005B' TO SINISACO-COD-USUARIO */
            _.Move("SI0005B", SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_USUARIO);

            /*" -4104- MOVE 0 TO SINISACO-COD-EMPRESA */
            _.Move(0, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_EMPRESA);

            /*" -4129- PERFORM R1020_INCLUI_SINISACO_DB_INSERT_1 */

            R1020_INCLUI_SINISACO_DB_INSERT_1();

            /*" -4132- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4133- DISPLAY 'ERRO NA INCLUSAO DA TABELA .SINISTRO_ACOMPANHA' */
                _.Display($"ERRO NA INCLUSAO DA TABELA .SINISTRO_ACOMPANHA");

                /*" -4134- DISPLAY 'COD-FONTE          ' SINISACO-COD-FONTE */
                _.Display($"COD-FONTE          {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_FONTE}");

                /*" -4135- DISPLAY 'NUM-PROTOCOLO-SINI ' SINISACO-NUM-PROTOCOLO-SINI */
                _.Display($"NUM-PROTOCOLO-SINI {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_NUM_PROTOCOLO_SINI}");

                /*" -4136- DISPLAY 'DAC-PROTOCOLO-SINI ' SINISACO-DAC-PROTOCOLO-SINI */
                _.Display($"DAC-PROTOCOLO-SINI {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DAC_PROTOCOLO_SINI}");

                /*" -4137- DISPLAY 'COD-OPERACAO       ' SINISACO-COD-OPERACAO */
                _.Display($"COD-OPERACAO       {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_OPERACAO}");

                /*" -4138- DISPLAY 'DATA-OPERACAO      ' SINISACO-DATA-OPERACAO */
                _.Display($"DATA-OPERACAO      {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DATA_OPERACAO}");

                /*" -4139- DISPLAY 'HORA-OPERACAO      ' SINISACO-HORA-OPERACAO */
                _.Display($"HORA-OPERACAO      {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_HORA_OPERACAO}");

                /*" -4140- DISPLAY 'OCORR-HISTORICO    ' SINISACO-OCORR-HISTORICO */
                _.Display($"OCORR-HISTORICO    {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_OCORR_HISTORICO}");

                /*" -4141- DISPLAY 'COD-USUARIO        ' SINISACO-COD-USUARIO */
                _.Display($"COD-USUARIO        {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_USUARIO}");

                /*" -4142- DISPLAY 'COD-EMPRESA        ' SINISACO-COD-EMPRESA */
                _.Display($"COD-EMPRESA        {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_EMPRESA}");

                /*" -4142- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1020-INCLUI-SINISACO-DB-INSERT-1 */
        public void R1020_INCLUI_SINISACO_DB_INSERT_1()
        {
            /*" -4129- EXEC SQL INSERT INTO SEGUROS.SINISTRO_ACOMPANHA ( COD_FONTE ,NUM_PROTOCOLO_SINI ,DAC_PROTOCOLO_SINI ,COD_OPERACAO ,DATA_OPERACAO ,HORA_OPERACAO ,OCORR_HISTORICO ,COD_USUARIO ,COD_EMPRESA ,TIMESTAMP ) VALUES (:SINISACO-COD-FONTE ,:SINISACO-NUM-PROTOCOLO-SINI ,:SINISACO-DAC-PROTOCOLO-SINI ,:SINISACO-COD-OPERACAO ,:SINISACO-DATA-OPERACAO ,:SINISACO-HORA-OPERACAO ,:SINISACO-OCORR-HISTORICO ,:SINISACO-COD-USUARIO ,:SINISACO-COD-EMPRESA , CURRENT TIMESTAMP ) END-EXEC. */

            var r1020_INCLUI_SINISACO_DB_INSERT_1_Insert1 = new R1020_INCLUI_SINISACO_DB_INSERT_1_Insert1()
            {
                SINISACO_COD_FONTE = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_FONTE.ToString(),
                SINISACO_NUM_PROTOCOLO_SINI = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_NUM_PROTOCOLO_SINI.ToString(),
                SINISACO_DAC_PROTOCOLO_SINI = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DAC_PROTOCOLO_SINI.ToString(),
                SINISACO_COD_OPERACAO = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_OPERACAO.ToString(),
                SINISACO_DATA_OPERACAO = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DATA_OPERACAO.ToString(),
                SINISACO_HORA_OPERACAO = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_HORA_OPERACAO.ToString(),
                SINISACO_OCORR_HISTORICO = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_OCORR_HISTORICO.ToString(),
                SINISACO_COD_USUARIO = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_USUARIO.ToString(),
                SINISACO_COD_EMPRESA = SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_EMPRESA.ToString(),
            };

            R1020_INCLUI_SINISACO_DB_INSERT_1_Insert1.Execute(r1020_INCLUI_SINISACO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

        [StopWatch]
        /*" R1030-INCLUI-SINISMES */
        private void R1030_INCLUI_SINISMES(bool isPerform = false)
        {
            /*" -4156- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4157- IF AV-COD-NATUREZA-N EQUAL 6 OR 16 */

            if (REGISTRO_AVISO.AV_COD_NATUREZA_N.In("6", "16"))
            {

                /*" -4158- MOVE 51 TO APOLICES-RAMO-EMISSOR */
                _.Move(51, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);

                /*" -4159- MOVE '10' TO AV-COD-CAUSA */
                _.Move("10", REGISTRO_AVISO.AV_COD_CAUSA);

                /*" -4161- END-IF */
            }


            /*" -4163- PERFORM R035-SELECT-NUMERO-AES THRU R035-EXIT. */

            R035_SELECT_NUMERO_AES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R035_EXIT*/


            /*" -4164- ADD 1 TO NUMERAES-SEQ-SINISTRO. */
            NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO.Value = NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO + 1;

            /*" -4165- MOVE 010 TO W-ORGAO-SINISTRO. */
            _.Move(010, AREA_DE_WORK.W_NUMERO_SINISTRO.W_ORGAO_SINISTRO);

            /*" -4166- MOVE APOLICES-RAMO-EMISSOR TO W-RAMO-SINISTRO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, AREA_DE_WORK.W_NUMERO_SINISTRO.W_RAMO_SINISTRO);

            /*" -4167- MOVE NUMERAES-SEQ-SINISTRO TO W-NUM-SINISTRO. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO, AREA_DE_WORK.W_NUMERO_SINISTRO.W_NUM_SINISTRO);

            /*" -4168- MOVE W-NUMERO-SINISTRO TO W-NUMERO-SINISTRO-NUM. */
            _.Move(AREA_DE_WORK.W_NUMERO_SINISTRO, AREA_DE_WORK.W_NUMERO_SINISTRO_NUM);

            /*" -4169- MOVE W-NUMERO-SINISTRO-NUM TO SINISMES-NUM-APOL-SINISTRO. */
            _.Move(AREA_DE_WORK.W_NUMERO_SINISTRO_NUM, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);

            /*" -4170- MOVE 0 TO SINISMES-COD-EMPRESA. */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_EMPRESA);

            /*" -4171- MOVE '1' TO SINISMES-TIPO-REGISTRO. */
            _.Move("1", SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO);

            /*" -4172- MOVE 10 TO SINISMES-COD-FONTE */
            _.Move(10, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);

            /*" -4173- MOVE FONTES-NUM-PROTOCOLO-SINI TO SINISMES-NUM-PROTOCOLO-SINI */
            _.Move(FONTES.DCLFONTES.FONTES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);

            /*" -4174- MOVE '0' TO SINISMES-DAC-PROTOCOLO-SINI */
            _.Move("0", SINISMES.DCLSINISTRO_MESTRE.SINISMES_DAC_PROTOCOLO_SINI);

            /*" -4175- MOVE LOTERI01-NUM-APOLICE TO SINISMES-NUM-APOLICE */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);

            /*" -4176- MOVE 0 TO SINISMES-NUM-ENDOSSO */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_ENDOSSO);

            /*" -4177- MOVE 0 TO SINISMES-COD-SUBGRUPO */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);

            /*" -4178- MOVE 0 TO SINISMES-NUM-CERTIFICADO */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);

            /*" -4179- MOVE ' ' TO SINISMES-DAC-CERTIFICADO */
            _.Move(" ", SINISMES.DCLSINISTRO_MESTRE.SINISMES_DAC_CERTIFICADO);

            /*" -4180- MOVE ' ' TO SINISMES-TIPO-SEGURADO */
            _.Move(" ", SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO);

            /*" -4181- MOVE 0 TO SINISMES-NUM-EMBARQUE */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_EMBARQUE);

            /*" -4182- MOVE 0 TO SINISMES-REF-EMBARQUE */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_REF_EMBARQUE);

            /*" -4183- MOVE 1 TO SINISMES-OCORR-HISTORICO */
            _.Move(1, SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO);

            /*" -4184- MOVE 0 TO SINISMES-COD-LIDER */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_LIDER);

            /*" -4185- MOVE ' ' TO SINISMES-NUM-SINI-LIDER */
            _.Move(" ", SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_SINI_LIDER);

            /*" -4186- MOVE HOST-DATA-AVISO TO SINISMES-DATA-COMUNICADO */
            _.Move(HOST_DATA_AVISO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);

            /*" -4187- MOVE HOST-DATA-OCORRENCIA TO SINISMES-DATA-OCORRENCIA */
            _.Move(HOST_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);

            /*" -4188- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISMES-DATA-TECNICA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA);

            /*" -4189- MOVE AV-COD-CAUSA TO SINISMES-COD-CAUSA */
            _.Move(REGISTRO_AVISO.AV_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);

            /*" -4190- MOVE 0 TO SINISMES-NUM-IRB */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);

            /*" -4191- MOVE ' ' TO SINISMES-NUM-AVISO-IRB */
            _.Move(" ", SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_AVISO_IRB);

            /*" -4192- MOVE 1 TO SINISMES-COD-MOEDA-SINI */
            _.Move(1, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_MOEDA_SINI);

            /*" -4193- MOVE W-VALOR-PARA-AVISO TO SINISMES-SALDO-PAGAR-IX. */
            _.Move(AREA_DE_WORK.W_VALOR_PARA_AVISO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_PAGAR_IX);

            /*" -4194- MOVE 0 TO SINISMES-TOT-PAGAMENTO-IX */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_PAGAMENTO_IX);

            /*" -4195- MOVE 0 TO SINISMES-SALDO-RECUPERAR-IX */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_RECUPERAR_IX);

            /*" -4196- MOVE 0 TO SINISMES-TOT-RECUPERADO-IX */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_RECUPERADO_IX);

            /*" -4197- MOVE 0 TO SINISMES-SALDO-RESSARCIR-IX */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_RESSARCIR_IX);

            /*" -4198- MOVE 0 TO SINISMES-TOT-RESSARCIDO-IX */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_RESSARCIDO_IX);

            /*" -4199- MOVE 0 TO SINISMES-TOT-DESPESAS-IX. */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_DESPESAS_IX);

            /*" -4200- MOVE 0 TO SINISMES-TOT-HONORARIOS-IX. */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_HONORARIOS_IX);

            /*" -4201- MOVE 0 TO SINISMES-ADIA-RECUPERAR-IX */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_ADIA_RECUPERAR_IX);

            /*" -4202- MOVE 0 TO SINISMES-ADIA-RECUPERADO-IX */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_ADIA_RECUPERADO_IX);

            /*" -4203- MOVE W-VALOR-PARA-AVISO TO SINISMES-IMP-SEGURADA-IX. */
            _.Move(AREA_DE_WORK.W_VALOR_PARA_AVISO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_IMP_SEGURADA_IX);

            /*" -4204- MOVE 0 TO SINISMES-PCT-PART-COSSEGURO */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_COSSEGURO);

            /*" -4205- MOVE 0 TO SINISMES-PCT-PART-RESSEGURO */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_RESSEGURO);

            /*" -4206- MOVE 0 TO SINISMES-APROVACAO-ALCADA */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_APROVACAO_ALCADA);

            /*" -4207- MOVE ' ' TO SINISMES-IND-SALVADO */
            _.Move(" ", SINISMES.DCLSINISTRO_MESTRE.SINISMES_IND_SALVADO);

            /*" -4208- MOVE ' ' TO SINISMES-INTEGRAL-ESPECIAL */
            _.Move(" ", SINISMES.DCLSINISTRO_MESTRE.SINISMES_INTEGRAL_ESPECIAL);

            /*" -4209- MOVE 0 TO SINISMES-NUM-MOV-SINI-ATU */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_MOV_SINI_ATU);

            /*" -4210- MOVE 0 TO SINISMES-NUM-MOV-SINI-ANT */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_MOV_SINI_ANT);

            /*" -4211- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISMES-DATA-ULT-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_ULT_MOVIMENTO);

            /*" -4212- MOVE '0' TO SINISMES-SIT-REGISTRO */
            _.Move("0", SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);

            /*" -4213- MOVE 0 TO SINISMES-BANCO-ORDEM-PAG */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_BANCO_ORDEM_PAG);

            /*" -4214- MOVE 0 TO SINISMES-AGENCIA-ORDEM-PAG */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_AGENCIA_ORDEM_PAG);

            /*" -4215- MOVE '1' TO SINISMES-TIPO-PAGAMENTO */
            _.Move("1", SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_PAGAMENTO);

            /*" -4216- MOVE APOLICES-RAMO-EMISSOR TO SINISMES-RAMO */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);

            /*" -4217- MOVE 0 TO SINISMES-NUMERO-ORDEM */
            _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUMERO_ORDEM);

            /*" -4224- MOVE APOLICES-COD-PRODUTO TO SINISMES-COD-PRODUTO */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);

            /*" -4328- PERFORM R1030_INCLUI_SINISMES_DB_INSERT_1 */

            R1030_INCLUI_SINISMES_DB_INSERT_1();

            /*" -4331- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4332- DISPLAY 'ERRO NA INCLUSAO DA TABELA .SINISTRO_MESTRE' */
                _.Display($"ERRO NA INCLUSAO DA TABELA .SINISTRO_MESTRE");

                /*" -4333- DISPLAY 'COD-EMPRESA        ' SINISMES-COD-EMPRESA */
                _.Display($"COD-EMPRESA        {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_EMPRESA}");

                /*" -4334- DISPLAY 'TIPO-REGISTRO      ' SINISMES-TIPO-REGISTRO */
                _.Display($"TIPO-REGISTRO      {SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO}");

                /*" -4335- DISPLAY 'COD-FONTE          ' SINISMES-COD-FONTE */
                _.Display($"COD-FONTE          {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -4336- DISPLAY 'NUM-PROTOCOLO-SINI ' SINISMES-NUM-PROTOCOLO-SINI */
                _.Display($"NUM-PROTOCOLO-SINI {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI}");

                /*" -4337- DISPLAY 'DAC-PROTOCOLO-SINI ' SINISMES-DAC-PROTOCOLO-SINI */
                _.Display($"DAC-PROTOCOLO-SINI {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DAC_PROTOCOLO_SINI}");

                /*" -4338- DISPLAY 'NUM-APOL-SINISTRO  ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SINISTRO  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -4339- DISPLAY 'NUM-APOLICE        ' SINISMES-NUM-APOLICE */
                _.Display($"NUM-APOLICE        {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -4340- DISPLAY 'NUM-ENDOSSO        ' SINISMES-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO        {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_ENDOSSO}");

                /*" -4341- DISPLAY 'COD-SUBGRUPO       ' SINISMES-COD-SUBGRUPO */
                _.Display($"COD-SUBGRUPO       {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO}");

                /*" -4342- DISPLAY 'NUM-CERTIFICADO    ' SINISMES-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO    {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO}");

                /*" -4343- DISPLAY 'DAC-CERTIFICADO    ' SINISMES-DAC-CERTIFICADO */
                _.Display($"DAC-CERTIFICADO    {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DAC_CERTIFICADO}");

                /*" -4344- DISPLAY 'TIPO-SEGURADO      ' SINISMES-TIPO-SEGURADO */
                _.Display($"TIPO-SEGURADO      {SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO}");

                /*" -4345- DISPLAY 'NUM-EMBARQUE       ' SINISMES-NUM-EMBARQUE */
                _.Display($"NUM-EMBARQUE       {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_EMBARQUE}");

                /*" -4346- DISPLAY 'REF-EMBARQUE       ' SINISMES-REF-EMBARQUE */
                _.Display($"REF-EMBARQUE       {SINISMES.DCLSINISTRO_MESTRE.SINISMES_REF_EMBARQUE}");

                /*" -4347- DISPLAY 'OCORR-HISTORICO    ' SINISMES-OCORR-HISTORICO */
                _.Display($"OCORR-HISTORICO    {SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO}");

                /*" -4348- DISPLAY 'COD-LIDER          ' SINISMES-COD-LIDER */
                _.Display($"COD-LIDER          {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_LIDER}");

                /*" -4349- DISPLAY 'NUM-SINI-LIDER     ' SINISMES-NUM-SINI-LIDER */
                _.Display($"NUM-SINI-LIDER     {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_SINI_LIDER}");

                /*" -4350- DISPLAY 'DATA-COMUNICADO    ' SINISMES-DATA-COMUNICADO */
                _.Display($"DATA-COMUNICADO    {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO}");

                /*" -4351- DISPLAY 'DATA-OCORRENCIA    ' SINISMES-DATA-OCORRENCIA */
                _.Display($"DATA-OCORRENCIA    {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA}");

                /*" -4352- DISPLAY 'DATA-TECNICA       ' SINISMES-DATA-TECNICA */
                _.Display($"DATA-TECNICA       {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA}");

                /*" -4353- DISPLAY 'COD-CAUSA          ' SINISMES-COD-CAUSA */
                _.Display($"COD-CAUSA          {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -4354- DISPLAY 'NUM-IRB            ' SINISMES-NUM-IRB */
                _.Display($"NUM-IRB            {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB}");

                /*" -4355- DISPLAY 'NUM-AVISO-IRB      ' SINISMES-NUM-AVISO-IRB */
                _.Display($"NUM-AVISO-IRB      {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_AVISO_IRB}");

                /*" -4356- DISPLAY 'COD-MOEDA-SINI     ' SINISMES-COD-MOEDA-SINI */
                _.Display($"COD-MOEDA-SINI     {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_MOEDA_SINI}");

                /*" -4357- DISPLAY 'SALDO-PAGAR-IX     ' SINISMES-SALDO-PAGAR-IX */
                _.Display($"SALDO-PAGAR-IX     {SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_PAGAR_IX}");

                /*" -4358- DISPLAY 'TOT-PAGAMENTO-IX   ' SINISMES-TOT-PAGAMENTO-IX */
                _.Display($"TOT-PAGAMENTO-IX   {SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_PAGAMENTO_IX}");

                /*" -4359- DISPLAY 'SALDO-RECUPERAR-IX ' SINISMES-SALDO-RECUPERAR-IX */
                _.Display($"SALDO-RECUPERAR-IX {SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_RECUPERAR_IX}");

                /*" -4360- DISPLAY 'TOT-RECUPERADO-IX  ' SINISMES-TOT-RECUPERADO-IX */
                _.Display($"TOT-RECUPERADO-IX  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_RECUPERADO_IX}");

                /*" -4361- DISPLAY 'SALDO-RESSARCIR-IX ' SINISMES-SALDO-RESSARCIR-IX */
                _.Display($"SALDO-RESSARCIR-IX {SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_RESSARCIR_IX}");

                /*" -4362- DISPLAY 'TOT-RESSARCIDO-IX  ' SINISMES-TOT-RESSARCIDO-IX */
                _.Display($"TOT-RESSARCIDO-IX  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_RESSARCIDO_IX}");

                /*" -4363- DISPLAY 'TOT-DESPESAS-IX    ' SINISMES-TOT-DESPESAS-IX */
                _.Display($"TOT-DESPESAS-IX    {SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_DESPESAS_IX}");

                /*" -4364- DISPLAY 'TOT-HONORARIOS-IX  ' SINISMES-TOT-HONORARIOS-IX */
                _.Display($"TOT-HONORARIOS-IX  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_HONORARIOS_IX}");

                /*" -4365- DISPLAY 'ADIA-RECUPERAR-IX  ' SINISMES-ADIA-RECUPERAR-IX */
                _.Display($"ADIA-RECUPERAR-IX  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_ADIA_RECUPERAR_IX}");

                /*" -4366- DISPLAY 'ADIA-RECUPERADO-IX ' SINISMES-ADIA-RECUPERADO-IX */
                _.Display($"ADIA-RECUPERADO-IX {SINISMES.DCLSINISTRO_MESTRE.SINISMES_ADIA_RECUPERADO_IX}");

                /*" -4367- DISPLAY 'IMP-SEGURADA-IX    ' SINISMES-IMP-SEGURADA-IX */
                _.Display($"IMP-SEGURADA-IX    {SINISMES.DCLSINISTRO_MESTRE.SINISMES_IMP_SEGURADA_IX}");

                /*" -4368- DISPLAY 'PCT-PART-COSSEGURO ' SINISMES-PCT-PART-COSSEGURO */
                _.Display($"PCT-PART-COSSEGURO {SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_COSSEGURO}");

                /*" -4369- DISPLAY 'PCT-PART-RESSEGURO ' SINISMES-PCT-PART-RESSEGURO */
                _.Display($"PCT-PART-RESSEGURO {SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_RESSEGURO}");

                /*" -4370- DISPLAY 'APROVACAO-ALCADA   ' SINISMES-APROVACAO-ALCADA */
                _.Display($"APROVACAO-ALCADA   {SINISMES.DCLSINISTRO_MESTRE.SINISMES_APROVACAO_ALCADA}");

                /*" -4371- DISPLAY 'IND-SALVADO        ' SINISMES-IND-SALVADO */
                _.Display($"IND-SALVADO        {SINISMES.DCLSINISTRO_MESTRE.SINISMES_IND_SALVADO}");

                /*" -4372- DISPLAY 'INTEGRAL-ESPECIAL  ' SINISMES-INTEGRAL-ESPECIAL */
                _.Display($"INTEGRAL-ESPECIAL  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_INTEGRAL_ESPECIAL}");

                /*" -4373- DISPLAY 'NUM-MOV-SINI-ATU   ' SINISMES-NUM-MOV-SINI-ATU */
                _.Display($"NUM-MOV-SINI-ATU   {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_MOV_SINI_ATU}");

                /*" -4374- DISPLAY 'NUM-MOV-SINI-ANT   ' SINISMES-NUM-MOV-SINI-ANT */
                _.Display($"NUM-MOV-SINI-ANT   {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_MOV_SINI_ANT}");

                /*" -4375- DISPLAY 'DATA-ULT-MOVIMENTO ' SINISMES-DATA-ULT-MOVIMENTO */
                _.Display($"DATA-ULT-MOVIMENTO {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_ULT_MOVIMENTO}");

                /*" -4376- DISPLAY 'SIT-REGISTRO       ' SINISMES-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO       {SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO}");

                /*" -4377- DISPLAY 'BANCO-ORDEM-PAG    ' SINISMES-BANCO-ORDEM-PAG */
                _.Display($"BANCO-ORDEM-PAG    {SINISMES.DCLSINISTRO_MESTRE.SINISMES_BANCO_ORDEM_PAG}");

                /*" -4378- DISPLAY 'AGENCIA-ORDEM-PAG  ' SINISMES-AGENCIA-ORDEM-PAG */
                _.Display($"AGENCIA-ORDEM-PAG  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_AGENCIA_ORDEM_PAG}");

                /*" -4379- DISPLAY 'TIPO-PAGAMENTO     ' SINISMES-TIPO-PAGAMENTO */
                _.Display($"TIPO-PAGAMENTO     {SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_PAGAMENTO}");

                /*" -4380- DISPLAY 'RAMO               ' SINISMES-RAMO */
                _.Display($"RAMO               {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -4381- DISPLAY 'NUMERO-ORDEM       ' SINISMES-NUMERO-ORDEM */
                _.Display($"NUMERO-ORDEM       {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUMERO_ORDEM}");

                /*" -4382- DISPLAY 'COD-PRODUTO        ' SINISMES-COD-PRODUTO */
                _.Display($"COD-PRODUTO        {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -4384- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4384- PERFORM R055-ALTERA-NUMERO-AES THRU R055-EXIT. */

            R055_ALTERA_NUMERO_AES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R055_EXIT*/


        }

        [StopWatch]
        /*" R1030-INCLUI-SINISMES-DB-INSERT-1 */
        public void R1030_INCLUI_SINISMES_DB_INSERT_1()
        {
            /*" -4328- EXEC SQL INSERT INTO SEGUROS.SINISTRO_MESTRE (COD_EMPRESA, TIPO_REGISTRO, COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_APOL_SINISTRO, NUM_APOLICE, NUM_ENDOSSO, COD_SUBGRUPO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_SEGURADO, NUM_EMBARQUE, REF_EMBARQUE, OCORR_HISTORICO, COD_LIDER, NUM_SINI_LIDER, DATA_COMUNICADO, DATA_OCORRENCIA, DATA_TECNICA, COD_CAUSA, NUM_IRB, NUM_AVISO_IRB, COD_MOEDA_SINI, SALDO_PAGAR_IX, TOT_PAGAMENTO_IX, SALDO_RECUPERAR_IX, TOT_RECUPERADO_IX, SALDO_RESSARCIR_IX, TOT_RESSARCIDO_IX, TOT_DESPESAS_IX, TOT_HONORARIOS_IX, ADIA_RECUPERAR_IX, ADIA_RECUPERADO_IX, IMP_SEGURADA_IX, PCT_PART_COSSEGURO, PCT_PART_RESSEGURO, APROVACAO_ALCADA, IND_SALVADO, INTEGRAL_ESPECIAL, NUM_MOV_SINI_ATU, NUM_MOV_SINI_ANT, DATA_ULT_MOVIMENTO, SIT_REGISTRO, TIMESTAMP, BANCO_ORDEM_PAG, AGENCIA_ORDEM_PAG, TIPO_PAGAMENTO, RAMO, NUMERO_ORDEM, COD_PRODUTO) VALUES (:SINISMES-COD-EMPRESA, :SINISMES-TIPO-REGISTRO, :SINISMES-COD-FONTE, :SINISMES-NUM-PROTOCOLO-SINI, :SINISMES-DAC-PROTOCOLO-SINI, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-NUM-APOLICE, :SINISMES-NUM-ENDOSSO, :SINISMES-COD-SUBGRUPO, :SINISMES-NUM-CERTIFICADO, :SINISMES-DAC-CERTIFICADO, :SINISMES-TIPO-SEGURADO, :SINISMES-NUM-EMBARQUE, :SINISMES-REF-EMBARQUE, :SINISMES-OCORR-HISTORICO, :SINISMES-COD-LIDER, :SINISMES-NUM-SINI-LIDER, :SINISMES-DATA-COMUNICADO, :SINISMES-DATA-OCORRENCIA, :SINISMES-DATA-TECNICA, :SINISMES-COD-CAUSA, :SINISMES-NUM-IRB, :SINISMES-NUM-AVISO-IRB, :SINISMES-COD-MOEDA-SINI, :SINISMES-SALDO-PAGAR-IX, :SINISMES-TOT-PAGAMENTO-IX, :SINISMES-SALDO-RECUPERAR-IX, :SINISMES-TOT-RECUPERADO-IX, :SINISMES-SALDO-RESSARCIR-IX, :SINISMES-TOT-RESSARCIDO-IX, :SINISMES-TOT-DESPESAS-IX, :SINISMES-TOT-HONORARIOS-IX, :SINISMES-ADIA-RECUPERAR-IX, :SINISMES-ADIA-RECUPERADO-IX, :SINISMES-IMP-SEGURADA-IX, :SINISMES-PCT-PART-COSSEGURO, :SINISMES-PCT-PART-RESSEGURO, :SINISMES-APROVACAO-ALCADA, :SINISMES-IND-SALVADO, :SINISMES-INTEGRAL-ESPECIAL, :SINISMES-NUM-MOV-SINI-ATU, :SINISMES-NUM-MOV-SINI-ANT, :SINISMES-DATA-ULT-MOVIMENTO, :SINISMES-SIT-REGISTRO, CURRENT TIMESTAMP, :SINISMES-BANCO-ORDEM-PAG, :SINISMES-AGENCIA-ORDEM-PAG, :SINISMES-TIPO-PAGAMENTO, :SINISMES-RAMO, :SINISMES-NUMERO-ORDEM, :SINISMES-COD-PRODUTO) END-EXEC. */

            var r1030_INCLUI_SINISMES_DB_INSERT_1_Insert1 = new R1030_INCLUI_SINISMES_DB_INSERT_1_Insert1()
            {
                SINISMES_COD_EMPRESA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_EMPRESA.ToString(),
                SINISMES_TIPO_REGISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO.ToString(),
                SINISMES_COD_FONTE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE.ToString(),
                SINISMES_NUM_PROTOCOLO_SINI = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI.ToString(),
                SINISMES_DAC_PROTOCOLO_SINI = SINISMES.DCLSINISTRO_MESTRE.SINISMES_DAC_PROTOCOLO_SINI.ToString(),
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
                SINISMES_NUM_ENDOSSO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_ENDOSSO.ToString(),
                SINISMES_COD_SUBGRUPO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO.ToString(),
                SINISMES_NUM_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.ToString(),
                SINISMES_DAC_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_DAC_CERTIFICADO.ToString(),
                SINISMES_TIPO_SEGURADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO.ToString(),
                SINISMES_NUM_EMBARQUE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_EMBARQUE.ToString(),
                SINISMES_REF_EMBARQUE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_REF_EMBARQUE.ToString(),
                SINISMES_OCORR_HISTORICO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.ToString(),
                SINISMES_COD_LIDER = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_LIDER.ToString(),
                SINISMES_NUM_SINI_LIDER = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_SINI_LIDER.ToString(),
                SINISMES_DATA_COMUNICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO.ToString(),
                SINISMES_DATA_OCORRENCIA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.ToString(),
                SINISMES_DATA_TECNICA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA.ToString(),
                SINISMES_COD_CAUSA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA.ToString(),
                SINISMES_NUM_IRB = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB.ToString(),
                SINISMES_NUM_AVISO_IRB = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_AVISO_IRB.ToString(),
                SINISMES_COD_MOEDA_SINI = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_MOEDA_SINI.ToString(),
                SINISMES_SALDO_PAGAR_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_PAGAR_IX.ToString(),
                SINISMES_TOT_PAGAMENTO_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_PAGAMENTO_IX.ToString(),
                SINISMES_SALDO_RECUPERAR_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_RECUPERAR_IX.ToString(),
                SINISMES_TOT_RECUPERADO_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_RECUPERADO_IX.ToString(),
                SINISMES_SALDO_RESSARCIR_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_RESSARCIR_IX.ToString(),
                SINISMES_TOT_RESSARCIDO_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_RESSARCIDO_IX.ToString(),
                SINISMES_TOT_DESPESAS_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_DESPESAS_IX.ToString(),
                SINISMES_TOT_HONORARIOS_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_HONORARIOS_IX.ToString(),
                SINISMES_ADIA_RECUPERAR_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_ADIA_RECUPERAR_IX.ToString(),
                SINISMES_ADIA_RECUPERADO_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_ADIA_RECUPERADO_IX.ToString(),
                SINISMES_IMP_SEGURADA_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_IMP_SEGURADA_IX.ToString(),
                SINISMES_PCT_PART_COSSEGURO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_COSSEGURO.ToString(),
                SINISMES_PCT_PART_RESSEGURO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_RESSEGURO.ToString(),
                SINISMES_APROVACAO_ALCADA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_APROVACAO_ALCADA.ToString(),
                SINISMES_IND_SALVADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_IND_SALVADO.ToString(),
                SINISMES_INTEGRAL_ESPECIAL = SINISMES.DCLSINISTRO_MESTRE.SINISMES_INTEGRAL_ESPECIAL.ToString(),
                SINISMES_NUM_MOV_SINI_ATU = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_MOV_SINI_ATU.ToString(),
                SINISMES_NUM_MOV_SINI_ANT = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_MOV_SINI_ANT.ToString(),
                SINISMES_DATA_ULT_MOVIMENTO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_ULT_MOVIMENTO.ToString(),
                SINISMES_SIT_REGISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO.ToString(),
                SINISMES_BANCO_ORDEM_PAG = SINISMES.DCLSINISTRO_MESTRE.SINISMES_BANCO_ORDEM_PAG.ToString(),
                SINISMES_AGENCIA_ORDEM_PAG = SINISMES.DCLSINISTRO_MESTRE.SINISMES_AGENCIA_ORDEM_PAG.ToString(),
                SINISMES_TIPO_PAGAMENTO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_PAGAMENTO.ToString(),
                SINISMES_RAMO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.ToString(),
                SINISMES_NUMERO_ORDEM = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUMERO_ORDEM.ToString(),
                SINISMES_COD_PRODUTO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.ToString(),
            };

            R1030_INCLUI_SINISMES_DB_INSERT_1_Insert1.Execute(r1030_INCLUI_SINISMES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_EXIT*/

        [StopWatch]
        /*" R1040-INCLUI-SILOTER1 */
        private void R1040_INCLUI_SILOTER1(bool isPerform = false)
        {
            /*" -4394- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4395- MOVE LOTERI01-COD-LOT-FENAL TO SINILT01-COD-LOT-FENAL */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL);

            /*" -4396- MOVE LOTERI01-NUM-APOLICE TO SINILT01-NUM-APOLICE */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE, SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE);

            /*" -4398- MOVE SINISMES-NUM-APOL-SINISTRO TO SINILT01-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOL_SINISTRO);

            /*" -4400- MOVE LOTERI01-NUM-CONTROLE-FENAL TO SINILT01-NUM-CONTROLE-FENAL */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_CONTROLE_FENAL, SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_CONTROLE_FENAL);

            /*" -4401- MOVE LOTERI01-COD-LOT-CEF TO SINILT01-COD-LOT-CEF */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF);

            /*" -4402- MOVE LOTERI01-COD-CLIENTE TO SINILT01-COD-CLIENTE */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLIENTE, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_CLIENTE);

            /*" -4403- MOVE ' ' TO SINILT01-SITUACAO */
            _.Move(" ", SINILT01.DCLSINI_LOTERICO01.SINILT01_SITUACAO);

            /*" -4404- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINILT01-DATA-GERA-MOV */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINILT01.DCLSINI_LOTERICO01.SINILT01_DATA_GERA_MOV);

            /*" -4405- MOVE '1' TO SINILT01-COD-ORIGEM-AVISO */
            _.Move("1", SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_ORIGEM_AVISO);

            /*" -4406- MOVE LOTERI01-DTINIVIG TO SINILT01-DTINIVIG */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DTINIVIG, SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG);

            /*" -4410- MOVE AV-COD-NATUREZA-N TO SINILT01-COD-COBERTURA */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA_N, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA);

            /*" -4439- PERFORM R1040_INCLUI_SILOTER1_DB_INSERT_1 */

            R1040_INCLUI_SILOTER1_DB_INSERT_1();

            /*" -4442- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4443- DISPLAY 'ERRO NA INCLUSAO DA TABELA .SINI_LOTERICO01' */
                _.Display($"ERRO NA INCLUSAO DA TABELA .SINI_LOTERICO01");

                /*" -4444- DISPLAY 'COD-LOT-FENAL      ' SINILT01-COD-LOT-FENAL */
                _.Display($"COD-LOT-FENAL      {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}");

                /*" -4445- DISPLAY 'NUM-APOLICE        ' SINILT01-NUM-APOLICE */
                _.Display($"NUM-APOLICE        {SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE}");

                /*" -4446- DISPLAY 'NUM-APOL-SINISTRO  ' SINILT01-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SINISTRO  {SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOL_SINISTRO}");

                /*" -4447- DISPLAY 'NUM-CONTROLE-FENAL ' SINILT01-NUM-CONTROLE-FENAL */
                _.Display($"NUM-CONTROLE-FENAL {SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_CONTROLE_FENAL}");

                /*" -4448- DISPLAY 'COD-LOT-CEF        ' SINILT01-COD-LOT-CEF */
                _.Display($"COD-LOT-CEF        {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF}");

                /*" -4449- DISPLAY 'COD-CLIENTE        ' SINILT01-COD-CLIENTE */
                _.Display($"COD-CLIENTE        {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_CLIENTE}");

                /*" -4450- DISPLAY 'SITUACAO           ' SINILT01-SITUACAO */
                _.Display($"SITUACAO           {SINILT01.DCLSINI_LOTERICO01.SINILT01_SITUACAO}");

                /*" -4451- DISPLAY 'DATA-GERA-MOV      ' SINILT01-DATA-GERA-MOV */
                _.Display($"DATA-GERA-MOV      {SINILT01.DCLSINI_LOTERICO01.SINILT01_DATA_GERA_MOV}");

                /*" -4452- DISPLAY 'COD-ORIGEM-AVISO   ' SINILT01-COD-ORIGEM-AVISO */
                _.Display($"COD-ORIGEM-AVISO   {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_ORIGEM_AVISO}");

                /*" -4453- DISPLAY 'DTINIVIG           ' SINILT01-DTINIVIG */
                _.Display($"DTINIVIG           {SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG}");

                /*" -4454- DISPLAY 'COD-COBERTURA      ' SINILT01-COD-COBERTURA */
                _.Display($"COD-COBERTURA      {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA}");

                /*" -4454- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1040-INCLUI-SILOTER1-DB-INSERT-1 */
        public void R1040_INCLUI_SILOTER1_DB_INSERT_1()
        {
            /*" -4439- EXEC SQL INSERT INTO SEGUROS.SINI_LOTERICO01 ( COD_LOT_FENAL ,NUM_APOLICE ,NUM_APOL_SINISTRO ,NUM_CONTROLE_FENAL ,COD_LOT_CEF ,COD_CLIENTE ,SITUACAO ,DATA_GERA_MOV ,COD_ORIGEM_AVISO ,DTINIVIG ,TIMESTAMP ,COD_COBERTURA ) VALUES (:SINILT01-COD-LOT-FENAL ,:SINILT01-NUM-APOLICE ,:SINILT01-NUM-APOL-SINISTRO ,:SINILT01-NUM-CONTROLE-FENAL ,:SINILT01-COD-LOT-CEF ,:SINILT01-COD-CLIENTE ,:SINILT01-SITUACAO ,:SINILT01-DATA-GERA-MOV ,:SINILT01-COD-ORIGEM-AVISO ,:SINILT01-DTINIVIG , CURRENT TIMESTAMP ,:SINILT01-COD-COBERTURA ) END-EXEC. */

            var r1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1 = new R1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1()
            {
                SINILT01_COD_LOT_FENAL = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL.ToString(),
                SINILT01_NUM_APOLICE = SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE.ToString(),
                SINILT01_NUM_APOL_SINISTRO = SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOL_SINISTRO.ToString(),
                SINILT01_NUM_CONTROLE_FENAL = SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_CONTROLE_FENAL.ToString(),
                SINILT01_COD_LOT_CEF = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF.ToString(),
                SINILT01_COD_CLIENTE = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_CLIENTE.ToString(),
                SINILT01_SITUACAO = SINILT01.DCLSINI_LOTERICO01.SINILT01_SITUACAO.ToString(),
                SINILT01_DATA_GERA_MOV = SINILT01.DCLSINI_LOTERICO01.SINILT01_DATA_GERA_MOV.ToString(),
                SINILT01_COD_ORIGEM_AVISO = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_ORIGEM_AVISO.ToString(),
                SINILT01_DTINIVIG = SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG.ToString(),
                SINILT01_COD_COBERTURA = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA.ToString(),
            };

            R1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1.Execute(r1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_EXIT*/

        [StopWatch]
        /*" R1050-INCLUI-SINIITEM */
        private void R1050_INCLUI_SINIITEM(bool isPerform = false)
        {
            /*" -4464- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4465- MOVE 10 TO SINIITEM-COD-FONTE */
            _.Move(10, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_FONTE);

            /*" -4467- MOVE SINISMES-NUM-APOL-SINISTRO TO SINIITEM-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_NUM_APOL_SINISTRO);

            /*" -4471- MOVE LOTERI01-COD-CLIENTE TO SINIITEM-COD-CLIENTE */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLIENTE, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE);

            /*" -4482- PERFORM R1050_INCLUI_SINIITEM_DB_INSERT_1 */

            R1050_INCLUI_SINIITEM_DB_INSERT_1();

            /*" -4485- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4486- DISPLAY 'ERRO NA INCLUSAO DA TABELA .SINISTRO_ITEM' */
                _.Display($"ERRO NA INCLUSAO DA TABELA .SINISTRO_ITEM");

                /*" -4487- DISPLAY 'NUM-APOL-SINISTRO ' SINIITEM-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SINISTRO {SINIITEM.DCLSINISTRO_ITEM.SINIITEM_NUM_APOL_SINISTRO}");

                /*" -4488- DISPLAY 'COD-CLIENTE       ' SINIITEM-COD-CLIENTE */
                _.Display($"COD-CLIENTE       {SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE}");

                /*" -4489- DISPLAY 'COD-FONTE         ' SINIITEM-COD-FONTE */
                _.Display($"COD-FONTE         {SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_FONTE}");

                /*" -4489- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-INCLUI-SINIITEM-DB-INSERT-1 */
        public void R1050_INCLUI_SINIITEM_DB_INSERT_1()
        {
            /*" -4482- EXEC SQL INSERT INTO SEGUROS.SINISTRO_ITEM ( NUM_APOL_SINISTRO ,COD_CLIENTE ,COD_FONTE ) VALUES (:SINIITEM-NUM-APOL-SINISTRO ,:SINIITEM-COD-CLIENTE ,:SINIITEM-COD-FONTE ) END-EXEC. */

            var r1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1 = new R1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1()
            {
                SINIITEM_NUM_APOL_SINISTRO = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_NUM_APOL_SINISTRO.ToString(),
                SINIITEM_COD_CLIENTE = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.ToString(),
                SINIITEM_COD_FONTE = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_FONTE.ToString(),
            };

            R1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1.Execute(r1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_EXIT*/

        [StopWatch]
        /*" R1060-MONTA-SINISHIS-BASICO */
        private void R1060_MONTA_SINISHIS_BASICO(bool isPerform = false)
        {
            /*" -4498- MOVE '0' TO SINISHIS-SIT-REGISTRO */
            _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -4499- MOVE 0 TO SINISHIS-COD-EMPRESA */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA);

            /*" -4500- MOVE '1' TO SINISHIS-TIPO-REGISTRO */
            _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO);

            /*" -4501- MOVE SINISMES-NUM-APOL-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -4502- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISHIS-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -4503- MOVE CLIENTES-NOME-RAZAO TO SINISHIS-NOME-FAVORECIDO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -4504- MOVE '0' TO SINISHIS-TIPO-FAVORECIDO */
            _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);

            /*" -4505- MOVE '9999-12-31' TO SINISHIS-DATA-LIM-CORRECAO */
            _.Move("9999-12-31", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);

            /*" -4506- MOVE '9999-12-31' TO SINISHIS-DATA-NEGOCIADA */
            _.Move("9999-12-31", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA);

            /*" -4507- MOVE 10 TO SINISHIS-FONTE-PAGAMENTO */
            _.Move(10, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO);

            /*" -4508- MOVE 0 TO SINISHIS-COD-PREST-SERVICO */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);

            /*" -4509- MOVE 0 TO SINISHIS-ORDEM-PAGAMENTO */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO);

            /*" -4510- MOVE 0 TO SINISHIS-NUM-RECIBO */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO);

            /*" -4511- MOVE 0 TO SINISHIS-NUM-MOV-SINISTRO */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO);

            /*" -4512- MOVE 'SI0005B' TO SINISHIS-COD-USUARIO */
            _.Move("SI0005B", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);

            /*" -4513- MOVE '3' TO SINISHIS-SIT-CONTABIL */
            _.Move("3", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

            /*" -4514- MOVE 0 TO SINISHIS-COD-SERVICO */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);

            /*" -4515- MOVE LOTERI01-NUM-APOLICE TO SINISHIS-NUM-APOLICE */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);

            /*" -4515- MOVE APOLICES-COD-PRODUTO TO SINISHIS-COD-PRODUTO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_EXIT*/

        [StopWatch]
        /*" R1070-INCLUI-SINISHIS */
        private void R1070_INCLUI_SINISHIS(bool isPerform = false)
        {
            /*" -4527- MOVE '1070' TO WNR-EXEC-SQL. */
            _.Move("1070", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4579- PERFORM R1070_INCLUI_SINISHIS_DB_INSERT_1 */

            R1070_INCLUI_SINISHIS_DB_INSERT_1();

            /*" -4582- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4583- DISPLAY 'ERRO NA INCLUSAO DA TABELA .SINISTRO_HISTORICO' */
                _.Display($"ERRO NA INCLUSAO DA TABELA .SINISTRO_HISTORICO");

                /*" -4584- DISPLAY 'COD-EMPRESA       ' SINISHIS-COD-EMPRESA */
                _.Display($"COD-EMPRESA       {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA}");

                /*" -4585- DISPLAY 'TIPO-REGISTRO     ' SINISHIS-TIPO-REGISTRO */
                _.Display($"TIPO-REGISTRO     {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO}");

                /*" -4586- DISPLAY 'NUM-APOL-SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -4587- DISPLAY 'OCORR-HISTORICO   ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR-HISTORICO   {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -4588- DISPLAY 'COD-OPERACAO      ' SINISHIS-COD-OPERACAO */
                _.Display($"COD-OPERACAO      {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -4589- DISPLAY 'DATA-MOVIMENTO    ' SINISHIS-DATA-MOVIMENTO */
                _.Display($"DATA-MOVIMENTO    {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}");

                /*" -4590- DISPLAY 'NOME-FAVORECIDO   ' SINISHIS-NOME-FAVORECIDO */
                _.Display($"NOME-FAVORECIDO   {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

                /*" -4591- DISPLAY 'VAL-OPERACAO      ' SINISHIS-VAL-OPERACAO */
                _.Display($"VAL-OPERACAO      {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO}");

                /*" -4592- DISPLAY 'DATA-LIM-CORRECAO ' SINISHIS-DATA-LIM-CORRECAO */
                _.Display($"DATA-LIM-CORRECAO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO}");

                /*" -4593- DISPLAY 'TIPO-FAVORECIDO   ' SINISHIS-TIPO-FAVORECIDO */
                _.Display($"TIPO-FAVORECIDO   {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO}");

                /*" -4594- DISPLAY 'DATA-NEGOCIADA    ' SINISHIS-DATA-NEGOCIADA */
                _.Display($"DATA-NEGOCIADA    {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA}");

                /*" -4595- DISPLAY 'FONTE-PAGAMENTO   ' SINISHIS-FONTE-PAGAMENTO */
                _.Display($"FONTE-PAGAMENTO   {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO}");

                /*" -4596- DISPLAY 'COD-PREST-SERVICO ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD-PREST-SERVICO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -4597- DISPLAY 'COD-SERVICO       ' SINISHIS-COD-SERVICO */
                _.Display($"COD-SERVICO       {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO}");

                /*" -4598- DISPLAY 'ORDEM-PAGAMENTO   ' SINISHIS-ORDEM-PAGAMENTO */
                _.Display($"ORDEM-PAGAMENTO   {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO}");

                /*" -4599- DISPLAY 'NUM-RECIBO        ' SINISHIS-NUM-RECIBO */
                _.Display($"NUM-RECIBO        {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO}");

                /*" -4600- DISPLAY 'NUM-MOV-SINISTRO  ' SINISHIS-NUM-MOV-SINISTRO */
                _.Display($"NUM-MOV-SINISTRO  {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO}");

                /*" -4601- DISPLAY 'COD-USUARIO       ' SINISHIS-COD-USUARIO */
                _.Display($"COD-USUARIO       {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO}");

                /*" -4602- DISPLAY 'SIT-CONTABIL      ' SINISHIS-SIT-CONTABIL */
                _.Display($"SIT-CONTABIL      {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL}");

                /*" -4603- DISPLAY 'SIT-REGISTRO      ' SINISHIS-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO      {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO}");

                /*" -4604- DISPLAY 'NUM-APOLICE       ' SINISHIS-NUM-APOLICE */
                _.Display($"NUM-APOLICE       {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE}");

                /*" -4605- DISPLAY 'COD-PRODUTO       ' SINISHIS-COD-PRODUTO */
                _.Display($"COD-PRODUTO       {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO}");

                /*" -4605- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1070-INCLUI-SINISHIS-DB-INSERT-1 */
        public void R1070_INCLUI_SINISHIS_DB_INSERT_1()
        {
            /*" -4579- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (:SINISHIS-COD-EMPRESA, :SINISHIS-TIPO-REGISTRO, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, CURRENT TIME , :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, CURRENT TIMESTAMP, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, 'SI0005B' ) END-EXEC. */

            var r1070_INCLUI_SINISHIS_DB_INSERT_1_Insert1 = new R1070_INCLUI_SINISHIS_DB_INSERT_1_Insert1()
            {
                SINISHIS_COD_EMPRESA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA.ToString(),
                SINISHIS_TIPO_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_VAL_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.ToString(),
                SINISHIS_DATA_LIM_CORRECAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO.ToString(),
                SINISHIS_TIPO_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO.ToString(),
                SINISHIS_DATA_NEGOCIADA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.ToString(),
                SINISHIS_FONTE_PAGAMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO.ToString(),
                SINISHIS_COD_PREST_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.ToString(),
                SINISHIS_COD_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO.ToString(),
                SINISHIS_ORDEM_PAGAMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO.ToString(),
                SINISHIS_NUM_RECIBO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO.ToString(),
                SINISHIS_NUM_MOV_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO.ToString(),
                SINISHIS_COD_USUARIO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.ToString(),
                SINISHIS_SIT_CONTABIL = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.ToString(),
                SINISHIS_SIT_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.ToString(),
                SINISHIS_NUM_APOLICE = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE.ToString(),
                SINISHIS_COD_PRODUTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.ToString(),
            };

            R1070_INCLUI_SINISHIS_DB_INSERT_1_Insert1.Execute(r1070_INCLUI_SINISHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_EXIT*/

        [StopWatch]
        /*" R1080-INCLUI-SIMOLOT1 */
        private void R1080_INCLUI_SIMOLOT1(bool isPerform = false)
        {
            /*" -4615- MOVE '1080' TO WNR-EXEC-SQL. */
            _.Move("1080", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4616- MOVE SINISMES-NUM-APOL-SINISTRO TO SIMOLOT1-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NUM_APOL_SINISTRO);

            /*" -4617- MOVE AV-COD-LOT-CEF TO SIMOLOT1-COD-LOT-CEF */
            _.Move(REGISTRO_AVISO.AV_COD_LOT_CEF, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_LOT_CEF);

            /*" -4618- MOVE AV-NOME-LOTERICO TO SIMOLOT1-NOME-LOTERICO */
            _.Move(REGISTRO_AVISO.AV_NOME_LOTERICO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NOME_LOTERICO);

            /*" -4619- MOVE HOST-DATA-OCORRENCIA TO SIMOLOT1-DATA-OCORRENCIA */
            _.Move(HOST_DATA_OCORRENCIA, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_OCORRENCIA);

            /*" -4620- MOVE HOST-HORA-OCORRENCIA TO SIMOLOT1-HORA-OCORRENCIA */
            _.Move(HOST_HORA_OCORRENCIA, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_HORA_OCORRENCIA);

            /*" -4621- MOVE HOST-DATA-GERACAO TO SIMOLOT1-DATA-GERACAO-MOV */
            _.Move(HOST_DATA_GERACAO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_GERACAO_MOV);

            /*" -4622- MOVE HOST-DATA-AVISO TO SIMOLOT1-DATA-AVISO */
            _.Move(HOST_DATA_AVISO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_AVISO);

            /*" -4623- MOVE HOST-HORA-AVISO TO SIMOLOT1-HORA-AVISO */
            _.Move(HOST_HORA_AVISO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_HORA_AVISO);

            /*" -4624- MOVE AV-VALOR-INFORMADO TO SIMOLOT1-VALOR-INFORMADO */
            _.Move(REGISTRO_AVISO.AV_VALOR_INFORMADO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO);

            /*" -4625- MOVE AV-COD-NATUREZA TO SIMOLOT1-NATUREZA */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NATUREZA);

            /*" -4626- MOVE AV-COD-CAUSA TO SIMOLOT1-COD-CAUSA */
            _.Move(REGISTRO_AVISO.AV_COD_CAUSA, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_CAUSA);

            /*" -4627- MOVE AV-DATA-ULTIMO-DOC TO W-DATA-AAAAMMDD. */
            _.Move(REGISTRO_AVISO.AV_DATA_ULTIMO_DOC, AREA_DE_WORK.W_DATA_AAAAMMDD);

            /*" -4628- MOVE W-DATA-AAAAMMDD-AAAA TO W-DATA-AAAA-MM-DD-AAAA. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA);

            /*" -4629- MOVE W-DATA-AAAAMMDD-MM TO W-DATA-AAAA-MM-DD-MM. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM);

            /*" -4630- MOVE W-DATA-AAAAMMDD-DD TO W-DATA-AAAA-MM-DD-DD. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD, AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD);

            /*" -4631- MOVE W-DATA-AAAA-MM-DD TO SIMOLOT1-DATA-ULT-DOC */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_ULT_DOC);

            /*" -4632- MOVE AV-NUM-SINISTRO-PREST TO SIMOLOT1-NUM-SINI-PREST */
            _.Move(REGISTRO_AVISO.AV_NUM_SINISTRO_PREST, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NUM_SINI_PREST);

            /*" -4633- MOVE W-VALOR-PARA-AVISO TO SIMOLOT1-VALOR-REGISTRADO */
            _.Move(AREA_DE_WORK.W_VALOR_PARA_AVISO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_REGISTRADO);

            /*" -4634- MOVE W-VALOR-ADIANTAMENTO TO SIMOLOT1-VAL-ADIANTAMENTO */
            _.Move(AREA_DE_WORK.W_VALOR_ADIANTAMENTO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_ADIANTAMENTO);

            /*" -4635- MOVE SIPARADI-PERC-ADIANTAMENTO TO SIMOLOT1-PERC-ADIANTAMENTO */
            _.Move(SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_PERC_ADIANTAMENTO);

            /*" -4636- MOVE LOTISG01-IMP-SEG TO SIMOLOT1-VAL-IS */
            _.Move(LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_IS);

            /*" -4638- MOVE ZEROS TO SIMOLOT1-COD-LOT-SASSE SIMOLOT1-QTD-MESES */
            _.Move(0, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_LOT_SASSE, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_MESES);

            /*" -4639- MOVE SISTEMAS-DATA-MOV-ABERTO TO SIMOLOT1-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_MOVIMENTO);

            /*" -4640- MOVE AV-INDICADOR-ADIANTAMENTO TO SIMOLOT1-IND-ADIANTAMENTO */
            _.Move(REGISTRO_AVISO.AV_INDICADOR_ADIANTAMENTO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_ADIANTAMENTO);

            /*" -4642- MOVE AV-QTD-PORTADORES TO SIMOLOT1-QTD-PORTADORES */
            _.Move(REGISTRO_AVISO.AV_QTD_PORTADORES, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_PORTADORES);

            /*" -4643- IF AV-VALOR-INFORMADO GREATER LOTISG01-IMP-SEG */

            if (REGISTRO_AVISO.AV_VALOR_INFORMADO > LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG)
            {

                /*" -4644- MOVE 3 TO SIMOLOT1-IND-CRITICA */
                _.Move(3, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_CRITICA);

                /*" -4646- MOVE 'VALOR INFORMADO SUPERIOR AO VALOR DA COBERTURA' TO SIMOLOT1-MENSAGEM */
                _.Move("VALOR INFORMADO SUPERIOR AO VALOR DA COBERTURA", SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_MENSAGEM);

                /*" -4647- ELSE */
            }
            else
            {


                /*" -4648- MOVE 2 TO SIMOLOT1-IND-CRITICA */
                _.Move(2, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_CRITICA);

                /*" -4650- MOVE 'SINISTRO AVISADO SEM ALTERACAO DE VALOR' TO SIMOLOT1-MENSAGEM */
                _.Move("SINISTRO AVISADO SEM ALTERACAO DE VALOR", SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_MENSAGEM);

                /*" -4652- END-IF */
            }


            /*" -4661- PERFORM R1080_INCLUI_SIMOLOT1_DB_SELECT_1 */

            R1080_INCLUI_SIMOLOT1_DB_SELECT_1();

            /*" -4664- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4665- DISPLAY 'ERRO NA QTD. SINISTROS AVISADOS .........' */
                _.Display($"ERRO NA QTD. SINISTROS AVISADOS .........");

                /*" -4666- DISPLAY 'COD. LOT. CEF   ' LOTERI01-COD-LOT-CEF */
                _.Display($"COD. LOT. CEF   {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -4667- DISPLAY 'COD. LOT. FENAL ' LOTERI01-COD-LOT-FENAL */
                _.Display($"COD. LOT. FENAL {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL}");

                /*" -4668- DISPLAY 'NUM-APOLICE     ' LOTERI01-NUM-APOLICE */
                _.Display($"NUM-APOLICE     {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -4670- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4688- PERFORM R1080_INCLUI_SIMOLOT1_DB_SELECT_2 */

            R1080_INCLUI_SIMOLOT1_DB_SELECT_2();

            /*" -4691- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4692- DISPLAY 'ERRO NA QTD. SINISTROS PAGOS ............' */
                _.Display($"ERRO NA QTD. SINISTROS PAGOS ............");

                /*" -4693- DISPLAY 'COD. LOT. CEF   ' LOTERI01-COD-LOT-CEF */
                _.Display($"COD. LOT. CEF   {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF}");

                /*" -4694- DISPLAY 'COD. LOT. FENAL ' LOTERI01-COD-LOT-FENAL */
                _.Display($"COD. LOT. FENAL {LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL}");

                /*" -4695- DISPLAY 'NUM-APOLICE     ' LOTERI01-NUM-APOLICE */
                _.Display($"NUM-APOLICE     {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -4699- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4755- PERFORM R1080_INCLUI_SIMOLOT1_DB_INSERT_1 */

            R1080_INCLUI_SIMOLOT1_DB_INSERT_1();

            /*" -4758- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4759- DISPLAY 'ERRO NA INCLUSAO DA TABELA .SI_MOV_LOTERICO1' */
                _.Display($"ERRO NA INCLUSAO DA TABELA .SI_MOV_LOTERICO1");

                /*" -4760- DISPLAY 'NUM-APOL-SINISTRO ' SIMOLOT1-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SINISTRO {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NUM_APOL_SINISTRO}");

                /*" -4761- DISPLAY 'COD-LOT-CEF       ' SIMOLOT1-COD-LOT-CEF */
                _.Display($"COD-LOT-CEF       {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_LOT_CEF}");

                /*" -4762- DISPLAY 'NOME-LOTERICO     ' SIMOLOT1-NOME-LOTERICO */
                _.Display($"NOME-LOTERICO     {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NOME_LOTERICO}");

                /*" -4763- DISPLAY 'DATA-OCORRENCIA   ' SIMOLOT1-DATA-OCORRENCIA */
                _.Display($"DATA-OCORRENCIA   {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_OCORRENCIA}");

                /*" -4764- DISPLAY 'HORA-OCORRENCIA   ' SIMOLOT1-HORA-OCORRENCIA */
                _.Display($"HORA-OCORRENCIA   {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_HORA_OCORRENCIA}");

                /*" -4765- DISPLAY 'DATA-GERACAO-MOV  ' SIMOLOT1-DATA-GERACAO-MOV */
                _.Display($"DATA-GERACAO-MOV  {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_GERACAO_MOV}");

                /*" -4766- DISPLAY 'DATA-AVISO        ' SIMOLOT1-DATA-AVISO */
                _.Display($"DATA-AVISO        {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_AVISO}");

                /*" -4767- DISPLAY 'HORA-AVISO        ' SIMOLOT1-HORA-AVISO */
                _.Display($"HORA-AVISO        {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_HORA_AVISO}");

                /*" -4768- DISPLAY 'VALOR-INFORMADO   ' SIMOLOT1-VALOR-INFORMADO */
                _.Display($"VALOR-INFORMADO   {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO}");

                /*" -4769- DISPLAY 'NATUREZA          ' SIMOLOT1-NATUREZA */
                _.Display($"NATUREZA          {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NATUREZA}");

                /*" -4770- DISPLAY 'COD-CAUSA         ' SIMOLOT1-COD-CAUSA */
                _.Display($"COD-CAUSA         {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_CAUSA}");

                /*" -4771- DISPLAY 'IND-CRITICA       ' SIMOLOT1-IND-CRITICA */
                _.Display($"IND-CRITICA       {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_CRITICA}");

                /*" -4772- DISPLAY 'MENSAGEM          ' SIMOLOT1-MENSAGEM */
                _.Display($"MENSAGEM          {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_MENSAGEM}");

                /*" -4773- DISPLAY 'VALOR-REGISTRADO  ' SIMOLOT1-VALOR-REGISTRADO */
                _.Display($"VALOR-REGISTRADO  {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_REGISTRADO}");

                /*" -4774- DISPLAY 'VAL-IS            ' SIMOLOT1-VAL-IS */
                _.Display($"VAL-IS            {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_IS}");

                /*" -4775- DISPLAY 'VAL-ADIANTAMENTO  ' SIMOLOT1-VAL-ADIANTAMENTO */
                _.Display($"VAL-ADIANTAMENTO  {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_ADIANTAMENTO}");

                /*" -4776- DISPLAY 'PERC-ADIANTAMENTO ' SIMOLOT1-PERC-ADIANTAMENTO */
                _.Display($"PERC-ADIANTAMENTO {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_PERC_ADIANTAMENTO}");

                /*" -4777- DISPLAY 'COD-LOT-SASSE     ' SIMOLOT1-COD-LOT-SASSE */
                _.Display($"COD-LOT-SASSE     {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_LOT_SASSE}");

                /*" -4778- DISPLAY 'DATA-MOVIMENTO    ' SIMOLOT1-DATA-MOVIMENTO */
                _.Display($"DATA-MOVIMENTO    {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_MOVIMENTO}");

                /*" -4779- DISPLAY 'QTD-SINI-AVISADO  ' SIMOLOT1-QTD-SINI-AVISADO */
                _.Display($"QTD-SINI-AVISADO  {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_SINI_AVISADO}");

                /*" -4780- DISPLAY 'QTD-SINI-PAGOS    ' SIMOLOT1-QTD-SINI-PAGOS */
                _.Display($"QTD-SINI-PAGOS    {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_SINI_PAGOS}");

                /*" -4781- DISPLAY 'QTD-MESES         ' SIMOLOT1-QTD-MESES */
                _.Display($"QTD-MESES         {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_MESES}");

                /*" -4782- DISPLAY 'DATA-ULT-DOC      ' SIMOLOT1-DATA-ULT-DOC */
                _.Display($"DATA-ULT-DOC      {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_ULT_DOC}");

                /*" -4783- DISPLAY 'NUM-SINI-PREST    ' SIMOLOT1-NUM-SINI-PREST */
                _.Display($"NUM-SINI-PREST    {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NUM_SINI_PREST}");

                /*" -4784- DISPLAY 'QTD-PORTADORES    ' SIMOLOT1-QTD-PORTADORES */
                _.Display($"QTD-PORTADORES    {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_PORTADORES}");

                /*" -4785- DISPLAY 'IND-ADIANTAMENTO  ' SIMOLOT1-IND-ADIANTAMENTO */
                _.Display($"IND-ADIANTAMENTO  {SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_ADIANTAMENTO}");

                /*" -4785- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1080-INCLUI-SIMOLOT1-DB-SELECT-1 */
        public void R1080_INCLUI_SIMOLOT1_DB_SELECT_1()
        {
            /*" -4661- EXEC SQL SELECT VALUE(COUNT(DISTINCT SL.NUM_APOL_SINISTRO),0) INTO :SIMOLOT1-QTD-SINI-AVISADO FROM SEGUROS.SINI_LOTERICO01 SL ,SEGUROS.SINISTRO_MESTRE M WHERE SL.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND SL.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND SL.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO END-EXEC. */

            var r1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1 = new R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1()
            {
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                LOTERI01_COD_LOT_CEF = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1.Execute(r1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIMOLOT1_QTD_SINI_AVISADO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_SINI_AVISADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_EXIT*/

        [StopWatch]
        /*" R1080-INCLUI-SIMOLOT1-DB-INSERT-1 */
        public void R1080_INCLUI_SIMOLOT1_DB_INSERT_1()
        {
            /*" -4755- EXEC SQL INSERT INTO SEGUROS.SI_MOV_LOTERICO1 (NUM_APOL_SINISTRO, COD_LOT_CEF, NOME_LOTERICO, DATA_OCORRENCIA, HORA_OCORRENCIA, DATA_GERACAO_MOV, DATA_AVISO, HORA_AVISO, VALOR_INFORMADO, NATUREZA, COD_CAUSA, IND_CRITICA, MENSAGEM, VALOR_REGISTRADO, VAL_IS, VAL_ADIANTAMENTO, PERC_ADIANTAMENTO, COD_LOT_SASSE, DATA_MOVIMENTO, QTD_SINI_AVISADO, QTD_SINI_PAGOS, QTD_MESES, TIMESTAMP, DATA_ULT_DOC, NUM_SINI_PREST, QTD_PORTADORES, IND_ADIANTAMENTO) VALUES (:SIMOLOT1-NUM-APOL-SINISTRO, :SIMOLOT1-COD-LOT-CEF, :SIMOLOT1-NOME-LOTERICO, :SIMOLOT1-DATA-OCORRENCIA, :SIMOLOT1-HORA-OCORRENCIA, :SIMOLOT1-DATA-GERACAO-MOV, :SIMOLOT1-DATA-AVISO, :SIMOLOT1-HORA-AVISO, :SIMOLOT1-VALOR-INFORMADO, :SIMOLOT1-NATUREZA, :SIMOLOT1-COD-CAUSA, :SIMOLOT1-IND-CRITICA, :SIMOLOT1-MENSAGEM, :SIMOLOT1-VALOR-REGISTRADO, :SIMOLOT1-VAL-IS, :SIMOLOT1-VAL-ADIANTAMENTO, :SIMOLOT1-PERC-ADIANTAMENTO, :SIMOLOT1-COD-LOT-SASSE, :SIMOLOT1-DATA-MOVIMENTO, :SIMOLOT1-QTD-SINI-AVISADO, :SIMOLOT1-QTD-SINI-PAGOS, :SIMOLOT1-QTD-MESES, CURRENT TIMESTAMP, :SIMOLOT1-DATA-ULT-DOC, :SIMOLOT1-NUM-SINI-PREST, :SIMOLOT1-QTD-PORTADORES, :SIMOLOT1-IND-ADIANTAMENTO) END-EXEC. */

            var r1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1 = new R1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1()
            {
                SIMOLOT1_NUM_APOL_SINISTRO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NUM_APOL_SINISTRO.ToString(),
                SIMOLOT1_COD_LOT_CEF = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_LOT_CEF.ToString(),
                SIMOLOT1_NOME_LOTERICO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NOME_LOTERICO.ToString(),
                SIMOLOT1_DATA_OCORRENCIA = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_OCORRENCIA.ToString(),
                SIMOLOT1_HORA_OCORRENCIA = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_HORA_OCORRENCIA.ToString(),
                SIMOLOT1_DATA_GERACAO_MOV = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_GERACAO_MOV.ToString(),
                SIMOLOT1_DATA_AVISO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_AVISO.ToString(),
                SIMOLOT1_HORA_AVISO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_HORA_AVISO.ToString(),
                SIMOLOT1_VALOR_INFORMADO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO.ToString(),
                SIMOLOT1_NATUREZA = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NATUREZA.ToString(),
                SIMOLOT1_COD_CAUSA = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_CAUSA.ToString(),
                SIMOLOT1_IND_CRITICA = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_CRITICA.ToString(),
                SIMOLOT1_MENSAGEM = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_MENSAGEM.ToString(),
                SIMOLOT1_VALOR_REGISTRADO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_REGISTRADO.ToString(),
                SIMOLOT1_VAL_IS = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_IS.ToString(),
                SIMOLOT1_VAL_ADIANTAMENTO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_ADIANTAMENTO.ToString(),
                SIMOLOT1_PERC_ADIANTAMENTO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_PERC_ADIANTAMENTO.ToString(),
                SIMOLOT1_COD_LOT_SASSE = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_COD_LOT_SASSE.ToString(),
                SIMOLOT1_DATA_MOVIMENTO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_MOVIMENTO.ToString(),
                SIMOLOT1_QTD_SINI_AVISADO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_SINI_AVISADO.ToString(),
                SIMOLOT1_QTD_SINI_PAGOS = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_SINI_PAGOS.ToString(),
                SIMOLOT1_QTD_MESES = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_MESES.ToString(),
                SIMOLOT1_DATA_ULT_DOC = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_ULT_DOC.ToString(),
                SIMOLOT1_NUM_SINI_PREST = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NUM_SINI_PREST.ToString(),
                SIMOLOT1_QTD_PORTADORES = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_PORTADORES.ToString(),
                SIMOLOT1_IND_ADIANTAMENTO = SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_ADIANTAMENTO.ToString(),
            };

            R1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1.Execute(r1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1080-INCLUI-SIMOLOT1-DB-SELECT-2 */
        public void R1080_INCLUI_SIMOLOT1_DB_SELECT_2()
        {
            /*" -4688- EXEC SQL SELECT VALUE(COUNT(DISTINCT SL.NUM_APOL_SINISTRO),0) INTO :SIMOLOT1-QTD-SINI-PAGOS FROM SEGUROS.SINI_LOTERICO01 SL ,SEGUROS.SINISTRO_MESTRE M ,SEGUROS.SINISTRO_HISTORICO H ,SEGUROS.GE_OPERACAO O WHERE SL.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF AND SL.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND SL.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND M.SIT_REGISTRO <> '2' AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.SIT_REGISTRO <> '2' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO = 'IN' AND O.FUNCAO_OPERACAO = 'PRE' AND O.IDE_SISTEMA = 'SI' END-EXEC. */

            var r1080_INCLUI_SIMOLOT1_DB_SELECT_2_Query1 = new R1080_INCLUI_SIMOLOT1_DB_SELECT_2_Query1()
            {
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                LOTERI01_COD_LOT_CEF = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1080_INCLUI_SIMOLOT1_DB_SELECT_2_Query1.Execute(r1080_INCLUI_SIMOLOT1_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIMOLOT1_QTD_SINI_PAGOS, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_SINI_PAGOS);
            }


        }

        [StopWatch]
        /*" R1090-INCLUI-DOC01 */
        private void R1090_INCLUI_DOC01(bool isPerform = false)
        {
            /*" -4795- MOVE '1090' TO WNR-EXEC-SQL. */
            _.Move("1090", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4797- MOVE AV-COD-NATUREZA TO SILOTDC2-COD-COBERTURA. */
            _.Move(REGISTRO_AVISO.AV_COD_NATUREZA, SILOTDC2.DCLSINI_LOT_DOC02.SILOTDC2_COD_COBERTURA);

            /*" -4803- PERFORM R1090_INCLUI_DOC01_DB_DECLARE_1 */

            R1090_INCLUI_DOC01_DB_DECLARE_1();

            /*" -4807- PERFORM R1090_INCLUI_DOC01_DB_OPEN_1 */

            R1090_INCLUI_DOC01_DB_OPEN_1();

            /*" -4810- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4811- DISPLAY 'ERRO OPEN CURSOR DOCUMENTOS' */
                _.Display($"ERRO OPEN CURSOR DOCUMENTOS");

                /*" -4812- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -4812- END-IF. */
            }


        }

        [StopWatch]
        /*" R1090-INCLUI-DOC01-DB-OPEN-1 */
        public void R1090_INCLUI_DOC01_DB_OPEN_1()
        {
            /*" -4807- EXEC SQL OPEN DOCUMENTOS END-EXEC. */

            DOCUMENTOS.Open();

        }

        [StopWatch]
        /*" R2010-DECLARE-ADIANT-PENDENTES-DB-DECLARE-1 */
        public void R2010_DECLARE_ADIANT_PENDENTES_DB_DECLARE_1()
        {
            /*" -4945- EXEC SQL DECLARE ADIANT_PEND CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.DATA_MOVIMENTO, H.VAL_OPERACAO, SL.COD_LOT_CEF, C.NOME_RAZAO, A.VAL_OPERACAO AS VALOR_AVISADO, M.DATA_OCORRENCIA, B.VALOR_INFORMADO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HISTORICO A, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.CLIENTES C, SEGUROS.SI_MOV_LOTERICO1 B WHERE H.COD_OPERACAO = 1170 AND H.COD_PRODUTO IN (1803,1805) AND H.SIT_REGISTRO = '0' AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.COD_OPERACAO = 101 AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND C.COD_CLIENTE = SL.COD_CLIENTE AND B.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO ORDER BY H.DATA_MOVIMENTO, H.NUM_APOL_SINISTRO END-EXEC. */
            ADIANT_PEND = new SI0005B_ADIANT_PEND(false);
            string GetQuery_ADIANT_PEND()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.DATA_MOVIMENTO
							, 
							H.VAL_OPERACAO
							, 
							SL.COD_LOT_CEF
							, 
							C.NOME_RAZAO
							, 
							A.VAL_OPERACAO AS VALOR_AVISADO
							, 
							M.DATA_OCORRENCIA
							, 
							B.VALOR_INFORMADO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HISTORICO A
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINI_LOTERICO01 SL
							, 
							SEGUROS.CLIENTES C
							, 
							SEGUROS.SI_MOV_LOTERICO1 B 
							WHERE H.COD_OPERACAO = 1170 
							AND H.COD_PRODUTO IN (1803
							,1805) 
							AND H.SIT_REGISTRO = '0' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND A.COD_OPERACAO = 101 
							AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND C.COD_CLIENTE = SL.COD_CLIENTE 
							AND B.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							ORDER BY H.DATA_MOVIMENTO
							, H.NUM_APOL_SINISTRO";

                return query;
            }
            ADIANT_PEND.GetQueryEvent += GetQuery_ADIANT_PEND;

        }

        [StopWatch]
        /*" R1090-LE-NOVAMENTE */
        private void R1090_LE_NOVAMENTE(bool isPerform = false)
        {
            /*" -4818- PERFORM R1090_LE_NOVAMENTE_DB_FETCH_1 */

            R1090_LE_NOVAMENTE_DB_FETCH_1();

            /*" -4821- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -4823- PERFORM R1090_LE_NOVAMENTE_DB_CLOSE_1 */

                R1090_LE_NOVAMENTE_DB_CLOSE_1();

                /*" -4825- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -4826- DISPLAY 'ERRO CLOSE CURSOR DOCUMENTOS' */
                    _.Display($"ERRO CLOSE CURSOR DOCUMENTOS");

                    /*" -4827- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -4828- END-IF */
                }


                /*" -4829- GO TO R1090-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1090_EXIT*/ //GOTO
                return;

                /*" -4831- END-IF. */
            }


            /*" -4832- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -4833- DISPLAY 'ERRO NA LEITURA DO CURSOR DOCUMENTOS' */
                _.Display($"ERRO NA LEITURA DO CURSOR DOCUMENTOS");

                /*" -4834- DISPLAY 'NUMERO SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUMERO SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -4836- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4837- MOVE SINISMES-NUM-APOL-SINISTRO TO SINLOTDO-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_NUM_APOL_SINISTRO);

            /*" -4838- MOVE SILOTDC2-COD-DOCUMENTO TO SINLOTDO-COD-DOCUMENTO */
            _.Move(SILOTDC2.DCLSINI_LOT_DOC02.SILOTDC2_COD_DOCUMENTO, SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_COD_DOCUMENTO);

            /*" -4839- MOVE SINISMES-DATA-COMUNICADO TO SINLOTDO-DATA-RECEBE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_DATA_RECEBE);

            /*" -4840- MOVE 'SI0005B' TO SINLOTDO-CODUSU-RECEBE */
            _.Move("SI0005B", SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_RECEBE);

            /*" -4841- MOVE '00000101' TO SINLOTDO-DATA-SOLICITA */
            _.Move("00000101", SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_DATA_SOLICITA);

            /*" -4844- MOVE '0001-01-01-00.01.01.000001' TO SINLOTDO-TMSP-MOV-SOLICITA SINLOTDO-TMSP-MOV-SITUACAO */
            _.Move("0001-01-01-00.01.01.000001", SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_SOLICITA, SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_SITUACAO);

            /*" -4850- MOVE ' ' TO SINLOTDO-CODUSU-SOLICITA SINLOTDO-SITUACAO SINLOTDO-CODUSU-SITUACAO. */
            _.Move(" ", SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_SOLICITA, SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_SITUACAO, SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_SITUACAO);

            /*" -4879- PERFORM R1090_LE_NOVAMENTE_DB_INSERT_1 */

            R1090_LE_NOVAMENTE_DB_INSERT_1();

            /*" -4882- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4883- DISPLAY 'ERRO NA INCLUSAO DA TABELA .SINI_LOT_DOC01' */
                _.Display($"ERRO NA INCLUSAO DA TABELA .SINI_LOT_DOC01");

                /*" -4884- DISPLAY 'NUM-APOL-SINISTRO ' SINLOTDO-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SINISTRO {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_NUM_APOL_SINISTRO}");

                /*" -4885- DISPLAY 'COD-DOCUMENTO     ' SINLOTDO-COD-DOCUMENTO */
                _.Display($"COD-DOCUMENTO     {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_COD_DOCUMENTO}");

                /*" -4886- DISPLAY 'DATA-RECEBE       ' SINLOTDO-DATA-RECEBE */
                _.Display($"DATA-RECEBE       {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_DATA_RECEBE}");

                /*" -4887- DISPLAY 'CODUSU-RECEBE     ' SINLOTDO-CODUSU-RECEBE */
                _.Display($"CODUSU-RECEBE     {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_RECEBE}");

                /*" -4888- DISPLAY 'DATA-SOLICITA     ' SINLOTDO-DATA-SOLICITA */
                _.Display($"DATA-SOLICITA     {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_DATA_SOLICITA}");

                /*" -4889- DISPLAY 'TMSP-MOV-SOLICITA ' SINLOTDO-TMSP-MOV-SOLICITA */
                _.Display($"TMSP-MOV-SOLICITA {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_SOLICITA}");

                /*" -4890- DISPLAY 'CODUSU-SOLICITA   ' SINLOTDO-CODUSU-SOLICITA */
                _.Display($"CODUSU-SOLICITA   {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_SOLICITA}");

                /*" -4891- DISPLAY 'SITUACAO          ' SINLOTDO-SITUACAO */
                _.Display($"SITUACAO          {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_SITUACAO}");

                /*" -4892- DISPLAY 'TMSP-MOV-SITUACAO ' SINLOTDO-TMSP-MOV-SITUACAO */
                _.Display($"TMSP-MOV-SITUACAO {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_SITUACAO}");

                /*" -4893- DISPLAY 'CODUSU-SITUACAO   ' SINLOTDO-CODUSU-SITUACAO */
                _.Display($"CODUSU-SITUACAO   {SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_SITUACAO}");

                /*" -4895- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4895- GO TO R1090-LE-NOVAMENTE. */
            new Task(() => R1090_LE_NOVAMENTE()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1090-LE-NOVAMENTE-DB-FETCH-1 */
        public void R1090_LE_NOVAMENTE_DB_FETCH_1()
        {
            /*" -4818- EXEC SQL FETCH DOCUMENTOS INTO :SILOTDC2-COD-DOCUMENTO END-EXEC. */

            if (DOCUMENTOS.Fetch())
            {
                _.Move(DOCUMENTOS.SILOTDC2_COD_DOCUMENTO, SILOTDC2.DCLSINI_LOT_DOC02.SILOTDC2_COD_DOCUMENTO);
            }

        }

        [StopWatch]
        /*" R1090-LE-NOVAMENTE-DB-CLOSE-1 */
        public void R1090_LE_NOVAMENTE_DB_CLOSE_1()
        {
            /*" -4823- EXEC SQL CLOSE DOCUMENTOS END-EXEC */

            DOCUMENTOS.Close();

        }

        [StopWatch]
        /*" R1090-LE-NOVAMENTE-DB-INSERT-1 */
        public void R1090_LE_NOVAMENTE_DB_INSERT_1()
        {
            /*" -4879- EXEC SQL INSERT INTO SEGUROS.SINI_LOT_DOC01 ( NUM_APOL_SINISTRO ,COD_DOCUMENTO ,DATA_RECEBE ,TMSP_MOV_RECEBE ,CODUSU_RECEBE ,DATA_SOLICITA ,TMSP_MOV_SOLICITA ,CODUSU_SOLICITA ,SITUACAO ,TMSP_MOV_SITUACAO ,CODUSU_SITUACAO ,TIMESTAMP ) VALUES (:SINLOTDO-NUM-APOL-SINISTRO ,:SINLOTDO-COD-DOCUMENTO ,:SINLOTDO-DATA-RECEBE , CURRENT TIMESTAMP ,:SINLOTDO-CODUSU-RECEBE ,:SINLOTDO-DATA-SOLICITA ,:SINLOTDO-TMSP-MOV-SOLICITA ,:SINLOTDO-CODUSU-SOLICITA ,:SINLOTDO-SITUACAO ,:SINLOTDO-TMSP-MOV-SITUACAO ,:SINLOTDO-CODUSU-SITUACAO , CURRENT TIMESTAMP ) END-EXEC. */

            var r1090_LE_NOVAMENTE_DB_INSERT_1_Insert1 = new R1090_LE_NOVAMENTE_DB_INSERT_1_Insert1()
            {
                SINLOTDO_NUM_APOL_SINISTRO = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_NUM_APOL_SINISTRO.ToString(),
                SINLOTDO_COD_DOCUMENTO = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_COD_DOCUMENTO.ToString(),
                SINLOTDO_DATA_RECEBE = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_DATA_RECEBE.ToString(),
                SINLOTDO_CODUSU_RECEBE = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_RECEBE.ToString(),
                SINLOTDO_DATA_SOLICITA = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_DATA_SOLICITA.ToString(),
                SINLOTDO_TMSP_MOV_SOLICITA = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_SOLICITA.ToString(),
                SINLOTDO_CODUSU_SOLICITA = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_SOLICITA.ToString(),
                SINLOTDO_SITUACAO = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_SITUACAO.ToString(),
                SINLOTDO_TMSP_MOV_SITUACAO = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_SITUACAO.ToString(),
                SINLOTDO_CODUSU_SITUACAO = SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_CODUSU_SITUACAO.ToString(),
            };

            R1090_LE_NOVAMENTE_DB_INSERT_1_Insert1.Execute(r1090_LE_NOVAMENTE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1090_EXIT*/

        [StopWatch]
        /*" R2000-ADIANT-PENDENTES */
        private void R2000_ADIANT_PENDENTES(bool isPerform = false)
        {
            /*" -4905- PERFORM R2010-DECLARE-ADIANT-PENDENTES THRU R2010-EXIT. */

            R2010_DECLARE_ADIANT_PENDENTES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/


            /*" -4907- MOVE 'NAO' TO WFIM-ADIANT-PENDENTES. */
            _.Move("NAO", AREA_DE_WORK.WFIM_ADIANT_PENDENTES);

            /*" -4909- PERFORM R2011-FETCH-ADIANT-PENDENTES THRU R2011-EXIT. */

            R2011_FETCH_ADIANT_PENDENTES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2011_EXIT*/


            /*" -4910- PERFORM R2020-PCS-ADIANT-PENDENTES THRU R2020-EXIT UNTIL (WFIM-ADIANT-PENDENTES EQUAL 'SIM' ). */

            while (!((AREA_DE_WORK.WFIM_ADIANT_PENDENTES == "SIM")))
            {

                R2020_PCS_ADIANT_PENDENTES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/

        [StopWatch]
        /*" R2010-DECLARE-ADIANT-PENDENTES */
        private void R2010_DECLARE_ADIANT_PENDENTES(bool isPerform = false)
        {
            /*" -4920- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4945- PERFORM R2010_DECLARE_ADIANT_PENDENTES_DB_DECLARE_1 */

            R2010_DECLARE_ADIANT_PENDENTES_DB_DECLARE_1();

            /*" -4949- PERFORM R2010_DECLARE_ADIANT_PENDENTES_DB_OPEN_1 */

            R2010_DECLARE_ADIANT_PENDENTES_DB_OPEN_1();

            /*" -4952- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4953- DISPLAY 'ERRO OPEN CURSOR ADIANT_PEND' */
                _.Display($"ERRO OPEN CURSOR ADIANT_PEND");

                /*" -4954- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -4954- END-IF. */
            }


        }

        [StopWatch]
        /*" R2010-DECLARE-ADIANT-PENDENTES-DB-OPEN-1 */
        public void R2010_DECLARE_ADIANT_PENDENTES_DB_OPEN_1()
        {
            /*" -4949- EXEC SQL OPEN ADIANT_PEND END-EXEC. */

            ADIANT_PEND.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/

        [StopWatch]
        /*" R2011-FETCH-ADIANT-PENDENTES */
        private void R2011_FETCH_ADIANT_PENDENTES(bool isPerform = false)
        {
            /*" -4964- MOVE '2011' TO WNR-EXEC-SQL. */
            _.Move("2011", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -4973- PERFORM R2011_FETCH_ADIANT_PENDENTES_DB_FETCH_1 */

            R2011_FETCH_ADIANT_PENDENTES_DB_FETCH_1();

            /*" -4976- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -4978- MOVE 'SIM' TO W-CHAVE-TEM-ADIANT-PENDENTE. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_ADIANT_PENDENTE);
            }


            /*" -4979- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -4980- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -4981- MOVE 'SIM' TO WFIM-ADIANT-PENDENTES */
                    _.Move("SIM", AREA_DE_WORK.WFIM_ADIANT_PENDENTES);

                    /*" -4983- PERFORM R2011_FETCH_ADIANT_PENDENTES_DB_CLOSE_1 */

                    R2011_FETCH_ADIANT_PENDENTES_DB_CLOSE_1();

                    /*" -4985- IF SQLCODE NOT EQUAL ZERO */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4986- DISPLAY 'ERRO CLOSE CURSOR - ADIANT_PEND' */
                        _.Display($"ERRO CLOSE CURSOR - ADIANT_PEND");

                        /*" -4987- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO(); //GOTO
                        return;

                        /*" -4988- END-IF */
                    }


                    /*" -4989- ELSE */
                }
                else
                {


                    /*" -4990- DISPLAY 'ERRO SINISTRO_HISTORICO - ADIANT PEND......' */
                    _.Display($"ERRO SINISTRO_HISTORICO - ADIANT PEND......");

                    /*" -4991- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -4992- END-IF */
                }


                /*" -4992- END-IF. */
            }


        }

        [StopWatch]
        /*" R2011-FETCH-ADIANT-PENDENTES-DB-FETCH-1 */
        public void R2011_FETCH_ADIANT_PENDENTES_DB_FETCH_1()
        {
            /*" -4973- EXEC SQL FETCH ADIANT_PEND INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-VAL-OPERACAO, :SINILT01-COD-LOT-CEF, :CLIENTES-NOME-RAZAO, :HOST-VALOR-AVISADO, :SINISMES-DATA-OCORRENCIA, :SIMOLOT1-VALOR-INFORMADO END-EXEC. */

            if (ADIANT_PEND.Fetch())
            {
                _.Move(ADIANT_PEND.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(ADIANT_PEND.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(ADIANT_PEND.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(ADIANT_PEND.SINILT01_COD_LOT_CEF, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF);
                _.Move(ADIANT_PEND.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(ADIANT_PEND.HOST_VALOR_AVISADO, HOST_VALOR_AVISADO);
                _.Move(ADIANT_PEND.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(ADIANT_PEND.SIMOLOT1_VALOR_INFORMADO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO);
            }

        }

        [StopWatch]
        /*" R2011-FETCH-ADIANT-PENDENTES-DB-CLOSE-1 */
        public void R2011_FETCH_ADIANT_PENDENTES_DB_CLOSE_1()
        {
            /*" -4983- EXEC SQL CLOSE ADIANT_PEND END-EXEC */

            ADIANT_PEND.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2011_EXIT*/

        [StopWatch]
        /*" R2020-PCS-ADIANT-PENDENTES */
        private void R2020_PCS_ADIANT_PENDENTES(bool isPerform = false)
        {
            /*" -5005- MOVE '2020' TO WNR-EXEC-SQL. */
            _.Move("2020", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -5006- IF SINISHIS-DATA-MOVIMENTO NOT EQUAL W-DATA-ANTERIOR */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO != AREA_DE_WORK.W_DATA_ANTERIOR)
            {

                /*" -5007- MOVE SINISHIS-DATA-MOVIMENTO TO W-DATA-ANTERIOR */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, AREA_DE_WORK.W_DATA_ANTERIOR);

                /*" -5008- IF W-CONTA-LINHA-AVISOOK GREATER 60 */

                if (AREA_DE_WORK.W_CONTA_LINHA_AVISOOK > 60)
                {

                    /*" -5009- PERFORM R9005-IMPRIME-CABEC-AVISOOK THRU R9005-EXIT */

                    R9005_IMPRIME_CABEC_AVISOOK(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9005_EXIT*/


                    /*" -5010- END-IF */
                }


                /*" -5012- MOVE 'ADIANTAMENTOS PENDENTES DE LIBERACAO DESDE - ' TO LD03-TITULO-1 */
                _.Move("ADIANTAMENTOS PENDENTES DE LIBERACAO DESDE - ", AREA_DE_WORK.LD03.LD03_AAAA.LD03_TITULO_1);

                /*" -5013- MOVE SINISHIS-DATA-MOVIMENTO TO W-DATA-AAAA-MM-DD */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

                /*" -5014- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

                /*" -5015- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

                /*" -5016- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
                _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

                /*" -5017- MOVE W-DATA-DD-MM-AAAA TO LD03-DATA-TITULO-1 */
                _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD03.LD03_AAAA.LD03_DATA_TITULO_1);

                /*" -5018- WRITE REGISTRO-AVISOOK FROM LD03 AFTER 2 */
                _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REGISTRO_AVISOOK);

                RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

                /*" -5019- MOVE SPACES TO LD03-AAAA */
                _.Move("", AREA_DE_WORK.LD03.LD03_AAAA);

                /*" -5020- WRITE REGISTRO-AVISOOK FROM LC-BRANCO AFTER 2 */
                _.Move(AREA_DE_WORK.LC_BRANCO.GetMoveValues(), REGISTRO_AVISOOK);

                RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

                /*" -5022- ADD 4 TO W-CONTA-LINHA-AVISOOK. */
                AREA_DE_WORK.W_CONTA_LINHA_AVISOOK.Value = AREA_DE_WORK.W_CONTA_LINHA_AVISOOK + 4;
            }


            /*" -5023- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD02-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.LD02.LD02_NUM_APOL_SINISTRO);

            /*" -5024- MOVE SINILT01-COD-LOT-CEF TO LD02-COD-LOT-CEF */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, AREA_DE_WORK.LD02.LD02_COD_LOT_CEF);

            /*" -5025- MOVE CLIENTES-NOME-RAZAO TO LD02-NOME */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LD02.LD02_NOME);

            /*" -5026- MOVE SINISMES-DATA-OCORRENCIA TO W-DATA-AAAA-MM-DD */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -5027- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -5028- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -5029- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -5030- MOVE W-DATA-DD-MM-AAAA TO LD02-DATA-OCORRENCIA */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD02.LD02_DATA_OCORRENCIA);

            /*" -5031- MOVE SIMOLOT1-VALOR-INFORMADO TO LD02-VALOR-INFORMADO */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO, AREA_DE_WORK.LD02.LD02_VALOR_INFORMADO);

            /*" -5032- MOVE HOST-VALOR-AVISADO TO LD02-VALOR-REGISTRADO */
            _.Move(HOST_VALOR_AVISADO, AREA_DE_WORK.LD02.LD02_VALOR_REGISTRADO);

            /*" -5034- MOVE SINISHIS-VAL-OPERACAO TO LD02-VALOR-ADIANTAMENTO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.LD02.LD02_VALOR_ADIANTAMENTO);

            /*" -5041- MOVE SPACES TO LD02-MENSAGEM. */
            _.Move("", AREA_DE_WORK.LD02.LD02_MENSAGEM);

            /*" -5042- IF W-CONTA-LINHA-AVISOOK GREATER 60 */

            if (AREA_DE_WORK.W_CONTA_LINHA_AVISOOK > 60)
            {

                /*" -5044- PERFORM R9005-IMPRIME-CABEC-AVISOOK THRU R9005-EXIT. */

                R9005_IMPRIME_CABEC_AVISOOK(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9005_EXIT*/

            }


            /*" -5045- WRITE REGISTRO-AVISOOK FROM LD02 AFTER 2. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -5047- ADD 2 TO W-CONTA-LINHA-AVISOOK. */
            AREA_DE_WORK.W_CONTA_LINHA_AVISOOK.Value = AREA_DE_WORK.W_CONTA_LINHA_AVISOOK + 2;

            /*" -5047- PERFORM R2011-FETCH-ADIANT-PENDENTES THRU R2011-EXIT. */

            R2011_FETCH_ADIANT_PENDENTES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2011_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_EXIT*/

        [StopWatch]
        /*" R9000-CABECALHO-CRITICA */
        private void R9000_CABECALHO_CRITICA(bool isPerform = false)
        {
            /*" -5057- IF W-CONTA-LINHA GREATER 60 */

            if (AREA_DE_WORK.W_CONTA_LINHA > 60)
            {

                /*" -5059- ADD 1 TO W-CONTA-PAGINA. */
                AREA_DE_WORK.W_CONTA_PAGINA.Value = AREA_DE_WORK.W_CONTA_PAGINA + 1;
            }


            /*" -5060- MOVE W-CONTA-PAGINA TO LC01-PAGINA. */
            _.Move(AREA_DE_WORK.W_CONTA_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -5061- MOVE 8 TO W-CONTA-LINHA. */
            _.Move(8, AREA_DE_WORK.W_CONTA_LINHA);

            /*" -5062- WRITE REGISTRO-CRITICA FROM LC01 AFTER PAGE. */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REGISTRO_CRITICA);

            RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

            /*" -5063- WRITE REGISTRO-CRITICA FROM LC02 AFTER 1. */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REGISTRO_CRITICA);

            RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

            /*" -5064- WRITE REGISTRO-CRITICA FROM LC02-A AFTER 1. */
            _.Move(AREA_DE_WORK.LC02_A.GetMoveValues(), REGISTRO_CRITICA);

            RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

            /*" -5065- WRITE REGISTRO-CRITICA FROM LC03 AFTER 1. */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REGISTRO_CRITICA);

            RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

            /*" -5065- WRITE REGISTRO-CRITICA FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REGISTRO_CRITICA);

            RCRITICA.Write(REGISTRO_CRITICA.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_EXIT*/

        [StopWatch]
        /*" R7000-00-TRATAR-PEP-SECTION */
        private void R7000_00_TRATAR_PEP_SECTION()
        {
            /*" -5090- PERFORM R7019-00-BUSCAR-COD-SOCIO THRU R7019-99-SAIDA */

            R7019_00_BUSCAR_COD_SOCIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R7019_99_SAIDA*/


            /*" -5092- IF WS-ERRO EQUAL ZEROS */

            if (AREA_DE_WORK.WABEND.WABEND1.WS_ERRO == 00)
            {

                /*" -5094- PERFORM R7020-00-BUSCAR-DADOS-PESSOA THRU R7020-99-SAIDA */

                R7020_00_BUSCAR_DADOS_PESSOA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7020_99_SAIDA*/


                /*" -5098- IF WS-ERRO EQUAL ZEROS */

                if (AREA_DE_WORK.WABEND.WABEND1.WS_ERRO == 00)
                {

                    /*" -5099- PERFORM R7030-00-CONSULTAR-PEP THRU R7030-99-SAIDA */

                    R7030_00_CONSULTAR_PEP_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7030_99_SAIDA*/


                    /*" -5100- END-IF */
                }


                /*" -5103- END-IF */
            }


            /*" -5103- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7019-00-BUSCAR-COD-SOCIO-SECTION */
        private void R7019_00_BUSCAR_COD_SOCIO_SECTION()
        {
            /*" -5112- MOVE '7019' TO WNR-EXEC-SQL. */
            _.Move("7019", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -5114- MOVE ZEROS TO WS-ERRO. */
            _.Move(0, AREA_DE_WORK.WABEND.WABEND1.WS_ERRO);

            /*" -5116- INITIALIZE DCLLT-MOV-PROPOSTA */
            _.Initialize(
                LTMVPROP.DCLLT_MOV_PROPOSTA
            );

            /*" -5117- MOVE SPACES TO WS-COD-LOT-CEF */
            _.Move("", AREA_DE_WORK.WABEND.WABEND1.WS_COD_LOT_CEF);

            /*" -5119- MOVE ZEROS TO WS-COD-LOT-CEF-NUMERIC */
            _.Move(0, AREA_DE_WORK.WABEND.WABEND1.WS_COD_LOT_CEF_REDF.WS_COD_LOT_CEF_NUMERIC);

            /*" -5120- MOVE AV-COD-LOT-CEF TO WS-COD-LOT-CEF */
            _.Move(REGISTRO_AVISO.AV_COD_LOT_CEF, AREA_DE_WORK.WABEND.WABEND1.WS_COD_LOT_CEF);

            /*" -5122- MOVE WS-COD-LOT-CEF-NUMERIC TO LTMVPROP-COD-EXT-SEGURADO */
            _.Move(AREA_DE_WORK.WABEND.WABEND1.WS_COD_LOT_CEF_REDF.WS_COD_LOT_CEF_NUMERIC, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO);

            /*" -5144- PERFORM R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1 */

            R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1();

            /*" -5147- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -5148- WHEN +000 */
                case +000:

                    /*" -5149- CONTINUE */

                    /*" -5150- WHEN OTHER */
                    break;
                default:

                    /*" -5151- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

                    /*" -5153- DISPLAY 'SI0005B - ERRO NA CONSULTA DO CODIGO DO ' 'SOCIO NAO GRAVA LOG - PEPS :' WSQLCODE */

                    $"SI0005B - ERRO NA CONSULTA DO CODIGO DO SOCIO NAO GRAVA LOG - PEPS :{AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}"
                    .Display();

                    /*" -5154- MOVE 1 TO WS-ERRO */
                    _.Move(1, AREA_DE_WORK.WABEND.WABEND1.WS_ERRO);

                    /*" -5156- END-EVALUATE */
                    break;
            }


            /*" -5156- . */

        }

        [StopWatch]
        /*" R7019-00-BUSCAR-COD-SOCIO-DB-SELECT-1 */
        public void R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1()
        {
            /*" -5144- EXEC SQL SELECT A.COD_EXT_SEGURADO , A.COD_PESSOA_SOCIO , A.NUM_PROPOSTA , A.COD_FONTE INTO :LTMVPROP-COD-EXT-SEGURADO ,:LTMVPROP-COD-PESSOA-SOCIO ,:LTMVPROP-NUM-PROPOSTA ,:LTMVPROP-COD-FONTE FROM SEGUROS.LT_MOV_PROPOSTA A ,SEGUROS.ENDOSSOS B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_PROPOSTA = B.NUM_PROPOSTA AND A.COD_EXT_SEGURADO = :LTMVPROP-COD-EXT-SEGURADO AND B.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND :SISTEMAS-DATA-MOV-ABERTO BETWEEN B.DATA_INIVIGENCIA AND B.DATA_TERVIGENCIA AND B.NUM_ENDOSSO = 0 ORDER BY A.DATA_MOVIMENTO DESC FETCH FIRST ROWS ONLY WITH UR END-EXEC */

            var r7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1 = new R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1()
            {
                LTMVPROP_COD_EXT_SEGURADO = LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1.Execute(r7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPROP_COD_EXT_SEGURADO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO);
                _.Move(executed_1.LTMVPROP_COD_PESSOA_SOCIO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_PESSOA_SOCIO);
                _.Move(executed_1.LTMVPROP_NUM_PROPOSTA, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA);
                _.Move(executed_1.LTMVPROP_COD_FONTE, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7019_99_SAIDA*/

        [StopWatch]
        /*" R7020-00-BUSCAR-DADOS-PESSOA-SECTION */
        private void R7020_00_BUSCAR_DADOS_PESSOA_SECTION()
        {
            /*" -5166- MOVE '7020' TO WNR-EXEC-SQL. */
            _.Move("7020", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -5168- MOVE ZEROS TO WS-ERRO. */
            _.Move(0, AREA_DE_WORK.WABEND.WABEND1.WS_ERRO);

            /*" -5170- INITIALIZE DCLGE-PESSOA DCLGE-PESSOA-JURIDICA */
            _.Initialize(
                GEPESSOA.DCLGE_PESSOA
                , GEPESJUR.DCLGE_PESSOA_JURIDICA
            );

            /*" -5171- IF LTMVPROP-COD-PESSOA-SOCIO LESS OR EQUAL ZEROS */

            if (LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_PESSOA_SOCIO <= 00)
            {

                /*" -5172- DISPLAY 'CODIGO DO SOCIO DA PROPOSTA - INVALIDO' */
                _.Display($"CODIGO DO SOCIO DA PROPOSTA - INVALIDO");

                /*" -5173- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -5175- DISPLAY 'LTMVPROP-COD-PESSOA-SOCIO..: ' LTMVPROP-COD-PESSOA-SOCIO */
                _.Display($"LTMVPROP-COD-PESSOA-SOCIO..: {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_PESSOA_SOCIO}");

                /*" -5177- DISPLAY 'NUM-PROPOSTA...............: ' LTMVPROP-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA...............: {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA}");

                /*" -5178- MOVE 1 TO WS-ERRO */
                _.Move(1, AREA_DE_WORK.WABEND.WABEND1.WS_ERRO);

                /*" -5179- GO TO R7020-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7020_99_SAIDA*/ //GOTO
                return;

                /*" -5181- END-IF */
            }


            /*" -5182- MOVE ZEROS TO GEPESSOA-COD-PESSOA */
            _.Move(0, GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA);

            /*" -5184- MOVE LTMVPROP-COD-PESSOA-SOCIO TO GEPESSOA-COD-PESSOA */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_PESSOA_SOCIO, GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA);

            /*" -5194- PERFORM R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1 */

            R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1();

            /*" -5198- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -5199- WHEN +0 */
                case +0:

                    /*" -5200- CONTINUE */

                    /*" -5201- WHEN +100 */
                    break;
                case +100:

                    /*" -5204- DISPLAY 'Consulta do socio-segurado na GE_PESSOA:' ' ' GEPESSOA-COD-PESSOA ' - Nao localizado ou nao cadastrado!!!' */

                    $"Consulta do socio-segurado na GE_PESSOA: {GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA} - Nao localizado ou nao cadastrado!!!"
                    .Display();

                    /*" -5205- MOVE 1 TO WS-ERRO */
                    _.Move(1, AREA_DE_WORK.WABEND.WABEND1.WS_ERRO);

                    /*" -5206- WHEN OTHER */
                    break;
                default:

                    /*" -5208- DISPLAY 'Erro select GE_PESSOA e GE_PESSOA_JUR - ' 'SQLCODE : ' SQLCODE */

                    $"Erro select GE_PESSOA e GE_PESSOA_JUR - SQLCODE : {DB.SQLCODE}"
                    .Display();

                    /*" -5209- MOVE 1 TO WS-ERRO */
                    _.Move(1, AREA_DE_WORK.WABEND.WABEND1.WS_ERRO);

                    /*" -5217- END-EVALUATE */
                    break;
            }


            /*" -5217- . */

        }

        [StopWatch]
        /*" R7020-00-BUSCAR-DADOS-PESSOA-DB-SELECT-1 */
        public void R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1()
        {
            /*" -5194- EXEC SQL SELECT B.NUM_CNPJ ,B.NOM_FANTASIA INTO :GEPESJUR-NUM-CNPJ ,:GEPESJUR-NOM-FANTASIA FROM SEGUROS.GE_PESSOA A INNER JOIN SEGUROS.GE_PESSOA_JURIDICA B ON A.COD_PESSOA = B.COD_PESSOA WHERE B.COD_PESSOA = :GEPESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1 = new R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1()
            {
                GEPESSOA_COD_PESSOA = GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1.Execute(r7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEPESJUR_NUM_CNPJ, GEPESJUR.DCLGE_PESSOA_JURIDICA.GEPESJUR_NUM_CNPJ);
                _.Move(executed_1.GEPESJUR_NOM_FANTASIA, GEPESJUR.DCLGE_PESSOA_JURIDICA.GEPESJUR_NOM_FANTASIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7020_99_SAIDA*/

        [StopWatch]
        /*" R7030-00-CONSULTAR-PEP-SECTION */
        private void R7030_00_CONSULTAR_PEP_SECTION()
        {
            /*" -5230- MOVE '7030' TO WNR-EXEC-SQL. */
            _.Move("7030", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -5232- INITIALIZE LK-GE0530 */
            _.Initialize(
                LBGE0530.LK_GE0530
            );

            /*" -5233- MOVE 'LT2' TO LK-GE0530-FUNCAO */
            _.Move("LT2", LBGE0530.LK_GE0530.LK_GE0530_FUNCAO);

            /*" -5234- MOVE GEPESJUR-NUM-CNPJ TO LK-GE0530-CPF-CNPJ */
            _.Move(GEPESJUR.DCLGE_PESSOA_JURIDICA.GEPESJUR_NUM_CNPJ, LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ);

            /*" -5235- MOVE GEPESJUR-NOM-FANTASIA TO LK-GE0530-NOME-PESSOA */
            _.Move(GEPESJUR.DCLGE_PESSOA_JURIDICA.GEPESJUR_NOM_FANTASIA, LBGE0530.LK_GE0530.LK_GE0530_NOME_PESSOA);

            /*" -5236- MOVE 18 TO LK-GE0530-NUM-RAMO-EMISSOR */
            _.Move(18, LBGE0530.LK_GE0530.LK_GE0530_NUM_RAMO_EMISSOR);

            /*" -5237- MOVE SINISHIS-COD-PRODUTO TO LK-GE0530-COD-PRODUTO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, LBGE0530.LK_GE0530.LK_GE0530_COD_PRODUTO);

            /*" -5238- MOVE LTMVPROP-COD-FONTE TO LK-GE0530-COD-FONTE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_FONTE, LBGE0530.LK_GE0530.LK_GE0530_COD_FONTE);

            /*" -5239- MOVE LTMVPROP-NUM-PROPOSTA TO LK-GE0530-NUM-PROPOSTA */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA, LBGE0530.LK_GE0530.LK_GE0530_NUM_PROPOSTA);

            /*" -5240- MOVE LTMVPROP-COD-EXT-SEGURADO TO LK-GE0530-NUM-CERTIFIC-EXT */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBGE0530.LK_GE0530.LK_GE0530_NUM_CERTIFIC_EXT);

            /*" -5241- MOVE SINISHIS-NUM-APOLICE TO LK-GE0530-NUM-APOLICE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, LBGE0530.LK_GE0530.LK_GE0530_NUM_APOLICE);

            /*" -5242- MOVE 0 TO LK-GE0530-NUM-ENDOSSO */
            _.Move(0, LBGE0530.LK_GE0530.LK_GE0530_NUM_ENDOSSO);

            /*" -5243- MOVE SINISHIS-NUM-APOL-SINISTRO TO LK-GE0530-NUM-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LBGE0530.LK_GE0530.LK_GE0530_NUM_SINISTRO);

            /*" -5244- MOVE SINISHIS-OCORR-HISTORICO TO LK-GE0530-OCORR-HISTORICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, LBGE0530.LK_GE0530.LK_GE0530_OCORR_HISTORICO);

            /*" -5245- MOVE SINISHIS-COD-OPERACAO TO LK-GE0530-COD-OPER-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, LBGE0530.LK_GE0530.LK_GE0530_COD_OPER_SINISTRO);

            /*" -5247- MOVE 'SI0005B' TO LK-GE0530-NOM-PRG-SOLICITA */
            _.Move("SI0005B", LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA);

            /*" -5248- DISPLAY '** DADOS PARA CHAMAR GE0530S **' */
            _.Display($"** DADOS PARA CHAMAR GE0530S **");

            /*" -5249- DISPLAY 'SI0005B-FUNCAO        :' LK-GE0530-FUNCAO */
            _.Display($"SI0005B-FUNCAO        :{LBGE0530.LK_GE0530.LK_GE0530_FUNCAO}");

            /*" -5250- DISPLAY 'SI0005B-CPF-CNPJ      :' LK-GE0530-CPF-CNPJ */
            _.Display($"SI0005B-CPF-CNPJ      :{LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ}");

            /*" -5251- DISPLAY 'SI0005B-NOME-PESSOA   :' LK-GE0530-NOME-PESSOA */
            _.Display($"SI0005B-NOME-PESSOA   :{LBGE0530.LK_GE0530.LK_GE0530_NOME_PESSOA}");

            /*" -5252- DISPLAY 'SI0005B-NUM-RAMO-EMIS :' LK-GE0530-NUM-RAMO-EMISSOR */
            _.Display($"SI0005B-NUM-RAMO-EMIS :{LBGE0530.LK_GE0530.LK_GE0530_NUM_RAMO_EMISSOR}");

            /*" -5253- DISPLAY 'SI0005B-COD-PRODUTO   :' LK-GE0530-COD-PRODUTO */
            _.Display($"SI0005B-COD-PRODUTO   :{LBGE0530.LK_GE0530.LK_GE0530_COD_PRODUTO}");

            /*" -5254- DISPLAY 'SI0005B-COD-FONTE     :' LK-GE0530-COD-FONTE */
            _.Display($"SI0005B-COD-FONTE     :{LBGE0530.LK_GE0530.LK_GE0530_COD_FONTE}");

            /*" -5255- DISPLAY 'SI0005B-NUM-PROPOSTA  :' LK-GE0530-NUM-PROPOSTA */
            _.Display($"SI0005B-NUM-PROPOSTA  :{LBGE0530.LK_GE0530.LK_GE0530_NUM_PROPOSTA}");

            /*" -5256- DISPLAY 'SI0005B-NUM-CERTIFIC- :' LK-GE0530-NUM-CERTIFIC-EXT */
            _.Display($"SI0005B-NUM-CERTIFIC- :{LBGE0530.LK_GE0530.LK_GE0530_NUM_CERTIFIC_EXT}");

            /*" -5257- DISPLAY 'SI0005B-NUM-APOLICE   :' LK-GE0530-NUM-APOLICE */
            _.Display($"SI0005B-NUM-APOLICE   :{LBGE0530.LK_GE0530.LK_GE0530_NUM_APOLICE}");

            /*" -5258- DISPLAY 'SI0005B-NUM-ENDOSSO   :' LK-GE0530-NUM-ENDOSSO */
            _.Display($"SI0005B-NUM-ENDOSSO   :{LBGE0530.LK_GE0530.LK_GE0530_NUM_ENDOSSO}");

            /*" -5259- DISPLAY 'SI0005B-NUM-SINISTRO  :' LK-GE0530-NUM-SINISTRO */
            _.Display($"SI0005B-NUM-SINISTRO  :{LBGE0530.LK_GE0530.LK_GE0530_NUM_SINISTRO}");

            /*" -5260- DISPLAY 'SI0005B-OCORR-HISTORI :' LK-GE0530-OCORR-HISTORICO */
            _.Display($"SI0005B-OCORR-HISTORI :{LBGE0530.LK_GE0530.LK_GE0530_OCORR_HISTORICO}");

            /*" -5261- DISPLAY 'SI0005B-COD-OPER-SINI :' LK-GE0530-COD-OPER-SINISTRO */
            _.Display($"SI0005B-COD-OPER-SINI :{LBGE0530.LK_GE0530.LK_GE0530_COD_OPER_SINISTRO}");

            /*" -5264- DISPLAY 'SI0005B-NOM-PRG-SOLIC :' LK-GE0530-NOM-PRG-SOLICITA */
            _.Display($"SI0005B-NOM-PRG-SOLIC :{LBGE0530.LK_GE0530.LK_GE0530_NOM_PRG_SOLICITA}");

            /*" -5266- CALL WS-GE0530S USING LK-GE0530. */
            _.Call(AREA_DE_WORK.WABEND.WABEND1.WS_GE0530S, LBGE0530.LK_GE0530);

            /*" -5268- DISPLAY 'COD-RETORNO-GE0530S :' LK-GE0530-COD-RETORNO */
            _.Display($"COD-RETORNO-GE0530S :{LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO}");

            /*" -5269- IF LK-GE0530-COD-RETORNO NOT EQUAL ZEROS */

            if (LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO != 00)
            {

                /*" -5274- DISPLAY ' R7030-LOT  =' LTMVPROP-COD-EXT-SEGURADO ' CPF        =' LK-GE0530-CPF-CNPJ ' COD-RETORNO=' LK-GE0530-COD-RETORNO ' MSG-RETORNO=' LK-GE0530-MSG-RETORNO ' ERRO GE0530S - SELECT PEP.' */

                $" R7030-LOT  ={LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO} CPF        ={LBGE0530.LK_GE0530.LK_GE0530_CPF_CNPJ} COD-RETORNO={LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO} MSG-RETORNO={LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_MSG_RETORNO} ERRO GE0530S - SELECT PEP."
                .Display();

                /*" -5275- ELSE */
            }
            else
            {


                /*" -5276- ADD 1 TO WS-CONT-PEPS */
                AREA_DE_WORK.WABEND.WABEND1.WS_CONT_PEPS.Value = AREA_DE_WORK.WABEND.WABEND1.WS_CONT_PEPS + 1;

                /*" -5277- DISPLAY 'WS-CONT-PEPS :' WS-CONT-PEPS */
                _.Display($"WS-CONT-PEPS :{AREA_DE_WORK.WABEND.WABEND1.WS_CONT_PEPS}");

                /*" -5279- END-IF */
            }


            /*" -5279- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7030_99_SAIDA*/

        [StopWatch]
        /*" R9005-IMPRIME-CABEC-AVISOOK */
        private void R9005_IMPRIME_CABEC_AVISOOK(bool isPerform = false)
        {
            /*" -5288- ADD 1 TO W-CONTA-PAGINA-AVISOOK. */
            AREA_DE_WORK.W_CONTA_PAGINA_AVISOOK.Value = AREA_DE_WORK.W_CONTA_PAGINA_AVISOOK + 1;

            /*" -5289- MOVE W-CONTA-PAGINA-AVISOOK TO LC01-X-PAGINA. */
            _.Move(AREA_DE_WORK.W_CONTA_PAGINA_AVISOOK, AREA_DE_WORK.LC01_X.LC01_X_PAGINA);

            /*" -5290- MOVE 8 TO W-CONTA-LINHA-AVISOOK. */
            _.Move(8, AREA_DE_WORK.W_CONTA_LINHA_AVISOOK);

            /*" -5291- WRITE REGISTRO-AVISOOK FROM LC01-X AFTER PAGE. */
            _.Move(AREA_DE_WORK.LC01_X.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -5292- WRITE REGISTRO-AVISOOK FROM LC02 AFTER 1. */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -5293- WRITE REGISTRO-AVISOOK FROM LC02-A AFTER 1. */
            _.Move(AREA_DE_WORK.LC02_A.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -5294- WRITE REGISTRO-AVISOOK FROM LC03-X AFTER 1. */
            _.Move(AREA_DE_WORK.LC03_X.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -5295- WRITE REGISTRO-AVISOOK FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -5296- WRITE REGISTRO-AVISOOK FROM LC05 AFTER 1. */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

            /*" -5296- WRITE REGISTRO-AVISOOK FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REGISTRO_AVISOOK);

            RAVISOOK.Write(REGISTRO_AVISOOK.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9005_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -5307- CLOSE AVISO RETORNO RAVISOOK RCRITICA. */
            AVISO.Close();
            RETORNO.Close();
            RAVISOOK.Close();
            RCRITICA.Close();

            /*" -5309- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -5310- DISPLAY ' ' */
            _.Display($" ");

            /*" -5311- DISPLAY ' ' */
            _.Display($" ");

            /*" -5312- DISPLAY ' ' */
            _.Display($" ");

            /*" -5313- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -5314- DISPLAY ' ' */
            _.Display($" ");

            /*" -5315- DISPLAY ' ' */
            _.Display($" ");

            /*" -5316- DISPLAY ' ' */
            _.Display($" ");

            /*" -5317- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -5318- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2);

            /*" -5320- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -5320- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -5321- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5325- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -5325- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/
    }
}