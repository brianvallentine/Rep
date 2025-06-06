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
using Sias.Emissao.DB2.EM0015B;

namespace Code
{
    public class EM0015B
    {
        public bool IsCall { get; set; }

        public EM0015B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  EM0015B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  NOVEMBRO/1995                      *      */
        /*"      *   VERSAO .................  02012009 17:00HS                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - GERACAO DAS TABELAS 0APOLCOB,   *       */
        /*"      *                               V0MOVDEBCC_CEF E V0APOLINDICA    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTERACAO DA COLUNA COD_CONVENIO *      */
        /*"      *                               DE SMALLINT PARA INTEGER.        *      */
        /*"      *               LIANE PONTES  -  LP0301   EM:  14/03/2001.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTERACAO PARA TRATAR OS RAMOS   *      */
        /*"      *                               40 E 67.                         *      */
        /*"      *               FERNANDO      - LF1610    EM:  16/10/2003.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTERACAO PARA TRATAR O PRODUTO  *      */
        /*"      *                               1803 (MULTIRRISCO LOTERICO)      *      */
        /*"      *               FERNANDO      - LF1501    EM:  15/01/2004.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTERACAO PARA TRATAR O PRODUTO  *      */
        /*"      *                               1803 (MULTIRRISCO LOTERICO)      *      */
        /*"      *                               ED2901    EM:  29/01/2004.       *      */
        /*"      *                               EDUARDO (PRODEXTER)              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTERACAO PARA TRATAR O PRODUTO  *      */
        /*"      *                               1804 (MULTIRRISCO EMPRESARIAL)   *      */
        /*"      *                               FC0703    EM:  20/03/2007.       *      */
        /*"      *                               FAST COMPUTER                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CORRECAO   .............  - ABEND -310 DIARIA DIA 01/04/2008 *      */
        /*"      *                               CD9277    EM   03/04/2007        *      */
        /*"      *                               GEFAB:    FERNANDO               *      */
        /*"V.01  *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTO FACIL                       *      */
        /*"      *                               V.01      EM:  19/04/2013.       *      */
        /*"      *                               COREON                           *      */
        /*"V.01  *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - CORRESPONDENTE CAIXA AQUI        *      */
        /*"      *                               INCLUSAO PRODUTO CCA - 1805.     *      */
        /*"      *                               09/09/2013 - GUILHERME CORREIA.  *      */
        /*"      *                                    PROCURAR: GUI               *      */
        /*"V.02  *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTO FACIL                       *      */
        /*"      *                               V.02 - COREON EM 17/10/2013.     *      */
        /*"      *                               NAO GERAR MOVDEBCC_CEF QUANDO    *      */
        /*"      *                               ADESAO CARTAO, PARA 1A. PARCELA. *      */
        /*"V.03  *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTO FACIL - CADMUS 74.582       *      */
        /*"      *                               COREON EM 27/03/2014 - (V.03)    *      */
        /*"      *                               GERAR MOVDEBCC_CEF ADESAO (3)    *      */
        /*"      *                               DEBITO DEMAIS BANCOS, SOMENTE    *      */
        /*"      *                               PARA DEMAIS PARCELAS.            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 4.0  - NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"V.05  *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - DEMANDA 455132                   *      */
        /*"      *                               HUSNI ALI HUSNI                  *      */
        /*"      *                               24/02/2023                       *      */
        /*"      *                               ESPECIFICACAO DOS CAMPOS NO      *      */
        /*"      *                               MOMENTO DA EXECUCAO DE INCLUSAO  *      */
        /*"      *                               DA TABELE MOVTO_DEBITOCC_CEF     *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      *                                     V0PROPCOB         INPUT    *      */
        /*"      *                                     V0ENDOSSO         INPUT    *      */
        /*"      *                                     V0PROPOSTA        INPUT    *      */
        /*"      *                                     V0PARAM_CONTACEF  INPUT    *      */
        /*"      *                                     V0PARCELA         INPUT    *      */
        /*"      *                                     V0HISTOPARC       INPUT    *      */
        /*"      *                                     V0FUNCIOCEF       INPUT    *      */
        /*"      *                                     V0PRODUTOR        INPUT    *      */
        /*"      *                                     V0EMISDIARIA      I-O      *      */
        /*"      *                                     V0APOLINDICA      I-O      *      */
        /*"      *                                     V0APOLCOB         OUTPUT   *      */
        /*"      *                                     V0MOVDEBCC_CEF    OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 25/04/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V1SISTE-IDSISTEM             PIC X(2).*/
        public StringBasis V1SISTE_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"77  V1SISTE-DTMOVABE             PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0EMISD-CODRELAT             PIC X(8).*/
        public StringBasis V0EMISD_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77  V0EMISD-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0EMISD_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0EMISD-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0EMISD_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0EMISD-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0EMISD_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0EMISD-DTMOVTO              PIC X(10).*/
        public StringBasis V0EMISD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0EMISD-SITUACAO             PIC X(1).*/
        public StringBasis V0EMISD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0ENDOS-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0ENDOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0ENDOS-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0ENDOS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0ENDOS-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0ENDOS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0ENDOS-NRPROPOS             PIC S9(09) COMP.*/
        public IntBasis V0ENDOS_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0ENDOS-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0ENDOS_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0ENDOS-DTINIVIG             PIC  X(10).*/
        public StringBasis V0ENDOS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ENDOS-DTTERVIG             PIC  X(10).*/
        public StringBasis V0ENDOS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ENDOS-TIPO-ENDOSSO         PIC  X(01).*/
        public StringBasis V0ENDOS_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0ENDOS-COD-PRODUTO          PIC S9(04) COMP.*/
        public IntBasis V0ENDOS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPO-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0PROPO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPO-NRPROPOS             PIC S9(09) COMP.*/
        public IntBasis V0PROPO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PROPO-AGECOBR              PIC S9(04) COMP.*/
        public IntBasis V0PROPO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPO-RAMO                 PIC S9(04) COMP.*/
        public IntBasis V0PROPO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0PROPC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-NRPROPOS             PIC S9(09) COMP.*/
        public IntBasis V0PROPC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PROPC-CODPRODU             PIC S9(04) COMP.*/
        public IntBasis V0PROPC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-NUM-MATRICULA        PIC S9(15) COMP-3.*/
        public IntBasis V0PROPC_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0PROPC-COD-AGENCIA          PIC S9(04) COMP.*/
        public IntBasis V0PROPC_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-OPERACAO-CONTA       PIC S9(04) COMP.*/
        public IntBasis V0PROPC_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-NUM-CONTA            PIC S9(13) COMP-3.*/
        public IntBasis V0PROPC_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PROPC-DIG-CONTA            PIC S9(04) COMP.*/
        public IntBasis V0PROPC_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-TIPO-COBRANCA        PIC X(1).*/
        public StringBasis V0PROPC_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0PROPC-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V0PROPC_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-OPER-CONTA-DEB       PIC S9(04) COMP.*/
        public IntBasis V0PROPC_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-NUM-CONTA-DEB        PIC S9(13) COMP-3.*/
        public IntBasis V0PROPC_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PROPC-DIG-CONTA-DEB        PIC S9(04) COMP.*/
        public IntBasis V0PROPC_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0PROPC_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROPC-NRCERTIF-AUTO        PIC X(25).*/
        public StringBasis V0PROPC_NRCERTIF_AUTO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"77  V0PROPC-NUM-CARTAO           PIC S9(16) COMP-3.*/
        public IntBasis V0PROPC_NUM_CARTAO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"77  V0PROPC-MARGEM-COMERCIAL     PIC S9(03)V99  COMP-3.*/
        public DoubleBasis V0PROPC_MARGEM_COMERCIAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"77  V0PARAMC-TIPO-MOVTOCC         PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_TIPO_MOVTOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-CODPRODU             PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0PARAMC_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HISTO-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0HISTO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0HISTO-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0HISTO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HISTO-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0HISTO_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HISTO-DTMOVTO              PIC X(10).*/
        public StringBasis V0HISTO_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HISTO-OPERACAO             PIC S9(04) COMP.*/
        public IntBasis V0HISTO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HISTO-VLPRMTOT             PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0HISTO_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0HISTO-DTVENCTO             PIC X(10).*/
        public StringBasis V0HISTO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PARCE-SITUACAO             PIC X(1).*/
        public StringBasis V0PARCE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0APOLC-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0APOLC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0APOLC-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0APOLC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0APOLC_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0APOLC-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0APOLC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0APOLC-CODPRODU             PIC S9(04) COMP.*/
        public IntBasis V0APOLC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-NUM-MATRICULA        PIC S9(15) COMP-3.*/
        public IntBasis V0APOLC_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0APOLC-TIPO-COBRANCA        PIC X(1).*/
        public StringBasis V0APOLC_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0APOLC-AGECOBR              PIC S9(04) COMP.*/
        public IntBasis V0APOLC_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-COD-AGENCIA          PIC S9(04) COMP.*/
        public IntBasis V0APOLC_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-OPER-CONTA           PIC S9(04) COMP.*/
        public IntBasis V0APOLC_OPER_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-NUM-CONTA            PIC S9(13) COMP-3.*/
        public IntBasis V0APOLC_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0APOLC-DIG-CONTA            PIC S9(04) COMP.*/
        public IntBasis V0APOLC_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V0APOLC_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-OPER-CONTA-DEB       PIC S9(04) COMP.*/
        public IntBasis V0APOLC_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-NUM-CONTA-DEB        PIC S9(13) COMP-3.*/
        public IntBasis V0APOLC_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0APOLC-DIG-CONTA-DEB        PIC S9(04) COMP.*/
        public IntBasis V0APOLC_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-NUM-CARTAO           PIC S9(16)     COMP-3.*/
        public IntBasis V0APOLC_NUM_CARTAO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"77  V0APOLC-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0APOLC_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOLC-NRCERTIF-AUTO        PIC X(25).*/
        public StringBasis V0APOLC_NRCERTIF_AUTO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"77  V0APOLC-MARGEM-COMERCIAL     PIC S9(03)V99  COMP-3.*/
        public DoubleBasis V0APOLC_MARGEM_COMERCIAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"77  V0MOVDE-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
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
        /*"77  V0MOVDE-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-VLR-DEBITO           PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0MOVDE_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0MOVDE-VLR-CREDITO          PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0MOVDE_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0MOVDE-VLR-CREDITO-NULL     PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_VLR_CREDITO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-COD-AGENCIA-DEB-NULL PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_AGENCIA_DEB_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-OPER-CONTA-DEB       PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-OPER-CONTA-DEB-NULL  PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_OPER_CONTA_DEB_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NUM-CONTA-DEB        PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-NUM-CONTA-DEB-NULL   PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_NUM_CONTA_DEB_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-DIG-CONTA-DEB        PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-DIG-CONTA-DEB-NULL   PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIG_CONTA_DEB_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
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
        /*"77  V0MOVDE-NUM-REQUISICAO       PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-NUM-CARTAO           PIC S9(16) COMP-3.*/
        public IntBasis V0MOVDE_NUM_CARTAO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"77  V0MOVDE-NUM-CARTAO-NULL      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_NUM_CARTAO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-SEQUENCIA            PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NUM-LOTE             PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MOVDE-DTCREDITO            PIC X(10).*/
        public StringBasis V0MOVDE_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTCREDITO-NULL       PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DTCREDITO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-STATUS-CARTAO        PIC X(02).*/
        public StringBasis V0MOVDE_STATUS_CARTAO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77  V0MOVDE-STATUS-CARTAO-NULL   PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_STATUS_CARTAO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOIN-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0APOIN_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0APOIN-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0APOIN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOIN-NRPROPOS             PIC S9(09) COMP.*/
        public IntBasis V0APOIN_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0APOIN-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0APOIN_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0APOIN-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0APOIN_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0APOIN-TIPOFUNC             PIC  X(01).*/
        public StringBasis V0APOIN_TIPOFUNC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0APOIN-DTINIVIG             PIC  X(10).*/
        public StringBasis V0APOIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0APOIN-DTTERVIG             PIC  X(10).*/
        public StringBasis V0APOIN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0APOIN-PERCOMIS-FUN         PIC S9(03)V9(2) COMP-3.*/
        public DoubleBasis V0APOIN_PERCOMIS_FUN { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(2)"), 2);
        /*"77  V0APOIN-NUM-MATRICULA        PIC S9(15) COMP-3.*/
        public IntBasis V0APOIN_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0APOIN-FORMAPGTO            PIC  X(01).*/
        public StringBasis V0APOIN_FORMAPGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0APOIN-COD-AGENCIA          PIC S9(04) COMP.*/
        public IntBasis V0APOIN_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOIN-OPERACAO-CONTA       PIC S9(04) COMP.*/
        public IntBasis V0APOIN_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0APOIN-NUM-CONTA            PIC S9(13) COMP-3.*/
        public IntBasis V0APOIN_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0APOIN-DIG-CONTA            PIC S9(04) COMP.*/
        public IntBasis V0APOIN_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PRODU-CODPDT               PIC S9(09) COMP.*/
        public IntBasis V0PRODU_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PRODU-CHPFUN               PIC S9(15) COMP-3.*/
        public IntBasis V0PRODU_CHPFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0FUNCI-NUM-MATRICULA        PIC S9(15) COMP-3.*/
        public IntBasis V0FUNCI_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0FUNCI-COD-ANGARIADOR       PIC S9(09) COMP.*/
        public IntBasis V0FUNCI_COD_ANGARIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0FUNCI-COD-AGENCIA          PIC S9(04) COMP.*/
        public IntBasis V0FUNCI_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0FUNCI-OPERACAO-CONTA       PIC S9(04) COMP.*/
        public IntBasis V0FUNCI_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0FUNCI-NUM-CONTA            PIC S9(13) COMP-3.*/
        public IntBasis V0FUNCI_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0FUNCI-DIG-CONTA            PIC S9(04) COMP.*/
        public IntBasis V0FUNCI_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PRODE-COD-ESCNEG           PIC S9(04) COMP.*/
        public IntBasis V0PRODE_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PRODE-DATA-INIVIGENCIA     PIC X(10).*/
        public StringBasis V0PRODE_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PRODE-DATA-TERVIGENCIA     PIC X(10).*/
        public StringBasis V0PRODE_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PRODE-NUM-MATRICULA        PIC S9(15) COMP-3.*/
        public IntBasis V0PRODE_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0AGENC-COD-AGENCIA          PIC S9(04) COMP.*/
        public IntBasis V0AGENC_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AGENC-COD-ESCNEG           PIC S9(04) COMP.*/
        public IntBasis V0AGENC_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PRODG-COD-AGENCIA          PIC S9(04) COMP.*/
        public IntBasis V0PRODG_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PRODG-COD-PROD-GERENTE     PIC S9(09) COMP.*/
        public IntBasis V0PRODG_COD_PROD_GERENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PRODG-DATA-INIVIGENCIA     PIC X(10).*/
        public StringBasis V0PRODG_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PRODG-DATA-TERVIGENCIA     PIC X(10).*/
        public StringBasis V0PRODG_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  VIND-NUM-TITULO              PIC S9(04) COMP.*/
        public IntBasis VIND_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WHOST-NUM-APOLICE            PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  WHOST-NUM-ENDOSSO            PIC S9(09) COMP.*/
        public IntBasis WHOST_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01           AREA-DE-WORK.*/
        public EM0015B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0015B_AREA_DE_WORK();
        public class EM0015B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WDATA-VENCTO.*/
            public EM0015B_WDATA_VENCTO WDATA_VENCTO { get; set; } = new EM0015B_WDATA_VENCTO();
            public class EM0015B_WDATA_VENCTO : VarBasis
            {
                /*"    10       WANO-VENCTO          PIC  9(004).*/
                public IntBasis WANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER               PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WMES-VENCTO          PIC  9(002).*/
                public IntBasis WMES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER               PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDIA-VENCTO          PIC  9(002).*/
                public IntBasis WDIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WFIMV1SISTEMA        PIC  X(001)    VALUE SPACES.*/
            }
            public StringBasis WFIMV1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0EMISDIARIA     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0EMISDIARIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0HISTOPARC      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0APOLINDICA     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0APOLINDICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-PROPCOB         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PROPCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTOTEMISD            PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTEMISD { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTAPOLC            PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTAPOLC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTMOVDE            PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTMOVDE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        WABEND.*/
            public EM0015B_WABEND WABEND { get; set; } = new EM0015B_WABEND();
            public class EM0015B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' EM0015B'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0015B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  05        WPARAGRAFO          PIC  X(040)    VALUE SPACES.*/
            }
            public StringBasis WPARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        }


        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.AU085 AU085 { get; set; } = new Dclgens.AU085();
        public EM0015B_V0EMISDIARIA V0EMISDIARIA { get; set; } = new EM0015B_V0EMISDIARIA();
        public EM0015B_V0HISTOPARC V0HISTOPARC { get; set; } = new EM0015B_V0HISTOPARC();
        public EM0015B_V0APOLINDICA V0APOLINDICA { get; set; } = new EM0015B_V0APOLINDICA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -353- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -356- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -359- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -359- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -367- PERFORM R0010-00-SELECT-V1SISTEMA */

