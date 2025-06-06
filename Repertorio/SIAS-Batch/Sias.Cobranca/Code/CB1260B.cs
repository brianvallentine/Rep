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
using Sias.Cobranca.DB2.CB1260B;

namespace Code
{
    public class CB1260B
    {
        public bool IsCall { get; set; }

        public CB1260B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB1260B                            *      */
        /*"      *   ANALISTA / PROGRAMADOR..  CARLOS ALBERTO DE A ALVES          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................. -VERSAO DO PROGRAMA CB0260B         *      */
        /*"      *                            -SELECIONAR AS PARCELAS EM ATRASO P/*      */
        /*"      *                             CADASTRAMENTO NA TABELA            *      */
        /*"      *                             CB_APOLICE_VIGPROP, QUE CONTROLA A *      */
        /*"      *                             NOVA VIGENCIA E O PROVAVEL CANCE-  *      */
        /*"      *                             LAMENTO DA APOLICE.        ALEM DE *      */
        /*"      *                             CADASTRAR NA CB_MALA_PARCATRASO,   *      */
        /*"      *                             INFORMACOES PARA EMISSAO DO BOLETO *      */
        /*"      *                             BANCARIO DE COBRANCA.              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELAS                         ACESSO        DCLGEN           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMAS                        INPUT         SISTEMAS         *      */
        /*"      * CALENDARIO                      INPUT         CALENDAR         *      */
        /*"      * APOLICES                        INPUT         APOLICES         *      */
        /*"      * ENDOSSOS                        INPUT         ENDOSSOS         *      */
        /*"      * PARCELAS                        INPUT         PARCELAS         *      */
        /*"      * PARCELA_HISTORICO               INPUT         PARCEHIS         *      */
        /*"      * MOVTO_DEBITOCC_CEF              INPUT         MOVDEBCE         *      */
        /*"      * FOLLOW_UP                       INPUT         FOLLOUP          *      */
        /*"      * SINISTRO_MESTRE                 INPUT         SINISMES         *      */
        /*"      * PRAZO_SEGURO                    INPUT         PRAZOSEG         *      */
        /*"      * CB_APOLICE_VIGPROP              I-O           CBAPOVIG         *      */
        /*"      * CB_MALA_PARCATRASO              OUTPUT        CBMALPAR         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  *   ALTERADO EM 16/05/2018 - LISIANE BRAGANCA SOARES             *      */
        /*"      *   CADMUS 163489-ABEND                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  *   ALTERADO EM 10/08/2017 - OLIVEIRA                            *      */
        /*"      *   CADMUS 153259 - SUSPENDER CANCELAMENTOS DO RAMO 31           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  *   ALTERADO EM 01/12/2015 - LISIANE BRAGANCA SOARES             *      */
        /*"      *   CADMUS 125788 - ALTERA��O DAS REGRAS DE ENVIO DAS CARTAS DE  *      */
        /*"      *                   COBRAN�A DOS PRODUTOS AUTO - RAMOS 31 E 53   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *   ALTERADO EM 19/04/2016 - LISIANE BRAGANCA SOARES             *      */
        /*"      *   CADMUS 135407 - INCLUIR A DATA DE VENCIMENTO DA PARCELA      *      */
        /*"      *                   NO ARQUIVO CB1260B1                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  *   ALTERADO EM 25/02/2016 - LISIANE BRAGANCA SOARES             *      */
        /*"      *   CADMUS 129125 - ATUALIZAR A DATA DE VENCIMENTO DA CARTA      *      */
        /*"      *                   REGISTRADA (AR) NA TABELA                    *      */
        /*"      *                   CB_MALA_PARCATRASO                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  *   ALTERADO EM 04/06/2014 - COREON                              *      */
        /*"      *   CADMUS 94790 - AJUSTE NA REGRA DE COBRANCA PARA PRODUTOS     *      */
        /*"      *                  AUTO FACIL, CUJA FORMA DE PAGTO � CART�O      *      */
        /*"      *                                                                *      */
        /*"      *                                                  PROCURE: V.07 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  *   ALTERADO EM 16/09/2013 - COREON                              *      */
        /*"      *   CADMUS 74582 - AJUSTE DA REGRA CRIADA NA V.05 P/ O AUTO,     *      */
        /*"      *                  DE MODO A TRATAR OS PRODUTOS DE AUTO FACIL    *      */
        /*"      *                                                PROCURE: V.06   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  *   ALTERADO EM 30/05/2013 - GUILHERME CORREIA                   *      */
        /*"      *   CADMUS 79945 - ALTERAR REGRAS DE INADIMPLENCIA PARA AUTO     *      */
        /*"      *                                                PROCURE: V.05   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  *   ALTERADO EM 30/04/2013 - COREON                              *      */
        /*"      *   CADMUS 74582 - AUTO FACIL                                    *      */
        /*"      *                                                PROCURE: V.04   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *   ALTERADO EM 17/09/2012                                       *      */
        /*"      *   CADMUS 73178 - COREON - SAC 1229                             *      */
        /*"      *   ALTERAR A REGRA PARA GERACAO DA DATA DE CANCELAMENTO NA      *      */
        /*"      *   TABELA CB_APOLICE_VIGPROP PARA AS APOLICES DO CONVENIO SAS   *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURAR POR: V.03   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *   ALTERADO EM 29/12/2011                                       *      */
        /*"      *   CADMUS 64811 - COREON - SAC 1097                             *      */
        /*"      *   ALTERAR A REGRA QUE DESCARTA DO PROCESSO DE INADIMPLENCIA /  *      */
        /*"      *   CANCELAMENTO APOLICES E ENDOSSOS COM PARCELA SUSPENSA PARA   *      */
        /*"      *   POSSIBILITAR A IMPRESSAO DE SEGUNDA VIA DO BOLETO NO PORTAL  *      */
        /*"      *   DE COBRANCA.                                                 *      */
        /*"      *                                           PROCURAR POR: V.02   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * ALTERADO EM 26/07/2011 - CLOVIS                 -  V.01        *      */
        /*"      * ATENDIMENTO DO PROJETO AUTO SAS                                *      */
        /*"      * PASSA A VERIFICAR O VENCIMENTO CADASTRADO NA TABELA            *      */
        /*"      * SEGUROS.PARCELA_AUTO_COMPL, PARA CALCULO DA VIGENCIA           *      */
        /*"      * PROPORCIONAL.                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 31/01/2008 - CLOVIS                 -  CL0801      *      */
        /*"      * ATENDIMENTO DA SSI 20318/2008                                  *      */
        /*"      * INCLUIR O PRODUTO 1804 NA ROTINA DE CANCELMTO, E MALA DIRETA   *      */
        /*"      * QUE ESTAVA INIBIDO A PARTIR DE 04/06/2007 SEM COMENTARIOS NO   *      */
        /*"      * PROGRAMA.   QUEM SOLICITOU E O MOTIVO DA INBICAO.              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 20/03/2007 - FAST COMPUTER          -  FC0703      *      */
        /*"      * INCLUIR O PRODUTO 1804 NA ROTINA DE CANCELMTO, E MALA DIRETA   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 05/08/2004 - GILSON PINTO DA SILVA  -  GP0805      *      */
        /*"      * INCLUIR O PRODUTO 1404 NA ROTINA DE CANCELMTO, E MALA DIRETA   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 06/07/2004 - CARLOS ALBERTO - PROCURAR CA0704      *      */
        /*"      * TRATAR O RAMO 67 E 40 PARA ACEITAR VIGENCIA DIFERENTE DE 12MESES      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 03/11/2003, INCLUIDO OS PRODUTOS 4005 E 6701       *      */
        /*"      * IDENTIFICADOR: CAAA2                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 07/02/2003, TRATA PRODUTOS QUE FORAM TRANSFERIDOS  *      */
        /*"      * IDENTIFICADOR: CL0203   DO RAMO 71 PARA (14,16,18)             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 17/07/2002, CONFORME SOLICITA DO SR.JACINTO (NOTES)*      */
        /*"      * IDENTIFICADOR: CAAA1    ALTERADA A QUANTIDADE DE DIAS UTEIS DE *      */
        /*"      *                         ESPERA PARA CHEGAR A INFORMACAO DO PAG.*      */
        /*"      *                         POR CARNE DE 5DIAS UTEIS P/ 3DIAS UTEIS*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _CB1260B1 { get; set; } = new FileBasis(new PIC("X", "91", "X(91)"));

        public FileBasis CB1260B1
        {
            get
            {
                _.Move(REG_CB1260B1, _CB1260B1); VarBasis.RedefinePassValue(REG_CB1260B1, _CB1260B1, REG_CB1260B1); return _CB1260B1;
            }
        }
        /*"01 REG-CB1260B1.*/
        public CB1260B_REG_CB1260B1 REG_CB1260B1 { get; set; } = new CB1260B_REG_CB1260B1();
        public class CB1260B_REG_CB1260B1 : VarBasis
        {
            /*"   05 CB1260B1-NUM-APOLICE        PIC 9(13).*/
            public IntBasis CB1260B1_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 CB1260B1-NUM-ENDOSSO        PIC 9(06).*/
            public IntBasis CB1260B1_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 CB1260B1-NUM-PARCELA        PIC 9(02).*/
            public IntBasis CB1260B1_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 CB1260B1-OBSERVACAO         PIC X(55).*/
            public StringBasis CB1260B1_OBSERVACAO { get; set; } = new StringBasis(new PIC("X", "55", "X(55)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 CB1260B1-DT-VENCIM          PIC X(10).*/
            public StringBasis CB1260B1_DT_VENCIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-OBSERVACAO                  PIC X(55) VALUE SPACES.*/
        public StringBasis WS_OBSERVACAO { get; set; } = new StringBasis(new PIC("X", "55", "X(55)"), @"");
        /*"77 WS-HOST-DATA-MOV-20D           PIC X(10) VALUE SPACES.*/
        public StringBasis WS_HOST_DATA_MOV_20D { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-QT-REGISTRO-LIDO            PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_REGISTRO_LIDO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-REGISTRO-ATU             PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_REGISTRO_ATU { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-REGISTRO-REJ-1           PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_REGISTRO_REJ_1 { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-REGISTRO-REJ-2           PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_REGISTRO_REJ_2 { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-REGISTRO-REJ-3           PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_REGISTRO_REJ_3 { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-DT-VENCIMENTO               PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-DT-VENCIMENTO-AUTO          PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_VENCIMENTO_AUTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-DATA-MOV-ABERTO-CO          PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DATA_MOV_ABERTO_CO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-HOST-DATA-NOVOCANCEL        PIC X(10) VALUE SPACES.*/
        public StringBasis WS_HOST_DATA_NOVOCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-HOST-DATA-CANCELAMENTO      PIC X(10) VALUE SPACES.*/
        public StringBasis WS_HOST_DATA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-HOST-DATA-FIM-VIG-PROP      PIC X(10) VALUE SPACES.*/
        public StringBasis WS_HOST_DATA_FIM_VIG_PROP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-DATA-CANCTO-FIMVIG          PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DATA_CANCTO_FIMVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-HOST-DTINIVIG-APOL          PIC X(10) VALUE SPACES.*/
        public StringBasis WS_HOST_DTINIVIG_APOL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-HOST-DTTERVIG-APOL          PIC X(10) VALUE SPACES.*/
        public StringBasis WS_HOST_DTTERVIG_APOL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-HOST-DATA-VENCIMENTO        PIC X(10) VALUE SPACES.*/
        public StringBasis WS_HOST_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-HOST-TIPO-ENDOSSO           PIC X(01) VALUE SPACES.*/
        public StringBasis WS_HOST_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77 WS-HOST-QTD-DOCUMENTOS         PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WS_HOST_QTD_DOCUMENTOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77 WS-HOST-QTD-MESES-VIG          PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WS_HOST_QTD_MESES_VIG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77 WS-HOST-QTD-SINISTROS          PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WS_HOST_QTD_SINISTROS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77 WS-HOST-QTD-PARCELAS           PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WS_HOST_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77 WS-HOST-PRM-DEVIDO             PIC S9(13)V99 VALUE +0 COMP-3.*/
        public DoubleBasis WS_HOST_PRM_DEVIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77 WS-HOST-PRM-PAGO               PIC S9(13)V99 VALUE +0 COMP-3.*/
        public DoubleBasis WS_HOST_PRM_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77 WS-PCT-PRM-RETIDO              PIC S9(03)V99 VALUE +0 COMP-3.*/
        public DoubleBasis WS_PCT_PRM_RETIDO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"77 VIND-DATA-MALA-VIG             PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_MALA_VIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-DATA-MALA-CANCEL          PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_MALA_CANCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-NUM-TITULO                PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-DATA-VENCIMENTO           PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_VENCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-DTA-VENCTO-AR             PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_DTA_VENCTO_AR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-PREMIO-TOTAL              PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_PREMIO_TOTAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-VALOR-ACRESCIMO           PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_VALOR_ACRESCIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-VALOR-TARIFA              PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_VALOR_TARIFA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-VALOR-VISTORIA            PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_VALOR_VISTORIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-DATA-ENVIO                PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_ENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01 TOTAIS-ROT.*/
        public CB1260B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new CB1260B_TOTAIS_ROT();
        public class CB1260B_TOTAIS_ROT : VarBasis
        {
            /*"   05 FILLER OCCURS 50 TIMES.*/
            public ListBasis<CB1260B_FILLER_5> FILLER_5 { get; set; } = new ListBasis<CB1260B_FILLER_5>(50);
            public class CB1260B_FILLER_5 : VarBasis
            {
                /*"      10 STT                      PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"      10 SQT                      PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01 AREA-DE-WORK.*/
            }
        }
        public CB1260B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB1260B_AREA_DE_WORK();
        public class CB1260B_AREA_DE_WORK : VarBasis
        {
            /*"   05 WS-DATA-1.*/
            public CB1260B_WS_DATA_1 WS_DATA_1 { get; set; } = new CB1260B_WS_DATA_1();
            public class CB1260B_WS_DATA_1 : VarBasis
            {
                /*"      07 WS-ANO-1                 PIC 9(04).*/
                public IntBasis WS_ANO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      07 FILLER                   PIC X(01).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      07 WS-MES-1                 PIC 9(02).*/
                public IntBasis WS_MES_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      07 FILLER                   PIC X(01).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      07 WS-DIA-1                 PIC 9(02).*/
                public IntBasis WS_DIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-DATA-2.*/
            }
            public CB1260B_WS_DATA_2 WS_DATA_2 { get; set; } = new CB1260B_WS_DATA_2();
            public class CB1260B_WS_DATA_2 : VarBasis
            {
                /*"      07 WS-DIA-2                 PIC 9(02).*/
                public IntBasis WS_DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      07 FILLER                   PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      07 WS-MES-2                 PIC 9(02).*/
                public IntBasis WS_MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      07 FILLER                   PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      07 WS-ANO-2                 PIC 9(04).*/
                public IntBasis WS_ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"   05 AC-COUNT                    PIC 9(04) VALUE ZEROS.*/
            }
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   05 AC-L-CALENDARIO             PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_CALENDARIO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-PARCELAS               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-S-PARCELAS               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_S_PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-MOVDEBCE               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-APOLICES               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_APOLICES { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-ENDOSSOS               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-PRAZOSEG               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_PRAZOSEG { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-FOLLOUP                PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_FOLLOUP { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-SINISMES               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_SINISMES { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-CBAPOVIG               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_CBAPOVIG { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-I-CBAPOVIG               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_I_CBAPOVIG { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-U-CBAPOVIG               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_U_CBAPOVIG { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-CBMALPAR               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_CBMALPAR { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-I-CBMALPAR               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_I_CBMALPAR { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 AC-L-PARCEDEV               PIC 9(07) VALUE ZEROS.*/
            public IntBasis AC_L_PARCEDEV { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"   05 WS-HORA-ACCEPT.*/
            public CB1260B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new CB1260B_WS_HORA_ACCEPT();
            public class CB1260B_WS_HORA_ACCEPT : VarBasis
            {
                /*"      10 WS-HORA-ACCEPT-HH        PIC 9(02) VALUE ZEROS.*/
                public IntBasis WS_HORA_ACCEPT_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      10 WS-HORA-ACCEPT-MM        PIC 9(02) VALUE ZEROS.*/
                public IntBasis WS_HORA_ACCEPT_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      10 WS-HORA-ACCEPT-SS        PIC 9(02) VALUE ZEROS.*/
                public IntBasis WS_HORA_ACCEPT_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      10 WS-HORA-ACCEPT-CC        PIC 9(02) VALUE ZEROS.*/
                public IntBasis WS_HORA_ACCEPT_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"   05 WS-FIM-PARCELAS             PIC X(01) VALUE SPACES.*/
            }
            public StringBasis WS_FIM_PARCELAS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05 WS-FIM-PARCEHIS             PIC X(01) VALUE SPACES.*/
            public StringBasis WS_FIM_PARCEHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05 WS-TEM-MOVDEBCE             PIC X(01) VALUE SPACES.*/
            public StringBasis WS_TEM_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05 WS-TEM-VIG-PROP             PIC X(01) VALUE SPACES.*/
            public StringBasis WS_TEM_VIG_PROP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05 WS-TEM-MALA-COBR            PIC X(01) VALUE SPACES.*/
            public StringBasis WS_TEM_MALA_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05 WS-APOLICE-DIFERENTE        PIC X(01) VALUE SPACES.*/
            public StringBasis WS_APOLICE_DIFERENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05 WS-DESPREZA-OUTRAS          PIC X(01) VALUE SPACES.*/
            public StringBasis WS_DESPREZA_OUTRAS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05 WS-DTVENCTO-SELEC           PIC X(10) VALUE SPACES.*/
            public StringBasis WS_DTVENCTO_SELEC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05 WS-DTVENCTO-02              PIC X(10) VALUE SPACES.*/
            public StringBasis WS_DTVENCTO_02 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05 WS-NUM-APOLICE-ANT          PIC S9(13) VALUE +0 COMP-3.*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"   05 WS-NUM-ENDOSSO-ANT          PIC S9(09) VALUE +0 COMP.*/
            public IntBasis WS_NUM_ENDOSSO_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"   05 WS-NUM-PARCELA-ANT          PIC S9(04) VALUE +0 COMP.*/
            public IntBasis WS_NUM_PARCELA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS-COD-OPERACAO             PIC 9(04) VALUE ZEROS.*/
            public IntBasis WS_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   05 WS-COD-OPERACAO-R REDEFINES WS-COD-OPERACAO.*/
            private _REDEF_CB1260B_WS_COD_OPERACAO_R _ws_cod_operacao_r { get; set; }
            public _REDEF_CB1260B_WS_COD_OPERACAO_R WS_COD_OPERACAO_R
            {
                get { _ws_cod_operacao_r = new _REDEF_CB1260B_WS_COD_OPERACAO_R(); _.Move(WS_COD_OPERACAO, _ws_cod_operacao_r); VarBasis.RedefinePassValue(WS_COD_OPERACAO, _ws_cod_operacao_r, WS_COD_OPERACAO); _ws_cod_operacao_r.ValueChanged += () => { _.Move(_ws_cod_operacao_r, WS_COD_OPERACAO); }; return _ws_cod_operacao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cod_operacao_r, WS_COD_OPERACAO); }
            }  //Redefines
            public class _REDEF_CB1260B_WS_COD_OPERACAO_R : VarBasis
            {
                /*"      10 WS-FAIXA-OPERACAO        PIC 9(02).*/
                public IntBasis WS_FAIXA_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                   PIC 9(02).*/
                public IntBasis FILLER_10 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-QTD-DIAS-UTEIS           PIC 9(04) VALUE ZEROS.*/

                public _REDEF_CB1260B_WS_COD_OPERACAO_R()
                {
                    WS_FAIXA_OPERACAO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_QTD_DIAS_UTEIS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   05 WS-QTD-DIAS                 PIC 9(04) VALUE ZEROS.*/
            public IntBasis WS_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   05 WS-HORAS.*/
            public CB1260B_WS_HORAS WS_HORAS { get; set; } = new CB1260B_WS_HORAS();
            public class CB1260B_WS_HORAS : VarBasis
            {
                /*"      10 WS-HORA-INI              PIC X(08).*/
                public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"      10 WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
                private _REDEF_CB1260B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
                public _REDEF_CB1260B_WS_HORA_INI_R WS_HORA_INI_R
                {
                    get { _ws_hora_ini_r = new _REDEF_CB1260B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
                }  //Redefines
                public class _REDEF_CB1260B_WS_HORA_INI_R : VarBasis
                {
                    /*"         15 HI                    PIC 9(02).*/
                    public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 MI                    PIC 9(02).*/
                    public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 SI                    PIC 9(02).*/
                    public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 DCI                   PIC 9(02).*/
                    public IntBasis DCI { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"      10 WS-HORA-FIM              PIC X(08).*/

                    public _REDEF_CB1260B_WS_HORA_INI_R()
                    {
                        HI.ValueChanged += OnValueChanged;
                        MI.ValueChanged += OnValueChanged;
                        SI.ValueChanged += OnValueChanged;
                        DCI.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"      10 WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
                private _REDEF_CB1260B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
                public _REDEF_CB1260B_WS_HORA_FIM_R WS_HORA_FIM_R
                {
                    get { _ws_hora_fim_r = new _REDEF_CB1260B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
                }  //Redefines
                public class _REDEF_CB1260B_WS_HORA_FIM_R : VarBasis
                {
                    /*"         15 HF                    PIC 9(02).*/
                    public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 MF                    PIC 9(02).*/
                    public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 SF                    PIC 9(02).*/
                    public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 DCF                   PIC 9(02).*/
                    public IntBasis DCF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"      10 SIT                      PIC S9(13)V99 COMP-3.*/

                    public _REDEF_CB1260B_WS_HORA_FIM_R()
                    {
                        HF.ValueChanged += OnValueChanged;
                        MF.ValueChanged += OnValueChanged;
                        SF.ValueChanged += OnValueChanged;
                        DCF.ValueChanged += OnValueChanged;
                    }

                }
                public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"      10 SFT                      PIC S9(13)V99 COMP-3.*/
                public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"      10 SII                      PIC S9(04)    COMP.*/
                public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"      10 STT-DISP                 PIC --.---.---.---.--9,99.*/
                public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
                /*"01 WS-VARIAVEIS-GLOBAIS.*/
            }
        }
        public CB1260B_WS_VARIAVEIS_GLOBAIS WS_VARIAVEIS_GLOBAIS { get; set; } = new CB1260B_WS_VARIAVEIS_GLOBAIS();
        public class CB1260B_WS_VARIAVEIS_GLOBAIS : VarBasis
        {
            /*"   03 WS-CURRENT-DATE.*/
            public CB1260B_WS_CURRENT_DATE WS_CURRENT_DATE { get; set; } = new CB1260B_WS_CURRENT_DATE();
            public class CB1260B_WS_CURRENT_DATE : VarBasis
            {
                /*"      05 WS-DATE                  PIC X(16) VALUE SPACES.*/
                public StringBasis WS_DATE { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"      05 FILLER REDEFINES WS-DATE.*/
                private _REDEF_CB1260B_FILLER_11 _filler_11 { get; set; }
                public _REDEF_CB1260B_FILLER_11 FILLER_11
                {
                    get { _filler_11 = new _REDEF_CB1260B_FILLER_11(); _.Move(WS_DATE, _filler_11); VarBasis.RedefinePassValue(WS_DATE, _filler_11, WS_DATE); _filler_11.ValueChanged += () => { _.Move(_filler_11, WS_DATE); }; return _filler_11; }
                    set { VarBasis.RedefinePassValue(value, _filler_11, WS_DATE); }
                }  //Redefines
                public class _REDEF_CB1260B_FILLER_11 : VarBasis
                {
                    /*"         07 WS-DT-TODAY           PIC 9(08).*/
                    public IntBasis WS_DT_TODAY { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"         07 WS-HR-TODAY           PIC 9(06).*/
                    public IntBasis WS_HR_TODAY { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                    /*"         07 WS-FILLER             PIC X(02).*/
                    public StringBasis WS_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"01 WABEND.*/

                    public _REDEF_CB1260B_FILLER_11()
                    {
                        WS_DT_TODAY.ValueChanged += OnValueChanged;
                        WS_HR_TODAY.ValueChanged += OnValueChanged;
                        WS_FILLER.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public CB1260B_WABEND WABEND { get; set; } = new CB1260B_WABEND();
        public class CB1260B_WABEND : VarBasis
        {
            /*"   05 FILLER                      PIC X(10) VALUE      ' CB1260B'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" CB1260B");
            /*"   05 FILLER                      PIC X(26) VALUE      ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"   05 WNR-EXEC-SQL                PIC X(03) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
            /*"   05 FILLER                      PIC X(13) VALUE      ' *** SQLCODE '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" *** SQLCODE ");
            /*"   05 WSQLCODE                    PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCEDEV PARCEDEV { get; set; } = new Dclgens.PARCEDEV();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.CBAPOVIG CBAPOVIG { get; set; } = new Dclgens.CBAPOVIG();
        public Dclgens.CBMALPAR CBMALPAR { get; set; } = new Dclgens.CBMALPAR();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.PRAZOSEG PRAZOSEG { get; set; } = new Dclgens.PRAZOSEG();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.APOLCOBR APOLCOBR { get; set; } = new Dclgens.APOLCOBR();
        public Dclgens.AU071 AU071 { get; set; } = new Dclgens.AU071();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.AU084 AU084 { get; set; } = new Dclgens.AU084();
        public CB1260B_C1CALENDARIO C1CALENDARIO { get; set; } = new CB1260B_C1CALENDARIO();
        public CB1260B_C0PARCELAS C0PARCELAS { get; set; } = new CB1260B_C0PARCELAS();
        public CB1260B_C1AU071 C1AU071 { get; set; } = new CB1260B_C1AU071();
        public CB1260B_C0MOVDEBCE C0MOVDEBCE { get; set; } = new CB1260B_C0MOVDEBCE();
        public CB1260B_C0PARCEHIS C0PARCEHIS { get; set; } = new CB1260B_C0PARCEHIS();
        public CB1260B_C2CALENDARIO C2CALENDARIO { get; set; } = new CB1260B_C2CALENDARIO();
        public CB1260B_C0CALENDARIO C0CALENDARIO { get; set; } = new CB1260B_C0CALENDARIO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CB1260B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CB1260B1.SetFile(CB1260B1_FILE_NAME_P);

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
            /*" -379- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WABEND.WNR_EXEC_SQL);

            /*" -379- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -381- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -383- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -387- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -390- DISPLAY 'DATA INICIO: ' WS-DT-TODAY ' - HORA INICIO: ' WS-HR-TODAY */

            $"DATA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.FILLER_11.WS_DT_TODAY} - HORA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.FILLER_11.WS_HR_TODAY}"
            .Display();

            /*" -392- OPEN OUTPUT CB1260B1. */
            CB1260B1.Open(REG_CB1260B1);

            /*" -395- INITIALIZE WS-HORAS TOTAIS-ROT. */
            _.Initialize(
                AREA_DE_WORK.WS_HORAS
                , TOTAIS_ROT
            );

            /*" -397- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -401- PERFORM R0150-00-SELECT-SISTEMAS-CO. */

            R0150_00_SELECT_SISTEMAS_CO_SECTION();

            /*" -402- MOVE 3 TO WS-QTD-DIAS-UTEIS */
            _.Move(3, AREA_DE_WORK.WS_QTD_DIAS_UTEIS);

            /*" -404- MOVE ZEROS TO WS-QTD-DIAS. */
            _.Move(0, AREA_DE_WORK.WS_QTD_DIAS);

            /*" -406- PERFORM R0200-00-DECLARE-CALENDARIO. */

            R0200_00_DECLARE_CALENDARIO_SECTION();

            /*" -408- PERFORM R0210-00-FETCH-CALENDARIO. */

            R0210_00_FETCH_CALENDARIO_SECTION();

            /*" -410- MOVE CALENDAR-DATA-CALENDARIO TO WS-DTVENCTO-SELEC. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.WS_DTVENCTO_SELEC);

            /*" -411- MOVE 2 TO WS-QTD-DIAS-UTEIS */
            _.Move(2, AREA_DE_WORK.WS_QTD_DIAS_UTEIS);

            /*" -413- MOVE ZEROS TO WS-QTD-DIAS. */
            _.Move(0, AREA_DE_WORK.WS_QTD_DIAS);

            /*" -415- PERFORM R0200-00-DECLARE-CALENDARIO. */

            R0200_00_DECLARE_CALENDARIO_SECTION();

            /*" -417- PERFORM R0210-00-FETCH-CALENDARIO. */

            R0210_00_FETCH_CALENDARIO_SECTION();

            /*" -424- MOVE CALENDAR-DATA-CALENDARIO TO WS-DTVENCTO-02. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.WS_DTVENCTO_02);

            /*" -431- PERFORM R3100-00-CALC-NOVO-VENCTO. */

            R3100_00_CALC_NOVO_VENCTO_SECTION();

            /*" -433- MOVE WS-DT-VENCIMENTO TO CALENDAR-DATA-CALENDARIO. */
            _.Move(WS_DT_VENCIMENTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -435- PERFORM R1830-00-CALC-DATA-NOVOCANCEL. */

            R1830_00_CALC_DATA_NOVOCANCEL_SECTION();

            /*" -437- DISPLAY 'DATA DO SISTEMA (CB)   - ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO SISTEMA (CB)   - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -439- DISPLAY 'DATA DO SISTEMA (CO)   - ' WS-DATA-MOV-ABERTO-CO */
            _.Display($"DATA DO SISTEMA (CO)   - {WS_DATA_MOV_ABERTO_CO}");

            /*" -441- DISPLAY 'DATA PARAM.P/SELECAO 1 - ' WS-DTVENCTO-SELEC */
            _.Display($"DATA PARAM.P/SELECAO 1 - {AREA_DE_WORK.WS_DTVENCTO_SELEC}");

            /*" -443- DISPLAY 'DATA PARAM.P/SELECAO 2 - ' WS-DTVENCTO-02 */
            _.Display($"DATA PARAM.P/SELECAO 2 - {AREA_DE_WORK.WS_DTVENCTO_02}");

            /*" -446- DISPLAY 'DATA NOVO VENCIMENTO   - ' WS-DT-VENCIMENTO */
            _.Display($"DATA NOVO VENCIMENTO   - {WS_DT_VENCIMENTO}");

            /*" -448- DISPLAY 'DATA NOVO CANCELAMENTO - ' WS-HOST-DATA-NOVOCANCEL */
            _.Display($"DATA NOVO CANCELAMENTO - {WS_HOST_DATA_NOVOCANCEL}");

            /*" -450- DISPLAY 'DATA NOVO VENCIMENTO AU- ' WS-DT-VENCIMENTO-AUTO */
            _.Display($"DATA NOVO VENCIMENTO AU- {WS_DT_VENCIMENTO_AUTO}");

            /*" -455- DISPLAY 'DATA MOV. 20 DIAS      - ' WS-HOST-DATA-MOV-20D */
            _.Display($"DATA MOV. 20 DIAS      - {WS_HOST_DATA_MOV_20D}");

            /*" -457- PERFORM R0300-00-PROCESSA-RAMO-EMISSOR. */

            R0300_00_PROCESSA_RAMO_EMISSOR_SECTION();

            /*" -458- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -459- DISPLAY '* CB1260B-CARREGAR A CB_APOLICE_VIGPROP *' . */
            _.Display($"* CB1260B-CARREGAR A CB_APOLICE_VIGPROP *");

            /*" -460- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -461- DISPLAY '* DOCUMENTOS LIDOS:          ' . */
            _.Display($"* DOCUMENTOS LIDOS:          ");

            /*" -462- DISPLAY '* - PARCELAS              = ' AC-L-PARCELAS. */
            _.Display($"* - PARCELAS              = {AREA_DE_WORK.AC_L_PARCELAS}");

            /*" -463- DISPLAY '* - PARCELAS SELECIONADAS = ' AC-S-PARCELAS. */
            _.Display($"* - PARCELAS SELECIONADAS = {AREA_DE_WORK.AC_S_PARCELAS}");

            /*" -464- DISPLAY '* - MOVTO_DEBITOCC_CEF    = ' AC-L-MOVDEBCE. */
            _.Display($"* - MOVTO_DEBITOCC_CEF    = {AREA_DE_WORK.AC_L_MOVDEBCE}");

            /*" -465- DISPLAY '* - APOLICES              = ' AC-L-APOLICES. */
            _.Display($"* - APOLICES              = {AREA_DE_WORK.AC_L_APOLICES}");

            /*" -466- DISPLAY '* - ENDOSSOS              = ' AC-L-ENDOSSOS. */
            _.Display($"* - ENDOSSOS              = {AREA_DE_WORK.AC_L_ENDOSSOS}");

            /*" -468- DISPLAY '* - FOLLOW_UP             = ' AC-L-FOLLOUP. */
            _.Display($"* - FOLLOW_UP             = {AREA_DE_WORK.AC_L_FOLLOUP}");

            /*" -469- DISPLAY '* - PRAZO_SEGURO          = ' AC-L-PRAZOSEG. */
            _.Display($"* - PRAZO_SEGURO          = {AREA_DE_WORK.AC_L_PRAZOSEG}");

            /*" -470- DISPLAY '* - CALENDARIO            = ' AC-L-CALENDARIO. */
            _.Display($"* - CALENDARIO            = {AREA_DE_WORK.AC_L_CALENDARIO}");

            /*" -471- DISPLAY '* - SINISTRO_MESTRE       = ' AC-L-SINISMES. */
            _.Display($"* - SINISTRO_MESTRE       = {AREA_DE_WORK.AC_L_SINISMES}");

            /*" -472- DISPLAY '* - CB_APOLICE_VIGPROP    = ' AC-L-CBAPOVIG. */
            _.Display($"* - CB_APOLICE_VIGPROP    = {AREA_DE_WORK.AC_L_CBAPOVIG}");

            /*" -473- DISPLAY '* - CB_MALA_PARCATRASO    = ' AC-L-CBMALPAR. */
            _.Display($"* - CB_MALA_PARCATRASO    = {AREA_DE_WORK.AC_L_CBMALPAR}");

            /*" -474- DISPLAY '*--*' . */
            _.Display($"*--*");

            /*" -475- DISPLAY '* DOCUMENTOS ATUALIZADOS:' . */
            _.Display($"* DOCUMENTOS ATUALIZADOS:");

            /*" -476- DISPLAY '* INSERT CB_APOLICE_VIGPROP = ' AC-I-CBAPOVIG. */
            _.Display($"* INSERT CB_APOLICE_VIGPROP = {AREA_DE_WORK.AC_I_CBAPOVIG}");

            /*" -477- DISPLAY '* UPDATE CB_APOLICE_VIGPROP = ' AC-U-CBAPOVIG. */
            _.Display($"* UPDATE CB_APOLICE_VIGPROP = {AREA_DE_WORK.AC_U_CBAPOVIG}");

            /*" -478- DISPLAY '* INSERT CB_MALA_PARCATRASO = ' AC-I-CBMALPAR. */
            _.Display($"* INSERT CB_MALA_PARCATRASO = {AREA_DE_WORK.AC_I_CBMALPAR}");

            /*" -479- DISPLAY '*------------------------------------*' . */
            _.Display($"*------------------------------------*");

            /*" -480- DISPLAY '              FIM NORMAL              ' . */
            _.Display($"              FIM NORMAL              ");

            /*" -482- DISPLAY '*------------------------------------*' . */
            _.Display($"*------------------------------------*");

            /*" -484- CLOSE CB1260B1. */
            CB1260B1.Close();

            /*" -486- PERFORM R0010-00-MOSTRA-TOTAIS. */

            R0010_00_MOSTRA_TOTAIS_SECTION();

            /*" -486- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -491- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -493- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -496- DISPLAY 'DATA TERMINO: ' WS-DT-TODAY ' - HORA TERMINO: ' WS-HR-TODAY */

            $"DATA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.FILLER_11.WS_DT_TODAY} - HORA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.FILLER_11.WS_HR_TODAY}"
            .Display();

            /*" -496- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-MOSTRA-TOTAIS-SECTION */
        private void R0010_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -507- MOVE 'R0010' TO WNR-EXEC-SQL. */
            _.Move("R0010", WABEND.WNR_EXEC_SQL);

            /*" -508- DISPLAY ' ' . */
            _.Display($" ");

            /*" -509- MOVE ZEROS TO SII. */
            _.Move(0, AREA_DE_WORK.WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R0010_10_MOSTRA_TOTAIS */

            R0010_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R0010-10-MOSTRA-TOTAIS */
        private void R0010_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -513- ADD 1 TO SII. */
            AREA_DE_WORK.WS_HORAS.SII.Value = AREA_DE_WORK.WS_HORAS.SII + 1;

            /*" -514- IF SII < 37 */

            if (AREA_DE_WORK.WS_HORAS.SII < 37)
            {

                /*" -515- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_5[AREA_DE_WORK.WS_HORAS.SII].STT, AREA_DE_WORK.WS_HORAS.STT_DISP);

                /*" -517- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{AREA_DE_WORK.WS_HORAS.SII} TOTAL= {AREA_DE_WORK.WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_5[AREA_DE_WORK.WS_HORAS.SII]}"
                .Display();

                /*" -518- GO TO R0010-10-MOSTRA-TOTAIS */
                new Task(() => R0010_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -520- END-IF */
            }


            /*" -520- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -531- MOVE 'R0100' TO WNR-EXEC-SQL */
            _.Move("R0100", WABEND.WNR_EXEC_SQL);

            /*" -537- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -540- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -541- DISPLAY 'R0100- ERRO SELECT SISTEMAS (CB)' */
                _.Display($"R0100- ERRO SELECT SISTEMAS (CB)");

                /*" -542- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -542- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -537- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECT-SISTEMAS-CO-SECTION */
        private void R0150_00_SELECT_SISTEMAS_CO_SECTION()
        {
            /*" -555- MOVE 'R0150' TO WNR-EXEC-SQL */
            _.Move("R0150", WABEND.WNR_EXEC_SQL);

            /*" -561- PERFORM R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1 */

            R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1();

            /*" -564- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -565- DISPLAY 'R0150- ERRO SELECT SISTEMAS (CO)' */
                _.Display($"R0150- ERRO SELECT SISTEMAS (CO)");

                /*" -566- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -566- END-IF. */
            }


        }

        [StopWatch]
        /*" R0150-00-SELECT-SISTEMAS-CO-DB-SELECT-1 */
        public void R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1()
        {
            /*" -561- EXEC SQL SELECT DATA_MOV_ABERTO INTO :WS-DATA-MOV-ABERTO-CO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CO' WITH UR END-EXEC */

            var r0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1 = new R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_MOV_ABERTO_CO, WS_DATA_MOV_ABERTO_CO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-CALENDARIO-SECTION */
        private void R0200_00_DECLARE_CALENDARIO_SECTION()
        {
            /*" -579- MOVE 'R0200' TO WNR-EXEC-SQL */
            _.Move("R0200", WABEND.WNR_EXEC_SQL);

            /*" -580- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -582- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -590- PERFORM R0200_00_DECLARE_CALENDARIO_DB_DECLARE_1 */

            R0200_00_DECLARE_CALENDARIO_DB_DECLARE_1();

            /*" -592- PERFORM R0200_00_DECLARE_CALENDARIO_DB_OPEN_1 */

            R0200_00_DECLARE_CALENDARIO_DB_OPEN_1();

            /*" -596- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -597- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -598- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -599- ADD SFT TO STT(01) */
            TOTAIS_ROT.FILLER_5[01].STT.Value = TOTAIS_ROT.FILLER_5[01].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -602- ADD 1 TO SQT(01) */
            TOTAIS_ROT.FILLER_5[01].SQT.Value = TOTAIS_ROT.FILLER_5[01].SQT + 1;

            /*" -603- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -604- DISPLAY 'R0200 - ERRO DECLARE CALENDARIO' */
                _.Display($"R0200 - ERRO DECLARE CALENDARIO");

                /*" -605- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -605- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-CALENDARIO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_CALENDARIO_DB_DECLARE_1()
        {
            /*" -590- EXEC SQL DECLARE C1CALENDARIO CURSOR FOR SELECT DATA_CALENDARIO ,DIA_SEMANA ,FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO < :WS-DATA-MOV-ABERTO-CO ORDER BY DATA_CALENDARIO DESC WITH UR END-EXEC */
            C1CALENDARIO = new CB1260B_C1CALENDARIO(true);
            string GetQuery_C1CALENDARIO()
            {
                var query = @$"SELECT DATA_CALENDARIO 
							,DIA_SEMANA 
							,FERIADO 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO < '{WS_DATA_MOV_ABERTO_CO}' 
							ORDER BY DATA_CALENDARIO DESC";

                return query;
            }
            C1CALENDARIO.GetQueryEvent += GetQuery_C1CALENDARIO;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-CALENDARIO-DB-OPEN-1 */
        public void R0200_00_DECLARE_CALENDARIO_DB_OPEN_1()
        {
            /*" -592- EXEC SQL OPEN C1CALENDARIO END-EXEC */

            C1CALENDARIO.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-PARCELAS-DB-DECLARE-1 */
        public void R0500_00_DECLARE_PARCELAS_DB_DECLARE_1()
        {
            /*" -774- EXEC SQL DECLARE C0PARCELAS CURSOR FOR SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_TITULO ,A.NUM_PARCELA ,B.DATA_VENCIMENTO ,B.PRM_TOTAL ,C.COD_PRODUTO ,C.DATA_INIVIGENCIA ,C.DATA_TERVIGENCIA ,C.QTD_PARCELAS ,C.TIPO_ENDOSSO FROM SEGUROS.ENDOSSOS C ,SEGUROS.PARCELAS A ,SEGUROS.PARCELA_HISTORICO B WHERE C.RAMO_EMISSOR = :ENDOSSOS-RAMO-EMISSOR AND C.SIT_REGISTRO = '0' AND C.TIPO_ENDOSSO IN ( '0' , '1' ) AND A.NUM_APOLICE = C.NUM_APOLICE AND A.NUM_ENDOSSO = C.NUM_ENDOSSO AND A.SIT_REGISTRO = '0' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA AND B.OCORR_HISTORICO = 1 AND B.DATA_VENCIMENTO < :SISTEMAS-DATA-MOV-ABERTO ORDER BY A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA WITH UR END-EXEC */
            C0PARCELAS = new CB1260B_C0PARCELAS(true);
            string GetQuery_C0PARCELAS()
            {
                var query = @$"SELECT A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_TITULO 
							,A.NUM_PARCELA 
							,B.DATA_VENCIMENTO 
							,B.PRM_TOTAL 
							,C.COD_PRODUTO 
							,C.DATA_INIVIGENCIA 
							,C.DATA_TERVIGENCIA 
							,C.QTD_PARCELAS 
							,C.TIPO_ENDOSSO 
							FROM SEGUROS.ENDOSSOS C 
							,SEGUROS.PARCELAS A 
							,SEGUROS.PARCELA_HISTORICO B 
							WHERE C.RAMO_EMISSOR = '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR}' 
							AND C.SIT_REGISTRO = '0' 
							AND C.TIPO_ENDOSSO IN ( '0'
							, '1' ) 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.NUM_ENDOSSO = C.NUM_ENDOSSO 
							AND A.SIT_REGISTRO = '0' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.NUM_PARCELA = A.NUM_PARCELA 
							AND B.OCORR_HISTORICO = 1 
							AND B.DATA_VENCIMENTO < '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA";

                return query;
            }
            C0PARCELAS.GetQueryEvent += GetQuery_C0PARCELAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-CALENDARIO-SECTION */
        private void R0210_00_FETCH_CALENDARIO_SECTION()
        {
            /*" -614- MOVE 'R0210' TO WNR-EXEC-SQL. */
            _.Move("R0210", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0210_10_FETCH_CALENDARIO */

            R0210_10_FETCH_CALENDARIO();

        }

        [StopWatch]
        /*" R0210-10-FETCH-CALENDARIO */
        private void R0210_10_FETCH_CALENDARIO(bool isPerform = false)
        {
            /*" -620- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -623- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -627- PERFORM R0210_10_FETCH_CALENDARIO_DB_FETCH_1 */

            R0210_10_FETCH_CALENDARIO_DB_FETCH_1();

            /*" -631- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -632- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -633- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -634- ADD SFT TO STT(02) */
            TOTAIS_ROT.FILLER_5[02].STT.Value = TOTAIS_ROT.FILLER_5[02].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -637- ADD 1 TO SQT(02) */
            TOTAIS_ROT.FILLER_5[02].SQT.Value = TOTAIS_ROT.FILLER_5[02].SQT + 1;

            /*" -638- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -639- DISPLAY 'R0210- ERRO FETCH CALENDARIO' */
                _.Display($"R0210- ERRO FETCH CALENDARIO");

                /*" -640- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -642- END-IF */
            }


            /*" -644- ADD 1 TO AC-L-CALENDARIO */
            AREA_DE_WORK.AC_L_CALENDARIO.Value = AREA_DE_WORK.AC_L_CALENDARIO + 1;

            /*" -645- IF CALENDAR-DIA-SEMANA = 'S' OR 'D' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA.In("S", "D"))
            {

                /*" -646- GO TO R0210-10-FETCH-CALENDARIO */
                new Task(() => R0210_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -648- END-IF */
            }


            /*" -649- IF CALENDAR-FERIADO = 'N' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
            {

                /*" -650- GO TO R0210-10-FETCH-CALENDARIO */
                new Task(() => R0210_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -652- END-IF */
            }


            /*" -654- ADD 1 TO WS-QTD-DIAS */
            AREA_DE_WORK.WS_QTD_DIAS.Value = AREA_DE_WORK.WS_QTD_DIAS + 1;

            /*" -655- IF WS-QTD-DIAS = WS-QTD-DIAS-UTEIS */

            if (AREA_DE_WORK.WS_QTD_DIAS == AREA_DE_WORK.WS_QTD_DIAS_UTEIS)
            {

                /*" -655- PERFORM R0210_10_FETCH_CALENDARIO_DB_CLOSE_1 */

                R0210_10_FETCH_CALENDARIO_DB_CLOSE_1();

                /*" -657- ELSE */
            }
            else
            {


                /*" -658- GO TO R0210-10-FETCH-CALENDARIO */
                new Task(() => R0210_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -658- END-IF. */
            }


        }

        [StopWatch]
        /*" R0210-10-FETCH-CALENDARIO-DB-FETCH-1 */
        public void R0210_10_FETCH_CALENDARIO_DB_FETCH_1()
        {
            /*" -627- EXEC SQL FETCH C1CALENDARIO INTO :CALENDAR-DATA-CALENDARIO ,:CALENDAR-DIA-SEMANA ,:CALENDAR-FERIADO END-EXEC */

            if (C1CALENDARIO.Fetch())
            {
                _.Move(C1CALENDARIO.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(C1CALENDARIO.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(C1CALENDARIO.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }

        }

        [StopWatch]
        /*" R0210-10-FETCH-CALENDARIO-DB-CLOSE-1 */
        public void R0210_10_FETCH_CALENDARIO_DB_CLOSE_1()
        {
            /*" -655- EXEC SQL CLOSE C1CALENDARIO END-EXEC */

            C1CALENDARIO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-RAMO-EMISSOR-SECTION */
        private void R0300_00_PROCESSA_RAMO_EMISSOR_SECTION()
        {
            /*" -668- MOVE 'R0300' TO WNR-EXEC-SQL */
            _.Move("R0300", WABEND.WNR_EXEC_SQL);

            /*" -668- MOVE ZEROS TO ENDOSSOS-RAMO-EMISSOR. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

            /*" -0- FLUXCONTROL_PERFORM R0300_10_PROCESSA_RAMO_EMISSOR */

            R0300_10_PROCESSA_RAMO_EMISSOR();

        }

        [StopWatch]
        /*" R0300-10-PROCESSA-RAMO-EMISSOR */
        private void R0300_10_PROCESSA_RAMO_EMISSOR(bool isPerform = false)
        {
            /*" -673- MOVE SPACES TO WS-FIM-PARCELAS */
            _.Move("", AREA_DE_WORK.WS_FIM_PARCELAS);

            /*" -679- MOVE 0 TO WS-QT-REGISTRO-LIDO WS-QT-REGISTRO-ATU WS-QT-REGISTRO-REJ-1 WS-QT-REGISTRO-REJ-2 WS-QT-REGISTRO-REJ-3 */
            _.Move(0, WS_QT_REGISTRO_LIDO, WS_QT_REGISTRO_ATU, WS_QT_REGISTRO_REJ_1, WS_QT_REGISTRO_REJ_2, WS_QT_REGISTRO_REJ_3);

            /*" -680-  EVALUATE ENDOSSOS-RAMO-EMISSOR  */

            /*" -681-  WHEN ZEROS  */

            /*" -681- IF   ENDOSSOS-RAMO-EMISSOR EQUALS  ZEROS */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 00)
            {

                /*" -682- MOVE 11 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(11, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -683-  WHEN 11  */

                /*" -683- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  11 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 11)
            {

                /*" -684- MOVE 31 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(31, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -685-  WHEN 31  */

                /*" -685- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  31 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 31)
            {

                /*" -686- MOVE 53 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(53, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -687-  WHEN 53  */

                /*" -687- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  53 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53)
            {

                /*" -688- MOVE 71 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(71, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -689-  WHEN 71  */

                /*" -689- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  71 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 71)
            {

                /*" -690- MOVE 14 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(14, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -691-  WHEN 14  */

                /*" -691- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  14 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 14)
            {

                /*" -692- MOVE 16 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(16, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -693-  WHEN 16  */

                /*" -693- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  16 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 16)
            {

                /*" -694- MOVE 18 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(18, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -695-  WHEN 18  */

                /*" -695- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  18 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 18)
            {

                /*" -696- MOVE 40 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(40, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -697-  WHEN 40  */

                /*" -697- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  40 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 40)
            {

                /*" -698- MOVE 45 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(45, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -699-  WHEN 45  */

                /*" -699- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  45 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 45)
            {

                /*" -700- MOVE 67 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(67, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -701-  WHEN 67  */

                /*" -701- ELSE IF   ENDOSSOS-RAMO-EMISSOR EQUALS  67 */
            }
            else

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 67)
            {

                /*" -702- MOVE 75 TO ENDOSSOS-RAMO-EMISSOR */
                _.Move(75, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

                /*" -703-  WHEN OTHER  */

                /*" -703- ELSE */
            }
            else
            {


                /*" -704- GO TO R0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;

                /*" -706-  END-EVALUATE  */

                /*" -706- END-IF */
            }


            /*" -708- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -709- DISPLAY 'RAMO - ' ENDOSSOS-RAMO-EMISSOR */
            _.Display($"RAMO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR}");

            /*" -711- DISPLAY '  INICIO DO DECLARE - ' WS-HORA-ACCEPT */
            _.Display($"  INICIO DO DECLARE - {AREA_DE_WORK.WS_HORA_ACCEPT}");

            /*" -713- PERFORM R0500-00-DECLARE-PARCELAS */

            R0500_00_DECLARE_PARCELAS_SECTION();

            /*" -715- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -717- DISPLAY '  FIM DO DECLARE    - ' WS-HORA-ACCEPT */
            _.Display($"  FIM DO DECLARE    - {AREA_DE_WORK.WS_HORA_ACCEPT}");

            /*" -719- PERFORM R0510-00-FETCH-PARCELAS */

            R0510_00_FETCH_PARCELAS_SECTION();

            /*" -722- PERFORM R0800-00-PROCESSA-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' */

            while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S"))
            {

                R0800_00_PROCESSA_PARCELAS_SECTION();
            }

            /*" -723- DISPLAY '  QTDE REG LIDO......: ' WS-QT-REGISTRO-LIDO */
            _.Display($"  QTDE REG LIDO......: {WS_QT_REGISTRO_LIDO}");

            /*" -724- DISPLAY '  QTDE REG ATUALIZADO: ' WS-QT-REGISTRO-ATU */
            _.Display($"  QTDE REG ATUALIZADO: {WS_QT_REGISTRO_ATU}");

            /*" -725- DISPLAY '  QTDE REG REJEITADO : ' WS-QT-REGISTRO-REJ-1 */
            _.Display($"  QTDE REG REJEITADO : {WS_QT_REGISTRO_REJ_1}");

            /*" -726- DISPLAY '  QTDE REG REJ JA CAD: ' WS-QT-REGISTRO-REJ-2 */
            _.Display($"  QTDE REG REJ JA CAD: {WS_QT_REGISTRO_REJ_2}");

            /*" -728- DISPLAY '  QTDE REG REJ ORGAO : ' WS-QT-REGISTRO-REJ-3 */
            _.Display($"  QTDE REG REJ ORGAO : {WS_QT_REGISTRO_REJ_3}");

            /*" -728- GO TO R0300-10-PROCESSA-RAMO-EMISSOR. */
            new Task(() => R0300_10_PROCESSA_RAMO_EMISSOR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-PARCELAS-SECTION */
        private void R0500_00_DECLARE_PARCELAS_SECTION()
        {
            /*" -740- MOVE 'R0500' TO WNR-EXEC-SQL */
            _.Move("R0500", WABEND.WNR_EXEC_SQL);

            /*" -741- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -744- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -774- PERFORM R0500_00_DECLARE_PARCELAS_DB_DECLARE_1 */

            R0500_00_DECLARE_PARCELAS_DB_DECLARE_1();

            /*" -776- PERFORM R0500_00_DECLARE_PARCELAS_DB_OPEN_1 */

            R0500_00_DECLARE_PARCELAS_DB_OPEN_1();

            /*" -780- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -781- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -782- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -783- ADD SFT TO STT(03) */
            TOTAIS_ROT.FILLER_5[03].STT.Value = TOTAIS_ROT.FILLER_5[03].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -786- ADD 1 TO SQT(03) */
            TOTAIS_ROT.FILLER_5[03].SQT.Value = TOTAIS_ROT.FILLER_5[03].SQT + 1;

            /*" -787- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -788- DISPLAY 'R0500 - ERRO DECLARE PARCELAS/PARCELA_HISTORICO' */
                _.Display($"R0500 - ERRO DECLARE PARCELAS/PARCELA_HISTORICO");

                /*" -789- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -789- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-PARCELAS-DB-OPEN-1 */
        public void R0500_00_DECLARE_PARCELAS_DB_OPEN_1()
        {
            /*" -776- EXEC SQL OPEN C0PARCELAS END-EXEC */

            C0PARCELAS.Open();

        }

        [StopWatch]
        /*" R0820-00-DECLARE-AU071-DB-DECLARE-1 */
        public void R0820_00_DECLARE_AU071_DB_DECLARE_1()
        {
            /*" -1557- EXEC SQL DECLARE C1AU071 CURSOR FOR SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DTA_VENCTO ,NUM_VENCTO FROM SEGUROS.PARCELA_AUTO_COMPL WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA = :PARCELAS-NUM-PARCELA ORDER BY NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_VENCTO DESC WITH UR END-EXEC. */
            C1AU071 = new CB1260B_C1AU071(true);
            string GetQuery_C1AU071()
            {
                var query = @$"SELECT NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,DTA_VENCTO 
							,NUM_VENCTO 
							FROM SEGUROS.PARCELA_AUTO_COMPL 
							WHERE NUM_APOLICE = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}' 
							AND NUM_ENDOSSO = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}' 
							AND NUM_PARCELA = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}' 
							ORDER BY NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,NUM_VENCTO DESC";

                return query;
            }
            C1AU071.GetQueryEvent += GetQuery_C1AU071;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-PARCELAS-SECTION */
        private void R0510_00_FETCH_PARCELAS_SECTION()
        {
            /*" -798- MOVE 'R0510' TO WNR-EXEC-SQL. */
            _.Move("R0510", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0510_10_FETCH_PARCELAS */

            R0510_10_FETCH_PARCELAS();

        }

        [StopWatch]
        /*" R0510-10-FETCH-PARCELAS */
        private void R0510_10_FETCH_PARCELAS(bool isPerform = false)
        {
            /*" -804- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -807- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -819- PERFORM R0510_10_FETCH_PARCELAS_DB_FETCH_1 */

            R0510_10_FETCH_PARCELAS_DB_FETCH_1();

            /*" -823- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -824- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -825- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -826- ADD SFT TO STT(04) */
            TOTAIS_ROT.FILLER_5[04].STT.Value = TOTAIS_ROT.FILLER_5[04].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -829- ADD 1 TO SQT(04) */
            TOTAIS_ROT.FILLER_5[04].SQT.Value = TOTAIS_ROT.FILLER_5[04].SQT + 1;

            /*" -830- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -831- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -832- MOVE 'S' TO WS-FIM-PARCELAS */
                    _.Move("S", AREA_DE_WORK.WS_FIM_PARCELAS);

                    /*" -832- PERFORM R0510_10_FETCH_PARCELAS_DB_CLOSE_1 */

                    R0510_10_FETCH_PARCELAS_DB_CLOSE_1();

                    /*" -834- GO TO R0510-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                    /*" -835- ELSE */
                }
                else
                {


                    /*" -836- DISPLAY 'R0510- ERRO FETCH PARCELAS/HISTORICO_PARCELAS' */
                    _.Display($"R0510- ERRO FETCH PARCELAS/HISTORICO_PARCELAS");

                    /*" -837- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -838- END-IF */
                }


                /*" -840- END-IF */
            }


            /*" -843- ADD 1 TO AC-L-PARCELAS AC-COUNT */
            AREA_DE_WORK.AC_L_PARCELAS.Value = AREA_DE_WORK.AC_L_PARCELAS + 1;
            AREA_DE_WORK.AC_COUNT.Value = AREA_DE_WORK.AC_COUNT + 1;

            /*" -846- IF AC-COUNT = 5000 */

            if (AREA_DE_WORK.AC_COUNT == 5000)
            {

                /*" -848- MOVE ZEROS TO AC-COUNT */
                _.Move(0, AREA_DE_WORK.AC_COUNT);

                /*" -859- ACCEPT WS-HORA-ACCEPT FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

                /*" -859- END-IF. */
            }


        }

        [StopWatch]
        /*" R0510-10-FETCH-PARCELAS-DB-FETCH-1 */
        public void R0510_10_FETCH_PARCELAS_DB_FETCH_1()
        {
            /*" -819- EXEC SQL FETCH C0PARCELAS INTO :PARCELAS-NUM-APOLICE ,:PARCELAS-NUM-ENDOSSO ,:PARCELAS-NUM-TITULO ,:PARCELAS-NUM-PARCELA ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-PRM-TOTAL ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:ENDOSSOS-QTD-PARCELAS ,:ENDOSSOS-TIPO-ENDOSSO END-EXEC */

            if (C0PARCELAS.Fetch())
            {
                _.Move(C0PARCELAS.PARCELAS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);
                _.Move(C0PARCELAS.PARCELAS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);
                _.Move(C0PARCELAS.PARCELAS_NUM_TITULO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);
                _.Move(C0PARCELAS.PARCELAS_NUM_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);
                _.Move(C0PARCELAS.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
                _.Move(C0PARCELAS.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(C0PARCELAS.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(C0PARCELAS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(C0PARCELAS.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(C0PARCELAS.ENDOSSOS_QTD_PARCELAS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);
                _.Move(C0PARCELAS.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
            }

        }

        [StopWatch]
        /*" R0510-10-FETCH-PARCELAS-DB-CLOSE-1 */
        public void R0510_10_FETCH_PARCELAS_DB_CLOSE_1()
        {
            /*" -832- EXEC SQL CLOSE C0PARCELAS END-EXEC */

            C0PARCELAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-PROCESSA-PARCELAS-SECTION */
        private void R0800_00_PROCESSA_PARCELAS_SECTION()
        {
            /*" -870- MOVE 'R0800' TO WNR-EXEC-SQL */
            _.Move("R0800", WABEND.WNR_EXEC_SQL);

            /*" -878- ADD 1 TO WS-QT-REGISTRO-LIDO */
            WS_QT_REGISTRO_LIDO.Value = WS_QT_REGISTRO_LIDO + 1;

            /*" -879- MOVE PARCEHIS-DATA-VENCIMENTO TO WS-DATA-1 */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, AREA_DE_WORK.WS_DATA_1);

            /*" -880- MOVE WS-DIA-1 TO WS-DIA-2 */
            _.Move(AREA_DE_WORK.WS_DATA_1.WS_DIA_1, AREA_DE_WORK.WS_DATA_2.WS_DIA_2);

            /*" -881- MOVE WS-MES-1 TO WS-MES-2 */
            _.Move(AREA_DE_WORK.WS_DATA_1.WS_MES_1, AREA_DE_WORK.WS_DATA_2.WS_MES_2);

            /*" -883- MOVE WS-ANO-1 TO WS-ANO-2 */
            _.Move(AREA_DE_WORK.WS_DATA_1.WS_ANO_1, AREA_DE_WORK.WS_DATA_2.WS_ANO_2);

            /*" -886- IF ( (ENDOSSOS-RAMO-EMISSOR = 31) OR (ENDOSSOS-RAMO-EMISSOR = 53 AND ENDOSSOS-COD-PRODUTO = 5302 OR 5303 OR 5304) ) */

            if (((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 31) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
            {

                /*" -887- MOVE WS-DT-VENCIMENTO-AUTO TO WS-HOST-DATA-VENCIMENTO */
                _.Move(WS_DT_VENCIMENTO_AUTO, WS_HOST_DATA_VENCIMENTO);

                /*" -888- ELSE */
            }
            else
            {


                /*" -889- MOVE WS-DT-VENCIMENTO TO WS-HOST-DATA-VENCIMENTO */
                _.Move(WS_DT_VENCIMENTO, WS_HOST_DATA_VENCIMENTO);

                /*" -891- END-IF */
            }


            /*" -893- IF (ENDOSSOS-RAMO-EMISSOR = 14) AND (ENDOSSOS-COD-PRODUTO NOT = 1401 AND 1403 AND 1404) */

            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 14) && (!ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("1401", "1403", "1404")))
            {

                /*" -894- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -895- GO TO R0800-90-FETCH-PARCELAS */

                R0800_90_FETCH_PARCELAS(); //GOTO
                return;

                /*" -897- END-IF */
            }


            /*" -899- IF (ENDOSSOS-RAMO-EMISSOR = 16) AND (ENDOSSOS-COD-PRODUTO NOT = 1601 AND 1602) */

            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 16) && (!ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("1601", "1602")))
            {

                /*" -900- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -901- GO TO R0800-90-FETCH-PARCELAS */

                R0800_90_FETCH_PARCELAS(); //GOTO
                return;

                /*" -903- END-IF */
            }


            /*" -905- IF (ENDOSSOS-RAMO-EMISSOR = 18) AND (ENDOSSOS-COD-PRODUTO NOT = 1801 AND 1802 AND 1804) */

            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 18) && (!ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("1801", "1802", "1804")))
            {

                /*" -906- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -907- GO TO R0800-90-FETCH-PARCELAS */

                R0800_90_FETCH_PARCELAS(); //GOTO
                return;

                /*" -917- END-IF */
            }


            /*" -919- PERFORM R1150-00-SELECT-APOLCOBR */

            R1150_00_SELECT_APOLCOBR_SECTION();

            /*" -922- IF ( (ENDOSSOS-RAMO-EMISSOR = 53) AND (ENDOSSOS-COD-PRODUTO = 5302 OR 5303 OR 5304) ) */

            if (((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
            {

                /*" -924- IF APOLCOBR-TIPO-COBRANCA = '2' */

                if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA == "2")
                {

                    /*" -926- PERFORM R0860-00-LE-TIPO-ADESAO */

                    R0860_00_LE_TIPO_ADESAO_SECTION();

                    /*" -928- IF AU084-IND-FORMA-PAGTO-AD = 4 */

                    if (AU084.DCLAU_APOLICE_COMPL.AU084_IND_FORMA_PAGTO_AD == 4)
                    {

                        /*" -930- PERFORM R0870-00-LE-SIT-COBR-CARTAO */

                        R0870_00_LE_SIT_COBR_CARTAO_SECTION();

                        /*" -942- IF MOVIMCOB-SIT-REGISTRO = ' ' */

                        if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO == " ")
                        {

                            /*" -944- MOVE 'PARCELA C/ PAGTO EM CARTAO NAO LOCALIZADA MOVIMCOB' TO WS-OBSERVACAO */
                            _.Move("PARCELA C/ PAGTO EM CARTAO NAO LOCALIZADA MOVIMCOB", WS_OBSERVACAO);

                            /*" -946- PERFORM R0801-GRAVA-CB1260B1 */

                            R0801_GRAVA_CB1260B1_SECTION();

                            /*" -947- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                            WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                            /*" -948- GO TO R0800-90-FETCH-PARCELAS */

                            R0800_90_FETCH_PARCELAS(); //GOTO
                            return;

                            /*" -949- ELSE */
                        }
                        else
                        {


                            /*" -964- IF MOVIMCOB-SIT-REGISTRO NOT = '*' */

                            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO != "*")
                            {

                                /*" -966- MOVE 'PARCELA PENDENTE DE RETORNO DA OPERADORA DE CREDITO' TO WS-OBSERVACAO */
                                _.Move("PARCELA PENDENTE DE RETORNO DA OPERADORA DE CREDITO", WS_OBSERVACAO);

                                /*" -968- PERFORM R0801-GRAVA-CB1260B1 */

                                R0801_GRAVA_CB1260B1_SECTION();

                                /*" -969- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                                /*" -970- GO TO R0800-90-FETCH-PARCELAS */

                                R0800_90_FETCH_PARCELAS(); //GOTO
                                return;

                                /*" -972- ELSE */
                            }
                            else
                            {


                                /*" -973- GO TO R0800-01 */

                                R0800_01(); //GOTO
                                return;

                                /*" -974- END-IF */
                            }


                            /*" -975- END-IF */
                        }


                        /*" -976- END-IF */
                    }


                    /*" -977- END-IF */
                }


                /*" -977- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0800_01 */

            R0800_01();

        }

        [StopWatch]
        /*" R0800-01 */
        private void R0800_01(bool isPerform = false)
        {
            /*" -987- IF ( (ENDOSSOS-RAMO-EMISSOR = 31) OR (ENDOSSOS-RAMO-EMISSOR = 53 AND ENDOSSOS-COD-PRODUTO = 5302 OR 5303 OR 5304) ) */

            if (((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 31) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
            {

                /*" -988- PERFORM R0820-00-DECLARE-AU071 */

                R0820_00_DECLARE_AU071_SECTION();

                /*" -990- PERFORM R0830-00-FETCH-AU071 */

                R0830_00_FETCH_AU071_SECTION();

                /*" -991- IF AU071-DTA-VENCTO NOT = SPACES */

                if (!AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO.IsEmpty())
                {

                    /*" -992- MOVE AU071-DTA-VENCTO TO PARCEHIS-DATA-VENCIMENTO */
                    _.Move(AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                    /*" -993- END-IF */
                }


                /*" -1001- END-IF */
            }


            /*" -1002- IF PARCEHIS-DATA-VENCIMENTO >= SISTEMAS-DATA-MOV-ABERTO */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO >= SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -1003- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -1004- GO TO R0800-90-FETCH-PARCELAS */

                R0800_90_FETCH_PARCELAS(); //GOTO
                return;

                /*" -1006- END-IF */
            }


            /*" -1008- PERFORM R0850-00-SELECT-APOL-VIG-PROP */

            R0850_00_SELECT_APOL_VIG_PROP_SECTION();

            /*" -1011- IF (WS-TEM-VIG-PROP = 'S' ) AND (WS-TEM-MALA-COBR = 'S' ) AND (CBAPOVIG-SITUACAO = '0' OR 'V' ) */

            if ((AREA_DE_WORK.WS_TEM_VIG_PROP == "S") && (AREA_DE_WORK.WS_TEM_MALA_COBR == "S") && (CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO.In("0", "V")))
            {

                /*" -1012- ADD 1 TO WS-QT-REGISTRO-REJ-2 */
                WS_QT_REGISTRO_REJ_2.Value = WS_QT_REGISTRO_REJ_2 + 1;

                /*" -1013- GO TO R0800-90-FETCH-PARCELAS */

                R0800_90_FETCH_PARCELAS(); //GOTO
                return;

                /*" -1015- END-IF */
            }


            /*" -1017- MOVE SPACES TO WS-APOLICE-DIFERENTE */
            _.Move("", AREA_DE_WORK.WS_APOLICE_DIFERENTE);

            /*" -1018- IF PARCELAS-NUM-APOLICE NOT = WS-NUM-APOLICE-ANT */

            if (PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT)
            {

                /*" -1019- MOVE 'S' TO WS-APOLICE-DIFERENTE */
                _.Move("S", AREA_DE_WORK.WS_APOLICE_DIFERENTE);

                /*" -1021- END-IF */
            }


            /*" -1022- MOVE PARCELAS-NUM-APOLICE TO WS-NUM-APOLICE-ANT */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT);

            /*" -1023- MOVE PARCELAS-NUM-ENDOSSO TO WS-NUM-ENDOSSO-ANT */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, AREA_DE_WORK.WS_NUM_ENDOSSO_ANT);

            /*" -1030- MOVE PARCELAS-NUM-PARCELA TO WS-NUM-PARCELA-ANT */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, AREA_DE_WORK.WS_NUM_PARCELA_ANT);

            /*" -1032- PERFORM R0900-00-SELECT-APOLICES */

            R0900_00_SELECT_APOLICES_SECTION();

            /*" -1036- IF (APOLICES-TIPO-SEGURO NOT = '1' ) OR (APOLICES-TIPO-APOLICE = '4' OR '6' ) OR (APOLICES-ORGAO-EMISSOR NOT = 10 AND 100 AND 110) */

            if ((APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO != "1") || (APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE.In("4", "6")) || (!APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.In("10", "100", "110")))
            {

                /*" -1038- ADD 1 TO WS-QT-REGISTRO-REJ-3 */
                WS_QT_REGISTRO_REJ_3.Value = WS_QT_REGISTRO_REJ_3 + 1;

                /*" -1041- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                {

                    R0510_00_FETCH_PARCELAS_SECTION();
                }

                /*" -1042- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -1050- END-IF */
            }


            /*" -1051- IF ENDOSSOS-RAMO-EMISSOR = 71 OR 14 OR 16 OR 18 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.In("71", "14", "16", "18"))
            {

                /*" -1063- IF PARCEHIS-PRM-TOTAL < 10 */

                if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL < 10)
                {

                    /*" -1065- MOVE 'APOLICE COM PRM-TOTAL DA PARC.MENOR QUE R$10,00' TO WS-OBSERVACAO */
                    _.Move("APOLICE COM PRM-TOTAL DA PARC.MENOR QUE R$10,00", WS_OBSERVACAO);

                    /*" -1067- PERFORM R0801-GRAVA-CB1260B1 */

                    R0801_GRAVA_CB1260B1_SECTION();

                    /*" -1069- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                    WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                    /*" -1073- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                    while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                    {

                        R0510_00_FETCH_PARCELAS_SECTION();
                    }

                    /*" -1074- GO TO R0800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                    return;

                    /*" -1075- END-IF */
                }


                /*" -1076- ELSE */
            }
            else
            {


                /*" -1080- IF ( (ENDOSSOS-RAMO-EMISSOR = 31) OR (ENDOSSOS-RAMO-EMISSOR = 53 AND ENDOSSOS-COD-PRODUTO = 5302 OR 5303 OR 5304) ) */

                if (((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 31) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
                {

                    /*" -1081- GO TO R0800-02 */

                    R0800_02(); //GOTO
                    return;

                    /*" -1082- ELSE */
                }
                else
                {


                    /*" -1095- IF PARCEHIS-PRM-TOTAL < 30 */

                    if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL < 30)
                    {

                        /*" -1098- MOVE 'APOLICE COM PRM-TOTAL DA PARC.MENOR QUE R$30,00' TO WS-OBSERVACAO */
                        _.Move("APOLICE COM PRM-TOTAL DA PARC.MENOR QUE R$30,00", WS_OBSERVACAO);

                        /*" -1100- PERFORM R0801-GRAVA-CB1260B1 */

                        R0801_GRAVA_CB1260B1_SECTION();

                        /*" -1101- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                        WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                        /*" -1104- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                        while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                        {

                            R0510_00_FETCH_PARCELAS_SECTION();
                        }

                        /*" -1105- GO TO R0800-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                        return;

                        /*" -1106- END-IF */
                    }


                    /*" -1107- END-IF */
                }


                /*" -1108- END-IF. */
            }


            /*" -1108- PERFORM R0800-02 */

            R0800_02(true);

        }

        [StopWatch]
        /*" R0800-02 */
        private void R0800_02(bool isPerform = false)
        {
            /*" -1115- PERFORM R1300-00-SELECT-PARCELAS */

            R1300_00_SELECT_PARCELAS_SECTION();

            /*" -1127- IF WS-HOST-QTD-PARCELAS > 0 */

            if (WS_HOST_QTD_PARCELAS > 0)
            {

                /*" -1129- MOVE 'APOLICE COM PARCELA PENDENTE ENTRE PAGAS' TO WS-OBSERVACAO */
                _.Move("APOLICE COM PARCELA PENDENTE ENTRE PAGAS", WS_OBSERVACAO);

                /*" -1131- PERFORM R0801-GRAVA-CB1260B1 */

                R0801_GRAVA_CB1260B1_SECTION();

                /*" -1132- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -1135- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                {

                    R0510_00_FETCH_PARCELAS_SECTION();
                }

                /*" -1136- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -1143- END-IF */
            }


            /*" -1145- PERFORM R1000-00-SELECT-FOLLOW-UP */

            R1000_00_SELECT_FOLLOW_UP_SECTION();

            /*" -1159- IF (WS-HOST-QTD-DOCUMENTOS > 0 ) AND (ENDOSSOS-RAMO-EMISSOR NOT = 31) */

            if ((WS_HOST_QTD_DOCUMENTOS > 0) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR != 31))
            {

                /*" -1161- MOVE 'APOLICE COM DOCUMENTO(S) EM FOLLOW-UP' TO WS-OBSERVACAO */
                _.Move("APOLICE COM DOCUMENTO(S) EM FOLLOW-UP", WS_OBSERVACAO);

                /*" -1163- PERFORM R0801-GRAVA-CB1260B1 */

                R0801_GRAVA_CB1260B1_SECTION();

                /*" -1164- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -1167- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                {

                    R0510_00_FETCH_PARCELAS_SECTION();
                }

                /*" -1168- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -1170- END-IF */
            }


            /*" -1172- MOVE SPACES TO WS-TEM-MOVDEBCE */
            _.Move("", AREA_DE_WORK.WS_TEM_MOVDEBCE);

            /*" -1176- PERFORM R1100-00-DECLARE-MOVDEBCE */

            R1100_00_DECLARE_MOVDEBCE_SECTION();

            /*" -1179- IF (WS-TEM-MOVDEBCE = 'S' ) AND (MOVDEBCE-NUM-CARTAO > 0 OR APOLCOBR-TIPO-COBRANCA = '2' ) */

            if ((AREA_DE_WORK.WS_TEM_MOVDEBCE == "S") && (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO > 0 || APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA == "2"))
            {

                /*" -1182- IF ( (ENDOSSOS-RAMO-EMISSOR = 53) AND (ENDOSSOS-COD-PRODUTO = 5302 OR 5303 OR 5304) ) */

                if (((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
                {

                    /*" -1183- GO TO R0800-03 */

                    R0800_03(); //GOTO
                    return;

                    /*" -1195- ELSE */
                }
                else
                {


                    /*" -1197- MOVE 'FORMA DE PAGAMENTO EH CARTAO' TO WS-OBSERVACAO */
                    _.Move("FORMA DE PAGAMENTO EH CARTAO", WS_OBSERVACAO);

                    /*" -1199- PERFORM R0801-GRAVA-CB1260B1 */

                    R0801_GRAVA_CB1260B1_SECTION();

                    /*" -1201- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                    WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                    /*" -1204- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                    while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                    {

                        R0510_00_FETCH_PARCELAS_SECTION();
                    }

                    /*" -1205- GO TO R0800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                    return;

                    /*" -1206- END-IF */
                }


                /*" -1207- END-IF. */
            }


            /*" -1207- PERFORM R0800-03 */

            R0800_03(true);

        }

        [StopWatch]
        /*" R0800-03 */
        private void R0800_03(bool isPerform = false)
        {
            /*" -1237- IF WS-TEM-MOVDEBCE = 'S' AND MOVDEBCE-SITUACAO-COBRANCA NOT = '3' AND MOVDEBCE-SITUACAO-COBRANCA NOT = '6' */

            if (AREA_DE_WORK.WS_TEM_MOVDEBCE == "S" && MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA != "3" && MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA != "6")
            {

                /*" -1249- IF PARCEHIS-DATA-VENCIMENTO < WS-DTVENCTO-SELEC */

                if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO < AREA_DE_WORK.WS_DTVENCTO_SELEC)
                {

                    /*" -1251- MOVE 'PARCELA NAO TEVE RETORNO DO DEBITO EM CONTA' TO WS-OBSERVACAO */
                    _.Move("PARCELA NAO TEVE RETORNO DO DEBITO EM CONTA", WS_OBSERVACAO);

                    /*" -1253- PERFORM R0801-GRAVA-CB1260B1 */

                    R0801_GRAVA_CB1260B1_SECTION();

                    /*" -1255- END-IF */
                }


                /*" -1257- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -1260- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                {

                    R0510_00_FETCH_PARCELAS_SECTION();
                }

                /*" -1261- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -1270- END-IF */
            }


            /*" -1287- IF WS-TEM-MOVDEBCE = 'S' AND MOVDEBCE-SITUACAO-COBRANCA = '3' AND MOVDEBCE-COD-RETORNO-CEF = 18 */

            if (AREA_DE_WORK.WS_TEM_MOVDEBCE == "S" && MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "3" && MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 18)
            {

                /*" -1289- MOVE 'REJEICAO DO DEBITO DA PARC. RETORNO = 18       ' TO WS-OBSERVACAO */
                _.Move("REJEICAO DO DEBITO DA PARC. RETORNO = 18       ", WS_OBSERVACAO);

                /*" -1291- PERFORM R0801-GRAVA-CB1260B1 */

                R0801_GRAVA_CB1260B1_SECTION();

                /*" -1292- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -1295- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                {

                    R0510_00_FETCH_PARCELAS_SECTION();
                }

                /*" -1296- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -1314- END-IF */
            }


            /*" -1317- IF ENDOSSOS-RAMO-EMISSOR NOT = 31 AND ENDOSSOS-RAMO-EMISSOR NOT = 53 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR != 31 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR != 53)
            {

                /*" -1318- IF WS-TEM-MOVDEBCE NOT = 'S' */

                if (AREA_DE_WORK.WS_TEM_MOVDEBCE != "S")
                {

                    /*" -1320- IF PARCEHIS-DATA-VENCIMENTO < WS-DTVENCTO-SELEC */

                    if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO < AREA_DE_WORK.WS_DTVENCTO_SELEC)
                    {

                        /*" -1321- GO TO R0800-04 */

                        R0800_04(); //GOTO
                        return;

                        /*" -1322- ELSE */
                    }
                    else
                    {


                        /*" -1323- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                        WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                        /*" -1326- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                        while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                        {

                            R0510_00_FETCH_PARCELAS_SECTION();
                        }

                        /*" -1327- GO TO R0800-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                        return;

                        /*" -1328- END-IF */
                    }


                    /*" -1329- END-IF */
                }


                /*" -1330- ELSE */
            }
            else
            {


                /*" -1331- IF WS-TEM-MOVDEBCE NOT = 'S' */

                if (AREA_DE_WORK.WS_TEM_MOVDEBCE != "S")
                {

                    /*" -1334- IF ( (ENDOSSOS-RAMO-EMISSOR = 31) OR (ENDOSSOS-RAMO-EMISSOR = 53 AND ENDOSSOS-COD-PRODUTO = 5302 OR 5303 OR 5304) ) */

                    if (((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 31) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
                    {

                        /*" -1336- IF PARCEHIS-DATA-VENCIMENTO < WS-DTVENCTO-02 */

                        if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO < AREA_DE_WORK.WS_DTVENCTO_02)
                        {

                            /*" -1337- GO TO R0800-04 */

                            R0800_04(); //GOTO
                            return;

                            /*" -1338- ELSE */
                        }
                        else
                        {


                            /*" -1339- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                            WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                            /*" -1342- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                            while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                            {

                                R0510_00_FETCH_PARCELAS_SECTION();
                            }

                            /*" -1343- GO TO R0800-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                            return;

                            /*" -1344- END-IF */
                        }


                        /*" -1345- END-IF */
                    }


                    /*" -1346- END-IF */
                }


                /*" -1347- END-IF. */
            }


            /*" -1347- PERFORM R0800-04 */

            R0800_04(true);

        }

        [StopWatch]
        /*" R0800-04 */
        private void R0800_04(bool isPerform = false)
        {
            /*" -1355- PERFORM R0990-00-SELECT-PARCEDEV */

            R0990_00_SELECT_PARCEDEV_SECTION();

            /*" -1367- IF SISTEMAS-DATA-MOV-ABERTO < PARCEDEV-DATA-CANCEL-PREV */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO < PARCEDEV.DCLPARCELA_DEVEDOR.PARCEDEV_DATA_CANCEL_PREV)
            {

                /*" -1369- MOVE 'PARCELA INSERIDA NA ROTINA ANTERIOR DE COBRANCA' TO WS-OBSERVACAO */
                _.Move("PARCELA INSERIDA NA ROTINA ANTERIOR DE COBRANCA", WS_OBSERVACAO);

                /*" -1371- PERFORM R0801-GRAVA-CB1260B1 */

                R0801_GRAVA_CB1260B1_SECTION();

                /*" -1372- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -1375- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                {

                    R0510_00_FETCH_PARCELAS_SECTION();
                }

                /*" -1376- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -1380- END-IF */
            }


            /*" -1381- IF ENDOSSOS-TIPO-ENDOSSO = '0' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO == "0")
            {

                /*" -1382- MOVE ENDOSSOS-DATA-INIVIGENCIA TO WS-HOST-DTINIVIG-APOL */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, WS_HOST_DTINIVIG_APOL);

                /*" -1383- MOVE ENDOSSOS-DATA-TERVIGENCIA TO WS-HOST-DTTERVIG-APOL */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, WS_HOST_DTTERVIG_APOL);

                /*" -1384- ELSE */
            }
            else
            {


                /*" -1385- PERFORM R0960-00-SELECT-ENDOSSOS */

                R0960_00_SELECT_ENDOSSOS_SECTION();

                /*" -1390- END-IF */
            }


            /*" -1392- PERFORM R0970-00-SELECT-CALENDARIO */

            R0970_00_SELECT_CALENDARIO_SECTION();

            /*" -1394- IF WS-HOST-QTD-MESES-VIG = 12 */

            if (WS_HOST_QTD_MESES_VIG == 12)
            {

                /*" -1395- GO TO R0800-05 */

                R0800_05(); //GOTO
                return;

                /*" -1396- ELSE */
            }
            else
            {


                /*" -1408- IF ENDOSSOS-RAMO-EMISSOR NOT = 67 AND 40 AND 45 AND 75 */

                if (!ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.In("67", "40", "45", "75"))
                {

                    /*" -1410- MOVE 'QTD. MESES DE VIG. DA APOLICE DIFERENTE DE 12' TO WS-OBSERVACAO */
                    _.Move("QTD. MESES DE VIG. DA APOLICE DIFERENTE DE 12", WS_OBSERVACAO);

                    /*" -1412- PERFORM R0801-GRAVA-CB1260B1 */

                    R0801_GRAVA_CB1260B1_SECTION();

                    /*" -1413- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                    WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                    /*" -1416- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                    while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                    {

                        R0510_00_FETCH_PARCELAS_SECTION();
                    }

                    /*" -1417- GO TO R0800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                    return;

                    /*" -1418- END-IF */
                }


                /*" -1419- END-IF. */
            }


            /*" -1419- PERFORM R0800-05 */

            R0800_05(true);

        }

        [StopWatch]
        /*" R0800-05 */
        private void R0800_05(bool isPerform = false)
        {
            /*" -1432- PERFORM R1200-00-SELECT-SINISTRO */

            R1200_00_SELECT_SINISTRO_SECTION();

            /*" -1446- IF (WS-HOST-QTD-SINISTROS > 0) AND (ENDOSSOS-RAMO-EMISSOR NOT = 31) */

            if ((WS_HOST_QTD_SINISTROS > 0) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR != 31))
            {

                /*" -1448- MOVE 'APOLICE COM SINISTRO(S)' TO WS-OBSERVACAO */
                _.Move("APOLICE COM SINISTRO(S)", WS_OBSERVACAO);

                /*" -1450- PERFORM R0801-GRAVA-CB1260B1 */

                R0801_GRAVA_CB1260B1_SECTION();

                /*" -1451- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -1454- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                {

                    R0510_00_FETCH_PARCELAS_SECTION();
                }

                /*" -1455- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -1460- END-IF */
            }


            /*" -1472- IF WS-HOST-DATA-VENCIMENTO > ENDOSSOS-DATA-TERVIGENCIA */

            if (WS_HOST_DATA_VENCIMENTO > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -1474- MOVE 'APOLICE SEM VIGENCIA' TO WS-OBSERVACAO */
                _.Move("APOLICE SEM VIGENCIA", WS_OBSERVACAO);

                /*" -1476- PERFORM R0801-GRAVA-CB1260B1 */

                R0801_GRAVA_CB1260B1_SECTION();

                /*" -1477- ADD 1 TO WS-QT-REGISTRO-REJ-1 */
                WS_QT_REGISTRO_REJ_1.Value = WS_QT_REGISTRO_REJ_1 + 1;

                /*" -1480- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                {

                    R0510_00_FETCH_PARCELAS_SECTION();
                }

                /*" -1481- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -1483- END-IF */
            }


            /*" -1487- ADD 1 TO AC-S-PARCELAS */
            AREA_DE_WORK.AC_S_PARCELAS.Value = AREA_DE_WORK.AC_S_PARCELAS + 1;

            /*" -1488- IF WS-APOLICE-DIFERENTE = 'S' AND CBAPOVIG-SITUACAO NOT = '0' */

            if (AREA_DE_WORK.WS_APOLICE_DIFERENTE == "S" && CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO != "0")
            {

                /*" -1489- PERFORM R1500-00-MONTA-APOLICE-VIGPROP */

                R1500_00_MONTA_APOLICE_VIGPROP_SECTION();

                /*" -1493- END-IF */
            }


            /*" -1494- IF WS-TEM-MALA-COBR NOT = 'S' */

            if (AREA_DE_WORK.WS_TEM_MALA_COBR != "S")
            {

                /*" -1496- MOVE SPACES TO WS-DESPREZA-OUTRAS */
                _.Move("", AREA_DE_WORK.WS_DESPREZA_OUTRAS);

                /*" -1498- PERFORM R3000-00-MONTA-MALA-COBRANCA */

                R3000_00_MONTA_MALA_COBRANCA_SECTION();

                /*" -1499- IF WS-DESPREZA-OUTRAS = 'S' */

                if (AREA_DE_WORK.WS_DESPREZA_OUTRAS == "S")
                {

                    /*" -1502- PERFORM R0510-00-FETCH-PARCELAS UNTIL WS-FIM-PARCELAS = 'S' OR WS-NUM-APOLICE-ANT NOT = PARCELAS-NUM-APOLICE */

                    while (!(AREA_DE_WORK.WS_FIM_PARCELAS == "S" || AREA_DE_WORK.WS_NUM_APOLICE_ANT != PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE))
                    {

                        R0510_00_FETCH_PARCELAS_SECTION();
                    }

                    /*" -1503- GO TO R0800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                    return;

                    /*" -1504- END-IF */
                }


                /*" -1504- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-90-FETCH-PARCELAS */
        private void R0800_90_FETCH_PARCELAS(bool isPerform = false)
        {
            /*" -1508- PERFORM R0510-00-FETCH-PARCELAS. */

            R0510_00_FETCH_PARCELAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0801-GRAVA-CB1260B1-SECTION */
        private void R0801_GRAVA_CB1260B1_SECTION()
        {
            /*" -1519- INITIALIZE REG-CB1260B1 */
            _.Initialize(
                REG_CB1260B1
            );

            /*" -1520- MOVE ALL ';' TO REG-CB1260B1 */
            _.MoveAll(";", REG_CB1260B1);

            /*" -1521- MOVE PARCELAS-NUM-APOLICE TO CB1260B1-NUM-APOLICE */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, REG_CB1260B1.CB1260B1_NUM_APOLICE);

            /*" -1522- MOVE PARCELAS-NUM-ENDOSSO TO CB1260B1-NUM-ENDOSSO */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, REG_CB1260B1.CB1260B1_NUM_ENDOSSO);

            /*" -1523- MOVE PARCELAS-NUM-PARCELA TO CB1260B1-NUM-PARCELA */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, REG_CB1260B1.CB1260B1_NUM_PARCELA);

            /*" -1524- MOVE WS-DATA-2 TO CB1260B1-DT-VENCIM */
            _.Move(AREA_DE_WORK.WS_DATA_2, REG_CB1260B1.CB1260B1_DT_VENCIM);

            /*" -1526- MOVE WS-OBSERVACAO TO CB1260B1-OBSERVACAO */
            _.Move(WS_OBSERVACAO, REG_CB1260B1.CB1260B1_OBSERVACAO);

            /*" -1526- WRITE REG-CB1260B1. */
            CB1260B1.Write(REG_CB1260B1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0801_99_SAIDA*/

        [StopWatch]
        /*" R0820-00-DECLARE-AU071-SECTION */
        private void R0820_00_DECLARE_AU071_SECTION()
        {
            /*" -1538- MOVE 'R0820' TO WNR-EXEC-SQL. */
            _.Move("R0820", WABEND.WNR_EXEC_SQL);

            /*" -1539- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1542- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1557- PERFORM R0820_00_DECLARE_AU071_DB_DECLARE_1 */

            R0820_00_DECLARE_AU071_DB_DECLARE_1();

            /*" -1559- PERFORM R0820_00_DECLARE_AU071_DB_OPEN_1 */

            R0820_00_DECLARE_AU071_DB_OPEN_1();

            /*" -1563- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1564- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1565- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1566- ADD SFT TO STT(05) */
            TOTAIS_ROT.FILLER_5[05].STT.Value = TOTAIS_ROT.FILLER_5[05].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1569- ADD 1 TO SQT(05) */
            TOTAIS_ROT.FILLER_5[05].SQT.Value = TOTAIS_ROT.FILLER_5[05].SQT + 1;

            /*" -1570- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1571- DISPLAY 'R0820 - ERRO DECLARE AU071     ' */
                _.Display($"R0820 - ERRO DECLARE AU071     ");

                /*" -1572- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1572- END-IF. */
            }


        }

        [StopWatch]
        /*" R0820-00-DECLARE-AU071-DB-OPEN-1 */
        public void R0820_00_DECLARE_AU071_DB_OPEN_1()
        {
            /*" -1559- EXEC SQL OPEN C1AU071 END-EXEC. */

            C1AU071.Open();

        }

        [StopWatch]
        /*" R1100-00-DECLARE-MOVDEBCE-DB-DECLARE-1 */
        public void R1100_00_DECLARE_MOVDEBCE_DB_DECLARE_1()
        {
            /*" -2098- EXEC SQL DECLARE C0MOVDEBCE CURSOR FOR SELECT VALUE(NUM_CARTAO,0) ,VALOR_DEBITO ,DATA_VENCIMENTO ,SITUACAO_COBRANCA ,NSAS ,VALUE(COD_RETORNO_CEF,9999) FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA = :PARCELAS-NUM-PARCELA ORDER BY DATA_MOVIMENTO DESC WITH UR END-EXEC. */
            C0MOVDEBCE = new CB1260B_C0MOVDEBCE(true);
            string GetQuery_C0MOVDEBCE()
            {
                var query = @$"SELECT VALUE(NUM_CARTAO
							,0) 
							,VALOR_DEBITO 
							,DATA_VENCIMENTO 
							,SITUACAO_COBRANCA 
							,NSAS 
							,VALUE(COD_RETORNO_CEF
							,9999) 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF 
							WHERE NUM_APOLICE = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}' 
							AND NUM_ENDOSSO = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}' 
							AND NUM_PARCELA = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}' 
							ORDER BY DATA_MOVIMENTO DESC";

                return query;
            }
            C0MOVDEBCE.GetQueryEvent += GetQuery_C0MOVDEBCE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0820_99_SAIDA*/

        [StopWatch]
        /*" R0830-00-FETCH-AU071-SECTION */
        private void R0830_00_FETCH_AU071_SECTION()
        {
            /*" -1584- MOVE 'R0830' TO WNR-EXEC-SQL. */
            _.Move("R0830", WABEND.WNR_EXEC_SQL);

            /*" -1585- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1588- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1594- PERFORM R0830_00_FETCH_AU071_DB_FETCH_1 */

            R0830_00_FETCH_AU071_DB_FETCH_1();

            /*" -1598- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1599- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1600- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1601- ADD SFT TO STT(06) */
            TOTAIS_ROT.FILLER_5[06].STT.Value = TOTAIS_ROT.FILLER_5[06].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1604- ADD 1 TO SQT(06) */
            TOTAIS_ROT.FILLER_5[06].SQT.Value = TOTAIS_ROT.FILLER_5[06].SQT + 1;

            /*" -1605- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1606- MOVE SPACES TO AU071-DTA-VENCTO */
                _.Move("", AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);

                /*" -1607- ELSE */
            }
            else
            {


                /*" -1608- IF SQLCODE NOT = ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1609- DISPLAY 'R0830- ERRO FETCH AU071     ' */
                    _.Display($"R0830- ERRO FETCH AU071     ");

                    /*" -1610- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1611- END-IF */
                }


                /*" -1613- END-IF */
            }


            /*" -1613- PERFORM R0830_00_FETCH_AU071_DB_CLOSE_1 */

            R0830_00_FETCH_AU071_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R0830-00-FETCH-AU071-DB-FETCH-1 */
        public void R0830_00_FETCH_AU071_DB_FETCH_1()
        {
            /*" -1594- EXEC SQL FETCH C1AU071 INTO :AU071-NUM-APOLICE ,:AU071-NUM-ENDOSSO ,:AU071-NUM-PARCELA ,:AU071-DTA-VENCTO ,:AU071-NUM-VENCTO END-EXEC. */

            if (C1AU071.Fetch())
            {
                _.Move(C1AU071.AU071_NUM_APOLICE, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE);
                _.Move(C1AU071.AU071_NUM_ENDOSSO, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO);
                _.Move(C1AU071.AU071_NUM_PARCELA, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA);
                _.Move(C1AU071.AU071_DTA_VENCTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);
                _.Move(C1AU071.AU071_NUM_VENCTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);
            }

        }

        [StopWatch]
        /*" R0830-00-FETCH-AU071-DB-CLOSE-1 */
        public void R0830_00_FETCH_AU071_DB_CLOSE_1()
        {
            /*" -1613- EXEC SQL CLOSE C1AU071 END-EXEC. */

            C1AU071.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0830_99_SAIDA*/

        [StopWatch]
        /*" R0850-00-SELECT-APOL-VIG-PROP-SECTION */
        private void R0850_00_SELECT_APOL_VIG_PROP_SECTION()
        {
            /*" -1625- MOVE 'R0850' TO WNR-EXEC-SQL. */
            _.Move("R0850", WABEND.WNR_EXEC_SQL);

            /*" -1626- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1629- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1635- MOVE ZEROS TO CBAPOVIG-NUM-APOLICE CBAPOVIG-NUM-ENDOSSO CBAPOVIG-NUM-PARCELA CBMALPAR-NUM-APOLICE CBMALPAR-NUM-ENDOSSO CBMALPAR-NUM-PARCELA. */
            _.Move(0, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_APOLICE, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_ENDOSSO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_PARCELA);

            /*" -1641- MOVE SPACES TO CBAPOVIG-DATA-MOVIMENTO CBAPOVIG-DATA-FIM-VIG-PROP CBAPOVIG-DATA-CANCELAMENTO CBAPOVIG-SITUACAO CBMALPAR-SITUACAO. */
            _.Move("", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO);

            /*" -1659- PERFORM R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1 */

            R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1();

            /*" -1663- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1664- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1665- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1666- ADD SFT TO STT(07) */
            TOTAIS_ROT.FILLER_5[07].STT.Value = TOTAIS_ROT.FILLER_5[07].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1669- ADD 1 TO SQT(07) */
            TOTAIS_ROT.FILLER_5[07].SQT.Value = TOTAIS_ROT.FILLER_5[07].SQT + 1;

            /*" -1670- IF SQLCODE = ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1671- ADD 1 TO AC-L-CBAPOVIG */
                AREA_DE_WORK.AC_L_CBAPOVIG.Value = AREA_DE_WORK.AC_L_CBAPOVIG + 1;

                /*" -1672- MOVE 'S' TO WS-TEM-VIG-PROP */
                _.Move("S", AREA_DE_WORK.WS_TEM_VIG_PROP);

                /*" -1673- ELSE */
            }
            else
            {


                /*" -1674- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1675- MOVE 'N' TO WS-TEM-VIG-PROP */
                    _.Move("N", AREA_DE_WORK.WS_TEM_VIG_PROP);

                    /*" -1676- ELSE */
                }
                else
                {


                    /*" -1677- DISPLAY 'R0850- ERRO SELECT CB_APOLICE_VIGPROP' */
                    _.Display($"R0850- ERRO SELECT CB_APOLICE_VIGPROP");

                    /*" -1678- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                    _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                    /*" -1679- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                    /*" -1680- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                    _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                    /*" -1681- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1682- END-IF */
                }


                /*" -1685- END-IF */
            }


            /*" -1686- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1689- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1703- PERFORM R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2 */

            R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2();

            /*" -1707- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1708- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1709- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1710- ADD SFT TO STT(08) */
            TOTAIS_ROT.FILLER_5[08].STT.Value = TOTAIS_ROT.FILLER_5[08].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1714- ADD 1 TO SQT(08) */
            TOTAIS_ROT.FILLER_5[08].SQT.Value = TOTAIS_ROT.FILLER_5[08].SQT + 1;

            /*" -1715- IF SQLCODE = ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -1716- ADD 1 TO AC-L-CBMALPAR */
                AREA_DE_WORK.AC_L_CBMALPAR.Value = AREA_DE_WORK.AC_L_CBMALPAR + 1;

                /*" -1717- MOVE 'S' TO WS-TEM-MALA-COBR */
                _.Move("S", AREA_DE_WORK.WS_TEM_MALA_COBR);

                /*" -1718- ELSE */
            }
            else
            {


                /*" -1719- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1720- MOVE 'N' TO WS-TEM-MALA-COBR */
                    _.Move("N", AREA_DE_WORK.WS_TEM_MALA_COBR);

                    /*" -1721- ELSE */
                }
                else
                {


                    /*" -1722- DISPLAY 'R0850- ERRO SELECT CB_MALA_PARCATRASO' */
                    _.Display($"R0850- ERRO SELECT CB_MALA_PARCATRASO");

                    /*" -1723- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                    _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                    /*" -1724- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                    /*" -1725- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                    _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                    /*" -1726- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1727- END-IF */
                }


                /*" -1727- END-IF. */
            }


        }

        [StopWatch]
        /*" R0850-00-SELECT-APOL-VIG-PROP-DB-SELECT-1 */
        public void R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1()
        {
            /*" -1659- EXEC SQL SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DATA_MOVIMENTO ,DATA_FIM_VIG_PROP ,DATA_CANCELAMENTO ,SITUACAO INTO :CBAPOVIG-NUM-APOLICE ,:CBAPOVIG-NUM-ENDOSSO ,:CBAPOVIG-NUM-PARCELA ,:CBAPOVIG-DATA-MOVIMENTO ,:CBAPOVIG-DATA-FIM-VIG-PROP ,:CBAPOVIG-DATA-CANCELAMENTO ,:CBAPOVIG-SITUACAO FROM SEGUROS.CB_APOLICE_VIGPROP WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE WITH UR END-EXEC. */

            var r0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1 = new R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1.Execute(r0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBAPOVIG_NUM_APOLICE, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE);
                _.Move(executed_1.CBAPOVIG_NUM_ENDOSSO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO);
                _.Move(executed_1.CBAPOVIG_NUM_PARCELA, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA);
                _.Move(executed_1.CBAPOVIG_DATA_MOVIMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO);
                _.Move(executed_1.CBAPOVIG_DATA_FIM_VIG_PROP, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP);
                _.Move(executed_1.CBAPOVIG_DATA_CANCELAMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO);
                _.Move(executed_1.CBAPOVIG_SITUACAO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_99_SAIDA*/

        [StopWatch]
        /*" R0850-00-SELECT-APOL-VIG-PROP-DB-SELECT-2 */
        public void R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2()
        {
            /*" -1703- EXEC SQL SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,SITUACAO INTO :CBMALPAR-NUM-APOLICE ,:CBMALPAR-NUM-ENDOSSO ,:CBMALPAR-NUM-PARCELA ,:CBMALPAR-SITUACAO FROM SEGUROS.CB_MALA_PARCATRASO WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA = :PARCELAS-NUM-PARCELA WITH UR END-EXEC. */

            var r0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1 = new R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1.Execute(r0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBMALPAR_NUM_APOLICE, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_APOLICE);
                _.Move(executed_1.CBMALPAR_NUM_ENDOSSO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_ENDOSSO);
                _.Move(executed_1.CBMALPAR_NUM_PARCELA, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_PARCELA);
                _.Move(executed_1.CBMALPAR_SITUACAO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO);
            }


        }

        [StopWatch]
        /*" R0860-00-LE-TIPO-ADESAO-SECTION */
        private void R0860_00_LE_TIPO_ADESAO_SECTION()
        {
            /*" -1739- MOVE 'R0860' TO WNR-EXEC-SQL. */
            _.Move("R0860", WABEND.WNR_EXEC_SQL);

            /*" -1740- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1743- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1750- PERFORM R0860_00_LE_TIPO_ADESAO_DB_SELECT_1 */

            R0860_00_LE_TIPO_ADESAO_DB_SELECT_1();

            /*" -1754- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1755- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1756- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1757- ADD SFT TO STT(09) */
            TOTAIS_ROT.FILLER_5[09].STT.Value = TOTAIS_ROT.FILLER_5[09].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1760- ADD 1 TO SQT(09) */
            TOTAIS_ROT.FILLER_5[09].SQT.Value = TOTAIS_ROT.FILLER_5[09].SQT + 1;

            /*" -1761- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1762- DISPLAY 'R0860 - ERRO SELECT AU_APOLICE_COMPL' */
                _.Display($"R0860 - ERRO SELECT AU_APOLICE_COMPL");

                /*" -1763- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -1764- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -1765- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -1766- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1766- END-IF. */
            }


        }

        [StopWatch]
        /*" R0860-00-LE-TIPO-ADESAO-DB-SELECT-1 */
        public void R0860_00_LE_TIPO_ADESAO_DB_SELECT_1()
        {
            /*" -1750- EXEC SQL SELECT IND_FORMA_PAGTO_AD INTO :AU084-IND-FORMA-PAGTO-AD FROM SEGUROS.AU_APOLICE_COMPL WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1 = new R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1.Execute(r0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU084_IND_FORMA_PAGTO_AD, AU084.DCLAU_APOLICE_COMPL.AU084_IND_FORMA_PAGTO_AD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0860_99_SAIDA*/

        [StopWatch]
        /*" R0870-00-LE-SIT-COBR-CARTAO-SECTION */
        private void R0870_00_LE_SIT_COBR_CARTAO_SECTION()
        {
            /*" -1778- MOVE 'R0870' TO WNR-EXEC-SQL. */
            _.Move("R0870", WABEND.WNR_EXEC_SQL);

            /*" -1779- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1782- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1791- PERFORM R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1 */

            R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1();

            /*" -1795- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1796- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1797- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1798- ADD SFT TO STT(10) */
            TOTAIS_ROT.FILLER_5[10].STT.Value = TOTAIS_ROT.FILLER_5[10].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1801- ADD 1 TO SQT(10) */
            TOTAIS_ROT.FILLER_5[10].SQT.Value = TOTAIS_ROT.FILLER_5[10].SQT + 1;

            /*" -1802- IF SQLCODE NOT = ZEROS AND SQLCODE NOT = +100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != +100)
            {

                /*" -1803- DISPLAY 'R0870 - ERRO SELECT MOVIMENTO_COBRANCA' */
                _.Display($"R0870 - ERRO SELECT MOVIMENTO_COBRANCA");

                /*" -1804- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -1805- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -1806- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -1807- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1809- END-IF */
            }


            /*" -1810- IF SQLCODE = +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -1811- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO */
                _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                /*" -1811- END-IF. */
            }


        }

        [StopWatch]
        /*" R0870-00-LE-SIT-COBR-CARTAO-DB-SELECT-1 */
        public void R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1()
        {
            /*" -1791- EXEC SQL SELECT SIT_REGISTRO INTO :MOVIMCOB-SIT-REGISTRO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA = :PARCELAS-NUM-PARCELA AND SIT_REGISTRO = '*' WITH UR END-EXEC. */

            var r0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1 = new R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1.Execute(r0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-APOLICES-SECTION */
        private void R0900_00_SELECT_APOLICES_SECTION()
        {
            /*" -1823- MOVE 'R0900' TO WNR-EXEC-SQL. */
            _.Move("R0900", WABEND.WNR_EXEC_SQL);

            /*" -1824- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1827- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1839- PERFORM R0900_00_SELECT_APOLICES_DB_SELECT_1 */

            R0900_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -1843- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1844- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1845- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1846- ADD SFT TO STT(11) */
            TOTAIS_ROT.FILLER_5[11].STT.Value = TOTAIS_ROT.FILLER_5[11].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1849- ADD 1 TO SQT(11) */
            TOTAIS_ROT.FILLER_5[11].SQT.Value = TOTAIS_ROT.FILLER_5[11].SQT + 1;

            /*" -1850- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1851- DISPLAY 'R0900- ERRO SELECT APOLICES' */
                _.Display($"R0900- ERRO SELECT APOLICES");

                /*" -1852- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -1853- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1855- END-IF */
            }


            /*" -1855- ADD 1 TO AC-L-APOLICES. */
            AREA_DE_WORK.AC_L_APOLICES.Value = AREA_DE_WORK.AC_L_APOLICES + 1;

        }

        [StopWatch]
        /*" R0900-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R0900_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -1839- EXEC SQL SELECT ORGAO_EMISSOR ,TIPO_SEGURO ,TIPO_APOLICE INTO :APOLICES-ORGAO-EMISSOR ,:APOLICES-TIPO-SEGURO ,:APOLICES-TIPO-APOLICE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE WITH UR END-EXEC. */

            var r0900_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(executed_1.APOLICES_TIPO_SEGURO, APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO);
                _.Move(executed_1.APOLICES_TIPO_APOLICE, APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-SELECT-ENDOSSOS-SECTION */
        private void R0950_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1867- MOVE 'R0950' TO WNR-EXEC-SQL. */
            _.Move("R0950", WABEND.WNR_EXEC_SQL);

            /*" -1868- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1871- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1878- PERFORM R0950_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0950_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1882- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1883- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1884- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1885- ADD SFT TO STT(12) */
            TOTAIS_ROT.FILLER_5[12].STT.Value = TOTAIS_ROT.FILLER_5[12].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1888- ADD 1 TO SQT(12) */
            TOTAIS_ROT.FILLER_5[12].SQT.Value = TOTAIS_ROT.FILLER_5[12].SQT + 1;

            /*" -1889- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1890- DISPLAY 'R0950- ERRO SELECT ENDOSSOS' */
                _.Display($"R0950- ERRO SELECT ENDOSSOS");

                /*" -1891- DISPLAY 'APOLICE = ' ENDOSSOS-NUM-APOLICE */
                _.Display($"APOLICE = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -1892- DISPLAY 'ENDOSSO = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -1893- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1895- END-IF */
            }


            /*" -1895- ADD 1 TO AC-L-ENDOSSOS. */
            AREA_DE_WORK.AC_L_ENDOSSOS.Value = AREA_DE_WORK.AC_L_ENDOSSOS + 1;

        }

        [StopWatch]
        /*" R0950-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0950_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1878- EXEC SQL SELECT TIPO_ENDOSSO INTO :WS-HOST-TIPO-ENDOSSO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0950_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_TIPO_ENDOSSO, WS_HOST_TIPO_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R0960-00-SELECT-ENDOSSOS-SECTION */
        private void R0960_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1907- MOVE 'R0960' TO WNR-EXEC-SQL. */
            _.Move("R0960", WABEND.WNR_EXEC_SQL);

            /*" -1908- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1911- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1920- PERFORM R0960_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0960_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1924- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1925- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1926- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1927- ADD SFT TO STT(13) */
            TOTAIS_ROT.FILLER_5[13].STT.Value = TOTAIS_ROT.FILLER_5[13].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1930- ADD 1 TO SQT(13) */
            TOTAIS_ROT.FILLER_5[13].SQT.Value = TOTAIS_ROT.FILLER_5[13].SQT + 1;

            /*" -1931- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1932- DISPLAY 'R0960- ERRO SELECT ENDOSSOS' */
                _.Display($"R0960- ERRO SELECT ENDOSSOS");

                /*" -1933- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -1934- DISPLAY 'ENDOSSO = ' 0 */
                _.Display($"ENDOSSO = 0");

                /*" -1935- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1937- END-IF */
            }


            /*" -1937- ADD 1 TO AC-L-ENDOSSOS. */
            AREA_DE_WORK.AC_L_ENDOSSOS.Value = AREA_DE_WORK.AC_L_ENDOSSOS + 1;

        }

        [StopWatch]
        /*" R0960-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0960_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1920- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA INTO :WS-HOST-DTINIVIG-APOL ,:WS-HOST-DTTERVIG-APOL FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0960_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_DTINIVIG_APOL, WS_HOST_DTINIVIG_APOL);
                _.Move(executed_1.WS_HOST_DTTERVIG_APOL, WS_HOST_DTTERVIG_APOL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0960_99_SAIDA*/

        [StopWatch]
        /*" R0970-00-SELECT-CALENDARIO-SECTION */
        private void R0970_00_SELECT_CALENDARIO_SECTION()
        {
            /*" -1949- MOVE 'R0970' TO WNR-EXEC-SQL. */
            _.Move("R0970", WABEND.WNR_EXEC_SQL);

            /*" -1950- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1953- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -1960- PERFORM R0970_00_SELECT_CALENDARIO_DB_SELECT_1 */

            R0970_00_SELECT_CALENDARIO_DB_SELECT_1();

            /*" -1964- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -1965- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -1966- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -1967- ADD SFT TO STT(14) */
            TOTAIS_ROT.FILLER_5[14].STT.Value = TOTAIS_ROT.FILLER_5[14].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -1970- ADD 1 TO SQT(14) */
            TOTAIS_ROT.FILLER_5[14].SQT.Value = TOTAIS_ROT.FILLER_5[14].SQT + 1;

            /*" -1971- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1972- DISPLAY 'R0970- ERRO SELECT CALENDARIO' */
                _.Display($"R0970- ERRO SELECT CALENDARIO");

                /*" -1973- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -1974- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -1975- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -1976- DISPLAY 'DTINIVIG= ' WS-HOST-DTINIVIG-APOL */
                _.Display($"DTINIVIG= {WS_HOST_DTINIVIG_APOL}");

                /*" -1977- DISPLAY 'DTTERVIG= ' WS-HOST-DTTERVIG-APOL */
                _.Display($"DTTERVIG= {WS_HOST_DTTERVIG_APOL}");

                /*" -1978- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1980- END-IF */
            }


            /*" -1980- ADD 1 TO AC-L-CALENDARIO. */
            AREA_DE_WORK.AC_L_CALENDARIO.Value = AREA_DE_WORK.AC_L_CALENDARIO + 1;

        }

        [StopWatch]
        /*" R0970-00-SELECT-CALENDARIO-DB-SELECT-1 */
        public void R0970_00_SELECT_CALENDARIO_DB_SELECT_1()
        {
            /*" -1960- EXEC SQL SELECT VALUE(COUNT(*) / 30,+0) INTO :WS-HOST-QTD-MESES-VIG FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO BETWEEN :WS-HOST-DTINIVIG-APOL AND :WS-HOST-DTTERVIG-APOL WITH UR END-EXEC. */

            var r0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 = new R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1()
            {
                WS_HOST_DTINIVIG_APOL = WS_HOST_DTINIVIG_APOL.ToString(),
                WS_HOST_DTTERVIG_APOL = WS_HOST_DTTERVIG_APOL.ToString(),
            };

            var executed_1 = R0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1.Execute(r0970_00_SELECT_CALENDARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_QTD_MESES_VIG, WS_HOST_QTD_MESES_VIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0970_99_SAIDA*/

        [StopWatch]
        /*" R0990-00-SELECT-PARCEDEV-SECTION */
        private void R0990_00_SELECT_PARCEDEV_SECTION()
        {
            /*" -1992- MOVE 'R0990' TO WNR-EXEC-SQL. */
            _.Move("R0990", WABEND.WNR_EXEC_SQL);

            /*" -1993- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -1996- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2005- PERFORM R0990_00_SELECT_PARCEDEV_DB_SELECT_1 */

            R0990_00_SELECT_PARCEDEV_DB_SELECT_1();

            /*" -2009- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2010- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2011- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2012- ADD SFT TO STT(15) */
            TOTAIS_ROT.FILLER_5[15].STT.Value = TOTAIS_ROT.FILLER_5[15].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2015- ADD 1 TO SQT(15) */
            TOTAIS_ROT.FILLER_5[15].SQT.Value = TOTAIS_ROT.FILLER_5[15].SQT + 1;

            /*" -2016- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2017- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2018- MOVE '0001-01-01' TO PARCEDEV-DATA-CANCEL-PREV */
                    _.Move("0001-01-01", PARCEDEV.DCLPARCELA_DEVEDOR.PARCEDEV_DATA_CANCEL_PREV);

                    /*" -2019- ELSE */
                }
                else
                {


                    /*" -2020- DISPLAY 'R0990- ERRO SELECT CALENDARIO' */
                    _.Display($"R0990- ERRO SELECT CALENDARIO");

                    /*" -2021- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                    _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                    /*" -2022- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                    /*" -2023- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                    _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                    /*" -2024- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2025- END-IF */
                }


                /*" -2026- ELSE */
            }
            else
            {


                /*" -2027- ADD 1 TO AC-L-PARCEDEV */
                AREA_DE_WORK.AC_L_PARCEDEV.Value = AREA_DE_WORK.AC_L_PARCEDEV + 1;

                /*" -2027- END-IF. */
            }


        }

        [StopWatch]
        /*" R0990-00-SELECT-PARCEDEV-DB-SELECT-1 */
        public void R0990_00_SELECT_PARCEDEV_DB_SELECT_1()
        {
            /*" -2005- EXEC SQL SELECT VALUE(DATA_CANCEL_PREV,DATE( '0001-01-01' )) INTO :PARCEDEV-DATA-CANCEL-PREV FROM SEGUROS.PARCELA_DEVEDOR WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA = :PARCELAS-NUM-PARCELA AND SITUACAO = '1' WITH UR END-EXEC. */

            var r0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1 = new R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1.Execute(r0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEDEV_DATA_CANCEL_PREV, PARCEDEV.DCLPARCELA_DEVEDOR.PARCEDEV_DATA_CANCEL_PREV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0990_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-SELECT-FOLLOW-UP-SECTION */
        private void R1000_00_SELECT_FOLLOW_UP_SECTION()
        {
            /*" -2039- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WABEND.WNR_EXEC_SQL);

            /*" -2040- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2043- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2050- PERFORM R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1 */

            R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1();

            /*" -2054- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2055- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2056- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2057- ADD SFT TO STT(16) */
            TOTAIS_ROT.FILLER_5[16].STT.Value = TOTAIS_ROT.FILLER_5[16].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2060- ADD 1 TO SQT(16) */
            TOTAIS_ROT.FILLER_5[16].SQT.Value = TOTAIS_ROT.FILLER_5[16].SQT + 1;

            /*" -2061- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2062- DISPLAY 'R1000- ERRO SELECT FOLLOW_UP' */
                _.Display($"R1000- ERRO SELECT FOLLOW_UP");

                /*" -2063- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2064- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2066- END-IF */
            }


            /*" -2067- IF WS-HOST-QTD-DOCUMENTOS > 0 */

            if (WS_HOST_QTD_DOCUMENTOS > 0)
            {

                /*" -2068- ADD 1 TO AC-L-FOLLOUP */
                AREA_DE_WORK.AC_L_FOLLOUP.Value = AREA_DE_WORK.AC_L_FOLLOUP + 1;

                /*" -2068- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-00-SELECT-FOLLOW-UP-DB-SELECT-1 */
        public void R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1()
        {
            /*" -2050- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-HOST-QTD-DOCUMENTOS FROM SEGUROS.FOLLOW_UP WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1 = new R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1.Execute(r1000_00_SELECT_FOLLOW_UP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_QTD_DOCUMENTOS, WS_HOST_QTD_DOCUMENTOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-DECLARE-MOVDEBCE-SECTION */
        private void R1100_00_DECLARE_MOVDEBCE_SECTION()
        {
            /*" -2080- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", WABEND.WNR_EXEC_SQL);

            /*" -2081- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2084- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2098- PERFORM R1100_00_DECLARE_MOVDEBCE_DB_DECLARE_1 */

            R1100_00_DECLARE_MOVDEBCE_DB_DECLARE_1();

            /*" -2100- PERFORM R1100_00_DECLARE_MOVDEBCE_DB_OPEN_1 */

            R1100_00_DECLARE_MOVDEBCE_DB_OPEN_1();

            /*" -2104- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2105- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2106- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2107- ADD SFT TO STT(17) */
            TOTAIS_ROT.FILLER_5[17].STT.Value = TOTAIS_ROT.FILLER_5[17].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2110- ADD 1 TO SQT(17) */
            TOTAIS_ROT.FILLER_5[17].SQT.Value = TOTAIS_ROT.FILLER_5[17].SQT + 1;

            /*" -2111- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2112- DISPLAY 'R1100 - ERRO DECLARE MOVTO_DEBITOCC_CEF' */
                _.Display($"R1100 - ERRO DECLARE MOVTO_DEBITOCC_CEF");

                /*" -2113- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2115- END-IF */
            }


            /*" -2115- PERFORM R1110-00-FETCH-MOVDEBCE. */

            R1110_00_FETCH_MOVDEBCE_SECTION();

        }

        [StopWatch]
        /*" R1100-00-DECLARE-MOVDEBCE-DB-OPEN-1 */
        public void R1100_00_DECLARE_MOVDEBCE_DB_OPEN_1()
        {
            /*" -2100- EXEC SQL OPEN C0MOVDEBCE END-EXEC. */

            C0MOVDEBCE.Open();

        }

        [StopWatch]
        /*" R1700-00-DECLARE-PARCEHIS-DB-DECLARE-1 */
        public void R1700_00_DECLARE_PARCEHIS_DB_DECLARE_1()
        {
            /*" -2519- EXEC SQL DECLARE C0PARCEHIS CURSOR FOR SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,OCORR_HISTORICO ,COD_OPERACAO ,DATA_MOVIMENTO ,PRM_TOTAL FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND COD_OPERACAO < 600 WITH UR END-EXEC. */
            C0PARCEHIS = new CB1260B_C0PARCEHIS(true);
            string GetQuery_C0PARCEHIS()
            {
                var query = @$"SELECT NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,OCORR_HISTORICO 
							,COD_OPERACAO 
							,DATA_MOVIMENTO 
							,PRM_TOTAL 
							FROM SEGUROS.PARCELA_HISTORICO 
							WHERE NUM_APOLICE = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}' 
							AND COD_OPERACAO < 600";

                return query;
            }
            C0PARCEHIS.GetQueryEvent += GetQuery_C0PARCEHIS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-FETCH-MOVDEBCE-SECTION */
        private void R1110_00_FETCH_MOVDEBCE_SECTION()
        {
            /*" -2127- MOVE 'R1110' TO WNR-EXEC-SQL. */
            _.Move("R1110", WABEND.WNR_EXEC_SQL);

            /*" -2128- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2131- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2138- PERFORM R1110_00_FETCH_MOVDEBCE_DB_FETCH_1 */

            R1110_00_FETCH_MOVDEBCE_DB_FETCH_1();

            /*" -2142- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2143- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2144- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2145- ADD SFT TO STT(18) */
            TOTAIS_ROT.FILLER_5[18].STT.Value = TOTAIS_ROT.FILLER_5[18].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2148- ADD 1 TO SQT(18) */
            TOTAIS_ROT.FILLER_5[18].SQT.Value = TOTAIS_ROT.FILLER_5[18].SQT + 1;

            /*" -2149- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2150- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2150- PERFORM R1110_00_FETCH_MOVDEBCE_DB_CLOSE_1 */

                    R1110_00_FETCH_MOVDEBCE_DB_CLOSE_1();

                    /*" -2152- MOVE 'N' TO WS-TEM-MOVDEBCE */
                    _.Move("N", AREA_DE_WORK.WS_TEM_MOVDEBCE);

                    /*" -2153- MOVE 0 TO MOVDEBCE-NUM-CARTAO */
                    _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

                    /*" -2154- MOVE 0 TO MOVDEBCE-VALOR-DEBITO */
                    _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

                    /*" -2155- MOVE SPACES TO MOVDEBCE-DATA-VENCIMENTO */
                    _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

                    /*" -2156- MOVE SPACES TO MOVDEBCE-SITUACAO-COBRANCA */
                    _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                    /*" -2157- MOVE 9999 TO MOVDEBCE-COD-RETORNO-CEF */
                    _.Move(9999, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                    /*" -2158- GO TO R1110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                    return;

                    /*" -2159- ELSE */
                }
                else
                {


                    /*" -2160- DISPLAY 'R1110- ERRO SELECT MOVTO_DEBITOCC_CEF' */
                    _.Display($"R1110- ERRO SELECT MOVTO_DEBITOCC_CEF");

                    /*" -2161- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                    _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                    /*" -2162- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                    /*" -2163- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                    _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                    /*" -2164- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2165- END-IF */
                }


                /*" -2167- END-IF */
            }


            /*" -2167- PERFORM R1110_00_FETCH_MOVDEBCE_DB_CLOSE_2 */

            R1110_00_FETCH_MOVDEBCE_DB_CLOSE_2();

            /*" -2171- MOVE 'S' TO WS-TEM-MOVDEBCE. */
            _.Move("S", AREA_DE_WORK.WS_TEM_MOVDEBCE);

            /*" -2171- ADD 1 TO AC-L-MOVDEBCE. */
            AREA_DE_WORK.AC_L_MOVDEBCE.Value = AREA_DE_WORK.AC_L_MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R1110-00-FETCH-MOVDEBCE-DB-FETCH-1 */
        public void R1110_00_FETCH_MOVDEBCE_DB_FETCH_1()
        {
            /*" -2138- EXEC SQL FETCH C0MOVDEBCE INTO :MOVDEBCE-NUM-CARTAO ,:MOVDEBCE-VALOR-DEBITO ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-NSAS ,:MOVDEBCE-COD-RETORNO-CEF END-EXEC. */

            if (C0MOVDEBCE.Fetch())
            {
                _.Move(C0MOVDEBCE.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(C0MOVDEBCE.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(C0MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(C0MOVDEBCE.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(C0MOVDEBCE.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(C0MOVDEBCE.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);
            }

        }

        [StopWatch]
        /*" R1110-00-FETCH-MOVDEBCE-DB-CLOSE-1 */
        public void R1110_00_FETCH_MOVDEBCE_DB_CLOSE_1()
        {
            /*" -2150- EXEC SQL CLOSE C0MOVDEBCE END-EXEC */

            C0MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-FETCH-MOVDEBCE-DB-CLOSE-2 */
        public void R1110_00_FETCH_MOVDEBCE_DB_CLOSE_2()
        {
            /*" -2167- EXEC SQL CLOSE C0MOVDEBCE END-EXEC. */

            C0MOVDEBCE.Close();

        }

        [StopWatch]
        /*" R1150-00-SELECT-APOLCOBR-SECTION */
        private void R1150_00_SELECT_APOLCOBR_SECTION()
        {
            /*" -2185- MOVE 'R1150' TO WNR-EXEC-SQL. */
            _.Move("R1150", WABEND.WNR_EXEC_SQL);

            /*" -2186- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2189- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2196- PERFORM R1150_00_SELECT_APOLCOBR_DB_SELECT_1 */

            R1150_00_SELECT_APOLCOBR_DB_SELECT_1();

            /*" -2200- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2201- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2202- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2203- ADD SFT TO STT(19) */
            TOTAIS_ROT.FILLER_5[19].STT.Value = TOTAIS_ROT.FILLER_5[19].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2207- ADD 1 TO SQT(19) */
            TOTAIS_ROT.FILLER_5[19].SQT.Value = TOTAIS_ROT.FILLER_5[19].SQT + 1;

            /*" -2208- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2209- MOVE SPACES TO APOLCOBR-TIPO-COBRANCA */
                _.Move("", APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA);

                /*" -2210- ELSE */
            }
            else
            {


                /*" -2211- IF SQLCODE NOT = ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2212- DISPLAY 'R1150-00 (PROBLEMAS SELECT APOLCOB) ... ' */
                    _.Display($"R1150-00 (PROBLEMAS SELECT APOLCOB) ... ");

                    /*" -2213- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2214- END-IF */
                }


                /*" -2214- END-IF. */
            }


        }

        [StopWatch]
        /*" R1150-00-SELECT-APOLCOBR-DB-SELECT-1 */
        public void R1150_00_SELECT_APOLCOBR_DB_SELECT_1()
        {
            /*" -2196- EXEC SQL SELECT TIPO_COBRANCA INTO :APOLCOBR-TIPO-COBRANCA FROM SEGUROS.APOLICE_COBRANCA WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO WITH UR END-EXEC. */

            var r1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 = new R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1.Execute(r1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOBR_TIPO_COBRANCA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-SINISTRO-SECTION */
        private void R1200_00_SELECT_SINISTRO_SECTION()
        {
            /*" -2226- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WABEND.WNR_EXEC_SQL);

            /*" -2227- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2230- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2237- PERFORM R1200_00_SELECT_SINISTRO_DB_SELECT_1 */

            R1200_00_SELECT_SINISTRO_DB_SELECT_1();

            /*" -2241- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2242- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2243- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2244- ADD SFT TO STT(20) */
            TOTAIS_ROT.FILLER_5[20].STT.Value = TOTAIS_ROT.FILLER_5[20].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2247- ADD 1 TO SQT(20) */
            TOTAIS_ROT.FILLER_5[20].SQT.Value = TOTAIS_ROT.FILLER_5[20].SQT + 1;

            /*" -2248- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2249- DISPLAY 'R1200- ERRO SELECT SINISTRO_MESTRE' */
                _.Display($"R1200- ERRO SELECT SINISTRO_MESTRE");

                /*" -2250- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2251- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2257- END-IF */
            }


            /*" -2259- IF WS-HOST-QTD-SINISTROS > 0 */

            if (WS_HOST_QTD_SINISTROS > 0)
            {

                /*" -2260- PERFORM R1250-00-SELECT-SINICAUSA */

                R1250_00_SELECT_SINICAUSA_SECTION();

                /*" -2260- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-SINISTRO-DB-SELECT-1 */
        public void R1200_00_SELECT_SINISTRO_DB_SELECT_1()
        {
            /*" -2237- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-HOST-QTD-SINISTROS FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND SIT_REGISTRO �= '2' WITH UR END-EXEC */

            var r1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1 = new R1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_SINISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_QTD_SINISTROS, WS_HOST_QTD_SINISTROS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-SELECT-SINICAUSA-SECTION */
        private void R1250_00_SELECT_SINICAUSA_SECTION()
        {
            /*" -2272- MOVE 'R1250' TO WNR-EXEC-SQL. */
            _.Move("R1250", WABEND.WNR_EXEC_SQL);

            /*" -2273- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2276- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2287- PERFORM R1250_00_SELECT_SINICAUSA_DB_SELECT_1 */

            R1250_00_SELECT_SINICAUSA_DB_SELECT_1();

            /*" -2291- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2292- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2293- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2294- ADD SFT TO STT(21) */
            TOTAIS_ROT.FILLER_5[21].STT.Value = TOTAIS_ROT.FILLER_5[21].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2297- ADD 1 TO SQT(21) */
            TOTAIS_ROT.FILLER_5[21].SQT.Value = TOTAIS_ROT.FILLER_5[21].SQT + 1;

            /*" -2298- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2299- DISPLAY 'R1250- ERRO SELECT SINISTRO_CAUSA ' */
                _.Display($"R1250- ERRO SELECT SINISTRO_CAUSA ");

                /*" -2300- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2301- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2303- END-IF */
            }


            /*" -2304- IF WS-HOST-QTD-SINISTROS > 0 */

            if (WS_HOST_QTD_SINISTROS > 0)
            {

                /*" -2305- ADD 1 TO AC-L-SINISMES */
                AREA_DE_WORK.AC_L_SINISMES.Value = AREA_DE_WORK.AC_L_SINISMES + 1;

                /*" -2305- END-IF. */
            }


        }

        [StopWatch]
        /*" R1250-00-SELECT-SINICAUSA-DB-SELECT-1 */
        public void R1250_00_SELECT_SINICAUSA_DB_SELECT_1()
        {
            /*" -2287- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-HOST-QTD-SINISTROS FROM SEGUROS.SINISTRO_MESTRE A ,SEGUROS.SINISTRO_CAUSA B WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE AND A.SIT_REGISTRO �= '2' AND B.COD_CAUSA = A.COD_CAUSA AND B.RAMO_EMISSOR = :ENDOSSOS-RAMO-EMISSOR AND B.GRUPO_CAUSAS = 'PT' WITH UR END-EXEC */

            var r1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1 = new R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1()
            {
                ENDOSSOS_RAMO_EMISSOR = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.ToString(),
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1.Execute(r1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_QTD_SINISTROS, WS_HOST_QTD_SINISTROS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-PARCELAS-SECTION */
        private void R1300_00_SELECT_PARCELAS_SECTION()
        {
            /*" -2317- MOVE 'R1300' TO WNR-EXEC-SQL. */
            _.Move("R1300", WABEND.WNR_EXEC_SQL);

            /*" -2318- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2321- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2330- PERFORM R1300_00_SELECT_PARCELAS_DB_SELECT_1 */

            R1300_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -2334- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2335- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2336- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2337- ADD SFT TO STT(22) */
            TOTAIS_ROT.FILLER_5[22].STT.Value = TOTAIS_ROT.FILLER_5[22].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2340- ADD 1 TO SQT(22) */
            TOTAIS_ROT.FILLER_5[22].SQT.Value = TOTAIS_ROT.FILLER_5[22].SQT + 1;

            /*" -2341- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2342- DISPLAY 'R1300- ERRO SELECT PARCELAS' */
                _.Display($"R1300- ERRO SELECT PARCELAS");

                /*" -2343- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2344- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -2345- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -2346- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2346- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R1300_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -2330- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-HOST-QTD-PARCELAS FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA > :PARCELAS-NUM-PARCELA AND SIT_REGISTRO = '1' WITH UR END-EXEC. */

            var r1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_QTD_PARCELAS, WS_HOST_QTD_PARCELAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-MONTA-APOLICE-VIGPROP-SECTION */
        private void R1500_00_MONTA_APOLICE_VIGPROP_SECTION()
        {
            /*" -2359- MOVE 'R1500' TO WNR-EXEC-SQL */
            _.Move("R1500", WABEND.WNR_EXEC_SQL);

            /*" -2360- IF ENDOSSOS-RAMO-EMISSOR = 67 OR 40 OR 45 OR 75 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.In("67", "40", "45", "75"))
            {

                /*" -2363- MOVE +0 TO WS-HOST-PRM-PAGO WS-HOST-PRM-DEVIDO PRAZOSEG-FIM-PRAZO */
                _.Move(+0, WS_HOST_PRM_PAGO, WS_HOST_PRM_DEVIDO, PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_FIM_PRAZO);

                /*" -2364- MOVE WS-HOST-DTTERVIG-APOL TO WS-HOST-DATA-FIM-VIG-PROP */
                _.Move(WS_HOST_DTTERVIG_APOL, WS_HOST_DATA_FIM_VIG_PROP);

                /*" -2365- ELSE */
            }
            else
            {


                /*" -2366- PERFORM R1600-00-CALCULA-DATAS */

                R1600_00_CALCULA_DATAS_SECTION();

                /*" -2368- END-IF */
            }


            /*" -2369- MOVE PARCELAS-NUM-APOLICE TO CBAPOVIG-NUM-APOLICE */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE);

            /*" -2370- MOVE PARCELAS-NUM-ENDOSSO TO CBAPOVIG-NUM-ENDOSSO */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO);

            /*" -2371- MOVE PARCELAS-NUM-PARCELA TO CBAPOVIG-NUM-PARCELA */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA);

            /*" -2372- MOVE SISTEMAS-DATA-MOV-ABERTO TO CBAPOVIG-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO);

            /*" -2373- MOVE PARCEHIS-DATA-VENCIMENTO TO CBAPOVIG-DATA-VENCIMENTO */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO);

            /*" -2374- MOVE WS-HOST-PRM-PAGO TO CBAPOVIG-PREMIO-TOTAL-PAGO */
            _.Move(WS_HOST_PRM_PAGO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_PAGO);

            /*" -2375- MOVE WS-HOST-PRM-DEVIDO TO CBAPOVIG-PREMIO-TOTAL-DEV */
            _.Move(WS_HOST_PRM_DEVIDO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_DEV);

            /*" -2377- MOVE PRAZOSEG-FIM-PRAZO TO CBAPOVIG-QTD-DIAS-COBERTOS */
            _.Move(PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_FIM_PRAZO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_QTD_DIAS_COBERTOS);

            /*" -2396- MOVE WS-HOST-DATA-FIM-VIG-PROP TO CBAPOVIG-DATA-FIM-VIG-PROP */
            _.Move(WS_HOST_DATA_FIM_VIG_PROP, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP);

            /*" -2397- IF ENDOSSOS-RAMO-EMISSOR = 67 OR 40 OR 45 OR 75 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.In("67", "40", "45", "75"))
            {

                /*" -2398- MOVE WS-HOST-DATA-VENCIMENTO TO CBAPOVIG-DATA-VENCIMENTO */
                _.Move(WS_HOST_DATA_VENCIMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO);

                /*" -2399- MOVE WS-HOST-DATA-NOVOCANCEL TO CBAPOVIG-DATA-CANCELAMENTO */
                _.Move(WS_HOST_DATA_NOVOCANCEL, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO);

                /*" -2400- ELSE */
            }
            else
            {


                /*" -2404- IF (APOLICES-ORGAO-EMISSOR = 100 OR 110) OR ( (APOLICES-ORGAO-EMISSOR = 10) AND (ENDOSSOS-RAMO-EMISSOR = 53) AND (ENDOSSOS-COD-PRODUTO = 5302 OR 5303 OR 5304) ) */

                if ((APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.In("100", "110")) || ((APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR == 10) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
                {

                    /*" -2406- MOVE WS-HOST-DATA-CANCELAMENTO TO CBAPOVIG-DATA-CANCELAMENTO */
                    _.Move(WS_HOST_DATA_CANCELAMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO);

                    /*" -2407- ELSE */
                }
                else
                {


                    /*" -2408- IF WS-HOST-DATA-CANCELAMENTO < WS-HOST-DATA-NOVOCANCEL */

                    if (WS_HOST_DATA_CANCELAMENTO < WS_HOST_DATA_NOVOCANCEL)
                    {

                        /*" -2410- MOVE WS-HOST-DATA-NOVOCANCEL TO CBAPOVIG-DATA-CANCELAMENTO */
                        _.Move(WS_HOST_DATA_NOVOCANCEL, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO);

                        /*" -2411- ELSE */
                    }
                    else
                    {


                        /*" -2413- MOVE WS-HOST-DATA-CANCELAMENTO TO CBAPOVIG-DATA-CANCELAMENTO */
                        _.Move(WS_HOST_DATA_CANCELAMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO);

                        /*" -2414- END-IF */
                    }


                    /*" -2415- END-IF */
                }


                /*" -2417- END-IF */
            }


            /*" -2423- MOVE 19 TO CBAPOVIG-IDTAB-SITUACAO */
            _.Move(19, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_IDTAB_SITUACAO);

            /*" -2424- MOVE '0' TO CBAPOVIG-SITUACAO */
            _.Move("0", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);

            /*" -2426- MOVE SPACES TO CBAPOVIG-DATA-MALA-VIG-PROP CBAPOVIG-DATA-MALA-CANCEL */
            _.Move("", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_VIG_PROP, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_CANCEL);

            /*" -2429- MOVE -1 TO VIND-DATA-MALA-VIG VIND-DATA-MALA-CANCEL */
            _.Move(-1, VIND_DATA_MALA_VIG, VIND_DATA_MALA_CANCEL);

            /*" -2430- IF WS-TEM-VIG-PROP = 'S' */

            if (AREA_DE_WORK.WS_TEM_VIG_PROP == "S")
            {

                /*" -2431- PERFORM R2100-00-UPDATE-VIG-PROP */

                R2100_00_UPDATE_VIG_PROP_SECTION();

                /*" -2432- ELSE */
            }
            else
            {


                /*" -2433- PERFORM R2000-00-INSERT-VIG-PROP */

                R2000_00_INSERT_VIG_PROP_SECTION();

                /*" -2433- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-CALCULA-DATAS-SECTION */
        private void R1600_00_CALCULA_DATAS_SECTION()
        {
            /*" -2442- MOVE 'R1600' TO WNR-EXEC-SQL. */
            _.Move("R1600", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1600_10_DATA_COBERTURA */

            R1600_10_DATA_COBERTURA();

        }

        [StopWatch]
        /*" R1600-10-DATA-COBERTURA */
        private void R1600_10_DATA_COBERTURA(bool isPerform = false)
        {
            /*" -2453- MOVE +0 TO WS-HOST-PRM-DEVIDO WS-HOST-PRM-PAGO */
            _.Move(+0, WS_HOST_PRM_DEVIDO, WS_HOST_PRM_PAGO);

            /*" -2454- MOVE 9999999999999 TO ENDOSSOS-NUM-APOLICE */
            _.Move(9999999999999, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -2455- MOVE 999999999 TO ENDOSSOS-NUM-ENDOSSO */
            _.Move(999999999, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -2457- MOVE SPACES TO WS-FIM-PARCEHIS */
            _.Move("", AREA_DE_WORK.WS_FIM_PARCEHIS);

            /*" -2459- PERFORM R1700-00-DECLARE-PARCEHIS */

            R1700_00_DECLARE_PARCEHIS_SECTION();

            /*" -2462- PERFORM R1710-00-FETCH-PARCEHIS UNTIL WS-FIM-PARCEHIS NOT = SPACES */

            while (!(!AREA_DE_WORK.WS_FIM_PARCEHIS.IsEmpty()))
            {

                R1710_00_FETCH_PARCEHIS_SECTION();
            }

            /*" -2469- COMPUTE WS-PCT-PRM-RETIDO ROUNDED = (WS-HOST-PRM-PAGO * 100) / WS-HOST-PRM-DEVIDO ON SIZE ERROR DISPLAY 'WS-PCT-PRM-RETIDO ERRO = ' WS-HOST-PRM-PAGO ' ' WS-HOST-PRM-DEVIDO MOVE +0 TO WS-PCT-PRM-RETIDO END-COMPUTE */
            if (WS_HOST_PRM_DEVIDO.Value == 0)
            {
                _.Display($"WS_PCT_PRM_RETIDO ERRO = {WS_HOST_PRM_PAGO}  {WS_HOST_PRM_DEVIDO}");
                _.Move(0, WS_PCT_PRM_RETIDO);
            }
            else

                WS_PCT_PRM_RETIDO.Value = (WS_HOST_PRM_PAGO * 100) / WS_HOST_PRM_DEVIDO;

            /*" -2471- MOVE WS-PCT-PRM-RETIDO TO PRAZOSEG-PCT-PRM-ANUAL */
            _.Move(WS_PCT_PRM_RETIDO, PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_PCT_PRM_ANUAL);

            /*" -2476- PERFORM R1800-00-SELECT-PRAZOSEG. */

            R1800_00_SELECT_PRAZOSEG_SECTION();

            /*" -2476- PERFORM R1600-30-DATA-CANC-PREVISTO. */

            R1600_30_DATA_CANC_PREVISTO(true);

        }

        [StopWatch]
        /*" R1600-30-DATA-CANC-PREVISTO */
        private void R1600_30_DATA_CANC_PREVISTO(bool isPerform = false)
        {
            /*" -2481- MOVE WS-HOST-DATA-FIM-VIG-PROP TO CALENDAR-DATA-CALENDARIO */
            _.Move(WS_HOST_DATA_FIM_VIG_PROP, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -2484- IF ( (APOLICES-ORGAO-EMISSOR = 10) AND (ENDOSSOS-RAMO-EMISSOR = 53) AND (ENDOSSOS-COD-PRODUTO = 5302 OR 5303 OR 5304) ) */

            if (((APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR == 10) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53) && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
            {

                /*" -2485- PERFORM R1850-00-CALC-DATA-CANCEL-SAS */

                R1850_00_CALC_DATA_CANCEL_SAS_SECTION();

                /*" -2486- ELSE */
            }
            else
            {


                /*" -2487- IF APOLICES-ORGAO-EMISSOR NOT = 110 */

                if (APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR != 110)
                {

                    /*" -2488- PERFORM R1820-00-CALC-DATA-CANCEL */

                    R1820_00_CALC_DATA_CANCEL_SECTION();

                    /*" -2489- ELSE */
                }
                else
                {


                    /*" -2490- PERFORM R1850-00-CALC-DATA-CANCEL-SAS */

                    R1850_00_CALC_DATA_CANCEL_SAS_SECTION();

                    /*" -2491- END-IF */
                }


                /*" -2491- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-DECLARE-PARCEHIS-SECTION */
        private void R1700_00_DECLARE_PARCEHIS_SECTION()
        {
            /*" -2503- MOVE 'R1700' TO WNR-EXEC-SQL. */
            _.Move("R1700", WABEND.WNR_EXEC_SQL);

            /*" -2504- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2507- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2519- PERFORM R1700_00_DECLARE_PARCEHIS_DB_DECLARE_1 */

            R1700_00_DECLARE_PARCEHIS_DB_DECLARE_1();

            /*" -2521- PERFORM R1700_00_DECLARE_PARCEHIS_DB_OPEN_1 */

            R1700_00_DECLARE_PARCEHIS_DB_OPEN_1();

            /*" -2525- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2526- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2527- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2528- ADD SFT TO STT(23) */
            TOTAIS_ROT.FILLER_5[23].STT.Value = TOTAIS_ROT.FILLER_5[23].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2531- ADD 1 TO SQT(23) */
            TOTAIS_ROT.FILLER_5[23].SQT.Value = TOTAIS_ROT.FILLER_5[23].SQT + 1;

            /*" -2532- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2533- DISPLAY 'R1700 - ERRO DECLARE PARCELA_HISTORICO' */
                _.Display($"R1700 - ERRO DECLARE PARCELA_HISTORICO");

                /*" -2534- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2534- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-DECLARE-PARCEHIS-DB-OPEN-1 */
        public void R1700_00_DECLARE_PARCEHIS_DB_OPEN_1()
        {
            /*" -2521- EXEC SQL OPEN C0PARCEHIS END-EXEC. */

            C0PARCEHIS.Open();

        }

        [StopWatch]
        /*" R1870-00-DECLARE-CALENDARIO-DB-DECLARE-1 */
        public void R1870_00_DECLARE_CALENDARIO_DB_DECLARE_1()
        {
            /*" -2881- EXEC SQL DECLARE C2CALENDARIO CURSOR FOR SELECT DATA_CALENDARIO ,DIA_SEMANA ,FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :CALENDAR-DATA-CALENDARIO ORDER BY DATA_CALENDARIO WITH UR END-EXEC. */
            C2CALENDARIO = new CB1260B_C2CALENDARIO(true);
            string GetQuery_C2CALENDARIO()
            {
                var query = @$"SELECT DATA_CALENDARIO 
							,DIA_SEMANA 
							,FERIADO 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO > '{CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}' 
							ORDER BY DATA_CALENDARIO";

                return query;
            }
            C2CALENDARIO.GetQueryEvent += GetQuery_C2CALENDARIO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1710-00-FETCH-PARCEHIS-SECTION */
        private void R1710_00_FETCH_PARCEHIS_SECTION()
        {
            /*" -2543- MOVE 'R1710' TO WNR-EXEC-SQL. */
            _.Move("R1710", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1710_10_FETCH_PARCEHIS */

            R1710_10_FETCH_PARCEHIS();

        }

        [StopWatch]
        /*" R1710-10-FETCH-PARCEHIS */
        private void R1710_10_FETCH_PARCEHIS(bool isPerform = false)
        {
            /*" -2549- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2552- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2560- PERFORM R1710_10_FETCH_PARCEHIS_DB_FETCH_1 */

            R1710_10_FETCH_PARCEHIS_DB_FETCH_1();

            /*" -2564- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2565- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2566- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2567- ADD SFT TO STT(24) */
            TOTAIS_ROT.FILLER_5[24].STT.Value = TOTAIS_ROT.FILLER_5[24].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2570- ADD 1 TO SQT(24) */
            TOTAIS_ROT.FILLER_5[24].SQT.Value = TOTAIS_ROT.FILLER_5[24].SQT + 1;

            /*" -2571- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2572- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2573- MOVE 'S' TO WS-FIM-PARCEHIS */
                    _.Move("S", AREA_DE_WORK.WS_FIM_PARCEHIS);

                    /*" -2573- PERFORM R1710_10_FETCH_PARCEHIS_DB_CLOSE_1 */

                    R1710_10_FETCH_PARCEHIS_DB_CLOSE_1();

                    /*" -2575- GO TO R1710-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/ //GOTO
                    return;

                    /*" -2576- ELSE */
                }
                else
                {


                    /*" -2577- DISPLAY 'R1710- ERRO FETCH PARCELA_HISTORICO' */
                    _.Display($"R1710- ERRO FETCH PARCELA_HISTORICO");

                    /*" -2578- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2579- END-IF */
                }


                /*" -2581- END-IF */
            }


            /*" -2582- IF PARCEHIS-DATA-MOVIMENTO > SISTEMAS-DATA-MOV-ABERTO */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO > SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -2583- GO TO R1710-10-FETCH-PARCEHIS */
                new Task(() => R1710_10_FETCH_PARCEHIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2585- END-IF */
            }


            /*" -2586- IF PARCEHIS-PRM-TOTAL = ZEROS */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL == 00)
            {

                /*" -2587- GO TO R1710-10-FETCH-PARCEHIS */
                new Task(() => R1710_10_FETCH_PARCEHIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2589- END-IF */
            }


            /*" -2591- MOVE PARCEHIS-COD-OPERACAO TO WS-COD-OPERACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO, AREA_DE_WORK.WS_COD_OPERACAO);

            /*" -2594- IF PARCEHIS-NUM-APOLICE = ENDOSSOS-NUM-APOLICE AND PARCEHIS-NUM-ENDOSSO = ENDOSSOS-NUM-ENDOSSO NEXT SENTENCE */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE == ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE && PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO == ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO)
            {

                /*" -2595- ELSE */
            }
            else
            {


                /*" -2596- MOVE PARCEHIS-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE */
                _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

                /*" -2597- MOVE PARCEHIS-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO */
                _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                /*" -2599- PERFORM R0950-00-SELECT-ENDOSSOS. */

                R0950_00_SELECT_ENDOSSOS_SECTION();
            }


            /*" -2600- IF WS-HOST-TIPO-ENDOSSO = '0' OR '1' */

            if (WS_HOST_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -2601- IF WS-FAIXA-OPERACAO = 01 OR 05 */

                if (AREA_DE_WORK.WS_COD_OPERACAO_R.WS_FAIXA_OPERACAO.In("01", "05"))
                {

                    /*" -2602- ADD PARCEHIS-PRM-TOTAL TO WS-HOST-PRM-DEVIDO */
                    WS_HOST_PRM_DEVIDO.Value = WS_HOST_PRM_DEVIDO + PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                    /*" -2603- ELSE */
                }
                else
                {


                    /*" -2604- IF WS-FAIXA-OPERACAO = 04 */

                    if (AREA_DE_WORK.WS_COD_OPERACAO_R.WS_FAIXA_OPERACAO == 04)
                    {

                        /*" -2605- SUBTRACT PARCEHIS-PRM-TOTAL FROM WS-HOST-PRM-DEVIDO */
                        WS_HOST_PRM_DEVIDO.Value = WS_HOST_PRM_DEVIDO - PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                        /*" -2606- ELSE */
                    }
                    else
                    {


                        /*" -2607- IF WS-FAIXA-OPERACAO = 02 */

                        if (AREA_DE_WORK.WS_COD_OPERACAO_R.WS_FAIXA_OPERACAO == 02)
                        {

                            /*" -2608- ADD PARCEHIS-PRM-TOTAL TO WS-HOST-PRM-PAGO */
                            WS_HOST_PRM_PAGO.Value = WS_HOST_PRM_PAGO + PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                            /*" -2609- ELSE */
                        }
                        else
                        {


                            /*" -2610- IF WS-FAIXA-OPERACAO = 03 */

                            if (AREA_DE_WORK.WS_COD_OPERACAO_R.WS_FAIXA_OPERACAO == 03)
                            {

                                /*" -2611- SUBTRACT PARCEHIS-PRM-TOTAL FROM WS-HOST-PRM-PAGO */
                                WS_HOST_PRM_PAGO.Value = WS_HOST_PRM_PAGO - PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                                /*" -2613- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -2614- ELSE */
                            }

                        }

                    }

                }

            }
            else
            {


                /*" -2615- IF WS-FAIXA-OPERACAO = 01 OR 05 */

                if (AREA_DE_WORK.WS_COD_OPERACAO_R.WS_FAIXA_OPERACAO.In("01", "05"))
                {

                    /*" -2616- SUBTRACT PARCEHIS-PRM-TOTAL FROM WS-HOST-PRM-DEVIDO */
                    WS_HOST_PRM_DEVIDO.Value = WS_HOST_PRM_DEVIDO - PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                    /*" -2617- ELSE */
                }
                else
                {


                    /*" -2618- IF WS-FAIXA-OPERACAO = 04 */

                    if (AREA_DE_WORK.WS_COD_OPERACAO_R.WS_FAIXA_OPERACAO == 04)
                    {

                        /*" -2619- ADD PARCEHIS-PRM-TOTAL TO WS-HOST-PRM-DEVIDO */
                        WS_HOST_PRM_DEVIDO.Value = WS_HOST_PRM_DEVIDO + PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                        /*" -2620- ELSE */
                    }
                    else
                    {


                        /*" -2621- IF WS-FAIXA-OPERACAO = 02 */

                        if (AREA_DE_WORK.WS_COD_OPERACAO_R.WS_FAIXA_OPERACAO == 02)
                        {

                            /*" -2622- SUBTRACT PARCEHIS-PRM-TOTAL FROM WS-HOST-PRM-PAGO */
                            WS_HOST_PRM_PAGO.Value = WS_HOST_PRM_PAGO - PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;

                            /*" -2623- ELSE */
                        }
                        else
                        {


                            /*" -2624- IF WS-FAIXA-OPERACAO = 03 */

                            if (AREA_DE_WORK.WS_COD_OPERACAO_R.WS_FAIXA_OPERACAO == 03)
                            {

                                /*" -2624- ADD PARCEHIS-PRM-TOTAL TO WS-HOST-PRM-PAGO. */
                                WS_HOST_PRM_PAGO.Value = WS_HOST_PRM_PAGO + PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL;
                            }

                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R1710-10-FETCH-PARCEHIS-DB-FETCH-1 */
        public void R1710_10_FETCH_PARCEHIS_DB_FETCH_1()
        {
            /*" -2560- EXEC SQL FETCH C0PARCEHIS INTO :PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-COD-OPERACAO ,:PARCEHIS-DATA-MOVIMENTO ,:PARCEHIS-PRM-TOTAL END-EXEC. */

            if (C0PARCEHIS.Fetch())
            {
                _.Move(C0PARCEHIS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C0PARCEHIS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C0PARCEHIS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(C0PARCEHIS.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(C0PARCEHIS.PARCEHIS_COD_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);
                _.Move(C0PARCEHIS.PARCEHIS_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);
                _.Move(C0PARCEHIS.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
            }

        }

        [StopWatch]
        /*" R1710-10-FETCH-PARCEHIS-DB-CLOSE-1 */
        public void R1710_10_FETCH_PARCEHIS_DB_CLOSE_1()
        {
            /*" -2573- EXEC SQL CLOSE C0PARCEHIS END-EXEC */

            C0PARCEHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-PRAZOSEG-SECTION */
        private void R1800_00_SELECT_PRAZOSEG_SECTION()
        {
            /*" -2636- MOVE 'R1800' TO WNR-EXEC-SQL. */
            _.Move("R1800", WABEND.WNR_EXEC_SQL);

            /*" -2637- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2640- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2647- PERFORM R1800_00_SELECT_PRAZOSEG_DB_SELECT_1 */

            R1800_00_SELECT_PRAZOSEG_DB_SELECT_1();

            /*" -2651- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2652- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2653- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2654- ADD SFT TO STT(25) */
            TOTAIS_ROT.FILLER_5[25].STT.Value = TOTAIS_ROT.FILLER_5[25].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2657- ADD 1 TO SQT(25) */
            TOTAIS_ROT.FILLER_5[25].SQT.Value = TOTAIS_ROT.FILLER_5[25].SQT + 1;

            /*" -2658- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2659- DISPLAY 'R1800- ERRO SELECT PRAZO_SEGURO' */
                _.Display($"R1800- ERRO SELECT PRAZO_SEGURO");

                /*" -2660- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2661- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -2662- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -2663- DISPLAY 'PCT_PRM_ANUAL = ' PRAZOSEG-PCT-PRM-ANUAL */
                _.Display($"PCT_PRM_ANUAL = {PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_PCT_PRM_ANUAL}");

                /*" -2664- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2666- END-IF */
            }


            /*" -2669- ADD 1 TO AC-L-PRAZOSEG. */
            AREA_DE_WORK.AC_L_PRAZOSEG.Value = AREA_DE_WORK.AC_L_PRAZOSEG + 1;

            /*" -2670- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2673- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2679- PERFORM R1800_00_SELECT_PRAZOSEG_DB_SELECT_2 */

            R1800_00_SELECT_PRAZOSEG_DB_SELECT_2();

            /*" -2683- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2684- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2685- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2686- ADD SFT TO STT(26) */
            TOTAIS_ROT.FILLER_5[26].STT.Value = TOTAIS_ROT.FILLER_5[26].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2689- ADD 1 TO SQT(26) */
            TOTAIS_ROT.FILLER_5[26].SQT.Value = TOTAIS_ROT.FILLER_5[26].SQT + 1;

            /*" -2690- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2691- DISPLAY 'R1800- ERRO SELECT CALENDARIO' */
                _.Display($"R1800- ERRO SELECT CALENDARIO");

                /*" -2692- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2693- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -2694- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -2695- DISPLAY 'DTINIVIG= ' WS-HOST-DTINIVIG-APOL */
                _.Display($"DTINIVIG= {WS_HOST_DTINIVIG_APOL}");

                /*" -2696- DISPLAY 'QTD_DIAS= ' PRAZOSEG-FIM-PRAZO */
                _.Display($"QTD_DIAS= {PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_FIM_PRAZO}");

                /*" -2697- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2699- END-IF */
            }


            /*" -2699- ADD 1 TO AC-L-CALENDARIO. */
            AREA_DE_WORK.AC_L_CALENDARIO.Value = AREA_DE_WORK.AC_L_CALENDARIO + 1;

        }

        [StopWatch]
        /*" R1800-00-SELECT-PRAZOSEG-DB-SELECT-1 */
        public void R1800_00_SELECT_PRAZOSEG_DB_SELECT_1()
        {
            /*" -2647- EXEC SQL SELECT VALUE(MIN(FIM_PRAZO),+0) INTO :PRAZOSEG-FIM-PRAZO FROM SEGUROS.PRAZO_SEGURO WHERE PCT_PRM_ANUAL >= :PRAZOSEG-PCT-PRM-ANUAL AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1 = new R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1()
            {
                PRAZOSEG_PCT_PRM_ANUAL = PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_PCT_PRM_ANUAL.ToString(),
            };

            var executed_1 = R1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_PRAZOSEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRAZOSEG_FIM_PRAZO, PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_FIM_PRAZO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-PRAZOSEG-DB-SELECT-2 */
        public void R1800_00_SELECT_PRAZOSEG_DB_SELECT_2()
        {
            /*" -2679- EXEC SQL SELECT (DATA_CALENDARIO + :PRAZOSEG-FIM-PRAZO DAYS) INTO :WS-HOST-DATA-FIM-VIG-PROP FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WS-HOST-DTINIVIG-APOL WITH UR END-EXEC. */

            var r1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1 = new R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1()
            {
                WS_HOST_DTINIVIG_APOL = WS_HOST_DTINIVIG_APOL.ToString(),
                PRAZOSEG_FIM_PRAZO = PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_FIM_PRAZO.ToString(),
            };

            var executed_1 = R1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1.Execute(r1800_00_SELECT_PRAZOSEG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_DATA_FIM_VIG_PROP, WS_HOST_DATA_FIM_VIG_PROP);
            }


        }

        [StopWatch]
        /*" R1820-00-CALC-DATA-CANCEL-SECTION */
        private void R1820_00_CALC_DATA_CANCEL_SECTION()
        {
            /*" -2710- MOVE 'R1820' TO WNR-EXEC-SQL. */
            _.Move("R1820", WABEND.WNR_EXEC_SQL);

            /*" -2716- PERFORM R1820_00_CALC_DATA_CANCEL_DB_SELECT_1 */

            R1820_00_CALC_DATA_CANCEL_DB_SELECT_1();

            /*" -2720- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2721- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2722- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2723- ADD SFT TO STT(27) */
            TOTAIS_ROT.FILLER_5[27].STT.Value = TOTAIS_ROT.FILLER_5[27].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2726- ADD 1 TO SQT(27) */
            TOTAIS_ROT.FILLER_5[27].SQT.Value = TOTAIS_ROT.FILLER_5[27].SQT + 1;

            /*" -2727- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2728- DISPLAY 'R1820- ERRO SELECT CALENDARIO' */
                _.Display($"R1820- ERRO SELECT CALENDARIO");

                /*" -2729- DISPLAY 'APOLICE = ' PARCELAS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2730- DISPLAY 'ENDOSSO = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -2731- DISPLAY 'PARCELA = ' PARCELAS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -2732- DISPLAY 'DATA    = ' CALENDAR-DATA-CALENDARIO */
                _.Display($"DATA    = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}");

                /*" -2733- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2735- END-IF */
            }


            /*" -2735- ADD 1 TO AC-L-CALENDARIO. */
            AREA_DE_WORK.AC_L_CALENDARIO.Value = AREA_DE_WORK.AC_L_CALENDARIO + 1;

        }

        [StopWatch]
        /*" R1820-00-CALC-DATA-CANCEL-DB-SELECT-1 */
        public void R1820_00_CALC_DATA_CANCEL_DB_SELECT_1()
        {
            /*" -2716- EXEC SQL SELECT (DATA_CALENDARIO + 15 DAYS) INTO :WS-HOST-DATA-CANCELAMENTO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO WITH UR END-EXEC. */

            var r1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1 = new R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1.Execute(r1820_00_CALC_DATA_CANCEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_DATA_CANCELAMENTO, WS_HOST_DATA_CANCELAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1820_99_SAIDA*/

        [StopWatch]
        /*" R1830-00-CALC-DATA-NOVOCANCEL-SECTION */
        private void R1830_00_CALC_DATA_NOVOCANCEL_SECTION()
        {
            /*" -2747- MOVE 'R1830' TO WNR-EXEC-SQL. */
            _.Move("R1830", WABEND.WNR_EXEC_SQL);

            /*" -2748- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2751- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2757- PERFORM R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1 */

            R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1();

            /*" -2761- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2762- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2763- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2764- ADD SFT TO STT(28) */
            TOTAIS_ROT.FILLER_5[28].STT.Value = TOTAIS_ROT.FILLER_5[28].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2767- ADD 1 TO SQT(28) */
            TOTAIS_ROT.FILLER_5[28].SQT.Value = TOTAIS_ROT.FILLER_5[28].SQT + 1;

            /*" -2768- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2769- DISPLAY 'R1830- ERRO SELECT CALENDARIO' */
                _.Display($"R1830- ERRO SELECT CALENDARIO");

                /*" -2770- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2772- END-IF */
            }


            /*" -2772- ADD 1 TO AC-L-CALENDARIO. */
            AREA_DE_WORK.AC_L_CALENDARIO.Value = AREA_DE_WORK.AC_L_CALENDARIO + 1;

        }

        [StopWatch]
        /*" R1830-00-CALC-DATA-NOVOCANCEL-DB-SELECT-1 */
        public void R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1()
        {
            /*" -2757- EXEC SQL SELECT (DATA_CALENDARIO + 07 DAYS) INTO :WS-HOST-DATA-NOVOCANCEL FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO WITH UR END-EXEC. */

            var r1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1 = new R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1.Execute(r1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_DATA_NOVOCANCEL, WS_HOST_DATA_NOVOCANCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1830_99_SAIDA*/

        [StopWatch]
        /*" R1850-00-CALC-DATA-CANCEL-SAS-SECTION */
        private void R1850_00_CALC_DATA_CANCEL_SAS_SECTION()
        {
            /*" -2787- MOVE 'R1850' TO WNR-EXEC-SQL */
            _.Move("R1850", WABEND.WNR_EXEC_SQL);

            /*" -2788- MOVE 5 TO WS-QTD-DIAS-UTEIS */
            _.Move(5, AREA_DE_WORK.WS_QTD_DIAS_UTEIS);

            /*" -2790- MOVE ZEROS TO WS-QTD-DIAS */
            _.Move(0, AREA_DE_WORK.WS_QTD_DIAS);

            /*" -2791- PERFORM R1870-00-DECLARE-CALENDARIO */

            R1870_00_DECLARE_CALENDARIO_SECTION();

            /*" -2793- PERFORM R1880-00-FETCH-CALENDARIO */

            R1880_00_FETCH_CALENDARIO_SECTION();

            /*" -2816- MOVE CALENDAR-DATA-CALENDARIO TO WS-DATA-CANCTO-FIMVIG */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WS_DATA_CANCTO_FIMVIG);

            /*" -2817- IF WS-DATA-CANCTO-FIMVIG > WS-HOST-DATA-MOV-20D */

            if (WS_DATA_CANCTO_FIMVIG > WS_HOST_DATA_MOV_20D)
            {

                /*" -2818- MOVE WS-DATA-CANCTO-FIMVIG TO WS-HOST-DATA-CANCELAMENTO */
                _.Move(WS_DATA_CANCTO_FIMVIG, WS_HOST_DATA_CANCELAMENTO);

                /*" -2819- ELSE */
            }
            else
            {


                /*" -2820- MOVE WS-HOST-DATA-MOV-20D TO WS-HOST-DATA-CANCELAMENTO */
                _.Move(WS_HOST_DATA_MOV_20D, WS_HOST_DATA_CANCELAMENTO);

                /*" -2820- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1850_99_SAIDA*/

        [StopWatch]
        /*" R1870-00-DECLARE-CALENDARIO-SECTION */
        private void R1870_00_DECLARE_CALENDARIO_SECTION()
        {
            /*" -2869- MOVE 'R1870' TO WNR-EXEC-SQL. */
            _.Move("R1870", WABEND.WNR_EXEC_SQL);

            /*" -2870- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2873- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2881- PERFORM R1870_00_DECLARE_CALENDARIO_DB_DECLARE_1 */

            R1870_00_DECLARE_CALENDARIO_DB_DECLARE_1();

            /*" -2883- PERFORM R1870_00_DECLARE_CALENDARIO_DB_OPEN_1 */

            R1870_00_DECLARE_CALENDARIO_DB_OPEN_1();

            /*" -2887- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2888- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2889- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2890- ADD SFT TO STT(30) */
            TOTAIS_ROT.FILLER_5[30].STT.Value = TOTAIS_ROT.FILLER_5[30].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2893- ADD 1 TO SQT(30) */
            TOTAIS_ROT.FILLER_5[30].SQT.Value = TOTAIS_ROT.FILLER_5[30].SQT + 1;

            /*" -2894- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2895- DISPLAY 'R3200 - ERRO DECLARE CALENDARIO' */
                _.Display($"R3200 - ERRO DECLARE CALENDARIO");

                /*" -2896- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2896- END-IF. */
            }


        }

        [StopWatch]
        /*" R1870-00-DECLARE-CALENDARIO-DB-OPEN-1 */
        public void R1870_00_DECLARE_CALENDARIO_DB_OPEN_1()
        {
            /*" -2883- EXEC SQL OPEN C2CALENDARIO END-EXEC. */

            C2CALENDARIO.Open();

        }

        [StopWatch]
        /*" R3200-00-DECLARE-CALENDARIO-DB-DECLARE-1 */
        public void R3200_00_DECLARE_CALENDARIO_DB_DECLARE_1()
        {
            /*" -3229- EXEC SQL DECLARE C0CALENDARIO CURSOR FOR SELECT DATA_CALENDARIO ,DIA_SEMANA ,FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :WS-DATA-MOV-ABERTO-CO ORDER BY DATA_CALENDARIO WITH UR END-EXEC. */
            C0CALENDARIO = new CB1260B_C0CALENDARIO(true);
            string GetQuery_C0CALENDARIO()
            {
                var query = @$"SELECT DATA_CALENDARIO 
							,DIA_SEMANA 
							,FERIADO 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO > '{WS_DATA_MOV_ABERTO_CO}' 
							ORDER BY DATA_CALENDARIO";

                return query;
            }
            C0CALENDARIO.GetQueryEvent += GetQuery_C0CALENDARIO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1870_99_SAIDA*/

        [StopWatch]
        /*" R1880-00-FETCH-CALENDARIO-SECTION */
        private void R1880_00_FETCH_CALENDARIO_SECTION()
        {
            /*" -2905- MOVE 'R1880' TO WNR-EXEC-SQL. */
            _.Move("R1880", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1880_10_FETCH_CALENDARIO */

            R1880_10_FETCH_CALENDARIO();

        }

        [StopWatch]
        /*" R1880-10-FETCH-CALENDARIO */
        private void R1880_10_FETCH_CALENDARIO(bool isPerform = false)
        {
            /*" -2911- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2914- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -2918- PERFORM R1880_10_FETCH_CALENDARIO_DB_FETCH_1 */

            R1880_10_FETCH_CALENDARIO_DB_FETCH_1();

            /*" -2922- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -2923- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -2924- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -2925- ADD SFT TO STT(31) */
            TOTAIS_ROT.FILLER_5[31].STT.Value = TOTAIS_ROT.FILLER_5[31].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -2928- ADD 1 TO SQT(31) */
            TOTAIS_ROT.FILLER_5[31].SQT.Value = TOTAIS_ROT.FILLER_5[31].SQT + 1;

            /*" -2929- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2930- DISPLAY 'R3210- ERRO FETCH CALENDARIO' */
                _.Display($"R3210- ERRO FETCH CALENDARIO");

                /*" -2931- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2933- END-IF */
            }


            /*" -2935- ADD 1 TO AC-L-CALENDARIO. */
            AREA_DE_WORK.AC_L_CALENDARIO.Value = AREA_DE_WORK.AC_L_CALENDARIO + 1;

            /*" -2936- IF CALENDAR-DIA-SEMANA = 'S' OR 'D' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA.In("S", "D"))
            {

                /*" -2937- GO TO R1880-10-FETCH-CALENDARIO */
                new Task(() => R1880_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2939- END-IF */
            }


            /*" -2940- IF CALENDAR-FERIADO = 'N' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
            {

                /*" -2941- GO TO R1880-10-FETCH-CALENDARIO */
                new Task(() => R1880_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2943- END-IF */
            }


            /*" -2945- ADD 1 TO WS-QTD-DIAS */
            AREA_DE_WORK.WS_QTD_DIAS.Value = AREA_DE_WORK.WS_QTD_DIAS + 1;

            /*" -2946- IF WS-QTD-DIAS = WS-QTD-DIAS-UTEIS */

            if (AREA_DE_WORK.WS_QTD_DIAS == AREA_DE_WORK.WS_QTD_DIAS_UTEIS)
            {

                /*" -2946- PERFORM R1880_10_FETCH_CALENDARIO_DB_CLOSE_1 */

                R1880_10_FETCH_CALENDARIO_DB_CLOSE_1();

                /*" -2948- ELSE */
            }
            else
            {


                /*" -2949- GO TO R1880-10-FETCH-CALENDARIO */
                new Task(() => R1880_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2949- END-IF. */
            }


        }

        [StopWatch]
        /*" R1880-10-FETCH-CALENDARIO-DB-FETCH-1 */
        public void R1880_10_FETCH_CALENDARIO_DB_FETCH_1()
        {
            /*" -2918- EXEC SQL FETCH C2CALENDARIO INTO :CALENDAR-DATA-CALENDARIO ,:CALENDAR-DIA-SEMANA ,:CALENDAR-FERIADO END-EXEC. */

            if (C2CALENDARIO.Fetch())
            {
                _.Move(C2CALENDARIO.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(C2CALENDARIO.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(C2CALENDARIO.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }

        }

        [StopWatch]
        /*" R1880-10-FETCH-CALENDARIO-DB-CLOSE-1 */
        public void R1880_10_FETCH_CALENDARIO_DB_CLOSE_1()
        {
            /*" -2946- EXEC SQL CLOSE C2CALENDARIO END-EXEC */

            C2CALENDARIO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1880_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-INSERT-VIG-PROP-SECTION */
        private void R2000_00_INSERT_VIG_PROP_SECTION()
        {
            /*" -2961- MOVE 'R2000' TO WNR-EXEC-SQL */
            _.Move("R2000", WABEND.WNR_EXEC_SQL);

            /*" -2962- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -2970- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -3005- PERFORM R2000_00_INSERT_VIG_PROP_DB_INSERT_1 */

            R2000_00_INSERT_VIG_PROP_DB_INSERT_1();

            /*" -3009- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -3010- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -3011- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -3012- ADD SFT TO STT(32) */
            TOTAIS_ROT.FILLER_5[32].STT.Value = TOTAIS_ROT.FILLER_5[32].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -3015- ADD 1 TO SQT(32) */
            TOTAIS_ROT.FILLER_5[32].SQT.Value = TOTAIS_ROT.FILLER_5[32].SQT + 1;

            /*" -3016- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3017- DISPLAY 'R2000 - ERRO INSERT CB_APOLICE_VIGPROP: ' */
                _.Display($"R2000 - ERRO INSERT CB_APOLICE_VIGPROP: ");

                /*" -3018- DISPLAY CBAPOVIG-NUM-APOLICE */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE);

                /*" -3019- DISPLAY CBAPOVIG-NUM-ENDOSSO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO);

                /*" -3020- DISPLAY CBAPOVIG-NUM-PARCELA */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA);

                /*" -3021- DISPLAY CBAPOVIG-DATA-MOVIMENTO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO);

                /*" -3022- DISPLAY CBAPOVIG-DATA-VENCIMENTO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO);

                /*" -3023- DISPLAY CBAPOVIG-PREMIO-TOTAL-PAGO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_PAGO);

                /*" -3024- DISPLAY CBAPOVIG-PREMIO-TOTAL-DEV */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_DEV);

                /*" -3025- DISPLAY CBAPOVIG-QTD-DIAS-COBERTOS */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_QTD_DIAS_COBERTOS);

                /*" -3026- DISPLAY CBAPOVIG-DATA-FIM-VIG-PROP */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP);

                /*" -3027- DISPLAY CBAPOVIG-DATA-CANCELAMENTO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO);

                /*" -3028- DISPLAY CBAPOVIG-IDTAB-SITUACAO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_IDTAB_SITUACAO);

                /*" -3029- DISPLAY CBAPOVIG-SITUACAO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);

                /*" -3031- DISPLAY CBAPOVIG-DATA-MALA-VIG-PROP ' ' VIND-DATA-MALA-VIG */

                $"{CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_VIG_PROP} {VIND_DATA_MALA_VIG}"
                .Display();

                /*" -3033- DISPLAY CBAPOVIG-DATA-MALA-CANCEL ' ' VIND-DATA-MALA-CANCEL */

                $"{CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_CANCEL} {VIND_DATA_MALA_CANCEL}"
                .Display();

                /*" -3034- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3036- END-IF */
            }


            /*" -3037- ADD 1 TO AC-I-CBAPOVIG WS-QT-REGISTRO-ATU. */
            AREA_DE_WORK.AC_I_CBAPOVIG.Value = AREA_DE_WORK.AC_I_CBAPOVIG + 1;
            WS_QT_REGISTRO_ATU.Value = WS_QT_REGISTRO_ATU + 1;

        }

        [StopWatch]
        /*" R2000-00-INSERT-VIG-PROP-DB-INSERT-1 */
        public void R2000_00_INSERT_VIG_PROP_DB_INSERT_1()
        {
            /*" -3005- EXEC SQL INSERT INTO SEGUROS.CB_APOLICE_VIGPROP ( NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DATA_MOVIMENTO ,DATA_VENCIMENTO ,PREMIO_TOTAL_PAGO ,PREMIO_TOTAL_DEV ,QTD_DIAS_COBERTOS ,DATA_FIM_VIG_PROP ,DATA_CANCELAMENTO ,IDTAB_SITUACAO ,SITUACAO ,TIMESTAMP ,DATA_MALA_VIG_PROP ,DATA_MALA_CANCEL ) VALUES (:CBAPOVIG-NUM-APOLICE ,:CBAPOVIG-NUM-ENDOSSO ,:CBAPOVIG-NUM-PARCELA ,:CBAPOVIG-DATA-MOVIMENTO ,:CBAPOVIG-DATA-VENCIMENTO ,:CBAPOVIG-PREMIO-TOTAL-PAGO ,:CBAPOVIG-PREMIO-TOTAL-DEV ,:CBAPOVIG-QTD-DIAS-COBERTOS ,:CBAPOVIG-DATA-FIM-VIG-PROP ,:CBAPOVIG-DATA-CANCELAMENTO ,:CBAPOVIG-IDTAB-SITUACAO ,:CBAPOVIG-SITUACAO , CURRENT TIMESTAMP ,:CBAPOVIG-DATA-MALA-VIG-PROP:VIND-DATA-MALA-VIG ,:CBAPOVIG-DATA-MALA-CANCEL:VIND-DATA-MALA-CANCEL ) END-EXEC. */

            var r2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1 = new R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1()
            {
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
                CBAPOVIG_NUM_ENDOSSO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO.ToString(),
                CBAPOVIG_NUM_PARCELA = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA.ToString(),
                CBAPOVIG_DATA_MOVIMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO.ToString(),
                CBAPOVIG_DATA_VENCIMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO.ToString(),
                CBAPOVIG_PREMIO_TOTAL_PAGO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_PAGO.ToString(),
                CBAPOVIG_PREMIO_TOTAL_DEV = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_DEV.ToString(),
                CBAPOVIG_QTD_DIAS_COBERTOS = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_QTD_DIAS_COBERTOS.ToString(),
                CBAPOVIG_DATA_FIM_VIG_PROP = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP.ToString(),
                CBAPOVIG_DATA_CANCELAMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO.ToString(),
                CBAPOVIG_IDTAB_SITUACAO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_IDTAB_SITUACAO.ToString(),
                CBAPOVIG_SITUACAO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO.ToString(),
                CBAPOVIG_DATA_MALA_VIG_PROP = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_VIG_PROP.ToString(),
                VIND_DATA_MALA_VIG = VIND_DATA_MALA_VIG.ToString(),
                CBAPOVIG_DATA_MALA_CANCEL = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_CANCEL.ToString(),
                VIND_DATA_MALA_CANCEL = VIND_DATA_MALA_CANCEL.ToString(),
            };

            R2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1.Execute(r2000_00_INSERT_VIG_PROP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-UPDATE-VIG-PROP-SECTION */
        private void R2100_00_UPDATE_VIG_PROP_SECTION()
        {
            /*" -3049- MOVE 'R2100' TO WNR-EXEC-SQL */
            _.Move("R2100", WABEND.WNR_EXEC_SQL);

            /*" -3050- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -3053- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -3072- PERFORM R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1 */

            R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1();

            /*" -3076- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -3077- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -3078- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -3079- ADD SFT TO STT(33) */
            TOTAIS_ROT.FILLER_5[33].STT.Value = TOTAIS_ROT.FILLER_5[33].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -3082- ADD 1 TO SQT(33) */
            TOTAIS_ROT.FILLER_5[33].SQT.Value = TOTAIS_ROT.FILLER_5[33].SQT + 1;

            /*" -3083- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3084- DISPLAY 'R2100- ERRO UPDATE CB_APOLICE_VIGPROP' */
                _.Display($"R2100- ERRO UPDATE CB_APOLICE_VIGPROP");

                /*" -3085- DISPLAY CBAPOVIG-NUM-APOLICE */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE);

                /*" -3086- DISPLAY CBAPOVIG-NUM-ENDOSSO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO);

                /*" -3087- DISPLAY CBAPOVIG-NUM-PARCELA */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA);

                /*" -3088- DISPLAY CBAPOVIG-DATA-MOVIMENTO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO);

                /*" -3089- DISPLAY CBAPOVIG-DATA-VENCIMENTO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO);

                /*" -3090- DISPLAY CBAPOVIG-PREMIO-TOTAL-PAGO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_PAGO);

                /*" -3091- DISPLAY CBAPOVIG-PREMIO-TOTAL-DEV */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_DEV);

                /*" -3092- DISPLAY CBAPOVIG-QTD-DIAS-COBERTOS */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_QTD_DIAS_COBERTOS);

                /*" -3093- DISPLAY CBAPOVIG-DATA-FIM-VIG-PROP */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP);

                /*" -3094- DISPLAY CBAPOVIG-DATA-CANCELAMENTO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO);

                /*" -3095- DISPLAY CBAPOVIG-IDTAB-SITUACAO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_IDTAB_SITUACAO);

                /*" -3096- DISPLAY CBAPOVIG-SITUACAO */
                _.Display(CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);

                /*" -3098- DISPLAY CBAPOVIG-DATA-MALA-VIG-PROP ' ' VIND-DATA-MALA-VIG */

                $"{CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_VIG_PROP} {VIND_DATA_MALA_VIG}"
                .Display();

                /*" -3100- DISPLAY CBAPOVIG-DATA-MALA-CANCEL ' ' VIND-DATA-MALA-CANCEL */

                $"{CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_CANCEL} {VIND_DATA_MALA_CANCEL}"
                .Display();

                /*" -3101- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3103- END-IF */
            }


            /*" -3103- ADD 1 TO AC-U-CBAPOVIG. */
            AREA_DE_WORK.AC_U_CBAPOVIG.Value = AREA_DE_WORK.AC_U_CBAPOVIG + 1;

        }

        [StopWatch]
        /*" R2100-00-UPDATE-VIG-PROP-DB-UPDATE-1 */
        public void R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1()
        {
            /*" -3072- EXEC SQL UPDATE SEGUROS.CB_APOLICE_VIGPROP SET NUM_ENDOSSO = :CBAPOVIG-NUM-ENDOSSO ,NUM_PARCELA = :CBAPOVIG-NUM-PARCELA ,DATA_MOVIMENTO = :CBAPOVIG-DATA-MOVIMENTO ,DATA_VENCIMENTO = :CBAPOVIG-DATA-VENCIMENTO ,PREMIO_TOTAL_PAGO = :CBAPOVIG-PREMIO-TOTAL-PAGO ,PREMIO_TOTAL_DEV = :CBAPOVIG-PREMIO-TOTAL-DEV ,QTD_DIAS_COBERTOS = :CBAPOVIG-QTD-DIAS-COBERTOS ,DATA_FIM_VIG_PROP = :CBAPOVIG-DATA-FIM-VIG-PROP ,DATA_CANCELAMENTO = :CBAPOVIG-DATA-CANCELAMENTO ,IDTAB_SITUACAO = :CBAPOVIG-IDTAB-SITUACAO ,SITUACAO = :CBAPOVIG-SITUACAO ,DATA_MALA_VIG_PROP = :CBAPOVIG-DATA-MALA-VIG-PROP :VIND-DATA-MALA-VIG ,DATA_MALA_CANCEL = :CBAPOVIG-DATA-MALA-CANCEL :VIND-DATA-MALA-CANCEL ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :CBAPOVIG-NUM-APOLICE END-EXEC */

            var r2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1 = new R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1()
            {
                CBAPOVIG_DATA_MALA_CANCEL = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_CANCEL.ToString(),
                VIND_DATA_MALA_CANCEL = VIND_DATA_MALA_CANCEL.ToString(),
                CBAPOVIG_DATA_MALA_VIG_PROP = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_VIG_PROP.ToString(),
                VIND_DATA_MALA_VIG = VIND_DATA_MALA_VIG.ToString(),
                CBAPOVIG_PREMIO_TOTAL_PAGO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_PAGO.ToString(),
                CBAPOVIG_QTD_DIAS_COBERTOS = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_QTD_DIAS_COBERTOS.ToString(),
                CBAPOVIG_DATA_FIM_VIG_PROP = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP.ToString(),
                CBAPOVIG_DATA_CANCELAMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO.ToString(),
                CBAPOVIG_PREMIO_TOTAL_DEV = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_DEV.ToString(),
                CBAPOVIG_DATA_VENCIMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO.ToString(),
                CBAPOVIG_DATA_MOVIMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO.ToString(),
                CBAPOVIG_IDTAB_SITUACAO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_IDTAB_SITUACAO.ToString(),
                CBAPOVIG_NUM_ENDOSSO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO.ToString(),
                CBAPOVIG_NUM_PARCELA = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA.ToString(),
                CBAPOVIG_SITUACAO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO.ToString(),
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
            };

            R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1.Execute(r2100_00_UPDATE_VIG_PROP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-MONTA-MALA-COBRANCA-SECTION */
        private void R3000_00_MONTA_MALA_COBRANCA_SECTION()
        {
            /*" -3141- MOVE 'R3000' TO WNR-EXEC-SQL */
            _.Move("R3000", WABEND.WNR_EXEC_SQL);

            /*" -3142- MOVE PARCELAS-NUM-APOLICE TO CBMALPAR-NUM-APOLICE */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_APOLICE);

            /*" -3143- MOVE PARCELAS-NUM-ENDOSSO TO CBMALPAR-NUM-ENDOSSO */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_ENDOSSO);

            /*" -3144- MOVE PARCELAS-NUM-PARCELA TO CBMALPAR-NUM-PARCELA */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_PARCELA);

            /*" -3145- MOVE SISTEMAS-DATA-MOV-ABERTO TO CBMALPAR-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO);

            /*" -3146- MOVE PARCEHIS-DATA-VENCIMENTO TO CBMALPAR-DATA-VENC-CONTR */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_VENC_CONTR);

            /*" -3147- MOVE 20 TO CBMALPAR-IDTAB-SITUACAO */
            _.Move(20, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_IDTAB_SITUACAO);

            /*" -3149- MOVE '0' TO CBMALPAR-SITUACAO */
            _.Move("0", CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO);

            /*" -3153- MOVE SPACES TO CBMALPAR-DATA-VENCIMENTO CBMALPAR-DATA-ENVIO CBMALPAR-DTA-VENCIMENTO-AR */
            _.Move("", CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_VENCIMENTO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_ENVIO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DTA_VENCIMENTO_AR);

            /*" -3159- MOVE ZEROS TO CBMALPAR-PREMIO-TOTAL CBMALPAR-VALOR-ACRESCIMO CBMALPAR-VALOR-TARIFA CBMALPAR-VALOR-VISTORIA CBMALPAR-NUM-TITULO */
            _.Move(0, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_PREMIO_TOTAL, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_ACRESCIMO, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_TARIFA, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_VISTORIA, CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_TITULO);

            /*" -3168- MOVE -1 TO VIND-NUM-TITULO VIND-DATA-VENCIMENTO VIND-DTA-VENCTO-AR VIND-PREMIO-TOTAL VIND-VALOR-ACRESCIMO VIND-VALOR-TARIFA VIND-VALOR-VISTORIA VIND-DATA-ENVIO */
            _.Move(-1, VIND_NUM_TITULO, VIND_DATA_VENCIMENTO, VIND_DTA_VENCTO_AR, VIND_PREMIO_TOTAL, VIND_VALOR_ACRESCIMO, VIND_VALOR_TARIFA, VIND_VALOR_VISTORIA, VIND_DATA_ENVIO);

            /*" -3168- PERFORM R3500-00-INSERT-CBMALPAR. */

            R3500_00_INSERT_CBMALPAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-CALC-NOVO-VENCTO-SECTION */
        private void R3100_00_CALC_NOVO_VENCTO_SECTION()
        {
            /*" -3179- MOVE 'R3100' TO WNR-EXEC-SQL */
            _.Move("R3100", WABEND.WNR_EXEC_SQL);

            /*" -3180- MOVE 10 TO WS-QTD-DIAS-UTEIS */
            _.Move(10, AREA_DE_WORK.WS_QTD_DIAS_UTEIS);

            /*" -3182- MOVE ZEROS TO WS-QTD-DIAS */
            _.Move(0, AREA_DE_WORK.WS_QTD_DIAS);

            /*" -3184- PERFORM R3200-00-DECLARE-CALENDARIO */

            R3200_00_DECLARE_CALENDARIO_SECTION();

            /*" -3187- PERFORM R3210-00-FETCH-CALENDARIO */

            R3210_00_FETCH_CALENDARIO_SECTION();

            /*" -3189- MOVE CALENDAR-DATA-CALENDARIO TO WS-DT-VENCIMENTO */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WS_DT_VENCIMENTO);

            /*" -3190- MOVE 7 TO WS-QTD-DIAS-UTEIS */
            _.Move(7, AREA_DE_WORK.WS_QTD_DIAS_UTEIS);

            /*" -3192- MOVE ZEROS TO WS-QTD-DIAS */
            _.Move(0, AREA_DE_WORK.WS_QTD_DIAS);

            /*" -3194- PERFORM R3200-00-DECLARE-CALENDARIO */

            R3200_00_DECLARE_CALENDARIO_SECTION();

            /*" -3196- PERFORM R3210-00-FETCH-CALENDARIO */

            R3210_00_FETCH_CALENDARIO_SECTION();

            /*" -3198- MOVE CALENDAR-DATA-CALENDARIO TO WS-DT-VENCIMENTO-AUTO */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WS_DT_VENCIMENTO_AUTO);

            /*" -3199- MOVE 20 TO WS-QTD-DIAS-UTEIS */
            _.Move(20, AREA_DE_WORK.WS_QTD_DIAS_UTEIS);

            /*" -3201- MOVE ZEROS TO WS-QTD-DIAS */
            _.Move(0, AREA_DE_WORK.WS_QTD_DIAS);

            /*" -3203- PERFORM R3200-00-DECLARE-CALENDARIO */

            R3200_00_DECLARE_CALENDARIO_SECTION();

            /*" -3205- PERFORM R3210-00-FETCH-CALENDARIO */

            R3210_00_FETCH_CALENDARIO_SECTION();

            /*" -3205- MOVE CALENDAR-DATA-CALENDARIO TO WS-HOST-DATA-MOV-20D. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WS_HOST_DATA_MOV_20D);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-DECLARE-CALENDARIO-SECTION */
        private void R3200_00_DECLARE_CALENDARIO_SECTION()
        {
            /*" -3217- MOVE 'R3200' TO WNR-EXEC-SQL. */
            _.Move("R3200", WABEND.WNR_EXEC_SQL);

            /*" -3218- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -3221- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -3229- PERFORM R3200_00_DECLARE_CALENDARIO_DB_DECLARE_1 */

            R3200_00_DECLARE_CALENDARIO_DB_DECLARE_1();

            /*" -3231- PERFORM R3200_00_DECLARE_CALENDARIO_DB_OPEN_1 */

            R3200_00_DECLARE_CALENDARIO_DB_OPEN_1();

            /*" -3235- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -3236- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -3237- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -3238- ADD SFT TO STT(34) */
            TOTAIS_ROT.FILLER_5[34].STT.Value = TOTAIS_ROT.FILLER_5[34].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -3241- ADD 1 TO SQT(34) */
            TOTAIS_ROT.FILLER_5[34].SQT.Value = TOTAIS_ROT.FILLER_5[34].SQT + 1;

            /*" -3242- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3243- DISPLAY 'R3200 - ERRO DECLARE CALENDARIO' */
                _.Display($"R3200 - ERRO DECLARE CALENDARIO");

                /*" -3244- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3244- END-IF. */
            }


        }

        [StopWatch]
        /*" R3200-00-DECLARE-CALENDARIO-DB-OPEN-1 */
        public void R3200_00_DECLARE_CALENDARIO_DB_OPEN_1()
        {
            /*" -3231- EXEC SQL OPEN C0CALENDARIO END-EXEC. */

            C0CALENDARIO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-CALENDARIO-SECTION */
        private void R3210_00_FETCH_CALENDARIO_SECTION()
        {
            /*" -3253- MOVE 'R3210' TO WNR-EXEC-SQL. */
            _.Move("R3210", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3210_10_FETCH_CALENDARIO */

            R3210_10_FETCH_CALENDARIO();

        }

        [StopWatch]
        /*" R3210-10-FETCH-CALENDARIO */
        private void R3210_10_FETCH_CALENDARIO(bool isPerform = false)
        {
            /*" -3259- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -3262- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -3266- PERFORM R3210_10_FETCH_CALENDARIO_DB_FETCH_1 */

            R3210_10_FETCH_CALENDARIO_DB_FETCH_1();

            /*" -3270- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -3271- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -3272- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -3273- ADD SFT TO STT(35) */
            TOTAIS_ROT.FILLER_5[35].STT.Value = TOTAIS_ROT.FILLER_5[35].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -3276- ADD 1 TO SQT(35) */
            TOTAIS_ROT.FILLER_5[35].SQT.Value = TOTAIS_ROT.FILLER_5[35].SQT + 1;

            /*" -3277- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3278- DISPLAY 'R3210- ERRO FETCH CALENDARIO' */
                _.Display($"R3210- ERRO FETCH CALENDARIO");

                /*" -3279- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3281- END-IF */
            }


            /*" -3283- ADD 1 TO AC-L-CALENDARIO. */
            AREA_DE_WORK.AC_L_CALENDARIO.Value = AREA_DE_WORK.AC_L_CALENDARIO + 1;

            /*" -3284- IF CALENDAR-DIA-SEMANA = 'S' OR 'D' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA.In("S", "D"))
            {

                /*" -3285- GO TO R3210-10-FETCH-CALENDARIO */
                new Task(() => R3210_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3287- END-IF */
            }


            /*" -3288- IF CALENDAR-FERIADO = 'N' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
            {

                /*" -3289- GO TO R3210-10-FETCH-CALENDARIO */
                new Task(() => R3210_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3291- END-IF */
            }


            /*" -3293- ADD 1 TO WS-QTD-DIAS */
            AREA_DE_WORK.WS_QTD_DIAS.Value = AREA_DE_WORK.WS_QTD_DIAS + 1;

            /*" -3294- IF WS-QTD-DIAS = WS-QTD-DIAS-UTEIS */

            if (AREA_DE_WORK.WS_QTD_DIAS == AREA_DE_WORK.WS_QTD_DIAS_UTEIS)
            {

                /*" -3294- PERFORM R3210_10_FETCH_CALENDARIO_DB_CLOSE_1 */

                R3210_10_FETCH_CALENDARIO_DB_CLOSE_1();

                /*" -3296- ELSE */
            }
            else
            {


                /*" -3297- GO TO R3210-10-FETCH-CALENDARIO */
                new Task(() => R3210_10_FETCH_CALENDARIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3297- END-IF. */
            }


        }

        [StopWatch]
        /*" R3210-10-FETCH-CALENDARIO-DB-FETCH-1 */
        public void R3210_10_FETCH_CALENDARIO_DB_FETCH_1()
        {
            /*" -3266- EXEC SQL FETCH C0CALENDARIO INTO :CALENDAR-DATA-CALENDARIO ,:CALENDAR-DIA-SEMANA ,:CALENDAR-FERIADO END-EXEC. */

            if (C0CALENDARIO.Fetch())
            {
                _.Move(C0CALENDARIO.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(C0CALENDARIO.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(C0CALENDARIO.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }

        }

        [StopWatch]
        /*" R3210-10-FETCH-CALENDARIO-DB-CLOSE-1 */
        public void R3210_10_FETCH_CALENDARIO_DB_CLOSE_1()
        {
            /*" -3294- EXEC SQL CLOSE C0CALENDARIO END-EXEC */

            C0CALENDARIO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERT-CBMALPAR-SECTION */
        private void R3500_00_INSERT_CBMALPAR_SECTION()
        {
            /*" -3309- MOVE 'R3500' TO WNR-EXEC-SQL. */
            _.Move("R3500", WABEND.WNR_EXEC_SQL);

            /*" -3310- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_INI);

            /*" -3313- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DCI / 100) */
            AREA_DE_WORK.WS_HORAS.SIT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.MI * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.SI + (AREA_DE_WORK.WS_HORAS.WS_HORA_INI_R.DCI / 100f);

            /*" -3350- PERFORM R3500_00_INSERT_CBMALPAR_DB_INSERT_1 */

            R3500_00_INSERT_CBMALPAR_DB_INSERT_1();

            /*" -3354- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORAS.WS_HORA_FIM);

            /*" -3355- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DCF / 100) */
            AREA_DE_WORK.WS_HORAS.SFT.Value = (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.MF * 60) + AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.SF + (AREA_DE_WORK.WS_HORAS.WS_HORA_FIM_R.DCF / 100f);

            /*" -3356- SUBTRACT SIT FROM SFT */
            AREA_DE_WORK.WS_HORAS.SFT.Value = AREA_DE_WORK.WS_HORAS.SFT - AREA_DE_WORK.WS_HORAS.SIT;

            /*" -3357- ADD SFT TO STT(36) */
            TOTAIS_ROT.FILLER_5[36].STT.Value = TOTAIS_ROT.FILLER_5[36].STT + AREA_DE_WORK.WS_HORAS.SFT;

            /*" -3360- ADD 1 TO SQT(36) */
            TOTAIS_ROT.FILLER_5[36].SQT.Value = TOTAIS_ROT.FILLER_5[36].SQT + 1;

            /*" -3361- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3362- DISPLAY 'R3500 - ERRO INSERT CB_MALA_PARCATRASO' */
                _.Display($"R3500 - ERRO INSERT CB_MALA_PARCATRASO");

                /*" -3363- DISPLAY CBMALPAR-NUM-APOLICE */
                _.Display(CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_APOLICE);

                /*" -3364- DISPLAY CBMALPAR-NUM-ENDOSSO */
                _.Display(CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_ENDOSSO);

                /*" -3365- DISPLAY CBMALPAR-NUM-PARCELA */
                _.Display(CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_PARCELA);

                /*" -3366- DISPLAY CBMALPAR-DATA-MOVIMENTO */
                _.Display(CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO);

                /*" -3367- DISPLAY CBMALPAR-DATA-VENC-CONTR */
                _.Display(CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_VENC_CONTR);

                /*" -3368- DISPLAY CBMALPAR-IDTAB-SITUACAO */
                _.Display(CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_IDTAB_SITUACAO);

                /*" -3369- DISPLAY CBMALPAR-SITUACAO */
                _.Display(CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO);

                /*" -3371- DISPLAY CBMALPAR-NUM-TITULO ' ' VIND-NUM-TITULO */

                $"{CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_TITULO} {VIND_NUM_TITULO}"
                .Display();

                /*" -3373- DISPLAY CBMALPAR-DATA-VENCIMENTO ' ' VIND-DATA-VENCIMENTO */

                $"{CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_VENCIMENTO} {VIND_DATA_VENCIMENTO}"
                .Display();

                /*" -3375- DISPLAY CBMALPAR-PREMIO-TOTAL ' ' VIND-PREMIO-TOTAL */

                $"{CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_PREMIO_TOTAL} {VIND_PREMIO_TOTAL}"
                .Display();

                /*" -3377- DISPLAY CBMALPAR-VALOR-ACRESCIMO ' ' VIND-VALOR-ACRESCIMO */

                $"{CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_ACRESCIMO} {VIND_VALOR_ACRESCIMO}"
                .Display();

                /*" -3379- DISPLAY CBMALPAR-VALOR-TARIFA ' ' VIND-VALOR-TARIFA */

                $"{CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_TARIFA} {VIND_VALOR_TARIFA}"
                .Display();

                /*" -3381- DISPLAY CBMALPAR-VALOR-VISTORIA ' ' VIND-VALOR-VISTORIA */

                $"{CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_VISTORIA} {VIND_VALOR_VISTORIA}"
                .Display();

                /*" -3383- DISPLAY CBMALPAR-DATA-ENVIO ' ' VIND-DATA-ENVIO */

                $"{CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_ENVIO} {VIND_DATA_ENVIO}"
                .Display();

                /*" -3384- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3386- END-IF */
            }


            /*" -3386- ADD 1 TO AC-I-CBMALPAR. */
            AREA_DE_WORK.AC_I_CBMALPAR.Value = AREA_DE_WORK.AC_I_CBMALPAR + 1;

        }

        [StopWatch]
        /*" R3500-00-INSERT-CBMALPAR-DB-INSERT-1 */
        public void R3500_00_INSERT_CBMALPAR_DB_INSERT_1()
        {
            /*" -3350- EXEC SQL INSERT INTO SEGUROS.CB_MALA_PARCATRASO ( NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DATA_MOVIMENTO ,DATA_VENC_CONTR ,IDTAB_SITUACAO ,SITUACAO ,NUM_TITULO ,DATA_VENCIMENTO ,PREMIO_TOTAL ,VALOR_ACRESCIMO ,VALOR_TARIFA ,VALOR_VISTORIA ,DATA_ENVIO ,TIMESTAMP ,DTA_VENCIMENTO_AR ) VALUES (:CBMALPAR-NUM-APOLICE ,:CBMALPAR-NUM-ENDOSSO ,:CBMALPAR-NUM-PARCELA ,:CBMALPAR-DATA-MOVIMENTO ,:CBMALPAR-DATA-VENC-CONTR ,:CBMALPAR-IDTAB-SITUACAO ,:CBMALPAR-SITUACAO ,:CBMALPAR-NUM-TITULO:VIND-NUM-TITULO ,:CBMALPAR-DATA-VENCIMENTO:VIND-DATA-VENCIMENTO ,:CBMALPAR-PREMIO-TOTAL:VIND-PREMIO-TOTAL ,:CBMALPAR-VALOR-ACRESCIMO:VIND-VALOR-ACRESCIMO ,:CBMALPAR-VALOR-TARIFA:VIND-VALOR-TARIFA ,:CBMALPAR-VALOR-VISTORIA:VIND-VALOR-VISTORIA ,:CBMALPAR-DATA-ENVIO:VIND-DATA-ENVIO , CURRENT TIMESTAMP ,:CBMALPAR-DTA-VENCIMENTO-AR:VIND-DTA-VENCTO-AR ) END-EXEC. */

            var r3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1 = new R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1()
            {
                CBMALPAR_NUM_APOLICE = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_APOLICE.ToString(),
                CBMALPAR_NUM_ENDOSSO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_ENDOSSO.ToString(),
                CBMALPAR_NUM_PARCELA = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_PARCELA.ToString(),
                CBMALPAR_DATA_MOVIMENTO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO.ToString(),
                CBMALPAR_DATA_VENC_CONTR = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_VENC_CONTR.ToString(),
                CBMALPAR_IDTAB_SITUACAO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_IDTAB_SITUACAO.ToString(),
                CBMALPAR_SITUACAO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_SITUACAO.ToString(),
                CBMALPAR_NUM_TITULO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_NUM_TITULO.ToString(),
                VIND_NUM_TITULO = VIND_NUM_TITULO.ToString(),
                CBMALPAR_DATA_VENCIMENTO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_VENCIMENTO.ToString(),
                VIND_DATA_VENCIMENTO = VIND_DATA_VENCIMENTO.ToString(),
                CBMALPAR_PREMIO_TOTAL = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_PREMIO_TOTAL.ToString(),
                VIND_PREMIO_TOTAL = VIND_PREMIO_TOTAL.ToString(),
                CBMALPAR_VALOR_ACRESCIMO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_ACRESCIMO.ToString(),
                VIND_VALOR_ACRESCIMO = VIND_VALOR_ACRESCIMO.ToString(),
                CBMALPAR_VALOR_TARIFA = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_TARIFA.ToString(),
                VIND_VALOR_TARIFA = VIND_VALOR_TARIFA.ToString(),
                CBMALPAR_VALOR_VISTORIA = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_VALOR_VISTORIA.ToString(),
                VIND_VALOR_VISTORIA = VIND_VALOR_VISTORIA.ToString(),
                CBMALPAR_DATA_ENVIO = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_ENVIO.ToString(),
                VIND_DATA_ENVIO = VIND_DATA_ENVIO.ToString(),
                CBMALPAR_DTA_VENCIMENTO_AR = CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DTA_VENCIMENTO_AR.ToString(),
                VIND_DTA_VENCTO_AR = VIND_DTA_VENCTO_AR.ToString(),
            };

            R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1.Execute(r3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3397- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -3399- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -3399- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -3401- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3405- PERFORM R0010-00-MOSTRA-TOTAIS. */

            R0010_00_MOSTRA_TOTAIS_SECTION();

            /*" -3407- CLOSE CB1260B1 */
            CB1260B1.Close();

            /*" -3409- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3409- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}