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
using Sias.VidaAzul.DB2.VA0458B;

namespace Code
{
    public class VA0458B
    {
        public bool IsCall { get; set; }

        public VA0458B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *     INCLUI REGISTRO NA TABELA RELATORIOS NA COLUNA COD_OPERACAO*      */
        /*"      *     A MENSAGEM (9 - DOENCA PRE EXISTENTE) PARA AS PROPOSTAS    *      */
        /*"      *     PENDENTES COM 15 DIAS DA EMISSAO.                          *      */
        /*"      *     O PROGRAMA VA0469B, QUE FAZ A DEVOLUCAO DA PARCELA PAGA    *      */
        /*"      *     VAI LER ESTE REGISTRO E PROCESSAR.                         *      */
        /*"      *================================================================*      */
        /*"V.27  *  VERSAO 27  - DEMANDA 571.176 - DPS ELETRONICA                 *      */
        /*"      *             - ALTERAR O PRAZO DE SUBSCRICAOO DE 15 DIAS PARA 30*      */
        /*"      *               DIAS PARA RECUSA AUTOMATICA DA PROPOSTA QUANDO   *      */
        /*"      *               DPS ESTIVER COM STATUS DE INCONCLUSIVO           *      */
        /*"      *                                                                *      */
        /*"      *  EM 05/08/2024 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.27        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26  - DEMANDA 525645                                  *      */
        /*"      *              - GRAVA MENSAGEM INFORMATIVA COM MOTIVO DO CANCELA*      */
        /*"      *                MENTO DA PROPOSTA NA TABELA VG_CRITICA_PROPOSTA *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/02/2024 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25  - DEMANDA 495263                                  *      */
        /*"      *              - CONSULTAR PROPOSTAS QUE NAO DEVEM SER DECLINADAS*      */
        /*"      *                NA TABELA RELATORIOS.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/08/2023 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.25         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24  - DEMANDA 402982                                  *      */
        /*"      *              - EXCLUIR CRITICAS CADASTRADAS QUANDO CERTIFICADO *      */
        /*"      *                FOR ALTERADO PARA SITUACAO "NAO ACEITA"         *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/03/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.24         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23  - DEMANDA 338650                                  *      */
        /*"      *              - BLOQUEAR DEVOLUCAO EM DUPLICIDADE.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/09/2022 - FLAVIO BICALHO                               *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22  - DEMANDA 251270                                  *      */
        /*"      *              - REMOVER A VERSAO 21.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/08/2022 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21  - DEMANDA 251270                                  *      */
        /*"      *              - NAO DECLINAR AS PROPOSTAS ABAIXO:               *      */
        /*"      *                80163110041837                                  *      */
        /*"      *                80163110041829                                  *      */
        /*"      *              - HOUVE UM ATRASO NO ENVIO DA CAIXA PARA A SEGURA-*      */
        /*"      *                DORA E ESTES SEGUROS NAO PODEM SER DECLINADOS.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/08/2022 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20  - DEMANDA 251270 / 2019230                        *      */
        /*"      *              - ESTORNO AUTOMATICO PAGAMENTO MESMO VALOR(ADESAO)*      */
        /*"      *                                                                *      */
        /*"      *   EM 01/11/2019 - TERCIO CARVALHO     PROCURE POR V.20         *      */
        /*"      *   EM 28/01/2021 - FRANK CARVALHO (TESTES INTEGRADOS)           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - PROJ. CARTAO CIELO                               *      */
        /*"      *                                                                *      */
        /*"      *       - AJUSTES PARA O DECLINIO DE PROPOSTAS COMERCIALIZADAS   *      */
        /*"      *         VIA CARTAO DE CREDITO. A PRINCIPIO NESTA DATA, O ESTOR-*      */
        /*"      *         NO SERA REALIZADO MANUALMENTE, COM ISSO E INSERIDO NA  *      */
        /*"      *         TABELA RELATORIOS O CODIGO VA0972B, ONDE SERA GERADO UM*      */
        /*"      *         RELATORIO COM AS PROPOSTAS DECLINADAS PARA REALIZAR O  *      */
        /*"      *         ESTORNO MANUAL.                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/07/2019 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - CAD 155.388                                      *      */
        /*"      *                                                                *      */
        /*"      *       - DECLINAR AS PROPOSTAS SETADAS COM ACATAR = 'N' NO ATA- *      */
        /*"      *         LHO 04-19-01-01 (VANEA) NO MESMO DIA. NAO AGUARDAR OS  *      */
        /*"      *         15o DIA COMO ATUALMENTE.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/12/2017 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 - CAD 153.538                                      *      */
        /*"      *                                                                *      */
        /*"      *       - RECUPERAR A DATA DO RCAP AO INVES DA DATA DE CADASTRA- *      */
        /*"      *         MENTO. (RCAP_COMPLEMENTAR)                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/08/2017 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - CAD 142715 - ABEND                               *      */
        /*"      *                                                                *      */
        /*"      *       - QUANDO EXISTIR PAGAMENTO LEVAR EM CONSIDERACAO A       *      */
        /*"      *         DATA DO PAGAMENTO (RCAPS).                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/06/2017 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - CAD 129035 - ABEND                               *      */
        /*"      *                                                                *      */
        /*"      *       - AJUSTE DO CALCULO DO VALOR PAGO NO RETORNO DA PROPOSTA *      */
        /*"      *         FIDELIZ E ZERAR VARIAVEIS DO INSERT NA RELATORIOS.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/02/2016 - LUIGI CONTE                                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - CAD 124038                                       *      */
        /*"      *                                                                *      */
        /*"      *       - VALOR DO PREMIO NAO DEVOLVIDO QUANDO PROPOSTA E        *      */
        /*"      *         DECLINADA. OPCAO DE PAGAMENTO E BOLETO, MAS SE O       *      */
        /*"      *         CERTIFICADO TIVER CONTA CAIXA INFORMADA, INFORMAR      *      */
        /*"      *         OS DADOS DA CONTA NO REGISTRO DA RELATORIOS PARA       *      */
        /*"      *         QUE O VA0469B EFETUE A DEVOLUCAO DA PARCELA ADESAO.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/11/2015 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - CAD 122623                                       *      */
        /*"      *                                                                *      */
        /*"      *       - A DATA DE DECLINIO NãO PODE SER ALTERADA.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/09/2015 - ROGERIO LAMAS DE LIMA                        *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 105.276                                      *      */
        /*"      *                                                                *      */
        /*"      *       - GUARDAR DATA DE DECLINIO NA PROPOSTAS_VA               *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/12/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 82.411                                       *      */
        /*"      *                                                                *      */
        /*"      *       - ENVIO DE CARTA DE DECLINIO PARA OS PRODUTOS EXCLUSIVO  *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/06/2013 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 64.866                                       *      */
        /*"      *                                                                *      */
        /*"      *       - RETIRAR OS PRODUTOS PRESTAMISTA DO CURSOR PRINCIPAL    *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/12/2011 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 50.348                                       *      */
        /*"      *                                                                *      */
        /*"      *       - SUBSTITUIR A DATA '0001-01-01' PELA DATA  '1900-01-01' *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2010 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 30.835                                       *      */
        /*"      *                                                                *      */
        /*"      *             - AO ATUALIZAR A SITUACAO, ATUALIZAR TAMBEM OS CAM-*      */
        /*"      *             POS DATA_MOVIMENTO E TIMESTAMP.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/10/2009 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 15/12/2008 - FAST COMPUTER       CAD 18.573               *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - AJUSTE NOS CANELAMENTOS PARA SABADOS,            *      */
        /*"      *               DOMINGOS E FERIADOS.                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 08/12/2008 - FAST COMPUTER       CAD 18.452               *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - GEROU ABEND NO VA0469B POR TER LIBERADO          *      */
        /*"      *               PROPOSTAS MUITO ANTIGAS. VOLTA A SOLICITAR       *      */
        /*"      *               O CANCELAMENTO COM DATA IGUAL.                   *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 08/12/2008 - FAST COMPUTER       CAD 18.155               *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - PASSOU A TRATAR PROPOSTAS COM DATA MAIOR OU      *      */
        /*"      *               IGUAL A 15 DIAS.                                 *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 19/04/2008 - FAST COMPUTER       CAD 9.548  E CAD 8.550   *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - PASSOU A ANTECIPAR CANCELAMENTO DE PROPOSTAS PEN-*      */
        /*"      *               DENTES QUE SERIAM CANCELADAS NOS PROXIMOS DIAS,  *      */
        /*"      *               DESDE QUE ESTES NAO SEJAM DIAS UTEIS.            *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 03 - PASSOU A CANCELAR NAS SEXTAS-FEIRAS AS PROPOS-   *      */
        /*"      *               TAS PENDENTES QUE SERIAM CANCELADAS NO SABADO OU *      */
        /*"      *               DOMINGO SEGUINTE.       SSI 19.838                      */
        /*"      *                                                                *      */
        /*"      *   EM 20/02/2008 - FAST COMPUTER            PROCURE POR V.03    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - PASSOU A CANCELAR TODAS AS PROPOSTAS PENDENTES   *      */
        /*"      *               INDEPENDENTE DOS ERROS APRESENTADOS.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/09/2006 - FAST COMPUTER            PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSOU A NAO MAIS GERAR ERROS_PROP_VIDAZUL       *      */
        /*"      *               PELO FATO DA NAO ACEITACAO SER PELOS ERROS       *      */
        /*"      *               1803 OU 1804 .                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/09/2006 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77            WHOST-DATARCAP      PIC  X(10).*/
        public StringBasis WHOST_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-SITUACAO      PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            WS-MSG-INFORMATIVA  PIC  X(70).*/
        public StringBasis WS_MSG_INFORMATIVA { get; set; } = new StringBasis(new PIC("X", "70", "X(70)."), @"");
        /*"77            WS-QTD-PENDENTES    PIC S9(09) USAGE COMP.*/
        public IntBasis WS_QTD_PENDENTES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WS-QTD-ERRO-VANEA   PIC S9(09) USAGE COMP.*/
        public IntBasis WS_QTD_ERRO_VANEA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WS-STA-INCONCLUSIVO PIC S9(04) USAGE COMP.*/
        public IntBasis WS_STA_INCONCLUSIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-NRRCAP        PIC S9(09) USAGE COMP.*/
        public IntBasis WHOST_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WHOST-NRCERTIF      PIC S9(15) COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            WHOST-QTDIAS        PIC S9(09) COMP.*/
        public IntBasis WHOST_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WHOST-NUMTIT        PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-APOLICE       PIC S9(13) COMP-3.*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-CODSUBES      PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-COD-ESCNEG    PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-DT-CALENDARIO PIC  X(10).*/
        public StringBasis WHOST_DT_CALENDARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTINICIAL     PIC  X(10).*/
        public StringBasis WHOST_DTINICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL-01    PIC  X(10).*/
        public StringBasis WHOST_DTFINAL_01 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL-02    PIC  X(10).*/
        public StringBasis WHOST_DTFINAL_02 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL-03    PIC  X(10).*/
        public StringBasis WHOST_DTFINAL_03 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL-04    PIC  X(10).*/
        public StringBasis WHOST_DTFINAL_04 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL-05    PIC  X(10).*/
        public StringBasis WHOST_DTFINAL_05 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL-06    PIC  X(10).*/
        public StringBasis WHOST_DTFINAL_06 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-ERROS         PIC S9(04) COMP.*/
        public IntBasis WHOST_ERROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-ACOMP         PIC S9(04) COMP.*/
        public IntBasis WHOST_ACOMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-DTA-DECLINIO  PIC  X(10).*/
        public StringBasis WHOST_DTA_DECLINIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            VIND-DPS-TITULAR    PIC S9(04) COMP.*/
        public IntBasis VIND_DPS_TITULAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-DPS-CONJUGE    PIC S9(04) COMP.*/
        public IntBasis VIND_DPS_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-ORIG-PRODU     PIC S9(04) COMP.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-DTA-DECLINIO   PIC S9(04) COMP.*/
        public IntBasis VIND_DTA_DECLINIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-ACATAMENTO     PIC S9(04) COMP.*/
        public IntBasis VIND_ACATAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-ORIG-PRODU    PIC  X(010).*/
        public StringBasis WHOST_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WHOST-COD-RELAT     PIC  X(008).*/
        public StringBasis WHOST_COD_RELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            WHOST-NUM-COPIAS    PIC S9(004) USAGE COMP.*/
        public IntBasis WHOST_NUM_COPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-BCO-RELAT     PIC S9(4) USAGE COMP.*/
        public IntBasis WHOST_BCO_RELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77            WHOST-VLR-RELAT     PIC S9(10)V9(5) USAGE COMP-3.*/
        public DoubleBasis WHOST_VLR_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77            WHOST-SIN-RELAT     PIC S9(15)V USAGE COMP-3                                              VALUE +0.*/
        public DoubleBasis WHOST_SIN_RELAT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77            WHOST-SEM-DECLINIO  PIC  X(003) VALUE 'NAO'.*/
        public StringBasis WHOST_SEM_DECLINIO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77         V0RELA-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NRTIT        PIC S9(013) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RELA-DTVENCTO     PIC  X(010).*/
        public StringBasis V0RELA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-CODRELAT     PIC  X(010).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-1   PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-2   PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-3   PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-4   PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-10  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-11  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-12  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-13  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-14  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-30  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0CONT-DATCEF       PIC  X(10).*/
        public StringBasis V0CONT_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-AGECOBR      PIC S9(04)    COMP.*/
        public IntBasis V0PROP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-VLPREMIO     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PROP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PROP-IMPSEGUR     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PROP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PROP-SITUACAO     PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V0PROP-APOLICE      PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0PROP-CODSUBES     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-CODPRODU     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-NRCERTIF     PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0PROP-CODUSU       PIC  X(08).*/
        public StringBasis V0PROP_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77            V0PROP-CODCLIEN     PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PROP-OCOREND      PIC S9(04)    COMP.*/
        public IntBasis V0PROP_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-DTQITBCO     PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-DTQITBCO15   PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO15 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-DPS-TITULAR  PIC  X(25).*/
        public StringBasis V0PROP_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"77            V0PROP-DPS-CONJUGE  PIC  X(25).*/
        public StringBasis V0PROP_DPS_CONJUGE { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"77            V0PROP-DTA-DECLINIO PIC  X(10).*/
        public StringBasis V0PROP_DTA_DECLINIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-ACATAMENTO   PIC  X(01).*/
        public StringBasis V0PROP_ACATAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V0ERROSP-DESCR-ERRO PIC X(40).*/
        public StringBasis V0ERROSP_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            PF-NUM-PROP-SIVPF     PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF_NUM_PROP_SIVPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77            PF-OPCAOPAG           PIC X(1).*/
        public StringBasis PF_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77            PF-AGECTADEB          PIC S9(4)   USAGE COMP.*/
        public IntBasis PF_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77            PF-OPRCTADEB          PIC S9(4)   USAGE COMP.*/
        public IntBasis PF_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77            PF-NUMCTADEB          PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PF_NUMCTADEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77            PF-DIGCTADEB          PIC S9(4)   USAGE COMP.*/
        public IntBasis PF_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77            PF-VAL-PAGO           PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis PF_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77            CONV-NUM-SICOB      PIC S9(15)    COMP-3.*/
        public IntBasis CONV_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            CONV-NUMTIT         PIC S9(13)    COMP-3.*/
        public IntBasis CONV_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0ERROSP-DESCR-ERRO PIC X(40).*/
        public StringBasis V0ERROSP_DESCR_ERRO_0 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            OPCPAGVI-OPC-PAGTO  PIC X(01).*/
        public StringBasis OPCPAGVI_OPC_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WORK-AREA.*/
        public VA0458B_WORK_AREA WORK_AREA { get; set; } = new VA0458B_WORK_AREA();
        public class VA0458B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public VA0458B_DATA_SQL DATA_SQL { get; set; } = new VA0458B_DATA_SQL();
            public class VA0458B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        IND                 PIC  9(005) VALUE ZEROS.*/
            }
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WFIM-PROPOSTAS-VA   PIC  X(01)  VALUE  ' '.*/
            public StringBasis WFIM_PROPOSTAS_VA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-V0ERROSPROP    PIC   X(03)  VALUE  ' '.*/
            public StringBasis WFIM_V0ERROSPROP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-CALENDAR       PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_CALENDAR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WTEM-FIDELIZ        PIC   X(01)  VALUE  ' '.*/
            public StringBasis WTEM_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESPR-PROPOVA    PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_PROPOVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESPR-RELATORIOS PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_RELATORIOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESPR-RCAPS      PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_RCAPS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESPR-DATA       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_DATA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        UP-PROPOVA          PIC  9(006) VALUE ZEROS.*/
            public IntBasis UP_PROPOVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        UP-PROPOVA-ATV      PIC  9(006) VALUE ZEROS.*/
            public IntBasis UP_PROPOVA_ATV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        UP-DECLINADO-PGTO   PIC  9(006) VALUE ZEROS.*/
            public IntBasis UP_DECLINADO_PGTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        UP-DECLINADO-NTRAT  PIC  9(006) VALUE ZEROS.*/
            public IntBasis UP_DECLINADO_NTRAT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-SELEC            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_SELEC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-GRAVA            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DUPLICA          PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DUPLICA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DIAS-ANTECIPACAO PIC  S9(04) USAGE COMP.*/
            public IntBasis AC_DIAS_ANTECIPACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05        WABEND.*/
            public VA0458B_WABEND WABEND { get; set; } = new VA0458B_WABEND();
            public class VA0458B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA0458B'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0458B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.FERIADOS FERIADOS { get; set; } = new Dclgens.FERIADOS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public VA0458B_TCOMIS TCOMIS { get; set; } = new VA0458B_TCOMIS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -477- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -480- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -484- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -486- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -493- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -494- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -495- DISPLAY ' PROGRAMA EM EXECUCAO VA0458B ' */
            _.Display($" PROGRAMA EM EXECUCAO VA0458B ");