            R0010_00_SELECT_V1SISTEMA_SECTION();

            /*" -368- IF WFIMV1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIMV1SISTEMA.IsEmpty())
            {

                /*" -370- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -372- PERFORM R0020-00-DECLARE-V0EMISDIARIA */

            R0020_00_DECLARE_V0EMISDIARIA_SECTION();

            /*" -374- PERFORM R0030-00-DECLARE-V0HISTOPARC */

            R0030_00_DECLARE_V0HISTOPARC_SECTION();

            /*" -376- PERFORM R0035-00-DECLARE-V0APOLINDICA */

            R0035_00_DECLARE_V0APOLINDICA_SECTION();

            /*" -378- PERFORM R0040-00-ABRE-V0EMISDIARIA */

            R0040_00_ABRE_V0EMISDIARIA_SECTION();

            /*" -379- PERFORM R0050-00-PROCESSA-V0EMISDIARIA UNTIL WFIMV0EMISDIARIA = 'S' . */

            while (!(AREA_DE_WORK.WFIMV0EMISDIARIA == "S"))
            {

                R0050_00_PROCESSA_V0EMISDIARIA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -384- IF WTOTEMISD > 0 */

            if (AREA_DE_WORK.WTOTEMISD > 0)
            {

                /*" -385- DISPLAY 'LIDOS NA EMISDIARIA........' WTOTEMISD */
                _.Display($"LIDOS NA EMISDIARIA........{AREA_DE_WORK.WTOTEMISD}");

                /*" -386- DISPLAY 'INCLUIDOS NA APOLCOB.......' WTOTAPOLC */
                _.Display($"INCLUIDOS NA APOLCOB.......{AREA_DE_WORK.WTOTAPOLC}");

                /*" -387- DISPLAY 'INCLUIDOS NA MOVDEBCC_CEF..' WTOTMOVDE */
                _.Display($"INCLUIDOS NA MOVDEBCC_CEF..{AREA_DE_WORK.WTOTMOVDE}");

                /*" -388- DISPLAY ' ' */
                _.Display($" ");

                /*" -389- ELSE */
            }
            else
            {


                /*" -390- DISPLAY '******************************' */
                _.Display($"******************************");

                /*" -391- DISPLAY '* EM0015B - SEM MOVIMENTACAO *' */
                _.Display($"* EM0015B - SEM MOVIMENTACAO *");

                /*" -392- DISPLAY '******************************' . */
                _.Display($"******************************");
            }


            /*" -394- DISPLAY ' ' */
            _.Display($" ");

            /*" -394- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -397- DISPLAY '*************************************' */
            _.Display($"*************************************");

            /*" -398- DISPLAY '*                                   *' */
            _.Display($"*                                   *");

            /*" -399- DISPLAY '* EM0015B - TERMINO NORMAL DE       *' */
            _.Display($"* EM0015B - TERMINO NORMAL DE       *");

            /*" -400- DISPLAY '*             PROCESSAMENTO         *' */
            _.Display($"*             PROCESSAMENTO         *");

            /*" -401- DISPLAY '*                                   *' */
            _.Display($"*                                   *");

            /*" -403- DISPLAY '*************************************' */
            _.Display($"*************************************");

            /*" -405- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -405- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-SECTION */
        private void R0010_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -416- MOVE 'R0010-00-SELECT-V1SISTEMA' TO WPARAGRAFO */
            _.Move("R0010-00-SELECT-V1SISTEMA", AREA_DE_WORK.WPARAGRAFO);

            /*" -418- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -423- PERFORM R0010_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0010_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -426- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -427- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -428- DISPLAY 'EM0015B - SISTEMA (EM) NAO CADASTRADO' */
                    _.Display($"EM0015B - SISTEMA (EM) NAO CADASTRADO");

                    /*" -429- MOVE 'S' TO WFIMV1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIMV1SISTEMA);

                    /*" -430- GO TO R0010-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/ //GOTO
                    return;

                    /*" -431- ELSE */
                }
                else
                {


                    /*" -432- DISPLAY 'EM0015B - ' WPARAGRAFO */
                    _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -432- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0010_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -423- EXEC SQL SELECT DTMOVABE INTO :V1SISTE-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTE_DTMOVABE, V1SISTE_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-DECLARE-V0EMISDIARIA-SECTION */
        private void R0020_00_DECLARE_V0EMISDIARIA_SECTION()
        {
            /*" -441- MOVE 'R0020-00-DECLARE-V0EMISDIARIA' TO WPARAGRAFO */
            _.Move("R0020-00-DECLARE-V0EMISDIARIA", AREA_DE_WORK.WPARAGRAFO);

            /*" -443- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -451- PERFORM R0020_00_DECLARE_V0EMISDIARIA_DB_DECLARE_1 */

            R0020_00_DECLARE_V0EMISDIARIA_DB_DECLARE_1();

        }

        [StopWatch]
        /*" R0020-00-DECLARE-V0EMISDIARIA-DB-DECLARE-1 */
        public void R0020_00_DECLARE_V0EMISDIARIA_DB_DECLARE_1()
        {
            /*" -451- EXEC SQL DECLARE V0EMISDIARIA CURSOR FOR SELECT NUM_APOLICE, NRENDOS, NRPARCEL FROM SEGUROS.V0EMISDIARIA WHERE CODRELAT = :V0EMISD-CODRELAT AND DTMOVTO = :V0EMISD-DTMOVTO AND SITUACAO = :V0EMISD-SITUACAO END-EXEC. */
            V0EMISDIARIA = new EM0015B_V0EMISDIARIA(true);
            string GetQuery_V0EMISDIARIA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL 
							FROM SEGUROS.V0EMISDIARIA 
							WHERE CODRELAT = '{V0EMISD_CODRELAT}' 
							AND DTMOVTO = '{V0EMISD_DTMOVTO}' 
							AND SITUACAO = '{V0EMISD_SITUACAO}'";

                return query;
            }
            V0EMISDIARIA.GetQueryEvent += GetQuery_V0EMISDIARIA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-DECLARE-V0HISTOPARC-SECTION */
        private void R0030_00_DECLARE_V0HISTOPARC_SECTION()
        {
            /*" -460- MOVE 'R0030-00-DECLARE-V0HISTOPARC ' TO WPARAGRAFO */
            _.Move("R0030-00-DECLARE-V0HISTOPARC ", AREA_DE_WORK.WPARAGRAFO);

            /*" -462- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -478- PERFORM R0030_00_DECLARE_V0HISTOPARC_DB_DECLARE_1 */

            R0030_00_DECLARE_V0HISTOPARC_DB_DECLARE_1();

        }

        [StopWatch]
        /*" R0030-00-DECLARE-V0HISTOPARC-DB-DECLARE-1 */
        public void R0030_00_DECLARE_V0HISTOPARC_DB_DECLARE_1()
        {
            /*" -478- EXEC SQL DECLARE V0HISTOPARC CURSOR FOR SELECT A.NRPARCEL, A.DTMOVTO, A.VLPRMTOT, A.DTVENCTO FROM SEGUROS.V0HISTOPARC A, SEGUROS.V0PARCELA B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.NRENDOS = B.NRENDOS AND A.NRPARCEL = B.NRPARCEL AND A.NUM_APOLICE = :V0HISTO-NUM-APOLICE AND A.NRENDOS = :V0HISTO-NRENDOS AND A.NRPARCEL >= :V0HISTO-NRPARCEL AND A.OPERACAO = :V0HISTO-OPERACAO AND B.SITUACAO = :V0PARCE-SITUACAO END-EXEC. */
            V0HISTOPARC = new EM0015B_V0HISTOPARC(true);
            string GetQuery_V0HISTOPARC()
            {
                var query = @$"SELECT 
							A.NRPARCEL
							, 
							A.DTMOVTO
							, 
							A.VLPRMTOT
							, 
							A.DTVENCTO 
							FROM SEGUROS.V0HISTOPARC A
							, 
							SEGUROS.V0PARCELA B 
							WHERE A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NRENDOS = B.NRENDOS 
							AND A.NRPARCEL = B.NRPARCEL 
							AND A.NUM_APOLICE = '{V0HISTO_NUM_APOLICE}' 
							AND A.NRENDOS = '{V0HISTO_NRENDOS}' 
							AND A.NRPARCEL >= '{V0HISTO_NRPARCEL}' 
							AND A.OPERACAO = '{V0HISTO_OPERACAO}' 
							AND B.SITUACAO = '{V0PARCE_SITUACAO}'";

                return query;
            }
            V0HISTOPARC.GetQueryEvent += GetQuery_V0HISTOPARC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/

        [StopWatch]
        /*" R0035-00-DECLARE-V0APOLINDICA-SECTION */
        private void R0035_00_DECLARE_V0APOLINDICA_SECTION()
        {
            /*" -487- MOVE 'R00350-00-DECLARE-V0APOLINDICA' TO WPARAGRAFO */
            _.Move("R00350-00-DECLARE-V0APOLINDICA", AREA_DE_WORK.WPARAGRAFO);

            /*" -489- MOVE '035' TO WNR-EXEC-SQL. */
            _.Move("035", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -500- PERFORM R0035_00_DECLARE_V0APOLINDICA_DB_DECLARE_1 */

            R0035_00_DECLARE_V0APOLINDICA_DB_DECLARE_1();

        }

        [StopWatch]
        /*" R0035-00-DECLARE-V0APOLINDICA-DB-DECLARE-1 */
        public void R0035_00_DECLARE_V0APOLINDICA_DB_DECLARE_1()
        {
            /*" -500- EXEC SQL DECLARE V0APOLINDICA CURSOR FOR SELECT FONTE, NRPROPOS, DTINIVIG, DTTERVIG, TIPOFUNC FROM SEGUROS.V0APOLINDICA WHERE FONTE = :V0APOIN-FONTE AND NRPROPOS = :V0APOIN-NRPROPOS ORDER BY 5 END-EXEC. */
            V0APOLINDICA = new EM0015B_V0APOLINDICA(true);
            string GetQuery_V0APOLINDICA()
            {
                var query = @$"SELECT 
							FONTE
							, 
							NRPROPOS
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							TIPOFUNC 
							FROM SEGUROS.V0APOLINDICA 
							WHERE FONTE = '{V0APOIN_FONTE}' 
							AND NRPROPOS = '{V0APOIN_NRPROPOS}' 
							ORDER BY 5";

                return query;
            }
            V0APOLINDICA.GetQueryEvent += GetQuery_V0APOLINDICA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_99_SAIDA*/

        [StopWatch]
        /*" R0040-00-ABRE-V0EMISDIARIA-SECTION */
        private void R0040_00_ABRE_V0EMISDIARIA_SECTION()
        {
            /*" -509- MOVE 'R0040-00-ABRE-V0EMISDIARIA   ' TO WPARAGRAFO */
            _.Move("R0040-00-ABRE-V0EMISDIARIA   ", AREA_DE_WORK.WPARAGRAFO);

            /*" -511- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -513- MOVE SPACES TO WFIMV0EMISDIARIA */
            _.Move("", AREA_DE_WORK.WFIMV0EMISDIARIA);

            /*" -514- MOVE 'EM0015B1' TO V0EMISD-CODRELAT */
            _.Move("EM0015B1", V0EMISD_CODRELAT);

            /*" -515- MOVE V1SISTE-DTMOVABE TO V0EMISD-DTMOVTO */
            _.Move(V1SISTE_DTMOVABE, V0EMISD_DTMOVTO);

            /*" -517- MOVE ZEROS TO V0EMISD-SITUACAO */
            _.Move(0, V0EMISD_SITUACAO);

            /*" -517- PERFORM R0040_00_ABRE_V0EMISDIARIA_DB_OPEN_1 */

            R0040_00_ABRE_V0EMISDIARIA_DB_OPEN_1();

            /*" -520- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -521- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -521- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0040-00-ABRE-V0EMISDIARIA-DB-OPEN-1 */
        public void R0040_00_ABRE_V0EMISDIARIA_DB_OPEN_1()
        {
            /*" -517- EXEC SQL OPEN V0EMISDIARIA END-EXEC. */

            V0EMISDIARIA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-PROCESSA-V0EMISDIARIA-SECTION */
        private void R0050_00_PROCESSA_V0EMISDIARIA_SECTION()
        {
            /*" -531- PERFORM R0060-00-LE-V0EMISDIARIA */

            R0060_00_LE_V0EMISDIARIA_SECTION();

            /*" -532- IF WFIMV0EMISDIARIA = 'S' */

            if (AREA_DE_WORK.WFIMV0EMISDIARIA == "S")
            {

                /*" -534- GO TO R0050-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/ //GOTO
                return;
            }


            /*" -536- PERFORM R0070-00-LE-V0ENDOSSO */

            R0070_00_LE_V0ENDOSSO_SECTION();

            /*" -537- MOVE ' ' TO WTEM-PROPCOB. */
            _.Move(" ", AREA_DE_WORK.WTEM_PROPCOB);

            /*" -540- PERFORM R0080-00-LE-V0PROPCOB */

            R0080_00_LE_V0PROPCOB_SECTION();

            /*" -541- IF WTEM-PROPCOB EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_PROPCOB == "N")
            {

                /*" -543- GO TO R0050-90-UPDATE. */

                R0050_90_UPDATE(); //GOTO
                return;
            }


            /*" -545- PERFORM R0090-00-LE-V0PROPOSTA */

            R0090_00_LE_V0PROPOSTA_SECTION();

            /*" -547- PERFORM R0100-00-INCLUI-V0APOLCOB */

            R0100_00_INCLUI_V0APOLCOB_SECTION();

            /*" -549- IF V0PROPC-TIPO-COBRANCA EQUAL '1' OR V0PROPC-TIPO-COBRANCA EQUAL '2' */

            if (V0PROPC_TIPO_COBRANCA == "1" || V0PROPC_TIPO_COBRANCA == "2")
            {

                /*" -556- IF V0PROPC-CODPRODU = 1403 OR V0PROPC-CODPRODU = 1404 OR V0PROPC-CODPRODU = 1601 OR V0PROPC-CODPRODU = 1801 OR V0PROPC-CODPRODU = 1602 OR V0PROPC-CODPRODU = 1802 OR V0PROPC-CODPRODU = 1804 */

                if (V0PROPC_CODPRODU == 1403 || V0PROPC_CODPRODU == 1404 || V0PROPC_CODPRODU == 1601 || V0PROPC_CODPRODU == 1801 || V0PROPC_CODPRODU == 1602 || V0PROPC_CODPRODU == 1802 || V0PROPC_CODPRODU == 1804)
                {

                    /*" -557- MOVE 600140 TO V0PARAMC-COD-CONVENIO */
                    _.Move(600140, V0PARAMC_COD_CONVENIO);

                    /*" -558- ELSE */
                }
                else
                {


                    /*" -559- IF V0PROPC-CODPRODU = 1805 */

                    if (V0PROPC_CODPRODU == 1805)
                    {

                        /*" -560- MOVE 600149 TO V0PARAMC-COD-CONVENIO */
                        _.Move(600149, V0PARAMC_COD_CONVENIO);

                        /*" -561- ELSE */
                    }
                    else
                    {


                        /*" -562- IF V0PROPC-CODPRODU = 1803 */

                        if (V0PROPC_CODPRODU == 1803)
                        {

                            /*" -563- MOVE 600121 TO V0PARAMC-COD-CONVENIO */
                            _.Move(600121, V0PARAMC_COD_CONVENIO);

                            /*" -564- ELSE */
                        }
                        else
                        {


                            /*" -565- PERFORM R0110-00-LE-V0PARAM-CONTACEF */

                            R0110_00_LE_V0PARAM_CONTACEF_SECTION();

                            /*" -566- ELSE */
                        }

                    }

                }

            }
            else
            {


                /*" -568- GO TO R0050-90-UPDATE. */

                R0050_90_UPDATE(); //GOTO
                return;
            }


            /*" -570- PERFORM R0120-00-ABRE-V0HISTOPARC */

            R0120_00_ABRE_V0HISTOPARC_SECTION();

            /*" -571- PERFORM R0130-00-PROCESSA-V0HISTOPARC UNTIL WFIMV0HISTOPARC = 'S' . */

            while (!(AREA_DE_WORK.WFIMV0HISTOPARC == "S"))
            {

                R0130_00_PROCESSA_V0HISTOPARC_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0050_90_UPDATE */

            R0050_90_UPDATE();

        }

        [StopWatch]
        /*" R0050-90-UPDATE */
        private void R0050_90_UPDATE(bool isPerform = false)
        {
            /*" -577- PERFORM R0150-00-UPDATE-V0EMISDIARIA. */

            R0150_00_UPDATE_V0EMISDIARIA_SECTION();

            /*" -578- IF V0PROPC-CODPRODU EQUAL 3101 OR 3102 */

            if (V0PROPC_CODPRODU.In("3101", "3102"))
            {

                /*" -579- PERFORM R0400-00-ABRE-V0APOLINDICA */

                R0400_00_ABRE_V0APOLINDICA_SECTION();

                /*" -580- PERFORM R0500-00-PROCESSA-COMISSAO UNTIL WFIMV0APOLINDICA = 'S' . */

                while (!(AREA_DE_WORK.WFIMV0APOLINDICA == "S"))
                {

                    R0500_00_PROCESSA_COMISSAO_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-LE-V0EMISDIARIA-SECTION */
        private void R0060_00_LE_V0EMISDIARIA_SECTION()
        {
            /*" -589- MOVE 'R0060-00-LE-V0EMISDIARIA     ' TO WPARAGRAFO */
            _.Move("R0060-00-LE-V0EMISDIARIA     ", AREA_DE_WORK.WPARAGRAFO);

            /*" -591- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -595- PERFORM R0060_00_LE_V0EMISDIARIA_DB_FETCH_1 */

            R0060_00_LE_V0EMISDIARIA_DB_FETCH_1();

            /*" -598- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -599- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -600- MOVE 'S' TO WFIMV0EMISDIARIA */
                    _.Move("S", AREA_DE_WORK.WFIMV0EMISDIARIA);

                    /*" -600- PERFORM R0060_00_LE_V0EMISDIARIA_DB_CLOSE_1 */

                    R0060_00_LE_V0EMISDIARIA_DB_CLOSE_1();

                    /*" -602- GO TO R0060-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/ //GOTO
                    return;

                    /*" -603- ELSE */
                }
                else
                {


                    /*" -604- DISPLAY 'EM0015B - ' WPARAGRAFO */
                    _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -606- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -606- COMPUTE WTOTEMISD = WTOTEMISD + 1. */
            AREA_DE_WORK.WTOTEMISD.Value = AREA_DE_WORK.WTOTEMISD + 1;

        }

        [StopWatch]
        /*" R0060-00-LE-V0EMISDIARIA-DB-FETCH-1 */
        public void R0060_00_LE_V0EMISDIARIA_DB_FETCH_1()
        {
            /*" -595- EXEC SQL FETCH V0EMISDIARIA INTO :V0EMISD-NUM-APOLICE, :V0EMISD-NRENDOS, :V0EMISD-NRPARCEL END-EXEC. */

            if (V0EMISDIARIA.Fetch())
            {
                _.Move(V0EMISDIARIA.V0EMISD_NUM_APOLICE, V0EMISD_NUM_APOLICE);
                _.Move(V0EMISDIARIA.V0EMISD_NRENDOS, V0EMISD_NRENDOS);
                _.Move(V0EMISDIARIA.V0EMISD_NRPARCEL, V0EMISD_NRPARCEL);
            }

        }

        [StopWatch]
        /*" R0060-00-LE-V0EMISDIARIA-DB-CLOSE-1 */
        public void R0060_00_LE_V0EMISDIARIA_DB_CLOSE_1()
        {
            /*" -600- EXEC SQL CLOSE V0EMISDIARIA END-EXEC */

            V0EMISDIARIA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0070-00-LE-V0ENDOSSO-SECTION */
        private void R0070_00_LE_V0ENDOSSO_SECTION()
        {
            /*" -615- MOVE 'R0070-00-LE-V0ENDOSSO        ' TO WPARAGRAFO */
            _.Move("R0070-00-LE-V0ENDOSSO        ", AREA_DE_WORK.WPARAGRAFO);

            /*" -617- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -618- MOVE V0EMISD-NUM-APOLICE TO V0ENDOS-NUM-APOLICE */
            _.Move(V0EMISD_NUM_APOLICE, V0ENDOS_NUM_APOLICE);

            /*" -620- MOVE V0EMISD-NRENDOS TO V0ENDOS-NRENDOS */
            _.Move(V0EMISD_NRENDOS, V0ENDOS_NRENDOS);

            /*" -638- PERFORM R0070_00_LE_V0ENDOSSO_DB_SELECT_1 */

            R0070_00_LE_V0ENDOSSO_DB_SELECT_1();

            /*" -641- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -642- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -643- DISPLAY 'V0ENDOS-NUM-APOLICE ' V0ENDOS-NUM-APOLICE */
                _.Display($"V0ENDOS-NUM-APOLICE {V0ENDOS_NUM_APOLICE}");

                /*" -644- DISPLAY 'V0ENDOS-NRENDOS     ' V0ENDOS-NRENDOS */
                _.Display($"V0ENDOS-NRENDOS     {V0ENDOS_NRENDOS}");

                /*" -644- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0070-00-LE-V0ENDOSSO-DB-SELECT-1 */
        public void R0070_00_LE_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -638- EXEC SQL SELECT VALUE(COD_EMPRESA, 0), NRPROPOS, FONTE, DTINIVIG, DTTERVIG, TIPO_ENDOSSO, CODPRODU INTO :V0ENDOS-COD-EMPRESA, :V0ENDOS-NRPROPOS, :V0ENDOS-FONTE, :V0ENDOS-DTINIVIG, :V0ENDOS-DTTERVIG, :V0ENDOS-TIPO-ENDOSSO, :V0ENDOS-COD-PRODUTO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0ENDOS-NUM-APOLICE AND NRENDOS = :V0ENDOS-NRENDOS END-EXEC. */

            var r0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1 = new R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V0ENDOS_NUM_APOLICE = V0ENDOS_NUM_APOLICE.ToString(),
                V0ENDOS_NRENDOS = V0ENDOS_NRENDOS.ToString(),
            };

            var executed_1 = R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDOS_COD_EMPRESA, V0ENDOS_COD_EMPRESA);
                _.Move(executed_1.V0ENDOS_NRPROPOS, V0ENDOS_NRPROPOS);
                _.Move(executed_1.V0ENDOS_FONTE, V0ENDOS_FONTE);
                _.Move(executed_1.V0ENDOS_DTINIVIG, V0ENDOS_DTINIVIG);
                _.Move(executed_1.V0ENDOS_DTTERVIG, V0ENDOS_DTTERVIG);
                _.Move(executed_1.V0ENDOS_TIPO_ENDOSSO, V0ENDOS_TIPO_ENDOSSO);
                _.Move(executed_1.V0ENDOS_COD_PRODUTO, V0ENDOS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-LE-V0PROPCOB-SECTION */
        private void R0080_00_LE_V0PROPCOB_SECTION()
        {
            /*" -653- MOVE 'R0080-00-LE-V0PROPCOB        ' TO WPARAGRAFO */
            _.Move("R0080-00-LE-V0PROPCOB        ", AREA_DE_WORK.WPARAGRAFO);

            /*" -655- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -656- MOVE V0ENDOS-NRPROPOS TO V0PROPC-NRPROPOS */
            _.Move(V0ENDOS_NRPROPOS, V0PROPC_NRPROPOS);

            /*" -658- MOVE V0ENDOS-FONTE TO V0PROPC-FONTE */
            _.Move(V0ENDOS_FONTE, V0PROPC_FONTE);

            /*" -695- PERFORM R0080_00_LE_V0PROPCOB_DB_SELECT_1 */

            R0080_00_LE_V0PROPCOB_DB_SELECT_1();

            /*" -698- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -699- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -700- MOVE 'N' TO WTEM-PROPCOB */
                    _.Move("N", AREA_DE_WORK.WTEM_PROPCOB);

                    /*" -701- ELSE */
                }
                else
                {


                    /*" -704- DISPLAY 'EM0015B - SELECT V0PROPCOB - ' WPARAGRAFO ' FONTE / NR PROPOSTA  - ' V0PROPC-FONTE ' / ' V0PROPC-NRPROPOS */

                    $"EM0015B - SELECT V0PROPCOB - {AREA_DE_WORK.WPARAGRAFO} FONTE / NR PROPOSTA  - {V0PROPC_FONTE} / {V0PROPC_NRPROPOS}"
                    .Display();

                    /*" -704- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0080-00-LE-V0PROPCOB-DB-SELECT-1 */
        public void R0080_00_LE_V0PROPCOB_DB_SELECT_1()
        {
            /*" -695- EXEC SQL SELECT FONTE, CODPRODU, NUM_MATRICULA, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA, TIPO_COBRANCA, VALUE(COD_AGENCIA_DEB,0), VALUE(OPER_CONTA_DEB,0), VALUE(NUM_CONTA_DEB,0), VALUE(DIG_CONTA_DEB,0), VALUE(DIA_DEBITO,0), VALUE(NRCERTIF_AUTO, ' ' ), VALUE(NUM_CARTAO, 0), VALUE(MARGEM_COMERCIAL, 0) INTO :V0PROPC-FONTE, :V0PROPC-CODPRODU, :V0PROPC-NUM-MATRICULA, :V0PROPC-COD-AGENCIA, :V0PROPC-OPERACAO-CONTA, :V0PROPC-NUM-CONTA, :V0PROPC-DIG-CONTA, :V0PROPC-TIPO-COBRANCA, :V0PROPC-COD-AGENCIA-DEB, :V0PROPC-OPER-CONTA-DEB, :V0PROPC-NUM-CONTA-DEB, :V0PROPC-DIG-CONTA-DEB, :V0PROPC-DIA-DEBITO, :V0PROPC-NRCERTIF-AUTO, :V0PROPC-NUM-CARTAO, :V0PROPC-MARGEM-COMERCIAL FROM SEGUROS.V0PROPCOB WHERE NRPROPOS = :V0PROPC-NRPROPOS AND FONTE = :V0PROPC-FONTE END-EXEC. */

            var r0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1 = new R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1()
            {
                V0PROPC_NRPROPOS = V0PROPC_NRPROPOS.ToString(),
                V0PROPC_FONTE = V0PROPC_FONTE.ToString(),
            };

            var executed_1 = R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1.Execute(r0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROPC_FONTE, V0PROPC_FONTE);
                _.Move(executed_1.V0PROPC_CODPRODU, V0PROPC_CODPRODU);
                _.Move(executed_1.V0PROPC_NUM_MATRICULA, V0PROPC_NUM_MATRICULA);
                _.Move(executed_1.V0PROPC_COD_AGENCIA, V0PROPC_COD_AGENCIA);
                _.Move(executed_1.V0PROPC_OPERACAO_CONTA, V0PROPC_OPERACAO_CONTA);
                _.Move(executed_1.V0PROPC_NUM_CONTA, V0PROPC_NUM_CONTA);
                _.Move(executed_1.V0PROPC_DIG_CONTA, V0PROPC_DIG_CONTA);
                _.Move(executed_1.V0PROPC_TIPO_COBRANCA, V0PROPC_TIPO_COBRANCA);
                _.Move(executed_1.V0PROPC_COD_AGENCIA_DEB, V0PROPC_COD_AGENCIA_DEB);
                _.Move(executed_1.V0PROPC_OPER_CONTA_DEB, V0PROPC_OPER_CONTA_DEB);
                _.Move(executed_1.V0PROPC_NUM_CONTA_DEB, V0PROPC_NUM_CONTA_DEB);
                _.Move(executed_1.V0PROPC_DIG_CONTA_DEB, V0PROPC_DIG_CONTA_DEB);
                _.Move(executed_1.V0PROPC_DIA_DEBITO, V0PROPC_DIA_DEBITO);
                _.Move(executed_1.V0PROPC_NRCERTIF_AUTO, V0PROPC_NRCERTIF_AUTO);
                _.Move(executed_1.V0PROPC_NUM_CARTAO, V0PROPC_NUM_CARTAO);
                _.Move(executed_1.V0PROPC_MARGEM_COMERCIAL, V0PROPC_MARGEM_COMERCIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_SAIDA*/

        [StopWatch]
        /*" R0090-00-LE-V0PROPOSTA-SECTION */
        private void R0090_00_LE_V0PROPOSTA_SECTION()
        {
            /*" -713- MOVE 'R0090-00-LE-V0PROPOSTA       ' TO WPARAGRAFO */
            _.Move("R0090-00-LE-V0PROPOSTA       ", AREA_DE_WORK.WPARAGRAFO);

            /*" -715- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -716- MOVE V0ENDOS-FONTE TO V0PROPO-FONTE */
            _.Move(V0ENDOS_FONTE, V0PROPO_FONTE);

            /*" -718- MOVE V0ENDOS-NRPROPOS TO V0PROPO-NRPROPOS */
            _.Move(V0ENDOS_NRPROPOS, V0PROPO_NRPROPOS);

            /*" -726- PERFORM R0090_00_LE_V0PROPOSTA_DB_SELECT_1 */

            R0090_00_LE_V0PROPOSTA_DB_SELECT_1();

            /*" -729- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -730- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -731- DISPLAY 'V0PROPC-NRPROPOS    ' V0PROPC-NRPROPOS */
                _.Display($"V0PROPC-NRPROPOS    {V0PROPC_NRPROPOS}");

                /*" -731- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0090-00-LE-V0PROPOSTA-DB-SELECT-1 */
        public void R0090_00_LE_V0PROPOSTA_DB_SELECT_1()
        {
            /*" -726- EXEC SQL SELECT AGECOBR, RAMO INTO :V0PROPO-AGECOBR, :V0PROPO-RAMO FROM SEGUROS.V0PROPOSTA WHERE FONTE = :V0PROPO-FONTE AND NRPROPOS = :V0PROPO-NRPROPOS END-EXEC. */

            var r0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1 = new R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1()
            {
                V0PROPO_NRPROPOS = V0PROPO_NRPROPOS.ToString(),
                V0PROPO_FONTE = V0PROPO_FONTE.ToString(),
            };

            var executed_1 = R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1.Execute(r0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROPO_AGECOBR, V0PROPO_AGECOBR);
                _.Move(executed_1.V0PROPO_RAMO, V0PROPO_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INCLUI-V0APOLCOB-SECTION */
        private void R0100_00_INCLUI_V0APOLCOB_SECTION()
        {
            /*" -741- PERFORM R0100-10-MOVTA-CAMPOS */

            R0100_10_MOVTA_CAMPOS_SECTION();

            /*" -742- MOVE 'R0100-00-INCLUI-V0APOLCOB    ' TO WPARAGRAFO */
            _.Move("R0100-00-INCLUI-V0APOLCOB    ", AREA_DE_WORK.WPARAGRAFO);

            /*" -744- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -766- PERFORM R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1 */

            R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1();

            /*" -769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -770- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -771- DISPLAY 'V0APOLC-FONTE       ' V0APOLC-FONTE */
                _.Display($"V0APOLC-FONTE       {V0APOLC_FONTE}");

                /*" -772- DISPLAY 'V0APOLC-NUM-APOLICE ' V0APOLC-NUM-APOLICE */
                _.Display($"V0APOLC-NUM-APOLICE {V0APOLC_NUM_APOLICE}");

                /*" -773- DISPLAY 'V0APOLC-NRENDOS     ' V0APOLC-NRENDOS */
                _.Display($"V0APOLC-NRENDOS     {V0APOLC_NRENDOS}");

                /*" -775- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -775- COMPUTE WTOTAPOLC = WTOTAPOLC + 1. */
            AREA_DE_WORK.WTOTAPOLC.Value = AREA_DE_WORK.WTOTAPOLC + 1;

        }

        [StopWatch]
        /*" R0100-00-INCLUI-V0APOLCOB-DB-INSERT-1 */
        public void R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1()
        {
            /*" -766- EXEC SQL INSERT INTO SEGUROS.V0APOLCOB VALUES ( :V0APOLC-COD-EMPRESA, :V0APOLC-FONTE, :V0APOLC-NUM-APOLICE, :V0APOLC-NRENDOS, :V0APOLC-CODPRODU, :V0APOLC-NUM-MATRICULA, :V0APOLC-TIPO-COBRANCA, :V0APOLC-AGECOBR, :V0APOLC-COD-AGENCIA, :V0APOLC-OPER-CONTA, :V0APOLC-NUM-CONTA, :V0APOLC-DIG-CONTA, :V0APOLC-COD-AGENCIA-DEB, :V0APOLC-OPER-CONTA-DEB, :V0APOLC-NUM-CONTA-DEB, :V0APOLC-DIG-CONTA-DEB, :V0APOLC-NUM-CARTAO, :V0APOLC-DIA-DEBITO, :V0APOLC-NRCERTIF-AUTO, CURRENT TIMESTAMP, :V0APOLC-MARGEM-COMERCIAL) END-EXEC. */

            var r0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1 = new R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1()
            {
                V0APOLC_COD_EMPRESA = V0APOLC_COD_EMPRESA.ToString(),
                V0APOLC_FONTE = V0APOLC_FONTE.ToString(),
                V0APOLC_NUM_APOLICE = V0APOLC_NUM_APOLICE.ToString(),
                V0APOLC_NRENDOS = V0APOLC_NRENDOS.ToString(),
                V0APOLC_CODPRODU = V0APOLC_CODPRODU.ToString(),
                V0APOLC_NUM_MATRICULA = V0APOLC_NUM_MATRICULA.ToString(),
                V0APOLC_TIPO_COBRANCA = V0APOLC_TIPO_COBRANCA.ToString(),
                V0APOLC_AGECOBR = V0APOLC_AGECOBR.ToString(),
                V0APOLC_COD_AGENCIA = V0APOLC_COD_AGENCIA.ToString(),
                V0APOLC_OPER_CONTA = V0APOLC_OPER_CONTA.ToString(),
                V0APOLC_NUM_CONTA = V0APOLC_NUM_CONTA.ToString(),
                V0APOLC_DIG_CONTA = V0APOLC_DIG_CONTA.ToString(),
                V0APOLC_COD_AGENCIA_DEB = V0APOLC_COD_AGENCIA_DEB.ToString(),
                V0APOLC_OPER_CONTA_DEB = V0APOLC_OPER_CONTA_DEB.ToString(),
                V0APOLC_NUM_CONTA_DEB = V0APOLC_NUM_CONTA_DEB.ToString(),
                V0APOLC_DIG_CONTA_DEB = V0APOLC_DIG_CONTA_DEB.ToString(),
                V0APOLC_NUM_CARTAO = V0APOLC_NUM_CARTAO.ToString(),
                V0APOLC_DIA_DEBITO = V0APOLC_DIA_DEBITO.ToString(),
                V0APOLC_NRCERTIF_AUTO = V0APOLC_NRCERTIF_AUTO.ToString(),
                V0APOLC_MARGEM_COMERCIAL = V0APOLC_MARGEM_COMERCIAL.ToString(),
            };

            R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1.Execute(r0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-10-MOVTA-CAMPOS-SECTION */
        private void R0100_10_MOVTA_CAMPOS_SECTION()
        {
            /*" -784- MOVE V0ENDOS-COD-EMPRESA TO V0APOLC-COD-EMPRESA */
            _.Move(V0ENDOS_COD_EMPRESA, V0APOLC_COD_EMPRESA);

            /*" -785- MOVE V0PROPC-FONTE TO V0APOLC-FONTE */
            _.Move(V0PROPC_FONTE, V0APOLC_FONTE);

            /*" -786- MOVE V0EMISD-NUM-APOLICE TO V0APOLC-NUM-APOLICE */
            _.Move(V0EMISD_NUM_APOLICE, V0APOLC_NUM_APOLICE);

            /*" -787- MOVE V0EMISD-NRENDOS TO V0APOLC-NRENDOS */
            _.Move(V0EMISD_NRENDOS, V0APOLC_NRENDOS);

            /*" -788- MOVE V0PROPC-CODPRODU TO V0APOLC-CODPRODU */
            _.Move(V0PROPC_CODPRODU, V0APOLC_CODPRODU);

            /*" -789- MOVE V0PROPC-NUM-MATRICULA TO V0APOLC-NUM-MATRICULA */
            _.Move(V0PROPC_NUM_MATRICULA, V0APOLC_NUM_MATRICULA);

            /*" -790- MOVE V0PROPC-TIPO-COBRANCA TO V0APOLC-TIPO-COBRANCA */
            _.Move(V0PROPC_TIPO_COBRANCA, V0APOLC_TIPO_COBRANCA);

            /*" -791- MOVE V0PROPO-AGECOBR TO V0APOLC-AGECOBR */
            _.Move(V0PROPO_AGECOBR, V0APOLC_AGECOBR);

            /*" -793- MOVE V0PROPC-COD-AGENCIA-DEB TO V0APOLC-COD-AGENCIA-DEB */
            _.Move(V0PROPC_COD_AGENCIA_DEB, V0APOLC_COD_AGENCIA_DEB);

            /*" -794- IF V0PROPO-RAMO EQUAL 40 OR 67 OR 45 OR 75 */

            if (V0PROPO_RAMO.In("40", "67", "45", "75"))
            {

                /*" -796- MOVE V0PROPC-COD-AGENCIA-DEB TO V0APOLC-AGECOBR. */
                _.Move(V0PROPC_COD_AGENCIA_DEB, V0APOLC_AGECOBR);
            }


            /*" -797- IF V0PROPC-CODPRODU EQUAL 1803 OR 1805 */

            if (V0PROPC_CODPRODU.In("1803", "1805"))
            {

                /*" -799- MOVE V0PROPC-COD-AGENCIA-DEB TO V0APOLC-AGECOBR. */
                _.Move(V0PROPC_COD_AGENCIA_DEB, V0APOLC_AGECOBR);
            }


            /*" -803- MOVE ZEROS TO V0APOLC-COD-AGENCIA V0APOLC-OPER-CONTA V0APOLC-NUM-CONTA V0APOLC-DIG-CONTA */
            _.Move(0, V0APOLC_COD_AGENCIA, V0APOLC_OPER_CONTA, V0APOLC_NUM_CONTA, V0APOLC_DIG_CONTA);

            /*" -804- MOVE V0PROPC-OPER-CONTA-DEB TO V0APOLC-OPER-CONTA-DEB */
            _.Move(V0PROPC_OPER_CONTA_DEB, V0APOLC_OPER_CONTA_DEB);

            /*" -805- MOVE V0PROPC-NUM-CONTA-DEB TO V0APOLC-NUM-CONTA-DEB */
            _.Move(V0PROPC_NUM_CONTA_DEB, V0APOLC_NUM_CONTA_DEB);

            /*" -806- MOVE V0PROPC-DIG-CONTA-DEB TO V0APOLC-DIG-CONTA-DEB */
            _.Move(V0PROPC_DIG_CONTA_DEB, V0APOLC_DIG_CONTA_DEB);

            /*" -807- MOVE V0PROPC-NUM-CARTAO TO V0APOLC-NUM-CARTAO */
            _.Move(V0PROPC_NUM_CARTAO, V0APOLC_NUM_CARTAO);

            /*" -808- MOVE V0PROPC-DIA-DEBITO TO V0APOLC-DIA-DEBITO */
            _.Move(V0PROPC_DIA_DEBITO, V0APOLC_DIA_DEBITO);

            /*" -809- MOVE V0PROPC-NRCERTIF-AUTO TO V0APOLC-NRCERTIF-AUTO. */
            _.Move(V0PROPC_NRCERTIF_AUTO, V0APOLC_NRCERTIF_AUTO);

            /*" -815- MOVE V0PROPC-MARGEM-COMERCIAL TO V0APOLC-MARGEM-COMERCIAL. */
            _.Move(V0PROPC_MARGEM_COMERCIAL, V0APOLC_MARGEM_COMERCIAL);

            /*" -817- IF V0ENDOS-COD-PRODUTO EQUAL 5302 OR 5303 OR 5304 */

            if (V0ENDOS_COD_PRODUTO.In("5302", "5303", "5304"))
            {

                /*" -818- PERFORM R0101-00-RECUPERA-AU085 */

                R0101_00_RECUPERA_AU085_SECTION();

                /*" -820- IF AU085-IND-FORMA-PAGTO-AD EQUAL '4' OR AU085-IND-FORMA-PAGTO-AD EQUAL '3' */

                if (AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD == "4" || AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD == "3")
                {

                    /*" -820- PERFORM R0105-00-UPDATE-MOVIMCOB. */

                    R0105_00_UPDATE_MOVIMCOB_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_19_SAIDA*/

        [StopWatch]
        /*" R0101-00-RECUPERA-AU085-SECTION */
        private void R0101_00_RECUPERA_AU085_SECTION()
        {
            /*" -829- MOVE 'R0101-00-RECUPERA-AU085      ' TO WPARAGRAFO */
            _.Move("R0101-00-RECUPERA-AU085      ", AREA_DE_WORK.WPARAGRAFO);

            /*" -831- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -839- PERFORM R0101_00_RECUPERA_AU085_DB_SELECT_1 */

            R0101_00_RECUPERA_AU085_DB_SELECT_1();

            /*" -842- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -843- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -844- DISPLAY 'V0ENDOS-COD-FONTE     ' V0ENDOS-FONTE */
                _.Display($"V0ENDOS-COD-FONTE     {V0ENDOS_FONTE}");

                /*" -845- DISPLAY 'V0ENDOS-NUM-PROPOSTA  ' V0ENDOS-NRPROPOS */
                _.Display($"V0ENDOS-NUM-PROPOSTA  {V0ENDOS_NRPROPOS}");

                /*" -845- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0101-00-RECUPERA-AU085-DB-SELECT-1 */
        public void R0101_00_RECUPERA_AU085_DB_SELECT_1()
        {
            /*" -839- EXEC SQL SELECT IND_FORMA_PAGTO_AD, VALUE(COD_PARCEIRO, 0) INTO :AU085-IND-FORMA-PAGTO-AD, :AU085-COD-PARCEIRO FROM SEGUROS.AU_PROPOSTA_COMPL WHERE COD_FONTE = :V0ENDOS-FONTE AND NUM_PROPOSTA = :V0ENDOS-NRPROPOS END-EXEC. */

            var r0101_00_RECUPERA_AU085_DB_SELECT_1_Query1 = new R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1()
            {
                V0ENDOS_NRPROPOS = V0ENDOS_NRPROPOS.ToString(),
                V0ENDOS_FONTE = V0ENDOS_FONTE.ToString(),
            };

            var executed_1 = R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1.Execute(r0101_00_RECUPERA_AU085_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU085_IND_FORMA_PAGTO_AD, AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD);
                _.Move(executed_1.AU085_COD_PARCEIRO, AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_PARCEIRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_99_SAIDA*/

        [StopWatch]
        /*" R0105-00-UPDATE-MOVIMCOB-SECTION */
        private void R0105_00_UPDATE_MOVIMCOB_SECTION()
        {
            /*" -855- MOVE 'R0105-00-UPDATE-MOVIMCOB     ' TO WPARAGRAFO */
            _.Move("R0105-00-UPDATE-MOVIMCOB     ", AREA_DE_WORK.WPARAGRAFO);

            /*" -857- MOVE '105' TO WNR-EXEC-SQL. */
            _.Move("105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -858- MOVE V0ENDOS-FONTE TO WHOST-NUM-APOLICE */
            _.Move(V0ENDOS_FONTE, WHOST_NUM_APOLICE);

            /*" -860- MOVE V0ENDOS-NRPROPOS TO WHOST-NUM-ENDOSSO */
            _.Move(V0ENDOS_NRPROPOS, WHOST_NUM_ENDOSSO);

            /*" -862- MOVE V0EMISD-NUM-APOLICE TO MOVIMCOB-NUM-APOLICE */
            _.Move(V0EMISD_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -864- MOVE V0EMISD-NRENDOS TO MOVIMCOB-NUM-ENDOSSO */
            _.Move(V0EMISD_NRENDOS, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);

            /*" -867- MOVE V0EMISD-NRPARCEL TO MOVIMCOB-NUM-PARCELA. */
            _.Move(V0EMISD_NRPARCEL, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);

            /*" -868- IF AU085-IND-FORMA-PAGTO-AD EQUAL '4' */

            if (AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD == "4")
            {

                /*" -869- MOVE 23000 TO MOVIMCOB-NUM-AVISO */
                _.Move(23000, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

                /*" -870- ELSE */
            }
            else
            {


                /*" -872- MOVE 12000 TO MOVIMCOB-NUM-AVISO. */
                _.Move(12000, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
            }


            /*" -883- PERFORM R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1 */

            R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1();

            /*" -886- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -887- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -888- DISPLAY 'FONTE    ' V0ENDOS-FONTE */
                _.Display($"FONTE    {V0ENDOS_FONTE}");

                /*" -889- DISPLAY 'PROPOSTA ' V0ENDOS-NRPROPOS */
                _.Display($"PROPOSTA {V0ENDOS_NRPROPOS}");

                /*" -890- DISPLAY 'APOLICE  ' MOVIMCOB-NUM-APOLICE */
                _.Display($"APOLICE  {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -891- DISPLAY 'ENDOSSO  ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -891- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0105-00-UPDATE-MOVIMCOB-DB-UPDATE-1 */
        public void R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1()
        {
            /*" -883- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET NUM_APOLICE = :MOVIMCOB-NUM-APOLICE, NUM_ENDOSSO = :MOVIMCOB-NUM-ENDOSSO, NUM_PARCELA = :MOVIMCOB-NUM-PARCELA WHERE NUM_APOLICE = :WHOST-NUM-APOLICE AND NUM_ENDOSSO = :WHOST-NUM-ENDOSSO AND NUM_PARCELA IN (0, 1) AND SIT_REGISTRO = '0' AND TIPO_MOVIMENTO = 'Y' AND NUM_AVISO = :MOVIMCOB-NUM-AVISO END-EXEC. */

            var r0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 = new R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                WHOST_NUM_APOLICE = WHOST_NUM_APOLICE.ToString(),
                WHOST_NUM_ENDOSSO = WHOST_NUM_ENDOSSO.ToString(),
            };

            R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1.Execute(r0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0105_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-LE-V0PARAM-CONTACEF-SECTION */
        private void R0110_00_LE_V0PARAM_CONTACEF_SECTION()
        {
            /*" -900- MOVE 'R0110-00-LE-PARAM_CONTACEF   ' TO WPARAGRAFO */
            _.Move("R0110-00-LE-PARAM_CONTACEF   ", AREA_DE_WORK.WPARAGRAFO);

            /*" -902- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -903- MOVE V0PROPC-CODPRODU TO V0PARAMC-CODPRODU */
            _.Move(V0PROPC_CODPRODU, V0PARAMC_CODPRODU);

            /*" -905- MOVE 1 TO V0PARAMC-TIPO-MOVTOCC */
            _.Move(1, V0PARAMC_TIPO_MOVTOCC);

            /*" -911- PERFORM R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1 */

            R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1();

            /*" -914- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -915- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -916- DISPLAY 'V0PARAMC-CODPRODU     ' V0PARAMC-CODPRODU */
                _.Display($"V0PARAMC-CODPRODU     {V0PARAMC_CODPRODU}");

                /*" -917- DISPLAY 'V0PARAMC-TIPO-MOVTOCC ' V0PARAMC-TIPO-MOVTOCC */
                _.Display($"V0PARAMC-TIPO-MOVTOCC {V0PARAMC_TIPO_MOVTOCC}");

                /*" -917- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0110-00-LE-V0PARAM-CONTACEF-DB-SELECT-1 */
        public void R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1()
        {
            /*" -911- EXEC SQL SELECT COD_CONVENIO INTO :V0PARAMC-COD-CONVENIO FROM SEGUROS.V0PARAM_CONTACEF WHERE CODPRODU = :V0PARAMC-CODPRODU AND TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC END-EXEC. */

            var r0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1 = new R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1()
            {
                V0PARAMC_TIPO_MOVTOCC = V0PARAMC_TIPO_MOVTOCC.ToString(),
                V0PARAMC_CODPRODU = V0PARAMC_CODPRODU.ToString(),
            };

            var executed_1 = R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1.Execute(r0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARAMC_COD_CONVENIO, V0PARAMC_COD_CONVENIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-ABRE-V0HISTOPARC-SECTION */
        private void R0120_00_ABRE_V0HISTOPARC_SECTION()
        {
            /*" -927- MOVE 'R0120-00-ABRE-V0HISTOPARC    ' TO WPARAGRAFO */
            _.Move("R0120-00-ABRE-V0HISTOPARC    ", AREA_DE_WORK.WPARAGRAFO);

            /*" -929- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -931- MOVE SPACES TO WFIMV0HISTOPARC */
            _.Move("", AREA_DE_WORK.WFIMV0HISTOPARC);

            /*" -932- MOVE V0EMISD-NUM-APOLICE TO V0HISTO-NUM-APOLICE */
            _.Move(V0EMISD_NUM_APOLICE, V0HISTO_NUM_APOLICE);

            /*" -933- MOVE V0EMISD-NRENDOS TO V0HISTO-NRENDOS */
            _.Move(V0EMISD_NRENDOS, V0HISTO_NRENDOS);

            /*" -934- MOVE V0EMISD-NRPARCEL TO V0HISTO-NRPARCEL */
            _.Move(V0EMISD_NRPARCEL, V0HISTO_NRPARCEL);

            /*" -935- MOVE 101 TO V0HISTO-OPERACAO */
            _.Move(101, V0HISTO_OPERACAO);

            /*" -937- MOVE '0' TO V0PARCE-SITUACAO */
            _.Move("0", V0PARCE_SITUACAO);

            /*" -937- PERFORM R0120_00_ABRE_V0HISTOPARC_DB_OPEN_1 */

            R0120_00_ABRE_V0HISTOPARC_DB_OPEN_1();

            /*" -940- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -941- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -941- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-ABRE-V0HISTOPARC-DB-OPEN-1 */
        public void R0120_00_ABRE_V0HISTOPARC_DB_OPEN_1()
        {
            /*" -937- EXEC SQL OPEN V0HISTOPARC END-EXEC. */

            V0HISTOPARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-PROCESSA-V0HISTOPARC-SECTION */
        private void R0130_00_PROCESSA_V0HISTOPARC_SECTION()
        {
            /*" -951- PERFORM R0140-00-LE-V0HISTOPARC */

            R0140_00_LE_V0HISTOPARC_SECTION();

            /*" -952- IF WFIMV0HISTOPARC = 'S' */

            if (AREA_DE_WORK.WFIMV0HISTOPARC == "S")
            {

                /*" -956- GO TO R0130-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/ //GOTO
                return;
            }


            /*" -961- IF ((V0HISTO-NRPARCEL EQUAL 0 OR 1) AND (V0ENDOS-COD-PRODUTO EQUAL 5302 OR 5303 OR 5304) AND (AU085-IND-FORMA-PAGTO-AD EQUAL '4' OR AU085-IND-FORMA-PAGTO-AD EQUAL '3' )) NEXT SENTENCE */

            if (((V0HISTO_NRPARCEL.In("0", "1")) && (V0ENDOS_COD_PRODUTO.In("5302", "5303", "5304")) && (AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD == "4" || AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD == "3")))
            {

                /*" -962- ELSE */
            }
            else
            {


                /*" -962- PERFORM R0160-00-INCLUI-V0MOVDE. */

                R0160_00_INCLUI_V0MOVDE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0140-00-LE-V0HISTOPARC-SECTION */
        private void R0140_00_LE_V0HISTOPARC_SECTION()
        {
            /*" -971- MOVE 'R0140-00-LE-V0HISTOPARC      ' TO WPARAGRAFO */
            _.Move("R0140-00-LE-V0HISTOPARC      ", AREA_DE_WORK.WPARAGRAFO);

            /*" -973- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -978- PERFORM R0140_00_LE_V0HISTOPARC_DB_FETCH_1 */

            R0140_00_LE_V0HISTOPARC_DB_FETCH_1();

            /*" -981- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -982- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -983- MOVE 'S' TO WFIMV0HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIMV0HISTOPARC);

                    /*" -983- PERFORM R0140_00_LE_V0HISTOPARC_DB_CLOSE_1 */

                    R0140_00_LE_V0HISTOPARC_DB_CLOSE_1();

                    /*" -985- GO TO R0140-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/ //GOTO
                    return;

                    /*" -986- ELSE */
                }
                else
                {


                    /*" -987- DISPLAY 'EM0015B - ' WPARAGRAFO */
                    _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -987- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0140-00-LE-V0HISTOPARC-DB-FETCH-1 */
        public void R0140_00_LE_V0HISTOPARC_DB_FETCH_1()
        {
            /*" -978- EXEC SQL FETCH V0HISTOPARC INTO :V0HISTO-NRPARCEL, :V0HISTO-DTMOVTO, :V0HISTO-VLPRMTOT, :V0HISTO-DTVENCTO END-EXEC. */

            if (V0HISTOPARC.Fetch())
            {
                _.Move(V0HISTOPARC.V0HISTO_NRPARCEL, V0HISTO_NRPARCEL);
                _.Move(V0HISTOPARC.V0HISTO_DTMOVTO, V0HISTO_DTMOVTO);
                _.Move(V0HISTOPARC.V0HISTO_VLPRMTOT, V0HISTO_VLPRMTOT);
                _.Move(V0HISTOPARC.V0HISTO_DTVENCTO, V0HISTO_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R0140-00-LE-V0HISTOPARC-DB-CLOSE-1 */
        public void R0140_00_LE_V0HISTOPARC_DB_CLOSE_1()
        {
            /*" -983- EXEC SQL CLOSE V0HISTOPARC END-EXEC */

            V0HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-UPDATE-V0EMISDIARIA-SECTION */
        private void R0150_00_UPDATE_V0EMISDIARIA_SECTION()
        {
            /*" -996- MOVE 'R0150-00-UPDATE-V0EMISDIARIA' TO WPARAGRAFO */
            _.Move("R0150-00-UPDATE-V0EMISDIARIA", AREA_DE_WORK.WPARAGRAFO);

            /*" -998- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1000- MOVE 1 TO V0EMISD-SITUACAO */
            _.Move(1, V0EMISD_SITUACAO);

            /*" -1006- PERFORM R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1 */

            R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1();

            /*" -1009- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1010- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1011- DISPLAY 'V0EMISD-CODRELAT    ' V0EMISD-CODRELAT */
                _.Display($"V0EMISD-CODRELAT    {V0EMISD_CODRELAT}");

                /*" -1012- DISPLAY 'V0EMISD-NUM-APOLICE ' V0EMISD-NUM-APOLICE */
                _.Display($"V0EMISD-NUM-APOLICE {V0EMISD_NUM_APOLICE}");

                /*" -1013- DISPLAY 'V0EMISD-NRENDOS     ' V0EMISD-NRENDOS */
                _.Display($"V0EMISD-NRENDOS     {V0EMISD_NRENDOS}");

                /*" -1014- DISPLAY 'V0EMISD-NRPARCEL    ' V0EMISD-NRPARCEL */
                _.Display($"V0EMISD-NRPARCEL    {V0EMISD_NRPARCEL}");

                /*" -1014- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-UPDATE-V0EMISDIARIA-DB-UPDATE-1 */
        public void R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1()
        {
            /*" -1006- EXEC SQL UPDATE SEGUROS.V0EMISDIARIA SET SITUACAO = :V0EMISD-SITUACAO WHERE CODRELAT = :V0EMISD-CODRELAT AND NUM_APOLICE = :V0EMISD-NUM-APOLICE AND NRENDOS = :V0EMISD-NRENDOS AND NRPARCEL = :V0EMISD-NRPARCEL END-EXEC. */

            var r0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1 = new R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1()
            {
                V0EMISD_SITUACAO = V0EMISD_SITUACAO.ToString(),
                V0EMISD_NUM_APOLICE = V0EMISD_NUM_APOLICE.ToString(),
                V0EMISD_CODRELAT = V0EMISD_CODRELAT.ToString(),
                V0EMISD_NRPARCEL = V0EMISD_NRPARCEL.ToString(),
                V0EMISD_NRENDOS = V0EMISD_NRENDOS.ToString(),
            };

            R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1.Execute(r0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-INCLUI-V0MOVDE-SECTION */
        private void R0160_00_INCLUI_V0MOVDE_SECTION()
        {
            /*" -1024- PERFORM R0160-10-MOVTA-CAMPOS. */

            R0160_10_MOVTA_CAMPOS_SECTION();

            /*" -1025- MOVE 'R0160-00-INCLUI-V0MOVDE' TO WPARAGRAFO */
            _.Move("R0160-00-INCLUI-V0MOVDE", AREA_DE_WORK.WPARAGRAFO);

            /*" -1027- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1084- PERFORM R0160_00_INCLUI_V0MOVDE_DB_INSERT_1 */

            R0160_00_INCLUI_V0MOVDE_DB_INSERT_1();

            /*" -1087- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1088- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1089- DISPLAY 'V0MOVDE-NUM-APOLICE  ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE  {V0MOVDE_NUM_APOLICE}");

                /*" -1090- DISPLAY 'V0MOVDE-NRENDOS      ' V0MOVDE-NRENDOS */
                _.Display($"V0MOVDE-NRENDOS      {V0MOVDE_NRENDOS}");

                /*" -1091- DISPLAY 'V0MOVDE-NRPARCEL     ' V0MOVDE-NRPARCEL */
                _.Display($"V0MOVDE-NRPARCEL     {V0MOVDE_NRPARCEL}");

                /*" -1092- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                /*" -1093- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                /*" -1095- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1095- COMPUTE WTOTMOVDE = WTOTMOVDE + 1. */
            AREA_DE_WORK.WTOTMOVDE.Value = AREA_DE_WORK.WTOTMOVDE + 1;

        }

        [StopWatch]
        /*" R0160-00-INCLUI-V0MOVDE-DB-INSERT-1 */
        public void R0160_00_INCLUI_V0MOVDE_DB_INSERT_1()
        {
            /*" -1084- EXEC SQL INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES ( :V0MOVDE-COD-EMPRESA, :V0MOVDE-NUM-APOLICE, :V0MOVDE-NRENDOS, :V0MOVDE-NRPARCEL, :V0MOVDE-SIT-COBRANCA, :V0MOVDE-DTVENCTO, :V0MOVDE-VLR-DEBITO, :V0MOVDE-DTMOVTO, CURRENT TIMESTAMP, :V0MOVDE-DIA-DEBITO, :V0MOVDE-COD-AGENCIA-DEB:V0MOVDE-COD-AGENCIA-DEB-NULL, :V0MOVDE-OPER-CONTA-DEB:V0MOVDE-OPER-CONTA-DEB-NULL, :V0MOVDE-NUM-CONTA-DEB:V0MOVDE-NUM-CONTA-DEB-NULL, :V0MOVDE-DIG-CONTA-DEB:V0MOVDE-DIG-CONTA-DEB-NULL, :V0MOVDE-COD-CONVENIO, :V0MOVDE-DTENVIO, NULL, NULL, :V0MOVDE-NSAS, :V0MOVDE-COD-USUARIO, NULL, :V0MOVDE-NUM-CARTAO:V0MOVDE-NUM-CARTAO-NULL, NULL, NULL, :V0MOVDE-DTCREDITO:V0MOVDE-DTCREDITO-NULL, :V0MOVDE-STATUS-CARTAO:V0MOVDE-STATUS-CARTAO-NULL, :V0MOVDE-VLR-CREDITO:V0MOVDE-VLR-CREDITO-NULL) END-EXEC. */

            var r0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1 = new R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1()
            {
                V0MOVDE_COD_EMPRESA = V0MOVDE_COD_EMPRESA.ToString(),
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_NRENDOS = V0MOVDE_NRENDOS.ToString(),
                V0MOVDE_NRPARCEL = V0MOVDE_NRPARCEL.ToString(),
                V0MOVDE_SIT_COBRANCA = V0MOVDE_SIT_COBRANCA.ToString(),
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V0MOVDE_VLR_DEBITO = V0MOVDE_VLR_DEBITO.ToString(),
                V0MOVDE_DTMOVTO = V0MOVDE_DTMOVTO.ToString(),
                V0MOVDE_DIA_DEBITO = V0MOVDE_DIA_DEBITO.ToString(),
                V0MOVDE_COD_AGENCIA_DEB = V0MOVDE_COD_AGENCIA_DEB.ToString(),
                V0MOVDE_COD_AGENCIA_DEB_NULL = V0MOVDE_COD_AGENCIA_DEB_NULL.ToString(),
                V0MOVDE_OPER_CONTA_DEB = V0MOVDE_OPER_CONTA_DEB.ToString(),
                V0MOVDE_OPER_CONTA_DEB_NULL = V0MOVDE_OPER_CONTA_DEB_NULL.ToString(),
                V0MOVDE_NUM_CONTA_DEB = V0MOVDE_NUM_CONTA_DEB.ToString(),
                V0MOVDE_NUM_CONTA_DEB_NULL = V0MOVDE_NUM_CONTA_DEB_NULL.ToString(),
                V0MOVDE_DIG_CONTA_DEB = V0MOVDE_DIG_CONTA_DEB.ToString(),
                V0MOVDE_DIG_CONTA_DEB_NULL = V0MOVDE_DIG_CONTA_DEB_NULL.ToString(),
                V0MOVDE_COD_CONVENIO = V0MOVDE_COD_CONVENIO.ToString(),
                V0MOVDE_DTENVIO = V0MOVDE_DTENVIO.ToString(),
                V0MOVDE_NSAS = V0MOVDE_NSAS.ToString(),
                V0MOVDE_COD_USUARIO = V0MOVDE_COD_USUARIO.ToString(),
                V0MOVDE_NUM_CARTAO = V0MOVDE_NUM_CARTAO.ToString(),
                V0MOVDE_NUM_CARTAO_NULL = V0MOVDE_NUM_CARTAO_NULL.ToString(),
                V0MOVDE_DTCREDITO = V0MOVDE_DTCREDITO.ToString(),
                V0MOVDE_DTCREDITO_NULL = V0MOVDE_DTCREDITO_NULL.ToString(),
                V0MOVDE_STATUS_CARTAO = V0MOVDE_STATUS_CARTAO.ToString(),
                V0MOVDE_STATUS_CARTAO_NULL = V0MOVDE_STATUS_CARTAO_NULL.ToString(),
                V0MOVDE_VLR_CREDITO = V0MOVDE_VLR_CREDITO.ToString(),
                V0MOVDE_VLR_CREDITO_NULL = V0MOVDE_VLR_CREDITO_NULL.ToString(),
            };

            R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1.Execute(r0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0160-10-MOVTA-CAMPOS-SECTION */
        private void R0160_10_MOVTA_CAMPOS_SECTION()
        {
            /*" -1104- MOVE V0ENDOS-COD-EMPRESA TO V0MOVDE-COD-EMPRESA */
            _.Move(V0ENDOS_COD_EMPRESA, V0MOVDE_COD_EMPRESA);

            /*" -1105- MOVE V0EMISD-NUM-APOLICE TO V0MOVDE-NUM-APOLICE */
            _.Move(V0EMISD_NUM_APOLICE, V0MOVDE_NUM_APOLICE);

            /*" -1106- MOVE V0EMISD-NRENDOS TO V0MOVDE-NRENDOS */
            _.Move(V0EMISD_NRENDOS, V0MOVDE_NRENDOS);

            /*" -1107- MOVE V0HISTO-NRPARCEL TO V0MOVDE-NRPARCEL */
            _.Move(V0HISTO_NRPARCEL, V0MOVDE_NRPARCEL);

            /*" -1108- MOVE SPACES TO V0MOVDE-SIT-COBRANCA */
            _.Move("", V0MOVDE_SIT_COBRANCA);

            /*" -1110- MOVE V0HISTO-DTVENCTO TO V0MOVDE-DTVENCTO */
            _.Move(V0HISTO_DTVENCTO, V0MOVDE_DTVENCTO);

            /*" -1111- IF V0PROPO-RAMO EQUAL 40 OR 67 OR 45 OR 75 */

            if (V0PROPO_RAMO.In("40", "67", "45", "75"))
            {

                /*" -1112- MOVE V0HISTO-DTVENCTO TO WDATA-VENCTO */
                _.Move(V0HISTO_DTVENCTO, AREA_DE_WORK.WDATA_VENCTO);

                /*" -1113- MOVE WDIA-VENCTO TO V0MOVDE-DIA-DEBITO */
                _.Move(AREA_DE_WORK.WDATA_VENCTO.WDIA_VENCTO, V0MOVDE_DIA_DEBITO);

                /*" -1114- ELSE */
            }
            else
            {


                /*" -1116- MOVE V0PROPC-DIA-DEBITO TO V0MOVDE-DIA-DEBITO. */
                _.Move(V0PROPC_DIA_DEBITO, V0MOVDE_DIA_DEBITO);
            }


            /*" -1117- IF V0PROPC-CODPRODU EQUAL 1803 OR 1805 */

            if (V0PROPC_CODPRODU.In("1803", "1805"))
            {

                /*" -1118- MOVE V0HISTO-DTVENCTO TO WDATA-VENCTO */
                _.Move(V0HISTO_DTVENCTO, AREA_DE_WORK.WDATA_VENCTO);

                /*" -1119- MOVE WDIA-VENCTO TO V0MOVDE-DIA-DEBITO */
                _.Move(AREA_DE_WORK.WDATA_VENCTO.WDIA_VENCTO, V0MOVDE_DIA_DEBITO);

                /*" -1120- ELSE */
            }
            else
            {


                /*" -1124- MOVE V0PROPC-DIA-DEBITO TO V0MOVDE-DIA-DEBITO. */
                _.Move(V0PROPC_DIA_DEBITO, V0MOVDE_DIA_DEBITO);
            }


            /*" -1126- IF (V0PROPC-CODPRODU EQUAL 1803 OR 1805) AND (V0ENDOS-TIPO-ENDOSSO EQUAL '3' OR '5' ) */

            if ((V0PROPC_CODPRODU.In("1803", "1805")) && (V0ENDOS_TIPO_ENDOSSO.In("3", "5")))
            {

                /*" -1127- MOVE 0 TO V0MOVDE-VLR-DEBITO */
                _.Move(0, V0MOVDE_VLR_DEBITO);

                /*" -1128- MOVE V0HISTO-VLPRMTOT TO V0MOVDE-VLR-CREDITO */
                _.Move(V0HISTO_VLPRMTOT, V0MOVDE_VLR_CREDITO);

                /*" -1129- MOVE 1 TO V0MOVDE-VLR-CREDITO-NULL */
                _.Move(1, V0MOVDE_VLR_CREDITO_NULL);

                /*" -1130- MOVE 'CR' TO V0MOVDE-STATUS-CARTAO */
                _.Move("CR", V0MOVDE_STATUS_CARTAO);

                /*" -1131- MOVE 1 TO V0MOVDE-STATUS-CARTAO-NULL */
                _.Move(1, V0MOVDE_STATUS_CARTAO_NULL);

                /*" -1132- MOVE V1SISTE-DTMOVABE TO V0MOVDE-DTCREDITO */
                _.Move(V1SISTE_DTMOVABE, V0MOVDE_DTCREDITO);

                /*" -1133- MOVE 1 TO V0MOVDE-DTCREDITO-NULL */
                _.Move(1, V0MOVDE_DTCREDITO_NULL);

                /*" -1134- ELSE */
            }
            else
            {


                /*" -1135- MOVE V0HISTO-VLPRMTOT TO V0MOVDE-VLR-DEBITO */
                _.Move(V0HISTO_VLPRMTOT, V0MOVDE_VLR_DEBITO);

                /*" -1136- MOVE 0 TO V0MOVDE-VLR-CREDITO */
                _.Move(0, V0MOVDE_VLR_CREDITO);

                /*" -1137- MOVE -1 TO V0MOVDE-VLR-CREDITO-NULL */
                _.Move(-1, V0MOVDE_VLR_CREDITO_NULL);

                /*" -1138- MOVE SPACES TO V0MOVDE-STATUS-CARTAO */
                _.Move("", V0MOVDE_STATUS_CARTAO);

                /*" -1139- MOVE -1 TO V0MOVDE-STATUS-CARTAO-NULL */
                _.Move(-1, V0MOVDE_STATUS_CARTAO_NULL);

                /*" -1140- MOVE SPACES TO V0MOVDE-DTCREDITO */
                _.Move("", V0MOVDE_DTCREDITO);

                /*" -1147- MOVE -1 TO V0MOVDE-DTCREDITO-NULL. */
                _.Move(-1, V0MOVDE_DTCREDITO_NULL);
            }


            /*" -1149- IF (V0PROPC-CODPRODU EQUAL 1803 OR 1805) AND V0EMISD-NRENDOS EQUAL ZEROS */

            if ((V0PROPC_CODPRODU.In("1803", "1805")) && V0EMISD_NRENDOS == 00)
            {

                /*" -1150- IF V0HISTO-NRPARCEL EQUAL 0 OR 1 */

                if (V0HISTO_NRPARCEL.In("0", "1"))
                {

                    /*" -1153- PERFORM R0600-00-LER-TITULO-LOTERICO . */

                    R0600_00_LER_TITULO_LOTERICO_SECTION();
                }

            }


            /*" -1154- MOVE V0HISTO-DTMOVTO TO V0MOVDE-DTMOVTO */
            _.Move(V0HISTO_DTMOVTO, V0MOVDE_DTMOVTO);

            /*" -1155- MOVE V1SISTE-DTMOVABE TO V0MOVDE-DTENVIO */
            _.Move(V1SISTE_DTMOVABE, V0MOVDE_DTENVIO);

            /*" -1156- MOVE 'EM0015B' TO V0MOVDE-COD-USUARIO */
            _.Move("EM0015B", V0MOVDE_COD_USUARIO);

            /*" -1158- MOVE ZEROS TO V0MOVDE-NSAS */
            _.Move(0, V0MOVDE_NSAS);

            /*" -1164- MOVE 1 TO V0MOVDE-NUM-CARTAO-NULL V0MOVDE-COD-AGENCIA-DEB-NULL V0MOVDE-OPER-CONTA-DEB-NULL V0MOVDE-NUM-CONTA-DEB-NULL V0MOVDE-DIG-CONTA-DEB-NULL */
            _.Move(1, V0MOVDE_NUM_CARTAO_NULL, V0MOVDE_COD_AGENCIA_DEB_NULL, V0MOVDE_OPER_CONTA_DEB_NULL, V0MOVDE_NUM_CONTA_DEB_NULL, V0MOVDE_DIG_CONTA_DEB_NULL);

            /*" -1165- IF V0PROPC-TIPO-COBRANCA = '1' */

            if (V0PROPC_TIPO_COBRANCA == "1")
            {

                /*" -1166- MOVE V0PROPC-COD-AGENCIA-DEB TO V0MOVDE-COD-AGENCIA-DEB */
                _.Move(V0PROPC_COD_AGENCIA_DEB, V0MOVDE_COD_AGENCIA_DEB);

                /*" -1167- MOVE V0PROPC-OPER-CONTA-DEB TO V0MOVDE-OPER-CONTA-DEB */
                _.Move(V0PROPC_OPER_CONTA_DEB, V0MOVDE_OPER_CONTA_DEB);

                /*" -1168- MOVE V0PROPC-NUM-CONTA-DEB TO V0MOVDE-NUM-CONTA-DEB */
                _.Move(V0PROPC_NUM_CONTA_DEB, V0MOVDE_NUM_CONTA_DEB);

                /*" -1169- MOVE V0PROPC-DIG-CONTA-DEB TO V0MOVDE-DIG-CONTA-DEB */
                _.Move(V0PROPC_DIG_CONTA_DEB, V0MOVDE_DIG_CONTA_DEB);

                /*" -1172- MOVE -1 TO V0MOVDE-NUM-CARTAO-NULL */
                _.Move(-1, V0MOVDE_NUM_CARTAO_NULL);

                /*" -1174- IF ((V0ENDOS-COD-PRODUTO = 5302 OR 5303 OR 5304) AND (AU085-IND-FORMA-PAGTO-AD = '3' )) */

                if (((V0ENDOS_COD_PRODUTO.In("5302", "5303", "5304")) && (AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD == "3")))
                {

                    /*" -1175- MOVE 12000 TO V0MOVDE-COD-CONVENIO */
                    _.Move(12000, V0MOVDE_COD_CONVENIO);

                    /*" -1176- ELSE */
                }
                else
                {


                    /*" -1177- MOVE V0PARAMC-COD-CONVENIO TO V0MOVDE-COD-CONVENIO */
                    _.Move(V0PARAMC_COD_CONVENIO, V0MOVDE_COD_CONVENIO);

                    /*" -1178- ELSE */
                }

            }
            else
            {


                /*" -1179- IF V0PROPC-TIPO-COBRANCA = '2' */

                if (V0PROPC_TIPO_COBRANCA == "2")
                {

                    /*" -1180- IF V0PROPC-CODPRODU EQUAL (1403 OR 1404) */

                    if (V0PROPC_CODPRODU.In("1403", "1404"))
                    {

                        /*" -1182- MOVE -1 TO V0MOVDE-COD-AGENCIA-DEB-NULL V0MOVDE-NUM-CONTA-DEB-NULL */
                        _.Move(-1, V0MOVDE_COD_AGENCIA_DEB_NULL, V0MOVDE_NUM_CONTA_DEB_NULL);

                        /*" -1183- MOVE 0004 TO V0MOVDE-OPER-CONTA-DEB-NULL */
                        _.Move(0004, V0MOVDE_OPER_CONTA_DEB_NULL);

                        /*" -1184- MOVE 152 TO V0MOVDE-DIG-CONTA-DEB-NULL */
                        _.Move(152, V0MOVDE_DIG_CONTA_DEB_NULL);

                        /*" -1185- MOVE 9019 TO V0MOVDE-COD-CONVENIO */
                        _.Move(9019, V0MOVDE_COD_CONVENIO);

                        /*" -1186- MOVE V0PROPC-NUM-CARTAO TO V0MOVDE-NUM-CARTAO */
                        _.Move(V0PROPC_NUM_CARTAO, V0MOVDE_NUM_CARTAO);

                        /*" -1187- ELSE */
                    }
                    else
                    {


                        /*" -1188- MOVE V0PROPC-NUM-CARTAO TO V0MOVDE-NUM-CARTAO */
                        _.Move(V0PROPC_NUM_CARTAO, V0MOVDE_NUM_CARTAO);

                        /*" -1192- MOVE -1 TO V0MOVDE-COD-AGENCIA-DEB-NULL V0MOVDE-OPER-CONTA-DEB-NULL V0MOVDE-NUM-CONTA-DEB-NULL V0MOVDE-DIG-CONTA-DEB-NULL */
                        _.Move(-1, V0MOVDE_COD_AGENCIA_DEB_NULL, V0MOVDE_OPER_CONTA_DEB_NULL, V0MOVDE_NUM_CONTA_DEB_NULL, V0MOVDE_DIG_CONTA_DEB_NULL);

                        /*" -1192- MOVE 23000 TO V0MOVDE-COD-CONVENIO. */
                        _.Move(23000, V0MOVDE_COD_CONVENIO);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0400-00-ABRE-V0APOLINDICA-SECTION */
        private void R0400_00_ABRE_V0APOLINDICA_SECTION()
        {
            /*" -1198- MOVE 'R0400-00-ABRE-V0APOLINDICA' TO WPARAGRAFO */
            _.Move("R0400-00-ABRE-V0APOLINDICA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1200- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1202- MOVE SPACES TO WFIMV0APOLINDICA */
            _.Move("", AREA_DE_WORK.WFIMV0APOLINDICA);

            /*" -1203- MOVE V0PROPC-NRPROPOS TO V0APOIN-NRPROPOS */
            _.Move(V0PROPC_NRPROPOS, V0APOIN_NRPROPOS);

            /*" -1205- MOVE V0PROPC-FONTE TO V0APOIN-FONTE */
            _.Move(V0PROPC_FONTE, V0APOIN_FONTE);

            /*" -1205- PERFORM R0400_00_ABRE_V0APOLINDICA_DB_OPEN_1 */

            R0400_00_ABRE_V0APOLINDICA_DB_OPEN_1();

            /*" -1208- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1209- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1209- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0400-00-ABRE-V0APOLINDICA-DB-OPEN-1 */
        public void R0400_00_ABRE_V0APOLINDICA_DB_OPEN_1()
        {
            /*" -1205- EXEC SQL OPEN V0APOLINDICA END-EXEC. */

            V0APOLINDICA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-COMISSAO-SECTION */
        private void R0500_00_PROCESSA_COMISSAO_SECTION()
        {
            /*" -1219- PERFORM R0510-00-LE-V0APOLINDICA */

            R0510_00_LE_V0APOLINDICA_SECTION();

            /*" -1220- IF WFIMV0APOLINDICA = 'S' */

            if (AREA_DE_WORK.WFIMV0APOLINDICA == "S")
            {

                /*" -1222- GO TO R0500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1224- PERFORM R0520-00-VER-COMISSIONARIO */

            R0520_00_VER_COMISSIONARIO_SECTION();

            /*" -1224- PERFORM R0570-00-UPDATE-V0APOLINDICA. */

            R0570_00_UPDATE_V0APOLINDICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LE-V0APOLINDICA-SECTION */
        private void R0510_00_LE_V0APOLINDICA_SECTION()
        {
            /*" -1233- MOVE 'R0510-00-LE-V0APOLINDICA' TO WPARAGRAFO */
            _.Move("R0510-00-LE-V0APOLINDICA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1235- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1241- PERFORM R0510_00_LE_V0APOLINDICA_DB_FETCH_1 */

            R0510_00_LE_V0APOLINDICA_DB_FETCH_1();

            /*" -1244- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1245- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1246- MOVE 'S' TO WFIMV0APOLINDICA */
                    _.Move("S", AREA_DE_WORK.WFIMV0APOLINDICA);

                    /*" -1246- PERFORM R0510_00_LE_V0APOLINDICA_DB_CLOSE_1 */

                    R0510_00_LE_V0APOLINDICA_DB_CLOSE_1();

                    /*" -1248- GO TO R0510-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                    /*" -1249- ELSE */
                }
                else
                {


                    /*" -1250- DISPLAY 'EM0015B - ' WPARAGRAFO */
                    _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1250- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-LE-V0APOLINDICA-DB-FETCH-1 */
        public void R0510_00_LE_V0APOLINDICA_DB_FETCH_1()
        {
            /*" -1241- EXEC SQL FETCH V0APOLINDICA INTO :V0APOIN-FONTE, :V0APOIN-NRPROPOS, :V0APOIN-DTINIVIG, :V0APOIN-DTTERVIG, :V0APOIN-TIPOFUNC END-EXEC. */

            if (V0APOLINDICA.Fetch())
            {
                _.Move(V0APOLINDICA.V0APOIN_FONTE, V0APOIN_FONTE);
                _.Move(V0APOLINDICA.V0APOIN_NRPROPOS, V0APOIN_NRPROPOS);
                _.Move(V0APOLINDICA.V0APOIN_DTINIVIG, V0APOIN_DTINIVIG);
                _.Move(V0APOLINDICA.V0APOIN_DTTERVIG, V0APOIN_DTTERVIG);
                _.Move(V0APOLINDICA.V0APOIN_TIPOFUNC, V0APOIN_TIPOFUNC);
            }

        }

        [StopWatch]
        /*" R0510-00-LE-V0APOLINDICA-DB-CLOSE-1 */
        public void R0510_00_LE_V0APOLINDICA_DB_CLOSE_1()
        {
            /*" -1246- EXEC SQL CLOSE V0APOLINDICA END-EXEC */

            V0APOLINDICA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-VER-COMISSIONARIO-SECTION */
        private void R0520_00_VER_COMISSIONARIO_SECTION()
        {
            /*" -1259- MOVE 'R0520-00-LE-V0APOLINDICA' TO WPARAGRAFO */
            _.Move("R0520-00-LE-V0APOLINDICA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1261- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1262- IF V0APOIN-TIPOFUNC = '1' */

            if (V0APOIN_TIPOFUNC == "1")
            {

                /*" -1263- PERFORM R0530-00-OBTEM-INDICADOR */

                R0530_00_OBTEM_INDICADOR_SECTION();

                /*" -1264- ELSE */
            }
            else
            {


                /*" -1265- IF V0APOIN-TIPOFUNC = '2' */

                if (V0APOIN_TIPOFUNC == "2")
                {

                    /*" -1266- PERFORM R0540-00-OBTEM-GERENTE */

                    R0540_00_OBTEM_GERENTE_SECTION();

                    /*" -1267- ELSE */
                }
                else
                {


                    /*" -1268- IF V0APOIN-TIPOFUNC = '3' */

                    if (V0APOIN_TIPOFUNC == "3")
                    {

                        /*" -1269- PERFORM R0550-00-OBTEM-ESCNEG */

                        R0550_00_OBTEM_ESCNEG_SECTION();

                        /*" -1270- ELSE */
                    }
                    else
                    {


                        /*" -1271- IF V0APOIN-TIPOFUNC = '4' */

                        if (V0APOIN_TIPOFUNC == "4")
                        {

                            /*" -1272- MOVE 9999999 TO V0APOIN-NUM-MATRICULA */
                            _.Move(9999999, V0APOIN_NUM_MATRICULA);

                            /*" -1273- MOVE 9999 TO V0APOIN-COD-AGENCIA */
                            _.Move(9999, V0APOIN_COD_AGENCIA);

                            /*" -1275- MOVE 9999 TO V0APOIN-OPERACAO-CONTA */
                            _.Move(9999, V0APOIN_OPERACAO_CONTA);

                            /*" -1276- MOVE 999999999999 TO V0APOIN-NUM-CONTA */
                            _.Move(999999999999, V0APOIN_NUM_CONTA);

                            /*" -1277- MOVE 9 TO V0APOIN-DIG-CONTA */
                            _.Move(9, V0APOIN_DIG_CONTA);

                            /*" -1278- ELSE */
                        }
                        else
                        {


                            /*" -1279- IF V0APOIN-TIPOFUNC = '5' */

                            if (V0APOIN_TIPOFUNC == "5")
                            {

                                /*" -1280- MOVE 8888888 TO V0APOIN-NUM-MATRICULA */
                                _.Move(8888888, V0APOIN_NUM_MATRICULA);

                                /*" -1281- MOVE 8888 TO V0APOIN-COD-AGENCIA */
                                _.Move(8888, V0APOIN_COD_AGENCIA);

                                /*" -1283- MOVE 8888 TO V0APOIN-OPERACAO-CONTA */
                                _.Move(8888, V0APOIN_OPERACAO_CONTA);

                                /*" -1284- MOVE 888888888888 TO V0APOIN-NUM-CONTA */
                                _.Move(888888888888, V0APOIN_NUM_CONTA);

                                /*" -1284- MOVE 8 TO V0APOIN-DIG-CONTA. */
                                _.Move(8, V0APOIN_DIG_CONTA);
                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-OBTEM-INDICADOR-SECTION */
        private void R0530_00_OBTEM_INDICADOR_SECTION()
        {
            /*" -1298- MOVE 'R0530-00-OBTEM-INDICADOR' TO WPARAGRAFO */
            _.Move("R0530-00-OBTEM-INDICADOR", AREA_DE_WORK.WPARAGRAFO);

            /*" -1300- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1301- MOVE V0APOLC-NUM-MATRICULA TO V0APOIN-NUM-MATRICULA */
            _.Move(V0APOLC_NUM_MATRICULA, V0APOIN_NUM_MATRICULA);

            /*" -1302- MOVE V0PROPC-COD-AGENCIA TO V0APOIN-COD-AGENCIA */
            _.Move(V0PROPC_COD_AGENCIA, V0APOIN_COD_AGENCIA);

            /*" -1303- MOVE V0PROPC-OPERACAO-CONTA TO V0APOIN-OPERACAO-CONTA */
            _.Move(V0PROPC_OPERACAO_CONTA, V0APOIN_OPERACAO_CONTA);

            /*" -1304- MOVE V0PROPC-NUM-CONTA TO V0APOIN-NUM-CONTA */
            _.Move(V0PROPC_NUM_CONTA, V0APOIN_NUM_CONTA);

            /*" -1304- MOVE V0PROPC-DIG-CONTA TO V0APOIN-DIG-CONTA. */
            _.Move(V0PROPC_DIG_CONTA, V0APOIN_DIG_CONTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R0540-00-OBTEM-GERENTE-SECTION */
        private void R0540_00_OBTEM_GERENTE_SECTION()
        {
            /*" -1312- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0541_00_LE_V0PRODGER */

            R0541_00_LE_V0PRODGER();

        }

        [StopWatch]
        /*" R0541-00-LE-V0PRODGER */
        private void R0541_00_LE_V0PRODGER(bool isPerform = false)
        {
            /*" -1316- MOVE 'R0541-00-LE-V0PRODGER       ' TO WPARAGRAFO */
            _.Move("R0541-00-LE-V0PRODGER       ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1318- MOVE '541' TO WNR-EXEC-SQL. */
            _.Move("541", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1319- MOVE V0PROPC-COD-AGENCIA TO V0PRODG-COD-AGENCIA */
            _.Move(V0PROPC_COD_AGENCIA, V0PRODG_COD_AGENCIA);

            /*" -1322- MOVE V0ENDOS-DTINIVIG TO V0PRODG-DATA-INIVIGENCIA V0PRODG-DATA-TERVIGENCIA */
            _.Move(V0ENDOS_DTINIVIG, V0PRODG_DATA_INIVIGENCIA, V0PRODG_DATA_TERVIGENCIA);

            /*" -1332- PERFORM R0541_00_LE_V0PRODGER_DB_SELECT_1 */

            R0541_00_LE_V0PRODGER_DB_SELECT_1();

            /*" -1335- IF SQLCODE LESS THAN ZEROS */

            if (DB.SQLCODE < 00)
            {

                /*" -1336- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1338- DISPLAY 'V0PRODG-COD-AGENCIA      ' V0PRODG-COD-AGENCIA */
                _.Display($"V0PRODG-COD-AGENCIA      {V0PRODG_COD_AGENCIA}");

                /*" -1340- DISPLAY 'V0PRODG-DATA-INIVIGENCIA ' V0PRODG-DATA-INIVIGENCIA */
                _.Display($"V0PRODG-DATA-INIVIGENCIA {V0PRODG_DATA_INIVIGENCIA}");

                /*" -1342- DISPLAY 'V0PRODG-DATA-TERVIGENCIA ' V0PRODG-DATA-TERVIGENCIA */
                _.Display($"V0PRODG-DATA-TERVIGENCIA {V0PRODG_DATA_TERVIGENCIA}");

                /*" -1344- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1345- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -1347- GO TO R0541-10-LE-V0PRODUTOR. */

                R0541_10_LE_V0PRODUTOR(); //GOTO
                return;
            }


            /*" -1347- PERFORM R0541-05-LE-V0PRODGER. */

            R0541_05_LE_V0PRODGER(true);

        }

        [StopWatch]
        /*" R0541-00-LE-V0PRODGER-DB-SELECT-1 */
        public void R0541_00_LE_V0PRODGER_DB_SELECT_1()
        {
            /*" -1332- EXEC SQL SELECT COD_PROD_GERENTE INTO :V0PRODG-COD-PROD-GERENTE FROM SEGUROS.V0PRODGER WHERE COD_AGENCIA = :V0PRODG-COD-AGENCIA AND DATA_INIVIGENCIA <= :V0PRODG-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :V0PRODG-DATA-TERVIGENCIA END-EXEC. */

            var r0541_00_LE_V0PRODGER_DB_SELECT_1_Query1 = new R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1()
            {
                V0PRODG_DATA_INIVIGENCIA = V0PRODG_DATA_INIVIGENCIA.ToString(),
                V0PRODG_DATA_TERVIGENCIA = V0PRODG_DATA_TERVIGENCIA.ToString(),
                V0PRODG_COD_AGENCIA = V0PRODG_COD_AGENCIA.ToString(),
            };

            var executed_1 = R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1.Execute(r0541_00_LE_V0PRODGER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRODG_COD_PROD_GERENTE, V0PRODG_COD_PROD_GERENTE);
            }


        }

        [StopWatch]
        /*" R0541-05-LE-V0PRODGER */
        private void R0541_05_LE_V0PRODGER(bool isPerform = false)
        {
            /*" -1352- MOVE 'R0541-05-LE-V0PRODGER       ' TO WPARAGRAFO */
            _.Move("R0541-05-LE-V0PRODGER       ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1354- MOVE '541' TO WNR-EXEC-SQL. */
            _.Move("541", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1362- PERFORM R0541_05_LE_V0PRODGER_DB_SELECT_1 */

            R0541_05_LE_V0PRODGER_DB_SELECT_1();

            /*" -1365- IF SQLCODE LESS THAN ZEROS */

            if (DB.SQLCODE < 00)
            {

                /*" -1366- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1368- DISPLAY 'V0PRODG-COD-AGENCIA      ' V0PRODG-COD-AGENCIA */
                _.Display($"V0PRODG-COD-AGENCIA      {V0PRODG_COD_AGENCIA}");

                /*" -1370- DISPLAY 'V0PRODG-DATA-INIVIGENCIA ' V0PRODG-DATA-INIVIGENCIA */
                _.Display($"V0PRODG-DATA-INIVIGENCIA {V0PRODG_DATA_INIVIGENCIA}");

                /*" -1372- DISPLAY 'V0PRODG-DATA-TERVIGENCIA ' V0PRODG-DATA-TERVIGENCIA */
                _.Display($"V0PRODG-DATA-TERVIGENCIA {V0PRODG_DATA_TERVIGENCIA}");

                /*" -1372- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0541-05-LE-V0PRODGER-DB-SELECT-1 */
        public void R0541_05_LE_V0PRODGER_DB_SELECT_1()
        {
            /*" -1362- EXEC SQL SELECT COD_PROD_GERENTE INTO :V0PRODG-COD-PROD-GERENTE FROM SEGUROS.V0PRODGER WHERE COD_AGENCIA = :V0PRODG-COD-AGENCIA END-EXEC. */

            var r0541_05_LE_V0PRODGER_DB_SELECT_1_Query1 = new R0541_05_LE_V0PRODGER_DB_SELECT_1_Query1()
            {
                V0PRODG_COD_AGENCIA = V0PRODG_COD_AGENCIA.ToString(),
            };

            var executed_1 = R0541_05_LE_V0PRODGER_DB_SELECT_1_Query1.Execute(r0541_05_LE_V0PRODGER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRODG_COD_PROD_GERENTE, V0PRODG_COD_PROD_GERENTE);
            }


        }

        [StopWatch]
        /*" R0541-10-LE-V0PRODUTOR */
        private void R0541_10_LE_V0PRODUTOR(bool isPerform = false)
        {
            /*" -1378- MOVE 'R0541-10-LE-V0PRODUTOR      ' TO WPARAGRAFO */
            _.Move("R0541-10-LE-V0PRODUTOR      ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1380- MOVE '541' TO WNR-EXEC-SQL. */
            _.Move("541", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1382- MOVE V0PRODG-COD-PROD-GERENTE TO V0PRODU-CODPDT. */
            _.Move(V0PRODG_COD_PROD_GERENTE, V0PRODU_CODPDT);

            /*" -1390- PERFORM R0541_10_LE_V0PRODUTOR_DB_SELECT_1 */

            R0541_10_LE_V0PRODUTOR_DB_SELECT_1();

            /*" -1393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1394- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1395- IF V0PRODG-COD-PROD-GERENTE NOT EQUAL ZEROS */

                    if (V0PRODG_COD_PROD_GERENTE != 00)
                    {

                        /*" -1396- MOVE V0PRODG-COD-PROD-GERENTE TO V0PRODU-CHPFUN */
                        _.Move(V0PRODG_COD_PROD_GERENTE, V0PRODU_CHPFUN);

                        /*" -1397- ELSE */
                    }
                    else
                    {


                        /*" -1398- MOVE 7777777 TO V0PRODU-CHPFUN */
                        _.Move(7777777, V0PRODU_CHPFUN);

                        /*" -1399- ELSE */
                    }

                }
                else
                {


                    /*" -1400- DISPLAY 'EM0015B - ' WPARAGRAFO */
                    _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1401- DISPLAY 'V0PRODU-CODPDT  = ' V0PRODU-CODPDT */
                    _.Display($"V0PRODU-CODPDT  = {V0PRODU_CODPDT}");

                    /*" -1402- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1403- ELSE */
                }

            }
            else
            {


                /*" -1404- IF V0PRODU-CHPFUN EQUAL ZEROS */

                if (V0PRODU_CHPFUN == 00)
                {

                    /*" -1407- IF V0PRODG-COD-PROD-GERENTE NOT EQUAL ZEROS */

                    if (V0PRODG_COD_PROD_GERENTE != 00)
                    {

                        /*" -1408- MOVE V0PRODG-COD-PROD-GERENTE TO V0PRODU-CHPFUN */
                        _.Move(V0PRODG_COD_PROD_GERENTE, V0PRODU_CHPFUN);

                        /*" -1411- ELSE */
                    }
                    else
                    {


                        /*" -1413- MOVE 7777777 TO V0PRODU-CHPFUN. */
                        _.Move(7777777, V0PRODU_CHPFUN);
                    }

                }

            }


            /*" -1413- PERFORM R0542-00-LE-V0FUNCIOCEF. */

            R0542_00_LE_V0FUNCIOCEF(true);

        }

        [StopWatch]
        /*" R0541-10-LE-V0PRODUTOR-DB-SELECT-1 */
        public void R0541_10_LE_V0PRODUTOR_DB_SELECT_1()
        {
            /*" -1390- EXEC SQL SELECT CHPFUN INTO :V0PRODU-CHPFUN FROM SEGUROS.V0PRODUTOR WHERE CODPDT = :V0PRODU-CODPDT END-EXEC. */

            var r0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1 = new R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1()
            {
                V0PRODU_CODPDT = V0PRODU_CODPDT.ToString(),
            };

            var executed_1 = R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1.Execute(r0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRODU_CHPFUN, V0PRODU_CHPFUN);
            }


        }

        [StopWatch]
        /*" R0542-00-LE-V0FUNCIOCEF */
        private void R0542_00_LE_V0FUNCIOCEF(bool isPerform = false)
        {
            /*" -1418- MOVE 'R0542-00-LE-V0FUNCIOCEF     ' TO WPARAGRAFO */
            _.Move("R0542-00-LE-V0FUNCIOCEF     ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1420- MOVE '542' TO WNR-EXEC-SQL. */
            _.Move("542", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1422- MOVE V0PRODU-CHPFUN TO V0FUNCI-NUM-MATRICULA. */
            _.Move(V0PRODU_CHPFUN, V0FUNCI_NUM_MATRICULA);

            /*" -1438- PERFORM R0542_00_LE_V0FUNCIOCEF_DB_SELECT_1 */

            R0542_00_LE_V0FUNCIOCEF_DB_SELECT_1();

            /*" -1441- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1442- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1443- DISPLAY 'V0ENDOS-NUM-APOLICE    ' V0ENDOS-NUM-APOLICE */
                _.Display($"V0ENDOS-NUM-APOLICE    {V0ENDOS_NUM_APOLICE}");

                /*" -1444- DISPLAY 'V0ENDOS-NRENDOS        ' V0ENDOS-NRENDOS */
                _.Display($"V0ENDOS-NRENDOS        {V0ENDOS_NRENDOS}");

                /*" -1445- DISPLAY 'V0APOIN-FONTE          ' V0APOIN-FONTE */
                _.Display($"V0APOIN-FONTE          {V0APOIN_FONTE}");

                /*" -1446- DISPLAY 'V0APOIN-NRPROPOS       ' V0APOIN-NRPROPOS */
                _.Display($"V0APOIN-NRPROPOS       {V0APOIN_NRPROPOS}");

                /*" -1447- DISPLAY 'V0FUNCI-NUM-MATRICULA  ' V0FUNCI-NUM-MATRICULA */
                _.Display($"V0FUNCI-NUM-MATRICULA  {V0FUNCI_NUM_MATRICULA}");

                /*" -1449- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1450- MOVE V0FUNCI-NUM-MATRICULA TO V0APOIN-NUM-MATRICULA */
            _.Move(V0FUNCI_NUM_MATRICULA, V0APOIN_NUM_MATRICULA);

            /*" -1451- MOVE V0FUNCI-COD-AGENCIA TO V0APOIN-COD-AGENCIA */
            _.Move(V0FUNCI_COD_AGENCIA, V0APOIN_COD_AGENCIA);

            /*" -1452- MOVE V0FUNCI-OPERACAO-CONTA TO V0APOIN-OPERACAO-CONTA */
            _.Move(V0FUNCI_OPERACAO_CONTA, V0APOIN_OPERACAO_CONTA);

            /*" -1453- MOVE V0FUNCI-NUM-CONTA TO V0APOIN-NUM-CONTA */
            _.Move(V0FUNCI_NUM_CONTA, V0APOIN_NUM_CONTA);

            /*" -1453- MOVE V0FUNCI-DIG-CONTA TO V0APOIN-DIG-CONTA. */
            _.Move(V0FUNCI_DIG_CONTA, V0APOIN_DIG_CONTA);

        }

        [StopWatch]
        /*" R0542-00-LE-V0FUNCIOCEF-DB-SELECT-1 */
        public void R0542_00_LE_V0FUNCIOCEF_DB_SELECT_1()
        {
            /*" -1438- EXEC SQL SELECT NUM_MATRICULA, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA INTO :V0FUNCI-NUM-MATRICULA, :V0FUNCI-COD-AGENCIA, :V0FUNCI-OPERACAO-CONTA, :V0FUNCI-NUM-CONTA, :V0FUNCI-DIG-CONTA FROM SEGUROS.V0FUNCIOCEF WHERE NUM_MATRICULA = :V0FUNCI-NUM-MATRICULA END-EXEC. */

            var r0542_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1 = new R0542_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1()
            {
                V0FUNCI_NUM_MATRICULA = V0FUNCI_NUM_MATRICULA.ToString(),
            };

            var executed_1 = R0542_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1.Execute(r0542_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FUNCI_NUM_MATRICULA, V0FUNCI_NUM_MATRICULA);
                _.Move(executed_1.V0FUNCI_COD_AGENCIA, V0FUNCI_COD_AGENCIA);
                _.Move(executed_1.V0FUNCI_OPERACAO_CONTA, V0FUNCI_OPERACAO_CONTA);
                _.Move(executed_1.V0FUNCI_NUM_CONTA, V0FUNCI_NUM_CONTA);
                _.Move(executed_1.V0FUNCI_DIG_CONTA, V0FUNCI_DIG_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0540_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-OBTEM-ESCNEG-SECTION */
        private void R0550_00_OBTEM_ESCNEG_SECTION()
        {
            /*" -1461- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0551_00_LE_V0AGENCIACEF */

            R0551_00_LE_V0AGENCIACEF();

        }

        [StopWatch]
        /*" R0551-00-LE-V0AGENCIACEF */
        private void R0551_00_LE_V0AGENCIACEF(bool isPerform = false)
        {
            /*" -1465- MOVE 'R0551-00-LE-V0AGENCIACEF    ' TO WPARAGRAFO */
            _.Move("R0551-00-LE-V0AGENCIACEF    ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1467- MOVE '551' TO WNR-EXEC-SQL. */
            _.Move("551", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1469- MOVE V0PROPC-COD-AGENCIA TO V0AGENC-COD-AGENCIA */
            _.Move(V0PROPC_COD_AGENCIA, V0AGENC_COD_AGENCIA);

            /*" -1477- PERFORM R0551_00_LE_V0AGENCIACEF_DB_SELECT_1 */

            R0551_00_LE_V0AGENCIACEF_DB_SELECT_1();

            /*" -1480- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1481- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1482- DISPLAY 'V0AGENC-COD-AGENCIA ' V0AGENC-COD-AGENCIA */
                _.Display($"V0AGENC-COD-AGENCIA {V0AGENC_COD_AGENCIA}");

                /*" -1484- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1484- PERFORM R0552-00-LE-V0PRODESCNEG. */

            R0552_00_LE_V0PRODESCNEG(true);

        }

        [StopWatch]
        /*" R0551-00-LE-V0AGENCIACEF-DB-SELECT-1 */
        public void R0551_00_LE_V0AGENCIACEF_DB_SELECT_1()
        {
            /*" -1477- EXEC SQL SELECT COD_ESCNEG INTO :V0AGENC-COD-ESCNEG FROM SEGUROS.V0AGENCIACEF WHERE COD_AGENCIA = :V0AGENC-COD-AGENCIA END-EXEC. */

            var r0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1 = new R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1()
            {
                V0AGENC_COD_AGENCIA = V0AGENC_COD_AGENCIA.ToString(),
            };

            var executed_1 = R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1.Execute(r0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AGENC_COD_ESCNEG, V0AGENC_COD_ESCNEG);
            }


        }

        [StopWatch]
        /*" R0552-00-LE-V0PRODESCNEG */
        private void R0552_00_LE_V0PRODESCNEG(bool isPerform = false)
        {
            /*" -1489- MOVE 'R0552-00-LE-V0PRODESCNEG    ' TO WPARAGRAFO */
            _.Move("R0552-00-LE-V0PRODESCNEG    ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1491- MOVE '552' TO WNR-EXEC-SQL. */
            _.Move("552", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1492- MOVE V0AGENC-COD-ESCNEG TO V0PRODE-COD-ESCNEG */
            _.Move(V0AGENC_COD_ESCNEG, V0PRODE_COD_ESCNEG);

            /*" -1495- MOVE V0ENDOS-DTINIVIG TO V0PRODE-DATA-INIVIGENCIA V0PRODE-DATA-TERVIGENCIA */
            _.Move(V0ENDOS_DTINIVIG, V0PRODE_DATA_INIVIGENCIA, V0PRODE_DATA_TERVIGENCIA);

            /*" -1505- PERFORM R0552_00_LE_V0PRODESCNEG_DB_SELECT_1 */

            R0552_00_LE_V0PRODESCNEG_DB_SELECT_1();

            /*" -1508- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1509- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1510- MOVE 7777777 TO V0PRODE-NUM-MATRICULA */
                    _.Move(7777777, V0PRODE_NUM_MATRICULA);

                    /*" -1511- ELSE */
                }
                else
                {


                    /*" -1512- DISPLAY 'EM0015B - ' WPARAGRAFO */
                    _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1514- DISPLAY 'V0PRODE-COD-ESCNEG       ' V0PRODE-COD-ESCNEG */
                    _.Display($"V0PRODE-COD-ESCNEG       {V0PRODE_COD_ESCNEG}");

                    /*" -1516- DISPLAY 'V0PRODE-DATA-INIVIGENCIA ' V0PRODE-DATA-INIVIGENCIA */
                    _.Display($"V0PRODE-DATA-INIVIGENCIA {V0PRODE_DATA_INIVIGENCIA}");

                    /*" -1518- DISPLAY 'V0PRODE-DATA-TERVIGENCIA ' V0PRODE-DATA-TERVIGENCIA */
                    _.Display($"V0PRODE-DATA-TERVIGENCIA {V0PRODE_DATA_TERVIGENCIA}");

                    /*" -1520- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1520- PERFORM R0553-00-LE-V0FUNCIOCEF. */

            R0553_00_LE_V0FUNCIOCEF(true);

        }

        [StopWatch]
        /*" R0552-00-LE-V0PRODESCNEG-DB-SELECT-1 */
        public void R0552_00_LE_V0PRODESCNEG_DB_SELECT_1()
        {
            /*" -1505- EXEC SQL SELECT NUM_MATRICULA INTO :V0PRODE-NUM-MATRICULA FROM SEGUROS.V0PRODESCNEG WHERE COD_ESCNEG = :V0PRODE-COD-ESCNEG AND DATA_INIVIGENCIA <= :V0PRODE-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :V0PRODE-DATA-TERVIGENCIA END-EXEC. */

            var r0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1 = new R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1()
            {
                V0PRODE_DATA_INIVIGENCIA = V0PRODE_DATA_INIVIGENCIA.ToString(),
                V0PRODE_DATA_TERVIGENCIA = V0PRODE_DATA_TERVIGENCIA.ToString(),
                V0PRODE_COD_ESCNEG = V0PRODE_COD_ESCNEG.ToString(),
            };

            var executed_1 = R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1.Execute(r0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRODE_NUM_MATRICULA, V0PRODE_NUM_MATRICULA);
            }


        }

        [StopWatch]
        /*" R0553-00-LE-V0FUNCIOCEF */
        private void R0553_00_LE_V0FUNCIOCEF(bool isPerform = false)
        {
            /*" -1525- MOVE 'R0553-00-LE-V0FUNCIOCEF     ' TO WPARAGRAFO */
            _.Move("R0553-00-LE-V0FUNCIOCEF     ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1527- MOVE '553' TO WNR-EXEC-SQL. */
            _.Move("553", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1529- MOVE V0PRODE-NUM-MATRICULA TO V0FUNCI-NUM-MATRICULA */
            _.Move(V0PRODE_NUM_MATRICULA, V0FUNCI_NUM_MATRICULA);

            /*" -1543- PERFORM R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1 */

            R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1();

            /*" -1546- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1547- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1548- DISPLAY 'V0FUNCI-NUM-MATRICULA ' V0FUNCI-NUM-MATRICULA */
                _.Display($"V0FUNCI-NUM-MATRICULA {V0FUNCI_NUM_MATRICULA}");

                /*" -1550- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1551- MOVE V0FUNCI-NUM-MATRICULA TO V0APOIN-NUM-MATRICULA */
            _.Move(V0FUNCI_NUM_MATRICULA, V0APOIN_NUM_MATRICULA);

            /*" -1552- MOVE V0FUNCI-COD-AGENCIA TO V0APOIN-COD-AGENCIA */
            _.Move(V0FUNCI_COD_AGENCIA, V0APOIN_COD_AGENCIA);

            /*" -1553- MOVE V0FUNCI-OPERACAO-CONTA TO V0APOIN-OPERACAO-CONTA */
            _.Move(V0FUNCI_OPERACAO_CONTA, V0APOIN_OPERACAO_CONTA);

            /*" -1554- MOVE V0FUNCI-NUM-CONTA TO V0APOIN-NUM-CONTA */
            _.Move(V0FUNCI_NUM_CONTA, V0APOIN_NUM_CONTA);

            /*" -1554- MOVE V0FUNCI-DIG-CONTA TO V0APOIN-DIG-CONTA. */
            _.Move(V0FUNCI_DIG_CONTA, V0APOIN_DIG_CONTA);

        }

        [StopWatch]
        /*" R0553-00-LE-V0FUNCIOCEF-DB-SELECT-1 */
        public void R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1()
        {
            /*" -1543- EXEC SQL SELECT COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA INTO :V0FUNCI-COD-AGENCIA, :V0FUNCI-OPERACAO-CONTA, :V0FUNCI-NUM-CONTA, :V0FUNCI-DIG-CONTA FROM SEGUROS.V0FUNCIOCEF WHERE NUM_MATRICULA = :V0FUNCI-NUM-MATRICULA END-EXEC. */

            var r0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1 = new R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1()
            {
                V0FUNCI_NUM_MATRICULA = V0FUNCI_NUM_MATRICULA.ToString(),
            };

            var executed_1 = R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1.Execute(r0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FUNCI_COD_AGENCIA, V0FUNCI_COD_AGENCIA);
                _.Move(executed_1.V0FUNCI_OPERACAO_CONTA, V0FUNCI_OPERACAO_CONTA);
                _.Move(executed_1.V0FUNCI_NUM_CONTA, V0FUNCI_NUM_CONTA);
                _.Move(executed_1.V0FUNCI_DIG_CONTA, V0FUNCI_DIG_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0570-00-UPDATE-V0APOLINDICA-SECTION */
        private void R0570_00_UPDATE_V0APOLINDICA_SECTION()
        {
            /*" -1563- MOVE 'R0570-00-UPDATE-V0APOLINDICA' TO WPARAGRAFO */
            _.Move("R0570-00-UPDATE-V0APOLINDICA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1565- MOVE '570' TO WNR-EXEC-SQL. */
            _.Move("570", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1566- MOVE V0APOLC-NUM-APOLICE TO V0APOIN-NUM-APOLICE */
            _.Move(V0APOLC_NUM_APOLICE, V0APOIN_NUM_APOLICE);

            /*" -1567- MOVE 0 TO V0APOIN-NRENDOS */
            _.Move(0, V0APOIN_NRENDOS);

            /*" -1568- MOVE V0ENDOS-DTINIVIG TO V0APOIN-DTINIVIG */
            _.Move(V0ENDOS_DTINIVIG, V0APOIN_DTINIVIG);

            /*" -1570- MOVE V0ENDOS-DTTERVIG TO V0APOIN-DTTERVIG */
            _.Move(V0ENDOS_DTTERVIG, V0APOIN_DTTERVIG);

            /*" -1577- PERFORM R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1 */

            R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1();

            /*" -1580- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1581- DISPLAY 'EM0015B - ' WPARAGRAFO */
                _.Display($"EM0015B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1582- DISPLAY 'V0APOIN-FONTE    ' V0APOIN-FONTE */
                _.Display($"V0APOIN-FONTE    {V0APOIN_FONTE}");

                /*" -1583- DISPLAY 'V0APOIN-NRPROPOS ' V0APOIN-NRPROPOS */
                _.Display($"V0APOIN-NRPROPOS {V0APOIN_NRPROPOS}");

                /*" -1584- DISPLAY 'V0APOIN-TIPOFUNC ' V0APOIN-TIPOFUNC */
                _.Display($"V0APOIN-TIPOFUNC {V0APOIN_TIPOFUNC}");

                /*" -1584- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0570-00-UPDATE-V0APOLINDICA-DB-UPDATE-1 */
        public void R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1()
        {
            /*" -1577- EXEC SQL UPDATE SEGUROS.V0APOLINDICA SET NUM_APOLICE = :V0APOIN-NUM-APOLICE, NRENDOS = :V0APOIN-NRENDOS, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0APOIN-FONTE AND NRPROPOS = :V0APOIN-NRPROPOS AND TIPOFUNC = :V0APOIN-TIPOFUNC END-EXEC. */

            var r0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1 = new R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1()
            {
                V0APOIN_NUM_APOLICE = V0APOIN_NUM_APOLICE.ToString(),
                V0APOIN_NRENDOS = V0APOIN_NRENDOS.ToString(),
                V0APOIN_NRPROPOS = V0APOIN_NRPROPOS.ToString(),
                V0APOIN_TIPOFUNC = V0APOIN_TIPOFUNC.ToString(),
                V0APOIN_FONTE = V0APOIN_FONTE.ToString(),
            };

            R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1.Execute(r0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-LER-TITULO-LOTERICO-SECTION */
        private void R0600_00_LER_TITULO_LOTERICO_SECTION()
        {
            /*" -1602- PERFORM R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1 */

            R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1();

            /*" -1605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1607- DISPLAY ' R600-ERRO SELECT MAX SEQ LT_MOV_PROPOSTA' ' ' V0EMISD-NUM-APOLICE */

                $" R600-ERRO SELECT MAX SEQ LT_MOV_PROPOSTA {V0EMISD_NUM_APOLICE}"
                .Display();

                /*" -1610- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1619- PERFORM R0600_00_LER_TITULO_LOTERICO_DB_SELECT_2 */

            R0600_00_LER_TITULO_LOTERICO_DB_SELECT_2();

            /*" -1622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1625- DISPLAY 'R0600-ERRO SELECT LT_MOV_PROPOSTA' 'APO=' V0EMISD-NUM-APOLICE 'SEQ=' LTMVPROP-SEQ-PROPOSTA */

                $"R0600-ERRO SELECT LT_MOV_PROPOSTAAPO={V0EMISD_NUM_APOLICE}SEQ={LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA}"
                .Display();

                /*" -1630- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1631- IF LTMVPROP-IND-TIPO-ENDOSSO EQUAL 800 */

            if (LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_ENDOSSO == 800)
            {

                /*" -1633- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1634- MOVE LTMVPROP-NUM-TITULO TO RCAPS-NUM-TITULO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -1637- MOVE 0 TO RCAPS-VAL-RCAP FOLLOUP-VAL-OPERACAO. */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

            /*" -1644- PERFORM R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3 */

            R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3();

            /*" -1647- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1648- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1653- DISPLAY 'R0600-NAO HOUVE PGTO DO TITULO DE ADESAO' ' DEBITO INTEGRAL DA 1.PARCELA           ' ' LOT =' LTMVPROP-COD-EXT-SEGURADO ' TIT =' RCAPS-NUM-TITULO ' SQLCODE=' WSQLCODE */

                $"R0600-NAO HOUVE PGTO DO TITULO DE ADESAO DEBITO INTEGRAL DA 1.PARCELA            LOT ={LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO} TIT ={RCAPS.DCLRCAPS.RCAPS_NUM_TITULO} SQLCODE={AREA_DE_WORK.WABEND.WSQLCODE}"
                .Display();

                /*" -1658- GO TO R0600-99-SAIDA . */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1660- GO TO R0600-10-TOTAL-PAGO. */

            R0600_10_TOTAL_PAGO(); //GOTO
            return;

        }

        [StopWatch]
        /*" R0600-00-LER-TITULO-LOTERICO-DB-SELECT-1 */
        public void R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1()
        {
            /*" -1602- EXEC SQL SELECT VALUE(MAX(SEQ_PROPOSTA),0) INTO :LTMVPROP-SEQ-PROPOSTA FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :V0EMISD-NUM-APOLICE AND COD_MOVIMENTO = '9' AND SIT_MOVIMENTO IN ( '1' , 'T' ) END-EXEC. */

            var r0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1 = new R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1()
            {
                V0EMISD_NUM_APOLICE = V0EMISD_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1.Execute(r0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPROP_SEQ_PROPOSTA, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R0600-10-TOTAL-PAGO */
        private void R0600_10_TOTAL_PAGO(bool isPerform = false)
        {
            /*" -1681- IF RCAPS-VAL-RCAP <= V0MOVDE-VLR-DEBITO */

            if (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP <= V0MOVDE_VLR_DEBITO)
            {

                /*" -1683- COMPUTE V0MOVDE-VLR-DEBITO = V0MOVDE-VLR-DEBITO - RCAPS-VAL-RCAP */
                V0MOVDE_VLR_DEBITO.Value = V0MOVDE_VLR_DEBITO - RCAPS.DCLRCAPS.RCAPS_VAL_RCAP;

                /*" -1684- ELSE */
            }
            else
            {


                /*" -1689- DISPLAY ' R0600 - PAGO A MAIOR POR BOLETO  ' ' CUSTO ADESAO NAO DESCONTADO      ' ' DEBITO INTEGRAL 1.PARCELA        ' ' LOT = ' LTMVPROP-COD-EXT-SEGURADO ' TIT = ' LTMVPROP-NUM-TITULO ' VLR=' RCAPS-VAL-RCAP . */

                $" R0600 - PAGO A MAIOR POR BOLETO   CUSTO ADESAO NAO DESCONTADO       DEBITO INTEGRAL 1.PARCELA         LOT = {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO} TIT = {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_TITULO} VLR={RCAPS.DCLRCAPS.RCAPS_VAL_RCAP}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0600-00-LER-TITULO-LOTERICO-DB-SELECT-2 */
        public void R0600_00_LER_TITULO_LOTERICO_DB_SELECT_2()
        {
            /*" -1619- EXEC SQL SELECT VALUE(NUM_TITULO,0),VALUE(IND_TIPO_ENDOSSO,0) INTO :LTMVPROP-NUM-TITULO :VIND-NUM-TITULO , :LTMVPROP-IND-TIPO-ENDOSSO FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :V0EMISD-NUM-APOLICE AND SEQ_PROPOSTA = :LTMVPROP-SEQ-PROPOSTA AND COD_MOVIMENTO = '9' AND SIT_MOVIMENTO IN ( '1' , 'T' ) END-EXEC. */

            var r0600_00_LER_TITULO_LOTERICO_DB_SELECT_2_Query1 = new R0600_00_LER_TITULO_LOTERICO_DB_SELECT_2_Query1()
            {
                LTMVPROP_SEQ_PROPOSTA = LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA.ToString(),
                V0EMISD_NUM_APOLICE = V0EMISD_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0600_00_LER_TITULO_LOTERICO_DB_SELECT_2_Query1.Execute(r0600_00_LER_TITULO_LOTERICO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPROP_NUM_TITULO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_TITULO);
                _.Move(executed_1.VIND_NUM_TITULO, VIND_NUM_TITULO);
                _.Move(executed_1.LTMVPROP_IND_TIPO_ENDOSSO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-LER-TITULO-LOTERICO-DB-SELECT-3 */
        public void R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3()
        {
            /*" -1644- EXEC SQL SELECT VLRCAP , VALUE(SITUACAO, ' ' ) INTO :RCAPS-VAL-RCAP , :RCAPS-SIT-REGISTRO FROM SEGUROS.V0RCAP WHERE NRTIT = :RCAPS-NUM-TITULO END-EXEC. */

            var r0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1 = new R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1.Execute(r0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1698- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1700- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1700- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1702- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1706- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1706- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0600-00-LER-TITULO-LOTERICO-DB-SELECT-4 */
        public void R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4()
        {
            /*" -1667- EXEC SQL SELECT VLPREMIO , SITUACAO INTO :FOLLOUP-VAL-OPERACAO , :FOLLOUP-SIT-REGISTRO FROM SEGUROS.V0FOLLOWUP WHERE NUM_APOLICE = :LTMVPROP-NUM-TITULO END-EXEC. */

            var r0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1 = new R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1()
            {
                LTMVPROP_NUM_TITULO = LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_TITULO.ToString(),
            };

            var executed_1 = R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1.Execute(r0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FOLLOUP_VAL_OPERACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);
                _.Move(executed_1.FOLLOUP_SIT_REGISTRO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO);
            }


        }
    }
}