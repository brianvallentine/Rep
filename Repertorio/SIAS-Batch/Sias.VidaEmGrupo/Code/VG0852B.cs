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
using Sias.VidaEmGrupo.DB2.VG0852B;

namespace Code
{
    public class VG0852B
    {
        public bool IsCall { get; set; }

        public VG0852B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL EMPRESA GLOBAL/MULTIPREM   *      */
        /*"      *   PROGRAMA ...............  VG0852B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  ALESSANDRO G. RAMOS                       */
        /*"      *   PROGRAMADOR ............  ALESSANDRO G. RAMOS                *      */
        /*"      *   DATA CODIFICACAO .......  03/06/2011                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CANCELAMENTO DE APOLICE ESPECIFICA,*      */
        /*"      *                             EMPRESARIAL E GLOBAL               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 22 - DEMANDA 461637 TAREFA                              *      */
        /*"      *           - AJUSTAR SELECT PARA POR AVALIAR LOW VALUES         *      */
        /*"      *                                                                *      */
        /*"      * EM 26/12/2023 - HUSNI ALI HUSNI            PROCURE POR  V.22   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 21 - JAZZ 391703                                        *      */
        /*"      *                                                                *      */
        /*"      *             DESABILITAR ALTERACOES DA V.20 E NAO PERMITIR O    *      */
        /*"      *             CANCELAMENTO DOS CERTIFICADOS ABAIXO QUE ESTAO EM  *      */
        /*"      *             PROCESSO DE REABILITACAO POR CANCELAMENTO INDEVIDO *      */
        /*"      *             E REGULARIZACAO DE COBRANCA.                       *      */
        /*"      *                                                                *      */
        /*"      *             CERTIFICADOS   CLIENTE                             *      */
        /*"      *             -------------- ----------------------------------- *      */
        /*"      *             95662665984    PREMIUS EBENEZER SERVICOS EIRELI    *      */
        /*"      *             95662680630    PREMIUS EBENEZER SERVICOS EIRELI    *      */
        /*"      *                                                                *      */
        /*"      * EM 19/05/2022 - BRICEHO                    PROCURE POR  V.21   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 20 - JAZZ 334120                                        *      */
        /*"      *                                                                *      */
        /*"      *             DESABILITAR ALTERACOES DA V.19 E NAO PERMITIR O    *      */
        /*"      *             CANCELAMENTO DO CERTIFICADO ABAIXO QUE ESTA EM     *      */
        /*"      *             PROCESSO DE REABILITACAO POR CANCELAMENTO INDEVIDO.*      */
        /*"      *                                                                *      */
        /*"      *             CERTIFICADO    CLIENTE                             *      */
        /*"      *             -------------- ----------------------------------- *      */
        /*"      *             11611160000010 A C R DE JESUS                      *      */
        /*"      *                                                                *      */
        /*"      * EM 12/11/2021 - BRICEHO                    PROCURE POR  V.20   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 19 - JAZZ 311683/318136                                 *      */
        /*"      *                                                                *      */
        /*"      *             DESABILITAR ALTERACOES DA V.18 E                   *      */
        /*"      *             NAO PERMITIR CANCELAMENTO DOS CERTIFICADOS ABAIXO  *      */
        /*"      *             QUE ESTAO EM PROCESSO DE REGULARIZACAO DE COBRANCA *      */
        /*"      *             POR TEREM MAIS DE 2 PARCELAS PENDENTES.            *      */
        /*"      *                                                                *      */
        /*"      *             CONDICAO TEMPORARIA: DEVE SER RETIRADA APOS        *      */
        /*"      *             REGULARIZACAO DOS CERTIFICADOS.                    *      */
        /*"      *                                                                *      */
        /*"      *             CERTIFICADO CLIENTE                                *      */
        /*"      *             ----------- -------------------------------------  *      */
        /*"      *             95630655240 DEISE BENAIR ORTHMANN DA ROSA ANGILO   *      */
        /*"      *             95630644418 AMH CHOCOLATES LTDA.                   *      */
        /*"      *             95630633980 JELLY VALERIA ARAUJO SILVEIRA DA SILVA *      */
        /*"      *             95322229363 SOCIEDADE DOS AMIGOS DA MATA DA PRAIA  *      */
        /*"      *                                                                *      */
        /*"      * EM 30/09/2021 - BRICEHO                    PROCURE POR  V.19   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 18 - JAZZ 281542                                        *      */
        /*"      *                                                                *      */
        /*"      *             NAO PERMITIR CANCELAMENTO DOS CERTIFICADOS ABAIXO  *      */
        /*"      *             QUE ESTAO EM PROCESSO DE REGULARIZACAO DE COBRANCA *      */
        /*"      *             POR TEREM MAIS DE 2 PARCELAS PENDENTES.            *      */
        /*"      *                                                                *      */
        /*"      *             CONDICAO TEMPORARIA: DEVE SER RETIRADA APOS        *      */
        /*"      *             REGULARIZACAO DOS CERTIFICADOS.                    *      */
        /*"      *                                                                *      */
        /*"      *             CERTIFICADO CLIENTE                                *      */
        /*"      *             ----------- -------------------------------------  *      */
        /*"      *             95528555509 DIVISA DIVINOPOLIS VEICULOS LTDA       *      */
        /*"      *             95409284366 A.G. SIMOES IND.COM. & IMPORTACAO      *      */
        /*"      *             95544116956 REALPET COMERCIO ATACADISTA            *      */
        /*"      *             95366237230 TECON TECNOLOGIA EM CONSTRUCOES LTDA   *      */
        /*"      *             95593376605 ENGCLARIAN IND. E COMERCIO             *      */
        /*"      *                                                                *      */
        /*"      * EM 19/03/2021 - BRICEHO                    PROCURE POR  V.18   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 17 - JAZZ 192339                                        *      */
        /*"      *                                                                *      */
        /*"      *           SIAS - COBRANCA NAO REALIZADA APOS RENOVACAO         *      */
        /*"      *                  NAO CANCELAR MODALIDADE DE COBRANCA (1)       *      */
        /*"      *                  DEBITO EM CONTA CORRENTE                      *      */
        /*"      *                                                                *      */
        /*"      * EM 23/01/2019 - CANETTA                    PROCURE POR  V.17   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.16  * VERSAO 16 - DEM 181547                                         *      */
        /*"      *                                                                *      */
        /*"      *           SIAS - CORRECAO CANCELAMENTO DE SEGURADOS            *      */
        /*"      *                - ACESSO APOLICE COBERTURA (MODALIDADE = 10)    *      */
        /*"      *                                                                *      */
        /*"      * EM 23/01/2019 - CANETTA                                        *      */
        /*"      *                                            PROCURE POR  V.16   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.15  * VERSAO 15 - CAD 27.322                                         *      */
        /*"      *                                                                *      */
        /*"      *           SIAS - SINISTRO - FALHA NO CADASTRAMENTO DO SINISTRO.*      */
        /*"      *                                                                *      */
        /*"      * EM 11/05/2018 - MARCUS                                         *      */
        /*"      *                                            PROCURE POR  V.15   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.14  * VERSAO 14 - CAD 142.173                                        *      */
        /*"      *                                                                *      */
        /*"      *           AO CANCELAR APOLICE ESPECIFICA COM TIPO DE FATURAMEN-*      */
        /*"      *           TO POR APOLICE, CANCELAR TODOS OS SUBGRUPOS E TODOS  *      */
        /*"      *           OS CERTIFICADOS RELACIONADOS A APOLICE.              *      */
        /*"      *                                                                *      */
        /*"      * EM 26/04/2017 - FRANK CARVALHO                                 *      */
        /*"      *                                            PROCURE POR  V.14   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  * VERSAO 13 - CAD 128.293                                        *      */
        /*"      *                                                                *      */
        /*"      *           CORRECAO CERTIFICADOS EMPRESARIAL E GLOBAL - BOLETO  *      */
        /*"      *           ANUAIS                                               *      */
        /*"      *                                                                *      */
        /*"      * EM 22/02/2015 - MIRIAM HECK                                    *      */
        /*"      *                                            PROCURE POR  V.13   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  * VERSAO 12 - CAD 128.293                                        *      */
        /*"      *                                                                *      */
        /*"      *           CANCELAR CERTIFICADOS EMPRESARIAL E GLOBAL - BOLETO  *      */
        /*"      *           APOS 3 PARCELAS EM ATRASO ACUMULADAS                 *      */
        /*"      *                                                                *      */
        /*"      * EM 01/02/2015 - MIRIAM HECK                                    *      */
        /*"      *                                            PROCURE POR  V.12   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11 - CAD 102.406                                        *      */
        /*"      *                                                                *      */
        /*"      *           CANCELAR CERTIFICADOS EMPRESARIAL E GLOBAL QUE ERAM  *      */
        /*"      *           ANTERIORMENTE CANCELADOS PELO VA0851B                *      */
        /*"      *                                                                *      */
        /*"      * EM 07/11/2014 - ELIERMES OLIVEIRA                              *      */
        /*"      *                                            PROCURE POR  V.11   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10 - CAD 96.675                                         *      */
        /*"      *                                                                *      */
        /*"      *           CANCELAR PARCELA QUE ESTEJA EM DUPLICIDADE NA        *      */
        /*"      *           COBER_HIST_VIDAZUL                                   *      */
        /*"      *                                                                *      */
        /*"      * EM 11/04/2014 - ELIERMES OLIVEIRA (GESIN)                      *      */
        /*"      *                                            PROCURE POR  V.10   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 09 - CAD 94.717                                         *      */
        /*"      *                                                                *      */
        /*"      *           CANCELAR PARCELAS GERADAS COM SITUACAO 5 (IMP)       *      */
        /*"      *                                                                *      */
        /*"      * EM 21/03/2014 - ELIERMES OLIVEIRA (GESIN)                      *      */
        /*"      *                                            PROCURE POR  V.09   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 08             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       26/12/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - ABEND                                            *      */
        /*"      *   OCORR�NCIA DE FALHA N�91916 - VIDA AZUL - DISTRIBUI��O ATENDI*      */
        /*"      *   MENTO                                                               */
        /*"      *   RETIRAR DO CURSOR PRONCIPAL A APOLICE 109300000635(PRESTAMISTA      */
        /*"      *   VIDA DISEF                                                          */
        /*"      *                                                                *      */
        /*"      *   EM 23/12/2013 -  ALEXANDRE ANDRE                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.07      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05  - CAD 83.969                                      *      */
        /*"      *                                                                *      */
        /*"      *              CORRECAO DE CANCELAMENTO DE SUBGRUPO, PGM ESTAVA  *      */
        /*"      *              CANCELANDO SEMPRE O SUBGRUPO ZERO                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/06/2013 - ELIERMES OLIVEIRA (GESIN)                    *      */
        /*"      *                                            PROCURE POR  V.05   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04  - CAD 83.969                                      *      */
        /*"      *                                                                *      */
        /*"      *              RETIRADA DA APOLICE 109300002554 DO CURSOR,       *      */
        /*"      *              PARA NAO CANCELAMENTO DO MESMO                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/06/2013 - ELIERMES OLIVEIRA (GESIN)                    *      */
        /*"      *                                            PROCURE POR  V.04   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03  - CAD 82.541                                      *      */
        /*"      *                                                                *      */
        /*"      *              CORRECAO DE ABEND NO ACESSO A TABELA              *      */
        /*"      *              SEGUROS.COBER_HIST_VIDAZUL                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/05/2013 - EDIVALDO GOMES  (FAST COMPUTER)              *      */
        /*"      *                                            PROCURE POR  V.03   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02  - CAD 76.202                                      *      */
        /*"      *                                                                *      */
        /*"      *                CORRECAO DO CANCELAMENTO AUTOMATICO - APOLICES  *      */
        /*"      *              ESPECIFICAS.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/12/2012 - CLAUDIO FREITAS (FAST COMPUTER)              *      */
        /*"      *                                            PROCURE POR  V.02   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01  - CAD 67.949                                      *      */
        /*"      *                                                                *      */
        /*"      *                CORRECAO DO CANCELAMENTO AUTOMATICO - APOLICES  *      */
        /*"      *              ESPECIFICAS. PASSA A CONSIDERAR PARCELAS VENCIDAS *      */
        /*"      *              A MAIS DE 15 DIAS UTEIS E NAO MAIS A 5 DIAS UTEIS.*      */
        /*"      *              CORRIGE TAMBEM O CANCELAMENTO DE APOLICES COM PAR *      */
        /*"      *              CELAS A VENCER. (3 PARCELAS CONSECUTIVAS PARA O   *      */
        /*"      *              MENSAL E 1 PARCELA PARA OS DEMAIS)                *      */
        /*"      *   EM 09/04/2012 - LUIZ MARQUES -(FAST COMPUTER)                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 00  - CAD 52.223                                      *      */
        /*"      *                                                                *      */
        /*"      *                CANCELAMENTO AUTOM�TICO DO SEGURO DE APOLICE    *      */
        /*"      *              ESPECIFICA AP�S 3 PARCELAS COM STATUS DE PENDENTE *      */
        /*"      *   EM 03/06/2011 - ALESSANDRO G. RAMOS - FAST COMPUTER          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PROPOSTAS VA                        V0PROPOSTAVA      INPUT    *      */
        /*"      * COBERTURAS PROPOSTA VA              V0COBERPROPVA     INPUT    *      */
        /*"      * PARCELAS VA                         V0PARCELVA        I-O      *      */
        /*"      * HISTORICO DEBITO CONTA VA           V0HISTCONTAVA     OUTPUT   *      */
        /*"      * HISTORICO COBRANCA VA               V0HISTCOBVA       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _STSASSE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis STSASSE
        {
            get
            {
                _.Move(REG_STSASSE, _STSASSE); VarBasis.RedefinePassValue(REG_STSASSE, _STSASSE, REG_STSASSE); return _STSASSE;
            }
        }
        /*"01   REG-STSASSE              PIC X(100).*/
        public StringBasis REG_STSASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 R165-HEADER-SASSE.*/
        public VG0852B_R165_HEADER_SASSE R165_HEADER_SASSE { get; set; } = new VG0852B_R165_HEADER_SASSE();
        public class VG0852B_R165_HEADER_SASSE : VarBasis
        {
            /*"   03 R165-H-IDENT                 PIC X(001).*/
            public StringBasis R165_H_IDENT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   03 R165-H-NOME-ARQ              PIC X(008).*/
            public StringBasis R165_H_NOME_ARQ { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   03 R165-H-DT-GERACAO            PIC 9(008).*/
            public IntBasis R165_H_DT_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-H-SIS-GERACAO           PIC 9(001).*/
            public IntBasis R165_H_SIS_GERACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   03 R165-H-SIS-DESTINO           PIC 9(001).*/
            public IntBasis R165_H_SIS_DESTINO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   03 R165-H-SEQUENCIAL            PIC 9(006).*/
            public IntBasis R165_H_SEQUENCIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   03 FILLER                       PIC X(075).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)."), @"");
            /*"01 R165-TIPO1-SASSE.*/
        }
        public VG0852B_R165_TIPO1_SASSE R165_TIPO1_SASSE { get; set; } = new VG0852B_R165_TIPO1_SASSE();
        public class VG0852B_R165_TIPO1_SASSE : VarBasis
        {
            /*"   03 R165-T1-IDENT                PIC X(001).*/
            public StringBasis R165_T1_IDENT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   03 R165-T1-PROPOSTA             PIC 9(013).*/
            public IntBasis R165_T1_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"   03 R165-T1-DV-PROPOSTA          PIC 9(001).*/
            public IntBasis R165_T1_DV_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   03 R165-T1-SIT-PROP             PIC X(003).*/
            public StringBasis R165_T1_SIT_PROP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"   03 R165-T1-SIT-COB              PIC X(003).*/
            public StringBasis R165_T1_SIT_COB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"   03 R165-T1-TP-MOTIVO            PIC 9(003).*/
            public IntBasis R165_T1_TP_MOTIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   03 R165-T1-DT-INI-SIT           PIC 9(008).*/
            public IntBasis R165_T1_DT_INI_SIT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 FILLER                       PIC X(046).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"   03 R165-T1-SEQ-ARQ              PIC 9(006).*/
            public IntBasis R165_T1_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   03 R165-T1-SEQ-REG              PIC 9(006).*/
            public IntBasis R165_T1_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   03 R165-T1-USO-RESERV           PIC X(010).*/
            public StringBasis R165_T1_USO_RESERV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01 R165-TRAILLER-SASSE-N.*/
        }
        public VG0852B_R165_TRAILLER_SASSE_N R165_TRAILLER_SASSE_N { get; set; } = new VG0852B_R165_TRAILLER_SASSE_N();
        public class VG0852B_R165_TRAILLER_SASSE_N : VarBasis
        {
            /*"   03 R165-TN-IDENT                PIC X(001).*/
            public StringBasis R165_TN_IDENT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   03 R165-TN-NOME-ARQ             PIC X(008).*/
            public StringBasis R165_TN_NOME_ARQ { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   03 R165-TN-QTD-TIPO1            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO2            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO3            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO4            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO5            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO6            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO7            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO8            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO9            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TIPO0            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TIPO0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 R165-TN-QTD-TOTAL            PIC 9(008).*/
            public IntBasis R165_TN_QTD_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 FILLER                       PIC X(003).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"77 WFIM-CSEGURA           PIC X(001).*/
        }
        public StringBasis WFIM_CSEGURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77 WHOST-COUNT-PEN        PIC S9(009) COMP VALUE +0.*/
        public IntBasis WHOST_COUNT_PEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77 VIND-DATA-REF          PIC S9(4)   COMP.*/
        public IntBasis VIND_DATA_REF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77 CONT-PROPOSTAS-VA      PIC 9(9)         VALUE ZEROS.*/
        public IntBasis CONT_PROPOSTAS_VA { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"77 CONT-SUBGRUPOS         PIC 9(9)         VALUE ZEROS.*/
        public IntBasis CONT_SUBGRUPOS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"77 CONT-MOVIMENTO         PIC 9(9)         VALUE ZEROS.*/
        public IntBasis CONT_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"77 CONT-ENDOSSOS          PIC 9(9)         VALUE ZEROS.*/
        public IntBasis CONT_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"77 CONT-3-PARCE           PIC 9(9)         VALUE ZEROS.*/
        public IntBasis CONT_3_PARCE { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"77 CONT-INS-MOV-VGAP      PIC 9(9)         VALUE ZEROS.*/
        public IntBasis CONT_INS_MOV_VGAP { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"77 CONT-ENDOSSO           PIC 9(9)         VALUE ZEROS.*/
        public IntBasis CONT_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"77 WS-QT-CANC-EMPR        PIC 9(9)         VALUE ZEROS.*/
        public IntBasis WS_QT_CANC_EMPR { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
        /*"77 WHOST-SUBGRUPO         PIC S9(009) COMP VALUE +0.*/
        public IntBasis WHOST_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77 WHOST-NUM-PARCELA      PIC S9(004) COMP VALUE +0.*/
        public IntBasis WHOST_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WHOST-NUM-PARCELA-I    PIC S9(004) COMP VALUE +0.*/
        public IntBasis WHOST_NUM_PARCELA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WHOST-NUM-PARCELA-F    PIC S9(004) COMP VALUE +0.*/
        public IntBasis WHOST_NUM_PARCELA_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 V0COBA-IMPMORACID      PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77 V0COBA-IMPINVPERM      PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77 V0COBA-IMPDIT          PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77 V0COBA-PRMAP           PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77 W-NSAS                 PIC 9(010).*/
        public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
        /*"77 WS-TEM-PARCELA         PIC X(003)       VALUE 'NAO'.*/
        public StringBasis WS_TEM_PARCELA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77 WS-FATURA-POR-APOLICE  PIC X(001)       VALUE 'N'.*/
        public StringBasis WS_FATURA_POR_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77 V1SIST-DTVENFIM-VE  PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_VE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77 V1SIST-DTVENFIM-CN  PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_CN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77 WS-DT-REL           PIC  X(010).*/
        public StringBasis WS_DT_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01 WS-DT-INV.*/
        public VG0852B_WS_DT_INV WS_DT_INV { get; set; } = new VG0852B_WS_DT_INV();
        public class VG0852B_WS_DT_INV : VarBasis
        {
            /*"   02 WS-DIA-INV       PIC  X(002).*/
            public StringBasis WS_DIA_INV { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   02 WS-BARRA1-INV    PIC  X(001).*/
            public StringBasis WS_BARRA1_INV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   02 WS-MES-INV       PIC  X(002).*/
            public StringBasis WS_MES_INV { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   02 WS-BARRA2-INV    PIC  X(001).*/
            public StringBasis WS_BARRA2_INV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   02 WS-ANO-INV       PIC  X(004).*/
            public StringBasis WS_ANO_INV { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"01 WS-DT-FOR.*/
        }
        public VG0852B_WS_DT_FOR WS_DT_FOR { get; set; } = new VG0852B_WS_DT_FOR();
        public class VG0852B_WS_DT_FOR : VarBasis
        {
            /*"   02 WS-DIA-FOR       PIC  X(002).*/
            public StringBasis WS_DIA_FOR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   02 WS-BARRA1-FOR    PIC  X(001).*/
            public StringBasis WS_BARRA1_FOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   02 WS-MES-FOR       PIC  X(002).*/
            public StringBasis WS_MES_FOR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   02 WS-BARRA2-FOR    PIC  X(001).*/
            public StringBasis WS_BARRA2_FOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   02 WS-ANO-FOR       PIC  X(004).*/
            public StringBasis WS_ANO_FOR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"01 W-NUMR-TITULO       PIC  9(013)   VALUE ZEROS.*/
        }
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01 FILLER              REDEFINES     W-NUMR-TITULO.*/
        private _REDEF_VG0852B_FILLER_3 _filler_3 { get; set; }
        public _REDEF_VG0852B_FILLER_3 FILLER_3
        {
            get { _filler_3 = new _REDEF_VG0852B_FILLER_3(); _.Move(W_NUMR_TITULO, _filler_3); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_3, W_NUMR_TITULO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_NUMR_TITULO); }; return _filler_3; }
            set { VarBasis.RedefinePassValue(value, _filler_3, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VG0852B_FILLER_3 : VarBasis
        {
            /*"  05 WTITL-ZEROS       PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05 WTITL-SEQUENCIA   PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05 WTITL-DIGITO      PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01   WS-ARRAY.*/

            public _REDEF_VG0852B_FILLER_3()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VG0852B_WS_ARRAY WS_ARRAY { get; set; } = new VG0852B_WS_ARRAY();
        public class VG0852B_WS_ARRAY : VarBasis
        {
            /*"  05 WS-ARRAY-OCC      OCCURS 6 TIMES.*/
            public ListBasis<VG0852B_WS_ARRAY_OCC> WS_ARRAY_OCC { get; set; } = new ListBasis<VG0852B_WS_ARRAY_OCC>(6);
            public class VG0852B_WS_ARRAY_OCC : VarBasis
            {
                /*"  10 WS-SMALLINT       PIC  9(006) VALUE ZEROS.*/
                public IntBasis WS_SMALLINT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"01 AREA-DE-WORK.*/
            }
            public VG0852B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0852B_AREA_DE_WORK();
            public class VG0852B_AREA_DE_WORK : VarBasis
            {
                /*"  05 AC-C-V0ENDOSSO    PIC  9(007)    VALUE ZEROS.*/
                public IntBasis AC_C_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
                /*"  05 AC-C-V0PARCELAS   PIC  9(007)    VALUE ZEROS.*/
                public IntBasis AC_C_V0PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
                /*"  05 AC-C-V0PARCHIST   PIC  9(007)    VALUE ZEROS.*/
                public IntBasis AC_C_V0PARCHIST { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
                /*"  05 WFIM-PARCELA      PIC X(001)    VALUE SPACES.*/
                public StringBasis WFIM_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  05 W-SIT-BRANCO      PIC X(001)    VALUE SPACES.*/
                public StringBasis W_SIT_BRANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  05 W-SIT-ZEROS       PIC X(001)    VALUE '0'.*/
                public StringBasis W_SIT_ZEROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"  05 W-SIT-VARIAVEL    PIC X(001)    VALUE SPACES.*/
                public StringBasis W_SIT_VARIAVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  05 WFIM-CHISTCB      PIC X(001)  VALUE SPACES.*/
                public StringBasis WFIM_CHISTCB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  05 WTEM-ERRO         PIC X(001)  VALUE SPACES.*/
                public StringBasis WTEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  05 WDATA-CORRENTE    PIC X(010).*/
                public StringBasis WDATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05 WDATA-MINVEN.*/
                public VG0852B_WDATA_MINVEN WDATA_MINVEN { get; set; } = new VG0852B_WDATA_MINVEN();
                public class VG0852B_WDATA_MINVEN : VarBasis
                {
                    /*"    10 WDATA-SAVEN     PIC 9(004).*/
                    public IntBasis WDATA_SAVEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10 WDATA-SAVEN-R   REDEFINES  WDATA-SAVEN.*/
                    private _REDEF_VG0852B_WDATA_SAVEN_R _wdata_saven_r { get; set; }
                    public _REDEF_VG0852B_WDATA_SAVEN_R WDATA_SAVEN_R
                    {
                        get { _wdata_saven_r = new _REDEF_VG0852B_WDATA_SAVEN_R(); _.Move(WDATA_SAVEN, _wdata_saven_r); VarBasis.RedefinePassValue(WDATA_SAVEN, _wdata_saven_r, WDATA_SAVEN); _wdata_saven_r.ValueChanged += () => { _.Move(_wdata_saven_r, WDATA_SAVEN); }; return _wdata_saven_r; }
                        set { VarBasis.RedefinePassValue(value, _wdata_saven_r, WDATA_SAVEN); }
                    }  //Redefines
                    public class _REDEF_VG0852B_WDATA_SAVEN_R : VarBasis
                    {
                        /*"      15 WDATA-AAVEN   PIC 9(004).*/
                        public IntBasis WDATA_AAVEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"    10 WDATA-T1VEN     PIC X(001).*/

                        public _REDEF_VG0852B_WDATA_SAVEN_R()
                        {
                            WDATA_AAVEN.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis WDATA_T1VEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10 WDATA-MMVEN     PIC 9(002).*/
                    public IntBasis WDATA_MMVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10 WDATA-T2VEN     PIC X(001).*/
                    public StringBasis WDATA_T2VEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10 WDATA-DDVEN     PIC 9(002).*/
                    public IntBasis WDATA_DDVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05 PARM-PROSOMU1.*/
                }
                public VG0852B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VG0852B_PARM_PROSOMU1();
                public class VG0852B_PARM_PROSOMU1 : VarBasis
                {
                    /*"    10 SU1-DATA1.*/
                    public VG0852B_SU1_DATA1 SU1_DATA1 { get; set; } = new VG0852B_SU1_DATA1();
                    public class VG0852B_SU1_DATA1 : VarBasis
                    {
                        /*"      15 SU1-DD1       PIC 99.*/
                        public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                        /*"      15 SU1-MM1       PIC 99.*/
                        public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                        /*"      15 SU1-AA1       PIC 9999.*/
                        public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                        /*"    10 SU1-NRDIAS      PIC S9(5)  COMP-3.*/
                    }
                    public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                    /*"    10   SU1-DATA2.*/
                    public VG0852B_SU1_DATA2 SU1_DATA2 { get; set; } = new VG0852B_SU1_DATA2();
                    public class VG0852B_SU1_DATA2 : VarBasis
                    {
                        /*"      15 SU1-DD2       PIC 99.*/
                        public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                        /*"      15 SU1-MM2       PIC 99.*/
                        public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                        /*"      15 SU1-AA2       PIC 9999.*/
                        public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                        /*"  05 NRCERTIF-ANT      PIC  9(015) VALUE ZEROES.*/
                    }
                }
                public IntBasis NRCERTIF_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"  05 WDATA-MINATR.*/
                public VG0852B_WDATA_MINATR WDATA_MINATR { get; set; } = new VG0852B_WDATA_MINATR();
                public class VG0852B_WDATA_MINATR : VarBasis
                {
                    /*"    10 WDATA-SAATR     PIC 9(004).*/
                    public IntBasis WDATA_SAATR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10 WDATA-SAATR-R   REDEFINES   WDATA-SAATR.*/
                    private _REDEF_VG0852B_WDATA_SAATR_R _wdata_saatr_r { get; set; }
                    public _REDEF_VG0852B_WDATA_SAATR_R WDATA_SAATR_R
                    {
                        get { _wdata_saatr_r = new _REDEF_VG0852B_WDATA_SAATR_R(); _.Move(WDATA_SAATR, _wdata_saatr_r); VarBasis.RedefinePassValue(WDATA_SAATR, _wdata_saatr_r, WDATA_SAATR); _wdata_saatr_r.ValueChanged += () => { _.Move(_wdata_saatr_r, WDATA_SAATR); }; return _wdata_saatr_r; }
                        set { VarBasis.RedefinePassValue(value, _wdata_saatr_r, WDATA_SAATR); }
                    }  //Redefines
                    public class _REDEF_VG0852B_WDATA_SAATR_R : VarBasis
                    {
                        /*"      15 WDATA-AAATR   PIC 9(004).*/
                        public IntBasis WDATA_AAATR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"    10 WDATA-T1ATR     PIC X(001).*/

                        public _REDEF_VG0852B_WDATA_SAATR_R()
                        {
                            WDATA_AAATR.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis WDATA_T1ATR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10 WDATA-MMATR     PIC 9(002).*/
                    public IntBasis WDATA_MMATR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10 WDATA-T2ATR     PIC X(001).*/
                    public StringBasis WDATA_T2ATR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10 WDATA-DDATR     PIC 9(002).*/
                    public IntBasis WDATA_DDATR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05 WIND-DATA         PIC 9(002).*/
                }
                public IntBasis WIND_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05 WTAB-DATAS-UTEIS.*/
                public VG0852B_WTAB_DATAS_UTEIS WTAB_DATAS_UTEIS { get; set; } = new VG0852B_WTAB_DATAS_UTEIS();
                public class VG0852B_WTAB_DATAS_UTEIS : VarBasis
                {
                    /*"    10 WTAB-DATATR     OCCURS 30         PIC X(010).*/
                    public ListBasis<StringBasis, string> WTAB_DATATR { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "10", "X(010)."), 30);
                    /*"  05 WACC-LIDOS        PIC 9(006)       VALUE  ZEROS.*/
                }
                public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05 WACC-CANCELADOS   PIC 9(006)       VALUE  ZEROS.*/
                public IntBasis WACC_CANCELADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05 WACC-CANC-SIGPF   PIC 9(006)       VALUE  ZEROS.*/
                public IntBasis WACC_CANC_SIGPF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05 WACC-SIVPF        PIC 9(006)       VALUE  ZEROS.*/
                public IntBasis WACC_SIVPF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05 WACC-STASASSE     PIC 9(006)       VALUE  ZEROS.*/
                public IntBasis WACC_STASASSE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05 WACC-LIDO2        PIC 9(006)       VALUE  ZEROS.*/
                public IntBasis WACC_LIDO2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05 WACC-GRAVADOS     PIC 9(006)       VALUE  ZEROS.*/
                public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05 WACC-SOL-CANC     PIC 9(006)       VALUE  ZEROS.*/
                public IntBasis WACC_SOL_CANC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05 QTD-CANCEL        PIC 9(002)       VALUE  ZEROS.*/
                public IntBasis QTD_CANCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05 WACC-COMMIT       PIC 9(004)       VALUE  ZEROS.*/
                public IntBasis WACC_COMMIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05 WABEND.*/
                public VG0852B_WABEND WABEND { get; set; } = new VG0852B_WABEND();
                public class VG0852B_WABEND : VarBasis
                {
                    /*"    10 FILLER          PIC  X(008) VALUE  'VG0852B '.*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0852B ");
                    /*"    10 FILLER          PIC  X(025) VALUE                       '*** ERRO EXEC SQL NUMERO '.*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                    /*"    10 WNR-EXEC-SQL    PIC  X(004) VALUE  '0001'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                    /*"    10 FILLER          PIC  X(013) VALUE  ' *** SQLCODE '.*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                    /*"    10 WSQLCODE        PIC ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                }
            }
        }


        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public Dclgens.CONTACOR CONTACOR { get; set; } = new Dclgens.CONTACOR();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.HISPROFI HISPROFI { get; set; } = new Dclgens.HISPROFI();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public VG0852B_CHISTCB CHISTCB { get; set; } = new VG0852B_CHISTCB();
        public VG0852B_CONT_PEN CONT_PEN { get; set; } = new VG0852B_CONT_PEN();
        public VG0852B_CSEGURA CSEGURA { get; set; } = new VG0852B_CSEGURA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string STSASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                STSASSE.SetFile(STSASSE_FILE_NAME_P);

                /*" -482- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -485- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -488- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -488- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -495- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -496- DISPLAY '* ------------------------------- *' */
            _.Display($"* ------------------------------- *");

            /*" -497- DISPLAY '*  PROGRAMA EM EXECUCAO VG0852B   *' */
            _.Display($"*  PROGRAMA EM EXECUCAO VG0852B   *");

            /*" -498- DISPLAY '* ------------------------------- *' */
            _.Display($"* ------------------------------- *");

            /*" -499- DISPLAY '*                                 * ' */
            _.Display($"*                                 * ");

            /*" -500- DISPLAY '* VERSAO V.21 391.703 19/05/2022  * ' */
            _.Display($"* VERSAO V.21 391.703 19/05/2022  * ");

            /*" -501- DISPLAY '  COMPILACAO: ' FUNCTION WHEN-COMPILED */

            $"  COMPILACAO: FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -502- DISPLAY '*                                 * ' */
            _.Display($"*                                 * ");

            /*" -504- DISPLAY '* ------------------------------- * ' */
            _.Display($"* ------------------------------- * ");

            /*" -506- PERFORM R100-00-PROCESSA-DATA. */

            R100_00_PROCESSA_DATA_SECTION();

            /*" -508- PERFORM R700-000-LER-V1PARAMRAMO. */

            R700_000_LER_V1PARAMRAMO_SECTION();

            /*" -510- PERFORM R900-00-DECLARE-CURSOR-CHISTCB. */

            R900_00_DECLARE_CURSOR_CHISTCB_SECTION();

            /*" -512- PERFORM R300-00-ABRIR-ARQUIVO. */

            R300_00_ABRIR_ARQUIVO_SECTION();

            /*" -514- PERFORM R0910-00-FETCH-CHISTCB. */

            R0910_00_FETCH_CHISTCB_SECTION();

            /*" -515- IF WFIM-CHISTCB NOT EQUAL SPACES */

            if (!WS_ARRAY.AREA_DE_WORK.WFIM_CHISTCB.IsEmpty())
            {

                /*" -517- DISPLAY '* *** VG0852B *** NENHUMA PARCELA A PROCESSAR' */
                _.Display($"* *** VG0852B *** NENHUMA PARCELA A PROCESSAR");

                /*" -520- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -521- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CHISTCB NOT EQUAL SPACES. */

            while (!(!WS_ARRAY.AREA_DE_WORK.WFIM_CHISTCB.IsEmpty()))
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
            /*" -527- PERFORM R0010-00-FECHA-ARQUIVO. */

            R0010_00_FECHA_ARQUIVO_SECTION();

            /*" -528- DISPLAY '* LIDOS CHISTCB .............. ' WACC-LIDOS . */
            _.Display($"* LIDOS CHISTCB .............. {WS_ARRAY.AREA_DE_WORK.WACC_LIDOS}");

            /*" -529- DISPLAY '* CANCELADOS ................. ' WACC-CANCELADOS. */
            _.Display($"* CANCELADOS ................. {WS_ARRAY.AREA_DE_WORK.WACC_CANCELADOS}");

            /*" -530- DISPLAY '* CANCELADOS NO SIVPF  ....... ' WACC-CANC-SIGPF. */
            _.Display($"* CANCELADOS NO SIVPF  ....... {WS_ARRAY.AREA_DE_WORK.WACC_CANC_SIGPF}");

            /*" -532- DISPLAY '* CERTIF. EMPRE/GLOBAL CANCEL. ' WS-QT-CANC-EMPR */
            _.Display($"* CERTIF. EMPRE/GLOBAL CANCEL. {WS_QT_CANC_EMPR}");

            /*" -533- IF WTEM-ERRO EQUAL SPACES */

            if (WS_ARRAY.AREA_DE_WORK.WTEM_ERRO.IsEmpty())
            {

                /*" -533- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -535- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -536- DISPLAY '* ' */
                _.Display($"* ");

                /*" -537- DISPLAY '* -------  VG0852B - FIM NORMAL  -------- *' */
                _.Display($"* -------  VG0852B - FIM NORMAL  -------- *");

                /*" -538- ELSE */
            }
            else
            {


                /*" -538- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -540- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -541- DISPLAY '* ' */
                _.Display($"* ");

                /*" -542- DISPLAY '* -------  VG0852B - FIM ANORMAL -------- *' */
                _.Display($"* -------  VG0852B - FIM ANORMAL -------- *");

                /*" -543- END-IF. */
            }


            /*" -543- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-FECHA-ARQUIVO-SECTION */
        private void R0010_00_FECHA_ARQUIVO_SECTION()
        {
            /*" -555- MOVE 'R001' TO WNR-EXEC-SQL. */
            _.Move("R001", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -556- MOVE WACC-SIVPF TO ARQSIVPF-QTDE-REG-GER */
            _.Move(WS_ARRAY.AREA_DE_WORK.WACC_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -557- COMPUTE WACC-STASASSE = WACC-SIVPF + 2 */
            WS_ARRAY.AREA_DE_WORK.WACC_STASASSE.Value = WS_ARRAY.AREA_DE_WORK.WACC_SIVPF + 2;

            /*" -559- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -565- PERFORM R0010_00_FECHA_ARQUIVO_DB_UPDATE_1 */

            R0010_00_FECHA_ARQUIVO_DB_UPDATE_1();

            /*" -568- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -569- DISPLAY 'VG0852B - FIM ANORMAL' */
                _.Display($"VG0852B - FIM ANORMAL");

                /*" -570- DISPLAY 'ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -571- DISPLAY 'SIGLA DO ARQIVO.... ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"SIGLA DO ARQIVO.... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -572- DISPLAY 'NSAS SIVPF......... ' ARQSIVPF-NSAS-SIVPF */
                _.Display($"NSAS SIVPF......... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -573- DISPLAY 'DATA GERACAO....... ' ARQSIVPF-DATA-GERACAO */
                _.Display($"DATA GERACAO....... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -574- DISPLAY 'QTDE. REGISTROS.... ' ARQSIVPF-QTDE-REG-GER */
                _.Display($"QTDE. REGISTROS.... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -575- DISPLAY 'SQLCODE............ ' SQLCODE */
                _.Display($"SQLCODE............ {DB.SQLCODE}");

                /*" -576- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -578- END-IF. */
            }


            /*" -579- MOVE 'T' TO R165-TN-IDENT */
            _.Move("T", R165_TRAILLER_SASSE_N.R165_TN_IDENT);

            /*" -580- MOVE 'STASASSE' TO R165-TN-NOME-ARQ */
            _.Move("STASASSE", R165_TRAILLER_SASSE_N.R165_TN_NOME_ARQ);

            /*" -581- MOVE WACC-SIVPF TO R165-TN-QTD-TIPO1 */
            _.Move(WS_ARRAY.AREA_DE_WORK.WACC_SIVPF, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO1);

            /*" -582- MOVE ZEROS TO R165-TN-QTD-TIPO2 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO2);

            /*" -583- MOVE ZEROS TO R165-TN-QTD-TIPO3 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO3);

            /*" -584- MOVE ZEROS TO R165-TN-QTD-TIPO4 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO4);

            /*" -585- MOVE ZEROS TO R165-TN-QTD-TIPO5 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO5);

            /*" -586- MOVE ZEROS TO R165-TN-QTD-TIPO6 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO6);

            /*" -587- MOVE ZEROS TO R165-TN-QTD-TIPO7 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO7);

            /*" -588- MOVE ZEROS TO R165-TN-QTD-TIPO8 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO8);

            /*" -589- MOVE ZEROS TO R165-TN-QTD-TIPO9 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO9);

            /*" -590- MOVE ZEROS TO R165-TN-QTD-TIPO0 */
            _.Move(0, R165_TRAILLER_SASSE_N.R165_TN_QTD_TIPO0);

            /*" -592- MOVE WACC-STASASSE TO R165-TN-QTD-TOTAL */
            _.Move(WS_ARRAY.AREA_DE_WORK.WACC_STASASSE, R165_TRAILLER_SASSE_N.R165_TN_QTD_TOTAL);

            /*" -594- WRITE REG-STSASSE FROM R165-TRAILLER-SASSE-N */
            _.Move(R165_TRAILLER_SASSE_N.GetMoveValues(), REG_STSASSE);

            STSASSE.Write(REG_STSASSE.GetMoveValues().ToString());

            /*" -594- CLOSE STSASSE. */
            STSASSE.Close();

        }

        [StopWatch]
        /*" R0010-00-FECHA-ARQUIVO-DB-UPDATE-1 */
        public void R0010_00_FECHA_ARQUIVO_DB_UPDATE_1()
        {
            /*" -565- EXEC SQL UPDATE SEGUROS.ARQUIVOS_SIVPF SET QTDE_REG_GER = :ARQSIVPF-QTDE-REG-GER WHERE SIGLA_ARQUIVO = 'STASASSE' AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM AND NSAS_SIVPF = :ARQSIVPF-NSAS-SIVPF END-EXEC. */

            var r0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1 = new R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1()
            {
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
            };

            R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1.Execute(r0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R100-00-PROCESSA-DATA-SECTION */
        private void R100_00_PROCESSA_DATA_SECTION()
        {
            /*" -609- MOVE 'R010' TO WNR-EXEC-SQL. */
            _.Move("R010", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -620- PERFORM R100_00_PROCESSA_DATA_DB_SELECT_1 */

            R100_00_PROCESSA_DATA_DB_SELECT_1();

            /*" -624- MOVE V1SIST-DTVENFIM-VE TO WS-DT-REL */
            _.Move(V1SIST_DTVENFIM_VE, WS_DT_REL);

            /*" -625- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -626- DISPLAY 'ERRO SELECT V1SISTEMA VA' */
                _.Display($"ERRO SELECT V1SISTEMA VA");

                /*" -627- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -628- END-IF. */
            }


            /*" -629- MOVE V1SIST-DTVENFIM-VE TO WDATA-CORRENTE */
            _.Move(V1SIST_DTVENFIM_VE, WS_ARRAY.AREA_DE_WORK.WDATA_CORRENTE);

            /*" -634- MOVE V1SIST-DTVENFIM-VE TO WS-DT-INV. */
            _.Move(V1SIST_DTVENFIM_VE, WS_DT_INV);

            /*" -635- MOVE V1SIST-DTVENFIM-VE TO WDATA-MINVEN. */
            _.Move(V1SIST_DTVENFIM_VE, WS_ARRAY.AREA_DE_WORK.WDATA_MINVEN);

            /*" -636- MOVE WDATA-DDVEN TO SU1-DD1. */
            _.Move(WS_ARRAY.AREA_DE_WORK.WDATA_MINVEN.WDATA_DDVEN, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -637- MOVE WDATA-MMVEN TO SU1-MM1. */
            _.Move(WS_ARRAY.AREA_DE_WORK.WDATA_MINVEN.WDATA_MMVEN, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -638- MOVE WDATA-AAVEN TO SU1-AA1. */
            _.Move(WS_ARRAY.AREA_DE_WORK.WDATA_MINVEN.WDATA_SAVEN_R.WDATA_AAVEN, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -639- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2);

            /*" -640- PERFORM R013-00-SOMA-DIAS 6 TIMES. */

            for (int i = 0; i < 6; i++)
            {

                R013_00_SOMA_DIAS_SECTION();

            }

            /*" -641- MOVE SU1-DD2 TO WDATA-DDVEN. */
            _.Move(WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WS_ARRAY.AREA_DE_WORK.WDATA_MINVEN.WDATA_DDVEN);

            /*" -643- MOVE SU1-MM2 TO WDATA-MMVEN. */
            _.Move(WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WS_ARRAY.AREA_DE_WORK.WDATA_MINVEN.WDATA_MMVEN);

            /*" -644- DISPLAY '* DATA ATUAL             ' WDATA-CORRENTE. */
            _.Display($"* DATA ATUAL             {WS_ARRAY.AREA_DE_WORK.WDATA_CORRENTE}");

            /*" -645- DISPLAY '* DATA MOVIMENTO ABERTO  ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"* DATA MOVIMENTO ABERTO  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -646- DISPLAY '* DATA MINIMA P/COBRANCA ' WDATA-MINVEN. */
            _.Display($"* DATA MINIMA P/COBRANCA {WS_ARRAY.AREA_DE_WORK.WDATA_MINVEN}");

            /*" -653- MOVE WDATA-MINVEN TO V1SIST-DTVENFIM-VE. */
            _.Move(WS_ARRAY.AREA_DE_WORK.WDATA_MINVEN, V1SIST_DTVENFIM_VE);

            /*" -654- MOVE V1SIST-DTVENFIM-CN TO WDATA-MINATR. */
            _.Move(V1SIST_DTVENFIM_CN, WS_ARRAY.AREA_DE_WORK.WDATA_MINATR);

            /*" -655- MOVE WDATA-DDATR TO SU1-DD1. */
            _.Move(WS_ARRAY.AREA_DE_WORK.WDATA_MINATR.WDATA_DDATR, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -656- MOVE WDATA-MMATR TO SU1-MM1. */
            _.Move(WS_ARRAY.AREA_DE_WORK.WDATA_MINATR.WDATA_MMATR, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -657- MOVE WDATA-AAATR TO SU1-AA1. */
            _.Move(WS_ARRAY.AREA_DE_WORK.WDATA_MINATR.WDATA_SAATR_R.WDATA_AAATR, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -658- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2);

            /*" -659- MOVE 0 TO WIND-DATA. */
            _.Move(0, WS_ARRAY.AREA_DE_WORK.WIND_DATA);

            /*" -662- PERFORM R015-00-SOMA-DIAS UNTIL WDATA-MINATR NOT LESS WDATA-CORRENTE. */

            while (!(WS_ARRAY.AREA_DE_WORK.WDATA_MINATR >= WS_ARRAY.AREA_DE_WORK.WDATA_CORRENTE))
            {

                R015_00_SOMA_DIAS_SECTION();
            }

            /*" -663- IF WDATA-MINATR > WDATA-CORRENTE */

            if (WS_ARRAY.AREA_DE_WORK.WDATA_MINATR > WS_ARRAY.AREA_DE_WORK.WDATA_CORRENTE)
            {

                /*" -666- COMPUTE WIND-DATA = WIND-DATA - 1. */
                WS_ARRAY.AREA_DE_WORK.WIND_DATA.Value = WS_ARRAY.AREA_DE_WORK.WIND_DATA - 1;
            }


            /*" -667- COMPUTE WIND-DATA = WIND-DATA - 16. */
            WS_ARRAY.AREA_DE_WORK.WIND_DATA.Value = WS_ARRAY.AREA_DE_WORK.WIND_DATA - 16;

            /*" -670- MOVE WTAB-DATATR (WIND-DATA) TO WDATA-MINATR. */
            _.Move(WS_ARRAY.AREA_DE_WORK.WTAB_DATAS_UTEIS.WTAB_DATATR[WS_ARRAY.AREA_DE_WORK.WIND_DATA], WS_ARRAY.AREA_DE_WORK.WDATA_MINATR);

            /*" -670- DISPLAY '* DATA MINIMA P/ATRASO   ' V1SIST-DTVENFIM-CN. */
            _.Display($"* DATA MINIMA P/ATRASO   {V1SIST_DTVENFIM_CN}");

        }

        [StopWatch]
        /*" R100-00-PROCESSA-DATA-DB-SELECT-1 */
        public void R100_00_PROCESSA_DATA_DB_SELECT_1()
        {
            /*" -620- EXEC SQL SELECT CURRENT DATE, CURRENT DATE - 15 DAYS, DATA_MOV_ABERTO INTO :V1SIST-DTVENFIM-VE, :V1SIST-DTVENFIM-CN, :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' WITH UR END-EXEC. */

            var r100_00_PROCESSA_DATA_DB_SELECT_1_Query1 = new R100_00_PROCESSA_DATA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R100_00_PROCESSA_DATA_DB_SELECT_1_Query1.Execute(r100_00_PROCESSA_DATA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTVENFIM_VE, V1SIST_DTVENFIM_VE);
                _.Move(executed_1.V1SIST_DTVENFIM_CN, V1SIST_DTVENFIM_CN);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_99_SAIDA*/

        [StopWatch]
        /*" R013-00-SOMA-DIAS-SECTION */
        private void R013_00_SOMA_DIAS_SECTION()
        {
            /*" -684- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -685- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1);

            /*" -685- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R013_99_SAIDA*/

        [StopWatch]
        /*" R015-00-SOMA-DIAS-SECTION */
        private void R015_00_SOMA_DIAS_SECTION()
        {
            /*" -697- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -698- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1);

            /*" -699- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2, WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1);

            /*" -700- MOVE SU1-DD2 TO WDATA-DDATR. */
            _.Move(WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WS_ARRAY.AREA_DE_WORK.WDATA_MINATR.WDATA_DDATR);

            /*" -701- MOVE SU1-MM2 TO WDATA-MMATR. */
            _.Move(WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WS_ARRAY.AREA_DE_WORK.WDATA_MINATR.WDATA_MMATR);

            /*" -703- MOVE SU1-AA2 TO WDATA-AAATR. */
            _.Move(WS_ARRAY.AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WS_ARRAY.AREA_DE_WORK.WDATA_MINATR.WDATA_SAATR_R.WDATA_AAATR);

            /*" -704- COMPUTE WIND-DATA = WIND-DATA + 1. */
            WS_ARRAY.AREA_DE_WORK.WIND_DATA.Value = WS_ARRAY.AREA_DE_WORK.WIND_DATA + 1;

            /*" -704- MOVE WDATA-MINATR TO WTAB-DATATR (WIND-DATA). */
            _.Move(WS_ARRAY.AREA_DE_WORK.WDATA_MINATR, WS_ARRAY.AREA_DE_WORK.WTAB_DATAS_UTEIS.WTAB_DATATR[WS_ARRAY.AREA_DE_WORK.WIND_DATA]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_99_SAIDA*/

        [StopWatch]
        /*" R300-00-ABRIR-ARQUIVO-SECTION */
        private void R300_00_ABRIR_ARQUIVO_SECTION()
        {
            /*" -716- MOVE 'R030' TO WNR-EXEC-SQL. */
            _.Move("R030", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -720- OPEN OUTPUT STSASSE. */
            STSASSE.Open(REG_STSASSE);

            /*" -722- PERFORM R310-00-INSE-ARG-SIVPF. */

            R310_00_INSE_ARG_SIVPF_SECTION();

            /*" -723- MOVE 'H' TO R165-H-IDENT */
            _.Move("H", R165_HEADER_SASSE.R165_H_IDENT);

            /*" -724- MOVE 'STASASSE' TO R165-H-NOME-ARQ */
            _.Move("STASASSE", R165_HEADER_SASSE.R165_H_NOME_ARQ);

            /*" -725- MOVE WS-DT-REL(1:4) TO R165-H-DT-GERACAO(5:4) */
            _.MoveAtPosition(WS_DT_REL.Substring(1, 4), R165_HEADER_SASSE.R165_H_DT_GERACAO, 5, 4);

            /*" -726- MOVE WS-DT-REL(6:2) TO R165-H-DT-GERACAO(3:2) */
            _.MoveAtPosition(WS_DT_REL.Substring(6, 2), R165_HEADER_SASSE.R165_H_DT_GERACAO, 3, 2);

            /*" -727- MOVE WS-DT-REL(9:2) TO R165-H-DT-GERACAO(1:2) */
            _.MoveAtPosition(WS_DT_REL.Substring(9, 2), R165_HEADER_SASSE.R165_H_DT_GERACAO, 1, 2);

            /*" -728- MOVE 4 TO R165-H-SIS-GERACAO */
            _.Move(4, R165_HEADER_SASSE.R165_H_SIS_GERACAO);

            /*" -729- MOVE 1 TO R165-H-SIS-DESTINO */
            _.Move(1, R165_HEADER_SASSE.R165_H_SIS_DESTINO);

            /*" -730- MOVE W-NSAS TO R165-H-SEQUENCIAL */
            _.Move(W_NSAS, R165_HEADER_SASSE.R165_H_SEQUENCIAL);

            /*" -730- WRITE REG-STSASSE FROM R165-HEADER-SASSE. */
            _.Move(R165_HEADER_SASSE.GetMoveValues(), REG_STSASSE);

            STSASSE.Write(REG_STSASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_99_SAIDA*/

        [StopWatch]
        /*" R310-00-INSE-ARG-SIVPF-SECTION */
        private void R310_00_INSE_ARG_SIVPF_SECTION()
        {
            /*" -743- MOVE 'R031' TO WNR-EXEC-SQL. */
            _.Move("R031", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -750- PERFORM R310_00_INSE_ARG_SIVPF_DB_SELECT_1 */

            R310_00_INSE_ARG_SIVPF_DB_SELECT_1();

            /*" -753- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -754- DISPLAY 'VG0852B - FIM ANORMAL' */
                _.Display($"VG0852B - FIM ANORMAL");

                /*" -755- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -756- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -757- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -759- END-IF */
            }


            /*" -760- MOVE ARQSIVPF-NSAS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, W_NSAS);

            /*" -762- ADD 1 TO W-NSAS. */
            W_NSAS.Value = W_NSAS + 1;

            /*" -763- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO, */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -764- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM, */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -765- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF. */
            _.Move(W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -766- MOVE V1SIST-DTVENFIM-VE TO ARQSIVPF-DATA-GERACAO, */
            _.Move(V1SIST_DTVENFIM_VE, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -767- MOVE 0 TO ARQSIVPF-QTDE-REG-GER, */
            _.Move(0, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -769- MOVE SISTEMAS-DATA-MOV-ABERTO TO ARQSIVPF-DATA-PROCESSAMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -777- PERFORM R310_00_INSE_ARG_SIVPF_DB_INSERT_1 */

            R310_00_INSE_ARG_SIVPF_DB_INSERT_1();

            /*" -780- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -781- DISPLAY 'VG0852B - FIM ANORMAL' */
                _.Display($"VG0852B - FIM ANORMAL");

                /*" -782- DISPLAY 'ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -783- DISPLAY 'SIGLA DO ARQIVO.... ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"SIGLA DO ARQIVO.... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -784- DISPLAY 'NSAS SIVPF......... ' ARQSIVPF-NSAS-SIVPF */
                _.Display($"NSAS SIVPF......... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -785- DISPLAY 'DATA GERACAO....... ' ARQSIVPF-DATA-GERACAO */
                _.Display($"DATA GERACAO....... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -786- DISPLAY 'QTDE. REGISTROS.... ' ARQSIVPF-QTDE-REG-GER */
                _.Display($"QTDE. REGISTROS.... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -787- DISPLAY 'SQLCODE............ ' SQLCODE */
                _.Display($"SQLCODE............ {DB.SQLCODE}");

                /*" -788- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -788- END-IF. */
            }


        }

        [StopWatch]
        /*" R310-00-INSE-ARG-SIVPF-DB-SELECT-1 */
        public void R310_00_INSE_ARG_SIVPF_DB_SELECT_1()
        {
            /*" -750- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'STASASSE' AND SISTEMA_ORIGEM = 4 WITH UR END-EXEC. */

            var r310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1 = new R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1.Execute(r310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }

        [StopWatch]
        /*" R310-00-INSE-ARG-SIVPF-DB-INSERT-1 */
        public void R310_00_INSE_ARG_SIVPF_DB_INSERT_1()
        {
            /*" -777- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:ARQSIVPF-SIGLA-ARQUIVO, :ARQSIVPF-SISTEMA-ORIGEM, :ARQSIVPF-NSAS-SIVPF, :ARQSIVPF-DATA-GERACAO, :ARQSIVPF-QTDE-REG-GER, :ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r310_00_INSE_ARG_SIVPF_DB_INSERT_1_Insert1 = new R310_00_INSE_ARG_SIVPF_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R310_00_INSE_ARG_SIVPF_DB_INSERT_1_Insert1.Execute(r310_00_INSE_ARG_SIVPF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_99_SAIDA*/

        [StopWatch]
        /*" R700-000-LER-V1PARAMRAMO-SECTION */
        private void R700_000_LER_V1PARAMRAMO_SECTION()
        {
            /*" -803- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -808- PERFORM R700_000_LER_V1PARAMRAMO_DB_SELECT_1 */

            R700_000_LER_V1PARAMRAMO_DB_SELECT_1();

            /*" -811- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -812- DISPLAY 'VG0852B - NAO CONSTA REGISTRO NA V1PARAMRAMO' */
                _.Display($"VG0852B - NAO CONSTA REGISTRO NA V1PARAMRAMO");

                /*" -812- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R700-000-LER-V1PARAMRAMO-DB-SELECT-1 */
        public void R700_000_LER_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -808- EXEC SQL SELECT RAMO_AP INTO :PARAMRAM-RAMO-AP FROM SEGUROS.PARAMETROS_RAMOS WITH UR END-EXEC. */

            var r700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 = new R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(r700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_RAMO_AP, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_99_EXIT*/

        [StopWatch]
        /*" R900-00-DECLARE-CURSOR-CHISTCB-SECTION */
        private void R900_00_DECLARE_CURSOR_CHISTCB_SECTION()
        {
            /*" -824- MOVE 'R900' TO WNR-EXEC-SQL. */
            _.Move("R900", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -851- PERFORM R900_00_DECLARE_CURSOR_CHISTCB_DB_DECLARE_1 */

            R900_00_DECLARE_CURSOR_CHISTCB_DB_DECLARE_1();

            /*" -853- PERFORM R900_00_DECLARE_CURSOR_CHISTCB_DB_OPEN_1 */

            R900_00_DECLARE_CURSOR_CHISTCB_DB_OPEN_1();

            /*" -856- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -857- DISPLAY 'PROBLEMAS NO OPEN (CHISTCB   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CHISTCB   ) ... ");

                /*" -857- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R900-00-DECLARE-CURSOR-CHISTCB-DB-DECLARE-1 */
        public void R900_00_DECLARE_CURSOR_CHISTCB_DB_DECLARE_1()
        {
            /*" -851- EXEC SQL DECLARE CHISTCB CURSOR FOR SELECT B.NUM_CERTIFICADO, B.NUM_APOLICE, B.COD_SUBGRUPO, B.NUM_PARCELA, C.PERI_PAGAMENTO, C.ORIG_PRODU, C.COD_PRODUTO , D.TIPO_FATURAMENTO FROM SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C, SEGUROS.SUBGRUPOS_VGAP D WHERE D.NUM_APOLICE = C.NUM_APOLICE AND D.COD_SUBGRUPO = C.COD_SUBGRUPO AND D.SIT_REGISTRO = '0' AND C.COD_PRODUTO NOT BETWEEN 7700 AND 7799 AND C.ORIG_PRODU IN ( 'ESPEC' , 'ESPE1' , 'EMPRE' , 'GLOBAL' ) AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND B.SIT_REGISTRO IN ( '3' , '6' ) AND B.DTPROXVEN <> '9999-12-31' AND B.NUM_APOLICE NOT IN(109300002554, 109300000635) WITH UR END-EXEC. */
            CHISTCB = new VG0852B_CHISTCB(false);
            string GetQuery_CHISTCB()
            {
                var query = @$"SELECT B.NUM_CERTIFICADO
							, 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_PARCELA
							, 
							C.PERI_PAGAMENTO
							, 
							C.ORIG_PRODU
							, 
							C.COD_PRODUTO 
							, D.TIPO_FATURAMENTO 
							FROM SEGUROS.PROPOSTAS_VA B
							, 
							SEGUROS.PRODUTOS_VG C
							, 
							SEGUROS.SUBGRUPOS_VGAP D 
							WHERE D.NUM_APOLICE = C.NUM_APOLICE 
							AND D.COD_SUBGRUPO = C.COD_SUBGRUPO 
							AND D.SIT_REGISTRO = '0' 
							AND C.COD_PRODUTO NOT BETWEEN 7700 AND 7799 
							AND C.ORIG_PRODU IN 
							( 'ESPEC'
							, 'ESPE1'
							, 'EMPRE'
							, 'GLOBAL' ) 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND B.SIT_REGISTRO IN ( '3'
							, '6' ) 
							AND B.DTPROXVEN <> '9999-12-31' 
							AND B.NUM_APOLICE NOT IN(109300002554
							, 109300000635)";

                return query;
            }
            CHISTCB.GetQueryEvent += GetQuery_CHISTCB;

        }

        [StopWatch]
        /*" R900-00-DECLARE-CURSOR-CHISTCB-DB-OPEN-1 */
        public void R900_00_DECLARE_CURSOR_CHISTCB_DB_OPEN_1()
        {
            /*" -853- EXEC SQL OPEN CHISTCB END-EXEC. */

            CHISTCB.Open();

        }

        [StopWatch]
        /*" R1100-00-CONTA-PENDENCIA-DB-DECLARE-1 */
        public void R1100_00_CONTA_PENDENCIA_DB_DECLARE_1()
        {
            /*" -1058- EXEC SQL DECLARE CONT-PEN CURSOR FOR SELECT NUM_PARCELA , OPCAO_PAGAMENTO , SIT_REGISTRO , DATA_VENCIMENTO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA BETWEEN :WHOST-NUM-PARCELA-I AND :WHOST-NUM-PARCELA-F AND DATA_VENCIMENTO <= :V1SIST-DTVENFIM-CN AND SIT_REGISTRO IN (:W-SIT-BRANCO, :W-SIT-ZEROS, :W-SIT-VARIAVEL, X'00' ) ORDER BY NUM_PARCELA ASC WITH UR END-EXEC. */
            CONT_PEN = new VG0852B_CONT_PEN(true);
            string GetQuery_CONT_PEN()
            {
                var query = @$"SELECT NUM_PARCELA 
							, OPCAO_PAGAMENTO 
							, SIT_REGISTRO 
							, DATA_VENCIMENTO 
							FROM SEGUROS.COBER_HIST_VIDAZUL 
							WHERE NUM_CERTIFICADO = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}' 
							AND NUM_PARCELA BETWEEN '{WHOST_NUM_PARCELA_I}' 
							AND '{WHOST_NUM_PARCELA_F}' 
							AND DATA_VENCIMENTO <= '{V1SIST_DTVENFIM_CN}' 
							AND SIT_REGISTRO IN 
							('{WS_ARRAY.AREA_DE_WORK.W_SIT_BRANCO}'
							, '{WS_ARRAY.AREA_DE_WORK.W_SIT_ZEROS}'
							, '{WS_ARRAY.AREA_DE_WORK.W_SIT_VARIAVEL}'
							, 
							X'00' ) 
							ORDER BY NUM_PARCELA ASC";

                return query;
            }
            CONT_PEN.GetQueryEvent += GetQuery_CONT_PEN;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CHISTCB-SECTION */
        private void R0910_00_FETCH_CHISTCB_SECTION()
        {
            /*" -869- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -878- PERFORM R0910_00_FETCH_CHISTCB_DB_FETCH_1 */

            R0910_00_FETCH_CHISTCB_DB_FETCH_1();

            /*" -881- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -882- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -882- PERFORM R0910_00_FETCH_CHISTCB_DB_CLOSE_1 */

                    R0910_00_FETCH_CHISTCB_DB_CLOSE_1();

                    /*" -884- MOVE 'S' TO WFIM-CHISTCB */
                    _.Move("S", WS_ARRAY.AREA_DE_WORK.WFIM_CHISTCB);

                    /*" -885- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -886- ELSE */
                }
                else
                {


                    /*" -887- DISPLAY 'R0910-00 (ERRO -  FETCH CHISTCB   )...' */
                    _.Display($"R0910-00 (ERRO -  FETCH CHISTCB   )...");

                    /*" -888- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -889- END-IF */
                }


                /*" -890- ELSE */
            }
            else
            {


                /*" -891- ADD 1 TO WACC-LIDOS */
                WS_ARRAY.AREA_DE_WORK.WACC_LIDOS.Value = WS_ARRAY.AREA_DE_WORK.WACC_LIDOS + 1;

                /*" -893- END-IF. */
            }


            /*" -893- ADD 1 TO WACC-COMMIT. */
            WS_ARRAY.AREA_DE_WORK.WACC_COMMIT.Value = WS_ARRAY.AREA_DE_WORK.WACC_COMMIT + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-CHISTCB-DB-FETCH-1 */
        public void R0910_00_FETCH_CHISTCB_DB_FETCH_1()
        {
            /*" -878- EXEC SQL FETCH CHISTCB INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-PARCELA, :PRODUVG-PERI-PAGAMENTO, :PRODUVG-ORIG-PRODU, :PRODUVG-COD-PRODUTO , :SUBGVGAP-TIPO-FATURAMENTO END-EXEC. */

            if (CHISTCB.Fetch())
            {
                _.Move(CHISTCB.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CHISTCB.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CHISTCB.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CHISTCB.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(CHISTCB.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CHISTCB.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
                _.Move(CHISTCB.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(CHISTCB.SUBGVGAP_TIPO_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CHISTCB-DB-CLOSE-1 */
        public void R0910_00_FETCH_CHISTCB_DB_CLOSE_1()
        {
            /*" -882- EXEC SQL CLOSE CHISTCB END-EXEC */

            CHISTCB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -904- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -905- DISPLAY 'R1000 ---------------------------------' */
            _.Display($"R1000 ---------------------------------");

            /*" -916- DISPLAY 'R1000-00/001> ' PROPOVA-NUM-CERTIFICADO '-' PROPOVA-NUM-APOLICE '-' PROPOVA-COD-SUBGRUPO '-' PROPOVA-NUM-PARCELA '-' PRODUVG-PERI-PAGAMENTO '-' PRODUVG-ORIG-PRODU '-' PRODUVG-COD-PRODUTO '-' SUBGVGAP-TIPO-FATURAMENTO */

            $"R1000-00/001> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}-{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}-{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}-{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}-{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}-{PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU}-{PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO}-{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO}"
            .Display();

            /*" -918- PERFORM R1210-00-LER-HISTCOBVA. */

            R1210_00_LER_HISTCOBVA_SECTION();

            /*" -920- DISPLAY 'R1000-00/002> ' WS-TEM-PARCELA '-' COBHISVI-SIT-REGISTRO */

            $"R1000-00/002> {WS_TEM_PARCELA}-{COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO}"
            .Display();

            /*" -922- IF (WS-TEM-PARCELA EQUAL 'NAO' ) OR (COBHISVI-SIT-REGISTRO EQUAL '1' ) */

            if ((WS_TEM_PARCELA == "NAO") || (COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO == "1"))
            {

                /*" -923- GO TO R1000-90-NEXT */

                R1000_90_NEXT(); //GOTO
                return;

                /*" -932- END-IF. */
            }


            /*" -933- MOVE ZEROS TO WHOST-COUNT-PEN. */
            _.Move(0, WHOST_COUNT_PEN);

            /*" -934- IF PRODUVG-PERI-PAGAMENTO = 1 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO == 1)
            {

                /*" -935- DISPLAY 'R1000-00/003> FAZER R1100' */
                _.Display($"R1000-00/003> FAZER R1100");

                /*" -936- PERFORM R1100-00-CONTA-PENDENCIA */

                R1100_00_CONTA_PENDENCIA_SECTION();

                /*" -937- ELSE */
            }
            else
            {


                /*" -938- DISPLAY 'R1150-00/004> FAZER R1100' */
                _.Display($"R1150-00/004> FAZER R1100");

                /*" -939- PERFORM R1150-00-VERIF-ULT-PARCELA */

                R1150_00_VERIF_ULT_PARCELA_SECTION();

                /*" -941- IF COBHISVI-DATA-VENCIMENTO <= V1SIST-DTVENFIM-CN AND COBHISVI-SIT-REGISTRO NOT = '1' */

                if (COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO <= V1SIST_DTVENFIM_CN && COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO != "1")
                {

                    /*" -942- MOVE 1 TO WHOST-COUNT-PEN */
                    _.Move(1, WHOST_COUNT_PEN);

                    /*" -943- END-IF */
                }


                /*" -945- END-IF */
            }


            /*" -946- MOVE WHOST-COUNT-PEN TO WS-SMALLINT(01) */
            _.Move(WHOST_COUNT_PEN, WS_ARRAY.WS_ARRAY_OCC[01].WS_SMALLINT);

            /*" -948- DISPLAY 'R1000-00/005> ' PROPOVA-NUM-CERTIFICADO '-' WS-SMALLINT(01) */

            $"R1000-00/005> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}-{WS_ARRAY.WS_ARRAY_OCC[1]}"
            .Display();

            /*" -949- IF WHOST-COUNT-PEN = 0 */

            if (WHOST_COUNT_PEN == 0)
            {

                /*" -950- GO TO R1000-90-NEXT */

                R1000_90_NEXT(); //GOTO
                return;

                /*" -956- END-IF. */
            }


            /*" -961- DISPLAY 'R1000-00/006> ' PROPOVA-NUM-CERTIFICADO '-' WS-SMALLINT(01) '-' COBHISVI-SIT-REGISTRO '-' COBHISVI-DATA-VENCIMENTO '-' V1SIST-DTVENFIM-CN */

            $"R1000-00/006> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}-{WS_ARRAY.WS_ARRAY_OCC[1]}-{COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO}-{COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO}-{V1SIST_DTVENFIM_CN}"
            .Display();

            /*" -963- IF (COBHISVI-SIT-REGISTRO = '0' OR ' ' ) AND (COBHISVI-DATA-VENCIMENTO > V1SIST-DTVENFIM-CN) */

            if ((COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.In("0", " ")) && (COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO > V1SIST_DTVENFIM_CN))
            {

                /*" -967- IF ((WHOST-COUNT-PEN < 3) AND (PRODUVG-PERI-PAGAMENTO = 1)) OR ((WHOST-COUNT-PEN < 1) AND (PRODUVG-PERI-PAGAMENTO > 1)) */

                if (((WHOST_COUNT_PEN < 3) && (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO == 1)) || ((WHOST_COUNT_PEN < 1) && (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO > 1)))
                {

                    /*" -968- GO TO R1000-90-NEXT */

                    R1000_90_NEXT(); //GOTO
                    return;

                    /*" -969- END-IF */
                }


                /*" -977- END-IF. */
            }


            /*" -979- IF SISTEMAS-DATA-MOV-ABERTO > '2022-05-27' NEXT SENTENCE */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO > "2022-05-27")
            {

                /*" -980- ELSE */
            }
            else
            {


                /*" -982- IF PROPOVA-NUM-CERTIFICADO EQUAL 95662665984 OR 95662680630 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.In("95662665984", "95662680630"))
                {

                    /*" -983- GO TO R1000-90-NEXT */

                    R1000_90_NEXT(); //GOTO
                    return;

                    /*" -984- END-IF */
                }


                /*" -988- END-IF. */
            }


            /*" -991- DISPLAY 'R1000-00/007> ' PROPOVA-NUM-CERTIFICADO '-' WS-SMALLINT(01) '-' PRODUVG-PERI-PAGAMENTO */

            $"R1000-00/007> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}-{WS_ARRAY.WS_ARRAY_OCC[1]}-{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}"
            .Display();

            /*" -995- IF ((WHOST-COUNT-PEN > 2) AND (PRODUVG-PERI-PAGAMENTO = 1)) OR ((WHOST-COUNT-PEN > 0) AND (PRODUVG-PERI-PAGAMENTO > 1)) */

            if (((WHOST_COUNT_PEN > 2) && (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO == 1)) || ((WHOST_COUNT_PEN > 0) && (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO > 1)))
            {

                /*" -996- PERFORM R1300-00-CANCELA-PROPOSTA-VA */

                R1300_00_CANCELA_PROPOSTA_VA_SECTION();

                /*" -997- PERFORM R1400-00-CANCELA-SUBGRUPO */

                R1400_00_CANCELA_SUBGRUPO_SECTION();

                /*" -998- PERFORM R1450-00-CANCELA-APOLICE */

                R1450_00_CANCELA_APOLICE_SECTION();

                /*" -999- PERFORM R1500-00-INSERT-MOVIMENTO-VGAP */

                R1500_00_INSERT_MOVIMENTO_VGAP_SECTION();

                /*" -1000- PERFORM R1600-00-CANCELA-ENDOSSO */

                R1600_00_CANCELA_ENDOSSO_SECTION();

                /*" -1001- PERFORM R1700-00-CANC-PARC */

                R1700_00_CANC_PARC_SECTION();

                /*" -1002- PERFORM R1800-00-SELECT-FIDRLIZ */

                R1800_00_SELECT_FIDRLIZ_SECTION();

                /*" -1003- ADD 001 TO WACC-CANCELADOS */
                WS_ARRAY.AREA_DE_WORK.WACC_CANCELADOS.Value = WS_ARRAY.AREA_DE_WORK.WACC_CANCELADOS + 001;

                /*" -1003- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_NEXT */

            R1000_90_NEXT();

        }

        [StopWatch]
        /*" R1000-90-NEXT */
        private void R1000_90_NEXT(bool isPerform = false)
        {
            /*" -1006- PERFORM R0910-00-FETCH-CHISTCB. */

            R0910_00_FETCH_CHISTCB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-CONTA-PENDENCIA-SECTION */
        private void R1100_00_CONTA_PENDENCIA_SECTION()
        {
            /*" -1019- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1020- MOVE ZEROS TO WHOST-COUNT-PEN. */
            _.Move(0, WHOST_COUNT_PEN);

            /*" -1022- MOVE 'N' TO WFIM-PARCELA. */
            _.Move("N", WS_ARRAY.AREA_DE_WORK.WFIM_PARCELA);

            /*" -1023- MOVE PROPOVA-NUM-PARCELA TO WHOST-NUM-PARCELA-F. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA, WHOST_NUM_PARCELA_F);

            /*" -1025- COMPUTE WHOST-NUM-PARCELA-I = PROPOVA-NUM-PARCELA - 2. */
            WHOST_NUM_PARCELA_I.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA - 2;

            /*" -1026- IF (COBHISVI-DATA-VENCIMENTO > V1SIST-DTVENFIM-CN) */

            if ((COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO > V1SIST_DTVENFIM_CN))
            {

                /*" -1027- COMPUTE WHOST-NUM-PARCELA-I = PROPOVA-NUM-PARCELA - 3 */
                WHOST_NUM_PARCELA_I.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA - 3;

                /*" -1028- COMPUTE WHOST-NUM-PARCELA-F = PROPOVA-NUM-PARCELA - 1 */
                WHOST_NUM_PARCELA_F.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA - 1;

                /*" -1031- END-IF. */
            }


            /*" -1032- IF COBHISVI-OPCAO-PAGAMENTO EQUAL '1' */

            if (COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OPCAO_PAGAMENTO == "1")
            {

                /*" -1033- MOVE SPACES TO W-SIT-VARIAVEL */
                _.Move("", WS_ARRAY.AREA_DE_WORK.W_SIT_VARIAVEL);

                /*" -1034- ELSE */
            }
            else
            {


                /*" -1035- MOVE '2' TO W-SIT-VARIAVEL */
                _.Move("2", WS_ARRAY.AREA_DE_WORK.W_SIT_VARIAVEL);

                /*" -1037- END-IF */
            }


            /*" -1042- DISPLAY 'R1100-00/001> ' PROPOVA-NUM-CERTIFICADO '-' WHOST-NUM-PARCELA-I '-' WHOST-NUM-PARCELA-F '-' V1SIST-DTVENFIM-CN '-' COBHISVI-OPCAO-PAGAMENTO */

            $"R1100-00/001> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}-{WHOST_NUM_PARCELA_I}-{WHOST_NUM_PARCELA_F}-{V1SIST_DTVENFIM_CN}-{COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OPCAO_PAGAMENTO}"
            .Display();

            /*" -1058- PERFORM R1100_00_CONTA_PENDENCIA_DB_DECLARE_1 */

            R1100_00_CONTA_PENDENCIA_DB_DECLARE_1();

            /*" -1062- PERFORM R1100_00_CONTA_PENDENCIA_DB_OPEN_1 */

            R1100_00_CONTA_PENDENCIA_DB_OPEN_1();

            /*" -1065- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1066- DISPLAY 'PROBLEMAS NO OPEN (CONT-PEN  ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CONT-PEN  ) ... ");

                /*" -1067- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1069- END-IF. */
            }


            /*" -1071- PERFORM R1110-00-FETCH-CONT-PEC */

            R1110_00_FETCH_CONT_PEC_SECTION();

            /*" -1072- PERFORM UNTIL WFIM-PARCELA = 'S' */

            while (!(WS_ARRAY.AREA_DE_WORK.WFIM_PARCELA == "S"))
            {

                /*" -1074- ADD 1 TO WHOST-COUNT-PEN */
                WHOST_COUNT_PEN.Value = WHOST_COUNT_PEN + 1;

                /*" -1075- PERFORM R1110-00-FETCH-CONT-PEC */

                R1110_00_FETCH_CONT_PEC_SECTION();

                /*" -1077- END-PERFORM */
            }

            /*" -1079- PERFORM R1100_00_CONTA_PENDENCIA_DB_CLOSE_1 */

            R1100_00_CONTA_PENDENCIA_DB_CLOSE_1();

            /*" -1081- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1082- DISPLAY 'PROBLEMAS NO CLOSE(CONT-PEN  ) ... ' */
                _.Display($"PROBLEMAS NO CLOSE(CONT-PEN  ) ... ");

                /*" -1083- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1085- END-IF. */
            }


            /*" -1086- MOVE WHOST-COUNT-PEN TO WS-SMALLINT(01) */
            _.Move(WHOST_COUNT_PEN, WS_ARRAY.WS_ARRAY_OCC[01].WS_SMALLINT);

            /*" -1087- DISPLAY 'R1100-00/002> ' PROPOVA-NUM-CERTIFICADO '-' WS-SMALLINT(01). */

            $"R1100-00/002> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}-{WS_ARRAY.WS_ARRAY_OCC[1]}"
            .Display();

        }

        [StopWatch]
        /*" R1100-00-CONTA-PENDENCIA-DB-OPEN-1 */
        public void R1100_00_CONTA_PENDENCIA_DB_OPEN_1()
        {
            /*" -1062- EXEC SQL OPEN CONT-PEN END-EXEC. */

            CONT_PEN.Open();

        }

        [StopWatch]
        /*" R1590-00-DECLARE-CSEGURA-DB-DECLARE-1 */
        public void R1590_00_DECLARE_CSEGURA_DB_DECLARE_1()
        {
            /*" -1390- EXEC SQL DECLARE CSEGURA CURSOR FOR SELECT NUM_CERTIFICADO, COD_FONTE, TIPO_INCLUSAO, COD_AGENCIADOR, NUM_ITEM, OCORR_HISTORICO, NUM_APOLICE, COD_SUBGRUPO, SIT_REGISTRO, COD_CLIENTE, NUM_MATRICULA, DATA_INIVIGENCIA FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND (:WS-FATURA-POR-APOLICE = 'S' OR (:WS-FATURA-POR-APOLICE = 'N' AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO ) ) AND NUM_MATRICULA >= 0 AND TIPO_SEGURADO = '1' AND SIT_REGISTRO = '0' WITH UR END-EXEC. */
            CSEGURA = new VG0852B_CSEGURA(true);
            string GetQuery_CSEGURA()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							COD_FONTE
							, 
							TIPO_INCLUSAO
							, 
							COD_AGENCIADOR
							, 
							NUM_ITEM
							, 
							OCORR_HISTORICO
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							SIT_REGISTRO
							, 
							COD_CLIENTE
							, 
							NUM_MATRICULA
							, 
							DATA_INIVIGENCIA 
							FROM SEGUROS.SEGURADOS_VGAP 
							WHERE NUM_APOLICE = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}' 
							AND ('{WS_FATURA_POR_APOLICE}' = 'S' 
							OR ('{WS_FATURA_POR_APOLICE}' = 'N' 
							AND COD_SUBGRUPO = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}' 
							) 
							) 
							AND NUM_MATRICULA >= 0 
							AND TIPO_SEGURADO = '1' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            CSEGURA.GetQueryEvent += GetQuery_CSEGURA;

        }

        [StopWatch]
        /*" R1100-00-CONTA-PENDENCIA-DB-CLOSE-1 */
        public void R1100_00_CONTA_PENDENCIA_DB_CLOSE_1()
        {
            /*" -1079- EXEC SQL CLOSE CONT-PEN END-EXEC. */

            CONT_PEN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-FETCH-CONT-PEC-SECTION */
        private void R1110_00_FETCH_CONT_PEC_SECTION()
        {
            /*" -1098- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1100- MOVE SPACES TO WFIM-PARCELA */
            _.Move("", WS_ARRAY.AREA_DE_WORK.WFIM_PARCELA);

            /*" -1105- PERFORM R1110_00_FETCH_CONT_PEC_DB_FETCH_1 */

            R1110_00_FETCH_CONT_PEC_DB_FETCH_1();

            /*" -1108- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1108- WHEN 0 */
                case 0:

                    /*" -1108- CONTINUE */

                    /*" -1109- WHEN 100 */
                    break;
                case 100:

                    /*" -1109- MOVE   'S'      TO  WFIM-PARCELA */
                    _.Move("S", WS_ARRAY.AREA_DE_WORK.WFIM_PARCELA);

                    /*" -1111- WHEN OTHER */
                    break;
                default:

                    /*" -1112- DISPLAY 'R0910-00 (ERRO -  FETCH CONT-PEN  )...' */
                    _.Display($"R0910-00 (ERRO -  FETCH CONT-PEN  )...");

                    /*" -1113- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1113- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R1110-00-FETCH-CONT-PEC-DB-FETCH-1 */
        public void R1110_00_FETCH_CONT_PEC_DB_FETCH_1()
        {
            /*" -1105- EXEC SQL FETCH CONT-PEN INTO :COBHISVI-NUM-PARCELA , :COBHISVI-OPCAO-PAGAMENTO , :COBHISVI-SIT-REGISTRO , :COBHISVI-DATA-VENCIMENTO END-EXEC. */

            if (CONT_PEN.Fetch())
            {
                _.Move(CONT_PEN.COBHISVI_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);
                _.Move(CONT_PEN.COBHISVI_OPCAO_PAGAMENTO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OPCAO_PAGAMENTO);
                _.Move(CONT_PEN.COBHISVI_SIT_REGISTRO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);
                _.Move(CONT_PEN.COBHISVI_DATA_VENCIMENTO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-VERIF-ULT-PARCELA-SECTION */
        private void R1150_00_VERIF_ULT_PARCELA_SECTION()
        {
            /*" -1124- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1137- PERFORM R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1 */

            R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1();

            /*" -1140- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1141- DISPLAY 'R0910-00 (ERRO -  SELECT PARCELA   )...' */
                _.Display($"R0910-00 (ERRO -  SELECT PARCELA   )...");

                /*" -1142- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1142- END-IF. */
            }


        }

        [StopWatch]
        /*" R1150-00-VERIF-ULT-PARCELA-DB-SELECT-1 */
        public void R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1()
        {
            /*" -1137- EXEC SQL SELECT NUM_PARCELA , OPCAO_PAGAMENTO , SIT_REGISTRO , DATA_VENCIMENTO INTO :COBHISVI-NUM-PARCELA , :COBHISVI-OPCAO-PAGAMENTO , :COBHISVI-SIT-REGISTRO , :COBHISVI-DATA-VENCIMENTO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-NUM-PARCELA WITH UR END-EXEC. */

            var r1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1 = new R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1.Execute(r1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);
                _.Move(executed_1.COBHISVI_OPCAO_PAGAMENTO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.COBHISVI_SIT_REGISTRO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);
                _.Move(executed_1.COBHISVI_DATA_VENCIMENTO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-LER-HISTCOBVA-SECTION */
        private void R1210_00_LER_HISTCOBVA_SECTION()
        {
            /*" -1153- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1155- MOVE 'NAO' TO WS-TEM-PARCELA */
            _.Move("NAO", WS_TEM_PARCELA);

            /*" -1175- PERFORM R1210_00_LER_HISTCOBVA_DB_SELECT_1 */

            R1210_00_LER_HISTCOBVA_DB_SELECT_1();

            /*" -1178- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -1179- DISPLAY 'R1210-00-LER-HISTCOBVA-VA .....' */
                _.Display($"R1210-00-LER-HISTCOBVA-VA .....");

                /*" -1180- DISPLAY 'NRCERTIF.....  ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NRCERTIF.....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1181- DISPLAY 'PARCELA .....  ' PROPOVA-NUM-PARCELA */
                _.Display($"PARCELA .....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                /*" -1183- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1184- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1185- ELSE */
            }
            else
            {


                /*" -1186- IF (SQLCODE EQUAL ZEROS) */

                if ((DB.SQLCODE == 00))
                {

                    /*" -1187- MOVE 'SIM' TO WS-TEM-PARCELA */
                    _.Move("SIM", WS_TEM_PARCELA);

                    /*" -1188- PERFORM R1215-00-CANCEL-HISTCOBVA */

                    R1215_00_CANCEL_HISTCOBVA_SECTION();

                    /*" -1189- END-IF */
                }


                /*" -1189- END-IF. */
            }


        }

        [StopWatch]
        /*" R1210-00-LER-HISTCOBVA-DB-SELECT-1 */
        public void R1210_00_LER_HISTCOBVA_DB_SELECT_1()
        {
            /*" -1175- EXEC SQL SELECT SIT_REGISTRO, DATA_VENCIMENTO, NUM_TITULO ,OPCAO_PAGAMENTO INTO :COBHISVI-SIT-REGISTRO, :COBHISVI-DATA-VENCIMENTO, :COBHISVI-NUM-TITULO ,:COBHISVI-OPCAO-PAGAMENTO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-NUM-PARCELA AND SIT_REGISTRO <> '2' AND NUM_TITULO = (SELECT MAX(A.NUM_TITULO) FROM SEGUROS.COBER_HIST_VIDAZUL A WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.NUM_PARCELA = :PROPOVA-NUM-PARCELA AND A.SIT_REGISTRO <> '2' ) WITH UR END-EXEC. */

            var r1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1 = new R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1.Execute(r1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_SIT_REGISTRO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);
                _.Move(executed_1.COBHISVI_DATA_VENCIMENTO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.COBHISVI_OPCAO_PAGAMENTO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OPCAO_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1215-00-CANCEL-HISTCOBVA-SECTION */
        private void R1215_00_CANCEL_HISTCOBVA_SECTION()
        {
            /*" -1202- MOVE '1205' TO WNR-EXEC-SQL. */
            _.Move("1205", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1208- PERFORM R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1 */

            R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1();

            /*" -1211- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -1212- DISPLAY 'R1215-00-CANCEL-HISTCOBVA-VA .....' */
                _.Display($"R1215-00-CANCEL-HISTCOBVA-VA .....");

                /*" -1213- DISPLAY 'NRCERTIF.....  ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NRCERTIF.....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1214- DISPLAY 'PARCELA .....  ' PROPOVA-NUM-PARCELA */
                _.Display($"PARCELA .....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                /*" -1215- DISPLAY 'NUM-TITULO...  ' COBHISVI-NUM-TITULO */
                _.Display($"NUM-TITULO...  {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO}");

                /*" -1216- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1217- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1218- END-IF. */
            }


        }

        [StopWatch]
        /*" R1215-00-CANCEL-HISTCOBVA-DB-UPDATE-1 */
        public void R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1()
        {
            /*" -1208- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = '2' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-NUM-PARCELA AND NUM_TITULO <> :COBHISVI-NUM-TITULO END-EXEC. */

            var r1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1 = new R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                COBHISVI_NUM_TITULO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO.ToString(),
            };

            R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1.Execute(r1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1215_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-CANCELA-PROPOSTA-VA-SECTION */
        private void R1300_00_CANCELA_PROPOSTA_VA_SECTION()
        {
            /*" -1227- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1228- IF (PRODUVG-ORIG-PRODU EQUAL 'EMPRE' OR 'GLOBAL' ) */

            if ((PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("EMPRE", "GLOBAL")))
            {

                /*" -1229- ADD 1 TO WS-QT-CANC-EMPR */
                WS_QT_CANC_EMPR.Value = WS_QT_CANC_EMPR + 1;

                /*" -1231- END-IF. */
            }


            /*" -1239- PERFORM R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1 */

            R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1();

            /*" -1242- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1243- DISPLAY 'R1300-00-CANCELA-PROPOSTA... ........' */
                _.Display($"R1300-00-CANCELA-PROPOSTA... ........");

                /*" -1244- DISPLAY 'APOLICE......  ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE......  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1245- DISPLAY 'SUBGRUPO.....  ' PROPOVA-COD-SUBGRUPO */
                _.Display($"SUBGRUPO.....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -1246- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1246- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-CANCELA-PROPOSTA-VA-DB-UPDATE-1 */
        public void R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1()
        {
            /*" -1239- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_USUARIO = 'VG0852B' , COD_OPERACAO = 403 , TIMESTAMP = CURRENT TIMESTAMP, SIT_REGISTRO = '4' WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1 = new R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1.Execute(r1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-CANCELA-SUBGRUPO-SECTION */
        private void R1400_00_CANCELA_SUBGRUPO_SECTION()
        {
            /*" -1257- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1259- IF SUBGVGAP-TIPO-FATURAMENTO EQUAL '1' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO == "1")
            {

                /*" -1263- PERFORM R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1 */

                R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1();

                /*" -1266- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1267- DISPLAY 'R1400-00-CANCELA-SUBGRUPO I' */
                    _.Display($"R1400-00-CANCELA-SUBGRUPO I");

                    /*" -1268- DISPLAY 'APOLICE......  ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE......  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -1269- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1271- END-IF */
                }


                /*" -1273- ELSE */
            }
            else
            {


                /*" -1278- PERFORM R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2 */

                R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2();

                /*" -1281- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1282- DISPLAY 'R1400-00-CANCELA-SUBGRUPO II' */
                    _.Display($"R1400-00-CANCELA-SUBGRUPO II");

                    /*" -1283- DISPLAY 'APOLICE......  ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE......  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -1284- DISPLAY 'SUBGRUPO.....  ' PROPOVA-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO.....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                    /*" -1285- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1286- END-IF */
                }


                /*" -1286- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-CANCELA-SUBGRUPO-DB-UPDATE-1 */
        public void R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1()
        {
            /*" -1263- EXEC SQL UPDATE SEGUROS.SUBGRUPOS_VGAP SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE END-EXEC */

            var r1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1 = new R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1.Execute(r1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-CANCELA-SUBGRUPO-DB-UPDATE-2 */
        public void R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2()
        {
            /*" -1278- EXEC SQL UPDATE SEGUROS.SUBGRUPOS_VGAP SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC */

            var r1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2_Update1 = new R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2_Update1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2_Update1.Execute(r1400_00_CANCELA_SUBGRUPO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1450-00-CANCELA-APOLICE-SECTION */
        private void R1450_00_CANCELA_APOLICE_SECTION()
        {
            /*" -1297- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1303- PERFORM R1450_00_CANCELA_APOLICE_DB_SELECT_1 */

            R1450_00_CANCELA_APOLICE_DB_SELECT_1();

            /*" -1306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1307- DISPLAY 'R1450-00-CANCELA-APOLICE' */
                _.Display($"R1450-00-CANCELA-APOLICE");

                /*" -1308- DISPLAY 'APOLICE......  ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE......  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1309- DISPLAY 'SUBGRUPO.....  ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO.....  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -1310- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1311- GO TO R1450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/ //GOTO
                return;

                /*" -1313- END-IF. */
            }


            /*" -1314- IF APOLICES-TIPO-APOLICE NOT EQUAL '5' */

            if (APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE != "5")
            {

                /*" -1316- GO TO R1450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1321- PERFORM R1450_00_CANCELA_APOLICE_DB_UPDATE_1 */

            R1450_00_CANCELA_APOLICE_DB_UPDATE_1();

            /*" -1324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1325- DISPLAY 'R1450-00-CANCELA-APOLICE' */
                _.Display($"R1450-00-CANCELA-APOLICE");

                /*" -1326- DISPLAY 'APOLICE......  ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE......  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1327- DISPLAY 'SUBGRUPO.....  ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO.....  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -1328- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1329- GO TO R1450-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/ //GOTO
                return;

                /*" -1329- END-IF. */
            }


        }

        [StopWatch]
        /*" R1450-00-CANCELA-APOLICE-DB-SELECT-1 */
        public void R1450_00_CANCELA_APOLICE_DB_SELECT_1()
        {
            /*" -1303- EXEC SQL SELECT TIPO_APOLICE INTO :APOLICES-TIPO-APOLICE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE WITH UR END-EXEC. */

            var r1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1 = new R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1.Execute(r1450_00_CANCELA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_TIPO_APOLICE, APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE);
            }


        }

        [StopWatch]
        /*" R1450-00-CANCELA-APOLICE-DB-UPDATE-1 */
        public void R1450_00_CANCELA_APOLICE_DB_UPDATE_1()
        {
            /*" -1321- EXEC SQL UPDATE SEGUROS.SUBGRUPOS_VGAP SET SIT_REGISTRO = '2' WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = 0 END-EXEC. */

            var r1450_00_CANCELA_APOLICE_DB_UPDATE_1_Update1 = new R1450_00_CANCELA_APOLICE_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            R1450_00_CANCELA_APOLICE_DB_UPDATE_1_Update1.Execute(r1450_00_CANCELA_APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-INSERT-MOVIMENTO-VGAP-SECTION */
        private void R1500_00_INSERT_MOVIMENTO_VGAP_SECTION()
        {
            /*" -1340- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1341- IF SUBGVGAP-TIPO-FATURAMENTO EQUAL '1' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO == "1")
            {

                /*" -1342- MOVE 'S' TO WS-FATURA-POR-APOLICE */
                _.Move("S", WS_FATURA_POR_APOLICE);

                /*" -1343- ELSE */
            }
            else
            {


                /*" -1344- MOVE 'N' TO WS-FATURA-POR-APOLICE */
                _.Move("N", WS_FATURA_POR_APOLICE);

                /*" -1346- END-IF. */
            }


            /*" -1347- PERFORM R1590-00-DECLARE-CSEGURA. */

            R1590_00_DECLARE_CSEGURA_SECTION();

            /*" -1349- MOVE SPACES TO WFIM-CSEGURA */
            _.Move("", WFIM_CSEGURA);

            /*" -1351- PERFORM R1595-00-FETCH-CSEGURA. */

            R1595_00_FETCH_CSEGURA_SECTION();

            /*" -1352- PERFORM R2000-00-INSERT-MOV-VGAP UNTIL WFIM-CSEGURA NOT EQUAL SPACES. */

            while (!(!WFIM_CSEGURA.IsEmpty()))
            {

                R2000_00_INSERT_MOV_VGAP_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1590-00-DECLARE-CSEGURA-SECTION */
        private void R1590_00_DECLARE_CSEGURA_SECTION()
        {
            /*" -1364- MOVE '1590' TO WNR-EXEC-SQL. */
            _.Move("1590", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1390- PERFORM R1590_00_DECLARE_CSEGURA_DB_DECLARE_1 */

            R1590_00_DECLARE_CSEGURA_DB_DECLARE_1();

            /*" -1392- PERFORM R1590_00_DECLARE_CSEGURA_DB_OPEN_1 */

            R1590_00_DECLARE_CSEGURA_DB_OPEN_1();

            /*" -1396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1397- DISPLAY 'PROBLEMAS NO OPEN (CSEGURA   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CSEGURA   ) ... ");

                /*" -1398- MOVE 'S' TO WFIM-CSEGURA */
                _.Move("S", WFIM_CSEGURA);

                /*" -1399- ELSE */
            }
            else
            {


                /*" -1400- MOVE SPACES TO WFIM-CSEGURA */
                _.Move("", WFIM_CSEGURA);

                /*" -1400- END-IF. */
            }


        }

        [StopWatch]
        /*" R1590-00-DECLARE-CSEGURA-DB-OPEN-1 */
        public void R1590_00_DECLARE_CSEGURA_DB_OPEN_1()
        {
            /*" -1392- EXEC SQL OPEN CSEGURA END-EXEC. */

            CSEGURA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1590_99_SAIDA*/

        [StopWatch]
        /*" R1595-00-FETCH-CSEGURA-SECTION */
        private void R1595_00_FETCH_CSEGURA_SECTION()
        {
            /*" -1411- MOVE '1595' TO WNR-EXEC-SQL. */
            _.Move("1595", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1413- MOVE ' ' TO WFIM-CSEGURA. */
            _.Move(" ", WFIM_CSEGURA);

            /*" -1426- PERFORM R1595_00_FETCH_CSEGURA_DB_FETCH_1 */

            R1595_00_FETCH_CSEGURA_DB_FETCH_1();

            /*" -1429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1430- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1430- PERFORM R1595_00_FETCH_CSEGURA_DB_CLOSE_1 */

                    R1595_00_FETCH_CSEGURA_DB_CLOSE_1();

                    /*" -1432- MOVE 'S' TO WFIM-CSEGURA */
                    _.Move("S", WFIM_CSEGURA);

                    /*" -1433- ELSE */
                }
                else
                {


                    /*" -1434- DISPLAY 'R1595-00 (ERRO -  FETCH CSEGURA   )...' */
                    _.Display($"R1595-00 (ERRO -  FETCH CSEGURA   )...");

                    /*" -1434- PERFORM R1595_00_FETCH_CSEGURA_DB_CLOSE_2 */

                    R1595_00_FETCH_CSEGURA_DB_CLOSE_2();

                    /*" -1436- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1437- END-IF */
                }


                /*" -1438- ELSE */
            }
            else
            {


                /*" -1439- ADD 1 TO WACC-LIDO2 */
                WS_ARRAY.AREA_DE_WORK.WACC_LIDO2.Value = WS_ARRAY.AREA_DE_WORK.WACC_LIDO2 + 1;

                /*" -1439- END-IF. */
            }


        }

        [StopWatch]
        /*" R1595-00-FETCH-CSEGURA-DB-FETCH-1 */
        public void R1595_00_FETCH_CSEGURA_DB_FETCH_1()
        {
            /*" -1426- EXEC SQL FETCH CSEGURA INTO :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-COD-FONTE, :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-AGENCIADOR, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-SIT-REGISTRO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-NUM-MATRICULA, :SEGURVGA-DATA-INIVIGENCIA END-EXEC. */

            if (CSEGURA.Fetch())
            {
                _.Move(CSEGURA.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(CSEGURA.SEGURVGA_COD_FONTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);
                _.Move(CSEGURA.SEGURVGA_TIPO_INCLUSAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO);
                _.Move(CSEGURA.SEGURVGA_COD_AGENCIADOR, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR);
                _.Move(CSEGURA.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(CSEGURA.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(CSEGURA.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(CSEGURA.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(CSEGURA.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
                _.Move(CSEGURA.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(CSEGURA.SEGURVGA_NUM_MATRICULA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA);
                _.Move(CSEGURA.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
            }

        }

        [StopWatch]
        /*" R1595-00-FETCH-CSEGURA-DB-CLOSE-1 */
        public void R1595_00_FETCH_CSEGURA_DB_CLOSE_1()
        {
            /*" -1430- EXEC SQL CLOSE CSEGURA END-EXEC */

            CSEGURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1595_99_SAIDA*/

        [StopWatch]
        /*" R1595-00-FETCH-CSEGURA-DB-CLOSE-2 */
        public void R1595_00_FETCH_CSEGURA_DB_CLOSE_2()
        {
            /*" -1434- EXEC SQL CLOSE CSEGURA END-EXEC */

            CSEGURA.Close();

        }

        [StopWatch]
        /*" R1600-00-CANCELA-ENDOSSO-SECTION */
        private void R1600_00_CANCELA_ENDOSSO_SECTION()
        {
            /*" -1450- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1452- MOVE ZEROS TO WHOST-SUBGRUPO. */
            _.Move(0, WHOST_SUBGRUPO);

            /*" -1459- PERFORM R1600_00_CANCELA_ENDOSSO_DB_SELECT_1 */

            R1600_00_CANCELA_ENDOSSO_DB_SELECT_1();

            /*" -1462- IF WHOST-SUBGRUPO < 1 */

            if (WHOST_SUBGRUPO < 1)
            {

                /*" -1463- PERFORM R1610-00-CANCELA-ENDOSSO */

                R1610_00_CANCELA_ENDOSSO_SECTION();

                /*" -1463- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-CANCELA-ENDOSSO-DB-SELECT-1 */
        public void R1600_00_CANCELA_ENDOSSO_DB_SELECT_1()
        {
            /*" -1459- EXEC SQL SELECT COUNT(*) INTO :WHOST-SUBGRUPO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r1600_00_CANCELA_ENDOSSO_DB_SELECT_1_Query1 = new R1600_00_CANCELA_ENDOSSO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1600_00_CANCELA_ENDOSSO_DB_SELECT_1_Query1.Execute(r1600_00_CANCELA_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_SUBGRUPO, WHOST_SUBGRUPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-CANCELA-ENDOSSO-SECTION */
        private void R1610_00_CANCELA_ENDOSSO_SECTION()
        {
            /*" -1474- MOVE '1610' TO WNR-EXEC-SQL. */
            _.Move("1610", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1480- PERFORM R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1 */

            R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1();

            /*" -1484- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1486- DISPLAY 'R1610-00 (PROBLEMAS UPDATE V0ENDOSSO) ... ' ' ' PROPOVA-NUM-APOLICE */

                $"R1610-00 (PROBLEMAS UPDATE V0ENDOSSO) ...  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                .Display();

                /*" -1488- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1490- ADD 1 TO CONT-ENDOSSO. */
            CONT_ENDOSSO.Value = CONT_ENDOSSO + 1;

            /*" -1490- ADD 1 TO CONT-ENDOSSOS. */
            CONT_ENDOSSOS.Value = CONT_ENDOSSOS + 1;

        }

        [StopWatch]
        /*" R1610-00-CANCELA-ENDOSSO-DB-UPDATE-1 */
        public void R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1()
        {
            /*" -1480- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET SIT_REGISTRO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 = new R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1.Execute(r1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-CANC-PARC-SECTION */
        private void R1700_00_CANC_PARC_SECTION()
        {
            /*" -1500- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1506- PERFORM R1700_00_CANC_PARC_DB_UPDATE_1 */

            R1700_00_CANC_PARC_DB_UPDATE_1();

            /*" -1509- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1510- DISPLAY 'R1700-00-PARCELAS' */
                _.Display($"R1700-00-PARCELAS");

                /*" -1511- DISPLAY 'APOLICE......  ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE......  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1512- DISPLAY 'SUBGRUPO.....  ' PROPOVA-COD-SUBGRUPO */
                _.Display($"SUBGRUPO.....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -1513- DISPLAY 'NRCERTIF.....  ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NRCERTIF.....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1514- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1516- END-IF. */
            }


            /*" -1520- MOVE '1701' TO WNR-EXEC-SQL. */
            _.Move("1701", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1526- PERFORM R1700_00_CANC_PARC_DB_UPDATE_2 */

            R1700_00_CANC_PARC_DB_UPDATE_2();

            /*" -1529- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1530- DISPLAY 'R1700-00-HISTCOBVA' */
                _.Display($"R1700-00-HISTCOBVA");

                /*" -1531- DISPLAY 'APOLICE......  ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE......  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1532- DISPLAY 'SUBGRUPO.....  ' PROPOVA-COD-SUBGRUPO */
                _.Display($"SUBGRUPO.....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -1533- DISPLAY 'NRCERTIF.....  ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NRCERTIF.....  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1534- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1534- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-CANC-PARC-DB-UPDATE-1 */
        public void R1700_00_CANC_PARC_DB_UPDATE_1()
        {
            /*" -1506- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET SIT_REGISTRO = '2' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SIT_REGISTRO <> '1' END-EXEC. */

            var r1700_00_CANC_PARC_DB_UPDATE_1_Update1 = new R1700_00_CANC_PARC_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1700_00_CANC_PARC_DB_UPDATE_1_Update1.Execute(r1700_00_CANC_PARC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-CANC-PARC-DB-UPDATE-2 */
        public void R1700_00_CANC_PARC_DB_UPDATE_2()
        {
            /*" -1526- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = '2' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SIT_REGISTRO <> '1' END-EXEC. */

            var r1700_00_CANC_PARC_DB_UPDATE_2_Update1 = new R1700_00_CANC_PARC_DB_UPDATE_2_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1700_00_CANC_PARC_DB_UPDATE_2_Update1.Execute(r1700_00_CANC_PARC_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1800-00-SELECT-FIDRLIZ-SECTION */
        private void R1800_00_SELECT_FIDRLIZ_SECTION()
        {
            /*" -1545- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1569- PERFORM R1800_00_SELECT_FIDRLIZ_DB_SELECT_1 */

            R1800_00_SELECT_FIDRLIZ_DB_SELECT_1();

            /*" -1572- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1573- PERFORM R1810-00-GRAVA-R165-ST-SASSE */

                R1810_00_GRAVA_R165_ST_SASSE_SECTION();

                /*" -1574- PERFORM R1820-00-INSERT-HIST-FIDELIZ */

                R1820_00_INSERT_HIST_FIDELIZ_SECTION();

                /*" -1575- PERFORM R1830-00-CANCEL-FIDELIZ */

                R1830_00_CANCEL_FIDELIZ_SECTION();

                /*" -1576- ADD 1 TO WACC-CANC-SIGPF */
                WS_ARRAY.AREA_DE_WORK.WACC_CANC_SIGPF.Value = WS_ARRAY.AREA_DE_WORK.WACC_CANC_SIGPF + 1;

                /*" -1577- ELSE */
            }
            else
            {


                /*" -1578- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1579- DISPLAY 'R1820-00-INSERT-HIST-FIDELIZ' */
                    _.Display($"R1820-00-INSERT-HIST-FIDELIZ");

                    /*" -1580- DISPLAY 'NUM-CERTIFICADO.... ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM-CERTIFICADO.... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1581- DISPLAY 'SQLCODE............ ' SQLCODE */
                    _.Display($"SQLCODE............ {DB.SQLCODE}");

                    /*" -1582- END-IF */
                }


                /*" -1582- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-FIDRLIZ-DB-SELECT-1 */
        public void R1800_00_SELECT_FIDRLIZ_DB_SELECT_1()
        {
            /*" -1569- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PRODUTO_SIVPF INTO :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PRODUTO-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO AND SIT_PROPOSTA <> 'CAN' UNION SELECT NUM_SICOB, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PRODUTO_SIVPF INTO :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PRODUTO-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :PROPOVA-NUM-CERTIFICADO AND SIT_PROPOSTA <> 'CAN' END-EXEC. */

            var r1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1 = new R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1810-00-GRAVA-R165-ST-SASSE-SECTION */
        private void R1810_00_GRAVA_R165_ST_SASSE_SECTION()
        {
            /*" -1594- MOVE '1810' TO WNR-EXEC-SQL. */
            _.Move("1810", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1596- ADD 1 TO WACC-SIVPF. */
            WS_ARRAY.AREA_DE_WORK.WACC_SIVPF.Value = WS_ARRAY.AREA_DE_WORK.WACC_SIVPF + 1;

            /*" -1597- MOVE 1 TO R165-T1-IDENT */
            _.Move(1, R165_TIPO1_SASSE.R165_T1_IDENT);

            /*" -1598- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R165-T1-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, R165_TIPO1_SASSE.R165_T1_PROPOSTA);

            /*" -1599- MOVE ZEROS TO R165-T1-DV-PROPOSTA */
            _.Move(0, R165_TIPO1_SASSE.R165_T1_DV_PROPOSTA);

            /*" -1600- MOVE 'CAN' TO R165-T1-SIT-PROP */
            _.Move("CAN", R165_TIPO1_SASSE.R165_T1_SIT_PROP);

            /*" -1601- MOVE SPACES TO R165-T1-SIT-COB */
            _.Move("", R165_TIPO1_SASSE.R165_T1_SIT_COB);

            /*" -1602- MOVE 100 TO R165-T1-TP-MOTIVO */
            _.Move(100, R165_TIPO1_SASSE.R165_T1_TP_MOTIVO);

            /*" -1603- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO R165-T1-DT-INI-SIT(5:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), R165_TIPO1_SASSE.R165_T1_DT_INI_SIT, 5, 4);

            /*" -1604- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO R165-T1-DT-INI-SIT(3:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), R165_TIPO1_SASSE.R165_T1_DT_INI_SIT, 3, 2);

            /*" -1605- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO R165-T1-DT-INI-SIT(1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), R165_TIPO1_SASSE.R165_T1_DT_INI_SIT, 1, 2);

            /*" -1606- MOVE W-NSAS TO R165-T1-SEQ-ARQ */
            _.Move(W_NSAS, R165_TIPO1_SASSE.R165_T1_SEQ_ARQ);

            /*" -1607- MOVE WACC-SIVPF TO R165-T1-SEQ-REG */
            _.Move(WS_ARRAY.AREA_DE_WORK.WACC_SIVPF, R165_TIPO1_SASSE.R165_T1_SEQ_REG);

            /*" -1609- MOVE SPACES TO R165-T1-USO-RESERV */
            _.Move("", R165_TIPO1_SASSE.R165_T1_USO_RESERV);

            /*" -1609- WRITE REG-STSASSE FROM R165-TIPO1-SASSE. */
            _.Move(R165_TIPO1_SASSE.GetMoveValues(), REG_STSASSE);

            STSASSE.Write(REG_STSASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_99_SAIDA*/

        [StopWatch]
        /*" R1820-00-INSERT-HIST-FIDELIZ-SECTION */
        private void R1820_00_INSERT_HIST_FIDELIZ_SECTION()
        {
            /*" -1620- MOVE '1820' TO WNR-EXEC-SQL. */
            _.Move("1820", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1621- MOVE R165-T1-SEQ-ARQ TO PROPOFID-NSAS-SIVPF */
            _.Move(R165_TIPO1_SASSE.R165_T1_SEQ_ARQ, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -1622- MOVE R165-T1-SEQ-REG TO PROPOFID-NSL */
            _.Move(R165_TIPO1_SASSE.R165_T1_SEQ_REG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -1623- MOVE SPACES TO HISPROFI-SIT-COBRANCA-SIVPF */
            _.Move("", HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_COBRANCA_SIVPF);

            /*" -1643- PERFORM R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1 */

            R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1();

            /*" -1647- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1648- DISPLAY 'R1820-00-INSERT-HIST-FIDELIZ' */
                _.Display($"R1820-00-INSERT-HIST-FIDELIZ");

                /*" -1649- DISPLAY 'NUM-CERTIFICADO.... ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO.... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1650- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1650- END-IF. */
            }


        }

        [StopWatch]
        /*" R1820-00-INSERT-HIST-FIDELIZ-DB-INSERT-1 */
        public void R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1()
        {
            /*" -1643- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ (NUM_IDENTIFICACAO , DATA_SITUACAO , NSAS_SIVPF , NSL , SIT_PROPOSTA , SIT_COBRANCA_SIVPF , SIT_MOTIVO_SIVPF , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF ) VALUES (:PROPOFID-NUM-IDENTIFICACAO , :SISTEMAS-DATA-MOV-ABERTO , :PROPOFID-NSAS-SIVPF , :PROPOFID-NSL , 'CAN' , :HISPROFI-SIT-COBRANCA-SIVPF , 100 , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-COD-PRODUTO-SIVPF ) END-EXEC. */

            var r1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1 = new R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                HISPROFI_SIT_COBRANCA_SIVPF = HISPROFI.DCLHIST_PROP_FIDELIZ.HISPROFI_SIT_COBRANCA_SIVPF.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
            };

            R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1.Execute(r1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1820_99_SAIDA*/

        [StopWatch]
        /*" R1830-00-CANCEL-FIDELIZ-SECTION */
        private void R1830_00_CANCEL_FIDELIZ_SECTION()
        {
            /*" -1660- MOVE '1830' TO WNR-EXEC-SQL. */
            _.Move("1830", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1671- PERFORM R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1 */

            R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1();

            /*" -1674- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1675- DISPLAY 'R1830-00-CANCEL-FIDELIZ' */
                _.Display($"R1830-00-CANCEL-FIDELIZ");

                /*" -1676- DISPLAY 'NUM-CERTIFICADO.... ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO.... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1677- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -1677- END-IF. */
            }


        }

        [StopWatch]
        /*" R1830-00-CANCEL-FIDELIZ-DB-UPDATE-1 */
        public void R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1()
        {
            /*" -1671- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'R' , COD_USUARIO = 'VG0852B' , SIT_PROPOSTA = 'CAN' , NSAS_SIVPF = :PROPOFID-NSAS-SIVPF, NSL = :PROPOFID-NSL , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO OR NUM_SICOB = :PROPOVA-NUM-CERTIFICADO AND SIT_PROPOSTA <> 'CAN' END-EXEC. */

            var r1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1 = new R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1()
            {
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1.Execute(r1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1830_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-INSERT-MOV-VGAP-SECTION */
        private void R2000_00_INSERT_MOV_VGAP_SECTION()
        {
            /*" -1688- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1690- ADD 1 TO CONT-INS-MOV-VGAP. */
            CONT_INS_MOV_VGAP.Value = CONT_INS_MOV_VGAP + 1;

            /*" -1691- PERFORM R2300-00-SELECT-PERI-FATUR */

            R2300_00_SELECT_PERI_FATUR_SECTION();

            /*" -1692- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1693- GO TO R2000-99-SAIDA */

                R2000_99_SAIDA(); //GOTO
                return;

                /*" -1694- END-IF. */
            }


            /*" -1695- PERFORM R2400-00-CONTA-CORRENTE */

            R2400_00_CONTA_CORRENTE_SECTION();

            /*" -1696- PERFORM R2500-00-SELECT-IMP-SEGURADA */

            R2500_00_SELECT_IMP_SEGURADA_SECTION();

            /*" -1697- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1698- GO TO R2000-99-SAIDA */

                R2000_99_SAIDA(); //GOTO
                return;

                /*" -1699- END-IF. */
            }


            /*" -1700- PERFORM R2600-00-IMP-SEGURADA-IX */

            R2600_00_IMP_SEGURADA_IX_SECTION();

            /*" -1701- PERFORM R2700-00-IMP-SEGURADA-IX2 */

            R2700_00_IMP_SEGURADA_IX2_SECTION();

            /*" -1702- PERFORM R2800-00-V0COBA-IMPDIT */

            R2800_00_V0COBA_IMPDIT_SECTION();

            /*" -1702- PERFORM R2900-00-DATA-REFERENCIA. */

            R2900_00_DATA_REFERENCIA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2050_00_INSERT_MOV */

            R2050_00_INSERT_MOV();

        }

        [StopWatch]
        /*" R2050-00-INSERT-MOV */
        private void R2050_00_INSERT_MOV(bool isPerform = false)
        {
            /*" -1707- PERFORM R2100-00-SELECT-UPDATE-FONTES */

            R2100_00_SELECT_UPDATE_FONTES_SECTION();

            /*" -1708- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1709- GO TO R2050-00-INSERT-MOV */
                new Task(() => R2050_00_INSERT_MOV()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1710- END-IF. */
            }


            /*" -1863- PERFORM R2050_00_INSERT_MOV_DB_INSERT_1 */

            R2050_00_INSERT_MOV_DB_INSERT_1();

            /*" -1865- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1866- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1867- GO TO R2050-00-INSERT-MOV */
                    new Task(() => R2050_00_INSERT_MOV()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1868- ELSE */
                }
                else
                {


                    /*" -1869- DISPLAY 'ERRO  ' SUBGVGAP-PERI-FATURAMENTO */
                    _.Display($"ERRO  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO}");

                    /*" -1870- DISPLAY 'ERRO  ' FATURCON-DATA-REFERENCIA */
                    _.Display($"ERRO  {FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA}");

                    /*" -1871- DISPLAY 'ERRO  ' SISTEMAS-DATA-MOV-ABERTO */
                    _.Display($"ERRO  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                    /*" -1872- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1873- END-IF */
                }


                /*" -1873- END-IF. */
            }


        }

        [StopWatch]
        /*" R2050-00-INSERT-MOV-DB-INSERT-1 */
        public void R2050_00_INSERT_MOV_DB_INSERT_1()
        {
            /*" -1863- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_INCLUSAO , COD_CLIENTE , COD_AGENCIADOR , COD_CORRETOR , COD_PLANOVGAP , COD_PLANOAP , FAIXA , AUTOR_AUM_AUTOMAT , TIPO_BENEFICIARIO , PERI_PAGAMENTO , PERI_RENOVACAO , COD_OCUPACAO , ESTADO_CIVIL , IDE_SEXO , COD_PROFISSAO , NATURALIDADE , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , NUM_MATRICULA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , VAL_SALARIO , TIPO_SALARIO , TIPO_PLANO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO , DATA_AVERBACAO , DATA_ADMISSAO , DATA_INCLUSAO , DATA_NASCIMENTO , DATA_FATURA , DATA_REFERENCIA , DATA_MOVIMENTO , COD_EMPRESA , LOT_EMP_SEGURADO) VALUES (:PROPOVA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-COD-FONTE, :FONTES-ULT-PROP-AUTOMAT, '1' , :SEGURVGA-NUM-CERTIFICADO, ' ' , :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-COD-AGENCIADOR, 0, 0, 0, 0, 'S' , 'N' , :SUBGVGAP-PERI-FATURAMENTO, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, :CONTACOR-COD-AGENCIA, ' ' , :SEGURVGA-NUM-MATRICULA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :APOLICOB-IMP-SEGURADA-IX, :APOLICOB-IMP-SEGURADA-IX, :V0COBA-IMPMORACID, :V0COBA-IMPMORACID, :V0COBA-IMPINVPERM, :V0COBA-IMPINVPERM, 0, 0, 0, 0, :V0COBA-IMPDIT, :V0COBA-IMPDIT, :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-PRM-TARIFARIO-IX, :V0COBA-PRMAP, :V0COBA-PRMAP, 403, CURRENT DATE, 0, '1' , 'VG0852B' , CURRENT DATE, NULL, NULL, NULL, NULL, :FATURCON-DATA-REFERENCIA:VIND-DATA-REF, :SISTEMAS-DATA-MOV-ABERTO, NULL, NULL) END-EXEC. */

            var r2050_00_INSERT_MOV_DB_INSERT_1_Insert1 = new R2050_00_INSERT_MOV_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
                SEGURVGA_TIPO_INCLUSAO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                SEGURVGA_COD_AGENCIADOR = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR.ToString(),
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                CONTACOR_COD_AGENCIA = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA.ToString(),
                SEGURVGA_NUM_MATRICULA = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA.ToString(),
                CONTACOR_NUM_CTA_CORRENTE = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE.ToString(),
                CONTACOR_DAC_CTA_CORRENTE = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                V0COBA_IMPMORACID = V0COBA_IMPMORACID.ToString(),
                V0COBA_IMPINVPERM = V0COBA_IMPINVPERM.ToString(),
                V0COBA_IMPDIT = V0COBA_IMPDIT.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                V0COBA_PRMAP = V0COBA_PRMAP.ToString(),
                FATURCON_DATA_REFERENCIA = FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA.ToString(),
                VIND_DATA_REF = VIND_DATA_REF.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R2050_00_INSERT_MOV_DB_INSERT_1_Insert1.Execute(r2050_00_INSERT_MOV_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2000-99-SAIDA */
        private void R2000_99_SAIDA(bool isPerform = false)
        {
            /*" -1876- PERFORM R1595-00-FETCH-CSEGURA. */

            R1595_00_FETCH_CSEGURA_SECTION();

            /*" -1876- EXIT. */

            return;

        }

        [StopWatch]
        /*" R2100-00-SELECT-UPDATE-FONTES-SECTION */
        private void R2100_00_SELECT_UPDATE_FONTES_SECTION()
        {
            /*" -1885- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1890- PERFORM R2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1 */

            R2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1();

            /*" -1893- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1895- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1898- COMPUTE FONTES-ULT-PROP-AUTOMAT = FONTES-ULT-PROP-AUTOMAT + 1. */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1;

            /*" -1903- PERFORM R2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1 */

            R2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1();

        }

        [StopWatch]
        /*" R2100-00-SELECT-UPDATE-FONTES-DB-SELECT-1 */
        public void R2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1()
        {
            /*" -1890- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1_Query1 = new R2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            var executed_1 = R2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_UPDATE_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-UPDATE-FONTES-DB-UPDATE-1 */
        public void R2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1()
        {
            /*" -1903- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1_Update1 = new R2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            R2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1_Update1.Execute(r2100_00_SELECT_UPDATE_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-PERI-FATUR-SECTION */
        private void R2300_00_SELECT_PERI_FATUR_SECTION()
        {
            /*" -1913- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1915- MOVE PROPOVA-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -1921- PERFORM R2300_00_SELECT_PERI_FATUR_DB_SELECT_1 */

            R2300_00_SELECT_PERI_FATUR_DB_SELECT_1();

        }

        [StopWatch]
        /*" R2300-00-SELECT-PERI-FATUR-DB-SELECT-1 */
        public void R2300_00_SELECT_PERI_FATUR_DB_SELECT_1()
        {
            /*" -1921- EXEC SQL SELECT PERI_FATURAMENTO INTO :SUBGVGAP-PERI-FATURAMENTO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1 = new R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-CONTA-CORRENTE-SECTION */
        private void R2400_00_CONTA_CORRENTE_SECTION()
        {
            /*" -1932- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1941- PERFORM R2400_00_CONTA_CORRENTE_DB_SELECT_1 */

            R2400_00_CONTA_CORRENTE_DB_SELECT_1();

            /*" -1944- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1945- MOVE ZEROS TO CONTACOR-COD-AGENCIA */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);

                /*" -1946- MOVE ZEROS TO CONTACOR-NUM-CTA-CORRENTE */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);

                /*" -1947- MOVE SPACES TO CONTACOR-DAC-CTA-CORRENTE */
                _.Move("", CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);

                /*" -1947- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-CONTA-CORRENTE-DB-SELECT-1 */
        public void R2400_00_CONTA_CORRENTE_DB_SELECT_1()
        {
            /*" -1941- EXEC SQL SELECT COD_AGENCIA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE INTO :CONTACOR-COD-AGENCIA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE FROM SEGUROS.CONTA_CORRENTE WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2400_00_CONTA_CORRENTE_DB_SELECT_1_Query1 = new R2400_00_CONTA_CORRENTE_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2400_00_CONTA_CORRENTE_DB_SELECT_1_Query1.Execute(r2400_00_CONTA_CORRENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONTACOR_COD_AGENCIA, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);
                _.Move(executed_1.CONTACOR_NUM_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);
                _.Move(executed_1.CONTACOR_DAC_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-IMP-SEGURADA-SECTION */
        private void R2500_00_SELECT_IMP_SEGURADA_SECTION()
        {
            /*" -1959- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1972- PERFORM R2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1 */

            R2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1();

        }

        [StopWatch]
        /*" R2500-00-SELECT-IMP-SEGURADA-DB-SELECT-1 */
        public void R2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1()
        {
            /*" -1972- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :APOLICOB-IMP-SEGURADA-IX, :APOLICOB-PRM-TARIFARIO-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = 93 AND COD_COBERTURA = 11 END-EXEC. */

            var r2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1_Query1 = new R2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_IMP_SEGURADA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-IMP-SEGURADA-IX-SECTION */
        private void R2600_00_IMP_SEGURADA_IX_SECTION()
        {
            /*" -1983- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1996- PERFORM R2600_00_IMP_SEGURADA_IX_DB_SELECT_1 */

            R2600_00_IMP_SEGURADA_IX_DB_SELECT_1();

            /*" -1999- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2001- MOVE 0 TO V0COBA-IMPMORACID V0COBA-PRMAP */
                _.Move(0, V0COBA_IMPMORACID, V0COBA_PRMAP);

                /*" -2001- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-IMP-SEGURADA-IX-DB-SELECT-1 */
        public void R2600_00_IMP_SEGURADA_IX_DB_SELECT_1()
        {
            /*" -1996- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORACID, :V0COBA-PRMAP FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 1 END-EXEC. */

            var r2600_00_IMP_SEGURADA_IX_DB_SELECT_1_Query1 = new R2600_00_IMP_SEGURADA_IX_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R2600_00_IMP_SEGURADA_IX_DB_SELECT_1_Query1.Execute(r2600_00_IMP_SEGURADA_IX_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORACID, V0COBA_IMPMORACID);
                _.Move(executed_1.V0COBA_PRMAP, V0COBA_PRMAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-IMP-SEGURADA-IX2-SECTION */
        private void R2700_00_IMP_SEGURADA_IX2_SECTION()
        {
            /*" -2012- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2023- PERFORM R2700_00_IMP_SEGURADA_IX2_DB_SELECT_1 */

            R2700_00_IMP_SEGURADA_IX2_DB_SELECT_1();

            /*" -2026- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2027- MOVE 0 TO V0COBA-IMPINVPERM */
                _.Move(0, V0COBA_IMPINVPERM);

                /*" -2027- END-IF. */
            }


        }

        [StopWatch]
        /*" R2700-00-IMP-SEGURADA-IX2-DB-SELECT-1 */
        public void R2700_00_IMP_SEGURADA_IX2_DB_SELECT_1()
        {
            /*" -2023- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPINVPERM FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 2 END-EXEC. */

            var r2700_00_IMP_SEGURADA_IX2_DB_SELECT_1_Query1 = new R2700_00_IMP_SEGURADA_IX2_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R2700_00_IMP_SEGURADA_IX2_DB_SELECT_1_Query1.Execute(r2700_00_IMP_SEGURADA_IX2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPINVPERM, V0COBA_IMPINVPERM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-V0COBA-IMPDIT-SECTION */
        private void R2800_00_V0COBA_IMPDIT_SECTION()
        {
            /*" -2038- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2049- PERFORM R2800_00_V0COBA_IMPDIT_DB_SELECT_1 */

            R2800_00_V0COBA_IMPDIT_DB_SELECT_1();

            /*" -2052- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2052- MOVE 0 TO V0COBA-IMPDIT. */
                _.Move(0, V0COBA_IMPDIT);
            }


        }

        [StopWatch]
        /*" R2800-00-V0COBA-IMPDIT-DB-SELECT-1 */
        public void R2800_00_V0COBA_IMPDIT_DB_SELECT_1()
        {
            /*" -2049- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPDIT FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 5 END-EXEC. */

            var r2800_00_V0COBA_IMPDIT_DB_SELECT_1_Query1 = new R2800_00_V0COBA_IMPDIT_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R2800_00_V0COBA_IMPDIT_DB_SELECT_1_Query1.Execute(r2800_00_V0COBA_IMPDIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPDIT, V0COBA_IMPDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-DATA-REFERENCIA-SECTION */
        private void R2900_00_DATA_REFERENCIA_SECTION()
        {
            /*" -2063- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WS_ARRAY.AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2065- MOVE ZEROS TO VIND-DATA-REF */
            _.Move(0, VIND_DATA_REF);

            /*" -2071- PERFORM R2900_00_DATA_REFERENCIA_DB_SELECT_1 */

            R2900_00_DATA_REFERENCIA_DB_SELECT_1();

            /*" -2074- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2081- PERFORM R2900_00_DATA_REFERENCIA_DB_SELECT_2 */

                R2900_00_DATA_REFERENCIA_DB_SELECT_2();

                /*" -2083- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2085- MOVE SISTEMAS-DATA-MOV-ABERTO TO FATURCON-DATA-REFERENCIA */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);

                    /*" -2086- END-IF */
                }


                /*" -2086- END-IF. */
            }


        }

        [StopWatch]
        /*" R2900-00-DATA-REFERENCIA-DB-SELECT-1 */
        public void R2900_00_DATA_REFERENCIA_DB_SELECT_1()
        {
            /*" -2071- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r2900_00_DATA_REFERENCIA_DB_SELECT_1_Query1 = new R2900_00_DATA_REFERENCIA_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2900_00_DATA_REFERENCIA_DB_SELECT_1_Query1.Execute(r2900_00_DATA_REFERENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-DATA-REFERENCIA-DB-SELECT-2 */
        public void R2900_00_DATA_REFERENCIA_DB_SELECT_2()
        {
            /*" -2081- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = 0 WITH UR END-EXEC */

            var r2900_00_DATA_REFERENCIA_DB_SELECT_2_Query1 = new R2900_00_DATA_REFERENCIA_DB_SELECT_2_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2900_00_DATA_REFERENCIA_DB_SELECT_2_Query1.Execute(r2900_00_DATA_REFERENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2099- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WS_ARRAY.AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2101- DISPLAY WABEND */
            _.Display(WS_ARRAY.AREA_DE_WORK.WABEND);

            /*" -2102- DISPLAY 'LIDOS 1  CHISTC  ' WACC-LIDOS. */
            _.Display($"LIDOS 1  CHISTC  {WS_ARRAY.AREA_DE_WORK.WACC_LIDOS}");

            /*" -2103- DISPLAY 'LIDOS 2  CSEGUR  ' WACC-LIDO2. */
            _.Display($"LIDOS 2  CSEGUR  {WS_ARRAY.AREA_DE_WORK.WACC_LIDO2}");

            /*" -2105- DISPLAY 'CERTIFICADO ' PROPOVA-NUM-CERTIFICADO */
            _.Display($"CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -2105- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2107- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2111- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2111- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}