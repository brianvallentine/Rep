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
using Sias.VidaAzul.DB2.VA0340B;

namespace Code
{
    public class VA0340B
    {
        public bool IsCall { get; set; }

        public VA0340B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 17 - DEMANDA 226662 / TAREFA 247709                   *      */
        /*"      *             - ALTERAR QUANTIDADE DE DIAS DE ENVIO DO DEBITO    *      */
        /*"      *               PARA O BANCO DE 6 PARA 7 DIAS                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/06/2020 - HUSNI ALI HUSNI                              *      */
        /*"      *                                           PROCURE POR V.17     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - DEMANDA 234779                                   *      */
        /*"      *             - ORDENAR A LEITURA DAS PARCELAS PARA GERAR O ARQ-A*      */
        /*"      *               ORDENADAMENTE NA TENTATIVA DE EVITAR DEBITOS DE  *      */
        /*"      *               PARCELAS INTERMEDI�RIAS.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/03/2020 - FRANK CARVALHO                               *      */
        /*"      *                                           PROCURE POR V.16     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - DEMANDA 214252                                   *      */
        /*"      *             - NAO USAR A CURRENT DATE, POIS O PROCESSAMENTO    *      */
        /*"      *               ESTA OCORRENDO DE MADRUGADA, POR ISSO, A DATA    *      */
        /*"      *               E UM DIA A MAIS QUE A DATA DE MOVIMENTO.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/12/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                           PROCURE POR V.15     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 -   JAZZ   15182                                  *       */
        /*"      * - INIBE COBRANCAS EFETUADAS PARA AGENCIAS INATIVADAS PELA CEF. *      */
        /*"      *   A PARTIR DE 14/04/2018.                                      *      */
        /*"      *  (7929)                                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/04/2018 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 -   JAZZ   11409                                  *       */
        /*"      * - INIBE COBRANCAS EFETUADAS PARA AGENCIAS INATIVADAS PELA CEF. *      */
        /*"      *   A PARTIR DE 24/02/2018.                                      *      */
        /*"      *  (4559)                                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/02/2018 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 12                                                          */
        /*"      * MOTIVO  : ACERTO DATA VENCIMENTO DA PARCELA                           */
        /*"      *           APOLICE 107700000067/107700000068                           */
        /*"      *           PRODUTO CESTA DE SERVICOS                                   */
        /*"      * CADMUS  : 151597                                                      */
        /*"      * DATA    : 07/11/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.12                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 11                                                          */
        /*"      * MOTIVO  : AVERBACAO PRESTAMISTA PJ PRODUTO 7732/7733                  */
        /*"      *           APOLICE 107700000067/107700000068                           */
        /*"      *           PRODUTO CESTA DE SERVICOS                                   */
        /*"      * CADMUS  : 151597                                                      */
        /*"      * DATA    : 23/08/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.11                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 -   AJUSTES CAMPANHA.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/10/2017 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 -   CADMUS 153256                                  *      */
        /*"      * - INIBE COBRANCAS EFETUADAS PARA AGENCIAS INATIVADAS PELA CEF. *      */
        /*"      *  (3091,7927,3098,3195,4059,2956,2802,3301,3595)                *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2017 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07                                                    *      */
        /*"      *             - CAD 201.102                                      *      */
        /*"      *               AJUSTE NA DATA DE VENCIMENTO.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/06/2011 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06                                                    *      */
        /*"      *             - CAD 29.862                                       *      */
        /*"      *               PASSA A ENCAMINHAR PARA A CONTA EM D+1 AS        *      */
        /*"      *               PROPOSTAS ORIUNDAS DA GITEL PARA O PRODUTO       *      */
        /*"      *               PRESTAMISTA.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/09/2009 - FAST COMPUTER - TERCIO CARVALHO              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05                                                    *      */
        /*"      *             - CAD 14.447                                       *      */
        /*"      *               DESPRESA REGISTROS SEM A COBER_HIST_VIDAZUL      *      */
        /*"      *               CORRESPONDENTE                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/09/2008 - FAST COMPUTER            PROCURE POR V.05    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO 004                                                 *      */
        /*"      *  ALTERADO EM 19/01/2006    FAST COMPUTER  -  TERCIO CARVALHO   *      */
        /*"      *                                                                *      */
        /*"      *    PASSA A NAO GERAR LANCAMENTOS PARA OPCAO DE PAGAMENTO       *      */
        /*"      *    DIFERENTE DE 1 - CONTA CORRENTE E 2 - CONTA POUPANCA        *      */
        /*"      *    NA V0PARCELVA                                               *      */
        /*"      *                                            PROCURE FC0601      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO 003                                                 *      */
        /*"      *  ALTERADO EM 18/03/2004                    MANOEL MESSIAS      *      */
        /*"      *                                                                *      */
        /*"      *    LE A TABELA V0PROPOSTA E SE A SITUACAO FOR 3, 6 OU 8        *      */
        /*"      *    PROCESSA. PARA EVITAR O ENVIO DE COBRANCA AO SEGURADO.      *      */
        /*"      *                                            PROCURE MM0304      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO 002                                                 *      */
        /*"      *  ALTERADO EM 15/08/2000                    TERCIO CARVALHO     *      */
        /*"      *                                                                *      */
        /*"      *    O PROGRAMA VINHA ALTERANDO DTVENCTO DA PARCELVA             *      */
        /*"      *    INDEVIDAMENTE, UMA VEZ QUE O VENCIMENTO QUE DEVE            *      */
        /*"      *    SER ALTERADO E O DA HISTCONTAVA. O VENCIMENTO DA            *      */
        /*"      *    PARCELVA DEVE SER PRESERVADO COMO O VENCIMENTO              *      */
        /*"      *    ORIGINAL.                                                   *      */
        /*"      *                                            PROCURE TL0008      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO 001                                                 *      */
        /*"      *  ALTERADO EM 13/11/1998                    TERCIO CARVALHO     *      */
        /*"      *  PASSA A TRATAR A PROPOSTAVA PARA SEGUROS CANCELADOS           *      */
        /*"      *  DESPREZANDO O LANCAMENTO.                 PROCURE TL9811      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERADO EM 04/03/1999                    MANOEL MESSIAS      *      */
        /*"      *     INCLUIDO NO ARQUIVO DE REMESSA O NUMERO DO CERTIFICADO     *      */
        /*"      *  DO SEGURADO (MF-IDENT-CLI) PARA NOSSO CONTROLE.               *      */
        /*"      *                                            PROCURE MM0399      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  GERA FITA COM LANCAMENTOS DE DEBITO EM CONTA DO SEGURO        *      */
        /*"      *                 CONVENIO 6088 MULTIPREMIADO                    *      */
        /*"      *                                                                *      */
        /*"      *                          ALEXANDRE FONSECA      17/10/97       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(MOVIMENTO_RECORD, _MOVIMENTO); VarBasis.RedefinePassValue(MOVIMENTO_RECORD, _MOVIMENTO, MOVIMENTO_RECORD); return _MOVIMENTO;
            }
        }
        /*"01  MOVIMENTO-RECORD    PIC X(150).*/
        public StringBasis MOVIMENTO_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  SIST-CURRDATE                    PIC X(10).*/
        public StringBasis SIST_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMAXDEB                    PIC X(10).*/
        public StringBasis SIST_DTMAXDEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMINDEB                    PIC X(10).*/
        public StringBasis SIST_DTMINDEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMINDEB1                   PIC X(10).*/
        public StringBasis SIST_DTMINDEB1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMINDEB2                   PIC X(10).*/
        public StringBasis SIST_DTMINDEB2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMINDEB3                   PIC X(10).*/
        public StringBasis SIST_DTMINDEB3 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMINDEB4                   PIC X(10).*/
        public StringBasis SIST_DTMINDEB4 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIST-DTMOVABE                    PIC X(10).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PROP-CODPRODU                  PIC S9(4)     COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  V0PROP-SITUACAO                  PIC X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PARC-SITUACAO                  PIC X(01).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PARC-OPCAOPAG                  PIC X(01).*/
        public StringBasis V0PARC_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PARM-CODCONV                     PIC S9(9)     COMP.*/
        public IntBasis PARM_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PARM-NSA                         PIC S9(4)     COMP.*/
        public IntBasis PARM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PARM-VERSAO                      PIC S9(4)     COMP.*/
        public IntBasis PARM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NRCERTIF                         PIC S9(15)    COMP-3.*/
        public IntBasis NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  NRPARCEL                         PIC S9(4)     COMP.*/
        public IntBasis NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OCORRHISTCTA                     PIC S9(4)     COMP.*/
        public IntBasis OCORRHISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  AGECTADEB                        PIC S9(4)     COMP.*/
        public IntBasis AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPRCTADEB                        PIC S9(4)     COMP.*/
        public IntBasis OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NUMCTADEB                        PIC S9(13)    COMP-3.*/
        public IntBasis NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  DIGCTADEB                        PIC S9(4)     COMP.*/
        public IntBasis DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VLPRMTOT                         PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SITUACAO                         PIC X(1).*/
        public StringBasis SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  DTVENCTO                         PIC X(10).*/
        public StringBasis DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  NSAS                             PIC S9(4)     COMP.*/
        public IntBasis NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NSL                              PIC S9(9)     COMP.*/
        public IntBasis NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-NSL                       PIC S9(9)     COMP.*/
        public IntBasis FITSAS_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-REG                       PIC S9(9)     COMP.*/
        public IntBasis FITSAS_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-VALOR                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FITSAS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SQL-NOT-NULL                     PIC S9(4) COMP VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"), +1);
        /*"01  SQL-MAYBE-NULL                   PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-MAYBE-NULL1                  PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-MAYBE-NULL2                  PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-DTPROXVEN                     PIC X(10).*/
        public StringBasis WS_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-DT-AUX1.*/
        public VA0340B_WS_DT_AUX1 WS_DT_AUX1 { get; set; } = new VA0340B_WS_DT_AUX1();
        public class VA0340B_WS_DT_AUX1 : VarBasis
        {
            /*"    03 WS-DT-AUX1-ANO                PIC 9(04).*/
            public IntBasis WS_DT_AUX1_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03 WS-DT-AUX1-TR1                PIC X(01).*/
            public StringBasis WS_DT_AUX1_TR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 WS-DT-AUX1-MES                PIC 9(02).*/
            public IntBasis WS_DT_AUX1_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03 WS-DT-AUX1-TR2                PIC X(01).*/
            public StringBasis WS_DT_AUX1_TR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03 WS-DT-AUX1-DIA                PIC 9(02).*/
            public IntBasis WS_DT_AUX1_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-DT-AUX2.*/
        }
        public VA0340B_WS_DT_AUX2 WS_DT_AUX2 { get; set; } = new VA0340B_WS_DT_AUX2();
        public class VA0340B_WS_DT_AUX2 : VarBasis
        {
            /*"    03 WS-DT-AUX2-ANO                PIC 9(04).*/
            public IntBasis WS_DT_AUX2_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03 WS-DT-AUX2-MES                PIC 9(02).*/
            public IntBasis WS_DT_AUX2_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03 WS-DT-AUX2-DIA                PIC 9(02).*/
            public IntBasis WS_DT_AUX2_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WORK-AREA.*/
        }
        public VA0340B_WORK_AREA WORK_AREA { get; set; } = new VA0340B_WORK_AREA();
        public class VA0340B_WORK_AREA : VarBasis
        {
            /*"    05 W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA0340B_CANAL _canal { get; set; }
            public _REDEF_VA0340B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA0340B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0340B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA         PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-VENDA-SASSE                    VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR                 VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-ATM                      VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "4"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8"),
							/*" 88 CANAL-VENDA-EXTRA-RED                VALUE 9. */
							new SelectorItemBasis("CANAL_VENDA_EXTRA_RED", "9")
                }
                };