            /*" -496- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -497- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -514- DISPLAY 'VERSAO V.27 571.176 05/08/2024' */
            _.Display($"VERSAO V.27 571.176 05/08/2024");

            /*" -515- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -520- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -522- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -523- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -524- DISPLAY '*** PROBLEMAS NA V0SISTEMA' */
                _.Display($"*** PROBLEMAS NA V0SISTEMA");

                /*" -525- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -527- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -529- PERFORM R0200-00-DEFINE-ANTECIPACAO. */

            R0200_00_DEFINE_ANTECIPACAO_SECTION();

            /*" -531- PERFORM R0900-00-DECLARE-PROPOSTAS-VA. */

            R0900_00_DECLARE_PROPOSTAS_VA_SECTION();

            /*" -533- PERFORM R0910-00-FETCH-PROPOSTAS-VA. */

            R0910_00_FETCH_PROPOSTAS_VA_SECTION();

            /*" -534- IF WFIM-PROPOSTAS-VA EQUAL 'S' */

            if (WORK_AREA.WFIM_PROPOSTAS_VA == "S")
            {

                /*" -535- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -536- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -538- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -539- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-PROPOSTAS-VA EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_PROPOSTAS_VA == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -545- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -545- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -548- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -549- DISPLAY '---------------*** VA0458B ***----------------' */
            _.Display($"---------------*** VA0458B ***----------------");

            /*" -550- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -551- DISPLAY 'LIDOS PROPOVA             ' AC-LIDOS */
            _.Display($"LIDOS PROPOVA             {WORK_AREA.AC_LIDOS}");

            /*" -552- DISPLAY 'SELECIONADOS PROPOVA      ' AC-SELEC */
            _.Display($"SELECIONADOS PROPOVA      {WORK_AREA.AC_SELEC}");

            /*" -553- DISPLAY 'DESPREZADOS  PROPOVA      ' AC-DESPR-PROPOVA */
            _.Display($"DESPREZADOS  PROPOVA      {WORK_AREA.AC_DESPR_PROPOVA}");

            /*" -554- DISPLAY 'DESPREZADOS  RELATORIOS   ' AC-DESPR-RELATORIOS */
            _.Display($"DESPREZADOS  RELATORIOS   {WORK_AREA.AC_DESPR_RELATORIOS}");

            /*" -555- DISPLAY 'DESPREZADOS  RCAPS        ' AC-DESPR-RCAPS */
            _.Display($"DESPREZADOS  RCAPS        {WORK_AREA.AC_DESPR_RCAPS}");

            /*" -556- DISPLAY 'GRAVADOS RELATORIOS       ' AC-GRAVA. */
            _.Display($"GRAVADOS RELATORIOS       {WORK_AREA.AC_GRAVA}");

            /*" -557- DISPLAY 'DUPLICADOS RELATORIOS     ' AC-DUPLICA. */
            _.Display($"DUPLICADOS RELATORIOS     {WORK_AREA.AC_DUPLICA}");

            /*" -558- DISPLAY 'DESPREZA DATA             ' AC-DESPR-DATA */
            _.Display($"DESPREZA DATA             {WORK_AREA.AC_DESPR_DATA}");

            /*" -559- DISPLAY 'ALTERADOS PROPOVA         ' UP-PROPOVA. */
            _.Display($"ALTERADOS PROPOVA         {WORK_AREA.UP_PROPOVA}");

            /*" -560- DISPLAY 'ATIVAR PROPOSTA P/EMISSAO ' UP-PROPOVA-ATV. */
            _.Display($"ATIVAR PROPOSTA P/EMISSAO {WORK_AREA.UP_PROPOVA_ATV}");

            /*" -561- DISPLAY 'DECL. POR FALTA TRATAMENTO' UP-DECLINADO-NTRAT. */
            _.Display($"DECL. POR FALTA TRATAMENTO{WORK_AREA.UP_DECLINADO_NTRAT}");

            /*" -563- DISPLAY 'DECL. POR FATAL DE PGMTO  ' UP-DECLINADO-PGTO. */
            _.Display($"DECL. POR FATAL DE PGMTO  {WORK_AREA.UP_DECLINADO_PGTO}");

            /*" -565- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -567- DISPLAY '*** VA0458B - TERMINO NORMAL ***' */
            _.Display($"*** VA0458B - TERMINO NORMAL ***");

            /*" -567- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -581- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -606- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -609- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -610- DISPLAY 'VA0458B - SISTEMA VA NAO ESTA CADASTRADO' */
                _.Display($"VA0458B - SISTEMA VA NAO ESTA CADASTRADO");

                /*" -611- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                /*" -613- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -615- MOVE V1SIST-DTMOVABE TO DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, WORK_AREA.DATA_SQL);

            /*" -615- DISPLAY 'V1SIST-DTMOVABE    ' V1SIST-DTMOVABE. */
            _.Display($"V1SIST-DTMOVABE    {V1SIST_DTMOVABE}");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -606- EXEC SQL SELECT DTMOVABE, DTMOVABE + 1 DAYS , DTMOVABE + 2 DAYS , DTMOVABE + 3 DAYS , DTMOVABE + 4 DAYS , DTMOVABE - 10 DAYS , DTMOVABE - 11 DAYS , DTMOVABE - 12 DAYS , DTMOVABE - 13 DAYS , DTMOVABE - 14 DAYS , DTMOVABE - 30 DAYS INTO :V1SIST-DTMOVABE , :V1SIST-DTMOVABE-1, :V1SIST-DTMOVABE-2, :V1SIST-DTMOVABE-3, :V1SIST-DTMOVABE-4, :V1SIST-DTMOVABE-10, :V1SIST-DTMOVABE-11, :V1SIST-DTMOVABE-12, :V1SIST-DTMOVABE-13, :V1SIST-DTMOVABE-14, :V1SIST-DTMOVABE-30 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTMOVABE_1, V1SIST_DTMOVABE_1);
                _.Move(executed_1.V1SIST_DTMOVABE_2, V1SIST_DTMOVABE_2);
                _.Move(executed_1.V1SIST_DTMOVABE_3, V1SIST_DTMOVABE_3);
                _.Move(executed_1.V1SIST_DTMOVABE_4, V1SIST_DTMOVABE_4);
                _.Move(executed_1.V1SIST_DTMOVABE_10, V1SIST_DTMOVABE_10);
                _.Move(executed_1.V1SIST_DTMOVABE_11, V1SIST_DTMOVABE_11);
                _.Move(executed_1.V1SIST_DTMOVABE_12, V1SIST_DTMOVABE_12);
                _.Move(executed_1.V1SIST_DTMOVABE_13, V1SIST_DTMOVABE_13);
                _.Move(executed_1.V1SIST_DTMOVABE_14, V1SIST_DTMOVABE_14);
                _.Move(executed_1.V1SIST_DTMOVABE_30, V1SIST_DTMOVABE_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DEFINE-ANTECIPACAO-SECTION */
        private void R0200_00_DEFINE_ANTECIPACAO_SECTION()
        {
            /*" -629- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -630- MOVE V1SIST-DTMOVABE-1 TO WHOST-DT-CALENDARIO */
            _.Move(V1SIST_DTMOVABE_1, WHOST_DT_CALENDARIO);

            /*" -631- PERFORM R0300-00-SELECT-CALENDARIO. */

            R0300_00_SELECT_CALENDARIO_SECTION();

            /*" -632- PERFORM R0310-00-SELECT-FERIADO */

            R0310_00_SELECT_FERIADO_SECTION();

            /*" -634- IF CALENDAR-FERIADO EQUAL 'N' OR CALENDAR-DIA-SEMANA EQUAL 'S' OR 'D' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA.In("S", "D"))
            {

                /*" -636- MOVE 1 TO AC-DIAS-ANTECIPACAO */
                _.Move(1, WORK_AREA.AC_DIAS_ANTECIPACAO);

                /*" -638- MOVE V1SIST-DTMOVABE-2 TO WHOST-DT-CALENDARIO */
                _.Move(V1SIST_DTMOVABE_2, WHOST_DT_CALENDARIO);

                /*" -639- PERFORM R0300-00-SELECT-CALENDARIO */

                R0300_00_SELECT_CALENDARIO_SECTION();

                /*" -640- PERFORM R0310-00-SELECT-FERIADO */

                R0310_00_SELECT_FERIADO_SECTION();

                /*" -642- IF CALENDAR-FERIADO EQUAL 'N' OR CALENDAR-DIA-SEMANA EQUAL 'S' OR 'D' */

                if (CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA.In("S", "D"))
                {

                    /*" -644- ADD 1 TO AC-DIAS-ANTECIPACAO */
                    WORK_AREA.AC_DIAS_ANTECIPACAO.Value = WORK_AREA.AC_DIAS_ANTECIPACAO + 1;

                    /*" -646- MOVE V1SIST-DTMOVABE-3 TO WHOST-DT-CALENDARIO */
                    _.Move(V1SIST_DTMOVABE_3, WHOST_DT_CALENDARIO);

                    /*" -647- PERFORM R0300-00-SELECT-CALENDARIO */

                    R0300_00_SELECT_CALENDARIO_SECTION();

                    /*" -648- PERFORM R0310-00-SELECT-FERIADO */

                    R0310_00_SELECT_FERIADO_SECTION();

                    /*" -650- IF CALENDAR-FERIADO EQUAL 'N' OR CALENDAR-DIA-SEMANA EQUAL 'S' OR 'D' */

                    if (CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA.In("S", "D"))
                    {

                        /*" -652- ADD 1 TO AC-DIAS-ANTECIPACAO */
                        WORK_AREA.AC_DIAS_ANTECIPACAO.Value = WORK_AREA.AC_DIAS_ANTECIPACAO + 1;

                        /*" -654- MOVE V1SIST-DTMOVABE-4 TO WHOST-DT-CALENDARIO */
                        _.Move(V1SIST_DTMOVABE_4, WHOST_DT_CALENDARIO);

                        /*" -655- PERFORM R0300-00-SELECT-CALENDARIO */

                        R0300_00_SELECT_CALENDARIO_SECTION();

                        /*" -656- PERFORM R0310-00-SELECT-FERIADO */

                        R0310_00_SELECT_FERIADO_SECTION();

                        /*" -658- IF CALENDAR-FERIADO EQUAL 'N' OR CALENDAR-DIA-SEMANA EQUAL 'S' OR 'D' */

                        if (CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA.In("S", "D"))
                        {

                            /*" -660- ADD 1 TO AC-DIAS-ANTECIPACAO */
                            WORK_AREA.AC_DIAS_ANTECIPACAO.Value = WORK_AREA.AC_DIAS_ANTECIPACAO + 1;

                            /*" -661- END-IF */
                        }


                        /*" -662- END-IF */
                    }


                    /*" -663- END-IF */
                }


                /*" -666- END-IF. */
            }


            /*" -673- MOVE '1900-01-01' TO WHOST-DTFINAL-01 WHOST-DTFINAL-02 WHOST-DTFINAL-03 WHOST-DTFINAL-04 WHOST-DTFINAL-05 */
            _.Move("1900-01-01", WHOST_DTFINAL_01, WHOST_DTFINAL_02, WHOST_DTFINAL_03, WHOST_DTFINAL_04, WHOST_DTFINAL_05);

            /*" -674- IF AC-DIAS-ANTECIPACAO EQUAL ZEROS */

            if (WORK_AREA.AC_DIAS_ANTECIPACAO == 00)
            {

                /*" -676- MOVE V1SIST-DTMOVABE-14 TO WHOST-DTFINAL-01 */
                _.Move(V1SIST_DTMOVABE_14, WHOST_DTFINAL_01);

                /*" -678- END-IF. */
            }


            /*" -679- IF AC-DIAS-ANTECIPACAO EQUAL 1 */

            if (WORK_AREA.AC_DIAS_ANTECIPACAO == 1)
            {

                /*" -681- MOVE V1SIST-DTMOVABE-14 TO WHOST-DTFINAL-01 */
                _.Move(V1SIST_DTMOVABE_14, WHOST_DTFINAL_01);

                /*" -683- MOVE V1SIST-DTMOVABE-13 TO WHOST-DTFINAL-02 */
                _.Move(V1SIST_DTMOVABE_13, WHOST_DTFINAL_02);

                /*" -685- END-IF. */
            }


            /*" -686- IF AC-DIAS-ANTECIPACAO EQUAL 2 */

            if (WORK_AREA.AC_DIAS_ANTECIPACAO == 2)
            {

                /*" -688- MOVE V1SIST-DTMOVABE-14 TO WHOST-DTFINAL-01 */
                _.Move(V1SIST_DTMOVABE_14, WHOST_DTFINAL_01);

                /*" -690- MOVE V1SIST-DTMOVABE-13 TO WHOST-DTFINAL-02 */
                _.Move(V1SIST_DTMOVABE_13, WHOST_DTFINAL_02);

                /*" -692- MOVE V1SIST-DTMOVABE-12 TO WHOST-DTFINAL-03 */
                _.Move(V1SIST_DTMOVABE_12, WHOST_DTFINAL_03);

                /*" -694- END-IF. */
            }


            /*" -695- IF AC-DIAS-ANTECIPACAO EQUAL 3 */

            if (WORK_AREA.AC_DIAS_ANTECIPACAO == 3)
            {

                /*" -697- MOVE V1SIST-DTMOVABE-14 TO WHOST-DTFINAL-01 */
                _.Move(V1SIST_DTMOVABE_14, WHOST_DTFINAL_01);

                /*" -699- MOVE V1SIST-DTMOVABE-13 TO WHOST-DTFINAL-02 */
                _.Move(V1SIST_DTMOVABE_13, WHOST_DTFINAL_02);

                /*" -701- MOVE V1SIST-DTMOVABE-12 TO WHOST-DTFINAL-03 */
                _.Move(V1SIST_DTMOVABE_12, WHOST_DTFINAL_03);

                /*" -703- MOVE V1SIST-DTMOVABE-11 TO WHOST-DTFINAL-04 */
                _.Move(V1SIST_DTMOVABE_11, WHOST_DTFINAL_04);

                /*" -705- END-IF. */
            }


            /*" -706- IF AC-DIAS-ANTECIPACAO EQUAL 4 */

            if (WORK_AREA.AC_DIAS_ANTECIPACAO == 4)
            {

                /*" -708- MOVE V1SIST-DTMOVABE-14 TO WHOST-DTFINAL-01 */
                _.Move(V1SIST_DTMOVABE_14, WHOST_DTFINAL_01);

                /*" -710- MOVE V1SIST-DTMOVABE-13 TO WHOST-DTFINAL-02 */
                _.Move(V1SIST_DTMOVABE_13, WHOST_DTFINAL_02);

                /*" -712- MOVE V1SIST-DTMOVABE-12 TO WHOST-DTFINAL-03 */
                _.Move(V1SIST_DTMOVABE_12, WHOST_DTFINAL_03);

                /*" -714- MOVE V1SIST-DTMOVABE-11 TO WHOST-DTFINAL-04 */
                _.Move(V1SIST_DTMOVABE_11, WHOST_DTFINAL_04);

                /*" -716- MOVE V1SIST-DTMOVABE-10 TO WHOST-DTFINAL-05 */
                _.Move(V1SIST_DTMOVABE_10, WHOST_DTFINAL_05);

                /*" -718- END-IF. */
            }


            /*" -720- PERFORM R3210-00-CALCULA-DT-FINAL */

            R3210_00_CALCULA_DT_FINAL_SECTION();

            /*" -728- DISPLAY 'VA0458B - DATAS LIMITE ' ' ' WHOST-DTFINAL-01 ' ' WHOST-DTFINAL-02 ' ' WHOST-DTFINAL-03 ' ' WHOST-DTFINAL-04 ' ' WHOST-DTFINAL-05 ' ' WHOST-DTFINAL-06. */

            $"VA0458B - DATAS LIMITE  {WHOST_DTFINAL_01} {WHOST_DTFINAL_02} {WHOST_DTFINAL_03} {WHOST_DTFINAL_04} {WHOST_DTFINAL_05} {WHOST_DTFINAL_06}"
            .Display();

            /*" -734- DISPLAY '          DECLINA DTQITBCO <= A ' WHOST-DTFINAL-01 ' OU ' WHOST-DTFINAL-02 ' OU ' WHOST-DTFINAL-03 ' OU ' WHOST-DTFINAL-04 ' OU ' WHOST-DTFINAL-05 ' OU ' WHOST-DTFINAL-06. */

            $"          DECLINA DTQITBCO <= A {WHOST_DTFINAL_01} OU {WHOST_DTFINAL_02} OU {WHOST_DTFINAL_03} OU {WHOST_DTFINAL_04} OU {WHOST_DTFINAL_05} OU {WHOST_DTFINAL_06}"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECT-CALENDARIO-SECTION */
        private void R0300_00_SELECT_CALENDARIO_SECTION()
        {
            /*" -748- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -755- PERFORM R0300_00_SELECT_CALENDARIO_DB_SELECT_1 */

            R0300_00_SELECT_CALENDARIO_DB_SELECT_1();

            /*" -758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -759- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -761- DISPLAY 'VA0458B - DATA NAO ESTA CADASTRADA ' WHOST-DT-CALENDARIO */
                    _.Display($"VA0458B - DATA NAO ESTA CADASTRADA {WHOST_DT_CALENDARIO}");

                    /*" -762- ELSE */
                }
                else
                {


                    /*" -764- DISPLAY '*** PROBLEMAS NA CALENDARIO ' WHOST-DT-CALENDARIO */
                    _.Display($"*** PROBLEMAS NA CALENDARIO {WHOST_DT_CALENDARIO}");

                    /*" -765- END-IF */
                }


                /*" -766- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -766- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-SELECT-CALENDARIO-DB-SELECT-1 */
        public void R0300_00_SELECT_CALENDARIO_DB_SELECT_1()
        {
            /*" -755- EXEC SQL SELECT DIA_SEMANA, FERIADO INTO :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-DT-CALENDARIO END-EXEC. */

            var r0300_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 = new R0300_00_SELECT_CALENDARIO_DB_SELECT_1_Query1()
            {
                WHOST_DT_CALENDARIO = WHOST_DT_CALENDARIO.ToString(),
            };

            var executed_1 = R0300_00_SELECT_CALENDARIO_DB_SELECT_1_Query1.Execute(r0300_00_SELECT_CALENDARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-SELECT-FERIADO-SECTION */
        private void R0310_00_SELECT_FERIADO_SECTION()
        {
            /*" -780- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -785- PERFORM R0310_00_SELECT_FERIADO_DB_SELECT_1 */

            R0310_00_SELECT_FERIADO_DB_SELECT_1();

            /*" -788- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -789- MOVE 'N' TO CALENDAR-FERIADO */
                _.Move("N", CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);

                /*" -790- ELSE */
            }
            else
            {


                /*" -791- MOVE ' ' TO CALENDAR-FERIADO */
                _.Move(" ", CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);

                /*" -791- END-IF. */
            }


        }

        [StopWatch]
        /*" R0310-00-SELECT-FERIADO-DB-SELECT-1 */
        public void R0310_00_SELECT_FERIADO_DB_SELECT_1()
        {
            /*" -785- EXEC SQL SELECT DATA_FERIADO INTO :FERIADOS-DATA-FERIADO FROM SEGUROS.FERIADOS WHERE DATA_FERIADO = :WHOST-DT-CALENDARIO END-EXEC. */

            var r0310_00_SELECT_FERIADO_DB_SELECT_1_Query1 = new R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1()
            {
                WHOST_DT_CALENDARIO = WHOST_DT_CALENDARIO.ToString(),
            };

            var executed_1 = R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1.Execute(r0310_00_SELECT_FERIADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FERIADOS_DATA_FERIADO, FERIADOS.DCLFERIADOS.FERIADOS_DATA_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTAS-VA-SECTION */
        private void R0900_00_DECLARE_PROPOSTAS_VA_SECTION()
        {
            /*" -805- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -829- PERFORM R0900_00_DECLARE_PROPOSTAS_VA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTAS_VA_DB_DECLARE_1();

            /*" -831- PERFORM R0900_00_DECLARE_PROPOSTAS_VA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTAS_VA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTAS-VA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTAS_VA_DB_DECLARE_1()
        {
            /*" -829- EXEC SQL DECLARE TCOMIS CURSOR FOR SELECT B.NUM_APOLICE, B.CODSUBES, B.NRCERTIF, B.DTQITBCO, B.DTQITBCO + 14 DAYS, B.SITUACAO, B.DPS_TITULAR, B.DPS_ESPOSA, B.DTA_DECLINIO, B.ACATAMENTO, A.ORIG_PRODU, B.CODPRODU FROM SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0COBERPROPVA C WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.SITUACAO IN ( '1' , '9' , 'E' ) AND B.CODPRODU NOT BETWEEN 7700 AND 7799 AND C.OCORHIST = B.OCORHIST AND C.NRCERTIF = B.NRCERTIF WITH UR END-EXEC. */
            TCOMIS = new VA0458B_TCOMIS(false);
            string GetQuery_TCOMIS()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.NRCERTIF
							, 
							B.DTQITBCO
							, 
							B.DTQITBCO + 14 DAYS
							, 
							B.SITUACAO
							, 
							B.DPS_TITULAR
							, 
							B.DPS_ESPOSA
							, 
							B.DTA_DECLINIO
							, 
							B.ACATAMENTO
							, 
							A.ORIG_PRODU
							, 
							B.CODPRODU 
							FROM SEGUROS.V0PRODUTOSVG A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0COBERPROPVA C 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.SITUACAO IN ( '1'
							, '9'
							, 'E' ) 
							AND B.CODPRODU NOT BETWEEN 7700 AND 7799 
							AND C.OCORHIST = B.OCORHIST 
							AND C.NRCERTIF = B.NRCERTIF";

                return query;
            }
            TCOMIS.GetQueryEvent += GetQuery_TCOMIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTAS-VA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTAS_VA_DB_OPEN_1()
        {
            /*" -831- EXEC SQL OPEN TCOMIS END-EXEC. */

            TCOMIS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTAS-VA-SECTION */
        private void R0910_00_FETCH_PROPOSTAS_VA_SECTION()
        {
            /*" -845- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -859- PERFORM R0910_00_FETCH_PROPOSTAS_VA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOSTAS_VA_DB_FETCH_1();

            /*" -862- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -863- MOVE 'S' TO WFIM-PROPOSTAS-VA */
                _.Move("S", WORK_AREA.WFIM_PROPOSTAS_VA);

                /*" -863- PERFORM R0910_00_FETCH_PROPOSTAS_VA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOSTAS_VA_DB_CLOSE_1();

                /*" -865- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -867- END-IF */
            }


            /*" -868- IF VIND-ORIG-PRODU < 0 */

            if (VIND_ORIG_PRODU < 0)
            {

                /*" -869- MOVE SPACES TO WHOST-ORIG-PRODU */
                _.Move("", WHOST_ORIG_PRODU);

                /*" -871- END-IF */
            }


            /*" -872- IF VIND-ACATAMENTO LESS ZEROS */

            if (VIND_ACATAMENTO < 00)
            {

                /*" -873- MOVE SPACES TO V0PROP-ACATAMENTO */
                _.Move("", V0PROP_ACATAMENTO);

                /*" -885- END-IF */
            }


            /*" -890- IF V0PROP-DTQITBCO <= WHOST-DTFINAL-01 OR V0PROP-DTQITBCO <= WHOST-DTFINAL-02 OR V0PROP-DTQITBCO <= WHOST-DTFINAL-03 OR V0PROP-DTQITBCO <= WHOST-DTFINAL-04 OR V0PROP-DTQITBCO <= WHOST-DTFINAL-05 */

            if (V0PROP_DTQITBCO <= WHOST_DTFINAL_01 || V0PROP_DTQITBCO <= WHOST_DTFINAL_02 || V0PROP_DTQITBCO <= WHOST_DTFINAL_03 || V0PROP_DTQITBCO <= WHOST_DTFINAL_04 || V0PROP_DTQITBCO <= WHOST_DTFINAL_05)
            {

                /*" -891- CONTINUE */

                /*" -892- ELSE */
            }
            else
            {


                /*" -893- IF V0PROP-ACATAMENTO EQUAL 'N' */

                if (V0PROP_ACATAMENTO == "N")
                {

                    /*" -894- CONTINUE */

                    /*" -895- ELSE */
                }
                else
                {


                    /*" -896- ADD 1 TO AC-DESPR-PROPOVA */
                    WORK_AREA.AC_DESPR_PROPOVA.Value = WORK_AREA.AC_DESPR_PROPOVA + 1;

                    /*" -897- GO TO R0910-00-FETCH-PROPOSTAS-VA */
                    new Task(() => R0910_00_FETCH_PROPOSTAS_VA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -898- END-IF */
                }


                /*" -900- END-IF */
            }


            /*" -901- IF VIND-DTA-DECLINIO LESS ZEROS */

            if (VIND_DTA_DECLINIO < 00)
            {

                /*" -902- MOVE V1SIST-DTMOVABE TO WHOST-DTA-DECLINIO */
                _.Move(V1SIST_DTMOVABE, WHOST_DTA_DECLINIO);

                /*" -903- ELSE */
            }
            else
            {


                /*" -905- IF VIND-DTA-DECLINIO = -1 OR V0PROP-DTA-DECLINIO = '0001-01-01' */

                if (VIND_DTA_DECLINIO == -1 || V0PROP_DTA_DECLINIO == "0001-01-01")
                {

                    /*" -906- MOVE V1SIST-DTMOVABE TO WHOST-DTA-DECLINIO */
                    _.Move(V1SIST_DTMOVABE, WHOST_DTA_DECLINIO);

                    /*" -907- ELSE */
                }
                else
                {


                    /*" -908- MOVE V0PROP-DTA-DECLINIO TO WHOST-DTA-DECLINIO */
                    _.Move(V0PROP_DTA_DECLINIO, WHOST_DTA_DECLINIO);

                    /*" -909- END-IF */
                }


                /*" -911- END-IF */
            }


            /*" -911- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTAS-VA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOSTAS_VA_DB_FETCH_1()
        {
            /*" -859- EXEC SQL FETCH TCOMIS INTO :V0PROP-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-DTQITBCO, :V0PROP-DTQITBCO15, :V0PROP-SITUACAO, :V0PROP-DPS-TITULAR:VIND-DPS-TITULAR, :V0PROP-DPS-CONJUGE:VIND-DPS-CONJUGE, :V0PROP-DTA-DECLINIO:VIND-DTA-DECLINIO, :V0PROP-ACATAMENTO:VIND-ACATAMENTO, :WHOST-ORIG-PRODU:VIND-ORIG-PRODU, :V0PROP-CODPRODU END-EXEC. */

            if (TCOMIS.Fetch())
            {
                _.Move(TCOMIS.V0PROP_APOLICE, V0PROP_APOLICE);
                _.Move(TCOMIS.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(TCOMIS.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(TCOMIS.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(TCOMIS.V0PROP_DTQITBCO15, V0PROP_DTQITBCO15);
                _.Move(TCOMIS.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(TCOMIS.V0PROP_DPS_TITULAR, V0PROP_DPS_TITULAR);
                _.Move(TCOMIS.VIND_DPS_TITULAR, VIND_DPS_TITULAR);
                _.Move(TCOMIS.V0PROP_DPS_CONJUGE, V0PROP_DPS_CONJUGE);
                _.Move(TCOMIS.VIND_DPS_CONJUGE, VIND_DPS_CONJUGE);
                _.Move(TCOMIS.V0PROP_DTA_DECLINIO, V0PROP_DTA_DECLINIO);
                _.Move(TCOMIS.VIND_DTA_DECLINIO, VIND_DTA_DECLINIO);
                _.Move(TCOMIS.V0PROP_ACATAMENTO, V0PROP_ACATAMENTO);
                _.Move(TCOMIS.VIND_ACATAMENTO, VIND_ACATAMENTO);
                _.Move(TCOMIS.WHOST_ORIG_PRODU, WHOST_ORIG_PRODU);
                _.Move(TCOMIS.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
                _.Move(TCOMIS.V0PROP_CODPRODU, V0PROP_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTAS-VA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOSTAS_VA_DB_CLOSE_1()
        {
            /*" -863- EXEC SQL CLOSE TCOMIS END-EXEC */

            TCOMIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -941- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -943- ADD 1 TO AC-SELEC. */
            WORK_AREA.AC_SELEC.Value = WORK_AREA.AC_SELEC + 1;

            /*" -946- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -948- PERFORM R1010-00-SELECT-CONVERSAO */

            R1010_00_SELECT_CONVERSAO_SECTION();

            /*" -949- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -950- MOVE CONV-NUM-SICOB TO WHOST-NUMTIT */
                _.Move(CONV_NUM_SICOB, WHOST_NUMTIT);

                /*" -951- ELSE */
            }
            else
            {


                /*" -952- MOVE V0PROP-NRCERTIF TO WHOST-NUMTIT */
                _.Move(V0PROP_NRCERTIF, WHOST_NUMTIT);

                /*" -954- END-IF */
            }


            /*" -956- PERFORM R1100-00-SELECT-FIDELIZ */

            R1100_00_SELECT_FIDELIZ_SECTION();

            /*" -958- MOVE 'NAO' TO WHOST-SEM-DECLINIO */
            _.Move("NAO", WHOST_SEM_DECLINIO);

            /*" -961- PERFORM R1110-00-SELECT-RELATORI THRU R1110-99-SAIDA */

            R1110_00_SELECT_RELATORI_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/


            /*" -962- IF WHOST-SEM-DECLINIO EQUAL 'SIM' */

            if (WHOST_SEM_DECLINIO == "SIM")
            {

                /*" -963- ADD 1 TO AC-DESPR-RELATORIOS */
                WORK_AREA.AC_DESPR_RELATORIOS.Value = WORK_AREA.AC_DESPR_RELATORIOS + 1;

                /*" -964- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -967- END-IF */
            }


            /*" -970- PERFORM R1015-00-SELECT-OPCAOPAG */

            R1015_00_SELECT_OPCAOPAG_SECTION();

            /*" -971- MOVE ZEROS TO WHOST-NRRCAP */
            _.Move(0, WHOST_NRRCAP);

            /*" -973- MOVE SPACES TO WS-MSG-INFORMATIVA */
            _.Move("", WS_MSG_INFORMATIVA);

            /*" -974- IF (V0PROP-SITUACAO EQUAL '1' ) */

            if ((V0PROP_SITUACAO == "1"))
            {

                /*" -976- PERFORM R3100-00-VERIFICA-MSG-INFOR */

                R3100_00_VERIFICA_MSG_INFOR_SECTION();

                /*" -977- IF WS-QTD-ERRO-VANEA > ZEROS */

                if (WS_QTD_ERRO_VANEA > 00)
                {

                    /*" -978- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -979- END-IF */
                }


                /*" -981- END-IF */
            }


            /*" -982- IF PF-OPCAOPAG NOT EQUAL '3' */

            if (PF_OPCAOPAG != "3")
            {

                /*" -984- PERFORM R1020-00-SELECT-V0RCAP */

                R1020_00_SELECT_V0RCAP_SECTION();

                /*" -985- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -987- PERFORM R2200-00-UPDATE-PROPOVA */

                    R2200_00_UPDATE_PROPOVA_SECTION();

                    /*" -988- MOVE 'A' TO LK-VG001-STA-CRITICA */
                    _.Move("A", SPVG001W.LK_VG001_STA_CRITICA);

                    /*" -990- PERFORM R2860-00-DELETE-VGCRITICA */

                    R2860_00_DELETE_VGCRITICA_SECTION();

                    /*" -992- ADD 1 TO AC-DESPR-RCAPS */
                    WORK_AREA.AC_DESPR_RCAPS.Value = WORK_AREA.AC_DESPR_RCAPS + 1;

                    /*" -994- IF WHOST-ORIG-PRODU EQUAL 'CEF DEB CC' OR WHOST-ORIG-PRODU EQUAL 'PAREN' */

                    if (WHOST_ORIG_PRODU == "CEF DEB CC" || WHOST_ORIG_PRODU == "PAREN")
                    {

                        /*" -995- MOVE 'VA0512B' TO WHOST-COD-RELAT */
                        _.Move("VA0512B", WHOST_COD_RELAT);

                        /*" -1003- MOVE ZEROS TO PF-OPCAOPAG PF-AGECTADEB PF-OPRCTADEB PF-NUMCTADEB PF-DIGCTADEB WHOST-BCO-RELAT WHOST-VLR-RELAT WHOST-SIN-RELAT */
                        _.Move(0, PF_OPCAOPAG, PF_AGECTADEB, PF_OPRCTADEB, PF_NUMCTADEB, PF_DIGCTADEB, WHOST_BCO_RELAT, WHOST_VLR_RELAT, WHOST_SIN_RELAT);

                        /*" -1004- PERFORM R2000-00-INSERT-RELATORIOS */

                        R2000_00_INSERT_RELATORIOS_SECTION();

                        /*" -1005- END-IF */
                    }


                    /*" -1006- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1007- END-IF */
                }


                /*" -1008- ELSE */
            }
            else
            {


                /*" -1009- MOVE V0PROP-DTQITBCO TO WHOST-DATARCAP */
                _.Move(V0PROP_DTQITBCO, WHOST_DATARCAP);

                /*" -1011- END-IF */
            }


            /*" -1016- IF WHOST-DATARCAP <= WHOST-DTFINAL-01 OR WHOST-DATARCAP <= WHOST-DTFINAL-02 OR WHOST-DATARCAP <= WHOST-DTFINAL-03 OR WHOST-DATARCAP <= WHOST-DTFINAL-04 OR WHOST-DATARCAP <= WHOST-DTFINAL-05 */

            if (WHOST_DATARCAP <= WHOST_DTFINAL_01 || WHOST_DATARCAP <= WHOST_DTFINAL_02 || WHOST_DATARCAP <= WHOST_DTFINAL_03 || WHOST_DATARCAP <= WHOST_DTFINAL_04 || WHOST_DATARCAP <= WHOST_DTFINAL_05)
            {

                /*" -1017- CONTINUE */

                /*" -1018- ELSE */
            }
            else
            {


                /*" -1019- IF V0PROP-ACATAMENTO EQUAL 'N' */

                if (V0PROP_ACATAMENTO == "N")
                {

                    /*" -1020- CONTINUE */

                    /*" -1021- ELSE */
                }
                else
                {


                    /*" -1022- ADD 1 TO AC-DESPR-DATA */
                    WORK_AREA.AC_DESPR_DATA.Value = WORK_AREA.AC_DESPR_DATA + 1;

                    /*" -1023- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1024- END-IF */
                }


                /*" -1026- END-IF */
            }


            /*" -1027- IF V0PROP-CODPRODU EQUAL 9750 OR 9751 OR 9752 */

            if (V0PROP_CODPRODU.In("9750", "9751", "9752"))
            {

                /*" -1029- PERFORM R3200-00-CONS-DPS-INCONCLUSIVO */

                R3200_00_CONS_DPS_INCONCLUSIVO_SECTION();

                /*" -1030- IF WS-STA-INCONCLUSIVO > ZEROS */

                if (WS_STA_INCONCLUSIVO > 00)
                {

                    /*" -1031- IF WHOST-DATARCAP <= WHOST-DTFINAL-06 */

                    if (WHOST_DATARCAP <= WHOST_DTFINAL_06)
                    {

                        /*" -1032- CONTINUE */

                        /*" -1033- ELSE */
                    }
                    else
                    {


                        /*" -1034- ADD 1 TO AC-DESPR-DATA */
                        WORK_AREA.AC_DESPR_DATA.Value = WORK_AREA.AC_DESPR_DATA + 1;

                        /*" -1035- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -1036- END-IF */
                    }


                    /*" -1038- END-IF */
                }


                /*" -1039- MOVE 'VA0469B' TO WHOST-COD-RELAT */
                _.Move("VA0469B", WHOST_COD_RELAT);

                /*" -1041- MOVE ZEROS TO WHOST-NUM-COPIAS */
                _.Move(0, WHOST_NUM_COPIAS);

                /*" -1042- IF WTEM-FIDELIZ = 'N' */

                if (WORK_AREA.WTEM_FIDELIZ == "N")
                {

                    /*" -1050- MOVE ZEROS TO PF-OPCAOPAG PF-AGECTADEB PF-OPRCTADEB PF-NUMCTADEB PF-DIGCTADEB WHOST-BCO-RELAT WHOST-VLR-RELAT WHOST-SIN-RELAT */
                    _.Move(0, PF_OPCAOPAG, PF_AGECTADEB, PF_OPRCTADEB, PF_NUMCTADEB, PF_DIGCTADEB, WHOST_BCO_RELAT, WHOST_VLR_RELAT, WHOST_SIN_RELAT);

                    /*" -1051- ELSE */
                }
                else
                {


                    /*" -1053- MOVE ZEROS TO WHOST-VLR-RELAT WHOST-SIN-RELAT */
                    _.Move(0, WHOST_VLR_RELAT, WHOST_SIN_RELAT);

                    /*" -1054- MOVE 104 TO WHOST-BCO-RELAT */
                    _.Move(104, WHOST_BCO_RELAT);

                    /*" -1055- MOVE PF-VAL-PAGO TO WHOST-VLR-RELAT */
                    _.Move(PF_VAL_PAGO, WHOST_VLR_RELAT);

                    /*" -1057- COMPUTE WHOST-VLR-RELAT = WHOST-VLR-RELAT * 100 */
                    WHOST_VLR_RELAT.Value = WHOST_VLR_RELAT * 100;

                    /*" -1061- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

                    R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

                    /*" -1064- END-IF */
                }


                /*" -1065- IF PF-OPCAOPAG EQUAL '3' */

                if (PF_OPCAOPAG == "3")
                {

                    /*" -1070- MOVE ZEROS TO PF-AGECTADEB PF-OPRCTADEB PF-NUMCTADEB PF-DIGCTADEB WHOST-BCO-RELAT */
                    _.Move(0, PF_AGECTADEB, PF_OPRCTADEB, PF_NUMCTADEB, PF_DIGCTADEB, WHOST_BCO_RELAT);

                    /*" -1071- MOVE 5 TO WHOST-NUM-COPIAS */
                    _.Move(5, WHOST_NUM_COPIAS);

                    /*" -1073- END-IF */
                }


                /*" -1077- PERFORM R2000-00-INSERT-RELATORIOS. */

                R2000_00_INSERT_RELATORIOS_SECTION();
            }


            /*" -1079- PERFORM R2200-00-UPDATE-PROPOVA */

            R2200_00_UPDATE_PROPOVA_SECTION();

            /*" -1080- MOVE '9' TO LK-VG001-STA-CRITICA */
            _.Move("9", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -1082- PERFORM R2860-00-DELETE-VGCRITICA */

            R2860_00_DELETE_VGCRITICA_SECTION();

            /*" -1083- IF WS-MSG-INFORMATIVA NOT EQUAL SPACES */

            if (!WS_MSG_INFORMATIVA.IsEmpty())
            {

                /*" -1084- PERFORM R3150-00-INSERIR-MSG-INFOR */

                R3150_00_INSERIR_MSG_INFOR_SECTION();

                /*" -1085- END-IF */
            }


            /*" -1085- . */

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -1061- EXEC SQL SELECT CAST(:WHOST-VLR-RELAT AS INT) INTO :WHOST-SIN-RELAT FROM SYSIBM.SYSDUMMY1 END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                WHOST_VLR_RELAT = WHOST_VLR_RELAT.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_SIN_RELAT, WHOST_SIN_RELAT);
            }


        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1089- PERFORM R0910-00-FETCH-PROPOSTAS-VA. */

            R0910_00_FETCH_PROPOSTAS_VA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1015-00-SELECT-OPCAOPAG-SECTION */
        private void R1015_00_SELECT_OPCAOPAG_SECTION()
        {
            /*" -1100- MOVE '1015' TO WNR-EXEC-SQL */
            _.Move("1015", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1107- PERFORM R1015_00_SELECT_OPCAOPAG_DB_SELECT_1 */

            R1015_00_SELECT_OPCAOPAG_DB_SELECT_1();

            /*" -1110- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1111- DISPLAY 'R1015- SELECT OPCAO_PAG_VIDAZUL' */
                _.Display($"R1015- SELECT OPCAO_PAG_VIDAZUL");

                /*" -1112- DISPLAY 'R1015- SQLCODE  - ' SQLCODE */
                _.Display($"R1015- SQLCODE  - {DB.SQLCODE}");

                /*" -1113- DISPLAY 'R1015- NRCERTIF - ' V0PROP-NRCERTIF */
                _.Display($"R1015- NRCERTIF - {V0PROP_NRCERTIF}");

                /*" -1114- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1116- END-IF */
            }


            /*" -1117- EVALUATE OPCPAGVI-OPC-PAGTO */
            switch (OPCPAGVI_OPC_PAGTO.Value.Trim())
            {

                /*" -1118- WHEN '1' */
                case "1":

                    /*" -1119- WHEN '2' */
                    break;
                case "2":

                    /*" -1120- MOVE '1' TO PF-OPCAOPAG */
                    _.Move("1", PF_OPCAOPAG);

                    /*" -1121- WHEN '3' */
                    break;
                case "3":

                    /*" -1122- MOVE '2' TO PF-OPCAOPAG */
                    _.Move("2", PF_OPCAOPAG);

                    /*" -1123- WHEN '5' */
                    break;
                case "5":

                    /*" -1124- MOVE '3' TO PF-OPCAOPAG */
                    _.Move("3", PF_OPCAOPAG);

                    /*" -1125- WHEN OTHER */
                    break;
                default:

                    /*" -1126- MOVE '1' TO PF-OPCAOPAG */
                    _.Move("1", PF_OPCAOPAG);

                    /*" -1128- END-EVALUATE */
                    break;
            }


            /*" -1128- . */

        }

        [StopWatch]
        /*" R1015-00-SELECT-OPCAOPAG-DB-SELECT-1 */
        public void R1015_00_SELECT_OPCAOPAG_DB_SELECT_1()
        {
            /*" -1107- EXEC SQL SELECT OPCAO_PAGAMENTO INTO :OPCPAGVI-OPC-PAGTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC */

            var r1015_00_SELECT_OPCAOPAG_DB_SELECT_1_Query1 = new R1015_00_SELECT_OPCAOPAG_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1015_00_SELECT_OPCAOPAG_DB_SELECT_1_Query1.Execute(r1015_00_SELECT_OPCAOPAG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPC_PAGTO, OPCPAGVI_OPC_PAGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1015_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-SECTION */
        private void R1010_00_SELECT_CONVERSAO_SECTION()
        {
            /*" -1142- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1147- PERFORM R1010_00_SELECT_CONVERSAO_DB_SELECT_1 */

            R1010_00_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -1150- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1151- DISPLAY 'R1010- SELECT CONVERSAO' */
                _.Display($"R1010- SELECT CONVERSAO");

                /*" -1152- DISPLAY 'R1010- SQLCODE - ' SQLCODE */
                _.Display($"R1010- SQLCODE - {DB.SQLCODE}");

                /*" -1153- DISPLAY 'R1010-NRCERTIF - ' V0PROP-NRCERTIF */
                _.Display($"R1010-NRCERTIF - {V0PROP_NRCERTIF}");

                /*" -1155- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1156- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1156- MOVE CONV-NUM-SICOB TO CONV-NUMTIT. */
                _.Move(CONV_NUM_SICOB, CONV_NUMTIT);
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R1010_00_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -1147- EXEC SQL SELECT NUM_SICOB INTO :CONV-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NRCERTIF END-EXEC. */

            var r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 = new R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONV_NUM_SICOB, CONV_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-SECTION */
        private void R1020_00_SELECT_V0RCAP_SECTION()
        {
            /*" -1170- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1183- PERFORM R1020_00_SELECT_V0RCAP_DB_SELECT_1 */

            R1020_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -1186- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1187- WHEN 00 */
                case 00:

                    /*" -1188- PERFORM R1026-00-SELECT-V0RCAPCOMP */

                    R1026_00_SELECT_V0RCAPCOMP_SECTION();

                    /*" -1190- WHEN +100 */
                    break;
                case +100:

                    /*" -1193- PERFORM R1025-00-SELECT-V0RCAP */

                    R1025_00_SELECT_V0RCAP_SECTION();

                    /*" -1194- WHEN OTHER */
                    break;
                default:

                    /*" -1195- DISPLAY 'R1020- SELECT RCAPS' */
                    _.Display($"R1020- SELECT RCAPS");

                    /*" -1196- DISPLAY 'R1020- SQLCODE - ' SQLCODE */
                    _.Display($"R1020- SQLCODE - {DB.SQLCODE}");

                    /*" -1197- DISPLAY 'R1020- NUMTIT  - ' WHOST-NUMTIT */
                    _.Display($"R1020- NUMTIT  - {WHOST_NUMTIT}");

                    /*" -1198- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1200- END-EVALUATE */
                    break;
            }


            /*" -1200- . */

        }

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R1020_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -1183- EXEC SQL SELECT NRRCAP , SITUACAO INTO :WHOST-NRRCAP , :WHOST-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :WHOST-NUMTIT AND OPERACAO >= 100 AND OPERACAO <= 299 END-EXEC. */

            var r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                WHOST_NUMTIT = WHOST_NUMTIT.ToString(),
            };

            var executed_1 = R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRRCAP, WHOST_NRRCAP);
                _.Move(executed_1.WHOST_SITUACAO, WHOST_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1025-00-SELECT-V0RCAP-SECTION */
        private void R1025_00_SELECT_V0RCAP_SECTION()
        {
            /*" -1212- MOVE '103' TO WNR-EXEC-SQL. */
            _.Move("103", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1223- PERFORM R1025_00_SELECT_V0RCAP_DB_SELECT_1 */

            R1025_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -1226- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1227- WHEN 00 */
                case 00:

                    /*" -1228- PERFORM R1026-00-SELECT-V0RCAPCOMP */

                    R1026_00_SELECT_V0RCAPCOMP_SECTION();

                    /*" -1229- WHEN +100 */
                    break;
                case +100:

                /*" -1230- CONTINUE */

                /*" -1232- WHEN OTHER */
                default:

                    /*" -1233- DISPLAY 'R1025- SELECT RCAPS' */
                    _.Display($"R1025- SELECT RCAPS");

                    /*" -1234- DISPLAY 'R1025- SQLCODE - ' SQLCODE */
                    _.Display($"R1025- SQLCODE - {DB.SQLCODE}");

                    /*" -1235- DISPLAY 'R1025- NUMCERT - ' V0PROP-NRCERTIF */
                    _.Display($"R1025- NUMCERT - {V0PROP_NRCERTIF}");

                    /*" -1236- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1238- END-EVALUATE */
                    break;
            }


            /*" -1238- . */

        }

        [StopWatch]
        /*" R1025-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R1025_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -1223- EXEC SQL SELECT NRRCAP , SITUACAO INTO :WHOST-NRRCAP , :WHOST-SITUACAO FROM SEGUROS.V0RCAP WHERE NRCERTIF = :V0PROP-NRCERTIF AND OPERACAO >= 100 AND OPERACAO <= 299 END-EXEC */

            var r1025_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R1025_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1025_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r1025_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRRCAP, WHOST_NRRCAP);
                _.Move(executed_1.WHOST_SITUACAO, WHOST_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1025_99_SAIDA*/

        [StopWatch]
        /*" R1026-00-SELECT-V0RCAPCOMP-SECTION */
        private void R1026_00_SELECT_V0RCAPCOMP_SECTION()
        {
            /*" -1252- MOVE '104' TO WNR-EXEC-SQL. */
            _.Move("104", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1259- PERFORM R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1 */

            R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1();

            /*" -1262- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1263- DISPLAY 'R1026- SELECT RCAP_COMPLEMENTAR' */
                _.Display($"R1026- SELECT RCAP_COMPLEMENTAR");

                /*" -1264- DISPLAY 'R1026- SQLCODE  - ' SQLCODE */
                _.Display($"R1026- SQLCODE  - {DB.SQLCODE}");

                /*" -1265- DISPLAY 'R1026- NUM_RCAP - ' WHOST-NUMTIT */
                _.Display($"R1026- NUM_RCAP - {WHOST_NUMTIT}");

                /*" -1266- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1268- END-IF */
            }


            /*" -1268- . */

        }

        [StopWatch]
        /*" R1026-00-SELECT-V0RCAPCOMP-DB-SELECT-1 */
        public void R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1()
        {
            /*" -1259- EXEC SQL SELECT DATARCAP INTO :WHOST-DATARCAP FROM SEGUROS.V0RCAPCOMP WHERE NRRCAP = :WHOST-NRRCAP AND OPERACAO >= 100 AND OPERACAO <= 199 END-EXEC */

            var r1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 = new R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1()
            {
                WHOST_NRRCAP = WHOST_NRRCAP.ToString(),
            };

            var executed_1 = R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1.Execute(r1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATARCAP, WHOST_DATARCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1026_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-SELECT-VG078-SECTION */
        private void R1030_00_SELECT_VG078_SECTION()
        {
            /*" -1282- MOVE '103' TO WNR-EXEC-SQL. */
            _.Move("103", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1287- PERFORM R1030_00_SELECT_VG078_DB_SELECT_1 */

            R1030_00_SELECT_VG078_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1030-00-SELECT-VG078-DB-SELECT-1 */
        public void R1030_00_SELECT_VG078_DB_SELECT_1()
        {
            /*" -1287- EXEC SQL SELECT COUNT(*) INTO :WHOST-ACOMP FROM SEGUROS.VG_ANDAMENTO_PROP WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF END-EXEC. */

            var r1030_00_SELECT_VG078_DB_SELECT_1_Query1 = new R1030_00_SELECT_VG078_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1030_00_SELECT_VG078_DB_SELECT_1_Query1.Execute(r1030_00_SELECT_VG078_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_ACOMP, WHOST_ACOMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-V0ERROSPROPVA-SECTION */
        private void R1050_00_SELECT_V0ERROSPROPVA_SECTION()
        {
            /*" -1301- MOVE '105' TO WNR-EXEC-SQL. */
            _.Move("105", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1307- PERFORM R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1 */

            R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1050-00-SELECT-V0ERROSPROPVA-DB-SELECT-1 */
        public void R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1()
        {
            /*" -1307- EXEC SQL SELECT COUNT(*) INTO :WHOST-ERROS FROM SEGUROS.V0ERROSPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND COD_ERRO IN (1803, 1804) END-EXEC. */

            var r1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1 = new R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_ERROS, WHOST_ERROS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-FIDELIZ-SECTION */
        private void R1100_00_SELECT_FIDELIZ_SECTION()
        {
            /*" -1321- MOVE '110' TO WNR-EXEC-SQL */
            _.Move("110", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1323- MOVE 'N' TO WTEM-FIDELIZ */
            _.Move("N", WORK_AREA.WTEM_FIDELIZ);

            /*" -1340- PERFORM R1100_00_SELECT_FIDELIZ_DB_SELECT_1 */

            R1100_00_SELECT_FIDELIZ_DB_SELECT_1();

            /*" -1343- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1344- DISPLAY 'R1100- SELECT POSPORTA-FIDELIZ' */
                _.Display($"R1100- SELECT POSPORTA-FIDELIZ");

                /*" -1345- DISPLAY 'R1100- SQLCODE  - ' SQLCODE */
                _.Display($"R1100- SQLCODE  - {DB.SQLCODE}");

                /*" -1346- DISPLAY 'R1100- NRCERTIF - ' V0PROP-NRCERTIF */
                _.Display($"R1100- NRCERTIF - {V0PROP_NRCERTIF}");

                /*" -1347- MOVE 'N' TO WTEM-FIDELIZ */
                _.Move("N", WORK_AREA.WTEM_FIDELIZ);

                /*" -1348- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1350- END-IF */
            }


            /*" -1351- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1352- MOVE 'S' TO WTEM-FIDELIZ */
                _.Move("S", WORK_AREA.WTEM_FIDELIZ);

                /*" -1354- END-IF */
            }


            /*" -1354- . */

        }

        [StopWatch]
        /*" R1100-00-SELECT-FIDELIZ-DB-SELECT-1 */
        public void R1100_00_SELECT_FIDELIZ_DB_SELECT_1()
        {
            /*" -1340- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, OPCAOPAG, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, VAL_PAGO INTO :PF-NUM-PROP-SIVPF, :PF-OPCAOPAG, :PF-AGECTADEB, :PF-OPRCTADEB, :PF-NUMCTADEB, :PF-DIGCTADEB, :PF-VAL-PAGO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NRCERTIF END-EXEC */

            var r1100_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 = new R1100_00_SELECT_FIDELIZ_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_SELECT_FIDELIZ_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF_NUM_PROP_SIVPF, PF_NUM_PROP_SIVPF);
                _.Move(executed_1.PF_OPCAOPAG, PF_OPCAOPAG);
                _.Move(executed_1.PF_AGECTADEB, PF_AGECTADEB);
                _.Move(executed_1.PF_OPRCTADEB, PF_OPRCTADEB);
                _.Move(executed_1.PF_NUMCTADEB, PF_NUMCTADEB);
                _.Move(executed_1.PF_DIGCTADEB, PF_DIGCTADEB);
                _.Move(executed_1.PF_VAL_PAGO, PF_VAL_PAGO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-SELECT-RELATORI-SECTION */
        private void R1110_00_SELECT_RELATORI_SECTION()
        {
            /*" -1368- MOVE '111' TO WNR-EXEC-SQL */
            _.Move("111", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1376- PERFORM R1110_00_SELECT_RELATORI_DB_SELECT_1 */

            R1110_00_SELECT_RELATORI_DB_SELECT_1();

            /*" -1379-  EVALUATE SQLCODE  */

            /*" -1380-  WHEN ZEROS  */

            /*" -1381-  WHEN -811  */

            /*" -1381- IF   SQLCODE EQUALS ZEROS OR  -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -1382- MOVE 'SIM' TO WHOST-SEM-DECLINIO */
                _.Move("SIM", WHOST_SEM_DECLINIO);

                /*" -1383-  WHEN +100  */

                /*" -1383- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1384- CONTINUE */

                /*" -1385-  WHEN OTHER  */

                /*" -1385- ELSE */
            }
            else
            {


                /*" -1386- DISPLAY 'ERRO SELECT RELATORIOS - DECLINIO' */
                _.Display($"ERRO SELECT RELATORIOS - DECLINIO");

                /*" -1387- DISPLAY 'CERTIFICADO = ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO = {V0PROP_NRCERTIF}");

                /*" -1388- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1390-  END-EVALUATE  */

                /*" -1390- END-IF */
            }


            /*" -1390- . */

        }

        [StopWatch]
        /*" R1110-00-SELECT-RELATORI-DB-SELECT-1 */
        public void R1110_00_SELECT_RELATORI_DB_SELECT_1()
        {
            /*" -1376- EXEC SQL SELECT CODRELAT INTO :V0RELA-CODRELAT FROM SEGUROS.V0RELATORIOS WHERE NRCERTIF = :V0PROP-NRCERTIF AND CODRELAT = 'DECLINIO' AND SITUACAO = '1' WITH UR END-EXEC. */

            var r1110_00_SELECT_RELATORI_DB_SELECT_1_Query1 = new R1110_00_SELECT_RELATORI_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1110_00_SELECT_RELATORI_DB_SELECT_1_Query1.Execute(r1110_00_SELECT_RELATORI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_CODRELAT, V0RELA_CODRELAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-INSERT-RELATORIOS-SECTION */
        private void R2000_00_INSERT_RELATORIOS_SECTION()
        {
            /*" -1404- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1412- PERFORM R2000_00_INSERT_RELATORIOS_DB_SELECT_1 */

            R2000_00_INSERT_RELATORIOS_DB_SELECT_1();

            /*" -1415- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1416- DISPLAY 'R2000- SELECT RELATORIO' */
                _.Display($"R2000- SELECT RELATORIO");

                /*" -1417- DISPLAY 'R2000-NRCERTIF  - ' V0PROP-NRCERTIF */
                _.Display($"R2000-NRCERTIF  - {V0PROP_NRCERTIF}");

                /*" -1418- DISPLAY 'R2000-DATASOLIC - ' V1SIST-DTMOVABE */
                _.Display($"R2000-DATASOLIC - {V1SIST_DTMOVABE}");

                /*" -1421- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1422- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1423- DISPLAY 'REGISTRO RELATORIO EM DUPLICIDADE' */
                _.Display($"REGISTRO RELATORIO EM DUPLICIDADE");

                /*" -1424- DISPLAY 'R2000- CODUSU   - ' RELATORI-COD-USUARIO */
                _.Display($"R2000- CODUSU   - {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

                /*" -1425- DISPLAY 'R2000-NRCERTIF  - ' V0PROP-NRCERTIF */
                _.Display($"R2000-NRCERTIF  - {V0PROP_NRCERTIF}");

                /*" -1426- DISPLAY 'R2000-DATASOLIC - ' V1SIST-DTMOVABE */
                _.Display($"R2000-DATASOLIC - {V1SIST_DTMOVABE}");

                /*" -1427- ADD 1 TO AC-DUPLICA */
                WORK_AREA.AC_DUPLICA.Value = WORK_AREA.AC_DUPLICA + 1;

                /*" -1430- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1433- MOVE '205' TO WNR-EXEC-SQL. */
            _.Move("205", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1484- PERFORM R2000_00_INSERT_RELATORIOS_DB_INSERT_1 */

            R2000_00_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -1487- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1488- DISPLAY 'R2050- INSERT RELATORIOS-CERT- ' V0PROP-NRCERTIF */
                _.Display($"R2050- INSERT RELATORIOS-CERT- {V0PROP_NRCERTIF}");

                /*" -1489- DISPLAY 'R2050- CODREL  - ' WHOST-COD-RELAT */
                _.Display($"R2050- CODREL  - {WHOST_COD_RELAT}");

                /*" -1490- DISPLAY 'R2050- SQLCODE - ' SQLCODE */
                _.Display($"R2050- SQLCODE - {DB.SQLCODE}");

                /*" -1492- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1492- ADD 1 TO AC-GRAVA. */
            WORK_AREA.AC_GRAVA.Value = WORK_AREA.AC_GRAVA + 1;

        }

        [StopWatch]
        /*" R2000-00-INSERT-RELATORIOS-DB-SELECT-1 */
        public void R2000_00_INSERT_RELATORIOS_DB_SELECT_1()
        {
            /*" -1412- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND DATA_SOLICITACAO = :V1SIST-DTMOVABE AND COD_RELATORIO = 'VA0469B' AND NUM_PARCELA = 01 END-EXEC. */

            var r2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 = new R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1.Execute(r2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }


        }

        [StopWatch]
        /*" R2000-00-INSERT-RELATORIOS-DB-INSERT-1 */
        public void R2000_00_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -1484- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA0458B' , :V1SIST-DTMOVABE, 'VA' , :WHOST-COD-RELAT, :WHOST-NUM-COPIAS, :WHOST-BCO-RELAT, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :PF-AGECTADEB, :PF-OPRCTADEB, :PF-DIGCTADEB, 0, 0, 0, 0, 0, :V0PROP-APOLICE, 0, 1, :V0PROP-NRCERTIF, 0, :V0PROP-CODSUBES, 9, 0, 0, ' ' , ' ' , 0, :PF-NUMCTADEB, ' ' , :WHOST-SIN-RELAT, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                WHOST_COD_RELAT = WHOST_COD_RELAT.ToString(),
                WHOST_NUM_COPIAS = WHOST_NUM_COPIAS.ToString(),
                WHOST_BCO_RELAT = WHOST_BCO_RELAT.ToString(),
                PF_AGECTADEB = PF_AGECTADEB.ToString(),
                PF_OPRCTADEB = PF_OPRCTADEB.ToString(),
                PF_DIGCTADEB = PF_DIGCTADEB.ToString(),
                V0PROP_APOLICE = V0PROP_APOLICE.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                PF_NUMCTADEB = PF_NUMCTADEB.ToString(),
                WHOST_SIN_RELAT = WHOST_SIN_RELAT.ToString(),
            };

            R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(r2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-INSERT-ERRPROVI-SECTION */
        private void R2100_00_INSERT_ERRPROVI_SECTION()
        {
            /*" -1506- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1510- PERFORM R2100_00_INSERT_ERRPROVI_DB_INSERT_1 */

            R2100_00_INSERT_ERRPROVI_DB_INSERT_1();

            /*" -1513- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1513- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-INSERT-ERRPROVI-DB-INSERT-1 */
        public void R2100_00_INSERT_ERRPROVI_DB_INSERT_1()
        {
            /*" -1510- EXEC SQL INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL VALUES ( :V0PROP-NRCERTIF, 1846 ) END-EXEC. */

            var r2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1 = new R2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1.Execute(r2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-UPDATE-PROPOVA-SECTION */
        private void R2200_00_UPDATE_PROPOVA_SECTION()
        {
            /*" -1526- MOVE '220' TO WNR-EXEC-SQL */
            _.Move("220", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1535- PERFORM R2200_00_UPDATE_PROPOVA_DB_UPDATE_1 */

            R2200_00_UPDATE_PROPOVA_DB_UPDATE_1();

            /*" -1538- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1539- DISPLAY 'R2200- UPDATE PROPOSTA_VA' */
                _.Display($"R2200- UPDATE PROPOSTA_VA");

                /*" -1540- DISPLAY 'R2200- SQLCODE  - ' SQLCODE */
                _.Display($"R2200- SQLCODE  - {DB.SQLCODE}");

                /*" -1541- DISPLAY 'R2200- NRCERTIF - ' V0PROP-NRCERTIF */
                _.Display($"R2200- NRCERTIF - {V0PROP_NRCERTIF}");

                /*" -1542- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1544- END-IF */
            }


            /*" -1544- ADD 1 TO UP-PROPOVA. */
            WORK_AREA.UP_PROPOVA.Value = WORK_AREA.UP_PROPOVA + 1;

        }

        [StopWatch]
        /*" R2200-00-UPDATE-PROPOVA-DB-UPDATE-1 */
        public void R2200_00_UPDATE_PROPOVA_DB_UPDATE_1()
        {
            /*" -1535- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '2' , DTA_DECLINIO = :WHOST-DTA-DECLINIO, DATA_MOVIMENTO = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP, COD_USUARIO = 'VA0458B' WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF END-EXEC */

            var r2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 = new R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1()
            {
                WHOST_DTA_DECLINIO = WHOST_DTA_DECLINIO.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1.Execute(r2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2860-00-DELETE-VGCRITICA-SECTION */
        private void R2860_00_DELETE_VGCRITICA_SECTION()
        {
            /*" -1556- MOVE 286 TO WNR-EXEC-SQL. */
            _.Move(286, WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1558- DISPLAY PARAGRAFO */
            

            /*" -1559- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -1560- MOVE 08 TO LK-VG001-TIPO-ACAO */
            _.Move(08, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -1561- MOVE V0PROP-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0PROP_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -1562- MOVE 0 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -1563- MOVE 1 TO LK-VG001-SEQ-CRITICA */
            _.Move(1, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -1564- MOVE 'VA' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("VA", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -1565- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -1566- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -1567- MOVE 'VA0458B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0458B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -1568- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -1569- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -1572- MOVE 'EXCLUSAO LOGICA DE ERRO P/ PROPOSTA NAO ACEITA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EXCLUSAO LOGICA DE ERRO P/ PROPOSTA NAO ACEITA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -1574- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -1575- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS AND +1 */

            if (!SPVG001W.LK_VG001_IND_ERRO.In("00", "+1"))
            {

                /*" -1576- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -1577- DISPLAY '* R2860-PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R2860-PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -1578- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -1579- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -1580- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -1581- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -1582- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -1583- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -1584- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -1586- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -1587- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1588- END-IF */
            }


            /*" -1588- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2860_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-VERIFICA-MSG-INFOR-SECTION */
        private void R3100_00_VERIFICA_MSG_INFOR_SECTION()
        {
            /*" -1599- MOVE 3100 TO WNR-EXEC-SQL. */
            _.Move(3100, WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1601- DISPLAY PARAGRAFO */
            

            /*" -1602- IF PF-OPCAOPAG NOT EQUAL '3' */

            if (PF_OPCAOPAG != "3")
            {

                /*" -1603- PERFORM R1020-00-SELECT-V0RCAP */

                R1020_00_SELECT_V0RCAP_SECTION();

                /*" -1605- END-IF */
            }


            /*" -1607- IF WHOST-NRRCAP EQUAL ZEROS AND PF-OPCAOPAG NOT EQUAL '3' */

            if (WHOST_NRRCAP == 00 && PF_OPCAOPAG != "3")
            {

                /*" -1609- MOVE 'DECLINADO POR FALTA DE PAGAMENTO DE ADESAO' TO WS-MSG-INFORMATIVA */
                _.Move("DECLINADO POR FALTA DE PAGAMENTO DE ADESAO", WS_MSG_INFORMATIVA);

                /*" -1610- ADD 1 TO UP-DECLINADO-PGTO */
                WORK_AREA.UP_DECLINADO_PGTO.Value = WORK_AREA.UP_DECLINADO_PGTO + 1;

                /*" -1611- ELSE */
            }
            else
            {


                /*" -1613- PERFORM R3110-00-CONSULTA-PENDENTES */

                R3110_00_CONSULTA_PENDENTES_SECTION();

                /*" -1614- IF WS-QTD-PENDENTES > ZEROS */

                if (WS_QTD_PENDENTES > 00)
                {

                    /*" -1616- MOVE 'DECLINADO POR FALTA DE TRATAMENTO DE ERROS' TO WS-MSG-INFORMATIVA */
                    _.Move("DECLINADO POR FALTA DE TRATAMENTO DE ERROS", WS_MSG_INFORMATIVA);

                    /*" -1617- ADD 1 TO UP-DECLINADO-NTRAT */
                    WORK_AREA.UP_DECLINADO_NTRAT.Value = WORK_AREA.UP_DECLINADO_NTRAT + 1;

                    /*" -1618- ELSE */
                }
                else
                {


                    /*" -1620- PERFORM R3120-00-CONSULTA-ERRO-VANEA */

                    R3120_00_CONSULTA_ERRO_VANEA_SECTION();

                    /*" -1621- IF WS-QTD-ERRO-VANEA > ZEROS */

                    if (WS_QTD_ERRO_VANEA > 00)
                    {

                        /*" -1624- MOVE 'REALIZADA CORRECAO DE SITUACAO DA PROPOSTA PARA EMISSAO' TO WS-MSG-INFORMATIVA */
                        _.Move("REALIZADA CORRECAO DE SITUACAO DA PROPOSTA PARA EMISSAO", WS_MSG_INFORMATIVA);

                        /*" -1625- PERFORM R3150-00-INSERIR-MSG-INFOR */

                        R3150_00_INSERIR_MSG_INFOR_SECTION();

                        /*" -1626- PERFORM R3170-00-UPDATE-PROPOVA */

                        R3170_00_UPDATE_PROPOVA_SECTION();

                        /*" -1627- ADD 1 TO UP-PROPOVA-ATV */
                        WORK_AREA.UP_PROPOVA_ATV.Value = WORK_AREA.UP_PROPOVA_ATV + 1;

                        /*" -1628- END-IF */
                    }


                    /*" -1629- END-IF */
                }


                /*" -1630- END-IF */
            }


            /*" -1630- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-CONSULTA-PENDENTES-SECTION */
        private void R3110_00_CONSULTA_PENDENTES_SECTION()
        {
            /*" -1641- MOVE 3110 TO WNR-EXEC-SQL. */
            _.Move(3110, WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1643- DISPLAY PARAGRAFO */
            

            /*" -1645- MOVE ZEROS TO WS-QTD-PENDENTES */
            _.Move(0, WS_QTD_PENDENTES);

            /*" -1674- PERFORM R3110_00_CONSULTA_PENDENTES_DB_SELECT_1 */

            R3110_00_CONSULTA_PENDENTES_DB_SELECT_1();

            /*" -1677- IF SQLCODE NOT EQUAL ZEROES AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -1678- DISPLAY 'R3110- SELECT VG_CRITICA_PROPOSTA' */
                _.Display($"R3110- SELECT VG_CRITICA_PROPOSTA");

                /*" -1679- DISPLAY 'R3110- SQLCODE  - ' SQLCODE */
                _.Display($"R3110- SQLCODE  - {DB.SQLCODE}");

                /*" -1681- DISPLAY 'R3110- NRCERTIF - ' V0PROP-NRCERTIF */
                _.Display($"R3110- NRCERTIF - {V0PROP_NRCERTIF}");

                /*" -1682- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1684- END-IF */
            }


            /*" -1684- . */

        }

        [StopWatch]
        /*" R3110-00-CONSULTA-PENDENTES-DB-SELECT-1 */
        public void R3110_00_CONSULTA_PENDENTES_DB_SELECT_1()
        {
            /*" -1674- EXEC SQL SELECT COUNT(*) INTO :WS-QTD-PENDENTES FROM SEGUROS.PROPOSTAS_VA A WHERE A.NUM_CERTIFICADO = :V0PROP-NRCERTIF AND EXISTS ( SELECT 1 FROM SEGUROS.VG_CRITICA_PROPOSTA V1, SEGUROS.VG_DM_MSG_CRITICA V2 WHERE V1.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND V2.COD_MSG_CRITICA = V1.COD_MSG_CRITICA AND V2.COD_TP_MSG_CRITICA = 1 ) AND NOT EXISTS ( SELECT 1 FROM SEGUROS.VG_CRITICA_PROPOSTA V3 WHERE V3.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND V3.STA_CRITICA IN ( '3' , '8' ) ) AND EXISTS ( SELECT 1 FROM SEGUROS.VG_CRITICA_PROPOSTA V5 WHERE V5.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND V5.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' ) ) END-EXEC. */

            var r3110_00_CONSULTA_PENDENTES_DB_SELECT_1_Query1 = new R3110_00_CONSULTA_PENDENTES_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R3110_00_CONSULTA_PENDENTES_DB_SELECT_1_Query1.Execute(r3110_00_CONSULTA_PENDENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTD_PENDENTES, WS_QTD_PENDENTES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3120-00-CONSULTA-ERRO-VANEA-SECTION */
        private void R3120_00_CONSULTA_ERRO_VANEA_SECTION()
        {
            /*" -1695- MOVE 3120 TO WNR-EXEC-SQL. */
            _.Move(3120, WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1697- DISPLAY PARAGRAFO */
            

            /*" -1699- MOVE ZEROS TO WS-QTD-ERRO-VANEA */
            _.Move(0, WS_QTD_ERRO_VANEA);

            /*" -1721- PERFORM R3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1 */

            R3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1();

            /*" -1724- IF SQLCODE NOT EQUAL ZEROES AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -1725- DISPLAY 'R3120- SELECT VG_CRITICA_PROPOSTA' */
                _.Display($"R3120- SELECT VG_CRITICA_PROPOSTA");

                /*" -1726- DISPLAY 'R3120- SQLCODE  - ' SQLCODE */
                _.Display($"R3120- SQLCODE  - {DB.SQLCODE}");

                /*" -1728- DISPLAY 'R3120- NRCERTIF - ' V0PROP-NRCERTIF */
                _.Display($"R3120- NRCERTIF - {V0PROP_NRCERTIF}");

                /*" -1729- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1731- END-IF */
            }


            /*" -1731- . */

        }

        [StopWatch]
        /*" R3120-00-CONSULTA-ERRO-VANEA-DB-SELECT-1 */
        public void R3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1()
        {
            /*" -1721- EXEC SQL SELECT COUNT(*) INTO :WS-QTD-ERRO-VANEA FROM SEGUROS.PROPOSTAS_VA A WHERE A.NUM_CERTIFICADO = :V0PROP-NRCERTIF AND EXISTS ( SELECT 1 FROM SEGUROS.VG_CRITICA_PROPOSTA V1, SEGUROS.VG_DM_MSG_CRITICA V2 WHERE V1.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND V2.COD_MSG_CRITICA = V1.COD_MSG_CRITICA AND V2.COD_TP_MSG_CRITICA = 1 ) AND NOT EXISTS ( SELECT 1 FROM SEGUROS.VG_CRITICA_PROPOSTA V5 WHERE V5.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND V5.STA_CRITICA IN ( '0' , '1' , '2' , '3' , '4' , '5' , '8' ) ) END-EXEC. */

            var r3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1_Query1 = new R3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1_Query1.Execute(r3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTD_ERRO_VANEA, WS_QTD_ERRO_VANEA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3150-00-INSERIR-MSG-INFOR-SECTION */
        private void R3150_00_INSERIR_MSG_INFOR_SECTION()
        {
            /*" -1739- MOVE 3150 TO WNR-EXEC-SQL. */
            _.Move(3150, WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1741- DISPLAY PARAGRAFO */
            

            /*" -1742- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -1743- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -1744- MOVE V0PROP-NRCERTIF TO LK-VG001-NUM-CERTIFICADO */
            _.Move(V0PROP_NRCERTIF, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -1745- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -1746- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -1747- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -1748- MOVE 7 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(7, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -1749- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -1750- MOVE 'VA0458B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0458B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -1751- MOVE '7' TO LK-VG001-STA-CRITICA */
            _.Move("7", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -1752- MOVE 70 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(70, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -1754- MOVE WS-MSG-INFORMATIVA TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move(WS_MSG_INFORMATIVA, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -1756- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -1757- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS AND +1 */

            if (!SPVG001W.LK_VG001_IND_ERRO.In("00", "+1"))
            {

                /*" -1758- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -1759- DISPLAY '* R3150-PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R3150-PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -1760- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -1761- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -1762- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -1763- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -1764- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -1765- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -1766- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -1768- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -1769- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1770- END-IF */
            }


            /*" -1770- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/

        [StopWatch]
        /*" R3170-00-UPDATE-PROPOVA-SECTION */
        private void R3170_00_UPDATE_PROPOVA_SECTION()
        {
            /*" -1780- MOVE '3170' TO WNR-EXEC-SQL */
            _.Move("3170", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1786- PERFORM R3170_00_UPDATE_PROPOVA_DB_UPDATE_1 */

            R3170_00_UPDATE_PROPOVA_DB_UPDATE_1();

            /*" -1789- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1790- DISPLAY 'R3170- ATIVAR PROPOSTA_VA PARA EMISSAO' */
                _.Display($"R3170- ATIVAR PROPOSTA_VA PARA EMISSAO");

                /*" -1791- DISPLAY 'R3170- SQLCODE  - ' SQLCODE */
                _.Display($"R3170- SQLCODE  - {DB.SQLCODE}");

                /*" -1792- DISPLAY 'R3170- NRCERTIF - ' V0PROP-NRCERTIF */
                _.Display($"R3170- NRCERTIF - {V0PROP_NRCERTIF}");

                /*" -1793- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1794- END-IF */
            }


            /*" -1794- . */

        }

        [StopWatch]
        /*" R3170-00-UPDATE-PROPOVA-DB-UPDATE-1 */
        public void R3170_00_UPDATE_PROPOVA_DB_UPDATE_1()
        {
            /*" -1786- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '0' , TIMESTAMP = CURRENT TIMESTAMP, COD_USUARIO = 'VA0458B' WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF END-EXEC */

            var r3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 = new R3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1.Execute(r3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-CONS-DPS-INCONCLUSIVO-SECTION */
        private void R3200_00_CONS_DPS_INCONCLUSIVO_SECTION()
        {
            /*" -1806- MOVE 3200 TO WNR-EXEC-SQL. */
            _.Move(3200, WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1808- DISPLAY PARAGRAFO */
            

            /*" -1811- MOVE ZEROS TO WS-STA-INCONCLUSIVO */
            _.Move(0, WS_STA_INCONCLUSIVO);

            /*" -1818- PERFORM R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1 */

            R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1();

            /*" -1821- IF SQLCODE NOT EQUAL ZEROES AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -1822- DISPLAY 'R3200 - SELECT VG_DPS_PROPOSTA' */
                _.Display($"R3200 - SELECT VG_DPS_PROPOSTA");

                /*" -1823- DISPLAY 'R3200 - SQLCODE  - ' SQLCODE */
                _.Display($"R3200 - SQLCODE  - {DB.SQLCODE}");

                /*" -1825- DISPLAY 'R3200 - NRCERTIF - ' V0PROP-NRCERTIF */
                _.Display($"R3200 - NRCERTIF - {V0PROP_NRCERTIF}");

                /*" -1826- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1828- END-IF */
            }


            /*" -1828- . */

        }

        [StopWatch]
        /*" R3200-00-CONS-DPS-INCONCLUSIVO-DB-SELECT-1 */
        public void R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1()
        {
            /*" -1818- EXEC SQL SELECT COUNT(*) INTO :WS-STA-INCONCLUSIVO FROM SEGUROS.VG_DPS_PROPOSTA A WHERE A.NUM_PROPOSTA = :V0PROP-NRCERTIF AND A.STA_DPS_PROPOSTA = 7 WITH UR END-EXEC. */

            var r3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1 = new R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1.Execute(r3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_STA_INCONCLUSIVO, WS_STA_INCONCLUSIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-CALCULA-DT-FINAL-SECTION */
        private void R3210_00_CALCULA_DT_FINAL_SECTION()
        {
            /*" -1839- MOVE 3210 TO WNR-EXEC-SQL. */
            _.Move(3210, WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1841- DISPLAY PARAGRAFO */
            

            /*" -1843- MOVE SPACES TO WHOST-DTFINAL-06 */
            _.Move("", WHOST_DTFINAL_06);

            /*" -1849- PERFORM R3210_00_CALCULA_DT_FINAL_DB_SELECT_1 */

            R3210_00_CALCULA_DT_FINAL_DB_SELECT_1();

            /*" -1852- IF SQLCODE NOT EQUAL ZEROES AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -1853- DISPLAY 'R3200 - ERRO NO CALCULO DE DATA ' */
                _.Display($"R3200 - ERRO NO CALCULO DE DATA ");

                /*" -1854- DISPLAY 'R3200 - SQLCODE  - ' SQLCODE */
                _.Display($"R3200 - SQLCODE  - {DB.SQLCODE}");

                /*" -1855- DISPLAY 'R3200 - V1SIST-DTMOVABE-30 - ' V0PROP-NRCERTIF */
                _.Display($"R3200 - V1SIST-DTMOVABE-30 - {V0PROP_NRCERTIF}");

                /*" -1857- DISPLAY 'R3200 - DIAS-ANTECIPACAO - ' AC-DIAS-ANTECIPACAO */
                _.Display($"R3200 - DIAS-ANTECIPACAO - {WORK_AREA.AC_DIAS_ANTECIPACAO}");

                /*" -1858- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1860- END-IF */
            }


            /*" -1860- . */

        }

        [StopWatch]
        /*" R3210-00-CALCULA-DT-FINAL-DB-SELECT-1 */
        public void R3210_00_CALCULA_DT_FINAL_DB_SELECT_1()
        {
            /*" -1849- EXEC SQL SELECT (DATE(:V1SIST-DTMOVABE-30) - :AC-DIAS-ANTECIPACAO DAYS) INTO :WHOST-DTFINAL-06 FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC. */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT (DATE(:V1SIST-DTMOVABE-30) -
            /*--:AC-DIAS-ANTECIPACAO DAYS)
            /*--INTO :WHOST-DTFINAL-06
            /*--FROM SYSIBM.SYSDUMMY1
            /*--WITH UR
            /*--END-EXEC.
            /*-- */

            _.Move(V1SIST_DTMOVABE_30.ToDateTime().AddDays(WORK_AREA.AC_DIAS_ANTECIPACAO).ToString(_.CurrentDateFormat), WHOST_DTFINAL_06);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1873- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1874- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1875- DISPLAY '*   VA0458B - MOVIMENTO     DO     DIA     *' */
            _.Display($"*   VA0458B - MOVIMENTO     DO     DIA     *");

            /*" -1876- DISPLAY '*   -------   ---------------------------  *' */
            _.Display($"*   -------   ---------------------------  *");

            /*" -1877- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1878- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -1879- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -1880- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1880- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1894- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1896- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1896- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1898- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1902- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1902- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}