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
using Sias.VidaAzul.DB2.VA2601B;

namespace Code
{
    public class VA2601B
    {
        public bool IsCall { get; set; }

        public VA2601B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  INTEGRA SISPF E SIAS PARA OS       *      */
        /*"      *                             PRODUTOS DE VIDA PESSOA FISICA     *      */
        /*"      *                             NA OPERACAO DE TELESUBCRICAO       *      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO.....  EDIVALDO GOMES (FAST COMPUTER)     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA2601B                            *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ORIGEM ........  VA0601B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  30/05/2011                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 - SOL  330882                                      *      */
        /*"      *             - REVISAO PARA ERRO 1864 POR CONTER VARIOS ERROS   *      */
        /*"      *               ENVOLVIDOS, DEIXANDO DUVIDA PARA O USUARIO.      *      */
        /*"      *             - A BU VALIDOU A SOLUCAO IMPLEMENTADA.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/03/2022 - FELIPE LARA                                  *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22B *VERSAO V.22B-DEMANDA 295632-KINKAS 24/08/2021-ALTERA LIMITES    *      */
        /*"      *            LIMITE ISS                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO V.22-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO 21: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"      *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"      *           - PROCURAR POR JV121                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20 - HIST 193616                                      *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/03/2019 - ANDR�S RIERA (ALTRAN)                        *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - HIS  13.055                                      *      */
        /*"      *             - REVISAO PARA ERRO DPS DECLINAR PROPOSTA, AQUI OU *      */
        /*"      *               AP�S ANALISE BU.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/03/2018 - HERVAL SOUZA                                 *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - CAD 153.153                                      *      */
        /*"      *             - INCLUIR SITUACOES AO CALCULO DE LIMITE DE RISCO. *      */
        /*"      *               'E' - AGUARDANDO CRIVO                           *      */
        /*"      *               '8' - ACEITA-AGUARDANDO PAGAMENTO DA 1a PARCELA  *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/08/2017 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 - CAD 149.441                                      *      */
        /*"      *             - INCLUIR NOVOS INDICADORES DE TIPO PROPOSTA.      *      */
        /*"      *               'D' - PROPOSTA ASSINADAS DIGITALMENTE            *      */
        /*"      *               'E' - PROPOSTA ASSINADAS DIGITALMENTE POR E-MAIL *      */
        /*"      *               'S' - PROPOSTA ASSINADAS DIGITALMENTE POR SMS    *      */
        /*"      *               'NULO' - PROPOSTA ASSINADAS MANUALMENTE          *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/03/2017 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - CAD 147.155 - PERMITIR A VENDA DE PRODUTOS PARA  *      */
        /*"      *               O CPF 000.000.371-92.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/03/2017 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15   CAD 140.553 - DOCYOUSIGN                         *      */
        /*"      *                                                                *      */
        /*"      *       - NAO CRIAR ERRO 1800 - AGUARDANDO PROPOSTA FISICA PARA  *      */
        /*"      *         AS PROPOSTAS COMERCIALIZADAS E ENVIADAS DIGITALMENTE.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/08/2016 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14   CAD 137.226                                      *      */
        /*"      *                                                                *      */
        /*"      *       - INSERIR A DATA DE DECL�NIO QUANDO O CERTIFICADO FOR    *      */
        /*"      *         DECLINADO (STATUS = 2).                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/08/2016 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13   CAD 140.623                                      *      */
        /*"      *                                                                *      */
        /*"      *       - RETIRADA DA ATUALIZACAO DA TABELA PROPOSTAS_FIDELIZ    *      */
        /*"      *         NAO ALTERAR A AGENCIA QUE CHEGA NO ARQUIVO DO RCAP,    *      */
        /*"      *         MANTER A AGENCIA ATUAL.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/08/2016 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12   CAD 136.363                                      *      */
        /*"      *                                                                *      */
        /*"      *       - ALTERA��O DA FAIXA DE RENDA PARA TODOS OS CERTIFICADOS *      */
        /*"      *         DO PRODUTO VIDA EXCLUSIVO.                             *      */
        /*"      *         AS FAIXAS DE RENDA (INDIVIDUAL E FAMILIAR) SER�O CONSI-*      */
        /*"      *         RADAS COMO FAIXA 05.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/05/2016 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *   VERSAO 11 - CAD 135.713                                      *      */
        /*"      *                                                                *      */
        /*"      *       - TRATAR PROFISSAO QUE ESTA SENDO GRAVADO EM BRANCO NA   *      */
        /*"      *         PROPOSTA_VA                                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/05/2016 - THIAGO BLAIER                                *      */
        /*"      *                                           PROCURE POR V.11     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 127.190                                      *      */
        /*"      *                                                                *      */
        /*"      *       - CORRE��O PARA QUE TODAS AS PROPOSTAS DECLINADAS, QUE   *      */
        /*"      *         POSSUAM CONTA INFORMADA, TENHAM SUAS CONTAS REGISTRADAS*      */
        /*"      *         NA TABELA RELATORIO PARA QUE O PGM VA0469B EFETUE A    *      */
        /*"      *         DEVOLUCAO DA PARCELA ADESAO                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/02/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                           PROCURE POR V.08     *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 124.821                                      *      */
        /*"      *           - AJUSTE NA VALIDACAO DE VIGENCIA DAS PROPOSTAS.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/11/2015 -  LUIGI CONTE    (INDRA COMPANY)              *      */
        /*"      *                                           PROCURE POR V.07     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 123.147                                      *      */
        /*"      *           - ALTERAR VALIDACOES DE DADOS CADASTRAIS DO CLIENTE. *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/10/2015 -  FRANK CARVALHO (INDRA COMPANY)              *      */
        /*"      *                                           PROCURE POR V.06     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 99.439                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CORRECAO DA QUERY QUE EST� PENGANDO RAMO 29 COM  *      */
        /*"      *               PERIODO DE VIGENCIA VENCIDO                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/06/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 04 - CAD 10.003                                        *      */
        /*"      *                                                                *      */
        /*"      *             - CONVERSAO DO DB2 PARA A VERSAO 10                *      */
        /*"      *                                                                *      */
        /*"      *  EM 30/09/2013 -  ROGERIO PEREIRA                              *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE POR V.04     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CAD 67.646                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTA PARA TRATAR AS NOVAS APOLICES PARA OS    *      */
        /*"      *                PRODUTOS VIDA MULHER E MULTIPREMIADO SUPER.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/04/2012 - PEDRO SILVERIO (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.03      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CAD 65.201                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTA VALOR DO PREMIO.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/01/2012 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 201.104                                      *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTA SIT_REGISTRO PARA 7 NA PROPOSTA_VA       *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/06/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.01      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 00 - CAD 54.905                                       *      */
        /*"      *                                                                *      */
        /*"      *              - INTEGRA MOVIMENTOS ORIUNDOS DA CEF NA OPRACAO   *      */
        /*"      *                DE TELESUBCRICAO.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/05/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.00      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-CONTA-FONE           PIC S9(04)    COMP    VALUE +0.*/
        public IntBasis WS_CONTA_FONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WS-NUM-PROPOSTA-AZUL    PIC S9(13)V   COMP-3  VALUE ZERO.*/
        public DoubleBasis WS_NUM_PROPOSTA_AZUL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77  COBERP-IMPMORNATU       PIC S9(13)V   COMP-3  VALUE ZERO.*/
        public DoubleBasis COBERP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77  WS-PREMIO-TOTAL         PIC S9(13)V99 COMP-3  VALUE ZERO.*/
        public DoubleBasis WS_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WS-PREMIO-TOTAL-AC      PIC S9(13)V99 COMP-3  VALUE ZERO.*/
        public DoubleBasis WS_PREMIO_TOTAL_AC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-BCO-RELAT         PIC S9(4)       USAGE COMP.*/
        public IntBasis WHOST_BCO_RELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WHOST-VLR-RELAT         PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis WHOST_VLR_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  WHOST-SIN-RELAT         PIC S9(15)V     USAGE COMP-3.*/
        public DoubleBasis WHOST_SIN_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  WHOST-DATA-AGENDAMENTO  PIC  X(10).*/
        public StringBasis WHOST_DATA_AGENDAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01    WS-HORAS.*/
        public VA2601B_WS_HORAS WS_HORAS { get; set; } = new VA2601B_WS_HORAS();
        public class VA2601B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA2601B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA2601B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA2601B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA2601B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VA2601B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA2601B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA2601B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA2601B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA2601B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VA2601B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VA2601B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA2601B_TOTAIS_ROT();
        public class VA2601B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 90 TIMES.*/
            public ListBasis<VA2601B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<VA2601B_FILLER_0>(90);
            public class VA2601B_FILLER_0 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01  WHOST-IMPMORNATU-MAX              PIC S9(013)V99 COMP-3.*/
            }
        }
        public DoubleBasis WHOST_IMPMORNATU_MAX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-IMPMORNATU                  PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-PREMIO-1                    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_PREMIO_1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-PREMIO-2                    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_PREMIO_2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-INFO-COMPL                  PIC  X(050).*/
        public StringBasis WHOST_INFO_COMPL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"01  WHOST-PROFISSAO                   PIC  X(020).*/
        public StringBasis WHOST_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WHOST-PROFISSAO-CONJUGE           PIC  X(020).*/
        public StringBasis WHOST_PROFISSAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WHOST-SIT-PROPOSTA                PIC  X(003).*/
        public StringBasis WHOST_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WHOST-SIT-ENVIO                   PIC  X(001).*/
        public StringBasis WHOST_SIT_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-SIT-REGISTRO                PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-STA-ANTECIPACAO             PIC  X(001).*/
        public StringBasis WHOST_STA_ANTECIPACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-OPCAOPAG                    PIC  X(001).*/
        public StringBasis WHOST_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-FONTE                       PIC S9(004)      COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-RAMO                        PIC S9(004)      COMP.*/
        public IntBasis WHOST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PROPAUTOM                   PIC S9(004)      COMP.*/
        public IntBasis WHOST_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-GRUPO-SUSEP                 PIC S9(004)      COMP.*/
        public IntBasis WHOST_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-COD-RAMO                    PIC S9(004)      COMP.*/
        public IntBasis WHOST_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PREMIO-CONJ                 PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WHOST_PREMIO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-TAXA-RAMO                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_TAXA_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-PERC-CDG                    PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERC_CDG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-PERC-DIT                    PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERC_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-DTPROXVEN                   PIC  X(010).*/
        public StringBasis WHOST_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PROPVA-NRCERTIF                   PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  WS-COUNT                          PIC S9(009) COMP VALUE +0.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-CONTA-BRC                      PIC  9(005) VALUE ZEROS.*/
        public IntBasis WS_CONTA_BRC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-POSICAO                        PIC  9(005) VALUE ZEROS.*/
        public IntBasis WS_POSICAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-SIGLA-UF                       PIC  X(002) VALUE SPACES.*/
        public StringBasis WS_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  WS-ENCONTROU-LETRA                PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_ENCONTROU_LETRA { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-ACHOU                    VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_ACHOU", "S"),
							/*" 88 WS-NAO-ACHOU                    VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_ACHOU", "N")
                }
        };

        /*"01  WS-INSERE-ANDAMENTO               PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_INSERE_ANDAMENTO { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-PROP-ELETRONICA              VALUE 'S'. */
							new SelectorItemBasis("WS_PROP_ELETRONICA", "S"),
							/*" 88 WS-NAO-PROP-ELETRONICA          VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_PROP_ELETRONICA", "N")
                }
        };

        /*"01  WS-TXT-PROP-ELETRONICA            PIC  X(049) VALUE        'PROPOSTA ELETRONICA COM ASSINATURA DIGITAL/TOKEN.'.*/
        public StringBasis WS_TXT_PROP_ELETRONICA { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"PROPOSTA ELETRONICA COM ASSINATURA DIGITAL/TOKEN.");
        /*"01  WS-TXT-PROP-ELETRONICA-EMAIL      PIC  X(055) VALUE        'PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR E-MAIL'.*/
        public StringBasis WS_TXT_PROP_ELETRONICA_EMAIL { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR E-MAIL");
        /*"01  WS-TXT-PROP-ELETRONICA-SMS        PIC  X(055) VALUE        'PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR SMS'.*/
        public StringBasis WS_TXT_PROP_ELETRONICA_SMS { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"PROPOSTA ELETRONICA COM ASSINATURA DIGITAL POR SMS");
        /*"01  VIND-NUM-CONTR                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUM_CONTR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-CORRESP                  PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_CORRESP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUM-PRAZO                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUM_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-OPER-CRED                PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_OPER_CRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-STA-ANTECIPACAO              PIC S9(004)      COMP.*/
        public IntBasis VIND_STA_ANTECIPACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DTFATUR                      PIC S9(004)      COMP.*/
        public IntBasis VIND_DTFATUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-AGECTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-OPRCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUMCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DIGCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CARTAO                       PIC S9(004)      COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-IMPSEGAUXF                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_IMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-VLCUSTAUXF                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_VLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PRMDIT                       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_PRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-QTDIT                        PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_QTDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-EXPEDICAO               PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_EXPEDICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-NASCIMENTO              PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CGC-CONVENENTE               PIC S9(004)      COMP.*/
        public IntBasis VIND_CGC_CONVENENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NOME-CONJUGE                 PIC S9(004)      COMP.*/
        public IntBasis VIND_NOME_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RENDA-FIXA-IND               PIC S9(004)      COMP.*/
        public IntBasis VIND_RENDA_FIXA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RENDA-FIXA-FAM               PIC S9(004)      COMP.*/
        public IntBasis VIND_RENDA_FIXA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-NASC-CONJUGE            PIC S9(004)      COMP.*/
        public IntBasis VIND_DATA_NASC_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PROFISSAO-CONJUGE            PIC S9(004)      COMP.*/
        public IntBasis VIND_PROFISSAO_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-DECLINIO                PIC S9(004)      COMP.*/
        public IntBasis VIND_DATA_DECLINIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-UF-EXPEDIDORA                PIC S9(004)      COMP.*/
        public IntBasis VIND_UF_EXPEDIDORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-TP-PROPOSTA                  PIC S9(004)      COMP.*/
        public IntBasis VIND_TP_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NOME-RAZAO        PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIPO-PESSOA       PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-IDE-SEXO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-EST-CIVIL         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_EST_CIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OCORR-END         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ENDERECO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-BAIRRO            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CIDADE            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIGLA-UF          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CEP               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DDD               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TELEFONE          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-FAX               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CGCCPF            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTNASC            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODUSU            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-I      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-F      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  APOLCOB-IMPSEGURADO           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLCOB_IMPSEGURADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  APOLCOB-DT-TERVIGENCIA        PIC X(10).*/
        public StringBasis APOLCOB_DT_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-DT-TERVIGENCIA             PIC 9(08).*/
        public IntBasis WS_DT_TERVIGENCIA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
        /*"01  WS-DT-MOVABERTO               PIC 9(08).*/
        public IntBasis WS_DT_MOVABERTO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
        /*"01  WTEM-GECLIMOV                    PIC  X(001)  VALUE  SPACES.*/
        public StringBasis WTEM_GECLIMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WS-SEG-LIBERADO                  PIC  X(001)  VALUE  SPACES.*/
        public StringBasis WS_SEG_LIBERADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WEXISTE-PRPVA                    PIC  X(003)  VALUE  'NAO'.*/
        public StringBasis WEXISTE_PRPVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  WEXISTE-COMISSAO                 PIC  X(003)  VALUE  'NAO'.*/
        public StringBasis WEXISTE_COMISSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  WHOST-OPCAO-COBER                PIC  X(001).*/
        public StringBasis WHOST_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-IDADE                      PIC S9(004)          COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-IDADE-CONJUGE              PIC S9(004)          COMP.*/
        public IntBasis WHOST_IDADE_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-CODPRODU                    PIC S9(004)          COMP.*/
        public IntBasis PRVG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-CODPRODU                    PIC S9(004)          COMP.*/
        public IntBasis PRVG_CODPRODU_0 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-PERIPGTO                    PIC S9(004)          COMP.*/
        public IntBasis PRVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  ESTIP-COD-CCT                    PIC S9(015)        COMP-3.*/
        public IntBasis ESTIP_COD_CCT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  ESTIP-NOME                       PIC  X(040).*/
        public StringBasis ESTIP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WHOST-DDD                        PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-RESIDENCIAL            PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD_RESIDENCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-COMERCIAL              PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-CELULAR                PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD_CELULAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-FAX                    PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-EMAIL                      PIC  X(040).*/
        public StringBasis WHOST_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WHOST-FONE                       PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-RESIDENCIAL           PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE_RESIDENCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-COMERCIAL             PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-CELULAR               PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE_CELULAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-FAX                   PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FAX                        PIC S9(009)          COMP.*/
        public IntBasis WHOST_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-TELEX                      PIC S9(009)          COMP.*/
        public IntBasis WHOST_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  VGPLAR-NUM-RAMO                  PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-NUM-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-QTD-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-IMPSEGURADA               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-CUSTO                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-PREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGPLAR_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  VGPLAA-NUM-ACESSORIO             PIC S9(04)    COMP.*/
        public IntBasis VGPLAA_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-QTD-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAA_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-IMPSEGURADA               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-CUSTO                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-PREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGPLAA_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  LPARM01                     PIC  9(007).*/
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
        /*"01  LPARM01-R                   REDEFINES   LPARM01.*/
        private _REDEF_VA2601B_LPARM01_R _lparm01_r { get; set; }
        public _REDEF_VA2601B_LPARM01_R LPARM01_R
        {
            get { _lparm01_r = new _REDEF_VA2601B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
            set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
        }  //Redefines
        public class _REDEF_VA2601B_LPARM01_R : VarBasis
        {
            /*"    05          LPARM01-1       PIC  9(001).*/
            public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-2       PIC  9(001).*/
            public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-3       PIC  9(001).*/
            public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-4       PIC  9(001).*/
            public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-5       PIC  9(001).*/
            public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-6       PIC  9(001).*/
            public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              LPARM03         PIC  9(001).*/

            public _REDEF_VA2601B_LPARM01_R()
            {
                LPARM01_1.ValueChanged += OnValueChanged;
                LPARM01_2.ValueChanged += OnValueChanged;
                LPARM01_3.ValueChanged += OnValueChanged;
                LPARM01_4.ValueChanged += OnValueChanged;
                LPARM01_5.ValueChanged += OnValueChanged;
                LPARM01_6.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01              LPARM03-R       REDEFINES   LPARM03                                PIC  X(001).*/
        private _REDEF_StringBasis _lparm03_r { get; set; }
        public _REDEF_StringBasis LPARM03_R
        {
            get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
            set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
        }  //Redefines
        /*"01  W-NUM-CARTAO-CREDITO        PIC  9(016)  VALUE ZEROS.*/
        public IntBasis W_NUM_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
        /*"01  W-NRMATRICULA               PIC  9(007)  VALUE ZEROS.*/
        public IntBasis W_NRMATRICULA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  FILLER                      REDEFINES   W-NRMATRICULA.*/
        private _REDEF_VA2601B_FILLER_1 _filler_1 { get; set; }
        public _REDEF_VA2601B_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_VA2601B_FILLER_1(); _.Move(W_NRMATRICULA, _filler_1); VarBasis.RedefinePassValue(W_NRMATRICULA, _filler_1, W_NRMATRICULA); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_NRMATRICULA); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, W_NRMATRICULA); }
        }  //Redefines
        public class _REDEF_VA2601B_FILLER_1 : VarBasis
        {
            /*"    05          W-NRMATRICULA1  PIC  9(006).*/
            public IntBasis W_NRMATRICULA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          W-DV-MATRICULA  PIC  9(001).*/
            public IntBasis W_DV_MATRICULA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  WORK-TAB-RAMO-CONJ.*/

            public _REDEF_VA2601B_FILLER_1()
            {
                W_NRMATRICULA1.ValueChanged += OnValueChanged;
                W_DV_MATRICULA.ValueChanged += OnValueChanged;
            }

        }
        public VA2601B_WORK_TAB_RAMO_CONJ WORK_TAB_RAMO_CONJ { get; set; } = new VA2601B_WORK_TAB_RAMO_CONJ();
        public class VA2601B_WORK_TAB_RAMO_CONJ : VarBasis
        {
            /*"    05  N5WORK-TAB-RAMO-CONJ    OCCURS 30 TIMES.*/
            public ListBasis<VA2601B_N5WORK_TAB_RAMO_CONJ> N5WORK_TAB_RAMO_CONJ { get; set; } = new ListBasis<VA2601B_N5WORK_TAB_RAMO_CONJ>(30);
            public class VA2601B_N5WORK_TAB_RAMO_CONJ : VarBasis
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
        public VA2601B_WORK_RAMO_CONJ WORK_RAMO_CONJ { get; set; } = new VA2601B_WORK_RAMO_CONJ();
        public class VA2601B_WORK_RAMO_CONJ : VarBasis
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
        public VA2601B_WORK_AREA WORK_AREA { get; set; } = new VA2601B_WORK_AREA();
        public class VA2601B_WORK_AREA : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA2601B_FAIXAS _faixas { get; set; }
            public _REDEF_VA2601B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_VA2601B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA2601B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  W-FILLER                  PIC 9(008).*/
                public IntBasis W_FILLER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VA2601B_FAIXAS()
                {
                    FILLER_2.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    W_FILLER.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2601B_CANAL _canal { get; set; }
            public _REDEF_VA2601B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA2601B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA2601B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                   VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                       VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                        VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                          VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                       VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05  W-ENDERECO                    PIC 9(001).*/

                public _REDEF_VA2601B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_ENDERECO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 END-CORRES-CADASTRADO          VALUE 01. */
							new SelectorItemBasis("END_CORRES_CADASTRADO", "01"),
							/*" 88 END-CORRES-N-CADASTRADO        VALUE 02. */
							new SelectorItemBasis("END_CORRES_N_CADASTRADO", "02"),
							/*" 88 DEMAIS-END-CADASTRADO          VALUE 03. */
							new SelectorItemBasis("DEMAIS_END_CADASTRADO", "03"),
							/*" 88 DEMAIS-END-N-CADASTRADO        VALUE 04. */
							new SelectorItemBasis("DEMAIS_END_N_CADASTRADO", "04")
                }
            };

            /*"    05  W-RCAPS                       PIC 9(002).*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                          VALUE 01. */
							new SelectorItemBasis("RCAP_CADASTRADO", "01")
                }
            };

            /*"    05  W-PLANO                       PIC 9(002).*/

            public SelectorBasis W_PLANO { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-PLANO                             VALUE 01. */
							new SelectorItemBasis("EXISTE_PLANO", "01")
                }
            };

            /*"    05  W-COBRANCA                    PIC 9(002).*/

            public SelectorBasis W_COBRANCA { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 COBRANCA-EMITIDA                         VALUE 01. */
							new SelectorItemBasis("COBRANCA_EMITIDA", "01")
                }
            };

            /*"    05  W-ORIGEM-PROPOSTA             PIC 9(002).*/

            public SelectorBasis W_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ORIGEM-SIGPF                             VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88 ORIGEM-CAIXA-PREV                        VALUE 02. */
							new SelectorItemBasis("ORIGEM_CAIXA_PREV", "02"),
							/*" 88 ORIGEM-SIGAT                             VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88 ORIGEM-SASSE                             VALUE 04. */
							new SelectorItemBasis("ORIGEM_SASSE", "04"),
							/*" 88 ORIGEM-CAIXA-CAP                         VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88 ORIGEM-SIFEC                             VALUE 06. */
							new SelectorItemBasis("ORIGEM_SIFEC", "06"),
							/*" 88 ORIGEM-REMOTA                            VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88 ORIGEM-REMOTA-FILIAL                     VALUE 08. */
							new SelectorItemBasis("ORIGEM_REMOTA_FILIAL", "08"),
							/*" 88 ORIGEM-MANUAL                            VALUE 09. */
							new SelectorItemBasis("ORIGEM_MANUAL", "09")
                }
            };

            /*"    05  W-TRATA-CLIENTE               PIC 9(002).*/

            public SelectorBasis W_TRATA_CLIENTE { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CLIENTE-INSERIDO                         VALUE 01. */
							new SelectorItemBasis("CLIENTE_INSERIDO", "01"),
							/*" 88 CLIENTE-ERRO                             VALUE 02. */
							new SelectorItemBasis("CLIENTE_ERRO", "02")
                }
            };

            /*"    05 WS-CHAVE-ATU VALUE ZEROS.*/
            public VA2601B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VA2601B_WS_CHAVE_ATU();
            public class VA2601B_WS_CHAVE_ATU : VarBasis
            {
                /*"       10 WS-ATU-APOLICE             PIC  9(013).*/
                public IntBasis WS_ATU_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10 WS-ATU-SUBGRUPO            PIC  9(005).*/
                public IntBasis WS_ATU_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05 WS-CHAVE-ANT VALUE ZEROS.*/
            }
            public VA2601B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA2601B_WS_CHAVE_ANT();
            public class VA2601B_WS_CHAVE_ANT : VarBasis
            {
                /*"       10 WS-ANT-APOLICE             PIC  9(013).*/
                public IntBasis WS_ANT_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10 WS-ANT-SUBGRUPO            PIC  9(005).*/
                public IntBasis WS_ANT_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05 WS-LIM-CALCULADO              PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis WS_LIM_CALCULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-VLPREMIOTOT-CCT            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLPREMIOTOT_CCT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-JA-E-CLIENTE               PIC  9(001) VALUE 0.*/
            public IntBasis WS_JA_E_CLIENTE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-EOR                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO-ASS               PIC  9(001) VALUE 0.*/
            public IntBasis WS_TEM_ERRO_ASS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO                   PIC  9(001) VALUE 0.*/
            public IntBasis WS_TEM_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO-1855              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1855 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1807              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1807 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1852              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1852 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-CPF-REC           PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_CPF_REC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1829              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1829 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-DAD-CAD           PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_DAD_CAD { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-FONTE                      PIC  9(005) VALUE 0.*/
            public IntBasis WS_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 WFIM-AGENCEF                  PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-CBO                      PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-FONTES                   PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-VGPLARAMC                PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_VGPLARAMC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-VGPLAACES                PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_VGPLAACES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-VGRAMOCOMP               PIC  X(003) VALUE ' '.*/
            public StringBasis WFIM_VGRAMOCOMP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"    05 WFIM-TAB-RAMO                 PIC  X(003) VALUE ' '.*/
            public StringBasis WFIM_TAB_RAMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"    05 IND                           PIC  9(005) VALUE 0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 INDR                          PIC  9      VALUE 0.*/
            public IntBasis INDR { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    05 WS-IDADE-INICIAL              PIC  9(004) VALUE 0.*/
            public IntBasis WS_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 AC-CONTROLE                   PIC  9(006) VALUE 0.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-L-MOVIMENTO                PIC  9(006) VALUE 0.*/
            public IntBasis AC_L_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-PROPOSTAVA               PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-HISTRAMOCOB              PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_HISTRAMOCOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-HISTACESCOB              PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_HISTACESCOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-TOT-RISCO                  PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_TOT_RISCO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05  WS-TRATA-NOME                PIC X(040).*/
            public StringBasis WS_TRATA_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  WS-TRATA-NOM REDEFINES WS-TRATA-NOME.*/
            private _REDEF_VA2601B_WS_TRATA_NOM _ws_trata_nom { get; set; }
            public _REDEF_VA2601B_WS_TRATA_NOM WS_TRATA_NOM
            {
                get { _ws_trata_nom = new _REDEF_VA2601B_WS_TRATA_NOM(); _.Move(WS_TRATA_NOME, _ws_trata_nom); VarBasis.RedefinePassValue(WS_TRATA_NOME, _ws_trata_nom, WS_TRATA_NOME); _ws_trata_nom.ValueChanged += () => { _.Move(_ws_trata_nom, WS_TRATA_NOME); }; return _ws_trata_nom; }
                set { VarBasis.RedefinePassValue(value, _ws_trata_nom, WS_TRATA_NOME); }
            }  //Redefines
            public class _REDEF_VA2601B_WS_TRATA_NOM : VarBasis
            {
                /*"       10 WS-NOM-1A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-2A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-3A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-4A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-5A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-6A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-7A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-8A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-NOM-9A-POSICAO          PIC X(001).*/
                public StringBasis WS_NOM_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 FILLER                     PIC X(031).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
                /*"    05  WS-TRATA-ENDERECO            PIC X(040).*/

                public _REDEF_VA2601B_WS_TRATA_NOM()
                {
                    WS_NOM_1A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_2A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_3A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_4A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_5A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_6A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_7A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_8A_POSICAO.ValueChanged += OnValueChanged;
                    WS_NOM_9A_POSICAO.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_TRATA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  WS-TRATA-END REDEFINES WS-TRATA-ENDERECO.*/
            private _REDEF_VA2601B_WS_TRATA_END _ws_trata_end { get; set; }
            public _REDEF_VA2601B_WS_TRATA_END WS_TRATA_END
            {
                get { _ws_trata_end = new _REDEF_VA2601B_WS_TRATA_END(); _.Move(WS_TRATA_ENDERECO, _ws_trata_end); VarBasis.RedefinePassValue(WS_TRATA_ENDERECO, _ws_trata_end, WS_TRATA_ENDERECO); _ws_trata_end.ValueChanged += () => { _.Move(_ws_trata_end, WS_TRATA_ENDERECO); }; return _ws_trata_end; }
                set { VarBasis.RedefinePassValue(value, _ws_trata_end, WS_TRATA_ENDERECO); }
            }  //Redefines
            public class _REDEF_VA2601B_WS_TRATA_END : VarBasis
            {
                /*"       10 WS-END-1A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-2A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-3A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-4A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-5A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-6A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-7A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-8A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-END-9A-POSICAO          PIC X(001).*/
                public StringBasis WS_END_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 FILLER                     PIC X(031).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
                /*"    05  WS-TRATA-BAIRRO              PIC X(020).*/

                public _REDEF_VA2601B_WS_TRATA_END()
                {
                    WS_END_1A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_2A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_3A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_4A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_5A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_6A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_7A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_8A_POSICAO.ValueChanged += OnValueChanged;
                    WS_END_9A_POSICAO.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_TRATA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  WS-TRATA-BAI REDEFINES WS-TRATA-BAIRRO.*/
            private _REDEF_VA2601B_WS_TRATA_BAI _ws_trata_bai { get; set; }
            public _REDEF_VA2601B_WS_TRATA_BAI WS_TRATA_BAI
            {
                get { _ws_trata_bai = new _REDEF_VA2601B_WS_TRATA_BAI(); _.Move(WS_TRATA_BAIRRO, _ws_trata_bai); VarBasis.RedefinePassValue(WS_TRATA_BAIRRO, _ws_trata_bai, WS_TRATA_BAIRRO); _ws_trata_bai.ValueChanged += () => { _.Move(_ws_trata_bai, WS_TRATA_BAIRRO); }; return _ws_trata_bai; }
                set { VarBasis.RedefinePassValue(value, _ws_trata_bai, WS_TRATA_BAIRRO); }
            }  //Redefines
            public class _REDEF_VA2601B_WS_TRATA_BAI : VarBasis
            {
                /*"       10 WS-BAI-1A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-2A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-3A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-4A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-5A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-6A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-7A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-8A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-BAI-9A-POSICAO          PIC X(001).*/
                public StringBasis WS_BAI_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 FILLER                     PIC X(011).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"    05  WS-TRATA-CIDADE              PIC X(020).*/

                public _REDEF_VA2601B_WS_TRATA_BAI()
                {
                    WS_BAI_1A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_2A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_3A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_4A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_5A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_6A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_7A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_8A_POSICAO.ValueChanged += OnValueChanged;
                    WS_BAI_9A_POSICAO.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_TRATA_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  WS-TRATA-CID REDEFINES WS-TRATA-CIDADE.*/
            private _REDEF_VA2601B_WS_TRATA_CID _ws_trata_cid { get; set; }
            public _REDEF_VA2601B_WS_TRATA_CID WS_TRATA_CID
            {
                get { _ws_trata_cid = new _REDEF_VA2601B_WS_TRATA_CID(); _.Move(WS_TRATA_CIDADE, _ws_trata_cid); VarBasis.RedefinePassValue(WS_TRATA_CIDADE, _ws_trata_cid, WS_TRATA_CIDADE); _ws_trata_cid.ValueChanged += () => { _.Move(_ws_trata_cid, WS_TRATA_CIDADE); }; return _ws_trata_cid; }
                set { VarBasis.RedefinePassValue(value, _ws_trata_cid, WS_TRATA_CIDADE); }
            }  //Redefines
            public class _REDEF_VA2601B_WS_TRATA_CID : VarBasis
            {
                /*"       10 WS-CID-1A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-2A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-3A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-4A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-5A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-6A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-7A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-8A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-CID-9A-POSICAO          PIC X(001).*/
                public StringBasis WS_CID_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 FILLER                     PIC X(011).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"    05 DATA-SQL1                     PIC  X(010).*/

                public _REDEF_VA2601B_WS_TRATA_CID()
                {
                    WS_CID_1A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_2A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_3A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_4A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_5A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_6A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_7A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_8A_POSICAO.ValueChanged += OnValueChanged;
                    WS_CID_9A_POSICAO.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis DATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 DATA-SQL  REDEFINES DATA-SQL1.*/
            private _REDEF_VA2601B_DATA_SQL _data_sql { get; set; }
            public _REDEF_VA2601B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_VA2601B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_VA2601B_DATA_SQL : VarBasis
            {
                /*"       10 ANO-SQL                    PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 MES-SQL                    PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 DIA-SQL                    PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTNASC.*/

                public _REDEF_VA2601B_DATA_SQL()
                {
                    ANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    MES_SQL.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public VA2601B_WS_DTNASC WS_DTNASC { get; set; } = new VA2601B_WS_DTNASC();
            public class VA2601B_WS_DTNASC : VarBasis
            {
                /*"       10 WS-AA-DTNASC               PIC  9(004).*/
                public IntBasis WS_AA_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTNASC               PIC  9(002).*/
                public IntBasis WS_MM_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTNASC               PIC  9(002).*/
                public IntBasis WS_DD_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTPROP.*/
            }
            public VA2601B_WS_DTPROP WS_DTPROP { get; set; } = new VA2601B_WS_DTPROP();
            public class VA2601B_WS_DTPROP : VarBasis
            {
                /*"       10 WS-AA-DTPROP               PIC  9(004).*/
                public IntBasis WS_AA_DTPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTPROP               PIC  9(002).*/
                public IntBasis WS_MM_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTPROP               PIC  9(002).*/
                public IntBasis WS_DD_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTINIVIG                   PIC  9(008).*/
            }
            public IntBasis WS_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 WS-DTTERVIG                   PIC  9(008).*/
            public IntBasis WS_DTTERVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_VA2601B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VA2601B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VA2601B_FILLER_14(); _.Move(W_NOM_ORGAO_EXP, _filler_14); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_14, W_NOM_ORGAO_EXP); _filler_14.ValueChanged += () => { _.Move(_filler_14, W_NOM_ORGAO_EXP); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_VA2601B_FILLER_14 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 DATA-DDMMAA                   PIC  9(008).*/

                public _REDEF_VA2601B_FILLER_14()
                {
                    W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                    FILLER_15.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DATA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 DATA-DDMMAA-R REDEFINES DATA-DDMMAA.*/
            private _REDEF_VA2601B_DATA_DDMMAA_R _data_ddmmaa_r { get; set; }
            public _REDEF_VA2601B_DATA_DDMMAA_R DATA_DDMMAA_R
            {
                get { _data_ddmmaa_r = new _REDEF_VA2601B_DATA_DDMMAA_R(); _.Move(DATA_DDMMAA, _data_ddmmaa_r); VarBasis.RedefinePassValue(DATA_DDMMAA, _data_ddmmaa_r, DATA_DDMMAA); _data_ddmmaa_r.ValueChanged += () => { _.Move(_data_ddmmaa_r, DATA_DDMMAA); }; return _data_ddmmaa_r; }
                set { VarBasis.RedefinePassValue(value, _data_ddmmaa_r, DATA_DDMMAA); }
            }  //Redefines
            public class _REDEF_VA2601B_DATA_DDMMAA_R : VarBasis
            {
                /*"       10 DIA-DDMMAA                 PIC  9(002).*/
                public IntBasis DIA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 MES-DDMMAA                 PIC  9(002).*/
                public IntBasis MES_DDMMAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 ANO-DDMMAA                 PIC  9(004).*/
                public IntBasis ANO_DDMMAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 WS-VLCONJUGE                  PIC  9(013)V99.*/

                public _REDEF_VA2601B_DATA_DDMMAA_R()
                {
                    DIA_DDMMAA.ValueChanged += OnValueChanged;
                    MES_DDMMAA.ValueChanged += OnValueChanged;
                    ANO_DDMMAA.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WS_VLCONJUGE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"01  WS-TIME.*/
        }
        public VA2601B_WS_TIME WS_TIME { get; set; } = new VA2601B_WS_TIME();
        public class VA2601B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01         W-GECLIMOV.*/
        public VA2601B_W_GECLIMOV W_GECLIMOV { get; set; } = new VA2601B_W_GECLIMOV();
        public class VA2601B_W_GECLIMOV : VarBasis
        {
            /*"  05       WWORK-COD-CLIENTE      PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-TIPO-MOVIMENTO   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-DATA-ULT-MANUTEN PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WWORK-NOME-RAZAO       PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-TIPO-PESSOA      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-IDE-SEXO         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-ESTADO-CIVIL     PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-OCORR-ENDERECO   PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-ENDERECO         PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-BAIRRO           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-CIDADE           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-SIGLA-UF         PIC  X(002)    VALUE  SPACES.*/
            public StringBasis WWORK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05       WWORK-CEP              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-DDD              PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-TELEFONE         PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-FAX              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-CGCCPF           PIC S9(015)    VALUE +0 COMP-3*/
            public IntBasis WWORK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05       WWORK-DATA-NASCIMENTO  PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  AREA-ABEND.*/
        }
        public VA2601B_AREA_ABEND AREA_ABEND { get; set; } = new VA2601B_AREA_ABEND();
        public class VA2601B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public VA2601B_WABEND WABEND { get; set; } = new VA2601B_WABEND();
            public class VA2601B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA2601B  '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA2601B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA2601B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA2601B_LOCALIZA_ABEND_1();
            public class VA2601B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA2601B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA2601B_LOCALIZA_ABEND_2();
            public class VA2601B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05         WSQLERRO.*/
            }
            public VA2601B_WSQLERRO WSQLERRO { get; set; } = new VA2601B_WSQLERRO();
            public class VA2601B_WSQLERRO : VarBasis
            {
                /*"      10       FILLER               PIC  X(014) VALUE               ' *** SQLERRMC '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10       WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01           CT0006S-LINKAGE.*/
            }
        }
        public VA2601B_CT0006S_LINKAGE CT0006S_LINKAGE { get; set; } = new VA2601B_CT0006S_LINKAGE();
        public class VA2601B_CT0006S_LINKAGE : VarBasis
        {
            /*"  05         CT0006S-CEP-DESTINO    PIC  9(008).*/
            public IntBasis CT0006S_CEP_DESTINO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         CT0006S-SIGLA-UF       PIC  X(002).*/
            public StringBasis CT0006S_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05         CT0006S-SQLCODE        PIC  S9(04) COMP.*/
            public IntBasis CT0006S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         CT0006S-MENSAGEM       PIC  X(070).*/
            public StringBasis CT0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         CT0006S-TP-LOGRAD      PIC  X(036).*/
            public StringBasis CT0006S_TP_LOGRAD { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
            /*"  05         CT0006S-NOM-LOGRAD     PIC  X(100).*/
            public StringBasis CT0006S_NOM_LOGRAD { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"  05         CT0006S-BAIRRO         PIC  X(072).*/
            public StringBasis CT0006S_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-CIDADE         PIC  X(072).*/
            public StringBasis CT0006S_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-UNIDADE-OPER   PIC  X(072).*/
            public StringBasis CT0006S_UNIDADE_OPER { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-CENTRALIZ      PIC  X(072).*/
            public StringBasis CT0006S_CENTRALIZ { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"01  TAB-FILIAIS.*/
        }
        public VA2601B_TAB_FILIAIS TAB_FILIAIS { get; set; } = new VA2601B_TAB_FILIAIS();
        public class VA2601B_TAB_FILIAIS : VarBasis
        {
            /*"    05      TAB-FILIAL.*/
            public VA2601B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA2601B_TAB_FILIAL();
            public class VA2601B_TAB_FILIAL : VarBasis
            {
                /*"      10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<VA2601B_FILLER_26> FILLER_26 { get; set; } = new ListBasis<VA2601B_FILLER_26>(9999);
                public class VA2601B_FILLER_26 : VarBasis
                {
                    /*"        15  TAB-FONTE                PIC S9(4) COMP.*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                    /*"01  TAB-CBO1.*/
                }
            }
        }
        public VA2601B_TAB_CBO1 TAB_CBO1 { get; set; } = new VA2601B_TAB_CBO1();
        public class VA2601B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public VA2601B_TAB_CBO TAB_CBO { get; set; } = new VA2601B_TAB_CBO();
            public class VA2601B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<VA2601B_FILLER_27> FILLER_27 { get; set; } = new ListBasis<VA2601B_FILLER_27>(999);
                public class VA2601B_FILLER_27 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                }
            }
        }


        public Copies.VATBFREN VATBFREN { get; set; } = new Copies.VATBFREN();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.COADSICO COADSICO { get; set; } = new Dclgens.COADSICO();
        public Dclgens.PARVDZUL PARVDZUL { get; set; } = new Dclgens.PARVDZUL();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.CONVEVG CONVEVG { get; set; } = new Dclgens.CONVEVG();
        public Dclgens.CBHSTZUL CBHSTZUL { get; set; } = new Dclgens.CBHSTZUL();
        public Dclgens.HTCTBPVA HTCTBPVA { get; set; } = new Dclgens.HTCTBPVA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.ESTIPULA ESTIPULA { get; set; } = new Dclgens.ESTIPULA();
        public Dclgens.ERPROPAZ ERPROPAZ { get; set; } = new Dclgens.ERPROPAZ();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PLVAVGAP PLVAVGAP { get; set; } = new Dclgens.PLVAVGAP();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.NUMOUTRO NUMOUTRO { get; set; } = new Dclgens.NUMOUTRO();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.VG080 VG080 { get; set; } = new Dclgens.VG080();
        public Dclgens.VG081 VG081 { get; set; } = new Dclgens.VG081();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public Dclgens.UNIDAFED UNIDAFED { get; set; } = new Dclgens.UNIDAFED();
        public Dclgens.VG034 VG034 { get; set; } = new Dclgens.VG034();
        public Dclgens.VGHIRACO VGHIRACO { get; set; } = new Dclgens.VGHIRACO();
        public Dclgens.VG036 VG036 { get; set; } = new Dclgens.VG036();
        public Dclgens.VGHIACCO VGHIACCO { get; set; } = new Dclgens.VGHIACCO();
        public Dclgens.BENPROPZ BENPROPZ { get; set; } = new Dclgens.BENPROPZ();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA2601B_CPROPOSTA CPROPOSTA { get; set; } = new VA2601B_CPROPOSTA();
        public VA2601B_C01_RCAPCOMP C01_RCAPCOMP { get; set; } = new VA2601B_C01_RCAPCOMP();
        public VA2601B_CPESENDER CPESENDER { get; set; } = new VA2601B_CPESENDER();
        public VA2601B_CPESENDERR CPESENDERR { get; set; } = new VA2601B_CPESENDERR();
        public VA2601B_CFONE CFONE { get; set; } = new VA2601B_CFONE();
        public VA2601B_CRISCO CRISCO { get; set; } = new VA2601B_CRISCO();
        public VA2601B_CCLIENTES CCLIENTES { get; set; } = new VA2601B_CCLIENTES();
        public VA2601B_VGPLARAMC VGPLARAMC { get; set; } = new VA2601B_VGPLARAMC();
        public VA2601B_VGPLAACES VGPLAACES { get; set; } = new VA2601B_VGPLAACES();
        public VA2601B_C01_AGENCEF C01_AGENCEF { get; set; } = new VA2601B_C01_AGENCEF();
        public VA2601B_CCBO CCBO { get; set; } = new VA2601B_CCBO();
        public VA2601B_CFONTES CFONTES { get; set; } = new VA2601B_CFONTES();
        public VA2601B_CVGRAMOCOMP CVGRAMOCOMP { get; set; } = new VA2601B_CVGRAMOCOMP();
        public VA2601B_C01_GECLIMOV C01_GECLIMOV { get; set; } = new VA2601B_C01_GECLIMOV();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -802- DISPLAY ' ' */
            _.Display($" ");

            /*" -804- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -812- DISPLAY 'PROGRAMA EM EXECUCAO VA2601B   ' 'VERSAO V.23 - DEMANDA 330882 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VA2601B   VERSAO V.23 - DEMANDA 330882 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -814- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -839- DISPLAY ' ' . */
            _.Display($" ");

            /*" -841- MOVE '0000-PRINCIPAL                     ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL                     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -847- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -854- MOVE '0000-PRINCIPAL                     ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL                     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -855- PERFORM R0900-00-DECLARE-PROPOSTA. */

            R0900_00_DECLARE_PROPOSTA_SECTION();

            /*" -857- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

            /*" -858- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -859- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -860- DISPLAY '//                TERMINO                     //' */
                _.Display($"//                TERMINO                     //");

                /*" -861- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -862- DISPLAY '//        ==>    N O R M A L  <==             //' */
                _.Display($"//        ==>    N O R M A L  <==             //");

                /*" -863- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -864- DISPLAY '//      PROGRAMA =>  VA2601B                  //' */
                _.Display($"//      PROGRAMA =>  VA2601B                  //");

                /*" -865- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -866- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -872- GO TO R0000-00-FINALIZA. */

                R0000_00_FINALIZA(); //GOTO
                return;
            }


            /*" -875- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -875- PERFORM R9100-00-UPDATE-NUM-OUTROS. */

            R9100_00_UPDATE_NUM_OUTROS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -880- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -882- DISPLAY ' ' */
            _.Display($" ");

            /*" -883- DISPLAY '////////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////////");

            /*" -884- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -885- DISPLAY '//      ==> TERMINO NORMAL <==                //' */
            _.Display($"//      ==> TERMINO NORMAL <==                //");

            /*" -886- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -887- DISPLAY '//      PROGRAMA =>  VA2601B                  //' */
            _.Display($"//      PROGRAMA =>  VA2601B                  //");

            /*" -888- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -889- DISPLAY '////////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////////");

            /*" -890- DISPLAY 'LIDOS PROPOSTAVA-FIDELIZ  ' AC-L-MOVIMENTO */
            _.Display($"LIDOS PROPOSTAVA-FIDELIZ  {WORK_AREA.AC_L_MOVIMENTO}");

            /*" -891- DISPLAY 'GRAVADOS PROPOSTAVA       ' AC-I-PROPOSTAVA */
            _.Display($"GRAVADOS PROPOSTAVA       {WORK_AREA.AC_I_PROPOSTAVA}");

            /*" -892- DISPLAY 'GRAVADOS VG-HIST-RAMO-COB ' AC-I-HISTRAMOCOB */
            _.Display($"GRAVADOS VG-HIST-RAMO-COB {WORK_AREA.AC_I_HISTRAMOCOB}");

            /*" -893- DISPLAY 'GRAVADOS VG-HIST-ACES-COB ' AC-I-HISTACESCOB */
            _.Display($"GRAVADOS VG-HIST-ACES-COB {WORK_AREA.AC_I_HISTACESCOB}");

            /*" -895- PERFORM R9900-00-MOSTRA-TOTAIS */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -896- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -896- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -902- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -905- MOVE 'R0100-00-SELECT-SISTEMAS      ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -906- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -907- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -914- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -917- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -918- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -919- DISPLAY 'PROBLEMAS NO ACESSO  A SISTEMAS ' */
                _.Display($"PROBLEMAS NO ACESSO  A SISTEMAS ");

                /*" -921- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -923- MOVE 'R0100-00-SELECT-NUM-OUTROS    ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-NUM-OUTROS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -924- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -925- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -929- PERFORM R0100_00_INICIALIZA_DB_SELECT_2 */

            R0100_00_INICIALIZA_DB_SELECT_2();

            /*" -932- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -933- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -934- DISPLAY 'PROBLEMAS NO ACESSO  A NUMERO OUTROS' */
                _.Display($"PROBLEMAS NO ACESSO  A NUMERO OUTROS");

                /*" -936- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -938- INITIALIZE TAB-FILIAIS. */
            _.Initialize(
                TAB_FILIAIS
            );

            /*" -940- PERFORM R6000-00-DECLARE-AGENCEF. */

            R6000_00_DECLARE_AGENCEF_SECTION();

            /*" -942- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

            /*" -943- IF WFIM-AGENCEF NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_AGENCEF.IsEmpty())
            {

                /*" -944- DISPLAY '0000 - PROBLEMA NO FETCH DA AGENCIACEF' */
                _.Display($"0000 - PROBLEMA NO FETCH DA AGENCIACEF");

                /*" -946- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -949- PERFORM R6020-00-CARREGA-FILIAL UNTIL WFIM-AGENCEF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_AGENCEF == "S"))
            {

                R6020_00_CARREGA_FILIAL_SECTION();
            }

            /*" -951- MOVE ZEROS TO TAB-CBO1. */
            _.Move(0, TAB_CBO1);

            /*" -953- PERFORM R6100-00-DECLARE-CBO. */

            R6100_00_DECLARE_CBO_SECTION();

            /*" -955- PERFORM R6110-00-FETCH-CBO. */

            R6110_00_FETCH_CBO_SECTION();

            /*" -956- IF WFIM-CBO NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_CBO.IsEmpty())
            {

                /*" -957- DISPLAY '0100 - PROBLEMA NO FETCH DA CBO         ' */
                _.Display($"0100 - PROBLEMA NO FETCH DA CBO         ");

                /*" -959- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -960- PERFORM R6120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_CBO == "S"))
            {

                R6120_00_CARREGA_CBO_SECTION();
            }

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-1 */
        public void R0100_00_INICIALIZA_DB_SELECT_1()
        {
            /*" -914- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO + 8 DAYS INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :WHOST-DATA-AGENDAMENTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'PF' END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_1_Query1 = new R0100_00_INICIALIZA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_1_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_AGENDAMENTO, WHOST_DATA_AGENDAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-2 */
        public void R0100_00_INICIALIZA_DB_SELECT_2()
        {
            /*" -929- EXEC SQL SELECT NUM_CLIENTE INTO :DCLNUMERO-OUTROS.NUM-CLIENTE FROM SEGUROS.NUMERO_OUTROS END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_2_Query1 = new R0100_00_INICIALIZA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_2_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_CLIENTE, NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-SECTION */
        private void R0900_00_DECLARE_PROPOSTA_SECTION()
        {
            /*" -983- MOVE 'DECLARE CPROPOSTA                  ' TO COMANDO. */
            _.Move("DECLARE CPROPOSTA                  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -984- MOVE 03 TO SII. */
            _.Move(03, WS_HORAS.SII);

            /*" -985- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1060- PERFORM R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1();

            /*" -1063- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1064- MOVE 'OPEN CPROPOSTA                     ' TO COMANDO. */
            _.Move("OPEN CPROPOSTA                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1065- MOVE 04 TO SII. */
            _.Move(04, WS_HORAS.SII);

            /*" -1066- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1066- PERFORM R0900_00_DECLARE_PROPOSTA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTA_DB_OPEN_1();

            /*" -1069- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1070- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1071- DISPLAY '*** VA2601B *** ERRO OPEN CPROPOSTA  ' */
                _.Display($"*** VA2601B *** ERRO OPEN CPROPOSTA  ");

                /*" -1071- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1()
        {
            /*" -1060- EXEC SQL DECLARE CPROPOSTA CURSOR FOR SELECT B.NUM_APOLICE, B.COD_SUBGRUPO , B.NUM_IDENTIFICACAO, B.DPS_TITULAR, B.DPS_CONJUGE, B.APOS_INVALIDEZ, B.NUM_CONTR_VINCULO, B.COD_CORRESP_BANC, B.NUM_PRAZO_FIN, B.COD_OPER_CREDITO, C.OPCAO_COBER, C.COD_PLANO, B.COD_USUARIO, C.NUM_PROPOSTA_SIVPF, C.COD_PESSOA, C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM , C.IND_TP_PROPOSTA , A.COD_PRODUTO , A.PERI_PAGAMENTO , A.DESCONTO_ADESAO , A.NOME_PRODUTO , D.RAMO_EMISSOR FROM SEGUROS.PRODUTOS_VG A, SEGUROS.PROP_SASSE_VIDA B, SEGUROS.PROPOSTA_FIDELIZ C, SEGUROS.APOLICES D WHERE A.ESTR_COBR = 'MULT' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_APOLICE = D.NUM_APOLICE AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA = 'POB' AND C.ORIGEM_PROPOSTA = 1005 ORDER BY C.NUM_PROPOSTA_SIVPF END-EXEC. */
            CPROPOSTA = new VA2601B_CPROPOSTA(false);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_IDENTIFICACAO
							, 
							B.DPS_TITULAR
							, 
							B.DPS_CONJUGE
							, 
							B.APOS_INVALIDEZ
							, 
							B.NUM_CONTR_VINCULO
							, 
							B.COD_CORRESP_BANC
							, 
							B.NUM_PRAZO_FIN
							, 
							B.COD_OPER_CREDITO
							, 
							C.OPCAO_COBER
							, 
							C.COD_PLANO
							, 
							B.COD_USUARIO
							, 
							C.NUM_PROPOSTA_SIVPF
							, 
							C.COD_PESSOA
							, 
							C.NUM_SICOB
							, 
							C.DATA_PROPOSTA
							, 
							C.COD_PRODUTO_SIVPF
							, 
							C.COD_EMPRESA_SIVPF
							, 
							C.AGECOBR
							, 
							C.DIA_DEBITO
							, 
							C.OPCAOPAG
							, 
							C.AGECTADEB
							, 
							C.OPRCTADEB
							, 
							C.NUMCTADEB
							, 
							C.DIGCTADEB
							, 
							C.PERC_DESCONTO
							, 
							C.NRMATRVEN
							, 
							C.AGECTAVEN
							, 
							C.OPRCTAVEN
							, 
							C.NUMCTAVEN
							, 
							C.DIGCTAVEN
							, 
							C.CGC_CONVENENTE
							, 
							C.NOME_CONVENENTE
							, 
							C.NRMATRCON
							, 
							C.DTQITBCO
							, 
							C.VAL_PAGO
							, 
							C.AGEPGTO
							, 
							C.VAL_TARIFA
							, 
							C.VAL_IOF
							, 
							C.DATA_CREDITO
							, 
							C.VAL_COMISSAO
							, 
							C.SIT_PROPOSTA
							, 
							C.COD_USUARIO
							, 
							C.CANAL_PROPOSTA
							, 
							C.NSAS_SIVPF
							, 
							C.ORIGEM_PROPOSTA
							, 
							C.TIMESTAMP
							, 
							C.NSL
							, 
							C.NSAC_SIVPF
							, 
							C.NOME_CONJUGE
							, 
							C.DATA_NASC_CONJUGE
							, 
							C.PROFISSAO_CONJUGE
							, 
							C.FAIXA_RENDA_IND
							, 
							C.FAIXA_RENDA_FAM
							, 
							C.IND_TP_PROPOSTA
							, 
							A.COD_PRODUTO
							, 
							A.PERI_PAGAMENTO
							, 
							A.DESCONTO_ADESAO
							, 
							A.NOME_PRODUTO
							, 
							D.RAMO_EMISSOR 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.PROP_SASSE_VIDA B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C
							, 
							SEGUROS.APOLICES D 
							WHERE A.ESTR_COBR = 'MULT' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.NUM_APOLICE = D.NUM_APOLICE 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA = 'POB' 
							AND C.ORIGEM_PROPOSTA = 1005 
							ORDER BY C.NUM_PROPOSTA_SIVPF";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_OPEN_1()
        {
            /*" -1066- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-DECLARE-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1()
        {
            /*" -2910- EXEC SQL DECLARE C01_RCAPCOMP CURSOR FOR SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, COD_OPERACAO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 ORDER BY COD_OPERACAO DESC END-EXEC */
            C01_RCAPCOMP = new VA2601B_C01_RCAPCOMP(true);
            string GetQuery_C01_RCAPCOMP()
            {
                var query = @$"SELECT BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							DATA_MOVIMENTO
							, 
							DATA_RCAP
							, 
							COD_OPERACAO 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE COD_FONTE = '{RCAPS.DCLRCAPS.RCAPS_COD_FONTE}' 
							AND NUM_RCAP = '{RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}' 
							AND NUM_RCAP_COMPLEMEN = 0 
							ORDER BY COD_OPERACAO DESC";

                return query;
            }
            C01_RCAPCOMP.GetQueryEvent += GetQuery_C01_RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-SECTION */
        private void R0910_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -1083- MOVE 'R0910-00-FETCH-PROPOSTA     ' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-PROPOSTA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1086- MOVE 'FETCH CPROPOSTA             ' TO COMANDO. */
            _.Move("FETCH CPROPOSTA             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1155- PERFORM R0910_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -1158- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1158- PERFORM R0910_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -1160- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -1161- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -1162- ELSE */
            }
            else
            {


                /*" -1164- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -1166- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1169- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -1174- MOVE PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-ORIGEM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, WORK_AREA.W_ORIGEM_PROPOSTA);

            /*" -1176- IF PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 1005 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1005)
            {

                /*" -1177- GO TO R0910-CONTINUA */

                R0910_CONTINUA(); //GOTO
                return;

                /*" -1179- END-IF. */
            }


            /*" -1180- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -1181- GO TO R0910-CONTINUA */

                R0910_CONTINUA(); //GOTO
                return;

                /*" -1183- END-IF. */
            }


            /*" -1185- PERFORM R0911-00-SELECT-RCAPS */

            R0911_00_SELECT_RCAPS_SECTION();

            /*" -1188- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1189- GO TO R0910-00-FETCH-PROPOSTA */
                new Task(() => R0910_00_FETCH_PROPOSTA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1189- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0910_CONTINUA */

            R0910_CONTINUA();

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -1155- EXEC SQL FETCH CPROPOSTA INTO :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO , :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE , :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ , :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-USUARIO , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-EMPRESA-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAOPAG , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-PERC-DESCONTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONVENENTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRCON , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-TARIFA , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-IOF , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-COMISSAO , :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-USUARIO , :DCLPROPOSTA-FIDELIZ.PROPOFID-CANAL-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-TIMESTAMP , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSL , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAC-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND :VIND-RENDA-FIXA-IND , :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM :VIND-RENDA-FIXA-FAM , :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TP-PROPOSTA :VIND-TP-PROPOSTA , :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO , :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO , :DCLPRODUTOS-VG.PRODUVG-DESCONTO-ADESAO , :DCLPRODUTOS-VG.PRODUVG-NOME-PRODUTO , :WHOST-RAMO END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);
                _.Move(CPROPOSTA.PROPSSVD_NUM_CONTR_VINCULO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO);
                _.Move(CPROPOSTA.VIND_NUM_CONTR, VIND_NUM_CONTR);
                _.Move(CPROPOSTA.PROPSSVD_COD_CORRESP_BANC, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC);
                _.Move(CPROPOSTA.VIND_COD_CORRESP, VIND_COD_CORRESP);
                _.Move(CPROPOSTA.PROPSSVD_NUM_PRAZO_FIN, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN);
                _.Move(CPROPOSTA.VIND_NUM_PRAZO, VIND_NUM_PRAZO);
                _.Move(CPROPOSTA.PROPSSVD_COD_OPER_CREDITO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO);
                _.Move(CPROPOSTA.VIND_COD_OPER_CRED, VIND_COD_OPER_CRED);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_TIMESTAMP);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);
                _.Move(CPROPOSTA.VIND_NOME_CONJUGE, VIND_NOME_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);
                _.Move(CPROPOSTA.VIND_DATA_NASC_CONJUGE, VIND_DATA_NASC_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);
                _.Move(CPROPOSTA.VIND_PROFISSAO_CONJUGE, VIND_PROFISSAO_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);
                _.Move(CPROPOSTA.VIND_RENDA_FIXA_IND, VIND_RENDA_FIXA_IND);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);
                _.Move(CPROPOSTA.VIND_RENDA_FIXA_FAM, VIND_RENDA_FIXA_FAM);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);
                _.Move(CPROPOSTA.VIND_TP_PROPOSTA, VIND_TP_PROPOSTA);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DESCONTO_ADESAO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
                _.Move(CPROPOSTA.WHOST_RAMO, WHOST_RAMO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -1158- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }

        [StopWatch]
        /*" R0910-CONTINUA */
        private void R0910_CONTINUA(bool isPerform = false)
        {
            /*" -1203- ADD 1 TO AC-L-MOVIMENTO, AC-CONTROLE. */
            WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;
            WORK_AREA.AC_CONTROLE.Value = WORK_AREA.AC_CONTROLE + 1;

            /*" -1204- IF VIND-RENDA-FIXA-IND LESS ZERO */

            if (VIND_RENDA_FIXA_IND < 00)
            {

                /*" -1207- MOVE SPACES TO PROPOFID-FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ. */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);
            }


            /*" -1208- IF VIND-RENDA-FIXA-FAM LESS ZERO */

            if (VIND_RENDA_FIXA_FAM < 00)
            {

                /*" -1211- MOVE SPACES TO PROPOFID-FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ. */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);
            }


            /*" -1212- IF VIND-TP-PROPOSTA LESS ZERO */

            if (VIND_TP_PROPOSTA < 00)
            {

                /*" -1214- MOVE SPACES TO PROPOFID-IND-TP-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);

                /*" -1216- END-IF */
            }


            /*" -1218- SET WS-NAO-PROP-ELETRONICA TO TRUE */
            WS_INSERE_ANDAMENTO["WS_NAO_PROP_ELETRONICA"] = true;

            /*" -1219- IF AC-CONTROLE GREATER 99 */

            if (WORK_AREA.AC_CONTROLE > 99)
            {

                /*" -1220- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1221- MOVE WS-TIME-N TO WS-TIME-EDIT */
                _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                /*" -1222- DISPLAY ' ' */
                _.Display($" ");

                /*" -1225- DISPLAY 'VA2601B - TOTAL LIDO ' AC-L-MOVIMENTO '  HORAS  ' WS-TIME-EDIT */

                $"VA2601B - TOTAL LIDO {WORK_AREA.AC_L_MOVIMENTO}  HORAS  {WS_TIME_EDIT}"
                .Display();

                /*" -1227- MOVE ZEROS TO AC-CONTROLE. */
                _.Move(0, WORK_AREA.AC_CONTROLE);
            }


            /*" -1229- MOVE PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA TO WS-ATU-APOLICE. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, WORK_AREA.WS_CHAVE_ATU.WS_ATU_APOLICE);

            /*" -1230- MOVE PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA TO WS-ATU-SUBGRUPO. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, WORK_AREA.WS_CHAVE_ATU.WS_ATU_SUBGRUPO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0911-00-SELECT-RCAPS-SECTION */
        private void R0911_00_SELECT_RCAPS_SECTION()
        {
            /*" -1246- MOVE 'R0911-00-SELECT-RCAPS       ' TO PARAGRAFO. */
            _.Move("R0911-00-SELECT-RCAPS       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1249- MOVE 'SELECT RCAPS FILTRO         ' TO COMANDO. */
            _.Move("SELECT RCAPS FILTRO         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1256- PERFORM R0911_00_SELECT_RCAPS_DB_SELECT_1 */

            R0911_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1259- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1260- DISPLAY 'PROBLEMAS NO SELECT DA RCAPS            ' */
                _.Display($"PROBLEMAS NO SELECT DA RCAPS            ");

                /*" -1261- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0911-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0911_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1256- EXEC SQL SELECT NOME_SEGURADO , AGE_COBRANCA INTO :RCAPS-NOME-SEGURADO, :RCAPS-AGE-COBRANCA FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0911_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0911_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NOME_SEGURADO, RCAPS.DCLRCAPS.RCAPS_NOME_SEGURADO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0911_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1295- MOVE 'R1000-00-PROCESSA-REGISTRO  ' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1297- MOVE ZERO TO W-COBRANCA. */
            _.Move(0, WORK_AREA.W_COBRANCA);

            /*" -1304- MOVE 'NAO' TO WS-TEM-ERRO-1852 WS-TEM-ERRO-CPF-REC WS-TEM-ERRO-1829 WS-TEM-ERRO-DAD-CAD */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1852, WORK_AREA.WS_TEM_ERRO_CPF_REC, WORK_AREA.WS_TEM_ERRO_1829, WORK_AREA.WS_TEM_ERRO_DAD_CAD);

            /*" -1306- PERFORM R2203-00-SELECT-CONDITEC. */

            R2203_00_SELECT_CONDITEC_SECTION();

            /*" -1309- PERFORM R2205-00-SELECT-HISTCOBVA. */

            R2205_00_SELECT_HISTCOBVA_SECTION();

            /*" -1313- MOVE ZEROS TO WS-TEM-ERRO. */
            _.Move(0, WORK_AREA.WS_TEM_ERRO);

            /*" -1314- PERFORM R2200-00-SELECT-PESSOA. */

            R2200_00_SELECT_PESSOA_SECTION();

            /*" -1315- PERFORM R2210-00-SELECT-PESSOA-FISICA. */

            R2210_00_SELECT_PESSOA_FISICA_SECTION();

            /*" -1316- PERFORM R2215-00-SELECT-PROPOVA. */

            R2215_00_SELECT_PROPOVA_SECTION();

            /*" -1317- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1318- PERFORM R2220-00-OBTER-ENDERECO-CORRES */

                R2220_00_OBTER_ENDERECO_CORRES_SECTION();

                /*" -1319- ELSE */
            }
            else
            {


                /*" -1320- PERFORM R2222-00-OBTER-ENDERECO-CORRES */

                R2222_00_OBTER_ENDERECO_CORRES_SECTION();

                /*" -1322- END-IF. */
            }


            /*" -1323- IF END-CORRES-N-CADASTRADO */

            if (WORK_AREA.W_ENDERECO["END_CORRES_N_CADASTRADO"])
            {

                /*" -1325- PERFORM R2225-00-OBTER-DEMAIS-ENDERECO */

                R2225_00_OBTER_DEMAIS_ENDERECO_SECTION();

                /*" -1326- IF DEMAIS-END-N-CADASTRADO */

                if (WORK_AREA.W_ENDERECO["DEMAIS_END_N_CADASTRADO"])
                {

                    /*" -1327- MOVE 501 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(501, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1329- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();
                }

            }


            /*" -1331- PERFORM R2230-00-SELECT-PESSOA-FONE. */

            R2230_00_SELECT_PESSOA_FONE_SECTION();

            /*" -1335- IF WHOST-DDD = ZEROS AND WHOST-FONE = ZEROS AND WHOST-FAX = ZEROS AND WHOST-TELEX = ZEROS */

            if (WHOST_DDD == 00 && WHOST_FONE == 00 && WHOST_FAX == 00 && WHOST_TELEX == 00)
            {

                /*" -1336- PERFORM R2232-00-SELECT-PESSOA-FONE */

                R2232_00_SELECT_PESSOA_FONE_SECTION();

                /*" -1337- ELSE */
            }
            else
            {


                /*" -1338- PERFORM R2235-00-UPDATE-PESSOA-FONE */

                R2235_00_UPDATE_PESSOA_FONE_SECTION();

                /*" -1340- END-IF. */
            }


            /*" -1342- PERFORM R2236-00-SELECT-PESSOA-EMAIL. */

            R2236_00_SELECT_PESSOA_EMAIL_SECTION();

            /*" -1346- PERFORM R2240-00-SELECT-PROPFIDC. */

            R2240_00_SELECT_PROPFIDC_SECTION();

            /*" -1347- PERFORM R2300-00-TRATA-CLIENTES. */

            R2300_00_TRATA_CLIENTES_SECTION();

            /*" -1348- IF CLIENTE-ERRO */

            if (WORK_AREA.W_TRATA_CLIENTE["CLIENTE_ERRO"])
            {

                /*" -1353- GO TO R1000-10-SAIDA. */

                R1000_10_SAIDA(); //GOTO
                return;
            }


            /*" -1363- IF CPF OF DCLPESSOA-FISICA = 11111111111 OR 22222222222 OR 33333333333 OR 44444444444 OR 55555555555 OR 66666666666 OR 77777777777 OR 88888888888 OR 99999999999 */

            if (PESFIS.DCLPESSOA_FISICA.CPF.In("11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"))
            {

                /*" -1364- MOVE 402 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(402, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -1366- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                R1100_00_INSERT_ERROSPROPVA_SECTION();
            }


            /*" -1378- IF CPF OF DCLPESSOA-FISICA = 000000000000000 OR 000000000000091 OR 000000000000101 OR 000000000000191 OR 000000000001910 OR 000000000019100 OR 000001910000000 OR 000009100000000 OR 000010000000000 OR 000011000000000 OR 000011111111111 OR 000017500000000 OR 000019100000000 OR 000020000000000 OR 000022222222222 OR 000030000000000 OR 000040000000000 OR 000050000000000 OR 000060000000000 OR 000070000000000 OR 000080000000000 OR 000090000000000 OR 000099000000000 OR 000099900000000 OR 000099990000000 OR 000099999000000 OR 000099999964001 OR 000099999999990 OR 000099999999999 OR 099999999999999 OR 000360306000104 OR 034020354000110 */

            if (PESFIS.DCLPESSOA_FISICA.CPF.In("000000000000000", "000000000000091", "000000000000101", "000000000000191", "000000000001910", "000000000019100", "000001910000000", "000009100000000", "000010000000000", "000011000000000", "000011111111111", "000017500000000", "000019100000000", "000020000000000", "000022222222222", "000030000000000", "000040000000000", "000050000000000", "000060000000000", "000070000000000", "000080000000000", "000090000000000", "000099000000000", "000099900000000", "000099990000000", "000099999000000", "000099999964001", "000099999999990", "000099999999999", "099999999999999", "000360306000104", "034020354000110"))
            {

                /*" -1379- MOVE 402 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(402, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -1382- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                R1100_00_INSERT_ERROSPROPVA_SECTION();
            }


            /*" -1384- IF CPF OF DCLPESSOA-FISICA LESS 100000 AND CPF OF DCLPESSOA-FISICA NOT EQUAL 37192 */

            if (PESFIS.DCLPESSOA_FISICA.CPF < 100000 && PESFIS.DCLPESSOA_FISICA.CPF != 37192)
            {

                /*" -1385- MOVE 402 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(402, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -1386- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -1401- END-IF */
            }


            /*" -1402- MOVE ' ' TO WS-SEG-LIBERADO. */
            _.Move(" ", WS_SEG_LIBERADO);

            /*" -1415- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9320 OR JVPRD9320 OR 9321 OR JVPRD9321 OR 9327 OR JVPRD9327 OR 9328 OR JVPRD9328 OR 9332 OR JVPRD9332 OR 9334 OR JVPRD9334 OR 9356 OR JVPRD9356 OR 9357 OR JVPRD9357 OR 9358 OR JVPRD9358 OR 9359 OR JVPRD9359 OR 9360 OR JVPRD9360 OR 9361 OR JVPRD9361 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), "9321", JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), "9327", JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9332", JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9356", JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), "9359", JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), "9360", JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), "9361", JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString()))
            {

                /*" -1416- PERFORM R1400-00-SELECT-PLANOS-VA */

                R1400_00_SELECT_PLANOS_VA_SECTION();

                /*" -1417- IF IMPMORNATU OF DCLPLANOS-VA-VGAP GREATER 600000 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 600000)
                {

                    /*" -1418- MOVE 'S' TO WS-SEG-LIBERADO */
                    _.Move("S", WS_SEG_LIBERADO);

                    /*" -1419- END-IF */
                }


                /*" -1421- END-IF. */
            }


            /*" -1423- IF NOT CANAL-GITEL AND WS-SEG-LIBERADO NOT EQUAL 'S' */

            if (!WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] && WS_SEG_LIBERADO == "S")
            {

                /*" -1424- IF PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA EQUAL 'N' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ == "N")
                {

                    /*" -1425- IF COD-CBO OF DCLPESSOA-FISICA GREATER ZEROS */

                    if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 00)
                    {

                        /*" -1427- IF TAB-DESCR-CBO-C (COD-CBO OF DCLPESSOA-FISICA) (1:5) EQUAL 'APOSE' */

                        if (TAB_CBO1.TAB_CBO.FILLER_27[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C.Substring(1, 5) == "APOSE")
                        {

                            /*" -1428- MOVE 1801 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1801, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -1430- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();
                        }

                    }

                }

            }


            /*" -1433- MOVE PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA(2:1) TO PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Substring(2, 1), PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);

            /*" -1435- MOVE 'NAO' TO WS-TEM-ERRO-1807 */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1807);

            /*" -1436- IF WS-SEG-LIBERADO NOT EQUAL 'S' */

            if (WS_SEG_LIBERADO != "S")
            {

                /*" -1437- IF PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA = 'S' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ == "S")
                {

                    /*" -1438- MOVE 1807 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1807, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1439- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -1440- MOVE 'SIM' TO WS-TEM-ERRO-1807 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1807);

                    /*" -1456- PERFORM R3700-00-INSERT-RELATORIOS. */

                    R3700_00_INSERT_RELATORIOS_SECTION();
                }

            }


            /*" -1457- IF WS-SEG-LIBERADO NOT EQUAL 'S' */

            if (WS_SEG_LIBERADO != "S")
            {

                /*" -1458- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA(2:1) = 'S' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Substring(2, 1) == "S")
                {

                    /*" -1459- MOVE 1807 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1807, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1460- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -1461- MOVE 'SIM' TO WS-TEM-ERRO-1807 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1807);

                    /*" -1467- PERFORM R3700-00-INSERT-RELATORIOS. */

                    R3700_00_INSERT_RELATORIOS_SECTION();
                }

            }


            /*" -1468- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 9341 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 9341)
            {

                /*" -1469- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA(3:1) = 'S' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Substring(3, 1) == "S")
                {

                    /*" -1470- MOVE 1803 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1803, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1471- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -1472- MOVE 'SIM' TO WS-TEM-ERRO-1807 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1807);

                    /*" -1478- PERFORM R3700-00-INSERT-RELATORIOS. */

                    R3700_00_INSERT_RELATORIOS_SECTION();
                }

            }


            /*" -1479- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 9341 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 9341)
            {

                /*" -1480- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA(5:1) = 'S' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Substring(5, 1) == "S")
                {

                    /*" -1481- MOVE 1803 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1803, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1482- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -1483- MOVE 'SIM' TO WS-TEM-ERRO-1807 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1807);

                    /*" -1485- PERFORM R3700-00-INSERT-RELATORIOS. */

                    R3700_00_INSERT_RELATORIOS_SECTION();
                }

            }


            /*" -1487- PERFORM R5634-00-SELECT-SEGUROS-PF-CBO. */

            R5634_00_SELECT_SEGUROS_PF_CBO_SECTION();

            /*" -1488- IF WHOST-PROFISSAO EQUAL SPACES */

            if (WHOST_PROFISSAO.IsEmpty())
            {

                /*" -1490- IF COD-CBO OF DCLPESSOA-FISICA > ZEROS AND COD-CBO OF DCLPESSOA-FISICA < 1000 */

                if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 00 && PESFIS.DCLPESSOA_FISICA.COD_CBO < 1000)
                {

                    /*" -1499- MOVE TAB-DESCR-CBO-C (COD-CBO OF DCLPESSOA-FISICA) TO WHOST-PROFISSAO. */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_27[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C, WHOST_PROFISSAO);
                }

            }


            /*" -1501- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9703 OR 9705 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9703", "9705"))
            {

                /*" -1509- GO TO R1000-CONSISTE-DPS. */

                R1000_CONSISTE_DPS(); //GOTO
                return;
            }


            /*" -1510- IF PROPOFID-COD-PRODUTO-SIVPF = 7 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 7)
            {

                /*" -1517- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -1518- IF WS-SEG-LIBERADO EQUAL 'S' */

            if (WS_SEG_LIBERADO == "S")
            {

                /*" -1524- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -1525- IF PROPOFID-COD-PRODUTO-SIVPF = 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -1532- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -1537- IF PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001391 OR (PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001392 ) OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001294 OR PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300000598 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001391 || (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001392) || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001294 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300000598)
            {

                /*" -1539- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -1540- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 46 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 46)
            {

                /*" -1542- IF PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ >= '2008-04-17' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA >= "2008-04-17")
                {

                    /*" -1543- INITIALIZE WHOST-IMPMORNATU */
                    _.Initialize(
                        WHOST_IMPMORNATU
                    );

                    /*" -1544- PERFORM R1401-00-SELECT-PLANOS-VA */

                    R1401_00_SELECT_PLANOS_VA_SECTION();

                    /*" -1545- IF WHOST-IMPMORNATU <= 30000,00 */

                    if (WHOST_IMPMORNATU <= 30000.00)
                    {

                        /*" -1560- GO TO R1000-CONSISTE-CX-TRAB. */

                        R1000_CONSISTE_CX_TRAB(); //GOTO
                        return;
                    }

                }

            }


            /*" -1562- PERFORM R5634-00-SELECT-SEGUROS-PF-CBO. */

            R5634_00_SELECT_SEGUROS_PF_CBO_SECTION();

            /*" -1564- IF COD-CBO OF DCLPESSOA-FISICA EQUAL ZEROS AND WHOST-PROFISSAO EQUAL SPACES */

            if (PESFIS.DCLPESSOA_FISICA.COD_CBO == 00 && WHOST_PROFISSAO.IsEmpty())
            {

                /*" -1565- MOVE 1811 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1811, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -1566- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -1567- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -1568- ELSE */
            }
            else
            {


                /*" -1571- IF WHOST-PROFISSAO EQUAL SPACES OR WHOST-PROFISSAO EQUAL 'PROFISSAO NAO QUALIFICADA' OR WHOST-PROFISSAO EQUAL 'PROFISSAO NAO ENCONTRADA' */

                if (WHOST_PROFISSAO.IsEmpty() || WHOST_PROFISSAO == "PROFISSAO NAO QUALIFICADA" || WHOST_PROFISSAO == "PROFISSAO NAO ENCONTRADA")
                {

                    /*" -1573- IF COD-CBO OF DCLPESSOA-FISICA > ZEROS AND COD-CBO OF DCLPESSOA-FISICA < 1000 */

                    if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 00 && PESFIS.DCLPESSOA_FISICA.COD_CBO < 1000)
                    {

                        /*" -1575- MOVE TAB-DESCR-CBO-C (COD-CBO OF DCLPESSOA-FISICA) TO WHOST-PROFISSAO */
                        _.Move(TAB_CBO1.TAB_CBO.FILLER_27[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C, WHOST_PROFISSAO);

                        /*" -1576- ELSE */
                    }
                    else
                    {


                        /*" -1579- DISPLAY 'CBO INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' COD-CBO OF DCLPESSOA-FISICA */

                        $"CBO INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PESFIS.DCLPESSOA_FISICA.COD_CBO}"
                        .Display();

                        /*" -1580- MOVE SPACES TO WHOST-PROFISSAO */
                        _.Move("", WHOST_PROFISSAO);

                        /*" -1581- MOVE 1811 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1811, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -1582- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -1583- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                        _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                        /*" -1584- END-IF */
                    }


                    /*" -1604- IF WHOST-PROFISSAO(1:5) EQUAL 'POLIC' OR 'DELEG' OR 'MILIT' OR 'VIGIA' OR 'VIGIL' OR 'SEGUR' OR 'PILOT' OR 'INSTR' OR 'PARAQ' OR 'MOTOB' OR 'MOTOC' OR 'MOTOQ' OR 'MERGU' OR 'ALPIN' OR 'AGENT' OR 'PERIT' OR 'SERVE' OR 'APOSE' OR 'OUTRO' */

                    if (WHOST_PROFISSAO.Substring(1, 5).In("POLIC", "DELEG", "MILIT", "VIGIA", "VIGIL", "SEGUR", "PILOT", "INSTR", "PARAQ", "MOTOB", "MOTOC", "MOTOQ", "MERGU", "ALPIN", "AGENT", "PERIT", "SERVE", "APOSE", "OUTRO"))
                    {

                        /*" -1605- MOVE 1802 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1802, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -1606- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -1607- END-IF */
                    }


                    /*" -1608- ELSE */
                }
                else
                {


                    /*" -1628- IF WHOST-PROFISSAO(1:5) EQUAL 'POLIC' OR 'DELEG' OR 'MILIT' OR 'VIGIA' OR 'VIGIL' OR 'SEGUR' OR 'PILOT' OR 'INSTR' OR 'PARAQ' OR 'MOTOB' OR 'MOTOC' OR 'MOTOQ' OR 'MERGU' OR 'ALPIN' OR 'AGENT' OR 'PERIT' OR 'SERVE' OR 'APOSE' OR 'OUTRO' */

                    if (WHOST_PROFISSAO.Substring(1, 5).In("POLIC", "DELEG", "MILIT", "VIGIA", "VIGIL", "SEGUR", "PILOT", "INSTR", "PARAQ", "MOTOB", "MOTOC", "MOTOQ", "MERGU", "ALPIN", "AGENT", "PERIT", "SERVE", "APOSE", "OUTRO"))
                    {

                        /*" -1629- MOVE 1802 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1802, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -1630- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -1631- END-IF */
                    }


                    /*" -1632- END-IF */
                }


                /*" -1634- END-IF */
            }


            /*" -1635- IF PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA = 109300001666 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 109300001666)
            {

                /*" -1635- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_CONSISTE_DPS */

            R1000_CONSISTE_DPS();

        }

        [StopWatch]
        /*" R1000-CONSISTE-DPS */
        private void R1000_CONSISTE_DPS(bool isPerform = false)
        {
            /*" -1650- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 7 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 7)
            {

                /*" -1654- IF PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ >= '2008-04-17' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA >= "2008-04-17")
                {

                    /*" -1656- GO TO R1000-CONSISTE-CX-TRAB. */

                    R1000_CONSISTE_CX_TRAB(); //GOTO
                    return;
                }

            }


            /*" -1657- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 9348 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 9348)
            {

                /*" -1743- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -1744- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -1745- PERFORM R1150-00-IDADE-CONJUGE */

                R1150_00_IDADE_CONJUGE_SECTION();

                /*" -1746- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 46 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 46)
                {

                    /*" -1747- IF WHOST-IDADE-CONJUGE GREATER 70 */

                    if (WHOST_IDADE_CONJUGE > 70)
                    {

                        /*" -1748- MOVE 1865 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1865, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -1749- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -1750- END-IF */
                    }


                    /*" -1751- ELSE */
                }
                else
                {


                    /*" -1752- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 13 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 13)
                    {

                        /*" -1753- IF WHOST-IDADE-CONJUGE GREATER 65 */

                        if (WHOST_IDADE_CONJUGE > 65)
                        {

                            /*" -1754- MOVE 1851 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1851, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -1755- PERFORM R1100-00-INSERT-ERROSPROPVA */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();

                            /*" -1756- END-IF */
                        }


                        /*" -1757- END-IF */
                    }


                    /*" -1758- END-IF */
                }


                /*" -1758- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-CONSISTE-CX-TRAB */
        private void R1000_CONSISTE_CX_TRAB(bool isPerform = false)
        {
            /*" -1779- MOVE 'R1000-00-CONSISTE-CX-TRAB   ' TO PARAGRAFO. */
            _.Move("R1000-00-CONSISTE-CX-TRAB   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1783- IF PROPOFID-CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ NOT EQUAL ZEROS AND PRODUVG-DESCONTO-ADESAO OF DCLPRODUTOS-VG GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE != 00 && PRODUVG.DCLPRODUTOS_VG.PRODUVG_DESCONTO_ADESAO > 00)
            {

                /*" -1784- MOVE ZEROS TO VIND-CGC-CONVENENTE */
                _.Move(0, VIND_CGC_CONVENENTE);

                /*" -1785- PERFORM R1200-00-SELECT-ESTIPULANTE */

                R1200_00_SELECT_ESTIPULANTE_SECTION();

                /*" -1786- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1787- MOVE 1702 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1702, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1788- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -1789- END-IF */
                }


                /*" -1790- ELSE */
            }
            else
            {


                /*" -1795- MOVE -1 TO VIND-CGC-CONVENENTE. */
                _.Move(-1, VIND_CGC_CONVENENTE);
            }


            /*" -1798- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO LPARM01, W-NRMATRICULA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, LPARM01, W_NRMATRICULA);

            /*" -1800- CALL 'PRODIGCX' USING LPARM01, LPARM03. */
            _.Call("PRODIGCX", LPARM01, LPARM03);

            /*" -1801- IF LPARM01 EQUAL ALL '9' */

            if (LPARM01.All("9"))
            {

                /*" -1802- DISPLAY '*----------------------------------------------*' */
                _.Display($"*----------------------------------------------*");

                /*" -1803- DISPLAY '* VA2601B - PROBLEMAS CALL SUBROTINA PRODIGCX  *' */
                _.Display($"* VA2601B - PROBLEMAS CALL SUBROTINA PRODIGCX  *");

                /*" -1804- DISPLAY '*----------------------------------------------*' */
                _.Display($"*----------------------------------------------*");

                /*" -1806- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1807- IF LPARM03 NOT EQUAL W-DV-MATRICULA */

            if (LPARM03 != FILLER_1.W_DV_MATRICULA)
            {

                /*" -1809- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO W-NRMATRICULA1 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, FILLER_1.W_NRMATRICULA1);

                /*" -1810- MOVE LPARM03 TO W-DV-MATRICULA */
                _.Move(LPARM03, FILLER_1.W_DV_MATRICULA);

                /*" -1813- MOVE W-NRMATRICULA TO PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ */
                _.Move(W_NRMATRICULA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

                /*" -1815- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO LPARM01 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, LPARM01);

                /*" -1817- CALL 'PRODIGCX' USING LPARM01, LPARM03 */
                _.Call("PRODIGCX", LPARM01, LPARM03);

                /*" -1818- IF LPARM01 EQUAL ALL '9' */

                if (LPARM01.All("9"))
                {

                    /*" -1820- DISPLAY '*---------------------------------------------*' */
                    _.Display($"*---------------------------------------------*");

                    /*" -1822- DISPLAY '* VA2601B - PROBLEMAS CALL SUBROTINA PRODIGCX *' */
                    _.Display($"* VA2601B - PROBLEMAS CALL SUBROTINA PRODIGCX *");

                    /*" -1824- DISPLAY '*---------------------------------------------*' */
                    _.Display($"*---------------------------------------------*");

                    /*" -1825- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1827- END-IF */
                }


                /*" -1828- MOVE LPARM03 TO W-DV-MATRICULA */
                _.Move(LPARM03, FILLER_1.W_DV_MATRICULA);

                /*" -1831- MOVE W-NRMATRICULA TO PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ. */
                _.Move(W_NRMATRICULA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);
            }


            /*" -1832- PERFORM R1300-00-SELECT-FUNCIOCEF. */

            R1300_00_SELECT_FUNCIOCEF_SECTION();

            /*" -1833- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1834- IF PROPOFID-ORIGEM-PROPOSTA NOT = 1000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA != 1000)
                {

                    /*" -1835- MOVE 1302 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1302, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1836- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -1837- END-IF */
                }


                /*" -1838- ELSE */
            }
            else
            {


                /*" -1842- IF FUNCICEF-TIPO-VINCULO OF DCLFUNCIONARIOS-CEF EQUAL 'EMPREGADO CEF' AND FUNCICEF-SITUACAO OF DCLFUNCIONARIOS-CEF NOT EQUAL '0' */

                if (FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_TIPO_VINCULO == "EMPREGADO CEF" && FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_SITUACAO != "0")
                {

                    /*" -1843- MOVE 1303 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1303, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1847- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();
                }

            }


            /*" -1850- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO RCAPS-NUM-TITULO OF DCLRCAPS. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -1852- MOVE ZERO TO W-RCAPS. */
            _.Move(0, WORK_AREA.W_RCAPS);

            /*" -1854- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -1856- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_26[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -1857- ELSE */
            }
            else
            {


                /*" -1860- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -1861- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -1863- END-IF. */
            }


            /*" -1865- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -1867- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -1869- MOVE WHOST-FONTE TO RCAPS-COD-FONTE OF DCLRCAPS. */
            _.Move(WHOST_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);

            /*" -1871- PERFORM R1500-00-SELECT-RCAPS. */

            R1500_00_SELECT_RCAPS_SECTION();

            /*" -1872- IF NOT RCAP-CADASTRADO */

            if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -1882- MOVE ZEROS TO RCAPS-COD-FONTE OF DCLRCAPS RCAPS-NUM-RCAP OF DCLRCAPS RCAPS-VAL-RCAP OF DCLRCAPS RCAPCOMP-BCO-AVISO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-AGE-AVISO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-NUM-AVISO-CREDITO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-DATA-MOVIMENTO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);

                /*" -1885- IF PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'POB' NEXT SENTENCE */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "POB")
                {

                    /*" -1886- ELSE */
                }
                else
                {


                    /*" -1887- MOVE 1501 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1501, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1891- IF CANAL-GITEL AND PROPOFID-COD-PRODUTO-SIVPF = 11 OR 46 OR 77 NEXT SENTENCE */

                    if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("11", "46", "77"))
                    {

                        /*" -1892- ELSE */
                    }
                    else
                    {


                        /*" -1893- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -1894- PERFORM R1600-00-UPDATE-PROPFID */

                        R1600_00_UPDATE_PROPFID_SECTION();

                        /*" -1896- END-IF */
                    }


                    /*" -1897- IF WHOST-SIT-PROPOSTA EQUAL 'REJ' */

                    if (WHOST_SIT_PROPOSTA == "REJ")
                    {

                        /*" -1898- GO TO R1000-10-SAIDA */

                        R1000_10_SAIDA(); //GOTO
                        return;

                        /*" -1900- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1901- ELSE */
                    }

                }

            }
            else
            {


                /*" -1903- PERFORM R1510-00-SELECT-RCAPCOMP. */

                R1510_00_SELECT_RCAPCOMP_SECTION();
            }


            /*" -1904- IF RCAP-CADASTRADO */

            if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -1906- IF PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ = '0001-01-01' OR PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ = '1900-01-01' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO == "0001-01-01" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO == "1900-01-01")
                {

                    /*" -1909- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                }

            }


            /*" -1910- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -1913- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
            }


            /*" -1915- MOVE ZERO TO W-PLANO */
            _.Move(0, WORK_AREA.W_PLANO);

            /*" -1920- MOVE +0 TO VIND-IMPSEGAUXF VIND-VLCUSTAUXF VIND-PRMDIT VIND-QTDIT. */
            _.Move(+0, VIND_IMPSEGAUXF, VIND_VLCUSTAUXF, VIND_PRMDIT, VIND_QTDIT);

            /*" -1921- IF PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ = ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 00)
            {

                /*" -1922- IF PROPOFID-OPCAO-COBER OF DCLPROPOSTA-FIDELIZ = SPACES */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.IsEmpty())
                {

                    /*" -1923- MOVE 1844 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1844, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1925- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -1926- MOVE 1845 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1845, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -1928- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();
                }

            }


            /*" -1929- IF PROPOFID-COD-PRODUTO-SIVPF = 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -1930- PERFORM R1410-00-SELECT-PLANOS-VA */

                R1410_00_SELECT_PLANOS_VA_SECTION();

                /*" -1931- ELSE */
            }
            else
            {


                /*" -1932- PERFORM R1400-00-SELECT-PLANOS-VA */

                R1400_00_SELECT_PLANOS_VA_SECTION();

                /*" -1934- END-IF. */
            }


            /*" -1935- IF NOT EXISTE-PLANO */

            if (!WORK_AREA.W_PLANO["EXISTE_PLANO"])
            {

                /*" -1950- MOVE ZEROS TO IMPMORNATU OF DCLPLANOS-VA-VGAP, IMPMORACID OF DCLPLANOS-VA-VGAP, IMPINVPERM OF DCLPLANOS-VA-VGAP, IMPAMDS OF DCLPLANOS-VA-VGAP, IMPDH OF DCLPLANOS-VA-VGAP, IMPDIT OF DCLPLANOS-VA-VGAP, VLPREMIOTOT OF DCLPLANOS-VA-VGAP, PRMVG OF DCLPLANOS-VA-VGAP, PRMAP OF DCLPLANOS-VA-VGAP, QTTITCAP OF DCLPLANOS-VA-VGAP, VLTITCAP OF DCLPLANOS-VA-VGAP, VLCUSTCAP OF DCLPLANOS-VA-VGAP, IMPSEGCDG OF DCLPLANOS-VA-VGAP, VLCUSTCDG OF DCLPLANOS-VA-VGAP */
                _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);

                /*" -1955- MOVE -1 TO VIND-IMPSEGAUXF, VIND-VLCUSTAUXF, VIND-PRMDIT, VIND-QTDIT */
                _.Move(-1, VIND_IMPSEGAUXF, VIND_VLCUSTAUXF, VIND_PRMDIT, VIND_QTDIT);

                /*" -1956- MOVE 604 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(604, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -1958- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                R1100_00_INSERT_ERROSPROPVA_SECTION();
            }


            /*" -1959- IF EXISTE-PLANO */

            if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
            {

                /*" -1961- DIVIDE VLPREMIOTOT OF DCLPLANOS-VA-VGAP BY 2 GIVING WS-VLPREMIOTOT-CCT */
                _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, 2, WORK_AREA.WS_VLPREMIOTOT_CCT);

                /*" -1962- ELSE */
            }
            else
            {


                /*" -1964- MOVE ZEROS TO WS-VLPREMIOTOT-CCT. */
                _.Move(0, WORK_AREA.WS_VLPREMIOTOT_CCT);
            }


            /*" -1966- IF PROPOFID-DATA-CREDITO EQUAL '0001-01-01' OR PROPOFID-DATA-CREDITO EQUAL '1901-01-01' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO == "0001-01-01" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO == "1901-01-01")
            {

                /*" -1967- IF NOT EXISTE-PLANO */

                if (!WORK_AREA.W_PLANO["EXISTE_PLANO"])
                {

                    /*" -1969- IF NOT RCAP-CADASTRADO NEXT SENTENCE */

                    if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                    {

                        /*" -1970- END-IF */
                    }


                    /*" -1972- END-IF */
                }


                /*" -1973- IF PROPOFID-VAL-PAGO EQUAL ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO == 00)
                {

                    /*" -1974- IF EXISTE-PLANO */

                    if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
                    {

                        /*" -1976- MOVE VLPREMIOTOT OF DCLPLANOS-VA-VGAP TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ */
                        _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                        /*" -1977- ELSE */
                    }
                    else
                    {


                        /*" -1979- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                        /*" -1980- END-IF */
                    }


                    /*" -1982- END-IF */
                }


                /*" -1984- PERFORM R1700-00-UPDATE-PRP-FIDELIZ. */

                R1700_00_UPDATE_PRP_FIDELIZ_SECTION();
            }


            /*" -1987- COMPUTE WHOST-PREMIO-1 = VLPREMIOTOT OF DCLPLANOS-VA-VGAP - 1 */
            WHOST_PREMIO_1.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT - 1;

            /*" -1990- COMPUTE WHOST-PREMIO-2 = VLPREMIOTOT OF DCLPLANOS-VA-VGAP + 1 */
            WHOST_PREMIO_2.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT + 1;

            /*" -1991- IF NOT CANAL-SASSE-FILIAL */

            if (!WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"])
            {

                /*" -1992- IF RCAP-CADASTRADO */

                if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                {

                    /*" -1993- IF EXISTE-PLANO */

                    if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
                    {

                        /*" -2001- IF (RCAPS-VAL-RCAP OF DCLRCAPS NOT EQUAL VLPREMIOTOT OF DCLPLANOS-VA-VGAP) AND (RCAPS-VAL-RCAP OF DCLRCAPS NOT EQUAL WS-VLPREMIOTOT-CCT) AND ((RCAPS-VAL-RCAP OF DCLRCAPS LESS WHOST-PREMIO-1 ) OR (RCAPS-VAL-RCAP OF DCLRCAPS GREATER WHOST-PREMIO-2 )) */

                        if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP != PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT) && (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP != WORK_AREA.WS_VLPREMIOTOT_CCT) && ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP < WHOST_PREMIO_1) || (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP > WHOST_PREMIO_2)))
                        {

                            /*" -2002- MOVE 1817 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1817, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2007- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();
                        }

                    }

                }

            }


            /*" -2010- IF PROPOFID-COD-PRODUTO-SIVPF = 77 OR CANAL-GITEL NEXT SENTENCE */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77 || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -2011- ELSE */
            }
            else
            {


                /*" -2012- PERFORM R2350-00-TRATA-ERRO-1864 */

                R2350_00_TRATA_ERRO_1864_SECTION();

                /*" -2020- END-IF. */
            }


            /*" -2021- INITIALIZE WS-NUM-PROPOSTA-AZUL. */
            _.Initialize(
                WS_NUM_PROPOSTA_AZUL
            );

            /*" -2024- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO WS-NUM-PROPOSTA-AZUL. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, WS_NUM_PROPOSTA_AZUL);

            /*" -2030- PERFORM R1000_CONSISTE_CX_TRAB_DB_SELECT_1 */

            R1000_CONSISTE_CX_TRAB_DB_SELECT_1();

            /*" -2033- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2034- MOVE 913 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(913, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2035- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2041- END-IF. */
            }


            /*" -2044- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9310 OR JVPRD9310 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -2045- IF IMPMORNATU OF DCLPLANOS-VA-VGAP GREATER 200000 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 200000)
                {

                    /*" -2046- MOVE 1829 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1829, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2047- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -2048- MOVE 'SIM' TO WS-TEM-ERRO-1829 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1829);

                    /*" -2049- END-IF */
                }


                /*" -2057- END-IF. */
            }


            /*" -2059- IF WHOST-IMPMORNATU-MAX GREATER ZEROS */

            if (WHOST_IMPMORNATU_MAX > 00)
            {

                /*" -2060- PERFORM R2241-00-SELECT-ACUM-RISCO */

                R2241_00_SELECT_ACUM_RISCO_SECTION();

                /*" -2061- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                {

                    /*" -2065- DISPLAY 'RISCO 77 ----> ' ' ' PROPOFID-NUM-PROPOSTA-SIVPF ' ' WHOST-IMPMORNATU-MAX ' ' AC-TOT-RISCO */

                    $"RISCO 77 ---->  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {WHOST_IMPMORNATU_MAX} {WORK_AREA.AC_TOT_RISCO}"
                    .Display();

                    /*" -2066- END-IF */
                }


                /*" -2067- IF PROPOFID-COD-PRODUTO-SIVPF NOT EQUAL 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF != 77)
                {

                    /*" -2068- IF AC-TOT-RISCO GREATER WHOST-IMPMORNATU-MAX */

                    if (WORK_AREA.AC_TOT_RISCO > WHOST_IMPMORNATU_MAX)
                    {

                        /*" -2069- MOVE 1852 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1852, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2072- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2073- MOVE 'SIM' TO WS-TEM-ERRO-1852 */
                        _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1852);

                        /*" -2082- PERFORM R3700-00-INSERT-RELATORIOS. */

                        R3700_00_INSERT_RELATORIOS_SECTION();
                    }

                }

            }


            /*" -2085- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9314 OR JVPRD9314 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString()))
            {

                /*" -2086- PERFORM R2250-00-SELECT-LIM-RENDA */

                R2250_00_SELECT_LIM_RENDA_SECTION();

                /*" -2109- END-IF. */
            }


            /*" -2111- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9310 OR JVPRD9310 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -2113- MOVE 5 TO PROPOFID-FAIXA-RENDA-IND PROPOFID-FAIXA-RENDA-FAM */
                _.Move(5, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

                /*" -2115- END-IF */
            }


            /*" -2123- IF ((PROPOFID-FAIXA-RENDA-IND EQUAL SPACES OR PROPOFID-FAIXA-RENDA-IND EQUAL LOW-VALUES OR PROPOFID-FAIXA-RENDA-IND LESS 1 OR PROPOFID-FAIXA-RENDA-IND GREATER 5 ) OR (PROPOFID-FAIXA-RENDA-FAM EQUAL SPACES OR PROPOFID-FAIXA-RENDA-FAM EQUAL LOW-VALUES OR PROPOFID-FAIXA-RENDA-FAM LESS 1 OR PROPOFID-FAIXA-RENDA-FAM GREATER 5 )) */

            if (((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.IsEmpty() || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.IsLowValues() || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND < 1 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND > 5) || (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.IsEmpty() || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.IsLowValues() || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM < 1 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM > 5)))
            {

                /*" -2124- MOVE 1875 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1875, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2125- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2126- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -2129- END-IF */
            }


            /*" -2130- IF PROPOFID-IND-TP-PROPOSTA EQUAL 'D' OR 'E' OR 'S' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA.In("D", "E", "S"))
            {

                /*" -2131- SET WS-PROP-ELETRONICA TO TRUE */
                WS_INSERE_ANDAMENTO["WS_PROP_ELETRONICA"] = true;

                /*" -2137- ELSE */
            }
            else
            {


                /*" -2138- IF WS-TEM-ERRO EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_ERRO == 00)
                {

                    /*" -2139- MOVE ZEROS TO WS-TEM-ERRO-ASS */
                    _.Move(0, WORK_AREA.WS_TEM_ERRO_ASS);

                    /*" -2140- ELSE */
                }
                else
                {


                    /*" -2141- MOVE 1 TO WS-TEM-ERRO-ASS */
                    _.Move(1, WORK_AREA.WS_TEM_ERRO_ASS);

                    /*" -2147- END-IF */
                }


                /*" -2149- IF NOT CANAL-GITEL */

                if (!WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
                {

                    /*" -2151- MOVE 1800 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1800, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2153- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -2157- END-IF */
                }


                /*" -2158- IF WS-TEM-ERRO-ASS EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_ERRO_ASS == 00)
                {

                    /*" -2159- MOVE ZEROS TO WS-TEM-ERRO */
                    _.Move(0, WORK_AREA.WS_TEM_ERRO);

                    /*" -2165- END-IF */
                }


                /*" -2169- END-IF */
            }


            /*" -2171- PERFORM R5632-00-SELECT-PROPOSTAVA. */

            R5632_00_SELECT_PROPOSTAVA_SECTION();

            /*" -2172- IF WEXISTE-PRPVA EQUAL 'SIM' */

            if (WEXISTE_PRPVA == "SIM")
            {

                /*" -2174- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '0' OR '1' OR '3' OR '7' OR '8' */

                if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO.In("0", "1", "3", "7", "8"))
                {

                    /*" -2175- PERFORM R5633-00-UPDATE-PRP-FIDELIZ */

                    R5633_00_UPDATE_PRP_FIDELIZ_SECTION();

                    /*" -2188- GO TO R1000-10-SAIDA. */

                    R1000_10_SAIDA(); //GOTO
                    return;
                }

            }


            /*" -2190- PERFORM R2400-00-TRATA-ENDERECOS. */

            R2400_00_TRATA_ENDERECOS_SECTION();

            /*" -2191- IF WHOST-EMAIL NOT EQUAL SPACES */

            if (!WHOST_EMAIL.IsEmpty())
            {

                /*" -2193- PERFORM R2500-00-TRATA-EMAIL. */

                R2500_00_TRATA_EMAIL_SECTION();
            }


            /*" -2194- IF WWORK-TIPO-MOVIMENTO NOT EQUAL SPACES */

            if (!W_GECLIMOV.WWORK_TIPO_MOVIMENTO.IsEmpty())
            {

                /*" -2198- PERFORM R9300-00-TRATA-MOVTO-CLIENTE. */

                R9300_00_TRATA_MOVTO_CLIENTE_SECTION();
            }


            /*" -2199- IF WEXISTE-PRPVA EQUAL 'NAO' */

            if (WEXISTE_PRPVA == "NAO")
            {

                /*" -2200- PERFORM R3000-00-INSERT-PROPOSTAVA */

                R3000_00_INSERT_PROPOSTAVA_SECTION();

                /*" -2201- ELSE */
            }
            else
            {


                /*" -2202- PERFORM R5635-00-UPDATE-PROPOSTAVA */

                R5635_00_UPDATE_PROPOSTAVA_SECTION();

                /*" -2204- END-IF */
            }


            /*" -2205- IF WS-INSERE-ANDAMENTO EQUAL 'S' */

            if (WS_INSERE_ANDAMENTO == "S")
            {

                /*" -2206- PERFORM R3020-00-INSERE-ANDAMENTO */

                R3020_00_INSERE_ANDAMENTO_SECTION();

                /*" -2208- END-IF */
            }


            /*" -2210- PERFORM R3100-00-INSERT-COBERPROPVA */

            R3100_00_INSERT_COBERPROPVA_SECTION();

            /*" -2212- PERFORM R3110-00-DECLARE-VGPLARAMCOB */

            R3110_00_DECLARE_VGPLARAMCOB_SECTION();

            /*" -2214- PERFORM R3150-00-DECLARE-VGPLAACES */

            R3150_00_DECLARE_VGPLAACES_SECTION();

            /*" -2217- MOVE CEP OF DCLPESSOA-ENDERECO TO CT0006S-CEP-DESTINO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CEP, CT0006S_LINKAGE.CT0006S_CEP_DESTINO);

            /*" -2220- MOVE SIGLA-UF OF DCLPESSOA-ENDERECO TO CT0006S-SIGLA-UF */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF, CT0006S_LINKAGE.CT0006S_SIGLA_UF);

            /*" -2223- MOVE SPACES TO CT0006S-MENSAGEM. */
            _.Move("", CT0006S_LINKAGE.CT0006S_MENSAGEM);

            /*" -2226- MOVE ZEROS TO CT0006S-SQLCODE. */
            _.Move(0, CT0006S_LINKAGE.CT0006S_SQLCODE);

            /*" -2250- CALL 'CT0006S' USING CT0006S-LINKAGE. */
            _.Call("CT0006S", CT0006S_LINKAGE);

            /*" -2251- IF PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ EQUAL 3 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == 3)
            {

                /*" -2252- PERFORM R1250-00-SELECT-OPCAOPAGVA */

                R1250_00_SELECT_OPCAOPAGVA_SECTION();

                /*" -2253- IF OPCPAGVI-NUM-CARTAO-CREDITO EQUAL ZEROS */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO == 00)
                {

                    /*" -2254- MOVE 1853 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1853, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2255- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -2256- ELSE */
                }
                else
                {


                    /*" -2258- MOVE OPCPAGVI-NUM-CARTAO-CREDITO TO W-NUM-CARTAO-CREDITO */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, W_NUM_CARTAO_CREDITO);

                    /*" -2268- IF W-NUM-CARTAO-CREDITO (1:6) = 400236 OR 400636 OR 402383 OR 479395 OR 400770 OR 400970 OR 401370 OR 403236 OR 432989 OR 433589 OR 434389 OR 510447 OR 518767 OR 539016 OR 539017 OR 539018 OR 544816 OR 544817 OR 544818 OR 548826 OR 548827 OR 549316 OR 549317 OR 549318 OR 554932 OR 557768 */

                    if (W_NUM_CARTAO_CREDITO.Substring(1, 6).In("400236", "400636", "402383", "479395", "400770", "400970", "401370", "403236", "432989", "433589", "434389", "510447", "518767", "539016", "539017", "539018", "544816", "544817", "544818", "548826", "548827", "549316", "549317", "549318", "554932", "557768"))
                    {

                        /*" -2269- IF OPCPAGVI-NUM-CONTA-DEBITO EQUAL ZEROES */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO == 00)
                        {

                            /*" -2270- MOVE 1854 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1854, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2271- PERFORM R1100-00-INSERT-ERROSPROPVA */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();

                            /*" -2272- END-IF */
                        }


                        /*" -2273- ELSE */
                    }
                    else
                    {


                        /*" -2274- MOVE 1853 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1853, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2275- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2276- END-IF */
                    }


                    /*" -2277- END-IF */
                }


                /*" -2283- END-IF. */
            }


            /*" -2284- IF PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ NOT EQUAL 3 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG != 3)
            {

                /*" -2285- PERFORM R3200-00-INSERT-OPCAOPAGVA */

                R3200_00_INSERT_OPCAOPAGVA_SECTION();

                /*" -2286- PERFORM R3400-00-INSERT-PARCELVA */

                R3400_00_INSERT_PARCELVA_SECTION();

                /*" -2287- PERFORM R3500-00-INSERT-HISTCOBVA */

                R3500_00_INSERT_HISTCOBVA_SECTION();

                /*" -2288- PERFORM R3520-00-INSERT-HISTCONTAVA */

                R3520_00_INSERT_HISTCONTAVA_SECTION();

                /*" -2290- END-IF. */
            }


            /*" -2291- IF RCAP-CADASTRADO */

            if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -2293- IF COBRANCA-EMITIDA NEXT SENTENCE */

                if (WORK_AREA.W_COBRANCA["COBRANCA_EMITIDA"])
                {

                    /*" -2294- ELSE */
                }
                else
                {


                    /*" -2295- PERFORM R3300-00-INSERT-COMISICOBVA */

                    R3300_00_INSERT_COMISICOBVA_SECTION();

                    /*" -2296- IF WEXISTE-COMISSAO EQUAL 'NAO' */

                    if (WEXISTE_COMISSAO == "NAO")
                    {

                        /*" -2297- PERFORM R3400-00-INSERT-PARCELVA */

                        R3400_00_INSERT_PARCELVA_SECTION();

                        /*" -2298- PERFORM R3500-00-INSERT-HISTCOBVA */

                        R3500_00_INSERT_HISTCOBVA_SECTION();

                        /*" -2299- IF PROPOFID-DATA-PROPOSTA GREATER '2010-12-31' */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA > "2010-12-31")
                        {

                            /*" -2300- PERFORM R3600-00-INSERT-HISTCONTABILVA */

                            R3600_00_INSERT_HISTCONTABILVA_SECTION();

                            /*" -2301- PERFORM R7900-00-DECLARE-VGRAMOCOMP */

                            R7900_00_DECLARE_VGRAMOCOMP_SECTION();

                            /*" -2302- PERFORM R7910-00-FETCH-VGRAMOCOMP */

                            R7910_00_FETCH_VGRAMOCOMP_SECTION();

                            /*" -2303- INITIALIZE WORK-TAB-RAMO-CONJ */
                            _.Initialize(
                                WORK_TAB_RAMO_CONJ
                            );

                            /*" -2306- MOVE ZEROS TO WS-IND WHOST-VLR-PERC-PREMIO-TOT WS-PREMIO-TOTAL-AC */
                            _.Move(0, WORK_RAMO_CONJ.WS_IND, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT, WS_PREMIO_TOTAL_AC);

                            /*" -2309- COMPUTE WS-PREMIO-TOTAL = RCAPS-VAL-RCAP + PREMIO-AP OF DCLHIST-CONT-PARCELVA */
                            WS_PREMIO_TOTAL.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP + HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP;

                            /*" -2312- PERFORM R8000-00-PROCESSA-VGRAMOCOMP UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' */

                            while (!(WORK_AREA.WFIM_VGRAMOCOMP == "SIM"))
                            {

                                R8000_00_PROCESSA_VGRAMOCOMP_SECTION();
                            }

                            /*" -2313- IF WS-IND GREATER ZEROS */

                            if (WORK_RAMO_CONJ.WS_IND > 00)
                            {

                                /*" -2314- IF WHOST-RAMO NOT EQUAL TB-RAMO-CONJ (WS-IND) */

                                if (WHOST_RAMO != WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ)
                                {

                                    /*" -2315- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND) TO WS-SALVA */
                                    _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND], WORK_RAMO_CONJ.WS_SALVA);

                                    /*" -2319- PERFORM VARYING WS-IND1 FROM 1 BY 1 UNTIL TB-RAMO-CONJ (WS-IND1) EQUAL WHOST-RAMO OR WS-IND1 EQUAL WS-IND */

                                    for (WORK_RAMO_CONJ.WS_IND1.Value = 1; !(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ == WHOST_RAMO || WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND); WORK_RAMO_CONJ.WS_IND1.Value += 1)
                                    {

                                        /*" -2320- END-PERFORM */
                                    }

                                    /*" -2322- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND1) TO N5WORK-TAB-RAMO-CONJ(WS-IND) */
                                    _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1], WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND]);

                                    /*" -2324- MOVE WS-SALVA TO N5WORK-TAB-RAMO-CONJ(WS-IND1) */
                                    _.Move(WORK_RAMO_CONJ.WS_SALVA, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1]);

                                    /*" -2325- END-IF */
                                }


                                /*" -2327- END-IF */
                            }


                            /*" -2328- MOVE 'NAO' TO WFIM-TAB-RAMO */
                            _.Move("NAO", WORK_AREA.WFIM_TAB_RAMO);

                            /*" -2329- MOVE ZEROS TO WS-IND1 */
                            _.Move(0, WORK_RAMO_CONJ.WS_IND1);

                            /*" -2332- PERFORM R8200-00-INSERT-VGHISTCONT UNTIL WFIM-TAB-RAMO EQUAL 'SIM' . */

                            while (!(WORK_AREA.WFIM_TAB_RAMO == "SIM"))
                            {

                                R8200_00_INSERT_VGHISTCONT_SECTION();
                            }
                        }

                    }

                }

            }


            /*" -2334- IF PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01)
            {

                /*" -2336- PERFORM R3700-00-INSERT-RELATORIOS. */

                R3700_00_INSERT_RELATORIOS_SECTION();
            }


            /*" -2338- IF PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -2339- MOVE 1846 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1846, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2340- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2342- PERFORM R3700-00-INSERT-RELATORIOS. */

                R3700_00_INSERT_RELATORIOS_SECTION();
            }


            /*" -2342- PERFORM R1600-00-UPDATE-PROPFID. */

            R1600_00_UPDATE_PROPFID_SECTION();

        }

        [StopWatch]
        /*" R1000-CONSISTE-CX-TRAB-DB-SELECT-1 */
        public void R1000_CONSISTE_CX_TRAB_DB_SELECT_1()
        {
            /*" -2030- EXEC SQL SELECT NUM_PROPOSTA_AZUL INTO :WS-NUM-PROPOSTA-AZUL FROM SEGUROS.BENEF_PROP_AZUL WHERE NUM_PROPOSTA_AZUL = :WS-NUM-PROPOSTA-AZUL AND GRAU_PARENTESCO = 'ERROPF' END-EXEC. */

            var r1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1 = new R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1()
            {
                WS_NUM_PROPOSTA_AZUL = WS_NUM_PROPOSTA_AZUL.ToString(),
            };

            var executed_1 = R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1.Execute(r1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_PROPOSTA_AZUL, WS_NUM_PROPOSTA_AZUL);
            }


        }

        [StopWatch]
        /*" R1000-10-SAIDA */
        private void R1000_10_SAIDA(bool isPerform = false)
        {
            /*" -2346- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-INSERT-ERROSPROPVA-SECTION */
        private void R1100_00_INSERT_ERROSPROPVA_SECTION()
        {
            /*" -2355- MOVE 1 TO WS-TEM-ERRO. */
            _.Move(1, WORK_AREA.WS_TEM_ERRO);

            /*" -2358- MOVE '1100-00-INSERT-ERROSPROPVA   ' TO PARAGRAFO. */
            _.Move("1100-00-INSERT-ERROSPROPVA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2359- MOVE 05 TO SII. */
            _.Move(05, WS_HORAS.SII);

            /*" -2360- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2365- PERFORM R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1 */

            R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1();

            /*" -2368- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2370- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -2371- DISPLAY 'PROBLEMAS NO INSERT A ERROS-PROP-VIDAZUL' */
                _.Display($"PROBLEMAS NO INSERT A ERROS-PROP-VIDAZUL");

                /*" -2371- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-INSERT-ERROSPROPVA-DB-INSERT-1 */
        public void R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1()
        {
            /*" -2365- EXEC SQL INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLERROS-PROP-VIDAZUL.COD-ERRO) END-EXEC. */

            var r1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 = new R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                COD_ERRO = ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO.ToString(),
            };

            R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1.Execute(r1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-IDADE-CONJUGE-SECTION */
        private void R1150_00_IDADE_CONJUGE_SECTION()
        {
            /*" -2382- MOVE '1150-00-IDADE-CONJUGE        ' TO PARAGRAFO. */
            _.Move("1150-00-IDADE-CONJUGE        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2383- IF VIND-DATA-NASC-CONJUGE LESS ZEROS */

            if (VIND_DATA_NASC_CONJUGE < 00)
            {

                /*" -2385- MOVE '0001-01-01' TO WS-DTNASC */
                _.Move("0001-01-01", WORK_AREA.WS_DTNASC);

                /*" -2386- ELSE */
            }
            else
            {


                /*" -2388- MOVE PROPOFID-DATA-NASC-CONJUGE OF DCLPROPOSTA-FIDELIZ TO WS-DTNASC. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE, WORK_AREA.WS_DTNASC);
            }


            /*" -2391- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -2394- COMPUTE WHOST-IDADE-CONJUGE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE_CONJUGE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -2395- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -2396- SUBTRACT 1 FROM WHOST-IDADE-CONJUGE */
                WHOST_IDADE_CONJUGE.Value = WHOST_IDADE_CONJUGE - 1;

                /*" -2397- ELSE */
            }
            else
            {


                /*" -2398- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -2399- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -2399- SUBTRACT 1 FROM WHOST-IDADE-CONJUGE. */
                        WHOST_IDADE_CONJUGE.Value = WHOST_IDADE_CONJUGE - 1;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-SECTION */
        private void R1200_00_SELECT_ESTIPULANTE_SECTION()
        {
            /*" -2408- MOVE '1200-00-SELECT-ESTIPULANTE   ' TO PARAGRAFO. */
            _.Move("1200-00-SELECT-ESTIPULANTE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2409- MOVE 06 TO SII. */
            _.Move(06, WS_HORAS.SII);

            /*" -2410- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2417- PERFORM R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1 */

            R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1();

            /*" -2420- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2421- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2422- DISPLAY 'PROBLEMAS NO SELECT A ESTIPULANTE       ' */
                _.Display($"PROBLEMAS NO SELECT A ESTIPULANTE       ");

                /*" -2422- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-DB-SELECT-1 */
        public void R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -2417- EXEC SQL SELECT NOME_ESTIPULANTE INTO :DCLESTIPULANTE.ESTIPULA-NOME-ESTIPULANTE FROM SEGUROS.ESTIPULANTE WHERE COD_CCT = :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ESTIPULA_NOME_ESTIPULANTE, ESTIPULA.DCLESTIPULANTE.ESTIPULA_NOME_ESTIPULANTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-SELECT-OPCAOPAGVA-SECTION */
        private void R1250_00_SELECT_OPCAOPAGVA_SECTION()
        {
            /*" -2432- MOVE '1250-00-SELECT-OPCAOPAGVA   ' TO PARAGRAFO. */
            _.Move("1250-00-SELECT-OPCAOPAGVA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2433- MOVE 07 TO SII. */
            _.Move(07, WS_HORAS.SII);

            /*" -2434- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2450- PERFORM R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1 */

            R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1();

            /*" -2453- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2454- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2455- DISPLAY 'PROBLEMAS NO SELECT A OPCAOPAGVA       ' */
                _.Display($"PROBLEMAS NO SELECT A OPCAOPAGVA       ");

                /*" -2457- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2458- IF VIND-AGECTADEB LESS +0 */

            if (VIND_AGECTADEB < +0)
            {

                /*" -2460- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
            }


            /*" -2461- IF VIND-OPRCTADEB LESS +0 */

            if (VIND_OPRCTADEB < +0)
            {

                /*" -2463- MOVE ZEROS TO OPCPAGVI-OPE-CONTA-DEBITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
            }


            /*" -2464- IF VIND-NUMCTADEB LESS +0 */

            if (VIND_NUMCTADEB < +0)
            {

                /*" -2466- MOVE ZEROS TO OPCPAGVI-NUM-CONTA-DEBITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
            }


            /*" -2467- IF VIND-DIGCTADEB LESS +0 */

            if (VIND_DIGCTADEB < +0)
            {

                /*" -2469- MOVE ZEROS TO OPCPAGVI-DIG-CONTA-DEBITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
            }


            /*" -2470- IF VIND-CARTAO LESS +0 */

            if (VIND_CARTAO < +0)
            {

                /*" -2471- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
            }


        }

        [StopWatch]
        /*" R1250-00-SELECT-OPCAOPAGVA-DB-SELECT-1 */
        public void R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -2450- EXEC SQL SELECT COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO INTO :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB , :OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPRCTADEB , :OPCPAGVI-NUM-CONTA-DEBITO :VIND-NUMCTADEB , :OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGCTADEB , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CARTAO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 = new R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_CARTAO, VIND_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-FUNCIOCEF-SECTION */
        private void R1300_00_SELECT_FUNCIOCEF_SECTION()
        {
            /*" -2480- MOVE '1300-00-SELECT-FUNCIOCEF     ' TO PARAGRAFO. */
            _.Move("1300-00-SELECT-FUNCIOCEF     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2481- MOVE 08 TO SII. */
            _.Move(08, WS_HORAS.SII);

            /*" -2482- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2488- PERFORM R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1 */

            R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1();

            /*" -2491- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2492- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2493- DISPLAY 'PROBLEMAS NO SELECT A FUNCIOCEF         ' */
                _.Display($"PROBLEMAS NO SELECT A FUNCIOCEF         ");

                /*" -2493- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-FUNCIOCEF-DB-SELECT-1 */
        public void R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1()
        {
            /*" -2488- EXEC SQL SELECT NOME_FUNCIONARIO INTO :DCLFUNCIONARIOS-CEF.FUNCICEF-NOME-FUNCIONARIO FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN END-EXEC. */

            var r1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1 = new R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1()
            {
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
            };

            var executed_1 = R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_NOME_FUNCIONARIO, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-SECTION */
        private void R1400_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -2503- MOVE '1400-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1400-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2504- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -2507- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -2510- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -2511- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -2512- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -2513- ELSE */
            }
            else
            {


                /*" -2514- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -2515- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -2517- SUBTRACT 1 FROM WHOST-IDADE. */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;
                    }

                }

            }


            /*" -2519- MOVE '1400-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1400-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2520- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -2521- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2571- PERFORM R1400_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1400_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -2574- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2576- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2578- DISPLAY 'VA2601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP' SQLCODE */
                    _.Display($"VA2601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP{DB.SQLCODE}");

                    /*" -2580- DISPLAY '          PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -2581- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2583- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -2584- ELSE */
                }

            }
            else
            {


                /*" -2586- MOVE 1 TO W-PLANO. */
                _.Move(1, WORK_AREA.W_PLANO);
            }


            /*" -2588- MOVE '1400-01-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1400-01-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2589- MOVE 10 TO SII. */
            _.Move(10, WS_HORAS.SII);

            /*" -2590- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2604- PERFORM R1400_00_SELECT_PLANOS_VA_DB_SELECT_2 */

            R1400_00_SELECT_PLANOS_VA_DB_SELECT_2();

            /*" -2605- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1400_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -2571- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIOTOT, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDG, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT INTO :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, :DCLPLANOS-VA-VGAP.IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);
                _.Move(executed_1.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS);
                _.Move(executed_1.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH);
                _.Move(executed_1.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT);
                _.Move(executed_1.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);
                _.Move(executed_1.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);
                _.Move(executed_1.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);
                _.Move(executed_1.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP);
                _.Move(executed_1.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP);
                _.Move(executed_1.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP);
                _.Move(executed_1.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG);
                _.Move(executed_1.VLCUSTCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);
                _.Move(executed_1.IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF);
                _.Move(executed_1.VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF);
                _.Move(executed_1.PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT);
                _.Move(executed_1.QTDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-DB-SELECT-2 */
        public void R1400_00_SELECT_PLANOS_VA_DB_SELECT_2()
        {
            /*" -2604- EXEC SQL SELECT VALUE (MAX(IMPMORNATU),0) INTO :WHOST-IMPMORNATU-MAX FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 = new R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1.Execute(r1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU_MAX, WHOST_IMPMORNATU_MAX);
            }


        }

        [StopWatch]
        /*" R1401-00-SELECT-PLANOS-VA-SECTION */
        private void R1401_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -2616- MOVE '1401-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1401-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2617- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -2620- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -2623- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -2624- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -2625- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -2626- ELSE */
            }
            else
            {


                /*" -2627- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -2628- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -2630- SUBTRACT 1 FROM WHOST-IDADE. */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;
                    }

                }

            }


            /*" -2632- MOVE '1401-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1401-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2633- MOVE 11 TO SII. */
            _.Move(11, WS_HORAS.SII);

            /*" -2634- PERFORM R9000-00-INICIO. */

            R9000_00_INICIO_SECTION();

            /*" -2650- PERFORM R1401_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1401_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -2653- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2655- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2657- DISPLAY 'VA2601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP' SQLCODE */
                    _.Display($"VA2601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP{DB.SQLCODE}");

                    /*" -2659- DISPLAY 'R1401  -  PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"R1401  -  PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -2660- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2661- ELSE */
                }
                else
                {


                    /*" -2667- DISPLAY 'R1401 NAO ENCONTROU PLANOS-VA-VGAP ' PROPSSVD-NUM-APOLICE ' ' PROPSSVD-COD-SUBGRUPO ' ' PROPOFID-OPCAO-COBER ' ' PROPOFID-DTQITBCO ' ' WHOST-IDADE. */

                    $"R1401 NAO ENCONTROU PLANOS-VA-VGAP {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE} {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO} {WHOST_IDADE}"
                    .Display();
                }

            }


        }

        [StopWatch]
        /*" R1401-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1401_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -2650- EXEC SQL SELECT VALUE (IMPMORNATU,0) INTO :WHOST-IMPMORNATU FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU, WHOST_IMPMORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1401_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-SECTION */
        private void R1410_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -2676- MOVE '1410-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1410-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2677- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -2680- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -2683- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -2684- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -2685- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -2686- ELSE */
            }
            else
            {


                /*" -2687- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -2688- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -2690- SUBTRACT 1 FROM WHOST-IDADE. */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;
                    }

                }

            }


            /*" -2692- MOVE '1410-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1410-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2693- MOVE 12 TO SII. */
            _.Move(12, WS_HORAS.SII);

            /*" -2694- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2746- PERFORM R1410_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1410_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -2749- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2750- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2751- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2753- DISPLAY 'VA2601B - ERRO NO SELECT PLANOS_VA_VGAP' SQLCODE */
                    _.Display($"VA2601B - ERRO NO SELECT PLANOS_VA_VGAP{DB.SQLCODE}");

                    /*" -2755- DISPLAY '          PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -2756- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2758- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -2759- ELSE */
                }

            }
            else
            {


                /*" -2761- MOVE 1 TO W-PLANO. */
                _.Move(1, WORK_AREA.W_PLANO);
            }


            /*" -2763- MOVE '1410-01-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1410-01-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2764- MOVE 13 TO SII. */
            _.Move(13, WS_HORAS.SII);

            /*" -2765- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2783- PERFORM R1410_00_SELECT_PLANOS_VA_DB_SELECT_2 */

            R1410_00_SELECT_PLANOS_VA_DB_SELECT_2();

            /*" -2784- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1410_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -2746- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIOTOT, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDG, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT INTO :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, :DCLPLANOS-VA-VGAP.IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);
                _.Move(executed_1.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS);
                _.Move(executed_1.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH);
                _.Move(executed_1.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT);
                _.Move(executed_1.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);
                _.Move(executed_1.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);
                _.Move(executed_1.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);
                _.Move(executed_1.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP);
                _.Move(executed_1.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP);
                _.Move(executed_1.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP);
                _.Move(executed_1.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG);
                _.Move(executed_1.VLCUSTCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);
                _.Move(executed_1.IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF);
                _.Move(executed_1.VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF);
                _.Move(executed_1.PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT);
                _.Move(executed_1.QTDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-DB-SELECT-2 */
        public void R1410_00_SELECT_PLANOS_VA_DB_SELECT_2()
        {
            /*" -2783- EXEC SQL SELECT VALUE (MAX(IMPMORNATU),0) INTO :WHOST-IMPMORNATU-MAX FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 = new R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1.Execute(r1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU_MAX, WHOST_IMPMORNATU_MAX);
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-RCAPS-SECTION */
        private void R1500_00_SELECT_RCAPS_SECTION()
        {
            /*" -2794- MOVE '1500-00-SELECT-RCAPS         ' TO PARAGRAFO. */
            _.Move("1500-00-SELECT-RCAPS         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2795- MOVE 14 TO SII. */
            _.Move(14, WS_HORAS.SII);

            /*" -2796- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2806- PERFORM R1500_00_SELECT_RCAPS_DB_SELECT_1 */

            R1500_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -2809- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2811- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2814- PERFORM R1505-00-SELECT-RCAPS */

                R1505_00_SELECT_RCAPS_SECTION();

                /*" -2815- ELSE */
            }
            else
            {


                /*" -2815- MOVE 1 TO W-RCAPS. */
                _.Move(1, WORK_AREA.W_RCAPS);
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1500_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -2806- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO AND COD_FONTE =:DCLRCAPS.RCAPS-COD-FONTE END-EXEC. */

            var r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1505-00-SELECT-RCAPS-SECTION */
        private void R1505_00_SELECT_RCAPS_SECTION()
        {
            /*" -2825- MOVE '1505-00-SELECT-RCAPS         ' TO PARAGRAFO. */
            _.Move("1505-00-SELECT-RCAPS         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2826- MOVE 15 TO SII. */
            _.Move(15, WS_HORAS.SII);

            /*" -2827- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2836- PERFORM R1505_00_SELECT_RCAPS_DB_SELECT_1 */

            R1505_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -2839- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2840- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2841- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2842- DISPLAY 'VA2601B - PROBLEMAS NO ACESSO A RCAP' */
                    _.Display($"VA2601B - PROBLEMAS NO ACESSO A RCAP");

                    /*" -2844- DISPLAY '          NUMERO DO TITULO......... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                    _.Display($"          NUMERO DO TITULO......... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -2846- DISPLAY '          SQLCODE.................. ' SQLCODE */
                    _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                    /*" -2847- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2849- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -2850- ELSE */
                }

            }
            else
            {


                /*" -2850- MOVE 1 TO W-RCAPS. */
                _.Move(1, WORK_AREA.W_RCAPS);
            }


        }

        [StopWatch]
        /*" R1505-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1505_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -2836- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO END-EXEC. */

            var r1505_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1505_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1505_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-SECTION */
        private void R1510_00_SELECT_RCAPCOMP_SECTION()
        {
            /*" -2860- MOVE '1510-00-SELECT-RCAP COMP     ' TO PARAGRAFO. */
            _.Move("1510-00-SELECT-RCAP COMP     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2861- MOVE 16 TO SII. */
            _.Move(16, WS_HORAS.SII);

            /*" -2862- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2878- PERFORM R1510_00_SELECT_RCAPCOMP_DB_SELECT_1 */

            R1510_00_SELECT_RCAPCOMP_DB_SELECT_1();

            /*" -2881- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2883- IF SQLCODE EQUAL ZEROS NEXT SENTENCE */

            if (DB.SQLCODE == 00)
            {

                /*" -2884- ELSE */
            }
            else
            {


                /*" -2886- IF SQLCODE NOT EQUAL 100 AND SQLCODE NOT EQUAL -811 */

                if (DB.SQLCODE != 100 && DB.SQLCODE != -811)
                {

                    /*" -2887- DISPLAY 'VA2601B - PROBLEMAS NO ACESSO A RCAPCOMP' */
                    _.Display($"VA2601B - PROBLEMAS NO ACESSO A RCAPCOMP");

                    /*" -2889- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                    _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                    /*" -2891- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                    _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                    /*" -2893- DISPLAY '          SQLCODE...................... ' SQLCODE */
                    _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                    /*" -2894- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2895- ELSE */
                }
                else
                {


                    /*" -2910- PERFORM R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1();

                    /*" -2913- MOVE 17 TO SII */
                    _.Move(17, WS_HORAS.SII);

                    /*" -2914- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -2914- PERFORM R1510_00_SELECT_RCAPCOMP_DB_OPEN_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_OPEN_1();

                    /*" -2917- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -2918- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2919- DISPLAY 'VA2601B - PROBLEMAS NO OPEN DA RCAPCOMP' */
                        _.Display($"VA2601B - PROBLEMAS NO OPEN DA RCAPCOMP");

                        /*" -2921- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -2923- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -2925- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -2926- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2928- END-IF */
                    }


                    /*" -2929- MOVE 18 TO SII */
                    _.Move(18, WS_HORAS.SII);

                    /*" -2930- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -2941- PERFORM R1510_00_SELECT_RCAPCOMP_DB_FETCH_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_FETCH_1();

                    /*" -2944- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -2945- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2946- DISPLAY 'VA2601B - ERRO, RCAPCOMP NAO CADASTRADO' */
                        _.Display($"VA2601B - ERRO, RCAPCOMP NAO CADASTRADO");

                        /*" -2948- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -2950- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -2952- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -2953- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2955- END-IF */
                    }


                    /*" -2955- PERFORM R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1();

                    /*" -2958- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2959- DISPLAY 'VA2601B - PROBLEMAS NO CLOSE DA RCAPCOMP' */
                        _.Display($"VA2601B - PROBLEMAS NO CLOSE DA RCAPCOMP");

                        /*" -2961- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -2963- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -2965- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -2965- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-SELECT-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_SELECT_1()
        {
            /*" -2878- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 END-EXEC. */

            var r1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 = new R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1.Execute(r1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-OPEN-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_OPEN_1()
        {
            /*" -2914- EXEC SQL OPEN C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-DECLARE-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1()
        {
            /*" -3302- EXEC SQL DECLARE CPESENDER CURSOR FOR SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND TIPO_ENDER = 2 AND OCORR_ENDERECO = :DCLPESSOA-ENDERECO.OCORR-ENDERECO ORDER BY OCORR_ENDERECO DESC END-EXEC. */
            CPESENDER = new VA2601B_CPESENDER(true);
            string GetQuery_CPESENDER()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							CEP
							, 
							SIGLA_UF 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							AND TIPO_ENDER = 2 
							AND OCORR_ENDERECO = 
							'{PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO}' 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            CPESENDER.GetQueryEvent += GetQuery_CPESENDER;

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-FETCH-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_FETCH_1()
        {
            /*" -2941- EXEC SQL FETCH C01_RCAPCOMP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-COD-OPERACAO END-EXEC */

            if (C01_RCAPCOMP.Fetch())
            {
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-CLOSE-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1()
        {
            /*" -2955- EXEC SQL CLOSE C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-UPDATE-PROPFID-SECTION */
        private void R1600_00_UPDATE_PROPFID_SECTION()
        {
            /*" -2977- MOVE '1600-00-UPDATE-PROPFID       ' TO PARAGRAFO. */
            _.Move("1600-00-UPDATE-PROPFID       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2984- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -2985- MOVE 'REJ' TO WHOST-SIT-PROPOSTA */
                _.Move("REJ", WHOST_SIT_PROPOSTA);

                /*" -2986- MOVE 'S' TO WHOST-SIT-ENVIO */
                _.Move("S", WHOST_SIT_ENVIO);

                /*" -2987- ELSE */
            }
            else
            {


                /*" -2988- IF WS-TEM-ERRO EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_ERRO == 00)
                {

                    /*" -2989- MOVE 'PAI' TO WHOST-SIT-PROPOSTA */
                    _.Move("PAI", WHOST_SIT_PROPOSTA);

                    /*" -2990- MOVE ' ' TO WHOST-SIT-ENVIO */
                    _.Move(" ", WHOST_SIT_ENVIO);

                    /*" -2991- ELSE */
                }
                else
                {


                    /*" -2992- MOVE 'S' TO WHOST-SIT-ENVIO */
                    _.Move("S", WHOST_SIT_ENVIO);

                    /*" -2993- IF RCAP-CADASTRADO */

                    if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                    {

                        /*" -2994- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                        _.Move("PEN", WHOST_SIT_PROPOSTA);

                        /*" -2995- ELSE */
                    }
                    else
                    {


                        /*" -3003- MOVE 'POB' TO WHOST-SIT-PROPOSTA. */
                        _.Move("POB", WHOST_SIT_PROPOSTA);
                    }

                }

            }


            /*" -3006- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -3019- MOVE PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-ORIGEM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, WORK_AREA.W_ORIGEM_PROPOSTA);

            /*" -3020- MOVE 19 TO SII */
            _.Move(19, WS_HORAS.SII);

            /*" -3021- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3030- PERFORM R1600_00_UPDATE_PROPFID_DB_UPDATE_1 */

            R1600_00_UPDATE_PROPFID_DB_UPDATE_1();

            /*" -3033- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3034- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3035- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID      ' */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID      ");

                /*" -3035- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-UPDATE-PROPFID-DB-UPDATE-1 */
        public void R1600_00_UPDATE_PROPFID_DB_UPDATE_1()
        {
            /*" -3030- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO, NRMATRVEN = :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN, COD_USUARIO = 'VA2601B' , DTQITBCO = :WHOST-DATA-AGENDAMENTO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 = new R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                WHOST_DATA_AGENDAMENTO = WHOST_DATA_AGENDAMENTO.ToString(),
                WHOST_SIT_PROPOSTA = WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WHOST_SIT_ENVIO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1.Execute(r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-UPDATE-PRP-FIDELIZ-SECTION */
        private void R1700_00_UPDATE_PRP_FIDELIZ_SECTION()
        {
            /*" -3048- MOVE '1700-00-UPDATE-PRP-FIDELIZ   ' TO PARAGRAFO. */
            _.Move("1700-00-UPDATE-PRP-FIDELIZ   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3049- MOVE 20 TO SII */
            _.Move(20, WS_HORAS.SII);

            /*" -3050- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3062- PERFORM R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1 */

            R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -3065- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3066- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3067- DISPLAY 'VA2601B - PROPOSTA-FIDELIZ NAO FOI ATUALIZADA   ' */
                _.Display($"VA2601B - PROPOSTA-FIDELIZ NAO FOI ATUALIZADA   ");

                /*" -3068- DISPLAY '          SERA ATUALIZADA NO PF0002B.           ' */
                _.Display($"          SERA ATUALIZADA NO PF0002B.           ");

                /*" -3077- DISPLAY '          NUM PROPOSTA........................  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '          DTQITBCO / DATA-RCAP................  ' RCAPCOMP-DATA-RCAP '          DATA CREDITO / DATA MOVIMENTO RCAP..  ' RCAPCOMP-DATA-MOVIMENTO '          VALOR PAGO..........................  ' PROPOFID-VAL-PAGO '          SQLCODE.............................  ' SQLCODE. */

                $"          NUM PROPOSTA........................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}          DTQITBCO / DATA-RCAP................  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP}          DATA CREDITO / DATA MOVIMENTO RCAP..  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO}          VALOR PAGO..........................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO}          SQLCODE.............................  {DB.SQLCODE}"
                .Display();
            }


        }

        [StopWatch]
        /*" R1700-00-UPDATE-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -3062- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DTQITBCO = :WHOST-DATA-AGENDAMENTO, DATA_CREDITO = :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, VAL_PAGO = :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF AND SIT_PROPOSTA IN ( 'ENV' , 'POV' , 'DEC' ) END-EXEC. */

            var r1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                WHOST_DATA_AGENDAMENTO = WHOST_DATA_AGENDAMENTO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R2203-00-SELECT-CONDITEC-SECTION */
        private void R2203_00_SELECT_CONDITEC_SECTION()
        {
            /*" -3088- MOVE '2203-00-SELECT-CONDITEC      ' TO PARAGRAFO. */
            _.Move("2203-00-SELECT-CONDITEC      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3090- MOVE 'SELECT SEGUROS.CONDICOES_TECNICAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.CONDICOES_TECNICAS", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3091- MOVE 21 TO SII */
            _.Move(21, WS_HORAS.SII);

            /*" -3092- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3100- PERFORM R2203_00_SELECT_CONDITEC_DB_SELECT_1 */

            R2203_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -3103- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3104- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3104- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2203-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R2203_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -3100- EXEC SQL SELECT CARREGA_CONJUGE INTO :CONDITEC-CARREGA-CONJUGE FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND COD_SUBGRUPO = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO END-EXEC. */

            var r2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2203_99_SAIDA*/

        [StopWatch]
        /*" R2205-00-SELECT-HISTCOBVA-SECTION */
        private void R2205_00_SELECT_HISTCOBVA_SECTION()
        {
            /*" -3114- MOVE '2205-00-SELECT-HISTCOBVA     ' TO PARAGRAFO. */
            _.Move("2205-00-SELECT-HISTCOBVA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3116- MOVE 'SELECT SEGUROS.COBER_HIST_VIDAZUL' TO COMANDO. */
            _.Move("SELECT SEGUROS.COBER_HIST_VIDAZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3119- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO NUM-TITULO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);

            /*" -3120- MOVE 22 TO SII */
            _.Move(22, WS_HORAS.SII);

            /*" -3121- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3127- PERFORM R2205_00_SELECT_HISTCOBVA_DB_SELECT_1 */

            R2205_00_SELECT_HISTCOBVA_DB_SELECT_1();

            /*" -3130- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3131- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3131- MOVE 1 TO W-COBRANCA. */
                _.Move(1, WORK_AREA.W_COBRANCA);
            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-HISTCOBVA-DB-SELECT-1 */
        public void R2205_00_SELECT_HISTCOBVA_DB_SELECT_1()
        {
            /*" -3127- EXEC SQL SELECT NUM_TITULO INTO :DCLCOBER-HIST-VIDAZUL.NUM-TITULO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_TITULO = :DCLCOBER-HIST-VIDAZUL.NUM-TITULO END-EXEC. */

            var r2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 = new R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1()
            {
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
            };

            var executed_1 = R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1.Execute(r2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_TITULO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2205_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-PESSOA-SECTION */
        private void R2200_00_SELECT_PESSOA_SECTION()
        {
            /*" -3139- MOVE '2200-00-SELECT-PESSOA        ' TO PARAGRAFO. */
            _.Move("2200-00-SELECT-PESSOA        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3142- MOVE 'SELECT SEGUROS.PESSOA        ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3143- MOVE 23 TO SII */
            _.Move(23, WS_HORAS.SII);

            /*" -3144- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3150- PERFORM R2200_00_SELECT_PESSOA_DB_SELECT_1 */

            R2200_00_SELECT_PESSOA_DB_SELECT_1();

            /*" -3152- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3153- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3154- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3155- DISPLAY 'PESSOA FISICA NAO CADASTRADA ' */
                    _.Display($"PESSOA FISICA NAO CADASTRADA ");

                    /*" -3156- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3157- ELSE */
                }
                else
                {


                    /*" -3158- DISPLAY 'PROBLEMAS ACESSO PESSOA FISICA ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA FISICA ");

                    /*" -3158- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-PESSOA-DB-SELECT-1 */
        public void R2200_00_SELECT_PESSOA_DB_SELECT_1()
        {
            /*" -3150- EXEC SQL SELECT NOME_PESSOA INTO :DCLPESSOA.PESSOA-NOME-PESSOA FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1 = new R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-SELECT-PESSOA-FISICA-SECTION */
        private void R2210_00_SELECT_PESSOA_FISICA_SECTION()
        {
            /*" -3167- MOVE '2210-00-SELECT-PESSOA-FISICA ' TO PARAGRAFO. */
            _.Move("2210-00-SELECT-PESSOA-FISICA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3170- MOVE 'SELECT SEGUROS.PESSOA_FISICA ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_FISICA ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3171- MOVE 24 TO SII */
            _.Move(24, WS_HORAS.SII);

            /*" -3172- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3196- PERFORM R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1 */

            R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1();

            /*" -3198- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3199- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3200- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3201- DISPLAY 'PESSOA FISICA NAO CADASTRADA ' */
                    _.Display($"PESSOA FISICA NAO CADASTRADA ");

                    /*" -3202- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3203- ELSE */
                }
                else
                {


                    /*" -3204- DISPLAY 'PROBLEMAS ACESSO PESSOA FISICA ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA FISICA ");

                    /*" -3204- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2210-00-SELECT-PESSOA-FISICA-DB-SELECT-1 */
        public void R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -3196- EXEC SQL SELECT CPF, DATA_NASCIMENTO, SEXO, COD_CBO, ESTADO_CIVIL, ORGAO_EXPEDIDOR, NUM_IDENTIDADE, DATA_EXPEDICAO, UF_EXPEDIDORA INTO :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.DATA-EXPEDICAO :VIND-DATA-EXPEDICAO, :DCLPESSOA-FISICA.UF-EXPEDIDORA :VIND-UF-EXPEDIDORA FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 = new R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
                _.Move(executed_1.DATA_NASCIMENTO, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
                _.Move(executed_1.SEXO, PESFIS.DCLPESSOA_FISICA.SEXO);
                _.Move(executed_1.COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);
                _.Move(executed_1.ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DATA_EXPEDICAO, VIND_DATA_EXPEDICAO);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXPEDIDORA, VIND_UF_EXPEDIDORA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2215-00-SELECT-PROPOVA-SECTION */
        private void R2215_00_SELECT_PROPOVA_SECTION()
        {
            /*" -3213- MOVE '2215-00-SELECT-PROPOVA       ' TO PARAGRAFO. */
            _.Move("2215-00-SELECT-PROPOVA       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3216- MOVE 'SELECT SEGUROS.PROPOSTAS_VA  ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PROPOSTAS_VA  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3217- MOVE 25 TO SII */
            _.Move(25, WS_HORAS.SII);

            /*" -3218- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3224- PERFORM R2215_00_SELECT_PROPOVA_DB_SELECT_1 */

            R2215_00_SELECT_PROPOVA_DB_SELECT_1();

            /*" -3226- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3227- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3229- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -3230- ELSE */
                }
                else
                {


                    /*" -3231- DISPLAY 'PROBLEMAS ACESSO PROPOSTAS_VA  ' */
                    _.Display($"PROBLEMAS ACESSO PROPOSTAS_VA  ");

                    /*" -3232- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2215-00-SELECT-PROPOVA-DB-SELECT-1 */
        public void R2215_00_SELECT_PROPOVA_DB_SELECT_1()
        {
            /*" -3224- EXEC SQL SELECT OCOREND INTO :DCLPROPOSTAS-VA.OCOREND FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1 = new R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1.Execute(r2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCOREND, PROPVA.DCLPROPOSTAS_VA.OCOREND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-SECTION */
        private void R2220_00_OBTER_ENDERECO_CORRES_SECTION()
        {
            /*" -3240- MOVE '2220-00-SELECT-PESSOA-ENDER  ' TO PARAGRAFO. */
            _.Move("2220-00-SELECT-PESSOA-ENDER  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3243- MOVE 'SELECT  PESSOA_ENDERECO ' TO COMANDO. */
            _.Move("SELECT  PESSOA_ENDERECO ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3244- MOVE 26 TO SII */
            _.Move(26, WS_HORAS.SII);

            /*" -3245- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3263- PERFORM R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1 */

            R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1();

            /*" -3265- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3266- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3267- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3268- MOVE 2 TO W-ENDERECO */
                    _.Move(2, WORK_AREA.W_ENDERECO);

                    /*" -3269- GO TO R2220-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/ //GOTO
                    return;

                    /*" -3270- ELSE */
                }
                else
                {


                    /*" -3271- DISPLAY 'PROBLEMAS ACESSO PESSOA ENDER  ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA ENDER  ");

                    /*" -3273- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3274- MOVE 1 TO W-ENDERECO. */
            _.Move(1, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-DB-SELECT-1 */
        public void R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1()
        {
            /*" -3263- EXEC SQL SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND OCORR_ENDERECO = :DCLPROPOSTAS-VA.OCOREND END-EXEC. */

            var r2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1 = new R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                OCOREND = PROPVA.DCLPROPOSTAS_VA.OCOREND.ToString(),
            };

            var executed_1 = R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1.Execute(r2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(executed_1.BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(executed_1.CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(executed_1.CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(executed_1.SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-SECTION */
        private void R2222_00_OBTER_ENDERECO_CORRES_SECTION()
        {
            /*" -3281- MOVE '2222-00-SELECT-PESSOA-ENDER  ' TO PARAGRAFO. */
            _.Move("2222-00-SELECT-PESSOA-ENDER  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3284- MOVE 'DECLARE PESSOA_ENDERECO CORRESPONDENCIA' TO COMANDO. */
            _.Move("DECLARE PESSOA_ENDERECO CORRESPONDENCIA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3288- MOVE PROPOFID-DIGCTAVEN OF DCLPROPOSTA-FIDELIZ TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -3302- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1();

            /*" -3305- MOVE 27 TO SII */
            _.Move(27, WS_HORAS.SII);

            /*" -3306- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3306- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1();

            /*" -3308- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3309- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3310- MOVE 2 TO W-ENDERECO */
                _.Move(2, WORK_AREA.W_ENDERECO);

                /*" -3311- GO TO R2222-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/ //GOTO
                return;

                /*" -3312- ELSE */
            }
            else
            {


                /*" -3313- MOVE 'FETCH CPESENDER              ' TO COMANDO */
                _.Move("FETCH CPESENDER              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -3321- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1 */

                R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1();

                /*" -3323- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3324- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -3324- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1 */

                        R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1();

                        /*" -3326- MOVE 2 TO W-ENDERECO */
                        _.Move(2, WORK_AREA.W_ENDERECO);

                        /*" -3327- GO TO R2222-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/ //GOTO
                        return;

                        /*" -3328- ELSE */
                    }
                    else
                    {


                        /*" -3329- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                        _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                        /*" -3331- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3331- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2();

            /*" -3334- MOVE 1 TO W-ENDERECO. */
            _.Move(1, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-OPEN-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1()
        {
            /*" -3306- EXEC SQL OPEN CPESENDER END-EXEC. */

            CPESENDER.Open();

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-DECLARE-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1()
        {
            /*" -3356- EXEC SQL DECLARE CPESENDERR CURSOR FOR SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA ORDER BY OCORR_ENDERECO DESC END-EXEC. */
            CPESENDERR = new VA2601B_CPESENDERR(true);
            string GetQuery_CPESENDERR()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							CEP
							, 
							SIGLA_UF 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            CPESENDERR.GetQueryEvent += GetQuery_CPESENDERR;

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-FETCH-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1()
        {
            /*" -3321- EXEC SQL FETCH CPESENDER INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            if (CPESENDER.Fetch())
            {
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-CLOSE-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1()
        {
            /*" -3324- EXEC SQL CLOSE CPESENDER END-EXEC */

            CPESENDER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-CLOSE-2 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2()
        {
            /*" -3331- EXEC SQL CLOSE CPESENDER END-EXEC. */

            CPESENDER.Close();

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-SECTION */
        private void R2225_00_OBTER_DEMAIS_ENDERECO_SECTION()
        {
            /*" -3342- MOVE '2225-00-OBTER-OUTRO-ENDERECO ' TO PARAGRAFO. */
            _.Move("2225-00-OBTER-OUTRO-ENDERECO ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3345- MOVE 'DECLARE PESSOA_ENDERECO - OUTRO ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA_ENDERECO - OUTRO ENDERECO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3356- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1();

            /*" -3359- MOVE 28 TO SII */
            _.Move(28, WS_HORAS.SII);

            /*" -3360- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3360- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1();

            /*" -3362- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3364- MOVE 4 TO W-ENDERECO */
                _.Move(4, WORK_AREA.W_ENDERECO);

                /*" -3365- GO TO R2225-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/ //GOTO
                return;

                /*" -3366- ELSE */
            }
            else
            {


                /*" -3367- MOVE 'FETCH CPESENDERR             ' TO COMANDO */
                _.Move("FETCH CPESENDERR             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -3375- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1 */

                R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1();

                /*" -3377- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3378- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -3378- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1 */

                        R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1();

                        /*" -3380- MOVE 4 TO W-ENDERECO */
                        _.Move(4, WORK_AREA.W_ENDERECO);

                        /*" -3381- GO TO R2225-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/ //GOTO
                        return;

                        /*" -3382- ELSE */
                    }
                    else
                    {


                        /*" -3383- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                        _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                        /*" -3385- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3385- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2();

            /*" -3388- MOVE 3 TO W-ENDERECO. */
            _.Move(3, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-OPEN-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1()
        {
            /*" -3360- EXEC SQL OPEN CPESENDERR END-EXEC. */

            CPESENDERR.Open();

        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-DB-DECLARE-1 */
        public void R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1()
        {
            /*" -3570- EXEC SQL DECLARE CFONE CURSOR FOR SELECT TIPO_FONE, DDD, NUM_FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA ORDER BY TIPO_FONE END-EXEC. */
            CFONE = new VA2601B_CFONE(true);
            string GetQuery_CFONE()
            {
                var query = @$"SELECT TIPO_FONE
							, 
							DDD
							, 
							NUM_FONE 
							FROM SEGUROS.PESSOA_TELEFONE 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							ORDER BY TIPO_FONE";

                return query;
            }
            CFONE.GetQueryEvent += GetQuery_CFONE;

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-FETCH-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1()
        {
            /*" -3375- EXEC SQL FETCH CPESENDERR INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            if (CPESENDERR.Fetch())
            {
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-CLOSE-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1()
        {
            /*" -3378- EXEC SQL CLOSE CPESENDERR END-EXEC */

            CPESENDERR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-CLOSE-2 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2()
        {
            /*" -3385- EXEC SQL CLOSE CPESENDERR END-EXEC. */

            CPESENDERR.Close();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-SECTION */
        private void R2230_00_SELECT_PESSOA_FONE_SECTION()
        {
            /*" -3401- MOVE '2230-00-SELECT-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2230-00-SELECT-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3404- MOVE 'SELECT PESSOA_TELEFONE 1' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 1", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3405- MOVE 29 TO SII */
            _.Move(29, WS_HORAS.SII);

            /*" -3406- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3416- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1();

            /*" -3419- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3420- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3421- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3423- MOVE ZEROS TO WHOST-DDD-RESIDENCIAL WHOST-FONE-RESIDENCIAL */
                    _.Move(0, WHOST_DDD_RESIDENCIAL, WHOST_FONE_RESIDENCIAL);

                    /*" -3424- ELSE */
                }
                else
                {


                    /*" -3426- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -3427- ELSE */
                    }
                    else
                    {


                        /*" -3428- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 1' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 1");

                        /*" -3430- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3433- MOVE 'SELECT PESSOA_TELEFONE 2' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 2", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3434- MOVE 30 TO SII */
            _.Move(30, WS_HORAS.SII);

            /*" -3435- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3445- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2();

            /*" -3448- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3449- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3450- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3452- MOVE ZEROS TO WHOST-DDD-COMERCIAL WHOST-FONE-COMERCIAL */
                    _.Move(0, WHOST_DDD_COMERCIAL, WHOST_FONE_COMERCIAL);

                    /*" -3453- ELSE */
                }
                else
                {


                    /*" -3455- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -3456- ELSE */
                    }
                    else
                    {


                        /*" -3457- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 2' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 2");

                        /*" -3459- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3462- MOVE 'SELECT PESSOA_TELEFONE 3' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 3", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3463- MOVE 31 TO SII */
            _.Move(31, WS_HORAS.SII);

            /*" -3464- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3474- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3();

            /*" -3477- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3478- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3479- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3481- MOVE ZEROS TO WHOST-DDD-CELULAR WHOST-FONE-CELULAR */
                    _.Move(0, WHOST_DDD_CELULAR, WHOST_FONE_CELULAR);

                    /*" -3482- ELSE */
                }
                else
                {


                    /*" -3484- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -3485- ELSE */
                    }
                    else
                    {


                        /*" -3486- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 3' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 3");

                        /*" -3488- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3491- MOVE 'SELECT PESSOA_TELEFONE 4' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 4", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3492- MOVE 32 TO SII */
            _.Move(32, WS_HORAS.SII);

            /*" -3493- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3503- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4();

            /*" -3506- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3507- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3508- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3510- MOVE ZEROS TO WHOST-DDD-FAX WHOST-FONE-FAX */
                    _.Move(0, WHOST_DDD_FAX, WHOST_FONE_FAX);

                    /*" -3511- ELSE */
                }
                else
                {


                    /*" -3513- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -3514- ELSE */
                    }
                    else
                    {


                        /*" -3515- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 4' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 4");

                        /*" -3517- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3518- IF WHOST-DDD-RESIDENCIAL > 0 */

            if (WHOST_DDD_RESIDENCIAL > 0)
            {

                /*" -3519- MOVE WHOST-DDD-RESIDENCIAL TO WHOST-DDD */
                _.Move(WHOST_DDD_RESIDENCIAL, WHOST_DDD);

                /*" -3520- ELSE */
            }
            else
            {


                /*" -3521- IF WHOST-DDD-COMERCIAL > 0 */

                if (WHOST_DDD_COMERCIAL > 0)
                {

                    /*" -3522- MOVE WHOST-DDD-COMERCIAL TO WHOST-DDD */
                    _.Move(WHOST_DDD_COMERCIAL, WHOST_DDD);

                    /*" -3523- ELSE */
                }
                else
                {


                    /*" -3524- IF WHOST-DDD-CELULAR > 0 */

                    if (WHOST_DDD_CELULAR > 0)
                    {

                        /*" -3525- MOVE WHOST-DDD-CELULAR TO WHOST-DDD */
                        _.Move(WHOST_DDD_CELULAR, WHOST_DDD);

                        /*" -3526- ELSE */
                    }
                    else
                    {


                        /*" -3527- IF WHOST-DDD-FAX > 0 */

                        if (WHOST_DDD_FAX > 0)
                        {

                            /*" -3528- MOVE WHOST-DDD-FAX TO WHOST-DDD */
                            _.Move(WHOST_DDD_FAX, WHOST_DDD);

                            /*" -3529- ELSE */
                        }
                        else
                        {


                            /*" -3530- MOVE ZEROS TO WHOST-DDD */
                            _.Move(0, WHOST_DDD);

                            /*" -3531- END-IF */
                        }


                        /*" -3532- END-IF */
                    }


                    /*" -3533- END-IF */
                }


                /*" -3535- END-IF. */
            }


            /*" -3536- IF WHOST-FONE-COMERCIAL > 0 */

            if (WHOST_FONE_COMERCIAL > 0)
            {

                /*" -3537- MOVE WHOST-FONE-COMERCIAL TO WHOST-FONE */
                _.Move(WHOST_FONE_COMERCIAL, WHOST_FONE);

                /*" -3538- ELSE */
            }
            else
            {


                /*" -3539- MOVE WHOST-FONE-RESIDENCIAL TO WHOST-FONE */
                _.Move(WHOST_FONE_RESIDENCIAL, WHOST_FONE);

                /*" -3541- END-IF */
            }


            /*" -3543- MOVE WHOST-FONE-CELULAR TO WHOST-TELEX. */
            _.Move(WHOST_FONE_CELULAR, WHOST_TELEX);

            /*" -3544- MOVE WHOST-FONE-FAX TO WHOST-FAX. */
            _.Move(WHOST_FONE_FAX, WHOST_FAX);

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-1 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1()
        {
            /*" -3416- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-RESIDENCIAL, :WHOST-FONE-RESIDENCIAL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' AND TIPO_FONE = 1 END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_RESIDENCIAL, WHOST_DDD_RESIDENCIAL);
                _.Move(executed_1.WHOST_FONE_RESIDENCIAL, WHOST_FONE_RESIDENCIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-2 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2()
        {
            /*" -3445- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-COMERCIAL, :WHOST-FONE-COMERCIAL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' AND TIPO_FONE = 2 END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_COMERCIAL, WHOST_DDD_COMERCIAL);
                _.Move(executed_1.WHOST_FONE_COMERCIAL, WHOST_FONE_COMERCIAL);
            }


        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-SECTION */
        private void R2232_00_SELECT_PESSOA_FONE_SECTION()
        {
            /*" -3552- MOVE '2232-00-SELECT-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2232-00-SELECT-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3556- MOVE ZEROS TO WHOST-DDD WHOST-FONE WHOST-FAX. */
            _.Move(0, WHOST_DDD, WHOST_FONE, WHOST_FAX);

            /*" -3558- MOVE 'DECLARE CURSOR PESSOA_TELEFONE' TO COMANDO. */
            _.Move("DECLARE CURSOR PESSOA_TELEFONE", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3560- MOVE ZEROS TO WS-CONTA-FONE */
            _.Move(0, WS_CONTA_FONE);

            /*" -3561- MOVE 33 TO SII */
            _.Move(33, WS_HORAS.SII);

            /*" -3562- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3570- PERFORM R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1 */

            R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1();

            /*" -3573- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3573- PERFORM R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1 */

            R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1();

            /*" -3575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3576- DISPLAY 'PROBLEMAS NO DECLARE PESSOA TELEFONE ' */
                _.Display($"PROBLEMAS NO DECLARE PESSOA TELEFONE ");

                /*" -3576- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2232_10_FETCH_PESSOA_FONE */

            R2232_10_FETCH_PESSOA_FONE();

        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-DB-OPEN-1 */
        public void R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1()
        {
            /*" -3573- EXEC SQL OPEN CFONE END-EXEC. */

            CFONE.Open();

        }

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-DB-DECLARE-1 */
        public void R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1()
        {
            /*" -3768- EXEC SQL DECLARE CRISCO CURSOR FOR SELECT A.NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.CLIENTES B, SEGUROS.PRODUTOS_VG C WHERE C.NOME_PRODUTO = :DCLPRODUTOS-VG.PRODUVG-NOME-PRODUTO AND B.CGCCPF = :DCLPESSOA-FISICA.CPF AND A.COD_CLIENTE = B.COD_CLIENTE AND A.NUM_APOLICE = C.NUM_APOLICE AND A.COD_SUBGRUPO = C.COD_SUBGRUPO AND A.SIT_REGISTRO IN ( '0' , '3' , '6' , '7' , '8' , '9' , 'E' ) END-EXEC. */
            CRISCO = new VA2601B_CRISCO(true);
            string GetQuery_CRISCO()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.CLIENTES B
							, 
							SEGUROS.PRODUTOS_VG C 
							WHERE C.NOME_PRODUTO = 
							'{PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO}' 
							AND B.CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND A.COD_CLIENTE = B.COD_CLIENTE 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.COD_SUBGRUPO = C.COD_SUBGRUPO 
							AND A.SIT_REGISTRO IN ( '0'
							, '3'
							, '6'
							, '7'
							, '8'
							, '9'
							, 'E' )";

                return query;
            }
            CRISCO.GetQueryEvent += GetQuery_CRISCO;

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-3 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3()
        {
            /*" -3474- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-CELULAR, :WHOST-FONE-CELULAR FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' AND TIPO_FONE = 3 END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_CELULAR, WHOST_DDD_CELULAR);
                _.Move(executed_1.WHOST_FONE_CELULAR, WHOST_FONE_CELULAR);
            }


        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE */
        private void R2232_10_FETCH_PESSOA_FONE(bool isPerform = false)
        {
            /*" -3581- MOVE 'FETCH CFONE                  ' TO COMANDO. */
            _.Move("FETCH CFONE                  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3586- PERFORM R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1 */

            R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1();

            /*" -3589- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3590- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3590- PERFORM R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1 */

                    R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1();

                    /*" -3595- IF WS-CONTA-FONE EQUAL ZEROS */

                    if (WS_CONTA_FONE == 00)
                    {

                        /*" -3596- MOVE 1874 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1874, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -3597- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -3598- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                        _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                        /*" -3599- END-IF */
                    }


                    /*" -3600- GO TO R2232-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2232_99_SAIDA*/ //GOTO
                    return;

                    /*" -3601- ELSE */
                }
                else
                {


                    /*" -3602- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                    _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                    /*" -3603- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3604- ELSE */
                }

            }
            else
            {


                /*" -3605- ADD 1 TO WS-CONTA-FONE */
                WS_CONTA_FONE.Value = WS_CONTA_FONE + 1;

                /*" -3613- END-IF. */
            }


            /*" -3614- IF TIPO-FONE EQUAL 1 OR 2 OR 3 */

            if (PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.In("1", "2", "3"))
            {

                /*" -3615- MOVE DDD OF DCLPESSOA-TELEFONE TO WHOST-DDD */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, WHOST_DDD);

                /*" -3616- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-FONE */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_FONE);

                /*" -3617- ELSE */
            }
            else
            {


                /*" -3619- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-FAX. */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_FAX);
            }


            /*" -3619- GO TO R2232-10-FETCH-PESSOA-FONE. */
            new Task(() => R2232_10_FETCH_PESSOA_FONE()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE-DB-FETCH-1 */
        public void R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1()
        {
            /*" -3586- EXEC SQL FETCH CFONE INTO :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE END-EXEC. */

            if (CFONE.Fetch())
            {
                _.Move(CFONE.DCLPESSOA_TELEFONE_TIPO_FONE, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);
                _.Move(CFONE.DCLPESSOA_TELEFONE_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);
                _.Move(CFONE.DCLPESSOA_TELEFONE_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);
            }

        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE-DB-CLOSE-1 */
        public void R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1()
        {
            /*" -3590- EXEC SQL CLOSE CFONE END-EXEC */

            CFONE.Close();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-4 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4()
        {
            /*" -3503- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-FAX, :WHOST-FONE-FAX FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' AND TIPO_FONE = 4 END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_FAX, WHOST_DDD_FAX);
                _.Move(executed_1.WHOST_FONE_FAX, WHOST_FONE_FAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2232_99_SAIDA*/

        [StopWatch]
        /*" R2235-00-UPDATE-PESSOA-FONE-SECTION */
        private void R2235_00_UPDATE_PESSOA_FONE_SECTION()
        {
            /*" -3628- MOVE '2235-00-UPDATE-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2235-00-UPDATE-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3631- MOVE 'UPDATE PESSOA_TELEFONE       ' TO COMANDO. */
            _.Move("UPDATE PESSOA_TELEFONE       ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3632- MOVE 34 TO SII */
            _.Move(34, WS_HORAS.SII);

            /*" -3633- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3638- PERFORM R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1 */

            R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1();

            /*" -3641- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3642- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3643- DISPLAY 'PROBLEMAS NO UPDATE  PESSOA TELEFONE ' */
                _.Display($"PROBLEMAS NO UPDATE  PESSOA TELEFONE ");

                /*" -3643- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2235-00-UPDATE-PESSOA-FONE-DB-UPDATE-1 */
        public void R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1()
        {
            /*" -3638- EXEC SQL UPDATE SEGUROS.PESSOA_TELEFONE SET SITUACAO_FONE = 'A' WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' END-EXEC. */

            var r2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1 = new R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1.Execute(r2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2235_99_SAIDA*/

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-SECTION */
        private void R2236_00_SELECT_PESSOA_EMAIL_SECTION()
        {
            /*" -3652- MOVE '2236-00-SELECT-PESSOA-EMAIL  ' TO PARAGRAFO. */
            _.Move("2236-00-SELECT-PESSOA-EMAIL  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3655- MOVE 'SELECT PESSOA_EMAIL     ' TO COMANDO. */
            _.Move("SELECT PESSOA_EMAIL     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3656- MOVE 35 TO SII */
            _.Move(35, WS_HORAS.SII);

            /*" -3657- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3664- PERFORM R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1 */

            R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1();

            /*" -3667- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3669- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3670- MOVE SPACES TO WHOST-EMAIL */
                    _.Move("", WHOST_EMAIL);

                    /*" -3671- GO TO R2236-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2236_99_SAIDA*/ //GOTO
                    return;

                    /*" -3672- ELSE */
                }
                else
                {


                    /*" -3674- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -3675- ELSE */
                    }
                    else
                    {


                        /*" -3676- DISPLAY 'PROBLEMAS NO SELECT  PESSOA EMAIL' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA EMAIL");

                        /*" -3678- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3681- MOVE 'UPDATE PESSOA_EMAIL     ' TO COMANDO. */
            _.Move("UPDATE PESSOA_EMAIL     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3682- MOVE 36 TO SII */
            _.Move(36, WS_HORAS.SII);

            /*" -3683- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3688- PERFORM R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1 */

            R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1();

            /*" -3691- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3692- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3693- DISPLAY 'PROBLEMAS NO UPDATE PESSOA EMAIL' */
                _.Display($"PROBLEMAS NO UPDATE PESSOA EMAIL");

                /*" -3694- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-DB-SELECT-1 */
        public void R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1()
        {
            /*" -3664- EXEC SQL SELECT EMAIL INTO :WHOST-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_EMAIL = 'P' END-EXEC. */

            var r2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1 = new R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1.Execute(r2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_EMAIL, WHOST_EMAIL);
            }


        }

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-DB-UPDATE-1 */
        public void R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1()
        {
            /*" -3688- EXEC SQL UPDATE SEGUROS.PESSOA_EMAIL SET SITUACAO_EMAIL = 'A' WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_EMAIL = 'P' END-EXEC. */

            var r2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1 = new R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1.Execute(r2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2236_99_SAIDA*/

        [StopWatch]
        /*" R2240-00-SELECT-PROPFIDC-SECTION */
        private void R2240_00_SELECT_PROPFIDC_SECTION()
        {
            /*" -3702- MOVE '2240-00-SELECT-PROPFIDC      ' TO PARAGRAFO. */
            _.Move("2240-00-SELECT-PROPFIDC      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3705- MOVE 'SELECT PROPFIDC               ' TO COMANDO. */
            _.Move("SELECT PROPFIDC               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3706- MOVE 37 TO SII */
            _.Move(37, WS_HORAS.SII);

            /*" -3707- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3714- PERFORM R2240_00_SELECT_PROPFIDC_DB_SELECT_1 */

            R2240_00_SELECT_PROPFIDC_DB_SELECT_1();

            /*" -3717- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3719- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3721- MOVE SPACES TO PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP */
                    _.Move("", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

                    /*" -3722- ELSE */
                }
                else
                {


                    /*" -3723- DISPLAY 'PROBLEMAS NO ACESSOA A PROPFIDC ' */
                    _.Display($"PROBLEMAS NO ACESSOA A PROPFIDC ");

                    /*" -3725- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3726- MOVE PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP TO WHOST-INFO-COMPL. */
            _.Move(PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL, WHOST_INFO_COMPL);

        }

        [StopWatch]
        /*" R2240-00-SELECT-PROPFIDC-DB-SELECT-1 */
        public void R2240_00_SELECT_PROPFIDC_DB_SELECT_1()
        {
            /*" -3714- EXEC SQL SELECT INFORMACAO_COMPL INTO :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL FROM SEGUROS.PROP_FIDELIZ_COMP WHERE NUM_IDENTIFICACAO = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO AND IND_TP_INFORMACAO = '1' END-EXEC. */

            var r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1 = new R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1()
            {
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1.Execute(r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROFIDCO_INFORMACAO_COMPL, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2240_99_SAIDA*/

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-SECTION */
        private void R2241_00_SELECT_ACUM_RISCO_SECTION()
        {
            /*" -3737- MOVE '2241-00-SELECT-ACUM-RISCO     ' TO PARAGRAFO. */
            _.Move("2241-00-SELECT-ACUM-RISCO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3754- MOVE IMPMORNATU OF DCLPLANOS-VA-VGAP TO AC-TOT-RISCO. */
            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WORK_AREA.AC_TOT_RISCO);

            /*" -3755- MOVE 'DECLARE CURSOR CRISCO         ' TO COMANDO. */
            _.Move("DECLARE CURSOR CRISCO         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3768- PERFORM R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1 */

            R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1();

            /*" -3771- MOVE 38 TO SII */
            _.Move(38, WS_HORAS.SII);

            /*" -3772- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3772- PERFORM R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1 */

            R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1();

            /*" -3775- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3776- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3777- DISPLAY 'VA2601B - PROBLEMAS NO DECLARE PROPOSTAS_VA' */
                _.Display($"VA2601B - PROBLEMAS NO DECLARE PROPOSTAS_VA");

                /*" -3779- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -3781- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -3783- DISPLAY '          SQLCODE...............   ' SQLCODE */
                _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                /*" -3784- GO TO R2241-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2241_10_FETCH */

            R2241_10_FETCH();

        }

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-DB-OPEN-1 */
        public void R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1()
        {
            /*" -3772- EXEC SQL OPEN CRISCO END-EXEC. */

            CRISCO.Open();

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-DECLARE-1 */
        public void R2300_00_TRATA_CLIENTES_DB_DECLARE_1()
        {
            /*" -3941- EXEC SQL DECLARE CCLIENTES CURSOR FOR SELECT COD_CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND NOME_RAZAO <> ' ' ORDER BY COD_CLIENTE DESC END-EXEC. */
            CCLIENTES = new VA2601B_CCLIENTES(true);
            string GetQuery_CCLIENTES()
            {
                var query = @$"SELECT COD_CLIENTE 
							FROM SEGUROS.CLIENTES 
							WHERE CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND DATA_NASCIMENTO = '{PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}' 
							AND NOME_RAZAO <> ' ' 
							ORDER BY COD_CLIENTE DESC";

                return query;
            }
            CCLIENTES.GetQueryEvent += GetQuery_CCLIENTES;

        }

        [StopWatch]
        /*" R2241-10-FETCH */
        private void R2241_10_FETCH(bool isPerform = false)
        {
            /*" -3788- MOVE 'FETCH  CRISCO                ' TO COMANDO. */
            _.Move("FETCH  CRISCO                ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3791- PERFORM R2241_10_FETCH_DB_FETCH_1 */

            R2241_10_FETCH_DB_FETCH_1();

            /*" -3794- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3795- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3795- PERFORM R2241_10_FETCH_DB_CLOSE_1 */

                    R2241_10_FETCH_DB_CLOSE_1();

                    /*" -3797- GO TO R2241-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                    return;

                    /*" -3798- ELSE */
                }
                else
                {


                    /*" -3798- PERFORM R2241_10_FETCH_DB_CLOSE_2 */

                    R2241_10_FETCH_DB_CLOSE_2();

                    /*" -3800- DISPLAY 'VA2601B - PROBLEMAS NO FETCH PROPOSTAS_VA' */
                    _.Display($"VA2601B - PROBLEMAS NO FETCH PROPOSTAS_VA");

                    /*" -3802- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                    _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                    /*" -3804- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                    _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                    /*" -3806- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -3808- GO TO R2241-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3809- MOVE 39 TO SII */
            _.Move(39, WS_HORAS.SII);

            /*" -3810- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3827- PERFORM R2241_10_FETCH_DB_SELECT_1 */

            R2241_10_FETCH_DB_SELECT_1();

            /*" -3830- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3831- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3832- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3833- MOVE ZEROS TO APOLCOB-IMPSEGURADO */
                    _.Move(0, APOLCOB_IMPSEGURADO);

                    /*" -3834- ELSE */
                }
                else
                {


                    /*" -3835- DISPLAY 'VA2601B - PROBLEMAS ACESSO APOLICE_COBERTURAS' */
                    _.Display($"VA2601B - PROBLEMAS ACESSO APOLICE_COBERTURAS");

                    /*" -3837- DISPLAY '          NUM_CERTIFICADO.......   ' PROPVA-NRCERTIF */
                    _.Display($"          NUM_CERTIFICADO.......   {PROPVA_NRCERTIF}");

                    /*" -3839- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -3842- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3843- MOVE APOLCOB-DT-TERVIGENCIA (1:4) TO WS-DT-TERVIGENCIA (1:4) */
            _.MoveAtPosition(APOLCOB_DT_TERVIGENCIA.Substring(1, 4), WS_DT_TERVIGENCIA, 1, 4);

            /*" -3844- MOVE APOLCOB-DT-TERVIGENCIA (6:2) TO WS-DT-TERVIGENCIA (5:2) */
            _.MoveAtPosition(APOLCOB_DT_TERVIGENCIA.Substring(6, 2), WS_DT_TERVIGENCIA, 5, 2);

            /*" -3845- MOVE APOLCOB-DT-TERVIGENCIA (9:2) TO WS-DT-TERVIGENCIA (7:2) */
            _.MoveAtPosition(APOLCOB_DT_TERVIGENCIA.Substring(9, 2), WS_DT_TERVIGENCIA, 7, 2);

            /*" -3847- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS (1:4) TO WS-DT-MOVABERTO (1:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), WS_DT_MOVABERTO, 1, 4);

            /*" -3849- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS (6:2) TO WS-DT-MOVABERTO (5:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), WS_DT_MOVABERTO, 5, 2);

            /*" -3852- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS (9:2) TO WS-DT-MOVABERTO (7:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), WS_DT_MOVABERTO, 7, 2);

            /*" -3853- IF WS-DT-TERVIGENCIA GREATER WS-DT-MOVABERTO */

            if (WS_DT_TERVIGENCIA > WS_DT_MOVABERTO)
            {

                /*" -3881- ADD APOLCOB-IMPSEGURADO TO AC-TOT-RISCO. */
                WORK_AREA.AC_TOT_RISCO.Value = WORK_AREA.AC_TOT_RISCO + APOLCOB_IMPSEGURADO;
            }


            /*" -3881- GO TO R2241-10-FETCH. */
            new Task(() => R2241_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-FETCH-1 */
        public void R2241_10_FETCH_DB_FETCH_1()
        {
            /*" -3791- EXEC SQL FETCH CRISCO INTO :PROPVA-NRCERTIF END-EXEC. */

            if (CRISCO.Fetch())
            {
                _.Move(CRISCO.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
            }

        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-CLOSE-1 */
        public void R2241_10_FETCH_DB_CLOSE_1()
        {
            /*" -3795- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/

        [StopWatch]
        /*" R2241-10-FETCH-DB-SELECT-1 */
        public void R2241_10_FETCH_DB_SELECT_1()
        {
            /*" -3827- EXEC SQL SELECT B.IMP_SEGURADA_IX, B.DATA_TERVIGENCIA INTO :APOLCOB-IMPSEGURADO, :APOLCOB-DT-TERVIGENCIA FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.APOLICE_COBERTURAS B WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ITEM = B.NUM_ITEM AND A.TIPO_SEGURADO = '1' AND B.DATA_TERVIGENCIA = (SELECT MAX(DATA_TERVIGENCIA) FROM SEGUROS.APOLICE_COBERTURAS C WHERE C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ITEM = B.NUM_ITEM) WITH UR END-EXEC. */

            var r2241_10_FETCH_DB_SELECT_1_Query1 = new R2241_10_FETCH_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R2241_10_FETCH_DB_SELECT_1_Query1.Execute(r2241_10_FETCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOB_IMPSEGURADO, APOLCOB_IMPSEGURADO);
                _.Move(executed_1.APOLCOB_DT_TERVIGENCIA, APOLCOB_DT_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-CLOSE-2 */
        public void R2241_10_FETCH_DB_CLOSE_2()
        {
            /*" -3798- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }

        [StopWatch]
        /*" R2250-00-SELECT-LIM-RENDA-SECTION */
        private void R2250_00_SELECT_LIM_RENDA_SECTION()
        {
            /*" -3893- MOVE 'R2250-00-SELECT-LIM-RENDA     ' TO PARAGRAFO. */
            _.Move("R2250-00-SELECT-LIM-RENDA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3897- MOVE 'NAO' TO WS-TEM-ERRO-1855. */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1855);

            /*" -3898- IF PROPOFID-FAIXA-RENDA-IND NOT EQUAL SPACES */

            if (!PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.IsEmpty())
            {

                /*" -3899- MOVE PROPOFID-FAIXA-RENDA-IND TO INDR */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND, WORK_AREA.INDR);

                /*" -3900- IF INDR > 0 AND INDR < 6 */

                if (WORK_AREA.INDR > 0 && WORK_AREA.INDR < 6)
                {

                    /*" -3903- IF IMPMORNATU OF DCLPLANOS-VA-VGAP GREATER VATBFREN-REND-IND-LIMITE(INDR) */

                    if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > VATBFREN.VATBFREN_TABELA_FAIXA_RENDA.FILLER_4.VATBFREN_REND_IND_LIMITE[WORK_AREA.INDR])
                    {

                        /*" -3904- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -3914- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -3915- END-IF */
                    }


                    /*" -3916- END-IF */
                }


                /*" -3916- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-SECTION */
        private void R2300_00_TRATA_CLIENTES_SECTION()
        {
            /*" -3927- MOVE '2300-00-TRATA-CLIENTES       ' TO PARAGRAFO. */
            _.Move("2300-00-TRATA-CLIENTES       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3929- MOVE 1 TO W-TRATA-CLIENTE. */
            _.Move(1, WORK_AREA.W_TRATA_CLIENTE);

            /*" -3931- MOVE 0 TO WS-JA-E-CLIENTE. */
            _.Move(0, WORK_AREA.WS_JA_E_CLIENTE);

            /*" -3933- MOVE '2300-00-TRATA-CLIENTE        ' TO PARAGRAFO. */
            _.Move("2300-00-TRATA-CLIENTE        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3934- MOVE 'DECLARE CURSOR CLIENTES      ' TO COMANDO. */
            _.Move("DECLARE CURSOR CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3941- PERFORM R2300_00_TRATA_CLIENTES_DB_DECLARE_1 */

            R2300_00_TRATA_CLIENTES_DB_DECLARE_1();

            /*" -3944- MOVE 40 TO SII */
            _.Move(40, WS_HORAS.SII);

            /*" -3945- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3945- PERFORM R2300_00_TRATA_CLIENTES_DB_OPEN_1 */

            R2300_00_TRATA_CLIENTES_DB_OPEN_1();

            /*" -3948- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3949- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3950- DISPLAY 'VA2601B - PROBLEMAS NO DECLARE CLIENTES' */
                _.Display($"VA2601B - PROBLEMAS NO DECLARE CLIENTES");

                /*" -3952- DISPLAY '          NUM PROPOSTA..............   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA..............   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -3954- DISPLAY '          COD CLIENTE...............   ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE...............   {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -3956- DISPLAY '          SQLCODE...................   ' SQLCODE */
                _.Display($"          SQLCODE...................   {DB.SQLCODE}");

                /*" -3959- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


            /*" -3960- MOVE 'FETCH CLIENTES               ' TO COMANDO. */
            _.Move("FETCH CLIENTES               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3963- PERFORM R2300_00_TRATA_CLIENTES_DB_FETCH_1 */

            R2300_00_TRATA_CLIENTES_DB_FETCH_1();

            /*" -3966- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3967- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3967- PERFORM R2300_00_TRATA_CLIENTES_DB_CLOSE_1 */

                    R2300_00_TRATA_CLIENTES_DB_CLOSE_1();

                    /*" -3970- PERFORM R2310-00-INSERT-CLIENTES */

                    R2310_00_INSERT_CLIENTES_SECTION();

                    /*" -3971- IF VIND-DATA-EXPEDICAO EQUAL ZEROS */

                    if (VIND_DATA_EXPEDICAO == 00)
                    {

                        /*" -3972- PERFORM R2315-00-INSERT-GE-DOC */

                        R2315_00_INSERT_GE_DOC_SECTION();

                        /*" -3974- END-IF */
                    }


                    /*" -3975- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                    _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                    /*" -3976- GO TO R2300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                    /*" -3977- ELSE */
                }
                else
                {


                    /*" -3978- DISPLAY 'VA2601B - PROBLEMAS NO FETCH   CLIENTES' */
                    _.Display($"VA2601B - PROBLEMAS NO FETCH   CLIENTES");

                    /*" -3980- DISPLAY '          NUM PROPOSTA..............   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA..............   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3982- DISPLAY '          COD CLIENTE...............   ' COD-CLIENTE OF DCLCLIENTES */
                    _.Display($"          COD CLIENTE...............   {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                    /*" -3984- DISPLAY '          SQLCODE...................   ' SQLCODE */
                    _.Display($"          SQLCODE...................   {DB.SQLCODE}");

                    /*" -3987- MOVE 2 TO W-TRATA-CLIENTE. */
                    _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
                }

            }


            /*" -3987- PERFORM R2300_00_TRATA_CLIENTES_DB_CLOSE_2 */

            R2300_00_TRATA_CLIENTES_DB_CLOSE_2();

            /*" -3989- MOVE 1 TO WS-JA-E-CLIENTE. */
            _.Move(1, WORK_AREA.WS_JA_E_CLIENTE);

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-OPEN-1 */
        public void R2300_00_TRATA_CLIENTES_DB_OPEN_1()
        {
            /*" -3945- EXEC SQL OPEN CCLIENTES END-EXEC. */

            CCLIENTES.Open();

        }

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-DB-DECLARE-1 */
        public void R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1()
        {
            /*" -5456- EXEC SQL DECLARE VGPLARAMC CURSOR FOR SELECT NUM_RAMO, NUM_COBERTURA, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_PLANO_RAMO_COB WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE AND PERIPGTO = :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO ORDER BY NUM_RAMO, NUM_COBERTURA END-EXEC. */
            VGPLARAMC = new VA2601B_VGPLARAMC(true);
            string GetQuery_VGPLARAMC()
            {
                var query = @$"SELECT NUM_RAMO
							, 
							NUM_COBERTURA
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_PLANO_RAMO_COB 
							WHERE NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND CODSUBES = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}' 
							AND OPCAO_COBER = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}' 
							AND DTINIVIG <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DTTERVIG >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND IDADE_INICIAL <= '{WHOST_IDADE}' 
							AND IDADE_FINAL >= '{WHOST_IDADE}' 
							AND PERIPGTO = 
							'{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}' 
							ORDER BY NUM_RAMO
							, 
							NUM_COBERTURA";

                return query;
            }
            VGPLARAMC.GetQueryEvent += GetQuery_VGPLARAMC;

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-FETCH-1 */
        public void R2300_00_TRATA_CLIENTES_DB_FETCH_1()
        {
            /*" -3963- EXEC SQL FETCH CCLIENTES INTO :DCLCLIENTES.COD-CLIENTE END-EXEC. */

            if (CCLIENTES.Fetch())
            {
                _.Move(CCLIENTES.DCLCLIENTES_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);
            }

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-CLOSE-1 */
        public void R2300_00_TRATA_CLIENTES_DB_CLOSE_1()
        {
            /*" -3967- EXEC SQL CLOSE CCLIENTES END-EXEC */

            CCLIENTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-CLOSE-2 */
        public void R2300_00_TRATA_CLIENTES_DB_CLOSE_2()
        {
            /*" -3987- EXEC SQL CLOSE CCLIENTES END-EXEC. */

            CCLIENTES.Close();

        }

        [StopWatch]
        /*" R2305-00-VALIDA-NOME-CLIENTE */
        private void R2305_00_VALIDA_NOME_CLIENTE(bool isPerform = false)
        {
            /*" -3999- MOVE 'R2305-00-VALIDA-NOME-CLIENTE ' TO PARAGRAFO. */
            _.Move("R2305-00-VALIDA-NOME-CLIENTE ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4004- MOVE 'VALIDAR NOME DO CLIENTE      ' TO COMANDO. */
            _.Move("VALIDAR NOME DO CLIENTE      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4005- IF PESSOA-NOME-PESSOA EQUAL SPACES OR LOW-VALUES */

            if (PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsLowValues())
            {

                /*" -4006- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4007- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4008- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4009- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -4012- END-IF */
            }


            /*" -4014- IF PESSOA-NOME-PESSOA EQUAL 'NOME' OR PESSOA-NOME-PESSOA EQUAL 'NAONAO' */

            if (PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA == "NOME" || PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA == "NAONAO")
            {

                /*" -4015- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4016- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4017- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4018- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -4022- END-IF */
            }


            /*" -4023- MOVE PESSOA-NOME-PESSOA TO WS-TRATA-NOME */
            _.Move(PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA, WORK_AREA.WS_TRATA_NOME);

            /*" -4025- IF WS-NOM-1A-POSICAO EQUAL WS-NOM-2A-POSICAO AND WS-NOM-1A-POSICAO EQUAL WS-NOM-3A-POSICAO */

            if (WORK_AREA.WS_TRATA_NOM.WS_NOM_1A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_2A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_1A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_3A_POSICAO)
            {

                /*" -4026- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4027- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4028- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4029- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -4032- END-IF */
            }


            /*" -4038- IF WS-NOM-1A-POSICAO EQUAL WS-NOM-4A-POSICAO AND WS-NOM-1A-POSICAO EQUAL WS-NOM-7A-POSICAO AND WS-NOM-2A-POSICAO EQUAL WS-NOM-5A-POSICAO AND WS-NOM-2A-POSICAO EQUAL WS-NOM-8A-POSICAO AND WS-NOM-3A-POSICAO EQUAL WS-NOM-6A-POSICAO AND WS-NOM-3A-POSICAO EQUAL WS-NOM-9A-POSICAO */

            if (WORK_AREA.WS_TRATA_NOM.WS_NOM_1A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_4A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_1A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_7A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_2A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_5A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_2A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_8A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_3A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_6A_POSICAO && WORK_AREA.WS_TRATA_NOM.WS_NOM_3A_POSICAO == WORK_AREA.WS_TRATA_NOM.WS_NOM_9A_POSICAO)
            {

                /*" -4039- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4040- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4041- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4042- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -4045- END-IF */
            }


            /*" -4047- MOVE ZEROS TO WS-CONTA-BRC */
            _.Move(0, WS_CONTA_BRC);

            /*" -4050- INSPECT FUNCTION REVERSE(WS-TRATA-NOME) TALLYING WS-CONTA-BRC FOR LEADING SPACES */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_NOME.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -4053- COMPUTE WS-CONTA-BRC EQUAL LENGTH OF WS-TRATA-NOME - WS-CONTA-BRC */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_NOME.Pic.Length - WS_CONTA_BRC;

            /*" -4054- IF WS-CONTA-BRC <= 3 */

            if (WS_CONTA_BRC <= 3)
            {

                /*" -4055- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4056- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4057- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4058- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -4061- END-IF */
            }


            /*" -4062- MOVE 1 TO WS-POSICAO */
            _.Move(1, WS_POSICAO);

            /*" -4064- SET WS-NAO-ACHOU TO TRUE */
            WS_ENCONTROU_LETRA["WS_NAO_ACHOU"] = true;

            /*" -4065- PERFORM UNTIL WS-POSICAO > 40 OR WS-SIM-ACHOU */

            while (!(WS_POSICAO > 40 || WS_ENCONTROU_LETRA["WS_SIM_ACHOU"]))
            {

                /*" -4072- IF WS-TRATA-NOME(WS-POSICAO:1) EQUAL '0' OR '1' OR '2' OR '3' OR '4' OR '5' OR '6' OR '7' OR '8' OR '9' OR '0' OR '/' OR '\' OR '?' OR '!' OR '*' OR '+' OR '�' OR '`' OR ',' OR '=' OR '_' OR '[' OR ']' OR '{' OR '}' OR '<' OR '>' OR '(' OR ')' OR '%' OR '$' OR '#' OR '@' OR '�' OR ';' OR ':' OR '|' OR '^' OR '~' OR '"' */

                if (WORK_AREA.WS_TRATA_NOME.Substring(WS_POSICAO, 1).In("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "/", "\\", "?", "!", "*", "+", "�", "`", " , ", "=", "_".ToString(), "[".ToString(), "]", "{", "}", "<", ">", " ( ".ToString(), " )", "%", "$", "#", "@", "�", ";", ":", "|", "^", "~", "\""))
                {

                    /*" -4073- SET WS-SIM-ACHOU TO TRUE */
                    WS_ENCONTROU_LETRA["WS_SIM_ACHOU"] = true;

                    /*" -4074- ELSE */
                }
                else
                {


                    /*" -4075- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -4077- END-IF */
                }


                /*" -4079- END-PERFORM */
            }

            /*" -4080- IF WS-SIM-ACHOU */

            if (WS_ENCONTROU_LETRA["WS_SIM_ACHOU"])
            {

                /*" -4081- MOVE 1873 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1873, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4082- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4083- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4084- GO TO R2305-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/ //GOTO
                return;

                /*" -4086- END-IF */
            }


            /*" -4086- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-SECTION */
        private void R2310_00_INSERT_CLIENTES_SECTION()
        {
            /*" -4097- MOVE '2310-00-INSERT-CLIENTES      ' TO PARAGRAFO. */
            _.Move("2310-00-INSERT-CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4101- PERFORM R2305-00-VALIDA-NOME-CLIENTE THRU R2305-99-SAIDA */

            R2305_00_VALIDA_NOME_CLIENTE();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/


            /*" -4102- ADD 1 TO NUM-CLIENTE OF DCLNUMERO-OUTROS. */
            NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE + 1;

            /*" -4105- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -4107- MOVE '2310-00-INSERT-CLIENTES      ' TO PARAGRAFO. */
            _.Move("2310-00-INSERT-CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4108- MOVE 41 TO SII */
            _.Move(41, WS_HORAS.SII);

            /*" -4109- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4147- PERFORM R2310_00_INSERT_CLIENTES_DB_INSERT_1 */

            R2310_00_INSERT_CLIENTES_DB_INSERT_1();

            /*" -4149- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4150- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4151- DISPLAY 'VA2601B - PROBLEMAS NO INSERT DA V0CLIENTES' */
                _.Display($"VA2601B - PROBLEMAS NO INSERT DA V0CLIENTES");

                /*" -4153- DISPLAY '          NUM PROPOSTA..............       ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA..............       {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4155- DISPLAY '          COD CLIENTE...............       ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE...............       {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -4157- DISPLAY '          SQLCODE...................       ' SQLCODE */
                _.Display($"          SQLCODE...................       {DB.SQLCODE}");

                /*" -4157- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


        }

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-DB-INSERT-1 */
        public void R2310_00_INSERT_CLIENTES_DB_INSERT_1()
        {
            /*" -4147- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:DCLCLIENTES.COD-CLIENTE, :DCLPESSOA.PESSOA-NOME-PESSOA, 'F' , :DCLPESSOA-FISICA.CPF, '0' , :DCLPESSOA-FISICA.DATA-NASCIMENTO :VIND-DATA-NASCIMENTO, 0, NULL, NULL, NULL, NULL, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.ESTADO-CIVIL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1 = new R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                VIND_DATA_NASCIMENTO = VIND_DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
            };

            R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1.Execute(r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-SECTION */
        private void R2315_00_INSERT_GE_DOC_SECTION()
        {
            /*" -4169- MOVE '2315-00-INSERT-GE-DOC        ' TO PARAGRAFO. */
            _.Move("2315-00-INSERT-GE-DOC        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4172- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -4175- MOVE NUM-IDENTIDADE OF DCLPESSOA-FISICA TO GEDOCCLI-COD-IDENTIFICACAO */
            _.Move(PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);

            /*" -4178- MOVE ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA TO W-NOM-ORGAO-EXP */
            _.Move(PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR, WORK_AREA.W_NOM_ORGAO_EXP);

            /*" -4181- MOVE W-ORGAO-EXPEDIDOR TO GEDOCCLI-NOM-ORGAO-EXP */
            _.Move(WORK_AREA.FILLER_14.W_ORGAO_EXPEDIDOR, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);

            /*" -4184- MOVE DATA-EXPEDICAO OF DCLPESSOA-FISICA TO GEDOCCLI-DTH-EXPEDICAO. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);

            /*" -4185- IF VIND-UF-EXPEDIDORA NOT LESS ZEROS */

            if (VIND_UF_EXPEDIDORA >= 00)
            {

                /*" -4188- MOVE UF-EXPEDIDORA OF DCLPESSOA-FISICA TO GEDOCCLI-COD-UF. */
                _.Move(PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
            }


            /*" -4189- MOVE 42 TO SII */
            _.Move(42, WS_HORAS.SII);

            /*" -4190- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4203- PERFORM R2315_00_INSERT_GE_DOC_DB_INSERT_1 */

            R2315_00_INSERT_GE_DOC_DB_INSERT_1();

            /*" -4206- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4208- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -4209- DISPLAY 'VA2601B - PROBLEMAS INSERT GE-DOC-CLIENTE ' */
                _.Display($"VA2601B - PROBLEMAS INSERT GE-DOC-CLIENTE ");

                /*" -4211- DISPLAY '          NUM PROPOSTA....................... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA....................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4213- DISPLAY '          COD CLIENTE........................ ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE........................ {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -4215- DISPLAY '          SQLCODE............................ ' SQLCODE */
                _.Display($"          SQLCODE............................ {DB.SQLCODE}");

                /*" -4215- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-DB-INSERT-1 */
        public void R2315_00_INSERT_GE_DOC_DB_INSERT_1()
        {
            /*" -4203- EXEC SQL INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES (:GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO, :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF:VIND-UF-EXPEDIDORA) END-EXEC. */

            var r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 = new R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1()
            {
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
                GEDOCCLI_COD_IDENTIFICACAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO.ToString(),
                GEDOCCLI_NOM_ORGAO_EXP = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP.ToString(),
                GEDOCCLI_DTH_EXPEDICAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO.ToString(),
                GEDOCCLI_COD_UF = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF.ToString(),
                VIND_UF_EXPEDIDORA = VIND_UF_EXPEDIDORA.ToString(),
            };

            R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1.Execute(r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-SECTION */
        private void R2350_00_TRATA_ERRO_1864_SECTION()
        {
            /*" -4224- MOVE '2350-00-TRATA-ERRO1864       ' TO PARAGRAFO. */
            _.Move("2350-00-TRATA-ERRO1864       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4234- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_1 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_1();

            /*" -4237- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -4238- MOVE 1835 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1835, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4239- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4241- MOVE 'SIM' TO WS-TEM-ERRO-CPF-REC */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_CPF_REC);

                /*" -4243- END-IF. */
            }


            /*" -4262- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_2 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_2();

            /*" -4265- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -4266- IF IMPMORNATU OF DCLPLANOS-VA-VGAP NOT LESS 100000,00 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU >= 100000.00)
                {

                    /*" -4267- MOVE 1890 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1890, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -4268- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -4270- MOVE 'SIM' TO WS-TEM-ERRO-CPF-REC */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_CPF_REC);

                    /*" -4271- END-IF */
                }


                /*" -4291- END-IF. */
            }


            /*" -4301- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_3 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_3();

            /*" -4304- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -4305- MOVE 1891 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1891, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4306- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4329- MOVE 'SIM' TO WS-TEM-ERRO-CPF-REC */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_CPF_REC);

                /*" -4344- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_4 */

                R2350_00_TRATA_ERRO_1864_DB_SELECT_4();

                /*" -4347- IF WS-COUNT GREATER ZEROS */

                if (WS_COUNT > 00)
                {

                    /*" -4348- MOVE 1892 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1892, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -4349- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -4351- MOVE 'SIM' TO WS-TEM-ERRO-CPF-REC */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_CPF_REC);

                    /*" -4352- ELSE */
                }
                else
                {


                    /*" -4353- GO TO R2350-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                    return;

                    /*" -4353- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-1 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_1()
        {
            /*" -4234- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.SINISTRO_MESTRE B, SEGUROS.CLIENTES C WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.COD_CLIENTE = C.COD_CLIENTE AND C.CGCCPF = :DCLPESSOA-FISICA.CPF WITH UR END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-2 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_2()
        {
            /*" -4262- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.SEGURADOSVGAP_HIST A, SEGUROS.SEGURADOS_VGAP B, SEGUROS.CLIENTES C, SEGUROS.PROPOSTAS_VA D WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.NUM_ITEM = B.NUM_ITEM AND D.NUM_APOLICE = B.NUM_APOLICE AND D.COD_SUBGRUPO = B.COD_SUBGRUPO AND D.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND B.TIPO_SEGURADO = '1' AND B.COD_CLIENTE = C.COD_CLIENTE AND C.CGCCPF = :DCLPESSOA-FISICA.CPF AND A.COD_OPERACAO = 403 WITH UR END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }

        [StopWatch]
        /*" R2400-00-TRATA-ENDERECOS-SECTION */
        private void R2400_00_TRATA_ENDERECOS_SECTION()
        {
            /*" -4369- MOVE '2400-00-TRATA-ENDERECO       ' TO PARAGRAFO. */
            _.Move("2400-00-TRATA-ENDERECO       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4370- MOVE 43 TO SII */
            _.Move(43, WS_HORAS.SII);

            /*" -4371- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4372- IF WS-JA-E-CLIENTE EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 1)
            {

                /*" -4373- MOVE 'SELECT SEGUROS.ENDERECOS     ' TO COMANDO */
                _.Move("SELECT SEGUROS.ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4395- PERFORM R2400_00_TRATA_ENDERECOS_DB_SELECT_1 */

                R2400_00_TRATA_ENDERECOS_DB_SELECT_1();

                /*" -4397- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -4398- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4399- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -4400- PERFORM R2420-00-INSERT-ENDERECOS */

                        R2420_00_INSERT_ENDERECOS_SECTION();

                        /*" -4401- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                        _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                        /*" -4402- ELSE */
                    }
                    else
                    {


                        /*" -4404- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                        if (DB.SQLCODE == -811)
                        {

                            /*" -4405- ELSE */
                        }
                        else
                        {


                            /*" -4406- DISPLAY 'PROBLEMAS ACESSO ENDERECOS     ' */
                            _.Display($"PROBLEMAS ACESSO ENDERECOS     ");

                            /*" -4407- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -4408- END-IF */
                        }


                        /*" -4409- END-IF */
                    }


                    /*" -4412- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -4413- ELSE */
                }

            }
            else
            {


                /*" -4414- PERFORM R2420-00-INSERT-ENDERECOS */

                R2420_00_INSERT_ENDERECOS_SECTION();

                /*" -4414- MOVE 'I' TO WWORK-TIPO-MOVIMENTO. */
                _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R2400-00-TRATA-ENDERECOS-DB-SELECT-1 */
        public void R2400_00_TRATA_ENDERECOS_DB_SELECT_1()
        {
            /*" -4395- EXEC SQL SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, :DCLENDERECOS.ENDERECO-ENDERECO, :DCLENDERECOS.ENDERECO-BAIRRO, :DCLENDERECOS.ENDERECO-CIDADE, :DCLENDERECOS.ENDERECO-SIGLA-UF, :DCLENDERECOS.ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE AND ENDERECO = :DCLPESSOA-ENDERECO.ENDERECO AND BAIRRO = :DCLPESSOA-ENDERECO.BAIRRO AND CIDADE = :DCLPESSOA-ENDERECO.CIDADE AND SIGLA_UF = :DCLPESSOA-ENDERECO.SIGLA-UF AND CEP = :DCLPESSOA-ENDERECO.CEP END-EXEC */

            var r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 = new R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1()
            {
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
            };

            var executed_1 = R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1.Execute(r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-3 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_3()
        {
            /*" -4301- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.CLIENTES B WHERE A.ACATAMENTO = 'S' AND A.SIT_REGISTRO = '3' AND A.COD_CLIENTE = B.COD_CLIENTE AND B.CGCCPF = :DCLPESSOA-FISICA.CPF WITH UR END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-4 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_4()
        {
            /*" -4344- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.ERROS_PROP_VIDAZUL B, SEGUROS.CLIENTES C WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.SIT_REGISTRO = '2' AND B.COD_ERRO IN (1802,1807,1811, 1005,1006,1862) AND A.COD_CLIENTE = C.COD_CLIENTE AND C.CGCCPF = :DCLPESSOA-FISICA.CPF WITH UR END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-SECTION */
        private void R2420_00_INSERT_ENDERECOS_SECTION()
        {
            /*" -4472- MOVE 'SELECT MAX SEGUROS.ENDERECOS   ' TO COMANDO */
            _.Move("SELECT MAX SEGUROS.ENDERECOS   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4473- IF END-CORRES-CADASTRADO OR DEMAIS-END-CADASTRADO */

            if (WORK_AREA.W_ENDERECO["END_CORRES_CADASTRADO"] || WORK_AREA.W_ENDERECO["DEMAIS_END_CADASTRADO"])
            {

                /*" -4475- PERFORM R2450-00-VALIDA-ENDERECO THRU R2450-99-SAIDA */

                R2450_00_VALIDA_ENDERECO();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/


                /*" -4477- END-IF */
            }


            /*" -4478- MOVE 44 TO SII */
            _.Move(44, WS_HORAS.SII);

            /*" -4479- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4484- PERFORM R2420_00_INSERT_ENDERECOS_DB_SELECT_1 */

            R2420_00_INSERT_ENDERECOS_DB_SELECT_1();

            /*" -4487- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4489- DISPLAY 'PROBLEMAS NO MAX ENDERECOS              ' */
                _.Display($"PROBLEMAS NO MAX ENDERECOS              ");

                /*" -4491- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4494- ADD 1 TO ENDERECO-OCORR-ENDERECO OF DCLENDERECOS. */
            ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO + 1;

            /*" -4495- MOVE '2420-00-INSERT-ENDERECOS     ' TO PARAGRAFO. */
            _.Move("2420-00-INSERT-ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4497- MOVE 'INSERT ENDERECOS             ' TO COMANDO. */
            _.Move("INSERT ENDERECOS             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4498- MOVE 45 TO SII */
            _.Move(45, WS_HORAS.SII);

            /*" -4499- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4518- PERFORM R2420_00_INSERT_ENDERECOS_DB_INSERT_1 */

            R2420_00_INSERT_ENDERECOS_DB_INSERT_1();

            /*" -4521- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4522- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4523- DISPLAY 'PROBLEMAS NO INSERT A ENDERECOS         ' */
                _.Display($"PROBLEMAS NO INSERT A ENDERECOS         ");

                /*" -4524- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-DB-SELECT-1 */
        public void R2420_00_INSERT_ENDERECOS_DB_SELECT_1()
        {
            /*" -4484- EXEC SQL SELECT VALUE (MAX(OCORR_ENDERECO),0) INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1 = new R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1.Execute(r2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-DB-INSERT-1 */
        public void R2420_00_INSERT_ENDERECOS_DB_INSERT_1()
        {
            /*" -4518- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:DCLCLIENTES.COD-CLIENTE, 2, :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.CEP, :WHOST-DDD, :WHOST-FONE, :WHOST-FAX, :WHOST-TELEX, '0' , NULL , NULL) END-EXEC. */

            var r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 = new R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                WHOST_DDD = WHOST_DDD.ToString(),
                WHOST_FONE = WHOST_FONE.ToString(),
                WHOST_FAX = WHOST_FAX.ToString(),
                WHOST_TELEX = WHOST_TELEX.ToString(),
            };

            R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1.Execute(r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-VALIDA-ENDERECO */
        private void R2450_00_VALIDA_ENDERECO(bool isPerform = false)
        {
            /*" -4538- MOVE 'R2450-00-VALIDA-ENDERECO' TO PARAGRAFO */
            _.Move("R2450-00-VALIDA-ENDERECO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4543- MOVE 'VALIDA DODOS DE ENDERECO' TO COMANDO */
            _.Move("VALIDA DODOS DE ENDERECO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4545- IF ENDERECO OF DCLPESSOA-ENDERECO EQUAL SPACES OR LOW-VALUES */

            if (PESENDER.DCLPESSOA_ENDERECO.ENDERECO.IsLowValues())
            {

                /*" -4546- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4547- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4548- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4549- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4552- END-IF */
            }


            /*" -4555- IF ENDERECO OF DCLPESSOA-ENDERECO EQUAL 'ENDERECO' OR ENDERECO OF DCLPESSOA-ENDERECO EQUAL 'ENDERE�O' OR ENDERECO OF DCLPESSOA-ENDERECO EQUAL 'NAONAO' */

            if (PESENDER.DCLPESSOA_ENDERECO.ENDERECO == "ENDERECO" || PESENDER.DCLPESSOA_ENDERECO.ENDERECO == "ENDERE�O" || PESENDER.DCLPESSOA_ENDERECO.ENDERECO == "NAONAO")
            {

                /*" -4556- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4557- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4558- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4559- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4563- END-IF */
            }


            /*" -4565- MOVE ENDERECO OF DCLPESSOA-ENDERECO TO WS-TRATA-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.ENDERECO, WORK_AREA.WS_TRATA_ENDERECO);

            /*" -4567- IF WS-END-1A-POSICAO EQUAL WS-END-2A-POSICAO AND WS-END-1A-POSICAO EQUAL WS-END-3A-POSICAO */

            if (WORK_AREA.WS_TRATA_END.WS_END_1A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_2A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_1A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_3A_POSICAO)
            {

                /*" -4568- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4569- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4570- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4571- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4574- END-IF */
            }


            /*" -4580- IF WS-END-1A-POSICAO EQUAL WS-END-4A-POSICAO AND WS-END-1A-POSICAO EQUAL WS-END-7A-POSICAO AND WS-END-2A-POSICAO EQUAL WS-END-5A-POSICAO AND WS-END-2A-POSICAO EQUAL WS-END-8A-POSICAO AND WS-END-3A-POSICAO EQUAL WS-END-6A-POSICAO AND WS-END-3A-POSICAO EQUAL WS-END-9A-POSICAO */

            if (WORK_AREA.WS_TRATA_END.WS_END_1A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_4A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_1A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_7A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_2A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_5A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_2A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_8A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_3A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_6A_POSICAO && WORK_AREA.WS_TRATA_END.WS_END_3A_POSICAO == WORK_AREA.WS_TRATA_END.WS_END_9A_POSICAO)
            {

                /*" -4581- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4582- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4583- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4584- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4587- END-IF */
            }


            /*" -4589- MOVE ZEROS TO WS-CONTA-BRC */
            _.Move(0, WS_CONTA_BRC);

            /*" -4592- INSPECT FUNCTION REVERSE(WS-TRATA-ENDERECO) TALLYING WS-CONTA-BRC FOR LEADING SPACES */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_ENDERECO.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -4595- COMPUTE WS-CONTA-BRC EQUAL LENGTH OF WS-TRATA-ENDERECO - WS-CONTA-BRC */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_ENDERECO.Pic.Length - WS_CONTA_BRC;

            /*" -4596- IF WS-CONTA-BRC <= 3 */

            if (WS_CONTA_BRC <= 3)
            {

                /*" -4597- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4598- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4599- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4600- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4603- END-IF */
            }


            /*" -4604- MOVE 1 TO WS-POSICAO */
            _.Move(1, WS_POSICAO);

            /*" -4606- SET WS-NAO-ACHOU TO TRUE */
            WS_ENCONTROU_LETRA["WS_NAO_ACHOU"] = true;

            /*" -4607- PERFORM UNTIL WS-POSICAO > 40 OR WS-SIM-ACHOU */

            while (!(WS_POSICAO > 40 || WS_ENCONTROU_LETRA["WS_SIM_ACHOU"]))
            {

                /*" -4613- IF WS-TRATA-ENDERECO(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' */

                if (WORK_AREA.WS_TRATA_ENDERECO.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"))
                {

                    /*" -4614- SET WS-SIM-ACHOU TO TRUE */
                    WS_ENCONTROU_LETRA["WS_SIM_ACHOU"] = true;

                    /*" -4615- ELSE */
                }
                else
                {


                    /*" -4616- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -4618- END-IF */
                }


                /*" -4620- END-PERFORM */
            }

            /*" -4621- IF WS-NAO-ACHOU */

            if (WS_ENCONTROU_LETRA["WS_NAO_ACHOU"])
            {

                /*" -4622- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4623- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4624- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4625- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4629- END-IF */
            }


            /*" -4631- IF BAIRRO OF DCLPESSOA-ENDERECO EQUAL SPACES OR LOW-VALUES */

            if (PESENDER.DCLPESSOA_ENDERECO.BAIRRO.IsLowValues())
            {

                /*" -4632- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4633- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4634- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4635- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4638- END-IF */
            }


            /*" -4640- IF BAIRRO OF DCLPESSOA-ENDERECO EQUAL 'BAIRRO' OR BAIRRO OF DCLPESSOA-ENDERECO EQUAL 'NAONAO' */

            if (PESENDER.DCLPESSOA_ENDERECO.BAIRRO == "BAIRRO" || PESENDER.DCLPESSOA_ENDERECO.BAIRRO == "NAONAO")
            {

                /*" -4641- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4642- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4643- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4644- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4648- END-IF */
            }


            /*" -4650- MOVE BAIRRO OF DCLPESSOA-ENDERECO TO WS-TRATA-BAIRRO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.BAIRRO, WORK_AREA.WS_TRATA_BAIRRO);

            /*" -4652- IF WS-BAI-1A-POSICAO EQUAL WS-BAI-2A-POSICAO AND WS-BAI-1A-POSICAO EQUAL WS-BAI-3A-POSICAO */

            if (WORK_AREA.WS_TRATA_BAI.WS_BAI_1A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_2A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_1A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_3A_POSICAO)
            {

                /*" -4653- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4654- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4655- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4656- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4659- END-IF */
            }


            /*" -4665- IF WS-BAI-1A-POSICAO EQUAL WS-BAI-4A-POSICAO AND WS-BAI-1A-POSICAO EQUAL WS-BAI-7A-POSICAO AND WS-BAI-2A-POSICAO EQUAL WS-BAI-5A-POSICAO AND WS-BAI-2A-POSICAO EQUAL WS-BAI-8A-POSICAO AND WS-BAI-3A-POSICAO EQUAL WS-BAI-6A-POSICAO AND WS-BAI-3A-POSICAO EQUAL WS-BAI-9A-POSICAO */

            if (WORK_AREA.WS_TRATA_BAI.WS_BAI_1A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_4A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_1A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_7A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_2A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_5A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_2A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_8A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_3A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_6A_POSICAO && WORK_AREA.WS_TRATA_BAI.WS_BAI_3A_POSICAO == WORK_AREA.WS_TRATA_BAI.WS_BAI_9A_POSICAO)
            {

                /*" -4666- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4667- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4668- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4669- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4672- END-IF */
            }


            /*" -4674- MOVE ZEROS TO WS-CONTA-BRC */
            _.Move(0, WS_CONTA_BRC);

            /*" -4677- INSPECT FUNCTION REVERSE(WS-TRATA-BAIRRO) TALLYING WS-CONTA-BRC FOR LEADING SPACES */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_BAIRRO.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -4680- COMPUTE WS-CONTA-BRC EQUAL LENGTH OF WS-TRATA-BAIRRO - WS-CONTA-BRC */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_BAIRRO.Pic.Length - WS_CONTA_BRC;

            /*" -4681- IF WS-CONTA-BRC <= 3 */

            if (WS_CONTA_BRC <= 3)
            {

                /*" -4682- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4683- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4684- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4685- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4688- END-IF */
            }


            /*" -4689- MOVE 1 TO WS-POSICAO */
            _.Move(1, WS_POSICAO);

            /*" -4691- SET WS-NAO-ACHOU TO TRUE */
            WS_ENCONTROU_LETRA["WS_NAO_ACHOU"] = true;

            /*" -4692- PERFORM UNTIL WS-POSICAO > 20 OR WS-SIM-ACHOU */

            while (!(WS_POSICAO > 20 || WS_ENCONTROU_LETRA["WS_SIM_ACHOU"]))
            {

                /*" -4698- IF WS-TRATA-BAIRRO(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' */

                if (WORK_AREA.WS_TRATA_BAIRRO.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"))
                {

                    /*" -4699- SET WS-SIM-ACHOU TO TRUE */
                    WS_ENCONTROU_LETRA["WS_SIM_ACHOU"] = true;

                    /*" -4700- ELSE */
                }
                else
                {


                    /*" -4701- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -4703- END-IF */
                }


                /*" -4705- END-PERFORM */
            }

            /*" -4706- IF WS-NAO-ACHOU */

            if (WS_ENCONTROU_LETRA["WS_NAO_ACHOU"])
            {

                /*" -4707- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4708- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4709- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4710- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4714- END-IF */
            }


            /*" -4715- IF CEP OF DCLPESSOA-ENDERECO GREATER 99999999 */

            if (PESENDER.DCLPESSOA_ENDERECO.CEP > 99999999)
            {

                /*" -4716- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4717- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4718- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4719- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4724- END-IF */
            }


            /*" -4726- IF CIDADE OF DCLPESSOA-ENDERECO EQUAL SPACES OR LOW-VALUES */

            if (PESENDER.DCLPESSOA_ENDERECO.CIDADE.IsLowValues())
            {

                /*" -4727- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4728- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4729- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4730- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4733- END-IF */
            }


            /*" -4735- IF CIDADE OF DCLPESSOA-ENDERECO EQUAL 'CIDADE' OR CIDADE OF DCLPESSOA-ENDERECO EQUAL 'NAONAO' */

            if (PESENDER.DCLPESSOA_ENDERECO.CIDADE == "CIDADE" || PESENDER.DCLPESSOA_ENDERECO.CIDADE == "NAONAO")
            {

                /*" -4736- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4737- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4738- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4739- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4743- END-IF */
            }


            /*" -4745- MOVE CIDADE OF DCLPESSOA-ENDERECO TO WS-TRATA-CIDADE */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CIDADE, WORK_AREA.WS_TRATA_CIDADE);

            /*" -4747- IF WS-CID-1A-POSICAO EQUAL WS-CID-2A-POSICAO AND WS-CID-1A-POSICAO EQUAL WS-CID-3A-POSICAO */

            if (WORK_AREA.WS_TRATA_CID.WS_CID_1A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_2A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_1A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_3A_POSICAO)
            {

                /*" -4748- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4749- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4750- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4751- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4754- END-IF */
            }


            /*" -4760- IF WS-CID-1A-POSICAO EQUAL WS-CID-4A-POSICAO AND WS-CID-1A-POSICAO EQUAL WS-CID-7A-POSICAO AND WS-CID-2A-POSICAO EQUAL WS-CID-5A-POSICAO AND WS-CID-2A-POSICAO EQUAL WS-CID-8A-POSICAO AND WS-CID-3A-POSICAO EQUAL WS-CID-6A-POSICAO AND WS-CID-3A-POSICAO EQUAL WS-CID-9A-POSICAO */

            if (WORK_AREA.WS_TRATA_CID.WS_CID_1A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_4A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_1A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_7A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_2A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_5A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_2A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_8A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_3A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_6A_POSICAO && WORK_AREA.WS_TRATA_CID.WS_CID_3A_POSICAO == WORK_AREA.WS_TRATA_CID.WS_CID_9A_POSICAO)
            {

                /*" -4761- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4762- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4763- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4764- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4767- END-IF */
            }


            /*" -4769- MOVE ZEROS TO WS-CONTA-BRC */
            _.Move(0, WS_CONTA_BRC);

            /*" -4772- INSPECT FUNCTION REVERSE(WS-TRATA-CIDADE) TALLYING WS-CONTA-BRC FOR LEADING SPACES */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_CIDADE.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -4775- COMPUTE WS-CONTA-BRC EQUAL LENGTH OF WS-TRATA-CIDADE - WS-CONTA-BRC */
            WS_CONTA_BRC.Value = WORK_AREA.WS_TRATA_CIDADE.Pic.Length - WS_CONTA_BRC;

            /*" -4776- IF WS-CONTA-BRC <= 3 */

            if (WS_CONTA_BRC <= 3)
            {

                /*" -4777- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4778- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4779- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4780- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4783- END-IF */
            }


            /*" -4784- MOVE 1 TO WS-POSICAO */
            _.Move(1, WS_POSICAO);

            /*" -4786- SET WS-NAO-ACHOU TO TRUE */
            WS_ENCONTROU_LETRA["WS_NAO_ACHOU"] = true;

            /*" -4787- PERFORM UNTIL WS-POSICAO > 20 OR WS-SIM-ACHOU */

            while (!(WS_POSICAO > 20 || WS_ENCONTROU_LETRA["WS_SIM_ACHOU"]))
            {

                /*" -4793- IF WS-TRATA-CIDADE(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' */

                if (WORK_AREA.WS_TRATA_CIDADE.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"))
                {

                    /*" -4794- SET WS-SIM-ACHOU TO TRUE */
                    WS_ENCONTROU_LETRA["WS_SIM_ACHOU"] = true;

                    /*" -4795- ELSE */
                }
                else
                {


                    /*" -4796- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -4798- END-IF */
                }


                /*" -4800- END-PERFORM */
            }

            /*" -4801- IF WS-NAO-ACHOU */

            if (WS_ENCONTROU_LETRA["WS_NAO_ACHOU"])
            {

                /*" -4802- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4803- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4804- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4805- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4809- END-IF */
            }


            /*" -4811- IF SIGLA-UF OF DCLPESSOA-ENDERECO EQUAL SPACES OR LOW-VALUES */

            if (PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.IsLowValues())
            {

                /*" -4812- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -4813- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -4814- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                /*" -4815- GO TO R2450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                return;

                /*" -4817- END-IF */
            }


            /*" -4822- PERFORM R2450_00_VALIDA_ENDERECO_DB_SELECT_1 */

            R2450_00_VALIDA_ENDERECO_DB_SELECT_1();

            /*" -4825- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4826- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4827- MOVE 1872 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1872, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -4828- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -4829- MOVE 'SIM' TO WS-TEM-ERRO-DAD-CAD */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_DAD_CAD);

                    /*" -4830- GO TO R2450-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/ //GOTO
                    return;

                    /*" -4831- ELSE */
                }
                else
                {


                    /*" -4832- DISPLAY 'PROBLEMAS ACESSO UNIDADE_FEDERACAO' */
                    _.Display($"PROBLEMAS ACESSO UNIDADE_FEDERACAO");

                    /*" -4833- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4834- END-IF */
                }


                /*" -4836- END-IF */
            }


            /*" -4836- . */

        }

        [StopWatch]
        /*" R2450-00-VALIDA-ENDERECO-DB-SELECT-1 */
        public void R2450_00_VALIDA_ENDERECO_DB_SELECT_1()
        {
            /*" -4822- EXEC SQL SELECT SIGLA_UF INTO :WS-SIGLA-UF FROM SEGUROS.UNIDADE_FEDERACAO WHERE SIGLA_UF = :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            var r2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1 = new R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1()
            {
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
            };

            var executed_1 = R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1.Execute(r2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SIGLA_UF, WS_SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-TRATA-EMAIL-SECTION */
        private void R2500_00_TRATA_EMAIL_SECTION()
        {
            /*" -4847- MOVE '2500-00-TRATA-EMAIL          ' TO PARAGRAFO. */
            _.Move("2500-00-TRATA-EMAIL          ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4848- IF WS-JA-E-CLIENTE EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 1)
            {

                /*" -4849- MOVE 46 TO SII */
                _.Move(46, WS_HORAS.SII);

                /*" -4850- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -4851- MOVE 'SELECT SEGUROS.CLIENTE_EMAIL ' TO COMANDO */
                _.Move("SELECT SEGUROS.CLIENTE_EMAIL ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4856- PERFORM R2500_00_TRATA_EMAIL_DB_SELECT_1 */

                R2500_00_TRATA_EMAIL_DB_SELECT_1();

                /*" -4858- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -4859- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4860- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -4861- PERFORM R2520-00-INSERT-EMAIL */

                        R2520_00_INSERT_EMAIL_SECTION();

                        /*" -4862- ELSE */
                    }
                    else
                    {


                        /*" -4863- DISPLAY 'PROBLEMAS ACESSO ENDERECOS     ' */
                        _.Display($"PROBLEMAS ACESSO ENDERECOS     ");

                        /*" -4864- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4865- END-IF */
                    }


                    /*" -4866- ELSE */
                }
                else
                {


                    /*" -4867- PERFORM R2510-00-ALTERA-EMAIL */

                    R2510_00_ALTERA_EMAIL_SECTION();

                    /*" -4868- ELSE */
                }

            }
            else
            {


                /*" -4869- PERFORM R2520-00-INSERT-EMAIL. */

                R2520_00_INSERT_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R2500-00-TRATA-EMAIL-DB-SELECT-1 */
        public void R2500_00_TRATA_EMAIL_DB_SELECT_1()
        {
            /*" -4856- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2500_00_TRATA_EMAIL_DB_SELECT_1_Query1 = new R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1.Execute(r2500_00_TRATA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2510-00-ALTERA-EMAIL-SECTION */
        private void R2510_00_ALTERA_EMAIL_SECTION()
        {
            /*" -4877- MOVE '2510-00-ALTERA-EMAIL         ' TO PARAGRAFO. */
            _.Move("2510-00-ALTERA-EMAIL         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4878- MOVE 47 TO SII */
            _.Move(47, WS_HORAS.SII);

            /*" -4879- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4883- PERFORM R2510_00_ALTERA_EMAIL_DB_UPDATE_1 */

            R2510_00_ALTERA_EMAIL_DB_UPDATE_1();

            /*" -4885- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4886- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4887- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4888- DISPLAY 'EMAIL NAO CADASTRADO ' */
                    _.Display($"EMAIL NAO CADASTRADO ");

                    /*" -4889- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4890- ELSE */
                }
                else
                {


                    /*" -4892- DISPLAY 'PROBLEMAS ACESSO CLIENTE_EMAIL ' */
                    _.Display($"PROBLEMAS ACESSO CLIENTE_EMAIL ");

                    /*" -4893- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2510-00-ALTERA-EMAIL-DB-UPDATE-1 */
        public void R2510_00_ALTERA_EMAIL_DB_UPDATE_1()
        {
            /*" -4883- EXEC SQL UPDATE SEGUROS.CLIENTE_EMAIL SET EMAIL = :WHOST-EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1 = new R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1()
            {
                WHOST_EMAIL = WHOST_EMAIL.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1.Execute(r2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-SECTION */
        private void R2520_00_INSERT_EMAIL_SECTION()
        {
            /*" -4902- MOVE 'SELECT MAX SEGUROS.CLIENTE_EMAIL' TO COMANDO */
            _.Move("SELECT MAX SEGUROS.CLIENTE_EMAIL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4903- MOVE 48 TO SII */
            _.Move(48, WS_HORAS.SII);

            /*" -4904- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4909- PERFORM R2520_00_INSERT_EMAIL_DB_SELECT_1 */

            R2520_00_INSERT_EMAIL_DB_SELECT_1();

            /*" -4912- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4913- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4914- DISPLAY 'PROBLEMAS NO MAX CLEINTE_EMAIL          ' */
                _.Display($"PROBLEMAS NO MAX CLEINTE_EMAIL          ");

                /*" -4916- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4918- ADD 1 TO CLIENEMA-SEQ-EMAIL. */
            CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.Value = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL + 1;

            /*" -4919- MOVE '2520-00-INSERT-CLIENTE-EMAIL ' TO PARAGRAFO. */
            _.Move("2520-00-INSERT-CLIENTE-EMAIL ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4921- MOVE 'INSERT CLIENTE-EMAIL         ' TO COMANDO. */
            _.Move("INSERT CLIENTE-EMAIL         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4922- MOVE 49 TO SII */
            _.Move(49, WS_HORAS.SII);

            /*" -4923- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4929- PERFORM R2520_00_INSERT_EMAIL_DB_INSERT_1 */

            R2520_00_INSERT_EMAIL_DB_INSERT_1();

            /*" -4932- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4933- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4934- DISPLAY 'PROBLEMAS NO INSERT A ENDERECOS         ' */
                _.Display($"PROBLEMAS NO INSERT A ENDERECOS         ");

                /*" -4935- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-DB-SELECT-1 */
        public void R2520_00_INSERT_EMAIL_DB_SELECT_1()
        {
            /*" -4909- EXEC SQL SELECT VALUE (MAX(SEQ_EMAIL),0) INTO :CLIENEMA-SEQ-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2520_00_INSERT_EMAIL_DB_SELECT_1_Query1 = new R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1.Execute(r2520_00_INSERT_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_SEQ_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL);
            }


        }

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-DB-INSERT-1 */
        public void R2520_00_INSERT_EMAIL_DB_INSERT_1()
        {
            /*" -4929- EXEC SQL INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES (:DCLCLIENTES.COD-CLIENTE, :CLIENEMA-SEQ-EMAIL, :WHOST-EMAIL) END-EXEC. */

            var r2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1 = new R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
                WHOST_EMAIL = WHOST_EMAIL.ToString(),
            };

            R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1.Execute(r2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-PROPOSTAVA-SECTION */
        private void R3000_00_INSERT_PROPOSTAVA_SECTION()
        {
            /*" -4953- MOVE PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ TO DATA-SQL1. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WORK_AREA.DATA_SQL1);

            /*" -4956- COMPUTE MES-SQL = MES-SQL + PRODUVG-PERI-PAGAMENTO OF DCLPRODUTOS-VG. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO;

            /*" -4957- IF MES-SQL GREATER 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -4960- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -4963- COMPUTE ANO-SQL = ANO-SQL + 1. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -4965- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -4966- IF PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO > 00)
            {

                /*" -4969- MOVE PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ TO DIA-SQL. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -4970- IF DIA-SQL GREATER 28 */

            if (WORK_AREA.DATA_SQL.DIA_SQL > 28)
            {

                /*" -4972- MOVE 28 TO DIA-SQL. */
                _.Move(28, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -4973- IF DATA-SQL LESS WHOST-DTPROXVEN */

            if (WORK_AREA.DATA_SQL < WHOST_DTPROXVEN)
            {

                /*" -4974- ADD 1 TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                /*" -4975- IF MES-SQL GREATER 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -4976- MOVE 1 TO MES-SQL */
                    _.Move(1, WORK_AREA.DATA_SQL.MES_SQL);

                    /*" -4978- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -4991- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -4992- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -4994- MOVE '7' TO WHOST-SIT-REGISTRO. */
                _.Move("7", WHOST_SIT_REGISTRO);
            }


            /*" -4996- MOVE -1 TO VIND-DATA-DECLINIO */
            _.Move(-1, VIND_DATA_DECLINIO);

            /*" -5003- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -5004- MOVE '2' TO WHOST-SIT-REGISTRO */
                _.Move("2", WHOST_SIT_REGISTRO);

                /*" -5005- MOVE ZEROS TO VIND-DATA-DECLINIO */
                _.Move(0, VIND_DATA_DECLINIO);

                /*" -5006- ELSE */
            }
            else
            {


                /*" -5009- IF WS-TEM-ERRO-1829 EQUAL 'SIM' OR WS-TEM-ERRO-CPF-REC EQUAL 'SIM' OR WS-TEM-ERRO-DAD-CAD EQUAL 'SIM' */

                if (WORK_AREA.WS_TEM_ERRO_1829 == "SIM" || WORK_AREA.WS_TEM_ERRO_CPF_REC == "SIM" || WORK_AREA.WS_TEM_ERRO_DAD_CAD == "SIM")
                {

                    /*" -5010- MOVE '1' TO WHOST-SIT-REGISTRO */
                    _.Move("1", WHOST_SIT_REGISTRO);

                    /*" -5011- ELSE */
                }
                else
                {


                    /*" -5013- IF WS-TEM-ERRO EQUAL ZEROS */

                    if (WORK_AREA.WS_TEM_ERRO == 00)
                    {

                        /*" -5014- IF CANAL-VENDA-PAPEL */

                        if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                        {

                            /*" -5017- IF IMPMORNATU OF DCLPLANOS-VA-VGAP NOT GREATER 200000,00 */

                            if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU <= 200000.00)
                            {

                                /*" -5018- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                                {

                                    /*" -5019- MOVE '0' TO WHOST-SIT-REGISTRO */
                                    _.Move("0", WHOST_SIT_REGISTRO);

                                    /*" -5020- ELSE */
                                }
                                else
                                {


                                    /*" -5021- MOVE 'E' TO WHOST-SIT-REGISTRO */
                                    _.Move("E", WHOST_SIT_REGISTRO);

                                    /*" -5022- END-IF */
                                }


                                /*" -5023- ELSE */
                            }
                            else
                            {


                                /*" -5024- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                                {

                                    /*" -5025- MOVE '9' TO WHOST-SIT-REGISTRO */
                                    _.Move("9", WHOST_SIT_REGISTRO);

                                    /*" -5026- ELSE */
                                }
                                else
                                {


                                    /*" -5027- MOVE 'E' TO WHOST-SIT-REGISTRO */
                                    _.Move("E", WHOST_SIT_REGISTRO);

                                    /*" -5028- END-IF */
                                }


                                /*" -5029- END-IF */
                            }


                            /*" -5030- END-IF */
                        }


                        /*" -5031- IF CANAL-VENDA-CEF */

                        if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_CEF"])
                        {

                            /*" -5034- IF IMPMORNATU OF DCLPLANOS-VA-VGAP NOT GREATER 200000,00 */

                            if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU <= 200000.00)
                            {

                                /*" -5035- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                                {

                                    /*" -5036- MOVE '0' TO WHOST-SIT-REGISTRO */
                                    _.Move("0", WHOST_SIT_REGISTRO);

                                    /*" -5037- ELSE */
                                }
                                else
                                {


                                    /*" -5038- MOVE 'E' TO WHOST-SIT-REGISTRO */
                                    _.Move("E", WHOST_SIT_REGISTRO);

                                    /*" -5039- END-IF */
                                }


                                /*" -5040- ELSE */
                            }
                            else
                            {


                                /*" -5041- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                                {

                                    /*" -5042- MOVE '9' TO WHOST-SIT-REGISTRO */
                                    _.Move("9", WHOST_SIT_REGISTRO);

                                    /*" -5043- ELSE */
                                }
                                else
                                {


                                    /*" -5044- MOVE 'E' TO WHOST-SIT-REGISTRO */
                                    _.Move("E", WHOST_SIT_REGISTRO);

                                    /*" -5045- END-IF */
                                }


                                /*" -5046- END-IF */
                            }


                            /*" -5047- END-IF */
                        }


                        /*" -5048- IF CANAL-SASSE-FILIAL */

                        if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"])
                        {

                            /*" -5049- MOVE 'E' TO WHOST-SIT-REGISTRO */
                            _.Move("E", WHOST_SIT_REGISTRO);

                            /*" -5050- END-IF */
                        }


                        /*" -5051- ELSE */
                    }
                    else
                    {


                        /*" -5052- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                        {

                            /*" -5053- MOVE '9' TO WHOST-SIT-REGISTRO */
                            _.Move("9", WHOST_SIT_REGISTRO);

                            /*" -5054- ELSE */
                        }
                        else
                        {


                            /*" -5055- MOVE 'E' TO WHOST-SIT-REGISTRO */
                            _.Move("E", WHOST_SIT_REGISTRO);

                            /*" -5056- END-IF */
                        }


                        /*" -5057- END-IF */
                    }


                    /*" -5059- END-IF. */
                }

            }


            /*" -5061- IF WHOST-SIT-REGISTRO EQUAL 'E' */

            if (WHOST_SIT_REGISTRO == "E")
            {

                /*" -5062- MOVE '8' TO WHOST-SIT-REGISTRO */
                _.Move("8", WHOST_SIT_REGISTRO);

                /*" -5067- END-IF. */
            }


            /*" -5068- IF VIND-PROFISSAO-CONJUGE EQUAL ZEROS */

            if (VIND_PROFISSAO_CONJUGE == 00)
            {

                /*" -5072- IF PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ > ZEROS AND PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ < 1000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE > 00 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE < 1000)
                {

                    /*" -5075- MOVE TAB-DESCR-CBO-C (PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ) TO WHOST-PROFISSAO-CONJUGE */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_27[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE].TAB_DESCR_CBO_C, WHOST_PROFISSAO_CONJUGE);

                    /*" -5079- ELSE */
                }
                else
                {


                    /*" -5080- MOVE SPACES TO WHOST-PROFISSAO-CONJUGE */
                    _.Move("", WHOST_PROFISSAO_CONJUGE);

                    /*" -5081- END-IF */
                }


                /*" -5083- END-IF. */
            }


            /*" -5085- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -5087- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_26[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -5088- ELSE */
            }
            else
            {


                /*" -5091- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -5092- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -5094- END-IF. */
            }


            /*" -5096- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -5102- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -5104- IF PRODUVG-PERI-PAGAMENTO = 00 OR PROPOFID-COD-PRODUTO-SIVPF = 77 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO == 00 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -5105- MOVE '9999-12-31' TO WHOST-DTPROXVEN */
                _.Move("9999-12-31", WHOST_DTPROXVEN);

                /*" -5107- END-IF. */
            }


            /*" -5109- MOVE -1 TO VIND-STA-ANTECIPACAO. */
            _.Move(-1, VIND_STA_ANTECIPACAO);

            /*" -5111- IF (PROPOFID-COD-PRODUTO-SIVPF = 11 OR 13 OR 46) AND PROPOFID-COD-PLANO = 11 */

            if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("11", "13", "46")) && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 11)
            {

                /*" -5112- MOVE 'S' TO WHOST-STA-ANTECIPACAO */
                _.Move("S", WHOST_STA_ANTECIPACAO);

                /*" -5113- MOVE ZEROS TO VIND-STA-ANTECIPACAO */
                _.Move(0, VIND_STA_ANTECIPACAO);

                /*" -5115- END-IF. */
            }


            /*" -5116- MOVE '3000-00-INSERT-PROPOSTAVA    ' TO PARAGRAFO. */
            _.Move("3000-00-INSERT-PROPOSTAVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5123- MOVE 'INSERT PROPOSTAVA             ' TO COMANDO. */
            _.Move("INSERT PROPOSTAVA             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5124- MOVE 50 TO SII */
            _.Move(50, WS_HORAS.SII);

            /*" -5125- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5264- PERFORM R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1 */

            R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1();

            /*" -5267- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5269- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5270- DISPLAY 'PROBLEMAS NO INSERT PROPOSTAVA ' */
                _.Display($"PROBLEMAS NO INSERT PROPOSTAVA ");

                /*" -5272- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5272- ADD 1 TO AC-I-PROPOSTAVA. */
            WORK_AREA.AC_I_PROPOSTAVA.Value = WORK_AREA.AC_I_PROPOSTAVA + 1;

        }

        [StopWatch]
        /*" R3000-00-INSERT-PROPOSTAVA-DB-INSERT-1 */
        public void R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1()
        {
            /*" -5264- EXEC SQL INSERT INTO SEGUROS.PROPOSTAS_VA ( NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , OPCAO_MARCADA , SIGLA_CRM , COD_CRM , APOS_INVALIDEZ , ASSINATURA , ACATAMENTO , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , GRAU_PARENTESCO , DATA_ADMISSAO , NUM_PROPOSTA , EM_ATIVIDADE , LOC_ATIVIDADE , INFO_COMPLEMENTAR , NRMALADIR , NRCERTIFANT , COD_CCT , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , NUM_CONTR_VINCULO , COD_CORRESP_BANC , COD_ORIGEM_PROPOSTA , NUM_PRAZO_FIN , COD_OPER_CREDITO , STA_ANTECIPACAO, STA_MUDANCA_PLANO, DTA_DECLINIO) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF , :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO , :DCLCLIENTES.COD-CLIENTE , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :WHOST-FONTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER , :WHOST-DATA-AGENDAMENTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , 106 , :WHOST-PROFISSAO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :WHOST-SIT-REGISTRO , :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO , 1 , 0 , 0 , :WHOST-DTPROXVEN , 1 , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , '0' , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 'VA2601B' , CURRENT TIMESTAMP, :WHOST-IDADE, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.ESTADO-CIVIL, NULL, NULL, NULL, :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ , ' ' , ' ' , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE, :WHOST-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE , NULL, NULL, NULL, NULL, NULL, NULL, :WHOST-INFO-COMPL, NULL, NULL, :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE :VIND-CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM, :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA , :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED , :WHOST-STA-ANTECIPACAO :VIND-STA-ANTECIPACAO, NULL, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-DECLINIO) END-EXEC. */

            var r3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 = new R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                WHOST_DATA_AGENDAMENTO = WHOST_DATA_AGENDAMENTO.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                WHOST_PROFISSAO = WHOST_PROFISSAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WHOST_SIT_REGISTRO = WHOST_SIT_REGISTRO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                WHOST_DTPROXVEN = WHOST_DTPROXVEN.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                PROPSSVD_APOS_INVALIDEZ = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                VIND_NOME_CONJUGE = VIND_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DATA_NASC_CONJUGE = VIND_DATA_NASC_CONJUGE.ToString(),
                WHOST_PROFISSAO_CONJUGE = WHOST_PROFISSAO_CONJUGE.ToString(),
                VIND_PROFISSAO_CONJUGE = VIND_PROFISSAO_CONJUGE.ToString(),
                PROPSSVD_DPS_TITULAR = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.ToString(),
                PROPSSVD_DPS_CONJUGE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.ToString(),
                WHOST_INFO_COMPL = WHOST_INFO_COMPL.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                VIND_CGC_CONVENENTE = VIND_CGC_CONVENENTE.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPSSVD_NUM_CONTR_VINCULO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.ToString(),
                VIND_NUM_CONTR = VIND_NUM_CONTR.ToString(),
                PROPSSVD_COD_CORRESP_BANC = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.ToString(),
                VIND_COD_CORRESP = VIND_COD_CORRESP.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPSSVD_NUM_PRAZO_FIN = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.ToString(),
                VIND_NUM_PRAZO = VIND_NUM_PRAZO.ToString(),
                PROPSSVD_COD_OPER_CREDITO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.ToString(),
                VIND_COD_OPER_CRED = VIND_COD_OPER_CRED.ToString(),
                WHOST_STA_ANTECIPACAO = WHOST_STA_ANTECIPACAO.ToString(),
                VIND_STA_ANTECIPACAO = VIND_STA_ANTECIPACAO.ToString(),
                VIND_DATA_DECLINIO = VIND_DATA_DECLINIO.ToString(),
            };

            R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1.Execute(r3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-INSERE-ANDAMENTO-SECTION */
        private void R3020_00_INSERE_ANDAMENTO_SECTION()
        {
            /*" -5282- MOVE 'R3020-00-INSERE-ANDAMENTO     ' TO PARAGRAFO */
            _.Move("R3020-00-INSERE-ANDAMENTO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5285- MOVE 'INSERT VG_ANDAMENTO_PROP      ' TO COMANDO */
            _.Move("INSERT VG_ANDAMENTO_PROP      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5287- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO VG078-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO);

            /*" -5289- MOVE 55 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(55, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -5290- IF PROPOFID-IND-TP-PROPOSTA EQUAL 'D' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA == "D")
            {

                /*" -5292- MOVE WS-TXT-PROP-ELETRONICA TO VG078-DES-ANDAMENTO-TEXT */
                _.Move(WS_TXT_PROP_ELETRONICA, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                /*" -5293- ELSE */
            }
            else
            {


                /*" -5294- IF PROPOFID-IND-TP-PROPOSTA EQUAL 'E' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA == "E")
                {

                    /*" -5296- MOVE WS-TXT-PROP-ELETRONICA-EMAIL TO VG078-DES-ANDAMENTO-TEXT */
                    _.Move(WS_TXT_PROP_ELETRONICA_EMAIL, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                    /*" -5297- ELSE */
                }
                else
                {


                    /*" -5298- IF PROPOFID-IND-TP-PROPOSTA EQUAL 'S' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA == "S")
                    {

                        /*" -5300- MOVE WS-TXT-PROP-ELETRONICA-SMS TO VG078-DES-ANDAMENTO-TEXT */
                        _.Move(WS_TXT_PROP_ELETRONICA_SMS, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);

                        /*" -5301- END-IF */
                    }


                    /*" -5302- END-IF */
                }


                /*" -5304- END-IF */
            }


            /*" -5306- MOVE 'VA2601B' TO VG078-COD-USUARIO */
            _.Move("VA2601B", VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO);

            /*" -5307- MOVE 86 TO SII */
            _.Move(86, WS_HORAS.SII);

            /*" -5309- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5324- PERFORM R3020_00_INSERE_ANDAMENTO_DB_INSERT_1 */

            R3020_00_INSERE_ANDAMENTO_DB_INSERT_1();

            /*" -5328- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5329- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5330- DISPLAY 'PROBLEMAS NO INSERT VG_ANDAMENTO_PROP' */
                _.Display($"PROBLEMAS NO INSERT VG_ANDAMENTO_PROP");

                /*" -5331- DISPLAY 'NUM_CERTIFICADO = ' VG078-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO}");

                /*" -5332- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -5333- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5333- END-IF. */
            }


        }

        [StopWatch]
        /*" R3020-00-INSERE-ANDAMENTO-DB-INSERT-1 */
        public void R3020_00_INSERE_ANDAMENTO_DB_INSERT_1()
        {
            /*" -5324- EXEC SQL INSERT INTO SEGUROS.VG_ANDAMENTO_PROP ( NUM_CERTIFICADO , DTH_CADASTRAMENTO , DES_ANDAMENTO , COD_USUARIO ) VALUES ( :VG078-NUM-CERTIFICADO , CURRENT TIMESTAMP , :VG078-DES-ANDAMENTO , :VG078-COD-USUARIO ) END-EXEC */

            var r3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1 = new R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1()
            {
                VG078_NUM_CERTIFICADO = VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO.ToString(),
                VG078_DES_ANDAMENTO = VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.ToString(),
                VG078_COD_USUARIO = VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO.ToString(),
            };

            R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1.Execute(r3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-COBERPROPVA-SECTION */
        private void R3100_00_INSERT_COBERPROPVA_SECTION()
        {
            /*" -5341- MOVE '3100-00-INSERT-COBERPROPVA ' TO PARAGRAFO. */
            _.Move("3100-00-INSERT-COBERPROPVA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5345- MOVE 'INSERT COBERPROPVA         ' TO COMANDO. */
            _.Move("INSERT COBERPROPVA         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5346- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -5347- IF PROPOFID-COD-PRODUTO-SIVPF = 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                {

                    /*" -5348- IF WHOST-IDADE < 66 */

                    if (WHOST_IDADE < 66)
                    {

                        /*" -5350- COMPUTE COBERP-IMPMORNATU = PROPOFID-VAL-PAGO / 0,01449 */
                        COBERP_IMPMORNATU.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO / 0.01449f;

                        /*" -5351- ELSE */
                    }
                    else
                    {


                        /*" -5353- COMPUTE COBERP-IMPMORNATU = PROPOFID-VAL-PAGO / 0,06600 */
                        COBERP_IMPMORNATU.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO / 0.06600f;

                        /*" -5354- END-IF */
                    }


                    /*" -5356- MOVE COBERP-IMPMORNATU TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
                    _.Move(COBERP_IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                    /*" -5358- MOVE COBERP-IMPMORNATU TO IMPMORACID OF DCLPLANOS-VA-VGAP */
                    _.Move(COBERP_IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);

                    /*" -5361- MOVE PROPOFID-VAL-PAGO TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
                    _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                    /*" -5362- END-IF */
                }


                /*" -5364- END-IF. */
            }


            /*" -5366- IF CANAL-SASSE-FILIAL AND PROPOFID-VAL-PAGO > ZEROS */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"] && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO > 00)
            {

                /*" -5369- MOVE PROPOFID-VAL-PAGO TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                /*" -5371- END-IF. */
            }


            /*" -5372- MOVE 51 TO SII */
            _.Move(51, WS_HORAS.SII);

            /*" -5373- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5409- PERFORM R3100_00_INSERT_COBERPROPVA_DB_INSERT_1 */

            R3100_00_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -5412- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5414- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5415- DISPLAY 'PROBLEMAS NO INSERT COBERPROPVA' */
                _.Display($"PROBLEMAS NO INSERT COBERPROPVA");

                /*" -5415- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void R3100_00_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -5409- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, '9999-12-31' , :DCLPLANOS-VA-VGAP.IMPMORNATU, 0, :DCLPLANOS-VA-VGAP.IMPMORNATU, 106, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER, :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, 'VA2601B' , CURRENT TIMESTAMP, :DCLPLANOS-VA-VGAP.IMPSEGAUXF :VIND-IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF :VIND-VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT :VIND-PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT :VIND-QTDIT) END-EXEC. */

            var r3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 = new R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                IMPMORNATU = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                IMPMORACID = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID.ToString(),
                IMPINVPERM = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM.ToString(),
                IMPAMDS = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS.ToString(),
                IMPDH = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH.ToString(),
                IMPDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT.ToString(),
                VLPREMIOTOT = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT.ToString(),
                PRMVG = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG.ToString(),
                PRMAP = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP.ToString(),
                QTTITCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP.ToString(),
                VLTITCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP.ToString(),
                VLCUSTCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP.ToString(),
                IMPSEGCDG = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG.ToString(),
                VLCUSTCDG = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG.ToString(),
                IMPSEGAUXF = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF.ToString(),
                VIND_IMPSEGAUXF = VIND_IMPSEGAUXF.ToString(),
                VLCUSTAUXF = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF.ToString(),
                VIND_VLCUSTAUXF = VIND_VLCUSTAUXF.ToString(),
                PRMDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT.ToString(),
                VIND_PRMDIT = VIND_PRMDIT.ToString(),
                QTDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT.ToString(),
                VIND_QTDIT = VIND_QTDIT.ToString(),
            };

            R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-SECTION */
        private void R3110_00_DECLARE_VGPLARAMCOB_SECTION()
        {
            /*" -5431- MOVE 'DECLARE VGPLARAMC' TO COMANDO. */
            _.Move("DECLARE VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5456- PERFORM R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1 */

            R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1();

            /*" -5460- MOVE 'OPEN  VGPLARAMC' TO COMANDO. */
            _.Move("OPEN  VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5461- MOVE 52 TO SII */
            _.Move(52, WS_HORAS.SII);

            /*" -5462- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5462- PERFORM R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1 */

            R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1();

            /*" -5465- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5467- MOVE SPACES TO WFIM-VGPLARAMC. */
            _.Move("", WORK_AREA.WFIM_VGPLARAMC);

            /*" -5468- PERFORM R3120-00-FETCH-VGPLARAMC UNTIL WFIM-VGPLARAMC NOT EQUAL SPACES. */

            while (!(!WORK_AREA.WFIM_VGPLARAMC.IsEmpty()))
            {

                R3120_00_FETCH_VGPLARAMC_SECTION();
            }

        }

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-DB-OPEN-1 */
        public void R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1()
        {
            /*" -5462- EXEC SQL OPEN VGPLARAMC END-EXEC. */

            VGPLARAMC.Open();

        }

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-DB-DECLARE-1 */
        public void R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1()
        {
            /*" -5564- EXEC SQL DECLARE VGPLAACES CURSOR FOR SELECT NUM_ACESSORIO, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_PLANO_ACESSORIO WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE AND PERIPGTO = :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO ORDER BY NUM_ACESSORIO END-EXEC. */
            VGPLAACES = new VA2601B_VGPLAACES(true);
            string GetQuery_VGPLAACES()
            {
                var query = @$"SELECT NUM_ACESSORIO
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_PLANO_ACESSORIO 
							WHERE NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND CODSUBES = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}' 
							AND OPCAO_COBER = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}' 
							AND DTINIVIG <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DTTERVIG >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND IDADE_INICIAL <= '{WHOST_IDADE}' 
							AND IDADE_FINAL >= '{WHOST_IDADE}' 
							AND PERIPGTO = 
							'{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}' 
							ORDER BY NUM_ACESSORIO";

                return query;
            }
            VGPLAACES.GetQueryEvent += GetQuery_VGPLAACES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_FIM*/

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-SECTION */
        private void R3120_00_FETCH_VGPLARAMC_SECTION()
        {
            /*" -5477- MOVE 'R3120-00-FETCH-VG-PLANO-RAMO-COB' TO COMANDO */
            _.Move("R3120-00-FETCH-VG-PLANO-RAMO-COB", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5481- MOVE 'FETCH VGPLARAMC' TO COMANDO. */
            _.Move("FETCH VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5482- MOVE 53 TO SII */
            _.Move(53, WS_HORAS.SII);

            /*" -5483- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5491- PERFORM R3120_00_FETCH_VGPLARAMC_DB_FETCH_1 */

            R3120_00_FETCH_VGPLARAMC_DB_FETCH_1();

            /*" -5494- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5495- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5496- MOVE 'S' TO WFIM-VGPLARAMC */
                _.Move("S", WORK_AREA.WFIM_VGPLARAMC);

                /*" -5496- PERFORM R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1 */

                R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1();

                /*" -5499- GO TO R3120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5499- PERFORM R3130-00-INSERT-VGHISTRAMCOB. */

            R3130_00_INSERT_VGHISTRAMCOB_SECTION();

        }

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-DB-FETCH-1 */
        public void R3120_00_FETCH_VGPLARAMC_DB_FETCH_1()
        {
            /*" -5491- EXEC SQL FETCH VGPLARAMC INTO :VGPLAR-NUM-RAMO, :VGPLAR-NUM-COBERTURA, :VGPLAR-QTD-COBERTURA, :VGPLAR-IMPSEGURADA, :VGPLAR-CUSTO, :VGPLAR-PREMIO END-EXEC. */

            if (VGPLARAMC.Fetch())
            {
                _.Move(VGPLARAMC.VGPLAR_NUM_RAMO, VGPLAR_NUM_RAMO);
                _.Move(VGPLARAMC.VGPLAR_NUM_COBERTURA, VGPLAR_NUM_COBERTURA);
                _.Move(VGPLARAMC.VGPLAR_QTD_COBERTURA, VGPLAR_QTD_COBERTURA);
                _.Move(VGPLARAMC.VGPLAR_IMPSEGURADA, VGPLAR_IMPSEGURADA);
                _.Move(VGPLARAMC.VGPLAR_CUSTO, VGPLAR_CUSTO);
                _.Move(VGPLARAMC.VGPLAR_PREMIO, VGPLAR_PREMIO);
            }

        }

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-DB-CLOSE-1 */
        public void R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1()
        {
            /*" -5496- EXEC SQL CLOSE VGPLARAMC END-EXEC */

            VGPLARAMC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3130-00-INSERT-VGHISTRAMCOB-SECTION */
        private void R3130_00_INSERT_VGHISTRAMCOB_SECTION()
        {
            /*" -5510- MOVE 'INSERT VG_HIST_RAMO_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_RAMO_COB", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5511- MOVE 54 TO SII */
            _.Move(54, WS_HORAS.SII);

            /*" -5512- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5522- PERFORM R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1 */

            R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1();

            /*" -5525- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5527- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5529- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5529- ADD 1 TO AC-I-HISTRAMOCOB. */
            WORK_AREA.AC_I_HISTRAMOCOB.Value = WORK_AREA.AC_I_HISTRAMOCOB + 1;

        }

        [StopWatch]
        /*" R3130-00-INSERT-VGHISTRAMCOB-DB-INSERT-1 */
        public void R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1()
        {
            /*" -5522- EXEC SQL INSERT INTO SEGUROS.VG_HIST_RAMO_COB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :VGPLAR-NUM-RAMO, :VGPLAR-NUM-COBERTURA, :VGPLAR-QTD-COBERTURA, :VGPLAR-IMPSEGURADA, :VGPLAR-CUSTO, :VGPLAR-PREMIO) END-EXEC. */

            var r3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1 = new R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                VGPLAR_NUM_RAMO = VGPLAR_NUM_RAMO.ToString(),
                VGPLAR_NUM_COBERTURA = VGPLAR_NUM_COBERTURA.ToString(),
                VGPLAR_QTD_COBERTURA = VGPLAR_QTD_COBERTURA.ToString(),
                VGPLAR_IMPSEGURADA = VGPLAR_IMPSEGURADA.ToString(),
                VGPLAR_CUSTO = VGPLAR_CUSTO.ToString(),
                VGPLAR_PREMIO = VGPLAR_PREMIO.ToString(),
            };

            R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1.Execute(r3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_99_FIM*/

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-SECTION */
        private void R3150_00_DECLARE_VGPLAACES_SECTION()
        {
            /*" -5541- MOVE 'DECLARE VGPLAACES ' TO COMANDO. */
            _.Move("DECLARE VGPLAACES ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5564- PERFORM R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1 */

            R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1();

            /*" -5568- MOVE 'OPEN  VGPLAACES' TO COMANDO. */
            _.Move("OPEN  VGPLAACES", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5569- MOVE 55 TO SII */
            _.Move(55, WS_HORAS.SII);

            /*" -5570- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5570- PERFORM R3150_00_DECLARE_VGPLAACES_DB_OPEN_1 */

            R3150_00_DECLARE_VGPLAACES_DB_OPEN_1();

            /*" -5573- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5575- MOVE SPACES TO WFIM-VGPLAACES. */
            _.Move("", WORK_AREA.WFIM_VGPLAACES);

            /*" -5576- PERFORM R3160-00-FETCH-VGPLAACES UNTIL WFIM-VGPLAACES NOT EQUAL SPACES. */

            while (!(!WORK_AREA.WFIM_VGPLAACES.IsEmpty()))
            {

                R3160_00_FETCH_VGPLAACES_SECTION();
            }

        }

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-DB-OPEN-1 */
        public void R3150_00_DECLARE_VGPLAACES_DB_OPEN_1()
        {
            /*" -5570- EXEC SQL OPEN VGPLAACES END-EXEC. */

            VGPLAACES.Open();

        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-DECLARE-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_DECLARE_1()
        {
            /*" -6533- EXEC SQL DECLARE C01_AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA END-EXEC. */
            C01_AGENCEF = new VA2601B_C01_AGENCEF(false);
            string GetQuery_C01_AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A
							, 
							SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            C01_AGENCEF.GetQueryEvent += GetQuery_C01_AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_FIM*/

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-SECTION */
        private void R3160_00_FETCH_VGPLAACES_SECTION()
        {
            /*" -5585- MOVE 'R3160-00-FETCH-VG-PLANO-ACESSORIO' TO COMANDO */
            _.Move("R3160-00-FETCH-VG-PLANO-ACESSORIO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5588- MOVE 'FETCH VGPLAACES' TO COMANDO. */
            _.Move("FETCH VGPLAACES", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5589- MOVE 56 TO SII */
            _.Move(56, WS_HORAS.SII);

            /*" -5590- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5597- PERFORM R3160_00_FETCH_VGPLAACES_DB_FETCH_1 */

            R3160_00_FETCH_VGPLAACES_DB_FETCH_1();

            /*" -5600- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5601- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5602- MOVE 'S' TO WFIM-VGPLAACES */
                _.Move("S", WORK_AREA.WFIM_VGPLAACES);

                /*" -5602- PERFORM R3160_00_FETCH_VGPLAACES_DB_CLOSE_1 */

                R3160_00_FETCH_VGPLAACES_DB_CLOSE_1();

                /*" -5605- GO TO R3160-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5605- PERFORM R3170-00-INSERT-VGHISACESSCOB. */

            R3170_00_INSERT_VGHISACESSCOB_SECTION();

        }

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-DB-FETCH-1 */
        public void R3160_00_FETCH_VGPLAACES_DB_FETCH_1()
        {
            /*" -5597- EXEC SQL FETCH VGPLAACES INTO :VGPLAA-NUM-ACESSORIO, :VGPLAA-QTD-COBERTURA, :VGPLAA-IMPSEGURADA, :VGPLAA-CUSTO, :VGPLAA-PREMIO END-EXEC. */

            if (VGPLAACES.Fetch())
            {
                _.Move(VGPLAACES.VGPLAA_NUM_ACESSORIO, VGPLAA_NUM_ACESSORIO);
                _.Move(VGPLAACES.VGPLAA_QTD_COBERTURA, VGPLAA_QTD_COBERTURA);
                _.Move(VGPLAACES.VGPLAA_IMPSEGURADA, VGPLAA_IMPSEGURADA);
                _.Move(VGPLAACES.VGPLAA_CUSTO, VGPLAA_CUSTO);
                _.Move(VGPLAACES.VGPLAA_PREMIO, VGPLAA_PREMIO);
            }

        }

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-DB-CLOSE-1 */
        public void R3160_00_FETCH_VGPLAACES_DB_CLOSE_1()
        {
            /*" -5602- EXEC SQL CLOSE VGPLAACES END-EXEC */

            VGPLAACES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_99_SAIDA*/

        [StopWatch]
        /*" R3170-00-INSERT-VGHISACESSCOB-SECTION */
        private void R3170_00_INSERT_VGHISACESSCOB_SECTION()
        {
            /*" -5616- MOVE 'INSERT VG_HIST_ACESS_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_ACESS_COB", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5617- MOVE 57 TO SII */
            _.Move(57, WS_HORAS.SII);

            /*" -5618- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5627- PERFORM R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1 */

            R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1();

            /*" -5630- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5632- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5634- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5634- ADD 1 TO AC-I-HISTACESCOB. */
            WORK_AREA.AC_I_HISTACESCOB.Value = WORK_AREA.AC_I_HISTACESCOB + 1;

        }

        [StopWatch]
        /*" R3170-00-INSERT-VGHISACESSCOB-DB-INSERT-1 */
        public void R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1()
        {
            /*" -5627- EXEC SQL INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :VGPLAA-NUM-ACESSORIO, :VGPLAA-QTD-COBERTURA, :VGPLAA-IMPSEGURADA, :VGPLAA-CUSTO, :VGPLAA-PREMIO) END-EXEC. */

            var r3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1 = new R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                VGPLAA_NUM_ACESSORIO = VGPLAA_NUM_ACESSORIO.ToString(),
                VGPLAA_QTD_COBERTURA = VGPLAA_QTD_COBERTURA.ToString(),
                VGPLAA_IMPSEGURADA = VGPLAA_IMPSEGURADA.ToString(),
                VGPLAA_CUSTO = VGPLAA_CUSTO.ToString(),
                VGPLAA_PREMIO = VGPLAA_PREMIO.ToString(),
            };

            R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1.Execute(r3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_99_FIM*/

        [StopWatch]
        /*" R3200-00-INSERT-OPCAOPAGVA-SECTION */
        private void R3200_00_INSERT_OPCAOPAGVA_SECTION()
        {
            /*" -5650- MOVE PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ TO WHOST-OPCAOPAG. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG, WHOST_OPCAOPAG);

            /*" -5651- IF WHOST-OPCAOPAG EQUAL '3' */

            if (WHOST_OPCAOPAG == "3")
            {

                /*" -5655- MOVE -1 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                _.Move(-1, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                /*" -5657- MOVE '5' TO WHOST-OPCAOPAG. */
                _.Move("5", WHOST_OPCAOPAG);
            }


            /*" -5658- IF WHOST-OPCAOPAG EQUAL '1' */

            if (WHOST_OPCAOPAG == "1")
            {

                /*" -5662- MOVE +0 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                _.Move(+0, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                /*" -5663- IF PROPOFID-OPRCTADEB OF DCLPROPOSTA-FIDELIZ EQUAL 13 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 13)
                {

                    /*" -5664- MOVE '2' TO WHOST-OPCAOPAG */
                    _.Move("2", WHOST_OPCAOPAG);

                    /*" -5665- END-IF */
                }


                /*" -5666- ELSE */
            }
            else
            {


                /*" -5670- MOVE -1 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                _.Move(-1, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                /*" -5672- MOVE '3' TO WHOST-OPCAOPAG. */
                _.Move("3", WHOST_OPCAOPAG);
            }


            /*" -5686- MOVE '3200-00-INSERT-OPCAOPAGVA  ' TO PARAGRAFO. */
            _.Move("3200-00-INSERT-OPCAOPAGVA  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5687- MOVE 58 TO SII */
            _.Move(58, WS_HORAS.SII);

            /*" -5688- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5708- PERFORM R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1 */

            R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1();

            /*" -5711- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5713- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5714- DISPLAY 'PROBLEMAS NO INSERT OPCAOPAGVA ' */
                _.Display($"PROBLEMAS NO INSERT OPCAOPAGVA ");

                /*" -5714- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-INSERT-OPCAOPAGVA-DB-INSERT-1 */
        public void R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1()
        {
            /*" -5708- EXEC SQL INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, '9999-12-31' , :WHOST-OPCAOPAG, :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO, 'VA2601B' , CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB :VIND-AGECTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB :VIND-OPRCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB :VIND-NUMCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB :VIND-DIGCTADEB, NULL) END-EXEC. */

            var r3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 = new R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                VIND_AGECTADEB = VIND_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                VIND_OPRCTADEB = VIND_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                VIND_NUMCTADEB = VIND_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                VIND_DIGCTADEB = VIND_DIGCTADEB.ToString(),
            };

            R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1.Execute(r3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-INSERT-COMISICOBVA-SECTION */
        private void R3300_00_INSERT_COMISICOBVA_SECTION()
        {
            /*" -5722- MOVE '0' TO SIT-REGISTRO OF DCLCOMISS-ADIAN-SICOB. */
            _.Move("0", COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_REGISTRO);

            /*" -5723- MOVE ' ' TO SIT-FENAE OF DCLCOMISS-ADIAN-SICOB. */
            _.Move(" ", COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_FENAE);

            /*" -5757- MOVE ZEROS TO VAL-COMISSAO-VEN OF DCLCOMISS-ADIAN-SICOB VAL-ADIANTAMENTO OF DCLCOMISS-ADIAN-SICOB ORDEM-PAGAMENTO OF DCLCOMISS-ADIAN-SICOB NUM-ENDOSSO OF DCLCOMISS-ADIAN-SICOB NUM-MATR-GERENTE OF DCLCOMISS-ADIAN-SICOB COD-AGEN-GERENTE OF DCLCOMISS-ADIAN-SICOB OPE-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB NUM-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB DIG-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB VAL-COMIS-GERENTE OF DCLCOMISS-ADIAN-SICOB NUM-MATR-SUN OF DCLCOMISS-ADIAN-SICOB COD-AGEN-SUN OF DCLCOMISS-ADIAN-SICOB OPE-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB NUM-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB DIG-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB VAL-COMIS-SUN OF DCLCOMISS-ADIAN-SICOB. */
            _.Move(0, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMISSAO_VEN, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_ADIANTAMENTO, COADSICO.DCLCOMISS_ADIAN_SICOB.ORDEM_PAGAMENTO, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_ENDOSSO, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_SUN);

            /*" -5760- MOVE '3300-00-INSERT-COMISICOBVA ' TO PARAGRAFO. */
            _.Move("3300-00-INSERT-COMISICOBVA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5761- MOVE 59 TO SII */
            _.Move(59, WS_HORAS.SII);

            /*" -5762- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5798- PERFORM R3300_00_INSERT_COMISICOBVA_DB_INSERT_1 */

            R3300_00_INSERT_COMISICOBVA_DB_INSERT_1();

            /*" -5801- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5802- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5803- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -5804- MOVE 'SIM' TO WEXISTE-COMISSAO */
                    _.Move("SIM", WEXISTE_COMISSAO);

                    /*" -5805- ELSE */
                }
                else
                {


                    /*" -5806- DISPLAY 'PROBLEMAS NO INSERT COMISICOBVA ' */
                    _.Display($"PROBLEMAS NO INSERT COMISICOBVA ");

                    /*" -5807- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5808- ELSE */
                }

            }
            else
            {


                /*" -5808- MOVE 'NAO' TO WEXISTE-COMISSAO. */
                _.Move("NAO", WEXISTE_COMISSAO);
            }


        }

        [StopWatch]
        /*" R3300-00-INSERT-COMISICOBVA-DB-INSERT-1 */
        public void R3300_00_INSERT_COMISICOBVA_DB_INSERT_1()
        {
            /*" -5798- EXEC SQL INSERT INTO SEGUROS.COMISS_ADIAN_SICOB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :WHOST-FONTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLRCAPS.RCAPS-VAL-RCAP, :DCLCOMISS-ADIAN-SICOB.VAL-ADIANTAMENTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLCOMISS-ADIAN-SICOB.SIT-REGISTRO, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, CURRENT TIMESTAMP, :DCLCOMISS-ADIAN-SICOB.SIT-FENAE, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLCOMISS-ADIAN-SICOB.VAL-COMISSAO-VEN, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, :DCLCOMISS-ADIAN-SICOB.ORDEM-PAGAMENTO, :DCLCOMISS-ADIAN-SICOB.NUM-ENDOSSO, :DCLCOMISS-ADIAN-SICOB.NUM-MATR-GERENTE, :DCLCOMISS-ADIAN-SICOB.COD-AGEN-GERENTE, :DCLCOMISS-ADIAN-SICOB.OPE-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.NUM-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.DIG-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.VAL-COMIS-GERENTE, :DCLCOMISS-ADIAN-SICOB.NUM-MATR-SUN, :DCLCOMISS-ADIAN-SICOB.COD-AGEN-SUN, :DCLCOMISS-ADIAN-SICOB.OPE-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.NUM-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.DIG-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.VAL-COMIS-SUN) END-EXEC. */

            var r3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1 = new R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                VAL_ADIANTAMENTO = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_ADIANTAMENTO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIT_REGISTRO = COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_REGISTRO.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                SIT_FENAE = COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_FENAE.ToString(),
                VAL_COMISSAO_VEN = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMISSAO_VEN.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                ORDEM_PAGAMENTO = COADSICO.DCLCOMISS_ADIAN_SICOB.ORDEM_PAGAMENTO.ToString(),
                NUM_ENDOSSO = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_ENDOSSO.ToString(),
                NUM_MATR_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_GERENTE.ToString(),
                COD_AGEN_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_GERENTE.ToString(),
                OPE_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_GERENTE.ToString(),
                NUM_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_GERENTE.ToString(),
                DIG_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_GERENTE.ToString(),
                VAL_COMIS_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_GERENTE.ToString(),
                NUM_MATR_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_SUN.ToString(),
                COD_AGEN_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_SUN.ToString(),
                OPE_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_SUN.ToString(),
                NUM_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_SUN.ToString(),
                DIG_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_SUN.ToString(),
                VAL_COMIS_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_SUN.ToString(),
            };

            R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1.Execute(r3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-INSERT-PARCELVA-SECTION */
        private void R3400_00_INSERT_PARCELVA_SECTION()
        {
            /*" -5816- MOVE '0' TO SIT-REGISTRO OF DCLPARCELAS-VIDAZUL. */
            _.Move("0", PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO);

            /*" -5817- MOVE 1 TO NUM-PARCELA OF DCLPARCELAS-VIDAZUL. */
            _.Move(1, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA);

            /*" -5821- MOVE ZEROS TO PREMIO-AP OF DCLPARCELAS-VIDAZUL VLMULTA OF DCLPARCELAS-VIDAZUL OCORR-HISTORICO OF DCLPARCELAS-VIDAZUL. */
            _.Move(0, PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP, PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA, PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO);

            /*" -5825- MOVE '3400-00-INSERT-PARCELVA    ' TO PARAGRAFO. */
            _.Move("3400-00-INSERT-PARCELVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5826- MOVE 60 TO SII */
            _.Move(60, WS_HORAS.SII);

            /*" -5827- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5841- PERFORM R3400_00_INSERT_PARCELVA_DB_INSERT_1 */

            R3400_00_INSERT_PARCELVA_DB_INSERT_1();

            /*" -5844- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5846- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5847- DISPLAY 'PROBLEMAS NO INSERT PARCELVA    ' */
                _.Display($"PROBLEMAS NO INSERT PARCELVA    ");

                /*" -5847- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3400-00-INSERT-PARCELVA-DB-INSERT-1 */
        public void R3400_00_INSERT_PARCELVA_DB_INSERT_1()
        {
            /*" -5841- EXEC SQL INSERT INTO SEGUROS.PARCELAS_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :WHOST-DATA-AGENDAMENTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO, :DCLPARCELAS-VIDAZUL.PREMIO-AP, :DCLPARCELAS-VIDAZUL.VLMULTA, :WHOST-OPCAOPAG, :DCLPARCELAS-VIDAZUL.SIT-REGISTRO, :DCLPARCELAS-VIDAZUL.OCORR-HISTORICO, CURRENT TIMESTAMP) END-EXEC. */

            var r3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1 = new R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                WHOST_DATA_AGENDAMENTO = WHOST_DATA_AGENDAMENTO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PREMIO_AP = PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP.ToString(),
                VLMULTA = PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                SIT_REGISTRO = PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO.ToString(),
                OCORR_HISTORICO = PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO.ToString(),
            };

            R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1.Execute(r3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERT-HISTCOBVA-SECTION */
        private void R3500_00_INSERT_HISTCOBVA_SECTION()
        {
            /*" -5857- MOVE '3500-00-INSERT-HISTCOBVA   ' TO PARAGRAFO. */
            _.Move("3500-00-INSERT-HISTCOBVA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5858- MOVE '0' TO SIT-REGISTRO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move("0", CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO);

            /*" -5859- MOVE 201 TO COD-OPERACAO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(201, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO);

            /*" -5861- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO NUM-TITULO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);

            /*" -5863- MOVE 1 TO NUM-PARCELA OF DCLCOBER-HIST-VIDAZUL OCORR-HISTORICO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(1, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_PARCELA, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO);

            /*" -5867- MOVE ZEROS TO COD-DEVOLUCAO OF DCLCOBER-HIST-VIDAZUL NUM-TITULO-COMP OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(0, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP);

            /*" -5868- MOVE 61 TO SII */
            _.Move(61, WS_HORAS.SII);

            /*" -5869- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5887- PERFORM R3500_00_INSERT_HISTCOBVA_DB_INSERT_1 */

            R3500_00_INSERT_HISTCOBVA_DB_INSERT_1();

            /*" -5890- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5892- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5893- DISPLAY 'PROBLEMAS NO INSERT HISTCOBVA   ' */
                _.Display($"PROBLEMAS NO INSERT HISTCOBVA   ");

                /*" -5893- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3500-00-INSERT-HISTCOBVA-DB-INSERT-1 */
        public void R3500_00_INSERT_HISTCOBVA_DB_INSERT_1()
        {
            /*" -5887- EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO, :WHOST-DATA-AGENDAMENTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO, :WHOST-OPCAOPAG, :DCLCOBER-HIST-VIDAZUL.SIT-REGISTRO, :DCLCOBER-HIST-VIDAZUL.COD-OPERACAO, :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO, :DCLCOBER-HIST-VIDAZUL.COD-DEVOLUCAO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO-COMP) END-EXEC. */

            var r3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 = new R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                WHOST_DATA_AGENDAMENTO = WHOST_DATA_AGENDAMENTO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                SIT_REGISTRO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO.ToString(),
                COD_OPERACAO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                COD_DEVOLUCAO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                NUM_TITULO_COMP = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP.ToString(),
            };

            R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1.Execute(r3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3520-00-INSERT-HISTCONTAVA-SECTION */
        private void R3520_00_INSERT_HISTCONTAVA_SECTION()
        {
            /*" -5904- MOVE '3520-00-INSERT-HISTCONTAVA ' TO PARAGRAFO */
            _.Move("3520-00-INSERT-HISTCONTAVA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5908- MOVE 'INSERT HISTCONTAVA         ' TO COMANDO */
            _.Move("INSERT HISTCONTAVA         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5910- INITIALIZE DCLHIST-LANC-CTA */
            _.Initialize(
                HISLANCT.DCLHIST_LANC_CTA
            );

            /*" -5913- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO HISLANCT-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -5914- MOVE PROPOFID-VAL-PAGO TO HISLANCT-PRM-TOTAL */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);

            /*" -5916- MOVE 1 TO HISLANCT-NUM-PARCELA HISLANCT-OCORR-HISTORICOCTA */
            _.Move(1, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA);

            /*" -5917- MOVE '1' TO HISLANCT-TIPLANC */
            _.Move("1", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

            /*" -5919- MOVE '0' TO HISLANCT-SIT-REGISTRO */
            _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -5922- MOVE PROPOFID-AGECTADEB TO HISLANCT-COD-AGENCIA-DEBITO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO);

            /*" -5925- MOVE PROPOFID-OPRCTADEB TO HISLANCT-OPE-CONTA-DEBITO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OPE_CONTA_DEBITO);

            /*" -5928- MOVE PROPOFID-NUMCTADEB TO HISLANCT-NUM-CONTA-DEBITO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CONTA_DEBITO);

            /*" -5931- MOVE PROPOFID-DIGCTADEB TO HISLANCT-DIG-CONTA-DEBITO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DIG_CONTA_DEBITO);

            /*" -5936- MOVE 0 TO HISLANCT-NUM-CARTAO-CREDITO HISLANCT-OCORR-HISTORICO */
            _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CARTAO_CREDITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO);

            /*" -5938- MOVE 'VA2601B' TO HISLANCT-COD-USUARIO */
            _.Move("VA2601B", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO);

            /*" -5940- PERFORM R3525-00-CONSULTA-CONVENIOVG */

            R3525_00_CONSULTA_CONVENIOVG_SECTION();

            /*" -5942- MOVE CONVEVG-COD-SEGURO TO HISLANCT-CODCONV */
            _.Move(CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);

            /*" -5991- PERFORM R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1 */

            R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1();

            /*" -5995- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5996- DISPLAY 'PROBLEMAS NO INSERT HISTCONTAVA ' */
                _.Display($"PROBLEMAS NO INSERT HISTCONTAVA ");

                /*" -5997- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5997- END-IF. */
            }


        }

        [StopWatch]
        /*" R3520-00-INSERT-HISTCONTAVA-DB-INSERT-1 */
        public void R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1()
        {
            /*" -5991- EXEC SQL INSERT INTO SEGUROS.HIST_LANC_CTA ( NUM_CERTIFICADO , NUM_PARCELA , OCORR_HISTORICOCTA , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , DATA_VENCIMENTO , PRM_TOTAL , SIT_REGISTRO , TIPLANC , TIMESTAMP , OCORR_HISTORICO , CODCONV , NSAS , NSL , NSAC , CODRET , COD_USUARIO , NUM_CARTAO_CREDITO , COD_BANCO ) VALUES ( :HISLANCT-NUM-CERTIFICADO , :HISLANCT-NUM-PARCELA , :HISLANCT-OCORR-HISTORICOCTA , :HISLANCT-COD-AGENCIA-DEBITO , :HISLANCT-OPE-CONTA-DEBITO , :HISLANCT-NUM-CONTA-DEBITO , :HISLANCT-DIG-CONTA-DEBITO , :WHOST-DATA-AGENDAMENTO , :HISLANCT-PRM-TOTAL , :HISLANCT-SIT-REGISTRO , :HISLANCT-TIPLANC , CURRENT TIMESTAMP , :HISLANCT-OCORR-HISTORICO , :HISLANCT-CODCONV , NULL , NULL , NULL , NULL , :HISLANCT-COD-USUARIO , :HISLANCT-NUM-CARTAO-CREDITO , NULL ) END-EXEC. */

            var r3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 = new R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_COD_AGENCIA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO.ToString(),
                HISLANCT_OPE_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OPE_CONTA_DEBITO.ToString(),
                HISLANCT_NUM_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CONTA_DEBITO.ToString(),
                HISLANCT_DIG_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DIG_CONTA_DEBITO.ToString(),
                WHOST_DATA_AGENDAMENTO = WHOST_DATA_AGENDAMENTO.ToString(),
                HISLANCT_PRM_TOTAL = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL.ToString(),
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_TIPLANC = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC.ToString(),
                HISLANCT_OCORR_HISTORICO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO.ToString(),
                HISLANCT_CODCONV = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.ToString(),
                HISLANCT_COD_USUARIO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO.ToString(),
                HISLANCT_NUM_CARTAO_CREDITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CARTAO_CREDITO.ToString(),
            };

            R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1.Execute(r3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3520_99_SAIDA*/

        [StopWatch]
        /*" R3525-00-CONSULTA-CONVENIOVG-SECTION */
        private void R3525_00_CONSULTA_CONVENIOVG_SECTION()
        {
            /*" -6007- MOVE 'R3525-00-CONSULTA-CONVENIOVG ' TO PARAGRAFO */
            _.Move("R3525-00-CONSULTA-CONVENIOVG ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6009- MOVE 'CONSULTA CONVENIOS_VG        ' TO COMANDO */
            _.Move("CONSULTA CONVENIOS_VG        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6011- INITIALIZE DCLCONVENIOS-VG */
            _.Initialize(
                CONVEVG.DCLCONVENIOS_VG
            );

            /*" -6012- MOVE PROPSSVD-NUM-APOLICE TO CONVEVG-NUM-APOLICE */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, CONVEVG.DCLCONVENIOS_VG.CONVEVG_NUM_APOLICE);

            /*" -6017- MOVE PROPSSVD-COD-SUBGRUPO TO CONVEVG-CODSUBES */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODSUBES);

            /*" -6026- PERFORM R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1 */

            R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1();

            /*" -6029-  EVALUATE SQLCODE  */

            /*" -6030-  WHEN ZEROS  */

            /*" -6030- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6031- CONTINUE */

                /*" -6032-  WHEN +100  */

                /*" -6032- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -6034- MOVE ZEROS TO CONVEVG-COD-SEGURO CONVEVG-COD-CONV-CARTAO */
                _.Move(0, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_CONV_CARTAO);

                /*" -6035-  WHEN OTHER  */

                /*" -6035- ELSE */
            }
            else
            {


                /*" -6036- DISPLAY 'R3525-00 (ERRO - SELECT CONVENIOS_VG)' */
                _.Display($"R3525-00 (ERRO - SELECT CONVENIOS_VG)");

                /*" -6038- DISPLAY 'APOL...: ' CONVEVG-NUM-APOLICE 'SUBGRUP: ' CONVEVG-CODSUBES */

                $"APOL...: {CONVEVG.DCLCONVENIOS_VG.CONVEVG_NUM_APOLICE}SUBGRUP: {CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODSUBES}"
                .Display();

                /*" -6039- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6040-  END-EVALUATE.  */

                /*" -6040- END-IF. */
            }


        }

        [StopWatch]
        /*" R3525-00-CONSULTA-CONVENIOVG-DB-SELECT-1 */
        public void R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1()
        {
            /*" -6026- EXEC SQL SELECT COD_SEGURO , COD_CONV_CARTAO INTO :CONVEVG-COD-SEGURO , :CONVEVG-COD-CONV-CARTAO FROM SEGUROS.CONVENIOS_VG WHERE NUM_APOLICE = :CONVEVG-NUM-APOLICE AND CODSUBES = :CONVEVG-CODSUBES WITH UR END-EXEC */

            var r3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 = new R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1()
            {
                CONVEVG_NUM_APOLICE = CONVEVG.DCLCONVENIOS_VG.CONVEVG_NUM_APOLICE.ToString(),
                CONVEVG_CODSUBES = CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODSUBES.ToString(),
            };

            var executed_1 = R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1.Execute(r3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVEVG_COD_SEGURO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO);
                _.Move(executed_1.CONVEVG_COD_CONV_CARTAO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_CONV_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3525_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-INSERT-HISTCONTABILVA-SECTION */
        private void R3600_00_INSERT_HISTCONTABILVA_SECTION()
        {
            /*" -6047- MOVE '0' TO SIT-REGISTRO OF DCLHIST-CONT-PARCELVA. */
            _.Move("0", HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO);

            /*" -6050- MOVE ZEROS TO NUM-ENDOSSO OF DCLHIST-CONT-PARCELVA PREMIO-AP OF DCLHIST-CONT-PARCELVA. */
            _.Move(0, HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP);

            /*" -6051- MOVE 201 TO COD-OPERACAO OF DCLHIST-CONT-PARCELVA. */
            _.Move(201, HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO);

            /*" -6052- MOVE SPACES TO DTFATUR OF DCLHIST-CONT-PARCELVA. */
            _.Move("", HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR);

            /*" -6055- MOVE -1 TO VIND-DTFATUR. */
            _.Move(-1, VIND_DTFATUR);

            /*" -6058- MOVE '3600-00-INSERT-HISTCONTABILVA' TO PARAGRAFO. */
            _.Move("3600-00-INSERT-HISTCONTABILVA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6059- MOVE 62 TO SII */
            _.Move(62, WS_HORAS.SII);

            /*" -6060- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6078- PERFORM R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1 */

            R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1();

            /*" -6081- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6083- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6084- DISPLAY 'PROBLEMAS NO INSERT HISTCONTABILVA ' */
                _.Display($"PROBLEMAS NO INSERT HISTCONTABILVA ");

                /*" -6084- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3600-00-INSERT-HISTCONTABILVA-DB-INSERT-1 */
        public void R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1()
        {
            /*" -6078- EXEC SQL INSERT INTO SEGUROS.HIST_CONT_PARCELVA VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO, :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, :WHOST-FONTE, :DCLHIST-CONT-PARCELVA.NUM-ENDOSSO, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLHIST-CONT-PARCELVA.PREMIO-AP, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLHIST-CONT-PARCELVA.SIT-REGISTRO, :DCLHIST-CONT-PARCELVA.COD-OPERACAO, CURRENT TIMESTAMP, :DCLHIST-CONT-PARCELVA.DTFATUR:VIND-DTFATUR) END-EXEC. */

            var r3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 = new R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                NUM_ENDOSSO = HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                PREMIO_AP = HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIT_REGISTRO = HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO.ToString(),
                COD_OPERACAO = HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO.ToString(),
                DTFATUR = HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR.ToString(),
                VIND_DTFATUR = VIND_DTFATUR.ToString(),
            };

            R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1.Execute(r3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-SECTION */
        private void R3700_00_INSERT_RELATORIOS_SECTION()
        {
            /*" -6092- MOVE '3700-00-INSERT-RELATORIOS    ' TO PARAGRAFO. */
            _.Move("3700-00-INSERT-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6094- MOVE '3700-00-SELECT-RELATORIOS    ' TO COMANDO. */
            _.Move("3700-00-SELECT-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6095- MOVE 63 TO SII */
            _.Move(63, WS_HORAS.SII);

            /*" -6096- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6103- PERFORM R3700_00_INSERT_RELATORIOS_DB_SELECT_1 */

            R3700_00_INSERT_RELATORIOS_DB_SELECT_1();

            /*" -6106- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6107- IF SQLCODE NOT EQUAL ZEROES AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -6109- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6110- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6111- GO TO R3700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;

                /*" -6112- ELSE */
            }
            else
            {


                /*" -6114- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -6115- ELSE */
                }
                else
                {


                    /*" -6116- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -6117- MOVE '3700-00-UPDATE-RELATORIOS    ' TO COMANDO */
                        _.Move("3700-00-UPDATE-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                        /*" -6118- MOVE 64 TO SII */
                        _.Move(64, WS_HORAS.SII);

                        /*" -6119- PERFORM R9000-00-INICIO */

                        R9000_00_INICIO_SECTION();

                        /*" -6126- PERFORM R3700_00_INSERT_RELATORIOS_DB_UPDATE_1 */

                        R3700_00_INSERT_RELATORIOS_DB_UPDATE_1();

                        /*" -6128- PERFORM R9100-00-TERMINO */

                        R9100_00_TERMINO_SECTION();

                        /*" -6129- IF SQLCODE NOT EQUAL ZEROES */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -6131- GO TO R9999-00-ROT-ERRO. */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -6132- MOVE '3700-00-INSERT-RELATORIOS    ' TO COMANDO */
            _.Move("3700-00-INSERT-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6134- MOVE 65 TO SII */
            _.Move(65, WS_HORAS.SII);

            /*" -6135- IF (PROPOFID-NUMCTADEB NOT EQUAL ZEROS) */

            if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB != 00))
            {

                /*" -6136- MOVE 104 TO WHOST-BCO-RELAT */
                _.Move(104, WHOST_BCO_RELAT);

                /*" -6137- MOVE PROPOFID-VAL-PAGO TO WHOST-VLR-RELAT */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, WHOST_VLR_RELAT);

                /*" -6138- COMPUTE WHOST-VLR-RELAT = WHOST-VLR-RELAT * 100 */
                WHOST_VLR_RELAT.Value = WHOST_VLR_RELAT * 100;

                /*" -6139- MOVE WHOST-VLR-RELAT TO WHOST-SIN-RELAT */
                _.Move(WHOST_VLR_RELAT, WHOST_SIN_RELAT);

                /*" -6140- ELSE */
            }
            else
            {


                /*" -6146- MOVE ZEROS TO WHOST-BCO-RELAT PROPOFID-AGECTADEB PROPOFID-OPRCTADEB PROPOFID-NUMCTADEB PROPOFID-DIGCTADEB WHOST-SIN-RELAT */
                _.Move(0, WHOST_BCO_RELAT, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB, WHOST_SIN_RELAT);

                /*" -6148- END-IF. */
            }


            /*" -6150- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6200- PERFORM R3700_00_INSERT_RELATORIOS_DB_INSERT_1 */

            R3700_00_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -6203- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6204- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6205- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-SELECT-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_SELECT_1()
        {
            /*" -6103- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' END-EXEC */

            var r3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 = new R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1.Execute(r3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }


        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-UPDATE-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_UPDATE_1()
        {
            /*" -6126- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' END-EXEC */

            var r3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1 = new R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1.Execute(r3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-INSERT-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -6200- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA2601B' , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 'VA' , 'VA0469B' , 2, :WHOST-BCO-RELAT, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB, 0, 0, 0, 0, 0, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, 0, 1, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 0, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, 16, 0, 0, ' ' , ' ' , 0, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB, ' ' , :WHOST-SIN-RELAT, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WHOST_BCO_RELAT = WHOST_BCO_RELAT.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                WHOST_SIN_RELAT = WHOST_SIN_RELAT.ToString(),
            };

            R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(r3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R5632-00-SELECT-PROPOSTAVA-SECTION */
        private void R5632_00_SELECT_PROPOSTAVA_SECTION()
        {
            /*" -6214- MOVE 'R5632-00-SELECT-PROPOSTAVA  ' TO PARAGRAFO. */
            _.Move("R5632-00-SELECT-PROPOSTAVA  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6218- MOVE 'SELECT SEGUROS.PROPOSTAS-VA  ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PROPOSTAS-VA  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6221- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLPROPOSTAS-VA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);

            /*" -6222- MOVE 66 TO SII */
            _.Move(66, WS_HORAS.SII);

            /*" -6223- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6228- PERFORM R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1 */

            R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1();

            /*" -6231- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6232- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -6233- MOVE 'SIM' TO WEXISTE-PRPVA */
                _.Move("SIM", WEXISTE_PRPVA);

                /*" -6234- DISPLAY ' ' */
                _.Display($" ");

                /*" -6236- DISPLAY 'PROPOSTA CADASTRADA ESTRUTURA MULT ==>  ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"PROPOSTA CADASTRADA ESTRUTURA MULT ==>  {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -6237- ELSE */
            }
            else
            {


                /*" -6237- MOVE 'NAO' TO WEXISTE-PRPVA. */
                _.Move("NAO", WEXISTE_PRPVA);
            }


        }

        [StopWatch]
        /*" R5632-00-SELECT-PROPOSTAVA-DB-SELECT-1 */
        public void R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -6228- EXEC SQL SELECT SIT_REGISTRO INTO :DCLPROPOSTAS-VA.SIT-REGISTRO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO END-EXEC. */

            var r5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 = new R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIT_REGISTRO, PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5632_99_SAIDA*/

        [StopWatch]
        /*" R5633-00-UPDATE-PRP-FIDELIZ-SECTION */
        private void R5633_00_UPDATE_PRP_FIDELIZ_SECTION()
        {
            /*" -6250- MOVE 'R5633-00-UPDATE-PRP-FIDELIZ   ' TO PARAGRAFO. */
            _.Move("R5633-00-UPDATE-PRP-FIDELIZ   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6251- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '0' */

            if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "0")
            {

                /*" -6252- MOVE 'PAI' TO WHOST-SIT-PROPOSTA */
                _.Move("PAI", WHOST_SIT_PROPOSTA);

                /*" -6253- MOVE ' ' TO WHOST-SIT-ENVIO */
                _.Move(" ", WHOST_SIT_ENVIO);

                /*" -6254- ELSE */
            }
            else
            {


                /*" -6255- MOVE 'S' TO WHOST-SIT-ENVIO */
                _.Move("S", WHOST_SIT_ENVIO);

                /*" -6256- IF NOT RCAP-CADASTRADO */

                if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                {

                    /*" -6257- MOVE 'POB' TO WHOST-SIT-PROPOSTA */
                    _.Move("POB", WHOST_SIT_PROPOSTA);

                    /*" -6258- ELSE */
                }
                else
                {


                    /*" -6259- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '1' */

                    if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "1")
                    {

                        /*" -6260- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                        _.Move("PEN", WHOST_SIT_PROPOSTA);

                        /*" -6261- ELSE */
                    }
                    else
                    {


                        /*" -6262- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '3' */

                        if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "3")
                        {

                            /*" -6263- MOVE 'EMT' TO WHOST-SIT-PROPOSTA */
                            _.Move("EMT", WHOST_SIT_PROPOSTA);

                            /*" -6264- ELSE */
                        }
                        else
                        {


                            /*" -6265- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '5' */

                            if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "5")
                            {

                                /*" -6266- MOVE 'POB' TO WHOST-SIT-PROPOSTA */
                                _.Move("POB", WHOST_SIT_PROPOSTA);

                                /*" -6267- ELSE */
                            }
                            else
                            {


                                /*" -6269- MOVE 'EMT' TO WHOST-SIT-PROPOSTA. */
                                _.Move("EMT", WHOST_SIT_PROPOSTA);
                            }

                        }

                    }

                }

            }


            /*" -6270- MOVE 67 TO SII */
            _.Move(67, WS_HORAS.SII);

            /*" -6271- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6278- PERFORM R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1 */

            R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -6281- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6282- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6284- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID  - R5633  ' SQLCODE */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID  - R5633  {DB.SQLCODE}");

                /*" -6284- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5633-00-UPDATE-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -6278- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO, DTQITBCO = :WHOST-DATA-AGENDAMENTO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                WHOST_DATA_AGENDAMENTO = WHOST_DATA_AGENDAMENTO.ToString(),
                WHOST_SIT_PROPOSTA = WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WHOST_SIT_ENVIO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5633_99_SAIDA*/

        [StopWatch]
        /*" R5634-00-SELECT-SEGUROS-PF-CBO-SECTION */
        private void R5634_00_SELECT_SEGUROS_PF_CBO_SECTION()
        {
            /*" -6293- MOVE 'R5634-00-SELECT-SEGUROS-PF-CBO     ' TO PARAGRAFO. */
            _.Move("R5634-00-SELECT-SEGUROS-PF-CBO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6297- MOVE 'SELECT SEGUROS.PF_CBO              ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PF_CBO              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6300- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO PF062-NUM-PROPOSTA-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF);

            /*" -6301- MOVE 68 TO SII */
            _.Move(68, WS_HORAS.SII);

            /*" -6302- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6307- PERFORM R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1 */

            R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1();

            /*" -6310- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6311- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -6312- MOVE PF062-DES-CBO TO WHOST-PROFISSAO */
                _.Move(PF062.DCLPF_CBO.PF062_DES_CBO, WHOST_PROFISSAO);

                /*" -6313- ELSE */
            }
            else
            {


                /*" -6314- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6315- MOVE SPACES TO WHOST-PROFISSAO */
                    _.Move("", WHOST_PROFISSAO);

                    /*" -6316- ELSE */
                }
                else
                {


                    /*" -6317- DISPLAY 'PROBLEMAS NO ACESSO A PF-CBO ' */
                    _.Display($"PROBLEMAS NO ACESSO A PF-CBO ");

                    /*" -6318- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5634-00-SELECT-SEGUROS-PF-CBO-DB-SELECT-1 */
        public void R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1()
        {
            /*" -6307- EXEC SQL SELECT DES_CBO INTO :PF062-DES-CBO FROM SEGUROS.PF_CBO WHERE NUM_PROPOSTA_SIVPF = :PF062-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1 = new R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1()
            {
                PF062_NUM_PROPOSTA_SIVPF = PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1.Execute(r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF062_DES_CBO, PF062.DCLPF_CBO.PF062_DES_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5634_99_SAIDA*/

        [StopWatch]
        /*" R5635-00-UPDATE-PROPOSTAVA-SECTION */
        private void R5635_00_UPDATE_PROPOSTAVA_SECTION()
        {
            /*" -6331- MOVE PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ TO DATA-SQL1. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WORK_AREA.DATA_SQL1);

            /*" -6334- COMPUTE MES-SQL = MES-SQL + PRODUVG-PERI-PAGAMENTO OF DCLPRODUTOS-VG. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO;

            /*" -6335- IF MES-SQL GREATER 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -6338- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -6341- COMPUTE ANO-SQL = ANO-SQL + 1. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -6343- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -6344- IF PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO > 00)
            {

                /*" -6347- MOVE PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ TO DIA-SQL. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -6348- IF DIA-SQL GREATER 28 */

            if (WORK_AREA.DATA_SQL.DIA_SQL > 28)
            {

                /*" -6350- MOVE 28 TO DIA-SQL. */
                _.Move(28, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -6351- IF DATA-SQL LESS WHOST-DTPROXVEN */

            if (WORK_AREA.DATA_SQL < WHOST_DTPROXVEN)
            {

                /*" -6352- ADD 1 TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                /*" -6353- IF MES-SQL GREATER 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -6354- MOVE 1 TO MES-SQL */
                    _.Move(1, WORK_AREA.DATA_SQL.MES_SQL);

                    /*" -6356- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -6369- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -6371- MOVE -1 TO VIND-DATA-DECLINIO */
            _.Move(-1, VIND_DATA_DECLINIO);

            /*" -6378- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -6379- MOVE '2' TO WHOST-SIT-REGISTRO */
                _.Move("2", WHOST_SIT_REGISTRO);

                /*" -6380- MOVE ZEROS TO VIND-DATA-DECLINIO */
                _.Move(0, VIND_DATA_DECLINIO);

                /*" -6381- ELSE */
            }
            else
            {


                /*" -6382- IF WS-TEM-ERRO-DAD-CAD EQUAL 'SIM' */

                if (WORK_AREA.WS_TEM_ERRO_DAD_CAD == "SIM")
                {

                    /*" -6383- MOVE '1' TO WHOST-SIT-REGISTRO */
                    _.Move("1", WHOST_SIT_REGISTRO);

                    /*" -6384- ELSE */
                }
                else
                {


                    /*" -6390- IF WS-TEM-ERRO EQUAL ZEROS AND IMPMORNATU OF DCLPLANOS-VA-VGAP NOT GREATER 200000,00 */

                    if (WORK_AREA.WS_TEM_ERRO == 00 && PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU <= 200000.00)
                    {

                        /*" -6391- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                        {

                            /*" -6392- MOVE '0' TO WHOST-SIT-REGISTRO */
                            _.Move("0", WHOST_SIT_REGISTRO);

                            /*" -6393- ELSE */
                        }
                        else
                        {


                            /*" -6394- MOVE 'E' TO WHOST-SIT-REGISTRO */
                            _.Move("E", WHOST_SIT_REGISTRO);

                            /*" -6395- END-IF */
                        }


                        /*" -6396- ELSE */
                    }
                    else
                    {


                        /*" -6397- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                        {

                            /*" -6398- MOVE '9' TO WHOST-SIT-REGISTRO */
                            _.Move("9", WHOST_SIT_REGISTRO);

                            /*" -6399- ELSE */
                        }
                        else
                        {


                            /*" -6400- MOVE 'E' TO WHOST-SIT-REGISTRO */
                            _.Move("E", WHOST_SIT_REGISTRO);

                            /*" -6401- END-IF */
                        }


                        /*" -6402- END-IF */
                    }


                    /*" -6403- END-IF */
                }


                /*" -6405- END-IF. */
            }


            /*" -6406- IF WHOST-SIT-REGISTRO EQUAL 'E' */

            if (WHOST_SIT_REGISTRO == "E")
            {

                /*" -6407- MOVE '7' TO WHOST-SIT-REGISTRO */
                _.Move("7", WHOST_SIT_REGISTRO);

                /*" -6412- END-IF. */
            }


            /*" -6413- IF VIND-PROFISSAO-CONJUGE EQUAL ZEROS */

            if (VIND_PROFISSAO_CONJUGE == 00)
            {

                /*" -6417- IF PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ > ZEROS AND PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ < 1000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE > 00 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE < 1000)
                {

                    /*" -6420- MOVE TAB-DESCR-CBO-C (PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ) TO WHOST-PROFISSAO-CONJUGE */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_27[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE].TAB_DESCR_CBO_C, WHOST_PROFISSAO_CONJUGE);

                    /*" -6424- ELSE */
                }
                else
                {


                    /*" -6425- MOVE SPACES TO WHOST-PROFISSAO-CONJUGE */
                    _.Move("", WHOST_PROFISSAO_CONJUGE);

                    /*" -6426- END-IF */
                }


                /*" -6428- END-IF. */
            }


            /*" -6430- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -6432- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_26[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -6433- ELSE */
            }
            else
            {


                /*" -6436- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -6437- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -6439- END-IF. */
            }


            /*" -6441- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -6447- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -6448- MOVE '5635-00-UPDATE-PROPOSTAVA    ' TO PARAGRAFO. */
            _.Move("5635-00-UPDATE-PROPOSTAVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6451- MOVE 'UPDATE PROPOSTAVA            ' TO COMANDO. */
            _.Move("UPDATE PROPOSTAVA            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6452- MOVE 69 TO SII */
            _.Move(69, WS_HORAS.SII);

            /*" -6453- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6503- PERFORM R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1 */

            R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1();

            /*" -6506- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6507- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6508- DISPLAY 'PROBLEMAS NO UPDATE PROPOSTAVA ' */
                _.Display($"PROBLEMAS NO UPDATE PROPOSTAVA ");

                /*" -6510- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6511- ADD 1 TO AC-I-PROPOSTAVA. */
            WORK_AREA.AC_I_PROPOSTAVA.Value = WORK_AREA.AC_I_PROPOSTAVA + 1;

        }

        [StopWatch]
        /*" R5635-00-UPDATE-PROPOSTAVA-DB-UPDATE-1 */
        public void R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -6503- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE , OCOREND = :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, COD_FONTE = :WHOST-FONTE , PROFISSAO = :WHOST-PROFISSAO , SIT_REGISTRO = :WHOST-SIT-REGISTRO , DTPROXVEN = :WHOST-DTPROXVEN , IDADE = :WHOST-IDADE , NOME_ESPOSA = :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE , DTNASC_ESPOSA = :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE , PROFIS_ESPOSA = :WHOST-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE , INFO_COMPLEMENTAR = :WHOST-INFO-COMPL , COD_CCT = :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE :VIND-CGC-CONVENENTE , NUM_CONTR_VINCULO = :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , COD_CORRESP_BANC = :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , COD_ORIGEM_PROPOSTA = :PROPOFID-ORIGEM-PROPOSTA , NUM_PRAZO_FIN = :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , COD_OPER_CREDITO = :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED, DTA_DECLINIO = :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-DECLINIO WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 = new R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DATA_NASC_CONJUGE = VIND_DATA_NASC_CONJUGE.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                VIND_CGC_CONVENENTE = VIND_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                VIND_NOME_CONJUGE = VIND_NOME_CONJUGE.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                VIND_DATA_DECLINIO = VIND_DATA_DECLINIO.ToString(),
                WHOST_PROFISSAO_CONJUGE = WHOST_PROFISSAO_CONJUGE.ToString(),
                VIND_PROFISSAO_CONJUGE = VIND_PROFISSAO_CONJUGE.ToString(),
                PROPSSVD_COD_OPER_CREDITO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.ToString(),
                VIND_COD_OPER_CRED = VIND_COD_OPER_CRED.ToString(),
                PROPSSVD_COD_CORRESP_BANC = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.ToString(),
                VIND_COD_CORRESP = VIND_COD_CORRESP.ToString(),
                PROPSSVD_NUM_CONTR_VINCULO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.ToString(),
                VIND_NUM_CONTR = VIND_NUM_CONTR.ToString(),
                PROPSSVD_NUM_PRAZO_FIN = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.ToString(),
                VIND_NUM_PRAZO = VIND_NUM_PRAZO.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                WHOST_SIT_REGISTRO = WHOST_SIT_REGISTRO.ToString(),
                WHOST_INFO_COMPL = WHOST_INFO_COMPL.ToString(),
                WHOST_PROFISSAO = WHOST_PROFISSAO.ToString(),
                WHOST_DTPROXVEN = WHOST_DTPROXVEN.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5635_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-SECTION */
        private void R6000_00_DECLARE_AGENCEF_SECTION()
        {
            /*" -6520- MOVE 'R6000-DECLA-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6000-DECLA-AGENCEF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6524- MOVE 'DECLARE AGENCIACEF   ' TO COMANDO. */
            _.Move("DECLARE AGENCIACEF   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6533- PERFORM R6000_00_DECLARE_AGENCEF_DB_DECLARE_1 */

            R6000_00_DECLARE_AGENCEF_DB_DECLARE_1();

            /*" -6536- MOVE 70 TO SII */
            _.Move(70, WS_HORAS.SII);

            /*" -6537- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6537- PERFORM R6000_00_DECLARE_AGENCEF_DB_OPEN_1 */

            R6000_00_DECLARE_AGENCEF_DB_OPEN_1();

            /*" -6540- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6541- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6542- DISPLAY 'R6000 - PROBLEMAS DECLARE (AGENCEF) ..' */
                _.Display($"R6000 - PROBLEMAS DECLARE (AGENCEF) ..");

                /*" -6543- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -6543- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-OPEN-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_OPEN_1()
        {
            /*" -6537- EXEC SQL OPEN C01_AGENCEF END-EXEC. */

            C01_AGENCEF.Open();

        }

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R6100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -6612- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO ORDER BY COD_CBO END-EXEC. */
            CCBO = new VA2601B_CCBO(false);
            string GetQuery_CCBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							ORDER BY COD_CBO";

                return query;
            }
            CCBO.GetQueryEvent += GetQuery_CCBO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-SECTION */
        private void R6010_00_FETCH_AGENCEF_SECTION()
        {
            /*" -6553- MOVE 'R6010-FETCH-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6010-FETCH-AGENCEF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6557- MOVE 'FETCH   AGENCIACEF   ' TO COMANDO. */
            _.Move("FETCH   AGENCIACEF   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6558- MOVE 71 TO SII */
            _.Move(71, WS_HORAS.SII);

            /*" -6559- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6562- PERFORM R6010_00_FETCH_AGENCEF_DB_FETCH_1 */

            R6010_00_FETCH_AGENCEF_DB_FETCH_1();

            /*" -6565- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6566- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6567- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6568- MOVE 'S' TO WFIM-AGENCEF */
                    _.Move("S", WORK_AREA.WFIM_AGENCEF);

                    /*" -6568- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_1 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_1();

                    /*" -6570- ELSE */
                }
                else
                {


                    /*" -6570- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_2 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_2();

                    /*" -6572- DISPLAY '3100 - (PROBLEMAS NO FETCH AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH AGENCEF) ..");

                    /*" -6573- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -6573- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-FETCH-1 */
        public void R6010_00_FETCH_AGENCEF_DB_FETCH_1()
        {
            /*" -6562- EXEC SQL FETCH C01_AGENCEF INTO :DCLAGENCIAS-CEF.COD-AGENCIA, :DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC. */

            if (C01_AGENCEF.Fetch())
            {
                _.Move(C01_AGENCEF.DCLAGENCIAS_CEF_COD_AGENCIA, AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA);
                _.Move(C01_AGENCEF.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-1 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_1()
        {
            /*" -6568- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-2 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_2()
        {
            /*" -6570- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }

        [StopWatch]
        /*" R6020-00-CARREGA-FILIAL-SECTION */
        private void R6020_00_CARREGA_FILIAL_SECTION()
        {
            /*" -6583- MOVE 'R6020-CARREGA-FILIAL    ' TO PARAGRAFO. */
            _.Move("R6020-CARREGA-FILIAL    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6587- MOVE 'CARREGA FILIAL         ' TO COMANDO. */
            _.Move("CARREGA FILIAL         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6589- IF COD-AGENCIA OF DCLAGENCIAS-CEF > 0 AND COD-AGENCIA OF DCLAGENCIAS-CEF < 10000 */

            if (AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA > 0 && AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA < 10000)
            {

                /*" -6591- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (COD-AGENCIA OF DCLAGENCIAS-CEF) */
                _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAIS.TAB_FILIAL.FILLER_26[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_FONTE);

                /*" -6593- END-IF. */
            }


            /*" -6593- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-SECTION */
        private void R6100_00_DECLARE_CBO_SECTION()
        {
            /*" -6603- MOVE 'R6100-DECLA-CBO         ' TO PARAGRAFO. */
            _.Move("R6100-DECLA-CBO         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6607- MOVE 'DECLARE CBO            ' TO COMANDO. */
            _.Move("DECLARE CBO            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6612- PERFORM R6100_00_DECLARE_CBO_DB_DECLARE_1 */

            R6100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -6615- MOVE 72 TO SII */
            _.Move(72, WS_HORAS.SII);

            /*" -6616- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6616- PERFORM R6100_00_DECLARE_CBO_DB_OPEN_1 */

            R6100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -6619- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6620- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6621- DISPLAY 'R6100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R6100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -6622- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -6622- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R6100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -6616- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R6200_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -6690- EXEC SQL DECLARE CFONTES CURSOR FOR SELECT COD_FONTE, ULT_PROP_AUTOMAT FROM SEGUROS.FONTES ORDER BY COD_FONTE END-EXEC. */
            CFONTES = new VA2601B_CFONTES(false);
            string GetQuery_CFONTES()
            {
                var query = @$"SELECT COD_FONTE
							, 
							ULT_PROP_AUTOMAT 
							FROM SEGUROS.FONTES 
							ORDER BY COD_FONTE";

                return query;
            }
            CFONTES.GetQueryEvent += GetQuery_CFONTES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-FETCH-CBO-SECTION */
        private void R6110_00_FETCH_CBO_SECTION()
        {
            /*" -6632- MOVE 'R6110-FETCH-CBO         ' TO PARAGRAFO. */
            _.Move("R6110-FETCH-CBO         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6636- MOVE 'FETCH   CBO            ' TO COMANDO. */
            _.Move("FETCH   CBO            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6637- MOVE 73 TO SII */
            _.Move(73, WS_HORAS.SII);

            /*" -6638- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6641- PERFORM R6110_00_FETCH_CBO_DB_FETCH_1 */

            R6110_00_FETCH_CBO_DB_FETCH_1();

            /*" -6644- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6645- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6646- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6647- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", WORK_AREA.WFIM_CBO);

                    /*" -6647- PERFORM R6110_00_FETCH_CBO_DB_CLOSE_1 */

                    R6110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -6649- ELSE */
                }
                else
                {


                    /*" -6649- PERFORM R6110_00_FETCH_CBO_DB_CLOSE_2 */

                    R6110_00_FETCH_CBO_DB_CLOSE_2();

                    /*" -6651- DISPLAY '6110 - (PROBLEMAS NO FETCH CCBO     ) ..' */
                    _.Display($"6110 - (PROBLEMAS NO FETCH CCBO     ) ..");

                    /*" -6652- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -6652- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-FETCH-1 */
        public void R6110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -6641- EXEC SQL FETCH CCBO INTO :DCLCBO.CBO-COD-CBO, :DCLCBO.CBO-DESCR-CBO END-EXEC. */

            if (CCBO.Fetch())
            {
                _.Move(CCBO.DCLCBO_CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(CCBO.DCLCBO_CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-CLOSE-1 */
        public void R6110_00_FETCH_CBO_DB_CLOSE_1()
        {
            /*" -6647- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6110_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-CLOSE-2 */
        public void R6110_00_FETCH_CBO_DB_CLOSE_2()
        {
            /*" -6649- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }

        [StopWatch]
        /*" R6120-00-CARREGA-CBO-SECTION */
        private void R6120_00_CARREGA_CBO_SECTION()
        {
            /*" -6662- MOVE 'R6120-CARREGA-CBO       ' TO PARAGRAFO. */
            _.Move("R6120-CARREGA-CBO       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6666- MOVE 'CARREGA CBO            ' TO COMANDO. */
            _.Move("CARREGA CBO            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6668- IF CBO-COD-CBO OF DCLCBO > 0 AND CBO-COD-CBO OF DCLCBO < 1000 */

            if (CBO.DCLCBO.CBO_COD_CBO > 0 && CBO.DCLCBO.CBO_COD_CBO < 1000)
            {

                /*" -6670- MOVE CBO-DESCR-CBO OF DCLCBO TO TAB-DESCR-CBO-C (CBO-COD-CBO OF DCLCBO) */
                _.Move(CBO.DCLCBO.CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_27[CBO.DCLCBO.CBO_COD_CBO].TAB_DESCR_CBO_C);

                /*" -6672- END-IF. */
            }


            /*" -6672- PERFORM R6110-00-FETCH-CBO. */

            R6110_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6120_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-SECTION */
        private void R6200_00_DECLARE_FONTES_SECTION()
        {
            /*" -6682- MOVE 'R6200-DECLA-FONTES      ' TO PARAGRAFO. */
            _.Move("R6200-DECLA-FONTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6685- MOVE 'DECLARE FONTES         ' TO COMANDO. */
            _.Move("DECLARE FONTES         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6690- PERFORM R6200_00_DECLARE_FONTES_DB_DECLARE_1 */

            R6200_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -6693- MOVE 74 TO SII */
            _.Move(74, WS_HORAS.SII);

            /*" -6694- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6694- PERFORM R6200_00_DECLARE_FONTES_DB_OPEN_1 */

            R6200_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -6697- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6698- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6699- DISPLAY 'R6200 - PROBLEMAS DECLARE (FONTES   ) ..' */
                _.Display($"R6200 - PROBLEMAS DECLARE (FONTES   ) ..");

                /*" -6700- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -6700- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R6200_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -6694- EXEC SQL OPEN CFONTES END-EXEC. */

            CFONTES.Open();

        }

        [StopWatch]
        /*" R7900-00-DECLARE-VGRAMOCOMP-DB-DECLARE-1 */
        public void R7900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1()
        {
            /*" -6804- EXEC SQL DECLARE CVGRAMOCOMP CURSOR FOR SELECT DISTINCT B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_GRUPO_SUSEP , B.RAMO_EMISSOR , B.COD_MODALIDADE , B.DTH_INI_VIGENCIA , B.COD_OPCAO_COBERTURA , B.NUM_IDADE_INICIAL , B.NUM_IDADE_FINAL , B.VLR_PERC_PREMIO , B.COD_USUARIO , B.DTH_ATUALIZACAO FROM SEGUROS.VG_PARAM_RAMO_CONJ A, SEGUROS.VG_PARAM_RAMO_COMP B WHERE A.NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND A.COD_SUBGRUPO = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND A.DTH_INI_VIGENCIA <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA AND A.DTH_TER_VIGENCIA >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.RAMO_EMISSOR = A.RAMO_EMISSOR AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA AND B.NUM_IDADE_INICIAL <= :WHOST-IDADE AND B.NUM_IDADE_FINAL >= :WHOST-IDADE AND B.COD_OPCAO_COBERTURA = :WHOST-OPCAO-COBER ORDER BY B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_GRUPO_SUSEP , B.RAMO_EMISSOR , B.COD_MODALIDADE , B.DTH_INI_VIGENCIA , B.COD_OPCAO_COBERTURA , B.NUM_IDADE_INICIAL , B.NUM_IDADE_FINAL , B.VLR_PERC_PREMIO , B.COD_USUARIO , B.DTH_ATUALIZACAO END-EXEC */
            CVGRAMOCOMP = new VA2601B_CVGRAMOCOMP(true);
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
							WHERE A.NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND A.COD_SUBGRUPO = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}' 
							AND A.DTH_INI_VIGENCIA <= 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA}' 
							AND A.DTH_TER_VIGENCIA >= 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA}' 
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-SECTION */
        private void R6210_00_FETCH_FONTES_SECTION()
        {
            /*" -6710- MOVE 'R6210-FETCH-FONTES      ' TO PARAGRAFO. */
            _.Move("R6210-FETCH-FONTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6713- MOVE 'FETCH   FONTES         ' TO COMANDO. */
            _.Move("FETCH   FONTES         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6714- MOVE 75 TO SII */
            _.Move(75, WS_HORAS.SII);

            /*" -6715- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6718- PERFORM R6210_00_FETCH_FONTES_DB_FETCH_1 */

            R6210_00_FETCH_FONTES_DB_FETCH_1();

            /*" -6721- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6722- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6723- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6724- MOVE 'S' TO WFIM-FONTES */
                    _.Move("S", WORK_AREA.WFIM_FONTES);

                    /*" -6724- PERFORM R6210_00_FETCH_FONTES_DB_CLOSE_1 */

                    R6210_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -6726- ELSE */
                }
                else
                {


                    /*" -6726- PERFORM R6210_00_FETCH_FONTES_DB_CLOSE_2 */

                    R6210_00_FETCH_FONTES_DB_CLOSE_2();

                    /*" -6728- DISPLAY '6200 - (PROBLEMAS NO FETCH CFONTES  ) ..' */
                    _.Display($"6200 - (PROBLEMAS NO FETCH CFONTES  ) ..");

                    /*" -6729- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -6729- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-FETCH-1 */
        public void R6210_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -6718- EXEC SQL FETCH CFONTES INTO :DCLFONTES.FONTES-COD-FONTE, :DCLFONTES.FONTES-ULT-PROP-AUTOMAT END-EXEC. */

            if (CFONTES.Fetch())
            {
                _.Move(CFONTES.DCLFONTES_FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
                _.Move(CFONTES.DCLFONTES_FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }

        }

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-CLOSE-1 */
        public void R6210_00_FETCH_FONTES_DB_CLOSE_1()
        {
            /*" -6724- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6210_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-CLOSE-2 */
        public void R6210_00_FETCH_FONTES_DB_CLOSE_2()
        {
            /*" -6726- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }

        [StopWatch]
        /*" R7900-00-DECLARE-VGRAMOCOMP-SECTION */
        private void R7900_00_DECLARE_VGRAMOCOMP_SECTION()
        {
            /*" -6738- MOVE '7900-00-DECLARE-CURSOR       ' TO PARAGRAFO. */
            _.Move("7900-00-DECLARE-CURSOR       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6740- MOVE 'NAO' TO WFIM-VGRAMOCOMP */
            _.Move("NAO", WORK_AREA.WFIM_VGRAMOCOMP);

            /*" -6747- IF PROPSSVD-NUM-APOLICE = 109300000559 OR 3009300000559 OR 3009300001559 OR 109300000709 OR 109300001311 OR 109300001392 OR 109300001393 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.In("109300000559", "3009300000559", "3009300001559", "109300000709", "109300001311", "109300001392", "109300001393"))
            {

                /*" -6749- MOVE PROPOFID-OPCAO-COBER TO WHOST-OPCAO-COBER */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER, WHOST_OPCAO_COBER);

                /*" -6750- ELSE */
            }
            else
            {


                /*" -6752- MOVE ' ' TO WHOST-OPCAO-COBER */
                _.Move(" ", WHOST_OPCAO_COBER);

                /*" -6754- END-IF */
            }


            /*" -6755- MOVE 76 TO SII */
            _.Move(76, WS_HORAS.SII);

            /*" -6756- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6804- PERFORM R7900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1 */

            R7900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1();

            /*" -6807- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6807- PERFORM R7900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1 */

            R7900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1();

            /*" -6810- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6811- DISPLAY '7900 - (PROBLEMAS NO DECLARE CVGRAMOCOMP) ..' */
                _.Display($"7900 - (PROBLEMAS NO DECLARE CVGRAMOCOMP) ..");

                /*" -6812- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -6813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7900-00-DECLARE-VGRAMOCOMP-DB-OPEN-1 */
        public void R7900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1()
        {
            /*" -6807- EXEC SQL OPEN CVGRAMOCOMP END-EXEC. */

            CVGRAMOCOMP.Open();

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-DECLARE-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_DECLARE_1()
        {
            /*" -7320- EXEC SQL DECLARE C01_GECLIMOV CURSOR FOR SELECT TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_ENDERECO BETWEEN :WHOST-OCORR-END-I AND :WHOST-OCORR-END-F ORDER BY OCORR_HIST DESC END-EXEC. */
            C01_GECLIMOV = new VA2601B_C01_GECLIMOV(true);
            string GetQuery_C01_GECLIMOV()
            {
                var query = @$"SELECT TIPO_MOVIMENTO
							, 
							DATA_ULT_MANUTEN
							, 
							NOME_RAZAO
							, 
							TIPO_PESSOA
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							CEP
							, 
							DDD
							, 
							TELEFONE
							, 
							FAX
							, 
							OCORR_HIST
							, 
							CGCCPF
							, 
							DATA_NASCIMENTO 
							FROM SEGUROS.GE_CLIENTES_MOVTO 
							WHERE COD_CLIENTE = '{GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}' 
							AND OCORR_ENDERECO BETWEEN '{WHOST_OCORR_END_I}' 
							AND '{WHOST_OCORR_END_F}' 
							ORDER BY OCORR_HIST DESC";

                return query;
            }
            C01_GECLIMOV.GetQueryEvent += GetQuery_C01_GECLIMOV;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7900_99_SAIDA*/

        [StopWatch]
        /*" R7910-00-FETCH-VGRAMOCOMP-SECTION */
        private void R7910_00_FETCH_VGRAMOCOMP_SECTION()
        {
            /*" -6821- MOVE '7910-00-FETCH-CURSOR         ' TO PARAGRAFO. */
            _.Move("7910-00-FETCH-CURSOR         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6822- MOVE 78 TO SII */
            _.Move(78, WS_HORAS.SII);

            /*" -6823- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6837- PERFORM R7910_00_FETCH_VGRAMOCOMP_DB_FETCH_1 */

            R7910_00_FETCH_VGRAMOCOMP_DB_FETCH_1();

            /*" -6840- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6841- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6842- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6843- MOVE 'SIM' TO WFIM-VGRAMOCOMP */
                    _.Move("SIM", WORK_AREA.WFIM_VGRAMOCOMP);

                    /*" -6843- PERFORM R7910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1 */

                    R7910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1();

                    /*" -6845- GO TO R7910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7910_99_SAIDA*/ //GOTO
                    return;

                    /*" -6846- ELSE */
                }
                else
                {


                    /*" -6847- DISPLAY '7910 - (PROBLEMAS NO FETCH CVGRAMOCOMP) ..' */
                    _.Display($"7910 - (PROBLEMAS NO FETCH CVGRAMOCOMP) ..");

                    /*" -6848- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -6849- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R7910-00-FETCH-VGRAMOCOMP-DB-FETCH-1 */
        public void R7910_00_FETCH_VGRAMOCOMP_DB_FETCH_1()
        {
            /*" -6837- EXEC SQL FETCH CVGRAMOCOMP INTO :VG081-NUM-APOLICE , :VG081-COD-SUBGRUPO , :VG081-COD-GRUPO-SUSEP , :VG081-RAMO-EMISSOR , :VG081-COD-MODALIDADE , :VG081-DTH-INI-VIGENCIA , :VG081-COD-OPCAO-COBERTURA , :VG081-NUM-IDADE-INICIAL , :VG081-NUM-IDADE-FINAL , :VG081-VLR-PERC-PREMIO , :VG081-COD-USUARIO , :VG081-DTH-ATUALIZACAO END-EXEC */

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
        /*" R7910-00-FETCH-VGRAMOCOMP-DB-CLOSE-1 */
        public void R7910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1()
        {
            /*" -6843- EXEC SQL CLOSE CVGRAMOCOMP END-EXEC */

            CVGRAMOCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7910_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-PROCESSA-VGRAMOCOMP-SECTION */
        private void R8000_00_PROCESSA_VGRAMOCOMP_SECTION()
        {
            /*" -6857- MOVE '8000-00-PROCESSA-VGRAMOCOMP  ' TO PARAGRAFO. */
            _.Move("8000-00-PROCESSA-VGRAMOCOMP  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6859- MOVE VG081-COD-GRUPO-SUSEP TO WS-GRUPO-SUSEP-ANT */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP, WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT);

            /*" -6862- MOVE VG081-RAMO-EMISSOR TO WS-RAMO-CONJ-ANT */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR, WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT);

            /*" -6865- MOVE ZEROS TO WHOST-TAXA-RAMO WHOST-VLR-PERC-PREMIO */
            _.Move(0, WHOST_TAXA_RAMO, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO);

            /*" -6872- PERFORM R8100-00-PROCESSA-REGISTRO UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT. */

            while (!(WORK_AREA.WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
            {

                R8100_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -6873- ADD 1 TO WS-IND */
            WORK_RAMO_CONJ.WS_IND.Value = WORK_RAMO_CONJ.WS_IND + 1;

            /*" -6875- MOVE WS-GRUPO-SUSEP-ANT TO TB-GRUPO-SUSEP (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_GRUPO_SUSEP);

            /*" -6877- MOVE WS-RAMO-CONJ-ANT TO TB-RAMO-CONJ (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ);

            /*" -6879- MOVE WHOST-VLR-PERC-PREMIO TO TB-TAXA-RAMO-CONJ (WS-IND). */
            _.Move(WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_TAXA_RAMO_CONJ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-PROCESSA-REGISTRO-SECTION */
        private void R8100_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -6890- MOVE '8100-00-PROCESSA-REGISTRO    ' TO PARAGRAFO. */
            _.Move("8100-00-PROCESSA-REGISTRO    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6896- IF (PROPSSVD-NUM-APOLICE = 109300000550 OR 109300000559 OR 3009300000559 OR 3009300001559) AND WS-RAMO-CONJ-ANT = 84 */

            if ((PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.In("109300000550", "109300000559", "3009300000559", "3009300001559")) && WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 84)
            {

                /*" -6897- IF IMPMORNATU OF DCLPLANOS-VA-VGAP > 0 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 0)
                {

                    /*" -6900- DIVIDE IMPSEGCDG OF DCLPLANOS-VA-VGAP BY IMPMORNATU OF DCLPLANOS-VA-VGAP GIVING WHOST-PERC-CDG */
                    _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WHOST_PERC_CDG);

                    /*" -6901- ELSE */
                }
                else
                {


                    /*" -6902- IF IMPMORACID OF DCLPLANOS-VA-VGAP > 0 */

                    if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID > 0)
                    {

                        /*" -6905- DIVIDE IMPSEGCDG OF DCLPLANOS-VA-VGAP BY IMPMORACID OF DCLPLANOS-VA-VGAP GIVING WHOST-PERC-CDG */
                        _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, WHOST_PERC_CDG);

                        /*" -6906- ELSE */
                    }
                    else
                    {


                        /*" -6907- MOVE ZEROS TO WHOST-PERC-CDG */
                        _.Move(0, WHOST_PERC_CDG);

                        /*" -6908- END-IF */
                    }


                    /*" -6909- END-IF */
                }


                /*" -6911- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-CDG */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_CDG;

                /*" -6913- END-IF. */
            }


            /*" -6914- IF WS-RAMO-CONJ-ANT = 82 */

            if (WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 82)
            {

                /*" -6915- IF IMPMORNATU OF DCLPLANOS-VA-VGAP > 0 */

                if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 0)
                {

                    /*" -6918- DIVIDE IMPDIT OF DCLPLANOS-VA-VGAP BY IMPMORNATU OF DCLPLANOS-VA-VGAP GIVING WHOST-PERC-DIT */
                    _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WHOST_PERC_DIT);

                    /*" -6919- ELSE */
                }
                else
                {


                    /*" -6920- IF IMPMORACID OF DCLPLANOS-VA-VGAP > 0 */

                    if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID > 0)
                    {

                        /*" -6923- DIVIDE IMPDIT OF DCLPLANOS-VA-VGAP BY IMPMORACID OF DCLPLANOS-VA-VGAP GIVING WHOST-PERC-DIT */
                        _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, WHOST_PERC_DIT);

                        /*" -6924- ELSE */
                    }
                    else
                    {


                        /*" -6925- MOVE ZEROS TO WHOST-PERC-DIT */
                        _.Move(0, WHOST_PERC_DIT);

                        /*" -6926- END-IF */
                    }


                    /*" -6927- END-IF */
                }


                /*" -6929- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-DIT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_DIT;

                /*" -6931- END-IF */
            }


            /*" -6935- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -6936- PERFORM R7910-00-FETCH-VGRAMOCOMP. */

            R7910_00_FETCH_VGRAMOCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8200-00-INSERT-VGHISTCONT-SECTION */
        private void R8200_00_INSERT_VGHISTCONT_SECTION()
        {
            /*" -6944- MOVE '8200-00-INSERT-VGHISTCONT    ' TO PARAGRAFO. */
            _.Move("8200-00-INSERT-VGHISTCONT    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6946- ADD 1 TO WS-IND1. */
            WORK_RAMO_CONJ.WS_IND1.Value = WORK_RAMO_CONJ.WS_IND1 + 1;

            /*" -6948- IF WS-IND1 GREATER 30 OR TB-GRUPO-SUSEP (WS-IND1) EQUAL ZEROS */

            if (WORK_RAMO_CONJ.WS_IND1 > 30 || WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP == 00)
            {

                /*" -6949- MOVE 'SIM' TO WFIM-TAB-RAMO */
                _.Move("SIM", WORK_AREA.WFIM_TAB_RAMO);

                /*" -6950- ELSE */
            }
            else
            {


                /*" -6951- INITIALIZE DCLVG-HIST-CONT-COBER */
                _.Initialize(
                    VG082.DCLVG_HIST_CONT_COBER
                );

                /*" -6952- MOVE TB-GRUPO-SUSEP (WS-IND1) TO WHOST-GRUPO-SUSEP */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP, WHOST_GRUPO_SUSEP);

                /*" -6953- MOVE TB-RAMO-CONJ (WS-IND1) TO WHOST-COD-RAMO */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ, WHOST_COD_RAMO);

                /*" -6954- MOVE TB-TAXA-RAMO-CONJ (WS-IND1) TO WHOST-TAXA-RAMO */
                _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_TAXA_RAMO_CONJ, WHOST_TAXA_RAMO);

                /*" -6958- COMPUTE WHOST-PREMIO-CONJ ROUNDED = WS-PREMIO-TOTAL * WHOST-TAXA-RAMO / WHOST-VLR-PERC-PREMIO-TOT */
                WHOST_PREMIO_CONJ.Value = WS_PREMIO_TOTAL * WHOST_TAXA_RAMO / WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT;

                /*" -6959- IF WS-IND1 EQUAL WS-IND */

                if (WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND)
                {

                    /*" -6961- COMPUTE WHOST-PREMIO-CONJ = WS-PREMIO-TOTAL - WS-PREMIO-TOTAL-AC */
                    WHOST_PREMIO_CONJ.Value = WS_PREMIO_TOTAL - WS_PREMIO_TOTAL_AC;

                    /*" -6962- ELSE */
                }
                else
                {


                    /*" -6963- ADD WHOST-PREMIO-CONJ TO WS-PREMIO-TOTAL-AC */
                    WS_PREMIO_TOTAL_AC.Value = WS_PREMIO_TOTAL_AC + WHOST_PREMIO_CONJ;

                    /*" -6964- END-IF */
                }


                /*" -6965- IF WHOST-PREMIO-CONJ GREATER ZEROS */

                if (WHOST_PREMIO_CONJ > 00)
                {

                    /*" -6966- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -6991- PERFORM R8200_00_INSERT_VGHISTCONT_DB_INSERT_1 */

                    R8200_00_INSERT_VGHISTCONT_DB_INSERT_1();

                    /*" -6994- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -6996- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

                    if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
                    {

                        /*" -6997- DISPLAY 'PROBLEMAS NO INSERT VGHISTCONT     ' */
                        _.Display($"PROBLEMAS NO INSERT VGHISTCONT     ");

                        /*" -6998- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R8200-00-INSERT-VGHISTCONT-DB-INSERT-1 */
        public void R8200_00_INSERT_VGHISTCONT_DB_INSERT_1()
        {
            /*" -6991- EXEC SQL INSERT INTO SEGUROS.VG_HIST_CONT_COBER (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO ) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO, :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO, :WHOST-GRUPO-SUSEP , :WHOST-COD-RAMO , :VG082-COD-MODALIDADE, :VG082-COD-COBERTURA, :WHOST-PREMIO-CONJ, 'VA2601B' , CURRENT TIMESTAMP ) END-EXEC */

            var r8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 = new R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                WHOST_GRUPO_SUSEP = WHOST_GRUPO_SUSEP.ToString(),
                WHOST_COD_RAMO = WHOST_COD_RAMO.ToString(),
                VG082_COD_MODALIDADE = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_MODALIDADE.ToString(),
                VG082_COD_COBERTURA = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_COBERTURA.ToString(),
                WHOST_PREMIO_CONJ = WHOST_PREMIO_CONJ.ToString(),
            };

            R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1.Execute(r8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-UPDATE-NUM-OUTROS-SECTION */
        private void R9100_00_UPDATE_NUM_OUTROS_SECTION()
        {
            /*" -7027- MOVE '9100-00-UPDATE-NUM-OUTROS    ' TO PARAGRAFO. */
            _.Move("9100-00-UPDATE-NUM-OUTROS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7028- MOVE 79 TO SII */
            _.Move(79, WS_HORAS.SII);

            /*" -7029- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7033- PERFORM R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1 */

            R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1();

            /*" -7036- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7037- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7038- DISPLAY 'PROBLEMAS NO UPDATE DA NUMERO OUTROS' */
                _.Display($"PROBLEMAS NO UPDATE DA NUMERO OUTROS");

                /*" -7038- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9100-00-UPDATE-NUM-OUTROS-DB-UPDATE-1 */
        public void R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1()
        {
            /*" -7033- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CLIENTE = :DCLNUMERO-OUTROS.NUM-CLIENTE WHERE 1 = 1 END-EXEC. */

            var r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1 = new R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1()
            {
                NUM_CLIENTE = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.ToString(),
            };

            R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1.Execute(r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9300-00-TRATA-MOVTO-CLIENTE-SECTION */
        private void R9300_00_TRATA_MOVTO_CLIENTE_SECTION()
        {
            /*" -7091- MOVE 'R9300-00-TRATA-MOVTO-CLIENTE' TO PARAGRAFO */
            _.Move("R9300-00-TRATA-MOVTO-CLIENTE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7093- MOVE COD-CLIENTE OF DCLCLIENTES TO WWORK-COD-CLIENTE */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, W_GECLIMOV.WWORK_COD_CLIENTE);

            /*" -7095- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO WWORK-DATA-ULT-MANUTEN */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_GECLIMOV.WWORK_DATA_ULT_MANUTEN);

            /*" -7097- MOVE PESSOA-NOME-PESSOA OF DCLPESSOA TO WWORK-NOME-RAZAO */
            _.Move(PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA, W_GECLIMOV.WWORK_NOME_RAZAO);

            /*" -7098- MOVE 'F' TO WWORK-TIPO-PESSOA */
            _.Move("F", W_GECLIMOV.WWORK_TIPO_PESSOA);

            /*" -7099- MOVE SPACES TO WWORK-IDE-SEXO */
            _.Move("", W_GECLIMOV.WWORK_IDE_SEXO);

            /*" -7101- MOVE SPACES TO WWORK-ESTADO-CIVIL */
            _.Move("", W_GECLIMOV.WWORK_ESTADO_CIVIL);

            /*" -7104- MOVE ENDERECO-OCORR-ENDERECO OF DCLENDERECOS TO WWORK-OCORR-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO, W_GECLIMOV.WWORK_OCORR_ENDERECO);

            /*" -7106- MOVE ENDERECO OF DCLPESSOA-ENDERECO TO WWORK-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.ENDERECO, W_GECLIMOV.WWORK_ENDERECO);

            /*" -7108- MOVE BAIRRO OF DCLPESSOA-ENDERECO TO WWORK-BAIRRO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.BAIRRO, W_GECLIMOV.WWORK_BAIRRO);

            /*" -7110- MOVE CIDADE OF DCLPESSOA-ENDERECO TO WWORK-CIDADE */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CIDADE, W_GECLIMOV.WWORK_CIDADE);

            /*" -7112- MOVE SIGLA-UF OF DCLPESSOA-ENDERECO TO WWORK-SIGLA-UF */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF, W_GECLIMOV.WWORK_SIGLA_UF);

            /*" -7114- MOVE CEP OF DCLPESSOA-ENDERECO TO WWORK-CEP */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CEP, W_GECLIMOV.WWORK_CEP);

            /*" -7115- MOVE WHOST-DDD TO WWORK-DDD */
            _.Move(WHOST_DDD, W_GECLIMOV.WWORK_DDD);

            /*" -7116- MOVE WHOST-FONE TO WWORK-TELEFONE */
            _.Move(WHOST_FONE, W_GECLIMOV.WWORK_TELEFONE);

            /*" -7117- MOVE WHOST-FAX TO WWORK-FAX */
            _.Move(WHOST_FAX, W_GECLIMOV.WWORK_FAX);

            /*" -7118- MOVE CPF OF DCLPESSOA-FISICA TO WWORK-CGCCPF */
            _.Move(PESFIS.DCLPESSOA_FISICA.CPF, W_GECLIMOV.WWORK_CGCCPF);

            /*" -7121- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WWORK-DATA-NASCIMENTO */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, W_GECLIMOV.WWORK_DATA_NASCIMENTO);

            /*" -7122- MOVE WWORK-COD-CLIENTE TO GECLIMOV-COD-CLIENTE */
            _.Move(W_GECLIMOV.WWORK_COD_CLIENTE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE);

            /*" -7123- MOVE WWORK-OCORR-ENDERECO TO GECLIMOV-OCORR-ENDERECO */
            _.Move(W_GECLIMOV.WWORK_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);

            /*" -7125- MOVE WWORK-TIPO-MOVIMENTO TO GECLIMOV-TIPO-MOVIMENTO */
            _.Move(W_GECLIMOV.WWORK_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);

            /*" -7130- MOVE WWORK-DATA-ULT-MANUTEN TO GECLIMOV-DATA-ULT-MANUTEN */
            _.Move(W_GECLIMOV.WWORK_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);

            /*" -7131- PERFORM R9310-00-MAX-GECLIMOV */

            R9310_00_MAX_GECLIMOV_SECTION();

            /*" -7133- ADD 1 TO GECLIMOV-OCORR-HIST */
            GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.Value = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST + 1;

            /*" -7134- IF GECLIMOV-OCORR-ENDERECO EQUAL ZEROS */

            if (GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO == 00)
            {

                /*" -7135- MOVE 0 TO WHOST-OCORR-END-I */
                _.Move(0, WHOST_OCORR_END_I);

                /*" -7136- MOVE 9999 TO WHOST-OCORR-END-F */
                _.Move(9999, WHOST_OCORR_END_F);

                /*" -7137- ELSE */
            }
            else
            {


                /*" -7140- MOVE GECLIMOV-OCORR-ENDERECO TO WHOST-OCORR-END-I WHOST-OCORR-END-F. */
                _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO, WHOST_OCORR_END_I, WHOST_OCORR_END_F);
            }


            /*" -7142- PERFORM R9320-00-SELECT-GECLIMOV */

            R9320_00_SELECT_GECLIMOV_SECTION();

            /*" -7143- IF WWORK-NOME-RAZAO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_NOME_RAZAO.IsEmpty())
            {

                /*" -7144- MOVE -1 TO VIND-NOME-RAZAO */
                _.Move(-1, VIND_NOME_RAZAO);

                /*" -7145- ELSE */
            }
            else
            {


                /*" -7146- MOVE +0 TO VIND-NOME-RAZAO */
                _.Move(+0, VIND_NOME_RAZAO);

                /*" -7148- MOVE WWORK-NOME-RAZAO TO GECLIMOV-NOME-RAZAO. */
                _.Move(W_GECLIMOV.WWORK_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
            }


            /*" -7149- IF WWORK-TIPO-PESSOA EQUAL SPACES */

            if (W_GECLIMOV.WWORK_TIPO_PESSOA.IsEmpty())
            {

                /*" -7150- MOVE -1 TO VIND-TIPO-PESSOA */
                _.Move(-1, VIND_TIPO_PESSOA);

                /*" -7151- ELSE */
            }
            else
            {


                /*" -7152- MOVE +0 TO VIND-TIPO-PESSOA */
                _.Move(+0, VIND_TIPO_PESSOA);

                /*" -7154- MOVE WWORK-TIPO-PESSOA TO GECLIMOV-TIPO-PESSOA. */
                _.Move(W_GECLIMOV.WWORK_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
            }


            /*" -7155- IF WWORK-IDE-SEXO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_IDE_SEXO.IsEmpty())
            {

                /*" -7156- MOVE -1 TO VIND-IDE-SEXO */
                _.Move(-1, VIND_IDE_SEXO);

                /*" -7157- ELSE */
            }
            else
            {


                /*" -7158- MOVE +0 TO VIND-IDE-SEXO */
                _.Move(+0, VIND_IDE_SEXO);

                /*" -7160- MOVE WWORK-IDE-SEXO TO GECLIMOV-IDE-SEXO. */
                _.Move(W_GECLIMOV.WWORK_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
            }


            /*" -7161- IF WWORK-ESTADO-CIVIL EQUAL SPACES */

            if (W_GECLIMOV.WWORK_ESTADO_CIVIL.IsEmpty())
            {

                /*" -7162- MOVE -1 TO VIND-EST-CIVIL */
                _.Move(-1, VIND_EST_CIVIL);

                /*" -7163- ELSE */
            }
            else
            {


                /*" -7164- MOVE +0 TO VIND-EST-CIVIL */
                _.Move(+0, VIND_EST_CIVIL);

                /*" -7166- MOVE WWORK-ESTADO-CIVIL TO GECLIMOV-ESTADO-CIVIL. */
                _.Move(W_GECLIMOV.WWORK_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
            }


            /*" -7167- IF WWORK-OCORR-ENDERECO EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_OCORR_ENDERECO == 00)
            {

                /*" -7168- MOVE -1 TO VIND-OCORR-END */
                _.Move(-1, VIND_OCORR_END);

                /*" -7169- ELSE */
            }
            else
            {


                /*" -7171- MOVE +0 TO VIND-OCORR-END. */
                _.Move(+0, VIND_OCORR_END);
            }


            /*" -7172- IF WWORK-ENDERECO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_ENDERECO.IsEmpty())
            {

                /*" -7173- MOVE -1 TO VIND-ENDERECO */
                _.Move(-1, VIND_ENDERECO);

                /*" -7174- ELSE */
            }
            else
            {


                /*" -7175- MOVE +0 TO VIND-ENDERECO */
                _.Move(+0, VIND_ENDERECO);

                /*" -7177- MOVE WWORK-ENDERECO TO GECLIMOV-ENDERECO. */
                _.Move(W_GECLIMOV.WWORK_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
            }


            /*" -7178- IF WWORK-BAIRRO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_BAIRRO.IsEmpty())
            {

                /*" -7179- MOVE -1 TO VIND-BAIRRO */
                _.Move(-1, VIND_BAIRRO);

                /*" -7180- ELSE */
            }
            else
            {


                /*" -7181- MOVE +0 TO VIND-BAIRRO */
                _.Move(+0, VIND_BAIRRO);

                /*" -7183- MOVE WWORK-BAIRRO TO GECLIMOV-BAIRRO. */
                _.Move(W_GECLIMOV.WWORK_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
            }


            /*" -7184- IF WWORK-CIDADE EQUAL SPACES */

            if (W_GECLIMOV.WWORK_CIDADE.IsEmpty())
            {

                /*" -7185- MOVE -1 TO VIND-CIDADE */
                _.Move(-1, VIND_CIDADE);

                /*" -7186- ELSE */
            }
            else
            {


                /*" -7187- MOVE +0 TO VIND-CIDADE */
                _.Move(+0, VIND_CIDADE);

                /*" -7189- MOVE WWORK-CIDADE TO GECLIMOV-CIDADE. */
                _.Move(W_GECLIMOV.WWORK_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
            }


            /*" -7190- IF WWORK-SIGLA-UF EQUAL SPACES */

            if (W_GECLIMOV.WWORK_SIGLA_UF.IsEmpty())
            {

                /*" -7191- MOVE -1 TO VIND-SIGLA-UF */
                _.Move(-1, VIND_SIGLA_UF);

                /*" -7192- ELSE */
            }
            else
            {


                /*" -7193- MOVE +0 TO VIND-SIGLA-UF */
                _.Move(+0, VIND_SIGLA_UF);

                /*" -7195- MOVE WWORK-SIGLA-UF TO GECLIMOV-SIGLA-UF. */
                _.Move(W_GECLIMOV.WWORK_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
            }


            /*" -7196- IF WWORK-CEP EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_CEP == 00)
            {

                /*" -7197- MOVE -1 TO VIND-CEP */
                _.Move(-1, VIND_CEP);

                /*" -7198- ELSE */
            }
            else
            {


                /*" -7199- MOVE +0 TO VIND-CEP */
                _.Move(+0, VIND_CEP);

                /*" -7201- MOVE WWORK-CEP TO GECLIMOV-CEP. */
                _.Move(W_GECLIMOV.WWORK_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
            }


            /*" -7202- IF WWORK-DDD EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_DDD == 00)
            {

                /*" -7203- MOVE -1 TO VIND-DDD */
                _.Move(-1, VIND_DDD);

                /*" -7204- ELSE */
            }
            else
            {


                /*" -7205- MOVE +0 TO VIND-DDD */
                _.Move(+0, VIND_DDD);

                /*" -7207- MOVE WWORK-DDD TO GECLIMOV-DDD. */
                _.Move(W_GECLIMOV.WWORK_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
            }


            /*" -7208- IF WWORK-TELEFONE EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_TELEFONE == 00)
            {

                /*" -7209- MOVE -1 TO VIND-TELEFONE */
                _.Move(-1, VIND_TELEFONE);

                /*" -7210- ELSE */
            }
            else
            {


                /*" -7211- MOVE +0 TO VIND-TELEFONE */
                _.Move(+0, VIND_TELEFONE);

                /*" -7213- MOVE WWORK-TELEFONE TO GECLIMOV-TELEFONE. */
                _.Move(W_GECLIMOV.WWORK_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
            }


            /*" -7214- IF WWORK-FAX EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_FAX == 00)
            {

                /*" -7215- MOVE -1 TO VIND-FAX */
                _.Move(-1, VIND_FAX);

                /*" -7216- ELSE */
            }
            else
            {


                /*" -7217- MOVE +0 TO VIND-FAX */
                _.Move(+0, VIND_FAX);

                /*" -7219- MOVE WWORK-FAX TO GECLIMOV-FAX. */
                _.Move(W_GECLIMOV.WWORK_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
            }


            /*" -7220- IF WWORK-CGCCPF EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_CGCCPF == 00)
            {

                /*" -7221- MOVE -1 TO VIND-CGCCPF */
                _.Move(-1, VIND_CGCCPF);

                /*" -7222- ELSE */
            }
            else
            {


                /*" -7223- MOVE +0 TO VIND-CGCCPF */
                _.Move(+0, VIND_CGCCPF);

                /*" -7225- MOVE WWORK-CGCCPF TO GECLIMOV-CGCCPF. */
                _.Move(W_GECLIMOV.WWORK_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
            }


            /*" -7226- IF WWORK-DATA-NASCIMENTO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_DATA_NASCIMENTO.IsEmpty())
            {

                /*" -7227- MOVE -1 TO VIND-DTNASC */
                _.Move(-1, VIND_DTNASC);

                /*" -7228- ELSE */
            }
            else
            {


                /*" -7229- MOVE +0 TO VIND-DTNASC */
                _.Move(+0, VIND_DTNASC);

                /*" -7231- MOVE WWORK-DATA-NASCIMENTO TO GECLIMOV-DATA-NASCIMENTO. */
                _.Move(W_GECLIMOV.WWORK_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
            }


            /*" -7233- MOVE 'VA2601B' TO GECLIMOV-COD-USUARIO */
            _.Move("VA2601B", GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO);

            /*" -7234- IF WTEM-GECLIMOV EQUAL 'N' */

            if (WTEM_GECLIMOV == "N")
            {

                /*" -7250- IF VIND-NOME-RAZAO LESS ZEROS AND VIND-TIPO-PESSOA LESS ZEROS AND VIND-IDE-SEXO LESS ZEROS AND VIND-EST-CIVIL LESS ZEROS AND VIND-OCORR-END LESS ZEROS AND VIND-ENDERECO LESS ZEROS AND VIND-BAIRRO LESS ZEROS AND VIND-CIDADE LESS ZEROS AND VIND-SIGLA-UF LESS ZEROS AND VIND-CEP LESS ZEROS AND VIND-DDD LESS ZEROS AND VIND-TELEFONE LESS ZEROS AND VIND-FAX LESS ZEROS AND VIND-CGCCPF LESS ZEROS AND VIND-DTNASC LESS ZEROS NEXT SENTENCE */

                if (VIND_NOME_RAZAO < 00 && VIND_TIPO_PESSOA < 00 && VIND_IDE_SEXO < 00 && VIND_EST_CIVIL < 00 && VIND_OCORR_END < 00 && VIND_ENDERECO < 00 && VIND_BAIRRO < 00 && VIND_CIDADE < 00 && VIND_SIGLA_UF < 00 && VIND_CEP < 00 && VIND_DDD < 00 && VIND_TELEFONE < 00 && VIND_FAX < 00 && VIND_CGCCPF < 00 && VIND_DTNASC < 00)
                {

                    /*" -7251- ELSE */
                }
                else
                {


                    /*" -7252- PERFORM R9400-00-INSERT-GECLIMOV */

                    R9400_00_INSERT_GECLIMOV_SECTION();

                    /*" -7253- ELSE */
                }

            }
            else
            {


                /*" -7253- PERFORM R9450-00-UPDATE-GECLIMOV. */

                R9450_00_UPDATE_GECLIMOV_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9300_99_SAIDA*/

        [StopWatch]
        /*" R9310-00-MAX-GECLIMOV-SECTION */
        private void R9310_00_MAX_GECLIMOV_SECTION()
        {
            /*" -7268- MOVE 'R9310-00-MAX-GECLIMOV' TO PARAGRAFO */
            _.Move("R9310-00-MAX-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7269- MOVE 81 TO SII */
            _.Move(81, WS_HORAS.SII);

            /*" -7270- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7275- PERFORM R9310_00_MAX_GECLIMOV_DB_SELECT_1 */

            R9310_00_MAX_GECLIMOV_DB_SELECT_1();

            /*" -7278- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7279- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7280- DISPLAY 'PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ' */
                _.Display($"PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ");

                /*" -7281- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -7281- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9310-00-MAX-GECLIMOV-DB-SELECT-1 */
        public void R9310_00_MAX_GECLIMOV_DB_SELECT_1()
        {
            /*" -7275- EXEC SQL SELECT VALUE(MAX(OCORR_HIST), 0) INTO :GECLIMOV-OCORR-HIST FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE END-EXEC. */

            var r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 = new R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
            };

            var executed_1 = R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1.Execute(r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9310_99_SAIDA*/

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-SECTION */
        private void R9320_00_SELECT_GECLIMOV_SECTION()
        {
            /*" -7296- MOVE 'R9320-00-SELECT-GECLIMOV' TO PARAGRAFO */
            _.Move("R9320-00-SELECT-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7320- PERFORM R9320_00_SELECT_GECLIMOV_DB_DECLARE_1 */

            R9320_00_SELECT_GECLIMOV_DB_DECLARE_1();

            /*" -7323- MOVE 82 TO SII */
            _.Move(82, WS_HORAS.SII);

            /*" -7324- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7324- PERFORM R9320_00_SELECT_GECLIMOV_DB_OPEN_1 */

            R9320_00_SELECT_GECLIMOV_DB_OPEN_1();

            /*" -7327- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7328- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7329- DISPLAY 'PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ");

                /*" -7330- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -7331- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                /*" -7332- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                /*" -7334- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7335- MOVE 83 TO SII */
            _.Move(83, WS_HORAS.SII);

            /*" -7336- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7355- PERFORM R9320_00_SELECT_GECLIMOV_DB_FETCH_1 */

            R9320_00_SELECT_GECLIMOV_DB_FETCH_1();

            /*" -7358- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7359- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7360- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7360- PERFORM R9320_00_SELECT_GECLIMOV_DB_CLOSE_1 */

                    R9320_00_SELECT_GECLIMOV_DB_CLOSE_1();

                    /*" -7362- MOVE 'N' TO WTEM-GECLIMOV */
                    _.Move("N", WTEM_GECLIMOV);

                    /*" -7363- ELSE */
                }
                else
                {


                    /*" -7364- DISPLAY 'PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ' */
                    _.Display($"PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ");

                    /*" -7365- DISPLAY 'CODCLIEN    ' GECLIMOV-COD-CLIENTE */
                    _.Display($"CODCLIEN    {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                    /*" -7366- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                    _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                    /*" -7367- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                    _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                    /*" -7368- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7369- ELSE */
                }

            }
            else
            {


                /*" -7370- MOVE 'S' TO WTEM-GECLIMOV */
                _.Move("S", WTEM_GECLIMOV);

                /*" -7370- PERFORM R9320_00_SELECT_GECLIMOV_DB_CLOSE_2 */

                R9320_00_SELECT_GECLIMOV_DB_CLOSE_2();

            }
        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-OPEN-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_OPEN_1()
        {
            /*" -7324- EXEC SQL OPEN C01_GECLIMOV END-EXEC. */

            C01_GECLIMOV.Open();
        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-FETCH-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_FETCH_1()
        {
            /*" -7355- EXEC SQL FETCH C01_GECLIMOV INTO :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC END-EXEC. */

            if (C01_GECLIMOV.Fetch())
            {
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);
                _.Move(C01_GECLIMOV.GECLIMOV_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
                _.Move(C01_GECLIMOV.VIND_NOME_RAZAO, VIND_NOME_RAZAO);
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.VIND_TIPO_PESSOA, VIND_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.GECLIMOV_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
                _.Move(C01_GECLIMOV.VIND_IDE_SEXO, VIND_IDE_SEXO);
                _.Move(C01_GECLIMOV.GECLIMOV_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
                _.Move(C01_GECLIMOV.VIND_EST_CIVIL, VIND_EST_CIVIL);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_OCORR_END, VIND_OCORR_END);
                _.Move(C01_GECLIMOV.GECLIMOV_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_ENDERECO, VIND_ENDERECO);
                _.Move(C01_GECLIMOV.GECLIMOV_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
                _.Move(C01_GECLIMOV.VIND_BAIRRO, VIND_BAIRRO);
                _.Move(C01_GECLIMOV.GECLIMOV_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
                _.Move(C01_GECLIMOV.VIND_CIDADE, VIND_CIDADE);
                _.Move(C01_GECLIMOV.GECLIMOV_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
                _.Move(C01_GECLIMOV.VIND_SIGLA_UF, VIND_SIGLA_UF);
                _.Move(C01_GECLIMOV.GECLIMOV_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
                _.Move(C01_GECLIMOV.VIND_CEP, VIND_CEP);
                _.Move(C01_GECLIMOV.GECLIMOV_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
                _.Move(C01_GECLIMOV.VIND_DDD, VIND_DDD);
                _.Move(C01_GECLIMOV.GECLIMOV_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
                _.Move(C01_GECLIMOV.VIND_TELEFONE, VIND_TELEFONE);
                _.Move(C01_GECLIMOV.GECLIMOV_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
                _.Move(C01_GECLIMOV.VIND_FAX, VIND_FAX);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
                _.Move(C01_GECLIMOV.GECLIMOV_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
                _.Move(C01_GECLIMOV.VIND_CGCCPF, VIND_CGCCPF);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
                _.Move(C01_GECLIMOV.VIND_DTNASC, VIND_DTNASC);
            }

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-CLOSE-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_CLOSE_1()
        {
            /*" -7360- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9320_99_SAIDA*/

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-CLOSE-2 */
        public void R9320_00_SELECT_GECLIMOV_DB_CLOSE_2()
        {
            /*" -7370- EXEC SQL CLOSE C01_GECLIMOV END-EXEC. */

            C01_GECLIMOV.Close();

        }

        [StopWatch]
        /*" R9400-00-INSERT-GECLIMOV-SECTION */
        private void R9400_00_INSERT_GECLIMOV_SECTION()
        {
            /*" -7382- MOVE 'R9400-00-INSERT-GECLIMOV' TO PARAGRAFO */
            _.Move("R9400-00-INSERT-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7386- MOVE 'INSERT GE_CLIENTES_MOVTO' TO COMANDO */
            _.Move("INSERT GE_CLIENTES_MOVTO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7387- MOVE 84 TO SII */
            _.Move(84, WS_HORAS.SII);

            /*" -7388- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7434- PERFORM R9400_00_INSERT_GECLIMOV_DB_INSERT_1 */

            R9400_00_INSERT_GECLIMOV_DB_INSERT_1();

            /*" -7437- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7439- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -7440- DISPLAY 'PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ");

                /*" -7441- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -7442- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -7443- DISPLAY 'UF       ' GECLIMOV-SIGLA-UF */
                _.Display($"UF       {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF}");

                /*" -7443- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9400-00-INSERT-GECLIMOV-DB-INSERT-1 */
        public void R9400_00_INSERT_GECLIMOV_DB_INSERT_1()
        {
            /*" -7434- EXEC SQL INSERT INTO SEGUROS.GE_CLIENTES_MOVTO (COD_CLIENTE , TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO , COD_USUARIO , TIMESTAMP , DES_COMPLEMENTO) VALUES (:GECLIMOV-COD-CLIENTE , :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC , :GECLIMOV-COD-USUARIO:VIND-CODUSU , CURRENT TIMESTAMP , NULL) END-EXEC. */

            var r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1 = new R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                VIND_CODUSU = VIND_CODUSU.ToString(),
            };

            R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1.Execute(r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9400_99_SAIDA*/

        [StopWatch]
        /*" R9450-00-UPDATE-GECLIMOV-SECTION */
        private void R9450_00_UPDATE_GECLIMOV_SECTION()
        {
            /*" -7458- MOVE 'R9450-00-UPDATE-GECLIMOV' TO PARAGRAFO */
            _.Move("R9450-00-UPDATE-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7459- MOVE 85 TO SII */
            _.Move(85, WS_HORAS.SII);

            /*" -7460- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7484- PERFORM R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1 */

            R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1();

            /*" -7487- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7489- DISPLAY 'PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ... ");

                /*" -7490- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -7491- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -7491- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9450-00-UPDATE-GECLIMOV-DB-UPDATE-1 */
        public void R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1()
        {
            /*" -7484- EXEC SQL UPDATE SEGUROS.GE_CLIENTES_MOVTO SET TIPO_MOVIMENTO = :GECLIMOV-TIPO-MOVIMENTO, DATA_ULT_MANUTEN = :GECLIMOV-DATA-ULT-MANUTEN, NOME_RAZAO = :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO, TIPO_PESSOA = :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA, IDE_SEXO = :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO, ESTADO_CIVIL = :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL, OCORR_ENDERECO = :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END, ENDERECO = :GECLIMOV-ENDERECO:VIND-ENDERECO, BAIRRO = :GECLIMOV-BAIRRO:VIND-BAIRRO, CIDADE = :GECLIMOV-CIDADE:VIND-CIDADE, SIGLA_UF = :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF, CEP = :GECLIMOV-CEP:VIND-CEP , DDD = :GECLIMOV-DDD:VIND-DDD , TELEFONE = :GECLIMOV-TELEFONE:VIND-TELEFONE , FAX = :GECLIMOV-FAX:VIND-FAX , CGCCPF = :GECLIMOV-CGCCPF:VIND-CGCCPF , DATA_NASCIMENTO = :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC, COD_USUARIO = :GECLIMOV-COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_HIST = :GECLIMOV-OCORR-HIST END-EXEC. */

            var r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1 = new R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1()
            {
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
            };

            R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1.Execute(r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9450_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -7500- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -7501- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -7510- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -7511- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -7512- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -7513- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_0[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_0[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -7514- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_0[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_0[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -7523- DISPLAY ' ' . */
            _.Display($" ");

            /*" -7524- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -7529- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -7530- IF SII < 90 */

            if (WS_HORAS.SII < 90)
            {

                /*" -7531- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_0[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -7533- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_0[WS_HORAS.SII]}"
                .Display();

                /*" -7535- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -7536- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -7546- PERFORM R9900-00-MOSTRA-TOTAIS */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -7547- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -7548- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -7549- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -7550- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -7551- DISPLAY WABEND. */
            _.Display(AREA_ABEND.WABEND);

            /*" -7552- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -7554- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -7555- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, AREA_ABEND.WSQLERRO.WSQLERRMC);

            /*" -7557- DISPLAY WSQLERRO */
            _.Display(AREA_ABEND.WSQLERRO);

            /*" -7561- DISPLAY 'PROPOSTA ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Display($"PROPOSTA {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

            /*" -7561- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -7563- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -7567- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -7567- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}