                /*"        07  FILLER                   PIC 9(013).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05 W-CODPRODU                    PIC 9(004).*/

                public _REDEF_VA0340B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05      WS-DTPROXVEN-VP-GITEL    PIC X(010).*/
            public StringBasis WS_DTPROXVEN_VP_GITEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05      WS-CONSIDERA-DATA        PIC X(003).*/
            public StringBasis WS_CONSIDERA_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05      DATA-SQL.*/
            public VA0340B_DATA_SQL DATA_SQL { get; set; } = new VA0340B_DATA_SQL();
            public class VA0340B_DATA_SQL : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    T1                       PIC  X(001).*/
                public StringBasis T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    T2                       PIC  X(001).*/
                public StringBasis T2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      DATA-INVERTIDA           PIC  9(008).*/
            }
            public IntBasis DATA_INVERTIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05      DATA-AAMMDD REDEFINES DATA-INVERTIDA.*/
            private _REDEF_VA0340B_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_VA0340B_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_VA0340B_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_VA0340B_DATA_AAMMDD : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 W04DTSQL.*/

                public _REDEF_VA0340B_DATA_AAMMDD()
                {
                    ANO_0.ValueChanged += OnValueChanged;
                    MES_0.ValueChanged += OnValueChanged;
                    DIA_0.ValueChanged += OnValueChanged;
                }

            }
            public VA0340B_W04DTSQL W04DTSQL { get; set; } = new VA0340B_W04DTSQL();
            public class VA0340B_W04DTSQL : VarBasis
            {
                /*"       10  W04AASQL                  PIC 9(004).*/
                public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  W04T1SQL                  PIC X(001).*/
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  W04MMSQL                  PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  W04T2SQL                  PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  W04DDSQL                  PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 W05DTSQL.*/
            }
            public VA0340B_W05DTSQL W05DTSQL { get; set; } = new VA0340B_W05DTSQL();
            public class VA0340B_W05DTSQL : VarBasis
            {
                /*"       10  W05AASQL                  PIC 9(004).*/
                public IntBasis W05AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  W05T1SQL                  PIC X(001).*/
                public StringBasis W05T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  W05MMSQL                  PIC 9(002).*/
                public IntBasis W05MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  W05T2SQL                  PIC X(001).*/
                public StringBasis W05T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  W05DDSQL                  PIC 9(002).*/
                public IntBasis W05DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 PARM-PROSOMU1.*/
            }
            public VA0340B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA0340B_PARM_PROSOMU1();
            public class VA0340B_PARM_PROSOMU1 : VarBasis
            {
                /*"      10 SU1-DATA1.*/
                public VA0340B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA0340B_SU1_DATA1();
                public class VA0340B_SU1_DATA1 : VarBasis
                {
                    /*"        15 SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"      10 SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      10 SU1-DATA2.*/
                public VA0340B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA0340B_SU1_DATA2();
                public class VA0340B_SU1_DATA2 : VarBasis
                {
                    /*"        15 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    05 WS-QTD-CESTASERV              PIC  9(08) VALUE ZEROS.*/
                }
            }
            public IntBasis WS_QTD_CESTASERV { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 AC-REGISTROS                  PIC  9(009) VALUE 1.*/
            public IntBasis AC_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 1);
            /*"    05 AC-VALOR                      PIC S9(013)V99 VALUE +0.*/
            public DoubleBasis AC_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-AGENCIA-ANT                PIC S9(004) COMP.*/
            public IntBasis WS_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-NSL                        PIC  9(008) VALUE 0.*/
            public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05 WS-EOF                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-DISPLAY-QUANT              PIC  ZZZ.ZZZ.ZZ9.*/
            public IntBasis WS_DISPLAY_QUANT { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 WS-DISPLAY-VALOR              PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WS_DISPLAY_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05 WS-DISPLAY-NSA                PIC  9(05) VALUE ZEROS.*/
            public IntBasis WS_DISPLAY_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 LD-HCONTAVA                   PIC  9(07) VALUE ZEROS.*/
            public IntBasis LD_HCONTAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 DP-OPCAOPAG                   PIC  9(07) VALUE ZEROS.*/
            public IntBasis DP_OPCAOPAG { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 DP-SITUACAO                   PIC  9(07) VALUE ZEROS.*/
            public IntBasis DP_SITUACAO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 NT-PROPOVA                    PIC  9(07) VALUE ZEROS.*/
            public IntBasis NT_PROPOVA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 NT-PARCELA                    PIC  9(07) VALUE ZEROS.*/
            public IntBasis NT_PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 DP-PROPOVA                    PIC  9(07) VALUE ZEROS.*/
            public IntBasis DP_PROPOVA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 DP-DTVENCTO                   PIC  9(07) VALUE ZEROS.*/
            public IntBasis DP_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 DP-AGECTA                     PIC  9(07) VALUE ZEROS.*/
            public IntBasis DP_AGECTA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 WS-PRM-TOT                    PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 WS-PRM-DIF                    PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_VA0340B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VA0340B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VA0340B_FILLER_1(); _.Move(AC_LIDOS, _filler_1); VarBasis.RedefinePassValue(AC_LIDOS, _filler_1, AC_LIDOS); _filler_1.ValueChanged += () => { _.Move(_filler_1, AC_LIDOS); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_VA0340B_FILLER_1 : VarBasis
            {
                /*"        10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"        10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_VA0340B_FILLER_1()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_VA0340B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_VA0340B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_VA0340B_FILLER_2(); _.Move(WTIME_DAY, _filler_2); VarBasis.RedefinePassValue(WTIME_DAY, _filler_2, WTIME_DAY); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTIME_DAY); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VA0340B_FILLER_2 : VarBasis
            {
                /*"      10       WTIME-DAYR.*/
                public VA0340B_WTIME_DAYR WTIME_DAYR { get; set; } = new VA0340B_WTIME_DAYR();
                public class VA0340B_WTIME_DAYR : VarBasis
                {
                    /*"        15     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"        15     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"        15     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10       WTIME-2PT3         PIC  X(001).*/

                    public VA0340B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05         WS-TIME.*/

                public _REDEF_VA0340B_FILLER_2()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VA0340B_WS_TIME WS_TIME { get; set; } = new VA0340B_WS_TIME();
            public class VA0340B_WS_TIME : VarBasis
            {
                /*"        10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WABEND.*/
            }
            public VA0340B_WABEND WABEND { get; set; } = new VA0340B_WABEND();
            public class VA0340B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010)   VALUE           'VA0340B  '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0340B  ");
                /*"      10    FILLER                   PIC  X(028)   VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"      10    WNR-EXEC-SQL             PIC  X(004)   VALUE SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10    FILLER                   PIC  X(014)   VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE           '   SQLERRMC = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
                /*"      10    WSQLERRMC                PIC  X(070)   VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01  MOV-HEADER.*/
            }
        }
        public VA0340B_MOV_HEADER MOV_HEADER { get; set; } = new VA0340B_MOV_HEADER();
        public class VA0340B_MOV_HEADER : VarBasis
        {
            /*"    05 MA-COD-REG         PIC X(001) VALUE 'A'.*/
            public StringBasis MA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"A");
            /*"    05 MA-COD-REMESSA     PIC X(001) VALUE '1'.*/
            public StringBasis MA_COD_REMESSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
            /*"    05 MA-COD-CONVENIO    PIC X(020) VALUE '6088'.*/
            public StringBasis MA_COD_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"6088");
            /*"    05 MA-NOMF-EMPRESA    PIC X(020) VALUE 'SASSE'.*/
            public StringBasis MA_NOMF_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SASSE");
            /*"    05 MA-COD-BANCO       PIC X(003) VALUE '104'.*/
            public StringBasis MA_COD_BANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"104");
            /*"    05 MA-NOMF-BANCO      PIC X(020) VALUE 'CEF'.*/
            public StringBasis MA_NOMF_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CEF");
            /*"    05 MA-DATA-GERACAO    PIC 9(008).*/
            public IntBasis MA_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 MA-NSA             PIC 9(006).*/
            public IntBasis MA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 MA-VERSAO-LAYOUT   PIC 9(002).*/
            public IntBasis MA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 MA-SERVICO         PIC X(017) VALUE 'DEB SEGURO MULTIP'.*/
            public StringBasis MA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"DEB SEGURO MULTIP");
            /*"    05 MA-RESERVADO       PIC X(052) VALUE SPACES.*/
            public StringBasis MA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"");
            /*"01  MOV-LANCAMENTO.*/
        }
        public VA0340B_MOV_LANCAMENTO MOV_LANCAMENTO { get; set; } = new VA0340B_MOV_LANCAMENTO();
        public class VA0340B_MOV_LANCAMENTO : VarBasis
        {
            /*"    05 MF-COD-REG           PIC X(001) VALUE 'E'.*/
            public StringBasis MF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
            /*"    05 MF-IDENT-CLI-EMPRESA.*/
            public VA0340B_MF_IDENT_CLI_EMPRESA MF_IDENT_CLI_EMPRESA { get; set; } = new VA0340B_MF_IDENT_CLI_EMPRESA();
            public class VA0340B_MF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 MF-IDENT-CLI      PIC 9(015).*/
                public IntBasis MF_IDENT_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 MF-IDENT-CLI-R    REDEFINES  MF-IDENT-CLI.*/
                private _REDEF_VA0340B_MF_IDENT_CLI_R _mf_ident_cli_r { get; set; }
                public _REDEF_VA0340B_MF_IDENT_CLI_R MF_IDENT_CLI_R
                {
                    get { _mf_ident_cli_r = new _REDEF_VA0340B_MF_IDENT_CLI_R(); _.Move(MF_IDENT_CLI, _mf_ident_cli_r); VarBasis.RedefinePassValue(MF_IDENT_CLI, _mf_ident_cli_r, MF_IDENT_CLI); _mf_ident_cli_r.ValueChanged += () => { _.Move(_mf_ident_cli_r, MF_IDENT_CLI); }; return _mf_ident_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _mf_ident_cli_r, MF_IDENT_CLI); }
                }  //Redefines
                public class _REDEF_VA0340B_MF_IDENT_CLI_R : VarBasis
                {
                    /*"          15 FILLER         PIC X(015).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10 MF-NSA-PARM       PIC 9(005) VALUE ZEROS.*/

                    public _REDEF_VA0340B_MF_IDENT_CLI_R()
                    {
                        FILLER_9.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis MF_NSA_PARM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"       10 FILLER            PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05 MF-AGENCIA           PIC 9(004).*/
            }
            public IntBasis MF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 MF-IDENT-CLI-BANCO.*/
            public VA0340B_MF_IDENT_CLI_BANCO MF_IDENT_CLI_BANCO { get; set; } = new VA0340B_MF_IDENT_CLI_BANCO();
            public class VA0340B_MF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 MF-OPR-CTA-CORR   PIC 9(004).*/
                public IntBasis MF_OPR_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 MF-NUM-CTA-CORR   PIC 9(012).*/
                public IntBasis MF_NUM_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 MF-DAC-CTA-CORR   PIC 9(001).*/
                public IntBasis MF_DAC_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER            PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05 MF-DATA-VENCIMENTO   PIC 9(008).*/
            }
            public IntBasis MF_DATA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 MF-VALOR             PIC 9(13)V99.*/
            public DoubleBasis MF_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 MF-COD-MOEDA         PIC X(002) VALUE '00'.*/
            public StringBasis MF_COD_MOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"00");
            /*"    05 MF-USO-EMPRESA.*/
            public VA0340B_MF_USO_EMPRESA MF_USO_EMPRESA { get; set; } = new VA0340B_MF_USO_EMPRESA();
            public class VA0340B_MF_USO_EMPRESA : VarBasis
            {
                /*"       10 MF-NSA            PIC 9(003).*/
                public IntBasis MF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 MF-NSL            PIC 9(008).*/
                public IntBasis MF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 FILLER            PIC X(047) VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"");
                /*"    05 MF-RESERVADO         PIC X(017) VALUE SPACES.*/
            }
            public StringBasis MF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
            /*"    05 MF-COD-MOV           PIC X(001) VALUE '0'.*/
            public StringBasis MF_COD_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
            /*"01  MOV-TRAILLER.*/
        }
        public VA0340B_MOV_TRAILLER MOV_TRAILLER { get; set; } = new VA0340B_MOV_TRAILLER();
        public class VA0340B_MOV_TRAILLER : VarBasis
        {
            /*"    05 MZ-COD-REG         PIC X(001) VALUE 'Z'.*/
            public StringBasis MZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"Z");
            /*"    05 MZ-QTDE-REGISTROS  PIC 9(006).*/
            public IntBasis MZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 MZ-TOT-DEB-CRUZ    PIC 9(015)V99 VALUE 0.*/
            public DoubleBasis MZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
            /*"    05 MZ-TOT-VAL-CRUZ    PIC 9(015)V99 VALUE 0.*/
            public DoubleBasis MZ_TOT_VAL_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
            /*"    05 MZ-RESERVADO       PIC X(109) VALUE SPACES.*/
            public StringBasis MZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)"), @"");
        }


        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.FERIADOS FERIADOS { get; set; } = new Dclgens.FERIADOS();
        public VA0340B_V0HCONTAVA V0HCONTAVA { get; set; } = new VA0340B_V0HCONTAVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVIMENTO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);

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

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -461- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -462- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -464- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -466- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -476- DISPLAY 'VA0340B - VERSAO 16 - INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VA0340B - VERSAO 16 - INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -479- DISPLAY ' ' . */
            _.Display($" ");

            /*" -482- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -482- PERFORM R0200-00-SELECIONA. */

            R0200_00_SELECIONA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -487- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -491- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -493- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -494- DISPLAY ' ' */
            _.Display($" ");

            /*" -495- DISPLAY 'VA5340B - FIM NORMAL' */
            _.Display($"VA5340B - FIM NORMAL");

            /*" -498- DISPLAY ' ' */
            _.Display($" ");

            /*" -498- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -506- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -512- OPEN OUTPUT MOVIMENTO. */
            MOVIMENTO.Open(MOVIMENTO_RECORD);

            /*" -523- PERFORM R0050_00_INICIO_DB_SELECT_1 */

            R0050_00_INICIO_DB_SELECT_1();

            /*" -526- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -527- DISPLAY 'R0050-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0050-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -530- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -532- MOVE 'SIM' TO WS-CONSIDERA-DATA. */
            _.Move("SIM", WORK_AREA.WS_CONSIDERA_DATA);

            /*" -538- PERFORM R0050_00_INICIO_DB_SELECT_2 */

            R0050_00_INICIO_DB_SELECT_2();

            /*" -541- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -542- MOVE 'NAO' TO WS-CONSIDERA-DATA */
                _.Move("NAO", WORK_AREA.WS_CONSIDERA_DATA);

                /*" -543- ELSE */
            }
            else
            {


                /*" -545- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                {

                    /*" -546- DISPLAY 'R0050-00 - PROBLEMAS NO SELECT(CALENDAR)' */
                    _.Display($"R0050-00 - PROBLEMAS NO SELECT(CALENDAR)");

                    /*" -548- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -553- PERFORM R0050_00_INICIO_DB_SELECT_3 */

            R0050_00_INICIO_DB_SELECT_3();

            /*" -556- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -557- MOVE 'NAO' TO WS-CONSIDERA-DATA */
                _.Move("NAO", WORK_AREA.WS_CONSIDERA_DATA);

                /*" -558- ELSE */
            }
            else
            {


                /*" -560- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                {

                    /*" -561- DISPLAY 'R0050-00 - PROBLEMAS NO SELECT(FERIADOS)' */
                    _.Display($"R0050-00 - PROBLEMAS NO SELECT(FERIADOS)");

                    /*" -564- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -565- MOVE SIST-CURRDATE TO DATA-SQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.DATA_SQL);

            /*" -566- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -568- MOVE DATA-INVERTIDA TO MA-DATA-GERACAO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_HEADER.MA_DATA_GERACAO);

            /*" -576- DISPLAY '*** VA0340B *** DATA DE GERACAO DA FITA: ' DATA-SQL. */
            _.Display($"*** VA0340B *** DATA DE GERACAO DA FITA: {WORK_AREA.DATA_SQL}");

            /*" -585- PERFORM R0050_00_INICIO_DB_SELECT_4 */

            R0050_00_INICIO_DB_SELECT_4();

            /*" -588- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -589- DISPLAY 'R0050-00 - PROBLEMAS NO SELECT(CONVSUCOV)' */
                _.Display($"R0050-00 - PROBLEMAS NO SELECT(CONVSUCOV)");

                /*" -592- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -593- ADD 1 TO PARM-NSA. */
            PARM_NSA.Value = PARM_NSA + 1;

            /*" -594- MOVE PARM-NSA TO MA-NSA. */
            _.Move(PARM_NSA, MOV_HEADER.MA_NSA);

            /*" -595- MOVE PARM-NSA TO MF-NSA. */
            _.Move(PARM_NSA, MOV_LANCAMENTO.MF_USO_EMPRESA.MF_NSA);

            /*" -604- MOVE PARM-VERSAO TO MA-VERSAO-LAYOUT. */
            _.Move(PARM_VERSAO, MOV_HEADER.MA_VERSAO_LAYOUT);

            /*" -605- MOVE SIST-DTMOVABE TO W04DTSQL. */
            _.Move(SIST_DTMOVABE, WORK_AREA.W04DTSQL);

            /*" -606- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -607- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -608- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -609- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -610- PERFORM R0060-00-SOMA-DIAS 2 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0060_00_SOMA_DIAS_SECTION();

            }

            /*" -611- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -612- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -614- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -620- MOVE W04DTSQL TO SIST-DTMINDEB1. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMINDEB1);

            /*" -621- MOVE SIST-DTMOVABE TO W04DTSQL. */
            _.Move(SIST_DTMOVABE, WORK_AREA.W04DTSQL);

            /*" -622- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -623- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -624- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -625- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -626- PERFORM R0060-00-SOMA-DIAS 3 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0060_00_SOMA_DIAS_SECTION();

            }

            /*" -627- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -628- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -630- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -635- MOVE W04DTSQL TO SIST-DTMINDEB2. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMINDEB2);

            /*" -636- MOVE SIST-CURRDATE TO W04DTSQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.W04DTSQL);

            /*" -637- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -638- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -639- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -640- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -641- PERFORM R0060-00-SOMA-DIAS 2 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0060_00_SOMA_DIAS_SECTION();

            }

            /*" -642- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -643- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -645- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -651- MOVE W04DTSQL TO SIST-DTMINDEB3. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMINDEB3);

            /*" -652- MOVE SIST-CURRDATE TO W04DTSQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.W04DTSQL);

            /*" -653- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -654- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -655- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -656- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -657- PERFORM R0060-00-SOMA-DIAS 3 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0060_00_SOMA_DIAS_SECTION();

            }

            /*" -658- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -659- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -661- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -663- MOVE W04DTSQL TO SIST-DTMINDEB4. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMINDEB4);

            /*" -665- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

            /*" -667- MOVE SIST-DTMINDEB1 TO WS-DTPROXVEN-VP-GITEL */
            _.Move(SIST_DTMINDEB1, WORK_AREA.WS_DTPROXVEN_VP_GITEL);

            /*" -668- IF SIST-CURRDATE GREATER SIST-DTMOVABE */

            if (SIST_CURRDATE > SIST_DTMOVABE)
            {

                /*" -669- IF WS-CONSIDERA-DATA EQUAL 'SIM' */

                if (WORK_AREA.WS_CONSIDERA_DATA == "SIM")
                {

                    /*" -670- IF WS-TIME GREATER 6000000 */

                    if (WORK_AREA.WS_TIME > 6000000)
                    {

                        /*" -671- MOVE SIST-DTMINDEB2 TO WS-DTPROXVEN-VP-GITEL */
                        _.Move(SIST_DTMINDEB2, WORK_AREA.WS_DTPROXVEN_VP_GITEL);

                        /*" -672- END-IF */
                    }


                    /*" -673- END-IF */
                }


                /*" -675- END-IF. */
            }


            /*" -676- IF WS-DTPROXVEN-VP-GITEL LESS SIST-DTMINDEB3 */

            if (WORK_AREA.WS_DTPROXVEN_VP_GITEL < SIST_DTMINDEB3)
            {

                /*" -677- MOVE SIST-DTMINDEB3 TO WS-DTPROXVEN-VP-GITEL */
                _.Move(SIST_DTMINDEB3, WORK_AREA.WS_DTPROXVEN_VP_GITEL);

                /*" -678- IF WS-TIME GREATER 06000000 */

                if (WORK_AREA.WS_TIME > 06000000)
                {

                    /*" -679- MOVE SIST-DTMINDEB4 TO WS-DTPROXVEN-VP-GITEL */
                    _.Move(SIST_DTMINDEB4, WORK_AREA.WS_DTPROXVEN_VP_GITEL);

                    /*" -680- END-IF */
                }


                /*" -682- END-IF. */
            }


            /*" -683- DISPLAY 'SIST-DTMOVABE   ' SIST-DTMOVABE */
            _.Display($"SIST-DTMOVABE   {SIST_DTMOVABE}");

            /*" -684- DISPLAY 'SIST-CURRDATE   ' SIST-CURRDATE */
            _.Display($"SIST-CURRDATE   {SIST_CURRDATE}");

            /*" -685- DISPLAY 'SIST-DTMINDEB1  ' SIST-DTMINDEB1. */
            _.Display($"SIST-DTMINDEB1  {SIST_DTMINDEB1}");

            /*" -686- DISPLAY 'SIST-DTMINDEB2  ' SIST-DTMINDEB2. */
            _.Display($"SIST-DTMINDEB2  {SIST_DTMINDEB2}");

            /*" -687- DISPLAY 'SIST-DTMINDEB3  ' SIST-DTMINDEB3. */
            _.Display($"SIST-DTMINDEB3  {SIST_DTMINDEB3}");

            /*" -688- DISPLAY 'SIST-DTMINDEB4  ' SIST-DTMINDEB4. */
            _.Display($"SIST-DTMINDEB4  {SIST_DTMINDEB4}");

            /*" -690- DISPLAY 'WS-TIME         ' WS-TIME. */
            _.Display($"WS-TIME         {WORK_AREA.WS_TIME}");

            /*" -691- DISPLAY ' ' */
            _.Display($" ");

            /*" -692- DISPLAY 'DTPROXVEN VP GITEL ' WS-DTPROXVEN-VP-GITEL */
            _.Display($"DTPROXVEN VP GITEL {WORK_AREA.WS_DTPROXVEN_VP_GITEL}");

            /*" -698- DISPLAY ' ' */
            _.Display($" ");

            /*" -699- MOVE SIST-CURRDATE TO W04DTSQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.W04DTSQL);

            /*" -700- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -701- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -702- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -703- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -704- PERFORM R0060-00-SOMA-DIAS 4 TIMES. */

            for (int i = 0; i < 4; i++)
            {

                R0060_00_SOMA_DIAS_SECTION();

            }

            /*" -705- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -706- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -708- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -713- MOVE W04DTSQL TO SIST-DTMINDEB. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMINDEB);

            /*" -714- MOVE SIST-CURRDATE TO W04DTSQL. */
            _.Move(SIST_CURRDATE, WORK_AREA.W04DTSQL);

            /*" -715- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -716- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -717- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -718- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -719- PERFORM R0060-00-SOMA-DIAS 7 TIMES. */

            for (int i = 0; i < 7; i++)
            {

                R0060_00_SOMA_DIAS_SECTION();

            }

            /*" -720- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -721- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -723- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -725- MOVE W04DTSQL TO SIST-DTMAXDEB. */
            _.Move(WORK_AREA.W04DTSQL, SIST_DTMAXDEB);

            /*" -726- MOVE SIST-DTMAXDEB TO DATA-SQL. */
            _.Move(SIST_DTMAXDEB, WORK_AREA.DATA_SQL);

            /*" -727- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -728- MOVE DATA-INVERTIDA TO MF-DATA-VENCIMENTO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_LANCAMENTO.MF_DATA_VENCIMENTO);

            /*" -729- DISPLAY '*** VA0340B *** DATA MAXIMA DE DEBITO EM CONTA: ' DATA-SQL. */
            _.Display($"*** VA0340B *** DATA MAXIMA DE DEBITO EM CONTA: {WORK_AREA.DATA_SQL}");

        }

        [StopWatch]
        /*" R0050-00-INICIO-DB-SELECT-1 */
        public void R0050_00_INICIO_DB_SELECT_1()
        {
            /*" -523- EXEC SQL SELECT DTMOVABE, DTMOVABE + 1 DAY, DTMOVABE INTO :SIST-CURRDATE, :SIST-DTMINDEB, :SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM= 'VA' END-EXEC. */

            var r0050_00_INICIO_DB_SELECT_1_Query1 = new R0050_00_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0050_00_INICIO_DB_SELECT_1_Query1.Execute(r0050_00_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_CURRDATE, SIST_CURRDATE);
                _.Move(executed_1.SIST_DTMINDEB, SIST_DTMINDEB);
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-DB-SELECT-2 */
        public void R0050_00_INICIO_DB_SELECT_2()
        {
            /*" -538- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :SIST-CURRDATE AND DIA_SEMANA IN ( 'S' , 'D' ) END-EXEC. */

            var r0050_00_INICIO_DB_SELECT_2_Query1 = new R0050_00_INICIO_DB_SELECT_2_Query1()
            {
                SIST_CURRDATE = SIST_CURRDATE.ToString(),
            };

            var executed_1 = R0050_00_INICIO_DB_SELECT_2_Query1.Execute(r0050_00_INICIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }

        [StopWatch]
        /*" R0060-00-SOMA-DIAS-SECTION */
        private void R0060_00_SOMA_DIAS_SECTION()
        {
            /*" -742- MOVE '0060' TO WNR-EXEC-SQL. */
            _.Move("0060", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -743- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WORK_AREA.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -744- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WORK_AREA.PARM_PROSOMU1);

            /*" -744- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2, WORK_AREA.PARM_PROSOMU1.SU1_DATA1);

        }

        [StopWatch]
        /*" R0050-00-INICIO-DB-SELECT-3 */
        public void R0050_00_INICIO_DB_SELECT_3()
        {
            /*" -553- EXEC SQL SELECT DATA_FERIADO INTO :FERIADOS-DATA-FERIADO FROM SEGUROS.FERIADOS WHERE DATA_FERIADO = :SIST-CURRDATE END-EXEC. */

            var r0050_00_INICIO_DB_SELECT_3_Query1 = new R0050_00_INICIO_DB_SELECT_3_Query1()
            {
                SIST_CURRDATE = SIST_CURRDATE.ToString(),
            };

            var executed_1 = R0050_00_INICIO_DB_SELECT_3_Query1.Execute(r0050_00_INICIO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FERIADOS_DATA_FERIADO, FERIADOS.DCLFERIADOS.FERIADOS_DATA_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-DB-SELECT-4 */
        public void R0050_00_INICIO_DB_SELECT_4()
        {
            /*" -585- EXEC SQL SELECT COD_CONVENIO, NSA_CONVENIO, VERSAO_LAYOUT INTO :PARM-CODCONV, :PARM-NSA, :PARM-VERSAO FROM SEGUROS.V0CONVSUCOV WHERE COD_CONVENIO = 6088 END-EXEC. */

            var r0050_00_INICIO_DB_SELECT_4_Query1 = new R0050_00_INICIO_DB_SELECT_4_Query1()
            {
            };

            var executed_1 = R0050_00_INICIO_DB_SELECT_4_Query1.Execute(r0050_00_INICIO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARM_CODCONV, PARM_CODCONV);
                _.Move(executed_1.PARM_NSA, PARM_NSA);
                _.Move(executed_1.PARM_VERSAO, PARM_VERSAO);
            }


        }

        [StopWatch]
        /*" R0200-00-SELECIONA-SECTION */
        private void R0200_00_SELECIONA_SECTION()
        {
            /*" -757- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -758- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

            /*" -759- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WORK_AREA.WS_TIME.WS_HH_TIME, WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_HORA);

            /*" -760- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_2PT1);

            /*" -761- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WORK_AREA.WS_TIME.WS_MM_TIME, WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_MINU);

            /*" -762- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_2PT2);

            /*" -763- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WORK_AREA.WS_TIME.WS_SS_TIME, WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_SEGU);

            /*" -765- DISPLAY 'LEITURA HISTCONTAVA' WTIME-DAYR. */
            _.Display($"LEITURA HISTCONTAVA{WORK_AREA.FILLER_2.WTIME_DAYR}");

            /*" -767- MOVE ZEROS TO WS-EOF. */
            _.Move(0, WORK_AREA.WS_EOF);

            /*" -768- PERFORM R0300-00-DECLARE-V0HCONTAVA. */

            R0300_00_DECLARE_V0HCONTAVA_SECTION();

            /*" -770- PERFORM R0310-00-FETCH-V0HCONTAVA. */

            R0310_00_FETCH_V0HCONTAVA_SECTION();

            /*" -771- IF WS-EOF NOT EQUAL ZEROS */

            if (WORK_AREA.WS_EOF != 00)
            {

                /*" -772- DISPLAY '*** VA0340B *** CONVENIO 6088' */
                _.Display($"*** VA0340B *** CONVENIO 6088");

                /*" -773- DISPLAY '*** VA0340B *** NAO HA DEBITOS A PROCESSAR' */
                _.Display($"*** VA0340B *** NAO HA DEBITOS A PROCESSAR");

                /*" -774- DISPLAY '*** VA0340B *** TERMINO NORMAL' */
                _.Display($"*** VA0340B *** TERMINO NORMAL");

                /*" -777- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -780- WRITE MOVIMENTO-RECORD FROM MOV-HEADER. */
            _.Move(MOV_HEADER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -784- PERFORM R0320-00-PROCESSA-V0HCONTAVA UNTIL WS-EOF NOT EQUAL ZEROS. */

            while (!(WORK_AREA.WS_EOF != 00))
            {

                R0320_00_PROCESSA_V0HCONTAVA_SECTION();
            }

            /*" -785- DISPLAY ' ' */
            _.Display($" ");

            /*" -786- DISPLAY 'LIDOS HCONTAVA ........ ' LD-HCONTAVA */
            _.Display($"LIDOS HCONTAVA ........ {WORK_AREA.LD_HCONTAVA}");

            /*" -787- DISPLAY 'SEM   PROPOVA ......... ' NT-PROPOVA */
            _.Display($"SEM   PROPOVA ......... {WORK_AREA.NT_PROPOVA}");

            /*" -788- DISPLAY 'DESPR PROPOVA ......... ' DP-PROPOVA */
            _.Display($"DESPR PROPOVA ......... {WORK_AREA.DP_PROPOVA}");

            /*" -789- DISPLAY 'SEM   PARCELVA ........ ' NT-PARCELA */
            _.Display($"SEM   PARCELVA ........ {WORK_AREA.NT_PARCELA}");

            /*" -790- DISPLAY 'DESPREZA OPCAOPAG ..... ' DP-OPCAOPAG. */
            _.Display($"DESPREZA OPCAOPAG ..... {WORK_AREA.DP_OPCAOPAG}");

            /*" -791- DISPLAY 'DESPREZA SITUACAO ..... ' DP-SITUACAO. */
            _.Display($"DESPREZA SITUACAO ..... {WORK_AREA.DP_SITUACAO}");

            /*" -792- DISPLAY 'DESPREZA VENCTO ....... ' DP-DTVENCTO. */
            _.Display($"DESPREZA VENCTO ....... {WORK_AREA.DP_DTVENCTO}");

            /*" -793- DISPLAY 'DESPREZA AGENCIA ...... ' DP-AGECTA. */
            _.Display($"DESPREZA AGENCIA ...... {WORK_AREA.DP_AGECTA}");

            /*" -796- DISPLAY ' ' . */
            _.Display($" ");

            /*" -796- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0HCONTAVA-SECTION */
        private void R0300_00_DECLARE_V0HCONTAVA_SECTION()
        {
            /*" -808- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -810- DISPLAY 'SIST-DTMAXDEB = ' SIST-DTMAXDEB */
            _.Display($"SIST-DTMAXDEB = {SIST_DTMAXDEB}");

            /*" -832- PERFORM R0300_00_DECLARE_V0HCONTAVA_DB_DECLARE_1 */

            R0300_00_DECLARE_V0HCONTAVA_DB_DECLARE_1();

            /*" -835- PERFORM R0300_00_DECLARE_V0HCONTAVA_DB_OPEN_1 */

            R0300_00_DECLARE_V0HCONTAVA_DB_OPEN_1();

            /*" -838- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -839- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (HCONTAVA)  ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (HCONTAVA)  ");

                /*" -839- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0HCONTAVA-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0HCONTAVA_DB_DECLARE_1()
        {
            /*" -832- EXEC SQL DECLARE V0HCONTAVA CURSOR WITH HOLD FOR SELECT NRCERTIF, NRPARCEL, OCORRHISTCTA, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, VLPRMTOT, SITUACAO, DTVENCTO, NSAS, NSL FROM SEGUROS.V0HISTCONTAVA WHERE DTVENCTO <= :SIST-DTMAXDEB AND CODCONV = 6088 AND SITUACAO = '0' AND TIPLANC = '1' AND NUMCTADEB > 0 ORDER BY NRCERTIF, NRPARCEL, OCORRHISTCTA END-EXEC. */
            V0HCONTAVA = new VA0340B_V0HCONTAVA(true);
            string GetQuery_V0HCONTAVA()
            {
                var query = @$"SELECT NRCERTIF
							, 
							NRPARCEL
							, 
							OCORRHISTCTA
							, 
							AGECTADEB
							, 
							OPRCTADEB
							, 
							NUMCTADEB
							, 
							DIGCTADEB
							, 
							VLPRMTOT
							, 
							SITUACAO
							, 
							DTVENCTO
							, 
							NSAS
							, 
							NSL 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE DTVENCTO <= '{SIST_DTMAXDEB}' 
							AND CODCONV = 6088 
							AND SITUACAO = '0' 
							AND TIPLANC = '1' 
							AND NUMCTADEB > 0 
							ORDER BY NRCERTIF
							, NRPARCEL
							, OCORRHISTCTA";

                return query;
            }
            V0HCONTAVA.GetQueryEvent += GetQuery_V0HCONTAVA;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0HCONTAVA-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0HCONTAVA_DB_OPEN_1()
        {
            /*" -835- EXEC SQL OPEN V0HCONTAVA END-EXEC. */

            V0HCONTAVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0HCONTAVA-SECTION */
        private void R0310_00_FETCH_V0HCONTAVA_SECTION()
        {
            /*" -852- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -865- PERFORM R0310_00_FETCH_V0HCONTAVA_DB_FETCH_1 */

            R0310_00_FETCH_V0HCONTAVA_DB_FETCH_1();

            /*" -868- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -869- DISPLAY 'R0310-00 - PROBLEMAS FETCH (HCONTAVA)    ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH (HCONTAVA)    ");

                /*" -871- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -872- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -872- PERFORM R0310_00_FETCH_V0HCONTAVA_DB_CLOSE_1 */

                R0310_00_FETCH_V0HCONTAVA_DB_CLOSE_1();

                /*" -874- MOVE 1 TO WS-EOF */
                _.Move(1, WORK_AREA.WS_EOF);

                /*" -876- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -877- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -878- DISPLAY 'R0310-00 - PROBLEMAS FETCH (HCONTAVA)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH (HCONTAVA)   ");

                /*" -880- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -881- IF SQL-MAYBE-NULL1 LESS ZEROS */

            if (SQL_MAYBE_NULL1 < 00)
            {

                /*" -884- MOVE ZEROS TO NSAS. */
                _.Move(0, NSAS);
            }


            /*" -885- IF SQL-MAYBE-NULL2 LESS ZEROS */

            if (SQL_MAYBE_NULL2 < 00)
            {

                /*" -888- MOVE ZEROS TO NSL. */
                _.Move(0, NSL);
            }


            /*" -890- ADD 1 TO LD-HCONTAVA. */
            WORK_AREA.LD_HCONTAVA.Value = WORK_AREA.LD_HCONTAVA + 1;

            /*" -892- MOVE LD-HCONTAVA TO AC-LIDOS. */
            _.Move(WORK_AREA.LD_HCONTAVA, WORK_AREA.AC_LIDOS);

            /*" -894- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (WORK_AREA.FILLER_1.LD_PARTE2 == 00 || WORK_AREA.FILLER_1.LD_PARTE2 == 5000)
            {

                /*" -895- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -896- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(WORK_AREA.WS_TIME.WS_HH_TIME, WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_HORA);

                /*" -897- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_2PT1);

                /*" -898- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(WORK_AREA.WS_TIME.WS_MM_TIME, WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_MINU);

                /*" -899- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_2PT2);

                /*" -900- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(WORK_AREA.WS_TIME.WS_SS_TIME, WORK_AREA.FILLER_2.WTIME_DAYR.WTIME_SEGU);

                /*" -901- DISPLAY 'LIDOS HCONTAVA     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS HCONTAVA     {WORK_AREA.AC_LIDOS}    {WORK_AREA.FILLER_2.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-V0HCONTAVA-DB-FETCH-1 */
        public void R0310_00_FETCH_V0HCONTAVA_DB_FETCH_1()
        {
            /*" -865- EXEC SQL FETCH V0HCONTAVA INTO :NRCERTIF, :NRPARCEL, :OCORRHISTCTA, :AGECTADEB, :OPRCTADEB, :NUMCTADEB, :DIGCTADEB, :VLPRMTOT, :SITUACAO, :DTVENCTO, :NSAS:SQL-MAYBE-NULL1, :NSL:SQL-MAYBE-NULL2 END-EXEC. */

            if (V0HCONTAVA.Fetch())
            {
                _.Move(V0HCONTAVA.NRCERTIF, NRCERTIF);
                _.Move(V0HCONTAVA.NRPARCEL, NRPARCEL);
                _.Move(V0HCONTAVA.OCORRHISTCTA, OCORRHISTCTA);
                _.Move(V0HCONTAVA.AGECTADEB, AGECTADEB);
                _.Move(V0HCONTAVA.OPRCTADEB, OPRCTADEB);
                _.Move(V0HCONTAVA.NUMCTADEB, NUMCTADEB);
                _.Move(V0HCONTAVA.DIGCTADEB, DIGCTADEB);
                _.Move(V0HCONTAVA.VLPRMTOT, VLPRMTOT);
                _.Move(V0HCONTAVA.SITUACAO, SITUACAO);
                _.Move(V0HCONTAVA.DTVENCTO, DTVENCTO);
                _.Move(V0HCONTAVA.NSAS, NSAS);
                _.Move(V0HCONTAVA.SQL_MAYBE_NULL1, SQL_MAYBE_NULL1);
                _.Move(V0HCONTAVA.NSL, NSL);
                _.Move(V0HCONTAVA.SQL_MAYBE_NULL2, SQL_MAYBE_NULL2);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0HCONTAVA-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0HCONTAVA_DB_CLOSE_1()
        {
            /*" -872- EXEC SQL CLOSE V0HCONTAVA END-EXEC */

            V0HCONTAVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-V0HCONTAVA-SECTION */
        private void R0320_00_PROCESSA_V0HCONTAVA_SECTION()
        {
            /*" -911- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -918- PERFORM R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1 */

            R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1();

            /*" -921- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -922- DISPLAY 'R0320-00 - PROBLEMAS SELECT (PROPOVA)   ' */
                _.Display($"R0320-00 - PROBLEMAS SELECT (PROPOVA)   ");

                /*" -923- DISPLAY 'NRCERTIF   ' NRCERTIF */
                _.Display($"NRCERTIF   {NRCERTIF}");

                /*" -924- ADD 1 TO NT-PROPOVA */
                WORK_AREA.NT_PROPOVA.Value = WORK_AREA.NT_PROPOVA + 1;

                /*" -926- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -928- IF V0PROP-SITUACAO EQUAL '3' OR '6' OR '8' NEXT SENTENCE */

            if (V0PROP_SITUACAO.In("3", "6", "8"))
            {

                /*" -929- ELSE */
            }
            else
            {


                /*" -930- ADD 1 TO DP-PROPOVA */
                WORK_AREA.DP_PROPOVA.Value = WORK_AREA.DP_PROPOVA + 1;

                /*" -933- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -941- PERFORM R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2 */

            R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2();

            /*" -944- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -945- DISPLAY 'R0320-00 - PROBLEMAS SELECT (PARCELVA)   ' */
                _.Display($"R0320-00 - PROBLEMAS SELECT (PARCELVA)   ");

                /*" -946- DISPLAY 'NRCERTIF   ' NRCERTIF */
                _.Display($"NRCERTIF   {NRCERTIF}");

                /*" -947- ADD 1 TO NT-PARCELA */
                WORK_AREA.NT_PARCELA.Value = WORK_AREA.NT_PARCELA + 1;

                /*" -950- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -951- MOVE AGECTADEB TO MF-AGENCIA. */
            _.Move(AGECTADEB, MOV_LANCAMENTO.MF_AGENCIA);

            /*" -952- IF V0PARC-OPCAOPAG NOT EQUAL '1' AND '2' */

            if (!V0PARC_OPCAOPAG.In("1", "2"))
            {

                /*" -953- ADD 1 TO DP-OPCAOPAG */
                WORK_AREA.DP_OPCAOPAG.Value = WORK_AREA.DP_OPCAOPAG + 1;

                /*" -956- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -958- IF V0PARC-SITUACAO EQUAL ' ' OR '0' NEXT SENTENCE */

            if (V0PARC_SITUACAO.In(" ", "0"))
            {

                /*" -959- ELSE */
            }
            else
            {


                /*" -966- PERFORM R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1 */

                R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1();

                /*" -968- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -969- DISPLAY 'R0320-00 - PROBLEMAS UPDATE (HCONTAVA) ' */
                    _.Display($"R0320-00 - PROBLEMAS UPDATE (HCONTAVA) ");

                    /*" -970- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -971- ELSE */
                }
                else
                {


                    /*" -972- ADD 1 TO DP-SITUACAO */
                    WORK_AREA.DP_SITUACAO.Value = WORK_AREA.DP_SITUACAO + 1;

                    /*" -975- GO TO R0320-90-LEITURA. */

                    R0320_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -984- PERFORM R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3 */

            R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3();

            /*" -987- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -988- DISPLAY 'R0320-00 - PROBLEMAS NO SELECT(CALENDAR)' */
                _.Display($"R0320-00 - PROBLEMAS NO SELECT(CALENDAR)");

                /*" -991- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -994- IF CALENDAR-FERIADO NOT EQUAL SPACES OR CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' */

            if (!CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO.IsEmpty() || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D")
            {

                /*" -995- MOVE DTVENCTO TO W05DTSQL */
                _.Move(DTVENCTO, WORK_AREA.W05DTSQL);

                /*" -996- MOVE W05DDSQL TO SU1-DD1 */
                _.Move(WORK_AREA.W05DTSQL.W05DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

                /*" -997- MOVE W05MMSQL TO SU1-MM1 */
                _.Move(WORK_AREA.W05DTSQL.W05MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

                /*" -998- MOVE W05AASQL TO SU1-AA1 */
                _.Move(WORK_AREA.W05DTSQL.W05AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

                /*" -999- MOVE ZEROES TO SU1-DATA2 */
                _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

                /*" -1000- PERFORM R0060-00-SOMA-DIAS 1 TIMES */

                for (int i = 0; i < 1; i++)
                {

                    R0060_00_SOMA_DIAS_SECTION();

                }

                /*" -1001- MOVE SU1-DD2 TO W05DDSQL */
                _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W05DTSQL.W05DDSQL);

                /*" -1002- MOVE SU1-MM2 TO W05MMSQL */
                _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W05DTSQL.W05MMSQL);

                /*" -1003- MOVE SU1-AA2 TO W05AASQL */
                _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W05DTSQL.W05AASQL);

                /*" -1005- MOVE W05DTSQL TO DTVENCTO. */
                _.Move(WORK_AREA.W05DTSQL, DTVENCTO);
            }


            /*" -1006- IF DTVENCTO GREATER SIST-DTMAXDEB */

            if (DTVENCTO > SIST_DTMAXDEB)
            {

                /*" -1007- ADD 1 TO DP-DTVENCTO */
                WORK_AREA.DP_DTVENCTO.Value = WORK_AREA.DP_DTVENCTO + 1;

                /*" -1009- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -1010- ADD 1 TO WS-NSL. */
            WORK_AREA.WS_NSL.Value = WORK_AREA.WS_NSL + 1;

            /*" -1012- MOVE WS-NSL TO NSL FITSAS-NSL */
            _.Move(WORK_AREA.WS_NSL, NSL, FITSAS_NSL);

            /*" -1014- MOVE WS-NSL TO MF-NSL. */
            _.Move(WORK_AREA.WS_NSL, MOV_LANCAMENTO.MF_USO_EMPRESA.MF_NSL);

            /*" -1015- MOVE SPACES TO MF-IDENT-CLI-EMPRESA. */
            _.Move("", MOV_LANCAMENTO.MF_IDENT_CLI_EMPRESA);

            /*" -1017- MOVE NRCERTIF TO MF-IDENT-CLI. */
            _.Move(NRCERTIF, MOV_LANCAMENTO.MF_IDENT_CLI_EMPRESA.MF_IDENT_CLI);

            /*" -1018- MOVE AGECTADEB TO MF-AGENCIA. */
            _.Move(AGECTADEB, MOV_LANCAMENTO.MF_AGENCIA);

            /*" -1019- MOVE OPRCTADEB TO MF-OPR-CTA-CORR. */
            _.Move(OPRCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_OPR_CTA_CORR);

            /*" -1020- MOVE NUMCTADEB TO MF-NUM-CTA-CORR. */
            _.Move(NUMCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_NUM_CTA_CORR);

            /*" -1021- MOVE DIGCTADEB TO MF-DAC-CTA-CORR. */
            _.Move(DIGCTADEB, MOV_LANCAMENTO.MF_IDENT_CLI_BANCO.MF_DAC_CTA_CORR);

            /*" -1024- MOVE VLPRMTOT TO MF-VALOR. */
            _.Move(VLPRMTOT, MOV_LANCAMENTO.MF_VALOR);

            /*" -1025- IF NRCERTIF NOT EQUAL 21024130000011 */

            if (NRCERTIF != 21024130000011)
            {

                /*" -1026- IF DTVENCTO LESS SIST-DTMINDEB */

                if (DTVENCTO < SIST_DTMINDEB)
                {

                    /*" -1027- MOVE SIST-DTMINDEB TO DTVENCTO */
                    _.Move(SIST_DTMINDEB, DTVENCTO);

                    /*" -1029- END-IF. */
                }

            }


            /*" -1030- MOVE NRCERTIF TO W-NUM-PROPOSTA */
            _.Move(NRCERTIF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -1032- MOVE V0PROP-CODPRODU TO W-CODPRODU */
            _.Move(V0PROP_CODPRODU, WORK_AREA.W_CODPRODU);

            /*" -1033- IF W-CODPRODU(1:2) = 77 */

            if (WORK_AREA.W_CODPRODU.Substring(1, 2) == 77)
            {

                /*" -1034- IF CANAL-VENDA-GITEL */

                if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
                {

                    /*" -1035- MOVE WS-DTPROXVEN-VP-GITEL TO DTVENCTO */
                    _.Move(WORK_AREA.WS_DTPROXVEN_VP_GITEL, DTVENCTO);

                    /*" -1036- END-IF */
                }


                /*" -1039- END-IF. */
            }


            /*" -1044- PERFORM R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2 */

            R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2();

            /*" -1047- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1048- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1051- DISPLAY 'CERTIFICADO DESPREZADO ---> ' ' ' NRCERTIF ' ' NRPARCEL */

                    $"CERTIFICADO DESPREZADO --->  {NRCERTIF} {NRPARCEL}"
                    .Display();

                    /*" -1052- GO TO R0320-90-LEITURA */

                    R0320_90_LEITURA(); //GOTO
                    return;

                    /*" -1053- ELSE */
                }
                else
                {


                    /*" -1054- DISPLAY 'R0320-00 - PROBLEMAS NO UPDATE(HISCOBVA)' */
                    _.Display($"R0320-00 - PROBLEMAS NO UPDATE(HISCOBVA)");

                    /*" -1056- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1057- MOVE DTVENCTO TO DATA-SQL. */
            _.Move(DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -1058- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -1060- MOVE DATA-INVERTIDA TO MF-DATA-VENCIMENTO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, MOV_LANCAMENTO.MF_DATA_VENCIMENTO);

            /*" -1062- MOVE PARM-NSA TO MF-NSA-PARM. */
            _.Move(PARM_NSA, MOV_LANCAMENTO.MF_IDENT_CLI_EMPRESA.MF_NSA_PARM);

            /*" -1064- IF AGECTADEB EQUAL 7929 AND DTVENCTO GREATER '2018-04-13' */

            if (AGECTADEB == 7929 && DTVENCTO > "2018-04-13")
            {

                /*" -1065- ADD 1 TO DP-AGECTA */
                WORK_AREA.DP_AGECTA.Value = WORK_AREA.DP_AGECTA + 1;

                /*" -1067- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -1069- IF AGECTADEB EQUAL 4559 AND DTVENCTO GREATER '2018-02-23' */

            if (AGECTADEB == 4559 && DTVENCTO > "2018-02-23")
            {

                /*" -1070- ADD 1 TO DP-AGECTA */
                WORK_AREA.DP_AGECTA.Value = WORK_AREA.DP_AGECTA + 1;

                /*" -1072- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -1073- IF V0PROP-CODPRODU = 7732 OR 7733 */

            if (V0PROP_CODPRODU.In("7732", "7733"))
            {

                /*" -1074- MOVE DTVENCTO TO WS-DT-AUX1 */
                _.Move(DTVENCTO, WS_DT_AUX1);

                /*" -1075- MOVE WS-DT-AUX1-ANO TO WS-DT-AUX2-ANO */
                _.Move(WS_DT_AUX1.WS_DT_AUX1_ANO, WS_DT_AUX2.WS_DT_AUX2_ANO);

                /*" -1076- MOVE WS-DT-AUX1-MES TO WS-DT-AUX2-MES */
                _.Move(WS_DT_AUX1.WS_DT_AUX1_MES, WS_DT_AUX2.WS_DT_AUX2_MES);

                /*" -1077- MOVE WS-DT-AUX1-DIA TO WS-DT-AUX2-DIA */
                _.Move(WS_DT_AUX1.WS_DT_AUX1_DIA, WS_DT_AUX2.WS_DT_AUX2_DIA);

                /*" -1078- MOVE WS-DT-AUX2 TO MF-DATA-VENCIMENTO */
                _.Move(WS_DT_AUX2, MOV_LANCAMENTO.MF_DATA_VENCIMENTO);

                /*" -1079- END-IF */
            }


            /*" -1081- WRITE MOVIMENTO-RECORD FROM MOV-LANCAMENTO. */
            _.Move(MOV_LANCAMENTO.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -1082- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -1085- ADD VLPRMTOT TO AC-VALOR. */
            WORK_AREA.AC_VALOR.Value = WORK_AREA.AC_VALOR + VLPRMTOT;

            /*" -1095- PERFORM R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3 */

            R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3();

            /*" -1098- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1099- DISPLAY 'R0320-00 - PROBLEMAS NO UPDATE(HCONTAVA)' */
                _.Display($"R0320-00 - PROBLEMAS NO UPDATE(HCONTAVA)");

                /*" -1101- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1102- IF V0PROP-CODPRODU = 7732 OR 7733 */

            if (V0PROP_CODPRODU.In("7732", "7733"))
            {

                /*" -1103- ADD 1 TO WS-QTD-CESTASERV */
                WORK_AREA.WS_QTD_CESTASERV.Value = WORK_AREA.WS_QTD_CESTASERV + 1;

                /*" -1103- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0320_90_LEITURA */

            R0320_90_LEITURA();

        }

        [StopWatch]
        /*" R0320-00-PROCESSA-V0HCONTAVA-DB-SELECT-1 */
        public void R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1()
        {
            /*" -918- EXEC SQL SELECT SITUACAO, CODPRODU INTO :V0PROP-SITUACAO, :V0PROP-CODPRODU FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :NRCERTIF END-EXEC. */

            var r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1_Query1 = new R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
            };

            var executed_1 = R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1_Query1.Execute(r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
            }


        }

        [StopWatch]
        /*" R0320-90-LEITURA */
        private void R0320_90_LEITURA(bool isPerform = false)
        {
            /*" -1107- PERFORM R0310-00-FETCH-V0HCONTAVA. */

            R0310_00_FETCH_V0HCONTAVA_SECTION();

        }

        [StopWatch]
        /*" R0320-00-PROCESSA-V0HCONTAVA-DB-UPDATE-1 */
        public void R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1()
        {
            /*" -966- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '2' WHERE NRCERTIF = :NRCERTIF AND NRPARCEL = :NRPARCEL AND OCORRHISTCTA = :OCORRHISTCTA END-EXEC */

            var r0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1_Update1 = new R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1_Update1()
            {
                OCORRHISTCTA = OCORRHISTCTA.ToString(),
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
            };

            R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1_Update1.Execute(r0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0320-00-PROCESSA-V0HCONTAVA-DB-SELECT-2 */
        public void R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2()
        {
            /*" -941- EXEC SQL SELECT SITUACAO , OPCAOOPAG INTO :V0PARC-SITUACAO , :V0PARC-OPCAOPAG FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :NRCERTIF AND NRPARCEL = :NRPARCEL END-EXEC. */

            var r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1 = new R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
            };

            var executed_1 = R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1.Execute(r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_SITUACAO, V0PARC_SITUACAO);
                _.Move(executed_1.V0PARC_OPCAOPAG, V0PARC_OPCAOPAG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-V0HCONTAVA-DB-UPDATE-2 */
        public void R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2()
        {
            /*" -1044- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET DTVENCTO = :DTVENCTO WHERE NRCERTIF = :NRCERTIF AND NRPARCEL = :NRPARCEL END-EXEC. */

            var r0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2_Update1 = new R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2_Update1()
            {
                DTVENCTO = DTVENCTO.ToString(),
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
            };

            R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2_Update1.Execute(r0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R0320-00-PROCESSA-V0HCONTAVA-DB-SELECT-3 */
        public void R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3()
        {
            /*" -984- EXEC SQL SELECT DATA_CALENDARIO, DIA_SEMANA, FERIADO INTO :CALENDAR-DATA-CALENDARIO, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :DTVENCTO END-EXEC. */

            var r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1 = new R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1()
            {
                DTVENCTO = DTVENCTO.ToString(),
            };

            var executed_1 = R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1.Execute(r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }

        [StopWatch]
        /*" R0320-00-PROCESSA-V0HCONTAVA-DB-UPDATE-3 */
        public void R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3()
        {
            /*" -1095- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '3' , DTVENCTO = :DTVENCTO, NSAS = :PARM-NSA:SQL-NOT-NULL, NSL = :NSL:SQL-NOT-NULL WHERE NRCERTIF = :NRCERTIF AND NRPARCEL = :NRPARCEL AND OCORRHISTCTA = :OCORRHISTCTA END-EXEC. */

            var r0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1 = new R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1()
            {
                PARM_NSA = PARM_NSA.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
                NSL = NSL.ToString(),
                DTVENCTO = DTVENCTO.ToString(),
                OCORRHISTCTA = OCORRHISTCTA.ToString(),
                NRCERTIF = NRCERTIF.ToString(),
                NRPARCEL = NRPARCEL.ToString(),
            };

            R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1.Execute(r0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -1122- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1165- PERFORM R9000_00_FINALIZA_DB_INSERT_1 */

            R9000_00_FINALIZA_DB_INSERT_1();

            /*" -1168- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1169- DISPLAY 'R9000-00 - PROBLEMAS NO INSERT(RELATORI)' */
                _.Display($"R9000-00 - PROBLEMAS NO INSERT(RELATORI)");

                /*" -1175- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1176- ADD 1 TO AC-REGISTROS. */
            WORK_AREA.AC_REGISTROS.Value = WORK_AREA.AC_REGISTROS + 1;

            /*" -1178- MOVE AC-REGISTROS TO MZ-QTDE-REGISTROS WS-DISPLAY-QUANT. */
            _.Move(WORK_AREA.AC_REGISTROS, MOV_TRAILLER.MZ_QTDE_REGISTROS, WORK_AREA.WS_DISPLAY_QUANT);

            /*" -1180- MOVE AC-VALOR TO MZ-TOT-DEB-CRUZ WS-DISPLAY-VALOR. */
            _.Move(WORK_AREA.AC_VALOR, MOV_TRAILLER.MZ_TOT_DEB_CRUZ, WORK_AREA.WS_DISPLAY_VALOR);

            /*" -1181- MOVE PARM-NSA TO WS-DISPLAY-NSA. */
            _.Move(PARM_NSA, WORK_AREA.WS_DISPLAY_NSA);

            /*" -1183- WRITE MOVIMENTO-RECORD FROM MOV-TRAILLER. */
            _.Move(MOV_TRAILLER.GetMoveValues(), MOVIMENTO_RECORD);

            MOVIMENTO.Write(MOVIMENTO_RECORD.GetMoveValues().ToString());

            /*" -1184- DISPLAY '*** VA0340B *** CONVENIO   6088' . */
            _.Display($"*** VA0340B *** CONVENIO   6088");

            /*" -1185- DISPLAY '*** VA0340B *** NSA        ' WS-DISPLAY-NSA. */
            _.Display($"*** VA0340B *** NSA        {WORK_AREA.WS_DISPLAY_NSA}");

            /*" -1186- DISPLAY '*** VA0340B *** QUANTIDADE ' WS-DISPLAY-QUANT. */
            _.Display($"*** VA0340B *** QUANTIDADE {WORK_AREA.WS_DISPLAY_QUANT}");

            /*" -1187- DISPLAY '*** VA0340B *** VALOR      ' WS-DISPLAY-VALOR. */
            _.Display($"*** VA0340B *** VALOR      {WORK_AREA.WS_DISPLAY_VALOR}");

            /*" -1188- DISPLAY ' ' */
            _.Display($" ");

            /*" -1190- DISPLAY 'QTD PARCELAS CESTA SERVICO ' WS-QTD-CESTASERV */
            _.Display($"QTD PARCELAS CESTA SERVICO {WORK_AREA.WS_QTD_CESTASERV}");

            /*" -1194- PERFORM R9000_00_FINALIZA_DB_UPDATE_1 */

            R9000_00_FINALIZA_DB_UPDATE_1();

            /*" -1197- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1198- DISPLAY 'R9000-00 - PROBLEMAS NO UPDATE(CONVSUCOV)' */
                _.Display($"R9000-00 - PROBLEMAS NO UPDATE(CONVSUCOV)");

                /*" -1201- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1202- MOVE AC-REGISTROS TO FITSAS-REG. */
            _.Move(WORK_AREA.AC_REGISTROS, FITSAS_REG);

            /*" -1204- MOVE AC-VALOR TO FITSAS-VALOR. */
            _.Move(WORK_AREA.AC_VALOR, FITSAS_VALOR);

            /*" -1224- PERFORM R9000_00_FINALIZA_DB_INSERT_2 */

            R9000_00_FINALIZA_DB_INSERT_2();

            /*" -1227- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1228- DISPLAY 'R9000-00 - PROBLEMAS NO INSERT(FITA)' */
                _.Display($"R9000-00 - PROBLEMAS NO INSERT(FITA)");

                /*" -1231- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1231- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }

        [StopWatch]
        /*" R9000-00-FINALIZA-DB-INSERT-1 */
        public void R9000_00_FINALIZA_DB_INSERT_1()
        {
            /*" -1165- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0340B' , :SIST-CURRDATE, 'VA' , 'VA0473B' , :PARM-NSA, 0, :SIST-CURRDATE, :SIST-CURRDATE, :SIST-CURRDATE, 0, 0, 0, 0, 0, 0, 0, 0, 97010000889, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r9000_00_FINALIZA_DB_INSERT_1_Insert1 = new R9000_00_FINALIZA_DB_INSERT_1_Insert1()
            {
                SIST_CURRDATE = SIST_CURRDATE.ToString(),
                PARM_NSA = PARM_NSA.ToString(),
            };

            R9000_00_FINALIZA_DB_INSERT_1_Insert1.Execute(r9000_00_FINALIZA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R9000-00-FINALIZA-DB-UPDATE-1 */
        public void R9000_00_FINALIZA_DB_UPDATE_1()
        {
            /*" -1194- EXEC SQL UPDATE SEGUROS.V0CONVSUCOV SET NSA_CONVENIO = :PARM-NSA WHERE COD_CONVENIO = 6088 END-EXEC. */

            var r9000_00_FINALIZA_DB_UPDATE_1_Update1 = new R9000_00_FINALIZA_DB_UPDATE_1_Update1()
            {
                PARM_NSA = PARM_NSA.ToString(),
            };

            R9000_00_FINALIZA_DB_UPDATE_1_Update1.Execute(r9000_00_FINALIZA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-DB-INSERT-2 */
        public void R9000_00_FINALIZA_DB_INSERT_2()
        {
            /*" -1224- EXEC SQL INSERT INTO SEGUROS.V0FITASASSE VALUES (:PARM-CODCONV, :PARM-NSA, :SIST-CURRDATE, :SIST-DTMAXDEB, 'VA0340B' , '1' , 01, :PARM-VERSAO, :FITSAS-REG, :FITSAS-VALOR, 0, :FITSAS-NSL, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var r9000_00_FINALIZA_DB_INSERT_2_Insert1 = new R9000_00_FINALIZA_DB_INSERT_2_Insert1()
            {
                PARM_CODCONV = PARM_CODCONV.ToString(),
                PARM_NSA = PARM_NSA.ToString(),
                SIST_CURRDATE = SIST_CURRDATE.ToString(),
                SIST_DTMAXDEB = SIST_DTMAXDEB.ToString(),
                PARM_VERSAO = PARM_VERSAO.ToString(),
                FITSAS_REG = FITSAS_REG.ToString(),
                FITSAS_VALOR = FITSAS_VALOR.ToString(),
                FITSAS_NSL = FITSAS_NSL.ToString(),
            };

            R9000_00_FINALIZA_DB_INSERT_2_Insert1.Execute(r9000_00_FINALIZA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1246- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1247- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -1248- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -1249- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WORK_AREA.WABEND.WSQLERRMC);

            /*" -1251- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -1251- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1255- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -1257- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1257- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}